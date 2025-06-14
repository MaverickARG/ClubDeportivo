namespace ClubDeportivo
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            btnSalir = new Button();
            txtPassword = new TextBox();
            cmbUsuarios = new ComboBox();
            ptbLogo = new PictureBox();
            btnConfigurar = new Button();
            ((System.ComponentModel.ISupportInitialize)ptbLogo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(215, 33);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(215, 113);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(215, 170);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Entrar";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(296, 170);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(215, 131);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(156, 23);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // cmbUsuarios
            // 
            cmbUsuarios.FormattingEnabled = true;
            cmbUsuarios.Location = new Point(215, 69);
            cmbUsuarios.Name = "cmbUsuarios";
            cmbUsuarios.Size = new Size(156, 23);
            cmbUsuarios.TabIndex = 6;
            // 
            // ptbLogo
            // 
            ptbLogo.Image = (Image)resources.GetObject("ptbLogo.Image");
            ptbLogo.Location = new Point(27, 33);
            ptbLogo.Name = "ptbLogo";
            ptbLogo.Size = new Size(160, 160);
            ptbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbLogo.TabIndex = 7;
            ptbLogo.TabStop = false;
            // 
            // btnConfigurar
            // 
            btnConfigurar.Location = new Point(331, 12);
            btnConfigurar.Name = "btnConfigurar";
            btnConfigurar.Size = new Size(75, 23);
            btnConfigurar.TabIndex = 8;
            btnConfigurar.Text = "Configurar";
            btnConfigurar.UseVisualStyleBackColor = true;
            btnConfigurar.Click += btnConfigurar_Click;
            // 
            // FrmLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 236);
            Controls.Add(btnConfigurar);
            Controls.Add(ptbLogo);
            Controls.Add(cmbUsuarios);
            Controls.Add(btnSalir);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Club Deportivo PI";
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)ptbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private Label label2;
        private Button btnLogin;
        private Button btnSalir;
        private TextBox txtPassword;
        private ComboBox cmbUsuarios;
        private PictureBox ptbLogo;
        private Button btnConfigurar;
    }
}