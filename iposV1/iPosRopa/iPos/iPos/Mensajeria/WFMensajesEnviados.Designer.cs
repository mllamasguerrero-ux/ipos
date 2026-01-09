namespace iPos.Mensajeria
{
    partial class WFMensajesEnviados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFMensajesEnviados));
            this.dSMensajeria = new iPos.Mensajeria.DSMensajeria();
            this.mENSAJEENVIADOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mENSAJEENVIADOTableAdapter = new iPos.Mensajeria.DSMensajeriaTableAdapters.MENSAJEENVIADOTableAdapter();
            this.tableAdapterManager = new iPos.Mensajeria.DSMensajeriaTableAdapters.TableAdapterManager();
            this.mENSAJEENVIADODataGridView = new System.Windows.Forms.DataGridViewSum();
            this.btnVer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCrearNuevoMensaje = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dSMensajeria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mENSAJEENVIADOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mENSAJEENVIADODataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dSMensajeria
            // 
            this.dSMensajeria.DataSetName = "DSMensajeria";
            this.dSMensajeria.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mENSAJEENVIADOBindingSource
            // 
            this.mENSAJEENVIADOBindingSource.DataMember = "MENSAJEENVIADO";
            this.mENSAJEENVIADOBindingSource.DataSource = this.dSMensajeria;
            // 
            // mENSAJEENVIADOTableAdapter
            // 
            this.mENSAJEENVIADOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AREATableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BUZONTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Mensajeria.DSMensajeriaTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // mENSAJEENVIADODataGridView
            // 
            this.mENSAJEENVIADODataGridView.AllowUserToAddRows = false;
            this.mENSAJEENVIADODataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mENSAJEENVIADODataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mENSAJEENVIADODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mENSAJEENVIADODataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnVer,
            this.DGID,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22});
            this.mENSAJEENVIADODataGridView.DataSource = this.mENSAJEENVIADOBindingSource;
            this.mENSAJEENVIADODataGridView.Location = new System.Drawing.Point(12, 12);
            this.mENSAJEENVIADODataGridView.Name = "mENSAJEENVIADODataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mENSAJEENVIADODataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mENSAJEENVIADODataGridView.RowHeadersVisible = false;
            this.mENSAJEENVIADODataGridView.Size = new System.Drawing.Size(644, 347);
            this.mENSAJEENVIADODataGridView.TabIndex = 1;
            this.mENSAJEENVIADODataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mENSAJEENVIADODataGridView_CellContentClick);
            // 
            // btnVer
            // 
            this.btnVer.HeaderText = "";
            this.btnVer.Name = "btnVer";
            this.btnVer.Text = "Ver";
            this.btnVer.UseColumnTextForButtonValue = true;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MENSAJEID";
            this.dataGridViewTextBoxColumn7.HeaderText = "MENSAJE ID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "MENSAJETIPOID";
            this.dataGridViewTextBoxColumn8.HeaderText = "TIPO";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "FECHAHORA";
            this.dataGridViewTextBoxColumn12.HeaderText = "FECHA HORA";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 75;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ASUNTO";
            this.dataGridViewTextBoxColumn9.HeaderText = "ASUNTO";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 200;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn11.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "PARATODASSUC";
            this.dataGridViewTextBoxColumn13.HeaderText = "TODAS SUC";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "PARATODASAREAS";
            this.dataGridViewTextBoxColumn14.HeaderText = "TODAS AREAS";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "SOLOADMIN";
            this.dataGridViewTextBoxColumn15.HeaderText = "SOLO ADMIN";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "RESTRICTIVO";
            this.dataGridViewTextBoxColumn16.HeaderText = "RESTRICTIVO";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "MENSAJEESTADOID";
            this.dataGridViewTextBoxColumn19.HeaderText = "MENSAJEESTADOID";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Visible = false;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "NIVELDEURGENCIAID";
            this.dataGridViewTextBoxColumn21.HeaderText = "NIVELDEURGENCIAID";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.Visible = false;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "SUCURSALFUENTECLAVE";
            this.dataGridViewTextBoxColumn22.HeaderText = "SUCURSALFUENTECLAVE";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.Visible = false;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "Ver";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // btnCrearNuevoMensaje
            // 
            this.btnCrearNuevoMensaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCrearNuevoMensaje.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCrearNuevoMensaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearNuevoMensaje.ForeColor = System.Drawing.Color.White;
            this.btnCrearNuevoMensaje.Location = new System.Drawing.Point(291, 379);
            this.btnCrearNuevoMensaje.Name = "btnCrearNuevoMensaje";
            this.btnCrearNuevoMensaje.Size = new System.Drawing.Size(108, 23);
            this.btnCrearNuevoMensaje.TabIndex = 2;
            this.btnCrearNuevoMensaje.Text = "Nuevo Mensaje";
            this.btnCrearNuevoMensaje.UseVisualStyleBackColor = false;
            this.btnCrearNuevoMensaje.Click += new System.EventHandler(this.btnCrearNuevoMensaje_Click);
            // 
            // WFMensajesEnviados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(668, 414);
            this.Controls.Add(this.btnCrearNuevoMensaje);
            this.Controls.Add(this.mENSAJEENVIADODataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFMensajesEnviados";
            this.Text = "Mensajes Enviados";
            this.Load += new System.EventHandler(this.WFMensajesEnviados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSMensajeria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mENSAJEENVIADOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mENSAJEENVIADODataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSMensajeria dSMensajeria;
        private System.Windows.Forms.BindingSource mENSAJEENVIADOBindingSource;
        private DSMensajeriaTableAdapters.MENSAJEENVIADOTableAdapter mENSAJEENVIADOTableAdapter;
        private DSMensajeriaTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum mENSAJEENVIADODataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn btnVer;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.Button btnCrearNuevoMensaje;
    }
}