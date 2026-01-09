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
    public partial class WFSelectEntradaByFolio : IposForm
    {

        public CDOCTOBE m_selectedDocto = null;
        public WFSelectEntradaByFolio()
        {
            InitializeComponent();
        }

        private void WFSelectEntradaByFolio_Load(object sender, EventArgs e)
        {
            CBTipoTran.SelectedIndex = 0;
            TBFolio.Focus();

        }

        private void BTSeleccionar_Click(object sender, EventArgs e)
        {
            long tipoDoctoId = obtenTipoDocumentoPorSeleccion();

            long estatusDoctoId = DBValues._DOCTO_ESTATUS_COMPLETO;
            if(tipoDoctoId == DBValues._DOCTO_TIPO_COMPRA_CANCELACION)
            {
                estatusDoctoId = DBValues._DOCTO_ESTATUS_CANCELADA;
                tipoDoctoId = DBValues._DOCTO_TIPO_COMPRA;
            }

            if(tipoDoctoId != DBValues._DOCTO_TIPO_COMPRA_SUC)
            {


                WFLookUpTransacciones wfl = new WFLookUpTransacciones(estatusDoctoId, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, tipoDoctoId);
                wfl.ShowDialog();

                DataRow dr = wfl.m_rtnDataRow;

                wfl.Dispose();
                GC.SuppressFinalize(wfl);

                if (dr != null)
                {
                    this.TBFolio.Text = dr[15].ToString();
                }
            }
            else
            {

                Abonos.WFLookUpCompraSucursales wfl = new Abonos.WFLookUpCompraSucursales(estatusDoctoId, 0, tipoDoctoId,0);
                wfl.ShowDialog();

                DataRow dr = wfl.m_rtnDataRow;

                wfl.Dispose();
                GC.SuppressFinalize(wfl);

                if (dr != null)
                {
                    this.TBFolio.Text = dr[15].ToString();

                    try
                    {
                        string strBuffer = "";
                        this.SUCURSALIDTextBox.DbValue = dr["SUCDESTID"].ToString();
                        this.SUCURSALIDTextBox.MostrarErrores = false;
                        this.SUCURSALIDTextBox.MValidarEntrada(out strBuffer, 1);
                        this.SUCURSALIDTextBox.MostrarErrores = true;
                    }
                    catch
                    {

                    }
                    
                    

                    
                }
            }

            
        }

        private void BTReImprimir_Click(object sender, EventArgs e)
        {
            BuscarFolio();

        }


        private long obtenTipoDocumentoPorSeleccion()
        {
            long tipodoctoId = 0;
            switch (CBTipoTran.SelectedIndex)
            {
                case 0: tipodoctoId = 11; break;
                case 1: tipodoctoId = DBValues._DOCTO_TIPO_COMPRA_CANCELACION; break;
                case 2: tipodoctoId = DBValues._DOCTO_TIPO_PEDIDO_COMPRA; break;
                case 3: tipodoctoId = DBValues._DOCTO_TIPO_TRASPASO_REC; break;
                case 4: tipodoctoId = DBValues._DOCTO_TIPO_ORDEN_COMPRA; break;
                case 5: tipodoctoId = DBValues._DOCTO_TIPO_RECEPCIONORDEN_COMPRA; break;
                case 6: tipodoctoId = DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO; break;
                case 7: tipodoctoId = DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO; break;
                case 8: tipodoctoId = DBValues._DOCTO_TIPO_COMPRA_SUC; break;
                default: tipodoctoId = 0; break;

            }

            return tipodoctoId;
        }

        private void BuscarFolio()
        {
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            //long lPrintOption = 0;

            try
            {

                doctoBE.IFOLIO = int.Parse(this.TBFolio.Text.ToString());
                doctoBE.ITIPODOCTOID = obtenTipoDocumentoPorSeleccion();
                

            }
            catch
            {
                return;
            }

            if(doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA_SUC)
            {

                long sucursalDestinoId = 0;
                if (this.CBSucursal.Checked && this.SUCURSALIDTextBox.Text != "")
                {
                    sucursalDestinoId = Int32.Parse(this.SUCURSALIDTextBox.DbValue.ToString());
                }
                doctoBE.ISUCURSALTID = sucursalDestinoId;
                
                doctoBE = doctoD.SeleccionarXTIPOYFOLIOYSUCDEST(doctoBE, null);
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

        private void CBTipoTran_Validated(object sender, EventArgs e)
        {

            long tipoDoctoId = obtenTipoDocumentoPorSeleccion();

            pnlSucursal.Visible = tipoDoctoId == DBValues._DOCTO_TIPO_COMPRA_SUC;
        }
    }
}
