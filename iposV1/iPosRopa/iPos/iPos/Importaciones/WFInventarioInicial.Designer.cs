namespace iPos
{
    partial class WFInventarioInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFInventarioInicial));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TBInvInicial = new System.Windows.Forms.TextBox();
            this.BTInvInicial = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TBInvInicial
            // 
            this.TBInvInicial.Location = new System.Drawing.Point(21, 86);
            this.TBInvInicial.Name = "TBInvInicial";
            this.TBInvInicial.Size = new System.Drawing.Size(275, 20);
            this.TBInvInicial.TabIndex = 0;
            // 
            // BTInvInicial
            // 
            this.BTInvInicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTInvInicial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTInvInicial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTInvInicial.ForeColor = System.Drawing.Color.White;
            this.BTInvInicial.Image = global::iPos.Properties.Resources.searchNoBack_J;
            this.BTInvInicial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTInvInicial.Location = new System.Drawing.Point(305, 82);
            this.BTInvInicial.Name = "BTInvInicial";
            this.BTInvInicial.Size = new System.Drawing.Size(107, 28);
            this.BTInvInicial.TabIndex = 1;
            this.BTInvInicial.Text = "Explorar";
            this.BTInvInicial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTInvInicial.UseVisualStyleBackColor = false;
            this.BTInvInicial.Click += new System.EventHandler(this.BTInvInicial_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione el archivo:";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.BTEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTEnviar.Location = new System.Drawing.Point(158, 133);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(113, 35);
            this.BTEnviar.TabIndex = 3;
            this.BTEnviar.Text = "Cargar";
            this.BTEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(139, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Inventario inicial";
            // 
            // WFInventarioInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(424, 215);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTEnviar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTInvInicial);
            this.Controls.Add(this.TBInvInicial);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFInventarioInicial";
            this.Text = "Inventario Inicial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox TBInvInicial;
        private System.Windows.Forms.Button BTInvInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.Label label2;
    }
}