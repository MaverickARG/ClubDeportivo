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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            btnCerrar = new Button();
            lblBienvenida = new Label();
            btnSalir = new Button();
            btnListarVencimientos = new Button();
            dgvVencimientos = new DataGridView();
            pibLogo = new PictureBox();
            sociosToolStripMenuItem = new ToolStripMenuItem();
            agregarUnNuevoSocioToolStripMenuItem = new ToolStripMenuItem();
            informacionDeSocioToolStripMenuItem = new ToolStripMenuItem();
            noToolStripMenuItem = new ToolStripMenuItem();
            agregarNoSocioToolStripMenuItem = new ToolStripMenuItem();
            informacionNoSociosToolStripMenuItem = new ToolStripMenuItem();
            pagosToolStripMenuItem = new ToolStripMenuItem();
            pagoDeCuotaSocioToolStripMenuItem = new ToolStripMenuItem();
            pagoDiarioNoSocioToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            manualToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pibLogo).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            resources.ApplyResources(btnCerrar, "btnCerrar");
            btnCerrar.Name = "btnCerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblBienvenida
            // 
            resources.ApplyResources(lblBienvenida, "lblBienvenida");
            lblBienvenida.Name = "lblBienvenida";
            // 
            // btnSalir
            // 
            resources.ApplyResources(btnSalir, "btnSalir");
            btnSalir.Name = "btnSalir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnListarVencimientos
            // 
            resources.ApplyResources(btnListarVencimientos, "btnListarVencimientos");
            btnListarVencimientos.Name = "btnListarVencimientos";
            btnListarVencimientos.UseVisualStyleBackColor = true;
            btnListarVencimientos.Click += btnListarVencimientos_Click;
            // 
            // dgvVencimientos
            // 
            resources.ApplyResources(dgvVencimientos, "dgvVencimientos");
            dgvVencimientos.AllowUserToAddRows = false;
            dgvVencimientos.AllowUserToDeleteRows = false;
            dgvVencimientos.AllowUserToResizeColumns = false;
            dgvVencimientos.AllowUserToResizeRows = false;
            dgvVencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVencimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVencimientos.MultiSelect = false;
            dgvVencimientos.Name = "dgvVencimientos";
            dgvVencimientos.ReadOnly = true;
            dgvVencimientos.RowHeadersVisible = false;
            dgvVencimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVencimientos.CellContentClick += dgvVencimientos_CellContentClick;
            // 
            // pibLogo
            // 
            resources.ApplyResources(pibLogo, "pibLogo");
            pibLogo.AccessibleRole = AccessibleRole.Alert;
            pibLogo.Image = Properties.Resources.logo;
            pibLogo.Name = "pibLogo";
            pibLogo.TabStop = false;
            // 
            // sociosToolStripMenuItem
            // 
            resources.ApplyResources(sociosToolStripMenuItem, "sociosToolStripMenuItem");
            sociosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarUnNuevoSocioToolStripMenuItem, informacionDeSocioToolStripMenuItem });
            sociosToolStripMenuItem.Name = "sociosToolStripMenuItem";
            // 
            // agregarUnNuevoSocioToolStripMenuItem
            // 
            resources.ApplyResources(agregarUnNuevoSocioToolStripMenuItem, "agregarUnNuevoSocioToolStripMenuItem");
            agregarUnNuevoSocioToolStripMenuItem.Name = "agregarUnNuevoSocioToolStripMenuItem";
            agregarUnNuevoSocioToolStripMenuItem.Click += agregarUnNuevoSocioToolStripMenuItem_Click;
            // 
            // informacionDeSocioToolStripMenuItem
            // 
            resources.ApplyResources(informacionDeSocioToolStripMenuItem, "informacionDeSocioToolStripMenuItem");
            informacionDeSocioToolStripMenuItem.Name = "informacionDeSocioToolStripMenuItem";
            informacionDeSocioToolStripMenuItem.Click += informacionDeSocioToolStripMenuItem_Click;
            // 
            // noToolStripMenuItem
            // 
            resources.ApplyResources(noToolStripMenuItem, "noToolStripMenuItem");
            noToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarNoSocioToolStripMenuItem, informacionNoSociosToolStripMenuItem });
            noToolStripMenuItem.Name = "noToolStripMenuItem";
            // 
            // agregarNoSocioToolStripMenuItem
            // 
            resources.ApplyResources(agregarNoSocioToolStripMenuItem, "agregarNoSocioToolStripMenuItem");
            agregarNoSocioToolStripMenuItem.Name = "agregarNoSocioToolStripMenuItem";
            agregarNoSocioToolStripMenuItem.Click += agregarNoSocioToolStripMenuItem_Click;
            // 
            // informacionNoSociosToolStripMenuItem
            // 
            resources.ApplyResources(informacionNoSociosToolStripMenuItem, "informacionNoSociosToolStripMenuItem");
            informacionNoSociosToolStripMenuItem.Name = "informacionNoSociosToolStripMenuItem";
            informacionNoSociosToolStripMenuItem.Click += informacionNoSociosToolStripMenuItem_Click;
            // 
            // pagosToolStripMenuItem
            // 
            resources.ApplyResources(pagosToolStripMenuItem, "pagosToolStripMenuItem");
            pagosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pagoDeCuotaSocioToolStripMenuItem, pagoDiarioNoSocioToolStripMenuItem });
            pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
            // 
            // pagoDeCuotaSocioToolStripMenuItem
            // 
            resources.ApplyResources(pagoDeCuotaSocioToolStripMenuItem, "pagoDeCuotaSocioToolStripMenuItem");
            pagoDeCuotaSocioToolStripMenuItem.Name = "pagoDeCuotaSocioToolStripMenuItem";
            pagoDeCuotaSocioToolStripMenuItem.Click += pagoDeCuotaSocioToolStripMenuItem_Click;
            // 
            // pagoDiarioNoSocioToolStripMenuItem
            // 
            resources.ApplyResources(pagoDiarioNoSocioToolStripMenuItem, "pagoDiarioNoSocioToolStripMenuItem");
            pagoDiarioNoSocioToolStripMenuItem.Name = "pagoDiarioNoSocioToolStripMenuItem";
            // 
            // ayudaToolStripMenuItem
            // 
            resources.ApplyResources(ayudaToolStripMenuItem, "ayudaToolStripMenuItem");
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manualToolStripMenuItem, acercaDeToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            // 
            // manualToolStripMenuItem
            // 
            resources.ApplyResources(manualToolStripMenuItem, "manualToolStripMenuItem");
            manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            // 
            // acercaDeToolStripMenuItem
            // 
            resources.ApplyResources(acercaDeToolStripMenuItem, "acercaDeToolStripMenuItem");
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Items.AddRange(new ToolStripItem[] { sociosToolStripMenuItem, noToolStripMenuItem, pagosToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Name = "menuStrip1";
            // 
            // FrmMenu
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pibLogo);
            Controls.Add(dgvVencimientos);
            Controls.Add(btnListarVencimientos);
            Controls.Add(btnSalir);
            Controls.Add(lblBienvenida);
            Controls.Add(btnCerrar);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FrmMenu";
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pibLogo).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCerrar;
        private Label lblBienvenida;
        private Button btnSalir;
        private Button btnListarVencimientos;
        private DataGridView dgvVencimientos;
        private PictureBox pibLogo;
        private ToolStripMenuItem sociosToolStripMenuItem;
        private ToolStripMenuItem agregarUnNuevoSocioToolStripMenuItem;
        private ToolStripMenuItem informacionDeSocioToolStripMenuItem;
        private ToolStripMenuItem noToolStripMenuItem;
        private ToolStripMenuItem agregarNoSocioToolStripMenuItem;
        private ToolStripMenuItem informacionNoSociosToolStripMenuItem;
        private ToolStripMenuItem pagosToolStripMenuItem;
        private ToolStripMenuItem pagoDeCuotaSocioToolStripMenuItem;
        private ToolStripMenuItem pagoDiarioNoSocioToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem manualToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private MenuStrip menuStrip1;
    }
}