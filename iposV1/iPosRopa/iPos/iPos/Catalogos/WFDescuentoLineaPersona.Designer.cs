namespace iPos.Catalogos
{
    partial class WFDescuentoLineaPersona
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFDescuentoLineaPersona));
            this.BTGuardar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ITEMButton = new System.Windows.Forms.Button();
            this.ITEMLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLinea = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dSCatalogos = new iPos.Catalogos.DSCatalogos();
            this.dESCUENTOLINEAPERSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dESCUENTOLINEAPERSTableAdapter = new iPos.Catalogos.DSCatalogosTableAdapters.DESCUENTOLINEAPERSTableAdapter();
            this.tableAdapterManager = new iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager();
            this.dESCUENTOLINEAPERSDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLinea = new iPos.Tools.TextBoxFB();
            this.txtDescuento = new System.Windows.Forms.NumericTextBox();
            this.ITEMIDTextBox = new iPos.Tools.TextBoxFB();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLINEAID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINEACLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLINEANOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGEDITAR = new System.Windows.Forms.DataGridViewImageColumn();
            this.DGELIMINAR = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESCUENTOLINEAPERSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESCUENTOLINEAPERSDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BTGuardar
            // 
            this.BTGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTGuardar.ForeColor = System.Drawing.Color.White;
            this.BTGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTGuardar.Location = new System.Drawing.Point(392, 163);
            this.BTGuardar.Name = "BTGuardar";
            this.BTGuardar.Size = new System.Drawing.Size(100, 27);
            this.BTGuardar.TabIndex = 282;
            this.BTGuardar.Text = "Guardar";
            this.BTGuardar.UseVisualStyleBackColor = false;
            this.BTGuardar.Click += new System.EventHandler(this.BTGuardar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(537, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 281;
            this.label12.Text = "Descuento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 16);
            this.label1.TabIndex = 277;
            this.label1.Text = "Asignar descuento por linea al cliente";
            // 
            // ITEMButton
            // 
            this.ITEMButton.BackColor = System.Drawing.Color.Transparent;
            this.ITEMButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(236, 70);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(21, 23);
            this.ITEMButton.TabIndex = 274;
            this.ITEMButton.UseVisualStyleBackColor = false;
            this.ITEMButton.Click += new System.EventHandler(this.ITEMButton_Click);
            // 
            // ITEMLabel
            // 
            this.ITEMLabel.AutoSize = true;
            this.ITEMLabel.BackColor = System.Drawing.Color.Transparent;
            this.ITEMLabel.ForeColor = System.Drawing.Color.White;
            this.ITEMLabel.Location = new System.Drawing.Point(262, 75);
            this.ITEMLabel.Name = "ITEMLabel";
            this.ITEMLabel.Size = new System.Drawing.Size(16, 13);
            this.ITEMLabel.TabIndex = 276;
            this.ITEMLabel.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(79, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 275;
            this.label4.Text = "Cliente:";
            // 
            // btnLinea
            // 
            this.btnLinea.BackColor = System.Drawing.Color.Transparent;
            this.btnLinea.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.btnLinea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLinea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnLinea.Location = new System.Drawing.Point(703, 70);
            this.btnLinea.Name = "btnLinea";
            this.btnLinea.Size = new System.Drawing.Size(21, 23);
            this.btnLinea.TabIndex = 285;
            this.btnLinea.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(730, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 287;
            this.label3.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(558, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 286;
            this.label5.Text = "Linea:";
            // 
            // dSCatalogos
            // 
            this.dSCatalogos.DataSetName = "DSCatalogos";
            this.dSCatalogos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dESCUENTOLINEAPERSBindingSource
            // 
            this.dESCUENTOLINEAPERSBindingSource.DataMember = "DESCUENTOLINEAPERS";
            this.dESCUENTOLINEAPERSBindingSource.DataSource = this.dSCatalogos;
            // 
            // dESCUENTOLINEAPERSTableAdapter
            // 
            this.dESCUENTOLINEAPERSTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.LINEA_VIEWTableAdapter = null;
            this.tableAdapterManager.PERSONAAPARTADOTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dESCUENTOLINEAPERSDataGridView
            // 
            this.dESCUENTOLINEAPERSDataGridView.AllowUserToAddRows = false;
            this.dESCUENTOLINEAPERSDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dESCUENTOLINEAPERSDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dESCUENTOLINEAPERSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dESCUENTOLINEAPERSDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.dataGridViewTextBoxColumn13,
            this.GLINEAID,
            this.LINEACLAVE,
            this.GLINEANOMBRE,
            this.dataGridViewTextBoxColumn15,
            this.DGEDITAR,
            this.DGELIMINAR});
            this.dESCUENTOLINEAPERSDataGridView.DataSource = this.dESCUENTOLINEAPERSBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dESCUENTOLINEAPERSDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dESCUENTOLINEAPERSDataGridView.Location = new System.Drawing.Point(12, 210);
            this.dESCUENTOLINEAPERSDataGridView.Name = "dESCUENTOLINEAPERSDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dESCUENTOLINEAPERSDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dESCUENTOLINEAPERSDataGridView.RowHeadersVisible = false;
            this.dESCUENTOLINEAPERSDataGridView.Size = new System.Drawing.Size(787, 259);
            this.dESCUENTOLINEAPERSDataGridView.TabIndex = 289;
            this.dESCUENTOLINEAPERSDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dESCUENTOLINEAPERSDataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PRODUCTOCLAVE";
            this.dataGridViewTextBoxColumn1.HeaderText = "PRODUCTO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DESCRIPCION";
            this.dataGridViewTextBoxColumn2.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn3.HeaderText = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PRECIO1";
            this.dataGridViewTextBoxColumn4.HeaderText = "PRECIO1  NORMAL";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PRECIOPERSONACONIMPUESTO";
            dataGridViewCellStyle4.Format = "N2";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn5.HeaderText = "PRECIO CLIENTE C/I";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PRECIO1CONIMPUESTO";
            dataGridViewCellStyle5.Format = "N2";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn6.HeaderText = "PRECIO1 NORMAL C/I";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // txtLinea
            // 
            this.txtLinea.BotonLookUp = this.btnLinea;
            this.txtLinea.Condicion = null;
            this.txtLinea.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.txtLinea.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.txtLinea.DbValue = null;
            this.txtLinea.Format_Expression = null;
            this.txtLinea.IndiceCampoDescripcion = 2;
            this.txtLinea.IndiceCampoSelector = 1;
            this.txtLinea.IndiceCampoValue = 0;
            this.txtLinea.LabelDescription = this.label3;
            this.txtLinea.Location = new System.Drawing.Point(615, 72);
            this.txtLinea.MostrarErrores = true;
            this.txtLinea.Name = "txtLinea";
            this.txtLinea.NombreCampoSelector = "clave";
            this.txtLinea.NombreCampoValue = "id";
            this.txtLinea.Query = "select id,clave,nombre from linea";
            this.txtLinea.QueryDeSeleccion = "select id,clave,nombre from linea where clave = @clave";
            this.txtLinea.QueryPorDBValue = "select id,clave,nombre from linea where id = @id";
            this.txtLinea.Size = new System.Drawing.Size(82, 20);
            this.txtLinea.TabIndex = 284;
            this.txtLinea.Tag = 34;
            this.txtLinea.TextDescription = null;
            this.txtLinea.Titulo = "Lineas";
            this.txtLinea.ValidarEntrada = true;
            this.txtLinea.ValidationExpression = null;
            // 
            // txtDescuento
            // 
            this.txtDescuento.AllowNegative = true;
            this.txtDescuento.Format_Expression = null;
            this.txtDescuento.Location = new System.Drawing.Point(615, 113);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.NumericPrecision = 18;
            this.txtDescuento.NumericScaleOnFocus = 2;
            this.txtDescuento.NumericScaleOnLostFocus = 2;
            this.txtDescuento.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDescuento.Size = new System.Drawing.Size(109, 20);
            this.txtDescuento.TabIndex = 280;
            this.txtDescuento.Tag = 34;
            this.txtDescuento.Text = "0.00";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.ValidationExpression = null;
            this.txtDescuento.ZeroIsValid = true;
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
            this.ITEMIDTextBox.Location = new System.Drawing.Point(135, 72);
            this.ITEMIDTextBox.MostrarErrores = true;
            this.ITEMIDTextBox.Name = "ITEMIDTextBox";
            this.ITEMIDTextBox.NombreCampoSelector = "clave";
            this.ITEMIDTextBox.NombreCampoValue = "id";
            this.ITEMIDTextBox.Query = "select id, clave, nombre, gaffete from persona where tipopersonaid  in (50) ";
            this.ITEMIDTextBox.QueryDeSeleccion = "select id, clave, nombre, gaffete from persona where tipopersonaid  in (50) and  " +
    "clave= @clave";
            this.ITEMIDTextBox.QueryPorDBValue = "select id, clave ,nombre, gaffete from persona where tipopersonaid  in (50) and  " +
    "id = @id";
            this.ITEMIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.ITEMIDTextBox.TabIndex = 273;
            this.ITEMIDTextBox.Tag = 34;
            this.ITEMIDTextBox.TextDescription = null;
            this.ITEMIDTextBox.Titulo = "Clientes";
            this.ITEMIDTextBox.ValidarEntrada = true;
            this.ITEMIDTextBox.ValidationExpression = null;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "PERSONAID";
            this.dataGridViewTextBoxColumn13.HeaderText = "PERSONAID";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // GLINEAID
            // 
            this.GLINEAID.DataPropertyName = "LINEAID";
            this.GLINEAID.HeaderText = "LINEAID";
            this.GLINEAID.Name = "GLINEAID";
            // 
            // LINEACLAVE
            // 
            this.LINEACLAVE.DataPropertyName = "LINEACLAVE";
            this.LINEACLAVE.HeaderText = "LINEACLAVE";
            this.LINEACLAVE.Name = "LINEACLAVE";
            // 
            // GLINEANOMBRE
            // 
            this.GLINEANOMBRE.DataPropertyName = "NOMBRE";
            this.GLINEANOMBRE.HeaderText = "LINEA NOMBRE";
            this.GLINEANOMBRE.Name = "GLINEANOMBRE";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "DESCUENTO";
            this.dataGridViewTextBoxColumn15.HeaderText = "DESCUENTO";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // DGEDITAR
            // 
            this.DGEDITAR.HeaderText = "";
            this.DGEDITAR.Image = global::iPos.Properties.Resources.edit_J;
            this.DGEDITAR.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.DGEDITAR.Name = "DGEDITAR";
            this.DGEDITAR.Width = 30;
            // 
            // DGELIMINAR
            // 
            this.DGELIMINAR.HeaderText = "";
            this.DGELIMINAR.Image = global::iPos.Properties.Resources.close_J;
            this.DGELIMINAR.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.DGELIMINAR.Name = "DGELIMINAR";
            this.DGELIMINAR.Width = 30;
            // 
            // WFDescuentoLineaPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(820, 490);
            this.Controls.Add(this.dESCUENTOLINEAPERSDataGridView);
            this.Controls.Add(this.btnLinea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLinea);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BTGuardar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ITEMButton);
            this.Controls.Add(this.ITEMIDTextBox);
            this.Controls.Add(this.ITEMLabel);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFDescuentoLineaPersona";
            this.Text = "Descuento en Linea por Persona";
            this.Load += new System.EventHandler(this.WFDescuentoLineaPersona_Load);
            this.Shown += new System.EventHandler(this.WFDescuentoLineaPersona_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESCUENTOLINEAPERSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESCUENTOLINEAPERSDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTGuardar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ITEMButton;
        private Tools.TextBoxFB ITEMIDTextBox;
        private System.Windows.Forms.Label ITEMLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnLinea;
        private System.Windows.Forms.Label label3;
        private Tools.TextBoxFB txtLinea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericTextBox txtDescuento;
        private DSCatalogos dSCatalogos;
        private System.Windows.Forms.BindingSource dESCUENTOLINEAPERSBindingSource;
        private DSCatalogosTableAdapters.DESCUENTOLINEAPERSTableAdapter dESCUENTOLINEAPERSTableAdapter;
        private DSCatalogosTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum dESCUENTOLINEAPERSDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLINEAID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINEACLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLINEANOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewImageColumn DGEDITAR;
        private System.Windows.Forms.DataGridViewImageColumn DGELIMINAR;
    }
}