
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
using System.IO;

namespace iPos
{
    public partial class WFPromocionEdit : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;
        public delegate void AccionHandler(object source, Hashtable evtArgs);
        long productID = 0;


        bool m_bChangeImage = false;
        string m_imageExtension = "";

        public WFPromocionEdit()
        {
            InitializeComponent();
        }


        public void ReCargar(string popc, string pCLAVE)
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
            }
            else if (this.opc == "Agregar")
            {
                HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false;
            }
        }



        private void LINEAEdit_Reg_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSCatalogos.SUCURSAL' table. You can move, or remove it, as needed.
            //this.sUCURSALTableAdapter.Fill(this.dSCatalogos.SUCURSAL);


            CargarSucursales();

            if (this.opc != "Agregar" && this.opc != "")
            {
                CargarSucursalesPorPromocion();
            }
        }


        private bool LlenarDatosDeBase()
        {
            string strBuffer = "";
            decimal cantidad = 0;

            m_bChangeImage = false;

            try
            {
                CPROMOCIOND promocionD = new CPROMOCIOND();
                CPROMOCIONBE promocionBE = new CPROMOCIONBE();

                promocionBE.ICLAVE = CLAVE;
                promocionBE = promocionD.seleccionarPROMOCIONxCLAVE(promocionBE, null);

                if (promocionBE == null)
                    return false;

                this.ID = promocionBE.IID;

                this.CLAVETextBox.Text = promocionBE.ICLAVE;

                this.NOMBRETextBox.Text = promocionBE.INOMBRE;

                this.ACTIVOTextBox.Checked = (promocionBE.IACTIVO == "S") ? true : false;


                this.ENMONEDEROTextBox.Checked = (promocionBE.IENMONEDERO == "S") ? true : false;

                this.LUNESTextBox.Checked = (promocionBE.ILUNES == "S") ? true : false;
                this.MARTESTextBox.Checked = (promocionBE.IMARTES == "S") ? true : false;
                this.MIERCOLESTextBox.Checked = (promocionBE.IMIERCOLES == "S") ? true : false;
                this.JUEVESTextBox.Checked = (promocionBE.IJUEVES == "S") ? true : false;
                this.VIERNESTextBox.Checked = (promocionBE.IVIERNES == "S") ? true : false;
                this.SABADOTextBox.Checked = (promocionBE.ISABADO == "S") ? true : false;
                this.DOMINGOTextBox.Checked = (promocionBE.IDOMINGO == "S") ? true : false;


                this.MOSTRARDATOSCLIENTETextBox.Checked = (promocionBE.IMOSTRARDATOSCLIENTE == "S") ? true : false;

                this.ESMULTIDETALLETextBox.Checked = (promocionBE.IESMULTIDETALLE == "S") ? true : false;
                this.DESCMULTIDETALLETextBox.Text = promocionBE.IDESCMULTIDETALLE;

                try
                {
                    if (!(bool)promocionBE.isnull["IFECHAINICIO"])
                    {
                        this.FECHAINICIOTextBox.Value = promocionBE.IFECHAINICIO;
                    }
                }
                catch
                {
                }

                try
                {
                    if (!(bool)promocionBE.isnull["IFECHAFIN"])
                    {
                        this.FECHAFINTextBox.Value = promocionBE.IFECHAFIN;
                    }
                }
                catch
                {
                }



                if (!(bool)promocionBE.isnull["ICANTIDADLLEVATE"])
                    this.CANTIDADLLEVATETextBox.Text = promocionBE.ICANTIDADLLEVATE.ToString();

                if (!(bool)promocionBE.isnull["IIMPORTE"])
                {
                    if (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTE)
                    {
                        this.IMPORTETextBox.Text = promocionBE.IIMPORTE.ToString();
                    }
                    else
                    {
                        this.IMPORTE6TextBox.Text = promocionBE.IIMPORTE.ToString();
                    }
                }


                if (!(bool)promocionBE.isnull["IPORCENTAJEDESCUENTO"])
                    this.PORCENTAJEDESCUENTOTextBox.Text = promocionBE.IPORCENTAJEDESCUENTO.ToString();



                if (!(bool)promocionBE.isnull["ICANTIDAD"])
                    cantidad = promocionBE.ICANTIDAD;

                if (!(bool)promocionBE.isnull["ILINEAID"])
                {
                    this.LINEAIDTextBox.DbValue = promocionBE.ILINEAID.ToString();
                    this.LINEAIDTextBox.MostrarErrores = false;
                    this.LINEAIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.LINEAIDTextBox.MostrarErrores = true;
                }

                if (!(bool)promocionBE.isnull["IPRODUCTOID"])
                {
                    CPRODUCTOD prodD = new CPRODUCTOD();
                    CPRODUCTOBE prodBE = new CPRODUCTOBE();
                    prodBE.IID = promocionBE.IPRODUCTOID;
                    prodBE = prodD.seleccionarPRODUCTO(prodBE, null);
                    if (prodBE != null)
                    {
                        PRODUCTOIDTextBox.Text = prodBE.IID.ToString();
                        PRODUCTOIDLabel.Text = prodBE.INOMBRE;
                        productID = prodBE.IID;
                    }
                    else
                    {
                        PRODUCTOIDTextBox.Text = "";
                        PRODUCTOIDLabel.Text = "";

                    }
                }




                /*
        public const long _RANGOPROMOCIONXPRODUCTO = 1;
        public const long _RANGOPROMOCIONXLINEA = 1;

        public const long _TIPOPROMOCIONCOMPRASXLLEVASMAS = 1;
        public const long _TIPOPROMOCIONCOMPRASXCONIMPORTE = 2;
        public const long _TIPOPROMOCIONDESCUENTOPORCENTAJE = 3;*/

                if ((bool)promocionBE.isnull["IRANGOPROMOCIONID"])
                {
                    promocionBE.IRANGOPROMOCIONID = DBValues._RANGOPROMOCIONXPRODUCTO;
                }

                this.RBRANGOLINEA.Checked = (promocionBE.IRANGOPROMOCIONID == DBValues._RANGOPROMOCIONXLINEA);
                this.RBRANGOPRODUCTO.Checked = (promocionBE.IRANGOPROMOCIONID != DBValues._RANGOPROMOCIONXLINEA);
                this.RBRANGOGENERAL.Checked = (promocionBE.IRANGOPROMOCIONID == DBValues._RANGOPROMOCIONGENERAL);

                if (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONBODEGAZO)
                {
                    this.RBRANGOBODEGAZO.Checked = true;
                    this.RBRANGOLINEA.Checked = false;
                    this.RBRANGOPRODUCTO.Checked = false;
                }

                if(promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONCUPONES || 
                   promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONCUPONPORCADAMONTODEIMPORTE)
                {
                    this.RBTIPOPROMOCIONCUPONES.Checked = true;

                    if (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONCUPONES)
                    {
                        this.RBMONTOMINIMO.Checked = true;
                    }
                    else
                    {
                        this.RBCADAMONTO.Checked = true;
                    }

                    this.montoMinimoNumericTextBox.Text = promocionBE.IIMPORTE.ToString();
                    this.leyendaTextBox.Text = promocionBE.IDESCRIPCION;
                }

                SetHabilitacionesPorRango(promocionBE.IRANGOPROMOCIONID);


                if ((bool)promocionBE.isnull["IRANGOPROMOCIONID"])
                {
                    promocionBE.ITIPOPROMOCIONID = DBValues._TIPOPROMOCIONCOMPRASXLLEVASMAS;
                }

                this.RBTIPOPROMOCION1.Checked = (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONCOMPRASXLLEVASMAS);
                this.RBTIPOPROMOCION2.Checked = (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTE);
                this.RBTIPOPROMOCION3.Checked = (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONDESCUENTOPORCENTAJE);
                this.RBTIPOPROMOCION4.Checked = (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONDESC_MONTOMIN_LINEA);
                this.RBTIPOPROMOCION6.Checked = (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTEMANTEN);
                this.RBTIPOPROMOCION7.Checked = (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONBODEGAZO);


                this.CANTIDAD2TextBox.Text = "";
                this.CANTIDADTextBox.Text = "";
                if (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONCOMPRASXLLEVASMAS)
                {
                    this.CANTIDADTextBox.Text = cantidad.ToString();
                }
                else if (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTE)
                {
                    this.CANTIDAD2TextBox.Text = cantidad.ToString();
                }
                else if (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTEMANTEN)
                {
                    this.CANTIDAD6TextBox.Text = cantidad.ToString();
                }
                else if (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONDESC_MONTOMIN_LINEA)
                {
                    if (!(bool)promocionBE.isnull["IIMPORTE"])
                        this.MONTOMINDESCLINEATextBox.Text = promocionBE.IIMPORTE.ToString();

                    if (!(bool)promocionBE.isnull["IPORCENTAJEDESCUENTO"])
                        this.DESCMONTOMINTextBox.Text = promocionBE.IPORCENTAJEDESCUENTO.ToString();


                    this.IMPORTETextBox.Text = "0";
                    this.IMPORTE6TextBox.Text = "0";
                    this.PORCENTAJEDESCUENTOTextBox.Text = "0";

                }
                else if (promocionBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONBODEGAZO)
                {


                    if (!(bool)promocionBE.isnull["IPORCENTAJEDESCUENTO"])
                        this.PORCENTAJEAUMENTOBODEGAZOTextBox.Text = promocionBE.IPORCENTAJEDESCUENTO.ToString();



                    this.ENMONEDEROBODEGAZOTextBox.Checked = (promocionBE.IENMONEDERO == "S") ? true : false;
                }


                if (!(bool)promocionBE.isnull["IIMAGEN"])
                {
                    this.IMAGENTextBox.Text = promocionBE.IIMAGEN.ToString();

                    string imagePath = CurrentUserID.CurrentParameters.IRUTAIMAGENESPRODUCTO + "\\" + promocionBE.IIMAGEN;
                    try
                    {
                        if (promocionBE.IIMAGEN.ToString() != "")
                        {

                            pictureBox1.Image = Image.FromFile(imagePath);
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                }


                SetHabilitacionesPorTipo(promocionBE.ITIPOPROMOCIONID);


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



        private void CargarSucursalesPorPromocion()
        {
            CPROMOCIONBE promocionBE = new CPROMOCIONBE();
            CPROMOCIOND promocionD = new CPROMOCIOND();
            promocionBE.IID = this.ID;
            CargarSucursalesPorPromocion(promocionBE, promocionD);
        }

        private void CargarSucursalesPorPromocion(CPROMOCIONBE promocionBE, CPROMOCIOND promocionD)
        {
            List<CPROMOCIONSUCURSALBE> sucursalesPorPromocion = promocionD.seleccionarSUCURSALESxPROMOCION(promocionBE, null);

            if (sucursalesPorPromocion != null)
            {
                if (sucursalesPorPromocion.Count > 0)
                {
                    foreach (CPROMOCIONSUCURSALBE sucursal in sucursalesPorPromocion)
                    {
                        foreach (DataGridViewRow dataRow in this.sUCURSALDataGridView.Rows)
                        {
                            long sucId = dataRow.Cells["DGID"].Value != null && dataRow.Cells["DGID"].Value != DBNull.Value ?
                                (long)dataRow.Cells["DGID"].Value : 0;

                            if (sucursal.ISUCURSALID == sucId)
                            {
                                dataRow.Cells["Seleccionada"].Value = 1;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: " + promocionD.IComentario);
            }
        }


        private CPROMOCIONBE ObtenerDatosCapturados()
        {
            CPROMOCIONBE PROMOCIONBE = new CPROMOCIONBE();
            PROMOCIONBE.IACTIVO = (this.ACTIVOTextBox.Checked) ? "S" : "N";

            if (this.CLAVETextBox.Text != "")
            {
                PROMOCIONBE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                PROMOCIONBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }


            PROMOCIONBE.IACTIVO = (this.ACTIVOTextBox.Checked) ? "S" : "N";

            PROMOCIONBE.IENMONEDERO = (this.ENMONEDEROTextBox.Checked) ? "S" : "N";

            PROMOCIONBE.ILUNES = (this.LUNESTextBox.Checked) ? "S" : "N";
            PROMOCIONBE.IMARTES = (this.MARTESTextBox.Checked) ? "S" : "N";
            PROMOCIONBE.IMIERCOLES = (this.MIERCOLESTextBox.Checked) ? "S" : "N";
            PROMOCIONBE.IJUEVES = (this.JUEVESTextBox.Checked) ? "S" : "N";
            PROMOCIONBE.IVIERNES = (this.VIERNESTextBox.Checked) ? "S" : "N";
            PROMOCIONBE.ISABADO = (this.SABADOTextBox.Checked) ? "S" : "N";
            PROMOCIONBE.IDOMINGO = (this.DOMINGOTextBox.Checked) ? "S" : "N";

            PROMOCIONBE.IMOSTRARDATOSCLIENTE = (this.MOSTRARDATOSCLIENTETextBox.Checked) ? "S" : "N";

            PROMOCIONBE.IDESCMULTIDETALLE = this.DESCMULTIDETALLETextBox.Text;
            PROMOCIONBE.IESMULTIDETALLE = (this.ESMULTIDETALLETextBox.Checked) ? "S" : "N";



            if (this.FECHAINICIOTextBox.Text != "")
            {
                PROMOCIONBE.IFECHAINICIO = this.FECHAINICIOTextBox.Value;
            }


            if (this.FECHAFINTextBox.Text != "")
            {
                PROMOCIONBE.IFECHAFIN = this.FECHAFINTextBox.Value;
            }



            if (this.CANTIDADLLEVATETextBox.Text != "")
            {
                PROMOCIONBE.ICANTIDADLLEVATE = decimal.Parse(this.CANTIDADLLEVATETextBox.Text.ToString());
            }
            if (this.PORCENTAJEDESCUENTOTextBox.Text != "")
            {
                PROMOCIONBE.IPORCENTAJEDESCUENTO = decimal.Parse(this.PORCENTAJEDESCUENTOTextBox.Text.ToString());
            }


            if (this.LINEAIDTextBox.Text != "")
            {
                PROMOCIONBE.ILINEAID = Int32.Parse(this.LINEAIDTextBox.DbValue.ToString());
            }

            if (this.PRODUCTOIDTextBox.Text != "")
            {
                PROMOCIONBE.IPRODUCTOID = Int32.Parse(this.PRODUCTOIDTextBox.Text);
            }

            if (RBRANGOLINEA.Checked)
                PROMOCIONBE.IRANGOPROMOCIONID = DBValues._RANGOPROMOCIONXLINEA;
            else if (RBRANGOBODEGAZO.Checked)
                PROMOCIONBE.IRANGOPROMOCIONID = DBValues._RANGOPROMOCIONXBODEGAZO;
            else if (RBRANGOGENERAL.Checked)
                PROMOCIONBE.IRANGOPROMOCIONID = DBValues._RANGOPROMOCIONGENERAL;
            else
                PROMOCIONBE.IRANGOPROMOCIONID = DBValues._RANGOPROMOCIONXPRODUCTO;

            if (RBTIPOPROMOCION4.Checked)
            {
                PROMOCIONBE.ITIPOPROMOCIONID = DBValues._TIPOPROMOCIONDESC_MONTOMIN_LINEA;


                if (this.MONTOMINDESCLINEATextBox.Text != "")
                {
                    PROMOCIONBE.IIMPORTE = decimal.Parse(this.MONTOMINDESCLINEATextBox.Text.ToString());
                }
                if (this.DESCMONTOMINTextBox.Text != "")
                {
                    PROMOCIONBE.IPORCENTAJEDESCUENTO = decimal.Parse(this.DESCMONTOMINTextBox.Text.ToString());
                }

            }
            else if (RBTIPOPROMOCIONCUPONES.Checked)
            {
                PROMOCIONBE.ITIPOPROMOCIONID = RBMONTOMINIMO.Checked ? 
                                               DBValues._TIPOPROMOCIONCUPONES : 
                                               DBValues._TIPOPROMOCIONCUPONPORCADAMONTODEIMPORTE;

                PROMOCIONBE.IDESCRIPCION = this.leyendaTextBox.Text;
                PROMOCIONBE.IIMPORTE = decimal.Parse(this.montoMinimoNumericTextBox.Text);
            }
            else if (RBTIPOPROMOCION3.Checked)
            {
                PROMOCIONBE.ITIPOPROMOCIONID = DBValues._TIPOPROMOCIONDESCUENTOPORCENTAJE;
                PROMOCIONBE.ICANTIDAD = 0;
            }
            else if (RBTIPOPROMOCION2.Checked)
            {
                PROMOCIONBE.ITIPOPROMOCIONID = DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTE;
                PROMOCIONBE.ICANTIDAD = decimal.Parse(this.CANTIDAD2TextBox.Text.ToString());
            }
            else if (RBTIPOPROMOCION6.Checked)
            {
                PROMOCIONBE.ITIPOPROMOCIONID = DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTEMANTEN;
                PROMOCIONBE.ICANTIDAD = decimal.Parse(this.CANTIDAD6TextBox.Text.ToString());
            }
            else if (RBTIPOPROMOCION7.Checked)
            {
                PROMOCIONBE.ITIPOPROMOCIONID = DBValues._TIPOPROMOCIONBODEGAZO;
                PROMOCIONBE.ICANTIDAD = 0;
                PROMOCIONBE.IPORCENTAJEDESCUENTO = decimal.Parse(this.PORCENTAJEAUMENTOBODEGAZOTextBox.Text.ToString());
                PROMOCIONBE.IENMONEDERO = (this.ENMONEDEROBODEGAZOTextBox.Checked) ? "S" : "N";
            }
            else
            {
                PROMOCIONBE.ITIPOPROMOCIONID = DBValues._TIPOPROMOCIONCOMPRASXLLEVASMAS;
                PROMOCIONBE.ICANTIDAD = decimal.Parse(this.CANTIDADTextBox.Text.ToString());
            }

            PROMOCIONBE.IPROMOCION = "N";


            if (this.IMPORTETextBox.Text != "" && PROMOCIONBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTE)
            {
                PROMOCIONBE.IIMPORTE = decimal.Parse(this.IMPORTETextBox.Text.ToString());
            }


            if (this.IMPORTE6TextBox.Text != "" && PROMOCIONBE.ITIPOPROMOCIONID == DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTEMANTEN)
            {
                PROMOCIONBE.IIMPORTE = decimal.Parse(this.IMPORTE6TextBox.Text.ToString());
            }


            if (m_bChangeImage)
            {
                if (pictureBox1.Image != null)
                    PROMOCIONBE.IIMAGEN = PROMOCIONBE.ICLAVE + "___1_PROMO." + Path.GetExtension(NuevaImagenTextBox.Text);
                else
                    PROMOCIONBE.IIMAGEN = "";
            }

            else
            {
                PROMOCIONBE.IIMAGEN = this.IMAGENTextBox.Text;
            }

            return PROMOCIONBE;

        }

        public bool validarConflictosPromociones(CPROMOCIONBE PROMOCIONBE, CPROMOCIOND PROMOCIOND)
        {

            if (PROMOCIONBE.IRANGOPROMOCIONID == DBValues._RANGOPROMOCIONXLINEA)
            {
                string existeStr = "N";
                if (PROMOCIOND.PROMOCIONEXISTEPARALINEA(PROMOCIONBE, ref existeStr, null))
                {
                    if (existeStr == "S")
                    {
                        MessageBox.Show("Ya hay una promocion activa coincidente en algun punto para esa linea, esas fechas y esos dias");
                        return false;
                    }
                }
            }

            return true;
        }

        public void SaveChanges()
        {


            string ErroresValidacion = "";

            if (this.opc == "Borrar")
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarKeys);
            else
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarTodos);

            if(ESMULTIDETALLETextBox.Checked && (!RBRANGOLINEA.Checked || (!RBTIPOPROMOCION1.Checked && !RBTIPOPROMOCION2.Checked)))
                ErroresValidacion += "A este momento , para las promociones multidetalle, solo soportamos rango linea y tipo promocion 'compra x cantidad y llevate mas'" + "--";

            this.LBError.Text = ErroresValidacion;
            if (ErroresValidacion == "")
            {

                try
                {
                    CPROMOCIOND PROMOCIOND = new CPROMOCIOND();

                    if (opc == "Agregar")
                    {
                        CPROMOCIONBE PROMOCIONBE = new CPROMOCIONBE();
                        PROMOCIONBE = ObtenerDatosCapturados();

                        if (!validarConflictosPromociones(PROMOCIONBE, PROMOCIOND))
                        {
                            return;
                        }

                        PROMOCIONBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        PROMOCIOND.AgregarPROMOCION(PROMOCIONBE, null);

                        if (PROMOCIOND.IComentario == "" || PROMOCIOND.IComentario == null)
                        {
                            PROMOCIONBE = PROMOCIOND.seleccionarPROMOCIONxCLAVE(PROMOCIONBE, null);

                            if (PROMOCIONBE != null)
                            {

                                if (m_bChangeImage)
                                {
                                    string imagePath = CurrentUserID.CurrentParameters.IRUTAIMAGENESPRODUCTO + "\\" + PROMOCIONBE.IIMAGEN;
                                    if (File.Exists(imagePath))
                                        File.Delete(imagePath);

                                    if (pictureBox1.Image != null)
                                    {
                                        pictureBox1.Image.Save(imagePath);
                                    }
                                    m_bChangeImage = false;
                                }


                                AgregarSucursalPromocion(opc, PROMOCIONBE.IID);
                            }


                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();
                        }
                        else
                            MessageBox.Show("ERRORES: " + PROMOCIOND.IComentario.Replace("%", "\n"));

                    }
                    else if (opc == "Cambiar")
                    {
                        CPROMOCIONBE PROMOCIONBEAnt = new CPROMOCIONBE();

                        CPROMOCIONBE PROMOCIONBE = new CPROMOCIONBE();

                        PROMOCIONBE = ObtenerDatosCapturados();

                        if (!validarConflictosPromociones(PROMOCIONBE, PROMOCIOND))
                        {
                            return;
                        }


                        PROMOCIONBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        PROMOCIONBEAnt.IID = this.ID;

                        PROMOCIOND.CambiarPROMOCION(PROMOCIONBE, PROMOCIONBEAnt, null);
                        if (PROMOCIOND.IComentario == "" || PROMOCIOND.IComentario == null)
                        {

                            if (m_bChangeImage)
                            {
                                string imagePath = CurrentUserID.CurrentParameters.IRUTAIMAGENESPRODUCTO + "\\" + PROMOCIONBE.IIMAGEN;
                                if (File.Exists(imagePath))
                                    File.Delete(imagePath);

                                if (pictureBox1.Image != null)
                                {
                                    pictureBox1.Image.Save(imagePath);
                                }
                                m_bChangeImage = false;
                            }

                            AgregarSucursalPromocion(opc, this.ID);

                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);


                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + PROMOCIOND.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CPROMOCIONBE PROMOCIONBEAnt = new CPROMOCIONBE();
                            PROMOCIONBEAnt.IID = this.ID;
                            PROMOCIOND.BorrarPROMOCION(PROMOCIONBEAnt, null);
                            if (PROMOCIOND.IComentario == "" || PROMOCIOND.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + PROMOCIOND.IComentario.Replace("%", "\n"));
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

        private void AgregarSucursalPromocion(string mod, long promId)
        {
            CPROMOCIONSUCURSALD promocionSucursalDao = new CPROMOCIONSUCURSALD();

            if (mod == "Cambiar")
            {
                promocionSucursalDao.BorrarXPromocionIdPROMOCIONSUCURSAL(promId, null);
            }

            foreach (DataGridViewRow row in sUCURSALDataGridView.Rows)
            {

                if (row.Cells["Seleccionada"].Value != null &&
                    row.Cells["Seleccionada"].Value != DBNull.Value &&
                    (short)row.Cells["Seleccionada"].Value == 1)
                {
                    CPROMOCIONSUCURSALBE promocionSucursal = new CPROMOCIONSUCURSALBE();

                    promocionSucursal.IPROMOCIONID = promId;
                    promocionSucursal.ISUCURSALID = (long)row.Cells["DGID"].Value;

                    promocionSucursalDao.AgregarPROMOCIONSUCURSAL(promocionSucursal, null);
                }
            }
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



            this.ENMONEDEROTextBox.Checked = false;

            this.LUNESTextBox.Checked = false;
            this.MARTESTextBox.Checked = false;
            this.MIERCOLESTextBox.Checked = false;
            this.JUEVESTextBox.Checked = false;
            this.VIERNESTextBox.Checked = false;
            this.SABADOTextBox.Checked = false;
            this.DOMINGOTextBox.Checked = false;


            this.MOSTRARDATOSCLIENTETextBox.Checked = false;


            this.FECHAINICIOTextBox.Value = DateTime.Today;
            this.FECHAFINTextBox.Value = DateTime.Today;


            this.CANTIDADLLEVATETextBox.Text = "";
            this.IMPORTETextBox.Text = "";
            this.IMPORTE6TextBox.Text = "";
            this.PORCENTAJEDESCUENTOTextBox.Text = "";


            this.LINEAIDTextBox.Text = "";
            this.PRODUCTOIDTextBox.Text = "";


            this.RBTIPOPROMOCION1.Checked = true;
            this.RBTIPOPROMOCION2.Checked = false;
            this.RBTIPOPROMOCION3.Checked = false;
            this.RBTIPOPROMOCION6.Checked = false;
            SetHabilitacionesPorTipo(DBValues._TIPOPROMOCIONCOMPRASXLLEVASMAS);

            this.RBRANGOLINEA.Checked = false;
            this.RBRANGOPRODUCTO.Checked = false;
            SetHabilitacionesPorRango(DBValues._RANGOPROMOCIONXPRODUCTO);


            this.CANTIDAD6TextBox.Text = "";
            this.CANTIDAD2TextBox.Text = "";
            this.CANTIDADTextBox.Text = "";

        }



        private void IDTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void SetMode()
        {
            if (this.CLAVETextBox.Text != "")
            {
                this.CLAVE = this.CLAVETextBox.Text;

                if (this.LlenarDatosDeBase())
                {
                    if (this.opc != "Agregar" && this.opc != "")
                    {
                        this.opc = "Cambiar";
                        HabilitarEdicion(true);
                        this.BTIniciaEdicion.Enabled = false;
                    }
                    else
                    {
                        this.BTIniciaEdicion.Enabled = true;
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


        private void SetHabilitacionesPorTipo(long tipo)
        {

            switch (tipo)
            {
                case DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTE:
                    {
                        this.CANTIDADTextBox.Enabled = false;
                        this.CANTIDADLLEVATETextBox.Enabled = false;
                        this.CANTIDAD2TextBox.Enabled = true;
                        this.IMPORTETextBox.Enabled = true;
                        this.PORCENTAJEDESCUENTOTextBox.Enabled = false;
                        this.ENMONEDEROTextBox.Enabled = false;
                        this.CANTIDAD6TextBox.Enabled = false;
                        this.IMPORTE6TextBox.Enabled = false;

                        pnlBodegazo.Enabled = false;

                        this.CANTIDADTextBox.Text = "";
                        this.CANTIDADLLEVATETextBox.Text = "";
                        this.PORCENTAJEDESCUENTOTextBox.Text = "";
                        this.ENMONEDEROTextBox.Checked = false;
                        this.CANTIDAD6TextBox.Text = "";
                        this.IMPORTE6TextBox.Text = "";
                        break;
                    }

                case DBValues._TIPOPROMOCIONDESCUENTOPORCENTAJE:
                    {
                        this.CANTIDADTextBox.Enabled = false;
                        this.CANTIDADLLEVATETextBox.Enabled = false;
                        this.CANTIDAD2TextBox.Enabled = false;
                        this.IMPORTETextBox.Enabled = false;
                        this.PORCENTAJEDESCUENTOTextBox.Enabled = true;
                        this.ENMONEDEROTextBox.Enabled = true;
                        this.CANTIDAD6TextBox.Enabled = false;
                        this.IMPORTE6TextBox.Enabled = false;

                        pnlBodegazo.Enabled = false;

                        this.CANTIDADTextBox.Text = "";
                        this.CANTIDADLLEVATETextBox.Text = "";
                        this.CANTIDAD2TextBox.Text = "";
                        this.IMPORTETextBox.Text = "";
                        this.CANTIDAD6TextBox.Text = "";
                        this.IMPORTE6TextBox.Text = "";

                        break;
                    }

                case DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTEMANTEN:
                    {
                        this.CANTIDADTextBox.Enabled = false;
                        this.CANTIDADLLEVATETextBox.Enabled = false;
                        this.CANTIDAD2TextBox.Enabled = false;
                        this.IMPORTETextBox.Enabled = false;
                        this.PORCENTAJEDESCUENTOTextBox.Enabled = false;
                        this.ENMONEDEROTextBox.Enabled = false;
                        this.CANTIDAD6TextBox.Enabled = true;
                        this.IMPORTE6TextBox.Enabled = true;

                        pnlBodegazo.Enabled = false;

                        this.CANTIDADTextBox.Text = "";
                        this.CANTIDADLLEVATETextBox.Text = "";
                        this.PORCENTAJEDESCUENTOTextBox.Text = "";
                        this.ENMONEDEROTextBox.Checked = false;
                        this.CANTIDAD2TextBox.Text = "";
                        this.IMPORTETextBox.Text = "";
                        break;
                    }


                case DBValues._TIPOPROMOCIONBODEGAZO:
                    {
                        this.CANTIDADTextBox.Enabled = false;
                        this.CANTIDADLLEVATETextBox.Enabled = false;
                        this.CANTIDAD2TextBox.Enabled = false;
                        this.IMPORTETextBox.Enabled = false;
                        this.PORCENTAJEDESCUENTOTextBox.Enabled = false;
                        this.ENMONEDEROTextBox.Enabled = false;
                        this.CANTIDAD6TextBox.Enabled = false;
                        this.IMPORTE6TextBox.Enabled = false;

                        pnlBodegazo.Enabled = true;


                        this.CANTIDADTextBox.Text = "";
                        this.CANTIDADLLEVATETextBox.Text = "";
                        this.PORCENTAJEDESCUENTOTextBox.Text = "";
                        this.ENMONEDEROTextBox.Checked = false;
                        this.CANTIDAD2TextBox.Text = "";
                        this.IMPORTETextBox.Text = "";
                        break;
                    }
                default:
                    {
                        this.CANTIDADTextBox.Enabled = true;
                        this.CANTIDADLLEVATETextBox.Enabled = true;
                        this.CANTIDAD2TextBox.Enabled = false;
                        this.IMPORTETextBox.Enabled = false;
                        this.PORCENTAJEDESCUENTOTextBox.Enabled = false;
                        this.ENMONEDEROTextBox.Enabled = false;
                        this.CANTIDAD6TextBox.Enabled = false;
                        this.IMPORTE6TextBox.Enabled = false;

                        pnlBodegazo.Enabled = false;

                        this.CANTIDAD2TextBox.Text = "";
                        this.IMPORTETextBox.Text = "";
                        this.CANTIDAD6TextBox.Text = "";
                        this.IMPORTE6TextBox.Text = "";
                        this.PORCENTAJEDESCUENTOTextBox.Text = "";
                        this.ENMONEDEROTextBox.Checked = false;
                        break;
                    }
            }
        }


        private void SetHabilitacionesPorRango(long rango)
        {
            switch (rango)
            {
                case DBValues._RANGOPROMOCIONXLINEA:
                    {
                        this.LINEAIDTextBox.Enabled = true;
                        this.LINEAIDButton.Enabled = true;
                        this.LINEAIDLabel.Enabled = true;

                        this.pnlPromocionXMontoMin.Enabled = true;
                        this.pnlBodegazo.Enabled = false;


                        this.PRODUCTOIDTextBox.Enabled = false;
                        this.PRODUCTOIDButton.Enabled = false;
                        this.PRODUCTOIDLabel.Enabled = false;
                        this.PRODUCTOIDTextBox.Text = "";
                        this.PRODUCTOIDLabel.Text = "";

                        break;

                    }


                case DBValues._RANGOPROMOCIONXBODEGAZO:
                    {
                        this.LINEAIDTextBox.Enabled = false;
                        this.LINEAIDButton.Enabled = false;
                        this.LINEAIDLabel.Enabled = false;

                        this.pnlPromocionXMontoMin.Enabled = false;
                        this.pnlBodegazo.Enabled = true;


                        this.PRODUCTOIDTextBox.Enabled = false;
                        this.PRODUCTOIDButton.Enabled = false;
                        this.PRODUCTOIDLabel.Enabled = false;
                        this.PRODUCTOIDTextBox.Text = "";
                        this.PRODUCTOIDLabel.Text = "";

                        break;

                    }

                default:
                    {
                        this.PRODUCTOIDTextBox.Enabled = true;
                        this.PRODUCTOIDButton.Enabled = true;
                        this.PRODUCTOIDLabel.Enabled = true;

                        this.pnlPromocionXMontoMin.Enabled = false;
                        this.pnlBodegazo.Enabled = false;


                        this.LINEAIDTextBox.Enabled = false;
                        this.LINEAIDButton.Enabled = false;
                        this.LINEAIDLabel.Enabled = false;
                        this.LINEAIDTextBox.Text = "";
                        this.LINEAIDLabel.Text = "";



                        break;

                    }
            }
        }

        private void SetHabilitacionesRangoXSeleccion()
        {

            if (RBRANGOPRODUCTO.Checked)
                SetHabilitacionesPorRango(DBValues._RANGOPROMOCIONXPRODUCTO);
            else if (RBRANGOLINEA.Checked)
                SetHabilitacionesPorRango(DBValues._RANGOPROMOCIONXLINEA);
            else if (RBRANGOBODEGAZO.Checked)
                SetHabilitacionesPorRango(DBValues._RANGOPROMOCIONXBODEGAZO);
            else
            {
                SetHabilitacionesPorRango(DBValues._RANGOPROMOCIONXPRODUCTO);
            }
        }

        private void RBRANGOPRODUCTO_CheckedChanged(object sender, EventArgs e)
        {
            SetHabilitacionesRangoXSeleccion();

            AjustarDecimalesCantidad(null);
        }

        private void RBRANGOLINEA_CheckedChanged(object sender, EventArgs e)
        {
            SetHabilitacionesRangoXSeleccion();
            AjustarDecimalesCantidad(null);
        }


        private void SetHabilitacionesTipoXSeleccion()
        {
            if (RBTIPOPROMOCION1.Checked)
                SetHabilitacionesPorTipo(DBValues._TIPOPROMOCIONCOMPRASXLLEVASMAS);
            else if (RBTIPOPROMOCION2.Checked)
                SetHabilitacionesPorTipo(DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTE);
            else if (RBTIPOPROMOCION3.Checked)
                SetHabilitacionesPorTipo(DBValues._TIPOPROMOCIONDESCUENTOPORCENTAJE);
            else if (RBTIPOPROMOCION6.Checked)
                SetHabilitacionesPorTipo(DBValues._TIPOPROMOCIONCOMPRASXCONIMPORTEMANTEN);
            else
                SetHabilitacionesPorTipo(DBValues._TIPOPROMOCIONCOMPRASXLLEVASMAS);
        }

        private void RBTIPOPROMOCION1_CheckedChanged(object sender, EventArgs e)
        {
            SetHabilitacionesTipoXSeleccion();
        }

        private void RBTIPOPROMOCION2_CheckedChanged(object sender, EventArgs e)
        {
            SetHabilitacionesTipoXSeleccion();
        }

        private void RBTIPOPROMOCION3_CheckedChanged(object sender, EventArgs e)
        {
            SetHabilitacionesTipoXSeleccion();
        }

        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {

            CPRODUCTOBE prod = new CPRODUCTOBE();

            if (!BuscarProducto(ref prod))
            {
                PRODUCTOIDLabel.Text = "";
                SeleccionarProducto(PRODUCTOIDTextBox.Text.Trim());
                productID = 0;
                return;
            }

            PRODUCTOIDLabel.Text = prod.INOMBRE;
            productID = prod.IID;

            AjustarDecimalesCantidad(prod);
        }



        

        private void AjustarDecimalesCantidad(CPRODUCTOBE prod)
        {
            if (RBRANGOPRODUCTO.Checked && this.productID > 0)
            {
                if (prod == null)
                {
                    CPRODUCTOD prodD = new CPRODUCTOD();
                    prod = new CPRODUCTOBE();
                    prod.IID = this.productID;

                    prod = prodD.seleccionarPRODUCTO(prod, null);
                }


                short numeroDecimales = 2;
                if(prod != null)
                {
                    numeroDecimales = CUNIDADD.numerDecimalesPorClaveUnidad(prod.IUNIDAD);
                }
                CANTIDAD2TextBox.NumericScaleOnFocus = numeroDecimales;
                CANTIDAD2TextBox.NumericScaleOnLostFocus = numeroDecimales;
                CANTIDAD6TextBox.NumericScaleOnFocus = numeroDecimales;
                CANTIDAD6TextBox.NumericScaleOnLostFocus = numeroDecimales;
               

/*
                if (prod == null || (prod.IUNIDAD != "PZA" && prod.IUNIDAD != "KG"))
                {

                    CANTIDAD2TextBox.NumericScaleOnFocus = 2;
                    CANTIDAD2TextBox.NumericScaleOnLostFocus = 2;
                    CANTIDAD6TextBox.NumericScaleOnFocus = 2;
                    CANTIDAD6TextBox.NumericScaleOnLostFocus = 2;
                    return;
                }
                else if (prod.IUNIDAD == "PZA")
                {

                    CANTIDAD2TextBox.NumericScaleOnFocus = 0;
                    CANTIDAD2TextBox.NumericScaleOnLostFocus = 0;
                    CANTIDAD6TextBox.NumericScaleOnFocus = 0;
                    CANTIDAD6TextBox.NumericScaleOnLostFocus = 0;
                    return;
                }
                else if (prod.IUNIDAD == "KG")
                {

                    CANTIDAD2TextBox.NumericScaleOnFocus = 3;
                    CANTIDAD2TextBox.NumericScaleOnLostFocus = 3;
                    CANTIDAD6TextBox.NumericScaleOnFocus = 3;
                    CANTIDAD6TextBox.NumericScaleOnLostFocus = 3;
                    return;
                }
                else
                {

                    CANTIDAD2TextBox.NumericScaleOnFocus = 2;
                    CANTIDAD2TextBox.NumericScaleOnLostFocus = 2;
                    CANTIDAD6TextBox.NumericScaleOnFocus = 2;
                    CANTIDAD6TextBox.NumericScaleOnLostFocus = 2;
                    return;
                }
*/

            }
            else
            {

                CANTIDAD2TextBox.NumericScaleOnFocus = 2;
                CANTIDAD2TextBox.NumericScaleOnLostFocus = 2;
                CANTIDAD6TextBox.NumericScaleOnFocus = 2;
                CANTIDAD6TextBox.NumericScaleOnLostFocus = 2;
            }
        }


        private bool BuscarProducto(ref CPRODUCTOBE prod)
        {
            CPRODUCTOD prodD = new CPRODUCTOD();
            try
            {
                prod.IID = Int32.Parse(PRODUCTOIDTextBox.Text);
            }
            catch
            {
                return false;
            }
            prod = prodD.seleccionarPRODUCTO(prod, null);
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
                this.PRODUCTOIDTextBox.Text = dr["ID"].ToString().Trim();
                PRODUCTOIDTextBox.Focus();
                PRODUCTOIDTextBox.Select(PRODUCTOIDTextBox.Text.Length, 0);
            }
        }

        private void PRODUCTOIDButton_Click(object sender, EventArgs e)
        {

            SeleccionarProducto(PRODUCTOIDTextBox.Text.Trim());
        }

        private void RBRANGOBODEGAZO_CheckedChanged(object sender, EventArgs e)
        {

            SetHabilitacionesRangoXSeleccion();
            RBTIPOPROMOCION7.Checked = true;
            AjustarDecimalesCantidad(null);
        }

        private void flatTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (flatTabControl1.SelectedIndex == 1)
            //{
            //    CargarSucursales();
            //}
        }


        private void CargarSucursales()
        {


            CSUCURSALD sucursalDao = new CSUCURSALD();

            CSUCURSALBE[] sucursales = sucursalDao.seleccionarSUCURSALES();

            if (sucursales != null && sucursales.Length > 0)
            {
                sUCURSALTableAdapter.Fill(dSCatalogos.SUCURSAL);
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void IMPORTETextBox_NumericValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnImageSelector_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Imagenes";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
        "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                NuevaImagenTextBox.Text = openFileDialog1.FileName;

                try
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

                    if (pictureBox1.Image != null)
                    {
                        m_bChangeImage = true;
                        this.m_imageExtension = Path.GetExtension(openFileDialog1.FileName);
                    }
                }
                catch
                {
                }

            }
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {

            m_bChangeImage = true;
            pictureBox1.Image = null;
        }
    }
}
