
namespace iPos
{
    partial class WFTerminalPagoServicioEdit
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
            FirebirdSql.Data.FirebirdClient.FbParameter fbParameter1 = new FirebirdSql.Data.FirebirdClient.FbParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFTerminalPagoServicioEdit));
            this.ACTIVOLabel = new System.Windows.Forms.Label();
            this.TERMINALLabel = new System.Windows.Forms.Label();
            this.TERMINALTextBox = new System.Windows.Forms.TextBox();
            this.RFV_CLAVE = new CustomValidation.RequiredFieldValidator();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ESSERVICIOTextBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SUCURSALIDButton = new System.Windows.Forms.Button();
            this.SUCURSALIDTextBox = new iPos.Tools.TextBoxFB();
            this.SUCURSALIDLabel = new System.Windows.Forms.Label();
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ACTIVOLabel
            // 
            this.ACTIVOLabel.AutoSize = true;
            this.ACTIVOLabel.ForeColor = System.Drawing.Color.White;
            this.ACTIVOLabel.Location = new System.Drawing.Point(97, 70);
            this.ACTIVOLabel.Name = "ACTIVOLabel";
            this.ACTIVOLabel.Size = new System.Drawing.Size(47, 13);
            this.ACTIVOLabel.TabIndex = 1;
            this.ACTIVOLabel.Text = "Activo:";
            // 
            // TERMINALLabel
            // 
            this.TERMINALLabel.AutoSize = true;
            this.TERMINALLabel.BackColor = System.Drawing.Color.Transparent;
            this.TERMINALLabel.ForeColor = System.Drawing.Color.White;
            this.TERMINALLabel.Location = new System.Drawing.Point(108, 18);
            this.TERMINALLabel.Name = "TERMINALLabel";
            this.TERMINALLabel.Size = new System.Drawing.Size(43, 13);
            this.TERMINALLabel.TabIndex = 1;
            this.TERMINALLabel.Text = "Clave:";
            // 
            // TERMINALTextBox
            // 
            this.TERMINALTextBox.Location = new System.Drawing.Point(171, 15);
            this.TERMINALTextBox.Name = "TERMINALTextBox";
            this.TERMINALTextBox.Size = new System.Drawing.Size(237, 20);
            this.TERMINALTextBox.TabIndex = 1;
            this.TERMINALTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CLAVETextBox_Validating);
            // 
            // RFV_CLAVE
            // 
            this.RFV_CLAVE.ControlToValidate = this.TERMINALTextBox;
            this.RFV_CLAVE.Enabled = true;
            this.RFV_CLAVE.ErrorMessage = "Se requiere el campo CLAVE";
            this.RFV_CLAVE.Icon = null;
            // 
            // LBError
            // 
            this.LBError.AutoSize = true;
            this.LBError.ForeColor = System.Drawing.Color.Red;
            this.LBError.Location = new System.Drawing.Point(26, 20);
            this.LBError.Name = "LBError";
            this.LBError.Size = new System.Drawing.Size(10, 13);
            this.LBError.TabIndex = 44;
            this.LBError.Text = "-";
            // 
            // FbConnection1
            // 
            this.FbConnection1.ConnectionString = "Data Source=manuel;Initial Catalog=generador;Persist Security Info=True;User ID=s" +
    "a;Password=Twincept";
            // 
            // FbCommand1
            // 
            this.FbCommand1.CommandText = "select * from LINEA  where 1=1  and ID=@ID  and  1= 1 ";
            this.FbCommand1.CommandTimeout = 30;
            this.FbCommand1.Connection = this.FbConnection1;
            fbParameter1.FbDbType = FirebirdSql.Data.FirebirdClient.FbDbType.BigInt;
            fbParameter1.ParameterName = "@ID";
            this.FbCommand1.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
            fbParameter1});
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(148, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.ESSERVICIOTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SUCURSALIDButton);
            this.panel1.Controls.Add(this.SUCURSALIDTextBox);
            this.panel1.Controls.Add(this.SUCURSALIDLabel);
            this.panel1.Controls.Add(this.ACTIVOTextBox);
            this.panel1.Controls.Add(this.ACTIVOLabel);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(7, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 99);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            // 
            // ESSERVICIOTextBox
            // 
            this.ESSERVICIOTextBox.AutoSize = true;
            this.ESSERVICIOTextBox.Location = new System.Drawing.Point(163, 38);
            this.ESSERVICIOTextBox.Name = "ESSERVICIOTextBox";
            this.ESSERVICIOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ESSERVICIOTextBox.TabIndex = 170;
            this.ESSERVICIOTextBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(71, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 169;
            this.label2.Text = "Es servicio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(84, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 162;
            this.label1.Text = "Sucursal:";
            // 
            // SUCURSALIDButton
            // 
            this.SUCURSALIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SUCURSALIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SUCURSALIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SUCURSALIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SUCURSALIDButton.Location = new System.Drawing.Point(262, 2);
            this.SUCURSALIDButton.Name = "SUCURSALIDButton";
            this.SUCURSALIDButton.Size = new System.Drawing.Size(24, 23);
            this.SUCURSALIDButton.TabIndex = 160;
            this.SUCURSALIDButton.UseVisualStyleBackColor = true;
            // 
            // SUCURSALIDTextBox
            // 
            this.SUCURSALIDTextBox.BotonLookUp = this.SUCURSALIDButton;
            this.SUCURSALIDTextBox.Condicion = null;
            this.SUCURSALIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SUCURSALIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SUCURSALIDTextBox.DbValue = null;
            this.SUCURSALIDTextBox.Format_Expression = null;
            this.SUCURSALIDTextBox.IndiceCampoDescripcion = 2;
            this.SUCURSALIDTextBox.IndiceCampoSelector = 1;
            this.SUCURSALIDTextBox.IndiceCampoValue = 0;
            this.SUCURSALIDTextBox.LabelDescription = this.SUCURSALIDLabel;
            this.SUCURSALIDTextBox.Location = new System.Drawing.Point(164, 3);
            this.SUCURSALIDTextBox.MostrarErrores = true;
            this.SUCURSALIDTextBox.Name = "SUCURSALIDTextBox";
            this.SUCURSALIDTextBox.NombreCampoSelector = "clave";
            this.SUCURSALIDTextBox.NombreCampoValue = "id";
            this.SUCURSALIDTextBox.Query = "select id,clave,nombre from sucursal";
            this.SUCURSALIDTextBox.QueryDeSeleccion = "select id,clave,nombre from sucursal where  clave = @clave";
            this.SUCURSALIDTextBox.QueryPorDBValue = "select id,clave,nombre from sucursal where  id = @id";
            this.SUCURSALIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.SUCURSALIDTextBox.TabIndex = 159;
            this.SUCURSALIDTextBox.Tag = 34;
            this.SUCURSALIDTextBox.TextDescription = null;
            this.SUCURSALIDTextBox.Titulo = "Sucursal";
            this.SUCURSALIDTextBox.ValidarEntrada = true;
            this.SUCURSALIDTextBox.ValidationExpression = null;
            // 
            // SUCURSALIDLabel
            // 
            this.SUCURSALIDLabel.AutoSize = true;
            this.SUCURSALIDLabel.ForeColor = System.Drawing.Color.White;
            this.SUCURSALIDLabel.Location = new System.Drawing.Point(292, 6);
            this.SUCURSALIDLabel.Name = "SUCURSALIDLabel";
            this.SUCURSALIDLabel.Size = new System.Drawing.Size(19, 13);
            this.SUCURSALIDLabel.TabIndex = 161;
            this.SUCURSALIDLabel.Text = "...";
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(164, 70);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ACTIVOTextBox.TabIndex = 5;
            this.ACTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // BTIniciaEdicion
            // 
            this.BTIniciaEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTIniciaEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTIniciaEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIniciaEdicion.ForeColor = System.Drawing.Color.White;
            this.BTIniciaEdicion.Location = new System.Drawing.Point(72, 152);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(66, 23);
            this.BTIniciaEdicion.TabIndex = 46;
            this.BTIniciaEdicion.Text = "Editar";
            this.BTIniciaEdicion.UseVisualStyleBackColor = false;
            this.BTIniciaEdicion.Visible = false;
            this.BTIniciaEdicion.Click += new System.EventHandler(this.BTIniciaEdicion_Click);
            // 
            // BTCancelar
            // 
            this.BTCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCancelar.ForeColor = System.Drawing.Color.White;
            this.BTCancelar.Image = global::iPos.Properties.Resources.cancel_J;
            this.BTCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCancelar.Location = new System.Drawing.Point(282, 147);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(128, 32);
            this.BTCancelar.TabIndex = 47;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // WFTerminalPagoServicioEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(492, 195);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TERMINALLabel);
            this.Controls.Add(this.TERMINALTextBox);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFTerminalPagoServicioEdit";
            this.Text = "TERMINAL PAGO SERVICIO";
            this.Load += new System.EventHandler(this.TERMINALPAGOSERVICIOEdit_Reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

  }

  #endregion



        private System.Windows.Forms.TextBox TERMINALTextBox;
        private System.Windows.Forms.Panel panel1;
  
  private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
  private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.Label LBError;




  private CustomValidation.RequiredFieldValidator RFV_CLAVE;
        private System.Windows.Forms.Label ACTIVOLabel;
        private System.Windows.Forms.Label TERMINALLabel;
        private System.Windows.Forms.Button BTIniciaEdicion;
        private System.Windows.Forms.CheckBox ACTIVOTextBox;
        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SUCURSALIDButton;
        private Tools.TextBoxFB SUCURSALIDTextBox;
        private System.Windows.Forms.Label SUCURSALIDLabel;
        private System.Windows.Forms.CheckBox ESSERVICIOTextBox;
        private System.Windows.Forms.Label label2;
 

    }
}

