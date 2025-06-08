namespace ClubDeportivo
{
    partial class FrmMenu
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
            btnCerrar = new Button();
            button2 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            btnSalir = new Button();
            menuStrip1 = new MenuStrip();
            sociosToolStripMenuItem = new ToolStripMenuItem();
            agregarUnNuevoSocioToolStripMenuItem = new ToolStripMenuItem();
            informacionDeSocioToolStripMenuItem = new ToolStripMenuItem();
            noToolStripMenuItem = new ToolStripMenuItem();
            agregarNoSocioToolStripMenuItem = new ToolStripMenuItem();
            informacionNoSociosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(164, 385);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(99, 23);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "Cerrar Sesion";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // button2
            // 
            button2.Location = new Point(60, 84);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 53);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(141, 85);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 5;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(513, 385);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(116, 23);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir de programa";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { sociosToolStripMenuItem, noToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // sociosToolStripMenuItem
            // 
            sociosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarUnNuevoSocioToolStripMenuItem, informacionDeSocioToolStripMenuItem });
            sociosToolStripMenuItem.Name = "sociosToolStripMenuItem";
            sociosToolStripMenuItem.Size = new Size(53, 20);
            sociosToolStripMenuItem.Text = "Socios";
            // 
            // agregarUnNuevoSocioToolStripMenuItem
            // 
            agregarUnNuevoSocioToolStripMenuItem.Name = "agregarUnNuevoSocioToolStripMenuItem";
            agregarUnNuevoSocioToolStripMenuItem.Size = new Size(200, 22);
            agregarUnNuevoSocioToolStripMenuItem.Text = "Agregar un nuevo socio";
            agregarUnNuevoSocioToolStripMenuItem.Click += agregarUnNuevoSocioToolStripMenuItem_Click;
            // 
            // informacionDeSocioToolStripMenuItem
            // 
            informacionDeSocioToolStripMenuItem.Name = "informacionDeSocioToolStripMenuItem";
            informacionDeSocioToolStripMenuItem.Size = new Size(200, 22);
            informacionDeSocioToolStripMenuItem.Text = "Informacion de socio";
            informacionDeSocioToolStripMenuItem.Click += informacionDeSocioToolStripMenuItem_Click;
            // 
            // noToolStripMenuItem
            // 
            noToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarNoSocioToolStripMenuItem, informacionNoSociosToolStripMenuItem });
            noToolStripMenuItem.Name = "noToolStripMenuItem";
            noToolStripMenuItem.Size = new Size(72, 20);
            noToolStripMenuItem.Text = "No Socios";
            // 
            // agregarNoSocioToolStripMenuItem
            // 
            agregarNoSocioToolStripMenuItem.Name = "agregarNoSocioToolStripMenuItem";
            agregarNoSocioToolStripMenuItem.Size = new Size(195, 22);
            agregarNoSocioToolStripMenuItem.Text = "Agregar No Socio";
            agregarNoSocioToolStripMenuItem.Click += agregarNoSocioToolStripMenuItem_Click;
            // 
            // informacionNoSociosToolStripMenuItem
            // 
            informacionNoSociosToolStripMenuItem.Name = "informacionNoSociosToolStripMenuItem";
            informacionNoSociosToolStripMenuItem.Size = new Size(195, 22);
            informacionNoSociosToolStripMenuItem.Text = "Informacion No Socios";
            informacionNoSociosToolStripMenuItem.Click += informacionNoSociosToolStripMenuItem_Click;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(btnCerrar);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMenu";
            Text = "FrmMenu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCerrar;
        private Button button2;
        private Label label1;
        private TextBox textBox1;
        private Button btnSalir;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sociosToolStripMenuItem;
        private ToolStripMenuItem agregarUnNuevoSocioToolStripMenuItem;
        private ToolStripMenuItem informacionDeSocioToolStripMenuItem;
        private ToolStripMenuItem noToolStripMenuItem;
        private ToolStripMenuItem agregarNoSocioToolStripMenuItem;
        private ToolStripMenuItem informacionNoSociosToolStripMenuItem;
    }
}