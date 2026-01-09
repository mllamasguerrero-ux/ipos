namespace iPos
{
    partial class WFDialogCajaPza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFDialogCajaPza));
            this.TBCantidad = new System.Windows.Forms.NumericTextBox();
            this.TBCajas = new System.Windows.Forms.NumericTextBox();
            this.lblCajas = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPzaCaja = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBCantidad
            // 
            this.TBCantidad.AllowNegative = true;
            this.TBCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCantidad.Format_Expression = null;
            this.TBCantidad.Location = new System.Drawing.Point(169, 54);
            this.TBCantidad.Name = "TBCantidad";
            this.TBCantidad.NumericPrecision = 12;
            this.TBCantidad.NumericScaleOnFocus = 2;
            this.TBCantidad.NumericScaleOnLostFocus = 2;
            this.TBCantidad.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBCantidad.Size = new System.Drawing.Size(76, 24);
            this.TBCantidad.TabIndex = 6;
            this.TBCantidad.Tag = 34;
            this.TBCantidad.Text = "0.00";
            this.TBCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBCantidad.ValidationExpression = null;
            this.TBCantidad.ZeroIsValid = true;
            // 
            // TBCajas
            // 
            this.TBCajas.AllowNegative = true;
            this.TBCajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBCajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCajas.Format_Expression = null;
            this.TBCajas.Location = new System.Drawing.Point(89, 54);
            this.TBCajas.Name = "TBCajas";
            this.TBCajas.NumericPrecision = 12;
            this.TBCajas.NumericScaleOnFocus = 2;
            this.TBCajas.NumericScaleOnLostFocus = 2;
            this.TBCajas.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBCajas.Size = new System.Drawing.Size(76, 24);
            this.TBCajas.TabIndex = 5;
            this.TBCajas.Tag = 34;
            this.TBCajas.Text = "0.00";
            this.TBCajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBCajas.ValidationExpression = null;
            this.TBCajas.ZeroIsValid = true;
            // 
            // lblCajas
            // 
            this.lblCajas.AutoSize = true;
            this.lblCajas.BackColor = System.Drawing.Color.Transparent;
            this.lblCajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCajas.ForeColor = System.Drawing.Color.White;
            this.lblCajas.Location = new System.Drawing.Point(86, 38);
            this.lblCajas.Name = "lblCajas";
            this.lblCajas.Size = new System.Drawing.Size(38, 13);
            this.lblCajas.TabIndex = 37;
            this.lblCajas.Text = "Cajas";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.White;
            this.lblCantidad.Location = new System.Drawing.Point(166, 38);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 36;
            this.lblCantidad.Text = "Botellas";
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(136, 97);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(69, 28);
            this.btnEnviar.TabIndex = 38;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(166, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Piezas por caja:";
            // 
            // lbPzaCaja
            // 
            this.lbPzaCaja.AutoSize = true;
            this.lbPzaCaja.BackColor = System.Drawing.Color.Transparent;
            this.lbPzaCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPzaCaja.ForeColor = System.Drawing.Color.White;
            this.lbPzaCaja.Location = new System.Drawing.Point(270, 10);
            this.lbPzaCaja.Name = "lbPzaCaja";
            this.lbPzaCaja.Size = new System.Drawing.Size(19, 13);
            this.lbPzaCaja.TabIndex = 40;
            this.lbPzaCaja.Text = "...";
            // 
            // WFDialogCajaPza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(350, 156);
            this.Controls.Add(this.lbPzaCaja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.lblCajas);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.TBCantidad);
            this.Controls.Add(this.TBCajas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFDialogCajaPza";
            this.Text = "Dialog Caja Pza";
            this.Load += new System.EventHandler(this.WFDialogCajaPza_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericTextBox TBCantidad;
        private System.Windows.Forms.NumericTextBox TBCajas;
        private System.Windows.Forms.Label lblCajas;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPzaCaja;
    }
}