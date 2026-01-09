namespace iPos
{
    partial class WFMovilSolicitarArchivosRemotos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFMovilSolicitarArchivosRemotos));
            this.CBDIAS = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSolicitarArchivos = new System.Windows.Forms.Button();
            this.btnVerificarSolicitud = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CBDIAS
            // 
            this.CBDIAS.FormattingEnabled = true;
            this.CBDIAS.Items.AddRange(new object[] {
            "LUNES",
            "MARTES",
            "MIERCOLES",
            "JUEVES",
            "VIERNES",
            "SABADO",
            "DOMINGO"});
            this.CBDIAS.Location = new System.Drawing.Point(174, 46);
            this.CBDIAS.Name = "CBDIAS";
            this.CBDIAS.Size = new System.Drawing.Size(184, 21);
            this.CBDIAS.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(51, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dia de la semana";
            // 
            // btnSolicitarArchivos
            // 
            this.btnSolicitarArchivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnSolicitarArchivos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSolicitarArchivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolicitarArchivos.ForeColor = System.Drawing.Color.White;
            this.btnSolicitarArchivos.Location = new System.Drawing.Point(115, 96);
            this.btnSolicitarArchivos.Name = "btnSolicitarArchivos";
            this.btnSolicitarArchivos.Size = new System.Drawing.Size(184, 26);
            this.btnSolicitarArchivos.TabIndex = 2;
            this.btnSolicitarArchivos.Text = "Solicitar archivos remotos";
            this.btnSolicitarArchivos.UseVisualStyleBackColor = false;
            this.btnSolicitarArchivos.Click += new System.EventHandler(this.btnSolicitarArchivos_Click);
            // 
            // btnVerificarSolicitud
            // 
            this.btnVerificarSolicitud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnVerificarSolicitud.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnVerificarSolicitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificarSolicitud.ForeColor = System.Drawing.Color.White;
            this.btnVerificarSolicitud.Location = new System.Drawing.Point(115, 149);
            this.btnVerificarSolicitud.Name = "btnVerificarSolicitud";
            this.btnVerificarSolicitud.Size = new System.Drawing.Size(184, 26);
            this.btnVerificarSolicitud.TabIndex = 3;
            this.btnVerificarSolicitud.Text = "Verificar solicitud";
            this.btnVerificarSolicitud.UseVisualStyleBackColor = false;
            this.btnVerificarSolicitud.Click += new System.EventHandler(this.btnVerificarSolicitud_Click);
            // 
            // WFMovilSolicitarArchivosRemotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(410, 203);
            this.Controls.Add(this.btnVerificarSolicitud);
            this.Controls.Add(this.btnSolicitarArchivos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBDIAS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFMovilSolicitarArchivosRemotos";
            this.Text = "Solicitar archivos remotos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBDIAS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSolicitarArchivos;
        private System.Windows.Forms.Button btnVerificarSolicitud;
    }
}