namespace iPos.Utilerias.Ajustes_catálogos_SAT
{
    partial class WFEditarClaveProductoSat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFEditarClaveProductoSat));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.exportarButton = new System.Windows.Forms.Button();
            this.importarButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // exportarButton
            // 
            this.exportarButton.BackColor = System.Drawing.Color.Firebrick;
            this.exportarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportarButton.ForeColor = System.Drawing.Color.White;
            this.exportarButton.Location = new System.Drawing.Point(434, 127);
            this.exportarButton.Name = "exportarButton";
            this.exportarButton.Size = new System.Drawing.Size(119, 90);
            this.exportarButton.TabIndex = 188;
            this.exportarButton.Text = "Exportar";
            this.exportarButton.UseVisualStyleBackColor = false;
            this.exportarButton.Click += new System.EventHandler(this.exportarButton_Click);
            // 
            // importarButton
            // 
            this.importarButton.BackColor = System.Drawing.Color.DarkGreen;
            this.importarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importarButton.ForeColor = System.Drawing.Color.White;
            this.importarButton.Location = new System.Drawing.Point(85, 127);
            this.importarButton.Name = "importarButton";
            this.importarButton.Size = new System.Drawing.Size(124, 90);
            this.importarButton.TabIndex = 189;
            this.importarButton.Text = "Importar";
            this.importarButton.UseVisualStyleBackColor = false;
            this.importarButton.Click += new System.EventHandler(this.importarButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // WFEditarClaveProductoSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(630, 316);
            this.Controls.Add(this.importarButton);
            this.Controls.Add(this.exportarButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFEditarClaveProductoSat";
            this.Text = "Editar Clave SAT de Productos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button exportarButton;
        private System.Windows.Forms.Button importarButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}