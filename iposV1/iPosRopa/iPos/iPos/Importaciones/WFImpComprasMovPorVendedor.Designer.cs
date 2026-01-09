namespace iPos.Importaciones
{
    partial class WFImpComprasMovPorVendedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFImpComprasMovPorVendedor));
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSImportaciones = new iPos.Importaciones.DSImportaciones();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBImprimirRecibosFacturas = new System.Windows.Forms.CheckBox();
            this.datosVendedorLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.procesarTodosButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORTableAdapter = new iPos.Importaciones.DSImportacionesTableAdapters.INFO_COMPRAS_MOVIL_X_VENDEDORTableAdapter();
            this.tableAdapterManager = new iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager();
            this.VER = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PROCESAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGELIMINAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGORDENCOMPRA = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOCTO_REFERENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFECHAHORA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNFO_COMPRAS_MOVIL_X_VENDEDORBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView
            // 
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.AllowUserToAddRows = false;
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.AllowUserToDeleteRows = false;
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.AutoGenerateColumns = false;
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VER,
            this.PROCESAR,
            this.DGELIMINAR,
            this.DGORDENCOMPRA,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.DOCTO_REFERENCIA,
            this.dataGridViewTextBoxColumn4,
            this.DGFECHA,
            this.DGFECHAHORA,
            this.DGID});
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.DataSource = this.iNFO_COMPRAS_MOVIL_X_VENDEDORBindingSource;
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.Location = new System.Drawing.Point(0, 0);
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.Name = "iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView";
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.RowHeadersVisible = false;
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.Size = new System.Drawing.Size(966, 349);
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.TabIndex = 2;
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView_CellClick);
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView_DataBindingComplete);
            // 
            // iNFO_COMPRAS_MOVIL_X_VENDEDORBindingSource
            // 
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORBindingSource.DataMember = "INFO_COMPRAS_MOVIL_X_VENDEDOR";
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORBindingSource.DataSource = this.dSImportaciones;
            // 
            // dSImportaciones
            // 
            this.dSImportaciones.DataSetName = "DSImportaciones";
            this.dSImportaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.CBImprimirRecibosFacturas);
            this.panel1.Controls.Add(this.datosVendedorLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.procesarTodosButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(966, 100);
            this.panel1.TabIndex = 3;
            // 
            // CBImprimirRecibosFacturas
            // 
            this.CBImprimirRecibosFacturas.AutoSize = true;
            this.CBImprimirRecibosFacturas.Checked = true;
            this.CBImprimirRecibosFacturas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBImprimirRecibosFacturas.ForeColor = System.Drawing.Color.White;
            this.CBImprimirRecibosFacturas.Location = new System.Drawing.Point(142, 66);
            this.CBImprimirRecibosFacturas.Name = "CBImprimirRecibosFacturas";
            this.CBImprimirRecibosFacturas.Size = new System.Drawing.Size(147, 17);
            this.CBImprimirRecibosFacturas.TabIndex = 3;
            this.CBImprimirRecibosFacturas.Text = "Imprimir recibos y facturas";
            this.CBImprimirRecibosFacturas.UseVisualStyleBackColor = true;
            // 
            // datosVendedorLabel
            // 
            this.datosVendedorLabel.AutoSize = true;
            this.datosVendedorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datosVendedorLabel.ForeColor = System.Drawing.Color.White;
            this.datosVendedorLabel.Location = new System.Drawing.Point(109, 18);
            this.datosVendedorLabel.Name = "datosVendedorLabel";
            this.datosVendedorLabel.Size = new System.Drawing.Size(19, 13);
            this.datosVendedorLabel.TabIndex = 2;
            this.datosVendedorLabel.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "VENDEDOR:";
            // 
            // procesarTodosButton
            // 
            this.procesarTodosButton.BackColor = System.Drawing.Color.Firebrick;
            this.procesarTodosButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.procesarTodosButton.ForeColor = System.Drawing.Color.White;
            this.procesarTodosButton.Location = new System.Drawing.Point(313, 60);
            this.procesarTodosButton.Name = "procesarTodosButton";
            this.procesarTodosButton.Size = new System.Drawing.Size(93, 23);
            this.procesarTodosButton.TabIndex = 0;
            this.procesarTodosButton.Text = "Procesar Todos";
            this.procesarTodosButton.UseVisualStyleBackColor = false;
            this.procesarTodosButton.Click += new System.EventHandler(this.procesarTodosButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(966, 349);
            this.panel2.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn1.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "VER";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "PROCESAR";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn5.HeaderText = "ID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // iNFO_COMPRAS_MOVIL_X_VENDEDORTableAdapter
            // 
            this.iNFO_COMPRAS_MOVIL_X_VENDEDORTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // VER
            // 
            this.VER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VER.HeaderText = "";
            this.VER.Name = "VER";
            this.VER.Text = "VER";
            this.VER.UseColumnTextForButtonValue = true;
            this.VER.Width = 60;
            // 
            // PROCESAR
            // 
            this.PROCESAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PROCESAR.HeaderText = "";
            this.PROCESAR.Name = "PROCESAR";
            this.PROCESAR.Text = "PROCESAR";
            this.PROCESAR.UseColumnTextForButtonValue = true;
            this.PROCESAR.Width = 75;
            // 
            // DGELIMINAR
            // 
            this.DGELIMINAR.HeaderText = "";
            this.DGELIMINAR.Name = "DGELIMINAR";
            this.DGELIMINAR.Text = "ELIMINAR";
            this.DGELIMINAR.UseColumnTextForButtonValue = true;
            this.DGELIMINAR.Width = 75;
            // 
            // DGORDENCOMPRA
            // 
            this.DGORDENCOMPRA.HeaderText = "";
            this.DGORDENCOMPRA.Name = "DGORDENCOMPRA";
            this.DGORDENCOMPRA.Text = "ORDEN DE COMPRA";
            this.DGORDENCOMPRA.UseColumnTextForButtonValue = true;
            this.DGORDENCOMPRA.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DOCTO_REFERENCIA";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn2.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NOMBRE";
            dataGridViewCellStyle2.Format = "N2";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn3.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // DOCTO_REFERENCIA
            // 
            this.DOCTO_REFERENCIA.DataPropertyName = "DOCTO_REFERENCIA";
            this.DOCTO_REFERENCIA.HeaderText = "FACTURA";
            this.DOCTO_REFERENCIA.Name = "DOCTO_REFERENCIA";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TOTAL";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // DGFECHA
            // 
            this.DGFECHA.DataPropertyName = "FECHA";
            this.DGFECHA.HeaderText = "FECHA";
            this.DGFECHA.Name = "DGFECHA";
            this.DGFECHA.ReadOnly = true;
            this.DGFECHA.Width = 75;
            // 
            // DGFECHAHORA
            // 
            this.DGFECHAHORA.DataPropertyName = "FECHAHORA";
            dataGridViewCellStyle4.Format = "t";
            dataGridViewCellStyle4.NullValue = null;
            this.DGFECHAHORA.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGFECHAHORA.HeaderText = "HORA";
            this.DGFECHAHORA.Name = "DGFECHAHORA";
            this.DGFECHAHORA.ReadOnly = true;
            this.DGFECHAHORA.Width = 75;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // WFImpComprasMovPorVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(966, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFImpComprasMovPorVendedor";
            this.Text = "Compras Pendientes por Vendedor";
            this.Load += new System.EventHandler(this.WFImpComprasMovPorVendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNFO_COMPRAS_MOVIL_X_VENDEDORBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DSImportaciones dSImportaciones;
        private System.Windows.Forms.BindingSource iNFO_COMPRAS_MOVIL_X_VENDEDORBindingSource;
        private DSImportacionesTableAdapters.INFO_COMPRAS_MOVIL_X_VENDEDORTableAdapter iNFO_COMPRAS_MOVIL_X_VENDEDORTableAdapter;
        private DSImportacionesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button procesarTodosButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label datosVendedorLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.CheckBox CBImprimirRecibosFacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn VER;
        private System.Windows.Forms.DataGridViewButtonColumn PROCESAR;
        private System.Windows.Forms.DataGridViewButtonColumn DGELIMINAR;
        private System.Windows.Forms.DataGridViewButtonColumn DGORDENCOMPRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCTO_REFERENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFECHAHORA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
    }
}