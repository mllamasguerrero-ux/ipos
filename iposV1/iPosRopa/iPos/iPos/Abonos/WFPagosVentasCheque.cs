using FirebirdSql.Data.FirebirdClient;
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

namespace iPos.Abonos
{
    public partial class WFPagosVentasCheque : Form
    {
        public WFPagosVentasCheque()
        {
            InitializeComponent();
        }
        
        private void LlenarGridPorBusqueda()
        {

            long formaPago = DBValues._FORMA_PAGO_CHEQUE;
            string filtroAplicados = "T";
            string filtroTimbrados = "T";
            long clienteId = 0;
            string incluirCancelaciones = "S";
            string porFechaCheque = "N";
            string porFechaAplicacion = "N";

            string porFolio = "N";
            long pagoId = 0;

            long bancoId = 0;
            string referencia = "%%";

            if (CBGeneral.Checked)
            {
                filtroAplicados = ValorFiltroAplicados();
                if (ITEMIDTextBox.DbValue != null)
                {
                    clienteId = long.Parse(ITEMIDTextBox.DbValue);
                }
                incluirCancelaciones = CBIncluirCancelaciones.Checked ? "S" : "N";
                porFechaCheque = CBFechaCheque.Checked ? "S" : "N";
                porFechaAplicacion = this.CBFechaAplicacion.Checked ? "S" : "N";
            }
            else if(CBFolio.Checked)
            {
                porFolio = "S";
                pagoId = this.TBFolio.Text.Trim().Length > 0 ? long.Parse(this.TBFolio.Text.ToString()) : 0;
            }
            else if(CBDatosBancarios.Checked)
            {

                bancoId = this.ComboBanco.SelectedIndex >= 0 && bancoCheckBox.Checked ? long.Parse(this.ComboBanco.SelectedValue.ToString()) : 0;
                referencia = TBReferencia.Text != null && TBReferencia.Text.Trim().Length > 0 ? "%" + TBReferencia.Text + "%" : "%%";
            }

            LlenarGrid(formaPago, filtroAplicados, filtroTimbrados, clienteId, incluirCancelaciones, porFechaCheque, porFechaAplicacion, porFolio,pagoId, bancoId, referencia);
        }

        private void LlenarGrid(long formaPago, string aplicados, string timbrados, long clienteId, string incluirCancelaciones,
                                string porFechaCheque, string porFechaAplicacion, string porFolio, long pagoId, long bancoId, string referencia)
        {
            try
            {
                this.pAGOLISTCHEQUETableAdapter.Fill(this.dSAbonos.PAGOLISTCHEQUE,
                                                porFechaCheque, dtpFechaInicial.Value,dtpFechaFinal.Value,
                                                porFechaAplicacion, dtpFechaInicial.Value, dtpFechaFinal.Value,
                                                "N", dtpFechaInicial.Value, dtpFechaFinal.Value,
                                                this.CBFolio.Checked ? "S" : "N", pagoId,
                                               incluirCancelaciones, formaPago, aplicados, timbrados, clienteId,bancoId, referencia);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


       

        private string ValorFiltroAplicados()
        {
            switch (aplicadosComboBox.SelectedIndex)
            {
                case 0:
                    return "A";
                case 1:
                    return "N";
                case 2:
                    return "D";
                default:
                    return "T";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGridPorBusqueda();
        }

        private void SeleccionarPagosList(bool valorSeleccion)
        {
            for (int rowIndex = 0; rowIndex < pAGOLISTCHEQUEDataGridView.Rows.Count; rowIndex++)
            {
                pAGOLISTCHEQUEDataGridView.Rows[rowIndex].Cells["DGSeleccionar"].Value = valorSeleccion;
            }
        }

        private void btnSelecionarTodos_Click(object sender, EventArgs e)
        {
            SeleccionarPagosList(true);
        }


        private void btnDeseleccionarTodos_Click(object sender, EventArgs e)
        {

            SeleccionarPagosList(false);
        }


        private void btnAplicarSeleccionados_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Realmente desea aplicar los pagos? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }


            aplicarSeleccionados(true);
        }
        private void btnDesaplicarSeleccionados_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Realmente desea desaplicar los pagos? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }


            aplicarSeleccionados(false);
        }

