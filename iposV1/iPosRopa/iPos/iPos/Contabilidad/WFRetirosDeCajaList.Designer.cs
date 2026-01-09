namespace iPos
{
    partial class WFRetirosDeCajaList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFRetirosDeCajaList));
            this.rETIROSCAJADataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGESTATUSDOCTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCANCELAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGEDITAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGCONSULTAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGMONTOBILLETESID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rETIROSCAJABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSContabilidad = new iPos.Contabilidad.DSContabilidad();
            this.pnlCorteActual = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CBCorteActual = new System.Windows.Forms.CheckBox();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.pnlCajero = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.VENDEDORLabel = new System.Windows.Forms.Label();
            this.VENDEDORButton = new System.Windows.Forms.Button();
            this.CBCajerosTodos = new System.Windows.Forms.CheckBox();
            this.VENDEDORIDTextBox = new iPos.Tools.TextBoxFB();
            this.btnAgregarRetiroCaja = new System.Windows.Forms.Button();
            this.btnMostrarRegistros = new System.Windows.Forms.Button();
            this.rETIROSCAJATableAdapter = new iPos.Contabilidad.DSContabilidadTableAdapters.RETIROSCAJATableAdapter();
            this.tableAdapterManager = new iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComboEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarRetiroOtroCajero = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rETIROSCAJADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETIROSCAJABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad)).BeginInit();
            this.pnlCorteActual.SuspendLayout();
            this.pnlCajero.SuspendLayout();
            this.SuspendLayout();
            // 
            // rETIROSCAJADataGridView
            // 
            this.rETIROSCAJADataGridView.AllowUserToAddRows = false;
            this.rETIROSCAJADataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rETIROSCAJADataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.rETIROSCAJADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rETIROSCAJADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn11,
            this.DGID,
            this.DGFECHA,
            this.DGESTATUSDOCTOID,
            this.DGCANCELAR,
            this.DGEDITAR,
            this.DGCONSULTAR,
            this.DGMONTOBILLETESID});
            this.rETIROSCAJADataGridView.DataSource = this.rETIROSCAJABindingSource;
            this.rETIROSCAJADataGridView.Location = new System.Drawing.Point(12, 96);
            this.rETIROSCAJADataGridView.Name = "rETIROSCAJADataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rETIROSCAJADataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.rETIROSCAJADataGridView.RowHeadersVisible = false;
            this.rETIROSCAJADataGridView.Size = new System.Drawing.Size(872, 231);
            this.rETIROSCAJADataGridView.TabIndex = 2;
            this.rETIROSCAJADataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rETIROSCAJADataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FOLIO";
            this.dataGridViewTextBoxColumn2.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TOTAL";
            this.dataGridViewTextBoxColumn3.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CAJEROID";
            this.dataGridViewTextBoxColumn4.HeaderText = "CAJEROID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CAJERONOMBRE";
            this.dataGridViewTextBoxColumn5.HeaderText = "CAJERO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "EFECTIVO";
            this.dataGridViewTextBoxColumn6.HeaderText = "EFECTIVO";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CHEQUE";
            this.dataGridViewTextBoxColumn7.HeaderText = "CHEQUE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "VALE";
            this.dataGridViewTextBoxColumn8.HeaderText = "VALE";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NOMBREESTATUSDOCTO";
            this.dataGridViewTextBoxColumn9.HeaderText = "ESTATUS";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "CORTEID";
            this.dataGridViewTextBoxColumn11.HeaderText = "CORTEID";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.ReadOnly = true;
            this.DGID.Visible = false;
            // 
            // DGFECHA
            // 
            this.DGFECHA.DataPropertyName = "FECHA";
            this.DGFECHA.HeaderText = "FECHA";
            this.DGFECHA.Name = "DGFECHA";
            this.DGFECHA.ReadOnly = true;
            this.DGFECHA.Width = 75;
            // 
            // DGESTATUSDOCTOID
            // 
            this.DGESTATUSDOCTOID.DataPropertyName = "ESTATUSDOCTOID";
            this.DGESTATUSDOCTOID.HeaderText = "ESTATUSDOCTOID";
            this.DGESTATUSDOCTOID.Name = "DGESTATUSDOCTOID";
            this.DGESTATUSDOCTOID.Visible = false;
            // 
            // DGCANCELAR
            // 
            this.DGCANCELAR.HeaderText = "";
            this.DGCANCELAR.Name = "DGCANCELAR";
            this.DGCANCELAR.Text = "CANCELAR";
            this.DGCANCELAR.UseColumnTextForButtonValue = true;
            this.DGCANCELAR.Width = 70;
            // 
            // DGEDITAR
            // 
            this.DGEDITAR.HeaderText = "";
            this.DGEDITAR.Name = "DGEDITAR";
            this.DGEDITAR.Text = "EDITAR";
            this.DGEDITAR.UseColumnTextForButtonValue = true;
            this.DGEDITAR.Width = 70;
            // 
            // DGCONSULTAR
            // 
            this.DGCONSULTAR.HeaderText = "";
            this.DGCONSULTAR.Name = "DGCONSULTAR";
            this.DGCONSULTAR.Text = "CONSULTAR";
            this.DGCONSULTAR.UseColumnTextForButtonValue = true;
            this.DGCONSULTAR.Width = 70;
            // 
            // DGMONTOBILLETESID
            // 
            this.DGMONTOBILLETESID.DataPropertyName = "MONTOBILLETESID";
            this.DGMONTOBILLETESID.HeaderText = "MONTOBILLETESID";
            this.DGMONTOBILLETESID.Name = "DGMONTOBILLETESID";
            this.DGMONTOBILLETESID.Visible = false;
            // 
            // rETIROSCAJABindingSource
            // 
            this.rETIROSCAJABindingSource.DataMember = "RETIROSCAJA";
            this.rETIROSCAJABindingSource.DataSource = this.dSContabilidad;
            // 
            // dSContabilidad
            // 
            this.dSContabilidad.DataSetName = "DSContabilidad";
            this.dSContabilidad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlCorteActual
            // 
            this.pnlCorteActual.BackColor = System.Drawing.Color.Transparent;
            this.pnlCorteActual.Controls.Add(this.label4);
            this.pnlCorteActual.Controls.Add(this.label5);
            this.pnlCorteActual.Controls.Add(this.CBCorteActual);
            this.pnlCorteActual.Controls.Add(this.DTPFecha);
            this.pnlCorteActual.Location = new System.Drawing.Point(15, 47);
            this.pnlCorteActual.Name = "pnlCorteActual";
            this.pnlCorteActual.Size = new System.Drawing.Size(536, 34);
            this.pnlCorteActual.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(19, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Corte Actual:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(224, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Fecha:";
            // 
            // CBCorteActual
            // 
            this.CBCorteActual.AutoSize = true;
            this.CBCorteActual.Checked = true;
            this.CBCorteActual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBCorteActual.Location = new System.Drawing.Point(93, 8);
            this.CBCorteActual.Name = "CBCorteActual";
            this.CBCorteActual.Size = new System.Drawing.Size(15, 14);
            this.CBCorteActual.TabIndex = 13;
            this.CBCorteActual.UseVisualStyleBackColor = true;
            // 
            // DTPFecha
            // 
            this.DTPFecha.AccessibleDescription = "resizeforscreen";
            this.DTPFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPFecha.Location = new System.Drawing.Point(270, 4);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(237, 20);
            this.DTPFecha.TabIndex = 15;
            // 
            // pnlCajero
            // 
            this.pnlCajero.BackColor = System.Drawing.Color.Transparent;
            this.pnlCajero.Controls.Add(this.label2);
            this.pnlCajero.Controls.Add(this.VENDEDORLabel);
            this.pnlCajero.Controls.Add(this.VENDEDORButton);
            this.pnlCajero.Controls.Add(this.CBCajerosTodos);
            this.pnlCajero.Controls.Add(this.VENDEDORIDTextBox);
            this.pnlCajero.Location = new System.Drawing.Point(15, 4);
            this.pnlCajero.Name = "pnlCajero";
            this.pnlCajero.Size = new System.Drawing.Size(536, 37);
            this.pnlCajero.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 162;
            this.label2.Text = "Cajero:";
            // 
            // VENDEDORLabel
            // 
            this.VENDEDORLabel.AutoSize = true;
            this.VENDEDORLabel.ForeColor = System.Drawing.Color.White;
            this.VENDEDORLabel.Location = new System.Drawing.Point(194, 6);
            this.VENDEDORLabel.Name = "VENDEDORLabel";
            this.VENDEDORLabel.Size = new System.Drawing.Size(16, 13);
            this.VENDEDORLabel.TabIndex = 160;
            this.VENDEDORLabel.Text = "...";
            // 
            // VENDEDORButton
            // 
            this.VENDEDORButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.VENDEDORButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VENDEDORButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VENDEDORButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.VENDEDORButton.Location = new System.Drawing.Point(164, 3);
            this.VENDEDORButton.Name = "VENDEDORButton";
            this.VENDEDORButton.Size = new System.Drawing.Size(24, 23);
            this.VENDEDORButton.TabIndex = 16;
            this.VENDEDORButton.UseVisualStyleBackColor = true;
            // 
            // CBCajerosTodos
            // 
            this.CBCajerosTodos.AutoSize = true;
            this.CBCajerosTodos.ForeColor = System.Drawing.Color.White;
            this.CBCajerosTodos.Location = new System.Drawing.Point(359, 7);
            this.CBCajerosTodos.Name = "CBCajerosTodos";
            this.CBCajerosTodos.Size = new System.Drawing.Size(109, 17);
            this.CBCajerosTodos.TabIndex = 17;
            this.CBCajerosTodos.Text = "Todos los cajeros";
            this.CBCajerosTodos.UseVisualStyleBackColor = true;
            // 
            // VENDEDORIDTextBox
            // 
            this.VENDEDORIDTextBox.AccessibleDescription = "resizeforscreen";
            this.VENDEDORIDTextBox.BotonLookUp = this.VENDEDORButton;
            this.VENDEDORIDTextBox.Condicion = null;
            this.VENDEDORIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORIDTextBox.DbValue = null;
            this.VENDEDORIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VENDEDORIDTextBox.Format_Expression = null;
            this.VENDEDORIDTextBox.IndiceCampoDescripcion = 2;
            this.VENDEDORIDTextBox.IndiceCampoSelector = 1;
            this.VENDEDORIDTextBox.IndiceCampoValue = 0;
            this.VENDEDORIDTextBox.LabelDescription = this.VENDEDORLabel;
            this.VENDEDORIDTextBox.Location = new System.Drawing.Point(65, 3);
            this.VENDEDORIDTextBox.MostrarErrores = true;
            this.VENDEDORIDTextBox.Name = "VENDEDORIDTextBox";
            this.VENDEDORIDTextBox.NombreCampoSelector = "clave";
            this.VENDEDORIDTextBox.NombreCampoValue = "id";
            this.VENDEDORIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid in (12,13,20,21)";
            this.VENDEDORIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid in (12,13,20,21) and  cla" +
    "ve= @clave";
            this.VENDEDORIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid in (12,13,20,21) and  id " +
    "= @id";
            this.VENDEDORIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.VENDEDORIDTextBox.TabIndex = 15;
            this.VENDEDORIDTextBox.Tag = 34;
            this.VENDEDORIDTextBox.TextDescription = null;
            this.VENDEDORIDTextBox.Titulo = "Usuarios";
            this.VENDEDORIDTextBox.ValidarEntrada = true;
            this.VENDEDORIDTextBox.ValidationExpression = null;
            // 
            // btnAgregarRetiroCaja
            // 
            this.btnAgregarRetiroCaja.AccessibleDescription = "resizeforscreen";
            this.btnAgregarRetiroCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnAgregarRetiroCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAgregarRetiroCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarRetiroCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarRetiroCaja.ForeColor = System.Drawing.Color.White;
            this.btnAgregarRetiroCaja.Location = new System.Drawing.Point(691, 43);
            this.btnAgregarRetiroCaja.Name = "btnAgregarRetiroCaja";
            this.btnAgregarRetiroCaja.Size = new System.Drawing.Size(94, 37);
            this.btnAgregarRetiroCaja.TabIndex = 35;
            this.btnAgregarRetiroCaja.Text = "Agregar retiro de caja";
            this.btnAgregarRetiroCaja.UseVisualStyleBackColor = false;
            this.btnAgregarRetiroCaja.Click += new System.EventHandler(this.btnAgregarRetiroCaja_Click);
            // 
            // btnMostrarRegistros
            // 
            this.btnMostrarRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnMostrarRegistros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMostrarRegistros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarRegistros.ForeColor = System.Drawing.Color.White;
            this.btnMostrarRegistros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarRegistros.Location = new System.Drawing.Point(557, 52);
            this.btnMostrarRegistros.Name = "btnMostrarRegistros";
            this.btnMostrarRegistros.Size = new System.Drawing.Size(128, 25);
            this.btnMostrarRegistros.TabIndex = 43;
            this.btnMostrarRegistros.Text = "Mostrar registros";
            this.btnMostrarRegistros.UseVisualStyleBackColor = false;
            this.btnMostrarRegistros.Click += new System.EventHandler(this.btnMostrarRegistros_Click);
            // 
            // rETIROSCAJATableAdapter
            // 
            this.rETIROSCAJATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ESTATUSDOCTOID";
            this.dataGridViewTextBoxColumn10.HeaderText = "ESTATUSDOCTOID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "CANCELAR";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 70;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "EDITAR";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "CAJEROID";
            this.dataGridViewTextBoxColumn12.HeaderText = "CAJEROID";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "MONTOBILLETESID";
            this.dataGridViewTextBoxColumn13.HeaderText = "MONTOBILLETESID";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // ComboEstado
            // 
            this.ComboEstado.FormattingEnabled = true;
            this.ComboEstado.Items.AddRange(new object[] {
            "Todos",
            "Completos",
            "Pendientes",
            "Cancelados"});
            this.ComboEstado.Location = new System.Drawing.Point(712, 13);
            this.ComboEstado.Name = "ComboEstado";
            this.ComboEstado.Size = new System.Drawing.Size(161, 21);
            this.ComboEstado.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(663, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Estado:";
            // 
            // btnAgregarRetiroOtroCajero
            // 
            this.btnAgregarRetiroOtroCajero.AccessibleDescription = "resizeforscreen";
            this.btnAgregarRetiroOtroCajero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnAgregarRetiroOtroCajero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAgregarRetiroOtroCajero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarRetiroOtroCajero.ForeColor = System.Drawing.Color.White;
            this.btnAgregarRetiroOtroCajero.Location = new System.Drawing.Point(791, 45);
            this.btnAgregarRetiroOtroCajero.Name = "btnAgregarRetiroOtroCajero";
            this.btnAgregarRetiroOtroCajero.Size = new System.Drawing.Size(98, 37);
            this.btnAgregarRetiroOtroCajero.TabIndex = 52;
            this.btnAgregarRetiroOtroCajero.Text = "Agregar retiro otro cajero";
            this.btnAgregarRetiroOtroCajero.UseVisualStyleBackColor = false;
            this.btnAgregarRetiroOtroCajero.Click += new System.EventHandler(this.btnAgregarRetiroOtroCajero_Click);
            // 
            // WFRetirosDeCajaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(898, 408);
            this.Controls.Add(this.btnAgregarRetiroOtroCajero);
            this.Controls.Add(this.ComboEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMostrarRegistros);
            this.Controls.Add(this.btnAgregarRetiroCaja);
            this.Controls.Add(this.pnlCorteActual);
            this.Controls.Add(this.pnlCajero);
            this.Controls.Add(this.rETIROSCAJADataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFRetirosDeCajaList";
            this.Text = "Lista de retiros de caja";
            this.Load += new System.EventHandler(this.WFRetirosDeCajaList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rETIROSCAJADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETIROSCAJABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad)).EndInit();
            this.pnlCorteActual.ResumeLayout(false);
            this.pnlCorteActual.PerformLayout();
            this.pnlCajero.ResumeLayout(false);
            this.pnlCajero.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Contabilidad.DSContabilidad dSContabilidad;
        private System.Windows.Forms.BindingSource rETIROSCAJABindingSource;
        private Contabilidad.DSContabilidadTableAdapters.RETIROSCAJATableAdapter rETIROSCAJATableAdapter;
        private Contabilidad.DSContabilidadTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum rETIROSCAJADataGridView;
        private System.Windows.Forms.Panel pnlCorteActual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CBCorteActual;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.Panel pnlCajero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label VENDEDORLabel;
        private System.Windows.Forms.Button VENDEDORButton;
        private System.Windows.Forms.CheckBox CBCajerosTodos;
        private Tools.TextBoxFB VENDEDORIDTextBox;
        private System.Windows.Forms.Button btnAgregarRetiroCaja;
        private System.Windows.Forms.Button btnMostrarRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGESTATUSDOCTOID;
        private System.Windows.Forms.DataGridViewButtonColumn DGCANCELAR;
        private System.Windows.Forms.DataGridViewButtonColumn DGEDITAR;
        private System.Windows.Forms.DataGridViewButtonColumn DGCONSULTAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGMONTOBILLETESID;
        private System.Windows.Forms.ComboBox ComboEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarRetiroOtroCajero;
    }
}