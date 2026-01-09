namespace iPos.Utilerias.Procesos
{
    partial class WFBloquearClientesVentasVencidas
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DiasNumericTextBox = new System.Windows.Forms.NumericUpDown();
            this.BTEnviar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DiasNumericTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bloqueo de clientes con ventas vencidas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(49, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Por mas de: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(184, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "dias";
            // 
            // DiasNumericTextBox
            // 
            this.DiasNumericTextBox.Location = new System.Drawing.Point(133, 101);
            this.DiasNumericTextBox.Name = "DiasNumericTextBox";
            this.DiasNumericTextBox.Size = new System.Drawing.Size(45, 20);
            this.DiasNumericTextBox.TabIndex = 3;
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.SystemColors.Highlight;
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTEnviar.Location = new System.Drawing.Point(108, 155);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(122, 30);
            this.BTEnviar.TabIndex = 9;
            this.BTEnviar.Text = "Bloquear";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // WFBloquearClientesVentasVencidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.FONDO_IPOS_SIN_LOGO;
            this.ClientSize = new System.Drawing.Size(425, 287);
            this.Controls.Add(this.BTEnviar);
            this.Controls.Add(this.DiasNumericTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WFBloquearClientesVentasVencidas";
            this.Text = "Bloquear clientes ventas vencidas";
            ((System.ComponentModel.ISupportInitialize)(this.DiasNumericTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown DiasNumericTextBox;
        private System.Windows.Forms.Button BTEnviar;
    }
}