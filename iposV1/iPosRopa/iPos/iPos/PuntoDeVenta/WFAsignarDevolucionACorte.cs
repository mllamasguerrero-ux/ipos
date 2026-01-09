using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public partial class WFAsignarDevolucionACorte : Form
    {
        CDOCTOBE m_Docto;
        CDOCTOBE m_Docto_ref;
        long m_ClienteId;

        bool m_bTieneDerechoReasignarNCUnMismoDia = true;
        bool m_bTieneDerechoReasignarNCUnDiaAnterior = false;
        bool m_bTieneDerechoReasignarNCCualquierDiaAnterior = false;


        long m_tipoDoctoId = DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO;

        public WFAsignarDevolucionACorte()
        {
            InitializeComponent();
            m_Docto = new CDOCTOBE();
            m_Docto_ref = new CDOCTOBE();
        }
        public WFAsignarDevolucionACorte(long tipoDoctoId) : this()
        {
            m_tipoDoctoId = tipoDoctoId;
        }

        public WFAsignarDevolucionACorte(CDOCTOBE docto) : this()
        {
            m_Docto = docto;
            m_tipoDoctoId = docto.ITIPODOCTOID;

            LlenarDoctoRef();

        }

        private void LlenarDoctoRef()
        {
            m_Docto_ref = new CDOCTOBE();

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto_ref = new CDOCTOBE();
            m_Docto_ref.IID = m_Docto.IDOCTOREFID;
            m_Docto_ref = doctoD.seleccionarDOCTO(m_Docto_ref, null);

            if(m_Docto_ref == null)
                m_Docto_ref = new CDOCTOBE();

        }


        private void WFAsignarDevolucionACorte_Load(object sender, EventArgs e)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();

            if(m_tipoDoctoId == DBValues._DOCTO_TIPO_CANCELACION)
            {
                m_bTieneDerechoReasignarNCUnMismoDia = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_APLICARCANC_MISMODIA, null);
                m_bTieneDerechoReasignarNCUnDiaAnterior = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_APLICARCANC_DIAANTERIOR, null);
                m_bTieneDerechoReasignarNCCualquierDiaAnterior = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_APLICARCANC_CUALQUIERDIAANTES, null);

            }
            else
            {
                m_bTieneDerechoReasignarNCUnMismoDia = true;
                m_bTieneDerechoReasignarNCUnDiaAnterior = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_APLICARNC_DIAANTERIOR, null);
                m_bTieneDerechoReasignarNCCualquierDiaAnterior = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_APLICARNC_CUALQUIERDIAANTES, null);

            }
            if ( !m_bTieneDerechoReasignarNCUnMismoDia &&  !m_bTieneDerechoReasignarNCUnDiaAnterior && !m_bTieneDerechoReasignarNCCualquierDiaAnterior)
            {
                MessageBox.Show("No tiene derecho para hacer transacciones en este formulario");
                this.Close();
            }

            this.CBCajero.llenarDatos();

            if(m_Docto != null && m_Docto.IID > 0)
            {
                LlenarDatosDocto();
            }


            if (m_tipoDoctoId == DBValues._DOCTO_TIPO_CANCELACION)
            {
                RB_MISMOVENTA.Checked = true;
                RB_MISMOVENTA_FECHA.Checked = true;
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

        }


        private void Limpiar()
        {


            lbClieCiudad.Text = "";
            lbClieColonia.Text = "";
            lbClieCP.Text = "";
            lbClieDom.Text = "";
            lbClieEstado.Text = "";
            lbClieNombre.Text = "";
            lbClieRFC.Text = "";
            lbClieTel.Text = "";

            this.lblFolio.Text = "";
            this.lblFecha.Text = "";
            this.lblTotal.Text = "";
            this.lblSaldo.Text = "";
            this.lblFolioFacturado.Text = "";

        }



        public void llenarDatosTransaccion()
        {
            if (!(bool)m_Docto.isnull["IID"])
            {
                if (!(bool)m_Docto.isnull["IFOLIO"])
                {
                    this.lblFolio.Text = m_Docto.IFOLIO.ToString();
                }
                if (!(bool)m_Docto.isnull["IFECHA"])
                {
                    this.lblFecha.Text = m_Docto.IFECHA.ToString("dd/MM/yyyy");
                }
                if (!(bool)m_Docto.isnull["ITOTAL"])
                {
                    this.lblTotal.Text = m_Docto.ITOTAL.ToString("SALDO");
                }
                if (!(bool)m_Docto.isnull["ISALDO"])
                {
                    this.lblSaldo.Text = (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_ANTICIPO_CLIENTES || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_ANTICIPO_PROVEEDORES) ? (m_Docto.ISALDO * -1).ToString() : m_Docto.ISALDO.ToString();
                }
                if (!(bool)m_Docto.isnull["IFOLIOORIGENFACTURADO"])
                {
                    this.lblFolioFacturado.Text = m_Docto.IFOLIOORIGENFACTURADO.ToString();
                }

            }
        }

        private void LlenarDatosDocto()
        {
            CDOCTOD vData = new CDOCTOD();
            m_Docto = vData.seleccionarDOCTO(m_Docto, null);
            m_ClienteId = m_Docto.IPERSONAID;
            llenarDatosCliente();
            llenarDatosTransaccion();

        }

        private void btnListaTransaccione_Click(object sender, EventArgs e)
        {

            WFSeleccionParaDevolucion look = new WFSeleccionParaDevolucion((int)m_tipoDoctoId, -1, true);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                Limpiar();

                m_Docto = new CDOCTOBE();
                m_Docto.IID = int.Parse(dr[0].ToString());

                LlenarDatosDocto();
                LlenarDoctoRef();

                this.BTReAsignarCorte.Enabled = true;

            }
        }

        private void BTReAsignarCorte_Click(object sender, EventArgs e)
        {
            long vendedorId = 0;
            string opcionVendedor = "MISMONC";
            string opcionFecha = "ESPECIFICO";


            if (m_Docto == null || m_Docto.IID == 0 )
            {
                MessageBox.Show("Primero seleccione una transaccion");
                return;
            }


            if (RB_ESPECIFICO.Checked && CBCajero.SelectedIndex < 0)
            {

                MessageBox.Show("Si selecciono que sera un vendedor especifico tiene que seleccionarlo");
                return;
            }

            if(RB_MISMONC.Checked)
            {

                vendedorId = 0;
                opcionVendedor = "MISMONC";
            }
            else if(RB_MISMOVENTA.Checked)
            {

                vendedorId = 0;
                opcionVendedor = "MISMOVENTA";
            }
            else if(RB_ESPECIFICO.Checked)
            {
                vendedorId = long.Parse(CBCajero.SelectedValue.ToString());
                opcionVendedor = "ESPECIFICO";
            }
            else
            {

                MessageBox.Show("Seleccione una opcion de vendedor");
                return;
            }



            if (RB_MISMONC_FECHA.Checked)
            {

                opcionFecha = "MISMONC";
            }
            else if (RB_MISMOVENTA_FECHA.Checked)
            {

                opcionFecha = "MISMOVENTA";
            }
            else if (RB_ESPECIFICO_FECHA.Checked)
            {
                opcionFecha = "ESPECIFICO";
            }
            else
            {

                MessageBox.Show("Seleccione una opcion de fecha");
                return;
            }


            DateTime fechaACalcular = m_Docto_ref != null && m_Docto_ref.IID > 0 && opcionFecha == "MISMOVENTA" ? m_Docto_ref.IFECHA :
                                       (m_Docto != null && m_Docto.IID > 0 && opcionFecha == "MISMONC" ? m_Docto.IFECHA : DTFecha.Value);



            if (fechaACalcular > DateTime.Today)
            {
                MessageBox.Show("Debe de seleccionar de una fecha igual o anterior al dia de hoy ");
                return;
            }

            if (fechaACalcular == DateTime.Today && !m_bTieneDerechoReasignarNCUnMismoDia)
            {
                MessageBox.Show("No tiene permiso para asignar esta transaccion a la fecha de hoy");
                return;
            }

            if (fechaACalcular == DateTime.Today.AddDays(-1) && !m_bTieneDerechoReasignarNCUnDiaAnterior && !m_bTieneDerechoReasignarNCCualquierDiaAnterior)
            {
                MessageBox.Show("No tiene permiso para asignar esta transaccion a la fecha de ayer");
                return;
            }

            if (fechaACalcular < DateTime.Today.AddDays(-1) && !m_bTieneDerechoReasignarNCCualquierDiaAnterior)
            {

                MessageBox.Show("No tiene permiso para asigar una nota de credito a una fecha anterior a ayer");
                return;
            }


            CDOCTOD doctoD = new CDOCTOD();

            if(!doctoD.DEVO_REASIGNARCORTEYFECHA(m_Docto.IID,DTFecha.Value, vendedorId , opcionVendedor, opcionFecha,null))
            {
                MessageBox.Show("No se pudo reasignar la venta " +  doctoD.IComentario);
                return;
            }
            else
            {
                MessageBox.Show("Transaccion reasignada existosamente");
                this.Close();
            }

        }
    }
}
