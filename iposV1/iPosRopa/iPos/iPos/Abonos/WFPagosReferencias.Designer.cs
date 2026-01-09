namespace iPos.Abonos
{
    partial class WFPagosReferencias
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
            this.pAGOSPORREFERENCIADataGridView = new System.Windows.Forms.DataGridView();
            this.pAGOSPORREFERENCIABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSAbonos3 = new iPos.Abonos.DSAbonos3();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pAGOSPORREFERENCIATableAdapter = new iPos.Abonos.DSAbonos3TableAdapters.PAGOSPORREFERENCIATableAdapter();
            this.tableAdapterManager = new iPos.Abonos.DSAbonos3TableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FORMAPAGONOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REVERTIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOSPORREFERENCIADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOSPORREFERENCIABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSAbonos3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pAGOSPORREFERENCIADataGridView
            // 
            this.pAGOSPORREFERENCIADataGridView.AllowUserToAddRows = false;
            this.pAGOSPORREFERENCIADataGridView.AutoGenerateColumns = false;
            this.pAGOSPORREFERENCIADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pAGOSPORREFERENCIADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn4,
            this.FORMAPAGONOMBRE,
            this.REVERTIDO,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18});
            this.pAGOSPORREFERENCIADataGridView.DataSource = this.pAGOSPORREFERENCIABindingSource;
            this.pAGOSPORREFERENCIADataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAGOSPORREFERENCIADataGridView.Location = new System.Drawing.Point(0, 0);
            this.pAGOSPORREFERENCIADataGridView.Name = "pAGOSPORREFERENCIADataGridView";
            this.pAGOSPORREFERENCIADataGridView.RowHeadersVisible = false;
            this.pAGOSPORREFERENCIADataGridView.Size = new System.Drawing.Size(800, 291);
            this.pAGOSPORREFERENCIADataGridView.TabIndex = 2;
            // 
            // pAGOSPORREFERENCIABindingSource
            // 
            this.pAGOSPORREFERENCIABindingSource.DataMember = "PAGOSPORREFERENCIA";
            this.pAGOSPORREFERENCIABindingSource.DataSource = this.dSAbonos3;
            // 
            // dSAbonos3
            // 
            this.dSAbonos3.DataSetName = "DSAbonos3";
            this.dSAbonos3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 56);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 13);
            this.label1.TabIndex = 89;
            this.label1.Text = "CON LA AUTORIZACION CORRESPONDIENTE";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(23, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(607, 13);
            this.label23.TabIndex = 88;
            this.label23.Text = "HAY REFERENCIAS BANCARIAS REPETIDAS, FAVOR DE REVISAR Y EN SU CASO ACEPTAR EL PAG" +
    "O";
            this.label23.Click += new System.EventHandler(this.label23_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnRechazar);
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 347);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 51);
            this.panel2.TabIndex = 4;
            // 
            // btnRechazar
            // 
            this.btnRechazar.BackColor = System.Drawing.Color.Brown;
            this.btnRechazar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnRechazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechazar.ForeColor = System.Drawing.Color.White;
            this.btnRechazar.Location = new System.Drawing.Point(137, 12);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(123, 27);
            this.btnRechazar.TabIndex = 93;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = false;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Teal;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(527, 12);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(123, 27);
            this.btnAceptar.TabIndex = 92;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pAGOSPORREFERENCIADataGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 291);
            this.panel3.TabIndex = 5;
            // 
            // pAGOSPORREFERENCIATableAdapter
            // 
            this.pAGOSPORREFERENCIATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Abonos.DSAbonos3TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PAGOID";
            this.dataGridViewTextBoxColumn1.HeaderText = "PAGO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FECHAPAGO";
            this.dataGridViewTextBoxColumn6.HeaderText = "FECHA PAGO";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "IMPORTERECIBIDOPAGO";
            this.dataGridViewTextBoxColumn4.HeaderText = "IMPORTE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // FORMAPAGONOMBRE
            // 
            this.FORMAPAGONOMBRE.DataPropertyName = "FORMAPAGONOMBRE";
            this.FORMAPAGONOMBRE.HeaderText = "FORMA PAGO";
            this.FORMAPAGONOMBRE.Name = "FORMAPAGONOMBRE";
            this.FORMAPAGONOMBRE.Width = 95;
            // 
            // REVERTIDO
            // 
            this.REVERTIDO.DataPropertyName = "REVERTIDO";
            this.REVERTIDO.HeaderText = "REVERTIDO";
            this.REVERTIDO.Name = "REVERTIDO";
            this.REVERTIDO.Width = 75;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "REFERENCIABANCARIAPAGO";
            this.dataGridViewTextBoxColumn5.HeaderText = "REFERENCIA BANCARIA";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "CAJERONOMBREPAGO";
            this.dataGridViewTextBoxColumn8.HeaderText = "CAJERO NOMBRE";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "TIPODOCTONOMBRE";
            this.dataGridViewTextBoxColumn12.HeaderText = "TIPO TRANS.";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "PERSONANOMBRE";
            this.dataGridViewTextBoxColumn14.HeaderText = "CLIENTE/PROVEE.";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "DOCTOFOLIO";
            this.dataGridViewTextBoxColumn16.HeaderText = "FOLIO TRANS.";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "DOCTOFECHA";
            this.dataGridViewTextBoxColumn17.HeaderText = "FECHA TRANS.";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "DOCTOTOTAL";
            this.dataGridViewTextBoxColumn18.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // WFPagosReferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(800, 398);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "WFPagosReferencias";
            this.Text = "Referencias de pago";
            this.Load += new System.EventHandler(this.WFPagosReferencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pAGOSPORREFERENCIADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOSPORREFERENCIABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSAbonos3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DSAbonos3 dSAbonos3;
        private System.Windows.Forms.BindingSource pAGOSPORREFERENCIABindingSource;
        private DSAbonos3TableAdapters.PAGOSPORREFERENCIATableAdapter pAGOSPORREFERENCIATableAdapter;
        private DSAbonos3TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView pAGOSPORREFERENCIADataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn FORMAPAGONOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REVERTIDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
    }
}