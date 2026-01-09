namespace iPos.PuntoDeVenta
{
    partial class WFTipoCotizacionTope
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsiderandoTopes = new System.Windows.Forms.Button();
            this.btnSinTopes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esta venta tiene descuentos por rebaja, que tipo de impresion de cotizacion desea" +
    "?";
            // 
            // btnConsiderandoTopes
            // 
            this.btnConsiderandoTopes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnConsiderandoTopes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnConsiderandoTopes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsiderandoTopes.ForeColor = System.Drawing.Color.White;
            this.btnConsiderandoTopes.Location = new System.Drawing.Point(102, 91);
            this.btnConsiderandoTopes.Name = "btnConsiderandoTopes";
            this.btnConsiderandoTopes.Size = new System.Drawing.Size(175, 23);
            this.btnConsiderandoTopes.TabIndex = 205;
            this.btnConsiderandoTopes.Text = "Con topes";
            this.btnConsiderandoTopes.UseVisualStyleBackColor = false;
            this.btnConsiderandoTopes.Click += new System.EventHandler(this.btnConsiderandoTopes_Click);
            // 
            // btnSinTopes
            // 
            this.btnSinTopes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnSinTopes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSinTopes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSinTopes.ForeColor = System.Drawing.Color.White;
            this.btnSinTopes.Location = new System.Drawing.Point(312, 91);
            this.btnSinTopes.Name = "btnSinTopes";
            this.btnSinTopes.Size = new System.Drawing.Size(199, 23);
            this.btnSinTopes.TabIndex = 206;
            this.btnSinTopes.Text = "Precios netos";
            this.btnSinTopes.UseVisualStyleBackColor = false;
            this.btnSinTopes.Click += new System.EventHandler(this.btnSinTopes_Click);
            // 
            // WFTipoCotizacionTope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(538, 159);
            this.Controls.Add(this.btnSinTopes);
            this.Controls.Add(this.btnConsiderandoTopes);
            this.Controls.Add(this.label1);
            this.Name = "WFTipoCotizacionTope";
            this.Text = "WFTipoCotizacionTope";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsiderandoTopes;
        private System.Windows.Forms.Button btnSinTopes;
    }
}