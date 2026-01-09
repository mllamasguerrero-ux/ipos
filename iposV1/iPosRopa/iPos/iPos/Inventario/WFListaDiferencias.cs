using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;
using System.Threading;
using iPos.Inventario;

namespace iPos
{
    public partial class WFListaDiferencias : IposForm
    {
        CDOCTOBE m_Docto;
        string m_sCadenaConexion;
        string m_Comentario = "";
        bool m_ProcessSuccess = false;

        int m_posicionActual = 0;
        long m_productoIdABuscar = 0;

        bool m_bImprimirSoloDiferenciasTicket = false;



        string[] m_columnTitlesExcel = new string[] {   "",
                                                        "PRODUCTO",	
                                                        "DESCRIPCION",	
                                                        "LOTE",
                                                        "FECHA VENCIMIENTO",	
                                                        "CANT. TEORICA",	
                                                        "CANT. FISICA",	
                                                        "CANT. DIFERENCIA",	
                                                        "",	
                                                        ""};


        string[] m_columnTitlesExcelXLoc = new string[] {   
                                                        "ANAQUEL",
                                                        "LOCALIDAD",
                                                        "",	
                                                        "PRODUCTO",	
                                                        "DESCRIPCION",	
                                                        "LOTE",
                                                        "FECHA VENCIMIENTO",	
                                                        "",	
                                                        "",	
                                                        "",	
                                                        "",	
                                                        "",	
                                                        "CAJAS",	
                                                        "PIEZAS"      };



        private string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }

        bool m_bEsInventarioCiclico = false;


        public WFListaDiferencias()
        {
            InitializeComponent();
            m_Docto = new CDOCTOBE();
            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_INVENTARIO_FISICO;
            m_sCadenaConexion = ConexionBD.ConexionString();
        }


        public WFListaDiferencias(long doctoId) :
            this()
        {
            m_Docto.IID = doctoId;
            ObtenerDoctoDeBD(doctoId);
            LlenarGrid(doctoId);
            SetHabilitaciones();
        }

        private void ObtenerDoctoDeBD(long lDoctoID)
        {
            CDOCTOD vDocto = new CDOCTOD();
            m_Docto = new CDOCTOBE();
            m_Docto.IID = lDoctoID;
            m_Docto = vDocto.seleccionarDOCTO(m_Docto, null);

            this.LBConsecutivo.Text = m_Docto.IID.ToString();
            this.LBFolio.Text = m_Docto.IFOLIO.ToString();
            this.LBDateValue.Text = m_Docto.IFECHA.ToShortDateString();
            

        }


