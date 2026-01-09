
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;

namespace iPos
{
    public partial class UCEMPRESASEdit_Reg : UserControl
    {
        public string opc;
        System.Collections.ArrayList validadores;
        string EM_NOMBRE;
        int EM_COLOR_RED;
        int EM_COLOR_GREEN;
        int EM_COLOR_BLUE;
        public UCEMPRESASEdit_Reg()
        {
            InitializeComponent();
        }
        public void ReCargar(string popc,
      string pEM_NOMBRE
      )
        {
            opc = popc;
            EM_NOMBRE = pEM_NOMBRE;
            validadores = new System.Collections.ArrayList();
            validadores.Add((RFV_EM_NOMBRE));
            this.button1.Text = opc;
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.aduanas' Puede moverla o quitarla según sea necesario.
            if (this.opc != "Agregar" && this.opc != "")
            {
                if (this.opc == "Consultar") { this.button1.Visible = false; }
                LlenarDatosDeBase();
                this.panel1.Enabled = true;
                this.EM_DATABASETextBox.Focus();
            }
            else
            {
                this.CBCustomConn.Checked = true;
                //this.CBCustomConn.Visible = true;
                GBConecctionData.Enabled = true;
                //this.CBCustomConn.Focus();
                this.panel1.Enabled = true;
            }
        }
        private void EMPRESASEdit_Reg_Load(object sender, EventArgs e)
        {
        }
        private bool LlenarDatosDeBase()
        {
            try
            {
                this.FbCommand1.Parameters["@EM_NOMBRE"].Value = EM_NOMBRE;
                DataTable dt = new DataTable();
                dt = DataTablesParaGrid.GetData(this.FbCommand1, ConexionMEBD.ConexionString());
                if (dt.Rows.Count <= 0)
                    return false;
                this.EM_NOMBRETextBox.Text = dt.Rows[0]["EM_NOMBRE"].ToString();
                this.EM_DATABASETextBox.Text = dt.Rows[0]["EM_DATABASE"].ToString();
                this.EM_USUARIOTextBox.Text = dt.Rows[0]["EM_USUARIO"].ToString();
                this.EM_PASSWORDTextBox.Text = dt.Rows[0]["EM_PASSWORD"].ToString();
                this.EM_SERVERTextBox.Text = dt.Rows[0]["EM_SERVER"].ToString();

                string strHabImpExp = dt.Rows[0]["HABILITAR_IMPEXP_AUT"].ToString();
                this.HABILITAR_IMPEXP_AUTCheckBox.Checked = ((strHabImpExp.ToUpper() == "S") ? true : false);

                string strEsMatriz = dt.Rows[0]["ESMATRIZ"].ToString();
                this.ESMATRIZCheckBox.Checked = ((strEsMatriz.ToUpper() == "S") ? true : false);
               
                try{
                    LlenarComboCajas();
                    this.EM_CAJAComboBox.SelectedIndex = EM_CAJAComboBox.FindString(dt.Rows[0]["EM_CAJA_NOMBRE"].ToString());
                }
                catch{
                }

                
                try{
                    EM_COLOR_RED = int.Parse(dt.Rows[0]["RED"].ToString());
                    EM_COLOR_GREEN = int.Parse(dt.Rows[0]["GREEN"].ToString());
                    EM_COLOR_BLUE = int.Parse(dt.Rows[0]["BLUE"].ToString());
                }
                catch{

                    EM_COLOR_RED = 50;
                    EM_COLOR_GREEN = 120;
                    EM_COLOR_BLUE = 180;
                }

                pnlColor.BackColor = Color.FromArgb(255, EM_COLOR_RED, EM_COLOR_GREEN, EM_COLOR_BLUE);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
                return false;
            }
        }
        private CEMPRESASBE ObtenerDatosCapturados()
        {
            CEMPRESASBE EMPRESASBE = new CEMPRESASBE();
            if (this.EM_NOMBRETextBox.Text != "")
            {
                EMPRESASBE.IEM_NOMBRE = this.EM_NOMBRETextBox.Text.ToString();
            }
            if (this.EM_DATABASETextBox.Text != "")
            {
                EMPRESASBE.IEM_DATABASE = this.EM_DATABASETextBox.Text.ToString();
            }
            if (this.EM_USUARIOTextBox.Text != "")
            {
                EMPRESASBE.IEM_USUARIO = this.EM_USUARIOTextBox.Text.ToString();
            }
            if (this.EM_PASSWORDTextBox.Text != "")
            {
                EMPRESASBE.IEM_PASSWORD = this.EM_PASSWORDTextBox.Text.ToString();
            }
            if (this.EM_SERVERTextBox.Text != "")
            {
                EMPRESASBE.IEM_SERVER = this.EM_SERVERTextBox.Text.ToString();
            }

            if (EM_CAJAComboBox.SelectedIndex >= 0)
            {
                EMPRESASBE.IEM_CAJA = int.Parse(this.EM_CAJAComboBox.SelectedValue.ToString());
                EMPRESASBE.IEM_CAJA_NOMBRE = this.EM_CAJAComboBox.SelectedText.ToString();
            }

            EMPRESASBE.IHABILITAR_IMPEXP_AUT = (this.HABILITAR_IMPEXP_AUTCheckBox.Checked ? "S" : "N");
            
            EMPRESASBE.IESMATRIZ = (this.ESMATRIZCheckBox.Checked ? "S" : "N");

            EMPRESASBE.IRED = EM_COLOR_RED;
            EMPRESASBE.IGREEN = EM_COLOR_GREEN;
            EMPRESASBE.IBLUE = EM_COLOR_BLUE;
            
            return EMPRESASBE;
        }
        public void SaveChanges()
        {
            string ErroresValidacion = "";
            if (this.opc == "Borrar")
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarKeys);
            else
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarTodos);
            this.LBError.Text = ErroresValidacion;
            if (ErroresValidacion == "")
            {
                try
                {
                    CEMPRESASD EMPRESASD = new CEMPRESASD();
                    if (opc == "Agregar")
                    {
                        CEMPRESASBE EMPRESASBE = new CEMPRESASBE();
                        EMPRESASBE = ObtenerDatosCapturados();

                        if (EMPRESASBE.IESMATRIZ == "S")
                        {

                            if (MessageBox.Show("Esta guardando esta sucursal como matriz.. Debe estar seguro de que ninguna otra maquina dentro del sistema total este tambien configurada como matriz. De lo contrario resultados inesperados pueden ocurror. Desea continuar? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                return;
                            }
                        }

                        if (!CBCustomConn.Checked)
                        {
                            string dataPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                            
                            EMPRESASBE.IEM_SERVER = "localhost";
                            EMPRESASBE.IEM_USUARIO = "sysdba";
                            EMPRESASBE.IEM_PASSWORD= "masterkey";
                            EMPRESASBE.IEM_DATABASE = /*dataPath*/@"{BaseDirectory}" + "\\Data\\" + EMPRESASBE.IEM_NOMBRE.Replace(" ", "_") + "\\iposdb.fdb";
                            
                        }
                      
                        EMPRESASD.AgregarEMPRESAS(EMPRESASBE, null);
                        if (EMPRESASD.IComentario == "" || EMPRESASD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.ParentForm.Close();
                        }
                        else
                            MessageBox.Show("ERRORES: " + EMPRESASD.IComentario.Replace("%", "\n"));
                    }
                    else if (opc == "Cambiar")
                    {
                        CEMPRESASBE EMPRESASBEAnt = new CEMPRESASBE();
                        CEMPRESASBE EMPRESASBE = new CEMPRESASBE();
                        EMPRESASBE = ObtenerDatosCapturados();

                        if (EMPRESASBE.IESMATRIZ == "S")
                        {
                            if (MessageBox.Show("Esta guardando esta sucursal como matriz.. Debe estar seguro de que ninguna otra maquina dentro del sistema total este tambien configurada como matriz. De lo contrario resultados inesperados pueden ocurror. Desea continuar? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                return;
                            }
                        }

                        EMPRESASBEAnt.IEM_NOMBRE = this.EM_NOMBRE;
                        EMPRESASD.CambiarEMPRESAS(EMPRESASBE, EMPRESASBEAnt, null);
                        if (EMPRESASD.IComentario == "" || EMPRESASD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.ParentForm.Close();
                        }
                        else
                            MessageBox.Show("ERRORES: " + EMPRESASD.IComentario.Replace("%", "\n"));
                    }
                    else if (opc == "Borrar")
                    {
                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CEMPRESASBE EMPRESASBEAnt = new CEMPRESASBE();
                            EMPRESASBEAnt.IEM_NOMBRE = this.EM_NOMBRE;
                            EMPRESASD.BorrarEMPRESAS(EMPRESASBEAnt, null);
                            if (EMPRESASD.IComentario == "" || EMPRESASD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);
                                this.ParentForm.Close();
                            }
                            else
                                MessageBox.Show("ERRORES: " + EMPRESASD.IComentario.Replace("%", "\n"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error Asegurese de que metio los datos en el formato correcto " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(ErroresValidacion);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }
        private void HabilitarEdicion(bool b)
        {
            HabilitarValidadores(false);
            panel1.Enabled = b;
            HabilitarValidadores(true);
        }
        private void LimpiarVariablesForm()
        {
            this.EM_NOMBRE = "";
        }
        private void Limpiar()
        {
            Limpiar(false);
        }
        private void Limpiar(bool bLimpiarKeys)
        {
            if (bLimpiarKeys)
            {
                this.EM_NOMBRETextBox.Text = "";
            }
            this.EM_DATABASETextBox.Text = "";
            this.EM_USUARIOTextBox.Text = "";
            this.EM_PASSWORDTextBox.Text = "";
            this.EM_SERVERTextBox.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ShowLookUp();
        }
        private void ShowLookUp()
        {
            GeneralLookUp look = new GeneralLookUp("select * from EMPRESAS", "EMPRESAS");
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.EM_NOMBRETextBox.Text = dr[0].ToString();
            }
            SetMode();
        }
        private void EM_NOMBRETextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ShowLookUp();
            }
        }
        private void SetMode()
        {
            if (
              this.EM_NOMBRETextBox.Text != ""
          )
            {
                this.EM_NOMBRE = this.EM_NOMBRETextBox.Text;
                if (this.LlenarDatosDeBase())
                {
                    this.opc = "Cambiar";
                    HabilitarEdicion(true);
                    this.btEliminar.Enabled = true;
                }
                else
                {
                    this.opc = "Agregar";
                    Limpiar();
                    HabilitarEdicion(true);
                    this.btEliminar.Enabled = false;
                }
            }
            else
            {
                Limpiar();
                HabilitarEdicion(false);
                this.btEliminar.Enabled = false;
            }
        }
        private void EM_NOMBRETextBox_Validated(object sender, EventArgs e)
        {
            SetMode();
        }
        private void btEliminar_Click(object sender, EventArgs e)
        {
            this.opc = "Borrar";
            SaveChanges();
        }
        public void Resetear() // new for generator
        {
            HabilitarValidadores(false); // new generator
            Limpiar(true);
            this.opc = "";
            this.EM_NOMBRETextBox.Focus();
            HabilitarValidadores(true);
            this.HabilitarEdicion(false);
        }
        public void HabilitarValidadores(bool bEnabled) // new for generator
        {
            CustomValidation.BaseValidator[] validors = new CustomValidation.BaseValidator[this.validadores.Count];
            this.validadores.CopyTo(validors, 0);
            foreach (CustomValidation.BaseValidator v in validors)
            {
                try
                {
                    v.Enabled = bEnabled;
                }
                catch
                {
                }
            }
        }
        public void Validar(ref string ErroresValidacion, int iCamposAValidar)
        {
            CustomValidation.BaseValidator[] validors = new CustomValidation.BaseValidator[this.validadores.Count];
            this.validadores.CopyTo(validors, 0);
            foreach (CustomValidation.BaseValidator v in validors)
            {
                try
                {
                    if (iCamposAValidar == (int)CamposAValidar.ValidarKeys)
                    {
                        if (
                        v.ControlToValidate.Name != "EM_NOMBRETextBox"
                        )
                            continue;
                    }
                    v.Validate();
                    if (!v.IsValid)
                    {
                        ErroresValidacion += v.ErrorMessage + "--";
                    }
                }
                catch
                {
                }
            }
        }
        private void BTExaminar_Click(object sender, EventArgs e)
        {
            if (this.OpenFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.EM_DATABASETextBox.Text = this.OpenFileDialog2.FileName;
            }
        }
        private void CBDefault_Validated(object sender, EventArgs e)
        {
            if (this.CBCustomConn.Checked)
            {
                this.GBConecctionData.Enabled = true;
            }
            else
            {
                this.GBConecctionData.Enabled = false;
            }
        }








        public void LlenarComboCajas()
        {

            DataSet dsCajas = ObtenerTablaCajas(this.EM_SERVERTextBox.Text,
                this.EM_DATABASETextBox.Text.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)),
                this.EM_USUARIOTextBox.Text,
                this.EM_PASSWORDTextBox.Text);
            this.EM_CAJAComboBox.DataSource = null;
            if (dsCajas != null)
            {
                this.EM_CAJAComboBox.DataSource = dsCajas.Tables[0].DefaultView;
                this.EM_CAJAComboBox.ValueMember = "ID";
                this.EM_CAJAComboBox.DisplayMember = "NOMBRE";
            }
        }

        public DataSet ObtenerTablaCajas(string server, string dataLocation,string usuario, string password)
        {
            
            string connectionStr = "data source=" + server + ";initial catalog=\"" + dataLocation + "\";user id=" + usuario + ";password=" + password + "; pooling=false";
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                String CmdTxt = @"select id, nombre from CAJA   ";



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                DataSet dr;
                dr = SqlHelper.ExecuteDataset(connectionStr, CommandType.Text, CmdTxt, arParms);
           



                return dr;
            }
            catch
            {
                return null;
            }



        }

        private void BTRefreshComboCaja_Click(object sender, EventArgs e)
        {

            try
            {
                LlenarComboCajas();
            }
            catch
            {
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();

            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;

            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;

            // Sets the initial color select to the current text color,
            // so that if the user cancels out, the original color is restored.
            MyDialog.Color = Color.FromArgb(255, EM_COLOR_RED, EM_COLOR_GREEN, EM_COLOR_BLUE);

            // Open color selection dialog box
            MyDialog.ShowDialog();

            EM_COLOR_BLUE = (int)MyDialog.Color.B;
            EM_COLOR_GREEN = (int)MyDialog.Color.G;
            EM_COLOR_RED = (int)MyDialog.Color.R;

            pnlColor.BackColor = Color.FromArgb(255, EM_COLOR_RED, EM_COLOR_GREEN, EM_COLOR_BLUE);


            MyDialog.Dispose();
            GC.SuppressFinalize(MyDialog);
        }

        

    }
}

