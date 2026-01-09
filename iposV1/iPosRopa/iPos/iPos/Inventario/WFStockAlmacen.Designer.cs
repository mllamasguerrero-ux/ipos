namespace iPos.Inventario
{
    partial class WFStockAlmacen
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label LBCantidadStock;
            System.Windows.Forms.Label pRODUCTODESCRIPCIONLabel;
            System.Windows.Forms.Label pRODUCTONOMBRELabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFStockAlmacen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.ALMACENComboBox = new System.Windows.Forms.ComboBoxFB();
            this.label1 = new System.Windows.Forms.Label();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.STOCKMAXTextBox = new System.Windows.Forms.NumericTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pRODUCTODESCRIPCIONTextBox = new System.Windows.Forms.TextBox();
            this.STOCKTextBox = new System.Windows.Forms.NumericTextBox();
            this.pRODUCTONOMBRETextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dSLocationProducts = new iPos.Inventario.DSLocationProducts();
            this.sTOCKALMACENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sTOCKALMACENTableAdapter = new iPos.Inventario.DSLocationProductsTableAdapters.STOCKALMACENTableAdapter();
            this.tableAdapterManager = new iPos.Inventario.DSLocationProductsTableAdapters.TableAdapterManager();
            this.sTOCKALMACENDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label2 = new System.Windows.Forms.Label();
            LBCantidadStock = new System.Windows.Forms.Label();
            pRODUCTODESCRIPCIONLabel = new System.Windows.Forms.Label();
            pRODUCTONOMBRELabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSLocationProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTOCKALMACENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTOCKALMACENDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(19, 114);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(109, 13);
            label2.TabIndex = 175;
            label2.Text = "Cantidad Stock Max.:";
            // 
            // LBCantidadStock
            // 
            LBCantidadStock.AutoSize = true;
            LBCantidadStock.BackColor = System.Drawing.Color.Transparent;
            LBCantidadStock.ForeColor = System.Drawing.Color.White;
            LBCantidadStock.Location = new System.Drawing.Point(22, 82);
            LBCantidadStock.Name = "LBCantidadStock";
            LBCantidadStock.Size = new System.Drawing.Size(106, 13);
            LBCantidadStock.TabIndex = 173;
            LBCantidadStock.Text = "Cantidad Stock Min.:";
            // 
            // pRODUCTODESCRIPCIONLabel
            // 
            pRODUCTODESCRIPCIONLabel.AutoSize = true;
            pRODUCTODESCRIPCIONLabel.BackColor = System.Drawing.Color.Transparent;
            pRODUCTODESCRIPCIONLabel.ForeColor = System.Drawing.Color.White;
            pRODUCTODESCRIPCIONLabel.Location = new System.Drawing.Point(496, 82);
            pRODUCTODESCRIPCIONLabel.Name = "pRODUCTODESCRIPCIONLabel";
            pRODUCTODESCRIPCIONLabel.Size = new System.Drawing.Size(66, 13);
            pRODUCTODESCRIPCIONLabel.TabIndex = 24;
            pRODUCTODESCRIPCIONLabel.Text = "Descripcion:";
            // 
            // pRODUCTONOMBRELabel
            // 
            pRODUCTONOMBRELabel.AutoSize = true;
            pRODUCTONOMBRELabel.BackColor = System.Drawing.Color.Transparent;
            pRODUCTONOMBRELabel.ForeColor = System.Drawing.Color.White;
            pRODUCTONOMBRELabel.Location = new System.Drawing.Point(469, 49);
            pRODUCTONOMBRELabel.Name = "pRODUCTONOMBRELabel";
            pRODUCTONOMBRELabel.Size = new System.Drawing.Size(93, 13);
            pRODUCTONOMBRELabel.TabIndex = 22;
            pRODUCTONOMBRELabel.Text = "Producto Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(19, 13);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(303, 18);
            label3.TabIndex = 173;
            label3.Text = "Listado de productos con stock por almacen";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblAlmacen);
            this.panel1.Controls.Add(this.ALMACENComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(this.TBCodigo);
            this.panel1.Controls.Add(this.STOCKMAXTextBox);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(LBCantidadStock);
            this.panel1.Controls.Add(this.pRODUCTODESCRIPCIONTextBox);
            this.panel1.Controls.Add(this.STOCKTextBox);
            this.panel1.Controls.Add(pRODUCTODESCRIPCIONLabel);
            this.panel1.Controls.Add(this.pRODUCTONOMBRETextBox);
            this.panel1.Controls.Add(pRODUCTONOMBRELabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 142);
            this.panel1.TabIndex = 177;
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.lblAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblAlmacen.Location = new System.Drawing.Point(69, 15);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(59, 13);
            this.lblAlmacen.TabIndex = 176;
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
            this.ALMACENComboBox.Location = new System.Drawing.Point(134, 12);
            this.ALMACENComboBox.Name = "ALMACENComboBox";
            this.ALMACENComboBox.NombreCampoSelector = "id";
            this.ALMACENComboBox.Query = "select id,nombre from almacen";
            this.ALMACENComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENComboBox.SelectedDataDisplaying = null;
            this.ALMACENComboBox.SelectedDataValue = null;
            this.ALMACENComboBox.Size = new System.Drawing.Size(206, 21);
            this.ALMACENComboBox.TabIndex = 1;
            this.ALMACENComboBox.ValueMember = "id";
            this.ALMACENComboBox.SelectedIndexChanged += new System.EventHandler(this.ALMACENComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(85, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Codigo:";
            // 
            // TBCodigo
            // 
            this.TBCodigo.Location = new System.Drawing.Point(135, 43);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(205, 20);
            this.TBCodigo.TabIndex = 2;
            this.TBCodigo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBCodigo_PreviewKeyDown);
            this.TBCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.TBCodigo_Validating);
            // 
            // STOCKMAXTextBox
            // 
            this.STOCKMAXTextBox.AllowNegative = true;
            this.STOCKMAXTextBox.Format_Expression = null;
            this.STOCKMAXTextBox.Location = new System.Drawing.Point(135, 111);
            this.STOCKMAXTextBox.Name = "STOCKMAXTextBox";
            this.STOCKMAXTextBox.NumericPrecision = 18;
            this.STOCKMAXTextBox.NumericScaleOnFocus = 2;
            this.STOCKMAXTextBox.NumericScaleOnLostFocus = 2;
            this.STOCKMAXTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.STOCKMAXTextBox.Size = new System.Drawing.Size(205, 20);
            this.STOCKMAXTextBox.TabIndex = 3;
            this.STOCKMAXTextBox.Tag = 34;
            this.STOCKMAXTextBox.Text = "0.00";
            this.STOCKMAXTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.STOCKMAXTextBox.ValidationExpression = null;
            this.STOCKMAXTextBox.ZeroIsValid = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(611, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pRODUCTODESCRIPCIONTextBox
            // 
            this.pRODUCTODESCRIPCIONTextBox.Location = new System.Drawing.Point(568, 79);
            this.pRODUCTODESCRIPCIONTextBox.Name = "pRODUCTODESCRIPCIONTextBox";
            this.pRODUCTODESCRIPCIONTextBox.ReadOnly = true;
            this.pRODUCTODESCRIPCIONTextBox.Size = new System.Drawing.Size(206, 20);
            this.pRODUCTODESCRIPCIONTextBox.TabIndex = 25;
            // 
            // STOCKTextBox
            // 
            this.STOCKTextBox.AllowNegative = true;
            this.STOCKTextBox.Format_Expression = null;
            this.STOCKTextBox.Location = new System.Drawing.Point(135, 79);
            this.STOCKTextBox.Name = "STOCKTextBox";
            this.STOCKTextBox.NumericPrecision = 18;
            this.STOCKTextBox.NumericScaleOnFocus = 2;
            this.STOCKTextBox.NumericScaleOnLostFocus = 2;
            this.STOCKTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.STOCKTextBox.Size = new System.Drawing.Size(205, 20);
            this.STOCKTextBox.TabIndex = 2;
            this.STOCKTextBox.Tag = 34;
            this.STOCKTextBox.Text = "0.00";
            this.STOCKTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.STOCKTextBox.ValidationExpression = null;
            this.STOCKTextBox.ZeroIsValid = true;
            // 
            // pRODUCTONOMBRETextBox
            // 
            this.pRODUCTONOMBRETextBox.Location = new System.Drawing.Point(568, 47);
            this.pRODUCTONOMBRETextBox.Name = "pRODUCTONOMBRETextBox";
            this.pRODUCTONOMBRETextBox.ReadOnly = true;
            this.pRODUCTONOMBRETextBox.Size = new System.Drawing.Size(206, 20);
            this.pRODUCTONOMBRETextBox.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(845, 44);
            this.panel3.TabIndex = 178;
            // 
            // dSLocationProducts
            // 
            this.dSLocationProducts.DataSetName = "DSLocationProducts";
            this.dSLocationProducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sTOCKALMACENBindingSource
            // 
            this.sTOCKALMACENBindingSource.DataMember = "STOCKALMACEN";
            this.sTOCKALMACENBindingSource.DataSource = this.dSLocationProducts;
            // 
            // sTOCKALMACENTableAdapter
            // 
            this.sTOCKALMACENTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Inventario.DSLocationProductsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // sTOCKALMACENDataGridView
            // 
            this.sTOCKALMACENDataGridView.AllowDrop = true;
            this.sTOCKALMACENDataGridView.AllowUserToAddRows = false;
            this.sTOCKALMACENDataGridView.AllowUserToDeleteRows = false;
            this.sTOCKALMACENDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sTOCKALMACENDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sTOCKALMACENDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sTOCKALMACENDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.sTOCKALMACENDataGridView.DataSource = this.sTOCKALMACENBindingSource;
            this.sTOCKALMACENDataGridView.Location = new System.Drawing.Point(0, 192);
            this.sTOCKALMACENDataGridView.Name = "sTOCKALMACENDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sTOCKALMACENDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.sTOCKALMACENDataGridView.RowHeadersVisible = false;
            this.sTOCKALMACENDataGridView.Size = new System.Drawing.Size(845, 344);
            this.sTOCKALMACENDataGridView.TabIndex = 179;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "PRODUCTOCLAVE";
            this.dataGridViewTextBoxColumn12.HeaderText = "PRODUCTO CLAVE";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 130;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "DESCRIPCION";
            this.dataGridViewTextBoxColumn11.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 200;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "CLAVEALMACEN";
            this.dataGridViewTextBoxColumn13.HeaderText = "CLAVE ALMACEN";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ALMACEN";
            this.dataGridViewTextBoxColumn14.HeaderText = "ALMACEN";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 200;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "STOCKMIN";
            this.dataGridViewTextBoxColumn9.HeaderText = "STOCKMIN";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "STOCKMAX";
            this.dataGridViewTextBoxColumn10.HeaderText = "STOCKMAX";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PRODUCTOCLAVE";
            this.dataGridViewTextBoxColumn1.HeaderText = "PRODUCTO CLAVE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 130;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DESCRIPCION";
            this.dataGridViewTextBoxColumn2.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CLAVEALMACEN";
            this.dataGridViewTextBoxColumn3.HeaderText = "CLAVE ALMACEN";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ALMACEN";
            this.dataGridViewTextBoxColumn4.HeaderText = "ALMACEN";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "STOCKMIN";
            this.dataGridViewTextBoxColumn5.HeaderText = "STOCKMIN";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "STOCKMAX";
            this.dataGridViewTextBoxColumn6.HeaderText = "STOCKMAX";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // WFStockAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(845, 536);
            this.Controls.Add(this.sTOCKALMACENDataGridView);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFStockAlmacen";
            this.Text = "Stock Almacen";
            this.Load += new System.EventHandler(this.WFStockAlmacen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSLocationProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTOCKALMACENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTOCKALMACENDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.NumericTextBox STOCKMAXTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox pRODUCTODESCRIPCIONTextBox;
        private System.Windows.Forms.NumericTextBox STOCKTextBox;
        private System.Windows.Forms.TextBox pRODUCTONOMBRETextBox;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.ComboBoxFB ALMACENComboBox;
        private System.Windows.Forms.Panel panel3;
        private DSLocationProducts dSLocationProducts;
        private System.Windows.Forms.BindingSource sTOCKALMACENBindingSource;
        private DSLocationProductsTableAdapters.STOCKALMACENTableAdapter sTOCKALMACENTableAdapter;
        private DSLocationProductsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum sTOCKALMACENDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}