namespace iPos
{
    partial class WFMain2
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
            this.dSAccessControl = new iPos.Login_and_Maintenance.DSAccessControl();
            this.mENUITEMSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mENUITEMSTableAdapter = new iPos.Login_and_Maintenance.DSAccessControlTableAdapters.MENUITEMSTableAdapter();
            this.tableAdapterManager = new iPos.Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager();
            this.mENUITEMSDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dSAccessControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mENUITEMSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mENUITEMSDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dSAccessControl
            // 
            this.dSAccessControl.DataSetName = "DSAccessControl";
            this.dSAccessControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mENUITEMSBindingSource
            // 
            this.mENUITEMSBindingSource.DataMember = "MENUITEMS";
            this.mENUITEMSBindingSource.DataSource = this.dSAccessControl;
            // 
            // mENUITEMSTableAdapter
            // 
            this.mENUITEMSTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.DERECHOS_USUARIOSTableAdapter = null;
            this.tableAdapterManager.PERFILES_DERECHOSTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // mENUITEMSDataGridView
            // 
            this.mENUITEMSDataGridView.AutoGenerateColumns = false;
            this.mENUITEMSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mENUITEMSDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.mENUITEMSDataGridView.DataSource = this.mENUITEMSBindingSource;
            this.mENUITEMSDataGridView.Location = new System.Drawing.Point(106, 126);
            this.mENUITEMSDataGridView.Name = "mENUITEMSDataGridView";
            this.mENUITEMSDataGridView.Size = new System.Drawing.Size(300, 220);
            this.mENUITEMSDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MN_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "MN_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MN_IDPARENT";
            this.dataGridViewTextBoxColumn2.HeaderText = "MN_IDPARENT";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MN_ETIQUETA";
            this.dataGridViewTextBoxColumn3.HeaderText = "MN_ETIQUETA";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MN_DESC";
            this.dataGridViewTextBoxColumn4.HeaderText = "MN_DESC";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MN_DERECHO";
            this.dataGridViewTextBoxColumn5.HeaderText = "MN_DERECHO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MN_LEVEL";
            this.dataGridViewTextBoxColumn6.HeaderText = "MN_LEVEL";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MN_ORDEN";
            this.dataGridViewTextBoxColumn7.HeaderText = "MN_ORDEN";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // WFMain2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 366);
            this.Controls.Add(this.mENUITEMSDataGridView);
            this.Name = "WFMain2";
            this.Text = "WFMain2";
            this.Load += new System.EventHandler(this.WFMain2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSAccessControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mENUITEMSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mENUITEMSDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Login_and_Maintenance.DSAccessControl dSAccessControl;
        private System.Windows.Forms.BindingSource mENUITEMSBindingSource;
        private Login_and_Maintenance.DSAccessControlTableAdapters.MENUITEMSTableAdapter mENUITEMSTableAdapter;
        private Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView mENUITEMSDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}