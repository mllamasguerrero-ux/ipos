using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using iPosData;
using iPosBusinessEntity;

namespace iPos
{
    public partial class WFGuias : Form
    {
        public WFGuias()
        {
            InitializeComponent();
        }

        private void LlenarDatos()
        {
            try
            {


                Int64? p_encargado = 0;
                Int64? p_cajero = 0;
                Int64 p_estado = CBSoloPendientes.Checked ? -2 : -1;
                Int64? p_tipo = 0;
                Int64? p_id = 0;
                string p_guia = "";

                if (!CBEncargadosTodos.Checked)
                {
                    try
                    {
                        p_encargado = Int64.Parse(this.ENCARGADOIDTextBox.DbValue.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Seleccione un encargado valido");
                        return;
                    }
                }

                if (!CBCajerosTodos.Checked)
                {
                    try
                    {
                        p_cajero = Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Seleccione un cajero valido");
                        return;
                    }
                }



                if (!CBIDTodos.Checked)
                {
                    try
                    {
                        p_id = Int64.Parse(this.TBIDTextBox.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Seleccione un cajero valido");
                        return;
                    }
                }

                if (!CBTodasGuias.Checked)
                {
                    try
                    {
                        p_guia = GUIAPAQUETERIATextBox.Text;
                    }
                    catch
                    {
                        MessageBox.Show("Seleccione un cajero valido");
                        return;
                    }
                }

                if (CBTipo.SelectedIndex < 0)
                    p_tipo = 0;
                else
                    p_tipo = CBTipo.SelectedIndex;


                this.gUIATableAdapter.Fill(this.dSGuia.GUIA, this.DTPFechaIni.Value, this.DTPFechaFin.Value, p_cajero.Value, p_encargado.Value, p_estado,p_tipo.Value,p_guia, p_id.Value);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            LlenarDatos();
        }

        private void btnAgregarGuia_Click(object sender, EventArgs e)
        {
            Guia.WFGuiasEdicion wf = new Guia.WFGuiasEdicion();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
            LlenarDatos();
        }

        private void WFGuias_Load(object sender, EventArgs e)
        {
            if (!ChecarCorteActivo())
                return;

            LlenarDatos();
        }

        private void gUIADataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (gUIADataGridView.Columns[e.ColumnIndex].Name == "DGEDITAR")
                {
                    long guiaId = long.Parse(gUIADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    
                    iPos.Guia.WFGuiasEdicion wf = new iPos.Guia.WFGuiasEdicion("Cambiar", guiaId);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                    LlenarDatos();
                }
                
                else if(gUIADataGridView.Columns[e.ColumnIndex].Name == "DGCANCELAR")
                {
                    if (MessageBox.Show("Realmente desea cancelar la guia?",
                                "Confirmacion",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CGUIAD guiaDao = new CGUIAD();
                        CGUIABE guia = new CGUIABE();
                        long guiaId = long.Parse(gUIADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                        guia.IID = guiaId;

                        FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                        FbTransaction fTrans = null;
                        try
                        {
                            fConn.Open();
                            fTrans = fConn.BeginTransaction();

                            //ante cualquier return o error

                            if (!guiaDao.GUIA_CANCEL(guia, null))
                            {
                                fTrans.Rollback();
                                fConn.Close();

                                MessageBox.Show("Problema al llevar a cabo el proceso, llame a soporte.");
                                return;
                            }
                            else
                            {
                                fTrans.Commit();
                                fConn.Close();
                                MessageBox.Show("Proceso finalizado con exito");

                                this.LlenarDatos();
                               // this.Close();
                            }
                        }
                        catch
                        {
                            try
                            {
                                fTrans.Rollback();
                                fConn.Close();
                            }
                            catch
                            {
                                fTrans.Rollback();
                                fConn.Close();
                            }

                        }
                        finally
                        {
                            fConn.Close();
                        }
                    }
                }

                else if (gUIADataGridView.Columns[e.ColumnIndex].Name == "DGRECIBIR")
                {
                    long guiaId = long.Parse(gUIADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    
                    iPos.Guia.WFGuiasEdicion wf = new iPos.Guia.WFGuiasEdicion("Recibir", guiaId);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);

                    LlenarDatos();
                }
                else if (gUIADataGridView.Columns[e.ColumnIndex].Name == "DGCARTACORTE")
                {
                    long guiaId = long.Parse(gUIADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());

                    iPos.Guia.WFGuiasEdicion wf = new iPos.Guia.WFGuiasEdicion("CartaCorte", guiaId);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);

                    LlenarDatos();
                }
            }
        }

        private void ENCARGADOIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private bool ChecarCorteActivo()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            //CorteAbrir corteForm;
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
    }
}
