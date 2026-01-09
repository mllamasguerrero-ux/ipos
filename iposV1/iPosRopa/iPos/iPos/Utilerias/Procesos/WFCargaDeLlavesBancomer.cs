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
    public partial class WFCargaDeLlavesBancomer : Form
    {
        public WFCargaDeLlavesBancomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Recuerde que las llaves solo se deben cargar de esta forma la primera ves que se utiliza la terminal!, Desea Continuar?", "Seguro", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (!PagoBancomerHelper.MandarSincronizacion())
                {
                    MessageBox.Show("No se pudo lograr la sincronizacion " + PagoBancomerHelper.strResSync);
                    return;
                }

                if(!PagoBancomerHelper.CargarConfiguracionDePinPad())
                {
                    MessageBox.Show("No se pudo Cargar la Configuración del archivo PinPadConfig.txt! " + PagoBancomerHelper.strResSync);
                    return;
                }

                if(PagoBancomerHelper.CargaLlaves())
                {
                    MessageBox.Show("Listo", "Llaves Cargadas Correctamente");
                }
                else
                {
                    MessageBox.Show("Error", "No se puedieron cargar las llaves: " + PagoBancomerHelper.strResCargaLlaves);
                }


                if (!PagoBancomerHelper.MandarSincronizacion())
                {
                    MessageBox.Show("No se pudo lograr la sincronizacion " + PagoBancomerHelper.strResSync);
                    return;
                }
                
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}
