using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using System.Printing;
using System.IO;

namespace iPos
{
    public partial class WFImprimirEtiquetas : IposForm
    {

        Boolean m_bImprimirPreciosTemporales = false;
        public const string FileLocalLocation_FE_IMG = "\\sampdata\\facturaelectronica\\IMG";
        string productIDs = "";
        string productCOUNTs = "";
        string productLibres = "";

        public WFImprimirEtiquetas()
        {
            InitializeComponent();
            cmbPrinterModel.SelectedIndex = 0;
        }



        public WFImprimirEtiquetas(Boolean bImprimirPreciosTemporales) : this()
        {
            m_bImprimirPreciosTemporales = bImprimirPreciosTemporales;
        }

        private CZEBRACONFIGBE ObtenerDatosCapturados()
        {
            CZEBRACONFIGBE ZEBRACONFIGBE = new CZEBRACONFIGBE();


            if (this.A1_X_POSITIONTextBox.Text != "")
            {
                ZEBRACONFIGBE.IA1_X_POSITION = this.A1_X_POSITIONTextBox.Text.ToString();
            }


            if (this.A2_Y_POSITIONTextBox.Text != "")
            {
                ZEBRACONFIGBE.IA2_Y_POSITION = this.A2_Y_POSITIONTextBox.Text.ToString();
            }


            if (this.A3_ROTATIONTextBox.Text != "")
            {
                ZEBRACONFIGBE.IA3_ROTATION = this.A3_ROTATIONTextBox.Text.ToString();
            }


            if (this.A4_FONT_SELECTIONTextBox.Text != "")
            {
                ZEBRACONFIGBE.IA4_FONT_SELECTION = this.A4_FONT_SELECTIONTextBox.Text.ToString();
            }


            if (this.A5_X_MULTIPLIERTextBox.Text != "")
            {
                ZEBRACONFIGBE.IA5_X_MULTIPLIER = this.A5_X_MULTIPLIERTextBox.Text.ToString();
            }


            if (this.A6_Y_MULTIPLIERTextBox.Text != "")
            {
                ZEBRACONFIGBE.IA6_Y_MULTIPLIER = this.A6_Y_MULTIPLIERTextBox.Text.ToString();
            }


            if (this.A7_REVERSEIMAGETextBox.Text != "")
            {
                ZEBRACONFIGBE.IA7_REVERSEIMAGE = this.A7_REVERSEIMAGETextBox.Text.ToString();
            }


            if (this.B1_X_POSITIONTextBox.Text != "")
            {
                ZEBRACONFIGBE.IB1_X_POSITION = this.B1_X_POSITIONTextBox.Text.ToString();
            }


            if (this.B2_Y_POSITIONTextBox.Text != "")
            {
                ZEBRACONFIGBE.IB2_Y_POSITION = this.B2_Y_POSITIONTextBox.Text.ToString();
            }


            if (this.B3_ROTATIONTextBox.Text != "")
            {
                ZEBRACONFIGBE.IB3_ROTATION = this.B3_ROTATIONTextBox.Text.ToString();
            }


            if (this.B4_BARCODE_SELECTIONTextBox.Text != "")
            {
                ZEBRACONFIGBE.IB4_BARCODE_SELECTION = this.B4_BARCODE_SELECTIONTextBox.Text.ToString();
            }


            if (this.B5_NARROWBARWIDTHTextBox.Text != "")
            {
                ZEBRACONFIGBE.IB5_NARROWBARWIDTH = this.B5_NARROWBARWIDTHTextBox.Text.ToString();
            }


            if (this.B6_WIDEBARWIDTHTextBox.Text != "")
            {
                ZEBRACONFIGBE.IB6_WIDEBARWIDTH = this.B6_WIDEBARWIDTHTextBox.Text.ToString();
            }


            if (this.B7_BARCODEHEIGHTTextBox.Text != "")
            {
                ZEBRACONFIGBE.IB7_BARCODEHEIGHT = this.B7_BARCODEHEIGHTTextBox.Text.ToString();
            }


            if (this.B8_PRINTHUMANREADABLETextBox.Text != "")
            {
                ZEBRACONFIGBE.IB8_PRINTHUMANREADABLE = this.B8_PRINTHUMANREADABLETextBox.Text.ToString();
            }


            if (this.Q_LABELWIDTHTextBox.Text != "")
            {
                ZEBRACONFIGBE.IQ_LABELWIDTH = this.Q_LABELWIDTHTextBox.Text.ToString();
            }


            if (this.Q_FORMLENGTH_1TextBox.Text != "")
            {
                ZEBRACONFIGBE.IQ_FORMLENGTH_1 = this.Q_FORMLENGTH_1TextBox.Text.ToString();
            }


            if (this.Q_FORMLENGTH_2TextBox.Text != "")
            {
                ZEBRACONFIGBE.IQ_FORMLENGTH_2 = this.Q_FORMLENGTH_2TextBox.Text.ToString();
            }




            return ZEBRACONFIGBE;

        }




        private bool LlenarDatosDeBase()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DataTablesParaGrid.GetDataFb("Select * from zebraconfig");


