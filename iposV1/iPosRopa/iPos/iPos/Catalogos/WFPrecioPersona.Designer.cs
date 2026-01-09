namespace iPos
{
    partial class WFPrecioPersona
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPrecioPersona));
            this.ITEMButton = new System.Windows.Forms.Button();
            this.ITEMLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LBProductoDescripcion = new System.Windows.Forms.Label();
            this.BTGuardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PRECIO1Lbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pRECIO5Label = new System.Windows.Forms.Label();
            this.pRECIO4Label = new System.Windows.Forms.Label();
            this.pRECIO3Label = new System.Windows.Forms.Label();
            this.pRECIO2Label = new System.Windows.Forms.Label();
            this.PRECIO4Lbl = new System.Windows.Forms.Label();
            this.PRECIO2Lbl = new System.Windows.Forms.Label();
            this.PRECIO5Lbl = new System.Windows.Forms.Label();
            this.PRECIO3Lbl = new System.Windows.Forms.Label();
            this.PRECIO1TextBox = new System.Windows.Forms.NumericTextBox();
            this.ITEMIDTextBox = new iPos.Tools.TextBoxFB();
            this.pRECIOPERSONADataGridView = new System.Windows.Forms.DataGridViewSum();
            this.pRECIOPERSONABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCatalogos = new iPos.Catalogos.DSCatalogos();
            this.pRECIOPERSONATableAdapter = new iPos.Catalogos.DSCatalogosTableAdapters.PRECIOPERSONATableAdapter();
            this.tableAdapterManager = new iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.CBEnviarExistencia = new System.Windows.Forms.CheckBox();
            this.BTImprimir = new System.Windows.Forms.Button();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTOCLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIO1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIOPERSONACONIMPUESTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIO1CONIMPUESTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGEDITAR = new System.Windows.Forms.DataGridViewImageColumn();
            this.DGELIMINAR = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pRECIOPERSONADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRECIOPERSONABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).BeginInit();
            this.SuspendLayout();
            // 
            // ITEMButton
            // 
            this.ITEMButton.BackColor = System.Drawing.Color.Transparent;
            this.ITEMButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(202, 42);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(23, 23);
            this.ITEMButton.TabIndex = 178;
            this.ITEMButton.UseVisualStyleBackColor = false;
            this.ITEMButton.Click += new System.EventHandler(this.ITEMButton_Click);
            // 
            // ITEMLabel
            // 
            this.ITEMLabel.AutoSize = true;
            this.ITEMLabel.BackColor = System.Drawing.Color.Transparent;
            this.ITEMLabel.ForeColor = System.Drawing.Color.White;
            this.ITEMLabel.Location = new System.Drawing.Point(231, 47);
            this.ITEMLabel.Name = "ITEMLabel";
            this.ITEMLabel.Size = new System.Drawing.Size(16, 13);
            this.ITEMLabel.TabIndex = 180;
            this.ITEMLabel.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(22, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 179;
            this.label4.Text = "Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(32, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 13);
            this.label1.TabIndex = 181;
            this.label1.Text = "ASIGNAR PRECIOS ESPECIFICOS A CLIENTE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(22, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 253;
            this.label2.Text = "Codigo";
            // 
            // TBCodigo
            // 
            this.TBCodigo.Location = new System.Drawing.Point(103, 86);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(100, 20);
            this.TBCodigo.TabIndex = 252;
            this.TBCodigo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TBCodigo_PreviewKeyDown);
            this.TBCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.TBCodigo_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(22, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 254;
            this.label6.Text = "Descripción:";
            // 
            // LBProductoDescripcion
            // 
            this.LBProductoDescripcion.AutoSize = true;
            this.LBProductoDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.LBProductoDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBProductoDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LBProductoDescripcion.Location = new System.Drawing.Point(122, 136);
            this.LBProductoDescripcion.Name = "LBProductoDescripcion";
            this.LBProductoDescripcion.Size = new System.Drawing.Size(19, 13);
            this.LBProductoDescripcion.TabIndex = 255;
            this.LBProductoDescripcion.Text = "...";
            // 
            // BTGuardar
            // 
            this.BTGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTGuardar.ForeColor = System.Drawing.Color.White;
            this.BTGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTGuardar.Location = new System.Drawing.Point(586, 86);
            this.BTGuardar.Name = "BTGuardar";
            this.BTGuardar.Size = new System.Drawing.Size(100, 27);
            this.BTGuardar.TabIndex = 261;
            this.BTGuardar.Text = "Guardar";
            this.BTGuardar.UseVisualStyleBackColor = false;
            this.BTGuardar.Click += new System.EventHandler(this.BTGuardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(259, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 256;
            this.label3.Text = "Precio 1 c/imp:";
            // 
            // PRECIO1Lbl
            // 
            this.PRECIO1Lbl.AutoSize = true;
            this.PRECIO1Lbl.BackColor = System.Drawing.Color.Transparent;
            this.PRECIO1Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRECIO1Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PRECIO1Lbl.Location = new System.Drawing.Point(422, 134);
            this.PRECIO1Lbl.Name = "PRECIO1Lbl";
            this.PRECIO1Lbl.Size = new System.Drawing.Size(19, 13);
            this.PRECIO1Lbl.TabIndex = 257;
            this.PRECIO1Lbl.Text = "...";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label12.Location = new System.Drawing.Point(259, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 13);
            this.label12.TabIndex = 260;
            this.label12.Text = "Precio asignado c/imp:";
            // 
            // pRECIO5Label
            // 
            this.pRECIO5Label.AutoSize = true;
            this.pRECIO5Label.BackColor = System.Drawing.Color.Transparent;
            this.pRECIO5Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.pRECIO5Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pRECIO5Label.Location = new System.Drawing.Point(583, 166);
            this.pRECIO5Label.Name = "pRECIO5Label";
            this.pRECIO5Label.Size = new System.Drawing.Size(94, 13);
            this.pRECIO5Label.TabIndex = 265;
            this.pRECIO5Label.Text = "Precio 5 c/imp:";
            // 
            // pRECIO4Label
            // 
            this.pRECIO4Label.AutoSize = true;
            this.pRECIO4Label.BackColor = System.Drawing.Color.Transparent;
            this.pRECIO4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.pRECIO4Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pRECIO4Label.Location = new System.Drawing.Point(259, 166);
            this.pRECIO4Label.Name = "pRECIO4Label";
            this.pRECIO4Label.Size = new System.Drawing.Size(94, 13);
            this.pRECIO4Label.TabIndex = 264;
            this.pRECIO4Label.Text = "Precio 4 c/imp:";
            // 
            // pRECIO3Label
            // 
            this.pRECIO3Label.AutoSize = true;
            this.pRECIO3Label.BackColor = System.Drawing.Color.Transparent;
            this.pRECIO3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.pRECIO3Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pRECIO3Label.Location = new System.Drawing.Point(22, 167);
            this.pRECIO3Label.Name = "pRECIO3Label";
            this.pRECIO3Label.Size = new System.Drawing.Size(94, 13);
            this.pRECIO3Label.TabIndex = 263;
            this.pRECIO3Label.Text = "Precio 3 c/imp:";
            // 
            // pRECIO2Label
            // 
            this.pRECIO2Label.AutoSize = true;
            this.pRECIO2Label.BackColor = System.Drawing.Color.Transparent;
            this.pRECIO2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.pRECIO2Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pRECIO2Label.Location = new System.Drawing.Point(583, 134);
            this.pRECIO2Label.Name = "pRECIO2Label";
            this.pRECIO2Label.Size = new System.Drawing.Size(94, 13);
            this.pRECIO2Label.TabIndex = 262;
            this.pRECIO2Label.Text = "Precio 2 c/imp:";
            // 
            // PRECIO4Lbl
            // 
            this.PRECIO4Lbl.AutoSize = true;
            this.PRECIO4Lbl.BackColor = System.Drawing.Color.Transparent;
            this.PRECIO4Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRECIO4Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PRECIO4Lbl.Location = new System.Drawing.Point(422, 166);
            this.PRECIO4Lbl.Name = "PRECIO4Lbl";
            this.PRECIO4Lbl.Size = new System.Drawing.Size(19, 13);
            this.PRECIO4Lbl.TabIndex = 270;
            this.PRECIO4Lbl.Text = "...";
            // 
            // PRECIO2Lbl
            // 
            this.PRECIO2Lbl.AutoSize = true;
            this.PRECIO2Lbl.BackColor = System.Drawing.Color.Transparent;
            this.PRECIO2Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRECIO2Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PRECIO2Lbl.Location = new System.Drawing.Point(683, 136);
            this.PRECIO2Lbl.Name = "PRECIO2Lbl";
            this.PRECIO2Lbl.Size = new System.Drawing.Size(19, 13);
            this.PRECIO2Lbl.TabIndex = 269;
            this.PRECIO2Lbl.Text = "...";
            // 
            // PRECIO5Lbl
            // 
            this.PRECIO5Lbl.AutoSize = true;
            this.PRECIO5Lbl.BackColor = System.Drawing.Color.Transparent;
            this.PRECIO5Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRECIO5Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PRECIO5Lbl.Location = new System.Drawing.Point(683, 164);
            this.PRECIO5Lbl.Name = "PRECIO5Lbl";
            this.PRECIO5Lbl.Size = new System.Drawing.Size(19, 13);
            this.PRECIO5Lbl.TabIndex = 268;
            this.PRECIO5Lbl.Text = "...";
            // 
            // PRECIO3Lbl
            // 
            this.PRECIO3Lbl.AutoSize = true;
            this.PRECIO3Lbl.BackColor = System.Drawing.Color.Transparent;
            this.PRECIO3Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRECIO3Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PRECIO3Lbl.Location = new System.Drawing.Point(122, 166);
            this.PRECIO3Lbl.Name = "PRECIO3Lbl";
            this.PRECIO3Lbl.Size = new System.Drawing.Size(19, 13);
            this.PRECIO3Lbl.TabIndex = 267;
            this.PRECIO3Lbl.Text = "...";
            // 
            // PRECIO1TextBox
            // 
            this.PRECIO1TextBox.AllowNegative = true;
            this.PRECIO1TextBox.Format_Expression = null;
            this.PRECIO1TextBox.Location = new System.Drawing.Point(421, 86);
            this.PRECIO1TextBox.Name = "PRECIO1TextBox";
            this.PRECIO1TextBox.NumericPrecision = 18;
            this.PRECIO1TextBox.NumericScaleOnFocus = 2;
            this.PRECIO1TextBox.NumericScaleOnLostFocus = 2;
            this.PRECIO1TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PRECIO1TextBox.Size = new System.Drawing.Size(100, 20);
            this.PRECIO1TextBox.TabIndex = 258;
            this.PRECIO1TextBox.Tag = 34;
            this.PRECIO1TextBox.Text = "0.00";
            this.PRECIO1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PRECIO1TextBox.ValidationExpression = null;
            this.PRECIO1TextBox.ZeroIsValid = true;
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
            this.ITEMIDTextBox.Location = new System.Drawing.Point(103, 43);
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
            this.ITEMIDTextBox.TabIndex = 177;
            this.ITEMIDTextBox.Tag = 34;
            this.ITEMIDTextBox.TextDescription = null;
            this.ITEMIDTextBox.Titulo = "Clientes";
            this.ITEMIDTextBox.ValidarEntrada = true;
            this.ITEMIDTextBox.ValidationExpression = null;
            // 
            // pRECIOPERSONADataGridView
            // 
            this.pRECIOPERSONADataGridView.AllowUserToAddRows = false;
            this.pRECIOPERSONADataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pRECIOPERSONADataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pRECIOPERSONADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pRECIOPERSONADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.PRODUCTOCLAVE,
            this.DESCRIPCION,
            this.DESCRIPCION1,
            this.dataGridViewTextBoxColumn9,
            this.PRECIO1,
            this.PRECIOPERSONACONIMPUESTO,
            this.PRECIO1CONIMPUESTO,
            this.DGEDITAR,
            this.DGELIMINAR});
            this.pRECIOPERSONADataGridView.DataSource = this.pRECIOPERSONABindingSource;
            this.pRECIOPERSONADataGridView.Location = new System.Drawing.Point(3, 187);
            this.pRECIOPERSONADataGridView.Name = "pRECIOPERSONADataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pRECIOPERSONADataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.pRECIOPERSONADataGridView.RowHeadersVisible = false;
            this.pRECIOPERSONADataGridView.Size = new System.Drawing.Size(812, 220);
            this.pRECIOPERSONADataGridView.TabIndex = 272;
            this.pRECIOPERSONADataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pRECIOPERSONADataGridView_CellContentClick);
            // 
            // pRECIOPERSONABindingSource
            // 
            this.pRECIOPERSONABindingSource.DataMember = "PRECIOPERSONA";
            this.pRECIOPERSONABindingSource.DataSource = this.dSCatalogos;
            // 
            // dSCatalogos
            // 
            this.dSCatalogos.DataSetName = "DSCatalogos";
            this.dSCatalogos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pRECIOPERSONATableAdapter
            // 
            this.pRECIOPERSONATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.LINEA_VIEWTableAdapter = null;
            this.tableAdapterManager.PERSONAAPARTADOTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.Location = new System.Drawing.Point(447, 430);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(157, 27);
            this.btnEnviar.TabIndex = 273;
            this.btnEnviar.Text = "Enviar por correo";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // CBEnviarExistencia
            // 
            this.CBEnviarExistencia.AutoSize = true;
            this.CBEnviarExistencia.BackColor = System.Drawing.Color.Transparent;
            this.CBEnviarExistencia.ForeColor = System.Drawing.Color.White;
            this.CBEnviarExistencia.Location = new System.Drawing.Point(332, 436);
            this.CBEnviarExistencia.Name = "CBEnviarExistencia";
            this.CBEnviarExistencia.Size = new System.Drawing.Size(107, 17);
            this.CBEnviarExistencia.TabIndex = 274;
            this.CBEnviarExistencia.Text = "Enviar Existencia";
            this.CBEnviarExistencia.UseVisualStyleBackColor = false;
            // 
            // BTImprimir
            // 
            this.BTImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTImprimir.ForeColor = System.Drawing.Color.White;
            this.BTImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTImprimir.Location = new System.Drawing.Point(642, 430);
            this.BTImprimir.Name = "BTImprimir";
            this.BTImprimir.Size = new System.Drawing.Size(157, 27);
            this.BTImprimir.TabIndex = 275;
            this.BTImprimir.Text = "Imprimir";
            this.BTImprimir.UseVisualStyleBackColor = false;
            this.BTImprimir.Click += new System.EventHandler(this.BTImprimir_Click);
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
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PERSONAID";
            this.dataGridViewTextBoxColumn7.HeaderText = "PERSONAID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PRODUCTOID";
            this.dataGridViewTextBoxColumn8.HeaderText = "PRODUCTOID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // PRODUCTOCLAVE
            // 
            this.PRODUCTOCLAVE.DataPropertyName = "PRODUCTOCLAVE";
            this.PRODUCTOCLAVE.HeaderText = "PRODUCTO";
            this.PRODUCTOCLAVE.Name = "PRODUCTOCLAVE";
            this.PRODUCTOCLAVE.Width = 80;
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.DataPropertyName = "DESCRIPCION";
            this.DESCRIPCION.HeaderText = "DESCRIPCION";
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.Width = 130;
            // 
            // DESCRIPCION1
            // 
            this.DESCRIPCION1.DataPropertyName = "DESCRIPCION1";
            this.DESCRIPCION1.HeaderText = "DESCRIPCION1";
            this.DESCRIPCION1.Name = "DESCRIPCION1";
            this.DESCRIPCION1.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "PRECIO";
            this.dataGridViewTextBoxColumn9.HeaderText = "PRECIO CLIENTE";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 90;
            // 
            // PRECIO1
            // 
            this.PRECIO1.DataPropertyName = "PRECIO1";
            this.PRECIO1.HeaderText = "PRECIO1  NORMAL";
            this.PRECIO1.Name = "PRECIO1";
            this.PRECIO1.Width = 90;
            // 
            // PRECIOPERSONACONIMPUESTO
            // 
            this.PRECIOPERSONACONIMPUESTO.DataPropertyName = "PRECIOPERSONACONIMPUESTO";
            dataGridViewCellStyle2.Format = "N2";
            this.PRECIOPERSONACONIMPUESTO.DefaultCellStyle = dataGridViewCellStyle2;
            this.PRECIOPERSONACONIMPUESTO.HeaderText = "PRECIO CLIENTE C/I";
            this.PRECIOPERSONACONIMPUESTO.Name = "PRECIOPERSONACONIMPUESTO";
            this.PRECIOPERSONACONIMPUESTO.ReadOnly = true;
            this.PRECIOPERSONACONIMPUESTO.Width = 90;
            // 
            // PRECIO1CONIMPUESTO
            // 
            this.PRECIO1CONIMPUESTO.DataPropertyName = "PRECIO1CONIMPUESTO";
            dataGridViewCellStyle3.Format = "N2";
            this.PRECIO1CONIMPUESTO.DefaultCellStyle = dataGridViewCellStyle3;
            this.PRECIO1CONIMPUESTO.HeaderText = "PRECIO1 NORMAL C/I";
            this.PRECIO1CONIMPUESTO.Name = "PRECIO1CONIMPUESTO";
            this.PRECIO1CONIMPUESTO.Width = 90;
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
            // WFPrecioPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(820, 469);
            this.Controls.Add(this.BTImprimir);
            this.Controls.Add(this.CBEnviarExistencia);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.pRECIOPERSONADataGridView);
            this.Controls.Add(this.pRECIO5Label);
            this.Controls.Add(this.pRECIO4Label);
            this.Controls.Add(this.pRECIO3Label);
            this.Controls.Add(this.pRECIO2Label);
            this.Controls.Add(this.PRECIO4Lbl);
            this.Controls.Add(this.PRECIO2Lbl);
            this.Controls.Add(this.PRECIO5Lbl);
            this.Controls.Add(this.PRECIO3Lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBCodigo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LBProductoDescripcion);
            this.Controls.Add(this.BTGuardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PRECIO1Lbl);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.PRECIO1TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ITEMButton);
            this.Controls.Add(this.ITEMIDTextBox);
            this.Controls.Add(this.ITEMLabel);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFPrecioPersona";
            this.Text = "Precios cliente";
            this.Load += new System.EventHandler(this.WFPrecioPersona_Load);
            this.Shown += new System.EventHandler(this.WFPrecioPersona_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pRECIOPERSONADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRECIOPERSONABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ITEMButton;
        private Tools.TextBoxFB ITEMIDTextBox;
        private System.Windows.Forms.Label ITEMLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LBProductoDescripcion;
        private System.Windows.Forms.Button BTGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PRECIO1Lbl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericTextBox PRECIO1TextBox;
        private System.Windows.Forms.Label pRECIO5Label;
        private System.Windows.Forms.Label pRECIO4Label;
        private System.Windows.Forms.Label pRECIO3Label;
        private System.Windows.Forms.Label pRECIO2Label;
        private System.Windows.Forms.Label PRECIO4Lbl;
        private System.Windows.Forms.Label PRECIO2Lbl;
        private System.Windows.Forms.Label PRECIO5Lbl;
        private System.Windows.Forms.Label PRECIO3Lbl;
        private Catalogos.DSCatalogos dSCatalogos;
        private System.Windows.Forms.BindingSource pRECIOPERSONABindingSource;
        private Catalogos.DSCatalogosTableAdapters.PRECIOPERSONATableAdapter pRECIOPERSONATableAdapter;
        private Catalogos.DSCatalogosTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum pRECIOPERSONADataGridView;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.CheckBox CBEnviarExistencia;
        private System.Windows.Forms.Button BTImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTOCLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIOPERSONACONIMPUESTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO1CONIMPUESTO;
        private System.Windows.Forms.DataGridViewImageColumn DGEDITAR;
        private System.Windows.Forms.DataGridViewImageColumn DGELIMINAR;
    }
}