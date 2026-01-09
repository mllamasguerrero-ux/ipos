namespace iPos
{
    partial class WFDefineLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFDefineLote));
            this.TBLote = new System.Windows.Forms.TextBox();
            this.DTP = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTAsignar = new System.Windows.Forms.Button();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBLote
            // 
            this.TBLote.Location = new System.Drawing.Point(253, 75);
            this.TBLote.Name = "TBLote";
            this.TBLote.Size = new System.Drawing.Size(100, 20);
            this.TBLote.TabIndex = 0;
            // 
            // DTP
            // 
            this.DTP.Location = new System.Drawing.Point(253, 104);
            this.DTP.Name = "DTP";
            this.DTP.Size = new System.Drawing.Size(200, 20);
            this.DTP.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(115, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Fecha de vencimiento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(215, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Lote:";
            // 
            // BTAsignar
            // 
            this.BTAsignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTAsignar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAsignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.BTAsignar.ForeColor = System.Drawing.Color.White;
            this.BTAsignar.Location = new System.Drawing.Point(218, 141);
            this.BTAsignar.Name = "BTAsignar";
            this.BTAsignar.Size = new System.Drawing.Size(105, 29);
            this.BTAsignar.TabIndex = 162;
            this.BTAsignar.Text = "Asignar";
            this.BTAsignar.UseVisualStyleBackColor = false;
            this.BTAsignar.Click += new System.EventHandler(this.BTAsignar_Click);
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProducto.ForeColor = System.Drawing.Color.White;
            this.lblNombreProducto.Location = new System.Drawing.Point(215, 43);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(19, 13);
            this.lblNombreProducto.TabIndex = 163;
            this.lblNombreProducto.Text = "...";
            // 
            // WFDefineLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(538, 209);
            this.Controls.Add(this.lblNombreProducto);
            this.Controls.Add(this.BTAsignar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBLote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFDefineLote";
            this.Text = "Define lote";
            this.Load += new System.EventHandler(this.WFDefineLote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBLote;
        private System.Windows.Forms.DateTimePicker DTP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTAsignar;
        private System.Windows.Forms.Label lblNombreProducto;
    }
}