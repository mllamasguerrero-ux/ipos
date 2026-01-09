namespace iPos.Exportaciones
{
    partial class WFExportarCubo
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
            this.CBCatalogos = new System.Windows.Forms.CheckBox();
            this.CBPersonas = new System.Windows.Forms.CheckBox();
            this.CBTransacciones = new System.Windows.Forms.CheckBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.DTPInicial = new System.Windows.Forms.DateTimePicker();
            this.DTPFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dSCubo = new iPos.Exportaciones.DSCubo();
            this.cUBOINFOVEDMEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cUBOINFOVEDMETableAdapter = new iPos.Exportaciones.DSCuboTableAdapters.CUBOINFOVEDMETableAdapter();
            this.tableAdapterManager = new iPos.Exportaciones.DSCuboTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.dSCubo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUBOINFOVEDMEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CBCatalogos
            // 
            this.CBCatalogos.AutoSize = true;
            this.CBCatalogos.BackColor = System.Drawing.Color.Transparent;
            this.CBCatalogos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBCatalogos.ForeColor = System.Drawing.Color.White;
            this.CBCatalogos.Location = new System.Drawing.Point(93, 70);
            this.CBCatalogos.Name = "CBCatalogos";
            this.CBCatalogos.Size = new System.Drawing.Size(82, 17);
            this.CBCatalogos.TabIndex = 0;
            this.CBCatalogos.Text = "Catalogos";
            this.CBCatalogos.UseVisualStyleBackColor = false;
            // 
            // CBPersonas
            // 
            this.CBPersonas.AutoSize = true;
            this.CBPersonas.BackColor = System.Drawing.Color.Transparent;
            this.CBPersonas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBPersonas.ForeColor = System.Drawing.Color.White;
            this.CBPersonas.Location = new System.Drawing.Point(93, 105);
            this.CBPersonas.Name = "CBPersonas";
            this.CBPersonas.Size = new System.Drawing.Size(151, 17);
            this.CBPersonas.TabIndex = 1;
            this.CBPersonas.Text = "Clientes y vendedores";
            this.CBPersonas.UseVisualStyleBackColor = false;
            // 
            // CBTransacciones
            // 
            this.CBTransacciones.AutoSize = true;
            this.CBTransacciones.BackColor = System.Drawing.Color.Transparent;
            this.CBTransacciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBTransacciones.ForeColor = System.Drawing.Color.White;
            this.CBTransacciones.Location = new System.Drawing.Point(93, 143);
            this.CBTransacciones.Name = "CBTransacciones";
            this.CBTransacciones.Size = new System.Drawing.Size(173, 17);
            this.CBTransacciones.TabIndex = 2;
            this.CBTransacciones.Text = "Ventas y Notas de credito";
            this.CBTransacciones.UseVisualStyleBackColor = false;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(130, 240);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 35);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "ENVIAR";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(93, 185);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(621, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(80, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Exportacion para cubo";
            // 
            // DTPInicial
            // 
            this.DTPInicial.Location = new System.Drawing.Point(317, 138);
            this.DTPInicial.Name = "DTPInicial";
            this.DTPInicial.Size = new System.Drawing.Size(200, 20);
            this.DTPInicial.TabIndex = 9;
            // 
            // DTPFinal
            // 
            this.DTPFinal.Location = new System.Drawing.Point(552, 138);
            this.DTPFinal.Name = "DTPFinal";
            this.DTPFinal.Size = new System.Drawing.Size(200, 20);
            this.DTPFinal.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(286, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "de ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(531, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "a";
            // 
            // dSCubo
            // 
            this.dSCubo.DataSetName = "DSCubo";
            this.dSCubo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cUBOINFOVEDMEBindingSource
            // 
            this.cUBOINFOVEDMEBindingSource.DataMember = "CUBOINFOVEDME";
            this.cUBOINFOVEDMEBindingSource.DataSource = this.dSCubo;
            // 
            // cUBOINFOVEDMETableAdapter
            // 
            this.cUBOINFOVEDMETableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Exportaciones.DSCuboTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFExportarCubo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(809, 292);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DTPFinal);
            this.Controls.Add(this.DTPInicial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.CBTransacciones);
            this.Controls.Add(this.CBPersonas);
            this.Controls.Add(this.CBCatalogos);
            this.Name = "WFExportarCubo";
            this.Text = "WFExportarCubo";
            this.Load += new System.EventHandler(this.WFExportarCubo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSCubo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUBOINFOVEDMEBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CBCatalogos;
        private System.Windows.Forms.CheckBox CBPersonas;
        private System.Windows.Forms.CheckBox CBTransacciones;
        private System.Windows.Forms.Button btnEnviar;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPInicial;
        private System.Windows.Forms.DateTimePicker DTPFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DSCubo dSCubo;
        private System.Windows.Forms.BindingSource cUBOINFOVEDMEBindingSource;
        private DSCuboTableAdapters.CUBOINFOVEDMETableAdapter cUBOINFOVEDMETableAdapter;
        private DSCuboTableAdapters.TableAdapterManager tableAdapterManager;
    }
}