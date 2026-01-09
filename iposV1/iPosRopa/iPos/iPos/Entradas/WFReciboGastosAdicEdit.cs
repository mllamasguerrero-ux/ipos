using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;
using FlatTabControl;
using iPosReporting;
using System.Diagnostics;
using DataLayer.Importaciones;
using System.IO;
using Newtonsoft.Json;

namespace iPos
{
    public partial class WFReciboGastosAdicEdit : IposForm
    {

        int m_estadoVenta;
        CDOCTOBE m_Docto;

        long predoctoId = 0;
        long m_corteId = 0;

        bool m_bSeleccionarCajero = false;

        string m_modo = "Agregar";

        long m_autorizoId = 0;
        public WFReciboGastosAdicEdit()
        {
            InitializeComponent();
            m_autorizoId = CurrentUserID.CurrentUser.IID;
            m_Docto = new CDOCTOBE();

        }



        public WFReciboGastosAdicEdit(long doctoId, string modo)
            : this()
        {
            predoctoId = doctoId;
            m_modo = modo;


        }



        private void WFReciboGastosAdicEdit_Load(object sender, EventArgs e)
        {
            


            if (predoctoId != 0)
            {
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IID = predoctoId;
                doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                if(doctoBE == null)
                {
                    MessageBox.Show("No se pudo cargar la informacion del gasto");
                    return;
                }
                
                m_Docto = doctoBE;
                LlenarGrid();
                this.LBFolio.Text = m_Docto.IFOLIO.ToString();


                this.pnlCorteSeleccion.Visible = false;
                m_corteId = m_Docto.ICORTEID;

                if (m_modo.Equals("Consultar"))
                {
                    gRIDPVGASTODataGridView.ReadOnly = true;
                    btnAgregar.Enabled = false;
                }
                if (m_modo.Equals("Cambiar") )
                {

                    if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR && m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_ORDEN_COMPRA)
                    {
                        gRIDPVGASTODataGridView.ReadOnly = true;
                        btnAgregar.Enabled = false;
                    }
                }

            }
        }

