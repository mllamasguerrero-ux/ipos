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

namespace iPos.Reportes.Ventas
{
    public partial class WFDiarioGeneral1 : Form
    {

        private FastReport.Report report1;

        public WFDiarioGeneral1()
        {
            InitializeComponent();
            this.report1 = new FastReport.Report();
        }

        private void btnVentasConIeps_Click(object sender, EventArgs e)
        {

            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            configVentasConIeps(ref strReporte, ref dictionary);

            MostrarReporte(strReporte, dictionary);
        }

        private void btnVentasTarjeta_Click(object sender, EventArgs e)
        {

            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();


            configVentasTarjeta(ref strReporte, ref dictionary);

            MostrarReporte(strReporte, dictionary);
        }

        private void btnNotasCredito_Click(object sender, EventArgs e)
        {

            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            configNotasCredito(ref strReporte, ref dictionary);

            MostrarReporte(strReporte, dictionary);
        }

        private void btnVentasCanceladas_Click(object sender, EventArgs e)
        {

            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            configVentasCanceladas(ref strReporte, ref dictionary);

            MostrarReporte(strReporte, dictionary);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {

            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();


            configCompras(ref strReporte, ref dictionary);

            MostrarReporte(strReporte, dictionary);
        }

        private void btnOtrasCompras_Click(object sender, EventArgs e)
        {

            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();


            configOtrasCompras(ref strReporte, ref dictionary);

            MostrarReporte(strReporte, dictionary);
        }

        private void btnOtrasSalidas_Click(object sender, EventArgs e)
        {

            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            configOtrasSalidas(ref strReporte, ref dictionary);

            MostrarReporte(strReporte, dictionary);
        }

        private void btnVentasClasif_Click(object sender, EventArgs e)
        {

            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();


            configVentasClasif(ref strReporte, ref dictionary);


            MostrarReporte(strReporte, dictionary);
        }

        private void btnEnsambleKits_Click(object sender, EventArgs e)
        {

            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            configEnsambleKits(ref strReporte, ref dictionary);

            MostrarReporte(strReporte, dictionary);
        }

        private void btnClientesModif_Click(object sender, EventArgs e)
        {

            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            configClientesModif(ref strReporte, ref dictionary);

            MostrarReporte(strReporte, dictionary);
        }

        private void btnPreciosCambiados_Click(object sender, EventArgs e)
        {

            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            configPreciosCambiados(ref strReporte, ref dictionary);
            MostrarReporte(strReporte, dictionary);
        }

        private void MostrarReporte(string strReporte, Dictionary<string, object> dictionary)
        {

            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }











        private void configVentasConIeps(ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();

            dictionary.Add("FECHAINI", dateTimePicker1.Value);
            dictionary.Add("FECHAFIN", dateTimePicker1.Value);
            dictionary.Add("TIPODOCTOID", DBValues._DOCTO_TIPO_VENTA);
            dictionary.Add("TIPODOCTONOMBRE", "VENTAS");
            dictionary.Add("VENDEDORID", 0);
            dictionary.Add("VENDEDORNOMBRE", "TODOS");
            dictionary.Add("ALMACENID", 0);
            dictionary.Add("NOMBREALMACEN", "TODOS");
            dictionary.Add("REMISIONFACTURA", "T");
            dictionary.Add("REMISIONFACTURADESC", "TODOS");



            strReporte = "DiarioEspecial1\\InformeDiarioVentasIEPSEXP.frx";
            
        }

        private void configVentasTarjeta(ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();


            dictionary.Add("FECHAINI", dateTimePicker1.Value);
            dictionary.Add("FECHAFIN", dateTimePicker1.Value);
            dictionary.Add("TIPODOCTOID", DBValues._DOCTO_TIPO_VENTA);
            dictionary.Add("TIPODOCTONOMBRE", "VENTAS CON TARJETA");
            dictionary.Add("VENDEDORID", 0);
            dictionary.Add("VENDEDORNOMBRE", "TODOS");
            dictionary.Add("ALMACENID", 0);
            dictionary.Add("NOMBREALMACEN", "TODOS");
            dictionary.Add("REMISIONFACTURA", "T");
            dictionary.Add("REMISIONFACTURADESC", "TODOS");

            strReporte = "DiarioEspecial1\\InformeDiarioVentasTarjetaIEPSEXP.frx";
            
        }

        private void configNotasCredito(ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();
            dictionary.Add("fechaini", dateTimePicker1.Value);
            dictionary.Add("fechafin", dateTimePicker1.Value);
            dictionary.Add("almacenid", 0);

            strReporte = "DiarioEspecial1\\InformeNotasDeCreditoSum.frx";
            
        }

        private void configNotasCargo(ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();
            dictionary.Add("fechaini", dateTimePicker1.Value);
            dictionary.Add("fechafin", dateTimePicker1.Value);
            dictionary.Add("almacenid", 0);

            strReporte = "DiarioEspecial1\\InformeDevolucionesCompraSum.frx";

        }

        private void configVentasCanceladas(ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();


            dictionary.Add("FECHAINI", dateTimePicker1.Value);
            dictionary.Add("FECHAFIN", dateTimePicker1.Value);
            dictionary.Add("TIPODOCTOID", DBValues._DOCTO_TIPO_CANCELACION);
            dictionary.Add("TIPODOCTONOMBRE", "CANCELACIONES DE VENTAS");
            dictionary.Add("VENDEDORID", 0);
            dictionary.Add("VENDEDORNOMBRE", "TODOS");
            dictionary.Add("ALMACENID", 0);
            dictionary.Add("NOMBREALMACEN", "TODOS");
            dictionary.Add("REMISIONFACTURA", "T");
            dictionary.Add("REMISIONFACTURADESC", "TODOS");

            strReporte = "DiarioEspecial1\\InformeDiarioCancelacionesIEPSEXP.frx";
            
        }

        private void configCompras(ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();


            dictionary.Add("FECHAINI", dateTimePicker1.Value);
            dictionary.Add("FECHAFIN", dateTimePicker1.Value);
            dictionary.Add("TIPODOCTOID", DBValues._DOCTO_TIPO_COMPRA);
            dictionary.Add("TIPODOCTONOMBRE", "COMPRAS");
            dictionary.Add("VENDEDORID", 0);
            dictionary.Add("VENDEDORNOMBRE", "TODOS");
            dictionary.Add("ALMACENID", 0);
            dictionary.Add("NOMBREALMACEN", "TODOS");
            dictionary.Add("REMISIONFACTURA", "T");

            strReporte = "DiarioEspecial1\\InformeDiarioComprasIEPSEXP.frx";
            
        }

        private void configOtrasCompras(ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();


            dictionary.Add("FECHAINI", dateTimePicker1.Value);
            dictionary.Add("FECHAFIN", dateTimePicker1.Value);
            dictionary.Add("TIPODOCTOID", DBValues._DOCTO_TIPO_OTRASENTRADAS);
            dictionary.Add("TIPODOCTONOMBRE", "OTRAS COMPRAS");
            dictionary.Add("VENDEDORID", 0);
            dictionary.Add("VENDEDORNOMBRE", "TODOS");
            dictionary.Add("ALMACENID", 0);
            dictionary.Add("NOMBREALMACEN", "TODOS");
            dictionary.Add("REMISIONFACTURA", "T");

            strReporte = "DiarioEspecial1\\InformeDiarioEntradasIEPSEXP.frx";
            
        }

        private void configOtrasSalidas(ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();


            dictionary.Add("FECHAINI", dateTimePicker1.Value);
            dictionary.Add("FECHAFIN", dateTimePicker1.Value);
            dictionary.Add("TIPODOCTOID", DBValues._DOCTO_TIPO_OTRASSALIDAS);
            dictionary.Add("TIPODOCTONOMBRE", "OTRAS SALIDAS");
            dictionary.Add("VENDEDORID", 0);
            dictionary.Add("VENDEDORNOMBRE", "TODOS");
            dictionary.Add("ALMACENID", 0);
            dictionary.Add("NOMBREALMACEN", "TODOS");
            dictionary.Add("REMISIONFACTURA", "T");
            dictionary.Add("REMISIONFACTURADESC", "TODOS");

            strReporte = "DiarioEspecial1\\InformeDiarioOtrasSalidasIEPSEXP.frx";
            
        }

        private void configVentasClasif(ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();


            dictionary.Add("fechaini", dateTimePicker1.Value);
            dictionary.Add("fechafin", dateTimePicker1.Value);

            strReporte = "DiarioEspecial1\\InformeVentasXClasif.frx";

            
        }

        private void configEnsambleKits(ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();
            dictionary.Add("fecha", dateTimePicker1.Value);

            strReporte = "DiarioEspecial1\\InformeKitEnsambladoXDia.frx";
            
        }

        private void configClientesModif(ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();
            dictionary.Add("fecha", dateTimePicker1.Value);

            strReporte = "DiarioEspecial1\\InformeCambiosClientesXDia.frx";
            
        }

        private void configPreciosCambiados( ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();

            dictionary.Add("fecha", dateTimePicker1.Value);

            strReporte = "DiarioEspecial1\\InformeCambioPrecio.frx";
            
        }


        private void configCancelaciones(ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();

            dictionary.Add("fechaini", dateTimePicker1.Value.Date);
            dictionary.Add("fechafin", dateTimePicker1.Value.Date.AddDays(1).AddSeconds(-1));

            strReporte = "DiarioEspecial1\\InformeCancelaciones.frx";

        }


        private void configTransEspCaja(ref string strReporte, ref Dictionary<string, object> dictionary)
        {

            strReporte = "";
            dictionary = new Dictionary<string, object>();

            dictionary.Add("fechaini", dateTimePicker1.Value.Date);
            dictionary.Add("fechafin", dateTimePicker1.Value.Date.AddDays(1).AddSeconds(-1));

            strReporte = "DiarioEspecial1\\InformeDoctosCajaEspeciales.frx";

        }


        private void ImprimirReporte(string strReporte, Dictionary<string, object> dictionary)
        {
            
            report1.Load(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema));
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);


