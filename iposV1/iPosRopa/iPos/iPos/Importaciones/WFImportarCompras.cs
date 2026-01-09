using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer.Importaciones;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;
using ConexionesBD;

namespace iPos
{
     public partial class WFImportarCompras : IposForm
    {
        private long m_TipoDoctoID;



        public WFImportarCompras()
        {
            InitializeComponent();
            m_TipoDoctoID = 11;
        }

        public WFImportarCompras(long TipoDoctoID) : this()
        {
            m_TipoDoctoID = TipoDoctoID;
        }
        private void WFImportarCompras_Load(object sender, EventArgs e)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_ELIMINAR_PEDIDOS, null))
            {

                iMP_FILESDataGridView.Columns["Eliminar"].Visible = false;
            }


            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            sucursalBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);
            if (sucursalBE.IMOSTRARPRECIOREAL == "N")
                this.iMP_FILESDataGridView.Columns["GR_TOTAL"].Visible = false;

            // TODO: This line of code loads data into the 'dSImportaciones.COMPRASINCOMPLETAS' table. You can move, or remove it, as needed.
            this.cOMPRASINCOMPLETASTableAdapter.Fill(this.dSImportaciones.COMPRASINCOMPLETAS, (int)m_TipoDoctoID);
            
            
        }


        private void iMP_FILESDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && this.iMP_FILESDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() == "Recibir")
            {
                WFImportarComprasDet fic;

                fic = new WFImportarComprasDet((long)iMP_FILESDataGridView["GR_ID", e.RowIndex].Value, m_TipoDoctoID);
                                                
                fic.ShowDialog();
                fic.Dispose();
                GC.SuppressFinalize(fic);

                this.cOMPRASINCOMPLETASTableAdapter.Fill(this.dSImportaciones.COMPRASINCOMPLETAS, (int)m_TipoDoctoID);
            }
            else if (e.RowIndex >= 0 && this.iMP_FILESDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() == "Eliminar")
            {

                if (MessageBox.Show("Quiere eliminar el pedido?", "Eliminar el pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                    if (EliminarDocto((long)iMP_FILESDataGridView["GR_ID", e.RowIndex].Value, CurrentUserID.CurrentUser.IID, null))
                    {
                        this.cOMPRASINCOMPLETASTableAdapter.Fill(this.dSImportaciones.COMPRASINCOMPLETAS, (int)m_TipoDoctoID);
                    }

            }
        }




        public bool EliminarDocto(long doctoID, long vendedorId, FbTransaction st)
        {
            try
            {
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                bool iResult;


                doctoBE.IID = doctoID;

                doctoBE = doctoD.seleccionarDOCTO(doctoBE, st);

                if (doctoBE == null)
                {
                    MessageBox.Show("El docto ya no existe");
                    return false;
                }



                //Generar el archivo a enviar de log mail antes de eliminar el docto
                string strArchivoEnvioMail = GenerarArchivoDeDocto( (int)doctoBE.IID);

                if (doctoBE.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                {
                    if (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_REC)
                    {
                        iResult = doctoD.IgnorarTrasladoDOCTOD(doctoBE, st);
                    }
                    else
                       iResult = doctoD.BorrarDOCTOD(doctoBE, st);
                }
                else
                    iResult = doctoD.CancelarDOCTOD(doctoBE, vendedorId, st);


                if (!iResult)
                {
                    MessageBox.Show(doctoD.IComentario);
                    return false;
                }

                //Enviar el mail
                EnvioMailRecepcionEliminada(strArchivoEnvioMail);

                HiloExistencias._IFLAGRECEPCIONREGISTROTRASLAEVENTOS++;

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }
        }

        private string GenerarArchivoDeDocto(int doctoID)
        {


            string[] columnTitlesExcel = new string[] {  "REFERENCIA",
                                                        "PRODUCTO",	
                                                        "DESCRIPCION",	
                                                        "LOTE",	
                                                        "CANTIDAD",	
                                                        "",	
                                                        ""    };


            try
            {
                this.mAILRECEPCIONTableAdapter.Fill(this.dSImportaciones.MAILRECEPCION, doctoID);


                CSUCURSALD sucursalD = new CSUCURSALD();
                CSUCURSALBE sucursalBE = new CSUCURSALBE();
                sucursalBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;
                sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

                if (sucursalBE != null)
                {
                    string strArchivoSoloNombre = CurrentUserID.CurrentParameters.ISUCURSALNUMERO + " " + DateTime.Today.ToString("dd_MM_yyyy") + " " + doctoID + " " + EnviosMail.str_FileExcelNameEliminarRec;
                    string strArchivo = System.AppDomain.CurrentDomain.BaseDirectory + EnviosMail.FileLocalLocation_Excel + "\\" + strArchivoSoloNombre;


                    if (EnviosMail.Excel_FromDataTable(this.dSImportaciones.MAILRECEPCION, strArchivo, columnTitlesExcel, sucursalBE))
                    {

                        return strArchivoSoloNombre;
                    }
                }

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return "";

        }



        private bool EnvioMailRecepcionEliminada(string strArchivoSoloNombre)
        {
            CEXP_FILESD expFileD = new CEXP_FILESD();
            CEXP_FILESBE expFile = new CEXP_FILESBE();

            string strArchivo = System.AppDomain.CurrentDomain.BaseDirectory + EnviosMail.FileLocalLocation_Excel + "\\" + strArchivoSoloNombre;


            if (!EnviosMail.EnviarRecepcionEliminada("", strArchivo))
            {
                expFile = new CEXP_FILESBE();
                expFile.ITIPO = DBValues._EXP_FILES_TIPO_REC_ELIM_MAIL;
                expFile.INOMBRE = strArchivoSoloNombre;
                expFile.IARCHIVOFTP = strArchivoSoloNombre;
                expFile.IFECHA = DateTime.Now;
                expFile.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;

                expFileD.AgregarEXP_FILESD(expFile, null);


            }
            return true;
        }






    }
}
