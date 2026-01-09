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
    public partial class WFSelectOtrosTransByFolio : IposForm
    {

        public CDOCTOBE m_selectedDocto = null;
        public long m_tipoDoctoId = DBValues._DOCTO_TIPO_OTRASENTRADAS;
        public WFSelectOtrosTransByFolio()
        {
            InitializeComponent();
        }

        public WFSelectOtrosTransByFolio(long tipoDoctoId) :this()
        {
            m_tipoDoctoId = tipoDoctoId;
        }

        private void WFSelectOtrosTransByFolio_Load(object sender, EventArgs e)
        {
            TBFolio.Focus();

        }

        private void BTSeleccionar_Click(object sender, EventArgs e)
        {
            switch (m_tipoDoctoId)
            {
                case DBValues._DOCTO_TIPO_OTRASENTRADAS:
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_OTRASENTRADAS);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);

                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        } 

                    }
                    break;


                case DBValues._DOCTO_TIPO_OTRASSALIDAS:
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_OTRASSALIDAS);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);

                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;





                    

                default: break;
            }
        }

        private void BTReImprimir_Click(object sender, EventArgs e)
        {
            BuscarFolio();

        }

        private void BuscarFolio()
        {
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            //long lPrintOption = 0;

            try
            {

                doctoBE.IFOLIO = int.Parse(this.TBFolio.Text.ToString());
                doctoBE.ITIPODOCTOID = m_tipoDoctoId;
                

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
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TBFolio_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                BuscarFolio();
            }
        }
    }
}
