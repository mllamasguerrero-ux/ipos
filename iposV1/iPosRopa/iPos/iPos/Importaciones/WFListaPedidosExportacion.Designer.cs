namespace iPos
{
    partial class WFListaPedidosExportacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFListaPedidosExportacion));
            this.vENTASLISTADataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fOLIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOMBREDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFECHAINI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFECHAFIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cORTEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vENDEDORIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOMBRECAJERODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eSTATUSPEDIDODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGTRASLADOAFTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGContinuar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGVer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGREENVIAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGELIMINAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DG_EXPFILEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lISTAPEDIDOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSImportaciones = new iPos.Importaciones.DSImportaciones();
            this.LBTIPOREG = new System.Windows.Forms.Label();
            this.CBTipo = new System.Windows.Forms.ComboBox();
            this.CBCorteActual = new System.Windows.Forms.CheckBox();
            this.CBCajerosTodos = new System.Windows.Forms.CheckBox();
            this.VENDEDORButton = new System.Windows.Forms.Button();
            this.VENDEDORLabel = new System.Windows.Forms.Label();
            this.pnlCajero = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.VENDEDORIDTextBox = new iPos.Tools.TextBoxFB();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlCorteActual = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tableAdapterManager = new iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBFechaElaboracion = new System.Windows.Forms.CheckBox();
            this.lISTAPEDIDOSTableAdapter = new iPos.Importaciones.DSImportacionesTableAdapters.LISTAPEDIDOSTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.CBEstatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.vENTASLISTADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lISTAPEDIDOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).BeginInit();
            this.pnlCajero.SuspendLayout();
            this.pnlCorteActual.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vENTASLISTADataGridView
            // 
            this.vENTASLISTADataGridView.AllowUserToAddRows = false;
            this.vENTASLISTADataGridView.AutoGenerateColumns = false;
            this.vENTASLISTADataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.vENTASLISTADataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.vENTASLISTADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vENTASLISTADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.fOLIODataGridViewTextBoxColumn,
            this.nOMBREDataGridViewTextBoxColumn,
            this.fECHADataGridViewTextBoxColumn,
            this.DGFECHAINI,
            this.DGFECHAFIN,
            this.cORTEIDDataGridViewTextBoxColumn,
            this.vENDEDORIDDataGridViewTextBoxColumn,
            this.nOMBRECAJERODataGridViewTextBoxColumn,
            this.eSTATUSPEDIDODataGridViewTextBoxColumn,
            this.DGTRASLADOAFTP,
            this.DGContinuar,
            this.DGVer,
            this.DGREENVIAR,
            this.DGELIMINAR,
            this.DG_EXPFILEID});
            this.vENTASLISTADataGridView.DataSource = this.lISTAPEDIDOSBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.vENTASLISTADataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.vENTASLISTADataGridView.EnableHeadersVisualStyles = false;
            this.vENTASLISTADataGridView.Location = new System.Drawing.Point(0, 61);
            this.vENTASLISTADataGridView.Name = "vENTASLISTADataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.vENTASLISTADataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.vENTASLISTADataGridView.RowHeadersVisible = false;
            this.vENTASLISTADataGridView.Size = new System.Drawing.Size(980, 374);
            this.vENTASLISTADataGridView.TabIndex = 2;
            this.vENTASLISTADataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vENTASLISTADataGridView_CellContentClick_1);
            this.vENTASLISTADataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vENTASLISTADataGridView_CellContentClick);
            this.vENTASLISTADataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vENTASLISTADataGridView_KeyPress);
            this.vENTASLISTADataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.vENTASLISTADataGridView_PreviewKeyDown);
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // fOLIODataGridViewTextBoxColumn
            // 
            this.fOLIODataGridViewTextBoxColumn.DataPropertyName = "FOLIO";
            this.fOLIODataGridViewTextBoxColumn.HeaderText = "FOLIO";
            this.fOLIODataGridViewTextBoxColumn.Name = "fOLIODataGridViewTextBoxColumn";
            this.fOLIODataGridViewTextBoxColumn.Width = 75;
            // 
            // nOMBREDataGridViewTextBoxColumn
            // 
            this.nOMBREDataGridViewTextBoxColumn.DataPropertyName = "NOMBRE";
            this.nOMBREDataGridViewTextBoxColumn.HeaderText = "TIPO";
            this.nOMBREDataGridViewTextBoxColumn.Name = "nOMBREDataGridViewTextBoxColumn";
            // 
            // fECHADataGridViewTextBoxColumn
            // 
            this.fECHADataGridViewTextBoxColumn.DataPropertyName = "FECHA";
            this.fECHADataGridViewTextBoxColumn.HeaderText = "FECHA";
            this.fECHADataGridViewTextBoxColumn.Name = "fECHADataGridViewTextBoxColumn";
            this.fECHADataGridViewTextBoxColumn.Width = 75;
            // 
            // DGFECHAINI
            // 
            this.DGFECHAINI.DataPropertyName = "FECHAINI";
            this.DGFECHAINI.HeaderText = "FECHAINI";
            this.DGFECHAINI.Name = "DGFECHAINI";
            this.DGFECHAINI.Width = 75;
            // 
            // DGFECHAFIN
            // 
            this.DGFECHAFIN.DataPropertyName = "FECHAFIN";
            this.DGFECHAFIN.HeaderText = "FECHAFIN";
            this.DGFECHAFIN.Name = "DGFECHAFIN";
            this.DGFECHAFIN.Width = 75;
            // 
            // cORTEIDDataGridViewTextBoxColumn
            // 
            this.cORTEIDDataGridViewTextBoxColumn.DataPropertyName = "CORTEID";
            this.cORTEIDDataGridViewTextBoxColumn.HeaderText = "CORTEID";
            this.cORTEIDDataGridViewTextBoxColumn.Name = "cORTEIDDataGridViewTextBoxColumn";
            this.cORTEIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // vENDEDORIDDataGridViewTextBoxColumn
            // 
            this.vENDEDORIDDataGridViewTextBoxColumn.DataPropertyName = "VENDEDORID";
            this.vENDEDORIDDataGridViewTextBoxColumn.HeaderText = "VENDEDORID";
            this.vENDEDORIDDataGridViewTextBoxColumn.Name = "vENDEDORIDDataGridViewTextBoxColumn";
            this.vENDEDORIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nOMBRECAJERODataGridViewTextBoxColumn
            // 
            this.nOMBRECAJERODataGridViewTextBoxColumn.DataPropertyName = "NOMBRECAJERO";
            this.nOMBRECAJERODataGridViewTextBoxColumn.HeaderText = "NOMBRECAJERO";
            this.nOMBRECAJERODataGridViewTextBoxColumn.Name = "nOMBRECAJERODataGridViewTextBoxColumn";
            // 
            // eSTATUSPEDIDODataGridViewTextBoxColumn
            // 
            this.eSTATUSPEDIDODataGridViewTextBoxColumn.DataPropertyName = "ESTATUSPEDIDO";
            this.eSTATUSPEDIDODataGridViewTextBoxColumn.HeaderText = "ESTATUS";
            this.eSTATUSPEDIDODataGridViewTextBoxColumn.Name = "eSTATUSPEDIDODataGridViewTextBoxColumn";
            // 
            // DGTRASLADOAFTP
            // 
            this.DGTRASLADOAFTP.DataPropertyName = "TRASLADOAFTP";
            this.DGTRASLADOAFTP.HeaderText = "TRASLADOAFTP";
            this.DGTRASLADOAFTP.Name = "DGTRASLADOAFTP";
            this.DGTRASLADOAFTP.Visible = false;
            // 
            // DGContinuar
            // 
            this.DGContinuar.HeaderText = "CONTINUAR";
            this.DGContinuar.Name = "DGContinuar";
            this.DGContinuar.Text = "CONTINUAR";
            this.DGContinuar.UseColumnTextForButtonValue = true;
            this.DGContinuar.Width = 75;
            // 
            // DGVer
            // 
            this.DGVer.HeaderText = "VER";
            this.DGVer.Name = "DGVer";
            this.DGVer.Text = "VER";
            this.DGVer.UseColumnTextForButtonValue = true;
            this.DGVer.Width = 75;
            // 
            // DGREENVIAR
            // 
            this.DGREENVIAR.HeaderText = "REENVIAR";
            this.DGREENVIAR.Name = "DGREENVIAR";
            this.DGREENVIAR.Text = "REENVIAR";
            this.DGREENVIAR.UseColumnTextForButtonValue = true;
            this.DGREENVIAR.Width = 75;
            // 
            // DGELIMINAR
            // 
            this.DGELIMINAR.HeaderText = "ELIMINAR";
            this.DGELIMINAR.Name = "DGELIMINAR";
            this.DGELIMINAR.ReadOnly = true;
            this.DGELIMINAR.Text = "ELIMINAR";
            this.DGELIMINAR.UseColumnTextForButtonValue = true;
            this.DGELIMINAR.Width = 75;
            // 
            // DG_EXPFILEID
            // 
            this.DG_EXPFILEID.DataPropertyName = "EXPFILEID";
            this.DG_EXPFILEID.HeaderText = "EXPFILEID";
            this.DG_EXPFILEID.Name = "DG_EXPFILEID";
            this.DG_EXPFILEID.Visible = false;
            // 
            // lISTAPEDIDOSBindingSource
            // 
            this.lISTAPEDIDOSBindingSource.DataMember = "LISTAPEDIDOS";
            this.lISTAPEDIDOSBindingSource.DataSource = this.dSImportaciones;
            // 
            // dSImportaciones
            // 
            this.dSImportaciones.DataSetName = "DSImportaciones";
            this.dSImportaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LBTIPOREG
            // 
            this.LBTIPOREG.AutoSize = true;
            this.LBTIPOREG.BackColor = System.Drawing.Color.Transparent;
            this.LBTIPOREG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTIPOREG.ForeColor = System.Drawing.Color.White;
            this.LBTIPOREG.Location = new System.Drawing.Point(119, 7);
            this.LBTIPOREG.Name = "LBTIPOREG";
            this.LBTIPOREG.Size = new System.Drawing.Size(100, 13);
            this.LBTIPOREG.TabIndex = 9;
            this.LBTIPOREG.Text = "Tipo de registro:";
            // 
            // CBTipo
            // 
            this.CBTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTipo.FormattingEnabled = true;
            this.CBTipo.Items.AddRange(new object[] {
            "POR FECHAS",
            "POR STOCK",
            "TODOS"});
            this.CBTipo.Location = new System.Drawing.Point(225, 3);
            this.CBTipo.Name = "CBTipo";
            this.CBTipo.Size = new System.Drawing.Size(231, 21);
            this.CBTipo.TabIndex = 10;
            this.CBTipo.SelectedIndexChanged += new System.EventHandler(this.CBTipo_SelectedIndexChanged);
            // 
            // CBCorteActual
            // 
            this.CBCorteActual.AutoSize = true;
            this.CBCorteActual.Checked = true;
            this.CBCorteActual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBCorteActual.Location = new System.Drawing.Point(90, 7);
            this.CBCorteActual.Name = "CBCorteActual";
            this.CBCorteActual.Size = new System.Drawing.Size(15, 14);
            this.CBCorteActual.TabIndex = 13;
            this.CBCorteActual.UseVisualStyleBackColor = true;
            this.CBCorteActual.CheckedChanged += new System.EventHandler(this.CBCorteActual_CheckedChanged);
            // 
            // CBCajerosTodos
            // 
            this.CBCajerosTodos.AutoSize = true;
            this.CBCajerosTodos.BackColor = System.Drawing.Color.Transparent;
            this.CBCajerosTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBCajerosTodos.ForeColor = System.Drawing.Color.White;
            this.CBCajerosTodos.Location = new System.Drawing.Point(254, 4);
            this.CBCajerosTodos.Name = "CBCajerosTodos";
            this.CBCajerosTodos.Size = new System.Drawing.Size(126, 17);
            this.CBCajerosTodos.TabIndex = 17;
            this.CBCajerosTodos.Text = "Todos los cajeros";
            this.CBCajerosTodos.UseVisualStyleBackColor = false;
            this.CBCajerosTodos.CheckedChanged += new System.EventHandler(this.CBCajerosTodos_CheckedChanged);
            // 
            // VENDEDORButton
            // 
            this.VENDEDORButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.VENDEDORButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VENDEDORButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VENDEDORButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.VENDEDORButton.Location = new System.Drawing.Point(137, 0);
            this.VENDEDORButton.Name = "VENDEDORButton";
            this.VENDEDORButton.Size = new System.Drawing.Size(21, 23);
            this.VENDEDORButton.TabIndex = 16;
            this.VENDEDORButton.UseVisualStyleBackColor = true;
            // 
            // VENDEDORLabel
            // 
            this.VENDEDORLabel.AutoSize = true;
            this.VENDEDORLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VENDEDORLabel.ForeColor = System.Drawing.Color.White;
            this.VENDEDORLabel.Location = new System.Drawing.Point(164, 9);
            this.VENDEDORLabel.Name = "VENDEDORLabel";
            this.VENDEDORLabel.Size = new System.Drawing.Size(19, 13);
            this.VENDEDORLabel.TabIndex = 160;
            this.VENDEDORLabel.Text = "...";
            // 
            // pnlCajero
            // 
            this.pnlCajero.BackColor = System.Drawing.Color.Transparent;
            this.pnlCajero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCajero.Controls.Add(this.label2);
            this.pnlCajero.Controls.Add(this.VENDEDORLabel);
            this.pnlCajero.Controls.Add(this.VENDEDORButton);
            this.pnlCajero.Controls.Add(this.CBCajerosTodos);
            this.pnlCajero.Controls.Add(this.VENDEDORIDTextBox);
            this.pnlCajero.Location = new System.Drawing.Point(531, 0);
            this.pnlCajero.Name = "pnlCajero";
            this.pnlCajero.Size = new System.Drawing.Size(389, 26);
            this.pnlCajero.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 162;
            this.label2.Text = "Cajero:";
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
            this.VENDEDORIDTextBox.Location = new System.Drawing.Point(49, 3);
            this.VENDEDORIDTextBox.MostrarErrores = true;
            this.VENDEDORIDTextBox.Name = "VENDEDORIDTextBox";
            this.VENDEDORIDTextBox.NombreCampoSelector = "clave";
            this.VENDEDORIDTextBox.NombreCampoValue = "id";
            this.VENDEDORIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid in (12,13,20,21)";
            this.VENDEDORIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid in (12,13,20,21) and  cla" +
    "ve= @clave";
            this.VENDEDORIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid in (12,13,20,21) and  id " +
    "= @id";
            this.VENDEDORIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.VENDEDORIDTextBox.TabIndex = 15;
            this.VENDEDORIDTextBox.Tag = 34;
            this.VENDEDORIDTextBox.TextDescription = null;
            this.VENDEDORIDTextBox.Titulo = "Usuarios";
            this.VENDEDORIDTextBox.ValidarEntrada = true;
            this.VENDEDORIDTextBox.ValidationExpression = null;
            this.VENDEDORIDTextBox.Validated += new System.EventHandler(this.VENDEDORIDTextBox_Validated);
            // 
            // DTPFecha
            // 
            this.DTPFecha.Location = new System.Drawing.Point(148, 1);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(231, 20);
            this.DTPFecha.TabIndex = 15;
            this.DTPFecha.ValueChanged += new System.EventHandler(this.DTPFecha_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(26, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Fecha elaboracion:";
            // 
            // pnlCorteActual
            // 
            this.pnlCorteActual.BackColor = System.Drawing.Color.Transparent;
            this.pnlCorteActual.Controls.Add(this.label4);
            this.pnlCorteActual.Controls.Add(this.CBCorteActual);
            this.pnlCorteActual.Location = new System.Drawing.Point(90, 26);
            this.pnlCorteActual.Name = "pnlCorteActual";
            this.pnlCorteActual.Size = new System.Drawing.Size(113, 29);
            this.pnlCorteActual.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Corte Actual:";
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "CAJAID";
            this.dataGridViewTextBoxColumn12.HeaderText = "CAJAID";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            this.dataGridViewTextBoxColumn12.Width = 75;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "TURNOID";
            this.dataGridViewTextBoxColumn13.HeaderText = "TURNOID";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ESTATUSDOCTOID";
            this.dataGridViewTextBoxColumn14.HeaderText = "ESTATUSDOCTOID";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "REFERENCIA";
            this.dataGridViewTextBoxColumn15.HeaderText = "REFERENCIA";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "SUCURSALDESTINO";
            this.dataGridViewTextBoxColumn16.HeaderText = "Suc. dest.(clave)";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "SUCURSALDESTINONOMBRE";
            this.dataGridViewTextBoxColumn17.HeaderText = "Suc. dest.(nombre)";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "TRANREGSERVER";
            this.dataGridViewTextBoxColumn18.HeaderText = "Registrado(traslados)";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.CBFechaElaboracion);
            this.panel1.Controls.Add(this.DTPFecha);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(532, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 26);
            this.panel1.TabIndex = 19;
            // 
            // CBFechaElaboracion
            // 
            this.CBFechaElaboracion.AutoSize = true;
            this.CBFechaElaboracion.Location = new System.Drawing.Point(5, 3);
            this.CBFechaElaboracion.Name = "CBFechaElaboracion";
            this.CBFechaElaboracion.Size = new System.Drawing.Size(15, 14);
            this.CBFechaElaboracion.TabIndex = 18;
            this.CBFechaElaboracion.UseVisualStyleBackColor = true;
            this.CBFechaElaboracion.CheckedChanged += new System.EventHandler(this.CBFechaElaboracion_CheckedChanged);
            // 
            // lISTAPEDIDOSTableAdapter
            // 
            this.lISTAPEDIDOSTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(226, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Estatus:";
            // 
            // CBEstatus
            // 
            this.CBEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBEstatus.FormattingEnabled = true;
            this.CBEstatus.Items.AddRange(new object[] {
            "PENDIENTE",
            "ENVIADO",
            "EN PROCESO DE ENVIO",
            "TODOS"});
            this.CBEstatus.Location = new System.Drawing.Point(285, 28);
            this.CBEstatus.Name = "CBEstatus";
            this.CBEstatus.Size = new System.Drawing.Size(171, 21);
            this.CBEstatus.TabIndex = 21;
            this.CBEstatus.SelectedIndexChanged += new System.EventHandler(this.CBEstatus_SelectedIndexChanged);
            // 
            // WFListaPedidosExportacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(985, 439);
            this.Controls.Add(this.CBEstatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlCorteActual);
            this.Controls.Add(this.pnlCajero);
            this.Controls.Add(this.vENTASLISTADataGridView);
            this.Controls.Add(this.CBTipo);
            this.Controls.Add(this.LBTIPOREG);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFListaPedidosExportacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Lista de pedidos";
            this.Load += new System.EventHandler(this.WFListaPedidosExportacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vENTASLISTADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lISTAPEDIDOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).EndInit();
            this.pnlCajero.ResumeLayout(false);
            this.pnlCajero.PerformLayout();
            this.pnlCorteActual.ResumeLayout(false);
            this.pnlCorteActual.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum vENTASLISTADataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.Label LBTIPOREG;
        private System.Windows.Forms.ComboBox CBTipo;
        private System.Windows.Forms.CheckBox CBCorteActual;
        private System.Windows.Forms.CheckBox CBCajerosTodos;
        private System.Windows.Forms.Button VENDEDORButton;
        private Tools.TextBoxFB VENDEDORIDTextBox;
        private System.Windows.Forms.Label VENDEDORLabel;
        private System.Windows.Forms.Panel pnlCajero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlCorteActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox CBFechaElaboracion;
        private System.Windows.Forms.BindingSource lISTAPEDIDOSBindingSource;
        private Importaciones.DSImportaciones dSImportaciones;
        private Importaciones.DSImportacionesTableAdapters.LISTAPEDIDOSTableAdapter lISTAPEDIDOSTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBEstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fOLIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOMBREDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFECHAINI;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFECHAFIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn cORTEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vENDEDORIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOMBRECAJERODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eSTATUSPEDIDODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGTRASLADOAFTP;
        private System.Windows.Forms.DataGridViewButtonColumn DGContinuar;
        private System.Windows.Forms.DataGridViewButtonColumn DGVer;
        private System.Windows.Forms.DataGridViewButtonColumn DGREENVIAR;
        private System.Windows.Forms.DataGridViewButtonColumn DGELIMINAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_EXPFILEID;
        private System.Windows.Forms.Label label4;
    }
}