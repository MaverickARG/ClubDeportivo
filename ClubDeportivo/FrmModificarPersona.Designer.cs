namespace ClubDeportivo
{
    partial class FrmModificarPersona
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            txtApellido = new TextBox();
            chkAptoFisico = new CheckBox();
            label3 = new Label();
            btnGuardar = new Button();
            btnCerrar = new Button();
            label5 = new Label();
            groupBox1 = new GroupBox();
            txtDni = new TextBox();
            lblDni = new Label();
            rbSocio = new RadioButton();
            rbNoSocio = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(19, 46);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(57, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre: ";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(91, 43);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 75);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Apellido: ";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(91, 72);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 3;
            // 
            // chkAptoFisico
            // 
            chkAptoFisico.AutoSize = true;
            chkAptoFisico.Location = new Point(107, 145);
            chkAptoFisico.Name = "chkAptoFisico";
            chkAptoFisico.Size = new Size(15, 14);
            chkAptoFisico.TabIndex = 4;
            chkAptoFisico.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 145);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 5;
            label3.Text = "Apto Fisico";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(19, 218);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(188, 218);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ImeMode = ImeMode.NoControl;
            label5.Location = new Point(86, 44);
            label5.Name = "label5";
            label5.Size = new Size(170, 30);
            label5.TabIndex = 14;
            label5.Text = "Modificar Datos";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbNoSocio);
            groupBox1.Controls.Add(rbSocio);
            groupBox1.Controls.Add(txtDni);
            groupBox1.Controls.Add(lblDni);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(lblNombre);
            groupBox1.Controls.Add(btnCerrar);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(chkAptoFisico);
            groupBox1.Location = new Point(21, 96);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(302, 261);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(91, 101);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 9;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(19, 104);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(33, 15);
            lblDni.TabIndex = 8;
            lblDni.Text = "DNI: ";
            // 
            // rbSocio
            // 
            rbSocio.AutoSize = true;
            rbSocio.Location = new Point(31, 178);
            rbSocio.Name = "rbSocio";
            rbSocio.Size = new Size(54, 19);
            rbSocio.TabIndex = 10;
            rbSocio.TabStop = true;
            rbSocio.Text = "Socio";
            rbSocio.UseVisualStyleBackColor = true;
            // 
            // rbNoSocio
            // 
            rbNoSocio.AutoSize = true;
            rbNoSocio.Location = new Point(118, 178);
            rbNoSocio.Name = "rbNoSocio";
            rbNoSocio.Size = new Size(73, 19);
            rbNoSocio.TabIndex = 11;
            rbNoSocio.TabStop = true;
            rbNoSocio.Text = "No Socio";
            rbNoSocio.UseVisualStyleBackColor = true;
            // 
            // FrmModificarPersona
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 381);
            Controls.Add(groupBox1);
            Controls.Add(label5);
            Name = "FrmModificarPersona";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar Datos";
            Load += FrmModificarPersona_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();


        }
        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtApellido;
        private CheckBox chkAptoFisico;
        private Label label3;
        private Button btnGuardar;
        private Button btnCerrar;
        private Label label5;
        private GroupBox groupBox1;
        private Label lblDni;
        private TextBox txtDni;
        private RadioButton rbNoSocio;
        private RadioButton rbSocio;
    }
}