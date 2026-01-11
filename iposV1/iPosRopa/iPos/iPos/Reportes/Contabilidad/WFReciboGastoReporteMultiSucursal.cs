using iPosBusinessEntity;
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
    public partial class WFReciboGastoReporteMultiSucursal : Form
    {
        public WFReciboGastoReporteMultiSucursal()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            RecargarReport();
            string p_suc = "";
            string p_gasto = "T";
            //String p_cajeroNombre = "Todos";
            //String p_gastoNombre = "Todos";

            if (!CBTodas.Checked)
            {
                try
                {
                    p_suc = this.ITEMIDTextBox.DbValue.ToString();
                    //p_cajeroNombre = this.ITEMLabel.Text;
                }
                catch
                {
                    MessageBox.Show("Seleccione una sucursal valida");
                    return;
                }
            }


            if (!CBTodosGastos.Checked)
            {
                try
                {
                    p_gasto = this.GASTOIDTextBox.DbValue.ToString();
                   // p_gastoNombre = this.GASTOLabel.Text;
                }
                catch
                {
                    MessageBox.Show("Seleccione un tipo de gasto valido");
                    return;
                }
            }

            CSUCURSALD suc = new CSUCURSALD();
            CSUCURSALBE[] sucs = new CSUCURSALBE[] { };
            string cadena = "";
            string sucFueraReport = "";
            sucs = suc.seleccionarSUCURSALES();
            for (int i = 0; i < sucs.Length; i++)
            {
                if (sucs[i].INOMBRERESPALDOBD != null && sucs[i].INOMBRERESPALDOBD != "")
                {
                    if (sucs[i].IRUTARESPALDORED != null && sucs[i].IRUTARESPALDORED != "")
                    {
                        cadena += "initial catalog=" + sucs[i].IRUTARESPALDORED + @"\" + sucs[i].INOMBRERESPALDOBD + ".fdb;" +
                        "server=" + CurrentUserID.CurrentCompania.IEM_SERVER + ";user id=sysdba;password=masterkey";
                    }
                    else
                    {
                        cadena += "initial catalog=" + sucs[i].IRUTARESPALDODESTINO + @"\" + sucs[i].INOMBRERESPALDOBD + ".fdb;" +
                        "server=" + CurrentUserID.CurrentCompania.IEM_SERVER + ";user id=sysdba;password=masterkey";
                    }
                }
                else
                {
                    sucFueraReport += sucs[i].INOMBRE + "\n";
                }

            }


            report1.SetParameterValue("succlave", p_suc);
            report1.SetParameterValue("gastoclave", p_gasto);
           // report1.SetParameterValue("cajeronombre", p_cajeroNombre);
           // report1.SetParameterValue("gastonombre", p_gastoNombre);
            report1.SetParameterValue("fechaini", DTPFrom.Value);
            report1.SetParameterValue("fechafin", DTPTo.Value);
            report1.SetParameterValue("totalizado", (bool)CBTotalizado.Checked ? true : false);
            report1.SetParameterValue("conexiones", cadena);

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("InformeGastosSumarizadoMultiSucursal.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WFReciboGastoReporteMultiSucursal_FormClosing(object sender, FormClosingEventArgs e)
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
