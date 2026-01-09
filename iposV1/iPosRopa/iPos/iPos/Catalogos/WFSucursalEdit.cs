
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

namespace iPos
{
    public partial class WFSucursalEdit : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;
        public delegate void AccionHandler(object source, Hashtable evtArgs);


        public string m_localidad_Sel_Query = @"SELECT  LOC.ID id, LOC.CLAVE_LOCALIDAD clave, LOC.DESCRIPCION nombre ,LOC.DESCRIPCION descripcion FROM sat_localidad LOC LEFT JOIN ESTADO ON (LOC.clave_estado = ESTADO.acronimo or (LOC.clave_estado = 'DIF' and ESTADO.acronimo = 'CMX' )) WHERE ESTADO.clave = @CLAVEESTADO ORDER BY LOC.DESCRIPCION";
        public string m_localidad_Sel_Query_DeSeleccion = @"SELECT  LOC.ID id, LOC.CLAVE_LOCALIDAD clave, LOC.DESCRIPCION nombre ,LOC.DESCRIPCION descripcion FROM sat_localidad LOC LEFT JOIN ESTADO ON (LOC.clave_estado = ESTADO.acronimo or (LOC.clave_estado = 'DIF' and ESTADO.acronimo = 'CMX' )) WHERE ESTADO.clave = @CLAVEESTADO  and LOC.CLAVE_LOCALIDAD = @clave";

        public string m_municipio_Sel_Query = @"SELECT MUN.ID id,  MUN.CLAVE_MUNICIPIO clave, MUN.DESCRIPCION nombre ,MUN.DESCRIPCION descripcion FROM sat_municipio MUN LEFT JOIN ESTADO ON (MUN.clave_estado = ESTADO.acronimo or (MUN.clave_estado = 'DIF' and ESTADO.acronimo = 'CMX' )) WHERE ESTADO.clave = @CLAVEESTADO ORDER BY MUN.DESCRIPCION";
        public string m_municipio_Sel_Query_DeSeleccion = @"SELECT MUN.ID id,  MUN.CLAVE_MUNICIPIO clave, MUN.DESCRIPCION nombre ,MUN.DESCRIPCION descripcion FROM sat_municipio MUN LEFT JOIN ESTADO ON (MUN.clave_estado = ESTADO.acronimo or (MUN.clave_estado = 'DIF' and ESTADO.acronimo = 'CMX' )) WHERE ESTADO.clave = @CLAVEESTADO and MUN.CLAVE_MUNICIPIO = @clave";

        public string m_colonia_Sel_Query = @"SELECT  c.ID id, c.COLONIA clave, C.nombre nombre ,C.nombre descripcion FROM sat_colonia C WHERE c.codigopostal = @CODIGOPOSTAL ORDER BY C.nombre";
        public string m_colonia_Sel_Query_DeSeleccion = @"SELECT  c.ID id, c.COLONIA clave, C.nombre nombre ,C.nombre descripcion FROM sat_colonia C WHERE c.codigopostal = @CODIGOPOSTAL  and c.COLONIA = @clave";

        bool m_terminoLoad = false;

        public WFSucursalEdit()
        {
            InitializeComponent();
        }


        public void ReCargar(string popc,string pCLAVE)
        {

            ENTREGAESTADOTextBox.llenarDatos();
            this.BANCOCLAVETextBox.llenarDatos();
            this.LISTAPRECIOCLAVETextBox.llenarDatos();

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

            m_terminoLoad = true;
            // this.BANCOCLAVETextBox.SelectedIndex = -1;
        }


