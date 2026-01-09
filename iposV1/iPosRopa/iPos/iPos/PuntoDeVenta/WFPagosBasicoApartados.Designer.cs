namespace iPos
{
    partial class WFPagosBasicoApartados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPagosBasicoApartados));
            this.label1 = new System.Windows.Forms.Label();
            this.TBPagosTotalVenta = new System.Windows.Forms.TextBox();
            this.BTPaymentSave = new System.Windows.Forms.Button();
            this.PA_ABONOLabel = new System.Windows.Forms.Label();
            this.dSPuntoVenta = new iPos.PuntoDeVenta.DSPuntoVenta();
            this.dETALLE_DE_PAGOTableAdapter = new iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.DETALLE_DE_PAGOTableAdapter();
            this.dETALLE_DE_PAGOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.TBCambioTextBox = new System.Windows.Forms.TextBox();
            this.PA_ABONOTextBox = new System.Windows.Forms.NumericTextBox();
            this.LBFaltante = new System.Windows.Forms.Label();
            this.TBMontoTarjeta = new System.Windows.Forms.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBMontoCheque = new System.Windows.Forms.NumericTextBox();
            this.LBCheque = new System.Windows.Forms.Label();
            this.TBMontoVale = new System.Windows.Forms.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NOMBRESLabel = new System.Windows.Forms.Label();
            this.NOMBRESTextBox = new System.Windows.Forms.TextBox();
            this.DOMICILIOLabel = new System.Windows.Forms.Label();
            this.DOMICILIOTextBox = new System.Windows.Forms.TextBox();
            this.CIUDADLabel = new System.Windows.Forms.Label();
            this.CIUDADTextBox = new System.Windows.Forms.TextBox();
            this.EMAIL1TextBox = new System.Windows.Forms.TextBox();
            this.EMAIL1Label = new System.Windows.Forms.Label();
            this.CELULARTextBox = new System.Windows.Forms.TextBox();
            this.CELULARLabel = new System.Windows.Forms.Label();
            this.TELEFONO1Label = new System.Windows.Forms.Label();
            this.TELEFONO1TextBox = new System.Windows.Forms.TextBox();
            this.pnlEdicionCliente = new System.Windows.Forms.Panel();
            this.BTSeleccionar = new System.Windows.Forms.Button();
            this.BTNNuevo = new System.Windows.Forms.Button();
            this.CBTIPOTARJETA = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLE_DE_PAGOBindingSource)).BeginInit();
            this.pnlEdicionCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(457, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 28;
            this.label1.Text = "Total:";
            // 
            // TBPagosTotalVenta
            // 
            this.TBPagosTotalVenta.BackColor = System.Drawing.SystemColors.Window;
            this.TBPagosTotalVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPagosTotalVenta.ForeColor = System.Drawing.Color.Black;
            this.TBPagosTotalVenta.Location = new System.Drawing.Point(519, 5);
            this.TBPagosTotalVenta.Name = "TBPagosTotalVenta";
            this.TBPagosTotalVenta.ReadOnly = true;
            this.TBPagosTotalVenta.Size = new System.Drawing.Size(236, 29);
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
            this.BTPaymentSave.Location = new System.Drawing.Point(544, 244);
            this.BTPaymentSave.Name = "BTPaymentSave";
            this.BTPaymentSave.Size = new System.Drawing.Size(186, 33);
            this.BTPaymentSave.TabIndex = 6;
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
            this.PA_ABONOLabel.Location = new System.Drawing.Point(433, 43);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(434, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 24);
            this.label4.TabIndex = 32;
            this.label4.Text = "Cambio:";
            // 
            // TBCambioTextBox
            // 
            this.TBCambioTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.TBCambioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCambioTextBox.ForeColor = System.Drawing.Color.Black;
            this.TBCambioTextBox.Location = new System.Drawing.Point(519, 190);
            this.TBCambioTextBox.Name = "TBCambioTextBox";
            this.TBCambioTextBox.ReadOnly = true;
            this.TBCambioTextBox.Size = new System.Drawing.Size(236, 29);
            this.TBCambioTextBox.TabIndex = 8;
            this.TBCambioTextBox.TabStop = false;
            this.TBCambioTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PA_ABONOTextBox
            // 
            this.PA_ABONOTextBox.AllowNegative = true;
            this.PA_ABONOTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PA_ABONOTextBox.Format_Expression = null;
            this.PA_ABONOTextBox.Location = new System.Drawing.Point(519, 40);
            this.PA_ABONOTextBox.Name = "PA_ABONOTextBox";
            this.PA_ABONOTextBox.NumericPrecision = 17;
            this.PA_ABONOTextBox.NumericScaleOnFocus = 2;
            this.PA_ABONOTextBox.NumericScaleOnLostFocus = 2;
            this.PA_ABONOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PA_ABONOTextBox.Size = new System.Drawing.Size(236, 29);
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
            this.LBFaltante.ForeColor = System.Drawing.Color.White;
            this.LBFaltante.Location = new System.Drawing.Point(369, 277);
            this.LBFaltante.Name = "LBFaltante";
            this.LBFaltante.Size = new System.Drawing.Size(16, 16);
            this.LBFaltante.TabIndex = 0;
            this.LBFaltante.Text = "_";
            // 
            // TBMontoTarjeta
            // 
            this.TBMontoTarjeta.AllowNegative = true;
            this.TBMontoTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMontoTarjeta.Format_Expression = null;
            this.TBMontoTarjeta.Location = new System.Drawing.Point(519, 78);
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
            this.TBMontoTarjeta.TabIndex = 3;
            this.TBMontoTarjeta.Tag = 34;
            this.TBMontoTarjeta.Text = "0.00";
            this.TBMontoTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMontoTarjeta.ValidationExpression = null;
            this.TBMontoTarjeta.ZeroIsValid = true;
            this.TBMontoTarjeta.Validated += new System.EventHandler(this.TBMontoTarjeta_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(403, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 35;
            this.label2.Text = "TARJETA:";
            // 
            // TBMontoCheque
            // 
            this.TBMontoCheque.AllowNegative = true;
            this.TBMontoCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMontoCheque.Format_Expression = null;
            this.TBMontoCheque.Location = new System.Drawing.Point(519, 115);
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
            this.TBMontoCheque.TabIndex = 4;
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
            this.LBCheque.Location = new System.Drawing.Point(430, 118);
            this.LBCheque.Name = "LBCheque";
            this.LBCheque.Size = new System.Drawing.Size(83, 24);
            this.LBCheque.TabIndex = 39;
            this.LBCheque.Text = "Cheque:";
            // 
            // TBMontoVale
            // 
            this.TBMontoVale.AllowNegative = true;
            this.TBMontoVale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMontoVale.Format_Expression = null;
            this.TBMontoVale.Location = new System.Drawing.Point(519, 153);
            this.TBMontoVale.Name = "TBMontoVale";
            this.TBMontoVale.NumericPrecision = 17;
            this.TBMontoVale.NumericScaleOnFocus = 2;
            this.TBMontoVale.NumericScaleOnLostFocus = 2;
            this.TBMontoVale.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBMontoVale.Size = new System.Drawing.Size(236, 29);
            this.TBMontoVale.TabIndex = 5;
            this.TBMontoVale.Tag = 34;
            this.TBMontoVale.Text = "0.00";
            this.TBMontoVale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMontoVale.ValidationExpression = null;
            this.TBMontoVale.ZeroIsValid = true;
            this.TBMontoVale.Validated += new System.EventHandler(this.TBMontoVale_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(461, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 24);
            this.label5.TabIndex = 41;
            this.label5.Text = "Vale:";
            // 
            // NOMBRESLabel
            // 
            this.NOMBRESLabel.AutoSize = true;
            this.NOMBRESLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NOMBRESLabel.ForeColor = System.Drawing.Color.White;
            this.NOMBRESLabel.Location = new System.Drawing.Point(3, 4);
            this.NOMBRESLabel.Name = "NOMBRESLabel";
            this.NOMBRESLabel.Size = new System.Drawing.Size(56, 13);
            this.NOMBRESLabel.TabIndex = 42;
            this.NOMBRESLabel.Text = "Nombres";
            // 
            // NOMBRESTextBox
            // 
            this.NOMBRESTextBox.Location = new System.Drawing.Point(6, 18);
            this.NOMBRESTextBox.Name = "NOMBRESTextBox";
            this.NOMBRESTextBox.Size = new System.Drawing.Size(254, 20);
            this.NOMBRESTextBox.TabIndex = 43;
            // 
            // DOMICILIOLabel
            // 
            this.DOMICILIOLabel.AutoSize = true;
            this.DOMICILIOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DOMICILIOLabel.ForeColor = System.Drawing.Color.White;
            this.DOMICILIOLabel.Location = new System.Drawing.Point(3, 48);
            this.DOMICILIOLabel.Name = "DOMICILIOLabel";
            this.DOMICILIOLabel.Size = new System.Drawing.Size(58, 13);
            this.DOMICILIOLabel.TabIndex = 47;
            this.DOMICILIOLabel.Text = "Domicilio";
            // 
            // DOMICILIOTextBox
            // 
            this.DOMICILIOTextBox.Location = new System.Drawing.Point(6, 64);
            this.DOMICILIOTextBox.Name = "DOMICILIOTextBox";
            this.DOMICILIOTextBox.Size = new System.Drawing.Size(320, 20);
            this.DOMICILIOTextBox.TabIndex = 49;
            // 
            // CIUDADLabel
            // 
            this.CIUDADLabel.AutoSize = true;
            this.CIUDADLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CIUDADLabel.ForeColor = System.Drawing.Color.White;
            this.CIUDADLabel.Location = new System.Drawing.Point(3, 87);
            this.CIUDADLabel.Name = "CIUDADLabel";
            this.CIUDADLabel.Size = new System.Drawing.Size(46, 13);
            this.CIUDADLabel.TabIndex = 48;
            this.CIUDADLabel.Text = "Ciudad";
            // 
            // CIUDADTextBox
            // 
            this.CIUDADTextBox.Location = new System.Drawing.Point(6, 103);
            this.CIUDADTextBox.Name = "CIUDADTextBox";
            this.CIUDADTextBox.Size = new System.Drawing.Size(254, 20);
            this.CIUDADTextBox.TabIndex = 50;
            // 
            // EMAIL1TextBox
            // 
            this.EMAIL1TextBox.Location = new System.Drawing.Point(6, 183);
            this.EMAIL1TextBox.Name = "EMAIL1TextBox";
            this.EMAIL1TextBox.Size = new System.Drawing.Size(254, 20);
            this.EMAIL1TextBox.TabIndex = 53;
            // 
            // EMAIL1Label
            // 
            this.EMAIL1Label.AutoSize = true;
            this.EMAIL1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EMAIL1Label.ForeColor = System.Drawing.Color.White;
            this.EMAIL1Label.Location = new System.Drawing.Point(3, 167);
            this.EMAIL1Label.Name = "EMAIL1Label";
            this.EMAIL1Label.Size = new System.Drawing.Size(52, 13);
            this.EMAIL1Label.TabIndex = 46;
            this.EMAIL1Label.Text = "E-mail 1";
            // 
            // CELULARTextBox
            // 
            this.CELULARTextBox.Location = new System.Drawing.Point(160, 144);
            this.CELULARTextBox.Name = "CELULARTextBox";
            this.CELULARTextBox.Size = new System.Drawing.Size(100, 20);
            this.CELULARTextBox.TabIndex = 52;
            // 
            // CELULARLabel
            // 
            this.CELULARLabel.AutoSize = true;
            this.CELULARLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CELULARLabel.ForeColor = System.Drawing.Color.White;
            this.CELULARLabel.Location = new System.Drawing.Point(157, 128);
            this.CELULARLabel.Name = "CELULARLabel";
            this.CELULARLabel.Size = new System.Drawing.Size(46, 13);
            this.CELULARLabel.TabIndex = 44;
            this.CELULARLabel.Text = "Celular";
            // 
            // TELEFONO1Label
            // 
            this.TELEFONO1Label.AutoSize = true;
            this.TELEFONO1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TELEFONO1Label.ForeColor = System.Drawing.Color.White;
            this.TELEFONO1Label.Location = new System.Drawing.Point(3, 128);
            this.TELEFONO1Label.Name = "TELEFONO1Label";
            this.TELEFONO1Label.Size = new System.Drawing.Size(68, 13);
            this.TELEFONO1Label.TabIndex = 45;
            this.TELEFONO1Label.Text = "Teléfono 1";
            // 
            // TELEFONO1TextBox
            // 
            this.TELEFONO1TextBox.Location = new System.Drawing.Point(6, 144);
            this.TELEFONO1TextBox.Name = "TELEFONO1TextBox";
            this.TELEFONO1TextBox.Size = new System.Drawing.Size(100, 20);
            this.TELEFONO1TextBox.TabIndex = 51;
            // 
            // pnlEdicionCliente
            // 
            this.pnlEdicionCliente.BackColor = System.Drawing.Color.Transparent;
            this.pnlEdicionCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlEdicionCliente.Controls.Add(this.NOMBRESLabel);
            this.pnlEdicionCliente.Controls.Add(this.DOMICILIOLabel);
            this.pnlEdicionCliente.Controls.Add(this.NOMBRESTextBox);
            this.pnlEdicionCliente.Controls.Add(this.DOMICILIOTextBox);
            this.pnlEdicionCliente.Controls.Add(this.TELEFONO1TextBox);
            this.pnlEdicionCliente.Controls.Add(this.CIUDADLabel);
            this.pnlEdicionCliente.Controls.Add(this.TELEFONO1Label);
            this.pnlEdicionCliente.Controls.Add(this.CIUDADTextBox);
            this.pnlEdicionCliente.Controls.Add(this.CELULARLabel);
            this.pnlEdicionCliente.Controls.Add(this.EMAIL1TextBox);
            this.pnlEdicionCliente.Controls.Add(this.CELULARTextBox);
            this.pnlEdicionCliente.Controls.Add(this.EMAIL1Label);
            this.pnlEdicionCliente.Location = new System.Drawing.Point(12, 12);
            this.pnlEdicionCliente.Name = "pnlEdicionCliente";
            this.pnlEdicionCliente.Size = new System.Drawing.Size(333, 235);
            this.pnlEdicionCliente.TabIndex = 54;
            // 
            // BTSeleccionar
            // 
            this.BTSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTSeleccionar.ForeColor = System.Drawing.Color.White;
            this.BTSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTSeleccionar.Location = new System.Drawing.Point(48, 269);
            this.BTSeleccionar.Name = "BTSeleccionar";
            this.BTSeleccionar.Size = new System.Drawing.Size(122, 33);
            this.BTSeleccionar.TabIndex = 55;
            this.BTSeleccionar.Text = "Seleccionar";
            this.BTSeleccionar.UseVisualStyleBackColor = false;
            this.BTSeleccionar.Click += new System.EventHandler(this.BTSeleccionar_Click);
            // 
            // BTNNuevo
            // 
            this.BTNNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTNNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNNuevo.ForeColor = System.Drawing.Color.White;
            this.BTNNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNNuevo.Location = new System.Drawing.Point(186, 269);
            this.BTNNuevo.Name = "BTNNuevo";
            this.BTNNuevo.Size = new System.Drawing.Size(122, 33);
            this.BTNNuevo.TabIndex = 56;
            this.BTNNuevo.Text = "Nuevo";
            this.BTNNuevo.UseVisualStyleBackColor = false;
            this.BTNNuevo.Click += new System.EventHandler(this.BTNNuevo_Click);
            // 
            // CBTIPOTARJETA
            // 
            this.CBTIPOTARJETA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBTIPOTARJETA.FormattingEnabled = true;
            this.CBTIPOTARJETA.Items.AddRange(new object[] {
            "TARJETA DE CREDITO",
            "TARJETA DE DEBITO",
            "TARJETA DE SERVICIO"});
            this.CBTIPOTARJETA.Location = new System.Drawing.Point(351, 78);
            this.CBTIPOTARJETA.Name = "CBTIPOTARJETA";
            this.CBTIPOTARJETA.Size = new System.Drawing.Size(163, 26);
            this.CBTIPOTARJETA.TabIndex = 92;
            // 
            // WFPagosBasicoApartados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(774, 418);
            this.Controls.Add(this.CBTIPOTARJETA);
            this.Controls.Add(this.BTNNuevo);
            this.Controls.Add(this.BTSeleccionar);
            this.Controls.Add(this.pnlEdicionCliente);
            this.Controls.Add(this.TBMontoVale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TBMontoCheque);
            this.Controls.Add(this.LBCheque);
            this.Controls.Add(this.TBMontoTarjeta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LBFaltante);
            this.Controls.Add(this.PA_ABONOTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBCambioTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBPagosTotalVenta);
            this.Controls.Add(this.BTPaymentSave);
            this.Controls.Add(this.PA_ABONOLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "WFPagosBasicoApartados";
            this.Text = "Pago";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.WFPagosBasicoApartados_Load);
            this.Shown += new System.EventHandler(this.WFPagosBasicoApartados_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WFPagosBasicoApartados_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLE_DE_PAGOBindingSource)).EndInit();
            this.pnlEdicionCliente.ResumeLayout(false);
            this.pnlEdicionCliente.PerformLayout();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBCambioTextBox;
        //private Skinner.FormSkin formSkin1;
        private System.Windows.Forms.NumericTextBox PA_ABONOTextBox;
        private System.Windows.Forms.Label LBFaltante;
        private System.Windows.Forms.NumericTextBox TBMontoTarjeta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericTextBox TBMontoCheque;
        private System.Windows.Forms.Label LBCheque;
        private System.Windows.Forms.NumericTextBox TBMontoVale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label NOMBRESLabel;
        private System.Windows.Forms.TextBox NOMBRESTextBox;
        private System.Windows.Forms.Label DOMICILIOLabel;
        private System.Windows.Forms.TextBox DOMICILIOTextBox;
        private System.Windows.Forms.Label CIUDADLabel;
        private System.Windows.Forms.TextBox CIUDADTextBox;
        private System.Windows.Forms.TextBox EMAIL1TextBox;
        private System.Windows.Forms.Label EMAIL1Label;
        private System.Windows.Forms.TextBox CELULARTextBox;
        private System.Windows.Forms.Label CELULARLabel;
        private System.Windows.Forms.Label TELEFONO1Label;
        private System.Windows.Forms.TextBox TELEFONO1TextBox;
        private System.Windows.Forms.Panel pnlEdicionCliente;
        private System.Windows.Forms.Button BTSeleccionar;
        private System.Windows.Forms.Button BTNNuevo;
        private System.Windows.Forms.ComboBox CBTIPOTARJETA;
    }
}