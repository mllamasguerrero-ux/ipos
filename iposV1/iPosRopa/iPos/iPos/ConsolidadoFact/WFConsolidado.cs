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
using FirebirdSql.Data.FirebirdClient;
using FlatTabControl;
using iPosReporting;
using System.Diagnostics;
using DataLayer.Importaciones;
using System.Collections;
using System.Data.OleDb;
using DataLayer;

namespace iPos
{
    public partial class WFConsolidado : Form
    {
        private string m_strFileLog = "";
        private DateTime m_diaAMostrar = DateTime.Today;
        private bool m_formLoaded = false;

        private string m_grupoFoliosAConsiderar = null;
        public const string NombreTempReporteFacturacionDia = "FacturacionXDia";
        public bool m_importacionFoliosExitosa = false;
        public string m_importacionFoliosComentario;

        private List<CGRUPOUSUARIOBE> m_listGrupoUsuario = new List<CGRUPOUSUARIOBE>();

        public WFConsolidado()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private bool Consolidar(DateTime fechaInicial, DateTime fechaFinal, decimal montoMaximo,
                                 bool bOmitirVentasFranquicias, bool bIncluirGastos, bool bOmitirVales, long grupoUsuarioId, bool bOmitirClientesRfc , decimal montoMaximoPorc)
        {
            CDOCTOBE doctoBE = new CDOCTOBE();
            CDOCTOD doctoD = new CDOCTOD();
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                CCONSOLIDADOD consolidadoD = new CCONSOLIDADOD();
                long doctoIdFactCons = 0;
                string sOmitirVentasFranquicias = bOmitirVentasFranquicias ? "S" : "N";
                string sIncluirGastos = bIncluirGastos ? "S" : "N";
                int errorCode = 0;
                string sOmitirVales = bOmitirVales ? "S" : "N";
                string sOmitirClientesRfc = bOmitirClientesRfc ? "S" : "N";


                if (!consolidadoD.CONSOLIDADO_GENERAR(fechaInicial, fechaFinal, CurrentUserID.CurrentUser.IID, ref doctoIdFactCons, sOmitirVentasFranquicias, sIncluirGastos, montoMaximo, sOmitirVales, grupoUsuarioId, sOmitirClientesRfc, montoMaximoPorc, (this.CBSoloFoliosImportados.Checked ? m_grupoFoliosAConsiderar : null), ref errorCode, fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Ocurrio un error " + consolidadoD.IComentario);
                    return false;
                }
                else
                {
                    string resComentario = "";


                    if (!generarFacturaElectronicaPorId(doctoIdFactCons, fTrans, ref resComentario))
                    {

                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("No se pudo realizar la facturacion " + resComentario);
                        if (m_strFileLog != null && m_strFileLog.Trim().Length > 0)
                        {
                            Process.Start("notepad.exe", m_strFileLog);
                        }

                        return false;

                    }


                    fTrans.Commit();
                    fConn.Close();
                    MessageBox.Show("Factura generada " + doctoIdFactCons.ToString());

                    imprimirFacturaElectronicaPorId(doctoIdFactCons);
                    if (MessageBox.Show("Desea imprimir el ticket de la factura electronica ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        imprimirTicketFacturaElectronicaPorId(doctoIdFactCons);
                    }


                    //this.Close();
                }

            }
            catch
            {
                try
                {
                    fTrans.Rollback();
                }
                catch { }

                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }

            return true;
        }


        private void ConsolidarPorRango()
        {


            bool bOmitirVentasFranquicias =  CBOMITIRFRANQUICIAS.Checked ;
            bool bIncluirGastos = CBIncluirGastos.Checked ;
            bool bOmitirVales = OMITIRVALESCheckBox.Checked;
            bool bOmitirClientesRFC = CBOmitirClientesConRFC.Checked;

            DateTime fechaInicial = this.DTPFechaInicial.Value.Date;
            DateTime fechaFinal = this.DTPFechaFinal.Value.Date;


            decimal montoMaximo = Math.Round(decimal.Parse(this.MONTOMAXIMOTextBox.Text.ToString()), 2);
            if (!CBMontoMaximo.Checked)
            {
                montoMaximo = 0;
            }

            decimal montoMaximoPorc = Math.Round(decimal.Parse(this.MONTOMAXIMOPORCTextBox.Text.ToString()), 2);
            if (!CBMontoMaximoPorc.Checked)
            {
                montoMaximoPorc = 0;
            }


            if (Consolidar(fechaInicial, fechaFinal, montoMaximo, bOmitirVentasFranquicias,  bIncluirGastos, bOmitirVales,0, bOmitirClientesRFC, montoMaximoPorc))
            {
                this.Close();
            }


            
        }





        private void ConsolidarPorRangoFechaGrupoUsuario()
        {


            bool bOmitirVentasFranquicias = CBOMITIRFRANQUICIAS.Checked;
            bool bIncluirGastos = CBIncluirGastos.Checked;
            bool bOmitirVales = OMITIRVALESCheckBox.Checked;
            bool bOmitirClientesRFC = CBOmitirClientesConRFC.Checked;

            //foreach(CGRUPOUSUARIOBE grupoUsuario in m_listGrupoUsuario)
            //{

            ////m_diaAMostrar = fecha;
            //GRUPOUSUARIOIDComboBox.SelectedDataValue = grupoUsuario.IID;

                long grupoUsuarioId = 0;
                if (GRUPOUSUARIOIDComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Primero seleccione un grupo de usuario");
                    return;
                }
                try
                {
                    grupoUsuarioId = long.Parse(GRUPOUSUARIOIDComboBox.SelectedDataValue.ToString());
                    if(grupoUsuarioId <= 0)
                    {
                        return;
                    }
                }
                catch
                {
                    return;
                }
            

                llenarDatosDia();

                if (this.dSPuntoDeVentaAux2.PORCONSOLIDAR.Rows.Count == 0)
                    return;

                if (this.dSPuntoDeVentaAux2.PORCONSOLIDARSUMA.Rows.Count == 0)
                    return;

                foreach (PuntoDeVenta.DSPuntoDeVentaAux2.PORCONSOLIDARSUMARow row in this.dSPuntoDeVentaAux2.PORCONSOLIDARSUMA.Rows)
                {
                    if (row.SUMATOTAL == 0)
                        continue;
                }
                
                DateTime fechaInicial = this.DTPFechaInicial.Value.Date;
                DateTime fechaFinal = this.DTPFechaFinal.Value.Date;


                decimal montoMaximo = Math.Round(decimal.Parse(this.MONTOMAXIMOTextBox.Text.ToString()), 2);
                if (!CBMontoMaximo.Checked)
                {
                    montoMaximo = 0;
                }

                decimal montoMaximoPorc = Math.Round(decimal.Parse(this.MONTOMAXIMOPORCTextBox.Text.ToString()), 2);
                if (!CBMontoMaximoPorc.Checked)
                {
                    montoMaximoPorc = 0;
                }


            if (Consolidar(fechaInicial, fechaFinal, montoMaximo, bOmitirVentasFranquicias, bIncluirGastos, bOmitirVales, grupoUsuarioId, bOmitirClientesRFC, montoMaximoPorc))
                {
                    this.Close();
                }
            //}


        }





        private void ConsolidarPorDiaGrupoUsuario()
        {


            bool bOmitirVentasFranquicias = CBOMITIRFRANQUICIAS.Checked;
            bool bIncluirGastos = CBIncluirGastos.Checked;
            bool bOmitirVales = OMITIRVALESCheckBox.Checked;
            bool bOmitirClientesRFC = CBOmitirClientesConRFC.Checked;


            long grupoUsuarioId = 0;
            if (GRUPOUSUARIOIDComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Primero seleccione un grupo de usuario");
                return;
            }
            try
            {
                grupoUsuarioId = long.Parse(GRUPOUSUARIOIDComboBox.SelectedDataValue.ToString());
                if (grupoUsuarioId <= 0)
                {
                    return;
                }
            }
            catch
            {
                return;
            }
            //foreach (CGRUPOUSUARIOBE grupoUsuario in m_listGrupoUsuario)
            //{
            //    GRUPOUSUARIOIDComboBox.SelectedDataValue = grupoUsuario.IID;

            for (DateTime fecha = DTPFechaInicial.Value.Date; fecha.Date.CompareTo(DTPFechaFinal.Value.Date) <= 0; fecha = fecha.AddDays(1))
                {

                    m_diaAMostrar = fecha;
                    llenarDatosDia();

                    if (this.dSPuntoDeVentaAux2.PORCONSOLIDAR.Rows.Count == 0)
                        continue;

                    if (this.dSPuntoDeVentaAux2.PORCONSOLIDARSUMA.Rows.Count == 0)
                        continue;

                    foreach (PuntoDeVenta.DSPuntoDeVentaAux2.PORCONSOLIDARSUMARow row in this.dSPuntoDeVentaAux2.PORCONSOLIDARSUMA.Rows)
                    {
                        if (row.SUMATOTAL == 0)
                            continue;
                    }


                    DateTime fechaInicial = fecha;
                    DateTime fechaFinal = fecha;

                    decimal montoMaximo = 0;
                    Boolean aplicaMontoMaximo = false;
                    ObtenerMontoMaximoDiaGrid(fecha, ref aplicaMontoMaximo, ref montoMaximo);

                    if (!aplicaMontoMaximo)
                    {
                        montoMaximo = 0;
                    }


                    decimal montoMaximoPorc = Math.Round(decimal.Parse(this.MONTOMAXIMOPORCTextBox.Text.ToString()), 2);
                    if (!CBMontoMaximoPorc.Checked)
                    {
                        montoMaximoPorc = 0;
                    }
                    
                    if (Consolidar(fechaInicial, fechaFinal, montoMaximo, bOmitirVentasFranquicias, bIncluirGastos, bOmitirVales, grupoUsuarioId, bOmitirClientesRFC, montoMaximoPorc))
                    {
                        this.Close();
                    }
                }
            //}


        }


        private void ConsolidarPorDia()
        {


            bool bOmitirVentasFranquicias = CBOMITIRFRANQUICIAS.Checked;
            bool bIncluirGastos = CBIncluirGastos.Checked;
            bool bOmitirVales = OMITIRVALESCheckBox.Checked;
            bool bOmitirClientesRFC = CBOmitirClientesConRFC.Checked;

            for (DateTime fecha = DTPFechaInicial.Value.Date; fecha.Date.CompareTo(DTPFechaFinal.Value.Date) <= 0; fecha = fecha.AddDays(1))
            {

                m_diaAMostrar = fecha;
                llenarDatosDia();

                if (this.dSPuntoDeVentaAux2.PORCONSOLIDAR.Rows.Count == 0)
                    continue;

                if (this.dSPuntoDeVentaAux2.PORCONSOLIDARSUMA.Rows.Count == 0)
                    continue;

                foreach(PuntoDeVenta.DSPuntoDeVentaAux2.PORCONSOLIDARSUMARow row in this.dSPuntoDeVentaAux2.PORCONSOLIDARSUMA.Rows)
                {
                    if (row.SUMATOTAL == 0)
                        continue;
                }


                DateTime fechaInicial = fecha;
                DateTime fechaFinal = fecha;

                decimal montoMaximo = 0;
                Boolean aplicaMontoMaximo = false;
                ObtenerMontoMaximoDiaGrid(fecha, ref aplicaMontoMaximo, ref montoMaximo);

                if (!aplicaMontoMaximo)
                {
                    montoMaximo = 0;
                }



                decimal montoMaximoPorc = Math.Round(decimal.Parse(this.MONTOMAXIMOPORCTextBox.Text.ToString()), 2);
                if (!CBMontoMaximoPorc.Checked)
                {
                    montoMaximoPorc = 0;
                }


                if (Consolidar(fechaInicial, fechaFinal, montoMaximo, bOmitirVentasFranquicias, bIncluirGastos, bOmitirVales,0, bOmitirClientesRFC, montoMaximoPorc))
                {
                    this.Close();
                }
            }


        }



        private void btnConsolidar_Click(object sender, EventArgs e)
        {

            if(RBFacturacionXDia.Checked && RBTodosLosGruposUsuarios.Checked)
            {
                ConsolidarPorDia();
            }
            else if (RBFacturacionXDia.Checked && RBPorGrupoUsuario.Checked)
            {
                this.ConsolidarPorDiaGrupoUsuario();
            }
            else if (RBFacturacionXRango.Checked && RBPorGrupoUsuario.Checked)
            {
                this.ConsolidarPorRangoFechaGrupoUsuario();
            }
            else
            {
                ConsolidarPorRango();
            }
           
        }

        private void LlenarFacturas()
        {
            try
            {
                string sOmitirVentasFranquicias = CBOMITIRFRANQUICIAS.Checked ? "S" : "N";
                string sIncluirGastos = CBIncluirGastos.Checked ? "S" : "N";
                string sOmitirVales = OMITIRVALESCheckBox.Checked ? "S" : "N";
                string sOmitirClientesRFC = CBOmitirClientesConRFC.Checked ? "S" : "N";


                decimal montoMaximo = 0;
                decimal montoMaximoPorc = 0;



                if (RBFacturacionXDia.Checked)
                {
                    Boolean aplicaMontoMaximo = false;
                    ObtenerMontoMaximoDiaGrid(m_diaAMostrar, ref aplicaMontoMaximo, ref montoMaximo);

                    if (!aplicaMontoMaximo)
                    {
                        montoMaximo = 0;
                    }

                    montoMaximoPorc = CurrentUserID.CurrentParameters.IFACTCONSMAXPOR;
                }
                else
                {

                    montoMaximo = Math.Round(decimal.Parse(this.MONTOMAXIMOTextBox.Text.ToString()), 2);
                    if (!CBMontoMaximo.Checked)
                    {
                        montoMaximo = 0;
                    }


                    montoMaximoPorc = Math.Round(decimal.Parse(this.MONTOMAXIMOPORCTextBox.Text.ToString()), 2);
                    if (!CBMontoMaximoPorc.Checked)
                    {
                        montoMaximoPorc = 0;
                    }
                }



                DateTime fechaInicial = this.DTPFechaInicial.Value.Date;
                DateTime fechaFinal = this.DTPFechaFinal.Value.Date;

                if (RBFacturacionXDia.Checked)
                {

                    fechaInicial = m_diaAMostrar;
                    fechaFinal = m_diaAMostrar;
                }



                long grupoUsuarioId = 0;
                if( RBPorGrupoUsuario.Checked && GRUPOUSUARIOIDComboBox.SelectedIndex != -1)
                {
                    
                    try
                    {
                        grupoUsuarioId = long.Parse(this.GRUPOUSUARIOIDComboBox.SelectedValue.ToString());
                    }
                    catch
                    {
                        grupoUsuarioId = 0;
                    }

                }


                this.pORCONSOLIDARTableAdapter.Fill(this.dSPuntoDeVentaAux2.PORCONSOLIDAR, fechaInicial, fechaFinal, sOmitirVentasFranquicias, sIncluirGastos, montoMaximo, sOmitirVales,"N",grupoUsuarioId, sOmitirClientesRFC, montoMaximoPorc,"N", (this.CBSoloFoliosImportados.Checked ? m_grupoFoliosAConsiderar : null));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void LlenarSuma()
        {
            try
            {
                string sOmitirVentasFranquicias = CBOMITIRFRANQUICIAS.Checked ? "S" : "N";
                string sIncluirGastos = CBIncluirGastos.Checked ? "S" : "N";
                string sOmitirVales = OMITIRVALESCheckBox.Checked ? "S" : "N";
                string sOmitirClientesRFC = CBOmitirClientesConRFC.Checked ? "S" : "N";


                decimal montoMaximo = 0;
                decimal montoMaximoPorc = 0;


                if (RBFacturacionXDia.Checked)
                {
                    Boolean aplicaMontoMaximo = false;
                    ObtenerMontoMaximoDiaGrid(m_diaAMostrar, ref aplicaMontoMaximo, ref montoMaximo);

                    if (!aplicaMontoMaximo)
                    {
                        montoMaximo = 0;
                    }
                    montoMaximoPorc = CurrentUserID.CurrentParameters.IFACTCONSMAXPOR;
                }
                else
                {

                    montoMaximo = Math.Round(decimal.Parse(this.MONTOMAXIMOTextBox.Text.ToString()), 2);
                    if (!CBMontoMaximo.Checked)
                    {
                        montoMaximo = 0;
                    }

                    montoMaximoPorc = Math.Round(decimal.Parse(this.MONTOMAXIMOPORCTextBox.Text.ToString()), 2);
                    if (!CBMontoMaximoPorc.Checked)
                    {
                        montoMaximoPorc = 0;
                    }
                }


                DateTime fechaInicial = this.DTPFechaInicial.Value.Date;
                DateTime fechaFinal = this.DTPFechaFinal.Value.Date;


                if (RBFacturacionXDia.Checked)
                {

                    fechaInicial = m_diaAMostrar;
                    fechaFinal = m_diaAMostrar;
                }


                long grupoUsuarioId = 0;
                if (RBPorGrupoUsuario.Checked && GRUPOUSUARIOIDComboBox.SelectedIndex != -1)
                {

                    try
                    {
                        grupoUsuarioId = long.Parse(this.GRUPOUSUARIOIDComboBox.SelectedValue.ToString());
                    }
                    catch
                    {
                        grupoUsuarioId = 0;
                    }

                }

                this.pORCONSOLIDARSUMATableAdapter.Fill(this.dSPuntoDeVentaAux2.PORCONSOLIDARSUMA, fechaInicial, fechaFinal, sOmitirVentasFranquicias, sIncluirGastos, montoMaximo, sOmitirVales, "N", grupoUsuarioId, sOmitirClientesRFC, montoMaximoPorc, (this.CBSoloFoliosImportados.Checked ? m_grupoFoliosAConsiderar : null));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void LlenarGruposUsuarios()
        {
            CGRUPOUSUARIOD grupoUsuarioD = new CGRUPOUSUARIOD();
            m_listGrupoUsuario = grupoUsuarioD.listGRUPOUSUARIO(null);
            
        }

        private void btnFacturasAConsolidar_Click(object sender, EventArgs e)
        {
            m_diaAMostrar = DTPFechaInicial.Value.Date;
            GRUPOUSUARIOIDComboBox.SelectedIndex = -1;

            llenarDatosDia();
        }




        private bool generarFacturaElectronicaPorId(long doctoId, FbTransaction fTrans, ref string resComentario)
        {

            CDOCTOBE docto = new CDOCTOBE();
            CDOCTOD doctoD = new CDOCTOD();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, fTrans);

            if(docto == null)
            {

                resComentario = "No se encontro la factura electronica";
                return false;
            }

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (docto.IFECHAHORA.Month != DateTime.Now.Month)
            {
                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_FACTURARFUERADEMES, fTrans))
                {
                    resComentario = "No tiene derecho para facturar una remision fuera de este mes";
                    return false;
                }
            }



            bool retorno = false;



           

            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, fTrans, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.m_silentMode = true;
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            m_strFileLog = fe.m_strFileLog;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            if (retorno)
            {
                docto.IESFACTURAELECTRONICA = "S";
                doctoD.ACTUALIZARESFACTURAELECTRONICA(docto, fTrans);
            }

            return retorno;
        }



        private bool imprimirFacturaElectronicaPorId(long doctoId)
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE docto = new CDOCTOBE();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, null);

            if (docto == null)
            {

                MessageBox.Show("No se encontro la factura electronica");
                return false;
            }


            if ((bool)docto.isnull["IFOLIOSAT"] || (bool)docto.isnull["IESTATUSDOCTOID"]
                || docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || docto.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }


            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, iPosReporting.WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }




