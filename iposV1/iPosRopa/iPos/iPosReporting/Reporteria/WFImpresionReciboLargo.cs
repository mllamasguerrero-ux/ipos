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
using System.IO;

namespace iPos
{
    public partial class WFImpresionReciboLargo : Form
    {
        long m_doctoid;
        long m_tipodoctoid = 0;
        long m_subtipodoctoid = 0;
        bool m_usaDatosDeEntregaCuandoExista = true;
        bool m_bMarcaAgua = false;
        int m_numerocopias = 2;
        public bool m_imprimirRecDevolucion = false;
        public bool m_imprimirRecCompDevolucion = false;
        bool m_enDolar = false;
        bool m_conTopes = false;

        long? m_filterByUserId = 0;

        bool m_bImpresionDirecta = false;
        string m_impresoraEspecial = null;
      
        public WFImpresionReciboLargo()
        {
            InitializeComponent();
        }
        public WFImpresionReciboLargo(long doctoId)
            : this()
        {
            m_doctoid = doctoId;
        }

        public WFImpresionReciboLargo(long doctoId, long tipodoctoid)
            : this(doctoId)
        {
            m_tipodoctoid = tipodoctoid;
        }

        public WFImpresionReciboLargo(long doctoId, long tipodoctoid, bool bMarcaAgua)
            : this(doctoId, tipodoctoid)
        {
            m_bMarcaAgua = bMarcaAgua;
        }
        public WFImpresionReciboLargo(long doctoId, long tipodoctoid, bool bMarcaAgua, int numerocopias)
            : this(doctoId, tipodoctoid)
        {
            m_numerocopias = numerocopias;
        }

        public WFImpresionReciboLargo(long doctoId, long tipodoctoid, bool bMarcaAgua, int numerocopias, bool enDolar, bool conTopes, bool bImpresionDirecta, string impresoraEspecial, long? filterByUserId )
            : this(doctoId, tipodoctoid,bMarcaAgua, numerocopias)
        {
            m_enDolar = enDolar;
            m_conTopes = conTopes;
            m_bImpresionDirecta = bImpresionDirecta;
            m_impresoraEspecial = impresoraEspecial;

            m_filterByUserId = filterByUserId;
        }

        

