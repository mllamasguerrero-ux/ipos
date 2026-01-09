namespace iPos.Utilerias.Ajustes_catálogos_SAT
{
    partial class WFCatalogosSatUsoCFDIOperativo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFCatalogosSatUsoCFDIOperativo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.filtroTextBox = new System.Windows.Forms.TextBox();
            this.filtrarButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dSCatalogosSat = new iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSat();
            this.sAT_USOCFDIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sAT_USOCFDITableAdapter = new iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSatTableAdapters.SAT_USOCFDITableAdapter();
            this.tableAdapterManager = new iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSatTableAdapters.TableAdapterManager();
            this.sAT_USOCFDIDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGOPERATIVA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGHACAMBIADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogosSat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAT_USOCFDIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAT_USOCFDIDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel1.Controls.Add(this.sAT_USOCFDIDataGridView);
            this.panel1.Controls.Add(this.filtroTextBox);
            this.panel1.Controls.Add(this.filtrarButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 492);
            this.panel1.TabIndex = 1;
            // 
            // filtroTextBox
            // 
            this.filtroTextBox.Location = new System.Drawing.Point(146, 15);
            this.filtroTextBox.Name = "filtroTextBox";
            this.filtroTextBox.Size = new System.Drawing.Size(283, 20);
            this.filtroTextBox.TabIndex = 4;
            // 
            // filtrarButton
            // 
            this.filtrarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.filtrarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.filtrarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.filtrarButton.ForeColor = System.Drawing.Color.White;
            this.filtrarButton.Location = new System.Drawing.Point(477, 11);
            this.filtrarButton.Name = "filtrarButton";
            this.filtrarButton.Size = new System.Drawing.Size(75, 25);
            this.filtrarButton.TabIndex = 2;
            this.filtrarButton.Text = "Buscar";
            this.filtrarButton.UseVisualStyleBackColor = false;
            this.filtrarButton.Click += new System.EventHandler(this.filtrarButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(354, 447);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dSCatalogosSat
            // 
            this.dSCatalogosSat.DataSetName = "DSCatalogosSat";
            this.dSCatalogosSat.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sAT_USOCFDIBindingSource
            // 
            this.sAT_USOCFDIBindingSource.DataMember = "SAT_USOCFDI";
            this.sAT_USOCFDIBindingSource.DataSource = this.dSCatalogosSat;
            // 
            // sAT_USOCFDITableAdapter
            // 
            this.sAT_USOCFDITableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.SAT_PRODUCTOSERVICIO_LINEATableAdapter = null;
            this.tableAdapterManager.SAT_PRODUCTOSERVICIOTableAdapter = null;
            this.tableAdapterManager.SAT_USOCFDITableAdapter = this.sAT_USOCFDITableAdapter;
            this.tableAdapterManager.UpdateOrder = iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSatTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // sAT_USOCFDIDataGridView
            // 
            this.sAT_USOCFDIDataGridView.AllowUserToAddRows = false;
            this.sAT_USOCFDIDataGridView.AutoGenerateColumns = false;
            this.sAT_USOCFDIDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sAT_USOCFDIDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.DGOPERATIVA,
            this.DGHACAMBIADO});
            this.sAT_USOCFDIDataGridView.DataSource = this.sAT_USOCFDIBindingSource;
            this.sAT_USOCFDIDataGridView.Location = new System.Drawing.Point(0, 55);
            this.sAT_USOCFDIDataGridView.Name = "sAT_USOCFDIDataGridView";
            this.sAT_USOCFDIDataGridView.RowHeadersVisible = false;
            this.sAT_USOCFDIDataGridView.Size = new System.Drawing.Size(774, 373);
            this.sAT_USOCFDIDataGridView.TabIndex = 4;
            this.sAT_USOCFDIDataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.sAT_USOCFDIDataGridView_CellValidated);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SAT_CLAVE";
            this.dataGridViewTextBoxColumn2.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SAT_DESCRIPCION";
            this.dataGridViewTextBoxColumn3.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // DGOPERATIVA
            // 
            this.DGOPERATIVA.DataPropertyName = "ESOPERATIVA";
            this.DGOPERATIVA.FalseValue = "N";
            this.DGOPERATIVA.HeaderText = "OPERATIVA";
            this.DGOPERATIVA.Name = "DGOPERATIVA";
            this.DGOPERATIVA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGOPERATIVA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGOPERATIVA.TrueValue = "S";
            // 
            // DGHACAMBIADO
            // 
            this.DGHACAMBIADO.DataPropertyName = "HACAMBIADO";
            this.DGHACAMBIADO.HeaderText = "HACAMBIADO";
            this.DGHACAMBIADO.Name = "DGHACAMBIADO";
            this.DGHACAMBIADO.Visible = false;
            // 
            // WFCatalogosSatUsoCFDIOperativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(774, 492);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFCatalogosSatUsoCFDIOperativo";
            this.Text = "Catalogo Sat Uso CFDI Operativo";
            this.Load += new System.EventHandler(this.WFCatalogosSatUsoCFDIOperativo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogosSat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAT_USOCFDIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAT_USOCFDIDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox filtroTextBox;
        private System.Windows.Forms.Button filtrarButton;
        private System.Windows.Forms.Button button1;
        private DSCatalogosSat dSCatalogosSat;
        private System.Windows.Forms.BindingSource sAT_USOCFDIBindingSource;
        private DSCatalogosSatTableAdapters.SAT_USOCFDITableAdapter sAT_USOCFDITableAdapter;
        private DSCatalogosSatTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum sAT_USOCFDIDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGOPERATIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGHACAMBIADO;
    }
}