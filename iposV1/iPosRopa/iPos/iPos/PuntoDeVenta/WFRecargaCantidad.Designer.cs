namespace iPos
{
    partial class WFRecargaCantidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFRecargaCantidad));
            this.TBCantidad = new System.Windows.Forms.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CBCompania = new System.Windows.Forms.ComboBox();
            this.lblCompania = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBCantidad
            // 
            this.TBCantidad.AllowNegative = true;
            this.TBCantidad.BackColor = System.Drawing.Color.White;
            this.TBCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCantidad.Format_Expression = null;
            this.TBCantidad.Location = new System.Drawing.Point(125, 51);
            this.TBCantidad.Name = "TBCantidad";
            this.TBCantidad.NumericPrecision = 10;
            this.TBCantidad.NumericScaleOnFocus = 3;
            this.TBCantidad.NumericScaleOnLostFocus = 3;
            this.TBCantidad.NumericValue = new decimal(new int[] {
            1000,
            0,
            0,
            196608});
            this.TBCantidad.Size = new System.Drawing.Size(204, 26);
            this.TBCantidad.TabIndex = 9;
            this.TBCantidad.Tag = 34;
            this.TBCantidad.Text = "1.000";
            this.TBCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBCantidad.ValidationExpression = null;
            this.TBCantidad.ZeroIsValid = true;
            this.TBCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBCantidad_KeyDown);
            this.TBCantidad.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBCantidad_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(30, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Cantidad:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(148, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CBCompania
            // 
            this.CBCompania.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBCompania.FormattingEnabled = true;
            this.CBCompania.Items.AddRange(new object[] {
            "Movistar",
            "Iusacell",
            "Unefon",
            "Nextel",
            "Telcel",
            "Virgin",
            "At&t"});
            this.CBCompania.Location = new System.Drawing.Point(125, 80);
            this.CBCompania.Name = "CBCompania";
            this.CBCompania.Size = new System.Drawing.Size(204, 25);
            this.CBCompania.TabIndex = 13;
            // 
            // lblCompania
            // 
            this.lblCompania.AutoSize = true;
            this.lblCompania.BackColor = System.Drawing.Color.Transparent;
            this.lblCompania.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompania.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCompania.Location = new System.Drawing.Point(18, 81);
            this.lblCompania.Name = "lblCompania";
            this.lblCompania.Size = new System.Drawing.Size(101, 24);
            this.lblCompania.TabIndex = 12;
            this.lblCompania.Text = "Compañia:";
            // 
            // WFRecargaCantidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(374, 205);
            this.Controls.Add(this.CBCompania);
            this.Controls.Add(this.lblCompania);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBCantidad);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFRecargaCantidad";
            this.Text = "Cantidad";
            this.Load += new System.EventHandler(this.WFRecargaCantidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericTextBox TBCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CBCompania;
        private System.Windows.Forms.Label lblCompania;
    }
}