        private bool imprimirTicketFacturaElectronicaPorId(long doctoId)
        {
            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

            if ((bool)doctoBE.isnull["IFOLIOSAT"] || (bool)doctoBE.isnull["IESTATUSDOCTOID"]
               || doctoBE.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || doctoBE.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }


            WFFacturaElectronica fe = new WFFacturaElectronica(doctoBE, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_IMPRIMIRTICKET, doctoBE, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.m_bForzarImpresionTicket = true;
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;

        }



        private void formatearPantallaSegunAgrupacion()
        {
            if(RBFacturacionXRango.Checked)
            {
                tabControl1.TabPages.Remove(tbPageXDia);
                pnlDia.Visible = false;

                pnlMesAnio.Visible = true;
                pnlFechas.Visible = false;
            }
            else
            {
                if(!tabControl1.TabPages.Contains(tbPageXDia))
                    tabControl1.TabPages.Add(tbPageXDia);
                pnlDia.Visible = true;

                pnlMesAnio.Visible = false;
                pnlFechas.Visible = true;
            }

            if(this.RBTodosLosGruposUsuarios.Checked)
            {
                
                pnlGrupoUsuario.Visible = false;
            }
            else
            {
                pnlGrupoUsuario.Visible = true;
                if (GRUPOUSUARIOIDComboBox.Items.Count > 0)
                {
                    GRUPOUSUARIOIDComboBox.SelectedIndex = 0;
                }

            }


            if(RBFacturacionXRango.Checked && RBTodosLosGruposUsuarios.Checked)
            {
                
                pnlMontoMax.Visible = true;
                pnlMultiple.Visible = false;
            }
            else
            {
                pnlMontoMax.Visible = false;
                pnlMultiple.Visible = true;
                pnlMultiple.Height = 60;

            }
        }

        private void RBFacturacionXRango_CheckedChanged(object sender, EventArgs e)
        {
            formatearPantallaSegunAgrupacion();
        }

        private void RBFacturacionXDia_CheckedChanged(object sender, EventArgs e)
        {

            formatearPantallaSegunAgrupacion();
        }

        private void LlenarGridFechas()
        {

            dSConsolidados.TableFechaMonto.Clear();
            for(DateTime fecha = DTPFechaInicial.Value.Date; fecha.Date.CompareTo(DTPFechaFinal.Value.Date) <= 0; fecha = fecha.AddDays(1))
            {
                ConsolidadoFact.DSConsolidados.TableFechaMontoRow row = dSConsolidados.TableFechaMonto.NewTableFechaMontoRow();
                row.Fecha = fecha;
                row.Monto = 0;
                row.AplicaMontoMaximo = false;
                dSConsolidados.TableFechaMonto.AddTableFechaMontoRow(row);
            }

        }

        private void ObtenerMontoMaximoDiaGrid(DateTime fecha, ref bool aplicaMontoMaximo, ref decimal montoMaximo)
        {
            foreach(ConsolidadoFact.DSConsolidados.TableFechaMontoRow row in dSConsolidados.TableFechaMonto.Rows)
            {
                if(row.Fecha.Date.CompareTo(fecha) == 0)
                {
                    aplicaMontoMaximo = row.AplicaMontoMaximo;
                    montoMaximo = row.Monto;
                    return;
                }
            }
        }

        private void CambiarMontoMaximoDiaGrid(DateTime fecha, bool aplicaMontoMaximo , decimal montoMaximo)
        {

            foreach (ConsolidadoFact.DSConsolidados.TableFechaMontoRow row in dSConsolidados.TableFechaMonto.Rows)
            {
                if (row.Fecha.Date.CompareTo(fecha) == 0)
                {
                    row.AplicaMontoMaximo = aplicaMontoMaximo;
                    row.Monto = montoMaximo;
                    return;
                }
            }
        }

        private void DTPFechaInicial_ValueChanged(object sender, EventArgs e)
        {
            
            LlenarGridFechas();
        }

        private void DTPFechaFinal_ValueChanged(object sender, EventArgs e)
        {

            LlenarGridFechas();
        }

        private void AjustaFechasAMesSeleccionado()
        {
            var firstDayOfMonth = new DateTime(Decimal.ToInt32(NumAnio.Value), CBMes.SelectedIndex + 1, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            DTPFechaInicial.Value = firstDayOfMonth;
            DTPFechaFinal.Value = lastDayOfMonth;
        }

        private void WFConsolidado_Load(object sender, EventArgs e)
        {

            CBMes.SelectedIndex = DateTime.Today.Month - 1;
            NumAnio.Value = DateTime.Today.Year;
            AjustaFechasAMesSeleccionado();


            tabControl1.TabPages.Remove(tbPageXDia);
            GRUPOUSUARIOIDComboBox.llenarDatos();
            LlenarGridFechas();
            LlenarGruposUsuarios();

            if(CurrentUserID.CurrentParameters.IFACTCONSMAXPOR > 0)
            {
                MONTOMAXIMOPORCTextBox.Text = CurrentUserID.CurrentParameters.IFACTCONSMAXPOR.ToString("N2");
            }

            m_formLoaded = true;
        }


        private void llenarDatosDia()
        {

            lblMostrandoFact.Text = "Facturas del dia : " + m_diaAMostrar.ToString("dd/MM/yyyy");

            bool aplicaMontoMaximo = false;
            decimal montoMaximo = 0;
            ObtenerMontoMaximoDiaGrid(m_diaAMostrar, ref aplicaMontoMaximo, ref montoMaximo);
            CBMontoMaximoDia.Checked = aplicaMontoMaximo;
            MONTOMAXIMODIATextBox.NumericValue = montoMaximo;
            LlenarSuma();
            LlenarFacturas();
        }

        private void btnDiaAnterior_Click(object sender, EventArgs e)
        {

            DateTime fechaInicial = this.DTPFechaInicial.Value.Date;
            DateTime fechaFinal = this.DTPFechaFinal.Value.Date;

            if (m_diaAMostrar == null)
                m_diaAMostrar = fechaInicial;

            if (m_diaAMostrar.AddDays(-1).CompareTo(fechaInicial) >= 0)
                m_diaAMostrar = m_diaAMostrar.AddDays(-1);

            llenarDatosDia();


        }

        private void btnDiaSiguiente_Click(object sender, EventArgs e)
        {


            DateTime fechaInicial = this.DTPFechaInicial.Value.Date;
            DateTime fechaFinal = this.DTPFechaFinal.Value.Date;

            if (m_diaAMostrar == null)
                m_diaAMostrar = fechaInicial;

            if (m_diaAMostrar.AddDays(1).CompareTo(fechaFinal) <= 0)
                m_diaAMostrar = m_diaAMostrar.AddDays(1);
            

            llenarDatosDia();
        }

        private void btnActualizarDia_Click(object sender, EventArgs e)
        {


            decimal montoMaximo = Math.Round(decimal.Parse(this.MONTOMAXIMODIATextBox.Text.ToString()), 2);
            bool aplicaMontoMaximo = CBMontoMaximoDia.Checked;
            if (!aplicaMontoMaximo)
            {
                montoMaximo = 0;
            }


            CambiarMontoMaximoDiaGrid(m_diaAMostrar,  aplicaMontoMaximo,  montoMaximo);

            llenarDatosDia();
        }

        private void tableFechaMontoDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            string columnName = tableFechaMontoDataGridView.Columns[e.ColumnIndex].Name;

            // Abort validation if cell is not in the CompanyName column.
            if (!columnName.Equals("AplicaMontoMaximo") && !columnName.Equals("DGMontoMaximoDia")  ) return;


            try
            {
                decimal dMontoMaximo = 0;
                bool bAplicaMontoMaximo = false;
                DateTime fechaMontoMaximo = DateTime.Today;



                try
                {
                    fechaMontoMaximo = (DateTime)(tableFechaMontoDataGridView.Rows[e.RowIndex].Cells["fechaMontoMaximo"].Value);
                }
                catch
                {

                }

                try
                {
                    dMontoMaximo = decimal.Parse(tableFechaMontoDataGridView.Rows[e.RowIndex].Cells["DGMontoMaximoDia"].Value.ToString());
                }
                catch
                {

                }



                try
                {
                    bAplicaMontoMaximo = Boolean.Parse(tableFechaMontoDataGridView.Rows[e.RowIndex].Cells["AplicaMontoMaximo"].Value.ToString());
                }
                catch
                {

                }

                if(m_diaAMostrar.CompareTo(fechaMontoMaximo) == 0)
                {
                    llenarDatosDia();
                }




            }
            catch(Exception ex)
            {

            }


         }

        

        private void RBTodosLosGruposUsuarios_CheckedChanged(object sender, EventArgs e)
        {
            formatearPantallaSegunAgrupacion();
        }

        private void RBPorGrupoUsuario_CheckedChanged(object sender, EventArgs e)
        {
            formatearPantallaSegunAgrupacion();
        }
        

        private void CBMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_formLoaded)
            {
                this.AjustaFechasAMesSeleccionado();
                this.LlenarGridFechas();
            }
        }

