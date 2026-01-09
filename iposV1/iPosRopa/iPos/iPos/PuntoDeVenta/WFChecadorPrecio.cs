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
    public partial class WFChecadorPrecio : IposForm
    {
        private static int countF1Search;

        private Dictionary<string, string> preciosAMostrar;
        private List<Label> listLabels;
        private List<Label> listPrecLabels;

        public WFChecadorPrecio()
        {
            InitializeComponent();
            countF1Search = 0;

        }

        private void GetVerifConfig()
        {

            CLOOKUPD regD = new CLOOKUPD();
            CLOOKUPBE verificadorConfig = new CLOOKUPBE();
            verificadorConfig.ICLAVE = "VERIFICADOR";
            try
            {
                verificadorConfig = regD.seleccionarLOOKUPXClave(verificadorConfig, null);
                if (verificadorConfig != null)
                {

                    preciosAMostrar = new Dictionary<string, string>();
                    if (verificadorConfig.ICAMPO1.Equals("S"))
                        preciosAMostrar.Add("PRECIO1", verificadorConfig.ILBL_CAMPO1 != null ? verificadorConfig.ILBL_CAMPO1 : "Precio 1");
                    if (verificadorConfig.ICAMPO2.Equals("S"))
                        preciosAMostrar.Add("PRECIO2", verificadorConfig.ILBL_CAMPO2 != null ? verificadorConfig.ILBL_CAMPO2 : "Precio 2");
                    if (verificadorConfig.ICAMPO3.Equals("S"))
                        preciosAMostrar.Add("PRECIO3", verificadorConfig.ILBL_CAMPO3 != null ? verificadorConfig.ILBL_CAMPO3 : "Precio 3");
                    if (verificadorConfig.ICAMPO4.Equals("S"))
                        preciosAMostrar.Add("PRECIO4", verificadorConfig.ILBL_CAMPO4 != null ? verificadorConfig.ILBL_CAMPO4 : "Precio 4");
                    if (verificadorConfig.ICAMPO5.Equals("S"))
                        preciosAMostrar.Add("PRECIO5", verificadorConfig.ILBL_CAMPO5 != null ? verificadorConfig.ILBL_CAMPO5 : "Precio 5");

                    if (verificadorConfig.ICAMPO6.Equals("S"))
                        preciosAMostrar.Add("PRECIO1CONIMP", verificadorConfig.ILBL_CAMPO6 != null ? verificadorConfig.ILBL_CAMPO6 : "Precio 1 + imp");
                    if (verificadorConfig.ICAMPO7.Equals("S"))
                        preciosAMostrar.Add("PRECIO2CONIMP", verificadorConfig.ILBL_CAMPO7 != null ? verificadorConfig.ILBL_CAMPO7 : "Precio 2 + imp");
                    if (verificadorConfig.ICAMPO8.Equals("S"))
                        preciosAMostrar.Add("PRECIO3CONIMP", verificadorConfig.ILBL_CAMPO8 != null ? verificadorConfig.ILBL_CAMPO8 : "Precio 3 + imp");
                    if (verificadorConfig.ICAMPO9.Equals("S"))
                        preciosAMostrar.Add("PRECIO4CONIMP", verificadorConfig.ILBL_CAMPO9 != null ? verificadorConfig.ILBL_CAMPO9 : "Precio 4 + imp");
                    if (verificadorConfig.ICAMPO10.Equals("S"))
                        preciosAMostrar.Add("PRECIO5CONIMP", verificadorConfig.ILBL_CAMPO10 != null ? verificadorConfig.ILBL_CAMPO10 : "Precio 5 + imp");



                    if (verificadorConfig.ICAMPO12.Equals("S"))
                        preciosAMostrar.Add("PRECIOSUGERIDO", verificadorConfig.ILBL_CAMPO12 != null ? verificadorConfig.ILBL_CAMPO12 : "Precio Sugerido");
                    if (verificadorConfig.ICAMPO11.Equals("S"))
                        preciosAMostrar.Add("PRECIOCAJA", verificadorConfig.ILBL_CAMPO11 != null ? verificadorConfig.ILBL_CAMPO11 : "Precio Caja");





                }
                else
                {
                    MessageBox.Show("No estan configurados los precios a mostrar");
                    this.Close();
                }

            }
            catch
            {

                MessageBox.Show("No estan configurados los precios a mostrar");
                this.Close();
            }

            listLabels = new List<Label>();
            listLabels.Add(lblPrecioA);
            listLabels.Add(lblPrecioB);
            listLabels.Add(lblPrecioC);
            listLabels.Add(lblPrecioD);
            listLabels.Add(lblPrecioE);
            listLabels.Add(lblPrecioF);

            listPrecLabels = new List<Label>();
            listPrecLabels.Add(TBPrecioA);
            listPrecLabels.Add(TBPrecioB);
            listPrecLabels.Add(TBPrecioC);
            listPrecLabels.Add(TBPrecioD);
            listPrecLabels.Add(TBPrecioE);
            listPrecLabels.Add(TBPrecioF);

        }

        private void PreparaPreciosAMostrar()
        {

            foreach (var labelControl in listLabels)
                labelControl.Text = "";


            foreach (var labelControl in listPrecLabels )
                labelControl.Text = "";

            int i = 0;

            foreach(var keyPrecio in preciosAMostrar.Keys)
            {
                if (i < 5)
                {
                    listLabels[i].Text = preciosAMostrar[keyPrecio];
                    i++;
                }
            }

        }


        private void MostrarPrecios(CPRODUCTOBE prod)
        {
            PreparaPreciosAMostrar();

            int i = 0;
            foreach (var keyPrecio in preciosAMostrar.Keys)
            {
                if (i < 5)
                {
                    listPrecLabels[i].Text = GetPrecioStrValue(keyPrecio, prod);
                    i++;
                }
            }
        }

        private string GetPrecioStrValue(string keyPrecio, CPRODUCTOBE prod)
        {
            
            switch (keyPrecio)
            {
                case "PRECIO1":
                    return "$" + prod.IPRECIO1.ToString("#,##0.00");
                case "PRECIO2":
                    return "$" + prod.IPRECIO2.ToString("#,##0.00");
                case "PRECIO3":
                    return "$" + prod.IPRECIO3.ToString("#,##0.00");
                case "PRECIO4":
                    return "$" + prod.IPRECIO4.ToString("#,##0.00");
                case "PRECIO5":
                    return "$" + prod.IPRECIO5.ToString("#,##0.00");

                case "PRECIO1CONIMP":
                    return "$" + (calculaPrecioConImpuestos(prod.IPRECIO1, prod.ITASAIVA, prod.ITASAIEPS)).ToString("#,##0.00");
                case "PRECIO2CONIMP":
                    return "$" + (calculaPrecioConImpuestos(prod.IPRECIO2, prod.ITASAIVA, prod.ITASAIEPS)).ToString("#,##0.00");
                case "PRECIO3CONIMP":
                    return "$" + (calculaPrecioConImpuestos(prod.IPRECIO3, prod.ITASAIVA, prod.ITASAIEPS)).ToString("#,##0.00");
                case "PRECIO4CONIMP":
                    return "$" + (calculaPrecioConImpuestos(prod.IPRECIO4, prod.ITASAIVA, prod.ITASAIEPS)).ToString("#,##0.00");
                case "PRECIO5CONIMP":
                    return "$" + (calculaPrecioConImpuestos(prod.IPRECIO5, prod.ITASAIVA, prod.ITASAIEPS)).ToString("#,##0.00");


                case "PRECIOSUGERIDO":
                    return "$" + prod.IPRECIOSUGERIDO.ToString("#,##0.00");
                case "PRECIOCAJA":
                    return "$" + (calculaPrecioConImpuestos(prod.IPRECIO3 * prod.IPZACAJA, prod.ITASAIVA, prod.ITASAIEPS)).ToString("#,##0.00");

                default:
                    return "";

            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ClearInfo()
        {
            PreparaPreciosAMostrar();
            pRODUCTONOMBRETextBox.Text = "";
            pRODUCTODESCRIPCIONTextBox.Text = "";
            lblProductoNoLocalizado.Visible = false;

        }

        private void MostrarInfo()
        {
            ClearInfo();

            countF1Search++;
            if(countF1Search>1)
            {
                CPRODUCTOBE prod = new CPRODUCTOBE();
                if (!BuscarProducto(ref prod, TBCodigo.Text))
                {
                    //MessageBox.Show("Producto no localizado");
                    lblProductoNoLocalizado.Visible = true;
                    TBCodigo.Text = "";
                    TBCodigo.Focus();
                    return;
                }

                pRODUCTONOMBRETextBox.Text = prod.INOMBRE;
                pRODUCTODESCRIPCIONTextBox.Text = prod.IDESCRIPCION1;

                MostrarPrecios(prod);
                
                TBCodigo.Text = "";
                TBCodigo.Focus();
            }
        }


        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {
            //MostrarInfo();
        }



        private decimal calculaPrecioConImpuestos(decimal precioSinImpuestos, decimal dTasaIva, decimal dTasaIeps)
        {

            decimal precioConImpuesto = (precioSinImpuestos * (1 + (dTasaIeps / 100))) * (1 + (dTasaIva / 100));
            return Math.Round(precioConImpuesto, 2);


        }



        private bool BuscarProducto(ref CPRODUCTOBE prod, string search)
        {
            CComprasD pvd = new CComprasD();
            prod = pvd.buscarPRODUCTOSPV(search.Trim(), CurrentUserID.CurrentParameters, null);
            if (prod != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void SeleccionarProducto(string strDescripcion, ref TextBox control)
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
                control.Text = dr["CLAVE"].ToString().Trim();
                control.Focus();
                control.Select(TBCodigo.Text.Length, 0);
            }
        }

        private void TBCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            
        }

        private void TBCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MostrarInfo();
            }
        }

        private void WFChecadorPrecio_Load(object sender, EventArgs e)
        {
            GetVerifConfig();
            TBCodigo.Focus();
            PreparaPreciosAMostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TBCodigo_Enter(object sender, EventArgs e)
        {
            MostrarInfo();
        }

        private void ITEMButton_Click(object sender, EventArgs e)
        {
            SeleccionarProducto(TBCodigo.Text.Trim(), ref TBCodigo);
        }
    }
}