                if (dt.Rows.Count <= 0)
                    return false;


                this.A1_X_POSITIONTextBox.Text = dt.Rows[0]["A1_X_POSITION"].ToString();

                this.A2_Y_POSITIONTextBox.Text = dt.Rows[0]["A2_Y_POSITION"].ToString();

                this.A3_ROTATIONTextBox.Text = dt.Rows[0]["A3_ROTATION"].ToString();

                this.A4_FONT_SELECTIONTextBox.Text = dt.Rows[0]["A4_FONT_SELECTION"].ToString();

                this.A5_X_MULTIPLIERTextBox.Text = dt.Rows[0]["A5_X_MULTIPLIER"].ToString();

                this.A6_Y_MULTIPLIERTextBox.Text = dt.Rows[0]["A6_Y_MULTIPLIER"].ToString();

                this.A7_REVERSEIMAGETextBox.Text = dt.Rows[0]["A7_REVERSEIMAGE"].ToString();

                this.B1_X_POSITIONTextBox.Text = dt.Rows[0]["B1_X_POSITION"].ToString();

                this.B2_Y_POSITIONTextBox.Text = dt.Rows[0]["B2_Y_POSITION"].ToString();

                this.B3_ROTATIONTextBox.Text = dt.Rows[0]["B3_ROTATION"].ToString();

                this.B4_BARCODE_SELECTIONTextBox.Text = dt.Rows[0]["B4_BARCODE_SELECTION"].ToString();

                this.B5_NARROWBARWIDTHTextBox.Text = dt.Rows[0]["B5_NARROWBARWIDTH"].ToString();

                this.B6_WIDEBARWIDTHTextBox.Text = dt.Rows[0]["B6_WIDEBARWIDTH"].ToString();

                this.B7_BARCODEHEIGHTTextBox.Text = dt.Rows[0]["B7_BARCODEHEIGHT"].ToString();

                this.B8_PRINTHUMANREADABLETextBox.Text = dt.Rows[0]["B8_PRINTHUMANREADABLE"].ToString();

                this.Q_LABELWIDTHTextBox.Text = dt.Rows[0]["Q_LABELWIDTH"].ToString();

                this.Q_FORMLENGTH_1TextBox.Text = dt.Rows[0]["Q_FORMLENGTH_1"].ToString();

                this.Q_FORMLENGTH_2TextBox.Text = dt.Rows[0]["Q_FORMLENGTH_2"].ToString();


                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();

