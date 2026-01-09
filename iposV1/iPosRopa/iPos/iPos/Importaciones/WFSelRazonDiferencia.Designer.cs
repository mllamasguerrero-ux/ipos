namespace iPos
{
    partial class WFSelRazonDiferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFSelRazonDiferencia));
            this.dSImportaciones = new iPos.Importaciones.DSImportaciones();
            this.tIPODIFERENCIAINVENTARIOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tIPODIFERENCIAINVENTARIOTableAdapter = new iPos.Importaciones.DSImportacionesTableAdapters.TIPODIFERENCIAINVENTARIOTableAdapter();
            this.tableAdapterManager = new iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager();
            this.tIPODIFERENCIAINVENTARIODataGridView = new System.Windows.Forms.DataGridViewSum();
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
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tIPODIFERENCIAINVENTARIOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tIPODIFERENCIAINVENTARIODataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dSImportaciones
            // 
            this.dSImportaciones.DataSetName = "DSImportaciones";
            this.dSImportaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tIPODIFERENCIAINVENTARIOBindingSource
            // 
            this.tIPODIFERENCIAINVENTARIOBindingSource.DataMember = "TIPODIFERENCIAINVENTARIO";
            this.tIPODIFERENCIAINVENTARIOBindingSource.DataSource = this.dSImportaciones;
            // 
            // tIPODIFERENCIAINVENTARIOTableAdapter
            // 
            this.tIPODIFERENCIAINVENTARIOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tIPODIFERENCIAINVENTARIODataGridView
            // 
            this.tIPODIFERENCIAINVENTARIODataGridView.AllowUserToAddRows = false;
            this.tIPODIFERENCIAINVENTARIODataGridView.AutoGenerateColumns = false;
            this.tIPODIFERENCIAINVENTARIODataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tIPODIFERENCIAINVENTARIODataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tIPODIFERENCIAINVENTARIODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tIPODIFERENCIAINVENTARIODataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dataGridViewTextBoxColumn11});
            this.tIPODIFERENCIAINVENTARIODataGridView.DataSource = this.tIPODIFERENCIAINVENTARIOBindingSource;
            this.tIPODIFERENCIAINVENTARIODataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tIPODIFERENCIAINVENTARIODataGridView.EnableHeadersVisualStyles = false;
            this.tIPODIFERENCIAINVENTARIODataGridView.Location = new System.Drawing.Point(0, 0);
            this.tIPODIFERENCIAINVENTARIODataGridView.Name = "tIPODIFERENCIAINVENTARIODataGridView";
            this.tIPODIFERENCIAINVENTARIODataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tIPODIFERENCIAINVENTARIODataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tIPODIFERENCIAINVENTARIODataGridView.RowHeadersVisible = false;
            this.tIPODIFERENCIAINVENTARIODataGridView.Size = new System.Drawing.Size(426, 343);
            this.tIPODIFERENCIAINVENTARIODataGridView.TabIndex = 1;
            this.tIPODIFERENCIAINVENTARIODataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tIPODIFERENCIAINVENTARIODataGridView_CellDoubleClick);
            this.tIPODIFERENCIAINVENTARIODataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tIPODIFERENCIAINVENTARIODataGridView_KeyPress);
            this.tIPODIFERENCIAINVENTARIODataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tIPODIFERENCIAINVENTARIODataGridView_PreviewKeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ACTIVO";
            this.dataGridViewTextBoxColumn2.HeaderText = "ACTIVO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CREADO";
            this.dataGridViewTextBoxColumn3.HeaderText = "CREADO";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CREADOPOR_USERID";
            this.dataGridViewTextBoxColumn4.HeaderText = "CREADOPOR_USERID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MODIFICADO";
            this.dataGridViewTextBoxColumn5.HeaderText = "MODIFICADO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MODIFICADOPOR_USERID";
            this.dataGridViewTextBoxColumn6.HeaderText = "MODIFICADOPOR_USERID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn7.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn8.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DESCRIPCION";
            this.dataGridViewTextBoxColumn9.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 200;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "MEMO";
            this.dataGridViewTextBoxColumn10.HeaderText = "MEMO";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "GRUPODIFERENCIAINVENTARIOID";
            this.dataGridViewTextBoxColumn11.HeaderText = "GRUPODIFERENCIAINVENTARIOID";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // WFSelRazonDiferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 343);
            this.Controls.Add(this.tIPODIFERENCIAINVENTARIODataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFSelRazonDiferencia";
            this.Text = "Razón Diferencia";
            this.Load += new System.EventHandler(this.WFSelRazonDiferencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tIPODIFERENCIAINVENTARIOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tIPODIFERENCIAINVENTARIODataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private iPos.Importaciones.DSImportaciones dSImportaciones;
        private System.Windows.Forms.BindingSource tIPODIFERENCIAINVENTARIOBindingSource;
        private iPos.Importaciones.DSImportacionesTableAdapters.TIPODIFERENCIAINVENTARIOTableAdapter tIPODIFERENCIAINVENTARIOTableAdapter;
        private iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum tIPODIFERENCIAINVENTARIODataGridView;
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
    }
}