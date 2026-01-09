namespace iPos.Tools
{
    partial class Clock
    {
        
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblClockText = new System.Windows.Forms.Label();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            
            
            
            this.lblClockText.AutoSize = true;
            this.lblClockText.Location = new System.Drawing.Point(16, 6);
            this.lblClockText.Name = "lblClockText";
            this.lblClockText.Size = new System.Drawing.Size(58, 13);
            this.lblClockText.TabIndex = 0;
            this.lblClockText.Text = "Clock Text";
            
            
            
            this.tmrRefresh.Interval = 500;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            
            
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblClockText);
            this.Name = "Clock";
            this.Size = new System.Drawing.Size(136, 25);
            this.Load += new System.EventHandler(this.Clock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Label lblClockText;
        private System.Windows.Forms.Timer tmrRefresh;
    }
}
