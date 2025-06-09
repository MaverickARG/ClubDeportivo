namespace ClubDeportivo
{
    partial class FrmPagos
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblResultado;

        private System.Windows.Forms.GroupBox grpSocio;
        private System.Windows.Forms.ComboBox cboFormaPago;
        private System.Windows.Forms.TextBox txtValorBase;
        private System.Windows.Forms.Label lblMontoFinalSocio;
        private System.Windows.Forms.Button btnPagarSocio;

        private System.Windows.Forms.GroupBox grpNoSocio;
        private System.Windows.Forms.ComboBox cboActividad;
        private System.Windows.Forms.Label lblValorActividad;
        private System.Windows.Forms.Button btnPagarNoSocio;

        private void InitializeComponent()
        {
            lblDni = new Label();
            txtDni = new TextBox();
            btnBuscar = new Button();
            lblResultado = new Label();
            grpSocio = new GroupBox();
            cboFormaPago = new ComboBox();
            txtValorBase = new TextBox();
            lblMontoFinalSocio = new Label();
            btnPagarSocio = new Button();
            grpNoSocio = new GroupBox();
            cboActividad = new ComboBox();
            lblValorActividad = new Label();
            btnPagarNoSocio = new Button();
            grpSocio.SuspendLayout();
            grpNoSocio.SuspendLayout();
            SuspendLayout();
            // 
            // lblDni
            // 
            lblDni.Location = new Point(30, 30);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(51, 23);
            lblDni.TabIndex = 0;
            lblDni.Text = "DNI:";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(112, 30);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(118, 23);
            txtDni.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(250, 30);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblResultado
            // 
            lblResultado.Location = new Point(30, 60);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(300, 23);
            lblResultado.TabIndex = 3;
            // 
            // grpSocio
            // 
            grpSocio.Controls.Add(cboFormaPago);
            grpSocio.Controls.Add(txtValorBase);
            grpSocio.Controls.Add(lblMontoFinalSocio);
            grpSocio.Controls.Add(btnPagarSocio);
            grpSocio.Location = new Point(30, 100);
            grpSocio.Name = "grpSocio";
            grpSocio.Size = new Size(500, 150);
            grpSocio.TabIndex = 4;
            grpSocio.TabStop = false;
            grpSocio.Text = "Pago Socio";
            // 
            // cboFormaPago
            // 
            cboFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormaPago.Location = new Point(20, 30);
            cboFormaPago.Name = "cboFormaPago";
            cboFormaPago.Size = new Size(200, 23);
            cboFormaPago.TabIndex = 0;
            // 
            // txtValorBase
            // 
            txtValorBase.Location = new Point(20, 60);
            txtValorBase.Name = "txtValorBase";
            txtValorBase.PlaceholderText = "Valor base cuota";
            txtValorBase.Size = new Size(100, 23);
            txtValorBase.TabIndex = 1;
            // 
            // lblMontoFinalSocio
            // 
            lblMontoFinalSocio.Location = new Point(20, 90);
            lblMontoFinalSocio.Name = "lblMontoFinalSocio";
            lblMontoFinalSocio.Size = new Size(200, 23);
            lblMontoFinalSocio.TabIndex = 2;
            lblMontoFinalSocio.Text = "Total a pagar: $0.00";
            // 
            // btnPagarSocio
            // 
            btnPagarSocio.Location = new Point(300, 90);
            btnPagarSocio.Name = "btnPagarSocio";
            btnPagarSocio.Size = new Size(75, 23);
            btnPagarSocio.TabIndex = 3;
            btnPagarSocio.Text = "Registrar Pago";
            btnPagarSocio.Click += btnPagarSocio_Click;
            // 
            // grpNoSocio
            // 
            grpNoSocio.Controls.Add(cboActividad);
            grpNoSocio.Controls.Add(lblValorActividad);
            grpNoSocio.Controls.Add(btnPagarNoSocio);
            grpNoSocio.Location = new Point(30, 270);
            grpNoSocio.Name = "grpNoSocio";
            grpNoSocio.Size = new Size(500, 150);
            grpNoSocio.TabIndex = 5;
            grpNoSocio.TabStop = false;
            grpNoSocio.Text = "Pago No Socio";
            // 
            // cboActividad
            // 
            cboActividad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActividad.Location = new Point(20, 30);
            cboActividad.Name = "cboActividad";
            cboActividad.Size = new Size(250, 23);
            cboActividad.TabIndex = 0;
            // 
            // lblValorActividad
            // 
            lblValorActividad.Location = new Point(20, 60);
            lblValorActividad.Name = "lblValorActividad";
            lblValorActividad.Size = new Size(200, 23);
            lblValorActividad.TabIndex = 1;
            lblValorActividad.Text = "Valor actividad: $0.00";
            // 
            // btnPagarNoSocio
            // 
            btnPagarNoSocio.Location = new Point(300, 90);
            btnPagarNoSocio.Name = "btnPagarNoSocio";
            btnPagarNoSocio.Size = new Size(75, 23);
            btnPagarNoSocio.TabIndex = 2;
            btnPagarNoSocio.Text = "Registrar Entrada";
            btnPagarNoSocio.Click += btnPagarNoSocio_Click;
            // 
            // FrmPagos
            // 
            ClientSize = new Size(584, 461);
            Controls.Add(lblDni);
            Controls.Add(txtDni);
            Controls.Add(btnBuscar);
            Controls.Add(lblResultado);
            Controls.Add(grpSocio);
            Controls.Add(grpNoSocio);
            Name = "FrmPagos";
            Text = "Pagos";
            Load += FrmPagos_Load;
            grpSocio.ResumeLayout(false);
            grpSocio.PerformLayout();
            grpNoSocio.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}