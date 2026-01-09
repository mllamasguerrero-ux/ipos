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
    public partial class WFConsultaInventarioFisico : IposForm
    {
        string[] m_columnTitlesExcel = new string[] {   "",
                                                        "",
                                                        "",
                                                        "CANTIDAD_TEORICA",
                                                        "CANTIDAD_FISICA",
                                                        "DIFERENCIA",
                                                        "PRODUCTO_NOMBRE",
                                                        "PRODUCTO_DESCRIPCION",
                                                        "" ,
                                                        CurrentUserID.CurrentParameters.ITEXTO1 != null ? CurrentUserID.CurrentParameters.ITEXTO1 : "",
                                                        CurrentUserID.CurrentParameters.ITEXTO2 != null ? CurrentUserID.CurrentParameters.ITEXTO2 : "",
                                                        CurrentUserID.CurrentParameters.ITEXTO3 != null ? CurrentUserID.CurrentParameters.ITEXTO3 : "",
                                                        CurrentUserID.CurrentParameters.ITEXTO4 != null ? CurrentUserID.CurrentParameters.ITEXTO4 : "",
                                                        CurrentUserID.CurrentParameters.ITEXTO5 != null ? CurrentUserID.CurrentParameters.ITEXTO5 : "",
                                                        CurrentUserID.CurrentParameters.ITEXTO6 != null ? CurrentUserID.CurrentParameters.ITEXTO6 : "",
                                                        CurrentUserID.CurrentParameters.INUMERO1 != null ? CurrentUserID.CurrentParameters.INUMERO1 : "",
                                                        CurrentUserID.CurrentParameters.INUMERO1 != null ? CurrentUserID.CurrentParameters.INUMERO2 : "",
                                                        CurrentUserID.CurrentParameters.INUMERO1 != null ? CurrentUserID.CurrentParameters.INUMERO3 : "",
                                                        CurrentUserID.CurrentParameters.INUMERO1 != null ? CurrentUserID.CurrentParameters.INUMERO4 : "",
                                                        CurrentUserID.CurrentParameters.INUMERO1 != null ? CurrentUserID.CurrentParameters.IFECHA1 : "",
                                                        CurrentUserID.CurrentParameters.INUMERO1 != null ? CurrentUserID.CurrentParameters.IFECHA2 : ""
        };

       long m_lDoctoId;

       public bool m_bNotShowScreen = false;

        public WFConsultaInventarioFisico()
        {
            InitializeComponent();
            m_lDoctoId = 0;
        }
        public WFConsultaInventarioFisico(long lDoctoId):this()
        {
            m_lDoctoId = lDoctoId;
        }


        private void LlenarGrid(int iDoctoId,bool bSoloDif)
        {
            try
            {
                this.consultaInventarioTableAdapter.Fill(this.dSInventarioFisico.ConsultaInventario, iDoctoId, (bSoloDif ? "1" : "0"));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFConsultaInventarioFisico_Load(object sender, EventArgs e)
        {

            if(m_bNotShowScreen)
            {
                this.Close();
                return;
            }

            this.LlenarGrid((int)m_lDoctoId, this.CBMostrarSoloDif.Checked);
        }

        private void CBMostrarSoloDif_CheckedChanged(object sender, EventArgs e)
        {

            this.LlenarGrid((int)m_lDoctoId, this.CBMostrarSoloDif.Checked);
        }

        private void BTPrint_Click(object sender, EventArgs e)
        {
            ImprimirTicket(m_lDoctoId, this.CBImprimeDif.Checked ? 1 : 0);
        }



        public  void ImprimirTicket(long doctoId, long lOpcion1)
        {


            CTICKET_DETAILD detailD = new CTICKET_DETAILD();
            CTICKET_FOOTERD footerD = new CTICKET_FOOTERD();
            CTICKET_HEADERD headerD = new CTICKET_HEADERD();


            CTICKET_FOOTERBE footerBE = new CTICKET_FOOTERBE();
            CTICKET_HEADERBE headerBE = new CTICKET_HEADERBE();
            //CTICKET_DETAILBE[] ListaDetalles = detailD.seleccionarTICKET_DETAIL(doctoId, false, null);
            LlenarInventarioFisico(doctoId);

            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            string line;

            footerBE.IDOCTOID = doctoId;
            headerBE.IDOCTOID = doctoId;

            headerBE = headerD.seleccionarTICKET_HEADER(headerBE,  null);
            footerBE = footerD.seleccionarTICKET_FOOTER(footerBE, false, null);


            Ticket ticket = new Ticket();

            ticket.AddHeaderLine("INVENTARIO FISICO");
            ticket.AddHeaderLine("      " + headerBE.INOMBRE);
            ticket.AddHeaderLine(headerBE.IDOMICICIO);
            ticket.AddHeaderLine(headerBE.ICIUDAD.Trim() + " , " + headerBE.IESTADO.Trim());
            ticket.AddHeaderLine("RFC: " + headerBE.IRFC);
            ticket.AddHeaderLine(new string('-', Ticket.maxChar));


            ticket.AddHeaderLine("Usuario: " + iPos.CurrentUserID.CurrentUser.INOMBRE);

            if (headerBE.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA)
                ticket.AddHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            else
                ticket.AddHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " Ticket " + headerBE.ITICKET);




            decimal dCantidadTeorica = 0, dDiferencia = 0, dCantidadFisica = 0, dCostoPrecio = 0, dDiferenciaCostoInv = 0;
            decimal dCantidadTeoricaTotal = 0, dCantidadFisicaTotal = 0, dDiferenciaCostoInvTotal = 0;
            int iCantProdTotal = 0, iCantProdConDif = 0, iCantSinExistencia = 0;

            ticket.AddHeaderLine(new string('=', Ticket.maxChar));

            ticket.AddHeaderLine("DESCRIPCION               ");
            ticket.AddHeaderLine("CANT. TEORICA  CANT. FISICA  DIFERENCIA");
            ticket.AddHeaderLine("               COSTO         IMPORTE");

            ticket.AddHeaderLine(new string('-', Ticket.maxChar));


            foreach (DataRow detailItem in this.dSInventarioFisico2.GET_INVFIS_COMPLETO)
            {
                iCantProdTotal++;


                dCantidadTeorica = (decimal)detailItem["CANTIDADTEORICA"];
                dCantidadFisica = (decimal)detailItem["CANTIDADFISICA"]; ;
                dDiferenciaCostoInv = (decimal)detailItem["DIFERNECIACOSTOINVENTARIO"];
                dCostoPrecio = (decimal)detailItem["COSTOPRECIOMANEJADO"];
                dDiferenciaCostoInvTotal += dDiferenciaCostoInv;
                dCantidadTeoricaTotal += dCantidadTeorica;
                dCantidadFisicaTotal += dCantidadFisica;

                if (dCantidadTeorica != dCantidadFisica)
                    iCantProdConDif++;

                if (dCantidadFisica == 0)
                    iCantSinExistencia++;


                if (lOpcion1 == 1 && dCantidadTeorica == dCantidadFisica)
                    continue;


                dDiferencia = dCantidadTeorica - dCantidadFisica;

                int maxleng = (detailItem["PRODUCTODESCRIPCION"].ToString().Length > 39) ? 39 : detailItem["PRODUCTODESCRIPCION"].ToString().Length;
                ticket.AddHeaderLine(detailItem["PRODUCTODESCRIPCION"].ToString().Substring(0, maxleng));


                try
                {
                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] && CurrentUserID.CurrentParameters.ITEXTO1 != "")
                    {
                        ticket.AddHeaderLine(Ticket.FormatPrintField(CurrentUserID.CurrentParameters.ITEXTO1, 16, 0) + " : " + Ticket.FormatPrintField(detailItem["TEXTO1"].ToString(), 16, 0));
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO2"] && CurrentUserID.CurrentParameters.ITEXTO2 != "")
                    {

                        ticket.AddHeaderLine(Ticket.FormatPrintField(CurrentUserID.CurrentParameters.ITEXTO2, 16, 0) + " : " + Ticket.FormatPrintField(detailItem["TEXTO2"].ToString(), 16, 0));
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO3"] && CurrentUserID.CurrentParameters.ITEXTO3 != "")
                    {

                        ticket.AddHeaderLine(Ticket.FormatPrintField(CurrentUserID.CurrentParameters.ITEXTO3, 16, 0) + " : " + Ticket.FormatPrintField(detailItem["TEXTO3"].ToString(), 16, 0));
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO4"] && CurrentUserID.CurrentParameters.ITEXTO4 != "")
                    {
                        ticket.AddHeaderLine(Ticket.FormatPrintField(CurrentUserID.CurrentParameters.ITEXTO4, 16, 0) + " : " + Ticket.FormatPrintField(detailItem["TEXTO4"].ToString(), 16, 0));
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO5"] && CurrentUserID.CurrentParameters.ITEXTO5 != "")
                    {

                        ticket.AddHeaderLine(Ticket.FormatPrintField(CurrentUserID.CurrentParameters.ITEXTO5, 16, 0) + " : " + Ticket.FormatPrintField(detailItem["TEXTO5"].ToString(), 16, 0));
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO6"] && CurrentUserID.CurrentParameters.ITEXTO6 != "")
                    {

                        ticket.AddHeaderLine(Ticket.FormatPrintField(CurrentUserID.CurrentParameters.ITEXTO6, 16, 0) + " : " + Ticket.FormatPrintField(detailItem["TEXTO6"].ToString(), 16, 0));
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO1"] && CurrentUserID.CurrentParameters.INUMERO1 != "")
                    {

                        ticket.AddHeaderLine(Ticket.FormatPrintField(CurrentUserID.CurrentParameters.INUMERO1, 16, 0) + " : " + Ticket.FormatPrintField(detailItem["NUMERO1"].ToString(), 16, 0));
                    }




                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO2"] && CurrentUserID.CurrentParameters.INUMERO2 != "")
                    {

                        ticket.AddHeaderLine(Ticket.FormatPrintField(CurrentUserID.CurrentParameters.INUMERO2, 16, 0) + " : " + Ticket.FormatPrintField(detailItem["NUMERO2"].ToString(), 16, 0));
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO3"] && CurrentUserID.CurrentParameters.INUMERO3 != "")
                    {

                        ticket.AddHeaderLine(Ticket.FormatPrintField(CurrentUserID.CurrentParameters.INUMERO3, 16, 0) + " : " + Ticket.FormatPrintField(detailItem["NUMERO3"].ToString(), 16, 0));
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO4"] && CurrentUserID.CurrentParameters.INUMERO4 != "")
                    {

                        ticket.AddHeaderLine(Ticket.FormatPrintField(CurrentUserID.CurrentParameters.INUMERO4, 16, 0) + " : " + Ticket.FormatPrintField(detailItem["NUMERO4"].ToString(), 16, 0));
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA1"] && CurrentUserID.CurrentParameters.IFECHA1 != "")
                    {

                        ticket.AddHeaderLine(Ticket.FormatPrintField(CurrentUserID.CurrentParameters.IFECHA1, 16, 0) + " : " + Ticket.FormatPrintField(detailItem["FECHA1"].ToString(), 16, 0));
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA2"] && CurrentUserID.CurrentParameters.IFECHA2 != "")
                    {
                        ticket.AddHeaderLine(Ticket.FormatPrintField(CurrentUserID.CurrentParameters.IFECHA2, 16, 0) + " : " + Ticket.FormatPrintField(detailItem["FECHA2"].ToString(), 16, 0));
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }




                line = "";
                line += Ticket.FormatPrintField(dCantidadTeorica.ToString("N2"), 13, 0) + "  ";
                line += Ticket.FormatPrintField(dCantidadFisica.ToString("N2"), 12, 0) + "  ";
                line += Ticket.FormatPrintField(dDiferencia.ToString("N2"), 10, 0);
                ticket.AddHeaderLine(line);
                line = "";
                line += Ticket.FormatPrintField(" ", 13, 0) + "  ";
                line += Ticket.FormatPrintField(dCostoPrecio.ToString("N2"), 12, 0) + "  ";
                line += Ticket.FormatPrintField(dDiferenciaCostoInv.ToString("N2"), 10, 0);
                ticket.AddHeaderLine(line);
            }


            ticket.AddHeaderLine(new string('-', Ticket.maxChar));
            ticket.AddTotal("Cant. Prod.     : ", iCantProdTotal.ToString("N0"));
            ticket.AddTotal("Prod. con Dif.  : ", iCantProdConDif.ToString("N0"));
            ticket.AddTotal("Prod. sin Exist.: ", iCantSinExistencia.ToString("N0"));
            ticket.AddTotal("Importe Dif.    : ", dDiferenciaCostoInvTotal.ToString("N0"));
            ticket.AddTotal("Cant Teorica Tot: ", dCantidadTeoricaTotal.ToString("N0"));
            ticket.AddTotal("Cant Fisica Tot : ", dCantidadFisicaTotal.ToString("N0"));
            ticket.AddTotal("Cant Dif Tot    : ", (dCantidadFisicaTotal - dCantidadTeoricaTotal).ToString("N0"));


            ticket.AddFooterLine(new string('-', Ticket.maxChar));

            ticket.AddFooterLine(footerBE.ICAJA /*+ " Turno: " + footerBE.ITURNO*/);
            ticket.AddFooterLine(new string('-', Ticket.maxChar));

            ticket.PrintTicketDirect(Ticket.GetReceiptPrinter());


        }




        private void ExportToExcel()
        {



            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            sucursalBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);


                if (sucursalBE != null)
                {
                    string strArchivo = "";

                    
                    SaveFileDialog openFileDialog1 = new SaveFileDialog();

                    openFileDialog1.InitialDirectory = "c:\\";
                    openFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                    openFileDialog1.FilterIndex = 1;
                    openFileDialog1.RestoreDirectory = true;

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        strArchivo = openFileDialog1.FileName;
                    }



                    if (EnviosMail.Excel_FromDataTable(this.dSInventarioFisico.ConsultaInventario, strArchivo, this.m_columnTitlesExcel, sucursalBE))
                    {

                        MessageBox.Show("El archivo se ha exportado");
                    }
                }
            



        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void LlenarInventarioFisico(long doctoId)
        {
            try
            {
                this.gET_INVFIS_COMPLETOTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_COMPLETO, doctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

            Dictionary<string, object> dictionary = new Dictionary<string, object>();


            string strReporte = "InformeInventarioFisicoRealizado.frx";

            if (CBImprimeDif.Checked)
            {

                strReporte = "InformeInventarioCompleto.frx";
                dictionary.Add("DOCTOID", m_lDoctoId);
                dictionary.Add("SOLODIFERENCIAS", CBImprimeDif.Checked ? (short)1 : (short)0);
                dictionary.Add("TODOSLOSPRODUCTOS", (short)1);
                dictionary.Add("TITULO", "Consulta inventario fisico");
            }
            else
            {

                dictionary.Add("doctoid", m_lDoctoId);
                dictionary.Add("solodiferencias", CBImprimeDif.Checked ? "S" : "N");
            }



            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }



    }
}