        private void NumAnio_ValueChanged(object sender, EventArgs e)
        {
            if(m_formLoaded)
            {
                this.AjustaFechasAMesSeleccionado();
                this.LlenarGridFechas();
            }
        }

        private void WFConsolidado_FormClosing(object sender, FormClosingEventArgs e)
        {
            string comentario = "";
            EliminarRegistrosFoliosReferenciaTemporales(ref comentario);
        }

        private bool EliminarRegistrosFoliosReferenciaTemporales(ref string comentario)
        {
            //Eliminar los registros de filtro temporal de folios
            if (m_grupoFoliosAConsiderar != null)
            {
                CTEMP_FILTRO_REPOD tempFiltrosD = new CTEMP_FILTRO_REPOD();
                CTEMP_FILTRO_REPOBE tempFiltroBE = new CTEMP_FILTRO_REPOBE();
                tempFiltroBE.INOMBRE_REPORTE = NombreTempReporteFacturacionDia;
                tempFiltroBE.IGRUPO_REPORTE = m_grupoFoliosAConsiderar;

                var retorno = tempFiltrosD.BorrarPorNombreYGrupo(tempFiltroBE, null);
                if (!retorno)
                    comentario = tempFiltrosD.IComentario;

                return retorno;

            }

            return true;
        }

