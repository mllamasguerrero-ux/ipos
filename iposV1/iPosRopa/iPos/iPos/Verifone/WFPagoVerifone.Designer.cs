namespace iPos
{
    partial class WFPagoVerifone
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
            this.components = new System.ComponentModel.Container();
            this.lblMensajeOperacion = new System.Windows.Forms.Label();
            this.ConsoleOutput = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnReintentar = new System.Windows.Forms.Button();
            this.timerCheckingTransaction = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblMensajeOperacion
            // 
            this.lblMensajeOperacion.AutoSize = true;
            this.lblMensajeOperacion.BackColor = System.Drawing.Color.Transparent;
            this.lblMensajeOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeOperacion.ForeColor = System.Drawing.Color.White;
            this.lblMensajeOperacion.Location = new System.Drawing.Point(29, 53);
            this.lblMensajeOperacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMensajeOperacion.Name = "lblMensajeOperacion";
            this.lblMensajeOperacion.Size = new System.Drawing.Size(348, 31);
            this.lblMensajeOperacion.TabIndex = 0;
            this.lblMensajeOperacion.Text = "Procesando en terminal...";
            // 
            // ConsoleOutput
            // 
            this.ConsoleOutput.Location = new System.Drawing.Point(36, 145);
            this.ConsoleOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConsoleOutput.Multiline = true;
            this.ConsoleOutput.Name = "ConsoleOutput";
            this.ConsoleOutput.Size = new System.Drawing.Size(607, 88);
            this.ConsoleOutput.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(36, 107);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(608, 28);
            this.progressBar1.TabIndex = 2;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Salmon;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(511, 343);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(115, 52);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnReintentar
            // 
            this.btnReintentar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnReintentar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReintentar.ForeColor = System.Drawing.Color.White;
            this.btnReintentar.Location = new System.Drawing.Point(49, 268);
            this.btnReintentar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReintentar.Name = "btnReintentar";
            this.btnReintentar.Size = new System.Drawing.Size(244, 52);
            this.btnReintentar.TabIndex = 4;
            this.btnReintentar.Text = "RE-INTENTAR";
            this.btnReintentar.UseVisualStyleBackColor = false;
            this.btnReintentar.Visible = false;
            this.btnReintentar.Click += new System.EventHandler(this.btnReintentar_Click);
            // 
            // timerCheckingTransaction
            // 
            this.timerCheckingTransaction.Interval = 1000;
            this.timerCheckingTransaction.Tick += new System.EventHandler(this.timerCheckingTransaction_Tick);
            // 
            // WFPagoVerifone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(777, 430);
            this.ControlBox = false;
            this.Controls.Add(this.btnReintentar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ConsoleOutput);
            this.Controls.Add(this.lblMensajeOperacion);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WFPagoVerifone";
            this.Text = "PAGO VERIFONE";
            this.Load += new System.EventHandler(this.WFPagoVerifone_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensajeOperacion;
        private System.Windows.Forms.TextBox ConsoleOutput;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnReintentar;
        private System.Windows.Forms.Timer timerCheckingTransaction;
    }
}