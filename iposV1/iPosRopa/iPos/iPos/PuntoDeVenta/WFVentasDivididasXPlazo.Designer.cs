namespace iPos
{
    partial class WFVentasDivididasXPlazo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFVentasDivididasXPlazo));
            this.vENTASCONERROREMIDADataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dOCTODIVIDIDOPORPLAZOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSPuntoDeVentaAux2 = new iPos.PuntoDeVenta.DSPuntoDeVentaAux2();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOCTODIVIDIDOPORPLAZOTableAdapter = new iPos.PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.DOCTODIVIDIDOPORPLAZOTableAdapter();
            this.tableAdapterManager1 = new iPos.PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGSALDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPLAZO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPagar = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblTotalVentas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPagarTodas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vENTASCONERROREMIDADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCTODIVIDIDOPORPLAZOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux2)).BeginInit();
            this.SuspendLayout();
            // 
            // vENTASCONERROREMIDADataGridView
            // 
            this.vENTASCONERROREMIDADataGridView.AllowUserToAddRows = false;
            this.vENTASCONERROREMIDADataGridView.AllowUserToDeleteRows = false;
            this.vENTASCONERROREMIDADataGridView.AutoGenerateColumns = false;
            this.vENTASCONERROREMIDADataGridView.CausesValidation = false;
            this.vENTASCONERROREMIDADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vENTASCONERROREMIDADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.DGID,
            this.DGSALDO,
            this.DGPLAZO,
            this.dataGridViewTextBoxColumn6,
            this.DGPagar});
            this.vENTASCONERROREMIDADataGridView.DataSource = this.dOCTODIVIDIDOPORPLAZOBindingSource;
            this.vENTASCONERROREMIDADataGridView.Location = new System.Drawing.Point(0, 57);
            this.vENTASCONERROREMIDADataGridView.Name = "vENTASCONERROREMIDADataGridView";
            this.vENTASCONERROREMIDADataGridView.RowHeadersVisible = false;
            this.vENTASCONERROREMIDADataGridView.Size = new System.Drawing.Size(864, 264);
            this.vENTASCONERROREMIDADataGridView.TabIndex = 2;
            this.vENTASCONERROREMIDADataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vENTASCONERROREMIDADataGridView_CellContentClick);
            // 
            // dOCTODIVIDIDOPORPLAZOBindingSource
            // 
            this.dOCTODIVIDIDOPORPLAZOBindingSource.DataMember = "DOCTODIVIDIDOPORPLAZO";
            this.dOCTODIVIDIDOPORPLAZOBindingSource.DataSource = this.dSPuntoDeVentaAux2;
            // 
            // dSPuntoDeVentaAux2
            // 
            this.dSPuntoDeVentaAux2.DataSetName = "DSPuntoDeVentaAux2";
            this.dSPuntoDeVentaAux2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnTerminar
            // 
            this.btnTerminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.ForeColor = System.Drawing.Color.White;
            this.btnTerminar.Location = new System.Drawing.Point(396, 335);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(75, 23);
            this.btnTerminar.TabIndex = 3;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dOCTODIVIDIDOPORPLAZOTableAdapter
            // 
            this.dOCTODIVIDIDOPORPLAZOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.EMIDAPRODUCTTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = iPos.PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FOLIO";
            this.dataGridViewTextBoxColumn2.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SERIE";
            this.dataGridViewTextBoxColumn3.HeaderText = "SERIE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
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
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "NOMBRECLIENTE";
            this.dataGridViewTextBoxColumn7.HeaderText = "CLIENTE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 150;
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
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // DGSALDO
            // 
            this.DGSALDO.DataPropertyName = "SALDO";
            this.DGSALDO.HeaderText = "SALDO";
            this.DGSALDO.Name = "DGSALDO";
            this.DGSALDO.Visible = false;
            // 
            // DGPLAZO
            // 
            this.DGPLAZO.DataPropertyName = "PLAZO";
            this.DGPLAZO.HeaderText = "PLAZO";
            this.DGPLAZO.Name = "DGPLAZO";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TOTAL";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn6.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // DGPagar
            // 
            this.DGPagar.HeaderText = "PAGAR";
            this.DGPagar.Image = global::iPos.Properties.Resources.cash_J;
            this.DGPagar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.DGPagar.Name = "DGPagar";
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.AutoSize = true;
            this.lblTotalVentas.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVentas.ForeColor = System.Drawing.Color.White;
            this.lblTotalVentas.Location = new System.Drawing.Point(280, 9);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(38, 31);
            this.lblTotalVentas.TabIndex = 4;
            this.lblTotalVentas.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(191, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total";
            // 
            // btnPagarTodas
            // 
            this.btnPagarTodas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnPagarTodas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagarTodas.ForeColor = System.Drawing.Color.White;
            this.btnPagarTodas.Location = new System.Drawing.Point(599, 28);
            this.btnPagarTodas.Name = "btnPagarTodas";
            this.btnPagarTodas.Size = new System.Drawing.Size(95, 23);
            this.btnPagarTodas.TabIndex = 6;
            this.btnPagarTodas.Text = "Pagarlas todas";
            this.btnPagarTodas.UseVisualStyleBackColor = false;
            this.btnPagarTodas.Click += new System.EventHandler(this.btnPagarTodas_Click);
            // 
            // WFVentasDivididasXPlazo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(864, 370);
            this.Controls.Add(this.btnPagarTodas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalVentas);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.vENTASCONERROREMIDADataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFVentasDivididasXPlazo";
            this.Text = "Ventas divididas por plazo";
            this.Load += new System.EventHandler(this.WFVentasDivididasXPlazo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vENTASCONERROREMIDADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCTODIVIDIDOPORPLAZOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewSum vENTASCONERROREMIDADataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnTerminar;
        private PuntoDeVenta.DSPuntoDeVentaAux2 dSPuntoDeVentaAux2;
        private System.Windows.Forms.BindingSource dOCTODIVIDIDOPORPLAZOBindingSource;
        private PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.DOCTODIVIDIDOPORPLAZOTableAdapter dOCTODIVIDIDOPORPLAZOTableAdapter;
        private PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGSALDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPLAZO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewImageColumn DGPagar;
        private System.Windows.Forms.Label lblTotalVentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPagarTodas;
    }
}