using iPos;
namespace iPos
{
    partial class USUARIOSEdit
    {
      
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
       
private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USUARIOSEdit));
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSBGuardar = new System.Windows.Forms.ToolStripButton();
            this.TSBCerrar = new System.Windows.Forms.ToolStripButton();
            this.TSBEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cambiarPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSBAyuda = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.F5Info = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new FlatTabControl.FlatTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucAsignarPerfil1 = new iPos.UCAsignarPerfil();
            this.US_USUARIOTextBox = new iPos.Tools.TextBoxFB();
            this.button2 = new System.Windows.Forms.Button();
            this.US_USUARIOLabel = new System.Windows.Forms.Label();
            this.uCUSUARIOSEdit1 = new iPos.UCUSUARIOSEdit();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Location = new System.Drawing.Point(393, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(78, 152);
            this.panel2.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSBGuardar,
            this.TSBCerrar,
            this.TSBEliminar,
            this.toolStripDropDownButton1,
            this.TSBAyuda,
            this.toolStripSeparator1,
            this.F5Info});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 20, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(79, 152);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSBGuardar
            // 
            this.TSBGuardar.ForeColor = System.Drawing.Color.Black;
            this.TSBGuardar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBGuardar.Name = "TSBGuardar";
            this.TSBGuardar.Size = new System.Drawing.Size(76, 19);
            this.TSBGuardar.Text = "OK";
            this.TSBGuardar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBGuardar.ToolTipText = "Ctrl-G";
            this.TSBGuardar.Click += new System.EventHandler(this.TSBGuardar_Click);
            // 
            // TSBCerrar
            // 
            this.TSBCerrar.ForeColor = System.Drawing.Color.Black;
            this.TSBCerrar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBCerrar.Name = "TSBCerrar";
            this.TSBCerrar.Size = new System.Drawing.Size(76, 19);
            this.TSBCerrar.Text = "Cerrar";
            this.TSBCerrar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBCerrar.ToolTipText = "Esc";
            this.TSBCerrar.Click += new System.EventHandler(this.TSBCerrar_Click);
            // 
            // TSBEliminar
            // 
            this.TSBEliminar.Enabled = false;
            this.TSBEliminar.ForeColor = System.Drawing.Color.Black;
            this.TSBEliminar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBEliminar.Name = "TSBEliminar";
            this.TSBEliminar.Size = new System.Drawing.Size(76, 19);
            this.TSBEliminar.Text = "Eliminar";
            this.TSBEliminar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBEliminar.ToolTipText = "Ctrl-E";
            this.TSBEliminar.Click += new System.EventHandler(this.TSBEliminar_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarPasswordToolStripMenuItem});
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Black;
            this.toolStripDropDownButton1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(76, 19);
            this.toolStripDropDownButton1.Text = "Opciones";
            this.toolStripDropDownButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // cambiarPasswordToolStripMenuItem
            // 
            this.cambiarPasswordToolStripMenuItem.Name = "cambiarPasswordToolStripMenuItem";
            this.cambiarPasswordToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cambiarPasswordToolStripMenuItem.Text = "Cambiar Password";
            this.cambiarPasswordToolStripMenuItem.Click += new System.EventHandler(this.cambiarPasswordToolStripMenuItem_Click);
            // 
            // TSBAyuda
            // 
            this.TSBAyuda.ForeColor = System.Drawing.Color.Black;
            this.TSBAyuda.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBAyuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBAyuda.Name = "TSBAyuda";
            this.TSBAyuda.Size = new System.Drawing.Size(76, 19);
            this.TSBAyuda.Text = "Ayuda";
            this.TSBAyuda.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBAyuda.ToolTipText = "F1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(69, 6);
            // 
            // F5Info
            // 
            this.F5Info.Name = "F5Info";
            this.F5Info.Size = new System.Drawing.Size(78, 15);
            this.F5Info.Text = "Ctrl-S Listado";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(358, 312);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.ucAsignarPerfil1);
            this.tabPage1.Controls.Add(this.US_USUARIOTextBox);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.US_USUARIOLabel);
            this.tabPage1.Controls.Add(this.uCUSUARIOSEdit1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(350, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Usuario";
            // 
            // ucAsignarPerfil1
            // 
            this.ucAsignarPerfil1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ucAsignarPerfil1.Location = new System.Drawing.Point(28, 116);
            this.ucAsignarPerfil1.Name = "ucAsignarPerfil1";
            this.ucAsignarPerfil1.Size = new System.Drawing.Size(296, 163);
            this.ucAsignarPerfil1.TabIndex = 4;
            this.ucAsignarPerfil1.Load += new System.EventHandler(this.ucAsignarPerfil1_Load);
            // 
            // US_USUARIOTextBox
            // 
            this.US_USUARIOTextBox.BotonLookUp = null;
            this.US_USUARIOTextBox.Condicion = null;
            this.US_USUARIOTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.VarChar;
            this.US_USUARIOTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.US_USUARIOTextBox.DbValue = null;
            this.US_USUARIOTextBox.Format_Expression = null;
            this.US_USUARIOTextBox.IndiceCampoDescripcion = 0;
            this.US_USUARIOTextBox.IndiceCampoSelector = 1;
            this.US_USUARIOTextBox.IndiceCampoValue = 0;
            this.US_USUARIOTextBox.LabelDescription = null;
            this.US_USUARIOTextBox.Location = new System.Drawing.Point(111, 10);
            this.US_USUARIOTextBox.Name = "US_USUARIOTextBox";
            this.US_USUARIOTextBox.NombreCampoSelector = "@us_usuario";
            this.US_USUARIOTextBox.NombreCampoValue = null;
            this.US_USUARIOTextBox.Query = "Select * from usuarios";
            this.US_USUARIOTextBox.QueryDeSeleccion = "Select * from usuarios where us_usuario = @us_usuario";
            this.US_USUARIOTextBox.QueryPorDBValue = null;
            this.US_USUARIOTextBox.Size = new System.Drawing.Size(118, 20);
            this.US_USUARIOTextBox.TabIndex = 1;
            this.US_USUARIOTextBox.Tag = 34;
            this.US_USUARIOTextBox.TextDescription = null;
            this.US_USUARIOTextBox.Titulo = "USUARIOS";
            this.US_USUARIOTextBox.ValidationExpression = null;
            this.US_USUARIOTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.US_USUARIOTextBox_Validating);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(235, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // US_USUARIOLabel
            // 
            this.US_USUARIOLabel.AutoSize = true;
            this.US_USUARIOLabel.BackColor = System.Drawing.Color.Transparent;
            this.US_USUARIOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.US_USUARIOLabel.ForeColor = System.Drawing.Color.White;
            this.US_USUARIOLabel.Location = new System.Drawing.Point(4, 13);
            this.US_USUARIOLabel.Name = "US_USUARIOLabel";
            this.US_USUARIOLabel.Size = new System.Drawing.Size(67, 13);
            this.US_USUARIOLabel.TabIndex = 3;
            this.US_USUARIOLabel.Text = "USUARIO:";
            this.US_USUARIOLabel.Click += new System.EventHandler(this.US_USUARIOLabel_Click);
            // 
            // uCUSUARIOSEdit1
            // 
            this.uCUSUARIOSEdit1.BackColor = System.Drawing.Color.Transparent;
            this.uCUSUARIOSEdit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uCUSUARIOSEdit1.ForeColor = System.Drawing.Color.White;
            this.uCUSUARIOSEdit1.Location = new System.Drawing.Point(0, 37);
            this.uCUSUARIOSEdit1.Name = "uCUSUARIOSEdit1";
            this.uCUSUARIOSEdit1.Size = new System.Drawing.Size(347, 56);
            this.uCUSUARIOSEdit1.TabIndex = 3;
            this.uCUSUARIOSEdit1.Load += new System.EventHandler(this.uCUSUARIOSEdit1_Load);
            // 
            // USUARIOSEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(524, 325);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "USUARIOSEdit";
            this.Text = "Edicion de Usuario";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.USUARIOSEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.USUARIOSEdit_Reg_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private UCUSUARIOSEdit uCUSUARIOSEdit1;
        private FlatTabControl.FlatTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private UCAsignarPerfil ucAsignarPerfil1;
        private System.Windows.Forms.Label US_USUARIOLabel;
        private System.Windows.Forms.Button button2;
        //private Skinner.FormSkin formSkin1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TSBGuardar;
        private System.Windows.Forms.ToolStripButton TSBCerrar;
        private System.Windows.Forms.ToolStripButton TSBEliminar;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripButton TSBAyuda;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel F5Info;
        private iPos.Tools.TextBoxFB US_USUARIOTextBox;
        private System.Windows.Forms.ToolStripMenuItem cambiarPasswordToolStripMenuItem;
    }
}

