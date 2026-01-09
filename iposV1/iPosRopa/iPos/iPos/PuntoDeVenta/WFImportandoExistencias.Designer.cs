namespace iPos
{
    partial class WFImportandoExistencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFImportandoExistencias));
            this.prBrExistencias = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.bgWorkExistencias = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // prBrExistencias
            // 
            this.prBrExistencias.Location = new System.Drawing.Point(24, 58);
            this.prBrExistencias.Name = "prBrExistencias";
            this.prBrExistencias.Size = new System.Drawing.Size(212, 23);
            this.prBrExistencias.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Importando existencias...";
            // 
            // bgWorkExistencias
            // 
            this.bgWorkExistencias.WorkerReportsProgress = true;
            this.bgWorkExistencias.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkExistencias_DoWork);
            this.bgWorkExistencias.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkExistencias_RunWorkerCompleted);
            // 
            // WFImportandoExistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(260, 133);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prBrExistencias);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFImportandoExistencias";
            this.Text = "Importando Existencias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prBrExistencias;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bgWorkExistencias;
    }
}