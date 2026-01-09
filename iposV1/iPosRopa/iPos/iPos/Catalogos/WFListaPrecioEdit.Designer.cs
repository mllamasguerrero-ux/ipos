
namespace iPos
{
    partial class WFListaPrecioEdit
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
            System.Windows.Forms.Label cOSTOREPOSICIONLabel;
            FirebirdSql.Data.FirebirdClient.FbParameter fbParameter1 = new FirebirdSql.Data.FirebirdClient.FbParameter();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.dSCatalogos3 = new iPos.Catalogos.DSCatalogos3();
            this.lISTAPRECIODETALLEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lISTAPRECIODETALLETableAdapter = new iPos.Catalogos.DSCatalogos3TableAdapters.LISTAPRECIODETALLETableAdapter();
            this.tableAdapterManager = new iPos.Catalogos.DSCatalogos3TableAdapters.TableAdapterManager();
            this.lISTAPRECIODETALLEDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.label2 = new System.Windows.Forms.Label();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LBProductoDescripcion = new System.Windows.Forms.Label();
            this.BTAgregarPrecio = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.PRECIO1TextBox = new System.Windows.Forms.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PRECIO2TextBox = new System.Windows.Forms.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PRECIO3TextBox = new System.Windows.Forms.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PRECIO4TextBox = new System.Windows.Forms.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PRECIO5TextBox = new System.Windows.Forms.NumericTextBox();
            this.BTImportarListaPrecio = new System.Windows.Forms.Button();
            this.CBPrecioConImpuesto = new System.Windows.Forms.CheckBox();
            this.pnlDetalles = new System.Windows.Forms.Panel();
            this.TIENEVIGCheckBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.FECHAVIGDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.BTCargarProductos = new System.Windows.Forms.Button();
            this.BTExportarListaPrecio = new System.Windows.Forms.Button();
            this.COSTOREPOSICIONTextBox = new System.Windows.Forms.TextBox();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGBORRAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGEDITAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIO1CONIMPUESTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIO2CONIMPUESTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIO3CONIMPUESTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIO4CONIMPUESTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIO5CONIMPUESTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COSTOREPOSICION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COSTOREPOSICIONCONIMPUESTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIENEVIG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAVIG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cOSTOREPOSICIONLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lISTAPRECIODETALLEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lISTAPRECIODETALLEDataGridView)).BeginInit();
            this.pnlDetalles.SuspendLayout();
            this.SuspendLayout();
            // 
            // cOSTOREPOSICIONLabel
            // 
            cOSTOREPOSICIONLabel.AutoSize = true;
            cOSTOREPOSICIONLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cOSTOREPOSICIONLabel.ForeColor = System.Drawing.Color.White;
            cOSTOREPOSICIONLabel.Location = new System.Drawing.Point(160, 262);
            cOSTOREPOSICIONLabel.Name = "cOSTOREPOSICIONLabel";
            cOSTOREPOSICIONLabel.Size = new System.Drawing.Size(110, 13);
            cOSTOREPOSICIONLabel.TabIndex = 293;
            cOSTOREPOSICIONLabel.Text = "Costo Reposición:";
            // 
            // ACTIVOLabel
            // 
            this.ACTIVOLabel.AutoSize = true;
            this.ACTIVOLabel.BackColor = System.Drawing.Color.Transparent;
            this.ACTIVOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACTIVOLabel.ForeColor = System.Drawing.Color.White;
            this.ACTIVOLabel.Location = new System.Drawing.Point(316, 8);
            this.ACTIVOLabel.Name = "ACTIVOLabel";
            this.ACTIVOLabel.Size = new System.Drawing.Size(47, 13);
            this.ACTIVOLabel.TabIndex = 1;
            this.ACTIVOLabel.Text = "Activo:";
            // 
            // CLAVELabel
            // 
            this.CLAVELabel.AutoSize = true;
            this.CLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLAVELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLAVELabel.ForeColor = System.Drawing.Color.White;
            this.CLAVELabel.Location = new System.Drawing.Point(23, 22);
            this.CLAVELabel.Name = "CLAVELabel";
            this.CLAVELabel.Size = new System.Drawing.Size(43, 13);
            this.CLAVELabel.TabIndex = 1;
            this.CLAVELabel.Text = "Clave:";
            // 
            // NOMBRELabel
            // 
            this.NOMBRELabel.AutoSize = true;
            this.NOMBRELabel.BackColor = System.Drawing.Color.Transparent;
            this.NOMBRELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NOMBRELabel.ForeColor = System.Drawing.Color.White;
            this.NOMBRELabel.Location = new System.Drawing.Point(6, 5);
            this.NOMBRELabel.Name = "NOMBRELabel";
            this.NOMBRELabel.Size = new System.Drawing.Size(54, 13);
            this.NOMBRELabel.TabIndex = 1;
            this.NOMBRELabel.Text = "Nombre:";
            // 
            // CLAVETextBox
            // 
            this.CLAVETextBox.Location = new System.Drawing.Point(94, 19);
            this.CLAVETextBox.Name = "CLAVETextBox";
            this.CLAVETextBox.Size = new System.Drawing.Size(212, 20);
            this.CLAVETextBox.TabIndex = 1;
            this.CLAVETextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CLAVETextBox_Validating);
            // 
            // NOMBRETextBox
            // 
            this.NOMBRETextBox.Location = new System.Drawing.Point(88, 5);
            this.NOMBRETextBox.Name = "NOMBRETextBox";
            this.NOMBRETextBox.Size = new System.Drawing.Size(212, 20);
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
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(202, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 30);
            this.button1.TabIndex = 3;
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
            this.panel1.Location = new System.Drawing.Point(321, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 33);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(391, 8);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ACTIVOTextBox.TabIndex = 5;
            this.ACTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // BTIniciaEdicion
            // 
            this.BTIniciaEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTIniciaEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTIniciaEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIniciaEdicion.ForeColor = System.Drawing.Color.White;
            this.BTIniciaEdicion.Location = new System.Drawing.Point(123, 393);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(57, 23);
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
            this.BTCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCancelar.ForeColor = System.Drawing.Color.White;
            this.BTCancelar.Image = global::iPos.Properties.Resources.cancel_J;
            this.BTCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCancelar.Location = new System.Drawing.Point(310, 389);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(112, 30);
            this.BTCancelar.TabIndex = 47;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // dSCatalogos3
            // 
            this.dSCatalogos3.DataSetName = "DSCatalogos3";
            this.dSCatalogos3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lISTAPRECIODETALLEBindingSource
            // 
            this.lISTAPRECIODETALLEBindingSource.DataMember = "LISTAPRECIODETALLE";
            this.lISTAPRECIODETALLEBindingSource.DataSource = this.dSCatalogos3;
            // 
            // lISTAPRECIODETALLETableAdapter
            // 
            this.lISTAPRECIODETALLETableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Catalogos.DSCatalogos3TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // lISTAPRECIODETALLEDataGridView
            // 
            this.lISTAPRECIODETALLEDataGridView.AllowUserToAddRows = false;
            this.lISTAPRECIODETALLEDataGridView.AutoGenerateColumns = false;
            this.lISTAPRECIODETALLEDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lISTAPRECIODETALLEDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.DGBORRAR,
            this.DGEDITAR,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.DGCLAVE,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn4,
            this.PRECIO1CONIMPUESTO,
            this.dataGridViewTextBoxColumn5,
            this.PRECIO2CONIMPUESTO,
            this.dataGridViewTextBoxColumn6,
            this.PRECIO3CONIMPUESTO,
            this.dataGridViewTextBoxColumn7,
            this.PRECIO4CONIMPUESTO,
            this.dataGridViewTextBoxColumn8,
            this.PRECIO5CONIMPUESTO,
            this.dataGridViewTextBoxColumn9,
            this.COSTOREPOSICION,
            this.COSTOREPOSICIONCONIMPUESTO,
            this.TIENEVIG,
            this.FECHAVIG});
            this.lISTAPRECIODETALLEDataGridView.DataSource = this.lISTAPRECIODETALLEBindingSource;
            this.lISTAPRECIODETALLEDataGridView.Location = new System.Drawing.Point(3, 3);
            this.lISTAPRECIODETALLEDataGridView.Name = "lISTAPRECIODETALLEDataGridView";
            this.lISTAPRECIODETALLEDataGridView.RowHeadersVisible = false;
            this.lISTAPRECIODETALLEDataGridView.Size = new System.Drawing.Size(850, 164);
            this.lISTAPRECIODETALLEDataGridView.TabIndex = 49;
            this.lISTAPRECIODETALLEDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lISTAPRECIODETALLEDataGridView_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(3, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 272;
            this.label2.Text = "Codigo";
            // 
            // TBCodigo
            // 
            this.TBCodigo.Location = new System.Drawing.Point(84, 193);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(100, 20);
            this.TBCodigo.TabIndex = 271;
            this.TBCodigo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBCodigo_PreviewKeyDown);
            this.TBCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.TBCodigo_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(3, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 273;
            this.label6.Text = "Descripción:";
            // 
            // LBProductoDescripcion
            // 
            this.LBProductoDescripcion.AutoSize = true;
            this.LBProductoDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.LBProductoDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBProductoDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LBProductoDescripcion.Location = new System.Drawing.Point(103, 231);
            this.LBProductoDescripcion.Name = "LBProductoDescripcion";
            this.LBProductoDescripcion.Size = new System.Drawing.Size(19, 13);
            this.LBProductoDescripcion.TabIndex = 274;
            this.LBProductoDescripcion.Text = "...";
            // 
            // BTAgregarPrecio
            // 
            this.BTAgregarPrecio.BackColor = System.Drawing.Color.Gray;
            this.BTAgregarPrecio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTAgregarPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregarPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTAgregarPrecio.ForeColor = System.Drawing.Color.White;
            this.BTAgregarPrecio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTAgregarPrecio.Location = new System.Drawing.Point(595, 298);
            this.BTAgregarPrecio.Name = "BTAgregarPrecio";
            this.BTAgregarPrecio.Size = new System.Drawing.Size(176, 27);
            this.BTAgregarPrecio.TabIndex = 279;
            this.BTAgregarPrecio.Text = "Guardar precio";
            this.BTAgregarPrecio.UseVisualStyleBackColor = false;
            this.BTAgregarPrecio.Click += new System.EventHandler(this.BTAgregarPrecio_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label12.Location = new System.Drawing.Point(205, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 278;
            this.label12.Text = "Precio 1";
            // 
            // PRECIO1TextBox
            // 
            this.PRECIO1TextBox.AllowNegative = true;
            this.PRECIO1TextBox.Format_Expression = null;
            this.PRECIO1TextBox.Location = new System.Drawing.Point(276, 193);
            this.PRECIO1TextBox.Name = "PRECIO1TextBox";
            this.PRECIO1TextBox.NumericPrecision = 18;
            this.PRECIO1TextBox.NumericScaleOnFocus = 2;
            this.PRECIO1TextBox.NumericScaleOnLostFocus = 2;
            this.PRECIO1TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PRECIO1TextBox.Size = new System.Drawing.Size(100, 20);
            this.PRECIO1TextBox.TabIndex = 277;
            this.PRECIO1TextBox.Tag = 34;
            this.PRECIO1TextBox.Text = "0.00";
            this.PRECIO1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PRECIO1TextBox.ValidationExpression = null;
            this.PRECIO1TextBox.ZeroIsValid = true;
            this.PRECIO1TextBox.Validating += new System.ComponentModel.CancelEventHandler(this.PRECIO1TextBox_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(412, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 281;
            this.label1.Text = "Precio 2";
            // 
            // PRECIO2TextBox
            // 
            this.PRECIO2TextBox.AllowNegative = true;
            this.PRECIO2TextBox.Format_Expression = null;
            this.PRECIO2TextBox.Location = new System.Drawing.Point(483, 193);
            this.PRECIO2TextBox.Name = "PRECIO2TextBox";
            this.PRECIO2TextBox.NumericPrecision = 18;
            this.PRECIO2TextBox.NumericScaleOnFocus = 2;
            this.PRECIO2TextBox.NumericScaleOnLostFocus = 2;
            this.PRECIO2TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PRECIO2TextBox.Size = new System.Drawing.Size(100, 20);
            this.PRECIO2TextBox.TabIndex = 280;
            this.PRECIO2TextBox.Tag = 34;
            this.PRECIO2TextBox.Text = "0.00";
            this.PRECIO2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PRECIO2TextBox.ValidationExpression = null;
            this.PRECIO2TextBox.ZeroIsValid = true;
            this.PRECIO2TextBox.Validating += new System.ComponentModel.CancelEventHandler(this.PRECIO2TextBox_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(595, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 283;
            this.label3.Text = "Precio 3";
            // 
            // PRECIO3TextBox
            // 
            this.PRECIO3TextBox.AllowNegative = true;
            this.PRECIO3TextBox.Format_Expression = null;
            this.PRECIO3TextBox.Location = new System.Drawing.Point(666, 189);
            this.PRECIO3TextBox.Name = "PRECIO3TextBox";
            this.PRECIO3TextBox.NumericPrecision = 18;
            this.PRECIO3TextBox.NumericScaleOnFocus = 2;
            this.PRECIO3TextBox.NumericScaleOnLostFocus = 2;
            this.PRECIO3TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PRECIO3TextBox.Size = new System.Drawing.Size(100, 20);
            this.PRECIO3TextBox.TabIndex = 282;
            this.PRECIO3TextBox.Tag = 34;
            this.PRECIO3TextBox.Text = "0.00";
            this.PRECIO3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PRECIO3TextBox.ValidationExpression = null;
            this.PRECIO3TextBox.ZeroIsValid = true;
            this.PRECIO3TextBox.Validating += new System.ComponentModel.CancelEventHandler(this.PRECIO3TextBox_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(412, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 285;
            this.label4.Text = "Precio 4";
            // 
            // PRECIO4TextBox
            // 
            this.PRECIO4TextBox.AllowNegative = true;
            this.PRECIO4TextBox.Format_Expression = null;
            this.PRECIO4TextBox.Location = new System.Drawing.Point(483, 224);
            this.PRECIO4TextBox.Name = "PRECIO4TextBox";
            this.PRECIO4TextBox.NumericPrecision = 18;
            this.PRECIO4TextBox.NumericScaleOnFocus = 2;
            this.PRECIO4TextBox.NumericScaleOnLostFocus = 2;
            this.PRECIO4TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PRECIO4TextBox.Size = new System.Drawing.Size(100, 20);
            this.PRECIO4TextBox.TabIndex = 284;
            this.PRECIO4TextBox.Tag = 34;
            this.PRECIO4TextBox.Text = "0.00";
            this.PRECIO4TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PRECIO4TextBox.ValidationExpression = null;
            this.PRECIO4TextBox.ZeroIsValid = true;
            this.PRECIO4TextBox.Validating += new System.ComponentModel.CancelEventHandler(this.PRECIO4TextBox_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(595, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 287;
            this.label5.Text = "Precio 5";
            // 
            // PRECIO5TextBox
            // 
            this.PRECIO5TextBox.AllowNegative = true;
            this.PRECIO5TextBox.Format_Expression = null;
            this.PRECIO5TextBox.Location = new System.Drawing.Point(666, 224);
            this.PRECIO5TextBox.Name = "PRECIO5TextBox";
            this.PRECIO5TextBox.NumericPrecision = 18;
            this.PRECIO5TextBox.NumericScaleOnFocus = 2;
            this.PRECIO5TextBox.NumericScaleOnLostFocus = 2;
            this.PRECIO5TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PRECIO5TextBox.Size = new System.Drawing.Size(100, 20);
            this.PRECIO5TextBox.TabIndex = 286;
            this.PRECIO5TextBox.Tag = 34;
            this.PRECIO5TextBox.Text = "0.00";
            this.PRECIO5TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PRECIO5TextBox.ValidationExpression = null;
            this.PRECIO5TextBox.ZeroIsValid = true;
            this.PRECIO5TextBox.Validating += new System.ComponentModel.CancelEventHandler(this.PRECIO5TextBox_Validating);
            // 
            // BTImportarListaPrecio
            // 
            this.BTImportarListaPrecio.BackColor = System.Drawing.Color.Gray;
            this.BTImportarListaPrecio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTImportarListaPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTImportarListaPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTImportarListaPrecio.ForeColor = System.Drawing.Color.White;
            this.BTImportarListaPrecio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTImportarListaPrecio.Location = new System.Drawing.Point(3, 298);
            this.BTImportarListaPrecio.Name = "BTImportarListaPrecio";
            this.BTImportarListaPrecio.Size = new System.Drawing.Size(93, 29);
            this.BTImportarListaPrecio.TabIndex = 290;
            this.BTImportarListaPrecio.Text = "Importar lista ";
            this.BTImportarListaPrecio.UseVisualStyleBackColor = false;
            this.BTImportarListaPrecio.Click += new System.EventHandler(this.BTImportarListaPrecio_Click);
            // 
            // CBPrecioConImpuesto
            // 
            this.CBPrecioConImpuesto.AutoSize = true;
            this.CBPrecioConImpuesto.BackColor = System.Drawing.Color.Transparent;
            this.CBPrecioConImpuesto.Checked = true;
            this.CBPrecioConImpuesto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBPrecioConImpuesto.ForeColor = System.Drawing.Color.White;
            this.CBPrecioConImpuesto.Location = new System.Drawing.Point(6, 262);
            this.CBPrecioConImpuesto.Name = "CBPrecioConImpuesto";
            this.CBPrecioConImpuesto.Size = new System.Drawing.Size(90, 17);
            this.CBPrecioConImpuesto.TabIndex = 291;
            this.CBPrecioConImpuesto.Text = "Con impuesto";
            this.CBPrecioConImpuesto.UseVisualStyleBackColor = false;
            // 
            // pnlDetalles
            // 
            this.pnlDetalles.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetalles.Controls.Add(this.TIENEVIGCheckBox);
            this.pnlDetalles.Controls.Add(this.label8);
            this.pnlDetalles.Controls.Add(this.FECHAVIGDateTimePicker);
            this.pnlDetalles.Controls.Add(this.label7);
            this.pnlDetalles.Controls.Add(this.button2);
            this.pnlDetalles.Controls.Add(this.BTCargarProductos);
            this.pnlDetalles.Controls.Add(this.BTExportarListaPrecio);
            this.pnlDetalles.Controls.Add(this.COSTOREPOSICIONTextBox);
            this.pnlDetalles.Controls.Add(cOSTOREPOSICIONLabel);
            this.pnlDetalles.Controls.Add(this.lISTAPRECIODETALLEDataGridView);
            this.pnlDetalles.Controls.Add(this.CBPrecioConImpuesto);
            this.pnlDetalles.Controls.Add(this.PRECIO1TextBox);
            this.pnlDetalles.Controls.Add(this.BTImportarListaPrecio);
            this.pnlDetalles.Controls.Add(this.label12);
            this.pnlDetalles.Controls.Add(this.label5);
            this.pnlDetalles.Controls.Add(this.BTAgregarPrecio);
            this.pnlDetalles.Controls.Add(this.PRECIO5TextBox);
            this.pnlDetalles.Controls.Add(this.LBProductoDescripcion);
            this.pnlDetalles.Controls.Add(this.label4);
            this.pnlDetalles.Controls.Add(this.label6);
            this.pnlDetalles.Controls.Add(this.PRECIO4TextBox);
            this.pnlDetalles.Controls.Add(this.TBCodigo);
            this.pnlDetalles.Controls.Add(this.label3);
            this.pnlDetalles.Controls.Add(this.label2);
            this.pnlDetalles.Controls.Add(this.PRECIO3TextBox);
            this.pnlDetalles.Controls.Add(this.PRECIO2TextBox);
            this.pnlDetalles.Controls.Add(this.label1);
            this.pnlDetalles.Location = new System.Drawing.Point(3, 45);
            this.pnlDetalles.Name = "pnlDetalles";
            this.pnlDetalles.Size = new System.Drawing.Size(873, 337);
            this.pnlDetalles.TabIndex = 292;
            // 
            // TIENEVIGCheckBox
            // 
            this.TIENEVIGCheckBox.AutoSize = true;
            this.TIENEVIGCheckBox.Location = new System.Drawing.Point(497, 262);
            this.TIENEVIGCheckBox.Name = "TIENEVIGCheckBox";
            this.TIENEVIGCheckBox.Size = new System.Drawing.Size(15, 14);
            this.TIENEVIGCheckBox.TabIndex = 301;
            this.TIENEVIGCheckBox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(595, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 300;
            this.label8.Text = "Fecha vig:";
            // 
            // FECHAVIGDateTimePicker
            // 
            this.FECHAVIGDateTimePicker.Location = new System.Drawing.Point(666, 260);
            this.FECHAVIGDateTimePicker.Name = "FECHAVIGDateTimePicker";
            this.FECHAVIGDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.FECHAVIGDateTimePicker.TabIndex = 299;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(403, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 298;
            this.label7.Text = "Tiene vig:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(391, 298);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 27);
            this.button2.TabIndex = 296;
            this.button2.Text = "Borrar precios";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BTCargarProductos
            // 
            this.BTCargarProductos.BackColor = System.Drawing.Color.Gray;
            this.BTCargarProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCargarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCargarProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCargarProductos.ForeColor = System.Drawing.Color.White;
            this.BTCargarProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCargarProductos.Location = new System.Drawing.Point(209, 298);
            this.BTCargarProductos.Name = "BTCargarProductos";
            this.BTCargarProductos.Size = new System.Drawing.Size(176, 27);
            this.BTCargarProductos.TabIndex = 295;
            this.BTCargarProductos.Text = "Cargar productos actuales";
            this.BTCargarProductos.UseVisualStyleBackColor = false;
            this.BTCargarProductos.Click += new System.EventHandler(this.BTCargarProductos_Click);
            // 
            // BTExportarListaPrecio
            // 
            this.BTExportarListaPrecio.BackColor = System.Drawing.Color.Gray;
            this.BTExportarListaPrecio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTExportarListaPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTExportarListaPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTExportarListaPrecio.ForeColor = System.Drawing.Color.White;
            this.BTExportarListaPrecio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTExportarListaPrecio.Location = new System.Drawing.Point(102, 298);
            this.BTExportarListaPrecio.Name = "BTExportarListaPrecio";
            this.BTExportarListaPrecio.Size = new System.Drawing.Size(101, 27);
            this.BTExportarListaPrecio.TabIndex = 294;
            this.BTExportarListaPrecio.Text = "Exportar lista";
            this.BTExportarListaPrecio.UseVisualStyleBackColor = false;
            this.BTExportarListaPrecio.Click += new System.EventHandler(this.BTExportarListaPrecio_Click);
            // 
            // COSTOREPOSICIONTextBox
            // 
            this.COSTOREPOSICIONTextBox.Location = new System.Drawing.Point(276, 259);
            this.COSTOREPOSICIONTextBox.Name = "COSTOREPOSICIONTextBox";
            this.COSTOREPOSICIONTextBox.ReadOnly = true;
            this.COSTOREPOSICIONTextBox.Size = new System.Drawing.Size(100, 20);
            this.COSTOREPOSICIONTextBox.TabIndex = 292;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // DGBORRAR
            // 
            this.DGBORRAR.HeaderText = "";
            this.DGBORRAR.Name = "DGBORRAR";
            this.DGBORRAR.Text = "Borrar";
            this.DGBORRAR.UseColumnTextForButtonValue = true;
            this.DGBORRAR.Width = 70;
            // 
            // DGEDITAR
            // 
            this.DGEDITAR.HeaderText = "";
            this.DGEDITAR.Name = "DGEDITAR";
            this.DGEDITAR.Text = "Editar";
            this.DGEDITAR.UseColumnTextForButtonValue = true;
            this.DGEDITAR.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LISTAPRECIOID";
            this.dataGridViewTextBoxColumn2.HeaderText = "LISTAPRECIOID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PRODUCTOID";
            this.dataGridViewTextBoxColumn3.HeaderText = "PRODUCTOID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // DGCLAVE
            // 
            this.DGCLAVE.DataPropertyName = "CLAVE";
            this.DGCLAVE.HeaderText = "CLAVE";
            this.DGCLAVE.Name = "DGCLAVE";
            this.DGCLAVE.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "DESCRIPCION";
            this.dataGridViewTextBoxColumn11.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn12.HeaderText = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PRECIO1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn4.HeaderText = "PRECIO1";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 85;
            // 
            // PRECIO1CONIMPUESTO
            // 
            this.PRECIO1CONIMPUESTO.DataPropertyName = "PRECIO1CONIMPUESTO";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.PRECIO1CONIMPUESTO.DefaultCellStyle = dataGridViewCellStyle2;
            this.PRECIO1CONIMPUESTO.HeaderText = "PRECIO1 C/I";
            this.PRECIO1CONIMPUESTO.Name = "PRECIO1CONIMPUESTO";
            this.PRECIO1CONIMPUESTO.Width = 85;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PRECIO2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn5.HeaderText = "PRECIO2";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 85;
            // 
            // PRECIO2CONIMPUESTO
            // 
            this.PRECIO2CONIMPUESTO.DataPropertyName = "PRECIO2CONIMPUESTO";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.PRECIO2CONIMPUESTO.DefaultCellStyle = dataGridViewCellStyle4;
            this.PRECIO2CONIMPUESTO.HeaderText = "PRECIO2 C/I";
            this.PRECIO2CONIMPUESTO.Name = "PRECIO2CONIMPUESTO";
            this.PRECIO2CONIMPUESTO.Width = 85;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PRECIO3";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn6.HeaderText = "PRECIO3";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 85;
            // 
            // PRECIO3CONIMPUESTO
            // 
            this.PRECIO3CONIMPUESTO.DataPropertyName = "PRECIO3CONIMPUESTO";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.PRECIO3CONIMPUESTO.DefaultCellStyle = dataGridViewCellStyle6;
            this.PRECIO3CONIMPUESTO.HeaderText = "PRECIO3 C/I";
            this.PRECIO3CONIMPUESTO.Name = "PRECIO3CONIMPUESTO";
            this.PRECIO3CONIMPUESTO.Width = 85;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PRECIO4";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn7.HeaderText = "PRECIO4";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 85;
            // 
            // PRECIO4CONIMPUESTO
            // 
            this.PRECIO4CONIMPUESTO.DataPropertyName = "PRECIO4CONIMPUESTO";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.PRECIO4CONIMPUESTO.DefaultCellStyle = dataGridViewCellStyle8;
            this.PRECIO4CONIMPUESTO.HeaderText = "PRECIO4 C/I";
            this.PRECIO4CONIMPUESTO.Name = "PRECIO4CONIMPUESTO";
            this.PRECIO4CONIMPUESTO.Width = 85;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PRECIO5";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn8.HeaderText = "PRECIO5";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 85;
            // 
            // PRECIO5CONIMPUESTO
            // 
            this.PRECIO5CONIMPUESTO.DataPropertyName = "PRECIO5CONIMPUESTO";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.PRECIO5CONIMPUESTO.DefaultCellStyle = dataGridViewCellStyle10;
            this.PRECIO5CONIMPUESTO.HeaderText = "PRECIO5 C/I";
            this.PRECIO5CONIMPUESTO.Name = "PRECIO5CONIMPUESTO";
            this.PRECIO5CONIMPUESTO.Width = 85;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "PRECIO6";
            this.dataGridViewTextBoxColumn9.HeaderText = "PRECIO6";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // COSTOREPOSICION
            // 
            this.COSTOREPOSICION.DataPropertyName = "COSTOREPOSICION";
            dataGridViewCellStyle11.Format = "N2";
            this.COSTOREPOSICION.DefaultCellStyle = dataGridViewCellStyle11;
            this.COSTOREPOSICION.HeaderText = "COSTO REP.";
            this.COSTOREPOSICION.Name = "COSTOREPOSICION";
            this.COSTOREPOSICION.Width = 85;
            // 
            // COSTOREPOSICIONCONIMPUESTO
            // 
            this.COSTOREPOSICIONCONIMPUESTO.DataPropertyName = "COSTOREPOSICIONCONIMPUESTO";
            dataGridViewCellStyle12.Format = "N2";
            this.COSTOREPOSICIONCONIMPUESTO.DefaultCellStyle = dataGridViewCellStyle12;
            this.COSTOREPOSICIONCONIMPUESTO.HeaderText = "COSTO REP C/I";
            this.COSTOREPOSICIONCONIMPUESTO.Name = "COSTOREPOSICIONCONIMPUESTO";
            this.COSTOREPOSICIONCONIMPUESTO.Width = 85;
            // 
            // TIENEVIG
            // 
            this.TIENEVIG.DataPropertyName = "TIENEVIG";
            this.TIENEVIG.HeaderText = "TIENE VIG.";
            this.TIENEVIG.Name = "TIENEVIG";
            this.TIENEVIG.Width = 85;
            // 
            // FECHAVIG
            // 
            this.FECHAVIG.DataPropertyName = "FECHAVIG";
            this.FECHAVIG.HeaderText = "FECHA VIG.";
            this.FECHAVIG.Name = "FECHAVIG";
            this.FECHAVIG.Width = 85;
            // 
            // WFListaPrecioEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(898, 431);
            this.Controls.Add(this.pnlDetalles);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CLAVELabel);
            this.Controls.Add(this.CLAVETextBox);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WFListaPrecioEdit";
            this.Text = "LISTA PRECIO";
            this.Load += new System.EventHandler(this.LINEAEdit_Reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lISTAPRECIODETALLEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lISTAPRECIODETALLEDataGridView)).EndInit();
            this.pnlDetalles.ResumeLayout(false);
            this.pnlDetalles.PerformLayout();
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
        private Catalogos.DSCatalogos3 dSCatalogos3;
        private System.Windows.Forms.BindingSource lISTAPRECIODETALLEBindingSource;
        private Catalogos.DSCatalogos3TableAdapters.LISTAPRECIODETALLETableAdapter lISTAPRECIODETALLETableAdapter;
        private Catalogos.DSCatalogos3TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum lISTAPRECIODETALLEDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LBProductoDescripcion;
        private System.Windows.Forms.Button BTAgregarPrecio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericTextBox PRECIO1TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericTextBox PRECIO2TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericTextBox PRECIO3TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericTextBox PRECIO4TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericTextBox PRECIO5TextBox;
        private System.Windows.Forms.Button BTImportarListaPrecio;
        private System.Windows.Forms.CheckBox CBPrecioConImpuesto;
        private System.Windows.Forms.Panel pnlDetalles;
        private System.Windows.Forms.TextBox COSTOREPOSICIONTextBox;
        private System.Windows.Forms.Button BTExportarListaPrecio;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BTCargarProductos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker FECHAVIGDateTimePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox TIENEVIGCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewButtonColumn DGBORRAR;
        private System.Windows.Forms.DataGridViewButtonColumn DGEDITAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO1CONIMPUESTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO2CONIMPUESTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO3CONIMPUESTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO4CONIMPUESTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO5CONIMPUESTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn COSTOREPOSICION;
        private System.Windows.Forms.DataGridViewTextBoxColumn COSTOREPOSICIONCONIMPUESTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIENEVIG;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAVIG;
    }
}

