namespace iPos.Utilerias.Ajustes_catálogos_SAT
{
    partial class WFAduanasSat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFAduanasSat));
            this.panel1 = new System.Windows.Forms.Panel();
            this.aduanaLabel = new System.Windows.Forms.Label();
            this.aduanaButton = new System.Windows.Forms.Button();
            this.aduanaTextBoxFb = new iPos.Tools.TextBoxFB();
            this.label3 = new System.Windows.Forms.Label();
            this.guardarButton = new System.Windows.Forms.Button();
            this.descripcionContentLabel = new System.Windows.Forms.Label();
            this.descripcionLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.aplicarCambiosButton = new System.Windows.Forms.Button();
            this.lOTESIMPORTADOSDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADUANAASIGNADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASIGNARADUANA = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lOTESIMPORTADOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCatalogosSat3 = new iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSat3();
            this.lOTESIMPORTADOSTableAdapter = new iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSat3TableAdapters.LOTESIMPORTADOSTableAdapter();
            this.tableAdapterManager = new iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSat3TableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lOTESIMPORTADOSDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOTESIMPORTADOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogosSat3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.aduanaLabel);
            this.panel1.Controls.Add(this.aduanaButton);
            this.panel1.Controls.Add(this.aduanaTextBoxFb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.guardarButton);
            this.panel1.Controls.Add(this.descripcionContentLabel);
            this.panel1.Controls.Add(this.descripcionLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 100);
            this.panel1.TabIndex = 0;
            // 
            // aduanaLabel
            // 
            this.aduanaLabel.AutoSize = true;
            this.aduanaLabel.BackColor = System.Drawing.Color.Transparent;
            this.aduanaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aduanaLabel.ForeColor = System.Drawing.Color.White;
            this.aduanaLabel.Location = new System.Drawing.Point(249, 64);
            this.aduanaLabel.Name = "aduanaLabel";
            this.aduanaLabel.Size = new System.Drawing.Size(19, 13);
            this.aduanaLabel.TabIndex = 190;
            this.aduanaLabel.Text = "...";
            // 
            // aduanaButton
            // 
            this.aduanaButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.aduanaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aduanaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aduanaButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.aduanaButton.Location = new System.Drawing.Point(219, 58);
            this.aduanaButton.Name = "aduanaButton";
            this.aduanaButton.Size = new System.Drawing.Size(24, 24);
            this.aduanaButton.TabIndex = 189;
            this.aduanaButton.UseVisualStyleBackColor = true;
            // 
            // aduanaTextBoxFb
            // 
            this.aduanaTextBoxFb.BotonLookUp = this.aduanaButton;
            this.aduanaTextBoxFb.Condicion = null;
            this.aduanaTextBoxFb.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.aduanaTextBoxFb.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.aduanaTextBoxFb.DbValue = null;
            this.aduanaTextBoxFb.Format_Expression = null;
            this.aduanaTextBoxFb.IndiceCampoDescripcion = 2;
            this.aduanaTextBoxFb.IndiceCampoSelector = 1;
            this.aduanaTextBoxFb.IndiceCampoValue = 0;
            this.aduanaTextBoxFb.LabelDescription = this.aduanaLabel;
            this.aduanaTextBoxFb.Location = new System.Drawing.Point(113, 61);
            this.aduanaTextBoxFb.Name = "aduanaTextBoxFb";
            this.aduanaTextBoxFb.NombreCampoSelector = "SAT_CLAVEADUANA";
            this.aduanaTextBoxFb.NombreCampoValue = "ID";
            this.aduanaTextBoxFb.Query = "SELECT ID, SAT_CLAVEADUANA, SAT_DESCRIPCION FROM SAT_ADUANA";
            this.aduanaTextBoxFb.QueryDeSeleccion = "SELECT ID, SAT_CLAVEADUANA, SAT_DESCRIPCION FROM SAT_ADUANA WHERE SAT_CLAVEADUANA" +
    " = @SAT_CLAVEADUANA";
            this.aduanaTextBoxFb.QueryPorDBValue = "SELECT ID, SAT_CLAVEADUANA, SAT_DESCRIPCION FROM SAT_ADUANA WHERE ID = @ID";
            this.aduanaTextBoxFb.Size = new System.Drawing.Size(100, 20);
            this.aduanaTextBoxFb.TabIndex = 188;
            this.aduanaTextBoxFb.Tag = 34;
            this.aduanaTextBoxFb.TextDescription = null;
            this.aduanaTextBoxFb.Titulo = null;
            this.aduanaTextBoxFb.ValidarEntrada = true;
            this.aduanaTextBoxFb.ValidationExpression = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(53, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 187;
            this.label3.Text = "Aduana:";
            // 
            // guardarButton
            // 
            this.guardarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.guardarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.guardarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guardarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.guardarButton.ForeColor = System.Drawing.Color.White;
            this.guardarButton.Location = new System.Drawing.Point(696, 51);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(75, 26);
            this.guardarButton.TabIndex = 186;
            this.guardarButton.Text = "Fijar Aduana";
            this.guardarButton.UseVisualStyleBackColor = false;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // descripcionContentLabel
            // 
            this.descripcionContentLabel.AutoSize = true;
            this.descripcionContentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descripcionContentLabel.ForeColor = System.Drawing.Color.White;
            this.descripcionContentLabel.Location = new System.Drawing.Point(122, 19);
            this.descripcionContentLabel.Name = "descripcionContentLabel";
            this.descripcionContentLabel.Size = new System.Drawing.Size(0, 13);
            this.descripcionContentLabel.TabIndex = 185;
            // 
            // descripcionLabel
            // 
            this.descripcionLabel.AutoSize = true;
            this.descripcionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descripcionLabel.ForeColor = System.Drawing.Color.White;
            this.descripcionLabel.Location = new System.Drawing.Point(21, 19);
            this.descripcionLabel.Name = "descripcionLabel";
            this.descripcionLabel.Size = new System.Drawing.Size(95, 13);
            this.descripcionLabel.TabIndex = 0;
            this.descripcionLabel.Text = "DESCRIPCION:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lOTESIMPORTADOSDataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(803, 364);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.aplicarCambiosButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 310);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(803, 54);
            this.panel3.TabIndex = 188;
            // 
            // aplicarCambiosButton
            // 
            this.aplicarCambiosButton.BackColor = System.Drawing.Color.Firebrick;
            this.aplicarCambiosButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aplicarCambiosButton.ForeColor = System.Drawing.Color.White;
            this.aplicarCambiosButton.Location = new System.Drawing.Point(349, 19);
            this.aplicarCambiosButton.Name = "aplicarCambiosButton";
            this.aplicarCambiosButton.Size = new System.Drawing.Size(119, 23);
            this.aplicarCambiosButton.TabIndex = 187;
            this.aplicarCambiosButton.Text = "Aplicar Cambios";
            this.aplicarCambiosButton.UseVisualStyleBackColor = false;
            this.aplicarCambiosButton.Click += new System.EventHandler(this.aplicarCambiosButton_Click);
            // 
            // lOTESIMPORTADOSDataGridView
            // 
            this.lOTESIMPORTADOSDataGridView.AllowUserToAddRows = false;
            this.lOTESIMPORTADOSDataGridView.AllowUserToDeleteRows = false;
            this.lOTESIMPORTADOSDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lOTESIMPORTADOSDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.lOTESIMPORTADOSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lOTESIMPORTADOSDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.ADUANAASIGNADA,
            this.ASIGNARADUANA});
            this.lOTESIMPORTADOSDataGridView.DataSource = this.lOTESIMPORTADOSBindingSource;
            this.lOTESIMPORTADOSDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lOTESIMPORTADOSDataGridView.Location = new System.Drawing.Point(0, 0);
            this.lOTESIMPORTADOSDataGridView.Name = "lOTESIMPORTADOSDataGridView";
            this.lOTESIMPORTADOSDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.lOTESIMPORTADOSDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.lOTESIMPORTADOSDataGridView.Size = new System.Drawing.Size(803, 364);
            this.lOTESIMPORTADOSDataGridView.TabIndex = 0;
            this.lOTESIMPORTADOSDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lOTESIMPORTADOSDataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ADUANA";
            this.dataGridViewTextBoxColumn3.HeaderText = "ADUANA";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // ADUANAASIGNADA
            // 
            this.ADUANAASIGNADA.HeaderText = "ADUANA ASIGNADA";
            this.ADUANAASIGNADA.Name = "ADUANAASIGNADA";
            this.ADUANAASIGNADA.Width = 200;
            // 
            // ASIGNARADUANA
            // 
            this.ASIGNARADUANA.HeaderText = "";
            this.ASIGNARADUANA.Name = "ASIGNARADUANA";
            this.ASIGNARADUANA.Text = "ASIGNAR";
            this.ASIGNARADUANA.UseColumnTextForButtonValue = true;
            // 
            // lOTESIMPORTADOSBindingSource
            // 
            this.lOTESIMPORTADOSBindingSource.DataMember = "LOTESIMPORTADOS";
            this.lOTESIMPORTADOSBindingSource.DataSource = this.dSCatalogosSat3;
            // 
            // dSCatalogosSat3
            // 
            this.dSCatalogosSat3.DataSetName = "DSCatalogosSat3";
            this.dSCatalogosSat3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lOTESIMPORTADOSTableAdapter
            // 
            this.lOTESIMPORTADOSTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Utilerias.Ajustes_catálogos_SAT.DSCatalogosSat3TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "ADUANA ASIGNADA";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "ASIGNAR";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // WFAduanasSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(803, 464);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFAduanasSat";
            this.Text = "Catálogo de Aduanas Sat";
            this.Load += new System.EventHandler(this.WFAduanasSat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lOTESIMPORTADOSDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOTESIMPORTADOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogosSat3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label descripcionLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DSCatalogosSat3 dSCatalogosSat3;
        private System.Windows.Forms.BindingSource lOTESIMPORTADOSBindingSource;
        private DSCatalogosSat3TableAdapters.LOTESIMPORTADOSTableAdapter lOTESIMPORTADOSTableAdapter;
        private DSCatalogosSat3TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum lOTESIMPORTADOSDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADUANAASIGNADA;
        private System.Windows.Forms.DataGridViewButtonColumn ASIGNARADUANA;
        private System.Windows.Forms.Label descripcionContentLabel;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Label aduanaLabel;
        private System.Windows.Forms.Button aduanaButton;
        private Tools.TextBoxFB aduanaTextBoxFb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button aplicarCambiosButton;
    }
}