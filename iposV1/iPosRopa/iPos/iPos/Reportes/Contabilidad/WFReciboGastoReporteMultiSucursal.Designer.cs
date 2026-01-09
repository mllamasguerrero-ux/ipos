namespace iPos
{
    partial class WFReciboGastoReporteMultiSucursal
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
            System.Windows.Forms.Label mARCAIDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFReciboGastoReporteMultiSucursal));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBTodosGastos = new System.Windows.Forms.CheckBox();
            this.GASTOButton = new System.Windows.Forms.Button();
            this.GASTOIDTextBox = new iPos.Tools.TextBoxFB();
            this.GASTOLabel = new System.Windows.Forms.Label();
            this.ITEMButton = new System.Windows.Forms.Button();
            this.ITEMIDTextBox = new iPos.Tools.TextBoxFB();
            this.ITEMLabel = new System.Windows.Forms.Label();
            this.CBTotalizado = new System.Windows.Forms.CheckBox();
            this.CBTodas = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.report1 = new FastReport.Report();
            mARCAIDLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // mARCAIDLabel
            // 
            mARCAIDLabel.AutoSize = true;
            mARCAIDLabel.BackColor = System.Drawing.Color.Transparent;
            mARCAIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mARCAIDLabel.ForeColor = System.Drawing.Color.White;
            mARCAIDLabel.Location = new System.Drawing.Point(154, 117);
            mARCAIDLabel.Name = "mARCAIDLabel";
            mARCAIDLabel.Size = new System.Drawing.Size(44, 13);
            mARCAIDLabel.TabIndex = 179;
            mARCAIDLabel.Text = "Gasto:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 150);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 360);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.previewControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(877, 334);
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
            this.previewControl1.Size = new System.Drawing.Size(871, 328);
            this.previewControl1.TabIndex = 0;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.CBTodosGastos);
            this.panel1.Controls.Add(this.GASTOButton);
            this.panel1.Controls.Add(this.GASTOIDTextBox);
            this.panel1.Controls.Add(this.GASTOLabel);
            this.panel1.Controls.Add(mARCAIDLabel);
            this.panel1.Controls.Add(this.ITEMButton);
            this.panel1.Controls.Add(this.ITEMIDTextBox);
            this.panel1.Controls.Add(this.ITEMLabel);
            this.panel1.Controls.Add(this.CBTotalizado);
            this.panel1.Controls.Add(this.CBTodas);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Controls.Add(this.DTPFrom);
            this.panel1.Controls.Add(this.DTPTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 150);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CBTodosGastos
            // 
            this.CBTodosGastos.AutoSize = true;
            this.CBTodosGastos.ForeColor = System.Drawing.Color.White;
            this.CBTodosGastos.Location = new System.Drawing.Point(523, 113);
            this.CBTodosGastos.Name = "CBTodosGastos";
            this.CBTodosGastos.Size = new System.Drawing.Size(56, 17);
            this.CBTodosGastos.TabIndex = 181;
            this.CBTodosGastos.Text = "Todos";
            this.CBTodosGastos.UseVisualStyleBackColor = true;
            // 
            // GASTOButton
            // 
            this.GASTOButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.GASTOButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GASTOButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GASTOButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.GASTOButton.Location = new System.Drawing.Point(310, 112);
            this.GASTOButton.Name = "GASTOButton";
            this.GASTOButton.Size = new System.Drawing.Size(23, 23);
            this.GASTOButton.TabIndex = 178;
            this.GASTOButton.UseVisualStyleBackColor = true;
            // 
            // GASTOIDTextBox
            // 
            this.GASTOIDTextBox.BotonLookUp = this.GASTOButton;
            this.GASTOIDTextBox.Condicion = null;
            this.GASTOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GASTOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GASTOIDTextBox.DbValue = null;
            this.GASTOIDTextBox.Format_Expression = null;
            this.GASTOIDTextBox.IndiceCampoDescripcion = 2;
            this.GASTOIDTextBox.IndiceCampoSelector = 1;
            this.GASTOIDTextBox.IndiceCampoValue = 1;
            this.GASTOIDTextBox.LabelDescription = this.GASTOLabel;
            this.GASTOIDTextBox.Location = new System.Drawing.Point(205, 112);
            this.GASTOIDTextBox.MostrarErrores = true;
            this.GASTOIDTextBox.Name = "GASTOIDTextBox";
            this.GASTOIDTextBox.NombreCampoSelector = "clave";
            this.GASTOIDTextBox.NombreCampoValue = "clave";
            this.GASTOIDTextBox.Query = "select id,clave,nombre from gasto";
            this.GASTOIDTextBox.QueryDeSeleccion = "select id,clave,nombre from gasto where clave = @clave";
            this.GASTOIDTextBox.QueryPorDBValue = "select id,clave,nombre from gasto where id = @id";
            this.GASTOIDTextBox.Size = new System.Drawing.Size(99, 20);
            this.GASTOIDTextBox.TabIndex = 177;
            this.GASTOIDTextBox.Tag = 34;
            this.GASTOIDTextBox.TextDescription = null;
            this.GASTOIDTextBox.Titulo = "Gastos";
            this.GASTOIDTextBox.ValidarEntrada = true;
            this.GASTOIDTextBox.ValidationExpression = null;
            // 
            // GASTOLabel
            // 
            this.GASTOLabel.AutoSize = true;
            this.GASTOLabel.BackColor = System.Drawing.Color.Transparent;
            this.GASTOLabel.ForeColor = System.Drawing.Color.White;
            this.GASTOLabel.Location = new System.Drawing.Point(337, 118);
            this.GASTOLabel.Name = "GASTOLabel";
            this.GASTOLabel.Size = new System.Drawing.Size(16, 13);
            this.GASTOLabel.TabIndex = 180;
            this.GASTOLabel.Text = "...";
            // 
            // ITEMButton
            // 
            this.ITEMButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(310, 37);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(23, 23);
            this.ITEMButton.TabIndex = 2;
            this.ITEMButton.UseVisualStyleBackColor = true;
            // 
            // ITEMIDTextBox
            // 
            this.ITEMIDTextBox.BotonLookUp = this.ITEMButton;
            this.ITEMIDTextBox.Condicion = null;
            this.ITEMIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbValue = null;
            this.ITEMIDTextBox.Format_Expression = null;
            this.ITEMIDTextBox.IndiceCampoDescripcion = 2;
            this.ITEMIDTextBox.IndiceCampoSelector = 1;
            this.ITEMIDTextBox.IndiceCampoValue = 1;
            this.ITEMIDTextBox.LabelDescription = this.ITEMLabel;
            this.ITEMIDTextBox.Location = new System.Drawing.Point(209, 38);
            this.ITEMIDTextBox.MostrarErrores = true;
            this.ITEMIDTextBox.Name = "ITEMIDTextBox";
            this.ITEMIDTextBox.NombreCampoSelector = "clave";
            this.ITEMIDTextBox.NombreCampoValue = "clave";
            this.ITEMIDTextBox.Query = "select id, clave, nombre from sucursal where ACTIVO = \'S\'";
            this.ITEMIDTextBox.QueryDeSeleccion = "select id, clave, nombre from sucursal where ACTIVO = \'S\'  and  clave= @clave";
            this.ITEMIDTextBox.QueryPorDBValue = "select id, clave, nombre from sucursal where ACTIVO = \'S\' and  id = @id";
            this.ITEMIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.ITEMIDTextBox.TabIndex = 1;
            this.ITEMIDTextBox.Tag = 34;
            this.ITEMIDTextBox.TextDescription = null;
            this.ITEMIDTextBox.Titulo = "Sucursales";
            this.ITEMIDTextBox.ValidarEntrada = true;
            this.ITEMIDTextBox.ValidationExpression = null;
            // 
            // ITEMLabel
            // 
            this.ITEMLabel.AutoSize = true;
            this.ITEMLabel.ForeColor = System.Drawing.Color.White;
            this.ITEMLabel.Location = new System.Drawing.Point(337, 42);
            this.ITEMLabel.Name = "ITEMLabel";
            this.ITEMLabel.Size = new System.Drawing.Size(16, 13);
            this.ITEMLabel.TabIndex = 176;
            this.ITEMLabel.Text = "...";
            // 
            // CBTotalizado
            // 
            this.CBTotalizado.AutoSize = true;
            this.CBTotalizado.ForeColor = System.Drawing.Color.White;
            this.CBTotalizado.Location = new System.Drawing.Point(686, 40);
            this.CBTotalizado.Name = "CBTotalizado";
            this.CBTotalizado.Size = new System.Drawing.Size(75, 17);
            this.CBTotalizado.TabIndex = 4;
            this.CBTotalizado.Text = "Totalizado";
            this.CBTotalizado.UseVisualStyleBackColor = true;
            // 
            // CBTodas
            // 
            this.CBTodas.AutoSize = true;
            this.CBTodas.ForeColor = System.Drawing.Color.White;
            this.CBTodas.Location = new System.Drawing.Point(523, 38);
            this.CBTodas.Name = "CBTodas";
            this.CBTodas.Size = new System.Drawing.Size(56, 17);
            this.CBTodas.TabIndex = 3;
            this.CBTodas.Text = "Todos";
            this.CBTodas.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(139, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 173;
            this.label4.Text = "Sucursal:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "GASTOS MULTISUCURSAL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(151, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(673, 108);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(88, 28);
            this.BTEnviar.TabIndex = 7;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // DTPFrom
            // 
            this.DTPFrom.Location = new System.Drawing.Point(205, 76);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(200, 20);
            this.DTPFrom.TabIndex = 5;
            // 
            // DTPTo
            // 
            this.DTPTo.Location = new System.Drawing.Point(561, 76);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(200, 20);
            this.DTPTo.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(520, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "a:";
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // WFReciboGastoReporteMultiSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(885, 510);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFReciboGastoReporteMultiSucursal";
            this.Text = "Reporte de Gastos MultiSucursal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFReciboGastoReporteMultiSucursal_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private FastReport.Preview.PreviewControl previewControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox CBTodosGastos;
        private System.Windows.Forms.Button GASTOButton;
        private Tools.TextBoxFB GASTOIDTextBox;
        private System.Windows.Forms.Label GASTOLabel;
        private System.Windows.Forms.Button ITEMButton;
        private Tools.TextBoxFB ITEMIDTextBox;
        private System.Windows.Forms.Label ITEMLabel;
        private System.Windows.Forms.CheckBox CBTotalizado;
        private System.Windows.Forms.CheckBox CBTodas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.Label label2;
        private FastReport.Report report1;
    }
}