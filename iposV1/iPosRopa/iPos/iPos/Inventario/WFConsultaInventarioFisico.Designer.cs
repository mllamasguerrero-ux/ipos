namespace iPos
{
    partial class WFConsultaInventarioFisico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFConsultaInventarioFisico));
            this.CBMostrarSoloDif = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LBDateValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LBFolio = new System.Windows.Forms.Label();
            this.LBConsecutivo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.consultaInventarioDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consultaInventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSInventarioFisico = new iPos.Inventario.DSInventarioFisico();
            this.consultaInventarioTableAdapter = new iPos.Inventario.DSInventarioFisicoTableAdapters.ConsultaInventarioTableAdapter();
            this.tableAdapterManager = new iPos.Inventario.DSInventarioFisicoTableAdapters.TableAdapterManager();
            this.BTPrint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReporte = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CBImprimeDif = new System.Windows.Forms.CheckBox();
            this.dSInventarioFisico2 = new iPos.Inventario.DSInventarioFisico2();
            this.gET_INVFIS_FINEDICIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gET_INVFIS_FINEDICIONTableAdapter = new iPos.Inventario.DSInventarioFisico2TableAdapters.GET_INVFIS_FINEDICIONTableAdapter();
            this.tableAdapterManager1 = new iPos.Inventario.DSInventarioFisico2TableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gET_INVFIS_COMPLETOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gET_INVFIS_COMPLETOTableAdapter = new iPos.Inventario.DSInventarioFisico2TableAdapters.GET_INVFIS_COMPLETOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.consultaInventarioDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.consultaInventarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_INVFIS_FINEDICIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_INVFIS_COMPLETOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CBMostrarSoloDif
            // 
            this.CBMostrarSoloDif.AutoSize = true;
            this.CBMostrarSoloDif.BackColor = System.Drawing.Color.Transparent;
            this.CBMostrarSoloDif.Checked = true;
            this.CBMostrarSoloDif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBMostrarSoloDif.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBMostrarSoloDif.ForeColor = System.Drawing.Color.White;
            this.CBMostrarSoloDif.Location = new System.Drawing.Point(590, 41);
            this.CBMostrarSoloDif.Name = "CBMostrarSoloDif";
            this.CBMostrarSoloDif.Size = new System.Drawing.Size(181, 17);
            this.CBMostrarSoloDif.TabIndex = 50;
            this.CBMostrarSoloDif.Text = "Mostrar solo las diferencias";
            this.CBMostrarSoloDif.UseVisualStyleBackColor = false;
            this.CBMostrarSoloDif.CheckedChanged += new System.EventHandler(this.CBMostrarSoloDif_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Consulta de inventario fisico";
            // 
            // LBDateValue
            // 
            this.LBDateValue.AutoSize = true;
            this.LBDateValue.BackColor = System.Drawing.Color.Transparent;
            this.LBDateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBDateValue.ForeColor = System.Drawing.Color.White;
            this.LBDateValue.Location = new System.Drawing.Point(283, 41);
            this.LBDateValue.Name = "LBDateValue";
            this.LBDateValue.Size = new System.Drawing.Size(14, 13);
            this.LBDateValue.TabIndex = 48;
            this.LBDateValue.Text = "_";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(209, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Fecha Inicio:";
            // 
            // LBFolio
            // 
            this.LBFolio.AutoSize = true;
            this.LBFolio.BackColor = System.Drawing.Color.Transparent;
            this.LBFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBFolio.ForeColor = System.Drawing.Color.White;
            this.LBFolio.Location = new System.Drawing.Point(446, 41);
            this.LBFolio.Name = "LBFolio";
            this.LBFolio.Size = new System.Drawing.Size(14, 13);
            this.LBFolio.TabIndex = 46;
            this.LBFolio.Text = "_";
            // 
            // LBConsecutivo
            // 
            this.LBConsecutivo.AutoSize = true;
            this.LBConsecutivo.BackColor = System.Drawing.Color.Transparent;
            this.LBConsecutivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBConsecutivo.ForeColor = System.Drawing.Color.White;
            this.LBConsecutivo.Location = new System.Drawing.Point(92, 41);
            this.LBConsecutivo.Name = "LBConsecutivo";
            this.LBConsecutivo.Size = new System.Drawing.Size(14, 13);
            this.LBConsecutivo.TabIndex = 45;
            this.LBConsecutivo.Text = "_";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(398, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Folio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Consecutivo:";
            // 
            // consultaInventarioDataGridView
            // 
            this.consultaInventarioDataGridView.AllowUserToAddRows = false;
            this.consultaInventarioDataGridView.AutoGenerateColumns = false;
            this.consultaInventarioDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.consultaInventarioDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.consultaInventarioDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.consultaInventarioDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn9});
            this.consultaInventarioDataGridView.DataSource = this.consultaInventarioBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.consultaInventarioDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.consultaInventarioDataGridView.EnableHeadersVisualStyles = false;
            this.consultaInventarioDataGridView.Location = new System.Drawing.Point(15, 88);
            this.consultaInventarioDataGridView.Name = "consultaInventarioDataGridView";
            this.consultaInventarioDataGridView.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.consultaInventarioDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.consultaInventarioDataGridView.RowHeadersVisible = false;
            this.consultaInventarioDataGridView.Size = new System.Drawing.Size(756, 273);
            this.consultaInventarioDataGridView.TabIndex = 52;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PRODUCTONOMBRE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn7.HeaderText = "PRODUCTO";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PRODUCTODESCRIPCION";
            this.dataGridViewTextBoxColumn8.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CANTIDADTEORICA";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "CANT. TEORICA";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CANTIDADFISICA";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn5.HeaderText = "CANT. FISICA";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DIFERENCIA";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn6.HeaderText = "DIFERENCIA";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PRODUCTOLOTE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "LOTE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FECHAVENCE";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "VENCE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "MOVOTID";
            this.dataGridViewTextBoxColumn9.HeaderText = "MOVOTID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // consultaInventarioBindingSource
            // 
            this.consultaInventarioBindingSource.DataMember = "ConsultaInventario";
            this.consultaInventarioBindingSource.DataSource = this.dSInventarioFisico;
            // 
            // dSInventarioFisico
            // 
            this.dSInventarioFisico.DataSetName = "DSInventarioFisico";
            this.dSInventarioFisico.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // consultaInventarioTableAdapter
            // 
            this.consultaInventarioTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Inventario.DSInventarioFisicoTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // BTPrint
            // 
            this.BTPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTPrint.ForeColor = System.Drawing.Color.White;
            this.BTPrint.Location = new System.Drawing.Point(206, 9);
            this.BTPrint.Name = "BTPrint";
            this.BTPrint.Size = new System.Drawing.Size(75, 23);
            this.BTPrint.TabIndex = 53;
            this.BTPrint.Text = "Imprimir";
            this.BTPrint.UseVisualStyleBackColor = false;
            this.BTPrint.Click += new System.EventHandler(this.BTPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnReporte);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.CBImprimeDif);
            this.groupBox1.Controls.Add(this.BTPrint);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(178, 367);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 38);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impresión";
            // 
            // btnReporte
            // 
            this.btnReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.ForeColor = System.Drawing.Color.White;
            this.btnReporte.Location = new System.Drawing.Point(392, 9);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(75, 23);
            this.btnReporte.TabIndex = 56;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.UseVisualStyleBackColor = false;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(301, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 55;
            this.button1.Text = "Excel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CBImprimeDif
            // 
            this.CBImprimeDif.AutoSize = true;
            this.CBImprimeDif.Checked = true;
            this.CBImprimeDif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBImprimeDif.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBImprimeDif.ForeColor = System.Drawing.Color.White;
            this.CBImprimeDif.Location = new System.Drawing.Point(17, 13);
            this.CBImprimeDif.Name = "CBImprimeDif";
            this.CBImprimeDif.Size = new System.Drawing.Size(162, 17);
            this.CBImprimeDif.TabIndex = 54;
            this.CBImprimeDif.Text = "Imprimir solo diferencias";
            this.CBImprimeDif.UseVisualStyleBackColor = true;
            // 
            // dSInventarioFisico2
            // 
            this.dSInventarioFisico2.DataSetName = "DSInventarioFisico2";
            this.dSInventarioFisico2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gET_INVFIS_FINEDICIONBindingSource
            // 
            this.gET_INVFIS_FINEDICIONBindingSource.DataMember = "GET_INVFIS_FINEDICION";
            this.gET_INVFIS_FINEDICIONBindingSource.DataSource = this.dSInventarioFisico2;
            // 
            // gET_INVFIS_FINEDICIONTableAdapter
            // 
            this.gET_INVFIS_FINEDICIONTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = iPos.Inventario.DSInventarioFisico2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PRODUCTONOMBRE";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn1.HeaderText = "PRODUCTO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // gET_INVFIS_COMPLETOBindingSource
            // 
            this.gET_INVFIS_COMPLETOBindingSource.DataMember = "GET_INVFIS_COMPLETO";
            this.gET_INVFIS_COMPLETOBindingSource.DataSource = this.dSInventarioFisico2;
            // 
            // gET_INVFIS_COMPLETOTableAdapter
            // 
            this.gET_INVFIS_COMPLETOTableAdapter.ClearBeforeFill = true;
            // 
            // WFConsultaInventarioFisico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(824, 428);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.consultaInventarioDataGridView);
            this.Controls.Add(this.CBMostrarSoloDif);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LBDateValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LBFolio);
            this.Controls.Add(this.LBConsecutivo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFConsultaInventarioFisico";
            this.Text = "Inventario Fisico";
            this.Load += new System.EventHandler(this.WFConsultaInventarioFisico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.consultaInventarioDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.consultaInventarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_INVFIS_FINEDICIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_INVFIS_COMPLETOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CBMostrarSoloDif;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LBDateValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LBFolio;
        private System.Windows.Forms.Label LBConsecutivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private iPos.Inventario.DSInventarioFisico dSInventarioFisico;
        private System.Windows.Forms.BindingSource consultaInventarioBindingSource;
        private iPos.Inventario.DSInventarioFisicoTableAdapters.ConsultaInventarioTableAdapter consultaInventarioTableAdapter;
        private iPos.Inventario.DSInventarioFisicoTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum consultaInventarioDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button BTPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CBImprimeDif;
        private Inventario.DSInventarioFisico2 dSInventarioFisico2;
        private System.Windows.Forms.BindingSource gET_INVFIS_FINEDICIONBindingSource;
        private Inventario.DSInventarioFisico2TableAdapters.GET_INVFIS_FINEDICIONTableAdapter gET_INVFIS_FINEDICIONTableAdapter;
        private Inventario.DSInventarioFisico2TableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.BindingSource gET_INVFIS_COMPLETOBindingSource;
        private Inventario.DSInventarioFisico2TableAdapters.GET_INVFIS_COMPLETOTableAdapter gET_INVFIS_COMPLETOTableAdapter;
        private System.Windows.Forms.Button btnReporte;
    }
}