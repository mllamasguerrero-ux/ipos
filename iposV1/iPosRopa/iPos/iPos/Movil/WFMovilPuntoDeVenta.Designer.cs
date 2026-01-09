namespace iPos
{
    partial class WFMovilPuntoDeVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFMovilPuntoDeVenta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gRIDPVBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dSPuntoDeVentaAux = new iPos.PuntoDeVenta.DSPuntoDeVentaAux();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.gridPVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSPuntoVenta = new iPos.PuntoDeVenta.DSPuntoVenta();
            this.dETALLE_DE_PAGOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridPVTableAdapter = new iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.GridPVTableAdapter();
            this.tableAdapterManager = new iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.TableAdapterManager();
            this.dETALLE_DE_PAGOTableAdapter = new iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.DETALLE_DE_PAGOTableAdapter();
            this.gRIDPVTableAdapter1 = new iPos.PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.GRIDPVTableAdapter();
            this.tableAdapterManager1 = new iPos.PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.TableAdapterManager();
            this.RFVendedorFinal = new CustomValidation.RequiredFieldValidator();
            this.panelRoot = new System.Windows.Forms.Panel();
            this.gridPVDataGridView = new System.Windows.Forms.DataGridViewE();
            this.DOCTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOVTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pARTIDADataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gRIDLINEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVCANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGDESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIOUNIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TASAIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TASAIEPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCUENTOPORCENTAJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PORCENTAJEDESCUENTOMANUAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TASAIMPUESTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TITULOSTOTALES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVCLAVEPRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTALVALE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEXTO1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEXTO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEXTO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEXTO4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEXTO5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEXTO6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMAGEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGALERTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPZACAJA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UTILIDADMOVIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGHEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBSumaTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBIva = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TBTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.BTValidarExistencia = new System.Windows.Forms.Button();
            this.btnListaAdjuntos = new System.Windows.Forms.Button();
            this.btEditarVenta = new System.Windows.Forms.Button();
            this.btnAdjunto = new System.Windows.Forms.Button();
            this.BTCerrarVenta = new System.Windows.Forms.Button();
            this.BTAbrirVenta = new System.Windows.Forms.Button();
            this.BTPasarANueva = new System.Windows.Forms.Button();
            this.BTAbrirCerradasYDevo = new System.Windows.Forms.Button();
            this.BTCancelarVenta = new System.Windows.Forms.Button();
            this.BTEliminarDetalle = new System.Windows.Forms.Button();
            this.ListaPrecios = new System.Windows.Forms.ListBox();
            this.pnlInfoSaldos = new System.Windows.Forms.Panel();
            this.lblAbonos = new System.Windows.Forms.Label();
            this.lblSaldoVencido = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblLimite = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEtiqLimite = new System.Windows.Forms.Label();
            this.btnFecha = new System.Windows.Forms.Button();
            this.lstProductoComplete = new System.Windows.Forms.ListBox();
            this.lbClieNombre = new System.Windows.Forms.Label();
            this.btnClearCommand = new System.Windows.Forms.Button();
            this.LBVenta = new System.Windows.Forms.Label();
            this.pnlPrecioCaja = new System.Windows.Forms.Panel();
            this.TBPrecioCaja = new System.Windows.Forms.NumericTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnCalculadora = new System.Windows.Forms.Button();
            this.BTRecalcular = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.clock1 = new iPos.Tools.Clock();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCobranzaMovil = new System.Windows.Forms.Button();
            this.TBDescuento = new System.Windows.Forms.NumericTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TBPrecio = new System.Windows.Forms.NumericTextBox();
            this.TBCantidad = new System.Windows.Forms.NumericTextBox();
            this.LBCliente = new System.Windows.Forms.Label();
            this.TBCajas = new System.Windows.Forms.NumericTextBox();
            this.BTCliente = new System.Windows.Forms.Button();
            this.TBCommandLine = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCajas = new System.Windows.Forms.Label();
            this.LBVendedor = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tbCurrentItem = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gRIDPVBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLE_DE_PAGOBindingSource)).BeginInit();
            this.panelRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPVDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.pnlInfoSaldos.SuspendLayout();
            this.pnlPrecioCaja.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // gRIDPVBindingSource1
            // 
            this.gRIDPVBindingSource1.DataMember = "GRIDPV";
            this.gRIDPVBindingSource1.DataSource = this.dSPuntoDeVentaAux;
            // 
            // dSPuntoDeVentaAux
            // 
            this.dSPuntoDeVentaAux.DataSetName = "DSPuntoDeVentaAux";
            this.dSPuntoDeVentaAux.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // gridPVBindingSource
            // 
            this.gridPVBindingSource.DataMember = "GridPV";
            this.gridPVBindingSource.DataSource = this.dSPuntoVenta;
            this.gridPVBindingSource.CurrentChanged += new System.EventHandler(this.gridPVBindingSource_CurrentChanged);
            // 
            // dSPuntoVenta
            // 
            this.dSPuntoVenta.DataSetName = "DSPuntoVenta";
            this.dSPuntoVenta.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dSPuntoVenta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dETALLE_DE_PAGOBindingSource
            // 
            this.dETALLE_DE_PAGOBindingSource.DataMember = "DETALLE_DE_PAGO";
            this.dETALLE_DE_PAGOBindingSource.DataSource = this.dSPuntoVenta;
            // 
            // gridPVTableAdapter
            // 
            this.gridPVTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dETALLE_DE_PAGOTableAdapter
            // 
            this.dETALLE_DE_PAGOTableAdapter.ClearBeforeFill = true;
            // 
            // gRIDPVTableAdapter1
            // 
            this.gRIDPVTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = iPos.PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // RFVendedorFinal
            // 
            this.RFVendedorFinal.Enabled = true;
            this.RFVendedorFinal.Icon = ((System.Drawing.Icon)(resources.GetObject("RFVendedorFinal.Icon")));
            // 
            // panelRoot
            // 
            this.panelRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.panelRoot.Controls.Add(this.TBTotal);
            this.panelRoot.Controls.Add(this.TBIva);
            this.panelRoot.Controls.Add(this.label8);
            this.panelRoot.Controls.Add(this.TBSumaTotal);
            this.panelRoot.Controls.Add(this.label6);
            this.panelRoot.Controls.Add(this.label5);
            this.panelRoot.Controls.Add(this.gridPVDataGridView);
            this.panelRoot.Controls.Add(this.panel2);
            this.panelRoot.Controls.Add(this.ListaPrecios);
            this.panelRoot.Controls.Add(this.pnlInfoSaldos);
            this.panelRoot.Controls.Add(this.btnFecha);
            this.panelRoot.Controls.Add(this.lstProductoComplete);
            this.panelRoot.Controls.Add(this.lbClieNombre);
            this.panelRoot.Controls.Add(this.btnClearCommand);
            this.panelRoot.Controls.Add(this.LBVenta);
            this.panelRoot.Controls.Add(this.pnlPrecioCaja);
            this.panelRoot.Controls.Add(this.btnCalculadora);
            this.panelRoot.Controls.Add(this.BTRecalcular);
            this.panelRoot.Controls.Add(this.label3);
            this.panelRoot.Controls.Add(this.clock1);
            this.panelRoot.Controls.Add(this.label11);
            this.panelRoot.Controls.Add(this.btnCobranzaMovil);
            this.panelRoot.Controls.Add(this.TBDescuento);
            this.panelRoot.Controls.Add(this.label7);
            this.panelRoot.Controls.Add(this.TBPrecio);
            this.panelRoot.Controls.Add(this.TBCantidad);
            this.panelRoot.Controls.Add(this.LBCliente);
            this.panelRoot.Controls.Add(this.TBCajas);
            this.panelRoot.Controls.Add(this.BTCliente);
            this.panelRoot.Controls.Add(this.TBCommandLine);
            this.panelRoot.Controls.Add(this.label12);
            this.panelRoot.Controls.Add(this.lblCajas);
            this.panelRoot.Controls.Add(this.LBVendedor);
            this.panelRoot.Controls.Add(this.panel8);
            this.panelRoot.Controls.Add(this.label19);
            this.panelRoot.Controls.Add(this.label24);
            this.panelRoot.Controls.Add(this.lblCantidad);
            this.panelRoot.Controls.Add(this.label20);
            this.panelRoot.Location = new System.Drawing.Point(0, 0);
            this.panelRoot.Name = "panelRoot";
            this.panelRoot.Size = new System.Drawing.Size(592, 640);
            this.panelRoot.TabIndex = 171;
            this.panelRoot.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRoot_Paint);
            // 
            // gridPVDataGridView
            // 
            this.gridPVDataGridView.AllowUserToAddRows = false;
            this.gridPVDataGridView.AllowUserToDeleteRows = false;
            this.gridPVDataGridView.AllowUserToResizeColumns = false;
            this.gridPVDataGridView.AllowUserToResizeRows = false;
            this.gridPVDataGridView.AutoGenerateColumns = false;
            this.gridPVDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridPVDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            this.gridPVDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridPVDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridPVDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPVDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DOCTOID,
            this.MOVTOID,
            this.pARTIDADataGridViewTextBoxColumn1,
            this.gRIDLINEDataGridViewTextBoxColumn1,
            this.GVCANTIDAD,
            this.DGDESCRIPCION,
            this.PRECIOUNIDAD,
            this.IVA,
            this.TASAIVA,
            this.TASAIEPS,
            this.DESCUENTOPORCENTAJE,
            this.PORCENTAJEDESCUENTOMANUAL,
            this.IMPORTE,
            this.TASAIMPUESTO,
            this.TITULOSTOTALES,
            this.DESCRIPCION2,
            this.LOTE,
            this.GVCLAVEPRODUCTO,
            this.TOTALVALE,
            this.TEXTO1,
            this.TEXTO2,
            this.TEXTO3,
            this.TEXTO4,
            this.TEXTO5,
            this.TEXTO6,
            this.NUMERO1,
            this.NUMERO2,
            this.NUMERO3,
            this.NUMERO4,
            this.IMAGEN,
            this.DGALERTA,
            this.DGPZACAJA,
            this.UTILIDADMOVIL,
            this.DGHEIGHT});
            this.gridPVDataGridView.DataSource = this.gRIDPVBindingSource1;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPVDataGridView.DefaultCellStyle = dataGridViewCellStyle11;
            this.gridPVDataGridView.EnableHeadersVisualStyles = false;
            this.gridPVDataGridView.Location = new System.Drawing.Point(5, 181);
            this.gridPVDataGridView.Name = "gridPVDataGridView";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPVDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gridPVDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.LightGray;
            this.gridPVDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.gridPVDataGridView.RowTemplate.Height = 33;
            this.gridPVDataGridView.Size = new System.Drawing.Size(577, 362);
            this.gridPVDataGridView.TabIndex = 3;
            this.gridPVDataGridView.EnterKeyDownEvent += new System.EventHandler(this.gridPVDataGridView_EnterKeyDownEvent);
            this.gridPVDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridPVDataGridView_CellBeginEdit);
            this.gridPVDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPVDataGridView_CellClick);
            this.gridPVDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPVDataGridView_CellContentDoubleClick);
            this.gridPVDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPVDataGridView_CellDoubleClick);
            this.gridPVDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPVDataGridView_CellEndEdit);
            this.gridPVDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridPVDataGridView_CellFormatting);
            this.gridPVDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridPVDataGridView_CellValidating);
            this.gridPVDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridPVDataGridView_EditingControlShowing);
            this.gridPVDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPVDataGridView_RowEnter);
            this.gridPVDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridPVDataGridView_KeyPress);
            // 
            // DOCTOID
            // 
            this.DOCTOID.DataPropertyName = "DOCTOID";
            this.DOCTOID.HeaderText = "DOCTOID";
            this.DOCTOID.Name = "DOCTOID";
            this.DOCTOID.ReadOnly = true;
            this.DOCTOID.Visible = false;
            // 
            // MOVTOID
            // 
            this.MOVTOID.DataPropertyName = "MOVTOID";
            this.MOVTOID.HeaderText = "MOVTOID";
            this.MOVTOID.Name = "MOVTOID";
            this.MOVTOID.ReadOnly = true;
            this.MOVTOID.Visible = false;
            // 
            // pARTIDADataGridViewTextBoxColumn1
            // 
            this.pARTIDADataGridViewTextBoxColumn1.DataPropertyName = "PARTIDA";
            this.pARTIDADataGridViewTextBoxColumn1.HeaderText = "PARTIDA";
            this.pARTIDADataGridViewTextBoxColumn1.Name = "pARTIDADataGridViewTextBoxColumn1";
            this.pARTIDADataGridViewTextBoxColumn1.ReadOnly = true;
            this.pARTIDADataGridViewTextBoxColumn1.Visible = false;
            this.pARTIDADataGridViewTextBoxColumn1.Width = 75;
            // 
            // gRIDLINEDataGridViewTextBoxColumn1
            // 
            this.gRIDLINEDataGridViewTextBoxColumn1.DataPropertyName = "GRIDLINE";
            this.gRIDLINEDataGridViewTextBoxColumn1.HeaderText = "GRIDLINE";
            this.gRIDLINEDataGridViewTextBoxColumn1.Name = "gRIDLINEDataGridViewTextBoxColumn1";
            this.gRIDLINEDataGridViewTextBoxColumn1.ReadOnly = true;
            this.gRIDLINEDataGridViewTextBoxColumn1.Visible = false;
            // 
            // GVCANTIDAD
            // 
            this.GVCANTIDAD.DataPropertyName = "CANTIDAD";
            this.GVCANTIDAD.HeaderText = "CANTIDAD";
            this.GVCANTIDAD.Name = "GVCANTIDAD";
            this.GVCANTIDAD.Width = 95;
            // 
            // DGDESCRIPCION
            // 
            this.DGDESCRIPCION.DataPropertyName = "DESCRIPCION";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGDESCRIPCION.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGDESCRIPCION.HeaderText = "DESCRIPCION";
            this.DGDESCRIPCION.Name = "DGDESCRIPCION";
            this.DGDESCRIPCION.ReadOnly = true;
            this.DGDESCRIPCION.Width = 315;
            // 
            // PRECIOUNIDAD
            // 
            this.PRECIOUNIDAD.DataPropertyName = "PRECIOUNIDAD";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.PRECIOUNIDAD.DefaultCellStyle = dataGridViewCellStyle3;
            this.PRECIOUNIDAD.HeaderText = "PRECIO C/U";
            this.PRECIOUNIDAD.Name = "PRECIOUNIDAD";
            this.PRECIOUNIDAD.ReadOnly = true;
            this.PRECIOUNIDAD.Width = 125;
            // 
            // IVA
            // 
            this.IVA.DataPropertyName = "IVA";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.IVA.DefaultCellStyle = dataGridViewCellStyle4;
            this.IVA.HeaderText = "IVA";
            this.IVA.Name = "IVA";
            this.IVA.ReadOnly = true;
            this.IVA.Visible = false;
            this.IVA.Width = 70;
            // 
            // TASAIVA
            // 
            this.TASAIVA.DataPropertyName = "TASAIVA";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.TASAIVA.DefaultCellStyle = dataGridViewCellStyle5;
            this.TASAIVA.HeaderText = "T. IVA";
            this.TASAIVA.Name = "TASAIVA";
            this.TASAIVA.ReadOnly = true;
            this.TASAIVA.Visible = false;
            this.TASAIVA.Width = 50;
            // 
            // TASAIEPS
            // 
            this.TASAIEPS.DataPropertyName = "TASAIEPS";
            this.TASAIEPS.HeaderText = "TASAIEPS";
            this.TASAIEPS.Name = "TASAIEPS";
            this.TASAIEPS.ReadOnly = true;
            this.TASAIEPS.Visible = false;
            // 
            // DESCUENTOPORCENTAJE
            // 
            this.DESCUENTOPORCENTAJE.DataPropertyName = "DESCUENTOPORCENTAJE";
            this.DESCUENTOPORCENTAJE.HeaderText = "%D.";
            this.DESCUENTOPORCENTAJE.Name = "DESCUENTOPORCENTAJE";
            this.DESCUENTOPORCENTAJE.ReadOnly = true;
            this.DESCUENTOPORCENTAJE.Width = 50;
            // 
            // PORCENTAJEDESCUENTOMANUAL
            // 
            this.PORCENTAJEDESCUENTOMANUAL.DataPropertyName = "PORCENTAJEDESCUENTOMANUAL";
            this.PORCENTAJEDESCUENTOMANUAL.HeaderText = "% D. MAN.";
            this.PORCENTAJEDESCUENTOMANUAL.Name = "PORCENTAJEDESCUENTOMANUAL";
            this.PORCENTAJEDESCUENTOMANUAL.ReadOnly = true;
            this.PORCENTAJEDESCUENTOMANUAL.Visible = false;
            this.PORCENTAJEDESCUENTOMANUAL.Width = 60;
            // 
            // IMPORTE
            // 
            this.IMPORTE.DataPropertyName = "IMPORTE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0.00";
            this.IMPORTE.DefaultCellStyle = dataGridViewCellStyle6;
            this.IMPORTE.HeaderText = "IMPORTE";
            this.IMPORTE.Name = "IMPORTE";
            this.IMPORTE.ReadOnly = true;
            this.IMPORTE.Width = 125;
            // 
            // TASAIMPUESTO
            // 
            this.TASAIMPUESTO.DataPropertyName = "TASAIMPUESTO";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.TASAIMPUESTO.DefaultCellStyle = dataGridViewCellStyle7;
            this.TASAIMPUESTO.HeaderText = "T IMP";
            this.TASAIMPUESTO.Name = "TASAIMPUESTO";
            this.TASAIMPUESTO.ReadOnly = true;
            this.TASAIMPUESTO.Width = 50;
            // 
            // TITULOSTOTALES
            // 
            this.TITULOSTOTALES.DataPropertyName = "DESCUENTO";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0.00";
            this.TITULOSTOTALES.DefaultCellStyle = dataGridViewCellStyle8;
            this.TITULOSTOTALES.HeaderText = "DESC";
            this.TITULOSTOTALES.Name = "TITULOSTOTALES";
            this.TITULOSTOTALES.ReadOnly = true;
            this.TITULOSTOTALES.Width = 60;
            // 
            // DESCRIPCION2
            // 
            this.DESCRIPCION2.DataPropertyName = "DESCRIPCION2";
            this.DESCRIPCION2.HeaderText = "DESCRIPCION2";
            this.DESCRIPCION2.Name = "DESCRIPCION2";
            this.DESCRIPCION2.ReadOnly = true;
            // 
            // LOTE
            // 
            this.LOTE.DataPropertyName = "LOTE";
            this.LOTE.HeaderText = "LOTE";
            this.LOTE.Name = "LOTE";
            this.LOTE.ReadOnly = true;
            // 
            // GVCLAVEPRODUCTO
            // 
            this.GVCLAVEPRODUCTO.DataPropertyName = "CLAVEPRODUCTO";
            this.GVCLAVEPRODUCTO.HeaderText = "CLAVEPRODUCTO";
            this.GVCLAVEPRODUCTO.Name = "GVCLAVEPRODUCTO";
            this.GVCLAVEPRODUCTO.ReadOnly = true;
            this.GVCLAVEPRODUCTO.Visible = false;
            // 
            // TOTALVALE
            // 
            this.TOTALVALE.DataPropertyName = "TOTALVALE";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.TOTALVALE.DefaultCellStyle = dataGridViewCellStyle9;
            this.TOTALVALE.HeaderText = "TOTALVALE";
            this.TOTALVALE.Name = "TOTALVALE";
            this.TOTALVALE.ReadOnly = true;
            this.TOTALVALE.Visible = false;
            // 
            // TEXTO1
            // 
            this.TEXTO1.DataPropertyName = "TEXTO1";
            this.TEXTO1.HeaderText = "TEXTO1";
            this.TEXTO1.Name = "TEXTO1";
            this.TEXTO1.ReadOnly = true;
            this.TEXTO1.Visible = false;
            // 
            // TEXTO2
            // 
            this.TEXTO2.DataPropertyName = "TEXTO2";
            this.TEXTO2.HeaderText = "TEXTO2";
            this.TEXTO2.Name = "TEXTO2";
            this.TEXTO2.ReadOnly = true;
            this.TEXTO2.Visible = false;
            // 
            // TEXTO3
            // 
            this.TEXTO3.DataPropertyName = "TEXTO3";
            this.TEXTO3.HeaderText = "TEXTO3";
            this.TEXTO3.Name = "TEXTO3";
            this.TEXTO3.ReadOnly = true;
            this.TEXTO3.Visible = false;
            // 
            // TEXTO4
            // 
            this.TEXTO4.DataPropertyName = "TEXTO4";
            this.TEXTO4.HeaderText = "TEXTO4";
            this.TEXTO4.Name = "TEXTO4";
            this.TEXTO4.ReadOnly = true;
            this.TEXTO4.Visible = false;
            // 
            // TEXTO5
            // 
            this.TEXTO5.DataPropertyName = "TEXTO5";
            this.TEXTO5.HeaderText = "TEXTO5";
            this.TEXTO5.Name = "TEXTO5";
            this.TEXTO5.ReadOnly = true;
            this.TEXTO5.Visible = false;
            // 
            // TEXTO6
            // 
            this.TEXTO6.DataPropertyName = "TEXTO6";
            this.TEXTO6.HeaderText = "TEXTO6";
            this.TEXTO6.Name = "TEXTO6";
            this.TEXTO6.ReadOnly = true;
            this.TEXTO6.Visible = false;
            // 
            // NUMERO1
            // 
            this.NUMERO1.DataPropertyName = "NUMERO1";
            this.NUMERO1.HeaderText = "NUMERO1";
            this.NUMERO1.Name = "NUMERO1";
            this.NUMERO1.ReadOnly = true;
            this.NUMERO1.Visible = false;
            // 
            // NUMERO2
            // 
            this.NUMERO2.DataPropertyName = "NUMERO2";
            this.NUMERO2.HeaderText = "NUMERO2";
            this.NUMERO2.Name = "NUMERO2";
            this.NUMERO2.ReadOnly = true;
            this.NUMERO2.Visible = false;
            // 
            // NUMERO3
            // 
            this.NUMERO3.DataPropertyName = "NUMERO3";
            this.NUMERO3.HeaderText = "NUMERO3";
            this.NUMERO3.Name = "NUMERO3";
            this.NUMERO3.ReadOnly = true;
            this.NUMERO3.Visible = false;
            // 
            // NUMERO4
            // 
            this.NUMERO4.DataPropertyName = "NUMERO4";
            this.NUMERO4.HeaderText = "NUMERO4";
            this.NUMERO4.Name = "NUMERO4";
            this.NUMERO4.ReadOnly = true;
            this.NUMERO4.Visible = false;
            // 
            // IMAGEN
            // 
            this.IMAGEN.DataPropertyName = "IMAGEN";
            this.IMAGEN.HeaderText = "IMAGEN";
            this.IMAGEN.Name = "IMAGEN";
            this.IMAGEN.ReadOnly = true;
            this.IMAGEN.Visible = false;
            // 
            // DGALERTA
            // 
            this.DGALERTA.DataPropertyName = "ALERTA";
            this.DGALERTA.HeaderText = "ALERTA";
            this.DGALERTA.Name = "DGALERTA";
            this.DGALERTA.Visible = false;
            // 
            // DGPZACAJA
            // 
            this.DGPZACAJA.DataPropertyName = "PZACAJA";
            this.DGPZACAJA.HeaderText = "PZACAJA";
            this.DGPZACAJA.Name = "DGPZACAJA";
            this.DGPZACAJA.ReadOnly = true;
            this.DGPZACAJA.Visible = false;
            // 
            // UTILIDADMOVIL
            // 
            this.UTILIDADMOVIL.DataPropertyName = "UTILIDADMOVIL";
            this.UTILIDADMOVIL.HeaderText = "UTILIDADMOVIL";
            this.UTILIDADMOVIL.Name = "UTILIDADMOVIL";
            this.UTILIDADMOVIL.ReadOnly = true;
            // 
            // DGHEIGHT
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.NullValue = " ";
            this.DGHEIGHT.DefaultCellStyle = dataGridViewCellStyle10;
            this.DGHEIGHT.HeaderText = "";
            this.DGHEIGHT.Name = "DGHEIGHT";
            this.DGHEIGHT.ReadOnly = true;
            // 
            // TBSumaTotal
            // 
            this.TBSumaTotal.BackColor = System.Drawing.SystemColors.Control;
            this.TBSumaTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBSumaTotal.ForeColor = System.Drawing.Color.Black;
            this.TBSumaTotal.Location = new System.Drawing.Point(418, 547);
            this.TBSumaTotal.Name = "TBSumaTotal";
            this.TBSumaTotal.ReadOnly = true;
            this.TBSumaTotal.Size = new System.Drawing.Size(164, 29);
            this.TBSumaTotal.TabIndex = 0;
            this.TBSumaTotal.TabStop = false;
            this.TBSumaTotal.Text = "0.00";
            this.TBSumaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(352, 553);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Suma:";
            // 
            // TBIva
            // 
            this.TBIva.BackColor = System.Drawing.SystemColors.Control;
            this.TBIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBIva.ForeColor = System.Drawing.Color.Black;
            this.TBIva.Location = new System.Drawing.Point(418, 576);
            this.TBIva.Name = "TBIva";
            this.TBIva.ReadOnly = true;
            this.TBIva.Size = new System.Drawing.Size(164, 29);
            this.TBIva.TabIndex = 0;
            this.TBIva.TabStop = false;
            this.TBIva.Text = "0.00";
            this.TBIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(369, 582);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "IVA:";
            // 
            // TBTotal
            // 
            this.TBTotal.BackColor = System.Drawing.SystemColors.Control;
            this.TBTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTotal.ForeColor = System.Drawing.Color.Black;
            this.TBTotal.Location = new System.Drawing.Point(418, 606);
            this.TBTotal.Name = "TBTotal";
            this.TBTotal.ReadOnly = true;
            this.TBTotal.Size = new System.Drawing.Size(164, 29);
            this.TBTotal.TabIndex = 0;
            this.TBTotal.TabStop = false;
            this.TBTotal.Text = "0.00";
            this.TBTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(359, 612);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Total:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Location = new System.Drawing.Point(6, 539);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 96);
            this.panel2.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel10.Controls.Add(this.BTValidarExistencia);
            this.panel10.Controls.Add(this.btnListaAdjuntos);
            this.panel10.Controls.Add(this.btEditarVenta);
            this.panel10.Controls.Add(this.btnAdjunto);
            this.panel10.Controls.Add(this.BTCerrarVenta);
            this.panel10.Controls.Add(this.BTAbrirVenta);
            this.panel10.Controls.Add(this.BTPasarANueva);
            this.panel10.Controls.Add(this.BTAbrirCerradasYDevo);
            this.panel10.Controls.Add(this.BTCancelarVenta);
            this.panel10.Controls.Add(this.BTEliminarDetalle);
            this.panel10.Location = new System.Drawing.Point(-1, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(346, 101);
            this.panel10.TabIndex = 10;
            // 
            // BTValidarExistencia
            // 
            this.BTValidarExistencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.BTValidarExistencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTValidarExistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTValidarExistencia.ForeColor = System.Drawing.Color.Black;
            this.BTValidarExistencia.Location = new System.Drawing.Point(272, 0);
            this.BTValidarExistencia.Name = "BTValidarExistencia";
            this.BTValidarExistencia.Size = new System.Drawing.Size(70, 48);
            this.BTValidarExistencia.TabIndex = 47;
            this.BTValidarExistencia.Text = "Validar existencia";
            this.BTValidarExistencia.UseVisualStyleBackColor = false;
            this.BTValidarExistencia.Click += new System.EventHandler(this.BTValidarExistencia_Click);
            // 
            // btnListaAdjuntos
            // 
            this.btnListaAdjuntos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.btnListaAdjuntos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnListaAdjuntos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListaAdjuntos.ForeColor = System.Drawing.Color.Black;
            this.btnListaAdjuntos.Location = new System.Drawing.Point(204, 46);
            this.btnListaAdjuntos.Name = "btnListaAdjuntos";
            this.btnListaAdjuntos.Size = new System.Drawing.Size(70, 48);
            this.btnListaAdjuntos.TabIndex = 51;
            this.btnListaAdjuntos.Text = "Adjuntos";
            this.btnListaAdjuntos.UseVisualStyleBackColor = false;
            this.btnListaAdjuntos.Click += new System.EventHandler(this.btnListaAdjuntos_Click);
            // 
            // btEditarVenta
            // 
            this.btEditarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.btEditarVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btEditarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEditarVenta.ForeColor = System.Drawing.Color.Black;
            this.btEditarVenta.Location = new System.Drawing.Point(204, 0);
            this.btEditarVenta.Name = "btEditarVenta";
            this.btEditarVenta.Size = new System.Drawing.Size(70, 48);
            this.btEditarVenta.TabIndex = 48;
            this.btEditarVenta.Text = "Editar venta";
            this.btEditarVenta.UseVisualStyleBackColor = false;
            this.btEditarVenta.Visible = false;
            this.btEditarVenta.Click += new System.EventHandler(this.btEditarVenta_Click);
            // 
            // btnAdjunto
            // 
            this.btnAdjunto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.btnAdjunto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAdjunto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjunto.ForeColor = System.Drawing.Color.Black;
            this.btnAdjunto.Location = new System.Drawing.Point(272, 46);
            this.btnAdjunto.Name = "btnAdjunto";
            this.btnAdjunto.Size = new System.Drawing.Size(70, 48);
            this.btnAdjunto.TabIndex = 50;
            this.btnAdjunto.Text = "Adjuntar";
            this.btnAdjunto.UseVisualStyleBackColor = false;
            this.btnAdjunto.Click += new System.EventHandler(this.btnAdjunto_Click);
            // 
            // BTCerrarVenta
            // 
            this.BTCerrarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(196)))), ((int)(((byte)(77)))));
            this.BTCerrarVenta.BackgroundImage = global::iPos.Properties.Resources.moneySmallNoBack_J;
            this.BTCerrarVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTCerrarVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCerrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCerrarVenta.ForeColor = System.Drawing.Color.Black;
            this.BTCerrarVenta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTCerrarVenta.Location = new System.Drawing.Point(0, 0);
            this.BTCerrarVenta.Name = "BTCerrarVenta";
            this.BTCerrarVenta.Size = new System.Drawing.Size(70, 48);
            this.BTCerrarVenta.TabIndex = 7;
            this.BTCerrarVenta.Text = "Pagar (F6)";
            this.BTCerrarVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTCerrarVenta.UseVisualStyleBackColor = false;
            this.BTCerrarVenta.Click += new System.EventHandler(this.BTCerrarVenta_Click);
            // 
            // BTAbrirVenta
            // 
            this.BTAbrirVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(170)))), ((int)(((byte)(25)))));
            this.BTAbrirVenta.BackgroundImage = global::iPos.Properties.Resources.editNoBackSmallWhite_J;
            this.BTAbrirVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTAbrirVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTAbrirVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAbrirVenta.ForeColor = System.Drawing.Color.Black;
            this.BTAbrirVenta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTAbrirVenta.Location = new System.Drawing.Point(68, 46);
            this.BTAbrirVenta.Name = "BTAbrirVenta";
            this.BTAbrirVenta.Size = new System.Drawing.Size(70, 48);
            this.BTAbrirVenta.TabIndex = 13;
            this.BTAbrirVenta.Text = "Pendientes (F4)";
            this.BTAbrirVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTAbrirVenta.UseVisualStyleBackColor = false;
            this.BTAbrirVenta.Click += new System.EventHandler(this.BTAbrirVenta_Click);
            // 
            // BTPasarANueva
            // 
            this.BTPasarANueva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(121)))), ((int)(((byte)(255)))));
            this.BTPasarANueva.BackgroundImage = global::iPos.Properties.Resources.newNoBackSmallWhite_J;
            this.BTPasarANueva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTPasarANueva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTPasarANueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTPasarANueva.ForeColor = System.Drawing.Color.Black;
            this.BTPasarANueva.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTPasarANueva.Location = new System.Drawing.Point(68, 0);
            this.BTPasarANueva.Name = "BTPasarANueva";
            this.BTPasarANueva.Size = new System.Drawing.Size(70, 48);
            this.BTPasarANueva.TabIndex = 8;
            this.BTPasarANueva.Text = "Nueva (F2)";
            this.BTPasarANueva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTPasarANueva.UseVisualStyleBackColor = false;
            this.BTPasarANueva.Click += new System.EventHandler(this.BTPasarANueva_Click);
            // 
            // BTAbrirCerradasYDevo
            // 
            this.BTAbrirCerradasYDevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(170)))), ((int)(((byte)(25)))));
            this.BTAbrirCerradasYDevo.BackgroundImage = global::iPos.Properties.Resources.searchNoBackSmallWhite_J;
            this.BTAbrirCerradasYDevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTAbrirCerradasYDevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTAbrirCerradasYDevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAbrirCerradasYDevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.BTAbrirCerradasYDevo.ForeColor = System.Drawing.Color.Black;
            this.BTAbrirCerradasYDevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTAbrirCerradasYDevo.Location = new System.Drawing.Point(136, 46);
            this.BTAbrirCerradasYDevo.Name = "BTAbrirCerradasYDevo";
            this.BTAbrirCerradasYDevo.Size = new System.Drawing.Size(70, 48);
            this.BTAbrirCerradasYDevo.TabIndex = 14;
            this.BTAbrirCerradasYDevo.Text = "Ventas cerradas (F5)";
            this.BTAbrirCerradasYDevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTAbrirCerradasYDevo.UseVisualStyleBackColor = false;
            this.BTAbrirCerradasYDevo.Click += new System.EventHandler(this.BTAbrirCerradasYDevo_Click);
            // 
            // BTCancelarVenta
            // 
            this.BTCancelarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BTCancelarVenta.BackgroundImage = global::iPos.Properties.Resources.canelNoBackSmallWhite_J;
            this.BTCancelarVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTCancelarVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCancelarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelarVenta.ForeColor = System.Drawing.Color.Black;
            this.BTCancelarVenta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTCancelarVenta.Location = new System.Drawing.Point(136, 0);
            this.BTCancelarVenta.Name = "BTCancelarVenta";
            this.BTCancelarVenta.Size = new System.Drawing.Size(70, 48);
            this.BTCancelarVenta.TabIndex = 9;
            this.BTCancelarVenta.Text = "Cancelar (F3)";
            this.BTCancelarVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTCancelarVenta.UseVisualStyleBackColor = false;
            this.BTCancelarVenta.Click += new System.EventHandler(this.BTCancelarVenta_Click);
            // 
            // BTEliminarDetalle
            // 
            this.BTEliminarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BTEliminarDetalle.BackgroundImage = global::iPos.Properties.Resources.deleteNoBackSmallWhite_J;
            this.BTEliminarDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTEliminarDetalle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEliminarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEliminarDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.BTEliminarDetalle.ForeColor = System.Drawing.Color.Black;
            this.BTEliminarDetalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTEliminarDetalle.Location = new System.Drawing.Point(0, 46);
            this.BTEliminarDetalle.Name = "BTEliminarDetalle";
            this.BTEliminarDetalle.Size = new System.Drawing.Size(70, 48);
            this.BTEliminarDetalle.TabIndex = 12;
            this.BTEliminarDetalle.Text = "Eliminar detalle (F10)";
            this.BTEliminarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTEliminarDetalle.UseVisualStyleBackColor = false;
            this.BTEliminarDetalle.Click += new System.EventHandler(this.BTEliminarDetalle_Click);
            // 
            // ListaPrecios
            // 
            this.ListaPrecios.FormattingEnabled = true;
            this.ListaPrecios.Location = new System.Drawing.Point(256, 165);
            this.ListaPrecios.Name = "ListaPrecios";
            this.ListaPrecios.Size = new System.Drawing.Size(94, 30);
            this.ListaPrecios.TabIndex = 24;
            this.ListaPrecios.TabStop = false;
            this.ListaPrecios.Visible = false;
            this.ListaPrecios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            this.ListaPrecios.Leave += new System.EventHandler(this.listBox1_Leave);
            // 
            // pnlInfoSaldos
            // 
            this.pnlInfoSaldos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.pnlInfoSaldos.Controls.Add(this.lblAbonos);
            this.pnlInfoSaldos.Controls.Add(this.lblSaldoVencido);
            this.pnlInfoSaldos.Controls.Add(this.lblSaldo);
            this.pnlInfoSaldos.Controls.Add(this.lblLimite);
            this.pnlInfoSaldos.Controls.Add(this.label4);
            this.pnlInfoSaldos.Controls.Add(this.label2);
            this.pnlInfoSaldos.Controls.Add(this.label1);
            this.pnlInfoSaldos.Controls.Add(this.labelEtiqLimite);
            this.pnlInfoSaldos.Location = new System.Drawing.Point(13, 44);
            this.pnlInfoSaldos.Name = "pnlInfoSaldos";
            this.pnlInfoSaldos.Size = new System.Drawing.Size(473, 37);
            this.pnlInfoSaldos.TabIndex = 173;
            // 
            // lblAbonos
            // 
            this.lblAbonos.AutoSize = true;
            this.lblAbonos.BackColor = System.Drawing.Color.Transparent;
            this.lblAbonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbonos.ForeColor = System.Drawing.Color.White;
            this.lblAbonos.Location = new System.Drawing.Point(381, 23);
            this.lblAbonos.Name = "lblAbonos";
            this.lblAbonos.Size = new System.Drawing.Size(19, 13);
            this.lblAbonos.TabIndex = 179;
            this.lblAbonos.Text = "...";
            this.lblAbonos.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSaldoVencido
            // 
            this.lblSaldoVencido.AutoSize = true;
            this.lblSaldoVencido.BackColor = System.Drawing.Color.Transparent;
            this.lblSaldoVencido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoVencido.ForeColor = System.Drawing.Color.White;
            this.lblSaldoVencido.Location = new System.Drawing.Point(256, 23);
            this.lblSaldoVencido.Name = "lblSaldoVencido";
            this.lblSaldoVencido.Size = new System.Drawing.Size(19, 13);
            this.lblSaldoVencido.TabIndex = 178;
            this.lblSaldoVencido.Text = "...";
            this.lblSaldoVencido.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.BackColor = System.Drawing.Color.Transparent;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.ForeColor = System.Drawing.Color.White;
            this.lblSaldo.Location = new System.Drawing.Point(148, 23);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(19, 13);
            this.lblSaldo.TabIndex = 177;
            this.lblSaldo.Text = "...";
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblLimite
            // 
            this.lblLimite.AutoSize = true;
            this.lblLimite.BackColor = System.Drawing.Color.Transparent;
            this.lblLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLimite.ForeColor = System.Drawing.Color.White;
            this.lblLimite.Location = new System.Drawing.Point(40, 23);
            this.lblLimite.Name = "lblLimite";
            this.lblLimite.Size = new System.Drawing.Size(19, 13);
            this.lblLimite.TabIndex = 176;
            this.lblLimite.Text = "...";
            this.lblLimite.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(381, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 175;
            this.label4.Text = "Abonos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(251, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 174;
            this.label2.Text = "Saldo vencido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(148, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 173;
            this.label1.Text = "Saldo";
            // 
            // labelEtiqLimite
            // 
            this.labelEtiqLimite.AutoSize = true;
            this.labelEtiqLimite.BackColor = System.Drawing.Color.Transparent;
            this.labelEtiqLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEtiqLimite.ForeColor = System.Drawing.Color.White;
            this.labelEtiqLimite.Location = new System.Drawing.Point(40, 3);
            this.labelEtiqLimite.Name = "labelEtiqLimite";
            this.labelEtiqLimite.Size = new System.Drawing.Size(40, 13);
            this.labelEtiqLimite.TabIndex = 172;
            this.labelEtiqLimite.Text = "Limite";
            // 
            // btnFecha
            // 
            this.btnFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnFecha.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnFecha.ForeColor = System.Drawing.Color.White;
            this.btnFecha.Location = new System.Drawing.Point(441, -1);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(45, 23);
            this.btnFecha.TabIndex = 171;
            this.btnFecha.Text = "Hora:";
            this.btnFecha.UseVisualStyleBackColor = false;
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // lstProductoComplete
            // 
            this.lstProductoComplete.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstProductoComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProductoComplete.FormattingEnabled = true;
            this.lstProductoComplete.ItemHeight = 18;
            this.lstProductoComplete.Location = new System.Drawing.Point(9, 123);
            this.lstProductoComplete.Name = "lstProductoComplete";
            this.lstProductoComplete.Size = new System.Drawing.Size(571, 18);
            this.lstProductoComplete.TabIndex = 25;
            this.lstProductoComplete.Visible = false;
            this.lstProductoComplete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstProductoComplete_MouseClick);
            this.lstProductoComplete.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstProductoComplete_DrawItem);
            this.lstProductoComplete.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstProductoComplete_MeasureItem);
            this.lstProductoComplete.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstProductoComplete_KeyUp);
            // 
            // lbClieNombre
            // 
            this.lbClieNombre.AutoSize = true;
            this.lbClieNombre.BackColor = System.Drawing.Color.Transparent;
            this.lbClieNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieNombre.ForeColor = System.Drawing.Color.White;
            this.lbClieNombre.Location = new System.Drawing.Point(71, 24);
            this.lbClieNombre.Name = "lbClieNombre";
            this.lbClieNombre.Size = new System.Drawing.Size(19, 15);
            this.lbClieNombre.TabIndex = 169;
            this.lbClieNombre.Text = "...";
            this.lbClieNombre.Click += new System.EventHandler(this.lbClieNombre_Click);
            // 
            // btnClearCommand
            // 
            this.btnClearCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnClearCommand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnClearCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCommand.ForeColor = System.Drawing.Color.Firebrick;
            this.btnClearCommand.Location = new System.Drawing.Point(516, 93);
            this.btnClearCommand.Name = "btnClearCommand";
            this.btnClearCommand.Size = new System.Drawing.Size(30, 28);
            this.btnClearCommand.TabIndex = 50;
            this.btnClearCommand.Text = "X";
            this.btnClearCommand.UseVisualStyleBackColor = false;
            this.btnClearCommand.Click += new System.EventHandler(this.btnClearCommand_Click);
            // 
            // LBVenta
            // 
            this.LBVenta.AutoSize = true;
            this.LBVenta.BackColor = System.Drawing.Color.Transparent;
            this.LBVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBVenta.ForeColor = System.Drawing.Color.White;
            this.LBVenta.Location = new System.Drawing.Point(527, 24);
            this.LBVenta.Name = "LBVenta";
            this.LBVenta.Size = new System.Drawing.Size(19, 15);
            this.LBVenta.TabIndex = 23;
            this.LBVenta.Text = "...";
            // 
            // pnlPrecioCaja
            // 
            this.pnlPrecioCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.pnlPrecioCaja.Controls.Add(this.TBPrecioCaja);
            this.pnlPrecioCaja.Controls.Add(this.label16);
            this.pnlPrecioCaja.Location = new System.Drawing.Point(358, 124);
            this.pnlPrecioCaja.Name = "pnlPrecioCaja";
            this.pnlPrecioCaja.Size = new System.Drawing.Size(88, 38);
            this.pnlPrecioCaja.TabIndex = 7;
            // 
            // TBPrecioCaja
            // 
            this.TBPrecioCaja.AllowNegative = true;
            this.TBPrecioCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBPrecioCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPrecioCaja.Format_Expression = null;
            this.TBPrecioCaja.Location = new System.Drawing.Point(0, 13);
            this.TBPrecioCaja.Name = "TBPrecioCaja";
            this.TBPrecioCaja.NumericPrecision = 12;
            this.TBPrecioCaja.NumericScaleOnFocus = 2;
            this.TBPrecioCaja.NumericScaleOnLostFocus = 2;
            this.TBPrecioCaja.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBPrecioCaja.Size = new System.Drawing.Size(76, 29);
            this.TBPrecioCaja.TabIndex = 7;
            this.TBPrecioCaja.Tag = 34;
            this.TBPrecioCaja.Text = "0.00";
            this.TBPrecioCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBPrecioCaja.ValidationExpression = null;
            this.TBPrecioCaja.ZeroIsValid = true;
            this.TBPrecioCaja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBPrecioCaja_KeyDown);
            this.TBPrecioCaja.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBPrecioCaja_PreviewKeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 51;
            this.label16.Text = "Precio x caja";
            // 
            // btnCalculadora
            // 
            this.btnCalculadora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCalculadora.BackgroundImage = global::iPos.Properties.Resources.cash_terminal;
            this.btnCalculadora.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCalculadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculadora.ForeColor = System.Drawing.Color.White;
            this.btnCalculadora.Location = new System.Drawing.Point(450, 128);
            this.btnCalculadora.Name = "btnCalculadora";
            this.btnCalculadora.Size = new System.Drawing.Size(36, 36);
            this.btnCalculadora.TabIndex = 49;
            this.btnCalculadora.UseVisualStyleBackColor = false;
            this.btnCalculadora.Click += new System.EventHandler(this.btnCalculadora_Click);
            // 
            // BTRecalcular
            // 
            this.BTRecalcular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTRecalcular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTRecalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTRecalcular.ForeColor = System.Drawing.Color.White;
            this.BTRecalcular.Location = new System.Drawing.Point(492, 47);
            this.BTRecalcular.Name = "BTRecalcular";
            this.BTRecalcular.Size = new System.Drawing.Size(82, 21);
            this.BTRecalcular.TabIndex = 0;
            this.BTRecalcular.Text = "Re - calcular";
            this.BTRecalcular.UseVisualStyleBackColor = false;
            this.BTRecalcular.Visible = false;
            this.BTRecalcular.Click += new System.EventHandler(this.BTRecalcular_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(440, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "# Transacción:";
            // 
            // clock1
            // 
            this.clock1.BackColor = System.Drawing.Color.Transparent;
            this.clock1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clock1.ForeColor = System.Drawing.Color.White;
            this.clock1.Location = new System.Drawing.Point(468, -1);
            this.clock1.Margin = new System.Windows.Forms.Padding(4);
            this.clock1.Name = "clock1";
            this.clock1.Size = new System.Drawing.Size(106, 25);
            this.clock1.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(337, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "%";
            // 
            // btnCobranzaMovil
            // 
            this.btnCobranzaMovil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCobranzaMovil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCobranzaMovil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobranzaMovil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobranzaMovil.ForeColor = System.Drawing.Color.White;
            this.btnCobranzaMovil.Location = new System.Drawing.Point(340, 2);
            this.btnCobranzaMovil.Name = "btnCobranzaMovil";
            this.btnCobranzaMovil.Size = new System.Drawing.Size(79, 34);
            this.btnCobranzaMovil.TabIndex = 168;
            this.btnCobranzaMovil.Text = "Cobranza";
            this.btnCobranzaMovil.UseVisualStyleBackColor = false;
            this.btnCobranzaMovil.Click += new System.EventHandler(this.btnCobranzaMovil_Click);
            // 
            // TBDescuento
            // 
            this.TBDescuento.AllowNegative = true;
            this.TBDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDescuento.Format_Expression = null;
            this.TBDescuento.Location = new System.Drawing.Point(287, 137);
            this.TBDescuento.Name = "TBDescuento";
            this.TBDescuento.NumericPrecision = 4;
            this.TBDescuento.NumericScaleOnFocus = 2;
            this.TBDescuento.NumericScaleOnLostFocus = 2;
            this.TBDescuento.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBDescuento.ReadOnly = true;
            this.TBDescuento.Size = new System.Drawing.Size(50, 29);
            this.TBDescuento.TabIndex = 6;
            this.TBDescuento.Tag = 34;
            this.TBDescuento.Text = "0.00";
            this.TBDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBDescuento.TratarEnterComoTab = false;
            this.TBDescuento.ValidationExpression = null;
            this.TBDescuento.ZeroIsValid = true;
            this.TBDescuento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBDescuento_KeyDown);
            this.TBDescuento.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBDescuento_PreviewKeyDown);
            this.TBDescuento.Validated += new System.EventHandler(this.TBDescuento_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(439, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "Hora:";
            // 
            // TBPrecio
            // 
            this.TBPrecio.AllowNegative = true;
            this.TBPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPrecio.Format_Expression = null;
            this.TBPrecio.Location = new System.Drawing.Point(189, 137);
            this.TBPrecio.Name = "TBPrecio";
            this.TBPrecio.NumericPrecision = 15;
            this.TBPrecio.NumericScaleOnFocus = 2;
            this.TBPrecio.NumericScaleOnLostFocus = 2;
            this.TBPrecio.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBPrecio.ReadOnly = true;
            this.TBPrecio.Size = new System.Drawing.Size(88, 29);
            this.TBPrecio.TabIndex = 5;
            this.TBPrecio.Tag = 34;
            this.TBPrecio.Text = "0.00";
            this.TBPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBPrecio.TratarEnterComoTab = false;
            this.TBPrecio.ValidationExpression = null;
            this.TBPrecio.ZeroIsValid = true;
            this.TBPrecio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBPrecio_KeyDown);
            this.TBPrecio.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBPrecio_PreviewKeyDown);
            this.TBPrecio.Validated += new System.EventHandler(this.TBPrecio_Validated);
            // 
            // TBCantidad
            // 
            this.TBCantidad.AllowNegative = true;
            this.TBCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCantidad.Format_Expression = null;
            this.TBCantidad.Location = new System.Drawing.Point(96, 137);
            this.TBCantidad.Name = "TBCantidad";
            this.TBCantidad.NumericPrecision = 12;
            this.TBCantidad.NumericScaleOnFocus = 2;
            this.TBCantidad.NumericScaleOnLostFocus = 2;
            this.TBCantidad.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBCantidad.Size = new System.Drawing.Size(76, 29);
            this.TBCantidad.TabIndex = 4;
            this.TBCantidad.Tag = 34;
            this.TBCantidad.Text = "0.00";
            this.TBCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBCantidad.TratarEnterComoTab = false;
            this.TBCantidad.ValidationExpression = null;
            this.TBCantidad.ZeroIsValid = true;
            this.TBCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBCantidad_KeyDown);
            this.TBCantidad.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBCantidad_PreviewKeyDown);
            // 
            // LBCliente
            // 
            this.LBCliente.AutoSize = true;
            this.LBCliente.BackColor = System.Drawing.Color.Transparent;
            this.LBCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCliente.ForeColor = System.Drawing.Color.White;
            this.LBCliente.Location = new System.Drawing.Point(71, 6);
            this.LBCliente.Name = "LBCliente";
            this.LBCliente.Size = new System.Drawing.Size(19, 15);
            this.LBCliente.TabIndex = 21;
            this.LBCliente.Text = "...";
            this.LBCliente.Click += new System.EventHandler(this.LBCliente_Click);
            // 
            // TBCajas
            // 
            this.TBCajas.AllowNegative = true;
            this.TBCajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBCajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCajas.Format_Expression = null;
            this.TBCajas.Location = new System.Drawing.Point(6, 137);
            this.TBCajas.Name = "TBCajas";
            this.TBCajas.NumericPrecision = 12;
            this.TBCajas.NumericScaleOnFocus = 2;
            this.TBCajas.NumericScaleOnLostFocus = 2;
            this.TBCajas.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBCajas.Size = new System.Drawing.Size(76, 29);
            this.TBCajas.TabIndex = 3;
            this.TBCajas.Tag = 34;
            this.TBCajas.Text = "0.00";
            this.TBCajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBCajas.TratarEnterComoTab = false;
            this.TBCajas.ValidationExpression = null;
            this.TBCajas.ZeroIsValid = true;
            this.TBCajas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBCajas_KeyDown);
            this.TBCajas.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBCajas_PreviewKeyDown);
            // 
            // BTCliente
            // 
            this.BTCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCliente.ForeColor = System.Drawing.Color.White;
            this.BTCliente.Location = new System.Drawing.Point(2, 3);
            this.BTCliente.Name = "BTCliente";
            this.BTCliente.Size = new System.Drawing.Size(67, 35);
            this.BTCliente.TabIndex = 1;
            this.BTCliente.Text = "Cliente:";
            this.BTCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCliente.UseVisualStyleBackColor = false;
            this.BTCliente.Click += new System.EventHandler(this.BTCliente_Click);
            // 
            // TBCommandLine
            // 
            this.TBCommandLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCommandLine.Location = new System.Drawing.Point(9, 93);
            this.TBCommandLine.Name = "TBCommandLine";
            this.TBCommandLine.Size = new System.Drawing.Size(501, 29);
            this.TBCommandLine.TabIndex = 2;
            this.TBCommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBCommandLine_KeyDown);
            this.TBCommandLine.Validated += new System.EventHandler(this.TBCommandLine_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(13, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Cliente:";
            // 
            // lblCajas
            // 
            this.lblCajas.AutoSize = true;
            this.lblCajas.BackColor = System.Drawing.Color.Transparent;
            this.lblCajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCajas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCajas.Location = new System.Drawing.Point(6, 124);
            this.lblCajas.Name = "lblCajas";
            this.lblCajas.Size = new System.Drawing.Size(38, 13);
            this.lblCajas.TabIndex = 35;
            this.lblCajas.Text = "Cajas";
            // 
            // LBVendedor
            // 
            this.LBVendedor.AutoSize = true;
            this.LBVendedor.BackColor = System.Drawing.Color.Transparent;
            this.LBVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBVendedor.ForeColor = System.Drawing.Color.Black;
            this.LBVendedor.Location = new System.Drawing.Point(811, 7);
            this.LBVendedor.Name = "LBVendedor";
            this.LBVendedor.Size = new System.Drawing.Size(19, 13);
            this.LBVendedor.TabIndex = 20;
            this.LBVendedor.Text = "...";
            this.LBVendedor.Visible = false;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.tbCurrentItem);
            this.panel8.Location = new System.Drawing.Point(474, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(51, 10);
            this.panel8.TabIndex = 42;
            this.panel8.Visible = false;
            // 
            // tbCurrentItem
            // 
            this.tbCurrentItem.BackColor = System.Drawing.SystemColors.Control;
            this.tbCurrentItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCurrentItem.ForeColor = System.Drawing.Color.Blue;
            this.tbCurrentItem.Location = new System.Drawing.Point(0, 0);
            this.tbCurrentItem.Multiline = true;
            this.tbCurrentItem.Name = "tbCurrentItem";
            this.tbCurrentItem.ReadOnly = true;
            this.tbCurrentItem.Size = new System.Drawing.Size(47, 6);
            this.tbCurrentItem.TabIndex = 24;
            this.tbCurrentItem.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label19.Location = new System.Drawing.Point(11, 79);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Producto";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label24.Location = new System.Drawing.Point(284, 124);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(68, 13);
            this.label24.TabIndex = 33;
            this.label24.Text = "Descuento";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCantidad.Location = new System.Drawing.Point(96, 124);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(57, 13);
            this.lblCantidad.TabIndex = 27;
            this.lblCantidad.Text = "Cantidad";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label20.Location = new System.Drawing.Point(193, 124);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 13);
            this.label20.TabIndex = 29;
            this.label20.Text = "Precio";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PA_NUMERO";
            this.dataGridViewTextBoxColumn5.HeaderText = "PA_NUMERO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "CL_CLIENTE";
            this.dataGridViewTextBoxColumn6.HeaderText = "CL_CLIENTE";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // WFMovilPuntoDeVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ClientSize = new System.Drawing.Size(593, 641);
            this.Controls.Add(this.panelRoot);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1286, 690);
            this.Name = "WFMovilPuntoDeVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PUNTO DE VENTA : BIENVENIDO";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFMovilPuntoDeVenta_FormClosing);
            this.Load += new System.EventHandler(this.WFMovilPuntoDeVenta_Load);
            this.Shown += new System.EventHandler(this.WFMovilPuntoDeVenta_Shown);
            this.SizeChanged += new System.EventHandler(this.WFMovilPuntoDeVenta_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WFMovilPuntoDeVenta_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gRIDPVBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLE_DE_PAGOBindingSource)).EndInit();
            this.panelRoot.ResumeLayout(false);
            this.panelRoot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPVDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.pnlInfoSaldos.ResumeLayout(false);
            this.pnlInfoSaldos.PerformLayout();
            this.pnlPrecioCaja.ResumeLayout(false);
            this.pnlPrecioCaja.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private iPos.PuntoDeVenta.DSPuntoVenta dSPuntoVenta;
        private System.Windows.Forms.BindingSource gridPVBindingSource;
        private iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.GridPVTableAdapter gridPVTableAdapter;
        private iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.TextBox TBCommandLine;
        private System.Windows.Forms.BindingSource dETALLE_DE_PAGOBindingSource;
        private iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.DETALLE_DE_PAGOTableAdapter dETALLE_DE_PAGOTableAdapter;
        private iPos.Tools.Clock clock1;
        private System.Windows.Forms.Label LBCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBVenta;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.TextBox tbCurrentItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LBVendedor;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.NumericTextBox TBPrecio;
        private System.Windows.Forms.Button BTCliente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button BTRecalcular;
        private CustomValidation.RequiredFieldValidator RFVendedorFinal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericTextBox TBDescuento;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericTextBox TBCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panelRoot;
        private System.Windows.Forms.NumericTextBox TBCajas;
        private System.Windows.Forms.Label lblCajas;
        private System.Windows.Forms.Button btnCalculadora;
        private System.Windows.Forms.Panel pnlPrecioCaja;
        private System.Windows.Forms.NumericTextBox TBPrecioCaja;
        private System.Windows.Forms.Label label16;
        private PuntoDeVenta.DSPuntoDeVentaAux dSPuntoDeVentaAux;
        private System.Windows.Forms.BindingSource gRIDPVBindingSource1;
        private PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.GRIDPVTableAdapter gRIDPVTableAdapter1;
        private PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Button btnCobranzaMovil;
        private System.Windows.Forms.Button btnClearCommand;
        private System.Windows.Forms.Label lbClieNombre;
        private System.Windows.Forms.ListBox lstProductoComplete;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.Panel pnlInfoSaldos;
        private System.Windows.Forms.Label lblAbonos;
        private System.Windows.Forms.Label lblSaldoVencido;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblLimite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEtiqLimite;
        private System.Windows.Forms.DataGridViewE gridPVDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOVTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn pARTIDADataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gRIDLINEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GVCANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGDESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIOUNIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TASAIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TASAIEPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCUENTOPORCENTAJE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PORCENTAJEDESCUENTOMANUAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TASAIMPUESTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TITULOSTOTALES;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GVCLAVEPRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTALVALE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEXTO1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEXTO2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEXTO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEXTO4;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEXTO5;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEXTO6;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO4;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMAGEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGALERTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPZACAJA;
        private System.Windows.Forms.DataGridViewTextBoxColumn UTILIDADMOVIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGHEIGHT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button BTValidarExistencia;
        private System.Windows.Forms.Button btnListaAdjuntos;
        private System.Windows.Forms.Button btEditarVenta;
        private System.Windows.Forms.Button btnAdjunto;
        private System.Windows.Forms.Button BTCerrarVenta;
        private System.Windows.Forms.Button BTAbrirVenta;
        private System.Windows.Forms.Button BTPasarANueva;
        private System.Windows.Forms.Button BTAbrirCerradasYDevo;
        private System.Windows.Forms.Button BTCancelarVenta;
        private System.Windows.Forms.Button BTEliminarDetalle;
        private System.Windows.Forms.TextBox TBSumaTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBIva;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox ListaPrecios;
    }
}