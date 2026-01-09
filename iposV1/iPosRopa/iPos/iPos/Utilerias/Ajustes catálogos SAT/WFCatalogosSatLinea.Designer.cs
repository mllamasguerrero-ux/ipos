namespace iPos.Utilerias.Ajustes_catálogos_SAT
{
    partial class WFCatalogosSatLinea
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
            System.Windows.Forms.Label lINEAIDLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFCatalogosSatLinea));
            this.panel1 = new System.Windows.Forms.Panel();
            this.filtroTextBox = new System.Windows.Forms.TextBox();
            this.filtrarButton = new System.Windows.Forms.Button();
            this.LINEAButton = new System.Windows.Forms.Button();
            this.LINEALabel = new System.Windows.Forms.Label();
            this.LINEAIDTextBox = new iPos.Tools.TextBoxFB();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView = new System.Windows.Forms.DataGridViewSum();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sATCLAVEPRODSERVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sATDESCRIPCIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESOPERATIVA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HACAMBIADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sAT_PRODUCTOSERVICIO_LINEABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCatalogosSat = new iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSat();
            this.sAT_PRODUCTOSERVICIO_LINEATableAdapter = new iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSatTableAdapters.SAT_PRODUCTOSERVICIO_LINEATableAdapter();
            this.tableAdapterManager = new iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSatTableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lINEAIDLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sAT_PRODUCTOSERVICIO_LINEADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAT_PRODUCTOSERVICIO_LINEABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogosSat)).BeginInit();
            this.SuspendLayout();
            // 
            // lINEAIDLabel
            // 
            lINEAIDLabel.AutoSize = true;
            lINEAIDLabel.ForeColor = System.Drawing.Color.White;
            lINEAIDLabel.Location = new System.Drawing.Point(12, 26);
            lINEAIDLabel.Name = "lINEAIDLabel";
            lINEAIDLabel.Size = new System.Drawing.Size(36, 13);
            lINEAIDLabel.TabIndex = 155;
            lINEAIDLabel.Text = "Linea:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.filtroTextBox);
            this.panel1.Controls.Add(this.filtrarButton);
            this.panel1.Controls.Add(this.LINEAButton);
            this.panel1.Controls.Add(this.LINEALabel);
            this.panel1.Controls.Add(this.LINEAIDTextBox);
            this.panel1.Controls.Add(lINEAIDLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 71);
            this.panel1.TabIndex = 0;
            // 
            // filtroTextBox
            // 
            this.filtroTextBox.Location = new System.Drawing.Point(379, 23);
            this.filtroTextBox.Name = "filtroTextBox";
            this.filtroTextBox.Size = new System.Drawing.Size(283, 20);
            this.filtroTextBox.TabIndex = 158;
            this.filtroTextBox.TextChanged += new System.EventHandler(this.filtroTextBox_TextChanged);
            // 
            // filtrarButton
            // 
            this.filtrarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.filtrarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.filtrarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrarButton.ForeColor = System.Drawing.Color.White;
            this.filtrarButton.Location = new System.Drawing.Point(668, 21);
            this.filtrarButton.Name = "filtrarButton";
            this.filtrarButton.Size = new System.Drawing.Size(75, 23);
            this.filtrarButton.TabIndex = 157;
            this.filtrarButton.Text = "Buscar";
            this.filtrarButton.UseVisualStyleBackColor = false;
            this.filtrarButton.Click += new System.EventHandler(this.filtrarButton_Click);
            // 
            // LINEAButton
            // 
            this.LINEAButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.LINEAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LINEAButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LINEAButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.LINEAButton.Location = new System.Drawing.Point(142, 21);
            this.LINEAButton.Name = "LINEAButton";
            this.LINEAButton.Size = new System.Drawing.Size(23, 23);
            this.LINEAButton.TabIndex = 154;
            this.LINEAButton.UseVisualStyleBackColor = true;
            // 
            // LINEALabel
            // 
            this.LINEALabel.AutoSize = true;
            this.LINEALabel.ForeColor = System.Drawing.Color.White;
            this.LINEALabel.Location = new System.Drawing.Point(169, 26);
            this.LINEALabel.Name = "LINEALabel";
            this.LINEALabel.Size = new System.Drawing.Size(16, 13);
            this.LINEALabel.TabIndex = 156;
            this.LINEALabel.Text = "...";
            // 
            // LINEAIDTextBox
            // 
            this.LINEAIDTextBox.BotonLookUp = this.LINEAButton;
            this.LINEAIDTextBox.Condicion = null;
            this.LINEAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.LINEAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.LINEAIDTextBox.DbValue = null;
            this.LINEAIDTextBox.Format_Expression = null;
            this.LINEAIDTextBox.IndiceCampoDescripcion = 2;
            this.LINEAIDTextBox.IndiceCampoSelector = 1;
            this.LINEAIDTextBox.IndiceCampoValue = 0;
            this.LINEAIDTextBox.LabelDescription = this.LINEALabel;
            this.LINEAIDTextBox.Location = new System.Drawing.Point(54, 23);
            this.LINEAIDTextBox.MostrarErrores = true;
            this.LINEAIDTextBox.Name = "LINEAIDTextBox";
            this.LINEAIDTextBox.NombreCampoSelector = "clave";
            this.LINEAIDTextBox.NombreCampoValue = "id";
            this.LINEAIDTextBox.Query = "select id,clave,nombre from linea";
            this.LINEAIDTextBox.QueryDeSeleccion = "select id,clave,nombre from linea where clave = @clave";
            this.LINEAIDTextBox.QueryPorDBValue = "select id,clave,nombre from linea where id = @id";
            this.LINEAIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.LINEAIDTextBox.TabIndex = 153;
            this.LINEAIDTextBox.Tag = 34;
            this.LINEAIDTextBox.TextDescription = null;
            this.LINEAIDTextBox.Titulo = "Lineas";
            this.LINEAIDTextBox.ValidarEntrada = true;
            this.LINEAIDTextBox.ValidationExpression = null;
            this.LINEAIDTextBox.Validated += new System.EventHandler(this.LINEAIDTextBox_Validated);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 424);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(774, 100);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(348, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.sAT_PRODUCTOSERVICIO_LINEADataGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(774, 353);
            this.panel3.TabIndex = 2;
            // 
            // sAT_PRODUCTOSERVICIO_LINEADataGridView
            // 
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.AllowUserToAddRows = false;
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.AllowUserToDeleteRows = false;
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.sATCLAVEPRODSERVDataGridViewTextBoxColumn,
            this.sATDESCRIPCIONDataGridViewTextBoxColumn,
            this.ESOPERATIVA,
            this.HACAMBIADO});
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.DataSource = this.sAT_PRODUCTOSERVICIO_LINEABindingSource;
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.Location = new System.Drawing.Point(0, 0);
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.Name = "sAT_PRODUCTOSERVICIO_LINEADataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.RowHeadersVisible = false;
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.Size = new System.Drawing.Size(774, 381);
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.TabIndex = 1;
            this.sAT_PRODUCTOSERVICIO_LINEADataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.sAT_PRODUCTOSERVICIO_LINEADataGridView_CellValidated);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // sATCLAVEPRODSERVDataGridViewTextBoxColumn
            // 
            this.sATCLAVEPRODSERVDataGridViewTextBoxColumn.DataPropertyName = "SAT_CLAVEPRODSERV";
            this.sATCLAVEPRODSERVDataGridViewTextBoxColumn.HeaderText = "CLAVE";
            this.sATCLAVEPRODSERVDataGridViewTextBoxColumn.Name = "sATCLAVEPRODSERVDataGridViewTextBoxColumn";
            // 
            // sATDESCRIPCIONDataGridViewTextBoxColumn
            // 
            this.sATDESCRIPCIONDataGridViewTextBoxColumn.DataPropertyName = "SAT_DESCRIPCION";
            this.sATDESCRIPCIONDataGridViewTextBoxColumn.HeaderText = "DESCRIPCION";
            this.sATDESCRIPCIONDataGridViewTextBoxColumn.Name = "sATDESCRIPCIONDataGridViewTextBoxColumn";
            // 
            // ESOPERATIVA
            // 
            this.ESOPERATIVA.DataPropertyName = "ESOPERATIVA";
            this.ESOPERATIVA.FalseValue = "N";
            this.ESOPERATIVA.HeaderText = "ESOPERATIVA";
            this.ESOPERATIVA.Name = "ESOPERATIVA";
            this.ESOPERATIVA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ESOPERATIVA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ESOPERATIVA.TrueValue = "S";
            // 
            // HACAMBIADO
            // 
            this.HACAMBIADO.DataPropertyName = "HACAMBIADO";
            this.HACAMBIADO.HeaderText = "HACAMBIADO";
            this.HACAMBIADO.Name = "HACAMBIADO";
            // 
            // sAT_PRODUCTOSERVICIO_LINEABindingSource
            // 
            this.sAT_PRODUCTOSERVICIO_LINEABindingSource.DataMember = "SAT_PRODUCTOSERVICIO_LINEA";
            this.sAT_PRODUCTOSERVICIO_LINEABindingSource.DataSource = this.dSCatalogosSat;
            // 
            // dSCatalogosSat
            // 
            this.dSCatalogosSat.DataSetName = "DSCatalogosSat";
            this.dSCatalogosSat.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sAT_PRODUCTOSERVICIO_LINEATableAdapter
            // 
            this.sAT_PRODUCTOSERVICIO_LINEATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.SAT_PRODUCTOSERVICIO_LINEATableAdapter = this.sAT_PRODUCTOSERVICIO_LINEATableAdapter;
            this.tableAdapterManager.SAT_PRODUCTOSERVICIOTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSatTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn5.HeaderText = "ID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "SAT_CLAVEPRODSERV";
            this.dataGridViewTextBoxColumn6.HeaderText = "SAT_CLAVEPRODSERV";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SAT_DESCRIPCION";
            this.dataGridViewTextBoxColumn7.HeaderText = "SAT_DESCRIPCION";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 250;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ESOPERATIVA";
            this.dataGridViewTextBoxColumn8.HeaderText = "ESOPERATIVA";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn9.HeaderText = "ID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "SAT_CLAVEPRODSERV";
            this.dataGridViewTextBoxColumn10.HeaderText = "SAT_CLAVEPRODSERV";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "SAT_DESCRIPCION";
            this.dataGridViewTextBoxColumn11.HeaderText = "SAT_DESCRIPCION";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ESOPERATIVA";
            this.dataGridViewTextBoxColumn12.HeaderText = "ESOPERATIVA";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // WFCatalogosSatLinea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(774, 524);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFCatalogosSatLinea";
            this.Text = "Catalogos de Productos por Linea";
            this.Load += new System.EventHandler(this.WFCatalogosSatLinea_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sAT_PRODUCTOSERVICIO_LINEADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sAT_PRODUCTOSERVICIO_LINEABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogosSat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button LINEAButton;
        private System.Windows.Forms.Label LINEALabel;
        private Tools.TextBoxFB LINEAIDTextBox;
        private DSCatalogosSat dSCatalogosSat;
        private System.Windows.Forms.BindingSource sAT_PRODUCTOSERVICIO_LINEABindingSource;
        private DSCatalogosSatTableAdapters.SAT_PRODUCTOSERVICIO_LINEATableAdapter sAT_PRODUCTOSERVICIO_LINEATableAdapter;
        private DSCatalogosSatTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.TextBox filtroTextBox;
        private System.Windows.Forms.Button filtrarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewSum sAT_PRODUCTOSERVICIO_LINEADataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sATCLAVEPRODSERVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sATDESCRIPCIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ESOPERATIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn HACAMBIADO;
    }
}