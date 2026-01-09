
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using static iPos.Catalogos.DSCatalogos3;

namespace iPos
{
    public partial class WFListaPrecioEdit : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;
        public delegate void AccionHandler(object source, Hashtable evtArgs);

        long productoId = 0;


        public WFListaPrecioEdit()
        {
            InitializeComponent();
        }


        public void ReCargar(string popc,string pCLAVE)
        {
            opc = popc;
            CLAVE = pCLAVE;
            validadores = new System.Collections.ArrayList();
            validadores.Add(RFV_CLAVE);

            this.button1.Text = opc;
            if (this.opc != "Agregar" && this.opc != "")
            {
                if (this.opc == "Consultar")
                {
                    this.button1.Visible = false;
                    this.BTCancelar.Text = "Salir";
                    this.BTCancelar.Image = global::iPos.Properties.Resources.Exit;
                }
                else { HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false; }
                LlenarDatosDeBase();
                this.CLAVETextBox.Enabled = false;
                this.pnlDetalles.Enabled = true;
            }
            else if (this.opc == "Agregar")
            {
                HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false;
                this.pnlDetalles.Enabled = false;
            }
        }



        private void LINEAEdit_Reg_Load(object sender, EventArgs e)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            COSTOREPOSICIONTextBox.ReadOnly = !usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARCOSTOREPO_LISTAPREC, null);

        }


        private bool LlenarDatosDeBase()
        {
            try
            {
                CLISTAPRECIOD listaprecioD = new CLISTAPRECIOD();
                CLISTAPRECIOBE listaprecioBE = new CLISTAPRECIOBE();

                listaprecioBE.ICLAVE = CLAVE;
                listaprecioBE = listaprecioD.seleccionarLISTAPRECIOxCLAVE(listaprecioBE, null);

                if (listaprecioBE == null)
                    return false;

                this.ID = listaprecioBE.IID;

                this.CLAVETextBox.Text = listaprecioBE.ICLAVE;

                this.NOMBRETextBox.Text = listaprecioBE.INOMBRE;
                


                this.ACTIVOTextBox.Checked = (listaprecioBE.IACTIVO == "S") ? true : false;

                LlenarDetalles();

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


        private CLISTAPRECIOBE ObtenerDatosCapturados()
        {
            CLISTAPRECIOBE BANCOBE = new CLISTAPRECIOBE();
            BANCOBE.IACTIVO= (this.ACTIVOTextBox.Checked) ? "S" : "N";

            if (this.CLAVETextBox.Text != "")
            {
                BANCOBE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                BANCOBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }
            


            return BANCOBE;

        }

        public void SaveChanges()
        {


            string ErroresValidacion = "";

            if (this.opc == "Borrar")
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarKeys);
            else
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarTodos);

            this.LBError.Text = ErroresValidacion;
            if (ErroresValidacion == "")
            {

                try
                {
                    CLISTAPRECIOD BANCOD = new CLISTAPRECIOD();

                    if (opc == "Agregar")
                    {
                        CLISTAPRECIOBE BANCOBE = new CLISTAPRECIOBE();
                        BANCOBE = ObtenerDatosCapturados();

                        BANCOBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        BANCOBE = BANCOD.AgregarLISTAPRECIOD(BANCOBE, null);

                        if (BANCOD.IComentario == "" || BANCOD.IComentario == null)
                        {
                            this.ID = BANCOBE.IID;
                            
                                MessageBox.Show("El registro se ha insertado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);
                                this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + BANCOD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CLISTAPRECIOBE BANCOBEAnt = new CLISTAPRECIOBE();

                        CLISTAPRECIOBE BANCOBE = new CLISTAPRECIOBE();

                        BANCOBE = ObtenerDatosCapturados();

                        BANCOBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        BANCOBEAnt.IID = this.ID;

                        BANCOD.CambiarLISTAPRECIOD(BANCOBE, BANCOBEAnt, null);
                        if (BANCOD.IComentario == "" || BANCOD.IComentario == null)
                        {
                                MessageBox.Show("El registro se ha cambiado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);


                                this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + BANCOD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CLISTAPRECIOBE BANCOBEAnt = new CLISTAPRECIOBE();
                            BANCOBEAnt.IID = this.ID;
                            BANCOD.BorrarLISTAPRECIOD(BANCOBEAnt, null);
                            if (BANCOD.IComentario == "" || BANCOD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + BANCOD.IComentario.Replace("%", "\n"));
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error Asegurese de que metio los datos en el formato correcto " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(ErroresValidacion);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void HabilitarEdicion(bool b)
        {

            HabilitarValidadores(false);
            panel1.Enabled = b;
            HabilitarValidadores(true);

        }

        private void LimpiarVariablesForm()
        {
            this.ID = -1;
            this.CLAVE = "";
        }

        private void Limpiar()
        {
            Limpiar(false);
        }

        private void Limpiar(bool bLimpiarKeys)
        {
           
            this.ACTIVOTextBox.Checked = false;

            this.CLAVETextBox.Text = "";


            this.NOMBRETextBox.Text = "";





        }



        private void IDTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void SetMode()
        {
            if ( this.CLAVETextBox.Text != "" )
            {
                this.CLAVE = this.CLAVETextBox.Text;

                if (this.LlenarDatosDeBase())
                {
                    if (this.opc != "Agregar" && this.opc != "")
                    {
                        this.opc = "Cambiar";
                        HabilitarEdicion(true);
                        this.BTIniciaEdicion.Enabled = false;
                        this.pnlDetalles.Enabled = true;
                    }
                    else
                    {
                        this.BTIniciaEdicion.Enabled = true;
                        this.pnlDetalles.Enabled = false;
                    }

                }
                else
                {
                    this.opc = "Agregar";
                    Limpiar();
                    HabilitarEdicion(true);
                    //this.btEliminar.Enabled = false;
                    this.BTIniciaEdicion.Enabled = false;
                }
            }
            else
            {
                Limpiar();
                HabilitarEdicion(false);
                //this.btEliminar.Enabled = false;
                this.BTIniciaEdicion.Enabled = false;
            }
        }



        private void IDTextBox_Validated(object sender, EventArgs e)
        {
            SetMode();
        }


        public void Resetear() // new for generator
        {
            HabilitarValidadores(false); // new generator
            Limpiar(true);
            this.opc = "";
            //this.IDTextBox.Focus();
            this.CLAVETextBox.Focus();
            HabilitarValidadores(true);
            this.HabilitarEdicion(false);
        }

        public void HabilitarValidadores(bool bEnabled) // new for generator
        {
            CustomValidation.BaseValidator[] validors = new CustomValidation.BaseValidator[this.validadores.Count];
            this.validadores.CopyTo(validors, 0);
            foreach (CustomValidation.BaseValidator v in validors)
            {
                try
                {
                    v.Enabled = bEnabled;
                }
                catch
                {
                }
            }
        }


        public void Validar(ref string ErroresValidacion, int iCamposAValidar)
        {
            CustomValidation.BaseValidator[] validors = new CustomValidation.BaseValidator[this.validadores.Count];
            this.validadores.CopyTo(validors, 0);
            foreach (CustomValidation.BaseValidator v in validors)
            {
                try
                {

                    if (iCamposAValidar == (int)CamposAValidar.ValidarKeys)
                    {
                        if (v.ControlToValidate.Name != "CLAVETextBox")
                            continue;
                    }
                    v.Validate();
                    if (!v.IsValid)
                    {
                        ErroresValidacion += v.ErrorMessage + "--";
                    }
                }
                catch
                {
                }
            }
        }

        private void CLAVETextBox_Validating(object sender, CancelEventArgs e)
        {
            if (this.opc != "Agregar" && this.opc != "")
            {
                this.CLAVE = CLAVETextBox.Text;
                if (!LlenarDatosDeBase())
                {
                    e.Cancel = true;
                    MessageBox.Show("No existe una linea con esa clave");
                }
            }
        }

        private void BTIniciaEdicion_Click(object sender, EventArgs e)
        {
            this.opc = "Cambiar";
            HabilitarEdicion(true);
            this.BTIniciaEdicion.Enabled = false;
            this.button1.Visible = true;
            this.button1.Enabled = true;
            this.button1.Text = "Guardar";
        }

        private void BTCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

                this.PRECIO1TextBox.Focus();
                PRECIO1TextBox.Select(0, PRECIO1TextBox.Text.Length);
            }
        }




        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {
            fillDataFromCodigo();
            this.PRECIO1TextBox.Focus();

        }



        private void fillDataFromCodigo()
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
            this.LBProductoDescripcion.Text = prod.IDESCRIPCION1;

            productoId = prod.IID;

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
            preciosTempBE.IPRODUCTOID = productoId;
            preciosTempBE.ILISTAPRECIOID = ID;
            preciosTempBE = preciosTempD.seleccionarRegistrosLISTAPRECIODETALLEXListaYProducto(ID, productoId, null);

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

        //private bool ActualizarDetalles()
        //{
        //    CLISTAPRECIODETALLED listaPrecioD = new CLISTAPRECIODETALLED();


        //    List<CLISTAPRECIODETALLEBE> lista = new List<CLISTAPRECIODETALLEBE>();




        //    foreach (LISTAPRECIODETALLERow rowex in this.dSCatalogos3.LISTAPRECIODETALLE.Rows)
        //    {
        //        CLISTAPRECIODETALLEBE item = new CLISTAPRECIODETALLEBE();
        //        item.IACTIVO = "S";
        //        item.IPRODUCTOID = rowex.PRODUCTOID;
        //        item.ILISTAPRECIOID = rowex.LISTAPRECIOID;
        //        item.IPRECIO1 = rowex.PRECIO1;
        //        item.IPRECIO2 = rowex.PRECIO2;
        //        item.IPRECIO3 = rowex.PRECIO3;
        //        item.IPRECIO4 = rowex.PRECIO4;
        //        item.IPRECIO5 = rowex.PRECIO5;

        //        lista.Add(item);
        //    }


        //    if(!listaPrecioD.ActualizarDetallesLista(lista, ID, null))
        //    {

        //        MessageBox.Show(listaPrecioD.IComentario);
        //        return false;
        //    }

        //    return true;



        //}

        private void BTAgregarPrecio_Click(object sender, EventArgs e)
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

            productoId = prod.IID;

            Boolean desgloseIeps = CurrentUserID.CurrentParameters.IDESGLOSEIEPS != null && CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S");
            //decimal precioEspecificoConImpuesto = decimal.Parse(PRECIO1TextBox.Text);



            CLISTAPRECIODETALLEBE detalleBE = new CLISTAPRECIODETALLEBE();

            //LISTAPRECIODETALLERow row = this.dSCatalogos3.LISTAPRECIODETALLE.NewLISTAPRECIODETALLERow();

            detalleBE.IPRODUCTOID = productoId;
            detalleBE.ILISTAPRECIOID = ID;
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
                if(CBPrecioConImpuesto.Checked)
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


            if(detalleD.AgregarOCambiarLISTAPRECIODETALLED(detalleBE, null) == null)
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
            TBCodigo.Focus();

        }



        private void LimpiarActual()
        {
            productoId = 0;
            TBCodigo.Text = "";

            this.PRECIO1TextBox.Text = "";
            this.PRECIO2TextBox.Text = "";
            this.PRECIO3TextBox.Text = "";
            this.PRECIO4TextBox.Text = "";
            this.PRECIO5TextBox.Text = "";

            this.COSTOREPOSICIONTextBox.Text = "";

            this.TIENEVIGCheckBox.Checked = false;
            this.FECHAVIGDateTimePicker.Value = DateTime.Today.AddYears(10);


            this.LBProductoDescripcion.Text = "";
        }

        private void LlenarDetalles()
        {
            try
            {
                this.lISTAPRECIODETALLETableAdapter.Fill(this.dSCatalogos3.LISTAPRECIODETALLE, ID);
            }
            catch(Exception ex)
            {

            }
        }

        private void BTImportarListaPrecio_Click(object sender, EventArgs e)
        {
            WFImportarListaPrecioDesdeExcel wf = new WFImportarListaPrecioDesdeExcel(this.ID);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);

            this.LlenarDetalles();
        }





        private void PRECIO1TextBox_Validating(object sender, CancelEventArgs e)
        {
            decimal precio1 = 0, precio2 = 0;
            decimal costoreposicion = 0;


            if (this.PRECIO1TextBox.Text != "")
            {
                precio1 = decimal.Parse(this.PRECIO1TextBox.Text.ToString());
            }


            if (this.PRECIO2TextBox.Text != "")
            {
                precio2 = decimal.Parse(this.PRECIO2TextBox.Text.ToString());
            }



            if (this.COSTOREPOSICIONTextBox.Text != "")
            {
                costoreposicion = decimal.Parse(this.COSTOREPOSICIONTextBox.Text.ToString());
            }


            if (((CurrentUserID.CurrentParameters.IPRECIOSORDENADOS == null || CurrentUserID.CurrentParameters.IPRECIOSORDENADOS == "S") &&
                (precio1 < precio2)) ||
                precio1 < costoreposicion)
            {
                MessageBox.Show("Asegurese de que precio1 sea mayor o igual que precio2 y mayor o igual que el costo reposicion. ");
                e.Cancel = true;
            }



        }




        private void PRECIO2TextBox_Validating(object sender, CancelEventArgs e)
        {

            decimal precio1 = 0, precio2 = 0, precio3 = 0;
            decimal costoreposicion = 0;



            if (this.PRECIO1TextBox.Text != "")
            {
                precio1 = decimal.Parse(this.PRECIO1TextBox.Text.ToString());
            }

            if (this.PRECIO2TextBox.Text != "")
            {
                precio2 = decimal.Parse(this.PRECIO2TextBox.Text.ToString());
            }


            if (this.PRECIO3TextBox.Text != "")
            {
                precio3 = decimal.Parse(this.PRECIO3TextBox.Text.ToString());
            }


            if (this.COSTOREPOSICIONTextBox.Text != "")
            {
                costoreposicion = decimal.Parse(this.COSTOREPOSICIONTextBox.Text.ToString());
            }


            if (((CurrentUserID.CurrentParameters.IPRECIOSORDENADOS == null || CurrentUserID.CurrentParameters.IPRECIOSORDENADOS == "S") &&
                (precio1 < precio2 || precio2 < precio3)) ||
                precio2 < costoreposicion)
            {
                MessageBox.Show("Asegurese de que precio1 sea mayor o igual que precio2 , que el precio 2 sea mayor o igual que el  precio 3 y mayor o igual que el costo reposicion. ");
                e.Cancel = true;
            }

        }

        private void PRECIO3TextBox_Validating(object sender, CancelEventArgs e)
        {


            decimal precio4 = 0, precio2 = 0, precio3 = 0;
            decimal costoreposicion = 0;



            if (this.PRECIO4TextBox.Text != "")
            {
                precio4 = decimal.Parse(this.PRECIO4TextBox.Text.ToString());
            }

            if (this.PRECIO2TextBox.Text != "")
            {
                precio2 = decimal.Parse(this.PRECIO2TextBox.Text.ToString());
            }


            if (this.PRECIO3TextBox.Text != "")
            {
                precio3 = decimal.Parse(this.PRECIO3TextBox.Text.ToString());
            }


            if (this.COSTOREPOSICIONTextBox.Text != "")
            {
                costoreposicion = decimal.Parse(this.COSTOREPOSICIONTextBox.Text.ToString());
            }


            if (((CurrentUserID.CurrentParameters.IPRECIOSORDENADOS == null || CurrentUserID.CurrentParameters.IPRECIOSORDENADOS == "S") &&
                (precio2 < precio3 || precio3 < precio4)) ||
                precio3 < costoreposicion)
            {
                MessageBox.Show("Asegurese de que precio2 sea mayor o igual que precio3 , que el precio 3 sea mayor o igual que el  precio 4 y mayor o igual que el costo reposicion. ");
                e.Cancel = true;
            }
        }

        private void PRECIO4TextBox_Validating(object sender, CancelEventArgs e)
        {
            decimal precio4 = 0, precio5 = 0, precio3 = 0;
            decimal costoreposicion = 0;



            if (this.PRECIO4TextBox.Text != "")
            {
                precio4 = decimal.Parse(this.PRECIO4TextBox.Text.ToString());
            }

            if (this.PRECIO5TextBox.Text != "")
            {
                precio5 = decimal.Parse(this.PRECIO5TextBox.Text.ToString());
            }


            if (this.PRECIO3TextBox.Text != "")
            {
                precio3 = decimal.Parse(this.PRECIO3TextBox.Text.ToString());
            }


            if (this.COSTOREPOSICIONTextBox.Text != "")
            {
                costoreposicion = decimal.Parse(this.COSTOREPOSICIONTextBox.Text.ToString());
            }


            if (((CurrentUserID.CurrentParameters.IPRECIOSORDENADOS == null || CurrentUserID.CurrentParameters.IPRECIOSORDENADOS == "S") &&
                (precio3 < precio4 || precio4 < precio5)) ||
                precio4 < costoreposicion)
            {
                MessageBox.Show("Asegurese de que precio3 sea mayor o igual que precio4 , que el precio 4 sea mayor o igual que el  precio 5 y mayor o igual que el costo reposicion. ");
                e.Cancel = true;
            }
        }

        private void PRECIO5TextBox_Validating(object sender, CancelEventArgs e)
        {
            decimal precio4 = 0, precio5 = 0;
            decimal costoreposicion = 0;



            if (this.PRECIO4TextBox.Text != "")
            {
                precio4 = decimal.Parse(this.PRECIO4TextBox.Text.ToString());
            }

            if (this.PRECIO5TextBox.Text != "")
            {
                precio5 = decimal.Parse(this.PRECIO5TextBox.Text.ToString());
            }


            if (this.COSTOREPOSICIONTextBox.Text != "")
            {
                costoreposicion = decimal.Parse(this.COSTOREPOSICIONTextBox.Text.ToString());
            }


            if (((CurrentUserID.CurrentParameters.IPRECIOSORDENADOS == null || CurrentUserID.CurrentParameters.IPRECIOSORDENADOS == "S") &&
                (precio4 < precio5)) ||
                precio5 < costoreposicion)
            {
                MessageBox.Show("Asegurese de que precio4 sea mayor o igual que precio5 , que el precio 5 sea mayor o igual que el costo reposicion. ");
                e.Cancel = true;
            }
        }

        private void lISTAPRECIODETALLEDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (lISTAPRECIODETALLEDataGridView.Columns[e.ColumnIndex].Name == "DGBORRAR")
                {


                    if (MessageBox.Show("Esto eliminara este registro. Esta seguro de que desea hacerlo ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return ;
                    }

                    long dtlId = long.Parse(lISTAPRECIODETALLEDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());

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
                else if (lISTAPRECIODETALLEDataGridView.Columns[e.ColumnIndex].Name == "DGEDITAR")
                {

                    LimpiarActual();
                    TBCodigo.Text = lISTAPRECIODETALLEDataGridView.Rows[e.RowIndex].Cells["DGCLAVE"].Value.ToString();

                    fillDataFromCodigo();
                    this.PRECIO1TextBox.Focus();
                }
            }
        }

        private void BTExportarListaPrecio_Click(object sender, EventArgs e)
        {

            WFExportarListaPrecioDesdeExcel wf = new WFExportarListaPrecioDesdeExcel(this.ID);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Esto eliminara todos los detalles de esta lista. Esta seguro de que desea hacerlo ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            CLISTAPRECIODETALLED lista = new CLISTAPRECIODETALLED();
            if(!lista.BorrarxListaPrecio(ID, null))
            {
                MessageBox.Show("Hubo un error al eliminar los registros " +  lista.IComentario);
            }
            else
            {
                MessageBox.Show("Se eliminaron los registros");
                this.LlenarDetalles();
            }
        }

        private void BTCargarProductos_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Esto eliminara todos los detalles de esta lista y pondra los registros con los precios actuales de productos. Esta seguro de que desea hacerlo ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }


            CLISTAPRECIODETALLED lista = new CLISTAPRECIODETALLED();
            if (!lista.LISTAPRECIO_CARGARTODOS(ID, null))
            {
                MessageBox.Show("Hubo un error al cargar los registros " + lista.IComentario);
            }
            else
            {
                MessageBox.Show("Se cargaron los registros");
                this.LlenarDetalles();
            }
        }
    }
}
