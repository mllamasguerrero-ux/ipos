namespace iPos.Inventario
{
    partial class WFIsInventarioCiclico
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
            this.label6 = new System.Windows.Forms.Label();
            this.BTContinuar = new System.Windows.Forms.Button();
            this.BTInventarioCiclico = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(85, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(238, 24);
            this.label6.TabIndex = 37;
            this.label6.Text = "Es un inventario ciclico?";
            // 
            // BTContinuar
            // 
            this.BTContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTContinuar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTContinuar.ForeColor = System.Drawing.Color.White;
            this.BTContinuar.Location = new System.Drawing.Point(291, 117);
            this.BTContinuar.Name = "BTContinuar";
            this.BTContinuar.Size = new System.Drawing.Size(184, 48);
            this.BTContinuar.TabIndex = 36;
            this.BTContinuar.Text = "No , si afectara el inventario";
            this.BTContinuar.UseVisualStyleBackColor = false;
            this.BTContinuar.Click += new System.EventHandler(this.BTContinuar_Click);
            // 
            // BTInventarioCiclico
            // 
            this.BTInventarioCiclico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTInventarioCiclico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTInventarioCiclico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTInventarioCiclico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTInventarioCiclico.ForeColor = System.Drawing.Color.White;
            this.BTInventarioCiclico.Location = new System.Drawing.Point(51, 117);
            this.BTInventarioCiclico.Name = "BTInventarioCiclico";
            this.BTInventarioCiclico.Size = new System.Drawing.Size(184, 48);
            this.BTInventarioCiclico.TabIndex = 38;
            this.BTInventarioCiclico.Text = "Si , si se utilizara solo como referencia";
            this.BTInventarioCiclico.UseVisualStyleBackColor = false;
            this.BTInventarioCiclico.Click += new System.EventHandler(this.BTInventarioCiclico_Click);
            // 
            // WFIsInventarioCiclico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(544, 251);
            this.Controls.Add(this.BTInventarioCiclico);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BTContinuar);
            this.Name = "WFIsInventarioCiclico";
            this.Text = "Es inventario ciclico";
            this.Load += new System.EventHandler(this.WFIsInventarioCiclico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BTContinuar;
        private System.Windows.Forms.Button BTInventarioCiclico;
    }
}