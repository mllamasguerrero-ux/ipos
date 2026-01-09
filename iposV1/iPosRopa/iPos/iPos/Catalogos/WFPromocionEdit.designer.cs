
namespace iPos
{
    partial class WFPromocionEdit
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
            this.components = new System.ComponentModel.Container();
            FirebirdSql.Data.FirebirdClient.FbParameter fbParameter1 = new FirebirdSql.Data.FirebirdClient.FbParameter();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPromocionEdit));
            this.RFV_CLAVE = new CustomValidation.RequiredFieldValidator();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.sUCURSALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCatalogos = new iPos.Catalogos.DSCatalogos();
            this.sUCURSALTableAdapter = new iPos.Catalogos.DSCatalogosTableAdapters.SUCURSALTableAdapter();
            this.tableAdapterManager = new iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.flatTabControl1 = new FlatTabControl.FlatTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.CLAVELabel = new System.Windows.Forms.Label();
            this.CLAVETextBox = new System.Windows.Forms.TextBox();
            this.ESMULTIDETALLETextBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.JUEVESTextBox = new System.Windows.Forms.CheckBox();
            this.DESCMULTIDETALLETextBox = new System.Windows.Forms.TextBox();
            this.MARTESTextBox = new System.Windows.Forms.CheckBox();
            this.DOMINGOTextBox = new System.Windows.Forms.CheckBox();
            this.LUNESTextBox = new System.Windows.Forms.CheckBox();
            this.SABADOTextBox = new System.Windows.Forms.CheckBox();
            this.MIERCOLESTextBox = new System.Windows.Forms.CheckBox();
            this.FECHAFINTextBox = new System.Windows.Forms.DateTimePicker();
            this.VIERNESTextBox = new System.Windows.Forms.CheckBox();
            this.FECHAINICIOTextBox = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.MOSTRARDATOSCLIENTETextBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RBCADAMONTO = new System.Windows.Forms.RadioButton();
            this.RBMONTOMINIMO = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.leyendaTextBox = new System.Windows.Forms.TextBox();
            this.montoMinimoNumericTextBox = new System.Windows.Forms.NumericTextBox();
            this.RBTIPOPROMOCIONCUPONES = new System.Windows.Forms.RadioButton();
            this.pnlBodegazo = new System.Windows.Forms.Panel();
            this.RBTIPOPROMOCION7 = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.PORCENTAJEAUMENTOBODEGAZOTextBox = new System.Windows.Forms.NumericTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ENMONEDEROBODEGAZOTextBox = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.IMPORTE6TextBox = new System.Windows.Forms.NumericTextBox();
            this.CANTIDAD6TextBox = new System.Windows.Forms.NumericTextBox();
            this.RBTIPOPROMOCION6 = new System.Windows.Forms.RadioButton();
            this.pnlPromocionXMontoMin = new System.Windows.Forms.Panel();
            this.MONTOMINDESCLINEATextBox = new System.Windows.Forms.NumericTextBox();
            this.RBTIPOPROMOCION4 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.DESCMONTOMINTextBox = new System.Windows.Forms.NumericTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ENMONEDEROTextBox = new System.Windows.Forms.CheckBox();
            this.PORCENTAJEDESCUENTOTextBox = new System.Windows.Forms.NumericTextBox();
            this.IMPORTETextBox = new System.Windows.Forms.NumericTextBox();
            this.CANTIDAD2TextBox = new System.Windows.Forms.NumericTextBox();
            this.CANTIDADLLEVATETextBox = new System.Windows.Forms.NumericTextBox();
            this.CANTIDADTextBox = new System.Windows.Forms.NumericTextBox();
            this.RBTIPOPROMOCION3 = new System.Windows.Forms.RadioButton();
            this.RBTIPOPROMOCION2 = new System.Windows.Forms.RadioButton();
            this.RBTIPOPROMOCION1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBRANGOGENERAL = new System.Windows.Forms.RadioButton();
            this.RBRANGOBODEGAZO = new System.Windows.Forms.RadioButton();
            this.PRODUCTOIDTextBox = new System.Windows.Forms.TextBox();
            this.PRODUCTOIDButton = new System.Windows.Forms.Button();
            this.LINEAIDButton = new System.Windows.Forms.Button();
            this.PRODUCTOIDLabel = new System.Windows.Forms.Label();
            this.LINEAIDLabel = new System.Windows.Forms.Label();
            this.LINEAIDTextBox = new iPos.Tools.TextBoxFB();
            this.RBRANGOLINEA = new System.Windows.Forms.RadioButton();
            this.RBRANGOPRODUCTO = new System.Windows.Forms.RadioButton();
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.ACTIVOLabel = new System.Windows.Forms.Label();
            this.NOMBRELabel = new System.Windows.Forms.Label();
            this.NOMBRETextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sUCURSALDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CBTodasSucursales = new System.Windows.Forms.CheckBox();
            this.tabImagen = new System.Windows.Forms.TabPage();
            this.btnEliminarImagen = new System.Windows.Forms.Button();
            this.IMAGENTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnImageSelector = new System.Windows.Forms.Button();
            this.NuevaImagenTextBox = new System.Windows.Forms.TextBox();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).BeginInit();
            this.flatTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlBodegazo.SuspendLayout();
            this.pnlPromocionXMontoMin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALDataGridView)).BeginInit();
            this.tabImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RFV_CLAVE
            // 
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
            // sUCURSALBindingSource
            // 
            this.sUCURSALBindingSource.DataMember = "SUCURSAL";
            this.sUCURSALBindingSource.DataSource = this.dSCatalogos;
            // 
            // dSCatalogos
            // 
            this.dSCatalogos.DataSetName = "DSCatalogos";
            this.dSCatalogos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sUCURSALTableAdapter
            // 
            this.sUCURSALTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.LINEA_VIEWTableAdapter = null;
            this.tableAdapterManager.PERSONAAPARTADOTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
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
            this.BTCancelar.Location = new System.Drawing.Point(450, 523);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(121, 30);
            this.BTCancelar.TabIndex = 49;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // flatTabControl1
            // 
            this.flatTabControl1.Controls.Add(this.tabPage1);
            this.flatTabControl1.Controls.Add(this.tabPage2);
            this.flatTabControl1.Controls.Add(this.tabImagen);
            this.flatTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flatTabControl1.Location = new System.Drawing.Point(0, 0);
            this.flatTabControl1.Name = "flatTabControl1";
            this.flatTabControl1.SelectedIndex = 0;
            this.flatTabControl1.Size = new System.Drawing.Size(822, 520);
            this.flatTabControl1.TabIndex = 2;
            this.flatTabControl1.SelectedIndexChanged += new System.EventHandler(this.flatTabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.tabPage1.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(814, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Promocion";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.CLAVELabel);
            this.panel1.Controls.Add(this.CLAVETextBox);
            this.panel1.Controls.Add(this.ESMULTIDETALLETextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.JUEVESTextBox);
            this.panel1.Controls.Add(this.DESCMULTIDETALLETextBox);
            this.panel1.Controls.Add(this.MARTESTextBox);
            this.panel1.Controls.Add(this.DOMINGOTextBox);
            this.panel1.Controls.Add(this.LUNESTextBox);
            this.panel1.Controls.Add(this.SABADOTextBox);
            this.panel1.Controls.Add(this.MIERCOLESTextBox);
            this.panel1.Controls.Add(this.FECHAFINTextBox);
            this.panel1.Controls.Add(this.VIERNESTextBox);
            this.panel1.Controls.Add(this.FECHAINICIOTextBox);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.ACTIVOTextBox);
            this.panel1.Controls.Add(this.ACTIVOLabel);
            this.panel1.Controls.Add(this.NOMBRELabel);
            this.panel1.Controls.Add(this.NOMBRETextBox);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 492);
            this.panel1.TabIndex = 47;
            this.panel1.TabStop = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label20.Location = new System.Drawing.Point(578, 414);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 13);
            this.label20.TabIndex = 172;
            this.label20.Text = "Es multidetalle:";
            // 
            // CLAVELabel
            // 
            this.CLAVELabel.AutoSize = true;
            this.CLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLAVELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLAVELabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CLAVELabel.Location = new System.Drawing.Point(9, 34);
            this.CLAVELabel.Name = "CLAVELabel";
            this.CLAVELabel.Size = new System.Drawing.Size(43, 13);
            this.CLAVELabel.TabIndex = 62;
            this.CLAVELabel.Text = "Clave:";
            // 
            // CLAVETextBox
            // 
            this.CLAVETextBox.Location = new System.Drawing.Point(88, 31);
            this.CLAVETextBox.Name = "CLAVETextBox";
            this.CLAVETextBox.Size = new System.Drawing.Size(204, 20);
            this.CLAVETextBox.TabIndex = 63;
            // 
            // ESMULTIDETALLETextBox
            // 
            this.ESMULTIDETALLETextBox.AutoSize = true;
            this.ESMULTIDETALLETextBox.Location = new System.Drawing.Point(675, 413);
            this.ESMULTIDETALLETextBox.Name = "ESMULTIDETALLETextBox";
            this.ESMULTIDETALLETextBox.Size = new System.Drawing.Size(15, 14);
            this.ESMULTIDETALLETextBox.TabIndex = 170;
            this.ESMULTIDETALLETextBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(19, 449);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Dias de aplicacion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(332, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Fin:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label21.Location = new System.Drawing.Point(580, 437);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(159, 13);
            this.label21.TabIndex = 171;
            this.label21.Text = "Tag promocion multidetalle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(21, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Inicio:";
            // 
            // JUEVESTextBox
            // 
            this.JUEVESTextBox.AutoSize = true;
            this.JUEVESTextBox.ForeColor = System.Drawing.Color.White;
            this.JUEVESTextBox.Location = new System.Drawing.Point(266, 448);
            this.JUEVESTextBox.Name = "JUEVESTextBox";
            this.JUEVESTextBox.Size = new System.Drawing.Size(31, 17);
            this.JUEVESTextBox.TabIndex = 29;
            this.JUEVESTextBox.Text = "J";
            this.JUEVESTextBox.UseVisualStyleBackColor = true;
            // 
            // DESCMULTIDETALLETextBox
            // 
            this.DESCMULTIDETALLETextBox.Location = new System.Drawing.Point(580, 454);
            this.DESCMULTIDETALLETextBox.MaxLength = 255;
            this.DESCMULTIDETALLETextBox.Multiline = true;
            this.DESCMULTIDETALLETextBox.Name = "DESCMULTIDETALLETextBox";
            this.DESCMULTIDETALLETextBox.Size = new System.Drawing.Size(214, 31);
            this.DESCMULTIDETALLETextBox.TabIndex = 169;
            // 
            // MARTESTextBox
            // 
            this.MARTESTextBox.AutoSize = true;
            this.MARTESTextBox.ForeColor = System.Drawing.Color.White;
            this.MARTESTextBox.Location = new System.Drawing.Point(191, 447);
            this.MARTESTextBox.Name = "MARTESTextBox";
            this.MARTESTextBox.Size = new System.Drawing.Size(35, 17);
            this.MARTESTextBox.TabIndex = 27;
            this.MARTESTextBox.Text = "M";
            this.MARTESTextBox.UseVisualStyleBackColor = true;
            // 
            // DOMINGOTextBox
            // 
            this.DOMINGOTextBox.AutoSize = true;
            this.DOMINGOTextBox.ForeColor = System.Drawing.Color.White;
            this.DOMINGOTextBox.Location = new System.Drawing.Point(381, 447);
            this.DOMINGOTextBox.Name = "DOMINGOTextBox";
            this.DOMINGOTextBox.Size = new System.Drawing.Size(34, 17);
            this.DOMINGOTextBox.TabIndex = 32;
            this.DOMINGOTextBox.Text = "D";
            this.DOMINGOTextBox.UseVisualStyleBackColor = true;
            // 
            // LUNESTextBox
            // 
            this.LUNESTextBox.AutoSize = true;
            this.LUNESTextBox.ForeColor = System.Drawing.Color.White;
            this.LUNESTextBox.Location = new System.Drawing.Point(152, 447);
            this.LUNESTextBox.Name = "LUNESTextBox";
            this.LUNESTextBox.Size = new System.Drawing.Size(32, 17);
            this.LUNESTextBox.TabIndex = 26;
            this.LUNESTextBox.Text = "L";
            this.LUNESTextBox.UseVisualStyleBackColor = true;
            // 
            // SABADOTextBox
            // 
            this.SABADOTextBox.AutoSize = true;
            this.SABADOTextBox.ForeColor = System.Drawing.Color.White;
            this.SABADOTextBox.Location = new System.Drawing.Point(342, 447);
            this.SABADOTextBox.Name = "SABADOTextBox";
            this.SABADOTextBox.Size = new System.Drawing.Size(33, 17);
            this.SABADOTextBox.TabIndex = 31;
            this.SABADOTextBox.Text = "S";
            this.SABADOTextBox.UseVisualStyleBackColor = true;
            // 
            // MIERCOLESTextBox
            // 
            this.MIERCOLESTextBox.AutoSize = true;
            this.MIERCOLESTextBox.ForeColor = System.Drawing.Color.White;
            this.MIERCOLESTextBox.Location = new System.Drawing.Point(231, 448);
            this.MIERCOLESTextBox.Name = "MIERCOLESTextBox";
            this.MIERCOLESTextBox.Size = new System.Drawing.Size(29, 17);
            this.MIERCOLESTextBox.TabIndex = 28;
            this.MIERCOLESTextBox.Text = "I";
            this.MIERCOLESTextBox.UseVisualStyleBackColor = true;
            // 
            // FECHAFINTextBox
            // 
            this.FECHAFINTextBox.Location = new System.Drawing.Point(366, 411);
            this.FECHAFINTextBox.Name = "FECHAFINTextBox";
            this.FECHAFINTextBox.Size = new System.Drawing.Size(200, 20);
            this.FECHAFINTextBox.TabIndex = 25;
            // 
            // VIERNESTextBox
            // 
            this.VIERNESTextBox.AutoSize = true;
            this.VIERNESTextBox.ForeColor = System.Drawing.Color.White;
            this.VIERNESTextBox.Location = new System.Drawing.Point(303, 447);
            this.VIERNESTextBox.Name = "VIERNESTextBox";
            this.VIERNESTextBox.Size = new System.Drawing.Size(33, 17);
            this.VIERNESTextBox.TabIndex = 30;
            this.VIERNESTextBox.Text = "V";
            this.VIERNESTextBox.UseVisualStyleBackColor = true;
            // 
            // FECHAINICIOTextBox
            // 
            this.FECHAINICIOTextBox.Location = new System.Drawing.Point(69, 411);
            this.FECHAINICIOTextBox.Name = "FECHAINICIOTextBox";
            this.FECHAINICIOTextBox.Size = new System.Drawing.Size(200, 20);
            this.FECHAINICIOTextBox.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.RBTIPOPROMOCIONCUPONES);
            this.groupBox2.Controls.Add(this.pnlBodegazo);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.IMPORTE6TextBox);
            this.groupBox2.Controls.Add(this.CANTIDAD6TextBox);
            this.groupBox2.Controls.Add(this.RBTIPOPROMOCION6);
            this.groupBox2.Controls.Add(this.pnlPromocionXMontoMin);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ENMONEDEROTextBox);
            this.groupBox2.Controls.Add(this.PORCENTAJEDESCUENTOTextBox);
            this.groupBox2.Controls.Add(this.IMPORTETextBox);
            this.groupBox2.Controls.Add(this.CANTIDAD2TextBox);
            this.groupBox2.Controls.Add(this.CANTIDADLLEVATETextBox);
            this.groupBox2.Controls.Add(this.CANTIDADTextBox);
            this.groupBox2.Controls.Add(this.RBTIPOPROMOCION3);
            this.groupBox2.Controls.Add(this.RBTIPOPROMOCION2);
            this.groupBox2.Controls.Add(this.RBTIPOPROMOCION1);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(6, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(786, 277);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TIPO PROMOCION";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.MOSTRARDATOSCLIENTETextBox);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.leyendaTextBox);
            this.panel3.Controls.Add(this.montoMinimoNumericTextBox);
            this.panel3.Location = new System.Drawing.Point(574, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(206, 237);
            this.panel3.TabIndex = 66;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label18.Location = new System.Drawing.Point(19, 171);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(120, 13);
            this.label18.TabIndex = 168;
            this.label18.Text = "Mostrar datos de cliente";
            // 
            // MOSTRARDATOSCLIENTETextBox
            // 
            this.MOSTRARDATOSCLIENTETextBox.AutoSize = true;
            this.MOSTRARDATOSCLIENTETextBox.Location = new System.Drawing.Point(19, 194);
            this.MOSTRARDATOSCLIENTETextBox.Name = "MOSTRARDATOSCLIENTETextBox";
            this.MOSTRARDATOSCLIENTETextBox.Size = new System.Drawing.Size(15, 14);
            this.MOSTRARDATOSCLIENTETextBox.TabIndex = 165;
            this.MOSTRARDATOSCLIENTETextBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RBCADAMONTO);
            this.groupBox3.Controls.Add(this.RBMONTOMINIMO);
            this.groupBox3.Location = new System.Drawing.Point(21, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 41);
            this.groupBox3.TabIndex = 166;
            this.groupBox3.TabStop = false;
            // 
            // RBCADAMONTO
            // 
            this.RBCADAMONTO.AutoSize = true;
            this.RBCADAMONTO.Location = new System.Drawing.Point(98, 8);
            this.RBCADAMONTO.Name = "RBCADAMONTO";
            this.RBCADAMONTO.Size = new System.Drawing.Size(83, 17);
            this.RBCADAMONTO.TabIndex = 163;
            this.RBCADAMONTO.TabStop = true;
            this.RBCADAMONTO.Text = "Cada Monto";
            this.RBCADAMONTO.UseVisualStyleBackColor = true;
            // 
            // RBMONTOMINIMO
            // 
            this.RBMONTOMINIMO.AutoSize = true;
            this.RBMONTOMINIMO.Location = new System.Drawing.Point(4, 9);
            this.RBMONTOMINIMO.Name = "RBMONTOMINIMO";
            this.RBMONTOMINIMO.Size = new System.Drawing.Size(90, 17);
            this.RBMONTOMINIMO.TabIndex = 162;
            this.RBMONTOMINIMO.TabStop = true;
            this.RBMONTOMINIMO.Text = "Monto minimo";
            this.RBMONTOMINIMO.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label17.Location = new System.Drawing.Point(16, 95);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 165;
            this.label17.Text = "Leyenda";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label16.Location = new System.Drawing.Point(16, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 163;
            this.label16.Text = "Monto";
            // 
            // leyendaTextBox
            // 
            this.leyendaTextBox.Location = new System.Drawing.Point(19, 114);
            this.leyendaTextBox.MaxLength = 255;
            this.leyendaTextBox.Multiline = true;
            this.leyendaTextBox.Name = "leyendaTextBox";
            this.leyendaTextBox.Size = new System.Drawing.Size(151, 45);
            this.leyendaTextBox.TabIndex = 164;
            // 
            // montoMinimoNumericTextBox
            // 
            this.montoMinimoNumericTextBox.AllowNegative = true;
            this.montoMinimoNumericTextBox.Format_Expression = null;
            this.montoMinimoNumericTextBox.Location = new System.Drawing.Point(19, 70);
            this.montoMinimoNumericTextBox.Name = "montoMinimoNumericTextBox";
            this.montoMinimoNumericTextBox.NumericPrecision = 18;
            this.montoMinimoNumericTextBox.NumericScaleOnFocus = 2;
            this.montoMinimoNumericTextBox.NumericScaleOnLostFocus = 2;
            this.montoMinimoNumericTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.montoMinimoNumericTextBox.Size = new System.Drawing.Size(151, 20);
            this.montoMinimoNumericTextBox.TabIndex = 162;
            this.montoMinimoNumericTextBox.Tag = 34;
            this.montoMinimoNumericTextBox.Text = "0";
            this.montoMinimoNumericTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.montoMinimoNumericTextBox.ValidationExpression = null;
            this.montoMinimoNumericTextBox.ZeroIsValid = true;
            // 
            // RBTIPOPROMOCIONCUPONES
            // 
            this.RBTIPOPROMOCIONCUPONES.AutoSize = true;
            this.RBTIPOPROMOCIONCUPONES.Location = new System.Drawing.Point(579, 10);
            this.RBTIPOPROMOCIONCUPONES.Name = "RBTIPOPROMOCIONCUPONES";
            this.RBTIPOPROMOCIONCUPONES.Size = new System.Drawing.Size(67, 17);
            this.RBTIPOPROMOCIONCUPONES.TabIndex = 161;
            this.RBTIPOPROMOCIONCUPONES.TabStop = true;
            this.RBTIPOPROMOCIONCUPONES.Text = "Cupones";
            this.RBTIPOPROMOCIONCUPONES.UseVisualStyleBackColor = true;
            // 
            // pnlBodegazo
            // 
            this.pnlBodegazo.Controls.Add(this.RBTIPOPROMOCION7);
            this.pnlBodegazo.Controls.Add(this.label14);
            this.pnlBodegazo.Controls.Add(this.PORCENTAJEAUMENTOBODEGAZOTextBox);
            this.pnlBodegazo.Controls.Add(this.label15);
            this.pnlBodegazo.Controls.Add(this.ENMONEDEROBODEGAZOTextBox);
            this.pnlBodegazo.Location = new System.Drawing.Point(304, 204);
            this.pnlBodegazo.Name = "pnlBodegazo";
            this.pnlBodegazo.Size = new System.Drawing.Size(262, 67);
            this.pnlBodegazo.TabIndex = 76;
            // 
            // RBTIPOPROMOCION7
            // 
            this.RBTIPOPROMOCION7.AutoSize = true;
            this.RBTIPOPROMOCION7.Location = new System.Drawing.Point(3, 4);
            this.RBTIPOPROMOCION7.Name = "RBTIPOPROMOCION7";
            this.RBTIPOPROMOCION7.Size = new System.Drawing.Size(136, 17);
            this.RBTIPOPROMOCION7.TabIndex = 71;
            this.RBTIPOPROMOCION7.TabStop = true;
            this.RBTIPOPROMOCION7.Text = "Porcentaje sumar costo";
            this.RBTIPOPROMOCION7.UseVisualStyleBackColor = true;
            this.RBTIPOPROMOCION7.CheckedChanged += new System.EventHandler(this.RBTIPOPROMOCION1_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label14.Location = new System.Drawing.Point(149, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 13);
            this.label14.TabIndex = 75;
            this.label14.Text = "Aplicar en monedero?";
            // 
            // PORCENTAJEAUMENTOBODEGAZOTextBox
            // 
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.AllowNegative = true;
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.Format_Expression = null;
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.Location = new System.Drawing.Point(19, 38);
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.Name = "PORCENTAJEAUMENTOBODEGAZOTextBox";
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.NumericPrecision = 18;
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.NumericScaleOnFocus = 2;
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.NumericScaleOnLostFocus = 2;
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.Size = new System.Drawing.Size(100, 20);
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.TabIndex = 72;
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.Tag = "41";
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.Text = "0";
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.ValidationExpression = null;
            this.PORCENTAJEAUMENTOBODEGAZOTextBox.ZeroIsValid = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label15.Location = new System.Drawing.Point(30, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 74;
            this.label15.Text = "Porcentaje:";
            // 
            // ENMONEDEROBODEGAZOTextBox
            // 
            this.ENMONEDEROBODEGAZOTextBox.AutoSize = true;
            this.ENMONEDEROBODEGAZOTextBox.Location = new System.Drawing.Point(197, 41);
            this.ENMONEDEROBODEGAZOTextBox.Name = "ENMONEDEROBODEGAZOTextBox";
            this.ENMONEDEROBODEGAZOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ENMONEDEROBODEGAZOTextBox.TabIndex = 73;
            this.ENMONEDEROBODEGAZOTextBox.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label12.Location = new System.Drawing.Point(167, 207);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 13);
            this.label12.TabIndex = 70;
            this.label12.Text = "Con importe total de:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label13.Location = new System.Drawing.Point(37, 207);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 69;
            this.label13.Text = "Compra:";
            // 
            // IMPORTE6TextBox
            // 
            this.IMPORTE6TextBox.AllowNegative = true;
            this.IMPORTE6TextBox.Format_Expression = null;
            this.IMPORTE6TextBox.Location = new System.Drawing.Point(164, 223);
            this.IMPORTE6TextBox.Name = "IMPORTE6TextBox";
            this.IMPORTE6TextBox.NumericPrecision = 18;
            this.IMPORTE6TextBox.NumericScaleOnFocus = 2;
            this.IMPORTE6TextBox.NumericScaleOnLostFocus = 2;
            this.IMPORTE6TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.IMPORTE6TextBox.Size = new System.Drawing.Size(100, 20);
            this.IMPORTE6TextBox.TabIndex = 68;
            this.IMPORTE6TextBox.Tag = 34;
            this.IMPORTE6TextBox.Text = "0";
            this.IMPORTE6TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IMPORTE6TextBox.ValidationExpression = null;
            this.IMPORTE6TextBox.ZeroIsValid = true;
            // 
            // CANTIDAD6TextBox
            // 
            this.CANTIDAD6TextBox.AllowNegative = true;
            this.CANTIDAD6TextBox.Format_Expression = null;
            this.CANTIDAD6TextBox.Location = new System.Drawing.Point(27, 223);
            this.CANTIDAD6TextBox.Name = "CANTIDAD6TextBox";
            this.CANTIDAD6TextBox.NumericPrecision = 18;
            this.CANTIDAD6TextBox.NumericScaleOnFocus = 2;
            this.CANTIDAD6TextBox.NumericScaleOnLostFocus = 2;
            this.CANTIDAD6TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CANTIDAD6TextBox.Size = new System.Drawing.Size(100, 20);
            this.CANTIDAD6TextBox.TabIndex = 67;
            this.CANTIDAD6TextBox.Tag = 34;
            this.CANTIDAD6TextBox.Text = "0.00";
            this.CANTIDAD6TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CANTIDAD6TextBox.ValidationExpression = null;
            this.CANTIDAD6TextBox.ZeroIsValid = true;
            // 
            // RBTIPOPROMOCION6
            // 
            this.RBTIPOPROMOCION6.AutoSize = true;
            this.RBTIPOPROMOCION6.Location = new System.Drawing.Point(13, 172);
            this.RBTIPOPROMOCION6.Name = "RBTIPOPROMOCION6";
            this.RBTIPOPROMOCION6.Size = new System.Drawing.Size(443, 17);
            this.RBTIPOPROMOCION6.TabIndex = 66;
            this.RBTIPOPROMOCION6.TabStop = true;
            this.RBTIPOPROMOCION6.Text = "Compra x cantidad con un importe menor y el precio bajo se mantedra para los sigu" +
    "ientes";
            this.RBTIPOPROMOCION6.UseVisualStyleBackColor = true;
            this.RBTIPOPROMOCION6.CheckedChanged += new System.EventHandler(this.RBTIPOPROMOCION1_CheckedChanged);
            // 
            // pnlPromocionXMontoMin
            // 
            this.pnlPromocionXMontoMin.Controls.Add(this.MONTOMINDESCLINEATextBox);
            this.pnlPromocionXMontoMin.Controls.Add(this.RBTIPOPROMOCION4);
            this.pnlPromocionXMontoMin.Controls.Add(this.label10);
            this.pnlPromocionXMontoMin.Controls.Add(this.DESCMONTOMINTextBox);
            this.pnlPromocionXMontoMin.Controls.Add(this.label11);
            this.pnlPromocionXMontoMin.Location = new System.Drawing.Point(304, 97);
            this.pnlPromocionXMontoMin.Name = "pnlPromocionXMontoMin";
            this.pnlPromocionXMontoMin.Size = new System.Drawing.Size(269, 57);
            this.pnlPromocionXMontoMin.TabIndex = 65;
            // 
            // MONTOMINDESCLINEATextBox
            // 
            this.MONTOMINDESCLINEATextBox.AllowNegative = true;
            this.MONTOMINDESCLINEATextBox.Format_Expression = null;
            this.MONTOMINDESCLINEATextBox.Location = new System.Drawing.Point(20, 33);
            this.MONTOMINDESCLINEATextBox.Name = "MONTOMINDESCLINEATextBox";
            this.MONTOMINDESCLINEATextBox.NumericPrecision = 18;
            this.MONTOMINDESCLINEATextBox.NumericScaleOnFocus = 2;
            this.MONTOMINDESCLINEATextBox.NumericScaleOnLostFocus = 2;
            this.MONTOMINDESCLINEATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MONTOMINDESCLINEATextBox.Size = new System.Drawing.Size(100, 20);
            this.MONTOMINDESCLINEATextBox.TabIndex = 22;
            this.MONTOMINDESCLINEATextBox.Tag = 34;
            this.MONTOMINDESCLINEATextBox.Text = "0.00";
            this.MONTOMINDESCLINEATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MONTOMINDESCLINEATextBox.ValidationExpression = null;
            this.MONTOMINDESCLINEATextBox.ZeroIsValid = true;
            // 
            // RBTIPOPROMOCION4
            // 
            this.RBTIPOPROMOCION4.AutoSize = true;
            this.RBTIPOPROMOCION4.Location = new System.Drawing.Point(3, 3);
            this.RBTIPOPROMOCION4.Name = "RBTIPOPROMOCION4";
            this.RBTIPOPROMOCION4.Size = new System.Drawing.Size(163, 17);
            this.RBTIPOPROMOCION4.TabIndex = 21;
            this.RBTIPOPROMOCION4.TabStop = true;
            this.RBTIPOPROMOCION4.Text = "Descuento x monto por linea:";
            this.RBTIPOPROMOCION4.UseVisualStyleBackColor = true;
            this.RBTIPOPROMOCION4.CheckedChanged += new System.EventHandler(this.RBTIPOPROMOCION1_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label10.Location = new System.Drawing.Point(17, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "Monto minimo de compra:";
            // 
            // DESCMONTOMINTextBox
            // 
            this.DESCMONTOMINTextBox.AllowNegative = true;
            this.DESCMONTOMINTextBox.Format_Expression = null;
            this.DESCMONTOMINTextBox.Location = new System.Drawing.Point(157, 35);
            this.DESCMONTOMINTextBox.Name = "DESCMONTOMINTextBox";
            this.DESCMONTOMINTextBox.NumericPrecision = 18;
            this.DESCMONTOMINTextBox.NumericScaleOnFocus = 2;
            this.DESCMONTOMINTextBox.NumericScaleOnLostFocus = 2;
            this.DESCMONTOMINTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DESCMONTOMINTextBox.Size = new System.Drawing.Size(100, 20);
            this.DESCMONTOMINTextBox.TabIndex = 23;
            this.DESCMONTOMINTextBox.Tag = "41";
            this.DESCMONTOMINTextBox.Text = "0";
            this.DESCMONTOMINTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DESCMONTOMINTextBox.ValidationExpression = null;
            this.DESCMONTOMINTextBox.ZeroIsValid = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label11.Location = new System.Drawing.Point(161, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 13);
            this.label11.TabIndex = 64;
            this.label11.Text = "Porcentaje descuento:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label9.Location = new System.Drawing.Point(163, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "Aplicar en monedero?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(37, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "Porcentaje:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(464, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Con importe total de:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(334, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Compra:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(172, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Llevate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(34, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Compra:";
            // 
            // ENMONEDEROTextBox
            // 
            this.ENMONEDEROTextBox.AutoSize = true;
            this.ENMONEDEROTextBox.Location = new System.Drawing.Point(189, 137);
            this.ENMONEDEROTextBox.Name = "ENMONEDEROTextBox";
            this.ENMONEDEROTextBox.Size = new System.Drawing.Size(15, 14);
            this.ENMONEDEROTextBox.TabIndex = 20;
            this.ENMONEDEROTextBox.UseVisualStyleBackColor = true;
            // 
            // PORCENTAJEDESCUENTOTextBox
            // 
            this.PORCENTAJEDESCUENTOTextBox.AllowNegative = true;
            this.PORCENTAJEDESCUENTOTextBox.Format_Expression = null;
            this.PORCENTAJEDESCUENTOTextBox.Location = new System.Drawing.Point(26, 134);
            this.PORCENTAJEDESCUENTOTextBox.Name = "PORCENTAJEDESCUENTOTextBox";
            this.PORCENTAJEDESCUENTOTextBox.NumericPrecision = 18;
            this.PORCENTAJEDESCUENTOTextBox.NumericScaleOnFocus = 2;
            this.PORCENTAJEDESCUENTOTextBox.NumericScaleOnLostFocus = 2;
            this.PORCENTAJEDESCUENTOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PORCENTAJEDESCUENTOTextBox.Size = new System.Drawing.Size(100, 20);
            this.PORCENTAJEDESCUENTOTextBox.TabIndex = 19;
            this.PORCENTAJEDESCUENTOTextBox.Tag = "41";
            this.PORCENTAJEDESCUENTOTextBox.Text = "0";
            this.PORCENTAJEDESCUENTOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PORCENTAJEDESCUENTOTextBox.ValidationExpression = null;
            this.PORCENTAJEDESCUENTOTextBox.ZeroIsValid = true;
            // 
            // IMPORTETextBox
            // 
            this.IMPORTETextBox.AllowNegative = true;
            this.IMPORTETextBox.Format_Expression = null;
            this.IMPORTETextBox.Location = new System.Drawing.Point(461, 61);
            this.IMPORTETextBox.Name = "IMPORTETextBox";
            this.IMPORTETextBox.NumericPrecision = 18;
            this.IMPORTETextBox.NumericScaleOnFocus = 2;
            this.IMPORTETextBox.NumericScaleOnLostFocus = 2;
            this.IMPORTETextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.IMPORTETextBox.Size = new System.Drawing.Size(100, 20);
            this.IMPORTETextBox.TabIndex = 17;
            this.IMPORTETextBox.Tag = 34;
            this.IMPORTETextBox.Text = "0";
            this.IMPORTETextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IMPORTETextBox.ValidationExpression = null;
            this.IMPORTETextBox.ZeroIsValid = true;
            this.IMPORTETextBox.NumericValueChanged += new System.EventHandler(this.IMPORTETextBox_NumericValueChanged);
            // 
            // CANTIDAD2TextBox
            // 
            this.CANTIDAD2TextBox.AllowNegative = true;
            this.CANTIDAD2TextBox.Format_Expression = null;
            this.CANTIDAD2TextBox.Location = new System.Drawing.Point(324, 61);
            this.CANTIDAD2TextBox.Name = "CANTIDAD2TextBox";
            this.CANTIDAD2TextBox.NumericPrecision = 18;
            this.CANTIDAD2TextBox.NumericScaleOnFocus = 2;
            this.CANTIDAD2TextBox.NumericScaleOnLostFocus = 2;
            this.CANTIDAD2TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CANTIDAD2TextBox.Size = new System.Drawing.Size(100, 20);
            this.CANTIDAD2TextBox.TabIndex = 16;
            this.CANTIDAD2TextBox.Tag = 34;
            this.CANTIDAD2TextBox.Text = "0.00";
            this.CANTIDAD2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CANTIDAD2TextBox.ValidationExpression = null;
            this.CANTIDAD2TextBox.ZeroIsValid = true;
            // 
            // CANTIDADLLEVATETextBox
            // 
            this.CANTIDADLLEVATETextBox.AllowNegative = true;
            this.CANTIDADLLEVATETextBox.Format_Expression = null;
            this.CANTIDADLLEVATETextBox.Location = new System.Drawing.Point(160, 62);
            this.CANTIDADLLEVATETextBox.Name = "CANTIDADLLEVATETextBox";
            this.CANTIDADLLEVATETextBox.NumericPrecision = 18;
            this.CANTIDADLLEVATETextBox.NumericScaleOnFocus = 2;
            this.CANTIDADLLEVATETextBox.NumericScaleOnLostFocus = 2;
            this.CANTIDADLLEVATETextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CANTIDADLLEVATETextBox.Size = new System.Drawing.Size(100, 20);
            this.CANTIDADLLEVATETextBox.TabIndex = 14;
            this.CANTIDADLLEVATETextBox.Tag = 34;
            this.CANTIDADLLEVATETextBox.Text = "0";
            this.CANTIDADLLEVATETextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CANTIDADLLEVATETextBox.ValidationExpression = null;
            this.CANTIDADLLEVATETextBox.ZeroIsValid = true;
            // 
            // CANTIDADTextBox
            // 
            this.CANTIDADTextBox.AllowNegative = true;
            this.CANTIDADTextBox.Format_Expression = null;
            this.CANTIDADTextBox.Location = new System.Drawing.Point(23, 62);
            this.CANTIDADTextBox.Name = "CANTIDADTextBox";
            this.CANTIDADTextBox.NumericPrecision = 18;
            this.CANTIDADTextBox.NumericScaleOnFocus = 2;
            this.CANTIDADTextBox.NumericScaleOnLostFocus = 2;
            this.CANTIDADTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CANTIDADTextBox.Size = new System.Drawing.Size(100, 20);
            this.CANTIDADTextBox.TabIndex = 13;
            this.CANTIDADTextBox.Tag = 34;
            this.CANTIDADTextBox.Text = "0";
            this.CANTIDADTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CANTIDADTextBox.ValidationExpression = null;
            this.CANTIDADTextBox.ZeroIsValid = true;
            // 
            // RBTIPOPROMOCION3
            // 
            this.RBTIPOPROMOCION3.AutoSize = true;
            this.RBTIPOPROMOCION3.Location = new System.Drawing.Point(10, 100);
            this.RBTIPOPROMOCION3.Name = "RBTIPOPROMOCION3";
            this.RBTIPOPROMOCION3.Size = new System.Drawing.Size(129, 17);
            this.RBTIPOPROMOCION3.TabIndex = 18;
            this.RBTIPOPROMOCION3.TabStop = true;
            this.RBTIPOPROMOCION3.Text = "Porcentaje descuento";
            this.RBTIPOPROMOCION3.UseVisualStyleBackColor = true;
            this.RBTIPOPROMOCION3.CheckedChanged += new System.EventHandler(this.RBTIPOPROMOCION1_CheckedChanged);
            // 
            // RBTIPOPROMOCION2
            // 
            this.RBTIPOPROMOCION2.AutoSize = true;
            this.RBTIPOPROMOCION2.Location = new System.Drawing.Point(307, 10);
            this.RBTIPOPROMOCION2.Name = "RBTIPOPROMOCION2";
            this.RBTIPOPROMOCION2.Size = new System.Drawing.Size(218, 17);
            this.RBTIPOPROMOCION2.TabIndex = 15;
            this.RBTIPOPROMOCION2.TabStop = true;
            this.RBTIPOPROMOCION2.Text = "Compra x cantidad con un importe menor";
            this.RBTIPOPROMOCION2.UseVisualStyleBackColor = true;
            this.RBTIPOPROMOCION2.CheckedChanged += new System.EventHandler(this.RBTIPOPROMOCION1_CheckedChanged);
            // 
            // RBTIPOPROMOCION1
            // 
            this.RBTIPOPROMOCION1.AutoSize = true;
            this.RBTIPOPROMOCION1.Location = new System.Drawing.Point(10, 10);
            this.RBTIPOPROMOCION1.Name = "RBTIPOPROMOCION1";
            this.RBTIPOPROMOCION1.Size = new System.Drawing.Size(177, 17);
            this.RBTIPOPROMOCION1.TabIndex = 12;
            this.RBTIPOPROMOCION1.TabStop = true;
            this.RBTIPOPROMOCION1.Text = "Compra x cantidad y llevate mas";
            this.RBTIPOPROMOCION1.UseVisualStyleBackColor = true;
            this.RBTIPOPROMOCION1.CheckedChanged += new System.EventHandler(this.RBTIPOPROMOCION1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBRANGOGENERAL);
            this.groupBox1.Controls.Add(this.RBRANGOBODEGAZO);
            this.groupBox1.Controls.Add(this.PRODUCTOIDTextBox);
            this.groupBox1.Controls.Add(this.PRODUCTOIDButton);
            this.groupBox1.Controls.Add(this.LINEAIDButton);
            this.groupBox1.Controls.Add(this.PRODUCTOIDLabel);
            this.groupBox1.Controls.Add(this.LINEAIDLabel);
            this.groupBox1.Controls.Add(this.LINEAIDTextBox);
            this.groupBox1.Controls.Add(this.RBRANGOLINEA);
            this.groupBox1.Controls.Add(this.RBRANGOPRODUCTO);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(6, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 71);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RANGO";
            // 
            // RBRANGOGENERAL
            // 
            this.RBRANGOGENERAL.AutoSize = true;
            this.RBRANGOGENERAL.Location = new System.Drawing.Point(700, 19);
            this.RBRANGOGENERAL.Name = "RBRANGOGENERAL";
            this.RBRANGOGENERAL.Size = new System.Drawing.Size(62, 17);
            this.RBRANGOGENERAL.TabIndex = 161;
            this.RBRANGOGENERAL.TabStop = true;
            this.RBRANGOGENERAL.Text = "General";
            this.RBRANGOGENERAL.UseVisualStyleBackColor = true;
            // 
            // RBRANGOBODEGAZO
            // 
            this.RBRANGOBODEGAZO.AutoSize = true;
            this.RBRANGOBODEGAZO.Location = new System.Drawing.Point(524, 19);
            this.RBRANGOBODEGAZO.Name = "RBRANGOBODEGAZO";
            this.RBRANGOBODEGAZO.Size = new System.Drawing.Size(91, 17);
            this.RBRANGOBODEGAZO.TabIndex = 160;
            this.RBRANGOBODEGAZO.TabStop = true;
            this.RBRANGOBODEGAZO.Text = "Por bodegazo";
            this.RBRANGOBODEGAZO.UseVisualStyleBackColor = true;
            // 
            // PRODUCTOIDTextBox
            // 
            this.PRODUCTOIDTextBox.Location = new System.Drawing.Point(20, 45);
            this.PRODUCTOIDTextBox.Name = "PRODUCTOIDTextBox";
            this.PRODUCTOIDTextBox.Size = new System.Drawing.Size(83, 20);
            this.PRODUCTOIDTextBox.TabIndex = 6;
            this.PRODUCTOIDTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.TBCodigo_Validating);
            // 
            // PRODUCTOIDButton
            // 
            this.PRODUCTOIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.PRODUCTOIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PRODUCTOIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PRODUCTOIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PRODUCTOIDButton.Location = new System.Drawing.Point(106, 43);
            this.PRODUCTOIDButton.Name = "PRODUCTOIDButton";
            this.PRODUCTOIDButton.Size = new System.Drawing.Size(21, 23);
            this.PRODUCTOIDButton.TabIndex = 7;
            this.PRODUCTOIDButton.UseVisualStyleBackColor = true;
            this.PRODUCTOIDButton.Click += new System.EventHandler(this.PRODUCTOIDButton_Click);
            // 
            // LINEAIDButton
            // 
            this.LINEAIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.LINEAIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LINEAIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LINEAIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.LINEAIDButton.Location = new System.Drawing.Point(397, 41);
            this.LINEAIDButton.Name = "LINEAIDButton";
            this.LINEAIDButton.Size = new System.Drawing.Size(21, 23);
            this.LINEAIDButton.TabIndex = 10;
            this.LINEAIDButton.UseVisualStyleBackColor = true;
            // 
            // PRODUCTOIDLabel
            // 
            this.PRODUCTOIDLabel.AutoSize = true;
            this.PRODUCTOIDLabel.Location = new System.Drawing.Point(137, 51);
            this.PRODUCTOIDLabel.Name = "PRODUCTOIDLabel";
            this.PRODUCTOIDLabel.Size = new System.Drawing.Size(16, 13);
            this.PRODUCTOIDLabel.TabIndex = 159;
            this.PRODUCTOIDLabel.Text = "...";
            // 
            // LINEAIDLabel
            // 
            this.LINEAIDLabel.AutoSize = true;
            this.LINEAIDLabel.Location = new System.Drawing.Point(428, 46);
            this.LINEAIDLabel.Name = "LINEAIDLabel";
            this.LINEAIDLabel.Size = new System.Drawing.Size(16, 13);
            this.LINEAIDLabel.TabIndex = 158;
            this.LINEAIDLabel.Text = "...";
            // 
            // LINEAIDTextBox
            // 
            this.LINEAIDTextBox.BotonLookUp = this.LINEAIDButton;
            this.LINEAIDTextBox.Condicion = null;
            this.LINEAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.LINEAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.LINEAIDTextBox.DbValue = null;
            this.LINEAIDTextBox.Format_Expression = null;
            this.LINEAIDTextBox.IndiceCampoDescripcion = 2;
            this.LINEAIDTextBox.IndiceCampoSelector = 1;
            this.LINEAIDTextBox.IndiceCampoValue = 0;
            this.LINEAIDTextBox.LabelDescription = this.LINEAIDLabel;
            this.LINEAIDTextBox.Location = new System.Drawing.Point(313, 42);
            this.LINEAIDTextBox.MostrarErrores = true;
            this.LINEAIDTextBox.Name = "LINEAIDTextBox";
            this.LINEAIDTextBox.NombreCampoSelector = "clave";
            this.LINEAIDTextBox.NombreCampoValue = "id";
            this.LINEAIDTextBox.Query = "select id,clave,nombre from linea";
            this.LINEAIDTextBox.QueryDeSeleccion = "select id,clave,nombre from linea where clave = @clave";
            this.LINEAIDTextBox.QueryPorDBValue = "select id,clave,nombre from linea where id = @id";
            this.LINEAIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.LINEAIDTextBox.TabIndex = 9;
            this.LINEAIDTextBox.Tag = 34;
            this.LINEAIDTextBox.TextDescription = null;
            this.LINEAIDTextBox.Titulo = "Lineas";
            this.LINEAIDTextBox.ValidarEntrada = true;
            this.LINEAIDTextBox.ValidationExpression = null;
            // 
            // RBRANGOLINEA
            // 
            this.RBRANGOLINEA.AutoSize = true;
            this.RBRANGOLINEA.Location = new System.Drawing.Point(309, 19);
            this.RBRANGOLINEA.Name = "RBRANGOLINEA";
            this.RBRANGOLINEA.Size = new System.Drawing.Size(66, 17);
            this.RBRANGOLINEA.TabIndex = 8;
            this.RBRANGOLINEA.TabStop = true;
            this.RBRANGOLINEA.Text = "Por linea";
            this.RBRANGOLINEA.UseVisualStyleBackColor = true;
            // 
            // RBRANGOPRODUCTO
            // 
            this.RBRANGOPRODUCTO.AutoSize = true;
            this.RBRANGOPRODUCTO.Location = new System.Drawing.Point(17, 22);
            this.RBRANGOPRODUCTO.Name = "RBRANGOPRODUCTO";
            this.RBRANGOPRODUCTO.Size = new System.Drawing.Size(86, 17);
            this.RBRANGOPRODUCTO.TabIndex = 5;
            this.RBRANGOPRODUCTO.TabStop = true;
            this.RBRANGOPRODUCTO.Text = "Por producto";
            this.RBRANGOPRODUCTO.UseVisualStyleBackColor = true;
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(412, 8);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ACTIVOTextBox.TabIndex = 3;
            this.ACTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // ACTIVOLabel
            // 
            this.ACTIVOLabel.AutoSize = true;
            this.ACTIVOLabel.BackColor = System.Drawing.Color.Transparent;
            this.ACTIVOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACTIVOLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ACTIVOLabel.Location = new System.Drawing.Point(359, 8);
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
            this.NOMBRELabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NOMBRELabel.Location = new System.Drawing.Point(9, 9);
            this.NOMBRELabel.Name = "NOMBRELabel";
            this.NOMBRELabel.Size = new System.Drawing.Size(54, 13);
            this.NOMBRELabel.TabIndex = 1;
            this.NOMBRELabel.Text = "Nombre:";
            // 
            // NOMBRETextBox
            // 
            this.NOMBRETextBox.Location = new System.Drawing.Point(88, 5);
            this.NOMBRETextBox.Name = "NOMBRETextBox";
            this.NOMBRETextBox.Size = new System.Drawing.Size(204, 20);
            this.NOMBRETextBox.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(814, 494);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sucursales";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panel2.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel2.Controls.Add(this.sUCURSALDataGridView);
            this.panel2.Controls.Add(this.CBTodasSucursales);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(808, 488);
            this.panel2.TabIndex = 20;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // sUCURSALDataGridView
            // 
            this.sUCURSALDataGridView.AllowUserToAddRows = false;
            this.sUCURSALDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sUCURSALDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sUCURSALDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sUCURSALDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.DGID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.Seleccionada});
            this.sUCURSALDataGridView.DataSource = this.sUCURSALBindingSource;
            this.sUCURSALDataGridView.Location = new System.Drawing.Point(5, 48);
            this.sUCURSALDataGridView.Name = "sUCURSALDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sUCURSALDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.sUCURSALDataGridView.RowHeadersVisible = false;
            this.sUCURSALDataGridView.Size = new System.Drawing.Size(767, 392);
            this.sUCURSALDataGridView.TabIndex = 18;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn7.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ACTIVO";
            this.dataGridViewTextBoxColumn2.HeaderText = "ACTIVO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn8.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DESCRIPCION";
            this.dataGridViewTextBoxColumn9.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // Seleccionada
            // 
            this.Seleccionada.DataPropertyName = "SELECCIONADA";
            this.Seleccionada.FalseValue = "0";
            this.Seleccionada.HeaderText = "SELECCIONAR";
            this.Seleccionada.IndeterminateValue = "-1";
            this.Seleccionada.Name = "Seleccionada";
            this.Seleccionada.TrueValue = "1";
            // 
            // CBTodasSucursales
            // 
            this.CBTodasSucursales.AutoSize = true;
            this.CBTodasSucursales.BackColor = System.Drawing.Color.Transparent;
            this.CBTodasSucursales.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CBTodasSucursales.Location = new System.Drawing.Point(716, 25);
            this.CBTodasSucursales.Name = "CBTodasSucursales";
            this.CBTodasSucursales.Size = new System.Drawing.Size(56, 17);
            this.CBTodasSucursales.TabIndex = 18;
            this.CBTodasSucursales.Text = "Todas";
            this.CBTodasSucursales.UseVisualStyleBackColor = false;
            // 
            // tabImagen
            // 
            this.tabImagen.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabImagen.Controls.Add(this.btnEliminarImagen);
            this.tabImagen.Controls.Add(this.IMAGENTextBox);
            this.tabImagen.Controls.Add(this.pictureBox1);
            this.tabImagen.Controls.Add(this.label19);
            this.tabImagen.Controls.Add(this.btnImageSelector);
            this.tabImagen.Controls.Add(this.NuevaImagenTextBox);
            this.tabImagen.Location = new System.Drawing.Point(4, 22);
            this.tabImagen.Margin = new System.Windows.Forms.Padding(2);
            this.tabImagen.Name = "tabImagen";
            this.tabImagen.Padding = new System.Windows.Forms.Padding(2);
            this.tabImagen.Size = new System.Drawing.Size(814, 494);
            this.tabImagen.TabIndex = 2;
            this.tabImagen.Text = "Imagen";
            this.tabImagen.UseVisualStyleBackColor = true;
            // 
            // btnEliminarImagen
            // 
            this.btnEliminarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarImagen.ForeColor = System.Drawing.Color.White;
            this.btnEliminarImagen.Location = new System.Drawing.Point(608, 84);
            this.btnEliminarImagen.Name = "btnEliminarImagen";
            this.btnEliminarImagen.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarImagen.TabIndex = 232;
            this.btnEliminarImagen.Text = "Eliminar imagen";
            this.btnEliminarImagen.UseVisualStyleBackColor = true;
            this.btnEliminarImagen.Click += new System.EventHandler(this.btnEliminarImagen_Click);
            // 
            // IMAGENTextBox
            // 
            this.IMAGENTextBox.Enabled = false;
            this.IMAGENTextBox.Location = new System.Drawing.Point(392, 58);
            this.IMAGENTextBox.Name = "IMAGENTextBox";
            this.IMAGENTextBox.Size = new System.Drawing.Size(291, 20);
            this.IMAGENTextBox.TabIndex = 231;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(38, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 156);
            this.pictureBox1.TabIndex = 230;
            this.pictureBox1.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label19.Location = new System.Drawing.Point(36, 62);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 229;
            this.label19.Text = "Imagen:";
            // 
            // btnImageSelector
            // 
            this.btnImageSelector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImageSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImageSelector.ForeColor = System.Drawing.Color.White;
            this.btnImageSelector.Location = new System.Drawing.Point(313, 59);
            this.btnImageSelector.Name = "btnImageSelector";
            this.btnImageSelector.Size = new System.Drawing.Size(59, 23);
            this.btnImageSelector.TabIndex = 227;
            this.btnImageSelector.Text = "Explorar";
            this.btnImageSelector.UseVisualStyleBackColor = true;
            this.btnImageSelector.Click += new System.EventHandler(this.btnImageSelector_Click);
            // 
            // NuevaImagenTextBox
            // 
            this.NuevaImagenTextBox.Location = new System.Drawing.Point(87, 62);
            this.NuevaImagenTextBox.Name = "NuevaImagenTextBox";
            this.NuevaImagenTextBox.Size = new System.Drawing.Size(223, 20);
            this.NuevaImagenTextBox.TabIndex = 228;
            // 
            // BTIniciaEdicion
            // 
            this.BTIniciaEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTIniciaEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTIniciaEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIniciaEdicion.ForeColor = System.Drawing.Color.White;
            this.BTIniciaEdicion.Location = new System.Drawing.Point(179, 528);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(57, 23);
            this.BTIniciaEdicion.TabIndex = 50;
            this.BTIniciaEdicion.Text = "Editar";
            this.BTIniciaEdicion.UseVisualStyleBackColor = false;
            this.BTIniciaEdicion.Visible = false;
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
            this.button1.Location = new System.Drawing.Point(322, 523);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 32);
            this.button1.TabIndex = 48;
            this.button1.Text = "Guardar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WFPromocionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(822, 565);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.flatTabControl1);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFPromocionEdit";
            this.Text = "PROMOCION";
            this.Load += new System.EventHandler(this.LINEAEdit_Reg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).EndInit();
            this.flatTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pnlBodegazo.ResumeLayout(false);
            this.pnlBodegazo.PerformLayout();
            this.pnlPromocionXMontoMin.ResumeLayout(false);
            this.pnlPromocionXMontoMin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALDataGridView)).EndInit();
            this.tabImagen.ResumeLayout(false);
            this.tabImagen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

  }

  #endregion


        private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
        private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
  private System.Windows.Forms.Label LBError;




  private CustomValidation.RequiredFieldValidator RFV_CLAVE;
  private FlatTabControl.FlatTabControl flatTabControl1;
  private System.Windows.Forms.TabPage tabPage1;
  private System.Windows.Forms.Button BTCancelar;
  private System.Windows.Forms.Button BTIniciaEdicion;
  private System.Windows.Forms.Panel panel1;
  private System.Windows.Forms.Label CLAVELabel;
  private System.Windows.Forms.TextBox CLAVETextBox;
  private System.Windows.Forms.Label label3;
  private System.Windows.Forms.Label label2;
  private System.Windows.Forms.Label label1;
  private System.Windows.Forms.CheckBox JUEVESTextBox;
  private System.Windows.Forms.CheckBox MARTESTextBox;
  private System.Windows.Forms.CheckBox DOMINGOTextBox;
  private System.Windows.Forms.CheckBox LUNESTextBox;
  private System.Windows.Forms.CheckBox SABADOTextBox;
  private System.Windows.Forms.CheckBox MIERCOLESTextBox;
  private System.Windows.Forms.DateTimePicker FECHAFINTextBox;
  private System.Windows.Forms.CheckBox VIERNESTextBox;
  private System.Windows.Forms.DateTimePicker FECHAINICIOTextBox;
  private System.Windows.Forms.GroupBox groupBox2;
  private System.Windows.Forms.Panel pnlBodegazo;
  private System.Windows.Forms.RadioButton RBTIPOPROMOCION7;
  private System.Windows.Forms.Label label14;
  private System.Windows.Forms.NumericTextBox PORCENTAJEAUMENTOBODEGAZOTextBox;
  private System.Windows.Forms.Label label15;
  private System.Windows.Forms.CheckBox ENMONEDEROBODEGAZOTextBox;
  private System.Windows.Forms.Label label12;
  private System.Windows.Forms.Label label13;
  private System.Windows.Forms.NumericTextBox IMPORTE6TextBox;
  private System.Windows.Forms.NumericTextBox CANTIDAD6TextBox;
  private System.Windows.Forms.RadioButton RBTIPOPROMOCION6;
  private System.Windows.Forms.Panel pnlPromocionXMontoMin;
  private System.Windows.Forms.NumericTextBox MONTOMINDESCLINEATextBox;
  private System.Windows.Forms.RadioButton RBTIPOPROMOCION4;
  private System.Windows.Forms.Label label10;
  private System.Windows.Forms.NumericTextBox DESCMONTOMINTextBox;
  private System.Windows.Forms.Label label11;
  private System.Windows.Forms.Label label9;
  private System.Windows.Forms.Label label8;
  private System.Windows.Forms.Label label7;
  private System.Windows.Forms.Label label6;
  private System.Windows.Forms.Label label5;
  private System.Windows.Forms.Label label4;
  private System.Windows.Forms.CheckBox ENMONEDEROTextBox;
  private System.Windows.Forms.NumericTextBox PORCENTAJEDESCUENTOTextBox;
  private System.Windows.Forms.NumericTextBox IMPORTETextBox;
  private System.Windows.Forms.NumericTextBox CANTIDAD2TextBox;
  private System.Windows.Forms.NumericTextBox CANTIDADLLEVATETextBox;
  private System.Windows.Forms.NumericTextBox CANTIDADTextBox;
  private System.Windows.Forms.RadioButton RBTIPOPROMOCION3;
  private System.Windows.Forms.RadioButton RBTIPOPROMOCION2;
  private System.Windows.Forms.RadioButton RBTIPOPROMOCION1;
  private System.Windows.Forms.GroupBox groupBox1;
  private System.Windows.Forms.RadioButton RBRANGOBODEGAZO;
  private System.Windows.Forms.TextBox PRODUCTOIDTextBox;
  private System.Windows.Forms.Button PRODUCTOIDButton;
  private System.Windows.Forms.Button LINEAIDButton;
  private System.Windows.Forms.Label PRODUCTOIDLabel;
  private System.Windows.Forms.Label LINEAIDLabel;
  private Tools.TextBoxFB LINEAIDTextBox;
  private System.Windows.Forms.RadioButton RBRANGOLINEA;
  private System.Windows.Forms.RadioButton RBRANGOPRODUCTO;
  private System.Windows.Forms.CheckBox ACTIVOTextBox;
  private System.Windows.Forms.Label ACTIVOLabel;
  private System.Windows.Forms.Label NOMBRELabel;
  private System.Windows.Forms.TextBox NOMBRETextBox;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.TabPage tabPage2;
  private System.Windows.Forms.CheckBox CBTodasSucursales;
  private System.Windows.Forms.Panel panel2;
  private Catalogos.DSCatalogos dSCatalogos;
  private System.Windows.Forms.BindingSource sUCURSALBindingSource;
  private Catalogos.DSCatalogosTableAdapters.SUCURSALTableAdapter sUCURSALTableAdapter;
  private Catalogos.DSCatalogosTableAdapters.TableAdapterManager tableAdapterManager;
  private System.Windows.Forms.DataGridViewSum sUCURSALDataGridView;
  private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
  private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
  private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
  private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
  private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
  private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionada;
  private System.Windows.Forms.RadioButton RBTIPOPROMOCIONCUPONES;
  private System.Windows.Forms.RadioButton RBRANGOGENERAL;
  private System.Windows.Forms.Label label16;
  private System.Windows.Forms.NumericTextBox montoMinimoNumericTextBox;
  private System.Windows.Forms.Label label17;
  private System.Windows.Forms.TextBox leyendaTextBox;
  private System.Windows.Forms.GroupBox groupBox3;
  private System.Windows.Forms.RadioButton RBCADAMONTO;
  private System.Windows.Forms.RadioButton RBMONTOMINIMO;
  private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox MOSTRARDATOSCLIENTETextBox;
        private System.Windows.Forms.TabPage tabImagen;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnImageSelector;
        private System.Windows.Forms.TextBox NuevaImagenTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEliminarImagen;
        private System.Windows.Forms.TextBox IMAGENTextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox ESMULTIDETALLETextBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox DESCMULTIDETALLETextBox;
    }
}

