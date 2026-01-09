namespace iPos
{
    partial class WFReasignaLote
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFReasignaLote));
            this.gridLotesDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.pRODUCTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_LOTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_FECHAVENCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CADUCADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PORCADUCAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDADENDOCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASURTIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGSURTIBLE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGCANTSURTIBLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLotesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dSPuntoDeVentaAux = new iPos.Inventario.DSInventarioFisico3();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTPaymentSave = new System.Windows.Forms.Button();
            this.gridLotesTableAdapter1 = new iPos.Inventario.DSInventarioFisico3TableAdapters.GridLotesTableAdapter();
            this.tableAdapterManager = new iPos.Inventario.DSInventarioFisico3TableAdapters.TableAdapterManager();
            this.BTIntercambioLotes = new System.Windows.Forms.Button();
            this.pnlLotes = new System.Windows.Forms.GroupBox();
            this.DTPFechaVence = new System.Windows.Forms.DateTimePicker();
            this.TBLote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregarAListaDeLotes = new System.Windows.Forms.Button();
            this.comboLoteDestino = new System.Windows.Forms.ComboBox();
            this.r_LISTALOTESINVENTARIOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSInventarioFisico2 = new iPos.Inventario.DSInventarioFisico2();
            this.RBManualLote = new System.Windows.Forms.RadioButton();
            this.RBSeleccionLote = new System.Windows.Forms.RadioButton();
            this.r_LISTALOTESINVENTARIOTableAdapter = new iPos.Inventario.DSInventarioFisico2TableAdapters.R_LISTALOTESINVENTARIOTableAdapter();
            this.tableAdapterManager1 = new iPos.Inventario.DSInventarioFisico2TableAdapters.TableAdapterManager();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBIntercambio = new System.Windows.Forms.RadioButton();
            this.RBReasignacion = new System.Windows.Forms.RadioButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridLotesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLotesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux)).BeginInit();
            this.pnlLotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.r_LISTALOTESINVENTARIOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico2)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridLotesDataGridView
            // 
            this.gridLotesDataGridView.AllowUserToAddRows = false;
            this.gridLotesDataGridView.AutoGenerateColumns = false;
            this.gridLotesDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLotesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLotesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLotesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pRODUCTODataGridViewTextBoxColumn,
            this.DG_LOTE,
            this.DG_CANTIDAD,
            this.DG_FECHAVENCE,
            this.CADUCADO,
            this.PORCADUCAR,
            this.CANTIDADENDOCTO,
            this.ASURTIR,
            this.DGSURTIBLE,
            this.DGCANTSURTIBLE});
            this.gridLotesDataGridView.DataSource = this.gridLotesBindingSource1;
            this.gridLotesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLotesDataGridView.EnableHeadersVisualStyles = false;
            this.gridLotesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.gridLotesDataGridView.Name = "gridLotesDataGridView";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLotesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridLotesDataGridView.RowHeadersVisible = false;
            this.gridLotesDataGridView.Size = new System.Drawing.Size(851, 238);
            this.gridLotesDataGridView.TabIndex = 5;
            this.gridLotesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLotesDataGridView_CellClick);
            this.gridLotesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridLotesDataGridView_CellFormatting);
            this.gridLotesDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridLotesDataGridView_CellValidating);
            this.gridLotesDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridLotesDataGridView_KeyPress);
            this.gridLotesDataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.gridLotesDataGridView_PreviewKeyDown);
            // 
            // pRODUCTODataGridViewTextBoxColumn
            // 
            this.pRODUCTODataGridViewTextBoxColumn.DataPropertyName = "PRODUCTO";
            this.pRODUCTODataGridViewTextBoxColumn.HeaderText = "PRODUCTO";
            this.pRODUCTODataGridViewTextBoxColumn.Name = "pRODUCTODataGridViewTextBoxColumn";
            this.pRODUCTODataGridViewTextBoxColumn.Visible = false;
            // 
            // DG_LOTE
            // 
            this.DG_LOTE.DataPropertyName = "LOTE";
            this.DG_LOTE.HeaderText = "LOTE";
            this.DG_LOTE.Name = "DG_LOTE";
            this.DG_LOTE.ReadOnly = true;
            this.DG_LOTE.Width = 180;
            // 
            // DG_CANTIDAD
            // 
            this.DG_CANTIDAD.DataPropertyName = "CANTIDAD";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.DG_CANTIDAD.DefaultCellStyle = dataGridViewCellStyle2;
            this.DG_CANTIDAD.HeaderText = "CANTIDAD";
            this.DG_CANTIDAD.Name = "DG_CANTIDAD";
            this.DG_CANTIDAD.ReadOnly = true;
            this.DG_CANTIDAD.Width = 110;
            // 
            // DG_FECHAVENCE
            // 
            this.DG_FECHAVENCE.DataPropertyName = "FECHAVENCE";
            this.DG_FECHAVENCE.HeaderText = "FECHA VENCE";
            this.DG_FECHAVENCE.Name = "DG_FECHAVENCE";
            this.DG_FECHAVENCE.ReadOnly = true;
            this.DG_FECHAVENCE.Width = 80;
            // 
            // CADUCADO
            // 
            this.CADUCADO.DataPropertyName = "CADUCADO";
            this.CADUCADO.HeaderText = "CADUCADO";
            this.CADUCADO.Name = "CADUCADO";
            this.CADUCADO.ReadOnly = true;
            this.CADUCADO.Width = 75;
            // 
            // PORCADUCAR
            // 
            this.PORCADUCAR.DataPropertyName = "PORCADUCAR";
            this.PORCADUCAR.HeaderText = "POR CADUCAR";
            this.PORCADUCAR.Name = "PORCADUCAR";
            this.PORCADUCAR.ReadOnly = true;
            this.PORCADUCAR.Width = 75;
            // 
            // CANTIDADENDOCTO
            // 
            this.CANTIDADENDOCTO.DataPropertyName = "CANTIDADENDOCTO";
            this.CANTIDADENDOCTO.HeaderText = "CANTIDAD EN DOCTO";
            this.CANTIDADENDOCTO.Name = "CANTIDADENDOCTO";
            this.CANTIDADENDOCTO.ReadOnly = true;
            this.CANTIDADENDOCTO.Width = 90;
            // 
            // ASURTIR
            // 
            this.ASURTIR.DataPropertyName = "ASURTIR";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ASURTIR.DefaultCellStyle = dataGridViewCellStyle3;
            this.ASURTIR.HeaderText = "CANT. A TOMAR";
            this.ASURTIR.Name = "ASURTIR";
            this.ASURTIR.Width = 90;
            // 
            // DGSURTIBLE
            // 
            this.DGSURTIBLE.DataPropertyName = "SURTIBLE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.NullValue = false;
            this.DGSURTIBLE.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGSURTIBLE.FalseValue = "N";
            this.DGSURTIBLE.HeaderText = "SURT.";
            this.DGSURTIBLE.IndeterminateValue = "S";
            this.DGSURTIBLE.Name = "DGSURTIBLE";
            this.DGSURTIBLE.TrueValue = "S";
            this.DGSURTIBLE.Width = 50;
            // 
            // DGCANTSURTIBLE
            // 
            this.DGCANTSURTIBLE.DataPropertyName = "CANTSURTIBLE";
            this.DGCANTSURTIBLE.HeaderText = "MAX. SURTIBLE";
            this.DGCANTSURTIBLE.Name = "DGCANTSURTIBLE";
            this.DGCANTSURTIBLE.Width = 75;
            // 
            // gridLotesBindingSource1
            // 
            this.gridLotesBindingSource1.DataMember = "GridLotes";
            this.gridLotesBindingSource1.DataSource = this.dSPuntoDeVentaAux;
            // 
            // dSPuntoDeVentaAux
            // 
            this.dSPuntoDeVentaAux.DataSetName = "DSPuntoDeVentaAux";
            this.dSPuntoDeVentaAux.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PRODUCTO";
            this.dataGridViewTextBoxColumn1.HeaderText = "PRODUCTO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LOTE";
            this.dataGridViewTextBoxColumn2.HeaderText = "LOTE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CANTIDAD";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "CANTIDAD";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FECHAVENCE";
            this.dataGridViewTextBoxColumn4.HeaderText = "FECHAVENCE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // BTPaymentSave
            // 
            this.BTPaymentSave.BackColor = System.Drawing.Color.Transparent;
            this.BTPaymentSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTPaymentSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTPaymentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTPaymentSave.ForeColor = System.Drawing.Color.White;
            this.BTPaymentSave.Location = new System.Drawing.Point(188, 110);
            this.BTPaymentSave.Name = "BTPaymentSave";
            this.BTPaymentSave.Size = new System.Drawing.Size(141, 33);
            this.BTPaymentSave.TabIndex = 6;
            this.BTPaymentSave.Text = "Enviar";
            this.BTPaymentSave.UseVisualStyleBackColor = false;
            this.BTPaymentSave.Click += new System.EventHandler(this.BTPaymentSave_Click);
            // 
            // gridLotesTableAdapter1
            // 
            this.gridLotesTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Inventario.DSInventarioFisico3TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // BTIntercambioLotes
            // 
            this.BTIntercambioLotes.BackColor = System.Drawing.Color.Gray;
            this.BTIntercambioLotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIntercambioLotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTIntercambioLotes.ForeColor = System.Drawing.Color.White;
            this.BTIntercambioLotes.Location = new System.Drawing.Point(584, 110);
            this.BTIntercambioLotes.Name = "BTIntercambioLotes";
            this.BTIntercambioLotes.Size = new System.Drawing.Size(141, 33);
            this.BTIntercambioLotes.TabIndex = 7;
            this.BTIntercambioLotes.Text = "Intercambio lotes";
            this.BTIntercambioLotes.UseVisualStyleBackColor = false;
            this.BTIntercambioLotes.Click += new System.EventHandler(this.BTIntercambioLotes_Click);
            // 
            // pnlLotes
            // 
            this.pnlLotes.BackColor = System.Drawing.Color.Transparent;
            this.pnlLotes.Controls.Add(this.DTPFechaVence);
            this.pnlLotes.Controls.Add(this.TBLote);
            this.pnlLotes.Controls.Add(this.label3);
            this.pnlLotes.Controls.Add(this.btnAgregarAListaDeLotes);
            this.pnlLotes.Controls.Add(this.comboLoteDestino);
            this.pnlLotes.Controls.Add(this.RBManualLote);
            this.pnlLotes.Controls.Add(this.RBSeleccionLote);
            this.pnlLotes.Location = new System.Drawing.Point(3, 4);
            this.pnlLotes.Name = "pnlLotes";
            this.pnlLotes.Size = new System.Drawing.Size(836, 100);
            this.pnlLotes.TabIndex = 39;
            this.pnlLotes.TabStop = false;
            this.pnlLotes.Visible = false;
            this.pnlLotes.Enter += new System.EventHandler(this.pnlLotes_Enter);
            // 
            // DTPFechaVence
            // 
            this.DTPFechaVence.Location = new System.Drawing.Point(336, 68);
            this.DTPFechaVence.Name = "DTPFechaVence";
            this.DTPFechaVence.Size = new System.Drawing.Size(253, 20);
            this.DTPFechaVence.TabIndex = 8;
            // 
            // TBLote
            // 
            this.TBLote.Location = new System.Drawing.Point(86, 68);
            this.TBLote.Name = "TBLote";
            this.TBLote.Size = new System.Drawing.Size(226, 20);
            this.TBLote.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Agregar lote a la lista:";
            // 
            // btnAgregarAListaDeLotes
            // 
            this.btnAgregarAListaDeLotes.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarAListaDeLotes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAgregarAListaDeLotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarAListaDeLotes.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAListaDeLotes.Location = new System.Drawing.Point(615, 65);
            this.btnAgregarAListaDeLotes.Name = "btnAgregarAListaDeLotes";
            this.btnAgregarAListaDeLotes.Size = new System.Drawing.Size(186, 23);
            this.btnAgregarAListaDeLotes.TabIndex = 40;
            this.btnAgregarAListaDeLotes.Text = "Agregar a lista de lotes:";
            this.btnAgregarAListaDeLotes.UseVisualStyleBackColor = false;
            this.btnAgregarAListaDeLotes.Click += new System.EventHandler(this.btnAgregarAListaDeLotes_Click);
            // 
            // comboLoteDestino
            // 
            this.comboLoteDestino.DataSource = this.r_LISTALOTESINVENTARIOBindingSource;
            this.comboLoteDestino.DisplayMember = "VALOR";
            this.comboLoteDestino.FormattingEnabled = true;
            this.comboLoteDestino.Location = new System.Drawing.Point(86, 40);
            this.comboLoteDestino.Name = "comboLoteDestino";
            this.comboLoteDestino.Size = new System.Drawing.Size(226, 21);
            this.comboLoteDestino.TabIndex = 6;
            this.comboLoteDestino.ValueMember = "R_LISTALOTESINVENTARIO.VALOR";
            // 
            // r_LISTALOTESINVENTARIOBindingSource
            // 
            this.r_LISTALOTESINVENTARIOBindingSource.DataMember = "R_LISTALOTESINVENTARIO";
            this.r_LISTALOTESINVENTARIOBindingSource.DataSource = this.dSInventarioFisico2;
            // 
            // dSInventarioFisico2
            // 
            this.dSInventarioFisico2.DataSetName = "DSInventarioFisico2";
            this.dSInventarioFisico2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RBManualLote
            // 
            this.RBManualLote.AutoSize = true;
            this.RBManualLote.ForeColor = System.Drawing.Color.White;
            this.RBManualLote.Location = new System.Drawing.Point(6, 70);
            this.RBManualLote.Name = "RBManualLote";
            this.RBManualLote.Size = new System.Drawing.Size(60, 17);
            this.RBManualLote.TabIndex = 5;
            this.RBManualLote.Text = "Manual";
            this.RBManualLote.UseVisualStyleBackColor = true;
            // 
            // RBSeleccionLote
            // 
            this.RBSeleccionLote.AutoSize = true;
            this.RBSeleccionLote.Checked = true;
            this.RBSeleccionLote.ForeColor = System.Drawing.Color.White;
            this.RBSeleccionLote.Location = new System.Drawing.Point(6, 41);
            this.RBSeleccionLote.Name = "RBSeleccionLote";
            this.RBSeleccionLote.Size = new System.Drawing.Size(72, 17);
            this.RBSeleccionLote.TabIndex = 4;
            this.RBSeleccionLote.TabStop = true;
            this.RBSeleccionLote.Text = "Selección";
            this.RBSeleccionLote.UseVisualStyleBackColor = true;
            // 
            // r_LISTALOTESINVENTARIOTableAdapter
            // 
            this.r_LISTALOTESINVENTARIOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = iPos.Inventario.DSInventarioFisico2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFooter.Controls.Add(this.pnlLotes);
            this.pnlFooter.Controls.Add(this.BTIntercambioLotes);
            this.pnlFooter.Controls.Add(this.BTPaymentSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 281);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(851, 182);
            this.pnlFooter.TabIndex = 41;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.groupBox1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(851, 43);
            this.pnlHeader.TabIndex = 42;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBIntercambio);
            this.groupBox1.Controls.Add(this.RBReasignacion);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 37);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // RBIntercambio
            // 
            this.RBIntercambio.AutoSize = true;
            this.RBIntercambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBIntercambio.ForeColor = System.Drawing.Color.White;
            this.RBIntercambio.Location = new System.Drawing.Point(499, 11);
            this.RBIntercambio.Name = "RBIntercambio";
            this.RBIntercambio.Size = new System.Drawing.Size(175, 20);
            this.RBIntercambio.TabIndex = 1;
            this.RBIntercambio.Text = "Intercambio en inventario";
            this.RBIntercambio.UseVisualStyleBackColor = true;
            this.RBIntercambio.CheckedChanged += new System.EventHandler(this.RBIntercambio_CheckedChanged);
            // 
            // RBReasignacion
            // 
            this.RBReasignacion.AutoSize = true;
            this.RBReasignacion.Checked = true;
            this.RBReasignacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBReasignacion.ForeColor = System.Drawing.Color.White;
            this.RBReasignacion.Location = new System.Drawing.Point(77, 11);
            this.RBReasignacion.Name = "RBReasignacion";
            this.RBReasignacion.Size = new System.Drawing.Size(164, 20);
            this.RBReasignacion.TabIndex = 0;
            this.RBReasignacion.TabStop = true;
            this.RBReasignacion.Text = "Reasignacion en venta";
            this.RBReasignacion.UseVisualStyleBackColor = true;
            this.RBReasignacion.CheckedChanged += new System.EventHandler(this.RBReasignacion_CheckedChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gridLotesDataGridView);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 43);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(851, 238);
            this.pnlMain.TabIndex = 43;
            // 
            // WFReasignaLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(851, 463);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "WFReasignaLote";
            this.Text = "Reasignacion / Intercambio lote";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.formSkin1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLotesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLotesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux)).EndInit();
            this.pnlLotes.ResumeLayout(false);
            this.pnlLotes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.r_LISTALOTESINVENTARIOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico2)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        //private Skinner.FormSkin formSkin1;
        private System.Windows.Forms.DataGridViewSum gridLotesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button BTPaymentSave;
        private Inventario.DSInventarioFisico3 dSPuntoDeVentaAux;
        private System.Windows.Forms.BindingSource gridLotesBindingSource1;
        private Inventario.DSInventarioFisico3TableAdapters.GridLotesTableAdapter gridLotesTableAdapter1;
        private Inventario.DSInventarioFisico3TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button BTIntercambioLotes;
        private System.Windows.Forms.GroupBox pnlLotes;
        private System.Windows.Forms.DateTimePicker DTPFechaVence;
        private System.Windows.Forms.TextBox TBLote;
        private System.Windows.Forms.ComboBox comboLoteDestino;
        private System.Windows.Forms.RadioButton RBManualLote;
        private System.Windows.Forms.RadioButton RBSeleccionLote;
        private System.Windows.Forms.Label label3;
        private Inventario.DSInventarioFisico2 dSInventarioFisico2;
        private System.Windows.Forms.BindingSource r_LISTALOTESINVENTARIOBindingSource;
        private Inventario.DSInventarioFisico2TableAdapters.R_LISTALOTESINVENTARIOTableAdapter r_LISTALOTESINVENTARIOTableAdapter;
        private Inventario.DSInventarioFisico2TableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Button btnAgregarAListaDeLotes;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_LOTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_FECHAVENCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CADUCADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PORCADUCAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDADENDOCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASURTIR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGSURTIBLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCANTSURTIBLE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBIntercambio;
        private System.Windows.Forms.RadioButton RBReasignacion;
    }
}