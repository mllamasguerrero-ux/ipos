namespace iPos
{
    partial class WFDevolucionesAMatriz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFDevolucionesAMatriz));
            this.prBrTrasladosDevo = new System.Windows.Forms.ProgressBar();
            this.BTImportarTrasladosDevo = new System.Windows.Forms.Button();
            this.bgWorkTrasladosDevo = new System.ComponentModel.BackgroundWorker();
            this.prBrPedidosDevo = new System.Windows.Forms.ProgressBar();
            this.BTImportarPedidosDevo = new System.Windows.Forms.Button();
            this.bgWorkPedidosDevo = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // prBrTrasladosDevo
            // 
            this.prBrTrasladosDevo.Location = new System.Drawing.Point(345, 151);
            this.prBrTrasladosDevo.Name = "prBrTrasladosDevo";
            this.prBrTrasladosDevo.Size = new System.Drawing.Size(133, 23);
            this.prBrTrasladosDevo.TabIndex = 13;
            // 
            // BTImportarTrasladosDevo
            // 
            this.BTImportarTrasladosDevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImportarTrasladosDevo.ForeColor = System.Drawing.Color.White;
            this.BTImportarTrasladosDevo.Location = new System.Drawing.Point(344, 92);
            this.BTImportarTrasladosDevo.Name = "BTImportarTrasladosDevo";
            this.BTImportarTrasladosDevo.Size = new System.Drawing.Size(134, 52);
            this.BTImportarTrasladosDevo.TabIndex = 12;
            this.BTImportarTrasladosDevo.Text = "Importar devoluciones de traslados";
            this.BTImportarTrasladosDevo.UseVisualStyleBackColor = false;
            this.BTImportarTrasladosDevo.Click += new System.EventHandler(this.BTImportarTrasladosDevo_Click);
            // 
            // bgWorkTrasladosDevo
            // 
            this.bgWorkTrasladosDevo.WorkerReportsProgress = true;
            this.bgWorkTrasladosDevo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkTrasladosDevo_DoWork);
            this.bgWorkTrasladosDevo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkTrasladosDevo_RunWorkerCompleted);
            // 
            // prBrPedidosDevo
            // 
            this.prBrPedidosDevo.Location = new System.Drawing.Point(54, 151);
            this.prBrPedidosDevo.Name = "prBrPedidosDevo";
            this.prBrPedidosDevo.Size = new System.Drawing.Size(133, 23);
            this.prBrPedidosDevo.TabIndex = 15;
            // 
            // BTImportarPedidosDevo
            // 
            this.BTImportarPedidosDevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImportarPedidosDevo.ForeColor = System.Drawing.Color.White;
            this.BTImportarPedidosDevo.Location = new System.Drawing.Point(53, 92);
            this.BTImportarPedidosDevo.Name = "BTImportarPedidosDevo";
            this.BTImportarPedidosDevo.Size = new System.Drawing.Size(134, 52);
            this.BTImportarPedidosDevo.TabIndex = 14;
            this.BTImportarPedidosDevo.Text = "Importar pedidos de traslados";
            this.BTImportarPedidosDevo.UseVisualStyleBackColor = false;
            this.BTImportarPedidosDevo.Click += new System.EventHandler(this.BTImportarPedidosDevo_Click);
            // 
            // bgWorkPedidosDevo
            // 
            this.bgWorkPedidosDevo.WorkerReportsProgress = true;
            this.bgWorkPedidosDevo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkPedidosDevo_DoWork);
            this.bgWorkPedidosDevo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkPedidosDevo_RunWorkerCompleted);
            // 
            // WFDevolucionesAMatriz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(536, 261);
            this.Controls.Add(this.prBrPedidosDevo);
            this.Controls.Add(this.BTImportarPedidosDevo);
            this.Controls.Add(this.prBrTrasladosDevo);
            this.Controls.Add(this.BTImportarTrasladosDevo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFDevolucionesAMatriz";
            this.Text = "Devoluciones A Matriz";
            this.Load += new System.EventHandler(this.WFDevolucionesAMatriz_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prBrTrasladosDevo;
        private System.Windows.Forms.Button BTImportarTrasladosDevo;
        private System.ComponentModel.BackgroundWorker bgWorkTrasladosDevo;
        private System.Windows.Forms.ProgressBar prBrPedidosDevo;
        private System.Windows.Forms.Button BTImportarPedidosDevo;
        private System.ComponentModel.BackgroundWorker bgWorkPedidosDevo;
    }
}