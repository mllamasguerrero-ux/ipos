using FirebirdSql.Data.FirebirdClient;
using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFVentasDivididasXPlazo : Form
    {

        long m_doctoPlazoOrigenId = 0;
        decimal m_totalVentas = 0;
        CDOCTOBE m_doctoPlazoOrigenBE = null;
        bool m_bTieneDerechoRutaEmbarque = false;
        public WFVentasDivididasXPlazo()
        {
            InitializeComponent();
        }
        public WFVentasDivididasXPlazo(long doctoPlazoOrigenId) : this()
        {
            m_doctoPlazoOrigenId = doctoPlazoOrigenId;
        }

        private void LlenarGrid()
        {
            try
            {
                long corteActual = CurrentUserID.CurrentUser.ICORTEID;

                //DateTime.Today.AddDays(-30)
                this.dOCTODIVIDIDOPORPLAZOTableAdapter.Fill(this.dSPuntoDeVentaAux2.DOCTODIVIDIDOPORPLAZO, (int)m_doctoPlazoOrigenId);


                if (this.dSPuntoDeVentaAux2.DOCTODIVIDIDOPORPLAZO.Rows.Count == 0)
                {
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void LlenarTotal()
        {
            m_totalVentas = 0;
            foreach (PuntoDeVenta.DSPuntoDeVentaAux2.DOCTODIVIDIDOPORPLAZORow row in this.dSPuntoDeVentaAux2.DOCTODIVIDIDOPORPLAZO.Rows)
            {
                if(!row.IsTOTALNull())
                {

                    m_totalVentas += row.TOTAL;
                }
            }

            lblTotalVentas.Text = m_totalVentas.ToString("N2");
        }



       





        private void vENTASCONERROREMIDADataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (vENTASCONERROREMIDADataGridView.Columns[e.ColumnIndex].Name == "DGPagar")
                {


                    long docId = (long)vENTASCONERROREMIDADataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                    

                    try
                    {

                        WFPuntoDeVenta wf = new WFPuntoDeVenta(docId, true);
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);

                        LlenarGrid();
                        LlenarTotal();

                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {

                    }


                }
            }
        }

        private void WFVentasDivididasXPlazo_Load(object sender, EventArgs e)
        {
            LlenarGrid();
            LlenarTotal();

            ObtenerDoctoDeBD(m_doctoPlazoOrigenId);
            asignarPermisos();
        }



        private void btnTerminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPagarTodas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea que el sistema intente pagar en efectivo las ventas?",
                                "Confirmacion",
                                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if(!PreguntarSiEsServDomSiAplica())
            {
                return;
            }

            if(!asignarRutaEmbarqueSiAplica())
            {
                return;
            }

            foreach (PuntoDeVenta.DSPuntoDeVentaAux2.DOCTODIVIDIDOPORPLAZORow row in this.dSPuntoDeVentaAux2.DOCTODIVIDIDOPORPLAZO.Rows)
            {
                WFPuntoDeVenta wf = new WFPuntoDeVenta(row.ID, true,true);
                wf.ShowDialog();
                bool bPagoAutomaticoHecho = wf.m_bPagoAutomaticoHecho;
                wf.Dispose();
                GC.SuppressFinalize(wf);

                if (!bPagoAutomaticoHecho)
                {
                    
                    break;
                }
            }

            this.LlenarGrid();
            this.LlenarTotal();
        }


        private void ObtenerDoctoDeBD(long lDoctoID)
        {
            CDOCTOD vDocto = new CDOCTOD();

            m_doctoPlazoOrigenBE = new CDOCTOBE();
            m_doctoPlazoOrigenBE.IID = lDoctoID;
            m_doctoPlazoOrigenBE = vDocto.seleccionarDOCTO(m_doctoPlazoOrigenBE, null);


        }

        private void asignarPermisos()
        {
            CUSUARIOSD usersD = new CUSUARIOSD();
            if (!usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._PONER_RUTA_EMBARQUE_EN_VENTA, null))
            {
                m_bTieneDerechoRutaEmbarque = false;
            }
            else
            {
                
                m_bTieneDerechoRutaEmbarque = true;
            }

            if(m_doctoPlazoOrigenBE != null)
            {

                CPERSONABE personaBE = new CPERSONABE();
                CPERSONAD personaD = new CPERSONAD();
                personaBE.IID = m_doctoPlazoOrigenBE.IPERSONAID;
                personaBE = personaD.seleccionarPERSONA(personaBE, null);
                if(personaBE != null)
                {
                    btnPagarTodas.Enabled = personaBE.IHAB_PAGOEFECTIVO == null || personaBE.IHAB_PAGOEFECTIVO.Equals("S");
                }
                
            }

        }
        

        private bool PreguntarSiEsServDomSiAplica()
        {
            if (CurrentUserID.CurrentParameters.IPREGUNTARSERVDOM == null || !CurrentUserID.CurrentParameters.IPREGUNTARSERVDOM.Equals("S") )
                return true;


            CPERSONAD daoPersona = new CPERSONAD();
            CPERSONABE cliente = new CPERSONABE();
            cliente.IID = m_doctoPlazoOrigenBE.IPERSONAID;
            cliente = daoPersona.seleccionarPERSONA(cliente, null);

            if (cliente == null || cliente.ISERVICIOADOMICILIO == null || !cliente.ISERVICIOADOMICILIO.Equals("S"))
                return true;

            if (MessageBox.Show("Es esta una venta a domicilio?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return true;
            }


            CDOCTOD doctoD = new CDOCTOD();
            m_doctoPlazoOrigenBE.IESSERVDOMICILIO = "S";
            if (!doctoD.CambiarESSERVDOMICILIO_DIVIDIDOSPLAZO(m_doctoPlazoOrigenBE, null))
            {
                m_doctoPlazoOrigenBE.IESSERVDOMICILIO = "N";
                MessageBox.Show("No se pudo asignar como servicio a domicilio " + doctoD.IComentario);
                return false;
            }

            return true;

        }



        private bool asignarRutaEmbarqueSiAplica()
        {
            

            //Si a) tiene derecho a ruta de embarque, b) el cliente es diferente de mostrador o tiene definido un cliente de entrega 
            //( en las ventas normales se usa el campo personapartadoid para designar al cliente de entrega)
            // y c) nos aseguramos de que sean solo ventas
            if (m_bTieneDerechoRutaEmbarque &&
                (m_doctoPlazoOrigenBE.IPERSONAID != DBValues._CLIENTEMOSTRADOR) && (m_doctoPlazoOrigenBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA) &&
                m_doctoPlazoOrigenBE.IRUTAEMBARQUEID == 0)
            {

                iPos.PuntoDeVenta.WFSeleccionarRutaEmbarque sre = new PuntoDeVenta.WFSeleccionarRutaEmbarque(true, m_doctoPlazoOrigenBE.IPERSONAID);
                sre.ShowDialog();
                m_doctoPlazoOrigenBE.IRUTAEMBARQUEID = sre.rutaEmbarqueId;
                sre.Dispose();

                if(m_doctoPlazoOrigenBE.IRUTAEMBARQUEID != 0)
                {

                    CDOCTOD doctoD = new CDOCTOD();
                    if (!doctoD.CambiarRutaEmbarqueDOCTO_DIVIDIDOSPLAZO(m_doctoPlazoOrigenBE, null))
                    {
                        m_doctoPlazoOrigenBE.IRUTAEMBARQUEID = 0;
                        MessageBox.Show("No se pudo asignar la ruta de embarque " + doctoD.IComentario);
                        return false;
                    }
                }
                
                
            }

            return true;
        }
    }
}
