namespace iPos
{
    partial class WFLogEventoTransaccion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFLogEventoTransaccion));
            this.lOGDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFECHAHORA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBREUSUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPOEVENTONOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLIENTE_NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGENCABEZADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCatalogos = new iPos.Catalogos.DSCatalogos();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BTAgregarNota = new System.Windows.Forms.Button();
            this.btnSearchLog = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lOGTableAdapter = new iPos.Catalogos.DSCatalogosTableAdapters.LOGTableAdapter();
            this.tableAdapterManager = new iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager();
            this.lOGEVENTOTABLATableAdapter = new iPos.Catalogos.DSCatalogosTableAdapters.LOGEVENTOTABLATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.lOGDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lOGDataGridView
            // 
            this.lOGDataGridView.AllowUserToAddRows = false;
            this.lOGDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lOGDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.lOGDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lOGDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.DGFECHAHORA,
            this.NOMBREUSUARIO,
            this.TIPOEVENTONOMBRE,
            this.CLIENTE_NOMBRE,
            this.DGENCABEZADO,
            this.NOTA});
            this.lOGDataGridView.DataSource = this.lOGBindingSource;
            this.lOGDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lOGDataGridView.Location = new System.Drawing.Point(0, 0);
            this.lOGDataGridView.Name = "lOGDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lOGDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.lOGDataGridView.RowHeadersVisible = false;
            this.lOGDataGridView.Size = new System.Drawing.Size(999, 307);
            this.lOGDataGridView.TabIndex = 11;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            this.DGID.Width = 300;
            // 
            // DGFECHAHORA
            // 
            this.DGFECHAHORA.DataPropertyName = "FECHAHORA";
            this.DGFECHAHORA.FillWeight = 85.71429F;
            this.DGFECHAHORA.HeaderText = "FECHA HORA";
            this.DGFECHAHORA.Name = "DGFECHAHORA";
            this.DGFECHAHORA.Width = 125;
            // 
            // NOMBREUSUARIO
            // 
            this.NOMBREUSUARIO.DataPropertyName = "USUARIO_NOMBRE";
            this.NOMBREUSUARIO.FillWeight = 182.1429F;
            this.NOMBREUSUARIO.HeaderText = "USUARIO";
            this.NOMBREUSUARIO.Name = "NOMBREUSUARIO";
            this.NOMBREUSUARIO.Width = 125;
            // 
            // TIPOEVENTONOMBRE
            // 
            this.TIPOEVENTONOMBRE.DataPropertyName = "TIPOEVENTONOMBRE";
            this.TIPOEVENTONOMBRE.HeaderText = "TIPO EVENTO";
            this.TIPOEVENTONOMBRE.Name = "TIPOEVENTONOMBRE";
            // 
            // CLIENTE_NOMBRE
            // 
            this.CLIENTE_NOMBRE.DataPropertyName = "CLIENTE_NOMBRE";
            this.CLIENTE_NOMBRE.HeaderText = "CLIENTE";
            this.CLIENTE_NOMBRE.Name = "CLIENTE_NOMBRE";
            this.CLIENTE_NOMBRE.Width = 125;
            // 
            // DGENCABEZADO
            // 
            this.DGENCABEZADO.DataPropertyName = "ENCABEZADO";
            this.DGENCABEZADO.HeaderText = "ENCABEZADO";
            this.DGENCABEZADO.Name = "DGENCABEZADO";
            // 
            // NOTA
            // 
            this.NOTA.DataPropertyName = "NOTA";
            this.NOTA.HeaderText = "NOTA";
            this.NOTA.Name = "NOTA";
            this.NOTA.Width = 400;
            // 
            // lOGBindingSource
            // 
            this.lOGBindingSource.DataMember = "LOGEVENTOTABLA";
            this.lOGBindingSource.DataSource = this.dSCatalogos;
            // 
            // dSCatalogos
            // 
            this.dSCatalogos.DataSetName = "DSCatalogos";
            this.dSCatalogos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TABLAID";
            this.dataGridViewTextBoxColumn3.HeaderText = "TABLAID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "VER";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 70;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BTAgregarNota);
            this.panel1.Controls.Add(this.btnSearchLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 94);
            this.panel1.TabIndex = 191;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(454, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 224;
            this.label1.Text = "Negociaciones";
            // 
            // BTAgregarNota
            // 
            this.BTAgregarNota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTAgregarNota.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTAgregarNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregarNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTAgregarNota.ForeColor = System.Drawing.Color.White;
            this.BTAgregarNota.Location = new System.Drawing.Point(113, 41);
            this.BTAgregarNota.Name = "BTAgregarNota";
            this.BTAgregarNota.Size = new System.Drawing.Size(164, 42);
            this.BTAgregarNota.TabIndex = 223;
            this.BTAgregarNota.Text = "Agregar negociacion";
            this.BTAgregarNota.UseVisualStyleBackColor = false;
            this.BTAgregarNota.Click += new System.EventHandler(this.BTAgregarNota_Click);
            // 
            // btnSearchLog
            // 
            this.btnSearchLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnSearchLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSearchLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchLog.ForeColor = System.Drawing.Color.White;
            this.btnSearchLog.Location = new System.Drawing.Point(774, 41);
            this.btnSearchLog.Name = "btnSearchLog";
            this.btnSearchLog.Size = new System.Drawing.Size(138, 42);
            this.btnSearchLog.TabIndex = 10;
            this.btnSearchLog.Text = "Actualizar lista";
            this.btnSearchLog.UseVisualStyleBackColor = false;
            this.btnSearchLog.Click += new System.EventHandler(this.btnSearchLog_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 401);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(999, 67);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lOGDataGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(999, 307);
            this.panel3.TabIndex = 10;
            // 
            // lOGTableAdapter
            // 
            this.lOGTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.LINEA_VIEWTableAdapter = null;
            this.tableAdapterManager.PERSONAAPARTADOTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // lOGEVENTOTABLATableAdapter
            // 
            this.lOGEVENTOTABLATableAdapter.ClearBeforeFill = true;
            // 
            // WFLogEventoTransaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(999, 468);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFLogEventoTransaccion";
            this.Text = "Negociaciones ";
            this.Load += new System.EventHandler(this.WFLogEventoTransaccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lOGDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Catalogos.DSCatalogos dSCatalogos;
        private System.Windows.Forms.BindingSource lOGBindingSource;
        private Catalogos.DSCatalogosTableAdapters.LOGTableAdapter lOGTableAdapter;
        private Catalogos.DSCatalogosTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum lOGDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Catalogos.DSCatalogosTableAdapters.LOGEVENTOTABLATableAdapter lOGEVENTOTABLATableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFECHAHORA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBREUSUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPOEVENTONOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENTE_NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGENCABEZADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTA;
        private System.Windows.Forms.Button btnSearchLog;
        private System.Windows.Forms.Button BTAgregarNota;
        private System.Windows.Forms.Label label1;
    }
}