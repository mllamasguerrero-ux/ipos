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
    public partial class WFCambioVenceTrans : IposForm
    {

        public CDOCTOBE m_selectedDocto = null;
        public WFCambioVenceTrans()
        {
            InitializeComponent();
        }

        private void WFCambioVenceTrans_Load(object sender, EventArgs e)
        {
            TBFolio.Focus();

        }

        private void BTSeleccionar_Click(object sender, EventArgs e)
        {
                        WFLookUpTransacciones wfl_ = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_VENTA);
                        wfl_.ShowDialog();

                        DataRow dr = wfl_.m_rtnDataRow;

                        wfl_.Dispose();
                        GC.SuppressFinalize(wfl_);

                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                            int doctoId = int.Parse(dr[0].ToString());
                            CDOCTOD doctoD = new CDOCTOD();
                            CDOCTOBE doctoBE = new CDOCTOBE();
                            doctoBE.IID = doctoId;
                            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                            if (doctoBE != null)
                            {
                                m_selectedDocto = doctoBE;
                                MostrarDatosDocto();
                            }


                        } 

        }

        private void MostrarDatosDocto()
        {

            diasPlazoTextBox.Text = m_selectedDocto.IPLAZO.ToString();
            lbSaldo.Text = m_selectedDocto.ISALDO.ToString();
            lbTotal.Text = m_selectedDocto.ITOTAL.ToString();
            this.dtpFechaVence.Value = m_selectedDocto.IVENCE;
            this.dtpFecha.Value = m_selectedDocto.IFECHA;
        }

        private void ObtenerDatosCapturados()
        {
            try
            {
                m_selectedDocto.IPLAZO = short.Parse(diasPlazoTextBox.Text);
            }
            catch
            {

            }
            m_selectedDocto.IVENCE = this.dtpFechaVence.Value;
        }


        private void BuscarFolio()
        {
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();

            try
            {

                doctoBE.IFOLIO = int.Parse(this.TBFolio.Text.ToString());
                doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;

            }
            catch
            {
                return;
            }

            doctoBE = doctoD.SeleccionarXTIPOYFOLIO(doctoBE, null);

            if (doctoBE == null)
            {
                MessageBox.Show("Folio no encontrado");
                return;
            }

            try
            {
                m_selectedDocto = doctoBE;
                MostrarDatosDocto();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void TBFolio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                BuscarFolio();
            }
        }

        private void TBFolio_Leave(object sender, EventArgs e)
        {

        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            ObtenerDatosCapturados();
            CDOCTOD doctoD = new CDOCTOD();
            if(doctoD.CAMBIARVENCIMIENTO(this.m_selectedDocto, null))
            {
                MessageBox.Show("Se ha cambiado la fecha de vencimiento");
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error : " + doctoD.IComentario);
            }
        }

        private void diasPlazoTextBox_Validated(object sender, EventArgs e)
        {

            int iDiasPlazo = 0;
            try{
                iDiasPlazo = int.Parse(diasPlazoTextBox.Text);
            }
            catch
            {

            }

            this.dtpFechaVence.Value = m_selectedDocto.IFECHA.AddDays(iDiasPlazo);
        }

        private void TBFolio_Validated(object sender, EventArgs e)
        {

                BuscarFolio();
        }
    }
}
