using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    public partial class FrmPagos : Form
    {
        MySqlConnection conexion = DB.GetConnection();

        public FrmPagos()
        {
            InitializeComponent();
            grpSocio.Visible = false;
            grpNoSocio.Visible = false;
            cboFormaPago.SelectedIndexChanged += cboFormaPago_SelectedIndexChanged;
            txtValorBase.TextChanged += txtValorBase_TextChanged;
            cboActividad.SelectedIndexChanged += cboActividad_SelectedIndexChanged;
        }

        private void FrmPagos_Load(object sender, EventArgs e)
        {
            cboFormaPago.Items.Add("Efectivo");
            cboFormaPago.Items.Add("3 cuotas sin interés");
            cboFormaPago.Items.Add("6 cuotas sin interés");
            cboFormaPago.Items.Add("12 cuotas con 25% interés");

            CargarActividades();
        }

        private void CargarActividades()
        {
            string query = "SELECT idActividad, nombreActividad FROM actividad";
            MySqlCommand cmd = new MySqlCommand(query, conexion);

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();

            cboActividad.DataSource = dt;
            cboActividad.DisplayMember = "nombreActividad";
            cboActividad.ValueMember = "idActividad";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Ingrese un DNI");
                return;
            }

            string querySocio = "SELECT idSocio FROM socio WHERE dni = @dni";
            MySqlCommand cmd = new MySqlCommand(querySocio, conexion);
            cmd.Parameters.AddWithValue("@dni", dni);

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            var resultado = cmd.ExecuteScalar();

            if (resultado != null)
            {
                lblResultado.Text = "Es Socio";
                lblResultado.ForeColor = Color.Green;
                grpSocio.Visible = true;
                grpNoSocio.Visible = false;
                grpSocio.Tag = resultado.ToString();
            }
            else
            {
                string queryNoSocio = "SELECT idNoSocio FROM nosocio WHERE dni = @dni";
                cmd = new MySqlCommand(queryNoSocio, conexion);
                cmd.Parameters.AddWithValue("@dni", dni);

                resultado = cmd.ExecuteScalar();

                if (resultado != null)
                {
                    lblResultado.Text = "Es No Socio";
                    lblResultado.ForeColor = Color.Blue;
                    grpNoSocio.Visible = true;
                    grpSocio.Visible = false;
                    grpNoSocio.Tag = resultado.ToString();
                }
                else
                {
                    MessageBox.Show("DNI no encontrado en las tablas de socios ni no socios.");
                }

            }
            }

        private void CalcularMontoSocio()
        {
            if (decimal.TryParse(txtValorBase.Text, out decimal baseValor))
            {
                string formaPago = cboFormaPago.SelectedItem?.ToString();
                decimal final = baseValor;

                if (formaPago == "Efectivo")
                    final *= 0.90m;
                else if (formaPago == "6 cuotas sin interés")
                    final *= 1.10m;

                lblMontoFinalSocio.Text = $"Total a pagar: ${final:F2}";
            }
            else
            {
                lblMontoFinalSocio.Text = "Total a pagar: $0.00";
            }
        }

        private void cboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularMontoSocio();
        }

        private void txtValorBase_TextChanged(object sender, EventArgs e)
        {
            CalcularMontoSocio();
        }

        private void btnPagarSocio_Click(object sender, EventArgs e)
        {
            int idSocio = int.Parse(grpSocio.Tag.ToString());
            string formaPago = cboFormaPago.SelectedItem?.ToString();
            DateTime hoy = DateTime.Today;
            decimal monto = decimal.Parse(lblMontoFinalSocio.Text.Replace("Total a pagar: $", "").Trim());
            int numeroCuota = 1;

            string insert = "INSERT INTO cuotasocio (idSocio, fechaPagoSocio, vencimientoPago, formaPago, numeroCuota, monto) " +
                            "VALUES (@id, @pago, @vto, @forma, @nro, @monto)";
            MySqlCommand cmd = new MySqlCommand(insert, conexion);
            cmd.Parameters.AddWithValue("@id", idSocio);
            cmd.Parameters.AddWithValue("@pago", hoy);
            cmd.Parameters.AddWithValue("@vto", hoy.AddMonths(1));
            cmd.Parameters.AddWithValue("@forma", formaPago);
            cmd.Parameters.AddWithValue("@nro", numeroCuota);
            cmd.Parameters.AddWithValue("@valorActividad", monto);

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            cmd.ExecuteNonQuery();
            MessageBox.Show("Pago registrado para el socio.");
        }

        private void cboActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActividad.SelectedItem is DataRowView row)
            {
                int idActividad = Convert.ToInt32(row["idActividad"]);
                string query = "SELECT valorActividad FROM actividad WHERE idActividad = @id";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", idActividad);

                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    decimal valor = Convert.ToDecimal(resultado);
                    lblValorActividad.Text = $"Valor actividad: ${valor:F2}";
                }
            }
        }

        private void btnPagarNoSocio_Click(object sender, EventArgs e)
        {
            int idNoSocio = int.Parse(grpNoSocio.Tag.ToString());
            DateTime hoy = DateTime.Today;
            decimal monto = Convert.ToDecimal(lblValorActividad.Text.Replace("Valor actividad: $", "").Trim());
            int idActividad = Convert.ToInt32(cboActividad.SelectedValue);
            int numeroPago = 1;

            string insert = "INSERT INTO pagodiario (idNoSocio, fechaPagoDiario, formaPago, idActividad, numeroPagoD) " +
                "VALUES (@id, @fecha, @forma, @actividad, @nroPago)";

            MySqlCommand cmd = new MySqlCommand(insert, conexion);
            cmd.Parameters.AddWithValue("@id", idNoSocio);
            cmd.Parameters.AddWithValue("@fecha", hoy);
            cmd.Parameters.AddWithValue("@forma", "Efectivo"); // o recuperar de otro combo si se requiere
            cmd.Parameters.AddWithValue("@actividad", idActividad);
            cmd.Parameters.AddWithValue("@nroPago", numeroPago);


            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            cmd.ExecuteNonQuery();
            MessageBox.Show("Entrada registrada para el no socio.");
        }
    }
}
