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
using System.Collections;

namespace iPos
{
    public partial class WFRecibosListaTransacciones : IposForm
    {
        public long m_PersonaId = 0;


        public DataRow m_rtnDataRow;

        public int m_tipo, m_statusdocto, m_tipodoctoId;

        public List<long> m_selectedTransactions = new List<long>();

        public WFRecibosListaTransacciones()
        {
            InitializeComponent();
        }

        public WFRecibosListaTransacciones(int p_statusdocto, int p_tipodoctoId, long personaId)
        {
            InitializeComponent();
            this.m_statusdocto = p_statusdocto;
            this.m_tipodoctoId = p_tipodoctoId;
            m_PersonaId = personaId;
          

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

                //LBCliente.Text = clienteBE.ICLAVE;

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

            //if (e.RowIndex != -1)
            //    RetornarSeleccion(false);
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

            //if (e.KeyCode == Keys.Enter)
            //    RetornarSeleccion(true);
        }

        private void WFRecibosListaTransacciones_Load(object sender, EventArgs e)
        {

            if (m_PersonaId != 0)
            {
                LlenaGrid();
                llenarDatosPersona();
            }
        }


        private void LlenaGrid()
        {


            int? p_statusdocto, p_cajero;
            long p_tipodoctoId;
            p_cajero = 0;
            p_statusdocto = m_statusdocto;
            p_tipodoctoId = (this.m_tipodoctoId != DBValues._DOCTO_TIPO_VENTA) ? this.m_tipodoctoId : 0;


            DateTime? fechaQuery = DateTime.Parse("1980-01-01");

            this.tRANSACCIONES_LISTA_CONSALDOS_CRTableAdapter.Fill(this.dSPuntoDeVentaAux.TRANSACCIONES_LISTA_CONSALDOS_CR, p_tipodoctoId, p_statusdocto.Value,  "N" , p_cajero.Value, m_PersonaId, fechaQuery.Value,"","S");

        }

        private void BtnListaTransacciones_Click(object sender, EventArgs e)
        {
            m_selectedTransactions = new List<long>();

            bool bHaySeleccionados = false;

            foreach (DataGridViewRow row in tRANSACCIONES_LISTADataGridView.Rows)
            {
                if (row.Index == tRANSACCIONES_LISTADataGridView.NewRowIndex)
                {
                    continue;
                }
                try
                {
                    if ((bool)row.Cells["DGCHECK"].Value)
                    {
                        long doctoId = long.Parse(row.Cells["CONSECUTIVO"].Value.ToString());
                        m_selectedTransactions.Add(doctoId);
                        bHaySeleccionados = true;
                    }
                }
                catch
                {
                }
            }

            if (bHaySeleccionados)
                this.Close();
        }

        
        
        

    }
}
