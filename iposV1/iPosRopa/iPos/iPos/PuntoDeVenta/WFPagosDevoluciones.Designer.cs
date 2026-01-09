namespace iPos
{
    partial class WFPagosDevoluciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPagosDevoluciones));
            this.PA_ABONOTextBox = new System.Windows.Forms.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBPagosTotalVenta = new System.Windows.Forms.TextBox();
            this.PA_ABONOLabel = new System.Windows.Forms.Label();
            this.CBCreditoAutomatico = new System.Windows.Forms.CheckBox();
            this.BTPaymentSave = new System.Windows.Forms.Button();
            this.LBFaltante = new System.Windows.Forms.Label();
            this.CBFacturaElectronica = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.NOTAPAGOTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PA_ABONOTextBox
            // 
            this.PA_ABONOTextBox.AllowNegative = true;
            this.PA_ABONOTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PA_ABONOTextBox.Format_Expression = null;
            this.PA_ABONOTextBox.Location = new System.Drawing.Point(194, 52);
            this.PA_ABONOTextBox.Name = "PA_ABONOTextBox";
            this.PA_ABONOTextBox.NumericPrecision = 17;
            this.PA_ABONOTextBox.NumericScaleOnFocus = 2;
            this.PA_ABONOTextBox.NumericScaleOnLostFocus = 2;
            this.PA_ABONOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PA_ABONOTextBox.Size = new System.Drawing.Size(236, 29);
            this.PA_ABONOTextBox.TabIndex = 29;
            this.PA_ABONOTextBox.Tag = 34;
            this.PA_ABONOTextBox.Text = "0.00";
            this.PA_ABONOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PA_ABONOTextBox.ValidationExpression = null;
            this.PA_ABONOTextBox.ZeroIsValid = true;
            this.PA_ABONOTextBox.Validated += new System.EventHandler(this.PA_ABONOTextBox_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(117, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 32;
            this.label1.Text = "Total:";
            // 
            // TBPagosTotalVenta
            // 
            this.TBPagosTotalVenta.BackColor = System.Drawing.SystemColors.Window;
            this.TBPagosTotalVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPagosTotalVenta.ForeColor = System.Drawing.Color.Black;
            this.TBPagosTotalVenta.Location = new System.Drawing.Point(194, 17);
            this.TBPagosTotalVenta.Name = "TBPagosTotalVenta";
            this.TBPagosTotalVenta.ReadOnly = true;
            this.TBPagosTotalVenta.Size = new System.Drawing.Size(236, 29);
            this.TBPagosTotalVenta.TabIndex = 30;
            this.TBPagosTotalVenta.TabStop = false;
            this.TBPagosTotalVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PA_ABONOLabel
            // 
            this.PA_ABONOLabel.AutoSize = true;
            this.PA_ABONOLabel.BackColor = System.Drawing.Color.Transparent;
            this.PA_ABONOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PA_ABONOLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PA_ABONOLabel.Location = new System.Drawing.Point(89, 55);
            this.PA_ABONOLabel.Name = "PA_ABONOLabel";
            this.PA_ABONOLabel.Size = new System.Drawing.Size(90, 24);
            this.PA_ABONOLabel.TabIndex = 31;
            this.PA_ABONOLabel.Text = "Efectivo:";
            // 
            // CBCreditoAutomatico
            // 
            this.CBCreditoAutomatico.AutoSize = true;
            this.CBCreditoAutomatico.BackColor = System.Drawing.Color.Transparent;
            this.CBCreditoAutomatico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBCreditoAutomatico.ForeColor = System.Drawing.Color.White;
            this.CBCreditoAutomatico.Location = new System.Drawing.Point(194, 242);
            this.CBCreditoAutomatico.Name = "CBCreditoAutomatico";
            this.CBCreditoAutomatico.Size = new System.Drawing.Size(212, 17);
            this.CBCreditoAutomatico.TabIndex = 33;
            this.CBCreditoAutomatico.Text = "Aplicacion automatica de credito";
            this.CBCreditoAutomatico.UseVisualStyleBackColor = false;
            this.CBCreditoAutomatico.CheckedChanged += new System.EventHandler(this.CBCreditoAutomatico_CheckedChanged);
            // 
            // BTPaymentSave
            // 
            this.BTPaymentSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTPaymentSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTPaymentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTPaymentSave.ForeColor = System.Drawing.Color.White;
            this.BTPaymentSave.Location = new System.Drawing.Point(195, 295);
            this.BTPaymentSave.Name = "BTPaymentSave";
            this.BTPaymentSave.Size = new System.Drawing.Size(214, 33);
            this.BTPaymentSave.TabIndex = 34;
            this.BTPaymentSave.Text = "Guardar pago (F10)";
            this.BTPaymentSave.UseVisualStyleBackColor = false;
            this.BTPaymentSave.Click += new System.EventHandler(this.BTPaymentSave_Click);
            // 
            // LBFaltante
            // 
            this.LBFaltante.AutoSize = true;
            this.LBFaltante.BackColor = System.Drawing.Color.Transparent;
            this.LBFaltante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBFaltante.ForeColor = System.Drawing.Color.White;
            this.LBFaltante.Location = new System.Drawing.Point(30, 206);
            this.LBFaltante.Name = "LBFaltante";
            this.LBFaltante.Size = new System.Drawing.Size(16, 16);
            this.LBFaltante.TabIndex = 37;
            this.LBFaltante.Text = "_";
            // 
            // CBFacturaElectronica
            // 
            this.CBFacturaElectronica.AutoSize = true;
            this.CBFacturaElectronica.BackColor = System.Drawing.Color.Transparent;
            this.CBFacturaElectronica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFacturaElectronica.ForeColor = System.Drawing.Color.White;
            this.CBFacturaElectronica.Location = new System.Drawing.Point(194, 265);
            this.CBFacturaElectronica.Name = "CBFacturaElectronica";
            this.CBFacturaElectronica.Size = new System.Drawing.Size(182, 17);
            this.CBFacturaElectronica.TabIndex = 47;
            this.CBFacturaElectronica.Text = "Generar factura electronica";
            this.CBFacturaElectronica.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(37, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 24);
            this.label13.TabIndex = 91;
            this.label13.Text = "Observaciones:";
            // 
            // NOTAPAGOTextBox
            // 
            this.NOTAPAGOTextBox.Location = new System.Drawing.Point(195, 87);
            this.NOTAPAGOTextBox.Multiline = true;
            this.NOTAPAGOTextBox.Name = "NOTAPAGOTextBox";
            this.NOTAPAGOTextBox.Size = new System.Drawing.Size(360, 103);
            this.NOTAPAGOTextBox.TabIndex = 90;
            // 
            // WFPagosDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(607, 350);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.NOTAPAGOTextBox);
            this.Controls.Add(this.CBFacturaElectronica);
            this.Controls.Add(this.LBFaltante);
            this.Controls.Add(this.BTPaymentSave);
            this.Controls.Add(this.CBCreditoAutomatico);
            this.Controls.Add(this.PA_ABONOTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBPagosTotalVenta);
            this.Controls.Add(this.PA_ABONOLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "WFPagosDevoluciones";
            this.Text = "Aplicacion Devoluciones";
            this.Load += new System.EventHandler(this.WFPagosBasico_Load);
            this.Shown += new System.EventHandler(this.WFPagosBasico_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WFPagosBasico_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericTextBox PA_ABONOTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBPagosTotalVenta;
        private System.Windows.Forms.Label PA_ABONOLabel;
        private System.Windows.Forms.CheckBox CBCreditoAutomatico;
        private System.Windows.Forms.Button BTPaymentSave;
        private System.Windows.Forms.Label LBFaltante;
        private System.Windows.Forms.CheckBox CBFacturaElectronica;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox NOTAPAGOTextBox;
    }
}