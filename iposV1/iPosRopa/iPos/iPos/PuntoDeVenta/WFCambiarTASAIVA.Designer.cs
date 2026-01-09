namespace iPos
{
    partial class WFCambiarTASAIVA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFCambiarTASAIVA));
            this.label11 = new System.Windows.Forms.Label();
            this.TBTASAIVA = new System.Windows.Forms.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(233, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "%";
            // 
            // TBTASAIVA
            // 
            this.TBTASAIVA.AllowNegative = true;
            this.TBTASAIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTASAIVA.Format_Expression = null;
            this.TBTASAIVA.Location = new System.Drawing.Point(175, 21);
            this.TBTASAIVA.Name = "TBTASAIVA";
            this.TBTASAIVA.NumericPrecision = 4;
            this.TBTASAIVA.NumericScaleOnFocus = 2;
            this.TBTASAIVA.NumericScaleOnLostFocus = 2;
            this.TBTASAIVA.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBTASAIVA.Size = new System.Drawing.Size(52, 26);
            this.TBTASAIVA.TabIndex = 26;
            this.TBTASAIVA.Tag = 34;
            this.TBTASAIVA.Text = "0";
            this.TBTASAIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBTASAIVA.ValidationExpression = null;
            this.TBTASAIVA.ZeroIsValid = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(67, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "TASA IVA:";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(122, 65);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(77, 24);
            this.BTEnviar.TabIndex = 29;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // WFCambiarTASAIVA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(307, 101);
            this.Controls.Add(this.BTEnviar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TBTASAIVA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFCambiarTASAIVA";
            this.Text = "Cambiar tasa iva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericTextBox TBTASAIVA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTEnviar;
    }
}