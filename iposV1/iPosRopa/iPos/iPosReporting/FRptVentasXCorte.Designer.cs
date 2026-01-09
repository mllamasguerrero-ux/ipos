namespace iPosReporting
{
    partial class FRptVentasXCorte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRptVentasXCorte));
            this.label1 = new System.Windows.Forms.Label();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxAlmacen = new System.Windows.Forms.ComboBox();
            this.aLMACENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSReportIpos = new iPosReporting.DSReportIpos();
            this.CBSoloAlmacen = new System.Windows.Forms.CheckBox();
            this.CBCajerosTodos = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VENDEDORButton = new System.Windows.Forms.Button();
            this.VENDEDORLabel = new System.Windows.Forms.Label();
            this.VENDEDORIDTextBox = new iPos.Tools.TextBoxFBRpt();
            this.CBTipo = new System.Windows.Forms.ComboBox();
            this.LBTIPOREG = new System.Windows.Forms.Label();
            this.tableAdapterManager = new iPosReporting.DSReportIposTableAdapters.TableAdapterManager();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabReporte = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.report1 = new FastReport.Report();
            this.aLMACENTableAdapter = new iPosReporting.DSReportIposTableAdapters.ALMACENTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aLMACENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(464, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // DTPFrom
            // 
            this.DTPFrom.Location = new System.Drawing.Point(517, 29);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(200, 20);
            this.DTPFrom.TabIndex = 3;
            // 
            // DTPTo
            // 
            this.DTPTo.Location = new System.Drawing.Point(750, 29);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(200, 20);
            this.DTPTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(728, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "A:";
            // 
            // BTEnviar
            // 
            this.BTEnviar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTEnviar.AutoSize = true;
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(975, 29);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 25);
            this.BTEnviar.TabIndex = 5;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "REPORTES DE VENTAS POR CORTE";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.comboBoxAlmacen);
            this.panel1.Controls.Add(this.CBSoloAlmacen);
            this.panel1.Controls.Add(this.CBCajerosTodos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.VENDEDORButton);
            this.panel1.Controls.Add(this.VENDEDORLabel);
            this.panel1.Controls.Add(this.VENDEDORIDTextBox);
            this.panel1.Controls.Add(this.CBTipo);
            this.panel1.Controls.Add(this.LBTIPOREG);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Controls.Add(this.DTPFrom);
            this.panel1.Controls.Add(this.DTPTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 94);
            this.panel1.TabIndex = 7;
            // 
            // comboBoxAlmacen
            // 
            this.comboBoxAlmacen.DataSource = this.aLMACENBindingSource;
            this.comboBoxAlmacen.DisplayMember = "CLAVE";
            this.comboBoxAlmacen.FormattingEnabled = true;
            this.comboBoxAlmacen.Location = new System.Drawing.Point(209, 55);
            this.comboBoxAlmacen.Name = "comboBoxAlmacen";
            this.comboBoxAlmacen.Size = new System.Drawing.Size(178, 21);
            this.comboBoxAlmacen.TabIndex = 179;
            this.comboBoxAlmacen.ValueMember = "ID";
            // 
            // aLMACENBindingSource
            // 
            this.aLMACENBindingSource.DataMember = "ALMACEN";
            this.aLMACENBindingSource.DataSource = this.dSReportIpos;
            // 
            // dSReportIpos
            // 
            this.dSReportIpos.DataSetName = "DSReportIpos";
            this.dSReportIpos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CBSoloAlmacen
            // 
            this.CBSoloAlmacen.AutoSize = true;
            this.CBSoloAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.CBSoloAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBSoloAlmacen.ForeColor = System.Drawing.Color.White;
            this.CBSoloAlmacen.Location = new System.Drawing.Point(64, 59);
            this.CBSoloAlmacen.Name = "CBSoloAlmacen";
            this.CBSoloAlmacen.Size = new System.Drawing.Size(127, 17);
            this.CBSoloAlmacen.TabIndex = 177;
            this.CBSoloAlmacen.Text = "Solo del almacen:";
            this.CBSoloAlmacen.UseVisualStyleBackColor = false;
            // 
            // CBCajerosTodos
            // 
            this.CBCajerosTodos.AutoSize = true;
            this.CBCajerosTodos.ForeColor = System.Drawing.Color.White;
            this.CBCajerosTodos.Location = new System.Drawing.Point(841, 59);
            this.CBCajerosTodos.Name = "CBCajerosTodos";
            this.CBCajerosTodos.Size = new System.Drawing.Size(109, 17);
            this.CBCajerosTodos.TabIndex = 176;
            this.CBCajerosTodos.Text = "Todos los cajeros";
            this.CBCajerosTodos.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(464, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 175;
            this.label4.Text = "Cajero:";
            // 
            // VENDEDORButton
            // 
            this.VENDEDORButton.Location = new System.Drawing.Point(623, 55);
            this.VENDEDORButton.Name = "VENDEDORButton";
            this.VENDEDORButton.Size = new System.Drawing.Size(30, 23);
            this.VENDEDORButton.TabIndex = 173;
            this.VENDEDORButton.Text = "...";
            this.VENDEDORButton.UseVisualStyleBackColor = true;
            // 
            // VENDEDORLabel
            // 
            this.VENDEDORLabel.AutoSize = true;
            this.VENDEDORLabel.ForeColor = System.Drawing.Color.White;
            this.VENDEDORLabel.Location = new System.Drawing.Point(659, 60);
            this.VENDEDORLabel.Name = "VENDEDORLabel";
            this.VENDEDORLabel.Size = new System.Drawing.Size(16, 13);
            this.VENDEDORLabel.TabIndex = 174;
            this.VENDEDORLabel.Text = "...";
            // 
            // VENDEDORIDTextBox
            // 
            this.VENDEDORIDTextBox.BotonLookUp = this.VENDEDORButton;
            this.VENDEDORIDTextBox.Condicion = null;
            this.VENDEDORIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORIDTextBox.DbValue = null;
            this.VENDEDORIDTextBox.Format_Expression = null;
            this.VENDEDORIDTextBox.IndiceCampoDescripcion = 2;
            this.VENDEDORIDTextBox.IndiceCampoSelector = 1;
            this.VENDEDORIDTextBox.IndiceCampoValue = 0;
            this.VENDEDORIDTextBox.LabelDescription = this.VENDEDORLabel;
            this.VENDEDORIDTextBox.Location = new System.Drawing.Point(517, 57);
            this.VENDEDORIDTextBox.MostrarErrores = true;
            this.VENDEDORIDTextBox.Name = "VENDEDORIDTextBox";
            this.VENDEDORIDTextBox.NombreCampoSelector = "clave";
            this.VENDEDORIDTextBox.NombreCampoValue = "id";
            this.VENDEDORIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid in (22,20)";
            this.VENDEDORIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid  in (22,20) and  clave= @" +
    "clave";
            this.VENDEDORIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid  in (22,20) and  id = @id" +
    "";
            this.VENDEDORIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.VENDEDORIDTextBox.TabIndex = 172;
            this.VENDEDORIDTextBox.Tag = 34;
            this.VENDEDORIDTextBox.TextDescription = null;
            this.VENDEDORIDTextBox.Titulo = "Cajeros";
            this.VENDEDORIDTextBox.ValidarEntrada = true;
            this.VENDEDORIDTextBox.ValidationExpression = null;
            // 
            // CBTipo
            // 
            this.CBTipo.FormattingEnabled = true;
            this.CBTipo.Items.AddRange(new object[] {
            "VENTAS",
            "TRASLADOS",
            "DEVOLUCIONES",
            "TODOS"});
            this.CBTipo.Location = new System.Drawing.Point(209, 29);
            this.CBTipo.Name = "CBTipo";
            this.CBTipo.Size = new System.Drawing.Size(231, 21);
            this.CBTipo.TabIndex = 2;
            // 
            // LBTIPOREG
            // 
            this.LBTIPOREG.AutoSize = true;
            this.LBTIPOREG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTIPOREG.ForeColor = System.Drawing.Color.White;
            this.LBTIPOREG.Location = new System.Drawing.Point(91, 34);
            this.LBTIPOREG.Name = "LBTIPOREG";
            this.LBTIPOREG.Size = new System.Drawing.Size(100, 13);
            this.LBTIPOREG.TabIndex = 13;
            this.LBTIPOREG.Text = "Tipo de registro:";
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CLIENTESTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.PRODUCTO1TableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPosReporting.DSReportIposTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabReporte);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1148, 544);
            this.tabControl1.TabIndex = 8;
            // 
            // tabReporte
            // 
            this.tabReporte.Controls.Add(this.previewControl1);
            this.tabReporte.Location = new System.Drawing.Point(4, 22);
            this.tabReporte.Name = "tabReporte";
            this.tabReporte.Padding = new System.Windows.Forms.Padding(3);
            this.tabReporte.Size = new System.Drawing.Size(1140, 518);
            this.tabReporte.TabIndex = 2;
            this.tabReporte.Text = "REPORTE";
            this.tabReporte.UseVisualStyleBackColor = true;
            // 
            // previewControl1
            // 
            this.previewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.previewControl1.Location = new System.Drawing.Point(3, 3);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl1.Size = new System.Drawing.Size(1134, 512);
            this.previewControl1.TabIndex = 0;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // aLMACENTableAdapter
            // 
            this.aLMACENTableAdapter.ClearBeforeFill = true;
            // 
            // FRptVentasXCorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1148, 638);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRptVentasXCorte";
            this.Text = "REPORTES DE VENTAS POR CORTE";
            this.Load += new System.EventHandler(this.FRptVentasXCorte_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aLMACENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabReporte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private DSReportIposTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox CBTipo;
        private System.Windows.Forms.Label LBTIPOREG;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabReporte;
        private FastReport.Preview.PreviewControl previewControl1;
        private FastReport.Report report1;
        private System.Windows.Forms.CheckBox CBCajerosTodos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button VENDEDORButton;
        private System.Windows.Forms.Label VENDEDORLabel;
        private iPos.Tools.TextBoxFBRpt VENDEDORIDTextBox;
        private System.Windows.Forms.CheckBox CBSoloAlmacen;
        private System.Windows.Forms.ComboBox comboBoxAlmacen;
        private System.Windows.Forms.BindingSource aLMACENBindingSource;
        private DSReportIposTableAdapters.ALMACENTableAdapter aLMACENTableAdapter;
        private DSReportIpos dSReportIpos;
    }
}