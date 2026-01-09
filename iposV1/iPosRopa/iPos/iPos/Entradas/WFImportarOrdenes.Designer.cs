namespace iPos
{
    partial class WFImportarOrdenes
    {
        
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFImportarOrdenes));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.iMP_FILESDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.cOMPRASINCOMPLETASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSImportaciones = new iPos.Importaciones.DSImportaciones();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cOMPRASINCOMPLETASTableAdapter = new iPos.Importaciones.DSImportacionesTableAdapters.COMPRASINCOMPLETASTableAdapter();
            this.tableAdapterManager = new iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager();
            this.mAILRECEPCIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mAILRECEPCIONTableAdapter = new iPos.Importaciones.DSImportacionesTableAdapters.MAILRECEPCIONTableAdapter();
            this.GR_REFERENCIAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GR_REFERENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GR_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOLIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GR_TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VENDEDORNOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recibir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGALMACENNOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.iMP_FILESDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMPRASINCOMPLETASBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAILRECEPCIONBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // iMP_FILESDataGridView
            // 
            this.iMP_FILESDataGridView.AllowUserToAddRows = false;
            this.iMP_FILESDataGridView.AutoGenerateColumns = false;
            this.iMP_FILESDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.iMP_FILESDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.iMP_FILESDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iMP_FILESDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GR_REFERENCIAS,
            this.GR_REFERENCIA,
            this.GR_ID,
            this.FOLIO,
            this.GR_TOTAL,
            this.NOMBRE,
            this.FECHA,
            this.VENDEDORNOMBRE,
            this.Recibir,
            this.Eliminar,
            this.DGALMACENNOMBRE});
            this.iMP_FILESDataGridView.DataSource = this.cOMPRASINCOMPLETASBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iMP_FILESDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.iMP_FILESDataGridView.EnableHeadersVisualStyles = false;
            this.iMP_FILESDataGridView.Location = new System.Drawing.Point(12, 25);
            this.iMP_FILESDataGridView.Name = "iMP_FILESDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.iMP_FILESDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.iMP_FILESDataGridView.RowHeadersVisible = false;
            this.iMP_FILESDataGridView.Size = new System.Drawing.Size(768, 290);
            this.iMP_FILESDataGridView.TabIndex = 4;
            this.iMP_FILESDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.iMP_FILESDataGridView_CellClick);
            // 
            // cOMPRASINCOMPLETASBindingSource
            // 
            this.cOMPRASINCOMPLETASBindingSource.DataMember = "COMPRASINCOMPLETAS";
            this.cOMPRASINCOMPLETASBindingSource.DataSource = this.dSImportaciones;
            // 
            // dSImportaciones
            // 
            this.dSImportaciones.DataSetName = "DSImportaciones";
            this.dSImportaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lista de archivos importados pendientes";
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Recibir";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "Recibir";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IF_REMOTE_FILE";
            this.dataGridViewTextBoxColumn1.HeaderText = "IF_REMOTE_FILE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "REFERENCIAS";
            this.dataGridViewTextBoxColumn2.HeaderText = "ARCHIVO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "REFERENCIA";
            this.dataGridViewTextBoxColumn3.HeaderText = "REFERENCIA";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "IF_TIPO";
            this.dataGridViewTextBoxColumn4.HeaderText = "IF_TIPO";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "IF_REMOTE_FILE";
            this.dataGridViewTextBoxColumn5.HeaderText = "IF_REMOTE_FILE";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "IF_TIME";
            this.dataGridViewTextBoxColumn6.HeaderText = "IF_TIME";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "Devolver Restante";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "Devolver Restante";
            // 
            // cOMPRASINCOMPLETASTableAdapter
            // 
            this.cOMPRASINCOMPLETASTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // mAILRECEPCIONBindingSource
            // 
            this.mAILRECEPCIONBindingSource.DataMember = "MAILRECEPCION";
            this.mAILRECEPCIONBindingSource.DataSource = this.dSImportaciones;
            // 
            // mAILRECEPCIONTableAdapter
            // 
            this.mAILRECEPCIONTableAdapter.ClearBeforeFill = true;
            // 
            // GR_REFERENCIAS
            // 
            this.GR_REFERENCIAS.DataPropertyName = "REFERENCIAS";
            this.GR_REFERENCIAS.HeaderText = "ARCHIVO";
            this.GR_REFERENCIAS.Name = "GR_REFERENCIAS";
            this.GR_REFERENCIAS.ReadOnly = true;
            this.GR_REFERENCIAS.Visible = false;
            // 
            // GR_REFERENCIA
            // 
            this.GR_REFERENCIA.DataPropertyName = "REFERENCIA";
            this.GR_REFERENCIA.HeaderText = "REFERENCIA";
            this.GR_REFERENCIA.Name = "GR_REFERENCIA";
            this.GR_REFERENCIA.ReadOnly = true;
            this.GR_REFERENCIA.Visible = false;
            // 
            // GR_ID
            // 
            this.GR_ID.DataPropertyName = "ID";
            this.GR_ID.HeaderText = "ID";
            this.GR_ID.Name = "GR_ID";
            this.GR_ID.ReadOnly = true;
            this.GR_ID.Visible = false;
            // 
            // FOLIO
            // 
            this.FOLIO.DataPropertyName = "FOLIO";
            this.FOLIO.HeaderText = "FOLIO";
            this.FOLIO.Name = "FOLIO";
            this.FOLIO.ReadOnly = true;
            this.FOLIO.Width = 75;
            // 
            // GR_TOTAL
            // 
            this.GR_TOTAL.DataPropertyName = "TOTAL";
            this.GR_TOTAL.HeaderText = "TOTAL";
            this.GR_TOTAL.Name = "GR_TOTAL";
            this.GR_TOTAL.ReadOnly = true;
            this.GR_TOTAL.Width = 85;
            // 
            // NOMBRE
            // 
            this.NOMBRE.DataPropertyName = "NOMBRE";
            this.NOMBRE.HeaderText = "PROVEEDOR";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.Width = 170;
            // 
            // FECHA
            // 
            this.FECHA.DataPropertyName = "FECHA";
            this.FECHA.HeaderText = "FECHA";
            this.FECHA.Name = "FECHA";
            this.FECHA.Width = 75;
            // 
            // VENDEDORNOMBRE
            // 
            this.VENDEDORNOMBRE.DataPropertyName = "VENDEDORNOMBRE";
            this.VENDEDORNOMBRE.HeaderText = "VENDEDOR";
            this.VENDEDORNOMBRE.Name = "VENDEDORNOMBRE";
            this.VENDEDORNOMBRE.Width = 125;
            // 
            // Recibir
            // 
            this.Recibir.HeaderText = "";
            this.Recibir.Name = "Recibir";
            this.Recibir.Text = "Recibir";
            this.Recibir.UseColumnTextForButtonValue = true;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseColumnTextForButtonValue = true;
            // 
            // DGALMACENNOMBRE
            // 
            this.DGALMACENNOMBRE.DataPropertyName = "ALMACENNOMBRE";
            this.DGALMACENNOMBRE.HeaderText = "ALMACEN";
            this.DGALMACENNOMBRE.Name = "DGALMACENNOMBRE";
            this.DGALMACENNOMBRE.Width = 80;
            // 
            // WFImportarOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(792, 334);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.iMP_FILESDataGridView);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFImportarOrdenes";
            this.Text = "Lista de ordenes pendientes a importar";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.WFImportarOrdenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iMP_FILESDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMPRASINCOMPLETASBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAILRECEPCIONBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewSum iMP_FILESDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private iPos.Importaciones.DSImportaciones dSImportaciones;
        private System.Windows.Forms.BindingSource cOMPRASINCOMPLETASBindingSource;
        private iPos.Importaciones.DSImportacionesTableAdapters.COMPRASINCOMPLETASTableAdapter cOMPRASINCOMPLETASTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Importaciones.DSImportacionesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource mAILRECEPCIONBindingSource;
        private Importaciones.DSImportacionesTableAdapters.MAILRECEPCIONTableAdapter mAILRECEPCIONTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn GR_REFERENCIAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn GR_REFERENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn GR_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOLIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn GR_TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn VENDEDORNOMBRE;
        private System.Windows.Forms.DataGridViewButtonColumn Recibir;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGALMACENNOMBRE;
        //private Skinner.FormSkin formSkin1;
    }
}