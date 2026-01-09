namespace iPos
{
    partial class LookUpSucursales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LookUpSucursales));
            this.sUCURSALTRASLADOSDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSPuntoDeVentaAux2 = new iPos.PuntoDeVenta.DSPuntoDeVentaAux2();
            this.sUCURSALTRASLADOSBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sUCURSALTRASLADOSTableAdapter1 = new iPos.PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.SUCURSALTRASLADOSTableAdapter();
            this.tableAdapterManager1 = new iPos.PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALTRASLADOSDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALTRASLADOSBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // sUCURSALTRASLADOSDataGridView
            // 
            this.sUCURSALTRASLADOSDataGridView.AllowUserToAddRows = false;
            this.sUCURSALTRASLADOSDataGridView.AutoGenerateColumns = false;
            this.sUCURSALTRASLADOSDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sUCURSALTRASLADOSDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.sUCURSALTRASLADOSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sUCURSALTRASLADOSDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.sUCURSALTRASLADOSDataGridView.DataSource = this.sUCURSALTRASLADOSBindingSource1;
            this.sUCURSALTRASLADOSDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sUCURSALTRASLADOSDataGridView.EnableHeadersVisualStyles = false;
            this.sUCURSALTRASLADOSDataGridView.Location = new System.Drawing.Point(0, 0);
            this.sUCURSALTRASLADOSDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.sUCURSALTRASLADOSDataGridView.Name = "sUCURSALTRASLADOSDataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sUCURSALTRASLADOSDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.sUCURSALTRASLADOSDataGridView.RowHeadersVisible = false;
            this.sUCURSALTRASLADOSDataGridView.Size = new System.Drawing.Size(784, 456);
            this.sUCURSALTRASLADOSDataGridView.TabIndex = 2;
            this.sUCURSALTRASLADOSDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sUCURSALTRASLADOSDataGridView_CellContentClick);
            this.sUCURSALTRASLADOSDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sUCURSALTRASLADOSDataGridView_KeyPress);
            this.sUCURSALTRASLADOSDataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.sUCURSALTRASLADOSDataGridView_PreviewKeyDown);
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "GRUPOSUCURSALID";
            this.dataGridViewTextBoxColumn11.HeaderText = "GPO. SUC.";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "MEMO";
            this.dataGridViewTextBoxColumn10.HeaderText = "MEMO";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DESCRIPCION";
            this.dataGridViewTextBoxColumn9.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn8.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn7.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MODIFICADOPOR_USERID";
            this.dataGridViewTextBoxColumn6.HeaderText = "MODIFICADOPOR_USERID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MODIFICADO";
            this.dataGridViewTextBoxColumn5.HeaderText = "MODIFICADO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CREADOPOR_USERID";
            this.dataGridViewTextBoxColumn4.HeaderText = "CREADOPOR_USERID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CREADO";
            this.dataGridViewTextBoxColumn3.HeaderText = "CREADO";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ACTIVO";
            this.dataGridViewTextBoxColumn2.HeaderText = "ACTIVO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dSPuntoDeVentaAux2
            // 
            this.dSPuntoDeVentaAux2.DataSetName = "DSPuntoDeVentaAux2";
            this.dSPuntoDeVentaAux2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sUCURSALTRASLADOSBindingSource1
            // 
            this.sUCURSALTRASLADOSBindingSource1.DataMember = "SUCURSALTRASLADOS";
            this.sUCURSALTRASLADOSBindingSource1.DataSource = this.dSPuntoDeVentaAux2;
            // 
            // sUCURSALTRASLADOSTableAdapter1
            // 
            this.sUCURSALTRASLADOSTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.EMIDAPRODUCTTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = iPos.PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // LookUpSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 456);
            this.Controls.Add(this.sUCURSALTRASLADOSDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LookUpSucursales";
            this.Text = "Sucursales de traslado";
            this.Load += new System.EventHandler(this.LookUpSucursales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALTRASLADOSDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALTRASLADOSBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewSum sUCURSALTRASLADOSDataGridView;
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
        private PuntoDeVenta.DSPuntoDeVentaAux2 dSPuntoDeVentaAux2;
        private System.Windows.Forms.BindingSource sUCURSALTRASLADOSBindingSource1;
        private PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.SUCURSALTRASLADOSTableAdapter sUCURSALTRASLADOSTableAdapter1;
        private PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.TableAdapterManager tableAdapterManager1;
    }
}