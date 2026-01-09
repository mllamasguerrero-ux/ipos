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
    public partial class WFReciboDepositoEdit : IposForm
    {

        int m_estadoVenta;
        CDOCTOBE m_Docto;

        long predoctoId = 0;
        long m_corteId = 0;

        bool m_bSeleccionarCajero = false;

        string m_modo = "Agregar";

        long m_autorizoId = 0;

        string m_printer = "";
        bool m_bPermisoReimprimirTicketContabilidad = false;
        public WFReciboDepositoEdit()
        {
            InitializeComponent();
            m_autorizoId = CurrentUserID.CurrentUser.IID;
            m_Docto = new CDOCTOBE();



        }


        public WFReciboDepositoEdit(bool bSeleccionarCajero, long autorizoId)
            : this()
        {
            m_autorizoId = autorizoId;
            m_bSeleccionarCajero = bSeleccionarCajero;

        }

        public WFReciboDepositoEdit(long doctoId, string modo)
            : this()
        {
            predoctoId = doctoId;
            m_modo = modo;


        }

        private void WFReciboDepositoEdit_Load(object sender, EventArgs e)
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

            try
            {
                m_printer =  Ticket.GetReceiptPrinter();
            }
            catch { }

            this.CBCajero.llenarDatos();
            this.CBCajero.SelectedDataValue = CurrentUserID.CurrentUser.IID.ToString();

            this.CBCajero.Enabled = m_bSeleccionarCajero;
            if(m_bSeleccionarCajero)
            {
                pnlCorteSeleccion.Visible = false;
                CBCorteActual.Checked = false;
            }



            if (predoctoId != 0)
            {
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IID = predoctoId;
                doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                if(doctoBE == null)
                {
                    MessageBox.Show("No se pudo cargar la informacion del deposito");
                    return;
                }
                
                m_Docto = doctoBE;
                this.DTPFecha.Value = m_Docto.IFECHA;
                this.LBFolio.Text = m_Docto.IFOLIO.ToString();
                this.TBNotas.Text = m_Docto.IREFERENCIAS;
                this.TBMonto.Text = m_Docto.ITOTAL.ToString("N2");
                this.CBCajero.SelectedDataValue = m_Docto.IVENDEDORID;


                this.pnlCorteSeleccion.Visible = false;
                this.CBCorteActual.Checked = false;
                this.DTPFecha.Enabled = false;
                m_corteId = m_Docto.ICORTEID;

                if (m_modo.Equals("Consultar") )
                {
                    btnGuardar.Enabled = false;
                    btnGuardar.Visible = false;
                    btnImprimir.Visible = m_bPermisoReimprimirTicketContabilidad;
                    pnlEdicion.Enabled = false;
                }

               if(m_modo.Equals("Cambiar"))
                {
                    btnImprimir.Visible = m_bPermisoReimprimirTicketContabilidad;
                }

            }
            else
            {


                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEPOSITOAGREGAR, null))
                {
                    MessageBox.Show("No tiene derecho a agregardepositos");
                    this.Close();
                    return;
                }

                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEPOSITOAGREGAR_OTROCORTE, null))
                {
                    DTPFecha.Enabled = false;
                    pnlCorteSeleccion.Enabled = false;

                }

               
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
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
        }



        public void ImprimirTickets(long doctoId)
        {

            int iCantidadTickets = CurrentUserID.CurrentParameters.ICANTTICKETDEPOSITOS > 0 ? CurrentUserID.CurrentParameters.ICANTTICKETDEPOSITOS : 1;

            for (int i = 0; i < iCantidadTickets; i++)
            {
                ImprimirTicket(doctoId);
            }
        }

        public void ImprimirTicket(long doctoId)
        {

            Ticket ticket = new Ticket();
            //decimal dVentasNetas;

            this.dEPOSITOSIMPRESIONTableAdapter.Fill(this.dSContabilidad.DEPOSITOSIMPRESION, doctoId);

            if (this.dSContabilidad.DEPOSITOSIMPRESION.Rows.Count < 1)
            {
                return;
            }

            long lTipoDoctoId = long.Parse(this.dSContabilidad.DEPOSITOSIMPRESION.Rows[0]["TIPODOCTOID"].ToString());

            ticket.AddHeaderLine("" + this.dSContabilidad.DEPOSITOSIMPRESION.Rows[0]["TIPODOCTOCLAVE"].ToString());
            ticket.AddHeaderLine("Sucursal        : " + this.dSContabilidad.DEPOSITOSIMPRESION.Rows[0]["SUCURSAL"].ToString());
            ticket.AddHeaderLine("Fecha           : " + ((DateTime)this.dSContabilidad.DEPOSITOSIMPRESION.Rows[0]["FECHA"]).ToString("dd/MM/yyyy"));
            ticket.AddHeaderLine("Hora            : " + DateTime.Now.ToShortTimeString());
            ticket.AddHeaderLine("Usuario         : " + this.dSContabilidad.DEPOSITOSIMPRESION.Rows[0]["USUARIONOMBRE"].ToString());

            
            
                ticket.AddHeaderLine(new string('-', Ticket.maxChar));
                ticket.AddHeaderLine("");
                if (this.dSContabilidad.DEPOSITOSIMPRESION.Rows[0]["NOTAS"].ToString().Trim().Length > 0)
                {
                    ticket.AddHeaderLine("Nota             ");
                    ticket.AddHeaderLine(this.dSContabilidad.DEPOSITOSIMPRESION.Rows[0]["NOTAS"].ToString());
                    ticket.AddHeaderLine("");
                }
                ticket.AddHeaderLine(formatTotalLine("Monto: ", decimal.Parse(this.dSContabilidad.DEPOSITOSIMPRESION.Rows[0]["TOTAL"].ToString()).ToString("N2")));
                ticket.AddHeaderLine(new string('-', Ticket.maxChar));

                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");

                ticket.AddHeaderLine(new string('=', Ticket.maxChar));
                ticket.AddHeaderLine("                 FIRMA                  ");

            
            
            ticket.AddFooterLine("");

            if (m_printer != "")
            {
                ticket.PrintTicketDirect(this.m_printer);
                MessageBox.Show("El ticket se imprimio");
            }


        }


        private string formatTotalLine(string name, string total)
        {

            string line = Ticket.FormatPrintField(name, 28, 0);
            line += Ticket.FormatPrintField(total, 11, 0);
            line = AlignRightText(line.Length) + line;
            return line;
        }


        private string AlignRightText(int lenght)
        {
            string espacios = "";
            int spaces = 39 - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string comentario = "";
            

            
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();


                decimal importe = Decimal.Parse(this.TBMonto.Text.ToString());
                if (importe <= 0)
                {
                    MessageBox.Show("Ingrese un importe mayor de cero");
                    return;
                }

                CDOCTOBE doctoBE = new CDOCTOBE();
                CDOCTOD doctoD = new CDOCTOD();

                doctoBE.IALMACENID = DBValues._DOCTO_ALMACEN_DEFAULT;
                doctoBE.ISUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
                doctoBE.IVENDEDORID = long.Parse(CBCajero.SelectedValue.ToString());//iPos.CurrentUserID.CurrentUser.IID;
                doctoBE.IFECHA = DTPFecha.Value;
                doctoBE.ICAJAID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;

               
                doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_DEPOSITO;
                doctoBE.IPERSONAID = DBValues._CLIENTEMOSTRADOR;
               

                doctoBE.IREFERENCIAS = TBNotas.Text;
                doctoBE.ITOTAL = importe;
                if (!doctoD.DEPOSITO_INSERT(ref doctoBE, null))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Error al insertar el deposito");
                    return;
                }



                 fTrans.Commit();
                 fConn.Close();
                 MessageBox.Show("El registro se ha guardado");



                //manda a imprimir el recibo del gasto
                ImprimirTickets(doctoBE.IID);


                    

                 this.Close();
                 return;
                

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

                    if(doctoD.DEPOSITO_CANCEL(m_Docto, fTrans))
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

                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEPOSITOCANCELAR, null))
                    {
                        MessageBox.Show("No tiene derechos para cancelar gastos en el corte actual");
                        return;

                    }
                }
                else if (m_Docto.IVENDEDORID == CurrentUserID.CurrentUser.IID)
                {

                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEPOSITOCANCELAR, null))
                    {

                        MessageBox.Show("No tiene derechos para cancelar gastos en un corte no activo");
                        return;
                    }
                }
                else
                {

                    if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEPOSITOCANCELAR, null))
                    {

                        MessageBox.Show("No tiene derechos para cancelar gastos de otro cajero");
                        return;
                    }
                }


                CDOCTOD doctoD = new CDOCTOD();

                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;

                try
                {
                    fConn.Open();
                    fTrans = fConn.BeginTransaction();

                    if (doctoD.DEPOSITO_CANCEL(m_Docto,fTrans))
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
        }

        private void gRIDPVGASTODataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        

        private void DTPFecha_Validating(object sender, CancelEventArgs e)
        {
            if(DTPFecha.Value.Date > DateTime.Today)
            {
                MessageBox.Show("No puede seleccionar una fecha futura");
                e.Cancel = true;
            }
        }

       

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirTicket(this.m_Docto.IID);
        }
    }
}
