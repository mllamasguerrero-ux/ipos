namespace iPos.Importaciones
{
    partial class WFDetalleCompraMovil
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFDetalleCompraMovil));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ALMACENComboBox = new System.Windows.Forms.ComboBoxFB();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.LBEstatusCliente = new System.Windows.Forms.Label();
            this.btnImprimirTicket = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.procesarButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dETALLE_COMPRA_MOVILDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDADAENVIAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_EXISTENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dETALLE_COMPRA_MOVILBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dSImportaciones3 = new iPos.Importaciones.DSImportaciones3();
            this.tableAdapterManager = new iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dETALLE_COMPRA_MOVILTableAdapter1 = new iPos.Importaciones.DSImportaciones3TableAdapters.DETALLE_COMPRA_MOVILTableAdapter();
            this.tableAdapterManager1 = new iPos.Importaciones.DSImportaciones3TableAdapters.TableAdapterManager();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLE_COMPRA_MOVILDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLE_COMPRA_MOVILBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.ALMACENComboBox);
            this.panel1.Controls.Add(this.lblAlmacen);
            this.panel1.Controls.Add(this.LBEstatusCliente);
            this.panel1.Controls.Add(this.btnImprimirTicket);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.procesarButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 104);
            this.panel1.TabIndex = 3;
            // 
            // ALMACENComboBox
            // 
            this.ALMACENComboBox.Condicion = null;
            this.ALMACENComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENComboBox.DisplayMember = "nombre";
            this.ALMACENComboBox.FormattingEnabled = true;
            this.ALMACENComboBox.IndiceCampoSelector = 0;
            this.ALMACENComboBox.LabelDescription = null;
            this.ALMACENComboBox.Location = new System.Drawing.Point(129, 44);
            this.ALMACENComboBox.Name = "ALMACENComboBox";
            this.ALMACENComboBox.NombreCampoSelector = "id";
            this.ALMACENComboBox.Query = "select id,nombre from almacen";
            this.ALMACENComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENComboBox.SelectedDataDisplaying = null;
            this.ALMACENComboBox.SelectedDataValue = null;
            this.ALMACENComboBox.Size = new System.Drawing.Size(118, 21);
            this.ALMACENComboBox.TabIndex = 174;
            this.ALMACENComboBox.ValueMember = "id";
            this.ALMACENComboBox.SelectionChangeCommitted += new System.EventHandler(this.ALMACENComboBox_SelectionChangeCommitted);
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.lblAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacen.ForeColor = System.Drawing.Color.White;
            this.lblAlmacen.Location = new System.Drawing.Point(69, 47);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(59, 13);
            this.lblAlmacen.TabIndex = 173;
            this.lblAlmacen.Text = "Almacen:";
            // 
            // LBEstatusCliente
            // 
            this.LBEstatusCliente.AutoSize = true;
            this.LBEstatusCliente.ForeColor = System.Drawing.Color.White;
            this.LBEstatusCliente.Location = new System.Drawing.Point(35, 18);
            this.LBEstatusCliente.Name = "LBEstatusCliente";
            this.LBEstatusCliente.Size = new System.Drawing.Size(19, 13);
            this.LBEstatusCliente.TabIndex = 26;
            this.LBEstatusCliente.Text = "__";
            // 
            // btnImprimirTicket
            // 
            this.btnImprimirTicket.BackColor = System.Drawing.Color.Olive;
            this.btnImprimirTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirTicket.ForeColor = System.Drawing.Color.White;
            this.btnImprimirTicket.Location = new System.Drawing.Point(646, 47);
            this.btnImprimirTicket.Name = "btnImprimirTicket";
            this.btnImprimirTicket.Size = new System.Drawing.Size(93, 23);
            this.btnImprimirTicket.TabIndex = 25;
            this.btnImprimirTicket.Text = "Imprimir ticket";
            this.btnImprimirTicket.UseVisualStyleBackColor = false;
            this.btnImprimirTicket.Click += new System.EventHandler(this.btnImprimirTicket_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Olive;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(493, 47);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(138, 23);
            this.btnImprimir.TabIndex = 24;
            this.btnImprimir.Text = "Imprimir recibo largo";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // procesarButton
            // 
            this.procesarButton.BackColor = System.Drawing.Color.Firebrick;
            this.procesarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.procesarButton.ForeColor = System.Drawing.Color.White;
            this.procesarButton.Location = new System.Drawing.Point(374, 47);
            this.procesarButton.Name = "procesarButton";
            this.procesarButton.Size = new System.Drawing.Size(93, 23);
            this.procesarButton.TabIndex = 1;
            this.procesarButton.Text = "Procesar";
            this.procesarButton.UseVisualStyleBackColor = false;
            this.procesarButton.Click += new System.EventHandler(this.procesarButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dETALLE_COMPRA_MOVILDataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(854, 310);
            this.panel2.TabIndex = 4;
            // 
            // dETALLE_COMPRA_MOVILDataGridView
            // 
            this.dETALLE_COMPRA_MOVILDataGridView.AllowUserToAddRows = false;
            this.dETALLE_COMPRA_MOVILDataGridView.AllowUserToDeleteRows = false;
            this.dETALLE_COMPRA_MOVILDataGridView.AutoGenerateColumns = false;
            this.dETALLE_COMPRA_MOVILDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dETALLE_COMPRA_MOVILDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.DG_CANTIDAD,
            this.CANTIDADAENVIAR,
            this.DG_EXISTENCIA,
            this.DG_ID});
            this.dETALLE_COMPRA_MOVILDataGridView.DataSource = this.dETALLE_COMPRA_MOVILBindingSource1;
            this.dETALLE_COMPRA_MOVILDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dETALLE_COMPRA_MOVILDataGridView.Location = new System.Drawing.Point(0, 0);
            this.dETALLE_COMPRA_MOVILDataGridView.Name = "dETALLE_COMPRA_MOVILDataGridView";
            this.dETALLE_COMPRA_MOVILDataGridView.RowHeadersVisible = false;
            this.dETALLE_COMPRA_MOVILDataGridView.Size = new System.Drawing.Size(854, 310);
            this.dETALLE_COMPRA_MOVILDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn1.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn2.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DESCRIPCION1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn6.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PRECIO";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn4.HeaderText = "PRECIO";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TOTAL";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn5.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DESCRIPCION2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn7.HeaderText = "DESCRIPCION2";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // DG_CANTIDAD
            // 
            this.DG_CANTIDAD.DataPropertyName = "CANTIDAD";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.DG_CANTIDAD.DefaultCellStyle = dataGridViewCellStyle5;
            this.DG_CANTIDAD.HeaderText = "CANTIDAD";
            this.DG_CANTIDAD.Name = "DG_CANTIDAD";
            // 
            // CANTIDADAENVIAR
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.CANTIDADAENVIAR.DefaultCellStyle = dataGridViewCellStyle6;
            this.CANTIDADAENVIAR.HeaderText = "CANTIDAD A ENVIAR";
            this.CANTIDADAENVIAR.Name = "CANTIDADAENVIAR";
            this.CANTIDADAENVIAR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DG_EXISTENCIA
            // 
            this.DG_EXISTENCIA.DataPropertyName = "EXISTENCIA";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.DG_EXISTENCIA.DefaultCellStyle = dataGridViewCellStyle7;
            this.DG_EXISTENCIA.HeaderText = "EXISTENCIA";
            this.DG_EXISTENCIA.Name = "DG_EXISTENCIA";
            this.DG_EXISTENCIA.ReadOnly = true;
            // 
            // DG_ID
            // 
            this.DG_ID.DataPropertyName = "ID";
            this.DG_ID.HeaderText = "ID";
            this.DG_ID.Name = "DG_ID";
            this.DG_ID.ReadOnly = true;
            this.DG_ID.Visible = false;
            // 
            // dETALLE_COMPRA_MOVILBindingSource1
            // 
            this.dETALLE_COMPRA_MOVILBindingSource1.DataMember = "DETALLE_COMPRA_MOVIL";
            this.dETALLE_COMPRA_MOVILBindingSource1.DataSource = this.dSImportaciones3;
            // 
            // dSImportaciones3
            // 
            this.dSImportaciones3.DataSetName = "DSImportaciones3";
            this.dSImportaciones3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DESCRIPCION1";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn8.HeaderText = "CANTIDAD A ENVIAR";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "EXISTENCIA";
            this.dataGridViewTextBoxColumn9.HeaderText = "EXISTENCIA";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn10.HeaderText = "ID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dETALLE_COMPRA_MOVILTableAdapter1
            // 
            this.dETALLE_COMPRA_MOVILTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = iPos.Importaciones.DSImportaciones3TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFDetalleCompraMovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(854, 414);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFDetalleCompraMovil";
            this.Text = "Detalle de Compra";
            this.Load += new System.EventHandler(this.WFDetalleCompraMovil_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dETALLE_COMPRA_MOVILDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLE_COMPRA_MOVILBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DSImportacionesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum dETALLE_COMPRA_MOVILDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button procesarButton;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnImprimirTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Label LBEstatusCliente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBoxFB ALMACENComboBox;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDADAENVIAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_EXISTENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_ID;
        private DSImportaciones3 dSImportaciones3;
        private System.Windows.Forms.BindingSource dETALLE_COMPRA_MOVILBindingSource1;
        private DSImportaciones3TableAdapters.DETALLE_COMPRA_MOVILTableAdapter dETALLE_COMPRA_MOVILTableAdapter1;
        private DSImportaciones3TableAdapters.TableAdapterManager tableAdapterManager1;
    }
}