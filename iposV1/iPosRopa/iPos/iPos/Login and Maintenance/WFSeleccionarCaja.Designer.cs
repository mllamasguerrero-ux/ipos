namespace iPos.Login_and_Maintenance
{
    partial class WFSeleccionarCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFSeleccionarCaja));
            this.label3 = new System.Windows.Forms.Label();
            this.dSAccessControl = new iPos.Login_and_Maintenance.DSAccessControl();
            this.cAJABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAJATableAdapter = new iPos.Login_and_Maintenance.DSAccessControlTableAdapters.CAJATableAdapter();
            this.tableAdapterManager = new iPos.Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager();
            this.cAJAComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dSAccessControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAJABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(55, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Caja:";
            // 
            // dSAccessControl
            // 
            this.dSAccessControl.DataSetName = "DSAccessControl";
            this.dSAccessControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cAJABindingSource
            // 
            this.cAJABindingSource.DataMember = "CAJA";
            this.cAJABindingSource.DataSource = this.dSAccessControl;
            // 
            // cAJATableAdapter
            // 
            this.cAJATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.DERECHOS_USUARIOSTableAdapter = null;
            this.tableAdapterManager.PERFILES_DERECHOSTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cAJAComboBox
            // 
            this.cAJAComboBox.DataSource = this.cAJABindingSource;
            this.cAJAComboBox.DisplayMember = "NOMBRE";
            this.cAJAComboBox.FormattingEnabled = true;
            this.cAJAComboBox.Location = new System.Drawing.Point(97, 86);
            this.cAJAComboBox.Name = "cAJAComboBox";
            this.cAJAComboBox.Size = new System.Drawing.Size(210, 21);
            this.cAJAComboBox.TabIndex = 14;
            this.cAJAComboBox.ValueMember = "ID";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(221, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Continuar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WFSeleccionarCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(356, 216);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cAJAComboBox);
            this.Controls.Add(this.label3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFSeleccionarCaja";
            this.Text = "WFSeleccionarCaja";
            this.Load += new System.EventHandler(this.WFSeleccionarCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSAccessControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAJABindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private DSAccessControl dSAccessControl;
        private System.Windows.Forms.BindingSource cAJABindingSource;
        private DSAccessControlTableAdapters.CAJATableAdapter cAJATableAdapter;
        private DSAccessControlTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cAJAComboBox;
        private System.Windows.Forms.Button button1;

    }
}