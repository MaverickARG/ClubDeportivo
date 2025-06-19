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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPagos));
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
            btnSalir = new Button();
            lblNombre = new Label();
            lblApellido = new Label();
            dgvDetalle = new DataGridView();
            btnImprimirCarnet = new Button();
            btnImprimirRecibo = new Button();
            grpSocio.SuspendLayout();
            grpNoSocio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // lblDni
            // 
            lblDni.Location = new Point(31, 56);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(51, 23);
            lblDni.TabIndex = 0;
            lblDni.Text = "DNI:";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(84, 53);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(118, 23);
            txtDni.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(229, 56);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblResultado
            // 
            lblResultado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblResultado.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResultado.Location = new Point(334, 34);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(216, 47);
            lblResultado.TabIndex = 3;
            lblResultado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpSocio
            // 
            grpSocio.Controls.Add(cboFormaPago);
            grpSocio.Controls.Add(txtValorBase);
            grpSocio.Controls.Add(lblMontoFinalSocio);
            grpSocio.Controls.Add(btnPagarSocio);
            grpSocio.Location = new Point(210, 101);
            grpSocio.Name = "grpSocio";
            grpSocio.Size = new Size(340, 132);
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
            txtValorBase.Location = new Point(20, 70);
            txtValorBase.Name = "txtValorBase";
            txtValorBase.PlaceholderText = "Valor base cuota";
            txtValorBase.Size = new Size(100, 23);
            txtValorBase.TabIndex = 1;
            // 
            // lblMontoFinalSocio
            // 
            lblMontoFinalSocio.Location = new Point(20, 100);
            lblMontoFinalSocio.Name = "lblMontoFinalSocio";
            lblMontoFinalSocio.Size = new Size(200, 23);
            lblMontoFinalSocio.TabIndex = 2;
            lblMontoFinalSocio.Text = "Total a pagar: $0.00";
            // 
            // btnPagarSocio
            // 
            btnPagarSocio.Location = new Point(226, 70);
            btnPagarSocio.Name = "btnPagarSocio";
            btnPagarSocio.Size = new Size(98, 23);
            btnPagarSocio.TabIndex = 3;
            btnPagarSocio.Text = "Registrar Pago";
            btnPagarSocio.Click += btnPagarSocio_Click;
            // 
            // grpNoSocio
            // 
            grpNoSocio.Controls.Add(cboActividad);
            grpNoSocio.Controls.Add(lblValorActividad);
            grpNoSocio.Controls.Add(btnPagarNoSocio);
            grpNoSocio.Location = new Point(210, 250);
            grpNoSocio.Name = "grpNoSocio";
            grpNoSocio.Size = new Size(340, 134);
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
            lblValorActividad.Location = new Point(20, 77);
            lblValorActividad.Name = "lblValorActividad";
            lblValorActividad.Size = new Size(200, 23);
            lblValorActividad.TabIndex = 1;
            lblValorActividad.Text = "Valor actividad: $0.00";
            // 
            // btnPagarNoSocio
            // 
            btnPagarNoSocio.Location = new Point(226, 77);
            btnPagarNoSocio.Name = "btnPagarNoSocio";
            btnPagarNoSocio.Size = new Size(98, 23);
            btnPagarNoSocio.TabIndex = 2;
            btnPagarNoSocio.Text = "Registrar Pago";
            btnPagarNoSocio.Click += btnPagarNoSocio_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(475, 404);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Cerrar";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += button1_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(42, 104);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(0, 15);
            lblNombre.TabIndex = 7;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(42, 143);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(0, 15);
            lblApellido.TabIndex = 8;
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(30, 185);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(162, 213);
            dgvDetalle.TabIndex = 9;
            // 
            // btnImprimirCarnet
            // 
            btnImprimirCarnet.Location = new Point(343, 404);
            btnImprimirCarnet.Name = "btnImprimirCarnet";
            btnImprimirCarnet.Size = new Size(105, 23);
            btnImprimirCarnet.TabIndex = 10;
            btnImprimirCarnet.Text = "Imprimir Carnet";
            btnImprimirCarnet.UseVisualStyleBackColor = true;
            btnImprimirCarnet.Click += btnImprimirCarnet_Click;
            // 
            // btnImprimirRecibo
            // 
            btnImprimirRecibo.Location = new Point(210, 404);
            btnImprimirRecibo.Name = "btnImprimirRecibo";
            btnImprimirRecibo.Size = new Size(108, 23);
            btnImprimirRecibo.TabIndex = 13;
            btnImprimirRecibo.Text = "Imprimir recibo";
            btnImprimirRecibo.Click += btnImprimirRecibo_Click;
            // 
            // FrmPagos
            // 
            AcceptButton = btnBuscar;
            ClientSize = new Size(584, 461);
            Controls.Add(btnImprimirRecibo);
            Controls.Add(btnImprimirCarnet);
            Controls.Add(dgvDetalle);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(btnSalir);
            Controls.Add(lblDni);
            Controls.Add(txtDni);
            Controls.Add(btnBuscar);
            Controls.Add(lblResultado);
            Controls.Add(grpSocio);
            Controls.Add(grpNoSocio);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPagos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pagos";
            Load += FrmPagos_Load;
            grpSocio.ResumeLayout(false);
            grpSocio.PerformLayout();
            grpNoSocio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button btnSalir;
        private Label lblNombre;
        private Label lblApellido;
        private DataGridView dgvDetalle;
        private Button btnImprimirCarnet;
        private Button btnImprimirRecibo;
    }
}