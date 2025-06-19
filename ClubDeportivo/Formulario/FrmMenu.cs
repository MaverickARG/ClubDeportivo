using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClubDeportivo.Datos;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace ClubDeportivo
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        private void btnListarVencimientos_Click(object? sender, EventArgs e)
        {
            string query = @"
    SELECT p.Nombre, p.Apellido, p.Dni, c.VencimientoPago
    FROM persona p
    INNER JOIN socio s ON p.Dni = s.Dni
    INNER JOIN cuotasocio c ON s.IdSocio = c.IdSocio
    WHERE DATE(c.VencimientoPago) = CURDATE()
    ORDER BY c.VencimientoPago ASC;
";

            MySqlConnection conn = Conexion.GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvVencimientos.DataSource = table;

                if (dgvVencimientos.Columns["VencimientoPago"] != null)
                {
                    dgvVencimientos.Columns["VencimientoPago"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvVencimientos.Columns["VencimientoPago"].HeaderText = "Vto. Cuota";
                }

                MessageBox.Show($"Se encontraron {table.Rows.Count} registros.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar vencimientos: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void agregarUnNuevoSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarSocio form = new FrmAgregarSocio();
            form.ShowDialog();
        }

        private void agregarNoSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarNoSocio form = new FrmAgregarNoSocio();
            form.ShowDialog();
        }

        private void informacionDeSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaPersona form = new FrmConsultaPersona();
            form.ShowDialog();
        }

        private void informacionNoSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaPersona form = new FrmConsultaPersona();
            form.ShowDialog();
        }

        private void pagoDeCuotaSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPagos form = new FrmPagos();
            form.ShowDialog();
        }

        private void dgvVencimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAcercaDe form = new FrmAcercaDe();
            form.ShowDialog();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarNoSocio form = new FrmAgregarNoSocio();
            form.ShowDialog();
        }

   
        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Application.StartupPath + @"\Recursos\manual_usuario.pdf";
                Process.Start(new ProcessStartInfo()
                {
                    FileName = ruta,
                    UseShellExecute = true 
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el manual de usuario.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
