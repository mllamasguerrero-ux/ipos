namespace iPos.Mensajeria
{
    partial class WFLeerMensaje
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFLeerMensaje));
            this.messageWebBrowser = new System.Windows.Forms.WebBrowser();
            this.LBLFechaEnvio = new System.Windows.Forms.Label();
            this.LBLAsunto = new System.Windows.Forms.Label();
            this.dSMensajeria = new iPos.Mensajeria.DSMensajeria();
            this.datosAdjuntosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datosAdjuntosDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBREFTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dSMensajeria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosAdjuntosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosAdjuntosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // messageWebBrowser
            // 
            this.messageWebBrowser.Location = new System.Drawing.Point(15, 115);
            this.messageWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.messageWebBrowser.Name = "messageWebBrowser";
            this.messageWebBrowser.Size = new System.Drawing.Size(767, 266);
            this.messageWebBrowser.TabIndex = 0;
            // 
            // LBLFechaEnvio
            // 
            this.LBLFechaEnvio.AutoSize = true;
            this.LBLFechaEnvio.BackColor = System.Drawing.Color.Transparent;
            this.LBLFechaEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.LBLFechaEnvio.ForeColor = System.Drawing.Color.White;
            this.LBLFechaEnvio.Location = new System.Drawing.Point(12, 24);
            this.LBLFechaEnvio.Name = "LBLFechaEnvio";
            this.LBLFechaEnvio.Size = new System.Drawing.Size(49, 16);
            this.LBLFechaEnvio.TabIndex = 29;
            this.LBLFechaEnvio.Text = "Fecha:";
            // 
            // LBLAsunto
            // 
            this.LBLAsunto.AutoSize = true;
            this.LBLAsunto.BackColor = System.Drawing.Color.Transparent;
            this.LBLAsunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.LBLAsunto.ForeColor = System.Drawing.Color.White;
            this.LBLAsunto.Location = new System.Drawing.Point(12, 74);
            this.LBLAsunto.Name = "LBLAsunto";
            this.LBLAsunto.Size = new System.Drawing.Size(52, 16);
            this.LBLAsunto.TabIndex = 27;
            this.LBLAsunto.Text = "Asunto:";
            // 
            // dSMensajeria
            // 
            this.dSMensajeria.DataSetName = "DSMensajeria";
            this.dSMensajeria.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // datosAdjuntosBindingSource
            // 
            this.datosAdjuntosBindingSource.DataMember = "DatosAdjuntos";
            this.datosAdjuntosBindingSource.DataSource = this.dSMensajeria;
            // 
            // datosAdjuntosDataGridView
            // 
            this.datosAdjuntosDataGridView.AllowUserToAddRows = false;
            this.datosAdjuntosDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datosAdjuntosDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datosAdjuntosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datosAdjuntosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NOMBRE,
            this.dataGridViewTextBoxColumn2,
            this.NOMBREFTP});
            this.datosAdjuntosDataGridView.DataSource = this.datosAdjuntosBindingSource;
            this.datosAdjuntosDataGridView.Location = new System.Drawing.Point(15, 413);
            this.datosAdjuntosDataGridView.Name = "datosAdjuntosDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datosAdjuntosDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datosAdjuntosDataGridView.RowHeadersVisible = false;
            this.datosAdjuntosDataGridView.Size = new System.Drawing.Size(767, 156);
            this.datosAdjuntosDataGridView.TabIndex = 31;
            this.datosAdjuntosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datosAdjuntosDataGridView_CellContentClick);
            // 
            // NOMBRE
            // 
            this.NOMBRE.DataPropertyName = "NOMBRE";
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "RUTA";
            this.dataGridViewTextBoxColumn2.HeaderText = "RUTA";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 400;
            // 
            // NOMBREFTP
            // 
            this.NOMBREFTP.DataPropertyName = "NOMBREFTP";
            this.NOMBREFTP.HeaderText = "NOMBREFTP";
            this.NOMBREFTP.Name = "NOMBREFTP";
            this.NOMBREFTP.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NOMBREFTP";
            this.dataGridViewTextBoxColumn3.HeaderText = "NOMBREFTP";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 400;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "RUTA";
            this.dataGridViewTextBoxColumn4.HeaderText = "RUTA";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 400;
            // 
            // WFLeerMensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(806, 584);
            this.Controls.Add(this.datosAdjuntosDataGridView);
            this.Controls.Add(this.LBLFechaEnvio);
            this.Controls.Add(this.LBLAsunto);
            this.Controls.Add(this.messageWebBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFLeerMensaje";
            this.Text = "Leer Mensaje";
            this.Load += new System.EventHandler(this.WFLeerMensaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSMensajeria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosAdjuntosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosAdjuntosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser messageWebBrowser;
        private System.Windows.Forms.Label LBLFechaEnvio;
        private System.Windows.Forms.Label LBLAsunto;
        private DSMensajeria dSMensajeria;
        private System.Windows.Forms.BindingSource datosAdjuntosBindingSource;
        private System.Windows.Forms.DataGridViewSum datosAdjuntosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBREFTP;
    }
}