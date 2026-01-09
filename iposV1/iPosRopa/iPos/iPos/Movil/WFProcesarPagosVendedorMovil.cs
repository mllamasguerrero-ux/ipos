using FirebirdSql.Data.FirebirdClient;
using iPosBusinessEntity;
using iPosData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Movil
{
    public partial class WFProcesarPagosVendedorMovil : Form
    {
        public string vendedorClave;
        public DateTime fechaVal;
        public WFProcesarPagosVendedorMovil(string vendedorClave, DateTime fecha)
        {
            InitializeComponent();
            this.vendedorClave = vendedorClave;
            this.fechaVal = fecha;
        }

        private void WFProcesarPagosVendedorMovil_Load(object sender, EventArgs e)
        {

            LlenarGrid();

            LlenarDatosReporte();
        }

        private void WFProcesarPagosVendedorMovil_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            procesarPagos();
        }

        private bool ChecarCorteActivo()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                MessageBox.Show("Necesita abrir un corte");
                this.Close();
                return false;
            }
            else
            {
                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {

                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                    this.Close();
                    return false;
                }
                else
                    return true;
            }

            //return true;

        }

        private void procesarPagos()
        {
            if (!ChecarCorteActivo())
            {
                MessageBox.Show("Corte de Caja No activo! Haga un nuevo corte de caja ");
                return;
            }


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();
                
                CR_PAGOMOVILD daoPago = new CR_PAGOMOVILD();
                List<CR_PAGOMOVILBE> pagos = new List<CR_PAGOMOVILBE>();
                pagos = daoPago.seleccionarPAGOMOVILPendienteXVendedor(vendedorClave, fechaVal, fTrans);




                if (dSMovil5.PAGOSVENDEDORMOVIL.Rows.Count > 0 )
                {
                    foreach (CR_PAGOMOVILBE item in pagos)
                    //foreach(DSMovil5.PAGOSVENDEDORMOVILRow dgRow in dSMovil5.PAGOSVENDEDORMOVIL.Rows)
                    {

                        var dgRow = dSMovil5.PAGOSVENDEDORMOVIL.AsEnumerable().Where(row => row.Field<long>("ID") == item.IID).First();

                        //CR_PAGOMOVILBE item = new CR_PAGOMOVILBE();
                        //item.IID = dgRow.ID;

                        if (dgRow != null && dgRow.REFINTERNO != null && dgRow.REFINTERNO.Trim().Length > 0)
                        {
                            item.IREFINTERNO = dgRow.REFINTERNO;
                            if(!daoPago.CambiarR_PAGOMOVIL_REFINTERNO(item, item, fTrans))
                            {

                                fTrans.Rollback();
                                fConn.Close();
                                MessageBox.Show("Error al cambiar el ref interno : " + daoPago.IComentario);
                                return;
                            }
                        }


                        if (!daoPago.MOVILPAGO_PROCESAR(item.IID, CurrentUserID.CurrentUser.IID, fTrans))
                        {
                           
                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show("Error al aplicar los pagos : " + daoPago.IComentario);
                            return;
                        }
                    }
                    
                }

                fTrans.Commit();
                fConn.Close();



                //enviar los registros al webservice como ya finalizados por la matriz
                com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
                string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                if (strWebService.Trim().Length > 0)
                {
                    service1.Url = strWebService.Trim();
                }

                List<string> strErrores = new List<string>();
                if (pagos.Count > 0)
                {
                    foreach (CR_PAGOMOVILBE item in pagos)
                    {
                        item.IID = item.IR_PAGOMOVILREFID;
                        item.IPROCESADO = "F";
                    }

                    var serialized = JsonConvert.SerializeObject(pagos);
                    string strRespuesta = service1.ActualizarCobranzaProcesadoMovil_3(serialized, "", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                       iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                       iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    if (!strRespuesta.StartsWith("S"))
                    {
                        strErrores.Add("Error al actualizar el estado de pagos " + strRespuesta);   

                    }
                }




                MessageBox.Show("Se aplicaron los cambios");
                this.Close();
                return;

            }
            catch(Exception exc)
            {
                fTrans.Rollback();
                fConn.Close();
                MessageBox.Show("Error, algo salio mal: " + exc.Message);
            }

        }

        private void LlenarGrid()
        {
            try
            {
                this.pAGOSVENDEDORMOVILTableAdapter.Fill(this.dSMovil5.PAGOSVENDEDORMOVIL, vendedorClave, fechaVal);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void LlenarDatosReporte()
        {

            try
            {
                report1.Delete();
                report1.Dispose();
                report1 = new FastReport.Report();
                report1.NeedRefresh = false;

                report1.Load(FastReportsConfig.getPathForFile("InformePagosPorVendedorMovil.frx", FastReportsTipoFile.desistema));
                report1.Preview = this.previewControl1;
                report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;

                report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
                report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
                report1.SetParameterValue("vendedor", vendedorClave);
                report1.SetParameterValue("fecha", fechaVal);


                if (report1.Prepare())
                {
                    report1.ShowPrepared();
                    this.previewControl1.Update();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void pAGOSVENDEDORMOVILDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (pAGOSVENDEDORMOVILDataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {


                    if (MessageBox.Show("Esta seguro que desea eliminar el abono? ", "Confirmacion", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                    
                    CR_DOCTOPAGOMOVILD doctoPagoMovilD = new CR_DOCTOPAGOMOVILD();
                    CR_PAGOMOVILD pagoMovilD = new CR_PAGOMOVILD();

                    long doctoPagoMovilId = long.Parse(pAGOSVENDEDORMOVILDataGridView.Rows[e.RowIndex].Cells["DGDOCTOPAGOMOVILID"].Value.ToString());

                    CR_DOCTOPAGOMOVILBE doctoPagoMovil = new CR_DOCTOPAGOMOVILBE();
                    doctoPagoMovil.IID = doctoPagoMovilId;
                    doctoPagoMovil = doctoPagoMovilD.seleccionarR_DOCTOPAGOMOVIL(doctoPagoMovil, null);


                    if (doctoPagoMovil != null)
                    {
                        bool bRes = doctoPagoMovilD.BorrarR_DOCTOPAGOMOVILD(doctoPagoMovil, null);
                            if (!bRes)
                            {
                                MessageBox.Show("Ocurrio un error al eliminar los detalles del registro");
                            }

                        if (bRes)
                        {
                            CR_PAGOMOVILBE pagoMovil = new CR_PAGOMOVILBE();
                            pagoMovil.IID = doctoPagoMovil.IPAGOMOVILID;
                            var doctoPagosMovilesMismoPago = doctoPagoMovilD.seleccionarR_DOCTOPAGOMOVIL_DEPAGO(doctoPagoMovil.IPAGOMOVILID, null);
                            if (doctoPagosMovilesMismoPago == null || doctoPagosMovilesMismoPago.Count() == 0)
                            {

                                

                                bRes = pagoMovilD.BorrarR_PAGOMOVILD(pagoMovil, null);

                            }
                            else
                            {

                                pagoMovil = pagoMovilD.seleccionarR_PAGOMOVIL(pagoMovil, null);
                                pagoMovil.IIMPORTE -= doctoPagoMovil.IIMPORTE;
                                bRes = pagoMovilD.CambiarR_PAGOMOVILD(pagoMovil, pagoMovil, null);
                            }
                        }


                    }

                    LlenarGrid();
                }

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (tabControl1.SelectedIndex)
            {

                case 1:
                    {
                        this.LlenarDatosReporte();
                        break;
                }
                case 0:
                    {
                    LlenarGrid();
                    break;
                }
            }
        }
    }
}
