
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using FirebirdSql.Data.FirebirdClient;
namespace iPos
{
    public partial class UCUSUARIOSEdit : UserControl
    {
        string opc;
        System.Collections.ArrayList validadores;
        long m_personaId;//US_USERID
        public UCUSUARIOSEdit()
        {
            InitializeComponent();
        }
        public void ReCargar(string popc,long  personaId)
        {
            opc = popc;
            m_personaId = personaId;
            validadores = new System.Collections.ArrayList();
            
            validadores.Add((RFV_US_USUARIO));
            
            
            validadores.Add(RAV_US_LIMITE_CONEXIONES);
            validadores.Add(RAV_US_CONEXIONES_ABIERTAS);
            this.button1.Text = opc;
            
            if (this.opc != "Agregar")
            {
                if (this.opc == "Consultar") { this.button1.Visible = false; }
                LlenarDatosDeBase();
                this.US_USERIDTextBox.Enabled = false;
            }
        }
        private void USUARIOSEdit_Load(object sender, EventArgs e)
        {
        }
        private void LlenarDatosDeBase()
        {
            try
            {
                this.FbCommand1.Parameters["@US_USERID"].Value = this.m_personaId;
                DataTable dt = new DataTable();
                dt = DataTablesParaGrid.GetData(this.FbCommand1);
                this.US_USERIDTextBox.Text = dt.Rows[0]["ID"].ToString();
                this.US_USUARIOTextBox.Text = dt.Rows[0]["USERNAME"].ToString();
                this.US_PASSWORDTextBox.Text = dt.Rows[0]["CLAVEACCESO"].ToString();
                this.US_NOMBRETextBox.Text = dt.Rows[0]["NOMBRE"].ToString();
                //this.US_VENDEDORTextBox.Text = dt.Rows[0]["US_VENDEDOR"].ToString();
                //this.US_EMPRESATextBox.Text = dt.Rows[0]["US_EMPRESA"].ToString();
                this.US_R_PASSWORDTextBox.Text = dt.Rows[0]["RESET_PASS"].ToString();
                //this.US_LIMITE_CONEXIONESTextBox.Text = dt.Rows[0]["US_LIMITE_CONEXIONES"].ToString();
                //this.US_CONEXIONES_ABIERTASTextBox.Text = dt.Rows[0]["US_CONEXIONES_ABIERTAS"].ToString();
                try
                {
                    this.US_VIGENCIATextBox.Value = DateTime.Parse(dt.Rows[0]["VIGENCIA"].ToString());
                }
                catch
                {
                }
                //this.US_ALMACENIDTextBox.Text = dt.Rows[0]["US_ALMACENID"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
            }
        }
        private CPERSONABE ObtenerDatosCapturados()
        {
            CPERSONABE USUARIOSBE = new CPERSONABE();
            if (this.US_USUARIOTextBox.Text != "")
            {
                USUARIOSBE.IUSERNAME = this.US_USUARIOTextBox.Text.ToString();
                USUARIOSBE.ICLAVE = this.US_USUARIOTextBox.Text.ToString();
            }
            if (this.US_PASSWORDTextBox.Text != "")
            {
                USUARIOSBE.ICLAVEACCESO = this.US_PASSWORDTextBox.Text.ToString();
            }
            if (this.US_NOMBRETextBox.Text != "")
            {
                USUARIOSBE.INOMBRE = this.US_NOMBRETextBox.Text.ToString();
            }
            //if (this.US_VENDEDORTextBox.Text != "")
            //{
            //    USUARIOSBE.IUS_VENDEDOR = this.US_VENDEDORTextBox.Text.ToString();
            //}
            //if (this.US_EMPRESATextBox.Text != "")
            //{
            //    USUARIOSBE.IUS_EMPRESA = this.US_EMPRESATextBox.Text.ToString();
            //}
            if (this.US_R_PASSWORDTextBox.Text != "")
            {
                USUARIOSBE.IRESET_PASS = short.Parse(this.US_R_PASSWORDTextBox.Text.ToString());
            }
            if (this.US_USERIDTextBox.Text != "")
            {
                USUARIOSBE.IID = long.Parse(this.US_USERIDTextBox.Text.ToString());
            }
            //if (this.US_LIMITE_CONEXIONESTextBox.Text != "")
            //{
            //    USUARIOSBE.IUS_LIMITE_CONEXIONES = long.Parse(this.US_LIMITE_CONEXIONESTextBox.Text.ToString());
            //}
            //if (this.US_CONEXIONES_ABIERTASTextBox.Text != "")
            //{
            //    USUARIOSBE.IUS_CONEXIONES_ABIERTAS = long.Parse(this.US_CONEXIONES_ABIERTASTextBox.Text.ToString());
            //}
            USUARIOSBE.IVIGENCIA = this.US_VIGENCIATextBox.Value;
            //if (this.US_ALMACENIDTextBox.Text != "")
            //{
            //    USUARIOSBE.IUS_ALMACENID = Int32.Parse(this.US_ALMACENIDTextBox.Text.ToString());
            //}
            return USUARIOSBE;
        }
        public void LimpiarDatos()
        {
            this.US_USERIDTextBox.Enabled = true;
            this.US_USERIDTextBox.Text = "";
            this.US_USUARIOTextBox.Text = "";
            this.US_PASSWORDTextBox.Text = "";
            this.US_NOMBRETextBox.Text = "";
            this.US_VENDEDORTextBox.Text = "";
            this.US_EMPRESATextBox.Text = "";
            this.US_R_PASSWORDTextBox.Text = "";
            this.US_LIMITE_CONEXIONESTextBox.Text = "";
            this.US_CONEXIONES_ABIERTASTextBox.Text = "";
            try
            {
                this.US_VIGENCIATextBox.Value = DateTime.Today;
            }
            catch
            {
            }
            this.US_ALMACENIDTextBox.Text = "";
        }
        public bool Eliminar()
        {
            CPERSONAD USUARIOSD = new CPERSONAD();
            try
            {
                CPERSONABE USUARIOSBEAnt = new CPERSONABE();
                USUARIOSBEAnt.IID = this.m_personaId;
                USUARIOSD.BorrarPERSONAD(USUARIOSBEAnt, null);
                if (USUARIOSD.IComentario == "" || USUARIOSD.IComentario == null)
                {
                    
                    MessageBox.Show("El registro se ha eliminado");
                }
                else
                {
                    MessageBox.Show("ERRORES: " + USUARIOSD.IComentario.Replace("%", "\n"));
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error Asegurese de que metio los datos en el formato correcto " + ex.Message);
                return false;
            }
            return true;
        }
        public bool SaveChanges(FbTransaction fTrans, ref CPERSONABE uReturnUser)
        {
            string ErroresValidacion = "";
            CustomValidation.BaseValidator[] validors = new CustomValidation.BaseValidator[this.validadores.Count];
            this.validadores.CopyTo(validors, 0);
            foreach (CustomValidation.BaseValidator v in validors)
            {
                try
                {
                    v.Validate();
                    if (!v.IsValid)
                    {
                        ErroresValidacion += v.ErrorMessage + "--";
                    }
                }
                catch
                {
                    return false;
                }
            }
            this.LBError.Text = ErroresValidacion;
            if (ErroresValidacion == "")
            {
                try
                {
                    CPERSONAD USUARIOSD = new CPERSONAD();
                    if (opc == "Agregar")
                    {
                        CPERSONABE USUARIOSBE = new CPERSONABE();
                        USUARIOSBE = ObtenerDatosCapturados();
                        USUARIOSBE.IRESET_PASS = 1;
                        uReturnUser = USUARIOSD.AgregarPERSONAUSUARIOD(USUARIOSBE, fTrans);
                        if (USUARIOSD.IComentario == "" || USUARIOSD.IComentario == null)
                        {
                            US_USERIDTextBox.Text = USUARIOSBE.IID.ToString();
                            MessageBox.Show("El registro se ha insertado");
                        }
                        else
                        {
                            MessageBox.Show("ERRORES: " + USUARIOSD.IComentario.Replace("%", "\n"));
                            return false;
                        }
                    }
                    else if (opc == "Cambiar")
                    {
                        CPERSONABE USUARIOSBEAnt = new CPERSONABE();
                        CPERSONABE USUARIOSBE = new CPERSONABE();
                        USUARIOSBE = ObtenerDatosCapturados();
                        USUARIOSBEAnt.IID = this.m_personaId;
                        USUARIOSD.CambiarPERSONAUSUARIOD(USUARIOSBE, USUARIOSBEAnt, fTrans);
                        if (USUARIOSD.IComentario == "" || USUARIOSD.IComentario == null)
                        {
                            uReturnUser = USUARIOSBE;
                            MessageBox.Show("El registro se ha cambiado");
                        }
                        else
                        {
                            MessageBox.Show("ERRORES: " + USUARIOSD.IComentario.Replace("%", "\n"));
                            return false;
                        }
                    }
                    else if (opc == "Borrar")
                    {
                        CPERSONABE USUARIOSBEAnt = new CPERSONABE();
                        USUARIOSBEAnt.IID = this.m_personaId;
                        USUARIOSD.BorrarPERSONAD(USUARIOSBEAnt, null);
                        if (USUARIOSD.IComentario == "" || USUARIOSD.IComentario == null)
                        {
                            uReturnUser = USUARIOSBEAnt;
                            MessageBox.Show("El registro se ha eliminado");
                        }
                        else
                        {
                            MessageBox.Show("ERRORES: " + USUARIOSD.IComentario.Replace("%", "\n"));
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error Asegurese de que metio los datos en el formato correcto " + ex.Message);
                    return false;
                }
            }
            return true;
        }
        public void SetUsuarioField(string strUsuario)
        {
            this.US_USUARIOTextBox.Text = strUsuario;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans;
            CPERSONABE user = new CPERSONABE();
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                if (SaveChanges(fTrans, ref user))
                {
                    fTrans.Commit();
                }
                else
                {
                    fTrans.Rollback();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fConn.Close();
            }
        }
    }
}
