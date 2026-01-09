namespace iPos
{
    partial class WFExportacionFinalMovil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFExportacionFinalMovil));
            this.checkBox0 = new System.Windows.Forms.CheckBox();
            this.progressBar00 = new System.Windows.Forms.ProgressBar();
            this.lblAbonos = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker0 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkBoxA = new System.Windows.Forms.CheckBox();
            this.progressBar0A = new System.Windows.Forms.ProgressBar();
            this.lblExportacionVentas = new System.Windows.Forms.Label();
            this.backgroundWorkerA = new System.ComponentModel.BackgroundWorker();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.progressBar02 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CBFinalizarCobranza = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CBFinalizarVenta = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GBProgreso = new System.Windows.Forms.GroupBox();
            this.lblVisitas = new System.Windows.Forms.Label();
            this.progressBar03 = new System.Windows.Forms.ProgressBar();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.GBProgreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox0
            // 
            this.checkBox0.AutoSize = true;
            this.checkBox0.Checked = true;
            this.checkBox0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox0.Location = new System.Drawing.Point(55, 118);
            this.checkBox0.Name = "checkBox0";
            this.checkBox0.Size = new System.Drawing.Size(15, 14);
            this.checkBox0.TabIndex = 26;
            this.checkBox0.UseVisualStyleBackColor = true;
            this.checkBox0.Visible = false;
            // 
            // progressBar00
            // 
            this.progressBar00.Location = new System.Drawing.Point(263, 108);
            this.progressBar00.Name = "progressBar00";
            this.progressBar00.Size = new System.Drawing.Size(132, 23);
            this.progressBar00.TabIndex = 25;
            // 
            // lblAbonos
            // 
            this.lblAbonos.AutoSize = true;
            this.lblAbonos.BackColor = System.Drawing.Color.Transparent;
            this.lblAbonos.ForeColor = System.Drawing.Color.White;
            this.lblAbonos.Location = new System.Drawing.Point(90, 118);
            this.lblAbonos.Name = "lblAbonos";
            this.lblAbonos.Size = new System.Drawing.Size(116, 13);
            this.lblAbonos.TabIndex = 24;
            this.lblAbonos.Text = "Exportación de abonos";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(263, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Procesar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "FINALIZACIÓN MOVIL";
            // 
            // backgroundWorker0
            // 
            this.backgroundWorker0.WorkerReportsProgress = true;
            this.backgroundWorker0.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker0.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // checkBoxA
            // 
            this.checkBoxA.AutoSize = true;
            this.checkBoxA.Checked = true;
            this.checkBoxA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxA.Location = new System.Drawing.Point(55, 79);
            this.checkBoxA.Name = "checkBoxA";
            this.checkBoxA.Size = new System.Drawing.Size(15, 14);
            this.checkBoxA.TabIndex = 30;
            this.checkBoxA.UseVisualStyleBackColor = true;
            this.checkBoxA.Visible = false;
            // 
            // progressBar0A
            // 
            this.progressBar0A.Location = new System.Drawing.Point(263, 69);
            this.progressBar0A.Name = "progressBar0A";
            this.progressBar0A.Size = new System.Drawing.Size(132, 23);
            this.progressBar0A.TabIndex = 29;
            // 
            // lblExportacionVentas
            // 
            this.lblExportacionVentas.AutoSize = true;
            this.lblExportacionVentas.BackColor = System.Drawing.Color.Transparent;
            this.lblExportacionVentas.ForeColor = System.Drawing.Color.White;
            this.lblExportacionVentas.Location = new System.Drawing.Point(93, 79);
            this.lblExportacionVentas.Name = "lblExportacionVentas";
            this.lblExportacionVentas.Size = new System.Drawing.Size(113, 13);
            this.lblExportacionVentas.TabIndex = 28;
            this.lblExportacionVentas.Text = "Exportación de ventas";
            // 
            // backgroundWorkerA
            // 
            this.backgroundWorkerA.WorkerReportsProgress = true;
            this.backgroundWorkerA.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorkerA.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(55, 40);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 33;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // progressBar02
            // 
            this.progressBar02.Location = new System.Drawing.Point(263, 30);
            this.progressBar02.Name = "progressBar02";
            this.progressBar02.Size = new System.Drawing.Size(132, 23);
            this.progressBar02.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(93, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Exportación de clientes";
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.CBFinalizarCobranza);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CBFinalizarVenta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 88);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "¿QUE DESEA CERRAR?";
            // 
            // CBFinalizarCobranza
            // 
            this.CBFinalizarCobranza.AutoSize = true;
            this.CBFinalizarCobranza.Location = new System.Drawing.Point(205, 60);
            this.CBFinalizarCobranza.Name = "CBFinalizarCobranza";
            this.CBFinalizarCobranza.Size = new System.Drawing.Size(15, 14);
            this.CBFinalizarCobranza.TabIndex = 34;
            this.CBFinalizarCobranza.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(44, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Finalización de cobranza";
            // 
            // CBFinalizarVenta
            // 
            this.CBFinalizarVenta.AutoSize = true;
            this.CBFinalizarVenta.Location = new System.Drawing.Point(205, 30);
            this.CBFinalizarVenta.Name = "CBFinalizarVenta";
            this.CBFinalizarVenta.Size = new System.Drawing.Size(15, 14);
            this.CBFinalizarVenta.TabIndex = 32;
            this.CBFinalizarVenta.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(56, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Finalización de ventas";
            // 
            // GBProgreso
            // 
            this.GBProgreso.BackColor = System.Drawing.Color.Transparent;
            this.GBProgreso.Controls.Add(this.lblVisitas);
            this.GBProgreso.Controls.Add(this.progressBar03);
            this.GBProgreso.Controls.Add(this.checkBox3);
            this.GBProgreso.Controls.Add(this.checkBoxA);
            this.GBProgreso.Controls.Add(this.checkBox2);
            this.GBProgreso.Controls.Add(this.progressBar02);
            this.GBProgreso.Controls.Add(this.label1);
            this.GBProgreso.Controls.Add(this.lblAbonos);
            this.GBProgreso.Controls.Add(this.progressBar00);
            this.GBProgreso.Controls.Add(this.progressBar0A);
            this.GBProgreso.Controls.Add(this.checkBox0);
            this.GBProgreso.Controls.Add(this.lblExportacionVentas);
            this.GBProgreso.ForeColor = System.Drawing.Color.White;
            this.GBProgreso.Location = new System.Drawing.Point(12, 148);
            this.GBProgreso.Name = "GBProgreso";
            this.GBProgreso.Size = new System.Drawing.Size(406, 200);
            this.GBProgreso.TabIndex = 35;
            this.GBProgreso.TabStop = false;
            this.GBProgreso.Text = "PROGRESO";
            this.GBProgreso.Enter += new System.EventHandler(this.GBProgreso_Enter);
            // 
            // lblVisitas
            // 
            this.lblVisitas.AutoSize = true;
            this.lblVisitas.BackColor = System.Drawing.Color.Transparent;
            this.lblVisitas.ForeColor = System.Drawing.Color.White;
            this.lblVisitas.Location = new System.Drawing.Point(90, 157);
            this.lblVisitas.Name = "lblVisitas";
            this.lblVisitas.Size = new System.Drawing.Size(110, 13);
            this.lblVisitas.TabIndex = 34;
            this.lblVisitas.Text = "Exportación de visitas";
            // 
            // progressBar03
            // 
            this.progressBar03.Location = new System.Drawing.Point(263, 147);
            this.progressBar03.Name = "progressBar03";
            this.progressBar03.Size = new System.Drawing.Size(132, 23);
            this.progressBar03.TabIndex = 35;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(55, 157);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 36;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // WFExportacionFinalMovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(449, 360);
            this.Controls.Add(this.GBProgreso);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFExportacionFinalMovil";
            this.Text = "WFExportacionFinalMovil";
            this.Load += new System.EventHandler(this.WFExportacionFinalMovil_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GBProgreso.ResumeLayout(false);
            this.GBProgreso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox0;
        private System.Windows.Forms.ProgressBar progressBar00;
        private System.Windows.Forms.Label lblAbonos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        public System.ComponentModel.BackgroundWorker backgroundWorker0;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox checkBoxA;
        private System.Windows.Forms.ProgressBar progressBar0A;
        private System.Windows.Forms.Label lblExportacionVentas;
        public System.ComponentModel.BackgroundWorker backgroundWorkerA;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ProgressBar progressBar02;
        private System.Windows.Forms.Label label1;
        public System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CBFinalizarCobranza;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CBFinalizarVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GBProgreso;
        public System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Label lblVisitas;
        private System.Windows.Forms.ProgressBar progressBar03;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}