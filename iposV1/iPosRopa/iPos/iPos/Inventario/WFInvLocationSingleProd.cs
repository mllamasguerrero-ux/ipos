using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;

namespace iPos.Inventario
{
    public partial class WFInvLocationSingleProd : Form
    {

        long m_productoId = 0;
        long m_doctoId = 0;

        public WFInvLocationSingleProd()
        {
            InitializeComponent();
        }


        public WFInvLocationSingleProd(long productoId, long doctoId) : this()
        {
            m_productoId = productoId;
            m_doctoId = doctoId;
        }

        private void LlenarDatos()
        {
            try
            {
                this.gET_INVFIS_LISTADETAIL_XLOCPRODTableAdapter.Fill(this.dSInventarioFisico3.GET_INVFIS_LISTADETAIL_XLOCPROD, m_doctoId, m_productoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFInvLocationSingleProd_Load(object sender, EventArgs e)
        {
            CPRODUCTOD prodD = new CPRODUCTOD();
            CPRODUCTOBE prodBE = new CPRODUCTOBE();
            prodBE.IID = m_productoId;
            prodBE = prodD.seleccionarPRODUCTO(prodBE, null);

            if (prodBE != null)
            {
                PRODUCTOCLAVELabel.Text = prodBE.ICLAVE;
                PRODUCTONOMBRELabel.Text = prodBE.INOMBRE;
            }
            LlenarDatos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
