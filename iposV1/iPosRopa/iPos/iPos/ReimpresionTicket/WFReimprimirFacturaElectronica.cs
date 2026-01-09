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
using iPosReporting;

namespace iPos
{
    public partial class WFReimprimirFacturaElectronica : IposForm
    {
        public WFReimprimirFacturaElectronica()
        {
            InitializeComponent();
        }

        private void BTSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {

                if (CBTipoTran.SelectedIndex < 0)
                    return;

                switch (CBTipoTran.SelectedItem.ToString())
                {
                    case "Venta":
                        {
                            WFLookUpTransacciones wfl = new WFLookUpTransacciones(0, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_VENTA, true);
                            wfl.ShowDialog();

                            DataRow dr = wfl.m_rtnDataRow;

                            wfl.Dispose();
                            GC.SuppressFinalize(wfl);


                            if (dr != null)
                            {
                                this.TBFolio.Text = dr["FOLIO"].ToString();
                            }

                        }
                        break;


                    case "Devolucion":
                        {
                            WFLookUpTransacciones wfl = new WFLookUpTransacciones(0, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO);
                            wfl.ShowDialog();

                            DataRow dr = wfl.m_rtnDataRow;

                            wfl.Dispose();
                            GC.SuppressFinalize(wfl);


                            if (dr != null)
                            {
                                this.TBFolio.Text = dr["FOLIO"].ToString();
                            }

                        }
                        break;






                    default: break;
                }
            }
            catch
            {
            }
        }

        private void BTSeleccionarFE_Click(object sender, EventArgs e)
        {
            try
            {
                if (CBTipoTran.SelectedIndex < 0)
                    return;

                switch (CBTipoTran.SelectedItem.ToString())
                {
                    case "Venta":
                        {
                            WFLookUpTransacciones wfl = new WFLookUpTransacciones(0, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_VENTA,true);
                            wfl.ShowDialog();

                            DataRow dr = wfl.m_rtnDataRow;

                            wfl.Dispose();
                            GC.SuppressFinalize(wfl);


                            if (dr != null)
                            {
                                    this.TBFolioSAT.Text = dr["FOLIOSAT"].ToString();
                                    this.TBSerieSAT.Text = dr["SERIESAT"].ToString();
                            }

                        }
                        break;


                    case "Devolucion":
                        {
                            WFLookUpTransacciones wfl = new WFLookUpTransacciones(0, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO);
                            wfl.ShowDialog();

                            DataRow dr = wfl.m_rtnDataRow;

                            wfl.Dispose();
                            GC.SuppressFinalize(wfl);


                            if (dr != null)
                            {

                                this.TBFolioSAT.Text = dr["FOLIOSAT"].ToString();
                                this.TBSerieSAT.Text = dr["SERIESAT"].ToString();
                            }

                        }
                        break;



                    default: break;
                }
            }
            catch
            {
            }
        }

        private void RBPorFactura_CheckedChanged(object sender, EventArgs e)
        {
            this.TBFolio.Enabled = !RBPorFactura.Checked;
            this.BTSeleccionar.Enabled = !RBPorFactura.Checked;


            this.TBFolioSAT.Enabled = RBPorFactura.Checked;
            this.TBSerieSAT.Enabled = RBPorFactura.Checked;
            this.BTSeleccionarFE.Enabled = RBPorFactura.Checked;
        }

        private void BTReImprimir_Click(object sender, EventArgs e)
        {

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            //long lPrintOption = 0;

            try
            {

               
                switch (CBTipoTran.SelectedItem.ToString())
                {
                    case "Venta":
                        doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;
                        break;


                    case "Devolucion":
                        doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO;
                        break;

                    default: break;
                }

            }
            catch
            {
                return;
            }


            if (RBPorTrans.Checked)
            {
                doctoBE.IFOLIO = int.Parse(this.TBFolio.Text.ToString());
                doctoBE = doctoD.SeleccionarXTIPOYFOLIO(doctoBE, null);
            }
            else
            {
                doctoBE.IFOLIOSAT = int.Parse(this.TBFolioSAT.Text.ToString());
                doctoBE.ISERIESAT = this.TBSerieSAT.Text;
                doctoBE = doctoD.SeleccionarXTIPOYFOLIOFacturaElectronica(doctoBE, null);
            }

            if (doctoBE == null)
            {
                MessageBox.Show("Folio no encontrado");
                return;
            }

            try
            {
                imprimirFacturaElectronica(doctoBE);
                reimprimirTrasladoIfContains(doctoBE);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private bool imprimirFacturaElectronica(CDOCTOBE Docto)
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            Docto = doctoD.seleccionarDOCTO(Docto, null);

            if ((bool)Docto.isnull["IFOLIOSAT"] || (bool)Docto.isnull["IESTATUSDOCTOID"]
                || Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || Docto.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }

            CDOCTOBE doctoRef = new CDOCTOBE();
            if ((bool)Docto.isnull["IDOCTOREFID"] || Docto.IDOCTOREFID <= 0)
                doctoRef = null;
            else
            {
                doctoRef.IID = Docto.IDOCTOREFID;
                doctoRef = doctoD.seleccionarDOCTO(doctoRef, null);
            }

            WFFacturaElectronica fe = new WFFacturaElectronica(Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, doctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }


        private bool imprimirComprobanteTraslado(CDOCTOBE Docto)
        {

            bool retorno = false;

            CDOCTOD doctoD = new CDOCTOD();
            CUSUARIOSD usuariosD = new CUSUARIOSD();


            CDOCTOBE doctoRef = new CDOCTOBE();
            if ((bool)Docto.isnull["IDOCTOREFID"] || Docto.IDOCTOREFID <= 0)
                doctoRef = null;
            else
            {
                doctoRef.IID = Docto.IDOCTOREFID;
                doctoRef = doctoD.seleccionarDOCTO(doctoRef, null);
            }

            CDOCTOPAGOBE pagoTemporal = new CDOCTOPAGOBE();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();
            pagoTemporal = doctoPagoD.seleccionarPrimerDOCTOPAGO(Docto, null);

            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENPDF_COMPROBTRASL, doctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.m_vendedorId = CurrentUserID.CurrentUser.IID;
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            return retorno;

        }

        private void reimprimirTrasladoIfContains(CDOCTOBE Docto)
        {
            CDOCTOD doctoD = new CDOCTOD();
            bool containsTraslado = doctoD.ContieneComprobante(Docto, "T", null);
            if (containsTraslado)
            {
                this.imprimirComprobanteTraslado(Docto);
            }
        }

    }
}
