namespace iPos
{
    partial class WFProductoClienteHistorial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFProductoClienteHistorial));
            this.hISTORIALDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCUENTOOTORGADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIOLISTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PREC_ACT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGHEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hISTORIALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSMovil = new iPos.Movil.DSMovil();
            this.hISTORIALTableAdapter = new iPos.Movil.DSMovilTableAdapters.HISTORIALTableAdapter();
            this.tableAdapterManager = new iPos.Movil.DSMovilTableAdapters.TableAdapterManager();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.hISTORIALDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hISTORIALBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // hISTORIALDataGridView
            // 
            this.hISTORIALDataGridView.AllowUserToAddRows = false;
            this.hISTORIALDataGridView.AutoGenerateColumns = false;
            this.hISTORIALDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hISTORIALDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.DESCUENTOOTORGADO,
            this.PRECIOLISTA,
            this.PREC_ACT,
            this.DGHEIGHT});
            this.hISTORIALDataGridView.DataSource = this.hISTORIALBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.hISTORIALDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.hISTORIALDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hISTORIALDataGridView.Location = new System.Drawing.Point(0, 0);
            this.hISTORIALDataGridView.Name = "hISTORIALDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.hISTORIALDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.hISTORIALDataGridView.RowHeadersVisible = false;
            this.hISTORIALDataGridView.Size = new System.Drawing.Size(748, 291);
            this.hISTORIALDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn2.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn3.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn4.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PRECIO";
            this.dataGridViewTextBoxColumn5.HeaderText = "PRECIO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "CANTIDAD";
            this.dataGridViewTextBoxColumn6.HeaderText = "CANTIDAD";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // DESCUENTOOTORGADO
            // 
            this.DESCUENTOOTORGADO.DataPropertyName = "DESCUENTOOTORGADO";
            this.DESCUENTOOTORGADO.HeaderText = "DESCUENTO";
            this.DESCUENTOOTORGADO.Name = "DESCUENTOOTORGADO";
            this.DESCUENTOOTORGADO.ReadOnly = true;
            // 
            // PRECIOLISTA
            // 
            this.PRECIOLISTA.DataPropertyName = "PRECIOLISTA";
            this.PRECIOLISTA.HeaderText = "PRECIO LISTA";
            this.PRECIOLISTA.Name = "PRECIOLISTA";
            this.PRECIOLISTA.ReadOnly = true;
            // 
            // PREC_ACT
            // 
            this.PREC_ACT.DataPropertyName = "PREC_ACT";
            this.PREC_ACT.HeaderText = "PREC. ACT.";
            this.PREC_ACT.Name = "PREC_ACT";
            this.PREC_ACT.ReadOnly = true;
            // 
            // DGHEIGHT
            // 
            dataGridViewCellStyle1.NullValue = " ";
            this.DGHEIGHT.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGHEIGHT.HeaderText = "";
            this.DGHEIGHT.Name = "DGHEIGHT";
            this.DGHEIGHT.ReadOnly = true;
            this.DGHEIGHT.Width = 5;
            // 
            // hISTORIALBindingSource
            // 
            this.hISTORIALBindingSource.DataMember = "HISTORIAL";
            this.hISTORIALBindingSource.DataSource = this.dSMovil;
            // 
            // dSMovil
            // 
            this.dSMovil.DataSetName = "DSMovil";
            this.dSMovil.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hISTORIALTableAdapter
            // 
            this.hISTORIALTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Movil.DSMovilTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(336, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 291);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 57);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.hISTORIALDataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(748, 291);
            this.panel2.TabIndex = 5;
            // 
            // WFProductoClienteHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(748, 348);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFProductoClienteHistorial";
            this.Text = "WFProductoClienteHistorial";
            this.Load += new System.EventHandler(this.WFProductoClienteHistorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hISTORIALDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hISTORIALBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSMovil)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Movil.DSMovil dSMovil;
        private System.Windows.Forms.BindingSource hISTORIALBindingSource;
        private Movil.DSMovilTableAdapters.HISTORIALTableAdapter hISTORIALTableAdapter;
        private Movil.DSMovilTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum hISTORIALDataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCUENTOOTORGADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIOLISTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PREC_ACT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGHEIGHT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}