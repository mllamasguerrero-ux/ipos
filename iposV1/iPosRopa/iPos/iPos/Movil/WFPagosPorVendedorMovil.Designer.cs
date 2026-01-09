namespace iPos.Movil
{
    partial class WFPagosPorVendedorMovil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPagosPorVendedorMovil));
            this.dSMovil5 = new iPos.Movil.DSMovil5();
            this.pAGOS_MOVIL_POR_VENDEDORBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pAGOS_MOVIL_POR_VENDEDORTableAdapter = new iPos.Movil.DSMovil5TableAdapters.PAGOS_MOVIL_POR_VENDEDORTableAdapter();
            this.tableAdapterManager = new iPos.Movil.DSMovil5TableAdapters.TableAdapterManager();
            this.pAGOS_MOVIL_POR_VENDEDORDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DGFECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVENDEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVer = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOS_MOVIL_POR_VENDEDORBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOS_MOVIL_POR_VENDEDORDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dSMovil5
            // 
            this.dSMovil5.DataSetName = "DSMovil5";
            this.dSMovil5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pAGOS_MOVIL_POR_VENDEDORBindingSource
            // 
            this.pAGOS_MOVIL_POR_VENDEDORBindingSource.DataMember = "PAGOS_MOVIL_POR_VENDEDOR";
            this.pAGOS_MOVIL_POR_VENDEDORBindingSource.DataSource = this.dSMovil5;
            // 
            // pAGOS_MOVIL_POR_VENDEDORTableAdapter
            // 
            this.pAGOS_MOVIL_POR_VENDEDORTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Movil.DSMovil5TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // pAGOS_MOVIL_POR_VENDEDORDataGridView
            // 
            this.pAGOS_MOVIL_POR_VENDEDORDataGridView.AllowUserToAddRows = false;
            this.pAGOS_MOVIL_POR_VENDEDORDataGridView.AllowUserToDeleteRows = false;
            this.pAGOS_MOVIL_POR_VENDEDORDataGridView.AutoGenerateColumns = false;
            this.pAGOS_MOVIL_POR_VENDEDORDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pAGOS_MOVIL_POR_VENDEDORDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGFECHA,
            this.DGVENDEDOR,
            this.dataGridViewTextBoxColumn4,
            this.btnVer});
            this.pAGOS_MOVIL_POR_VENDEDORDataGridView.DataSource = this.pAGOS_MOVIL_POR_VENDEDORBindingSource;
            this.pAGOS_MOVIL_POR_VENDEDORDataGridView.Location = new System.Drawing.Point(12, 12);
            this.pAGOS_MOVIL_POR_VENDEDORDataGridView.Name = "pAGOS_MOVIL_POR_VENDEDORDataGridView";
            this.pAGOS_MOVIL_POR_VENDEDORDataGridView.RowHeadersVisible = false;
            this.pAGOS_MOVIL_POR_VENDEDORDataGridView.Size = new System.Drawing.Size(474, 343);
            this.pAGOS_MOVIL_POR_VENDEDORDataGridView.TabIndex = 1;
            this.pAGOS_MOVIL_POR_VENDEDORDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pAGOS_MOVIL_POR_VENDEDORDataGridView_CellContentClick);
            // 
            // DGFECHA
            // 
            this.DGFECHA.DataPropertyName = "FECHA";
            this.DGFECHA.HeaderText = "FECHA";
            this.DGFECHA.Name = "DGFECHA";
            // 
            // DGVENDEDOR
            // 
            this.DGVENDEDOR.DataPropertyName = "VENDEDOR";
            this.DGVENDEDOR.HeaderText = "VENDEDOR";
            this.DGVENDEDOR.Name = "DGVENDEDOR";
            this.DGVENDEDOR.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MONTO";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn4.HeaderText = "MONTO";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 160;
            // 
            // btnVer
            // 
            this.btnVer.HeaderText = "";
            this.btnVer.Image = global::iPos.Properties.Resources.search_J;
            this.btnVer.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.btnVer.Name = "btnVer";
            this.btnVer.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnVer.Width = 30;
            // 
            // WFPagosPorVendedorMovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(497, 367);
            this.Controls.Add(this.pAGOS_MOVIL_POR_VENDEDORDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFPagosPorVendedorMovil";
            this.Text = "WFPagosPorVendedorMovil";
            this.Load += new System.EventHandler(this.WFPagosPorVendedorMovil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOS_MOVIL_POR_VENDEDORBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOS_MOVIL_POR_VENDEDORDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSMovil5 dSMovil5;
        private System.Windows.Forms.BindingSource pAGOS_MOVIL_POR_VENDEDORBindingSource;
        private DSMovil5TableAdapters.PAGOS_MOVIL_POR_VENDEDORTableAdapter pAGOS_MOVIL_POR_VENDEDORTableAdapter;
        private DSMovil5TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum pAGOS_MOVIL_POR_VENDEDORDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVENDEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewImageColumn btnVer;
    }
}