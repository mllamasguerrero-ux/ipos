namespace iPos.Importaciones
{
    partial class WFPedidosXProductos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPedidosXProductos));
            this.label4 = new System.Windows.Forms.Label();
            this.dSImportaciones = new iPos.Importaciones.DSImportaciones();
            this.eXISTENCIAPEDIDOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eXISTENCIAPEDIDOTableAdapter = new iPos.Importaciones.DSImportacionesTableAdapters.EXISTENCIAPEDIDOTableAdapter();
            this.tableAdapterManager = new iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager();
            this.eXISTENCIAPEDIDODataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DGCLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXISTENCIASUCURSAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDADPEDIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.comboTipoReporte = new System.Windows.Forms.ComboBox();
            this.btnCargarDatos = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SucursalComboBox = new System.Windows.Forms.ComboBoxFB();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eXISTENCIAPEDIDOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eXISTENCIAPEDIDODataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(184, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 180;
            this.label4.Text = "Sucursal:";
            // 
            // dSImportaciones
            // 
            this.dSImportaciones.DataSetName = "DSImportaciones";
            this.dSImportaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eXISTENCIAPEDIDOBindingSource
            // 
            this.eXISTENCIAPEDIDOBindingSource.DataMember = "EXISTENCIAPEDIDO";
            this.eXISTENCIAPEDIDOBindingSource.DataSource = this.dSImportaciones;
            // 
            // eXISTENCIAPEDIDOTableAdapter
            // 
            this.eXISTENCIAPEDIDOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // eXISTENCIAPEDIDODataGridView
            // 
            this.eXISTENCIAPEDIDODataGridView.AllowUserToAddRows = false;
            this.eXISTENCIAPEDIDODataGridView.AllowUserToDeleteRows = false;
            this.eXISTENCIAPEDIDODataGridView.AutoGenerateColumns = false;
            this.eXISTENCIAPEDIDODataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.eXISTENCIAPEDIDODataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.eXISTENCIAPEDIDODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eXISTENCIAPEDIDODataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCLAVE,
            this.DGDESC,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn3,
            this.EXISTENCIASUCURSAL,
            this.CANTIDADPEDIDO});
            this.eXISTENCIAPEDIDODataGridView.DataSource = this.eXISTENCIAPEDIDOBindingSource;
            this.eXISTENCIAPEDIDODataGridView.EnableHeadersVisualStyles = false;
            this.eXISTENCIAPEDIDODataGridView.Location = new System.Drawing.Point(12, 109);
            this.eXISTENCIAPEDIDODataGridView.Name = "eXISTENCIAPEDIDODataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.eXISTENCIAPEDIDODataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.eXISTENCIAPEDIDODataGridView.RowHeadersVisible = false;
            this.eXISTENCIAPEDIDODataGridView.Size = new System.Drawing.Size(914, 278);
            this.eXISTENCIAPEDIDODataGridView.TabIndex = 183;
            // 
            // DGCLAVE
            // 
            this.DGCLAVE.DataPropertyName = "CLAVE";
            this.DGCLAVE.HeaderText = "CLAVE";
            this.DGCLAVE.Name = "DGCLAVE";
            this.DGCLAVE.ReadOnly = true;
            // 
            // DGDESC
            // 
            this.DGDESC.DataPropertyName = "DESCRIPCION1";
            this.DGDESC.HeaderText = "DESCRIPCION1";
            this.DGDESC.Name = "DGDESC";
            this.DGDESC.ReadOnly = true;
            this.DGDESC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DGDESC.Width = 260;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DESCRIPCION2";
            this.dataGridViewTextBoxColumn4.HeaderText = "DESCRIPCION2";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 255;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "EXISTENCIA";
            this.dataGridViewTextBoxColumn3.HeaderText = "EXISTENCIA";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // EXISTENCIASUCURSAL
            // 
            this.EXISTENCIASUCURSAL.HeaderText = "EXISTENCIA SUCURSAL";
            this.EXISTENCIASUCURSAL.Name = "EXISTENCIASUCURSAL";
            this.EXISTENCIASUCURSAL.ReadOnly = true;
            this.EXISTENCIASUCURSAL.Width = 90;
            // 
            // CANTIDADPEDIDO
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.NullValue = "0";
            this.CANTIDADPEDIDO.DefaultCellStyle = dataGridViewCellStyle2;
            this.CANTIDADPEDIDO.HeaderText = "CANTIDAD PEDIDO";
            this.CANTIDADPEDIDO.Name = "CANTIDADPEDIDO";
            this.CANTIDADPEDIDO.Width = 90;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(450, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 185;
            this.label5.Text = "Tipo:";
            // 
            // comboTipoReporte
            // 
            this.comboTipoReporte.FormattingEnabled = true;
            this.comboTipoReporte.Items.AddRange(new object[] {
            "CON EXISTENCIA\t",
            "TODOS"});
            this.comboTipoReporte.Location = new System.Drawing.Point(492, 52);
            this.comboTipoReporte.Name = "comboTipoReporte";
            this.comboTipoReporte.Size = new System.Drawing.Size(121, 21);
            this.comboTipoReporte.TabIndex = 184;
            // 
            // btnCargarDatos
            // 
            this.btnCargarDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCargarDatos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCargarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnCargarDatos.ForeColor = System.Drawing.Color.White;
            this.btnCargarDatos.Location = new System.Drawing.Point(685, 44);
            this.btnCargarDatos.Name = "btnCargarDatos";
            this.btnCargarDatos.Size = new System.Drawing.Size(127, 32);
            this.btnCargarDatos.TabIndex = 186;
            this.btnCargarDatos.Text = "Cargar datos";
            this.btnCargarDatos.UseVisualStyleBackColor = false;
            this.btnCargarDatos.Click += new System.EventHandler(this.btnCargarDatos_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnConvert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.ForeColor = System.Drawing.Color.White;
            this.btnConvert.Location = new System.Drawing.Point(408, 404);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(125, 35);
            this.btnConvert.TabIndex = 187;
            this.btnConvert.Text = "Convertir a pedido";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn1.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn2.HeaderText = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "EXISTENCIA SUCURSAL";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle4.NullValue = "0";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn6.HeaderText = "CANTIDAD PEDIDO";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // SucursalComboBox
            // 
            this.SucursalComboBox.Condicion = null;
            this.SucursalComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SucursalComboBox.DisplayMember = "descripcion";
            this.SucursalComboBox.FormattingEnabled = true;
            this.SucursalComboBox.IndiceCampoSelector = 0;
            this.SucursalComboBox.LabelDescription = null;
            this.SucursalComboBox.Location = new System.Drawing.Point(251, 52);
            this.SucursalComboBox.Name = "SucursalComboBox";
            this.SucursalComboBox.NombreCampoSelector = "";
            this.SucursalComboBox.Query = "select id,clave,descripcion from sucursal";
            this.SucursalComboBox.QueryDeSeleccion = null;
            this.SucursalComboBox.SelectedDataDisplaying = null;
            this.SucursalComboBox.SelectedDataValue = null;
            this.SucursalComboBox.Size = new System.Drawing.Size(140, 21);
            this.SucursalComboBox.TabIndex = 181;
            this.SucursalComboBox.ValueMember = "clave";
            // 
            // WFPedidosXProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(938, 451);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnCargarDatos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboTipoReporte);
            this.Controls.Add(this.eXISTENCIAPEDIDODataGridView);
            this.Controls.Add(this.SucursalComboBox);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFPedidosXProductos";
            this.Text = "Pedidos por Productos";
            this.Load += new System.EventHandler(this.WFPedidosXProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eXISTENCIAPEDIDOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eXISTENCIAPEDIDODataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBoxFB SucursalComboBox;
        private System.Windows.Forms.Label label4;
        private DSImportaciones dSImportaciones;
        private System.Windows.Forms.BindingSource eXISTENCIAPEDIDOBindingSource;
        private DSImportacionesTableAdapters.EXISTENCIAPEDIDOTableAdapter eXISTENCIAPEDIDOTableAdapter;
        private DSImportacionesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum eXISTENCIAPEDIDODataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboTipoReporte;
        private System.Windows.Forms.Button btnCargarDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGDESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXISTENCIASUCURSAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDADPEDIDO;
    }
}