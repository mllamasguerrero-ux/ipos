namespace iPos
{
    partial class WFOtrasSalidas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFOtrasSalidas));
            this.gRIDPVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSInventarioFisico3 = new iPos.Inventario.DSInventarioFisico3();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.TimerImageSWF = new System.Windows.Forms.Timer(this.components);
            this.tableAdapterManager = new iPos.Entradas.DSEntradasTableAdapters.TableAdapterManager();
            this.gridPVTableAdapter = new iPos.Inventario.DSInventarioFisico3TableAdapters.GRIDPVTableAdapter();
            this.tableAdapterManager1 = new iPos.Inventario.DSInventarioFisico3TableAdapters.TableAdapterManager();
            this.TBReferencias = new iPos.Tools.TextBoxFB();
            this.REFERENCIASButton = new System.Windows.Forms.Button();
            this.REFERENCIASLabel = new System.Windows.Forms.Label();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.ALMACENComboBox = new System.Windows.Forms.ComboBoxFB();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.CBOrigenFiscal = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TBObservaciones = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.LBTransaccion = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.LBAtendiendo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LBCliente = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbTotalPiezas = new System.Windows.Forms.Label();
            this.lblEtiquetaTotPzas = new System.Windows.Forms.Label();
            this.BTCotizacion = new System.Windows.Forms.Button();
            this.tbCurrentItem = new System.Windows.Forms.TextBox();
            this.LBFecha = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.LBSucursal = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.LBOperacion = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.clock1 = new iPos.Tools.Clock();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LBVendedor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridPVDataGridView = new System.Windows.Forms.DataGridViewE();
            this.DOCTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOVTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pARTIDADataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gRIDLINEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVCANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRIPCIONDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIOUNIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCUENTOPORCENTAJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVCLAVEPRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TASAIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.DGCOSTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPZACAJA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGUNIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TBCommandLine = new System.Windows.Forms.TextBox();
            this.TBCajas = new System.Windows.Forms.NumericTextBox();
            this.lblCajas = new System.Windows.Forms.Label();
            this.btnCalculadora = new System.Windows.Forms.Button();
            this.LBIva = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.TBStatus = new System.Windows.Forms.TextBox();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.TBCosto = new System.Windows.Forms.NumericTextBox();
            this.TBCantidad = new System.Windows.Forms.NumericTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.BTCerrarTransaccion = new System.Windows.Forms.Button();
            this.BTSeleccionarProducto = new System.Windows.Forms.Button();
            this.BTAbrirTransaccion = new System.Windows.Forms.Button();
            this.BTPasarANueva = new System.Windows.Forms.Button();
            this.BTAbrirCerradasYDevo = new System.Windows.Forms.Button();
            this.BTCancelarTransaccion = new System.Windows.Forms.Button();
            this.BTEliminarDetalle = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.TBSumaTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBIva = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TBTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TBPagosTotalTransaccionBig = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNoTransaccion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gRIDPVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico3)).BeginInit();
            this.panel11.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPVDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // gRIDPVBindingSource
            // 
            this.gRIDPVBindingSource.DataMember = "GRIDPV";
            this.gRIDPVBindingSource.DataSource = this.dSInventarioFisico3;
            // 
            // dSInventarioFisico3
            // 
            this.dSInventarioFisico3.DataSetName = "DSInventarioFisico3";
            this.dSInventarioFisico3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // TimerImageSWF
            // 
            this.TimerImageSWF.Enabled = true;
            this.TimerImageSWF.Interval = 15000;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.INVENTARIOSUCURSALTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Entradas.DSEntradasTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gridPVTableAdapter
            // 
            this.gridPVTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = iPos.Inventario.DSInventarioFisico3TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // TBReferencias
            // 
            this.TBReferencias.AccessibleDescription = "";
            this.TBReferencias.BotonLookUp = this.REFERENCIASButton;
            this.TBReferencias.Condicion = null;
            this.TBReferencias.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TBReferencias.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TBReferencias.DbValue = null;
            this.TBReferencias.Format_Expression = null;
            this.TBReferencias.IndiceCampoDescripcion = 2;
            this.TBReferencias.IndiceCampoSelector = 1;
            this.TBReferencias.IndiceCampoValue = 1;
            this.TBReferencias.LabelDescription = this.REFERENCIASLabel;
            this.TBReferencias.Location = new System.Drawing.Point(74, 26);
            this.TBReferencias.MostrarErrores = true;
            this.TBReferencias.Name = "TBReferencias";
            this.TBReferencias.NombreCampoSelector = "clave";
            this.TBReferencias.NombreCampoValue = "clave";
            this.TBReferencias.Query = "select id,clave,nombre from tipotransaccion where sentidoinventario = -1";
            this.TBReferencias.QueryDeSeleccion = "select id,clave,nombre from tipotransaccion where sentidoinventario = -1 and  cla" +
    "ve= @clave";
            this.TBReferencias.QueryPorDBValue = "select id,clave,nombre from tipotransaccion where sentidoinventario = -1 and  cla" +
    "ve = @clave";
            this.TBReferencias.Size = new System.Drawing.Size(117, 20);
            this.TBReferencias.TabIndex = 178;
            this.TBReferencias.Tag = 34;
            this.TBReferencias.TextDescription = null;
            this.TBReferencias.Titulo = "Tipo Transaccion";
            this.TBReferencias.ValidarEntrada = true;
            this.TBReferencias.ValidationExpression = null;
            // 
            // REFERENCIASButton
            // 
            this.REFERENCIASButton.AccessibleDescription = "";
            this.REFERENCIASButton.BackColor = System.Drawing.Color.Transparent;
            this.REFERENCIASButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.REFERENCIASButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.REFERENCIASButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.REFERENCIASButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.REFERENCIASButton.Location = new System.Drawing.Point(197, 26);
            this.REFERENCIASButton.Name = "REFERENCIASButton";
            this.REFERENCIASButton.Size = new System.Drawing.Size(24, 23);
            this.REFERENCIASButton.TabIndex = 179;
            this.REFERENCIASButton.UseVisualStyleBackColor = false;
            // 
            // REFERENCIASLabel
            // 
            this.REFERENCIASLabel.AccessibleDescription = "";
            this.REFERENCIASLabel.AutoSize = true;
            this.REFERENCIASLabel.BackColor = System.Drawing.Color.Transparent;
            this.REFERENCIASLabel.ForeColor = System.Drawing.Color.White;
            this.REFERENCIASLabel.Location = new System.Drawing.Point(227, 32);
            this.REFERENCIASLabel.Name = "REFERENCIASLabel";
            this.REFERENCIASLabel.Size = new System.Drawing.Size(16, 13);
            this.REFERENCIASLabel.TabIndex = 180;
            this.REFERENCIASLabel.Text = "...";
            // 
            // DTPFecha
            // 
            this.DTPFecha.CustomFormat = "dd/MM/yyyy";
            this.DTPFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPFecha.Location = new System.Drawing.Point(701, 58);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(95, 20);
            this.DTPFecha.TabIndex = 173;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(656, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 174;
            this.label13.Text = "Fecha:";
            // 
            // ALMACENComboBox
            // 
            this.ALMACENComboBox.Condicion = null;
            this.ALMACENComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENComboBox.DisplayMember = "nombre";
            this.ALMACENComboBox.FormattingEnabled = true;
            this.ALMACENComboBox.IndiceCampoSelector = 0;
            this.ALMACENComboBox.LabelDescription = null;
            this.ALMACENComboBox.Location = new System.Drawing.Point(74, 55);
            this.ALMACENComboBox.Name = "ALMACENComboBox";
            this.ALMACENComboBox.NombreCampoSelector = "id";
            this.ALMACENComboBox.Query = "select id,nombre from almacen";
            this.ALMACENComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENComboBox.SelectedDataDisplaying = null;
            this.ALMACENComboBox.SelectedDataValue = null;
            this.ALMACENComboBox.Size = new System.Drawing.Size(117, 21);
            this.ALMACENComboBox.TabIndex = 172;
            this.ALMACENComboBox.ValueMember = "id";
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.lblAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacen.ForeColor = System.Drawing.Color.White;
            this.lblAlmacen.Location = new System.Drawing.Point(32, 62);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(40, 13);
            this.lblAlmacen.TabIndex = 171;
            this.lblAlmacen.Text = "ALM.:";
            // 
            // CBOrigenFiscal
            // 
            this.CBOrigenFiscal.FormattingEnabled = true;
            this.CBOrigenFiscal.Items.AddRange(new object[] {
            "Remision",
            "Factura"});
            this.CBOrigenFiscal.Location = new System.Drawing.Point(710, 30);
            this.CBOrigenFiscal.Name = "CBOrigenFiscal";
            this.CBOrigenFiscal.Size = new System.Drawing.Size(140, 21);
            this.CBOrigenFiscal.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(656, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 13);
            this.label19.TabIndex = 53;
            this.label19.Text = "Origen:";
            // 
            // TBObservaciones
            // 
            this.TBObservaciones.Location = new System.Drawing.Point(298, 57);
            this.TBObservaciones.Multiline = true;
            this.TBObservaciones.Name = "TBObservaciones";
            this.TBObservaciones.Size = new System.Drawing.Size(334, 20);
            this.TBObservaciones.TabIndex = 6;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(201, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 13);
            this.label16.TabIndex = 52;
            this.label16.Text = "Observaciones:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(-1, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Referencia:";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.label3);
            this.panel11.Controls.Add(this.LBTransaccion);
            this.panel11.Location = new System.Drawing.Point(597, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(130, 20);
            this.panel11.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Folio:";
            // 
            // LBTransaccion
            // 
            this.LBTransaccion.AutoSize = true;
            this.LBTransaccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.LBTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTransaccion.ForeColor = System.Drawing.Color.Black;
            this.LBTransaccion.Location = new System.Drawing.Point(31, 3);
            this.LBTransaccion.Name = "LBTransaccion";
            this.LBTransaccion.Size = new System.Drawing.Size(19, 13);
            this.LBTransaccion.TabIndex = 23;
            this.LBTransaccion.Text = "...";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.LBAtendiendo);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Location = new System.Drawing.Point(308, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(145, 20);
            this.panel9.TabIndex = 43;
            // 
            // LBAtendiendo
            // 
            this.LBAtendiendo.AutoSize = true;
            this.LBAtendiendo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.LBAtendiendo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBAtendiendo.ForeColor = System.Drawing.Color.Black;
            this.LBAtendiendo.Location = new System.Drawing.Point(37, 1);
            this.LBAtendiendo.Name = "LBAtendiendo";
            this.LBAtendiendo.Size = new System.Drawing.Size(19, 13);
            this.LBAtendiendo.TabIndex = 28;
            this.LBAtendiendo.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Turno:";
            // 
            // LBCliente
            // 
            this.LBCliente.AutoSize = true;
            this.LBCliente.BackColor = System.Drawing.Color.Transparent;
            this.LBCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCliente.ForeColor = System.Drawing.Color.White;
            this.LBCliente.Location = new System.Drawing.Point(822, 65);
            this.LBCliente.Name = "LBCliente";
            this.LBCliente.Size = new System.Drawing.Size(19, 13);
            this.LBCliente.TabIndex = 21;
            this.LBCliente.Text = "...";
            this.LBCliente.Visible = false;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.lbTotalPiezas);
            this.panel8.Controls.Add(this.lblEtiquetaTotPzas);
            this.panel8.Controls.Add(this.BTCotizacion);
            this.panel8.Controls.Add(this.tbCurrentItem);
            this.panel8.Location = new System.Drawing.Point(4, 82);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(844, 38);
            this.panel8.TabIndex = 42;
            // 
            // lbTotalPiezas
            // 
            this.lbTotalPiezas.AutoSize = true;
            this.lbTotalPiezas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.lbTotalPiezas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPiezas.ForeColor = System.Drawing.Color.White;
            this.lbTotalPiezas.Location = new System.Drawing.Point(650, 21);
            this.lbTotalPiezas.Name = "lbTotalPiezas";
            this.lbTotalPiezas.Size = new System.Drawing.Size(19, 13);
            this.lbTotalPiezas.TabIndex = 48;
            this.lbTotalPiezas.Text = "...";
            // 
            // lblEtiquetaTotPzas
            // 
            this.lblEtiquetaTotPzas.AutoSize = true;
            this.lblEtiquetaTotPzas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.lblEtiquetaTotPzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiquetaTotPzas.ForeColor = System.Drawing.Color.White;
            this.lblEtiquetaTotPzas.Location = new System.Drawing.Point(594, 21);
            this.lblEtiquetaTotPzas.Name = "lblEtiquetaTotPzas";
            this.lblEtiquetaTotPzas.Size = new System.Drawing.Size(55, 13);
            this.lblEtiquetaTotPzas.TabIndex = 47;
            this.lblEtiquetaTotPzas.Text = "Tot. Pzas:";
            // 
            // BTCotizacion
            // 
            this.BTCotizacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCotizacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCotizacion.ForeColor = System.Drawing.Color.White;
            this.BTCotizacion.Location = new System.Drawing.Point(773, 0);
            this.BTCotizacion.Name = "BTCotizacion";
            this.BTCotizacion.Size = new System.Drawing.Size(69, 34);
            this.BTCotizacion.TabIndex = 26;
            this.BTCotizacion.Text = "Reimprimir ";
            this.BTCotizacion.UseVisualStyleBackColor = false;
            this.BTCotizacion.Click += new System.EventHandler(this.BTCotizacion_Click);
            // 
            // tbCurrentItem
            // 
            this.tbCurrentItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.tbCurrentItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbCurrentItem.ForeColor = System.Drawing.Color.White;
            this.tbCurrentItem.Location = new System.Drawing.Point(0, 0);
            this.tbCurrentItem.Multiline = true;
            this.tbCurrentItem.Name = "tbCurrentItem";
            this.tbCurrentItem.ReadOnly = true;
            this.tbCurrentItem.Size = new System.Drawing.Size(841, 34);
            this.tbCurrentItem.TabIndex = 24;
            this.tbCurrentItem.TabStop = false;
            // 
            // LBFecha
            // 
            this.LBFecha.AutoSize = true;
            this.LBFecha.BackColor = System.Drawing.Color.Transparent;
            this.LBFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBFecha.ForeColor = System.Drawing.Color.White;
            this.LBFecha.Location = new System.Drawing.Point(802, 65);
            this.LBFecha.Name = "LBFecha";
            this.LBFecha.Size = new System.Drawing.Size(19, 13);
            this.LBFecha.TabIndex = 28;
            this.LBFecha.Text = "...";
            this.LBFecha.Visible = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.LBSucursal);
            this.panel7.Location = new System.Drawing.Point(1, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(153, 20);
            this.panel7.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Sucursal:";
            // 
            // LBSucursal
            // 
            this.LBSucursal.AutoSize = true;
            this.LBSucursal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.LBSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBSucursal.ForeColor = System.Drawing.Color.Black;
            this.LBSucursal.Location = new System.Drawing.Point(60, 2);
            this.LBSucursal.Name = "LBSucursal";
            this.LBSucursal.Size = new System.Drawing.Size(19, 13);
            this.LBSucursal.TabIndex = 20;
            this.LBSucursal.Text = "...";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.LBOperacion);
            this.panel5.Location = new System.Drawing.Point(727, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(123, 20);
            this.panel5.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Operación:";
            // 
            // LBOperacion
            // 
            this.LBOperacion.AutoSize = true;
            this.LBOperacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.LBOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBOperacion.ForeColor = System.Drawing.Color.Black;
            this.LBOperacion.Location = new System.Drawing.Point(65, 3);
            this.LBOperacion.Name = "LBOperacion";
            this.LBOperacion.Size = new System.Drawing.Size(49, 13);
            this.LBOperacion.TabIndex = 26;
            this.LBOperacion.Text = "Compra";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.clock1);
            this.panel4.Location = new System.Drawing.Point(454, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(143, 20);
            this.panel4.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-1, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Hora:";
            // 
            // clock1
            // 
            this.clock1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clock1.Location = new System.Drawing.Point(20, -6);
            this.clock1.Margin = new System.Windows.Forms.Padding(4);
            this.clock1.Name = "clock1";
            this.clock1.Size = new System.Drawing.Size(121, 25);
            this.clock1.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.LBVendedor);
            this.panel3.Location = new System.Drawing.Point(157, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 20);
            this.panel3.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Operador:";
            // 
            // LBVendedor
            // 
            this.LBVendedor.AutoSize = true;
            this.LBVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.LBVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBVendedor.ForeColor = System.Drawing.Color.Black;
            this.LBVendedor.Location = new System.Drawing.Point(59, 1);
            this.LBVendedor.Name = "LBVendedor";
            this.LBVendedor.Size = new System.Drawing.Size(19, 13);
            this.LBVendedor.TabIndex = 20;
            this.LBVendedor.Text = "...";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.gridPVDataGridView);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 501);
            this.panel1.TabIndex = 11;
            // 
            // gridPVDataGridView
            // 
            this.gridPVDataGridView.AllowUserToAddRows = false;
            this.gridPVDataGridView.AllowUserToDeleteRows = false;
            this.gridPVDataGridView.AllowUserToResizeColumns = false;
            this.gridPVDataGridView.AllowUserToResizeRows = false;
            this.gridPVDataGridView.AutoGenerateColumns = false;
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
            this.dESCRIPCIONDataGridViewTextBoxColumn1,
            this.PRECIOUNIDAD,
            this.DGDESC,
            this.DESCUENTOPORCENTAJE,
            this.IMPORTE,
            this.DESCRIPCION2,
            this.LOTE,
            this.GVCLAVEPRODUCTO,
            this.TASAIVA,
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
            this.DGCOSTO,
            this.DGPZACAJA,
            this.DGUNIDAD});
            this.gridPVDataGridView.DataSource = this.gRIDPVBindingSource;
            this.gridPVDataGridView.EnableHeadersVisualStyles = false;
            this.gridPVDataGridView.Location = new System.Drawing.Point(0, 3);
            this.gridPVDataGridView.Name = "gridPVDataGridView";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPVDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridPVDataGridView.RowHeadersVisible = false;
            this.gridPVDataGridView.Size = new System.Drawing.Size(846, 367);
            this.gridPVDataGridView.TabIndex = 7;
            this.gridPVDataGridView.EnterKeyDownEvent += new System.EventHandler(this.gridPVDataGridView_EnterKeyDownEvent);
            this.gridPVDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridPVDataGridView_CellBeginEdit);
            this.gridPVDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPVDataGridView_CellClick);
            this.gridPVDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridPVDataGridView_CellValidating);
            this.gridPVDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPVDataGridView_RowEnter);
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
            this.GVCANTIDAD.Width = 85;
            // 
            // dESCRIPCIONDataGridViewTextBoxColumn1
            // 
            this.dESCRIPCIONDataGridViewTextBoxColumn1.DataPropertyName = "DESCRIPCION";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dESCRIPCIONDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dESCRIPCIONDataGridViewTextBoxColumn1.HeaderText = "DESCRIPCION";
            this.dESCRIPCIONDataGridViewTextBoxColumn1.Name = "dESCRIPCIONDataGridViewTextBoxColumn1";
            this.dESCRIPCIONDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dESCRIPCIONDataGridViewTextBoxColumn1.Width = 450;
            // 
            // PRECIOUNIDAD
            // 
            this.PRECIOUNIDAD.DataPropertyName = "PRECIOUNIDAD";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.PRECIOUNIDAD.DefaultCellStyle = dataGridViewCellStyle3;
            this.PRECIOUNIDAD.HeaderText = "PRECIO";
            this.PRECIOUNIDAD.Name = "PRECIOUNIDAD";
            this.PRECIOUNIDAD.Width = 120;
            // 
            // DGDESC
            // 
            this.DGDESC.DataPropertyName = "DESCUENTO";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0.00";
            this.DGDESC.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGDESC.HeaderText = "DESC";
            this.DGDESC.Name = "DGDESC";
            this.DGDESC.ReadOnly = true;
            this.DGDESC.Visible = false;
            this.DGDESC.Width = 60;
            // 
            // DESCUENTOPORCENTAJE
            // 
            this.DESCUENTOPORCENTAJE.DataPropertyName = "DESCUENTOPORCENTAJE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.DESCUENTOPORCENTAJE.DefaultCellStyle = dataGridViewCellStyle5;
            this.DESCUENTOPORCENTAJE.HeaderText = "%DESC";
            this.DESCUENTOPORCENTAJE.Name = "DESCUENTOPORCENTAJE";
            this.DESCUENTOPORCENTAJE.Width = 60;
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
            // DESCRIPCION2
            // 
            this.DESCRIPCION2.DataPropertyName = "DESCRIPCION2";
            this.DESCRIPCION2.HeaderText = "DESCRIPCION2";
            this.DESCRIPCION2.Name = "DESCRIPCION2";
            this.DESCRIPCION2.ReadOnly = true;
            this.DESCRIPCION2.Visible = false;
            // 
            // LOTE
            // 
            this.LOTE.DataPropertyName = "LOTE";
            this.LOTE.HeaderText = "LOTE";
            this.LOTE.Name = "LOTE";
            this.LOTE.ReadOnly = true;
            this.LOTE.Visible = false;
            // 
            // GVCLAVEPRODUCTO
            // 
            this.GVCLAVEPRODUCTO.DataPropertyName = "CLAVEPRODUCTO";
            this.GVCLAVEPRODUCTO.HeaderText = "CLAVEPRODUCTO";
            this.GVCLAVEPRODUCTO.Name = "GVCLAVEPRODUCTO";
            this.GVCLAVEPRODUCTO.ReadOnly = true;
            this.GVCLAVEPRODUCTO.Visible = false;
            // 
            // TASAIVA
            // 
            this.TASAIVA.DataPropertyName = "TASAIVA";
            this.TASAIVA.HeaderText = "TASAIVA";
            this.TASAIVA.Name = "TASAIVA";
            this.TASAIVA.ReadOnly = true;
            this.TASAIVA.Visible = false;
            // 
            // TEXTO1
            // 
            this.TEXTO1.DataPropertyName = "TEXTO1";
            this.TEXTO1.HeaderText = "TEXTO1";
            this.TEXTO1.Name = "TEXTO1";
            this.TEXTO1.ReadOnly = true;
            // 
            // TEXTO2
            // 
            this.TEXTO2.DataPropertyName = "TEXTO2";
            this.TEXTO2.HeaderText = "TEXTO2";
            this.TEXTO2.Name = "TEXTO2";
            this.TEXTO2.ReadOnly = true;
            // 
            // TEXTO3
            // 
            this.TEXTO3.DataPropertyName = "TEXTO3";
            this.TEXTO3.HeaderText = "TEXTO3";
            this.TEXTO3.Name = "TEXTO3";
            this.TEXTO3.ReadOnly = true;
            // 
            // TEXTO4
            // 
            this.TEXTO4.DataPropertyName = "TEXTO4";
            this.TEXTO4.HeaderText = "TEXTO4";
            this.TEXTO4.Name = "TEXTO4";
            this.TEXTO4.ReadOnly = true;
            // 
            // TEXTO5
            // 
            this.TEXTO5.DataPropertyName = "TEXTO5";
            this.TEXTO5.HeaderText = "TEXTO5";
            this.TEXTO5.Name = "TEXTO5";
            this.TEXTO5.ReadOnly = true;
            // 
            // TEXTO6
            // 
            this.TEXTO6.DataPropertyName = "TEXTO6";
            this.TEXTO6.HeaderText = "TEXTO6";
            this.TEXTO6.Name = "TEXTO6";
            this.TEXTO6.ReadOnly = true;
            // 
            // NUMERO1
            // 
            this.NUMERO1.DataPropertyName = "NUMERO1";
            this.NUMERO1.HeaderText = "NUMERO1";
            this.NUMERO1.Name = "NUMERO1";
            this.NUMERO1.ReadOnly = true;
            // 
            // NUMERO2
            // 
            this.NUMERO2.DataPropertyName = "NUMERO2";
            this.NUMERO2.HeaderText = "NUMERO2";
            this.NUMERO2.Name = "NUMERO2";
            this.NUMERO2.ReadOnly = true;
            // 
            // NUMERO3
            // 
            this.NUMERO3.DataPropertyName = "NUMERO3";
            this.NUMERO3.HeaderText = "NUMERO3";
            this.NUMERO3.Name = "NUMERO3";
            this.NUMERO3.ReadOnly = true;
            // 
            // NUMERO4
            // 
            this.NUMERO4.DataPropertyName = "NUMERO4";
            this.NUMERO4.HeaderText = "NUMERO4";
            this.NUMERO4.Name = "NUMERO4";
            this.NUMERO4.ReadOnly = true;
            // 
            // DGCOSTO
            // 
            this.DGCOSTO.DataPropertyName = "COSTO";
            this.DGCOSTO.HeaderText = "COSTO";
            this.DGCOSTO.Name = "DGCOSTO";
            this.DGCOSTO.ReadOnly = true;
            this.DGCOSTO.Visible = false;
            // 
            // DGPZACAJA
            // 
            this.DGPZACAJA.DataPropertyName = "PZACAJA";
            this.DGPZACAJA.HeaderText = "PZACAJA";
            this.DGPZACAJA.Name = "DGPZACAJA";
            this.DGPZACAJA.ReadOnly = true;
            this.DGPZACAJA.Visible = false;
            // 
            // DGUNIDAD
            // 
            this.DGUNIDAD.DataPropertyName = "UNIDAD";
            this.DGUNIDAD.HeaderText = "UNIDAD";
            this.DGUNIDAD.Name = "DGUNIDAD";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TBCommandLine);
            this.panel2.Controls.Add(this.TBCajas);
            this.panel2.Controls.Add(this.lblCajas);
            this.panel2.Controls.Add(this.btnCalculadora);
            this.panel2.Controls.Add(this.LBIva);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.TBStatus);
            this.panel2.Controls.Add(this.BTEnviar);
            this.panel2.Controls.Add(this.TBCosto);
            this.panel2.Controls.Add(this.TBCantidad);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.lblCantidad);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.TBPagosTotalTransaccionBig);
            this.panel2.Location = new System.Drawing.Point(3, 371);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(843, 127);
            this.panel2.TabIndex = 9;
            // 
            // TBCommandLine
            // 
            this.TBCommandLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCommandLine.Location = new System.Drawing.Point(5, 19);
            this.TBCommandLine.Name = "TBCommandLine";
            this.TBCommandLine.Size = new System.Drawing.Size(210, 24);
            this.TBCommandLine.TabIndex = 10;
            this.TBCommandLine.Enter += new System.EventHandler(this.TBCommandLine_Enter);
            this.TBCommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBCommandLine_KeyDown_1);
            this.TBCommandLine.Leave += new System.EventHandler(this.TBCommandLine_Leave);
            this.TBCommandLine.Validating += new System.ComponentModel.CancelEventHandler(this.TBCommandLine_Validating);
            this.TBCommandLine.Validated += new System.EventHandler(this.TBCommandLine_Validated);
            // 
            // TBCajas
            // 
            this.TBCajas.AllowNegative = true;
            this.TBCajas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBCajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCajas.Format_Expression = null;
            this.TBCajas.Location = new System.Drawing.Point(216, 19);
            this.TBCajas.Name = "TBCajas";
            this.TBCajas.NumericPrecision = 12;
            this.TBCajas.NumericScaleOnFocus = 2;
            this.TBCajas.NumericScaleOnLostFocus = 2;
            this.TBCajas.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBCajas.Size = new System.Drawing.Size(76, 24);
            this.TBCajas.TabIndex = 11;
            this.TBCajas.Tag = 34;
            this.TBCajas.Text = "0.00";
            this.TBCajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBCajas.ValidationExpression = null;
            this.TBCajas.ZeroIsValid = true;
            // 
            // lblCajas
            // 
            this.lblCajas.AutoSize = true;
            this.lblCajas.BackColor = System.Drawing.Color.Transparent;
            this.lblCajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCajas.ForeColor = System.Drawing.Color.White;
            this.lblCajas.Location = new System.Drawing.Point(216, 4);
            this.lblCajas.Name = "lblCajas";
            this.lblCajas.Size = new System.Drawing.Size(38, 13);
            this.lblCajas.TabIndex = 52;
            this.lblCajas.Text = "Cajas";
            // 
            // btnCalculadora
            // 
            this.btnCalculadora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCalculadora.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCalculadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculadora.ForeColor = System.Drawing.Color.White;
            this.btnCalculadora.Image = global::iPos.Properties.Resources.cash_terminal;
            this.btnCalculadora.Location = new System.Drawing.Point(533, 78);
            this.btnCalculadora.Name = "btnCalculadora";
            this.btnCalculadora.Size = new System.Drawing.Size(54, 40);
            this.btnCalculadora.TabIndex = 50;
            this.btnCalculadora.UseVisualStyleBackColor = false;
            this.btnCalculadora.Click += new System.EventHandler(this.btnCalculadora_Click);
            // 
            // LBIva
            // 
            this.LBIva.AutoSize = true;
            this.LBIva.BackColor = System.Drawing.Color.Transparent;
            this.LBIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBIva.ForeColor = System.Drawing.Color.White;
            this.LBIva.Location = new System.Drawing.Point(477, 47);
            this.LBIva.Name = "LBIva";
            this.LBIva.Size = new System.Drawing.Size(28, 18);
            this.LBIva.TabIndex = 31;
            this.LBIva.Text = "0.0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(434, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 13);
            this.label18.TabIndex = 30;
            this.label18.Text = "% IVA";
            // 
            // TBStatus
            // 
            this.TBStatus.BackColor = System.Drawing.SystemColors.Control;
            this.TBStatus.ForeColor = System.Drawing.Color.Blue;
            this.TBStatus.Location = new System.Drawing.Point(5, 44);
            this.TBStatus.Name = "TBStatus";
            this.TBStatus.ReadOnly = true;
            this.TBStatus.Size = new System.Drawing.Size(423, 20);
            this.TBStatus.TabIndex = 27;
            this.TBStatus.TabStop = false;
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(533, 19);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(54, 23);
            this.BTEnviar.TabIndex = 15;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // TBCosto
            // 
            this.TBCosto.AllowNegative = false;
            this.TBCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCosto.Format_Expression = null;
            this.TBCosto.Location = new System.Drawing.Point(386, 19);
            this.TBCosto.Name = "TBCosto";
            this.TBCosto.NumericPrecision = 12;
            this.TBCosto.NumericScaleOnFocus = 2;
            this.TBCosto.NumericScaleOnLostFocus = 2;
            this.TBCosto.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBCosto.Size = new System.Drawing.Size(105, 24);
            this.TBCosto.TabIndex = 13;
            this.TBCosto.Tag = 34;
            this.TBCosto.Text = "0.00";
            this.TBCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBCosto.ValidationExpression = null;
            this.TBCosto.ZeroIsValid = true;
            this.TBCosto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBCommandLine_KeyDown);
            // 
            // TBCantidad
            // 
            this.TBCantidad.AllowNegative = true;
            this.TBCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCantidad.Format_Expression = null;
            this.TBCantidad.Location = new System.Drawing.Point(294, 19);
            this.TBCantidad.Name = "TBCantidad";
            this.TBCantidad.NumericPrecision = 12;
            this.TBCantidad.NumericScaleOnFocus = 2;
            this.TBCantidad.NumericScaleOnLostFocus = 2;
            this.TBCantidad.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBCantidad.Size = new System.Drawing.Size(90, 24);
            this.TBCantidad.TabIndex = 12;
            this.TBCantidad.Tag = 34;
            this.TBCantidad.Text = "0.00";
            this.TBCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBCantidad.ValidationExpression = null;
            this.TBCantidad.ZeroIsValid = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(410, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Costo";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.White;
            this.lblCantidad.Location = new System.Drawing.Point(310, 5);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(57, 13);
            this.lblCantidad.TabIndex = 25;
            this.lblCantidad.Text = "Cantidad";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(7, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Producto";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel10.Controls.Add(this.BTCerrarTransaccion);
            this.panel10.Controls.Add(this.BTSeleccionarProducto);
            this.panel10.Controls.Add(this.BTAbrirTransaccion);
            this.panel10.Controls.Add(this.BTPasarANueva);
            this.panel10.Controls.Add(this.BTAbrirCerradasYDevo);
            this.panel10.Controls.Add(this.BTCancelarTransaccion);
            this.panel10.Controls.Add(this.BTEliminarDetalle);
            this.panel10.Location = new System.Drawing.Point(4, 67);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(424, 58);
            this.panel10.TabIndex = 15;
            // 
            // BTCerrarTransaccion
            // 
            this.BTCerrarTransaccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCerrarTransaccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCerrarTransaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCerrarTransaccion.ForeColor = System.Drawing.Color.White;
            this.BTCerrarTransaccion.Image = global::iPos.Properties.Resources.cash_stack;
            this.BTCerrarTransaccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCerrarTransaccion.Location = new System.Drawing.Point(0, 0);
            this.BTCerrarTransaccion.Name = "BTCerrarTransaccion";
            this.BTCerrarTransaccion.Size = new System.Drawing.Size(105, 27);
            this.BTCerrarTransaccion.TabIndex = 14;
            this.BTCerrarTransaccion.Text = "Terminar (F6)";
            this.BTCerrarTransaccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCerrarTransaccion.UseVisualStyleBackColor = false;
            this.BTCerrarTransaccion.Click += new System.EventHandler(this.BTCerrarTransaccion_Click);
            // 
            // BTSeleccionarProducto
            // 
            this.BTSeleccionarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTSeleccionarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTSeleccionarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTSeleccionarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSeleccionarProducto.ForeColor = System.Drawing.Color.White;
            this.BTSeleccionarProducto.Image = global::iPos.Properties.Resources.Add;
            this.BTSeleccionarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTSeleccionarProducto.Location = new System.Drawing.Point(313, 0);
            this.BTSeleccionarProducto.Name = "BTSeleccionarProducto";
            this.BTSeleccionarProducto.Size = new System.Drawing.Size(105, 27);
            this.BTSeleccionarProducto.TabIndex = 17;
            this.BTSeleccionarProducto.Text = "Producto (F8)";
            this.BTSeleccionarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTSeleccionarProducto.UseVisualStyleBackColor = false;
            this.BTSeleccionarProducto.Click += new System.EventHandler(this.BTSeleccionarProducto_Click);
            // 
            // BTAbrirTransaccion
            // 
            this.BTAbrirTransaccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTAbrirTransaccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTAbrirTransaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAbrirTransaccion.ForeColor = System.Drawing.Color.White;
            this.BTAbrirTransaccion.Image = global::iPos.Properties.Resources.applic_doc;
            this.BTAbrirTransaccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTAbrirTransaccion.Location = new System.Drawing.Point(104, 27);
            this.BTAbrirTransaccion.Name = "BTAbrirTransaccion";
            this.BTAbrirTransaccion.Size = new System.Drawing.Size(105, 27);
            this.BTAbrirTransaccion.TabIndex = 19;
            this.BTAbrirTransaccion.Text = "Pendientes (F4)";
            this.BTAbrirTransaccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTAbrirTransaccion.UseVisualStyleBackColor = false;
            this.BTAbrirTransaccion.Click += new System.EventHandler(this.BTAbrirTransaccion_Click);
            // 
            // BTPasarANueva
            // 
            this.BTPasarANueva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTPasarANueva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTPasarANueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTPasarANueva.ForeColor = System.Drawing.Color.White;
            this.BTPasarANueva.Image = global::iPos.Properties.Resources.doc;
            this.BTPasarANueva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTPasarANueva.Location = new System.Drawing.Point(104, 0);
            this.BTPasarANueva.Name = "BTPasarANueva";
            this.BTPasarANueva.Size = new System.Drawing.Size(105, 27);
            this.BTPasarANueva.TabIndex = 15;
            this.BTPasarANueva.Text = "Nueva (F2)";
            this.BTPasarANueva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTPasarANueva.UseVisualStyleBackColor = false;
            this.BTPasarANueva.Click += new System.EventHandler(this.BTPasarANueva_Click);
            // 
            // BTAbrirCerradasYDevo
            // 
            this.BTAbrirCerradasYDevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTAbrirCerradasYDevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTAbrirCerradasYDevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAbrirCerradasYDevo.ForeColor = System.Drawing.Color.White;
            this.BTAbrirCerradasYDevo.Image = global::iPos.Properties.Resources.doc_find;
            this.BTAbrirCerradasYDevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTAbrirCerradasYDevo.Location = new System.Drawing.Point(208, 27);
            this.BTAbrirCerradasYDevo.Name = "BTAbrirCerradasYDevo";
            this.BTAbrirCerradasYDevo.Size = new System.Drawing.Size(105, 27);
            this.BTAbrirCerradasYDevo.TabIndex = 20;
            this.BTAbrirCerradasYDevo.Text = "Cerradas (F5)";
            this.BTAbrirCerradasYDevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTAbrirCerradasYDevo.UseVisualStyleBackColor = false;
            this.BTAbrirCerradasYDevo.Click += new System.EventHandler(this.BTAbrirCerradasYDevo_Click);
            // 
            // BTCancelarTransaccion
            // 
            this.BTCancelarTransaccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCancelarTransaccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCancelarTransaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelarTransaccion.ForeColor = System.Drawing.Color.White;
            this.BTCancelarTransaccion.Image = global::iPos.Properties.Resources.cancel_doc;
            this.BTCancelarTransaccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCancelarTransaccion.Location = new System.Drawing.Point(208, 0);
            this.BTCancelarTransaccion.Name = "BTCancelarTransaccion";
            this.BTCancelarTransaccion.Size = new System.Drawing.Size(105, 27);
            this.BTCancelarTransaccion.TabIndex = 16;
            this.BTCancelarTransaccion.Text = "Cancelar (F3)";
            this.BTCancelarTransaccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelarTransaccion.UseVisualStyleBackColor = false;
            this.BTCancelarTransaccion.Click += new System.EventHandler(this.BTCancelarTransaccion_Click);
            // 
            // BTEliminarDetalle
            // 
            this.BTEliminarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEliminarDetalle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEliminarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEliminarDetalle.ForeColor = System.Drawing.Color.White;
            this.BTEliminarDetalle.Image = global::iPos.Properties.Resources.remove;
            this.BTEliminarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTEliminarDetalle.Location = new System.Drawing.Point(-1, 27);
            this.BTEliminarDetalle.Name = "BTEliminarDetalle";
            this.BTEliminarDetalle.Size = new System.Drawing.Size(105, 27);
            this.BTEliminarDetalle.TabIndex = 18;
            this.BTEliminarDetalle.Text = "Detalle (F10)";
            this.BTEliminarDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTEliminarDetalle.UseVisualStyleBackColor = false;
            this.BTEliminarDetalle.Click += new System.EventHandler(this.BTEliminarDetalle_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.TBSumaTotal);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.TBIva);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.TBTotal);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Location = new System.Drawing.Point(593, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(251, 123);
            this.panel6.TabIndex = 23;
            // 
            // TBSumaTotal
            // 
            this.TBSumaTotal.BackColor = System.Drawing.SystemColors.Control;
            this.TBSumaTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBSumaTotal.ForeColor = System.Drawing.Color.Black;
            this.TBSumaTotal.Location = new System.Drawing.Point(77, 1);
            this.TBSumaTotal.Name = "TBSumaTotal";
            this.TBSumaTotal.ReadOnly = true;
            this.TBSumaTotal.Size = new System.Drawing.Size(164, 29);
            this.TBSumaTotal.TabIndex = 15;
            this.TBSumaTotal.TabStop = false;
            this.TBSumaTotal.Text = "0.00";
            this.TBSumaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Suma:";
            // 
            // TBIva
            // 
            this.TBIva.BackColor = System.Drawing.SystemColors.Control;
            this.TBIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBIva.ForeColor = System.Drawing.Color.Black;
            this.TBIva.Location = new System.Drawing.Point(77, 33);
            this.TBIva.Name = "TBIva";
            this.TBIva.ReadOnly = true;
            this.TBIva.Size = new System.Drawing.Size(164, 29);
            this.TBIva.TabIndex = 21;
            this.TBIva.TabStop = false;
            this.TBIva.Text = "0.00";
            this.TBIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(29, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "IVA:";
            // 
            // TBTotal
            // 
            this.TBTotal.BackColor = System.Drawing.SystemColors.Control;
            this.TBTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTotal.ForeColor = System.Drawing.Color.Black;
            this.TBTotal.Location = new System.Drawing.Point(77, 67);
            this.TBTotal.Name = "TBTotal";
            this.TBTotal.ReadOnly = true;
            this.TBTotal.Size = new System.Drawing.Size(164, 29);
            this.TBTotal.TabIndex = 22;
            this.TBTotal.TabStop = false;
            this.TBTotal.Text = "0.00";
            this.TBTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(19, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Total:";
            // 
            // TBPagosTotalTransaccionBig
            // 
            this.TBPagosTotalTransaccionBig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.TBPagosTotalTransaccionBig.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPagosTotalTransaccionBig.ForeColor = System.Drawing.Color.White;
            this.TBPagosTotalTransaccionBig.Location = new System.Drawing.Point(454, 78);
            this.TBPagosTotalTransaccionBig.Name = "TBPagosTotalTransaccionBig";
            this.TBPagosTotalTransaccionBig.ReadOnly = true;
            this.TBPagosTotalTransaccionBig.Size = new System.Drawing.Size(64, 40);
            this.TBPagosTotalTransaccionBig.TabIndex = 14;
            this.TBPagosTotalTransaccionBig.TabStop = false;
            this.TBPagosTotalTransaccionBig.Text = "0.00";
            this.TBPagosTotalTransaccionBig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBPagosTotalTransaccionBig.Visible = false;
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
            // btnNoTransaccion
            // 
            this.btnNoTransaccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnNoTransaccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnNoTransaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoTransaccion.ForeColor = System.Drawing.Color.White;
            this.btnNoTransaccion.Location = new System.Drawing.Point(553, 31);
            this.btnNoTransaccion.Name = "btnNoTransaccion";
            this.btnNoTransaccion.Size = new System.Drawing.Size(79, 20);
            this.btnNoTransaccion.TabIndex = 181;
            this.btnNoTransaccion.Text = "# TRANS.";
            this.btnNoTransaccion.UseVisualStyleBackColor = false;
            this.btnNoTransaccion.Click += new System.EventHandler(this.btnNoTransaccion_Click);
            // 
            // WFOtrasSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(859, 626);
            this.Controls.Add(this.btnNoTransaccion);
            this.Controls.Add(this.TBReferencias);
            this.Controls.Add(this.REFERENCIASButton);
            this.Controls.Add(this.REFERENCIASLabel);
            this.Controls.Add(this.DTPFecha);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ALMACENComboBox);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.CBOrigenFiscal);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.TBObservaciones);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.LBCliente);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.LBFecha);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "WFOtrasSalidas";
            this.Text = "SALIDAS";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFPuntoDeTransaccion_FormClosing);
            this.Load += new System.EventHandler(this.WFPuntoDeTransaccion_Load);
            this.Shown += new System.EventHandler(this.WFPuntoDeTransaccion_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WFPuntoDeTransaccion_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gRIDPVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico3)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPVDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private iPos.Entradas.DSEntradasTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewE gridPVDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.TextBox TBCommandLine;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BTSeleccionarProducto;
        private System.Windows.Forms.Button BTPasarANueva;
        private System.Windows.Forms.Button BTCancelarTransaccion;
        private System.Windows.Forms.Button BTAbrirTransaccion;
        private System.Windows.Forms.TextBox TBPagosTotalTransaccionBig;
        private System.Windows.Forms.Button BTCerrarTransaccion;
        //private Skinner.FormSkin formSkin1;
        private System.Windows.Forms.Panel panel1;
        private iPos.Tools.Clock clock1;
        private System.Windows.Forms.Label LBCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBTransaccion;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.TextBox TBSumaTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TBIva;
        private System.Windows.Forms.TextBox TBTotal;
        private System.Windows.Forms.TextBox tbCurrentItem;
        private System.Windows.Forms.Button BTEliminarDetalle;
        private System.Windows.Forms.Button BTAbrirCerradasYDevo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBOperacion;
        private System.Windows.Forms.Timer TimerImageSWF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBVendedor;
        private System.Windows.Forms.Label LBAtendiendo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LBSucursal;
        private System.Windows.Forms.Label LBFecha;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericTextBox TBCosto;
        private System.Windows.Forms.NumericTextBox TBCantidad;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TBObservaciones;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.TextBox TBStatus;
        private System.Windows.Forms.Label LBIva;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox CBOrigenFiscal;
        private System.Windows.Forms.Button BTCotizacion;
        private System.Windows.Forms.Label lbTotalPiezas;
        private System.Windows.Forms.Label lblEtiquetaTotPzas;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.ComboBoxFB ALMACENComboBox;
        private System.Windows.Forms.Button btnCalculadora;
        private System.Windows.Forms.NumericTextBox TBCajas;
        private System.Windows.Forms.Label lblCajas;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOVTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn pARTIDADataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gRIDLINEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GVCANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPCIONDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIOUNIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGDESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCUENTOPORCENTAJE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GVCLAVEPRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TASAIVA;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCOSTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPZACAJA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGUNIDAD;
        private Tools.TextBoxFB TBReferencias;
        private System.Windows.Forms.Button REFERENCIASButton;
        private System.Windows.Forms.Label REFERENCIASLabel;
        private Inventario.DSInventarioFisico3 dSInventarioFisico3;
        private System.Windows.Forms.BindingSource gRIDPVBindingSource;
        private Inventario.DSInventarioFisico3TableAdapters.GRIDPVTableAdapter gridPVTableAdapter;
        private Inventario.DSInventarioFisico3TableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Button btnNoTransaccion;
    }
}