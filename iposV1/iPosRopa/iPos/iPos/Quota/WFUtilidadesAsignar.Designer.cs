namespace iPos
{
    partial class WFUtilidadesAsignar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFUtilidadesAsignar));
            this.PERSONAIDTextBox = new iPos.Tools.TextBoxFB();
            this.PERSONAButton = new System.Windows.Forms.Button();
            this.PERSONALabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.VENDEDORIDTextBox = new iPos.Tools.TextBoxFB();
            this.VENDEDORButton = new System.Windows.Forms.Button();
            this.VENDEDORLabel = new System.Windows.Forms.Label();
            this.VENDEDORIDLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PERSONAIDTextBox
            // 
            this.PERSONAIDTextBox.BotonLookUp = this.PERSONAButton;
            this.PERSONAIDTextBox.Condicion = null;
            this.PERSONAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PERSONAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PERSONAIDTextBox.DbValue = null;
            this.PERSONAIDTextBox.Format_Expression = null;
            this.PERSONAIDTextBox.IndiceCampoDescripcion = 2;
            this.PERSONAIDTextBox.IndiceCampoSelector = 1;
            this.PERSONAIDTextBox.IndiceCampoValue = 0;
            this.PERSONAIDTextBox.LabelDescription = this.PERSONALabel;
            this.PERSONAIDTextBox.Location = new System.Drawing.Point(118, 62);
            this.PERSONAIDTextBox.MostrarErrores = true;
            this.PERSONAIDTextBox.Name = "PERSONAIDTextBox";
            this.PERSONAIDTextBox.NombreCampoSelector = "clave";
            this.PERSONAIDTextBox.NombreCampoValue = "id";
            this.PERSONAIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid in (50)";
            this.PERSONAIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid in (50) and  clave= @clav" +
    "e";
            this.PERSONAIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid in (50) and  id = @id";
            this.PERSONAIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.PERSONAIDTextBox.TabIndex = 173;
            this.PERSONAIDTextBox.Tag = 34;
            this.PERSONAIDTextBox.TextDescription = null;
            this.PERSONAIDTextBox.Titulo = "Clientes";
            this.PERSONAIDTextBox.ValidarEntrada = true;
            this.PERSONAIDTextBox.ValidationExpression = null;
            this.PERSONAIDTextBox.Validated += new System.EventHandler(this.PERSONAIDTextBox_Validated);
            // 
            // PERSONAButton
            // 
            this.PERSONAButton.BackColor = System.Drawing.Color.Transparent;
            this.PERSONAButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.PERSONAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PERSONAButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PERSONAButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PERSONAButton.Location = new System.Drawing.Point(206, 62);
            this.PERSONAButton.Name = "PERSONAButton";
            this.PERSONAButton.Size = new System.Drawing.Size(23, 23);
            this.PERSONAButton.TabIndex = 174;
            this.PERSONAButton.UseVisualStyleBackColor = false;
            // 
            // PERSONALabel
            // 
            this.PERSONALabel.AutoSize = true;
            this.PERSONALabel.BackColor = System.Drawing.Color.Transparent;
            this.PERSONALabel.ForeColor = System.Drawing.Color.White;
            this.PERSONALabel.Location = new System.Drawing.Point(233, 68);
            this.PERSONALabel.Name = "PERSONALabel";
            this.PERSONALabel.Size = new System.Drawing.Size(16, 13);
            this.PERSONALabel.TabIndex = 175;
            this.PERSONALabel.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(42, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 176;
            this.label4.Text = "Del cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 168;
            this.label1.Text = "Desde:";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(666, 96);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 23);
            this.BTEnviar.TabIndex = 172;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // DTPFrom
            // 
            this.DTPFrom.Location = new System.Drawing.Point(102, 95);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(200, 20);
            this.DTPFrom.TabIndex = 169;
            // 
            // DTPTo
            // 
            this.DTPTo.Location = new System.Drawing.Point(417, 95);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(210, 20);
            this.DTPTo.TabIndex = 171;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(376, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 170;
            this.label2.Text = "A:";
            // 
            // VENDEDORIDTextBox
            // 
            this.VENDEDORIDTextBox.BotonLookUp = this.VENDEDORButton;
            this.VENDEDORIDTextBox.Condicion = null;
            this.VENDEDORIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORIDTextBox.DbValue = null;
            this.VENDEDORIDTextBox.Format_Expression = null;
            this.VENDEDORIDTextBox.IndiceCampoDescripcion = 2;
            this.VENDEDORIDTextBox.IndiceCampoSelector = 1;
            this.VENDEDORIDTextBox.IndiceCampoValue = 0;
            this.VENDEDORIDTextBox.LabelDescription = this.VENDEDORLabel;
            this.VENDEDORIDTextBox.Location = new System.Drawing.Point(458, 61);
            this.VENDEDORIDTextBox.MostrarErrores = true;
            this.VENDEDORIDTextBox.Name = "VENDEDORIDTextBox";
            this.VENDEDORIDTextBox.NombreCampoSelector = "clave";
            this.VENDEDORIDTextBox.NombreCampoValue = "id";
            this.VENDEDORIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 22";
            this.VENDEDORIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 22 and  clave= @clave";
            this.VENDEDORIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 22 and  id = @id";
            this.VENDEDORIDTextBox.Size = new System.Drawing.Size(117, 20);
            this.VENDEDORIDTextBox.TabIndex = 179;
            this.VENDEDORIDTextBox.Tag = 34;
            this.VENDEDORIDTextBox.TextDescription = null;
            this.VENDEDORIDTextBox.Titulo = "Vendedores";
            this.VENDEDORIDTextBox.ValidarEntrada = true;
            this.VENDEDORIDTextBox.ValidationExpression = null;
            // 
            // VENDEDORButton
            // 
            this.VENDEDORButton.BackColor = System.Drawing.Color.Transparent;
            this.VENDEDORButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.VENDEDORButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VENDEDORButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VENDEDORButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.VENDEDORButton.Location = new System.Drawing.Point(581, 61);
            this.VENDEDORButton.Name = "VENDEDORButton";
            this.VENDEDORButton.Size = new System.Drawing.Size(24, 24);
            this.VENDEDORButton.TabIndex = 178;
            this.VENDEDORButton.UseVisualStyleBackColor = false;
            // 
            // VENDEDORLabel
            // 
            this.VENDEDORLabel.AutoSize = true;
            this.VENDEDORLabel.BackColor = System.Drawing.Color.Transparent;
            this.VENDEDORLabel.ForeColor = System.Drawing.Color.White;
            this.VENDEDORLabel.Location = new System.Drawing.Point(611, 67);
            this.VENDEDORLabel.Name = "VENDEDORLabel";
            this.VENDEDORLabel.Size = new System.Drawing.Size(16, 13);
            this.VENDEDORLabel.TabIndex = 180;
            this.VENDEDORLabel.Text = "...";
            // 
            // VENDEDORIDLabel
            // 
            this.VENDEDORIDLabel.AutoSize = true;
            this.VENDEDORIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.VENDEDORIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VENDEDORIDLabel.ForeColor = System.Drawing.Color.White;
            this.VENDEDORIDLabel.Location = new System.Drawing.Point(376, 67);
            this.VENDEDORIDLabel.Name = "VENDEDORIDLabel";
            this.VENDEDORIDLabel.Size = new System.Drawing.Size(79, 13);
            this.VENDEDORIDLabel.TabIndex = 177;
            this.VENDEDORIDLabel.Text = "Al vendedor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(42, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 13);
            this.label3.TabIndex = 181;
            this.label3.Text = "CAMBIO DE ASIGNACION DE UTILIDADES";
            // 
            // WFUtilidadesAsignar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(774, 158);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VENDEDORIDTextBox);
            this.Controls.Add(this.VENDEDORIDLabel);
            this.Controls.Add(this.VENDEDORButton);
            this.Controls.Add(this.VENDEDORLabel);
            this.Controls.Add(this.PERSONAIDTextBox);
            this.Controls.Add(this.PERSONAButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTEnviar);
            this.Controls.Add(this.PERSONALabel);
            this.Controls.Add(this.DTPFrom);
            this.Controls.Add(this.DTPTo);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFUtilidadesAsignar";
            this.Text = "Utilidades Asignar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tools.TextBoxFB PERSONAIDTextBox;
        private System.Windows.Forms.Button PERSONAButton;
        private System.Windows.Forms.Label PERSONALabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.Label label2;
        private Tools.TextBoxFB VENDEDORIDTextBox;
        private System.Windows.Forms.Button VENDEDORButton;
        private System.Windows.Forms.Label VENDEDORLabel;
        private System.Windows.Forms.Label VENDEDORIDLabel;
        private System.Windows.Forms.Label label3;
    }
}