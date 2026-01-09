
namespace iPos
{
    partial class WFCajaEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFCajaEditForm));
            this.RFV_CLAVE = new CustomValidation.RequiredFieldValidator();
            this.CLAVETextBox = new System.Windows.Forms.TextBox();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.CLAVELabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.NOMBRETextBox = new System.Windows.Forms.TextBox();
            this.NOMBRELabel = new System.Windows.Forms.Label();
            this.ACTIVOLabel = new System.Windows.Forms.Label();
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DESCRIPCIONTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NOMBREIMPRESORATextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TERMINALLabel = new System.Windows.Forms.Label();
            this.TERMINALTextBox = new iPos.Tools.TextBoxFB();
            this.TERMINALButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TERMINALSERVICIOSLabel = new System.Windows.Forms.Label();
            this.TERMINALSERVICIOSTextBox = new iPos.Tools.TextBoxFB();
            this.TERMINALSERVICIOSButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBancomerTerminal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBancomerCert = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlVerifone = new System.Windows.Forms.Panel();
            this.VERIFONEACTIVOCheckBox = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.VERIFONE_DEVICECONNECTIONTYPEKEYComboBox = new System.Windows.Forms.ComboBox();
            this.VERIFONE_DEVICEADDRESSKEYTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.VERIFONE_OPERATORLOCALETextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.VERIFONE_MERCHANTIDTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.VERIFONE_SHIFTNUMBERTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.VERIFONE_CONTRASENATextBox = new System.Windows.Forms.TextBox();
            this.lblVerifoneContrasena = new System.Windows.Forms.Label();
            this.VERIFONE_USERIDTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.IMPRESORACOMANDATextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.afiliacionTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.pnlVerifone.SuspendLayout();
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
            this.CLAVETextBox.Location = new System.Drawing.Point(151, 19);
            this.CLAVETextBox.Name = "CLAVETextBox";
            this.CLAVETextBox.Size = new System.Drawing.Size(210, 20);
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
            this.BTCancelar.Location = new System.Drawing.Point(337, 441);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(128, 32);
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
            this.BTIniciaEdicion.Location = new System.Drawing.Point(7, 450);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(66, 23);
            this.BTIniciaEdicion.TabIndex = 46;
            this.BTIniciaEdicion.Text = "Editar";
            this.BTIniciaEdicion.UseVisualStyleBackColor = false;
            this.BTIniciaEdicion.Visible = false;
            this.BTIniciaEdicion.Click += new System.EventHandler(this.BTIniciaEdicion_Click);
            // 
            // CLAVELabel
            // 
            this.CLAVELabel.AutoSize = true;
            this.CLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLAVELabel.ForeColor = System.Drawing.Color.White;
            this.CLAVELabel.Location = new System.Drawing.Point(101, 22);
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
            this.button1.Location = new System.Drawing.Point(159, 441);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NOMBRETextBox
            // 
            this.NOMBRETextBox.Location = new System.Drawing.Point(144, 5);
            this.NOMBRETextBox.Name = "NOMBRETextBox";
            this.NOMBRETextBox.Size = new System.Drawing.Size(314, 20);
            this.NOMBRETextBox.TabIndex = 2;
            // 
            // NOMBRELabel
            // 
            this.NOMBRELabel.AutoSize = true;
            this.NOMBRELabel.ForeColor = System.Drawing.Color.White;
            this.NOMBRELabel.Location = new System.Drawing.Point(83, 8);
            this.NOMBRELabel.Name = "NOMBRELabel";
            this.NOMBRELabel.Size = new System.Drawing.Size(54, 13);
            this.NOMBRELabel.TabIndex = 1;
            this.NOMBRELabel.Text = "Nombre:";
            // 
            // ACTIVOLabel
            // 
            this.ACTIVOLabel.AutoSize = true;
            this.ACTIVOLabel.ForeColor = System.Drawing.Color.White;
            this.ACTIVOLabel.Location = new System.Drawing.Point(90, 40);
            this.ACTIVOLabel.Name = "ACTIVOLabel";
            this.ACTIVOLabel.Size = new System.Drawing.Size(47, 13);
            this.ACTIVOLabel.TabIndex = 1;
            this.ACTIVOLabel.Text = "Activo:";
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(144, 40);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ACTIVOTextBox.TabIndex = 5;
            this.ACTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(59, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Descripcion:";
            // 
            // DESCRIPCIONTextBox
            // 
            this.DESCRIPCIONTextBox.Location = new System.Drawing.Point(144, 68);
            this.DESCRIPCIONTextBox.Multiline = true;
            this.DESCRIPCIONTextBox.Name = "DESCRIPCIONTextBox";
            this.DESCRIPCIONTextBox.Size = new System.Drawing.Size(314, 36);
            this.DESCRIPCIONTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(71, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Impresora:";
            // 
            // NOMBREIMPRESORATextBox
            // 
            this.NOMBREIMPRESORATextBox.Enabled = false;
            this.NOMBREIMPRESORATextBox.Location = new System.Drawing.Point(144, 116);
            this.NOMBREIMPRESORATextBox.Name = "NOMBREIMPRESORATextBox";
            this.NOMBREIMPRESORATextBox.Size = new System.Drawing.Size(315, 20);
            this.NOMBREIMPRESORATextBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(78, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Terminal:";
            // 
            // TERMINALLabel
            // 
            this.TERMINALLabel.AutoSize = true;
            this.TERMINALLabel.Location = new System.Drawing.Point(272, 157);
            this.TERMINALLabel.Name = "TERMINALLabel";
            this.TERMINALLabel.Size = new System.Drawing.Size(19, 13);
            this.TERMINALLabel.TabIndex = 161;
            this.TERMINALLabel.Text = "...";
            // 
            // TERMINALTextBox
            // 
            this.TERMINALTextBox.BotonLookUp = this.TERMINALButton;
            this.TERMINALTextBox.Condicion = null;
            this.TERMINALTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TERMINALTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TERMINALTextBox.DbValue = null;
            this.TERMINALTextBox.Format_Expression = null;
            this.TERMINALTextBox.IndiceCampoDescripcion = 2;
            this.TERMINALTextBox.IndiceCampoSelector = 1;
            this.TERMINALTextBox.IndiceCampoValue = 1;
            this.TERMINALTextBox.LabelDescription = this.TERMINALLabel;
            this.TERMINALTextBox.Location = new System.Drawing.Point(144, 148);
            this.TERMINALTextBox.MostrarErrores = true;
            this.TERMINALTextBox.Name = "TERMINALTextBox";
            this.TERMINALTextBox.NombreCampoSelector = "terminal";
            this.TERMINALTextBox.NombreCampoValue = "terminal";
            this.TERMINALTextBox.Query = "select id, terminal, sucursalclave from terminalpagoservicio where (esservicio <>" +
    " \'S\' or esservicio is null)";
            this.TERMINALTextBox.QueryDeSeleccion = "select id, terminal , sucursalclave from terminalpagoservicio where  terminal = @" +
    "terminal and (esservicio <> \'S\' or esservicio is null)";
            this.TERMINALTextBox.QueryPorDBValue = "select id, terminal , sucursalclave from terminalpagoservicio where  terminal = @" +
    "terminal and (esservicio <> \'S\' or esservicio is null)";
            this.TERMINALTextBox.Size = new System.Drawing.Size(95, 20);
            this.TERMINALTextBox.TabIndex = 159;
            this.TERMINALTextBox.Tag = 34;
            this.TERMINALTextBox.TextDescription = null;
            this.TERMINALTextBox.Titulo = "Terminal";
            this.TERMINALTextBox.ValidarEntrada = true;
            this.TERMINALTextBox.ValidationExpression = null;
            // 
            // TERMINALButton
            // 
            this.TERMINALButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.TERMINALButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TERMINALButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TERMINALButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.TERMINALButton.Location = new System.Drawing.Point(242, 147);
            this.TERMINALButton.Name = "TERMINALButton";
            this.TERMINALButton.Size = new System.Drawing.Size(24, 23);
            this.TERMINALButton.TabIndex = 160;
            this.TERMINALButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(42, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 162;
            this.label5.Text = "Terminal serv. :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TERMINALSERVICIOSLabel
            // 
            this.TERMINALSERVICIOSLabel.AutoSize = true;
            this.TERMINALSERVICIOSLabel.Location = new System.Drawing.Point(272, 190);
            this.TERMINALSERVICIOSLabel.Name = "TERMINALSERVICIOSLabel";
            this.TERMINALSERVICIOSLabel.Size = new System.Drawing.Size(19, 13);
            this.TERMINALSERVICIOSLabel.TabIndex = 165;
            this.TERMINALSERVICIOSLabel.Text = "...";
            // 
            // TERMINALSERVICIOSTextBox
            // 
            this.TERMINALSERVICIOSTextBox.BotonLookUp = this.TERMINALSERVICIOSButton;
            this.TERMINALSERVICIOSTextBox.Condicion = null;
            this.TERMINALSERVICIOSTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TERMINALSERVICIOSTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TERMINALSERVICIOSTextBox.DbValue = null;
            this.TERMINALSERVICIOSTextBox.Format_Expression = null;
            this.TERMINALSERVICIOSTextBox.IndiceCampoDescripcion = 2;
            this.TERMINALSERVICIOSTextBox.IndiceCampoSelector = 1;
            this.TERMINALSERVICIOSTextBox.IndiceCampoValue = 1;
            this.TERMINALSERVICIOSTextBox.LabelDescription = this.TERMINALSERVICIOSLabel;
            this.TERMINALSERVICIOSTextBox.Location = new System.Drawing.Point(144, 181);
            this.TERMINALSERVICIOSTextBox.MostrarErrores = true;
            this.TERMINALSERVICIOSTextBox.Name = "TERMINALSERVICIOSTextBox";
            this.TERMINALSERVICIOSTextBox.NombreCampoSelector = "terminal";
            this.TERMINALSERVICIOSTextBox.NombreCampoValue = "terminal";
            this.TERMINALSERVICIOSTextBox.Query = "select id, terminal, sucursalclave from terminalpagoservicio where esservicio = \'" +
    "S\'    ";
            this.TERMINALSERVICIOSTextBox.QueryDeSeleccion = "select id, terminal , sucursalclave from terminalpagoservicio where  terminal = @" +
    "terminal and esservicio = \'S\'";
            this.TERMINALSERVICIOSTextBox.QueryPorDBValue = "select id, terminal , sucursalclave from terminalpagoservicio where  terminal = @" +
    "terminal and esservicio = \'S\'";
            this.TERMINALSERVICIOSTextBox.Size = new System.Drawing.Size(95, 20);
            this.TERMINALSERVICIOSTextBox.TabIndex = 163;
            this.TERMINALSERVICIOSTextBox.Tag = 34;
            this.TERMINALSERVICIOSTextBox.TextDescription = null;
            this.TERMINALSERVICIOSTextBox.Titulo = "Terminal de Pago de Servicios";
            this.TERMINALSERVICIOSTextBox.ValidarEntrada = true;
            this.TERMINALSERVICIOSTextBox.ValidationExpression = null;
            // 
            // TERMINALSERVICIOSButton
            // 
            this.TERMINALSERVICIOSButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.TERMINALSERVICIOSButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TERMINALSERVICIOSButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TERMINALSERVICIOSButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.TERMINALSERVICIOSButton.Location = new System.Drawing.Point(242, 180);
            this.TERMINALSERVICIOSButton.Name = "TERMINALSERVICIOSButton";
            this.TERMINALSERVICIOSButton.Size = new System.Drawing.Size(24, 23);
            this.TERMINALSERVICIOSButton.TabIndex = 164;
            this.TERMINALSERVICIOSButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 166;
            this.label4.Text = "Terminal Bancomer:";
            this.label4.Visible = false;
            // 
            // txtBancomerTerminal
            // 
            this.txtBancomerTerminal.Enabled = false;
            this.txtBancomerTerminal.Location = new System.Drawing.Point(144, 213);
            this.txtBancomerTerminal.MaxLength = 8;
            this.txtBancomerTerminal.Name = "txtBancomerTerminal";
            this.txtBancomerTerminal.Size = new System.Drawing.Size(133, 20);
            this.txtBancomerTerminal.TabIndex = 167;
            this.txtBancomerTerminal.Visible = false;
            this.txtBancomerTerminal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBancomerTerminal_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 168;
            this.label6.Text = "Certificado Bancomer:";
            this.label6.Visible = false;
            // 
            // txtBancomerCert
            // 
            this.txtBancomerCert.Location = new System.Drawing.Point(144, 276);
            this.txtBancomerCert.Name = "txtBancomerCert";
            this.txtBancomerCert.Size = new System.Drawing.Size(314, 20);
            this.txtBancomerCert.TabIndex = 169;
            this.txtBancomerCert.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pnlVerifone);
            this.panel1.Controls.Add(this.IMPRESORACOMANDATextBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.afiliacionTextBox);
            this.panel1.Controls.Add(this.txtBancomerCert);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtBancomerTerminal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TERMINALSERVICIOSButton);
            this.panel1.Controls.Add(this.TERMINALSERVICIOSTextBox);
            this.panel1.Controls.Add(this.TERMINALSERVICIOSLabel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TERMINALButton);
            this.panel1.Controls.Add(this.TERMINALTextBox);
            this.panel1.Controls.Add(this.TERMINALLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.NOMBREIMPRESORATextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DESCRIPCIONTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ACTIVOTextBox);
            this.panel1.Controls.Add(this.ACTIVOLabel);
            this.panel1.Controls.Add(this.NOMBRELabel);
            this.panel1.Controls.Add(this.NOMBRETextBox);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(7, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 378);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            // 
            // pnlVerifone
            // 
            this.pnlVerifone.Controls.Add(this.VERIFONEACTIVOCheckBox);
            this.pnlVerifone.Controls.Add(this.label16);
            this.pnlVerifone.Controls.Add(this.label11);
            this.pnlVerifone.Controls.Add(this.VERIFONE_DEVICECONNECTIONTYPEKEYComboBox);
            this.pnlVerifone.Controls.Add(this.VERIFONE_DEVICEADDRESSKEYTextBox);
            this.pnlVerifone.Controls.Add(this.label13);
            this.pnlVerifone.Controls.Add(this.VERIFONE_OPERATORLOCALETextBox);
            this.pnlVerifone.Controls.Add(this.label14);
            this.pnlVerifone.Controls.Add(this.VERIFONE_MERCHANTIDTextBox);
            this.pnlVerifone.Controls.Add(this.label15);
            this.pnlVerifone.Controls.Add(this.VERIFONE_SHIFTNUMBERTextBox);
            this.pnlVerifone.Controls.Add(this.label12);
            this.pnlVerifone.Controls.Add(this.VERIFONE_CONTRASENATextBox);
            this.pnlVerifone.Controls.Add(this.lblVerifoneContrasena);
            this.pnlVerifone.Controls.Add(this.VERIFONE_USERIDTextBox);
            this.pnlVerifone.Controls.Add(this.label10);
            this.pnlVerifone.Controls.Add(this.label9);
            this.pnlVerifone.Location = new System.Drawing.Point(488, 71);
            this.pnlVerifone.Name = "pnlVerifone";
            this.pnlVerifone.Size = new System.Drawing.Size(403, 293);
            this.pnlVerifone.TabIndex = 175;
            this.pnlVerifone.Visible = false;
            // 
            // VERIFONEACTIVOCheckBox
            // 
            this.VERIFONEACTIVOCheckBox.AutoSize = true;
            this.VERIFONEACTIVOCheckBox.Location = new System.Drawing.Point(163, 35);
            this.VERIFONEACTIVOCheckBox.Name = "VERIFONEACTIVOCheckBox";
            this.VERIFONEACTIVOCheckBox.Size = new System.Drawing.Size(15, 14);
            this.VERIFONEACTIVOCheckBox.TabIndex = 183;
            this.VERIFONEACTIVOCheckBox.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(19, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 182;
            this.label16.Text = "Activo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(21, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 181;
            this.label11.Text = "Tipo conexion:";
            // 
            // VERIFONE_DEVICECONNECTIONTYPEKEYComboBox
            // 
            this.VERIFONE_DEVICECONNECTIONTYPEKEYComboBox.FormattingEnabled = true;
            this.VERIFONE_DEVICECONNECTIONTYPEKEYComboBox.Items.AddRange(new object[] {
            "TCP/IP",
            "SERIAL"});
            this.VERIFONE_DEVICECONNECTIONTYPEKEYComboBox.Location = new System.Drawing.Point(164, 220);
            this.VERIFONE_DEVICECONNECTIONTYPEKEYComboBox.Name = "VERIFONE_DEVICECONNECTIONTYPEKEYComboBox";
            this.VERIFONE_DEVICECONNECTIONTYPEKEYComboBox.Size = new System.Drawing.Size(198, 21);
            this.VERIFONE_DEVICECONNECTIONTYPEKEYComboBox.TabIndex = 180;
            // 
            // VERIFONE_DEVICEADDRESSKEYTextBox
            // 
            this.VERIFONE_DEVICEADDRESSKEYTextBox.Location = new System.Drawing.Point(164, 256);
            this.VERIFONE_DEVICEADDRESSKEYTextBox.MaxLength = 64;
            this.VERIFONE_DEVICEADDRESSKEYTextBox.Name = "VERIFONE_DEVICEADDRESSKEYTextBox";
            this.VERIFONE_DEVICEADDRESSKEYTextBox.Size = new System.Drawing.Size(198, 20);
            this.VERIFONE_DEVICEADDRESSKEYTextBox.TabIndex = 179;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(20, 259);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 13);
            this.label13.TabIndex = 178;
            this.label13.Text = "Direccion dispositivo:";
            // 
            // VERIFONE_OPERATORLOCALETextBox
            // 
            this.VERIFONE_OPERATORLOCALETextBox.Location = new System.Drawing.Point(164, 190);
            this.VERIFONE_OPERATORLOCALETextBox.MaxLength = 64;
            this.VERIFONE_OPERATORLOCALETextBox.Name = "VERIFONE_OPERATORLOCALETextBox";
            this.VERIFONE_OPERATORLOCALETextBox.Size = new System.Drawing.Size(198, 20);
            this.VERIFONE_OPERATORLOCALETextBox.TabIndex = 177;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(20, 193);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 176;
            this.label14.Text = "Operador local:";
            // 
            // VERIFONE_MERCHANTIDTextBox
            // 
            this.VERIFONE_MERCHANTIDTextBox.Location = new System.Drawing.Point(164, 160);
            this.VERIFONE_MERCHANTIDTextBox.MaxLength = 64;
            this.VERIFONE_MERCHANTIDTextBox.Name = "VERIFONE_MERCHANTIDTextBox";
            this.VERIFONE_MERCHANTIDTextBox.Size = new System.Drawing.Size(198, 20);
            this.VERIFONE_MERCHANTIDTextBox.TabIndex = 175;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(20, 163);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 13);
            this.label15.TabIndex = 174;
            this.label15.Text = "Merchant Id:";
            // 
            // VERIFONE_SHIFTNUMBERTextBox
            // 
            this.VERIFONE_SHIFTNUMBERTextBox.Location = new System.Drawing.Point(164, 128);
            this.VERIFONE_SHIFTNUMBERTextBox.MaxLength = 64;
            this.VERIFONE_SHIFTNUMBERTextBox.Name = "VERIFONE_SHIFTNUMBERTextBox";
            this.VERIFONE_SHIFTNUMBERTextBox.Size = new System.Drawing.Size(198, 20);
            this.VERIFONE_SHIFTNUMBERTextBox.TabIndex = 173;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(20, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 172;
            this.label12.Text = "Shift Number:";
            // 
            // VERIFONE_CONTRASENATextBox
            // 
            this.VERIFONE_CONTRASENATextBox.Location = new System.Drawing.Point(164, 95);
            this.VERIFONE_CONTRASENATextBox.MaxLength = 64;
            this.VERIFONE_CONTRASENATextBox.Name = "VERIFONE_CONTRASENATextBox";
            this.VERIFONE_CONTRASENATextBox.Size = new System.Drawing.Size(198, 20);
            this.VERIFONE_CONTRASENATextBox.TabIndex = 171;
            // 
            // lblVerifoneContrasena
            // 
            this.lblVerifoneContrasena.AutoSize = true;
            this.lblVerifoneContrasena.ForeColor = System.Drawing.Color.White;
            this.lblVerifoneContrasena.Location = new System.Drawing.Point(20, 98);
            this.lblVerifoneContrasena.Name = "lblVerifoneContrasena";
            this.lblVerifoneContrasena.Size = new System.Drawing.Size(75, 13);
            this.lblVerifoneContrasena.TabIndex = 170;
            this.lblVerifoneContrasena.Text = "Contraseña:";
            // 
            // VERIFONE_USERIDTextBox
            // 
            this.VERIFONE_USERIDTextBox.Location = new System.Drawing.Point(164, 65);
            this.VERIFONE_USERIDTextBox.MaxLength = 64;
            this.VERIFONE_USERIDTextBox.Name = "VERIFONE_USERIDTextBox";
            this.VERIFONE_USERIDTextBox.Size = new System.Drawing.Size(198, 20);
            this.VERIFONE_USERIDTextBox.TabIndex = 169;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(20, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 168;
            this.label10.Text = "User Id:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 13);
            this.label9.TabIndex = 167;
            this.label9.Text = "TERMINAL VERIFONE";
            // 
            // IMPRESORACOMANDATextBox
            // 
            this.IMPRESORACOMANDATextBox.Location = new System.Drawing.Point(143, 315);
            this.IMPRESORACOMANDATextBox.Name = "IMPRESORACOMANDATextBox";
            this.IMPRESORACOMANDATextBox.Size = new System.Drawing.Size(315, 20);
            this.IMPRESORACOMANDATextBox.TabIndex = 174;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(18, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 13);
            this.label8.TabIndex = 173;
            this.label8.Text = "Impresora comanda:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 13);
            this.label7.TabIndex = 172;
            this.label7.Text = "Afiliacion Bancomer:";
            this.label7.Visible = false;
            // 
            // afiliacionTextBox
            // 
            this.afiliacionTextBox.Enabled = false;
            this.afiliacionTextBox.Location = new System.Drawing.Point(144, 246);
            this.afiliacionTextBox.MaxLength = 8;
            this.afiliacionTextBox.Name = "afiliacionTextBox";
            this.afiliacionTextBox.Size = new System.Drawing.Size(133, 20);
            this.afiliacionTextBox.TabIndex = 171;
            this.afiliacionTextBox.Visible = false;
            // 
            // WFCajaEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(927, 485);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CLAVELabel);
            this.Controls.Add(this.CLAVETextBox);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFCajaEditForm";
            this.Text = "CAJA";
            this.Load += new System.EventHandler(this.CAJAEdit_Reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlVerifone.ResumeLayout(false);
            this.pnlVerifone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

  }

  #endregion



        private System.Windows.Forms.TextBox CLAVETextBox;
  
  private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
  private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.Label LBError;




  private CustomValidation.RequiredFieldValidator RFV_CLAVE;
  private System.Windows.Forms.Label CLAVELabel;
  private System.Windows.Forms.Button BTIniciaEdicion;
  private System.Windows.Forms.Button BTCancelar;
  private System.Windows.Forms.TextBox NOMBRETextBox;
  private System.Windows.Forms.Label NOMBRELabel;
  private System.Windows.Forms.Label ACTIVOLabel;
  private System.Windows.Forms.CheckBox ACTIVOTextBox;
  private System.Windows.Forms.Label label1;
  private System.Windows.Forms.TextBox DESCRIPCIONTextBox;
  private System.Windows.Forms.Label label2;
  private System.Windows.Forms.TextBox NOMBREIMPRESORATextBox;
  private System.Windows.Forms.Label label3;
  private System.Windows.Forms.Label TERMINALLabel;
  private Tools.TextBoxFB TERMINALTextBox;
  private System.Windows.Forms.Button TERMINALButton;
  private System.Windows.Forms.Label label5;
  private System.Windows.Forms.Label TERMINALSERVICIOSLabel;
  private Tools.TextBoxFB TERMINALSERVICIOSTextBox;
  private System.Windows.Forms.Button TERMINALSERVICIOSButton;
  private System.Windows.Forms.Label label4;
  private System.Windows.Forms.TextBox txtBancomerTerminal;
  private System.Windows.Forms.Label label6;
  private System.Windows.Forms.TextBox txtBancomerCert;
  private System.Windows.Forms.Panel panel1;
  private System.Windows.Forms.TextBox afiliacionTextBox;
  private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox IMPRESORACOMANDATextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlVerifone;
        private System.Windows.Forms.TextBox VERIFONE_DEVICEADDRESSKEYTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox VERIFONE_OPERATORLOCALETextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox VERIFONE_MERCHANTIDTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox VERIFONE_SHIFTNUMBERTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox VERIFONE_CONTRASENATextBox;
        private System.Windows.Forms.Label lblVerifoneContrasena;
        private System.Windows.Forms.TextBox VERIFONE_USERIDTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox VERIFONE_DEVICECONNECTIONTYPEKEYComboBox;
        private System.Windows.Forms.CheckBox VERIFONEACTIVOCheckBox;
        private System.Windows.Forms.Label label16;
    }
}

