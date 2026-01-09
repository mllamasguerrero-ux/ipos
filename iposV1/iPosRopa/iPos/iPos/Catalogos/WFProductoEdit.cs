
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

using FirebirdSql.Data.FirebirdClient;
using iPos.Catalogos;

using System.Linq;


namespace iPos
{
    public partial class WFProductoEdit : IposForm
    {
        public bool loteIsAble = false;
        public string opc;
        System.Collections.ArrayList validadores;


        long ID;
        string CLAVE;


        public string m_subProduct_opc;
        public long m_subProduct_Id;

        public CPRODUCTOBE m_producto = null;


        public delegate void AccionHandler(object source, Hashtable evtArgs);
        //public event AccionHandler AccionUsuario;

        bool m_bChangeImage = false;
        string m_imageExtension = "";


        bool m_bChangeImage_SUB = false;
        string m_imageExtension_SUB = "";

        private CPRODUCTOBE m_productoParte = null;

        string strManejaLoteAnterior = "";

        bool m_bChangedSucursales = false;
        bool m_sucursalesCargadas = false;

        bool m_bChangedProveedores = false;


        public WFProductoEdit()
        {
            InitializeComponent();
            Marquesina.Enabled = true;
        }


        public void ReCargar(string popc, string pCLAVE)
        {
            opc = popc;
            CLAVE = pCLAVE;

            validadores = new System.Collections.ArrayList();
            validadores.Add((RFV_CLAVE));
            validadores.Add((RFV_LINEA));
            validadores.Add((RFV_MARCA));
            validadores.Add((RFV_PROVEEDOR1));
            validadores.Add((RFV_PROVEEDOR2));
            validadores.Add((RFV_TASAIVA));
            validadores.Add((RVF_MONEDA));
            validadores.Add((RFV_DESCRIPCION1));
            validadores.Add((RFV_NOMBRE));


            UNIDADTextBox.llenarDatos();
            UNIDAD2TextBox.llenarDatos();
            CONTENIDOIDTextBox.llenarDatos();
            CONTENIDOIDTextBox.SelectedIndex = -1;

            this.button1.Text = opc;
            if (this.opc != "Agregar" && this.opc != "")
            {
                if (this.opc == "Consultar")
                {
                    this.button1.Visible = false;
                    this.BTCancelar.Text = "Salir";
                    this.BTCancelar.Image = global::iPos.Properties.Resources.Exit;
                }
                else
                {
                    HabilitarEdicion(true);
                    this.BTIniciaEdicion.Enabled = false;

                }
                LlenarDatosDeBase();
                HabilitarCamposInventariables(true);
                this.CLAVETextBox.Enabled = false;



            }
            else if (this.opc == "Agregar")
            {
                HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false;
                UNIDADTextBox.SelectedIndex = 0;
                UNIDAD2TextBox.Text = "CAJA";
                CONTENIDOIDTextBox.SelectedIndex = -1;

                PutDefaultValues();
            }

            showHideTabPages();
            habilitarCamposPorKit();
        }



        private void SetCostosVisibility()
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();

