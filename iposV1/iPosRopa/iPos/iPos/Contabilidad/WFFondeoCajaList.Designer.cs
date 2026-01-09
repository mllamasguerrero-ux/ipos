namespace iPos
{
    partial class WFFondeoCajaList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAgregarFondeoOtroCajero = new System.Windows.Forms.Button();
            this.ComboEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMostrarRegistros = new System.Windows.Forms.Button();
            this.btnAgregarFondeo = new System.Windows.Forms.Button();
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
            this.fONDEOS_CAJADataGridView = new System.Windows.Forms.DataGridViewSum();
            this.fONDEOS_CAJABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSContabilidad2 = new iPos.Contabilidad.DSContabilidad2();
            this.fONDEOS_CAJATableAdapter = new iPos.Contabilidad.DSContabilidad2TableAdapters.FONDEOS_CAJATableAdapter();
            this.tableAdapterManager = new iPos.Contabilidad.DSContabilidad2TableAdapters.TableAdapterManager();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVER = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGCANCELAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.pnlCorteActual.SuspendLayout();
            this.pnlCajero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fONDEOS_CAJADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fONDEOS_CAJABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnAgregarFondeoOtroCajero);
            this.panel1.Controls.Add(this.ComboEstado);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnMostrarRegistros);
            this.panel1.Controls.Add(this.btnAgregarFondeo);
            this.panel1.Controls.Add(this.pnlCorteActual);
            this.panel1.Controls.Add(this.pnlCajero);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 89);
            this.panel1.TabIndex = 4;
            // 
            // btnAgregarFondeoOtroCajero
            // 
            this.btnAgregarFondeoOtroCajero.AccessibleDescription = "resizeforscreen";
            this.btnAgregarFondeoOtroCajero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnAgregarFondeoOtroCajero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAgregarFondeoOtroCajero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarFondeoOtroCajero.ForeColor = System.Drawing.Color.White;
            this.btnAgregarFondeoOtroCajero.Location = new System.Drawing.Point(707, 45);
            this.btnAgregarFondeoOtroCajero.Name = "btnAgregarFondeoOtroCajero";
            this.btnAgregarFondeoOtroCajero.Size = new System.Drawing.Size(107, 37);
            this.btnAgregarFondeoOtroCajero.TabIndex = 50;
            this.btnAgregarFondeoOtroCajero.Text = "Agregar fondeo otro cajero";
            this.btnAgregarFondeoOtroCajero.UseVisualStyleBackColor = false;
            this.btnAgregarFondeoOtroCajero.Click += new System.EventHandler(this.btnAgregarFondeoOtroCajero_Click);
            // 
            // ComboEstado
            // 
            this.ComboEstado.FormattingEnabled = true;
            this.ComboEstado.Items.AddRange(new object[] {
            "Todos",
            "Completos",
            "Pendientes",
            "Cancelados"});
            this.ComboEstado.Location = new System.Drawing.Point(652, 7);
            this.ComboEstado.Name = "ComboEstado";
            this.ComboEstado.Size = new System.Drawing.Size(144, 21);
            this.ComboEstado.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(603, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Estado:";
            // 
            // btnMostrarRegistros
            // 
            this.btnMostrarRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnMostrarRegistros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMostrarRegistros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarRegistros.ForeColor = System.Drawing.Color.White;
            this.btnMostrarRegistros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarRegistros.Location = new System.Drawing.Point(472, 51);
            this.btnMostrarRegistros.Name = "btnMostrarRegistros";
            this.btnMostrarRegistros.Size = new System.Drawing.Size(128, 25);
            this.btnMostrarRegistros.TabIndex = 47;
            this.btnMostrarRegistros.Text = "Mostrar Registros";
            this.btnMostrarRegistros.UseVisualStyleBackColor = false;
            this.btnMostrarRegistros.Click += new System.EventHandler(this.btnMostrarRegistros_Click);
            // 
            // btnAgregarFondeo
            // 
            this.btnAgregarFondeo.AccessibleDescription = "resizeforscreen";
            this.btnAgregarFondeo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnAgregarFondeo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAgregarFondeo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarFondeo.ForeColor = System.Drawing.Color.White;
            this.btnAgregarFondeo.Location = new System.Drawing.Point(606, 46);
            this.btnAgregarFondeo.Name = "btnAgregarFondeo";
            this.btnAgregarFondeo.Size = new System.Drawing.Size(98, 37);
            this.btnAgregarFondeo.TabIndex = 46;
            this.btnAgregarFondeo.Text = "Agregar fondeo";
            this.btnAgregarFondeo.UseVisualStyleBackColor = false;
            this.btnAgregarFondeo.Click += new System.EventHandler(this.btnAgregarFondeo_Click);
            // 
            // pnlCorteActual
            // 
            this.pnlCorteActual.BackColor = System.Drawing.Color.Transparent;
            this.pnlCorteActual.Controls.Add(this.label4);
            this.pnlCorteActual.Controls.Add(this.label5);
            this.pnlCorteActual.Controls.Add(this.CBCorteActual);
            this.pnlCorteActual.Controls.Add(this.DTPFecha);
            this.pnlCorteActual.Location = new System.Drawing.Point(4, 49);
            this.pnlCorteActual.Name = "pnlCorteActual";
            this.pnlCorteActual.Size = new System.Drawing.Size(462, 34);
            this.pnlCorteActual.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Corte Actual:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(151, 9);
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
            this.CBCorteActual.Location = new System.Drawing.Point(92, 8);
            this.CBCorteActual.Name = "CBCorteActual";
            this.CBCorteActual.Size = new System.Drawing.Size(15, 14);
            this.CBCorteActual.TabIndex = 13;
            this.CBCorteActual.UseVisualStyleBackColor = true;
            // 
            // DTPFecha
            // 
            this.DTPFecha.AccessibleDescription = "resizeforscreen";
            this.DTPFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPFecha.Location = new System.Drawing.Point(197, 7);
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
            this.pnlCajero.Location = new System.Drawing.Point(4, 6);
            this.pnlCajero.Name = "pnlCajero";
            this.pnlCajero.Size = new System.Drawing.Size(482, 37);
            this.pnlCajero.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 6);
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
            this.CBCajerosTodos.Location = new System.Drawing.Point(307, 6);
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
            // fONDEOS_CAJADataGridView
            // 
            this.fONDEOS_CAJADataGridView.AllowUserToAddRows = false;
            this.fONDEOS_CAJADataGridView.AllowUserToDeleteRows = false;
            this.fONDEOS_CAJADataGridView.AutoGenerateColumns = false;
            this.fONDEOS_CAJADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fONDEOS_CAJADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn3,
            this.DGVER,
            this.DGCANCELAR,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.fONDEOS_CAJADataGridView.DataSource = this.fONDEOS_CAJABindingSource;
            this.fONDEOS_CAJADataGridView.Location = new System.Drawing.Point(4, 104);
            this.fONDEOS_CAJADataGridView.Name = "fONDEOS_CAJADataGridView";
            this.fONDEOS_CAJADataGridView.RowHeadersVisible = false;
            this.fONDEOS_CAJADataGridView.Size = new System.Drawing.Size(849, 283);
            this.fONDEOS_CAJADataGridView.TabIndex = 6;
            this.fONDEOS_CAJADataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gASTOSDataGridView_CellContentClick);
            // 
            // fONDEOS_CAJABindingSource
            // 
            this.fONDEOS_CAJABindingSource.DataMember = "FONDEOS_CAJA";
            this.fONDEOS_CAJABindingSource.DataSource = this.dSContabilidad2;
            // 
            // dSContabilidad2
            // 
            this.dSContabilidad2.DataSetName = "DSContabilidad2";
            this.dSContabilidad2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fONDEOS_CAJATableAdapter
            // 
            this.fONDEOS_CAJATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Contabilidad.DSContabilidad2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CAJEROID";
            this.dataGridViewTextBoxColumn4.HeaderText = "CAJEROID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FOLIO";
            this.dataGridViewTextBoxColumn2.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CAJERONOMBRE";
            this.dataGridViewTextBoxColumn5.HeaderText = "CAJERO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "NOMBREESTATUSDOCTO";
            this.dataGridViewTextBoxColumn6.HeaderText = "ESTATUS";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "FECHA";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn10.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "FECHAHORA";
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn12.HeaderText = "HORA";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TOTAL";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // DGVER
            // 
            this.DGVER.HeaderText = "";
            this.DGVER.Name = "DGVER";
            this.DGVER.Text = "VER";
            this.DGVER.UseColumnTextForButtonValue = true;
            // 
            // DGCANCELAR
            // 
            this.DGCANCELAR.HeaderText = "";
            this.DGCANCELAR.Name = "DGCANCELAR";
            this.DGCANCELAR.Text = "CANCELAR";
            this.DGCANCELAR.UseColumnTextForButtonValue = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "FECHACORTE";
            this.dataGridViewTextBoxColumn11.HeaderText = "FECHACORTE";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ESTATUSDOCTOID";
            this.dataGridViewTextBoxColumn7.HeaderText = "ESTATUSDOCTOID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "CORTEID";
            this.dataGridViewTextBoxColumn8.HeaderText = "CORTEID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "MONTOBILLETESID";
            this.dataGridViewTextBoxColumn9.HeaderText = "MONTOBILLETESID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // WFFondeoCajaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(865, 399);
            this.Controls.Add(this.fONDEOS_CAJADataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "WFFondeoCajaList";
            this.Text = "Lista de fondeos";
            this.Load += new System.EventHandler(this.WFFondeoCajaList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlCorteActual.ResumeLayout(false);
            this.pnlCorteActual.PerformLayout();
            this.pnlCajero.ResumeLayout(false);
            this.pnlCajero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fONDEOS_CAJADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fONDEOS_CAJABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAgregarFondeoOtroCajero;
        private System.Windows.Forms.ComboBox ComboEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMostrarRegistros;
        private System.Windows.Forms.Button btnAgregarFondeo;
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
        private iPos.Contabilidad.DSContabilidad2 dSContabilidad2;
        private System.Windows.Forms.BindingSource fONDEOS_CAJABindingSource;
        private iPos.Contabilidad.DSContabilidad2TableAdapters.FONDEOS_CAJATableAdapter fONDEOS_CAJATableAdapter;
        private iPos.Contabilidad.DSContabilidad2TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum fONDEOS_CAJADataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewButtonColumn DGVER;
        private System.Windows.Forms.DataGridViewButtonColumn DGCANCELAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}