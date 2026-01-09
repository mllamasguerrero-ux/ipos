namespace iPos
{
    partial class WFDefineLoteYCantidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFDefineLoteYCantidad));
            this.TBLote = new System.Windows.Forms.TextBox();
            this.DTP = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTAsignar = new System.Windows.Forms.Button();
            this.TBCantidad = new System.Windows.Forms.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBLote
            // 
            this.TBLote.Location = new System.Drawing.Point(163, 24);
            this.TBLote.Name = "TBLote";
            this.TBLote.Size = new System.Drawing.Size(100, 20);
            this.TBLote.TabIndex = 0;
            // 
            // DTP
            // 
            this.DTP.Location = new System.Drawing.Point(163, 53);
            this.DTP.Name = "DTP";
            this.DTP.Size = new System.Drawing.Size(200, 20);
            this.DTP.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Fecha de vencimiento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(125, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Lote:";
            // 
            // BTAsignar
            // 
            this.BTAsignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTAsignar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.BTAsignar.ForeColor = System.Drawing.Color.White;
            this.BTAsignar.Location = new System.Drawing.Point(146, 106);
            this.BTAsignar.Name = "BTAsignar";
            this.BTAsignar.Size = new System.Drawing.Size(90, 26);
            this.BTAsignar.TabIndex = 162;
            this.BTAsignar.Text = "Asignar";
            this.BTAsignar.UseVisualStyleBackColor = false;
            this.BTAsignar.Click += new System.EventHandler(this.BTAsignar_Click);
            // 
            // TBCantidad
            // 
            this.TBCantidad.AllowNegative = false;
            this.TBCantidad.Format_Expression = null;
            this.TBCantidad.Location = new System.Drawing.Point(163, 79);
            this.TBCantidad.Name = "TBCantidad";
            this.TBCantidad.NumericPrecision = 10;
            this.TBCantidad.NumericScaleOnFocus = 2;
            this.TBCantidad.NumericScaleOnLostFocus = 2;
            this.TBCantidad.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBCantidad.Size = new System.Drawing.Size(157, 20);
            this.TBCantidad.TabIndex = 163;
            this.TBCantidad.Tag = 34;
            this.TBCantidad.Text = "0";
            this.TBCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBCantidad.ValidationExpression = null;
            this.TBCantidad.ZeroIsValid = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(100, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 164;
            this.label3.Text = "Cantidad:";
            // 
            // WFDefineLoteYCantidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(387, 144);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBCantidad);
            this.Controls.Add(this.BTAsignar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBLote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFDefineLoteYCantidad";
            this.Text = "Define lote";
            this.Load += new System.EventHandler(this.WFDefineLoteYCantidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBLote;
        private System.Windows.Forms.DateTimePicker DTP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTAsignar;
        private System.Windows.Forms.NumericTextBox TBCantidad;
        private System.Windows.Forms.Label label3;
    }
}