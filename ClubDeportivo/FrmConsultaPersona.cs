using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClubDeportivo
{
    public partial class FrmConsultaPersona : Form
    {
        public FrmConsultaPersona()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dniTexto = txtDni.Text.Trim();

            if (!int.TryParse(dniTexto, out int dni) || dniTexto.Length < 7 || dniTexto.Length > 8)
            {
                MessageBox.Show("Ingrese un DNI válido (7 u 8 dígitos).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DB.GetConnection())
            {
                try
                {
                    conn.Open();

                    string consulta = "SELECT * FROM VistaDatosPersona WHERE dni = @dni";
                    MySqlCommand cmd = new MySqlCommand(consulta, conn);
                    cmd.Parameters.AddWithValue("@dni", dni);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron datos para ese DNI.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDatosPersona.DataSource = null;
                    }
                    else
                    {
                        dgvDatosPersona.DataSource = dt;
                    }
                    // Ocultar columnas donde todos los valores están vacíos o nulos
                    foreach (DataGridViewColumn col in dgvDatosPersona.Columns)
                    {
                        bool columnaVacia = true;

                        foreach (DataGridViewRow row in dgvDatosPersona.Rows)
                        {
                            if (row.Cells[col.Index].Value != DBNull.Value &&
                                !string.IsNullOrWhiteSpace(row.Cells[col.Index].Value?.ToString()))
                            {
                                columnaVacia = false;
                                break;
                            }
                        }

                        col.Visible = !columnaVacia;
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDatosPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
