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
    public partial class WFSelectTransByFolio : IposForm
    {

        public CDOCTOBE m_selectedDocto = null;
        public string m_tipoBusqueda = "Ventas";

        public WFSelectTransByFolio()
        {
            InitializeComponent();
        }


        public WFSelectTransByFolio(string tipoBusqueda):this()
        {
            m_tipoBusqueda = tipoBusqueda;
        }

        private void WFSelectTransByFolio_Load(object sender, EventArgs e)
        {

            if(m_tipoBusqueda == "NotaCredito")
            {
                CBTipoTran.Items.Clear();
                CBTipoTran.Items.Add("Nota de credito");
            }

            CBTipoTran.SelectedIndex = 0;
            TBFolio.Focus();

        }

        private void BTSeleccionar_Click(object sender, EventArgs e)
        {
            switch(CBTipoTran.SelectedItem.ToString())
            {
                case "Venta Cerrada":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_VENTA);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);

                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        } 

                    }
                    break;


                case "Venta Cancelada":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_CANCELADA, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_VENTA);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);

                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;


                case "Traslados Envio":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_TRASPASO_ENVIO);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);

                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;


                case "Venta de Apartado":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_VENTAAPARTADO);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);


                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;


                case "Pedido traslado":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);


                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;


                case "Venta a futuro":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_VENTA_FUTURO);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);


                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;



                case "Nota de credito":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);

                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;


                /*
            case "Traslados Recepcion":
                {
                    WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_TRASPASO_REC);
                    wfl.ShowDialog();

                    DataRow dr = wfl.m_rtnDataRow;

                    wfl.Dispose();
                    GC.SuppressFinalize(wfl);


                    if (dr != null)
                    {
                        this.TBFolio.Text = dr[15].ToString();
                    }

                }
                break;



            case "Compra":
                {
                    WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_COMPRA);
                    wfl.ShowDialog();

                    DataRow dr = wfl.m_rtnDataRow;
                    if (dr != null)
                    {
                        this.TBFolio.Text = dr[15].ToString();
                    }

                }
                break;


            case "Pedido Recepcion":
                {
                    WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_PEDIDO_COMPRA);
                    wfl.ShowDialog();

                    DataRow dr = wfl.m_rtnDataRow;
                    if (dr != null)
                    {
                        this.TBFolio.Text = dr[15].ToString();
                    }

                }
                break;
                 */

                default: break;
            }
        }

        private void BTReImprimir_Click(object sender, EventArgs e)
        {
            BuscarFolio();

        }

        private void BuscarFolio()
        {
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            //long lPrintOption = 0;

            try
            {

                doctoBE.IFOLIO = int.Parse(this.TBFolio.Text.ToString());

                switch (CBTipoTran.SelectedItem.ToString())
                {
                    case "Venta Cerrada":
                        doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;
                        break;


                    case "Venta Cancelada":
                        doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;
                        break;


                    case "Traslados Envio":
                        doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_TRASPASO_ENVIO;
                        break;



                    case "Venta de Apartado":
                        doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTAAPARTADO;
                        break;


                    case "Pedido traslado":
                        doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA;
                        break;


                    case "Venta a futuro":
                        doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA_FUTURO;
                        break;

                    case "Venta pendiente":
                        doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;
                        doctoBE.IID = doctoBE.IFOLIO;
                        break;


                    case "Nota de credito":
                        doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO;
                        break;


                    /*
                case "Traslados Recepcion":
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_TRASPASO_REC;
                    break;



                case "Pedido Recepcion":
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_PEDIDO_COMPRA;
                    break;

                case "Compra":
                    lPrintOption = Ticket._OPCION_IMPRESION_COMPRA;
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_COMPRA;
                    break;
                     */

                    default: break;
                }

            }
            catch
            {
                return;
            }


            if (doctoBE.IID != 0)
            {

                doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
            }
            else
            {
                doctoBE = doctoD.SeleccionarXTIPOYFOLIO(doctoBE, null);
            }

            if (doctoBE == null)
            {
                MessageBox.Show("Folio no encontrado");
                return;
            }

            try
            {
                m_selectedDocto = doctoBE;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TBFolio_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                BuscarFolio();
            }
        }

        private void TBFolio_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
