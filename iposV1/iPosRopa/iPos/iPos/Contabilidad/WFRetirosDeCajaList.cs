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
    public partial class WFRetirosDeCajaList : Form
    {
        int m_statusdocto = 1;
        public WFRetirosDeCajaList()
        {
            InitializeComponent();
        }

        private bool LlenarGrid()
        {
           

            try
            {
                int? p_statusdocto, p_cajero;
                p_cajero =  (this.CBCajerosTodos.Checked) ? 0 : Int32.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
                p_statusdocto = m_statusdocto;


                DateTime? fechaQuery = DateTime.Parse("1980-01-01");
                fechaQuery = DTPFecha.Value;


                switch (ComboEstado.SelectedIndex)
                {
                    case 0: p_statusdocto = -1; break;
                    case 1: p_statusdocto = 1; break;
                    case 2: p_statusdocto = 0; break;
                    case 3: p_statusdocto = 2; break;
                    default: p_statusdocto = -1; break;
                }

                this.rETIROSCAJATableAdapter.Fill(this.dSContabilidad.RETIROSCAJA, p_statusdocto, p_cajero.Value,fechaQuery, (CBCorteActual.Checked ? "S" : "N"));


               /* if (this.dSContabilidad.RETIROSCAJA.Rows.Count <= 0)
                {
                    MessageBox.Show("No hay registros");
                    return false;
                }*/
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

            return true;

        }

        private void btnAgregarRetiroCaja_Click(object sender, EventArgs e)
        {
            WFRetiroCaja wf = new WFRetiroCaja();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
            LlenarGrid();
        }

        private void btnMostrarRegistros_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void WFRetirosDeCajaList_Load(object sender, EventArgs e)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_RETIROCAJA_CORTE, null))
            {
                this.pnlCorteActual.Enabled = false;

            }



            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_RETIROCAJA_CAJEROS, null))
            {
                this.pnlCajero.Enabled = true;
            }
            else
            {
                this.pnlCajero.Enabled = false;
            }


            string strBuffer = "";
            this.VENDEDORIDTextBox.DbValue = CurrentUserID.CurrentUser.IID.ToString();
            this.VENDEDORIDTextBox.MostrarErrores = false;
            this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
            this.VENDEDORIDTextBox.MostrarErrores = true;


            ComboEstado.SelectedIndex = 1;

            LlenarGrid();
        }

        private void rETIROSCAJADataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 )
            {

                if (rETIROSCAJADataGridView.Columns[e.ColumnIndex].Name == "DGCANCELAR")
                {
                    long estatusDoctoId = long.Parse(rETIROSCAJADataGridView.Rows[e.RowIndex].Cells["DGESTATUSDOCTOID"].Value.ToString());

                    DateTime? fecha = null;

                    try
                    {
                        fecha = DateTime.Parse(rETIROSCAJADataGridView.Rows[e.RowIndex].Cells["DGFECHA"].Value.ToString());

                    }
                    catch
                    {

                    }

                    if(fecha == null)
                    {
                        return;
                    }



                    if(estatusDoctoId != DBValues._DOCTO_ESTATUS_COMPLETO)
                    {
                        return;
                    }


                    if (MessageBox.Show("Esta seguro de cancelar el retiro ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                        ps2.ShowDialog();
                        CPERSONABE userBE = ps2.m_userBE;
                        bool bPassValido = ps2.m_bPassValido;
                        bool bIsSupervisor = ps2.m_bIsSupervisor;
                        bool bIsAdministrador = ps2.m_bIsAdministrador;
                        ps2.Dispose();
                        GC.SuppressFinalize(ps2);

                        if (!bPassValido)
                            return ;

                        if (!bIsSupervisor)
                        {
                            MessageBox.Show("El usuario no es un supervisor");
                            return ;
                        }


                        if (bIsSupervisor && fecha < DateTime.Today.AddDays(-1) && !bIsAdministrador)
                        {
                            MessageBox.Show("Un supervisor solo puede eliminar retiros del dia actual y anterior. Se requiere un administrador para borrar de fechas previas");
                            return ;
                        }

                        long doctoId = long.Parse(rETIROSCAJADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                        CancelarRetiroDeCaja(doctoId);
                    }
                    //MostrarRegistro("Consultar");
                }
                else if (rETIROSCAJADataGridView.Columns[e.ColumnIndex].Name == "DGEDITAR")
                {
                    long estatusDoctoId = long.Parse(rETIROSCAJADataGridView.Rows[e.RowIndex].Cells["DGESTATUSDOCTOID"].Value.ToString());

                    DateTime? fecha = null;

                    try
                    {
                        fecha = DateTime.Parse(rETIROSCAJADataGridView.Rows[e.RowIndex].Cells["DGFECHA"].Value.ToString());

                    }
                    catch
                    {

                    }

                    if(fecha == null)
                    {
                        return;
                    }



                    if(estatusDoctoId != DBValues._DOCTO_ESTATUS_COMPLETO)
                    {
                        return;
                    }


                    if (MessageBox.Show("Esta seguro de editar el retiro ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                        ps2.ShowDialog();
                        CPERSONABE userBE = ps2.m_userBE;
                        bool bPassValido = ps2.m_bPassValido;
                        bool bIsSupervisor = ps2.m_bIsSupervisor;
                        bool bIsAdministrador = ps2.m_bIsAdministrador;
                        ps2.Dispose();
                        GC.SuppressFinalize(ps2);

                        if (!bPassValido)
                            return ;

                        if (!bIsSupervisor)
                        {
                            MessageBox.Show("El usuario no es un supervisor");
                            return ;
                        }


                        if (bIsSupervisor && fecha < DateTime.Today.AddDays(-1) && !bIsAdministrador)
                        {
                            MessageBox.Show("Un supervisor solo puede editar retiros del dia actual y anterior. Se requiere un administrador para borrar de fechas previas");
                            return ;
                        }

                        long doctoId = long.Parse(rETIROSCAJADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                        WFRetiroCaja wf = new WFRetiroCaja(doctoId);
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);
                        LlenarGrid();
                    }
                    

                }
                else if (rETIROSCAJADataGridView.Columns[e.ColumnIndex].Name == "DGCONSULTAR")
                {

                    // long doctoId = long.Parse(rETIROSCAJADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    // CancelarRetiroDeCaja(doctoId);

                    long doctoId = long.Parse(rETIROSCAJADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    WFRetiroCaja wf = new WFRetiroCaja(doctoId, "Consultar");
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                    LlenarGrid();

                }
            }
        }

        private bool CancelarRetiroDeCaja(long doctoId)
        {
            CRETIRODECAJAD retiroD = new CRETIRODECAJAD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE.IVENDEDORID = CurrentUserID.CurrentUser.IID;
            if(!retiroD.RETIRO_CAJA_CANCEL(doctoBE, null))
            {
                MessageBox.Show(retiroD.IComentario);
            }
            else
            {
                MessageBox.Show("Se cancelo el registro");
                LlenarGrid();
            }
            return true;
        }

        private void btnAgregarRetiroOtroCajero_Click(object sender, EventArgs e)
        {

            long autorizoId = CurrentUserID.CurrentUser.IID;

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_AGREGARRETIRO_OTROCAJERO, null))
            {

                WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                ps2.m_requiereAdminOrSupervisor = false;
                ps2.ShowDialog();
                CPERSONABE userBE = ps2.m_userBE;
                bool bPassValido = ps2.m_bPassValido;
                bool bIsSupervisor = ps2.m_bIsSupervisor;
                bool bIsAdministrador = ps2.m_bIsAdministrador;
                ps2.Dispose();
                GC.SuppressFinalize(ps2);

                if (!bPassValido || userBE != null)
                {
                    return;
                }

                if (!usuariosD.UsuarioTienePermisos((int)userBE.IID, (int)DBValues._DERECHO_AGREGARRETIRO_OTROCAJERO, null))
                {
                    MessageBox.Show("El usuario ingresado no tiene tampoco el derecho de editar un retiro de otro cajero");
                    return;
                }
                autorizoId = userBE.IID;



            }



            WFRetiroCaja wf = new WFRetiroCaja(true, autorizoId);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
            LlenarGrid();
        }
    }
}
