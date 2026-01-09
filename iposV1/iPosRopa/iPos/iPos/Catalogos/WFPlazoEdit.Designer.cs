namespace iPos.Catalogos
{
    partial class WFPlazoEdit
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
            FirebirdSql.Data.FirebirdClient.FbParameter fbParameter1 = new FirebirdSql.Data.FirebirdClient.FbParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPlazoEdit));
            this.BTCancelar = new System.Windows.Forms.Button();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.ACTIVOLabel = new System.Windows.Forms.Label();
            this.NOMBRELabel = new System.Windows.Forms.Label();
            this.NOMBRETextBox = new System.Windows.Forms.TextBox();
            this.CLAVELabel = new System.Windows.Forms.Label();
            this.CLAVETextBox = new System.Windows.Forms.TextBox();
            this.cbComisionista = new System.Windows.Forms.CheckBox();
            this.lblComisionista = new System.Windows.Forms.Label();
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.txtLeyenda = new System.Windows.Forms.TextBox();
            this.RFV_CLAVE = new CustomValidation.RequiredFieldValidator();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.label1 = new System.Windows.Forms.Label();
            this.DIASTextBox = new System.Windows.Forms.NumericTextBox();
            this.pnlAlmacen = new System.Windows.Forms.Panel();
            this.ALMACENComboBox = new System.Windows.Forms.ComboBoxFB();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlAlmacen.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTCancelar
            // 
            this.BTCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelar.ForeColor = System.Drawing.Color.White;
            this.BTCancelar.Image = global::iPos.Properties.Resources.cancel_J;
            this.BTCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCancelar.Location = new System.Drawing.Point(215, 351);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(132, 30);
            this.BTCancelar.TabIndex = 56;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // BTIniciaEdicion
            // 
            this.BTIniciaEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTIniciaEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTIniciaEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIniciaEdicion.ForeColor = System.Drawing.Color.White;
            this.BTIniciaEdicion.Location = new System.Drawing.Point(3, 356);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(71, 23);
            this.BTIniciaEdicion.TabIndex = 55;
            this.BTIniciaEdicion.Text = "Editar";
            this.BTIniciaEdicion.UseVisualStyleBackColor = false;
            this.BTIniciaEdicion.Visible = false;
            this.BTIniciaEdicion.Click += new System.EventHandler(this.BTIniciaEdicion_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(81, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 29);
            this.button1.TabIndex = 54;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.ACTIVOTextBox);
            this.panel1.Controls.Add(this.ACTIVOLabel);
            this.panel1.Controls.Add(this.NOMBRELabel);
            this.panel1.Controls.Add(this.NOMBRETextBox);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(6, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 65);
            this.panel1.TabIndex = 53;
            this.panel1.TabStop = true;
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(100, 38);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ACTIVOTextBox.TabIndex = 5;
            this.ACTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // ACTIVOLabel
            // 
            this.ACTIVOLabel.AutoSize = true;
            this.ACTIVOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACTIVOLabel.ForeColor = System.Drawing.Color.White;
            this.ACTIVOLabel.Location = new System.Drawing.Point(41, 38);
            this.ACTIVOLabel.Name = "ACTIVOLabel";
            this.ACTIVOLabel.Size = new System.Drawing.Size(47, 13);
            this.ACTIVOLabel.TabIndex = 1;
            this.ACTIVOLabel.Text = "Activo:";
            // 
            // NOMBRELabel
            // 
            this.NOMBRELabel.AutoSize = true;
            this.NOMBRELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NOMBRELabel.ForeColor = System.Drawing.Color.White;
            this.NOMBRELabel.Location = new System.Drawing.Point(34, 6);
            this.NOMBRELabel.Name = "NOMBRELabel";
            this.NOMBRELabel.Size = new System.Drawing.Size(54, 13);
            this.NOMBRELabel.TabIndex = 1;
            this.NOMBRELabel.Text = "Nombre:";
            // 
            // NOMBRETextBox
            // 
            this.NOMBRETextBox.Location = new System.Drawing.Point(102, 3);
            this.NOMBRETextBox.Name = "NOMBRETextBox";
            this.NOMBRETextBox.Size = new System.Drawing.Size(218, 20);
            this.NOMBRETextBox.TabIndex = 2;
            // 
            // CLAVELabel
            // 
            this.CLAVELabel.AutoSize = true;
            this.CLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLAVELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLAVELabel.ForeColor = System.Drawing.Color.White;
            this.CLAVELabel.Location = new System.Drawing.Point(47, 34);
            this.CLAVELabel.Name = "CLAVELabel";
            this.CLAVELabel.Size = new System.Drawing.Size(43, 13);
            this.CLAVELabel.TabIndex = 51;
            this.CLAVELabel.Text = "Clave:";
            // 
            // CLAVETextBox
            // 
            this.CLAVETextBox.Location = new System.Drawing.Point(109, 31);
            this.CLAVETextBox.Name = "CLAVETextBox";
            this.CLAVETextBox.Size = new System.Drawing.Size(217, 20);
            this.CLAVETextBox.TabIndex = 52;
            this.CLAVETextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CLAVETextBox_Validating);
            // 
            // cbComisionista
            // 
            this.cbComisionista.AutoSize = true;
            this.cbComisionista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.cbComisionista.Location = new System.Drawing.Point(109, 170);
            this.cbComisionista.Name = "cbComisionista";
            this.cbComisionista.Size = new System.Drawing.Size(15, 14);
            this.cbComisionista.TabIndex = 7;
            this.cbComisionista.UseVisualStyleBackColor = false;
            this.cbComisionista.CheckedChanged += new System.EventHandler(this.cbComisionista_CheckedChanged);
            // 
            // lblComisionista
            // 
            this.lblComisionista.AutoSize = true;
            this.lblComisionista.BackColor = System.Drawing.Color.Transparent;
            this.lblComisionista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComisionista.ForeColor = System.Drawing.Color.White;
            this.lblComisionista.Location = new System.Drawing.Point(13, 170);
            this.lblComisionista.Name = "lblComisionista";
            this.lblComisionista.Size = new System.Drawing.Size(81, 13);
            this.lblComisionista.TabIndex = 6;
            this.lblComisionista.Text = "Comisionista:";
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.AutoSize = true;
            this.lblLeyenda.BackColor = System.Drawing.Color.Transparent;
            this.lblLeyenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeyenda.ForeColor = System.Drawing.Color.White;
            this.lblLeyenda.Location = new System.Drawing.Point(31, 239);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(59, 13);
            this.lblLeyenda.TabIndex = 57;
            this.lblLeyenda.Text = "Leyenda:";
            // 
            // txtLeyenda
            // 
            this.txtLeyenda.Location = new System.Drawing.Point(12, 255);
            this.txtLeyenda.Multiline = true;
            this.txtLeyenda.Name = "txtLeyenda";
            this.txtLeyenda.Size = new System.Drawing.Size(326, 81);
            this.txtLeyenda.TabIndex = 89;
            // 
            // RFV_CLAVE
            // 
            this.RFV_CLAVE.ControlToValidate = this.CLAVETextBox;
            this.RFV_CLAVE.Enabled = true;
            this.RFV_CLAVE.ErrorMessage = "Se requiere el campo CLAVE";
            this.RFV_CLAVE.Icon = null;
            // 
            // FbConnection1
            // 
            this.FbConnection1.ConnectionString = "Data Source=manuel;Initial Catalog=generador;Persist Security Info=True;User ID=s" +
    "a;Password=Twincept";
            // 
            // FbCommand1
            // 
            this.FbCommand1.CommandText = "select * from MARCA  where 1=1  and ID=@ID  and  1= 1 ";
            this.FbCommand1.CommandTimeout = 30;
            this.FbCommand1.Connection = this.FbConnection1;
            fbParameter1.FbDbType = FirebirdSql.Data.FirebirdClient.FbDbType.BigInt;
            fbParameter1.ParameterName = "@ID";
            this.FbCommand1.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
            fbParameter1});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(58, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 90;
            this.label1.Text = "Dias:";
            // 
            // DIASTextBox
            // 
            this.DIASTextBox.AllowNegative = true;
            this.DIASTextBox.Format_Expression = null;
            this.DIASTextBox.Location = new System.Drawing.Point(106, 135);
            this.DIASTextBox.Name = "DIASTextBox";
            this.DIASTextBox.NumericPrecision = 18;
            this.DIASTextBox.NumericScaleOnFocus = 0;
            this.DIASTextBox.NumericScaleOnLostFocus = 0;
            this.DIASTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DIASTextBox.Size = new System.Drawing.Size(100, 20);
            this.DIASTextBox.TabIndex = 91;
            this.DIASTextBox.Tag = "";
            this.DIASTextBox.Text = "0";
            this.DIASTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DIASTextBox.ValidationExpression = null;
            this.DIASTextBox.ZeroIsValid = true;
            // 
            // pnlAlmacen
            // 
            this.pnlAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.pnlAlmacen.Controls.Add(this.ALMACENComboBox);
            this.pnlAlmacen.Controls.Add(this.label2);
            this.pnlAlmacen.Location = new System.Drawing.Point(34, 203);
            this.pnlAlmacen.Name = "pnlAlmacen";
            this.pnlAlmacen.Size = new System.Drawing.Size(200, 29);
            this.pnlAlmacen.TabIndex = 177;
            // 
            // ALMACENComboBox
            // 
            this.ALMACENComboBox.Condicion = null;
            this.ALMACENComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENComboBox.DisplayMember = "nombre";
            this.ALMACENComboBox.FormattingEnabled = true;
            this.ALMACENComboBox.IndiceCampoSelector = 0;
            this.ALMACENComboBox.LabelDescription = null;
            this.ALMACENComboBox.Location = new System.Drawing.Point(66, 1);
            this.ALMACENComboBox.Name = "ALMACENComboBox";
            this.ALMACENComboBox.NombreCampoSelector = "id";
            this.ALMACENComboBox.Query = "select id,nombre from almacen";
            this.ALMACENComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENComboBox.SelectedDataDisplaying = null;
            this.ALMACENComboBox.SelectedDataValue = null;
            this.ALMACENComboBox.Size = new System.Drawing.Size(131, 21);
            this.ALMACENComboBox.TabIndex = 175;
            this.ALMACENComboBox.ValueMember = "id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 174;
            this.label2.Text = "Almacen:";
            // 
            // WFPlazoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(351, 411);
            this.Controls.Add(this.pnlAlmacen);
            this.Controls.Add(this.DIASTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLeyenda);
            this.Controls.Add(this.lblLeyenda);
            this.Controls.Add(this.cbComisionista);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.lblComisionista);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CLAVELabel);
            this.Controls.Add(this.CLAVETextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFPlazoEdit";
            this.Text = "Plazo";
            this.Load += new System.EventHandler(this.WFPlazoEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAlmacen.ResumeLayout(false);
            this.pnlAlmacen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.Button BTIniciaEdicion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ACTIVOTextBox;
        private System.Windows.Forms.Label ACTIVOLabel;
        private System.Windows.Forms.Label NOMBRELabel;
        private System.Windows.Forms.TextBox NOMBRETextBox;
        private System.Windows.Forms.Label CLAVELabel;
        private System.Windows.Forms.TextBox CLAVETextBox;
        private System.Windows.Forms.CheckBox cbComisionista;
        private System.Windows.Forms.Label lblComisionista;
        private System.Windows.Forms.Label lblLeyenda;
        private System.Windows.Forms.TextBox txtLeyenda;
        private CustomValidation.RequiredFieldValidator RFV_CLAVE;
        private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
        private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericTextBox DIASTextBox;
        private System.Windows.Forms.Panel pnlAlmacen;
        private System.Windows.Forms.ComboBoxFB ALMACENComboBox;
        private System.Windows.Forms.Label label2;
    }
}