namespace iPos.Cobranza
{
    partial class WFBitacoraCobranzaList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFBitacoraCobranzaList));
            this.bITACOBRANZADataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCOBRADORID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COBRADORNOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTADONOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVER = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGEDITAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGCancelar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGREGISTRARPAGOS = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGImprimir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bITACOBRANZABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCobranza = new iPos.Cobranza.DSCobranza();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgregarBitacora = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bITACOBRANZATableAdapter = new iPos.Cobranza.DSCobranzaTableAdapters.BITACOBRANZATableAdapter();
            this.tableAdapterManager = new iPos.Cobranza.DSCobranzaTableAdapters.TableAdapterManager();
            this.CBSoloPendientes = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bITACOBRANZADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bITACOBRANZABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCobranza)).BeginInit();
            this.SuspendLayout();
            // 
            // bITACOBRANZADataGridView
            // 
            this.bITACOBRANZADataGridView.AllowUserToAddRows = false;
            this.bITACOBRANZADataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bITACOBRANZADataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.bITACOBRANZADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bITACOBRANZADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.DGCOBRADORID,
            this.DGFECHA,
            this.COBRADORNOMBRE,
            this.dataGridViewTextBoxColumn10,
            this.ESTADONOMBRE,
            this.DGVER,
            this.DGEDITAR,
            this.DGCancelar,
            this.DGREGISTRARPAGOS,
            this.DGImprimir});
            this.bITACOBRANZADataGridView.DataSource = this.bITACOBRANZABindingSource;
            this.bITACOBRANZADataGridView.Location = new System.Drawing.Point(12, 49);
            this.bITACOBRANZADataGridView.Name = "bITACOBRANZADataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bITACOBRANZADataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bITACOBRANZADataGridView.RowHeadersVisible = false;
            this.bITACOBRANZADataGridView.Size = new System.Drawing.Size(818, 276);
            this.bITACOBRANZADataGridView.TabIndex = 2;
            this.bITACOBRANZADataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bITACOBRANZADataGridView_CellContentClick);
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            this.DGID.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ACTIVO";
            this.dataGridViewTextBoxColumn2.HeaderText = "ACTIVO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CREADO";
            this.dataGridViewTextBoxColumn3.HeaderText = "CREADO";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CREADOPOR_USERID";
            this.dataGridViewTextBoxColumn4.HeaderText = "CREADOPOR_USERID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MODIFICADO";
            this.dataGridViewTextBoxColumn5.HeaderText = "MODIFICADO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MODIFICADOPOR_USERID";
            this.dataGridViewTextBoxColumn6.HeaderText = "MODIFICADOPOR_USERID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // DGCOBRADORID
            // 
            this.DGCOBRADORID.DataPropertyName = "COBRADORID";
            this.DGCOBRADORID.HeaderText = "COBRADORID";
            this.DGCOBRADORID.Name = "DGCOBRADORID";
            this.DGCOBRADORID.ReadOnly = true;
            this.DGCOBRADORID.Visible = false;
            this.DGCOBRADORID.Width = 200;
            // 
            // DGFECHA
            // 
            this.DGFECHA.DataPropertyName = "FECHA";
            this.DGFECHA.HeaderText = "FECHA";
            this.DGFECHA.Name = "DGFECHA";
            this.DGFECHA.Width = 80;
            // 
            // COBRADORNOMBRE
            // 
            this.COBRADORNOMBRE.DataPropertyName = "COBRADORNOMBRE";
            this.COBRADORNOMBRE.HeaderText = "COBRADOR";
            this.COBRADORNOMBRE.Name = "COBRADORNOMBRE";
            this.COBRADORNOMBRE.ReadOnly = true;
            this.COBRADORNOMBRE.Width = 180;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TOTALABONADO";
            this.dataGridViewTextBoxColumn10.HeaderText = "TOTAL ABONADO";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 120;
            // 
            // ESTADONOMBRE
            // 
            this.ESTADONOMBRE.DataPropertyName = "ESTADONOMBRE";
            this.ESTADONOMBRE.HeaderText = "ESTADO";
            this.ESTADONOMBRE.Name = "ESTADONOMBRE";
            this.ESTADONOMBRE.ReadOnly = true;
            this.ESTADONOMBRE.Width = 125;
            // 
            // DGVER
            // 
            this.DGVER.HeaderText = "Ver";
            this.DGVER.Name = "DGVER";
            this.DGVER.Text = "VER";
            this.DGVER.UseColumnTextForButtonValue = true;
            this.DGVER.Width = 55;
            // 
            // DGEDITAR
            // 
            this.DGEDITAR.HeaderText = "Editar";
            this.DGEDITAR.Name = "DGEDITAR";
            this.DGEDITAR.Text = "EDITAR";
            this.DGEDITAR.UseColumnTextForButtonValue = true;
            this.DGEDITAR.Width = 55;
            // 
            // DGCancelar
            // 
            this.DGCancelar.HeaderText = "Cancelar";
            this.DGCancelar.Name = "DGCancelar";
            this.DGCancelar.Text = "CANCELAR";
            this.DGCancelar.UseColumnTextForButtonValue = true;
            this.DGCancelar.Width = 70;
            // 
            // DGREGISTRARPAGOS
            // 
            this.DGREGISTRARPAGOS.HeaderText = "Recibir";
            this.DGREGISTRARPAGOS.Name = "DGREGISTRARPAGOS";
            this.DGREGISTRARPAGOS.Text = "RECIBIR";
            this.DGREGISTRARPAGOS.UseColumnTextForButtonValue = true;
            this.DGREGISTRARPAGOS.Width = 60;
            // 
            // DGImprimir
            // 
            this.DGImprimir.HeaderText = "Imprimir";
            this.DGImprimir.Name = "DGImprimir";
            this.DGImprimir.Text = "Imprimir";
            this.DGImprimir.UseColumnTextForButtonValue = true;
            this.DGImprimir.Width = 60;
            // 
            // bITACOBRANZABindingSource
            // 
            this.bITACOBRANZABindingSource.DataMember = "BITACOBRANZA";
            this.bITACOBRANZABindingSource.DataSource = this.dSCobranza;
            // 
            // dSCobranza
            // 
            this.dSCobranza.DataSetName = "DSCobranza";
            this.dSCobranza.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Location = new System.Drawing.Point(84, 10);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicial.TabIndex = 3;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Location = new System.Drawing.Point(355, 10);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFinal.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fecha inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(291, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha final";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(674, 9);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgregarBitacora
            // 
            this.btnAgregarBitacora.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnAgregarBitacora.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAgregarBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarBitacora.ForeColor = System.Drawing.Color.White;
            this.btnAgregarBitacora.Location = new System.Drawing.Point(755, 3);
            this.btnAgregarBitacora.Name = "btnAgregarBitacora";
            this.btnAgregarBitacora.Size = new System.Drawing.Size(75, 40);
            this.btnAgregarBitacora.TabIndex = 8;
            this.btnAgregarBitacora.Text = "Agregar bitacora";
            this.btnAgregarBitacora.UseVisualStyleBackColor = false;
            this.btnAgregarBitacora.Click += new System.EventHandler(this.btnAgregarBitacora_Click);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn7.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "TOTALABONADO";
            this.dataGridViewTextBoxColumn11.HeaderText = "TOTAL ABONADO";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 120;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Ver";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "VER";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 60;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "Editar";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "EDITAR";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Width = 60;
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.HeaderText = "Recibir";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.Text = "RECIBIR";
            this.dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn3.Width = 60;
            // 
            // bITACOBRANZATableAdapter
            // 
            this.bITACOBRANZATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Cobranza.DSCobranzaTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // CBSoloPendientes
            // 
            this.CBSoloPendientes.AutoSize = true;
            this.CBSoloPendientes.BackColor = System.Drawing.Color.Transparent;
            this.CBSoloPendientes.Checked = true;
            this.CBSoloPendientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBSoloPendientes.ForeColor = System.Drawing.Color.White;
            this.CBSoloPendientes.Location = new System.Drawing.Point(566, 13);
            this.CBSoloPendientes.Name = "CBSoloPendientes";
            this.CBSoloPendientes.Size = new System.Drawing.Size(102, 17);
            this.CBSoloPendientes.TabIndex = 9;
            this.CBSoloPendientes.Text = "Solo pendientes";
            this.CBSoloPendientes.UseVisualStyleBackColor = false;
            // 
            // WFBitacoraCobranzaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(842, 368);
            this.Controls.Add(this.CBSoloPendientes);
            this.Controls.Add(this.btnAgregarBitacora);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.bITACOBRANZADataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFBitacoraCobranzaList";
            this.Text = "Bitacoras de cobraza";
            this.Load += new System.EventHandler(this.WFBitacoraCobranzaList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bITACOBRANZADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bITACOBRANZABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCobranza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSCobranza dSCobranza;
        private System.Windows.Forms.BindingSource bITACOBRANZABindingSource;
        private DSCobranzaTableAdapters.BITACOBRANZATableAdapter bITACOBRANZATableAdapter;
        private DSCobranzaTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum bITACOBRANZADataGridView;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgregarBitacora;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private System.Windows.Forms.CheckBox CBSoloPendientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCOBRADORID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COBRADORNOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTADONOMBRE;
        private System.Windows.Forms.DataGridViewButtonColumn DGVER;
        private System.Windows.Forms.DataGridViewButtonColumn DGEDITAR;
        private System.Windows.Forms.DataGridViewButtonColumn DGCancelar;
        private System.Windows.Forms.DataGridViewButtonColumn DGREGISTRARPAGOS;
        private System.Windows.Forms.DataGridViewButtonColumn DGImprimir;
    }
}