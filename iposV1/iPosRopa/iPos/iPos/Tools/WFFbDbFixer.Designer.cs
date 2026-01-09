namespace iPos.Tools
{
    partial class WFFbDbFixer
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
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.loadingMsgLabel = new System.Windows.Forms.Label();
            this.dbFixerBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Location = new System.Drawing.Point(90, 142);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(100, 23);
            this.loadingProgressBar.TabIndex = 0;
            // 
            // loadingMsgLabel
            // 
            this.loadingMsgLabel.AutoSize = true;
            this.loadingMsgLabel.BackColor = System.Drawing.Color.Transparent;
            this.loadingMsgLabel.Location = new System.Drawing.Point(87, 99);
            this.loadingMsgLabel.Name = "loadingMsgLabel";
            this.loadingMsgLabel.Size = new System.Drawing.Size(35, 13);
            this.loadingMsgLabel.TabIndex = 1;
            this.loadingMsgLabel.Text = "label1";
            // 
            // dbFixerBackgroundWorker
            // 
            this.dbFixerBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dbFixerBackgroundWorker_DoWork);
            this.dbFixerBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.dbFixerBackgroundWorker_ProgressChanged);
            this.dbFixerBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dbFixerBackgroundWorker_RunWorkerCompleted);
            // 
            // WFFbDbFixer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_4;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.loadingMsgLabel);
            this.Controls.Add(this.loadingProgressBar);
            this.Name = "WFFbDbFixer";
            this.Text = "Espere";
            this.Load += new System.EventHandler(this.LoadingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar loadingProgressBar;
        private System.Windows.Forms.Label loadingMsgLabel;
        private System.ComponentModel.BackgroundWorker dbFixerBackgroundWorker;
    }
}