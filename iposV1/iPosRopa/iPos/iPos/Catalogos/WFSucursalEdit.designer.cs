
namespace iPos
{
    partial class WFSucursalEdit
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
            System.Windows.Forms.Label dESCRIPCIONLabel;
            System.Windows.Forms.Label pROVEEDOR1IDLabel;
            System.Windows.Forms.Label LBCantidadStock;
            System.Windows.Forms.Label label22;
            FirebirdSql.Data.FirebirdClient.FbParameter fbParameter1 = new FirebirdSql.Data.FirebirdClient.FbParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFSucursalEdit));
            this.ACTIVOLabel = new System.Windows.Forms.Label();
            this.CLAVELabel = new System.Windows.Forms.Label();
            this.NOMBRELabel = new System.Windows.Forms.Label();
            this.CLAVETextBox = new System.Windows.Forms.TextBox();
            this.NOMBRETextBox = new System.Windows.Forms.TextBox();
            this.RFV_CLAVE = new CustomValidation.RequiredFieldValidator();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.IMNUPRODTextBox = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.EMPPROVButton = new System.Windows.Forms.Button();
            this.EMPPROVTextBox = new iPos.Tools.TextBoxFB();
            this.EMPPROVLabel = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.LISTAPRECIOCLAVETextBox = new System.Windows.Forms.ComboBoxFB();
            this.label26 = new System.Windows.Forms.Label();
            this.CUENTAPOLIZATextBox = new System.Windows.Forms.TextBox();
            this.txtRutaRespaldoRed = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.CUENTAREFERENCIATextBox = new System.Windows.Forms.TextBox();
            this.BANCOCLAVETextBox = new System.Windows.Forms.ComboBoxFB();
            this.txtNombreRespaldoBD = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.PREFIJOPRECIOXDESCUENTOTextBox = new System.Windows.Forms.TextBox();
            this.MANEJAPRECIOXDESCUENTOTextBox = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtRutaRespaldoDestino = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtRutaRespaldoOrigen = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.PORC_AUMENTO_PRECIOTextBox = new System.Windows.Forms.NumericTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.SURTIDORButton = new System.Windows.Forms.Button();
            this.SURTIDORTextBox = new iPos.Tools.TextBoxFB();
            this.SURTIDORLabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.PROVEEDORCLAVEButton = new System.Windows.Forms.Button();
            this.PROVEEDORCLAVETextBox = new iPos.Tools.TextBoxFB();
            this.PROVEEDORCLAVELabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.POR_FACT_ELECTTextBox = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ESFRANQUICIATextBox = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CLIENTECLAVEButton = new System.Windows.Forms.Button();
            this.CLIENTECLAVETextBox = new iPos.Tools.TextBoxFB();
            this.CLIENTECLAVELabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PRECIOENVIOTRASLADOTextBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MOSTRARPRECIOREALTextBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PRECIORECEPCIONTRASLADOTextBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ESMATRIZTextBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.LISTA_PRECIO_TRASPASOTextBox = new System.Windows.Forms.ComboBox();
            this.LISTAPRECIOIDLabel = new System.Windows.Forms.Label();
            this.MAXDOCTOSPENDIENTESTextBox = new System.Windows.Forms.NumericTextBox();
            this.DESCRIPCIONTextBox = new System.Windows.Forms.TextBox();
            this.GRUPOSUCURSALIDButton = new System.Windows.Forms.Button();
            this.GRUPOSUCURSALIDTextBox = new iPos.Tools.TextBoxFB();
            this.GRUPOSUCURSALIDLabel = new System.Windows.Forms.Label();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ENTREGA_DISTANCIATextBox = new System.Windows.Forms.NumericTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.ENTREGA_SAT_COLONIAIDButton = new System.Windows.Forms.Button();
            this.ENTREGA_SAT_COLONIAIDLabel = new System.Windows.Forms.Label();
            this.ENTREGA_SAT_COLONIAIDTextBox = new iPos.Tools.TextBoxFB();
            this.ENTREGA_SAT_MUNICIPIOIDButton = new System.Windows.Forms.Button();
            this.ENTREGA_SAT_MUNICIPIOIDLabel = new System.Windows.Forms.Label();
            this.ENTREGA_SAT_MUNICIPIOIDTextBox = new iPos.Tools.TextBoxFB();
            this.ENTREGA_SAT_LOCALIDADIDButton = new System.Windows.Forms.Button();
            this.ENTREGA_SAT_LOCALIDADIDLabel = new System.Windows.Forms.Label();
            this.ENTREGA_SAT_LOCALIDADIDTextBox = new iPos.Tools.TextBoxFB();
            this.label35 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ENTREGAESTADOTextBox = new System.Windows.Forms.ComboBoxFB();
            this.ENTREGACODIGOPOSTALTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ENTREGANUMEROINTERIORTextBox = new System.Windows.Forms.TextBox();
            this.ENTREGANUMEROEXTERIORTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ENTREGACALLETextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.ENTREGAREFERENCIADOMTextBox = new System.Windows.Forms.TextBox();
            dESCRIPCIONLabel = new System.Windows.Forms.Label();
            pROVEEDOR1IDLabel = new System.Windows.Forms.Label();
            LBCantidadStock = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dESCRIPCIONLabel
            // 
            dESCRIPCIONLabel.AutoSize = true;
            dESCRIPCIONLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            dESCRIPCIONLabel.ForeColor = System.Drawing.Color.White;
            dESCRIPCIONLabel.Location = new System.Drawing.Point(11, 64);
            dESCRIPCIONLabel.Name = "dESCRIPCIONLabel";
            dESCRIPCIONLabel.Size = new System.Drawing.Size(74, 13);
            dESCRIPCIONLabel.TabIndex = 49;
            dESCRIPCIONLabel.Text = "Descripción";
            // 
            // pROVEEDOR1IDLabel
            // 
            pROVEEDOR1IDLabel.AutoSize = true;
            pROVEEDOR1IDLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            pROVEEDOR1IDLabel.ForeColor = System.Drawing.Color.White;
            pROVEEDOR1IDLabel.Location = new System.Drawing.Point(11, 89);
            pROVEEDOR1IDLabel.Name = "pROVEEDOR1IDLabel";
            pROVEEDOR1IDLabel.Size = new System.Drawing.Size(113, 13);
            pROVEEDOR1IDLabel.TabIndex = 157;
            pROVEEDOR1IDLabel.Text = "Grupo Sucursal Id:";
            // 
            // LBCantidadStock
            // 
            LBCantidadStock.AutoSize = true;
            LBCantidadStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            LBCantidadStock.ForeColor = System.Drawing.Color.White;
            LBCantidadStock.Location = new System.Drawing.Point(10, 139);
            LBCantidadStock.Name = "LBCantidadStock";
            LBCantidadStock.Size = new System.Drawing.Size(112, 13);
            LBCantidadStock.TabIndex = 171;
            LBCantidadStock.Text = "Max doctos pend.:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            label22.ForeColor = System.Drawing.Color.White;
            label22.Location = new System.Drawing.Point(392, 469);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(145, 13);
            label22.TabIndex = 211;
            label22.Text = "Prefijo precio descuento";
            // 
            // ACTIVOLabel
            // 
            this.ACTIVOLabel.AutoSize = true;
            this.ACTIVOLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ACTIVOLabel.ForeColor = System.Drawing.Color.White;
            this.ACTIVOLabel.Location = new System.Drawing.Point(11, 35);
            this.ACTIVOLabel.Name = "ACTIVOLabel";
            this.ACTIVOLabel.Size = new System.Drawing.Size(47, 13);
            this.ACTIVOLabel.TabIndex = 1;
            this.ACTIVOLabel.Text = "Activo:";
            // 
            // CLAVELabel
            // 
            this.CLAVELabel.AutoSize = true;
            this.CLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLAVELabel.Location = new System.Drawing.Point(14, 21);
            this.CLAVELabel.Name = "CLAVELabel";
            this.CLAVELabel.Size = new System.Drawing.Size(43, 13);
            this.CLAVELabel.TabIndex = 1;
            this.CLAVELabel.Text = "Clave:";
            // 
            // NOMBRELabel
            // 
            this.NOMBRELabel.AutoSize = true;
            this.NOMBRELabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.NOMBRELabel.ForeColor = System.Drawing.Color.White;
            this.NOMBRELabel.Location = new System.Drawing.Point(10, 12);
            this.NOMBRELabel.Name = "NOMBRELabel";
            this.NOMBRELabel.Size = new System.Drawing.Size(54, 13);
            this.NOMBRELabel.TabIndex = 1;
            this.NOMBRELabel.Text = "Nombre:";
            // 
            // CLAVETextBox
            // 
            this.CLAVETextBox.Location = new System.Drawing.Point(63, 18);
            this.CLAVETextBox.Name = "CLAVETextBox";
            this.CLAVETextBox.Size = new System.Drawing.Size(326, 20);
            this.CLAVETextBox.TabIndex = 1;
            this.CLAVETextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CLAVETextBox_Validating);
            // 
            // NOMBRETextBox
            // 
            this.NOMBRETextBox.Location = new System.Drawing.Point(161, 5);
            this.NOMBRETextBox.Name = "NOMBRETextBox";
            this.NOMBRETextBox.Size = new System.Drawing.Size(326, 20);
            this.NOMBRETextBox.TabIndex = 2;
            // 
            // RFV_CLAVE
            // 
            this.RFV_CLAVE.ControlToValidate = this.CLAVETextBox;
            this.RFV_CLAVE.Enabled = true;
            this.RFV_CLAVE.ErrorMessage = "Se requiere el campo CLAVE";
            this.RFV_CLAVE.Icon = null;
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(291, 605);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panel1.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel1.Controls.Add(this.IMNUPRODTextBox);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.EMPPROVButton);
            this.panel1.Controls.Add(this.EMPPROVTextBox);
            this.panel1.Controls.Add(this.EMPPROVLabel);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.LISTAPRECIOCLAVETextBox);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.CUENTAPOLIZATextBox);
            this.panel1.Controls.Add(this.txtRutaRespaldoRed);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.CUENTAREFERENCIATextBox);
            this.panel1.Controls.Add(this.BANCOCLAVETextBox);
            this.panel1.Controls.Add(this.txtNombreRespaldoBD);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(label22);
            this.panel1.Controls.Add(this.PREFIJOPRECIOXDESCUENTOTextBox);
            this.panel1.Controls.Add(this.MANEJAPRECIOXDESCUENTOTextBox);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.txtRutaRespaldoDestino);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.txtRutaRespaldoOrigen);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.PORC_AUMENTO_PRECIOTextBox);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.SURTIDORButton);
            this.panel1.Controls.Add(this.SURTIDORTextBox);
            this.panel1.Controls.Add(this.SURTIDORLabel);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.PROVEEDORCLAVEButton);
            this.panel1.Controls.Add(this.PROVEEDORCLAVETextBox);
            this.panel1.Controls.Add(this.PROVEEDORCLAVELabel);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.POR_FACT_ELECTTextBox);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.ESFRANQUICIATextBox);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.CLIENTECLAVEButton);
            this.panel1.Controls.Add(this.CLIENTECLAVETextBox);
            this.panel1.Controls.Add(this.CLIENTECLAVELabel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.PRECIOENVIOTRASLADOTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.MOSTRARPRECIOREALTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.PRECIORECEPCIONTRASLADOTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ESMATRIZTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ACTIVOTextBox);
            this.panel1.Controls.Add(this.ACTIVOLabel);
            this.panel1.Controls.Add(this.LISTA_PRECIO_TRASPASOTextBox);
            this.panel1.Controls.Add(this.NOMBRELabel);
            this.panel1.Controls.Add(this.LISTAPRECIOIDLabel);
            this.panel1.Controls.Add(this.NOMBRETextBox);
            this.panel1.Controls.Add(LBCantidadStock);
            this.panel1.Controls.Add(dESCRIPCIONLabel);
            this.panel1.Controls.Add(this.MAXDOCTOSPENDIENTESTextBox);
            this.panel1.Controls.Add(this.DESCRIPCIONTextBox);
            this.panel1.Controls.Add(this.GRUPOSUCURSALIDButton);
            this.panel1.Controls.Add(pROVEEDOR1IDLabel);
            this.panel1.Controls.Add(this.GRUPOSUCURSALIDTextBox);
            this.panel1.Controls.Add(this.GRUPOSUCURSALIDLabel);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 520);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            // 
            // IMNUPRODTextBox
            // 
            this.IMNUPRODTextBox.AutoSize = true;
            this.IMNUPRODTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.IMNUPRODTextBox.Location = new System.Drawing.Point(577, 228);
            this.IMNUPRODTextBox.Name = "IMNUPRODTextBox";
            this.IMNUPRODTextBox.Size = new System.Drawing.Size(15, 14);
            this.IMNUPRODTextBox.TabIndex = 225;
            this.IMNUPRODTextBox.UseVisualStyleBackColor = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(394, 227);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(162, 13);
            this.label28.TabIndex = 224;
            this.label28.Text = "Importar nuevos productos:";
            // 
            // EMPPROVButton
            // 
            this.EMPPROVButton.BackColor = System.Drawing.Color.Transparent;
            this.EMPPROVButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EMPPROVButton.BackgroundImage")));
            this.EMPPROVButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EMPPROVButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EMPPROVButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.EMPPROVButton.Location = new System.Drawing.Point(261, 310);
            this.EMPPROVButton.Name = "EMPPROVButton";
            this.EMPPROVButton.Size = new System.Drawing.Size(21, 23);
            this.EMPPROVButton.TabIndex = 186;
            this.EMPPROVButton.UseVisualStyleBackColor = false;
            // 
            // EMPPROVTextBox
            // 
            this.EMPPROVTextBox.BotonLookUp = this.EMPPROVButton;
            this.EMPPROVTextBox.Condicion = null;
            this.EMPPROVTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.EMPPROVTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.EMPPROVTextBox.DbValue = null;
            this.EMPPROVTextBox.Format_Expression = null;
            this.EMPPROVTextBox.IndiceCampoDescripcion = 2;
            this.EMPPROVTextBox.IndiceCampoSelector = 1;
            this.EMPPROVTextBox.IndiceCampoValue = 1;
            this.EMPPROVTextBox.LabelDescription = this.EMPPROVLabel;
            this.EMPPROVTextBox.Location = new System.Drawing.Point(160, 311);
            this.EMPPROVTextBox.MostrarErrores = true;
            this.EMPPROVTextBox.Name = "EMPPROVTextBox";
            this.EMPPROVTextBox.NombreCampoSelector = "clave";
            this.EMPPROVTextBox.NombreCampoValue = "clave";
            this.EMPPROVTextBox.Query = "select p.id,p.clave,p.nombre from persona p where p.tipopersonaid in (40) ";
            this.EMPPROVTextBox.QueryDeSeleccion = "select  id,clave, nombre from persona where tipopersonaid  in (40) and  clave= @c" +
    "lave";
            this.EMPPROVTextBox.QueryPorDBValue = "select  id,clave, nombre from persona where tipopersonaid  in (40) and  clave = @" +
    "clave";
            this.EMPPROVTextBox.Size = new System.Drawing.Size(95, 20);
            this.EMPPROVTextBox.TabIndex = 186;
            this.EMPPROVTextBox.Tag = 34;
            this.EMPPROVTextBox.TextDescription = null;
            this.EMPPROVTextBox.Titulo = "Proveedores";
            this.EMPPROVTextBox.ValidarEntrada = true;
            this.EMPPROVTextBox.ValidationExpression = null;
            // 
            // EMPPROVLabel
            // 
            this.EMPPROVLabel.AutoSize = true;
            this.EMPPROVLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.EMPPROVLabel.ForeColor = System.Drawing.Color.White;
            this.EMPPROVLabel.Location = new System.Drawing.Point(288, 315);
            this.EMPPROVLabel.Name = "EMPPROVLabel";
            this.EMPPROVLabel.Size = new System.Drawing.Size(19, 13);
            this.EMPPROVLabel.TabIndex = 192;
            this.EMPPROVLabel.Text = "...";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(11, 315);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(131, 13);
            this.label29.TabIndex = 223;
            this.label29.Text = "Empresa / Proveedor:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(423, 110);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(132, 13);
            this.label27.TabIndex = 222;
            this.label27.Text = "Lista precio especial: ";
            // 
            // LISTAPRECIOCLAVETextBox
            // 
            this.LISTAPRECIOCLAVETextBox.Condicion = null;
            this.LISTAPRECIOCLAVETextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.LISTAPRECIOCLAVETextBox.DisplayMember = "nombre";
            this.LISTAPRECIOCLAVETextBox.FormattingEnabled = true;
            this.LISTAPRECIOCLAVETextBox.IndiceCampoSelector = 0;
            this.LISTAPRECIOCLAVETextBox.LabelDescription = null;
            this.LISTAPRECIOCLAVETextBox.Location = new System.Drawing.Point(561, 106);
            this.LISTAPRECIOCLAVETextBox.Name = "LISTAPRECIOCLAVETextBox";
            this.LISTAPRECIOCLAVETextBox.NombreCampoSelector = "clave";
            this.LISTAPRECIOCLAVETextBox.Query = "select clave,nombre from listaprecio";
            this.LISTAPRECIOCLAVETextBox.QueryDeSeleccion = "select clave,nombre from listaprecio where   clave = @clave";
            this.LISTAPRECIOCLAVETextBox.SelectedDataDisplaying = null;
            this.LISTAPRECIOCLAVETextBox.SelectedDataValue = null;
            this.LISTAPRECIOCLAVETextBox.Size = new System.Drawing.Size(103, 21);
            this.LISTAPRECIOCLAVETextBox.TabIndex = 221;
            this.LISTAPRECIOCLAVETextBox.ValueMember = "clave";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(392, 495);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(92, 13);
            this.label26.TabIndex = 220;
            this.label26.Text = "Cuenta poliza: ";
            // 
            // CUENTAPOLIZATextBox
            // 
            this.CUENTAPOLIZATextBox.Location = new System.Drawing.Point(541, 492);
            this.CUENTAPOLIZATextBox.Name = "CUENTAPOLIZATextBox";
            this.CUENTAPOLIZATextBox.Size = new System.Drawing.Size(103, 20);
            this.CUENTAPOLIZATextBox.TabIndex = 219;
            // 
            // txtRutaRespaldoRed
            // 
            this.txtRutaRespaldoRed.Location = new System.Drawing.Point(160, 491);
            this.txtRutaRespaldoRed.Name = "txtRutaRespaldoRed";
            this.txtRutaRespaldoRed.Size = new System.Drawing.Size(225, 20);
            this.txtRutaRespaldoRed.TabIndex = 218;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(10, 495);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(122, 13);
            this.label25.TabIndex = 217;
            this.label25.Text = "Ruta Respaldo Red:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(393, 418);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 13);
            this.label24.TabIndex = 216;
            this.label24.Text = "Cuenta: ";
            // 
            // CUENTAREFERENCIATextBox
            // 
            this.CUENTAREFERENCIATextBox.Location = new System.Drawing.Point(582, 415);
            this.CUENTAREFERENCIATextBox.Name = "CUENTAREFERENCIATextBox";
            this.CUENTAREFERENCIATextBox.Size = new System.Drawing.Size(132, 20);
            this.CUENTAREFERENCIATextBox.TabIndex = 215;
            // 
            // BANCOCLAVETextBox
            // 
            this.BANCOCLAVETextBox.Condicion = null;
            this.BANCOCLAVETextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.BANCOCLAVETextBox.DisplayMember = "nombre";
            this.BANCOCLAVETextBox.FormattingEnabled = true;
            this.BANCOCLAVETextBox.IndiceCampoSelector = 0;
            this.BANCOCLAVETextBox.LabelDescription = null;
            this.BANCOCLAVETextBox.Location = new System.Drawing.Point(463, 414);
            this.BANCOCLAVETextBox.Name = "BANCOCLAVETextBox";
            this.BANCOCLAVETextBox.NombreCampoSelector = "clave";
            this.BANCOCLAVETextBox.Query = "select clave,nombre from bancos";
            this.BANCOCLAVETextBox.QueryDeSeleccion = "select clave,nombre from bancos where   clave = @clave";
            this.BANCOCLAVETextBox.SelectedDataDisplaying = null;
            this.BANCOCLAVETextBox.SelectedDataValue = null;
            this.BANCOCLAVETextBox.Size = new System.Drawing.Size(103, 21);
            this.BANCOCLAVETextBox.TabIndex = 214;
            this.BANCOCLAVETextBox.ValueMember = "clave";
            // 
            // txtNombreRespaldoBD
            // 
            this.txtNombreRespaldoBD.Location = new System.Drawing.Point(160, 415);
            this.txtNombreRespaldoBD.Name = "txtNombreRespaldoBD";
            this.txtNombreRespaldoBD.Size = new System.Drawing.Size(225, 20);
            this.txtNombreRespaldoBD.TabIndex = 213;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(10, 418);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(148, 13);
            this.label23.TabIndex = 212;
            this.label23.Text = "Nombre del resplado BD:";
            // 
            // PREFIJOPRECIOXDESCUENTOTextBox
            // 
            this.PREFIJOPRECIOXDESCUENTOTextBox.Location = new System.Drawing.Point(541, 465);
            this.PREFIJOPRECIOXDESCUENTOTextBox.Name = "PREFIJOPRECIOXDESCUENTOTextBox";
            this.PREFIJOPRECIOXDESCUENTOTextBox.Size = new System.Drawing.Size(103, 20);
            this.PREFIJOPRECIOXDESCUENTOTextBox.TabIndex = 210;
            // 
            // MANEJAPRECIOXDESCUENTOTextBox
            // 
            this.MANEJAPRECIOXDESCUENTOTextBox.AutoSize = true;
            this.MANEJAPRECIOXDESCUENTOTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.MANEJAPRECIOXDESCUENTOTextBox.Location = new System.Drawing.Point(541, 443);
            this.MANEJAPRECIOXDESCUENTOTextBox.Name = "MANEJAPRECIOXDESCUENTOTextBox";
            this.MANEJAPRECIOXDESCUENTOTextBox.Size = new System.Drawing.Size(15, 14);
            this.MANEJAPRECIOXDESCUENTOTextBox.TabIndex = 209;
            this.MANEJAPRECIOXDESCUENTOTextBox.UseVisualStyleBackColor = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(393, 443);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(146, 13);
            this.label21.TabIndex = 208;
            this.label21.Text = "Importar prec. con desc.";
            // 
            // txtRutaRespaldoDestino
            // 
            this.txtRutaRespaldoDestino.Location = new System.Drawing.Point(160, 466);
            this.txtRutaRespaldoDestino.Name = "txtRutaRespaldoDestino";
            this.txtRutaRespaldoDestino.Size = new System.Drawing.Size(225, 20);
            this.txtRutaRespaldoDestino.TabIndex = 207;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(10, 469);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(142, 13);
            this.label20.TabIndex = 206;
            this.label20.Text = "Ruta Respaldo Destino:";
            // 
            // txtRutaRespaldoOrigen
            // 
            this.txtRutaRespaldoOrigen.Location = new System.Drawing.Point(160, 440);
            this.txtRutaRespaldoOrigen.Name = "txtRutaRespaldoOrigen";
            this.txtRutaRespaldoOrigen.Size = new System.Drawing.Size(225, 20);
            this.txtRutaRespaldoOrigen.TabIndex = 205;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(10, 443);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(136, 13);
            this.label19.TabIndex = 204;
            this.label19.Text = "Ruta Respaldo Origen:";
            // 
            // PORC_AUMENTO_PRECIOTextBox
            // 
            this.PORC_AUMENTO_PRECIOTextBox.AllowNegative = true;
            this.PORC_AUMENTO_PRECIOTextBox.Format_Expression = null;
            this.PORC_AUMENTO_PRECIOTextBox.Location = new System.Drawing.Point(413, 338);
            this.PORC_AUMENTO_PRECIOTextBox.Name = "PORC_AUMENTO_PRECIOTextBox";
            this.PORC_AUMENTO_PRECIOTextBox.NumericPrecision = 10;
            this.PORC_AUMENTO_PRECIOTextBox.NumericScaleOnFocus = 2;
            this.PORC_AUMENTO_PRECIOTextBox.NumericScaleOnLostFocus = 2;
            this.PORC_AUMENTO_PRECIOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PORC_AUMENTO_PRECIOTextBox.Size = new System.Drawing.Size(100, 20);
            this.PORC_AUMENTO_PRECIOTextBox.TabIndex = 203;
            this.PORC_AUMENTO_PRECIOTextBox.Tag = 34;
            this.PORC_AUMENTO_PRECIOTextBox.Text = "0";
            this.PORC_AUMENTO_PRECIOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PORC_AUMENTO_PRECIOTextBox.ValidationExpression = null;
            this.PORC_AUMENTO_PRECIOTextBox.ZeroIsValid = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(288, 342);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 13);
            this.label16.TabIndex = 202;
            this.label16.Text = "% Aumento precio:";
            // 
            // SURTIDORButton
            // 
            this.SURTIDORButton.BackColor = System.Drawing.Color.Transparent;
            this.SURTIDORButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SURTIDORButton.BackgroundImage")));
            this.SURTIDORButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SURTIDORButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SURTIDORButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SURTIDORButton.Location = new System.Drawing.Point(261, 388);
            this.SURTIDORButton.Name = "SURTIDORButton";
            this.SURTIDORButton.Size = new System.Drawing.Size(21, 23);
            this.SURTIDORButton.TabIndex = 200;
            this.SURTIDORButton.UseVisualStyleBackColor = false;
            // 
            // SURTIDORTextBox
            // 
            this.SURTIDORTextBox.BotonLookUp = this.SURTIDORButton;
            this.SURTIDORTextBox.Condicion = null;
            this.SURTIDORTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SURTIDORTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SURTIDORTextBox.DbValue = null;
            this.SURTIDORTextBox.Format_Expression = null;
            this.SURTIDORTextBox.IndiceCampoDescripcion = 2;
            this.SURTIDORTextBox.IndiceCampoSelector = 1;
            this.SURTIDORTextBox.IndiceCampoValue = 1;
            this.SURTIDORTextBox.LabelDescription = this.SURTIDORLabel;
            this.SURTIDORTextBox.Location = new System.Drawing.Point(160, 389);
            this.SURTIDORTextBox.MostrarErrores = true;
            this.SURTIDORTextBox.Name = "SURTIDORTextBox";
            this.SURTIDORTextBox.NombreCampoSelector = "clave";
            this.SURTIDORTextBox.NombreCampoValue = "clave";
            this.SURTIDORTextBox.Query = "select p.id,p.clave,p.nombre from sucursal p ";
            this.SURTIDORTextBox.QueryDeSeleccion = "select  id,clave, nombre from sucursal where  clave= @clave";
            this.SURTIDORTextBox.QueryPorDBValue = "select  id,clave, nombre from sucursal where clave = @clave";
            this.SURTIDORTextBox.Size = new System.Drawing.Size(95, 20);
            this.SURTIDORTextBox.TabIndex = 199;
            this.SURTIDORTextBox.Tag = 34;
            this.SURTIDORTextBox.TextDescription = null;
            this.SURTIDORTextBox.Titulo = "Sucursales";
            this.SURTIDORTextBox.ValidarEntrada = true;
            this.SURTIDORTextBox.ValidationExpression = null;
            // 
            // SURTIDORLabel
            // 
            this.SURTIDORLabel.AutoSize = true;
            this.SURTIDORLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SURTIDORLabel.ForeColor = System.Drawing.Color.White;
            this.SURTIDORLabel.Location = new System.Drawing.Point(288, 393);
            this.SURTIDORLabel.Name = "SURTIDORLabel";
            this.SURTIDORLabel.Size = new System.Drawing.Size(19, 13);
            this.SURTIDORLabel.TabIndex = 201;
            this.SURTIDORLabel.Text = "...";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(10, 395);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 13);
            this.label18.TabIndex = 198;
            this.label18.Text = "Surtidor:";
            // 
            // PROVEEDORCLAVEButton
            // 
            this.PROVEEDORCLAVEButton.BackColor = System.Drawing.Color.Transparent;
            this.PROVEEDORCLAVEButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PROVEEDORCLAVEButton.BackgroundImage")));
            this.PROVEEDORCLAVEButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PROVEEDORCLAVEButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PROVEEDORCLAVEButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PROVEEDORCLAVEButton.Location = new System.Drawing.Point(261, 281);
            this.PROVEEDORCLAVEButton.Name = "PROVEEDORCLAVEButton";
            this.PROVEEDORCLAVEButton.Size = new System.Drawing.Size(21, 23);
            this.PROVEEDORCLAVEButton.TabIndex = 185;
            this.PROVEEDORCLAVEButton.UseVisualStyleBackColor = false;
            // 
            // PROVEEDORCLAVETextBox
            // 
            this.PROVEEDORCLAVETextBox.BotonLookUp = this.PROVEEDORCLAVEButton;
            this.PROVEEDORCLAVETextBox.Condicion = null;
            this.PROVEEDORCLAVETextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEEDORCLAVETextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEEDORCLAVETextBox.DbValue = null;
            this.PROVEEDORCLAVETextBox.Format_Expression = null;
            this.PROVEEDORCLAVETextBox.IndiceCampoDescripcion = 2;
            this.PROVEEDORCLAVETextBox.IndiceCampoSelector = 1;
            this.PROVEEDORCLAVETextBox.IndiceCampoValue = 1;
            this.PROVEEDORCLAVETextBox.LabelDescription = this.PROVEEDORCLAVELabel;
            this.PROVEEDORCLAVETextBox.Location = new System.Drawing.Point(160, 282);
            this.PROVEEDORCLAVETextBox.MostrarErrores = true;
            this.PROVEEDORCLAVETextBox.Name = "PROVEEDORCLAVETextBox";
            this.PROVEEDORCLAVETextBox.NombreCampoSelector = "clave";
            this.PROVEEDORCLAVETextBox.NombreCampoValue = "clave";
            this.PROVEEDORCLAVETextBox.Query = "select p.id,p.clave,p.nombre from persona p where p.tipopersonaid in (40) ";
            this.PROVEEDORCLAVETextBox.QueryDeSeleccion = "select  id,clave, nombre from persona where tipopersonaid  in (40) and  clave= @c" +
    "lave";
            this.PROVEEDORCLAVETextBox.QueryPorDBValue = "select  id,clave, nombre from persona where tipopersonaid  in (40) and  clave = @" +
    "clave";
            this.PROVEEDORCLAVETextBox.Size = new System.Drawing.Size(95, 20);
            this.PROVEEDORCLAVETextBox.TabIndex = 185;
            this.PROVEEDORCLAVETextBox.Tag = 34;
            this.PROVEEDORCLAVETextBox.TextDescription = null;
            this.PROVEEDORCLAVETextBox.Titulo = "Proveedores";
            this.PROVEEDORCLAVETextBox.ValidarEntrada = true;
            this.PROVEEDORCLAVETextBox.ValidationExpression = null;
            // 
            // PROVEEDORCLAVELabel
            // 
            this.PROVEEDORCLAVELabel.AutoSize = true;
            this.PROVEEDORCLAVELabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PROVEEDORCLAVELabel.ForeColor = System.Drawing.Color.White;
            this.PROVEEDORCLAVELabel.Location = new System.Drawing.Point(288, 286);
            this.PROVEEDORCLAVELabel.Name = "PROVEEDORCLAVELabel";
            this.PROVEEDORCLAVELabel.Size = new System.Drawing.Size(19, 13);
            this.PROVEEDORCLAVELabel.TabIndex = 189;
            this.PROVEEDORCLAVELabel.Text = "...";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(11, 286);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(116, 13);
            this.label17.TabIndex = 191;
            this.label17.Text = "Proveedor entrada:";
            // 
            // POR_FACT_ELECTTextBox
            // 
            this.POR_FACT_ELECTTextBox.AutoSize = true;
            this.POR_FACT_ELECTTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.POR_FACT_ELECTTextBox.Location = new System.Drawing.Point(163, 370);
            this.POR_FACT_ELECTTextBox.Name = "POR_FACT_ELECTTextBox";
            this.POR_FACT_ELECTTextBox.Size = new System.Drawing.Size(15, 14);
            this.POR_FACT_ELECTTextBox.TabIndex = 190;
            this.POR_FACT_ELECTTextBox.UseVisualStyleBackColor = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(10, 370);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 13);
            this.label15.TabIndex = 189;
            this.label15.Text = "Default fact. elect.";
            // 
            // ESFRANQUICIATextBox
            // 
            this.ESFRANQUICIATextBox.AutoSize = true;
            this.ESFRANQUICIATextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ESFRANQUICIATextBox.Location = new System.Drawing.Point(163, 341);
            this.ESFRANQUICIATextBox.Name = "ESFRANQUICIATextBox";
            this.ESFRANQUICIATextBox.Size = new System.Drawing.Size(15, 14);
            this.ESFRANQUICIATextBox.TabIndex = 188;
            this.ESFRANQUICIATextBox.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(10, 342);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 13);
            this.label14.TabIndex = 187;
            this.label14.Text = "Es franquicia:";
            // 
            // CLIENTECLAVEButton
            // 
            this.CLIENTECLAVEButton.BackColor = System.Drawing.Color.Transparent;
            this.CLIENTECLAVEButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CLIENTECLAVEButton.BackgroundImage")));
            this.CLIENTECLAVEButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CLIENTECLAVEButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLIENTECLAVEButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.CLIENTECLAVEButton.Location = new System.Drawing.Point(261, 252);
            this.CLIENTECLAVEButton.Name = "CLIENTECLAVEButton";
            this.CLIENTECLAVEButton.Size = new System.Drawing.Size(21, 23);
            this.CLIENTECLAVEButton.TabIndex = 184;
            this.CLIENTECLAVEButton.UseVisualStyleBackColor = false;
            // 
            // CLIENTECLAVETextBox
            // 
            this.CLIENTECLAVETextBox.BotonLookUp = this.CLIENTECLAVEButton;
            this.CLIENTECLAVETextBox.Condicion = null;
            this.CLIENTECLAVETextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CLIENTECLAVETextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CLIENTECLAVETextBox.DbValue = null;
            this.CLIENTECLAVETextBox.Format_Expression = null;
            this.CLIENTECLAVETextBox.IndiceCampoDescripcion = 2;
            this.CLIENTECLAVETextBox.IndiceCampoSelector = 1;
            this.CLIENTECLAVETextBox.IndiceCampoValue = 1;
            this.CLIENTECLAVETextBox.LabelDescription = this.CLIENTECLAVELabel;
            this.CLIENTECLAVETextBox.Location = new System.Drawing.Point(160, 253);
            this.CLIENTECLAVETextBox.MostrarErrores = true;
            this.CLIENTECLAVETextBox.Name = "CLIENTECLAVETextBox";
            this.CLIENTECLAVETextBox.NombreCampoSelector = "clave";
            this.CLIENTECLAVETextBox.NombreCampoValue = "clave";
            this.CLIENTECLAVETextBox.Query = "select p.id,p.clave,p.nombre from persona p where p.tipopersonaid in (50) ";
            this.CLIENTECLAVETextBox.QueryDeSeleccion = "select  id,clave, nombre from persona where tipopersonaid  in (50) and  clave= @c" +
    "lave";
            this.CLIENTECLAVETextBox.QueryPorDBValue = "select  id,clave, nombre from persona where tipopersonaid  in (50) and  clave = @" +
    "clave";
            this.CLIENTECLAVETextBox.Size = new System.Drawing.Size(95, 20);
            this.CLIENTECLAVETextBox.TabIndex = 184;
            this.CLIENTECLAVETextBox.Tag = 34;
            this.CLIENTECLAVETextBox.TextDescription = null;
            this.CLIENTECLAVETextBox.Titulo = "Clientes";
            this.CLIENTECLAVETextBox.ValidarEntrada = true;
            this.CLIENTECLAVETextBox.ValidationExpression = null;
            // 
            // CLIENTECLAVELabel
            // 
            this.CLIENTECLAVELabel.AutoSize = true;
            this.CLIENTECLAVELabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.CLIENTECLAVELabel.ForeColor = System.Drawing.Color.White;
            this.CLIENTECLAVELabel.Location = new System.Drawing.Point(288, 257);
            this.CLIENTECLAVELabel.Name = "CLIENTECLAVELabel";
            this.CLIENTECLAVELabel.Size = new System.Drawing.Size(19, 13);
            this.CLIENTECLAVELabel.TabIndex = 186;
            this.CLIENTECLAVELabel.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(10, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 183;
            this.label5.Text = "Cliente:";
            // 
            // PRECIOENVIOTRASLADOTextBox
            // 
            this.PRECIOENVIOTRASLADOTextBox.FormattingEnabled = true;
            this.PRECIOENVIOTRASLADOTextBox.Items.AddRange(new object[] {
            "Costo reposicion",
            "Costo ultimo",
            "Costo promedio",
            "Precio 1",
            "Precio 2",
            "Precio 3",
            "Precio 4",
            "Precio 5"});
            this.PRECIOENVIOTRASLADOTextBox.Location = new System.Drawing.Point(354, 163);
            this.PRECIOENVIOTRASLADOTextBox.Name = "PRECIOENVIOTRASLADOTextBox";
            this.PRECIOENVIOTRASLADOTextBox.Size = new System.Drawing.Size(185, 21);
            this.PRECIOENVIOTRASLADOTextBox.TabIndex = 181;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(196, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 13);
            this.label4.TabIndex = 180;
            this.label4.Text = "Precio surtimiento pedido.";
            // 
            // MOSTRARPRECIOREALTextBox
            // 
            this.MOSTRARPRECIOREALTextBox.AutoSize = true;
            this.MOSTRARPRECIOREALTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.MOSTRARPRECIOREALTextBox.Location = new System.Drawing.Point(162, 227);
            this.MOSTRARPRECIOREALTextBox.Name = "MOSTRARPRECIOREALTextBox";
            this.MOSTRARPRECIOREALTextBox.Size = new System.Drawing.Size(15, 14);
            this.MOSTRARPRECIOREALTextBox.TabIndex = 179;
            this.MOSTRARPRECIOREALTextBox.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 178;
            this.label3.Text = "Mostrar precio real:";
            // 
            // PRECIORECEPCIONTRASLADOTextBox
            // 
            this.PRECIORECEPCIONTRASLADOTextBox.FormattingEnabled = true;
            this.PRECIORECEPCIONTRASLADOTextBox.Items.AddRange(new object[] {
            "Costo reposicion",
            "Costo ultimo",
            "Costo promedio",
            "Precio 1",
            "Precio 2",
            "Precio 3",
            "Precio 4",
            "Precio 5"});
            this.PRECIORECEPCIONTRASLADOTextBox.Location = new System.Drawing.Point(161, 192);
            this.PRECIORECEPCIONTRASLADOTextBox.Name = "PRECIORECEPCIONTRASLADOTextBox";
            this.PRECIORECEPCIONTRASLADOTextBox.Size = new System.Drawing.Size(185, 21);
            this.PRECIORECEPCIONTRASLADOTextBox.TabIndex = 177;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 176;
            this.label2.Text = "Recepcion traslado";
            // 
            // ESMATRIZTextBox
            // 
            this.ESMATRIZTextBox.AutoSize = true;
            this.ESMATRIZTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ESMATRIZTextBox.ForeColor = System.Drawing.Color.White;
            this.ESMATRIZTextBox.Location = new System.Drawing.Point(162, 168);
            this.ESMATRIZTextBox.Name = "ESMATRIZTextBox";
            this.ESMATRIZTextBox.Size = new System.Drawing.Size(15, 14);
            this.ESMATRIZTextBox.TabIndex = 175;
            this.ESMATRIZTextBox.UseVisualStyleBackColor = false;
            this.ESMATRIZTextBox.CheckedChanged += new System.EventHandler(this.ESMATRIZTextBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 174;
            this.label1.Text = "Es matriz:";
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ACTIVOTextBox.ForeColor = System.Drawing.Color.White;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(161, 35);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ACTIVOTextBox.TabIndex = 5;
            this.ACTIVOTextBox.UseVisualStyleBackColor = false;
            // 
            // LISTA_PRECIO_TRASPASOTextBox
            // 
            this.LISTA_PRECIO_TRASPASOTextBox.FormattingEnabled = true;
            this.LISTA_PRECIO_TRASPASOTextBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "Costo reposicion",
            "Costo ultimo",
            "Costo promedio"});
            this.LISTA_PRECIO_TRASPASOTextBox.Location = new System.Drawing.Point(161, 109);
            this.LISTA_PRECIO_TRASPASOTextBox.Name = "LISTA_PRECIO_TRASPASOTextBox";
            this.LISTA_PRECIO_TRASPASOTextBox.Size = new System.Drawing.Size(185, 21);
            this.LISTA_PRECIO_TRASPASOTextBox.TabIndex = 173;
            // 
            // LISTAPRECIOIDLabel
            // 
            this.LISTAPRECIOIDLabel.AutoSize = true;
            this.LISTAPRECIOIDLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.LISTAPRECIOIDLabel.ForeColor = System.Drawing.Color.White;
            this.LISTAPRECIOIDLabel.Location = new System.Drawing.Point(10, 114);
            this.LISTAPRECIOIDLabel.Name = "LISTAPRECIOIDLabel";
            this.LISTAPRECIOIDLabel.Size = new System.Drawing.Size(95, 13);
            this.LISTAPRECIOIDLabel.TabIndex = 172;
            this.LISTAPRECIOIDLabel.Text = "Precio traspaso";
            // 
            // MAXDOCTOSPENDIENTESTextBox
            // 
            this.MAXDOCTOSPENDIENTESTextBox.AllowNegative = true;
            this.MAXDOCTOSPENDIENTESTextBox.Format_Expression = null;
            this.MAXDOCTOSPENDIENTESTextBox.Location = new System.Drawing.Point(161, 136);
            this.MAXDOCTOSPENDIENTESTextBox.Name = "MAXDOCTOSPENDIENTESTextBox";
            this.MAXDOCTOSPENDIENTESTextBox.NumericPrecision = 18;
            this.MAXDOCTOSPENDIENTESTextBox.NumericScaleOnFocus = 0;
            this.MAXDOCTOSPENDIENTESTextBox.NumericScaleOnLostFocus = 0;
            this.MAXDOCTOSPENDIENTESTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MAXDOCTOSPENDIENTESTextBox.Size = new System.Drawing.Size(116, 20);
            this.MAXDOCTOSPENDIENTESTextBox.TabIndex = 170;
            this.MAXDOCTOSPENDIENTESTextBox.Tag = 34;
            this.MAXDOCTOSPENDIENTESTextBox.Text = "0";
            this.MAXDOCTOSPENDIENTESTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MAXDOCTOSPENDIENTESTextBox.ValidationExpression = null;
            this.MAXDOCTOSPENDIENTESTextBox.ZeroIsValid = true;
            // 
            // DESCRIPCIONTextBox
            // 
            this.DESCRIPCIONTextBox.Location = new System.Drawing.Point(161, 57);
            this.DESCRIPCIONTextBox.Name = "DESCRIPCIONTextBox";
            this.DESCRIPCIONTextBox.Size = new System.Drawing.Size(318, 20);
            this.DESCRIPCIONTextBox.TabIndex = 48;
            // 
            // GRUPOSUCURSALIDButton
            // 
            this.GRUPOSUCURSALIDButton.BackColor = System.Drawing.Color.Transparent;
            this.GRUPOSUCURSALIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.GRUPOSUCURSALIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GRUPOSUCURSALIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GRUPOSUCURSALIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.GRUPOSUCURSALIDButton.Location = new System.Drawing.Point(259, 82);
            this.GRUPOSUCURSALIDButton.Name = "GRUPOSUCURSALIDButton";
            this.GRUPOSUCURSALIDButton.Size = new System.Drawing.Size(24, 23);
            this.GRUPOSUCURSALIDButton.TabIndex = 156;
            this.GRUPOSUCURSALIDButton.UseVisualStyleBackColor = false;
            // 
            // GRUPOSUCURSALIDTextBox
            // 
            this.GRUPOSUCURSALIDTextBox.BotonLookUp = this.GRUPOSUCURSALIDButton;
            this.GRUPOSUCURSALIDTextBox.Condicion = null;
            this.GRUPOSUCURSALIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GRUPOSUCURSALIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GRUPOSUCURSALIDTextBox.DbValue = null;
            this.GRUPOSUCURSALIDTextBox.Format_Expression = null;
            this.GRUPOSUCURSALIDTextBox.IndiceCampoDescripcion = 2;
            this.GRUPOSUCURSALIDTextBox.IndiceCampoSelector = 1;
            this.GRUPOSUCURSALIDTextBox.IndiceCampoValue = 0;
            this.GRUPOSUCURSALIDTextBox.LabelDescription = this.GRUPOSUCURSALIDLabel;
            this.GRUPOSUCURSALIDTextBox.Location = new System.Drawing.Point(161, 83);
            this.GRUPOSUCURSALIDTextBox.MostrarErrores = true;
            this.GRUPOSUCURSALIDTextBox.Name = "GRUPOSUCURSALIDTextBox";
            this.GRUPOSUCURSALIDTextBox.NombreCampoSelector = "clave";
            this.GRUPOSUCURSALIDTextBox.NombreCampoValue = "id";
            this.GRUPOSUCURSALIDTextBox.Query = "select id,clave,nombre from gruposucursal";
            this.GRUPOSUCURSALIDTextBox.QueryDeSeleccion = "select id,clave,nombre from gruposucursal where  clave = @clave";
            this.GRUPOSUCURSALIDTextBox.QueryPorDBValue = "select id,clave,nombre from gruposucursal where  id = @id";
            this.GRUPOSUCURSALIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.GRUPOSUCURSALIDTextBox.TabIndex = 155;
            this.GRUPOSUCURSALIDTextBox.Tag = 34;
            this.GRUPOSUCURSALIDTextBox.TextDescription = null;
            this.GRUPOSUCURSALIDTextBox.Titulo = "Grupos de sucursal";
            this.GRUPOSUCURSALIDTextBox.ValidarEntrada = true;
            this.GRUPOSUCURSALIDTextBox.ValidationExpression = null;
            // 
            // GRUPOSUCURSALIDLabel
            // 
            this.GRUPOSUCURSALIDLabel.AutoSize = true;
            this.GRUPOSUCURSALIDLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.GRUPOSUCURSALIDLabel.ForeColor = System.Drawing.Color.White;
            this.GRUPOSUCURSALIDLabel.Location = new System.Drawing.Point(296, 85);
            this.GRUPOSUCURSALIDLabel.Name = "GRUPOSUCURSALIDLabel";
            this.GRUPOSUCURSALIDLabel.Size = new System.Drawing.Size(19, 13);
            this.GRUPOSUCURSALIDLabel.TabIndex = 158;
            this.GRUPOSUCURSALIDLabel.Text = "...";
            // 
            // BTIniciaEdicion
            // 
            this.BTIniciaEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTIniciaEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTIniciaEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIniciaEdicion.ForeColor = System.Drawing.Color.White;
            this.BTIniciaEdicion.Location = new System.Drawing.Point(219, 610);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(66, 23);
            this.BTIniciaEdicion.TabIndex = 46;
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
            this.BTCancelar.Location = new System.Drawing.Point(430, 606);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(131, 34);
            this.BTCancelar.TabIndex = 47;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(739, 555);
            this.tabControl1.TabIndex = 48;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(731, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.tabPage2.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage2.Controls.Add(this.label36);
            this.tabPage2.Controls.Add(this.ENTREGAREFERENCIADOMTextBox);
            this.tabPage2.Controls.Add(this.ENTREGA_DISTANCIATextBox);
            this.tabPage2.Controls.Add(this.label34);
            this.tabPage2.Controls.Add(this.ENTREGA_SAT_COLONIAIDButton);
            this.tabPage2.Controls.Add(this.ENTREGA_SAT_COLONIAIDLabel);
            this.tabPage2.Controls.Add(this.ENTREGA_SAT_COLONIAIDTextBox);
            this.tabPage2.Controls.Add(this.ENTREGA_SAT_MUNICIPIOIDButton);
            this.tabPage2.Controls.Add(this.ENTREGA_SAT_MUNICIPIOIDLabel);
            this.tabPage2.Controls.Add(this.ENTREGA_SAT_MUNICIPIOIDTextBox);
            this.tabPage2.Controls.Add(this.ENTREGA_SAT_LOCALIDADIDButton);
            this.tabPage2.Controls.Add(this.ENTREGA_SAT_LOCALIDADIDLabel);
            this.tabPage2.Controls.Add(this.ENTREGA_SAT_LOCALIDADIDTextBox);
            this.tabPage2.Controls.Add(this.label35);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.ENTREGAESTADOTextBox);
            this.tabPage2.Controls.Add(this.ENTREGACODIGOPOSTALTextBox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.ENTREGANUMEROINTERIORTextBox);
            this.tabPage2.Controls.Add(this.ENTREGANUMEROEXTERIORTextBox);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.ENTREGACALLETextBox);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(731, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Datos de entrega";
            // 
            // ENTREGA_DISTANCIATextBox
            // 
            this.ENTREGA_DISTANCIATextBox.AllowNegative = true;
            this.ENTREGA_DISTANCIATextBox.Format_Expression = null;
            this.ENTREGA_DISTANCIATextBox.Location = new System.Drawing.Point(12, 333);
            this.ENTREGA_DISTANCIATextBox.Name = "ENTREGA_DISTANCIATextBox";
            this.ENTREGA_DISTANCIATextBox.NumericPrecision = 18;
            this.ENTREGA_DISTANCIATextBox.NumericScaleOnFocus = 3;
            this.ENTREGA_DISTANCIATextBox.NumericScaleOnLostFocus = 3;
            this.ENTREGA_DISTANCIATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ENTREGA_DISTANCIATextBox.Size = new System.Drawing.Size(85, 20);
            this.ENTREGA_DISTANCIATextBox.TabIndex = 212;
            this.ENTREGA_DISTANCIATextBox.Tag = "";
            this.ENTREGA_DISTANCIATextBox.Text = "0.000";
            this.ENTREGA_DISTANCIATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ENTREGA_DISTANCIATextBox.ValidationExpression = null;
            this.ENTREGA_DISTANCIATextBox.ZeroIsValid = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Location = new System.Drawing.Point(9, 318);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(64, 13);
            this.label34.TabIndex = 289;
            this.label34.Text = "Distancia:";
            // 
            // ENTREGA_SAT_COLONIAIDButton
            // 
            this.ENTREGA_SAT_COLONIAIDButton.BackColor = System.Drawing.Color.Transparent;
            this.ENTREGA_SAT_COLONIAIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ENTREGA_SAT_COLONIAIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ENTREGA_SAT_COLONIAIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENTREGA_SAT_COLONIAIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ENTREGA_SAT_COLONIAIDButton.Location = new System.Drawing.Point(394, 165);
            this.ENTREGA_SAT_COLONIAIDButton.Name = "ENTREGA_SAT_COLONIAIDButton";
            this.ENTREGA_SAT_COLONIAIDButton.Size = new System.Drawing.Size(23, 23);
            this.ENTREGA_SAT_COLONIAIDButton.TabIndex = 208;
            this.ENTREGA_SAT_COLONIAIDButton.UseVisualStyleBackColor = false;
            // 
            // ENTREGA_SAT_COLONIAIDLabel
            // 
            this.ENTREGA_SAT_COLONIAIDLabel.AutoSize = true;
            this.ENTREGA_SAT_COLONIAIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.ENTREGA_SAT_COLONIAIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTREGA_SAT_COLONIAIDLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ENTREGA_SAT_COLONIAIDLabel.Location = new System.Drawing.Point(416, 174);
            this.ENTREGA_SAT_COLONIAIDLabel.Name = "ENTREGA_SAT_COLONIAIDLabel";
            this.ENTREGA_SAT_COLONIAIDLabel.Size = new System.Drawing.Size(19, 13);
            this.ENTREGA_SAT_COLONIAIDLabel.TabIndex = 287;
            this.ENTREGA_SAT_COLONIAIDLabel.Text = "...";
            // 
            // ENTREGA_SAT_COLONIAIDTextBox
            // 
            this.ENTREGA_SAT_COLONIAIDTextBox.BotonLookUp = this.ENTREGA_SAT_COLONIAIDButton;
            this.ENTREGA_SAT_COLONIAIDTextBox.Condicion = null;
            this.ENTREGA_SAT_COLONIAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGA_SAT_COLONIAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGA_SAT_COLONIAIDTextBox.DbValue = null;
            this.ENTREGA_SAT_COLONIAIDTextBox.Format_Expression = null;
            this.ENTREGA_SAT_COLONIAIDTextBox.IndiceCampoDescripcion = 2;
            this.ENTREGA_SAT_COLONIAIDTextBox.IndiceCampoSelector = 1;
            this.ENTREGA_SAT_COLONIAIDTextBox.IndiceCampoValue = 0;
            this.ENTREGA_SAT_COLONIAIDTextBox.LabelDescription = this.ENTREGA_SAT_COLONIAIDLabel;
            this.ENTREGA_SAT_COLONIAIDTextBox.Location = new System.Drawing.Point(347, 167);
            this.ENTREGA_SAT_COLONIAIDTextBox.MostrarErrores = true;
            this.ENTREGA_SAT_COLONIAIDTextBox.Name = "ENTREGA_SAT_COLONIAIDTextBox";
            this.ENTREGA_SAT_COLONIAIDTextBox.NombreCampoSelector = "clave";
            this.ENTREGA_SAT_COLONIAIDTextBox.NombreCampoValue = "id";
            this.ENTREGA_SAT_COLONIAIDTextBox.Query = "SELECT  c.ID id, c.COLONIA clave, C.nombre nombre ,C.nombre descripcion FROM sat_" +
    "colonia C WHERE c.codigopostal = @CODIGOPOSTAL ORDER BY C.nombre";
            this.ENTREGA_SAT_COLONIAIDTextBox.QueryDeSeleccion = "SELECT  c.ID id, c.COLONIA clave, C.nombre nombre ,C.nombre descripcion FROM sat_" +
    "colonia C WHERE c.codigopostal = @CODIGOPOSTAL  and c.COLONIA = @clave";
            this.ENTREGA_SAT_COLONIAIDTextBox.QueryPorDBValue = "SELECT  c.ID id, c.COLONIA clave, C.nombre nombre ,C.nombre descripcion FROM sat_" +
    "colonia C  WHERE c.ID = @id";
            this.ENTREGA_SAT_COLONIAIDTextBox.Size = new System.Drawing.Size(48, 20);
            this.ENTREGA_SAT_COLONIAIDTextBox.TabIndex = 207;
            this.ENTREGA_SAT_COLONIAIDTextBox.Tag = "36";
            this.ENTREGA_SAT_COLONIAIDTextBox.TextDescription = null;
            this.ENTREGA_SAT_COLONIAIDTextBox.Titulo = "Colonia";
            this.ENTREGA_SAT_COLONIAIDTextBox.ValidarEntrada = true;
            this.ENTREGA_SAT_COLONIAIDTextBox.ValidationExpression = null;
            // 
            // ENTREGA_SAT_MUNICIPIOIDButton
            // 
            this.ENTREGA_SAT_MUNICIPIOIDButton.BackColor = System.Drawing.Color.Transparent;
            this.ENTREGA_SAT_MUNICIPIOIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ENTREGA_SAT_MUNICIPIOIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ENTREGA_SAT_MUNICIPIOIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENTREGA_SAT_MUNICIPIOIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ENTREGA_SAT_MUNICIPIOIDButton.Location = new System.Drawing.Point(57, 164);
            this.ENTREGA_SAT_MUNICIPIOIDButton.Name = "ENTREGA_SAT_MUNICIPIOIDButton";
            this.ENTREGA_SAT_MUNICIPIOIDButton.Size = new System.Drawing.Size(23, 23);
            this.ENTREGA_SAT_MUNICIPIOIDButton.TabIndex = 206;
            this.ENTREGA_SAT_MUNICIPIOIDButton.UseVisualStyleBackColor = false;
            // 
            // ENTREGA_SAT_MUNICIPIOIDLabel
            // 
            this.ENTREGA_SAT_MUNICIPIOIDLabel.AutoSize = true;
            this.ENTREGA_SAT_MUNICIPIOIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.ENTREGA_SAT_MUNICIPIOIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTREGA_SAT_MUNICIPIOIDLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ENTREGA_SAT_MUNICIPIOIDLabel.Location = new System.Drawing.Point(79, 173);
            this.ENTREGA_SAT_MUNICIPIOIDLabel.Name = "ENTREGA_SAT_MUNICIPIOIDLabel";
            this.ENTREGA_SAT_MUNICIPIOIDLabel.Size = new System.Drawing.Size(19, 13);
            this.ENTREGA_SAT_MUNICIPIOIDLabel.TabIndex = 284;
            this.ENTREGA_SAT_MUNICIPIOIDLabel.Text = "...";
            // 
            // ENTREGA_SAT_MUNICIPIOIDTextBox
            // 
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.BotonLookUp = this.ENTREGA_SAT_MUNICIPIOIDButton;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Condicion = null;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.DbValue = null;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Format_Expression = null;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.IndiceCampoDescripcion = 2;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.IndiceCampoSelector = 1;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.IndiceCampoValue = 0;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.LabelDescription = this.ENTREGA_SAT_MUNICIPIOIDLabel;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Location = new System.Drawing.Point(10, 166);
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.MostrarErrores = true;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Name = "ENTREGA_SAT_MUNICIPIOIDTextBox";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.NombreCampoSelector = "clave";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.NombreCampoValue = "id";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Query = resources.GetString("ENTREGA_SAT_MUNICIPIOIDTextBox.Query");
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.QueryDeSeleccion = resources.GetString("ENTREGA_SAT_MUNICIPIOIDTextBox.QueryDeSeleccion");
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.QueryPorDBValue = "SELECT MUN.ID id,  MUN.CLAVE_MUNICIPIO clave, MUN.DESCRIPCION nombre ,MUN.DESCRIP" +
    "CION descripcion FROM sat_municipio MUN LEFT JOIN ESTADO ON MUN.clave_estado = E" +
    "STADO.acronimo WHERE  MUN.ID = @id";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Size = new System.Drawing.Size(48, 20);
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.TabIndex = 205;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Tag = "36";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.TextDescription = null;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Titulo = "Municipio";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.ValidarEntrada = true;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.ValidationExpression = null;
            // 
            // ENTREGA_SAT_LOCALIDADIDButton
            // 
            this.ENTREGA_SAT_LOCALIDADIDButton.BackColor = System.Drawing.Color.Transparent;
            this.ENTREGA_SAT_LOCALIDADIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ENTREGA_SAT_LOCALIDADIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ENTREGA_SAT_LOCALIDADIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENTREGA_SAT_LOCALIDADIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ENTREGA_SAT_LOCALIDADIDButton.Location = new System.Drawing.Point(394, 70);
            this.ENTREGA_SAT_LOCALIDADIDButton.Name = "ENTREGA_SAT_LOCALIDADIDButton";
            this.ENTREGA_SAT_LOCALIDADIDButton.Size = new System.Drawing.Size(23, 23);
            this.ENTREGA_SAT_LOCALIDADIDButton.TabIndex = 204;
            this.ENTREGA_SAT_LOCALIDADIDButton.UseVisualStyleBackColor = false;
            // 
            // ENTREGA_SAT_LOCALIDADIDLabel
            // 
            this.ENTREGA_SAT_LOCALIDADIDLabel.AutoSize = true;
            this.ENTREGA_SAT_LOCALIDADIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.ENTREGA_SAT_LOCALIDADIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTREGA_SAT_LOCALIDADIDLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ENTREGA_SAT_LOCALIDADIDLabel.Location = new System.Drawing.Point(416, 79);
            this.ENTREGA_SAT_LOCALIDADIDLabel.Name = "ENTREGA_SAT_LOCALIDADIDLabel";
            this.ENTREGA_SAT_LOCALIDADIDLabel.Size = new System.Drawing.Size(19, 13);
            this.ENTREGA_SAT_LOCALIDADIDLabel.TabIndex = 281;
            this.ENTREGA_SAT_LOCALIDADIDLabel.Text = "...";
            // 
            // ENTREGA_SAT_LOCALIDADIDTextBox
            // 
            this.ENTREGA_SAT_LOCALIDADIDTextBox.BotonLookUp = this.ENTREGA_SAT_LOCALIDADIDButton;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Condicion = null;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.DbValue = null;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Format_Expression = null;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.IndiceCampoDescripcion = 2;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.IndiceCampoSelector = 1;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.IndiceCampoValue = 0;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.LabelDescription = this.ENTREGA_SAT_LOCALIDADIDLabel;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Location = new System.Drawing.Point(347, 72);
            this.ENTREGA_SAT_LOCALIDADIDTextBox.MostrarErrores = true;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Name = "ENTREGA_SAT_LOCALIDADIDTextBox";
            this.ENTREGA_SAT_LOCALIDADIDTextBox.NombreCampoSelector = "clave";
            this.ENTREGA_SAT_LOCALIDADIDTextBox.NombreCampoValue = "id";
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Query = resources.GetString("ENTREGA_SAT_LOCALIDADIDTextBox.Query");
            this.ENTREGA_SAT_LOCALIDADIDTextBox.QueryDeSeleccion = resources.GetString("ENTREGA_SAT_LOCALIDADIDTextBox.QueryDeSeleccion");
            this.ENTREGA_SAT_LOCALIDADIDTextBox.QueryPorDBValue = "SELECT  LOC.ID id, LOC.CLAVE_LOCALIDAD clave, LOC.DESCRIPCION nombre ,LOC.DESCRIP" +
    "CION descripcion FROM sat_localidad LOC LEFT JOIN ESTADO ON LOC.clave_estado = E" +
    "STADO.acronimo WHERE  LOC.ID = @id";
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Size = new System.Drawing.Size(48, 20);
            this.ENTREGA_SAT_LOCALIDADIDTextBox.TabIndex = 203;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Tag = "36";
            this.ENTREGA_SAT_LOCALIDADIDTextBox.TextDescription = null;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Titulo = "Localidad";
            this.ENTREGA_SAT_LOCALIDADIDTextBox.ValidarEntrada = true;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.ValidationExpression = null;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Location = new System.Drawing.Point(345, 55);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(66, 13);
            this.label35.TabIndex = 280;
            this.label35.Text = "Localidad:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(6, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 13);
            this.label12.TabIndex = 217;
            this.label12.Text = "DATOS DE ENTREGA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(8, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 211;
            this.label7.Text = "Domicilio ";
            // 
            // ENTREGAESTADOTextBox
            // 
            this.ENTREGAESTADOTextBox.Condicion = null;
            this.ENTREGAESTADOTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGAESTADOTextBox.DisplayMember = "nombre";
            this.ENTREGAESTADOTextBox.FormattingEnabled = true;
            this.ENTREGAESTADOTextBox.IndiceCampoSelector = 0;
            this.ENTREGAESTADOTextBox.LabelDescription = null;
            this.ENTREGAESTADOTextBox.Location = new System.Drawing.Point(11, 71);
            this.ENTREGAESTADOTextBox.Name = "ENTREGAESTADOTextBox";
            this.ENTREGAESTADOTextBox.NombreCampoSelector = "id";
            this.ENTREGAESTADOTextBox.Query = "select id,nombre from estado";
            this.ENTREGAESTADOTextBox.QueryDeSeleccion = "select id,nombre from estado where  id = @id";
            this.ENTREGAESTADOTextBox.SelectedDataDisplaying = null;
            this.ENTREGAESTADOTextBox.SelectedDataValue = null;
            this.ENTREGAESTADOTextBox.Size = new System.Drawing.Size(209, 21);
            this.ENTREGAESTADOTextBox.TabIndex = 201;
            this.ENTREGAESTADOTextBox.ValueMember = "id";
            this.ENTREGAESTADOTextBox.SelectedIndexChanged += new System.EventHandler(this.ENTREGAESTADOTextBox_SelectedIndexChanged);
            // 
            // ENTREGACODIGOPOSTALTextBox
            // 
            this.ENTREGACODIGOPOSTALTextBox.Location = new System.Drawing.Point(253, 71);
            this.ENTREGACODIGOPOSTALTextBox.Name = "ENTREGACODIGOPOSTALTextBox";
            this.ENTREGACODIGOPOSTALTextBox.Size = new System.Drawing.Size(86, 20);
            this.ENTREGACODIGOPOSTALTextBox.TabIndex = 202;
            this.ENTREGACODIGOPOSTALTextBox.Validated += new System.EventHandler(this.ENTREGACODIGOPOSTALTextBox_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(523, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 216;
            this.label6.Text = "Num. Int. ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(250, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 214;
            this.label11.Text = "Código Postal ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(345, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 215;
            this.label8.Text = "Num. Ext ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(8, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 212;
            this.label10.Text = "Estado ";
            // 
            // ENTREGANUMEROINTERIORTextBox
            // 
            this.ENTREGANUMEROINTERIORTextBox.Location = new System.Drawing.Point(526, 249);
            this.ENTREGANUMEROINTERIORTextBox.Name = "ENTREGANUMEROINTERIORTextBox";
            this.ENTREGANUMEROINTERIORTextBox.Size = new System.Drawing.Size(73, 20);
            this.ENTREGANUMEROINTERIORTextBox.TabIndex = 212;
            // 
            // ENTREGANUMEROEXTERIORTextBox
            // 
            this.ENTREGANUMEROEXTERIORTextBox.Location = new System.Drawing.Point(348, 249);
            this.ENTREGANUMEROEXTERIORTextBox.Name = "ENTREGANUMEROEXTERIORTextBox";
            this.ENTREGANUMEROEXTERIORTextBox.Size = new System.Drawing.Size(69, 20);
            this.ENTREGANUMEROEXTERIORTextBox.TabIndex = 211;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(6, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 213;
            this.label9.Text = "Ciudad ";
            // 
            // ENTREGACALLETextBox
            // 
            this.ENTREGACALLETextBox.Location = new System.Drawing.Point(12, 249);
            this.ENTREGACALLETextBox.Name = "ENTREGACALLETextBox";
            this.ENTREGACALLETextBox.Size = new System.Drawing.Size(327, 20);
            this.ENTREGACALLETextBox.TabIndex = 209;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(344, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 210;
            this.label13.Text = "Colonia ";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Location = new System.Drawing.Point(166, 315);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(140, 13);
            this.label36.TabIndex = 291;
            this.label36.Text = "Referencia domiciliaria:";
            // 
            // ENTREGAREFERENCIADOMTextBox
            // 
            this.ENTREGAREFERENCIADOMTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ENTREGAREFERENCIADOMTextBox.Location = new System.Drawing.Point(166, 331);
            this.ENTREGAREFERENCIADOMTextBox.Name = "ENTREGAREFERENCIADOMTextBox";
            this.ENTREGAREFERENCIADOMTextBox.Size = new System.Drawing.Size(339, 20);
            this.ENTREGAREFERENCIADOMTextBox.TabIndex = 213;
            // 
            // WFSucursalEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(763, 646);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.CLAVELabel);
            this.Controls.Add(this.CLAVETextBox);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFSucursalEdit";
            this.Text = "SUCURSAL";
            this.Load += new System.EventHandler(this.LINEAEdit_Reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.TextBox DESCRIPCIONTextBox;
        private System.Windows.Forms.Button GRUPOSUCURSALIDButton;
        private Tools.TextBoxFB GRUPOSUCURSALIDTextBox;
        private System.Windows.Forms.Label GRUPOSUCURSALIDLabel;
        private System.Windows.Forms.NumericTextBox MAXDOCTOSPENDIENTESTextBox;
        private System.Windows.Forms.ComboBox LISTA_PRECIO_TRASPASOTextBox;
        private System.Windows.Forms.Label LISTAPRECIOIDLabel;
        private System.Windows.Forms.CheckBox ESMATRIZTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox MOSTRARPRECIOREALTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox PRECIORECEPCIONTRASLADOTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PRECIOENVIOTRASLADOTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CLIENTECLAVEButton;
        private Tools.TextBoxFB CLIENTECLAVETextBox;
        private System.Windows.Forms.Label CLIENTECLAVELabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox POR_FACT_ELECTTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ESFRANQUICIATextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBoxFB ENTREGAESTADOTextBox;
        private System.Windows.Forms.TextBox ENTREGACODIGOPOSTALTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ENTREGANUMEROINTERIORTextBox;
        private System.Windows.Forms.TextBox ENTREGANUMEROEXTERIORTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ENTREGACALLETextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button PROVEEDORCLAVEButton;
        private Tools.TextBoxFB PROVEEDORCLAVETextBox;
        private System.Windows.Forms.Label PROVEEDORCLAVELabel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button SURTIDORButton;
        private Tools.TextBoxFB SURTIDORTextBox;
        private System.Windows.Forms.Label SURTIDORLabel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericTextBox PORC_AUMENTO_PRECIOTextBox;
        private System.Windows.Forms.TextBox txtRutaRespaldoDestino;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtRutaRespaldoOrigen;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox PREFIJOPRECIOXDESCUENTOTextBox;
        private System.Windows.Forms.CheckBox MANEJAPRECIOXDESCUENTOTextBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtNombreRespaldoBD;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox CUENTAREFERENCIATextBox;
        private System.Windows.Forms.ComboBoxFB BANCOCLAVETextBox;
        private System.Windows.Forms.TextBox txtRutaRespaldoRed;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox CUENTAPOLIZATextBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBoxFB LISTAPRECIOCLAVETextBox;
        private System.Windows.Forms.Button EMPPROVButton;
        private Tools.TextBoxFB EMPPROVTextBox;
        private System.Windows.Forms.Label EMPPROVLabel;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox IMNUPRODTextBox;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button ENTREGA_SAT_LOCALIDADIDButton;
        private System.Windows.Forms.Label ENTREGA_SAT_LOCALIDADIDLabel;
        private Tools.TextBoxFB ENTREGA_SAT_LOCALIDADIDTextBox;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button ENTREGA_SAT_MUNICIPIOIDButton;
        private System.Windows.Forms.Label ENTREGA_SAT_MUNICIPIOIDLabel;
        private Tools.TextBoxFB ENTREGA_SAT_MUNICIPIOIDTextBox;
        private System.Windows.Forms.Button ENTREGA_SAT_COLONIAIDButton;
        private System.Windows.Forms.Label ENTREGA_SAT_COLONIAIDLabel;
        private Tools.TextBoxFB ENTREGA_SAT_COLONIAIDTextBox;
        private System.Windows.Forms.NumericTextBox ENTREGA_DISTANCIATextBox;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox ENTREGAREFERENCIADOMTextBox;
    }
}

