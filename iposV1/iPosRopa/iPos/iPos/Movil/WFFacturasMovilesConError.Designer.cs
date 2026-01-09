namespace iPos
{
    partial class WFFacturasMovilesConError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFFacturasMovilesConError));
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dSMovil3 = new iPos.Movil.DSMovil3();
            this.fACTURASCONERRORBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fACTURASCONERRORTableAdapter = new iPos.Movil.DSMovil3TableAdapters.FACTURASCONERRORTableAdapter();
            this.tableAdapterManager = new iPos.Movil.DSMovil3TableAdapters.TableAdapterManager();
            this.fACTURASCONERRORDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSeleccionarVenta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACTURASCONERRORBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACTURASCONERRORDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(103, 54);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpInicio.TabIndex = 0;
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(406, 53);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(336, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha fin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(99, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "FACTURAS MOVILES CON ERRORES";
            // 
            // dSMovil3
            // 
            this.dSMovil3.DataSetName = "DSMovil3";
            this.dSMovil3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fACTURASCONERRORBindingSource
            // 
            this.fACTURASCONERRORBindingSource.DataMember = "FACTURASCONERROR";
            this.fACTURASCONERRORBindingSource.DataSource = this.dSMovil3;
            // 
            // fACTURASCONERRORTableAdapter
            // 
            this.fACTURASCONERRORTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Movil.DSMovil3TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // fACTURASCONERRORDataGridView
            // 
            this.fACTURASCONERRORDataGridView.AllowUserToAddRows = false;
            this.fACTURASCONERRORDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fACTURASCONERRORDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.fACTURASCONERRORDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fACTURASCONERRORDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.fACTURASCONERRORDataGridView.DataSource = this.fACTURASCONERRORBindingSource;
            this.fACTURASCONERRORDataGridView.Location = new System.Drawing.Point(12, 105);
            this.fACTURASCONERRORDataGridView.Name = "fACTURASCONERRORDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fACTURASCONERRORDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.fACTURASCONERRORDataGridView.RowHeadersVisible = false;
            this.fACTURASCONERRORDataGridView.Size = new System.Drawing.Size(708, 220);
            this.fACTURASCONERRORDataGridView.TabIndex = 7;
            this.fACTURASCONERRORDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fACTURASCONERRORDataGridView_CellContentDoubleClick);
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FOLIO";
            this.dataGridViewTextBoxColumn2.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SERIE";
            this.dataGridViewTextBoxColumn3.HeaderText = "SERIE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 45;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FOLIOSAT";
            this.dataGridViewTextBoxColumn4.HeaderText = "FOLIO SAT";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 75;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SERIESAT";
            this.dataGridViewTextBoxColumn5.HeaderText = "SERIE SAT";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 45;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "NOMBRECLIENTE";
            this.dataGridViewTextBoxColumn7.HeaderText = "CLIENTE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TOTAL";
            this.dataGridViewTextBoxColumn6.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NOMBREVENDEDOR";
            this.dataGridViewTextBoxColumn8.HeaderText = "VENDEDOR";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "USERNAME";
            this.dataGridViewTextBoxColumn9.HeaderText = "USERNAME";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // btnSeleccionarVenta
            // 
            this.btnSeleccionarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnSeleccionarVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSeleccionarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarVenta.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarVenta.Location = new System.Drawing.Point(651, 53);
            this.btnSeleccionarVenta.Name = "btnSeleccionarVenta";
            this.btnSeleccionarVenta.Size = new System.Drawing.Size(69, 23);
            this.btnSeleccionarVenta.TabIndex = 8;
            this.btnSeleccionarVenta.Text = "Buscar";
            this.btnSeleccionarVenta.UseVisualStyleBackColor = false;
            this.btnSeleccionarVenta.Click += new System.EventHandler(this.btnSeleccionarVenta_Click);
            // 
            // WFFacturasMovilesConError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(732, 451);
            this.Controls.Add(this.btnSeleccionarVenta);
            this.Controls.Add(this.fACTURASCONERRORDataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.dtpInicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFFacturasMovilesConError";
            this.Text = "WFFacturasMovilesConError";
            this.Load += new System.EventHandler(this.WFFacturasMovilesConError_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACTURASCONERRORBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACTURASCONERRORDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Movil.DSMovil3 dSMovil3;
        private System.Windows.Forms.BindingSource fACTURASCONERRORBindingSource;
        private Movil.DSMovil3TableAdapters.FACTURASCONERRORTableAdapter fACTURASCONERRORTableAdapter;
        private Movil.DSMovil3TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum fACTURASCONERRORDataGridView;
        private System.Windows.Forms.Button btnSeleccionarVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}