namespace iPos
{
    partial class WFActualizacionBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFActualizacionBD));
            this.progressBarUpdateDB = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtStateOfUpdate = new System.Windows.Forms.CheckedListBox();
            this.dbFixBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBarUpdateDB
            // 
            this.progressBarUpdateDB.Location = new System.Drawing.Point(26, 3);
            this.progressBarUpdateDB.Name = "progressBarUpdateDB";
            this.progressBarUpdateDB.Size = new System.Drawing.Size(339, 30);
            this.progressBarUpdateDB.TabIndex = 0;
            this.progressBarUpdateDB.Click += new System.EventHandler(this.progressBarUpdateDB_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.progressBarUpdateDB);
            this.panel1.Location = new System.Drawing.Point(20, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 43);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtStateOfUpdate);
            this.panel2.Location = new System.Drawing.Point(20, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 245);
            this.panel2.TabIndex = 3;
            // 
            // txtStateOfUpdate
            // 
            this.txtStateOfUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.txtStateOfUpdate.Enabled = false;
            this.txtStateOfUpdate.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStateOfUpdate.ForeColor = System.Drawing.Color.White;
            this.txtStateOfUpdate.FormattingEnabled = true;
            this.txtStateOfUpdate.Location = new System.Drawing.Point(26, 37);
            this.txtStateOfUpdate.Name = "txtStateOfUpdate";
            this.txtStateOfUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStateOfUpdate.Size = new System.Drawing.Size(338, 172);
            this.txtStateOfUpdate.TabIndex = 2;
            // 
            // dbFixBackgroundWorker
            // 
            this.dbFixBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dbFixBackgroundWorker_DoWork);
            this.dbFixBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dbFixBackgroundWorker_RunWorkerCompleted);
            // 
            // WFActualizacionBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(434, 330);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFActualizacionBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualización";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFActualizacionBD_FormClosing);
            this.Load += new System.EventHandler(this.WFActualizacionBD_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarUpdateDB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckedListBox txtStateOfUpdate;
        private System.ComponentModel.BackgroundWorker dbFixBackgroundWorker;
    }
}