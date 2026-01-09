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
using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public partial class WFCancelacionDocumentos : IposForm
    {
        CDOCTOBE m_Docto = new CDOCTOBE();
        CDOCTOBE m_DoctoRef = new CDOCTOBE();

        public WFCancelacionDocumentos()
        {
            m_Docto = new CDOCTOBE();
            InitializeComponent();
        }

        private void WFCancelacionDocumentos_Load(object sender, EventArgs e)
        {
            this.CBTipoDocumento.SelectedIndex = 0;
            this.RBFolioDocumento.Checked = false;
            this.RBFolioSAT.Checked = true;
        }

        private void RBFolioSAT_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarCampos();
        }

        private void HabilitarCampos()
        {
            this.TBFolioDocumento.Enabled = this.RBFolioDocumento.Checked;
            this.TBFolioSAT.Enabled = this.RBFolioSAT.Checked;
            this.TBSerieSAT.Enabled = this.RBFolioSAT.Checked;
        }

        private void RBFolioDocumento_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarCampos();
        }


        private bool CancelarSoloFacturaElectronica()
        {
            if (!this.CancelarFacturaElectronica())
            {

                MessageBox.Show("No se pudo cancelar la factura electronica en el SAT desde el sistema. Como la venta actual fue facturada electronicamente, tendra que cancelarla tambien en el SAT. Desea continuar con la cancelacion en el sistema?", "Cancelar la transaccion actual");
                    return false;
            }
            this.Close();
            return true;
        }
        
        private bool CancelarFacturaElectronica()
        {
            if (m_Docto.IESFACTURAELECTRONICA != null)
            {
                if (m_Docto.IESFACTURAELECTRONICA == "S")
                {


                    WFFacturaElectronica fe = new WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_CANCELAR, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
                    CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
                    fe.ShowDialog();
                    bool facturacionCancelada = fe.m_facturacionCancelada;
                    fe.Dispose();
                    GC.SuppressFinalize(fe);
                    if (!fe.m_facturacionCancelada)
                    {
                        return false;
                    }
                    else{
                        return true;
                    }
                }

            }

            return false;

        }

        private bool CancelarDocumento()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();


            if ((bool)m_Docto.isnull["IID"])
                return false;

            long statusDoctoId = m_Docto.IESTATUSDOCTOID;

            if (m_Docto.IESFACTURAELECTRONICA != null)
            {
                if (m_Docto.IESFACTURAELECTRONICA == "S")
                {


                    //WFFacturaElectronica fe = new WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_CANCELAR, this.m_DoctoRef, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
                    //CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
                    //fe.ShowDialog();
                    if (!this.CancelarFacturaElectronica())
                    {

                        if (MessageBox.Show("No se pudo cancelar la factura electronica en el SAT desde el sistema. Como la venta actual fue facturada electronicamente, tendra que cancelarla tambien en el SAT. Desea continuar con la cancelacion en el sistema?", "Cancelar la transaccion actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                            return false;
                    }
                }

            }




            pvd.CancelarVenta(m_Docto, CurrentUserID.CurrentUser, null);
            if (pvd.IComentario == "" || pvd.IComentario == null)
            {
                
                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                MessageBox.Show("Venta cancelada");

                if (statusDoctoId != DBValues._DOCTO_ESTATUS_BORRADOR)
                {
                    PosPrinter.ImprimirTicket(m_Docto.IID);
                }

                PreguntaComentarioCancelacion(m_Docto.IID, CurrentUserID.CurrentUser.IID, null);
                this.Close();
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                return false;
            }

            return true;
        }


        private bool PreguntaComentarioCancelacion(long doctoId, long usuarioId, FbTransaction ftrans)
        {
            string comentarioAut = "";
            WFPreguntaComentario wf1_ = new WFPreguntaComentario();
            wf1_.m_labelText = "Comentario de la cancelación";
            wf1_.ShowDialog();
            comentarioAut = wf1_.m_comentario.Trim();
            wf1_.Dispose();
            GC.SuppressFinalize(wf1_);

            if (comentarioAut != null && comentarioAut.Trim().Length > 0)
            {
                CDOCTOD doctoD = new CDOCTOD();
                doctoD.CambiarDOCTONOTASET(doctoId, DBValues._TIPODOCTONOTA_CANCELACION, DateTime.Now, usuarioId, comentarioAut, ftrans);

                return true;
            }

            return false;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();

            try
            {


                switch (this.CBTipoDocumento.SelectedIndex)
                {
                    case 0:
                        doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;
                        break;


                    case 1:
                        doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO;
                        break;



                    default: break;
                }

            }
            catch
            {
                return;
            }



            if (RBFolioDocumento.Checked)
            {

                if(TBFolioDocumento.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Porfavor llene el dato de folio");
                    return;
                }

                try
                {
                    doctoBE.IFOLIO = int.Parse(this.TBFolioDocumento.Text.ToString());
                }
                catch
                {
                    MessageBox.Show("El folio no es valido");
                    return;
                }
                doctoBE = doctoD.SeleccionarXTIPOYFOLIO(doctoBE, null);

            }
            else
            {


                if (TBFolioSAT.Text.Trim().Length == 0 || TBSerieSAT.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Porfavor llene el dato de folio y seria SAT");
                    return;
                }

                try
                {
                    doctoBE.IFOLIOSAT = int.Parse(this.TBFolioSAT.Text);
                    doctoBE.ISERIESAT = this.TBSerieSAT.Text;
                }
                catch
                {
                    MessageBox.Show("El folio SAT no es valido");
                    return;
                }

                doctoBE = doctoD.SeleccionarXTIPOYFOLIOFacturaElectronica(doctoBE, null);
            }

            if (doctoBE == null)
            {
                MessageBox.Show("Folio no encontrado");
                return;
            }

            if(doctoBE.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA )
            {
                if(doctoBE.ITIMBRADOCANCELADO == DBValues._DB_BOOLVALUE_SI)
                {


                    if (MessageBox.Show("EL documento ya esta cancelado tanto en el sistema como en el SAT. Desea hacer de nuevo la cancelacion en el SAT? ( lo mas probable es que devuelva un error de que el documento ya esta cancelado)", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        m_Docto = doctoBE;
                        CancelarSoloFacturaElectronica();
                        // cancela solo en SAT
                    }
                }
                else
                {

                    if (MessageBox.Show("EL documento ya esta cancelado tanto en el sistema pero no tenemos registrada la cancelacion en el SAT. Desea hacer la cancelacion en el SAT? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        m_Docto = doctoBE;
                        CancelarSoloFacturaElectronica();
                        // cancela solo en SAT
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Esta seguro de que desea cancelar este documento?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    m_Docto = doctoBE;
                    CancelarDocumento();
                    //cancelacion completa
                }

            }

        }

        private void BTSeleccionar_Click(object sender, EventArgs e)
        {

        }
    }
}
