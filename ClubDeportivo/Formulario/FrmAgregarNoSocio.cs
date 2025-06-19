using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClubDeportivo.Datos;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    public partial class FrmAgregarNoSocio : Form
    {
        public FrmAgregarNoSocio()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string dniTexto = txtDni.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(dniTexto))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(dniTexto, out int dni))
            {
                MessageBox.Show("El DNI debe ser un número entero válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dniTexto.Length < 7 || dniTexto.Length > 8)
            {
                MessageBox.Show("El DNI debe tener entre 7 y 8 dígitos.", "DNI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!chkAptoFisico.Checked)
            {
                MessageBox.Show("Debe marcar que el no socio tiene Apto Físico para poder registrarlo.", "Apto Físico requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool aptoFisico = chkAptoFisico.Checked;
            DateTime fechaAlta = DateTime.Now;

            using (MySqlConnection connection = Conexion.GetConnection())
            {
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // ⚠️ Verificar que NO esté como Socio activo con cuota activa
                    string checkSocioActivo = @"
                        SELECT COUNT(*) FROM socio 
                        WHERE dni = @dni AND activo = 1 
                        AND idSocio IN (
                            SELECT idSocio FROM cuotasocio 
                            WHERE activo = 1 AND vencimientoPago >= CURDATE()
                        )";

                    MySqlCommand cmdCheckSocio = new MySqlCommand(checkSocioActivo, connection, transaction);
                    cmdCheckSocio.Parameters.AddWithValue("@dni", dni);
                    int socioConCuotaActiva = Convert.ToInt32(cmdCheckSocio.ExecuteScalar());

                    if (socioConCuotaActiva > 0)
                    {
                        MessageBox.Show("Este DNI tiene una cuota activa como Socio. No puede registrarse como No Socio.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        transaction.Rollback();
                        return;
                    }

                    // Verificar si ya existe la persona
                    string verificarPersona = "SELECT COUNT(*) FROM persona WHERE dni = @dni";
                    MySqlCommand cmdVerificarPersona = new MySqlCommand(verificarPersona, connection, transaction);
                    cmdVerificarPersona.Parameters.AddWithValue("@dni", dni);
                    int personaExiste = Convert.ToInt32(cmdVerificarPersona.ExecuteScalar());

                    if (personaExiste > 0)
                    {
                        // Reactivar o actualizar persona existente
                        string actualizarPersona = @"
                            UPDATE persona 
                            SET nombre = @nombre, apellido = @apellido, aptoFisico = @apto 
                            WHERE dni = @dni";
                        MySqlCommand cmdPersona = new MySqlCommand(actualizarPersona, connection, transaction);
                        cmdPersona.Parameters.AddWithValue("@nombre", nombre);
                        cmdPersona.Parameters.AddWithValue("@apellido", apellido);
                        cmdPersona.Parameters.AddWithValue("@apto", aptoFisico);
                        cmdPersona.Parameters.AddWithValue("@dni", dni);
                        cmdPersona.ExecuteNonQuery();
                    }
                    else
                    {
                        // Insertar nueva persona
                        string insertarPersona = "INSERT INTO persona (dni, nombre, apellido, aptoFisico) VALUES (@dni, @nombre, @apellido, @apto)";
                        MySqlCommand cmdPersona = new MySqlCommand(insertarPersona, connection, transaction);
                        cmdPersona.Parameters.AddWithValue("@dni", dni);
                        cmdPersona.Parameters.AddWithValue("@nombre", nombre);
                        cmdPersona.Parameters.AddWithValue("@apellido", apellido);
                        cmdPersona.Parameters.AddWithValue("@apto", aptoFisico);
                        cmdPersona.ExecuteNonQuery();
                    }

                    // Si existe como Socio, lo pasamos a inactivo
                    string desactivarSocio = "UPDATE socio SET activo = 0, deletedOn = NOW() WHERE dni = @dni AND activo = 1";
                    MySqlCommand cmdBajaSocio = new MySqlCommand(desactivarSocio, connection, transaction);
                    cmdBajaSocio.Parameters.AddWithValue("@dni", dni);
                    cmdBajaSocio.ExecuteNonQuery();

                    // Verificar si ya existe en nosocio
                    string verificarNoSocio = "SELECT COUNT(*) FROM nosocio WHERE dni = @dni";
                    MySqlCommand cmdVerificarNoSocio = new MySqlCommand(verificarNoSocio, connection, transaction);
                    cmdVerificarNoSocio.Parameters.AddWithValue("@dni", dni);
                    int noSocioExiste = Convert.ToInt32(cmdVerificarNoSocio.ExecuteScalar());

                    if (noSocioExiste > 0)
                    {
                        // Reactivar no socio
                        string reactivarNoSocio = @"
                            UPDATE nosocio 
                            SET fechaActividad = @fecha, noSocioActivo = 0, activo = 1, deletedOn = NULL 
                            WHERE dni = @dni";
                        MySqlCommand cmdUpdate = new MySqlCommand(reactivarNoSocio, connection, transaction);
                        cmdUpdate.Parameters.AddWithValue("@fecha", fechaAlta);
                        cmdUpdate.Parameters.AddWithValue("@dni", dni);
                        cmdUpdate.ExecuteNonQuery();
                    }
                    else
                    {
                        // Insertar nuevo no socio
                        string insertarNoSocio = @"
                            INSERT INTO nosocio (fechaActividad, noSocioActivo, dni, activo) 
                            VALUES (@fecha, 0, @dni, 1)";
                        MySqlCommand cmdInsert = new MySqlCommand(insertarNoSocio, connection, transaction);
                        cmdInsert.Parameters.AddWithValue("@fecha", fechaAlta);
                        cmdInsert.Parameters.AddWithValue("@dni", dni);
                        cmdInsert.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("No Socio agregado correctamente.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al guardar el no socio:\n" + ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