        private void aplicarSeleccionados(bool aplicado)
        {

            ReciboElectronicoHelper reciboElectronicoHelper = new ReciboElectronicoHelper();
            CPAGOD pagoDao = new CPAGOD();

            FbConnection connection = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction transaction = null;
            

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                foreach (DataGridViewRow row in pAGOLISTCHEQUEDataGridView.Rows)
                {
                    if (row.Cells["DGSeleccionar"].Value != null && (bool)row.Cells["DGSeleccionar"].Value)
                    {

                        CPAGOBE pago = new CPAGOBE();

                        long folio = (long)row.Cells["DGID"].Value;

                        pago.IID = folio;
                        pago = pagoDao.seleccionarPAGO(pago, transaction);
                        
                        //no hay cambio
                        if((pago.IAPLICADO != null && pago.IAPLICADO.Equals("S") && aplicado) ||
                           (pago.IAPLICADO == null || pago.IAPLICADO.Equals("N") && !aplicado))
                        {
                            continue;
                        }

                        pago.IAPLICADO = aplicado ? "S" : "N";
                        if (!pagoDao.CambiarAPLICADO_PAGOD(pago, pago, transaction))
                        {
                            throw new Exception("Error: " + pagoDao.IComentario);
                        }
                        
                    }
                }

                transaction.Commit();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                MessageBox.Show("Error: " + exception.Message + " StackTrace: " + exception.StackTrace);
                
            }
            finally
            {
                connection.Close();
            }

