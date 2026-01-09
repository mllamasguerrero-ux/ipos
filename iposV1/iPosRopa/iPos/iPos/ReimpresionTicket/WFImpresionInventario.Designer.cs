namespace iPos
{
    partial class WFImpresionInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFImpresionInventario));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CBOption = new System.Windows.Forms.ComboBox();
            this.pnlImprimiendo = new System.Windows.Forms.Panel();
            this.pnlParametros = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.CBLetraFinal = new System.Windows.Forms.ComboBox();
            this.CBLetraInicial = new System.Windows.Forms.ComboBox();
            this.dSTicketInventario = new iPos.ReimpresionTicket.DSTicketInventario();
            this.inventarioTicketBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventarioTicketTableAdapter = new iPos.ReimpresionTicket.DSTicketInventarioTableAdapters.InventarioTicketTableAdapter();
            this.tableAdapterManager = new iPos.ReimpresionTicket.DSTicketInventarioTableAdapters.TableAdapterManager();
            this.pnlImprimiendo.SuspendLayout();
            this.pnlParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSTicketInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioTicketBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(347, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "---------------------------------------------------------------------------------" +
    "----";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Imprimiendo inventario ....";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "De la letra: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(132, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "A la letra: ";
            // 
            // CBOption
            // 
            this.CBOption.FormattingEnabled = true;
            this.CBOption.Items.AddRange(new object[] {
            "Descripcion",
            "Descripcion 1",
            "Descripcion 2"});
            this.CBOption.Location = new System.Drawing.Point(295, 3);
            this.CBOption.Name = "CBOption";
            this.CBOption.Size = new System.Drawing.Size(121, 21);
            this.CBOption.TabIndex = 11;
            // 
            // pnlImprimiendo
            // 
            this.pnlImprimiendo.BackColor = System.Drawing.Color.Transparent;
            this.pnlImprimiendo.Controls.Add(this.label1);
            this.pnlImprimiendo.Controls.Add(this.label3);
            this.pnlImprimiendo.Location = new System.Drawing.Point(12, 12);
            this.pnlImprimiendo.Name = "pnlImprimiendo";
            this.pnlImprimiendo.Size = new System.Drawing.Size(411, 40);
            this.pnlImprimiendo.TabIndex = 12;
            this.pnlImprimiendo.Visible = false;
            // 
            // pnlParametros
            // 
            this.pnlParametros.BackColor = System.Drawing.Color.Transparent;
            this.pnlParametros.Controls.Add(this.label5);
            this.pnlParametros.Controls.Add(this.btnEnviar);
            this.pnlParametros.Controls.Add(this.CBLetraFinal);
            this.pnlParametros.Controls.Add(this.CBLetraInicial);
            this.pnlParametros.Controls.Add(this.label2);
            this.pnlParametros.Controls.Add(this.label4);
            this.pnlParametros.Controls.Add(this.CBOption);
            this.pnlParametros.Location = new System.Drawing.Point(12, 61);
            this.pnlParametros.Name = "pnlParametros";
            this.pnlParametros.Size = new System.Drawing.Size(438, 65);
            this.pnlParametros.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(249, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tipo: ";
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(341, 39);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 14;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // CBLetraFinal
            // 
            this.CBLetraFinal.FormattingEnabled = true;
            this.CBLetraFinal.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.CBLetraFinal.Location = new System.Drawing.Point(200, -2);
            this.CBLetraFinal.Name = "CBLetraFinal";
            this.CBLetraFinal.Size = new System.Drawing.Size(43, 21);
            this.CBLetraFinal.TabIndex = 13;
            // 
            // CBLetraInicial
            // 
            this.CBLetraInicial.FormattingEnabled = true;
            this.CBLetraInicial.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.CBLetraInicial.Location = new System.Drawing.Point(83, -2);
            this.CBLetraInicial.Name = "CBLetraInicial";
            this.CBLetraInicial.Size = new System.Drawing.Size(43, 21);
            this.CBLetraInicial.TabIndex = 12;
            // 
            // dSTicketInventario
            // 
            this.dSTicketInventario.DataSetName = "DSTicketInventario";
            this.dSTicketInventario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventarioTicketBindingSource
            // 
            this.inventarioTicketBindingSource.DataMember = "InventarioTicket";
            this.inventarioTicketBindingSource.DataSource = this.dSTicketInventario;
            // 
            // inventarioTicketTableAdapter
            // 
            this.inventarioTicketTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.ReimpresionTicket.DSTicketInventarioTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFImpresionInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(480, 147);
            this.Controls.Add(this.pnlParametros);
            this.Controls.Add(this.pnlImprimiendo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFImpresionInventario";
            this.Text = "Imprimiendo ticket";
            this.Load += new System.EventHandler(this.WFImpresionInventario_Load);
            this.pnlImprimiendo.ResumeLayout(false);
            this.pnlImprimiendo.PerformLayout();
            this.pnlParametros.ResumeLayout(false);
            this.pnlParametros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSTicketInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioTicketBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private ReimpresionTicket.DSTicketInventario dSTicketInventario;
        private System.Windows.Forms.BindingSource inventarioTicketBindingSource;
        private ReimpresionTicket.DSTicketInventarioTableAdapters.InventarioTicketTableAdapter inventarioTicketTableAdapter;
        private ReimpresionTicket.DSTicketInventarioTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBOption;
        private System.Windows.Forms.Panel pnlImprimiendo;
        private System.Windows.Forms.Panel pnlParametros;
        private System.Windows.Forms.ComboBox CBLetraFinal;
        private System.Windows.Forms.ComboBox CBLetraInicial;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label label5;
    }
}