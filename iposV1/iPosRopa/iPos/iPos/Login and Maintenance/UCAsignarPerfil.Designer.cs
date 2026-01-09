namespace iPos
{
    partial class UCAsignarPerfil
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
        #region Código generado por el Diseñador de componentes
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pERFILES_ASIGNADOSDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dgPermitido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pERFILES_ASIGNADOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSAccessControl = new iPos.Login_and_Maintenance.DSAccessControl();
            this.tableAdapterManager = new iPos.Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager();
            this.pERFILES_ASIGNADOSTableAdapter = new iPos.Login_and_Maintenance.DSAccessControlTableAdapters.PERFILES_ASIGNADOSTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pERFILES_ASIGNADOSDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pERFILES_ASIGNADOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSAccessControl)).BeginInit();
            this.SuspendLayout();
            // 
            // pERFILES_ASIGNADOSDataGridView
            // 
            this.pERFILES_ASIGNADOSDataGridView.AllowUserToAddRows = false;
            this.pERFILES_ASIGNADOSDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pERFILES_ASIGNADOSDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pERFILES_ASIGNADOSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pERFILES_ASIGNADOSDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgPermitido,
            this.dgDescripcion,
            this.dgPerfil});
            this.pERFILES_ASIGNADOSDataGridView.DataSource = this.pERFILES_ASIGNADOSBindingSource;
            this.pERFILES_ASIGNADOSDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pERFILES_ASIGNADOSDataGridView.EnableHeadersVisualStyles = false;
            this.pERFILES_ASIGNADOSDataGridView.Location = new System.Drawing.Point(0, 0);
            this.pERFILES_ASIGNADOSDataGridView.Name = "pERFILES_ASIGNADOSDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pERFILES_ASIGNADOSDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.pERFILES_ASIGNADOSDataGridView.RowHeadersVisible = false;
            this.pERFILES_ASIGNADOSDataGridView.Size = new System.Drawing.Size(228, 234);
            this.pERFILES_ASIGNADOSDataGridView.TabIndex = 4;
            this.pERFILES_ASIGNADOSDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.pERFILES_ASIGNADOSDataGridView_CellValueChanged);
            this.pERFILES_ASIGNADOSDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.pERFILES_ASIGNADOSDataGridView_CurrentCellDirtyStateChanged);
            // 
            // dgPermitido
            // 
            this.dgPermitido.DataPropertyName = "PERMITIDO";
            this.dgPermitido.FalseValue = "0";
            this.dgPermitido.HeaderText = "";
            this.dgPermitido.Name = "dgPermitido";
            this.dgPermitido.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPermitido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgPermitido.TrueValue = "1";
            this.dgPermitido.Width = 20;
            // 
            // dgDescripcion
            // 
            this.dgDescripcion.DataPropertyName = "PF_DESCRIPCION";
            this.dgDescripcion.HeaderText = "PF_DESCRIPCION";
            this.dgDescripcion.Name = "dgDescripcion";
            this.dgDescripcion.Width = 200;
            // 
            // dgPerfil
            // 
            this.dgPerfil.DataPropertyName = "PF_PERFIL";
            this.dgPerfil.HeaderText = "PF_PERFIL";
            this.dgPerfil.Name = "dgPerfil";
            this.dgPerfil.Visible = false;
            // 
            // pERFILES_ASIGNADOSBindingSource
            // 
            this.pERFILES_ASIGNADOSBindingSource.DataMember = "PERFILES_ASIGNADOS";
            this.pERFILES_ASIGNADOSBindingSource.DataSource = this.dSAccessControl;
            // 
            // dSAccessControl
            // 
            this.dSAccessControl.DataSetName = "DSAccessControl";
            this.dSAccessControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.DERECHOS_USUARIOSTableAdapter = null;
            this.tableAdapterManager.PERFILES_DERECHOSTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // pERFILES_ASIGNADOSTableAdapter
            // 
            this.pERFILES_ASIGNADOSTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(153, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PF_DESCRIPCION";
            this.dataGridViewTextBoxColumn1.HeaderText = "PF_DESCRIPCION";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PF_PERFIL";
            this.dataGridViewTextBoxColumn2.HeaderText = "PF_PERFIL";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // UCAsignarPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pERFILES_ASIGNADOSDataGridView);
            this.Name = "UCAsignarPerfil";
            this.Size = new System.Drawing.Size(228, 234);
            this.Load += new System.EventHandler(this.UCAsignarPerfil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pERFILES_ASIGNADOSDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pERFILES_ASIGNADOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSAccessControl)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private iPos.Login_and_Maintenance.DSAccessControl dSAccessControl;
        private iPos.Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager tableAdapterManager;
        private iPos.Login_and_Maintenance.DSAccessControlTableAdapters.PERFILES_ASIGNADOSTableAdapter pERFILES_ASIGNADOSTableAdapter;
        private System.Windows.Forms.BindingSource pERFILES_ASIGNADOSBindingSource;
        private System.Windows.Forms.DataGridViewSum pERFILES_ASIGNADOSDataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgPermitido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPerfil;
    }
}
