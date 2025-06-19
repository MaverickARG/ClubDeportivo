namespace ClubDeportivo
{
    partial class FrmModificarConexion
    {
        /// <summary>
        ///  Variable del diseñador.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        ///  Método necesario para admitir el Diseñador. No se puede modificar
        ///  el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModificarConexion));
            lblServidor = new Label();
            lblPuerto = new Label();
            lblUsuario = new Label();
            lblClave = new Label();
            lblBaseDatos = new Label();
            txtServidor = new TextBox();
            txtPuerto = new TextBox();
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            txtBaseDatos = new TextBox();
            btnGuardarConexion = new Button();
            SuspendLayout();
            // 
            // lblServidor
            // 
            lblServidor.AutoSize = true;
            lblServidor.Location = new Point(30, 30);
            lblServidor.Name = "lblServidor";
            lblServidor.Size = new Size(53, 15);
            lblServidor.TabIndex = 0;
            lblServidor.Text = "Servidor:";
            // 
            // lblPuerto
            // 
            lblPuerto.AutoSize = true;
            lblPuerto.Location = new Point(30, 70);
            lblPuerto.Name = "lblPuerto";
            lblPuerto.Size = new Size(45, 15);
            lblPuerto.TabIndex = 1;
            lblPuerto.Text = "Puerto:";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(30, 110);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario:";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Location = new Point(30, 150);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(39, 15);
            lblClave.TabIndex = 3;
            lblClave.Text = "Clave:";
            // 
            // lblBaseDatos
            // 
            lblBaseDatos.AutoSize = true;
            lblBaseDatos.Location = new Point(30, 190);
            lblBaseDatos.Name = "lblBaseDatos";
            lblBaseDatos.Size = new Size(82, 15);
            lblBaseDatos.TabIndex = 4;
            lblBaseDatos.Text = "Base de datos:";
            // 
            // txtServidor
            // 
            txtServidor.Location = new Point(140, 27);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(137, 23);
            txtServidor.TabIndex = 5;
            txtServidor.Text = "localhost";
            // 
            // txtPuerto
            // 
            txtPuerto.Location = new Point(140, 67);
            txtPuerto.Name = "txtPuerto";
            txtPuerto.Size = new Size(137, 23);
            txtPuerto.TabIndex = 6;
            txtPuerto.Text = "3306";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(140, 107);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(137, 23);
            txtUsuario.TabIndex = 7;
            txtUsuario.Text = "root";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(140, 147);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(137, 23);
            txtClave.TabIndex = 8;
            // 
            // txtBaseDatos
            // 
            txtBaseDatos.Location = new Point(140, 187);
            txtBaseDatos.Name = "txtBaseDatos";
            txtBaseDatos.Size = new Size(137, 23);
            txtBaseDatos.TabIndex = 9;
            txtBaseDatos.Text = "club_deportivo";
            // 
            // btnGuardarConexion
            // 
            btnGuardarConexion.Location = new Point(74, 226);
            btnGuardarConexion.Name = "btnGuardarConexion";
            btnGuardarConexion.Size = new Size(180, 30);
            btnGuardarConexion.TabIndex = 10;
            btnGuardarConexion.Text = "Guardar y Conectar";
            btnGuardarConexion.UseVisualStyleBackColor = true;
            btnGuardarConexion.Click += btnGuardarConexion_Click;
            // 
            // FrmModificarConexion
            // 
            AcceptButton = btnGuardarConexion;
            ClientSize = new Size(321, 280);
            Controls.Add(btnGuardarConexion);
            Controls.Add(txtBaseDatos);
            Controls.Add(txtClave);
            Controls.Add(txtUsuario);
            Controls.Add(txtPuerto);
            Controls.Add(txtServidor);
            Controls.Add(lblBaseDatos);
            Controls.Add(lblClave);
            Controls.Add(lblUsuario);
            Controls.Add(lblPuerto);
            Controls.Add(lblServidor);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmModificarConexion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración de Conexión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblBaseDatos;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtBaseDatos;
        private System.Windows.Forms.Button btnGuardarConexion;
    }
}