        private bool LlenarDatosDeBase()
        {
            try
            {
                
                CSUCURSALD itemD = new CSUCURSALD();
                CSUCURSALBE itemBE = new CSUCURSALBE();
                string strBuffer = "";

                itemBE.ICLAVE = CLAVE;
                itemBE = itemD.seleccionarSUCURSALPorClave(itemBE, null);

                if (itemBE == null)
                    return false;

                this.ID = itemBE.IID;

                this.CLAVETextBox.Text = itemBE.ICLAVE;

                this.NOMBRETextBox.Text = itemBE.INOMBRE;


                this.ACTIVOTextBox.Checked = (itemBE.IACTIVO == "S") ? true : false;



                this.DESCRIPCIONTextBox.Text = itemBE.IDESCRIPCION;


                if (!(bool)itemBE.isnull["IGRUPOSUCURSALID"])
                {
                    this.GRUPOSUCURSALIDTextBox.DbValue = itemBE.IGRUPOSUCURSALID.ToString();
                    this.GRUPOSUCURSALIDTextBox.MostrarErrores = false;
                    this.GRUPOSUCURSALIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.GRUPOSUCURSALIDTextBox.MostrarErrores = true;
                }

                if (!(bool)itemBE.isnull["IMAXDOCTOSPENDIENTES"])
                    this.MAXDOCTOSPENDIENTESTextBox.Text = itemBE.IMAXDOCTOSPENDIENTES.ToString();


                if (!(bool)itemBE.isnull["ILISTA_PRECIO_TRASPASO"] && itemBE.ILISTA_PRECIO_TRASPASO != null)
                {
                    switch(itemBE.ILISTA_PRECIO_TRASPASO.ToString())
                    {
                        case "R": this.LISTA_PRECIO_TRASPASOTextBox.Text = "Costo reposicion"; break;
                        case "U": this.LISTA_PRECIO_TRASPASOTextBox.Text = "Costo ultimo"; break;
                        case "P": this.LISTA_PRECIO_TRASPASOTextBox.Text = "Costo promedio"; break;
                        default: this.LISTA_PRECIO_TRASPASOTextBox.Text = itemBE.ILISTA_PRECIO_TRASPASO.ToString(); break;
                    }
                }
                else
                {
                    this.LISTA_PRECIO_TRASPASOTextBox.Text = "";
                }

                this.ESMATRIZTextBox.Checked = (itemBE.IESMATRIZ == "S") ? true : false;


                this.PRECIOENVIOTRASLADOTextBox.Enabled = this.ESMATRIZTextBox.Checked;

                if (!(bool)itemBE.isnull["IPRECIORECEPCIONTRASLADO"] && itemBE.IPRECIORECEPCIONTRASLADO > 0)
                {
                    this.PRECIORECEPCIONTRASLADOTextBox.SelectedIndex = (int)itemBE.IPRECIORECEPCIONTRASLADO - 1;
                }
                else
                {
                    this.PRECIORECEPCIONTRASLADOTextBox.SelectedIndex = 0;
                }

                this.MOSTRARPRECIOREALTextBox.Checked = (itemBE.IMOSTRARPRECIOREAL == "S") ? true : false;

                this.IMNUPRODTextBox.Checked = (itemBE.IIMNUPROD == "S") ? true : false;



                if (!(bool)itemBE.isnull["IPRECIOENVIOTRASLADO"] && itemBE.IPRECIOENVIOTRASLADO > 0)
                {
                    this.PRECIOENVIOTRASLADOTextBox.SelectedIndex = (int)itemBE.IPRECIOENVIOTRASLADO - 1;
                }
                else
                {
                    this.PRECIOENVIOTRASLADOTextBox.SelectedIndex = 3;
                }


                
                if (!(bool)itemBE.isnull["ICLIENTECLAVE"])
                {
                    this.CLIENTECLAVETextBox.DbValue = itemBE.ICLIENTECLAVE.ToString();
                    this.CLIENTECLAVETextBox.MostrarErrores = false;
                    this.CLIENTECLAVETextBox.MValidarEntrada(out strBuffer,1);
                    this.CLIENTECLAVETextBox.MostrarErrores = true;
                }



                if (!(bool)itemBE.isnull["IPROVEEDORCLAVE"])
                {
                    this.PROVEEDORCLAVETextBox.DbValue = itemBE.IPROVEEDORCLAVE.ToString();
                    this.PROVEEDORCLAVETextBox.MostrarErrores = false;
                    this.PROVEEDORCLAVETextBox.MValidarEntrada(out strBuffer, 1);
                    this.PROVEEDORCLAVETextBox.MostrarErrores = true;
                }




                if (!(bool)itemBE.isnull["IEMPPROV"])
                {
                    this.EMPPROVTextBox.DbValue = itemBE.IEMPPROV.ToString();
                    this.EMPPROVTextBox.MostrarErrores = false;
                    this.EMPPROVTextBox.MValidarEntrada(out strBuffer, 1);
                    this.EMPPROVTextBox.MostrarErrores = true;
                }



                this.ESFRANQUICIATextBox.Checked = (itemBE.IESFRANQUICIA == "S") ? true : false;
                this.POR_FACT_ELECTTextBox.Checked = (itemBE.IPOR_FACT_ELECT == "S") ? true : false;


                


                if (!(bool)itemBE.isnull["IENTREGAESTADO"])
                    this.ENTREGAESTADOTextBox.Text = itemBE.IENTREGAESTADO.ToString().Trim();

                this.LlenarCamposRelacionadosAEstado_Entrega();


                if (!(bool)itemBE.isnull["IENTREGA_SAT_LOCALIDADID"])
                {
                    this.ENTREGA_SAT_LOCALIDADIDTextBox.DbValue = itemBE.IENTREGA_SAT_LOCALIDADID.ToString();
                    this.ENTREGA_SAT_LOCALIDADIDTextBox.MostrarErrores = false;
                    this.ENTREGA_SAT_LOCALIDADIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.ENTREGA_SAT_LOCALIDADIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.ENTREGA_SAT_LOCALIDADIDTextBox.Text = "";
                }


                if (!(bool)itemBE.isnull["IENTREGA_SAT_MUNICIPIOID"])
                {
                    this.ENTREGA_SAT_MUNICIPIOIDTextBox.DbValue = itemBE.IENTREGA_SAT_MUNICIPIOID.ToString();
                    this.ENTREGA_SAT_MUNICIPIOIDTextBox.MostrarErrores = false;
                    this.ENTREGA_SAT_MUNICIPIOIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.ENTREGA_SAT_MUNICIPIOIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.ENTREGA_SAT_MUNICIPIOIDTextBox.Text = "";
                    if (!(bool)itemBE.isnull["IENTREGAMUNICIPIO"])
                    {
                        this.ENTREGA_SAT_MUNICIPIOIDLabel.Text = itemBE.IENTREGAMUNICIPIO;
                    }
                }


                if (!(bool)itemBE.isnull["IENTREGACODIGOPOSTAL"])
                    this.ENTREGACODIGOPOSTALTextBox.Text = itemBE.IENTREGACODIGOPOSTAL.ToString().Trim();

                this.LlenarCamposRelacionadosACodigoPostal_Entrega();


                if (!(bool)itemBE.isnull["IENTREGA_SAT_COLONIAID"])
                {
                    this.ENTREGA_SAT_COLONIAIDTextBox.DbValue = itemBE.IENTREGA_SAT_COLONIAID.ToString();
                    this.ENTREGA_SAT_COLONIAIDTextBox.MostrarErrores = false;
                    this.ENTREGA_SAT_COLONIAIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.ENTREGA_SAT_COLONIAIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.ENTREGA_SAT_COLONIAIDTextBox.Text = "";
                    if (!(bool)itemBE.isnull["IENTREGACOLONIA"])
                    {
                        this.ENTREGA_SAT_COLONIAIDLabel.Text = itemBE.IENTREGACOLONIA;
                    }
                }



                if (!(bool)itemBE.isnull["IENTREGACALLE"])
                    this.ENTREGACALLETextBox.Text = itemBE.IENTREGACALLE.ToString().Trim();

                if (!(bool)itemBE.isnull["IENTREGANUMEROINTERIOR"])
                    this.ENTREGANUMEROINTERIORTextBox.Text = itemBE.IENTREGANUMEROINTERIOR.ToString().Trim();

                if (!(bool)itemBE.isnull["IENTREGANUMEROEXTERIOR"])
                    this.ENTREGANUMEROEXTERIORTextBox.Text = itemBE.IENTREGANUMEROEXTERIOR.ToString().Trim();
                


                if (!(bool)itemBE.isnull["ISURTIDOR"])
                {
                    this.SURTIDORTextBox.DbValue = itemBE.ISURTIDOR.ToString();
                    this.SURTIDORTextBox.MostrarErrores = false;
                    this.SURTIDORTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SURTIDORTextBox.MostrarErrores = true;
                }


                if (!(bool)itemBE.isnull["IPORC_AUMENTO_PRECIO"])
                    this.PORC_AUMENTO_PRECIOTextBox.Text = itemBE.IPORC_AUMENTO_PRECIO.ToString();


                if (!(bool)itemBE.isnull["IRUTARESPALDOORIGEN"])
                {
                    this.txtRutaRespaldoOrigen.Text = itemBE.IRUTARESPALDOORIGEN;
                }

                if (!(bool)itemBE.isnull["IRUTARESPALDODESTINO"])
                {
                    this.txtRutaRespaldoDestino.Text = itemBE.IRUTARESPALDODESTINO;
                }


                this.MANEJAPRECIOXDESCUENTOTextBox.Checked = (itemBE.IMANEJAPRECIOXDESCUENTO == "S") ? true : false;


                if (!(bool)itemBE.isnull["IPREFIJOPRECIOXDESCUENTO"])
                {
                    this.PREFIJOPRECIOXDESCUENTOTextBox.Text = itemBE.IPREFIJOPRECIOXDESCUENTO;
                }


                if (!(bool)itemBE.isnull["INOMBRERESPALDOBD"])
                {
                    this.txtNombreRespaldoBD.Text = itemBE.INOMBRERESPALDOBD;
                }

                if (!(bool)itemBE.isnull["IBANCOCLAVE"])
                    this.BANCOCLAVETextBox.SelectedDataValue = itemBE.IBANCOCLAVE;
                else
                    this.BANCOCLAVETextBox.SelectedIndex = -1;


                if (!(bool)itemBE.isnull["ICUENTAREFERENCIA"])
                    this.CUENTAREFERENCIATextBox.Text = itemBE.ICUENTAREFERENCIA.ToString().Trim();


                if (!(bool)itemBE.isnull["IRUTARESPALDORED"])
                {
                    this.txtRutaRespaldoRed.Text = itemBE.IRUTARESPALDORED;
                }


                if (!(bool)itemBE.isnull["ICUENTAPOLIZA"])
                    this.CUENTAPOLIZATextBox.Text = itemBE.ICUENTAPOLIZA.ToString().Trim();



                if (!(bool)itemBE.isnull["ILISTAPRECIOCLAVE"])
                    this.LISTAPRECIOCLAVETextBox.SelectedDataValue = itemBE.ILISTAPRECIOCLAVE;
                else
                    this.LISTAPRECIOCLAVETextBox.SelectedIndex = -1;


                if (!(bool)itemBE.isnull["IENTREGA_DISTANCIA"])
                    this.ENTREGA_DISTANCIATextBox.Text = itemBE.IENTREGA_DISTANCIA.ToString();


                if (!(bool)itemBE.isnull["IENTREGAREFERENCIADOM"])
                    this.ENTREGAREFERENCIADOMTextBox.Text = itemBE.IENTREGAREFERENCIADOM.ToString();

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


        private CSUCURSALBE ObtenerDatosCapturados()
        {
            CSUCURSALBE ITEMBE = new CSUCURSALBE();
            ITEMBE.IACTIVO= (this.ACTIVOTextBox.Checked) ? "S" : "N";

            if (this.CLAVETextBox.Text != "")
            {
                ITEMBE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                ITEMBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }


            if (this.DESCRIPCIONTextBox.Text != "")
            {
                ITEMBE.IDESCRIPCION = this.DESCRIPCIONTextBox.Text.ToString();
            }


            if (this.GRUPOSUCURSALIDTextBox.Text != "")
            {
                ITEMBE.IGRUPOSUCURSALID = Int32.Parse(this.GRUPOSUCURSALIDTextBox.DbValue.ToString());
            }



            if (this.LISTA_PRECIO_TRASPASOTextBox.Text != "")
            {

                switch (this.LISTA_PRECIO_TRASPASOTextBox.Text)
                {
                    case "Costo reposicion": ITEMBE.ILISTA_PRECIO_TRASPASO = "R"; break;
                    case "Costo ultimo": ITEMBE.ILISTA_PRECIO_TRASPASO = "U"; break;
                    case "Costo promedio": ITEMBE.ILISTA_PRECIO_TRASPASO = "P"; break;
                    default: ITEMBE.ILISTA_PRECIO_TRASPASO = this.LISTA_PRECIO_TRASPASOTextBox.Text;  break;
                }
            }
            

            if (this.MAXDOCTOSPENDIENTESTextBox.Text != "")
            {
                ITEMBE.IMAXDOCTOSPENDIENTES = long.Parse(this.MAXDOCTOSPENDIENTESTextBox.Text.ToString());
            }


            ITEMBE.IESMATRIZ = (this.ESMATRIZTextBox.Checked) ? "S" : "N";


            ITEMBE.IMOSTRARPRECIOREAL = (this.MOSTRARPRECIOREALTextBox.Checked) ? "S" : "N";

            ITEMBE.IIMNUPROD = (this.IMNUPRODTextBox.Checked) ? "S" : "N";



            if (this.PRECIORECEPCIONTRASLADOTextBox.SelectedIndex >= 0)
            {
                ITEMBE.IPRECIORECEPCIONTRASLADO = this.PRECIORECEPCIONTRASLADOTextBox.SelectedIndex + 1;
            }
            else
            {
                ITEMBE.IPRECIORECEPCIONTRASLADO = 1;
            }



            if (this.PRECIOENVIOTRASLADOTextBox.SelectedIndex >= 0)
            {
                ITEMBE.IPRECIOENVIOTRASLADO = this.PRECIOENVIOTRASLADOTextBox.SelectedIndex + 1;
            }
            else
            {
                ITEMBE.IPRECIOENVIOTRASLADO = 4;
            }




            if (this.CLIENTECLAVETextBox.Text != "")
            {
                ITEMBE.ICLIENTECLAVE = this.CLIENTECLAVETextBox.DbValue.ToString();
            }


            if (this.PROVEEDORCLAVETextBox.Text != "")
            {
                ITEMBE.IPROVEEDORCLAVE = this.PROVEEDORCLAVETextBox.DbValue.ToString();
            }



            ITEMBE.IESFRANQUICIA = (this.ESFRANQUICIATextBox.Checked) ? "S" : "N";

            ITEMBE.IPOR_FACT_ELECT = (this.POR_FACT_ELECTTextBox.Checked) ? "S" : "N";



            if (this.ENTREGACALLETextBox.Text != "")
            {
                ITEMBE.IENTREGACALLE = this.ENTREGACALLETextBox.Text.ToString();
            }
            if (this.ENTREGANUMEROINTERIORTextBox.Text != "")
            {
                ITEMBE.IENTREGANUMEROINTERIOR = this.ENTREGANUMEROINTERIORTextBox.Text.ToString();
            }
            if (this.ENTREGANUMEROEXTERIORTextBox.Text != "")
            {
                ITEMBE.IENTREGANUMEROEXTERIOR = this.ENTREGANUMEROEXTERIORTextBox.Text.ToString();
            }
            

            if (this.ENTREGAESTADOTextBox.Text != "")
            {
                ITEMBE.IENTREGAESTADO = this.ENTREGAESTADOTextBox.Text.ToString();
            }


            if (this.ENTREGA_SAT_LOCALIDADIDTextBox.Text != "")
            {
                ITEMBE.IENTREGA_SAT_LOCALIDADID = Int64.Parse(this.ENTREGA_SAT_LOCALIDADIDTextBox.DbValue.ToString());
            }




            if (this.ENTREGA_SAT_MUNICIPIOIDTextBox.Text != "")
            {
                ITEMBE.IENTREGA_SAT_MUNICIPIOID = Int64.Parse(this.ENTREGA_SAT_MUNICIPIOIDTextBox.DbValue.ToString());
            }
            ITEMBE.IENTREGAMUNICIPIO = this.ENTREGA_SAT_MUNICIPIOIDLabel.Text;


            if (this.ENTREGACODIGOPOSTALTextBox.Text != "")
            {
                ITEMBE.IENTREGACODIGOPOSTAL = this.ENTREGACODIGOPOSTALTextBox.Text.ToString();
            }


            if (this.ENTREGA_SAT_COLONIAIDTextBox.Text != "")
            {
                ITEMBE.IENTREGA_SAT_COLONIAID = Int64.Parse(this.ENTREGA_SAT_COLONIAIDTextBox.DbValue.ToString());
            }
            ITEMBE.IENTREGACOLONIA = this.ENTREGA_SAT_COLONIAIDLabel.Text;



            if (this.SURTIDORTextBox.Text != "")
            {
                ITEMBE.ISURTIDOR = this.SURTIDORTextBox.DbValue.ToString();
            }



            if (this.PORC_AUMENTO_PRECIOTextBox.Text != "")
            {
                ITEMBE.IPORC_AUMENTO_PRECIO = decimal.Parse(this.PORC_AUMENTO_PRECIOTextBox.Text.ToString());
            }


            if (this.txtRutaRespaldoOrigen.Text != "")
            {
                ITEMBE.IRUTARESPALDOORIGEN = this.txtRutaRespaldoOrigen.Text.ToString();
            }


            if (this.txtRutaRespaldoDestino.Text != "")
            {
                ITEMBE.IRUTARESPALDODESTINO = this.txtRutaRespaldoDestino.Text.ToString();
            }

            ITEMBE.IMANEJAPRECIOXDESCUENTO = (this.MANEJAPRECIOXDESCUENTOTextBox.Checked) ? "S" : "N";

            if (this.PREFIJOPRECIOXDESCUENTOTextBox.Text != "")
            {
                ITEMBE.IPREFIJOPRECIOXDESCUENTO = this.PREFIJOPRECIOXDESCUENTOTextBox.Text.ToString();
            }

            if (this.txtNombreRespaldoBD.Text != "")
            {
                ITEMBE.INOMBRERESPALDOBD = this.txtNombreRespaldoBD.Text.ToString();
            }

            if (this.BANCOCLAVETextBox.SelectedIndex >= 0)
                ITEMBE.IBANCOCLAVE = this.BANCOCLAVETextBox.SelectedDataValue.ToString();


            if (this.CUENTAREFERENCIATextBox.Text != "")
            {
                ITEMBE.ICUENTAREFERENCIA = this.CUENTAREFERENCIATextBox.Text.ToString();
            }


            if (this.txtRutaRespaldoRed.Text != "")
            {
                ITEMBE.IRUTARESPALDORED = this.txtRutaRespaldoRed.Text.ToString();
            }


            if (this.CUENTAPOLIZATextBox.Text != "")
            {
                ITEMBE.ICUENTAPOLIZA = this.CUENTAPOLIZATextBox.Text.ToString();
            }

            if (this.LISTAPRECIOCLAVETextBox.SelectedIndex >= 0)
                ITEMBE.ILISTAPRECIOCLAVE = this.LISTAPRECIOCLAVETextBox.SelectedDataValue.ToString();


            if (this.EMPPROVTextBox.Text != "")
            {
                ITEMBE.IEMPPROV = this.EMPPROVTextBox.DbValue.ToString();
            }

            if (this.ENTREGA_DISTANCIATextBox.Text != "")
            {
                ITEMBE.IENTREGA_DISTANCIA = decimal.Parse(this.ENTREGA_DISTANCIATextBox.Text.ToString());
            }

            if (this.ENTREGAREFERENCIADOMTextBox.Text != "")
            {
                ITEMBE.IENTREGAREFERENCIADOM = this.ENTREGAREFERENCIADOMTextBox.Text.ToString();
            }

            return ITEMBE;

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
                    CSUCURSALD ITEMD = new CSUCURSALD();

                    if (opc == "Agregar")
                    {
                        CSUCURSALBE ITEMBE = new CSUCURSALBE();
                        ITEMBE = ObtenerDatosCapturados();

                        ITEMBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        ITEMD.AgregarSUCURSAL(ITEMBE, null);

                        if (ITEMD.IComentario == "" || ITEMD.IComentario == null)
                        {

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + ITEMD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CSUCURSALBE ITEMBEAnt = new CSUCURSALBE();

                        CSUCURSALBE ITEMBE = new CSUCURSALBE();

                        ITEMBE = ObtenerDatosCapturados();

                        ITEMBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        ITEMBEAnt.IID = this.ID;

                        ITEMD.CambiarSUCURSAL(ITEMBE, ITEMBEAnt, null);
                        if (ITEMD.IComentario == "" || ITEMD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);


                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + ITEMD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CSUCURSALBE ITEMBEAnt = new CSUCURSALBE();
                            ITEMBEAnt.IID = this.ID;
                            ITEMD.BorrarSUCURSAL(ITEMBEAnt, null);
                            if (ITEMD.IComentario == "" || ITEMD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + ITEMD.IComentario.Replace("%", "\n"));
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
            if (!validarCodigoPostal(ENTREGACODIGOPOSTALTextBox.Text) && ENTREGACODIGOPOSTALTextBox.Text != "")
            {
                MessageBox.Show("El Código Postal Ingresado no es valido!");
                ENTREGACODIGOPOSTALTextBox.Focus();
                return;
            }

            if(this.ENTREGA_SAT_COLONIAIDTextBox.Text == "" )
            {
                MessageBox.Show("La colonia ingresada no existe en el catalogo, favor de revisar.");
                this.ENTREGA_SAT_COLONIAIDTextBox.Focus();
                return;
            }
            

            if (this.ENTREGA_SAT_MUNICIPIOIDTextBox.Text == "")
            {
                MessageBox.Show("La ciudad/municipio no existe en el catalogo, favor de revisar.");
                this.ENTREGA_SAT_MUNICIPIOIDTextBox.Focus();
                return;
            }



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

            this.DESCRIPCIONTextBox.Text = "";

            this.GRUPOSUCURSALIDTextBox.Text = "";

            this.LISTA_PRECIO_TRASPASOTextBox.Text = "";

            this.MAXDOCTOSPENDIENTESTextBox.Text = "";

            this.ESMATRIZTextBox.Checked = false;

            this.PRECIORECEPCIONTRASLADOTextBox.SelectedIndex = 0;

            this.MOSTRARPRECIOREALTextBox.Checked = false;

            this.IMNUPRODTextBox.Checked = false;

            this.PRECIOENVIOTRASLADOTextBox.SelectedIndex = 0;

            this.CLIENTECLAVETextBox.Text = "";

            this.SURTIDORTextBox.Text = "";

            this.CUENTAREFERENCIATextBox.Text = "";

            this.BANCOCLAVETextBox.SelectedIndex = -1;

            this.LISTAPRECIOCLAVETextBox.SelectedIndex = -1;


            this.ENTREGACALLETextBox.Text = "";
            this.ENTREGANUMEROINTERIORTextBox.Text = "";
            this.ENTREGANUMEROEXTERIORTextBox.Text = "";
            this.ENTREGAESTADOTextBox.Text = "";
            this.ENTREGACODIGOPOSTALTextBox.Text = "";

            this.ENTREGA_SAT_LOCALIDADIDTextBox.Text = "";
            this.ENTREGA_SAT_LOCALIDADIDLabel.Text = "";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Text = "";
            this.ENTREGA_SAT_MUNICIPIOIDLabel.Text = "";
            this.ENTREGA_SAT_COLONIAIDTextBox.Text = "";
            this.ENTREGA_SAT_COLONIAIDLabel.Text = "";


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

        private void ESMATRIZTextBox_CheckedChanged(object sender, EventArgs e)
        {

            this.PRECIOENVIOTRASLADOTextBox.Enabled = this.ESMATRIZTextBox.Checked;
        }

        private bool validarCodigoPostal(string cp)
        {
            CSAT_CODIGOPOSTALBE codPostal = new CSAT_CODIGOPOSTALBE();
            CSAT_CODIGOPOSTALD daoCodPostal = new CSAT_CODIGOPOSTALD();
            codPostal.ISAT_CLAVE = cp;
            if (daoCodPostal.ExisteSAT_CODIGOPOSTALXCLAVE(codPostal, null) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private void LlenarCamposRelacionadosAEstado_Entrega()
        {

            var acronimoEstado = ENTREGAESTADOTextBox.SelectedDataDisplaying != null ? "'" + ENTREGAESTADOTextBox.SelectedDataDisplaying.ToString() + "'" : "''";


            this.ENTREGA_SAT_LOCALIDADIDTextBox.Query = this.m_localidad_Sel_Query.Replace("@CLAVEESTADO", acronimoEstado);
            this.ENTREGA_SAT_LOCALIDADIDTextBox.QueryDeSeleccion = this.m_localidad_Sel_Query_DeSeleccion.Replace("@CLAVEESTADO", acronimoEstado);


            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Query = this.m_municipio_Sel_Query.Replace("@CLAVEESTADO", acronimoEstado);
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.QueryDeSeleccion = this.m_municipio_Sel_Query_DeSeleccion.Replace("@CLAVEESTADO", acronimoEstado);

        }

        private void LlenarCamposRelacionadosACodigoPostal_Entrega()
        {

            var codigoPostal = this.ENTREGACODIGOPOSTALTextBox.Text != null ? "'" + this.ENTREGACODIGOPOSTALTextBox.Text + "'" : "''";

            this.ENTREGA_SAT_COLONIAIDTextBox.Query = this.m_colonia_Sel_Query.Replace("@CODIGOPOSTAL", codigoPostal);
            this.ENTREGA_SAT_COLONIAIDTextBox.QueryDeSeleccion = this.m_colonia_Sel_Query_DeSeleccion.Replace("@CODIGOPOSTAL", codigoPostal);


        }


        private void ENTREGACODIGOPOSTALTextBox_Validated(object sender, EventArgs e)
        {

            if (m_terminoLoad)
            {
                LlenarCamposRelacionadosACodigoPostal_Entrega();
            }
        }

        private void ENTREGAESTADOTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_terminoLoad)
            {
                this.LlenarCamposRelacionadosAEstado_Entrega();
            }
        }


    }
}
