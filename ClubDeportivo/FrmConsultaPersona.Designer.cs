namespace ClubDeportivo
{
    partial class FrmConsultaPersona
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBuscar = new Button();
            txtDni = new TextBox();
            lblNombre = new Label();
            lblApellido = new Label();
            lblTipoPersona = new Label();
            btnCerrar = new Button();
            dgvDatosPersona = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDatosPersona).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(223, 67);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(83, 67);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(83, 136);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(0, 15);
            lblNombre.TabIndex = 2;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(83, 181);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(0, 15);
            lblApellido.TabIndex = 3;
            // 
            // lblTipoPersona
            // 
            lblTipoPersona.AutoSize = true;
            lblTipoPersona.Location = new Point(83, 221);
            lblTipoPersona.Name = "lblTipoPersona";
            lblTipoPersona.Size = new Size(0, 15);
            lblTipoPersona.TabIndex = 4;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(678, 393);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // dgvDatosPersona
            // 
            dgvDatosPersona.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatosPersona.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatosPersona.Location = new Point(46, 108);
            dgvDatosPersona.Name = "dgvDatosPersona";
            dgvDatosPersona.ReadOnly = true;
            dgvDatosPersona.Size = new Size(707, 228);
            dgvDatosPersona.TabIndex = 6;
            dgvDatosPersona.CellContentClick += dgvDatosPersona_CellContentClick;
            // 
            // FrmConsultaPersona
            // 
            AcceptButton = btnBuscar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvDatosPersona);
            Controls.Add(btnCerrar);
            Controls.Add(lblTipoPersona);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(txtDni);
            Controls.Add(btnBuscar);
            Name = "FrmConsultaPersona";
            Text = "FrmConsultaPersona";
            ((System.ComponentModel.ISupportInitialize)dgvDatosPersona).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscar;
        private TextBox txtDni;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblTipoPersona;
        private Button btnCerrar;
        private DataGridView dgvDatosPersona;
    }
}