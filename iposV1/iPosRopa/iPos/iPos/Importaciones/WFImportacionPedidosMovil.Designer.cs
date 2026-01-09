namespace iPos.Importaciones
{
    partial class WFImportacionPedidosMovil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFImportacionPedidosMovil));
            this.iNFO_PEDIDOS_MOVILDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.iNFO_PEDIDOS_MOVILBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSImportaciones = new iPos.Importaciones.DSImportaciones();
            this.iNFO_PEDIDOS_MOVILTableAdapter = new iPos.Importaciones.DSImportacionesTableAdapters.INFO_PEDIDOS_MOVILTableAdapter();
            this.tableAdapterManager = new iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGCLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGNOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPENDIENTES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGENRUTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCOTI_ENRUTADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VISUALIZAR = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.iNFO_PEDIDOS_MOVILDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNFO_PEDIDOS_MOVILBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // iNFO_PEDIDOS_MOVILDataGridView
            // 
            this.iNFO_PEDIDOS_MOVILDataGridView.AllowUserToAddRows = false;
            this.iNFO_PEDIDOS_MOVILDataGridView.AllowUserToDeleteRows = false;
            this.iNFO_PEDIDOS_MOVILDataGridView.AutoGenerateColumns = false;
            this.iNFO_PEDIDOS_MOVILDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.iNFO_PEDIDOS_MOVILDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.iNFO_PEDIDOS_MOVILDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iNFO_PEDIDOS_MOVILDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCLAVE,
            this.DGNOMBRE,
            this.DGID,
            this.DGPENDIENTES,
            this.DGENRUTA,
            this.DGCOTI_ENRUTADA,
            this.VISUALIZAR});
            this.iNFO_PEDIDOS_MOVILDataGridView.DataSource = this.iNFO_PEDIDOS_MOVILBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iNFO_PEDIDOS_MOVILDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.iNFO_PEDIDOS_MOVILDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iNFO_PEDIDOS_MOVILDataGridView.Location = new System.Drawing.Point(0, 0);
            this.iNFO_PEDIDOS_MOVILDataGridView.Name = "iNFO_PEDIDOS_MOVILDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.iNFO_PEDIDOS_MOVILDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.iNFO_PEDIDOS_MOVILDataGridView.RowHeadersVisible = false;
            this.iNFO_PEDIDOS_MOVILDataGridView.Size = new System.Drawing.Size(640, 402);
            this.iNFO_PEDIDOS_MOVILDataGridView.TabIndex = 1;
            this.iNFO_PEDIDOS_MOVILDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.iNFO_PEDIDOS_MOVILDataGridView_CellClick);
            // 
            // iNFO_PEDIDOS_MOVILBindingSource
            // 
            this.iNFO_PEDIDOS_MOVILBindingSource.DataMember = "INFO_PEDIDOS_MOVIL";
            this.iNFO_PEDIDOS_MOVILBindingSource.DataSource = this.dSImportaciones;
            // 
            // dSImportaciones
            // 
            this.dSImportaciones.DataSetName = "DSImportaciones";
            this.dSImportaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // iNFO_PEDIDOS_MOVILTableAdapter
            // 
            this.iNFO_PEDIDOS_MOVILTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PENDIENTES";
            this.dataGridViewTextBoxColumn4.HeaderText = "PENDIENTES";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ENRUTA";
            this.dataGridViewTextBoxColumn5.HeaderText = "ENRUTA";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "VER";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // DGCLAVE
            // 
            this.DGCLAVE.DataPropertyName = "CLAVE";
            this.DGCLAVE.HeaderText = "CLAVE";
            this.DGCLAVE.Name = "DGCLAVE";
            // 
            // DGNOMBRE
            // 
            this.DGNOMBRE.DataPropertyName = "NOMBRE";
            this.DGNOMBRE.HeaderText = "NOMBRE";
            this.DGNOMBRE.Name = "DGNOMBRE";
            this.DGNOMBRE.Width = 200;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // DGPENDIENTES
            // 
            this.DGPENDIENTES.DataPropertyName = "PENDIENTES";
            this.DGPENDIENTES.HeaderText = "PENDIENTES";
            this.DGPENDIENTES.Name = "DGPENDIENTES";
            // 
            // DGENRUTA
            // 
            this.DGENRUTA.DataPropertyName = "ENRUTA";
            this.DGENRUTA.HeaderText = "ENRUTA";
            this.DGENRUTA.Name = "DGENRUTA";
            this.DGENRUTA.Visible = false;
            // 
            // DGCOTI_ENRUTADA
            // 
            this.DGCOTI_ENRUTADA.DataPropertyName = "COTI_ENRUTADA";
            this.DGCOTI_ENRUTADA.HeaderText = "COTIZACION";
            this.DGCOTI_ENRUTADA.Name = "DGCOTI_ENRUTADA";
            // 
            // VISUALIZAR
            // 
            this.VISUALIZAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VISUALIZAR.HeaderText = "";
            this.VISUALIZAR.Name = "VISUALIZAR";
            this.VISUALIZAR.Text = "VER";
            this.VISUALIZAR.UseColumnTextForButtonValue = true;
            // 
            // WFImportacionPedidosMovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(640, 402);
            this.Controls.Add(this.iNFO_PEDIDOS_MOVILDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFImportacionPedidosMovil";
            this.Text = "Información de Pedidos Pendientes por Vendedor";
            this.Load += new System.EventHandler(this.WFImportacionPedidosMovil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iNFO_PEDIDOS_MOVILDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNFO_PEDIDOS_MOVILBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSImportaciones dSImportaciones;
        private System.Windows.Forms.BindingSource iNFO_PEDIDOS_MOVILBindingSource;
        private DSImportacionesTableAdapters.INFO_PEDIDOS_MOVILTableAdapter iNFO_PEDIDOS_MOVILTableAdapter;
        private DSImportacionesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum iNFO_PEDIDOS_MOVILDataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGNOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPENDIENTES;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGENRUTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCOTI_ENRUTADA;
        private System.Windows.Forms.DataGridViewButtonColumn VISUALIZAR;
    }
}