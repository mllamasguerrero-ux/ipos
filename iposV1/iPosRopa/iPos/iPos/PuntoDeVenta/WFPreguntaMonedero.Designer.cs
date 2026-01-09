namespace iPos
{
    partial class WFPreguntaMonedero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPreguntaMonedero));
            this.TBMonedero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTContinue = new System.Windows.Forms.Button();
            this.BTVerSaldo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LBLSaldoActual = new System.Windows.Forms.Label();
            this.LBTextMonto = new System.Windows.Forms.Label();
            this.LblMontoAAplicar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LBTitulo = new System.Windows.Forms.Label();
            this.LBVigencia = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBMonedero
            // 
            this.TBMonedero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMonedero.Location = new System.Drawing.Point(11, 94);
            this.TBMonedero.Name = "TBMonedero";
            this.TBMonedero.Size = new System.Drawing.Size(289, 21);
            this.TBMonedero.TabIndex = 0;
            this.TBMonedero.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBMonedero_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese el numero de monedero del cliente ";
            // 
            // BTContinue
            // 
            this.BTContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTContinue.ForeColor = System.Drawing.Color.White;
            this.BTContinue.Location = new System.Drawing.Point(135, 210);
            this.BTContinue.Name = "BTContinue";
            this.BTContinue.Size = new System.Drawing.Size(75, 25);
            this.BTContinue.TabIndex = 2;
            this.BTContinue.Text = "Continuar";
            this.BTContinue.UseVisualStyleBackColor = false;
            this.BTContinue.Click += new System.EventHandler(this.BTContinue_Click);
            // 
            // BTVerSaldo
            // 
            this.BTVerSaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTVerSaldo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTVerSaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTVerSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTVerSaldo.ForeColor = System.Drawing.Color.White;
            this.BTVerSaldo.Location = new System.Drawing.Point(225, 121);
            this.BTVerSaldo.Name = "BTVerSaldo";
            this.BTVerSaldo.Size = new System.Drawing.Size(75, 25);
            this.BTVerSaldo.TabIndex = 3;
            this.BTVerSaldo.Text = "Ver saldo";
            this.BTVerSaldo.UseVisualStyleBackColor = false;
            this.BTVerSaldo.Visible = false;
            this.BTVerSaldo.Click += new System.EventHandler(this.BTVerSaldo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Saldo Actual:";
            // 
            // LBLSaldoActual
            // 
            this.LBLSaldoActual.AutoSize = true;
            this.LBLSaldoActual.BackColor = System.Drawing.Color.Transparent;
            this.LBLSaldoActual.ForeColor = System.Drawing.Color.White;
            this.LBLSaldoActual.Location = new System.Drawing.Point(132, 128);
            this.LBLSaldoActual.Name = "LBLSaldoActual";
            this.LBLSaldoActual.Size = new System.Drawing.Size(16, 13);
            this.LBLSaldoActual.TabIndex = 5;
            this.LBLSaldoActual.Text = "...";
            // 
            // LBTextMonto
            // 
            this.LBTextMonto.AutoSize = true;
            this.LBTextMonto.BackColor = System.Drawing.Color.Transparent;
            this.LBTextMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTextMonto.ForeColor = System.Drawing.Color.White;
            this.LBTextMonto.Location = new System.Drawing.Point(8, 153);
            this.LBTextMonto.Name = "LBTextMonto";
            this.LBTextMonto.Size = new System.Drawing.Size(103, 16);
            this.LBTextMonto.TabIndex = 6;
            this.LBTextMonto.Text = "Monto a aplicar:";
            // 
            // LblMontoAAplicar
            // 
            this.LblMontoAAplicar.AutoSize = true;
            this.LblMontoAAplicar.BackColor = System.Drawing.Color.Transparent;
            this.LblMontoAAplicar.ForeColor = System.Drawing.Color.White;
            this.LblMontoAAplicar.Location = new System.Drawing.Point(132, 153);
            this.LblMontoAAplicar.Name = "LblMontoAAplicar";
            this.LblMontoAAplicar.Size = new System.Drawing.Size(16, 13);
            this.LblMontoAAplicar.TabIndex = 7;
            this.LblMontoAAplicar.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "o deje en blanco si no tiene";
            // 
            // LBTitulo
            // 
            this.LBTitulo.AutoSize = true;
            this.LBTitulo.BackColor = System.Drawing.Color.Transparent;
            this.LBTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTitulo.ForeColor = System.Drawing.Color.White;
            this.LBTitulo.Location = new System.Drawing.Point(12, 19);
            this.LBTitulo.Name = "LBTitulo";
            this.LBTitulo.Size = new System.Drawing.Size(280, 15);
            this.LBTitulo.TabIndex = 9;
            this.LBTitulo.Text = "MONEDERO DE DONDE SE DESCONTARA";
            // 
            // LBVigencia
            // 
            this.LBVigencia.AutoSize = true;
            this.LBVigencia.BackColor = System.Drawing.Color.Transparent;
            this.LBVigencia.ForeColor = System.Drawing.Color.White;
            this.LBVigencia.Location = new System.Drawing.Point(131, 180);
            this.LBVigencia.Name = "LBVigencia";
            this.LBVigencia.Size = new System.Drawing.Size(16, 13);
            this.LBVigencia.TabIndex = 11;
            this.LBVigencia.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(46, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Vigencia:";
            // 
            // WFPreguntaMonedero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(345, 245);
            this.Controls.Add(this.LBVigencia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LBTitulo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblMontoAAplicar);
            this.Controls.Add(this.LBTextMonto);
            this.Controls.Add(this.LBLSaldoActual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTVerSaldo);
            this.Controls.Add(this.BTContinue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBMonedero);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFPreguntaMonedero";
            this.Text = "Pregunta Monedero";
            this.Load += new System.EventHandler(this.WFPreguntaMonedero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBMonedero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTContinue;
        private System.Windows.Forms.Button BTVerSaldo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBLSaldoActual;
        private System.Windows.Forms.Label LBTextMonto;
        private System.Windows.Forms.Label LblMontoAAplicar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBTitulo;
        private System.Windows.Forms.Label LBVigencia;
        private System.Windows.Forms.Label label6;
    }
}