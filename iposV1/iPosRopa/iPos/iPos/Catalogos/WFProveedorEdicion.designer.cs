
namespace iPos
{
    partial class WFProveedorEdicion
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
            System.Windows.Forms.Label PROVEECLIENTETag;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFProveedorEdicion));
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
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PROVEECLIENTEIDButton = new System.Windows.Forms.Button();
            this.PROVEECLIENTEIDTextBox = new iPos.Tools.TextBoxFB();
            this.PROVEECLIENTEIDLabel = new System.Windows.Forms.Label();
            this.PAISComboBoxFb = new System.Windows.Forms.ComboBoxFB();
            this.ESIMPORTADORTextBox = new System.Windows.Forms.CheckBox();
            this.ESIMPORTADORLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ADESCPESTextBox = new System.Windows.Forms.NumericTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lpagos = new System.Windows.Forms.Label();
            this.lrevisio = new System.Windows.Forms.Label();
            this.PAGOSTextBox = new System.Windows.Forms.ComboBox();
            this.ldias = new System.Windows.Forms.Label();
            this.REVISIONTextBox = new System.Windows.Forms.ComboBox();
            this.DIASTextBox = new System.Windows.Forms.NumericTextBox();
            this.ESTADOTextBox = new System.Windows.Forms.ComboBoxFB();
            this.EMPRESAButton = new System.Windows.Forms.Button();
            this.EMPRESAIDTextBox = new iPos.Tools.TextBoxFB();
            this.EMPRESALabel = new System.Windows.Forms.Label();
            this.VENDEDORButton = new System.Windows.Forms.Button();
            this.VENDEDORIDTextBox = new iPos.Tools.TextBoxFB();
            this.VENDEDORLabel = new System.Windows.Forms.Label();
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
            this.VENDEDORIDLabel = new System.Windows.Forms.Label();
            this.CONTACTO1Label = new System.Windows.Forms.Label();
            this.MEMOLabel = new System.Windows.Forms.Label();
            this.RFCTextBox = new System.Windows.Forms.TextBox();
            this.EMPRESAIDLabel = new System.Windows.Forms.Label();
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
            this.BTCancelar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conSaldosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenesDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNotaIncidencia = new System.Windows.Forms.Button();
            this.BTAgregarNota = new System.Windows.Forms.Button();
            PROVEECLIENTETag = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PROVEECLIENTETag
            // 
            PROVEECLIENTETag.AutoSize = true;
            PROVEECLIENTETag.Location = new System.Drawing.Point(705, 336);
            PROVEECLIENTETag.Name = "PROVEECLIENTETag";
            PROVEECLIENTETag.Size = new System.Drawing.Size(120, 13);
            PROVEECLIENTETag.TabIndex = 191;
            PROVEECLIENTETag.Text = "Cliente relacionado:";
            // 
            // CLAVELabel
            // 
            this.CLAVELabel.AutoSize = true;
            this.CLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLAVELabel.Location = new System.Drawing.Point(36, 48);
            this.CLAVELabel.Name = "CLAVELabel";
            this.CLAVELabel.Size = new System.Drawing.Size(43, 13);
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
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(387, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 30);
            this.button1.TabIndex = 37;
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
            // BTIniciaEdicion
            // 
            this.BTIniciaEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTIniciaEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTIniciaEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIniciaEdicion.ForeColor = System.Drawing.Color.White;
            this.BTIniciaEdicion.Location = new System.Drawing.Point(236, 41);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(87, 23);
            this.BTIniciaEdicion.TabIndex = 3;
            this.BTIniciaEdicion.Text = "Editar";
            this.BTIniciaEdicion.UseVisualStyleBackColor = false;
            this.BTIniciaEdicion.Visible = false;
            this.BTIniciaEdicion.Click += new System.EventHandler(this.BTIniciaEdicion_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.PROVEECLIENTEIDButton);
            this.panel1.Controls.Add(this.PROVEECLIENTEIDTextBox);
            this.panel1.Controls.Add(this.PROVEECLIENTEIDLabel);
            this.panel1.Controls.Add(PROVEECLIENTETag);
            this.panel1.Controls.Add(this.PAISComboBoxFb);
            this.panel1.Controls.Add(this.ESIMPORTADORTextBox);
            this.panel1.Controls.Add(this.ESIMPORTADORLabel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ESTADOTextBox);
            this.panel1.Controls.Add(this.EMPRESAButton);
            this.panel1.Controls.Add(this.EMPRESAIDTextBox);
            this.panel1.Controls.Add(this.EMPRESALabel);
            this.panel1.Controls.Add(this.VENDEDORButton);
            this.panel1.Controls.Add(this.VENDEDORIDTextBox);
            this.panel1.Controls.Add(this.VENDEDORLabel);
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
            this.panel1.Controls.Add(this.VENDEDORIDLabel);
            this.panel1.Controls.Add(this.CONTACTO1Label);
            this.panel1.Controls.Add(this.MEMOLabel);
            this.panel1.Controls.Add(this.RFCTextBox);
            this.panel1.Controls.Add(this.EMPRESAIDLabel);
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
            this.panel1.Location = new System.Drawing.Point(1, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 418);
            this.panel1.TabIndex = 4;
            // 
            // PROVEECLIENTEIDButton
            // 
            this.PROVEECLIENTEIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.PROVEECLIENTEIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PROVEECLIENTEIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PROVEECLIENTEIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PROVEECLIENTEIDButton.Location = new System.Drawing.Point(790, 351);
            this.PROVEECLIENTEIDButton.Name = "PROVEECLIENTEIDButton";
            this.PROVEECLIENTEIDButton.Size = new System.Drawing.Size(21, 23);
            this.PROVEECLIENTEIDButton.TabIndex = 190;
            this.PROVEECLIENTEIDButton.UseVisualStyleBackColor = true;
            // 
            // PROVEECLIENTEIDTextBox
            // 
            this.PROVEECLIENTEIDTextBox.BotonLookUp = this.PROVEECLIENTEIDButton;
            this.PROVEECLIENTEIDTextBox.Condicion = null;
            this.PROVEECLIENTEIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEECLIENTEIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEECLIENTEIDTextBox.DbValue = null;
            this.PROVEECLIENTEIDTextBox.Format_Expression = null;
            this.PROVEECLIENTEIDTextBox.IndiceCampoDescripcion = 2;
            this.PROVEECLIENTEIDTextBox.IndiceCampoSelector = 1;
            this.PROVEECLIENTEIDTextBox.IndiceCampoValue = 0;
            this.PROVEECLIENTEIDTextBox.LabelDescription = this.PROVEECLIENTEIDLabel;
            this.PROVEECLIENTEIDTextBox.Location = new System.Drawing.Point(708, 352);
            this.PROVEECLIENTEIDTextBox.MostrarErrores = true;
            this.PROVEECLIENTEIDTextBox.Name = "PROVEECLIENTEIDTextBox";
            this.PROVEECLIENTEIDTextBox.NombreCampoSelector = "clave";
            this.PROVEECLIENTEIDTextBox.NombreCampoValue = "id";
            this.PROVEECLIENTEIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 50";
            this.PROVEECLIENTEIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 50 and  clave = @clave";
            this.PROVEECLIENTEIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 50 and  id = @id";
            this.PROVEECLIENTEIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.PROVEECLIENTEIDTextBox.TabIndex = 189;
            this.PROVEECLIENTEIDTextBox.Tag = 34;
            this.PROVEECLIENTEIDTextBox.TextDescription = null;
            this.PROVEECLIENTEIDTextBox.Titulo = "Clientes";
            this.PROVEECLIENTEIDTextBox.ValidarEntrada = true;
            this.PROVEECLIENTEIDTextBox.ValidationExpression = null;
            // 
            // PROVEECLIENTEIDLabel
            // 
            this.PROVEECLIENTEIDLabel.AutoSize = true;
            this.PROVEECLIENTEIDLabel.Location = new System.Drawing.Point(815, 358);
            this.PROVEECLIENTEIDLabel.Name = "PROVEECLIENTEIDLabel";
            this.PROVEECLIENTEIDLabel.Size = new System.Drawing.Size(19, 13);
            this.PROVEECLIENTEIDLabel.TabIndex = 192;
            this.PROVEECLIENTEIDLabel.Text = "...";
            // 
            // PAISComboBoxFb
            // 
            this.PAISComboBoxFb.Condicion = null;
            this.PAISComboBoxFb.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PAISComboBoxFb.DisplayMember = "sat_descripcion";
            this.PAISComboBoxFb.FormattingEnabled = true;
            this.PAISComboBoxFb.IndiceCampoSelector = 1;
            this.PAISComboBoxFb.LabelDescription = null;
            this.PAISComboBoxFb.Location = new System.Drawing.Point(573, 312);
            this.PAISComboBoxFb.Name = "PAISComboBoxFb";
            this.PAISComboBoxFb.NombreCampoSelector = "sat_clave";
            this.PAISComboBoxFb.Query = "select id, sat_clave, sat_descripcion from sat_pais";
            this.PAISComboBoxFb.QueryDeSeleccion = "select id, sat_clave, sat_descripcion from sat_pais where sat_clave = @sat_clave";
            this.PAISComboBoxFb.SelectedDataDisplaying = null;
            this.PAISComboBoxFb.SelectedDataValue = null;
            this.PAISComboBoxFb.Size = new System.Drawing.Size(253, 21);
            this.PAISComboBoxFb.TabIndex = 188;
            this.PAISComboBoxFb.ValueMember = "sat_clave";
            // 
            // ESIMPORTADORTextBox
            // 
            this.ESIMPORTADORTextBox.AutoSize = true;
            this.ESIMPORTADORTextBox.Location = new System.Drawing.Point(1040, 230);
            this.ESIMPORTADORTextBox.Name = "ESIMPORTADORTextBox";
            this.ESIMPORTADORTextBox.Size = new System.Drawing.Size(15, 14);
            this.ESIMPORTADORTextBox.TabIndex = 187;
            this.ESIMPORTADORTextBox.UseVisualStyleBackColor = true;
            // 
            // ESIMPORTADORLabel
            // 
            this.ESIMPORTADORLabel.AutoSize = true;
            this.ESIMPORTADORLabel.Location = new System.Drawing.Point(908, 231);
            this.ESIMPORTADORLabel.Name = "ESIMPORTADORLabel";
            this.ESIMPORTADORLabel.Size = new System.Drawing.Size(84, 13);
            this.ESIMPORTADORLabel.TabIndex = 186;
            this.ESIMPORTADORLabel.Text = "Es importador";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ADESCPESTextBox);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lpagos);
            this.panel2.Controls.Add(this.lrevisio);
            this.panel2.Controls.Add(this.PAGOSTextBox);
            this.panel2.Controls.Add(this.ldias);
            this.panel2.Controls.Add(this.REVISIONTextBox);
            this.panel2.Controls.Add(this.DIASTextBox);
            this.panel2.Location = new System.Drawing.Point(911, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(191, 141);
            this.panel2.TabIndex = 33;
            // 
            // ADESCPESTextBox
            // 
            this.ADESCPESTextBox.AllowNegative = true;
            this.ADESCPESTextBox.Format_Expression = null;
            this.ADESCPESTextBox.Location = new System.Drawing.Point(76, 110);
            this.ADESCPESTextBox.Name = "ADESCPESTextBox";
            this.ADESCPESTextBox.NumericPrecision = 18;
            this.ADESCPESTextBox.NumericScaleOnFocus = 2;
            this.ADESCPESTextBox.NumericScaleOnLostFocus = 2;
            this.ADESCPESTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ADESCPESTextBox.Size = new System.Drawing.Size(99, 20);
            this.ADESCPESTextBox.TabIndex = 272;
            this.ADESCPESTextBox.Tag = "";
            this.ADESCPESTextBox.Text = "0.00";
            this.ADESCPESTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ADESCPESTextBox.ValidationExpression = null;
            this.ADESCPESTextBox.ZeroIsValid = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 271;
            this.label14.Text = "% Com. Ad.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 173;
            this.label1.Text = "Información de credito";
            // 
            // lpagos
            // 
            this.lpagos.AutoSize = true;
            this.lpagos.Location = new System.Drawing.Point(9, 82);
            this.lpagos.Name = "lpagos";
            this.lpagos.Size = new System.Drawing.Size(42, 13);
            this.lpagos.TabIndex = 168;
            this.lpagos.Text = "Pagos";
            // 
            // lrevisio
            // 
            this.lrevisio.AutoSize = true;
            this.lrevisio.Location = new System.Drawing.Point(7, 58);
            this.lrevisio.Name = "lrevisio";
            this.lrevisio.Size = new System.Drawing.Size(56, 13);
            this.lrevisio.TabIndex = 167;
            this.lrevisio.Text = "Revision";
            // 
            // PAGOSTextBox
            // 
            this.PAGOSTextBox.FormattingEnabled = true;
            this.PAGOSTextBox.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.PAGOSTextBox.Location = new System.Drawing.Point(76, 80);
            this.PAGOSTextBox.Name = "PAGOSTextBox";
            this.PAGOSTextBox.Size = new System.Drawing.Size(100, 21);
            this.PAGOSTextBox.TabIndex = 36;
            // 
            // ldias
            // 
            this.ldias.AutoSize = true;
            this.ldias.Location = new System.Drawing.Point(7, 32);
            this.ldias.Name = "ldias";
            this.ldias.Size = new System.Drawing.Size(67, 13);
            this.ldias.TabIndex = 169;
            this.ldias.Text = "Dias Plazo";
            // 
            // REVISIONTextBox
            // 
            this.REVISIONTextBox.FormattingEnabled = true;
            this.REVISIONTextBox.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.REVISIONTextBox.Location = new System.Drawing.Point(76, 55);
            this.REVISIONTextBox.Name = "REVISIONTextBox";
            this.REVISIONTextBox.Size = new System.Drawing.Size(100, 21);
            this.REVISIONTextBox.TabIndex = 35;
            // 
            // DIASTextBox
            // 
            this.DIASTextBox.AllowNegative = true;
            this.DIASTextBox.Format_Expression = null;
            this.DIASTextBox.Location = new System.Drawing.Point(76, 30);
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
            this.DIASTextBox.TabIndex = 34;
            this.DIASTextBox.Tag = "";
            this.DIASTextBox.Text = "0";
            this.DIASTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DIASTextBox.ValidationExpression = null;
            this.DIASTextBox.ZeroIsValid = true;
            // 
            // ESTADOTextBox
            // 
            this.ESTADOTextBox.Condicion = null;
            this.ESTADOTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ESTADOTextBox.DisplayMember = "nombre";
            this.ESTADOTextBox.FormattingEnabled = true;
            this.ESTADOTextBox.IndiceCampoSelector = 0;
            this.ESTADOTextBox.LabelDescription = null;
            this.ESTADOTextBox.Location = new System.Drawing.Point(302, 311);
            this.ESTADOTextBox.Name = "ESTADOTextBox";
            this.ESTADOTextBox.NombreCampoSelector = "id";
            this.ESTADOTextBox.Query = "select id,nombre from estado";
            this.ESTADOTextBox.QueryDeSeleccion = "select id,nombre from estado where  id = @id";
            this.ESTADOTextBox.SelectedDataDisplaying = null;
            this.ESTADOTextBox.SelectedDataValue = null;
            this.ESTADOTextBox.Size = new System.Drawing.Size(246, 21);
            this.ESTADOTextBox.TabIndex = 21;
            this.ESTADOTextBox.ValueMember = "id";
            // 
            // EMPRESAButton
            // 
            this.EMPRESAButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.EMPRESAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EMPRESAButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EMPRESAButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.EMPRESAButton.Location = new System.Drawing.Point(128, 231);
            this.EMPRESAButton.Name = "EMPRESAButton";
            this.EMPRESAButton.Size = new System.Drawing.Size(24, 23);
            this.EMPRESAButton.TabIndex = 13;
            this.EMPRESAButton.UseVisualStyleBackColor = true;
            this.EMPRESAButton.Visible = false;
            // 
            // EMPRESAIDTextBox
            // 
            this.EMPRESAIDTextBox.BotonLookUp = this.EMPRESAButton;
            this.EMPRESAIDTextBox.Condicion = null;
            this.EMPRESAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.EMPRESAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.EMPRESAIDTextBox.DbValue = null;
            this.EMPRESAIDTextBox.Format_Expression = null;
            this.EMPRESAIDTextBox.IndiceCampoDescripcion = 2;
            this.EMPRESAIDTextBox.IndiceCampoSelector = 1;
            this.EMPRESAIDTextBox.IndiceCampoValue = 0;
            this.EMPRESAIDTextBox.LabelDescription = this.EMPRESALabel;
            this.EMPRESAIDTextBox.Location = new System.Drawing.Point(25, 233);
            this.EMPRESAIDTextBox.MostrarErrores = true;
            this.EMPRESAIDTextBox.Name = "EMPRESAIDTextBox";
            this.EMPRESAIDTextBox.NombreCampoSelector = "clave";
            this.EMPRESAIDTextBox.NombreCampoValue = "id";
            this.EMPRESAIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 30";
            this.EMPRESAIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 30 and  clave = @clave";
            this.EMPRESAIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 30 and  id = @id";
            this.EMPRESAIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.EMPRESAIDTextBox.TabIndex = 12;
            this.EMPRESAIDTextBox.Tag = 34;
            this.EMPRESAIDTextBox.TextDescription = null;
            this.EMPRESAIDTextBox.Titulo = "Empresas";
            this.EMPRESAIDTextBox.ValidarEntrada = true;
            this.EMPRESAIDTextBox.ValidationExpression = null;
            this.EMPRESAIDTextBox.Visible = false;
            // 
            // EMPRESALabel
            // 
            this.EMPRESALabel.AutoSize = true;
            this.EMPRESALabel.Location = new System.Drawing.Point(166, 234);
            this.EMPRESALabel.Name = "EMPRESALabel";
            this.EMPRESALabel.Size = new System.Drawing.Size(19, 13);
            this.EMPRESALabel.TabIndex = 166;
            this.EMPRESALabel.Text = "...";
            this.EMPRESALabel.Visible = false;
            // 
            // VENDEDORButton
            // 
            this.VENDEDORButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.VENDEDORButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VENDEDORButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VENDEDORButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.VENDEDORButton.Location = new System.Drawing.Point(463, 233);
            this.VENDEDORButton.Name = "VENDEDORButton";
            this.VENDEDORButton.Size = new System.Drawing.Size(24, 23);
            this.VENDEDORButton.TabIndex = 15;
            this.VENDEDORButton.UseVisualStyleBackColor = true;
            this.VENDEDORButton.Visible = false;
            // 
            // VENDEDORIDTextBox
            // 
            this.VENDEDORIDTextBox.BotonLookUp = this.VENDEDORButton;
            this.VENDEDORIDTextBox.Condicion = null;
            this.VENDEDORIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORIDTextBox.DbValue = null;
            this.VENDEDORIDTextBox.Format_Expression = null;
            this.VENDEDORIDTextBox.IndiceCampoDescripcion = 2;
            this.VENDEDORIDTextBox.IndiceCampoSelector = 1;
            this.VENDEDORIDTextBox.IndiceCampoValue = 0;
            this.VENDEDORIDTextBox.LabelDescription = this.VENDEDORLabel;
            this.VENDEDORIDTextBox.Location = new System.Drawing.Point(365, 234);
            this.VENDEDORIDTextBox.MostrarErrores = true;
            this.VENDEDORIDTextBox.Name = "VENDEDORIDTextBox";
            this.VENDEDORIDTextBox.NombreCampoSelector = "clave";
            this.VENDEDORIDTextBox.NombreCampoValue = "id";
            this.VENDEDORIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 22";
            this.VENDEDORIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 22 and  clave = @clave";
            this.VENDEDORIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 22 and  id = @id";
            this.VENDEDORIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.VENDEDORIDTextBox.TabIndex = 14;
            this.VENDEDORIDTextBox.Tag = 34;
            this.VENDEDORIDTextBox.TextDescription = null;
            this.VENDEDORIDTextBox.Titulo = "Vendedores";
            this.VENDEDORIDTextBox.ValidarEntrada = true;
            this.VENDEDORIDTextBox.ValidationExpression = null;
            this.VENDEDORIDTextBox.Visible = false;
            // 
            // VENDEDORLabel
            // 
            this.VENDEDORLabel.AutoSize = true;
            this.VENDEDORLabel.Location = new System.Drawing.Point(500, 236);
            this.VENDEDORLabel.Name = "VENDEDORLabel";
            this.VENDEDORLabel.Size = new System.Drawing.Size(19, 13);
            this.VENDEDORLabel.TabIndex = 163;
            this.VENDEDORLabel.Text = "...";
            this.VENDEDORLabel.Visible = false;
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
            this.SALUDOIDTextBox.Location = new System.Drawing.Point(730, 70);
            this.SALUDOIDTextBox.Name = "SALUDOIDTextBox";
            this.SALUDOIDTextBox.NombreCampoSelector = null;
            this.SALUDOIDTextBox.Query = "select ID,NOMBRE from saludo";
            this.SALUDOIDTextBox.QueryDeSeleccion = null;
            this.SALUDOIDTextBox.SelectedDataDisplaying = null;
            this.SALUDOIDTextBox.SelectedDataValue = null;
            this.SALUDOIDTextBox.Size = new System.Drawing.Size(159, 21);
            this.SALUDOIDTextBox.TabIndex = 7;
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
            this.LISTAPRECIOIDTextBox.Location = new System.Drawing.Point(730, 231);
            this.LISTAPRECIOIDTextBox.Name = "LISTAPRECIOIDTextBox";
            this.LISTAPRECIOIDTextBox.Size = new System.Drawing.Size(159, 21);
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
            this.DOMICILIOLabel.Location = new System.Drawing.Point(22, 256);
            this.DOMICILIOLabel.Name = "DOMICILIOLabel";
            this.DOMICILIOLabel.Size = new System.Drawing.Size(58, 13);
            this.DOMICILIOLabel.TabIndex = 1;
            this.DOMICILIOLabel.Text = "Domicilio";
            // 
            // DOMICILIOTextBox
            // 
            this.DOMICILIOTextBox.Location = new System.Drawing.Point(25, 272);
            this.DOMICILIOTextBox.Name = "DOMICILIOTextBox";
            this.DOMICILIOTextBox.Size = new System.Drawing.Size(522, 20);
            this.DOMICILIOTextBox.TabIndex = 17;
            // 
            // CREADOPOR_USERIDLabel
            // 
            this.CREADOPOR_USERIDLabel.AutoSize = true;
            this.CREADOPOR_USERIDLabel.Location = new System.Drawing.Point(563, 14);
            this.CREADOPOR_USERIDLabel.Name = "CREADOPOR_USERIDLabel";
            this.CREADOPOR_USERIDLabel.Size = new System.Drawing.Size(70, 13);
            this.CREADOPOR_USERIDLabel.TabIndex = 1;
            this.CREADOPOR_USERIDLabel.Text = "Creado Por";
            // 
            // TextBoxCREADOPOR_USERCLAVE
            // 
            this.TextBoxCREADOPOR_USERCLAVE.Location = new System.Drawing.Point(567, 29);
            this.TextBoxCREADOPOR_USERCLAVE.Name = "TextBoxCREADOPOR_USERCLAVE";
            this.TextBoxCREADOPOR_USERCLAVE.ReadOnly = true;
            this.TextBoxCREADOPOR_USERCLAVE.Size = new System.Drawing.Size(136, 20);
            this.TextBoxCREADOPOR_USERCLAVE.TabIndex = 5;
            this.TextBoxCREADOPOR_USERCLAVE.TabStop = false;
            // 
            // COLONIALabel
            // 
            this.COLONIALabel.AutoSize = true;
            this.COLONIALabel.Location = new System.Drawing.Point(574, 256);
            this.COLONIALabel.Name = "COLONIALabel";
            this.COLONIALabel.Size = new System.Drawing.Size(49, 13);
            this.COLONIALabel.TabIndex = 1;
            this.COLONIALabel.Text = "Colonia";
            // 
            // MODIFICADOPOR_USERIDLabel
            // 
            this.MODIFICADOPOR_USERIDLabel.AutoSize = true;
            this.MODIFICADOPOR_USERIDLabel.Location = new System.Drawing.Point(727, 13);
            this.MODIFICADOPOR_USERIDLabel.Name = "MODIFICADOPOR_USERIDLabel";
            this.MODIFICADOPOR_USERIDLabel.Size = new System.Drawing.Size(91, 13);
            this.MODIFICADOPOR_USERIDLabel.TabIndex = 1;
            this.MODIFICADOPOR_USERIDLabel.Text = "Modificado por";
            // 
            // COLONIATextBox
            // 
            this.COLONIATextBox.Location = new System.Drawing.Point(573, 272);
            this.COLONIATextBox.Name = "COLONIATextBox";
            this.COLONIATextBox.Size = new System.Drawing.Size(253, 20);
            this.COLONIATextBox.TabIndex = 18;
            // 
            // MODIFICADOPOR_USERIDTextBox
            // 
            this.MODIFICADOPOR_USERIDTextBox.Location = new System.Drawing.Point(730, 29);
            this.MODIFICADOPOR_USERIDTextBox.Name = "MODIFICADOPOR_USERIDTextBox";
            this.MODIFICADOPOR_USERIDTextBox.ReadOnly = true;
            this.MODIFICADOPOR_USERIDTextBox.Size = new System.Drawing.Size(158, 20);
            this.MODIFICADOPOR_USERIDTextBox.TabIndex = 6;
            this.MODIFICADOPOR_USERIDTextBox.TabStop = false;
            // 
            // LISTAPRECIOIDLabel
            // 
            this.LISTAPRECIOIDLabel.AutoSize = true;
            this.LISTAPRECIOIDLabel.Location = new System.Drawing.Point(728, 216);
            this.LISTAPRECIOIDLabel.Name = "LISTAPRECIOIDLabel";
            this.LISTAPRECIOIDLabel.Size = new System.Drawing.Size(98, 13);
            this.LISTAPRECIOIDLabel.TabIndex = 1;
            this.LISTAPRECIOIDLabel.Text = "Lista de Precios";
            this.LISTAPRECIOIDLabel.Visible = false;
            // 
            // VIGENCIATextBox
            // 
            this.VIGENCIATextBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.VIGENCIATextBox.Location = new System.Drawing.Point(412, 29);
            this.VIGENCIATextBox.Name = "VIGENCIATextBox";
            this.VIGENCIATextBox.Size = new System.Drawing.Size(124, 20);
            this.VIGENCIATextBox.TabIndex = 4;
            // 
            // CIUDADLabel
            // 
            this.CIUDADLabel.AutoSize = true;
            this.CIUDADLabel.Location = new System.Drawing.Point(22, 295);
            this.CIUDADLabel.Name = "CIUDADLabel";
            this.CIUDADLabel.Size = new System.Drawing.Size(46, 13);
            this.CIUDADLabel.TabIndex = 1;
            this.CIUDADLabel.Text = "Ciudad";
            // 
            // VIGENCIALabel
            // 
            this.VIGENCIALabel.AutoSize = true;
            this.VIGENCIALabel.Location = new System.Drawing.Point(412, 14);
            this.VIGENCIALabel.Name = "VIGENCIALabel";
            this.VIGENCIALabel.Size = new System.Drawing.Size(56, 13);
            this.VIGENCIALabel.TabIndex = 1;
            this.VIGENCIALabel.Text = "Vigencia";
            // 
            // CIUDADTextBox
            // 
            this.CIUDADTextBox.Location = new System.Drawing.Point(25, 311);
            this.CIUDADTextBox.Name = "CIUDADTextBox";
            this.CIUDADTextBox.Size = new System.Drawing.Size(257, 20);
            this.CIUDADTextBox.TabIndex = 20;
            // 
            // MUNICIPIOLabel
            // 
            this.MUNICIPIOLabel.AutoSize = true;
            this.MUNICIPIOLabel.Location = new System.Drawing.Point(848, 256);
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
            this.CONTACTO2TextBox.Location = new System.Drawing.Point(897, 391);
            this.CONTACTO2TextBox.Name = "CONTACTO2TextBox";
            this.CONTACTO2TextBox.Size = new System.Drawing.Size(205, 20);
            this.CONTACTO2TextBox.TabIndex = 32;
            // 
            // MUNICIPIOTextBox
            // 
            this.MUNICIPIOTextBox.Location = new System.Drawing.Point(848, 272);
            this.MUNICIPIOTextBox.Name = "MUNICIPIOTextBox";
            this.MUNICIPIOTextBox.Size = new System.Drawing.Size(258, 20);
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
            this.CONTACTO2Label.Location = new System.Drawing.Point(894, 375);
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
            this.ESTADOLabel.Location = new System.Drawing.Point(307, 295);
            this.ESTADOLabel.Name = "ESTADOLabel";
            this.ESTADOLabel.Size = new System.Drawing.Size(46, 13);
            this.ESTADOLabel.TabIndex = 1;
            this.ESTADOLabel.Text = "Estado";
            // 
            // CONTACTO1TextBox
            // 
            this.CONTACTO1TextBox.Location = new System.Drawing.Point(623, 391);
            this.CONTACTO1TextBox.Name = "CONTACTO1TextBox";
            this.CONTACTO1TextBox.Size = new System.Drawing.Size(266, 20);
            this.CONTACTO1TextBox.TabIndex = 31;
            // 
            // DESCRIPCIONTextBox
            // 
            this.DESCRIPCIONTextBox.Location = new System.Drawing.Point(26, 148);
            this.DESCRIPCIONTextBox.Name = "DESCRIPCIONTextBox";
            this.DESCRIPCIONTextBox.Size = new System.Drawing.Size(677, 20);
            this.DESCRIPCIONTextBox.TabIndex = 10;
            // 
            // VENDEDORIDLabel
            // 
            this.VENDEDORIDLabel.AutoSize = true;
            this.VENDEDORIDLabel.Location = new System.Drawing.Point(365, 217);
            this.VENDEDORIDLabel.Name = "VENDEDORIDLabel";
            this.VENDEDORIDLabel.Size = new System.Drawing.Size(61, 13);
            this.VENDEDORIDLabel.TabIndex = 1;
            this.VENDEDORIDLabel.Text = "Vendedor";
            // 
            // CONTACTO1Label
            // 
            this.CONTACTO1Label.AutoSize = true;
            this.CONTACTO1Label.Location = new System.Drawing.Point(619, 375);
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
            this.RFCTextBox.Location = new System.Drawing.Point(731, 108);
            this.RFCTextBox.Name = "RFCTextBox";
            this.RFCTextBox.Size = new System.Drawing.Size(158, 20);
            this.RFCTextBox.TabIndex = 9;
            // 
            // EMPRESAIDLabel
            // 
            this.EMPRESAIDLabel.AutoSize = true;
            this.EMPRESAIDLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EMPRESAIDLabel.Location = new System.Drawing.Point(30, 214);
            this.EMPRESAIDLabel.Name = "EMPRESAIDLabel";
            this.EMPRESAIDLabel.Size = new System.Drawing.Size(57, 15);
            this.EMPRESAIDLabel.TabIndex = 1;
            this.EMPRESAIDLabel.Text = "Empresa";
            this.EMPRESAIDLabel.Visible = false;
            // 
            // MEMOTextBox
            // 
            this.MEMOTextBox.Location = new System.Drawing.Point(26, 189);
            this.MEMOTextBox.Name = "MEMOTextBox";
            this.MEMOTextBox.Size = new System.Drawing.Size(677, 20);
            this.MEMOTextBox.TabIndex = 11;
            // 
            // PAISLabel
            // 
            this.PAISLabel.AutoSize = true;
            this.PAISLabel.Location = new System.Drawing.Point(569, 295);
            this.PAISLabel.Name = "PAISLabel";
            this.PAISLabel.Size = new System.Drawing.Size(33, 13);
            this.PAISLabel.TabIndex = 1;
            this.PAISLabel.Text = "País";
            // 
            // RFCLabel
            // 
            this.RFCLabel.AutoSize = true;
            this.RFCLabel.Location = new System.Drawing.Point(727, 94);
            this.RFCLabel.Name = "RFCLabel";
            this.RFCLabel.Size = new System.Drawing.Size(35, 13);
            this.RFCLabel.TabIndex = 1;
            this.RFCLabel.Text = "RFC:";
            // 
            // EMAIL2TextBox
            // 
            this.EMAIL2TextBox.Location = new System.Drawing.Point(302, 391);
            this.EMAIL2TextBox.Name = "EMAIL2TextBox";
            this.EMAIL2TextBox.Size = new System.Drawing.Size(302, 20);
            this.EMAIL2TextBox.TabIndex = 30;
            // 
            // SALUDOIDLabel
            // 
            this.SALUDOIDLabel.AutoSize = true;
            this.SALUDOIDLabel.Location = new System.Drawing.Point(727, 55);
            this.SALUDOIDLabel.Name = "SALUDOIDLabel";
            this.SALUDOIDLabel.Size = new System.Drawing.Size(46, 13);
            this.SALUDOIDLabel.TabIndex = 1;
            this.SALUDOIDLabel.Text = "Saludo";
            // 
            // EMAIL2Label
            // 
            this.EMAIL2Label.AutoSize = true;
            this.EMAIL2Label.Location = new System.Drawing.Point(303, 375);
            this.EMAIL2Label.Name = "EMAIL2Label";
            this.EMAIL2Label.Size = new System.Drawing.Size(52, 13);
            this.EMAIL2Label.TabIndex = 1;
            this.EMAIL2Label.Text = "E-mail 2";
            // 
            // RAZONSOCIALTextBox
            // 
            this.RAZONSOCIALTextBox.Location = new System.Drawing.Point(26, 108);
            this.RAZONSOCIALTextBox.Name = "RAZONSOCIALTextBox";
            this.RAZONSOCIALTextBox.Size = new System.Drawing.Size(677, 20);
            this.RAZONSOCIALTextBox.TabIndex = 8;
            // 
            // EMAIL1TextBox
            // 
            this.EMAIL1TextBox.Location = new System.Drawing.Point(25, 391);
            this.EMAIL1TextBox.Name = "EMAIL1TextBox";
            this.EMAIL1TextBox.Size = new System.Drawing.Size(257, 20);
            this.EMAIL1TextBox.TabIndex = 29;
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
            this.EMAIL1Label.Location = new System.Drawing.Point(27, 375);
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
            this.CODIGOPOSTALLabel.Location = new System.Drawing.Point(848, 295);
            this.CODIGOPOSTALLabel.Name = "CODIGOPOSTALLabel";
            this.CODIGOPOSTALLabel.Size = new System.Drawing.Size(85, 13);
            this.CODIGOPOSTALLabel.TabIndex = 1;
            this.CODIGOPOSTALLabel.Text = "Código Postal";
            // 
            // APELLIDOSTextBox
            // 
            this.APELLIDOSTextBox.Location = new System.Drawing.Point(350, 69);
            this.APELLIDOSTextBox.Name = "APELLIDOSTextBox";
            this.APELLIDOSTextBox.Size = new System.Drawing.Size(353, 20);
            this.APELLIDOSTextBox.TabIndex = 6;
            // 
            // NEXTELTextBox
            // 
            this.NEXTELTextBox.Location = new System.Drawing.Point(573, 351);
            this.NEXTELTextBox.Name = "NEXTELTextBox";
            this.NEXTELTextBox.Size = new System.Drawing.Size(116, 20);
            this.NEXTELTextBox.TabIndex = 28;
            // 
            // NOMBRESTextBox
            // 
            this.NOMBRESTextBox.Location = new System.Drawing.Point(26, 69);
            this.NOMBRESTextBox.Name = "NOMBRESTextBox";
            this.NOMBRESTextBox.Size = new System.Drawing.Size(296, 20);
            this.NOMBRESTextBox.TabIndex = 5;
            // 
            // NEXTELLabel
            // 
            this.NEXTELLabel.AutoSize = true;
            this.NEXTELLabel.Location = new System.Drawing.Point(569, 336);
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
            this.CODIGOPOSTALTextBox.Location = new System.Drawing.Point(849, 311);
            this.CODIGOPOSTALTextBox.Name = "CODIGOPOSTALTextBox";
            this.CODIGOPOSTALTextBox.Size = new System.Drawing.Size(116, 20);
            this.CODIGOPOSTALTextBox.TabIndex = 23;
            // 
            // CELULARTextBox
            // 
            this.CELULARTextBox.Location = new System.Drawing.Point(432, 352);
            this.CELULARTextBox.Name = "CELULARTextBox";
            this.CELULARTextBox.Size = new System.Drawing.Size(116, 20);
            this.CELULARTextBox.TabIndex = 27;
            // 
            // CELULARLabel
            // 
            this.CELULARLabel.AutoSize = true;
            this.CELULARLabel.Location = new System.Drawing.Point(439, 336);
            this.CELULARLabel.Name = "CELULARLabel";
            this.CELULARLabel.Size = new System.Drawing.Size(46, 13);
            this.CELULARLabel.TabIndex = 1;
            this.CELULARLabel.Text = "Celular";
            // 
            // TELEFONO1Label
            // 
            this.TELEFONO1Label.AutoSize = true;
            this.TELEFONO1Label.Location = new System.Drawing.Point(22, 336);
            this.TELEFONO1Label.Name = "TELEFONO1Label";
            this.TELEFONO1Label.Size = new System.Drawing.Size(68, 13);
            this.TELEFONO1Label.TabIndex = 1;
            this.TELEFONO1Label.Text = "Teléfono 1";
            // 
            // TELEFONO3TextBox
            // 
            this.TELEFONO3TextBox.Location = new System.Drawing.Point(302, 352);
            this.TELEFONO3TextBox.Name = "TELEFONO3TextBox";
            this.TELEFONO3TextBox.Size = new System.Drawing.Size(116, 20);
            this.TELEFONO3TextBox.TabIndex = 26;
            // 
            // TELEFONO3Label
            // 
            this.TELEFONO3Label.AutoSize = true;
            this.TELEFONO3Label.Location = new System.Drawing.Point(320, 336);
            this.TELEFONO3Label.Name = "TELEFONO3Label";
            this.TELEFONO3Label.Size = new System.Drawing.Size(68, 13);
            this.TELEFONO3Label.TabIndex = 1;
            this.TELEFONO3Label.Text = "Teléfono 3";
            // 
            // TELEFONO1TextBox
            // 
            this.TELEFONO1TextBox.Location = new System.Drawing.Point(25, 355);
            this.TELEFONO1TextBox.Name = "TELEFONO1TextBox";
            this.TELEFONO1TextBox.Size = new System.Drawing.Size(116, 20);
            this.TELEFONO1TextBox.TabIndex = 24;
            // 
            // TELEFONO2TextBox
            // 
            this.TELEFONO2TextBox.Location = new System.Drawing.Point(166, 352);
            this.TELEFONO2TextBox.Name = "TELEFONO2TextBox";
            this.TELEFONO2TextBox.Size = new System.Drawing.Size(116, 20);
            this.TELEFONO2TextBox.TabIndex = 25;
            // 
            // TELEFONO2Label
            // 
            this.TELEFONO2Label.AutoSize = true;
            this.TELEFONO2Label.Location = new System.Drawing.Point(162, 336);
            this.TELEFONO2Label.Name = "TELEFONO2Label";
            this.TELEFONO2Label.Size = new System.Drawing.Size(68, 13);
            this.TELEFONO2Label.TabIndex = 1;
            this.TELEFONO2Label.Text = "Teléfono 2";
            // 
            // CLAVETextBox
            // 
            this.CLAVETextBox.Location = new System.Drawing.Point(94, 43);
            this.CLAVETextBox.Name = "CLAVETextBox";
            this.CLAVETextBox.Size = new System.Drawing.Size(116, 20);
            this.CLAVETextBox.TabIndex = 2;
            this.CLAVETextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CLAVETextBox_Validating);
            // 
            // BTCancelar
            // 
            this.BTCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelar.Image = global::iPos.Properties.Resources.cancel_J;
            this.BTCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCancelar.Location = new System.Drawing.Point(624, 493);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(132, 30);
            this.BTCancelar.TabIndex = 38;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1119, 24);
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todasToolStripMenuItem,
            this.conSaldosToolStripMenuItem,
            this.ordenesDeCompraToolStripMenuItem,
            this.estadisticosToolStripMenuItem});
            this.ventasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ventasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ventasToolStripMenuItem.Text = "Compras";
            // 
            // todasToolStripMenuItem
            // 
            this.todasToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.todasToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.todasToolStripMenuItem.Name = "todasToolStripMenuItem";
            this.todasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.todasToolStripMenuItem.Text = "Todas";
            this.todasToolStripMenuItem.Click += new System.EventHandler(this.todasToolStripMenuItem_Click);
            // 
            // conSaldosToolStripMenuItem
            // 
            this.conSaldosToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.conSaldosToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.conSaldosToolStripMenuItem.Name = "conSaldosToolStripMenuItem";
            this.conSaldosToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.conSaldosToolStripMenuItem.Text = "Con Saldos";
            this.conSaldosToolStripMenuItem.Click += new System.EventHandler(this.conSaldosToolStripMenuItem_Click);
            // 
            // ordenesDeCompraToolStripMenuItem
            // 
            this.ordenesDeCompraToolStripMenuItem.Name = "ordenesDeCompraToolStripMenuItem";
            this.ordenesDeCompraToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.ordenesDeCompraToolStripMenuItem.Text = "Ordenes de compra";
            this.ordenesDeCompraToolStripMenuItem.Click += new System.EventHandler(this.ordenesDeCompraToolStripMenuItem_Click);
            // 
            // estadisticosToolStripMenuItem
            // 
            this.estadisticosToolStripMenuItem.Name = "estadisticosToolStripMenuItem";
            this.estadisticosToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.estadisticosToolStripMenuItem.Text = "Estadisticos";
            this.estadisticosToolStripMenuItem.Click += new System.EventHandler(this.estadisticosToolStripMenuItem_Click);
            // 
            // btnNotaIncidencia
            // 
            this.btnNotaIncidencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnNotaIncidencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnNotaIncidencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotaIncidencia.ForeColor = System.Drawing.Color.White;
            this.btnNotaIncidencia.Location = new System.Drawing.Point(721, 38);
            this.btnNotaIncidencia.Name = "btnNotaIncidencia";
            this.btnNotaIncidencia.Size = new System.Drawing.Size(142, 23);
            this.btnNotaIncidencia.TabIndex = 223;
            this.btnNotaIncidencia.Text = "Ver negociaciones";
            this.btnNotaIncidencia.UseVisualStyleBackColor = false;
            this.btnNotaIncidencia.Click += new System.EventHandler(this.btnNotaIncidencia_Click);
            // 
            // BTAgregarNota
            // 
            this.BTAgregarNota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTAgregarNota.Enabled = false;
            this.BTAgregarNota.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTAgregarNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregarNota.ForeColor = System.Drawing.Color.White;
            this.BTAgregarNota.Location = new System.Drawing.Point(525, 38);
            this.BTAgregarNota.Name = "BTAgregarNota";
            this.BTAgregarNota.Size = new System.Drawing.Size(164, 23);
            this.BTAgregarNota.TabIndex = 222;
            this.BTAgregarNota.Text = "Agregar negociacion";
            this.BTAgregarNota.UseVisualStyleBackColor = false;
            this.BTAgregarNota.Click += new System.EventHandler(this.BTAgregarNota_Click);
            // 
            // WFProveedorEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1119, 541);
            this.Controls.Add(this.btnNotaIncidencia);
            this.Controls.Add(this.BTAgregarNota);
            this.Controls.Add(this.menuStrip1);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFProveedorEdicion";
            this.Text = "PROVEEDOR";
            this.Load += new System.EventHandler(this.PERSONAEdit_Reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Label VENDEDORIDLabel;
        private System.Windows.Forms.Label CONTACTO1Label;
        private System.Windows.Forms.Label MEMOLabel;
        private System.Windows.Forms.TextBox RFCTextBox;
        private System.Windows.Forms.Label EMPRESAIDLabel;
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
        private System.Windows.Forms.Button EMPRESAButton;
        private Tools.TextBoxFB EMPRESAIDTextBox;
        private System.Windows.Forms.Label EMPRESALabel;
        private System.Windows.Forms.Button VENDEDORButton;
        private Tools.TextBoxFB VENDEDORIDTextBox;
        private System.Windows.Forms.Label VENDEDORLabel;
        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.ComboBoxFB ESTADOTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conSaldosToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PAGOSTextBox;
        private System.Windows.Forms.ComboBox REVISIONTextBox;
        private System.Windows.Forms.NumericTextBox DIASTextBox;
        private System.Windows.Forms.Label ldias;
        private System.Windows.Forms.Label lpagos;
        private System.Windows.Forms.Label lrevisio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem ordenesDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticosToolStripMenuItem;
        private System.Windows.Forms.CheckBox ESIMPORTADORTextBox;
        private System.Windows.Forms.Label ESIMPORTADORLabel;
        private System.Windows.Forms.ComboBoxFB PAISComboBoxFb;
        private System.Windows.Forms.Button PROVEECLIENTEIDButton;
        private Tools.TextBoxFB PROVEECLIENTEIDTextBox;
        private System.Windows.Forms.Label PROVEECLIENTEIDLabel;
        private System.Windows.Forms.NumericTextBox ADESCPESTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnNotaIncidencia;
        private System.Windows.Forms.Button BTAgregarNota;
    }
}

