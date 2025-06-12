namespace ClubDeportivo
{
    partial class FrmAgregarSocio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarSocio));
            label1 = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            label3 = new Label();
            lblAptoFisico = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            txtDni = new TextBox();
            chkAptoFisico = new CheckBox();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label5 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 25);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 54);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Apellido";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(103, 22);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(103, 51);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 83);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 4;
            label3.Text = "DNI";
            // 
            // lblAptoFisico
            // 
            lblAptoFisico.AutoSize = true;
            lblAptoFisico.Location = new Point(25, 116);
            lblAptoFisico.Name = "lblAptoFisico";
            lblAptoFisico.Size = new Size(66, 15);
            lblAptoFisico.TabIndex = 5;
            lblAptoFisico.Text = "Apto Fisico";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(27, 165);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(199, 165);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(103, 80);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 3;
            // 
            // chkAptoFisico
            // 
            chkAptoFisico.AutoSize = true;
            chkAptoFisico.Location = new Point(115, 116);
            chkAptoFisico.Name = "chkAptoFisico";
            chkAptoFisico.Size = new Size(15, 14);
            chkAptoFisico.TabIndex = 4;
            chkAptoFisico.UseVisualStyleBackColor = true;
            chkAptoFisico.CheckedChanged += chkAptoFisico_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(chkAptoFisico);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtDni);
            groupBox1.Controls.Add(lblAptoFisico);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(21, 135);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(304, 226);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(48, 30);
            label4.Name = "label4";
            label4.Size = new Size(247, 37);
            label4.TabIndex = 12;
            label4.Text = "Club Deportivo PI";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ImeMode = ImeMode.NoControl;
            label5.Location = new Point(93, 86);
            label5.Name = "label5";
            label5.Size = new Size(149, 30);
            label5.TabIndex = 13;
            label5.Text = "Agregar socio";
            // 
            // FrmAgregarSocio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 381);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmAgregarSocio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Socio";
            Load += FrmAgregarSocio_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label label3;
        private Label lblAptoFisico;
        private Button btnGuardar;
        private Button btnCancelar;
        private TextBox txtDni;
        private CheckBox chkAptoFisico;
        private GroupBox groupBox1;
        private Label label4;
        private Label label5;
    }
}