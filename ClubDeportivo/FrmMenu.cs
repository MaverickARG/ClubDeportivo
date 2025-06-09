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

            MySqlConnection conn = DB.GetConnection();
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
            form.ShowDialog(); // Modal
        }

        private void agregarNoSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarNoSocio form = new FrmAgregarNoSocio();
            form.ShowDialog(); // Modal
        }

        private void informacionDeSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaPersona form = new FrmConsultaPersona();
            form.ShowDialog(); // Modal
        }

        private void informacionNoSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaPersona form = new FrmConsultaPersona();
            form.ShowDialog(); // Modal
        }

        private void pagoDeCuotaSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPagosSocios form = new FrmPagosSocios();
            form.ShowDialog(); // Modal
        }

        private void dgvVencimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
