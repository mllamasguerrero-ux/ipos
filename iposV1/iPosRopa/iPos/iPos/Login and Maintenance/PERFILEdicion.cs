using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using FirebirdSql.Data.FirebirdClient;
using static iPos.Login_and_Maintenance.DSSeguridad;
using System.IO;

namespace iPos
{
    public partial class PERFILEdicion : IposForm
    {
        string opc;
        int PF_PERFIL;
        string PF_DESCRIPCION;
        public PERFILEdicion()
        {
            InitializeComponent();
        }




        public void ReCargar(string popc, int pPF_PERFIL)
        {
            opc = popc;
            //PF_DESCRIPCION = pPF_DESCRIPCION;
            //validadores = new System.Collections.ArrayList();
            //validadores.Add(RFV_CLAVE);
            PF_PERFIL = pPF_PERFIL;

            this.button1.Text = opc;
            if (this.opc != "Agregar" && this.opc != "")
            {
                this.PF_DESCRIPCIONTextBox.Enabled = false;
                if (this.opc == "Consultar") { 
                    this.button1.Visible = false; 
                    pERFILES_DERECHOSDataGridView.ReadOnly = true;
                    BtnCopiarDe.Enabled = false;
                    this.BTCancelar.Text = "Salir";
                    this.BTCancelar.Image = global::iPos.Properties.Resources.Exit;
                }
                LlenaDatos();
                //this.CLAVETextBox.Enabled = false;
            }
            else if (this.opc == "Agregar")
            {
                this.PF_DESCRIPCIONTextBox.Enabled = true; //this.BTIniciaEdicion.Enabled = false;
                pERFILES_DERECHOSDataGridView.ReadOnly = false;
                BtnCopiarDe.Enabled = true;
                PF_PERFIL = 0;
                LlenarGrid(this.PF_PERFIL);
            }
        }

        
        private void LlenaDatos()
        {
            CPERFILESBE PERFILESBE = new CPERFILESBE();
            CPERFILESD PERFILESD = new CPERFILESD();
            PERFILESBE.IPF_PERFIL = PF_PERFIL;         
            PERFILESBE = PERFILESD.seleccionarPERFILES(PERFILESBE, null);
            this.PF_DESCRIPCIONTextBox.Text = PERFILESBE.IPF_DESCRIPCION;
            PF_DESCRIPCION = PERFILESBE.IPF_DESCRIPCION;
            LlenarGrid(this.PF_PERFIL);

        }
        private void SaveChanges()
        {
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans;
            CPERFILESBE perfilBE = new CPERFILESBE();
            CPERFILESD perfilD = new CPERFILESD();
            bool bContinue = true;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                if (this.opc == "Agregar")
                {
                    perfilBE.IPF_DESCRIPCION = this.PF_DESCRIPCIONTextBox.Text;
                    perfilBE = perfilD.AgregarPERFILES(perfilBE, fTrans);
                    if (perfilBE == null)
                        bContinue = false;

                    this.PF_PERFIL = perfilBE.IPF_PERFIL;
                }
                //else if (this.opc == "Cambiar")
                //{
                //    CPERFILESBE PERFILESBEAnt = new CPERFILESBE();
                //    PERFILESBEAnt.IPF_PERFIL = this.PF_PERFIL;
                //    perfilBE.IPF_PERFIL = this.PF_PERFIL;
                //    perfilBE.IPF_DESCRIPCION = this.PF_DESCRIPCIONTextBox.Text;
                //    bContinue = perfilD.CambiarPERFILES(perfilBE, PERFILESBEAnt, fTrans);
                //}
                if (bContinue)
                {
                    if (this.GuardarDerechos(this.PF_PERFIL, fTrans))
                   {
                        fTrans.Commit();
                        MessageBox.Show("Se han guardado los cambios");
                        this.Close();
                //        LimpiarInterfaces();
                //        HabilitarInterfaces(false);
                //        this.PF_DESCRIPCIONTextBox.Text = "";
                //        this.opc = "";
                //        this.PF_DESCRIPCIONTextBox.Focus();
                    }
                    else
                    {
                        fTrans.Rollback();
                   }
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
        private void PERFILEdicion_Load(object sender, EventArgs e)
        {
            CBBuscar.SelectedIndex = 0;
        }

        private void PF_DESCRIPCIONTextBox_Validating(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void LlenarGrid(Int32 iPerfilId)
        {
            try
            {
                this.pERFILES_DERECHOSTableAdapter.Fill(this.dSSeguridad.PERFILES_DERECHOS, iPerfilId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }





        public Boolean GuardarDerechos(Int32 iPerfilId, FbTransaction fTrans)
        {
            CPERFIL_DERBE oUPerBe = new CPERFIL_DERBE();
            CPERFIL_DERD oUPerD = new CPERFIL_DERD();

            if (iPerfilId == -1)
            {
                return false;
            }

            try
            {
                quitarFiltro();

                oUPerBe.IPD_PERFIL = iPerfilId;
                oUPerD.BorrarDerechosDePerfil(oUPerBe, fTrans);
                foreach (DataGridViewRow dataRow in this.pERFILES_DERECHOSDataGridView.Rows)
                {
                    if (
                        dataRow.Cells["dgPermitido"].Value != null
                        && dataRow.Cells["dgPermitido"].Value != DBNull.Value
                        && ((int)dataRow.Cells["dgPermitido"].Value == 1))
                    {


                        if (dataRow.Cells["dgDerecho"].Value != null
                            && dataRow.Cells["dgDerecho"].Value != DBNull.Value)
                        {
                            oUPerBe = new CPERFIL_DERBE();
                            oUPerBe.IPD_PERFIL = iPerfilId;
                            oUPerBe.IPD_DERECHO = (int)dataRow.Cells["dgDerecho"].Value;
                            oUPerD.AgregarPERFIL_DER(oUPerBe, fTrans);
                        }

                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {

                aplicarFiltro();
            }

            return true;
        }


        public Int32 ShowLookUpCopiarDe(Int32 iPerfilId)
        {
            GeneralLookUp look = new GeneralLookUp("select PF_PERFIL, PF_DESCRIPCION from perfiles where PF_PERFIL <> " + iPerfilId.ToString(), "Copiar Perfil");
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                return (Int32)dr[0];
            }
            return -1;
        }

        private void BtnCopiarDe_Click(object sender, EventArgs e)
        {
            Int32 iCopiarDe = ShowLookUpCopiarDe(this.PF_PERFIL);
            if (iCopiarDe >= 0)
            {
                LlenarGrid(iCopiarDe);
            }
        }

        private void BTCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pERFILES_DERECHOSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void aplicarFiltro()
        {

            DataView dv = new DataView(this.dSSeguridad.PERFILES_DERECHOS);

            if (TBBuscar.Text.Trim().Length > 0)
            {
                if (CBBuscar.SelectedIndex == 0)
                {
                    try
                    {

                        int iDerecho = int.Parse(TBBuscar.Text);
                        dv.RowFilter = string.Format("DR_DERECHO = {0}", iDerecho.ToString());
                    }
                    catch
                    {

                    }
                }
                else
                {

                    dv.RowFilter = string.Format("DR_DESCRIPCION LIKE '%{0}%'", TBBuscar.Text);
                }
            }

            pERFILES_DERECHOSDataGridView.DataSource = dv;
        }

        private void quitarFiltro()
        {

            DataView dv = new DataView(this.dSSeguridad.PERFILES_DERECHOS);
            pERFILES_DERECHOSDataGridView.DataSource = dv;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            aplicarFiltro();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            try
            {

                saveFileDialog1.FileName = "perfilderechos.txt";


                int result = (int)this.saveFileDialog1.ShowDialog();
                string pathAndName = "";

                if (result == (int)System.Windows.Forms.FolderBrowserResult.OK)
                {
                    // folderName = this.folderBrowserDialog1.SelectedPath;
                    pathAndName = saveFileDialog1.FileName;
                }
                else
                {
                    return ;
                }

                string strDerechos = "";
                int iCount = 0;
                foreach(PERFILES_DERECHOSRow dr in dSSeguridad.PERFILES_DERECHOS.Rows)
                {

                    if (dr.PERMITIDO != 1)
                        continue;

                    if(iCount > 0)
                    {
                        strDerechos += ",";
                    }

                    strDerechos += dr.DR_DERECHO.ToString();

                    iCount++;
                }


                File.WriteAllText(pathAndName, strDerechos);
            }
            catch
            {

            }

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            string pathAndName = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //primero pon todos en false

                    foreach (PERFILES_DERECHOSRow dr in dSSeguridad.PERFILES_DERECHOS.Rows)
                    {
                        dr.PERMITIDO = 0;
                    }


                        pathAndName = openFileDialog1.FileName;
                    string strDerechos = File.ReadAllText(pathAndName);
                    
                    string[] strDerechosSplit = strDerechos.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach(string strDerecho in strDerechosSplit)
                    {

                        PERFILES_DERECHOSRow dr = (PERFILES_DERECHOSRow)dSSeguridad.PERFILES_DERECHOS.Select("DR_DERECHO = " + strDerecho).FirstOrDefault();

                        if(dr != null)
                            dr.PERMITIDO = 1;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
