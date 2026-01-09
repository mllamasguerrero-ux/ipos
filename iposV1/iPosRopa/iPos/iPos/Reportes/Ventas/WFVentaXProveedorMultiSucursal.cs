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

namespace iPos.Reportes.Ventas
{
    public partial class WFVentaXProveedorMultiSucursal : Form
    {
        public WFVentaXProveedorMultiSucursal()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            string p_item = "";
            if (!CBTodas.Checked)
            {
                try
                {
                    p_item = this.ITEMIDTextBox.DbValue.ToString();
                }
                catch
                {
                    MessageBox.Show("Seleccione un registro valido");
                    return;
                }
            }

            CSUCURSALD suc = new CSUCURSALD();
            CSUCURSALBE[] sucs = new CSUCURSALBE[] { };
            string cadena = "";
            string sucFueraReport = "";
            sucs = suc.seleccionarSUCURSALES();
            //initial catalog=C:\IposProject\iPosRopa\iPos\iPos\bin\Debug\sampdata\IPOSDB.fdb;
            //server=localhost;user id=sysdba;password=masterkey
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

            //cade de prueba
            //cadena = @"initial catalog=C:\temporal\bdDF\elsauz.fdb;user id=sysdba;password=masterkeyinitial catalog=C:\temporal\bdDF\eltrece.fdb;user id=sysdba;password=masterkey";
            //cadena = @"initial catalog=C:\iPos\SampData\IPOSDB.fdb;user id=sysdba;password=masterkey";
                
            report1.SetParameterValue("itemclave", p_item);
            report1.SetParameterValue("fechaini", DTPFrom.Value);
            report1.SetParameterValue("fechafin", DTPTo.Value);
            report1.SetParameterValue("totalizado", (bool)CBSumarizado.Checked ? true : false);
            report1.SetParameterValue("conexiones", cadena);

            if (report1.Prepare())
                report1.ShowPrepared();
        }

        private void WFVentaXProveedorMultiSucursal_Load(object sender, EventArgs e)
        {
            report1.Load(FastReportsConfig.getPathForFile("InformeVentasXProveedorMultiSucursal.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFVentaXProveedorMultiSucursal_FormClosing(object sender, FormClosingEventArgs e)
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
