namespace iPos.PuntoDeVenta
{
    partial class WFAdjuntarArchivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFAdjuntarArchivos));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvArchivosAdjuntos = new System.Windows.Forms.CheckedListBox();
            this.btnAdjuntarArchivos = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtHorasTrabajo = new iPos.Tools.TextBoxFB();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(200, 52);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(126, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(53, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Horas de trabajo:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lvArchivosAdjuntos);
            this.panel1.Location = new System.Drawing.Point(21, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 179);
            this.panel1.TabIndex = 4;
            // 
            // lvArchivosAdjuntos
            // 
            this.lvArchivosAdjuntos.FormattingEnabled = true;
            this.lvArchivosAdjuntos.Location = new System.Drawing.Point(3, 3);
            this.lvArchivosAdjuntos.Name = "lvArchivosAdjuntos";
            this.lvArchivosAdjuntos.Size = new System.Drawing.Size(409, 169);
            this.lvArchivosAdjuntos.TabIndex = 0;
            // 
            // btnAdjuntarArchivos
            // 
            this.btnAdjuntarArchivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnAdjuntarArchivos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAdjuntarArchivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjuntarArchivos.ForeColor = System.Drawing.Color.White;
            this.btnAdjuntarArchivos.Location = new System.Drawing.Point(241, 368);
            this.btnAdjuntarArchivos.Name = "btnAdjuntarArchivos";
            this.btnAdjuntarArchivos.Size = new System.Drawing.Size(111, 23);
            this.btnAdjuntarArchivos.TabIndex = 5;
            this.btnAdjuntarArchivos.Text = "Adjuntar archivos";
            this.btnAdjuntarArchivos.UseVisualStyleBackColor = false;
            this.btnAdjuntarArchivos.Visible = false;
            this.btnAdjuntarArchivos.Click += new System.EventHandler(this.btnAdjuntarArchivos_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(119, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Seleccionar archivo";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtHorasTrabajo
            // 
            this.txtHorasTrabajo.BotonLookUp = null;
            this.txtHorasTrabajo.Condicion = null;
            this.txtHorasTrabajo.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.txtHorasTrabajo.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.txtHorasTrabajo.DbValue = null;
            this.txtHorasTrabajo.Enabled = false;
            this.txtHorasTrabajo.Format_Expression = null;
            this.txtHorasTrabajo.IndiceCampoDescripcion = 0;
            this.txtHorasTrabajo.IndiceCampoSelector = 0;
            this.txtHorasTrabajo.IndiceCampoValue = 0;
            this.txtHorasTrabajo.LabelDescription = null;
            this.txtHorasTrabajo.Location = new System.Drawing.Point(200, 110);
            this.txtHorasTrabajo.Name = "txtHorasTrabajo";
            this.txtHorasTrabajo.NombreCampoSelector = null;
            this.txtHorasTrabajo.NombreCampoValue = null;
            this.txtHorasTrabajo.Query = null;
            this.txtHorasTrabajo.QueryDeSeleccion = null;
            this.txtHorasTrabajo.QueryPorDBValue = null;
            this.txtHorasTrabajo.Size = new System.Drawing.Size(200, 20);
            this.txtHorasTrabajo.TabIndex = 3;
            this.txtHorasTrabajo.Tag = 34;
            this.txtHorasTrabajo.TextDescription = null;
            this.txtHorasTrabajo.Titulo = null;
            this.txtHorasTrabajo.ValidationExpression = null;
            // 
            // WFAdjuntarArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(461, 403);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdjuntarArchivos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtHorasTrabajo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFAdjuntarArchivos";
            this.Text = "Adjuntar Archivos ";
            this.Load += new System.EventHandler(this.WFAdjuntarArchivos_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Tools.TextBoxFB txtHorasTrabajo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdjuntarArchivos;
        private System.Windows.Forms.CheckedListBox lvArchivosAdjuntos;
        private System.Windows.Forms.Button button1;
    }
}