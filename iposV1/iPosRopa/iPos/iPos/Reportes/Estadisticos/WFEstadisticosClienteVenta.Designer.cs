namespace iPos
{
    partial class WFEstadisticosClienteVenta
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
            System.Windows.Forms.Label label40;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFEstadisticosClienteVenta));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ITEMButton = new System.Windows.Forms.Button();
            this.ITEMIDTextBox = new iPos.Tools.TextBoxFB();
            this.ITEMLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.INLUIRTRASLTextBox = new System.Windows.Forms.CheckBox();
            this.ANIO2TextBox = new System.Windows.Forms.NumericTextBox();
            this.ANIO1TextBox = new System.Windows.Forms.NumericTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tTL_REP_CLIENTE_COMPARACIONDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGIMAGE = new System.Windows.Forms.DataGridViewImageColumn();
            this.tTL_REP_CLIENTE_COMPARACIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSFastReports = new iPos.Reportes.DSFastReports();
            this.tTL_REP_CLIENTE_COMPARACIONTableAdapter = new iPos.Reportes.DSFastReportsTableAdapters.TTL_REP_CLIENTE_COMPARACIONTableAdapter();
            this.tableAdapterManager = new iPos.Reportes.DSFastReportsTableAdapters.TableAdapterManager();
            label40 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tTL_REP_CLIENTE_COMPARACIONDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTL_REP_CLIENTE_COMPARACIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSFastReports)).BeginInit();
            this.SuspendLayout();
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label40.ForeColor = System.Drawing.Color.White;
            label40.Location = new System.Drawing.Point(85, 70);
            label40.Name = "label40";
            label40.Size = new System.Drawing.Size(44, 13);
            label40.TabIndex = 245;
            label40.Text = "Año 1:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(340, 70);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 13);
            label1.TabIndex = 247;
            label1.Text = "Año 2:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.ITEMButton);
            this.panel1.Controls.Add(this.ITEMIDTextBox);
            this.panel1.Controls.Add(this.ITEMLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Controls.Add(this.INLUIRTRASLTextBox);
            this.panel1.Controls.Add(label1);
            this.panel1.Controls.Add(this.ANIO2TextBox);
            this.panel1.Controls.Add(label40);
            this.panel1.Controls.Add(this.ANIO1TextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 107);
            this.panel1.TabIndex = 3;
            // 
            // ITEMButton
            // 
            this.ITEMButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(257, 31);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(23, 23);
            this.ITEMButton.TabIndex = 2;
            this.ITEMButton.UseVisualStyleBackColor = true;
            this.ITEMButton.Click += new System.EventHandler(this.ITEMButton_Click_1);
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
            this.ITEMIDTextBox.Location = new System.Drawing.Point(156, 32);
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
            this.ITEMIDTextBox.TabIndex = 1;
            this.ITEMIDTextBox.Tag = 34;
            this.ITEMIDTextBox.TextDescription = null;
            this.ITEMIDTextBox.Titulo = "Clientes";
            this.ITEMIDTextBox.ValidarEntrada = true;
            this.ITEMIDTextBox.ValidationExpression = null;
            this.ITEMIDTextBox.Validated += new System.EventHandler(this.ITEMIDTextBox_Validated);
            // 
            // ITEMLabel
            // 
            this.ITEMLabel.AutoSize = true;
            this.ITEMLabel.ForeColor = System.Drawing.Color.White;
            this.ITEMLabel.Location = new System.Drawing.Point(284, 36);
            this.ITEMLabel.Name = "ITEMLabel";
            this.ITEMLabel.Size = new System.Drawing.Size(16, 13);
            this.ITEMLabel.TabIndex = 253;
            this.ITEMLabel.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(85, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 252;
            this.label4.Text = "Cliente:";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(692, 65);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 23);
            this.BTEnviar.TabIndex = 6;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // INLUIRTRASLTextBox
            // 
            this.INLUIRTRASLTextBox.AutoSize = true;
            this.INLUIRTRASLTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INLUIRTRASLTextBox.ForeColor = System.Drawing.Color.White;
            this.INLUIRTRASLTextBox.Location = new System.Drawing.Point(535, 69);
            this.INLUIRTRASLTextBox.Name = "INLUIRTRASLTextBox";
            this.INLUIRTRASLTextBox.Size = new System.Drawing.Size(116, 17);
            this.INLUIRTRASLTextBox.TabIndex = 5;
            this.INLUIRTRASLTextBox.Text = "Incluir traslados";
            this.INLUIRTRASLTextBox.UseVisualStyleBackColor = true;
            // 
            // ANIO2TextBox
            // 
            this.ANIO2TextBox.AllowNegative = true;
            this.ANIO2TextBox.Format_Expression = null;
            this.ANIO2TextBox.Location = new System.Drawing.Point(390, 67);
            this.ANIO2TextBox.Name = "ANIO2TextBox";
            this.ANIO2TextBox.NumericPrecision = 18;
            this.ANIO2TextBox.NumericScaleOnFocus = 0;
            this.ANIO2TextBox.NumericScaleOnLostFocus = 0;
            this.ANIO2TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ANIO2TextBox.Size = new System.Drawing.Size(87, 20);
            this.ANIO2TextBox.TabIndex = 4;
            this.ANIO2TextBox.Tag = 34;
            this.ANIO2TextBox.Text = "0";
            this.ANIO2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ANIO2TextBox.ValidationExpression = null;
            this.ANIO2TextBox.ZeroIsValid = true;
            // 
            // ANIO1TextBox
            // 
            this.ANIO1TextBox.AllowNegative = true;
            this.ANIO1TextBox.Format_Expression = null;
            this.ANIO1TextBox.Location = new System.Drawing.Point(156, 67);
            this.ANIO1TextBox.Name = "ANIO1TextBox";
            this.ANIO1TextBox.NumericPrecision = 18;
            this.ANIO1TextBox.NumericScaleOnFocus = 0;
            this.ANIO1TextBox.NumericScaleOnLostFocus = 0;
            this.ANIO1TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ANIO1TextBox.Size = new System.Drawing.Size(95, 20);
            this.ANIO1TextBox.TabIndex = 3;
            this.ANIO1TextBox.Tag = 34;
            this.ANIO1TextBox.Text = "0";
            this.ANIO1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ANIO1TextBox.ValidationExpression = null;
            this.ANIO1TextBox.ZeroIsValid = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 441);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(859, 49);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tTL_REP_CLIENTE_COMPARACIONDataGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 107);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(859, 334);
            this.panel3.TabIndex = 5;
            // 
            // tTL_REP_CLIENTE_COMPARACIONDataGridView
            // 
            this.tTL_REP_CLIENTE_COMPARACIONDataGridView.AllowUserToAddRows = false;
            this.tTL_REP_CLIENTE_COMPARACIONDataGridView.AutoGenerateColumns = false;
            this.tTL_REP_CLIENTE_COMPARACIONDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tTL_REP_CLIENTE_COMPARACIONDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.DGIMAGE});
            this.tTL_REP_CLIENTE_COMPARACIONDataGridView.DataSource = this.tTL_REP_CLIENTE_COMPARACIONBindingSource;
            this.tTL_REP_CLIENTE_COMPARACIONDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tTL_REP_CLIENTE_COMPARACIONDataGridView.Location = new System.Drawing.Point(0, 0);
            this.tTL_REP_CLIENTE_COMPARACIONDataGridView.Name = "tTL_REP_CLIENTE_COMPARACIONDataGridView";
            this.tTL_REP_CLIENTE_COMPARACIONDataGridView.ReadOnly = true;
            this.tTL_REP_CLIENTE_COMPARACIONDataGridView.RowHeadersVisible = false;
            this.tTL_REP_CLIENTE_COMPARACIONDataGridView.Size = new System.Drawing.Size(859, 334);
            this.tTL_REP_CLIENTE_COMPARACIONDataGridView.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MES";
            this.dataGridViewTextBoxColumn1.HeaderText = "MES";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PERSONAID";
            this.dataGridViewTextBoxColumn2.HeaderText = "PERSONAID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CANTIDADANIO1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "CANTIDAD AÑO 1";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TOTALANIO1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn4.HeaderText = "TOTAL AÑO 1";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CANTIDADANIO2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn5.HeaderText = "CANTIDAD AÑO 2";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TOTALANIO2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn6.HeaderText = "TOTAL AÑO 2";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DIFERENCIA";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn7.HeaderText = "DIFERENCIA";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PORCENTAJEDIFERENCIA";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn8.HeaderText = "% DIF.";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 50;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ACUMULADODIFERENCIA";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn9.HeaderText = "ACUM. DIF.";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 90;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "PORCACUMULADODIFERENCIA";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn10.HeaderText = "% ACUM. DIF.";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 50;
            // 
            // DGIMAGE
            // 
            this.DGIMAGE.HeaderText = "";
            this.DGIMAGE.Name = "DGIMAGE";
            this.DGIMAGE.ReadOnly = true;
            this.DGIMAGE.Width = 30;
            // 
            // tTL_REP_CLIENTE_COMPARACIONBindingSource
            // 
            this.tTL_REP_CLIENTE_COMPARACIONBindingSource.DataMember = "TTL_REP_CLIENTE_COMPARACION";
            this.tTL_REP_CLIENTE_COMPARACIONBindingSource.DataSource = this.dSFastReports;
            // 
            // dSFastReports
            // 
            this.dSFastReports.DataSetName = "DSFastReports";
            this.dSFastReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tTL_REP_CLIENTE_COMPARACIONTableAdapter
            // 
            this.tTL_REP_CLIENTE_COMPARACIONTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Reportes.DSFastReportsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFEstadisticosClienteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(859, 490);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFEstadisticosClienteVenta";
            this.Text = "Estadisticos Cliente Venta";
            this.Load += new System.EventHandler(this.WFEstadisticosClienteVenta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tTL_REP_CLIENTE_COMPARACIONDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTL_REP_CLIENTE_COMPARACIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSFastReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericTextBox ANIO1TextBox;
        private System.Windows.Forms.NumericTextBox ANIO2TextBox;
        private System.Windows.Forms.CheckBox INLUIRTRASLTextBox;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.Button ITEMButton;
        private Tools.TextBoxFB ITEMIDTextBox;
        private System.Windows.Forms.Label ITEMLabel;
        private System.Windows.Forms.Label label4;
        private Reportes.DSFastReports dSFastReports;
        private System.Windows.Forms.BindingSource tTL_REP_CLIENTE_COMPARACIONBindingSource;
        private Reportes.DSFastReportsTableAdapters.TTL_REP_CLIENTE_COMPARACIONTableAdapter tTL_REP_CLIENTE_COMPARACIONTableAdapter;
        private Reportes.DSFastReportsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum tTL_REP_CLIENTE_COMPARACIONDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewImageColumn DGIMAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    }
}