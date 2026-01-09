namespace iPos.Utilerias.Procesos
{
    partial class WFBajaSaldosMenores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFBajaSaldosMenores));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TextBoxMontoParametro = new System.Windows.Forms.Label();
            this.CheckBoxTodosClientes = new System.Windows.Forms.CheckBox();
            this.CheckBoxTodosProveedores = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CheckBoxSelectCliente = new System.Windows.Forms.CheckBox();
            this.CheckBoxSelectProveedor = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonProveedores = new System.Windows.Forms.Button();
            this.ProveedoresLabel = new System.Windows.Forms.Label();
            this.TextBoxProveedor = new iPos.Tools.TextBoxFB();
            this.ButtonClientes = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.LabelClientes = new System.Windows.Forms.Label();
            this.TextBoxCliente = new iPos.Tools.TextBoxFB();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.MONTOMAXSALDOMENORNumericTextBox = new System.Windows.Forms.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.storProcBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.TextBoxMontoParametro);
            this.panel1.Controls.Add(this.CheckBoxTodosClientes);
            this.panel1.Controls.Add(this.CheckBoxTodosProveedores);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.MONTOMAXSALDOMENORNumericTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Controls.Add(this.DTPFrom);
            this.panel1.Controls.Add(this.DTPTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 321);
            this.panel1.TabIndex = 12;
            // 
            // TextBoxMontoParametro
            // 
            this.TextBoxMontoParametro.AutoSize = true;
            this.TextBoxMontoParametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxMontoParametro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TextBoxMontoParametro.Location = new System.Drawing.Point(386, 207);
            this.TextBoxMontoParametro.Name = "TextBoxMontoParametro";
            this.TextBoxMontoParametro.Size = new System.Drawing.Size(136, 13);
            this.TextBoxMontoParametro.TabIndex = 183;
            this.TextBoxMontoParametro.Text = "Monto Maximo Actual: ";
            // 
            // CheckBoxTodosClientes
            // 
            this.CheckBoxTodosClientes.AutoSize = true;
            this.CheckBoxTodosClientes.Location = new System.Drawing.Point(612, 100);
            this.CheckBoxTodosClientes.Name = "CheckBoxTodosClientes";
            this.CheckBoxTodosClientes.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxTodosClientes.TabIndex = 182;
            this.CheckBoxTodosClientes.UseVisualStyleBackColor = true;
            // 
            // CheckBoxTodosProveedores
            // 
            this.CheckBoxTodosProveedores.AutoSize = true;
            this.CheckBoxTodosProveedores.Location = new System.Drawing.Point(612, 54);
            this.CheckBoxTodosProveedores.Name = "CheckBoxTodosProveedores";
            this.CheckBoxTodosProveedores.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxTodosProveedores.TabIndex = 181;
            this.CheckBoxTodosProveedores.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(633, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 180;
            this.label8.Text = "Todos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(633, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 179;
            this.label7.Text = "Todos";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CheckBoxSelectCliente);
            this.panel2.Controls.Add(this.CheckBoxSelectProveedor);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.ButtonProveedores);
            this.panel2.Controls.Add(this.ProveedoresLabel);
            this.panel2.Controls.Add(this.TextBoxProveedor);
            this.panel2.Controls.Add(this.ButtonClientes);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.LabelClientes);
            this.panel2.Controls.Add(this.TextBoxCliente);
            this.panel2.Location = new System.Drawing.Point(28, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(578, 85);
            this.panel2.TabIndex = 178;
            // 
            // CheckBoxSelectCliente
            // 
            this.CheckBoxSelectCliente.AutoSize = true;
            this.CheckBoxSelectCliente.Location = new System.Drawing.Point(6, 56);
            this.CheckBoxSelectCliente.Name = "CheckBoxSelectCliente";
            this.CheckBoxSelectCliente.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxSelectCliente.TabIndex = 180;
            this.CheckBoxSelectCliente.UseVisualStyleBackColor = true;
            // 
            // CheckBoxSelectProveedor
            // 
            this.CheckBoxSelectProveedor.AutoSize = true;
            this.CheckBoxSelectProveedor.Location = new System.Drawing.Point(6, 9);
            this.CheckBoxSelectProveedor.Name = "CheckBoxSelectProveedor";
            this.CheckBoxSelectProveedor.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxSelectProveedor.TabIndex = 179;
            this.CheckBoxSelectProveedor.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(23, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 167;
            this.label4.Text = "Proveedor:";
            // 
            // ButtonProveedores
            // 
            this.ButtonProveedores.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonProveedores.BackgroundImage")));
            this.ButtonProveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonProveedores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ButtonProveedores.Location = new System.Drawing.Point(201, 5);
            this.ButtonProveedores.Name = "ButtonProveedores";
            this.ButtonProveedores.Size = new System.Drawing.Size(23, 23);
            this.ButtonProveedores.TabIndex = 164;
            this.ButtonProveedores.UseVisualStyleBackColor = true;
            // 
            // ProveedoresLabel
            // 
            this.ProveedoresLabel.AutoSize = true;
            this.ProveedoresLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ProveedoresLabel.Location = new System.Drawing.Point(228, 9);
            this.ProveedoresLabel.Name = "ProveedoresLabel";
            this.ProveedoresLabel.Size = new System.Drawing.Size(16, 13);
            this.ProveedoresLabel.TabIndex = 166;
            this.ProveedoresLabel.Text = "...";
            // 
            // TextBoxProveedor
            // 
            this.TextBoxProveedor.BotonLookUp = this.ButtonProveedores;
            this.TextBoxProveedor.Condicion = null;
            this.TextBoxProveedor.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TextBoxProveedor.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TextBoxProveedor.DbValue = null;
            this.TextBoxProveedor.Format_Expression = null;
            this.TextBoxProveedor.IndiceCampoDescripcion = 2;
            this.TextBoxProveedor.IndiceCampoSelector = 1;
            this.TextBoxProveedor.IndiceCampoValue = 0;
            this.TextBoxProveedor.LabelDescription = this.ProveedoresLabel;
            this.TextBoxProveedor.Location = new System.Drawing.Point(113, 7);
            this.TextBoxProveedor.MostrarErrores = true;
            this.TextBoxProveedor.Name = "TextBoxProveedor";
            this.TextBoxProveedor.NombreCampoSelector = "clave";
            this.TextBoxProveedor.NombreCampoValue = "id";
            this.TextBoxProveedor.Query = "select id,clave,nombre from persona where tipopersonaid in (40)";
            this.TextBoxProveedor.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid in (40) and  clave= @clav" +
    "e";
            this.TextBoxProveedor.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid in (40) and  id = @id";
            this.TextBoxProveedor.Size = new System.Drawing.Size(82, 20);
            this.TextBoxProveedor.TabIndex = 163;
            this.TextBoxProveedor.Tag = 34;
            this.TextBoxProveedor.TextDescription = null;
            this.TextBoxProveedor.Titulo = "Proveedores";
            this.TextBoxProveedor.ValidarEntrada = true;
            this.TextBoxProveedor.ValidationExpression = null;
            // 
            // ButtonClientes
            // 
            this.ButtonClientes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonClientes.BackgroundImage")));
            this.ButtonClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ButtonClientes.Location = new System.Drawing.Point(201, 50);
            this.ButtonClientes.Name = "ButtonClientes";
            this.ButtonClientes.Size = new System.Drawing.Size(23, 23);
            this.ButtonClientes.TabIndex = 170;
            this.ButtonClientes.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(23, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 172;
            this.label5.Text = "Cliente:";
            // 
            // LabelClientes
            // 
            this.LabelClientes.AutoSize = true;
            this.LabelClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LabelClientes.Location = new System.Drawing.Point(228, 55);
            this.LabelClientes.Name = "LabelClientes";
            this.LabelClientes.Size = new System.Drawing.Size(16, 13);
            this.LabelClientes.TabIndex = 171;
            this.LabelClientes.Text = "...";
            // 
            // TextBoxCliente
            // 
            this.TextBoxCliente.BotonLookUp = this.ButtonClientes;
            this.TextBoxCliente.Condicion = null;
            this.TextBoxCliente.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TextBoxCliente.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TextBoxCliente.DbValue = null;
            this.TextBoxCliente.Format_Expression = null;
            this.TextBoxCliente.IndiceCampoDescripcion = 2;
            this.TextBoxCliente.IndiceCampoSelector = 1;
            this.TextBoxCliente.IndiceCampoValue = 0;
            this.TextBoxCliente.LabelDescription = this.LabelClientes;
            this.TextBoxCliente.Location = new System.Drawing.Point(113, 52);
            this.TextBoxCliente.MostrarErrores = true;
            this.TextBoxCliente.Name = "TextBoxCliente";
            this.TextBoxCliente.NombreCampoSelector = "clave";
            this.TextBoxCliente.NombreCampoValue = "id";
            this.TextBoxCliente.Query = "select id,clave,nombre from persona where tipopersonaid in (50)";
            this.TextBoxCliente.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid in (50) and  clave= @clav" +
    "e";
            this.TextBoxCliente.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid in (50) and  id = @id";
            this.TextBoxCliente.Size = new System.Drawing.Size(82, 20);
            this.TextBoxCliente.TabIndex = 169;
            this.TextBoxCliente.Tag = 34;
            this.TextBoxCliente.TextDescription = null;
            this.TextBoxCliente.Titulo = "Clientes";
            this.TextBoxCliente.ValidarEntrada = true;
            this.TextBoxCliente.ValidationExpression = null;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(212, 271);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(464, 23);
            this.progressBar1.TabIndex = 177;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(25, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 176;
            this.label6.Text = "Monto: ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // MONTOMAXSALDOMENORNumericTextBox
            // 
            this.MONTOMAXSALDOMENORNumericTextBox.AllowNegative = false;
            this.MONTOMAXSALDOMENORNumericTextBox.Format_Expression = null;
            this.MONTOMAXSALDOMENORNumericTextBox.Location = new System.Drawing.Point(187, 200);
            this.MONTOMAXSALDOMENORNumericTextBox.Name = "MONTOMAXSALDOMENORNumericTextBox";
            this.MONTOMAXSALDOMENORNumericTextBox.NumericPrecision = 18;
            this.MONTOMAXSALDOMENORNumericTextBox.NumericScaleOnFocus = 2;
            this.MONTOMAXSALDOMENORNumericTextBox.NumericScaleOnLostFocus = 2;
            this.MONTOMAXSALDOMENORNumericTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MONTOMAXSALDOMENORNumericTextBox.Size = new System.Drawing.Size(113, 20);
            this.MONTOMAXSALDOMENORNumericTextBox.TabIndex = 175;
            this.MONTOMAXSALDOMENORNumericTextBox.Tag = 34;
            this.MONTOMAXSALDOMENORNumericTextBox.Text = "0.00";
            this.MONTOMAXSALDOMENORNumericTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MONTOMAXSALDOMENORNumericTextBox.ValidationExpression = null;
            this.MONTOMAXSALDOMENORNumericTextBox.ZeroIsValid = true;
            this.MONTOMAXSALDOMENORNumericTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.MONTOMAXSALDOMENORNumericTextBox_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(31, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "BAJA DE SALDOS MENORES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(25, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.BTEnviar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTEnviar.Location = new System.Drawing.Point(120, 269);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 25);
            this.BTEnviar.TabIndex = 5;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // DTPFrom
            // 
            this.DTPFrom.Location = new System.Drawing.Point(100, 148);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(200, 20);
            this.DTPFrom.TabIndex = 3;
            // 
            // DTPTo
            // 
            this.DTPTo.Location = new System.Drawing.Point(410, 148);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(200, 20);
            this.DTPTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(386, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "a:";
            // 
            // storProcBackgroundWorker
            // 
            this.storProcBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.storProcBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // WFBajaSaldosMenores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(768, 320);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFBajaSaldosMenores";
            this.Text = "Baja de Saldos Menores";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private Tools.TextBoxFB TextBoxProveedor;
        private System.Windows.Forms.Button ButtonProveedores;
        private System.Windows.Forms.Label ProveedoresLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private Tools.TextBoxFB TextBoxCliente;
        private System.Windows.Forms.Button ButtonClientes;
        private System.Windows.Forms.Label LabelClientes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericTextBox MONTOMAXSALDOMENORNumericTextBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker storProcBackgroundWorker;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox CheckBoxSelectCliente;
        private System.Windows.Forms.CheckBox CheckBoxSelectProveedor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox CheckBoxTodosClientes;
        private System.Windows.Forms.CheckBox CheckBoxTodosProveedores;
        private System.Windows.Forms.Label TextBoxMontoParametro;
    }
}