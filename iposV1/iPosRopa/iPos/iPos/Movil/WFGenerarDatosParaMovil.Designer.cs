namespace iPos.Movil
{
    partial class WFGenerarDatosParaMovil
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
            this.CobradorLabel = new System.Windows.Forms.Label();
            this.COBRADORIDTextBox = new iPos.Tools.TextBoxFB();
            this.VENDEDORButton = new System.Windows.Forms.Button();
            this.VENDEDORIDLabel = new System.Windows.Forms.Label();
            this.btnRecibir = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.FECHATextBox = new System.Windows.Forms.DateTimePicker();
            this.CBAndroid = new System.Windows.Forms.CheckBox();
            this.CBExpProdInactivos = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CobradorLabel
            // 
            this.CobradorLabel.AutoSize = true;
            this.CobradorLabel.BackColor = System.Drawing.Color.Transparent;
            this.CobradorLabel.ForeColor = System.Drawing.Color.White;
            this.CobradorLabel.Location = new System.Drawing.Point(268, 48);
            this.CobradorLabel.Name = "CobradorLabel";
            this.CobradorLabel.Size = new System.Drawing.Size(16, 13);
            this.CobradorLabel.TabIndex = 185;
            this.CobradorLabel.Text = "...";
            // 
            // COBRADORIDTextBox
            // 
            this.COBRADORIDTextBox.AccessibleDescription = "";
            this.COBRADORIDTextBox.BotonLookUp = this.VENDEDORButton;
            this.COBRADORIDTextBox.Condicion = null;
            this.COBRADORIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.COBRADORIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.COBRADORIDTextBox.DbValue = null;
            this.COBRADORIDTextBox.Format_Expression = null;
            this.COBRADORIDTextBox.IndiceCampoDescripcion = 2;
            this.COBRADORIDTextBox.IndiceCampoSelector = 1;
            this.COBRADORIDTextBox.IndiceCampoValue = 0;
            this.COBRADORIDTextBox.LabelDescription = this.CobradorLabel;
            this.COBRADORIDTextBox.Location = new System.Drawing.Point(115, 43);
            this.COBRADORIDTextBox.MostrarErrores = true;
            this.COBRADORIDTextBox.Name = "COBRADORIDTextBox";
            this.COBRADORIDTextBox.NombreCampoSelector = "clave";
            this.COBRADORIDTextBox.NombreCampoValue = "id";
            this.COBRADORIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 22";
            this.COBRADORIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 22 and  clave= @clave";
            this.COBRADORIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 22 and  id = @id";
            this.COBRADORIDTextBox.Size = new System.Drawing.Size(117, 20);
            this.COBRADORIDTextBox.TabIndex = 183;
            this.COBRADORIDTextBox.Tag = 34;
            this.COBRADORIDTextBox.TextDescription = null;
            this.COBRADORIDTextBox.Titulo = "Cobradores";
            this.COBRADORIDTextBox.ValidarEntrada = true;
            this.COBRADORIDTextBox.ValidationExpression = null;
            // 
            // VENDEDORButton
            // 
            this.VENDEDORButton.AccessibleDescription = "";
            this.VENDEDORButton.BackColor = System.Drawing.Color.Transparent;
            this.VENDEDORButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.VENDEDORButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VENDEDORButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VENDEDORButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.VENDEDORButton.Location = new System.Drawing.Point(238, 43);
            this.VENDEDORButton.Name = "VENDEDORButton";
            this.VENDEDORButton.Size = new System.Drawing.Size(24, 23);
            this.VENDEDORButton.TabIndex = 184;
            this.VENDEDORButton.UseVisualStyleBackColor = false;
            // 
            // VENDEDORIDLabel
            // 
            this.VENDEDORIDLabel.AccessibleDescription = "";
            this.VENDEDORIDLabel.AutoSize = true;
            this.VENDEDORIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.VENDEDORIDLabel.ForeColor = System.Drawing.Color.White;
            this.VENDEDORIDLabel.Location = new System.Drawing.Point(56, 48);
            this.VENDEDORIDLabel.Name = "VENDEDORIDLabel";
            this.VENDEDORIDLabel.Size = new System.Drawing.Size(53, 13);
            this.VENDEDORIDLabel.TabIndex = 182;
            this.VENDEDORIDLabel.Text = "Cobrador:";
            // 
            // btnRecibir
            // 
            this.btnRecibir.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnRecibir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnRecibir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecibir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnRecibir.ForeColor = System.Drawing.Color.White;
            this.btnRecibir.Location = new System.Drawing.Point(121, 168);
            this.btnRecibir.Name = "btnRecibir";
            this.btnRecibir.Size = new System.Drawing.Size(82, 25);
            this.btnRecibir.TabIndex = 186;
            this.btnRecibir.Text = "Enviar";
            this.btnRecibir.UseVisualStyleBackColor = false;
            this.btnRecibir.Click += new System.EventHandler(this.btnRecibir_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(121, 139);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(163, 23);
            this.progressBar1.TabIndex = 187;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "";
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 195;
            this.label1.Text = "Fecha:";
            // 
            // FECHATextBox
            // 
            this.FECHATextBox.Location = new System.Drawing.Point(115, 75);
            this.FECHATextBox.Name = "FECHATextBox";
            this.FECHATextBox.Size = new System.Drawing.Size(215, 20);
            this.FECHATextBox.TabIndex = 194;
            // 
            // CBAndroid
            // 
            this.CBAndroid.AutoSize = true;
            this.CBAndroid.BackColor = System.Drawing.Color.Transparent;
            this.CBAndroid.ForeColor = System.Drawing.Color.White;
            this.CBAndroid.Location = new System.Drawing.Point(402, 104);
            this.CBAndroid.Name = "CBAndroid";
            this.CBAndroid.Size = new System.Drawing.Size(62, 17);
            this.CBAndroid.TabIndex = 196;
            this.CBAndroid.Text = "Android";
            this.CBAndroid.UseVisualStyleBackColor = false;
            // 
            // CBExpProdInactivos
            // 
            this.CBExpProdInactivos.AutoSize = true;
            this.CBExpProdInactivos.BackColor = System.Drawing.Color.Transparent;
            this.CBExpProdInactivos.ForeColor = System.Drawing.Color.White;
            this.CBExpProdInactivos.Location = new System.Drawing.Point(402, 145);
            this.CBExpProdInactivos.Name = "CBExpProdInactivos";
            this.CBExpProdInactivos.Size = new System.Drawing.Size(222, 17);
            this.CBExpProdInactivos.TabIndex = 197;
            this.CBExpProdInactivos.Text = "Enviar productos inactivos con existencia";
            this.CBExpProdInactivos.UseVisualStyleBackColor = false;
            // 
            // WFGenerarDatosParaMovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(631, 201);
            this.Controls.Add(this.CBExpProdInactivos);
            this.Controls.Add(this.CBAndroid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FECHATextBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnRecibir);
            this.Controls.Add(this.CobradorLabel);
            this.Controls.Add(this.COBRADORIDTextBox);
            this.Controls.Add(this.VENDEDORIDLabel);
            this.Controls.Add(this.VENDEDORButton);
            this.Name = "WFGenerarDatosParaMovil";
            this.Text = "Generar datos para movil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CobradorLabel;
        private Tools.TextBoxFB COBRADORIDTextBox;
        private System.Windows.Forms.Button VENDEDORButton;
        private System.Windows.Forms.Label VENDEDORIDLabel;
        private System.Windows.Forms.Button btnRecibir;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FECHATextBox;
        private System.Windows.Forms.CheckBox CBAndroid;
        private System.Windows.Forms.CheckBox CBExpProdInactivos;
    }
}