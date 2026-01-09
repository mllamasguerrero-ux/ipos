namespace iPos.Cortes
{
    partial class WFVentasConErrorEmida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFVentasConErrorEmida));
            this.dSCortes2 = new iPos.Cortes.DSCortes2();
            this.vENTASCONERROREMIDABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vENTASCONERROREMIDATableAdapter = new iPos.Cortes.DSCortes2TableAdapters.VENTASCONERROREMIDATableAdapter();
            this.tableAdapterManager = new iPos.Cortes.DSCortes2TableAdapters.TableAdapterManager();
            this.vENTASCONERROREMIDADataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTerminar = new System.Windows.Forms.Button();
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
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPagar = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dSCortes2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vENTASCONERROREMIDABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vENTASCONERROREMIDADataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dSCortes2
            // 
            this.dSCortes2.DataSetName = "DSCortes2";
            this.dSCortes2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vENTASCONERROREMIDABindingSource
            // 
            this.vENTASCONERROREMIDABindingSource.DataMember = "VENTASCONERROREMIDA";
            this.vENTASCONERROREMIDABindingSource.DataSource = this.dSCortes2;
            // 
            // vENTASCONERROREMIDATableAdapter
            // 
            this.vENTASCONERROREMIDATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Cortes.DSCortes2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // vENTASCONERROREMIDADataGridView
            // 
            this.vENTASCONERROREMIDADataGridView.AllowUserToAddRows = false;
            this.vENTASCONERROREMIDADataGridView.AllowUserToDeleteRows = false;
            this.vENTASCONERROREMIDADataGridView.AutoGenerateColumns = false;
            this.vENTASCONERROREMIDADataGridView.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.vENTASCONERROREMIDADataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.vENTASCONERROREMIDADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vENTASCONERROREMIDADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.DGID,
            this.DGPagar});
            this.vENTASCONERROREMIDADataGridView.DataSource = this.vENTASCONERROREMIDABindingSource;
            this.vENTASCONERROREMIDADataGridView.Location = new System.Drawing.Point(0, 57);
            this.vENTASCONERROREMIDADataGridView.Name = "vENTASCONERROREMIDADataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.vENTASCONERROREMIDADataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.vENTASCONERROREMIDADataGridView.RowHeadersVisible = false;
            this.vENTASCONERROREMIDADataGridView.Size = new System.Drawing.Size(844, 264);
            this.vENTASCONERROREMIDADataGridView.TabIndex = 2;
            this.vENTASCONERROREMIDADataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vENTASCONERROREMIDADataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // btnTerminar
            // 
            this.btnTerminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnTerminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnTerminar.ForeColor = System.Drawing.Color.White;
            this.btnTerminar.Location = new System.Drawing.Point(383, 344);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(78, 26);
            this.btnTerminar.TabIndex = 3;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FOLIO";
            this.dataGridViewTextBoxColumn2.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SERIE";
            this.dataGridViewTextBoxColumn3.HeaderText = "SERIE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FOLIOSAT";
            this.dataGridViewTextBoxColumn4.HeaderText = "FOLIOSAT";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SERIESAT";
            this.dataGridViewTextBoxColumn5.HeaderText = "SERIESAT";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TOTAL";
            this.dataGridViewTextBoxColumn6.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "NOMBRECLIENTE";
            this.dataGridViewTextBoxColumn7.HeaderText = "CLIENTE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NOMBREVENDEDOR";
            this.dataGridViewTextBoxColumn8.HeaderText = "VENDEDOR";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "USERNAME";
            this.dataGridViewTextBoxColumn9.HeaderText = "USERNAME";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "PROCESOSURTIDO";
            this.dataGridViewTextBoxColumn10.HeaderText = "PROCESOSURTIDO";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "OBSERVACIONFACTURACION";
            this.dataGridViewTextBoxColumn11.HeaderText = "OBSERVACIONFACTURACION";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn12.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "ALMACENID";
            this.dataGridViewTextBoxColumn13.HeaderText = "ALMACENID";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "NOTASURTIDO";
            this.dataGridViewTextBoxColumn14.HeaderText = "NOTASURTIDO";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // DGPagar
            // 
            this.DGPagar.HeaderText = "PAGAR";
            this.DGPagar.Image = global::iPos.Properties.Resources.cash_J;
            this.DGPagar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.DGPagar.Name = "DGPagar";
            // 
            // WFVentasConErrorEmida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(843, 382);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.vENTASCONERROREMIDADataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFVentasConErrorEmida";
            this.Text = "Ventas Con Error Emida";
            this.Load += new System.EventHandler(this.WFVentasConErrorEmida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSCortes2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vENTASCONERROREMIDABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vENTASCONERROREMIDADataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSCortes2 dSCortes2;
        private System.Windows.Forms.BindingSource vENTASCONERROREMIDABindingSource;
        private DSCortes2TableAdapters.VENTASCONERROREMIDATableAdapter vENTASCONERROREMIDATableAdapter;
        private DSCortes2TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum vENTASCONERROREMIDADataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnTerminar;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewImageColumn DGPagar;
    }
}