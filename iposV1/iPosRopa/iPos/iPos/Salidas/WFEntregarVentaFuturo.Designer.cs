namespace iPos
{
    partial class WFEntregarVentaFuturo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFEntregarVentaFuturo));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.iMP_FILESDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.GR_REFERENCIAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GR_REFERENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GR_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOLIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GR_TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APLICADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PORAPLICAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recibir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.vENTASFUTUROPENDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSSalidasAux = new iPos.Salidas.DSSalidasAux();
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
            this.tableAdapterManager = new iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager();
            this.mAILRECEPCIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mAILRECEPCIONTableAdapter = new iPos.Importaciones.DSImportacionesTableAdapters.MAILRECEPCIONTableAdapter();
            this.vENTASFUTUROPENDTableAdapter = new iPos.Salidas.DSSalidasAuxTableAdapters.VENTASFUTUROPENDTableAdapter();
            this.tableAdapterManager1 = new iPos.Salidas.DSSalidasAuxTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.iMP_FILESDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vENTASFUTUROPENDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSSalidasAux)).BeginInit();
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.iMP_FILESDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.iMP_FILESDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iMP_FILESDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GR_REFERENCIAS,
            this.GR_REFERENCIA,
            this.GR_ID,
            this.FOLIO,
            this.GR_TOTAL,
            this.APLICADO,
            this.PORAPLICAR,
            this.NOMBRE,
            this.Recibir,
            this.Eliminar});
            this.iMP_FILESDataGridView.DataSource = this.vENTASFUTUROPENDBindingSource;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iMP_FILESDataGridView.DefaultCellStyle = dataGridViewCellStyle12;
            this.iMP_FILESDataGridView.EnableHeadersVisualStyles = false;
            this.iMP_FILESDataGridView.Location = new System.Drawing.Point(12, 25);
            this.iMP_FILESDataGridView.Name = "iMP_FILESDataGridView";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.iMP_FILESDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.iMP_FILESDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            this.iMP_FILESDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.iMP_FILESDataGridView.Size = new System.Drawing.Size(768, 271);
            this.iMP_FILESDataGridView.TabIndex = 4;
            this.iMP_FILESDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.iMP_FILESDataGridView_CellClick);
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
            this.FOLIO.Width = 70;
            // 
            // GR_TOTAL
            // 
            this.GR_TOTAL.DataPropertyName = "TOTAL";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.GR_TOTAL.DefaultCellStyle = dataGridViewCellStyle9;
            this.GR_TOTAL.HeaderText = "TOTAL";
            this.GR_TOTAL.Name = "GR_TOTAL";
            this.GR_TOTAL.ReadOnly = true;
            this.GR_TOTAL.Width = 80;
            // 
            // APLICADO
            // 
            this.APLICADO.DataPropertyName = "APLICADO";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.APLICADO.DefaultCellStyle = dataGridViewCellStyle10;
            this.APLICADO.HeaderText = "APLICADO";
            this.APLICADO.Name = "APLICADO";
            this.APLICADO.Width = 80;
            // 
            // PORAPLICAR
            // 
            this.PORAPLICAR.DataPropertyName = "PORAPLICAR";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PORAPLICAR.DefaultCellStyle = dataGridViewCellStyle11;
            this.PORAPLICAR.HeaderText = "POR APLICAR";
            this.PORAPLICAR.Name = "PORAPLICAR";
            this.PORAPLICAR.Width = 80;
            // 
            // NOMBRE
            // 
            this.NOMBRE.DataPropertyName = "NOMBRE";
            this.NOMBRE.HeaderText = "CLIENTE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.Width = 200;
            // 
            // Recibir
            // 
            this.Recibir.HeaderText = "";
            this.Recibir.Name = "Recibir";
            this.Recibir.Text = "Surtir";
            this.Recibir.UseColumnTextForButtonValue = true;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Text = "Finalizar";
            this.Eliminar.UseColumnTextForButtonValue = true;
            // 
            // vENTASFUTUROPENDBindingSource
            // 
            this.vENTASFUTUROPENDBindingSource.DataMember = "VENTASFUTUROPEND";
            this.vENTASFUTUROPENDBindingSource.DataSource = this.dSSalidasAux;
            // 
            // dSSalidasAux
            // 
            this.dSSalidasAux.DataSetName = "DSSalidasAux";
            this.dSSalidasAux.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ventas a futuro";
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
            // vENTASFUTUROPENDTableAdapter
            // 
            this.vENTASFUTUROPENDTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = iPos.Salidas.DSSalidasAuxTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFEntregarVentaFuturo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(792, 398);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.iMP_FILESDataGridView);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFEntregarVentaFuturo";
            this.Text = "Lista de ventas a futuro pendientes de aplicar";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.WFEntregarVentaFuturo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iMP_FILESDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vENTASFUTUROPENDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSSalidasAux)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Importaciones.DSImportacionesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource mAILRECEPCIONBindingSource;
        private Importaciones.DSImportacionesTableAdapters.MAILRECEPCIONTableAdapter mAILRECEPCIONTableAdapter;
        private Salidas.DSSalidasAux dSSalidasAux;
        private System.Windows.Forms.BindingSource vENTASFUTUROPENDBindingSource;
        private Salidas.DSSalidasAuxTableAdapters.VENTASFUTUROPENDTableAdapter vENTASFUTUROPENDTableAdapter;
        private Salidas.DSSalidasAuxTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GR_REFERENCIAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn GR_REFERENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn GR_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOLIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn GR_TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn APLICADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PORAPLICAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewButtonColumn Recibir;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        //private Skinner.FormSkin formSkin1;
    }
}