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
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;

using System.Collections;

namespace iPos
{
    public partial class WFStockProductos : IposForm
    {

        bool m_bFocusCodigo = false;
        CPRODUCTOBE m_producto;
        bool m_refrescarGrid = false;

        public WFStockProductos()
        {
            InitializeComponent();
        }


        private bool BuscarProducto(ref CPRODUCTOBE prod)
        {
            CComprasD pvd = new CComprasD();
            prod = pvd.buscarPRODUCTOSPV(TBCodigo.Text.Trim(), CurrentUserID.CurrentParameters, null);
            if (prod != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void formateaGUIPzaCaja()
        {
            CBCapturaPiezas.Checked = true;
            CBCapturaCajas.Checked = true;

            if (!bEstaConfiguradoParaPiezasyCajas())
            {
                CBCapturaCajas.Checked = false;

                if (STOCKCAJAMAXTextBox.Focused || STOCKCAJAMINTextBox.Focused)
                {
                    STOCKTextBox.Focus();
                }


                DGSTOCKMAXCAJA.Visible = false;
                DGSTOCKMINCAJA.Visible = false;
                DGSTOCKMAXPIEZA.Visible = false;
                DGSTOCKMINPIEZA.Visible = false;


            }
            else
            {
                DGSTOCKMAXCAJA.Visible = true;
                DGSTOCKMINCAJA.Visible = true;
                DGSTOCKMAXPIEZA.Visible = true;
                DGSTOCKMINPIEZA.Visible = true;
            }
            ocultaMuestraCajaPzaXCheckBox();

        }



        private void ocultaMuestraCajaPzaXCheckBox()
        {

            lblCaja.Visible = CBCapturaCajas.Checked;
            STOCKCAJAMINTextBox.Visible = CBCapturaCajas.Checked;
            STOCKCAJAMAXTextBox.Visible = CBCapturaCajas.Checked;

            lblPza.Visible = CBCapturaPiezas.Checked;
            STOCKTextBox.Visible = CBCapturaPiezas.Checked;
            STOCKMAXTextBox.Visible = CBCapturaPiezas.Checked;
        }

        private bool bEstaConfiguradoParaPiezasyCajas()
        {
            return (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S"));
        }

        private void SeleccionarProducto(string strDescripcion)
        {

            LOOKPROD look;
            if (strDescripcion == "")
                look = new LOOKPROD("", false, TipoProductoNivel.tp_hijos);
            else
                look = new LOOKPROD(strDescripcion, false, TipoProductoNivel.tp_hijos);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.TBCodigo.Text = dr["CLAVE"].ToString().Trim();
                TBCodigo.Focus();
                TBCodigo.Select(TBCodigo.Text.Length, 0);
            }
        }

        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {
            //int errorCode = 0;
            //string strMensajeErr = "";


            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                SeleccionarProducto(TBCodigo.Text.Trim());
                return;
            }

            this.pRODUCTONOMBRETextBox.Text = prod.INOMBRE;
            this.pRODUCTODESCRIPCIONTextBox.Text = prod.IDESCRIPCION;

            if (!(bool)prod.isnull["IMANEJASTOCK"])
                this.MANEJASTOCKTextBox.Checked = (prod.IMANEJASTOCK == "S") ? true : false;


            if (!(bool)prod.isnull["ISURTIRPORCAJA"])
                this.CBSurtirPorCaja.Checked = (prod.ISURTIRPORCAJA == "S") ? true : false;


            this.STOCKTextBox.Text = "0.00";
            this.STOCKMAXTextBox.Text = "0.00";
            this.STOCKCAJAMINTextBox.Text = "0.00";
            this.STOCKCAJAMAXTextBox.Text = "0.00";

            if (!bEstaConfiguradoParaPiezasyCajas())
            {
                if (!(bool)prod.isnull["ISTOCK"])
                    this.STOCKTextBox.Text = prod.ISTOCK.ToString();


                if (!(bool)prod.isnull["ISTOCKMAX"])
                    this.STOCKMAXTextBox.Text = prod.ISTOCKMAX.ToString();
            }
            else
            {

                decimal piezaCaja = 1;
                decimal totalStockMin = 0;
                decimal cajasMin = 0;
                decimal piezasMin = 0;
                decimal totalXCajaPzaMin = 0;

                decimal totalStockMax = 0;
                decimal cajasMax = 0;
                decimal piezasMax = 0;
                decimal totalXCajaPzaMax = 0;


                if (!(bool)prod.isnull["ISTOCK"])
                    totalStockMin = prod.ISTOCK;

                if (!(bool)prod.isnull["ISTOCKMAX"])
                    totalStockMax = prod.ISTOCKMAX;

                if (!(bool)prod.isnull["ISTOCKMINCAJA"])
                    cajasMin = prod.ISTOCKMINCAJA;

                if (!(bool)prod.isnull["ISTOCKMAXCAJA"])
                    cajasMax = prod.ISTOCKMAXCAJA;

                if (!(bool)prod.isnull["ISTOCKMINPIEZA"])
                    piezasMin = prod.ISTOCKMINPIEZA;

                if (!(bool)prod.isnull["ISTOCKMAXPIEZA"])
                    piezasMax = prod.ISTOCKMAXPIEZA;

                if (!(bool)prod.isnull["IPZACAJA"])
                    piezaCaja = prod.IPZACAJA;

                if (piezaCaja < 1)
                    piezaCaja = 1;

                totalXCajaPzaMin = piezasMin + (cajasMin * piezaCaja);
                totalXCajaPzaMax = piezasMax + (cajasMax * piezaCaja);

                if (totalXCajaPzaMin != totalStockMin)
                {
                    cajasMin = Math.Truncate(totalStockMin / piezaCaja);
                    piezasMin = Math.Truncate(totalStockMin % piezaCaja);
                }

                if (totalXCajaPzaMax != totalStockMax)
                {
                    cajasMax = Math.Truncate(totalStockMax / piezaCaja);
                    piezasMax = Math.Truncate(totalStockMax % piezaCaja);
                }


                this.STOCKTextBox.Text = piezasMin.ToString();
                this.STOCKMAXTextBox.Text = piezasMax.ToString();
                this.STOCKCAJAMINTextBox.Text = cajasMin.ToString();
                this.STOCKCAJAMAXTextBox.Text = cajasMax.ToString();

            }







            if (!(bool)prod.isnull["IMANEJASTOCK"])
                this.MANEJASTOCKTextBox.Checked = (prod.IMANEJASTOCK == "S") ? true : false;

            m_producto = prod;

            this.lblCaja.Text = m_producto.IPZACAJA > 1 ? "Cajas (" + m_producto.IPZACAJA.ToString() + ")" : "Cajas";

            //LlenarGrid((int)prod.IID);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Process();

            this.TBCodigo.Focus();
            this.TBCodigo.Text = "";
        }


        private void Process()
        {

            string P_VD_VENDEDOR = CurrentUserID.CurrentUser.INOMBRE;
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;



            if (TBCodigo.Text.Trim() == "")
            {
                MessageBox.Show("El texto de este control no debe estar vacio");
                return;
            }

            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {

                MessageBox.Show("El producto no existe");
                return;
            }

            m_producto = prod;


            /*FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;*/


            try
            {

                prod.IMANEJASTOCK = (this.MANEJASTOCKTextBox.Checked) ? "S" : "N";
                prod.ISURTIRPORCAJA = (this.CBSurtirPorCaja.Checked) ? "S" : "N";

                prod.ISTOCK = 0;
                prod.ISTOCKMAX = 0;
                prod.ISTOCKMINCAJA = 0;
                prod.ISTOCKMAXCAJA = 0;
                prod.ISTOCKMINPIEZA = 0;
                prod.ISTOCKMAXPIEZA = 0;


                decimal piezaCaja = 1;
                decimal cajasMin = 0;
                decimal piezasMin = 0;
                decimal totalXCajaPzaMin = 0;

                decimal cajasMax = 0;
                decimal piezasMax = 0;
                decimal totalXCajaPzaMax = 0;

                if (!bEstaConfiguradoParaPiezasyCajas())
                {

                    if (this.STOCKTextBox.Text != "")
                    {
                        prod.ISTOCK = decimal.Parse(this.STOCKTextBox.Text.ToString());
                    }


                    if (this.STOCKMAXTextBox.Text != "")
                    {
                        prod.ISTOCKMAX = decimal.Parse(this.STOCKMAXTextBox.Text.ToString());
                    }

                    cajasMin = Math.Truncate(prod.ISTOCK / piezaCaja);
                    piezasMin = Math.Truncate(prod.ISTOCK % piezaCaja);
                   
                    
                    cajasMax = Math.Truncate(prod.ISTOCKMAX / piezaCaja);
                    piezasMax = Math.Truncate(prod.ISTOCKMAX % piezaCaja);


                    prod.ISTOCKMINCAJA = cajasMin;
                    prod.ISTOCKMAXCAJA = cajasMax;
                    prod.ISTOCKMINPIEZA = piezasMin;
                    prod.ISTOCKMAXPIEZA = piezasMax;


                }
                else
                {

                    piezasMin = decimal.Parse(this.STOCKTextBox.Text.ToString());
                    piezasMax = decimal.Parse(this.STOCKMAXTextBox.Text.ToString());

                    cajasMin = decimal.Parse(this.STOCKCAJAMINTextBox.Text.ToString());
                    cajasMax = decimal.Parse(this.STOCKCAJAMAXTextBox.Text.ToString());


                    if (!(bool)prod.isnull["IPZACAJA"])
                        piezaCaja = prod.IPZACAJA;

                    if (piezaCaja < 1)
                        piezaCaja = 1;

                    totalXCajaPzaMin = piezasMin + (cajasMin * piezaCaja);
                    totalXCajaPzaMax = piezasMax + (cajasMax * piezaCaja);

                    prod.ISTOCK = totalXCajaPzaMin;
                    prod.ISTOCKMAX = totalXCajaPzaMax;
                    prod.ISTOCKMINCAJA = cajasMin;
                    prod.ISTOCKMAXCAJA = cajasMax;
                    prod.ISTOCKMINPIEZA = piezasMin;
                    prod.ISTOCKMAXPIEZA = piezasMax;



                }

                if (!productoD.CambiarStockPRODUCTO(prod, null))
                {

                    MessageBox.Show("Error : " + productoD.IComentario);
                    return;
                }

                PrepararSiguienteEntrada();
                this.TBCodigo.Focus();
                this.pRODUCTOCONSTOCKTableAdapter.Fill(this.dSInventarioFisico.PRODUCTOCONSTOCK);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                //fConn.Close();
            }
        }


        private void PrepararSiguienteEntrada()
        {
            pRODUCTONOMBRETextBox.Text = "";
            pRODUCTODESCRIPCIONTextBox.Text = "";
            this.MANEJASTOCKTextBox.Checked = false;
            this.STOCKTextBox.Text = "";
            this.STOCKMAXTextBox.Text = "";
            this.STOCKCAJAMINTextBox.Text = "";
            this.STOCKCAJAMAXTextBox.Text = "";


            this.TBCodigo.Select(0, this.TBCodigo.Text.Length);
            this.CBSurtirPorCaja.Checked = false;
        }

        private void TBCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.STOCKTextBox.Focus();
                //this.TBAnaquel.Select(0, this.TBAnaquel.Text.Length);
            }
        }