        private void WFImpresionReciboLargo_Load(object sender, EventArgs e)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)ConexionesBD.ConexionBD.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);

            CDOCTOD doctoD = new CDOCTOD();

            //para devoluciones de compra .. obten el doctorefid
            if (this.m_imprimirRecCompDevolucion)
            {
                long devolucionId = doctoD.seleccionarDEVOLUCIONCOMPRAIMPORTADAxDOCTOREFID(m_doctoid, null);
                if (devolucionId > 0)
                {
                    m_doctoid = devolucionId;
                }
            }

            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = m_doctoid;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
            m_subtipodoctoid = doctoBE.ISUBTIPODOCTOID;

            if (m_tipodoctoid == 0)
            {
                if (doctoBE != null)
                    m_tipodoctoid = doctoBE.ITIPODOCTOID;
            }


            DefinirDatosEntrega();

            if (m_tipodoctoid == 201 || m_tipodoctoid == 202)
            {
                report1.Load(FastReportsConfig.getPathForFile("recibolargoanticipo.frx", FastReportsTipoFile.desistema));
            
            }
            else
            {
                string strNombreArchivo = "recibolargo.frx";

                long[] subtiposCompraImportada = new long[] { DBValues._DOCTO_SUBTIPO_COMPRAPEDIDO, DBValues._DOCTO_SUBTIPO_COMPRAIMPORTADA , DBValues._DOCTO_SUBTIPO_COMPRARECORDEN };
                if(m_tipodoctoid == DBValues._DOCTO_TIPO_COMPRA && !subtiposCompraImportada.Contains(m_subtipodoctoid))
                {
                    if (File.Exists(FastReportsConfig.getPathForFile("recibo_compra.frx", FastReportsTipoFile.deusuario)))
                    {
                        strNombreArchivo = "recibo_compra.frx";
                    }

                }
                else if (m_tipodoctoid == DBValues._DOCTO_TIPO_TRASPASO_REC)
                {
                    if (File.Exists(FastReportsConfig.getPathForFile("recibo_trasla_rec.frx", FastReportsTipoFile.deusuario)))
                    {
                        strNombreArchivo = "recibo_trasla_rec.frx";
                    }

                }
                else if (m_tipodoctoid == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
                {
                    if (File.Exists(FastReportsConfig.getPathForFile("recibo_trasla_env.frx", FastReportsTipoFile.deusuario)))
                    {
                        strNombreArchivo = "recibo_trasla_env.frx";
                    }

                }
                else if (m_tipodoctoid == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA)
                {
                    if (File.Exists(FastReportsConfig.getPathForFile("recibo_surt_env.frx", FastReportsTipoFile.deusuario)))
                    {
                        strNombreArchivo = "recibo_surt_env.frx";
                    }

                }
                else if(m_tipodoctoid == DBValues._DOCTO_TIPO_COMPRA && subtiposCompraImportada.Contains(m_subtipodoctoid))
                {

                    if (File.Exists(FastReportsConfig.getPathForFile("recibo_surt_rec.frx", FastReportsTipoFile.deusuario)))
                    {
                        strNombreArchivo = "recibo_surt_rec.frx";
                    }
                }
                else if (m_tipodoctoid == DBValues._DOCTO_TIPO_VENTA)
                {

                    if (File.Exists(FastReportsConfig.getPathForFile("recibo_venta.frx", FastReportsTipoFile.deusuario)))
                    {
                        strNombreArchivo = "recibo_venta.frx";
                    }

                    if (m_conTopes && File.Exists(FastReportsConfig.getPathForFile("RECIBO_CONTOPE.frx", FastReportsTipoFile.deusuario)))
                    {

                        strNombreArchivo = "RECIBO_CONTOPE.frx";
                    }

                }
                else if (m_tipodoctoid == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO)
                {
                    if (File.Exists(FastReportsConfig.getPathForFile("recibo_ndc.frx", FastReportsTipoFile.deusuario)))
                    {
                        strNombreArchivo = "recibo_ndc.frx";
                    }
                }
                else if (m_tipodoctoid == DBValues._DOCTO_TIPO_ORDEN_COMPRA)
                {
                    if (File.Exists(FastReportsConfig.getPathForFile("Recibo_orden de compra.frx", FastReportsTipoFile.deusuario)))
                    {
                        strNombreArchivo = "Recibo_orden de compra.frx";
                    }
                }
                
                //para devoluciones 
                if(m_imprimirRecDevolucion)
                {
                     strNombreArchivo = "RECIBOLARGODEVO.frx";
                }

                report1.Load(FastReportsConfig.getPathForFile(strNombreArchivo, FastReportsTipoFile.deusuario));
            }
            
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);
            report1.SetParameterValue("pdoctoid", m_doctoid);
            report1.SetParameterValue("usaDatosDeEntregaCuandoExista", m_usaDatosDeEntregaCuandoExista ? "S" : "N");
            report1.SetParameterValue("desglosekits", usuarioTienePermisoDesgloseKit ? "S" : "N");
            report1.SetParameterValue("marcaAgua", m_bMarcaAgua ? "S" : "N");
            report1.SetParameterValue("enDolar", m_enDolar ? "S" : "N");


            report1.SetParameterValue("creadoPorUserId", m_filterByUserId == null || !m_filterByUserId.HasValue ? 0 : m_filterByUserId.Value);


            if (m_numerocopias > 1)
            {
                report1.PrintSettings.Copies = m_numerocopias;
                report1.PrintSettings.CopyNames = new string[] { "", "", "copia" };
                 
            }

            if (report1.Prepare())
            {
                if (ConexionesBD.ConexionBD.CurrentParameters.IRECIBOLARGOPREVIEW.Equals("S") && !m_bImpresionDirecta)
                {
                    report1.ShowPrepared();
                }
                else
                {
                    string nombreImpresora = m_impresoraEspecial != null && m_impresoraEspecial.Length > 0 ? m_impresoraEspecial :
                                                ConexionesBD.ConexionBD.CurrentParameters.IRECIBOLARGOPRINTER;
                    if (doctoBE.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
                        nombreImpresora = ConexionesBD.ConexionBD.CurrentParameters.IRECIBOLARGOCOTIPRINTER;

                    report1.PrintSettings.Printer = nombreImpresora;
                    report1.PrintSettings.ShowDialog = false;
                    report1.Print();
                    this.Close();
                }

            }




        }


        private CDOCTOBE GetDocto(long doctoId)
        {

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
            return doctoBE;

        }


        private void DefinirDatosEntrega()
        {

            m_usaDatosDeEntregaCuandoExista = true;


            CDOCTOBE doctoBE = GetDocto(m_doctoid);

            if (ConexionesBD.ConexionBD.CurrentParameters.IPREGUNTARDATOSENTREGA != "S")
            {
                CambiarUsoDatosEntrega(m_doctoid, "S");
                return;
            }

            if (!(bool)doctoBE.isnull["IDOM_ENTREGAID"] && (doctoBE.IDOM_ENTREGAID > 0))
            {
                CambiarUsoDatosEntrega(doctoBE.IID, "S");
                return;
            }


            CDOMICILIOD domicilioD = new CDOMICILIOD();
            bool existeDomicilioEntrega = domicilioD.ExisteDOMICILIOParaPersona(doctoBE.IPERSONAID, null) > 0;


            if (!existeDomicilioEntrega)
            {
                CambiarUsoDatosEntrega(doctoBE.IID, "S");
                return;
            }


            if (!(bool)doctoBE.isnull["IUSARDATOSENTREGA"] && (doctoBE.IUSARDATOSENTREGA.Equals("S") || doctoBE.IUSARDATOSENTREGA.Equals("N")))
            {
                m_usaDatosDeEntregaCuandoExista = doctoBE.IUSARDATOSENTREGA.Equals("S");
                CambiarUsoDatosEntrega(m_doctoid, doctoBE.IUSARDATOSENTREGA);
                return;
            }
            

            long? domicilioEntregaSelecconadoId = SeleccionarDomicilioEntrega(false, doctoBE);
            if (domicilioEntregaSelecconadoId != null)
            {
                CambiarUsoDatosEntrega(doctoBE.IID, "S");
                return;
            }

            m_usaDatosDeEntregaCuandoExista = false;
            CambiarUsoDatosEntrega(m_doctoid, "N");

        }


        private long? SeleccionarDomicilioEntrega(bool silentMode, CDOCTOBE doctoBE)
        {
            long? domEntregaId = null;

            WFSeleccionarDomicilioEntregaFact rc_ = new WFSeleccionarDomicilioEntregaFact(doctoBE.IPERSONAID,
                "Hay datos de entrega definidos para este cliente. Si lo desea selecciona el domicilio de entrega de la lista. De lo contrario eliga usar los datos del cliente.",
                doctoBE.IDOM_ENTREGAID);
            rc_.ShowDialog();

            if (rc_.DomicilioSeleccionadoId != doctoBE.IDOM_ENTREGAID)
            {

                CDOCTOD doctoD = new CDOCTOD();

                if (rc_.DomicilioSeleccionadoId != null)
                    doctoBE.IDOM_ENTREGAID = rc_.DomicilioSeleccionadoId.Value;

                if (doctoD.CambiarDomicilioEntrega(doctoBE, null))
                {
                    if (!silentMode)
                        MessageBox.Show("Se actualizo el domicilio de entrega");
                    
                    domEntregaId = doctoBE.IDOM_ENTREGAID;
                }
                else if (!silentMode)
                {
                    MessageBox.Show("Ocurrio un error " + doctoD.IComentario);
                }
            }


            rc_.Dispose();
            GC.SuppressFinalize(rc_);

            return domEntregaId;
        }


        private void CambiarUsoDatosEntrega(long doctoId, string value)
        {

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE.IUSARDATOSENTREGA = value;
            if (!doctoD.CambiarUsarDatosEntregaDOCTOD(doctoBE, null))
            {
                MessageBox.Show(doctoD.IComentario);
            }


        }





    }
}
