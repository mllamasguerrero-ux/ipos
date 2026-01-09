namespace iPos
{
    partial class WFExportarTodo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFExportarTodo));
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.BTExportar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DateTo = new System.Windows.Forms.DateTimePicker();
            this.DateFrom = new System.Windows.Forms.DateTimePicker();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSeleccionarPedido = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBTipoStock = new System.Windows.Forms.ComboBox();
            this.CBIncluirApartadoStock = new System.Windows.Forms.CheckBox();
            this.btnPedidoxStock = new System.Windows.Forms.Button();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlPedidoxFecha = new System.Windows.Forms.Panel();
            this.CBIncluirApartado = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.dateDBF = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlPedidoxFecha.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(53, 97);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 33);
            this.button1.TabIndex = 6;
            this.button1.Text = "Exportar todo a FTP";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(275, 107);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(208, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // BTExportar
            // 
            this.BTExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTExportar.ForeColor = System.Drawing.Color.White;
            this.BTExportar.Location = new System.Drawing.Point(236, 74);
            this.BTExportar.Name = "BTExportar";
            this.BTExportar.Size = new System.Drawing.Size(87, 23);
            this.BTExportar.TabIndex = 5;
            this.BTExportar.Text = "Exportar";
            this.BTExportar.UseVisualStyleBackColor = false;
            this.BTExportar.Click += new System.EventHandler(this.BTExportar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "A la fecha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "De la fecha:";
            // 
            // DateTo
            // 
            this.DateTo.Location = new System.Drawing.Point(90, 48);
            this.DateTo.Name = "DateTo";
            this.DateTo.Size = new System.Drawing.Size(233, 20);
            this.DateTo.TabIndex = 3;
            this.DateTo.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // DateFrom
            // 
            this.DateFrom.Location = new System.Drawing.Point(90, 22);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Size = new System.Drawing.Size(233, 20);
            this.DateFrom.TabIndex = 2;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(330, 74);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(147, 23);
            this.progressBar2.TabIndex = 4;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(274, 91);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 56);
            this.button2.TabIndex = 7;
            this.button2.Text = "Exportar todas las existencias (mas lento todos los productos)";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(14, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(538, 264);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.tabPage1.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.pnlPedidoxFecha);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(530, 238);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Exportar pedidos";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnSeleccionarPedido);
            this.panel2.Controls.Add(this.label6);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(7, 188);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(513, 44);
            this.panel2.TabIndex = 4;
            // 
            // btnSeleccionarPedido
            // 
            this.btnSeleccionarPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnSeleccionarPedido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSeleccionarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarPedido.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarPedido.Location = new System.Drawing.Point(236, 14);
            this.btnSeleccionarPedido.Name = "btnSeleccionarPedido";
            this.btnSeleccionarPedido.Size = new System.Drawing.Size(199, 23);
            this.btnSeleccionarPedido.TabIndex = 13;
            this.btnSeleccionarPedido.Text = "Seleccionar envios anteriores";
            this.btnSeleccionarPedido.UseVisualStyleBackColor = false;
            this.btnSeleccionarPedido.Click += new System.EventHandler(this.btnSeleccionarPedido_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(230, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Seleccionar o revisar envíos anteriores";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.CBTipoStock);
            this.panel1.Controls.Add(this.CBIncluirApartadoStock);
            this.panel1.Controls.Add(this.btnPedidoxStock);
            this.panel1.Controls.Add(this.progressBar4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(7, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 66);
            this.panel1.TabIndex = 3;
            // 
            // CBTipoStock
            // 
            this.CBTipoStock.FormattingEnabled = true;
            this.CBTipoStock.Items.AddRange(new object[] {
            "Stock Minimo",
            "Stock Maximo"});
            this.CBTipoStock.Location = new System.Drawing.Point(10, 22);
            this.CBTipoStock.Name = "CBTipoStock";
            this.CBTipoStock.Size = new System.Drawing.Size(121, 21);
            this.CBTipoStock.TabIndex = 14;
            // 
            // CBIncluirApartadoStock
            // 
            this.CBIncluirApartadoStock.AutoSize = true;
            this.CBIncluirApartadoStock.Checked = true;
            this.CBIncluirApartadoStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBIncluirApartadoStock.ForeColor = System.Drawing.Color.White;
            this.CBIncluirApartadoStock.Location = new System.Drawing.Point(357, 16);
            this.CBIncluirApartadoStock.Name = "CBIncluirApartadoStock";
            this.CBIncluirApartadoStock.Size = new System.Drawing.Size(115, 17);
            this.CBIncluirApartadoStock.TabIndex = 13;
            this.CBIncluirApartadoStock.Text = "Incluir apartado";
            this.CBIncluirApartadoStock.UseVisualStyleBackColor = true;
            // 
            // btnPedidoxStock
            // 
            this.btnPedidoxStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnPedidoxStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnPedidoxStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedidoxStock.ForeColor = System.Drawing.Color.White;
            this.btnPedidoxStock.Location = new System.Drawing.Point(236, 36);
            this.btnPedidoxStock.Name = "btnPedidoxStock";
            this.btnPedidoxStock.Size = new System.Drawing.Size(87, 23);
            this.btnPedidoxStock.TabIndex = 12;
            this.btnPedidoxStock.Text = "Exportar";
            this.btnPedidoxStock.UseVisualStyleBackColor = false;
            this.btnPedidoxStock.Click += new System.EventHandler(this.btnPedidoxStock_Click);
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(330, 36);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(147, 23);
            this.progressBar4.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Generar un pedido por máximos y mínimos";
            // 
            // pnlPedidoxFecha
            // 
            this.pnlPedidoxFecha.BackColor = System.Drawing.Color.Transparent;
            this.pnlPedidoxFecha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPedidoxFecha.Controls.Add(this.CBIncluirApartado);
            this.pnlPedidoxFecha.Controls.Add(this.label4);
            this.pnlPedidoxFecha.Controls.Add(this.label1);
            this.pnlPedidoxFecha.Controls.Add(this.DateFrom);
            this.pnlPedidoxFecha.Controls.Add(this.label2);
            this.pnlPedidoxFecha.Controls.Add(this.BTExportar);
            this.pnlPedidoxFecha.Controls.Add(this.DateTo);
            this.pnlPedidoxFecha.Controls.Add(this.progressBar2);
            this.pnlPedidoxFecha.ForeColor = System.Drawing.Color.White;
            this.pnlPedidoxFecha.Location = new System.Drawing.Point(7, 6);
            this.pnlPedidoxFecha.Name = "pnlPedidoxFecha";
            this.pnlPedidoxFecha.Size = new System.Drawing.Size(513, 104);
            this.pnlPedidoxFecha.TabIndex = 2;
            // 
            // CBIncluirApartado
            // 
            this.CBIncluirApartado.AutoSize = true;
            this.CBIncluirApartado.Checked = true;
            this.CBIncluirApartado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBIncluirApartado.ForeColor = System.Drawing.Color.White;
            this.CBIncluirApartado.Location = new System.Drawing.Point(356, 50);
            this.CBIncluirApartado.Name = "CBIncluirApartado";
            this.CBIncluirApartado.Size = new System.Drawing.Size(115, 17);
            this.CBIncluirApartado.TabIndex = 10;
            this.CBIncluirApartado.Text = "Incluir apartado";
            this.CBIncluirApartado.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Generar un pedido por rango de fecha";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(530, 238);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Exportar todo";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.tabPage3.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(530, 238);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Exportar existencias";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(62, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 56);
            this.button3.TabIndex = 8;
            this.button3.Text = "Exportar existencias de los productos con movimientos ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.tabPage4.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage4.Controls.Add(this.progressBar3);
            this.tabPage4.Controls.Add(this.dateDBF);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(530, 238);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Exportar DBF de pedido";
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(114, 169);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(299, 23);
            this.progressBar3.TabIndex = 10;
            // 
            // dateDBF
            // 
            this.dateDBF.Location = new System.Drawing.Point(100, 104);
            this.dateDBF.Name = "dateDBF";
            this.dateDBF.Size = new System.Drawing.Size(233, 20);
            this.dateDBF.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(17, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "De la fecha:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(375, 89);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 54);
            this.button4.TabIndex = 0;
            this.button4.Text = "Exportar pedido DBF de crescendo";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.WorkerReportsProgress = true;
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            this.backgroundWorker4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker4_RunWorkerCompleted);
            // 
            // WFExportarTodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(562, 301);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFExportarTodo";
            this.Text = "Exportaciones";
            this.Load += new System.EventHandler(this.WFExportarTodo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlPedidoxFecha.ResumeLayout(false);
            this.pnlPedidoxFecha.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateTo;
        private System.Windows.Forms.DateTimePicker DateFrom;
        private System.Windows.Forms.ProgressBar progressBar2;
        public System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button BTExportar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker dateDBF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar3;
        public System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Panel pnlPedidoxFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSeleccionarPedido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPedidoxStock;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CBIncluirApartado;
        private System.Windows.Forms.CheckBox CBIncluirApartadoStock;
        public System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.Windows.Forms.ComboBox CBTipoStock;
    }
}