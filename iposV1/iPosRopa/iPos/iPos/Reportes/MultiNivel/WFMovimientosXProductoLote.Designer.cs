namespace iPos.Reportes
{
    partial class WFMovimientosXProductoLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFMovimientosXProductoLote));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TBLote = new System.Windows.Forms.TextBox();
            this.comboLote = new System.Windows.Forms.ComboBox();
            this.r_LISTALOTESINVENTARIOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSInventarioFisico2 = new iPos.Inventario.DSInventarioFisico2();
            this.RBManualLote = new System.Windows.Forms.RadioButton();
            this.RBSeleccionLote = new System.Windows.Forms.RadioButton();
            this.ITEMButton = new System.Windows.Forms.Button();
            this.ITEMIDTextBox = new iPos.Tools.TextBoxFB();
            this.ITEMLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.report1 = new FastReport.Report();
            this.r_LISTALOTESINVENTARIOTableAdapter = new iPos.Inventario.DSInventarioFisico2TableAdapters.R_LISTALOTESINVENTARIOTableAdapter();
            this.tableAdapterManager = new iPos.Inventario.DSInventarioFisico2TableAdapters.TableAdapterManager();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.r_LISTALOTESINVENTARIOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 113);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 397);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.previewControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(877, 371);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "REPORTE";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // previewControl1
            // 
            this.previewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.previewControl1.Location = new System.Drawing.Point(3, 3);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl1.Size = new System.Drawing.Size(871, 365);
            this.previewControl1.TabIndex = 0;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.TBLote);
            this.panel1.Controls.Add(this.comboLote);
            this.panel1.Controls.Add(this.RBManualLote);
            this.panel1.Controls.Add(this.RBSeleccionLote);
            this.panel1.Controls.Add(this.ITEMButton);
            this.panel1.Controls.Add(this.ITEMIDTextBox);
            this.panel1.Controls.Add(this.ITEMLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 113);
            this.panel1.TabIndex = 9;
            // 
            // TBLote
            // 
            this.TBLote.Location = new System.Drawing.Point(586, 62);
            this.TBLote.Name = "TBLote";
            this.TBLote.Size = new System.Drawing.Size(226, 20);
            this.TBLote.TabIndex = 180;
            // 
            // comboLote
            // 
            this.comboLote.DataSource = this.r_LISTALOTESINVENTARIOBindingSource;
            this.comboLote.DisplayMember = "VALOR";
            this.comboLote.FormattingEnabled = true;
            this.comboLote.Location = new System.Drawing.Point(586, 32);
            this.comboLote.Name = "comboLote";
            this.comboLote.Size = new System.Drawing.Size(226, 21);
            this.comboLote.TabIndex = 179;
            this.comboLote.ValueMember = "R_LISTALOTESINVENTARIO.VALOR";
            // 
            // r_LISTALOTESINVENTARIOBindingSource
            // 
            this.r_LISTALOTESINVENTARIOBindingSource.DataMember = "R_LISTALOTESINVENTARIO";
            this.r_LISTALOTESINVENTARIOBindingSource.DataSource = this.dSInventarioFisico2;
            // 
            // dSInventarioFisico2
            // 
            this.dSInventarioFisico2.DataSetName = "DSInventarioFisico2";
            this.dSInventarioFisico2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RBManualLote
            // 
            this.RBManualLote.AutoSize = true;
            this.RBManualLote.ForeColor = System.Drawing.Color.White;
            this.RBManualLote.Location = new System.Drawing.Point(483, 65);
            this.RBManualLote.Name = "RBManualLote";
            this.RBManualLote.Size = new System.Drawing.Size(60, 17);
            this.RBManualLote.TabIndex = 178;
            this.RBManualLote.Text = "Manual";
            this.RBManualLote.UseVisualStyleBackColor = true;
            // 
            // RBSeleccionLote
            // 
            this.RBSeleccionLote.AutoSize = true;
            this.RBSeleccionLote.Checked = true;
            this.RBSeleccionLote.ForeColor = System.Drawing.Color.White;
            this.RBSeleccionLote.Location = new System.Drawing.Point(483, 32);
            this.RBSeleccionLote.Name = "RBSeleccionLote";
            this.RBSeleccionLote.Size = new System.Drawing.Size(72, 17);
            this.RBSeleccionLote.TabIndex = 177;
            this.RBSeleccionLote.TabStop = true;
            this.RBSeleccionLote.Text = "Selección";
            this.RBSeleccionLote.UseVisualStyleBackColor = true;
            // 
            // ITEMButton
            // 
            this.ITEMButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(286, 59);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(21, 23);
            this.ITEMButton.TabIndex = 2;
            this.ITEMButton.UseVisualStyleBackColor = true;
            this.ITEMButton.Click += new System.EventHandler(this.ITEMButton_Click);
            // 
            // ITEMIDTextBox
            // 
            this.ITEMIDTextBox.BotonLookUp = null;
            this.ITEMIDTextBox.Condicion = null;
            this.ITEMIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbValue = null;
            this.ITEMIDTextBox.Format_Expression = null;
            this.ITEMIDTextBox.IndiceCampoDescripcion = 3;
            this.ITEMIDTextBox.IndiceCampoSelector = 1;
            this.ITEMIDTextBox.IndiceCampoValue = 0;
            this.ITEMIDTextBox.LabelDescription = this.ITEMLabel;
            this.ITEMIDTextBox.Location = new System.Drawing.Point(185, 60);
            this.ITEMIDTextBox.MostrarErrores = true;
            this.ITEMIDTextBox.Name = "ITEMIDTextBox";
            this.ITEMIDTextBox.NombreCampoSelector = "clave";
            this.ITEMIDTextBox.NombreCampoValue = "id";
            this.ITEMIDTextBox.Query = null;
            this.ITEMIDTextBox.QueryDeSeleccion = "select id, clave, nombre, descripcion from producto where  clave= @clave";
            this.ITEMIDTextBox.QueryPorDBValue = "select id, clave ,nombre, descripcion from producto where   id = @id";
            this.ITEMIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.ITEMIDTextBox.TabIndex = 1;
            this.ITEMIDTextBox.Tag = 34;
            this.ITEMIDTextBox.TextDescription = null;
            this.ITEMIDTextBox.Titulo = "Productos";
            this.ITEMIDTextBox.ValidarEntrada = true;
            this.ITEMIDTextBox.ValidationExpression = null;
            this.ITEMIDTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ITEMIDTextBox_Validating);
            // 
            // ITEMLabel
            // 
            this.ITEMLabel.AutoSize = true;
            this.ITEMLabel.ForeColor = System.Drawing.Color.White;
            this.ITEMLabel.Location = new System.Drawing.Point(313, 64);
            this.ITEMLabel.Name = "ITEMLabel";
            this.ITEMLabel.Size = new System.Drawing.Size(16, 13);
            this.ITEMLabel.TabIndex = 176;
            this.ITEMLabel.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(114, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 173;
            this.label4.Text = "Producto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "MOVIMIENTOS POR PRODUCTO Y LOTE";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(737, 88);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 23);
            this.BTEnviar.TabIndex = 7;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // r_LISTALOTESINVENTARIOTableAdapter
            // 
            this.r_LISTALOTESINVENTARIOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Inventario.DSInventarioFisico2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFMovimientosXProductoLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(885, 510);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFMovimientosXProductoLote";
            this.Text = "Movimientos por producto y lote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFMovimientosXProductoLote_FormClosing);
            this.Load += new System.EventHandler(this.WFMovimientosXProductoLote_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.r_LISTALOTESINVENTARIOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTEnviar;
        private FastReport.Preview.PreviewControl previewControl1;
        private FastReport.Report report1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ITEMButton;
        private Tools.TextBoxFB ITEMIDTextBox;
        private System.Windows.Forms.Label ITEMLabel;
        private System.Windows.Forms.TextBox TBLote;
        private System.Windows.Forms.ComboBox comboLote;
        private System.Windows.Forms.RadioButton RBManualLote;
        private System.Windows.Forms.RadioButton RBSeleccionLote;
        private Inventario.DSInventarioFisico2 dSInventarioFisico2;
        private System.Windows.Forms.BindingSource r_LISTALOTESINVENTARIOBindingSource;
        private Inventario.DSInventarioFisico2TableAdapters.R_LISTALOTESINVENTARIOTableAdapter r_LISTALOTESINVENTARIOTableAdapter;
        private Inventario.DSInventarioFisico2TableAdapters.TableAdapterManager tableAdapterManager;
    }
}