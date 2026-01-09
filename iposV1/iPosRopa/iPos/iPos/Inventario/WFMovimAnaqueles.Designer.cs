namespace iPos
{
    partial class WFMovimAnaqueles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFMovimAnaqueles));
            this.label3 = new System.Windows.Forms.Label();
            this.dSLocationProducts = new iPos.Inventario.DSLocationProducts();
            this.aNAQUELCONTENTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aNAQUELCONTENTTableAdapter = new iPos.Inventario.DSLocationProductsTableAdapters.ANAQUELCONTENTTableAdapter();
            this.tableAdapterManager = new iPos.Inventario.DSLocationProductsTableAdapters.TableAdapterManager();
            this.aNAQUELCONTENTDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPRODUCTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGANAQUELID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGLOCALIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGELIMINAR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGMOVER = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGLOCNUEVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectEliminarTodos = new System.Windows.Forms.Button();
            this.btnDeselectMoverTodos = new System.Windows.Forms.Button();
            this.btnDeselectEliminarTodos = new System.Windows.Forms.Button();
            this.btnSelectMoverTodos = new System.Windows.Forms.Button();
            this.btnCopiarLocalidadAnt = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBAnaquelDestino = new System.Windows.Forms.ComboBoxFB();
            this.CBAnaquel = new System.Windows.Forms.ComboBoxFB();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.ALMACENComboBox = new System.Windows.Forms.ComboBoxFB();
            this.lblAlmacenNuevo = new System.Windows.Forms.Label();
            this.ALMACENNuevoComboBox = new System.Windows.Forms.ComboBoxFB();
            ((System.ComponentModel.ISupportInitialize)(this.dSLocationProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNAQUELCONTENTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNAQUELCONTENTDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(492, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Anaquel:";
            // 
            // dSLocationProducts
            // 
            this.dSLocationProducts.DataSetName = "DSLocationProducts";
            this.dSLocationProducts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aNAQUELCONTENTBindingSource
            // 
            this.aNAQUELCONTENTBindingSource.DataMember = "ANAQUELCONTENT";
            this.aNAQUELCONTENTBindingSource.DataSource = this.dSLocationProducts;
            // 
            // aNAQUELCONTENTTableAdapter
            // 
            this.aNAQUELCONTENTTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Inventario.DSLocationProductsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // aNAQUELCONTENTDataGridView
            // 
            this.aNAQUELCONTENTDataGridView.AllowUserToAddRows = false;
            this.aNAQUELCONTENTDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.aNAQUELCONTENTDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.aNAQUELCONTENTDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aNAQUELCONTENTDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn12,
            this.DGPRODUCTOID,
            this.DGID,
            this.DGCLAVE,
            this.dataGridViewTextBoxColumn11,
            this.DGANAQUELID,
            this.DGLOCALIDAD,
            this.DGELIMINAR,
            this.DGMOVER,
            this.DGLOCNUEVA});
            this.aNAQUELCONTENTDataGridView.DataSource = this.aNAQUELCONTENTBindingSource;
            this.aNAQUELCONTENTDataGridView.Location = new System.Drawing.Point(47, 139);
            this.aNAQUELCONTENTDataGridView.Name = "aNAQUELCONTENTDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.aNAQUELCONTENTDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.aNAQUELCONTENTDataGridView.RowHeadersVisible = false;
            this.aNAQUELCONTENTDataGridView.Size = new System.Drawing.Size(633, 220);
            this.aNAQUELCONTENTDataGridView.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ACTIVO";
            this.dataGridViewTextBoxColumn2.HeaderText = "ACTIVO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CREADO";
            this.dataGridViewTextBoxColumn3.HeaderText = "CREADO";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CREADOPOR_USERID";
            this.dataGridViewTextBoxColumn4.HeaderText = "CREADOPOR_USERID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MODIFICADO";
            this.dataGridViewTextBoxColumn5.HeaderText = "MODIFICADO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MODIFICADOPOR_USERID";
            this.dataGridViewTextBoxColumn6.HeaderText = "MODIFICADOPOR_USERID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "DESCRIPCION2";
            this.dataGridViewTextBoxColumn12.HeaderText = "DESCRIPCION2";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // DGPRODUCTOID
            // 
            this.DGPRODUCTOID.DataPropertyName = "PRODUCTOID";
            this.DGPRODUCTOID.HeaderText = "PRODUCTOID";
            this.DGPRODUCTOID.Name = "DGPRODUCTOID";
            this.DGPRODUCTOID.Visible = false;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // DGCLAVE
            // 
            this.DGCLAVE.DataPropertyName = "CLAVE";
            this.DGCLAVE.HeaderText = "CLAVE";
            this.DGCLAVE.Name = "DGCLAVE";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn11.HeaderText = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 200;
            // 
            // DGANAQUELID
            // 
            this.DGANAQUELID.DataPropertyName = "ANAQUEL";
            this.DGANAQUELID.HeaderText = "ANAQUEL";
            this.DGANAQUELID.Name = "DGANAQUELID";
            this.DGANAQUELID.Visible = false;
            // 
            // DGLOCALIDAD
            // 
            this.DGLOCALIDAD.DataPropertyName = "LOCALIDAD";
            this.DGLOCALIDAD.HeaderText = "LOCALIDAD";
            this.DGLOCALIDAD.Name = "DGLOCALIDAD";
            // 
            // DGELIMINAR
            // 
            this.DGELIMINAR.HeaderText = "Eliminar";
            this.DGELIMINAR.Name = "DGELIMINAR";
            this.DGELIMINAR.Width = 50;
            // 
            // DGMOVER
            // 
            this.DGMOVER.HeaderText = "Mover";
            this.DGMOVER.Name = "DGMOVER";
            this.DGMOVER.Width = 50;
            // 
            // DGLOCNUEVA
            // 
            this.DGLOCNUEVA.HeaderText = "Loc. Nueva";
            this.DGLOCNUEVA.Name = "DGLOCNUEVA";
            this.DGLOCNUEVA.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(335, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Nuevo Anaquel (para los que se moveran)";
            // 
            // btnSelectEliminarTodos
            // 
            this.btnSelectEliminarTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnSelectEliminarTodos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectEliminarTodos.BackgroundImage")));
            this.btnSelectEliminarTodos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectEliminarTodos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSelectEliminarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectEliminarTodos.ForeColor = System.Drawing.Color.White;
            this.btnSelectEliminarTodos.Location = new System.Drawing.Point(448, 87);
            this.btnSelectEliminarTodos.Name = "btnSelectEliminarTodos";
            this.btnSelectEliminarTodos.Size = new System.Drawing.Size(42, 24);
            this.btnSelectEliminarTodos.TabIndex = 35;
            this.btnSelectEliminarTodos.UseVisualStyleBackColor = false;
            this.btnSelectEliminarTodos.Click += new System.EventHandler(this.btnSelectEliminarTodos_Click);
            // 
            // btnDeselectMoverTodos
            // 
            this.btnDeselectMoverTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnDeselectMoverTodos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeselectMoverTodos.BackgroundImage")));
            this.btnDeselectMoverTodos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeselectMoverTodos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnDeselectMoverTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeselectMoverTodos.ForeColor = System.Drawing.Color.White;
            this.btnDeselectMoverTodos.Location = new System.Drawing.Point(499, 109);
            this.btnDeselectMoverTodos.Name = "btnDeselectMoverTodos";
            this.btnDeselectMoverTodos.Size = new System.Drawing.Size(42, 24);
            this.btnDeselectMoverTodos.TabIndex = 38;
            this.btnDeselectMoverTodos.UseVisualStyleBackColor = false;
            this.btnDeselectMoverTodos.Click += new System.EventHandler(this.btnDeselectMoverTodos_Click);
            // 
            // btnDeselectEliminarTodos
            // 
            this.btnDeselectEliminarTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnDeselectEliminarTodos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeselectEliminarTodos.BackgroundImage")));
            this.btnDeselectEliminarTodos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeselectEliminarTodos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnDeselectEliminarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeselectEliminarTodos.ForeColor = System.Drawing.Color.White;
            this.btnDeselectEliminarTodos.Location = new System.Drawing.Point(448, 109);
            this.btnDeselectEliminarTodos.Name = "btnDeselectEliminarTodos";
            this.btnDeselectEliminarTodos.Size = new System.Drawing.Size(42, 24);
            this.btnDeselectEliminarTodos.TabIndex = 39;
            this.btnDeselectEliminarTodos.UseVisualStyleBackColor = false;
            this.btnDeselectEliminarTodos.Click += new System.EventHandler(this.btnDeselectEliminarTodos_Click);
            // 
            // btnSelectMoverTodos
            // 
            this.btnSelectMoverTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnSelectMoverTodos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectMoverTodos.BackgroundImage")));
            this.btnSelectMoverTodos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectMoverTodos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSelectMoverTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectMoverTodos.ForeColor = System.Drawing.Color.White;
            this.btnSelectMoverTodos.Location = new System.Drawing.Point(499, 87);
            this.btnSelectMoverTodos.Name = "btnSelectMoverTodos";
            this.btnSelectMoverTodos.Size = new System.Drawing.Size(42, 24);
            this.btnSelectMoverTodos.TabIndex = 40;
            this.btnSelectMoverTodos.UseVisualStyleBackColor = false;
            this.btnSelectMoverTodos.Click += new System.EventHandler(this.btnSelectMoverTodos_Click);
            // 
            // btnCopiarLocalidadAnt
            // 
            this.btnCopiarLocalidadAnt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCopiarLocalidadAnt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCopiarLocalidadAnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiarLocalidadAnt.ForeColor = System.Drawing.Color.White;
            this.btnCopiarLocalidadAnt.Location = new System.Drawing.Point(547, 109);
            this.btnCopiarLocalidadAnt.Name = "btnCopiarLocalidadAnt";
            this.btnCopiarLocalidadAnt.Size = new System.Drawing.Size(97, 24);
            this.btnCopiarLocalidadAnt.TabIndex = 41;
            this.btnCopiarLocalidadAnt.Text = "Copiar Loc Ant.";
            this.btnCopiarLocalidadAnt.UseVisualStyleBackColor = false;
            this.btnCopiarLocalidadAnt.Click += new System.EventHandler(this.btnCopiarLocalidadAnt_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(298, 365);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(135, 34);
            this.btnGuardar.TabIndex = 42;
            this.btnGuardar.Text = "Aplicar movimientos";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn7.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DESCRIPCION2";
            this.dataGridViewTextBoxColumn8.HeaderText = "DESCRIPCION2";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 200;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn9.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn10.HeaderText = "ID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Loc. Nueva";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 70;
            // 
            // CBAnaquelDestino
            // 
            this.CBAnaquelDestino.Condicion = null;
            this.CBAnaquelDestino.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CBAnaquelDestino.DisplayMember = "nombre";
            this.CBAnaquelDestino.FormattingEnabled = true;
            this.CBAnaquelDestino.IndiceCampoSelector = 0;
            this.CBAnaquelDestino.LabelDescription = null;
            this.CBAnaquelDestino.Location = new System.Drawing.Point(547, 56);
            this.CBAnaquelDestino.Name = "CBAnaquelDestino";
            this.CBAnaquelDestino.NombreCampoSelector = "id";
            this.CBAnaquelDestino.Query = "select id,clave as nombre from anaquel";
            this.CBAnaquelDestino.QueryDeSeleccion = "select id,clave as nombre  from anaquel where   id = @id";
            this.CBAnaquelDestino.SelectedDataDisplaying = null;
            this.CBAnaquelDestino.SelectedDataValue = null;
            this.CBAnaquelDestino.Size = new System.Drawing.Size(149, 21);
            this.CBAnaquelDestino.TabIndex = 4;
            this.CBAnaquelDestino.ValueMember = "id";
            // 
            // CBAnaquel
            // 
            this.CBAnaquel.Condicion = null;
            this.CBAnaquel.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CBAnaquel.DisplayMember = "nombre";
            this.CBAnaquel.FormattingEnabled = true;
            this.CBAnaquel.IndiceCampoSelector = 0;
            this.CBAnaquel.LabelDescription = null;
            this.CBAnaquel.Location = new System.Drawing.Point(547, 23);
            this.CBAnaquel.Name = "CBAnaquel";
            this.CBAnaquel.NombreCampoSelector = "id";
            this.CBAnaquel.Query = "select id,clave as nombre from anaquel";
            this.CBAnaquel.QueryDeSeleccion = "select id,clave as nombre  from anaquel where   id = @id";
            this.CBAnaquel.SelectedDataDisplaying = null;
            this.CBAnaquel.SelectedDataValue = null;
            this.CBAnaquel.Size = new System.Drawing.Size(149, 21);
            this.CBAnaquel.TabIndex = 2;
            this.CBAnaquel.ValueMember = "id";
            this.CBAnaquel.SelectedValueChanged += new System.EventHandler(this.CBAnaquel_SelectedValueChanged);
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.lblAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacen.ForeColor = System.Drawing.Color.White;
            this.lblAlmacen.Location = new System.Drawing.Point(95, 31);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(51, 13);
            this.lblAlmacen.TabIndex = 173;
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
            this.ALMACENComboBox.Location = new System.Drawing.Point(163, 28);
            this.ALMACENComboBox.Name = "ALMACENComboBox";
            this.ALMACENComboBox.NombreCampoSelector = "id";
            this.ALMACENComboBox.Query = "select id,nombre from almacen";
            this.ALMACENComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENComboBox.SelectedDataDisplaying = null;
            this.ALMACENComboBox.SelectedDataValue = null;
            this.ALMACENComboBox.Size = new System.Drawing.Size(116, 21);
            this.ALMACENComboBox.TabIndex = 1;
            this.ALMACENComboBox.ValueMember = "id";
            this.ALMACENComboBox.SelectedIndexChanged += new System.EventHandler(this.ALMACENComboBox_SelectedIndexChanged);
            // 
            // lblAlmacenNuevo
            // 
            this.lblAlmacenNuevo.AutoSize = true;
            this.lblAlmacenNuevo.BackColor = System.Drawing.Color.Transparent;
            this.lblAlmacenNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacenNuevo.ForeColor = System.Drawing.Color.White;
            this.lblAlmacenNuevo.Location = new System.Drawing.Point(60, 59);
            this.lblAlmacenNuevo.Name = "lblAlmacenNuevo";
            this.lblAlmacenNuevo.Size = new System.Drawing.Size(86, 13);
            this.lblAlmacenNuevo.TabIndex = 175;
            this.lblAlmacenNuevo.Text = "Nuevo Almacen:";
            // 
            // ALMACENNuevoComboBox
            // 
            this.ALMACENNuevoComboBox.Condicion = null;
            this.ALMACENNuevoComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENNuevoComboBox.DisplayMember = "nombre";
            this.ALMACENNuevoComboBox.FormattingEnabled = true;
            this.ALMACENNuevoComboBox.IndiceCampoSelector = 0;
            this.ALMACENNuevoComboBox.LabelDescription = null;
            this.ALMACENNuevoComboBox.Location = new System.Drawing.Point(163, 56);
            this.ALMACENNuevoComboBox.Name = "ALMACENNuevoComboBox";
            this.ALMACENNuevoComboBox.NombreCampoSelector = "id";
            this.ALMACENNuevoComboBox.Query = "select id,nombre from almacen";
            this.ALMACENNuevoComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENNuevoComboBox.SelectedDataDisplaying = null;
            this.ALMACENNuevoComboBox.SelectedDataValue = null;
            this.ALMACENNuevoComboBox.Size = new System.Drawing.Size(116, 21);
            this.ALMACENNuevoComboBox.TabIndex = 3;
            this.ALMACENNuevoComboBox.ValueMember = "id";
            // 
            // WFMovimAnaqueles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(731, 411);
            this.Controls.Add(this.lblAlmacenNuevo);
            this.Controls.Add(this.ALMACENNuevoComboBox);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.ALMACENComboBox);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCopiarLocalidadAnt);
            this.Controls.Add(this.btnSelectMoverTodos);
            this.Controls.Add(this.btnDeselectEliminarTodos);
            this.Controls.Add(this.btnDeselectMoverTodos);
            this.Controls.Add(this.btnSelectEliminarTodos);
            this.Controls.Add(this.CBAnaquelDestino);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aNAQUELCONTENTDataGridView);
            this.Controls.Add(this.CBAnaquel);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFMovimAnaqueles";
            this.Text = "Movimientos de anaquel";
            this.Load += new System.EventHandler(this.WFMovimAnaqueles_Load);
            this.Shown += new System.EventHandler(this.WFMovimAnaqueles_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dSLocationProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNAQUELCONTENTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aNAQUELCONTENTDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBoxFB CBAnaquel;
        private System.Windows.Forms.Label label3;
        private Inventario.DSLocationProducts dSLocationProducts;
        private System.Windows.Forms.BindingSource aNAQUELCONTENTBindingSource;
        private Inventario.DSLocationProductsTableAdapters.ANAQUELCONTENTTableAdapter aNAQUELCONTENTTableAdapter;
        private Inventario.DSLocationProductsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum aNAQUELCONTENTDataGridView;
        private System.Windows.Forms.ComboBoxFB CBAnaquelDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectEliminarTodos;
        private System.Windows.Forms.Button btnDeselectMoverTodos;
        private System.Windows.Forms.Button btnDeselectEliminarTodos;
        private System.Windows.Forms.Button btnSelectMoverTodos;
        private System.Windows.Forms.Button btnCopiarLocalidadAnt;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPRODUCTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGANAQUELID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGLOCALIDAD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGELIMINAR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGMOVER;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGLOCNUEVA;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.ComboBoxFB ALMACENComboBox;
        private System.Windows.Forms.Label lblAlmacenNuevo;
        private System.Windows.Forms.ComboBoxFB ALMACENNuevoComboBox;
    }
}