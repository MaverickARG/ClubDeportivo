using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    public partial class FrmPagosSocios : Form
    {
        private int socioId = -1;

        public FrmPagosSocios()
        {
            InitializeComponent();
        }

        private void FrmPagosSocios_Load(object sender, EventArgs e)
        {
            cmbFormaPago.Items.Add("Efectivo");
            cmbFormaPago.Items.Add("3 cuotas sin interés");
            cmbFormaPago.Items.Add("6 cuotas sin interés");
            cmbFormaPago.Items.Add("12 cuotas con 25%");
            cmbFormaPago.SelectedIndex = 0;

            DateTime hoy = DateTime.Now;
            lblFechaPago.Text = hoy.ToShortDateString();
            lblVencimiento.Text = hoy.AddDays(30).ToShortDateString();

            txtMontoFinal.ReadOnly = true;
            txtDetallePago.ReadOnly = true;
        }

        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMonto.Text, out decimal montoBase))
            {
                txtMontoFinal.Text = "0.00";
                txtDetallePago.Text = "";
                return;
            }

            decimal montoFinal = montoBase;
            int cuotas = 1;

            switch (cmbFormaPago.SelectedItem.ToString())
            {
                case "Efectivo":
                    cuotas = 1;
                    break;
                case "3 cuotas sin interés":
                    cuotas = 3;
                    break;
                case "6 cuotas sin interés":
                    cuotas = 6;
                    break;
                case "12 cuotas con 25%":
                    cuotas = 12;
                    montoFinal = montoBase + (montoBase * 0.25m);
                    break;
            }

            decimal montoCuota = montoFinal / cuotas;
            txtMontoFinal.Text = montoFinal.ToString("0.00");
            txtDetallePago.Text = $"{cuotas} cuota(s) de {montoCuota:C2}";
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {

            if (socioId == -1)
            {
                MessageBox.Show("Debe buscar un socio válido antes de registrar el pago.");
                return;
            }

            if (!decimal.TryParse(txtMonto.Text, out decimal montoBase))
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }

            DateTime fechaPago = DateTime.Now;
            DateTime vencimiento = fechaPago.AddDays(30);
            string formaPago = cmbFormaPago.SelectedItem.ToString();

            int cuotas = 1;
            decimal montoFinal = montoBase;

            switch (formaPago)
            {
                case "3 cuotas sin interés":
                    cuotas = 3;
                    break;
                case "6 cuotas sin interés":
                    cuotas = 6;
                    break;
                case "12 cuotas con 25%":
                    cuotas = 12;
                    montoFinal += montoBase * 0.25m;
                    break;
            }

            try
            {
                using (MySqlConnection con = Conexion.GetConnection())
                {
                    string query = "INSERT INTO CuotaSocio (fechaPagoSocio, vencimientoPago, formaPago, numeroCuota, idSocio) " +
                                   "VALUES (@fecha, @vto, @forma, @cuotas, @id)";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@fecha", fechaPago);
                    cmd.Parameters.AddWithValue("@vto", vencimiento);
                    cmd.Parameters.AddWithValue("@forma", formaPago);
                    cmd.Parameters.AddWithValue("@cuotas", cuotas);
                    cmd.Parameters.AddWithValue("@id", socioId);

                    con.Open();
                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        MessageBox.Show("✅ Pago registrado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("❌ Error: No se registró el pago.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pago: " + ex.Message);
            }

            // Limpiar
            txtDni.Clear();
            txtMonto.Clear();
            txtMontoFinal.Clear();
            txtDetallePago.Clear();
            lblNombre.Text = "Nombre:";
            lblApellido.Text = "Apellido:";
            socioId = -1;
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            if (dni.Length < 7 || dni.Length > 8 || !int.TryParse(dni, out _))
            {
                MessageBox.Show("Ingrese un DNI válido de 7 u 8 dígitos.");
                return;
            }

            using (MySqlConnection con = Conexion.GetConnection())
            {
                string query = "SELECT s.idSocio, p.nombre, p.apellido FROM Persona p " +
                               "INNER JOIN Socio s ON p.dni = s.dni WHERE p.dni = @dni";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@dni", dni);

                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    socioId = Convert.ToInt32(dr["idSocio"]);
                    lblNombre.Text = "Nombre: " + dr["nombre"].ToString();
                    lblApellido.Text = "Apellido: " + dr["apellido"].ToString();
                }
                else
                {
                    MessageBox.Show("Socio no encontrado.");
                    socioId = -1;
                    lblNombre.Text = "Nombre:";
                    lblApellido.Text = "Apellido:";
                }

                dr.Close();
            }
        }
    }
}
