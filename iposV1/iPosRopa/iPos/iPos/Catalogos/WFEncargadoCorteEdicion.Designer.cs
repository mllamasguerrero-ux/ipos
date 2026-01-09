
namespace iPos
{
    partial class WFEncargadoCorteEdicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFEncargadoCorteEdicion));
            this.CLAVELabel = new System.Windows.Forms.Label();
            this.RFV_CLAVE = new CustomValidation.RequiredFieldValidator();
            this.RAV_ID = new CustomValidation.RangeValidator();
            this.RAV_CREADOPOR_USERID = new CustomValidation.RangeValidator();
            this.RAV_MODIFICADOPOR_USERID = new CustomValidation.RangeValidator();
            this.RAV_TIPOPERSONAID = new CustomValidation.RangeValidator();
            this.RAV_SALUDOID = new CustomValidation.RangeValidator();
            this.RAV_EMPRESAID = new CustomValidation.RangeValidator();
            this.RAV_VENDEDORID = new CustomValidation.RangeValidator();
            this.RAV_LISTAPRECIOID = new CustomValidation.RangeValidator();
            this.RAV_RESET_PASS = new CustomValidation.RangeValidator();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.button1 = new System.Windows.Forms.Button();
            this.requiredFieldValidator1 = new CustomValidation.RequiredFieldValidator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PAISComboBoxFb = new System.Windows.Forms.ComboBoxFB();
            this.ESTADOTextBox = new System.Windows.Forms.ComboBoxFB();
            this.label1 = new System.Windows.Forms.Label();
            this.GAFFETETextBox = new System.Windows.Forms.TextBoxET();
            this.SALUDOIDTextBox = new System.Windows.Forms.ComboBoxFB();
            this.LISTAPRECIOIDTextBox = new System.Windows.Forms.ComboBox();
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.DOMICILIOLabel = new System.Windows.Forms.Label();
            this.DOMICILIOTextBox = new System.Windows.Forms.TextBox();
            this.CREADOPOR_USERIDLabel = new System.Windows.Forms.Label();
            this.TextBoxCREADOPOR_USERCLAVE = new System.Windows.Forms.TextBox();
            this.COLONIALabel = new System.Windows.Forms.Label();
            this.MODIFICADOPOR_USERIDLabel = new System.Windows.Forms.Label();
            this.COLONIATextBox = new System.Windows.Forms.TextBox();
            this.MODIFICADOPOR_USERIDTextBox = new System.Windows.Forms.TextBox();
            this.LISTAPRECIOIDLabel = new System.Windows.Forms.Label();
            this.VIGENCIATextBox = new System.Windows.Forms.DateTimePicker();
            this.CIUDADLabel = new System.Windows.Forms.Label();
            this.VIGENCIALabel = new System.Windows.Forms.Label();
            this.CIUDADTextBox = new System.Windows.Forms.TextBox();
            this.MUNICIPIOLabel = new System.Windows.Forms.Label();
            this.NOMBRELabel = new System.Windows.Forms.Label();
            this.CONTACTO2TextBox = new System.Windows.Forms.TextBox();
            this.MUNICIPIOTextBox = new System.Windows.Forms.TextBox();
            this.NOMBRETextBox = new System.Windows.Forms.TextBox();
            this.CONTACTO2Label = new System.Windows.Forms.Label();
            this.DESCRIPCIONLabel = new System.Windows.Forms.Label();
            this.ESTADOLabel = new System.Windows.Forms.Label();
            this.CONTACTO1TextBox = new System.Windows.Forms.TextBox();
            this.DESCRIPCIONTextBox = new System.Windows.Forms.TextBox();
            this.CONTACTO1Label = new System.Windows.Forms.Label();
            this.MEMOLabel = new System.Windows.Forms.Label();
            this.RFCTextBox = new System.Windows.Forms.TextBox();
            this.MEMOTextBox = new System.Windows.Forms.TextBox();
            this.PAISLabel = new System.Windows.Forms.Label();
            this.RFCLabel = new System.Windows.Forms.Label();
            this.EMAIL2TextBox = new System.Windows.Forms.TextBox();
            this.SALUDOIDLabel = new System.Windows.Forms.Label();
            this.EMAIL2Label = new System.Windows.Forms.Label();
            this.RAZONSOCIALTextBox = new System.Windows.Forms.TextBox();
            this.EMAIL1TextBox = new System.Windows.Forms.TextBox();
            this.RAZONSOCIALLabel = new System.Windows.Forms.Label();
            this.EMAIL1Label = new System.Windows.Forms.Label();
            this.NOMBRESLabel = new System.Windows.Forms.Label();
            this.CODIGOPOSTALLabel = new System.Windows.Forms.Label();
            this.APELLIDOSTextBox = new System.Windows.Forms.TextBox();
            this.NEXTELTextBox = new System.Windows.Forms.TextBox();
            this.NOMBRESTextBox = new System.Windows.Forms.TextBox();
            this.NEXTELLabel = new System.Windows.Forms.Label();
            this.APELLIDOSLabel = new System.Windows.Forms.Label();
            this.CODIGOPOSTALTextBox = new System.Windows.Forms.TextBox();
            this.CELULARTextBox = new System.Windows.Forms.TextBox();
            this.CELULARLabel = new System.Windows.Forms.Label();
            this.TELEFONO1Label = new System.Windows.Forms.Label();
            this.TELEFONO3TextBox = new System.Windows.Forms.TextBox();
            this.TELEFONO3Label = new System.Windows.Forms.Label();
            this.TELEFONO1TextBox = new System.Windows.Forms.TextBox();
            this.TELEFONO2TextBox = new System.Windows.Forms.TextBox();
            this.TELEFONO2Label = new System.Windows.Forms.Label();
            this.CLAVETextBox = new System.Windows.Forms.TextBox();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.btnQuotas = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CLAVELabel
            // 
            this.CLAVELabel.AutoSize = true;
            this.CLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLAVELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            this.CLAVELabel.Location = new System.Drawing.Point(36, 11);
            this.CLAVELabel.Name = "CLAVELabel";
            this.CLAVELabel.Size = new System.Drawing.Size(46, 15);
            this.CLAVELabel.TabIndex = 1;
            this.CLAVELabel.Text = "Clave:";
            // 
            // RFV_CLAVE
            // 
            this.RFV_CLAVE.Enabled = true;
            this.RFV_CLAVE.ErrorMessage = "Se requiere el campo ID";
            this.RFV_CLAVE.Icon = null;
            // 
            // RAV_ID
            // 
            this.RAV_ID.Enabled = true;
            this.RAV_ID.ErrorMessage = "Error el campo ID no esta dentro del rango";
            this.RAV_ID.Icon = null;
            this.RAV_ID.MaximumValue = "999999999999";
            this.RAV_ID.MinimumValue = "0";
            this.RAV_ID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_CREADOPOR_USERID
            // 
            this.RAV_CREADOPOR_USERID.Enabled = true;
            this.RAV_CREADOPOR_USERID.ErrorMessage = "Error el campo CREADOPOR_USERID no esta dentro del rango";
            this.RAV_CREADOPOR_USERID.Icon = null;
            this.RAV_CREADOPOR_USERID.MaximumValue = "999999999999";
            this.RAV_CREADOPOR_USERID.MinimumValue = "0";
            this.RAV_CREADOPOR_USERID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_MODIFICADOPOR_USERID
            // 
            this.RAV_MODIFICADOPOR_USERID.Enabled = true;
            this.RAV_MODIFICADOPOR_USERID.ErrorMessage = "Error el campo MODIFICADOPOR_USERID no esta dentro del rango";
            this.RAV_MODIFICADOPOR_USERID.Icon = null;
            this.RAV_MODIFICADOPOR_USERID.MaximumValue = "999999999999";
            this.RAV_MODIFICADOPOR_USERID.MinimumValue = "0";
            this.RAV_MODIFICADOPOR_USERID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_TIPOPERSONAID
            // 
            this.RAV_TIPOPERSONAID.Enabled = true;
            this.RAV_TIPOPERSONAID.ErrorMessage = "Error el campo TIPOPERSONAID no esta dentro del rango";
            this.RAV_TIPOPERSONAID.Icon = null;
            this.RAV_TIPOPERSONAID.MaximumValue = "999999999999";
            this.RAV_TIPOPERSONAID.MinimumValue = "0";
            this.RAV_TIPOPERSONAID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_SALUDOID
            // 
            this.RAV_SALUDOID.Enabled = true;
            this.RAV_SALUDOID.ErrorMessage = "Error el campo SALUDOID no esta dentro del rango";
            this.RAV_SALUDOID.Icon = null;
            this.RAV_SALUDOID.MaximumValue = "999999999999";
            this.RAV_SALUDOID.MinimumValue = "0";
            this.RAV_SALUDOID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_EMPRESAID
            // 
            this.RAV_EMPRESAID.Enabled = true;
            this.RAV_EMPRESAID.ErrorMessage = "Error el campo EMPRESAID no esta dentro del rango";
            this.RAV_EMPRESAID.Icon = null;
            this.RAV_EMPRESAID.MaximumValue = "999999999999";
            this.RAV_EMPRESAID.MinimumValue = "0";
            this.RAV_EMPRESAID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_VENDEDORID
            // 
            this.RAV_VENDEDORID.Enabled = true;
            this.RAV_VENDEDORID.ErrorMessage = "Error el campo VENDEDORID no esta dentro del rango";
            this.RAV_VENDEDORID.Icon = null;
            this.RAV_VENDEDORID.MaximumValue = "999999999999";
            this.RAV_VENDEDORID.MinimumValue = "0";
            this.RAV_VENDEDORID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_LISTAPRECIOID
            // 
            this.RAV_LISTAPRECIOID.Enabled = true;
            this.RAV_LISTAPRECIOID.ErrorMessage = "Error el campo LISTAPRECIOID no esta dentro del rango";
            this.RAV_LISTAPRECIOID.Icon = null;
            this.RAV_LISTAPRECIOID.MaximumValue = "999999999999";
            this.RAV_LISTAPRECIOID.MinimumValue = "0";
            this.RAV_LISTAPRECIOID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_RESET_PASS
            // 
            this.RAV_RESET_PASS.Enabled = true;
            this.RAV_RESET_PASS.ErrorMessage = "Error el campo RESET_PASS no esta dentro del rango";
            this.RAV_RESET_PASS.Icon = null;
            this.RAV_RESET_PASS.MaximumValue = "999999999999";
            this.RAV_RESET_PASS.MinimumValue = "0";
            this.RAV_RESET_PASS.Type = CustomValidation.ValidationDataType.Double;
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(290, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.Enabled = true;
            this.requiredFieldValidator1.Icon = null;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.PAISComboBoxFb);
            this.panel1.Controls.Add(this.ESTADOTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.GAFFETETextBox);
            this.panel1.Controls.Add(this.SALUDOIDTextBox);
            this.panel1.Controls.Add(this.LISTAPRECIOIDTextBox);
            this.panel1.Controls.Add(this.ACTIVOTextBox);
            this.panel1.Controls.Add(this.DOMICILIOLabel);
            this.panel1.Controls.Add(this.DOMICILIOTextBox);
            this.panel1.Controls.Add(this.CREADOPOR_USERIDLabel);
            this.panel1.Controls.Add(this.TextBoxCREADOPOR_USERCLAVE);
            this.panel1.Controls.Add(this.COLONIALabel);
            this.panel1.Controls.Add(this.MODIFICADOPOR_USERIDLabel);
            this.panel1.Controls.Add(this.COLONIATextBox);
            this.panel1.Controls.Add(this.MODIFICADOPOR_USERIDTextBox);
            this.panel1.Controls.Add(this.LISTAPRECIOIDLabel);
            this.panel1.Controls.Add(this.VIGENCIATextBox);
            this.panel1.Controls.Add(this.CIUDADLabel);
            this.panel1.Controls.Add(this.VIGENCIALabel);
            this.panel1.Controls.Add(this.CIUDADTextBox);
            this.panel1.Controls.Add(this.MUNICIPIOLabel);
            this.panel1.Controls.Add(this.NOMBRELabel);
            this.panel1.Controls.Add(this.CONTACTO2TextBox);
            this.panel1.Controls.Add(this.MUNICIPIOTextBox);
            this.panel1.Controls.Add(this.NOMBRETextBox);
            this.panel1.Controls.Add(this.CONTACTO2Label);
            this.panel1.Controls.Add(this.DESCRIPCIONLabel);
            this.panel1.Controls.Add(this.ESTADOLabel);
            this.panel1.Controls.Add(this.CONTACTO1TextBox);
            this.panel1.Controls.Add(this.DESCRIPCIONTextBox);
            this.panel1.Controls.Add(this.CONTACTO1Label);
            this.panel1.Controls.Add(this.MEMOLabel);
            this.panel1.Controls.Add(this.RFCTextBox);
            this.panel1.Controls.Add(this.MEMOTextBox);
            this.panel1.Controls.Add(this.PAISLabel);
            this.panel1.Controls.Add(this.RFCLabel);
            this.panel1.Controls.Add(this.EMAIL2TextBox);
            this.panel1.Controls.Add(this.SALUDOIDLabel);
            this.panel1.Controls.Add(this.EMAIL2Label);
            this.panel1.Controls.Add(this.RAZONSOCIALTextBox);
            this.panel1.Controls.Add(this.EMAIL1TextBox);
            this.panel1.Controls.Add(this.RAZONSOCIALLabel);
            this.panel1.Controls.Add(this.EMAIL1Label);
            this.panel1.Controls.Add(this.NOMBRESLabel);
            this.panel1.Controls.Add(this.CODIGOPOSTALLabel);
            this.panel1.Controls.Add(this.APELLIDOSTextBox);
            this.panel1.Controls.Add(this.NEXTELTextBox);
            this.panel1.Controls.Add(this.NOMBRESTextBox);
            this.panel1.Controls.Add(this.NEXTELLabel);
            this.panel1.Controls.Add(this.APELLIDOSLabel);
            this.panel1.Controls.Add(this.CODIGOPOSTALTextBox);
            this.panel1.Controls.Add(this.CELULARTextBox);
            this.panel1.Controls.Add(this.CELULARLabel);
            this.panel1.Controls.Add(this.TELEFONO1Label);
            this.panel1.Controls.Add(this.TELEFONO3TextBox);
            this.panel1.Controls.Add(this.TELEFONO3Label);
            this.panel1.Controls.Add(this.TELEFONO1TextBox);
            this.panel1.Controls.Add(this.TELEFONO2TextBox);
            this.panel1.Controls.Add(this.TELEFONO2Label);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(1, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 420);
            this.panel1.TabIndex = 4;
            // 
            // PAISComboBoxFb
            // 
            this.PAISComboBoxFb.Condicion = null;
            this.PAISComboBoxFb.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PAISComboBoxFb.DisplayMember = "sat_descripcion";
            this.PAISComboBoxFb.FormattingEnabled = true;
            this.PAISComboBoxFb.IndiceCampoSelector = 0;
            this.PAISComboBoxFb.LabelDescription = null;
            this.PAISComboBoxFb.Location = new System.Drawing.Point(481, 275);
            this.PAISComboBoxFb.Name = "PAISComboBoxFb";
            this.PAISComboBoxFb.NombreCampoSelector = "sat_clave";
            this.PAISComboBoxFb.Query = "select id, sat_clave, sat_descripcion from sat_pais";
            this.PAISComboBoxFb.QueryDeSeleccion = "select id, sat_clave, sat_descripcion from sat_pais where sat_clave = @sat_clave";
            this.PAISComboBoxFb.SelectedDataDisplaying = null;
            this.PAISComboBoxFb.SelectedDataValue = null;
            this.PAISComboBoxFb.Size = new System.Drawing.Size(208, 21);
            this.PAISComboBoxFb.TabIndex = 180;
            this.PAISComboBoxFb.ValueMember = "sat_clave";
            // 
            // ESTADOTextBox
            // 
            this.ESTADOTextBox.Condicion = null;
            this.ESTADOTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ESTADOTextBox.DisplayMember = "nombre";
            this.ESTADOTextBox.FormattingEnabled = true;
            this.ESTADOTextBox.IndiceCampoSelector = 0;
            this.ESTADOTextBox.LabelDescription = null;
            this.ESTADOTextBox.Location = new System.Drawing.Point(258, 274);
            this.ESTADOTextBox.Name = "ESTADOTextBox";
            this.ESTADOTextBox.NombreCampoSelector = "id";
            this.ESTADOTextBox.Query = "select id,nombre from estado";
            this.ESTADOTextBox.QueryDeSeleccion = "select id,nombre from estado where  id = @id";
            this.ESTADOTextBox.SelectedDataDisplaying = null;
            this.ESTADOTextBox.SelectedDataValue = null;
            this.ESTADOTextBox.Size = new System.Drawing.Size(206, 21);
            this.ESTADOTextBox.TabIndex = 179;
            this.ESTADOTextBox.ValueMember = "id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(707, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Gaffete:";
            // 
            // GAFFETETextBox
            // 
            this.GAFFETETextBox.Format_Expression = null;
            this.GAFFETETextBox.Location = new System.Drawing.Point(710, 315);
            this.GAFFETETextBox.Name = "GAFFETETextBox";
            this.GAFFETETextBox.Size = new System.Drawing.Size(233, 20);
            this.GAFFETETextBox.TabIndex = 29;
            this.GAFFETETextBox.Tag = 34;
            this.GAFFETETextBox.ValidationExpression = null;
            // 
            // SALUDOIDTextBox
            // 
            this.SALUDOIDTextBox.BackColor = System.Drawing.Color.White;
            this.SALUDOIDTextBox.Condicion = null;
            this.SALUDOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SALUDOIDTextBox.DisplayMember = "NOMBRE";
            this.SALUDOIDTextBox.FormattingEnabled = true;
            this.SALUDOIDTextBox.IndiceCampoSelector = 0;
            this.SALUDOIDTextBox.LabelDescription = null;
            this.SALUDOIDTextBox.Location = new System.Drawing.Point(783, 70);
            this.SALUDOIDTextBox.Name = "SALUDOIDTextBox";
            this.SALUDOIDTextBox.NombreCampoSelector = null;
            this.SALUDOIDTextBox.Query = "select ID,NOMBRE from saludo";
            this.SALUDOIDTextBox.QueryDeSeleccion = null;
            this.SALUDOIDTextBox.SelectedDataDisplaying = null;
            this.SALUDOIDTextBox.SelectedDataValue = null;
            this.SALUDOIDTextBox.Size = new System.Drawing.Size(159, 21);
            this.SALUDOIDTextBox.TabIndex = 9;
            this.SALUDOIDTextBox.ValueMember = "ID";
            // 
            // LISTAPRECIOIDTextBox
            // 
            this.LISTAPRECIOIDTextBox.FormattingEnabled = true;
            this.LISTAPRECIOIDTextBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.LISTAPRECIOIDTextBox.Location = new System.Drawing.Point(785, 189);
            this.LISTAPRECIOIDTextBox.Name = "LISTAPRECIOIDTextBox";
            this.LISTAPRECIOIDTextBox.Size = new System.Drawing.Size(157, 21);
            this.LISTAPRECIOIDTextBox.TabIndex = 16;
            this.LISTAPRECIOIDTextBox.Visible = false;
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(350, 14);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(47, 31);
            this.ACTIVOTextBox.TabIndex = 3;
            this.ACTIVOTextBox.Text = "Activo";
            this.ACTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // DOMICILIOLabel
            // 
            this.DOMICILIOLabel.AutoSize = true;
            this.DOMICILIOLabel.Location = new System.Drawing.Point(22, 219);
            this.DOMICILIOLabel.Name = "DOMICILIOLabel";
            this.DOMICILIOLabel.Size = new System.Drawing.Size(58, 13);
            this.DOMICILIOLabel.TabIndex = 1;
            this.DOMICILIOLabel.Text = "Domicilio";
            // 
            // DOMICILIOTextBox
            // 
            this.DOMICILIOTextBox.Location = new System.Drawing.Point(26, 235);
            this.DOMICILIOTextBox.Name = "DOMICILIOTextBox";
            this.DOMICILIOTextBox.Size = new System.Drawing.Size(439, 20);
            this.DOMICILIOTextBox.TabIndex = 17;
            // 
            // CREADOPOR_USERIDLabel
            // 
            this.CREADOPOR_USERIDLabel.AutoSize = true;
            this.CREADOPOR_USERIDLabel.Location = new System.Drawing.Point(587, 14);
            this.CREADOPOR_USERIDLabel.Name = "CREADOPOR_USERIDLabel";
            this.CREADOPOR_USERIDLabel.Size = new System.Drawing.Size(70, 13);
            this.CREADOPOR_USERIDLabel.TabIndex = 1;
            this.CREADOPOR_USERIDLabel.Text = "Creado Por";
            // 
            // TextBoxCREADOPOR_USERCLAVE
            // 
            this.TextBoxCREADOPOR_USERCLAVE.Enabled = false;
            this.TextBoxCREADOPOR_USERCLAVE.Location = new System.Drawing.Point(591, 29);
            this.TextBoxCREADOPOR_USERCLAVE.Name = "TextBoxCREADOPOR_USERCLAVE";
            this.TextBoxCREADOPOR_USERCLAVE.ReadOnly = true;
            this.TextBoxCREADOPOR_USERCLAVE.Size = new System.Drawing.Size(166, 20);
            this.TextBoxCREADOPOR_USERCLAVE.TabIndex = 5;
            // 
            // COLONIALabel
            // 
            this.COLONIALabel.AutoSize = true;
            this.COLONIALabel.Location = new System.Drawing.Point(484, 218);
            this.COLONIALabel.Name = "COLONIALabel";
            this.COLONIALabel.Size = new System.Drawing.Size(49, 13);
            this.COLONIALabel.TabIndex = 1;
            this.COLONIALabel.Text = "Colonia";
            // 
            // MODIFICADOPOR_USERIDLabel
            // 
            this.MODIFICADOPOR_USERIDLabel.AutoSize = true;
            this.MODIFICADOPOR_USERIDLabel.Location = new System.Drawing.Point(787, 14);
            this.MODIFICADOPOR_USERIDLabel.Name = "MODIFICADOPOR_USERIDLabel";
            this.MODIFICADOPOR_USERIDLabel.Size = new System.Drawing.Size(91, 13);
            this.MODIFICADOPOR_USERIDLabel.TabIndex = 1;
            this.MODIFICADOPOR_USERIDLabel.Text = "Modificado por";
            // 
            // COLONIATextBox
            // 
            this.COLONIATextBox.Location = new System.Drawing.Point(481, 234);
            this.COLONIATextBox.Name = "COLONIATextBox";
            this.COLONIATextBox.Size = new System.Drawing.Size(208, 20);
            this.COLONIATextBox.TabIndex = 18;
            // 
            // MODIFICADOPOR_USERIDTextBox
            // 
            this.MODIFICADOPOR_USERIDTextBox.Enabled = false;
            this.MODIFICADOPOR_USERIDTextBox.Location = new System.Drawing.Point(784, 29);
            this.MODIFICADOPOR_USERIDTextBox.Name = "MODIFICADOPOR_USERIDTextBox";
            this.MODIFICADOPOR_USERIDTextBox.ReadOnly = true;
            this.MODIFICADOPOR_USERIDTextBox.Size = new System.Drawing.Size(158, 20);
            this.MODIFICADOPOR_USERIDTextBox.TabIndex = 6;
            this.MODIFICADOPOR_USERIDTextBox.TabStop = false;
            // 
            // LISTAPRECIOIDLabel
            // 
            this.LISTAPRECIOIDLabel.AutoSize = true;
            this.LISTAPRECIOIDLabel.Location = new System.Drawing.Point(782, 173);
            this.LISTAPRECIOIDLabel.Name = "LISTAPRECIOIDLabel";
            this.LISTAPRECIOIDLabel.Size = new System.Drawing.Size(98, 13);
            this.LISTAPRECIOIDLabel.TabIndex = 1;
            this.LISTAPRECIOIDLabel.Text = "Lista de Precios";
            this.LISTAPRECIOIDLabel.Visible = false;
            // 
            // VIGENCIATextBox
            // 
            this.VIGENCIATextBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.VIGENCIATextBox.Location = new System.Drawing.Point(436, 29);
            this.VIGENCIATextBox.Name = "VIGENCIATextBox";
            this.VIGENCIATextBox.Size = new System.Drawing.Size(124, 20);
            this.VIGENCIATextBox.TabIndex = 4;
            // 
            // CIUDADLabel
            // 
            this.CIUDADLabel.AutoSize = true;
            this.CIUDADLabel.Location = new System.Drawing.Point(22, 258);
            this.CIUDADLabel.Name = "CIUDADLabel";
            this.CIUDADLabel.Size = new System.Drawing.Size(46, 13);
            this.CIUDADLabel.TabIndex = 1;
            this.CIUDADLabel.Text = "Ciudad";
            // 
            // VIGENCIALabel
            // 
            this.VIGENCIALabel.AutoSize = true;
            this.VIGENCIALabel.Location = new System.Drawing.Point(436, 14);
            this.VIGENCIALabel.Name = "VIGENCIALabel";
            this.VIGENCIALabel.Size = new System.Drawing.Size(56, 13);
            this.VIGENCIALabel.TabIndex = 1;
            this.VIGENCIALabel.Text = "Vigencia";
            // 
            // CIUDADTextBox
            // 
            this.CIUDADTextBox.Location = new System.Drawing.Point(26, 274);
            this.CIUDADTextBox.Name = "CIUDADTextBox";
            this.CIUDADTextBox.Size = new System.Drawing.Size(212, 20);
            this.CIUDADTextBox.TabIndex = 20;
            // 
            // MUNICIPIOLabel
            // 
            this.MUNICIPIOLabel.AutoSize = true;
            this.MUNICIPIOLabel.Location = new System.Drawing.Point(707, 217);
            this.MUNICIPIOLabel.Name = "MUNICIPIOLabel";
            this.MUNICIPIOLabel.Size = new System.Drawing.Size(61, 13);
            this.MUNICIPIOLabel.TabIndex = 1;
            this.MUNICIPIOLabel.Text = "Municipio";
            // 
            // NOMBRELabel
            // 
            this.NOMBRELabel.AutoSize = true;
            this.NOMBRELabel.Location = new System.Drawing.Point(23, 14);
            this.NOMBRELabel.Name = "NOMBRELabel";
            this.NOMBRELabel.Size = new System.Drawing.Size(50, 13);
            this.NOMBRELabel.TabIndex = 1;
            this.NOMBRELabel.Text = "Nombre";
            // 
            // CONTACTO2TextBox
            // 
            this.CONTACTO2TextBox.Location = new System.Drawing.Point(491, 393);
            this.CONTACTO2TextBox.Name = "CONTACTO2TextBox";
            this.CONTACTO2TextBox.Size = new System.Drawing.Size(456, 20);
            this.CONTACTO2TextBox.TabIndex = 33;
            // 
            // MUNICIPIOTextBox
            // 
            this.MUNICIPIOTextBox.Location = new System.Drawing.Point(710, 233);
            this.MUNICIPIOTextBox.Name = "MUNICIPIOTextBox";
            this.MUNICIPIOTextBox.Size = new System.Drawing.Size(235, 20);
            this.MUNICIPIOTextBox.TabIndex = 19;
            // 
            // NOMBRETextBox
            // 
            this.NOMBRETextBox.Location = new System.Drawing.Point(27, 29);
            this.NOMBRETextBox.Name = "NOMBRETextBox";
            this.NOMBRETextBox.Size = new System.Drawing.Size(294, 20);
            this.NOMBRETextBox.TabIndex = 2;
            // 
            // CONTACTO2Label
            // 
            this.CONTACTO2Label.AutoSize = true;
            this.CONTACTO2Label.Location = new System.Drawing.Point(492, 377);
            this.CONTACTO2Label.Name = "CONTACTO2Label";
            this.CONTACTO2Label.Size = new System.Drawing.Size(69, 13);
            this.CONTACTO2Label.TabIndex = 1;
            this.CONTACTO2Label.Text = "Contacto 2";
            // 
            // DESCRIPCIONLabel
            // 
            this.DESCRIPCIONLabel.AutoSize = true;
            this.DESCRIPCIONLabel.Location = new System.Drawing.Point(22, 134);
            this.DESCRIPCIONLabel.Name = "DESCRIPCIONLabel";
            this.DESCRIPCIONLabel.Size = new System.Drawing.Size(74, 13);
            this.DESCRIPCIONLabel.TabIndex = 1;
            this.DESCRIPCIONLabel.Text = "Descripción";
            // 
            // ESTADOLabel
            // 
            this.ESTADOLabel.AutoSize = true;
            this.ESTADOLabel.Location = new System.Drawing.Point(255, 258);
            this.ESTADOLabel.Name = "ESTADOLabel";
            this.ESTADOLabel.Size = new System.Drawing.Size(46, 13);
            this.ESTADOLabel.TabIndex = 1;
            this.ESTADOLabel.Text = "Estado";
            // 
            // CONTACTO1TextBox
            // 
            this.CONTACTO1TextBox.Location = new System.Drawing.Point(25, 393);
            this.CONTACTO1TextBox.Name = "CONTACTO1TextBox";
            this.CONTACTO1TextBox.Size = new System.Drawing.Size(439, 20);
            this.CONTACTO1TextBox.TabIndex = 32;
            // 
            // DESCRIPCIONTextBox
            // 
            this.DESCRIPCIONTextBox.Location = new System.Drawing.Point(26, 148);
            this.DESCRIPCIONTextBox.Name = "DESCRIPCIONTextBox";
            this.DESCRIPCIONTextBox.Size = new System.Drawing.Size(916, 20);
            this.DESCRIPCIONTextBox.TabIndex = 12;
            // 
            // CONTACTO1Label
            // 
            this.CONTACTO1Label.AutoSize = true;
            this.CONTACTO1Label.Location = new System.Drawing.Point(23, 377);
            this.CONTACTO1Label.Name = "CONTACTO1Label";
            this.CONTACTO1Label.Size = new System.Drawing.Size(69, 13);
            this.CONTACTO1Label.TabIndex = 1;
            this.CONTACTO1Label.Text = "Contacto 1";
            // 
            // MEMOLabel
            // 
            this.MEMOLabel.AutoSize = true;
            this.MEMOLabel.Location = new System.Drawing.Point(22, 173);
            this.MEMOLabel.Name = "MEMOLabel";
            this.MEMOLabel.Size = new System.Drawing.Size(91, 13);
            this.MEMOLabel.TabIndex = 1;
            this.MEMOLabel.Text = "Observaciones";
            // 
            // RFCTextBox
            // 
            this.RFCTextBox.Location = new System.Drawing.Point(784, 108);
            this.RFCTextBox.Name = "RFCTextBox";
            this.RFCTextBox.Size = new System.Drawing.Size(158, 20);
            this.RFCTextBox.TabIndex = 11;
            // 
            // MEMOTextBox
            // 
            this.MEMOTextBox.Location = new System.Drawing.Point(26, 189);
            this.MEMOTextBox.Name = "MEMOTextBox";
            this.MEMOTextBox.Size = new System.Drawing.Size(731, 20);
            this.MEMOTextBox.TabIndex = 13;
            // 
            // PAISLabel
            // 
            this.PAISLabel.AutoSize = true;
            this.PAISLabel.Location = new System.Drawing.Point(482, 258);
            this.PAISLabel.Name = "PAISLabel";
            this.PAISLabel.Size = new System.Drawing.Size(33, 13);
            this.PAISLabel.TabIndex = 1;
            this.PAISLabel.Text = "País";
            // 
            // RFCLabel
            // 
            this.RFCLabel.AutoSize = true;
            this.RFCLabel.Location = new System.Drawing.Point(780, 94);
            this.RFCLabel.Name = "RFCLabel";
            this.RFCLabel.Size = new System.Drawing.Size(35, 13);
            this.RFCLabel.TabIndex = 1;
            this.RFCLabel.Text = "RFC:";
            // 
            // EMAIL2TextBox
            // 
            this.EMAIL2TextBox.Location = new System.Drawing.Point(491, 354);
            this.EMAIL2TextBox.Name = "EMAIL2TextBox";
            this.EMAIL2TextBox.Size = new System.Drawing.Size(454, 20);
            this.EMAIL2TextBox.TabIndex = 31;
            // 
            // SALUDOIDLabel
            // 
            this.SALUDOIDLabel.AutoSize = true;
            this.SALUDOIDLabel.Location = new System.Drawing.Point(791, 55);
            this.SALUDOIDLabel.Name = "SALUDOIDLabel";
            this.SALUDOIDLabel.Size = new System.Drawing.Size(46, 13);
            this.SALUDOIDLabel.TabIndex = 1;
            this.SALUDOIDLabel.Text = "Saludo";
            // 
            // EMAIL2Label
            // 
            this.EMAIL2Label.AutoSize = true;
            this.EMAIL2Label.Location = new System.Drawing.Point(498, 338);
            this.EMAIL2Label.Name = "EMAIL2Label";
            this.EMAIL2Label.Size = new System.Drawing.Size(52, 13);
            this.EMAIL2Label.TabIndex = 1;
            this.EMAIL2Label.Text = "E-mail 2";
            // 
            // RAZONSOCIALTextBox
            // 
            this.RAZONSOCIALTextBox.Location = new System.Drawing.Point(26, 108);
            this.RAZONSOCIALTextBox.Name = "RAZONSOCIALTextBox";
            this.RAZONSOCIALTextBox.Size = new System.Drawing.Size(731, 20);
            this.RAZONSOCIALTextBox.TabIndex = 10;
            // 
            // EMAIL1TextBox
            // 
            this.EMAIL1TextBox.Location = new System.Drawing.Point(25, 354);
            this.EMAIL1TextBox.Name = "EMAIL1TextBox";
            this.EMAIL1TextBox.Size = new System.Drawing.Size(439, 20);
            this.EMAIL1TextBox.TabIndex = 30;
            // 
            // RAZONSOCIALLabel
            // 
            this.RAZONSOCIALLabel.AutoSize = true;
            this.RAZONSOCIALLabel.Location = new System.Drawing.Point(22, 94);
            this.RAZONSOCIALLabel.Name = "RAZONSOCIALLabel";
            this.RAZONSOCIALLabel.Size = new System.Drawing.Size(82, 13);
            this.RAZONSOCIALLabel.TabIndex = 1;
            this.RAZONSOCIALLabel.Text = "Razón Social";
            // 
            // EMAIL1Label
            // 
            this.EMAIL1Label.AutoSize = true;
            this.EMAIL1Label.Location = new System.Drawing.Point(24, 338);
            this.EMAIL1Label.Name = "EMAIL1Label";
            this.EMAIL1Label.Size = new System.Drawing.Size(52, 13);
            this.EMAIL1Label.TabIndex = 1;
            this.EMAIL1Label.Text = "E-mail 1";
            // 
            // NOMBRESLabel
            // 
            this.NOMBRESLabel.AutoSize = true;
            this.NOMBRESLabel.Location = new System.Drawing.Point(22, 55);
            this.NOMBRESLabel.Name = "NOMBRESLabel";
            this.NOMBRESLabel.Size = new System.Drawing.Size(56, 13);
            this.NOMBRESLabel.TabIndex = 1;
            this.NOMBRESLabel.Text = "Nombres";
            // 
            // CODIGOPOSTALLabel
            // 
            this.CODIGOPOSTALLabel.AutoSize = true;
            this.CODIGOPOSTALLabel.Location = new System.Drawing.Point(707, 256);
            this.CODIGOPOSTALLabel.Name = "CODIGOPOSTALLabel";
            this.CODIGOPOSTALLabel.Size = new System.Drawing.Size(85, 13);
            this.CODIGOPOSTALLabel.TabIndex = 1;
            this.CODIGOPOSTALLabel.Text = "Código Postal";
            // 
            // APELLIDOSTextBox
            // 
            this.APELLIDOSTextBox.Location = new System.Drawing.Point(350, 69);
            this.APELLIDOSTextBox.Name = "APELLIDOSTextBox";
            this.APELLIDOSTextBox.Size = new System.Drawing.Size(407, 20);
            this.APELLIDOSTextBox.TabIndex = 8;
            // 
            // NEXTELTextBox
            // 
            this.NEXTELTextBox.Location = new System.Drawing.Point(573, 315);
            this.NEXTELTextBox.Name = "NEXTELTextBox";
            this.NEXTELTextBox.Size = new System.Drawing.Size(116, 20);
            this.NEXTELTextBox.TabIndex = 28;
            // 
            // NOMBRESTextBox
            // 
            this.NOMBRESTextBox.Location = new System.Drawing.Point(26, 69);
            this.NOMBRESTextBox.Name = "NOMBRESTextBox";
            this.NOMBRESTextBox.Size = new System.Drawing.Size(296, 20);
            this.NOMBRESTextBox.TabIndex = 7;
            // 
            // NEXTELLabel
            // 
            this.NEXTELLabel.AutoSize = true;
            this.NEXTELLabel.Location = new System.Drawing.Point(570, 299);
            this.NEXTELLabel.Name = "NEXTELLabel";
            this.NEXTELLabel.Size = new System.Drawing.Size(43, 13);
            this.NEXTELLabel.TabIndex = 1;
            this.NEXTELLabel.Text = "Nextel";
            // 
            // APELLIDOSLabel
            // 
            this.APELLIDOSLabel.AutoSize = true;
            this.APELLIDOSLabel.Location = new System.Drawing.Point(357, 55);
            this.APELLIDOSLabel.Name = "APELLIDOSLabel";
            this.APELLIDOSLabel.Size = new System.Drawing.Size(58, 13);
            this.APELLIDOSLabel.TabIndex = 1;
            this.APELLIDOSLabel.Text = "Apellidos";
            // 
            // CODIGOPOSTALTextBox
            // 
            this.CODIGOPOSTALTextBox.Location = new System.Drawing.Point(710, 274);
            this.CODIGOPOSTALTextBox.Name = "CODIGOPOSTALTextBox";
            this.CODIGOPOSTALTextBox.Size = new System.Drawing.Size(126, 20);
            this.CODIGOPOSTALTextBox.TabIndex = 23;
            // 
            // CELULARTextBox
            // 
            this.CELULARTextBox.Location = new System.Drawing.Point(432, 315);
            this.CELULARTextBox.Name = "CELULARTextBox";
            this.CELULARTextBox.Size = new System.Drawing.Size(116, 20);
            this.CELULARTextBox.TabIndex = 27;
            // 
            // CELULARLabel
            // 
            this.CELULARLabel.AutoSize = true;
            this.CELULARLabel.Location = new System.Drawing.Point(439, 299);
            this.CELULARLabel.Name = "CELULARLabel";
            this.CELULARLabel.Size = new System.Drawing.Size(46, 13);
            this.CELULARLabel.TabIndex = 1;
            this.CELULARLabel.Text = "Celular";
            // 
            // TELEFONO1Label
            // 
            this.TELEFONO1Label.AutoSize = true;
            this.TELEFONO1Label.Location = new System.Drawing.Point(22, 299);
            this.TELEFONO1Label.Name = "TELEFONO1Label";
            this.TELEFONO1Label.Size = new System.Drawing.Size(68, 13);
            this.TELEFONO1Label.TabIndex = 1;
            this.TELEFONO1Label.Text = "Teléfono 1";
            // 
            // TELEFONO3TextBox
            // 
            this.TELEFONO3TextBox.Location = new System.Drawing.Point(302, 315);
            this.TELEFONO3TextBox.Name = "TELEFONO3TextBox";
            this.TELEFONO3TextBox.Size = new System.Drawing.Size(116, 20);
            this.TELEFONO3TextBox.TabIndex = 26;
            // 
            // TELEFONO3Label
            // 
            this.TELEFONO3Label.AutoSize = true;
            this.TELEFONO3Label.Location = new System.Drawing.Point(320, 299);
            this.TELEFONO3Label.Name = "TELEFONO3Label";
            this.TELEFONO3Label.Size = new System.Drawing.Size(68, 13);
            this.TELEFONO3Label.TabIndex = 1;
            this.TELEFONO3Label.Text = "Teléfono 3";
            // 
            // TELEFONO1TextBox
            // 
            this.TELEFONO1TextBox.Location = new System.Drawing.Point(26, 315);
            this.TELEFONO1TextBox.Name = "TELEFONO1TextBox";
            this.TELEFONO1TextBox.Size = new System.Drawing.Size(116, 20);
            this.TELEFONO1TextBox.TabIndex = 24;
            // 
            // TELEFONO2TextBox
            // 
            this.TELEFONO2TextBox.Location = new System.Drawing.Point(166, 315);
            this.TELEFONO2TextBox.Name = "TELEFONO2TextBox";
            this.TELEFONO2TextBox.Size = new System.Drawing.Size(116, 20);
            this.TELEFONO2TextBox.TabIndex = 25;
            // 
            // TELEFONO2Label
            // 
            this.TELEFONO2Label.AutoSize = true;
            this.TELEFONO2Label.Location = new System.Drawing.Point(162, 299);
            this.TELEFONO2Label.Name = "TELEFONO2Label";
            this.TELEFONO2Label.Size = new System.Drawing.Size(68, 13);
            this.TELEFONO2Label.TabIndex = 1;
            this.TELEFONO2Label.Text = "Teléfono 2";
            // 
            // CLAVETextBox
            // 
            this.CLAVETextBox.Location = new System.Drawing.Point(94, 6);
            this.CLAVETextBox.Name = "CLAVETextBox";
            this.CLAVETextBox.Size = new System.Drawing.Size(116, 20);
            this.CLAVETextBox.TabIndex = 2;
            this.CLAVETextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CLAVETextBox_Validating);
            // 
            // BTIniciaEdicion
            // 
            this.BTIniciaEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTIniciaEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTIniciaEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIniciaEdicion.ForeColor = System.Drawing.Color.White;
            this.BTIniciaEdicion.Location = new System.Drawing.Point(236, 4);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(87, 23);
            this.BTIniciaEdicion.TabIndex = 3;
            this.BTIniciaEdicion.Text = "Editar";
            this.BTIniciaEdicion.UseVisualStyleBackColor = false;
            this.BTIniciaEdicion.Visible = false;
            this.BTIniciaEdicion.Click += new System.EventHandler(this.BTIniciaEdicion_Click);
            // 
            // BTCancelar
            // 
            this.BTCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelar.ForeColor = System.Drawing.Color.White;
            this.BTCancelar.Image = global::iPos.Properties.Resources.cancel_J;
            this.BTCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCancelar.Location = new System.Drawing.Point(526, 458);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(132, 30);
            this.BTCancelar.TabIndex = 6;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // btnQuotas
            // 
            this.btnQuotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnQuotas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnQuotas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuotas.ForeColor = System.Drawing.Color.White;
            this.btnQuotas.Location = new System.Drawing.Point(31, 462);
            this.btnQuotas.Name = "btnQuotas";
            this.btnQuotas.Size = new System.Drawing.Size(75, 23);
            this.btnQuotas.TabIndex = 7;
            this.btnQuotas.Text = "Quotas";
            this.btnQuotas.UseVisualStyleBackColor = false;
            this.btnQuotas.Visible = false;
            this.btnQuotas.Click += new System.EventHandler(this.btnQuotas_Click);
            // 
            // WFEncargadoCorteEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(969, 493);
            this.Controls.Add(this.btnQuotas);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CLAVELabel);
            this.Controls.Add(this.CLAVETextBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFEncargadoCorteEdicion";
            this.Text = "ENCARGADO CORTE";
            this.Load += new System.EventHandler(this.PERSONAEdit_Reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

  }

  #endregion


        private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.Label LBError;
  private CustomValidation.RequiredFieldValidator requiredFieldValidator1;




        private CustomValidation.RequiredFieldValidator RFV_CLAVE;
 
     
        private CustomValidation.RangeValidator RAV_ID;
     
        private CustomValidation.RangeValidator RAV_CREADOPOR_USERID;
     
        private CustomValidation.RangeValidator RAV_MODIFICADOPOR_USERID;
     
        private CustomValidation.RangeValidator RAV_TIPOPERSONAID;
     
        private CustomValidation.RangeValidator RAV_SALUDOID;
     
        private CustomValidation.RangeValidator RAV_EMPRESAID;
     
        private CustomValidation.RangeValidator RAV_VENDEDORID;
     
        private CustomValidation.RangeValidator RAV_LISTAPRECIOID;

        private CustomValidation.RangeValidator RAV_RESET_PASS;
        private System.Windows.Forms.Label CLAVELabel;
        private System.Windows.Forms.Button BTIniciaEdicion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox LISTAPRECIOIDTextBox;
        private System.Windows.Forms.CheckBox ACTIVOTextBox;
        private System.Windows.Forms.Label DOMICILIOLabel;
        private System.Windows.Forms.TextBox DOMICILIOTextBox;
        private System.Windows.Forms.Label CREADOPOR_USERIDLabel;
        private System.Windows.Forms.TextBox TextBoxCREADOPOR_USERCLAVE;
        private System.Windows.Forms.Label COLONIALabel;
        private System.Windows.Forms.Label MODIFICADOPOR_USERIDLabel;
        private System.Windows.Forms.TextBox COLONIATextBox;
        private System.Windows.Forms.TextBox MODIFICADOPOR_USERIDTextBox;
        private System.Windows.Forms.Label LISTAPRECIOIDLabel;
        private System.Windows.Forms.DateTimePicker VIGENCIATextBox;
        private System.Windows.Forms.Label CIUDADLabel;
        private System.Windows.Forms.Label VIGENCIALabel;
        private System.Windows.Forms.TextBox CIUDADTextBox;
        private System.Windows.Forms.Label MUNICIPIOLabel;
        private System.Windows.Forms.Label NOMBRELabel;
        private System.Windows.Forms.TextBox CONTACTO2TextBox;
        private System.Windows.Forms.TextBox MUNICIPIOTextBox;
        private System.Windows.Forms.TextBox NOMBRETextBox;
        private System.Windows.Forms.Label CONTACTO2Label;
        private System.Windows.Forms.Label DESCRIPCIONLabel;
        private System.Windows.Forms.Label ESTADOLabel;
        private System.Windows.Forms.TextBox CONTACTO1TextBox;
        private System.Windows.Forms.TextBox DESCRIPCIONTextBox;
        private System.Windows.Forms.Label CONTACTO1Label;
        private System.Windows.Forms.Label MEMOLabel;
        private System.Windows.Forms.TextBox RFCTextBox;
        private System.Windows.Forms.TextBox MEMOTextBox;
        private System.Windows.Forms.Label PAISLabel;
        private System.Windows.Forms.Label RFCLabel;
        private System.Windows.Forms.TextBox EMAIL2TextBox;
        private System.Windows.Forms.Label SALUDOIDLabel;
        private System.Windows.Forms.Label EMAIL2Label;
        private System.Windows.Forms.TextBox RAZONSOCIALTextBox;
        private System.Windows.Forms.TextBox EMAIL1TextBox;
        private System.Windows.Forms.Label RAZONSOCIALLabel;
        private System.Windows.Forms.Label EMAIL1Label;
        private System.Windows.Forms.Label NOMBRESLabel;
        private System.Windows.Forms.Label CODIGOPOSTALLabel;
        private System.Windows.Forms.TextBox APELLIDOSTextBox;
        private System.Windows.Forms.TextBox NEXTELTextBox;
        private System.Windows.Forms.TextBox NOMBRESTextBox;
        private System.Windows.Forms.Label NEXTELLabel;
        private System.Windows.Forms.Label APELLIDOSLabel;
        private System.Windows.Forms.TextBox CODIGOPOSTALTextBox;
        private System.Windows.Forms.TextBox CELULARTextBox;
        private System.Windows.Forms.Label CELULARLabel;
        private System.Windows.Forms.Label TELEFONO1Label;
        private System.Windows.Forms.TextBox TELEFONO3TextBox;
        private System.Windows.Forms.Label TELEFONO3Label;
        private System.Windows.Forms.TextBox TELEFONO1TextBox;
        private System.Windows.Forms.TextBox TELEFONO2TextBox;
        private System.Windows.Forms.Label TELEFONO2Label;
        private System.Windows.Forms.TextBox CLAVETextBox;
        private System.Windows.Forms.ComboBoxFB SALUDOIDTextBox;
        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBoxET GAFFETETextBox;
        private System.Windows.Forms.ComboBoxFB ESTADOTextBox;
        private System.Windows.Forms.Button btnQuotas;
        private System.Windows.Forms.ComboBoxFB PAISComboBoxFb;
 

    }
}

