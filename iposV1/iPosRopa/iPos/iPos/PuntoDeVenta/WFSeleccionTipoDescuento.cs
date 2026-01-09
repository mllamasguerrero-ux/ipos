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

namespace iPos
{
    public partial class WFSeleccionTipoDescuento : Form
    {
        public long lDescuentoSeleccionado = -1;
        public decimal dPorcentajeDescuentoSeleccionado = 0;

        public WFSeleccionTipoDescuento()
        {
            InitializeComponent();
        }

        private void WFSeleccionTipoDescuento_Load(object sender, EventArgs e)
        {
            if(CurrentUserID.CurrentParameters.IDESCUENTOTIPO1TEXTO != null && CurrentUserID.CurrentParameters.IDESCUENTOTIPO1TEXTO.Trim().Length > 0)
            {
                CBTipoDescuento.Items.Add("1 - " + CurrentUserID.CurrentParameters.IDESCUENTOTIPO1TEXTO.Trim());
            }
            if (CurrentUserID.CurrentParameters.IDESCUENTOTIPO2TEXTO != null && CurrentUserID.CurrentParameters.IDESCUENTOTIPO2TEXTO.Trim().Length > 0)
            {
                CBTipoDescuento.Items.Add("2 - " + CurrentUserID.CurrentParameters.IDESCUENTOTIPO2TEXTO.Trim());
            }
            if (CurrentUserID.CurrentParameters.IDESCUENTOTIPO3TEXTO != null && CurrentUserID.CurrentParameters.IDESCUENTOTIPO3TEXTO.Trim().Length > 0)
            {
                CBTipoDescuento.Items.Add("3 - " + CurrentUserID.CurrentParameters.IDESCUENTOTIPO3TEXTO.Trim());
            }
            if (CurrentUserID.CurrentParameters.IDESCUENTOTIPO4TEXTO != null && CurrentUserID.CurrentParameters.IDESCUENTOTIPO4TEXTO.Trim().Length > 0)
            {
                CBTipoDescuento.Items.Add("4 - " + CurrentUserID.CurrentParameters.IDESCUENTOTIPO4TEXTO.Trim());
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            string[] strArr = new string[]  { " - " };
            string[] strBuffer = CBTipoDescuento.SelectedItem.ToString().Split(strArr, StringSplitOptions.None);

            if(strBuffer != null && strBuffer.Length > 0)
            {
                try
                {
                    long lBuffer = long.Parse(strBuffer[0]);
                    lDescuentoSeleccionado = lBuffer + 100;


                    switch (lDescuentoSeleccionado)
                    {
                        case 101: dPorcentajeDescuentoSeleccionado = CurrentUserID.CurrentParameters.IDESCUENTOTIPO1PORC; break;
                        case 102: dPorcentajeDescuentoSeleccionado = CurrentUserID.CurrentParameters.IDESCUENTOTIPO2PORC; break;
                        case 103: dPorcentajeDescuentoSeleccionado = CurrentUserID.CurrentParameters.IDESCUENTOTIPO3PORC; break;
                        case 104: dPorcentajeDescuentoSeleccionado = CurrentUserID.CurrentParameters.IDESCUENTOTIPO4PORC; break;
                        default: dPorcentajeDescuentoSeleccionado = 0;  break;


                    }

                    this.Close();

                }
                catch(Exception ex)
                {

                }
            }

        }

        private void WFSeleccionTipoDescuento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(CBTipoDescuento.SelectedIndex == -1)
            {
                MessageBox.Show("debe seleccionar un tipo de descuento");
                e.Cancel = true;
            }
        }
    }
}
