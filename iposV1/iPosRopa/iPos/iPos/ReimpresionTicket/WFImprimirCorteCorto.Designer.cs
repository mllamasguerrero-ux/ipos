namespace iPos
{
    partial class WFImprimirCorteCorto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFImprimirCorteCorto));
            this.label2 = new System.Windows.Forms.Label();
            this.BTReimprimirCorte = new System.Windows.Forms.Button();
            this.DTPCorte = new System.Windows.Forms.DateTimePicker();
            this.cbSumarizado = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GBOpcionesSumarizado = new System.Windows.Forms.GroupBox();
            this.RBPorGrupoCorto = new System.Windows.Forms.RadioButton();
            this.RBPorGrupoCajeros = new System.Windows.Forms.RadioButton();
            this.RBPorCajero = new System.Windows.Forms.RadioButton();
            this.RBNormal = new System.Windows.Forms.RadioButton();
            this.btnEnviarXMail = new System.Windows.Forms.Button();
            this.btnVistaPrevia = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.GBOpcionesSumarizado.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(46, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fecha:";
            // 
            // BTReimprimirCorte
            // 
            this.BTReimprimirCorte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTReimprimirCorte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTReimprimirCorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTReimprimirCorte.Image = global::iPos.Properties.Resources.printNoBack_J;
            this.BTReimprimirCorte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTReimprimirCorte.Location = new System.Drawing.Point(337, 49);
            this.BTReimprimirCorte.Name = "BTReimprimirCorte";
            this.BTReimprimirCorte.Size = new System.Drawing.Size(156, 35);
            this.BTReimprimirCorte.TabIndex = 10;
            this.BTReimprimirCorte.Text = "Reimprimir corte";
            this.BTReimprimirCorte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTReimprimirCorte.UseVisualStyleBackColor = false;
            this.BTReimprimirCorte.Click += new System.EventHandler(this.BTReimprimirCorte_Click);
            // 
            // DTPCorte
            // 
            this.DTPCorte.Location = new System.Drawing.Point(98, 58);
            this.DTPCorte.Name = "DTPCorte";
            this.DTPCorte.Size = new System.Drawing.Size(233, 20);
            this.DTPCorte.TabIndex = 8;
            // 
            // cbSumarizado
            // 
            this.cbSumarizado.AutoSize = true;
            this.cbSumarizado.Location = new System.Drawing.Point(7, 28);
            this.cbSumarizado.Name = "cbSumarizado";
            this.cbSumarizado.Size = new System.Drawing.Size(91, 17);
            this.cbSumarizado.TabIndex = 11;
            this.cbSumarizado.Text = "Sumarizado";
            this.cbSumarizado.UseVisualStyleBackColor = true;
            this.cbSumarizado.CheckedChanged += new System.EventHandler(this.cbSumarizado_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.GBOpcionesSumarizado);
            this.groupBox1.Controls.Add(this.cbSumarizado);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(18, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 69);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipos especiales";
            // 
            // GBOpcionesSumarizado
            // 
            this.GBOpcionesSumarizado.Controls.Add(this.RBPorGrupoCorto);
            this.GBOpcionesSumarizado.Controls.Add(this.RBPorGrupoCajeros);
            this.GBOpcionesSumarizado.Controls.Add(this.RBPorCajero);
            this.GBOpcionesSumarizado.Controls.Add(this.RBNormal);
            this.GBOpcionesSumarizado.Enabled = false;
            this.GBOpcionesSumarizado.Location = new System.Drawing.Point(102, 15);
            this.GBOpcionesSumarizado.Name = "GBOpcionesSumarizado";
            this.GBOpcionesSumarizado.Size = new System.Drawing.Size(482, 38);
            this.GBOpcionesSumarizado.TabIndex = 13;
            this.GBOpcionesSumarizado.TabStop = false;
            // 
            // RBPorGrupoCorto
            // 
            this.RBPorGrupoCorto.AutoSize = true;
            this.RBPorGrupoCorto.Location = new System.Drawing.Point(98, 13);
            this.RBPorGrupoCorto.Name = "RBPorGrupoCorto";
            this.RBPorGrupoCorto.Size = new System.Drawing.Size(113, 17);
            this.RBPorGrupoCorto.TabIndex = 15;
            this.RBPorGrupoCorto.TabStop = true;
            this.RBPorGrupoCorto.Text = "Por grupo corto";
            this.RBPorGrupoCorto.UseVisualStyleBackColor = true;
            // 
            // RBPorGrupoCajeros
            // 
            this.RBPorGrupoCajeros.AutoSize = true;
            this.RBPorGrupoCajeros.Location = new System.Drawing.Point(333, 13);
            this.RBPorGrupoCajeros.Name = "RBPorGrupoCajeros";
            this.RBPorGrupoCajeros.Size = new System.Drawing.Size(143, 17);
            this.RBPorGrupoCajeros.TabIndex = 14;
            this.RBPorGrupoCajeros.TabStop = true;
            this.RBPorGrupoCajeros.Text = "Por grupo de cajeros";
            this.RBPorGrupoCajeros.UseVisualStyleBackColor = true;
            // 
            // RBPorCajero
            // 
            this.RBPorCajero.AutoSize = true;
            this.RBPorCajero.Location = new System.Drawing.Point(234, 13);
            this.RBPorCajero.Name = "RBPorCajero";
            this.RBPorCajero.Size = new System.Drawing.Size(84, 17);
            this.RBPorCajero.TabIndex = 13;
            this.RBPorCajero.TabStop = true;
            this.RBPorCajero.Text = "Por Cajero";
            this.RBPorCajero.UseVisualStyleBackColor = true;
            // 
            // RBNormal
            // 
            this.RBNormal.AutoSize = true;
            this.RBNormal.Location = new System.Drawing.Point(14, 13);
            this.RBNormal.Name = "RBNormal";
            this.RBNormal.Size = new System.Drawing.Size(64, 17);
            this.RBNormal.TabIndex = 12;
            this.RBNormal.TabStop = true;
            this.RBNormal.Text = "Normal";
            this.RBNormal.UseVisualStyleBackColor = true;
            // 
            // btnEnviarXMail
            // 
            this.btnEnviarXMail.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnEnviarXMail.Enabled = false;
            this.btnEnviarXMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarXMail.Image = global::iPos.Properties.Resources.sendNoBack_J;
            this.btnEnviarXMail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarXMail.Location = new System.Drawing.Point(184, 90);
            this.btnEnviarXMail.Name = "btnEnviarXMail";
            this.btnEnviarXMail.Size = new System.Drawing.Size(147, 32);
            this.btnEnviarXMail.TabIndex = 13;
            this.btnEnviarXMail.Text = "Enviar x Email";
            this.btnEnviarXMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviarXMail.UseVisualStyleBackColor = false;
            this.btnEnviarXMail.Click += new System.EventHandler(this.btnEnviarXMail_Click);
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnVistaPrevia.Enabled = false;
            this.btnVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVistaPrevia.Image = global::iPos.Properties.Resources.searchNoBack_J;
            this.btnVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVistaPrevia.Location = new System.Drawing.Point(337, 90);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Size = new System.Drawing.Size(156, 32);
            this.btnVistaPrevia.TabIndex = 14;
            this.btnVistaPrevia.Text = "Vista previa";
            this.btnVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVistaPrevia.UseVisualStyleBackColor = false;
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // WFImprimirCorteCorto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(620, 212);
            this.Controls.Add(this.btnVistaPrevia);
            this.Controls.Add(this.btnEnviarXMail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTReimprimirCorte);
            this.Controls.Add(this.DTPCorte);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFImprimirCorteCorto";
            this.Text = "Imprimir Corte Corto";
            this.Load += new System.EventHandler(this.WFImprimirCorteCorto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GBOpcionesSumarizado.ResumeLayout(false);
            this.GBOpcionesSumarizado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTReimprimirCorte;
        private System.Windows.Forms.DateTimePicker DTPCorte;
        private System.Windows.Forms.CheckBox cbSumarizado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox GBOpcionesSumarizado;
        private System.Windows.Forms.RadioButton RBPorCajero;
        private System.Windows.Forms.RadioButton RBNormal;
        private System.Windows.Forms.Button btnEnviarXMail;
        private System.Windows.Forms.Button btnVistaPrevia;
        private System.Windows.Forms.RadioButton RBPorGrupoCajeros;
        private System.Windows.Forms.RadioButton RBPorGrupoCorto;
    }
}