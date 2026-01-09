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
    public partial class WFCambiarFechaPendMax : IposForm
    {
        public CDOCTOBE m_DoctoBE = new CDOCTOBE();
        public bool bCambioFechaPendMax = false;
        public WFCambiarFechaPendMax()
        {
            InitializeComponent();
        }


        public WFCambiarFechaPendMax(CDOCTOBE doctoBE) : this()
        {
            m_DoctoBE = doctoBE;
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {

            DateTime newFechaPendMax = dtpFechaPendMax.Value;
            DateTime maxFecha = m_DoctoBE.IFECHA.AddDays(CurrentUserID.CurrentParameters.IPENDMAXDIAS);

            if ( maxFecha < newFechaPendMax)
            {
                MessageBox.Show("La fecha no puede ser mayor a " + maxFecha.ToString("dd/MM/yyyy"));
                return;
            }


            m_DoctoBE.IPENDMAXFECHA = dtpFechaPendMax.Value;

            CDOCTOD doctoD = new CDOCTOD();
            if( !doctoD.CambiarPENDMAXFECHA(m_DoctoBE, null))
            {
                MessageBox.Show(doctoD.IComentario);
            }
            else
            {
                bCambioFechaPendMax = true;
                this.Close();
            }
        }

        private void WFCambiarFechaPendMax_Load(object sender, EventArgs e)
        {

            lbDiasMax.Text = CurrentUserID.CurrentParameters.IPENDMAXDIAS.ToString();
            
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = m_DoctoBE.IID;

            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);


            if (doctoBE != null && doctoBE.IFECHA != null)
            {
                m_DoctoBE = doctoBE;

                lbFechaDocumento.Text = m_DoctoBE != null && m_DoctoBE.IFECHA != null ? m_DoctoBE.IFECHA.ToString("dd/MM/yyyy") : "";
                dtpFechaPendMax.Value = m_DoctoBE != null && m_DoctoBE.IPENDMAXFECHA != null ? m_DoctoBE.IPENDMAXFECHA : DateTime.Today;
            }
            else
            {
                this.Close();
            }
        }
    }
}