            //LlenarGrid(0, "T", "T", 0);
            LlenarGridPorBusqueda();
        }

        private bool AplicarSimple(long folio, bool aplicado)
        {
            CPAGOBE pago = new CPAGOBE();
            CPAGOD pagoDao = new CPAGOD();

            FbConnection connection = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction transaction = null;


            bool bResult = true;

            string warningMessage = "";

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                pago.IID = folio;
                pago = pagoDao.seleccionarPAGO(pago, transaction);

                if (pago == null)
                {

                    throw new Exception("Error: pago no existe ");
                }

                //si hay cambio
                if ((pago.IAPLICADO != null && pago.IAPLICADO.Equals("S") && !aplicado) ||
                   (pago.IAPLICADO == null || pago.IAPLICADO.Equals("N") && aplicado))
                {
                    pago.IAPLICADO = aplicado ? "S" : "N";
                    if (!pagoDao.CambiarAPLICADO_PAGOD(pago, pago, transaction))
                    {
                        throw new Exception("Error: " + pagoDao.IComentario);
                    }
                }
                else
                {
                    warningMessage = "No hay cambio a hacer";
                }

                transaction.Commit();
            
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                bResult = false;
                MessageBox.Show("Error: " + exception.Message + " StackTrace: " + exception.StackTrace);

            }
            finally
            {
                connection.Close();
            }

            if(warningMessage != null && warningMessage.Trim().Length > 0)
            {
                MessageBox.Show(warningMessage);
            }

            return bResult;
        }

        private bool CambiarFechaAplicadoSimple(long folio, DateTime nuevaFecha, long motivoCambioId)
        {
            CPAGOBE pago = new CPAGOBE();
            CPAGOD pagoDao = new CPAGOD();

            FbConnection connection = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction transaction = null;

            bool bResult = true;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                pago.IID = folio;
                pago = pagoDao.seleccionarPAGO(pago, transaction);

                if(pago == null)
                {

                    throw new Exception("Error: pago no existe ");
                }
                
                pago.IFECHAAPLICADO = nuevaFecha;
                pago.IMOTIVO_CAMFEC_ID = motivoCambioId;

                if (!pagoDao.CambiarAPLICADO_PAGOD(pago, pago, null))
                {
                        throw new Exception("Error: " + pagoDao.IComentario);
                }

                transaction.Commit();

            }
            catch (Exception exception)
            {
                transaction.Rollback();
                bResult = false;
                MessageBox.Show("Error: " + exception.Message + " StackTrace: " + exception.StackTrace);

            }
            finally
            {
                connection.Close();
            }
            return bResult;
        }




        private bool DevolverPagoSimple(long folio)
        {
            CPAGOBE pago = new CPAGOBE();
            CPAGOD pagoDao = new CPAGOD();

            FbConnection connection = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction transaction = null;

            bool bResult = true;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                pago.IID = folio;
                pago = pagoDao.seleccionarPAGO(pago, transaction);

                if (pago == null)
                {

                    throw new Exception("Error: pago no existe ");
                }
                
                if(pago.IAPLICADO != null && !pago.IAPLICADO.Equals("S"))
                {
                    throw new Exception("Error: pago debe estar aplicado para que se pueda devolver ");
                }

                if (pago.IDEVUELTO != null && pago.IDEVUELTO.Equals("S"))
                {
                    throw new Exception("Error: pago ya esta devuelto ");
                }

                if (!pagoDao.PAGO_DEVOLVER(pago, CurrentUserID.CurrentUser.IID, null))
                {
                    throw new Exception("Error: " + pagoDao.IComentario);
                }

                transaction.Commit();

            }
            catch (Exception exception)
            {
                transaction.Rollback();
                bResult = false;
                MessageBox.Show("Error: " + exception.Message + " StackTrace: " + exception.StackTrace);

            }
            finally
            {
                connection.Close();
            }
            return bResult;
        }



        private void pAGOLISTCHEQUEDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pAGOLISTCHEQUEDataGridView.Columns[e.ColumnIndex].Name == "DGVer")
            {
                if (pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DGID"].Value != null)
                {
                    long folioId = (long)pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;

                    WFPagoCompuestoEdit wf = new WFPagoCompuestoEdit(folioId);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);

                    LlenarGridPorBusqueda();


                }
            }
            else if (pAGOLISTCHEQUEDataGridView.Columns[e.ColumnIndex].Name == "DGAPLICAR")
            {
                if (MessageBox.Show("Realmente desea aplicar el pago? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DGID"].Value != null)
                {
                    long folioId = (long)pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;

                    if (AplicarSimple(folioId, true))
                    {

                        LlenarGridPorBusqueda();
                    }


                }
            }
            else if (pAGOLISTCHEQUEDataGridView.Columns[e.ColumnIndex].Name == "DGDESAPLICAR")
            {

                string aplicado = "N";
                string devuelto = "N";
                try
                {
                    aplicado = pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DGAPLICADO"].Value.ToString();
                    devuelto = pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DEVUELTO"].Value.ToString();

                    if (aplicado == null || aplicado.Equals("N"))
                    {
                        MessageBox.Show("No puede desaplicar pues no esta aplicado ");
                        return;
                    }
                    if (devuelto != null && devuelto.Equals("S"))
                    {
                        MessageBox.Show("No puede desaplicar pues ya esta devuelto ");
                        return;
                    }
                }
                catch
                {
                }

                if (MessageBox.Show("Realmente desea desaplicar el pago? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DGID"].Value != null)
                {
                    long folioId = (long)pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;

                    if(AplicarSimple(folioId, false))
                    {

                        LlenarGridPorBusqueda();
                    }



                }
            }
            else if (pAGOLISTCHEQUEDataGridView.Columns[e.ColumnIndex].Name == "DGCambiarFechaAplicacion")
            {
                string aplicado = "N";
                try
                {
                    aplicado = pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DGAPLICADO"].Value.ToString();

                    if (aplicado != null && aplicado.Equals("S"))
                    {
                        MessageBox.Show("No puede cambiar la fecha de aplicacion si el registro ya esta aplicado ");
                        return;
                    }
                }
                catch
                {
                }

                if (MessageBox.Show("Realmente desea cambiar la fecha de aplicacion del pago? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DGID"].Value != null)
                {
                    long folioId = (long)pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;

                    long motivoId  = 0;
                    DateTime nuevaFecha = DateTime.Today;
                    WFMotivoCambioFecApl wf = new WFMotivoCambioFecApl();
                    wf.ShowDialog();

                    motivoId = wf.m_motivoId;
                    nuevaFecha = wf.m_fechaAplicacion;

                    wf.Dispose();
                    GC.SuppressFinalize(wf);

                    if (motivoId > 0)
                    {
                        if (CambiarFechaAplicadoSimple(folioId, nuevaFecha, motivoId))
                        {

                            LlenarGridPorBusqueda();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un motivo");
                    }



                }
            }
            else if (pAGOLISTCHEQUEDataGridView.Columns[e.ColumnIndex].Name == "DGDevolver")
            {

                string aplicado = "N";
                string devuelto = "N";
                try
                {
                    aplicado = pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DGAPLICADO"].Value.ToString();
                    devuelto = pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DEVUELTO"].Value.ToString();

                    if (aplicado == null || aplicado.Equals("N"))
                    {
                        MessageBox.Show("Para devolver el cheque primero necesita aplicarlo ");
                        return;
                    }
                    if (devuelto != null && devuelto.Equals("S"))
                    {
                        MessageBox.Show("No puede puede devolver otra vez pues ya esta devuelto ");
                        return;
                    }
                }
                catch
                {
                }


                if (MessageBox.Show("Realmente desea marcar como cheque devuelto? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DGID"].Value != null)
                {
                    long folioId = (long)pAGOLISTCHEQUEDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                    
                    
                        if (this.DevolverPagoSimple(folioId))
                        {
                            MessageBox.Show("Se hizo la devolucion del pago");
                            LlenarGridPorBusqueda();
                        }




                }
            }




        }

        private void WFPagosVentasCheque_Load(object sender, EventArgs e)
        {
            ComboBanco.llenarDatos();
            ComboBanco.SelectedIndex = -1;


            if (!ChecarCorteActivo())
                return;

            HabilitarOpciones();

            LlenarGridPorBusqueda(); 

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




        private void HabilitarOpciones()
        {

            CUSUARIOSD usersD = new CUSUARIOSD();
            Boolean bTieneDerechoAplicarCheque = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_APLICAR_CHEQUES, null);
            Boolean bTieneDerechoDesAplicarCheque = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DESAPLICAR_CHEQUES, null);
            Boolean bTieneDerechoCambiarFechaCheque = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_APLICACION_CAMBIARFECHA, null);
            Boolean bTieneDerechoDevolverCheque = usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEVOLVER_CHEQUE, null);



            DGSeleccionar.Visible = bTieneDerechoAplicarCheque || bTieneDerechoDesAplicarCheque;
            DGCambiarFechaAplicacion.Visible = bTieneDerechoCambiarFechaCheque;
            DGAPLICAR.Visible = bTieneDerechoAplicarCheque;
            DGDESAPLICAR.Visible = bTieneDerechoDesAplicarCheque;
            DGDevolver.Visible = bTieneDerechoDevolverCheque;

            btnSelecionarTodos.Visible = bTieneDerechoAplicarCheque || bTieneDerechoDesAplicarCheque;
            btnDeseleccionarTodos.Visible = bTieneDerechoAplicarCheque || bTieneDerechoDesAplicarCheque;


            btnAplicarSeleccionados.Visible = bTieneDerechoAplicarCheque;
            btnDesaplicarSeleccionados.Visible = bTieneDerechoDesAplicarCheque;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

            string strReporte = "";
            /*long formaPago = DBValues._FORMA_PAGO_CHEQUE;
            string filtroAplicados = ValorFiltroAplicados();
            string filtroTimbrados = "T";
            long clienteId = 0;
            long pagoId = this.TBFolio.Text.Trim().Length > 0 ? long.Parse(this.TBFolio.Text.ToString()) : 0;

            long bancoId = this.ComboBanco.SelectedIndex >= 0 && bancoCheckBox.Checked ? long.Parse(this.ComboBanco.SelectedValue.ToString()) : 0;
            string referencia = TBReferencia.Text != null && TBReferencia.Text.Trim().Length > 0 ?  "%" + TBReferencia.Text + "%" : "";*/
            string banconombre = this.ComboBanco.SelectedIndex >= 0 && bancoCheckBox.Checked ? this.ComboBanco.SelectedText : "Todos";
