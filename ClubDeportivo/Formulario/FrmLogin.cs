﻿using System;
using System.Windows.Forms;
using ClubDeportivo.Datos;
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

        }

        private void CargarUsuarios()
        {
            cmbUsuarios.Items.Clear();

            try
            {
                using (MySqlConnection connection = Conexion.GetConnection())
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
            }
            catch (Exception)
            {
                MessageBox.Show("No estás conectado a la base de datos.\nPor favor configurá la conexión.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            FrmModificarConexion frm = new FrmModificarConexion();
            frm.FormClosed += (s, args) =>
            {
                try
                {
                    CargarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar usuarios: " + ex.Message);
                }
            };
            frm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = cmbUsuarios.Text.Trim();
            string contrasena = txtPassword.Text;

            try
            {
                using (MySqlConnection connection = Conexion.GetConnection())
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
            }
            catch (Exception)
            {
                MessageBox.Show("No estás conectado a la base de datos.\nPor favor configurá la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