        private void LlenarGrid(long lDoctoID)
        {
            try
            {

                BindingSource bufferBinding = null;

                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_INVENTARIO_FISICO)
                {

                    if (m_Docto.IKITDESGLOSADO != null && m_Docto.IKITDESGLOSADO.Equals("S"))
                    {
                        this.gET_INVFIS_LISTADETALLES_PKITTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_LISTADETALLES_PKIT, (int)lDoctoID, 0);//,((this.CBMostrarSoloDif.Checked) ? "1" : "0")
                        bufferBinding = gET_INVFIS_LISTADETALLES_PKITBindingSource;
                    }
                    else
                    {
                        this.gET_INVFIS_LISTADETALLESTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_LISTADETALLES_P, (int)lDoctoID, 0);
                        bufferBinding = gET_INVFIS_LISTADETALLESBindingSource;
                    }
                }
                else
                {
                    if (m_Docto.IKITDESGLOSADO != null && m_Docto.IKITDESGLOSADO.Equals("S"))
                    {
                        this.gET_INVFIS_LISTADETALLES_PXLOC_KITTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_LISTADETALLES_PXLOC_KIT, (int)lDoctoID, 0);
                        bufferBinding = gET_INVFIS_LISTADETALLES_PXLOC_KITBindingSource;
                    }
                    else
                    {
                    this.gET_INVFIS_LISTADETALLES_PXLOCTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_LISTADETALLES_PXLOC, (int)lDoctoID, 0);//,((this.CBMostrarSoloDif.Checked) ? "1" : "0")
                    bufferBinding = gET_INVFIS_LISTADETALLES_PXLOCBindingSource;
                }
            }
                /**winforms only starts**/

                if ((this.CBMostrarSoloDif.Checked))
                    bufferBinding.Filter = " CANTIDADDIFERENCIA <> 0";
                else
                    bufferBinding.Filter = "";
                /**winforms only ends**/

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void gET_INVFIS_LISTADETALLESDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = gET_INVFIS_LISTADETALLESDataGridView.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.


            if (gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].Index != e.ColumnIndex &&
                gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].Index != e.ColumnIndex &&
                gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].Index != e.ColumnIndex)
                return;
            if (gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].Index == e.ColumnIndex)
            {
                try
                {
                    decimal dCantidadFisica = decimal.Parse(e.FormattedValue.ToString());
                    decimal dCantidadTeorica = decimal.Parse(gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["CANTIDADTEORICA"].Value.ToString());
                    decimal dCantidadDiferencia = dCantidadFisica - dCantidadTeorica;


                    decimal dOldCantidadFisica = decimal.Parse(gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["CANTIDADFISICA"].Value.ToString());
                    if (dOldCantidadFisica == dCantidadFisica)
                        return;


                    if (dCantidadFisica < 0)
                    {
                        MessageBox.Show("La cantidad fisica no puede ser menor que cero");
                        e.Cancel = true;
                        return;
                    }

                    long lMovtoId = long.Parse(gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["MOVTOID"].Value.ToString());
                    if (INVFIS_MOV_UPDATE(lMovtoId, dCantidadFisica, null))
                    {
                        gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["CANTIDADDIFERENCIA"].Value = dCantidadDiferencia;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al intentar hacer el cambio de cantidad");
                        e.Cancel = true;
                        return;
                    }

                }
                catch
                {
                    MessageBox.Show("Cheque el formato de entrada del valor");
                    e.Cancel = true;
                }
            }
            else if (gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].Index == e.ColumnIndex || gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].Index == e.ColumnIndex)
            {

                decimal dCantidadCajas;
                decimal dCantidadPiezas;
                decimal dOldCantidad;

                if (gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].Index == e.ColumnIndex)
                {
                    dCantidadCajas = decimal.Parse(e.FormattedValue.ToString());
                    dCantidadPiezas = decimal.Parse(gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["DGPIEZAS"].Value.ToString());

                    dOldCantidad = decimal.Parse(gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["DGCAJAS"].Value.ToString());
                    if (dCantidadCajas == dOldCantidad)
                        return;
                }
                else
                {
                    dCantidadPiezas = decimal.Parse(e.FormattedValue.ToString());
                    dCantidadCajas = decimal.Parse(gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["DGCAJAS"].Value.ToString());

                    dOldCantidad = decimal.Parse(gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["DGPIEZAS"].Value.ToString());
                    if (dCantidadPiezas == dOldCantidad)
                        return;
                }




                decimal dPzaCaja = 1;
                if (!decimal.TryParse(gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["DGPZACAJA"].Value.ToString(), out dPzaCaja))
                {
                    dPzaCaja = 1;
                }
                if (dPzaCaja == 0)
                    dPzaCaja = 1;

                decimal dCantidadFisica = (dPzaCaja * dCantidadCajas) + dCantidadPiezas;
                decimal dCantidadTeorica = decimal.Parse(gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["CANTIDADTEORICA"].Value.ToString());
                decimal dCantidadDiferencia = dCantidadFisica - dCantidadTeorica;


                if (dCantidadFisica < 0)
                {
                    MessageBox.Show("La cantidad fisica no puede ser menor que cero");
                    e.Cancel = true;
                    return;
                }
                if (dCantidadCajas < 0)
                {
                    MessageBox.Show("La cantidad de cajas no puede ser menor que cero");
                    e.Cancel = true;
                    return;
                }
                if (dCantidadPiezas < 0)
                {
                    MessageBox.Show("La cantidad de piezas no puede ser menor que cero");
                    e.Cancel = true;
                    return;
                }


                long productoId = long.Parse(gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["PRODUCTOID"].Value.ToString());
                string lote = gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["PRODUCTOLOTE"].Value.ToString();

                DateTime fechaVence = DateTime.MinValue;
                if (gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["FECHAVENCE"].Value != null)
                {

                    DateTime.TryParse(gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["FECHAVENCE"].Value.ToString(), out fechaVence);
                }


                if (INVFIS_MOV_UPDATE_XLOC(this.m_Docto.IID, dCantidadCajas, dCantidadPiezas, productoId, lote, fechaVence, null))
                {
                    gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["CANTIDADDIFERENCIA"].Value = dCantidadDiferencia;
                    gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["CANTIDADFISICA"].Value = dCantidadFisica;
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al intentar hacer el cambio de cantidad");
                    e.Cancel = true;
                    return;
                }
            }

        }




        private bool INVFIS_MOV_UPDATE(long movtoId, decimal cantidadSurtida, FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Value = movtoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Decimal);
                auxPar.Value = cantidadSurtida;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"INVFIS_MOV_UPDATE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.m_sCadenaConexion, null);
                        MessageBox.Show("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }

        }




        private bool INVFIS_MOV_UPDATE_XLOC(long doctoId, decimal cajas, decimal piezas, long productoId, string lote, DateTime fechaVence, FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = productoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJAS", FbDbType.Decimal);
                auxPar.Value = cajas;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PIEZAS", FbDbType.Decimal);
                auxPar.Value = piezas;
                parts.Add(auxPar);




                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (lote != null && lote.Length > 0)
                {
                    auxPar.Value = lote;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (fechaVence != DateTime.MinValue)
                {
                    auxPar.Value = fechaVence;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"INVFIS_MOV_UPDATE_XLOC";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.m_sCadenaConexion, null);
                        MessageBox.Show("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }

        }


        private bool INVFIS_DIF_APLICAR(long lDoctoID, long lVendedorID, FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lDoctoID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = lVendedorID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"INVFIS_DIF_APLICAR";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.m_sCadenaConexion, null);
                        MessageBox.Show("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }

        }


        private bool Process()
        {
            
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            bool bRes = false;

            //long lMovtoId = 0;
            //decimal dCantidadSurtida = 0;

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                /*foreach (DataGridViewRow row in gET_INVFIS_LISTADETALLESDataGridView.Rows)
                {

                    if (row.Index == gET_INVFIS_LISTADETALLESDataGridView.NewRowIndex)
                    {
                        continue;
                    }

                    lMovtoId = long.Parse(row.Cells["MOVTOID"].Value.ToString());
                    dCantidadSurtida = Decimal.Parse(row.Cells["CANTIDADFISICA"].Value.ToString());


                    if (INVFIS_MOV_UPDATE(lMovtoId, dCantidadSurtida, fTrans) == false)
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        //MessageBox.Show(objRecD.IComentario);
                        return false;
                    }

                }*/

                if (INVFIS_DIF_APLICAR(m_Docto.IID, CurrentUserID.CurrentUser.IID, fTrans) == false)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    //MessageBox.Show(objRecD.IComentario);
                    return false;
                }

                fTrans.Commit();
                fConn.Close();
                bRes = true;

            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                MessageBox.Show("Ocurrio un error , llame a sistemas . \n Detalles del error :" + ex.Message + ex.StackTrace);

            }
            finally
            {
                fConn.Close();
            }

            m_Comentario = "La finalizacion del inventario se realizo correctamente";
            return bRes;
        }



        private void BTFinalizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que ya termino de hacer todos los ajustes? ", "Confirmar finalizacion del proceso ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                progressBar1.Visible = true;
                m_Comentario = "";
                

                progressBar1.Style = ProgressBarStyle.Marquee;
                this.bgFinalizarInventario.RunWorkerAsync();

            }

        }

        private void CBMostrarSoloDif_CheckedChanged(object sender, EventArgs e)
        {
            this.LlenarGrid(m_Docto.IID);
        }

        private void bgFinalizarInventario_DoWork(object sender, DoWorkEventArgs e)
        {

            if (CurrentUserID.CurrentParameters.IREQ_APROBACION_INV == DBValues._DB_BOOLVALUE_NO
                && (this.m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR))
            {
                m_ProcessSuccess = INVFIS_FIS_FINEDICION(m_Docto.IID, null);
                if (!m_ProcessSuccess)
                    return;
            }


            m_ProcessSuccess = Process();

            if (m_Docto.IACTIVO != "N")
                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;


        }

        private void bgFinalizarInventario_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            if (m_ProcessSuccess)
            {

                if (MessageBox.Show("Desea imprimir las diferencias en formato ticket? ", "Tipo impresion ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    WFConsultaInventarioFisico wf = new WFConsultaInventarioFisico();
                    wf.m_bNotShowScreen = true;
                    wf.ShowDialog();
                    wf.ImprimirTicket(m_Docto.IID, 1);
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                }

                if (LlenarListaDeInventarioFisico(m_Docto.IID))
                {



                    CSUCURSALD sucursalD = new CSUCURSALD();
                    CSUCURSALBE sucursalBE = new CSUCURSALBE();
                    sucursalBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;
                    sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

                    if (sucursalBE != null)
                    {
                        string strArchivoSoloNombre = CurrentUserID.CurrentParameters.ISUCURSALNUMERO + " " + DateTime.Today.ToString("dd_MM_yyyy") + " " + m_Docto.IID + " " + EnviosMail.str_FileExcelName;
                        string strArchivo = System.AppDomain.CurrentDomain.BaseDirectory + EnviosMail.FileLocalLocation_Excel + "\\" + strArchivoSoloNombre;


                        DataTable dtBuffer = null;
                        if ((m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_INVENTARIO_FISICO))
                            dtBuffer = this.dSInventarioFisico2.GET_INVFIS_COMPLETO;
                        else
                            dtBuffer = this.dSInventarioFisico2.GET_INVFIS_COMPLETO_XLOC;


                        iPos.Login_and_Maintenance.WFReportSending rp = new Login_and_Maintenance.WFReportSending(FastReportsConfig.getPathForFile("InformeInventarioActual.frx", FastReportsTipoFile.desistema));
                        rp.m_silentMode = true;//corregir Manuel llamas
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);


                        /*ThreadStart ts = delegate
                        {*/
                        try
                        {
                            if (EnviosMail.Excel_FromDataTable(dtBuffer, strArchivo, (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_INVENTARIO_FISICO) ? this.m_columnTitlesExcel : this.m_columnTitlesExcelXLoc, sucursalBE, true))
                            {

                                CEXP_FILESD expFileD = new CEXP_FILESD();
                                CEXP_FILESBE expFile = new CEXP_FILESBE();
                                expFile.ITIPO = DBValues._EXP_FILES_TIPO_INVENTARIO;
                                expFile.INOMBRE = strArchivoSoloNombre;
                                expFile.IARCHIVOFTP = strArchivoSoloNombre;
                                expFile.IFECHA = DateTime.Now;
                                expFile.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;


                                expFileD.AgregarEXP_FILESD(expFile, null);



                                if (!EnviosMail.EnviarInventario("", strArchivo))
                                {
                                    expFile = new CEXP_FILESBE();
                                    expFile.ITIPO = DBValues._EXP_FILES_TIPO_INV_MAIL;
                                    expFile.INOMBRE = strArchivoSoloNombre;
                                    expFile.IARCHIVOFTP = strArchivoSoloNombre;
                                    expFile.IFECHA = DateTime.Now;
                                    expFile.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;

                                    expFileD.AgregarEXP_FILESD(expFile, null);


                                }



                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        /*};
                        new Thread(ts).Start();*/
                    }
                }

            }


            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Visible = false;
            if (m_Comentario != "")
            {
                MessageBox.Show(this.m_Comentario);
            }
            if (m_ProcessSuccess)
            {
                
               imprimirReciboLargo(m_Docto.IID, (short)(1), 0, "Reporte inventario Final", true);
               
                this.Close();
            }
        }

        private void BTEdicionFinal_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Seguro que ya termino de hacer todos los ajustes? Despues de eso solo el administrador podra modificarlos ", "Confirmar finalizacion de la edicion proceso ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                this.LlenarGrid(m_Docto.IID);
                progressBar1.Visible = true;
                m_Comentario = "";


                if (MessageBox.Show("Desea imprimir las diferencias en formato ticket? ", "Tipo impresion ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    m_bImprimirSoloDiferenciasTicket = true;
                }
                else
                {
                    m_bImprimirSoloDiferenciasTicket = false;
                }

                progressBar1.Style = ProgressBarStyle.Marquee;
                this.bgEdicionFinal.RunWorkerAsync();



            }
        }


        private bool INVFIS_FIS_FINEDICION(long lDoctoID, FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lDoctoID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"INVFIS_FIS_FINEDICION";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.m_sCadenaConexion, null);
                        MessageBox.Show("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }

        }



        private void SetHabilitaciones()
        {

            if (m_Docto.IACTIVO == "N")
                this.BTFinalizar.Visible = false;

            if (CurrentUserID.CurrentParameters.IREQ_APROBACION_INV == DBValues._DB_BOOLVALUE_SI)
            {
                if (this.m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_INVENTARIOFIN)
                {
                    CUSUARIOSD usuariosD = new CUSUARIOSD();
                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_FINALIZAR_INVENTARIO, null))
                    {
                        this.BTFinalizar.Enabled = false;
                        this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].ReadOnly = false;
                    }
                    else
                    {
                        this.BTFinalizar.Enabled = true;
                        this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].ReadOnly = true;
                    }


                    this.BTEdicionFinal.Enabled = false;
                }
                else if (this.m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_COMPLETO)
                {

                    this.BTFinalizar.Enabled = false;
                    this.BTEdicionFinal.Enabled = false;
                }
                else if (this.m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                {
                    this.BTFinalizar.Enabled = false;
                    this.BTEdicionFinal.Enabled = true;
                }
                else
                {
                    this.BTFinalizar.Enabled = false;
                    this.BTEdicionFinal.Enabled = false;
                }
            }
            else
            {
                this.BTEdicionFinal.Visible = false;
                if (this.m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR ||
                   this.m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_INVENTARIOFIN)
                {

                    this.BTFinalizar.Enabled = true;
                }

            }
        }





        private bool LlenarListaDeInventarioFisico(long lDoctoID)
        {
            try
            {
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_INVENTARIO_FISICO)
                {
                    this.gET_INVFIS_COMPLETOTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_COMPLETO, lDoctoID);
                }
                else
                {
                    this.gET_INVFIS_COMPLETO_XLOCTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_COMPLETO_XLOC, lDoctoID);
                }
                return true;
            }
            catch
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

        }



        private void bgEdicionFinal_DoWork(object sender, DoWorkEventArgs e)
        {
            m_ProcessSuccess = INVFIS_FIS_FINEDICION(m_Docto.IID, null);
            HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;


            if (m_ProcessSuccess)
            {

                ObtenerDoctoDeBD(m_Docto.IID);

                if (m_bImprimirSoloDiferenciasTicket)
                {
                    ImprimirTicketFinEdicion(m_Docto.IID, 1 );
                }

                if (LlenarListaDeInventarioEdicionFinal(m_Docto.IID))
                {



                    CSUCURSALD sucursalD = new CSUCURSALD();
                    CSUCURSALBE sucursalBE = new CSUCURSALBE();
                    sucursalBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;
                    sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

                    if (sucursalBE != null)
                    {
                        string strArchivoSoloNombre = CurrentUserID.CurrentParameters.ISUCURSALNUMERO + " " + DateTime.Today.ToString("dd_MM_yyyy") + " " + m_Docto.IID + " " + EnviosMail.str_FileExcelName;
                        string strArchivo = System.AppDomain.CurrentDomain.BaseDirectory + EnviosMail.FileLocalLocation_Excel + "\\" + strArchivoSoloNombre;


                        DataTable dtBuffer = null;
                        if ((m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_INVENTARIO_FISICO))
                            dtBuffer = this.dSInventarioFisico2.GET_INVFIS_FINEDICION;
                        else
                            dtBuffer = this.dSInventarioFisico2.GET_INVFIS_FINEDICION_XLOC;


                        ThreadStart ts = delegate
                        {
                            try
                            {

                                if (EnviosMail.Excel_FromDataTable(dtBuffer, strArchivo, (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_INVENTARIO_FISICO) ? this.m_columnTitlesExcel : this.m_columnTitlesExcelXLoc, sucursalBE, true))
                                {

                                    CEXP_FILESD expFileD = new CEXP_FILESD();
                                    CEXP_FILESBE expFile = new CEXP_FILESBE();
                                    expFile.ITIPO = DBValues._EXP_FILES_TIPO_INVENTARIO;
                                    expFile.INOMBRE = strArchivoSoloNombre;
                                    expFile.IARCHIVOFTP = strArchivoSoloNombre;
                                    expFile.IFECHA = DateTime.Now;
                                    expFile.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;


                                    expFileD.AgregarEXP_FILESD(expFile, null);



                                    if (!EnviosMail.EnviarInventario("", strArchivo))
                                    {
                                        expFile = new CEXP_FILESBE();
                                        expFile.ITIPO = DBValues._EXP_FILES_TIPO_INV_MAIL;
                                        expFile.INOMBRE = strArchivoSoloNombre;
                                        expFile.IARCHIVOFTP = strArchivoSoloNombre;
                                        expFile.IFECHA = DateTime.Now;
                                        expFile.IESTATUS = DBValues._EXP_FILES_ESTATUS_GENERADO;

                                        expFileD.AgregarEXP_FILESD(expFile, null);


                                    }
                                }
                            }
                            catch
                            {

                            }
                        };
                        new Thread(ts).Start();
                    }
                }

                MessageBox.Show("Edicion finalizada");

            }


        }



        private void bgEdicionFinal_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Visible = false;
            if (m_Comentario != "")
            {
                MessageBox.Show(this.m_Comentario);
            }

            if (m_ProcessSuccess)
            {
                imprimirReciboLargo(m_Docto.IID, (short)( 1), 0, "Reporte Inventario Edicion Final", false);
                
                SetHabilitaciones();
            }
        }

        private bool LlenarListaDeInventarioEdicionFinal(long lDoctoId)
        {
            try
            {

                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_INVENTARIO_FISICO)
                {
                    this.gET_INVFIS_FINEDICIONTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_FINEDICION, lDoctoId, 0, 0);
                    return true;
                }
                else
                {

                    this.gET_INVFIS_FINEDICION_XLOCTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_FINEDICION_XLOC, lDoctoId, 0, 0);
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }






        public void ImprimirTicketFinEdicion(long doctoId, long lOpcion1)
        {


            CTICKET_DETAILD detailD = new CTICKET_DETAILD();
            CTICKET_FOOTERD footerD = new CTICKET_FOOTERD();
            CTICKET_HEADERD headerD = new CTICKET_HEADERD();


            CTICKET_FOOTERBE footerBE = new CTICKET_FOOTERBE();
            CTICKET_HEADERBE headerBE = new CTICKET_HEADERBE();
            //CTICKET_DETAILBE[] ListaDetalles = detailD.seleccionarTICKET_DETAIL(doctoId, null);
            LlenarListaDeInventarioEdicionFinal(doctoId);

            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            string line;

            footerBE.IDOCTOID = doctoId;
            headerBE.IDOCTOID = doctoId;

            headerBE = headerD.seleccionarTICKET_HEADER(headerBE, null);
            footerBE = footerD.seleccionarTICKET_FOOTER(footerBE, false, null);


            Ticket ticket = new Ticket();

            ticket.AddHeaderLine("INVENTARIO FISICO");
            ticket.AddHeaderLine("      " + headerBE.INOMBRE);
            ticket.AddHeaderLine(headerBE.IDOMICICIO);
            ticket.AddHeaderLine(headerBE.ICIUDAD.Trim() + " , " + headerBE.IESTADO.Trim());
            ticket.AddHeaderLine("RFC: " + headerBE.IRFC);
            ticket.AddHeaderLine(new string('-', Ticket.maxChar));


            ticket.AddHeaderLine("Usuario: " + iPos.CurrentUserID.CurrentUser.INOMBRE);

            if (headerBE.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA)
                ticket.AddHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            else
                ticket.AddHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " Ticket " + headerBE.ITICKET);



            decimal dCantidadTeorica = 0, dDiferencia = 0, dCantidadFisica = 0, dCostoPrecio = 0, dDiferenciaCostoInv = 0;
            decimal dCantidadTeoricaTotal = 0, dCantidadFisicaTotal = 0, dDiferenciaCostoInvTotal = 0;
            int iCantProdTotal = 0, iCantProdConDif = 0, iCantSinExistencia = 0;



            if ((m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_INVENTARIO_FISICO))
            {


                ticket.AddHeaderLine(new string('=', Ticket.maxChar));

                ticket.AddHeaderLine("DESCRIPCION               ");
                ticket.AddHeaderLine("CANT. TEORICA  CANT. FISICA  DIFERENCIA");
                ticket.AddHeaderLine("               COSTO         IMPORTE");

                ticket.AddHeaderLine(new string('-', Ticket.maxChar));


                foreach (DataRow detailItem in this.dSInventarioFisico2.GET_INVFIS_FINEDICION)
                {
                    iCantProdTotal++;


                    dCantidadTeorica = (decimal)detailItem["CANTIDADTEORICA"];
                    dCantidadFisica = (decimal)detailItem["CANTIDADFISICA"]; ;
                    dDiferenciaCostoInv = (decimal)detailItem["DIFERNECIACOSTOINVENTARIO"];
                    dCostoPrecio = (decimal)detailItem["COSTOPRECIOMANEJADO"];
                    dDiferenciaCostoInvTotal += dDiferenciaCostoInv;
                    dCantidadTeoricaTotal += dCantidadTeorica;
                    dCantidadFisicaTotal += dCantidadFisica;

                    if (dCantidadTeorica != dCantidadFisica)
                        iCantProdConDif++;

                    if (dCantidadFisica == 0)
                        iCantSinExistencia++;


                    if (lOpcion1 == 1 && dCantidadTeorica == dCantidadFisica)
                        continue;


                    dDiferencia = dCantidadTeorica - dCantidadFisica;

                    int maxleng = (detailItem["PRODUCTODESCRIPCION"].ToString().Length > 39) ? 39 : detailItem["PRODUCTODESCRIPCION"].ToString().Length;
                    ticket.AddHeaderLine(detailItem["PRODUCTODESCRIPCION"].ToString().Substring(0, maxleng));

                    line = "";
                    line += Ticket.FormatPrintField(dCantidadTeorica.ToString("N2"), 13, 0) + "  ";
                    line += Ticket.FormatPrintField(dCantidadFisica.ToString("N2"), 12, 0) + "  ";
                    line += Ticket.FormatPrintField(dDiferencia.ToString("N2"), 10, 0);
                    ticket.AddHeaderLine(line);
                    line = "";
                    line += Ticket.FormatPrintField(" ", 13, 0) + "  ";
                    line += Ticket.FormatPrintField(dCostoPrecio.ToString("N2"), 12, 0) + "  ";
                    line += Ticket.FormatPrintField(dDiferenciaCostoInv.ToString("N2"), 10, 0);
                    ticket.AddHeaderLine(line);
                }


                ticket.AddHeaderLine(new string('-', Ticket.maxChar));
                ticket.AddTotal("Cant. Prod.     : ", iCantProdTotal.ToString("N0"));
                ticket.AddTotal("Prod. con Dif.  : ", iCantProdConDif.ToString("N0"));
                ticket.AddTotal("Prod. sin Exist.: ", iCantSinExistencia.ToString("N0"));
                ticket.AddTotal("Importe Dif.    : ", dDiferenciaCostoInvTotal.ToString("N0"));
                ticket.AddTotal("Cant Teorica Tot: ", dCantidadTeoricaTotal.ToString("N0"));
                ticket.AddTotal("Cant Fisica Tot : ", dCantidadFisicaTotal.ToString("N0"));
                ticket.AddTotal("Cant Dif Tot    : ", (dCantidadFisicaTotal - dCantidadTeoricaTotal).ToString("N0"));
            }

            else
            {
                string anaquel = "", localidad = "";
                ticket.AddHeaderLine(new string('=', Ticket.maxChar));

                ticket.AddHeaderLine("DESCRIPCION               ");
                ticket.AddHeaderLine("ANAQUEL      LOCALIDAD    CANT.FISICA");

                ticket.AddHeaderLine(new string('-', Ticket.maxChar));

                foreach (DataRow detailItem in this.dSInventarioFisico2.GET_INVFIS_FINEDICION_XLOC)
                {
                    anaquel = ""; localidad = "";
                    //iCantProdTotal++;


                    //dCantidadTeorica = (decimal)detailItem["CANTIDADTEORICA"];
                    dCantidadFisica = (decimal)detailItem["CANTIDADFISICA"]; ;

                    if (dCantidadTeorica != dCantidadFisica)
                        iCantProdConDif++;

                    if (dCantidadFisica == 0)
                        iCantSinExistencia++;


                    /*if (lOpcion1 == 1 && dCantidadTeorica == dCantidadFisica)
                        continue;*/


                    //dDiferencia = dCantidadTeorica - dCantidadFisica;

                    int maxleng = (detailItem["PRODUCTODESCRIPCION"].ToString().Length > 39) ? 39 : detailItem["PRODUCTODESCRIPCION"].ToString().Length;
                    ticket.AddHeaderLine(detailItem["PRODUCTODESCRIPCION"].ToString().Substring(0, maxleng));

                    maxleng = (detailItem["ANAQUEL"].ToString().Length > 13) ? 13 : detailItem["ANAQUEL"].ToString().Length;
                    anaquel = detailItem["ANAQUEL"].ToString().Substring(0, maxleng).PadRight(13);


                    maxleng = (detailItem["LOCALIDAD"].ToString().Length > 13) ? 13 : detailItem["LOCALIDAD"].ToString().Length;
                    localidad = detailItem["LOCALIDAD"].ToString().Substring(0, maxleng).PadRight(13);

                    line = "";
                    line += anaquel + localidad;
                    line += Ticket.FormatPrintField(dCantidadFisica.ToString("N2"), 14, 0);
                    ticket.AddHeaderLine(line);
                }


                ticket.AddHeaderLine(new string('-', Ticket.maxChar));
            }

            ticket.AddFooterLine(new string('-', Ticket.maxChar));

            ticket.AddFooterLine(footerBE.ICAJA);
            ticket.AddFooterLine(new string('-', Ticket.maxChar));

            ticket.PrintTicketDirect(Ticket.GetReceiptPrinter());


        }
        private void ActualizaTablasDeControl()
        {
            WFActualizandoKITMultiNivel wf = new WFActualizandoKITMultiNivel();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void WFListaDiferencias_Load(object sender, EventArgs e)
        {
            ActualizaTablasDeControl();

            //gET_INVFIS_LISTADETALLES_PXLOCTableAdapter
            formatGridColumnProductoCaracteristicas();

            this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].Visible = true;

            if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_INVENTARIO_FISICOXLOC)
            {

                
                if (m_Docto.IKITDESGLOSADO != null && m_Docto.IKITDESGLOSADO.Equals("S"))
                    this.gET_INVFIS_LISTADETALLESDataGridView.DataSource = this.gET_INVFIS_LISTADETALLES_PXLOC_KITBindingSource;
                else
                    this.gET_INVFIS_LISTADETALLESDataGridView.DataSource = this.gET_INVFIS_LISTADETALLES_PXLOCBindingSource;


                //this.gET_INVFIS_LISTADETALLESDataGridView.ReadOnly = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].ReadOnly = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].DefaultCellStyle.BackColor = Color.White;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].ReadOnly = false;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].DefaultCellStyle.BackColor = Color.PaleGreen;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].Visible = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].ReadOnly = false;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].Visible = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].DefaultCellStyle.BackColor = Color.PaleGreen;
            }
            else
            {

                if (m_Docto.IKITDESGLOSADO != null && m_Docto.IKITDESGLOSADO.Equals("S"))
                    this.gET_INVFIS_LISTADETALLESDataGridView.DataSource = this.gET_INVFIS_LISTADETALLES_PKITBindingSource;
                
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].DefaultCellStyle.BackColor = Color.PaleGreen;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].ReadOnly = false;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["CANTIDADFISICA"].Visible = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].DefaultCellStyle.BackColor = Color.White;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].ReadOnly = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGCAJAS"].Visible = false;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].DefaultCellStyle.BackColor = Color.White;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].ReadOnly = true;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["DGPIEZAS"].Visible = false;
            }

            if(bEstaConfiguradoParaPiezasyCajas())
            {
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["PRODUCTOLOTE"].Visible = false;
                this.gET_INVFIS_LISTADETALLESDataGridView.Columns["FECHAVENCE"].Visible = false;
            }


            this.m_bEsInventarioCiclico = m_Docto.IACTIVO == "N";
            //this.gET_INVFIS_LISTADETALLESTableAdapter.Adapter.SelectCommand.CommandText = gET_INVFIS_LISTADETALLES_PXLOCTableAdapter.Adapter.SelectCommand.CommandText;
        }




        private bool bEstaConfiguradoParaPiezasyCajas()
        {
            return (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S"));
        }



        public void formatGridColumnProductoCaracteristicas()
        {
            if (CurrentUserID.CurrentParameters.IMOSTRARINVINFOADICPROD != null && CurrentUserID.CurrentParameters.IMOSTRARINVINFOADICPROD.Equals("S"))
            {
                try
                {
                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] && CurrentUserID.CurrentParameters.ITEXTO1 != "")
                    {

                        this.DGTEXTO1.Visible = true;
                        this.DGTEXTO1.HeaderText = CurrentUserID.CurrentParameters.ITEXTO1;
                    }
                    else
                    {

                        this.DGTEXTO1.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO2"] && CurrentUserID.CurrentParameters.ITEXTO2 != "")
                    {

                        this.DGTEXTO2.Visible = true;
                        this.DGTEXTO2.HeaderText = CurrentUserID.CurrentParameters.ITEXTO2;
                    }
                    else
                    {

                        this.DGTEXTO2.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO3"] && CurrentUserID.CurrentParameters.ITEXTO3 != "")
                    {

                        this.DGTEXTO3.Visible = true;
                        this.DGTEXTO3.HeaderText = CurrentUserID.CurrentParameters.ITEXTO3;
                    }
                    else
                    {

                        this.DGTEXTO3.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO4"] && CurrentUserID.CurrentParameters.ITEXTO4 != "")
                    {

                        this.DGTEXTO4.Visible = true;
                        this.DGTEXTO4.HeaderText = CurrentUserID.CurrentParameters.ITEXTO4;
                    }
                    else
                    {

                        this.DGTEXTO4.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO5"] && CurrentUserID.CurrentParameters.ITEXTO5 != "")
                    {

                        this.DGTEXTO5.Visible = true;
                        this.DGTEXTO5.HeaderText = CurrentUserID.CurrentParameters.ITEXTO5;
                    }
                    else
                    {

                        this.DGTEXTO5.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO6"] && CurrentUserID.CurrentParameters.ITEXTO6 != "")
                    {

                        this.DGTEXTO6.Visible = true;
                        this.DGTEXTO6.HeaderText = CurrentUserID.CurrentParameters.ITEXTO6;
                    }
                    else
                    {

                        this.DGTEXTO6.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO1"] && CurrentUserID.CurrentParameters.INUMERO1 != "")
                    {

                        this.DGNUMERO1.Visible = true;
                        this.DGNUMERO1.HeaderText = CurrentUserID.CurrentParameters.INUMERO1;
                    }
                    else
                    {

                        this.DGNUMERO1.Visible = false;
                    }




                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO2"] && CurrentUserID.CurrentParameters.INUMERO2 != "")
                    {

                        this.DGNUMERO2.Visible = true;
                        this.DGNUMERO2.HeaderText = CurrentUserID.CurrentParameters.INUMERO2;
                    }
                    else
                    {

                        this.DGNUMERO2.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO3"] && CurrentUserID.CurrentParameters.INUMERO3 != "")
                    {

                        this.DGNUMERO3.Visible = true;
                        this.DGNUMERO3.HeaderText = CurrentUserID.CurrentParameters.INUMERO3;
                    }
                    else
                    {

                        this.DGNUMERO3.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO4"] && CurrentUserID.CurrentParameters.INUMERO4 != "")
                    {

                        this.DGNUMERO4.Visible = true;
                        this.DGNUMERO4.HeaderText = CurrentUserID.CurrentParameters.INUMERO4;
                    }
                    else
                    {

                        this.DGNUMERO4.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA1"] && CurrentUserID.CurrentParameters.IFECHA1 != "")
                    {

                        this.DGFECHA1.Visible = true;
                        this.DGFECHA1.HeaderText = CurrentUserID.CurrentParameters.IFECHA1;
                    }
                    else
                    {

                        this.DGFECHA1.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA2"] && CurrentUserID.CurrentParameters.IFECHA2 != "")
                    {

                        this.DGFECHA2.Visible = true;
                        this.DGFECHA2.HeaderText = CurrentUserID.CurrentParameters.IFECHA2;
                    }
                    else
                    {

                        this.DGFECHA2.Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
                PRODUCTOLOTE.Visible = false;
                FECHAVENCE.Visible = false;
            }
            else
            {

                DGTEXTO1.Visible = false;
                DGTEXTO2.Visible = false;
                DGTEXTO3.Visible = false;
                DGTEXTO4.Visible = false;
                DGTEXTO5.Visible = false;
                DGTEXTO6.Visible = false;
                DGNUMERO1.Visible = false;
                DGNUMERO2.Visible = false;
                DGNUMERO3.Visible = false;
                DGNUMERO4.Visible = false;
                DGFECHA1.Visible = false;
                DGFECHA2.Visible = false;
                PRODUCTOLOTE.Visible = true;
                FECHAVENCE.Visible = true;
            }
        }


        private void SeleccionarProducto(string strDescripcion)
        {

            LOOKPROD look;
            if (strDescripcion == "")
                look = new LOOKPROD("", false, TipoProductoNivel.tp_hijos);
            else
                look = new LOOKPROD(strDescripcion, false, TipoProductoNivel.tp_hijos);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                ITEMIDTextBox.Text = dr["CLAVE"].ToString().Trim();
                ITEMIDTextBox.Focus();
                ITEMIDTextBox.Select(ITEMIDTextBox.Text.Length, 0);
            }
        }


        private void ITEMButton_Click(object sender, EventArgs e)
        {

            SeleccionarProducto("");
        }

        private void ITEMIDTextBox_Validated(object sender, EventArgs e)
        {
            m_posicionActual = -1;
        }

        private void buscarProductoEnGrid()
        {
            gET_INVFIS_LISTADETALLESDataGridView.ClearSelection();

            int primeraPosicionEncontradaDesdeInicio = -1;
            

            foreach (DataGridViewRow dr in gET_INVFIS_LISTADETALLESDataGridView.Rows)
            {

                long productoId = long.Parse(dr.Cells["PRODUCTOID"].Value.ToString());

                if (productoId == m_productoIdABuscar)
                {


                    if (dr.Index <= m_posicionActual)
                    {
                        if (primeraPosicionEncontradaDesdeInicio == -1)
                        {
                            primeraPosicionEncontradaDesdeInicio = dr.Index;
                        }
                        continue;
                    }

                    gET_INVFIS_LISTADETALLESDataGridView.FirstDisplayedScrollingRowIndex = dr.Index;
                    dr.Selected = true;
                    m_posicionActual = dr.Index;
                    return;

                }

            }


            CPRODUCTOD prodD = new CPRODUCTOD();
            CPRODUCTOBE prodBE = new CPRODUCTOBE();
            prodBE.IID = m_productoIdABuscar;

            prodBE = prodD.seleccionarPRODUCTO(prodBE, null);


            if (primeraPosicionEncontradaDesdeInicio > -1)
            {

                gET_INVFIS_LISTADETALLESDataGridView.FirstDisplayedScrollingRowIndex = primeraPosicionEncontradaDesdeInicio;
                gET_INVFIS_LISTADETALLESDataGridView.Rows[primeraPosicionEncontradaDesdeInicio].Selected = true;
                m_posicionActual = primeraPosicionEncontradaDesdeInicio;
            }
            else if(prodBE != null && (prodBE.IMANEJALOTE == null || !prodBE.IMANEJALOTE.Equals("S")))
            {

                if (MessageBox.Show("No hay registros de ese producto en el inventario, desea agregarlo al inventario? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    decimal piezas = 0;
                    decimal cajas = 0;
                    long almacenId = 0;
                    bool manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));

                    WFDialogInvCajaPza dlg = new WFDialogInvCajaPza(0, prodBE.IPZACAJA, manejaAlmacen);
                    dlg.ShowDialog();
                    bool bHuboCambio = dlg.huboCambio;
                    piezas = dlg.dBotellas;
                    cajas = dlg.dCajas;
                    almacenId = dlg.lAlmacenId;
                    dlg.Dispose();
                    GC.SuppressFinalize(dlg);

                    Process(almacenId, m_productoIdABuscar,
                                -2, "LIBRE",
                                manejaAlmacen, cajas, piezas);
                }
            }


                /*


                 */
            }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarProductoEnGrid();
        }

        private void ITEMIDTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                ValidateBusqueda();
            }
        }


        private void ValidateBusqueda()
        {

            m_productoIdABuscar = 0;

            if (ITEMIDTextBox.Text.Trim() == "")
                return;

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                ITEMLabel.Text = "";
                SeleccionarProducto(ITEMIDTextBox.Text.Trim());
                return;
            }
            ITEMLabel.Text = prod.IDESCRIPCION1;

            m_productoIdABuscar = prod.IID;
            m_posicionActual = -1;
            buscarProductoEnGrid();
        }

        private void ITEMIDTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateBusqueda();
        }


        private bool BuscarProducto(ref CPRODUCTOBE prod)
        {
            CComprasD pvd = new CComprasD();
            prod = pvd.buscarPRODUCTOSPV(ITEMIDTextBox.Text.Trim(), CurrentUserID.CurrentParameters, null);
            if (prod != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void gET_INVFIS_LISTADETALLESDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {


                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_INVENTARIO_FISICOXLOC)
                {
                    long productoId = long.Parse(gET_INVFIS_LISTADETALLESDataGridView.Rows[e.RowIndex].Cells["PRODUCTOID"].Value.ToString());

                    WFInvLocationSingleProd wf = new WFInvLocationSingleProd(productoId,this.m_Docto.IID);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                }
            }
        }



        public void imprimirReciboLargo(long doctoId, short soloDiferencias, short todosLosProductos, string titulo, bool completo)
        {
            string strReporte = "InformeInventarioIngresado.frx";

            if (completo)
                strReporte = "InformeInventarioCompleto.frx";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("DOCTOID", doctoId);
            dictionary.Add("SOLODIFERENCIAS", soloDiferencias);
            dictionary.Add("TODOSLOSPRODUCTOS", todosLosProductos);
            dictionary.Add("TITULO", titulo);
            


            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void btnImprimirDif_Click(object sender, EventArgs e)
        {
            imprimirReciboLargo(m_Docto.IID, 1, 0, "Reporte Inventario Diferencias", false);
        }



        private bool Process(long lAlmacenId, long lProductoId, 
                                long lAnaquelId, string strLocalidad, 
                                bool manejaAlmacen, decimal cajas, decimal piezas)
        {

            

            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            string P_VD_VENDEDOR = CurrentUserID.CurrentUser.INOMBRE;
            string P_LOTE = "";
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            int? US_SUPERVISORID = null;
            int? ALMACENID = (int)lAlmacenId ;// m_manejaAlmacen ? int.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            long? SUCURSALTID = 0;
            long? ALMACENTID = 0;
            decimal? P_CANTIDAD_SURTIDA = null;
            bool bEsPrimeraEntrada = m_Docto == null || m_Docto.IID == 0;

            long? P_TIPODIFERENCIAINVENTARIOID = 0;

            string P_LOCALIDAD = "";
            long? P_ANAQUEL = 0;


            decimal? P_CANTIDAD_CAJAS = null;
            decimal? P_CANTIDAD_PIEZAS = null;
            decimal? P_PZACAJA = null;

            

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {

                MessageBox.Show("El producto no existe");
                return false;
            }


            if (this.dSInventarioFisico.GET_INVENTARIOFISICO_INFO.Rows.Count < 0)
            {
                MessageBox.Show("No se ha seleccionado un producto valido");
                return false;
            }

            P_IDPRODUCTO = lProductoId;


            if(this.m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_INVENTARIO_FISICOXLOC)
            {

                P_ANAQUEL = lAnaquelId;
                P_LOCALIDAD = strLocalidad.Trim();

                if (P_ANAQUEL != -2)
                {
                    CPRODUCTOLOCATIONSD prodLocD = new CPRODUCTOLOCATIONSD();
                    CPRODUCTOLOCATIONSBE prodLocBE = new CPRODUCTOLOCATIONSBE();
                    prodLocBE.IPRODUCTOID = P_IDPRODUCTO.Value;
                    prodLocBE.IANAQUELID = P_ANAQUEL.Value;
                    prodLocBE.ILOCALIDAD = P_LOCALIDAD;

                    if (manejaAlmacen)
                    {
                        prodLocBE.IALMACENID = ALMACENID.Value;
                    }
                    prodLocBE = prodLocD.seleccionarPRODUCTOLOCATIONSXINFO(prodLocBE, null);
                    if (prodLocBE == null)
                    {
                        MessageBox.Show("no se tiene registrado ese producto en esa localidad y anaquel");
                        return false;
                    }
                }
            }
            else
            {

                P_ANAQUEL = null;
                P_LOCALIDAD = null;
            }






            try
            {
                //decimal cajas = 0, piezas = 0;
                //decimal.TryParse(TBCajas.Text.Trim(), out cajas);
                //decimal.TryParse(TBPiezas.Text.Trim(), out piezas);

                P_CANTIDAD_CAJAS = cajas;
                P_CANTIDAD_PIEZAS = piezas;

                P_PZACAJA = 1;
                if (!(bool)prod.isnull["IPZACAJA"])
                {
                    if (prod.IPZACAJA > 0)
                        P_PZACAJA = prod.IPZACAJA;
                }

                P_CANTIDAD_SURTIDA = (P_CANTIDAD_CAJAS.Value * P_PZACAJA.Value) + P_CANTIDAD_PIEZAS/*decimal.Parse(TBCantidad.Text.Trim())*/;
            }
            catch
            {
                MessageBox.Show("La cantidad no tiene el formato adecuado");
                return false;
            }

            



            if (!(bool)this.m_Docto.isnull["IID"])
            {
                P_IDDOCTO = m_Docto.IID;
            }




            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_VD_VENDEDOR, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_Docto.ITIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_CANTIDAD_SURTIDA, P_ANAQUEL, P_LOCALIDAD, P_CANTIDAD_CAJAS, P_CANTIDAD_PIEZAS, P_PZACAJA, null, fTrans))
                {
                    fTrans.Commit();


                    LlenarGrid((long)P_IDDOCTO);

                    ObtenerDoctoDeBD((long)P_IDDOCTO);
                    
                    


                }
                else
                {
                    fTrans.Rollback();
                    MessageBox.Show(this.IComentario);
                    //this.TBCodigo.Focus();
                }
                fConn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }

        

        public bool EjecutarAddMOVTO(ref long? P_IDDOCTO,
                                        decimal? P_CANTIDAD,
                                        long? P_IDPRODUCTO,
                                        string P_VD_VENDEDOR,
                                        long? P_USERID,
                                        string P_LOTE,
                                        int? US_SUPERVISOR,
                                        int? ALMACENID,
                                        long? SUCURSALID,
                                        DateTime P_FECHAVENCE,
                                        long P_TIPO_DOCTO,
                                        long? P_SUCURSALTID,
                                        long? P_ALMACENTID,
                                        string P_PROMOCION,
                                        long? P_TIPODIFERENCIAINVENTARIOID,
                                        decimal? P_CANTIDAD_SURTIDA,
                                        long? P_ANAQUEL,
                                        string P_LOCALIDAD,
                                        decimal? P_CANTIDAD_CAJAS,
                                        decimal? P_CANTIDAD_PIEZAS,
                                        decimal? P_PZACAJA,
                                        long? P_LOTEIMPORTADO,
                                        FbTransaction st)
        {
            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                if (P_IDDOCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDDOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (ALMACENID.HasValue)
                {
                    auxPar.Value = (long)ALMACENID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (SUCURSALID.HasValue)
                {
                    auxPar.Value = (long)SUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = P_TIPO_DOCTO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOPAGOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_PAGO_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PARTIDA", FbDbType.SmallInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (P_IDPRODUCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (P_LOTE != null && P_LOTE != "")
                {
                    auxPar.Value = P_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (P_FECHAVENCE > DateTime.MinValue)
                    auxPar.Value = P_FECHAVENCE;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (P_CANTIDAD.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                if (P_CANTIDAD_SURTIDA.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD_SURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADFALTANTE", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEVUELTA", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSALDO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSMOVTOID", FbDbType.BigInt);
                auxPar.Value = (long)DBValues._MOVTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);



                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);





                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (P_SUCURSALTID.HasValue)
                {
                    auxPar.Value = (long)P_SUCURSALTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ALMACENTID", FbDbType.BigInt);
                if (P_ALMACENTID.HasValue)
                {
                    auxPar.Value = (long)P_ALMACENTID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PROMOCION", FbDbType.Char);
                auxPar.Value = P_PROMOCION;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODIFERENCIAINVENTARIOID", FbDbType.BigInt);
                if (P_TIPODIFERENCIAINVENTARIOID.HasValue)
                {
                    auxPar.Value = (long)P_TIPODIFERENCIAINVENTARIOID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCENTAJEDESCUENTO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOREFID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ANAQUELID", FbDbType.BigInt);
                if (P_ANAQUEL != null)
                {
                    auxPar.Value = P_ANAQUEL;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                if (P_LOCALIDAD != null)
                {
                    auxPar.Value = P_LOCALIDAD;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOREFID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOYAVALIDADO", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTEIMPORTADO", FbDbType.BigInt);
                if (P_LOTEIMPORTADO.HasValue)
                {
                    auxPar.Value = (long)P_LOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARGOTARJPRECIOMANUAL", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new FbParameter("@AGRUPAPORPARAMETRO", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);





                string commandText = @"MOVTO_INSERT";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }




                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {


                    CMOVTOD movtoD = new CMOVTOD();
                    CMOVTOBE movtoBE = new CMOVTOBE();
                    movtoBE.IID = (long)arParms[arParms.Length - 2].Value;
                    movtoBE = movtoD.seleccionarMOVTO(movtoBE, st);

                    if (movtoBE == null)
                    {
                        this.iComentario = "ERROR al asignar la cantidad de cajas y piezas ";
                        return false;
                    }

                    if ((bool)movtoBE.isnull["ICAJAS"])
                        movtoBE.ICAJAS = 0;

                    if ((bool)movtoBE.isnull["IPIEZAS"])
                        movtoBE.IPIEZAS = 0;

                    if (P_CANTIDAD_CAJAS.HasValue)
                    {
                        movtoBE.ICAJAS += P_CANTIDAD_CAJAS.Value;
                    }

                    if (P_CANTIDAD_PIEZAS.HasValue)
                    {
                        movtoBE.IPIEZAS += P_CANTIDAD_PIEZAS.Value;
                    }


                    if (P_PZACAJA.HasValue)
                    {
                        movtoBE.IPZACAJA = P_PZACAJA.Value;
                    }
                    else
                    {
                        movtoBE.IPZACAJA = 1;
                    }

                    if (!movtoD.CambiarCAJASPIEZASMOVTOD(movtoBE, st))
                    {
                        this.iComentario = "ERROR al asignar la cantidad de cajas y piezas ";
                        return false;
                    }

                }


                P_IDDOCTO = (long)arParms[arParms.Length - 3].Value;
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        private void btnReconteo_Click(object sender, EventArgs e)
        {

        }
    }
}