            foreach (KeyValuePair<string, object> entry in dictionary)
            {
                report1.SetParameterValue(entry.Key, entry.Value);
            }

            if (report1.Prepare())
            {
                    report1.PrintSettings.Printer = ConexionesBD.ConexionBD.CurrentParameters.IRECIBOLARGOPRINTER;
                    report1.PrintSettings.ShowDialog = false;
                    report1.Print();

            }
        }




        private void BTEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                string strReporte = "";
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                configVentasConIeps(ref strReporte, ref dictionary);
                ImprimirReporte(strReporte, dictionary);



                strReporte = "";
                dictionary = new Dictionary<string, object>();
                configVentasTarjeta(ref strReporte, ref dictionary);
                ImprimirReporte(strReporte, dictionary);

                strReporte = "";
                dictionary = new Dictionary<string, object>();
                configNotasCredito(ref strReporte, ref dictionary);
                ImprimirReporte(strReporte, dictionary);

                

                strReporte = "";
                dictionary = new Dictionary<string, object>();
                configNotasCargo(ref strReporte, ref dictionary);
                ImprimirReporte(strReporte, dictionary);
                
                

                strReporte = "";
                dictionary = new Dictionary<string, object>();
                configVentasCanceladas(ref strReporte, ref dictionary);
                ImprimirReporte(strReporte, dictionary);