        private void LlenarGrid()
        {
            try
            {
                this.gRIDPVGASTOADICTableAdapter.Fill(this.dSContabilidad.GRIDPVGASTOADIC, (int)m_Docto.IID);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        private void ProcessComand()
        {


            long? P_IDDOCTO = null;
            long? P_CAJEROID = iPos.CurrentUserID.CurrentUser.IID;
            long? P_SUPERVISORID = m_autorizoId;


            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            int? PARTIDAID =  null;
            long? MOVTOID = 0;


            long? gastoId = null;
            decimal? totalGasto = null;

            if (this.GASTOIDTextBox.Text != "")
            {
                gastoId = Int64.Parse(this.GASTOIDTextBox.DbValue.ToString());
            }

            if (this.TBMonto.Text != "")
            {
                totalGasto = decimal.Parse(this.TBMonto.Text.ToString());
            }


            if(gastoId == null || totalGasto == null)
            {
                return;
            }          
  
            if (!(bool)this.m_Docto.isnull["IID"])
            {
                P_IDDOCTO = m_Docto.IID;
            }




            CMOVTOGASTOSADICD movtoGastoD = new CMOVTOGASTOSADICD();

            
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                if (movtoGastoD.EjecutarAddMOVTO(P_IDDOCTO,
                                        PARTIDAID,
                                       gastoId,
                                       totalGasto,
                                       ref MOVTOID,
                                       fTrans ))
                {

                    fTrans.Commit();

                    this.limpiarEntradaGasto();



                    fConn.Close();

                    LlenarGrid();
                }
                else
                {

                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Ocurrio un error " + movtoGastoD.IComentario);
                }


           
            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }
            
            

        }




        private void ObtenerDoctoDeBD(long lDoctoID, FbTransaction st)
        {
            CDOCTOD vDocto = new CDOCTOD();
            m_Docto = new CDOCTOBE();
            m_Docto.IID = lDoctoID;
            m_Docto = vDocto.seleccionarDOCTO(m_Docto, st);
        }



        private void limpiarEntradaGasto()
        {
            TBMonto.Text = "0.0";
            GASTOIDTextBox.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProcessComand();
        }


        



        private bool ChecarCorteActivo(ref long corteId)
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CorteAbrir corteForm;
            DateTime fechaCorte = DateTime.MinValue;

            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                return false;
            }
            else
            {

                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {
                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                    return false;
                }
                else
                {

                    CCORTEBE corteBuffer = new CCORTEBE();
                    CCORTED corteD = new CCORTED();
                    corteBuffer.ICAJEROID = iPos.CurrentUserID.CurrentUser.IID;
                    corteBuffer.IFECHACORTE = fechaCorte;
                    corteBuffer = corteD.seleccionarCORTEXDIAyCAJERO(corteBuffer, null);

                    if (corteBuffer == null)
                    {
                        MessageBox.Show("No se pudo obtener la informacion del corte actual");
                        return false;
                    }

                    corteId = corteBuffer.IID;
                    return true;
                }

            }

        }

        private void gRIDPVGASTODataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 )
            {

                if (gRIDPVGASTODataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {
                    if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR && m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_ORDEN_COMPRA)
                    {
                        MessageBox.Show("No puede eliminar porque el estatus de la compra no es borrador");
                        return;
                    }


                    long movtoId = long.Parse(gRIDPVGASTODataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());

                    CMOVTOGASTOSADICD movtoGastosAdicD = new CMOVTOGASTOSADICD();
                    CMOVTOGASTOSADICBE movtoGastosAdicBE = new CMOVTOGASTOSADICBE();
                    movtoGastosAdicBE.IID = movtoId;
                    if (!movtoGastosAdicD.BorrarMOVTOGASTOSADIC(movtoGastosAdicBE, null))
                    {
                        MessageBox.Show(movtoGastosAdicD.IComentario);
                    }
                    else
                    {
                        LlenarGrid();
                    }

                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
            {
                MessageBox.Show("Como el docto no es borrador no se puede borrar");
                return;
            }

            if (MessageBox.Show("Esta seguro de cancelar este registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }




                CMOVTOGASTOSADICD movtoGastosAdicD = new CMOVTOGASTOSADICD();

                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;

                try
                {
                    fConn.Open();
                    fTrans = fConn.BeginTransaction();

                    if (movtoGastosAdicD.GASTOSADIC_CANCEL(m_Docto.IID, fTrans))
                    {
                        fTrans.Commit();
                        fConn.Close();
                        MessageBox.Show("El registro se ha cancelado");
                        this.Close();
                        return;
                    }
                    else
                    {

                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("Ocurrio un error " + movtoGastosAdicD.IComentario);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    fTrans.Rollback();
                    MessageBox.Show(ex.Message + " " + ex.StackTrace);
                    fConn.Close();
                }
                finally
                {
                    fConn.Close();
                }

            
        }

        private void gRIDPVGASTODataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void gRIDPVGASTODataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (gRIDPVGASTODataGridView.Columns["DGTOTAL"].Index == e.ColumnIndex)
            {
                try
                {
                    decimal dNuevaCantidad = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejaCantidad = decimal.Parse(gRIDPVGASTODataGridView.Rows[e.RowIndex].Cells["DGTOTAL"].Value.ToString());
                    decimal dEntrada = dNuevaCantidad - dViejaCantidad;


                    if (dEntrada == 0)
                        return;
                    if (dNuevaCantidad <= 0)
                    {
                        MessageBox.Show("La cantidad  no puede ser menor o igual a cero, si requiere cancelar el detalle porfavor seleccione 'Eliminar detalle'");
                        e.Cancel = true;
                    }
                    else
                    {
                        long movtoId = long.Parse(gRIDPVGASTODataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                        long gastoId = long.Parse(gRIDPVGASTODataGridView.Rows[e.RowIndex].Cells["DGGASTOID"].Value.ToString());

                        string strBuffer = "";

                        this.GASTOIDTextBox.DbValue = gastoId.ToString();
                        this.GASTOIDTextBox.MostrarErrores = false;
                        this.GASTOIDTextBox.MValidarEntrada(out strBuffer, 1);
                        this.GASTOIDTextBox.MostrarErrores = true;

                        TBMonto.Text = dEntrada.ToString();

                        ProcessComand();

                        
                    }

                }
                catch (Exception ex)
                {
                }
            }
        }

        private void gRIDPVGASTODataGridView_EnterKeyDownEvent(object sender, EventArgs e)
        {
            this.GASTOIDTextBox.Focus();
        }


        private void BuscarGastos()
        {
            iPos.Catalogos.WFGastosAdicionales look = new iPos.Catalogos.WFGastosAdicionales(GASTOIDTextBox.Text);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {

                string strBuffer = "";

                this.GASTOIDTextBox.DbValue = dr["ID"].ToString();
                this.GASTOIDTextBox.MostrarErrores = false;
                this.GASTOIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.GASTOIDTextBox.MostrarErrores = true;
            }
        }

        private void GASTOButton_Click(object sender, EventArgs e)
        {
            BuscarGastos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
