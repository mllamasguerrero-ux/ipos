namespace iPos
{
    partial class WFSaldosAplicacion
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFSaldosAplicacion));
            this.btnListaTransaccione = new System.Windows.Forms.Button();
            this.LBCliente = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFolioFacturado = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPersona = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.lbClieCP = new System.Windows.Forms.Label();
            this.lbClieTel = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lbClieCiudad = new System.Windows.Forms.Label();
            this.lbClieEstado = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbClieDom = new System.Windows.Forms.Label();
            this.lbClieColonia = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbClieNombre = new System.Windows.Forms.Label();
            this.lbClieRFC = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.BTGuardar = new System.Windows.Forms.Button();
            this.dSPuntoDeVentaAux = new iPos.PuntoDeVenta.DSPuntoDeVentaAux();
            this.gET_CREDITO_LISTA_A_APLICARBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gET_CREDITO_LISTA_A_APLICARTableAdapter = new iPos.PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.GET_CREDITO_LISTA_A_APLICARTableAdapter();
            this.tableAdapterManager = new iPos.PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.TableAdapterManager();
            this.gET_CREDITO_LISTA_A_APLICARDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DGFECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFOLIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGSALDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGSALDOAAPLICAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSumaAAplicar = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_CREDITO_LISTA_A_APLICARBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_CREDITO_LISTA_A_APLICARDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListaTransaccione
            // 
            this.btnListaTransaccione.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnListaTransaccione.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnListaTransaccione.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListaTransaccione.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaTransaccione.ForeColor = System.Drawing.Color.White;
            this.btnListaTransaccione.Location = new System.Drawing.Point(24, 39);
            this.btnListaTransaccione.Name = "btnListaTransaccione";
            this.btnListaTransaccione.Size = new System.Drawing.Size(328, 28);
            this.btnListaTransaccione.TabIndex = 0;
            this.btnListaTransaccione.Text = "Transacciones con saldo a aplicar";
            this.btnListaTransaccione.UseVisualStyleBackColor = false;
            this.btnListaTransaccione.Click += new System.EventHandler(this.btnListaTransaccione_Click);
            // 
            // LBCliente
            // 
            this.LBCliente.AutoSize = true;
            this.LBCliente.BackColor = System.Drawing.Color.Transparent;
            this.LBCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LBCliente.Location = new System.Drawing.Point(96, 70);
            this.LBCliente.Name = "LBCliente";
            this.LBCliente.Size = new System.Drawing.Size(46, 13);
            this.LBCliente.TabIndex = 75;
            this.LBCliente.Text = "Cliente";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblFolioFacturado);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblSaldo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.lblFolio);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(24, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 43);
            this.panel1.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(5, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Folio Facturado:";
            // 
            // lblFolioFacturado
            // 
            this.lblFolioFacturado.AutoSize = true;
            this.lblFolioFacturado.BackColor = System.Drawing.Color.Transparent;
            this.lblFolioFacturado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioFacturado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFolioFacturado.Location = new System.Drawing.Point(108, 25);
            this.lblFolioFacturado.Name = "lblFolioFacturado";
            this.lblFolioFacturado.Size = new System.Drawing.Size(19, 13);
            this.lblFolioFacturado.TabIndex = 44;
            this.lblFolioFacturado.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(594, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Saldo:";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.BackColor = System.Drawing.Color.Transparent;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSaldo.Location = new System.Drawing.Point(651, 0);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(19, 13);
            this.lblSaldo.TabIndex = 42;
            this.lblSaldo.Text = "...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(408, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTotal.Location = new System.Drawing.Point(469, 1);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(19, 13);
            this.lblTotal.TabIndex = 38;
            this.lblTotal.Text = "...";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label12.Location = new System.Drawing.Point(204, 2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Fecha:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFecha.Location = new System.Drawing.Point(265, 2);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(19, 13);
            this.lblFecha.TabIndex = 34;
            this.lblFecha.Text = "...";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label16.Location = new System.Drawing.Point(3, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "Folio:";
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.BackColor = System.Drawing.Color.Transparent;
            this.lblFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFolio.Location = new System.Drawing.Point(77, 2);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(19, 13);
            this.lblFolio.TabIndex = 20;
            this.lblFolio.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Transacción";
            // 
            // lblPersona
            // 
            this.lblPersona.AutoSize = true;
            this.lblPersona.BackColor = System.Drawing.Color.Transparent;
            this.lblPersona.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPersona.Location = new System.Drawing.Point(24, 70);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(46, 13);
            this.lblPersona.TabIndex = 72;
            this.lblPersona.Text = "Cliente";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.label26);
            this.panel11.Controls.Add(this.lbClieCP);
            this.panel11.Controls.Add(this.lbClieTel);
            this.panel11.Controls.Add(this.label29);
            this.panel11.Controls.Add(this.label22);
            this.panel11.Controls.Add(this.lbClieCiudad);
            this.panel11.Controls.Add(this.lbClieEstado);
            this.panel11.Controls.Add(this.label25);
            this.panel11.Controls.Add(this.label18);
            this.panel11.Controls.Add(this.lbClieDom);
            this.panel11.Controls.Add(this.lbClieColonia);
            this.panel11.Controls.Add(this.label21);
            this.panel11.Controls.Add(this.label4);
            this.panel11.Controls.Add(this.lbClieNombre);
            this.panel11.Controls.Add(this.lbClieRFC);
            this.panel11.Controls.Add(this.label17);
            this.panel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel11.Location = new System.Drawing.Point(24, 89);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(797, 38);
            this.panel11.TabIndex = 71;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(594, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(27, 13);
            this.label26.TabIndex = 41;
            this.label26.Text = "CP:";
            // 
            // lbClieCP
            // 
            this.lbClieCP.AutoSize = true;
            this.lbClieCP.BackColor = System.Drawing.Color.Transparent;
            this.lbClieCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieCP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieCP.Location = new System.Drawing.Point(651, 0);
            this.lbClieCP.Name = "lbClieCP";
            this.lbClieCP.Size = new System.Drawing.Size(19, 13);
            this.lbClieCP.TabIndex = 42;
            this.lbClieCP.Text = "...";
            // 
            // lbClieTel
            // 
            this.lbClieTel.AutoSize = true;
            this.lbClieTel.BackColor = System.Drawing.Color.Transparent;
            this.lbClieTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieTel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieTel.Location = new System.Drawing.Point(651, 19);
            this.lbClieTel.Name = "lbClieTel";
            this.lbClieTel.Size = new System.Drawing.Size(19, 13);
            this.lbClieTel.TabIndex = 43;
            this.lbClieTel.Text = "...";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(591, 19);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(33, 13);
            this.label29.TabIndex = 44;
            this.label29.Text = "Tel.:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(408, 1);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(50, 13);
            this.label22.TabIndex = 37;
            this.label22.Text = "Ciudad:";
            // 
            // lbClieCiudad
            // 
            this.lbClieCiudad.AutoSize = true;
            this.lbClieCiudad.BackColor = System.Drawing.Color.Transparent;
            this.lbClieCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieCiudad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieCiudad.Location = new System.Drawing.Point(469, 1);
            this.lbClieCiudad.Name = "lbClieCiudad";
            this.lbClieCiudad.Size = new System.Drawing.Size(19, 13);
            this.lbClieCiudad.TabIndex = 38;
            this.lbClieCiudad.Text = "...";
            // 
            // lbClieEstado
            // 
            this.lbClieEstado.AutoSize = true;
            this.lbClieEstado.BackColor = System.Drawing.Color.Transparent;
            this.lbClieEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieEstado.Location = new System.Drawing.Point(469, 20);
            this.lbClieEstado.Name = "lbClieEstado";
            this.lbClieEstado.Size = new System.Drawing.Size(19, 13);
            this.lbClieEstado.TabIndex = 39;
            this.lbClieEstado.Text = "...";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(409, 20);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(50, 13);
            this.label25.TabIndex = 40;
            this.label25.Text = "Estado:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(204, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "Domicilio:";
            // 
            // lbClieDom
            // 
            this.lbClieDom.AutoSize = true;
            this.lbClieDom.BackColor = System.Drawing.Color.Transparent;
            this.lbClieDom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieDom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieDom.Location = new System.Drawing.Point(265, 2);
            this.lbClieDom.Name = "lbClieDom";
            this.lbClieDom.Size = new System.Drawing.Size(19, 13);
            this.lbClieDom.TabIndex = 34;
            this.lbClieDom.Text = "...";
            // 
            // lbClieColonia
            // 
            this.lbClieColonia.AutoSize = true;
            this.lbClieColonia.BackColor = System.Drawing.Color.Transparent;
            this.lbClieColonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieColonia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieColonia.Location = new System.Drawing.Point(265, 21);
            this.lbClieColonia.Name = "lbClieColonia";
            this.lbClieColonia.Size = new System.Drawing.Size(19, 13);
            this.lbClieColonia.TabIndex = 35;
            this.lbClieColonia.Text = "...";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(205, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 36;
            this.label21.Text = "Colonia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Nombre:";
            // 
            // lbClieNombre
            // 
            this.lbClieNombre.AutoSize = true;
            this.lbClieNombre.BackColor = System.Drawing.Color.Transparent;
            this.lbClieNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieNombre.Location = new System.Drawing.Point(63, 2);
            this.lbClieNombre.Name = "lbClieNombre";
            this.lbClieNombre.Size = new System.Drawing.Size(19, 13);
            this.lbClieNombre.TabIndex = 20;
            this.lbClieNombre.Text = "...";
            // 
            // lbClieRFC
            // 
            this.lbClieRFC.AutoSize = true;
            this.lbClieRFC.BackColor = System.Drawing.Color.Transparent;
            this.lbClieRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClieRFC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbClieRFC.Location = new System.Drawing.Point(63, 21);
            this.lbClieRFC.Name = "lbClieRFC";
            this.lbClieRFC.Size = new System.Drawing.Size(19, 13);
            this.lbClieRFC.TabIndex = 28;
            this.lbClieRFC.Text = "...";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(5, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "RFC:";
            // 
            // BTGuardar
            // 
            this.BTGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTGuardar.Enabled = false;
            this.BTGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTGuardar.Location = new System.Drawing.Point(460, 305);
            this.BTGuardar.Name = "BTGuardar";
            this.BTGuardar.Size = new System.Drawing.Size(146, 29);
            this.BTGuardar.TabIndex = 76;
            this.BTGuardar.Text = "Aplicar";
            this.BTGuardar.UseVisualStyleBackColor = false;
            this.BTGuardar.Click += new System.EventHandler(this.BTGuardar_Click);
            // 
            // dSPuntoDeVentaAux
            // 
            this.dSPuntoDeVentaAux.DataSetName = "DSPuntoDeVentaAux";
            this.dSPuntoDeVentaAux.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gET_CREDITO_LISTA_A_APLICARBindingSource
            // 
            this.gET_CREDITO_LISTA_A_APLICARBindingSource.DataMember = "GET_CREDITO_LISTA_A_APLICAR";
            this.gET_CREDITO_LISTA_A_APLICARBindingSource.DataSource = this.dSPuntoDeVentaAux;
            // 
            // gET_CREDITO_LISTA_A_APLICARTableAdapter
            // 
            this.gET_CREDITO_LISTA_A_APLICARTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gET_CREDITO_LISTA_A_APLICARDataGridView
            // 
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.AllowUserToAddRows = false;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.AutoGenerateColumns = false;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGFECHA,
            this.DGFOLIO,
            this.DGSALDO,
            this.DGSALDOAAPLICAR});
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.DataSource = this.gET_CREDITO_LISTA_A_APLICARBindingSource;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.EnableHeadersVisualStyles = false;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.Location = new System.Drawing.Point(34, 203);
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.Name = "gET_CREDITO_LISTA_A_APLICARDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.RowHeadersVisible = false;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.Size = new System.Drawing.Size(403, 203);
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.TabIndex = 77;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gET_CREDITO_LISTA_A_APLICARDataGridView_CellValidated);
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gET_CREDITO_LISTA_A_APLICARDataGridView_CellValidating);
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gET_CREDITO_LISTA_A_APLICARDataGridView_DataError);
            // 
            // DGFECHA
            // 
            this.DGFECHA.DataPropertyName = "FECHA";
            this.DGFECHA.HeaderText = "FECHA";
            this.DGFECHA.Name = "DGFECHA";
            this.DGFECHA.ReadOnly = true;
            // 
            // DGFOLIO
            // 
            this.DGFOLIO.DataPropertyName = "FOLIO";
            this.DGFOLIO.HeaderText = "FOLIO";
            this.DGFOLIO.Name = "DGFOLIO";
            this.DGFOLIO.ReadOnly = true;
            // 
            // DGSALDO
            // 
            this.DGSALDO.DataPropertyName = "SALDO";
            this.DGSALDO.HeaderText = "SALDO";
            this.DGSALDO.Name = "DGSALDO";
            this.DGSALDO.ReadOnly = true;
            // 
            // DGSALDOAAPLICAR
            // 
            this.DGSALDOAAPLICAR.DataPropertyName = "SALDOAAPLICAR";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGSALDOAAPLICAR.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGSALDOAAPLICAR.HeaderText = "SALDO A APLICAR";
            this.DGSALDOAAPLICAR.Name = "DGSALDOAAPLICAR";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn1.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FOLIO";
            this.dataGridViewTextBoxColumn2.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SALDO";
            this.dataGridViewTextBoxColumn3.HeaderText = "SALDO";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SALDOAAPLICAR";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "SALDOAAPLICAR";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // lblSumaAAplicar
            // 
            this.lblSumaAAplicar.AutoSize = true;
            this.lblSumaAAplicar.BackColor = System.Drawing.Color.Transparent;
            this.lblSumaAAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumaAAplicar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSumaAAplicar.Location = new System.Drawing.Point(380, 423);
            this.lblSumaAAplicar.Name = "lblSumaAAplicar";
            this.lblSumaAAplicar.Size = new System.Drawing.Size(49, 24);
            this.lblSumaAAplicar.TabIndex = 78;
            this.lblSumaAAplicar.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(144, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 24);
            this.label5.TabIndex = 79;
            this.label5.Text = "Suma a aplicar";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTitulo.Location = new System.Drawing.Point(29, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(67, 24);
            this.lblTitulo.TabIndex = 80;
            this.lblTitulo.Text = "Saldos";
            // 
            // WFSaldosAplicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(846, 473);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSumaAAplicar);
            this.Controls.Add(this.gET_CREDITO_LISTA_A_APLICARDataGridView);
            this.Controls.Add(this.BTGuardar);
            this.Controls.Add(this.LBCliente);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.btnListaTransaccione);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFSaldosAplicacion";
            this.Text = "Aplicación de Saldos";
            this.Load += new System.EventHandler(this.WFSaldosAplicacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_CREDITO_LISTA_A_APLICARBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_CREDITO_LISTA_A_APLICARDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListaTransaccione;
        private System.Windows.Forms.Label LBCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFolioFacturado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPersona;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lbClieCP;
        private System.Windows.Forms.Label lbClieTel;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lbClieCiudad;
        private System.Windows.Forms.Label lbClieEstado;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbClieDom;
        private System.Windows.Forms.Label lbClieColonia;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbClieNombre;
        private System.Windows.Forms.Label lbClieRFC;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button BTGuardar;
        private PuntoDeVenta.DSPuntoDeVentaAux dSPuntoDeVentaAux;
        private System.Windows.Forms.BindingSource gET_CREDITO_LISTA_A_APLICARBindingSource;
        private PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.GET_CREDITO_LISTA_A_APLICARTableAdapter gET_CREDITO_LISTA_A_APLICARTableAdapter;
        private PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum gET_CREDITO_LISTA_A_APLICARDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label lblSumaAAplicar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFOLIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGSALDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGSALDOAAPLICAR;
        private System.Windows.Forms.Label lblTitulo;
    }
}