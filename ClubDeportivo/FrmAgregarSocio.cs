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


            // Validar campos vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(dniTexto))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que DNI (entre 7 y 8 numeros) y Cuota sean números válidos
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

            //declaracion de aptofisico y fechaAlta

            bool aptoFisico = chkAptoFisico.Checked;
            DateTime fechaAlta = DateTime.Now;

            using (MySqlConnection connection = DB.GetConnection())
            {
                connection.Open();

                // Verificar si ya existe ese DNI
                string verificarQuery = "SELECT COUNT(*) FROM Persona WHERE dni = @dni";
                MySqlCommand verificarCmd = new MySqlCommand(verificarQuery, connection);
                verificarCmd.Parameters.AddWithValue("@dni", dni);
                int existe = Convert.ToInt32(verificarCmd.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("El DNI ingresado ya existe. No se puede cargar el socio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insertar en transacción
                MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string queryPersona = "INSERT INTO Persona (dni, nombre, apellido, aptoFisico) VALUES (@dni, @nombre, @apellido, @apto)";
                    MySqlCommand cmdPersona = new MySqlCommand(queryPersona, connection, transaction);
                    cmdPersona.Parameters.AddWithValue("@dni", dni);
                    cmdPersona.Parameters.AddWithValue("@nombre", nombre);
                    cmdPersona.Parameters.AddWithValue("@apellido", apellido);
                    cmdPersona.Parameters.AddWithValue("@apto", aptoFisico);
                    cmdPersona.ExecuteNonQuery();

                    string querySocio = "INSERT INTO Socio (fechaAltaSocio, carnetActivo, dni) VALUES (@fecha, @carnet, @dni)";
                    MySqlCommand cmdSocio = new MySqlCommand(querySocio, connection, transaction);
                    cmdSocio.Parameters.AddWithValue("@fecha", fechaAlta);
                    cmdSocio.Parameters.AddWithValue("@carnet", false);
                    cmdSocio.Parameters.AddWithValue("@dni", dni);
                    cmdSocio.ExecuteNonQuery();

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