                return false;
            }
        }

        public void SaveChanges()
        {
            try
            {
                CZEBRACONFIGD zebraConfigD = new CZEBRACONFIGD();
                CZEBRACONFIGBE zebraConfigBE = new CZEBRACONFIGBE();
                zebraConfigBE = ObtenerDatosCapturados();

                zebraConfigD.CambiarZEBRACONFIGD(zebraConfigBE, zebraConfigBE, null);
                if (zebraConfigD.IComentario == "" || zebraConfigD.IComentario == null)
                {
                    MessageBox.Show("El registro se ha cambiado");

                    LlenarDatosDeBase();

                }
                else
                    MessageBox.Show("ERRORES: " + zebraConfigD.IComentario.Replace("%", "\n"));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error Asegurese de que metio los datos en el formato correcto " + ex.Message);
            }
        }

        private void btnGuardarConfig_Click(object sender, EventArgs e)
        {
            this.SaveChanges();
        }





        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (TBCodigo.Text.Trim() == "")
                return;

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                this.LBProductoDescripcion.Text = "";
                SeleccionarProducto(TBCodigo.Text.Trim());
                return;
            }
            this.LBProductoDescripcion.Text = prod.IDESCRIPCION;
            if(prod.IUNIDAD == "KG")
            {
                this.TBPeso.Text = "1000";
            }

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

        private void TBCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (TBCodigo.Text.Trim() == "")
                {
                    SeleccionarProducto(TBCodigo.Text.Trim());
                    return;
                }
                this.TBCantidad.Focus();
                TBCantidad.Select(0, TBCantidad.Text.Length);
            }
        }

        
        private bool AgregarDataRow(CPRODUCTOBE prodBE, int cantidad)
        {
            return AgregarDataRow( prodBE,  cantidad, true);
        }


        private bool AgregarDataRow(CPRODUCTOBE prodBE, int cantidad, bool mostrarMensaje)
        {
            try
            {
                int peso = 0;
                try
                {
                    peso = int.Parse(TBPeso.Text);
                }
                catch
                {

                }

                DataRow[] filteredRows = dSCatalogos.PRODUCTOAETIQUETAR.Select(string.Format("{0} = '{1}' AND {2} = {3}", "CLAVE", prodBE.ICLAVE, "PESO", peso.ToString()));

                if (filteredRows.Count() > 0)
                {
                    if (mostrarMensaje)
                    {
                        MessageBox.Show("ya se agrego ese producto a al lista");
                    }
                    return false;
                }

                string CAMPOIMPRIMIR = "__CAMPOPERSONALIZADO";
                if (RBCampo.Checked)
                {
                    try
                    {
                        CAMPOIMPRIMIR = camposuperior.SelectedItem.ToString();
                    }
                    catch
                    {
                        CAMPOIMPRIMIR = "Descripción";
                    }
                }


                decimal tasaIeps = 0;
                if (CurrentUserID.CurrentParameters.IDESGLOSEIEPS != null && CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S"))
                    tasaIeps = !(bool)prodBE.isnull["ITASAIEPS"] ? prodBE.ITASAIEPS : 0;

                decimal precio = ( ((!(bool)prodBE.isnull["IPRECIO1"]) ? prodBE.IPRECIO1 : 0) * ((100 + tasaIeps)/100) )    * ((100 +   ((!(bool)prodBE.isnull["ITASAIVA"]) ? prodBE.ITASAIVA : 0))/100);

                precio = Math.Round(precio, 2);

                    dSCatalogos.PRODUCTOAETIQUETAR.AddPRODUCTOAETIQUETARRow(prodBE.ICLAVE, prodBE.INOMBRE, prodBE.IDESCRIPCION, prodBE.IEAN, precio, cantidad, prodBE.ITEXTO1, prodBE.ITEXTO2, prodBE.ITEXTO3, prodBE.ITEXTO4, prodBE.ITEXTO5, prodBE.ITEXTO6, prodBE.INUMERO1, prodBE.INUMERO2, prodBE.INUMERO3, prodBE.INUMERO4, prodBE.IFECHA1, prodBE.IFECHA2, this.textosuperior.Text, CAMPOIMPRIMIR,prodBE.IDESCRIPCION1, prodBE.ISUBSTITUTO, 
                    peso, 
                    prodBE.IPLUG, prodBE.IUNIDAD, prodBE.IID);
                TBPeso.Text = "";
                TBCodigo.Text = "";
                TBCantidad.Text = "";
                LBProductoDescripcion.Text = "";
                return true;
            } 
            catch
            {
                if (mostrarMensaje)
                {
                    MessageBox.Show("hubo un problema para agregar el producto a la lista de productos a imprimir");
                }
                return false;
            }

        }



        private void forceDefaultCellStyle()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.pRODUCTOAETIQUETARDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
        }

        private void WFImprimirEtiquetas_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSCatalogos.PERSONAGAFFETE' table. You can move, or remove it, as needed.
            //this.pERSONAGAFFETETableAdapter.Fill(this.dSCatalogos.PERSONAGAFFETE);
            LlenarDatosDeBase();
            FormatearCamposPersonalizados();

            if (this.m_bImprimirPreciosTemporales)
                LlenarProductosDePreciosTemporales();

            this.camposuperior.SelectedIndex = 1;

            this.TBCodigo.Focus();

            forceDefaultCellStyle();
        }


        private decimal calculaPrecioSinImpuestos(decimal precioConImpuestos, decimal dTasaIva, decimal dTasaIeps)
        {

            decimal dPrecioSinImpuestos = (precioConImpuestos / (1 + (dTasaIva / 100))) / (1 + (dTasaIeps / 100));
            return Math.Round(dPrecioSinImpuestos, 2);


        }


        private void LlenarProductosDePreciosTemporales()
        {

            // TODO: This line of code loads data into the 'dSCatalogos.PRECIOSTEMP' table. You can move, or remove it, as needed.
            this.pRECIOSTEMPTableAdapter.Fill(this.dSCatalogos.PRECIOSTEMP);
            

            foreach(Catalogos.DSCatalogos.PRECIOSTEMPRow dr in this.dSCatalogos.PRECIOSTEMP.Rows)
            {
                CPRODUCTOBE prodBE = new CPRODUCTOBE();
                CPRODUCTOD prodD = new CPRODUCTOD();
                prodBE.IID = dr.PRODUCTOID;
                productIDs += dr.PRODUCTOID + ",";

                prodBE = prodD.seleccionarPRODUCTO(prodBE, null);

               

                if (prodBE != null)
                {

                    prodBE.IPRECIO1 = calculaPrecioSinImpuestos(dr.PRECIO1, prodBE.ITASAIVA, prodBE.ITASAIEPS);

                    AgregarDataRow(prodBE, 1, false);
                }
            }

            if (this.dSCatalogos.PRECIOSTEMP.Rows.Count > 0)
            {

                productIDs = productIDs.Remove(productIDs.Length - 1);
            }
            this.btnReporteLargo.Visible = true;

        }


        private void BTAgregar_Click(object sender, EventArgs e)
        {
            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                MessageBox.Show("El producto no existe");
                return;
            }

            int cantidad; 
            try
            {
                cantidad =int.Parse(TBCantidad.Text.Trim());
            }
            catch
            {
                MessageBox.Show("La cantidad no tiene el formato adecuado");
                return;
            }

            if(cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero");
                return;
            }

            if(prod.IUNIDAD != null && prod.IUNIDAD.ToUpper().Equals("KG") )
            {
                string pesotxt = this.TBPeso.Text;
                try
                {
                    int buffer =  int.Parse(this.TBPeso.Text);
                    if(buffer <= 0)
                    {

                        MessageBox.Show("Debe asignar un peso mayor a 0");
                        return;
                    }
                }
                catch(Exception ex)
                {

                    

                        MessageBox.Show("Debe asignar un peso");
                        return;
                }
            }

            AgregarDataRow(prod, cantidad);

            TBCodigo.Focus();
           
        }

        private void pRODUCTOAETIQUETARDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            MessageBox.Show("Dato invalido , porfavor ingrese un dato valido");
            e.ThrowException = false;
        }

        private void btnEnviarAImpresion_Click(object sender, EventArgs e)
        {
            
           StringBuilder sb;
            sb = new StringBuilder();
            string buffer;
            string codigo;
            string precio;
            string descripcion;
            int iNumeroCopias = 0;

            CZEBRACONFIGD zebraD = new CZEBRACONFIGD();
            CZEBRACONFIGBE zebraBE = new CZEBRACONFIGBE();
            zebraBE = zebraD.seleccionarZEBRACONFIG(null);

            string[] pTexto = {zebraBE.IA1_X_POSITION,zebraBE.IA2_Y_POSITION ,zebraBE.IA3_ROTATION , zebraBE.IA4_FONT_SELECTION , zebraBE.IA5_X_MULTIPLIER , zebraBE.IA6_Y_MULTIPLIER , zebraBE.IA7_REVERSEIMAGE  };        
            string[] pBarCode = {zebraBE.IB1_X_POSITION, zebraBE.IB2_Y_POSITION , zebraBE.IB3_ROTATION , zebraBE.IB4_BARCODE_SELECTION , zebraBE.IB5_NARROWBARWIDTH , zebraBE.IB6_WIDEBARWIDTH , zebraBE.IB7_BARCODEHEIGHT , zebraBE.IB8_PRINTHUMANREADABLE };


            foreach(Catalogos.DSCatalogos.PRODUCTOAETIQUETARRow p in dSCatalogos.PRODUCTOAETIQUETAR)
            {

                codigo = (p.EAN == null)? "" : p.EAN.Trim();
                precio = "Precio: $" + p.PRECIO1.ToString("N2");

                if (p.IsCAMPOIMPRESIONNull())
                {
                    descripcion = (p.IsDESCRIPCIONNull()) ? "" : p.DESCRIPCION.Trim();
                }
                else
                {


                    if (p.CAMPOIMPRESION.Equals("Descripción"))
                    {
                        descripcion = (p.IsDESCRIPCIONNull()) ? "" : p.DESCRIPCION.Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals("Descripción 1"))
                    {
                        descripcion = (p.IsDESCRIPCION1Null()) ? "" : p.DESCRIPCION1.Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals(CurrentUserID.CurrentParameters.ITEXTO1))
                    {
                        descripcion = (p.IsTEXTO1Null()) ? "" : p.TEXTO1.Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals(CurrentUserID.CurrentParameters.ITEXTO2))
                    {
                        descripcion = (p.IsTEXTO2Null()) ? "" : p.TEXTO2.Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals(CurrentUserID.CurrentParameters.ITEXTO3))
                    {
                        descripcion = (p.IsTEXTO3Null()) ? "" : p.TEXTO3.Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals(CurrentUserID.CurrentParameters.ITEXTO4))
                    {
                        descripcion = (p.IsTEXTO4Null()) ? "" : p.TEXTO4.Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals(CurrentUserID.CurrentParameters.ITEXTO5))
                    {
                        descripcion = (p.IsTEXTO5Null()) ? "" : p.TEXTO5.Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals(CurrentUserID.CurrentParameters.ITEXTO6))
                    {
                        descripcion = (p.IsTEXTO6Null()) ? "" : p.TEXTO6.Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals(CurrentUserID.CurrentParameters.INUMERO1))
                    {
                        descripcion = (p.IsNUMERO1Null()) ? "" : p.NUMERO1.ToString().Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals(CurrentUserID.CurrentParameters.INUMERO2))
                    {
                        descripcion = (p.IsNUMERO2Null()) ? "" : p.NUMERO2.ToString().Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals(CurrentUserID.CurrentParameters.INUMERO3))
                    {
                        descripcion = (p.IsNUMERO3Null()) ? "" : p.NUMERO3.ToString().Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals(CurrentUserID.CurrentParameters.INUMERO4))
                    {
                        descripcion = (p.IsNUMERO4Null()) ? "" : p.NUMERO4.ToString().Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals(CurrentUserID.CurrentParameters.IFECHA1))
                    {
                        descripcion = (p.IsFECHA1Null()) ? "" : p.FECHA1.ToString().Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals(CurrentUserID.CurrentParameters.IFECHA2))
                    {
                        descripcion = (p.IsFECHA2Null()) ? "" : p.FECHA2.ToString().Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals(CurrentUserID.CurrentParameters.IFECHA2))
                    {
                        descripcion = (p.IsFECHA2Null()) ? "" : p.FECHA2.ToString().Trim();
                    }
                    else if (p.CAMPOIMPRESION.Equals("__CAMPOPERSONALIZADO"))
                    {
                        descripcion = (p.IsTEXTOPERSONALIZADONull()) ? "" : p.TEXTOPERSONALIZADO.Trim();
                    }
                    else
                    {
                        descripcion = (p.IsDESCRIPCIONNull()) ? "" : p.DESCRIPCION.Trim();
                    }
                }



                iNumeroCopias = (p.IsCANTIDADNull()) ? (int)0 : (int)p.CANTIDAD;
                if(!this.fmtImpresoraDoble.Checked && cmbPrinterModel.Text == "BIXOLON SLP-TX400")
                {
                    string codigoAImprimir = "";

                    if (p.IsPLUGNull() || p.PLUG.Trim().Length == 0)
                    {
                        codigoAImprimir = p.EAN != null && p.EAN.Trim().Length > 0 ? p.EAN : "";
                    }
                    else
                    {
                        codigoAImprimir = p.IsPLUGNull() ? "" : p.PLUG.PadRight(6, '0');
                        codigoAImprimir += p.PESO.ToString().PadLeft(6, '0');
                    }
                    try
                    {
                        string rutaImg = getFileLocalLocation_FE_IMG(CurrentUserID.CurrentParameters) + "\\ETIQUETA_PRECIOS.png";
                        EPLPrinter.PrintEtiquetaBixolonZPL(TBImpresora.Text, codigoAImprimir, precio, descripcion, p.PESO, p.UNIDAD, rutaImg, iNumeroCopias);
                    }
                    catch(Exception)
                    {

                    }
                }
                if (!this.fmtImpresoraDoble.Checked && cmbPrinterModel.Text != "BIXOLON SLP-TX400" && this.CBAnaquel.Checked)
                {
                    buffer = EPLPrinter.PrintEtiqueta(TBImpresora.Text, p.EAN, precio, descripcion,
                    zebraBE.IQ_LABELWIDTH, zebraBE.IQ_FORMLENGTH_1, zebraBE.IQ_FORMLENGTH_2, pTexto, pBarCode,
                    iNumeroCopias, CBAnaquel.Checked);
                    if (buffer.Equals("error"))
                    {
                        MessageBox.Show("Ocurrio un error ");
                        return;
                    }
                    sb.Append(buffer);

                }
                else if (!this.fmtImpresoraDoble.Checked && cmbPrinterModel.Text != "BIXOLON SLP-TX400")
                {

                    buffer = EPLPrinter.PrintEtiqueta(TBImpresora.Text, p.EAN, precio, descripcion,
                zebraBE.IQ_LABELWIDTH, zebraBE.IQ_FORMLENGTH_1, zebraBE.IQ_FORMLENGTH_2, pTexto, pBarCode,
                iNumeroCopias, CBAnaquel.Checked);
                    if (buffer.Equals("error"))
                    {
                        MessageBox.Show("Ocurrio un error ");
                        return;
                    }
                    sb.Append(buffer);
                }

                else if (this.fmtImpresoraDoble.Checked)
                {
                    string codigoAImprimir = "";

                    if (p.IsPLUGNull() || p.PLUG.Trim().Length == 0)
                    {
                        codigoAImprimir = p.EAN != null && p.EAN.Trim().Length > 0 ? p.EAN : "";
                    }
                    else
                    {
                        codigoAImprimir = p.IsPLUGNull() ? "" : p.PLUG.PadRight(6, '0');
                        codigoAImprimir += p.PESO.ToString().PadLeft(6, '0');
                    }

                    buffer = EPLPrinter.PrintEtiquetaDoble(TBImpresora.Text, codigoAImprimir, ((p.IsTEXTOPERSONALIZADONull()) ? "" : p.TEXTOPERSONALIZADO.Trim()), descripcion,
                zebraBE.IQ_LABELWIDTH, zebraBE.IQ_FORMLENGTH_1, zebraBE.IQ_FORMLENGTH_2, pTexto, pBarCode,
                iNumeroCopias, cmbPrinterModel.Text, precio, CBAnaquel.Checked);
                    if (buffer.Equals("error"))
                    {
                        MessageBox.Show("Ocurrio un error ");
                        return;
                    }
                    sb.Append(buffer);
                }
            }

            TBOutPut.Text = sb.ToString();
             
             
            /*
            EPLPrinter label = new EPLPrinter("603679025109");
            label.Print("ZDesigner GK420t");*/
            

        }

        private void RBCampo_CheckedChanged(object sender, EventArgs e)
        {
            formateaCamposSuperiores(); 
        }

        private void formateaCamposSuperiores()
        {
           /* if (RBCampo.Checked)
            {
                camposuperior.Enabled = true;
                textosuperior.Enabled = false;
            }
            else if (RBLibre.Checked)
            {
                camposuperior.Enabled = false;
                textosuperior.Enabled = true;
            }*/


        }

        private void RBLibre_CheckedChanged(object sender, EventArgs e)
        {
            formateaCamposSuperiores(); 
        }


        private void FormatearCamposPersonalizados()
        {
            try
            {
                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] && CurrentUserID.CurrentParameters.ITEXTO1 != "")
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO1"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO1;
                    camposuperior.Items.Add(pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO1"].HeaderText);
                }
                else
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO1"].Visible = false;
                }



                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO2"] && CurrentUserID.CurrentParameters.ITEXTO2 != "")
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO2"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO2;
                    camposuperior.Items.Add(pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO2"].HeaderText);
                }
                else
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO2"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO3"] && CurrentUserID.CurrentParameters.ITEXTO3 != "")
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO3"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO3;
                    camposuperior.Items.Add(pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO3"].HeaderText);
                }
                else
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO3"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO4"] && CurrentUserID.CurrentParameters.ITEXTO4 != "")
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO4"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO4; 
                    camposuperior.Items.Add(pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO4"].HeaderText);
                }
                else
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO4"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO5"] && CurrentUserID.CurrentParameters.ITEXTO5 != "")
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO5"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO5; 
                    camposuperior.Items.Add(pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO5"].HeaderText);
                }
                else
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO5"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO6"] && CurrentUserID.CurrentParameters.ITEXTO6 != "")
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO6"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO6;
                    camposuperior.Items.Add(pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO6"].HeaderText);
                }
                else
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGTEXTO6"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO1"] && CurrentUserID.CurrentParameters.INUMERO1 != "")
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGNUMERO1"].HeaderText = CurrentUserID.CurrentParameters.INUMERO1;
                    camposuperior.Items.Add(pRODUCTOAETIQUETARDataGridView.Columns["DGNUMERO1"].HeaderText);
                }
                else
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGNUMERO1"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO2"] && CurrentUserID.CurrentParameters.INUMERO2 != "")
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGNUMERO2"].HeaderText = CurrentUserID.CurrentParameters.INUMERO2;
                    camposuperior.Items.Add(pRODUCTOAETIQUETARDataGridView.Columns["DGNUMERO2"].HeaderText);
                }
                else
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGNUMERO2"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO3"] && CurrentUserID.CurrentParameters.INUMERO3 != "")
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGNUMERO3"].HeaderText = CurrentUserID.CurrentParameters.INUMERO3;
                    camposuperior.Items.Add(pRODUCTOAETIQUETARDataGridView.Columns["DGNUMERO3"].HeaderText);
                }
                else
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGNUMERO3"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO4"] && CurrentUserID.CurrentParameters.INUMERO4 != "")
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGNUMERO4"].HeaderText = CurrentUserID.CurrentParameters.INUMERO4;
                    camposuperior.Items.Add(pRODUCTOAETIQUETARDataGridView.Columns["DGNUMERO4"].HeaderText);
                }
                else
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGNUMERO4"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA1"] && CurrentUserID.CurrentParameters.IFECHA1 != "")
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGFECHA1"].HeaderText = CurrentUserID.CurrentParameters.IFECHA1;
                    camposuperior.Items.Add(pRODUCTOAETIQUETARDataGridView.Columns["DGFECHA1"].HeaderText);
                }
                else
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGFECHA1"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA2"] && CurrentUserID.CurrentParameters.IFECHA2 != "")
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGFECHA2"].HeaderText = CurrentUserID.CurrentParameters.IFECHA2;
                    camposuperior.Items.Add(pRODUCTOAETIQUETARDataGridView.Columns["DGFECHA2"].HeaderText);
                }
                else
                {
                    pRODUCTOAETIQUETARDataGridView.Columns["DGFECHA2"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BTAgregarGaffete_Click(object sender, EventArgs e)
        {
            CPERSONABE personaBE = new CPERSONABE();
            CPERSONAD personaD = new CPERSONAD();
            

            personaBE.IID = Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
            personaBE = personaD.seleccionarPERSONA(personaBE, null);
            AgregarPersonaDataRow(personaBE);

        }






        private bool AgregarPersonaDataRow(CPERSONABE personaBE)
        {
            try
            {
                DataRow[] filteredRows = dSCatalogos.PERSONAGAFFETE.Select(string.Format("{0} = '{1}'", "ID", personaBE.IID));

                if (filteredRows.Count() > 0)
                {
                    MessageBox.Show("ya se agrego ese producto a al lista");
                    return false;
                }


                dSCatalogos.PERSONAGAFFETE.AddPERSONAGAFFETERow(personaBE.IID, personaBE.IGAFFETE, personaBE.INOMBRE, personaBE.INOMBRES, personaBE.IAPELLIDOS);
                return true;
            }
            catch
            {
                MessageBox.Show("hubo un problema para agregar la persona a la lista de productos a imprimir");
                return false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb;
            sb = new StringBuilder();
            string buffer;
            string nombre;
            string gaffete;

            CZEBRACONFIGD zebraD = new CZEBRACONFIGD();
            CZEBRACONFIGBE zebraBE = new CZEBRACONFIGBE();
            zebraBE = zebraD.seleccionarZEBRACONFIG(null);

            string[] pTexto = {zebraBE.IA1_X_POSITION,zebraBE.IA2_Y_POSITION ,zebraBE.IA3_ROTATION , zebraBE.IA4_FONT_SELECTION , zebraBE.IA5_X_MULTIPLIER , zebraBE.IA6_Y_MULTIPLIER , zebraBE.IA7_REVERSEIMAGE  };        
            string[] pBarCode = {zebraBE.IB1_X_POSITION, zebraBE.IB2_Y_POSITION , zebraBE.IB3_ROTATION , zebraBE.IB4_BARCODE_SELECTION , zebraBE.IB5_NARROWBARWIDTH , zebraBE.IB6_WIDEBARWIDTH , zebraBE.IB7_BARCODEHEIGHT , zebraBE.IB8_PRINTHUMANREADABLE };


            foreach (Catalogos.DSCatalogos.PERSONAGAFFETERow p in dSCatalogos.PERSONAGAFFETE)
            {

                nombre = (p.NOMBRE == null) ? "" : p.NOMBRE.Trim();
                gaffete = (p.GAFFETE == null) ? "" : p.GAFFETE.Trim();

                buffer = EPLPrinter.PrintEtiqueta(TBImpresora2.Text, gaffete, "", nombre,
                zebraBE.IQ_LABELWIDTH, zebraBE.IQ_FORMLENGTH_1, zebraBE.IQ_FORMLENGTH_2, pTexto, pBarCode,
                1, !CBAnaquel.Checked);
                if (buffer.Equals("error"))
                {
                    MessageBox.Show("Ocurrio un error ");
                    return;
                }

                sb.Append(buffer);
            }

            TBOutPut.Text = sb.ToString();



        }

        List<string> GetPrinters()
        {

            PrintServer localPrintServer = new PrintServer();

            PrintQueueCollection printQueues = localPrintServer.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });

            var printerList = (from printer in printQueues

                               select printer.FullName).ToList();
          
            return printerList;

        }

        private void btnSelectPrinterName_Click(object sender, EventArgs e)
        {
            ShowPrinters showPrinters = new ShowPrinters(GetPrinters());
            showPrinters.ShowDialog();
            TBImpresora.Text = ShowPrinters.auxPrinterName;
            showPrinters.Dispose();
            GC.SuppressFinalize(showPrinters);
        }

        public string getFileLocalLocation_FE_IMG(CPARAMETROBE parametro)
        {
            return FileLocalLocation_FE_IMG.Replace("\\sampdata", parametro.IFACT_ELECT_FOLDER.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))); ;
        }

        private void pRODUCTOAETIQUETARDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex != -1)
            {

                if (pRODUCTOAETIQUETARDataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {
                   // int dgDoctoId = (int)pRODUCTOAETIQUETARDataGridView.Rows[e.RowIndex].Cells["CLAVE"].Value;
                   // int dgDoctoPeso = (int)pRODUCTOAETIQUETARDataGridView.Rows[e.RowIndex].Cells["PESO"].Value;
                   //  DataRow[] rows = dSCatalogos.PRODUCTOAETIQUETAR.Select(string.Format("{0} = '{1}' AND {2} = {3}", "CLAVE", dgDoctoId, "PESO", dgDoctoPeso));
                   pRODUCTOAETIQUETARDataGridView.Rows.RemoveAt(e.RowIndex);
                    //SCatalogos.PRODUCTOAETIQUETAR..Rows.Find(dgDoctoId).Delete();
                }
            }
        }

        private void btnAgregarCambiosPrecios_Click(object sender, EventArgs e)
        {
            WFSeleccionarFecha sf2 = new WFSeleccionarFecha();
            sf2.ShowDialog();
            DateTime? dateSelected = sf2.m_dateSelected;
            sf2.Dispose();
            GC.SuppressFinalize(sf2);

            if (dateSelected != null)
            {
                LlenarDataCambioPrecio(dateSelected, true);

                foreach(iPos.Importaciones.DSImportaciones.PRODUCTOPRECIOLOGRow dr in  this.dSImportaciones.PRODUCTOPRECIOLOG.Rows)
                {
                    CPRODUCTOBE prodBE = new CPRODUCTOBE();
                    CPRODUCTOD prodD = new CPRODUCTOD();
                    prodBE.IID = dr.PRODUCTOID;

                    prodBE = prodD.seleccionarPRODUCTO(prodBE, null);

                    if(prodBE != null)
                    {
                        AgregarDataRowCambioPrecio(prodBE, 1, false);
                    }

                }
            }
        }

        private void LlenarDataCambioPrecio(DateTime? dt, Boolean soloPrecio1)
        {
            try
            {
                this.pRODUCTOPRECIOLOGTableAdapter.Fill(this.dSImportaciones.PRODUCTOPRECIOLOG, dt, soloPrecio1 ? "S":"N");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }



        private bool AgregarDataRowCambioPrecio(CPRODUCTOBE prodBE, int cantidad, bool mostrarMensaje)
        {
            try
            {
                int peso = 1000;

                DataRow[] filteredRows = dSCatalogos.PRODUCTOAETIQUETAR.Select(string.Format("{0} = '{1}' AND {2} = {3}", "CLAVE", prodBE.ICLAVE, "PESO", peso.ToString()));

                if (filteredRows.Count() > 0)
                {
                    if (mostrarMensaje)
                    {
                        MessageBox.Show("ya se agrego ese producto a al lista");
                    }
                    return false;
                }

                string CAMPOIMPRIMIR = "__CAMPOPERSONALIZADO";
                if (RBCampo.Checked)
                {
                    try
                    {
                        CAMPOIMPRIMIR = camposuperior.SelectedItem.ToString();
                    }
                    catch
                    {
                        CAMPOIMPRIMIR = "Descripción";
                    }
                }

                decimal precio = ((!(bool)prodBE.isnull["IPRECIO1"]) ? prodBE.IPRECIO1 : 0) * ((100 + ((!(bool)prodBE.isnull["ITASAIVA"]) ? prodBE.ITASAIVA : 0)) / 100);


                dSCatalogos.PRODUCTOAETIQUETAR.AddPRODUCTOAETIQUETARRow(prodBE.ICLAVE, prodBE.INOMBRE, prodBE.IDESCRIPCION, prodBE.IEAN, precio, cantidad, prodBE.ITEXTO1, prodBE.ITEXTO2, prodBE.ITEXTO3, prodBE.ITEXTO4, prodBE.ITEXTO5, prodBE.ITEXTO6, prodBE.INUMERO1, prodBE.INUMERO2, prodBE.INUMERO3, prodBE.INUMERO4, prodBE.IFECHA1, prodBE.IFECHA2, this.textosuperior.Text, CAMPOIMPRIMIR, prodBE.IDESCRIPCION1, prodBE.ISUBSTITUTO,
                    peso,
                    prodBE.IPLUG, prodBE.IUNIDAD, prodBE.IID);
                return true;
            }
            catch
            {
                if (mostrarMensaje)
                {
                    MessageBox.Show("hubo un problema para agregar el producto a la lista de productos a imprimir");
                }
                return false;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            productIDs = "";

            int iCount = 0;

            foreach (DataGridViewRow row in pRODUCTOAETIQUETARDataGridView.Rows)
            {
                long productoId = long.Parse(row.Cells["DGPRODUCTOID"].Value.ToString());

                if (iCount > 0)
                    productIDs += ",";

                productIDs += productoId.ToString();

                iCount++;
            }


            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("PRODUCTOIDS", productIDs);

            string strReporte = "EtiquetasCambioPrecioNuevosPrecios.frx";

            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void WFImprimirEtiquetas_Shown(object sender, EventArgs e)
        {
            TBCodigo.Focus();
        }

        private void btnEtiquetaPequena_Click(object sender, EventArgs e)
        {
            
            string strReporte = "EtiquetasCambioPrecioNuevosPrecios_Peq.frx";
            ImprimirEtiquetaPorFR(strReporte);
        }

        private void ImprimirEtiquetaPorFR(string strReporte)
        {
            if (MessageBox.Show("Esta opcion reordenara el grid para mostrar el orden de impresion de las etiquetas. ¿Desea hacerlo? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            productIDs = "";
            productCOUNTs = "";
            productLibres = "";

            int iCount = 0;

            this.pRODUCTOAETIQUETARDataGridView.Sort(this.pRODUCTOAETIQUETARDataGridView.Columns["DGPRODUCTOID"], ListSortDirection.Ascending);

            Dictionary<long, int> prodCant = new Dictionary<long, int>();
            Dictionary<long, string> prodLibres = new Dictionary<long, string>();
            foreach (DataGridViewRow row in pRODUCTOAETIQUETARDataGridView.Rows)
            {

                long productoId = long.Parse(row.Cells["DGPRODUCTOID"].Value.ToString());
                int productoCopias = int.Parse(row.Cells["DGCANTIDAD"].Value.ToString());
                string productoLibres = row.Cells["TEXTOPERSONALIZADO"].Value.ToString();
                prodCant.Add(productoId, productoCopias);
                prodLibres.Add(productoId, productoLibres);
            }

            var listProd = prodCant.Keys.ToList();
            listProd.Sort();


            foreach (long productoId in listProd)
            {
                // long productoId = long.Parse(row.Cells["DGPRODUCTOID"].Value.ToString());
                int productoCopias = prodCant[productoId]; //int.Parse(row.Cells["DGCANTIDAD"].Value.ToString());
                string productoLibres = prodLibres[productoId];

                if (iCount > 0)
                {
                    productIDs += ",";
                    productCOUNTs += ",";
                    productLibres += ";";
                }

                

                productIDs += productoId.ToString();
                productCOUNTs += productoCopias.ToString();
                productLibres += productoLibres.ToString();

                iCount++;
            }


            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("PRODUCTOIDS", productIDs);
            dictionary.Add("PRODUCTOCOUNT", productCOUNTs);
            dictionary.Add("PRODUCTOLIBRES", productLibres);


            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void btnEtiquetaLarga_Click(object sender, EventArgs e)
        {


            string strReporte = "EtiquetasCambioPrecioNuevosPrecios_Lar.frx";
            ImprimirEtiquetaPorFR(strReporte);
        }
    }
}
