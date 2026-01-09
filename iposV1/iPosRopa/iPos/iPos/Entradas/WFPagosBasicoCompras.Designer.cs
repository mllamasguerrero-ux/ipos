namespace iPos
{
    partial class WFPagosBasicoCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPagosBasicoCompras));
            this.label1 = new System.Windows.Forms.Label();
            this.TBPagosTotalVenta = new System.Windows.Forms.TextBox();
            this.BTPaymentSave = new System.Windows.Forms.Button();
            this.PA_ABONOLabel = new System.Windows.Forms.Label();
            this.dSPuntoVenta = new iPos.PuntoDeVenta.DSPuntoVenta();
            this.dETALLE_DE_PAGOTableAdapter = new iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.DETALLE_DE_PAGOTableAdapter();
            this.dETALLE_DE_PAGOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PA_ABONOTextBox = new System.Windows.Forms.NumericTextBox();
            this.LBFaltante = new System.Windows.Forms.Label();
            this.NOTAPAGOTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBancarioTransferencia = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.TBReferenciaTransferencia = new System.Windows.Forms.TextBox();
            this.ComboBancoTransferencia = new System.Windows.Forms.ComboBoxFB();
            this.label10 = new System.Windows.Forms.Label();
            this.TBMontoTransferencia = new System.Windows.Forms.NumericTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlBancarioCheque = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.TBReferenciaCheque = new System.Windows.Forms.TextBox();
            this.ComboBancoCheque = new System.Windows.Forms.ComboBoxFB();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlBancarioTarjeta = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.TBReferenciaTarjeta = new System.Windows.Forms.TextBox();
            this.ComboBancoTarjeta = new System.Windows.Forms.ComboBoxFB();
            this.label14 = new System.Windows.Forms.Label();
            this.TBMontoCheque = new System.Windows.Forms.NumericTextBox();
            this.LBCheque = new System.Windows.Forms.Label();
            this.TBMontoTarjeta = new System.Windows.Forms.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBTIPOTARJETA = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLE_DE_PAGOBindingSource)).BeginInit();
            this.pnlBancarioTransferencia.SuspendLayout();
            this.pnlBancarioCheque.SuspendLayout();
            this.pnlBancarioTarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(248, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 28;
            this.label1.Text = "Total:";
            // 
            // TBPagosTotalVenta
            // 
            this.TBPagosTotalVenta.BackColor = System.Drawing.Color.White;
            this.TBPagosTotalVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPagosTotalVenta.ForeColor = System.Drawing.Color.Black;
            this.TBPagosTotalVenta.Location = new System.Drawing.Point(310, 10);
            this.TBPagosTotalVenta.Name = "TBPagosTotalVenta";
            this.TBPagosTotalVenta.ReadOnly = true;
            this.TBPagosTotalVenta.Size = new System.Drawing.Size(275, 29);
            this.TBPagosTotalVenta.TabIndex = 7;
            this.TBPagosTotalVenta.TabStop = false;
            this.TBPagosTotalVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BTPaymentSave
            // 
            this.BTPaymentSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTPaymentSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTPaymentSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTPaymentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTPaymentSave.ForeColor = System.Drawing.Color.White;
            this.BTPaymentSave.Location = new System.Drawing.Point(310, 281);
            this.BTPaymentSave.Name = "BTPaymentSave";
            this.BTPaymentSave.Size = new System.Drawing.Size(187, 35);
            this.BTPaymentSave.TabIndex = 3;
            this.BTPaymentSave.Text = "Guardar pago (F10)";
            this.BTPaymentSave.UseVisualStyleBackColor = false;
            this.BTPaymentSave.Click += new System.EventHandler(this.BTPaymentSave_Click);
            // 
            // PA_ABONOLabel
            // 
            this.PA_ABONOLabel.AutoSize = true;
            this.PA_ABONOLabel.BackColor = System.Drawing.Color.Transparent;
            this.PA_ABONOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PA_ABONOLabel.ForeColor = System.Drawing.Color.White;
            this.PA_ABONOLabel.Location = new System.Drawing.Point(223, 48);
            this.PA_ABONOLabel.Name = "PA_ABONOLabel";
            this.PA_ABONOLabel.Size = new System.Drawing.Size(81, 24);
            this.PA_ABONOLabel.TabIndex = 19;
            this.PA_ABONOLabel.Text = "Efectivo:";
            // 
            // dSPuntoVenta
            // 
            this.dSPuntoVenta.DataSetName = "DSPuntoVenta";
            this.dSPuntoVenta.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dSPuntoVenta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dETALLE_DE_PAGOTableAdapter
            // 
            this.dETALLE_DE_PAGOTableAdapter.ClearBeforeFill = true;
            // 
            // dETALLE_DE_PAGOBindingSource
            // 
            this.dETALLE_DE_PAGOBindingSource.DataMember = "DETALLE_DE_PAGO";
            this.dETALLE_DE_PAGOBindingSource.DataSource = this.dSPuntoVenta;
            // 
            // PA_ABONOTextBox
            // 
            this.PA_ABONOTextBox.AllowNegative = true;
            this.PA_ABONOTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PA_ABONOTextBox.Format_Expression = null;
            this.PA_ABONOTextBox.Location = new System.Drawing.Point(310, 45);
            this.PA_ABONOTextBox.Name = "PA_ABONOTextBox";
            this.PA_ABONOTextBox.NumericPrecision = 17;
            this.PA_ABONOTextBox.NumericScaleOnFocus = 2;
            this.PA_ABONOTextBox.NumericScaleOnLostFocus = 2;
            this.PA_ABONOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PA_ABONOTextBox.Size = new System.Drawing.Size(275, 29);
            this.PA_ABONOTextBox.TabIndex = 2;
            this.PA_ABONOTextBox.Tag = 34;
            this.PA_ABONOTextBox.Text = "0.00";
            this.PA_ABONOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PA_ABONOTextBox.ValidationExpression = null;
            this.PA_ABONOTextBox.ZeroIsValid = true;
            this.PA_ABONOTextBox.Validated += new System.EventHandler(this.PA_ABONOTextBox_Validated);
            // 
            // LBFaltante
            // 
            this.LBFaltante.AutoSize = true;
            this.LBFaltante.BackColor = System.Drawing.Color.Transparent;
            this.LBFaltante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBFaltante.Location = new System.Drawing.Point(12, 320);
            this.LBFaltante.Name = "LBFaltante";
            this.LBFaltante.Size = new System.Drawing.Size(16, 16);
            this.LBFaltante.TabIndex = 33;
            this.LBFaltante.Text = "_";
            // 
            // NOTAPAGOTextBox
            // 
            this.NOTAPAGOTextBox.Location = new System.Drawing.Point(185, 193);
            this.NOTAPAGOTextBox.Multiline = true;
            this.NOTAPAGOTextBox.Name = "NOTAPAGOTextBox";
            this.NOTAPAGOTextBox.Size = new System.Drawing.Size(328, 59);
            this.NOTAPAGOTextBox.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(36, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 24);
            this.label2.TabIndex = 35;
            this.label2.Text = "Observaciones:";
            // 
            // pnlBancarioTransferencia
            // 
            this.pnlBancarioTransferencia.BackColor = System.Drawing.Color.Transparent;
            this.pnlBancarioTransferencia.Controls.Add(this.label7);
            this.pnlBancarioTransferencia.Controls.Add(this.TBReferenciaTransferencia);
            this.pnlBancarioTransferencia.Controls.Add(this.ComboBancoTransferencia);
            this.pnlBancarioTransferencia.Controls.Add(this.label10);
            this.pnlBancarioTransferencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlBancarioTransferencia.Location = new System.Drawing.Point(426, 156);
            this.pnlBancarioTransferencia.Name = "pnlBancarioTransferencia";
            this.pnlBancarioTransferencia.Size = new System.Drawing.Size(382, 28);
            this.pnlBancarioTransferencia.TabIndex = 94;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(10, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 55;
            this.label7.Text = "Banco:";
            // 
            // TBReferenciaTransferencia
            // 
            this.TBReferenciaTransferencia.Location = new System.Drawing.Point(248, 3);
            this.TBReferenciaTransferencia.Name = "TBReferenciaTransferencia";
            this.TBReferenciaTransferencia.Size = new System.Drawing.Size(130, 20);
            this.TBReferenciaTransferencia.TabIndex = 63;
            // 
            // ComboBancoTransferencia
            // 
            this.ComboBancoTransferencia.Condicion = null;
            this.ComboBancoTransferencia.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ComboBancoTransferencia.DisplayMember = "nombre";
            this.ComboBancoTransferencia.FormattingEnabled = true;
            this.ComboBancoTransferencia.IndiceCampoSelector = 0;
            this.ComboBancoTransferencia.LabelDescription = null;
            this.ComboBancoTransferencia.Location = new System.Drawing.Point(55, 3);
            this.ComboBancoTransferencia.Name = "ComboBancoTransferencia";
            this.ComboBancoTransferencia.NombreCampoSelector = "id";
            this.ComboBancoTransferencia.Query = "select id,nombre from bancos";
            this.ComboBancoTransferencia.QueryDeSeleccion = "select id,nombre from bancos where   id = @id";
            this.ComboBancoTransferencia.SelectedDataDisplaying = null;
            this.ComboBancoTransferencia.SelectedDataValue = null;
            this.ComboBancoTransferencia.Size = new System.Drawing.Size(103, 21);
            this.ComboBancoTransferencia.TabIndex = 62;
            this.ComboBancoTransferencia.ValueMember = "id";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(181, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 56;
            this.label10.Text = "Referencia:";
            // 
            // TBMontoTransferencia
            // 
            this.TBMontoTransferencia.AllowNegative = true;
            this.TBMontoTransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMontoTransferencia.Format_Expression = null;
            this.TBMontoTransferencia.Location = new System.Drawing.Point(184, 155);
            this.TBMontoTransferencia.Name = "TBMontoTransferencia";
            this.TBMontoTransferencia.NumericPrecision = 17;
            this.TBMontoTransferencia.NumericScaleOnFocus = 2;
            this.TBMontoTransferencia.NumericScaleOnLostFocus = 2;
            this.TBMontoTransferencia.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBMontoTransferencia.Size = new System.Drawing.Size(236, 29);
            this.TBMontoTransferencia.TabIndex = 88;
            this.TBMontoTransferencia.Tag = 34;
            this.TBMontoTransferencia.Text = "0.00";
            this.TBMontoTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMontoTransferencia.ValidationExpression = null;
            this.TBMontoTransferencia.ZeroIsValid = true;
            this.TBMontoTransferencia.Validated += new System.EventHandler(this.TBMontoTransferencia_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(48, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 24);
            this.label12.TabIndex = 93;
            this.label12.Text = "Transferencia:";
            // 
            // pnlBancarioCheque
            // 
            this.pnlBancarioCheque.BackColor = System.Drawing.Color.Transparent;
            this.pnlBancarioCheque.Controls.Add(this.label3);
            this.pnlBancarioCheque.Controls.Add(this.TBReferenciaCheque);
            this.pnlBancarioCheque.Controls.Add(this.ComboBancoCheque);
            this.pnlBancarioCheque.Controls.Add(this.label6);
            this.pnlBancarioCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlBancarioCheque.Location = new System.Drawing.Point(427, 118);
            this.pnlBancarioCheque.Name = "pnlBancarioCheque";
            this.pnlBancarioCheque.Size = new System.Drawing.Size(382, 28);
            this.pnlBancarioCheque.TabIndex = 92;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Banco:";
            // 
            // TBReferenciaCheque
            // 
            this.TBReferenciaCheque.Location = new System.Drawing.Point(248, 3);
            this.TBReferenciaCheque.Name = "TBReferenciaCheque";
            this.TBReferenciaCheque.Size = new System.Drawing.Size(130, 20);
            this.TBReferenciaCheque.TabIndex = 63;
            // 
            // ComboBancoCheque
            // 
            this.ComboBancoCheque.Condicion = null;
            this.ComboBancoCheque.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ComboBancoCheque.DisplayMember = "nombre";
            this.ComboBancoCheque.FormattingEnabled = true;
            this.ComboBancoCheque.IndiceCampoSelector = 0;
            this.ComboBancoCheque.LabelDescription = null;
            this.ComboBancoCheque.Location = new System.Drawing.Point(55, 3);
            this.ComboBancoCheque.Name = "ComboBancoCheque";
            this.ComboBancoCheque.NombreCampoSelector = "id";
            this.ComboBancoCheque.Query = "select id,nombre from bancos";
            this.ComboBancoCheque.QueryDeSeleccion = "select id,nombre from bancos where   id = @id";
            this.ComboBancoCheque.SelectedDataDisplaying = null;
            this.ComboBancoCheque.SelectedDataValue = null;
            this.ComboBancoCheque.Size = new System.Drawing.Size(103, 21);
            this.ComboBancoCheque.TabIndex = 62;
            this.ComboBancoCheque.ValueMember = "id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(180, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Referencia:";
            // 
            // pnlBancarioTarjeta
            // 
            this.pnlBancarioTarjeta.BackColor = System.Drawing.Color.Transparent;
            this.pnlBancarioTarjeta.Controls.Add(this.label11);
            this.pnlBancarioTarjeta.Controls.Add(this.TBReferenciaTarjeta);
            this.pnlBancarioTarjeta.Controls.Add(this.ComboBancoTarjeta);
            this.pnlBancarioTarjeta.Controls.Add(this.label14);
            this.pnlBancarioTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlBancarioTarjeta.Location = new System.Drawing.Point(427, 80);
            this.pnlBancarioTarjeta.Name = "pnlBancarioTarjeta";
            this.pnlBancarioTarjeta.Size = new System.Drawing.Size(382, 28);
            this.pnlBancarioTarjeta.TabIndex = 91;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(9, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 55;
            this.label11.Text = "Banco:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // TBReferenciaTarjeta
            // 
            this.TBReferenciaTarjeta.Location = new System.Drawing.Point(248, 3);
            this.TBReferenciaTarjeta.Name = "TBReferenciaTarjeta";
            this.TBReferenciaTarjeta.Size = new System.Drawing.Size(130, 20);
            this.TBReferenciaTarjeta.TabIndex = 63;
            // 
            // ComboBancoTarjeta
            // 
            this.ComboBancoTarjeta.Condicion = null;
            this.ComboBancoTarjeta.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ComboBancoTarjeta.DisplayMember = "nombre";
            this.ComboBancoTarjeta.FormattingEnabled = true;
            this.ComboBancoTarjeta.IndiceCampoSelector = 0;
            this.ComboBancoTarjeta.LabelDescription = null;
            this.ComboBancoTarjeta.Location = new System.Drawing.Point(55, 3);
            this.ComboBancoTarjeta.Name = "ComboBancoTarjeta";
            this.ComboBancoTarjeta.NombreCampoSelector = "id";
            this.ComboBancoTarjeta.Query = "select id,nombre from bancos";
            this.ComboBancoTarjeta.QueryDeSeleccion = "select id,nombre from bancos where   id = @id";
            this.ComboBancoTarjeta.SelectedDataDisplaying = null;
            this.ComboBancoTarjeta.SelectedDataValue = null;
            this.ComboBancoTarjeta.Size = new System.Drawing.Size(103, 21);
            this.ComboBancoTarjeta.TabIndex = 62;
            this.ComboBancoTarjeta.ValueMember = "id";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(180, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 56;
            this.label14.Text = "Referencia:";
            // 
            // TBMontoCheque
            // 
            this.TBMontoCheque.AllowNegative = true;
            this.TBMontoCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMontoCheque.Format_Expression = null;
            this.TBMontoCheque.Location = new System.Drawing.Point(185, 117);
            this.TBMontoCheque.Name = "TBMontoCheque";
            this.TBMontoCheque.NumericPrecision = 17;
            this.TBMontoCheque.NumericScaleOnFocus = 2;
            this.TBMontoCheque.NumericScaleOnLostFocus = 2;
            this.TBMontoCheque.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBMontoCheque.Size = new System.Drawing.Size(236, 29);
            this.TBMontoCheque.TabIndex = 87;
            this.TBMontoCheque.Tag = 34;
            this.TBMontoCheque.Text = "0.00";
            this.TBMontoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMontoCheque.ValidationExpression = null;
            this.TBMontoCheque.ZeroIsValid = true;
            this.TBMontoCheque.Validated += new System.EventHandler(this.TBMontoCheque_Validated);
            // 
            // LBCheque
            // 
            this.LBCheque.AutoSize = true;
            this.LBCheque.BackColor = System.Drawing.Color.Transparent;
            this.LBCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCheque.ForeColor = System.Drawing.Color.White;
            this.LBCheque.Location = new System.Drawing.Point(96, 118);
            this.LBCheque.Name = "LBCheque";
            this.LBCheque.Size = new System.Drawing.Size(83, 24);
            this.LBCheque.TabIndex = 90;
            this.LBCheque.Text = "Cheque:";
            // 
            // TBMontoTarjeta
            // 
            this.TBMontoTarjeta.AllowNegative = true;
            this.TBMontoTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMontoTarjeta.Format_Expression = null;
            this.TBMontoTarjeta.Location = new System.Drawing.Point(185, 80);
            this.TBMontoTarjeta.Name = "TBMontoTarjeta";
            this.TBMontoTarjeta.NumericPrecision = 17;
            this.TBMontoTarjeta.NumericScaleOnFocus = 2;
            this.TBMontoTarjeta.NumericScaleOnLostFocus = 2;
            this.TBMontoTarjeta.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBMontoTarjeta.Size = new System.Drawing.Size(236, 29);
            this.TBMontoTarjeta.TabIndex = 86;
            this.TBMontoTarjeta.Tag = 34;
            this.TBMontoTarjeta.Text = "0.00";
            this.TBMontoTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMontoTarjeta.ValidationExpression = null;
            this.TBMontoTarjeta.ZeroIsValid = true;
            this.TBMontoTarjeta.Validated += new System.EventHandler(this.TBMontoTarjeta_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(78, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 89;
            this.label4.Text = "TARJETA:";
            // 
            // CBTIPOTARJETA
            // 
            this.CBTIPOTARJETA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBTIPOTARJETA.FormattingEnabled = true;
            this.CBTIPOTARJETA.Items.AddRange(new object[] {
            "TARJETA DE CREDITO",
            "TARJETA DE DEBITO",
            "TARJETA DE SERVICIO"});
            this.CBTIPOTARJETA.Location = new System.Drawing.Point(6, 82);
            this.CBTIPOTARJETA.Name = "CBTIPOTARJETA";
            this.CBTIPOTARJETA.Size = new System.Drawing.Size(163, 26);
            this.CBTIPOTARJETA.TabIndex = 95;
            // 
            // WFPagosBasicoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(808, 367);
            this.Controls.Add(this.CBTIPOTARJETA);
            this.Controls.Add(this.pnlBancarioTransferencia);
            this.Controls.Add(this.TBMontoTransferencia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pnlBancarioCheque);
            this.Controls.Add(this.pnlBancarioTarjeta);
            this.Controls.Add(this.TBMontoCheque);
            this.Controls.Add(this.LBCheque);
            this.Controls.Add(this.TBMontoTarjeta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NOTAPAGOTextBox);
            this.Controls.Add(this.LBFaltante);
            this.Controls.Add(this.PA_ABONOTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBPagosTotalVenta);
            this.Controls.Add(this.BTPaymentSave);
            this.Controls.Add(this.PA_ABONOLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1194, 738);
            this.Name = "WFPagosBasicoCompras";
            this.Text = "Pago";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.WFPagosBasicoCompras_Load);
            this.Shown += new System.EventHandler(this.WFPagosBasicoCompras_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WFPagosBasicoCompras_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLE_DE_PAGOBindingSource)).EndInit();
            this.pnlBancarioTransferencia.ResumeLayout(false);
            this.pnlBancarioTransferencia.PerformLayout();
            this.pnlBancarioCheque.ResumeLayout(false);
            this.pnlBancarioCheque.PerformLayout();
            this.pnlBancarioTarjeta.ResumeLayout(false);
            this.pnlBancarioTarjeta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBPagosTotalVenta;
        private System.Windows.Forms.Button BTPaymentSave;
        private System.Windows.Forms.Label PA_ABONOLabel;
        private iPos.PuntoDeVenta.DSPuntoVenta dSPuntoVenta;
        private iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.DETALLE_DE_PAGOTableAdapter dETALLE_DE_PAGOTableAdapter;
        private System.Windows.Forms.BindingSource dETALLE_DE_PAGOBindingSource;
        //private Skinner.FormSkin formSkin1;
        private System.Windows.Forms.NumericTextBox PA_ABONOTextBox;
        private System.Windows.Forms.Label LBFaltante;
        private System.Windows.Forms.TextBox NOTAPAGOTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlBancarioTransferencia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBReferenciaTransferencia;
        private System.Windows.Forms.ComboBoxFB ComboBancoTransferencia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericTextBox TBMontoTransferencia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlBancarioCheque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBReferenciaCheque;
        private System.Windows.Forms.ComboBoxFB ComboBancoCheque;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlBancarioTarjeta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TBReferenciaTarjeta;
        private System.Windows.Forms.ComboBoxFB ComboBancoTarjeta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericTextBox TBMontoCheque;
        private System.Windows.Forms.Label LBCheque;
        private System.Windows.Forms.NumericTextBox TBMontoTarjeta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBTIPOTARJETA;
    }
}