        private void MANEJASTOCKTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.STOCKTextBox.Focus();
                this.STOCKTextBox.Select(0, this.STOCKTextBox.Text.Length);
            }
        }



        private void STOCKTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.STOCKTextBox.Text != "")
                {
                    decimal stock = decimal.Parse(this.STOCKTextBox.Text.ToString());
                    if (stock > 0 && !this.MANEJASTOCKTextBox.Checked)
                        this.MANEJASTOCKTextBox.Checked = true;
                }
            }
            catch
            {

            }


            if (m_bFocusCodigo)
            {
                this.TBCodigo.Focus();
                this.TBCodigo.Text = "";
                m_bFocusCodigo = false;
            }

        }

        private void STOCKMAXTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.STOCKMAXTextBox.Text != "")
                {
                    decimal stockMAX = decimal.Parse(this.STOCKMAXTextBox.Text.ToString());
                    if (stockMAX > 0 && !this.MANEJASTOCKTextBox.Checked)
                        this.MANEJASTOCKTextBox.Checked = true;
                }
            }
            catch
            {

            }


            if (m_bFocusCodigo)
            {
                this.TBCodigo.Focus();
                this.TBCodigo.Text = "";
                m_bFocusCodigo = false;
            }
        }



        private void STOCKCAJAMINTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.STOCKCAJAMINTextBox.Text != "")
                {
                    decimal stock = decimal.Parse(this.STOCKCAJAMINTextBox.Text.ToString());
                    if (stock > 0 && !this.MANEJASTOCKTextBox.Checked)
                        this.MANEJASTOCKTextBox.Checked = true;
                }
            }
            catch
            {

            }


            if (m_bFocusCodigo)
            {
                this.TBCodigo.Focus();
                this.TBCodigo.Text = "";
                m_bFocusCodigo = false;
            }

        }

        private void STOCKCAJAMAXTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.STOCKCAJAMAXTextBox.Text != "")
                {
                    decimal stockMAX = decimal.Parse(this.STOCKCAJAMAXTextBox.Text.ToString());
                    if (stockMAX > 0 && !this.MANEJASTOCKTextBox.Checked)
                        this.MANEJASTOCKTextBox.Checked = true;
                }
            }
            catch
            {

            }


            if (m_bFocusCodigo)
            {
                this.TBCodigo.Focus();
                this.TBCodigo.Text = "";
                m_bFocusCodigo = false;
            }
        }

        private void WFStockProductos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSInventarioFisico.PRODUCTOCONSTOCK' table. You can move, or remove it, as needed.
            this.pRODUCTOCONSTOCKTableAdapter.Fill(this.dSInventarioFisico.PRODUCTOCONSTOCK);
            formateaGUIPzaCaja();
        }

        private void pRODUCTOCONSTOCKDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            MessageBox.Show("1");
        }

        private void pRODUCTOCONSTOCKDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            decimal piezaCaja = 1;
            decimal cajasMin = 0;
            decimal piezasMin = 0;
            decimal totalXCajaPzaMin = 0;

            decimal cajasMax = 0;
            decimal piezasMax = 0;
            decimal totalXCajaPzaMax = 0;

            string headerText = pRODUCTOCONSTOCKDataGridView.Columns[e.ColumnIndex].Name;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("DGSTOCK") && !headerText.Equals("DGSTOCKMAX") && !headerText.Equals("DGSURTIRPORCAJA") 
                && !headerText.Equals("DGSTOCKMINCAJA") && !headerText.Equals("DGSTOCKMAXCAJA")
                 && !headerText.Equals("DGSTOCKMINPIEZA") && !headerText.Equals("DGSTOCKMAXPIEZA")) return;

            
            try
            {


                int prodId = int.Parse(pRODUCTOCONSTOCKDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());



                CPRODUCTOD productoD = new CPRODUCTOD();
                CPRODUCTOBE prod = new CPRODUCTOBE();
                prod.IID = prodId;
                prod = productoD.seleccionarPRODUCTO(prod, null);
                if (prod == null)
                {

                    MessageBox.Show("El producto no existe");
                    e.Cancel = true;
                    return;
                }

                prod.IMANEJASTOCK = "S";

                //PIEZA CAJA
                if (!(bool)prod.isnull["IPZACAJA"])
                    piezaCaja = prod.IPZACAJA;
                if (piezaCaja < 1)
                    piezaCaja = 1;


                if (!headerText.Equals("DGSTOCKMINCAJA") && !headerText.Equals("DGSTOCKMAXCAJA") &&
                    !headerText.Equals("DGSTOCKMINPIEZA") && !headerText.Equals("DGSTOCKMAXPIEZA"))
                {
                    if (!headerText.Equals("DGSTOCK"))
                    {
                        prod.ISTOCK = decimal.Parse(pRODUCTOCONSTOCKDataGridView.Rows[e.RowIndex].Cells["DGSTOCK"].Value.ToString());
                    }
                    else
                    {
                        prod.ISTOCK = decimal.Parse(e.FormattedValue.ToString());
                    }


                    if (!headerText.Equals("DGSTOCKMAX"))
                    {
                        prod.ISTOCKMAX = decimal.Parse(pRODUCTOCONSTOCKDataGridView.Rows[e.RowIndex].Cells["DGSTOCKMAX"].Value.ToString());
                    }
                    else
                    {
                        prod.ISTOCKMAX = decimal.Parse(e.FormattedValue.ToString());
                    }



                    cajasMin = Math.Truncate(prod.ISTOCK / piezaCaja);
                    piezasMin = Math.Truncate(prod.ISTOCK % piezaCaja);


                    cajasMax = Math.Truncate(prod.ISTOCKMAX / piezaCaja);
                    piezasMax = Math.Truncate(prod.ISTOCKMAX % piezaCaja);


                    prod.ISTOCKMINCAJA = cajasMin;
                    prod.ISTOCKMAXCAJA = cajasMax;
                    prod.ISTOCKMINPIEZA = piezasMin;
                    prod.ISTOCKMAXPIEZA = piezasMax;

                }
                else
                {

                    if (!headerText.Equals("DGSTOCKMINCAJA"))
                    {
                        cajasMin = decimal.Parse(pRODUCTOCONSTOCKDataGridView.Rows[e.RowIndex].Cells["DGSTOCKMINCAJA"].Value.ToString());
                    }
                    else
                    {
                        try
                        {
                            cajasMin = decimal.Parse(e.FormattedValue.ToString());
                        }
                        catch
                        {
                            cajasMin = 0;
                        }
                    }


                    if (!headerText.Equals("DGSTOCKMAXCAJA"))
                    {
                        cajasMax = decimal.Parse(pRODUCTOCONSTOCKDataGridView.Rows[e.RowIndex].Cells["DGSTOCKMAXCAJA"].Value.ToString());
                    }
                    else
                    {
                        try { 
                        cajasMax = decimal.Parse(e.FormattedValue.ToString());
                        }
                        catch
                        {
                            cajasMax = 0;
                        }
                    }



                    if (!headerText.Equals("DGSTOCKMINPIEZA"))
                    {
                        piezasMin = decimal.Parse(pRODUCTOCONSTOCKDataGridView.Rows[e.RowIndex].Cells["DGSTOCKMINPIEZA"].Value.ToString());
                    }
                    else
                    {
                        try
                        { 
                        piezasMin = decimal.Parse(e.FormattedValue.ToString());
                        }
                        catch
                        {
                            piezasMin = 0;
                        }
                    }


                    if (!headerText.Equals("DGSTOCKMAXPIEZA"))
                    {
                        piezasMax = decimal.Parse(pRODUCTOCONSTOCKDataGridView.Rows[e.RowIndex].Cells["DGSTOCKMAXPIEZA"].Value.ToString());
                    }
                    else
                    {
                        try
                        { 
                        piezasMax = decimal.Parse(e.FormattedValue.ToString());
                        }
                        catch
                        {
                            piezasMax = 0;
                        }
                    }


                    totalXCajaPzaMin = piezasMin + (cajasMin * piezaCaja);
                    totalXCajaPzaMax = piezasMax + (cajasMax * piezaCaja);

                    prod.ISTOCK = totalXCajaPzaMin;
                    prod.ISTOCKMAX = totalXCajaPzaMax;
                    prod.ISTOCKMINCAJA = cajasMin;
                    prod.ISTOCKMAXCAJA = cajasMax;
                    prod.ISTOCKMINPIEZA = piezasMin;
                    prod.ISTOCKMAXPIEZA = piezasMax;


                }








                if (!headerText.Equals("DGSURTIRPORCAJA"))
                {
                    prod.ISURTIRPORCAJA = pRODUCTOCONSTOCKDataGridView.Rows[e.RowIndex].Cells["DGSURTIRPORCAJA"].Value.ToString();
                }
                else
                {
                    prod.ISURTIRPORCAJA = e.FormattedValue.ToString();
                }

                if (prod.ISURTIRPORCAJA == "True")
                    prod.ISURTIRPORCAJA = "S";

                if (prod.ISURTIRPORCAJA != "S")
                    prod.ISURTIRPORCAJA = "N";






                if (!productoD.CambiarStockPRODUCTO(prod, null))
                {

                    MessageBox.Show("Error : " + productoD.IComentario);
                    e.Cancel = true;
                    return;
                }
                m_refrescarGrid = true;


            }
            catch
            {
            }
        }

        private void pRODUCTOCONSTOCKDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            MessageBox.Show("Dato invalido , porfavor ingrese un dato valido");
            e.ThrowException = false;
        }

        private void pRODUCTOCONSTOCKDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if(m_refrescarGrid)
            {
                m_refrescarGrid = false;

                this.pRODUCTOCONSTOCKTableAdapter.Fill(this.dSInventarioFisico.PRODUCTOCONSTOCK);
            }

        }

        private void CBCapturaCajas_CheckedChanged(object sender, EventArgs e)
        {
            ocultaMuestraCajaPzaXCheckBox();
        }

        private void CBCapturaPiezas_CheckedChanged(object sender, EventArgs e)
        {
            ocultaMuestraCajaPzaXCheckBox();
        }

        private void STOCKCAJAMINTextBox_Validated(object sender, EventArgs e)
        {
            if(decimal.Parse(this.STOCKCAJAMINTextBox.Text.ToString()) > 0)
            {
                CBSurtirPorCaja.Checked = true;
            }
        }

        private void STOCKCAJAMAXTextBox_Validated(object sender, EventArgs e)
        {

            if (decimal.Parse(this.STOCKCAJAMAXTextBox.Text.ToString()) > 0)
            {
                CBSurtirPorCaja.Checked = true;
            }
        }
    }
}
