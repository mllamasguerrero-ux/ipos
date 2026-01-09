namespace iPos
{
    partial class WFContraRecibosList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFContraRecibosList));
            this.CBFolioContrarecibo = new System.Windows.Forms.CheckBox();
            this.CBFolioVenta = new System.Windows.Forms.CheckBox();
            this.DTPFechaFin = new System.Windows.Forms.DateTimePicker();
            this.DTPFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.CBFecha = new System.Windows.Forms.CheckBox();
            this.CBCliente = new System.Windows.Forms.CheckBox();
            this.CLIENTECLAVEButton = new System.Windows.Forms.Button();
            this.CLIENTECLAVELabel = new System.Windows.Forms.Label();
            this.btnLookVenta = new System.Windows.Forms.Button();
            this.TBFolioVenta = new System.Windows.Forms.TextBox();
            this.TBFolioContrarecibo = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.CLIENTECLAVETextBox = new iPos.Tools.TextBoxFB();
            this.contrareciboLstDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBREESTATUSPAGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGEDITAR = new System.Windows.Forms.DataGridViewImageColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contrareciboLstBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCobranza2 = new iPos.Cobranza.DSCobranza2();
            this.label1 = new System.Windows.Forms.Label();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.contrareciboLstTableAdapter = new iPos.Cobranza.DSCobranza2TableAdapters.ContrareciboLstTableAdapter();
            this.tableAdapterManager = new iPos.Cobranza.DSCobranza2TableAdapters.TableAdapterManager();
            this.btnReporte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.contrareciboLstDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrareciboLstBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCobranza2)).BeginInit();
            this.SuspendLayout();
            // 
            // CBFolioContrarecibo
            // 
            this.CBFolioContrarecibo.AutoSize = true;
            this.CBFolioContrarecibo.BackColor = System.Drawing.Color.Transparent;
            this.CBFolioContrarecibo.ForeColor = System.Drawing.Color.White;
            this.CBFolioContrarecibo.Location = new System.Drawing.Point(25, 52);
            this.CBFolioContrarecibo.Name = "CBFolioContrarecibo";
            this.CBFolioContrarecibo.Size = new System.Drawing.Size(165, 17);
            this.CBFolioContrarecibo.TabIndex = 0;
            this.CBFolioContrarecibo.Text = "Filtro por folio de contrarecibo";
            this.CBFolioContrarecibo.UseVisualStyleBackColor = false;
            // 
            // CBFolioVenta
            // 
            this.CBFolioVenta.AutoSize = true;
            this.CBFolioVenta.BackColor = System.Drawing.Color.Transparent;
            this.CBFolioVenta.ForeColor = System.Drawing.Color.White;
            this.CBFolioVenta.Location = new System.Drawing.Point(424, 54);
            this.CBFolioVenta.Name = "CBFolioVenta";
            this.CBFolioVenta.Size = new System.Drawing.Size(133, 17);
            this.CBFolioVenta.TabIndex = 1;
            this.CBFolioVenta.Text = "Filtro por folio de venta";
            this.CBFolioVenta.UseVisualStyleBackColor = false;
            // 
            // DTPFechaFin
            // 
            this.DTPFechaFin.Location = new System.Drawing.Point(586, 82);
            this.DTPFechaFin.Name = "DTPFechaFin";
            this.DTPFechaFin.Size = new System.Drawing.Size(200, 20);
            this.DTPFechaFin.TabIndex = 2;
            // 
            // DTPFechaInicio
            // 
            this.DTPFechaInicio.Location = new System.Drawing.Point(206, 82);
            this.DTPFechaInicio.Name = "DTPFechaInicio";
            this.DTPFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.DTPFechaInicio.TabIndex = 3;
            // 
            // CBFecha
            // 
            this.CBFecha.AutoSize = true;
            this.CBFecha.BackColor = System.Drawing.Color.Transparent;
            this.CBFecha.Checked = true;
            this.CBFecha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBFecha.ForeColor = System.Drawing.Color.White;
            this.CBFecha.Location = new System.Drawing.Point(25, 85);
            this.CBFecha.Name = "CBFecha";
            this.CBFecha.Size = new System.Drawing.Size(96, 17);
            this.CBFecha.TabIndex = 4;
            this.CBFecha.Text = "Filtro por fecha";
            this.CBFecha.UseVisualStyleBackColor = false;
            // 
            // CBCliente
            // 
            this.CBCliente.AutoSize = true;
            this.CBCliente.BackColor = System.Drawing.Color.Transparent;
            this.CBCliente.ForeColor = System.Drawing.Color.White;
            this.CBCliente.Location = new System.Drawing.Point(25, 117);
            this.CBCliente.Name = "CBCliente";
            this.CBCliente.Size = new System.Drawing.Size(100, 17);
            this.CBCliente.TabIndex = 5;
            this.CBCliente.Text = "Filtro por cliente";
            this.CBCliente.UseVisualStyleBackColor = false;
            // 
            // CLIENTECLAVEButton
            // 
            this.CLIENTECLAVEButton.BackColor = System.Drawing.Color.Transparent;
            this.CLIENTECLAVEButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.CLIENTECLAVEButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CLIENTECLAVEButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLIENTECLAVEButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.CLIENTECLAVEButton.Location = new System.Drawing.Point(290, 113);
            this.CLIENTECLAVEButton.Name = "CLIENTECLAVEButton";
            this.CLIENTECLAVEButton.Size = new System.Drawing.Size(21, 23);
            this.CLIENTECLAVEButton.TabIndex = 156;
            this.CLIENTECLAVEButton.UseVisualStyleBackColor = false;
            // 
            // CLIENTECLAVELabel
            // 
            this.CLIENTECLAVELabel.AutoSize = true;
            this.CLIENTECLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLIENTECLAVELabel.ForeColor = System.Drawing.Color.White;
            this.CLIENTECLAVELabel.Location = new System.Drawing.Point(317, 118);
            this.CLIENTECLAVELabel.Name = "CLIENTECLAVELabel";
            this.CLIENTECLAVELabel.Size = new System.Drawing.Size(16, 13);
            this.CLIENTECLAVELabel.TabIndex = 157;
            this.CLIENTECLAVELabel.Text = "...";
            // 
            // btnLookVenta
            // 
            this.btnLookVenta.BackColor = System.Drawing.Color.Transparent;
            this.btnLookVenta.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.btnLookVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLookVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLookVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnLookVenta.Location = new System.Drawing.Point(690, 50);
            this.btnLookVenta.Name = "btnLookVenta";
            this.btnLookVenta.Size = new System.Drawing.Size(21, 23);
            this.btnLookVenta.TabIndex = 160;
            this.btnLookVenta.UseVisualStyleBackColor = false;
            this.btnLookVenta.Click += new System.EventHandler(this.btnLookVenta_Click);
            // 
            // TBFolioVenta
            // 
            this.TBFolioVenta.Location = new System.Drawing.Point(586, 51);
            this.TBFolioVenta.Name = "TBFolioVenta";
            this.TBFolioVenta.Size = new System.Drawing.Size(94, 20);
            this.TBFolioVenta.TabIndex = 161;
            // 
            // TBFolioContrarecibo
            // 
            this.TBFolioContrarecibo.Location = new System.Drawing.Point(206, 49);
            this.TBFolioContrarecibo.Name = "TBFolioContrarecibo";
            this.TBFolioContrarecibo.Size = new System.Drawing.Size(94, 20);
            this.TBFolioContrarecibo.TabIndex = 162;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(663, 18);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(123, 29);
            this.btnAgregar.TabIndex = 163;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(663, 117);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(123, 27);
            this.btnBuscar.TabIndex = 164;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.CLIENTECLAVETextBox.IndiceCampoValue = 0;
            this.CLIENTECLAVETextBox.LabelDescription = this.CLIENTECLAVELabel;
            this.CLIENTECLAVETextBox.Location = new System.Drawing.Point(206, 114);
            this.CLIENTECLAVETextBox.MostrarErrores = true;
            this.CLIENTECLAVETextBox.Name = "CLIENTECLAVETextBox";
            this.CLIENTECLAVETextBox.NombreCampoSelector = "clave";
            this.CLIENTECLAVETextBox.NombreCampoValue = "id";
            this.CLIENTECLAVETextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 50";
            this.CLIENTECLAVETextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 50 and  clave = @clave";
            this.CLIENTECLAVETextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 50 and  id = @id";
            this.CLIENTECLAVETextBox.Size = new System.Drawing.Size(82, 20);
            this.CLIENTECLAVETextBox.TabIndex = 155;
            this.CLIENTECLAVETextBox.Tag = 34;
            this.CLIENTECLAVETextBox.TextDescription = null;
            this.CLIENTECLAVETextBox.Titulo = "Proveedores";
            this.CLIENTECLAVETextBox.ValidarEntrada = true;
            this.CLIENTECLAVETextBox.ValidationExpression = null;
            // 
            // contrareciboLstDataGridView
            // 
            this.contrareciboLstDataGridView.AllowUserToAddRows = false;
            this.contrareciboLstDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.contrareciboLstDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.contrareciboLstDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contrareciboLstDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.NOMBREESTATUSPAGO,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn11,
            this.DGEDITAR,
            this.DGID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.contrareciboLstDataGridView.DataSource = this.contrareciboLstBindingSource;
            this.contrareciboLstDataGridView.Location = new System.Drawing.Point(13, 170);
            this.contrareciboLstDataGridView.Name = "contrareciboLstDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.contrareciboLstDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.contrareciboLstDataGridView.RowHeadersVisible = false;
            this.contrareciboLstDataGridView.Size = new System.Drawing.Size(901, 237);
            this.contrareciboLstDataGridView.TabIndex = 166;
            this.contrareciboLstDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.contrareciboLstDataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn3.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "FOLIO";
            this.dataGridViewTextBoxColumn10.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "NOMBRECLIENTE";
            this.dataGridViewTextBoxColumn12.HeaderText = "CLIENTE";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "NOMBREESTATUS";
            this.dataGridViewTextBoxColumn13.HeaderText = "ESTATUS";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // NOMBREESTATUSPAGO
            // 
            this.NOMBREESTATUSPAGO.DataPropertyName = "NOMBREESTATUSPAGO";
            this.NOMBREESTATUSPAGO.HeaderText = "ESTADO PAGO";
            this.NOMBREESTATUSPAGO.Name = "NOMBREESTATUSPAGO";
            this.NOMBREESTATUSPAGO.Width = 130;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "TOTAL";
            this.dataGridViewTextBoxColumn7.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "OBSERVACIONES";
            this.dataGridViewTextBoxColumn11.HeaderText = "OBSERVACIONES";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 200;
            // 
            // DGEDITAR
            // 
            this.DGEDITAR.HeaderText = "";
            this.DGEDITAR.Image = global::iPos.Properties.Resources.edit_J;
            this.DGEDITAR.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.DGEDITAR.Name = "DGEDITAR";
            this.DGEDITAR.Width = 30;
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
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PERSONAID";
            this.dataGridViewTextBoxColumn4.HeaderText = "PERSONAID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "VENDEDORID";
            this.dataGridViewTextBoxColumn5.HeaderText = "VENDEDORID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ESTATUSID";
            this.dataGridViewTextBoxColumn6.HeaderText = "ESTATUSID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ABONO";
            this.dataGridViewTextBoxColumn8.HeaderText = "ABONO";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "SALDO";
            this.dataGridViewTextBoxColumn9.HeaderText = "SALDO";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // contrareciboLstBindingSource
            // 
            this.contrareciboLstBindingSource.DataMember = "ContrareciboLst";
            this.contrareciboLstBindingSource.DataSource = this.dSCobranza2;
            // 
            // dSCobranza2
            // 
            this.dSCobranza2.DataSetName = "DSCobranza2";
            this.dSCobranza2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(150, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 167;
            this.label1.Text = "Estado:";
            // 
            // CBEstado
            // 
            this.CBEstado.FormattingEnabled = true;
            this.CBEstado.Items.AddRange(new object[] {
            "Todos menos cancelados",
            "Registrados",
            "Pendientes",
            "Cancelados"});
            this.CBEstado.Location = new System.Drawing.Point(206, 18);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(205, 21);
            this.CBEstado.TabIndex = 168;
            // 
            // contrareciboLstTableAdapter
            // 
            this.contrareciboLstTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Cobranza.DSCobranza2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.Gray;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReporte.Location = new System.Drawing.Point(554, 425);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(126, 37);
            this.btnReporte.TabIndex = 169;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // WFContraRecibosList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(926, 474);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.CBEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contrareciboLstDataGridView);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.TBFolioContrarecibo);
            this.Controls.Add(this.TBFolioVenta);
            this.Controls.Add(this.btnLookVenta);
            this.Controls.Add(this.CLIENTECLAVEButton);
            this.Controls.Add(this.CLIENTECLAVETextBox);
            this.Controls.Add(this.CLIENTECLAVELabel);
            this.Controls.Add(this.CBCliente);
            this.Controls.Add(this.CBFecha);
            this.Controls.Add(this.DTPFechaInicio);
            this.Controls.Add(this.DTPFechaFin);
            this.Controls.Add(this.CBFolioVenta);
            this.Controls.Add(this.CBFolioContrarecibo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFContraRecibosList";
            this.Text = "CONTRARECIBOS";
            this.Load += new System.EventHandler(this.WFContraRecibosList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contrareciboLstDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrareciboLstBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCobranza2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CBFolioContrarecibo;
        private System.Windows.Forms.CheckBox CBFolioVenta;
        private System.Windows.Forms.DateTimePicker DTPFechaFin;
        private System.Windows.Forms.DateTimePicker DTPFechaInicio;
        private System.Windows.Forms.CheckBox CBFecha;
        private System.Windows.Forms.CheckBox CBCliente;
        private System.Windows.Forms.Button CLIENTECLAVEButton;
        private Tools.TextBoxFB CLIENTECLAVETextBox;
        private System.Windows.Forms.Label CLIENTECLAVELabel;
        private System.Windows.Forms.Button btnLookVenta;
        private System.Windows.Forms.TextBox TBFolioVenta;
        private System.Windows.Forms.TextBox TBFolioContrarecibo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnBuscar;
        private Cobranza.DSCobranza2 dSCobranza2;
        private System.Windows.Forms.BindingSource contrareciboLstBindingSource;
        private Cobranza.DSCobranza2TableAdapters.ContrareciboLstTableAdapter contrareciboLstTableAdapter;
        private Cobranza.DSCobranza2TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum contrareciboLstDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBREESTATUSPAGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewImageColumn DGEDITAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Button btnReporte;
    }
}