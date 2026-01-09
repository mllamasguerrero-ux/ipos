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

namespace iPos
{
    public partial class WFProductoListasPrecio : Form
    {

        long m_productoId = 0;
        long m_listaPrecioId = 0;
        public WFProductoListasPrecio()
        {
            InitializeComponent();
        }

        public WFProductoListasPrecio(long productoId):this()
        {
            m_productoId = productoId;
        }

        private void LlenarDetalles()
        {
            try
            {
                this.pRODUCTOLISTAPRECIOSTableAdapter.Fill(this.dSCatalogos3.PRODUCTOLISTAPRECIOS, m_productoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void PRODUCTOIDTextBox_Validated(object sender, EventArgs e)
        {

            if (this.PRODUCTOIDTextBox.Text != "")
            {
                m_productoId = Int64.Parse(this.PRODUCTOIDTextBox.DbValue.ToString());
                LlenarDetalles();
            }
            else
            {
                m_productoId = 0;
                this.dSCatalogos3.PRODUCTOLISTAPRECIOS.Clear();
            }

        }

        private void WFProductoListasPrecio_Load(object sender, EventArgs e)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            COSTOREPOSICIONTextBox.ReadOnly = !usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARCOSTOREPO_LISTAPREC, null);
            

            this.LISTAPRECIOCLAVETextBox.llenarDatos();
            string strBuffer = "";
            if(m_productoId != 0)
            {

                this.PRODUCTOIDTextBox.DbValue = m_productoId.ToString();
                this.PRODUCTOIDTextBox.MostrarErrores = false;
                this.PRODUCTOIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.PRODUCTOIDTextBox.MostrarErrores = true;

                LlenarDetalles();
            }



        }

        private void pRODUCTOLISTAPRECIOSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (pRODUCTOLISTAPRECIOSDataGridView.Columns[e.ColumnIndex].Name == "DGBORRAR")
                {


                    if (MessageBox.Show("Esto eliminara este registro. Esta seguro de que desea hacerlo ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    long dtlId = long.Parse(pRODUCTOLISTAPRECIOSDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());

                    CLISTAPRECIODETALLED detalleD = new CLISTAPRECIODETALLED();
                    CLISTAPRECIODETALLEBE detalleBE = new CLISTAPRECIODETALLEBE();
                    detalleBE.IID = dtlId;
                    if (!detalleD.BorrarLISTAPRECIODETALLED(detalleBE, null))
                    {
                        MessageBox.Show("No se pudo borrar");
                    }
                    else
                    {

                        MessageBox.Show("se elimino el registro");
                        this.LlenarDetalles();
                    }
                }
                else if (pRODUCTOLISTAPRECIOSDataGridView.Columns[e.ColumnIndex].Name == "DGEDITAR")
                {

                    LimpiarActual();

                    long dtListaPrecioId = long.Parse(pRODUCTOLISTAPRECIOSDataGridView.Rows[e.RowIndex].Cells["DGLISTAPRECIOID"].Value.ToString());
                    
                    this.LISTAPRECIOCLAVETextBox.SelectedDataValue = dtListaPrecioId;
                    

                    fillDataFromCodigo();
                    this.PRECIO1TextBox.Focus();
                }
            }
        }



        private void fillDataFromCodigo()
        {

            if (this.LISTAPRECIOCLAVETextBox.SelectedIndex == -1)
                return;

            CPRODUCTOBE prod = new CPRODUCTOBE();
            CPRODUCTOD prodD = new CPRODUCTOD();
            prod.IID = m_productoId;

            prod = prodD.seleccionarPRODUCTO(prod, null);

            if(prod == null)
            {
                MessageBox.Show("el producto no existe");
                return;
            }


            Boolean desgloseIeps = CurrentUserID.CurrentParameters.IDESGLOSEIEPS != null && CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S");

            if (CBPrecioConImpuesto.Checked)
            {
                this.PRECIO1TextBox.Text = Math.Round((prod.IPRECIO1 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                this.PRECIO2TextBox.Text = Math.Round((prod.IPRECIO2 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                this.PRECIO3TextBox.Text = Math.Round((prod.IPRECIO3 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                this.PRECIO4TextBox.Text = Math.Round((prod.IPRECIO4 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                this.PRECIO5TextBox.Text = Math.Round((prod.IPRECIO5 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();

                this.COSTOREPOSICIONTextBox.Text = Math.Round((prod.ICOSTOREPOSICION * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();

            }
            else
            {
                this.PRECIO1TextBox.Text = prod.IPRECIO1.ToString();
                this.PRECIO2TextBox.Text = prod.IPRECIO2.ToString();
                this.PRECIO3TextBox.Text = prod.IPRECIO3.ToString();
                this.PRECIO4TextBox.Text = prod.IPRECIO4.ToString();
                this.PRECIO5TextBox.Text = prod.IPRECIO5.ToString();

                this.COSTOREPOSICIONTextBox.Text = prod.ICOSTOREPOSICION.ToString();

            }

            this.TIENEVIGCheckBox.Checked = false;
            this.FECHAVIGDateTimePicker.Value = DateTime.Today.AddYears(10);
            //this.PRECIOSUGERIDOLbl.Text = prod.IPRECIOSUGERIDO.ToString();



            CLISTAPRECIODETALLEBE preciosTempBE = new CLISTAPRECIODETALLEBE();
            CLISTAPRECIODETALLED preciosTempD = new CLISTAPRECIODETALLED();
            preciosTempBE.IPRODUCTOID = m_productoId;
            preciosTempBE.ILISTAPRECIOID = long.Parse(this.LISTAPRECIOCLAVETextBox.SelectedDataValue.ToString());
            preciosTempBE = preciosTempD.seleccionarRegistrosLISTAPRECIODETALLEXListaYProducto(preciosTempBE.ILISTAPRECIOID, preciosTempBE.IPRODUCTOID, null);

            if (preciosTempBE != null)
            {

                if (CBPrecioConImpuesto.Checked)
                {

                    this.PRECIO1TextBox.Text = Math.Round((preciosTempBE.IPRECIO1 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                    this.PRECIO2TextBox.Text = Math.Round((preciosTempBE.IPRECIO2 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                    this.PRECIO3TextBox.Text = Math.Round((preciosTempBE.IPRECIO3 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                    this.PRECIO4TextBox.Text = Math.Round((preciosTempBE.IPRECIO4 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                    this.PRECIO5TextBox.Text = Math.Round((preciosTempBE.IPRECIO5 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();
                    this.COSTOREPOSICIONTextBox.Text = Math.Round((preciosTempBE.ICOSTOREPOSICION * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2).ToString();


                }
                else
                {

                    this.PRECIO1TextBox.Text = preciosTempBE.IPRECIO1.ToString();
                    this.PRECIO2TextBox.Text = preciosTempBE.IPRECIO2.ToString();
                    this.PRECIO3TextBox.Text = preciosTempBE.IPRECIO3.ToString();
                    this.PRECIO4TextBox.Text = preciosTempBE.IPRECIO4.ToString();
                    this.PRECIO5TextBox.Text = preciosTempBE.IPRECIO5.ToString();
                    this.COSTOREPOSICIONTextBox.Text = preciosTempBE.ICOSTOREPOSICION.ToString();
                }
                this.TIENEVIGCheckBox.Checked = preciosTempBE.ITIENEVIG == "S";
                this.FECHAVIGDateTimePicker.Value = preciosTempBE.IFECHAVIG != null ? preciosTempBE.IFECHAVIG : DateTime.Today.AddYears(10); 
            }

        }



        private void LimpiarActual()
        {
            m_listaPrecioId = 0;
            this.LISTAPRECIOCLAVETextBox.SelectedIndex = -1;

            this.PRECIO1TextBox.Text = "";
            this.PRECIO2TextBox.Text = "";
            this.PRECIO3TextBox.Text = "";
            this.PRECIO4TextBox.Text = "";
            this.PRECIO5TextBox.Text = "";

            this.COSTOREPOSICIONTextBox.Text = "";
            this.TIENEVIGCheckBox.Checked = false;
            this.FECHAVIGDateTimePicker.Value = DateTime.Today.AddYears(10); 

        }

        private void LISTAPRECIOCLAVETextBox_Validated(object sender, EventArgs e)
        {
            //LimpiarActual();
            fillDataFromCodigo();
        }



        private void BTAgregarPrecio_Click(object sender, EventArgs e)
        {


            if (this.LISTAPRECIOCLAVETextBox.SelectedIndex == -1)
                return;

            CPRODUCTOBE prod = new CPRODUCTOBE();
            CPRODUCTOD prodD = new CPRODUCTOD();
            prod.IID = m_productoId;

            prod = prodD.seleccionarPRODUCTO(prod, null);

            if (prod == null)
            {
                MessageBox.Show("el producto no existe");
                return;
            }


            Boolean desgloseIeps = CurrentUserID.CurrentParameters.IDESGLOSEIEPS != null && CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S");
            //decimal precioEspecificoConImpuesto = decimal.Parse(PRECIO1TextBox.Text);



            CLISTAPRECIODETALLEBE detalleBE = new CLISTAPRECIODETALLEBE();

            //LISTAPRECIODETALLERow row = this.dSCatalogos3.LISTAPRECIODETALLE.NewLISTAPRECIODETALLERow();

            detalleBE.IPRODUCTOID = m_productoId;
            detalleBE.ILISTAPRECIOID = long.Parse(this.LISTAPRECIOCLAVETextBox.SelectedDataValue.ToString());
            detalleBE.IACTIVO = "S";
            //row.CLAVE = prod.ICLAVE;
            //row.DESCRIPCION = prod.IDESCRIPCION;
            //row.DESCRIPCION1 = prod.IDESCRIPCION1;








            if (this.PRECIO1TextBox.Text != "")
            {


                decimal precioConImpuesto1 = decimal.Parse(this.PRECIO1TextBox.Text.ToString());
                if (CBPrecioConImpuesto.Checked)
                {
                    detalleBE.IPRECIO1 = Math.Round((precioConImpuesto1 / ((1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100)))), 2);
                    //row.PRECIO1CONIMPUESTO = precioConImpuesto1;
                }
                else
                {
                    detalleBE.IPRECIO1 = precioConImpuesto1;
                    //row.PRECIO1CONIMPUESTO = Math.Round((precioConImpuesto1 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2);

                }

            }
            else
            {

                MessageBox.Show("Seleccione un precio valido");
                return;
            }


            if (this.PRECIO2TextBox.Text != "")
            {


                decimal precioConImpuesto2 = decimal.Parse(this.PRECIO2TextBox.Text.ToString());
                if (CBPrecioConImpuesto.Checked)
                {
                    detalleBE.IPRECIO2 = Math.Round((precioConImpuesto2 / ((1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100)))), 2);
                    //row.PRECIO2CONIMPUESTO = precioConImpuesto2;
                }
                else
                {
                    detalleBE.IPRECIO2 = precioConImpuesto2;
                    //row.PRECIO2CONIMPUESTO = Math.Round((precioConImpuesto2 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2);
                }
            }
            else
            {

                MessageBox.Show("Seleccione un precio valido");
                return;
            }


            if (this.PRECIO3TextBox.Text != "")
            {


                decimal precioConImpuesto3 = decimal.Parse(this.PRECIO3TextBox.Text.ToString());
                if (CBPrecioConImpuesto.Checked)
                {
                    detalleBE.IPRECIO3 = Math.Round((precioConImpuesto3 / ((1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100)))), 2);
                    //row.PRECIO3CONIMPUESTO = precioConImpuesto3;
                }
                else
                {
                    detalleBE.IPRECIO3 = precioConImpuesto3;
                    //row.PRECIO3CONIMPUESTO = Math.Round((precioConImpuesto3 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2);
                }
            }
            else
            {

                MessageBox.Show("Seleccione un precio valido");
                return;
            }


            if (this.PRECIO4TextBox.Text != "")
            {

                decimal precioConImpuesto4 = decimal.Parse(this.PRECIO4TextBox.Text.ToString());
                if (CBPrecioConImpuesto.Checked)
                {
                    detalleBE.IPRECIO4 = Math.Round((precioConImpuesto4 / ((1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100)))), 2);
                    //row.PRECIO4CONIMPUESTO = precioConImpuesto4;
                }
                else
                {
                    detalleBE.IPRECIO4 = precioConImpuesto4;
                    //row.PRECIO4CONIMPUESTO = Math.Round((precioConImpuesto4 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2);
                }
            }
            else
            {

                MessageBox.Show("Seleccione un precio valido");
                return;
            }


            if (this.PRECIO5TextBox.Text != "")
            {

                decimal precioConImpuesto5 = decimal.Parse(this.PRECIO5TextBox.Text.ToString());
                if (CBPrecioConImpuesto.Checked)
                {
                    detalleBE.IPRECIO5 = Math.Round((precioConImpuesto5 / ((1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100)))), 2);
                    //row.PRECIO5CONIMPUESTO = precioConImpuesto5;
                }
                else
                {
                    detalleBE.IPRECIO5 = precioConImpuesto5;
                    //row.PRECIO5CONIMPUESTO = Math.Round((precioConImpuesto5 * (1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100))), 2);

                }

            }
            else
            {

                MessageBox.Show("Seleccione un precio valido");
                return;
            }


            if (this.COSTOREPOSICIONTextBox.Text != "")
            {
                decimal costoreposicion = decimal.Parse(this.COSTOREPOSICIONTextBox.Text.ToString());
                if (CBPrecioConImpuesto.Checked)
                {
                    detalleBE.ICOSTOREPOSICION = Math.Round((costoreposicion / ((1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100)))), 2);
                }
                else
                {
                    detalleBE.ICOSTOREPOSICION = costoreposicion;

                }
            }
            else
            {

                MessageBox.Show("Seleccione un costo reposicion valido");
                return;
            }


            detalleBE.ITIENEVIG = TIENEVIGCheckBox.Checked ? "S" : "N";
            detalleBE.IFECHAVIG = FECHAVIGDateTimePicker.Value;

            if (detalleBE.IPRECIO1 < detalleBE.ICOSTOREPOSICION)
            {

                MessageBox.Show("El precio no puede estar abajo del costo de reposicion");
                return;
            }


            if (detalleBE.IPRECIO2 < detalleBE.ICOSTOREPOSICION)
            {

                MessageBox.Show("El precio no puede estar abajo del costo de reposicion");
                return;
            }

            if (detalleBE.IPRECIO3 < detalleBE.ICOSTOREPOSICION)
            {

                MessageBox.Show("El precio no puede estar abajo del costo de reposicion");
                return;
            }

            if (detalleBE.IPRECIO4 < detalleBE.ICOSTOREPOSICION)
            {

                MessageBox.Show("El precio no puede estar abajo del costo de reposicion");
                return;
            }

            if (detalleBE.IPRECIO5 < detalleBE.ICOSTOREPOSICION)
            {

                MessageBox.Show("El precio no puede estar abajo del costo de reposicion");
                return;
            }



            CLISTAPRECIODETALLED detalleD = new CLISTAPRECIODETALLED();


            if (detalleD.AgregarOCambiarLISTAPRECIODETALLED(detalleBE, null) == null)
            {

                MessageBox.Show("Ocurrio un error no se puede guardar");
                return;
            }
            else
            {

                MessageBox.Show("Se guardo el registro");
                this.LlenarDetalles();
            }


            LimpiarActual();
            this.LISTAPRECIOCLAVETextBox.Focus();

        }
    }
}
