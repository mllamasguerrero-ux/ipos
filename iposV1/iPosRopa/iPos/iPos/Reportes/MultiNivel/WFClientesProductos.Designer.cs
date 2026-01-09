namespace iPos.Reportes.MultiNivel
{
    partial class WFClientesProductos
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
            System.Windows.Forms.Label pROVEEDOR1IDLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dSFastReports = new iPos.Reportes.DSFastReports();
            this.mOVIMIENTOSDETALLEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mOVIMIENTOSDETALLEFECHATableAdapter = new iPos.Reportes.DSFastReportsTableAdapters.MOVIMIENTOSDETALLEFECHATableAdapter();
            this.tableAdapterManager = new iPos.Reportes.DSFastReportsTableAdapters.TableAdapterManager();
            this.label1 = new System.Windows.Forms.Label();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BTMostrar = new System.Windows.Forms.Button();
            this.BTImprimir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PERSONAIDButton = new System.Windows.Forms.Button();
            this.PERSONALabel = new System.Windows.Forms.Label();
            this.PERSONAIDTextBox = new iPos.Tools.TextBoxFB();
            this.mOVIMIENTOSDETALLEDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPRECIOCONIMPUESTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            pROVEEDOR1IDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSFastReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mOVIMIENTOSDETALLEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mOVIMIENTOSDETALLEDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pROVEEDOR1IDLabel
            // 
            pROVEEDOR1IDLabel.AutoSize = true;
            pROVEEDOR1IDLabel.BackColor = System.Drawing.Color.Transparent;
            pROVEEDOR1IDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pROVEEDOR1IDLabel.ForeColor = System.Drawing.Color.White;
            pROVEEDOR1IDLabel.Location = new System.Drawing.Point(112, 83);
            pROVEEDOR1IDLabel.Name = "pROVEEDOR1IDLabel";
            pROVEEDOR1IDLabel.Size = new System.Drawing.Size(50, 13);
            pROVEEDOR1IDLabel.TabIndex = 173;
            pROVEEDOR1IDLabel.Text = "Cliente:";
            // 
            // dSFastReports
            // 
            this.dSFastReports.DataSetName = "DSFastReports";
            this.dSFastReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mOVIMIENTOSDETALLEBindingSource
            // 
            this.mOVIMIENTOSDETALLEBindingSource.DataMember = "MOVIMIENTOSDETALLEFECHA";
            this.mOVIMIENTOSDETALLEBindingSource.DataSource = this.dSFastReports;
            // 
            // mOVIMIENTOSDETALLEFECHATableAdapter
            // 
            this.mOVIMIENTOSDETALLEFECHATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Reportes.DSFastReportsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(112, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 164;
            this.label1.Text = "Desde:";
            // 
            // DTPFrom
            // 
            this.DTPFrom.Location = new System.Drawing.Point(165, 45);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(200, 20);
            this.DTPFrom.TabIndex = 166;
            // 
            // DTPTo
            // 
            this.DTPTo.Location = new System.Drawing.Point(405, 45);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(200, 20);
            this.DTPTo.TabIndex = 167;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(380, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 165;
            this.label2.Text = "A:";
            // 
            // BTMostrar
            // 
            this.BTMostrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTMostrar.ForeColor = System.Drawing.Color.White;
            this.BTMostrar.Location = new System.Drawing.Point(638, 45);
            this.BTMostrar.Name = "BTMostrar";
            this.BTMostrar.Size = new System.Drawing.Size(87, 23);
            this.BTMostrar.TabIndex = 168;
            this.BTMostrar.Text = "Mostrar";
            this.BTMostrar.UseVisualStyleBackColor = false;
            this.BTMostrar.Click += new System.EventHandler(this.BTMostrar_Click);
            // 
            // BTImprimir
            // 
            this.BTImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTImprimir.ForeColor = System.Drawing.Color.White;
            this.BTImprimir.Location = new System.Drawing.Point(745, 45);
            this.BTImprimir.Name = "BTImprimir";
            this.BTImprimir.Size = new System.Drawing.Size(87, 23);
            this.BTImprimir.TabIndex = 169;
            this.BTImprimir.Text = "Imprimir";
            this.BTImprimir.UseVisualStyleBackColor = false;
            this.BTImprimir.Click += new System.EventHandler(this.BTImprimir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 16);
            this.label3.TabIndex = 170;
            this.label3.Text = "Detalles de ventas y NC de clientes";
            // 
            // PERSONAIDButton
            // 
            this.PERSONAIDButton.BackColor = System.Drawing.Color.Transparent;
            this.PERSONAIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.PERSONAIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PERSONAIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PERSONAIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PERSONAIDButton.Location = new System.Drawing.Point(256, 78);
            this.PERSONAIDButton.Name = "PERSONAIDButton";
            this.PERSONAIDButton.Size = new System.Drawing.Size(21, 23);
            this.PERSONAIDButton.TabIndex = 172;
            this.PERSONAIDButton.UseVisualStyleBackColor = false;
            // 
            // PERSONALabel
            // 
            this.PERSONALabel.AutoSize = true;
            this.PERSONALabel.BackColor = System.Drawing.Color.Transparent;
            this.PERSONALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PERSONALabel.ForeColor = System.Drawing.Color.White;
            this.PERSONALabel.Location = new System.Drawing.Point(283, 83);
            this.PERSONALabel.Name = "PERSONALabel";
            this.PERSONALabel.Size = new System.Drawing.Size(19, 13);
            this.PERSONALabel.TabIndex = 174;
            this.PERSONALabel.Text = "...";
            // 
            // PERSONAIDTextBox
            // 
            this.PERSONAIDTextBox.BotonLookUp = this.PERSONAIDButton;
            this.PERSONAIDTextBox.Condicion = null;
            this.PERSONAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PERSONAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PERSONAIDTextBox.DbValue = null;
            this.PERSONAIDTextBox.Format_Expression = null;
            this.PERSONAIDTextBox.IndiceCampoDescripcion = 2;
            this.PERSONAIDTextBox.IndiceCampoSelector = 1;
            this.PERSONAIDTextBox.IndiceCampoValue = 0;
            this.PERSONAIDTextBox.LabelDescription = this.PERSONALabel;
            this.PERSONAIDTextBox.Location = new System.Drawing.Point(168, 80);
            this.PERSONAIDTextBox.MostrarErrores = true;
            this.PERSONAIDTextBox.Name = "PERSONAIDTextBox";
            this.PERSONAIDTextBox.NombreCampoSelector = "clave";
            this.PERSONAIDTextBox.NombreCampoValue = "id";
            this.PERSONAIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 50";
            this.PERSONAIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 50 and  clave = @clave";
            this.PERSONAIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 50 and  id = @id";
            this.PERSONAIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.PERSONAIDTextBox.TabIndex = 171;
            this.PERSONAIDTextBox.Tag = 34;
            this.PERSONAIDTextBox.TextDescription = null;
            this.PERSONAIDTextBox.Titulo = "Clientes";
            this.PERSONAIDTextBox.ValidarEntrada = true;
            this.PERSONAIDTextBox.ValidationExpression = null;
            // 
            // mOVIMIENTOSDETALLEDataGridView
            // 
            this.mOVIMIENTOSDETALLEDataGridView.AllowUserToAddRows = false;
            this.mOVIMIENTOSDETALLEDataGridView.AutoGenerateColumns = false;
            this.mOVIMIENTOSDETALLEDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mOVIMIENTOSDETALLEDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.DESCRIPCION11,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.DGPRECIOCONIMPUESTO,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn40});
            this.mOVIMIENTOSDETALLEDataGridView.DataSource = this.mOVIMIENTOSDETALLEBindingSource;
            this.mOVIMIENTOSDETALLEDataGridView.Location = new System.Drawing.Point(12, 119);
            this.mOVIMIENTOSDETALLEDataGridView.Name = "mOVIMIENTOSDETALLEDataGridView";
            this.mOVIMIENTOSDETALLEDataGridView.ReadOnly = true;
            this.mOVIMIENTOSDETALLEDataGridView.RowHeadersVisible = false;
            this.mOVIMIENTOSDETALLEDataGridView.Size = new System.Drawing.Size(1001, 306);
            this.mOVIMIENTOSDETALLEDataGridView.TabIndex = 163;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "TIPODOC";
            this.dataGridViewTextBoxColumn25.HeaderText = "TIPO";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.Width = 75;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn12.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 75;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "FECHAHORA";
            this.dataGridViewTextBoxColumn13.HeaderText = "FECHAHORA";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "FOLIO";
            this.dataGridViewTextBoxColumn14.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 75;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn15.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 80;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn16.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // DESCRIPCION11
            // 
            this.DESCRIPCION11.DataPropertyName = "DESCRIPCION11";
            this.DESCRIPCION11.HeaderText = "DESC.REFERENCIA";
            this.DESCRIPCION11.Name = "DESCRIPCION11";
            this.DESCRIPCION11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "CANTIDAD";
            this.dataGridViewTextBoxColumn17.HeaderText = "CANT.";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 75;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "PRECIO";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn18.HeaderText = "PRECIO";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 80;
            // 
            // DGPRECIOCONIMPUESTO
            // 
            this.DGPRECIOCONIMPUESTO.DataPropertyName = "PRECIOCONIMPUESTO";
            this.DGPRECIOCONIMPUESTO.HeaderText = "PRECIO C/I";
            this.DGPRECIOCONIMPUESTO.Name = "DGPRECIOCONIMPUESTO";
            this.DGPRECIOCONIMPUESTO.ReadOnly = true;
            this.DGPRECIOCONIMPUESTO.Width = 80;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "IMPORTE";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn19.HeaderText = "IMPORTE";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 80;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "DESCUENTO";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.dataGridViewTextBoxColumn20.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn20.HeaderText = "DESCUENTO";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 70;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "SUBTOTAL";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.dataGridViewTextBoxColumn21.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn21.HeaderText = "SUBTOTAL";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 80;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "IVA";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.dataGridViewTextBoxColumn22.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn22.HeaderText = "IVA";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 75;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "TOTAL";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            this.dataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn23.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 80;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "SUCURSALT";
            this.dataGridViewTextBoxColumn24.HeaderText = "SUCURSALT";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Visible = false;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "PERSONA";
            this.dataGridViewTextBoxColumn26.HeaderText = "PERSONA";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.Visible = false;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "PRECIOMANUALMASBAJO";
            this.dataGridViewTextBoxColumn27.HeaderText = "Abajo de precio?";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            this.dataGridViewTextBoxColumn27.Width = 75;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "RAZONDESCUENTOCAJERO";
            this.dataGridViewTextBoxColumn28.HeaderText = "RAZON ABAJO DE PRECIO";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            this.dataGridViewTextBoxColumn28.Width = 150;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "NOMBREVENDEDOR";
            this.dataGridViewTextBoxColumn40.HeaderText = "CAJERO";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            // 
            // WFClientesProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(1029, 450);
            this.Controls.Add(this.PERSONAIDButton);
            this.Controls.Add(this.PERSONAIDTextBox);
            this.Controls.Add(this.PERSONALabel);
            this.Controls.Add(pROVEEDOR1IDLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BTImprimir);
            this.Controls.Add(this.BTMostrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTPFrom);
            this.Controls.Add(this.DTPTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mOVIMIENTOSDETALLEDataGridView);
            this.Name = "WFClientesProductos";
            this.Text = "Detalles de ventas y NC de clientes";
            this.Load += new System.EventHandler(this.WFClientesProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSFastReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mOVIMIENTOSDETALLEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mOVIMIENTOSDETALLEDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSFastReports dSFastReports;
        private System.Windows.Forms.BindingSource mOVIMIENTOSDETALLEBindingSource;
        private DSFastReportsTableAdapters.MOVIMIENTOSDETALLEFECHATableAdapter mOVIMIENTOSDETALLEFECHATableAdapter;
        private DSFastReportsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum mOVIMIENTOSDETALLEDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTMostrar;
        private System.Windows.Forms.Button BTImprimir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button PERSONAIDButton;
        private Tools.TextBoxFB PERSONAIDTextBox;
        private System.Windows.Forms.Label PERSONALabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPRECIOCONIMPUESTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
    }
}