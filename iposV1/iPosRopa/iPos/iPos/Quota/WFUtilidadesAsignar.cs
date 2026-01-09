using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;

namespace iPos
{
    public partial class WFUtilidadesAsignar : IposForm
    {
        public WFUtilidadesAsignar()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            PERSONAIDTextBox.Text = "";
            VENDEDORIDTextBox.Text = "";
            DTPFrom.Value = DateTime.Today;
            DTPTo.Value = DateTime.Today;

        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Esta seguro de realizar esta acción? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            long clienteId = 0, vendedorId = 0;
            
                try
                {
                    clienteId = Int64.Parse(this.PERSONAIDTextBox.DbValue.ToString());
                    
                }
                catch
                {
                    MessageBox.Show("Seleccione un cliente valido");
                    return;
                }

            
                try
                {
                    vendedorId = Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
                    
                }
                catch
                {
                    MessageBox.Show("Seleccione un vendedor valido");
                    return;
                }

            CQUOTAD quotaD = new CQUOTAD();
            if (!quotaD.CambiarAsignacionDelClienteXFecha(clienteId, vendedorId, DTPFrom.Value, DTPTo.Value, null))
            {

                MessageBox.Show("Se han reasignado los registros");
                Limpiar();
                return;
            }

        }

        private void PERSONAIDTextBox_Validated(object sender, EventArgs e)
        {
            long clienteId = 0;

            if (this.PERSONAIDTextBox.Text.Trim().Length == 0)
                return;

            try
            {
                clienteId = Int64.Parse(this.PERSONAIDTextBox.DbValue.ToString());

            }
            catch
            {
                return;
            }

            if (clienteId == 0)
                return;

            CPERSONAD clienteD = new CPERSONAD();
            CPERSONABE clienteBE = new CPERSONABE();

            clienteBE.IID = clienteId;
            clienteBE = clienteD.seleccionarPERSONA(clienteBE,null);

            if (clienteBE != null && !(bool)clienteBE.isnull["IVENDEDORID"])
            {
                string strBuffer = "";
                this.VENDEDORIDTextBox.DbValue = clienteBE.IVENDEDORID.ToString();
                this.VENDEDORIDTextBox.MostrarErrores = false;
                this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.VENDEDORIDTextBox.MostrarErrores = true;
            }

        }
    }
}
