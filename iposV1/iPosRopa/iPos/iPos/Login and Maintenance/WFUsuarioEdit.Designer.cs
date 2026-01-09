
namespace iPos
{
    partial class WFUsuarioEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFUsuarioEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.RAV_US_USERID = new CustomValidation.RangeValidator();
            this.requiredFieldValidator1 = new CustomValidation.RequiredFieldValidator();
            this.RFV_US_PASSWORD = new CustomValidation.RequiredFieldValidator();
            this.RAV_US_LIMITE_CONEXIONES = new CustomValidation.RangeValidator();
            this.RAV_US_CONEXIONES_ABIERTAS = new CustomValidation.RangeValidator();
            this.pERFILES_ASIGNADOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSSeguridad = new iPos.Login_and_Maintenance.DSSeguridad();
            this.pERFILES_ASIGNADOSTableAdapter = new iPos.Login_and_Maintenance.DSSeguridadTableAdapters.PERFILES_ASIGNADOSTableAdapter();
            this.tableAdapterManager = new iPos.Login_and_Maintenance.DSSeguridadTableAdapters.TableAdapterManager();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pERFILES_ASIGNADOSDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dgPermitido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.CBFormasPago = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CODIGOAUTORIZACIONTextBox = new System.Windows.Forms.TextBoxET();
            this.TICKETLARGOCOTIZACIONTextBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CLERKSERVICIOSTextBox = new iPos.Tools.TextBoxFB();
            this.CLERKSERVICIOSButton = new System.Windows.Forms.Button();
            this.CLERKSERVICIOSLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CLERKIDTextBox = new iPos.Tools.TextBoxFB();
            this.CLERKIDButton = new System.Windows.Forms.Button();
            this.CLERKIDLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.EMAIL1TextBox = new System.Windows.Forms.TextBox();
            this.EMAIL1Label = new System.Windows.Forms.Label();
            this.GRUPOUSUARIOIDTextBox = new iPos.Tools.TextBoxFB();
            this.GRUPOUSUARIOIDButton = new System.Windows.Forms.Button();
            this.GRUPOUSUARIOIDLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.PENDMAXDIASTextBox = new System.Windows.Forms.NumericTextBox();
            this.VENDEDORIDTextBox = new iPos.Tools.TextBoxFB();
            this.VENDEDORButton = new System.Windows.Forms.Button();
            this.VENDEDORLabel = new System.Windows.Forms.Label();
            this.VENDEDORIDLabel = new System.Windows.Forms.Label();
            this.TICKETLARGOCREDITOTextBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CAJASBOTELLASTextBox = new System.Windows.Forms.ComboBox();
            this.label112 = new System.Windows.Forms.Label();
            this.ALMACENComboBox = new System.Windows.Forms.ComboBoxFB();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.TICKETLARGOTextBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LISTAPRECIOIDTextBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.US_GAFFETETextBox = new System.Windows.Forms.TextBoxET();
            this.BTCambiarPassword = new System.Windows.Forms.Button();
            this.US_NOMBRELabel = new System.Windows.Forms.Label();
            this.US_NOMBRETextBox = new System.Windows.Forms.TextBoxET();
            this.US_VIGENCIALabel = new System.Windows.Forms.Label();
            this.US_VIGENCIATextBox = new System.Windows.Forms.DateTimePickerE();
            this.LableUsuario = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.US_USERNAMETextBox = new System.Windows.Forms.TextBoxET();
            this.RFV_US_USUARIO = new CustomValidation.RequiredFieldValidator();
            this.btnSelectPrinterName = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.NOMBREIMPRESORATextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pERFILES_ASIGNADOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSSeguridad)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pERFILES_ASIGNADOSDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            // RAV_US_LIMITE_CONEXIONES
            // 
            this.RAV_US_LIMITE_CONEXIONES.Enabled = true;
            this.RAV_US_LIMITE_CONEXIONES.ErrorMessage = "Error el campo US_LIMITE_CONEXIONES no esta dentro del rango";
            this.RAV_US_LIMITE_CONEXIONES.Icon = ((System.Drawing.Icon)(resources.GetObject("RAV_US_LIMITE_CONEXIONES.Icon")));
            this.RAV_US_LIMITE_CONEXIONES.MaximumValue = "999999999999";
            this.RAV_US_LIMITE_CONEXIONES.MinimumValue = "0";
            this.RAV_US_LIMITE_CONEXIONES.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_US_CONEXIONES_ABIERTAS
            // 
            this.RAV_US_CONEXIONES_ABIERTAS.Enabled = true;
            this.RAV_US_CONEXIONES_ABIERTAS.ErrorMessage = "Error el campo US_CONEXIONES_ABIERTAS no esta dentro del rango";
            this.RAV_US_CONEXIONES_ABIERTAS.Icon = ((System.Drawing.Icon)(resources.GetObject("RAV_US_CONEXIONES_ABIERTAS.Icon")));
            this.RAV_US_CONEXIONES_ABIERTAS.MaximumValue = "999999999999";
            this.RAV_US_CONEXIONES_ABIERTAS.MinimumValue = "0";
            this.RAV_US_CONEXIONES_ABIERTAS.Type = CustomValidation.ValidationDataType.Double;
            // 
            // pERFILES_ASIGNADOSBindingSource
            // 
            this.pERFILES_ASIGNADOSBindingSource.DataMember = "PERFILES_ASIGNADOS";
            this.pERFILES_ASIGNADOSBindingSource.DataSource = this.dSSeguridad;
            // 
            // dSSeguridad
            // 
            this.dSSeguridad.DataSetName = "DSSeguridad";
            this.dSSeguridad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pERFILES_ASIGNADOSTableAdapter
            // 
            this.pERFILES_ASIGNADOSTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.PERFILES_DERECHOSTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Login_and_Maintenance.DSSeguridadTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
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
            this.BTCancelar.Location = new System.Drawing.Point(480, 719);
            this.BTCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(155, 37);
            this.BTCancelar.TabIndex = 11;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pERFILES_ASIGNADOSDataGridView);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(16, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 665);
            this.panel1.TabIndex = 2;
            // 
            // pERFILES_ASIGNADOSDataGridView
            // 
            this.pERFILES_ASIGNADOSDataGridView.AutoGenerateColumns = false;
            this.pERFILES_ASIGNADOSDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pERFILES_ASIGNADOSDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pERFILES_ASIGNADOSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pERFILES_ASIGNADOSDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgPermitido,
            this.dataGridViewTextBoxColumn2,
            this.dgPerfil});
            this.pERFILES_ASIGNADOSDataGridView.DataSource = this.pERFILES_ASIGNADOSBindingSource;
            this.pERFILES_ASIGNADOSDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pERFILES_ASIGNADOSDataGridView.EnableHeadersVisualStyles = false;
            this.pERFILES_ASIGNADOSDataGridView.Location = new System.Drawing.Point(0, 430);
            this.pERFILES_ASIGNADOSDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pERFILES_ASIGNADOSDataGridView.Name = "pERFILES_ASIGNADOSDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pERFILES_ASIGNADOSDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.pERFILES_ASIGNADOSDataGridView.RowHeadersVisible = false;
            this.pERFILES_ASIGNADOSDataGridView.Size = new System.Drawing.Size(901, 235);
            this.pERFILES_ASIGNADOSDataGridView.TabIndex = 10;
            // 
            // dgPermitido
            // 
            this.dgPermitido.DataPropertyName = "PERMITIDO";
            this.dgPermitido.FalseValue = "0";
            this.dgPermitido.HeaderText = "";
            this.dgPermitido.Name = "dgPermitido";
            this.dgPermitido.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPermitido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgPermitido.TrueValue = "1";
            this.dgPermitido.Width = 95;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PF_DESCRIPCION";
            this.dataGridViewTextBoxColumn2.HeaderText = "PERFIL";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 214;
            // 
            // dgPerfil
            // 
            this.dgPerfil.DataPropertyName = "PF_PERFIL";
            this.dgPerfil.HeaderText = "PF_PERFIL";
            this.dgPerfil.Name = "dgPerfil";
            this.dgPerfil.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnSelectPrinterName);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.NOMBREIMPRESORATextBox);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.CBFormasPago);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.CODIGOAUTORIZACIONTextBox);
            this.panel2.Controls.Add(this.TICKETLARGOCOTIZACIONTextBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.CLERKSERVICIOSTextBox);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.CLERKSERVICIOSButton);
            this.panel2.Controls.Add(this.CLERKSERVICIOSLabel);
            this.panel2.Controls.Add(this.CLERKIDTextBox);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.CLERKIDButton);
            this.panel2.Controls.Add(this.CLERKIDLabel);
            this.panel2.Controls.Add(this.EMAIL1TextBox);
            this.panel2.Controls.Add(this.EMAIL1Label);
            this.panel2.Controls.Add(this.GRUPOUSUARIOIDTextBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.GRUPOUSUARIOIDButton);
            this.panel2.Controls.Add(this.GRUPOUSUARIOIDLabel);
            this.panel2.Controls.Add(this.label140);
            this.panel2.Controls.Add(this.PENDMAXDIASTextBox);
            this.panel2.Controls.Add(this.VENDEDORIDTextBox);
            this.panel2.Controls.Add(this.VENDEDORIDLabel);
            this.panel2.Controls.Add(this.VENDEDORButton);
            this.panel2.Controls.Add(this.VENDEDORLabel);
            this.panel2.Controls.Add(this.TICKETLARGOCREDITOTextBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.CAJASBOTELLASTextBox);
            this.panel2.Controls.Add(this.label112);
            this.panel2.Controls.Add(this.ALMACENComboBox);
            this.panel2.Controls.Add(this.lblAlmacen);
            this.panel2.Controls.Add(this.TICKETLARGOTextBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.LISTAPRECIOIDTextBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.US_GAFFETETextBox);
            this.panel2.Controls.Add(this.BTCambiarPassword);
            this.panel2.Controls.Add(this.US_NOMBRELabel);
            this.panel2.Controls.Add(this.US_NOMBRETextBox);
            this.panel2.Controls.Add(this.US_VIGENCIALabel);
            this.panel2.Controls.Add(this.US_VIGENCIATextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(901, 430);
            this.panel2.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(580, 170);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 34);
            this.label10.TabIndex = 202;
            this.label10.Text = "Formas pago def.\r\nclientes creados:";
            // 
            // CBFormasPago
            // 
            this.CBFormasPago.FormattingEnabled = true;
            this.CBFormasPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta",
            "Cheque",
            "Transferencia",
            "Credito"});
            this.CBFormasPago.Location = new System.Drawing.Point(737, 165);
            this.CBFormasPago.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBFormasPago.Name = "CBFormasPago";
            this.CBFormasPago.Size = new System.Drawing.Size(159, 40);
            this.CBFormasPago.TabIndex = 201;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(412, 71);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 200;
            this.label9.Text = "Cod. Aut. :";
            // 
            // CODIGOAUTORIZACIONTextBox
            // 
            this.CODIGOAUTORIZACIONTextBox.Format_Expression = null;
            this.CODIGOAUTORIZACIONTextBox.Location = new System.Drawing.Point(512, 66);
            this.CODIGOAUTORIZACIONTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CODIGOAUTORIZACIONTextBox.Name = "CODIGOAUTORIZACIONTextBox";
            this.CODIGOAUTORIZACIONTextBox.PasswordChar = '*';
            this.CODIGOAUTORIZACIONTextBox.Size = new System.Drawing.Size(265, 23);
            this.CODIGOAUTORIZACIONTextBox.TabIndex = 199;
            this.CODIGOAUTORIZACIONTextBox.Tag = 34;
            this.CODIGOAUTORIZACIONTextBox.ValidationExpression = null;
            // 
            // TICKETLARGOCOTIZACIONTextBox
            // 
            this.TICKETLARGOCOTIZACIONTextBox.AutoSize = true;
            this.TICKETLARGOCOTIZACIONTextBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TICKETLARGOCOTIZACIONTextBox.Location = new System.Drawing.Point(759, 140);
            this.TICKETLARGOCOTIZACIONTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TICKETLARGOCOTIZACIONTextBox.Name = "TICKETLARGOCOTIZACIONTextBox";
            this.TICKETLARGOCOTIZACIONTextBox.Size = new System.Drawing.Size(18, 17);
            this.TICKETLARGOCOTIZACIONTextBox.TabIndex = 198;
            this.TICKETLARGOCOTIZACIONTextBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(567, 140);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 17);
            this.label5.TabIndex = 197;
            this.label5.Text = "Ticket largo cotiz:";
            // 
            // CLERKSERVICIOSTextBox
            // 
            this.CLERKSERVICIOSTextBox.AccessibleDescription = "";
            this.CLERKSERVICIOSTextBox.BotonLookUp = this.CLERKSERVICIOSButton;
            this.CLERKSERVICIOSTextBox.Condicion = null;
            this.CLERKSERVICIOSTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CLERKSERVICIOSTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CLERKSERVICIOSTextBox.DbValue = null;
            this.CLERKSERVICIOSTextBox.Format_Expression = null;
            this.CLERKSERVICIOSTextBox.IndiceCampoDescripcion = 2;
            this.CLERKSERVICIOSTextBox.IndiceCampoSelector = 1;
            this.CLERKSERVICIOSTextBox.IndiceCampoValue = 0;
            this.CLERKSERVICIOSTextBox.LabelDescription = this.CLERKSERVICIOSLabel;
            this.CLERKSERVICIOSTextBox.Location = new System.Drawing.Point(133, 356);
            this.CLERKSERVICIOSTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CLERKSERVICIOSTextBox.MostrarErrores = true;
            this.CLERKSERVICIOSTextBox.Name = "CLERKSERVICIOSTextBox";
            this.CLERKSERVICIOSTextBox.NombreCampoSelector = "clerkid";
            this.CLERKSERVICIOSTextBox.NombreCampoValue = "id";
            this.CLERKSERVICIOSTextBox.Query = "select id,clerkid,clerkid as clerkid2 from CLERKPAGOSERVICIO where  esservicio = " +
    "\'S\'";
            this.CLERKSERVICIOSTextBox.QueryDeSeleccion = "select id,clerkid,clerkid as clerkid2 from CLERKPAGOSERVICIO where  clerkid= @cle" +
    "rkid and esservicio = \'S\'";
            this.CLERKSERVICIOSTextBox.QueryPorDBValue = "select id,clerkid,clerkid as clerkid2 from CLERKPAGOSERVICIO where   id = @id and" +
    " esservicio = \'S\'";
            this.CLERKSERVICIOSTextBox.Size = new System.Drawing.Size(133, 23);
            this.CLERKSERVICIOSTextBox.TabIndex = 194;
            this.CLERKSERVICIOSTextBox.Tag = 34;
            this.CLERKSERVICIOSTextBox.TextDescription = null;
            this.CLERKSERVICIOSTextBox.Titulo = "CLERKS SERVICIOS";
            this.CLERKSERVICIOSTextBox.ValidarEntrada = true;
            this.CLERKSERVICIOSTextBox.ValidationExpression = null;
            // 
            // CLERKSERVICIOSButton
            // 
            this.CLERKSERVICIOSButton.AccessibleDescription = "";
            this.CLERKSERVICIOSButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CLERKSERVICIOSButton.BackgroundImage")));
            this.CLERKSERVICIOSButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CLERKSERVICIOSButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLERKSERVICIOSButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.CLERKSERVICIOSButton.Location = new System.Drawing.Point(277, 356);
            this.CLERKSERVICIOSButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CLERKSERVICIOSButton.Name = "CLERKSERVICIOSButton";
            this.CLERKSERVICIOSButton.Size = new System.Drawing.Size(32, 28);
            this.CLERKSERVICIOSButton.TabIndex = 195;
            this.CLERKSERVICIOSButton.UseVisualStyleBackColor = true;
            // 
            // CLERKSERVICIOSLabel
            // 
            this.CLERKSERVICIOSLabel.AccessibleDescription = "";
            this.CLERKSERVICIOSLabel.AutoSize = true;
            this.CLERKSERVICIOSLabel.ForeColor = System.Drawing.Color.White;
            this.CLERKSERVICIOSLabel.Location = new System.Drawing.Point(317, 362);
            this.CLERKSERVICIOSLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CLERKSERVICIOSLabel.Name = "CLERKSERVICIOSLabel";
            this.CLERKSERVICIOSLabel.Size = new System.Drawing.Size(23, 17);
            this.CLERKSERVICIOSLabel.TabIndex = 196;
            this.CLERKSERVICIOSLabel.Text = "...";
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "";
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(9, 361);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 17);
            this.label8.TabIndex = 193;
            this.label8.Text = "Clerk serv. :";
            // 
            // CLERKIDTextBox
            // 
            this.CLERKIDTextBox.AccessibleDescription = "";
            this.CLERKIDTextBox.BotonLookUp = this.CLERKIDButton;
            this.CLERKIDTextBox.Condicion = null;
            this.CLERKIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CLERKIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CLERKIDTextBox.DbValue = null;
            this.CLERKIDTextBox.Format_Expression = null;
            this.CLERKIDTextBox.IndiceCampoDescripcion = 2;
            this.CLERKIDTextBox.IndiceCampoSelector = 1;
            this.CLERKIDTextBox.IndiceCampoValue = 0;
            this.CLERKIDTextBox.LabelDescription = this.CLERKIDLabel;
            this.CLERKIDTextBox.Location = new System.Drawing.Point(135, 319);
            this.CLERKIDTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CLERKIDTextBox.MostrarErrores = true;
            this.CLERKIDTextBox.Name = "CLERKIDTextBox";
            this.CLERKIDTextBox.NombreCampoSelector = "clerkid";
            this.CLERKIDTextBox.NombreCampoValue = "id";
            this.CLERKIDTextBox.Query = "select id,clerkid,clerkid as clerkid2 from CLERKPAGOSERVICIO where (esservicio <>" +
    " \'S\' or esservicio is null)";
            this.CLERKIDTextBox.QueryDeSeleccion = "select id,clerkid,clerkid as clerkid2 from CLERKPAGOSERVICIO where  clerkid= @cle" +
    "rkid  and (esservicio <> \'S\' or esservicio is null)";
            this.CLERKIDTextBox.QueryPorDBValue = "select id,clerkid,clerkid as clerkid2 from CLERKPAGOSERVICIO where   id = @id  an" +
    "d (esservicio <> \'S\' or esservicio is null)";
            this.CLERKIDTextBox.Size = new System.Drawing.Size(133, 23);
            this.CLERKIDTextBox.TabIndex = 190;
            this.CLERKIDTextBox.Tag = 34;
            this.CLERKIDTextBox.TextDescription = null;
            this.CLERKIDTextBox.Titulo = "CLERKS";
            this.CLERKIDTextBox.ValidarEntrada = true;
            this.CLERKIDTextBox.ValidationExpression = null;
            // 
            // CLERKIDButton
            // 
            this.CLERKIDButton.AccessibleDescription = "";
            this.CLERKIDButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CLERKIDButton.BackgroundImage")));
            this.CLERKIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CLERKIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLERKIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.CLERKIDButton.Location = new System.Drawing.Point(279, 319);
            this.CLERKIDButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CLERKIDButton.Name = "CLERKIDButton";
            this.CLERKIDButton.Size = new System.Drawing.Size(32, 28);
            this.CLERKIDButton.TabIndex = 191;
            this.CLERKIDButton.UseVisualStyleBackColor = true;
            // 
            // CLERKIDLabel
            // 
            this.CLERKIDLabel.AccessibleDescription = "";
            this.CLERKIDLabel.AutoSize = true;
            this.CLERKIDLabel.ForeColor = System.Drawing.Color.White;
            this.CLERKIDLabel.Location = new System.Drawing.Point(317, 322);
            this.CLERKIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CLERKIDLabel.Name = "CLERKIDLabel";
            this.CLERKIDLabel.Size = new System.Drawing.Size(23, 17);
            this.CLERKIDLabel.TabIndex = 192;
            this.CLERKIDLabel.Text = "...";
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "";
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 322);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 17);
            this.label7.TabIndex = 189;
            this.label7.Text = "Clerk ID:";
            // 
            // EMAIL1TextBox
            // 
            this.EMAIL1TextBox.Location = new System.Drawing.Point(135, 284);
            this.EMAIL1TextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EMAIL1TextBox.Name = "EMAIL1TextBox";
            this.EMAIL1TextBox.Size = new System.Drawing.Size(302, 23);
            this.EMAIL1TextBox.TabIndex = 188;
            // 
            // EMAIL1Label
            // 
            this.EMAIL1Label.AutoSize = true;
            this.EMAIL1Label.ForeColor = System.Drawing.Color.White;
            this.EMAIL1Label.Location = new System.Drawing.Point(11, 288);
            this.EMAIL1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EMAIL1Label.Name = "EMAIL1Label";
            this.EMAIL1Label.Size = new System.Drawing.Size(72, 17);
            this.EMAIL1Label.TabIndex = 187;
            this.EMAIL1Label.Text = "E-mail 1:";
            // 
            // GRUPOUSUARIOIDTextBox
            // 
            this.GRUPOUSUARIOIDTextBox.AccessibleDescription = "";
            this.GRUPOUSUARIOIDTextBox.BotonLookUp = this.GRUPOUSUARIOIDButton;
            this.GRUPOUSUARIOIDTextBox.Condicion = null;
            this.GRUPOUSUARIOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GRUPOUSUARIOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GRUPOUSUARIOIDTextBox.DbValue = null;
            this.GRUPOUSUARIOIDTextBox.Format_Expression = null;
            this.GRUPOUSUARIOIDTextBox.IndiceCampoDescripcion = 2;
            this.GRUPOUSUARIOIDTextBox.IndiceCampoSelector = 1;
            this.GRUPOUSUARIOIDTextBox.IndiceCampoValue = 0;
            this.GRUPOUSUARIOIDTextBox.LabelDescription = this.GRUPOUSUARIOIDLabel;
            this.GRUPOUSUARIOIDTextBox.Location = new System.Drawing.Point(135, 249);
            this.GRUPOUSUARIOIDTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GRUPOUSUARIOIDTextBox.MostrarErrores = true;
            this.GRUPOUSUARIOIDTextBox.Name = "GRUPOUSUARIOIDTextBox";
            this.GRUPOUSUARIOIDTextBox.NombreCampoSelector = "clave";
            this.GRUPOUSUARIOIDTextBox.NombreCampoValue = "id";
            this.GRUPOUSUARIOIDTextBox.Query = "select id,clave,nombre from grupousuario";
            this.GRUPOUSUARIOIDTextBox.QueryDeSeleccion = "select id,clave,nombre from grupousuario where  clave= @clave";
            this.GRUPOUSUARIOIDTextBox.QueryPorDBValue = "select id,clave,nombre from grupousuario where   id = @id";
            this.GRUPOUSUARIOIDTextBox.Size = new System.Drawing.Size(155, 23);
            this.GRUPOUSUARIOIDTextBox.TabIndex = 184;
            this.GRUPOUSUARIOIDTextBox.Tag = 34;
            this.GRUPOUSUARIOIDTextBox.TextDescription = null;
            this.GRUPOUSUARIOIDTextBox.Titulo = "Grupos de usuario";
            this.GRUPOUSUARIOIDTextBox.ValidarEntrada = true;
            this.GRUPOUSUARIOIDTextBox.ValidationExpression = null;
            // 
            // GRUPOUSUARIOIDButton
            // 
            this.GRUPOUSUARIOIDButton.AccessibleDescription = "";
            this.GRUPOUSUARIOIDButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GRUPOUSUARIOIDButton.BackgroundImage")));
            this.GRUPOUSUARIOIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GRUPOUSUARIOIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GRUPOUSUARIOIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.GRUPOUSUARIOIDButton.Location = new System.Drawing.Point(296, 249);
            this.GRUPOUSUARIOIDButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GRUPOUSUARIOIDButton.Name = "GRUPOUSUARIOIDButton";
            this.GRUPOUSUARIOIDButton.Size = new System.Drawing.Size(32, 28);
            this.GRUPOUSUARIOIDButton.TabIndex = 185;
            this.GRUPOUSUARIOIDButton.UseVisualStyleBackColor = true;
            // 
            // GRUPOUSUARIOIDLabel
            // 
            this.GRUPOUSUARIOIDLabel.AccessibleDescription = "";
            this.GRUPOUSUARIOIDLabel.AutoSize = true;
            this.GRUPOUSUARIOIDLabel.ForeColor = System.Drawing.Color.White;
            this.GRUPOUSUARIOIDLabel.Location = new System.Drawing.Point(336, 252);
            this.GRUPOUSUARIOIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GRUPOUSUARIOIDLabel.Name = "GRUPOUSUARIOIDLabel";
            this.GRUPOUSUARIOIDLabel.Size = new System.Drawing.Size(23, 17);
            this.GRUPOUSUARIOIDLabel.TabIndex = 186;
            this.GRUPOUSUARIOIDLabel.Text = "...";
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "";
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(11, 252);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 183;
            this.label6.Text = "Grupo:";
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.ForeColor = System.Drawing.Color.White;
            this.label140.Location = new System.Drawing.Point(412, 107);
            this.label140.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(206, 17);
            this.label140.TabIndex = 182;
            this.label140.Text = "Dias de ventas pendientes:";
            // 
            // PENDMAXDIASTextBox
            // 
            this.PENDMAXDIASTextBox.AllowNegative = false;
            this.PENDMAXDIASTextBox.Format_Expression = null;
            this.PENDMAXDIASTextBox.Location = new System.Drawing.Point(745, 103);
            this.PENDMAXDIASTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PENDMAXDIASTextBox.Name = "PENDMAXDIASTextBox";
            this.PENDMAXDIASTextBox.NumericPrecision = 3;
            this.PENDMAXDIASTextBox.NumericScaleOnFocus = 0;
            this.PENDMAXDIASTextBox.NumericScaleOnLostFocus = 0;
            this.PENDMAXDIASTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PENDMAXDIASTextBox.Size = new System.Drawing.Size(32, 23);
            this.PENDMAXDIASTextBox.TabIndex = 181;
            this.PENDMAXDIASTextBox.Tag = 34;
            this.PENDMAXDIASTextBox.Text = "0";
            this.PENDMAXDIASTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PENDMAXDIASTextBox.ValidationExpression = null;
            this.PENDMAXDIASTextBox.ZeroIsValid = true;
            // 
            // VENDEDORIDTextBox
            // 
            this.VENDEDORIDTextBox.AccessibleDescription = "";
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
            this.VENDEDORIDTextBox.Location = new System.Drawing.Point(135, 210);
            this.VENDEDORIDTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VENDEDORIDTextBox.MostrarErrores = true;
            this.VENDEDORIDTextBox.Name = "VENDEDORIDTextBox";
            this.VENDEDORIDTextBox.NombreCampoSelector = "clave";
            this.VENDEDORIDTextBox.NombreCampoValue = "id";
            this.VENDEDORIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 22";
            this.VENDEDORIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 22 and  clave= @clave";
            this.VENDEDORIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 22 and  id = @id";
            this.VENDEDORIDTextBox.Size = new System.Drawing.Size(155, 23);
            this.VENDEDORIDTextBox.TabIndex = 178;
            this.VENDEDORIDTextBox.Tag = 34;
            this.VENDEDORIDTextBox.TextDescription = null;
            this.VENDEDORIDTextBox.Titulo = "Vendedores";
            this.VENDEDORIDTextBox.ValidarEntrada = true;
            this.VENDEDORIDTextBox.ValidationExpression = null;
            // 
            // VENDEDORButton
            // 
            this.VENDEDORButton.AccessibleDescription = "";
            this.VENDEDORButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("VENDEDORButton.BackgroundImage")));
            this.VENDEDORButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VENDEDORButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VENDEDORButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.VENDEDORButton.Location = new System.Drawing.Point(296, 210);
            this.VENDEDORButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VENDEDORButton.Name = "VENDEDORButton";
            this.VENDEDORButton.Size = new System.Drawing.Size(32, 28);
            this.VENDEDORButton.TabIndex = 179;
            this.VENDEDORButton.UseVisualStyleBackColor = true;
            // 
            // VENDEDORLabel
            // 
            this.VENDEDORLabel.AccessibleDescription = "";
            this.VENDEDORLabel.AutoSize = true;
            this.VENDEDORLabel.ForeColor = System.Drawing.Color.White;
            this.VENDEDORLabel.Location = new System.Drawing.Point(336, 214);
            this.VENDEDORLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VENDEDORLabel.Name = "VENDEDORLabel";
            this.VENDEDORLabel.Size = new System.Drawing.Size(23, 17);
            this.VENDEDORLabel.TabIndex = 180;
            this.VENDEDORLabel.Text = "...";
            // 
            // VENDEDORIDLabel
            // 
            this.VENDEDORIDLabel.AccessibleDescription = "";
            this.VENDEDORIDLabel.AutoSize = true;
            this.VENDEDORIDLabel.ForeColor = System.Drawing.Color.White;
            this.VENDEDORIDLabel.Location = new System.Drawing.Point(11, 214);
            this.VENDEDORIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VENDEDORIDLabel.Name = "VENDEDORIDLabel";
            this.VENDEDORIDLabel.Size = new System.Drawing.Size(83, 17);
            this.VENDEDORIDLabel.TabIndex = 177;
            this.VENDEDORIDLabel.Text = "Vendedor:";
            // 
            // TICKETLARGOCREDITOTextBox
            // 
            this.TICKETLARGOCREDITOTextBox.AutoSize = true;
            this.TICKETLARGOCREDITOTextBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TICKETLARGOCREDITOTextBox.Location = new System.Drawing.Point(512, 140);
            this.TICKETLARGOCREDITOTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TICKETLARGOCREDITOTextBox.Name = "TICKETLARGOCREDITOTextBox";
            this.TICKETLARGOCREDITOTextBox.Size = new System.Drawing.Size(18, 17);
            this.TICKETLARGOCREDITOTextBox.TabIndex = 176;
            this.TICKETLARGOCREDITOTextBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(341, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 17);
            this.label4.TabIndex = 175;
            this.label4.Text = "Ticket largo credito:";
            // 
            // CAJASBOTELLASTextBox
            // 
            this.CAJASBOTELLASTextBox.FormattingEnabled = true;
            this.CAJASBOTELLASTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.CAJASBOTELLASTextBox.Location = new System.Drawing.Point(483, 170);
            this.CAJASBOTELLASTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CAJASBOTELLASTextBox.Name = "CAJASBOTELLASTextBox";
            this.CAJASBOTELLASTextBox.Size = new System.Drawing.Size(81, 25);
            this.CAJASBOTELLASTextBox.TabIndex = 173;
            this.CAJASBOTELLASTextBox.Tag = "";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.ForeColor = System.Drawing.Color.White;
            this.label112.Location = new System.Drawing.Point(341, 174);
            this.label112.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(125, 17);
            this.label112.TabIndex = 174;
            this.label112.Text = "Cajas / botellas:";
            // 
            // ALMACENComboBox
            // 
            this.ALMACENComboBox.Condicion = null;
            this.ALMACENComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENComboBox.DisplayMember = "nombre";
            this.ALMACENComboBox.FormattingEnabled = true;
            this.ALMACENComboBox.IndiceCampoSelector = 0;
            this.ALMACENComboBox.LabelDescription = null;
            this.ALMACENComboBox.Location = new System.Drawing.Point(135, 170);
            this.ALMACENComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ALMACENComboBox.Name = "ALMACENComboBox";
            this.ALMACENComboBox.NombreCampoSelector = "id";
            this.ALMACENComboBox.Query = "select id,nombre from almacen";
            this.ALMACENComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENComboBox.SelectedDataDisplaying = null;
            this.ALMACENComboBox.SelectedDataValue = null;
            this.ALMACENComboBox.Size = new System.Drawing.Size(156, 25);
            this.ALMACENComboBox.TabIndex = 172;
            this.ALMACENComboBox.ValueMember = "id";
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.lblAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacen.ForeColor = System.Drawing.Color.White;
            this.lblAlmacen.Location = new System.Drawing.Point(11, 174);
            this.lblAlmacen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(74, 17);
            this.lblAlmacen.TabIndex = 171;
            this.lblAlmacen.Text = "Almacen:";
            // 
            // TICKETLARGOTextBox
            // 
            this.TICKETLARGOTextBox.AutoSize = true;
            this.TICKETLARGOTextBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TICKETLARGOTextBox.Location = new System.Drawing.Point(229, 139);
            this.TICKETLARGOTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TICKETLARGOTextBox.Name = "TICKETLARGOTextBox";
            this.TICKETLARGOTextBox.Size = new System.Drawing.Size(18, 17);
            this.TICKETLARGOTextBox.TabIndex = 86;
            this.TICKETLARGOTextBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(11, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 17);
            this.label3.TabIndex = 85;
            this.label3.Text = "Ticket largo contado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Lista precio maxima:";
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
            this.LISTAPRECIOIDTextBox.Location = new System.Drawing.Point(207, 100);
            this.LISTAPRECIOIDTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LISTAPRECIOIDTextBox.Name = "LISTAPRECIOIDTextBox";
            this.LISTAPRECIOIDTextBox.Size = new System.Drawing.Size(76, 25);
            this.LISTAPRECIOIDTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Gaffete:";
            // 
            // US_GAFFETETextBox
            // 
            this.US_GAFFETETextBox.Format_Expression = null;
            this.US_GAFFETETextBox.Location = new System.Drawing.Point(135, 68);
            this.US_GAFFETETextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.US_GAFFETETextBox.Name = "US_GAFFETETextBox";
            this.US_GAFFETETextBox.Size = new System.Drawing.Size(265, 23);
            this.US_GAFFETETextBox.TabIndex = 6;
            this.US_GAFFETETextBox.Tag = 34;
            this.US_GAFFETETextBox.ValidationExpression = null;
            // 
            // BTCambiarPassword
            // 
            this.BTCambiarPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCambiarPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCambiarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCambiarPassword.ForeColor = System.Drawing.Color.White;
            this.BTCambiarPassword.Location = new System.Drawing.Point(133, 391);
            this.BTCambiarPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTCambiarPassword.Name = "BTCambiarPassword";
            this.BTCambiarPassword.Size = new System.Drawing.Size(236, 31);
            this.BTCambiarPassword.TabIndex = 9;
            this.BTCambiarPassword.Text = "Cambiar password";
            this.BTCambiarPassword.UseVisualStyleBackColor = false;
            this.BTCambiarPassword.Visible = false;
            this.BTCambiarPassword.Click += new System.EventHandler(this.BTCambiarPassword_Click);
            // 
            // US_NOMBRELabel
            // 
            this.US_NOMBRELabel.AutoSize = true;
            this.US_NOMBRELabel.ForeColor = System.Drawing.Color.White;
            this.US_NOMBRELabel.Location = new System.Drawing.Point(9, 7);
            this.US_NOMBRELabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.US_NOMBRELabel.Name = "US_NOMBRELabel";
            this.US_NOMBRELabel.Size = new System.Drawing.Size(69, 17);
            this.US_NOMBRELabel.TabIndex = 1;
            this.US_NOMBRELabel.Text = "Nombre:";
            // 
            // US_NOMBRETextBox
            // 
            this.US_NOMBRETextBox.Format_Expression = null;
            this.US_NOMBRETextBox.Location = new System.Drawing.Point(135, 4);
            this.US_NOMBRETextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.US_NOMBRETextBox.Name = "US_NOMBRETextBox";
            this.US_NOMBRETextBox.Size = new System.Drawing.Size(265, 23);
            this.US_NOMBRETextBox.TabIndex = 4;
            this.US_NOMBRETextBox.Tag = 34;
            this.US_NOMBRETextBox.ValidationExpression = null;
            // 
            // US_VIGENCIALabel
            // 
            this.US_VIGENCIALabel.AutoSize = true;
            this.US_VIGENCIALabel.ForeColor = System.Drawing.Color.White;
            this.US_VIGENCIALabel.Location = new System.Drawing.Point(11, 44);
            this.US_VIGENCIALabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.US_VIGENCIALabel.Name = "US_VIGENCIALabel";
            this.US_VIGENCIALabel.Size = new System.Drawing.Size(75, 17);
            this.US_VIGENCIALabel.TabIndex = 1;
            this.US_VIGENCIALabel.Text = "Vigencia:";
            // 
            // US_VIGENCIATextBox
            // 
            this.US_VIGENCIATextBox.Location = new System.Drawing.Point(135, 36);
            this.US_VIGENCIATextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.US_VIGENCIATextBox.Name = "US_VIGENCIATextBox";
            this.US_VIGENCIATextBox.Size = new System.Drawing.Size(265, 23);
            this.US_VIGENCIATextBox.TabIndex = 5;
            // 
            // LableUsuario
            // 
            this.LableUsuario.AutoSize = true;
            this.LableUsuario.BackColor = System.Drawing.Color.Transparent;
            this.LableUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableUsuario.ForeColor = System.Drawing.Color.White;
            this.LableUsuario.Location = new System.Drawing.Point(27, 17);
            this.LableUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LableUsuario.Name = "LableUsuario";
            this.LableUsuario.Size = new System.Drawing.Size(69, 17);
            this.LableUsuario.TabIndex = 6;
            this.LableUsuario.Text = "Usuario:";
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
            this.button1.Location = new System.Drawing.Point(189, 719);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 37);
            this.button1.TabIndex = 10;
            this.button1.Text = "Guardar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PF_DESCRIPCION";
            this.dataGridViewTextBoxColumn1.HeaderText = "PERFIL";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 214;
            // 
            // US_USERNAMETextBox
            // 
            this.US_USERNAMETextBox.Format_Expression = null;
            this.US_USERNAMETextBox.Location = new System.Drawing.Point(151, 14);
            this.US_USERNAMETextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.US_USERNAMETextBox.Name = "US_USERNAMETextBox";
            this.US_USERNAMETextBox.Size = new System.Drawing.Size(265, 22);
            this.US_USERNAMETextBox.TabIndex = 1;
            this.US_USERNAMETextBox.Tag = 34;
            this.US_USERNAMETextBox.ValidationExpression = null;
            // 
            // RFV_US_USUARIO
            // 
            this.RFV_US_USUARIO.ControlToValidate = this.US_USERNAMETextBox;
            this.RFV_US_USUARIO.Enabled = true;
            this.RFV_US_USUARIO.ErrorMessage = "Se requiere el campo US_USUARIO";
            this.RFV_US_USUARIO.Icon = ((System.Drawing.Icon)(resources.GetObject("RFV_US_USUARIO.Icon")));
            // 
            // btnSelectPrinterName
            // 
            this.btnSelectPrinterName.ForeColor = System.Drawing.Color.Black;
            this.btnSelectPrinterName.Location = new System.Drawing.Point(860, 274);
            this.btnSelectPrinterName.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectPrinterName.Name = "btnSelectPrinterName";
            this.btnSelectPrinterName.Size = new System.Drawing.Size(37, 30);
            this.btnSelectPrinterName.TabIndex = 204;
            this.btnSelectPrinterName.Text = "...";
            this.btnSelectPrinterName.UseVisualStyleBackColor = true;
            this.btnSelectPrinterName.Click += new System.EventHandler(this.btnSelectPrinterName_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label11.Location = new System.Drawing.Point(484, 284);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 17);
            this.label11.TabIndex = 205;
            this.label11.Text = "Impresora";
            // 
            // NOMBREIMPRESORATextBox
            // 
            this.NOMBREIMPRESORATextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.NOMBREIMPRESORATextBox.Location = new System.Drawing.Point(572, 281);
            this.NOMBREIMPRESORATextBox.Margin = new System.Windows.Forms.Padding(4);
            this.NOMBREIMPRESORATextBox.Name = "NOMBREIMPRESORATextBox";
            this.NOMBREIMPRESORATextBox.Size = new System.Drawing.Size(287, 23);
            this.NOMBREIMPRESORATextBox.TabIndex = 203;
            // 
            // WFUsuarioEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(936, 773);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LableUsuario);
            this.Controls.Add(this.US_USERNAMETextBox);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WFUsuarioEdit";
            this.Text = "USUARIO";
            this.Load += new System.EventHandler(this.USUARIOSEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pERFILES_ASIGNADOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSSeguridad)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pERFILES_ASIGNADOSDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TextBoxET US_NOMBRETextBox;
        private System.Windows.Forms.DateTimePickerE US_VIGENCIATextBox;
 
        private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
        private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
 	private System.Windows.Forms.Label LBError;
    private CustomValidation.RequiredFieldValidator requiredFieldValidator1;
    private CustomValidation.RequiredFieldValidator RFV_US_USUARIO;
 
     
        private CustomValidation.RangeValidator RAV_US_USERID;
     
        private CustomValidation.RangeValidator RAV_US_LIMITE_CONEXIONES;

        private CustomValidation.RangeValidator RAV_US_CONEXIONES_ABIERTAS;
        private System.Windows.Forms.Label US_NOMBRELabel;
        private System.Windows.Forms.Label US_VIGENCIALabel;
        private CustomValidation.RequiredFieldValidator RFV_US_PASSWORD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LableUsuario;
        private System.Windows.Forms.TextBoxET US_USERNAMETextBox;
        private System.Windows.Forms.Panel panel1;
        private Login_and_Maintenance.DSSeguridad dSSeguridad;
        private System.Windows.Forms.BindingSource pERFILES_ASIGNADOSBindingSource;
        private Login_and_Maintenance.DSSeguridadTableAdapters.PERFILES_ASIGNADOSTableAdapter pERFILES_ASIGNADOSTableAdapter;
        private Login_and_Maintenance.DSSeguridadTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum pERFILES_ASIGNADOSDataGridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BTCambiarPassword;
        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBoxET US_GAFFETETextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox LISTAPRECIOIDTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox TICKETLARGOTextBox;
        private System.Windows.Forms.ComboBoxFB ALMACENComboBox;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.ComboBox CAJASBOTELLASTextBox;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.CheckBox TICKETLARGOCREDITOTextBox;
        private System.Windows.Forms.Label label4;
        private Tools.TextBoxFB VENDEDORIDTextBox;
        private System.Windows.Forms.Button VENDEDORButton;
        private System.Windows.Forms.Label VENDEDORLabel;
        private System.Windows.Forms.Label VENDEDORIDLabel;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.NumericTextBox PENDMAXDIASTextBox;
        private Tools.TextBoxFB GRUPOUSUARIOIDTextBox;
        private System.Windows.Forms.Button GRUPOUSUARIOIDButton;
        private System.Windows.Forms.Label GRUPOUSUARIOIDLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgPermitido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPerfil;
        private System.Windows.Forms.TextBox EMAIL1TextBox;
        private System.Windows.Forms.Label EMAIL1Label;
        private Tools.TextBoxFB CLERKIDTextBox;
        private System.Windows.Forms.Button CLERKIDButton;
        private System.Windows.Forms.Label CLERKIDLabel;
        private System.Windows.Forms.Label label7;
        private Tools.TextBoxFB CLERKSERVICIOSTextBox;
        private System.Windows.Forms.Button CLERKSERVICIOSButton;
        private System.Windows.Forms.Label CLERKSERVICIOSLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox TICKETLARGOCOTIZACIONTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBoxET CODIGOAUTORIZACIONTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox CBFormasPago;
        private System.Windows.Forms.Button btnSelectPrinterName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox NOMBREIMPRESORATextBox;
    }
}

