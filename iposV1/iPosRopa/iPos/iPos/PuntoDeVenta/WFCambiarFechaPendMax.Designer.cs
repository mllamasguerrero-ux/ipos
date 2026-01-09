namespace iPos
{
    partial class WFCambiarFechaPendMax
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFCambiarFechaPendMax));
            this.dtpFechaPendMax = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbFechaDocumento = new System.Windows.Forms.Label();
            this.lbDiasMax = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpFechaPendMax
            // 
            this.dtpFechaPendMax.Location = new System.Drawing.Point(218, 157);
            this.dtpFechaPendMax.Name = "dtpFechaPendMax";
            this.dtpFechaPendMax.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaPendMax.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(38, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha pendiente maxima";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(38, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha documento:";
            // 
            // lbFechaDocumento
            // 
            this.lbFechaDocumento.AutoSize = true;
            this.lbFechaDocumento.BackColor = System.Drawing.Color.Transparent;
            this.lbFechaDocumento.ForeColor = System.Drawing.Color.White;
            this.lbFechaDocumento.Location = new System.Drawing.Point(215, 84);
            this.lbFechaDocumento.Name = "lbFechaDocumento";
            this.lbFechaDocumento.Size = new System.Drawing.Size(16, 13);
            this.lbFechaDocumento.TabIndex = 3;
            this.lbFechaDocumento.Text = "...";
            // 
            // lbDiasMax
            // 
            this.lbDiasMax.AutoSize = true;
            this.lbDiasMax.BackColor = System.Drawing.Color.Transparent;
            this.lbDiasMax.ForeColor = System.Drawing.Color.White;
            this.lbDiasMax.Location = new System.Drawing.Point(215, 121);
            this.lbDiasMax.Name = "lbDiasMax";
            this.lbDiasMax.Size = new System.Drawing.Size(16, 13);
            this.lbDiasMax.TabIndex = 5;
            this.lbDiasMax.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(38, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Dias maximo de estatus pendiente:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(72, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(335, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "CAMBIAR FECHA PENDIENTE MAXIMA";
            // 
            // btnCambiar
            // 
            this.btnCambiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCambiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiar.ForeColor = System.Drawing.Color.White;
            this.btnCambiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiar.Location = new System.Drawing.Point(186, 205);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(85, 35);
            this.btnCambiar.TabIndex = 14;
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.UseVisualStyleBackColor = false;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // WFCambiarFechaPendMax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(462, 269);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbDiasMax);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbFechaDocumento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaPendMax);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFCambiarFechaPendMax";
            this.Text = "WFCambiarFechaPendMax";
            this.Load += new System.EventHandler(this.WFCambiarFechaPendMax_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaPendMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbFechaDocumento;
        private System.Windows.Forms.Label lbDiasMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCambiar;
    }
}