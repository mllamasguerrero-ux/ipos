
namespace iPos
{
    partial class WFGastoEdit
    {
      
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

       
        private void InitializeComponent()
        {
            FirebirdSql.Data.FirebirdClient.FbParameter fbParameter1 = new FirebirdSql.Data.FirebirdClient.FbParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFGastoEdit));
            this.RFV_CLAVE = new CustomValidation.RequiredFieldValidator();
            this.CLAVETextBox = new System.Windows.Forms.TextBox();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CUENTAIDButton = new System.Windows.Forms.Button();
            this.CUENTAIDTextBox = new iPos.Tools.TextBoxFB();
            this.CUENTAIDLabel = new System.Windows.Forms.Label();
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.ACTIVOLabel = new System.Windows.Forms.Label();
            this.NOMBRELabel = new System.Windows.Forms.Label();
            this.NOMBRETextBox = new System.Windows.Forms.TextBox();
            this.CLAVELabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TIPOGASTOIDTextBox = new System.Windows.Forms.ComboBoxFB();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RFV_CLAVE
            // 
            this.RFV_CLAVE.ControlToValidate = this.CLAVETextBox;
            this.RFV_CLAVE.Enabled = true;
            this.RFV_CLAVE.ErrorMessage = "Se requiere el campo CLAVE";
            this.RFV_CLAVE.Icon = null;
            // 
            // CLAVETextBox
            // 
            this.CLAVETextBox.Location = new System.Drawing.Point(151, 17);
            this.CLAVETextBox.Name = "CLAVETextBox";
            this.CLAVETextBox.Size = new System.Drawing.Size(204, 20);
            this.CLAVETextBox.TabIndex = 1;
            this.CLAVETextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CLAVETextBox_Validating);
            // 
            // LBError
            // 
            this.LBError.AutoSize = true;
            this.LBError.ForeColor = System.Drawing.Color.Red;
            this.LBError.Location = new System.Drawing.Point(26, 20);
            this.LBError.Name = "LBError";
            this.LBError.Size = new System.Drawing.Size(10, 13);
            this.LBError.TabIndex = 44;
            this.LBError.Text = "-";
            // 
            // FbConnection1
            // 
            this.FbConnection1.ConnectionString = "Data Source=manuel;Initial Catalog=generador;Persist Security Info=True;User ID=s" +
    "a;Password=Twincept";
            // 
            // FbCommand1
            // 
            this.FbCommand1.CommandText = "select * from LINEA  where 1=1  and ID=@ID  and  1= 1 ";
            this.FbCommand1.CommandTimeout = 30;
            this.FbCommand1.Connection = this.FbConnection1;
            fbParameter1.FbDbType = FirebirdSql.Data.FirebirdClient.FbDbType.BigInt;
            fbParameter1.ParameterName = "@ID";
            this.FbCommand1.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
            fbParameter1});
            // 
            // BTCancelar
            // 
            this.BTCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCancelar.ForeColor = System.Drawing.Color.White;
            this.BTCancelar.Image = global::iPos.Properties.Resources.cancel_J;
            this.BTCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCancelar.Location = new System.Drawing.Point(295, 199);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(112, 30);
            this.BTCancelar.TabIndex = 47;
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
            this.BTIniciaEdicion.Location = new System.Drawing.Point(101, 203);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(57, 23);
            this.BTIniciaEdicion.TabIndex = 46;
            this.BTIniciaEdicion.Text = "Editar";
            this.BTIniciaEdicion.UseVisualStyleBackColor = false;
            this.BTIniciaEdicion.Visible = false;
            this.BTIniciaEdicion.Click += new System.EventHandler(this.BTIniciaEdicion_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TIPOGASTOIDTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CUENTAIDButton);
            this.panel1.Controls.Add(this.CUENTAIDTextBox);
            this.panel1.Controls.Add(this.CUENTAIDLabel);
            this.panel1.Controls.Add(this.ACTIVOTextBox);
            this.panel1.Controls.Add(this.ACTIVOLabel);
            this.panel1.Controls.Add(this.NOMBRELabel);
            this.panel1.Controls.Add(this.NOMBRETextBox);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(6, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 150);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(88, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 186;
            this.label1.Text = "Cuenta:";
            // 
            // CUENTAIDButton
            // 
            this.CUENTAIDButton.AccessibleDescription = "";
            this.CUENTAIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.CUENTAIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CUENTAIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CUENTAIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.CUENTAIDButton.Location = new System.Drawing.Point(230, 68);
            this.CUENTAIDButton.Name = "CUENTAIDButton";
            this.CUENTAIDButton.Size = new System.Drawing.Size(21, 23);
            this.CUENTAIDButton.TabIndex = 184;
            this.CUENTAIDButton.UseVisualStyleBackColor = true;
            // 
            // CUENTAIDTextBox
            // 
            this.CUENTAIDTextBox.AccessibleDescription = "";
            this.CUENTAIDTextBox.BotonLookUp = this.CUENTAIDButton;
            this.CUENTAIDTextBox.Condicion = null;
            this.CUENTAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CUENTAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CUENTAIDTextBox.DbValue = null;
            this.CUENTAIDTextBox.Format_Expression = null;
            this.CUENTAIDTextBox.IndiceCampoDescripcion = 2;
            this.CUENTAIDTextBox.IndiceCampoSelector = 1;
            this.CUENTAIDTextBox.IndiceCampoValue = 0;
            this.CUENTAIDTextBox.LabelDescription = this.CUENTAIDLabel;
            this.CUENTAIDTextBox.Location = new System.Drawing.Point(145, 69);
            this.CUENTAIDTextBox.MostrarErrores = true;
            this.CUENTAIDTextBox.Name = "CUENTAIDTextBox";
            this.CUENTAIDTextBox.NombreCampoSelector = "clave";
            this.CUENTAIDTextBox.NombreCampoValue = "id";
            this.CUENTAIDTextBox.Query = "select id,clave,numucuenta from cuenta";
            this.CUENTAIDTextBox.QueryDeSeleccion = "select id,clave,numucuenta from cuenta where clave = @clave";
            this.CUENTAIDTextBox.QueryPorDBValue = "select id,clave,numucuenta from cuenta where id = @id";
            this.CUENTAIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.CUENTAIDTextBox.TabIndex = 183;
            this.CUENTAIDTextBox.Tag = 34;
            this.CUENTAIDTextBox.TextDescription = null;
            this.CUENTAIDTextBox.Titulo = "Cuentas";
            this.CUENTAIDTextBox.ValidarEntrada = true;
            this.CUENTAIDTextBox.ValidationExpression = null;
            // 
            // CUENTAIDLabel
            // 
            this.CUENTAIDLabel.AccessibleDescription = "";
            this.CUENTAIDLabel.AutoSize = true;
            this.CUENTAIDLabel.ForeColor = System.Drawing.Color.White;
            this.CUENTAIDLabel.Location = new System.Drawing.Point(257, 72);
            this.CUENTAIDLabel.Name = "CUENTAIDLabel";
            this.CUENTAIDLabel.Size = new System.Drawing.Size(16, 13);
            this.CUENTAIDLabel.TabIndex = 185;
            this.CUENTAIDLabel.Text = "...";
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(145, 42);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ACTIVOTextBox.TabIndex = 5;
            this.ACTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // ACTIVOLabel
            // 
            this.ACTIVOLabel.AutoSize = true;
            this.ACTIVOLabel.BackColor = System.Drawing.Color.Transparent;
            this.ACTIVOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACTIVOLabel.ForeColor = System.Drawing.Color.White;
            this.ACTIVOLabel.Location = new System.Drawing.Point(92, 42);
            this.ACTIVOLabel.Name = "ACTIVOLabel";
            this.ACTIVOLabel.Size = new System.Drawing.Size(47, 13);
            this.ACTIVOLabel.TabIndex = 1;
            this.ACTIVOLabel.Text = "Activo:";
            // 
            // NOMBRELabel
            // 
            this.NOMBRELabel.AutoSize = true;
            this.NOMBRELabel.BackColor = System.Drawing.Color.Transparent;
            this.NOMBRELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NOMBRELabel.ForeColor = System.Drawing.Color.White;
            this.NOMBRELabel.Location = new System.Drawing.Point(85, 10);
            this.NOMBRELabel.Name = "NOMBRELabel";
            this.NOMBRELabel.Size = new System.Drawing.Size(54, 13);
            this.NOMBRELabel.TabIndex = 1;
            this.NOMBRELabel.Text = "Nombre:";
            // 
            // NOMBRETextBox
            // 
            this.NOMBRETextBox.Location = new System.Drawing.Point(145, 7);
            this.NOMBRETextBox.Name = "NOMBRETextBox";
            this.NOMBRETextBox.Size = new System.Drawing.Size(204, 20);
            this.NOMBRETextBox.TabIndex = 2;
            // 
            // CLAVELabel
            // 
            this.CLAVELabel.AutoSize = true;
            this.CLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLAVELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLAVELabel.ForeColor = System.Drawing.Color.White;
            this.CLAVELabel.Location = new System.Drawing.Point(102, 20);
            this.CLAVELabel.Name = "CLAVELabel";
            this.CLAVELabel.Size = new System.Drawing.Size(43, 13);
            this.CLAVELabel.TabIndex = 1;
            this.CLAVELabel.Text = "Clave:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(164, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TIPOGASTOIDTextBox
            // 
            this.TIPOGASTOIDTextBox.Condicion = null;
            this.TIPOGASTOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TIPOGASTOIDTextBox.DisplayMember = "nombre";
            this.TIPOGASTOIDTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TIPOGASTOIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TIPOGASTOIDTextBox.FormattingEnabled = true;
            this.TIPOGASTOIDTextBox.IndiceCampoSelector = 0;
            this.TIPOGASTOIDTextBox.LabelDescription = null;
            this.TIPOGASTOIDTextBox.Location = new System.Drawing.Point(145, 110);
            this.TIPOGASTOIDTextBox.Name = "TIPOGASTOIDTextBox";
            this.TIPOGASTOIDTextBox.NombreCampoSelector = "id";
            this.TIPOGASTOIDTextBox.Query = "select id,nombre from tipogasto";
            this.TIPOGASTOIDTextBox.QueryDeSeleccion = "select id,nombre from tipogasto where  id = @id";
            this.TIPOGASTOIDTextBox.SelectedDataDisplaying = null;
            this.TIPOGASTOIDTextBox.SelectedDataValue = null;
            this.TIPOGASTOIDTextBox.Size = new System.Drawing.Size(204, 20);
            this.TIPOGASTOIDTextBox.TabIndex = 187;
            this.TIPOGASTOIDTextBox.ValueMember = "id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(70, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 188;
            this.label2.Text = "Tipo gasto:";
            // 
            // WFGastoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(510, 243);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CLAVELabel);
            this.Controls.Add(this.CLAVETextBox);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFGastoEdit";
            this.Text = "GASTO";
            this.Load += new System.EventHandler(this.LINEAEdit_Reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

  }

  #endregion



        private System.Windows.Forms.TextBox CLAVETextBox;


        private System.Windows.Forms.TextBox NOMBRETextBox;
        private System.Windows.Forms.Panel panel1;
  
  private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
  private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.Label LBError;




  private CustomValidation.RequiredFieldValidator RFV_CLAVE;
        private System.Windows.Forms.Label ACTIVOLabel;
        private System.Windows.Forms.Label CLAVELabel;
        private System.Windows.Forms.Label NOMBRELabel;
        private System.Windows.Forms.Button BTIniciaEdicion;
        private System.Windows.Forms.CheckBox ACTIVOTextBox;
        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CUENTAIDButton;
        private Tools.TextBoxFB CUENTAIDTextBox;
        private System.Windows.Forms.Label CUENTAIDLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBoxFB TIPOGASTOIDTextBox;
    }
}

