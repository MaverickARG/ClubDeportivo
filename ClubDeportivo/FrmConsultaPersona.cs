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

            using (MySqlConnection conn = Conexion.GetConnection())
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
                    ns.idNoSocio,
                    ns.noSocioActivo
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

                            lblCarnetActivo.Text = Convert.ToBoolean(reader["noSocioActivo"]) ? "Sí" : "No";

                            lblFechaAlta.Text = "-";
                            lblValorCuota.Text = "-";

                            lblFechaAlta.Visible = true;
                            lblValorCuota.Visible = true;
                            lblCarnetActivo.Visible = true;
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

            string dni = lblDni.Text;
            string nombre = lblNombre.Text;
            string apellido = lblApellido.Text;
            string estado = lblEstado.Text;
            string vencimiento = lblFechaAlta.Text == "-" ? null : lblFechaAlta.Text;

            Bitmap plantilla;
            string titulo;
            List<string>? actividades = null;

            if (estado == "Socio")
            {
                plantilla = new Bitmap(Properties.Resources.plantilla_socio);
                titulo = "CARNET";
            }
            else if (estado == "No Socio")
            {
                plantilla = new Bitmap(Properties.Resources.plantilla_nosocio);
                titulo = "PAGO DIARIO";

                actividades = new List<string> { "Actividad 1", "Actividad 2" }; 
            }
            else
            {
                MessageBox.Show("No se puede imprimir. Estado no válido.");
                return;
            }

            string outputPath = Path.Combine(Path.GetTempPath(), $"Carnet_{dni}_{DateTime.Now.Ticks}.png");

            FrmPagos.GenerarCarnetDesdeBitmap(plantilla, titulo, dni, nombre, apellido, vencimiento, actividades, outputPath);
            FrmPagos.GuardarComoPdf(outputPath, "Carnet");
        }


        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(carnetImagen, 50, 50);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Console.WriteLine(">>> Se llamó a btnModificar_Click");

            if (string.IsNullOrWhiteSpace(lblDni.Text))
            {
                MessageBox.Show("Debe buscar una persona antes de modificar.");
                return;
            }

            if (!int.TryParse(lblDni.Text, out int dniActual))
            {
                MessageBox.Show("DNI inválido.");
                return;
            }

            using (FrmModificarPersona frm = new FrmModificarPersona(dniActual))
            {
                var result = frm.ShowDialog();

                Console.WriteLine(">>> DialogResult: " + result);

                if (result == DialogResult.OK)
                {
                    txtDni.Text = frm.NuevoDni.ToString();
                    btnBuscar.PerformClick(); // Esto solo se ejecuta 1 vez si hubo guardado
                }
            }
        }


    }
}
