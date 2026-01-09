namespace iPos
{
    partial class WFEnsambleKit
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
            System.Windows.Forms.Label pRODUCTONOMBRELabel;
            System.Windows.Forms.Label pRODUCTODESCRIPCIONLabel;
            System.Windows.Forms.Label cANTIDADTEORICALabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pRODUCTONOMBRETextBox = new System.Windows.Forms.TextBox();
            this.pRODUCTODESCRIPCIONTextBox = new System.Windows.Forms.TextBox();
            this.cANTIDADTEORICATextBox = new System.Windows.Forms.TextBox();
            this.dSKits = new iPos.Kits.DSKits();
            this.kitDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kitDetalleTableAdapter = new iPos.Kits.DSKitsTableAdapters.KitDetalleTableAdapter();
            this.tableAdapterManager = new iPos.Kits.DSKitsTableAdapters.TableAdapterManager();
            this.kitDetalleDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.BTELIMINAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGPRODUCTOCLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCANTIDADFISICA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOVTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAbrirPendientes = new System.Windows.Forms.Button();
            this.LBConsecutivo = new System.Windows.Forms.Label();
            this.LBFolio = new System.Windows.Forms.Label();
            this.LBDateValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ALMACENFuenteComboBox = new System.Windows.Forms.ComboBoxFB();
            this.ALMACENDestinoComboBox = new System.Windows.Forms.ComboBoxFB();
            this.TBCantidad = new System.Windows.Forms.NumericTextBox();
            pRODUCTONOMBRELabel = new System.Windows.Forms.Label();
            pRODUCTODESCRIPCIONLabel = new System.Windows.Forms.Label();
            cANTIDADTEORICALabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSKits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitDetalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitDetalleDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pRODUCTONOMBRELabel
            // 
            pRODUCTONOMBRELabel.AutoSize = true;
            pRODUCTONOMBRELabel.BackColor = System.Drawing.Color.Transparent;
            pRODUCTONOMBRELabel.ForeColor = System.Drawing.Color.White;
            pRODUCTONOMBRELabel.Location = new System.Drawing.Point(22, 150);
            pRODUCTONOMBRELabel.Name = "pRODUCTONOMBRELabel";
            pRODUCTONOMBRELabel.Size = new System.Drawing.Size(91, 13);
            pRODUCTONOMBRELabel.TabIndex = 23;
            pRODUCTONOMBRELabel.Text = "Producto nombre:";
            // 
            // pRODUCTODESCRIPCIONLabel
            // 
            pRODUCTODESCRIPCIONLabel.AutoSize = true;
            pRODUCTODESCRIPCIONLabel.BackColor = System.Drawing.Color.Transparent;
            pRODUCTODESCRIPCIONLabel.ForeColor = System.Drawing.Color.White;
            pRODUCTODESCRIPCIONLabel.Location = new System.Drawing.Point(182, 152);
            pRODUCTODESCRIPCIONLabel.Name = "pRODUCTODESCRIPCIONLabel";
            pRODUCTODESCRIPCIONLabel.Size = new System.Drawing.Size(110, 13);
            pRODUCTODESCRIPCIONLabel.TabIndex = 25;
            pRODUCTODESCRIPCIONLabel.Text = "Producto descripcion:";
            // 
            // cANTIDADTEORICALabel
            // 
            cANTIDADTEORICALabel.AutoSize = true;
            cANTIDADTEORICALabel.BackColor = System.Drawing.Color.Transparent;
            cANTIDADTEORICALabel.ForeColor = System.Drawing.Color.White;
            cANTIDADTEORICALabel.Location = new System.Drawing.Point(546, 150);
            cANTIDADTEORICALabel.Name = "cANTIDADTEORICALabel";
            cANTIDADTEORICALabel.Size = new System.Drawing.Size(87, 13);
            cANTIDADTEORICALabel.TabIndex = 27;
            cANTIDADTEORICALabel.Text = "Cantidad teorica:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(22, 37);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(69, 13);
            label3.TabIndex = 32;
            label3.Text = "Consecutivo:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.ForeColor = System.Drawing.Color.White;
            label6.Location = new System.Drawing.Point(182, 34);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(32, 13);
            label6.TabIndex = 34;
            label6.Text = "Folio:";
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BtnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BtnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnviar.ForeColor = System.Drawing.Color.White;
            this.BtnEnviar.Location = new System.Drawing.Point(401, 128);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(96, 23);
            this.BtnEnviar.TabIndex = 8;
            this.BtnEnviar.Text = "Enviar";
            this.BtnEnviar.UseVisualStyleBackColor = false;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(182, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cantidad:";
            // 
            // TBCodigo
            // 
            this.TBCodigo.Location = new System.Drawing.Point(25, 126);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(116, 20);
            this.TBCodigo.TabIndex = 5;
            this.TBCodigo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBCodigo_PreviewKeyDown);
            this.TBCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.TBCodigo_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Codigo:";
            // 
            // pRODUCTONOMBRETextBox
            // 
            this.pRODUCTONOMBRETextBox.Location = new System.Drawing.Point(25, 166);
            this.pRODUCTONOMBRETextBox.Name = "pRODUCTONOMBRETextBox";
            this.pRODUCTONOMBRETextBox.ReadOnly = true;
            this.pRODUCTONOMBRETextBox.Size = new System.Drawing.Size(116, 20);
            this.pRODUCTONOMBRETextBox.TabIndex = 24;
            // 
            // pRODUCTODESCRIPCIONTextBox
            // 
            this.pRODUCTODESCRIPCIONTextBox.Location = new System.Drawing.Point(185, 166);
            this.pRODUCTODESCRIPCIONTextBox.Name = "pRODUCTODESCRIPCIONTextBox";
            this.pRODUCTODESCRIPCIONTextBox.ReadOnly = true;
            this.pRODUCTODESCRIPCIONTextBox.Size = new System.Drawing.Size(312, 20);
            this.pRODUCTODESCRIPCIONTextBox.TabIndex = 26;
            // 
            // cANTIDADTEORICATextBox
            // 
            this.cANTIDADTEORICATextBox.Location = new System.Drawing.Point(549, 166);
            this.cANTIDADTEORICATextBox.Name = "cANTIDADTEORICATextBox";
            this.cANTIDADTEORICATextBox.ReadOnly = true;
            this.cANTIDADTEORICATextBox.Size = new System.Drawing.Size(190, 20);
            this.cANTIDADTEORICATextBox.TabIndex = 28;
            // 
            // dSKits
            // 
            this.dSKits.DataSetName = "DSKits";
            this.dSKits.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kitDetalleBindingSource
            // 
            this.kitDetalleBindingSource.DataMember = "KitDetalle";
            this.kitDetalleBindingSource.DataSource = this.dSKits;
            // 
            // kitDetalleTableAdapter
            // 
            this.kitDetalleTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Kits.DSKitsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // kitDetalleDataGridView
            // 
            this.kitDetalleDataGridView.AllowUserToAddRows = false;
            this.kitDetalleDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.kitDetalleDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.kitDetalleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kitDetalleDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BTELIMINAR,
            this.DGPRODUCTOCLAVE,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.DGCANTIDADFISICA,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.MOVTOID});
            this.kitDetalleDataGridView.DataSource = this.kitDetalleBindingSource;
            this.kitDetalleDataGridView.Location = new System.Drawing.Point(12, 210);
            this.kitDetalleDataGridView.Name = "kitDetalleDataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.kitDetalleDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.kitDetalleDataGridView.RowHeadersVisible = false;
            this.kitDetalleDataGridView.Size = new System.Drawing.Size(744, 220);
            this.kitDetalleDataGridView.TabIndex = 30;
            this.kitDetalleDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kitDetalleDataGridView_CellContentClick);
            this.kitDetalleDataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.kitDetalleDataGridView_CellValidated);
            this.kitDetalleDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.kitDetalleDataGridView_CellValidating);
            // 
            // BTELIMINAR
            // 
            this.BTELIMINAR.HeaderText = "";
            this.BTELIMINAR.Name = "BTELIMINAR";
            this.BTELIMINAR.Text = "Eliminar";
            this.BTELIMINAR.UseColumnTextForButtonValue = true;
            // 
            // DGPRODUCTOCLAVE
            // 
            this.DGPRODUCTOCLAVE.DataPropertyName = "CLAVE";
            this.DGPRODUCTOCLAVE.HeaderText = "CLAVE";
            this.DGPRODUCTOCLAVE.Name = "DGPRODUCTOCLAVE";
            this.DGPRODUCTOCLAVE.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn8.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DESCRIPCION";
            this.dataGridViewTextBoxColumn9.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn10.HeaderText = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 150;
            // 
            // DGCANTIDADFISICA
            // 
            this.DGCANTIDADFISICA.DataPropertyName = "CANTIDAD";
            this.DGCANTIDADFISICA.HeaderText = "CANTIDAD";
            this.DGCANTIDADFISICA.Name = "DGCANTIDADFISICA";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DOCTOID";
            this.dataGridViewTextBoxColumn1.HeaderText = "DOCTOID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "COSTO";
            this.dataGridViewTextBoxColumn6.HeaderText = "COSTO";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PARTIDA";
            this.dataGridViewTextBoxColumn3.HeaderText = "PARTIDA";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PRODUCTOID";
            this.dataGridViewTextBoxColumn4.HeaderText = "PRODUCTOID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // MOVTOID
            // 
            this.MOVTOID.DataPropertyName = "MOVTOID";
            this.MOVTOID.HeaderText = "MOVTOID";
            this.MOVTOID.Name = "MOVTOID";
            this.MOVTOID.ReadOnly = true;
            this.MOVTOID.Visible = false;
            // 
            // btnAbrirPendientes
            // 
            this.btnAbrirPendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnAbrirPendientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAbrirPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirPendientes.ForeColor = System.Drawing.Color.White;
            this.btnAbrirPendientes.Location = new System.Drawing.Point(599, 69);
            this.btnAbrirPendientes.Name = "btnAbrirPendientes";
            this.btnAbrirPendientes.Size = new System.Drawing.Size(140, 23);
            this.btnAbrirPendientes.TabIndex = 31;
            this.btnAbrirPendientes.Text = "Abrir";
            this.btnAbrirPendientes.UseVisualStyleBackColor = false;
            this.btnAbrirPendientes.Click += new System.EventHandler(this.btnAbrirPendientes_Click);
            // 
            // LBConsecutivo
            // 
            this.LBConsecutivo.AutoSize = true;
            this.LBConsecutivo.BackColor = System.Drawing.Color.Transparent;
            this.LBConsecutivo.ForeColor = System.Drawing.Color.White;
            this.LBConsecutivo.Location = new System.Drawing.Point(112, 34);
            this.LBConsecutivo.Name = "LBConsecutivo";
            this.LBConsecutivo.Size = new System.Drawing.Size(13, 13);
            this.LBConsecutivo.TabIndex = 33;
            this.LBConsecutivo.Text = "_";
            // 
            // LBFolio
            // 
            this.LBFolio.AutoSize = true;
            this.LBFolio.BackColor = System.Drawing.Color.Transparent;
            this.LBFolio.ForeColor = System.Drawing.Color.White;
            this.LBFolio.Location = new System.Drawing.Point(220, 34);
            this.LBFolio.Name = "LBFolio";
            this.LBFolio.Size = new System.Drawing.Size(13, 13);
            this.LBFolio.TabIndex = 35;
            this.LBFolio.Text = "_";
            // 
            // LBDateValue
            // 
            this.LBDateValue.AutoSize = true;
            this.LBDateValue.BackColor = System.Drawing.Color.Transparent;
            this.LBDateValue.ForeColor = System.Drawing.Color.White;
            this.LBDateValue.Location = new System.Drawing.Point(397, 37);
            this.LBDateValue.Name = "LBDateValue";
            this.LBDateValue.Size = new System.Drawing.Size(13, 13);
            this.LBDateValue.TabIndex = 37;
            this.LBDateValue.Text = "_";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(348, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Fecha :";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(168, 436);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 23);
            this.btnCancelar.TabIndex = 38;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(546, 436);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(87, 23);
            this.btnGuardar.TabIndex = 39;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(22, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "ENSAMBLE";
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.lblAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacen.ForeColor = System.Drawing.Color.White;
            this.lblAlmacen.Location = new System.Drawing.Point(22, 74);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(81, 13);
            this.lblAlmacen.TabIndex = 175;
            this.lblAlmacen.Text = "Ald. Destino kit:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(348, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 177;
            this.label7.Text = "Alm. Fuente partes:";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MOVTOID";
            this.dataGridViewTextBoxColumn2.HeaderText = "MOVTOID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CANTIDAD";
            this.dataGridViewTextBoxColumn5.HeaderText = "CANTIDAD";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn7.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "Eliminar";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // ALMACENFuenteComboBox
            // 
            this.ALMACENFuenteComboBox.Condicion = null;
            this.ALMACENFuenteComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENFuenteComboBox.DisplayMember = "nombre";
            this.ALMACENFuenteComboBox.FormattingEnabled = true;
            this.ALMACENFuenteComboBox.IndiceCampoSelector = 0;
            this.ALMACENFuenteComboBox.LabelDescription = null;
            this.ALMACENFuenteComboBox.Location = new System.Drawing.Point(452, 71);
            this.ALMACENFuenteComboBox.Name = "ALMACENFuenteComboBox";
            this.ALMACENFuenteComboBox.NombreCampoSelector = "id";
            this.ALMACENFuenteComboBox.Query = "select id,nombre from almacen";
            this.ALMACENFuenteComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENFuenteComboBox.SelectedDataDisplaying = null;
            this.ALMACENFuenteComboBox.SelectedDataValue = null;
            this.ALMACENFuenteComboBox.Size = new System.Drawing.Size(110, 21);
            this.ALMACENFuenteComboBox.TabIndex = 178;
            this.ALMACENFuenteComboBox.ValueMember = "id";
            // 
            // ALMACENDestinoComboBox
            // 
            this.ALMACENDestinoComboBox.Condicion = null;
            this.ALMACENDestinoComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENDestinoComboBox.DisplayMember = "nombre";
            this.ALMACENDestinoComboBox.FormattingEnabled = true;
            this.ALMACENDestinoComboBox.IndiceCampoSelector = 0;
            this.ALMACENDestinoComboBox.LabelDescription = null;
            this.ALMACENDestinoComboBox.Location = new System.Drawing.Point(109, 71);
            this.ALMACENDestinoComboBox.Name = "ALMACENDestinoComboBox";
            this.ALMACENDestinoComboBox.NombreCampoSelector = "id";
            this.ALMACENDestinoComboBox.Query = "select id,nombre from almacen";
            this.ALMACENDestinoComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENDestinoComboBox.SelectedDataDisplaying = null;
            this.ALMACENDestinoComboBox.SelectedDataValue = null;
            this.ALMACENDestinoComboBox.Size = new System.Drawing.Size(114, 21);
            this.ALMACENDestinoComboBox.TabIndex = 176;
            this.ALMACENDestinoComboBox.ValueMember = "id";
            // 
            // TBCantidad
            // 
            this.TBCantidad.AllowNegative = true;
            this.TBCantidad.Format_Expression = null;
            this.TBCantidad.Location = new System.Drawing.Point(185, 128);
            this.TBCantidad.Name = "TBCantidad";
            this.TBCantidad.NumericPrecision = 12;
            this.TBCantidad.NumericScaleOnFocus = 0;
            this.TBCantidad.NumericScaleOnLostFocus = 0;
            this.TBCantidad.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBCantidad.Size = new System.Drawing.Size(116, 20);
            this.TBCantidad.TabIndex = 6;
            this.TBCantidad.Tag = 34;
            this.TBCantidad.Text = "0";
            this.TBCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBCantidad.ValidationExpression = null;
            this.TBCantidad.ZeroIsValid = true;
            // 
            // WFEnsambleKit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(768, 472);
            this.Controls.Add(this.ALMACENFuenteComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ALMACENDestinoComboBox);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.LBDateValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LBFolio);
            this.Controls.Add(label6);
            this.Controls.Add(this.LBConsecutivo);
            this.Controls.Add(label3);
            this.Controls.Add(this.btnAbrirPendientes);
            this.Controls.Add(this.kitDetalleDataGridView);
            this.Controls.Add(pRODUCTONOMBRELabel);
            this.Controls.Add(this.pRODUCTONOMBRETextBox);
            this.Controls.Add(pRODUCTODESCRIPCIONLabel);
            this.Controls.Add(this.pRODUCTODESCRIPCIONTextBox);
            this.Controls.Add(cANTIDADTEORICALabel);
            this.Controls.Add(this.cANTIDADTEORICATextBox);
            this.Controls.Add(this.TBCantidad);
            this.Controls.Add(this.BtnEnviar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBCodigo);
            this.Controls.Add(this.label1);
            this.Name = "WFEnsambleKit";
            this.Text = "WFEnsambleKit";
            this.Load += new System.EventHandler(this.WFEnsambleKit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSKits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitDetalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitDetalleDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericTextBox TBCantidad;
        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pRODUCTONOMBRETextBox;
        private System.Windows.Forms.TextBox pRODUCTODESCRIPCIONTextBox;
        private System.Windows.Forms.TextBox cANTIDADTEORICATextBox;
        private Kits.DSKits dSKits;
        private System.Windows.Forms.BindingSource kitDetalleBindingSource;
        private Kits.DSKitsTableAdapters.KitDetalleTableAdapter kitDetalleTableAdapter;
        private Kits.DSKitsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum kitDetalleDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Button btnAbrirPendientes;
        private System.Windows.Forms.Label LBDateValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LBConsecutivo;
        private System.Windows.Forms.Label LBFolio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBoxFB ALMACENDestinoComboBox;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.ComboBoxFB ALMACENFuenteComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn BTELIMINAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPRODUCTOCLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCANTIDADFISICA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOVTOID;
    }
}