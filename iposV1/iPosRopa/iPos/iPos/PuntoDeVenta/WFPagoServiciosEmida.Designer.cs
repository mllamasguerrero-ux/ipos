namespace iPos
{
    partial class WFPagoServiciosEmida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPagoServiciosEmida));
            this.TBMonto = new System.Windows.Forms.NumericTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblCompania = new System.Windows.Forms.Label();
            this.FbConnection1_CARRIERS = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1_CARRIERS = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.dSPuntoDeVentaAux2 = new iPos.PuntoDeVenta.DSPuntoDeVentaAux2();
            this.cARRIERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cARRIERTableAdapter = new iPos.PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.CARRIERTableAdapter();
            this.tableAdapterManager = new iPos.PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.TableAdapterManager();
            this.CBCompaniaEmida = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCantidadEmida = new System.Windows.Forms.ComboBox();
            this.eMIDAPRODUCTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtNum1 = new System.Windows.Forms.TextBox();
            this.txtNum2 = new System.Windows.Forms.TextBox();
            this.eMIDAPRODUCTTableAdapter = new iPos.PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.EMIDAPRODUCTTableAdapter();
            this.BTCliente = new System.Windows.Forms.Button();
            this.LBClienteNombre = new System.Windows.Forms.Label();
            this.lblReferencia1 = new System.Windows.Forms.Label();
            this.lblReferencia2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBMontoAplicar = new System.Windows.Forms.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBComision = new System.Windows.Forms.NumericTextBox();
            this.lblDigits1 = new System.Windows.Forms.Label();
            this.lblDigits2 = new System.Windows.Forms.Label();
            this.btnRefreshCarriers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cARRIERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMIDAPRODUCTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TBMonto
            // 
            this.TBMonto.AllowNegative = true;
            this.TBMonto.BackColor = System.Drawing.Color.White;
            this.TBMonto.Enabled = false;
            this.TBMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMonto.Format_Expression = null;
            this.TBMonto.Location = new System.Drawing.Point(213, 171);
            this.TBMonto.Name = "TBMonto";
            this.TBMonto.NumericPrecision = 10;
            this.TBMonto.NumericScaleOnFocus = 3;
            this.TBMonto.NumericScaleOnLostFocus = 3;
            this.TBMonto.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBMonto.Size = new System.Drawing.Size(124, 26);
            this.TBMonto.TabIndex = 12;
            this.TBMonto.TabStop = false;
            this.TBMonto.Tag = 34;
            this.TBMonto.Text = "0.000";
            this.TBMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMonto.ValidationExpression = null;
            this.TBMonto.ZeroIsValid = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Location = new System.Drawing.Point(302, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 35);
            this.button1.TabIndex = 16;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCompania
            // 
            this.lblCompania.AutoSize = true;
            this.lblCompania.BackColor = System.Drawing.Color.Transparent;
            this.lblCompania.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompania.ForeColor = System.Drawing.Color.White;
            this.lblCompania.Location = new System.Drawing.Point(106, 13);
            this.lblCompania.Name = "lblCompania";
            this.lblCompania.Size = new System.Drawing.Size(101, 24);
            this.lblCompania.TabIndex = 12;
            this.lblCompania.Text = "Compañia:";
            // 
            // FbConnection1_CARRIERS
            // 
            this.FbConnection1_CARRIERS.ConnectionString = "Data Source=manuel;Initial Catalog=generador;Persist Security Info=True;User ID=s" +
    "a;Password=Twincept";
            // 
            // FbCommand1_CARRIERS
            // 
            this.FbCommand1_CARRIERS.CommandText = "Select DESCRIPTION from CARRIER where ACTIVO = \'S\'";
            this.FbCommand1_CARRIERS.CommandTimeout = 30;
            this.FbCommand1_CARRIERS.Connection = this.FbConnection1_CARRIERS;
            // 
            // dSPuntoDeVentaAux2
            // 
            this.dSPuntoDeVentaAux2.DataSetName = "DSPuntoDeVentaAux2";
            this.dSPuntoDeVentaAux2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cARRIERBindingSource
            // 
            this.cARRIERBindingSource.DataMember = "CARRIER";
            this.cARRIERBindingSource.DataSource = this.dSPuntoDeVentaAux2;
            // 
            // cARRIERTableAdapter
            // 
            this.cARRIERTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.EMIDAPRODUCTTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // CBCompaniaEmida
            // 
            this.CBCompaniaEmida.DataSource = this.cARRIERBindingSource;
            this.CBCompaniaEmida.DisplayMember = "DESCRIPTION";
            this.CBCompaniaEmida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCompaniaEmida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.CBCompaniaEmida.FormattingEnabled = true;
            this.CBCompaniaEmida.Location = new System.Drawing.Point(213, 15);
            this.CBCompaniaEmida.Name = "CBCompaniaEmida";
            this.CBCompaniaEmida.Size = new System.Drawing.Size(388, 25);
            this.CBCompaniaEmida.TabIndex = 10;
            this.CBCompaniaEmida.ValueMember = "CARRIERID";
            this.CBCompaniaEmida.SelectedIndexChanged += new System.EventHandler(this.CBCompaniaEmida_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(125, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "Servicio:";
            // 
            // cbCantidadEmida
            // 
            this.cbCantidadEmida.DataSource = this.eMIDAPRODUCTBindingSource;
            this.cbCantidadEmida.DisplayMember = "DESCRIPTION";
            this.cbCantidadEmida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCantidadEmida.Enabled = false;
            this.cbCantidadEmida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cbCantidadEmida.FormattingEnabled = true;
            this.cbCantidadEmida.Location = new System.Drawing.Point(213, 53);
            this.cbCantidadEmida.Name = "cbCantidadEmida";
            this.cbCantidadEmida.Size = new System.Drawing.Size(388, 25);
            this.cbCantidadEmida.TabIndex = 11;
            this.cbCantidadEmida.ValueMember = "PRODUCTID";
            this.cbCantidadEmida.SelectedIndexChanged += new System.EventHandler(this.cbCantidadEmida_SelectedIndexChanged);
            // 
            // eMIDAPRODUCTBindingSource
            // 
            this.eMIDAPRODUCTBindingSource.DataMember = "EMIDAPRODUCT";
            this.eMIDAPRODUCTBindingSource.DataSource = this.dSPuntoDeVentaAux2;
            // 
            // txtNum1
            // 
            this.txtNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum1.Location = new System.Drawing.Point(213, 222);
            this.txtNum1.MaxLength = 127;
            this.txtNum1.Name = "txtNum1";
            this.txtNum1.ShortcutsEnabled = false;
            this.txtNum1.Size = new System.Drawing.Size(388, 29);
            this.txtNum1.TabIndex = 13;
            this.txtNum1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum1_KeyPress);
            // 
            // txtNum2
            // 
            this.txtNum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum2.Location = new System.Drawing.Point(213, 270);
            this.txtNum2.MaxLength = 127;
            this.txtNum2.Name = "txtNum2";
            this.txtNum2.ShortcutsEnabled = false;
            this.txtNum2.Size = new System.Drawing.Size(388, 29);
            this.txtNum2.TabIndex = 14;
            this.txtNum2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum2_KeyPress);
            // 
            // eMIDAPRODUCTTableAdapter
            // 
            this.eMIDAPRODUCTTableAdapter.ClearBeforeFill = true;
            // 
            // BTCliente
            // 
            this.BTCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCliente.ForeColor = System.Drawing.Color.White;
            this.BTCliente.Location = new System.Drawing.Point(118, 328);
            this.BTCliente.Name = "BTCliente";
            this.BTCliente.Size = new System.Drawing.Size(85, 32);
            this.BTCliente.TabIndex = 15;
            this.BTCliente.Text = "Cliente";
            this.BTCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCliente.UseVisualStyleBackColor = false;
            this.BTCliente.Click += new System.EventHandler(this.BTCliente_Click);
            // 
            // LBClienteNombre
            // 
            this.LBClienteNombre.AutoSize = true;
            this.LBClienteNombre.BackColor = System.Drawing.Color.Transparent;
            this.LBClienteNombre.Enabled = false;
            this.LBClienteNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBClienteNombre.ForeColor = System.Drawing.Color.White;
            this.LBClienteNombre.Location = new System.Drawing.Point(212, 336);
            this.LBClienteNombre.Name = "LBClienteNombre";
            this.LBClienteNombre.Size = new System.Drawing.Size(25, 24);
            this.LBClienteNombre.TabIndex = 171;
            this.LBClienteNombre.Text = "...";
            this.LBClienteNombre.Click += new System.EventHandler(this.LBClienteNombre_Click);
            // 
            // lblReferencia1
            // 
            this.lblReferencia1.AutoSize = true;
            this.lblReferencia1.BackColor = System.Drawing.Color.Transparent;
            this.lblReferencia1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferencia1.ForeColor = System.Drawing.Color.White;
            this.lblReferencia1.Location = new System.Drawing.Point(101, 211);
            this.lblReferencia1.Name = "lblReferencia1";
            this.lblReferencia1.Size = new System.Drawing.Size(106, 24);
            this.lblReferencia1.TabIndex = 172;
            this.lblReferencia1.Text = "Referencia:";
            // 
            // lblReferencia2
            // 
            this.lblReferencia2.AutoSize = true;
            this.lblReferencia2.BackColor = System.Drawing.Color.Transparent;
            this.lblReferencia2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferencia2.ForeColor = System.Drawing.Color.White;
            this.lblReferencia2.Location = new System.Drawing.Point(97, 270);
            this.lblReferencia2.Name = "lblReferencia2";
            this.lblReferencia2.Size = new System.Drawing.Size(106, 24);
            this.lblReferencia2.TabIndex = 173;
            this.lblReferencia2.Text = "Referencia:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(151, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 174;
            this.label1.Text = "Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(139, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 24);
            this.label3.TabIndex = 176;
            this.label3.Text = "Monto:";
            // 
            // TBMontoAplicar
            // 
            this.TBMontoAplicar.AllowNegative = true;
            this.TBMontoAplicar.BackColor = System.Drawing.Color.White;
            this.TBMontoAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMontoAplicar.Format_Expression = null;
            this.TBMontoAplicar.Location = new System.Drawing.Point(213, 90);
            this.TBMontoAplicar.Name = "TBMontoAplicar";
            this.TBMontoAplicar.NumericPrecision = 10;
            this.TBMontoAplicar.NumericScaleOnFocus = 3;
            this.TBMontoAplicar.NumericScaleOnLostFocus = 3;
            this.TBMontoAplicar.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBMontoAplicar.Size = new System.Drawing.Size(124, 26);
            this.TBMontoAplicar.TabIndex = 12;
            this.TBMontoAplicar.Tag = 34;
            this.TBMontoAplicar.Text = "0.000";
            this.TBMontoAplicar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMontoAplicar.ValidationExpression = null;
            this.TBMontoAplicar.ZeroIsValid = true;
            this.TBMontoAplicar.Validated += new System.EventHandler(this.TBMontoAplicar_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(113, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 178;
            this.label4.Text = "Comision:";
            // 
            // TBComision
            // 
            this.TBComision.AllowNegative = true;
            this.TBComision.BackColor = System.Drawing.Color.White;
            this.TBComision.Enabled = false;
            this.TBComision.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBComision.Format_Expression = null;
            this.TBComision.Location = new System.Drawing.Point(213, 129);
            this.TBComision.Name = "TBComision";
            this.TBComision.NumericPrecision = 10;
            this.TBComision.NumericScaleOnFocus = 3;
            this.TBComision.NumericScaleOnLostFocus = 3;
            this.TBComision.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBComision.Size = new System.Drawing.Size(124, 26);
            this.TBComision.TabIndex = 12;
            this.TBComision.TabStop = false;
            this.TBComision.Tag = 34;
            this.TBComision.Text = "0.000";
            this.TBComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBComision.ValidationExpression = null;
            this.TBComision.ZeroIsValid = true;
            // 
            // lblDigits1
            // 
            this.lblDigits1.AutoSize = true;
            this.lblDigits1.BackColor = System.Drawing.Color.Transparent;
            this.lblDigits1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDigits1.ForeColor = System.Drawing.Color.White;
            this.lblDigits1.Location = new System.Drawing.Point(126, 235);
            this.lblDigits1.Name = "lblDigits1";
            this.lblDigits1.Size = new System.Drawing.Size(77, 16);
            this.lblDigits1.TabIndex = 179;
            this.lblDigits1.Text = "Referencia:";
            // 
            // lblDigits2
            // 
            this.lblDigits2.AutoSize = true;
            this.lblDigits2.BackColor = System.Drawing.Color.Transparent;
            this.lblDigits2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDigits2.ForeColor = System.Drawing.Color.White;
            this.lblDigits2.Location = new System.Drawing.Point(126, 294);
            this.lblDigits2.Name = "lblDigits2";
            this.lblDigits2.Size = new System.Drawing.Size(77, 16);
            this.lblDigits2.TabIndex = 180;
            this.lblDigits2.Text = "Referencia:";
            // 
            // btnRefreshCarriers
            // 
            this.btnRefreshCarriers.BackgroundImage = global::iPos.Properties.Resources.refresh_J;
            this.btnRefreshCarriers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshCarriers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshCarriers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnRefreshCarriers.Location = new System.Drawing.Point(630, 8);
            this.btnRefreshCarriers.Name = "btnRefreshCarriers";
            this.btnRefreshCarriers.Size = new System.Drawing.Size(47, 49);
            this.btnRefreshCarriers.TabIndex = 181;
            this.btnRefreshCarriers.UseVisualStyleBackColor = true;
            this.btnRefreshCarriers.Click += new System.EventHandler(this.btnRefreshCarriers_Click);
            // 
            // WFPagoServiciosEmida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 419);
            this.Controls.Add(this.btnRefreshCarriers);
            this.Controls.Add(this.lblDigits2);
            this.Controls.Add(this.lblDigits1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBComision);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBMontoAplicar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblReferencia2);
            this.Controls.Add(this.lblReferencia1);
            this.Controls.Add(this.LBClienteNombre);
            this.Controls.Add(this.BTCliente);
            this.Controls.Add(this.txtNum2);
            this.Controls.Add(this.txtNum1);
            this.Controls.Add(this.cbCantidadEmida);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBCompaniaEmida);
            this.Controls.Add(this.lblCompania);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TBMonto);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFPagoServiciosEmida";
            this.Text = "Pago de servicios";
            this.Load += new System.EventHandler(this.WFPagoServiciosEmida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cARRIERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMIDAPRODUCTBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericTextBox TBMonto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCompania;
        private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1_CARRIERS;
        private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1_CARRIERS;
        private PuntoDeVenta.DSPuntoDeVentaAux2 dSPuntoDeVentaAux2;
        private System.Windows.Forms.BindingSource cARRIERBindingSource;
        private PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.CARRIERTableAdapter cARRIERTableAdapter;
        private PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox CBCompaniaEmida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCantidadEmida;
        private System.Windows.Forms.TextBox txtNum1;
        private System.Windows.Forms.TextBox txtNum2;
        private System.Windows.Forms.BindingSource eMIDAPRODUCTBindingSource;
        private PuntoDeVenta.DSPuntoDeVentaAux2TableAdapters.EMIDAPRODUCTTableAdapter eMIDAPRODUCTTableAdapter;
        private System.Windows.Forms.Button BTCliente;
        private System.Windows.Forms.Label LBClienteNombre;
        private System.Windows.Forms.Label lblReferencia1;
        private System.Windows.Forms.Label lblReferencia2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericTextBox TBMontoAplicar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericTextBox TBComision;
        private System.Windows.Forms.Label lblDigits1;
        private System.Windows.Forms.Label lblDigits2;
        private System.Windows.Forms.Button btnRefreshCarriers;
    }
}