namespace iPos
{
    partial class WFStockProductos
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
            System.Windows.Forms.Label pRODUCTONOMBRELabel;
            System.Windows.Forms.Label pRODUCTODESCRIPCIONLabel;
            System.Windows.Forms.Label LBCantidadStock;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label LBStock;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFStockProductos));
            this.pRODUCTONOMBRETextBox = new System.Windows.Forms.TextBox();
            this.pRODUCTODESCRIPCIONTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dSLocationProducts = new iPos.Inventario.DSLocationProducts();
            this.pRODUCTOLOCATIONSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pRODUCTOLOCATIONSTableAdapter = new iPos.Inventario.DSLocationProductsTableAdapters.PRODUCTOLOCATIONSTableAdapter();
            this.tableAdapterManager = new iPos.Inventario.DSLocationProductsTableAdapters.TableAdapterManager();
            this.MANEJASTOCKTextBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBCapturaPiezas = new System.Windows.Forms.CheckBox();
            this.CBCapturaCajas = new System.Windows.Forms.CheckBox();
            this.lblPza = new System.Windows.Forms.Label();
            this.lblCaja = new System.Windows.Forms.Label();
            this.STOCKCAJAMAXTextBox = new System.Windows.Forms.NumericTextBox();
            this.STOCKCAJAMINTextBox = new System.Windows.Forms.NumericTextBox();
            this.CBSurtirPorCaja = new System.Windows.Forms.CheckBox();
            this.STOCKMAXTextBox = new System.Windows.Forms.NumericTextBox();
            this.STOCKTextBox = new System.Windows.Forms.NumericTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pRODUCTOCONSTOCKDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGSTOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGSTOCKMAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGSURTIRPORCAJA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGSTOCKMINCAJA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGSTOCKMAXCAJA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGSTOCKMINPIEZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGSTOCKMAXPIEZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRODUCTOCONSTOCKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSInventarioFisico = new iPos.Inventario.DSInventarioFisico();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pRODUCTOCONSTOCKTableAdapter = new iPos.Inventario.DSInventarioFisicoTableAdapters.PRODUCTOCONSTOCKTableAdapter();
            this.tableAdapterManager1 = new iPos.Inventario.DSInventarioFisicoTableAdapters.TableAdapterManager();
            pRODUCTONOMBRELabel = new System.Windows.Forms.Label();
            pRODUCTODESCRIPCIONLabel = new System.Windows.Forms.Label();
            LBCantidadStock = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            LBStock = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSLocationProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOLOCATIONSBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOCONSTOCKDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOCONSTOCKBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pRODUCTONOMBRELabel
            // 
            pRODUCTONOMBRELabel.AutoSize = true;
            pRODUCTONOMBRELabel.BackColor = System.Drawing.Color.Transparent;
            pRODUCTONOMBRELabel.ForeColor = System.Drawing.Color.White;
            pRODUCTONOMBRELabel.Location = new System.Drawing.Point(413, 12);
            pRODUCTONOMBRELabel.Name = "pRODUCTONOMBRELabel";
            pRODUCTONOMBRELabel.Size = new System.Drawing.Size(109, 13);
            pRODUCTONOMBRELabel.TabIndex = 22;
            pRODUCTONOMBRELabel.Text = "Producto Nombre:";
            // 
            // pRODUCTODESCRIPCIONLabel
            // 
            pRODUCTODESCRIPCIONLabel.AutoSize = true;
            pRODUCTODESCRIPCIONLabel.BackColor = System.Drawing.Color.Transparent;
            pRODUCTODESCRIPCIONLabel.ForeColor = System.Drawing.Color.White;
            pRODUCTODESCRIPCIONLabel.Location = new System.Drawing.Point(444, 45);
            pRODUCTODESCRIPCIONLabel.Name = "pRODUCTODESCRIPCIONLabel";
            pRODUCTODESCRIPCIONLabel.Size = new System.Drawing.Size(78, 13);
            pRODUCTODESCRIPCIONLabel.TabIndex = 24;
            pRODUCTODESCRIPCIONLabel.Text = "Descripcion:";
            // 
            // LBCantidadStock
            // 
            LBCantidadStock.AutoSize = true;
            LBCantidadStock.BackColor = System.Drawing.Color.Transparent;
            LBCantidadStock.ForeColor = System.Drawing.Color.White;
            LBCantidadStock.Location = new System.Drawing.Point(38, 59);
            LBCantidadStock.Name = "LBCantidadStock";
            LBCantidadStock.Size = new System.Drawing.Size(126, 13);
            LBCantidadStock.TabIndex = 173;
            LBCantidadStock.Text = "Cantidad Stock Min.:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(35, 91);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(129, 13);
            label2.TabIndex = 175;
            label2.Text = "Cantidad Stock Max.:";
            // 
            // LBStock
            // 
            LBStock.AutoSize = true;
            LBStock.BackColor = System.Drawing.Color.Transparent;
            LBStock.ForeColor = System.Drawing.Color.White;
            LBStock.Location = new System.Drawing.Point(478, 80);
            LBStock.Name = "LBStock";
            LBStock.Size = new System.Drawing.Size(44, 13);
            LBStock.TabIndex = 172;
            LBStock.Text = "Stock:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(12, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(249, 18);
            label3.TabIndex = 173;
            label3.Text = "Listados de producto por stock:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.ForeColor = System.Drawing.Color.White;
            label4.Location = new System.Drawing.Point(622, 80);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(91, 13);
            label4.TabIndex = 177;
            label4.Text = "Surtir por caja:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.ForeColor = System.Drawing.Color.White;
            label5.Location = new System.Drawing.Point(12, 145);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(93, 13);
            label5.TabIndex = 183;
            label5.Text = "Capturar cajas:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.ForeColor = System.Drawing.Color.White;
            label7.Location = new System.Drawing.Point(162, 145);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(99, 13);
            label7.TabIndex = 185;
            label7.Text = "Capturar piezas:";
            // 
            // pRODUCTONOMBRETextBox
            // 
            this.pRODUCTONOMBRETextBox.Location = new System.Drawing.Point(528, 10);
            this.pRODUCTONOMBRETextBox.Name = "pRODUCTONOMBRETextBox";
            this.pRODUCTONOMBRETextBox.ReadOnly = true;
            this.pRODUCTONOMBRETextBox.Size = new System.Drawing.Size(206, 20);
            this.pRODUCTONOMBRETextBox.TabIndex = 23;
            // 
            // pRODUCTODESCRIPCIONTextBox
            // 
            this.pRODUCTODESCRIPCIONTextBox.Location = new System.Drawing.Point(528, 42);
            this.pRODUCTODESCRIPCIONTextBox.Name = "pRODUCTODESCRIPCIONTextBox";
            this.pRODUCTODESCRIPCIONTextBox.ReadOnly = true;
            this.pRODUCTODESCRIPCIONTextBox.Size = new System.Drawing.Size(206, 20);
            this.pRODUCTODESCRIPCIONTextBox.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(427, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TBCodigo
            // 
            this.TBCodigo.Location = new System.Drawing.Point(167, 10);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(240, 20);
            this.TBCodigo.TabIndex = 1;
            this.TBCodigo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBCodigo_PreviewKeyDown);
            this.TBCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.TBCodigo_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(114, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Codigo:";
            // 
            // dSLocationProducts
            // 
            this.dSLocationProducts.DataSetName = "DSLocationProducts";
            this.dSLocationProducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pRODUCTOLOCATIONSBindingSource
            // 
            this.pRODUCTOLOCATIONSBindingSource.DataMember = "PRODUCTOLOCATIONS";
            this.pRODUCTOLOCATIONSBindingSource.DataSource = this.dSLocationProducts;
            // 
            // pRODUCTOLOCATIONSTableAdapter
            // 
            this.pRODUCTOLOCATIONSTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Inventario.DSLocationProductsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // MANEJASTOCKTextBox
            // 
            this.MANEJASTOCKTextBox.AutoSize = true;
            this.MANEJASTOCKTextBox.Location = new System.Drawing.Point(528, 81);
            this.MANEJASTOCKTextBox.Name = "MANEJASTOCKTextBox";
            this.MANEJASTOCKTextBox.Size = new System.Drawing.Size(15, 14);
            this.MANEJASTOCKTextBox.TabIndex = 7;
            this.MANEJASTOCKTextBox.UseVisualStyleBackColor = true;
            this.MANEJASTOCKTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MANEJASTOCKTextBox_PreviewKeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.CBCapturaPiezas);
            this.panel1.Controls.Add(label7);
            this.panel1.Controls.Add(this.CBCapturaCajas);
            this.panel1.Controls.Add(label5);
            this.panel1.Controls.Add(this.lblPza);
            this.panel1.Controls.Add(this.lblCaja);
            this.panel1.Controls.Add(this.STOCKCAJAMAXTextBox);
            this.panel1.Controls.Add(this.STOCKCAJAMINTextBox);
            this.panel1.Controls.Add(this.CBSurtirPorCaja);
            this.panel1.Controls.Add(label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(this.TBCodigo);
            this.panel1.Controls.Add(this.STOCKMAXTextBox);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(LBCantidadStock);
            this.panel1.Controls.Add(this.pRODUCTODESCRIPCIONTextBox);
            this.panel1.Controls.Add(this.STOCKTextBox);
            this.panel1.Controls.Add(pRODUCTODESCRIPCIONLabel);
            this.panel1.Controls.Add(this.MANEJASTOCKTextBox);
            this.panel1.Controls.Add(this.pRODUCTONOMBRETextBox);
            this.panel1.Controls.Add(LBStock);
            this.panel1.Controls.Add(pRODUCTONOMBRELabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(777, 169);
            this.panel1.TabIndex = 176;
            // 
            // CBCapturaPiezas
            // 
            this.CBCapturaPiezas.AutoSize = true;
            this.CBCapturaPiezas.Location = new System.Drawing.Point(267, 144);
            this.CBCapturaPiezas.Name = "CBCapturaPiezas";
            this.CBCapturaPiezas.Size = new System.Drawing.Size(15, 14);
            this.CBCapturaPiezas.TabIndex = 184;
            this.CBCapturaPiezas.UseVisualStyleBackColor = true;
            this.CBCapturaPiezas.CheckedChanged += new System.EventHandler(this.CBCapturaPiezas_CheckedChanged);
            // 
            // CBCapturaCajas
            // 
            this.CBCapturaCajas.AutoSize = true;
            this.CBCapturaCajas.Location = new System.Drawing.Point(111, 145);
            this.CBCapturaCajas.Name = "CBCapturaCajas";
            this.CBCapturaCajas.Size = new System.Drawing.Size(15, 14);
            this.CBCapturaCajas.TabIndex = 182;
            this.CBCapturaCajas.UseVisualStyleBackColor = true;
            this.CBCapturaCajas.CheckedChanged += new System.EventHandler(this.CBCapturaCajas_CheckedChanged);
            // 
            // lblPza
            // 
            this.lblPza.AutoSize = true;
            this.lblPza.BackColor = System.Drawing.Color.Transparent;
            this.lblPza.ForeColor = System.Drawing.Color.White;
            this.lblPza.Location = new System.Drawing.Point(312, 36);
            this.lblPza.Name = "lblPza";
            this.lblPza.Size = new System.Drawing.Size(80, 13);
            this.lblPza.TabIndex = 181;
            this.lblPza.Text = "Cant./Piezas";
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.BackColor = System.Drawing.Color.Transparent;
            this.lblCaja.ForeColor = System.Drawing.Color.White;
            this.lblCaja.Location = new System.Drawing.Point(186, 36);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(38, 13);
            this.lblCaja.TabIndex = 180;
            this.lblCaja.Text = "Cajas";
            // 
            // STOCKCAJAMAXTextBox
            // 
            this.STOCKCAJAMAXTextBox.AllowNegative = true;
            this.STOCKCAJAMAXTextBox.Format_Expression = null;
            this.STOCKCAJAMAXTextBox.Location = new System.Drawing.Point(167, 86);
            this.STOCKCAJAMAXTextBox.Name = "STOCKCAJAMAXTextBox";
            this.STOCKCAJAMAXTextBox.NumericPrecision = 18;
            this.STOCKCAJAMAXTextBox.NumericScaleOnFocus = 2;
            this.STOCKCAJAMAXTextBox.NumericScaleOnLostFocus = 2;
            this.STOCKCAJAMAXTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.STOCKCAJAMAXTextBox.Size = new System.Drawing.Size(116, 20);
            this.STOCKCAJAMAXTextBox.TabIndex = 4;
            this.STOCKCAJAMAXTextBox.Tag = 34;
            this.STOCKCAJAMAXTextBox.Text = "0.00";
            this.STOCKCAJAMAXTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.STOCKCAJAMAXTextBox.ValidationExpression = null;
            this.STOCKCAJAMAXTextBox.ZeroIsValid = true;
            this.STOCKCAJAMAXTextBox.Leave += new System.EventHandler(this.STOCKCAJAMAXTextBox_Leave);
            this.STOCKCAJAMAXTextBox.Validated += new System.EventHandler(this.STOCKCAJAMAXTextBox_Validated);
            // 
            // STOCKCAJAMINTextBox
            // 
            this.STOCKCAJAMINTextBox.AllowNegative = true;
            this.STOCKCAJAMINTextBox.Format_Expression = null;
            this.STOCKCAJAMINTextBox.Location = new System.Drawing.Point(167, 54);
            this.STOCKCAJAMINTextBox.Name = "STOCKCAJAMINTextBox";
            this.STOCKCAJAMINTextBox.NumericPrecision = 18;
            this.STOCKCAJAMINTextBox.NumericScaleOnFocus = 2;
            this.STOCKCAJAMINTextBox.NumericScaleOnLostFocus = 2;
            this.STOCKCAJAMINTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.STOCKCAJAMINTextBox.Size = new System.Drawing.Size(116, 20);
            this.STOCKCAJAMINTextBox.TabIndex = 2;
            this.STOCKCAJAMINTextBox.Tag = 34;
            this.STOCKCAJAMINTextBox.Text = "0.00";
            this.STOCKCAJAMINTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.STOCKCAJAMINTextBox.ValidationExpression = null;
            this.STOCKCAJAMINTextBox.ZeroIsValid = true;
            this.STOCKCAJAMINTextBox.Leave += new System.EventHandler(this.STOCKCAJAMINTextBox_Leave);
            this.STOCKCAJAMINTextBox.Validated += new System.EventHandler(this.STOCKCAJAMINTextBox_Validated);
            // 
            // CBSurtirPorCaja
            // 
            this.CBSurtirPorCaja.AutoSize = true;
            this.CBSurtirPorCaja.Location = new System.Drawing.Point(719, 80);
            this.CBSurtirPorCaja.Name = "CBSurtirPorCaja";
            this.CBSurtirPorCaja.Size = new System.Drawing.Size(15, 14);
            this.CBSurtirPorCaja.TabIndex = 8;
            this.CBSurtirPorCaja.UseVisualStyleBackColor = true;
            // 
            // STOCKMAXTextBox
            // 
            this.STOCKMAXTextBox.AllowNegative = true;
            this.STOCKMAXTextBox.Format_Expression = null;
            this.STOCKMAXTextBox.Location = new System.Drawing.Point(289, 86);
            this.STOCKMAXTextBox.Name = "STOCKMAXTextBox";
            this.STOCKMAXTextBox.NumericPrecision = 18;
            this.STOCKMAXTextBox.NumericScaleOnFocus = 2;
            this.STOCKMAXTextBox.NumericScaleOnLostFocus = 2;
            this.STOCKMAXTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.STOCKMAXTextBox.Size = new System.Drawing.Size(116, 20);
            this.STOCKMAXTextBox.TabIndex = 5;
            this.STOCKMAXTextBox.Tag = 34;
            this.STOCKMAXTextBox.Text = "0.00";
            this.STOCKMAXTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.STOCKMAXTextBox.ValidationExpression = null;
            this.STOCKMAXTextBox.ZeroIsValid = true;
            this.STOCKMAXTextBox.Leave += new System.EventHandler(this.STOCKMAXTextBox_Leave);
            // 
            // STOCKTextBox
            // 
            this.STOCKTextBox.AllowNegative = true;
            this.STOCKTextBox.Format_Expression = null;
            this.STOCKTextBox.Location = new System.Drawing.Point(289, 54);
            this.STOCKTextBox.Name = "STOCKTextBox";
            this.STOCKTextBox.NumericPrecision = 18;
            this.STOCKTextBox.NumericScaleOnFocus = 2;
            this.STOCKTextBox.NumericScaleOnLostFocus = 2;
            this.STOCKTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.STOCKTextBox.Size = new System.Drawing.Size(116, 20);
            this.STOCKTextBox.TabIndex = 3;
            this.STOCKTextBox.Tag = 34;
            this.STOCKTextBox.Text = "0.00";
            this.STOCKTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.STOCKTextBox.ValidationExpression = null;
            this.STOCKTextBox.ZeroIsValid = true;
            this.STOCKTextBox.Leave += new System.EventHandler(this.STOCKTextBox_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pRODUCTOCONSTOCKDataGridView);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 169);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(777, 327);
            this.panel2.TabIndex = 177;
            // 
            // pRODUCTOCONSTOCKDataGridView
            // 
            this.pRODUCTOCONSTOCKDataGridView.AllowUserToAddRows = false;
            this.pRODUCTOCONSTOCKDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pRODUCTOCONSTOCKDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pRODUCTOCONSTOCKDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pRODUCTOCONSTOCKDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.DGCLAVE,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.DGSTOCK,
            this.DGSTOCKMAX,
            this.DGSURTIRPORCAJA,
            this.DGSTOCKMINCAJA,
            this.DGSTOCKMAXCAJA,
            this.DGSTOCKMINPIEZA,
            this.DGSTOCKMAXPIEZA});
            this.pRODUCTOCONSTOCKDataGridView.DataSource = this.pRODUCTOCONSTOCKBindingSource;
            this.pRODUCTOCONSTOCKDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRODUCTOCONSTOCKDataGridView.Location = new System.Drawing.Point(0, 22);
            this.pRODUCTOCONSTOCKDataGridView.Name = "pRODUCTOCONSTOCKDataGridView";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pRODUCTOCONSTOCKDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.pRODUCTOCONSTOCKDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            this.pRODUCTOCONSTOCKDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.pRODUCTOCONSTOCKDataGridView.Size = new System.Drawing.Size(777, 305);
            this.pRODUCTOCONSTOCKDataGridView.TabIndex = 1;
            this.pRODUCTOCONSTOCKDataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.pRODUCTOCONSTOCKDataGridView_CellValidated);
            this.pRODUCTOCONSTOCKDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.pRODUCTOCONSTOCKDataGridView_CellValidating);
            this.pRODUCTOCONSTOCKDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.pRODUCTOCONSTOCKDataGridView_DataError);
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.ReadOnly = true;
            this.DGID.Visible = false;
            // 
            // DGCLAVE
            // 
            this.DGCLAVE.DataPropertyName = "CLAVE";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.DGCLAVE.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGCLAVE.HeaderText = "CLAVE";
            this.DGCLAVE.Name = "DGCLAVE";
            this.DGCLAVE.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NOMBRE";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 140;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DESCRIPCION1";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DESCRIPCION2";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn5.HeaderText = "DESCRIPCION2";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DESCRIPCION3";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn6.HeaderText = "DESCRIPCION3";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MANEJASTOCK";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn7.HeaderText = "MS";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 30;
            // 
            // DGSTOCK
            // 
            this.DGSTOCK.DataPropertyName = "STOCK";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.DGSTOCK.DefaultCellStyle = dataGridViewCellStyle8;
            this.DGSTOCK.HeaderText = "STOCK";
            this.DGSTOCK.Name = "DGSTOCK";
            this.DGSTOCK.Width = 75;
            // 
            // DGSTOCKMAX
            // 
            this.DGSTOCKMAX.DataPropertyName = "STOCKMAX";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.DGSTOCKMAX.DefaultCellStyle = dataGridViewCellStyle9;
            this.DGSTOCKMAX.HeaderText = "STOCKMAX";
            this.DGSTOCKMAX.Name = "DGSTOCKMAX";
            this.DGSTOCKMAX.Width = 75;
            // 
            // DGSURTIRPORCAJA
            // 
            this.DGSURTIRPORCAJA.DataPropertyName = "SURTIRPORCAJA";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.NullValue = false;
            this.DGSURTIRPORCAJA.DefaultCellStyle = dataGridViewCellStyle10;
            this.DGSURTIRPORCAJA.FalseValue = "N";
            this.DGSURTIRPORCAJA.HeaderText = "x Caja";
            this.DGSURTIRPORCAJA.Name = "DGSURTIRPORCAJA";
            this.DGSURTIRPORCAJA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGSURTIRPORCAJA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGSURTIRPORCAJA.TrueValue = "S";
            this.DGSURTIRPORCAJA.Width = 35;
            // 
            // DGSTOCKMINCAJA
            // 
            this.DGSTOCKMINCAJA.DataPropertyName = "STOCKMINCAJA";
            this.DGSTOCKMINCAJA.HeaderText = "STOCK MIN CAJA";
            this.DGSTOCKMINCAJA.Name = "DGSTOCKMINCAJA";
            this.DGSTOCKMINCAJA.Width = 60;
            // 
            // DGSTOCKMAXCAJA
            // 
            this.DGSTOCKMAXCAJA.DataPropertyName = "STOCKMAXCAJA";
            this.DGSTOCKMAXCAJA.HeaderText = "STOCK MAX CAJA";
            this.DGSTOCKMAXCAJA.Name = "DGSTOCKMAXCAJA";
            this.DGSTOCKMAXCAJA.Width = 60;
            // 
            // DGSTOCKMINPIEZA
            // 
            this.DGSTOCKMINPIEZA.DataPropertyName = "STOCKMINPIEZA";
            this.DGSTOCKMINPIEZA.HeaderText = "STOCK MIN PZA";
            this.DGSTOCKMINPIEZA.Name = "DGSTOCKMINPIEZA";
            this.DGSTOCKMINPIEZA.Width = 80;
            // 
            // DGSTOCKMAXPIEZA
            // 
            this.DGSTOCKMAXPIEZA.DataPropertyName = "STOCKMAXPIEZA";
            this.DGSTOCKMAXPIEZA.HeaderText = "STOCK MAX PZA";
            this.DGSTOCKMAXPIEZA.Name = "DGSTOCKMAXPIEZA";
            this.DGSTOCKMAXPIEZA.Width = 80;
            // 
            // pRODUCTOCONSTOCKBindingSource
            // 
            this.pRODUCTOCONSTOCKBindingSource.DataMember = "PRODUCTOCONSTOCK";
            this.pRODUCTOCONSTOCKBindingSource.DataSource = this.dSInventarioFisico;
            // 
            // dSInventarioFisico
            // 
            this.dSInventarioFisico.DataSetName = "DSInventarioFisico";
            this.dSInventarioFisico.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(777, 22);
            this.panel3.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NOMBRE";
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn2.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "STOCKMAX";
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn8.HeaderText = "STOCKMAX";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "SURTIRPORCAJA";
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn9.HeaderText = "SURTIR X CAJA";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Text = "Eliminar";
            // 
            // pRODUCTOCONSTOCKTableAdapter
            // 
            this.pRODUCTOCONSTOCKTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = iPos.Inventario.DSInventarioFisicoTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFStockProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(777, 496);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFStockProductos";
            this.Text = "Stock de productos";
            this.Load += new System.EventHandler(this.WFStockProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSLocationProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOLOCATIONSBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOCONSTOCKDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOCONSTOCKBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox pRODUCTONOMBRETextBox;
        private System.Windows.Forms.TextBox pRODUCTODESCRIPCIONTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.Label label1;
        private Inventario.DSLocationProducts dSLocationProducts;
        private System.Windows.Forms.BindingSource pRODUCTOLOCATIONSBindingSource;
        private Inventario.DSLocationProductsTableAdapters.PRODUCTOLOCATIONSTableAdapter pRODUCTOLOCATIONSTableAdapter;
        private Inventario.DSLocationProductsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.NumericTextBox STOCKTextBox;
        private System.Windows.Forms.NumericTextBox STOCKMAXTextBox;
        private System.Windows.Forms.CheckBox MANEJASTOCKTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Inventario.DSInventarioFisico dSInventarioFisico;
        private System.Windows.Forms.BindingSource pRODUCTOCONSTOCKBindingSource;
        private Inventario.DSInventarioFisicoTableAdapters.PRODUCTOCONSTOCKTableAdapter pRODUCTOCONSTOCKTableAdapter;
        private Inventario.DSInventarioFisicoTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.DataGridViewSum pRODUCTOCONSTOCKDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.CheckBox CBSurtirPorCaja;
        private System.Windows.Forms.Label lblPza;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.NumericTextBox STOCKCAJAMAXTextBox;
        private System.Windows.Forms.NumericTextBox STOCKCAJAMINTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGSTOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGSTOCKMAX;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGSURTIRPORCAJA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGSTOCKMINCAJA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGSTOCKMAXCAJA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGSTOCKMINPIEZA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGSTOCKMAXPIEZA;
        private System.Windows.Forms.CheckBox CBCapturaPiezas;
        private System.Windows.Forms.CheckBox CBCapturaCajas;
    }
}