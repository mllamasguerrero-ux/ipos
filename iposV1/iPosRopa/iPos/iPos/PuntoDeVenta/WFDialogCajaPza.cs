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
    public partial class WFDialogCajaPza : IposForm
    {

        public decimal dCajas = 0; 
        public decimal dBotellas = 0;
        public decimal dCantidadTotalFinal = 0;
        public bool huboCambio = false;


        decimal dCantidadTotalActual = 0;
        decimal dPzasPorCaja = 1;
        public WFDialogCajaPza()
        {
            InitializeComponent();
        }

        public WFDialogCajaPza(decimal cantidadTotalActual, decimal pzasPorCaja):this()
        {
            dCantidadTotalActual = cantidadTotalActual;
            dPzasPorCaja = pzasPorCaja;
            dCantidadTotalFinal = cantidadTotalActual;

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

        private void WFDialogCajaPza_Load(object sender, EventArgs e)
        {
            this.TBCajas.Text = dCajas.ToString();
            this.TBCantidad.Text = dBotellas.ToString();

            this.lbPzaCaja.Text = dPzasPorCaja.ToString("N2");
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            dCajas = Decimal.Parse(this.TBCajas.Text.ToString());
            dBotellas = Decimal.Parse(this.TBCantidad.Text.ToString());
            dCantidadTotalFinal = (dCajas * dPzasPorCaja) + dBotellas;

            if(dCantidadTotalFinal != dCantidadTotalActual)
                huboCambio = true;

            this.Close();

        }

    }
}
