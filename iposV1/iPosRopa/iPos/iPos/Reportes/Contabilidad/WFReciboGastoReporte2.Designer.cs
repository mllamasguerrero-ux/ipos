namespace iPos.Reportes.Contabilidad
{
    partial class WFReciboGastoReporte2
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
            System.Windows.Forms.Label mARCAIDLabel;
            System.Windows.Forms.Label label7;
            this.CBTodosGastos = new System.Windows.Forms.CheckBox();
            this.GASTOButton = new System.Windows.Forms.Button();
            this.GASTOIDTextBox = new iPos.Tools.TextBoxFB();
            this.GASTOLabel = new System.Windows.Forms.Label();
            this.ITEMButton = new System.Windows.Forms.Button();
            this.ITEMIDTextBox = new iPos.Tools.TextBoxFB();
            this.ITEMLabel = new System.Windows.Forms.Label();
            this.CBSumarizado = new System.Windows.Forms.CheckBox();
            this.CBTodas = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.CBOrigenFiscal = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.ALMACENComboBox = new System.Windows.Forms.ComboBoxFB();
            this.CBTodosAlmacenes = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TIPOGASTOIDTextBox = new System.Windows.Forms.ComboBoxFB();
            this.CBTodosTipoGasto = new System.Windows.Forms.CheckBox();
            this.CENTROCOSTOButton = new System.Windows.Forms.Button();
            this.CENTROCOSTOIDTextBox = new iPos.Tools.TextBoxFB();
            this.CENTROCOSTOLabel = new System.Windows.Forms.Label();
            this.CBTodosCentroCosto = new System.Windows.Forms.CheckBox();
            mARCAIDLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mARCAIDLabel
            // 
            mARCAIDLabel.AutoSize = true;
            mARCAIDLabel.BackColor = System.Drawing.Color.Transparent;
            mARCAIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mARCAIDLabel.ForeColor = System.Drawing.Color.White;
            mARCAIDLabel.Location = new System.Drawing.Point(151, 151);
            mARCAIDLabel.Name = "mARCAIDLabel";
            mARCAIDLabel.Size = new System.Drawing.Size(44, 13);
            mARCAIDLabel.TabIndex = 196;
            mARCAIDLabel.Text = "Gasto:";
            // 
            // CBTodosGastos
            // 
            this.CBTodosGastos.AutoSize = true;
            this.CBTodosGastos.BackColor = System.Drawing.Color.Transparent;
            this.CBTodosGastos.ForeColor = System.Drawing.Color.White;
            this.CBTodosGastos.Location = new System.Drawing.Point(563, 158);
            this.CBTodosGastos.Name = "CBTodosGastos";
            this.CBTodosGastos.Size = new System.Drawing.Size(56, 17);
            this.CBTodosGastos.TabIndex = 198;
            this.CBTodosGastos.Text = "Todos";
            this.CBTodosGastos.UseVisualStyleBackColor = false;
            // 
            // GASTOButton
            // 
            this.GASTOButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.GASTOButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GASTOButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GASTOButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.GASTOButton.Location = new System.Drawing.Point(356, 149);
            this.GASTOButton.Name = "GASTOButton";
            this.GASTOButton.Size = new System.Drawing.Size(23, 23);
            this.GASTOButton.TabIndex = 195;
            this.GASTOButton.UseVisualStyleBackColor = true;
            // 
            // GASTOIDTextBox
            // 
            this.GASTOIDTextBox.BotonLookUp = null;
            this.GASTOIDTextBox.Condicion = null;
            this.GASTOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GASTOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GASTOIDTextBox.DbValue = null;
            this.GASTOIDTextBox.Format_Expression = null;
            this.GASTOIDTextBox.IndiceCampoDescripcion = 2;
            this.GASTOIDTextBox.IndiceCampoSelector = 1;
            this.GASTOIDTextBox.IndiceCampoValue = 0;
            this.GASTOIDTextBox.LabelDescription = this.GASTOLabel;
            this.GASTOIDTextBox.Location = new System.Drawing.Point(253, 151);
            this.GASTOIDTextBox.MostrarErrores = true;
            this.GASTOIDTextBox.Name = "GASTOIDTextBox";
            this.GASTOIDTextBox.NombreCampoSelector = "clave";
            this.GASTOIDTextBox.NombreCampoValue = "id";
            this.GASTOIDTextBox.Query = "select id,clave,nombre from gasto";
            this.GASTOIDTextBox.QueryDeSeleccion = "select id,clave,nombre from gasto where clave = @clave";
            this.GASTOIDTextBox.QueryPorDBValue = "select id,clave,nombre from gasto where id = @id";
            this.GASTOIDTextBox.Size = new System.Drawing.Size(99, 20);
            this.GASTOIDTextBox.TabIndex = 194;
            this.GASTOIDTextBox.Tag = 34;
            this.GASTOIDTextBox.TextDescription = null;
            this.GASTOIDTextBox.Titulo = "Gastos";
            this.GASTOIDTextBox.ValidarEntrada = true;
            this.GASTOIDTextBox.ValidationExpression = null;
            // 
            // GASTOLabel
            // 
            this.GASTOLabel.AutoSize = true;
            this.GASTOLabel.BackColor = System.Drawing.Color.Transparent;
            this.GASTOLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GASTOLabel.Location = new System.Drawing.Point(385, 154);
            this.GASTOLabel.Name = "GASTOLabel";
            this.GASTOLabel.Size = new System.Drawing.Size(16, 13);
            this.GASTOLabel.TabIndex = 197;
            this.GASTOLabel.Text = "...";
            // 
            // ITEMButton
            // 
            this.ITEMButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(356, 74);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(23, 23);
            this.ITEMButton.TabIndex = 184;
            this.ITEMButton.UseVisualStyleBackColor = true;
            // 
            // ITEMIDTextBox
            // 
            this.ITEMIDTextBox.BotonLookUp = this.ITEMButton;
            this.ITEMIDTextBox.Condicion = null;
            this.ITEMIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbValue = null;
            this.ITEMIDTextBox.Format_Expression = null;
            this.ITEMIDTextBox.IndiceCampoDescripcion = 2;
            this.ITEMIDTextBox.IndiceCampoSelector = 1;
            this.ITEMIDTextBox.IndiceCampoValue = 0;
            this.ITEMIDTextBox.LabelDescription = this.ITEMLabel;
            this.ITEMIDTextBox.Location = new System.Drawing.Point(257, 77);
            this.ITEMIDTextBox.MostrarErrores = true;
            this.ITEMIDTextBox.Name = "ITEMIDTextBox";
            this.ITEMIDTextBox.NombreCampoSelector = "clave";
            this.ITEMIDTextBox.NombreCampoValue = "id";
            this.ITEMIDTextBox.Query = "select id,USERNAME as clave, nombre from persona where ACTIVO = \'S\' and username " +
    "is not null";
            this.ITEMIDTextBox.QueryDeSeleccion = "select id,USERNAME as clave, nombre from persona where ACTIVO = \'S\' and username " +
    "is not null and  clave= @clave";
            this.ITEMIDTextBox.QueryPorDBValue = "select id,USERNAME as clave, nombre from persona where ACTIVO = \'S\' and username " +
    "is not null and  id = @id";
            this.ITEMIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.ITEMIDTextBox.TabIndex = 183;
            this.ITEMIDTextBox.Tag = 34;
            this.ITEMIDTextBox.TextDescription = null;
            this.ITEMIDTextBox.Titulo = "Cajeros";
            this.ITEMIDTextBox.ValidarEntrada = true;
            this.ITEMIDTextBox.ValidationExpression = null;
            // 
            // ITEMLabel
            // 
            this.ITEMLabel.AutoSize = true;
            this.ITEMLabel.BackColor = System.Drawing.Color.Transparent;
            this.ITEMLabel.ForeColor = System.Drawing.Color.White;
            this.ITEMLabel.Location = new System.Drawing.Point(385, 80);
            this.ITEMLabel.Name = "ITEMLabel";
            this.ITEMLabel.Size = new System.Drawing.Size(16, 13);
            this.ITEMLabel.TabIndex = 193;
            this.ITEMLabel.Text = "...";
            // 
            // CBSumarizado
            // 
            this.CBSumarizado.AutoSize = true;
            this.CBSumarizado.BackColor = System.Drawing.Color.Transparent;
            this.CBSumarizado.ForeColor = System.Drawing.Color.White;
            this.CBSumarizado.Location = new System.Drawing.Point(722, 84);
            this.CBSumarizado.Name = "CBSumarizado";
            this.CBSumarizado.Size = new System.Drawing.Size(81, 17);
            this.CBSumarizado.TabIndex = 187;
            this.CBSumarizado.Text = "Sumarizado";
            this.CBSumarizado.UseVisualStyleBackColor = false;
            // 
            // CBTodas
            // 
            this.CBTodas.AutoSize = true;
            this.CBTodas.BackColor = System.Drawing.Color.Transparent;
            this.CBTodas.ForeColor = System.Drawing.Color.White;
            this.CBTodas.Location = new System.Drawing.Point(563, 83);
            this.CBTodas.Name = "CBTodas";
            this.CBTodas.Size = new System.Drawing.Size(56, 17);
            this.CBTodas.TabIndex = 186;
            this.CBTodas.Text = "Todos";
            this.CBTodas.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(151, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 192;
            this.label4.Text = "Cajero:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 190;
            this.label3.Text = "GASTOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(151, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 182;
            this.label1.Text = "Desde:";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(258, 386);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(94, 30);
            this.BTEnviar.TabIndex = 191;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // DTPFrom
            // 
            this.DTPFrom.Location = new System.Drawing.Point(253, 115);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(200, 20);
            this.DTPFrom.TabIndex = 188;
            // 
            // DTPTo
            // 
            this.DTPTo.Location = new System.Drawing.Point(603, 115);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(200, 20);
            this.DTPTo.TabIndex = 189;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(560, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 185;
            this.label2.Text = "a:";
            // 
            // CBOrigenFiscal
            // 
            this.CBOrigenFiscal.FormattingEnabled = true;
            this.CBOrigenFiscal.Items.AddRange(new object[] {
            "No fiscal",
            "Fiscal",
            "Todos"});
            this.CBOrigenFiscal.Location = new System.Drawing.Point(252, 197);
            this.CBOrigenFiscal.Name = "CBOrigenFiscal";
            this.CBOrigenFiscal.Size = new System.Drawing.Size(116, 21);
            this.CBOrigenFiscal.TabIndex = 199;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(151, 200);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 13);
            this.label19.TabIndex = 200;
            this.label19.Text = "Origen fiscal:";
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.lblAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacen.ForeColor = System.Drawing.Color.White;
            this.lblAlmacen.Location = new System.Drawing.Point(151, 247);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(59, 13);
            this.lblAlmacen.TabIndex = 201;
            this.lblAlmacen.Text = "Almacen:";
            // 
            // ALMACENComboBox
            // 
            this.ALMACENComboBox.Condicion = null;
            this.ALMACENComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENComboBox.DisplayMember = "nombre";
            this.ALMACENComboBox.FormattingEnabled = true;
            this.ALMACENComboBox.IndiceCampoSelector = 0;
            this.ALMACENComboBox.LabelDescription = null;
            this.ALMACENComboBox.Location = new System.Drawing.Point(250, 244);
            this.ALMACENComboBox.Name = "ALMACENComboBox";
            this.ALMACENComboBox.NombreCampoSelector = "id";
            this.ALMACENComboBox.Query = "select id,nombre from almacen";
            this.ALMACENComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENComboBox.SelectedDataDisplaying = null;
            this.ALMACENComboBox.SelectedDataValue = null;
            this.ALMACENComboBox.Size = new System.Drawing.Size(116, 21);
            this.ALMACENComboBox.TabIndex = 202;
            this.ALMACENComboBox.ValueMember = "id";
            // 
            // CBTodosAlmacenes
            // 
            this.CBTodosAlmacenes.AutoSize = true;
            this.CBTodosAlmacenes.BackColor = System.Drawing.Color.Transparent;
            this.CBTodosAlmacenes.ForeColor = System.Drawing.Color.White;
            this.CBTodosAlmacenes.Location = new System.Drawing.Point(563, 248);
            this.CBTodosAlmacenes.Name = "CBTodosAlmacenes";
            this.CBTodosAlmacenes.Size = new System.Drawing.Size(56, 17);
            this.CBTodosAlmacenes.TabIndex = 203;
            this.CBTodosAlmacenes.Text = "Todos";
            this.CBTodosAlmacenes.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(150, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 205;
            this.label5.Text = "Tipo gasto:";
            // 
            // TIPOGASTOIDTextBox
            // 
            this.TIPOGASTOIDTextBox.Condicion = null;
            this.TIPOGASTOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TIPOGASTOIDTextBox.DisplayMember = "nombre";
            this.TIPOGASTOIDTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TIPOGASTOIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TIPOGASTOIDTextBox.FormattingEnabled = true;
            this.TIPOGASTOIDTextBox.IndiceCampoSelector = 0;
            this.TIPOGASTOIDTextBox.LabelDescription = null;
            this.TIPOGASTOIDTextBox.Location = new System.Drawing.Point(249, 288);
            this.TIPOGASTOIDTextBox.Name = "TIPOGASTOIDTextBox";
            this.TIPOGASTOIDTextBox.NombreCampoSelector = "id";
            this.TIPOGASTOIDTextBox.Query = "select id,nombre from tipogasto";
            this.TIPOGASTOIDTextBox.QueryDeSeleccion = "select id,nombre from tipogasto where  id = @id";
            this.TIPOGASTOIDTextBox.SelectedDataDisplaying = null;
            this.TIPOGASTOIDTextBox.SelectedDataValue = null;
            this.TIPOGASTOIDTextBox.Size = new System.Drawing.Size(204, 20);
            this.TIPOGASTOIDTextBox.TabIndex = 204;
            this.TIPOGASTOIDTextBox.ValueMember = "id";
            // 
            // CBTodosTipoGasto
            // 
            this.CBTodosTipoGasto.AutoSize = true;
            this.CBTodosTipoGasto.BackColor = System.Drawing.Color.Transparent;
            this.CBTodosTipoGasto.ForeColor = System.Drawing.Color.White;
            this.CBTodosTipoGasto.Location = new System.Drawing.Point(563, 291);
            this.CBTodosTipoGasto.Name = "CBTodosTipoGasto";
            this.CBTodosTipoGasto.Size = new System.Drawing.Size(56, 17);
            this.CBTodosTipoGasto.TabIndex = 206;
            this.CBTodosTipoGasto.Text = "Todos";
            this.CBTodosTipoGasto.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.ForeColor = System.Drawing.Color.White;
            label7.Location = new System.Drawing.Point(150, 331);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(83, 13);
            label7.TabIndex = 210;
            label7.Text = "Centro costo:";
            // 
            // CENTROCOSTOButton
            // 
            this.CENTROCOSTOButton.BackColor = System.Drawing.Color.Transparent;
            this.CENTROCOSTOButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.CENTROCOSTOButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CENTROCOSTOButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CENTROCOSTOButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.CENTROCOSTOButton.Location = new System.Drawing.Point(332, 329);
            this.CENTROCOSTOButton.Name = "CENTROCOSTOButton";
            this.CENTROCOSTOButton.Size = new System.Drawing.Size(21, 23);
            this.CENTROCOSTOButton.TabIndex = 208;
            this.CENTROCOSTOButton.UseVisualStyleBackColor = false;
            // 
            // CENTROCOSTOIDTextBox
            // 
            this.CENTROCOSTOIDTextBox.BotonLookUp = this.CENTROCOSTOButton;
            this.CENTROCOSTOIDTextBox.Condicion = null;
            this.CENTROCOSTOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CENTROCOSTOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CENTROCOSTOIDTextBox.DbValue = null;
            this.CENTROCOSTOIDTextBox.Format_Expression = null;
            this.CENTROCOSTOIDTextBox.IndiceCampoDescripcion = 2;
            this.CENTROCOSTOIDTextBox.IndiceCampoSelector = 1;
            this.CENTROCOSTOIDTextBox.IndiceCampoValue = 0;
            this.CENTROCOSTOIDTextBox.LabelDescription = this.CENTROCOSTOLabel;
            this.CENTROCOSTOIDTextBox.Location = new System.Drawing.Point(249, 329);
            this.CENTROCOSTOIDTextBox.MostrarErrores = true;
            this.CENTROCOSTOIDTextBox.Name = "CENTROCOSTOIDTextBox";
            this.CENTROCOSTOIDTextBox.NombreCampoSelector = "clave";
            this.CENTROCOSTOIDTextBox.NombreCampoValue = "id";
            this.CENTROCOSTOIDTextBox.Query = "select id,clave,nombre from centrocosto";
            this.CENTROCOSTOIDTextBox.QueryDeSeleccion = "select id,clave,nombre from centrocosto where clave = @clave";
            this.CENTROCOSTOIDTextBox.QueryPorDBValue = "select id,clave,nombre from centrocosto where id = @id";
            this.CENTROCOSTOIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.CENTROCOSTOIDTextBox.TabIndex = 207;
            this.CENTROCOSTOIDTextBox.Tag = 34;
            this.CENTROCOSTOIDTextBox.TextDescription = null;
            this.CENTROCOSTOIDTextBox.Titulo = "Centro costo";
            this.CENTROCOSTOIDTextBox.ValidarEntrada = true;
            this.CENTROCOSTOIDTextBox.ValidationExpression = null;
            // 
            // CENTROCOSTOLabel
            // 
            this.CENTROCOSTOLabel.AutoSize = true;
            this.CENTROCOSTOLabel.BackColor = System.Drawing.Color.Transparent;
            this.CENTROCOSTOLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CENTROCOSTOLabel.Location = new System.Drawing.Point(359, 332);
            this.CENTROCOSTOLabel.Name = "CENTROCOSTOLabel";
            this.CENTROCOSTOLabel.Size = new System.Drawing.Size(16, 13);
            this.CENTROCOSTOLabel.TabIndex = 209;
            this.CENTROCOSTOLabel.Text = "...";
            // 
            // CBTodosCentroCosto
            // 
            this.CBTodosCentroCosto.AutoSize = true;
            this.CBTodosCentroCosto.BackColor = System.Drawing.Color.Transparent;
            this.CBTodosCentroCosto.ForeColor = System.Drawing.Color.White;
            this.CBTodosCentroCosto.Location = new System.Drawing.Point(563, 333);
            this.CBTodosCentroCosto.Name = "CBTodosCentroCosto";
            this.CBTodosCentroCosto.Size = new System.Drawing.Size(56, 17);
            this.CBTodosCentroCosto.TabIndex = 211;
            this.CBTodosCentroCosto.Text = "Todos";
            this.CBTodosCentroCosto.UseVisualStyleBackColor = false;
            // 
            // WFReciboGastoReporte2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(878, 422);
            this.Controls.Add(this.CBTodosCentroCosto);
            this.Controls.Add(label7);
            this.Controls.Add(this.CENTROCOSTOButton);
            this.Controls.Add(this.CENTROCOSTOIDTextBox);
            this.Controls.Add(this.CENTROCOSTOLabel);
            this.Controls.Add(this.CBTodosTipoGasto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TIPOGASTOIDTextBox);
            this.Controls.Add(this.CBTodosAlmacenes);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.ALMACENComboBox);
            this.Controls.Add(this.CBOrigenFiscal);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.CBTodosGastos);
            this.Controls.Add(this.GASTOButton);
            this.Controls.Add(this.GASTOIDTextBox);
            this.Controls.Add(this.GASTOLabel);
            this.Controls.Add(mARCAIDLabel);
            this.Controls.Add(this.ITEMButton);
            this.Controls.Add(this.ITEMIDTextBox);
            this.Controls.Add(this.ITEMLabel);
            this.Controls.Add(this.CBSumarizado);
            this.Controls.Add(this.CBTodas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTEnviar);
            this.Controls.Add(this.DTPFrom);
            this.Controls.Add(this.DTPTo);
            this.Controls.Add(this.label2);
            this.Name = "WFReciboGastoReporte2";
            this.Text = "Reporte de gastos";
            this.Load += new System.EventHandler(this.WFReciboGastoReporte2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CBTodosGastos;
        private System.Windows.Forms.Button GASTOButton;
        private Tools.TextBoxFB GASTOIDTextBox;
        private System.Windows.Forms.Label GASTOLabel;
        private System.Windows.Forms.Button ITEMButton;
        private Tools.TextBoxFB ITEMIDTextBox;
        private System.Windows.Forms.Label ITEMLabel;
        private System.Windows.Forms.CheckBox CBSumarizado;
        private System.Windows.Forms.CheckBox CBTodas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBOrigenFiscal;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.ComboBoxFB ALMACENComboBox;
        private System.Windows.Forms.CheckBox CBTodosAlmacenes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBoxFB TIPOGASTOIDTextBox;
        private System.Windows.Forms.CheckBox CBTodosTipoGasto;
        private System.Windows.Forms.Button CENTROCOSTOButton;
        private Tools.TextBoxFB CENTROCOSTOIDTextBox;
        private System.Windows.Forms.Label CENTROCOSTOLabel;
        private System.Windows.Forms.CheckBox CBTodosCentroCosto;
    }
}