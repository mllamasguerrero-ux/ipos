
namespace iPos
{
    partial class UCUSUARIOSEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCUSUARIOSEdit));
            this.US_USERIDLabel = new System.Windows.Forms.Label();
            this.US_USUARIOLabel = new System.Windows.Forms.Label();
            this.US_PASSWORDLabel = new System.Windows.Forms.Label();
            this.US_NOMBRELabel = new System.Windows.Forms.Label();
            this.US_VENDEDORLabel = new System.Windows.Forms.Label();
            this.US_VIGENCIALabel = new System.Windows.Forms.Label();
            this.US_EMPRESALabel = new System.Windows.Forms.Label();
            this.US_R_PASSWORDLabel = new System.Windows.Forms.Label();
            this.US_LIMITE_CONEXIONESLabel = new System.Windows.Forms.Label();
            this.US_CONEXIONES_ABIERTASLabel = new System.Windows.Forms.Label();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.button1 = new System.Windows.Forms.Button();
            this.US_ALMACENIDLabel = new System.Windows.Forms.Label();
            this.US_ALMACENIDTextBox = new System.Windows.Forms.TextBox();
            this.RAV_US_USERID = new CustomValidation.RangeValidator();
            this.requiredFieldValidator1 = new CustomValidation.RequiredFieldValidator();
            this.RFV_US_PASSWORD = new CustomValidation.RequiredFieldValidator();
            this.US_VENDEDORTextBox = new iPos.Tools.TextBoxFB();
            this.US_USERIDTextBox = new System.Windows.Forms.TextBoxET();
            this.US_USUARIOTextBox = new System.Windows.Forms.TextBoxET();
            this.US_PASSWORDTextBox = new System.Windows.Forms.TextBoxET();
            this.US_NOMBRETextBox = new System.Windows.Forms.TextBoxET();
            this.US_VIGENCIATextBox = new System.Windows.Forms.DateTimePickerE();
            this.US_EMPRESATextBox = new System.Windows.Forms.TextBoxET();
            this.US_R_PASSWORDTextBox = new System.Windows.Forms.TextBoxET();
            this.US_LIMITE_CONEXIONESTextBox = new System.Windows.Forms.TextBoxET();
            this.US_CONEXIONES_ABIERTASTextBox = new System.Windows.Forms.TextBoxET();
            this.RFV_US_USUARIO = new CustomValidation.RequiredFieldValidator();
            this.RAV_US_LIMITE_CONEXIONES = new CustomValidation.RangeValidator();
            this.RAV_US_CONEXIONES_ABIERTAS = new CustomValidation.RangeValidator();
            this.SuspendLayout();
            // 
            // US_USERIDLabel
            // 
            this.US_USERIDLabel.AutoSize = true;
            this.US_USERIDLabel.Location = new System.Drawing.Point(8, 194);
            this.US_USERIDLabel.Name = "US_USERIDLabel";
            this.US_USERIDLabel.Size = new System.Drawing.Size(72, 13);
            this.US_USERIDLabel.TabIndex = 1;
            this.US_USERIDLabel.Text = "US_USERID:";
            this.US_USERIDLabel.Visible = false;
            // 
            // US_USUARIOLabel
            // 
            this.US_USUARIOLabel.AutoSize = true;
            this.US_USUARIOLabel.Location = new System.Drawing.Point(8, 210);
            this.US_USUARIOLabel.Name = "US_USUARIOLabel";
            this.US_USUARIOLabel.Size = new System.Drawing.Size(80, 13);
            this.US_USUARIOLabel.TabIndex = 1;
            this.US_USUARIOLabel.Text = "US_USUARIO:";
            this.US_USUARIOLabel.Visible = false;
            // 
            // US_PASSWORDLabel
            // 
            this.US_PASSWORDLabel.AutoSize = true;
            this.US_PASSWORDLabel.Location = new System.Drawing.Point(14, 223);
            this.US_PASSWORDLabel.Name = "US_PASSWORDLabel";
            this.US_PASSWORDLabel.Size = new System.Drawing.Size(94, 13);
            this.US_PASSWORDLabel.TabIndex = 1;
            this.US_PASSWORDLabel.Text = "US_PASSWORD:";
            this.US_PASSWORDLabel.Visible = false;
            // 
            // US_NOMBRELabel
            // 
            this.US_NOMBRELabel.AutoSize = true;
            this.US_NOMBRELabel.Location = new System.Drawing.Point(2, 0);
            this.US_NOMBRELabel.Name = "US_NOMBRELabel";
            this.US_NOMBRELabel.Size = new System.Drawing.Size(57, 13);
            this.US_NOMBRELabel.TabIndex = 1;
            this.US_NOMBRELabel.Text = "NOMBRE:";
            // 
            // US_VENDEDORLabel
            // 
            this.US_VENDEDORLabel.AutoSize = true;
            this.US_VENDEDORLabel.Location = new System.Drawing.Point(8, 153);
            this.US_VENDEDORLabel.Name = "US_VENDEDORLabel";
            this.US_VENDEDORLabel.Size = new System.Drawing.Size(71, 13);
            this.US_VENDEDORLabel.TabIndex = 1;
            this.US_VENDEDORLabel.Text = "VENDEDOR:";
            // 
            // US_VIGENCIALabel
            // 
            this.US_VIGENCIALabel.AutoSize = true;
            this.US_VIGENCIALabel.Location = new System.Drawing.Point(3, 26);
            this.US_VIGENCIALabel.Name = "US_VIGENCIALabel";
            this.US_VIGENCIALabel.Size = new System.Drawing.Size(60, 13);
            this.US_VIGENCIALabel.TabIndex = 1;
            this.US_VIGENCIALabel.Text = "VIGENCIA:";
            // 
            // US_EMPRESALabel
            // 
            this.US_EMPRESALabel.AutoSize = true;
            this.US_EMPRESALabel.Location = new System.Drawing.Point(14, 127);
            this.US_EMPRESALabel.Name = "US_EMPRESALabel";
            this.US_EMPRESALabel.Size = new System.Drawing.Size(62, 13);
            this.US_EMPRESALabel.TabIndex = 1;
            this.US_EMPRESALabel.Text = "EMPRESA:";
            // 
            // US_R_PASSWORDLabel
            // 
            this.US_R_PASSWORDLabel.AutoSize = true;
            this.US_R_PASSWORDLabel.Location = new System.Drawing.Point(101, 204);
            this.US_R_PASSWORDLabel.Name = "US_R_PASSWORDLabel";
            this.US_R_PASSWORDLabel.Size = new System.Drawing.Size(108, 13);
            this.US_R_PASSWORDLabel.TabIndex = 1;
            this.US_R_PASSWORDLabel.Text = "US_R_PASSWORD:";
            this.US_R_PASSWORDLabel.Visible = false;
            // 
            // US_LIMITE_CONEXIONESLabel
            // 
            this.US_LIMITE_CONEXIONESLabel.AutoSize = true;
            this.US_LIMITE_CONEXIONESLabel.Location = new System.Drawing.Point(2, 207);
            this.US_LIMITE_CONEXIONESLabel.Name = "US_LIMITE_CONEXIONESLabel";
            this.US_LIMITE_CONEXIONESLabel.Size = new System.Drawing.Size(142, 13);
            this.US_LIMITE_CONEXIONESLabel.TabIndex = 1;
            this.US_LIMITE_CONEXIONESLabel.Text = "US_LIMITE_CONEXIONES:";
            this.US_LIMITE_CONEXIONESLabel.Visible = false;
            // 
            // US_CONEXIONES_ABIERTASLabel
            // 
            this.US_CONEXIONES_ABIERTASLabel.AutoSize = true;
            this.US_CONEXIONES_ABIERTASLabel.Location = new System.Drawing.Point(97, 159);
            this.US_CONEXIONES_ABIERTASLabel.Name = "US_CONEXIONES_ABIERTASLabel";
            this.US_CONEXIONES_ABIERTASLabel.Size = new System.Drawing.Size(160, 13);
            this.US_CONEXIONES_ABIERTASLabel.TabIndex = 1;
            this.US_CONEXIONES_ABIERTASLabel.Text = "US_CONEXIONES_ABIERTAS:";
            this.US_CONEXIONES_ABIERTASLabel.Visible = false;
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
            this.FbCommand1.CommandText = "select * from persona  where  ID=@US_USERID  ";
            this.FbCommand1.CommandTimeout = 30;
            this.FbCommand1.Connection = this.FbConnection1;
            fbParameter1.FbDbType = FirebirdSql.Data.FirebirdClient.FbDbType.Integer;
            fbParameter1.ParameterName = "@US_USERID";
            this.FbCommand1.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
            fbParameter1});
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(104, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // US_ALMACENIDLabel
            // 
            this.US_ALMACENIDLabel.AutoSize = true;
            this.US_ALMACENIDLabel.Location = new System.Drawing.Point(14, 178);
            this.US_ALMACENIDLabel.Name = "US_ALMACENIDLabel";
            this.US_ALMACENIDLabel.Size = new System.Drawing.Size(75, 13);
            this.US_ALMACENIDLabel.TabIndex = 44;
            this.US_ALMACENIDLabel.Text = "ALMACEN ID:";
            // 
            // US_ALMACENIDTextBox
            // 
            this.US_ALMACENIDTextBox.Enabled = false;
            this.US_ALMACENIDTextBox.Location = new System.Drawing.Point(113, 175);
            this.US_ALMACENIDTextBox.Name = "US_ALMACENIDTextBox";
            this.US_ALMACENIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.US_ALMACENIDTextBox.TabIndex = 6;
            // 
            // RAV_US_USERID
            // 
            this.RAV_US_USERID.Enabled = true;
            this.RAV_US_USERID.ErrorMessage = "Error el campo US_USERID no esta dentro del rango";
            this.RAV_US_USERID.Icon = ((System.Drawing.Icon)(resources.GetObject("RAV_US_USERID.Icon")));
            this.RAV_US_USERID.MaximumValue = "999999999999";
            this.RAV_US_USERID.MinimumValue = "0";
            this.RAV_US_USERID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.Enabled = true;
            this.requiredFieldValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator1.Icon")));
            // 
            // RFV_US_PASSWORD
            // 
            this.RFV_US_PASSWORD.Enabled = true;
            this.RFV_US_PASSWORD.ErrorMessage = "Se requiere el campo US_PASSWORD";
            this.RFV_US_PASSWORD.Icon = ((System.Drawing.Icon)(resources.GetObject("RFV_US_PASSWORD.Icon")));
            this.RFV_US_PASSWORD.InitialValue = "true";
            // 
            // US_VENDEDORTextBox
            // 
            this.US_VENDEDORTextBox.BackColor = System.Drawing.Color.Beige;
            this.US_VENDEDORTextBox.Condicion = null;
            this.US_VENDEDORTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.VarChar;
            this.US_VENDEDORTextBox.Enabled = false;
            this.US_VENDEDORTextBox.Format_Expression = null;
            this.US_VENDEDORTextBox.IndiceCampoDescripcion = 0;
            this.US_VENDEDORTextBox.IndiceCampoSelector = 0;
            this.US_VENDEDORTextBox.LabelDescription = null;
            this.US_VENDEDORTextBox.Location = new System.Drawing.Point(106, 149);
            this.US_VENDEDORTextBox.Name = "US_VENDEDORTextBox";
            this.US_VENDEDORTextBox.NombreCampoSelector = "@vd_vendedor";
            this.US_VENDEDORTextBox.Query = "Select * from vendedores";
            this.US_VENDEDORTextBox.QueryDeSeleccion = "Select * from vendedores where vd_vendedor=@vd_vendedor ";
            this.US_VENDEDORTextBox.Size = new System.Drawing.Size(100, 20);
            this.US_VENDEDORTextBox.TabIndex = 3;
            this.US_VENDEDORTextBox.Tag = 34;
            this.US_VENDEDORTextBox.Titulo = "Vendedores";
            this.US_VENDEDORTextBox.ValidationExpression = null;
            // 
            // US_USERIDTextBox
            // 
            this.US_USERIDTextBox.Enabled = false;
            this.US_USERIDTextBox.Format_Expression = null;
            this.US_USERIDTextBox.Location = new System.Drawing.Point(45, 194);
            this.US_USERIDTextBox.Name = "US_USERIDTextBox";
            this.US_USERIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.US_USERIDTextBox.TabIndex = 2;
            this.US_USERIDTextBox.Tag = 34;
            this.US_USERIDTextBox.ValidationExpression = null;
            this.US_USERIDTextBox.Visible = false;
            // 
            // US_USUARIOTextBox
            // 
            this.US_USUARIOTextBox.Enabled = false;
            this.US_USUARIOTextBox.Format_Expression = null;
            this.US_USUARIOTextBox.Location = new System.Drawing.Point(65, 203);
            this.US_USUARIOTextBox.Name = "US_USUARIOTextBox";
            this.US_USUARIOTextBox.Size = new System.Drawing.Size(100, 20);
            this.US_USUARIOTextBox.TabIndex = 2;
            this.US_USUARIOTextBox.Tag = 34;
            this.US_USUARIOTextBox.ValidationExpression = null;
            this.US_USUARIOTextBox.Visible = false;
            // 
            // US_PASSWORDTextBox
            // 
            this.US_PASSWORDTextBox.Enabled = false;
            this.US_PASSWORDTextBox.Format_Expression = null;
            this.US_PASSWORDTextBox.Location = new System.Drawing.Point(65, 220);
            this.US_PASSWORDTextBox.Name = "US_PASSWORDTextBox";
            this.US_PASSWORDTextBox.Size = new System.Drawing.Size(100, 20);
            this.US_PASSWORDTextBox.TabIndex = 2;
            this.US_PASSWORDTextBox.Tag = 34;
            this.US_PASSWORDTextBox.ValidationExpression = null;
            this.US_PASSWORDTextBox.Visible = false;
            // 
            // US_NOMBRETextBox
            // 
            this.US_NOMBRETextBox.Format_Expression = null;
            this.US_NOMBRETextBox.Location = new System.Drawing.Point(100, 0);
            this.US_NOMBRETextBox.Name = "US_NOMBRETextBox";
            this.US_NOMBRETextBox.Size = new System.Drawing.Size(100, 20);
            this.US_NOMBRETextBox.TabIndex = 2;
            this.US_NOMBRETextBox.Tag = 34;
            this.US_NOMBRETextBox.ValidationExpression = null;
            // 
            // US_VIGENCIATextBox
            // 
            this.US_VIGENCIATextBox.Location = new System.Drawing.Point(96, 26);
            this.US_VIGENCIATextBox.Name = "US_VIGENCIATextBox";
            this.US_VIGENCIATextBox.Size = new System.Drawing.Size(200, 20);
            this.US_VIGENCIATextBox.TabIndex = 4;
            // 
            // US_EMPRESATextBox
            // 
            this.US_EMPRESATextBox.Enabled = false;
            this.US_EMPRESATextBox.Format_Expression = null;
            this.US_EMPRESATextBox.Location = new System.Drawing.Point(112, 119);
            this.US_EMPRESATextBox.Name = "US_EMPRESATextBox";
            this.US_EMPRESATextBox.Size = new System.Drawing.Size(100, 20);
            this.US_EMPRESATextBox.TabIndex = 5;
            this.US_EMPRESATextBox.Tag = "5";
            this.US_EMPRESATextBox.ValidationExpression = null;
            // 
            // US_R_PASSWORDTextBox
            // 
            this.US_R_PASSWORDTextBox.Enabled = false;
            this.US_R_PASSWORDTextBox.Format_Expression = null;
            this.US_R_PASSWORDTextBox.Location = new System.Drawing.Point(185, 191);
            this.US_R_PASSWORDTextBox.Name = "US_R_PASSWORDTextBox";
            this.US_R_PASSWORDTextBox.Size = new System.Drawing.Size(100, 20);
            this.US_R_PASSWORDTextBox.TabIndex = 2;
            this.US_R_PASSWORDTextBox.Tag = 34;
            this.US_R_PASSWORDTextBox.ValidationExpression = null;
            this.US_R_PASSWORDTextBox.Visible = false;
            // 
            // US_LIMITE_CONEXIONESTextBox
            // 
            this.US_LIMITE_CONEXIONESTextBox.Format_Expression = null;
            this.US_LIMITE_CONEXIONESTextBox.Location = new System.Drawing.Point(67, 207);
            this.US_LIMITE_CONEXIONESTextBox.Name = "US_LIMITE_CONEXIONESTextBox";
            this.US_LIMITE_CONEXIONESTextBox.Size = new System.Drawing.Size(100, 20);
            this.US_LIMITE_CONEXIONESTextBox.TabIndex = 2;
            this.US_LIMITE_CONEXIONESTextBox.Tag = 34;
            this.US_LIMITE_CONEXIONESTextBox.ValidationExpression = null;
            this.US_LIMITE_CONEXIONESTextBox.Visible = false;
            // 
            // US_CONEXIONES_ABIERTASTextBox
            // 
            this.US_CONEXIONES_ABIERTASTextBox.Enabled = false;
            this.US_CONEXIONES_ABIERTASTextBox.Format_Expression = null;
            this.US_CONEXIONES_ABIERTASTextBox.Location = new System.Drawing.Point(199, 217);
            this.US_CONEXIONES_ABIERTASTextBox.Name = "US_CONEXIONES_ABIERTASTextBox";
            this.US_CONEXIONES_ABIERTASTextBox.Size = new System.Drawing.Size(100, 20);
            this.US_CONEXIONES_ABIERTASTextBox.TabIndex = 2;
            this.US_CONEXIONES_ABIERTASTextBox.Tag = 34;
            this.US_CONEXIONES_ABIERTASTextBox.ValidationExpression = null;
            this.US_CONEXIONES_ABIERTASTextBox.Visible = false;
            // 
            // RFV_US_USUARIO
            // 
            this.RFV_US_USUARIO.ControlToValidate = this.US_USUARIOTextBox;
            this.RFV_US_USUARIO.Enabled = true;
            this.RFV_US_USUARIO.ErrorMessage = "Se requiere el campo US_USUARIO";
            this.RFV_US_USUARIO.Icon = ((System.Drawing.Icon)(resources.GetObject("RFV_US_USUARIO.Icon")));
            // 
            // RAV_US_LIMITE_CONEXIONES
            // 
            this.RAV_US_LIMITE_CONEXIONES.ControlToValidate = this.US_LIMITE_CONEXIONESTextBox;
            this.RAV_US_LIMITE_CONEXIONES.Enabled = true;
            this.RAV_US_LIMITE_CONEXIONES.ErrorMessage = "Error el campo US_LIMITE_CONEXIONES no esta dentro del rango";
            this.RAV_US_LIMITE_CONEXIONES.Icon = ((System.Drawing.Icon)(resources.GetObject("RAV_US_LIMITE_CONEXIONES.Icon")));
            this.RAV_US_LIMITE_CONEXIONES.MaximumValue = "999999999999";
            this.RAV_US_LIMITE_CONEXIONES.MinimumValue = "0";
            this.RAV_US_LIMITE_CONEXIONES.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_US_CONEXIONES_ABIERTAS
            // 
            this.RAV_US_CONEXIONES_ABIERTAS.ControlToValidate = this.US_CONEXIONES_ABIERTASTextBox;
            this.RAV_US_CONEXIONES_ABIERTAS.Enabled = true;
            this.RAV_US_CONEXIONES_ABIERTAS.ErrorMessage = "Error el campo US_CONEXIONES_ABIERTAS no esta dentro del rango";
            this.RAV_US_CONEXIONES_ABIERTAS.Icon = ((System.Drawing.Icon)(resources.GetObject("RAV_US_CONEXIONES_ABIERTAS.Icon")));
            this.RAV_US_CONEXIONES_ABIERTAS.MaximumValue = "999999999999";
            this.RAV_US_CONEXIONES_ABIERTAS.MinimumValue = "0";
            this.RAV_US_CONEXIONES_ABIERTAS.Type = CustomValidation.ValidationDataType.Double;
            // 
            // UCUSUARIOSEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.US_ALMACENIDLabel);
            this.Controls.Add(this.US_ALMACENIDTextBox);
            this.Controls.Add(this.US_VENDEDORTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.US_USERIDLabel);
            this.Controls.Add(this.US_USERIDTextBox);
            this.Controls.Add(this.US_USUARIOLabel);
            this.Controls.Add(this.US_USUARIOTextBox);
            this.Controls.Add(this.US_PASSWORDLabel);
            this.Controls.Add(this.US_PASSWORDTextBox);
            this.Controls.Add(this.US_NOMBRELabel);
            this.Controls.Add(this.US_NOMBRETextBox);
            this.Controls.Add(this.US_VENDEDORLabel);
            this.Controls.Add(this.US_VIGENCIALabel);
            this.Controls.Add(this.US_VIGENCIATextBox);
            this.Controls.Add(this.US_EMPRESALabel);
            this.Controls.Add(this.US_EMPRESATextBox);
            this.Controls.Add(this.US_R_PASSWORDLabel);
            this.Controls.Add(this.US_R_PASSWORDTextBox);
            this.Controls.Add(this.US_LIMITE_CONEXIONESLabel);
            this.Controls.Add(this.US_LIMITE_CONEXIONESTextBox);
            this.Controls.Add(this.US_CONEXIONES_ABIERTASLabel);
            this.Controls.Add(this.US_CONEXIONES_ABIERTASTextBox);
            this.Name = "UCUSUARIOSEdit";
            this.Size = new System.Drawing.Size(299, 246);
            this.Load += new System.EventHandler(this.USUARIOSEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.TextBoxET US_USERIDTextBox;
        private System.Windows.Forms.TextBoxET US_USUARIOTextBox;
        private System.Windows.Forms.TextBoxET US_PASSWORDTextBox;
        private System.Windows.Forms.TextBoxET US_NOMBRETextBox;
        private System.Windows.Forms.TextBoxET US_EMPRESATextBox;
        private System.Windows.Forms.TextBoxET US_R_PASSWORDTextBox;
        private System.Windows.Forms.TextBoxET US_LIMITE_CONEXIONESTextBox;
        private System.Windows.Forms.TextBoxET US_CONEXIONES_ABIERTASTextBox;
        private System.Windows.Forms.DateTimePickerE US_VIGENCIATextBox;
 
        private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
        private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
        private System.Windows.Forms.Button button1;
 	private System.Windows.Forms.Label LBError;
    private CustomValidation.RequiredFieldValidator requiredFieldValidator1;
    private CustomValidation.RequiredFieldValidator RFV_US_USUARIO;
 
     
        private CustomValidation.RangeValidator RAV_US_USERID;
     
        private CustomValidation.RangeValidator RAV_US_LIMITE_CONEXIONES;
     
        private CustomValidation.RangeValidator RAV_US_CONEXIONES_ABIERTAS;
        private System.Windows.Forms.Label US_USERIDLabel;
        private System.Windows.Forms.Label US_USUARIOLabel;
        private System.Windows.Forms.Label US_PASSWORDLabel;
        private System.Windows.Forms.Label US_NOMBRELabel;
        private System.Windows.Forms.Label US_VENDEDORLabel;
        private System.Windows.Forms.Label US_VIGENCIALabel;
        private System.Windows.Forms.Label US_EMPRESALabel;
        private System.Windows.Forms.Label US_R_PASSWORDLabel;
        private System.Windows.Forms.Label US_LIMITE_CONEXIONESLabel;
        private System.Windows.Forms.Label US_CONEXIONES_ABIERTASLabel;
        private CustomValidation.RequiredFieldValidator RFV_US_PASSWORD;
        private iPos.Tools.TextBoxFB US_VENDEDORTextBox;
        private System.Windows.Forms.Label US_ALMACENIDLabel;
        private System.Windows.Forms.TextBox US_ALMACENIDTextBox;
 
    }
}

