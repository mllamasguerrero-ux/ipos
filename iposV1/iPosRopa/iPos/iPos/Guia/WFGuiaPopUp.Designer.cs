namespace iPos.Guia
{
    partial class WFGuiaPopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFGuiaPopUp));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.HORAESTIMADRECTextBox = new System.Windows.Forms.DateTimePicker();
            this.FECHAHORATextBox = new System.Windows.Forms.DateTimePicker();
            this.VEHICULODesc = new System.Windows.Forms.Label();
            this.VEHICULOIDTextBox = new iPos.Tools.TextBoxFB();
            this.VEHICULOButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.ENCARGADOIDLbl = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ENCARGADOIDTextBox = new iPos.Tools.TextBoxFB();
            this.ENCARGADOButton = new System.Windows.Forms.Button();
            this.ENCARGADOIDLabel = new System.Windows.Forms.Label();
            this.gUIADETALLE_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSGuia = new iPos.Guia.DSGuia();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gUIADETALLE_TableAdapter = new iPos.Guia.DSGuiaTableAdapters.GUIADETALLE_TableAdapter();
            this.tableAdapterManager = new iPos.Guia.DSGuiaTableAdapters.TableAdapterManager();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gUIADETALLE_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSGuia)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel.Controls.Add(this.label14);
            this.headerPanel.Controls.Add(this.label15);
            this.headerPanel.Controls.Add(this.HORAESTIMADRECTextBox);
            this.headerPanel.Controls.Add(this.FECHAHORATextBox);
            this.headerPanel.Controls.Add(this.VEHICULODesc);
            this.headerPanel.Controls.Add(this.VEHICULOIDTextBox);
            this.headerPanel.Controls.Add(this.VEHICULOButton);
            this.headerPanel.Controls.Add(this.label13);
            this.headerPanel.Controls.Add(this.btnGuardar);
            this.headerPanel.Controls.Add(this.ENCARGADOIDLbl);
            this.headerPanel.Controls.Add(this.btnCancelar);
            this.headerPanel.Controls.Add(this.ENCARGADOIDTextBox);
            this.headerPanel.Controls.Add(this.ENCARGADOIDLabel);
            this.headerPanel.Controls.Add(this.ENCARGADOButton);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(503, 267);
            this.headerPanel.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(3, 164);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 13);
            this.label14.TabIndex = 206;
            this.label14.Text = "Fecha/Hora llegada:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(5, 122);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 13);
            this.label15.TabIndex = 205;
            this.label15.Text = "Fecha/Hora salida:";
            // 
            // HORAESTIMADRECTextBox
            // 
            this.HORAESTIMADRECTextBox.CustomFormat = "dd/MM/yyyy HH:mm";
            this.HORAESTIMADRECTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HORAESTIMADRECTextBox.Location = new System.Drawing.Point(114, 163);
            this.HORAESTIMADRECTextBox.Name = "HORAESTIMADRECTextBox";
            this.HORAESTIMADRECTextBox.Size = new System.Drawing.Size(131, 20);
            this.HORAESTIMADRECTextBox.TabIndex = 11;
            // 
            // FECHAHORATextBox
            // 
            this.FECHAHORATextBox.CustomFormat = "dd/MM/yyyy HH:mm";
            this.FECHAHORATextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FECHAHORATextBox.Location = new System.Drawing.Point(109, 122);
            this.FECHAHORATextBox.Name = "FECHAHORATextBox";
            this.FECHAHORATextBox.Size = new System.Drawing.Size(141, 20);
            this.FECHAHORATextBox.TabIndex = 10;
            // 
            // VEHICULODesc
            // 
            this.VEHICULODesc.AutoSize = true;
            this.VEHICULODesc.BackColor = System.Drawing.Color.Transparent;
            this.VEHICULODesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VEHICULODesc.ForeColor = System.Drawing.Color.White;
            this.VEHICULODesc.Location = new System.Drawing.Point(266, 84);
            this.VEHICULODesc.Name = "VEHICULODesc";
            this.VEHICULODesc.Size = new System.Drawing.Size(19, 13);
            this.VEHICULODesc.TabIndex = 201;
            this.VEHICULODesc.Text = "...";
            // 
            // VEHICULOIDTextBox
            // 
            this.VEHICULOIDTextBox.AccessibleDescription = "";
            this.VEHICULOIDTextBox.BotonLookUp = this.VEHICULOButton;
            this.VEHICULOIDTextBox.Condicion = null;
            this.VEHICULOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VEHICULOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VEHICULOIDTextBox.DbValue = null;
            this.VEHICULOIDTextBox.Format_Expression = null;
            this.VEHICULOIDTextBox.IndiceCampoDescripcion = 2;
            this.VEHICULOIDTextBox.IndiceCampoSelector = 1;
            this.VEHICULOIDTextBox.IndiceCampoValue = 0;
            this.VEHICULOIDTextBox.LabelDescription = this.VEHICULODesc;
            this.VEHICULOIDTextBox.Location = new System.Drawing.Point(113, 76);
            this.VEHICULOIDTextBox.MostrarErrores = true;
            this.VEHICULOIDTextBox.Name = "VEHICULOIDTextBox";
            this.VEHICULOIDTextBox.NombreCampoSelector = "clave";
            this.VEHICULOIDTextBox.NombreCampoValue = "id";
            this.VEHICULOIDTextBox.Query = " select id, placavm clave, ANIOMODELOVM nombre from VEHICULO";
            this.VEHICULOIDTextBox.QueryDeSeleccion = " select id, placavm clave, ANIOMODELOVM nombre from VEHICULO where  placavm = @cl" +
    "ave";
            this.VEHICULOIDTextBox.QueryPorDBValue = " select id, placavm clave, ANIOMODELOVM nombre from VEHICULO where   id = @id";
            this.VEHICULOIDTextBox.Size = new System.Drawing.Size(117, 20);
            this.VEHICULOIDTextBox.TabIndex = 8;
            this.VEHICULOIDTextBox.Tag = 34;
            this.VEHICULOIDTextBox.TextDescription = null;
            this.VEHICULOIDTextBox.Titulo = "VEHICULO";
            this.VEHICULOIDTextBox.ValidarEntrada = true;
            this.VEHICULOIDTextBox.ValidationExpression = null;
            // 
            // VEHICULOButton
            // 
            this.VEHICULOButton.AccessibleDescription = "";
            this.VEHICULOButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.VEHICULOButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VEHICULOButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VEHICULOButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.VEHICULOButton.Location = new System.Drawing.Point(236, 74);
            this.VEHICULOButton.Name = "VEHICULOButton";
            this.VEHICULOButton.Size = new System.Drawing.Size(24, 23);
            this.VEHICULOButton.TabIndex = 9;
            this.VEHICULOButton.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(9, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 202;
            this.label13.Text = "Vehiculo";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(58, 223);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(99, 32);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // ENCARGADOIDLbl
            // 
            this.ENCARGADOIDLbl.AutoSize = true;
            this.ENCARGADOIDLbl.ForeColor = System.Drawing.Color.White;
            this.ENCARGADOIDLbl.Location = new System.Drawing.Point(266, 41);
            this.ENCARGADOIDLbl.Name = "ENCARGADOIDLbl";
            this.ENCARGADOIDLbl.Size = new System.Drawing.Size(16, 13);
            this.ENCARGADOIDLbl.TabIndex = 184;
            this.ENCARGADOIDLbl.Text = "...";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.Image = global::iPos.Properties.Resources.cancel_J;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(166, 223);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(133, 30);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar guia";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ENCARGADOIDTextBox
            // 
            this.ENCARGADOIDTextBox.AccessibleDescription = "";
            this.ENCARGADOIDTextBox.BotonLookUp = this.ENCARGADOButton;
            this.ENCARGADOIDTextBox.Condicion = null;
            this.ENCARGADOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENCARGADOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENCARGADOIDTextBox.DbValue = null;
            this.ENCARGADOIDTextBox.Format_Expression = null;
            this.ENCARGADOIDTextBox.IndiceCampoDescripcion = 2;
            this.ENCARGADOIDTextBox.IndiceCampoSelector = 1;
            this.ENCARGADOIDTextBox.IndiceCampoValue = 0;
            this.ENCARGADOIDTextBox.LabelDescription = this.ENCARGADOIDLbl;
            this.ENCARGADOIDTextBox.Location = new System.Drawing.Point(113, 36);
            this.ENCARGADOIDTextBox.MostrarErrores = true;
            this.ENCARGADOIDTextBox.Name = "ENCARGADOIDTextBox";
            this.ENCARGADOIDTextBox.NombreCampoSelector = "clave";
            this.ENCARGADOIDTextBox.NombreCampoValue = "id";
            this.ENCARGADOIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 60";
            this.ENCARGADOIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 60 and  clave= @clave";
            this.ENCARGADOIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 60 and  id = @id";
            this.ENCARGADOIDTextBox.Size = new System.Drawing.Size(117, 20);
            this.ENCARGADOIDTextBox.TabIndex = 1;
            this.ENCARGADOIDTextBox.Tag = 34;
            this.ENCARGADOIDTextBox.TextDescription = null;
            this.ENCARGADOIDTextBox.Titulo = "Encargados";
            this.ENCARGADOIDTextBox.ValidarEntrada = true;
            this.ENCARGADOIDTextBox.ValidationExpression = null;
            // 
            // ENCARGADOButton
            // 
            this.ENCARGADOButton.AccessibleDescription = "";
            this.ENCARGADOButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ENCARGADOButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ENCARGADOButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENCARGADOButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ENCARGADOButton.Location = new System.Drawing.Point(236, 34);
            this.ENCARGADOButton.Name = "ENCARGADOButton";
            this.ENCARGADOButton.Size = new System.Drawing.Size(24, 23);
            this.ENCARGADOButton.TabIndex = 2;
            this.ENCARGADOButton.UseVisualStyleBackColor = true;
            // 
            // ENCARGADOIDLabel
            // 
            this.ENCARGADOIDLabel.AccessibleDescription = "";
            this.ENCARGADOIDLabel.AutoSize = true;
            this.ENCARGADOIDLabel.ForeColor = System.Drawing.Color.White;
            this.ENCARGADOIDLabel.Location = new System.Drawing.Point(12, 36);
            this.ENCARGADOIDLabel.Name = "ENCARGADOIDLabel";
            this.ENCARGADOIDLabel.Size = new System.Drawing.Size(59, 13);
            this.ENCARGADOIDLabel.TabIndex = 158;
            this.ENCARGADOIDLabel.Text = "Encargado";
            // 
            // gUIADETALLE_BindingSource
            // 
            this.gUIADETALLE_BindingSource.DataMember = "GUIADETALLE ";
            this.gUIADETALLE_BindingSource.DataSource = this.dSGuia;
            // 
            // dSGuia
            // 
            this.dSGuia.DataSetName = "DSGuia";
            this.dSGuia.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // gUIADETALLE_TableAdapter
            // 
            this.gUIADETALLE_TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Guia.DSGuiaTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFGuiaPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(503, 279);
            this.Controls.Add(this.headerPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFGuiaPopUp";
            this.Text = "Guia";
            this.Load += new System.EventHandler(this.WFGuiaPopUp_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gUIADETALLE_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSGuia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private Tools.TextBoxFB ENCARGADOIDTextBox;
        private System.Windows.Forms.Button ENCARGADOButton;
        private System.Windows.Forms.Label ENCARGADOIDLabel;
        private DSGuia dSGuia;
        private System.Windows.Forms.BindingSource gUIADETALLE_BindingSource;
        private DSGuiaTableAdapters.GUIADETALLE_TableAdapter gUIADETALLE_TableAdapter;
        private DSGuiaTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label ENCARGADOIDLbl;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label VEHICULODesc;
        private Tools.TextBoxFB VEHICULOIDTextBox;
        private System.Windows.Forms.Button VEHICULOButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker HORAESTIMADRECTextBox;
        private System.Windows.Forms.DateTimePicker FECHAHORATextBox;
    }
}