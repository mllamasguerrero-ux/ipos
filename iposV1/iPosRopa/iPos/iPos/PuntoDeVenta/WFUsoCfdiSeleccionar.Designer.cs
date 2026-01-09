namespace iPos.PuntoDeVenta
{
    partial class WFUsoCfdiSeleccionar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFUsoCfdiSeleccionar));
            this.USOCFDITextBox = new System.Windows.Forms.ComboBoxFB();
            this.USOCFDILabel = new System.Windows.Forms.Label();
            this.BTPaymentSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // USOCFDITextBox
            // 
            this.USOCFDITextBox.Condicion = null;
            this.USOCFDITextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.USOCFDITextBox.DisplayMember = "sat_descripcion";
            this.USOCFDITextBox.FormattingEnabled = true;
            this.USOCFDITextBox.IndiceCampoSelector = 0;
            this.USOCFDITextBox.LabelDescription = null;
            this.USOCFDITextBox.Location = new System.Drawing.Point(79, 101);
            this.USOCFDITextBox.Name = "USOCFDITextBox";
            this.USOCFDITextBox.NombreCampoSelector = "id";
            this.USOCFDITextBox.Query = resources.GetString("USOCFDITextBox.Query");
            this.USOCFDITextBox.QueryDeSeleccion = resources.GetString("USOCFDITextBox.QueryDeSeleccion");
            this.USOCFDITextBox.SelectedDataDisplaying = null;
            this.USOCFDITextBox.SelectedDataValue = null;
            this.USOCFDITextBox.Size = new System.Drawing.Size(227, 21);
            this.USOCFDITextBox.TabIndex = 210;
            this.USOCFDITextBox.ValueMember = "id";
            // 
            // USOCFDILabel
            // 
            this.USOCFDILabel.AutoSize = true;
            this.USOCFDILabel.BackColor = System.Drawing.Color.Transparent;
            this.USOCFDILabel.ForeColor = System.Drawing.Color.White;
            this.USOCFDILabel.Location = new System.Drawing.Point(76, 86);
            this.USOCFDILabel.Name = "USOCFDILabel";
            this.USOCFDILabel.Size = new System.Drawing.Size(59, 13);
            this.USOCFDILabel.TabIndex = 209;
            this.USOCFDILabel.Text = "Uso CFDI: ";
            // 
            // BTPaymentSave
            // 
            this.BTPaymentSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTPaymentSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTPaymentSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTPaymentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTPaymentSave.ForeColor = System.Drawing.Color.White;
            this.BTPaymentSave.Location = new System.Drawing.Point(123, 148);
            this.BTPaymentSave.Name = "BTPaymentSave";
            this.BTPaymentSave.Size = new System.Drawing.Size(166, 33);
            this.BTPaymentSave.TabIndex = 211;
            this.BTPaymentSave.Text = "Seleccionar Cfdi";
            this.BTPaymentSave.UseVisualStyleBackColor = false;
            this.BTPaymentSave.Click += new System.EventHandler(this.BTPaymentSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 13);
            this.label1.TabIndex = 212;
            this.label1.Text = "Seleccione el uso de cfdi para la facturacion electronica ";
            // 
            // WFUsoCfdiSeleccionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(426, 211);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTPaymentSave);
            this.Controls.Add(this.USOCFDITextBox);
            this.Controls.Add(this.USOCFDILabel);
            this.Name = "WFUsoCfdiSeleccionar";
            this.Text = "Seleccionar uso de cfdi";
            this.Load += new System.EventHandler(this.WFUsoCfdiSeleccionar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBoxFB USOCFDITextBox;
        private System.Windows.Forms.Label USOCFDILabel;
        private System.Windows.Forms.Button BTPaymentSave;
        private System.Windows.Forms.Label label1;
    }
}