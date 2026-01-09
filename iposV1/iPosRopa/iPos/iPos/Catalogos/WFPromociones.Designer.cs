namespace iPos.Catalogos
{
    partial class WFPromociones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPromociones));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBSoloVigentes = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TSTPalabrasClave = new System.Windows.Forms.ToolStripTextBox();
            this.TSBBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSBAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.TSBEliminarTodas = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TableDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.TableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCatalogos = new iPos.Catalogos.DSCatalogos();
            this.tableAdapterManager = new iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager();
            this.TableTableAdapter = new iPos.Catalogos.DSCatalogosTableAdapters.PROMOCION_VIEWTableAdapter();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwCLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGACTIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAINICIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAFIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVer = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColDesactivar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.panel1.Controls.Add(this.CBSoloVigentes);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 53);
            this.panel1.TabIndex = 0;
            // 
            // CBSoloVigentes
            // 
            this.CBSoloVigentes.AutoSize = true;
            this.CBSoloVigentes.Checked = true;
            this.CBSoloVigentes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBSoloVigentes.ForeColor = System.Drawing.Color.White;
            this.CBSoloVigentes.Location = new System.Drawing.Point(107, 33);
            this.CBSoloVigentes.Name = "CBSoloVigentes";
            this.CBSoloVigentes.Size = new System.Drawing.Size(90, 17);
            this.CBSoloVigentes.TabIndex = 1;
            this.CBSoloVigentes.Text = "Solo vigentes";
            this.CBSoloVigentes.UseVisualStyleBackColor = true;
            this.CBSoloVigentes.CheckedChanged += new System.EventHandler(this.CBSoloVigentes_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TSTPalabrasClave,
            this.TSBBuscar,
            this.toolStripSeparator1,
            this.TSBAgregar,
            this.toolStripButton1,
            this.TSBEliminarTodas,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(701, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(95, 22);
            this.toolStripLabel1.Text = "Palabras clave:";
            // 
            // TSTPalabrasClave
            // 
            this.TSTPalabrasClave.Name = "TSTPalabrasClave";
            this.TSTPalabrasClave.Size = new System.Drawing.Size(150, 25);
            this.TSTPalabrasClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TSTPalabrasClave_KeyDown);
            // 
            // TSBBuscar
            // 
            this.TSBBuscar.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.TSBBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TSBBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBBuscar.Name = "TSBBuscar";
            this.TSBBuscar.Size = new System.Drawing.Size(23, 22);
            this.TSBBuscar.Text = "Buscar";
            this.TSBBuscar.Click += new System.EventHandler(this.TSBBuscar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TSBAgregar
            // 
            this.TSBAgregar.BackgroundImage = global::iPos.Properties.Resources.add_J;
            this.TSBAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TSBAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBAgregar.Name = "TSBAgregar";
            this.TSBAgregar.Size = new System.Drawing.Size(23, 22);
            this.TSBAgregar.Text = "Agregar";
            this.TSBAgregar.Click += new System.EventHandler(this.TSBAgregar_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackgroundImage = global::iPos.Properties.Resources.exitRed_J;
            this.toolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "TSBSalir";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // TSBEliminarTodas
            // 
            this.TSBEliminarTodas.BackgroundImage = global::iPos.Properties.Resources.close_J;
            this.TSBEliminarTodas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TSBEliminarTodas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBEliminarTodas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.TSBEliminarTodas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBEliminarTodas.Name = "TSBEliminarTodas";
            this.TSBEliminarTodas.Size = new System.Drawing.Size(23, 22);
            this.TSBEliminarTodas.Text = "TSBSalir";
            this.TSBEliminarTodas.Click += new System.EventHandler(this.TSBEliminarTodas_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.toolStripSplitButton1.Image = global::iPos.Properties.Resources.image_J;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn7.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Text = "Ver";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 75;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            this.dataGridViewButtonColumn2.Text = "Editar";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Width = 75;
            // 
            // TableDataGridView
            // 
            this.TableDataGridView.AllowUserToAddRows = false;
            this.TableDataGridView.AutoGenerateColumns = false;
            this.TableDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dgwCLAVE,
            this.dataGridViewTextBoxColumn8,
            this.DGACTIVO,
            this.FECHAINICIO,
            this.FECHAFIN,
            this.ColVer,
            this.colEditar,
            this.ColDesactivar});
            this.TableDataGridView.DataSource = this.TableBindingSource;
            this.TableDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableDataGridView.EnableHeadersVisualStyles = false;
            this.TableDataGridView.Location = new System.Drawing.Point(0, 53);
            this.TableDataGridView.Name = "TableDataGridView";
            this.TableDataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.TableDataGridView.RowHeadersVisible = false;
            this.TableDataGridView.Size = new System.Drawing.Size(701, 316);
            this.TableDataGridView.TabIndex = 2;
            this.TableDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableDataGridView_CellContentClick);
            this.TableDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableDataGridView_CellDoubleClick);
            this.TableDataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TableDataGridView_PreviewKeyDown);
            // 
            // TableBindingSource
            // 
            this.TableBindingSource.DataMember = "PROMOCION_VIEW";
            this.TableBindingSource.DataSource = this.dSCatalogos;
            // 
            // dSCatalogos
            // 
            this.dSCatalogos.DataSetName = "DSCatalogos";
            this.dSCatalogos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.LINEA_VIEWTableAdapter = null;
            this.tableAdapterManager.PERSONAAPARTADOTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // TableTableAdapter
            // 
            this.TableTableAdapter.ClearBeforeFill = true;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.ReadOnly = true;
            this.DGID.Visible = false;
            this.DGID.Width = 120;
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
            // dgwCLAVE
            // 
            this.dgwCLAVE.DataPropertyName = "CLAVE";
            this.dgwCLAVE.HeaderText = "CLAVE";
            this.dgwCLAVE.Name = "dgwCLAVE";
            this.dgwCLAVE.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn8.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 160;
            // 
            // DGACTIVO
            // 
            this.DGACTIVO.DataPropertyName = "ACTIVO";
            this.DGACTIVO.HeaderText = "ACTIVO";
            this.DGACTIVO.Name = "DGACTIVO";
            this.DGACTIVO.ReadOnly = true;
            this.DGACTIVO.Width = 55;
            // 
            // FECHAINICIO
            // 
            this.FECHAINICIO.DataPropertyName = "FECHAINICIO";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.FECHAINICIO.DefaultCellStyle = dataGridViewCellStyle2;
            this.FECHAINICIO.HeaderText = "F. INICIO";
            this.FECHAINICIO.Name = "FECHAINICIO";
            this.FECHAINICIO.ReadOnly = true;
            this.FECHAINICIO.Width = 85;
            // 
            // FECHAFIN
            // 
            this.FECHAFIN.DataPropertyName = "FECHAFIN";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.FECHAFIN.DefaultCellStyle = dataGridViewCellStyle3;
            this.FECHAFIN.HeaderText = "F. FIN";
            this.FECHAFIN.Name = "FECHAFIN";
            this.FECHAFIN.ReadOnly = true;
            this.FECHAFIN.Width = 85;
            // 
            // ColVer
            // 
            this.ColVer.HeaderText = "";
            this.ColVer.Image = global::iPos.Properties.Resources.eye_J;
            this.ColVer.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.ColVer.Name = "ColVer";
            this.ColVer.ReadOnly = true;
            this.ColVer.Width = 30;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "";
            this.colEditar.Image = global::iPos.Properties.Resources.edit_J;
            this.colEditar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Width = 30;
            // 
            // ColDesactivar
            // 
            this.ColDesactivar.HeaderText = "";
            this.ColDesactivar.Name = "ColDesactivar";
            this.ColDesactivar.ReadOnly = true;
            this.ColDesactivar.Text = "CAMBIAR ACTIVO";
            this.ColDesactivar.UseColumnTextForButtonValue = true;
            this.ColDesactivar.Width = 105;
            // 
            // WFPromociones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 369);
            this.Controls.Add(this.TableDataGridView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFPromociones";
            this.Text = "PROMOCIONES";
            this.Load += new System.EventHandler(this.WFPromociones_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DSCatalogos dSCatalogos;
        private System.Windows.Forms.BindingSource TableBindingSource;
        private DSCatalogosTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox TSTPalabrasClave;
        private System.Windows.Forms.ToolStripButton TSBBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSBAgregar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private DSCatalogosTableAdapters.PROMOCION_VIEWTableAdapter TableTableAdapter;
        private System.Windows.Forms.ToolStripButton TSBEliminarTodas;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.DataGridViewSum TableDataGridView;
        private System.Windows.Forms.CheckBox CBSoloVigentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwCLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGACTIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAINICIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAFIN;
        private System.Windows.Forms.DataGridViewImageColumn ColVer;
        private System.Windows.Forms.DataGridViewImageColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn ColDesactivar;
    }
}