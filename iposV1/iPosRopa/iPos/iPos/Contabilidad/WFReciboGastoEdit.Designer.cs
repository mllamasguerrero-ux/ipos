namespace iPos
{
    partial class WFReciboGastoEdit
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
            System.Windows.Forms.Label mARCAIDLabel;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFReciboGastoEdit));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gRIDPVGASTODataGridView = new System.Windows.Forms.DataGridViewE();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.TBMonto = new System.Windows.Forms.NumericTextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.pnlCorteSeleccion = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.CBCorteActual = new System.Windows.Forms.CheckBox();
            this.GASTOButton = new System.Windows.Forms.Button();
            this.GASTOIDTextBox = new iPos.Tools.TextBoxFB();
            this.GASTOLabel = new System.Windows.Forms.Label();
            this.LBFolio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.CBCajero = new System.Windows.Forms.ComboBoxFB();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.TBObservaciones = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.CBOrigenFiscal = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.ALMACENComboBox = new System.Windows.Forms.ComboBoxFB();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAlmacen = new System.Windows.Forms.Panel();
            this.CENTROCOSTOButton = new System.Windows.Forms.Button();
            this.CENTROCOSTOIDTextBox = new iPos.Tools.TextBoxFB();
            this.CENTROCOSTOLabel = new System.Windows.Forms.Label();
            this.gRIDPVGASTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSContabilidad = new iPos.Contabilidad.DSContabilidad();
            this.gRIDPVGASTOTableAdapter = new iPos.Contabilidad.DSContabilidadTableAdapters.GRIDPVGASTOTableAdapter();
            this.tableAdapterManager = new iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGGASTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCENTROCOSTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCENTROCOSTOCLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCENTROCOSTONOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGELIMINAR = new System.Windows.Forms.DataGridViewButtonColumn();
            mARCAIDLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gRIDPVGASTODataGridView)).BeginInit();
            this.pnlCorteSeleccion.SuspendLayout();
            this.pnlAlmacen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gRIDPVGASTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad)).BeginInit();
            this.SuspendLayout();
            // 
            // mARCAIDLabel
            // 
            mARCAIDLabel.AutoSize = true;
            mARCAIDLabel.BackColor = System.Drawing.Color.Transparent;
            mARCAIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mARCAIDLabel.ForeColor = System.Drawing.Color.White;
            mARCAIDLabel.Location = new System.Drawing.Point(39, 101);
            mARCAIDLabel.Name = "mARCAIDLabel";
            mARCAIDLabel.Size = new System.Drawing.Size(44, 13);
            mARCAIDLabel.TabIndex = 158;
            mARCAIDLabel.Text = "Gasto:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.ForeColor = System.Drawing.Color.White;
            label7.Location = new System.Drawing.Point(420, 25);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(83, 13);
            label7.TabIndex = 180;
            label7.Text = "Centro costo:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(441, 449);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 32);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gRIDPVGASTODataGridView
            // 
            this.gRIDPVGASTODataGridView.AllowUserToAddRows = false;
            this.gRIDPVGASTODataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gRIDPVGASTODataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gRIDPVGASTODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gRIDPVGASTODataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.dataGridViewTextBoxColumn2,
            this.DGGASTOID,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.DGCENTROCOSTOID,
            this.DGCENTROCOSTOCLAVE,
            this.DGCENTROCOSTONOMBRE,
            this.DGTOTAL,
            this.DGELIMINAR});
            this.gRIDPVGASTODataGridView.DataSource = this.gRIDPVGASTOBindingSource;
            this.gRIDPVGASTODataGridView.Location = new System.Drawing.Point(28, 153);
            this.gRIDPVGASTODataGridView.Name = "gRIDPVGASTODataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gRIDPVGASTODataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gRIDPVGASTODataGridView.RowHeadersVisible = false;
            this.gRIDPVGASTODataGridView.Size = new System.Drawing.Size(878, 220);
            this.gRIDPVGASTODataGridView.TabIndex = 8;
            this.gRIDPVGASTODataGridView.EnterKeyDownEvent += new System.EventHandler(this.gRIDPVGASTODataGridView_EnterKeyDownEvent);
            this.gRIDPVGASTODataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gRIDPVGASTODataGridView_CellContentClick);
            this.gRIDPVGASTODataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gRIDPVGASTODataGridView_CellValidating);
            this.gRIDPVGASTODataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gRIDPVGASTODataGridView_DataError);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(124, 449);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(123, 32);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(746, 111);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(78, 28);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // TBMonto
            // 
            this.TBMonto.AllowNegative = true;
            this.TBMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMonto.Format_Expression = null;
            this.TBMonto.Location = new System.Drawing.Point(421, 118);
            this.TBMonto.Name = "TBMonto";
            this.TBMonto.NumericPrecision = 12;
            this.TBMonto.NumericScaleOnFocus = 2;
            this.TBMonto.NumericScaleOnLostFocus = 2;
            this.TBMonto.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBMonto.Size = new System.Drawing.Size(120, 24);
            this.TBMonto.TabIndex = 6;
            this.TBMonto.Tag = 34;
            this.TBMonto.Text = "0.00";
            this.TBMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMonto.ValidationExpression = null;
            this.TBMonto.ZeroIsValid = true;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.White;
            this.lblCantidad.Location = new System.Drawing.Point(421, 101);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(46, 13);
            this.lblCantidad.TabIndex = 162;
            this.lblCantidad.Text = "Monto:";
            // 
            // pnlCorteSeleccion
            // 
            this.pnlCorteSeleccion.BackColor = System.Drawing.Color.Transparent;
            this.pnlCorteSeleccion.Controls.Add(this.label4);
            this.pnlCorteSeleccion.Controls.Add(this.CBCorteActual);
            this.pnlCorteSeleccion.Location = new System.Drawing.Point(418, 59);
            this.pnlCorteSeleccion.Name = "pnlCorteSeleccion";
            this.pnlCorteSeleccion.Size = new System.Drawing.Size(123, 25);
            this.pnlCorteSeleccion.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Corte Actual:";
            // 
            // CBCorteActual
            // 
            this.CBCorteActual.AutoSize = true;
            this.CBCorteActual.Checked = true;
            this.CBCorteActual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBCorteActual.Location = new System.Drawing.Point(90, 4);
            this.CBCorteActual.Name = "CBCorteActual";
            this.CBCorteActual.Size = new System.Drawing.Size(15, 14);
            this.CBCorteActual.TabIndex = 3;
            this.CBCorteActual.UseVisualStyleBackColor = true;
            // 
            // GASTOButton
            // 
            this.GASTOButton.BackColor = System.Drawing.Color.Transparent;
            this.GASTOButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.GASTOButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GASTOButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GASTOButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.GASTOButton.Location = new System.Drawing.Point(134, 119);
            this.GASTOButton.Name = "GASTOButton";
            this.GASTOButton.Size = new System.Drawing.Size(21, 23);
            this.GASTOButton.TabIndex = 5;
            this.GASTOButton.UseVisualStyleBackColor = false;
            this.GASTOButton.Click += new System.EventHandler(this.GASTOButton_Click);
            // 
            // GASTOIDTextBox
            // 
            this.GASTOIDTextBox.BotonLookUp = null;
            this.GASTOIDTextBox.Condicion = null;
            this.GASTOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GASTOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GASTOIDTextBox.DbValue = null;
            this.GASTOIDTextBox.Format_Expression = null;
            this.GASTOIDTextBox.IndiceCampoDescripcion = 2;
            this.GASTOIDTextBox.IndiceCampoSelector = 1;
            this.GASTOIDTextBox.IndiceCampoValue = 0;
            this.GASTOIDTextBox.LabelDescription = this.GASTOLabel;
            this.GASTOIDTextBox.Location = new System.Drawing.Point(42, 119);
            this.GASTOIDTextBox.MostrarErrores = true;
            this.GASTOIDTextBox.Name = "GASTOIDTextBox";
            this.GASTOIDTextBox.NombreCampoSelector = "clave";
            this.GASTOIDTextBox.NombreCampoValue = "id";
            this.GASTOIDTextBox.Query = "select id,clave,nombre from gasto";
            this.GASTOIDTextBox.QueryDeSeleccion = "select id,clave,nombre from gasto where clave = @clave";
            this.GASTOIDTextBox.QueryPorDBValue = "select id,clave,nombre from gasto where id = @id";
            this.GASTOIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.GASTOIDTextBox.TabIndex = 4;
            this.GASTOIDTextBox.Tag = 34;
            this.GASTOIDTextBox.TextDescription = null;
            this.GASTOIDTextBox.Titulo = "Gastos";
            this.GASTOIDTextBox.ValidarEntrada = true;
            this.GASTOIDTextBox.ValidationExpression = null;
            // 
            // GASTOLabel
            // 
            this.GASTOLabel.AutoSize = true;
            this.GASTOLabel.BackColor = System.Drawing.Color.Transparent;
            this.GASTOLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GASTOLabel.Location = new System.Drawing.Point(161, 122);
            this.GASTOLabel.Name = "GASTOLabel";
            this.GASTOLabel.Size = new System.Drawing.Size(16, 13);
            this.GASTOLabel.TabIndex = 159;
            this.GASTOLabel.Text = "...";
            // 
            // LBFolio
            // 
            this.LBFolio.AutoSize = true;
            this.LBFolio.BackColor = System.Drawing.Color.Transparent;
            this.LBFolio.ForeColor = System.Drawing.Color.White;
            this.LBFolio.Location = new System.Drawing.Point(87, 27);
            this.LBFolio.Name = "LBFolio";
            this.LBFolio.Size = new System.Drawing.Size(16, 13);
            this.LBFolio.TabIndex = 23;
            this.LBFolio.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Folio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(39, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Fecha corte:";
            // 
            // DTPFecha
            // 
            this.DTPFecha.AccessibleDescription = "resizeforscreen";
            this.DTPFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPFecha.Location = new System.Drawing.Point(124, 58);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(247, 20);
            this.DTPFecha.TabIndex = 1;
            this.DTPFecha.Validating += new System.ComponentModel.CancelEventHandler(this.DTPFecha_Validating);
            // 
            // CBCajero
            // 
            this.CBCajero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.CBCajero.Condicion = null;
            this.CBCajero.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CBCajero.DisplayMember = "NOMBRE";
            this.CBCajero.FormattingEnabled = true;
            this.CBCajero.IndiceCampoSelector = 0;
            this.CBCajero.LabelDescription = null;
            this.CBCajero.Location = new System.Drawing.Point(201, 22);
            this.CBCajero.Name = "CBCajero";
            this.CBCajero.NombreCampoSelector = null;
            this.CBCajero.Query = "select ID,USERNAME as NOMBRE from persona where ACTIVO = \'S\' and username is not " +
    "null";
            this.CBCajero.QueryDeSeleccion = null;
            this.CBCajero.SelectedDataDisplaying = null;
            this.CBCajero.SelectedDataValue = null;
            this.CBCajero.Size = new System.Drawing.Size(170, 21);
            this.CBCajero.TabIndex = 164;
            this.CBCajero.ValueMember = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(153, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 163;
            this.label3.Text = "Cajero:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(288, 451);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(108, 30);
            this.btnImprimir.TabIndex = 168;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // TBObservaciones
            // 
            this.TBObservaciones.Location = new System.Drawing.Point(194, 388);
            this.TBObservaciones.Multiline = true;
            this.TBObservaciones.Name = "TBObservaciones";
            this.TBObservaciones.Size = new System.Drawing.Size(315, 30);
            this.TBObservaciones.TabIndex = 169;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(99, 391);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 13);
            this.label16.TabIndex = 170;
            this.label16.Text = "Observaciones:";
            // 
            // CBOrigenFiscal
            // 
            this.CBOrigenFiscal.FormattingEnabled = true;
            this.CBOrigenFiscal.Items.AddRange(new object[] {
            "No fiscal",
            "Fiscal"});
            this.CBOrigenFiscal.Location = new System.Drawing.Point(826, 62);
            this.CBOrigenFiscal.Name = "CBOrigenFiscal";
            this.CBOrigenFiscal.Size = new System.Drawing.Size(116, 21);
            this.CBOrigenFiscal.TabIndex = 171;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(742, 65);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 13);
            this.label19.TabIndex = 172;
            this.label19.Text = "Origen fiscal:";
            // 
            // ALMACENComboBox
            // 
            this.ALMACENComboBox.Condicion = null;
            this.ALMACENComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENComboBox.DisplayMember = "nombre";
            this.ALMACENComboBox.FormattingEnabled = true;
            this.ALMACENComboBox.IndiceCampoSelector = 0;
            this.ALMACENComboBox.LabelDescription = null;
            this.ALMACENComboBox.Location = new System.Drawing.Point(66, 1);
            this.ALMACENComboBox.Name = "ALMACENComboBox";
            this.ALMACENComboBox.NombreCampoSelector = "id";
            this.ALMACENComboBox.Query = "select id,nombre from almacen";
            this.ALMACENComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENComboBox.SelectedDataDisplaying = null;
            this.ALMACENComboBox.SelectedDataValue = null;
            this.ALMACENComboBox.Size = new System.Drawing.Size(131, 21);
            this.ALMACENComboBox.TabIndex = 175;
            this.ALMACENComboBox.ValueMember = "id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 174;
            this.label2.Text = "Almacen:";
            // 
            // pnlAlmacen
            // 
            this.pnlAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.pnlAlmacen.Controls.Add(this.ALMACENComboBox);
            this.pnlAlmacen.Controls.Add(this.label2);
            this.pnlAlmacen.Location = new System.Drawing.Point(744, 22);
            this.pnlAlmacen.Name = "pnlAlmacen";
            this.pnlAlmacen.Size = new System.Drawing.Size(200, 29);
            this.pnlAlmacen.TabIndex = 176;
            // 
            // CENTROCOSTOButton
            // 
            this.CENTROCOSTOButton.BackColor = System.Drawing.Color.Transparent;
            this.CENTROCOSTOButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.CENTROCOSTOButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CENTROCOSTOButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CENTROCOSTOButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.CENTROCOSTOButton.Location = new System.Drawing.Point(588, 23);
            this.CENTROCOSTOButton.Name = "CENTROCOSTOButton";
            this.CENTROCOSTOButton.Size = new System.Drawing.Size(21, 23);
            this.CENTROCOSTOButton.TabIndex = 178;
            this.CENTROCOSTOButton.UseVisualStyleBackColor = false;
            // 
            // CENTROCOSTOIDTextBox
            // 
            this.CENTROCOSTOIDTextBox.BotonLookUp = this.CENTROCOSTOButton;
            this.CENTROCOSTOIDTextBox.Condicion = null;
            this.CENTROCOSTOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CENTROCOSTOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CENTROCOSTOIDTextBox.DbValue = null;
            this.CENTROCOSTOIDTextBox.Format_Expression = null;
            this.CENTROCOSTOIDTextBox.IndiceCampoDescripcion = 2;
            this.CENTROCOSTOIDTextBox.IndiceCampoSelector = 1;
            this.CENTROCOSTOIDTextBox.IndiceCampoValue = 0;
            this.CENTROCOSTOIDTextBox.LabelDescription = this.CENTROCOSTOLabel;
            this.CENTROCOSTOIDTextBox.Location = new System.Drawing.Point(505, 23);
            this.CENTROCOSTOIDTextBox.MostrarErrores = true;
            this.CENTROCOSTOIDTextBox.Name = "CENTROCOSTOIDTextBox";
            this.CENTROCOSTOIDTextBox.NombreCampoSelector = "clave";
            this.CENTROCOSTOIDTextBox.NombreCampoValue = "id";
            this.CENTROCOSTOIDTextBox.Query = "select id,clave,nombre from centrocosto";
            this.CENTROCOSTOIDTextBox.QueryDeSeleccion = "select id,clave,nombre from centrocosto where clave = @clave";
            this.CENTROCOSTOIDTextBox.QueryPorDBValue = "select id,clave,nombre from centrocosto where id = @id";
            this.CENTROCOSTOIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.CENTROCOSTOIDTextBox.TabIndex = 177;
            this.CENTROCOSTOIDTextBox.Tag = 34;
            this.CENTROCOSTOIDTextBox.TextDescription = null;
            this.CENTROCOSTOIDTextBox.Titulo = "Centro costo";
            this.CENTROCOSTOIDTextBox.ValidarEntrada = true;
            this.CENTROCOSTOIDTextBox.ValidationExpression = null;
            // 
            // CENTROCOSTOLabel
            // 
            this.CENTROCOSTOLabel.AutoSize = true;
            this.CENTROCOSTOLabel.BackColor = System.Drawing.Color.Transparent;
            this.CENTROCOSTOLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CENTROCOSTOLabel.Location = new System.Drawing.Point(615, 26);
            this.CENTROCOSTOLabel.Name = "CENTROCOSTOLabel";
            this.CENTROCOSTOLabel.Size = new System.Drawing.Size(16, 13);
            this.CENTROCOSTOLabel.TabIndex = 179;
            this.CENTROCOSTOLabel.Text = "...";
            // 
            // gRIDPVGASTOBindingSource
            // 
            this.gRIDPVGASTOBindingSource.DataMember = "GRIDPVGASTO";
            this.gRIDPVGASTOBindingSource.DataSource = this.dSContabilidad;
            // 
            // dSContabilidad
            // 
            this.dSContabilidad.DataSetName = "DSContabilidad";
            this.dSContabilidad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gRIDPVGASTOTableAdapter
            // 
            this.gRIDPVGASTOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PARTIDA";
            this.dataGridViewTextBoxColumn2.HeaderText = "PARTIDA";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // DGGASTOID
            // 
            this.DGGASTOID.DataPropertyName = "GASTOID";
            this.DGGASTOID.HeaderText = "GASTOID";
            this.DGGASTOID.Name = "DGGASTOID";
            this.DGGASTOID.ReadOnly = true;
            this.DGGASTOID.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "GASTOCLAVE";
            this.dataGridViewTextBoxColumn4.HeaderText = "GASTO CLAVE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "GASTONOMBRE";
            this.dataGridViewTextBoxColumn5.HeaderText = "GASTO NOMBRE";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // DGCENTROCOSTOID
            // 
            this.DGCENTROCOSTOID.DataPropertyName = "CENTROCOSTOID";
            this.DGCENTROCOSTOID.HeaderText = "CENTROCOSTOID";
            this.DGCENTROCOSTOID.Name = "DGCENTROCOSTOID";
            this.DGCENTROCOSTOID.Visible = false;
            // 
            // DGCENTROCOSTOCLAVE
            // 
            this.DGCENTROCOSTOCLAVE.DataPropertyName = "CENTROCOSTOCLAVE";
            this.DGCENTROCOSTOCLAVE.HeaderText = "CENTROCOSTOCLAVE";
            this.DGCENTROCOSTOCLAVE.Name = "DGCENTROCOSTOCLAVE";
            this.DGCENTROCOSTOCLAVE.Visible = false;
            // 
            // DGCENTROCOSTONOMBRE
            // 
            this.DGCENTROCOSTONOMBRE.DataPropertyName = "CENTROCOSTONOMBRE";
            this.DGCENTROCOSTONOMBRE.HeaderText = "CENTRO COSTO";
            this.DGCENTROCOSTONOMBRE.Name = "DGCENTROCOSTONOMBRE";
            this.DGCENTROCOSTONOMBRE.Width = 120;
            // 
            // DGTOTAL
            // 
            this.DGTOTAL.DataPropertyName = "TOTAL";
            this.DGTOTAL.HeaderText = "TOTAL";
            this.DGTOTAL.Name = "DGTOTAL";
            // 
            // DGELIMINAR
            // 
            this.DGELIMINAR.HeaderText = "";
            this.DGELIMINAR.Name = "DGELIMINAR";
            this.DGELIMINAR.Text = "ELIMINAR";
            this.DGELIMINAR.UseColumnTextForButtonValue = true;
            // 
            // WFReciboGastoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(964, 493);
            this.Controls.Add(label7);
            this.Controls.Add(this.CENTROCOSTOButton);
            this.Controls.Add(this.CENTROCOSTOIDTextBox);
            this.Controls.Add(this.CENTROCOSTOLabel);
            this.Controls.Add(this.pnlAlmacen);
            this.Controls.Add(this.CBOrigenFiscal);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.TBObservaciones);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.CBCajero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gRIDPVGASTODataGridView);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.TBMonto);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.pnlCorteSeleccion);
            this.Controls.Add(this.GASTOButton);
            this.Controls.Add(this.GASTOIDTextBox);
            this.Controls.Add(this.GASTOLabel);
            this.Controls.Add(mARCAIDLabel);
            this.Controls.Add(this.LBFolio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DTPFecha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFReciboGastoEdit";
            this.Text = "Recibo de gastos";
            this.Load += new System.EventHandler(this.WFReciboGastoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gRIDPVGASTODataGridView)).EndInit();
            this.pnlCorteSeleccion.ResumeLayout(false);
            this.pnlCorteSeleccion.PerformLayout();
            this.pnlAlmacen.ResumeLayout(false);
            this.pnlAlmacen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gRIDPVGASTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CBCorteActual;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBFolio;
        private System.Windows.Forms.Button GASTOButton;
        private Tools.TextBoxFB GASTOIDTextBox;
        private System.Windows.Forms.Label GASTOLabel;
        private System.Windows.Forms.Panel pnlCorteSeleccion;
        private System.Windows.Forms.NumericTextBox TBMonto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnGuardar;
        private Contabilidad.DSContabilidad dSContabilidad;
        private System.Windows.Forms.BindingSource gRIDPVGASTOBindingSource;
        private Contabilidad.DSContabilidadTableAdapters.GRIDPVGASTOTableAdapter gRIDPVGASTOTableAdapter;
        private Contabilidad.DSContabilidadTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewE gRIDPVGASTODataGridView;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBoxFB CBCajero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox TBObservaciones;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox CBOrigenFiscal;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBoxFB ALMACENComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlAlmacen;
        private System.Windows.Forms.Button CENTROCOSTOButton;
        private Tools.TextBoxFB CENTROCOSTOIDTextBox;
        private System.Windows.Forms.Label CENTROCOSTOLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGGASTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCENTROCOSTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCENTROCOSTOCLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCENTROCOSTONOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGTOTAL;
        private System.Windows.Forms.DataGridViewButtonColumn DGELIMINAR;
    }
}