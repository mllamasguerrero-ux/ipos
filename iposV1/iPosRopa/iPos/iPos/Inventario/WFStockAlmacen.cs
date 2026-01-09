using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Inventario
{
    public partial class WFStockAlmacen : Form
    {

        bool m_bFocusCodigo = false;
        CPRODUCTOBE m_producto;

        bool bHabSeleccionAlmacen = false;

        public WFStockAlmacen()
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

        private void PrepararSiguienteEntrada()
        {
            pRODUCTONOMBRETextBox.Text = "";
            pRODUCTODESCRIPCIONTextBox.Text = "";
            this.STOCKTextBox.Text = "";
            this.STOCKMAXTextBox.Text = "";
            this.TBCodigo.Select(0, this.TBCodigo.Text.Length);
            //this.ALMACENComboBox.SelectedIndex = -1;

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

           // CPRODUCTOD productoD = new CPRODUCTOD();
            CSTOCKALMACEND daoStockAlmacen = new CSTOCKALMACEND();
            CSTOCKALMACENBE stockAlmacen = new CSTOCKALMACENBE();
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
                stockAlmacen.IPRODUCTOID = m_producto.IID;

                if (this.STOCKTextBox.Text != "")
                {
                    stockAlmacen.ISTOCKMIN = decimal.Parse(this.STOCKTextBox.Text.ToString());
                }


                if (this.STOCKMAXTextBox.Text != "")
                {
                    stockAlmacen.ISTOCKMAX = decimal.Parse(this.STOCKMAXTextBox.Text.ToString());
                }

                if (this.ALMACENComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("por favor seleccione un almacen valido de la lista ");
                    return;
                }
                else
                {
                    stockAlmacen.IALMACENID = long.Parse(this.ALMACENComboBox.SelectedDataValue.ToString());
                }

                if (daoStockAlmacen.ExisteSTOCKALMACENXPRODUCTOYALMACEN(stockAlmacen, null) == 1)
                {
                    CSTOCKALMACENBE auxAlm = new CSTOCKALMACENBE();
                    auxAlm = stockAlmacen;
                    stockAlmacen = daoStockAlmacen.seleccionarSTOCKALMACENByAlmacenIdProductoId(stockAlmacen, null);
                    stockAlmacen.ISTOCKMIN = auxAlm.ISTOCKMIN;
                    stockAlmacen.ISTOCKMAX = auxAlm.ISTOCKMAX;
                    if (!daoStockAlmacen.CambiarSTOCKALMACEND(stockAlmacen, stockAlmacen, null))
                    {

                        MessageBox.Show("Error : " + daoStockAlmacen.IComentario);
                        return;
                    }
                }
                else
                {
                    if (daoStockAlmacen.AgregarSTOCKALMACEND(stockAlmacen, null) == null)
                    {

                        MessageBox.Show("Error : " + daoStockAlmacen.IComentario);
                        return;
                    }
                }


                PrepararSiguienteEntrada();
                this.TBCodigo.Focus();

                this.dSLocationProducts.STOCKALMACEN.Clear();
                int almacenId = int.Parse(this.ALMACENComboBox.SelectedDataValue.ToString());
                this.sTOCKALMACENTableAdapter.Fill(this.dSLocationProducts.STOCKALMACEN, almacenId);

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

        private void button1_Click(object sender, EventArgs e)
        {
            Process();
        }

        private void WFStockAlmacen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSLocationProducts.STOCKALMACEN' table. You can move, or remove it, as needed.
            //this.sTOCKALMACENTableAdapter.Fill(this.dSLocationProducts.STOCKALMACEN);

            this.ALMACENComboBox.llenarDatos();
            this.ALMACENComboBox.SelectedIndex = -1;

            bHabSeleccionAlmacen = true;
        }

        private void TBCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.STOCKTextBox.Focus();
                //this.TBAnaquel.Select(0, this.TBAnaquel.Text.Length);
            }
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
            if (this.ALMACENComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("por favor seleccione un almacen valido de la lista ");
                return;
            }


            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                SeleccionarProducto(TBCodigo.Text.Trim());
                return;
            }

            this.pRODUCTONOMBRETextBox.Text = prod.INOMBRE;
            this.pRODUCTODESCRIPCIONTextBox.Text = prod.IDESCRIPCION;

            CSTOCKALMACENBE stock = new CSTOCKALMACENBE();
            CSTOCKALMACEND daoStock = new CSTOCKALMACEND();

            stock.IPRODUCTOID = prod.IID;
            stock.IALMACENID = long.Parse(ALMACENComboBox.SelectedDataValue.ToString());

            if(daoStock.ExisteSTOCKALMACENXPRODUCTOYALMACEN(stock, null) == 1)
            {
                stock = daoStock.seleccionarSTOCKALMACENByAlmacenIdProductoId(stock, null);
                this.STOCKTextBox.Text = stock.ISTOCKMIN.ToString();
                this.STOCKMAXTextBox.Text = stock.ISTOCKMAX.ToString();
            }

        }

        private void ALMACENComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ALMACENComboBox.SelectedIndex >= 0 && bHabSeleccionAlmacen)
            {
                int almacenId = int.Parse(this.ALMACENComboBox.SelectedDataValue.ToString());
                this.sTOCKALMACENTableAdapter.Fill(this.dSLocationProducts.STOCKALMACEN, almacenId);
                ALMACENComboBox.Enabled = false;
            }
            else
            {
                this.dSLocationProducts.STOCKALMACEN.Clear();
            }
        }

    }
}
