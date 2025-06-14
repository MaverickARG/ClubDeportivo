using System;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class FrmModificarConexion : Form
    {
        public FrmModificarConexion()
        {
            InitializeComponent();
        }

        private void btnGuardarConexion_Click(object sender, EventArgs e)
        {
            string servidor = txtServidor.Text.Trim();
            string puerto = txtPuerto.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();
            string baseDatos = txtBaseDatos.Text.Trim();

            if (string.IsNullOrEmpty(servidor) || string.IsNullOrEmpty(puerto) ||
                string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(baseDatos))
            {
                MessageBox.Show("Complete todos los campos obligatorios.");
                return;
            }

            try
            {
                // Guardar configuración en memoria
                Conexion.Configurar(servidor, puerto, usuario, clave, baseDatos);

                // Probar conexión
                using (var conn = Conexion.GetConnection())
                {
                    conn.Open();
                    conn.Close();
                }

                MessageBox.Show("Conexión exitosa.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar:\n" + ex.Message);
            }
        }
    }
}
