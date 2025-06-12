using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
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
            using (MySqlConnection conn = DB.GetConnection())
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

            using (MySqlConnection conn = DB.GetConnection())
            {
                conn.Open();

                // Actualizar datos en persona
                string query = "UPDATE persona SET dni = @nuevoDni, nombre = @nombre, apellido = @apellido, aptoFisico = @apto WHERE dni = @dniOriginal";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nuevoDni", nuevoDni);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                cmd.Parameters.AddWithValue("@apto", chkAptoFisico.Checked);
                cmd.Parameters.AddWithValue("@dniOriginal", dniOriginal);

                cmd.ExecuteNonQuery();

                // Actualizar tipo (socio o no socio)
                if (rbSocio.Checked)
                {
                    // Insertar socio si no existe
                    string insertSocio = "INSERT IGNORE INTO socio (dni, fechaAltaSocio, carnetActivo, valorCuota) VALUES (@dni, CURDATE(), 0, 0)";
                    MySqlCommand cmdSocio = new MySqlCommand(insertSocio, conn);
                    cmdSocio.Parameters.AddWithValue("@dni", nuevoDni);
                    cmdSocio.ExecuteNonQuery();

                    string deletePagos = @"
    DELETE FROM pagodiario 
    WHERE idNoSocio IN (SELECT idNoSocio FROM nosocio WHERE dni = @dni)";
                    MySqlCommand cmdDeletePagos = new MySqlCommand(deletePagos, conn);
                    cmdDeletePagos.Parameters.AddWithValue("@dni", nuevoDni);
                    cmdDeletePagos.ExecuteNonQuery();
                }
                else if (rbNoSocio.Checked)
                {
                    // Insertar no socio si no existe
                    string insertNoSocio = "INSERT IGNORE INTO nosocio (dni, noSocioActivo) VALUES (@dni, 0)";
                    MySqlCommand cmdNoSocio = new MySqlCommand(insertNoSocio, conn);
                    cmdNoSocio.Parameters.AddWithValue("@dni", nuevoDni);
                    cmdNoSocio.ExecuteNonQuery();

                    // Eliminar si existía como socio
                    MySqlCommand cmdDeleteSocio = new MySqlCommand("DELETE FROM socio WHERE dni = @dni", conn);
                    cmdDeleteSocio.Parameters.AddWithValue("@dni", nuevoDni);
                    cmdDeleteSocio.ExecuteNonQuery();
                }
            }

            NuevoDni = nuevoDni;
            MessageBox.Show("Datos modificados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
