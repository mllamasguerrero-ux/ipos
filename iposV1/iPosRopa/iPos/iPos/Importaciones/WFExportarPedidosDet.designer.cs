namespace iPos
{
    partial class WFExportarPedidosDet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFExportarPedidosDet));
            this.iMP_REC_DETDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.GC_DOCTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GC_MOVTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GC_REFERENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOCALIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GC_PARTIDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GC_PRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANAQUEL_LOCALIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANAQUEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOCALIDADREAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GC_DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GC_LOTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GC_CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GC_APEDIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCAJAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPIEZAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GC_CANTIDADFALTANTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGC_RAZONDIFINVID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGC_RAZONDIFINVTEXT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GC_EXISTENCIAREMOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPZACAJA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pEDIRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSImportaciones = new iPos.Importaciones.DSImportaciones();
            this.BTRECIBIR = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBObservaciones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBCantidad = new System.Windows.Forms.NumericTextBox();
            this.BTAgregar = new System.Windows.Forms.Button();
            this.lblPiezas = new System.Windows.Forms.Label();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBLocalidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LBProductoDescripcion = new System.Windows.Forms.Label();
            this.pnlAdicion = new System.Windows.Forms.Panel();
            this.lblCaja = new System.Windows.Forms.Label();
            this.TBCajas = new System.Windows.Forms.NumericTextBox();
            this.btnObtenerExitenciaRemota = new System.Windows.Forms.Button();
            this.lblEsperandoExisRemota = new System.Windows.Forms.Label();
            this.bgExistenciaRemota = new System.ComponentModel.BackgroundWorker();
            this.pEDIRTableAdapter = new iPos.Importaciones.DSImportacionesTableAdapters.PEDIRTableAdapter();
            this.btnReenviar = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iMP_REC_DETDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pEDIRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).BeginInit();
            this.pnlAdicion.SuspendLayout();
            this.SuspendLayout();
            // 
            // iMP_REC_DETDataGridView
            // 
            this.iMP_REC_DETDataGridView.AllowUserToAddRows = false;
            this.iMP_REC_DETDataGridView.AutoGenerateColumns = false;
            this.iMP_REC_DETDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.iMP_REC_DETDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.iMP_REC_DETDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iMP_REC_DETDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GC_DOCTOID,
            this.GC_MOVTOID,
            this.GC_REFERENCIA,
            this.LOCALIDAD,
            this.GC_PARTIDA,
            this.GC_PRODUCTO,
            this.ANAQUEL_LOCALIDAD,
            this.ANAQUEL,
            this.LOCALIDADREAL,
            this.GC_DESCRIPCION,
            this.GC_LOTE,
            this.GC_CANTIDAD,
            this.GC_APEDIR,
            this.DGCAJAS,
            this.DGPIEZAS,
            this.GC_CANTIDADFALTANTE,
            this.DGC_RAZONDIFINVID,
            this.DGC_RAZONDIFINVTEXT,
            this.GC_EXISTENCIAREMOTA,
            this.DGPZACAJA});
            this.iMP_REC_DETDataGridView.DataSource = this.pEDIRBindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iMP_REC_DETDataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.iMP_REC_DETDataGridView.EnableHeadersVisualStyles = false;
            this.iMP_REC_DETDataGridView.Location = new System.Drawing.Point(3, 25);
            this.iMP_REC_DETDataGridView.Name = "iMP_REC_DETDataGridView";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.iMP_REC_DETDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.iMP_REC_DETDataGridView.RowHeadersVisible = false;
            this.iMP_REC_DETDataGridView.Size = new System.Drawing.Size(857, 359);
            this.iMP_REC_DETDataGridView.TabIndex = 2;
            this.iMP_REC_DETDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.iMP_REC_DETDataGridView_CellValidating);
            this.iMP_REC_DETDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.iMP_REC_DETDataGridView_DataError);
            this.iMP_REC_DETDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.iMP_REC_DETDataGridView_RowsAdded_1);
            // 
            // GC_DOCTOID
            // 
            this.GC_DOCTOID.DataPropertyName = "DOCTOID";
            this.GC_DOCTOID.HeaderText = "DOCTOID";
            this.GC_DOCTOID.Name = "GC_DOCTOID";
            this.GC_DOCTOID.ReadOnly = true;
            this.GC_DOCTOID.Visible = false;
            // 
            // GC_MOVTOID
            // 
            this.GC_MOVTOID.DataPropertyName = "MOVTOID";
            this.GC_MOVTOID.HeaderText = "MOVTOID";
            this.GC_MOVTOID.Name = "GC_MOVTOID";
            this.GC_MOVTOID.ReadOnly = true;
            this.GC_MOVTOID.Visible = false;
            // 
            // GC_REFERENCIA
            // 
            this.GC_REFERENCIA.DataPropertyName = "REFERENCIA";
            this.GC_REFERENCIA.HeaderText = "REFERENCIA";
            this.GC_REFERENCIA.Name = "GC_REFERENCIA";
            this.GC_REFERENCIA.ReadOnly = true;
            // 
            // LOCALIDAD
            // 
            this.LOCALIDAD.DataPropertyName = "LOCALIDAD";
            this.LOCALIDAD.HeaderText = "LOCALIDAD";
            this.LOCALIDAD.Name = "LOCALIDAD";
            this.LOCALIDAD.Visible = false;
            // 
            // GC_PARTIDA
            // 
            this.GC_PARTIDA.DataPropertyName = "PARTIDA";
            this.GC_PARTIDA.HeaderText = "PARTIDA";
            this.GC_PARTIDA.Name = "GC_PARTIDA";
            this.GC_PARTIDA.ReadOnly = true;
            this.GC_PARTIDA.Visible = false;
            // 
            // GC_PRODUCTO
            // 
            this.GC_PRODUCTO.DataPropertyName = "PRODUCTO";
            this.GC_PRODUCTO.HeaderText = "PRODUCTO";
            this.GC_PRODUCTO.Name = "GC_PRODUCTO";
            this.GC_PRODUCTO.ReadOnly = true;
            this.GC_PRODUCTO.Width = 125;
            // 
            // ANAQUEL_LOCALIDAD
            // 
            this.ANAQUEL_LOCALIDAD.DataPropertyName = "ANAQUEL_LOCALIDAD";
            this.ANAQUEL_LOCALIDAD.HeaderText = "ANAQ. LOC.";
            this.ANAQUEL_LOCALIDAD.Name = "ANAQUEL_LOCALIDAD";
            this.ANAQUEL_LOCALIDAD.ReadOnly = true;
            // 
            // ANAQUEL
            // 
            this.ANAQUEL.DataPropertyName = "ANAQUEL";
            this.ANAQUEL.HeaderText = "ANAQUEL";
            this.ANAQUEL.Name = "ANAQUEL";
            this.ANAQUEL.ReadOnly = true;
            this.ANAQUEL.Visible = false;
            this.ANAQUEL.Width = 70;
            // 
            // LOCALIDADREAL
            // 
            this.LOCALIDADREAL.DataPropertyName = "LOCALIDADREAL";
            this.LOCALIDADREAL.HeaderText = "LOCALIDAD";
            this.LOCALIDADREAL.Name = "LOCALIDADREAL";
            this.LOCALIDADREAL.ReadOnly = true;
            this.LOCALIDADREAL.Visible = false;
            this.LOCALIDADREAL.Width = 80;
            // 
            // GC_DESCRIPCION
            // 
            this.GC_DESCRIPCION.DataPropertyName = "DESCRIPCION";
            this.GC_DESCRIPCION.HeaderText = "DESCRIPCION";
            this.GC_DESCRIPCION.Name = "GC_DESCRIPCION";
            this.GC_DESCRIPCION.ReadOnly = true;
            this.GC_DESCRIPCION.Width = 200;
            // 
            // GC_LOTE
            // 
            this.GC_LOTE.DataPropertyName = "LOTE";
            this.GC_LOTE.HeaderText = "LOTE";
            this.GC_LOTE.Name = "GC_LOTE";
            this.GC_LOTE.ReadOnly = true;
            this.GC_LOTE.Visible = false;
            // 
            // GC_CANTIDAD
            // 
            this.GC_CANTIDAD.DataPropertyName = "CANTIDAD";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.GC_CANTIDAD.DefaultCellStyle = dataGridViewCellStyle2;
            this.GC_CANTIDAD.HeaderText = "CANTIDAD";
            this.GC_CANTIDAD.Name = "GC_CANTIDAD";
            this.GC_CANTIDAD.ReadOnly = true;
            this.GC_CANTIDAD.Width = 85;
            // 
            // GC_APEDIR
            // 
            this.GC_APEDIR.DataPropertyName = "CANTIDADSURTIDA";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.GC_APEDIR.DefaultCellStyle = dataGridViewCellStyle3;
            this.GC_APEDIR.HeaderText = "A PEDIR";
            this.GC_APEDIR.Name = "GC_APEDIR";
            this.GC_APEDIR.Width = 85;
            // 
            // DGCAJAS
            // 
            this.DGCAJAS.DataPropertyName = "CAJAS";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Format = "N2";
            this.DGCAJAS.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGCAJAS.HeaderText = "CAJAS PEDIR";
            this.DGCAJAS.Name = "DGCAJAS";
            this.DGCAJAS.Width = 70;
            // 
            // DGPIEZAS
            // 
            this.DGPIEZAS.DataPropertyName = "PIEZAS";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Format = "N2";
            this.DGPIEZAS.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGPIEZAS.HeaderText = "PIEZAS PEDIR";
            this.DGPIEZAS.Name = "DGPIEZAS";
            this.DGPIEZAS.Width = 80;
            // 
            // GC_CANTIDADFALTANTE
            // 
            this.GC_CANTIDADFALTANTE.DataPropertyName = "CANTIDADFALTANTE";
            this.GC_CANTIDADFALTANTE.HeaderText = "CANTIDADFALTANTE";
            this.GC_CANTIDADFALTANTE.Name = "GC_CANTIDADFALTANTE";
            this.GC_CANTIDADFALTANTE.ReadOnly = true;
            this.GC_CANTIDADFALTANTE.Visible = false;
            // 
            // DGC_RAZONDIFINVID
            // 
            this.DGC_RAZONDIFINVID.HeaderText = "RAZONDIFINV";
            this.DGC_RAZONDIFINVID.Name = "DGC_RAZONDIFINVID";
            this.DGC_RAZONDIFINVID.ReadOnly = true;
            this.DGC_RAZONDIFINVID.Visible = false;
            // 
            // DGC_RAZONDIFINVTEXT
            // 
            this.DGC_RAZONDIFINVTEXT.HeaderText = "RAZON DIF.";
            this.DGC_RAZONDIFINVTEXT.Name = "DGC_RAZONDIFINVTEXT";
            this.DGC_RAZONDIFINVTEXT.ReadOnly = true;
            this.DGC_RAZONDIFINVTEXT.Visible = false;
            this.DGC_RAZONDIFINVTEXT.Width = 150;
            // 
            // GC_EXISTENCIAREMOTA
            // 
            this.GC_EXISTENCIAREMOTA.DataPropertyName = "EXISTENCIAREMOTA";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.GC_EXISTENCIAREMOTA.DefaultCellStyle = dataGridViewCellStyle6;
            this.GC_EXISTENCIAREMOTA.HeaderText = "EXIST. REMOTA";
            this.GC_EXISTENCIAREMOTA.Name = "GC_EXISTENCIAREMOTA";
            this.GC_EXISTENCIAREMOTA.Width = 80;
            // 
            // DGPZACAJA
            // 
            this.DGPZACAJA.DataPropertyName = "PZACAJA";
            this.DGPZACAJA.HeaderText = "PZACAJA";
            this.DGPZACAJA.Name = "DGPZACAJA";
            this.DGPZACAJA.ReadOnly = true;
            this.DGPZACAJA.Visible = false;
            // 
            // pEDIRBindingSource
            // 
            this.pEDIRBindingSource.DataMember = "PEDIR";
            this.pEDIRBindingSource.DataSource = this.dSImportaciones;
            // 
            // dSImportaciones
            // 
            this.dSImportaciones.DataSetName = "DSImportaciones";
            this.dSImportaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BTRECIBIR
            // 
            this.BTRECIBIR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTRECIBIR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTRECIBIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTRECIBIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTRECIBIR.ForeColor = System.Drawing.Color.White;
            this.BTRECIBIR.Location = new System.Drawing.Point(251, 547);
            this.BTRECIBIR.Name = "BTRECIBIR";
            this.BTRECIBIR.Size = new System.Drawing.Size(75, 27);
            this.BTRECIBIR.TabIndex = 10;
            this.BTRECIBIR.Text = "Pedir";
            this.BTRECIBIR.UseVisualStyleBackColor = false;
            this.BTRECIBIR.Click += new System.EventHandler(this.BTRECIBIR_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Teclea la cantidad pedida";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IR_PRODUCTO";
            this.dataGridViewTextBoxColumn1.HeaderText = "IR_PRODUCTO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MOVTOID";
            this.dataGridViewTextBoxColumn2.HeaderText = "MOVTOID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "REFERENCIA";
            this.dataGridViewTextBoxColumn3.HeaderText = "REFERENCIA";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PARTIDA";
            this.dataGridViewTextBoxColumn4.HeaderText = "PARTIDA";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "IR_PRODUCTO";
            this.dataGridViewTextBoxColumn5.HeaderText = "IR_PRODUCTO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "IR_CANTIDAD";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn6.HeaderText = "IR_CANTIDAD";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "RECIBIDOS";
            this.dataGridViewTextBoxColumn7.HeaderText = "RECIBIDOS";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "RESTANTES";
            this.dataGridViewTextBoxColumn8.HeaderText = "RESTANTES";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "A_RECIBIR";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn9.HeaderText = "A_RECIBIR";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "A_RECIBIR";
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn10.HeaderText = "A_RECIBIR";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "IR_ID_FECHA";
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn11.HeaderText = "IR_ID_FECHA";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "IR_ID_HORA";
            this.dataGridViewTextBoxColumn12.HeaderText = "IR_ID_HORA";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            this.dataGridViewTextBoxColumn12.Width = 150;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "IR_FILE";
            this.dataGridViewTextBoxColumn13.HeaderText = "IR_FILE";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "A_RECIBIR";
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn14.HeaderText = "A_RECIBIR";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // TBObservaciones
            // 
            this.TBObservaciones.Location = new System.Drawing.Point(9, 105);
            this.TBObservaciones.Multiline = true;
            this.TBObservaciones.Name = "TBObservaciones";
            this.TBObservaciones.Size = new System.Drawing.Size(517, 40);
            this.TBObservaciones.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Observaciones";
            // 
            // TBCantidad
            // 
            this.TBCantidad.AllowNegative = true;
            this.TBCantidad.Format_Expression = null;
            this.TBCantidad.Location = new System.Drawing.Point(360, 21);
            this.TBCantidad.Name = "TBCantidad";
            this.TBCantidad.NumericPrecision = 12;
            this.TBCantidad.NumericScaleOnFocus = 2;
            this.TBCantidad.NumericScaleOnLostFocus = 2;
            this.TBCantidad.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBCantidad.Size = new System.Drawing.Size(100, 20);
            this.TBCantidad.TabIndex = 7;
            this.TBCantidad.Tag = 34;
            this.TBCantidad.Text = "0";
            this.TBCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBCantidad.ValidationExpression = null;
            this.TBCantidad.ZeroIsValid = true;
            this.TBCantidad.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBCantidad_PreviewKeyDown);
            // 
            // BTAgregar
            // 
            this.BTAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTAgregar.ForeColor = System.Drawing.Color.White;
            this.BTAgregar.Location = new System.Drawing.Point(525, 19);
            this.BTAgregar.Name = "BTAgregar";
            this.BTAgregar.Size = new System.Drawing.Size(75, 23);
            this.BTAgregar.TabIndex = 8;
            this.BTAgregar.Text = "Agregar";
            this.BTAgregar.UseVisualStyleBackColor = false;
            this.BTAgregar.Click += new System.EventHandler(this.BTAgregar_Click);
            // 
            // lblPiezas
            // 
            this.lblPiezas.AutoSize = true;
            this.lblPiezas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPiezas.ForeColor = System.Drawing.Color.White;
            this.lblPiezas.Location = new System.Drawing.Point(357, 6);
            this.lblPiezas.Name = "lblPiezas";
            this.lblPiezas.Size = new System.Drawing.Size(93, 13);
            this.lblPiezas.TabIndex = 14;
            this.lblPiezas.Text = "Cantidad/pzas:";
            // 
            // TBCodigo
            // 
            this.TBCodigo.Location = new System.Drawing.Point(10, 22);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(100, 20);
            this.TBCodigo.TabIndex = 4;
            this.TBCodigo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBCodigo_PreviewKeyDown);
            this.TBCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.TBCodigo_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Codigo:";
            // 
            // TBLocalidad
            // 
            this.TBLocalidad.Location = new System.Drawing.Point(137, 22);
            this.TBLocalidad.Name = "TBLocalidad";
            this.TBLocalidad.Size = new System.Drawing.Size(75, 20);
            this.TBLocalidad.TabIndex = 5;
            this.TBLocalidad.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBLocalidad_PreviewKeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(134, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Anaq. Loc. :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Descripción:";
            // 
            // LBProductoDescripcion
            // 
            this.LBProductoDescripcion.AutoSize = true;
            this.LBProductoDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBProductoDescripcion.ForeColor = System.Drawing.Color.White;
            this.LBProductoDescripcion.Location = new System.Drawing.Point(90, 67);
            this.LBProductoDescripcion.Name = "LBProductoDescripcion";
            this.LBProductoDescripcion.Size = new System.Drawing.Size(19, 13);
            this.LBProductoDescripcion.TabIndex = 18;
            this.LBProductoDescripcion.Text = "...";
            // 
            // pnlAdicion
            // 
            this.pnlAdicion.BackColor = System.Drawing.Color.Transparent;
            this.pnlAdicion.Controls.Add(this.btnExcel);
            this.pnlAdicion.Controls.Add(this.lblCaja);
            this.pnlAdicion.Controls.Add(this.TBCajas);
            this.pnlAdicion.Controls.Add(this.label4);
            this.pnlAdicion.Controls.Add(this.LBProductoDescripcion);
            this.pnlAdicion.Controls.Add(this.TBObservaciones);
            this.pnlAdicion.Controls.Add(this.label6);
            this.pnlAdicion.Controls.Add(this.label1);
            this.pnlAdicion.Controls.Add(this.TBLocalidad);
            this.pnlAdicion.Controls.Add(this.TBCodigo);
            this.pnlAdicion.Controls.Add(this.label5);
            this.pnlAdicion.Controls.Add(this.lblPiezas);
            this.pnlAdicion.Controls.Add(this.TBCantidad);
            this.pnlAdicion.Controls.Add(this.BTAgregar);
            this.pnlAdicion.Location = new System.Drawing.Point(12, 386);
            this.pnlAdicion.Name = "pnlAdicion";
            this.pnlAdicion.Size = new System.Drawing.Size(837, 149);
            this.pnlAdicion.TabIndex = 19;
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaja.ForeColor = System.Drawing.Color.White;
            this.lblCaja.Location = new System.Drawing.Point(236, 6);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(42, 13);
            this.lblCaja.TabIndex = 20;
            this.lblCaja.Text = "Cajas:";
            // 
            // TBCajas
            // 
            this.TBCajas.AllowNegative = true;
            this.TBCajas.Format_Expression = null;
            this.TBCajas.Location = new System.Drawing.Point(239, 21);
            this.TBCajas.Name = "TBCajas";
            this.TBCajas.NumericPrecision = 12;
            this.TBCajas.NumericScaleOnFocus = 2;
            this.TBCajas.NumericScaleOnLostFocus = 2;
            this.TBCajas.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBCajas.Size = new System.Drawing.Size(100, 20);
            this.TBCajas.TabIndex = 6;
            this.TBCajas.Tag = 34;
            this.TBCajas.Text = "0";
            this.TBCajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBCajas.ValidationExpression = null;
            this.TBCajas.ZeroIsValid = true;
            // 
            // btnObtenerExitenciaRemota
            // 
            this.btnObtenerExitenciaRemota.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnObtenerExitenciaRemota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObtenerExitenciaRemota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObtenerExitenciaRemota.ForeColor = System.Drawing.Color.White;
            this.btnObtenerExitenciaRemota.Location = new System.Drawing.Point(722, 541);
            this.btnObtenerExitenciaRemota.Name = "btnObtenerExitenciaRemota";
            this.btnObtenerExitenciaRemota.Size = new System.Drawing.Size(127, 39);
            this.btnObtenerExitenciaRemota.TabIndex = 20;
            this.btnObtenerExitenciaRemota.Text = "Obtener exist. remota";
            this.btnObtenerExitenciaRemota.UseVisualStyleBackColor = false;
            this.btnObtenerExitenciaRemota.Click += new System.EventHandler(this.btnObtenerExitenciaRemota_Click);
            // 
            // lblEsperandoExisRemota
            // 
            this.lblEsperandoExisRemota.AutoSize = true;
            this.lblEsperandoExisRemota.BackColor = System.Drawing.Color.Transparent;
            this.lblEsperandoExisRemota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEsperandoExisRemota.ForeColor = System.Drawing.Color.White;
            this.lblEsperandoExisRemota.Location = new System.Drawing.Point(632, 567);
            this.lblEsperandoExisRemota.Name = "lblEsperandoExisRemota";
            this.lblEsperandoExisRemota.Size = new System.Drawing.Size(32, 16);
            this.lblEsperandoExisRemota.TabIndex = 21;
            this.lblEsperandoExisRemota.Text = "___";
            // 
            // bgExistenciaRemota
            // 
            this.bgExistenciaRemota.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgExistenciaRemota_DoWork);
            this.bgExistenciaRemota.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgExistenciaRemota_RunWorkerCompleted);
            // 
            // pEDIRTableAdapter
            // 
            this.pEDIRTableAdapter.ClearBeforeFill = true;
            // 
            // btnReenviar
            // 
            this.btnReenviar.BackColor = System.Drawing.Color.Gray;
            this.btnReenviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnReenviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReenviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReenviar.ForeColor = System.Drawing.Color.White;
            this.btnReenviar.Location = new System.Drawing.Point(397, 547);
            this.btnReenviar.Name = "btnReenviar";
            this.btnReenviar.Size = new System.Drawing.Size(102, 27);
            this.btnReenviar.TabIndex = 22;
            this.btnReenviar.Text = "Reenviar";
            this.btnReenviar.UseVisualStyleBackColor = false;
            this.btnReenviar.Visible = false;
            this.btnReenviar.Click += new System.EventHandler(this.btnReenviar_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(658, 19);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(163, 23);
            this.btnExcel.TabIndex = 21;
            this.btnExcel.Text = "Cargar desde excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // WFExportarPedidosDet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(861, 592);
            this.Controls.Add(this.btnReenviar);
            this.Controls.Add(this.lblEsperandoExisRemota);
            this.Controls.Add(this.btnObtenerExitenciaRemota);
            this.Controls.Add(this.pnlAdicion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTRECIBIR);
            this.Controls.Add(this.iMP_REC_DETDataGridView);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "WFExportarPedidosDet";
            this.Text = "Exportación de pedidos";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.WFExportarPedidosDet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iMP_REC_DETDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pEDIRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).EndInit();
            this.pnlAdicion.ResumeLayout(false);
            this.pnlAdicion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.DataGridViewSum iMP_REC_DETDataGridView;
        private System.Windows.Forms.Button BTRECIBIR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Label label2;
        //private Skinner.FormSkin formSkin1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.BindingSource pEDIRBindingSource;
        private iPos.Importaciones.DSImportaciones dSImportaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox TBObservaciones;
        private System.Windows.Forms.Label label1;
        private Importaciones.DSImportacionesTableAdapters.PEDIRTableAdapter pEDIRTableAdapter;
        private System.Windows.Forms.NumericTextBox TBCantidad;
        private System.Windows.Forms.Button BTAgregar;
        private System.Windows.Forms.Label lblPiezas;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBLocalidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LBProductoDescripcion;
        private System.Windows.Forms.Panel pnlAdicion;
        private System.Windows.Forms.Button btnObtenerExitenciaRemota;
        private System.Windows.Forms.Label lblEsperandoExisRemota;
        private System.ComponentModel.BackgroundWorker bgExistenciaRemota;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.NumericTextBox TBCajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn GC_DOCTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GC_MOVTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GC_REFERENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOCALIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn GC_PARTIDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn GC_PRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANAQUEL_LOCALIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANAQUEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOCALIDADREAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn GC_DESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn GC_LOTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GC_CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn GC_APEDIR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCAJAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPIEZAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn GC_CANTIDADFALTANTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGC_RAZONDIFINVID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGC_RAZONDIFINVTEXT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GC_EXISTENCIAREMOTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPZACAJA;
        private System.Windows.Forms.Button btnReenviar;
        private System.Windows.Forms.Button btnExcel;
    }
}