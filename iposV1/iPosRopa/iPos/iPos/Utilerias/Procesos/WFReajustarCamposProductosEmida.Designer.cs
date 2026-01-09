namespace iPos.Utilerias.Procesos
{
    partial class WFReajustarCamposProductosEmida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFReajustarCamposProductosEmida));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnReajustar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(55, 174);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(323, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnReajustar
            // 
            this.btnReajustar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnReajustar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnReajustar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReajustar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReajustar.ForeColor = System.Drawing.Color.White;
            this.btnReajustar.Location = new System.Drawing.Point(129, 52);
            this.btnReajustar.Name = "btnReajustar";
            this.btnReajustar.Size = new System.Drawing.Size(178, 61);
            this.btnReajustar.TabIndex = 2;
            this.btnReajustar.Text = "Reajustar campos productos emida";
            this.btnReajustar.UseVisualStyleBackColor = false;
            this.btnReajustar.Click += new System.EventHandler(this.btnReajustar_Click);
            // 
            // WFReajustarCamposProductosEmida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(432, 239);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnReajustar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFReajustarCamposProductosEmida";
            this.Text = "Reajustar Campos Productos Emida";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnReajustar;
    }
}