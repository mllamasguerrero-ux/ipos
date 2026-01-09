namespace iPos.PuntoDeVenta
{
    partial class WFSeleccionarRutaEmbarque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFSeleccionarRutaEmbarque));
            this.LBClienteNombre = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ITEMButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ITEMIDTextBox = new iPos.Tools.TextBoxFB();
            this.SuspendLayout();
            // 
            // LBClienteNombre
            // 
            this.LBClienteNombre.AutoSize = true;
            this.LBClienteNombre.BackColor = System.Drawing.Color.Transparent;
            this.LBClienteNombre.Enabled = false;
            this.LBClienteNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBClienteNombre.ForeColor = System.Drawing.Color.White;
            this.LBClienteNombre.Location = new System.Drawing.Point(250, 82);
            this.LBClienteNombre.Name = "LBClienteNombre";
            this.LBClienteNombre.Size = new System.Drawing.Size(25, 24);
            this.LBClienteNombre.TabIndex = 173;
            this.LBClienteNombre.Text = "...";
            this.LBClienteNombre.Click += new System.EventHandler(this.LBClienteNombre_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(173, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 39);
            this.button1.TabIndex = 174;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ITEMButton
            // 
            this.ITEMButton.BackColor = System.Drawing.Color.Transparent;
            this.ITEMButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(223, 83);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(23, 23);
            this.ITEMButton.TabIndex = 176;
            this.ITEMButton.UseVisualStyleBackColor = false;
            this.ITEMButton.Click += new System.EventHandler(this.ITEMButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(130, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 177;
            this.label1.Text = "Ruta de embarque";
            // 
            // ITEMIDTextBox
            // 
            this.ITEMIDTextBox.BotonLookUp = null;
            this.ITEMIDTextBox.Condicion = null;
            this.ITEMIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbValue = null;
            this.ITEMIDTextBox.Format_Expression = null;
            this.ITEMIDTextBox.IndiceCampoDescripcion = 2;
            this.ITEMIDTextBox.IndiceCampoSelector = 1;
            this.ITEMIDTextBox.IndiceCampoValue = 0;
            this.ITEMIDTextBox.LabelDescription = this.LBClienteNombre;
            this.ITEMIDTextBox.Location = new System.Drawing.Point(135, 86);
            this.ITEMIDTextBox.MostrarErrores = true;
            this.ITEMIDTextBox.Name = "ITEMIDTextBox";
            this.ITEMIDTextBox.NombreCampoSelector = "clave";
            this.ITEMIDTextBox.NombreCampoValue = "id";
            this.ITEMIDTextBox.Query = "select id,clave,nombre from rutaembarque";
            this.ITEMIDTextBox.QueryDeSeleccion = "select id,clave,nombre from rutaembarque where clave = @clave";
            this.ITEMIDTextBox.QueryPorDBValue = "select id,clave,nombre from rutaembarque where id = @id";
            this.ITEMIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.ITEMIDTextBox.TabIndex = 175;
            this.ITEMIDTextBox.Tag = 34;
            this.ITEMIDTextBox.TextDescription = null;
            this.ITEMIDTextBox.Titulo = "Rutas de Embarque";
            this.ITEMIDTextBox.ValidarEntrada = true;
            this.ITEMIDTextBox.ValidationExpression = null;
            this.ITEMIDTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ITEMIDTextBox_KeyDown);
            // 
            // WFSeleccionarRutaEmbarque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(452, 193);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ITEMButton);
            this.Controls.Add(this.ITEMIDTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LBClienteNombre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFSeleccionarRutaEmbarque";
            this.Text = "Seleccionar Ruta Embarque";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFSeleccionarRutaEmbarque_FormClosing);
            this.Load += new System.EventHandler(this.WFSeleccionarRutaEmbarque_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBClienteNombre;
        private System.Windows.Forms.Button button1;
        private Tools.TextBoxFB ITEMIDTextBox;
        private System.Windows.Forms.Button ITEMButton;
        private System.Windows.Forms.Label label1;
    }
}