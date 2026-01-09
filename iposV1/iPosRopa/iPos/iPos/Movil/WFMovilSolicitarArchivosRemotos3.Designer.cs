namespace iPos.Movil
{
    partial class WFMovilSolicitarArchivosRemotos3
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
            this.btnVerificarSolicitud = new System.Windows.Forms.Button();
            this.btnSolicitarArchivos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnVerificarSolicitud
            // 
            this.btnVerificarSolicitud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnVerificarSolicitud.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnVerificarSolicitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificarSolicitud.ForeColor = System.Drawing.Color.White;
            this.btnVerificarSolicitud.Location = new System.Drawing.Point(81, 168);
            this.btnVerificarSolicitud.Name = "btnVerificarSolicitud";
            this.btnVerificarSolicitud.Size = new System.Drawing.Size(184, 26);
            this.btnVerificarSolicitud.TabIndex = 6;
            this.btnVerificarSolicitud.Text = "Verificar solicitud";
            this.btnVerificarSolicitud.UseVisualStyleBackColor = false;
            this.btnVerificarSolicitud.Click += new System.EventHandler(this.btnVerificarSolicitud_Click);
            // 
            // btnSolicitarArchivos
            // 
            this.btnSolicitarArchivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnSolicitarArchivos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSolicitarArchivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolicitarArchivos.ForeColor = System.Drawing.Color.White;
            this.btnSolicitarArchivos.Location = new System.Drawing.Point(81, 115);
            this.btnSolicitarArchivos.Name = "btnSolicitarArchivos";
            this.btnSolicitarArchivos.Size = new System.Drawing.Size(184, 26);
            this.btnSolicitarArchivos.TabIndex = 5;
            this.btnSolicitarArchivos.Text = "Solicitar archivos remotos";
            this.btnSolicitarArchivos.UseVisualStyleBackColor = false;
            this.btnSolicitarArchivos.Click += new System.EventHandler(this.btnSolicitarArchivos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(93, 42);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // WFMovilSolicitarArchivosRemotos3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(408, 244);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnVerificarSolicitud);
            this.Controls.Add(this.btnSolicitarArchivos);
            this.Controls.Add(this.label1);
            this.Name = "WFMovilSolicitarArchivosRemotos3";
            this.Text = "WFMovilSolicitarArchivosRemotos3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerificarSolicitud;
        private System.Windows.Forms.Button btnSolicitarArchivos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}