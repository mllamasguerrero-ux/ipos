using iPos;
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

namespace iPosReporting
{
    public partial class DRptDetComprasMultiSucursal : Form
    {
        public bool m_ieps;
        public DRptDetComprasMultiSucursal()
        {
            InitializeComponent();
            m_ieps = false;
        }

        public DRptDetComprasMultiSucursal(bool ieps)
            : this()
        {
            m_ieps = ieps;

        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            LlenarDataSource();
        }

        private void DRptDetComprasMultiSucursal_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSReportIpos.ALMACEN' table. You can move, or remove it, as needed.
            this.aLMACENTableAdapter.Fill(this.dSReportIpos.ALMACEN);



            CBFactRem.SelectedText = "TODOS";
        }

        private void LlenarDataSource()
        {

            string strTipoFactRem = "T";
            string strDescTipoFactRem = "Todos";
            int subtipo = 0;

            switch (CBFactRem.SelectedIndex)
            {
                case 0: strTipoFactRem = "T"; strDescTipoFactRem = "Todos"; break;
                case 1: strTipoFactRem = "R"; strDescTipoFactRem = "Remision"; break;
                case 2: strTipoFactRem = "F"; strDescTipoFactRem = "Factura"; break;
                default: strTipoFactRem = "T"; strDescTipoFactRem = "Todos"; break;

            }


            switch (cmbSubtipo.SelectedIndex)
            {
                case 0: subtipo = 0; break;
                case 1: subtipo = -1; break;
                case 2: subtipo = 0; break;
                case 3: subtipo = 16; break;
                case 4: subtipo = 23; break;
                default: subtipo = 0; break;

            }



                RecargarReport();

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

                // cadena de pruebas
                report1.SetParameterValue("TIPODOCTOID", cmbSubtipo.SelectedIndex == 2 ? 41 : (cmbSubtipo.SelectedIndex == 0 ? -11 : 11));
                report1.SetParameterValue("FECHAINI", DTPFrom.Value);
                report1.SetParameterValue("FECHAFIN", DTPTo.Value);
                report1.SetParameterValue("TIPODOCTONOMBRE", "Compras");
                report1.SetParameterValue("VENDEDORID", 0);
                report1.SetParameterValue("VENDEDORNOMBRE", "Todos");

                report1.SetParameterValue("ALMACENID", (CBSoloAlmacen.Checked) ? Decimal.Parse((comboBoxAlmacen.SelectedValue.ToString())) : 0);
                report1.SetParameterValue("NOMBREALMACEN", (CBSoloAlmacen.Checked) ? this.comboBoxAlmacen.SelectedText : "Todos");
                report1.SetParameterValue("REMISIONFACTURA", strTipoFactRem);
                report1.SetParameterValue("REMISIONFACTURADESC", strDescTipoFactRem);
                report1.SetParameterValue("SUBTIPO", subtipo);
                report1.SetParameterValue("conexiones", cadena);


                if (report1.Prepare())
                    report1.ShowPrepared();
            

        }

        private void RecargarReport()
        {

            report1.Load(FastReportsConfigReport.getPathForFile("InformeDiarioComprasIEPSDETALLEEXPMultiSucursal.frx", FastReportsConfigTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", ConexionesBD.ConexionBD.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", ConexionesBD.ConexionBD.CurrentUser.IID);
        }
    }
}
