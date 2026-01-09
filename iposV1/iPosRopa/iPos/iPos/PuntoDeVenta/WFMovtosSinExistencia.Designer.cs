namespace iPos
{
    partial class WFMovtosSinExistencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFMovtosSinExistencia));
            this.dSPuntoDeVentaAux = new iPos.PuntoDeVenta.DSPuntoDeVentaAux();
            this.mOVTOS_SINEXISTENCIABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mOVTOS_SINEXISTENCIATableAdapter = new iPos.PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.MOVTOS_SINEXISTENCIATableAdapter();
            this.tableAdapterManager = new iPos.PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.TableAdapterManager();
            this.mOVTOS_SINEXISTENCIADataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mOVTOS_SINEXISTENCIABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mOVTOS_SINEXISTENCIADataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dSPuntoDeVentaAux
            // 
            this.dSPuntoDeVentaAux.DataSetName = "DSPuntoDeVentaAux";
            this.dSPuntoDeVentaAux.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mOVTOS_SINEXISTENCIABindingSource
            // 
            this.mOVTOS_SINEXISTENCIABindingSource.DataMember = "MOVTOS_SINEXISTENCIA";
            this.mOVTOS_SINEXISTENCIABindingSource.DataSource = this.dSPuntoDeVentaAux;
            // 
            // mOVTOS_SINEXISTENCIATableAdapter
            // 
            this.mOVTOS_SINEXISTENCIATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // mOVTOS_SINEXISTENCIADataGridView
            // 
            this.mOVTOS_SINEXISTENCIADataGridView.AllowUserToAddRows = false;
            this.mOVTOS_SINEXISTENCIADataGridView.AutoGenerateColumns = false;
            this.mOVTOS_SINEXISTENCIADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mOVTOS_SINEXISTENCIADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.mOVTOS_SINEXISTENCIADataGridView.DataSource = this.mOVTOS_SINEXISTENCIABindingSource;
            this.mOVTOS_SINEXISTENCIADataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mOVTOS_SINEXISTENCIADataGridView.Location = new System.Drawing.Point(0, 0);
            this.mOVTOS_SINEXISTENCIADataGridView.Name = "mOVTOS_SINEXISTENCIADataGridView";
            this.mOVTOS_SINEXISTENCIADataGridView.ReadOnly = true;
            this.mOVTOS_SINEXISTENCIADataGridView.RowHeadersVisible = false;
            this.mOVTOS_SINEXISTENCIADataGridView.Size = new System.Drawing.Size(723, 368);
            this.mOVTOS_SINEXISTENCIADataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MOVTOID";
            this.dataGridViewTextBoxColumn1.HeaderText = "DETALLE ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DOCTOID";
            this.dataGridViewTextBoxColumn2.HeaderText = "DOCTOID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DOCTOFOLIO";
            this.dataGridViewTextBoxColumn3.HeaderText = "DOCTOFOLIO";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PRODUCTOID";
            this.dataGridViewTextBoxColumn4.HeaderText = "PRODUCTOID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn5.HeaderText = "PRODUCTO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn6.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DESCRIPCION";
            this.dataGridViewTextBoxColumn7.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn8.HeaderText = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DESCRIPCION2";
            this.dataGridViewTextBoxColumn9.HeaderText = "DESCRIPCION2";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "EXISTENCIA";
            this.dataGridViewTextBoxColumn10.HeaderText = "EXISTENCIA";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "CANTIDADMOVTO";
            this.dataGridViewTextBoxColumn11.HeaderText = "CANTIDAD";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "DIFERENCIA";
            this.dataGridViewTextBoxColumn12.HeaderText = "DIFERENCIA";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // WFMovtosSinExistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 368);
            this.Controls.Add(this.mOVTOS_SINEXISTENCIADataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFMovtosSinExistencia";
            this.Text = "Detalles sin existencia suficiente";
            this.Load += new System.EventHandler(this.WFMovtosSinExistencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mOVTOS_SINEXISTENCIABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mOVTOS_SINEXISTENCIADataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PuntoDeVenta.DSPuntoDeVentaAux dSPuntoDeVentaAux;
        private System.Windows.Forms.BindingSource mOVTOS_SINEXISTENCIABindingSource;
        private PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.MOVTOS_SINEXISTENCIATableAdapter mOVTOS_SINEXISTENCIATableAdapter;
        private PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum mOVTOS_SINEXISTENCIADataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
    }
}