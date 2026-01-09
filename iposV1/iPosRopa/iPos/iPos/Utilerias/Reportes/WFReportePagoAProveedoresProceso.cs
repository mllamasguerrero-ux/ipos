using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Utilerias
{
    public partial class WFReportePagoAProveedoresProceso : Form
    {
        public WFReportePagoAProveedoresProceso()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            Int64? p_proveedor = 0;
            Int64? p_cliente = 0;
            bool clienteSeleccionado = CheckBoxSelectCliente.Checked ? true : false;
            bool proveedorSeleccionado = CheckBoxSelectProveedor.Checked ? true : false;
            Int64 tipoDocto = 0;
            string proveedorNombre = "";
            string clienteNombre = "";

            if(proveedorSeleccionado)
            {
                if (!CheckBoxTodosProveedores.Checked)
                {
                    try
                    {
                        p_proveedor = Int64.Parse(this.TextBoxProveedor.DbValue.ToString());
                        proveedorNombre = TextBoxProveedor.Text;
                    }
                    catch
                    {
                        MessageBox.Show("Seleccione un proveedor valido");
                        return;
                    }
                }
                else
                {
                    proveedorNombre = "TODOS";
                }

                tipoDocto = -11;
            }

            if(clienteSeleccionado)
            {
                if (!CheckBoxTodosClientes.Checked)
                {
                    try
                    {
                        p_cliente = Int64.Parse(this.TextBoxCliente.DbValue.ToString());
                        clienteNombre = TextBoxCliente.Text;
                    }
                    catch
                    {
                        MessageBox.Show("Seleccione un cliente valido");
                        return;
                    }
                }
                else
                {
                    clienteNombre = "TODOS";
                }

                tipoDocto = -21;
            }

            if (proveedorSeleccionado && clienteSeleccionado) 
            {
                tipoDocto = 0;
            }

            if(clienteSeleccionado || proveedorSeleccionado)
            {
                report1.SetParameterValue("proveedorid", p_proveedor);
                report1.SetParameterValue("clienteid", p_cliente);
                report1.SetParameterValue("fechaini", DTPFrom.Value);
                report1.SetParameterValue("fechafin", DTPTo.Value);
                report1.SetParameterValue("tipodoctoid", tipoDocto);
                report1.SetParameterValue("proveedor", proveedorNombre);
                report1.SetParameterValue("cliente", clienteNombre);


                if (report1.Prepare())
                    report1.ShowPrepared();
            }
            else
            {
                MessageBox.Show("Seleccione proveedor, cliente o ambos");
            }
        }

        private void WFReportePagoAProveedoresProceso_Load(object sender, EventArgs e)
        {

            report1.Load(FastReportsConfig.getPathForFile("PagoPorProceso.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFReportePagoAProveedoresProceso_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                report1.Delete();
                report1.Dispose();
            }
            catch
            {
            }
        }
    }
}
