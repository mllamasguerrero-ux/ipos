
namespace iPos
{
    partial class WFCuentaEdit
    {
      
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

       
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label TIPOLINEAPOLIZAIDEtiqueta;
            FirebirdSql.Data.FirebirdClient.FbParameter fbParameter2 = new FirebirdSql.Data.FirebirdClient.FbParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFCuentaEdit));
            this.RFV_CLAVE = new CustomValidation.RequiredFieldValidator();
            this.CLAVETextBox = new System.Windows.Forms.TextBox();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LEYENDATextBox = new System.Windows.Forms.TextBox();
            this.ORDENTextBox = new System.Windows.Forms.NumericTextBox();
            this.TASATextBox = new System.Windows.Forms.NumericTextBox();
            this.ESFACTTextBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FORMAPAGOSATIDButton = new System.Windows.Forms.Button();
            this.FORMAPAGOSATIDTextBox = new iPos.Tools.TextBoxFB();
            this.FORMAPAGOSATIDLabel = new System.Windows.Forms.Label();
            this.TIPOLINEAPOLIZAIDButton = new System.Windows.Forms.Button();
            this.TIPOLINEAPOLIZAIDTextBox = new iPos.Tools.TextBoxFB();
            this.TIPOLINEAPOLIZAIDLabel = new System.Windows.Forms.Label();
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.ACTIVOLabel = new System.Windows.Forms.Label();
            this.NOMBRELabel = new System.Windows.Forms.Label();
            this.NUMUCUENTATextBox = new System.Windows.Forms.TextBox();
            this.CLAVELabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            TIPOLINEAPOLIZAIDEtiqueta = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(54, 113);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(105, 13);
            label1.TabIndex = 165;
            label1.Text = "Forma pago SAT:";
            // 
            // TIPOLINEAPOLIZAIDEtiqueta
            // 
            TIPOLINEAPOLIZAIDEtiqueta.AutoSize = true;
            TIPOLINEAPOLIZAIDEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TIPOLINEAPOLIZAIDEtiqueta.ForeColor = System.Drawing.Color.White;
            TIPOLINEAPOLIZAIDEtiqueta.Location = new System.Drawing.Point(55, 82);
            TIPOLINEAPOLIZAIDEtiqueta.Name = "TIPOLINEAPOLIZAIDEtiqueta";
            TIPOLINEAPOLIZAIDEtiqueta.Size = new System.Drawing.Size(104, 13);
            TIPOLINEAPOLIZAIDEtiqueta.TabIndex = 161;
            TIPOLINEAPOLIZAIDEtiqueta.Text = "Tipo linea poliza:";
            // 
            // RFV_CLAVE
            // 
            this.RFV_CLAVE.ControlToValidate = this.CLAVETextBox;
            this.RFV_CLAVE.Enabled = true;
            this.RFV_CLAVE.ErrorMessage = "Se requiere el campo CLAVE";
            this.RFV_CLAVE.Icon = null;
            // 
            // CLAVETextBox
            // 
            this.CLAVETextBox.Location = new System.Drawing.Point(176, 18);
            this.CLAVETextBox.Name = "CLAVETextBox";
            this.CLAVETextBox.Size = new System.Drawing.Size(204, 20);
            this.CLAVETextBox.TabIndex = 1;
            this.CLAVETextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CLAVETextBox_Validating);
            // 
            // LBError
            // 
            this.LBError.AutoSize = true;
            this.LBError.ForeColor = System.Drawing.Color.Red;
            this.LBError.Location = new System.Drawing.Point(26, 20);
            this.LBError.Name = "LBError";
            this.LBError.Size = new System.Drawing.Size(10, 13);
            this.LBError.TabIndex = 44;
            this.LBError.Text = "-";
            // 
            // FbConnection1
            // 
            this.FbConnection1.ConnectionString = "Data Source=manuel;Initial Catalog=generador;Persist Security Info=True;User ID=s" +
    "a;Password=Twincept";
            // 
            // FbCommand1
            // 
            this.FbCommand1.CommandText = "select * from LINEA  where 1=1  and ID=@ID  and  1= 1 ";
            this.FbCommand1.CommandTimeout = 30;
            this.FbCommand1.Connection = this.FbConnection1;
            fbParameter2.FbDbType = FirebirdSql.Data.FirebirdClient.FbDbType.BigInt;
            fbParameter2.ParameterName = "@ID";
            this.FbCommand1.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
            fbParameter2});
            // 
            // BTCancelar
            // 
            this.BTCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCancelar.ForeColor = System.Drawing.Color.White;
            this.BTCancelar.Image = global::iPos.Properties.Resources.cancel_J;
            this.BTCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCancelar.Location = new System.Drawing.Point(316, 331);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(112, 32);
            this.BTCancelar.TabIndex = 47;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // BTIniciaEdicion
            // 
            this.BTIniciaEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTIniciaEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTIniciaEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIniciaEdicion.ForeColor = System.Drawing.Color.White;
            this.BTIniciaEdicion.Location = new System.Drawing.Point(72, 336);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(57, 23);
            this.BTIniciaEdicion.TabIndex = 46;
            this.BTIniciaEdicion.Text = "Editar";
            this.BTIniciaEdicion.UseVisualStyleBackColor = false;
            this.BTIniciaEdicion.Visible = false;
            this.BTIniciaEdicion.Click += new System.EventHandler(this.BTIniciaEdicion_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.LEYENDATextBox);
            this.panel1.Controls.Add(this.ORDENTextBox);
            this.panel1.Controls.Add(this.TASATextBox);
            this.panel1.Controls.Add(this.ESFACTTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.FORMAPAGOSATIDButton);
            this.panel1.Controls.Add(label1);
            this.panel1.Controls.Add(this.FORMAPAGOSATIDTextBox);
            this.panel1.Controls.Add(this.FORMAPAGOSATIDLabel);
            this.panel1.Controls.Add(this.TIPOLINEAPOLIZAIDButton);
            this.panel1.Controls.Add(TIPOLINEAPOLIZAIDEtiqueta);
            this.panel1.Controls.Add(this.TIPOLINEAPOLIZAIDTextBox);
            this.panel1.Controls.Add(this.TIPOLINEAPOLIZAIDLabel);
            this.panel1.Controls.Add(this.ACTIVOTextBox);
            this.panel1.Controls.Add(this.ACTIVOLabel);
            this.panel1.Controls.Add(this.NOMBRELabel);
            this.panel1.Controls.Add(this.NUMUCUENTATextBox);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(6, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 282);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(114, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 178;
            this.label8.Text = "Orden:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(120, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 177;
            this.label7.Text = "Tasa:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(100, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 175;
            this.label6.Text = "Leyenda:";
            // 
            // LEYENDATextBox
            // 
            this.LEYENDATextBox.Location = new System.Drawing.Point(170, 199);
            this.LEYENDATextBox.Name = "LEYENDATextBox";
            this.LEYENDATextBox.Size = new System.Drawing.Size(204, 20);
            this.LEYENDATextBox.TabIndex = 176;
            // 
            // ORDENTextBox
            // 
            this.ORDENTextBox.AllowNegative = false;
            this.ORDENTextBox.Format_Expression = null;
            this.ORDENTextBox.Location = new System.Drawing.Point(170, 233);
            this.ORDENTextBox.Name = "ORDENTextBox";
            this.ORDENTextBox.NumericPrecision = 5;
            this.ORDENTextBox.NumericScaleOnFocus = 0;
            this.ORDENTextBox.NumericScaleOnLostFocus = 0;
            this.ORDENTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ORDENTextBox.Size = new System.Drawing.Size(116, 20);
            this.ORDENTextBox.TabIndex = 174;
            this.ORDENTextBox.Tag = 34;
            this.ORDENTextBox.Text = "0";
            this.ORDENTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ORDENTextBox.ValidationExpression = null;
            this.ORDENTextBox.ZeroIsValid = true;
            // 
            // TASATextBox
            // 
            this.TASATextBox.AllowNegative = false;
            this.TASATextBox.Format_Expression = null;
            this.TASATextBox.Location = new System.Drawing.Point(170, 168);
            this.TASATextBox.Name = "TASATextBox";
            this.TASATextBox.NumericPrecision = 5;
            this.TASATextBox.NumericScaleOnFocus = 2;
            this.TASATextBox.NumericScaleOnLostFocus = 2;
            this.TASATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TASATextBox.Size = new System.Drawing.Size(116, 20);
            this.TASATextBox.TabIndex = 173;
            this.TASATextBox.Tag = 34;
            this.TASATextBox.Text = "0.00";
            this.TASATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TASATextBox.ValidationExpression = null;
            this.TASATextBox.ZeroIsValid = true;
            // 
            // ESFACTTextBox
            // 
            this.ESFACTTextBox.FormattingEnabled = true;
            this.ESFACTTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.ESFACTTextBox.Location = new System.Drawing.Point(170, 140);
            this.ESFACTTextBox.Name = "ESFACTTextBox";
            this.ESFACTTextBox.Size = new System.Drawing.Size(63, 21);
            this.ESFACTTextBox.TabIndex = 172;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(72, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 171;
            this.label5.Text = "Para facturas:";
            // 
            // FORMAPAGOSATIDButton
            // 
            this.FORMAPAGOSATIDButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FORMAPAGOSATIDButton.BackgroundImage")));
            this.FORMAPAGOSATIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FORMAPAGOSATIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FORMAPAGOSATIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.FORMAPAGOSATIDButton.Location = new System.Drawing.Point(277, 108);
            this.FORMAPAGOSATIDButton.Name = "FORMAPAGOSATIDButton";
            this.FORMAPAGOSATIDButton.Size = new System.Drawing.Size(24, 23);
            this.FORMAPAGOSATIDButton.TabIndex = 164;
            this.FORMAPAGOSATIDButton.UseVisualStyleBackColor = true;
            // 
            // FORMAPAGOSATIDTextBox
            // 
            this.FORMAPAGOSATIDTextBox.BotonLookUp = this.FORMAPAGOSATIDButton;
            this.FORMAPAGOSATIDTextBox.Condicion = null;
            this.FORMAPAGOSATIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.FORMAPAGOSATIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.FORMAPAGOSATIDTextBox.DbValue = null;
            this.FORMAPAGOSATIDTextBox.Format_Expression = null;
            this.FORMAPAGOSATIDTextBox.IndiceCampoDescripcion = 2;
            this.FORMAPAGOSATIDTextBox.IndiceCampoSelector = 1;
            this.FORMAPAGOSATIDTextBox.IndiceCampoValue = 0;
            this.FORMAPAGOSATIDTextBox.LabelDescription = this.FORMAPAGOSATIDLabel;
            this.FORMAPAGOSATIDTextBox.Location = new System.Drawing.Point(170, 110);
            this.FORMAPAGOSATIDTextBox.MostrarErrores = true;
            this.FORMAPAGOSATIDTextBox.Name = "FORMAPAGOSATIDTextBox";
            this.FORMAPAGOSATIDTextBox.NombreCampoSelector = "clave";
            this.FORMAPAGOSATIDTextBox.NombreCampoValue = "id";
            this.FORMAPAGOSATIDTextBox.Query = "select id,clave,nombre from formapagosat";
            this.FORMAPAGOSATIDTextBox.QueryDeSeleccion = "select id,clave,nombre from formapagosat where  clave = @clave";
            this.FORMAPAGOSATIDTextBox.QueryPorDBValue = "select id,clave,nombre from formapagosat where  id = @id";
            this.FORMAPAGOSATIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.FORMAPAGOSATIDTextBox.TabIndex = 163;
            this.FORMAPAGOSATIDTextBox.Tag = 34;
            this.FORMAPAGOSATIDTextBox.TextDescription = null;
            this.FORMAPAGOSATIDTextBox.Titulo = "Formas de pago sat";
            this.FORMAPAGOSATIDTextBox.ValidarEntrada = true;
            this.FORMAPAGOSATIDTextBox.ValidationExpression = null;
            // 
            // FORMAPAGOSATIDLabel
            // 
            this.FORMAPAGOSATIDLabel.AutoSize = true;
            this.FORMAPAGOSATIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FORMAPAGOSATIDLabel.ForeColor = System.Drawing.Color.White;
            this.FORMAPAGOSATIDLabel.Location = new System.Drawing.Point(307, 113);
            this.FORMAPAGOSATIDLabel.Name = "FORMAPAGOSATIDLabel";
            this.FORMAPAGOSATIDLabel.Size = new System.Drawing.Size(19, 13);
            this.FORMAPAGOSATIDLabel.TabIndex = 166;
            this.FORMAPAGOSATIDLabel.Text = "...";
            // 
            // TIPOLINEAPOLIZAIDButton
            // 
            this.TIPOLINEAPOLIZAIDButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TIPOLINEAPOLIZAIDButton.BackgroundImage")));
            this.TIPOLINEAPOLIZAIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TIPOLINEAPOLIZAIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TIPOLINEAPOLIZAIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.TIPOLINEAPOLIZAIDButton.Location = new System.Drawing.Point(277, 77);
            this.TIPOLINEAPOLIZAIDButton.Name = "TIPOLINEAPOLIZAIDButton";
            this.TIPOLINEAPOLIZAIDButton.Size = new System.Drawing.Size(24, 23);
            this.TIPOLINEAPOLIZAIDButton.TabIndex = 160;
            this.TIPOLINEAPOLIZAIDButton.UseVisualStyleBackColor = true;
            // 
            // TIPOLINEAPOLIZAIDTextBox
            // 
            this.TIPOLINEAPOLIZAIDTextBox.BotonLookUp = this.TIPOLINEAPOLIZAIDButton;
            this.TIPOLINEAPOLIZAIDTextBox.Condicion = null;
            this.TIPOLINEAPOLIZAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TIPOLINEAPOLIZAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TIPOLINEAPOLIZAIDTextBox.DbValue = null;
            this.TIPOLINEAPOLIZAIDTextBox.Format_Expression = null;
            this.TIPOLINEAPOLIZAIDTextBox.IndiceCampoDescripcion = 2;
            this.TIPOLINEAPOLIZAIDTextBox.IndiceCampoSelector = 1;
            this.TIPOLINEAPOLIZAIDTextBox.IndiceCampoValue = 0;
            this.TIPOLINEAPOLIZAIDTextBox.LabelDescription = this.TIPOLINEAPOLIZAIDLabel;
            this.TIPOLINEAPOLIZAIDTextBox.Location = new System.Drawing.Point(170, 77);
            this.TIPOLINEAPOLIZAIDTextBox.MostrarErrores = true;
            this.TIPOLINEAPOLIZAIDTextBox.Name = "TIPOLINEAPOLIZAIDTextBox";
            this.TIPOLINEAPOLIZAIDTextBox.NombreCampoSelector = "clave";
            this.TIPOLINEAPOLIZAIDTextBox.NombreCampoValue = "id";
            this.TIPOLINEAPOLIZAIDTextBox.Query = "select id,clave,nombre from tipolineapoliza";
            this.TIPOLINEAPOLIZAIDTextBox.QueryDeSeleccion = "select id,clave,nombre from tipolineapoliza where  clave = @clave";
            this.TIPOLINEAPOLIZAIDTextBox.QueryPorDBValue = "select id,clave,nombre from tipolineapoliza where  id = @id";
            this.TIPOLINEAPOLIZAIDTextBox.Size = new System.Drawing.Size(98, 20);
            this.TIPOLINEAPOLIZAIDTextBox.TabIndex = 159;
            this.TIPOLINEAPOLIZAIDTextBox.Tag = 34;
            this.TIPOLINEAPOLIZAIDTextBox.TextDescription = null;
            this.TIPOLINEAPOLIZAIDTextBox.Titulo = "Tipo linea poliza";
            this.TIPOLINEAPOLIZAIDTextBox.ValidarEntrada = true;
            this.TIPOLINEAPOLIZAIDTextBox.ValidationExpression = null;
            // 
            // TIPOLINEAPOLIZAIDLabel
            // 
            this.TIPOLINEAPOLIZAIDLabel.AutoSize = true;
            this.TIPOLINEAPOLIZAIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TIPOLINEAPOLIZAIDLabel.ForeColor = System.Drawing.Color.White;
            this.TIPOLINEAPOLIZAIDLabel.Location = new System.Drawing.Point(307, 82);
            this.TIPOLINEAPOLIZAIDLabel.Name = "TIPOLINEAPOLIZAIDLabel";
            this.TIPOLINEAPOLIZAIDLabel.Size = new System.Drawing.Size(19, 13);
            this.TIPOLINEAPOLIZAIDLabel.TabIndex = 162;
            this.TIPOLINEAPOLIZAIDLabel.Text = "...";
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(170, 45);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ACTIVOTextBox.TabIndex = 5;
            this.ACTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // ACTIVOLabel
            // 
            this.ACTIVOLabel.AutoSize = true;
            this.ACTIVOLabel.BackColor = System.Drawing.Color.Transparent;
            this.ACTIVOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACTIVOLabel.ForeColor = System.Drawing.Color.White;
            this.ACTIVOLabel.Location = new System.Drawing.Point(112, 46);
            this.ACTIVOLabel.Name = "ACTIVOLabel";
            this.ACTIVOLabel.Size = new System.Drawing.Size(47, 13);
            this.ACTIVOLabel.TabIndex = 1;
            this.ACTIVOLabel.Text = "Activo:";
            // 
            // NOMBRELabel
            // 
            this.NOMBRELabel.AutoSize = true;
            this.NOMBRELabel.BackColor = System.Drawing.Color.Transparent;
            this.NOMBRELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NOMBRELabel.ForeColor = System.Drawing.Color.White;
            this.NOMBRELabel.Location = new System.Drawing.Point(96, 18);
            this.NOMBRELabel.Name = "NOMBRELabel";
            this.NOMBRELabel.Size = new System.Drawing.Size(63, 13);
            this.NOMBRELabel.TabIndex = 1;
            this.NOMBRELabel.Text = "# Cuenta:";
            // 
            // NUMUCUENTATextBox
            // 
            this.NUMUCUENTATextBox.Location = new System.Drawing.Point(170, 15);
            this.NUMUCUENTATextBox.Name = "NUMUCUENTATextBox";
            this.NUMUCUENTATextBox.Size = new System.Drawing.Size(204, 20);
            this.NUMUCUENTATextBox.TabIndex = 2;
            // 
            // CLAVELabel
            // 
            this.CLAVELabel.AutoSize = true;
            this.CLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLAVELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLAVELabel.ForeColor = System.Drawing.Color.White;
            this.CLAVELabel.Location = new System.Drawing.Point(122, 21);
            this.CLAVELabel.Name = "CLAVELabel";
            this.CLAVELabel.Size = new System.Drawing.Size(43, 13);
            this.CLAVELabel.TabIndex = 1;
            this.CLAVELabel.Text = "Clave:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(176, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WFCuentaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(512, 373);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CLAVELabel);
            this.Controls.Add(this.CLAVETextBox);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFCuentaEdit";
            this.Text = "CUENTA";
            this.Load += new System.EventHandler(this.LINEAEdit_Reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

  }

  #endregion



        private System.Windows.Forms.TextBox CLAVETextBox;


        private System.Windows.Forms.TextBox NUMUCUENTATextBox;
        private System.Windows.Forms.Panel panel1;
  
  private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
  private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.Label LBError;




  private CustomValidation.RequiredFieldValidator RFV_CLAVE;
        private System.Windows.Forms.Label ACTIVOLabel;
        private System.Windows.Forms.Label CLAVELabel;
        private System.Windows.Forms.Label NOMBRELabel;
        private System.Windows.Forms.Button BTIniciaEdicion;
        private System.Windows.Forms.CheckBox ACTIVOTextBox;
        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.Button FORMAPAGOSATIDButton;
        private Tools.TextBoxFB FORMAPAGOSATIDTextBox;
        private System.Windows.Forms.Label FORMAPAGOSATIDLabel;
        private System.Windows.Forms.Button TIPOLINEAPOLIZAIDButton;
        private Tools.TextBoxFB TIPOLINEAPOLIZAIDTextBox;
        private System.Windows.Forms.Label TIPOLINEAPOLIZAIDLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ESFACTTextBox;
        private System.Windows.Forms.NumericTextBox TASATextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox LEYENDATextBox;
        private System.Windows.Forms.NumericTextBox ORDENTextBox;
 

    }
}

