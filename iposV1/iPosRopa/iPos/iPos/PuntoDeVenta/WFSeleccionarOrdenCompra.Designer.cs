namespace iPos.PuntoDeVenta
{
    partial class WFSeleccionarOrdenCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFSeleccionarOrdenCompra));
            this.txtOrdenCompra = new System.Windows.Forms.TextBox();
            this.btnGuardarOrdenCompra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOrdenCompra
            // 
            this.txtOrdenCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrdenCompra.Location = new System.Drawing.Point(50, 38);
            this.txtOrdenCompra.Name = "txtOrdenCompra";
            this.txtOrdenCompra.Size = new System.Drawing.Size(282, 26);
            this.txtOrdenCompra.TabIndex = 0;
            // 
            // btnGuardarOrdenCompra
            // 
            this.btnGuardarOrdenCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnGuardarOrdenCompra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGuardarOrdenCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarOrdenCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnGuardarOrdenCompra.ForeColor = System.Drawing.Color.White;
            this.btnGuardarOrdenCompra.Location = new System.Drawing.Point(149, 116);
            this.btnGuardarOrdenCompra.Name = "btnGuardarOrdenCompra";
            this.btnGuardarOrdenCompra.Size = new System.Drawing.Size(82, 30);
            this.btnGuardarOrdenCompra.TabIndex = 1;
            this.btnGuardarOrdenCompra.Text = "Guardar";
            this.btnGuardarOrdenCompra.UseVisualStyleBackColor = false;
            this.btnGuardarOrdenCompra.Click += new System.EventHandler(this.btnGuardarOrdenCompra_Click);
            // 
            // WFSeleccionarOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(376, 158);
            this.Controls.Add(this.btnGuardarOrdenCompra);
            this.Controls.Add(this.txtOrdenCompra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFSeleccionarOrdenCompra";
            this.Text = "Ingresar Orden de Compra";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOrdenCompra;
        private System.Windows.Forms.Button btnGuardarOrdenCompra;
    }
}