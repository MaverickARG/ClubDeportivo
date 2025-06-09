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

        private void DesactivarNoSociosInactivos()
        {
            DateTime hoy = DateTime.Today;

            string update = @"
        UPDATE nosocio 
        SET noSocioActivo = 0 
        WHERE idNoSocio NOT IN (
            SELECT idNoSocio 
            FROM pagodiario 
            WHERE fechaPagoDiario = @hoy
        );";

            MySqlCommand cmd = new MySqlCommand(update, conexion);
            cmd.Parameters.AddWithValue("@hoy", hoy);

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            cmd.ExecuteNonQuery();
        }

        private void FrmPagos_Load(object sender, EventArgs e)
        {
            cboFormaPago.Items.Add("Efectivo");
            cboFormaPago.Items.Add("3 cuotas sin interés");
            cboFormaPago.Items.Add("6 cuotas con interés");

            CargarActividades();
            DesactivarNoSociosInactivos();
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

            // 🔽 CONSULTA A TABLA PERSONA PARA OBTENER NOMBRE Y APELLIDO
            string queryPersona = "SELECT nombre, apellido FROM persona WHERE dni = @dni";
            MySqlCommand cmdPersona = new MySqlCommand(queryPersona, conexion);
            cmdPersona.Parameters.AddWithValue("@dni", dni);

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            using (MySqlDataReader reader = cmdPersona.ExecuteReader())
            {
                if (reader.Read())
                {
                    lblNombre.Text = reader["nombre"].ToString();
                    lblApellido.Text = reader["apellido"].ToString();
                }
                else
                {
                    MessageBox.Show("DNI no encontrado en la tabla persona.");
                    return;
                }
            }

            // 🔽 CONSULTA A TABLA SOCIO
            string querySocio = "SELECT idSocio FROM socio WHERE dni = @dni";
            MySqlCommand cmd = new MySqlCommand(querySocio, conexion);
            cmd.Parameters.AddWithValue("@dni", dni);

            var resultado = cmd.ExecuteScalar();

            dgvDetalle.DataSource = null; // limpia el grid

            if (resultado != null)
            {
                lblResultado.Text = "SOCIO";
                lblResultado.ForeColor = Color.Green;
                grpSocio.Visible = true;
                grpNoSocio.Visible = false;
                grpSocio.Tag = resultado.ToString();

                // 🔽 MOSTRAR FECHA DE VENCIMIENTO EN EL DATAGRID
                string queryVencimiento = "SELECT vencimientoPago AS 'Vencimiento' " +
                                          "FROM cuotasocio WHERE idSocio = @id ORDER BY fechaPagoSocio DESC LIMIT 1";
                MySqlCommand cmdVto = new MySqlCommand(queryVencimiento, conexion);
                cmdVto.Parameters.AddWithValue("@id", Convert.ToInt32(grpSocio.Tag));

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmdVto);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvDetalle.DataSource = dt;
            }
            else
            {
                // 🔽 CONSULTA A TABLA NOSOCIO
                string queryNoSocio = "SELECT idNoSocio FROM nosocio WHERE dni = @dni";
                cmd = new MySqlCommand(queryNoSocio, conexion);
                cmd.Parameters.AddWithValue("@dni", dni);

                resultado = cmd.ExecuteScalar();

                if (resultado != null)
                {
                    lblResultado.Text = "NO SOCIO";
                    lblResultado.ForeColor = Color.Blue;
                    grpNoSocio.Visible = true;
                    grpSocio.Visible = false;
                    grpNoSocio.Tag = resultado.ToString();

                    // 🔽 MOSTRAR ACTIVIDADES PAGADAS HOY EN EL DATAGRID
                    string queryActividades = "SELECT a.nombreActividad AS 'Actividad' " +
                                              "FROM pagodiario pd " +
                                              "JOIN actividad a ON pd.idActividad = a.idActividad " +
                                              "WHERE pd.idNoSocio = @id AND pd.fechaPagoDiario = CURDATE()";
                    MySqlCommand cmdAct = new MySqlCommand(queryActividades, conexion);
                    cmdAct.Parameters.AddWithValue("@id", Convert.ToInt32(grpNoSocio.Tag));

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmdAct);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvDetalle.DataSource = dt;
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
                else if (formaPago == "6 cuotas con interés")
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
            int numeroCuota = 1;

            // Verificar si ya tiene una cuota vigente
            string queryUltimoVencimiento = "SELECT MAX(vencimientoPago) FROM cuotasocio WHERE idSocio = @id";
            MySqlCommand cmdVto = new MySqlCommand(queryUltimoVencimiento, conexion);
            cmdVto.Parameters.AddWithValue("@id", idSocio);

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            object fechaVto = cmdVto.ExecuteScalar();
            if (fechaVto != DBNull.Value && Convert.ToDateTime(fechaVto) >= hoy)
            {
                MessageBox.Show("La cuota aún está vigente. No se puede registrar un nuevo pago.");
                return;
            }

            // Obtener valor de cuota desde la tabla socio
            decimal baseValor = 0;
            string getValor = "SELECT valorCuota FROM socio WHERE idSocio = @id";
            MySqlCommand getCmd = new MySqlCommand(getValor, conexion);
            getCmd.Parameters.AddWithValue("@id", idSocio);
            object result = getCmd.ExecuteScalar();
            if (result != null)
                baseValor = Convert.ToDecimal(result);

            // Calcular monto según forma de pago
            decimal montoFinal = baseValor;
            if (formaPago == "Efectivo")
                montoFinal *= 0.90m;
            else if (formaPago == "6 cuotas sin interés")
                montoFinal *= 1.10m;

            // Insertar cuota (sin guardar monto en la tabla)
            string insert = "INSERT INTO cuotasocio (idSocio, fechaPagoSocio, vencimientoPago, formaPago, numeroCuota) " +
                            "VALUES (@id, @pago, @vto, @forma, @nro)";
            MySqlCommand cmd = new MySqlCommand(insert, conexion);
            cmd.Parameters.AddWithValue("@id", idSocio);
            cmd.Parameters.AddWithValue("@pago", hoy);
            cmd.Parameters.AddWithValue("@vto", hoy.AddMonths(1));
            cmd.Parameters.AddWithValue("@forma", formaPago);
            cmd.Parameters.AddWithValue("@nro", numeroCuota);

            cmd.ExecuteNonQuery();

            // Activar carnet
            string update = "UPDATE socio SET carnetActivo = 1 WHERE idSocio = @id";
            MySqlCommand updateCmd = new MySqlCommand(update, conexion);
            updateCmd.Parameters.AddWithValue("@id", idSocio);
            updateCmd.ExecuteNonQuery();

            MessageBox.Show("Pago registrado para el socio. Monto calculado: $" + montoFinal.ToString("F2"));
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
            int idActividad = Convert.ToInt32(cboActividad.SelectedValue);

            // Validar cantidad de pagos del día
            string countQuery = "SELECT COUNT(*) FROM pagodiario WHERE idNoSocio = @id AND fechaPagoDiario = @fecha";
            MySqlCommand countCmd = new MySqlCommand(countQuery, conexion);
            countCmd.Parameters.AddWithValue("@id", idNoSocio);
            countCmd.Parameters.AddWithValue("@fecha", hoy);

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            int cantidadPagos = Convert.ToInt32(countCmd.ExecuteScalar());

            if (cantidadPagos >= 2)
            {
                MessageBox.Show("Limite de actividades diarias alcanzado (2)");
                return;
            }

            // Insertar nuevo pago
            string insert = "INSERT INTO pagodiario (idNoSocio, fechaPagoDiario, formaPago, idActividad, numeroPagoD) " +
                            "VALUES (@id, @fecha, @forma, @actividad, @nroPago)";

            MySqlCommand cmd = new MySqlCommand(insert, conexion);
            cmd.Parameters.AddWithValue("@id", idNoSocio);
            cmd.Parameters.AddWithValue("@fecha", hoy);
            cmd.Parameters.AddWithValue("@forma", "Efectivo"); // podés hacer combo después
            cmd.Parameters.AddWithValue("@actividad", idActividad);
            cmd.Parameters.AddWithValue("@nroPago", cantidadPagos + 1);

            cmd.ExecuteNonQuery();

            // Activar noSocioActivo = 1 por el día
            string update = "UPDATE nosocio SET noSocioActivo = 1 WHERE idNoSocio = @id";
            MySqlCommand updateCmd = new MySqlCommand(update, conexion);
            updateCmd.Parameters.AddWithValue("@id", idNoSocio);
            updateCmd.ExecuteNonQuery();

            MessageBox.Show("Pago confirmado - No Socio habilitado");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
