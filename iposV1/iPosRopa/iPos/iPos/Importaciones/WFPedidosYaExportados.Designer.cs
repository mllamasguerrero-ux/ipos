namespace iPos
{
    partial class WFPedidosYaExportados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPedidosYaExportados));
            this.dSImportaciones = new iPos.Importaciones.DSImportaciones();
            this.tableAdapterManager = new iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager();
            this.pedidosYaExportadosDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DG_DOCTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_EXPFILEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOLIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAINI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAFIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRECAJERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTATUSPEDIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_REENVIAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lISTAPEDIDOSENVIADOSFECHABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTSI = new System.Windows.Forms.Button();
            this.BTNO = new System.Windows.Forms.Button();
            this.uLTIMOPEDIDOENVIADOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uLTIMOPEDIDOENVIADOTableAdapter = new iPos.Importaciones.DSImportacionesTableAdapters.ULTIMOPEDIDOENVIADOTableAdapter();
            this.lISTAPEDIDOSENVIADOSFECHATableAdapter = new iPos.Importaciones.DSImportacionesTableAdapters.LISTAPEDIDOSENVIADOSFECHATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosYaExportadosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lISTAPEDIDOSENVIADOSFECHABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uLTIMOPEDIDOENVIADOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dSImportaciones
            // 
            this.dSImportaciones.DataSetName = "DSImportaciones";
            this.dSImportaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // pedidosYaExportadosDataGridView
            // 
            this.pedidosYaExportadosDataGridView.AllowUserToAddRows = false;
            this.pedidosYaExportadosDataGridView.AutoGenerateColumns = false;
            this.pedidosYaExportadosDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pedidosYaExportadosDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pedidosYaExportadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pedidosYaExportadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DG_DOCTOID,
            this.DG_EXPFILEID,
            this.FOLIO,
            this.DG_FECHA,
            this.FECHAINI,
            this.FECHAFIN,
            this.NOMBRECAJERO,
            this.ESTATUSPEDIDO,
            this.dataGridViewTextBoxColumn4,
            this.DG_REENVIAR});
            this.pedidosYaExportadosDataGridView.DataSource = this.lISTAPEDIDOSENVIADOSFECHABindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.pedidosYaExportadosDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.pedidosYaExportadosDataGridView.EnableHeadersVisualStyles = false;
            this.pedidosYaExportadosDataGridView.Location = new System.Drawing.Point(78, 124);
            this.pedidosYaExportadosDataGridView.Name = "pedidosYaExportadosDataGridView";
            this.pedidosYaExportadosDataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pedidosYaExportadosDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.pedidosYaExportadosDataGridView.RowHeadersVisible = false;
            this.pedidosYaExportadosDataGridView.Size = new System.Drawing.Size(706, 218);
            this.pedidosYaExportadosDataGridView.TabIndex = 3;
            this.pedidosYaExportadosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pedidosYaExportadosDataGridView_CellContentClick);
            // 
            // DG_DOCTOID
            // 
            this.DG_DOCTOID.DataPropertyName = "ID";
            this.DG_DOCTOID.HeaderText = "ID";
            this.DG_DOCTOID.Name = "DG_DOCTOID";
            this.DG_DOCTOID.ReadOnly = true;
            this.DG_DOCTOID.Visible = false;
            // 
            // DG_EXPFILEID
            // 
            this.DG_EXPFILEID.DataPropertyName = "EXPFILEID";
            this.DG_EXPFILEID.HeaderText = "EXPFILEID";
            this.DG_EXPFILEID.Name = "DG_EXPFILEID";
            this.DG_EXPFILEID.ReadOnly = true;
            this.DG_EXPFILEID.Visible = false;
            // 
            // FOLIO
            // 
            this.FOLIO.DataPropertyName = "FOLIO";
            this.FOLIO.HeaderText = "FOLIO";
            this.FOLIO.Name = "FOLIO";
            this.FOLIO.ReadOnly = true;
            // 
            // DG_FECHA
            // 
            this.DG_FECHA.DataPropertyName = "FECHA";
            this.DG_FECHA.HeaderText = "FECHA";
            this.DG_FECHA.Name = "DG_FECHA";
            this.DG_FECHA.ReadOnly = true;
            // 
            // FECHAINI
            // 
            this.FECHAINI.DataPropertyName = "FECHAINI";
            this.FECHAINI.HeaderText = "FECHAINI";
            this.FECHAINI.Name = "FECHAINI";
            this.FECHAINI.ReadOnly = true;
            // 
            // FECHAFIN
            // 
            this.FECHAFIN.DataPropertyName = "FECHAFIN";
            this.FECHAFIN.HeaderText = "FECHAFIN";
            this.FECHAFIN.Name = "FECHAFIN";
            this.FECHAFIN.ReadOnly = true;
            // 
            // NOMBRECAJERO
            // 
            this.NOMBRECAJERO.DataPropertyName = "NOMBRECAJERO";
            this.NOMBRECAJERO.HeaderText = "NOMBRECAJERO";
            this.NOMBRECAJERO.Name = "NOMBRECAJERO";
            this.NOMBRECAJERO.ReadOnly = true;
            // 
            // ESTATUSPEDIDO
            // 
            this.ESTATUSPEDIDO.DataPropertyName = "ESTATUSPEDIDO";
            this.ESTATUSPEDIDO.HeaderText = "ESTATUSPEDIDO";
            this.ESTATUSPEDIDO.Name = "ESTATUSPEDIDO";
            this.ESTATUSPEDIDO.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ESTATUS";
            this.dataGridViewTextBoxColumn4.HeaderText = "ESTATUS";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // DG_REENVIAR
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "REENVIAR";
            this.DG_REENVIAR.DefaultCellStyle = dataGridViewCellStyle2;
            this.DG_REENVIAR.HeaderText = "REENVIAR";
            this.DG_REENVIAR.Name = "DG_REENVIAR";
            this.DG_REENVIAR.ReadOnly = true;
            this.DG_REENVIAR.Text = "REENVIAR";
            // 
            // lISTAPEDIDOSENVIADOSFECHABindingSource
            // 
            this.lISTAPEDIDOSENVIADOSFECHABindingSource.DataMember = "LISTAPEDIDOSENVIADOSFECHA";
            this.lISTAPEDIDOSENVIADOSFECHABindingSource.DataSource = this.dSImportaciones;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(75, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Los siguientes pedidos ya se enviaron.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(75, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Desea volver a regenerar el pedido?";
            // 
            // BTSI
            // 
            this.BTSI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTSI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTSI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTSI.ForeColor = System.Drawing.Color.White;
            this.BTSI.Location = new System.Drawing.Point(383, 82);
            this.BTSI.Name = "BTSI";
            this.BTSI.Size = new System.Drawing.Size(52, 25);
            this.BTSI.TabIndex = 2;
            this.BTSI.Text = "Si";
            this.BTSI.UseVisualStyleBackColor = false;
            this.BTSI.Click += new System.EventHandler(this.BTSI_Click);
            // 
            // BTNO
            // 
            this.BTNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTNO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNO.ForeColor = System.Drawing.Color.White;
            this.BTNO.Location = new System.Drawing.Point(314, 82);
            this.BTNO.Name = "BTNO";
            this.BTNO.Size = new System.Drawing.Size(52, 25);
            this.BTNO.TabIndex = 1;
            this.BTNO.Text = "No";
            this.BTNO.UseVisualStyleBackColor = false;
            this.BTNO.Click += new System.EventHandler(this.BTNO_Click);
            // 
            // uLTIMOPEDIDOENVIADOBindingSource
            // 
            this.uLTIMOPEDIDOENVIADOBindingSource.DataMember = "ULTIMOPEDIDOENVIADO";
            this.uLTIMOPEDIDOENVIADOBindingSource.DataSource = this.dSImportaciones;
            // 
            // uLTIMOPEDIDOENVIADOTableAdapter
            // 
            this.uLTIMOPEDIDOENVIADOTableAdapter.ClearBeforeFill = true;
            // 
            // lISTAPEDIDOSENVIADOSFECHATableAdapter
            // 
            this.lISTAPEDIDOSENVIADOSFECHATableAdapter.ClearBeforeFill = true;
            // 
            // WFPedidosYaExportados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(850, 455);
            this.Controls.Add(this.BTNO);
            this.Controls.Add(this.BTSI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pedidosYaExportadosDataGridView);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFPedidosYaExportados";
            this.Text = "Pedidos Ya Exportados";
            this.Load += new System.EventHandler(this.WFPedidosYaExportados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosYaExportadosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lISTAPEDIDOSENVIADOSFECHABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uLTIMOPEDIDOENVIADOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private iPos.Importaciones.DSImportaciones dSImportaciones;
        private iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum pedidosYaExportadosDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTSI;
        private System.Windows.Forms.Button BTNO;
        private System.Windows.Forms.BindingSource uLTIMOPEDIDOENVIADOBindingSource;
        private Importaciones.DSImportacionesTableAdapters.ULTIMOPEDIDOENVIADOTableAdapter uLTIMOPEDIDOENVIADOTableAdapter;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource lISTAPEDIDOSENVIADOSFECHABindingSource;
        private Importaciones.DSImportacionesTableAdapters.LISTAPEDIDOSENVIADOSFECHATableAdapter lISTAPEDIDOSENVIADOSFECHATableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_DOCTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_EXPFILEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOLIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAINI;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAFIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRECAJERO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTATUSPEDIDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewButtonColumn DG_REENVIAR;
    }
}