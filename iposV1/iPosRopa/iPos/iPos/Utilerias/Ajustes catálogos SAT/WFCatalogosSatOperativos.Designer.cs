namespace iPos.Utilerias.Ajustes_catálogos_SAT
{
    partial class WFCatalogosSatOperativos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFCatalogosSatOperativos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.filtroTextBox = new System.Windows.Forms.TextBox();
            this.filtrarButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sAT_PRODUCTOSERVICIODataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGOPERATIVA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGHACAMBIADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sAT_PRODUCTOSERVICIOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCatalogosSat = new iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSat();
            this.sAT_PRODUCTOSERVICIOTableAdapter = new iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSatTableAdapters.SAT_PRODUCTOSERVICIOTableAdapter();
            this.tableAdapterManager = new iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSatTableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sAT_PRODUCTOSERVICIODataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAT_PRODUCTOSERVICIOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogosSat)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel1.Controls.Add(this.filtroTextBox);
            this.panel1.Controls.Add(this.filtrarButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.sAT_PRODUCTOSERVICIODataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 482);
            this.panel1.TabIndex = 0;
            // 
            // filtroTextBox
            // 
            this.filtroTextBox.Location = new System.Drawing.Point(146, 12);
            this.filtroTextBox.Name = "filtroTextBox";
            this.filtroTextBox.Size = new System.Drawing.Size(283, 20);
            this.filtroTextBox.TabIndex = 4;
            this.filtroTextBox.TextChanged += new System.EventHandler(this.filtroTextBox_TextChanged);
            // 
            // filtrarButton
            // 
            this.filtrarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.filtrarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.filtrarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.filtrarButton.ForeColor = System.Drawing.Color.White;
            this.filtrarButton.Location = new System.Drawing.Point(477, 8);
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
            // sAT_PRODUCTOSERVICIODataGridView
            // 
            this.sAT_PRODUCTOSERVICIODataGridView.AllowUserToAddRows = false;
            this.sAT_PRODUCTOSERVICIODataGridView.AllowUserToDeleteRows = false;
            this.sAT_PRODUCTOSERVICIODataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sAT_PRODUCTOSERVICIODataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sAT_PRODUCTOSERVICIODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sAT_PRODUCTOSERVICIODataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.DGOPERATIVA,
            this.DGHACAMBIADO});
            this.sAT_PRODUCTOSERVICIODataGridView.DataSource = this.sAT_PRODUCTOSERVICIOBindingSource;
            this.sAT_PRODUCTOSERVICIODataGridView.Location = new System.Drawing.Point(0, 49);
            this.sAT_PRODUCTOSERVICIODataGridView.Name = "sAT_PRODUCTOSERVICIODataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sAT_PRODUCTOSERVICIODataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.sAT_PRODUCTOSERVICIODataGridView.RowHeadersVisible = false;
            this.sAT_PRODUCTOSERVICIODataGridView.Size = new System.Drawing.Size(774, 381);
            this.sAT_PRODUCTOSERVICIODataGridView.TabIndex = 0;
            this.sAT_PRODUCTOSERVICIODataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.sAT_PRODUCTOSERVICIODataGridView_CellValidated);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SAT_CLAVEPRODSERV";
            this.dataGridViewTextBoxColumn2.HeaderText = "CLAVE ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
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
            // sAT_PRODUCTOSERVICIOBindingSource
            // 
            this.sAT_PRODUCTOSERVICIOBindingSource.DataMember = "SAT_PRODUCTOSERVICIO";
            this.sAT_PRODUCTOSERVICIOBindingSource.DataSource = this.dSCatalogosSat;
            // 
            // dSCatalogosSat
            // 
            this.dSCatalogosSat.DataSetName = "DSCatalogosSat";
            this.dSCatalogosSat.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sAT_PRODUCTOSERVICIOTableAdapter
            // 
            this.sAT_PRODUCTOSERVICIOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.SAT_PRODUCTOSERVICIO_LINEATableAdapter = null;
            this.tableAdapterManager.SAT_PRODUCTOSERVICIOTableAdapter = this.sAT_PRODUCTOSERVICIOTableAdapter;
            this.tableAdapterManager.UpdateOrder = iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSatTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "HACAMBIADO";
            this.dataGridViewTextBoxColumn4.HeaderText = "HACAMBIADO";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // WFCatalogosSatOperativos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(774, 482);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WFCatalogosSatOperativos";
            this.Text = "Catálogos de Productos Operativos";
            this.Load += new System.EventHandler(this.WFCatalogosSatOperativos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sAT_PRODUCTOSERVICIODataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAT_PRODUCTOSERVICIOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogosSat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSCatalogosSat dSCatalogosSat;
        private System.Windows.Forms.BindingSource sAT_PRODUCTOSERVICIOBindingSource;
        private DSCatalogosSatTableAdapters.SAT_PRODUCTOSERVICIOTableAdapter sAT_PRODUCTOSERVICIOTableAdapter;
        private DSCatalogosSatTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewSum sAT_PRODUCTOSERVICIODataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button filtrarButton;
        private System.Windows.Forms.TextBox filtroTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGOPERATIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGHACAMBIADO;
    }
}