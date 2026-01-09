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

namespace iPos.Contabilidad
{
    public partial class WFCuentasPVC : Form
    {
        CCUENTASPVCBE cuentasPvc = new CCUENTASPVCBE();
        CCUENTASPVCD daoCuentasPvc = new CCUENTASPVCD();

        public WFCuentasPVC()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cuentasPvc = new CCUENTASPVCBE();
            daoCuentasPvc = new CCUENTASPVCD();

            cuentasPvc.IID = 1;
            if(!txtCuentaSumaVentas.Text.Equals("") && !txtCuentaSumaVentas.Text.Equals(null))
            {
                cuentasPvc.ICUENTASUMAVENTAS = txtCuentaSumaVentas.Text.Trim();
            }
            else
            {
                MessageBox.Show("Ingrese la cuenta de Suma en Ventas");
                txtCuentaSumaVentas.Focus();
                return;
            }
            if (!txtCuentaSumaNotasCredito.Text.Equals("") && !txtCuentaSumaNotasCredito.Text.Equals(null))
            {
                cuentasPvc.ICUENTASUMNOTASCREDITO = txtCuentaSumaNotasCredito.Text.Trim();
            }
            else
            {
                MessageBox.Show("Ingrese la cuenta de Suma en Notas de Crédito");
                txtCuentaSumaNotasCredito.Focus();
                return;
            }
            if (!txtCuentaImpuestos.Text.Equals("") && !txtCuentaImpuestos.Text.Equals(null))
            {
                cuentasPvc.ICUENTAIMPUESTOS = txtCuentaImpuestos.Text.Trim();
            }
            else
            {
                MessageBox.Show("Ingrese la cuenta de impuestos");
                txtCuentaImpuestos.Focus();
                return;
            }

            if(daoCuentasPvc.ExisteCUENTASPVC(cuentasPvc, null) == 1)
            {
                daoCuentasPvc.CambiarCUENTASPVCD(cuentasPvc, cuentasPvc, null);
                MessageBox.Show("Los datos han sido cambiados con éxito!");
                this.Close();
            }
            else if(daoCuentasPvc.ExisteCUENTASPVC(cuentasPvc, null) == 0)
            {
                daoCuentasPvc.AgregarCUENTASPVCD(cuentasPvc, null);
                MessageBox.Show("Los datos han sido insertados con éxito!");
                this.Close();
            }
        }

        private void WFCuentasPVC_Load(object sender, EventArgs e)
        {
            cuentasPvc.IID = 1;
            cuentasPvc = daoCuentasPvc.seleccionarCUENTASPVC(cuentasPvc, null);

            if(cuentasPvc == null)
            {
                return;
            }

            if (!cuentasPvc.ICUENTASUMAVENTAS.Equals("") && !cuentasPvc.ICUENTASUMAVENTAS.Equals(null))
            {
                txtCuentaSumaVentas.Text = cuentasPvc.ICUENTASUMAVENTAS;
            }

            if (!cuentasPvc.ICUENTASUMNOTASCREDITO.Equals("") && !cuentasPvc.ICUENTASUMNOTASCREDITO.Equals(null))
            {
                txtCuentaSumaNotasCredito.Text = cuentasPvc.ICUENTASUMNOTASCREDITO;
            }

            if (!cuentasPvc.ICUENTAIMPUESTOS.Equals("") && !cuentasPvc.ICUENTAIMPUESTOS.Equals(null))
            {
                txtCuentaImpuestos.Text = cuentasPvc.ICUENTAIMPUESTOS;
            }
        }
    }
}
