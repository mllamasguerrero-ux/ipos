using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;
using FlatTabControl;
using iPosReporting;
using System.Diagnostics;
using DataLayer.Importaciones;
using System.IO;
using Newtonsoft.Json;

namespace iPos
{
    public partial class WFReciboGastoEdit : IposForm
    {

        int m_estadoVenta;
        CDOCTOBE m_Docto;

        long predoctoId = 0;
        long m_corteId = 0;

        bool m_bSeleccionarCajero = false;

        string m_modo = "Agregar";

        long m_autorizoId = 0;
        bool m_bPermisoReimprimirTicketContabilidad = false;


        bool m_manejaAlmacen = false;
        bool m_usuarioPuedeCambiarAlmacen = false;


        public WFReciboGastoEdit()
        {
            InitializeComponent();
            m_autorizoId = CurrentUserID.CurrentUser.IID;
            m_Docto = new CDOCTOBE();

        }


        public WFReciboGastoEdit(bool bSeleccionarCajero, long autorizoId)
            : this()
        {
            m_autorizoId = autorizoId;
            m_bSeleccionarCajero = bSeleccionarCajero;

        }

        public WFReciboGastoEdit(long doctoId, string modo)
            : this()
        {
            predoctoId = doctoId;
            m_modo = modo;


        }



        private void WFReciboGastoEdit_Load(object sender, EventArgs e)
        {


            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_REIMPRIMIRTICKET_CONT, null))
            {
                m_bPermisoReimprimirTicketContabilidad = true;
            }
            else
            {
                m_bPermisoReimprimirTicketContabilidad = false;
            }


            this.CBCajero.llenarDatos();
            this.CBCajero.SelectedDataValue = CurrentUserID.CurrentUser.IID.ToString();

