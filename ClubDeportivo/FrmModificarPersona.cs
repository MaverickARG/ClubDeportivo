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
    public partial class FrmModificarPersona : Form
    {
        private int dni;

        public FrmModificarPersona(int dni)
        {
            InitializeComponent();
            this.dni = dni;
            this.Load += new System.EventHandler(this.FrmModificarPersona_Load);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
        }

        private void FrmModificarPersona_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            using (MySqlConnection conn = DB.GetConnection())
            {
                conn.Open();
                string query = "SELECT nombre, apellido, aptoFisico FROM persona WHERE dni = @dni";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtNombre.Text = reader["nombre"].ToString();
                        txtApellido.Text = reader["apellido"].ToString();
                        chkAptoFisico.Checked = Convert.ToBoolean(reader["aptoFisico"]);
                        txtDni.Text = dni.ToString();
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DB.GetConnection())
            {
                conn.Open();

                // Nuevo DNI ingresado
                int nuevoDni;
                if (!int.TryParse(txtDni.Text.Trim(), out nuevoDni))
                {
                    MessageBox.Show("Ingrese un DNI válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Actualizamos todas las tablas relacionadas
                string queryPersona = "UPDATE persona SET dni = @nuevoDni, nombre = @nombre, apellido = @apellido, aptoFisico = @apto WHERE dni = @dni";
                string querySocio = "UPDATE socio SET dni = @nuevoDni WHERE dni = @dni";
                string queryNoSocio = "UPDATE nosocio SET dni = @nuevoDni WHERE dni = @dni";

                MySqlCommand cmdPersona = new MySqlCommand(queryPersona, conn);
                MySqlCommand cmdSocio = new MySqlCommand(querySocio, conn);
                MySqlCommand cmdNoSocio = new MySqlCommand(queryNoSocio, conn);

                // Parámetros
                cmdPersona.Parameters.AddWithValue("@nuevoDni", nuevoDni);
                cmdPersona.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmdPersona.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                cmdPersona.Parameters.AddWithValue("@apto", chkAptoFisico.Checked);
                cmdPersona.Parameters.AddWithValue("@dni", dni);

                cmdSocio.Parameters.AddWithValue("@nuevoDni", nuevoDni);
                cmdSocio.Parameters.AddWithValue("@dni", dni);

                cmdNoSocio.Parameters.AddWithValue("@nuevoDni", nuevoDni);
                cmdNoSocio.Parameters.AddWithValue("@dni", dni);

                // Ejecutar
                cmdSocio.ExecuteNonQuery();
                cmdNoSocio.ExecuteNonQuery();
                cmdPersona.ExecuteNonQuery();

                MessageBox.Show("Datos modificados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
