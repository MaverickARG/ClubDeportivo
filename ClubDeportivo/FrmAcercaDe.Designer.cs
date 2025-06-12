namespace ClubDeportivo
{
    partial class FrmAcercaDe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcercaDe));
            lblTitulo = new Label();
            lblAutor = new Label();
            lblAnio = new Label();
            lblDescripcion = new Label();
            txtLegal = new TextBox();
            pictureBox1 = new PictureBox();
            btnCerrar = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(100, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(308, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Club Deportivo PI v1.2";
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.Location = new Point(174, 80);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(277, 15);
            lblAutor.TabIndex = 1;
            lblAutor.Text = "Desarrollado por: Santiago Cuda - Adrian Madroñal";
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(174, 104);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(56, 15);
            lblAnio.TabIndex = 2;
            lblAnio.Text = "Año 2025";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(174, 127);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(146, 15);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Sistema de gestion clubes.\r\n";
            // 
            // txtLegal
            // 
            txtLegal.BorderStyle = BorderStyle.None;
            txtLegal.Location = new Point(174, 174);
            txtLegal.Multiline = true;
            txtLegal.Name = "txtLegal";
            txtLegal.ReadOnly = true;
            txtLegal.ShortcutsEnabled = false;
            txtLegal.Size = new Size(284, 50);
            txtLegal.TabIndex = 0;
            txtLegal.Text = "© 2025 Club Deportivo.\r\nTodos los derechos reservados.\r\nEste software ha sido creado con fines educativos.\r\n";
            txtLegal.WordWrap = false;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = Properties.Resources.logo;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.InitialImage = Properties.Resources.logo;
            pictureBox1.Location = new Point(12, 80);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(154, 141);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(376, 233);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 6;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(174, 151);
            label1.Name = "label1";
            label1.Size = new Size(147, 15);
            label1.TabIndex = 7;
            label1.Text = "Proyecto Integrador DSOO";
            // 
            // FrmAcercaDe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 272);
            Controls.Add(label1);
            Controls.Add(btnCerrar);
            Controls.Add(pictureBox1);
            Controls.Add(txtLegal);
            Controls.Add(lblDescripcion);
            Controls.Add(lblAnio);
            Controls.Add(lblAutor);
            Controls.Add(lblTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAcercaDe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acerca de";
            Load += FrmAcercaDe_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblAutor;
        private Label lblAnio;
        private Label lblDescripcion;
        private TextBox txtLegal;
        private PictureBox pictureBox1;
        private Button btnCerrar;
        private Label label1;
    }
}