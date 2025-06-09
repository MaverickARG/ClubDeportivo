namespace ClubDeportivo
{
    partial class FrmPagosSocios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblNombre = new Label();
            lblApellido = new Label();
            txtDni = new TextBox();
            btnBuscar = new Button();
            lblDni = new Label();
            dtpFechaPago = new DateTimePicker();
            dtpVencimiento = new DateTimePicker();
            cmbFormaPago = new ComboBox();
            txtMonto = new TextBox();
            txtMontoFinal = new TextBox();
            btnRegistrarPago = new Button();
            lblFechaPago = new Label();
            lblVencimiento = new Label();
            txtDetallePago = new TextBox();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(83, 94);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(83, 122);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido:";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(178, 63);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(308, 66);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(83, 66);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(86, 15);
            lblDni.TabIndex = 4;
            lblDni.Text = "Ingrese un Dni:";
            // 
            // dtpFechaPago
            // 
            dtpFechaPago.Location = new Point(87, 171);
            dtpFechaPago.Name = "dtpFechaPago";
            dtpFechaPago.Size = new Size(200, 23);
            dtpFechaPago.TabIndex = 5;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Location = new Point(90, 224);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(200, 23);
            dtpVencimiento.TabIndex = 6;
            // 
            // cmbFormaPago
            // 
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Location = new Point(95, 268);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(121, 23);
            cmbFormaPago.TabIndex = 7;
            cmbFormaPago.SelectedIndexChanged += cmbFormaPago_SelectedIndexChanged;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(95, 352);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(100, 23);
            txtMonto.TabIndex = 9;
            // 
            // txtMontoFinal
            // 
            txtMontoFinal.Location = new Point(95, 381);
            txtMontoFinal.Name = "txtMontoFinal";
            txtMontoFinal.Size = new Size(100, 23);
            txtMontoFinal.TabIndex = 10;
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.Location = new Point(366, 381);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(108, 23);
            btnRegistrarPago.TabIndex = 11;
            btnRegistrarPago.Text = "Registrar Pago";
            btnRegistrarPago.UseVisualStyleBackColor = true;
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            // 
            // lblFechaPago
            // 
            lblFechaPago.AutoSize = true;
            lblFechaPago.Location = new Point(317, 176);
            lblFechaPago.Name = "lblFechaPago";
            lblFechaPago.Size = new Size(0, 15);
            lblFechaPago.TabIndex = 12;
            // 
            // lblVencimiento
            // 
            lblVencimiento.AutoSize = true;
            lblVencimiento.Location = new Point(317, 224);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(0, 15);
            lblVencimiento.TabIndex = 13;
            // 
            // txtDetallePago
            // 
            txtDetallePago.Location = new Point(96, 298);
            txtDetallePago.Name = "txtDetallePago";
            txtDetallePago.Size = new Size(100, 23);
            txtDetallePago.TabIndex = 14;
            // 
            // FrmPagosSocios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDetallePago);
            Controls.Add(lblVencimiento);
            Controls.Add(lblFechaPago);
            Controls.Add(btnRegistrarPago);
            Controls.Add(txtMontoFinal);
            Controls.Add(txtMonto);
            Controls.Add(cmbFormaPago);
            Controls.Add(dtpVencimiento);
            Controls.Add(dtpFechaPago);
            Controls.Add(lblDni);
            Controls.Add(btnBuscar);
            Controls.Add(txtDni);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Name = "FrmPagosSocios";
            Text = "Registro de Pagos de Socios";
            Load += FrmPagosSocios_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtMontoFinal;
        private System.Windows.Forms.Button btnRegistrarPago;
        private Label lblFechaPago;
        private Label lblVencimiento;
        private TextBox txtDetallePago;
    }
}