using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ClubDeportivo.Datos;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    public partial class FrmModificarPersona : Form
    {
        private int dniOriginal;
        public int NuevoDni { get; private set; }

        public FrmModificarPersona(int dni)
        {
            InitializeComponent();
            this.dniOriginal = dni;
        }

        private void FrmModificarPersona_Load(object sender, EventArgs e)
        {
            using (MySqlConnection conn = Conexion.GetConnection())
            {
                conn.Open();

                // Cargar datos de persona
                string query = "SELECT nombre, apellido, aptoFisico FROM persona WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dniOriginal);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtNombre.Text = reader["nombre"].ToString();
                        txtApellido.Text = reader["apellido"].ToString();
                        chkAptoFisico.Checked = Convert.ToBoolean(reader["aptoFisico"]);
                        txtDni.Text = dniOriginal.ToString();
                    }
                }

                // Cargar si es Socio o No Socio
                string querySocio = "SELECT COUNT(*) FROM socio WHERE dni = @dni";
                MySqlCommand cmdSocio = new MySqlCommand(querySocio, conn);
                cmdSocio.Parameters.AddWithValue("@dni", dniOriginal);
                long esSocio = (long)cmdSocio.ExecuteScalar();

                if (esSocio > 0)
                {
                    rbSocio.Checked = true;
                }
                else
                {
                    string queryNoSocio = "SELECT COUNT(*) FROM nosocio WHERE dni = @dni";
                    MySqlCommand cmdNoSocio = new MySqlCommand(queryNoSocio, conn);
                    cmdNoSocio.Parameters.AddWithValue("@dni", dniOriginal);
                    long esNoSocio = (long)cmdNoSocio.ExecuteScalar();

                    if (esNoSocio > 0)
                    {
                        rbNoSocio.Checked = true;
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDni.Text.Trim(), out int nuevoDni))
            {
                MessageBox.Show("Ingrese un DNI válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = Conexion.GetConnection())
            {
                conn.Open();
                MySqlTransaction tx = conn.BeginTransaction();

                try
                {
                    // Actualizar datos en persona
                    string query = @"UPDATE persona 
                             SET dni = @nuevoDni, nombre = @nombre, apellido = @apellido, aptoFisico = @apto 
                             WHERE dni = @dniOriginal";
                    MySqlCommand cmd = new MySqlCommand(query, conn, tx);
                    cmd.Parameters.AddWithValue("@nuevoDni", nuevoDni);
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@apto", chkAptoFisico.Checked);
                    cmd.Parameters.AddWithValue("@dniOriginal", dniOriginal);
                    cmd.ExecuteNonQuery();

                    if (rbSocio.Checked)
                    {
                        // Desactivar No Socio si existiera
                        string desactivarNoSocio = "UPDATE nosocio SET activo = 0, deletedOn = NOW() WHERE dni = @dni AND activo = 1";
                        MySqlCommand cmdDesactivar = new MySqlCommand(desactivarNoSocio, conn, tx);
                        cmdDesactivar.Parameters.AddWithValue("@dni", nuevoDni);
                        cmdDesactivar.ExecuteNonQuery();

                        // Obtener fecha más antigua de cuota
                        string obtenerFechaAlta = @"
                    SELECT MIN(fechaPagoSocio) 
                    FROM cuotasocio 
                    WHERE idSocio = (SELECT idSocio FROM socio WHERE dni = @dni)";
                        MySqlCommand cmdFechaAlta = new MySqlCommand(obtenerFechaAlta, conn, tx);
                        cmdFechaAlta.Parameters.AddWithValue("@dni", nuevoDni);
                        object resultadoFecha = cmdFechaAlta.ExecuteScalar();
                        DateTime fechaAltaSocio = resultadoFecha != DBNull.Value ? Convert.ToDateTime(resultadoFecha) : DateTime.Today;

                        // Insertar o reactivar socio
                        string upsertSocio = @"
                    INSERT INTO socio (dni, fechaAltaSocio, carnetActivo, valorCuota, activo) 
                    VALUES (@dni, @fechaAlta, 0, 0, 1)
                    ON DUPLICATE KEY UPDATE 
                        fechaAltaSocio = @fechaAlta, 
                        carnetActivo = 0, 
                        activo = 1, 
                        deletedOn = NULL";
                        MySqlCommand cmdUpsert = new MySqlCommand(upsertSocio, conn, tx);
                        cmdUpsert.Parameters.AddWithValue("@dni", nuevoDni);
                        cmdUpsert.Parameters.AddWithValue("@fechaAlta", fechaAltaSocio);
                        cmdUpsert.ExecuteNonQuery();

                        // Reactivar TODAS las cuotas desactivadas
                        string reactivarCuotas = @"
                    UPDATE cuotasocio 
                    SET activo = 1, deletedOn = NULL
                    WHERE idSocio = (SELECT idSocio FROM socio WHERE dni = @dni)
                    AND activo = 0";
                        MySqlCommand cmdReactivarCuotas = new MySqlCommand(reactivarCuotas, conn, tx);
                        cmdReactivarCuotas.Parameters.AddWithValue("@dni", nuevoDni);
                        cmdReactivarCuotas.ExecuteNonQuery();
                    }
                    else if (rbNoSocio.Checked)
                    {
                        // Verificar si tiene cuota activa
                        string checkCuota = @"
                    SELECT vencimientoPago 
                    FROM cuotasocio 
                    WHERE idSocio = (SELECT idSocio FROM socio WHERE dni = @dni AND activo = 1) 
                    AND activo = 1
                    ORDER BY vencimientoPago DESC LIMIT 1";
                        MySqlCommand cmdCheck = new MySqlCommand(checkCuota, conn, tx);
                        cmdCheck.Parameters.AddWithValue("@dni", nuevoDni);
                        object result = cmdCheck.ExecuteScalar();

                        if (result != null && Convert.ToDateTime(result) >= DateTime.Today)
                        {
                            MessageBox.Show("El socio tiene una cuota activa. No puede pasarse a No Socio hasta que la misma esté vencida.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Desactivar Socio
                        string desactivarSocio = "UPDATE socio SET activo = 0, deletedOn = NOW() WHERE dni = @dni AND activo = 1";
                        MySqlCommand cmdBajaSocio = new MySqlCommand(desactivarSocio, conn, tx);
                        cmdBajaSocio.Parameters.AddWithValue("@dni", nuevoDni);
                        cmdBajaSocio.ExecuteNonQuery();

                        // Desactivar todas las cuotas
                        string desactivarCuotas = @"
                    UPDATE cuotasocio 
                    SET activo = 0, deletedOn = NOW() 
                    WHERE idSocio = (SELECT idSocio FROM socio WHERE dni = @dni)";
                        MySqlCommand cmdBajaCuotas = new MySqlCommand(desactivarCuotas, conn, tx);
                        cmdBajaCuotas.Parameters.AddWithValue("@dni", nuevoDni);
                        cmdBajaCuotas.ExecuteNonQuery();

                        // Insertar o reactivar No Socio
                        string upsertNoSocio = @"
                    INSERT INTO nosocio (dni, fechaActividad, noSocioActivo, activo) 
                    VALUES (@dni, CURDATE(), 0, 1)
                    ON DUPLICATE KEY UPDATE 
                        fechaActividad = CURDATE(), 
                        activo = 1, 
                        deletedOn = NULL";
                        MySqlCommand cmdUpsertNoSocio = new MySqlCommand(upsertNoSocio, conn, tx);
                        cmdUpsertNoSocio.Parameters.AddWithValue("@dni", nuevoDni);
                        cmdUpsertNoSocio.ExecuteNonQuery();
                    }

                    tx.Commit();
                    NuevoDni = nuevoDni;
                    MessageBox.Show("Datos modificados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("Error al modificar:\n" + ex.Message);
                }
            }
        }




        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