                strReporte = "";
                dictionary = new Dictionary<string, object>();
                configCompras(ref strReporte, ref dictionary);
                ImprimirReporte(strReporte, dictionary);


                strReporte = "";
                dictionary = new Dictionary<string, object>();
                configOtrasCompras(ref strReporte, ref dictionary);
                ImprimirReporte(strReporte, dictionary);


                strReporte = "";
                dictionary = new Dictionary<string, object>();
                configOtrasSalidas(ref strReporte, ref dictionary);
                ImprimirReporte(strReporte, dictionary);



                strReporte = "";
                dictionary = new Dictionary<string, object>();
                configVentasClasif(ref strReporte, ref dictionary);
                ImprimirReporte(strReporte, dictionary);



                strReporte = "";
                dictionary = new Dictionary<string, object>();
                configEnsambleKits(ref strReporte, ref dictionary);
                ImprimirReporte(strReporte, dictionary);


                strReporte = "";
                dictionary = new Dictionary<string, object>();
                configClientesModif(ref strReporte, ref dictionary);
                ImprimirReporte(strReporte, dictionary);


                strReporte = "";
                dictionary = new Dictionary<string, object>();
                configPreciosCambiados(ref strReporte, ref dictionary);
                ImprimirReporte(strReporte, dictionary);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnNotasCargo_Click(object sender, EventArgs e)
        {


            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            configNotasCargo(ref strReporte, ref dictionary);

            MostrarReporte(strReporte, dictionary);
        }

        private void btnCancelaciones_Click(object sender, EventArgs e)
        {

            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            configCancelaciones(ref strReporte, ref dictionary);
            MostrarReporte(strReporte, dictionary);
        }

        private void btnTransEspCaja_Click(object sender, EventArgs e)
        {

            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            configTransEspCaja(ref strReporte, ref dictionary);
            MostrarReporte(strReporte, dictionary);
        }
    }
}
