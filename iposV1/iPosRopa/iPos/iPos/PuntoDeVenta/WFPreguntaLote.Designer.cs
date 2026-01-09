namespace iPos
{
    partial class WFPreguntaLote
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPreguntaLote));
            this.gridLotesDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.pRODUCTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_LOTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_FECHAVENCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CADUCADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PORCADUCAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDADENDOCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASURTIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLotesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dSPuntoDeVentaAux = new iPos.PuntoDeVenta.DSPuntoDeVentaAux();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTPaymentSave = new System.Windows.Forms.Button();
            this.gridLotesTableAdapter1 = new iPos.PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.GridLotesTableAdapter();
            this.tableAdapterManager = new iPos.PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.gridLotesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLotesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLotesDataGridView
            // 
            this.gridLotesDataGridView.AllowUserToAddRows = false;
            this.gridLotesDataGridView.AutoGenerateColumns = false;
            this.gridLotesDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLotesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLotesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLotesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pRODUCTODataGridViewTextBoxColumn,
            this.DG_LOTE,
            this.DG_CANTIDAD,
            this.DG_FECHAVENCE,
            this.CADUCADO,
            this.PORCADUCAR,
            this.CANTIDADENDOCTO,
            this.ASURTIR});
            this.gridLotesDataGridView.DataSource = this.gridLotesBindingSource1;
            this.gridLotesDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridLotesDataGridView.EnableHeadersVisualStyles = false;
            this.gridLotesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.gridLotesDataGridView.Name = "gridLotesDataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLotesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridLotesDataGridView.RowHeadersVisible = false;
            this.gridLotesDataGridView.Size = new System.Drawing.Size(800, 301);
            this.gridLotesDataGridView.TabIndex = 5;
            this.gridLotesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLotesDataGridView_CellClick);
            this.gridLotesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridLotesDataGridView_CellFormatting);
            this.gridLotesDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridLotesDataGridView_CellValidating);
            this.gridLotesDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridLotesDataGridView_KeyPress);
            this.gridLotesDataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.gridLotesDataGridView_PreviewKeyDown);
            // 
            // pRODUCTODataGridViewTextBoxColumn
            // 
            this.pRODUCTODataGridViewTextBoxColumn.DataPropertyName = "PRODUCTO";
            this.pRODUCTODataGridViewTextBoxColumn.HeaderText = "PRODUCTO";
            this.pRODUCTODataGridViewTextBoxColumn.Name = "pRODUCTODataGridViewTextBoxColumn";
            this.pRODUCTODataGridViewTextBoxColumn.Visible = false;
            // 
            // DG_LOTE
            // 
            this.DG_LOTE.DataPropertyName = "LOTE";
            this.DG_LOTE.HeaderText = "LOTE";
            this.DG_LOTE.Name = "DG_LOTE";
            this.DG_LOTE.ReadOnly = true;
            this.DG_LOTE.Width = 200;
            // 
            // DG_CANTIDAD
            // 
            this.DG_CANTIDAD.DataPropertyName = "CANTIDAD";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.DG_CANTIDAD.DefaultCellStyle = dataGridViewCellStyle2;
            this.DG_CANTIDAD.HeaderText = "CANTIDAD";
            this.DG_CANTIDAD.Name = "DG_CANTIDAD";
            this.DG_CANTIDAD.ReadOnly = true;
            this.DG_CANTIDAD.Width = 120;
            // 
            // DG_FECHAVENCE
            // 
            this.DG_FECHAVENCE.DataPropertyName = "FECHAVENCE";
            this.DG_FECHAVENCE.HeaderText = "FECHA VENCE";
            this.DG_FECHAVENCE.Name = "DG_FECHAVENCE";
            this.DG_FECHAVENCE.ReadOnly = true;
            // 
            // CADUCADO
            // 
            this.CADUCADO.DataPropertyName = "CADUCADO";
            this.CADUCADO.HeaderText = "CADUCADO";
            this.CADUCADO.Name = "CADUCADO";
            this.CADUCADO.ReadOnly = true;
            this.CADUCADO.Width = 75;
            // 
            // PORCADUCAR
            // 
            this.PORCADUCAR.DataPropertyName = "PORCADUCAR";
            this.PORCADUCAR.HeaderText = "POR CADUCAR";
            this.PORCADUCAR.Name = "PORCADUCAR";
            this.PORCADUCAR.ReadOnly = true;
            this.PORCADUCAR.Width = 75;
            // 
            // CANTIDADENDOCTO
            // 
            this.CANTIDADENDOCTO.DataPropertyName = "CANTIDADENDOCTO";
            this.CANTIDADENDOCTO.HeaderText = "CANTIDAD EN DOCTO";
            this.CANTIDADENDOCTO.Name = "CANTIDADENDOCTO";
            this.CANTIDADENDOCTO.ReadOnly = true;
            // 
            // ASURTIR
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ASURTIR.DefaultCellStyle = dataGridViewCellStyle3;
            this.ASURTIR.HeaderText = "CANT. A TOMAR";
            this.ASURTIR.Name = "ASURTIR";
            // 
            // gridLotesBindingSource1
            // 
            this.gridLotesBindingSource1.DataMember = "GridLotes";
            this.gridLotesBindingSource1.DataSource = this.dSPuntoDeVentaAux;
            // 
            // dSPuntoDeVentaAux
            // 
            this.dSPuntoDeVentaAux.DataSetName = "DSPuntoDeVentaAux";
            this.dSPuntoDeVentaAux.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PRODUCTO";
            this.dataGridViewTextBoxColumn1.HeaderText = "PRODUCTO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LOTE";
            this.dataGridViewTextBoxColumn2.HeaderText = "LOTE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CANTIDAD";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.HeaderText = "CANTIDAD";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FECHAVENCE";
            this.dataGridViewTextBoxColumn4.HeaderText = "FECHAVENCE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // BTPaymentSave
            // 
            this.BTPaymentSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTPaymentSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTPaymentSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTPaymentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTPaymentSave.ForeColor = System.Drawing.Color.White;
            this.BTPaymentSave.Location = new System.Drawing.Point(329, 307);
            this.BTPaymentSave.Name = "BTPaymentSave";
            this.BTPaymentSave.Size = new System.Drawing.Size(141, 33);
            this.BTPaymentSave.TabIndex = 6;
            this.BTPaymentSave.Text = "Enviar";
            this.BTPaymentSave.UseVisualStyleBackColor = false;
            this.BTPaymentSave.Click += new System.EventHandler(this.BTPaymentSave_Click);
            // 
            // gridLotesTableAdapter1
            // 
            this.gridLotesTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFPreguntaLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(800, 367);
            this.Controls.Add(this.BTPaymentSave);
            this.Controls.Add(this.gridLotesDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "WFPreguntaLote";
            this.Text = "Lista Lote";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.formSkin1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLotesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLotesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        //private Skinner.FormSkin formSkin1;
        private System.Windows.Forms.DataGridViewSum gridLotesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button BTPaymentSave;
        private PuntoDeVenta.DSPuntoDeVentaAux dSPuntoDeVentaAux;
        private System.Windows.Forms.BindingSource gridLotesBindingSource1;
        private PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.GridLotesTableAdapter gridLotesTableAdapter1;
        private PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRODUCTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_LOTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_FECHAVENCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CADUCADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PORCADUCAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDADENDOCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASURTIR;
    }
}