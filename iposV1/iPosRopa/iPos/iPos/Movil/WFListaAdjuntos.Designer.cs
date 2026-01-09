namespace iPos.Movil
{
    partial class WFListaAdjuntos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFListaAdjuntos));
            this.dSMovil2 = new iPos.Movil.DSMovil2();
            this.aDJUNTOSPORDOCTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aDJUNTOSPORDOCTOTableAdapter = new iPos.Movil.DSMovil2TableAdapters.ADJUNTOSPORDOCTOTableAdapter();
            this.tableAdapterManager = new iPos.Movil.DSMovil2TableAdapters.TableAdapterManager();
            this.aDJUNTOSPORDOCTODataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOVTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGHEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDJUNTOSPORDOCTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDJUNTOSPORDOCTODataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSMovil2
            // 
            this.dSMovil2.DataSetName = "DSMovil2";
            this.dSMovil2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aDJUNTOSPORDOCTOBindingSource
            // 
            this.aDJUNTOSPORDOCTOBindingSource.DataMember = "ADJUNTOSPORDOCTO";
            this.aDJUNTOSPORDOCTOBindingSource.DataSource = this.dSMovil2;
            // 
            // aDJUNTOSPORDOCTOTableAdapter
            // 
            this.aDJUNTOSPORDOCTOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.COBRANZAMOVILBYIDTableAdapter = null;
            this.tableAdapterManager.COBRANZAMOVILTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Movil.DSMovil2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // aDJUNTOSPORDOCTODataGridView
            // 
            this.aDJUNTOSPORDOCTODataGridView.AllowUserToAddRows = false;
            this.aDJUNTOSPORDOCTODataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.aDJUNTOSPORDOCTODataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.aDJUNTOSPORDOCTODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aDJUNTOSPORDOCTODataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.MOVTOID,
            this.DGHEIGHT});
            this.aDJUNTOSPORDOCTODataGridView.DataSource = this.aDJUNTOSPORDOCTOBindingSource;
            this.aDJUNTOSPORDOCTODataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aDJUNTOSPORDOCTODataGridView.Location = new System.Drawing.Point(0, 0);
            this.aDJUNTOSPORDOCTODataGridView.Name = "aDJUNTOSPORDOCTODataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.aDJUNTOSPORDOCTODataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.aDJUNTOSPORDOCTODataGridView.RowHeadersVisible = false;
            this.aDJUNTOSPORDOCTODataGridView.Size = new System.Drawing.Size(709, 330);
            this.aDJUNTOSPORDOCTODataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MOVTOADJUNTOAID";
            this.dataGridViewTextBoxColumn2.HeaderText = "MOVTOADJUNTOAID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CANTIDAD";
            this.dataGridViewTextBoxColumn3.HeaderText = "CANT.";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CLAVEPRODUCTO";
            this.dataGridViewTextBoxColumn4.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 75;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NOMBREPRODUCTO";
            this.dataGridViewTextBoxColumn5.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DESCRIPCION1PRODUCTO";
            this.dataGridViewTextBoxColumn6.HeaderText = "DESCRIPCION1 ";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CLAVEPRODUCTOREFERENCIA";
            this.dataGridViewTextBoxColumn7.HeaderText = "ADJUNTO POR:";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 75;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NOMBREPRODUCTOREFERENCIA";
            this.dataGridViewTextBoxColumn8.HeaderText = "";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DESCRIPCION1PRODUCTOREFERENCIA";
            this.dataGridViewTextBoxColumn9.HeaderText = "";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // MOVTOID
            // 
            this.MOVTOID.DataPropertyName = "ID";
            this.MOVTOID.HeaderText = "ID";
            this.MOVTOID.Name = "MOVTOID";
            this.MOVTOID.Visible = false;
            // 
            // DGHEIGHT
            // 
            dataGridViewCellStyle2.NullValue = " ";
            this.DGHEIGHT.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGHEIGHT.HeaderText = "";
            this.DGHEIGHT.Name = "DGHEIGHT";
            this.DGHEIGHT.ReadOnly = true;
            this.DGHEIGHT.Width = 5;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(317, 11);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(71, 23);
            this.btnCerrar.TabIndex = 159;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.aDJUNTOSPORDOCTODataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 330);
            this.panel1.TabIndex = 160;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 284);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(709, 46);
            this.panel2.TabIndex = 161;
            // 
            // WFListaAdjuntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(709, 330);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFListaAdjuntos";
            this.Text = "WFListaAdjuntos";
            this.Load += new System.EventHandler(this.WFListaAdjuntos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDJUNTOSPORDOCTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aDJUNTOSPORDOCTODataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DSMovil2 dSMovil2;
        private System.Windows.Forms.BindingSource aDJUNTOSPORDOCTOBindingSource;
        private DSMovil2TableAdapters.ADJUNTOSPORDOCTOTableAdapter aDJUNTOSPORDOCTOTableAdapter;
        private DSMovil2TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum aDJUNTOSPORDOCTODataGridView;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOVTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGHEIGHT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}