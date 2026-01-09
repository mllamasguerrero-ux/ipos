namespace iPos
{
    partial class WFCambioVenceTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFCambioVenceTrans));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.lbTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbSaldo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaVence = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.diasPlazoTextBox = new System.Windows.Forms.NumericTextBox();
            this.BTSeleccionar = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.TBFolio = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.btnCambiar);
            this.groupBox1.Controls.Add(this.lbTotal);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbSaldo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpFechaVence);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.diasPlazoTextBox);
            this.groupBox1.Controls.Add(this.BTSeleccionar);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.TBFolio);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transacciones";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Location = new System.Drawing.Point(397, 93);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(232, 20);
            this.dtpFecha.TabIndex = 14;
            // 
            // btnCambiar
            // 
            this.btnCambiar.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnCambiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiar.Location = new System.Drawing.Point(643, 60);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(85, 35);
            this.btnCambiar.TabIndex = 13;
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.UseVisualStyleBackColor = false;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(64, 93);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(19, 13);
            this.lbTotal.TabIndex = 12;
            this.lbTotal.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total:";
            // 
            // lbSaldo
            // 
            this.lbSaldo.AutoSize = true;
            this.lbSaldo.Location = new System.Drawing.Point(260, 93);
            this.lbSaldo.Name = "lbSaldo";
            this.lbSaldo.Size = new System.Drawing.Size(19, 13);
            this.lbSaldo.TabIndex = 10;
            this.lbSaldo.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Saldo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Vence:";
            // 
            // dtpFechaVence
            // 
            this.dtpFechaVence.Enabled = false;
            this.dtpFechaVence.Location = new System.Drawing.Point(397, 46);
            this.dtpFechaVence.Name = "dtpFechaVence";
            this.dtpFechaVence.Size = new System.Drawing.Size(232, 20);
            this.dtpFechaVence.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dias plazo:";
            // 
            // diasPlazoTextBox
            // 
            this.diasPlazoTextBox.AllowNegative = true;
            this.diasPlazoTextBox.Format_Expression = null;
            this.diasPlazoTextBox.Location = new System.Drawing.Point(283, 45);
            this.diasPlazoTextBox.Name = "diasPlazoTextBox";
            this.diasPlazoTextBox.NumericPrecision = 5;
            this.diasPlazoTextBox.NumericScaleOnFocus = 0;
            this.diasPlazoTextBox.NumericScaleOnLostFocus = 0;
            this.diasPlazoTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.diasPlazoTextBox.Size = new System.Drawing.Size(58, 20);
            this.diasPlazoTextBox.TabIndex = 5;
            this.diasPlazoTextBox.Tag = 34;
            this.diasPlazoTextBox.Text = "0";
            this.diasPlazoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.diasPlazoTextBox.ValidationExpression = null;
            this.diasPlazoTextBox.ZeroIsValid = false;
            this.diasPlazoTextBox.Validated += new System.EventHandler(this.diasPlazoTextBox_Validated);
            // 
            // BTSeleccionar
            // 
            this.BTSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTSeleccionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSeleccionar.Location = new System.Drawing.Point(163, 43);
            this.BTSeleccionar.Name = "BTSeleccionar";
            this.BTSeleccionar.Size = new System.Drawing.Size(34, 23);
            this.BTSeleccionar.TabIndex = 3;
            this.BTSeleccionar.Text = "...";
            this.BTSeleccionar.UseVisualStyleBackColor = false;
            this.BTSeleccionar.Click += new System.EventHandler(this.BTSeleccionar_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(22, 48);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(38, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Folio:";
            // 
            // TBFolio
            // 
            this.TBFolio.Location = new System.Drawing.Point(62, 45);
            this.TBFolio.Name = "TBFolio";
            this.TBFolio.Size = new System.Drawing.Size(95, 20);
            this.TBFolio.TabIndex = 2;
            this.TBFolio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBFolio_KeyUp);
            this.TBFolio.Leave += new System.EventHandler(this.TBFolio_Leave);
            this.TBFolio.Validated += new System.EventHandler(this.TBFolio_Validated);
            // 
            // WFCambioVenceTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(754, 171);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFCambioVenceTrans";
            this.Text = "Cambiar fecha vence";
            this.Load += new System.EventHandler(this.WFCambioVenceTrans_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTSeleccionar;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox TBFolio;
        private System.Windows.Forms.NumericTextBox diasPlazoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaVence;
        private System.Windows.Forms.Label lbSaldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}