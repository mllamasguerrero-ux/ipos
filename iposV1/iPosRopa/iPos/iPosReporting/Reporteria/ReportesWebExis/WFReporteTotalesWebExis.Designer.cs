namespace iPosReporting.ReportesWebExis
{
    partial class WFReporteTotalesWebExis
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.BTWebExisPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TBDBFPath = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.eXISTENCIAWEBEXISBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSWebExis = new iPosReporting.Reporteria.ReportesWebExis.DSWebExis();
            this.eXISTENCIAWEBEXISTableAdapter = new iPosReporting.Reporteria.ReportesWebExis.DSWebExisTableAdapters.EXISTENCIAWEBEXISTableAdapter();
            this.tableAdapterManager = new iPosReporting.Reporteria.ReportesWebExis.DSWebExisTableAdapters.TableAdapterManager();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eXISTENCIAWEBEXISBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSWebExis)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnGenerarReporte);
            this.panel1.Controls.Add(this.BTWebExisPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TBDBFPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 84);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(385, 24);
            this.btnGenerarReporte.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(106, 32);
            this.btnGenerarReporte.TabIndex = 16;
            this.btnGenerarReporte.Text = "Generar reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // BTWebExisPath
            // 
            this.BTWebExisPath.Location = new System.Drawing.Point(271, 29);
            this.BTWebExisPath.Margin = new System.Windows.Forms.Padding(2);
            this.BTWebExisPath.Name = "BTWebExisPath";
            this.BTWebExisPath.Size = new System.Drawing.Size(56, 32);
            this.BTWebExisPath.TabIndex = 15;
            this.BTWebExisPath.Text = "Explorar";
            this.BTWebExisPath.UseVisualStyleBackColor = true;
            this.BTWebExisPath.Click += new System.EventHandler(this.BTWebExisPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Seleccione el archivo Web Exis:";
            // 
            // TBDBFPath
            // 
            this.TBDBFPath.Location = new System.Drawing.Point(52, 36);
            this.TBDBFPath.Margin = new System.Windows.Forms.Padding(2);
            this.TBDBFPath.Name = "TBDBFPath";
            this.TBDBFPath.Size = new System.Drawing.Size(207, 20);
            this.TBDBFPath.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.previewControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(947, 282);
            this.panel2.TabIndex = 1;
            // 
            // previewControl1
            // 
            this.previewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.previewControl1.Location = new System.Drawing.Point(0, 0);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.previewControl1.SaveInitialDirectory = null;
            this.previewControl1.Size = new System.Drawing.Size(947, 282);
            this.previewControl1.TabIndex = 1;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // eXISTENCIAWEBEXISBindingSource
            // 
            this.eXISTENCIAWEBEXISBindingSource.DataMember = "EXISTENCIAWEBEXIS";
            this.eXISTENCIAWEBEXISBindingSource.DataSource = this.dSWebExis;
            // 
            // dSWebExis
            // 
            this.dSWebExis.DataSetName = "DSWebExis";
            this.dSWebExis.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eXISTENCIAWEBEXISTableAdapter
            // 
            this.eXISTENCIAWEBEXISTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPosReporting.Reporteria.ReportesWebExis.DSWebExisTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFReporteTotalesWebExis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(947, 366);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WFReporteTotalesWebExis";
            this.Text = "REPORTES";
            this.Load += new System.EventHandler(this.WFReporteTotalesWebExis_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eXISTENCIAWEBEXISBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSWebExis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BTWebExisPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBDBFPath;
        private System.Windows.Forms.Button btnGenerarReporte;
        private FastReport.Preview.PreviewControl previewControl1;
        private Reporteria.ReportesWebExis.DSWebExis dSWebExis;
        private System.Windows.Forms.BindingSource eXISTENCIAWEBEXISBindingSource;
        private Reporteria.ReportesWebExis.DSWebExisTableAdapters.EXISTENCIAWEBEXISTableAdapter eXISTENCIAWEBEXISTableAdapter;
        private Reporteria.ReportesWebExis.DSWebExisTableAdapters.TableAdapterManager tableAdapterManager;
    }
}