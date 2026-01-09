namespace iPos
{
    partial class WFLocacionProductos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFLocacionProductos));
            this.pRODUCTONOMBRETextBox = new System.Windows.Forms.TextBox();
            this.pRODUCTODESCRIPCIONTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBLocalidad = new System.Windows.Forms.TextBox();
            this.dSLocationProducts = new iPos.Inventario.DSLocationProducts();
            this.pRODUCTOLOCATIONSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pRODUCTOLOCATIONSTableAdapter = new iPos.Inventario.DSLocationProductsTableAdapters.PRODUCTOLOCATIONSTableAdapter();
            this.tableAdapterManager = new iPos.Inventario.DSLocationProductsTableAdapters.TableAdapterManager();
            this.pRODUCTOLOCATIONSDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBREALMACEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CBAnaquel = new System.Windows.Forms.ComboBoxFB();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.ALMACENComboBox = new System.Windows.Forms.ComboBoxFB();
            pRODUCTONOMBRELabel = new System.Windows.Forms.Label();
            pRODUCTODESCRIPCIONLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSLocationProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOLOCATIONSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOLOCATIONSDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pRODUCTONOMBRELabel
            // 
            pRODUCTONOMBRELabel.AutoSize = true;
            pRODUCTONOMBRELabel.BackColor = System.Drawing.Color.Transparent;
            pRODUCTONOMBRELabel.ForeColor = System.Drawing.Color.White;
            pRODUCTONOMBRELabel.Location = new System.Drawing.Point(313, 25);
            pRODUCTONOMBRELabel.Name = "pRODUCTONOMBRELabel";
            pRODUCTONOMBRELabel.Size = new System.Drawing.Size(107, 13);
            pRODUCTONOMBRELabel.TabIndex = 22;
            pRODUCTONOMBRELabel.Text = "Producto nombre:";
            // 
            // pRODUCTODESCRIPCIONLabel
            // 
            pRODUCTODESCRIPCIONLabel.AutoSize = true;
            pRODUCTODESCRIPCIONLabel.BackColor = System.Drawing.Color.Transparent;
            pRODUCTODESCRIPCIONLabel.ForeColor = System.Drawing.Color.White;
            pRODUCTODESCRIPCIONLabel.Location = new System.Drawing.Point(313, 90);
            pRODUCTODESCRIPCIONLabel.Name = "pRODUCTODESCRIPCIONLabel";
            pRODUCTODESCRIPCIONLabel.Size = new System.Drawing.Size(131, 13);
            pRODUCTODESCRIPCIONLabel.TabIndex = 24;
            pRODUCTODESCRIPCIONLabel.Text = "Producto descripcion:";
            // 
            // pRODUCTONOMBRETextBox
            // 
            this.pRODUCTONOMBRETextBox.Location = new System.Drawing.Point(316, 50);
            this.pRODUCTONOMBRETextBox.Name = "pRODUCTONOMBRETextBox";
            this.pRODUCTONOMBRETextBox.ReadOnly = true;
            this.pRODUCTONOMBRETextBox.Size = new System.Drawing.Size(276, 20);
            this.pRODUCTONOMBRETextBox.TabIndex = 23;
            // 
            // pRODUCTODESCRIPCIONTextBox
            // 
            this.pRODUCTODESCRIPCIONTextBox.Location = new System.Drawing.Point(316, 116);
            this.pRODUCTODESCRIPCIONTextBox.Name = "pRODUCTODESCRIPCIONTextBox";
            this.pRODUCTODESCRIPCIONTextBox.ReadOnly = true;
            this.pRODUCTODESCRIPCIONTextBox.Size = new System.Drawing.Size(276, 20);
            this.pRODUCTODESCRIPCIONTextBox.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(94, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TBCodigo
            // 
            this.TBCodigo.Location = new System.Drawing.Point(129, 47);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(116, 20);
            this.TBCodigo.TabIndex = 1;
            this.TBCodigo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBCodigo_PreviewKeyDown);
            this.TBCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.TBCodigo_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Localidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(32, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Anaquel:";
            // 
            // TBLocalidad
            // 
            this.TBLocalidad.Location = new System.Drawing.Point(129, 171);
            this.TBLocalidad.Name = "TBLocalidad";
            this.TBLocalidad.Size = new System.Drawing.Size(116, 20);
            this.TBLocalidad.TabIndex = 3;
            this.TBLocalidad.Leave += new System.EventHandler(this.TBLocalidad_Leave);
            this.TBLocalidad.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBLocalidad_PreviewKeyDown);
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
            // pRODUCTOLOCATIONSDataGridView
            // 
            this.pRODUCTOLOCATIONSDataGridView.AllowUserToAddRows = false;
            this.pRODUCTOLOCATIONSDataGridView.AutoGenerateColumns = false;
            this.pRODUCTOLOCATIONSDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pRODUCTOLOCATIONSDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pRODUCTOLOCATIONSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pRODUCTOLOCATIONSDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.NOMBREALMACEN,
            this.ColEliminar});
            this.pRODUCTOLOCATIONSDataGridView.DataSource = this.pRODUCTOLOCATIONSBindingSource;
            this.pRODUCTOLOCATIONSDataGridView.EnableHeadersVisualStyles = false;
            this.pRODUCTOLOCATIONSDataGridView.Location = new System.Drawing.Point(316, 169);
            this.pRODUCTOLOCATIONSDataGridView.Name = "pRODUCTOLOCATIONSDataGridView";
            this.pRODUCTOLOCATIONSDataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pRODUCTOLOCATIONSDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.pRODUCTOLOCATIONSDataGridView.RowHeadersVisible = false;
            this.pRODUCTOLOCATIONSDataGridView.Size = new System.Drawing.Size(397, 144);
            this.pRODUCTOLOCATIONSDataGridView.TabIndex = 32;
            this.pRODUCTOLOCATIONSDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pRODUCTOLOCATIONSDataGridView_CellContentClick);
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "ID";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ACTIVO";
            this.dataGridViewTextBoxColumn2.HeaderText = "ACTIVO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CREADO";
            this.dataGridViewTextBoxColumn3.HeaderText = "CREADO";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CREADOPOR_USERID";
            this.dataGridViewTextBoxColumn4.HeaderText = "CREADOPOR_USERID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MODIFICADO";
            this.dataGridViewTextBoxColumn5.HeaderText = "MODIFICADO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MODIFICADOPOR_USERID";
            this.dataGridViewTextBoxColumn6.HeaderText = "MODIFICADOPOR_USERID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PRODUCTOID";
            this.dataGridViewTextBoxColumn7.HeaderText = "PRODUCTOID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ANAQUEL";
            this.dataGridViewTextBoxColumn8.HeaderText = "ANAQUEL";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "LOCALIDAD";
            this.dataGridViewTextBoxColumn9.HeaderText = "LOCALIDAD";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // NOMBREALMACEN
            // 
            this.NOMBREALMACEN.DataPropertyName = "NOMBREALMACEN";
            this.NOMBREALMACEN.HeaderText = "ALMACEN";
            this.NOMBREALMACEN.Name = "NOMBREALMACEN";
            this.NOMBREALMACEN.ReadOnly = true;
            // 
            // ColEliminar
            // 
            this.ColEliminar.HeaderText = "";
            this.ColEliminar.Name = "ColEliminar";
            this.ColEliminar.ReadOnly = true;
            this.ColEliminar.Text = "ELIMINAR";
            this.ColEliminar.UseColumnTextForButtonValue = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Text = "Eliminar";
            // 
            // CBAnaquel
            // 
            this.CBAnaquel.Condicion = null;
            this.CBAnaquel.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CBAnaquel.DisplayMember = "nombre";
            this.CBAnaquel.FormattingEnabled = true;
            this.CBAnaquel.IndiceCampoSelector = 0;
            this.CBAnaquel.LabelDescription = null;
            this.CBAnaquel.Location = new System.Drawing.Point(129, 116);
            this.CBAnaquel.Name = "CBAnaquel";
            this.CBAnaquel.NombreCampoSelector = "id";
            this.CBAnaquel.Query = "select id,clave as nombre from anaquel";
            this.CBAnaquel.QueryDeSeleccion = "select id,clave as nombre  from anaquel where   id = @id";
            this.CBAnaquel.SelectedDataDisplaying = null;
            this.CBAnaquel.SelectedDataValue = null;
            this.CBAnaquel.Size = new System.Drawing.Size(116, 21);
            this.CBAnaquel.TabIndex = 2;
            this.CBAnaquel.ValueMember = "id";
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.lblAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacen.ForeColor = System.Drawing.Color.White;
            this.lblAlmacen.Location = new System.Drawing.Point(30, 222);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(59, 13);
            this.lblAlmacen.TabIndex = 171;
            this.lblAlmacen.Text = "Almacen:";
            // 
            // ALMACENComboBox
            // 
            this.ALMACENComboBox.Condicion = null;
            this.ALMACENComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENComboBox.DisplayMember = "nombre";
            this.ALMACENComboBox.FormattingEnabled = true;
            this.ALMACENComboBox.IndiceCampoSelector = 0;
            this.ALMACENComboBox.LabelDescription = null;
            this.ALMACENComboBox.Location = new System.Drawing.Point(129, 219);
            this.ALMACENComboBox.Name = "ALMACENComboBox";
            this.ALMACENComboBox.NombreCampoSelector = "id";
            this.ALMACENComboBox.Query = "select id,nombre from almacen";
            this.ALMACENComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENComboBox.SelectedDataDisplaying = null;
            this.ALMACENComboBox.SelectedDataValue = null;
            this.ALMACENComboBox.Size = new System.Drawing.Size(116, 21);
            this.ALMACENComboBox.TabIndex = 172;
            this.ALMACENComboBox.ValueMember = "id";
            this.ALMACENComboBox.SelectedIndexChanged += new System.EventHandler(this.ALMACENComboBox_SelectedIndexChanged);
            this.ALMACENComboBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ALMACENComboBox_PreviewKeyDown);
            // 
            // WFLocacionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(728, 377);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.ALMACENComboBox);
            this.Controls.Add(this.CBAnaquel);
            this.Controls.Add(this.pRODUCTOLOCATIONSDataGridView);
            this.Controls.Add(this.TBLocalidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(pRODUCTONOMBRELabel);
            this.Controls.Add(this.pRODUCTONOMBRETextBox);
            this.Controls.Add(pRODUCTODESCRIPCIONLabel);
            this.Controls.Add(this.pRODUCTODESCRIPCIONTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TBCodigo);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFLocacionProductos";
            this.Text = "Localización de Productos";
            this.Load += new System.EventHandler(this.WFLocacionProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSLocationProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOLOCATIONSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOLOCATIONSDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pRODUCTONOMBRETextBox;
        private System.Windows.Forms.TextBox pRODUCTODESCRIPCIONTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBLocalidad;
        private Inventario.DSLocationProducts dSLocationProducts;
        private System.Windows.Forms.BindingSource pRODUCTOLOCATIONSBindingSource;
        private Inventario.DSLocationProductsTableAdapters.PRODUCTOLOCATIONSTableAdapter pRODUCTOLOCATIONSTableAdapter;
        private Inventario.DSLocationProductsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum pRODUCTOLOCATIONSDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.ComboBoxFB CBAnaquel;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.ComboBoxFB ALMACENComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBREALMACEN;
        private System.Windows.Forms.DataGridViewButtonColumn ColEliminar;
    }
}