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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            using (MySqlConnection connection = Conexion.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT usuario FROM Administrador";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbUsuarios.Items.Add(reader.GetString("usuario"));
                    }

                    if (cmbUsuarios.Items.Count > 0)
                        cmbUsuarios.SelectedIndex = 0;

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar usuarios: " + ex.Message);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = cmbUsuarios.Text.Trim();
            string contrasena = txtPassword.Text;

            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("No existe el usuario / usuario incorrecto.");
                return;
            }

            using (MySqlConnection connection = DB.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Administrador WHERE usuario = @usuario AND pass = @pass";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@pass", contrasena);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        FrmMenu main = new FrmMenu();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos:\n" + ex.Message);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
