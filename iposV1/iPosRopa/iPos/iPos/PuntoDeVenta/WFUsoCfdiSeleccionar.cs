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

namespace iPos.PuntoDeVenta
{
    public partial class WFUsoCfdiSeleccionar : Form
    {

        public long m_cfdiSeleccionado = 0;
        long m_doctoId = 0;
        CDOCTOBE m_doctoBE ;
        public WFUsoCfdiSeleccionar()
        {
            InitializeComponent();
            m_doctoBE = new CDOCTOBE();
        }

        public WFUsoCfdiSeleccionar(long doctoId): this()
        {
            m_doctoBE.IID = doctoId;
        }

         private void BTPaymentSave_Click(object sender, EventArgs e)
        {
            if (this.USOCFDITextBox.SelectedIndex >= 0)
            {
                m_doctoBE.ISAT_USOCFDIID = long.Parse(this.USOCFDITextBox.SelectedValue.ToString());
                CDOCTOD doctoDCFDI = new CDOCTOD();
                if (!doctoDCFDI.CambiarSAT_USOCFDIIDD(m_doctoBE, null))
                {
                    MessageBox.Show("Error!: No se pudo cambiar el Uso CFDI en el Docto!");
                    return;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Debes asignar un Uso CFDI para poder facturar!");
                this.USOCFDITextBox.Focus();
                return;
            }
        }

        private void WFUsoCfdiSeleccionar_Load(object sender, EventArgs e)
        {
            USOCFDITextBox.llenarDatos();
        }
    }
}
