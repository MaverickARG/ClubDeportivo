using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using QRCoder;

namespace ClubDeportivo
{
    public partial class FrmPagos : Form
    {
        MySqlConnection conexion = Conexion.GetConnection();


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

            dgvDetalle.DataSource = null;

            // 🔽 CONSULTA A SOCIO ACTIVO
            string querySocio = "SELECT idSocio FROM socio WHERE dni = @dni AND activo = 1";
            MySqlCommand cmdSocio = new MySqlCommand(querySocio, conexion);
            cmdSocio.Parameters.AddWithValue("@dni", dni);
            var resultadoSocio = cmdSocio.ExecuteScalar();

            if (resultadoSocio != null)
            {
                lblResultado.Text = "SOCIO";
                lblResultado.ForeColor = Color.Green;
                grpSocio.Visible = true;
                grpNoSocio.Visible = false;
                grpSocio.Tag = resultadoSocio.ToString();
                btnImprimirCarnet.Visible = true;

                string queryVencimiento = "SELECT vencimientoPago AS 'Vencimiento' " +
                                          "FROM cuotasocio WHERE idSocio = @id ORDER BY fechaPagoSocio DESC LIMIT 1";
                MySqlCommand cmdVto = new MySqlCommand(queryVencimiento, conexion);
                cmdVto.Parameters.AddWithValue("@id", Convert.ToInt32(grpSocio.Tag));

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmdVto);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvDetalle.DataSource = dt;

                return;
            }

            // 🔽 CONSULTA A NO SOCIO ACTIVO
            string queryNoSocio = "SELECT idNoSocio FROM nosocio WHERE dni = @dni AND activo = 1";
            MySqlCommand cmdNoSocio = new MySqlCommand(queryNoSocio, conexion);
            cmdNoSocio.Parameters.AddWithValue("@dni", dni);
            var resultadoNoSocio = cmdNoSocio.ExecuteScalar();

            if (resultadoNoSocio != null)
            {
                lblResultado.Text = "NO SOCIO";
                lblResultado.ForeColor = Color.Blue;
                grpNoSocio.Visible = true;
                grpSocio.Visible = false;
                grpNoSocio.Tag = resultadoNoSocio.ToString();
                btnImprimirCarnet.Visible = true;

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

                return;
            }

