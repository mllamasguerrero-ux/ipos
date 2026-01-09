using iPosBusinessEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Utilerias.Procesos
{
    public partial class WFObtenerPuntosBancomer : Form
    {
        bool m_prepararPinPad = true;
        public WFObtenerPuntosBancomer(bool prepararPinPad)
        {
            InitializeComponent();
            m_prepararPinPad = prepararPinPad;

            
        }

        private void WFObtenerPuntosBancomer_Load(object sender, EventArgs e)
        {
            ObtenerPuntos(m_prepararPinPad);
        }

        public bool ObtenerPuntos(bool preparaPinPad)
        {
            CBANCOMERPARAMBE bancomerParam = new CBANCOMERPARAMBE();
            bool retorno = PagoBancomerHelper.CalcularPuntos(preparaPinPad, ref bancomerParam, null);

            if(retorno)
            {

                if (bancomerParam.Pts != null && bancomerParam.Pts.IPUNTOSSALDODISPONIBLE != null && bancomerParam.Pts.IPUNTOSSALDODISPONIBLE != "")
                    txtPuntosDisponibles.Text = PagoBancomerHelper.formatoPtos(bancomerParam.Pts.IPUNTOSSALDODISPONIBLE);
                else
                    txtPuntosDisponibles.Text = "";


                if (bancomerParam.Pts != null && bancomerParam.Pts.IPESOSSALDODISPONIBLE != null && bancomerParam.Pts.IPESOSSALDODISPONIBLE != "")
                    txtPuntosPesos.Text = PagoBancomerHelper.formatoPesos(bancomerParam.Pts.IPESOSSALDODISPONIBLE);
                else
                    txtPuntosPesos.Text = "";

                PagoBancomerHelper.ImprimirVoucher(bancomerParam.IID, true);

            }
            else 
            {
                MessageBox.Show("Error : " + PagoBancomerHelper.strResTransaccion);
            }



            return retorno;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObtenerPuntos(m_prepararPinPad);
        }
    }
}
