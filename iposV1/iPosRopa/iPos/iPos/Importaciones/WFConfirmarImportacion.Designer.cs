namespace iPos.Importaciones
{
    partial class WFConfirmarImportacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFConfirmarImportacion));
            this.mainMessageLabel = new System.Windows.Forms.Label();
            this.secondaryMessageLabel = new System.Windows.Forms.Label();
            this.counterLabel = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.importBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // mainMessageLabel
            // 
            this.mainMessageLabel.AutoSize = true;
            this.mainMessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.mainMessageLabel.ForeColor = System.Drawing.Color.White;
            this.mainMessageLabel.Location = new System.Drawing.Point(92, 32);
            this.mainMessageLabel.Name = "mainMessageLabel";
            this.mainMessageLabel.Size = new System.Drawing.Size(234, 13);
            this.mainMessageLabel.TabIndex = 0;
            this.mainMessageLabel.Text = "Se han encontrado nuevos catalogos a importar";
            // 
            // secondaryMessageLabel
            // 
            this.secondaryMessageLabel.AutoSize = true;
            this.secondaryMessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.secondaryMessageLabel.ForeColor = System.Drawing.Color.White;
            this.secondaryMessageLabel.Location = new System.Drawing.Point(92, 69);
            this.secondaryMessageLabel.Name = "secondaryMessageLabel";
            this.secondaryMessageLabel.Size = new System.Drawing.Size(90, 13);
            this.secondaryMessageLabel.TabIndex = 1;
            this.secondaryMessageLabel.Text = "Se importaran en:";
            // 
            // counterLabel
            // 
            this.counterLabel.AutoSize = true;
            this.counterLabel.BackColor = System.Drawing.Color.Transparent;
            this.counterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterLabel.ForeColor = System.Drawing.Color.White;
            this.counterLabel.Location = new System.Drawing.Point(298, 64);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(27, 20);
            this.counterLabel.TabIndex = 2;
            this.counterLabel.Text = "30";
            // 
            // acceptButton
            // 
            this.acceptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.acceptButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.acceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptButton.ForeColor = System.Drawing.Color.White;
            this.acceptButton.Location = new System.Drawing.Point(95, 126);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 3;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = false;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Firebrick;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(250, 126);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(188, 62);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // importBackgroundWorker
            // 
            this.importBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.importBackgroundWorker_DoWork);
            this.importBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.importBackgroundWorker_RunWorkerCompleted);
            // 
            // WFConfirmarImportacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(420, 175);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.counterLabel);
            this.Controls.Add(this.secondaryMessageLabel);
            this.Controls.Add(this.mainMessageLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFConfirmarImportacion";
            this.Text = "Notificación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFConfirmarImportacion_FormClosing);
            this.Load += new System.EventHandler(this.WFConfirmarImportacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainMessageLabel;
        private System.Windows.Forms.Label secondaryMessageLabel;
        private System.Windows.Forms.Label counterLabel;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker importBackgroundWorker;
    }
}