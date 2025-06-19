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
            btnSalir = new Button();
            btnListarVencimientos = new Button();
            dgvVencimientos = new DataGridView();
            pibLogo = new PictureBox();
            sociosToolStripMenuItem = new ToolStripMenuItem();
            agregarUnNuevoSocioToolStripMenuItem = new ToolStripMenuItem();
            agregarToolStripMenuItem = new ToolStripMenuItem();
            informacionDeSocioToolStripMenuItem = new ToolStripMenuItem();
            pagosToolStripMenuItem = new ToolStripMenuItem();
            pagoDeCuotaSocioToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            manualToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
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
            dgvVencimientos.AllowUserToAddRows = false;
            dgvVencimientos.AllowUserToDeleteRows = false;
            dgvVencimientos.AllowUserToResizeColumns = false;
            dgvVencimientos.AllowUserToResizeRows = false;
            dgvVencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVencimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dgvVencimientos, "dgvVencimientos");
            dgvVencimientos.MultiSelect = false;
            dgvVencimientos.Name = "dgvVencimientos";
            dgvVencimientos.ReadOnly = true;
            dgvVencimientos.RowHeadersVisible = false;
            dgvVencimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVencimientos.CellContentClick += dgvVencimientos_CellContentClick;
            // 
            // pibLogo
            // 
            pibLogo.AccessibleRole = AccessibleRole.Alert;
            resources.ApplyResources(pibLogo, "pibLogo");
            pibLogo.Name = "pibLogo";
            pibLogo.TabStop = false;
            // 
            // sociosToolStripMenuItem
            // 
            sociosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarUnNuevoSocioToolStripMenuItem, agregarToolStripMenuItem, informacionDeSocioToolStripMenuItem });
            sociosToolStripMenuItem.Name = "sociosToolStripMenuItem";
            resources.ApplyResources(sociosToolStripMenuItem, "sociosToolStripMenuItem");
            // 
            // agregarUnNuevoSocioToolStripMenuItem
            // 
            agregarUnNuevoSocioToolStripMenuItem.Name = "agregarUnNuevoSocioToolStripMenuItem";
            resources.ApplyResources(agregarUnNuevoSocioToolStripMenuItem, "agregarUnNuevoSocioToolStripMenuItem");
            agregarUnNuevoSocioToolStripMenuItem.Click += agregarUnNuevoSocioToolStripMenuItem_Click;
            // 
            // agregarToolStripMenuItem
            // 
            agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            resources.ApplyResources(agregarToolStripMenuItem, "agregarToolStripMenuItem");
            agregarToolStripMenuItem.Click += agregarToolStripMenuItem_Click;
            // 
            // informacionDeSocioToolStripMenuItem
            // 
            informacionDeSocioToolStripMenuItem.Name = "informacionDeSocioToolStripMenuItem";
            resources.ApplyResources(informacionDeSocioToolStripMenuItem, "informacionDeSocioToolStripMenuItem");
            informacionDeSocioToolStripMenuItem.Click += informacionDeSocioToolStripMenuItem_Click;
            // 
            // pagosToolStripMenuItem
            // 
            pagosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pagoDeCuotaSocioToolStripMenuItem });
            pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
            resources.ApplyResources(pagosToolStripMenuItem, "pagosToolStripMenuItem");
            // 
            // pagoDeCuotaSocioToolStripMenuItem
            // 
            pagoDeCuotaSocioToolStripMenuItem.Name = "pagoDeCuotaSocioToolStripMenuItem";
            resources.ApplyResources(pagoDeCuotaSocioToolStripMenuItem, "pagoDeCuotaSocioToolStripMenuItem");
            pagoDeCuotaSocioToolStripMenuItem.Click += pagoDeCuotaSocioToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { sociosToolStripMenuItem, pagosToolStripMenuItem, ayudaToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manualToolStripMenuItem, acercaDeToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            resources.ApplyResources(ayudaToolStripMenuItem, "ayudaToolStripMenuItem");
            // 
            // manualToolStripMenuItem
            // 
            manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            resources.ApplyResources(manualToolStripMenuItem, "manualToolStripMenuItem");
            manualToolStripMenuItem.Click += manualToolStripMenuItem_Click;
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            resources.ApplyResources(acercaDeToolStripMenuItem, "acercaDeToolStripMenuItem");
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // FrmMenu
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(pibLogo);
            Controls.Add(dgvVencimientos);
            Controls.Add(btnListarVencimientos);
            Controls.Add(btnSalir);
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
        private ToolStripMenuItem pagosToolStripMenuItem;
        private ToolStripMenuItem pagoDeCuotaSocioToolStripMenuItem;
        private MenuStrip menuStrip1;
        private Label label1;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem manualToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private ToolStripMenuItem agregarToolStripMenuItem;
    }
}