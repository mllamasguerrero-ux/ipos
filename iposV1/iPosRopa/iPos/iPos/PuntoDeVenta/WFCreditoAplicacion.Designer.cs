namespace iPos.PuntoDeVenta
{
    partial class WFCreditoAplicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFCreditoAplicacion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BTEnviar = new System.Windows.Forms.Button();
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
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_CREDITO_LISTA_A_APLICARBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_CREDITO_LISTA_A_APLICARDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 70);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.BTEnviar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 367);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 73);
            this.panel2.TabIndex = 1;
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(200, 20);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(92, 33);
            this.BTEnviar.TabIndex = 51;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
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
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.EnableHeadersVisualStyles = false;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.Location = new System.Drawing.Point(0, 70);
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.Name = "gET_CREDITO_LISTA_A_APLICARDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.RowHeadersVisible = false;
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.Size = new System.Drawing.Size(492, 297);
            this.gET_CREDITO_LISTA_A_APLICARDataGridView.TabIndex = 4;
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
            this.DGSALDO.Width = 160;
            // 
            // DGSALDOAAPLICAR
            // 
            this.DGSALDOAAPLICAR.DataPropertyName = "SALDOAAPLICAR";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGSALDOAAPLICAR.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGSALDOAAPLICAR.HeaderText = "SALDOAAPLICAR";
            this.DGSALDOAAPLICAR.Name = "DGSALDOAAPLICAR";
            this.DGSALDOAAPLICAR.Width = 128;
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
            this.dataGridViewTextBoxColumn3.Width = 160;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SALDOAAPLICAR";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "SALDOAAPLICAR";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 128;
            // 
            // WFCreditoAplicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 440);
            this.Controls.Add(this.gET_CREDITO_LISTA_A_APLICARDataGridView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFCreditoAplicacion";
            this.Text = "WFCreditoAplicacion";
            this.Load += new System.EventHandler(this.WFCreditoAplicacion_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_CREDITO_LISTA_A_APLICARBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_CREDITO_LISTA_A_APLICARDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DSPuntoDeVentaAux dSPuntoDeVentaAux;
        private System.Windows.Forms.BindingSource gET_CREDITO_LISTA_A_APLICARBindingSource;
        private DSPuntoDeVentaAuxTableAdapters.GET_CREDITO_LISTA_A_APLICARTableAdapter gET_CREDITO_LISTA_A_APLICARTableAdapter;
        private DSPuntoDeVentaAuxTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum gET_CREDITO_LISTA_A_APLICARDataGridView;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFOLIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGSALDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGSALDOAAPLICAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}