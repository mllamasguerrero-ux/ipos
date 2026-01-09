namespace iPos.Reportes.Entradas
{
    partial class WFReporteFactCompraSuc
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
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.CBFecha = new System.Windows.Forms.CheckBox();
            this.CBProveedor = new System.Windows.Forms.CheckBox();
            this.ITEMButton = new System.Windows.Forms.Button();
            this.ITEMLabel = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.ITEMIDTextBox = new iPos.Tools.TextBoxFB();
            this.label1 = new System.Windows.Forms.Label();
            this.BTBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(436, 49);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(233, 20);
            this.dateTimePicker2.TabIndex = 242;
            // 
            // CBFecha
            // 
            this.CBFecha.AutoSize = true;
            this.CBFecha.BackColor = System.Drawing.Color.Transparent;
            this.CBFecha.Checked = true;
            this.CBFecha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBFecha.ForeColor = System.Drawing.Color.White;
            this.CBFecha.Location = new System.Drawing.Point(9, 54);
            this.CBFecha.Name = "CBFecha";
            this.CBFecha.Size = new System.Drawing.Size(129, 17);
            this.CBFecha.TabIndex = 237;
            this.CBFecha.Text = "Registros de la Fecha";
            this.CBFecha.UseVisualStyleBackColor = false;
            // 
            // CBProveedor
            // 
            this.CBProveedor.AutoSize = true;
            this.CBProveedor.BackColor = System.Drawing.Color.Transparent;
            this.CBProveedor.ForeColor = System.Drawing.Color.Transparent;
            this.CBProveedor.Location = new System.Drawing.Point(9, 88);
            this.CBProveedor.Name = "CBProveedor";
            this.CBProveedor.Size = new System.Drawing.Size(75, 17);
            this.CBProveedor.TabIndex = 241;
            this.CBProveedor.Text = "Proveedor";
            this.CBProveedor.UseVisualStyleBackColor = false;
            // 
            // ITEMButton
            // 
            this.ITEMButton.BackColor = System.Drawing.Color.Transparent;
            this.ITEMButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(266, 87);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(23, 23);
            this.ITEMButton.TabIndex = 239;
            this.ITEMButton.UseVisualStyleBackColor = false;
            // 
            // ITEMLabel
            // 
            this.ITEMLabel.AutoSize = true;
            this.ITEMLabel.BackColor = System.Drawing.Color.Transparent;
            this.ITEMLabel.ForeColor = System.Drawing.Color.White;
            this.ITEMLabel.Location = new System.Drawing.Point(293, 92);
            this.ITEMLabel.Name = "ITEMLabel";
            this.ITEMLabel.Size = new System.Drawing.Size(16, 13);
            this.ITEMLabel.TabIndex = 240;
            this.ITEMLabel.Text = "...";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(165, 49);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(233, 20);
            this.dateTimePicker1.TabIndex = 236;
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
            this.ITEMIDTextBox.LabelDescription = this.ITEMLabel;
            this.ITEMIDTextBox.Location = new System.Drawing.Point(165, 88);
            this.ITEMIDTextBox.MostrarErrores = true;
            this.ITEMIDTextBox.Name = "ITEMIDTextBox";
            this.ITEMIDTextBox.NombreCampoSelector = "clave";
            this.ITEMIDTextBox.NombreCampoValue = "id";
            this.ITEMIDTextBox.Query = "select id, clave, nombre, gaffete from persona where tipopersonaid  in (40) ";
            this.ITEMIDTextBox.QueryDeSeleccion = "select id, clave, nombre, gaffete from persona where tipopersonaid  in (40) and  " +
    "clave= @clave";
            this.ITEMIDTextBox.QueryPorDBValue = "select id, clave ,nombre, gaffete from persona where tipopersonaid  in (40) and  " +
    "id = @id";
            this.ITEMIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.ITEMIDTextBox.TabIndex = 238;
            this.ITEMIDTextBox.Tag = 34;
            this.ITEMIDTextBox.TextDescription = null;
            this.ITEMIDTextBox.Titulo = "Proveedores";
            this.ITEMIDTextBox.ValidarEntrada = true;
            this.ITEMIDTextBox.ValidationExpression = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 13);
            this.label1.TabIndex = 243;
            this.label1.Text = "REPORTE DE FACTURAS ORIGINALES CON DIFERENCIA";
            // 
            // BTBuscar
            // 
            this.BTBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTBuscar.ForeColor = System.Drawing.Color.White;
            this.BTBuscar.Location = new System.Drawing.Point(299, 119);
            this.BTBuscar.Name = "BTBuscar";
            this.BTBuscar.Size = new System.Drawing.Size(87, 23);
            this.BTBuscar.TabIndex = 244;
            this.BTBuscar.Text = "Buscar";
            this.BTBuscar.UseVisualStyleBackColor = false;
            this.BTBuscar.Click += new System.EventHandler(this.BTBuscar_Click);
            // 
            // WFReporteFactCompraSuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(684, 172);
            this.Controls.Add(this.BTBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.CBFecha);
            this.Controls.Add(this.CBProveedor);
            this.Controls.Add(this.ITEMButton);
            this.Controls.Add(this.ITEMLabel);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.ITEMIDTextBox);
            this.Name = "WFReporteFactCompraSuc";
            this.Text = "WFReporteFactCompraSuc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.CheckBox CBFecha;
        private System.Windows.Forms.CheckBox CBProveedor;
        private System.Windows.Forms.Button ITEMButton;
        private System.Windows.Forms.Label ITEMLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Tools.TextBoxFB ITEMIDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTBuscar;
    }
}