using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    public partial class FrmAgregarSocio : Form
    {
        public FrmAgregarSocio()
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
                MessageBox.Show("Debe marcar que el socio tiene Apto Físico para poder registrarlo.", "Apto Físico requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    // Verificar si la persona existe
                    string checkPersona = "SELECT COUNT(*) FROM persona WHERE dni = @dni";
                    MySqlCommand cmdCheckPersona = new MySqlCommand(checkPersona, connection, transaction);
                    cmdCheckPersona.Parameters.AddWithValue("@dni", dni);
                    int personaExiste = Convert.ToInt32(cmdCheckPersona.ExecuteScalar());

                    if (personaExiste > 0)
                    {
                        // Reactivar persona si es necesario
                        string updatePersona = "UPDATE persona SET nombre = @nombre, apellido = @apellido, aptoFisico = @apto WHERE dni = @dni";
                        MySqlCommand cmdUpdate = new MySqlCommand(updatePersona, connection, transaction);
                        cmdUpdate.Parameters.AddWithValue("@nombre", nombre);
                        cmdUpdate.Parameters.AddWithValue("@apellido", apellido);
                        cmdUpdate.Parameters.AddWithValue("@apto", aptoFisico);
                        cmdUpdate.Parameters.AddWithValue("@dni", dni);
                        cmdUpdate.ExecuteNonQuery();
                    }
                    else
                    {
                        string insertarPersona = "INSERT INTO persona (dni, nombre, apellido, aptoFisico) VALUES (@dni, @nombre, @apellido, @apto)";
                        MySqlCommand cmdInsert = new MySqlCommand(insertarPersona, connection, transaction);
                        cmdInsert.Parameters.AddWithValue("@dni", dni);
                        cmdInsert.Parameters.AddWithValue("@nombre", nombre);
                        cmdInsert.Parameters.AddWithValue("@apellido", apellido);
                        cmdInsert.Parameters.AddWithValue("@apto", aptoFisico);
                        cmdInsert.ExecuteNonQuery();
                    }

                    // Si existe como No Socio activo → lo damos de baja
                    string desactivarNoSocio = "UPDATE nosocio SET activo = 0, deletedOn = NOW() WHERE dni = @dni AND activo = 1";
                    MySqlCommand cmdBajaNoSocio = new MySqlCommand(desactivarNoSocio, connection, transaction);
                    cmdBajaNoSocio.Parameters.AddWithValue("@dni", dni);
                    cmdBajaNoSocio.ExecuteNonQuery();

                    // Verificar si ya existe como socio
                    string checkSocio = "SELECT COUNT(*) FROM socio WHERE dni = @dni";
                    MySqlCommand cmdCheckSocio = new MySqlCommand(checkSocio, connection, transaction);
                    cmdCheckSocio.Parameters.AddWithValue("@dni", dni);
                    int existeSocio = Convert.ToInt32(cmdCheckSocio.ExecuteScalar());

                    if (existeSocio > 0)
                    {
                        // Reactivar socio si ya existía
                        string reactivarSocio = @"
                    UPDATE socio 
                    SET fechaAltaSocio = @fecha, carnetActivo = 0, activo = 1, deletedOn = NULL 
                    WHERE dni = @dni";
                        MySqlCommand cmdReactivar = new MySqlCommand(reactivarSocio, connection, transaction);
                        cmdReactivar.Parameters.AddWithValue("@fecha", fechaAlta);
                        cmdReactivar.Parameters.AddWithValue("@dni", dni);
                        cmdReactivar.ExecuteNonQuery();
                    }
                    else
                    {
                        // Insertar nuevo socio
                        string insertarSocio = @"
                    INSERT INTO socio (fechaAltaSocio, carnetActivo, dni, activo) 
                    VALUES (@fecha, 0, @dni, 1)";
                        MySqlCommand cmdInsert = new MySqlCommand(insertarSocio, connection, transaction);
                        cmdInsert.Parameters.AddWithValue("@fecha", fechaAlta);
                        cmdInsert.Parameters.AddWithValue("@dni", dni);
                        cmdInsert.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Socio agregado correctamente.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al guardar el socio:\n" + ex.Message);
                }
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAgregarSocio_Load(object sender, EventArgs e)
        {

        }

        private void chkAptoFisico_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
