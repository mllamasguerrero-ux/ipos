namespace iPos
{
    partial class CortesDelDiaConAjuste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CortesDelDiaConAjuste));
            this.DTFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataSet1 = new iPos.ReimpresionTicket.DataSet1();
            this.corteTicketFechaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.corteTicketFechaTableAdapter = new iPos.ReimpresionTicket.DataSet1TableAdapters.CorteTicketFechaTableAdapter();
            this.tableAdapterManager = new iPos.ReimpresionTicket.DataSet1TableAdapters.TableAdapterManager();
            this.dSPuntoVenta = new iPos.PuntoDeVenta.DSPuntoVenta();
            this.corteTrasladosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.corteTrasladosTableAdapter = new iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.CorteTrasladosTableAdapter();
            this.tableAdapterManager1 = new iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.TableAdapterManager();
            this.PORC_A_IVATextBox = new System.Windows.Forms.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.subTotalConIvaTextBox = new System.Windows.Forms.NumericTextBox();
            this.subTotalSinIvaTextBox = new System.Windows.Forms.NumericTextBox();
            this.impuestoConIvaTextBox = new System.Windows.Forms.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.totalConIvaTextBox = new System.Windows.Forms.NumericTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.totalSinIvaTextBox = new System.Windows.Forms.NumericTextBox();
            this.subtotalesTextBox = new System.Windows.Forms.NumericTextBox();
            this.impuestoTotalesTextBox = new System.Windows.Forms.NumericTextBox();
            this.totalTextBox = new System.Windows.Forms.NumericTextBox();
            this.totalAjustadoTextBox = new System.Windows.Forms.NumericTextBox();
            this.impuestoTotalesAjustadoTextBox = new System.Windows.Forms.NumericTextBox();
            this.subtotalesAjustadoTextBox = new System.Windows.Forms.NumericTextBox();
            this.totalSinIvaAjustadoTextBox = new System.Windows.Forms.NumericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.totalConIvaAjustadoTextBox = new System.Windows.Forms.NumericTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.impuestoConIvaAjustadoTextBox = new System.Windows.Forms.NumericTextBox();
            this.subTotalSinIvaAjustadoTextBox = new System.Windows.Forms.NumericTextBox();
            this.subTotalConIvaAjustadoTextBox = new System.Windows.Forms.NumericTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.TASAIVATextBox = new System.Windows.Forms.NumericTextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnAplicarPorcentaje = new System.Windows.Forms.Button();
            this.dSReimpresionTicket = new iPos.ReimpresionTicket.DSReimpresionTicket();
            this.corteTicketSumarizadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.corteTicketSumarizadoTableAdapter = new iPos.ReimpresionTicket.DSReimpresionTicketTableAdapters.CorteTicketSumarizadoTableAdapter();
            this.tableAdapterManager2 = new iPos.ReimpresionTicket.DSReimpresionTicketTableAdapters.TableAdapterManager();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corteTicketFechaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corteTrasladosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReimpresionTicket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corteTicketSumarizadoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DTFecha
            // 
            this.DTFecha.Location = new System.Drawing.Point(317, 36);
            this.DTFecha.Name = "DTFecha";
            this.DTFecha.Size = new System.Drawing.Size(233, 20);
            this.DTFecha.TabIndex = 0;
            this.DTFecha.ValueChanged += new System.EventHandler(this.DTFecha_ValueChanged);
            this.DTFecha.Validated += new System.EventHandler(this.DTFecha_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(268, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dia:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(292, 375);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 34);
            this.button1.TabIndex = 22;
            this.button1.Text = "Obtener reporte por cajero";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // corteTicketFechaBindingSource
            // 
            this.corteTicketFechaBindingSource.DataMember = "CorteTicketFecha";
            this.corteTicketFechaBindingSource.DataSource = this.dataSet1;
            // 
            // corteTicketFechaTableAdapter
            // 
            this.corteTicketFechaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.ReimpresionTicket.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dSPuntoVenta
            // 
            this.dSPuntoVenta.DataSetName = "DSPuntoVenta";
            this.dSPuntoVenta.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dSPuntoVenta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // corteTrasladosBindingSource
            // 
            this.corteTrasladosBindingSource.DataMember = "CorteTraslados";
            this.corteTrasladosBindingSource.DataSource = this.dSPuntoVenta;
            // 
            // corteTrasladosTableAdapter
            // 
            this.corteTrasladosTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // PORC_A_IVATextBox
            // 
            this.PORC_A_IVATextBox.AllowNegative = true;
            this.PORC_A_IVATextBox.Format_Expression = null;
            this.PORC_A_IVATextBox.Location = new System.Drawing.Point(271, 212);
            this.PORC_A_IVATextBox.Name = "PORC_A_IVATextBox";
            this.PORC_A_IVATextBox.NumericPrecision = 18;
            this.PORC_A_IVATextBox.NumericScaleOnFocus = 2;
            this.PORC_A_IVATextBox.NumericScaleOnLostFocus = 2;
            this.PORC_A_IVATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PORC_A_IVATextBox.Size = new System.Drawing.Size(100, 20);
            this.PORC_A_IVATextBox.TabIndex = 10;
            this.PORC_A_IVATextBox.Tag = "41";
            this.PORC_A_IVATextBox.Text = "0";
            this.PORC_A_IVATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PORC_A_IVATextBox.ValidationExpression = null;
            this.PORC_A_IVATextBox.ZeroIsValid = true;
            this.PORC_A_IVATextBox.Validated += new System.EventHandler(this.PORC_A_IVATextBox_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(162, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Porcentaje de ajuste de paso a IVA:";
            // 
            // subTotalConIvaTextBox
            // 
            this.subTotalConIvaTextBox.AllowNegative = true;
            this.subTotalConIvaTextBox.Format_Expression = null;
            this.subTotalConIvaTextBox.Location = new System.Drawing.Point(271, 97);
            this.subTotalConIvaTextBox.Name = "subTotalConIvaTextBox";
            this.subTotalConIvaTextBox.NumericPrecision = 18;
            this.subTotalConIvaTextBox.NumericScaleOnFocus = 2;
            this.subTotalConIvaTextBox.NumericScaleOnLostFocus = 2;
            this.subTotalConIvaTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.subTotalConIvaTextBox.ReadOnly = true;
            this.subTotalConIvaTextBox.Size = new System.Drawing.Size(100, 20);
            this.subTotalConIvaTextBox.TabIndex = 2;
            this.subTotalConIvaTextBox.Tag = 34;
            this.subTotalConIvaTextBox.Text = "0";
            this.subTotalConIvaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.subTotalConIvaTextBox.ValidationExpression = null;
            this.subTotalConIvaTextBox.ZeroIsValid = true;
            // 
            // subTotalSinIvaTextBox
            // 
            this.subTotalSinIvaTextBox.AllowNegative = true;
            this.subTotalSinIvaTextBox.Format_Expression = null;
            this.subTotalSinIvaTextBox.Location = new System.Drawing.Point(390, 97);
            this.subTotalSinIvaTextBox.Name = "subTotalSinIvaTextBox";
            this.subTotalSinIvaTextBox.NumericPrecision = 18;
            this.subTotalSinIvaTextBox.NumericScaleOnFocus = 2;
            this.subTotalSinIvaTextBox.NumericScaleOnLostFocus = 2;
            this.subTotalSinIvaTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.subTotalSinIvaTextBox.ReadOnly = true;
            this.subTotalSinIvaTextBox.Size = new System.Drawing.Size(100, 20);
            this.subTotalSinIvaTextBox.TabIndex = 3;
            this.subTotalSinIvaTextBox.Tag = 34;
            this.subTotalSinIvaTextBox.Text = "0";
            this.subTotalSinIvaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.subTotalSinIvaTextBox.ValidationExpression = null;
            this.subTotalSinIvaTextBox.ZeroIsValid = true;
            // 
            // impuestoConIvaTextBox
            // 
            this.impuestoConIvaTextBox.AllowNegative = true;
            this.impuestoConIvaTextBox.Format_Expression = null;
            this.impuestoConIvaTextBox.Location = new System.Drawing.Point(271, 126);
            this.impuestoConIvaTextBox.Name = "impuestoConIvaTextBox";
            this.impuestoConIvaTextBox.NumericPrecision = 18;
            this.impuestoConIvaTextBox.NumericScaleOnFocus = 2;
            this.impuestoConIvaTextBox.NumericScaleOnLostFocus = 2;
            this.impuestoConIvaTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.impuestoConIvaTextBox.ReadOnly = true;
            this.impuestoConIvaTextBox.Size = new System.Drawing.Size(100, 20);
            this.impuestoConIvaTextBox.TabIndex = 5;
            this.impuestoConIvaTextBox.Tag = 34;
            this.impuestoConIvaTextBox.Text = "0";
            this.impuestoConIvaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.impuestoConIvaTextBox.ValidationExpression = null;
            this.impuestoConIvaTextBox.ZeroIsValid = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(197, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Subtotal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(193, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Impuesto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(289, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Con IVA:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(406, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Sin IVA:";
            // 
            // totalConIvaTextBox
            // 
            this.totalConIvaTextBox.AllowNegative = true;
            this.totalConIvaTextBox.Format_Expression = null;
            this.totalConIvaTextBox.Location = new System.Drawing.Point(271, 154);
            this.totalConIvaTextBox.Name = "totalConIvaTextBox";
            this.totalConIvaTextBox.NumericPrecision = 18;
            this.totalConIvaTextBox.NumericScaleOnFocus = 2;
            this.totalConIvaTextBox.NumericScaleOnLostFocus = 2;
            this.totalConIvaTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalConIvaTextBox.ReadOnly = true;
            this.totalConIvaTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalConIvaTextBox.TabIndex = 7;
            this.totalConIvaTextBox.Tag = 34;
            this.totalConIvaTextBox.Text = "0";
            this.totalConIvaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalConIvaTextBox.ValidationExpression = null;
            this.totalConIvaTextBox.ZeroIsValid = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(202, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Totales:";
            // 
            // totalSinIvaTextBox
            // 
            this.totalSinIvaTextBox.AllowNegative = true;
            this.totalSinIvaTextBox.Format_Expression = null;
            this.totalSinIvaTextBox.Location = new System.Drawing.Point(390, 154);
            this.totalSinIvaTextBox.Name = "totalSinIvaTextBox";
            this.totalSinIvaTextBox.NumericPrecision = 18;
            this.totalSinIvaTextBox.NumericScaleOnFocus = 2;
            this.totalSinIvaTextBox.NumericScaleOnLostFocus = 2;
            this.totalSinIvaTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalSinIvaTextBox.ReadOnly = true;
            this.totalSinIvaTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalSinIvaTextBox.TabIndex = 8;
            this.totalSinIvaTextBox.Tag = 34;
            this.totalSinIvaTextBox.Text = "0";
            this.totalSinIvaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalSinIvaTextBox.ValidationExpression = null;
            this.totalSinIvaTextBox.ZeroIsValid = true;
            // 
            // subtotalesTextBox
            // 
            this.subtotalesTextBox.AllowNegative = true;
            this.subtotalesTextBox.Format_Expression = null;
            this.subtotalesTextBox.Location = new System.Drawing.Point(510, 97);
            this.subtotalesTextBox.Name = "subtotalesTextBox";
            this.subtotalesTextBox.NumericPrecision = 18;
            this.subtotalesTextBox.NumericScaleOnFocus = 2;
            this.subtotalesTextBox.NumericScaleOnLostFocus = 2;
            this.subtotalesTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.subtotalesTextBox.ReadOnly = true;
            this.subtotalesTextBox.Size = new System.Drawing.Size(100, 20);
            this.subtotalesTextBox.TabIndex = 4;
            this.subtotalesTextBox.Tag = 34;
            this.subtotalesTextBox.Text = "0";
            this.subtotalesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.subtotalesTextBox.ValidationExpression = null;
            this.subtotalesTextBox.ZeroIsValid = true;
            // 
            // impuestoTotalesTextBox
            // 
            this.impuestoTotalesTextBox.AllowNegative = true;
            this.impuestoTotalesTextBox.Format_Expression = null;
            this.impuestoTotalesTextBox.Location = new System.Drawing.Point(510, 126);
            this.impuestoTotalesTextBox.Name = "impuestoTotalesTextBox";
            this.impuestoTotalesTextBox.NumericPrecision = 18;
            this.impuestoTotalesTextBox.NumericScaleOnFocus = 2;
            this.impuestoTotalesTextBox.NumericScaleOnLostFocus = 2;
            this.impuestoTotalesTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.impuestoTotalesTextBox.ReadOnly = true;
            this.impuestoTotalesTextBox.Size = new System.Drawing.Size(100, 20);
            this.impuestoTotalesTextBox.TabIndex = 6;
            this.impuestoTotalesTextBox.Tag = 34;
            this.impuestoTotalesTextBox.Text = "0";
            this.impuestoTotalesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.impuestoTotalesTextBox.ValidationExpression = null;
            this.impuestoTotalesTextBox.ZeroIsValid = true;
            // 
            // totalTextBox
            // 
            this.totalTextBox.AllowNegative = true;
            this.totalTextBox.Format_Expression = null;
            this.totalTextBox.Location = new System.Drawing.Point(510, 154);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.NumericPrecision = 18;
            this.totalTextBox.NumericScaleOnFocus = 2;
            this.totalTextBox.NumericScaleOnLostFocus = 2;
            this.totalTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalTextBox.ReadOnly = true;
            this.totalTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalTextBox.TabIndex = 9;
            this.totalTextBox.Tag = 34;
            this.totalTextBox.Text = "0";
            this.totalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalTextBox.ValidationExpression = null;
            this.totalTextBox.ZeroIsValid = true;
            // 
            // totalAjustadoTextBox
            // 
            this.totalAjustadoTextBox.AllowNegative = true;
            this.totalAjustadoTextBox.Format_Expression = null;
            this.totalAjustadoTextBox.Location = new System.Drawing.Point(510, 325);
            this.totalAjustadoTextBox.Name = "totalAjustadoTextBox";
            this.totalAjustadoTextBox.NumericPrecision = 18;
            this.totalAjustadoTextBox.NumericScaleOnFocus = 2;
            this.totalAjustadoTextBox.NumericScaleOnLostFocus = 2;
            this.totalAjustadoTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalAjustadoTextBox.ReadOnly = true;
            this.totalAjustadoTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalAjustadoTextBox.TabIndex = 21;
            this.totalAjustadoTextBox.Tag = 34;
            this.totalAjustadoTextBox.Text = "0";
            this.totalAjustadoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalAjustadoTextBox.ValidationExpression = null;
            this.totalAjustadoTextBox.ZeroIsValid = true;
            // 
            // impuestoTotalesAjustadoTextBox
            // 
            this.impuestoTotalesAjustadoTextBox.AllowNegative = true;
            this.impuestoTotalesAjustadoTextBox.Format_Expression = null;
            this.impuestoTotalesAjustadoTextBox.Location = new System.Drawing.Point(510, 299);
            this.impuestoTotalesAjustadoTextBox.Name = "impuestoTotalesAjustadoTextBox";
            this.impuestoTotalesAjustadoTextBox.NumericPrecision = 18;
            this.impuestoTotalesAjustadoTextBox.NumericScaleOnFocus = 2;
            this.impuestoTotalesAjustadoTextBox.NumericScaleOnLostFocus = 2;
            this.impuestoTotalesAjustadoTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.impuestoTotalesAjustadoTextBox.ReadOnly = true;
            this.impuestoTotalesAjustadoTextBox.Size = new System.Drawing.Size(100, 20);
            this.impuestoTotalesAjustadoTextBox.TabIndex = 18;
            this.impuestoTotalesAjustadoTextBox.Tag = 34;
            this.impuestoTotalesAjustadoTextBox.Text = "0";
            this.impuestoTotalesAjustadoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.impuestoTotalesAjustadoTextBox.ValidationExpression = null;
            this.impuestoTotalesAjustadoTextBox.ZeroIsValid = true;
            // 
            // subtotalesAjustadoTextBox
            // 
            this.subtotalesAjustadoTextBox.AllowNegative = true;
            this.subtotalesAjustadoTextBox.Format_Expression = null;
            this.subtotalesAjustadoTextBox.Location = new System.Drawing.Point(510, 270);
            this.subtotalesAjustadoTextBox.Name = "subtotalesAjustadoTextBox";
            this.subtotalesAjustadoTextBox.NumericPrecision = 18;
            this.subtotalesAjustadoTextBox.NumericScaleOnFocus = 2;
            this.subtotalesAjustadoTextBox.NumericScaleOnLostFocus = 2;
            this.subtotalesAjustadoTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.subtotalesAjustadoTextBox.ReadOnly = true;
            this.subtotalesAjustadoTextBox.Size = new System.Drawing.Size(100, 20);
            this.subtotalesAjustadoTextBox.TabIndex = 16;
            this.subtotalesAjustadoTextBox.Tag = 34;
            this.subtotalesAjustadoTextBox.Text = "0";
            this.subtotalesAjustadoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.subtotalesAjustadoTextBox.ValidationExpression = null;
            this.subtotalesAjustadoTextBox.ZeroIsValid = true;
            // 
            // totalSinIvaAjustadoTextBox
            // 
            this.totalSinIvaAjustadoTextBox.AllowNegative = true;
            this.totalSinIvaAjustadoTextBox.Format_Expression = null;
            this.totalSinIvaAjustadoTextBox.Location = new System.Drawing.Point(390, 325);
            this.totalSinIvaAjustadoTextBox.Name = "totalSinIvaAjustadoTextBox";
            this.totalSinIvaAjustadoTextBox.NumericPrecision = 18;
            this.totalSinIvaAjustadoTextBox.NumericScaleOnFocus = 2;
            this.totalSinIvaAjustadoTextBox.NumericScaleOnLostFocus = 2;
            this.totalSinIvaAjustadoTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalSinIvaAjustadoTextBox.ReadOnly = true;
            this.totalSinIvaAjustadoTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalSinIvaAjustadoTextBox.TabIndex = 20;
            this.totalSinIvaAjustadoTextBox.Tag = 34;
            this.totalSinIvaAjustadoTextBox.Text = "0";
            this.totalSinIvaAjustadoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalSinIvaAjustadoTextBox.ValidationExpression = null;
            this.totalSinIvaAjustadoTextBox.ZeroIsValid = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(202, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "Totales:";
            // 
            // totalConIvaAjustadoTextBox
            // 
            this.totalConIvaAjustadoTextBox.AllowNegative = true;
            this.totalConIvaAjustadoTextBox.Format_Expression = null;
            this.totalConIvaAjustadoTextBox.Location = new System.Drawing.Point(271, 325);
            this.totalConIvaAjustadoTextBox.Name = "totalConIvaAjustadoTextBox";
            this.totalConIvaAjustadoTextBox.NumericPrecision = 18;
            this.totalConIvaAjustadoTextBox.NumericScaleOnFocus = 2;
            this.totalConIvaAjustadoTextBox.NumericScaleOnLostFocus = 2;
            this.totalConIvaAjustadoTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalConIvaAjustadoTextBox.ReadOnly = true;
            this.totalConIvaAjustadoTextBox.Size = new System.Drawing.Size(100, 20);
            this.totalConIvaAjustadoTextBox.TabIndex = 19;
            this.totalConIvaAjustadoTextBox.Tag = 34;
            this.totalConIvaAjustadoTextBox.Text = "0";
            this.totalConIvaAjustadoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalConIvaAjustadoTextBox.ValidationExpression = null;
            this.totalConIvaAjustadoTextBox.ZeroIsValid = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(406, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 73;
            this.label9.Text = "Sin IVA:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(289, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 72;
            this.label10.Text = "Con IVA:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(193, 302);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 71;
            this.label11.Text = "Impuesto:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(197, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 70;
            this.label12.Text = "Subtotal:";
            // 
            // impuestoConIvaAjustadoTextBox
            // 
            this.impuestoConIvaAjustadoTextBox.AllowNegative = true;
            this.impuestoConIvaAjustadoTextBox.Format_Expression = null;
            this.impuestoConIvaAjustadoTextBox.Location = new System.Drawing.Point(271, 299);
            this.impuestoConIvaAjustadoTextBox.Name = "impuestoConIvaAjustadoTextBox";
            this.impuestoConIvaAjustadoTextBox.NumericPrecision = 18;
            this.impuestoConIvaAjustadoTextBox.NumericScaleOnFocus = 2;
            this.impuestoConIvaAjustadoTextBox.NumericScaleOnLostFocus = 2;
            this.impuestoConIvaAjustadoTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.impuestoConIvaAjustadoTextBox.ReadOnly = true;
            this.impuestoConIvaAjustadoTextBox.Size = new System.Drawing.Size(100, 20);
            this.impuestoConIvaAjustadoTextBox.TabIndex = 17;
            this.impuestoConIvaAjustadoTextBox.Tag = 34;
            this.impuestoConIvaAjustadoTextBox.Text = "0";
            this.impuestoConIvaAjustadoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.impuestoConIvaAjustadoTextBox.ValidationExpression = null;
            this.impuestoConIvaAjustadoTextBox.ZeroIsValid = true;
            // 
            // subTotalSinIvaAjustadoTextBox
            // 
            this.subTotalSinIvaAjustadoTextBox.AllowNegative = true;
            this.subTotalSinIvaAjustadoTextBox.Format_Expression = null;
            this.subTotalSinIvaAjustadoTextBox.Location = new System.Drawing.Point(390, 270);
            this.subTotalSinIvaAjustadoTextBox.Name = "subTotalSinIvaAjustadoTextBox";
            this.subTotalSinIvaAjustadoTextBox.NumericPrecision = 18;
            this.subTotalSinIvaAjustadoTextBox.NumericScaleOnFocus = 2;
            this.subTotalSinIvaAjustadoTextBox.NumericScaleOnLostFocus = 2;
            this.subTotalSinIvaAjustadoTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.subTotalSinIvaAjustadoTextBox.ReadOnly = true;
            this.subTotalSinIvaAjustadoTextBox.Size = new System.Drawing.Size(100, 20);
            this.subTotalSinIvaAjustadoTextBox.TabIndex = 15;
            this.subTotalSinIvaAjustadoTextBox.Tag = 34;
            this.subTotalSinIvaAjustadoTextBox.Text = "0";
            this.subTotalSinIvaAjustadoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.subTotalSinIvaAjustadoTextBox.ValidationExpression = null;
            this.subTotalSinIvaAjustadoTextBox.ZeroIsValid = true;
            // 
            // subTotalConIvaAjustadoTextBox
            // 
            this.subTotalConIvaAjustadoTextBox.AllowNegative = true;
            this.subTotalConIvaAjustadoTextBox.Format_Expression = null;
            this.subTotalConIvaAjustadoTextBox.Location = new System.Drawing.Point(271, 270);
            this.subTotalConIvaAjustadoTextBox.Name = "subTotalConIvaAjustadoTextBox";
            this.subTotalConIvaAjustadoTextBox.NumericPrecision = 18;
            this.subTotalConIvaAjustadoTextBox.NumericScaleOnFocus = 2;
            this.subTotalConIvaAjustadoTextBox.NumericScaleOnLostFocus = 2;
            this.subTotalConIvaAjustadoTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.subTotalConIvaAjustadoTextBox.ReadOnly = true;
            this.subTotalConIvaAjustadoTextBox.Size = new System.Drawing.Size(100, 20);
            this.subTotalConIvaAjustadoTextBox.TabIndex = 14;
            this.subTotalConIvaAjustadoTextBox.Tag = 34;
            this.subTotalConIvaAjustadoTextBox.Text = "0";
            this.subTotalConIvaAjustadoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.subTotalConIvaAjustadoTextBox.ValidationExpression = null;
            this.subTotalConIvaAjustadoTextBox.ZeroIsValid = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(106, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 15);
            this.label13.TabIndex = 80;
            this.label13.Text = "Cantidades sin ajuste:";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(102, 252);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(153, 15);
            this.label14.TabIndex = 81;
            this.label14.Text = "Cantidades con ajuste:";
            // 
            // TASAIVATextBox
            // 
            this.TASAIVATextBox.AllowNegative = true;
            this.TASAIVATextBox.Format_Expression = null;
            this.TASAIVATextBox.Location = new System.Drawing.Point(390, 212);
            this.TASAIVATextBox.Name = "TASAIVATextBox";
            this.TASAIVATextBox.NumericPrecision = 18;
            this.TASAIVATextBox.NumericScaleOnFocus = 2;
            this.TASAIVATextBox.NumericScaleOnLostFocus = 2;
            this.TASAIVATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TASAIVATextBox.Size = new System.Drawing.Size(100, 20);
            this.TASAIVATextBox.TabIndex = 11;
            this.TASAIVATextBox.Tag = "41";
            this.TASAIVATextBox.Text = "0";
            this.TASAIVATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TASAIVATextBox.ValidationExpression = null;
            this.TASAIVATextBox.ZeroIsValid = true;
            this.TASAIVATextBox.Validated += new System.EventHandler(this.TASAIVATextBox_Validated);
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCalcular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcular.ForeColor = System.Drawing.Color.White;
            this.btnCalcular.Location = new System.Drawing.Point(510, 209);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(100, 23);
            this.btnCalcular.TabIndex = 12;
            this.btnCalcular.Text = "Recalcular";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnAplicarPorcentaje
            // 
            this.btnAplicarPorcentaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnAplicarPorcentaje.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAplicarPorcentaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarPorcentaje.ForeColor = System.Drawing.Color.White;
            this.btnAplicarPorcentaje.Location = new System.Drawing.Point(625, 209);
            this.btnAplicarPorcentaje.Name = "btnAplicarPorcentaje";
            this.btnAplicarPorcentaje.Size = new System.Drawing.Size(109, 23);
            this.btnAplicarPorcentaje.TabIndex = 13;
            this.btnAplicarPorcentaje.Text = "Guardar ajuste";
            this.btnAplicarPorcentaje.UseVisualStyleBackColor = false;
            this.btnAplicarPorcentaje.Click += new System.EventHandler(this.btnAplicarPorcentaje_Click);
            // 
            // dSReimpresionTicket
            // 
            this.dSReimpresionTicket.DataSetName = "DSReimpresionTicket";
            this.dSReimpresionTicket.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // corteTicketSumarizadoBindingSource
            // 
            this.corteTicketSumarizadoBindingSource.DataMember = "CorteTicketSumarizado";
            this.corteTicketSumarizadoBindingSource.DataSource = this.dSReimpresionTicket;
            // 
            // corteTicketSumarizadoTableAdapter
            // 
            this.corteTicketSumarizadoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager2
            // 
            this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager2.Connection = null;
            this.tableAdapterManager2.CORTETableAdapter = null;
            this.tableAdapterManager2.UpdateOrder = iPos.ReimpresionTicket.DSReimpresionTicketTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(406, 191);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 117;
            this.label15.Text = "% IVA";
            // 
            // CortesDelDiaConAjuste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(793, 469);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnAplicarPorcentaje);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.TASAIVATextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.totalAjustadoTextBox);
            this.Controls.Add(this.impuestoTotalesAjustadoTextBox);
            this.Controls.Add(this.subtotalesAjustadoTextBox);
            this.Controls.Add(this.totalSinIvaAjustadoTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.totalConIvaAjustadoTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.impuestoConIvaAjustadoTextBox);
            this.Controls.Add(this.subTotalSinIvaAjustadoTextBox);
            this.Controls.Add(this.subTotalConIvaAjustadoTextBox);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(this.impuestoTotalesTextBox);
            this.Controls.Add(this.subtotalesTextBox);
            this.Controls.Add(this.totalSinIvaTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.totalConIvaTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.impuestoConIvaTextBox);
            this.Controls.Add(this.subTotalSinIvaTextBox);
            this.Controls.Add(this.subTotalConIvaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PORC_A_IVATextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTFecha);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CortesDelDiaConAjuste";
            this.Text = "Cortes del dia por cajero";
            this.Load += new System.EventHandler(this.CortesDelDia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corteTicketFechaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corteTrasladosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReimpresionTicket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corteTicketSumarizadoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private ReimpresionTicket.DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource corteTicketFechaBindingSource;
        private ReimpresionTicket.DataSet1TableAdapters.CorteTicketFechaTableAdapter corteTicketFechaTableAdapter;
        private ReimpresionTicket.DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private PuntoDeVenta.DSPuntoVenta dSPuntoVenta;
        private System.Windows.Forms.BindingSource corteTrasladosBindingSource;
        private PuntoDeVenta.DSPuntoVentaTableAdapters.CorteTrasladosTableAdapter corteTrasladosTableAdapter;
        private PuntoDeVenta.DSPuntoVentaTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.NumericTextBox PORC_A_IVATextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericTextBox subTotalConIvaTextBox;
        private System.Windows.Forms.NumericTextBox subTotalSinIvaTextBox;
        private System.Windows.Forms.NumericTextBox impuestoConIvaTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericTextBox totalConIvaTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericTextBox totalSinIvaTextBox;
        private System.Windows.Forms.NumericTextBox subtotalesTextBox;
        private System.Windows.Forms.NumericTextBox impuestoTotalesTextBox;
        private System.Windows.Forms.NumericTextBox totalTextBox;
        private System.Windows.Forms.NumericTextBox totalAjustadoTextBox;
        private System.Windows.Forms.NumericTextBox impuestoTotalesAjustadoTextBox;
        private System.Windows.Forms.NumericTextBox subtotalesAjustadoTextBox;
        private System.Windows.Forms.NumericTextBox totalSinIvaAjustadoTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericTextBox totalConIvaAjustadoTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericTextBox impuestoConIvaAjustadoTextBox;
        private System.Windows.Forms.NumericTextBox subTotalSinIvaAjustadoTextBox;
        private System.Windows.Forms.NumericTextBox subTotalConIvaAjustadoTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericTextBox TASAIVATextBox;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnAplicarPorcentaje;
        private ReimpresionTicket.DSReimpresionTicket dSReimpresionTicket;
        private System.Windows.Forms.BindingSource corteTicketSumarizadoBindingSource;
        private ReimpresionTicket.DSReimpresionTicketTableAdapters.CorteTicketSumarizadoTableAdapter corteTicketSumarizadoTableAdapter;
        private ReimpresionTicket.DSReimpresionTicketTableAdapters.TableAdapterManager tableAdapterManager2;
        private System.Windows.Forms.Label label15;
    }
}