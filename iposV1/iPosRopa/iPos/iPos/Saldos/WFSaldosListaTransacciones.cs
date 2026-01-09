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
    public partial class WFSaldosListaTransacciones : IposForm
    {
        public long m_PersonaId = 0;


        public DataRow m_rtnDataRow;

        public int m_tipo, m_statusdocto, m_tipodoctoId;

        long? preseleccion_personaid = null;
        bool? preseleccion_corteactual = null;
        bool? preseleccion_porfecha = null;
        string preseleccion_referencia = null;

        bool bHabilitarLlenarGrid = true;

        public WFSaldosListaTransacciones()
        {
            InitializeComponent();
        }

        public WFSaldosListaTransacciones(int p_statusdocto, int p_tipodoctoId)
        {
            InitializeComponent();
            this.m_statusdocto = p_statusdocto;
            this.m_tipodoctoId = p_tipodoctoId;
          

        }


        public WFSaldosListaTransacciones(int p_statusdocto, int p_tipodoctoId, long? p_preseleccion_personaid, bool? p_preseleccion_corteactual, bool? p_preseleccion_porfecha):
            this(p_statusdocto, p_tipodoctoId)
        {

            preseleccion_personaid = p_preseleccion_personaid;
            preseleccion_corteactual = p_preseleccion_corteactual;
            preseleccion_porfecha = p_preseleccion_porfecha;


        }

        public WFSaldosListaTransacciones(int p_statusdocto, int p_tipodoctoId, long? p_preseleccion_personaid, bool? p_preseleccion_corteactual, bool? p_preseleccion_porfecha, string p_preseleccion_referencia) :
           this( p_statusdocto,  p_tipodoctoId,  p_preseleccion_personaid,  p_preseleccion_corteactual, p_preseleccion_porfecha)
        {
            preseleccion_referencia = p_preseleccion_referencia;
        }


            private void BTCliente_Click(object sender, EventArgs e)
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
                        iPos.Catalogos.WFClientes look = new iPos.Catalogos.WFClientes();
                        look.ShowDialog();

                        DataRow dr = look.m_rtnDataRow;

                        look.Dispose();
                        GC.SuppressFinalize(look);

                        if (dr != null)
                        {
                            this.LBCliente.Text = dr["CLAVE"].ToString().Trim();
                            m_PersonaId = (long)dr["ID"];

                            llenarDatosPersona();
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
                            llenarDatosPersona();
                        }
                    }
                    break;
            }
        }


        public void llenarDatosPersona()
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
            //this.tRANSACCIONES_LISTA_CONSALDOSTableAdapter.Fill(this.dSPuntoDeVentaAux.TRANSACCIONES_LISTA_CONSALDOS, this.m_tipodoctoId, this.m_statusdocto, "N", 0, clienteBE.IID, DateTime.Parse("1980-01-01"));

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


        private void tRANSACCIONES_LISTADataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }

        private void WFSaldosListaTransacciones_Load(object sender, EventArgs e)
        {

            string strBuffer = "";
            this.VENDEDORIDTextBox.DbValue = CurrentUserID.CurrentUser.IID.ToString();
            this.VENDEDORIDTextBox.MostrarErrores = false;
            this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
            this.VENDEDORIDTextBox.MostrarErrores = true;

            FormateaPantallaParaTipoDocto();

            bHabilitarLlenarGrid = false;

            if (preseleccion_corteactual != null && preseleccion_corteactual.HasValue)
            {
                CBCorteActual.Checked = preseleccion_corteactual.Value;
            }

            if (preseleccion_porfecha != null && preseleccion_porfecha.HasValue)
            {
                CBSoloFecha.Checked = preseleccion_porfecha.Value;
            }


            if (preseleccion_referencia != null && preseleccion_referencia.Trim().Length > 0)
            {
                CBReferencia.Checked = true;
                TBReferencia.Text = preseleccion_referencia;
            }


            if (this.preseleccion_personaid != null && preseleccion_personaid.HasValue)
            {
                m_PersonaId = preseleccion_personaid.Value;
                llenarDatosPersona();
            }



            bHabilitarLlenarGrid = true;

            LlenaGrid();
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
                    }
                    break;

                default:
                    {
                        this.lblPersona.Text = "Proveedor";
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
                this.lblListaTitle.Text += " pendientes con saldo";
            else
                this.lblListaTitle.Text += " completas con saldo";

        }



        private void LlenaGrid()
        {
            if (!bHabilitarLlenarGrid)
                return;

            int? p_statusdocto, p_cajero;
            long p_tipodoctoId;
            string p_referencia = CBReferencia.Checked ? TBReferencia.Text.Trim() : "";
            string p_ignorereferencia = CBReferencia.Checked ? "N" : "S";
            p_cajero = (this.CBCajerosTodos.Checked) ? 0 : Int32.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
            p_statusdocto = m_statusdocto;
            p_tipodoctoId = (this.m_tipodoctoId != DBValues._DOCTO_TIPO_VENTA) ? this.m_tipodoctoId : 0;


            DateTime? fechaQuery = DateTime.Parse("1980-01-01");
            if (CBSoloFecha.Checked)
                fechaQuery = DTPFecha.Value;

            this.tRANSACCIONES_LISTA_CONSALDOSTableAdapter.Fill(this.dSPuntoDeVentaAux.TRANSACCIONES_LISTA_CONSALDOS, p_tipodoctoId, p_statusdocto.Value, (CBCorteActual.Checked ? "S" : "N"), p_cajero.Value, m_PersonaId, fechaQuery.Value, p_referencia, p_ignorereferencia);

        }

        private void VENDEDORIDTextBox_Validated(object sender, EventArgs e)
        {

            LlenaGrid();
        }

        private void CBCajerosTodos_CheckedChanged(object sender, EventArgs e)
        {
            LlenaGrid();
        }

        private void CBCorteActual_CheckedChanged(object sender, EventArgs e)
        {
            LlenaGrid();
        }

        private void CBSoloFecha_CheckedChanged(object sender, EventArgs e)
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

        private void LBCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            LlenaGrid();
        }

        private void lblPersona_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
