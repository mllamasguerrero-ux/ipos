namespace iPos
{
    partial class WFPagosBasico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPagosBasico));
            this.label1 = new System.Windows.Forms.Label();
            this.TBPagosTotalVenta = new System.Windows.Forms.TextBox();
            this.BTPaymentSave = new System.Windows.Forms.Button();
            this.PA_ABONOLabel = new System.Windows.Forms.Label();
            this.dSPuntoVenta = new iPos.PuntoDeVenta.DSPuntoVenta();
            this.dETALLE_DE_PAGOTableAdapter = new iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.DETALLE_DE_PAGOTableAdapter();
            this.dETALLE_DE_PAGOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.TBCambioTextBox = new System.Windows.Forms.TextBox();
            this.LBFaltante = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LBCheque = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CBFacturaElectronica = new System.Windows.Forms.CheckBox();
            this.pnlBancarioTarjeta = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.TBReferenciaTarjeta = new System.Windows.Forms.TextBox();
            this.ComboBancoTarjeta = new System.Windows.Forms.ComboBoxFB();
            this.label14 = new System.Windows.Forms.Label();
            this.pnlBancarioCheque = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.TBReferenciaCheque = new System.Windows.Forms.TextBox();
            this.ComboBancoCheque = new System.Windows.Forms.ComboBoxFB();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TBNumeroMonedero = new System.Windows.Forms.TextBox();
            this.BtnMonedero = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TBMonederoAplicado = new System.Windows.Forms.TextBox();
            this.pnlBancarioTransferencia = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.TBReferenciaTransferencia = new System.Windows.Forms.TextBox();
            this.ComboBancoTransferencia = new System.Windows.Forms.ComboBoxFB();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.LBMONEDA = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.NOTAPAGOTextBox = new System.Windows.Forms.TextBox();
            this.TBMontoTransferencia = new System.Windows.Forms.NumericTextBox();
            this.TBMontoVale = new System.Windows.Forms.NumericTextBox();
            this.TBMontoCheque = new System.Windows.Forms.NumericTextBox();
            this.TBMontoTarjeta = new System.Windows.Forms.NumericTextBox();
            this.PA_ABONOTextBox = new System.Windows.Forms.NumericTextBox();
            this.CBSurtidoPostpuesto = new System.Windows.Forms.CheckBox();
            this.CBTIPOTARJETA = new System.Windows.Forms.ComboBox();
            this.pnlCreditoAutomatico = new System.Windows.Forms.Panel();
            this.lblCreditoAutomatico = new System.Windows.Forms.NumericTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.BtnCompraRelacionada = new System.Windows.Forms.Button();
            this.pnlCompraRelacionada = new System.Windows.Forms.Panel();
            this.BtnQuitarCompraRelacionada = new System.Windows.Forms.Button();
            this.lblCompraRelacionada = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.USOCFDITextBox = new System.Windows.Forms.ComboBoxFB();
            this.USOCFDILabel = new System.Windows.Forms.Label();
            this.CBRevisionFinal = new System.Windows.Forms.CheckBox();
            this.pnlOtros = new System.Windows.Forms.Panel();
            this.lblOtros = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.BtnAvanzado = new System.Windows.Forms.Button();
            this.CBComprobanteTraslado = new System.Windows.Forms.CheckBox();
            this.CBCartaPorte = new System.Windows.Forms.CheckBox();
            this.btnReinicializaVerifone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLE_DE_PAGOBindingSource)).BeginInit();
            this.pnlBancarioTarjeta.SuspendLayout();
            this.pnlBancarioCheque.SuspendLayout();
            this.pnlBancarioTransferencia.SuspendLayout();
            this.pnlCreditoAutomatico.SuspendLayout();
            this.pnlCompraRelacionada.SuspendLayout();
            this.pnlOtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(120, 20);
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
            this.TBPagosTotalVenta.Location = new System.Drawing.Point(183, 17);
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
            this.BTPaymentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTPaymentSave.ForeColor = System.Drawing.Color.White;
            this.BTPaymentSave.Location = new System.Drawing.Point(277, 560);
            this.BTPaymentSave.Name = "BTPaymentSave";
            this.BTPaymentSave.Size = new System.Drawing.Size(211, 33);
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
            this.PA_ABONOLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PA_ABONOLabel.Location = new System.Drawing.Point(95, 52);
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
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(96, 205);
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
            this.TBCambioTextBox.Location = new System.Drawing.Point(183, 202);
            this.TBCambioTextBox.Name = "TBCambioTextBox";
            this.TBCambioTextBox.ReadOnly = true;
            this.TBCambioTextBox.Size = new System.Drawing.Size(236, 29);
            this.TBCambioTextBox.TabIndex = 8;
            this.TBCambioTextBox.TabStop = false;
            this.TBCambioTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LBFaltante
            // 
            this.LBFaltante.AutoSize = true;
            this.LBFaltante.BackColor = System.Drawing.Color.Transparent;
            this.LBFaltante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBFaltante.Location = new System.Drawing.Point(9, 626);
            this.LBFaltante.Name = "LBFaltante";
            this.LBFaltante.Size = new System.Drawing.Size(16, 16);
            this.LBFaltante.TabIndex = 33;
            this.LBFaltante.Text = "_";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(76, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 35;
            this.label2.Text = "TARJETA:";
            // 
            // LBCheque
            // 
            this.LBCheque.AutoSize = true;
            this.LBCheque.BackColor = System.Drawing.Color.Transparent;
            this.LBCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LBCheque.Location = new System.Drawing.Point(93, 127);
            this.LBCheque.Name = "LBCheque";
            this.LBCheque.Size = new System.Drawing.Size(83, 24);
            this.LBCheque.TabIndex = 39;
            this.LBCheque.Text = "Cheque:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(123, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 24);
            this.label5.TabIndex = 41;
            this.label5.Text = "Vale:";
            // 
            // CBFacturaElectronica
            // 
            this.CBFacturaElectronica.AutoSize = true;
            this.CBFacturaElectronica.BackColor = System.Drawing.Color.Transparent;
            this.CBFacturaElectronica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFacturaElectronica.ForeColor = System.Drawing.Color.White;
            this.CBFacturaElectronica.Location = new System.Drawing.Point(39, 499);
            this.CBFacturaElectronica.Name = "CBFacturaElectronica";
            this.CBFacturaElectronica.Size = new System.Drawing.Size(231, 17);
            this.CBFacturaElectronica.TabIndex = 46;
            this.CBFacturaElectronica.Text = "Generar factura electronica (Ctrl +F)";
            this.CBFacturaElectronica.UseVisualStyleBackColor = false;
            this.CBFacturaElectronica.CheckedChanged += new System.EventHandler(this.CBFacturaElectronica_CheckedChanged);
            // 
            // pnlBancarioTarjeta
            // 
            this.pnlBancarioTarjeta.BackColor = System.Drawing.Color.Transparent;
            this.pnlBancarioTarjeta.Controls.Add(this.label11);
            this.pnlBancarioTarjeta.Controls.Add(this.TBReferenciaTarjeta);
            this.pnlBancarioTarjeta.Controls.Add(this.ComboBancoTarjeta);
            this.pnlBancarioTarjeta.Controls.Add(this.label14);
            this.pnlBancarioTarjeta.Enabled = false;
            this.pnlBancarioTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlBancarioTarjeta.Location = new System.Drawing.Point(425, 87);
            this.pnlBancarioTarjeta.Name = "pnlBancarioTarjeta";
            this.pnlBancarioTarjeta.Size = new System.Drawing.Size(382, 28);
            this.pnlBancarioTarjeta.TabIndex = 76;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(8, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 55;
            this.label11.Text = "Banco:";
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
            this.label14.Location = new System.Drawing.Point(179, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 56;
            this.label14.Text = "Referencia:";
            // 
            // pnlBancarioCheque
            // 
            this.pnlBancarioCheque.BackColor = System.Drawing.Color.Transparent;
            this.pnlBancarioCheque.Controls.Add(this.label3);
            this.pnlBancarioCheque.Controls.Add(this.TBReferenciaCheque);
            this.pnlBancarioCheque.Controls.Add(this.ComboBancoCheque);
            this.pnlBancarioCheque.Controls.Add(this.label6);
            this.pnlBancarioCheque.Enabled = false;
            this.pnlBancarioCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlBancarioCheque.Location = new System.Drawing.Point(425, 125);
            this.pnlBancarioCheque.Name = "pnlBancarioCheque";
            this.pnlBancarioCheque.Size = new System.Drawing.Size(382, 28);
            this.pnlBancarioCheque.TabIndex = 77;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 6);
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
            this.label6.Location = new System.Drawing.Point(179, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Referencia:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(429, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 82;
            this.label9.Text = "Numero Monedero";
            // 
            // TBNumeroMonedero
            // 
            this.TBNumeroMonedero.BackColor = System.Drawing.Color.Gainsboro;
            this.TBNumeroMonedero.Location = new System.Drawing.Point(425, 250);
            this.TBNumeroMonedero.Name = "TBNumeroMonedero";
            this.TBNumeroMonedero.ReadOnly = true;
            this.TBNumeroMonedero.Size = new System.Drawing.Size(171, 20);
            this.TBNumeroMonedero.TabIndex = 81;
            // 
            // BtnMonedero
            // 
            this.BtnMonedero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BtnMonedero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BtnMonedero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMonedero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMonedero.ForeColor = System.Drawing.Color.White;
            this.BtnMonedero.Location = new System.Drawing.Point(608, 244);
            this.BtnMonedero.Name = "BtnMonedero";
            this.BtnMonedero.Size = new System.Drawing.Size(39, 28);
            this.BtnMonedero.TabIndex = 80;
            this.BtnMonedero.Text = "...";
            this.BtnMonedero.UseVisualStyleBackColor = false;
            this.BtnMonedero.Click += new System.EventHandler(this.BtnMonedero_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(73, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 24);
            this.label8.TabIndex = 79;
            this.label8.Text = "Monedero:";
            // 
            // TBMonederoAplicado
            // 
            this.TBMonederoAplicado.BackColor = System.Drawing.Color.Gainsboro;
            this.TBMonederoAplicado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMonederoAplicado.ForeColor = System.Drawing.Color.Black;
            this.TBMonederoAplicado.Location = new System.Drawing.Point(182, 243);
            this.TBMonederoAplicado.Name = "TBMonederoAplicado";
            this.TBMonederoAplicado.ReadOnly = true;
            this.TBMonederoAplicado.Size = new System.Drawing.Size(237, 29);
            this.TBMonederoAplicado.TabIndex = 78;
            this.TBMonederoAplicado.Text = "0.00";
            this.TBMonederoAplicado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlBancarioTransferencia
            // 
            this.pnlBancarioTransferencia.BackColor = System.Drawing.Color.Transparent;
            this.pnlBancarioTransferencia.Controls.Add(this.label7);
            this.pnlBancarioTransferencia.Controls.Add(this.TBReferenciaTransferencia);
            this.pnlBancarioTransferencia.Controls.Add(this.ComboBancoTransferencia);
            this.pnlBancarioTransferencia.Controls.Add(this.label10);
            this.pnlBancarioTransferencia.Enabled = false;
            this.pnlBancarioTransferencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlBancarioTransferencia.Location = new System.Drawing.Point(424, 288);
            this.pnlBancarioTransferencia.Name = "pnlBancarioTransferencia";
            this.pnlBancarioTransferencia.Size = new System.Drawing.Size(382, 28);
            this.pnlBancarioTransferencia.TabIndex = 85;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 6);
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
            this.label10.Location = new System.Drawing.Point(180, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 56;
            this.label10.Text = "Referencia:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label12.Location = new System.Drawing.Point(46, 288);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 24);
            this.label12.TabIndex = 84;
            this.label12.Text = "Transferencia:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(460, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 13);
            this.label23.TabIndex = 87;
            this.label23.Text = "MONEDA:";
            // 
            // LBMONEDA
            // 
            this.LBMONEDA.AutoSize = true;
            this.LBMONEDA.BackColor = System.Drawing.Color.Transparent;
            this.LBMONEDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBMONEDA.ForeColor = System.Drawing.Color.White;
            this.LBMONEDA.Location = new System.Drawing.Point(535, 20);
            this.LBMONEDA.Name = "LBMONEDA";
            this.LBMONEDA.Size = new System.Drawing.Size(104, 13);
            this.LBMONEDA.TabIndex = 86;
            this.LBMONEDA.Text = "Moneda nacional";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(34, 444);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 24);
            this.label13.TabIndex = 89;
            this.label13.Text = "Observaciones:";
            // 
            // NOTAPAGOTextBox
            // 
            this.NOTAPAGOTextBox.Location = new System.Drawing.Point(180, 444);
            this.NOTAPAGOTextBox.Multiline = true;
            this.NOTAPAGOTextBox.Name = "NOTAPAGOTextBox";
            this.NOTAPAGOTextBox.Size = new System.Drawing.Size(616, 38);
            this.NOTAPAGOTextBox.TabIndex = 88;
            // 
            // TBMontoTransferencia
            // 
            this.TBMontoTransferencia.AllowNegative = true;
            this.TBMontoTransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMontoTransferencia.Format_Expression = null;
            this.TBMontoTransferencia.Location = new System.Drawing.Point(182, 287);
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
            this.TBMontoTransferencia.TabIndex = 10;
            this.TBMontoTransferencia.Tag = 34;
            this.TBMontoTransferencia.Text = "0.00";
            this.TBMontoTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMontoTransferencia.ValidationExpression = null;
            this.TBMontoTransferencia.ZeroIsValid = true;
            this.TBMontoTransferencia.Validated += new System.EventHandler(this.TBMontoTransferencia_Validated);
            // 
            // TBMontoVale
            // 
            this.TBMontoVale.AllowNegative = true;
            this.TBMontoVale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMontoVale.Format_Expression = null;
            this.TBMontoVale.Location = new System.Drawing.Point(183, 162);
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
            this.TBMontoVale.TabIndex = 8;
            this.TBMontoVale.Tag = 34;
            this.TBMontoVale.Text = "0.00";
            this.TBMontoVale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMontoVale.ValidationExpression = null;
            this.TBMontoVale.ZeroIsValid = true;
            this.TBMontoVale.Validated += new System.EventHandler(this.TBMontoVale_Validated);
            // 
            // TBMontoCheque
            // 
            this.TBMontoCheque.AllowNegative = true;
            this.TBMontoCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMontoCheque.Format_Expression = null;
            this.TBMontoCheque.Location = new System.Drawing.Point(183, 124);
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
            this.TBMontoCheque.TabIndex = 6;
            this.TBMontoCheque.Tag = 34;
            this.TBMontoCheque.Text = "0.00";
            this.TBMontoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMontoCheque.ValidationExpression = null;
            this.TBMontoCheque.ZeroIsValid = true;
            this.TBMontoCheque.Validated += new System.EventHandler(this.TBMontoCheque_Validated);
            // 
            // TBMontoTarjeta
            // 
            this.TBMontoTarjeta.AllowNegative = true;
            this.TBMontoTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMontoTarjeta.Format_Expression = null;
            this.TBMontoTarjeta.Location = new System.Drawing.Point(183, 87);
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
            this.TBMontoTarjeta.TabIndex = 4;
            this.TBMontoTarjeta.Tag = 34;
            this.TBMontoTarjeta.Text = "0.00";
            this.TBMontoTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMontoTarjeta.ValidationExpression = null;
            this.TBMontoTarjeta.ZeroIsValid = true;
            this.TBMontoTarjeta.Validated += new System.EventHandler(this.TBMontoTarjeta_Validated);
            // 
            // PA_ABONOTextBox
            // 
            this.PA_ABONOTextBox.AllowNegative = true;
            this.PA_ABONOTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PA_ABONOTextBox.Format_Expression = null;
            this.PA_ABONOTextBox.Location = new System.Drawing.Point(183, 49);
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
            // CBSurtidoPostpuesto
            // 
            this.CBSurtidoPostpuesto.AutoSize = true;
            this.CBSurtidoPostpuesto.BackColor = System.Drawing.Color.Transparent;
            this.CBSurtidoPostpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBSurtidoPostpuesto.ForeColor = System.Drawing.Color.White;
            this.CBSurtidoPostpuesto.Location = new System.Drawing.Point(538, 499);
            this.CBSurtidoPostpuesto.Name = "CBSurtidoPostpuesto";
            this.CBSurtidoPostpuesto.Size = new System.Drawing.Size(215, 17);
            this.CBSurtidoPostpuesto.TabIndex = 90;
            this.CBSurtidoPostpuesto.Text = "Surtido procesado hasta almacen";
            this.CBSurtidoPostpuesto.UseVisualStyleBackColor = false;
            this.CBSurtidoPostpuesto.CheckedChanged += new System.EventHandler(this.CBSurtidoPostpuesto_CheckedChanged);
            // 
            // CBTIPOTARJETA
            // 
            this.CBTIPOTARJETA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBTIPOTARJETA.FormattingEnabled = true;
            this.CBTIPOTARJETA.Items.AddRange(new object[] {
            "TARJETA DE CREDITO",
            "TARJETA DE DEBITO",
            "TARJETA DE SERVICIO"});
            this.CBTIPOTARJETA.Location = new System.Drawing.Point(3, 92);
            this.CBTIPOTARJETA.Name = "CBTIPOTARJETA";
            this.CBTIPOTARJETA.Size = new System.Drawing.Size(163, 26);
            this.CBTIPOTARJETA.TabIndex = 91;
            // 
            // pnlCreditoAutomatico
            // 
            this.pnlCreditoAutomatico.BackColor = System.Drawing.Color.Transparent;
            this.pnlCreditoAutomatico.Controls.Add(this.lblCreditoAutomatico);
            this.pnlCreditoAutomatico.Controls.Add(this.label15);
            this.pnlCreditoAutomatico.Location = new System.Drawing.Point(3, 319);
            this.pnlCreditoAutomatico.Name = "pnlCreditoAutomatico";
            this.pnlCreditoAutomatico.Size = new System.Drawing.Size(799, 39);
            this.pnlCreditoAutomatico.TabIndex = 92;
            // 
            // lblCreditoAutomatico
            // 
            this.lblCreditoAutomatico.AllowNegative = true;
            this.lblCreditoAutomatico.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditoAutomatico.Format_Expression = null;
            this.lblCreditoAutomatico.Location = new System.Drawing.Point(180, 6);
            this.lblCreditoAutomatico.Name = "lblCreditoAutomatico";
            this.lblCreditoAutomatico.NumericPrecision = 17;
            this.lblCreditoAutomatico.NumericScaleOnFocus = 2;
            this.lblCreditoAutomatico.NumericScaleOnLostFocus = 2;
            this.lblCreditoAutomatico.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lblCreditoAutomatico.ReadOnly = true;
            this.lblCreditoAutomatico.Size = new System.Drawing.Size(236, 29);
            this.lblCreditoAutomatico.TabIndex = 87;
            this.lblCreditoAutomatico.Tag = 34;
            this.lblCreditoAutomatico.Text = "0.00";
            this.lblCreditoAutomatico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lblCreditoAutomatico.ValidationExpression = null;
            this.lblCreditoAutomatico.ZeroIsValid = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label15.Location = new System.Drawing.Point(32, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(142, 24);
            this.label15.TabIndex = 85;
            this.label15.Text = "Credito autom. :";
            // 
            // BtnCompraRelacionada
            // 
            this.BtnCompraRelacionada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BtnCompraRelacionada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BtnCompraRelacionada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCompraRelacionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCompraRelacionada.ForeColor = System.Drawing.Color.White;
            this.BtnCompraRelacionada.Location = new System.Drawing.Point(389, 3);
            this.BtnCompraRelacionada.Name = "BtnCompraRelacionada";
            this.BtnCompraRelacionada.Size = new System.Drawing.Size(207, 27);
            this.BtnCompraRelacionada.TabIndex = 93;
            this.BtnCompraRelacionada.Text = "Seleccionar compra relacionada";
            this.BtnCompraRelacionada.UseVisualStyleBackColor = false;
            this.BtnCompraRelacionada.Click += new System.EventHandler(this.BtnCompraRelacionada_Click);
            // 
            // pnlCompraRelacionada
            // 
            this.pnlCompraRelacionada.BackColor = System.Drawing.Color.Transparent;
            this.pnlCompraRelacionada.Controls.Add(this.BtnQuitarCompraRelacionada);
            this.pnlCompraRelacionada.Controls.Add(this.lblCompraRelacionada);
            this.pnlCompraRelacionada.Controls.Add(this.label16);
            this.pnlCompraRelacionada.Controls.Add(this.BtnCompraRelacionada);
            this.pnlCompraRelacionada.Location = new System.Drawing.Point(3, 360);
            this.pnlCompraRelacionada.Name = "pnlCompraRelacionada";
            this.pnlCompraRelacionada.Size = new System.Drawing.Size(804, 35);
            this.pnlCompraRelacionada.TabIndex = 96;
            // 
            // BtnQuitarCompraRelacionada
            // 
            this.BtnQuitarCompraRelacionada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BtnQuitarCompraRelacionada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BtnQuitarCompraRelacionada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQuitarCompraRelacionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuitarCompraRelacionada.ForeColor = System.Drawing.Color.White;
            this.BtnQuitarCompraRelacionada.Location = new System.Drawing.Point(604, 4);
            this.BtnQuitarCompraRelacionada.Name = "BtnQuitarCompraRelacionada";
            this.BtnQuitarCompraRelacionada.Size = new System.Drawing.Size(181, 27);
            this.BtnQuitarCompraRelacionada.TabIndex = 97;
            this.BtnQuitarCompraRelacionada.Text = "Quitar compra relacionada";
            this.BtnQuitarCompraRelacionada.UseVisualStyleBackColor = false;
            this.BtnQuitarCompraRelacionada.Click += new System.EventHandler(this.BtnQuitarCompraRelacionada_Click);
            // 
            // lblCompraRelacionada
            // 
            this.lblCompraRelacionada.AutoSize = true;
            this.lblCompraRelacionada.BackColor = System.Drawing.Color.Transparent;
            this.lblCompraRelacionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompraRelacionada.ForeColor = System.Drawing.Color.White;
            this.lblCompraRelacionada.Location = new System.Drawing.Point(179, 12);
            this.lblCompraRelacionada.Name = "lblCompraRelacionada";
            this.lblCompraRelacionada.Size = new System.Drawing.Size(16, 13);
            this.lblCompraRelacionada.TabIndex = 96;
            this.lblCompraRelacionada.Text = "...";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label16.Location = new System.Drawing.Point(55, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 24);
            this.label16.TabIndex = 95;
            this.label16.Text = "Compra rel. :";
            // 
            // USOCFDITextBox
            // 
            this.USOCFDITextBox.Condicion = null;
            this.USOCFDITextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.USOCFDITextBox.DisplayMember = "sat_descripcion";
            this.USOCFDITextBox.FormattingEnabled = true;
            this.USOCFDITextBox.IndiceCampoSelector = 0;
            this.USOCFDITextBox.LabelDescription = null;
            this.USOCFDITextBox.Location = new System.Drawing.Point(286, 505);
            this.USOCFDITextBox.Name = "USOCFDITextBox";
            this.USOCFDITextBox.NombreCampoSelector = "id";
            this.USOCFDITextBox.Query = resources.GetString("USOCFDITextBox.Query");
            this.USOCFDITextBox.QueryDeSeleccion = resources.GetString("USOCFDITextBox.QueryDeSeleccion");
            this.USOCFDITextBox.SelectedDataDisplaying = null;
            this.USOCFDITextBox.SelectedDataValue = null;
            this.USOCFDITextBox.Size = new System.Drawing.Size(227, 21);
            this.USOCFDITextBox.TabIndex = 208;
            this.USOCFDITextBox.ValueMember = "id";
            this.USOCFDITextBox.Visible = false;
            // 
            // USOCFDILabel
            // 
            this.USOCFDILabel.AutoSize = true;
            this.USOCFDILabel.BackColor = System.Drawing.Color.Transparent;
            this.USOCFDILabel.Location = new System.Drawing.Point(283, 490);
            this.USOCFDILabel.Name = "USOCFDILabel";
            this.USOCFDILabel.Size = new System.Drawing.Size(59, 13);
            this.USOCFDILabel.TabIndex = 207;
            this.USOCFDILabel.Text = "Uso CFDI: ";
            this.USOCFDILabel.Visible = false;
            // 
            // CBRevisionFinal
            // 
            this.CBRevisionFinal.AutoSize = true;
            this.CBRevisionFinal.BackColor = System.Drawing.Color.Transparent;
            this.CBRevisionFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBRevisionFinal.ForeColor = System.Drawing.Color.White;
            this.CBRevisionFinal.Location = new System.Drawing.Point(538, 522);
            this.CBRevisionFinal.Name = "CBRevisionFinal";
            this.CBRevisionFinal.Size = new System.Drawing.Size(170, 17);
            this.CBRevisionFinal.TabIndex = 209;
            this.CBRevisionFinal.Text = "Marcar para revision final";
            this.CBRevisionFinal.UseVisualStyleBackColor = false;
            // 
            // pnlOtros
            // 
            this.pnlOtros.BackColor = System.Drawing.Color.Transparent;
            this.pnlOtros.Controls.Add(this.lblOtros);
            this.pnlOtros.Controls.Add(this.label18);
            this.pnlOtros.Controls.Add(this.BtnAvanzado);
            this.pnlOtros.Location = new System.Drawing.Point(3, 401);
            this.pnlOtros.Name = "pnlOtros";
            this.pnlOtros.Size = new System.Drawing.Size(804, 35);
            this.pnlOtros.TabIndex = 210;
            // 
            // lblOtros
            // 
            this.lblOtros.AutoSize = true;
            this.lblOtros.BackColor = System.Drawing.Color.Transparent;
            this.lblOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtros.ForeColor = System.Drawing.Color.White;
            this.lblOtros.Location = new System.Drawing.Point(179, 12);
            this.lblOtros.Name = "lblOtros";
            this.lblOtros.Size = new System.Drawing.Size(35, 24);
            this.lblOtros.TabIndex = 96;
            this.lblOtros.Text = "0.0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label18.Location = new System.Drawing.Point(55, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 24);
            this.label18.TabIndex = 95;
            this.label18.Text = "Otros :";
            // 
            // BtnAvanzado
            // 
            this.BtnAvanzado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BtnAvanzado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BtnAvanzado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAvanzado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAvanzado.ForeColor = System.Drawing.Color.White;
            this.BtnAvanzado.Location = new System.Drawing.Point(389, 3);
            this.BtnAvanzado.Name = "BtnAvanzado";
            this.BtnAvanzado.Size = new System.Drawing.Size(207, 27);
            this.BtnAvanzado.TabIndex = 93;
            this.BtnAvanzado.Text = "Opciones avanzadas";
            this.BtnAvanzado.UseVisualStyleBackColor = false;
            this.BtnAvanzado.Click += new System.EventHandler(this.BtnAvanzado_Click);
            // 
            // CBComprobanteTraslado
            // 
            this.CBComprobanteTraslado.AutoSize = true;
            this.CBComprobanteTraslado.BackColor = System.Drawing.Color.Transparent;
            this.CBComprobanteTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBComprobanteTraslado.ForeColor = System.Drawing.Color.White;
            this.CBComprobanteTraslado.Location = new System.Drawing.Point(38, 531);
            this.CBComprobanteTraslado.Name = "CBComprobanteTraslado";
            this.CBComprobanteTraslado.Size = new System.Drawing.Size(197, 17);
            this.CBComprobanteTraslado.TabIndex = 211;
            this.CBComprobanteTraslado.Text = "Generar comprobante traslado";
            this.CBComprobanteTraslado.UseVisualStyleBackColor = false;
            // 
            // CBCartaPorte
            // 
            this.CBCartaPorte.AutoSize = true;
            this.CBCartaPorte.BackColor = System.Drawing.Color.Transparent;
            this.CBCartaPorte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBCartaPorte.ForeColor = System.Drawing.Color.White;
            this.CBCartaPorte.Location = new System.Drawing.Point(38, 571);
            this.CBCartaPorte.Name = "CBCartaPorte";
            this.CBCartaPorte.Size = new System.Drawing.Size(137, 17);
            this.CBCartaPorte.TabIndex = 212;
            this.CBCartaPorte.Text = "Generar carta porte";
            this.CBCartaPorte.UseVisualStyleBackColor = false;
            // 
            // btnReinicializaVerifone
            // 
            this.btnReinicializaVerifone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnReinicializaVerifone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnReinicializaVerifone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReinicializaVerifone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnReinicializaVerifone.ForeColor = System.Drawing.Color.White;
            this.btnReinicializaVerifone.Location = new System.Drawing.Point(608, 53);
            this.btnReinicializaVerifone.Name = "btnReinicializaVerifone";
            this.btnReinicializaVerifone.Size = new System.Drawing.Size(191, 25);
            this.btnReinicializaVerifone.TabIndex = 213;
            this.btnReinicializaVerifone.Text = "Reinicializa terminal verifone";
            this.btnReinicializaVerifone.UseVisualStyleBackColor = false;
            this.btnReinicializaVerifone.Visible = false;
            this.btnReinicializaVerifone.Click += new System.EventHandler(this.btnReinicializaVerifone_Click);
            // 
            // WFPagosBasico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(808, 601);
            this.Controls.Add(this.btnReinicializaVerifone);
            this.Controls.Add(this.CBCartaPorte);
            this.Controls.Add(this.CBComprobanteTraslado);
            this.Controls.Add(this.pnlOtros);
            this.Controls.Add(this.CBRevisionFinal);
            this.Controls.Add(this.USOCFDITextBox);
            this.Controls.Add(this.USOCFDILabel);
            this.Controls.Add(this.pnlCompraRelacionada);
            this.Controls.Add(this.pnlCreditoAutomatico);
            this.Controls.Add(this.CBTIPOTARJETA);
            this.Controls.Add(this.CBSurtidoPostpuesto);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.NOTAPAGOTextBox);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.LBMONEDA);
            this.Controls.Add(this.pnlBancarioTransferencia);
            this.Controls.Add(this.TBMontoTransferencia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TBNumeroMonedero);
            this.Controls.Add(this.BtnMonedero);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TBMonederoAplicado);
            this.Controls.Add(this.pnlBancarioCheque);
            this.Controls.Add(this.pnlBancarioTarjeta);
            this.Controls.Add(this.CBFacturaElectronica);
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
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "WFPagosBasico";
            this.Text = "Pago";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFPagosBasico_FormClosing);
            this.Load += new System.EventHandler(this.WFPagosBasico_Load);
            this.Shown += new System.EventHandler(this.WFPagosBasico_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WFPagosBasico_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLE_DE_PAGOBindingSource)).EndInit();
            this.pnlBancarioTarjeta.ResumeLayout(false);
            this.pnlBancarioTarjeta.PerformLayout();
            this.pnlBancarioCheque.ResumeLayout(false);
            this.pnlBancarioCheque.PerformLayout();
            this.pnlBancarioTransferencia.ResumeLayout(false);
            this.pnlBancarioTransferencia.PerformLayout();
            this.pnlCreditoAutomatico.ResumeLayout(false);
            this.pnlCreditoAutomatico.PerformLayout();
            this.pnlCompraRelacionada.ResumeLayout(false);
            this.pnlCompraRelacionada.PerformLayout();
            this.pnlOtros.ResumeLayout(false);
            this.pnlOtros.PerformLayout();
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
        private System.Windows.Forms.CheckBox CBFacturaElectronica;
        private System.Windows.Forms.Panel pnlBancarioTarjeta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TBReferenciaTarjeta;
        private System.Windows.Forms.ComboBoxFB ComboBancoTarjeta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnlBancarioCheque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBReferenciaCheque;
        private System.Windows.Forms.ComboBoxFB ComboBancoCheque;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TBNumeroMonedero;
        private System.Windows.Forms.Button BtnMonedero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TBMonederoAplicado;
        private System.Windows.Forms.Panel pnlBancarioTransferencia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBReferenciaTransferencia;
        private System.Windows.Forms.ComboBoxFB ComboBancoTransferencia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericTextBox TBMontoTransferencia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label LBMONEDA;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox NOTAPAGOTextBox;
        private System.Windows.Forms.CheckBox CBSurtidoPostpuesto;
        private System.Windows.Forms.ComboBox CBTIPOTARJETA;
        private System.Windows.Forms.Panel pnlCreditoAutomatico;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericTextBox lblCreditoAutomatico;
        private System.Windows.Forms.Button BtnCompraRelacionada;
        private System.Windows.Forms.Panel pnlCompraRelacionada;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblCompraRelacionada;
        private System.Windows.Forms.Button BtnQuitarCompraRelacionada;
        private System.Windows.Forms.ComboBoxFB USOCFDITextBox;
        private System.Windows.Forms.Label USOCFDILabel;
        private System.Windows.Forms.CheckBox CBRevisionFinal;
        private System.Windows.Forms.Panel pnlOtros;
        private System.Windows.Forms.Label lblOtros;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button BtnAvanzado;
        private System.Windows.Forms.CheckBox CBComprobanteTraslado;
        private System.Windows.Forms.CheckBox CBCartaPorte;
        private System.Windows.Forms.Button btnReinicializaVerifone;
    }
}