        private void BTTempExcel_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Excel files (*.xls)|*.xls| Excel files 2007 (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.TBTempExcel.Text = openFileDialog1.FileName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void BTCargarExcel_Click(object sender, EventArgs e)
        {

            if (this.TBTempExcel.Text != "")
            {
                m_importacionFoliosExitosa = false;
                m_importacionFoliosComentario = "";
                progressBar1.Style = ProgressBarStyle.Marquee;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            string comentario = "";
            if (ImportarTempFolios(this.TBTempExcel.Text, ref comentario))
            {
                m_importacionFoliosExitosa = true;
            }
            else
            {
                m_importacionFoliosComentario = "No se pudieron importar los folios " + comentario;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBar1.Style = ProgressBarStyle.Blocks;
            if (m_importacionFoliosExitosa)
            {
                this.CargarFoliosFiltro();
            }
            else
            {
                MessageBox.Show(m_importacionFoliosComentario);
            }
        }



        public bool ImportarTempFolios(string archivoExcel,  ref string comentario)
        {
           string excelConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivoExcel + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;MAXSCANROWS=15;READONLY=FALSE\"";
            System.Collections.ArrayList parts = new ArrayList();
            String CmdTxt = @"select * from [folios$] ";
            OleDbParameter[] arParms = new OleDbParameter[parts.Count];
            parts.CopyTo(arParms, 0);
            

            try
            {
                OleDbDataReader dr;
                dr = OleDbHelper.ExecuteReader(excelConnection, CommandType.Text, CmdTxt, arParms);


                if (m_grupoFoliosAConsiderar == null)
                    m_grupoFoliosAConsiderar = (new Guid()).ToString();
                

                string bufferComentario = "";
                if (!EliminarRegistrosFoliosReferenciaTemporales(ref bufferComentario))
                {
                    comentario = bufferComentario;
                    return false;
                }



                CTEMP_FILTRO_REPOD tempFiltrosD = new CTEMP_FILTRO_REPOD();
                
                while (dr.Read())
                {


                    CTEMP_FILTRO_REPOBE item = new CTEMP_FILTRO_REPOBE();
                    item.INOMBRE_REPORTE = NombreTempReporteFacturacionDia;
                    item.IGRUPO_REPORTE = m_grupoFoliosAConsiderar;
                    item.IACTIVO = "S";


                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        item.IFILTRO_INTEGER = int.Parse(dr["FOLIO"].ToString());
                    }
                    else
                    {
                        return false;
                    }
                    


                    if (tempFiltrosD.AgregarTEMP_FILTRO_REPOD(item, null) == null)
                    {

                        comentario = tempFiltrosD.IComentario;
                        return false;
                    }

                }

                dr.Close();


                return true;


            }
            catch (Exception ex)
            {
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
            }
            

        }

        private void CargarFoliosFiltro()
        {
            try
            {
                this.fOLIOSACONSOLIDARTableAdapter.Fill(this.dSConsolidados.FOLIOSACONSOLIDAR, this.m_grupoFoliosAConsiderar);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
