namespace iPos.Catalogos
{
    partial class WFRespaldosSucursales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFRespaldosSucursales));
            this.SUCURSALButton = new System.Windows.Forms.Button();
            this.SUCURSALLabel = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SUCURSALTextBox = new iPos.Tools.TextBoxFB();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUnZipAll = new System.Windows.Forms.Button();
            this.dSCatalogos = new iPos.Catalogos.DSCatalogos();
            this.sUCURSALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sUCURSALTableAdapter = new iPos.Catalogos.DSCatalogosTableAdapters.SUCURSALTableAdapter();
            this.tableAdapterManager = new iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SUCURSALButton
            // 
            this.SUCURSALButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SUCURSALButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SUCURSALButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SUCURSALButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SUCURSALButton.Location = new System.Drawing.Point(142, 19);
            this.SUCURSALButton.Name = "SUCURSALButton";
            this.SUCURSALButton.Size = new System.Drawing.Size(21, 23);
            this.SUCURSALButton.TabIndex = 159;
            this.SUCURSALButton.UseVisualStyleBackColor = true;
            // 
            // SUCURSALLabel
            // 
            this.SUCURSALLabel.AutoSize = true;
            this.SUCURSALLabel.ForeColor = System.Drawing.Color.White;
            this.SUCURSALLabel.Location = new System.Drawing.Point(172, 23);
            this.SUCURSALLabel.Name = "SUCURSALLabel";
            this.SUCURSALLabel.Size = new System.Drawing.Size(16, 13);
            this.SUCURSALLabel.TabIndex = 160;
            this.SUCURSALLabel.Text = "...";
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(102, 72);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 161;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.SUCURSALTextBox);
            this.panel1.Controls.Add(this.btnEnviar);
            this.panel1.Controls.Add(this.SUCURSALLabel);
            this.panel1.Controls.Add(this.SUCURSALButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 116);
            this.panel1.TabIndex = 162;
            // 
            // SUCURSALTextBox
            // 
            this.SUCURSALTextBox.BotonLookUp = this.SUCURSALButton;
            this.SUCURSALTextBox.Condicion = null;
            this.SUCURSALTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SUCURSALTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SUCURSALTextBox.DbValue = null;
            this.SUCURSALTextBox.Format_Expression = null;
            this.SUCURSALTextBox.IndiceCampoDescripcion = 2;
            this.SUCURSALTextBox.IndiceCampoSelector = 1;
            this.SUCURSALTextBox.IndiceCampoValue = 0;
            this.SUCURSALTextBox.LabelDescription = this.SUCURSALLabel;
            this.SUCURSALTextBox.Location = new System.Drawing.Point(54, 20);
            this.SUCURSALTextBox.MostrarErrores = true;
            this.SUCURSALTextBox.Name = "SUCURSALTextBox";
            this.SUCURSALTextBox.NombreCampoSelector = "clave";
            this.SUCURSALTextBox.NombreCampoValue = "id";
            this.SUCURSALTextBox.Query = "select id,clave,nombre from sucursal";
            this.SUCURSALTextBox.QueryDeSeleccion = "select id,clave,nombre from sucursal where  clave = @clave";
            this.SUCURSALTextBox.QueryPorDBValue = "select id,clave,nombre from sucursal where  id = @id";
            this.SUCURSALTextBox.Size = new System.Drawing.Size(82, 20);
            this.SUCURSALTextBox.TabIndex = 158;
            this.SUCURSALTextBox.Tag = 34;
            this.SUCURSALTextBox.TextDescription = null;
            this.SUCURSALTextBox.Titulo = "Proveedores";
            this.SUCURSALTextBox.ValidarEntrada = true;
            this.SUCURSALTextBox.ValidationExpression = null;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnUnZipAll);
            this.panel2.Location = new System.Drawing.Point(12, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 71);
            this.panel2.TabIndex = 163;
            // 
            // btnUnZipAll
            // 
            this.btnUnZipAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnUnZipAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnUnZipAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnZipAll.ForeColor = System.Drawing.Color.White;
            this.btnUnZipAll.Location = new System.Drawing.Point(43, 18);
            this.btnUnZipAll.Name = "btnUnZipAll";
            this.btnUnZipAll.Size = new System.Drawing.Size(181, 31);
            this.btnUnZipAll.TabIndex = 0;
            this.btnUnZipAll.Text = "Descomprimir todos los respaldos";
            this.btnUnZipAll.UseVisualStyleBackColor = false;
            this.btnUnZipAll.Click += new System.EventHandler(this.btnUnZipAll_Click);
            // 
            // dSCatalogos
            // 
            this.dSCatalogos.DataSetName = "DSCatalogos";
            this.dSCatalogos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sUCURSALBindingSource
            // 
            this.sUCURSALBindingSource.DataMember = "SUCURSAL";
            this.sUCURSALBindingSource.DataSource = this.dSCatalogos;
            // 
            // sUCURSALTableAdapter
            // 
            this.sUCURSALTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.LINEA_VIEWTableAdapter = null;
            this.tableAdapterManager.PERSONAAPARTADOTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFRespaldosSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(295, 215);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFRespaldosSucursales";
            this.Text = "Respaldos ";
            this.Load += new System.EventHandler(this.WFRespaldosSucursales_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SUCURSALButton;
        private Tools.TextBoxFB SUCURSALTextBox;
        private System.Windows.Forms.Label SUCURSALLabel;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUnZipAll;
        private DSCatalogos dSCatalogos;
        private System.Windows.Forms.BindingSource sUCURSALBindingSource;
        private DSCatalogosTableAdapters.SUCURSALTableAdapter sUCURSALTableAdapter;
        private DSCatalogosTableAdapters.TableAdapterManager tableAdapterManager;
    }
}