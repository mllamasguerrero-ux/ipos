using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFDialogInvCajaPza : IposForm
    {

        public decimal dCajas = 0; 
        public decimal dBotellas = 0;
        public decimal dCantidadTotalFinal = 0;
        public bool huboCambio = false;


        decimal dCantidadTotalActual = 0;
        decimal dPzasPorCaja = 1;
        bool bManejaAlmacen = true;

        public long lAlmacenId = DBValues._DOCTO_ALMACEN_DEFAULT;
        public WFDialogInvCajaPza()
        {
            InitializeComponent();
        }

        public WFDialogInvCajaPza(decimal cantidadTotalActual, decimal pzasPorCaja, bool manejaAlmacen):this()
        {
            dCantidadTotalActual = cantidadTotalActual;
            dPzasPorCaja = pzasPorCaja;
            dCantidadTotalFinal = cantidadTotalActual;
            bManejaAlmacen = manejaAlmacen;

            if(dPzasPorCaja > 1)
            {

                dCajas = Math.Floor(dCantidadTotalActual / dPzasPorCaja);
                dBotellas = dCantidadTotalActual - (dCajas * dPzasPorCaja);

            }
            else
            {

                dCajas = 0;
                dBotellas = dCantidadTotalActual;
            }

        }

        private void WFDialogInvCajaPza_Load(object sender, EventArgs e)
        {
            ALMACENComboBox.llenarDatos();
            ALMACENComboBox.Visible = this.bManejaAlmacen;
            lblAlmacen.Visible = this.bManejaAlmacen;

            this.TBCajas.Text = dCajas.ToString();
            this.TBCantidad.Text = dBotellas.ToString();

            this.lbPzaCaja.Text = dPzasPorCaja.ToString("N2");
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            dCajas = Decimal.Parse(this.TBCajas.Text.ToString());
            dBotellas = Decimal.Parse(this.TBCantidad.Text.ToString());
            dCantidadTotalFinal = (dCajas * dPzasPorCaja) + dBotellas;

            lAlmacenId = this.bManejaAlmacen ? long.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : DBValues._DOCTO_ALMACEN_DEFAULT;

            if (dCantidadTotalFinal != dCantidadTotalActual)
                huboCambio = true;

            this.Close();

        }

    }
}