            this.CBCajero.Enabled = m_bSeleccionarCajero;
            if(m_bSeleccionarCajero)
            {
                pnlCorteSeleccion.Visible = false;
                CBCorteActual.Checked = false;
            }

            
            m_manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));
            if (!this.m_manejaAlmacen)
            {
                pnlAlmacen.Visible = false;
            }
            else
            {
                m_usuarioPuedeCambiarAlmacen = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARDEALMACEN_GASTOS, null);
                pnlAlmacen.Visible = true;
                pnlAlmacen.Enabled = m_usuarioPuedeCambiarAlmacen;
                this.ALMACENComboBox.llenarDatos();
            }


            if (predoctoId != 0)
            {
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IID = predoctoId;
                doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                if(doctoBE == null)
                {
                    MessageBox.Show("No se pudo cargar la informacion del gasto");
                    return;
                }
                
                m_Docto = doctoBE;
                LlenarGrid();
                this.DTPFecha.Value = m_Docto.IFECHA;
                this.LBFolio.Text = m_Docto.IFOLIO.ToString();


                this.pnlCorteSeleccion.Visible = false;
                this.CBCorteActual.Checked = false;
                this.DTPFecha.Enabled = false;
                m_corteId = m_Docto.ICORTEID;


                

                if (m_modo.Equals("Consultar"))
                {
                    gRIDPVGASTODataGridView.ReadOnly = true;
                    btnGuardar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnImprimir.Visible = m_bPermisoReimprimirTicketContabilidad;
                }
                if (m_modo.Equals("Cambiar") )
                {

                    if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                    {
                        gRIDPVGASTODataGridView.ReadOnly = true;
                        btnGuardar.Enabled = false;
                        btnAgregar.Enabled = false;
                        btnImprimir.Visible = m_bPermisoReimprimirTicketContabilidad;
                    }
                }

                switch (m_Docto.IORIGENFISCALID)
                {
                    case DBValues._ORIGENFISCAL_FACTURADO:
                        this.CBOrigenFiscal.SelectedIndex = 1; break;
                    default:
                        this.CBOrigenFiscal.SelectedIndex = 0; break;
                }
                this.CBOrigenFiscal.Enabled = false;
                TBObservaciones.Text = m_Docto.IREFERENCIAS;


            }
            else
            {

                SetDefaultAlmacenEstatus();

                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_GASTOAGREGAR_ACTUAL, null))
                {
                    MessageBox.Show("No tiene derecho a agregar gastos");
                    this.Close();
                    return;
                }

                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_GASTOAGREGAR_OTROCORTE, null))
                {
                    DTPFecha.Enabled = false;
                    pnlCorteSeleccion.Enabled = false;

                }

                this.CBOrigenFiscal.SelectedIndex = 0;
               
            }
        }


        public void SetDefaultAlmacenEstatus()
        {


            if (!(bool)CurrentUserID.CurrentUser.isnull["IALMACENID"])
                this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID;
            else
                this.ALMACENComboBox.SelectedDataValue = DBValues._ALMACEN_DEFAULT;

        }

        private void LlenarGrid()
        {
            try
            {
                this.gRIDPVGASTOTableAdapter.Fill(this.dSContabilidad.GRIDPVGASTO, (int)m_Docto.IID);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        private void ProcessComand()
        {

            if (CBCajero.SelectedIndex < 0)
            {
                MessageBox.Show("Necesita seleccionar un cajero");
                return;
            }

            long? P_IDDOCTO = null;
            long? P_PERSONAID = 1;
            long? P_USERID = long.Parse(CBCajero.SelectedValue.ToString());  //iPos.CurrentUserID.CurrentUser.IID;
            long? P_CAJEROID = iPos.CurrentUserID.CurrentUser.IID;
            long? P_SUPERVISORID = m_autorizoId;


            long? ALMACENID = this.m_manejaAlmacen ? long.Parse(ALMACENComboBox.SelectedValue.ToString()) : DBValues._DOCTO_ALMACEN_DEFAULT;  //DBValues._DOCTO_ALMACEN_DEFAULT;/*CurrentUserID.CurrentUser.IUS_ALMACENID*/ ;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            long? TIPODOCTOID = DBValues._DOCTO_TIPO_GASTO;
            long? ESTATUSDOCTOID =  0;
            long? PARTIDAID =  null;
            long? ESTATUSDOCTOPAGOID = null;
            
            long? DOCTOREFID = null;
            string REFERENCIA = null;
            string REFERENCIAS = TBObservaciones.Text;

            long? P_IDCORTE = 0;

            
            DateTime? FECHA = CBCorteActual.Checked ? DateTime.Today : DTPFecha.Value;
            string CORTEACTUAL = CBCorteActual.Checked ? "S" : "N";
            DateTime? FECHACORTE = CBCorteActual.Checked ? DateTime.Today : DTPFecha.Value;
            long? CORTEAPLICARID = null;
            long? MOVTOID = 0;


            long? gastoId = null;
            decimal? totalGasto = null;

            if (this.GASTOIDTextBox.Text != "")
            {
                gastoId = Int64.Parse(this.GASTOIDTextBox.DbValue.ToString());
            }


            //AGREGAR EL CENTRO DE GASTO
            long? centroCostoId = null;

            if (this.CENTROCOSTOIDTextBox.Text != "")
            {
                centroCostoId = Int64.Parse(this.CENTROCOSTOIDTextBox.DbValue.ToString());
            }

            if (this.TBMonto.Text != "")
            {
                totalGasto = decimal.Parse(this.TBMonto.Text.ToString());
            }


            if(centroCostoId == null)
            {
                MessageBox.Show("Por favor capture el centro de costo");
                return;
            }


            if(gastoId == null || totalGasto == null)
            {
                return;
            }          
  
            if (!(bool)this.m_Docto.isnull["IID"])
            {
                P_IDDOCTO = m_Docto.IID;
            }




            CGASTOCAJAD gastoCajaD = new CGASTOCAJAD();

            if(CBCorteActual.Checked && m_corteId == 0)
            {
                long corteIdRef = 0;
                if(!ChecarCorteActivo(ref corteIdRef))
                {
                    return ;
                }
                else
                {
                    m_corteId = corteIdRef;
                }
            }

            long origenFiscalId = (this.CBOrigenFiscal.SelectedIndex == 0) ? DBValues._ORIGENFISCAL_REMISIONADO : DBValues._ORIGENFISCAL_FACTURADO;

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                if(gastoCajaD.EjecutarAddMOVTO(P_IDDOCTO,
                                        P_USERID,
                                        ALMACENID,
                                        SUCURSALID,
                                        TIPODOCTOID,
                                        ESTATUSDOCTOID,
                                        ESTATUSDOCTOPAGOID,
                                        P_PERSONAID,
                                        P_USERID,
                                        P_CAJEROID,
                                        P_SUPERVISORID,
                                       iPos.CurrentUserID.CurrentCompania.IEM_CAJA,
                                        PARTIDAID,
                                       gastoId,
                                       totalGasto,
                                       DOCTOREFID,
                                       REFERENCIA,
                                       REFERENCIAS,
                                       FECHA,
                                       P_FECHAVENCE,
                                       CORTEACTUAL,
                                       origenFiscalId,
                                       FECHACORTE,
                                       CORTEAPLICARID,
                                       centroCostoId,
                                       ref P_IDDOCTO,
                                       ref MOVTOID,
                                       ref P_IDCORTE,
                                       fTrans ))
                {

                    fTrans.Commit();

                    this.CBOrigenFiscal.Enabled = false;

                    this.limpiarEntradaGasto();
                    if (!CBCorteActual.Checked && m_corteId == 0)
                    {
                        m_corteId = P_IDCORTE.Value;
                    }

                    CBCorteActual.Enabled = false;
                    this.DTPFecha.Enabled = false;


                    ObtenerDoctoDeBD((long)P_IDDOCTO, null);

                    fConn.Close();

                    LlenarGrid();
                }
                else
                {

                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Ocurrio un error " + gastoCajaD.IComentario);
                }


           
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }
            
            

        }




        private void ObtenerDoctoDeBD(long lDoctoID, FbTransaction st)
        {
            CDOCTOD vDocto = new CDOCTOD();
            m_Docto = new CDOCTOBE();
            m_Docto.IID = lDoctoID;
            m_Docto = vDocto.seleccionarDOCTO(m_Docto, st);
        }



        public bool AgregarPagoEfectivo(CDOCTOBE docto, FbTransaction st, ref string comentario, long corteId)
        {

            try
            {
                CDOCTOPAGOBE pagoBE;
                CDOCTOPAGOD pagoD = new CDOCTOPAGOD();

                pagoBE = new CDOCTOPAGOBE();
                pagoBE.IFECHA = m_Docto.IFECHA;
                pagoBE.IFECHAHORA = DateTime.Now;
                pagoBE.ICORTEID = corteId;
                pagoBE.IIMPORTE = docto.ITOTAL;

                pagoBE.IDOCTOSALIDAID = docto.IID;
                pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_SALIDA;
                pagoBE.IDOCTOID = 0;

                pagoBE.IESAPARTADO = "N";
                pagoBE.IESPAGOINICIAL = DBValues._DB_BOOLVALUE_SI;

                pagoBE.ITIPOABONOID = DBValues._TIPO_ABONO_INICIAL;
                pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_EFECTIVO;
                pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_EFECTIVO;


                pagoBE = pagoD.InsertarDOCTOPAGOD(pagoBE, st);

                if (pagoBE == null)
                {
                    comentario = pagoD.IComentario;
                    return false;
                }
            }
            catch(Exception ex)
            {

            }


            return true;
        }

        public bool CerrarTransaccion(CDOCTOBE docto, FbTransaction st, ref string comentario)
        {
            CDOCTOD doctoD = new CDOCTOD();
            
            docto.IREFERENCIAS = TBObservaciones.Text;
            if(!doctoD.CambiarReferencias(docto, docto, st))
            {
                comentario = doctoD.IComentario;
                return false;
            }


            if (!doctoD.CerrarDOCTOD(docto, st))
            {
                comentario = doctoD.IComentario;
                return false;
            }
            else
            {
                return true;
            }
        }

        private void limpiarEntradaGasto()
        {
            TBMonto.Text = "0.0";
            GASTOIDTextBox.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProcessComand();
        }


        private void mandaAImprimirTickets(long dgDoctoId)
        {


            int iCantidadTickets = CurrentUserID.CurrentParameters.ICANTTICKETGASTOS > 0 ? CurrentUserID.CurrentParameters.ICANTTICKETGASTOS : 1;
            
            for (int i = 0; i < iCantidadTickets; i++)
            {
                mandaAImprimirTicket(dgDoctoId);
            }
        }


        private void mandaAImprimirTicket(long dgDoctoId)
        {


            WFGastoImprimir wf = new WFGastoImprimir(m_Docto.IID);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string comentario = "";

           if(this.dSContabilidad.GRIDPVGASTO.Rows.Count <= 0 )
           {
               MessageBox.Show("Debe haber al menos un gasto agregado");
               return;
           }

            
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();




                if (!CerrarTransaccion(m_Docto, fTrans, ref comentario))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Error " + comentario);
                    return;
                }



                if (!AgregarPagoEfectivo(m_Docto, fTrans, ref comentario, m_corteId))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Error " + comentario);
                    return;
                }
                else
                {


                    //checar si se necesita actualizar y reimiprimir el corte
                    Boolean bReimprimirCorte = false;
                    CCORTED corteD = new CCORTED();
                    CCORTEBE corteBE = new CCORTEBE();
                    corteBE.IID = m_corteId;
                    corteBE = corteD.seleccionarCORTE(corteBE, fTrans);
                    if (corteBE != null && !corteBE.IACTIVO.Equals("S"))
                    {
                        corteD.QueryObtenTotalesCORTE_PORID(corteBE, fTrans);
                        //si ocurrio un error
                        if(corteD.IComentario != "")
                        {

                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show("Error al actualizar el corte cerrado " + corteD.IComentario);
                            return;
                        }

                        if(!corteD.CORTE_ACTUALIZAR_DIFERENCIA(corteBE, fTrans))
                        {

                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show("Error al actualizar la diferencia del corte cerrado " + corteD.IComentario);
                            return;
                        }

                        bReimprimirCorte = true;
                    }


                    fTrans.Commit();
                    fConn.Close();
                    MessageBox.Show("El registro se ha guardado");



                    //manda a imprimir el recibo del gasto
                    mandaAImprimirTickets(m_Docto.IID);


                    //reimprimir corte si se requiere
                    if(bReimprimirCorte)
                    {

                        WFImpresionCorte ic2 = new WFImpresionCorte(m_corteId);
                        ic2.m_aditionalFooter = "Corte modificado por gasto en " + DateTime.Today.ToString("dd/MM/yyyy") +  " por " +  CurrentUserID.CurrentUser.INOMBRE;
                        ic2.ShowDialog();
                        bool bTicketImpreso = ic2.m_bTicketImpreso;
                        ic2.Dispose();
                        GC.SuppressFinalize(ic2);

                        if (bTicketImpreso)
                            MessageBox.Show("El ticket de corte se imprimio");
                    }

                    this.Close();
                    return;
                }

            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }



        }



        private bool ChecarCorteActivo(ref long corteId)
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;

            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                return false;
            }
            else
            {

                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {
                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                    return false;
                }
                else
                {

                    CCORTEBE corteBuffer = new CCORTEBE();
                    CCORTED corteD = new CCORTED();
                    corteBuffer.ICAJEROID = iPos.CurrentUserID.CurrentUser.IID;
                    corteBuffer.IFECHACORTE = fechaCorte;
                    corteBuffer = corteD.seleccionarCORTEXDIAyCAJERO(corteBuffer, null);

                    if (corteBuffer == null)
                    {
                        MessageBox.Show("No se pudo obtener la informacion del corte actual");
                        return false;
                    }

                    corteId = corteBuffer.IID;
                    return true;
                }

            }

        }

        private void gRIDPVGASTODataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 )
            {

                if (gRIDPVGASTODataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {
                    if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
                        return;


                    long movtoId = long.Parse(gRIDPVGASTODataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());

                    CGASTOCAJAD cajaD = new CGASTOCAJAD();
                    if(!cajaD.MOVTOGASTO_DELETE(movtoId, null))
                    {
                        MessageBox.Show(cajaD.IComentario);
                    }
                    else
                    {
                        LlenarGrid();
                    }

                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Esta seguro de cancelar este registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if(m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
            {

                CDOCTOD doctoD = new CDOCTOD();


                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;

                try
                {
                    fConn.Open();
                    fTrans = fConn.BeginTransaction();

                    if(doctoD.BorrarDOCTOD(m_Docto, fTrans))
                    {
                        fTrans.Commit();
                        fConn.Close();
                        MessageBox.Show("El registro se ha eliminado");
                        this.Close();
                        return;
                    }
                    else
                    {

                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("Ocurrio un error " + doctoD.IComentario);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    fTrans.Rollback();
                    MessageBox.Show(ex.Message + " " + ex.StackTrace);
                    fConn.Close();
                }
                finally
                {
                    fConn.Close();
                }
            
                

            }
            else if(m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_COMPLETO)
            {
                CUSUARIOSD usuariosD = new CUSUARIOSD();
                if (m_Docto.ICORTEID == CurrentUserID.CurrentUser.ICORTEID)
                {

                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_GASTOCANCELAR_ACTUAL, null))
                    {
                        MessageBox.Show("No tiene derechos para cancelar gastos en el corte actual");
                        return;

                    }
                }
                else if (m_Docto.IVENDEDORID == CurrentUserID.CurrentUser.IID)
                {

                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_GASTOCANCELAR_CORTE, null))
                    {

                        MessageBox.Show("No tiene derechos para cancelar gastos en un corte no activo");
                        return;
                    }
                }
                else
                {

                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_GASTOCANCELAR_CAJEROS, null))
                    {

                        MessageBox.Show("No tiene derechos para cancelar gastos de otro cajero");
                        return;
                    }
                }


                CGASTOCAJAD cajaD = new CGASTOCAJAD();

                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;

                try
                {
                    fConn.Open();
                    fTrans = fConn.BeginTransaction();

                    if (cajaD.GASTO_CANCEL(m_Docto.IID, m_Docto.IVENDEDORID,fTrans))
                    {
                        fTrans.Commit();
                        fConn.Close();
                        MessageBox.Show("El registro se ha cancelado");
                        this.Close();
                        return;
                    }
                    else
                    {

                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("Ocurrio un error " + cajaD.IComentario);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    fTrans.Rollback();
                    MessageBox.Show(ex.Message + " " + ex.StackTrace);
                    fConn.Close();
                }
                finally
                {
                    fConn.Close();
                }

            }
        }

        private void gRIDPVGASTODataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void gRIDPVGASTODataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (gRIDPVGASTODataGridView.Columns["DGTOTAL"].Index == e.ColumnIndex)
            {
                try
                {
                    decimal dNuevaCantidad = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejaCantidad = decimal.Parse(gRIDPVGASTODataGridView.Rows[e.RowIndex].Cells["DGTOTAL"].Value.ToString());
                    decimal dEntrada = dNuevaCantidad - dViejaCantidad;


                    if (dEntrada == 0)
                        return;
                    if (dNuevaCantidad <= 0)
                    {
                        MessageBox.Show("La cantidad  no puede ser menor o igual a cero, si requiere cancelar el detalle porfavor seleccione 'Eliminar detalle'");
                        e.Cancel = true;
                    }
                    else
                    {
                        long movtoId = long.Parse(gRIDPVGASTODataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                        long gastoId = long.Parse(gRIDPVGASTODataGridView.Rows[e.RowIndex].Cells["DGGASTOID"].Value.ToString());

                        string strBuffer = "";

                        this.GASTOIDTextBox.DbValue = gastoId.ToString();
                        this.GASTOIDTextBox.MostrarErrores = false;
                        this.GASTOIDTextBox.MValidarEntrada(out strBuffer, 1);
                        this.GASTOIDTextBox.MostrarErrores = true;

                        TBMonto.Text = dEntrada.ToString();

                        ProcessComand();

                        
                    }

                }
                catch (Exception ex)
                {
                }
            }
        }

        private void gRIDPVGASTODataGridView_EnterKeyDownEvent(object sender, EventArgs e)
        {
            this.GASTOIDTextBox.Focus();
        }

        private void DTPFecha_Validating(object sender, CancelEventArgs e)
        {
            if(DTPFecha.Value.Date > DateTime.Today)
            {
                MessageBox.Show("No puede seleccionar una fecha futura");
                e.Cancel = true;
            }
        }

        private void BuscarGastos()
        {
            iPos.Catalogos.WFGastos look = new iPos.Catalogos.WFGastos(GASTOIDTextBox.Text);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {

                string strBuffer = "";

                this.GASTOIDTextBox.DbValue = dr["ID"].ToString();
                this.GASTOIDTextBox.MostrarErrores = false;
                this.GASTOIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.GASTOIDTextBox.MostrarErrores = true;
            }
        }

        private void GASTOButton_Click(object sender, EventArgs e)
        {
            BuscarGastos();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            mandaAImprimirTicket(m_Docto.IID);
        }
    }
}
