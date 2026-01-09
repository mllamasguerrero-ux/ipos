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
    public partial class WFLocacionProductos : IposForm
    {

        bool m_bFocusCodigo = false;
        CPRODUCTOBE m_producto;
        private bool m_loadingForm = true;

        public WFLocacionProductos()
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
            m_producto = prod;
            LlenarGrid((int)prod.IID);

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

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {

                MessageBox.Show("El producto no existe");
                return;
            }


            if (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S" && ALMACENComboBox.SelectedIndex < 0)
            {

                MessageBox.Show("Debe seleccionar el almacen");
                return;


            }

            m_producto = prod;

           
            /*FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;*/


            try
            {
                //fConn.Open();
                //fTrans = fConn.BeginTransaction();

                CPRODUCTOLOCATIONSD prodLocD = new CPRODUCTOLOCATIONSD();
                CPRODUCTOLOCATIONSBE prodLocBE = new CPRODUCTOLOCATIONSBE();
                prodLocBE.IPRODUCTOID = prod.IID;
                prodLocBE.ILOCALIDAD = TBLocalidad.Text;
                prodLocBE.IANAQUELID = long.Parse(this.CBAnaquel.SelectedValue.ToString());
                prodLocBE.IANAQUEL = this.CBAnaquel.Text;


                if (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S")
                {

                    prodLocBE.IALMACENID = long.Parse(this.ALMACENComboBox.SelectedValue.ToString());
                }

                if (prodLocD.ExistePRODUCTOLOCATIONS(prodLocBE, null) == 1)
                {
                    MessageBox.Show("Locacion del producto ya ingresada");
                    return;
                }
                else
                {
                    if (!prodLocD.AgregarPRODUCTOLOCATIONSD(prodLocBE, null))
                    {

                        MessageBox.Show("Error : " + prodLocD.IComentario);
                        return;
                    }

                    LlenarGrid((int)prod.IID);
                    this.TBLocalidad.Text = GuessNextLocalidad(this.TBLocalidad.Text);
                }
                
                    //fTrans.Commit();

                    PrepararSiguienteEntrada();
                    this.TBCodigo.Focus();
                    //LlenarGrid();

                /*else
                {
                    fTrans.Rollback();
                    MessageBox.Show(this.IComentario);
                    this.TBCodigo.Focus();
                }*/
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
           /* this.TBCodigo.Text = "";
            this.pRODUCTONOMBRETextBox.Text = "";
            this.pRODUCTODESCRIPCIONTextBox.Text = "";*/
            //this.LlenarDatos();

            this.TBCodigo.Select(0, this.TBCodigo.Text.Length);
        }

        private void TBCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.CBAnaquel.Focus();
                //this.TBAnaquel.Select(0, this.TBAnaquel.Text.Length);
            }
        }

        private void TBAnaquel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.TBLocalidad.Focus();
                this.TBLocalidad.Select(0, this.TBLocalidad.Text.Length);
            }
        }

        private void TBLocalidad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S")
                {
                    this.ALMACENComboBox.Focus();
                }
                else
                {

                    Process();
                    m_bFocusCodigo = true;
                }
            }
        }


        private void ALMACENComboBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                Process();
                m_bFocusCodigo = true;
            }
        }

        private void TBLocalidad_Leave(object sender, EventArgs e)
        {

            if (m_bFocusCodigo)
            {
                this.TBCodigo.Focus();
                this.TBCodigo.Text = "";
                m_bFocusCodigo = false;
            }
        }

        private void LlenarGrid(int productoId)
        {
            try
            {
                this.pRODUCTOLOCATIONSTableAdapter.Fill(this.dSLocationProducts.PRODUCTOLOCATIONS, productoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }



        private void pRODUCTOLOCATIONSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (pRODUCTOLOCATIONSDataGridView.Columns[e.ColumnIndex].Name == "ColEliminar")
                {
                    if (MessageBox.Show("Seguro que desea eliminar el registro", "Seguro que desea eliminar el registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        CPRODUCTOLOCATIONSD prodLocD = new CPRODUCTOLOCATIONSD();
                        CPRODUCTOLOCATIONSBE prodLocBE = new CPRODUCTOLOCATIONSBE();


                        prodLocBE.IID = long.Parse(pRODUCTOLOCATIONSDataGridView.Rows[e.RowIndex].Cells["ColID"].Value.ToString());

                        if (prodLocD.BorrarPRODUCTOLOCATIONSD(prodLocBE, null))
                        {
                            MessageBox.Show("El registro ha sido borrado", "El registro ha sido borrado");
                            LlenarGrid((int)m_producto.IID);
                        }
                        else
                        {

                            MessageBox.Show("Ocurrio un error al intentar borrar");
                        }
                    }
                }
            }
        }

        private void WFLocacionProductos_Load(object sender, EventArgs e)
        {

            this.ALMACENComboBox.llenarDatos();
            this.ALMACENComboBox.SelectedIndex = -1;

            bool manejaAlmacen = (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S");

            this.ALMACENComboBox.Visible = manejaAlmacen;
            this.lblAlmacen.Visible = manejaAlmacen;

            if (manejaAlmacen && CurrentUserID.CurrentUser.IALMACENID > 0)
                this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID;


            LlenarListaAnaqueles();

            m_loadingForm = false;
        }


        private void LlenarListaAnaqueles()
        {

            if(this.ALMACENComboBox.SelectedIndex >= 0 && (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S"))
            {
                this.CBAnaquel.Query = "select id,clave as nombre from anaquel where almacenid = " +  this.ALMACENComboBox.SelectedDataValue.ToString();
            }
            else
            {
                this.CBAnaquel.Query = "select id,clave as nombre from anaquel";
            }

            this.CBAnaquel.llenarDatos();
        }


        private string GuessNextLocalidad(string strLocalidad)
        {
            int iLoc = 0;
            if (int.TryParse(strLocalidad, out iLoc))
            {
                iLoc++;
                return iLoc.ToString().PadLeft(strLocalidad.Length,'0');
            }
            return strLocalidad;
        }

        private void ALMACENComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!m_loadingForm)
                LlenarListaAnaqueles();
        }
    }
}
