namespace iPos
{
    partial class WFListaEnsamblados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFListaEnsamblados));
            this.DTPFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.DTPFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dSKits = new iPos.Kits.DSKits();
            this.eNSAMBLESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eNSAMBLESTableAdapter = new iPos.Kits.DSKitsTableAdapters.ENSAMBLESTableAdapter();
            this.tableAdapterManager = new iPos.Kits.DSKitsTableAdapters.TableAdapterManager();
            this.eNSAMBLESDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBEstatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTNBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dSKits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNSAMBLESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNSAMBLESDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DTPFechaInicio
            // 
            this.DTPFechaInicio.Location = new System.Drawing.Point(51, 32);
            this.DTPFechaInicio.Name = "DTPFechaInicio";
            this.DTPFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.DTPFechaInicio.TabIndex = 0;
            // 
            // DTPFechaFin
            // 
            this.DTPFechaFin.Location = new System.Drawing.Point(290, 32);
            this.DTPFechaFin.Name = "DTPFechaFin";
            this.DTPFechaFin.Size = new System.Drawing.Size(200, 20);
            this.DTPFechaFin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "De la fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(287, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "A la fecha";
            // 
            // dSKits
            // 
            this.dSKits.DataSetName = "DSKits";
            this.dSKits.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eNSAMBLESBindingSource
            // 
            this.eNSAMBLESBindingSource.DataMember = "ENSAMBLES";
            this.eNSAMBLESBindingSource.DataSource = this.dSKits;
            // 
            // eNSAMBLESTableAdapter
            // 
            this.eNSAMBLESTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Kits.DSKitsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // eNSAMBLESDataGridView
            // 
            this.eNSAMBLESDataGridView.AllowUserToAddRows = false;
            this.eNSAMBLESDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.eNSAMBLESDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.eNSAMBLESDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eNSAMBLESDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.eNSAMBLESDataGridView.DataSource = this.eNSAMBLESBindingSource;
            this.eNSAMBLESDataGridView.Location = new System.Drawing.Point(51, 137);
            this.eNSAMBLESDataGridView.Name = "eNSAMBLESDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.eNSAMBLESDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.eNSAMBLESDataGridView.RowHeadersVisible = false;
            this.eNSAMBLESDataGridView.Size = new System.Drawing.Size(439, 272);
            this.eNSAMBLESDataGridView.TabIndex = 7;
            this.eNSAMBLESDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eNSAMBLESDataGridView_CellDoubleClick);
            this.eNSAMBLESDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.eNSAMBLESDataGridView_KeyDown);
            this.eNSAMBLESDataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.eNSAMBLESDataGridView_PreviewKeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "CONSECUTIVO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FOLIO";
            this.dataGridViewTextBoxColumn2.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn3.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ESTATUSDOCTOID";
            this.dataGridViewTextBoxColumn4.HeaderText = "ESTATUSDOCTOID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // CBEstatus
            // 
            this.CBEstatus.FormattingEnabled = true;
            this.CBEstatus.Items.AddRange(new object[] {
            "Pendientes",
            "Completados"});
            this.CBEstatus.Location = new System.Drawing.Point(51, 91);
            this.CBEstatus.Name = "CBEstatus";
            this.CBEstatus.Size = new System.Drawing.Size(200, 21);
            this.CBEstatus.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(48, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Estatus";
            // 
            // BTNBuscar
            // 
            this.BTNBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTNBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTNBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.BTNBuscar.ForeColor = System.Drawing.Color.White;
            this.BTNBuscar.Location = new System.Drawing.Point(290, 89);
            this.BTNBuscar.Name = "BTNBuscar";
            this.BTNBuscar.Size = new System.Drawing.Size(200, 25);
            this.BTNBuscar.TabIndex = 10;
            this.BTNBuscar.Text = "Buscar";
            this.BTNBuscar.UseVisualStyleBackColor = false;
            this.BTNBuscar.Click += new System.EventHandler(this.BTNBuscar_Click);
            // 
            // WFListaEnsamblados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(535, 440);
            this.Controls.Add(this.BTNBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CBEstatus);
            this.Controls.Add(this.eNSAMBLESDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTPFechaFin);
            this.Controls.Add(this.DTPFechaInicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFListaEnsamblados";
            this.Text = "WFListaEnsamblados";
            this.Load += new System.EventHandler(this.WFListaEnsamblados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSKits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNSAMBLESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNSAMBLESDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPFechaInicio;
        private System.Windows.Forms.DateTimePicker DTPFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Kits.DSKits dSKits;
        private System.Windows.Forms.BindingSource eNSAMBLESBindingSource;
        private Kits.DSKitsTableAdapters.ENSAMBLESTableAdapter eNSAMBLESTableAdapter;
        private Kits.DSKitsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum eNSAMBLESDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ComboBox CBEstatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTNBuscar;
    }
}