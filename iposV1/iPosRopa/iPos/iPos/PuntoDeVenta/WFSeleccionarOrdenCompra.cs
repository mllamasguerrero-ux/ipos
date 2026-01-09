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
    public partial class WFSeleccionarOrdenCompra : Form
    {
        long idDocto;
        public string ordenCompra = null;
        public WFSeleccionarOrdenCompra(long idDocto)
        {
            InitializeComponent();
            this.idDocto = idDocto;
        }

        private void btnGuardarOrdenCompra_Click(object sender, EventArgs e)
        {
            if(!txtOrdenCompra.Text.Equals("") && !txtOrdenCompra.Text.Equals(null))
            {

                ordenCompra = txtOrdenCompra.Text;

                if (this.idDocto > 0)
                {
                    CDOCTOD daoDocto = new CDOCTOD();
                    CDOCTOBE docto = new CDOCTOBE();
                    docto.IID = this.idDocto;
                    docto.IORDENCOMPRA = txtOrdenCompra.Text;
                    if (!daoDocto.CAMBIARORDENCOMPRA(docto, null))
                    {
                        MessageBox.Show("Algo salio mal, no se pudo agregar la orden de compra!");
                        return ;
                    }
                }

                this.Close();
            }
        }
    }
}
