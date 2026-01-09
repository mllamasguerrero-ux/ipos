namespace iPos.Utilerias.Procesos
{
    partial class WFEliminacionDocPendientes
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
            this.btnVerDocumentosPendientes = new System.Windows.Forms.Button();
            this.btnEliminarDocPendientes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVerDocumentosPendientes
            // 
            this.btnVerDocumentosPendientes.Location = new System.Drawing.Point(154, 50);
            this.btnVerDocumentosPendientes.Name = "btnVerDocumentosPendientes";
            this.btnVerDocumentosPendientes.Size = new System.Drawing.Size(131, 64);
            this.btnVerDocumentosPendientes.TabIndex = 0;
            this.btnVerDocumentosPendientes.Text = "Ver documentos pendientes";
            this.btnVerDocumentosPendientes.UseVisualStyleBackColor = true;
            this.btnVerDocumentosPendientes.Click += new System.EventHandler(this.btnVerDocumentosPendientes_Click);
            // 
            // btnEliminarDocPendientes
            // 
            this.btnEliminarDocPendientes.Location = new System.Drawing.Point(154, 155);
            this.btnEliminarDocPendientes.Name = "btnEliminarDocPendientes";
            this.btnEliminarDocPendientes.Size = new System.Drawing.Size(131, 64);
            this.btnEliminarDocPendientes.TabIndex = 1;
            this.btnEliminarDocPendientes.Text = "Eliminar documentos pendientes";
            this.btnEliminarDocPendientes.UseVisualStyleBackColor = true;
            this.btnEliminarDocPendientes.Click += new System.EventHandler(this.btnEliminarDocPendientes_Click);
            // 
            // WFEliminacionDocPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(441, 261);
            this.Controls.Add(this.btnEliminarDocPendientes);
            this.Controls.Add(this.btnVerDocumentosPendientes);
            this.Name = "WFEliminacionDocPendientes";
            this.Text = "WFEliminacionDocPendientes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVerDocumentosPendientes;
        private System.Windows.Forms.Button btnEliminarDocPendientes;
    }
}