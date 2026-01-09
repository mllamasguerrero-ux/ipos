namespace iPos
{
    partial class WFResumenMovilSync
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFResumenMovilSync));
            this.dSMovil = new iPos.Movil.DSMovil();
            this.eSTADOSYNCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eSTADOSYNCTableAdapter = new iPos.Movil.DSMovilTableAdapters.ESTADOSYNCTableAdapter();
            this.tableAdapterManager = new iPos.Movil.DSMovilTableAdapters.TableAdapterManager();
            this.eSTADOSYNCDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_FOLIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGENVIADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPROCESADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_DOCTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REENVIAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RECHECAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.VERIFICAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGHEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.progressBar03 = new System.Windows.Forms.ProgressBar();
            this.progressBar02 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.btnActualizarPrecios = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSTADOSYNCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSTADOSYNCDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSMovil
            // 
            this.dSMovil.DataSetName = "DSMovil";
            this.dSMovil.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eSTADOSYNCBindingSource
            // 
            this.eSTADOSYNCBindingSource.DataMember = "ESTADOSYNC";
            this.eSTADOSYNCBindingSource.DataSource = this.dSMovil;
            // 
            // eSTADOSYNCTableAdapter
            // 
            this.eSTADOSYNCTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Movil.DSMovilTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // eSTADOSYNCDataGridView
            // 
            this.eSTADOSYNCDataGridView.AllowUserToAddRows = false;
            this.eSTADOSYNCDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.eSTADOSYNCDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.eSTADOSYNCDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eSTADOSYNCDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.DG_FOLIO,
            this.DGENVIADO,
            this.DGPROCESADO,
            this.DG_DOCTOID,
            this.REENVIAR,
            this.RECHECAR,
            this.VERIFICAR,
            this.DGHEIGHT});
            this.eSTADOSYNCDataGridView.DataSource = this.eSTADOSYNCBindingSource;
            this.eSTADOSYNCDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eSTADOSYNCDataGridView.Location = new System.Drawing.Point(0, 0);
            this.eSTADOSYNCDataGridView.Name = "eSTADOSYNCDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.eSTADOSYNCDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.eSTADOSYNCDataGridView.RowHeadersVisible = false;
            this.eSTADOSYNCDataGridView.Size = new System.Drawing.Size(922, 310);
            this.eSTADOSYNCDataGridView.TabIndex = 1;
            this.eSTADOSYNCDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eSTADOSYNCDataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn3.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 75;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "HORA";
            this.dataGridViewTextBoxColumn4.HeaderText = "HORA";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 75;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn5.HeaderText = "CLIENTE";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 75;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn6.HeaderText = "NOMBRE CLIENTE";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 85;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "TOTAL";
            this.dataGridViewTextBoxColumn7.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 75;
            // 
            // DG_FOLIO
            // 
            this.DG_FOLIO.DataPropertyName = "FOLIO";
            this.DG_FOLIO.HeaderText = "FOLIO";
            this.DG_FOLIO.Name = "DG_FOLIO";
            // 
            // DGENVIADO
            // 
            this.DGENVIADO.DataPropertyName = "TRASLADOAFTP";
            this.DGENVIADO.HeaderText = "ENV.";
            this.DGENVIADO.Name = "DGENVIADO";
            this.DGENVIADO.Width = 50;
            // 
            // DGPROCESADO
            // 
            this.DGPROCESADO.DataPropertyName = "TRANREGSERVER";
            this.DGPROCESADO.HeaderText = "PROC.";
            this.DGPROCESADO.Name = "DGPROCESADO";
            this.DGPROCESADO.Width = 50;
            // 
            // DG_DOCTOID
            // 
            this.DG_DOCTOID.DataPropertyName = "DOCTOID";
            this.DG_DOCTOID.HeaderText = "DOCTOID";
            this.DG_DOCTOID.Name = "DG_DOCTOID";
            this.DG_DOCTOID.Visible = false;
            // 
            // REENVIAR
            // 
            this.REENVIAR.HeaderText = "";
            this.REENVIAR.Name = "REENVIAR";
            this.REENVIAR.Text = "ENVIAR";
            this.REENVIAR.UseColumnTextForButtonValue = true;
            this.REENVIAR.Width = 80;
            // 
            // RECHECAR
            // 
            this.RECHECAR.HeaderText = "";
            this.RECHECAR.Name = "RECHECAR";
            this.RECHECAR.Text = "RECHECAR";
            this.RECHECAR.UseColumnTextForButtonValue = true;
            this.RECHECAR.Width = 85;
            // 
            // VERIFICAR
            // 
            this.VERIFICAR.HeaderText = "";
            this.VERIFICAR.Name = "VERIFICAR";
            this.VERIFICAR.Text = "VERIF.";
            this.VERIFICAR.UseColumnTextForButtonValue = true;
            this.VERIFICAR.Width = 85;
            // 
            // DGHEIGHT
            // 
            dataGridViewCellStyle2.NullValue = " ";
            this.DGHEIGHT.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGHEIGHT.HeaderText = "";
            this.DGHEIGHT.Name = "DGHEIGHT";
            this.DGHEIGHT.ReadOnly = true;
            this.DGHEIGHT.Width = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // progressBar03
            // 
            this.progressBar03.Location = new System.Drawing.Point(659, 12);
            this.progressBar03.Name = "progressBar03";
            this.progressBar03.Size = new System.Drawing.Size(85, 23);
            this.progressBar03.TabIndex = 24;
            this.progressBar03.Visible = false;
            // 
            // progressBar02
            // 
            this.progressBar02.Location = new System.Drawing.Point(559, 12);
            this.progressBar02.Name = "progressBar02";
            this.progressBar02.Size = new System.Drawing.Size(94, 23);
            this.progressBar02.TabIndex = 25;
            this.progressBar02.Visible = false;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(751, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 26;
            this.progressBar1.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DOCTOID";
            this.dataGridViewTextBoxColumn1.HeaderText = "DOCTOID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn2.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TRANREGSERVER";
            this.dataGridViewTextBoxColumn8.HeaderText = "PROCESADO";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 75;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DOCTOID";
            this.dataGridViewTextBoxColumn9.HeaderText = "DOCTOID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "CHECAR PROCESO";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 80;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "RECHECAR";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Width = 80;
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.HeaderText = "";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.Text = "VERIFICAR DETALLE";
            this.dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            // 
            // button2
            // 
            this.button2.AccessibleDescription = "resizeforscreen";
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(264, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "Enviar todo lo pendiente";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnActualizarPrecios
            // 
            this.btnActualizarPrecios.AccessibleDescription = "resizeforscreen";
            this.btnActualizarPrecios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnActualizarPrecios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnActualizarPrecios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarPrecios.ForeColor = System.Drawing.Color.White;
            this.btnActualizarPrecios.Location = new System.Drawing.Point(107, 12);
            this.btnActualizarPrecios.Name = "btnActualizarPrecios";
            this.btnActualizarPrecios.Size = new System.Drawing.Size(123, 23);
            this.btnActualizarPrecios.TabIndex = 28;
            this.btnActualizarPrecios.Text = "Actualizar precios";
            this.btnActualizarPrecios.UseVisualStyleBackColor = false;
            this.btnActualizarPrecios.Click += new System.EventHandler(this.btnActualizarPrecios_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnActualizarPrecios);
            this.panel1.Controls.Add(this.progressBar03);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.progressBar02);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 52);
            this.panel1.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.eSTADOSYNCDataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(922, 310);
            this.panel2.TabIndex = 30;
            // 
            // WFResumenMovilSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(922, 362);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFResumenMovilSync";
            this.Text = "WFResumenMovilSync";
            this.Load += new System.EventHandler(this.WFResumenMovilSync_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSTADOSYNCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSTADOSYNCDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Movil.DSMovil dSMovil;
        private System.Windows.Forms.BindingSource eSTADOSYNCBindingSource;
        private Movil.DSMovilTableAdapters.ESTADOSYNCTableAdapter eSTADOSYNCTableAdapter;
        private Movil.DSMovilTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum eSTADOSYNCDataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        public System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.ProgressBar progressBar03;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.ProgressBar progressBar02;
        public System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnActualizarPrecios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_FOLIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGENVIADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPROCESADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_DOCTOID;
        private System.Windows.Forms.DataGridViewButtonColumn REENVIAR;
        private System.Windows.Forms.DataGridViewButtonColumn RECHECAR;
        private System.Windows.Forms.DataGridViewButtonColumn VERIFICAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGHEIGHT;
    }
}