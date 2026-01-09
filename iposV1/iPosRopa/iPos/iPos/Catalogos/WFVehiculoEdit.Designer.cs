
namespace iPos
{
    partial class WFVehiculoEdit
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
            FirebirdSql.Data.FirebirdClient.FbParameter fbParameter2 = new FirebirdSql.Data.FirebirdClient.FbParameter();
            this.ACTIVOLabel = new System.Windows.Forms.Label();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.DUENIODesc = new System.Windows.Forms.Label();
            this.DUENIOIDTextBox = new iPos.Tools.TextBoxFB();
            this.DUENIOButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.SAT_CONFIGAUTOTRANSPORTEIDDesc = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SAT_SUBTIPOREM2IDDesc = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SAT_SUBTIPOREM1IDDesc = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SAT_TIPOPERMISOIDDesc = new System.Windows.Forms.Label();
            this.SAT_SUBTIPOREM2IDTextBox = new iPos.Tools.TextBoxFB();
            this.SAT_SUBTIPOREM2IDButton = new System.Windows.Forms.Button();
            this.SAT_SUBTIPOREM1IDTextBox = new iPos.Tools.TextBoxFB();
            this.SAT_SUBTIPOREM1IDButton = new System.Windows.Forms.Button();
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox = new iPos.Tools.TextBoxFB();
            this.SAT_CONFIGAUTOTRANSPORTEIDButton = new System.Windows.Forms.Button();
            this.SAT_TIPOPERMISOIDTextBox = new iPos.Tools.TextBoxFB();
            this.SAT_TIPOPERMISOIDButton = new System.Windows.Forms.Button();
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.SAT_TIPOPERMISOIDLabel = new System.Windows.Forms.Label();
            this.NUMPERMISOSCTLabel = new System.Windows.Forms.Label();
            this.NUMPERMISOSCTTextBox = new System.Windows.Forms.TextBox();
            this.SAT_CONFIGAUTOTRANSPORTEIDLabel = new System.Windows.Forms.Label();
            this.PLACAVMLabel = new System.Windows.Forms.Label();
            this.PLACAVMTextBox = new System.Windows.Forms.TextBox();
            this.ANIOMODELOVMLabel = new System.Windows.Forms.Label();
            this.ANIOMODELOVMTextBox = new System.Windows.Forms.TextBox();
            this.ASEGURARESPCIVILLabel = new System.Windows.Forms.Label();
            this.ASEGURARESPCIVILTextBox = new System.Windows.Forms.TextBox();
            this.POLIZARESPCIVILLabel = new System.Windows.Forms.Label();
            this.POLIZARESPCIVILTextBox = new System.Windows.Forms.TextBox();
            this.ASEGURAMEDAMBIENTELabel = new System.Windows.Forms.Label();
            this.ASEGURAMEDAMBIENTETextBox = new System.Windows.Forms.TextBox();
            this.POLIZAMEDAMBIENTELabel = new System.Windows.Forms.Label();
            this.POLIZAMEDAMBIENTETextBox = new System.Windows.Forms.TextBox();
            this.ASEGURACARGALabel = new System.Windows.Forms.Label();
            this.ASEGURACARGATextBox = new System.Windows.Forms.TextBox();
            this.POLIZACARGALabel = new System.Windows.Forms.Label();
            this.POLIZACARGATextBox = new System.Windows.Forms.TextBox();
            this.PRIMASEGUROLabel = new System.Windows.Forms.Label();
            this.PRIMASEGUROTextBox = new System.Windows.Forms.TextBox();
            this.SAT_SUBTIPOREM1IDLabel = new System.Windows.Forms.Label();
            this.PLACA1Label = new System.Windows.Forms.Label();
            this.PLACA1TextBox = new System.Windows.Forms.TextBox();
            this.SAT_SUBTIPOREM2IDLabel = new System.Windows.Forms.Label();
            this.PLACA2Label = new System.Windows.Forms.Label();
            this.PLACA2TextBox = new System.Windows.Forms.TextBox();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.PESOBRUTOVEHICULARTextBox = new System.Windows.Forms.NumericTextBox();
            this.PESOBRUTOVEHICULARLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ACTIVOLabel
            // 
            this.ACTIVOLabel.AutoSize = true;
            this.ACTIVOLabel.Location = new System.Drawing.Point(7, 20);
            this.ACTIVOLabel.Name = "ACTIVOLabel";
            this.ACTIVOLabel.Size = new System.Drawing.Size(47, 13);
            this.ACTIVOLabel.TabIndex = 1;
            this.ACTIVOLabel.Text = "Activo:";
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
            this.FbCommand1.CommandText = "select * from VEHICULO  where 1=1  and ID=@ID  and  1= 1 ";
            this.FbCommand1.CommandTimeout = 30;
            this.FbCommand1.Connection = this.FbConnection1;
            fbParameter2.FbDbType = FirebirdSql.Data.FirebirdClient.FbDbType.BigInt;
            fbParameter2.ParameterName = "@ID";
            this.FbCommand1.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
            fbParameter2});
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(210, 484);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.PESOBRUTOVEHICULARTextBox);
            this.panel1.Controls.Add(this.PESOBRUTOVEHICULARLabel);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.DUENIOIDTextBox);
            this.panel1.Controls.Add(this.DUENIOButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.SAT_SUBTIPOREM2IDTextBox);
            this.panel1.Controls.Add(this.SAT_SUBTIPOREM2IDButton);
            this.panel1.Controls.Add(this.SAT_SUBTIPOREM1IDTextBox);
            this.panel1.Controls.Add(this.SAT_SUBTIPOREM1IDButton);
            this.panel1.Controls.Add(this.SAT_CONFIGAUTOTRANSPORTEIDTextBox);
            this.panel1.Controls.Add(this.SAT_CONFIGAUTOTRANSPORTEIDButton);
            this.panel1.Controls.Add(this.SAT_TIPOPERMISOIDTextBox);
            this.panel1.Controls.Add(this.SAT_TIPOPERMISOIDButton);
            this.panel1.Controls.Add(this.ACTIVOTextBox);
            this.panel1.Controls.Add(this.ACTIVOLabel);
            this.panel1.Controls.Add(this.SAT_TIPOPERMISOIDLabel);
            this.panel1.Controls.Add(this.NUMPERMISOSCTLabel);
            this.panel1.Controls.Add(this.NUMPERMISOSCTTextBox);
            this.panel1.Controls.Add(this.SAT_CONFIGAUTOTRANSPORTEIDLabel);
            this.panel1.Controls.Add(this.PLACAVMLabel);
            this.panel1.Controls.Add(this.PLACAVMTextBox);
            this.panel1.Controls.Add(this.ANIOMODELOVMLabel);
            this.panel1.Controls.Add(this.ANIOMODELOVMTextBox);
            this.panel1.Controls.Add(this.ASEGURARESPCIVILLabel);
            this.panel1.Controls.Add(this.ASEGURARESPCIVILTextBox);
            this.panel1.Controls.Add(this.POLIZARESPCIVILLabel);
            this.panel1.Controls.Add(this.POLIZARESPCIVILTextBox);
            this.panel1.Controls.Add(this.ASEGURAMEDAMBIENTELabel);
            this.panel1.Controls.Add(this.ASEGURAMEDAMBIENTETextBox);
            this.panel1.Controls.Add(this.POLIZAMEDAMBIENTELabel);
            this.panel1.Controls.Add(this.POLIZAMEDAMBIENTETextBox);
            this.panel1.Controls.Add(this.ASEGURACARGALabel);
            this.panel1.Controls.Add(this.ASEGURACARGATextBox);
            this.panel1.Controls.Add(this.POLIZACARGALabel);
            this.panel1.Controls.Add(this.POLIZACARGATextBox);
            this.panel1.Controls.Add(this.PRIMASEGUROLabel);
            this.panel1.Controls.Add(this.PRIMASEGUROTextBox);
            this.panel1.Controls.Add(this.SAT_SUBTIPOREM1IDLabel);
            this.panel1.Controls.Add(this.PLACA1Label);
            this.panel1.Controls.Add(this.PLACA1TextBox);
            this.panel1.Controls.Add(this.SAT_SUBTIPOREM2IDLabel);
            this.panel1.Controls.Add(this.PLACA2Label);
            this.panel1.Controls.Add(this.PLACA2TextBox);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 448);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.DUENIODesc);
            this.panel6.Location = new System.Drawing.Point(144, 396);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 28);
            this.panel6.TabIndex = 174;
            // 
            // DUENIODesc
            // 
            this.DUENIODesc.AutoSize = true;
            this.DUENIODesc.BackColor = System.Drawing.Color.Transparent;
            this.DUENIODesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DUENIODesc.ForeColor = System.Drawing.Color.White;
            this.DUENIODesc.Location = new System.Drawing.Point(3, 10);
            this.DUENIODesc.Name = "DUENIODesc";
            this.DUENIODesc.Size = new System.Drawing.Size(19, 13);
            this.DUENIODesc.TabIndex = 175;
            this.DUENIODesc.Text = "...";
            // 
            // DUENIOIDTextBox
            // 
            this.DUENIOIDTextBox.AccessibleDescription = "";
            this.DUENIOIDTextBox.BotonLookUp = this.DUENIOButton;
            this.DUENIOIDTextBox.Condicion = null;
            this.DUENIOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.DUENIOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.DUENIOIDTextBox.DbValue = null;
            this.DUENIOIDTextBox.Format_Expression = null;
            this.DUENIOIDTextBox.IndiceCampoDescripcion = 2;
            this.DUENIOIDTextBox.IndiceCampoSelector = 1;
            this.DUENIOIDTextBox.IndiceCampoValue = 0;
            this.DUENIOIDTextBox.LabelDescription = this.DUENIODesc;
            this.DUENIOIDTextBox.Location = new System.Drawing.Point(14, 400);
            this.DUENIOIDTextBox.MostrarErrores = true;
            this.DUENIOIDTextBox.Name = "DUENIOIDTextBox";
            this.DUENIOIDTextBox.NombreCampoSelector = "clave";
            this.DUENIOIDTextBox.NombreCampoValue = "id";
            this.DUENIOIDTextBox.Query = " select id,clave,nombre from PERSONA where tipopersonaid = 60 ";
            this.DUENIOIDTextBox.QueryDeSeleccion = " select id,clave,nombre from PERSONA where  tipopersonaid = 60  and clave= @clave" +
    "";
            this.DUENIOIDTextBox.QueryPorDBValue = " select id,clave,nombre from PERSONA where   tipopersonaid = 60  and id = @id";
            this.DUENIOIDTextBox.Size = new System.Drawing.Size(99, 20);
            this.DUENIOIDTextBox.TabIndex = 26;
            this.DUENIOIDTextBox.Tag = 34;
            this.DUENIOIDTextBox.TextDescription = null;
            this.DUENIOIDTextBox.Titulo = "ENCARGADO";
            this.DUENIOIDTextBox.ValidarEntrada = true;
            this.DUENIOIDTextBox.ValidationExpression = null;
            // 
            // DUENIOButton
            // 
            this.DUENIOButton.AccessibleDescription = "";
            this.DUENIOButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.DUENIOButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DUENIOButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DUENIOButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.DUENIOButton.Location = new System.Drawing.Point(119, 398);
            this.DUENIOButton.Name = "DUENIOButton";
            this.DUENIOButton.Size = new System.Drawing.Size(24, 23);
            this.DUENIOButton.TabIndex = 27;
            this.DUENIOButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 171;
            this.label2.Text = "Dueño:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.SAT_CONFIGAUTOTRANSPORTEIDDesc);
            this.panel5.Location = new System.Drawing.Point(142, 106);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(189, 28);
            this.panel5.TabIndex = 170;
            // 
            // SAT_CONFIGAUTOTRANSPORTEIDDesc
            // 
            this.SAT_CONFIGAUTOTRANSPORTEIDDesc.AutoSize = true;
            this.SAT_CONFIGAUTOTRANSPORTEIDDesc.BackColor = System.Drawing.Color.Transparent;
            this.SAT_CONFIGAUTOTRANSPORTEIDDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAT_CONFIGAUTOTRANSPORTEIDDesc.ForeColor = System.Drawing.Color.White;
            this.SAT_CONFIGAUTOTRANSPORTEIDDesc.Location = new System.Drawing.Point(6, 7);
            this.SAT_CONFIGAUTOTRANSPORTEIDDesc.Name = "SAT_CONFIGAUTOTRANSPORTEIDDesc";
            this.SAT_CONFIGAUTOTRANSPORTEIDDesc.Size = new System.Drawing.Size(19, 13);
            this.SAT_CONFIGAUTOTRANSPORTEIDDesc.TabIndex = 169;
            this.SAT_CONFIGAUTOTRANSPORTEIDDesc.Text = "...";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.SAT_SUBTIPOREM2IDDesc);
            this.panel4.Location = new System.Drawing.Point(140, 340);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 28);
            this.panel4.TabIndex = 24;
            // 
            // SAT_SUBTIPOREM2IDDesc
            // 
            this.SAT_SUBTIPOREM2IDDesc.AutoSize = true;
            this.SAT_SUBTIPOREM2IDDesc.BackColor = System.Drawing.Color.Transparent;
            this.SAT_SUBTIPOREM2IDDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAT_SUBTIPOREM2IDDesc.ForeColor = System.Drawing.Color.White;
            this.SAT_SUBTIPOREM2IDDesc.Location = new System.Drawing.Point(3, 10);
            this.SAT_SUBTIPOREM2IDDesc.Name = "SAT_SUBTIPOREM2IDDesc";
            this.SAT_SUBTIPOREM2IDDesc.Size = new System.Drawing.Size(19, 13);
            this.SAT_SUBTIPOREM2IDDesc.TabIndex = 175;
            this.SAT_SUBTIPOREM2IDDesc.Text = "...";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SAT_SUBTIPOREM1IDDesc);
            this.panel3.Location = new System.Drawing.Point(139, 283);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 28);
            this.panel3.TabIndex = 20;
            // 
            // SAT_SUBTIPOREM1IDDesc
            // 
            this.SAT_SUBTIPOREM1IDDesc.AutoSize = true;
            this.SAT_SUBTIPOREM1IDDesc.BackColor = System.Drawing.Color.Transparent;
            this.SAT_SUBTIPOREM1IDDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAT_SUBTIPOREM1IDDesc.ForeColor = System.Drawing.Color.White;
            this.SAT_SUBTIPOREM1IDDesc.Location = new System.Drawing.Point(4, 10);
            this.SAT_SUBTIPOREM1IDDesc.Name = "SAT_SUBTIPOREM1IDDesc";
            this.SAT_SUBTIPOREM1IDDesc.Size = new System.Drawing.Size(19, 13);
            this.SAT_SUBTIPOREM1IDDesc.TabIndex = 172;
            this.SAT_SUBTIPOREM1IDDesc.Text = "...";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SAT_TIPOPERMISOIDDesc);
            this.panel2.Location = new System.Drawing.Point(194, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(156, 27);
            this.panel2.TabIndex = 4;
            // 
            // SAT_TIPOPERMISOIDDesc
            // 
            this.SAT_TIPOPERMISOIDDesc.AutoSize = true;
            this.SAT_TIPOPERMISOIDDesc.BackColor = System.Drawing.Color.Transparent;
            this.SAT_TIPOPERMISOIDDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAT_TIPOPERMISOIDDesc.ForeColor = System.Drawing.Color.White;
            this.SAT_TIPOPERMISOIDDesc.Location = new System.Drawing.Point(3, 14);
            this.SAT_TIPOPERMISOIDDesc.Name = "SAT_TIPOPERMISOIDDesc";
            this.SAT_TIPOPERMISOIDDesc.Size = new System.Drawing.Size(19, 13);
            this.SAT_TIPOPERMISOIDDesc.TabIndex = 166;
            this.SAT_TIPOPERMISOIDDesc.Text = "...";
            // 
            // SAT_SUBTIPOREM2IDTextBox
            // 
            this.SAT_SUBTIPOREM2IDTextBox.AccessibleDescription = "";
            this.SAT_SUBTIPOREM2IDTextBox.BotonLookUp = this.SAT_SUBTIPOREM2IDButton;
            this.SAT_SUBTIPOREM2IDTextBox.Condicion = null;
            this.SAT_SUBTIPOREM2IDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_SUBTIPOREM2IDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_SUBTIPOREM2IDTextBox.DbValue = null;
            this.SAT_SUBTIPOREM2IDTextBox.Format_Expression = null;
            this.SAT_SUBTIPOREM2IDTextBox.IndiceCampoDescripcion = 2;
            this.SAT_SUBTIPOREM2IDTextBox.IndiceCampoSelector = 1;
            this.SAT_SUBTIPOREM2IDTextBox.IndiceCampoValue = 0;
            this.SAT_SUBTIPOREM2IDTextBox.LabelDescription = this.SAT_SUBTIPOREM2IDDesc;
            this.SAT_SUBTIPOREM2IDTextBox.Location = new System.Drawing.Point(10, 344);
            this.SAT_SUBTIPOREM2IDTextBox.MostrarErrores = true;
            this.SAT_SUBTIPOREM2IDTextBox.Name = "SAT_SUBTIPOREM2IDTextBox";
            this.SAT_SUBTIPOREM2IDTextBox.NombreCampoSelector = "clave";
            this.SAT_SUBTIPOREM2IDTextBox.NombreCampoValue = "id";
            this.SAT_SUBTIPOREM2IDTextBox.Query = " select id,clave,descripcion from SAT_SUBTIPOREM";
            this.SAT_SUBTIPOREM2IDTextBox.QueryDeSeleccion = " select id,clave,descripcion from SAT_SUBTIPOREM where clave= @clave";
            this.SAT_SUBTIPOREM2IDTextBox.QueryPorDBValue = " select id,clave,descripcion from SAT_SUBTIPOREM where  id = @id";
            this.SAT_SUBTIPOREM2IDTextBox.Size = new System.Drawing.Size(99, 20);
            this.SAT_SUBTIPOREM2IDTextBox.TabIndex = 22;
            this.SAT_SUBTIPOREM2IDTextBox.Tag = 34;
            this.SAT_SUBTIPOREM2IDTextBox.TextDescription = null;
            this.SAT_SUBTIPOREM2IDTextBox.Titulo = "SUB TIPO REMOLQUE";
            this.SAT_SUBTIPOREM2IDTextBox.ValidarEntrada = true;
            this.SAT_SUBTIPOREM2IDTextBox.ValidationExpression = null;
            // 
            // SAT_SUBTIPOREM2IDButton
            // 
            this.SAT_SUBTIPOREM2IDButton.AccessibleDescription = "";
            this.SAT_SUBTIPOREM2IDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SAT_SUBTIPOREM2IDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SAT_SUBTIPOREM2IDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAT_SUBTIPOREM2IDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SAT_SUBTIPOREM2IDButton.Location = new System.Drawing.Point(115, 342);
            this.SAT_SUBTIPOREM2IDButton.Name = "SAT_SUBTIPOREM2IDButton";
            this.SAT_SUBTIPOREM2IDButton.Size = new System.Drawing.Size(24, 23);
            this.SAT_SUBTIPOREM2IDButton.TabIndex = 23;
            this.SAT_SUBTIPOREM2IDButton.UseVisualStyleBackColor = true;
            // 
            // SAT_SUBTIPOREM1IDTextBox
            // 
            this.SAT_SUBTIPOREM1IDTextBox.AccessibleDescription = "";
            this.SAT_SUBTIPOREM1IDTextBox.BotonLookUp = this.SAT_SUBTIPOREM1IDButton;
            this.SAT_SUBTIPOREM1IDTextBox.Condicion = null;
            this.SAT_SUBTIPOREM1IDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_SUBTIPOREM1IDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_SUBTIPOREM1IDTextBox.DbValue = null;
            this.SAT_SUBTIPOREM1IDTextBox.Format_Expression = null;
            this.SAT_SUBTIPOREM1IDTextBox.IndiceCampoDescripcion = 2;
            this.SAT_SUBTIPOREM1IDTextBox.IndiceCampoSelector = 1;
            this.SAT_SUBTIPOREM1IDTextBox.IndiceCampoValue = 0;
            this.SAT_SUBTIPOREM1IDTextBox.LabelDescription = this.SAT_SUBTIPOREM1IDDesc;
            this.SAT_SUBTIPOREM1IDTextBox.Location = new System.Drawing.Point(10, 287);
            this.SAT_SUBTIPOREM1IDTextBox.MostrarErrores = true;
            this.SAT_SUBTIPOREM1IDTextBox.Name = "SAT_SUBTIPOREM1IDTextBox";
            this.SAT_SUBTIPOREM1IDTextBox.NombreCampoSelector = "clave";
            this.SAT_SUBTIPOREM1IDTextBox.NombreCampoValue = "id";
            this.SAT_SUBTIPOREM1IDTextBox.Query = " select id,clave,descripcion from SAT_SUBTIPOREM";
            this.SAT_SUBTIPOREM1IDTextBox.QueryDeSeleccion = " select id,clave,descripcion from SAT_SUBTIPOREM where clave= @clave";
            this.SAT_SUBTIPOREM1IDTextBox.QueryPorDBValue = " select id,clave,descripcion from SAT_SUBTIPOREM where  id = @id";
            this.SAT_SUBTIPOREM1IDTextBox.Size = new System.Drawing.Size(99, 20);
            this.SAT_SUBTIPOREM1IDTextBox.TabIndex = 18;
            this.SAT_SUBTIPOREM1IDTextBox.Tag = 34;
            this.SAT_SUBTIPOREM1IDTextBox.TextDescription = null;
            this.SAT_SUBTIPOREM1IDTextBox.Titulo = "SUB TIPO REMOLQUE";
            this.SAT_SUBTIPOREM1IDTextBox.ValidarEntrada = true;
            this.SAT_SUBTIPOREM1IDTextBox.ValidationExpression = null;
            // 
            // SAT_SUBTIPOREM1IDButton
            // 
            this.SAT_SUBTIPOREM1IDButton.AccessibleDescription = "";
            this.SAT_SUBTIPOREM1IDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SAT_SUBTIPOREM1IDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SAT_SUBTIPOREM1IDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAT_SUBTIPOREM1IDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SAT_SUBTIPOREM1IDButton.Location = new System.Drawing.Point(115, 285);
            this.SAT_SUBTIPOREM1IDButton.Name = "SAT_SUBTIPOREM1IDButton";
            this.SAT_SUBTIPOREM1IDButton.Size = new System.Drawing.Size(24, 23);
            this.SAT_SUBTIPOREM1IDButton.TabIndex = 19;
            this.SAT_SUBTIPOREM1IDButton.UseVisualStyleBackColor = true;
            // 
            // SAT_CONFIGAUTOTRANSPORTEIDTextBox
            // 
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.AccessibleDescription = "";
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.BotonLookUp = this.SAT_CONFIGAUTOTRANSPORTEIDButton;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.Condicion = null;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.DbValue = null;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.Format_Expression = null;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.IndiceCampoDescripcion = 2;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.IndiceCampoSelector = 1;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.IndiceCampoValue = 0;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.LabelDescription = this.SAT_CONFIGAUTOTRANSPORTEIDDesc;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.Location = new System.Drawing.Point(7, 108);
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.MostrarErrores = true;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.Name = "SAT_CONFIGAUTOTRANSPORTEIDTextBox";
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.NombreCampoSelector = "clave";
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.NombreCampoValue = "id";
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.Query = " select id,clave,descripcion from SAT_CONFIGAUTOTRANSPORTE";
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.QueryDeSeleccion = " select id,clave,descripcion from SAT_CONFIGAUTOTRANSPORTE where clave= @clave";
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.QueryPorDBValue = " select id,clave,descripcion from SAT_CONFIGAUTOTRANSPORTE where  id = @id";
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.Size = new System.Drawing.Size(99, 20);
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.TabIndex = 6;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.Tag = 34;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.TextDescription = null;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.Titulo = "CONFIG. AUTOTRANSPORTE";
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.ValidarEntrada = true;
            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.ValidationExpression = null;
            // 
            // SAT_CONFIGAUTOTRANSPORTEIDButton
            // 
            this.SAT_CONFIGAUTOTRANSPORTEIDButton.AccessibleDescription = "";
            this.SAT_CONFIGAUTOTRANSPORTEIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SAT_CONFIGAUTOTRANSPORTEIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SAT_CONFIGAUTOTRANSPORTEIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAT_CONFIGAUTOTRANSPORTEIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SAT_CONFIGAUTOTRANSPORTEIDButton.Location = new System.Drawing.Point(112, 106);
            this.SAT_CONFIGAUTOTRANSPORTEIDButton.Name = "SAT_CONFIGAUTOTRANSPORTEIDButton";
            this.SAT_CONFIGAUTOTRANSPORTEIDButton.Size = new System.Drawing.Size(24, 23);
            this.SAT_CONFIGAUTOTRANSPORTEIDButton.TabIndex = 7;
            this.SAT_CONFIGAUTOTRANSPORTEIDButton.UseVisualStyleBackColor = true;
            // 
            // SAT_TIPOPERMISOIDTextBox
            // 
            this.SAT_TIPOPERMISOIDTextBox.AccessibleDescription = "";
            this.SAT_TIPOPERMISOIDTextBox.BotonLookUp = this.SAT_TIPOPERMISOIDButton;
            this.SAT_TIPOPERMISOIDTextBox.Condicion = null;
            this.SAT_TIPOPERMISOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_TIPOPERMISOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_TIPOPERMISOIDTextBox.DbValue = null;
            this.SAT_TIPOPERMISOIDTextBox.Format_Expression = null;
            this.SAT_TIPOPERMISOIDTextBox.IndiceCampoDescripcion = 2;
            this.SAT_TIPOPERMISOIDTextBox.IndiceCampoSelector = 1;
            this.SAT_TIPOPERMISOIDTextBox.IndiceCampoValue = 0;
            this.SAT_TIPOPERMISOIDTextBox.LabelDescription = this.SAT_TIPOPERMISOIDDesc;
            this.SAT_TIPOPERMISOIDTextBox.Location = new System.Drawing.Point(63, 38);
            this.SAT_TIPOPERMISOIDTextBox.MostrarErrores = true;
            this.SAT_TIPOPERMISOIDTextBox.Name = "SAT_TIPOPERMISOIDTextBox";
            this.SAT_TIPOPERMISOIDTextBox.NombreCampoSelector = "clave";
            this.SAT_TIPOPERMISOIDTextBox.NombreCampoValue = "id";
            this.SAT_TIPOPERMISOIDTextBox.Query = "select id,clave,descripcion from SAT_TIPOPERMISO";
            this.SAT_TIPOPERMISOIDTextBox.QueryDeSeleccion = "select id,clave,descripcion from SAT_TIPOPERMISO where clave= @clave";
            this.SAT_TIPOPERMISOIDTextBox.QueryPorDBValue = "select id,clave,descripcion from SAT_TIPOPERMISO where  id = @id";
            this.SAT_TIPOPERMISOIDTextBox.Size = new System.Drawing.Size(99, 20);
            this.SAT_TIPOPERMISOIDTextBox.TabIndex = 2;
            this.SAT_TIPOPERMISOIDTextBox.Tag = 34;
            this.SAT_TIPOPERMISOIDTextBox.TextDescription = null;
            this.SAT_TIPOPERMISOIDTextBox.Titulo = "TIPO PERMISO";
            this.SAT_TIPOPERMISOIDTextBox.ValidarEntrada = true;
            this.SAT_TIPOPERMISOIDTextBox.ValidationExpression = null;
            // 
            // SAT_TIPOPERMISOIDButton
            // 
            this.SAT_TIPOPERMISOIDButton.AccessibleDescription = "";
            this.SAT_TIPOPERMISOIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SAT_TIPOPERMISOIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SAT_TIPOPERMISOIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAT_TIPOPERMISOIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SAT_TIPOPERMISOIDButton.Location = new System.Drawing.Point(168, 36);
            this.SAT_TIPOPERMISOIDButton.Name = "SAT_TIPOPERMISOIDButton";
            this.SAT_TIPOPERMISOIDButton.Size = new System.Drawing.Size(24, 23);
            this.SAT_TIPOPERMISOIDButton.TabIndex = 3;
            this.SAT_TIPOPERMISOIDButton.UseVisualStyleBackColor = true;
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(21, 43);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ACTIVOTextBox.TabIndex = 1;
            this.ACTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // SAT_TIPOPERMISOIDLabel
            // 
            this.SAT_TIPOPERMISOIDLabel.AutoSize = true;
            this.SAT_TIPOPERMISOIDLabel.Location = new System.Drawing.Point(60, 19);
            this.SAT_TIPOPERMISOIDLabel.Name = "SAT_TIPOPERMISOIDLabel";
            this.SAT_TIPOPERMISOIDLabel.Size = new System.Drawing.Size(83, 13);
            this.SAT_TIPOPERMISOIDLabel.TabIndex = 1;
            this.SAT_TIPOPERMISOIDLabel.Text = "Tipo permiso:";
            // 
            // NUMPERMISOSCTLabel
            // 
            this.NUMPERMISOSCTLabel.AutoSize = true;
            this.NUMPERMISOSCTLabel.Location = new System.Drawing.Point(363, 19);
            this.NUMPERMISOSCTLabel.Name = "NUMPERMISOSCTLabel";
            this.NUMPERMISOSCTLabel.Size = new System.Drawing.Size(95, 13);
            this.NUMPERMISOSCTLabel.TabIndex = 1;
            this.NUMPERMISOSCTLabel.Text = "# Permiso SCT:";
            // 
            // NUMPERMISOSCTTextBox
            // 
            this.NUMPERMISOSCTTextBox.Location = new System.Drawing.Point(356, 34);
            this.NUMPERMISOSCTTextBox.Name = "NUMPERMISOSCTTextBox";
            this.NUMPERMISOSCTTextBox.Size = new System.Drawing.Size(198, 20);
            this.NUMPERMISOSCTTextBox.TabIndex = 5;
            // 
            // SAT_CONFIGAUTOTRANSPORTEIDLabel
            // 
            this.SAT_CONFIGAUTOTRANSPORTEIDLabel.AutoSize = true;
            this.SAT_CONFIGAUTOTRANSPORTEIDLabel.Location = new System.Drawing.Point(7, 90);
            this.SAT_CONFIGAUTOTRANSPORTEIDLabel.Name = "SAT_CONFIGAUTOTRANSPORTEIDLabel";
            this.SAT_CONFIGAUTOTRANSPORTEIDLabel.Size = new System.Drawing.Size(176, 13);
            this.SAT_CONFIGAUTOTRANSPORTEIDLabel.TabIndex = 1;
            this.SAT_CONFIGAUTOTRANSPORTEIDLabel.Text = "Configuration auto transporte:";
            // 
            // PLACAVMLabel
            // 
            this.PLACAVMLabel.AutoSize = true;
            this.PLACAVMLabel.Location = new System.Drawing.Point(340, 90);
            this.PLACAVMLabel.Name = "PLACAVMLabel";
            this.PLACAVMLabel.Size = new System.Drawing.Size(65, 13);
            this.PLACAVMLabel.TabIndex = 1;
            this.PLACAVMLabel.Text = "Placa VM:";
            // 
            // PLACAVMTextBox
            // 
            this.PLACAVMTextBox.Location = new System.Drawing.Point(343, 108);
            this.PLACAVMTextBox.Name = "PLACAVMTextBox";
            this.PLACAVMTextBox.Size = new System.Drawing.Size(72, 20);
            this.PLACAVMTextBox.TabIndex = 9;
            // 
            // ANIOMODELOVMLabel
            // 
            this.ANIOMODELOVMLabel.AutoSize = true;
            this.ANIOMODELOVMLabel.Location = new System.Drawing.Point(439, 90);
            this.ANIOMODELOVMLabel.Name = "ANIOMODELOVMLabel";
            this.ANIOMODELOVMLabel.Size = new System.Drawing.Size(102, 13);
            this.ANIOMODELOVMLabel.TabIndex = 1;
            this.ANIOMODELOVMLabel.Text = "Año/Modelo VM:";
            // 
            // ANIOMODELOVMTextBox
            // 
            this.ANIOMODELOVMTextBox.Location = new System.Drawing.Point(441, 108);
            this.ANIOMODELOVMTextBox.Name = "ANIOMODELOVMTextBox";
            this.ANIOMODELOVMTextBox.Size = new System.Drawing.Size(100, 20);
            this.ANIOMODELOVMTextBox.TabIndex = 10;
            // 
            // ASEGURARESPCIVILLabel
            // 
            this.ASEGURARESPCIVILLabel.AutoSize = true;
            this.ASEGURARESPCIVILLabel.Location = new System.Drawing.Point(7, 153);
            this.ASEGURARESPCIVILLabel.Name = "ASEGURARESPCIVILLabel";
            this.ASEGURARESPCIVILLabel.Size = new System.Drawing.Size(110, 13);
            this.ASEGURARESPCIVILLabel.TabIndex = 1;
            this.ASEGURARESPCIVILLabel.Text = "Seguro resp. civil:";
            // 
            // ASEGURARESPCIVILTextBox
            // 
            this.ASEGURARESPCIVILTextBox.Location = new System.Drawing.Point(10, 169);
            this.ASEGURARESPCIVILTextBox.Name = "ASEGURARESPCIVILTextBox";
            this.ASEGURARESPCIVILTextBox.Size = new System.Drawing.Size(155, 20);
            this.ASEGURARESPCIVILTextBox.TabIndex = 11;
            // 
            // POLIZARESPCIVILLabel
            // 
            this.POLIZARESPCIVILLabel.AutoSize = true;
            this.POLIZARESPCIVILLabel.Location = new System.Drawing.Point(168, 153);
            this.POLIZARESPCIVILLabel.Name = "POLIZARESPCIVILLabel";
            this.POLIZARESPCIVILLabel.Size = new System.Drawing.Size(104, 13);
            this.POLIZARESPCIVILLabel.TabIndex = 1;
            this.POLIZARESPCIVILLabel.Text = "Poliza resp. civil:";
            // 
            // POLIZARESPCIVILTextBox
            // 
            this.POLIZARESPCIVILTextBox.Location = new System.Drawing.Point(176, 169);
            this.POLIZARESPCIVILTextBox.Name = "POLIZARESPCIVILTextBox";
            this.POLIZARESPCIVILTextBox.Size = new System.Drawing.Size(155, 20);
            this.POLIZARESPCIVILTextBox.TabIndex = 12;
            // 
            // ASEGURAMEDAMBIENTELabel
            // 
            this.ASEGURAMEDAMBIENTELabel.AutoSize = true;
            this.ASEGURAMEDAMBIENTELabel.Location = new System.Drawing.Point(340, 153);
            this.ASEGURAMEDAMBIENTELabel.Name = "ASEGURAMEDAMBIENTELabel";
            this.ASEGURAMEDAMBIENTELabel.Size = new System.Drawing.Size(143, 13);
            this.ASEGURAMEDAMBIENTELabel.TabIndex = 1;
            this.ASEGURAMEDAMBIENTELabel.Text = "Seguro medio ambiente:";
            // 
            // ASEGURAMEDAMBIENTETextBox
            // 
            this.ASEGURAMEDAMBIENTETextBox.Location = new System.Drawing.Point(343, 169);
            this.ASEGURAMEDAMBIENTETextBox.Name = "ASEGURAMEDAMBIENTETextBox";
            this.ASEGURAMEDAMBIENTETextBox.Size = new System.Drawing.Size(155, 20);
            this.ASEGURAMEDAMBIENTETextBox.TabIndex = 13;
            // 
            // POLIZAMEDAMBIENTELabel
            // 
            this.POLIZAMEDAMBIENTELabel.AutoSize = true;
            this.POLIZAMEDAMBIENTELabel.Location = new System.Drawing.Point(509, 153);
            this.POLIZAMEDAMBIENTELabel.Name = "POLIZAMEDAMBIENTELabel";
            this.POLIZAMEDAMBIENTELabel.Size = new System.Drawing.Size(137, 13);
            this.POLIZAMEDAMBIENTELabel.TabIndex = 1;
            this.POLIZAMEDAMBIENTELabel.Text = "Poliza medio ambiente:";
            // 
            // POLIZAMEDAMBIENTETextBox
            // 
            this.POLIZAMEDAMBIENTETextBox.Location = new System.Drawing.Point(512, 169);
            this.POLIZAMEDAMBIENTETextBox.Name = "POLIZAMEDAMBIENTETextBox";
            this.POLIZAMEDAMBIENTETextBox.Size = new System.Drawing.Size(155, 20);
            this.POLIZAMEDAMBIENTETextBox.TabIndex = 14;
            // 
            // ASEGURACARGALabel
            // 
            this.ASEGURACARGALabel.AutoSize = true;
            this.ASEGURACARGALabel.Location = new System.Drawing.Point(13, 211);
            this.ASEGURACARGALabel.Name = "ASEGURACARGALabel";
            this.ASEGURACARGALabel.Size = new System.Drawing.Size(93, 13);
            this.ASEGURACARGALabel.TabIndex = 1;
            this.ASEGURACARGALabel.Text = "Asegura carga:";
            // 
            // ASEGURACARGATextBox
            // 
            this.ASEGURACARGATextBox.Location = new System.Drawing.Point(16, 227);
            this.ASEGURACARGATextBox.Name = "ASEGURACARGATextBox";
            this.ASEGURACARGATextBox.Size = new System.Drawing.Size(149, 20);
            this.ASEGURACARGATextBox.TabIndex = 15;
            // 
            // POLIZACARGALabel
            // 
            this.POLIZACARGALabel.AutoSize = true;
            this.POLIZACARGALabel.Location = new System.Drawing.Point(167, 211);
            this.POLIZACARGALabel.Name = "POLIZACARGALabel";
            this.POLIZACARGALabel.Size = new System.Drawing.Size(81, 13);
            this.POLIZACARGALabel.TabIndex = 1;
            this.POLIZACARGALabel.Text = "Poliza carga:";
            // 
            // POLIZACARGATextBox
            // 
            this.POLIZACARGATextBox.Location = new System.Drawing.Point(176, 227);
            this.POLIZACARGATextBox.Name = "POLIZACARGATextBox";
            this.POLIZACARGATextBox.Size = new System.Drawing.Size(155, 20);
            this.POLIZACARGATextBox.TabIndex = 16;
            // 
            // PRIMASEGUROLabel
            // 
            this.PRIMASEGUROLabel.AutoSize = true;
            this.PRIMASEGUROLabel.Location = new System.Drawing.Point(340, 211);
            this.PRIMASEGUROLabel.Name = "PRIMASEGUROLabel";
            this.PRIMASEGUROLabel.Size = new System.Drawing.Size(84, 13);
            this.PRIMASEGUROLabel.TabIndex = 1;
            this.PRIMASEGUROLabel.Text = "Prima seguro:";
            // 
            // PRIMASEGUROTextBox
            // 
            this.PRIMASEGUROTextBox.Location = new System.Drawing.Point(343, 227);
            this.PRIMASEGUROTextBox.Name = "PRIMASEGUROTextBox";
            this.PRIMASEGUROTextBox.Size = new System.Drawing.Size(155, 20);
            this.PRIMASEGUROTextBox.TabIndex = 17;
            // 
            // SAT_SUBTIPOREM1IDLabel
            // 
            this.SAT_SUBTIPOREM1IDLabel.AutoSize = true;
            this.SAT_SUBTIPOREM1IDLabel.Location = new System.Drawing.Point(7, 271);
            this.SAT_SUBTIPOREM1IDLabel.Name = "SAT_SUBTIPOREM1IDLabel";
            this.SAT_SUBTIPOREM1IDLabel.Size = new System.Drawing.Size(124, 13);
            this.SAT_SUBTIPOREM1IDLabel.TabIndex = 1;
            this.SAT_SUBTIPOREM1IDLabel.Text = "Sub tipo remolque 1:";
            // 
            // PLACA1Label
            // 
            this.PLACA1Label.AutoSize = true;
            this.PLACA1Label.Location = new System.Drawing.Point(340, 271);
            this.PLACA1Label.Name = "PLACA1Label";
            this.PLACA1Label.Size = new System.Drawing.Size(54, 13);
            this.PLACA1Label.TabIndex = 1;
            this.PLACA1Label.Text = "Placa 1:";
            // 
            // PLACA1TextBox
            // 
            this.PLACA1TextBox.Location = new System.Drawing.Point(343, 287);
            this.PLACA1TextBox.Name = "PLACA1TextBox";
            this.PLACA1TextBox.Size = new System.Drawing.Size(100, 20);
            this.PLACA1TextBox.TabIndex = 21;
            // 
            // SAT_SUBTIPOREM2IDLabel
            // 
            this.SAT_SUBTIPOREM2IDLabel.AutoSize = true;
            this.SAT_SUBTIPOREM2IDLabel.Location = new System.Drawing.Point(13, 328);
            this.SAT_SUBTIPOREM2IDLabel.Name = "SAT_SUBTIPOREM2IDLabel";
            this.SAT_SUBTIPOREM2IDLabel.Size = new System.Drawing.Size(124, 13);
            this.SAT_SUBTIPOREM2IDLabel.TabIndex = 1;
            this.SAT_SUBTIPOREM2IDLabel.Text = "Sub tipo remolque 2:";
            // 
            // PLACA2Label
            // 
            this.PLACA2Label.AutoSize = true;
            this.PLACA2Label.Location = new System.Drawing.Point(340, 328);
            this.PLACA2Label.Name = "PLACA2Label";
            this.PLACA2Label.Size = new System.Drawing.Size(54, 13);
            this.PLACA2Label.TabIndex = 1;
            this.PLACA2Label.Text = "Placa 2:";
            // 
            // PLACA2TextBox
            // 
            this.PLACA2TextBox.Location = new System.Drawing.Point(343, 344);
            this.PLACA2TextBox.Name = "PLACA2TextBox";
            this.PLACA2TextBox.Size = new System.Drawing.Size(100, 20);
            this.PLACA2TextBox.TabIndex = 25;
            // 
            // BTIniciaEdicion
            // 
            this.BTIniciaEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTIniciaEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTIniciaEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIniciaEdicion.Location = new System.Drawing.Point(133, 487);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(71, 23);
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
            this.BTCancelar.Image = global::iPos.Properties.Resources.cancel_J;
            this.BTCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCancelar.Location = new System.Drawing.Point(338, 483);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(132, 30);
            this.BTCancelar.TabIndex = 47;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // PESOBRUTOVEHICULARTextBox
            // 
            this.PESOBRUTOVEHICULARTextBox.AllowNegative = true;
            this.PESOBRUTOVEHICULARTextBox.Format_Expression = null;
            this.PESOBRUTOVEHICULARTextBox.Location = new System.Drawing.Point(346, 399);
            this.PESOBRUTOVEHICULARTextBox.Name = "PESOBRUTOVEHICULARTextBox";
            this.PESOBRUTOVEHICULARTextBox.NumericPrecision = 18;
            this.PESOBRUTOVEHICULARTextBox.NumericScaleOnFocus = 0;
            this.PESOBRUTOVEHICULARTextBox.NumericScaleOnLostFocus = 0;
            this.PESOBRUTOVEHICULARTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PESOBRUTOVEHICULARTextBox.Size = new System.Drawing.Size(100, 20);
            this.PESOBRUTOVEHICULARTextBox.TabIndex = 176;
            this.PESOBRUTOVEHICULARTextBox.Tag = "";
            this.PESOBRUTOVEHICULARTextBox.Text = "0";
            this.PESOBRUTOVEHICULARTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PESOBRUTOVEHICULARTextBox.ValidationExpression = null;
            this.PESOBRUTOVEHICULARTextBox.ZeroIsValid = true;
            // 
            // PESOBRUTOVEHICULARLabel
            // 
            this.PESOBRUTOVEHICULARLabel.AutoSize = true;
            this.PESOBRUTOVEHICULARLabel.Location = new System.Drawing.Point(342, 380);
            this.PESOBRUTOVEHICULARLabel.Name = "PESOBRUTOVEHICULARLabel";
            this.PESOBRUTOVEHICULARLabel.Size = new System.Drawing.Size(128, 13);
            this.PESOBRUTOVEHICULARLabel.TabIndex = 175;
            this.PESOBRUTOVEHICULARLabel.Text = "Peso bruto vehicular:";
            // 
            // WFVehiculoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(702, 522);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WFVehiculoEdit";
            this.Text = "VEHICULO";
            this.Load += new System.EventHandler(this.VEHICULOEdit_Reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

  }

  #endregion



        private System.Windows.Forms.Panel panel1;
  
        private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
        private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LBError;
        private System.Windows.Forms.Button BTIniciaEdicion;
        private System.Windows.Forms.Button BTCancelar;



        private System.Windows.Forms.Label ACTIVOLabel;

        private System.Windows.Forms.CheckBox ACTIVOTextBox;






        System.Windows.Forms.Label SAT_TIPOPERMISOIDLabel;

        System.Windows.Forms.Label NUMPERMISOSCTLabel;

        System.Windows.Forms.Label SAT_CONFIGAUTOTRANSPORTEIDLabel;

        System.Windows.Forms.Label PLACAVMLabel;

        System.Windows.Forms.Label ANIOMODELOVMLabel;

        System.Windows.Forms.Label ASEGURARESPCIVILLabel;

        System.Windows.Forms.Label POLIZARESPCIVILLabel;

        System.Windows.Forms.Label ASEGURAMEDAMBIENTELabel;

        System.Windows.Forms.Label POLIZAMEDAMBIENTELabel;

        System.Windows.Forms.Label ASEGURACARGALabel;

        System.Windows.Forms.Label POLIZACARGALabel;

        System.Windows.Forms.Label PRIMASEGUROLabel;

        System.Windows.Forms.Label SAT_SUBTIPOREM1IDLabel;

        System.Windows.Forms.Label PLACA1Label;

        System.Windows.Forms.Label SAT_SUBTIPOREM2IDLabel;

        System.Windows.Forms.Label PLACA2Label;





        private System.Windows.Forms.TextBox NUMPERMISOSCTTextBox;



        private System.Windows.Forms.TextBox PLACAVMTextBox;


        private System.Windows.Forms.TextBox ANIOMODELOVMTextBox;


        private System.Windows.Forms.TextBox ASEGURARESPCIVILTextBox;


        private System.Windows.Forms.TextBox POLIZARESPCIVILTextBox;


        private System.Windows.Forms.TextBox ASEGURAMEDAMBIENTETextBox;


        private System.Windows.Forms.TextBox POLIZAMEDAMBIENTETextBox;


        private System.Windows.Forms.TextBox ASEGURACARGATextBox;


        private System.Windows.Forms.TextBox POLIZACARGATextBox;


        private System.Windows.Forms.TextBox PRIMASEGUROTextBox;



        private System.Windows.Forms.TextBox PLACA1TextBox;



        private System.Windows.Forms.TextBox PLACA2TextBox;
        private System.Windows.Forms.Label SAT_SUBTIPOREM2IDDesc;
        private Tools.TextBoxFB SAT_SUBTIPOREM2IDTextBox;
        private System.Windows.Forms.Button SAT_SUBTIPOREM2IDButton;
        private System.Windows.Forms.Label SAT_SUBTIPOREM1IDDesc;
        private Tools.TextBoxFB SAT_SUBTIPOREM1IDTextBox;
        private System.Windows.Forms.Button SAT_SUBTIPOREM1IDButton;
        private System.Windows.Forms.Label SAT_CONFIGAUTOTRANSPORTEIDDesc;
        private Tools.TextBoxFB SAT_CONFIGAUTOTRANSPORTEIDTextBox;
        private System.Windows.Forms.Button SAT_CONFIGAUTOTRANSPORTEIDButton;
        private System.Windows.Forms.Label SAT_TIPOPERMISOIDDesc;
        private Tools.TextBoxFB SAT_TIPOPERMISOIDTextBox;
        private System.Windows.Forms.Button SAT_TIPOPERMISOIDButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label DUENIODesc;
        private Tools.TextBoxFB DUENIOIDTextBox;
        private System.Windows.Forms.Button DUENIOButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericTextBox PESOBRUTOVEHICULARTextBox;
        private System.Windows.Forms.Label PESOBRUTOVEHICULARLabel;
    }
}

