namespace iPos
{
    partial class WFDefineLoteImportado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFDefineLoteImportado));
            this.aduanaLabel = new System.Windows.Forms.Label();
            this.aduanaButton = new System.Windows.Forms.Button();
            this.aduanaTextBoxFb = new iPos.Tools.TextBoxFB();
            this.label4 = new System.Windows.Forms.Label();
            this.TBTipoCambio = new System.Windows.Forms.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.BTAsignar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DTP = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.TBLote = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // aduanaLabel
            // 
            this.aduanaLabel.AutoSize = true;
            this.aduanaLabel.BackColor = System.Drawing.Color.Transparent;
            this.aduanaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aduanaLabel.ForeColor = System.Drawing.Color.White;
            this.aduanaLabel.Location = new System.Drawing.Point(385, 124);
            this.aduanaLabel.Name = "aduanaLabel";
            this.aduanaLabel.Size = new System.Drawing.Size(19, 13);
            this.aduanaLabel.TabIndex = 170;
            this.aduanaLabel.Text = "...";
            // 
            // aduanaButton
            // 
            this.aduanaButton.BackColor = System.Drawing.Color.Transparent;
            this.aduanaButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.aduanaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aduanaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aduanaButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.aduanaButton.Location = new System.Drawing.Point(355, 121);
            this.aduanaButton.Name = "aduanaButton";
            this.aduanaButton.Size = new System.Drawing.Size(24, 23);
            this.aduanaButton.TabIndex = 169;
            this.aduanaButton.UseVisualStyleBackColor = false;
            this.aduanaButton.Click += new System.EventHandler(this.aduanaButton_Click);
            // 
            // aduanaTextBoxFb
            // 
            this.aduanaTextBoxFb.BotonLookUp = this.aduanaButton;
            this.aduanaTextBoxFb.Condicion = null;
            this.aduanaTextBoxFb.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.aduanaTextBoxFb.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.aduanaTextBoxFb.DbValue = null;
            this.aduanaTextBoxFb.Format_Expression = null;
            this.aduanaTextBoxFb.IndiceCampoDescripcion = 2;
            this.aduanaTextBoxFb.IndiceCampoSelector = 1;
            this.aduanaTextBoxFb.IndiceCampoValue = 0;
            this.aduanaTextBoxFb.LabelDescription = this.aduanaLabel;
            this.aduanaTextBoxFb.Location = new System.Drawing.Point(249, 121);
            this.aduanaTextBoxFb.Name = "aduanaTextBoxFb";
            this.aduanaTextBoxFb.NombreCampoSelector = "SAT_CLAVEADUANA";
            this.aduanaTextBoxFb.NombreCampoValue = "ID";
            this.aduanaTextBoxFb.Query = "SELECT ID, SAT_CLAVEADUANA, SAT_DESCRIPCION FROM SAT_ADUANA";
            this.aduanaTextBoxFb.QueryDeSeleccion = "SELECT ID, SAT_CLAVEADUANA, SAT_DESCRIPCION FROM SAT_ADUANA WHERE SAT_CLAVEADUANA" +
    " = @SAT_CLAVEADUANA";
            this.aduanaTextBoxFb.QueryPorDBValue = "SELECT ID, SAT_CLAVEADUANA, SAT_DESCRIPCION FROM SAT_ADUANA WHERE ID = @ID";
            this.aduanaTextBoxFb.Size = new System.Drawing.Size(100, 20);
            this.aduanaTextBoxFb.TabIndex = 168;
            this.aduanaTextBoxFb.Tag = 34;
            this.aduanaTextBoxFb.TextDescription = null;
            this.aduanaTextBoxFb.Titulo = null;
            this.aduanaTextBoxFb.ValidarEntrada = true;
            this.aduanaTextBoxFb.ValidationExpression = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(146, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 167;
            this.label4.Text = "Tipo de cambio:";
            // 
            // TBTipoCambio
            // 
            this.TBTipoCambio.AllowNegative = true;
            this.TBTipoCambio.Format_Expression = null;
            this.TBTipoCambio.Location = new System.Drawing.Point(249, 151);
            this.TBTipoCambio.Name = "TBTipoCambio";
            this.TBTipoCambio.NumericPrecision = 18;
            this.TBTipoCambio.NumericScaleOnFocus = 2;
            this.TBTipoCambio.NumericScaleOnLostFocus = 2;
            this.TBTipoCambio.NumericValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TBTipoCambio.Size = new System.Drawing.Size(100, 20);
            this.TBTipoCambio.TabIndex = 4;
            this.TBTipoCambio.Tag = 34;
            this.TBTipoCambio.Text = "1.00";
            this.TBTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBTipoCambio.ValidationExpression = null;
            this.TBTipoCambio.ZeroIsValid = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(190, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 165;
            this.label3.Text = "Aduana:";
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProducto.ForeColor = System.Drawing.Color.White;
            this.lblNombreProducto.Location = new System.Drawing.Point(173, 30);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(19, 13);
            this.lblNombreProducto.TabIndex = 163;
            this.lblNombreProducto.Text = "...";
            // 
            // BTAsignar
            // 
            this.BTAsignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTAsignar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.BTAsignar.ForeColor = System.Drawing.Color.White;
            this.BTAsignar.Location = new System.Drawing.Point(217, 192);
            this.BTAsignar.Name = "BTAsignar";
            this.BTAsignar.Size = new System.Drawing.Size(106, 28);
            this.BTAsignar.TabIndex = 5;
            this.BTAsignar.Text = "Asignar";
            this.BTAsignar.UseVisualStyleBackColor = false;
            this.BTAsignar.Click += new System.EventHandler(this.BTAsignar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(173, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Pedimento:";
            // 
            // DTP
            // 
            this.DTP.Location = new System.Drawing.Point(249, 88);
            this.DTP.Name = "DTP";
            this.DTP.Size = new System.Drawing.Size(200, 20);
            this.DTP.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(111, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Fecha de importacion:";
            // 
            // TBLote
            // 
            this.TBLote.Location = new System.Drawing.Point(249, 59);
            this.TBLote.Name = "TBLote";
            this.TBLote.Size = new System.Drawing.Size(100, 20);
            this.TBLote.TabIndex = 0;
            // 
            // WFDefineLoteImportado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(538, 232);
            this.Controls.Add(this.aduanaLabel);
            this.Controls.Add(this.aduanaButton);
            this.Controls.Add(this.aduanaTextBoxFb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBTipoCambio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNombreProducto);
            this.Controls.Add(this.BTAsignar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBLote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFDefineLoteImportado";
            this.Text = "Define lote importado";
            this.Load += new System.EventHandler(this.WFDefineLoteImportado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBLote;
        private System.Windows.Forms.DateTimePicker DTP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTAsignar;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericTextBox TBTipoCambio;
        private System.Windows.Forms.Label label4;
        private Tools.TextBoxFB aduanaTextBoxFb;
        private System.Windows.Forms.Button aduanaButton;
        private System.Windows.Forms.Label aduanaLabel;
    }
}