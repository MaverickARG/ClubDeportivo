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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaPersona));
            btnBuscar = new Button();
            txtDni = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            lblDni = new Label();
            lblAptoFisico = new Label();
            lblFechaAlta = new Label();
            lblCarnetActivo = new Label();
            lblValorCuota = new Label();
            btnCerrar = new Button();
            btnImprimirCarnet = new Button();
            label9 = new Label();
            lblEstado = new Label();
            grbConsulta = new GroupBox();
            grbConsulta.SuspendLayout();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(196, 52);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(36, 53);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 26);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 6;
            label1.Text = "Ingrese DNI del Socio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 21);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 7;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 45);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 8;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 91);
            label4.Name = "label4";
            label4.Size = new Size(25, 15);
            label4.TabIndex = 9;
            label4.Text = "Dni";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 116);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 10;
            label5.Text = "Posee apto fisico";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 143);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 11;
            label6.Text = "Fecha de alta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 167);
            label7.Name = "label7";
            label7.Size = new Size(79, 15);
            label7.TabIndex = 12;
            label7.Text = "Carnet Activo";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 193);
            label8.Name = "label8";
            label8.Size = new Size(68, 15);
            label8.TabIndex = 13;
            label8.Text = "Valor Cuota";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(175, 21);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(49, 15);
            lblNombre.TabIndex = 14;
            lblNombre.Text = "nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(175, 45);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(49, 15);
            lblApellido.TabIndex = 15;
            lblApellido.Text = "apellido";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(175, 91);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(25, 15);
            lblDni.TabIndex = 16;
            lblDni.Text = "Dni";
            // 
            // lblAptoFisico
            // 
            lblAptoFisico.AutoSize = true;
            lblAptoFisico.Location = new Point(175, 116);
            lblAptoFisico.Name = "lblAptoFisico";
            lblAptoFisico.Size = new Size(31, 15);
            lblAptoFisico.TabIndex = 17;
            lblAptoFisico.Text = "apto";
            // 
            // lblFechaAlta
            // 
            lblFechaAlta.AutoSize = true;
            lblFechaAlta.Location = new Point(175, 143);
            lblFechaAlta.Name = "lblFechaAlta";
            lblFechaAlta.Size = new Size(58, 15);
            lblFechaAlta.TabIndex = 18;
            lblFechaAlta.Text = "fecha alta";
            // 
            // lblCarnetActivo
            // 
            lblCarnetActivo.AutoSize = true;
            lblCarnetActivo.Location = new Point(175, 167);
            lblCarnetActivo.Name = "lblCarnetActivo";
            lblCarnetActivo.Size = new Size(40, 15);
            lblCarnetActivo.TabIndex = 19;
            lblCarnetActivo.Text = "carnet";
            // 
            // lblValorCuota
            // 
            lblValorCuota.AutoSize = true;
            lblValorCuota.Location = new Point(175, 193);
            lblValorCuota.Name = "lblValorCuota";
            lblValorCuota.Size = new Size(66, 15);
            lblValorCuota.TabIndex = 20;
            lblValorCuota.Text = "valor cuota";
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(218, 326);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 21;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnImprimirCarnet
            // 
            btnImprimirCarnet.Location = new Point(36, 326);
            btnImprimirCarnet.Name = "btnImprimirCarnet";
            btnImprimirCarnet.Size = new Size(100, 23);
            btnImprimirCarnet.TabIndex = 22;
            btnImprimirCarnet.Text = "Imprimir Carnet";
            btnImprimirCarnet.UseVisualStyleBackColor = true;
            btnImprimirCarnet.Click += btnImprimirCarnet_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 67);
            label9.Name = "label9";
            label9.Size = new Size(42, 15);
            label9.TabIndex = 23;
            label9.Text = "Estado";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(175, 67);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(44, 15);
            lblEstado.TabIndex = 24;
            lblEstado.Text = "label10";
            // 
            // grbConsulta
            // 
            grbConsulta.Controls.Add(lblEstado);
            grbConsulta.Controls.Add(label2);
            grbConsulta.Controls.Add(label9);
            grbConsulta.Controls.Add(label3);
            grbConsulta.Controls.Add(label4);
            grbConsulta.Controls.Add(label5);
            grbConsulta.Controls.Add(lblValorCuota);
            grbConsulta.Controls.Add(label6);
            grbConsulta.Controls.Add(lblCarnetActivo);
            grbConsulta.Controls.Add(label7);
            grbConsulta.Controls.Add(lblFechaAlta);
            grbConsulta.Controls.Add(label8);
            grbConsulta.Controls.Add(lblAptoFisico);
            grbConsulta.Controls.Add(lblNombre);
            grbConsulta.Controls.Add(lblDni);
            grbConsulta.Controls.Add(lblApellido);
            grbConsulta.Location = new Point(21, 83);
            grbConsulta.Name = "grbConsulta";
            grbConsulta.Size = new Size(297, 226);
            grbConsulta.TabIndex = 25;
            grbConsulta.TabStop = false;
            // 
            // FrmConsultaPersona
            // 
            AcceptButton = btnBuscar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 381);
            Controls.Add(grbConsulta);
            Controls.Add(label1);
            Controls.Add(txtDni);
            Controls.Add(btnBuscar);
            Controls.Add(btnImprimirCarnet);
            Controls.Add(btnCerrar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmConsultaPersona";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta Socio / No Socio";
            grbConsulta.ResumeLayout(false);
            grbConsulta.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscar;
        private TextBox txtDni;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDni;
        private Label lblAptoFisico;
        private Label lblFechaAlta;
        private Label lblCarnetActivo;
        private Label lblValorCuota;
        private Button btnCerrar;
        private Button btnImprimirCarnet;
        private Label label9;
        private Label lblEstado;
        private GroupBox grbConsulta;
    }
}