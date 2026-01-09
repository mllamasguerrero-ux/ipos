namespace iPos
{
    partial class WFSeleccionarTipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFSeleccionarTipo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBParcialProducto = new System.Windows.Forms.RadioButton();
            this.RBCompleto = new System.Windows.Forms.RadioButton();
            this.RBParcial = new System.Windows.Forms.RadioButton();
            this.BTContinuar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.RBParcialProducto);
            this.groupBox1.Controls.Add(this.RBCompleto);
            this.groupBox1.Controls.Add(this.RBParcial);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(24, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Inventario";
            // 
            // RBParcialProducto
            // 
            this.RBParcialProducto.AutoSize = true;
            this.RBParcialProducto.Location = new System.Drawing.Point(31, 56);
            this.RBParcialProducto.Name = "RBParcialProducto";
            this.RBParcialProducto.Size = new System.Drawing.Size(128, 17);
            this.RBParcialProducto.TabIndex = 2;
            this.RBParcialProducto.Text = "Parcial x producto";
            this.RBParcialProducto.UseVisualStyleBackColor = true;
            // 
            // RBCompleto
            // 
            this.RBCompleto.AutoSize = true;
            this.RBCompleto.Location = new System.Drawing.Point(31, 81);
            this.RBCompleto.Name = "RBCompleto";
            this.RBCompleto.Size = new System.Drawing.Size(77, 17);
            this.RBCompleto.TabIndex = 1;
            this.RBCompleto.Text = "Completo";
            this.RBCompleto.UseVisualStyleBackColor = true;
            // 
            // RBParcial
            // 
            this.RBParcial.AutoSize = true;
            this.RBParcial.Checked = true;
            this.RBParcial.Location = new System.Drawing.Point(31, 26);
            this.RBParcial.Name = "RBParcial";
            this.RBParcial.Size = new System.Drawing.Size(64, 17);
            this.RBParcial.TabIndex = 0;
            this.RBParcial.TabStop = true;
            this.RBParcial.Text = "Parcial";
            this.RBParcial.UseVisualStyleBackColor = true;
            // 
            // BTContinuar
            // 
            this.BTContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTContinuar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTContinuar.ForeColor = System.Drawing.Color.White;
            this.BTContinuar.Location = new System.Drawing.Point(256, 129);
            this.BTContinuar.Name = "BTContinuar";
            this.BTContinuar.Size = new System.Drawing.Size(87, 23);
            this.BTContinuar.TabIndex = 1;
            this.BTContinuar.Text = "Continuar";
            this.BTContinuar.UseVisualStyleBackColor = false;
            this.BTContinuar.Click += new System.EventHandler(this.BTContinuar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(375, 24);
            this.label6.TabIndex = 35;
            this.label6.Text = "Paso 2: Definición de tipo de inventario";
            // 
            // WFSeleccionarTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(381, 244);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BTContinuar);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFSeleccionarTipo";
            this.Text = "Seleccionar Tipo Inventario";
            this.Load += new System.EventHandler(this.WFSeleccionarTipo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBCompleto;
        private System.Windows.Forms.RadioButton RBParcial;
        private System.Windows.Forms.Button BTContinuar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton RBParcialProducto;
    }
}