/*
            if (ITEMIDTextBox.DbValue != null)
            {
                clienteId = long.Parse(ITEMIDTextBox.DbValue);
            }*/





            long formaPago = DBValues._FORMA_PAGO_CHEQUE;
            string filtroAplicados = "T";
            string filtroTimbrados = "T";
            long clienteId = 0;
            string incluirCancelaciones = "S";
            string porFechaCheque = "N";
            string porFechaAplicacion = "N";

            string porFolio = "N";
            long pagoId = 0;

            long bancoId = 0;
            string referencia = "%%";

            if (CBGeneral.Checked)
            {
                filtroAplicados = ValorFiltroAplicados();
                if (ITEMIDTextBox.DbValue != null)
                {
                    clienteId = long.Parse(ITEMIDTextBox.DbValue);
                }
                incluirCancelaciones = CBIncluirCancelaciones.Checked ? "S" : "N";
                porFechaCheque = CBFechaCheque.Checked ? "S" : "N";
                porFechaAplicacion = this.CBFechaAplicacion.Checked ? "S" : "N";
            }
            else if (CBFolio.Checked)
            {
                porFolio = "S";
                pagoId = this.TBFolio.Text.Trim().Length > 0 ? long.Parse(this.TBFolio.Text.ToString()) : 0;
            }
            else if (CBDatosBancarios.Checked)
            {

                bancoId = this.ComboBanco.SelectedIndex >= 0 && bancoCheckBox.Checked ? long.Parse(this.ComboBanco.SelectedValue.ToString()) : 0;
                referencia = TBReferencia.Text != null && TBReferencia.Text.Trim().Length > 0 ? "%" + TBReferencia.Text + "%" : "%%";
            }


            Dictionary<string, object> dictionary = new Dictionary<string, object>();


            dictionary.Add("fechafinal", dtpFechaInicial.Value);
            dictionary.Add("fechainicial", dtpFechaFinal.Value);
            dictionary.Add("personaid", clienteId);
            dictionary.Add("incluircancelaciones", CBIncluirCancelaciones.Checked ? "S" : "N");
            dictionary.Add("formapagoid", formaPago);
            dictionary.Add("timbrado", filtroTimbrados);
            dictionary.Add("estatusaplicacion", filtroAplicados);


            

            dictionary.Add("porfecha", porFechaCheque);
            dictionary.Add("porfechaaplicado", porFechaAplicacion);
            dictionary.Add("fechainicialaplicado", dtpFechaInicial.Value);
            dictionary.Add("fechafinalaplicado", dtpFechaInicial.Value);
            dictionary.Add("porfechaprocesado", "N");
            dictionary.Add("fechainicialprocesado", dtpFechaInicial.Value);
            dictionary.Add("fechafinalprocesado", dtpFechaInicial.Value);
            dictionary.Add("porfolio", porFolio);
            dictionary.Add("pagoid", pagoId);
            dictionary.Add("banco", bancoId);
            dictionary.Add("banconombre", banconombre);
            dictionary.Add("referenciabancaria", referencia);

            strReporte = "pagoporcheque.frx";



            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void ITEMButton_Click(object sender, EventArgs e)
        {

            this.SeleccionaCliente();
        }


        private void SeleccionaCliente()
        {
            iPos.Catalogos.WFClientes look = new iPos.Catalogos.WFClientes();
            look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                string strBuffer = "";
                this.ITEMIDTextBox.DbValue = ((long)dr["ID"]).ToString();
                this.ITEMIDTextBox.MostrarErrores = false;
                this.ITEMIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ITEMIDTextBox.MostrarErrores = true;
                
            }
        }

        private void CBFechaCheque_CheckedChanged(object sender, EventArgs e)
        {
            if (CBFechaCheque.Checked)
                CBFechaAplicacion.Checked = false;
        }

        private void CBFechaAplicacion_CheckedChanged(object sender, EventArgs e)
        {

            if (CBFechaAplicacion.Checked)
                CBFechaCheque.Checked = false;
        }

        private void CBFolio_CheckedChanged(object sender, EventArgs e)
        {
            if(CBFolio.Checked)
            {
                CBGeneral.Checked = false;
                CBDatosBancarios.Checked = false;
            }
        }

        private void CBDatosBancarios_CheckedChanged(object sender, EventArgs e)
        {

            if (CBDatosBancarios.Checked)
            {
                CBGeneral.Checked = false;
                CBFolio.Checked = false;
            }
        }

        private void CBGeneral_CheckedChanged(object sender, EventArgs e)
        {

            if (CBGeneral.Checked)
            {
                CBDatosBancarios.Checked = false;
                CBFolio.Checked = false;
            }
        }
    }
}
