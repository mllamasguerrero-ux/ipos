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

namespace iPos
{
    public partial class WFSurtidoVentasMovilesDetalle : IposForm
    {
        long m_lDoctoId = 0; 
        int m_folio = 0;
        string m_nombrecliente = "";
        DateTime m_fecha = DateTime.MinValue;
        public WFSurtidoVentasMovilesDetalle()
        {
            InitializeComponent();
        }
        public WFSurtidoVentasMovilesDetalle(long doctoId, int folio, string nombreCliente, DateTime fecha) : this()
        {
            m_lDoctoId = doctoId;
            m_folio = folio;
            m_nombrecliente = nombreCliente;
            m_fecha = fecha;
        }

        private void LlenarGrid()
        {
            try
            {
                this.surtidoMovilDetalleTableAdapter.Fill(this.dSMovil3.SurtidoMovilDetalle, (int)m_lDoctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFSurtidoVentasMovilesDetalle_Load(object sender, EventArgs e)
        {

            lblFolio.Text = m_folio.ToString();
            lblCliente.Text = m_nombrecliente;
            lblFecha.Text = m_fecha.ToString("dd/MM/yyyy");

            LlenarGrid();
        }

        private void btnSeleccionarVenta_Click(object sender, EventArgs e)
        {

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = m_lDoctoId;
            doctoBE.IPROCESOSURTIDO = "S";


            if(!doctoD.CambiarProcesoSurtidoDOCTOD(doctoBE, null))
            {
                MessageBox.Show("No se pudo cambiar el flag de surtido");
                return;
            }
            else
            {
                PosPrinter.ImprimirTicket(m_lDoctoId);
                CPARAMETROD parametroD = new CPARAMETROD();
                parametroD.MOVILPROCESOSURTIDOUPDATE(null);
                CurrentUserID.CurrentParameters = parametroD.seleccionarPARAMETROActual(null);

            }


        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PosPrinter.ImprimirTicket(m_lDoctoId);
        }
    }
}
