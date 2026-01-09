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

namespace iPos
{
    public partial class WFSeleccionParaDevolucion : IposForm
    {
        public long m_PersonaId = 0;


        public DataRow m_rtnDataRow;

        public int m_tipo, m_statusdocto = (int)DBValues._DOCTO_ESTATUS_COMPLETO, m_tipodoctoId = (int)DBValues._DOCTO_TIPO_VENTA;

        public bool m_bPermisoDevolverSinVenta = true;

        bool m_manejaAlmacen = false;
        bool m_usuarioPuedeCambiarAlmacen = false;
        private bool m_loadingForm = true;

        public WFSeleccionParaDevolucion()
        {
            InitializeComponent();
        }

        public WFSeleccionParaDevolucion(int tipodoctoid, int statusdocto, bool bPermisoDevolverSinVenta)
            : this()
        {
            this.m_tipodoctoId = tipodoctoid;
            this.m_statusdocto = statusdocto;
            this.m_bPermisoDevolverSinVenta = bPermisoDevolverSinVenta;
        }

        private void FormateaPantallaParaTipoDocto()
        {
            switch (this.m_tipodoctoId)
            {
                case 0:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                    {
                        this.lblPersona.Text = "Cliente";
                        this.BTDevolucionXCliente.Text = "Devolución general por CLIENTE";
                    }
                    break;

                default:
                    {
                        this.lblPersona.Text = "Proveedor";
                        this.BTDevolucionXCliente.Text = "Devolución general por PROVEEDOR";
                    }
                    break;
            }



            switch (this.m_tipodoctoId)
            {
                case (int)DBValues._DOCTO_TIPO_VENTA:
                    this.lblListaTitle.Text = "Lista de ventas ";
                    break;
                case (int)DBValues._DOCTO_TIPO_COMPRA:
                    this.lblListaTitle.Text = "Lista de compras";
                    break;
                case (int)DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO:
                    this.lblListaTitle.Text = "Lista de notas de credito";
                    break;
                case (int)DBValues._DOCTO_TIPO_COMPRA_DEVO:
                    this.lblListaTitle.Text = "Lista de devoluciones de compra";
                    break;
                default:
                    this.lblListaTitle.Text = "Lista de ventas";
                    break;
            }

            if (m_statusdocto == DBValues._DOCTO_ESTATUS_BORRADOR)
                this.lblListaTitle.Text += " pendientes ";
            else
                this.lblListaTitle.Text += " completas ";

        }

        private void AsignaEstatusBotonTransaccionGeneral()
        {
            if (this.m_PersonaId != 0)
                this.BTDevolucionXCliente.Enabled = true;
            else
                this.BTDevolucionXCliente.Enabled = false;

        }

        private void BTCliente_Click(object sender, EventArgs e)
        {
        //    iPos.Catalogos.WFClientes look = new iPos.Catalogos.WFClientes();
        //    look.ShowDialog();

        //    DataRow dr = look.m_rtnDataRow;
        //    if (dr != null)
        //    {
        //        this.LBCliente.Text = dr["CLAVE"].ToString().Trim();
        //        m_PersonaId = (long)dr["ID"];

        //        llenarDatosCliente();
        //    }
        //    look.Dispose();




            switch (this.m_tipodoctoId)
            {
                case 0:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                    {
                        iPos.Catalogos.WFClientes look = new iPos.Catalogos.WFClientes();
                        look.ShowDialog();

                        DataRow dr = look.m_rtnDataRow;

                        look.Dispose();
                        GC.SuppressFinalize(look);

                        if (dr != null)
                        {
                            this.LBCliente.Text = dr["CLAVE"].ToString().Trim();
                            m_PersonaId = (long)dr["ID"];

                            llenarDatosCliente();
                        }
                    }
                    break;

                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    {
                        iPos.Catalogos.WFProveedores look = new iPos.Catalogos.WFProveedores();
                        look.ShowDialog();

                        DataRow dr = look.m_rtnDataRow;

                        look.Dispose();
                        GC.SuppressFinalize(look);

                        if (dr != null)
                        {
                            this.LBCliente.Text = dr["CLAVE"].ToString().Trim();
                            m_PersonaId = (long)dr["ID"];

                            llenarDatosCliente();
                        }
                    }
                    break;
            }
            AsignaEstatusBotonTransaccionGeneral();

        }


        public void llenarDatosCliente()
        {
            CPERSONAD clienteD = new CPERSONAD();
            CPERSONABE clienteBE = new CPERSONABE();
            clienteBE.IID = m_PersonaId;
            clienteBE = clienteD.seleccionarPERSONA(clienteBE, null);
            if (clienteBE != null)
            {

                lbClieCiudad.Text = ((bool)clienteBE.isnull["ICIUDAD"]) ? "" : clienteBE.ICIUDAD;
                lbClieColonia.Text = ((bool)clienteBE.isnull["ICOLONIA"]) ? "" : clienteBE.ICOLONIA;
                lbClieCP.Text = ((bool)clienteBE.isnull["ICODIGOPOSTAL"]) ? "" : clienteBE.ICODIGOPOSTAL;
                lbClieDom.Text = ((bool)clienteBE.isnull["IDOMICILIO"]) ? "" : clienteBE.IDOMICILIO;
                lbClieEstado.Text = ((bool)clienteBE.isnull["IESTADO"]) ? "" : clienteBE.IESTADO;
                lbClieNombre.Text = ((bool)clienteBE.isnull["INOMBRE"]) ? "" : clienteBE.INOMBRE;
                lbClieRFC.Text = ((bool)clienteBE.isnull["IRFC"]) ? "" : clienteBE.IRFC;
                lbClieTel.Text = ((bool)clienteBE.isnull["ITELEFONO1"]) ? "" : clienteBE.ITELEFONO1;

                LBCliente.Text = clienteBE.ICLAVE;

            }
            else
            {

                lbClieCiudad.Text = "";
                lbClieColonia.Text = "";
                lbClieCP.Text = "";
                lbClieDom.Text = "";
                lbClieEstado.Text = "";
                lbClieNombre.Text = "";
                lbClieRFC.Text = "";
                lbClieTel.Text = "";
            }

            LlenaGrid();

        }

