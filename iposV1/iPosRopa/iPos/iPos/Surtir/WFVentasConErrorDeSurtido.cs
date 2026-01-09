using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using System.Globalization;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using Microsoft.ApplicationBlocks.Data;
using ConexionesBD;

namespace iPos
{
    public partial class WFVentasConErrorDeSurtido : Form
    {
        public WFVentasConErrorDeSurtido()
        {
            InitializeComponent();
        }

        private void LlenarGrid()
        {
            try
            {
                int vendedorId = (this.CBCajerosTodos.Checked) ? 0 : Int32.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
                DateTime fechaMinima = this.DTFechaMinima.Value;
                string mostrarMoviles = this.cbMostrarMoviles.Checked ? "S" : "N";

                //DateTime.Today.AddDays(-30)
                this.vENTASCONERRORDESURTIDOTableAdapter.Fill(this.dSSurtido.VENTASCONERRORDESURTIDO,fechaMinima, vendedorId, mostrarMoviles);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFVentasConErrorDeSurtido_Load(object sender, EventArgs e)
        {
            ChecarCorteActivo();

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CANCELAR_VENTA_TODAS_ERRORSURTIDO, null))
            {
                this.pnlCajero.Enabled = false;

                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CANCELAR_VENTA_MOVIL_ERRORSURTIDO, null))
                {
                    this.cbMostrarMoviles.Enabled = false;
                }
                else
                {
                    this.cbMostrarMoviles.Enabled = true;
                }

            }
            else
            {
                this.pnlCajero.Enabled = true;
                this.cbMostrarMoviles.Enabled = true;
            }





            this.DTFechaMinima.Value = DateTime.Today.AddDays(-30);

            string strBuffer = "";
            this.VENDEDORIDTextBox.DbValue = CurrentUserID.CurrentUser.IID.ToString();
            this.VENDEDORIDTextBox.MostrarErrores = false;
            this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
            this.VENDEDORIDTextBox.MostrarErrores = true;

            LlenarGrid();
            
        }

        private void vENTASCONERRORDESURTIDODataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex != -1)
            {

                if (vENTASCONERRORDESURTIDODataGridView.Columns[e.ColumnIndex].Name == "DGRECREAR")
                {

                    if (MessageBox.Show("Seguro que desea cancelar esta venta y recrear una nueva con los mismos datos?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return ;
                    }

                    long docId = (long)vENTASCONERRORDESURTIDODataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                    CSURTIDOD surtidoD = new CSURTIDOD();
                    long refNewDoctoId = 0;
                    bool bRes = false;

                    
                        FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                        FbTransaction fTrans = null;
                        try
                        {

                            fConn.Open();
                            fTrans = fConn.BeginTransaction();

                            bRes = surtidoD.SURTIDO_RECREARVENTA(docId, CurrentUserID.CurrentUser.IID, ref refNewDoctoId, fTrans);

                            if(!bRes)
                            {
                                fTrans.Rollback();
                                fConn.Close();

                                MessageBox.Show("Ocurrrio un error " + surtidoD.IComentario);
                                return;

                            }

                            fTrans.Commit();
                            fConn.Close();

                            this.LlenarGrid();

                            WFPuntoDeVenta wf = new WFPuntoDeVenta(refNewDoctoId);
                            wf.ShowDialog();
                            wf.Dispose();
                            GC.SuppressFinalize(wf);




                    }
                        catch(Exception ex)
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

                    
                }
                else if (vENTASCONERRORDESURTIDODataGridView.Columns[e.ColumnIndex].Name == "DGCANCELAR")
                    {


                        if (MessageBox.Show("Seguro que desea cancelar esta venta ?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }

                        long docId = (long)vENTASCONERRORDESURTIDODataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                        bool bRes = false;
                        CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                        CDOCTOD doctoD = new CDOCTOD();
                        CDOCTOBE doctoBE = new CDOCTOBE();
                        CPERSONABE personaBE = new CPERSONABE();
                        personaBE.IID = CurrentUserID.CurrentUser.IID;
                        doctoBE.IID = docId;

                        doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                        if(doctoBE == null)
                        {

                            MessageBox.Show("La venta ya no existe");
                            return;
                        }

                        bRes = pvd.CancelarVenta(doctoBE, personaBE, null);
                        if(!bRes)
                        {
                            MessageBox.Show("hubo un error al cancelar la venta " + pvd.IComentario);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("La venta ha sido cancelada");
                            LlenarGrid();
                        }



                       


                    }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }




        private void ChecarCorteActivo()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            CorteAbrir corteForm_;
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                corteForm_ = new CorteAbrir();
                corteForm_.ShowDialog();
                corteForm_.Dispose();
                GC.SuppressFinalize(corteForm_);
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
                    this.Close();
                }

                if ((bool)corteBuffer.isnull["ITIPOCORTEID"] || corteBuffer.ITIPOCORTEID == DBValues._TIPO_CORTENORMAL)
                {


                    TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                    if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                    {

                        MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                        CorteCerrar cc_ = new CorteCerrar();
                        cc_.ShowDialog();
                        bool bCorteCerrado = cc_.m_bCorteCerrado;
                        cc_.Dispose();
                        GC.SuppressFinalize(cc_);

                        if (!bCorteCerrado)
                        {
                            //m_bSalirSinPreguntar = true;
                            this.Close();
                        }
                        else
                        {
                            corteForm_ = new CorteAbrir();
                            corteForm_.ShowDialog();
                            corteForm_.Dispose();
                            GC.SuppressFinalize(corteForm_);
                        }
                    }
                    else
                        return;
                }
                else
                {
                    return;
                }
            }


            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                this.Close();
            }
            else
            {

                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
