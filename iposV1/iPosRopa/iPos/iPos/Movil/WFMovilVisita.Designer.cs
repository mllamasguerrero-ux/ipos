namespace iPos
{
    partial class WFMovilVisita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFMovilVisita));
            this.pnlInicioVisita = new System.Windows.Forms.Panel();
            this.lbClieNombre = new System.Windows.Forms.Label();
            this.LBCliente = new System.Windows.Forms.Label();
            this.BTCliente = new System.Windows.Forms.Button();
            this.btnEnviarInicio = new System.Windows.Forms.Button();
            this.DTPFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFinVisita = new System.Windows.Forms.Panel();
            this.btnCancelarVisita = new System.Windows.Forms.Button();
            this.CBHizoPedido = new System.Windows.Forms.CheckBox();
            this.btnEnviarFin = new System.Windows.Forms.Button();
            this.DTPFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlInicioVisita.SuspendLayout();
            this.pnlFinVisita.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInicioVisita
            // 
            this.pnlInicioVisita.BackColor = System.Drawing.Color.Transparent;
            this.pnlInicioVisita.Controls.Add(this.lbClieNombre);
            this.pnlInicioVisita.Controls.Add(this.LBCliente);
            this.pnlInicioVisita.Controls.Add(this.BTCliente);
            this.pnlInicioVisita.Controls.Add(this.btnEnviarInicio);
            this.pnlInicioVisita.Controls.Add(this.DTPFechaInicio);
            this.pnlInicioVisita.Controls.Add(this.label1);
            this.pnlInicioVisita.Location = new System.Drawing.Point(15, 3);
            this.pnlInicioVisita.Name = "pnlInicioVisita";
            this.pnlInicioVisita.Size = new System.Drawing.Size(313, 164);
            this.pnlInicioVisita.TabIndex = 0;
            // 
            // lbClieNombre
            // 
            this.lbClieNombre.AutoSize = true;
            this.lbClieNombre.BackColor = System.Drawing.Color.Transparent;
            this.lbClieNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieNombre.ForeColor = System.Drawing.Color.White;
            this.lbClieNombre.Location = new System.Drawing.Point(94, 52);
            this.lbClieNombre.Name = "lbClieNombre";
            this.lbClieNombre.Size = new System.Drawing.Size(19, 15);
            this.lbClieNombre.TabIndex = 172;
            this.lbClieNombre.Text = "...";
            // 
            // LBCliente
            // 
            this.LBCliente.AutoSize = true;
            this.LBCliente.BackColor = System.Drawing.Color.Transparent;
            this.LBCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCliente.ForeColor = System.Drawing.Color.White;
            this.LBCliente.Location = new System.Drawing.Point(94, 34);
            this.LBCliente.Name = "LBCliente";
            this.LBCliente.Size = new System.Drawing.Size(19, 15);
            this.LBCliente.TabIndex = 171;
            this.LBCliente.Text = "...";
            // 
            // BTCliente
            // 
            this.BTCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCliente.ForeColor = System.Drawing.Color.White;
            this.BTCliente.Location = new System.Drawing.Point(15, 34);
            this.BTCliente.Name = "BTCliente";
            this.BTCliente.Size = new System.Drawing.Size(67, 35);
            this.BTCliente.TabIndex = 170;
            this.BTCliente.Text = "Cliente:";
            this.BTCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCliente.UseVisualStyleBackColor = false;
            this.BTCliente.Click += new System.EventHandler(this.BTCliente_Click);
            // 
            // btnEnviarInicio
            // 
            this.btnEnviarInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnEnviarInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarInicio.ForeColor = System.Drawing.Color.White;
            this.btnEnviarInicio.Location = new System.Drawing.Point(97, 121);
            this.btnEnviarInicio.Name = "btnEnviarInicio";
            this.btnEnviarInicio.Size = new System.Drawing.Size(141, 40);
            this.btnEnviarInicio.TabIndex = 2;
            this.btnEnviarInicio.Text = "Enviar inicio de visita";
            this.btnEnviarInicio.UseVisualStyleBackColor = false;
            this.btnEnviarInicio.Click += new System.EventHandler(this.btnEnviarInicio_Click);
            // 
            // DTPFechaInicio
            // 
            this.DTPFechaInicio.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy hh:mm tt";
            this.DTPFechaInicio.Enabled = false;
            this.DTPFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPFechaInicio.Location = new System.Drawing.Point(15, 86);
            this.DTPFechaInicio.Name = "DTPFechaInicio";
            this.DTPFechaInicio.Size = new System.Drawing.Size(272, 20);
            this.DTPFechaInicio.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio de visita";
            // 
            // pnlFinVisita
            // 
            this.pnlFinVisita.BackColor = System.Drawing.Color.Transparent;
            this.pnlFinVisita.Controls.Add(this.btnCancelarVisita);
            this.pnlFinVisita.Controls.Add(this.CBHizoPedido);
            this.pnlFinVisita.Controls.Add(this.btnEnviarFin);
            this.pnlFinVisita.Controls.Add(this.DTPFechaFin);
            this.pnlFinVisita.Controls.Add(this.label2);
            this.pnlFinVisita.Location = new System.Drawing.Point(15, 173);
            this.pnlFinVisita.Name = "pnlFinVisita";
            this.pnlFinVisita.Size = new System.Drawing.Size(313, 154);
            this.pnlFinVisita.TabIndex = 1;
            // 
            // btnCancelarVisita
            // 
            this.btnCancelarVisita.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelarVisita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarVisita.ForeColor = System.Drawing.Color.White;
            this.btnCancelarVisita.Location = new System.Drawing.Point(164, 103);
            this.btnCancelarVisita.Name = "btnCancelarVisita";
            this.btnCancelarVisita.Size = new System.Drawing.Size(123, 36);
            this.btnCancelarVisita.TabIndex = 5;
            this.btnCancelarVisita.Text = "Cancelar visita";
            this.btnCancelarVisita.UseVisualStyleBackColor = false;
            this.btnCancelarVisita.Click += new System.EventHandler(this.btnCancelarVisita_Click);
            // 
            // CBHizoPedido
            // 
            this.CBHizoPedido.AutoSize = true;
            this.CBHizoPedido.ForeColor = System.Drawing.Color.White;
            this.CBHizoPedido.Location = new System.Drawing.Point(15, 80);
            this.CBHizoPedido.Name = "CBHizoPedido";
            this.CBHizoPedido.Size = new System.Drawing.Size(82, 17);
            this.CBHizoPedido.TabIndex = 4;
            this.CBHizoPedido.Text = "Hizo pedido";
            this.CBHizoPedido.UseVisualStyleBackColor = true;
            // 
            // btnEnviarFin
            // 
            this.btnEnviarFin.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnEnviarFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarFin.ForeColor = System.Drawing.Color.White;
            this.btnEnviarFin.Location = new System.Drawing.Point(15, 103);
            this.btnEnviarFin.Name = "btnEnviarFin";
            this.btnEnviarFin.Size = new System.Drawing.Size(123, 36);
            this.btnEnviarFin.TabIndex = 3;
            this.btnEnviarFin.Text = "Enviar fin de visita";
            this.btnEnviarFin.UseVisualStyleBackColor = false;
            this.btnEnviarFin.Click += new System.EventHandler(this.btnEnviarFin_Click);
            // 
            // DTPFechaFin
            // 
            this.DTPFechaFin.CustomFormat = "dddd, dd \'de\' MMMM \'de\' yyyy hh:mm tt";
            this.DTPFechaFin.Enabled = false;
            this.DTPFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPFechaFin.Location = new System.Drawing.Point(15, 44);
            this.DTPFechaFin.Name = "DTPFechaFin";
            this.DTPFechaFin.Size = new System.Drawing.Size(272, 20);
            this.DTPFechaFin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fin de visita";
            // 
            // WFMovilVisita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(337, 339);
            this.Controls.Add(this.pnlFinVisita);
            this.Controls.Add(this.pnlInicioVisita);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFMovilVisita";
            this.Text = "WFMovilVisita";
            this.Load += new System.EventHandler(this.WFMovilVisita_Load);
            this.pnlInicioVisita.ResumeLayout(false);
            this.pnlInicioVisita.PerformLayout();
            this.pnlFinVisita.ResumeLayout(false);
            this.pnlFinVisita.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInicioVisita;
        private System.Windows.Forms.Panel pnlFinVisita;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPFechaInicio;
        private System.Windows.Forms.Button btnEnviarInicio;
        private System.Windows.Forms.CheckBox CBHizoPedido;
        private System.Windows.Forms.Button btnEnviarFin;
        private System.Windows.Forms.DateTimePicker DTPFechaFin;
        private System.Windows.Forms.Label lbClieNombre;
        private System.Windows.Forms.Label LBCliente;
        private System.Windows.Forms.Button BTCliente;
        private System.Windows.Forms.Button btnCancelarVisita;
    }
}