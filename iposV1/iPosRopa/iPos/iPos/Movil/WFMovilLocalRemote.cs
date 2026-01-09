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
using System.Collections;

namespace iPos
{
    public partial class WFMovilLocalRemote : IposForm
    {
        public WFMovilLocalRemote()
        {
            InitializeComponent();
        }
        private bool LlenarDatosDeBase()
        {
            

            try{

                CPARAMETROBE parametroBE = new CPARAMETROBE();
                CPARAMETROD parametroD = new CPARAMETROD();
                parametroBE = parametroD.seleccionarPARAMETROActual(null);

                if (!(bool)parametroBE.isnull["IUSARCONEXIONLOCAL"])
                    this.USARCONEXIONLOCALTextBox.Text = parametroBE.IUSARCONEXIONLOCAL;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();

            if (this.USARCONEXIONLOCALTextBox.SelectedIndex >= 0)
            {
                parametroBE.IUSARCONEXIONLOCAL = this.USARCONEXIONLOCALTextBox.Text;
            }
            else
            {
                parametroBE.IUSARCONEXIONLOCAL = "N";
            }

            try
            {
                bool bResult = parametroD.CambiarUSARCONEXIONLOCALPARAMETROD(parametroBE, parametroBE, null);

                if(!bResult)
                {
                    MessageBox.Show(parametroD.IComentario);
                    return;
                }

                CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL = parametroBE.IUSARCONEXIONLOCAL;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void WFMovilLocalRemote_Load(object sender, EventArgs e)
        {
            LlenarDatosDeBase();
        }
    }
}
