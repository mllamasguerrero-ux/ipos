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
    public partial class WFMovilVisita : IposForm
    {

        long m_ClienteId = 0;
        CVISITABE m_visitaBE = null;
        bool bEsInicioVisita = true;

        public WFMovilVisita()
        {
            InitializeComponent();
        }

        private void BTCliente_Click(object sender, EventArgs e)
        {

            iPos.Catalogos.WFClientes look = new iPos.Catalogos.WFClientes();
            look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.LBCliente.Text = dr["CLAVE"].ToString().Trim();
                m_ClienteId = (long)dr["ID"];
                llenarDatosCliente();
            }
        }



        public void llenarDatosCliente()
        {
            CPERSONAD clienteD = new CPERSONAD();
            CPERSONABE clienteBE = new CPERSONABE();
            clienteBE.IID = m_ClienteId;
            clienteBE = clienteD.seleccionarPERSONA(clienteBE, null);

            if (clienteBE != null)
            {
                LBCliente.Text = clienteBE.ICLAVE;
                lbClieNombre.Text = ((bool)clienteBE.isnull["INOMBRE"]) ? "" : clienteBE.INOMBRE;

            }
            else
            {

                lbClieNombre.Text = "";
            }

        }

        private void WFMovilVisita_Load(object sender, EventArgs e)
        {
            CVISITAD visitaD = new CVISITAD();
            CVISITABE visitaBE = new CVISITABE();
            visitaBE = visitaD.seleccionarULTIMAVISITA(null);
            if(visitaBE == null || visitaBE.IACTIVO == null || visitaBE.IACTIVO.Equals("N") || (!(bool)visitaBE.isnull["IHORAFIN"] && visitaBE.IHORAFIN != null) || (visitaBE.IENVIADOWS != null && visitaBE.IENVIADOWS.Equals("S")))
            {
                bEsInicioVisita = true;
                this.DTPFechaInicio.Value = DateTime.Now;

            }
            else
            {

                m_visitaBE = visitaBE;
                this.DTPFechaInicio.Value = m_visitaBE.IHORAINICIO;
                this.DTPFechaFin.Value = DateTime.Now;
                this.m_ClienteId = m_visitaBE.IPERSONAID;
                this.llenarDatosCliente();

                bEsInicioVisita = false;
            }

            this.pnlFinVisita.Enabled = !bEsInicioVisita;
            this.pnlInicioVisita.Enabled = bEsInicioVisita;

        }



        private void btnEnviarInicio_Click(object sender, EventArgs e)
        {
            if (m_ClienteId == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }

            if (MessageBox.Show("Esta seguro de que desea iniciar la visita", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            CVISITAD visitaD = new CVISITAD();
            CVISITABE visitaBE = new CVISITABE();
            visitaBE.IPERSONAID = m_ClienteId;
            visitaBE.IFECHA = this.DTPFechaInicio.Value;
            visitaBE.IHORAINICIO = this.DTPFechaInicio.Value;
            visitaBE.IACTIVO = "S";
            visitaBE.IPERSONACLAVE = LBCliente.Text;
            visitaBE.IHIZOPEDIDO = "N";
            visitaBE.IENVIADOWS = "N";

            visitaBE = visitaD.AgregarVISITAD(visitaBE, null);
            if (visitaBE == null)
            {
                MessageBox.Show("Ocurrio un error : " + visitaD.IComentario);
            }
            else
            {
                MessageBox.Show("Se registro el inicio de la cita");
                this.Close();
            }
        }

        private void btnEnviarFin_Click(object sender, EventArgs e)
        {
            m_visitaBE.IHORAFIN = this.DTPFechaFin.Value;
            m_visitaBE.IHIZOPEDIDO = this.CBHizoPedido.Checked ? "S" : "N";


            CVISITAD visitaD = new CVISITAD();

            bool bRes = visitaD.finalizarVISITAD(m_visitaBE, m_visitaBE, null);

            if (!bRes)
            {
                MessageBox.Show("Ocurrio un error : " + visitaD.IComentario);
            }
            else
            {
                MessageBox.Show("Se registro el fin de la cita");
                this.Close();
            }


        }


        private void btnCancelarVisita_Click(object sender, EventArgs e)
        {

            CVISITAD visitaD = new CVISITAD();

            bool bRes = visitaD.CancelarVISITAD(m_visitaBE, null);

            if (!bRes)
            {
                MessageBox.Show("Ocurrio un error : " + visitaD.IComentario);
            }
            else
            {
                MessageBox.Show("Se registro el fin de la cita");
                this.Close();
            }
        }


    }
}