            // mostrar ocultar costos
            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_MOSTRARCOSTOS, null))
            {
                this.pnlCostos.Visible = true;
            }
            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_EDITARCOSTOREPO, null))
            {
                this.COSTOREPOSICIONTextBox.Enabled = true;
                this.COSTOREPOSICIONTextBox.ReadOnly = false;
            }
            else
            {
                this.COSTOREPOSICIONTextBox.Enabled = false;
                this.COSTOREPOSICIONTextBox.ReadOnly = true;
            }
        }

        private void SetPreciosVisibility()
        {

            this.PRECIO1TextBox.Visible = false;
            this.PRECIO2TextBox.Visible = false;
            this.PRECIO3TextBox.Visible = false;
            this.PRECIO4TextBox.Visible = false;
            this.PRECIO5TextBox.Visible = false;
            this.PRECIO6TextBox.Visible = false;


            this.pRECIO1Label.Visible = false;
            this.pRECIO2Label.Visible = false;
            this.pRECIO3Label.Visible = false;
            this.pRECIO4Label.Visible = false;
            this.pRECIO5Label.Visible = false;
            this.pRECIO6Label.Visible = false;




            this.SPRECIO1TextBox.Visible = false;
            this.SPRECIO2TextBox.Visible = false;
            this.SPRECIO3TextBox.Visible = false;
            this.SPRECIO4TextBox.Visible = false;
            this.SPRECIO5TextBox.Visible = false;

            this.spRECIO1Label.Visible = false;
            this.spRECIO2Label.Visible = false;
            this.spRECIO3Label.Visible = false;
            this.spRECIO4Label.Visible = false;
            this.spRECIO5Label.Visible = false;


            if (!(bool)CurrentUserID.CurrentUser.isnull["ILISTAPRECIOID"])
            {

                if (CurrentUserID.CurrentUser.ILISTAPRECIOID >= 1)
                {
                    this.PRECIO1TextBox.Visible = true;
                    this.pRECIO1Label.Visible = true;
                    this.SPRECIO1TextBox.Visible = true;
                    this.spRECIO1Label.Visible = true;
                }

                if (CurrentUserID.CurrentUser.ILISTAPRECIOID >= 2)
                {
                    this.PRECIO2TextBox.Visible = true;
                    this.pRECIO2Label.Visible = true;
                    this.SPRECIO2TextBox.Visible = true;
                    this.spRECIO2Label.Visible = true;
                }

                if (CurrentUserID.CurrentUser.ILISTAPRECIOID >= 3)
                {
                    this.PRECIO3TextBox.Visible = true;
                    this.pRECIO3Label.Visible = true;
                    this.SPRECIO2TextBox.Visible = true;
                    this.spRECIO3Label.Visible = true;
                }

                if (CurrentUserID.CurrentUser.ILISTAPRECIOID >= 4)
                {
                    this.PRECIO4TextBox.Visible = true;
                    this.pRECIO4Label.Visible = true;
                    this.SPRECIO4TextBox.Visible = true;
                    this.spRECIO4Label.Visible = true;
                }

                if (CurrentUserID.CurrentUser.ILISTAPRECIOID >= 5)
                {
                    this.PRECIO5TextBox.Visible = true;
                    this.pRECIO5Label.Visible = true;
                    this.SPRECIO5TextBox.Visible = true;
                    this.spRECIO5Label.Visible = true;
                }
            }
            else
            {
                this.PRECIO1TextBox.Visible = true;
                this.PRECIO2TextBox.Visible = true;
                this.PRECIO3TextBox.Visible = true;
                this.PRECIO4TextBox.Visible = true;
                this.PRECIO5TextBox.Visible = true;

                this.pRECIO1Label.Visible = true;
                this.pRECIO2Label.Visible = true;
                this.pRECIO3Label.Visible = true;
                this.pRECIO4Label.Visible = true;
                this.pRECIO5Label.Visible = true;


                this.SPRECIO1TextBox.Visible = true;
                this.SPRECIO2TextBox.Visible = true;
                this.SPRECIO3TextBox.Visible = true;
                this.SPRECIO4TextBox.Visible = true;
                this.SPRECIO5TextBox.Visible = true;

                this.spRECIO1Label.Visible = true;
                this.spRECIO2Label.Visible = true;
                this.spRECIO3Label.Visible = true;
                this.spRECIO4Label.Visible = true;
                this.spRECIO5Label.Visible = true;

            }

        }





        private void SiEmpresaDesglosaIeps()
        {
            if (CurrentUserID.CurrentParameters.IDESGLOSEIEPS != null && CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S"))
            {
                lblClasifica.Visible = true;
                CLASIFICAIDTextBox.Visible = true;
                CLASIFICAButton.Visible = true;
                CLASIFICALabelButton.Visible = true;
                label46.Visible = true;
                CONTENIDOIDTextBox.Visible = true;
                CONTENIDOVALORTextBox.Visible = true;
            }
            else
            {
                lblClasifica.Visible = false;
                CLASIFICAIDTextBox.Visible = false;
                CLASIFICAButton.Visible = false;
                CLASIFICALabelButton.Visible = false;
                label46.Visible = false;
                CONTENIDOIDTextBox.Visible = false;
                CONTENIDOVALORTextBox.Visible = false;
            }
        }

        private void PRODUCTOEdit_Reg_Load(object sender, EventArgs e)
        {
            if (!m_sucursalesCargadas)
            {
                this.sUCURSALTableAdapter.Fill(this.dSCatalogos.SUCURSAL);
                m_sucursalesCargadas = true;
            }

            SiEmpresaDesglosaIeps();

            SetCostosVisibility();
            //SetPreciosVisibility();

            FormatearCamposPersonalizados();

            //valores por default

            TASAIEPSTextBox.Visible = CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S");
            lblTasaIEPS.Visible = CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S");

            CUENTAPREDIALTextBox.Visible = CurrentUserID.CurrentParameters.IARRENDATARIO.Equals("S");
            lblCuentaPredial.Visible = CurrentUserID.CurrentParameters.IARRENDATARIO.Equals("S");
            pnlSuperListaPrecio.Visible = CurrentUserID.CurrentParameters.IMANEJASUPERLISTAPRECIO.Equals("S");
            pnlPorcUtilListaPrecio.Visible = CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS.Equals("S");


            if (CurrentUserID.CurrentParameters.IMANEJARECETA != null && CurrentUserID.CurrentParameters.IMANEJARECETA.Equals("S"))
            {
                lblRequiereReceta.Visible = true;
                REQUIERERECETATextBox.Visible = true;
            }
            else
            {
                lblRequiereReceta.Visible = false;
                REQUIERERECETATextBox.Visible = false;
            }



            if (CurrentUserID.CurrentParameters.IMANEJARLOTEIMPORTACION != null && CurrentUserID.CurrentParameters.IMANEJARLOTEIMPORTACION.Equals("S"))
            {
                MANEJALOTEIMPORTADOLabel.Visible = true;
                MANEJALOTEIMPORTADOTextBox.Visible = true;
            }
            else
            {
                MANEJALOTEIMPORTADOLabel.Visible = false;
                MANEJALOTEIMPORTADOTextBox.Visible = false;
            }


            if (CurrentUserID.CurrentParameters.IPLAZOXPRODUCTO == "S")
            {
                this.panelPlazo.Visible = true;
            }
            else
            {
                this.panelPlazo.Visible = false;
            }


            CUSUARIOSD usuariosD = new CUSUARIOSD();
            Boolean usuarioTienePermisoHistorial = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_BITACORA_PRODUCTO, null);
            this.btnHistory.Visible = usuarioTienePermisoHistorial;


        }

        private void PutDefaultValues()
        {

            string strBuffer = "";

            this.MONEDAIDTextBox.DbValue = "1";
            this.MONEDAIDTextBox.MostrarErrores = false;
            this.MONEDAIDTextBox.MValidarEntrada(out strBuffer, 1);
            this.MONEDAIDTextBox.MostrarErrores = true;

            if (!(bool)CurrentUserID.CurrentParameters.isnull["IDEFAULTTASAIVAID"])
            {

                this.TASAIVAIDTextBox.DbValue = CurrentUserID.CurrentParameters.IDEFAULTTASAIVAID.ToString();
                this.TASAIVAIDTextBox.MostrarErrores = false;
                this.TASAIVAIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.TASAIVAIDTextBox.MostrarErrores = true;
            }
            IMPRIMIRTextBox.Checked = true;
            INVENTARIABLETextBox.Checked = true;
            IMPRIMIRCOMANDATextBox.Checked = false;

        }

        private void FormatearCamposPersonalizados()
        {
            try
            {
                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] && CurrentUserID.CurrentParameters.ITEXTO1 != "")
                {
                    this.TEXTO1Label.Text = CurrentUserID.CurrentParameters.ITEXTO1;
                    this.SUB_TEXTO1Label.Text = CurrentUserID.CurrentParameters.ITEXTO1;
                    pRODUCTOSHIJODataGridView.Columns["DGTEXTO1"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO1;
                }
                else
                {
                    this.TEXTO1Label.Visible = false;
                    this.TEXTO1TextBox.Visible = false;
                    this.SUB_TEXTO1Label.Visible = false;
                    this.SUB_TEXTO1TextBox.Visible = false;
                    pRODUCTOSHIJODataGridView.Columns["DGTEXTO1"].Visible = false;
                }



                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO2"] && CurrentUserID.CurrentParameters.ITEXTO2 != "")
                {
                    this.TEXTO2Label.Text = CurrentUserID.CurrentParameters.ITEXTO2;
                    this.SUB_TEXTO2Label.Text = CurrentUserID.CurrentParameters.ITEXTO2;
                    pRODUCTOSHIJODataGridView.Columns["DGTEXTO2"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO2;
                }
                else
                {
                    this.TEXTO2Label.Visible = false;
                    this.TEXTO2TextBox.Visible = false;
                    this.SUB_TEXTO2Label.Visible = false;
                    this.SUB_TEXTO2TextBox.Visible = false;
                    pRODUCTOSHIJODataGridView.Columns["DGTEXTO2"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO3"] && CurrentUserID.CurrentParameters.ITEXTO3 != "")
                {
                    this.TEXTO3Label.Text = CurrentUserID.CurrentParameters.ITEXTO3;
                    this.SUB_TEXTO3Label.Text = CurrentUserID.CurrentParameters.ITEXTO3;
                    pRODUCTOSHIJODataGridView.Columns["DGTEXTO3"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO3;
                }
                else
                {
                    this.TEXTO3Label.Visible = false;
                    this.TEXTO3TextBox.Visible = false;
                    this.SUB_TEXTO3Label.Visible = false;
                    this.SUB_TEXTO3TextBox.Visible = false;
                    pRODUCTOSHIJODataGridView.Columns["DGTEXTO3"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO4"] && CurrentUserID.CurrentParameters.ITEXTO4 != "")
                {
                    this.TEXTO4Label.Text = CurrentUserID.CurrentParameters.ITEXTO4;
                    this.SUB_TEXTO4Label.Text = CurrentUserID.CurrentParameters.ITEXTO4;
                    pRODUCTOSHIJODataGridView.Columns["DGTEXTO4"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO4;
                }
                else
                {
                    this.TEXTO4Label.Visible = false;
                    this.TEXTO4TextBox.Visible = false;
                    this.SUB_TEXTO4Label.Visible = false;
                    this.SUB_TEXTO4TextBox.Visible = false;
                    pRODUCTOSHIJODataGridView.Columns["DGTEXTO4"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO5"] && CurrentUserID.CurrentParameters.ITEXTO5 != "")
                {
                    this.TEXTO5Label.Text = CurrentUserID.CurrentParameters.ITEXTO5;
                    this.SUB_TEXTO5Label.Text = CurrentUserID.CurrentParameters.ITEXTO5;
                    pRODUCTOSHIJODataGridView.Columns["DGTEXTO5"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO5;
                }
                else
                {
                    this.TEXTO5Label.Visible = false;
                    this.TEXTO5TextBox.Visible = false;
                    this.SUB_TEXTO5Label.Visible = false;
                    this.SUB_TEXTO5TextBox.Visible = false;
                    pRODUCTOSHIJODataGridView.Columns["DGTEXTO5"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO6"] && CurrentUserID.CurrentParameters.ITEXTO6 != "")
                {
                    this.TEXTO6Label.Text = CurrentUserID.CurrentParameters.ITEXTO6;
                    this.SUB_TEXTO6Label.Text = CurrentUserID.CurrentParameters.ITEXTO6;
                    pRODUCTOSHIJODataGridView.Columns["DGTEXTO6"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO6;
                }
                else
                {
                    this.TEXTO6Label.Visible = false;
                    this.TEXTO6TextBox.Visible = false;
                    this.SUB_TEXTO6Label.Visible = false;
                    this.SUB_TEXTO6TextBox.Visible = false;
                    pRODUCTOSHIJODataGridView.Columns["DGTEXTO6"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO1"] && CurrentUserID.CurrentParameters.INUMERO1 != "")
                {
                    this.NUMERO1Label.Text = CurrentUserID.CurrentParameters.INUMERO1;
                    this.SUB_NUMERO1Label.Text = CurrentUserID.CurrentParameters.INUMERO1;
                    pRODUCTOSHIJODataGridView.Columns["DGNUMERO1"].HeaderText = CurrentUserID.CurrentParameters.INUMERO1;
                }
                else
                {
                    this.NUMERO1Label.Visible = false;
                    this.NUMERO1TextBox.Visible = false;
                    this.SUB_NUMERO1Label.Visible = false;
                    this.SUB_NUMERO1TextBox.Visible = false;
                    pRODUCTOSHIJODataGridView.Columns["DGNUMERO1"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO2"] && CurrentUserID.CurrentParameters.INUMERO2 != "")
                {
                    this.NUMERO2Label.Text = CurrentUserID.CurrentParameters.INUMERO2;
                    this.SUB_NUMERO2Label.Text = CurrentUserID.CurrentParameters.INUMERO2;
                    pRODUCTOSHIJODataGridView.Columns["DGNUMERO2"].HeaderText = CurrentUserID.CurrentParameters.INUMERO2;
                }
                else
                {
                    this.NUMERO2Label.Visible = false;
                    this.NUMERO2TextBox.Visible = false;
                    this.SUB_NUMERO2Label.Visible = false;
                    this.SUB_NUMERO2TextBox.Visible = false;
                    pRODUCTOSHIJODataGridView.Columns["DGNUMERO2"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO3"] && CurrentUserID.CurrentParameters.INUMERO3 != "")
                {
                    this.NUMERO3Label.Text = CurrentUserID.CurrentParameters.INUMERO3;
                    this.SUB_NUMERO3Label.Text = CurrentUserID.CurrentParameters.INUMERO3;
                    pRODUCTOSHIJODataGridView.Columns["DGNUMERO3"].HeaderText = CurrentUserID.CurrentParameters.INUMERO3;
                }
                else
                {
                    this.NUMERO3Label.Visible = false;
                    this.NUMERO3TextBox.Visible = false;
                    this.SUB_NUMERO3Label.Visible = false;
                    this.SUB_NUMERO3TextBox.Visible = false;
                    pRODUCTOSHIJODataGridView.Columns["DGNUMERO3"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO4"] && CurrentUserID.CurrentParameters.INUMERO4 != "")
                {
                    this.NUMERO4Label.Text = CurrentUserID.CurrentParameters.INUMERO4;
                    this.SUB_NUMERO4Label.Text = CurrentUserID.CurrentParameters.INUMERO4;
                    pRODUCTOSHIJODataGridView.Columns["DGNUMERO4"].HeaderText = CurrentUserID.CurrentParameters.INUMERO4;
                }
                else
                {
                    this.NUMERO4Label.Visible = false;
                    this.NUMERO4TextBox.Visible = false;
                    this.SUB_NUMERO4Label.Visible = false;
                    this.SUB_NUMERO4TextBox.Visible = false;
                    pRODUCTOSHIJODataGridView.Columns["DGNUMERO4"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA1"] && CurrentUserID.CurrentParameters.IFECHA1 != "")
                {
                    this.FECHA1Label.Text = CurrentUserID.CurrentParameters.IFECHA1;
                    this.SUB_FECHA1Label.Text = CurrentUserID.CurrentParameters.IFECHA1;
                    pRODUCTOSHIJODataGridView.Columns["DGFECHA1"].HeaderText = CurrentUserID.CurrentParameters.IFECHA1;
                }
                else
                {
                    this.FECHA1Label.Visible = false;
                    this.FECHA1TextBox.Visible = false;
                    this.SUB_FECHA1Label.Visible = false;
                    this.SUB_FECHA1TextBox.Visible = false;
                    pRODUCTOSHIJODataGridView.Columns["DGFECHA1"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA2"] && CurrentUserID.CurrentParameters.IFECHA2 != "")
                {
                    this.FECHA2Label.Text = CurrentUserID.CurrentParameters.IFECHA2;
                    this.SUB_FECHA2Label.Text = CurrentUserID.CurrentParameters.IFECHA2;
                    pRODUCTOSHIJODataGridView.Columns["DGFECHA2"].HeaderText = CurrentUserID.CurrentParameters.IFECHA2;
                }
                else
                {
                    this.FECHA2Label.Visible = false;
                    this.FECHA2TextBox.Visible = false;
                    this.SUB_FECHA2Label.Visible = false;
                    this.SUB_FECHA2TextBox.Visible = false;
                    pRODUCTOSHIJODataGridView.Columns["DGFECHA2"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private bool LlenarDatosDeBase()
        {
            string strBuffer = "";
            m_bChangeImage = false;
            try
            {

                CPRODUCTOD productoD = new CPRODUCTOD();
                CPRODUCTOBE productoBE = new CPRODUCTOBE();



                productoBE.ICLAVE = CLAVE;
                productoBE = productoD.seleccionarPRODUCTOxCLAVE(productoBE, null);

                this.m_producto = productoBE;

                if (productoBE == null)
                    return false;


                if (productoBE.IESKIT != null && productoBE.IESKIT.Equals("S"))
                {
                    LlenarKitInfo();
                    putCalculatedValuesFromKit(false);
                }

                this.ID = productoBE.IID;

                if (!(bool)productoBE.isnull["IACTIVO"])
                    this.ACTIVOTextBox.Checked = (productoBE.IACTIVO == "S") ? true : false;

                //this.CREADOPOR_USERIDTextBox.Text = productoBE.ICREADOPOR_USERID.ToString();

                //this.MODIFICADOPOR_USERIDTextBox.Text = productoBE.IMODIFICADOPOR_USERID.ToString();


                try
                {
                    this.CREADOTextBox.Value = productoBE.ICREADO;
                }
                catch
                {
                }


                try
                {
                    this.MODIFICADOTextBox.Value = productoBE.IMODIFICADO;
                }
                catch
                {
                }


                if (!(bool)productoBE.isnull["ICLAVE"])
                    this.CLAVETextBox.Text = productoBE.ICLAVE.ToString();


                if (!(bool)productoBE.isnull["INOMBRE"])
                    this.NOMBRETextBox.Text = productoBE.INOMBRE.ToString();


                if (!(bool)productoBE.isnull["IDESCRIPCION"])
                    this.DESCRIPCIONTextBox.Text = productoBE.IDESCRIPCION.ToString();


                if (!(bool)productoBE.isnull["IEAN"])
                    this.EANTextBox.Text = productoBE.IEAN.ToString();


                if (!(bool)productoBE.isnull["IDESCRIPCION1"])
                    this.DESCRIPCION1TextBox.Text = productoBE.IDESCRIPCION1.ToString();


                if (!(bool)productoBE.isnull["IDESCRIPCION2"])
                    this.DESCRIPCION2TextBox.Text = productoBE.IDESCRIPCION2.ToString();


                if (!(bool)productoBE.isnull["IDESCRIPCION3"])
                    this.DESCRIPCION3TextBox.Text = productoBE.IDESCRIPCION3.ToString();


                if (!(bool)productoBE.isnull["IPROVEEDOR1ID"])
                {
                    this.PROVEEDOR1IDTextBox.DbValue = productoBE.IPROVEEDOR1ID.ToString();
                    this.PROVEEDOR1IDTextBox.MostrarErrores = false;
                    this.PROVEEDOR1IDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.PROVEEDOR1IDTextBox.MostrarErrores = true;
                }


                if (!(bool)productoBE.isnull["IPROVEEDOR2ID"])
                {


                    this.PROVEEDOR2IDTextBox.DbValue = productoBE.IPROVEEDOR2ID.ToString();
                    this.PROVEEDOR2IDTextBox.MostrarErrores = false;
                    this.PROVEEDOR2IDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.PROVEEDOR2IDTextBox.MostrarErrores = true;
                }


                if (!(bool)productoBE.isnull["ILINEAID"])
                {
                    this.LINEAIDTextBox.DbValue = productoBE.ILINEAID.ToString();
                    this.LINEAIDTextBox.MostrarErrores = false;
                    this.LINEAIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.LINEAIDTextBox.MostrarErrores = true;
                }


                if (!(bool)productoBE.isnull["IMARCAID"])
                {
                    this.MARCAIDTextBox.DbValue = productoBE.IMARCAID.ToString();
                    this.MARCAIDTextBox.MostrarErrores = false;
                    this.MARCAIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.MARCAIDTextBox.MostrarErrores = true;
                }



                if (!(bool)productoBE.isnull["IPRECIO1"])
                    this.PRECIO1TextBox.Text = productoBE.IPRECIO1.ToString();


                if (!(bool)productoBE.isnull["IPRECIO2"])
                    this.PRECIO2TextBox.Text = productoBE.IPRECIO2.ToString();


                if (!(bool)productoBE.isnull["IPRECIO3"])
                    this.PRECIO3TextBox.Text = productoBE.IPRECIO3.ToString();


                if (!(bool)productoBE.isnull["IPRECIO4"])
                    this.PRECIO4TextBox.Text = productoBE.IPRECIO4.ToString();


                if (!(bool)productoBE.isnull["IPRECIO5"])
                    this.PRECIO5TextBox.Text = productoBE.IPRECIO5.ToString();



                if (!(bool)productoBE.isnull["IPRECIO6"])
                    this.PRECIO6TextBox.Text = productoBE.IPRECIO6.ToString();

                if (!(bool)productoBE.isnull["IPRECIOSUGERIDO"])
                    this.PRECIOSUGERIDOTextBox.Text = productoBE.IPRECIOSUGERIDO.ToString();

                if (!(bool)productoBE.isnull["ITASAIVAID"])
                {
                    this.TASAIVAIDTextBox.DbValue = productoBE.ITASAIVAID.ToString();
                    this.TASAIVAIDTextBox.MostrarErrores = false;
                    this.TASAIVAIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.TASAIVAIDTextBox.MostrarErrores = true;
                }


                if (!(bool)productoBE.isnull["ITASAIVA"])
                    this.TASAIVATextBox.Text = productoBE.ITASAIVA.ToString();

                if (!(bool)productoBE.isnull["IMONEDAID"] && productoBE.IMONEDAID != 0)
                {
                    this.MONEDAIDTextBox.DbValue = productoBE.IMONEDAID.ToString();
                    this.MONEDAIDTextBox.MostrarErrores = false;
                    this.MONEDAIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.MONEDAIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.MONEDAIDTextBox.DbValue = "1";
                    this.MONEDAIDTextBox.MostrarErrores = false;
                    this.MONEDAIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.MONEDAIDTextBox.MostrarErrores = true;
                }


                if (!(bool)productoBE.isnull["ICOSTOREPOSICION"])
                    this.COSTOREPOSICIONTextBox.Text = productoBE.ICOSTOREPOSICION.ToString("N2");


                if (!(bool)productoBE.isnull["ICOSTOULTIMO"])
                    this.COSTOULTIMOTextBox.Text = productoBE.ICOSTOULTIMO.ToString("N2");


                if (!(bool)productoBE.isnull["ICOSTOPROMEDIO"])
                    this.COSTOPROMEDIOTextBox.Text = productoBE.ICOSTOPROMEDIO.ToString("N2");

                if (!(bool)productoBE.isnull["IPRODUCTOSUSTITUTOID"])
                {
                    this.PRODUCTOSUSTITUTOIDTextBox.DbValue = productoBE.IPRODUCTOSUSTITUTOID.ToString();
                    this.PRODUCTOSUSTITUTOIDTextBox.MostrarErrores = false;
                    this.PRODUCTOSUSTITUTOIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.PRODUCTOSUSTITUTOIDTextBox.MostrarErrores = true;
                }


                if (!(bool)productoBE.isnull["IMANEJALOTE"])
                {
                    strManejaLoteAnterior = productoBE.IMANEJALOTE;
                    this.MANEJALOTETextBox.Checked = (productoBE.IMANEJALOTE == "S") ? true : false;
                }


                if (!(bool)productoBE.isnull["IESKIT"])
                    this.ESKITTextBox.Checked = (productoBE.IESKIT == "S") ? true : false;


                if (!(bool)productoBE.isnull["IIMPRIMIR"])
                    this.IMPRIMIRTextBox.Checked = (productoBE.IIMPRIMIR == "S") ? true : false;


                if (!(bool)productoBE.isnull["IINVENTARIABLE"])
                    this.INVENTARIABLETextBox.Checked = (productoBE.IINVENTARIABLE == "S") ? true : false;


                if (!(bool)productoBE.isnull["INEGATIVOS"])
                    this.NEGATIVOSTextBox.Checked = (productoBE.INEGATIVOS == "S") ? true : false;


                if (!(bool)productoBE.isnull["ILIMITEPRECIO2"])
                    this.LIMITEPRECIO2TextBox.Text = productoBE.ILIMITEPRECIO2.ToString();


                if (!(bool)productoBE.isnull["IPRECIOMAXIMOPUBLICO"])
                    this.PRECIOMAXIMOPUBLICOTextBox.Text = productoBE.IPRECIOMAXIMOPUBLICO.ToString();

                try
                {
                    this.FECHACAMBIOPRECIOTextBox.Value = productoBE.IFECHACAMBIOPRECIO;
                }
                catch
                {
                }




                if (!(bool)productoBE.isnull["IMANEJASTOCK"])
                    this.MANEJASTOCKTextBox.Checked = (productoBE.IMANEJASTOCK == "S") ? true : false;

                if (!(bool)productoBE.isnull["ISTOCK"])
                    this.STOCKTextBox.Text = productoBE.ISTOCK.ToString();


                if (!(bool)productoBE.isnull["ISTOCKMAX"])
                    this.STOCKMAXTextBox.Text = productoBE.ISTOCKMAX.ToString();

                if (!(bool)productoBE.isnull["ISURTIRPORCAJA"])
                    this.SURTIRPORCAJATextBox.Checked = (productoBE.ISURTIRPORCAJA == "S") ? true : false;


                if (!(bool)productoBE.isnull["ICAMBIARPRECIO"])
                    this.CAMBIARPRECIOTextBox.Checked = (productoBE.ICAMBIARPRECIO == "S") ? true : false;




                if (!(bool)productoBE.isnull["ICOMISION"])
                    this.COMISIONTextBox.Text = productoBE.ICOMISION.ToString();


                if (!(bool)productoBE.isnull["IOFERTA"])
                    this.OFERTATextBox.Text = productoBE.IOFERTA.ToString();


                if (!(bool)productoBE.isnull["ITEXTO1"])
                    this.TEXTO1TextBox.Text = productoBE.ITEXTO1.ToString();

                if (!(bool)productoBE.isnull["ITEXTO2"])
                    this.TEXTO2TextBox.Text = productoBE.ITEXTO2.ToString();

                if (!(bool)productoBE.isnull["ITEXTO3"])
                    this.TEXTO3TextBox.Text = productoBE.ITEXTO3.ToString();

                if (!(bool)productoBE.isnull["ITEXTO4"])
                    this.TEXTO4TextBox.Text = productoBE.ITEXTO4.ToString();

                if (!(bool)productoBE.isnull["ITEXTO5"])
                    this.TEXTO5TextBox.Text = productoBE.ITEXTO5.ToString();

                if (!(bool)productoBE.isnull["ITEXTO6"])
                    this.TEXTO6TextBox.Text = productoBE.ITEXTO6.ToString();


                if (!(bool)productoBE.isnull["INUMERO1"])
                    this.NUMERO1TextBox.Text = productoBE.INUMERO1.ToString();

                if (!(bool)productoBE.isnull["INUMERO2"])
                    this.NUMERO2TextBox.Text = productoBE.INUMERO2.ToString();

                if (!(bool)productoBE.isnull["INUMERO3"])
                    this.NUMERO3TextBox.Text = productoBE.INUMERO3.ToString();

                if (!(bool)productoBE.isnull["INUMERO4"])
                    this.NUMERO4TextBox.Text = productoBE.INUMERO4.ToString();


                try
                {
                    this.FECHA1TextBox.Value = productoBE.IFECHA1;
                }
                catch
                {
                }

                try
                {
                    this.FECHA2TextBox.Value = productoBE.IFECHA2;
                }
                catch
                {
                }


                this.LlenarProductosHijo(productoBE.IID);

                this.LlenarProveedoreLigados(productoBE.IID);


                if (!(bool)productoBE.isnull["IESSUBPRODUCTO"])
                {
                    if (productoBE.IESSUBPRODUCTO == "S")
                        this.tabControl1.TabPages.RemoveAt(2);
                }


                if (!(bool)productoBE.isnull["IPZACAJA"])
                    this.PZACAJATextBox.Text = productoBE.IPZACAJA.ToString();


                if (!(bool)productoBE.isnull["IU_EMPAQUE"])
                    this.U_EMPAQUETextBox.Text = productoBE.IU_EMPAQUE.ToString();


                if (!(bool)productoBE.isnull["IUNIDAD"])
                {
                    this.UNIDADTextBox.SelectedDataDisplaying = productoBE.IUNIDAD.ToString();
                }
                else
                {
                    this.UNIDADTextBox.Text = "";
                }


                if (!(bool)productoBE.isnull["ICEMPAQUE"])
                    this.CEMPAQUETextBox.Text = productoBE.ICEMPAQUE.ToString();

                if (!(bool)productoBE.isnull["ICBARRAS"])
                    this.CBARRASTextBox.Text = productoBE.ICBARRAS.ToString();

                if (!(bool)productoBE.isnull["IPLUG"])
                    this.PLUGTextBox.Text = productoBE.IPLUG.ToString();

                if (!(bool)productoBE.isnull["IMAYOKGS"])
                    this.MAYOKGSTextBox.Checked = (productoBE.IMAYOKGS == "S") ? true : false;


                if (!(bool)productoBE.isnull["IINI_MAYO"])
                    this.INI_MAYOTextBox.Text = productoBE.IINI_MAYO.ToString();

                if (!(bool)productoBE.isnull["IDESCRIPCION_COMODIN"])
                    this.DESCRIPCION_COMODINTextBox.Checked = (productoBE.IDESCRIPCION_COMODIN == "S") ? true : false;


                if (!(bool)productoBE.isnull["ICUENTAPREDIAL"])
                    this.CUENTAPREDIALTextBox.Text = productoBE.ICUENTAPREDIAL.ToString();



                if (!(bool)productoBE.isnull["IIMAGEN"])
                {
                    this.IMAGENTextBox.Text = productoBE.IIMAGEN.ToString();

                    string imagePath = CurrentUserID.CurrentParameters.IRUTAIMAGENESPRODUCTO + "\\" + productoBE.IIMAGEN;
                    try
                    {
                        if (productoBE.IIMAGEN.ToString() != "")
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


                if (!(bool)productoBE.isnull["ITASAIEPS"])
                    this.TASAIEPSTextBox.Text = productoBE.ITASAIEPS.ToString();


                if (!(bool)productoBE.isnull["ITASAIMPUESTO"])
                    this.TASAIMPUESTOTextBox.Text = productoBE.ITASAIMPUESTO.ToString();


                if (!(bool)productoBE.isnull["IMINUTILIDAD"])
                    this.MINUTILIDADTextBox.Text = productoBE.IMINUTILIDAD.ToString();



                if (!(bool)productoBE.isnull["ISPRECIO1"])
                    this.SPRECIO1TextBox.Text = productoBE.ISPRECIO1.ToString();


                if (!(bool)productoBE.isnull["ISPRECIO2"])
                    this.SPRECIO2TextBox.Text = productoBE.ISPRECIO2.ToString();


                if (!(bool)productoBE.isnull["ISPRECIO3"])
                    this.SPRECIO3TextBox.Text = productoBE.ISPRECIO3.ToString();


                if (!(bool)productoBE.isnull["ISPRECIO4"])
                    this.SPRECIO4TextBox.Text = productoBE.ISPRECIO4.ToString();


                if (!(bool)productoBE.isnull["ISPRECIO5"])
                    this.SPRECIO5TextBox.Text = productoBE.ISPRECIO5.ToString();




                if (!(bool)productoBE.isnull["IDESCUENTO"])
                    this.DESCUENTOTextBox.Text = productoBE.IDESCUENTO.ToString();


                if (!(bool)productoBE.isnull["IREQUIERERECETA"])
                    this.REQUIERERECETATextBox.Checked = (productoBE.IREQUIERERECETA == "S") ? true : false;



                if (!(bool)productoBE.isnull["IPRECIOTOPE"])
                    this.PRECIOTOPETextBox.Text = productoBE.IPRECIOTOPE.ToString();

                if (!(bool)productoBE.isnull["ITIPOABC"])
                    this.TIPOABCTextBox.Checked = (productoBE.ITIPOABC == "S") ? true : false;


                if (!(bool)productoBE.isnull["IPRECIOMAT"])
                    this.PRECIOMATCheckBox.Checked = (productoBE.IPRECIOMAT == "S") ? true : false;

                try
                {
                    if ((bool)productoBE.isnull["IULTIMAVENTA"])
                    {
                        this.dtpLastSale.Visible = false;

                    }
                    else
                        this.dtpLastSale.Value = productoBE.IULTIMAVENTA;
                }
                catch
                {
                }

                try
                {
                    if ((bool)productoBE.isnull["IULTIMACOMPRA"])
                    {
                        this.dtpLastPurchase.Visible = false;
                    }
                    else
                        this.dtpLastPurchase.Value = productoBE.IULTIMACOMPRA;
                }
                catch
                {
                }





                if (!(bool)productoBE.isnull["IMENUDEO"])
                    this.MENUDEOTextBox.Text = productoBE.IMENUDEO.ToString();


                if (!(bool)productoBE.isnull["ICONTENIDOID"])
                {
                    this.CONTENIDOIDTextBox.SelectedDataValue = productoBE.ICONTENIDOID.ToString();
                }
                else
                {
                    //this.CONTENIDOIDTextBox.Text = "";
                    CONTENIDOIDTextBox.SelectedIndex = -1;
                }



                if (!(bool)productoBE.isnull["ICONTENIDOVALOR"])
                    this.CONTENIDOVALORTextBox.Text = productoBE.ICONTENIDOVALOR.ToString();

                if (!(bool)productoBE.isnull["ICLASIFICAID"])
                {
                    this.CLASIFICAIDTextBox.DbValue = productoBE.ICLASIFICAID.ToString();
                    this.CLASIFICAIDTextBox.MostrarErrores = false;
                    this.CLASIFICAIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.CLASIFICAIDTextBox.MostrarErrores = true;
                }


                if (!(bool)productoBE.isnull["IUNIDAD2"])
                {
                    this.UNIDAD2TextBox.SelectedDataDisplaying = productoBE.IUNIDAD2.ToString();
                }
                else
                {
                    this.UNIDAD2TextBox.Text = "CAJA";
                }

                if (!(bool)productoBE.isnull["ICANTXPIEZA"])
                    this.CANTXPIEZATextBox.Text = productoBE.ICANTXPIEZA.ToString();


                if (!(bool)productoBE.isnull["IMANEJALOTEIMPORTADO"])
                    this.MANEJALOTEIMPORTADOTextBox.Checked = (productoBE.IMANEJALOTEIMPORTADO == "S") ? true : false;

                if ((!((bool)productoBE.isnull["ILOTEIMPORTADOAPLICADO"]) && productoBE.ILOTEIMPORTADOAPLICADO != null &&
                    productoBE.ILOTEIMPORTADOAPLICADO.Equals("S")) &&
                    (productoBE.IMANEJALOTEIMPORTADO != null && productoBE.IMANEJALOTEIMPORTADO == "S")
                    )
                {
                    this.MANEJALOTEIMPORTADOTextBox.Enabled = false;
                    //return false;
                }



                if (!(bool)productoBE.isnull["ICOSTOENDOLAR"])
                    this.COSTOENDOLARTextBox.Text = productoBE.ICOSTOENDOLAR.ToString();


                if (!(bool)productoBE.isnull["IPLAZOID"])
                {
                    this.txtPlazoFB.DbValue = productoBE.IPLAZOID.ToString();
                    this.txtPlazoFB.MostrarErrores = false;
                    this.txtPlazoFB.MValidarEntrada(out strBuffer, 1);
                    this.txtPlazoFB.MostrarErrores = true;
                }

                if(!(bool)productoBE.isnull["ISAT_PRODUCTOSERVICIOID"])
                {
                    this.productoSatTextBoxFb.DbValue = productoBE.ISAT_PRODUCTOSERVICIOID.ToString();
                    this.productoSatTextBoxFb.MostrarErrores = false;
                    this.productoSatTextBoxFb.MValidarEntrada(out strBuffer, 1);
                    this.productoSatTextBoxFb.MostrarErrores = true;
                }


                 if (!(bool)productoBE.isnull["IESPRODPROMO"])
                     this.ESPRODPROMOTextBox.Checked = (productoBE.IESPRODPROMO == "S") ? true : false;


                 if (!(bool)productoBE.isnull["IBASEPRODPROMOID"])
                 {
                     this.BASEPRODPROMOIDTextBox.DbValue = productoBE.IBASEPRODPROMOID.ToString();
                     this.BASEPRODPROMOIDTextBox.MostrarErrores = false;
                     this.BASEPRODPROMOIDTextBox.MValidarEntrada(out strBuffer, 1);
                     this.BASEPRODPROMOIDTextBox.MostrarErrores = true;
                 }


                 try
                 {
                     this.VIGENCIAPRODPROMOTextBox.Value = productoBE.IVIGENCIAPRODPROMO;
                 }
                 catch
                 {
                 }

                try
                {
                    this.VIGENCIAPRODKITTextBox.Value = productoBE.IVIGENCIAPRODKIT;
                }
                catch
                {
                }

                try
                {

                    if (!(bool)productoBE.isnull["IKITTIENEVIG"])
                        this.KITTIENEVIGTextBox.Checked = (productoBE.IKITTIENEVIG == "S") ? true : false;

                }
                catch
                {

                }


                try
                {

                    if (!(bool)productoBE.isnull["IVALXSUC"])
                        this.VALXSUCTextBox.Checked = (productoBE.IVALXSUC == "S") ? true : false;

                }
                catch
                {

                }

                try
                {

                    if (!(bool)productoBE.isnull["IDESCTOPE"])
                        this.DESCTOPETextBox.Text = productoBE.IDESCTOPE.ToString();

                    if (!(bool)productoBE.isnull["IMARGEN"])
                        this.MARGENTextBox.Text = productoBE.IMARGEN.ToString();

                    if (!(bool)productoBE.isnull["IDESCPES"])
                        this.DESCPESTextBox.Text = productoBE.IDESCPES.ToString();
                }
                catch { }

                try
                {

                    if (!(bool)productoBE.isnull["IKITIMPFIJO"])
                        this.KITIMPFIJOTextBox.Checked = (productoBE.IKITIMPFIJO == "S") ? true : false;

                }
                catch
                {

                }

                try
                {
                    if (!(bool)productoBE.isnull["IPORCUTILPRECIO1"])
                        this.PORCUTILPRECIO1TextBox.Text = productoBE.IPORCUTILPRECIO1.ToString();


                    if (!(bool)productoBE.isnull["IPORCUTILPRECIO2"])
                        this.PORCUTILPRECIO2TextBox.Text = productoBE.IPORCUTILPRECIO2.ToString();


                    if (!(bool)productoBE.isnull["IPORCUTILPRECIO3"])
                        this.PORCUTILPRECIO3TextBox.Text = productoBE.IPORCUTILPRECIO3.ToString();


                    if (!(bool)productoBE.isnull["IPORCUTILPRECIO4"])
                        this.PORCUTILPRECIO4TextBox.Text = productoBE.IPORCUTILPRECIO4.ToString();


                    if (!(bool)productoBE.isnull["IPORCUTILPRECIO5"])
                        this.PORCUTILPRECIO5TextBox.Text = productoBE.IPORCUTILPRECIO5.ToString();
                }
                catch{ }


                if (!(bool)productoBE.isnull["IIMPRIMIRCOMANDA"])
                    this.IMPRIMIRCOMANDATextBox.Checked = (productoBE.IIMPRIMIRCOMANDA == "S") ? true : false;

                try
                {
                    

                    if (!(bool)productoBE.isnull["ILISTAPRECMEDIOMAYID"])
                    {
                        this.LISTAPRECMEDIOMAYIDTextBox.Text = productoBE.ILISTAPRECMEDIOMAYID.ToString();
                    }
                    else
                    {
                        this.LISTAPRECMEDIOMAYIDTextBox.Text = "";
                    }

                    if (!(bool)productoBE.isnull["ICANTMEDIOMAY"])
                        this.CANTMEDIOMAYTextBox.Text = productoBE.ICANTMEDIOMAY.ToString();



                    if (!(bool)productoBE.isnull["ILISTAPRECMAYOREOID"])
                    {
                        this.LISTAPRECMAYOREOIDTextBox.Text = productoBE.ILISTAPRECMAYOREOID.ToString();
                    }
                    else
                    {
                        this.LISTAPRECMAYOREOIDTextBox.Text = "";
                    }

                    if (!(bool)productoBE.isnull["ICANTMAYOREO"])
                        this.CANTMAYOREOTextBox.Text = productoBE.ICANTMAYOREO.ToString();
                }
                catch { }


                if (!(bool)productoBE.isnull["IESPELIGROSO"])
                    this.ESPELIGROSOTextBox.Checked = (productoBE.IESPELIGROSO == "S") ? true : false;


                if (!(bool)productoBE.isnull["IPESO"])
                    this.PESOTextBox.Text = productoBE.IPESO.ToString();


                if (!(bool)productoBE.isnull["ISAT_TIPOEMBALAJEID"])
                {
                    this.SAT_TIPOEMBALAJEIDTextBox.DbValue = productoBE.ISAT_TIPOEMBALAJEID.ToString();
                    this.SAT_TIPOEMBALAJEIDTextBox.MostrarErrores = false;
                    this.SAT_TIPOEMBALAJEIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SAT_TIPOEMBALAJEIDTextBox.MostrarErrores = true;
                }

                if (!(bool)productoBE.isnull["ISAT_CLAVEUNIDADPESOID"])
                {
                    this.SAT_CLAVEUNIDADPESOIDTextBox.DbValue = productoBE.ISAT_CLAVEUNIDADPESOID.ToString();
                    this.SAT_CLAVEUNIDADPESOIDTextBox.MostrarErrores = false;
                    this.SAT_CLAVEUNIDADPESOIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SAT_CLAVEUNIDADPESOIDTextBox.MostrarErrores = true;
                }


                if (!(bool)productoBE.isnull["ISAT_MATPELIGROSOID"])
                {
                    this.SAT_MATPELIGROSOIDTextBox.DbValue = productoBE.ISAT_MATPELIGROSOID.ToString();
                    this.SAT_MATPELIGROSOIDTextBox.MostrarErrores = false;
                    this.SAT_MATPELIGROSOIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SAT_MATPELIGROSOIDTextBox.MostrarErrores = true;
                }


                if (!(bool)productoBE.isnull["IESOFERTA"])
                    this.ESOFERTATextBox.Checked = (productoBE.IESOFERTA == "S") ? true : false;

                CargarSucursalesPorProducto(productoBE,  productoD);

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


        private CPRODUCTOBE ObtenerDatosCapturados(CPRODUCTOBE PRODUCTOBE)
        {


            //if (this.ACTIVOTextBox.Text != "")
            //{
            PRODUCTOBE.IACTIVO = (this.ACTIVOTextBox.Checked) ? "S" : "N";
            //}


            if (this.CREADOTextBox.Text != "")
            {
                PRODUCTOBE.ICREADO = this.CREADOTextBox.Value;
            }


            if (this.MODIFICADOTextBox.Text != "")
            {
                PRODUCTOBE.IMODIFICADO = this.MODIFICADOTextBox.Value;
            }


            if (this.CLAVETextBox.Text != "")
            {
                PRODUCTOBE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                PRODUCTOBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }


            if (this.DESCRIPCIONTextBox.Text != "")
            {
                PRODUCTOBE.IDESCRIPCION = this.DESCRIPCIONTextBox.Text.ToString();
            }


            //if (this.EANTextBox.Text != "")
            //{
            PRODUCTOBE.IEAN = this.EANTextBox.Text.ToString();
            //}


            if (this.DESCRIPCION1TextBox.Text != "")
            {
                PRODUCTOBE.IDESCRIPCION1 = this.DESCRIPCION1TextBox.Text.ToString();
            }


            if (this.DESCRIPCION2TextBox.Text != "")
            {
                PRODUCTOBE.IDESCRIPCION2 = this.DESCRIPCION2TextBox.Text.ToString();
            }


            if (this.DESCRIPCION3TextBox.Text != "")
            {
                PRODUCTOBE.IDESCRIPCION3 = this.DESCRIPCION3TextBox.Text.ToString();
            }


            //if (this.MANEJALOTETextBox.Text != "")
            //{
            PRODUCTOBE.IMANEJALOTE = (this.MANEJALOTETextBox.Checked) ? "S" : "N";
            // }


            //if (this.ESKITTextBox.Text != "")
            //{
            PRODUCTOBE.IESKIT = (this.ESKITTextBox.Checked) ? "S" : "N";
            //}


            //if (this.IMPRIMIRTextBox.Text != "")
            //{
            PRODUCTOBE.IIMPRIMIR = (this.IMPRIMIRTextBox.Checked) ? "S" : "N";
            //}


            //if (this.INVENTARIABLETextBox.Text != "")
            //{
            PRODUCTOBE.IINVENTARIABLE = (this.INVENTARIABLETextBox.Checked) ? "S" : "N";
            //}


            //if (this.NEGATIVOSTextBox.Text != "")
            //{
            PRODUCTOBE.INEGATIVOS = (this.NEGATIVOSTextBox.Checked) ? "S" : "N";
            //}


            //if (this.IDTextBox.Text != "")
            //{
            //    PRODUCTOBE.IID = Int64.Parse(this.IDTextBox.Text.ToString());
            //}


            //if (this.CREADOPOR_USERIDTextBox.Text != "")
            //{
            //    PRODUCTOBE.ICREADOPOR_USERID = Int64.Parse(this.CREADOPOR_USERIDTextBox.Text.ToString());
            //}


            //if (this.MODIFICADOPOR_USERIDTextBox.Text != "")
            //{
            //    PRODUCTOBE.IMODIFICADOPOR_USERID = Int64.Parse(this.MODIFICADOPOR_USERIDTextBox.Text.ToString());
            //}


            if (this.PROVEEDOR1IDTextBox.Text != "")
            {
                PRODUCTOBE.IPROVEEDOR1ID = Int32.Parse(this.PROVEEDOR1IDTextBox.DbValue.ToString());
            }


            if (this.PROVEEDOR2IDTextBox.Text != "")
            {
                PRODUCTOBE.IPROVEEDOR2ID = Int32.Parse(this.PROVEEDOR2IDTextBox.DbValue.ToString());
            }


            if (this.LINEAIDTextBox.Text != "")
            {
                PRODUCTOBE.ILINEAID = Int32.Parse(this.LINEAIDTextBox.DbValue.ToString());
            }

            if(!String.IsNullOrEmpty(this.productoSatTextBoxFb.Text))
            {
                PRODUCTOBE.ISAT_PRODUCTOSERVICIOID = Int32.Parse(this.productoSatTextBoxFb.DbValue.ToString());
            }


            if (this.MARCAIDTextBox.Text != "")
            {
                PRODUCTOBE.IMARCAID = Int32.Parse(this.MARCAIDTextBox.DbValue.ToString());
            }


            if (this.PRECIO1TextBox.Text != "")
            {
                PRODUCTOBE.IPRECIO1 = Math.Round(decimal.Parse(this.PRECIO1TextBox.Text.ToString()), 2);
            }


            if (this.PRECIO2TextBox.Text != "")
            {
                PRODUCTOBE.IPRECIO2 = Math.Round(decimal.Parse(this.PRECIO2TextBox.Text.ToString()), 2);
            }


            if (this.PRECIO3TextBox.Text != "")
            {
                PRODUCTOBE.IPRECIO3 = Math.Round(decimal.Parse(this.PRECIO3TextBox.Text.ToString()), 2);
            }


            if (this.PRECIO4TextBox.Text != "")
            {
                PRODUCTOBE.IPRECIO4 = Math.Round(decimal.Parse(this.PRECIO4TextBox.Text.ToString()), 2);
            }


            if (this.PRECIO5TextBox.Text != "")
            {
                PRODUCTOBE.IPRECIO5 = Math.Round(decimal.Parse(this.PRECIO5TextBox.Text.ToString()), 2);
            }





            if (this.PRECIO6TextBox.Text != "")
            {
                PRODUCTOBE.IPRECIO6 = decimal.Parse(this.PRECIO6TextBox.Text.ToString());
            }

            if (this.PRECIOSUGERIDOTextBox.Text != "")
            {
                PRODUCTOBE.IPRECIOSUGERIDO = decimal.Parse(this.PRECIOSUGERIDOTextBox.Text.ToString());
            }


            if (this.TASAIVAIDTextBox.Text != "")
            {
                PRODUCTOBE.ITASAIVAID = Int64.Parse(this.TASAIVAIDTextBox.DbValue.ToString());
            }


            if (this.TASAIVATextBox.Text != "")
            {
                PRODUCTOBE.ITASAIVA = decimal.Parse(this.TASAIVATextBox.Text.ToString());
            }


            if (this.MONEDAIDTextBox.Text != "")
            {
                PRODUCTOBE.IMONEDAID = Int64.Parse(this.MONEDAIDTextBox.DbValue.ToString());
            }


            if (this.COSTOREPOSICIONTextBox.Text != "")
            {
                PRODUCTOBE.ICOSTOREPOSICION = decimal.Parse(this.COSTOREPOSICIONTextBox.Text.ToString());
            }


            if (this.COSTOULTIMOTextBox.Text != "")
            {
                PRODUCTOBE.ICOSTOULTIMO = decimal.Parse(this.COSTOULTIMOTextBox.Text.ToString());
            }


            if (this.COSTOPROMEDIOTextBox.Text != "")
            {
                PRODUCTOBE.ICOSTOPROMEDIO = decimal.Parse(this.COSTOPROMEDIOTextBox.Text.ToString());
            }


            if (this.PRODUCTOSUSTITUTOIDTextBox.Text != "")
            {
                PRODUCTOBE.IPRODUCTOSUSTITUTOID = Int64.Parse(this.PRODUCTOSUSTITUTOIDTextBox.DbValue.ToString());
            }


            if (this.LIMITEPRECIO2TextBox.Text != "")
            {
                PRODUCTOBE.ILIMITEPRECIO2 = decimal.Parse(this.LIMITEPRECIO2TextBox.Text.ToString());
            }


            if (this.PRECIOMAXIMOPUBLICOTextBox.Text != "")
            {
                PRODUCTOBE.IPRECIOMAXIMOPUBLICO = decimal.Parse(this.PRECIOMAXIMOPUBLICOTextBox.Text.ToString());
            }


            PRODUCTOBE.IFECHACAMBIOPRECIO = this.FECHACAMBIOPRECIOTextBox.Value;


            PRODUCTOBE.IMANEJASTOCK = (this.MANEJASTOCKTextBox.Checked) ? "S" : "N";

            if (this.STOCKTextBox.Text != "")
            {
                PRODUCTOBE.ISTOCK = decimal.Parse(this.STOCKTextBox.Text.ToString());
            }


            if (this.STOCKMAXTextBox.Text != "")
            {
                PRODUCTOBE.ISTOCKMAX = decimal.Parse(this.STOCKMAXTextBox.Text.ToString());
            }


            PRODUCTOBE.ISURTIRPORCAJA = (this.SURTIRPORCAJATextBox.Checked) ? "S" : "N";

            PRODUCTOBE.ICAMBIARPRECIO = (this.CAMBIARPRECIOTextBox.Checked) ? "S" : "N";




            if (this.COMISIONTextBox.Text != "")
            {
                PRODUCTOBE.ICOMISION = decimal.Parse(this.COMISIONTextBox.Text.ToString());
            }

            if (this.OFERTATextBox.Text != "")
            {
                PRODUCTOBE.IOFERTA = decimal.Parse(this.OFERTATextBox.Text.ToString());
            }


            if (this.TEXTO1TextBox.Text != "")
            {
                PRODUCTOBE.ITEXTO1 = this.TEXTO1TextBox.Text.ToString();
            }

            if (this.TEXTO2TextBox.Text != "")
            {
                PRODUCTOBE.ITEXTO2 = this.TEXTO2TextBox.Text.ToString();
            }

            if (this.TEXTO3TextBox.Text != "")
            {
                PRODUCTOBE.ITEXTO3 = this.TEXTO3TextBox.Text.ToString();
            }

            if (this.TEXTO4TextBox.Text != "")
            {
                PRODUCTOBE.ITEXTO4 = this.TEXTO4TextBox.Text.ToString();
            }

            if (this.TEXTO5TextBox.Text != "")
            {
                PRODUCTOBE.ITEXTO5 = this.TEXTO5TextBox.Text.ToString();
            }

            if (this.TEXTO6TextBox.Text != "")
            {
                PRODUCTOBE.ITEXTO6 = this.TEXTO6TextBox.Text.ToString();
            }


            if (this.NUMERO1TextBox.Text != "")
            {
                PRODUCTOBE.INUMERO1 = decimal.Parse(this.NUMERO1TextBox.Text.ToString());
            }
            if (this.NUMERO2TextBox.Text != "")
            {
                PRODUCTOBE.INUMERO2 = decimal.Parse(this.NUMERO2TextBox.Text.ToString());
            }
            if (this.NUMERO3TextBox.Text != "")
            {
                PRODUCTOBE.INUMERO3 = decimal.Parse(this.NUMERO3TextBox.Text.ToString());
            }
            if (this.NUMERO4TextBox.Text != "")
            {
                PRODUCTOBE.INUMERO4 = decimal.Parse(this.NUMERO4TextBox.Text.ToString());
            }


            if (this.FECHA1TextBox.Text != "")
            {
                PRODUCTOBE.IFECHA1 = this.FECHA1TextBox.Value;
            }


            if (this.FECHA2TextBox.Text != "")
            {
                PRODUCTOBE.IFECHA2 = this.FECHA2TextBox.Value;
            }


            if (this.PZACAJATextBox.Text != "")
            {
                PRODUCTOBE.IPZACAJA = decimal.Parse(this.PZACAJATextBox.Text.ToString());
            }

            if (this.U_EMPAQUETextBox.Text != "")
            {
                PRODUCTOBE.IU_EMPAQUE = decimal.Parse(this.U_EMPAQUETextBox.Text.ToString());
            }


            PRODUCTOBE.ICEMPAQUE = this.CEMPAQUETextBox.Text.ToString();

            PRODUCTOBE.ICBARRAS = this.CBARRASTextBox.Text.ToString();

            PRODUCTOBE.IPLUG = this.PLUGTextBox.Text.ToString();


            // si la unidad es distinta de kg entonces pon ini_mayo en 0 y mayokgs en false
            bool bEsKg = false;
            if (this.UNIDADTextBox.Text != "")
            {
                PRODUCTOBE.IUNIDAD = this.UNIDADTextBox.Text.ToString();
                if (PRODUCTOBE.IUNIDAD.Trim().Equals("KG"))
                {
                    bEsKg = true;
                }
            }


            if (!bEsKg)
            {
                PRODUCTOBE.IMAYOKGS = "N";
                PRODUCTOBE.IINI_MAYO = 0;
            }
            else
            {
                PRODUCTOBE.IMAYOKGS = (this.MAYOKGSTextBox.Checked) ? "S" : "N";
                if (this.INI_MAYOTextBox.Text != "")
                {
                    PRODUCTOBE.IINI_MAYO = decimal.Parse(this.INI_MAYOTextBox.Text.ToString());
                }
            }



            if (this.UNIDAD2TextBox.Text != "")
            {
                PRODUCTOBE.IUNIDAD2 = this.UNIDAD2TextBox.Text.ToString();
            }

            PRODUCTOBE.IDESCRIPCION_COMODIN = (this.DESCRIPCION_COMODINTextBox.Checked) ? "S" : "N";

            if (this.CUENTAPREDIALTextBox.Text != "")
            {
                PRODUCTOBE.ICUENTAPREDIAL = this.CUENTAPREDIALTextBox.Text.ToString();
            }


            if (m_bChangeImage)
            {
                if (pictureBox1.Image != null)
                    PRODUCTOBE.IIMAGEN = PRODUCTOBE.ICLAVE + "___1." + Path.GetExtension(NuevaImagenTextBox.Text);
                else
                    PRODUCTOBE.IIMAGEN = "";
            }


            if (this.TASAIEPSTextBox.Text != "")
            {
                PRODUCTOBE.ITASAIEPS = decimal.Parse(this.TASAIEPSTextBox.Text.ToString());
            }

            if (this.TASAIMPUESTOTextBox.Text != "")
            {
                PRODUCTOBE.ITASAIMPUESTO = decimal.Parse(this.TASAIMPUESTOTextBox.Text.ToString());
            }

            if (this.MINUTILIDADTextBox.Text != "")
            {
                PRODUCTOBE.IMINUTILIDAD = decimal.Parse(this.MINUTILIDADTextBox.Text.ToString());
            }


            if (this.SPRECIO1TextBox.Text != "")
            {
                PRODUCTOBE.ISPRECIO1 = decimal.Parse(this.SPRECIO1TextBox.Text.ToString());
            }


            if (this.SPRECIO2TextBox.Text != "")
            {
                PRODUCTOBE.ISPRECIO2 = decimal.Parse(this.SPRECIO2TextBox.Text.ToString());
            }


            if (this.SPRECIO3TextBox.Text != "")
            {
                PRODUCTOBE.ISPRECIO3 = decimal.Parse(this.SPRECIO3TextBox.Text.ToString());
            }


            if (this.SPRECIO4TextBox.Text != "")
            {
                PRODUCTOBE.ISPRECIO4 = decimal.Parse(this.SPRECIO4TextBox.Text.ToString());
            }


            if (this.SPRECIO5TextBox.Text != "")
            {
                PRODUCTOBE.ISPRECIO5 = decimal.Parse(this.SPRECIO5TextBox.Text.ToString());
            }


            if (this.DESCUENTOTextBox.Text != "")
            {
                PRODUCTOBE.IDESCUENTO = decimal.Parse(this.DESCUENTOTextBox.Text.ToString());
            }


            PRODUCTOBE.IREQUIERERECETA = (this.REQUIERERECETATextBox.Checked) ? "S" : "N";

            if (this.PRECIOTOPETextBox.Text != "")
            {
                PRODUCTOBE.IPRECIOTOPE = decimal.Parse(this.PRECIOTOPETextBox.Text.ToString());
            }

            PRODUCTOBE.ITIPOABC = (this.TIPOABCTextBox.Checked) ? "S" : "N";

            PRODUCTOBE.IPRECIOMAT = (this.PRECIOMATCheckBox.Checked) ? "S" : "N";


            if (this.MENUDEOTextBox.Text != "")
            {
                PRODUCTOBE.IMENUDEO = decimal.Parse(this.MENUDEOTextBox.Text.ToString());
            }

            if (this.CONTENIDOIDTextBox.Text != "")
            {
                try
                {
                    PRODUCTOBE.ICONTENIDOID = Int64.Parse(this.CONTENIDOIDTextBox.SelectedValue.ToString());
                }
                catch
                {

                }

            }
            else
            {
                PRODUCTOBE.ICONTENIDOID = 0;
            }

            if (this.CONTENIDOVALORTextBox.Text != "")
            {
                PRODUCTOBE.ICONTENIDOVALOR = decimal.Parse(this.CONTENIDOVALORTextBox.Text.ToString());
            }

            if (this.CLASIFICAIDTextBox.Text != "")
            {
                PRODUCTOBE.ICLASIFICAID = Int64.Parse(this.CLASIFICAIDTextBox.DbValue.ToString());
            }
            else
            {
                PRODUCTOBE.ICLASIFICAID = 0;
            }


            if (this.CANTXPIEZATextBox.Text != "")
            {
                PRODUCTOBE.ICANTXPIEZA = decimal.Parse(this.CANTXPIEZATextBox.Text.ToString());
            }


            PRODUCTOBE.IMANEJALOTEIMPORTADO = (this.MANEJALOTEIMPORTADOTextBox.Checked) ? "S" : "N";


            if (this.COSTOENDOLARTextBox.Text != "")
            {
                PRODUCTOBE.ICOSTOENDOLAR = decimal.Parse(this.COSTOENDOLARTextBox.Text.ToString());
            }

            if (this.txtPlazoFB.Text != "")
            {
                PRODUCTOBE.IPLAZOID = Int32.Parse(this.txtPlazoFB.DbValue.ToString());
            }


            PRODUCTOBE.IESPRODPROMO = (this.ESPRODPROMOTextBox.Checked) ? "S" : "N";

            if (this.BASEPRODPROMOIDTextBox.Text != "")
            {
                PRODUCTOBE.IBASEPRODPROMOID = Int64.Parse(this.BASEPRODPROMOIDTextBox.DbValue.ToString());
            }
            else
            {
                PRODUCTOBE.IBASEPRODPROMOID = 0;
            }


            if (this.VIGENCIAPRODPROMOTextBox.Text != "")
            {
                PRODUCTOBE.IVIGENCIAPRODPROMO = this.VIGENCIAPRODPROMOTextBox.Value;
            }

            if (this.VIGENCIAPRODKITTextBox.Text != "")
            {
                PRODUCTOBE.IVIGENCIAPRODKIT = this.VIGENCIAPRODKITTextBox.Value;
            }


            PRODUCTOBE.IKITTIENEVIG = (this.KITTIENEVIGTextBox.Checked) ? "S" : "N";

            PRODUCTOBE.IVALXSUC = (this.VALXSUCTextBox.Checked) ? "S" : "N";


            if (this.DESCTOPETextBox.Text != "")
            {
                PRODUCTOBE.IDESCTOPE = decimal.Parse(this.DESCTOPETextBox.Text.ToString());
            }

            if (this.MARGENTextBox.Text != "")
            {
                PRODUCTOBE.IMARGEN = decimal.Parse(this.MARGENTextBox.Text.ToString());
            }

            if (this.DESCPESTextBox.Text != "")
            {
                PRODUCTOBE.IDESCPES = decimal.Parse(this.DESCPESTextBox.Text.ToString());
            }

            PRODUCTOBE.IKITIMPFIJO = (this.KITIMPFIJOTextBox.Checked) ? "S" : "N";



            if (this.PORCUTILPRECIO1TextBox.Text != "")
            {
                PRODUCTOBE.IPORCUTILPRECIO1 = decimal.Parse(this.PORCUTILPRECIO1TextBox.Text.ToString());
            }


            if (this.PORCUTILPRECIO2TextBox.Text != "")
            {
                PRODUCTOBE.IPORCUTILPRECIO2 = decimal.Parse(this.PORCUTILPRECIO2TextBox.Text.ToString());
            }


            if (this.PORCUTILPRECIO3TextBox.Text != "")
            {
                PRODUCTOBE.IPORCUTILPRECIO3 = decimal.Parse(this.PORCUTILPRECIO3TextBox.Text.ToString());
            }


            if (this.PORCUTILPRECIO4TextBox.Text != "")
            {
                PRODUCTOBE.IPORCUTILPRECIO4 = decimal.Parse(this.PORCUTILPRECIO4TextBox.Text.ToString());
            }


            if (this.PORCUTILPRECIO5TextBox.Text != "")
            {
                PRODUCTOBE.IPORCUTILPRECIO5 = decimal.Parse(this.PORCUTILPRECIO5TextBox.Text.ToString());
            }


            PRODUCTOBE.IIMPRIMIRCOMANDA = (this.IMPRIMIRCOMANDATextBox.Checked) ? "S" : "N";



            if (this.LISTAPRECMEDIOMAYIDTextBox.Text != "")
            {
                PRODUCTOBE.ILISTAPRECMEDIOMAYID = Int64.Parse(this.LISTAPRECMEDIOMAYIDTextBox.Text.ToString());
            }
            if (this.CANTMEDIOMAYTextBox.Text != "")
            {
                PRODUCTOBE.ICANTMEDIOMAY = decimal.Parse(this.CANTMEDIOMAYTextBox.Text.ToString());
            }


            if (this.LISTAPRECMAYOREOIDTextBox.Text != "")
            {
                PRODUCTOBE.ILISTAPRECMAYOREOID = Int64.Parse(this.LISTAPRECMAYOREOIDTextBox.Text.ToString());
            }
            if (this.CANTMAYOREOTextBox.Text != "")
            {
                PRODUCTOBE.ICANTMAYOREO = decimal.Parse(this.CANTMAYOREOTextBox.Text.ToString());
            }


            PRODUCTOBE.IESPELIGROSO = (this.ESPELIGROSOTextBox.Checked) ? "S" : "N";

            if (this.PESOTextBox.Text != "")
            {
                PRODUCTOBE.IPESO = decimal.Parse(this.PESOTextBox.Text.ToString());
            }



            if (this.SAT_TIPOEMBALAJEIDTextBox.Text != "")
            {
                try
                {
                    PRODUCTOBE.ISAT_TIPOEMBALAJEID = Int64.Parse(this.SAT_TIPOEMBALAJEIDTextBox.DbValue.ToString());
                }
                catch {}
            }
            else
            {
                PRODUCTOBE.ISAT_TIPOEMBALAJEID = 0;
            }


            if (this.SAT_CLAVEUNIDADPESOIDTextBox.Text != "")
            {
                try
                {
                    PRODUCTOBE.ISAT_CLAVEUNIDADPESOID = Int64.Parse(this.SAT_CLAVEUNIDADPESOIDTextBox.DbValue.ToString());
                }
                catch { }
            }
            else
            {
                PRODUCTOBE.ISAT_CLAVEUNIDADPESOID = 0;
            }




            if (this.SAT_MATPELIGROSOIDTextBox.Text != "")
            {
                try
                {
                    PRODUCTOBE.ISAT_MATPELIGROSOID = Int64.Parse(this.SAT_MATPELIGROSOIDTextBox.DbValue.ToString());
                }
                catch { }
            }
            else
            {
                PRODUCTOBE.ISAT_MATPELIGROSOID = 0;
            }

            PRODUCTOBE.IESOFERTA = (this.ESOFERTATextBox.Checked) ? "S" : "N";


            return PRODUCTOBE;

        }

        public void SaveChanges()
        {
            if (CLAVETextBox.Text.ToUpper().Contains("EMIDA-"))
            {
                MessageBox.Show("Los productos no pueden contener la cadena EMIDA- como Clave!");
                CLAVETextBox.Focus();
                return;
            }

            if(CurrentUserID.CurrentParameters.IVERSIONCFDI != null && (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")))
            {
                if(productoSatTextBoxFb.Text == null || productoSatTextBoxFb.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Debe de asignar una clave sat");
                    productoSatTextBoxFb.Focus();
                    return;
                }
            }
            

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
                    CPRODUCTOD PRODUCTOD = new CPRODUCTOD();

                    if (opc == "Agregar")
                    {
                        CPRODUCTOBE PRODUCTOBE = new CPRODUCTOBE();
                        PRODUCTOBE = ObtenerDatosCapturados(PRODUCTOBE);
                        PRODUCTOBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;
                        PRODUCTOBE.ICREADO = DateTime.Now;

                        if (!ValidarDatos(PRODUCTOBE))
                            return;

                        PRODUCTOBE = PRODUCTOD.AgregarPRODUCTO(PRODUCTOBE, null);

                        if (PRODUCTOD.IComentario == "" || PRODUCTOD.IComentario == null)
                        {

                            if (m_bChangeImage)
                            {
                                string imagePath = CurrentUserID.CurrentParameters.IRUTAIMAGENESPRODUCTO + "\\" + PRODUCTOBE.IIMAGEN;
                                if (File.Exists(imagePath))
                                    File.Delete(imagePath);



                                if (pictureBox1.Image != null)
                                {
                                    pictureBox1.Image.Save(imagePath);
                                }
                                m_bChangeImage = false;
                            }

                            AgregarSucursalProducto(opc, PRODUCTOBE);

                            GuardarCambiosProveedoresLigados(opc, PRODUCTOBE);

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + PRODUCTOD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CPRODUCTOBE PRODUCTOBEAnt = new CPRODUCTOBE();
                        CPRODUCTOBE PRODUCTOBE = new CPRODUCTOBE();

                        PRODUCTOBE.IID = this.ID;
                        PRODUCTOBE = PRODUCTOD.seleccionarPRODUCTO(PRODUCTOBE, null);

                        PRODUCTOBE = ObtenerDatosCapturados(PRODUCTOBE);
                        PRODUCTOBEAnt.IID = this.ID;


                        PRODUCTOBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;
                        PRODUCTOBE.IMODIFICADO = DateTime.Now;


                        if (!ValidarDatos(PRODUCTOBE))
                            return;



                        PRODUCTOD.CambiarPRODUCTO(PRODUCTOBE, PRODUCTOBEAnt, null);
                        if (PRODUCTOD.IComentario == "" || PRODUCTOD.IComentario == null)
                        {
                            if (m_bChangeImage)
                            {
                                string imagePath = CurrentUserID.CurrentParameters.IRUTAIMAGENESPRODUCTO + "\\" + PRODUCTOBE.IIMAGEN;
                                if (File.Exists(imagePath))
                                    File.Delete(imagePath);

                                if (pictureBox1.Image != null)
                                {
                                    pictureBox1.Image.Save(imagePath);
                                }
                                m_bChangeImage = false;
                            }


                            AgregarSucursalProducto(opc, PRODUCTOBE);

                            GuardarCambiosProveedoresLigados(opc, PRODUCTOBE);

                            if (HayCambiosPrecios(this.m_producto, PRODUCTOBE))
                            {
                                CLISTAPRECIODETALLED listaPrecioD = new CLISTAPRECIODETALLED();
                                int iCuentaListas = listaPrecioD.cuentaListasConProducto(PRODUCTOBE.IID, null);

                                if(iCuentaListas > 0)
                                {
                                    WFProductoListasPrecio wf = new WFProductoListasPrecio(PRODUCTOBE.IID);
                                    wf.ShowDialog();
                                    wf.Dispose();
                                    GC.SuppressFinalize(wf);
                                }
                            }


                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            showHideTabPages();
                            habilitarCamposPorKit();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("ERRORES: " + PRODUCTOD.IComentario.Replace("%", "\n"));
                        }


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CPRODUCTOBE PRODUCTOBEAnt = new CPRODUCTOBE();

                            PRODUCTOBEAnt.IID = this.ID;

                            PRODUCTOD.BorrarPRODUCTO(PRODUCTOBEAnt, null);
                            if (PRODUCTOD.IComentario == "" || PRODUCTOD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + PRODUCTOD.IComentario.Replace("%", "\n"));
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

        private void HabilitarCamposInventariables(bool b)
        {
            int reg_count = 0;
            bool retorno;

            if (b == false)
                return;

            CPRODUCTOD prodD = new CPRODUCTOD();
            CPRODUCTOBE prodBE = new CPRODUCTOBE();
            prodBE.IID = this.ID;

            retorno = prodD.GetNumTransacciones(prodBE, ref  reg_count, null);

            if (!retorno || reg_count > 0)
            {
                this.INVENTARIABLETextBox.Enabled = false;
            }
            else
            {

                this.INVENTARIABLETextBox.Enabled = true;
            }




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
            if (bLimpiarKeys)
            {

                //this.IDTextBox.Text = "";
                this.CLAVETextBox.Text = "";

            }



            this.ACTIVOTextBox.Checked = false;


            this.CREADOTextBox.Value = DateTime.Today;


            //this.CREADOPOR_USERIDTextBox.Text = "";


            this.MODIFICADOTextBox.Value = DateTime.Today;


            //this.MODIFICADOPOR_USERIDTextBox.Text = "";


            this.NOMBRETextBox.Text = "";


            this.DESCRIPCIONTextBox.Text = "";


            this.EANTextBox.Text = "";


            this.DESCRIPCION1TextBox.Text = "";


            this.DESCRIPCION2TextBox.Text = "";


            this.DESCRIPCION3TextBox.Text = "";


            this.PROVEEDOR1IDTextBox.Text = "";


            this.PROVEEDOR2IDTextBox.Text = "";


            this.LINEAIDTextBox.Text = "";


            this.MARCAIDTextBox.Text = "";


            this.PRECIO1TextBox.Text = "";


            this.PRECIO2TextBox.Text = "";


            this.PRECIO3TextBox.Text = "";


            this.PRECIO4TextBox.Text = "";


            this.PRECIO5TextBox.Text = "";

            this.PRECIO6TextBox.Text = "";

            this.PRECIOSUGERIDOTextBox.Text = "";


            this.TASAIVAIDTextBox.Text = "";


            this.TASAIVATextBox.Text = "";


            this.MONEDAIDTextBox.Text = "";


            this.COSTOREPOSICIONTextBox.Text = "";


            this.COSTOULTIMOTextBox.Text = "";


            this.COSTOPROMEDIOTextBox.Text = "";


            this.PRODUCTOSUSTITUTOIDTextBox.Text = "";


            this.MANEJALOTETextBox.Checked = false;


            this.ESKITTextBox.Checked = false;


            this.IMPRIMIRTextBox.Checked = false;


            this.INVENTARIABLETextBox.Checked = false;


            this.NEGATIVOSTextBox.Checked = false;


            this.LIMITEPRECIO2TextBox.Text = "";


            this.PRECIOMAXIMOPUBLICOTextBox.Text = "";


            this.FECHACAMBIOPRECIOTextBox.Value = DateTime.Today;


            this.MANEJASTOCKTextBox.Checked = false;


            this.STOCKTextBox.Text = "";


            this.CAMBIARPRECIOTextBox.Checked = false;



            this.COMISIONTextBox.Text = "";

            this.OFERTATextBox.Text = "";

            this.TEXTO1TextBox.Text = "";
            this.TEXTO2TextBox.Text = "";
            this.TEXTO3TextBox.Text = "";
            this.TEXTO4TextBox.Text = "";
            this.TEXTO5TextBox.Text = "";
            this.TEXTO6TextBox.Text = "";


            this.NUMERO1TextBox.Text = "";
            this.NUMERO2TextBox.Text = "";
            this.NUMERO3TextBox.Text = "";
            this.NUMERO4TextBox.Text = "";


            this.FECHA1TextBox.Value = DateTime.Today;
            this.FECHA2TextBox.Value = DateTime.Today;


            this.PZACAJATextBox.Text = "";

            this.MAYOKGSTextBox.Checked = false;
            this.CEMPAQUETextBox.Text = "";
            this.CBARRASTextBox.Text = "";
            this.PLUGTextBox.Text = "";

            this.INI_MAYOTextBox.Text = "";


            this.DESCRIPCION_COMODINTextBox.Checked = false;

            this.CUENTAPREDIALTextBox.Text = "";

            this.SPRECIO1TextBox.Text = "";


            this.SPRECIO2TextBox.Text = "";


            this.SPRECIO3TextBox.Text = "";


            this.SPRECIO4TextBox.Text = "";


            this.SPRECIO5TextBox.Text = "";

            this.DESCUENTOTextBox.Text = "";


            this.REQUIERERECETATextBox.Checked = false;

            this.PRECIOTOPETextBox.Text = "";

            this.MANEJALOTEIMPORTADOTextBox.Checked = false;

            this.COSTOENDOLARTextBox.Text = "";

            this.txtPlazoFB.Text = "";


            this.DESCTOPETextBox.Text = "";
            this.MARGENTextBox.Text = "";
            this.DESCPESTextBox.Text = "";



            this.PORCUTILPRECIO1TextBox.Text = "";


            this.PORCUTILPRECIO2TextBox.Text = "";


            this.PORCUTILPRECIO3TextBox.Text = "";


            this.PORCUTILPRECIO4TextBox.Text = "";


            this.PORCUTILPRECIO5TextBox.Text = "";

            this.IMPRIMIRCOMANDATextBox.Checked = false;

            this.ESPELIGROSOTextBox.Checked = false;

            this.ESOFERTATextBox.Checked = false;

            this.PESOTextBox.Text = "";


        }




        //private void button2_Click(object sender, EventArgs e)
        //{

        //    ShowLookUp();
        //}

        //private void ShowLookUp()
        //{

        //    GeneralLookUp look = new GeneralLookUp("select * from PRODUCTO", "PRODUCTO");
        //    look.ShowDialog();
        //    DataRow dr = look.m_rtnDataRow;

        //    if (dr != null)
        //    {

        //        this.IDTextBox.Text = dr[0].ToString();


        //    }

        //    look.Dispose();
        //    SetMode();

        //}


        //private void IDTextBox_KeyDown(object sender, KeyEventArgs e)
        //{

        //    if (e.KeyCode == Keys.F5)
        //    {
        //        ShowLookUp();
        //    }
        //}






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


        private void btEliminar_Click(object sender, EventArgs e)
        {
            this.opc = "Borrar";
            SaveChanges();
        }


        public void Resetear() // new for generator
        {
            HabilitarValidadores(false); // new generator
            Limpiar(true);
            this.opc = "";


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
                        if (

                        v.ControlToValidate.Name != "IDTextBox"
                        )
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
                    MessageBox.Show("No existe una marca con esa clave");
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

        private void LlenarProductosHijo(long productoPadreId)
        {
            try
            {
                this.pRODUCTOSHIJOTableAdapter.Fill(this.dSCatalogos.PRODUCTOSHIJO, productoPadreId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void BtnAddSubproduct_Click(object sender, EventArgs e)
        {

            m_bChangeImage_SUB = false;
            m_imageExtension_SUB = "";
            pictureBox2.Image = null;
            SUB_NuevaImagenTextBox.Text = "";

            this.m_subProduct_opc = "Agregar";
            this.pnlEdicionSubProducto.Enabled = true;
            this.BtnAddSubproduct.Enabled = false;
            LimpiarSubProductoFields();
            LlenarPreciosPadre();
            LlenarOfertaPadre();
            LlenarComisionPadre();


        }

        private void LlenarPreciosPadre()
        {
            if (this.m_producto != null)
            {
                CPRODUCTOBE productoBE = this.m_producto;

                if (!(bool)productoBE.isnull["IPRECIO1"])
                    this.SUB_PRECIO1TextBox.Text = productoBE.IPRECIO1.ToString();


                if (!(bool)productoBE.isnull["IPRECIO2"])
                    this.SUB_PRECIO2TextBox.Text = productoBE.IPRECIO2.ToString();


                if (!(bool)productoBE.isnull["IPRECIO3"])
                    this.SUB_PRECIO3TextBox.Text = productoBE.IPRECIO3.ToString();


                if (!(bool)productoBE.isnull["IPRECIO4"])
                    this.SUB_PRECIO4TextBox.Text = productoBE.IPRECIO4.ToString();


                if (!(bool)productoBE.isnull["IPRECIO5"])
                    this.SUB_PRECIO5TextBox.Text = productoBE.IPRECIO5.ToString();



                if (!(bool)productoBE.isnull["ILIMITEPRECIO2"])
                    this.SUB_LIMITEPRECIO2TextBox.Text = productoBE.ILIMITEPRECIO2.ToString();


                if (!(bool)productoBE.isnull["IPRECIOMAXIMOPUBLICO"])
                    this.SUB_PRECIOMAXIMOPUBLICOTextBox.Text = productoBE.IPRECIOMAXIMOPUBLICO.ToString();

            }
        }

        private void LlenarOfertaPadre()
        {

            if (this.m_producto != null)
            {
                CPRODUCTOBE productoBE = this.m_producto;


                if (!(bool)productoBE.isnull["IOFERTA"])
                    this.SUB_OFERTATextBox.Text = productoBE.IOFERTA.ToString();
            }
        }
        private void LlenarComisionPadre()
        {

            if (this.m_producto != null)
            {
                CPRODUCTOBE productoBE = this.m_producto;


                if (!(bool)productoBE.isnull["ICOMISION"])
                    this.SUB_COMISIONTextBox.Text = productoBE.ICOMISION.ToString();

            }
        }

        private void SUB_AutoGenerarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SUB_AutoGenerarCheckBox.Checked)
                SUB_CLAVETextBox.Enabled = false;
            else
                SUB_CLAVETextBox.Enabled = true;

        }

        private void SUB_COMISIONCHECKBOX_CheckedChanged(object sender, EventArgs e)
        {

            if (SUB_COMISIONCHECKBOX.Checked)
                SUB_COMISIONTextBox.Enabled = false;
            else
                SUB_COMISIONTextBox.Enabled = true;
        }

        private void SUB_OFERTACheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (SUB_OFERTACheckBox.Checked)
                SUB_OFERTATextBox.Enabled = false;
            else
                SUB_OFERTATextBox.Enabled = true;
        }

        private void SUB_PRECIOSCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (SUB_PRECIOSCheckBox.Checked)
                pnlPreciosSubproducto.Enabled = false;
            else
                pnlPreciosSubproducto.Enabled = true;
        }





        private CPRODUCTOBE ObtenerDatosSubProductoCapturados(CPRODUCTOBE PRODUCTOBE)
        {



            PRODUCTOBE.IPRODUCTOPADRE = PRODUCTOBE.IID;
            PRODUCTOBE.IID = 0;

            PRODUCTOBE.IACTIVO = "S";



            if (this.SUB_CLAVETextBox.Text != "" && !this.SUB_AutoGenerarCheckBox.Checked)
            {
                PRODUCTOBE.ICLAVE = this.SUB_CLAVETextBox.Text;
            }
            else
            {
                PRODUCTOBE.ICLAVE = "";
            }

            if (this.SUB_EANTextBox.Text != "")
            {
                PRODUCTOBE.IEAN = this.SUB_EANTextBox.Text.ToString();
            }

            if (this.SUB_DESCRIPCION2TextBox.Text != "")
            {
                PRODUCTOBE.IDESCRIPCION2 = this.SUB_DESCRIPCION2TextBox.Text.ToString();
            }


            if (!this.SUB_PRECIOSCheckBox.Checked)
            {

                if (this.SUB_PRECIO1TextBox.Text != "")
                {
                    PRODUCTOBE.IPRECIO1 = decimal.Parse(this.SUB_PRECIO1TextBox.Text.ToString());
                }


                if (this.SUB_PRECIO2TextBox.Text != "")
                {
                    PRODUCTOBE.IPRECIO2 = decimal.Parse(this.SUB_PRECIO2TextBox.Text.ToString());
                }


                if (this.SUB_PRECIO3TextBox.Text != "")
                {
                    PRODUCTOBE.IPRECIO3 = decimal.Parse(this.SUB_PRECIO3TextBox.Text.ToString());
                }


                if (this.SUB_PRECIO4TextBox.Text != "")
                {
                    PRODUCTOBE.IPRECIO4 = decimal.Parse(this.SUB_PRECIO4TextBox.Text.ToString());
                }


                if (this.SUB_PRECIO5TextBox.Text != "")
                {
                    PRODUCTOBE.IPRECIO5 = decimal.Parse(this.SUB_PRECIO5TextBox.Text.ToString());
                }
            }




            if (!this.SUB_COMISIONCHECKBOX.Checked)
            {

                if (this.SUB_COMISIONTextBox.Text != "")
                {
                    PRODUCTOBE.ICOMISION = decimal.Parse(this.SUB_COMISIONTextBox.Text.ToString());
                }
            }


            if (!this.SUB_OFERTACheckBox.Checked)
            {

                if (this.SUB_OFERTATextBox.Text != "")
                {
                    PRODUCTOBE.IOFERTA = decimal.Parse(this.SUB_OFERTATextBox.Text.ToString());
                }
            }


            if (this.SUB_TEXTO1TextBox.Text != "")
            {
                PRODUCTOBE.ITEXTO1 = this.SUB_TEXTO1TextBox.Text.ToString();
            }

            if (this.SUB_TEXTO2TextBox.Text != "")
            {
                PRODUCTOBE.ITEXTO2 = this.SUB_TEXTO2TextBox.Text.ToString();
            }

            if (this.SUB_TEXTO3TextBox.Text != "")
            {
                PRODUCTOBE.ITEXTO3 = this.SUB_TEXTO3TextBox.Text.ToString();
            }

            if (this.SUB_TEXTO4TextBox.Text != "")
            {
                PRODUCTOBE.ITEXTO4 = this.SUB_TEXTO4TextBox.Text.ToString();
            }

            if (this.SUB_TEXTO5TextBox.Text != "")
            {
                PRODUCTOBE.ITEXTO5 = this.SUB_TEXTO5TextBox.Text.ToString();
            }

            if (this.SUB_TEXTO6TextBox.Text != "")
            {
                PRODUCTOBE.ITEXTO6 = this.SUB_TEXTO6TextBox.Text.ToString();
            }


            if (this.SUB_NUMERO1TextBox.Text != "")
            {
                PRODUCTOBE.INUMERO1 = decimal.Parse(this.SUB_NUMERO1TextBox.Text.ToString());
            }
            if (this.SUB_NUMERO2TextBox.Text != "")
            {
                PRODUCTOBE.INUMERO2 = decimal.Parse(this.SUB_NUMERO2TextBox.Text.ToString());
            }
            if (this.SUB_NUMERO3TextBox.Text != "")
            {
                PRODUCTOBE.INUMERO3 = decimal.Parse(this.SUB_NUMERO3TextBox.Text.ToString());
            }
            if (this.SUB_NUMERO4TextBox.Text != "")
            {
                PRODUCTOBE.INUMERO4 = decimal.Parse(this.SUB_NUMERO4TextBox.Text.ToString());
            }


            if (this.SUB_FECHA1TextBox.Text != "")
            {
                PRODUCTOBE.IFECHA1 = this.SUB_FECHA1TextBox.Value;
            }


            if (this.SUB_FECHA2TextBox.Text != "")
            {
                PRODUCTOBE.IFECHA2 = this.SUB_FECHA2TextBox.Value;
            }


            PRODUCTOBE.ITOMARCOMISIONPADRE = (this.SUB_COMISIONCHECKBOX.Checked) ? "S" : "N";

            PRODUCTOBE.ITOMAROFERTAPADRE = (this.SUB_OFERTACheckBox.Checked) ? "S" : "N";

            PRODUCTOBE.ITOMARPRECIOPADRE = (this.SUB_PRECIOSCheckBox.Checked) ? "S" : "N";

            PRODUCTOBE.ISAT_PRODUCTOSERVICIOID = Int32.Parse(this.productoSatTextBoxFb.DbValue.ToString());


            /*if (m_bChangeImage_SUB)
            {
                if (pictureBox2.Image != null)
                    PRODUCTOBE.IIMAGEN = PRODUCTOBE.ICLAVE + "___1." + Path.GetExtension(SUB_NuevaImagenTextBox.Text);
                else
                    PRODUCTOBE.IIMAGEN = "";
            }*/



            return PRODUCTOBE;

        }

        private void SaveSubProductChanges()
        {

            try
            {
                CPRODUCTOD PRODUCTOD = new CPRODUCTOD();

                if (this.m_subProduct_opc == "Agregar")
                {

                    CPRODUCTOBE PRODUCTOBE = new CPRODUCTOBE();
                    PRODUCTOBE.ICLAVE = CLAVE;
                    PRODUCTOBE = PRODUCTOD.seleccionarPRODUCTOxCLAVE(PRODUCTOBE, null);

                    PRODUCTOBE = ObtenerDatosSubProductoCapturados(PRODUCTOBE);
                    PRODUCTOBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;
                    PRODUCTOBE.ICREADO = DateTime.Now;

                    PRODUCTOD.AgregarPRODUCTO(PRODUCTOBE, null);

                    if (PRODUCTOD.IComentario == "" || PRODUCTOD.IComentario == null)
                    {

                        if (m_bChangeImage_SUB)
                        {

                            CPRODUCTOBE PRODUCTOBE_AUX = new CPRODUCTOBE();
                            PRODUCTOBE_AUX.IID = PRODUCTOBE.IID;
                            PRODUCTOBE_AUX = PRODUCTOD.seleccionarPRODUCTO(PRODUCTOBE_AUX, null);
                            if (pictureBox2.Image != null)
                            {
                                PRODUCTOBE_AUX.IIMAGEN = PRODUCTOBE_AUX.ICLAVE + "___1." + Path.GetExtension(SUB_NuevaImagenTextBox.Text);
                            }
                            else
                            {
                                PRODUCTOBE_AUX.IIMAGEN = "";
                            }
                            PRODUCTOD.CambiarImagenPRODUCTO(PRODUCTOBE_AUX, null);

                            string imagePath = CurrentUserID.CurrentParameters.IRUTAIMAGENESPRODUCTO + "\\" + PRODUCTOBE_AUX.IIMAGEN;
                            if (File.Exists(imagePath))
                                File.Delete(imagePath);

                            if (pictureBox2.Image != null)
                            {
                                pictureBox2.Image.Save(imagePath);
                            }
                            m_bChangeImage_SUB = false;
                        }


                        MessageBox.Show("El registro se ha insertado");
                        this.LlenarProductosHijo(this.ID);
                        this.pnlEdicionSubProducto.Enabled = false;
                        this.m_subProduct_Id = 0;
                        this.BtnAddSubproduct.Enabled = true;
                        LimpiarSubProductoFields();

                    }
                    else
                        MessageBox.Show("ERRORES: " + PRODUCTOD.IComentario.Replace("%", "\n"));



                }
                else if (opc == "Cambiar")
                {


                    CPRODUCTOBE PRODUCTOBEAnt = new CPRODUCTOBE();

                    CPRODUCTOBE PRODUCTOBE = new CPRODUCTOBE();
                    PRODUCTOBE.IID = this.m_subProduct_Id;
                    PRODUCTOBE = PRODUCTOD.seleccionarPRODUCTO(PRODUCTOBE, null);



                    PRODUCTOBE = ObtenerDatosSubProductoCapturados(PRODUCTOBE);
                    PRODUCTOBEAnt.IID = this.m_subProduct_Id;

                    PRODUCTOBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;
                    PRODUCTOBE.IMODIFICADO = DateTime.Now;

                    PRODUCTOD.CambiarPRODUCTO(PRODUCTOBE, PRODUCTOBEAnt, null);
                    if (PRODUCTOD.IComentario == "" || PRODUCTOD.IComentario == null)
                    {


                        if (m_bChangeImage_SUB)
                        {

                            CPRODUCTOBE PRODUCTOBE_AUX = new CPRODUCTOBE();
                            PRODUCTOBE_AUX.IID = PRODUCTOBEAnt.IID;
                            PRODUCTOBE_AUX = PRODUCTOD.seleccionarPRODUCTO(PRODUCTOBE_AUX, null);
                            if (pictureBox2.Image != null)
                            {
                                PRODUCTOBE_AUX.IIMAGEN = PRODUCTOBE_AUX.ICLAVE + "___1." + Path.GetExtension(SUB_NuevaImagenTextBox.Text);
                            }
                            else
                            {
                                PRODUCTOBE_AUX.IIMAGEN = "";
                            }
                            PRODUCTOD.CambiarImagenPRODUCTO(PRODUCTOBE_AUX, null);

                            string imagePath = CurrentUserID.CurrentParameters.IRUTAIMAGENESPRODUCTO + "\\" + PRODUCTOBE_AUX.IIMAGEN;
                            if (File.Exists(imagePath))
                                File.Delete(imagePath);

                            if (pictureBox2.Image != null)
                            {
                                pictureBox2.Image.Save(imagePath);
                            }
                            m_bChangeImage_SUB = false;
                        }


                        MessageBox.Show("El registro se ha cambiado");
                        this.LlenarProductosHijo(this.ID);
                        this.pnlEdicionSubProducto.Enabled = false;
                        this.m_subProduct_Id = 0;
                        this.BtnAddSubproduct.Enabled = true;
                        LimpiarSubProductoFields();

                    }
                    else
                        MessageBox.Show("ERRORES: " + PRODUCTOD.IComentario.Replace("%", "\n"));


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error Asegurese de que metio los datos en el formato correcto " + ex.Message);
            }

        }

        private void BtnGuardarSubproducto_Click(object sender, EventArgs e)
        {
            SaveSubProductChanges();
        }

        private void pRODUCTOSHIJODataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pRODUCTOSHIJODataGridView.Columns[e.ColumnIndex].Name == "DGEditar")
            {
                EditarProducto();
            }
        }


        private void EditarProducto()
        {
            try
            {

                m_bChangeImage_SUB = false;
                m_imageExtension_SUB = "";
                pictureBox2.Image = null;
                SUB_NuevaImagenTextBox.Text = "";

                int iRetornoRowIndex = pRODUCTOSHIJODataGridView.CurrentRow.Index;
                this.m_subProduct_Id = long.Parse(pRODUCTOSHIJODataGridView.Rows[iRetornoRowIndex].Cells["DGID"].Value.ToString());
                this.pnlEdicionSubProducto.Enabled = true;
                LlenarDatosSubProductoDeBase();
                this.m_subProduct_opc = "Cambiar";
                this.BtnAddSubproduct.Enabled = false;



            }
            catch
            {
            }
        }


        private void LimpiarSubProductoFields()
        {



            this.SUB_CLAVETextBox.Text = "";
            this.SUB_DESCRIPCION2TextBox.Text = "";

            this.SUB_EANTextBox.Text = "";

            this.SUB_PRECIO1TextBox.Text = "";
            this.SUB_PRECIO2TextBox.Text = "";
            this.SUB_PRECIO3TextBox.Text = "";
            this.SUB_PRECIO4TextBox.Text = "";
            this.SUB_PRECIO5TextBox.Text = "";
            this.SUB_LIMITEPRECIO2TextBox.Text = "";
            this.SUB_PRECIOMAXIMOPUBLICOTextBox.Text = "";
            this.SUB_COMISIONTextBox.Text = "";
            this.SUB_OFERTATextBox.Text = "";
            this.SUB_TEXTO1TextBox.Text = "";
            this.SUB_TEXTO2TextBox.Text = "";
            this.SUB_TEXTO3TextBox.Text = "";
            this.SUB_TEXTO4TextBox.Text = "";
            this.SUB_TEXTO5TextBox.Text = "";
            this.SUB_TEXTO6TextBox.Text = "";
            this.SUB_NUMERO1TextBox.Text = "";
            this.SUB_NUMERO2TextBox.Text = "";
            this.SUB_NUMERO3TextBox.Text = "";
            this.SUB_NUMERO4TextBox.Text = "";

            this.SUB_FECHA1TextBox.Value = DateTime.Today;
            this.SUB_FECHA2TextBox.Value = DateTime.Today;

            this.SUB_COMISIONCHECKBOX.Checked = true;
            this.SUB_OFERTACheckBox.Checked = true;
            this.SUB_PRECIOSCheckBox.Checked = true;

            pnlPreciosSubproducto.Enabled = false;
            this.SUB_COMISIONTextBox.Enabled = false;
            this.SUB_OFERTATextBox.Enabled = false;
        }



        private bool LlenarDatosSubProductoDeBase()
        {
            //string strBuffer = "";
            m_bChangeImage_SUB = false;
            try
            {

                CPRODUCTOD productoD = new CPRODUCTOD();
                CPRODUCTOBE productoBE = new CPRODUCTOBE();
                productoBE.IID = this.m_subProduct_Id;
                productoBE = productoD.seleccionarPRODUCTO(productoBE, null);


                if (productoBE == null)
                    return false;




                if (!(bool)productoBE.isnull["ICLAVE"])
                    this.SUB_CLAVETextBox.Text = productoBE.ICLAVE.ToString();


                if (!(bool)productoBE.isnull["IDESCRIPCION2"])
                    this.SUB_DESCRIPCION2TextBox.Text = productoBE.IDESCRIPCION2.ToString();


                if (!(bool)productoBE.isnull["IEAN"])
                    this.SUB_EANTextBox.Text = productoBE.IEAN.ToString();

                if (!(bool)productoBE.isnull["IPRECIO1"])
                    this.SUB_PRECIO1TextBox.Text = productoBE.IPRECIO1.ToString();


                if (!(bool)productoBE.isnull["IPRECIO2"])
                    this.SUB_PRECIO2TextBox.Text = productoBE.IPRECIO2.ToString();


                if (!(bool)productoBE.isnull["IPRECIO3"])
                    this.SUB_PRECIO3TextBox.Text = productoBE.IPRECIO3.ToString();


                if (!(bool)productoBE.isnull["IPRECIO4"])
                    this.SUB_PRECIO4TextBox.Text = productoBE.IPRECIO4.ToString();


                if (!(bool)productoBE.isnull["IPRECIO5"])
                    this.SUB_PRECIO5TextBox.Text = productoBE.IPRECIO5.ToString();



                if (!(bool)productoBE.isnull["ILIMITEPRECIO2"])
                    this.SUB_LIMITEPRECIO2TextBox.Text = productoBE.ILIMITEPRECIO2.ToString();


                if (!(bool)productoBE.isnull["IPRECIOMAXIMOPUBLICO"])
                    this.SUB_PRECIOMAXIMOPUBLICOTextBox.Text = productoBE.IPRECIOMAXIMOPUBLICO.ToString();





                if (!(bool)productoBE.isnull["ICOMISION"])
                    this.SUB_COMISIONTextBox.Text = productoBE.ICOMISION.ToString();


                if (!(bool)productoBE.isnull["IOFERTA"])
                    this.SUB_OFERTATextBox.Text = productoBE.IOFERTA.ToString();


                if (!(bool)productoBE.isnull["ITEXTO1"])
                    this.SUB_TEXTO1TextBox.Text = productoBE.ITEXTO1.ToString();

                if (!(bool)productoBE.isnull["ITEXTO2"])
                    this.SUB_TEXTO2TextBox.Text = productoBE.ITEXTO2.ToString();

                if (!(bool)productoBE.isnull["ITEXTO3"])
                    this.SUB_TEXTO3TextBox.Text = productoBE.ITEXTO3.ToString();

                if (!(bool)productoBE.isnull["ITEXTO4"])
                    this.SUB_TEXTO4TextBox.Text = productoBE.ITEXTO4.ToString();

                if (!(bool)productoBE.isnull["ITEXTO5"])
                    this.SUB_TEXTO5TextBox.Text = productoBE.ITEXTO5.ToString();

                if (!(bool)productoBE.isnull["ITEXTO6"])
                    this.SUB_TEXTO6TextBox.Text = productoBE.ITEXTO6.ToString();


                if (!(bool)productoBE.isnull["INUMERO1"])
                    this.SUB_NUMERO1TextBox.Text = productoBE.INUMERO1.ToString();

                if (!(bool)productoBE.isnull["INUMERO2"])
                    this.SUB_NUMERO2TextBox.Text = productoBE.INUMERO2.ToString();

                if (!(bool)productoBE.isnull["INUMERO3"])
                    this.SUB_NUMERO3TextBox.Text = productoBE.INUMERO3.ToString();

                if (!(bool)productoBE.isnull["INUMERO4"])
                    this.SUB_NUMERO4TextBox.Text = productoBE.INUMERO4.ToString();


                try
                {
                    this.SUB_FECHA1TextBox.Value = productoBE.IFECHA1;
                }
                catch
                {
                }

                try
                {
                    this.SUB_FECHA2TextBox.Value = productoBE.IFECHA2;
                }
                catch
                {
                }



                if (!(bool)productoBE.isnull["ITOMARCOMISIONPADRE"])
                    this.SUB_COMISIONCHECKBOX.Checked = (productoBE.ITOMARCOMISIONPADRE == "S") ? true : false;

                if (!(bool)productoBE.isnull["ITOMAROFERTAPADRE"])
                    this.SUB_OFERTACheckBox.Checked = (productoBE.ITOMAROFERTAPADRE == "S") ? true : false;

                if (!(bool)productoBE.isnull["ITOMARPRECIOPADRE"])
                    this.SUB_PRECIOSCheckBox.Checked = (productoBE.ITOMARPRECIOPADRE == "S") ? true : false;


                if (!(bool)productoBE.isnull["IIMAGEN"])
                {
                    this.SUB_IMAGENTextBox.Text = productoBE.IIMAGEN.ToString();

                    string imagePath = CurrentUserID.CurrentParameters.IRUTAIMAGENESPRODUCTO + "\\" + productoBE.IIMAGEN;
                    try
                    {
                        if (productoBE.IIMAGEN.ToString() != "")
                        {

                            pictureBox2.Image = Image.FromFile(imagePath);
                        }
                    }
                    catch
                    {
                    }
                }

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


        private void EliminarSubProducto()
        {
            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE productoBE = new CPRODUCTOBE();
            productoBE.IID = this.m_subProduct_Id;


            if (productoD.BorrarDesactivarPRODUCTOD(productoBE, null))
            {

                MessageBox.Show("El registro se ha eliminado/desactivado");
                this.LlenarProductosHijo(this.ID);
                this.pnlEdicionSubProducto.Enabled = false;
                this.m_subProduct_Id = 0;
                this.BtnAddSubproduct.Enabled = true;
                LimpiarSubProductoFields();

            }
            else
                MessageBox.Show("ERRORES: " + productoD.IComentario.Replace("%", "\n"));


        }

        private void BtnDesactivarSubproducto_Click(object sender, EventArgs e)
        {
            EliminarSubProducto();
        }

        private void MANEJALOTETextBox_Enter(object sender, EventArgs e)
        {
            this.MANEJALOTETextBox.BackColor = Color.Black;
        }

        private void mANEJALOTELabel_Leave(object sender, EventArgs e)
        {
            this.MANEJALOTETextBox.BackColor = Color.Transparent;
        }



        private void UNIDADTextBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.UNIDADTextBox.Text.ToString().Trim() == "KG")
            {
                this.INI_MAYOTextBox.Visible = true;
                this.PLUGTextBox.Visible = true;
                this.MAYOKGSTextBox.Visible = true;
                this.INI_MAYOLabel.Visible = true;
                this.PLUGLabel.Visible = true;
                this.MAYOKGSLabel.Visible = true;
            }
            else
            {
                this.INI_MAYOTextBox.Visible = false;
                this.PLUGTextBox.Visible = false;
                this.MAYOKGSTextBox.Visible = false;
                this.INI_MAYOLabel.Visible = false;
                this.PLUGLabel.Visible = false;
                this.MAYOKGSLabel.Visible = false;
                this.PLUGTextBox.Text = "";
            }
        }

        private bool ValidarDatos(CPRODUCTOBE prodBE)
        {
            decimal precio1 = 0, precio2 = 0, precio3 = 0;
            decimal precio4 = 0, precio5 = 0, costoreposicion = 0;

            if (!(bool)prodBE.isnull["IPRECIO1"])
                precio1 = prodBE.IPRECIO1;
            if (!(bool)prodBE.isnull["IPRECIO2"])
                precio2 = prodBE.IPRECIO2;
            if (!(bool)prodBE.isnull["IPRECIO3"])
                precio3 = prodBE.IPRECIO3;
            if (!(bool)prodBE.isnull["IPRECIO4"])
                precio4 = prodBE.IPRECIO4;
            if (!(bool)prodBE.isnull["IPRECIO5"])
                precio5 = prodBE.IPRECIO5;
            if (!(bool)prodBE.isnull["ICOSTOREPOSICION"])
                costoreposicion = prodBE.ICOSTOREPOSICION;

            if ((CurrentUserID.CurrentParameters.IPRECIOSORDENADOS == null || CurrentUserID.CurrentParameters.IPRECIOSORDENADOS == "S") &&
                (precio1 < precio2 || precio2 < precio3 || precio3 < precio4 || precio4 < precio5 || precio5 < costoreposicion))
            {
                MessageBox.Show("Asegurese de que precio1 sea mayor o igual que precio2 , precio 2 sea mayor o igual que precio 3 y asi sucesivamente y que precio5 sea mayor o igual que costo reposicion. ");
                return false;
            }



            return true;
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

                return;
            }



            if (e.Cancel == false && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS != null && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS.Equals("S"))
            {
                this.AjustaUtilidadxPrecio1();
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
                return;
            }

            if (e.Cancel == false && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS != null && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS.Equals("S"))
            {
                this.AjustaUtilidadxPrecio2();
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
                return;
            }


            if (e.Cancel == false && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS != null && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS.Equals("S"))
            {
                this.AjustaUtilidadxPrecio3();
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
                return;
            }


            if (e.Cancel == false && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS != null && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS.Equals("S"))
            {
                this.AjustaUtilidadxPrecio4();
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
                return;
            }


            if (e.Cancel == false && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS != null && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS.Equals("S"))
            {
                this.AjustaUtilidadxPrecio5();
            }
        }

        private void COSTOREPOSICIONTextBox_Validating(object sender, CancelEventArgs e)
        {
            decimal precio5 = 0;
            decimal costoreposicion = 0;


            if (this.PRECIO5TextBox.Text != "")
            {
                precio5 = decimal.Parse(this.PRECIO5TextBox.Text.ToString());
            }


            if (this.COSTOREPOSICIONTextBox.Text != "")
            {
                costoreposicion = decimal.Parse(this.COSTOREPOSICIONTextBox.Text.ToString());
            }


            if (precio5 < costoreposicion)
            {
                MessageBox.Show("Asegurese de que el precio 5 sea mayor o igual que el costo reposicion. ");
                e.Cancel = true;
                return;
            }


            if (CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS != null && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS.Equals("S"))
            {

                if( MessageBox.Show("Desea mantener los precios actuales y recalcular la utilidad?","Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes )
                {

                    this.AjustaUtilidadxPrecios();
                }
                else
                {

                    this.AjustaPreciosxUtilidad();
                }
            }



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

        private void SUB_btnImageSelector_Click(object sender, EventArgs e)
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
                SUB_NuevaImagenTextBox.Text = openFileDialog1.FileName;

                try
                {
                    pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);

                    if (pictureBox2.Image != null)
                    {
                        m_bChangeImage_SUB = true;
                        this.m_imageExtension_SUB = Path.GetExtension(openFileDialog1.FileName);
                    }
                }
                catch
                {
                }

            }
        }

        private void SUB_btnEliminarImagen_Click(object sender, EventArgs e)
        {

            m_bChangeImage_SUB = true;
            pictureBox2.Image = null;
        }

        private void CalcularImpuesto()
        {
            decimal iva = 0, ieps = 0, impuesto = 0;

            try
            {
                if (this.TASAIVATextBox.Text != "")
                {
                    iva = decimal.Parse(this.TASAIVATextBox.Text.ToString());
                }
            }
            catch
            {
            }


            try
            {
                if (this.TASAIEPSTextBox.Text != "" && CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S"))
                {
                    ieps = decimal.Parse(this.TASAIEPSTextBox.Text.ToString());
                }
            }
            catch
            {
            }


            impuesto = iva + ieps + ((ieps * iva) / 100);


            this.TASAIMPUESTOTextBox.Text = impuesto.ToString();

        }

        private void TASAIEPSTextBox_Validated(object sender, EventArgs e)
        {
            CalcularImpuesto();
        }

        private void TASAIVAIDTextBox_Validated(object sender, EventArgs e)
        {
            CalcularImpuesto();
        }

        private void LlenarKitInfo()
        {
            try
            {
                if (this.m_producto == null)
                {
                    this.dSCatalogos.KITDEFINICION.Clear();
                    return;
                }


                this.kITDEFINICIONTableAdapter.Fill(this.dSCatalogos.KITDEFINICION, (int)this.m_producto.IID);
                LlenarKitProrrateos();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }



        }


        private void LlenarKitProrrateos()
        {
            CKITDEFINICIOND kitD = new CKITDEFINICIOND();
            decimal totalProrrateoSumado = kitD.getSumaCostosPartes(m_producto.IID, null);

            foreach (DataGridViewRow row in kITDEFINICIONDataGridView.Rows)
            {

                if (row.Index == kITDEFINICIONDataGridView.NewRowIndex)
                    continue;

                decimal costoProductoParte = decimal.Parse(row.Cells["DGCOSTOTOTALCONIMPUESTO"].Value.ToString());

                if (totalProrrateoSumado == 0)
                    row.Cells["DGPRORRATEO"].Value = 0;
                else
                    row.Cells["DGPRORRATEO"].Value = Math.Round(((costoProductoParte / totalProrrateoSumado) * 100), 2);
            }

        }




        private void btnAddKit_Click(object sender, EventArgs e)
        {

            try
            {

                if (this.m_producto == null || this.m_producto.IID == 0)
                {
                    MessageBox.Show("Debe de estar guardado ya el producto para asignar kit");
                    return;
                }
                if (this.m_producto.IESKIT == null || this.m_producto.IESKIT != "S")
                {
                    MessageBox.Show("El producto debe tener habilitado el kit");
                    return;
                }

                if (this.TBCodigoProductoParte.Text == "")
                {
                    MessageBox.Show("No ingreso un producto valido");
                    return;
                }




                CKITDEFINICIONBE kitBE = new CKITDEFINICIONBE();
                CKITDEFINICIOND kitD = new CKITDEFINICIOND();

                kitBE.IPRODUCTOKITID = this.m_producto.IID;

                CPRODUCTOBE prodKit = new CPRODUCTOBE();
                CPRODUCTOD prodD = new CPRODUCTOD();
                prodKit.IID = this.m_producto.IID;
                prodKit = prodD.seleccionarPRODUCTO(prodKit, null);

                if ((/*prodKit.IENPROCESOPARTESSALIDA != null &&*/ prodKit.IENPROCESOPARTESSALIDA > 0) ||
                   (/*prodKit.IENPROCESODESALIDA != null &&*/ prodKit.IENPROCESODESALIDA > 0))
                {

                    MessageBox.Show("Hay ventas o documentos de salida en estatus de borrador con el productokit, por favor eliminelos o completelos antes de modificar el kit ");
                    return;
                }




                CPRODUCTOBE prodParte = new CPRODUCTOBE();
                if (!BuscarProducto(ref prodParte))
                {

                    MessageBox.Show("El producto no existe");
                    return;
                }

                m_productoParte = prodParte;

                if (m_productoParte != null)
                {
                    kitBE.IPRODUCTOPARTEID = m_productoParte.IID;
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado un producto valido");
                    return;
                }


                kitBE.IACTIVO = "S";

                if (this.CANTIDADPARTETextBox.Text != "")
                {
                    kitBE.ICANTIDADPARTE = decimal.Parse(this.CANTIDADPARTETextBox.Text.ToString());
                }
                else
                {
                    MessageBox.Show("No ingreso una cantidad valida");
                    return;

                }


                if (this.COSTOPARTETextBox.Text != "")
                {
                    kitBE.ICOSTOPARTE = decimal.Parse(this.COSTOPARTETextBox.Text.ToString());
                }



                if (kitBE.IPRODUCTOPARTEID == this.m_producto.IID)
                {

                    MessageBox.Show("No puede ser el mismo producto parte del kit");
                    return;
                }

                CPRODUCTOBE prodBE = new CPRODUCTOBE();
                prodBE.IID = kitBE.IPRODUCTOPARTEID;
                prodBE = prodD.seleccionarPRODUCTO(prodBE, null);

                if (prodBE == null)
                {
                    MessageBox.Show("No es un producto valido");
                    return;
                }
                if (prodBE.IESKIT == null)
                {
                    MessageBox.Show("El producto parte no puede ser otro kit");
                    return;
                }
                if (prodBE.IMANEJALOTE != null && prodBE.IMANEJALOTE == "S")
                {
                    MessageBox.Show("El producto parte no puede manejar lote");
                    return;
                }

                kitBE.IPRODUCTOKITCLAVE = this.m_producto.ICLAVE;
                kitBE.IPRODUCTOPARTECLAVE = prodBE.ICLAVE;



                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;
                try
                {

                    fConn.Open();
                    fTrans = fConn.BeginTransaction();

                    kitBE = kitD.AgregarKITDEFINICIOND(kitBE, fTrans);
                    if (kitBE == null)
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("Hubo un error al insertar el producto al kit " + kitD.IComentario);
                        return;
                    }


                    fTrans.Commit();
                    fConn.Close();


                }
                catch
                {
                    try
                    {
                        fTrans.Rollback();
                    }
                    catch
                    {

                    }
                    fConn.Close();
                }
                finally
                {
                    fConn.Close();
                }

                limpiarKitAddFields();


                LlenarKitInfo();
                putCalculatedValuesFromKit(true);
                this.habilitarCamposPorKit();
            }
            catch
            {

                MessageBox.Show("Hubo un error  ");
                return;
            }

        }

        private void limpiarKitAddFields()
        {
            CleanProductoParteDatos();

            COSTOPARTETextBox.Text = "0";
            CANTIDADPARTETextBox.Text = "0";

        }


        private void habilitarCamposPorKit()
        {


            if (this.m_producto == null || this.m_producto.IID == 0 ||
               this.m_producto.IESKIT == null || this.m_producto.IESKIT != "S" || 
               (this.m_producto.IKITIMPFIJO != null && this.m_producto.IKITIMPFIJO.Equals("S")))
            {
                this.TASAIVAIDTextBox.Enabled = true;
                this.TASAIVAButton.Enabled = true;
                this.TASAIEPSTextBox.Enabled = true;
            }
            else
            {

                this.TASAIVAIDTextBox.Enabled = false;
                this.TASAIVAButton.Enabled = false;
                this.TASAIEPSTextBox.Enabled = false;
            }
        }

        private void showHideKitTabPage()
        {

            this.tabControl1.TabPages.Remove(this.tabPageKit);

            if (this.m_producto == null || this.m_producto.IID == 0 ||
                this.m_producto.IESKIT == null || this.m_producto.IESKIT != "S")
                return;


            this.tabControl1.TabPages.Add(this.tabPageKit);

            if (this.m_producto.IEXISTENCIA > 0)
            {
                this.pnlKitEdicion.Enabled = false;
                this.kITDEFINICIONDataGridView.Columns["DGCANTIDADPARTE"].ReadOnly = true;
                this.kITDEFINICIONDataGridView.Columns["BTQuitarParte"].Visible = false;
            }
            else
            {
                this.pnlKitEdicion.Enabled = true;
                this.kITDEFINICIONDataGridView.Columns["DGCANTIDADPARTE"].ReadOnly = true;
                this.kITDEFINICIONDataGridView.Columns["BTQuitarParte"].Visible = true;

            }

        }


        private void showHideSucursalExportacion()
        {
            this.tabControl1.TabPages.Remove(this.tabPage6);

            if (this.m_producto == null || this.m_producto.IID == 0 ||
                this.m_producto.IESKIT == null || this.m_producto.IESKIT != "S" ||
                CurrentUserID.CurrentCompania.IESMATRIZ == null || CurrentUserID.CurrentCompania.IESMATRIZ != "S")
            {
                return;
            }

            this.tabControl1.TabPages.Add(this.tabPage6);
        }

        private void showHideTabPages()
        {

            showHideKitTabPage();
            showHideSucursalExportacion();



        }

        private void kITDEFINICIONDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (kITDEFINICIONDataGridView.Columns[e.ColumnIndex].Name == "BTQuitarParte")
            {

                try
                {


                    if (MessageBox.Show(" Esta seguro de que desea quitar este producto del kit ?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    int iRetornoRowIndex = kITDEFINICIONDataGridView.CurrentRow.Index;
                    long lKitId = Int64.Parse(kITDEFINICIONDataGridView.Rows[iRetornoRowIndex].Cells["DGKITID"].Value.ToString());


                    // CHECAR QUE EL KIT NO ESTE CON PROCESO DE SALIDA EN ALGUN DOCUMENTO
                    CPRODUCTOBE prodKit = new CPRODUCTOBE();
                    CPRODUCTOD prodD = new CPRODUCTOD();
                    prodKit.IID = this.m_producto.IID;
                    prodKit = prodD.seleccionarPRODUCTO(prodKit, null);

                    if ((/*prodKit.IENPROCESOPARTESSALIDA != null &&*/ prodKit.IENPROCESOPARTESSALIDA > 0) ||
                       (/*prodKit.IENPROCESODESALIDA != null &&*/ prodKit.IENPROCESODESALIDA > 0))
                    {

                        MessageBox.Show("Hay ventas o documentos de salida en estatus de borrador con el productokit, por favor eliminelos o completelos antes de modificar el kit ");
                        return;
                    }




                    FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                    FbTransaction fTrans = null;
                    try
                    {

                        fConn.Open();
                        fTrans = fConn.BeginTransaction();


                        CKITDEFINICIONBE kitBE = new CKITDEFINICIONBE();
                        CKITDEFINICIOND kitD = new CKITDEFINICIOND();
                        kitBE.IID = lKitId;

                        if (!kitD.BorrarKITDEFINICIOND(kitBE, fTrans))
                        {
                            fTrans.Rollback();
                            MessageBox.Show("Hubo un error al quitar el producto al kit " + kitD.IComentario);

                            return;
                        }


                        fTrans.Commit();

                        fConn.Close();




                    }
                    catch
                    {
                        fConn.Close();
                    }
                    finally
                    {
                        fConn.Close();
                    }

                    LlenarKitInfo();
                    putCalculatedValuesFromKit(true);
                    habilitarCamposPorKit();
                }
                catch
                {

                    MessageBox.Show("Hubo un error  ");
                    return;
                }

            }
        }


        private void putCalculatedValuesFromKit(bool bSobreEscribeCamposProd)
        {
            long tasaivaid = this.m_producto.ITASAIVAID;
            decimal tasaiva = this.m_producto.ITASAIVA;
            decimal tasaieps = this.m_producto.ITASAIEPS;
            decimal tasaimpuesto = this.m_producto.ITASAIMPUESTO;
            decimal sumasinimpuesto = 0;
            decimal sumaconimpuesto = 0;
            decimal sumaivaparte = 0;
            decimal sumaiepsparte = 0;

            CKITDEFINICIOND kitD = new CKITDEFINICIOND();


            if (!kitD.KIT_TOTALIZARIMPUESTOS(m_producto.IID, ref tasaivaid, ref  tasaiva, ref  tasaieps, ref  tasaimpuesto, ref sumasinimpuesto, ref  sumaconimpuesto, ref sumaivaparte, ref sumaiepsparte, null))
            {
                MessageBox.Show("Hubo un error al asigar los impuestos al producto " + kitD.IComentario);
                return;
            }

            if (bSobreEscribeCamposProd)
            {
                this.TASAIEPSTextBox.Text = tasaieps.ToString();
                this.TASAIMPUESTOTextBox.Text = tasaimpuesto.ToString();
                string strBuffer = "";
                this.TASAIVAIDTextBox.DbValue = tasaivaid.ToString();
                this.TASAIVAIDTextBox.MostrarErrores = false;
                this.TASAIVAIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.TASAIVAIDTextBox.MostrarErrores = true;
                this.m_producto.ITASAIVAID = tasaivaid;
                this.m_producto.ITASAIVA = tasaiva;
                this.m_producto.ITASAIEPS = tasaieps;
                this.m_producto.ITASAIMPUESTO = tasaimpuesto;
                this.TASAIVATextBox.Text = tasaiva.ToString();
            }


            this.kitIvaTextBoxPromedio.Text = tasaiva.ToString();
            this.kitIepsTextBoxPromedio.Text = tasaieps.ToString();
            this.kitSumaCostoTotalTextBox.Text = sumaconimpuesto.ToString();
            this.kitSumaIepsTextBox.Text = sumaiepsparte.ToString();
            this.kitSumaIvaTextBox.Text = sumaivaparte.ToString();
            this.kitCostoSinImpTextBox.Text = sumasinimpuesto.ToString();

        }


        private void validCodigoProductoParte()
        {

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                SeleccionarProducto(TBCodigoProductoParte.Text.Trim(),TBCodigoProductoParte);
                return;
            }

            m_productoParte = prod;
            LlenarProductoParteDatos();
        }


        private void CleanProductoParteDatos()
        {


            this.PRODUCTOPARTEDESCRIPCIONTextBox.Text = "";
            this.PRODUCTOPARTENOMBRETextBox.Text = "";
            this.PRODUCTOPARTECOSTOTextBox.Text = "0";
        }
        private void LlenarProductoParteDatos()
        {



            if (this.m_productoParte != null)
            {
                this.PRODUCTOPARTEDESCRIPCIONTextBox.Text = m_productoParte.IDESCRIPCION;
                this.PRODUCTOPARTENOMBRETextBox.Text = m_productoParte.INOMBRE;
                this.PRODUCTOPARTECOSTOTextBox.Text = m_productoParte.ICOSTOREPOSICION.ToString();
                this.COSTOPARTETextBox.Text = m_productoParte.ICOSTOREPOSICION.ToString();
            }
            else
            {
                CleanProductoParteDatos();
            }
        }


        //TBCodigoProductoParte
        private void SeleccionarProducto(string strDescripcion,  TextBox destinoTextBox)
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
                destinoTextBox.Text = dr["CLAVE"].ToString().Trim();
                destinoTextBox.Focus();
                destinoTextBox.Select(destinoTextBox.Text.Length, 0);
            }
        }

        private bool BuscarProducto(ref CPRODUCTOBE prod)
        {
            CComprasD pvd = new CComprasD();
            prod = pvd.buscarPRODUCTOSPV(TBCodigoProductoParte.Text.Trim(), CurrentUserID.CurrentParameters, null);
            if (prod != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void TBCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                validCodigoProductoParte();

                this.CANTIDADPARTETextBox.Focus();
                CANTIDADPARTETextBox.Select(0, CANTIDADPARTETextBox.Text.Length);
            }
        }

        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {

            if (TBCodigoProductoParte.Text.Trim() == "")
            {
                return;
            }

            validCodigoProductoParte();

        }

        private void btnAsignarCostoRepoPorKit_Click(object sender, EventArgs e)
        {


            this.COSTOREPOSICIONTextBox.Text = kitCostoSinImpTextBox.Text;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE productoBE = new CPRODUCTOBE();

            productoBE.ICLAVE = CLAVE;
            productoBE = productoD.seleccionarPRODUCTOxCLAVE(productoBE, null);


            WFLogItems wfLogItems = new WFLogItems("Producto", productoBE);
            wfLogItems.ShowDialog();
            wfLogItems.Dispose();
            GC.SuppressFinalize(wfLogItems);

        }

        private void MANEJALOTETextBox_Click(object sender, EventArgs e)
        {
            if (opc == "Cambiar")
            {
                CPRODUCTOD productoD = new CPRODUCTOD();
                CPRODUCTOBE productoBE = new CPRODUCTOBE();

                productoBE.ICLAVE = CLAVE;
                productoBE = productoD.seleccionarPRODUCTOxCLAVE(productoBE, null);

                if (MANEJALOTETextBox.Checked == true)
                {

                    //loteIsAble = true;
                    if (productoBE.IEXISTENCIA > 0 && productoBE.IMANEJALOTE != "S")
                    {
                        MessageBox.Show("Para ponerle lote a este producto primero debe tener la existencia en 0");
                        MANEJALOTETextBox.Checked = false;
                    }
                }
                else
                {
                    //loteIsAble = false;
                    if (productoBE.IMANEJALOTE == "S")
                    {
                        MessageBox.Show("Para quitarle el lote a este producto primero debe tener la existencia de inventario en 0");
                        MANEJALOTETextBox.Checked = true;
                    }
                }
            }

        }

        private void PRODUCTOSATButton_Click(object sender, EventArgs e)
        {
            try
            {
                long lineaId = 0;


                if (this.LINEAIDTextBox.Text != "")
                {
                    lineaId = Int32.Parse(this.LINEAIDTextBox.DbValue.ToString());
                }

                WFProductoServicioSat form = new WFProductoServicioSat(lineaId, CurrentUserID.CurrentParameters.ITIPOSELECCIONCATALOGOSAT);

                form.ShowDialog();

                DataRow rowSeleccionada = form.Retorno;

                form.Dispose();
                GC.SuppressFinalize(form);

                if (rowSeleccionada != null)
                {
                    string strBuffer = "";
                    this.productoSatTextBoxFb.DbValue = ((long)rowSeleccionada["ID"]).ToString();
                    this.productoSatTextBoxFb.MostrarErrores = false;
                    this.productoSatTextBoxFb.MValidarEntrada(out strBuffer, 1);
                    this.productoSatTextBoxFb.MostrarErrores = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + " " + ex.StackTrace);
            }
        }

        private void PROVEEDOR1Label_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Marquesina_Tick(object sender, EventArgs e)
        {
            if(PROVEEDOR1Label.Width >= 90)
            {
                PROVEEDOR1Label.Left -= 3;
                if (PROVEEDOR1Label.Left <= 0 - PROVEEDOR1Label.Width)
                {
                    PROVEEDOR1Label.Left = panel2.Width + 10;
                }
            }

            if(PROVEEDOR1Label.Width < 90)
                PROVEEDOR1Label.Left = 0;

            if (LINEALabel.Width >= 90)
            {
                LINEALabel.Left -= 3;
                if (LINEALabel.Left <= 0 - LINEALabel.Width)
                {
                    LINEALabel.Left = panel2.Width + 10;
                }
            }

            if (LINEALabel.Width < 90)
                LINEALabel.Left = 0;

            if (PRODUCTOSUSTITUTOLabel.Width >= 90)
            {
                PRODUCTOSUSTITUTOLabel.Left -= 3;
                if (PRODUCTOSUSTITUTOLabel.Left <= 0 - PRODUCTOSUSTITUTOLabel.Width)
                {
                    PRODUCTOSUSTITUTOLabel.Left = panel2.Width + 10;
                }
            }

            if (PRODUCTOSUSTITUTOLabel.Width < 90)
                PRODUCTOSUSTITUTOLabel.Left = 0;

            if (PROVEEDOR2Label.Width >= 90)
            {
                PROVEEDOR2Label.Left -= 3;
                if (PROVEEDOR2Label.Left <= 0 - PROVEEDOR2Label.Width)
                {
                    PROVEEDOR2Label.Left = panel3.Width + 10;
                }
            }

            if (PROVEEDOR2Label.Width < 90)
                PROVEEDOR2Label.Left = 0;

            if (MARCALabel.Width >= 90)
            {
                MARCALabel.Left -= 3;
                if (MARCALabel.Left <= 0 - MARCALabel.Width)
                {
                    MARCALabel.Left = panel3.Width + 10;
                }
            }

            if (MARCALabel.Width < 90)
                MARCALabel.Left = 0;

            if (CLASIFICALabelButton.Width >= 90)
            {
                CLASIFICALabelButton.Left -= 3;
                if (CLASIFICALabelButton.Left <= 0 - CLASIFICALabelButton.Width)
                {
                    CLASIFICALabelButton.Left = panel3.Width + 10;
                }
            }

            if (CLASIFICALabelButton.Width < 90)
                CLASIFICALabelButton.Left = 0;



        }

        private void PROVEEDOR2Label_Click(object sender, EventArgs e)
        {

        }






        private void CargarSucursalesPorProducto(CPRODUCTOBE productoBE, CPRODUCTOD productoD)
        {
            List<CPRODUCTOSUCURSALBE> sucursalesPorProducto = productoD.seleccionarSUCURSALESxPRODUCTO(productoBE, null);

            if (sucursalesPorProducto != null)
            {
                if (sucursalesPorProducto.Count > 0)
                {
                    if(!m_sucursalesCargadas)
                    {

                        this.sUCURSALTableAdapter.Fill(this.dSCatalogos.SUCURSAL);
                        m_sucursalesCargadas = true;
                    }
                    foreach (CPRODUCTOSUCURSALBE sucursal in sucursalesPorProducto)
                    {
                        foreach (DataGridViewRow dataRow in this.sUCURSALDataGridView.Rows)
                        {
                            long sucId = dataRow.Cells["DGSUCID"].Value != null && dataRow.Cells["DGSUCID"].Value != DBNull.Value ?
                                (long)dataRow.Cells["DGSUCID"].Value : 0;

                            if (sucursal.ISUCURSALID == sucId)
                            {
                                dataRow.Cells["DGSUCSeleccionada"].Value = 1;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: " + productoD.IComentario);
            }
        }


        private void AgregarSucursalProducto(string mod, CPRODUCTOBE prod)
        {
            CPRODUCTOSUCURSALD productoSucursalDao = new CPRODUCTOSUCURSALD();


            if(prod.IVALXSUC == null || !prod.IVALXSUC.Equals("S"))
            {

                productoSucursalDao.BorrarXProductoIdPRODUCTOSUCURSAL(prod.IID, null);
                return;
            }

            if (m_bChangedSucursales)
            {
                if (mod == "Cambiar")
                {
                    productoSucursalDao.BorrarXProductoIdPRODUCTOSUCURSAL(prod.IID, null);
                }



                foreach (DataGridViewRow row in sUCURSALDataGridView.Rows)
                {

                    if (row.Cells["DGSUCSeleccionada"].Value != null &&
                        row.Cells["DGSUCSeleccionada"].Value != DBNull.Value &&
                        (short)row.Cells["DGSUCSeleccionada"].Value == 1)
                    {
                        CPRODUCTOSUCURSALBE productoSucursal = new CPRODUCTOSUCURSALBE();

                        productoSucursal.IPRODUCTOID = prod.IID;
                        productoSucursal.ISUCURSALID = (long)row.Cells["DGSUCID"].Value;

                        productoSucursalDao.AgregarPRODUCTOSUCURSAL(productoSucursal, null);
                    }
                }
            }
        }

        private void CBTodasSucursales_Click(object sender, EventArgs e)
        {

            m_bChangedSucursales = true;
        }

        private void sUCURSALDataGridView_Validated(object sender, EventArgs e)
        {

            m_bChangedSucursales = true;
        }

        private void CBTodasSucursales_Validated(object sender, EventArgs e)
        {

            m_bChangedSucursales = true;
        }

       

        private void CBTodasSucursales_CheckedChanged_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in sUCURSALDataGridView.Rows)
            {

                row.Cells["DGSUCSeleccionada"].Value = CBTodasSucursales.Checked ? 1 : 0;
            }
        }

        private bool HayCambiosPrecios(CPRODUCTOBE originalProducto, CPRODUCTOBE nuevoProducto)
        {
            if (originalProducto == null || nuevoProducto == null)
                return false;

            if(originalProducto.IPRECIO1 != nuevoProducto.IPRECIO1 ||
                originalProducto.IPRECIO2 != nuevoProducto.IPRECIO2 ||
                originalProducto.IPRECIO3 != nuevoProducto.IPRECIO3 ||
                originalProducto.IPRECIO4 != nuevoProducto.IPRECIO4 ||
                originalProducto.IPRECIO5 != nuevoProducto.IPRECIO5 ||
                originalProducto.ICOSTOREPOSICION != nuevoProducto.ICOSTOREPOSICION)
            {
                return true;
            }

            return false;
        }

        private void BASEPRODPROMOIDButton_Click(object sender, EventArgs e)
        {
            SeleccionarProducto(TBCodigoProductoParte.Text.Trim(), BASEPRODPROMOIDTextBox);
        }



        private void AjustaPreciosxUtilidad()
        {
            AjustaPrecio1xUtilidad();
            AjustaPrecio2xUtilidad();
            AjustaPrecio3xUtilidad();
            AjustaPrecio4xUtilidad();
            AjustaPrecio5xUtilidad();
        }


        private void AjustaUtilidadxPrecios()
        {
            AjustaUtilidadxPrecio1();
            AjustaUtilidadxPrecio2();
            AjustaUtilidadxPrecio3();
            AjustaUtilidadxPrecio4();
            AjustaUtilidadxPrecio5();
        }

        private void AjustaPrecio1xUtilidad()
        {
            try
            {
                this.PRECIO1TextBox.Text = (((decimal.Parse(this.PORCUTILPRECIO1TextBox.Text) + 100.00m) / 100.00m) * decimal.Parse(this.COSTOREPOSICIONTextBox.Text)).ToString();
            }
            catch
            {

            }
        }

        private void AjustaUtilidadxPrecio1()
        {
            try
            {
                this.PORCUTILPRECIO1TextBox.Text = (((100m * decimal.Parse(this.PRECIO1TextBox.Text)) / decimal.Parse(this.COSTOREPOSICIONTextBox.Text)) - 100m).ToString();
            }
            catch
            {

            }
            
        }


        private void AjustaPrecio2xUtilidad()
        {
            try
            {
                this.PRECIO2TextBox.Text = (((decimal.Parse(this.PORCUTILPRECIO2TextBox.Text) + 100.00m) / 100.00m) * decimal.Parse(this.COSTOREPOSICIONTextBox.Text)).ToString();
            }
            catch
            {

            }
        }

        private void AjustaUtilidadxPrecio2()
        {
            try
            {
                    this.PORCUTILPRECIO2TextBox.Text = (((100m * decimal.Parse(this.PRECIO2TextBox.Text)) / decimal.Parse(this.COSTOREPOSICIONTextBox.Text)) - 100m).ToString();
            }
            catch
            {

            }
        }

        private void AjustaPrecio3xUtilidad()
         {
            try
             {
                        this.PRECIO3TextBox.Text = (((decimal.Parse(this.PORCUTILPRECIO3TextBox.Text) + 100.00m) / 100.00m) * decimal.Parse(this.COSTOREPOSICIONTextBox.Text)).ToString();
            }
            catch
            {

            }
        }

        private void AjustaUtilidadxPrecio3()
        {
           try
             {
                            this.PORCUTILPRECIO3TextBox.Text = (((100m * decimal.Parse(this.PRECIO3TextBox.Text)) / decimal.Parse(this.COSTOREPOSICIONTextBox.Text)) - 100m).ToString();
            }
            catch
            {

            }
        }



        private void AjustaPrecio4xUtilidad()
         {
            try
             {
                                this.PRECIO4TextBox.Text = (((decimal.Parse(this.PORCUTILPRECIO4TextBox.Text) + 100.00m) / 100.00m) * decimal.Parse(this.COSTOREPOSICIONTextBox.Text)).ToString();
            }
            catch
            {

            }
        }

        private void AjustaUtilidadxPrecio4()
        {
            try
            {
                                    this.PORCUTILPRECIO4TextBox.Text = (((100m * decimal.Parse(this.PRECIO4TextBox.Text)) / decimal.Parse(this.COSTOREPOSICIONTextBox.Text)) - 100m).ToString();
            }
            catch
            {

            }
        }



        private void AjustaPrecio5xUtilidad()
        {
             try
            {
                                        this.PRECIO5TextBox.Text = (((decimal.Parse(this.PORCUTILPRECIO5TextBox.Text) + 100.00m) / 100.00m) * decimal.Parse(this.COSTOREPOSICIONTextBox.Text)).ToString();
            }
            catch
            {

            }
        }

        private void AjustaUtilidadxPrecio5()
        {
            try
            {
                this.PORCUTILPRECIO5TextBox.Text = (((100m * decimal.Parse(this.PRECIO5TextBox.Text)) / decimal.Parse(this.COSTOREPOSICIONTextBox.Text)) - 100m).ToString();
            }
            catch
            {

            }
        }

    private void PORCUTILPRECIO1TextBox_Validating(object sender, CancelEventArgs e)
        {
            if(CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS != null && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS.Equals("S"))
            {
                this.AjustaPrecio1xUtilidad();
            }
        }

        private void PORCUTILPRECIO2TextBox_Validating(object sender, CancelEventArgs e)
        {

            if (CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS != null && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS.Equals("S"))
            {
                this.AjustaPrecio2xUtilidad();
            }
        }
        

        private void PORCUTILPRECIO3TextBox_Validating(object sender, CancelEventArgs e)
        {

            if (CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS != null && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS.Equals("S"))
            {
                this.AjustaPrecio3xUtilidad();
            }
        }

        private void PORCUTILPRECIO4TextBox_Validating(object sender, CancelEventArgs e)
        {

            if (CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS != null && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS.Equals("S"))
            {
                this.AjustaPrecio4xUtilidad();
            }
        }


        private void PORCUTILPRECIO5TextBox_Validating(object sender, CancelEventArgs e)
        {

            if (CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS != null && CurrentUserID.CurrentParameters.IMANEJAUTILIDADPRECIOS.Equals("S"))
            {
                this.AjustaPrecio5xUtilidad();
            }
        }

        private void LlenarProveedoreLigados(long productoId)
        {
            try
            {
                this.pRODUCTOPROVEEDOR_VIEWTableAdapter.Fill(this.dSCatalogos.PRODUCTOPROVEEDOR_VIEW, (int?)productoId, "%%");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void pRODUCTOPROVEEDOR_VIEWDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (pRODUCTOPROVEEDOR_VIEWDataGridView.Columns[e.ColumnIndex].Name == "DGDesligarProveedor")
            {
                //quitar registro producto proveedor

                if (MessageBox.Show("Estas seguro de que quieres remover el proveedor", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    long lProveedorId = Int64.Parse(pRODUCTOPROVEEDOR_VIEWDataGridView.Rows[e.RowIndex].Cells["DGPROVEEDORID"].Value.ToString());
                    m_bChangedProveedores = true;

                    List<DSCatalogos.PRODUCTOPROVEEDOR_VIEWRow> recordsToRemove = new List<DSCatalogos.PRODUCTOPROVEEDOR_VIEWRow>();
                    foreach (DSCatalogos.PRODUCTOPROVEEDOR_VIEWRow row in dSCatalogos.PRODUCTOPROVEEDOR_VIEW.Rows)
                    {
                        if (row.PROVEEDORID == lProveedorId)
                            recordsToRemove.Add(row);
                    }

                    foreach (DSCatalogos.PRODUCTOPROVEEDOR_VIEWRow row in recordsToRemove)
                    {
                        dSCatalogos.PRODUCTOPROVEEDOR_VIEW.RemovePRODUCTOPROVEEDOR_VIEWRow(row);
                    }

                }
            }
        }

        private void btnLigarProveedor_Click(object sender, EventArgs e)
        {

            if (PRODUCTOPROVEEDORIDTextBox.Text == "")
                return;



            var proveedorId = Int32.Parse(PRODUCTOPROVEEDORIDTextBox.DbValue.ToString());
            var proveedorClave = PRODUCTOPROVEEDORIDTextBox.Text;
            var proveedorNombre = PRODUCTOPROVEEDORLabel.Text;


            foreach (DSCatalogos.PRODUCTOPROVEEDOR_VIEWRow row in dSCatalogos.PRODUCTOPROVEEDOR_VIEW.Rows)
            {
                if (row.PROVEEDORID == proveedorId)
                {
                    MessageBox.Show("El proveedor ya esta ligado al producto");
                    return;
                }
            }


            var dr = dSCatalogos.PRODUCTOPROVEEDOR_VIEW.NewPRODUCTOPROVEEDOR_VIEWRow();
            dr.ID = -1;
            dr.PROVEEDORID = proveedorId;
            dr.CLAVE = proveedorClave;
            dr.NOMBRE = proveedorNombre;
            dSCatalogos.PRODUCTOPROVEEDOR_VIEW.AddPRODUCTOPROVEEDOR_VIEWRow(dr);

            m_bChangedProveedores = true;

        }


        private void GuardarCambiosProveedoresLigados(string mod, CPRODUCTOBE prod)
        {
            CPRODUCTOPROVEEDORD productoProveedorDao = new CPRODUCTOPROVEEDORD();

            
            if (m_bChangedProveedores)
            {
                if (mod == "Cambiar")
                {
                    productoProveedorDao.DesactivarPorProducto(prod.IID, null);
                }



                foreach (DataGridViewRow row in pRODUCTOPROVEEDOR_VIEWDataGridView.Rows)
                {
                    long lProveedorId = Int64.Parse(row.Cells["DGPROVEEDORID"].Value.ToString());
                    

                    if (productoProveedorDao.ExistePRODUCTOPROVEEDOR_x_VALORES(prod.IID, lProveedorId, null) == 1)
                    {
                        productoProveedorDao.PonerValorActivo(prod.IID, lProveedorId, "S", null);
                    }
                    else
                    {

                        CPRODUCTOPROVEEDORBE productoProveedor = new CPRODUCTOPROVEEDORBE();

                        productoProveedor.IPRODUCTOID = prod.IID;
                        productoProveedor.IPROVEEDORID = lProveedorId;
                        productoProveedor.IACTIVO = "S";

                        productoProveedorDao.AgregarPRODUCTOPROVEEDOR(productoProveedor, null);
                    }
                    
                }

                if (mod == "Cambiar")
                {
                    productoProveedorDao.EliminarInactivosPorProducto(prod.IID, null);
                }

                m_bChangedProveedores = false;
            }
        }
    }
}
