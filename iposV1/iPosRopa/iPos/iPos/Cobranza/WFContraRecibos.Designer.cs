namespace iPos
{
    partial class WFContraRecibos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFContraRecibos));
            this.lblPersona = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.lbClieCP = new System.Windows.Forms.Label();
            this.lbClieTel = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lbClieCiudad = new System.Windows.Forms.Label();
            this.lbClieEstado = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbClieDom = new System.Windows.Forms.Label();
            this.lbClieColonia = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbClieNombre = new System.Windows.Forms.Label();
            this.lbClieRFC = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.BTCliente = new System.Windows.Forms.Button();
            this.LBCliente = new System.Windows.Forms.Label();
            this.BtnListaTransacciones = new System.Windows.Forms.Button();
            this.TBNota = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dSCobranza = new iPos.Cobranza.DSCobranza();
            this.cONTRARECIBODTLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cONTRARECIBODTLTableAdapter = new iPos.Cobranza.DSCobranzaTableAdapters.CONTRARECIBODTLTableAdapter();
            this.tableAdapterManager = new iPos.Cobranza.DSCobranzaTableAdapters.TableAdapterManager();
            this.cONTRARECIBODTLDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGELIMINAR = new System.Windows.Forms.DataGridViewImageColumn();
            this.BTGUARDAR = new System.Windows.Forms.Button();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LBTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBTransacccion = new System.Windows.Forms.TextBox();
            this.ESTATUSPAGOIDTextBox = new System.Windows.Forms.ComboBoxFB();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCambiarEstatusPago = new System.Windows.Forms.Button();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSCobranza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cONTRARECIBODTLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cONTRARECIBODTLDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPersona
            // 
            this.lblPersona.AutoSize = true;
            this.lblPersona.BackColor = System.Drawing.Color.Transparent;
            this.lblPersona.ForeColor = System.Drawing.Color.White;
            this.lblPersona.Location = new System.Drawing.Point(16, 38);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(42, 13);
            this.lblPersona.TabIndex = 62;
            this.lblPersona.Text = "Cliente:";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.label26);
            this.panel11.Controls.Add(this.lbClieCP);
            this.panel11.Controls.Add(this.lbClieTel);
            this.panel11.Controls.Add(this.label29);
            this.panel11.Controls.Add(this.label22);
            this.panel11.Controls.Add(this.lbClieCiudad);
            this.panel11.Controls.Add(this.lbClieEstado);
            this.panel11.Controls.Add(this.label25);
            this.panel11.Controls.Add(this.label18);
            this.panel11.Controls.Add(this.lbClieDom);
            this.panel11.Controls.Add(this.lbClieColonia);
            this.panel11.Controls.Add(this.label21);
            this.panel11.Controls.Add(this.label4);
            this.panel11.Controls.Add(this.lbClieNombre);
            this.panel11.Controls.Add(this.lbClieRFC);
            this.panel11.Controls.Add(this.label17);
            this.panel11.Location = new System.Drawing.Point(12, 99);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1001, 38);
            this.panel11.TabIndex = 61;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(781, 2);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(27, 13);
            this.label26.TabIndex = 41;
            this.label26.Text = "CP:";
            // 
            // lbClieCP
            // 
            this.lbClieCP.AutoSize = true;
            this.lbClieCP.BackColor = System.Drawing.Color.Transparent;
            this.lbClieCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieCP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieCP.Location = new System.Drawing.Point(838, 2);
            this.lbClieCP.Name = "lbClieCP";
            this.lbClieCP.Size = new System.Drawing.Size(19, 13);
            this.lbClieCP.TabIndex = 42;
            this.lbClieCP.Text = "...";
            // 
            // lbClieTel
            // 
            this.lbClieTel.AutoSize = true;
            this.lbClieTel.BackColor = System.Drawing.Color.Transparent;
            this.lbClieTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieTel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieTel.Location = new System.Drawing.Point(838, 21);
            this.lbClieTel.Name = "lbClieTel";
            this.lbClieTel.Size = new System.Drawing.Size(19, 13);
            this.lbClieTel.TabIndex = 43;
            this.lbClieTel.Text = "...";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(778, 21);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(33, 13);
            this.label29.TabIndex = 44;
            this.label29.Text = "Tel.:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(529, 2);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(50, 13);
            this.label22.TabIndex = 37;
            this.label22.Text = "Ciudad:";
            // 
            // lbClieCiudad
            // 
            this.lbClieCiudad.AutoSize = true;
            this.lbClieCiudad.BackColor = System.Drawing.Color.Transparent;
            this.lbClieCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieCiudad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieCiudad.Location = new System.Drawing.Point(590, 2);
            this.lbClieCiudad.Name = "lbClieCiudad";
            this.lbClieCiudad.Size = new System.Drawing.Size(19, 13);
            this.lbClieCiudad.TabIndex = 38;
            this.lbClieCiudad.Text = "...";
            // 
            // lbClieEstado
            // 
            this.lbClieEstado.AutoSize = true;
            this.lbClieEstado.BackColor = System.Drawing.Color.Transparent;
            this.lbClieEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieEstado.Location = new System.Drawing.Point(590, 21);
            this.lbClieEstado.Name = "lbClieEstado";
            this.lbClieEstado.Size = new System.Drawing.Size(19, 13);
            this.lbClieEstado.TabIndex = 39;
            this.lbClieEstado.Text = "...";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(529, 21);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(50, 13);
            this.label25.TabIndex = 40;
            this.label25.Text = "Estado:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(263, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "Domicilio:";
            // 
            // lbClieDom
            // 
            this.lbClieDom.AutoSize = true;
            this.lbClieDom.BackColor = System.Drawing.Color.Transparent;
            this.lbClieDom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieDom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieDom.Location = new System.Drawing.Point(324, 2);
            this.lbClieDom.Name = "lbClieDom";
            this.lbClieDom.Size = new System.Drawing.Size(19, 13);
            this.lbClieDom.TabIndex = 34;
            this.lbClieDom.Text = "...";
            // 
            // lbClieColonia
            // 
            this.lbClieColonia.AutoSize = true;
            this.lbClieColonia.BackColor = System.Drawing.Color.Transparent;
            this.lbClieColonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieColonia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieColonia.Location = new System.Drawing.Point(324, 21);
            this.lbClieColonia.Name = "lbClieColonia";
            this.lbClieColonia.Size = new System.Drawing.Size(19, 13);
            this.lbClieColonia.TabIndex = 35;
            this.lbClieColonia.Text = "...";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(264, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 36;
            this.label21.Text = "Colonia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Nombre:";
            // 
            // lbClieNombre
            // 
            this.lbClieNombre.AutoSize = true;
            this.lbClieNombre.BackColor = System.Drawing.Color.Transparent;
            this.lbClieNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieNombre.Location = new System.Drawing.Point(63, 2);
            this.lbClieNombre.Name = "lbClieNombre";
            this.lbClieNombre.Size = new System.Drawing.Size(19, 13);
            this.lbClieNombre.TabIndex = 20;
            this.lbClieNombre.Text = "...";
            // 
            // lbClieRFC
            // 
            this.lbClieRFC.AutoSize = true;
            this.lbClieRFC.BackColor = System.Drawing.Color.Transparent;
            this.lbClieRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieRFC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieRFC.Location = new System.Drawing.Point(63, 21);
            this.lbClieRFC.Name = "lbClieRFC";
            this.lbClieRFC.Size = new System.Drawing.Size(19, 13);
            this.lbClieRFC.TabIndex = 28;
            this.lbClieRFC.Text = "...";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(5, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "RFC:";
            // 
            // BTCliente
            // 
            this.BTCliente.BackColor = System.Drawing.Color.Transparent;
            this.BTCliente.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.BTCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCliente.Location = new System.Drawing.Point(69, 30);
            this.BTCliente.Name = "BTCliente";
            this.BTCliente.Size = new System.Drawing.Size(27, 24);
            this.BTCliente.TabIndex = 60;
            this.BTCliente.Text = "...";
            this.BTCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCliente.UseVisualStyleBackColor = false;
            this.BTCliente.Click += new System.EventHandler(this.BTCliente_Click);
            // 
            // LBCliente
            // 
            this.LBCliente.AutoSize = true;
            this.LBCliente.BackColor = System.Drawing.Color.Transparent;
            this.LBCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCliente.ForeColor = System.Drawing.Color.White;
            this.LBCliente.Location = new System.Drawing.Point(110, 39);
            this.LBCliente.Name = "LBCliente";
            this.LBCliente.Size = new System.Drawing.Size(19, 13);
            this.LBCliente.TabIndex = 59;
            this.LBCliente.Text = "...";
            // 
            // BtnListaTransacciones
            // 
            this.BtnListaTransacciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BtnListaTransacciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BtnListaTransacciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnListaTransacciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.BtnListaTransacciones.ForeColor = System.Drawing.Color.White;
            this.BtnListaTransacciones.Location = new System.Drawing.Point(438, 27);
            this.BtnListaTransacciones.Name = "BtnListaTransacciones";
            this.BtnListaTransacciones.Size = new System.Drawing.Size(206, 27);
            this.BtnListaTransacciones.TabIndex = 63;
            this.BtnListaTransacciones.Text = "Seleccionar transacciones";
            this.BtnListaTransacciones.UseVisualStyleBackColor = false;
            this.BtnListaTransacciones.Click += new System.EventHandler(this.BtnListaTransacciones_Click);
            // 
            // TBNota
            // 
            this.TBNota.Location = new System.Drawing.Point(69, 66);
            this.TBNota.Name = "TBNota";
            this.TBNota.Size = new System.Drawing.Size(218, 20);
            this.TBNota.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Nota:";
            // 
            // dSCobranza
            // 
            this.dSCobranza.DataSetName = "DSCobranza";
            this.dSCobranza.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cONTRARECIBODTLBindingSource
            // 
            this.cONTRARECIBODTLBindingSource.DataMember = "CONTRARECIBODTL";
            this.cONTRARECIBODTLBindingSource.DataSource = this.dSCobranza;
            // 
            // cONTRARECIBODTLTableAdapter
            // 
            this.cONTRARECIBODTLTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Cobranza.DSCobranzaTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cONTRARECIBODTLDataGridView
            // 
            this.cONTRARECIBODTLDataGridView.AllowUserToAddRows = false;
            this.cONTRARECIBODTLDataGridView.AutoGenerateColumns = false;
            this.cONTRARECIBODTLDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cONTRARECIBODTLDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.DGELIMINAR});
            this.cONTRARECIBODTLDataGridView.DataSource = this.cONTRARECIBODTLBindingSource;
            this.cONTRARECIBODTLDataGridView.Location = new System.Drawing.Point(12, 153);
            this.cONTRARECIBODTLDataGridView.Name = "cONTRARECIBODTLDataGridView";
            this.cONTRARECIBODTLDataGridView.RowHeadersVisible = false;
            this.cONTRARECIBODTLDataGridView.Size = new System.Drawing.Size(1001, 220);
            this.cONTRARECIBODTLDataGridView.TabIndex = 67;
            this.cONTRARECIBODTLDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cONTRARECIBODTLDataGridView_CellContentClick);
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
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CONTRARECIBOID";
            this.dataGridViewTextBoxColumn7.HeaderText = "CONTRARECIBOID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DOCTOID";
            this.dataGridViewTextBoxColumn8.HeaderText = "DOCTOID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn9.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "FECHAVENCE";
            this.dataGridViewTextBoxColumn10.HeaderText = "FECHAVENCE";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "FOLIO";
            this.dataGridViewTextBoxColumn11.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "SERIE";
            this.dataGridViewTextBoxColumn12.HeaderText = "SERIE";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "FOLIOSAT";
            this.dataGridViewTextBoxColumn13.HeaderText = "FOLIOSAT";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "SERIESAT";
            this.dataGridViewTextBoxColumn14.HeaderText = "SERIESAT";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "ESTATUSID";
            this.dataGridViewTextBoxColumn15.HeaderText = "ESTATUSID";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "TOTALDOCTO";
            this.dataGridViewTextBoxColumn16.HeaderText = "TOTAL VENTA";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "ABONODOCTO";
            this.dataGridViewTextBoxColumn17.HeaderText = "ABONODOCTO";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "SALDODOCTO";
            this.dataGridViewTextBoxColumn18.HeaderText = "SALDO VENTA";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "TOTAL";
            this.dataGridViewTextBoxColumn19.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Visible = false;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "ABONO";
            this.dataGridViewTextBoxColumn20.HeaderText = "ABONO";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Visible = false;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "SALDO";
            this.dataGridViewTextBoxColumn21.HeaderText = "SALDO";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.Visible = false;
            // 
            // DGELIMINAR
            // 
            this.DGELIMINAR.HeaderText = "";
            this.DGELIMINAR.Image = global::iPos.Properties.Resources.close_J;
            this.DGELIMINAR.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.DGELIMINAR.Name = "DGELIMINAR";
            this.DGELIMINAR.Width = 30;
            // 
            // BTGUARDAR
            // 
            this.BTGUARDAR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTGUARDAR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTGUARDAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTGUARDAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.BTGUARDAR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTGUARDAR.Location = new System.Drawing.Point(795, 456);
            this.BTGUARDAR.Name = "BTGUARDAR";
            this.BTGUARDAR.Size = new System.Drawing.Size(126, 37);
            this.BTGUARDAR.TabIndex = 68;
            this.BTGUARDAR.Text = "Registrar";
            this.BTGUARDAR.UseVisualStyleBackColor = false;
            this.BTGUARDAR.Click += new System.EventHandler(this.BTGUARDAR_Click);
            // 
            // BTCancelar
            // 
            this.BTCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.BTCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.BTCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTCancelar.Location = new System.Drawing.Point(22, 456);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(126, 37);
            this.BTCancelar.TabIndex = 69;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Gray;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnImprimir.Location = new System.Drawing.Point(620, 456);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(126, 37);
            this.btnImprimir.TabIndex = 70;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(683, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 71;
            this.label2.Text = "Total";
            // 
            // LBTotal
            // 
            this.LBTotal.AutoSize = true;
            this.LBTotal.BackColor = System.Drawing.Color.Transparent;
            this.LBTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTotal.ForeColor = System.Drawing.Color.White;
            this.LBTotal.Location = new System.Drawing.Point(735, 390);
            this.LBTotal.Name = "LBTotal";
            this.LBTotal.Size = new System.Drawing.Size(21, 20);
            this.LBTotal.TabIndex = 72;
            this.LBTotal.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(684, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 87;
            this.label3.Text = "Seleccione folios del cliente:";
            // 
            // TBTransacccion
            // 
            this.TBTransacccion.Location = new System.Drawing.Point(864, 32);
            this.TBTransacccion.Name = "TBTransacccion";
            this.TBTransacccion.Size = new System.Drawing.Size(103, 20);
            this.TBTransacccion.TabIndex = 86;
            this.TBTransacccion.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBTransacccion_PreviewKeyDown);
            this.TBTransacccion.Validating += new System.ComponentModel.CancelEventHandler(this.TBTransacccion_Validating);
            this.TBTransacccion.Validated += new System.EventHandler(this.TBTransacccion_Validated);
            // 
            // ESTATUSPAGOIDTextBox
            // 
            this.ESTATUSPAGOIDTextBox.Condicion = null;
            this.ESTATUSPAGOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ESTATUSPAGOIDTextBox.DisplayMember = "nombre";
            this.ESTATUSPAGOIDTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ESTATUSPAGOIDTextBox.FormattingEnabled = true;
            this.ESTATUSPAGOIDTextBox.IndiceCampoSelector = 0;
            this.ESTATUSPAGOIDTextBox.LabelDescription = null;
            this.ESTATUSPAGOIDTextBox.Location = new System.Drawing.Point(459, 66);
            this.ESTATUSPAGOIDTextBox.Name = "ESTATUSPAGOIDTextBox";
            this.ESTATUSPAGOIDTextBox.NombreCampoSelector = "id";
            this.ESTATUSPAGOIDTextBox.Query = "select id,nombre from estadopagocontrarecibo";
            this.ESTATUSPAGOIDTextBox.QueryDeSeleccion = "select id,nombre from estadopagocontrarecibo where  id = @id";
            this.ESTATUSPAGOIDTextBox.SelectedDataDisplaying = null;
            this.ESTATUSPAGOIDTextBox.SelectedDataValue = null;
            this.ESTATUSPAGOIDTextBox.Size = new System.Drawing.Size(88, 21);
            this.ESTATUSPAGOIDTextBox.TabIndex = 88;
            this.ESTATUSPAGOIDTextBox.ValueMember = "id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(366, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 89;
            this.label5.Text = "Estatus de pago:";
            // 
            // btnCambiarEstatusPago
            // 
            this.btnCambiarEstatusPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCambiarEstatusPago.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCambiarEstatusPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEstatusPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCambiarEstatusPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCambiarEstatusPago.Location = new System.Drawing.Point(201, 456);
            this.btnCambiarEstatusPago.Name = "btnCambiarEstatusPago";
            this.btnCambiarEstatusPago.Size = new System.Drawing.Size(178, 37);
            this.btnCambiarEstatusPago.TabIndex = 90;
            this.btnCambiarEstatusPago.Text = "Cambiar estado de pago";
            this.btnCambiarEstatusPago.UseVisualStyleBackColor = false;
            this.btnCambiarEstatusPago.Click += new System.EventHandler(this.btnCambiarEstatusPago_Click);
            // 
            // WFContraRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(1034, 505);
            this.Controls.Add(this.btnCambiarEstatusPago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ESTATUSPAGOIDTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBTransacccion);
            this.Controls.Add(this.LBTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.BTGUARDAR);
            this.Controls.Add(this.cONTRARECIBODTLDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBNota);
            this.Controls.Add(this.BtnListaTransacciones);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.BTCliente);
            this.Controls.Add(this.LBCliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFContraRecibos";
            this.Text = "WFContraRecibos";
            this.Load += new System.EventHandler(this.WFContraRecibos_Load);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSCobranza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cONTRARECIBODTLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cONTRARECIBODTLDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPersona;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lbClieCP;
        private System.Windows.Forms.Label lbClieTel;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lbClieCiudad;
        private System.Windows.Forms.Label lbClieEstado;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbClieDom;
        private System.Windows.Forms.Label lbClieColonia;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbClieNombre;
        private System.Windows.Forms.Label lbClieRFC;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button BTCliente;
        private System.Windows.Forms.Label LBCliente;
        private System.Windows.Forms.Button BtnListaTransacciones;
        private System.Windows.Forms.TextBox TBNota;
        private System.Windows.Forms.Label label1;
        private Cobranza.DSCobranza dSCobranza;
        private System.Windows.Forms.BindingSource cONTRARECIBODTLBindingSource;
        private Cobranza.DSCobranzaTableAdapters.CONTRARECIBODTLTableAdapter cONTRARECIBODTLTableAdapter;
        private Cobranza.DSCobranzaTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum cONTRARECIBODTLDataGridView;
        private System.Windows.Forms.Button BTGUARDAR;
        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBTransacccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewImageColumn DGELIMINAR;
        private System.Windows.Forms.ComboBoxFB ESTATUSPAGOIDTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCambiarEstatusPago;
    }
}