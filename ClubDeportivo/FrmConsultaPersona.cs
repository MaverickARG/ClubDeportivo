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


using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;


namespace ClubDeportivo
{
    public partial class FrmConsultaPersona : Form
    {

        private Bitmap carnetImagen;

        public FrmConsultaPersona()
        {
            InitializeComponent();
            btnModificar.Click += btnModificar_Click;
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
                conn.Open();

                string query = @"
            SELECT 
                p.nombre,
                p.apellido,
                p.dni,
                p.aptoFisico,
                s.fechaAltaSocio,
                s.carnetActivo,
                s.valorCuota,
                ns.idNoSocio
            FROM persona p
            LEFT JOIN socio s ON s.dni = p.dni
            LEFT JOIN nosocio ns ON ns.dni = p.dni
            WHERE p.dni = @dni";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblNombre.Text = reader["nombre"].ToString();
                        lblApellido.Text = reader["apellido"].ToString();
                        lblDni.Text = reader["dni"].ToString();
                        lblAptoFisico.Text = Convert.ToBoolean(reader["aptoFisico"]) ? "Sí" : "No";

                        bool esSocio = reader["fechaAltaSocio"] != DBNull.Value;
                        bool esNoSocio = reader["idNoSocio"] != DBNull.Value;

                        if (esSocio)
                        {
                            lblEstado.Text = "Socio";
                            lblEstado.ForeColor = Color.Green;

                            lblFechaAlta.Text = Convert.ToDateTime(reader["fechaAltaSocio"]).ToShortDateString();
                            lblCarnetActivo.Text = Convert.ToBoolean(reader["carnetActivo"]) ? "Sí" : "No";
                            lblValorCuota.Text = reader["valorCuota"] != DBNull.Value
                            ? "$" + Convert.ToDouble(reader["valorCuota"]).ToString("0.00")
                            : "Falta gestionar pago en la pestaña 'Pagos'";



                            lblFechaAlta.Visible = true;
                            lblCarnetActivo.Visible = true;
                            lblValorCuota.Visible = true;
                        }
                        else if (esNoSocio)
                        {
                            lblEstado.Text = "No Socio";
                            lblEstado.ForeColor = Color.Blue;


                            // Ocultar datos de socio
                            lblFechaAlta.Text = "-";
                            lblCarnetActivo.Text = "-";
                            lblValorCuota.Text = "-";

                            lblFechaAlta.Visible = false;
                            lblCarnetActivo.Visible = false;
                            lblValorCuota.Visible = false;
                        }
                        else
                        {
                            lblEstado.Text = "Registrado sin actividad";
                            lblEstado.ForeColor = Color.Red;


                            lblFechaAlta.Text = "-";
                            lblCarnetActivo.Text = "-";
                            lblValorCuota.Text = "-";

                            lblFechaAlta.Visible = false;
                            lblCarnetActivo.Visible = false;
                            lblValorCuota.Visible = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("La persona no está registrada.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarLabels();
                    }
                }
                conn.Close();
            }
        }

        private void LimpiarLabels()
        {
            lblNombre.Text = "";
            lblApellido.Text = "";
            lblDni.Text = "";
            lblAptoFisico.Text = "";
            lblFechaAlta.Text = "";
            lblCarnetActivo.Text = "";
            lblValorCuota.Text = "";

            lblEstado.Text = "";
            lblFechaAlta.Visible = true;
            lblCarnetActivo.Visible = true;
            lblValorCuota.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimirCarnet_Click(object sender, EventArgs e)
        {
            if (lblCarnetActivo.Text != "Sí")
            {
                MessageBox.Show("No se puede imprimir el carnet porque no está activo.", "Carnet Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            carnetImagen = new Bitmap(400, 200);

            using (Graphics g = Graphics.FromImage(carnetImagen))
            {
                g.Clear(Color.White);
                g.FillRectangle(Brushes.DarkBlue, 0, 0, 400, 40);
                g.DrawString("CLUB DEPORTIVO", new Font("Arial", 16, FontStyle.Bold), Brushes.White, new PointF(10, 10));

                g.DrawString("Nombre: " + lblNombre.Text, new Font("Arial", 10), Brushes.Black, new PointF(20, 60));
                g.DrawString("Apellido: " + lblApellido.Text, new Font("Arial", 10), Brushes.Black, new PointF(20, 80));
                g.DrawString("DNI: " + lblDni.Text, new Font("Arial", 10), Brushes.Black, new PointF(20, 100));
                g.DrawString("Fecha Alta: " + lblFechaAlta.Text, new Font("Arial", 10), Brushes.Black, new PointF(20, 120));
                g.DrawString("Carnet Activo: " + lblCarnetActivo.Text, new Font("Arial", 10), Brushes.Black, new PointF(20, 140));
                g.DrawString("Valor Cuota: " + lblValorCuota.Text, new Font("Arial", 10), Brushes.Black, new PointF(20, 160));
            }

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintDialog dlg = new PrintDialog();
            dlg.Document = printDoc;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(carnetImagen, 50, 50);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblDni.Text))
            {
                MessageBox.Show("Debe buscar una persona antes de modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int dni = int.Parse(lblDni.Text);

            // Abrimos el formulario de modificación y le pasamos el DNI
            FrmModificarPersona frm = new FrmModificarPersona(dni);
            frm.ShowDialog();

            // Volvemos a consultar los datos actualizados
            btnBuscar.PerformClick();
        }


    }
}
