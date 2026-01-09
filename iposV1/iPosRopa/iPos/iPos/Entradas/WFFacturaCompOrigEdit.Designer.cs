
namespace iPos
{
    partial class WFFacturaCompOrigEdit
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label13;
            FirebirdSql.Data.FirebirdClient.FbParameter fbParameter2 = new FirebirdSql.Data.FirebirdClient.FbParameter();
            this.ACTIVOLabel = new System.Windows.Forms.Label();
            this.CLAVELabel = new System.Windows.Forms.Label();
            this.FACTURATextBox = new System.Windows.Forms.TextBox();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TOTALTextBox = new System.Windows.Forms.NumericTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.IEPS53TextBox = new System.Windows.Forms.NumericTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.IEPS30TextBox = new System.Windows.Forms.NumericTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.IEPS26CTextBox = new System.Windows.Forms.NumericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.IEPS26TextBox = new System.Windows.Forms.NumericTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.IEPS25TextBox = new System.Windows.Forms.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.IEPS8TextBox = new System.Windows.Forms.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IVATextBox = new System.Windows.Forms.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SUMATextBox = new System.Windows.Forms.NumericTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.ITEMButton = new System.Windows.Forms.Button();
            this.PROVEEDORIDTextBox = new iPos.Tools.TextBoxFB();
            this.ITEMLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FECHARECEPCIONTextBox = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.FECHAFACTURATextBox = new System.Windows.Forms.DateTimePicker();
            this.FECHAFACTURALabel = new System.Windows.Forms.Label();
            this.PROVISIONADACheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.pnlCargaPorFolio = new System.Windows.Forms.Panel();
            this.BTSeleccionar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.TBFolio = new System.Windows.Forms.TextBox();
            this.SUCURSALIDLabel = new System.Windows.Forms.Label();
            this.SUCURSALIDButton = new System.Windows.Forms.Button();
            this.SUCURSALIDTextBox = new iPos.Tools.TextBoxFB();
            this.btnCargarInformacion = new System.Windows.Forms.Button();
            this.lblCargarInformacion = new System.Windows.Forms.Label();
            this.dSAbonos2 = new iPos.Abonos.DSAbonos2();
            this.cOMPRASFACTURABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cOMPRASFACTURATableAdapter = new iPos.Abonos.DSAbonos2TableAdapters.COMPRASFACTURATableAdapter();
            this.tableAdapterManager = new iPos.Abonos.DSAbonos2TableAdapters.TableAdapterManager();
            this.pnlIngresoManual = new System.Windows.Forms.Panel();
            this.lblIngresoManual = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlCargaPorFolio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSAbonos2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMPRASFACTURABindingSource)).BeginInit();
            this.pnlIngresoManual.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = System.Drawing.Color.Transparent;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.ForeColor = System.Drawing.Color.White;
            label13.Location = new System.Drawing.Point(-3, 35);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(60, 13);
            label13.TabIndex = 239;
            label13.Text = "Sucursal:";
            // 
            // ACTIVOLabel
            // 
            this.ACTIVOLabel.AutoSize = true;
            this.ACTIVOLabel.BackColor = System.Drawing.Color.Transparent;
            this.ACTIVOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACTIVOLabel.ForeColor = System.Drawing.Color.White;
            this.ACTIVOLabel.Location = new System.Drawing.Point(17, 12);
            this.ACTIVOLabel.Name = "ACTIVOLabel";
            this.ACTIVOLabel.Size = new System.Drawing.Size(47, 13);
            this.ACTIVOLabel.TabIndex = 1;
            this.ACTIVOLabel.Text = "Activo:";
            // 
            // CLAVELabel
            // 
            this.CLAVELabel.AutoSize = true;
            this.CLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLAVELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLAVELabel.ForeColor = System.Drawing.Color.White;
            this.CLAVELabel.Location = new System.Drawing.Point(1, 52);
            this.CLAVELabel.Name = "CLAVELabel";
            this.CLAVELabel.Size = new System.Drawing.Size(54, 13);
            this.CLAVELabel.TabIndex = 1;
            this.CLAVELabel.Text = "Factura:";
            // 
            // FACTURATextBox
            // 
            this.FACTURATextBox.Location = new System.Drawing.Point(61, 49);
            this.FACTURATextBox.Name = "FACTURATextBox";
            this.FACTURATextBox.Size = new System.Drawing.Size(152, 20);
            this.FACTURATextBox.TabIndex = 1;
            this.FACTURATextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CLAVETextBox_Validating);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(105, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.TOTALTextBox);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.IEPS53TextBox);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.IEPS30TextBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.IEPS26CTextBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.IEPS26TextBox);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.IEPS25TextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.IEPS8TextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.IVATextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.SUMATextBox);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.ITEMButton);
            this.panel1.Controls.Add(this.PROVEEDORIDTextBox);
            this.panel1.Controls.Add(this.ITEMLabel);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.FECHARECEPCIONTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.FECHAFACTURATextBox);
            this.panel1.Controls.Add(this.FECHAFACTURALabel);
            this.panel1.Controls.Add(this.PROVISIONADACheckBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ACTIVOTextBox);
            this.panel1.Controls.Add(this.ACTIVOLabel);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(12, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 201);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            // 
            // TOTALTextBox
            // 
            this.TOTALTextBox.AllowNegative = true;
            this.TOTALTextBox.Format_Expression = null;
            this.TOTALTextBox.Location = new System.Drawing.Point(509, 102);
            this.TOTALTextBox.Name = "TOTALTextBox";
            this.TOTALTextBox.NumericPrecision = 18;
            this.TOTALTextBox.NumericScaleOnFocus = 2;
            this.TOTALTextBox.NumericScaleOnLostFocus = 2;
            this.TOTALTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TOTALTextBox.Size = new System.Drawing.Size(100, 20);
            this.TOTALTextBox.TabIndex = 249;
            this.TOTALTextBox.Tag = "";
            this.TOTALTextBox.Text = "0.00";
            this.TOTALTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TOTALTextBox.ValidationExpression = null;
            this.TOTALTextBox.ZeroIsValid = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(449, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 248;
            this.label11.Text = "Total:";
            // 
            // IEPS53TextBox
            // 
            this.IEPS53TextBox.AllowNegative = true;
            this.IEPS53TextBox.Format_Expression = null;
            this.IEPS53TextBox.Location = new System.Drawing.Point(509, 158);
            this.IEPS53TextBox.Name = "IEPS53TextBox";
            this.IEPS53TextBox.NumericPrecision = 18;
            this.IEPS53TextBox.NumericScaleOnFocus = 2;
            this.IEPS53TextBox.NumericScaleOnLostFocus = 2;
            this.IEPS53TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.IEPS53TextBox.Size = new System.Drawing.Size(100, 20);
            this.IEPS53TextBox.TabIndex = 247;
            this.IEPS53TextBox.Tag = "";
            this.IEPS53TextBox.Text = "0.00";
            this.IEPS53TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IEPS53TextBox.ValidationExpression = null;
            this.IEPS53TextBox.ZeroIsValid = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(449, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 246;
            this.label12.Text = "Ieps 53:";
            // 
            // IEPS30TextBox
            // 
            this.IEPS30TextBox.AllowNegative = true;
            this.IEPS30TextBox.Format_Expression = null;
            this.IEPS30TextBox.Location = new System.Drawing.Point(509, 132);
            this.IEPS30TextBox.Name = "IEPS30TextBox";
            this.IEPS30TextBox.NumericPrecision = 18;
            this.IEPS30TextBox.NumericScaleOnFocus = 2;
            this.IEPS30TextBox.NumericScaleOnLostFocus = 2;
            this.IEPS30TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.IEPS30TextBox.Size = new System.Drawing.Size(100, 20);
            this.IEPS30TextBox.TabIndex = 245;
            this.IEPS30TextBox.Tag = "";
            this.IEPS30TextBox.Text = "0.00";
            this.IEPS30TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IEPS30TextBox.ValidationExpression = null;
            this.IEPS30TextBox.ZeroIsValid = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(449, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 244;
            this.label7.Text = "Ieps 30:";
            // 
            // IEPS26CTextBox
            // 
            this.IEPS26CTextBox.AllowNegative = true;
            this.IEPS26CTextBox.Format_Expression = null;
            this.IEPS26CTextBox.Location = new System.Drawing.Point(290, 159);
            this.IEPS26CTextBox.Name = "IEPS26CTextBox";
            this.IEPS26CTextBox.NumericPrecision = 18;
            this.IEPS26CTextBox.NumericScaleOnFocus = 2;
            this.IEPS26CTextBox.NumericScaleOnLostFocus = 2;
            this.IEPS26CTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.IEPS26CTextBox.Size = new System.Drawing.Size(100, 20);
            this.IEPS26CTextBox.TabIndex = 243;
            this.IEPS26CTextBox.Tag = "";
            this.IEPS26CTextBox.Text = "0.00";
            this.IEPS26CTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IEPS26CTextBox.ValidationExpression = null;
            this.IEPS26CTextBox.ZeroIsValid = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(230, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 242;
            this.label8.Text = "Ieps 26c:";
            // 
            // IEPS26TextBox
            // 
            this.IEPS26TextBox.AllowNegative = true;
            this.IEPS26TextBox.Format_Expression = null;
            this.IEPS26TextBox.Location = new System.Drawing.Point(290, 133);
            this.IEPS26TextBox.Name = "IEPS26TextBox";
            this.IEPS26TextBox.NumericPrecision = 18;
            this.IEPS26TextBox.NumericScaleOnFocus = 2;
            this.IEPS26TextBox.NumericScaleOnLostFocus = 2;
            this.IEPS26TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.IEPS26TextBox.Size = new System.Drawing.Size(100, 20);
            this.IEPS26TextBox.TabIndex = 241;
            this.IEPS26TextBox.Tag = "";
            this.IEPS26TextBox.Text = "0.00";
            this.IEPS26TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IEPS26TextBox.ValidationExpression = null;
            this.IEPS26TextBox.ZeroIsValid = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(230, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 240;
            this.label9.Text = "Ieps 26:";
            // 
            // IEPS25TextBox
            // 
            this.IEPS25TextBox.AllowNegative = true;
            this.IEPS25TextBox.Format_Expression = null;
            this.IEPS25TextBox.Location = new System.Drawing.Point(89, 159);
            this.IEPS25TextBox.Name = "IEPS25TextBox";
            this.IEPS25TextBox.NumericPrecision = 18;
            this.IEPS25TextBox.NumericScaleOnFocus = 2;
            this.IEPS25TextBox.NumericScaleOnLostFocus = 2;
            this.IEPS25TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.IEPS25TextBox.Size = new System.Drawing.Size(100, 20);
            this.IEPS25TextBox.TabIndex = 239;
            this.IEPS25TextBox.Tag = "";
            this.IEPS25TextBox.Text = "0.00";
            this.IEPS25TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IEPS25TextBox.ValidationExpression = null;
            this.IEPS25TextBox.ZeroIsValid = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(29, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 238;
            this.label5.Text = "Ieps 25:";
            // 
            // IEPS8TextBox
            // 
            this.IEPS8TextBox.AllowNegative = true;
            this.IEPS8TextBox.Format_Expression = null;
            this.IEPS8TextBox.Location = new System.Drawing.Point(89, 133);
            this.IEPS8TextBox.Name = "IEPS8TextBox";
            this.IEPS8TextBox.NumericPrecision = 18;
            this.IEPS8TextBox.NumericScaleOnFocus = 2;
            this.IEPS8TextBox.NumericScaleOnLostFocus = 2;
            this.IEPS8TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.IEPS8TextBox.Size = new System.Drawing.Size(100, 20);
            this.IEPS8TextBox.TabIndex = 237;
            this.IEPS8TextBox.Tag = "";
            this.IEPS8TextBox.Text = "0.00";
            this.IEPS8TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IEPS8TextBox.ValidationExpression = null;
            this.IEPS8TextBox.ZeroIsValid = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(29, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 236;
            this.label4.Text = "Ieps 8:";
            // 
            // IVATextBox
            // 
            this.IVATextBox.AllowNegative = true;
            this.IVATextBox.Format_Expression = null;
            this.IVATextBox.Location = new System.Drawing.Point(289, 105);
            this.IVATextBox.Name = "IVATextBox";
            this.IVATextBox.NumericPrecision = 18;
            this.IVATextBox.NumericScaleOnFocus = 2;
            this.IVATextBox.NumericScaleOnLostFocus = 2;
            this.IVATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.IVATextBox.Size = new System.Drawing.Size(100, 20);
            this.IVATextBox.TabIndex = 235;
            this.IVATextBox.Tag = "";
            this.IVATextBox.Text = "0.00";
            this.IVATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IVATextBox.ValidationExpression = null;
            this.IVATextBox.ZeroIsValid = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(229, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 234;
            this.label3.Text = "Iva:";
            // 
            // SUMATextBox
            // 
            this.SUMATextBox.AllowNegative = true;
            this.SUMATextBox.Format_Expression = null;
            this.SUMATextBox.Location = new System.Drawing.Point(88, 105);
            this.SUMATextBox.Name = "SUMATextBox";
            this.SUMATextBox.NumericPrecision = 18;
            this.SUMATextBox.NumericScaleOnFocus = 2;
            this.SUMATextBox.NumericScaleOnLostFocus = 2;
            this.SUMATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SUMATextBox.Size = new System.Drawing.Size(100, 20);
            this.SUMATextBox.TabIndex = 233;
            this.SUMATextBox.Tag = "";
            this.SUMATextBox.Text = "0.00";
            this.SUMATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SUMATextBox.ValidationExpression = null;
            this.SUMATextBox.ZeroIsValid = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(28, 108);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 13);
            this.label20.TabIndex = 232;
            this.label20.Text = "Suma:";
            // 
            // ITEMButton
            // 
            this.ITEMButton.BackColor = System.Drawing.Color.Transparent;
            this.ITEMButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(189, 67);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(23, 23);
            this.ITEMButton.TabIndex = 229;
            this.ITEMButton.UseVisualStyleBackColor = false;
            this.ITEMButton.Click += new System.EventHandler(this.ITEMButton_Click);
            // 
            // PROVEEDORIDTextBox
            // 
            this.PROVEEDORIDTextBox.BotonLookUp = null;
            this.PROVEEDORIDTextBox.Condicion = null;
            this.PROVEEDORIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEEDORIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEEDORIDTextBox.DbValue = null;
            this.PROVEEDORIDTextBox.Format_Expression = null;
            this.PROVEEDORIDTextBox.IndiceCampoDescripcion = 2;
            this.PROVEEDORIDTextBox.IndiceCampoSelector = 1;
            this.PROVEEDORIDTextBox.IndiceCampoValue = 0;
            this.PROVEEDORIDTextBox.LabelDescription = this.ITEMLabel;
            this.PROVEEDORIDTextBox.Location = new System.Drawing.Point(89, 70);
            this.PROVEEDORIDTextBox.MostrarErrores = true;
            this.PROVEEDORIDTextBox.Name = "PROVEEDORIDTextBox";
            this.PROVEEDORIDTextBox.NombreCampoSelector = "clave";
            this.PROVEEDORIDTextBox.NombreCampoValue = "id";
            this.PROVEEDORIDTextBox.Query = "select id, clave, nombre, gaffete from persona where tipopersonaid  in (40) ";
            this.PROVEEDORIDTextBox.QueryDeSeleccion = "select id, clave, nombre, gaffete from persona where tipopersonaid  in (40) and  " +
    "clave= @clave";
            this.PROVEEDORIDTextBox.QueryPorDBValue = "select id, clave ,nombre, gaffete from persona where tipopersonaid  in (40) and  " +
    "id = @id";
            this.PROVEEDORIDTextBox.Size = new System.Drawing.Size(94, 20);
            this.PROVEEDORIDTextBox.TabIndex = 228;
            this.PROVEEDORIDTextBox.Tag = 34;
            this.PROVEEDORIDTextBox.TextDescription = null;
            this.PROVEEDORIDTextBox.Titulo = "Proveedores";
            this.PROVEEDORIDTextBox.ValidarEntrada = true;
            this.PROVEEDORIDTextBox.ValidationExpression = null;
            // 
            // ITEMLabel
            // 
            this.ITEMLabel.AutoSize = true;
            this.ITEMLabel.BackColor = System.Drawing.Color.Transparent;
            this.ITEMLabel.ForeColor = System.Drawing.Color.White;
            this.ITEMLabel.Location = new System.Drawing.Point(216, 72);
            this.ITEMLabel.Name = "ITEMLabel";
            this.ITEMLabel.Size = new System.Drawing.Size(16, 13);
            this.ITEMLabel.TabIndex = 231;
            this.ITEMLabel.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(6, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 230;
            this.label6.Text = "Proveedor:";
            // 
            // FECHARECEPCIONTextBox
            // 
            this.FECHARECEPCIONTextBox.AccessibleDescription = "";
            this.FECHARECEPCIONTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FECHARECEPCIONTextBox.Location = new System.Drawing.Point(377, 36);
            this.FECHARECEPCIONTextBox.Name = "FECHARECEPCIONTextBox";
            this.FECHARECEPCIONTextBox.Size = new System.Drawing.Size(124, 20);
            this.FECHARECEPCIONTextBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "";
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(302, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fecha Rec.:";
            // 
            // FECHAFACTURATextBox
            // 
            this.FECHAFACTURATextBox.AccessibleDescription = "";
            this.FECHAFACTURATextBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FECHAFACTURATextBox.Location = new System.Drawing.Point(88, 35);
            this.FECHAFACTURATextBox.Name = "FECHAFACTURATextBox";
            this.FECHAFACTURATextBox.Size = new System.Drawing.Size(124, 20);
            this.FECHAFACTURATextBox.TabIndex = 9;
            // 
            // FECHAFACTURALabel
            // 
            this.FECHAFACTURALabel.AccessibleDescription = "";
            this.FECHAFACTURALabel.AutoSize = true;
            this.FECHAFACTURALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FECHAFACTURALabel.ForeColor = System.Drawing.Color.White;
            this.FECHAFACTURALabel.Location = new System.Drawing.Point(13, 41);
            this.FECHAFACTURALabel.Name = "FECHAFACTURALabel";
            this.FECHAFACTURALabel.Size = new System.Drawing.Size(72, 13);
            this.FECHAFACTURALabel.TabIndex = 8;
            this.FECHAFACTURALabel.Text = "Fecha fac.:";
            // 
            // PROVISIONADACheckBox
            // 
            this.PROVISIONADACheckBox.AutoSize = true;
            this.PROVISIONADACheckBox.Location = new System.Drawing.Point(381, 12);
            this.PROVISIONADACheckBox.Name = "PROVISIONADACheckBox";
            this.PROVISIONADACheckBox.Size = new System.Drawing.Size(15, 14);
            this.PROVISIONADACheckBox.TabIndex = 7;
            this.PROVISIONADACheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(291, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Provisionada:";
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(92, 12);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ACTIVOTextBox.TabIndex = 5;
            this.ACTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // BTIniciaEdicion
            // 
            this.BTIniciaEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTIniciaEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTIniciaEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIniciaEdicion.ForeColor = System.Drawing.Color.White;
            this.BTIniciaEdicion.Location = new System.Drawing.Point(26, 321);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(57, 23);
            this.BTIniciaEdicion.TabIndex = 46;
            this.BTIniciaEdicion.Text = "Editar";
            this.BTIniciaEdicion.UseVisualStyleBackColor = false;
            this.BTIniciaEdicion.Visible = false;
            this.BTIniciaEdicion.Click += new System.EventHandler(this.BTIniciaEdicion_Click);
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
            this.BTCancelar.Location = new System.Drawing.Point(213, 317);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(112, 30);
            this.BTCancelar.TabIndex = 47;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // pnlCargaPorFolio
            // 
            this.pnlCargaPorFolio.BackColor = System.Drawing.Color.Transparent;
            this.pnlCargaPorFolio.Controls.Add(this.BTSeleccionar);
            this.pnlCargaPorFolio.Controls.Add(this.label10);
            this.pnlCargaPorFolio.Controls.Add(this.TBFolio);
            this.pnlCargaPorFolio.Controls.Add(label13);
            this.pnlCargaPorFolio.Controls.Add(this.SUCURSALIDLabel);
            this.pnlCargaPorFolio.Controls.Add(this.SUCURSALIDButton);
            this.pnlCargaPorFolio.Controls.Add(this.SUCURSALIDTextBox);
            this.pnlCargaPorFolio.Controls.Add(this.btnCargarInformacion);
            this.pnlCargaPorFolio.Controls.Add(this.lblCargarInformacion);
            this.pnlCargaPorFolio.Location = new System.Drawing.Point(265, 4);
            this.pnlCargaPorFolio.Name = "pnlCargaPorFolio";
            this.pnlCargaPorFolio.Size = new System.Drawing.Size(448, 100);
            this.pnlCargaPorFolio.TabIndex = 234;
            // 
            // BTSeleccionar
            // 
            this.BTSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTSeleccionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSeleccionar.ForeColor = System.Drawing.Color.White;
            this.BTSeleccionar.Location = new System.Drawing.Point(209, 60);
            this.BTSeleccionar.Name = "BTSeleccionar";
            this.BTSeleccionar.Size = new System.Drawing.Size(34, 23);
            this.BTSeleccionar.TabIndex = 242;
            this.BTSeleccionar.Text = "...";
            this.BTSeleccionar.UseVisualStyleBackColor = false;
            this.BTSeleccionar.Click += new System.EventHandler(this.BTSeleccionar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(11, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 240;
            this.label10.Text = "Folio:";
            // 
            // TBFolio
            // 
            this.TBFolio.Location = new System.Drawing.Point(61, 62);
            this.TBFolio.Name = "TBFolio";
            this.TBFolio.Size = new System.Drawing.Size(142, 20);
            this.TBFolio.TabIndex = 241;
            // 
            // SUCURSALIDLabel
            // 
            this.SUCURSALIDLabel.AutoSize = true;
            this.SUCURSALIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.SUCURSALIDLabel.ForeColor = System.Drawing.Color.White;
            this.SUCURSALIDLabel.Location = new System.Drawing.Point(191, 35);
            this.SUCURSALIDLabel.Name = "SUCURSALIDLabel";
            this.SUCURSALIDLabel.Size = new System.Drawing.Size(16, 13);
            this.SUCURSALIDLabel.TabIndex = 238;
            this.SUCURSALIDLabel.Text = "...";
            // 
            // SUCURSALIDButton
            // 
            this.SUCURSALIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SUCURSALIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SUCURSALIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SUCURSALIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SUCURSALIDButton.Location = new System.Drawing.Point(161, 30);
            this.SUCURSALIDButton.Name = "SUCURSALIDButton";
            this.SUCURSALIDButton.Size = new System.Drawing.Size(24, 23);
            this.SUCURSALIDButton.TabIndex = 237;
            this.SUCURSALIDButton.UseVisualStyleBackColor = true;
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
            this.SUCURSALIDTextBox.Location = new System.Drawing.Point(60, 32);
            this.SUCURSALIDTextBox.MostrarErrores = true;
            this.SUCURSALIDTextBox.Name = "SUCURSALIDTextBox";
            this.SUCURSALIDTextBox.NombreCampoSelector = "clave";
            this.SUCURSALIDTextBox.NombreCampoValue = "id";
            this.SUCURSALIDTextBox.Query = "select id,clave,nombre from sucursal";
            this.SUCURSALIDTextBox.QueryDeSeleccion = "select id,clave,nombre from sucursal where  clave = @clave";
            this.SUCURSALIDTextBox.QueryPorDBValue = "select id,clave,nombre from sucursal where  id = @id";
            this.SUCURSALIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.SUCURSALIDTextBox.TabIndex = 236;
            this.SUCURSALIDTextBox.Tag = 34;
            this.SUCURSALIDTextBox.TextDescription = null;
            this.SUCURSALIDTextBox.Titulo = "Sucursal";
            this.SUCURSALIDTextBox.ValidarEntrada = true;
            this.SUCURSALIDTextBox.ValidationExpression = null;
            // 
            // btnCargarInformacion
            // 
            this.btnCargarInformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCargarInformacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCargarInformacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCargarInformacion.ForeColor = System.Drawing.Color.White;
            this.btnCargarInformacion.Location = new System.Drawing.Point(278, 57);
            this.btnCargarInformacion.Name = "btnCargarInformacion";
            this.btnCargarInformacion.Size = new System.Drawing.Size(136, 29);
            this.btnCargarInformacion.TabIndex = 235;
            this.btnCargarInformacion.Text = "Cargar informacion";
            this.btnCargarInformacion.UseVisualStyleBackColor = false;
            this.btnCargarInformacion.Click += new System.EventHandler(this.btnCargarInformacion_Click);
            // 
            // lblCargarInformacion
            // 
            this.lblCargarInformacion.AutoSize = true;
            this.lblCargarInformacion.BackColor = System.Drawing.Color.Transparent;
            this.lblCargarInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargarInformacion.ForeColor = System.Drawing.Color.White;
            this.lblCargarInformacion.Location = new System.Drawing.Point(3, 5);
            this.lblCargarInformacion.Name = "lblCargarInformacion";
            this.lblCargarInformacion.Size = new System.Drawing.Size(327, 15);
            this.lblCargarInformacion.TabIndex = 234;
            this.lblCargarInformacion.Text = "CARGAR INFORMACION POR FOLIO Y SUCURSAL";
            // 
            // dSAbonos2
            // 
            this.dSAbonos2.DataSetName = "DSAbonos2";
            this.dSAbonos2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cOMPRASFACTURABindingSource
            // 
            this.cOMPRASFACTURABindingSource.DataMember = "COMPRASFACTURA";
            this.cOMPRASFACTURABindingSource.DataSource = this.dSAbonos2;
            // 
            // cOMPRASFACTURATableAdapter
            // 
            this.cOMPRASFACTURATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Abonos.DSAbonos2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // pnlIngresoManual
            // 
            this.pnlIngresoManual.BackColor = System.Drawing.Color.Transparent;
            this.pnlIngresoManual.Controls.Add(this.lblIngresoManual);
            this.pnlIngresoManual.Controls.Add(this.CLAVELabel);
            this.pnlIngresoManual.Controls.Add(this.FACTURATextBox);
            this.pnlIngresoManual.Location = new System.Drawing.Point(9, 4);
            this.pnlIngresoManual.Name = "pnlIngresoManual";
            this.pnlIngresoManual.Size = new System.Drawing.Size(250, 100);
            this.pnlIngresoManual.TabIndex = 250;
            // 
            // lblIngresoManual
            // 
            this.lblIngresoManual.AutoSize = true;
            this.lblIngresoManual.BackColor = System.Drawing.Color.Transparent;
            this.lblIngresoManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresoManual.ForeColor = System.Drawing.Color.White;
            this.lblIngresoManual.Location = new System.Drawing.Point(3, 5);
            this.lblIngresoManual.Name = "lblIngresoManual";
            this.lblIngresoManual.Size = new System.Drawing.Size(129, 15);
            this.lblIngresoManual.TabIndex = 235;
            this.lblIngresoManual.Text = "INGRESO MANUAL";
            // 
            // WFFacturaCompOrigEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(730, 355);
            this.Controls.Add(this.pnlIngresoManual);
            this.Controls.Add(this.pnlCargaPorFolio);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WFFacturaCompOrigEdit";
            this.Text = "Factura compra original";
            this.Load += new System.EventHandler(this.LINEAEdit_Reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlCargaPorFolio.ResumeLayout(false);
            this.pnlCargaPorFolio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSAbonos2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMPRASFACTURABindingSource)).EndInit();
            this.pnlIngresoManual.ResumeLayout(false);
            this.pnlIngresoManual.PerformLayout();
            this.ResumeLayout(false);

  }

  #endregion



        private System.Windows.Forms.TextBox FACTURATextBox;

        private System.Windows.Forms.Panel panel1;
  
  private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
  private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.Label LBError;



        private System.Windows.Forms.Label ACTIVOLabel;
        private System.Windows.Forms.Label CLAVELabel;
        private System.Windows.Forms.Button BTIniciaEdicion;
        private System.Windows.Forms.CheckBox ACTIVOTextBox;
        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.CheckBox PROVISIONADACheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FECHARECEPCIONTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FECHAFACTURATextBox;
        private System.Windows.Forms.Label FECHAFACTURALabel;
        private System.Windows.Forms.Button ITEMButton;
        private Tools.TextBoxFB PROVEEDORIDTextBox;
        private System.Windows.Forms.Label ITEMLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericTextBox TOTALTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericTextBox IEPS53TextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericTextBox IEPS30TextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericTextBox IEPS26CTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericTextBox IEPS26TextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericTextBox IEPS25TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericTextBox IEPS8TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericTextBox IVATextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericTextBox SUMATextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel pnlCargaPorFolio;
        private System.Windows.Forms.Label lblCargarInformacion;
        private System.Windows.Forms.Button btnCargarInformacion;
        private System.Windows.Forms.Button BTSeleccionar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TBFolio;
        private System.Windows.Forms.Label SUCURSALIDLabel;
        private System.Windows.Forms.Button SUCURSALIDButton;
        private Tools.TextBoxFB SUCURSALIDTextBox;
        private Abonos.DSAbonos2 dSAbonos2;
        private System.Windows.Forms.BindingSource cOMPRASFACTURABindingSource;
        private Abonos.DSAbonos2TableAdapters.COMPRASFACTURATableAdapter cOMPRASFACTURATableAdapter;
        private Abonos.DSAbonos2TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Panel pnlIngresoManual;
        private System.Windows.Forms.Label lblIngresoManual;
    }
}

