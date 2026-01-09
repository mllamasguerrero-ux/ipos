namespace iPos
{
    partial class CorteAbrir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorteAbrir));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.NTSaldoInicial = new System.Windows.Forms.NumericTextBox();
            this.pnlFondoDinamico = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.NTBFondoInicial = new System.Windows.Forms.NumericTextBox();
            this.pnlFondoDinamico.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(66, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Saldo Inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(125, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ABRIR CORTE";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.BTEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTEnviar.Location = new System.Drawing.Point(113, 149);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(103, 30);
            this.BTEnviar.TabIndex = 2;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // NTSaldoInicial
            // 
            this.NTSaldoInicial.AllowNegative = true;
            this.NTSaldoInicial.Format_Expression = null;
            this.NTSaldoInicial.Location = new System.Drawing.Point(178, 54);
            this.NTSaldoInicial.Name = "NTSaldoInicial";
            this.NTSaldoInicial.NumericPrecision = 10;
            this.NTSaldoInicial.NumericScaleOnFocus = 2;
            this.NTSaldoInicial.NumericScaleOnLostFocus = 2;
            this.NTSaldoInicial.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NTSaldoInicial.Size = new System.Drawing.Size(122, 20);
            this.NTSaldoInicial.TabIndex = 1;
            this.NTSaldoInicial.Tag = 34;
            this.NTSaldoInicial.Text = "0";
            this.NTSaldoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NTSaldoInicial.ValidationExpression = null;
            this.NTSaldoInicial.ZeroIsValid = true;
            // 
            // pnlFondoDinamico
            // 
            this.pnlFondoDinamico.BackColor = System.Drawing.Color.Transparent;
            this.pnlFondoDinamico.Controls.Add(this.label1);
            this.pnlFondoDinamico.Controls.Add(this.NTBFondoInicial);
            this.pnlFondoDinamico.Location = new System.Drawing.Point(61, 80);
            this.pnlFondoDinamico.Name = "pnlFondoDinamico";
            this.pnlFondoDinamico.Size = new System.Drawing.Size(265, 44);
            this.pnlFondoDinamico.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fondo dinamico";
            // 
            // NTBFondoInicial
            // 
            this.NTBFondoInicial.AllowNegative = true;
            this.NTBFondoInicial.Enabled = false;
            this.NTBFondoInicial.Format_Expression = null;
            this.NTBFondoInicial.Location = new System.Drawing.Point(118, 9);
            this.NTBFondoInicial.Name = "NTBFondoInicial";
            this.NTBFondoInicial.NumericPrecision = 10;
            this.NTBFondoInicial.NumericScaleOnFocus = 2;
            this.NTBFondoInicial.NumericScaleOnLostFocus = 2;
            this.NTBFondoInicial.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NTBFondoInicial.Size = new System.Drawing.Size(122, 20);
            this.NTBFondoInicial.TabIndex = 4;
            this.NTBFondoInicial.Tag = 34;
            this.NTBFondoInicial.Text = "0";
            this.NTBFondoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NTBFondoInicial.ValidationExpression = null;
            this.NTBFondoInicial.ZeroIsValid = true;
            // 
            // CorteAbrir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(338, 191);
            this.Controls.Add(this.pnlFondoDinamico);
            this.Controls.Add(this.BTEnviar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NTSaldoInicial);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CorteAbrir";
            this.Text = "CorteAbrir";
            this.Load += new System.EventHandler(this.CorteAbrir_Load);
            this.pnlFondoDinamico.ResumeLayout(false);
            this.pnlFondoDinamico.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericTextBox NTSaldoInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.Panel pnlFondoDinamico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericTextBox NTBFondoInicial;
    }
}