        private void tRANSACCIONES_LISTADataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
                RetornarSeleccion(false);
        }


        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex = tRANSACCIONES_LISTADataGridView.CurrentRow.Index;
                DataGridViewRow dr = tRANSACCIONES_LISTADataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

        private void BTDevolucionXCliente_Click(object sender, EventArgs e)
        {
            m_rtnDataRow = null;
            this.Close();
        }

        private void tRANSACCIONES_LISTADataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }

        private void WFSeleccionParaDevolucion_Load(object sender, EventArgs e)
        {
            

            string strBuffer = "";
            this.VENDEDORIDTextBox.DbValue = CurrentUserID.CurrentUser.IID.ToString();
            this.VENDEDORIDTextBox.MostrarErrores = false;
            this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
            this.VENDEDORIDTextBox.MostrarErrores = true;

            this.DTPFechaFin.Value = DateTime.Today;
            this.DTPFecha.Value = DateTime.Today.AddDays(-120);


            //ALMACENES
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            m_manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));
            if (!this.m_manejaAlmacen)
            {
                CBAlmacenesTodos.Checked = true;
                pnlAlmacen.Visible = false;
            }
            else
            {
                m_usuarioPuedeCambiarAlmacen = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_FILTARPORALMACEN, null);
                pnlAlmacen.Visible = true;
                pnlAlmacen.Enabled = m_usuarioPuedeCambiarAlmacen;
                this.ALMACENComboBox.llenarDatos();
                SetDefaultAlmacenEstatus();
            }



            FormateaPantallaParaTipoDocto();
            AsignaEstatusBotonTransaccionGeneral();

            m_loadingForm = false;

            LlenaGrid();
        }


        public void SetDefaultAlmacenEstatus()
        {


            if (!(bool)CurrentUserID.CurrentUser.isnull["IALMACENID"])
                this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID;
            else
                this.ALMACENComboBox.SelectedDataValue = DBValues._ALMACEN_DEFAULT;

        }

        private void LlenaGrid()
        {
            if (m_loadingForm)
                return ;


            int? p_statusdocto, p_cajero;
            long p_tipodoctoId;
            long p_almacenid = (this.CBAlmacenesTodos.Checked) ? 0 : Int32.Parse(this.ALMACENComboBox.SelectedDataValue.ToString());
            p_cajero = (this.CBCajerosTodos.Checked) ? 0 : Int32.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
            p_statusdocto = m_statusdocto;
            p_tipodoctoId = this.m_tipodoctoId;//(this.m_tipodoctoId != DBValues._DOCTO_TIPO_VENTA) ? this.m_tipodoctoId : 0;


            DateTime? fechaQuery = DateTime.Parse("1980-01-01");
            DateTime? fechaFinQuery = DateTime.Parse("2200-01-01");
            if (CBSoloFecha.Checked)
            {
                fechaQuery = DTPFecha.Value;
                fechaFinQuery = DTPFechaFin.Value;
            }
            this.tRANSACCIONES_LISTATableAdapter.Fill(this.dSPuntoDeVentaAux.TRANSACCIONES_LISTA, p_statusdocto.Value, p_tipodoctoId, (CBCorteActual.Checked ? "S" : "N"), p_cajero.Value, fechaQuery.Value, fechaFinQuery.Value, m_PersonaId, p_almacenid);
        }

        private void CBCajerosTodos_CheckedChanged(object sender, EventArgs e)
        {
            LlenaGrid();
        }

        private void CBCorteActual_CheckedChanged(object sender, EventArgs e)
        {
            LlenaGrid();
        }

        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        {
            if (CBSoloFecha.Checked)
            {
                LlenaGrid();
            }
        }

        private void VENDEDORIDTextBox_Validated(object sender, EventArgs e)
        {

            LlenaGrid();
        }

        private void CBSoloFecha_CheckedChanged(object sender, EventArgs e)
        {
            LlenaGrid();

        }

        private void DTPFechaFin_ValueChanged(object sender, EventArgs e)
        {

            if (CBSoloFecha.Checked)
            {
                LlenaGrid();
            }
        }


        private void CBAlmacenesTodos_CheckedChanged(object sender, EventArgs e)
        {

            LlenaGrid();
        }

        private void ALMACENComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            LlenaGrid();
        }



        /*private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                object PERSONAID = new object();
                object ESTATUSDOCTOID = new object();
                object TIPODOCTOID = new object();
                object CORTEACTIVO = new object();
                this.tRANSACCIONES_LISTATableAdapter.Fill(this.dSPuntoDeVentaAux.TRANSACCIONES_LISTA, PERSONAID, ESTATUSDOCTOID, TIPODOCTOID, CORTEACTIVO, cAJEROIDToolStripTextBox.Text, fECHAToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/
    }
}
