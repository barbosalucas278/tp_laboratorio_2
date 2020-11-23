namespace Teatro
{
    partial class Teatro
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Teatro));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.boleteriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vEntanillaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.electronicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.espectaculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boleteriaToolStripMenuItem,
            this.espectaculoToolStripMenuItem,
            this.informeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(834, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // boleteriaToolStripMenuItem
            // 
            this.boleteriaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vEntanillaToolStripMenuItem,
            this.electronicaToolStripMenuItem});
            this.boleteriaToolStripMenuItem.Enabled = false;
            this.boleteriaToolStripMenuItem.Name = "boleteriaToolStripMenuItem";
            this.boleteriaToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.boleteriaToolStripMenuItem.Text = "Boleteria";
            // 
            // vEntanillaToolStripMenuItem
            // 
            this.vEntanillaToolStripMenuItem.Name = "vEntanillaToolStripMenuItem";
            this.vEntanillaToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.vEntanillaToolStripMenuItem.Text = "Agregar Ventanilla";
            this.vEntanillaToolStripMenuItem.Click += new System.EventHandler(this.VentanillaToolStripMenuItem_Click);
            // 
            // electronicaToolStripMenuItem
            // 
            this.electronicaToolStripMenuItem.Name = "electronicaToolStripMenuItem";
            this.electronicaToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.electronicaToolStripMenuItem.Text = "Agregar punto Electrónico";
            this.electronicaToolStripMenuItem.Click += new System.EventHandler(this.electronicaToolStripMenuItem_Click);
            // 
            // espectaculoToolStripMenuItem
            // 
            this.espectaculoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem});
            this.espectaculoToolStripMenuItem.Name = "espectaculoToolStripMenuItem";
            this.espectaculoToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.espectaculoToolStripMenuItem.Text = "Espectaculo";
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarToolStripMenuItem.Text = "Agregar ";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            

            // 
            // Teatro
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(834, 662);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Teatro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teatro";
            this.Load += new System.EventHandler(this.FrmTeatro_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem boleteriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vEntanillaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem electronicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem espectaculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeToolStripMenuItem;
    }
}

