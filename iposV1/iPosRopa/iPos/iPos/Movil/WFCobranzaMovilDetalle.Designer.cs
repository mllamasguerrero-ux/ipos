namespace iPos
{
    partial class WFCobranzaMovilDetalle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFCobranzaMovilDetalle));
            this.dSMovil2 = new iPos.Movil.DSMovil2();
            this.pAGOPORCOBRANZABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pAGOPORCOBRANZATableAdapter = new iPos.Movil.DSMovil2TableAdapters.PAGOPORCOBRANZATableAdapter();
            this.tableAdapterManager = new iPos.Movil.DSMovil2TableAdapters.TableAdapterManager();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pAGOPORCOBRANZADataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPAGOMOVILID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VERPAGO = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGHEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.COBRANZALabel = new System.Windows.Forms.Label();
            this.VENTATEXT = new System.Windows.Forms.Label();
            this.COBRANZATEXT = new System.Windows.Forms.Label();
            this.VENTALabel = new System.Windows.Forms.Label();
            this.FACTURALabel = new System.Windows.Forms.Label();
            this.FACTURATEXT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOPORCOBRANZABindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOPORCOBRANZADataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSMovil2
            // 
            this.dSMovil2.DataSetName = "DSMovil2";
            this.dSMovil2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pAGOPORCOBRANZABindingSource
            // 
            this.pAGOPORCOBRANZABindingSource.DataMember = "PAGOPORCOBRANZA";
            this.pAGOPORCOBRANZABindingSource.DataSource = this.dSMovil2;
            // 
            // pAGOPORCOBRANZATableAdapter
            // 
            this.pAGOPORCOBRANZATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.COBRANZAMOVILBYIDTableAdapter = null;
            this.tableAdapterManager.COBRANZAMOVILTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Movil.DSMovil2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pAGOPORCOBRANZADataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(759, 351);
            this.panel2.TabIndex = 10;
            // 
            // pAGOPORCOBRANZADataGridView
            // 
            this.pAGOPORCOBRANZADataGridView.AllowUserToAddRows = false;
            this.pAGOPORCOBRANZADataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pAGOPORCOBRANZADataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pAGOPORCOBRANZADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pAGOPORCOBRANZADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.DGPAGOMOVILID,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.VERPAGO,
            this.DGHEIGHT});
            this.pAGOPORCOBRANZADataGridView.DataSource = this.pAGOPORCOBRANZABindingSource;
            this.pAGOPORCOBRANZADataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAGOPORCOBRANZADataGridView.Location = new System.Drawing.Point(0, 0);
            this.pAGOPORCOBRANZADataGridView.Name = "pAGOPORCOBRANZADataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pAGOPORCOBRANZADataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.pAGOPORCOBRANZADataGridView.RowHeadersVisible = false;
            this.pAGOPORCOBRANZADataGridView.Size = new System.Drawing.Size(759, 351);
            this.pAGOPORCOBRANZADataGridView.TabIndex = 2;
            this.pAGOPORCOBRANZADataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pAGOPORCOBRANZADataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // DGPAGOMOVILID
            // 
            this.DGPAGOMOVILID.DataPropertyName = "PAGOMOVILID";
            this.DGPAGOMOVILID.HeaderText = "PAGO ID";
            this.DGPAGOMOVILID.Name = "DGPAGOMOVILID";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "COBRANZAID";
            this.dataGridViewTextBoxColumn8.HeaderText = "COBRANZAID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "TIPO";
            this.dataGridViewTextBoxColumn18.HeaderText = "TIPO";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ESTATUS";
            this.dataGridViewTextBoxColumn9.HeaderText = "ESTATUS";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn10.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "IMPORTE";
            this.dataGridViewTextBoxColumn13.HeaderText = "IMPORTE";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "TIPOPAGOID";
            this.dataGridViewTextBoxColumn16.HeaderText = "TIPOPAGOID";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "VENTACOBRANZA";
            this.dataGridViewTextBoxColumn17.HeaderText = "VENTA-COBR.";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // VERPAGO
            // 
            this.VERPAGO.HeaderText = "";
            this.VERPAGO.Name = "VERPAGO";
            this.VERPAGO.Text = "VER";
            this.VERPAGO.UseColumnTextForButtonValue = true;
            // 
            // DGHEIGHT
            // 
            dataGridViewCellStyle2.NullValue = " ";
            this.DGHEIGHT.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGHEIGHT.HeaderText = "";
            this.DGHEIGHT.Name = "DGHEIGHT";
            this.DGHEIGHT.ReadOnly = true;
            this.DGHEIGHT.Width = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.COBRANZALabel);
            this.panel1.Controls.Add(this.VENTATEXT);
            this.panel1.Controls.Add(this.COBRANZATEXT);
            this.panel1.Controls.Add(this.VENTALabel);
            this.panel1.Controls.Add(this.FACTURALabel);
            this.panel1.Controls.Add(this.FACTURATEXT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 63);
            this.panel1.TabIndex = 9;
            // 
            // COBRANZALabel
            // 
            this.COBRANZALabel.AutoSize = true;
            this.COBRANZALabel.BackColor = System.Drawing.Color.Transparent;
            this.COBRANZALabel.ForeColor = System.Drawing.Color.White;
            this.COBRANZALabel.Location = new System.Drawing.Point(57, 27);
            this.COBRANZALabel.Name = "COBRANZALabel";
            this.COBRANZALabel.Size = new System.Drawing.Size(66, 13);
            this.COBRANZALabel.TabIndex = 3;
            this.COBRANZALabel.Text = "COBRANZA";
            // 
            // VENTATEXT
            // 
            this.VENTATEXT.AutoSize = true;
            this.VENTATEXT.BackColor = System.Drawing.Color.Transparent;
            this.VENTATEXT.ForeColor = System.Drawing.Color.White;
            this.VENTATEXT.Location = new System.Drawing.Point(564, 27);
            this.VENTATEXT.Name = "VENTATEXT";
            this.VENTATEXT.Size = new System.Drawing.Size(16, 13);
            this.VENTATEXT.TabIndex = 8;
            this.VENTATEXT.Text = "...";
            // 
            // COBRANZATEXT
            // 
            this.COBRANZATEXT.AutoSize = true;
            this.COBRANZATEXT.BackColor = System.Drawing.Color.Transparent;
            this.COBRANZATEXT.ForeColor = System.Drawing.Color.White;
            this.COBRANZATEXT.Location = new System.Drawing.Point(129, 27);
            this.COBRANZATEXT.Name = "COBRANZATEXT";
            this.COBRANZATEXT.Size = new System.Drawing.Size(13, 13);
            this.COBRANZATEXT.TabIndex = 4;
            this.COBRANZATEXT.Text = "..";
            // 
            // VENTALabel
            // 
            this.VENTALabel.AutoSize = true;
            this.VENTALabel.BackColor = System.Drawing.Color.Transparent;
            this.VENTALabel.ForeColor = System.Drawing.Color.White;
            this.VENTALabel.Location = new System.Drawing.Point(508, 27);
            this.VENTALabel.Name = "VENTALabel";
            this.VENTALabel.Size = new System.Drawing.Size(43, 13);
            this.VENTALabel.TabIndex = 7;
            this.VENTALabel.Text = "VENTA";
            // 
            // FACTURALabel
            // 
            this.FACTURALabel.AutoSize = true;
            this.FACTURALabel.BackColor = System.Drawing.Color.Transparent;
            this.FACTURALabel.ForeColor = System.Drawing.Color.White;
            this.FACTURALabel.Location = new System.Drawing.Point(291, 27);
            this.FACTURALabel.Name = "FACTURALabel";
            this.FACTURALabel.Size = new System.Drawing.Size(57, 13);
            this.FACTURALabel.TabIndex = 5;
            this.FACTURALabel.Text = "FACTURA";
            // 
            // FACTURATEXT
            // 
            this.FACTURATEXT.AutoSize = true;
            this.FACTURATEXT.BackColor = System.Drawing.Color.Transparent;
            this.FACTURATEXT.ForeColor = System.Drawing.Color.White;
            this.FACTURATEXT.Location = new System.Drawing.Point(354, 27);
            this.FACTURATEXT.Name = "FACTURATEXT";
            this.FACTURATEXT.Size = new System.Drawing.Size(13, 13);
            this.FACTURATEXT.TabIndex = 6;
            this.FACTURATEXT.Text = "..";
            // 
            // WFCobranzaMovilDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(759, 414);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFCobranzaMovilDetalle";
            this.Text = "WFCobranzaMovilDetalle";
            this.Load += new System.EventHandler(this.WFCobranzaMovilDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOPORCOBRANZABindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pAGOPORCOBRANZADataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Movil.DSMovil2 dSMovil2;
        private System.Windows.Forms.BindingSource pAGOPORCOBRANZABindingSource;
        private Movil.DSMovil2TableAdapters.PAGOPORCOBRANZATableAdapter pAGOPORCOBRANZATableAdapter;
        private Movil.DSMovil2TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum pAGOPORCOBRANZADataGridView;
        private System.Windows.Forms.Label COBRANZALabel;
        private System.Windows.Forms.Label COBRANZATEXT;
        private System.Windows.Forms.Label FACTURALabel;
        private System.Windows.Forms.Label FACTURATEXT;
        private System.Windows.Forms.Label VENTATEXT;
        private System.Windows.Forms.Label VENTALabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPAGOMOVILID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewButtonColumn VERPAGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGHEIGHT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}