            // Si no está en ninguna
            MessageBox.Show("DNI no encontrado en las tablas de socios activos ni no socios activos.");
        }



        private void ActualizarDetalle()
        {
            dgvDetalle.DataSource = null;

            if (lblResultado.Text == "SOCIO")
            {
                string query = "SELECT vencimientoPago AS 'Vencimiento' " +
                               "FROM cuotasocio WHERE idSocio = @id ORDER BY fechaPagoSocio DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(grpSocio.Tag));

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvDetalle.DataSource = dt;
            }
            else if (lblResultado.Text == "NO SOCIO")
            {
                string query = "SELECT a.nombreActividad AS 'Actividad' " +
                               "FROM pagodiario pd " +
                               "JOIN actividad a ON pd.idActividad = a.idActividad " +
                               "WHERE pd.idNoSocio = @id AND pd.fechaPagoDiario = CURDATE()";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(grpNoSocio.Tag));

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvDetalle.DataSource = dt;
            }

            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

            if (!decimal.TryParse(txtValorBase.Text, out decimal valor) || valor <= 0)
            {
                lblMontoFinalSocio.Text = "Valor inválido";
                return;
            }

            CalcularMontoSocio(); // si está todo bien
        }

        private void btnPagarSocio_Click(object sender, EventArgs e)
        {
            int idSocio = int.Parse(grpSocio.Tag.ToString());
            string formaPago = cboFormaPago.SelectedItem?.ToString();
            DateTime hoy = DateTime.Today;

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

            // Obtener valor actual de cuota desde la tabla socio
            decimal baseValor = 0;
            string getValor = "SELECT valorCuota FROM socio WHERE idSocio = @id";
            MySqlCommand getCmd = new MySqlCommand(getValor, conexion);
            getCmd.Parameters.AddWithValue("@id", idSocio);
            object result = getCmd.ExecuteScalar();

            if (result == DBNull.Value || result == null)
            {
                if (!decimal.TryParse(txtValorBase.Text.Trim(), out baseValor) || baseValor <= 0)
                {
                    MessageBox.Show("Ingrese un valor de cuota válido (mayor a 0).", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insertar nuevo valor
                string updateValor = "UPDATE socio SET valorCuota = @valor WHERE idSocio = @id";
                MySqlCommand updateValorCmd = new MySqlCommand(updateValor, conexion);
                updateValorCmd.Parameters.AddWithValue("@valor", baseValor);
                updateValorCmd.Parameters.AddWithValue("@id", idSocio);
                updateValorCmd.ExecuteNonQuery();
            }
            else
            {
                baseValor = Convert.ToDecimal(result);

                if (decimal.TryParse(txtValorBase.Text.Trim(), out decimal nuevoValor) && nuevoValor > 0 && nuevoValor != baseValor)
                {
                    baseValor = nuevoValor;
                    string updateValor = "UPDATE socio SET valorCuota = @valor WHERE idSocio = @id";
                    MySqlCommand updateValorCmd = new MySqlCommand(updateValor, conexion);
                    updateValorCmd.Parameters.AddWithValue("@valor", baseValor);
                    updateValorCmd.Parameters.AddWithValue("@id", idSocio);
                    updateValorCmd.ExecuteNonQuery();
                }
            }

            // Calcular monto final con forma de pago
            decimal montoFinal = baseValor;
            if (formaPago == "Efectivo")
                montoFinal *= 0.90m;
            else if (formaPago == "6 cuotas con interés")
                montoFinal *= 1.10m;

            // Obtener número de cuota nuevo
            string countQuery = "SELECT COUNT(*) FROM cuotasocio WHERE idSocio = @id";
            MySqlCommand countCmd = new MySqlCommand(countQuery, conexion);
            countCmd.Parameters.AddWithValue("@id", idSocio);
            int numeroCuota = Convert.ToInt32(countCmd.ExecuteScalar()) + 1;

            // Insertar nueva cuota
            string insert = "INSERT INTO cuotasocio (idSocio, fechaPagoSocio, vencimientoPago, formaPago, numeroCuota, montoCuota, montoFinal) " +
                            "VALUES (@id, @pago, @vto, @forma, @nro, @montoBase, @montoFinal)";
            MySqlCommand cmd = new MySqlCommand(insert, conexion);
            cmd.Parameters.AddWithValue("@id", idSocio);
            cmd.Parameters.AddWithValue("@pago", hoy);
            cmd.Parameters.AddWithValue("@vto", hoy.AddMonths(1));
            cmd.Parameters.AddWithValue("@forma", formaPago);
            cmd.Parameters.AddWithValue("@nro", numeroCuota);
            cmd.Parameters.AddWithValue("@montoBase", baseValor);
            cmd.Parameters.AddWithValue("@montoFinal", montoFinal);
            cmd.ExecuteNonQuery();

            // Activar carnet
            string update = "UPDATE socio SET carnetActivo = 1 WHERE idSocio = @id";
            MySqlCommand updateCmd = new MySqlCommand(update, conexion);
            updateCmd.Parameters.AddWithValue("@id", idSocio);
            updateCmd.ExecuteNonQuery();

            btnImprimirRecibo.Visible = true;

            MessageBox.Show($"Pago registrado para el socio.\nMonto base: ${baseValor:F2}\nMonto final: ${montoFinal:F2}");
            ActualizarDetalle();
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
            string actividadNombre = cboActividad.Text;

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
            cmd.Parameters.AddWithValue("@forma", "Efectivo");
            cmd.Parameters.AddWithValue("@actividad", idActividad);
            cmd.Parameters.AddWithValue("@nroPago", cantidadPagos + 1);

            cmd.ExecuteNonQuery();

            // Activar noSocioActivo = 1 por el día
            string update = "UPDATE nosocio SET noSocioActivo = 1 WHERE idNoSocio = @id";
            MySqlCommand updateCmd = new MySqlCommand(update, conexion);
            updateCmd.Parameters.AddWithValue("@id", idNoSocio);
            updateCmd.ExecuteNonQuery();

            // Obtener valor de la actividad
            string valorQuery = "SELECT valorActividad FROM actividad WHERE idActividad = @id";
            MySqlCommand valorCmd = new MySqlCommand(valorQuery, conexion);
            valorCmd.Parameters.AddWithValue("@id", idActividad);
            object valorObj = valorCmd.ExecuteScalar();

            decimal valorActividad = valorObj != null ? Convert.ToDecimal(valorObj) : 0;

            btnImprimirRecibo.Visible = true;

            MessageBox.Show("Pago confirmado - No Socio habilitado");
            ActualizarDetalle();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImprimirCarnet_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            string nombre = lblNombre.Text;
            string apellido = lblApellido.Text;
            string tipoPersona = lblResultado.Text;

            if (tipoPersona == "SOCIO")
            {
                // Cambiamos: buscamos la fecha de la PRIMERA cuota pagada (fecha de alta)
                string query = "SELECT MIN(fechaPagoSocio) FROM cuotasocio WHERE idSocio = @id";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(grpSocio.Tag));

                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                object resultado = cmd.ExecuteScalar();

                if (resultado == DBNull.Value)
                {
                    MessageBox.Show("No se encontró una cuota registrada para este socio. No se puede generar el carnet.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string fechaAlta = Convert.ToDateTime(resultado).ToShortDateString();

                Bitmap plantilla = new Bitmap(Properties.Resources.plantilla_socio);
                string outputPath = Path.Combine(Path.GetTempPath(), $"Carnet_{dni}_{DateTime.Now.Ticks}.png");

                // Se pasa la "fecha de alta" como parámetro en lugar de "vencimiento"
                GenerarCarnetDesdeBitmap(plantilla, "CARNET", dni, nombre, apellido, fechaAlta, null, outputPath);
                GuardarComoPdf(outputPath, "Carnet");
            }
            else if (tipoPersona == "NO SOCIO")
            {
                int idNoSocio = Convert.ToInt32(grpNoSocio.Tag);
                string query = @"SELECT a.nombreActividad 
                         FROM pagodiario pd 
                         JOIN actividad a ON pd.idActividad = a.idActividad 
                         WHERE pd.idNoSocio = @id AND pd.fechaPagoDiario = CURDATE()";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", idNoSocio);

                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                List<string> actividades = new List<string>();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        actividades.Add(reader["nombreActividad"].ToString());
                    }
                }

                if (actividades.Count == 0)
                {
                    MessageBox.Show("No hay actividades registradas hoy para este no socio.");
                    return;
                }

                Bitmap plantilla = new Bitmap(Properties.Resources.plantilla_nosocio);
                string outputPath = Path.Combine(Path.GetTempPath(), $"PagoDiario_{dni}_{DateTime.Now.Ticks}.png");

                GenerarCarnetDesdeBitmap(plantilla, "PAGO DIARIO", dni, nombre, apellido, null, actividades, outputPath);
                GuardarComoPdf(outputPath, "PagoDiario");
            }
        }




        private void btnImprimirPago_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            string nombre = lblNombre.Text;
            string apellido = lblApellido.Text;

            // Obtener actividades desde el DataGridView
            List<string> actividades = new List<string>();
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells["Actividad"].Value != null)
                    actividades.Add(row.Cells["Actividad"].Value.ToString());
            }

            // Cargar plantilla desde recursos
            Bitmap plantilla = new Bitmap(Properties.Resources.plantilla_nosocio);
            string outputPath = Path.Combine(Path.GetTempPath(), $"PagoDiario_{dni}_{DateTime.Now.Ticks}.png");

            // Generar la imagen personalizada
            GenerarCarnetDesdeBitmap(plantilla, "PAGO DIARIO", dni, nombre, apellido, null, actividades, outputPath);

            // Convertir a PDF
            GuardarComoPdf(outputPath, "PagoDiario");
        }



        public static void GenerarCarnetDesdeBitmap(Bitmap plantilla, string titulo, string dni, string nombre, string apellido, string? fechaAlta, List<string>? actividades, string outputPath)
        {
            Bitmap bmp = new Bitmap(plantilla);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            System.Drawing.Font fontTitulo = new System.Drawing.Font("Segoe UI", 26, FontStyle.Bold);
            System.Drawing.Font fontCampo = new System.Drawing.Font("Segoe UI", 20, FontStyle.Bold);
            System.Drawing.Font fontValor = new System.Drawing.Font("Segoe UI", 20, FontStyle.Regular);

            Brush brushTitulo = Brushes.DarkBlue;
            Brush brushTexto = Brushes.Black;

            float inicioX = 440;
            float inicioY = 260;
            float espacio = 50;

            g.DrawString(titulo, fontTitulo, brushTitulo, new PointF(inicioX, inicioY));
            inicioY += espacio + 10;

            g.DrawString("DNI:", fontCampo, brushTexto, new PointF(inicioX, inicioY));
            g.DrawString(dni, fontValor, brushTexto, new PointF(inicioX + 180, inicioY));
            inicioY += espacio;

            g.DrawString("Nombre:", fontCampo, brushTexto, new PointF(inicioX, inicioY));
            g.DrawString(nombre, fontValor, brushTexto, new PointF(inicioX + 180, inicioY));
            inicioY += espacio;

            g.DrawString("Apellido:", fontCampo, brushTexto, new PointF(inicioX, inicioY));
            g.DrawString(apellido, fontValor, brushTexto, new PointF(inicioX + 180, inicioY));
            inicioY += espacio;

            if (fechaAlta != null)
            {
                g.DrawString("Fecha de alta:", fontCampo, brushTexto, new PointF(inicioX, inicioY));
                g.DrawString(fechaAlta, fontValor, brushTexto, new PointF(inicioX + 250, inicioY));
                inicioY += espacio;
            }

            if (actividades != null && actividades.Count > 0)
            {
                SizeF sizeActividades = g.MeasureString("Actividades:", fontCampo);

                g.DrawString("Actividades:", fontCampo, brushTexto, new PointF(inicioX, inicioY));

                g.DrawString("• " + actividades[0], fontValor, brushTexto, new PointF(inicioX + sizeActividades.Width + 10, inicioY));
                inicioY += espacio - 5;

                for (int i = 1; i < actividades.Count; i++)
                {
                    g.DrawString("• " + actividades[i], fontValor, brushTexto, new PointF(inicioX + 176, inicioY));
                    inicioY += espacio - 5;
                }
            }

            bmp.Save(outputPath, ImageFormat.Png);
            g.Dispose();
            bmp.Dispose();
        }




        public static void GuardarComoPdf(string imagenPath, string titulo)
        {
            string pdfPath = Path.Combine(Path.GetTempPath(), $"{titulo}_{DateTime.Now.Ticks}.pdf");

            using (var doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A6))
            {
                using (var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create)))
                {
                    doc.Open();
                    iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(imagenPath);
                    imagen.ScaleToFit(doc.PageSize.Width - 20, doc.PageSize.Height - 20);
                    imagen.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    doc.Add(imagen);
                    doc.Close();
                }


            }

            System.Diagnostics.Process.Start("explorer", pdfPath);
        }

        private void GenerarReciboComoImagen(string outputPath, string contenido, string qrTexto)
        {
            int ancho = 919;
            int alto = 564;
            Bitmap bmp = new Bitmap(ancho, alto);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            // Borde negro
            Pen borde = new Pen(Color.Black, 4);
            g.DrawRectangle(borde, 0, 0, ancho - 1, alto - 1);

            // Título
            System.Drawing.Font fontTitulo = new System.Drawing.Font("Segoe UI", 26, FontStyle.Bold);
            Brush brushTitulo = Brushes.DarkBlue;
            string titulo = "RECIBO DE PAGO";
            SizeF sizeTitulo = g.MeasureString(titulo, fontTitulo);
            g.DrawString(titulo, fontTitulo, brushTitulo, (ancho - sizeTitulo.Width) / 2, 40);

            // Contenido (en bloque)
            System.Drawing.Font fontTexto = new System.Drawing.Font("Segoe UI", 16, FontStyle.Regular);
            Brush brushTexto = Brushes.Black;
            float x = 80;
            float y = 120;

            string[] lineas = contenido.Split('\n');
            foreach (string linea in lineas)
            {
                g.DrawString(linea, fontTexto, brushTexto, x, y);
                y += 36;
            }

            // Código QR
            QRCodeGenerator qrGen = new QRCodeGenerator();
            QRCodeData qrData = qrGen.CreateQrCode(qrTexto, QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qr = new QRCoder.QRCode(qrData);
            Bitmap qrImage = qr.GetGraphic(5);
            g.DrawImage(qrImage, ancho - 200, 120, 120, 120);


            g.Dispose();
            bmp.Save(outputPath, ImageFormat.Png);
            bmp.Dispose();

            //System.Diagnostics.Process.Start("explorer", outputPath);
        }

        private void btnImprimirRecibo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDni.Text))
            {
                MessageBox.Show("Debe buscar un DNI antes de imprimir el recibo.");
                return;
            }

            string dni = txtDni.Text.Trim();
            string nombre = lblNombre.Text;
            string apellido = lblApellido.Text;
            string tipoPersona = lblResultado.Text;
            DateTime hoy = DateTime.Today;
            string contenido = "";

            if (tipoPersona == "SOCIO")
            {
                int idSocio = Convert.ToInt32(grpSocio.Tag);
                string query = @"SELECT fechaPagoSocio, formaPago, 
                                (SELECT valorCuota FROM socio WHERE idSocio = @id) AS monto
                         FROM cuotasocio 
                         WHERE idSocio = @id AND fechaPagoSocio = CURDATE()
                         ORDER BY fechaPagoSocio DESC LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", idSocio);

                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DateTime fechaPago = Convert.ToDateTime(reader["fechaPagoSocio"]);
                        string formaPago = reader["formaPago"].ToString();
                        decimal monto = Convert.ToDecimal(reader["monto"]);

                        // aplicar descuentos/recargos
                        if (formaPago == "Efectivo")
                            monto *= 0.90m;
                        else if (formaPago == "6 cuotas sin interés")
                            monto *= 1.10m;

                        contenido = $"\n\n" +
                                    $"Fecha: {fechaPago:dd/MM/yyyy}\n" +
                                    $"DNI: {dni}\n" +
                                    $"Nombre: {nombre} {apellido}\n" +
                                    $"Tipo: SOCIO\n" +
                                    $"Detalle: Cuota mensual\n" +
                                    $"Forma de pago: {formaPago}\n" +
                                    $"Monto abonado: ${monto:F2}";
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un pago de hoy para este socio.");
                        return;
                    }
                }
            }
            else if (tipoPersona == "NO SOCIO")
            {
                int idNoSocio = Convert.ToInt32(grpNoSocio.Tag);
                string query = @"SELECT a.nombreActividad, a.valorActividad
                         FROM pagodiario pd
                         JOIN actividad a ON pd.idActividad = a.idActividad
                         WHERE pd.idNoSocio = @id AND pd.fechaPagoDiario = CURDATE()";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", idNoSocio);

                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                List<string> actividades = new List<string>();
                decimal total = 0;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string act = reader["nombreActividad"].ToString();
                        decimal valor = Convert.ToDecimal(reader["valorActividad"]);
                        actividades.Add($"{act} - ${valor:F2}");
                        total += valor;
                    }
                }

                if (actividades.Count == 0)
                {
                    MessageBox.Show("No se encontraron pagos registrados hoy para este no socio.");
                    return;
                }

                string listaActividades = string.Join("\n", actividades);

                contenido = $"Datos del CLiente\n\n" +
                            $"Fecha: {hoy:dd/MM/yyyy}\n" +
                            $"DNI: {dni}\n" +
                            $"Nombre: {nombre} {apellido}\n" +
                            $"Tipo: NO SOCIO\n" +
                            $"Detalle:\n{listaActividades}\n\n" +
                            $"Total abonado: ${total:F2}";
            }
            else
            {
                MessageBox.Show("Debe identificar primero si la persona es socio o no socio.");
                return;
            }

            string outputPath = Path.Combine(Path.GetTempPath(), $"Recibo_{dni}_{DateTime.Now.Ticks}.png");
            string qrTexto = $"DNI: {dni} - Fecha: {hoy:dd/MM/yyyy}";
            GenerarReciboComoImagen(outputPath, contenido, qrTexto);
            GuardarComoPdf(outputPath, "Recibo");

        }

    }

}
