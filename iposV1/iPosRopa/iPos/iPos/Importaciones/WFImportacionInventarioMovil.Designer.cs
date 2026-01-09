namespace iPos.Importaciones
{
    partial class WFImportacionInventarioMovil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFImportacionInventarioMovil));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.productosInventarioListView = new System.Windows.Forms.ListView();
            this.idMovto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.almacenClave = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productoClave = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cantidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fechaVence = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.datosInventarioListView = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sucursal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dispositivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.estatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 465);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.productosInventarioListView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(481, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(483, 465);
            this.panel3.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(199, 418);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "Importar actual";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(53, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Productos de Inventario";
            // 
            // productosInventarioListView
            // 
            this.productosInventarioListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idMovto,
            this.almacenClave,
            this.lote,
            this.productoClave,
            this.cantidad,
            this.fechaVence});
            this.productosInventarioListView.Location = new System.Drawing.Point(11, 46);
            this.productosInventarioListView.Name = "productosInventarioListView";
            this.productosInventarioListView.Size = new System.Drawing.Size(472, 341);
            this.productosInventarioListView.TabIndex = 1;
            this.productosInventarioListView.UseCompatibleStateImageBehavior = false;
            this.productosInventarioListView.View = System.Windows.Forms.View.Details;
            this.productosInventarioListView.SelectedIndexChanged += new System.EventHandler(this.productosInventarioListView_SelectedIndexChanged);
            // 
            // idMovto
            // 
            this.idMovto.DisplayIndex = 5;
            this.idMovto.Text = "ID Movto";
            // 
            // almacenClave
            // 
            this.almacenClave.DisplayIndex = 0;
            this.almacenClave.Text = "Almacen";
            this.almacenClave.Width = 83;
            // 
            // lote
            // 
            this.lote.Text = "Lote";
            this.lote.Width = 71;
            // 
            // productoClave
            // 
            this.productoClave.DisplayIndex = 1;
            this.productoClave.Text = "Producto";
            this.productoClave.Width = 146;
            // 
            // cantidad
            // 
            this.cantidad.Text = "Cantidad";
            this.cantidad.Width = 147;
            // 
            // fechaVence
            // 
            this.fechaVence.DisplayIndex = 3;
            this.fechaVence.Text = "Caducidad";
            this.fechaVence.Width = 87;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.datosInventarioListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(481, 465);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(286, 418);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 35);
            this.button3.TabIndex = 3;
            this.button3.Text = "Importar seleccionados";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Importar todos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Datos de Inventarios";
            // 
            // datosInventarioListView
            // 
            this.datosInventarioListView.BackColor = System.Drawing.SystemColors.Window;
            this.datosInventarioListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.sucursal,
            this.usuario,
            this.dispositivo,
            this.estatus,
            this.fecha});
            this.datosInventarioListView.Location = new System.Drawing.Point(12, 46);
            this.datosInventarioListView.Name = "datosInventarioListView";
            this.datosInventarioListView.Size = new System.Drawing.Size(450, 341);
            this.datosInventarioListView.TabIndex = 0;
            this.datosInventarioListView.UseCompatibleStateImageBehavior = false;
            this.datosInventarioListView.View = System.Windows.Forms.View.Details;
            this.datosInventarioListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.datosInventarioListView_ItemSelectionChanged);
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 56;
            // 
            // sucursal
            // 
            this.sucursal.Text = "Sucursal";
            this.sucursal.Width = 117;
            // 
            // usuario
            // 
            this.usuario.Text = "Usuario";
            this.usuario.Width = 119;
            // 
            // dispositivo
            // 
            this.dispositivo.Text = "Dispositivo";
            this.dispositivo.Width = 111;
            // 
            // estatus
            // 
            this.estatus.Text = "Estatus";
            this.estatus.Width = 90;
            // 
            // fecha
            // 
            this.fecha.Text = "Fecha";
            this.fecha.Width = 180;
            // 
            // WFImportacionInventarioMovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(964, 465);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFImportacionInventarioMovil";
            this.Text = "Importación de Inventario Móvil";
            this.Load += new System.EventHandler(this.WFImportacionInventarioMovil_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView productosInventarioListView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView datosInventarioListView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader sucursal;
        private System.Windows.Forms.ColumnHeader usuario;
        private System.Windows.Forms.ColumnHeader dispositivo;
        private System.Windows.Forms.ColumnHeader almacenClave;
        private System.Windows.Forms.ColumnHeader productoClave;
        private System.Windows.Forms.ColumnHeader lote;
        private System.Windows.Forms.ColumnHeader fechaVence;
        private System.Windows.Forms.ColumnHeader cantidad;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColumnHeader estatus;
        private System.Windows.Forms.ColumnHeader fecha;
        public System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader idMovto;
    }
}