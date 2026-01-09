namespace iPos.Abonos
{
    partial class WFLookUpCompraSucursales
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBProveedor = new System.Windows.Forms.CheckBox();
            this.ITEMButton = new System.Windows.Forms.Button();
            this.ITEMLabel = new System.Windows.Forms.Label();
            this.CBSucursal = new System.Windows.Forms.CheckBox();
            this.CBFecha = new System.Windows.Forms.CheckBox();
            this.SUCURSALIDLabel = new System.Windows.Forms.Label();
            this.BTBuscar = new System.Windows.Forms.Button();
            this.SUCURSALIDButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.transaccionesListaExtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSReimpresionTicket2 = new iPos.ReimpresionTicket.DSReimpresionTicket2();
            this.transaccionesListaExtTableAdapter = new iPos.ReimpresionTicket.DSReimpresionTicket2TableAdapters.TransaccionesListaExtTableAdapter();
            this.tableAdapterManager = new iPos.ReimpresionTicket.DSReimpresionTicket2TableAdapters.TableAdapterManager();
            this.transaccionesListaDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.ITEMIDTextBox = new iPos.Tools.TextBoxFB();
            this.SUCURSALIDTextBox = new iPos.Tools.TextBoxFB();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGSUCDESTNOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPERSONANOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOLIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transaccionesListaExtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReimpresionTicket2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transaccionesListaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.CBProveedor);
            this.panel1.Controls.Add(this.ITEMButton);
            this.panel1.Controls.Add(this.ITEMIDTextBox);
            this.panel1.Controls.Add(this.ITEMLabel);
            this.panel1.Controls.Add(this.CBSucursal);
            this.panel1.Controls.Add(this.CBFecha);
            this.panel1.Controls.Add(this.SUCURSALIDLabel);
            this.panel1.Controls.Add(this.BTBuscar);
            this.panel1.Controls.Add(this.SUCURSALIDButton);
            this.panel1.Controls.Add(this.SUCURSALIDTextBox);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 81);
            this.panel1.TabIndex = 231;
            // 
            // CBProveedor
            // 
            this.CBProveedor.AutoSize = true;
            this.CBProveedor.BackColor = System.Drawing.Color.Transparent;
            this.CBProveedor.ForeColor = System.Drawing.Color.Transparent;
            this.CBProveedor.Location = new System.Drawing.Point(437, 54);
            this.CBProveedor.Name = "CBProveedor";
            this.CBProveedor.Size = new System.Drawing.Size(75, 17);
            this.CBProveedor.TabIndex = 234;
            this.CBProveedor.Text = "Proveedor";
            this.CBProveedor.UseVisualStyleBackColor = false;
            // 
            // ITEMButton
            // 
            this.ITEMButton.BackColor = System.Drawing.Color.Transparent;
            this.ITEMButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(628, 52);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(23, 23);
            this.ITEMButton.TabIndex = 231;
            this.ITEMButton.UseVisualStyleBackColor = false;
            // 
            // ITEMLabel
            // 
            this.ITEMLabel.AutoSize = true;
            this.ITEMLabel.BackColor = System.Drawing.Color.Transparent;
            this.ITEMLabel.ForeColor = System.Drawing.Color.White;
            this.ITEMLabel.Location = new System.Drawing.Point(655, 57);
            this.ITEMLabel.Name = "ITEMLabel";
            this.ITEMLabel.Size = new System.Drawing.Size(16, 13);
            this.ITEMLabel.TabIndex = 233;
            this.ITEMLabel.Text = "...";
            // 
            // CBSucursal
            // 
            this.CBSucursal.AutoSize = true;
            this.CBSucursal.BackColor = System.Drawing.Color.Transparent;
            this.CBSucursal.ForeColor = System.Drawing.Color.Transparent;
            this.CBSucursal.Location = new System.Drawing.Point(12, 21);
            this.CBSucursal.Name = "CBSucursal";
            this.CBSucursal.Size = new System.Drawing.Size(67, 17);
            this.CBSucursal.TabIndex = 229;
            this.CBSucursal.Text = "Sucursal";
            this.CBSucursal.UseVisualStyleBackColor = false;
            // 
            // CBFecha
            // 
            this.CBFecha.AutoSize = true;
            this.CBFecha.BackColor = System.Drawing.Color.Transparent;
            this.CBFecha.ForeColor = System.Drawing.Color.White;
            this.CBFecha.Location = new System.Drawing.Point(12, 56);
            this.CBFecha.Name = "CBFecha";
            this.CBFecha.Size = new System.Drawing.Size(129, 17);
            this.CBFecha.TabIndex = 4;
            this.CBFecha.Text = "Registros de la Fecha";
            this.CBFecha.UseVisualStyleBackColor = false;
            // 
            // SUCURSALIDLabel
            // 
            this.SUCURSALIDLabel.AutoSize = true;
            this.SUCURSALIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.SUCURSALIDLabel.ForeColor = System.Drawing.Color.White;
            this.SUCURSALIDLabel.Location = new System.Drawing.Point(299, 20);
            this.SUCURSALIDLabel.Name = "SUCURSALIDLabel";
            this.SUCURSALIDLabel.Size = new System.Drawing.Size(16, 13);
            this.SUCURSALIDLabel.TabIndex = 228;
            this.SUCURSALIDLabel.Text = "...";
            // 
            // BTBuscar
            // 
            this.BTBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTBuscar.ForeColor = System.Drawing.Color.White;
            this.BTBuscar.Location = new System.Drawing.Point(783, 15);
            this.BTBuscar.Name = "BTBuscar";
            this.BTBuscar.Size = new System.Drawing.Size(87, 23);
            this.BTBuscar.TabIndex = 5;
            this.BTBuscar.Text = "Buscar";
            this.BTBuscar.UseVisualStyleBackColor = false;
            this.BTBuscar.Click += new System.EventHandler(this.BTBuscar_Click);
            // 
            // SUCURSALIDButton
            // 
            this.SUCURSALIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SUCURSALIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SUCURSALIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SUCURSALIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SUCURSALIDButton.Location = new System.Drawing.Point(269, 15);
            this.SUCURSALIDButton.Name = "SUCURSALIDButton";
            this.SUCURSALIDButton.Size = new System.Drawing.Size(24, 23);
            this.SUCURSALIDButton.TabIndex = 227;
            this.SUCURSALIDButton.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(168, 51);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(233, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // transaccionesListaExtBindingSource
            // 
            this.transaccionesListaExtBindingSource.DataMember = "TransaccionesListaExt";
            this.transaccionesListaExtBindingSource.DataSource = this.dSReimpresionTicket2;
            // 
            // dSReimpresionTicket2
            // 
            this.dSReimpresionTicket2.DataSetName = "DSReimpresionTicket2";
            this.dSReimpresionTicket2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // transaccionesListaExtTableAdapter
            // 
            this.transaccionesListaExtTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.ReimpresionTicket.DSReimpresionTicket2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // transaccionesListaDataGridView
            // 
            this.transaccionesListaDataGridView.AllowUserToAddRows = false;
            this.transaccionesListaDataGridView.AutoGenerateColumns = false;
            this.transaccionesListaDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.transaccionesListaDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.transaccionesListaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transaccionesListaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.DGSUCDESTNOMBRE,
            this.DGPERSONANOMBRE,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn8,
            this.FOLIO,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn12});
            this.transaccionesListaDataGridView.DataSource = this.transaccionesListaExtBindingSource;
            this.transaccionesListaDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.transaccionesListaDataGridView.EnableHeadersVisualStyles = false;
            this.transaccionesListaDataGridView.Location = new System.Drawing.Point(0, 87);
            this.transaccionesListaDataGridView.Name = "transaccionesListaDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.transaccionesListaDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.transaccionesListaDataGridView.RowHeadersVisible = false;
            this.transaccionesListaDataGridView.Size = new System.Drawing.Size(906, 319);
            this.transaccionesListaDataGridView.TabIndex = 232;
            this.transaccionesListaDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.transaccionesListaDataGridView_CellContentClick);
            this.transaccionesListaDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.transaccionesListaDataGridView_KeyPress);
            this.transaccionesListaDataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.transaccionesListaDataGridView_PreviewKeyDown);
            // 
            // ITEMIDTextBox
            // 
            this.ITEMIDTextBox.BotonLookUp = null;
            this.ITEMIDTextBox.Condicion = null;
            this.ITEMIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbValue = null;
            this.ITEMIDTextBox.Format_Expression = null;
            this.ITEMIDTextBox.IndiceCampoDescripcion = 2;
            this.ITEMIDTextBox.IndiceCampoSelector = 1;
            this.ITEMIDTextBox.IndiceCampoValue = 0;
            this.ITEMIDTextBox.LabelDescription = this.ITEMLabel;
            this.ITEMIDTextBox.Location = new System.Drawing.Point(527, 53);
            this.ITEMIDTextBox.MostrarErrores = true;
            this.ITEMIDTextBox.Name = "ITEMIDTextBox";
            this.ITEMIDTextBox.NombreCampoSelector = "clave";
            this.ITEMIDTextBox.NombreCampoValue = "id";
            this.ITEMIDTextBox.Query = "select id, clave, nombre, gaffete from persona where tipopersonaid  in (40) ";
            this.ITEMIDTextBox.QueryDeSeleccion = "select id, clave, nombre, gaffete from persona where tipopersonaid  in (40) and  " +
    "clave= @clave";
            this.ITEMIDTextBox.QueryPorDBValue = "select id, clave ,nombre, gaffete from persona where tipopersonaid  in (40) and  " +
    "id = @id";
            this.ITEMIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.ITEMIDTextBox.TabIndex = 230;
            this.ITEMIDTextBox.Tag = 34;
            this.ITEMIDTextBox.TextDescription = null;
            this.ITEMIDTextBox.Titulo = "Proveedores";
            this.ITEMIDTextBox.ValidarEntrada = true;
            this.ITEMIDTextBox.ValidationExpression = null;
            // 
            // SUCURSALIDTextBox
            // 
            this.SUCURSALIDTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.SUCURSALIDTextBox.BotonLookUp = this.SUCURSALIDButton;
            this.SUCURSALIDTextBox.Condicion = null;
            this.SUCURSALIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SUCURSALIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SUCURSALIDTextBox.DbValue = null;
            this.SUCURSALIDTextBox.Format_Expression = null;
            this.SUCURSALIDTextBox.IndiceCampoDescripcion = 2;
            this.SUCURSALIDTextBox.IndiceCampoSelector = 1;
            this.SUCURSALIDTextBox.IndiceCampoValue = 0;
            this.SUCURSALIDTextBox.LabelDescription = this.SUCURSALIDLabel;
            this.SUCURSALIDTextBox.Location = new System.Drawing.Point(168, 17);
            this.SUCURSALIDTextBox.MostrarErrores = true;
            this.SUCURSALIDTextBox.Name = "SUCURSALIDTextBox";
            this.SUCURSALIDTextBox.NombreCampoSelector = "clave";
            this.SUCURSALIDTextBox.NombreCampoValue = "id";
            this.SUCURSALIDTextBox.Query = "select id,clave,nombre from sucursal";
            this.SUCURSALIDTextBox.QueryDeSeleccion = "select id,clave,nombre from sucursal where  clave = @clave";
            this.SUCURSALIDTextBox.QueryPorDBValue = "select id,clave,nombre from sucursal where  id = @id";
            this.SUCURSALIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.SUCURSALIDTextBox.TabIndex = 226;
            this.SUCURSALIDTextBox.Tag = 34;
            this.SUCURSALIDTextBox.TextDescription = null;
            this.SUCURSALIDTextBox.Titulo = "Sucursal";
            this.SUCURSALIDTextBox.ValidarEntrada = true;
            this.SUCURSALIDTextBox.ValidationExpression = null;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CONSECUTIVO";
            this.dataGridViewTextBoxColumn1.HeaderText = "CONS.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // DGSUCDESTNOMBRE
            // 
            this.DGSUCDESTNOMBRE.DataPropertyName = "SUCDESTNOMBRE";
            this.DGSUCDESTNOMBRE.HeaderText = "SUCURSAL";
            this.DGSUCDESTNOMBRE.Name = "DGSUCDESTNOMBRE";
            this.DGSUCDESTNOMBRE.Width = 85;
            // 
            // DGPERSONANOMBRE
            // 
            this.DGPERSONANOMBRE.DataPropertyName = "PERSONANOMBRE";
            this.DGPERSONANOMBRE.HeaderText = "PROVEEDOR";
            this.DGPERSONANOMBRE.Name = "DGPERSONANOMBRE";
            this.DGPERSONANOMBRE.Width = 130;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CAJA";
            this.dataGridViewTextBoxColumn4.HeaderText = "CAJA";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn8.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 90;
            // 
            // FOLIO
            // 
            this.FOLIO.DataPropertyName = "FOLIO";
            this.FOLIO.HeaderText = "FOLIO";
            this.FOLIO.Name = "FOLIO";
            this.FOLIO.ReadOnly = true;
            this.FOLIO.Width = 90;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TOTAL";
            this.dataGridViewTextBoxColumn10.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 95;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "CLAVEESTATUSDOCTO";
            this.dataGridViewTextBoxColumn13.HeaderText = "ESTATUS";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 90;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "CLAVETIPODOCTO";
            this.dataGridViewTextBoxColumn14.HeaderText = "TIPO";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 90;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "REFERENCIA";
            this.dataGridViewTextBoxColumn15.HeaderText = "REFERENCIA";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 90;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ESTATUSDOCTOID";
            this.dataGridViewTextBoxColumn11.HeaderText = "ESTATUSDOCTOID";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TURNO";
            this.dataGridViewTextBoxColumn6.HeaderText = "TURNO";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SUCURSALID";
            this.dataGridViewTextBoxColumn3.HeaderText = "SUCURSALID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CAJAID";
            this.dataGridViewTextBoxColumn5.HeaderText = "CAJAID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "TURNOID";
            this.dataGridViewTextBoxColumn7.HeaderText = "TURNOID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "TIPODOCTOID";
            this.dataGridViewTextBoxColumn12.HeaderText = "TIPODOCTOID";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // WFLookUpCompraSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(906, 406);
            this.Controls.Add(this.transaccionesListaDataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "WFLookUpCompraSucursales";
            this.Text = "WFLookUpCompraSucursales";
            this.Load += new System.EventHandler(this.WFLookUpCompraSucursales_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transaccionesListaExtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReimpresionTicket2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transaccionesListaDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox CBSucursal;
        private System.Windows.Forms.CheckBox CBFecha;
        private System.Windows.Forms.Label SUCURSALIDLabel;
        private System.Windows.Forms.Button BTBuscar;
        private System.Windows.Forms.Button SUCURSALIDButton;
        private Tools.TextBoxFB SUCURSALIDTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private ReimpresionTicket.DSReimpresionTicket2 dSReimpresionTicket2;
        private System.Windows.Forms.BindingSource transaccionesListaExtBindingSource;
        private ReimpresionTicket.DSReimpresionTicket2TableAdapters.TransaccionesListaExtTableAdapter transaccionesListaExtTableAdapter;
        private ReimpresionTicket.DSReimpresionTicket2TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum transaccionesListaDataGridView;
        private System.Windows.Forms.Button ITEMButton;
        private Tools.TextBoxFB ITEMIDTextBox;
        private System.Windows.Forms.Label ITEMLabel;
        private System.Windows.Forms.CheckBox CBProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGSUCDESTNOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPERSONANOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOLIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
    }
}