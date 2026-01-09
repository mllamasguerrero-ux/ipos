namespace iPos
{
    partial class WFSurtidoVentasMoviles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFSurtidoVentasMoviles));
            this.label1 = new System.Windows.Forms.Label();
            this.surtidoVentasMovilesDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.surtidoVentasMovilesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSMovil3 = new iPos.Movil.DSMovil3();
            this.surtidoVentasMovilesTableAdapter = new iPos.Movil.DSMovil3TableAdapters.SurtidoVentasMovilesTableAdapter();
            this.tableAdapterManager = new iPos.Movil.DSMovil3TableAdapters.TableAdapterManager();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVER = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGIMPRIMIR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGSURTIDO = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGFECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFOLIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGNOMBRECLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGALMACENCLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCHECK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGOBSERVACIONFACTURACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.surtidoVentasMovilesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.surtidoVentasMovilesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(89, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "SURTIDO VENTAS MOVILES";
            // 
            // surtidoVentasMovilesDataGridView
            // 
            this.surtidoVentasMovilesDataGridView.AllowUserToAddRows = false;
            this.surtidoVentasMovilesDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.surtidoVentasMovilesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.surtidoVentasMovilesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.surtidoVentasMovilesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.DGVER,
            this.DGIMPRIMIR,
            this.DGSURTIDO,
            this.DGFECHA,
            this.DGFOLIO,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.DGNOMBRECLIENTE,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn6,
            this.DGALMACENCLAVE,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.DGCHECK,
            this.DGOBSERVACIONFACTURACION});
            this.surtidoVentasMovilesDataGridView.DataSource = this.surtidoVentasMovilesBindingSource;
            this.surtidoVentasMovilesDataGridView.Location = new System.Drawing.Point(0, 56);
            this.surtidoVentasMovilesDataGridView.Name = "surtidoVentasMovilesDataGridView";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.surtidoVentasMovilesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.surtidoVentasMovilesDataGridView.RowHeadersVisible = false;
            this.surtidoVentasMovilesDataGridView.Size = new System.Drawing.Size(835, 266);
            this.surtidoVentasMovilesDataGridView.TabIndex = 5;
            this.surtidoVentasMovilesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.surtidoVentasMovilesDataGridView_CellContentClick);
            this.surtidoVentasMovilesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.surtidoVentasMovilesDataGridView_CellFormatting);
            // 
            // surtidoVentasMovilesBindingSource
            // 
            this.surtidoVentasMovilesBindingSource.DataMember = "SurtidoVentasMoviles";
            this.surtidoVentasMovilesBindingSource.DataSource = this.dSMovil3;
            // 
            // dSMovil3
            // 
            this.dSMovil3.DataSetName = "DSMovil3";
            this.dSMovil3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // surtidoVentasMovilesTableAdapter
            // 
            this.surtidoVentasMovilesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Movil.DSMovil3TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // DGVER
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.DGVER.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVER.HeaderText = "Ver";
            this.DGVER.Name = "DGVER";
            this.DGVER.Text = "Ver";
            this.DGVER.UseColumnTextForButtonValue = true;
            this.DGVER.Width = 35;
            // 
            // DGIMPRIMIR
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.DGIMPRIMIR.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGIMPRIMIR.HeaderText = "Imprimir";
            this.DGIMPRIMIR.Name = "DGIMPRIMIR";
            this.DGIMPRIMIR.Text = "Imprimir";
            this.DGIMPRIMIR.UseColumnTextForButtonValue = true;
            this.DGIMPRIMIR.Width = 45;
            // 
            // DGSURTIDO
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.DGSURTIDO.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGSURTIDO.HeaderText = "Surtido";
            this.DGSURTIDO.Name = "DGSURTIDO";
            this.DGSURTIDO.Text = "Surtido";
            this.DGSURTIDO.UseColumnTextForButtonValue = true;
            this.DGSURTIDO.Width = 45;
            // 
            // DGFECHA
            // 
            this.DGFECHA.DataPropertyName = "FECHA";
            this.DGFECHA.HeaderText = "FECHA";
            this.DGFECHA.Name = "DGFECHA";
            this.DGFECHA.Width = 65;
            // 
            // DGFOLIO
            // 
            this.DGFOLIO.DataPropertyName = "FOLIO";
            this.DGFOLIO.HeaderText = "FOLIO";
            this.DGFOLIO.Name = "DGFOLIO";
            this.DGFOLIO.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SERIE";
            this.dataGridViewTextBoxColumn3.HeaderText = "SERIE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FOLIOSAT";
            this.dataGridViewTextBoxColumn4.HeaderText = "FOLIO SAT";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SERIESAT";
            this.dataGridViewTextBoxColumn5.HeaderText = "SERIE SAT";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 40;
            // 
            // DGNOMBRECLIENTE
            // 
            this.DGNOMBRECLIENTE.DataPropertyName = "NOMBRECLIENTE";
            this.DGNOMBRECLIENTE.HeaderText = "NOMBRECLIENTE";
            this.DGNOMBRECLIENTE.Name = "DGNOMBRECLIENTE";
            this.DGNOMBRECLIENTE.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NOMBREVENDEDOR";
            this.dataGridViewTextBoxColumn8.HeaderText = "VENDEDOR";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 130;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TOTAL";
            this.dataGridViewTextBoxColumn6.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // DGALMACENCLAVE
            // 
            this.DGALMACENCLAVE.DataPropertyName = "ALMACENCLAVE";
            this.DGALMACENCLAVE.HeaderText = "ALMACEN";
            this.DGALMACENCLAVE.Name = "DGALMACENCLAVE";
            this.DGALMACENCLAVE.Width = 90;
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
            // DGCHECK
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.NullValue = false;
            this.DGCHECK.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGCHECK.HeaderText = "PROCESO SURTIDO";
            this.DGCHECK.Name = "DGCHECK";
            this.DGCHECK.Visible = false;
            this.DGCHECK.Width = 60;
            // 
            // DGOBSERVACIONFACTURACION
            // 
            this.DGOBSERVACIONFACTURACION.DataPropertyName = "OBSERVACIONFACTURACION";
            this.DGOBSERVACIONFACTURACION.HeaderText = "OBSERVACIONFACTURACION";
            this.DGOBSERVACIONFACTURACION.Name = "DGOBSERVACIONFACTURACION";
            this.DGOBSERVACIONFACTURACION.ReadOnly = true;
            // 
            // WFSurtidoVentasMoviles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(835, 390);
            this.Controls.Add(this.surtidoVentasMovilesDataGridView);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFSurtidoVentasMoviles";
            this.Text = "WFSurtidoVentasMoviles";
            this.Load += new System.EventHandler(this.WFSurtidoVentasMoviles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.surtidoVentasMovilesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.surtidoVentasMovilesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Movil.DSMovil3 dSMovil3;
        private System.Windows.Forms.BindingSource surtidoVentasMovilesBindingSource;
        private Movil.DSMovil3TableAdapters.SurtidoVentasMovilesTableAdapter surtidoVentasMovilesTableAdapter;
        private Movil.DSMovil3TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum surtidoVentasMovilesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewButtonColumn DGVER;
        private System.Windows.Forms.DataGridViewButtonColumn DGIMPRIMIR;
        private System.Windows.Forms.DataGridViewButtonColumn DGSURTIDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFOLIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGNOMBRECLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGALMACENCLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGCHECK;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGOBSERVACIONFACTURACION;
    }
}