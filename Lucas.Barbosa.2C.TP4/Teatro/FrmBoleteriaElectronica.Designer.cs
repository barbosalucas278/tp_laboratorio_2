namespace Teatro
{
    partial class FrmBoleteriaElectronica
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
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.richTextBoxVentaElectronica = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(12, 50);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(162, 62);
            this.btnAbrir.TabIndex = 0;
            this.btnAbrir.Text = "Abrir Boleteria";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Enabled = false;
            this.btnCerrar.Location = new System.Drawing.Point(12, 173);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(162, 62);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar Boleteria";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // richTextBoxVentaElectronica
            // 
            this.richTextBoxVentaElectronica.Location = new System.Drawing.Point(208, 21);
            this.richTextBoxVentaElectronica.Name = "richTextBoxVentaElectronica";
            this.richTextBoxVentaElectronica.Size = new System.Drawing.Size(528, 261);
            this.richTextBoxVentaElectronica.TabIndex = 2;
            this.richTextBoxVentaElectronica.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ventas realizadas";
            // 
            // FrmBoleteriaElectronica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 294);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxVentaElectronica);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAbrir);
            this.Name = "FrmBoleteriaElectronica";
            this.Text = "Boletería Electrónica";
            this.Load += new System.EventHandler(this.FrmBoleteriaElectronica_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.RichTextBox richTextBoxVentaElectronica;
        private System.Windows.Forms.Label label1;
    }
}