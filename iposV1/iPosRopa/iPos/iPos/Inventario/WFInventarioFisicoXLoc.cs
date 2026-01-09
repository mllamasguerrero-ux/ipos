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
using iPos.Inventario;
using static iPos.Inventario.DSInventarioFisico;

namespace iPos
{
    public partial class WFInventarioFisicoXLoc : IposForm
    {
        CDOCTOBE m_Docto;

        bool m_bFocusCodigo = false;
        decimal dMaxCantidad = 1000;
        bool m_terminoLoad = false;


        bool m_bDobleTab = false;
        bool m_bSelectingEditableCell = false;
        //bool m_bIgnoreCellEnterEvent = false;


        bool m_manejaAlmacen = false;
        bool m_mostrarLookUpProductoSiVacio = false;

        private string mensajeGuardadoMultiple = "";

        private string m_anaquelComboQuery = "select id, nombre from(select id, nombre, 0 as orden from (select min(anaquel.id) id, anaquel.clave as nombre from productolocations inner join anaquel on anaquel.id = productolocations.anaquelid(wherecondition) group by anaquel.id , anaquel.clave order by anaquel.clave ) q UNION select -2 id, 'Libre' AS nombre, 1 as orden from rdb$database) r order by orden, nombre";

        private string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }

        bool m_bEsInventarioCiclico = false;

        public WFInventarioFisicoXLoc()
        {
            InitializeComponent();

            try
            {
                m_Docto = new CDOCTOBE();
                m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_INVENTARIO_FISICOXLOC;
                //LlenarGrid();

                if (!(bool)iPos.CurrentUserID.CurrentParameters.isnull["IMAX_INV_FIS_CANT"])
                {
                    dMaxCantidad = iPos.CurrentUserID.CurrentParameters.IMAX_INV_FIS_CANT;
                }
                ESINVENTARIOCICLICOLabel.Visible = m_bEsInventarioCiclico;
            }
            catch { }
            
        }

        public WFInventarioFisicoXLoc(bool bEsInventarioFCiclico):this()
        {
            this.m_bEsInventarioCiclico = bEsInventarioFCiclico;
            ESINVENTARIOCICLICOLabel.Visible = m_bEsInventarioCiclico;
        }


    public WFInventarioFisicoXLoc(long doctoId)
            :this()
        {
            ObtenerDoctoDeBD(doctoId);
            //LlenarGrid();
        }

        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {
            
            int errorCode = 0;
            string strMensajeErr = "";
            bool mostrarLookUpProductoSiVacio = m_mostrarLookUpProductoSiVacio;
            m_mostrarLookUpProductoSiVacio = false;



            if (TBCodigo.Text.Trim() == "")
            {
                return;
            }


            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                if (TBCodigo.Text.Trim().Length == 0 && !mostrarLookUpProductoSiVacio)
                    return;
                SeleccionarProducto(TBCodigo.Text.Trim());
                return;
            }


            if (prod.IESKIT != null && prod.IESKIT.Equals("S") && KITDESGLOSADOCheckBox.Checked)
            {
                MessageBox.Show("No se puede seleccionar un kit cuando estamos en un inventario con kits desglosado");
                e.Cancel = true;
                return;
            }

            LlenarDatos();


            DataRow dr = this.dSInventarioFisico.GET_INVENTARIOFISICO_INFO.Rows[0];
            if (dr["ERRORCODE"] != DBNull.Value)
            {
                errorCode = (int)dr["ERRORCODE"];
                if (errorCode != 0)
                {

                    strMensajeErr = CERRORCODED.ObtenerMensajeError((long)errorCode, ConexionBD.ConexionString(), null);
                    MessageBox.Show("ERROR : " + strMensajeErr);
                    e.Cancel = true;
                    return;
                }
            }


        }

        private void LlenarDatos()
        {
            long? doctoId = null;
            string producto = TBCodigo.Text.Trim();
            string lote = "";
            DateTime? fechaVence= null;
            string kitDesglosado = KITDESGLOSADOCheckBox.Checked ? "S" : "N";
            string modoDetalle = "S";//RBModoDetalle.Checked ? "S" : "N";

            long almacenid;
            if (m_manejaAlmacen)
            {
                almacenid = this.ALMACENComboBox.SelectedIndex >= 0 ? int.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT;
            }
            else
            {
                almacenid = (int)DBValues._DOCTO_ALMACEN_DEFAULT;
            }


            if (!(bool)this.m_Docto.isnull["IID"])
            {
                doctoId = m_Docto.IID;
            }


            try
            {
                this.gET_INVENTARIOFISICO_INFOTableAdapter.Fill(this.dSInventarioFisico.GET_INVENTARIOFISICO_INFO, producto, lote, fechaVence, doctoId, almacenid, kitDesglosado, modoDetalle);
                /**wpf only starts*
                 gET_INVENTARIOFISICO_INFOBindingSource.View.MoveCurrentToFirst();
                 /**wpf only ends**/
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


        }



        private void ObtenerDoctoDeBD(long lDoctoID)
        {
            CDOCTOD vDocto = new CDOCTOD();
            m_Docto = new CDOCTOBE();
            m_Docto.IID = lDoctoID;
            m_Docto = vDocto.seleccionarDOCTO(m_Docto, null);

            this.m_bEsInventarioCiclico = m_Docto.IACTIVO == "N";
            this.LBConsecutivo.Text = m_Docto.IID.ToString();
            this.LBFolio.Text = m_Docto.IFOLIO.ToString();
            this.LBDateValue.Text = m_Docto.IFECHA.ToShortDateString();
            this.KITDESGLOSADOCheckBox.Checked = m_Docto.IKITDESGLOSADO != null && m_Docto.IKITDESGLOSADO.Equals("S");
        }

        private bool Process()
        {
            return Process(true);
        }


            private bool Process(bool refreshGrid)
        {


            if (m_manejaAlmacen)
            {
                if (this.ALMACENComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("por favor seleccione un almacen valido de la lista ");
                    return false;
                }
            }

            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            string P_VD_VENDEDOR = CurrentUserID.CurrentUser.INOMBRE;
            string P_LOTE = "";
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            int? US_SUPERVISORID = null;
            int? ALMACENID = m_manejaAlmacen ? int.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT;//(int)DBValues._DOCTO_ALMACEN_DEFAULT;/*CurrentUserID.CurrentUser.IUS_ALMACENID*/ ;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            long? SUCURSALTID = 0;
            long? ALMACENTID = 0;
            decimal? P_CANTIDAD_SURTIDA = null;
            bool bEsPrimeraEntrada = m_Docto == null || m_Docto.IID == 0;

            long? P_TIPODIFERENCIAINVENTARIOID = 0;

            string  P_LOCALIDAD = "";
            long? P_ANAQUEL = 0;


            decimal? P_CANTIDAD_CAJAS = null;
            decimal? P_CANTIDAD_PIEZAS = null;
            decimal? P_PZACAJA = null;


            if (TBCodigo.Text.Trim() == "")
            {
                MessageBox.Show("El texto de este control no debe estar vacio");
                return false;
            }


            if (this.LocalidadComboBox.Text == "")
            {
                MessageBox.Show("La localidad no debe de estar vacia");
                return false;
            }



            //if (this.ANAQUELComboBox.Text.Trim() == "")
            if(this.ANAQUELComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("El campo de anaquel no debe de estar vacio");
                return false;
            }


            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {

                MessageBox.Show("El producto no existe");
                return false;
            }
            

            if (this.dSInventarioFisico.GET_INVENTARIOFISICO_INFO.Rows.Count < 0)
            {
                MessageBox.Show("No se ha seleccionado un producto valido");
                return false;
            }

            DataRow dr = this.dSInventarioFisico.GET_INVENTARIOFISICO_INFO.Rows[0];

            if (dr["PRODUCTOID"] != DBNull.Value)
            {
                P_IDPRODUCTO = (long)dr["PRODUCTOID"];
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un producto valido");
                return false;
            }


            P_ANAQUEL = long.Parse(this.ANAQUELComboBox.SelectedValue.ToString());
             P_LOCALIDAD = this.LocalidadComboBox.Text.Trim();

            if (P_ANAQUEL != -2)
            {
                CPRODUCTOLOCATIONSD prodLocD = new CPRODUCTOLOCATIONSD();
                CPRODUCTOLOCATIONSBE prodLocBE = new CPRODUCTOLOCATIONSBE();
                prodLocBE.IPRODUCTOID = P_IDPRODUCTO.Value;
                prodLocBE.IANAQUELID = P_ANAQUEL.Value;
                prodLocBE.ILOCALIDAD = P_LOCALIDAD;

                if (m_manejaAlmacen)
                {
                    prodLocBE.IALMACENID = ALMACENID.Value;
                }
                prodLocBE = prodLocD.seleccionarPRODUCTOLOCATIONSXINFO(prodLocBE, null);
                if (prodLocBE == null)
                {
                    MessageBox.Show("no se tiene registrado ese producto en esa localidad y anaquel");
                    return false;
                }
            }





            try
            {
                decimal cajas = 0, piezas = 0;
                decimal.TryParse(TBCajas.Text.Trim(), out cajas);
                decimal.TryParse(TBPiezas.Text.Trim(), out piezas);

                P_CANTIDAD_CAJAS = cajas;
                P_CANTIDAD_PIEZAS = piezas;

                P_PZACAJA = 1;
                if (!(bool)prod.isnull["IPZACAJA"])
                {
                    if (prod.IPZACAJA > 0)
                        P_PZACAJA = prod.IPZACAJA;
                }

                P_CANTIDAD_SURTIDA = (P_CANTIDAD_CAJAS.Value * P_PZACAJA.Value) + P_CANTIDAD_PIEZAS/*decimal.Parse(TBCantidad.Text.Trim())*/;
            }
            catch
            {
                MessageBox.Show("La cantidad no tiene el formato adecuado");
                return false;
            }


            //if (!(bool)iPos.CurrentUserID.CurrentParameters.isnull["IMAX_INV_FIS_CANT"])
            //{
                if (P_CANTIDAD_SURTIDA >= dMaxCantidad /*iPos.CurrentUserID.CurrentParameters.IMAX_INV_FIS_CANT*/)
                {

                    if (MessageBox.Show("La cantidad parece ser muy grande , seguro que desea continuar con esa cantidad ", "Cantidad muy grande", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return false;
                    }
                }
            //}



            if (!(bool)this.m_Docto.isnull["IID"])
            {
                P_IDDOCTO = m_Docto.IID;
            }
            



            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_VD_VENDEDOR, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_Docto.ITIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID,P_CANTIDAD_SURTIDA,P_ANAQUEL,P_LOCALIDAD,P_CANTIDAD_CAJAS, P_CANTIDAD_PIEZAS,P_PZACAJA, null, fTrans))
                {
                    fTrans.Commit();


                    if (bEsPrimeraEntrada)
                    {
                        string mensajeKit = "";
                        m_Docto = new CDOCTOBE();
                        m_Docto.IID = P_IDDOCTO.Value;
                        if (!CambiarKITDESGLOSADO(null, KITDESGLOSADOCheckBox.Checked, ref mensajeKit))
                        {
                            MessageBox.Show("no se pudo cambiar el flag de desglose de kits");
                        }

                        if (this.m_bEsInventarioCiclico)
                        {

                            if (!CambiarACTIVO(null, this.m_bEsInventarioCiclico, ref mensajeKit))
                            {
                                MessageBox.Show("no se pudo poner como inventario ciclico");
                            }
                        }
                    }

                    ObtenerDoctoDeBD((long)P_IDDOCTO);                 
                    PrepararSiguienteEntrada();

                    //if (CBCaminarLocalidad.Checked)
                    //{
                    //    NextLocalidad();
                    //}

                    if(refreshGrid)
                        LlenarGrid();

                    if (m_manejaAlmacen)
                    {
                        this.ALMACENComboBox.Enabled = false;
                    }

                    
                }
                else
                {
                    fTrans.Rollback();
                    MessageBox.Show(this.IComentario);
                    //this.TBCodigo.Focus();
                }
                fConn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }
            return true;
        }


        private void PrepararSiguienteEntrada()
        {
            this.TBCajas.Text = "";
            this.TBPiezas.Text = "";
            this.LlenarDatos();
            //this.TBCodigo.Focus();
            //TBCodigo.Select(0,TBCodigo.Text.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process();

            this.TBCodigo.Focus();
            this.TBCodigo.Text = "";
            //TBCodigo.Select(0, TBCodigo.Text.Length);
        }

        private void BTVerDiferencias_Click(object sender, EventArgs e)
        {
            if(!PreguntarSiGuardarCambiosGrid())
            {
                return;
            }



            if (m_Docto == null || m_Docto.IID == 0)
            {
                m_Docto = new CDOCTOBE();
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;
                doctoBE.IALMACENID = DBValues._ALMACEN_DEFAULT;
                doctoBE.ISUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
                doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_INVENTARIO_FISICOXLOC;
                doctoBE.IESTATUSDOCTOID = DBValues._DOCTO_ESTATUS_BORRADOR;
                //doctoBE.IESTATUSDOCTOPAGOID type of D_FK,
                doctoBE.IPERSONAID = 1;
                doctoBE.IVENDEDORID =  CurrentUserID.CurrentUser.IID;
                doctoBE.ICAJAID = DBValues._CAJA_DEFAULT;
                doctoBE.IREFERENCIA = "";
                doctoBE.IREFERENCIAS = "";
                //doctoBE.ISUCURSALTID D_FK,
                //doctoBE.IALMACENTID D_FK,
                doctoBE.IFECHA = DateTime.Today;
                doctoBE.IVENCE = DateTime.Today;
                //doctoBE.IDOCTOREFID D_FK,
                //doctoBE.IMERCANCIAENTREGADA D_BOOLCS,
                doctoBE.IORIGENFISCALID = DBValues._ORIGENFISCAL_REMISIONADO;

                if(!doctoD.DOCTO_INSERT(ref doctoBE, null))
                {
                    MessageBox.Show("Hubo un error al insertar el inventario vacio " + doctoD.IComentario);
                    return;
                }
                else
                {
                    m_Docto.IID = doctoBE.IID;
                }

            }

            WFSeleccionarTipo wf = new WFSeleccionarTipo(m_Docto.IID);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
            this.Close();
        }



        public bool EjecutarAddMOVTO(ref long? P_IDDOCTO,
                                        decimal? P_CANTIDAD,
                                        long? P_IDPRODUCTO,
                                        string P_VD_VENDEDOR,
                                        long? P_USERID,
                                        string P_LOTE,
                                        int? US_SUPERVISOR,
                                        int? ALMACENID,
                                        long? SUCURSALID,
                                        DateTime P_FECHAVENCE,
                                        long P_TIPO_DOCTO,
                                        long? P_SUCURSALTID,
                                        long? P_ALMACENTID,
                                        string P_PROMOCION,
                                        long? P_TIPODIFERENCIAINVENTARIOID,
                                        decimal? P_CANTIDAD_SURTIDA,
                                        long? P_ANAQUEL,
                                        string P_LOCALIDAD,
                                        decimal? P_CANTIDAD_CAJAS,
                                        decimal? P_CANTIDAD_PIEZAS,
                                        decimal? P_PZACAJA,
                                        long? P_LOTEIMPORTADO,
                                        FbTransaction st)
        {
            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                if (P_IDDOCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDDOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (ALMACENID.HasValue)
                {
                    auxPar.Value = (long)ALMACENID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (SUCURSALID.HasValue)
                {
                    auxPar.Value = (long)SUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = P_TIPO_DOCTO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOPAGOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_PAGO_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PARTIDA", FbDbType.SmallInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (P_IDPRODUCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (P_LOTE != null && P_LOTE != "")
                {
                    auxPar.Value = P_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (P_FECHAVENCE > DateTime.MinValue)
                    auxPar.Value = P_FECHAVENCE;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (P_CANTIDAD.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                if (P_CANTIDAD_SURTIDA.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD_SURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADFALTANTE", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEVUELTA", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSALDO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSMOVTOID", FbDbType.BigInt);
                auxPar.Value = (long)DBValues._MOVTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);



                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);





                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (P_SUCURSALTID.HasValue)
                {
                    auxPar.Value = (long)P_SUCURSALTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ALMACENTID", FbDbType.BigInt);
                if (P_ALMACENTID.HasValue)
                {
                    auxPar.Value = (long)P_ALMACENTID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PROMOCION", FbDbType.Char);
                auxPar.Value = P_PROMOCION;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODIFERENCIAINVENTARIOID", FbDbType.BigInt);
                if (P_TIPODIFERENCIAINVENTARIOID.HasValue)
                {
                    auxPar.Value = (long)P_TIPODIFERENCIAINVENTARIOID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCENTAJEDESCUENTO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOREFID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ANAQUELID", FbDbType.BigInt);
                if (P_ANAQUEL != null)
                {
                    auxPar.Value = P_ANAQUEL;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                if (P_LOCALIDAD != null)
                {
                    auxPar.Value = P_LOCALIDAD;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOREFID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOYAVALIDADO", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTEIMPORTADO", FbDbType.BigInt);
                if (P_LOTEIMPORTADO.HasValue)
                {
                    auxPar.Value = (long)P_LOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARGOTARJPRECIOMANUAL", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new FbParameter("@AGRUPAPORPARAMETRO", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);





                string commandText = @"MOVTO_INSERT";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }




                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {


                    CMOVTOD movtoD = new CMOVTOD();
                    CMOVTOBE movtoBE = new CMOVTOBE();
                    movtoBE.IID = (long)arParms[arParms.Length - 2].Value;
                    movtoBE = movtoD.seleccionarMOVTO(movtoBE, st);

                    if (movtoBE == null)
                    {
                        this.iComentario = "ERROR al asignar la cantidad de cajas y piezas ";
                        return false;
                    }

                    if ((bool)movtoBE.isnull["ICAJAS"])
                        movtoBE.ICAJAS = 0;

                    if ((bool)movtoBE.isnull["IPIEZAS"])
                        movtoBE.IPIEZAS = 0;

                    if (P_CANTIDAD_CAJAS.HasValue)
                    {
                        movtoBE.ICAJAS += P_CANTIDAD_CAJAS.Value;
                    }

                    if (P_CANTIDAD_PIEZAS.HasValue)
                    {
                        movtoBE.IPIEZAS += P_CANTIDAD_PIEZAS.Value;
                    }


                    if (P_PZACAJA.HasValue)
                    {
                        movtoBE.IPZACAJA = P_PZACAJA.Value;
                    }
                    else
                    {
                        movtoBE.IPZACAJA = 1;
                    }

                    if (!movtoD.CambiarCAJASPIEZASMOVTOD(movtoBE, st))
                    {
                        this.iComentario = "ERROR al asignar la cantidad de cajas y piezas ";
                        return false;
                    }

                }


                P_IDDOCTO = (long)arParms[arParms.Length - 3].Value;
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        private void TBPiezas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Process();
                m_bFocusCodigo = true;
            }
        }

        private void TBPiezas_Leave(object sender, EventArgs e)
        {
            if (m_bFocusCodigo)
            {
                this.TBCodigo.Focus();
                this.TBCodigo.Text = "";
                m_bFocusCodigo = false;
            }
        }

        private void TBCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                if (TBCodigo.Text.Trim() == "")
                {
                    SeleccionarProducto(TBCodigo.Text.Trim());
                }
                else
                {
                    this.LocalidadComboBox.Focus();
                    /**winforms only starts**/
                    LocalidadComboBox.Select(0, LocalidadComboBox.Text.Length);
                    /**winforms only ends**/
                }
            }
        }

        private void LlenarGrid()
        {
            try
            {

                long? P_IDDOCTO = null;
                if (!(bool)this.m_Docto.isnull["IID"])
                {
                    P_IDDOCTO = m_Docto.IID;
                }

                short P_SOLODIFERENCIAS = (this.cbSoloDiferencias.Checked) ? (short)1 : (short)0;
                short P_TODOSLOSPRODUCTOS = (this.cbSoloIngresados.Checked) ? (short)0 : (short)1;
                string P_KITDESGLOSADO = this.KITDESGLOSADOCheckBox.Checked ? "S" : "N";

                if (this.ANAQUELComboBox.SelectedIndex < 0)
                {
                    this.dSInventarioFisico.GET_INVFIS_LISTADETAIL_XLOC.Clear();
                    return;
                }

                long anaquelId = long.Parse(this.ANAQUELComboBox.SelectedValue.ToString());
                long? almacenId = m_manejaAlmacen && this.ALMACENComboBox.SelectedIndex > -1 ? (long?)long.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : null;
                this.gET_INVFIS_LISTADETAIL_XLOCTableAdapter.Fill(this.dSInventarioFisico.GET_INVFIS_LISTADETAIL_XLOC, (P_IDDOCTO.HasValue) ? P_IDDOCTO : -1, P_SOLODIFERENCIAS, P_TODOSLOSPRODUCTOS, anaquelId, P_KITDESGLOSADO, almacenId );
                
                if(P_SOLODIFERENCIAS == 1)
                    this.gETINVFISLISTADETAILXLOCBindingSource.Filter = "CANTIDADDIFERENCIA <> 0";
                else
                    this.gETINVFISLISTADETAILXLOCBindingSource.Filter = "";

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void gET_INVFIS_LISTADETALLES_PDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.RowIndex == gET_INVFIS_LISTADETALLES_PDataGridView.NewRowIndex)
            {
                return;
            }

            if (gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGCANTIDADFISICATEMP"].Index != e.ColumnIndex &&
                gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGCAJASTEMP"].Index != e.ColumnIndex  &&
                gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGPIEZASTEMP"].Index != e.ColumnIndex  )
                return;

            if(RBGuardadoGridXBoton.Checked)
            {

                decimal dCantidadTeorica = decimal.Parse(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGCANTIDADTEORICA"].Value.ToString());
                decimal dNuevaCantidad = 0;
                decimal dCantidadDif = decimal.Parse(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGCANTIDADDIFERENCIA"].Value.ToString());
                decimal dPzaCaja = decimal.Parse(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGPZACAJA"].Value.ToString());

                decimal dViejaCantidad = decimal.Parse(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGCANTIDADFISICA"].Value.ToString());
                decimal dViejaCantidadCajas = decimal.Parse(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGCAJAS"].Value.ToString());
                decimal dViejaCantidadPiezas = decimal.Parse(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGPIEZAS"].Value.ToString());
                decimal dNuevaCantidadCajas = 0;
                decimal dNuevaCantidadPiezas = 0;

                decimal dNuevaAcumuladoCantFisica = 0; //
                decimal dViejaAcumuladoCantFisica = !string.IsNullOrEmpty(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["ACUMCANTFISICATEMP"].Value.ToString())  ?
                                            decimal.Parse(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["ACUMCANTFISICATEMP"].Value.ToString()) : 0;

                


                if (dPzaCaja == 0)
                    dPzaCaja = 1;

                if (gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGCANTIDADFISICATEMP"].Index == e.ColumnIndex)
                {
                    dNuevaCantidad = decimal.Parse(e.FormattedValue.ToString());

                    if (dNuevaCantidad < 0)
                    {
                        MessageBox.Show("La cantidad fisica no puede ser menor que cero");
                        e.Cancel = true;
                    }

                    decimal dCajas = Math.Truncate(dNuevaCantidad / dPzaCaja);
                    decimal dPiezas = Math.Truncate(dNuevaCantidad % dPzaCaja);
                    gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGCAJASTEMP"].Value = dCajas;
                    gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGPIEZASTEMP"].Value = dPiezas;

                }
                else if (gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGCAJASTEMP"].Index == e.ColumnIndex)
                {
                    dNuevaCantidadCajas = decimal.Parse(e.FormattedValue.ToString());
                    dNuevaCantidadPiezas = decimal.Parse(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGPIEZASTEMP"].Value.ToString());
                    
                    dNuevaCantidad = (dNuevaCantidadCajas * dPzaCaja) + dNuevaCantidadPiezas;

                    if (dNuevaCantidad < 0)
                    {
                        MessageBox.Show("La cantidad fisica no puede ser menor que cero");
                        e.Cancel = true;
                    }

                    gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGCANTIDADFISICATEMP"].Value = dNuevaCantidad;

                }
                else if(gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGPIEZASTEMP"].Index == e.ColumnIndex)
                {

                    dNuevaCantidadCajas = decimal.Parse(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGCAJASTEMP"].Value.ToString());
                    dNuevaCantidadPiezas = decimal.Parse(e.FormattedValue.ToString()); 

                    dNuevaCantidad = (dNuevaCantidadCajas * dPzaCaja) + dNuevaCantidadPiezas;

                    if (dNuevaCantidad < 0)
                    {
                        MessageBox.Show("La cantidad fisica no puede ser menor que cero");
                        e.Cancel = true;
                    }

                    gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGCANTIDADFISICATEMP"].Value = dNuevaCantidad;
                }

                dCantidadDif = dNuevaCantidad - dCantidadTeorica;

                dNuevaAcumuladoCantFisica = dViejaAcumuladoCantFisica + dNuevaCantidad - dViejaCantidad;

                gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGCANTIDADDIFERENCIA"].Value = dCantidadDif;
                gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["ACUMULADOCANTIDADFISICA"].Value = dNuevaAcumuladoCantFisica;

                if (dViejaCantidad != dNuevaCantidad || dViejaCantidadPiezas != dNuevaCantidadPiezas || dViejaCantidadCajas != dNuevaCantidadCajas)
                    gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGESTADO"].Value = 1;
                else
                    gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGESTADO"].Value = 0;

                coloreaRow(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex]);
                return;
            }

            if (gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGCANTIDADFISICATEMP"].Index == e.ColumnIndex)
            {
                try
                {
                    decimal dNuevaCantidad = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejaCantidad = decimal.Parse(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGCANTIDADFISICA"].Value.ToString());
                    decimal dEntrada = dNuevaCantidad - dViejaCantidad;
                    if (dEntrada == 0)
                        return;
                    if (dNuevaCantidad < 0)
                    {
                        MessageBox.Show("La cantidad fisica no puede ser menor que cero");
                        e.Cancel = true;
                    }
                    TBCodigo.Text = gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGPRODUCTOCLAVE"].Value.ToString();
                    LocalidadComboBox.Text = gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGLOCALIDAD"].Value.ToString();

                    LlenarDatos();
                    TBPiezas.Text = dEntrada.ToString("N0");
                    TBCajas.Text = "0";

                    if (Process())
                    {
                        //m_bGoToNextCell = true;
                    }

                    //m_bFocusCodigo = true;
                    return;
                }
                catch
                {
                    MessageBox.Show("Cheque el formato de entrada del valor");
                    e.Cancel = true;
                }
            }
            else if (gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGCAJASTEMP"].Index == e.ColumnIndex)
            {
                try
                {
                    decimal dNuevaCantidad = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejaCantidad = decimal.Parse(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGCAJASTEMP"].Value.ToString());
                    decimal dPzaCaja = decimal.Parse(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGPZACAJA"].Value.ToString());
                    decimal dEntrada = (dNuevaCantidad - dViejaCantidad) /** dPzaCaja*/;
                    if (dEntrada == 0)
                        return;
                    if (dNuevaCantidad < 0)
                    {
                        MessageBox.Show("La cantidad fisica no puede ser menor que cero");
                        e.Cancel = true;
                    }
                    TBCodigo.Text = gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGPRODUCTOCLAVE"].Value.ToString();
                    LocalidadComboBox.Text = gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGLOCALIDAD"].Value.ToString();

                    LlenarDatos();
                    TBCajas.Text = dEntrada.ToString("N0");
                    TBPiezas.Text = "0";

                    if (Process())
                    {
                        //m_bGoToNextCell = true;
                    }

                    //m_bFocusCodigo = true;
                    return;
                }
                catch
                {
                    MessageBox.Show("Cheque el formato de entrada del valor");
                    e.Cancel = true;
                }
            }
            else if (gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGPIEZASTEMP"].Index == e.ColumnIndex)
            {
                try
                {
                    decimal dNuevaCantidad = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejaCantidad = decimal.Parse(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGPIEZASTEMP"].Value.ToString());
                    decimal dEntrada = dNuevaCantidad - dViejaCantidad;
                    if (dEntrada == 0)
                        return;
                    if (dNuevaCantidad < 0)
                    {
                        MessageBox.Show("La cantidad fisica no puede ser menor que cero");
                        e.Cancel = true;
                    }
                    TBCodigo.Text = gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGPRODUCTOCLAVE"].Value.ToString();
                    this.LocalidadComboBox.Text = gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGLOCALIDAD"].Value.ToString();

                    LlenarDatos();
                    TBPiezas.Text = dEntrada.ToString("N0");
                    TBCajas.Text = "0";

                    if (Process())
                    {
                        //m_bGoToNextCell = true;
                    }

                    //m_bFocusCodigo = true;
                    return;
                }
                catch
                {
                    MessageBox.Show("Cheque el formato de entrada del valor");
                    e.Cancel = true;
                }
            }

            return;
        }

        private void cbSoloIngresados_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void cbSoloDiferencias_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void gET_INVFIS_LISTADETALLES_PDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            //if (m_bGoToNextCell)
            //{
            //    if (gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGCAJASTEMP"].Index != e.ColumnIndex)
            //    {
            //        gET_INVFIS_LISTADETALLES_PDataGridView.CurrentCell = gET_INVFIS_LISTADETALLES_PDataGridView[gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGPIEZASTEMP"].Index, e.RowIndex];
            //    }
            //    m_bGoToNextCell = false;
            //}
        }
        private void ActualizaTablasDeControl()
        {
            WFActualizandoKITMultiNivel wf = new WFActualizandoKITMultiNivel();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }


        private void WFInventarioFisicoXLoc_Load(object sender, EventArgs e)
        {

            ActualizaTablasDeControl();
            // TODO: This line of code loads data into the 'dSInventarioFisico.ANAQUELES' table. You can move, or remove it, as needed.
            this.aNAQUELESTableAdapter.Fill(this.dSInventarioFisico.ANAQUELES);
            this.TBCantidadMaxima.Text = this.dMaxCantidad.ToString("N0");


            LlenarGrid();

            LlenarLocalidadCombo();


            m_manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));
            if (!m_manejaAlmacen)
            {
                this.ALMACENComboBox.Visible = false;
                this.lblAlmacen.Visible = false;


            }
            else
            {
                this.ALMACENComboBox.Visible = true;
                this.lblAlmacen.Visible = true;

                this.ALMACENComboBox.llenarDatos();
                try
                {
                    this.ALMACENComboBox.SelectedIndex = -1;
                }
                catch
                {
                }

                if (m_Docto != null && !(bool)m_Docto.isnull["IID"])
                {

                    this.ALMACENComboBox.Enabled = false;
                    if (!(bool)m_Docto.isnull["IALMACENID"])
                        this.ALMACENComboBox.SelectedDataValue = m_Docto.IALMACENID;
                    else
                        this.ALMACENComboBox.SelectedIndex = -1;
                }

                if (this.ALMACENComboBox.SelectedIndex == -1)
                    this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID;
                
            }


            LlenarAnaquelComboBox();
            m_terminoLoad = true;
        }

        private void LlenarAnaquelComboBox()
        {
            if (!m_manejaAlmacen)
            {
                this.ANAQUELComboBox.Query = this.m_anaquelComboQuery.Replace("(wherecondition)", " ");
            }
            else
            {

                if (this.ALMACENComboBox.SelectedIndex == -1)
                    this.ANAQUELComboBox.Query = this.m_anaquelComboQuery.Replace("(wherecondition)", " ");
                else
                    this.ANAQUELComboBox.Query = this.m_anaquelComboQuery.Replace("(wherecondition)", " where productolocations.almacenid =  " + this.ALMACENComboBox.SelectedDataValue.ToString() + " ");

            }

            ANAQUELComboBox.llenarDatos();

        }

    

        private void TBCantidadMaxima_Validated(object sender, EventArgs e)
        {
            if (this.TBCantidadMaxima.Text != "")
            {
                this.dMaxCantidad = decimal.Parse(this.TBCantidadMaxima.Text);
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


        private void TBLocalidad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                m_mostrarLookUpProductoSiVacio = true;

                this.TBCajas.Focus();
                TBCajas.Select(0, TBCajas.Text.Length);
            }
        }


        private void LocalidadComboBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (CBCajas.Checked)
                {
                    this.TBCajas.Focus();
                    TBCajas.Select(0, TBCajas.Text.Length);
                }
                else if (CBPiezas.Checked)
                {
                    this.TBPiezas.Focus();
                    TBPiezas.Select(0, TBCajas.Text.Length);
                }
            }
        }

        private void ANAQUELComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_terminoLoad)
            {

                if (!PreguntarSiGuardarCambiosGrid())
                    return;

                LlenarGrid();

                LlenarLocalidadCombo();
            }
        }

        private void BTNextAnaquel_Click(object sender, EventArgs e)
        {
            if (!PreguntarSiGuardarCambiosGrid())
                return;

            int nextSelectedIndex = ANAQUELComboBox.SelectedIndex + 1;
            if (nextSelectedIndex < ANAQUELComboBox.Items.Count && nextSelectedIndex >= 0)
            {
                ANAQUELComboBox.SelectedIndex = nextSelectedIndex;
            }        
        }

        private void BTPrevAnaquel_Click(object sender, EventArgs e)
        {
            if (!PreguntarSiGuardarCambiosGrid())
                return;

            int nextSelectedIndex = ANAQUELComboBox.SelectedIndex - 1;
            if (nextSelectedIndex < ANAQUELComboBox.Items.Count && nextSelectedIndex >= 0)
            {
                ANAQUELComboBox.SelectedIndex = nextSelectedIndex;
            }   
        }

        private void TBCajas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }


        private void LlenarLocalidadCombo()
        {
            long P_ANAQUEL = 0;
            string query = @"select id, nombre from
                            (
                            select id, nombre from
                            (select min(id) id, localidad as nombre
                            from productolocations
                            where anaquelid = :anaquelid
                            group by localidad ) q
                            union
                            select -2 id, 'Libre' nombre from rdb$database
                            where -2 = :anaquelid
                            ) r
                            order by nombre";
            string querySeleccion = @"select id,  nombre
                            from
                            (select id, nombre from
                            (select min(id) id, localidad as nombre
                            from productolocations
                            where anaquelid = :anaquelid and localidad = @localidad
                            group by localidad ) q
                            union
                            select -2 id, 'Libre' nombre from rdb$database
                            where -2 = :anaquelid and 'Libre' = @localidad) r
                            order by nombre";

            if (this.ANAQUELComboBox.SelectedIndex < 0)
            {

                query = query.Replace(":anaquelid", "0");
                querySeleccion = querySeleccion.Replace(":anaquelid", "0");
                return;
            }
            else
            {
                P_ANAQUEL = long.Parse(this.ANAQUELComboBox.SelectedValue.ToString());
                query = query.Replace(":anaquelid", P_ANAQUEL.ToString("0"));
                querySeleccion = querySeleccion.Replace(":anaquelid", P_ANAQUEL.ToString("0"));
            }

             LocalidadComboBox.Query = query;
             LocalidadComboBox.QueryDeSeleccion = querySeleccion;
             LocalidadComboBox.llenarDatos();
        }

        private void btnPrevLocalidad_Click(object sender, EventArgs e)
        {
            int nextSelectedIndex = LocalidadComboBox.SelectedIndex - 1;
            if (nextSelectedIndex < LocalidadComboBox.Items.Count && nextSelectedIndex >= 0)
            {
                LocalidadComboBox.SelectedIndex = nextSelectedIndex;
            }   
        }

        private void btnNextLocalidad_Click(object sender, EventArgs e)
        {
            NextLocalidad();
        }

        private void NextLocalidad()
        {
                int nextSelectedIndex = LocalidadComboBox.SelectedIndex + 1;
                if (nextSelectedIndex < LocalidadComboBox.Items.Count && nextSelectedIndex >= 0)
                {
                    LocalidadComboBox.SelectedIndex = nextSelectedIndex;
                }
        }

        private void TBCajas_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (CBPiezas.Checked)
                {
                    this.TBPiezas.Focus();
                    TBPiezas.Select(0, TBCajas.Text.Length);
                }
            }
        }

        private void CBCajas_CheckedChanged(object sender, EventArgs e)
        {
            this.TBCajas.Enabled = CBCajas.Checked;
            gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGCAJASTEMP"].ReadOnly = !CBCajas.Checked;
        }

        private void CBPiezas_CheckedChanged(object sender, EventArgs e)
        {
            this.TBPiezas.Enabled = CBPiezas.Checked;
            gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGPIEZASTEMP"].ReadOnly = !CBPiezas.Checked;

        }


        private void SelectNextEditableCell(DataGridView dataGridView)
        {
            if (m_bSelectingEditableCell)
                return;

            m_bSelectingEditableCell = true ;

            DataGridViewCell currentCell = dataGridView.CurrentCell;


            if (gET_INVFIS_LISTADETALLES_PDataGridView.NewRowIndex == 0)
                return;

            if (currentCell != null)
            {
                int nextRow = currentCell.RowIndex;
                int nextCol = currentCell.ColumnIndex + 1;
                int currentCol = currentCell.ColumnIndex;
                int currentRow = currentCell.RowIndex;



                while (!(nextCol == currentCol && nextRow == currentRow  ))
                {

                    DataGridViewCell nextCell;

                    if (nextCol >= dataGridView.ColumnCount )
                    {
                        nextCol = 0;
                        nextRow++;
                    }
                    if (nextRow >= dataGridView.RowCount || nextRow >= gET_INVFIS_LISTADETALLES_PDataGridView.NewRowIndex )
                    {
                        //nextRow = 0;
                        if (currentCol > 0)
                        {
                            nextCell = dataGridView.Rows[currentRow].Cells[currentCol - 1];
                            if (nextCell.Visible)
                            {
                                dataGridView.CurrentCell = nextCell;
                            }
                            else
                            {
                                dataGridView.CurrentCell = currentCell;
                            }
                        }
                        //m_bIgnoreCellEnterEvent = true;
                        MessageBox.Show("ha llegado al final de la captura");
                        break;
                    }
                    nextCell = dataGridView.Rows[nextRow].Cells[nextCol];



                    if (!nextCell.ReadOnly && nextCell.Visible)
                    {

                        //dataGridView.CurrentCell = dataGridView.Rows[nextRow].Cells[nextCol];
                        break;
                    }
                    else
                    {
                        if (nextCell.Visible)
                        {
                            dataGridView.CurrentCell = nextCell;
                        }
                    }
                    
                    //nextRow = currentCell.RowIndex;
                    nextCol++;

                }
                
            }
            m_bSelectingEditableCell = false;
        }

        private void gET_INVFIS_LISTADETALLES_PDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextEditableCell(gET_INVFIS_LISTADETALLES_PDataGridView);
            }
        }


        private void gET_INVFIS_LISTADETALLES_PDataGridView_KeyUp_1(object sender, KeyEventArgs e)
        {

            
        }

        private void gET_INVFIS_LISTADETALLES_PDataGridView_EnterKeyDownEvent(object sender, EventArgs e)
        {
                //SelectNextEditableCell(gET_INVFIS_LISTADETALLES_PDataGridView);


            if (m_bDobleTab)
            {
                SendKeys.Send("{tab}");
                SendKeys.Send("{tab}");
            }
            else
            {
                SendKeys.Send("{tab}");
            }

            m_bDobleTab = false;
        }

        private void gET_INVFIS_LISTADETALLES_PDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGCAJASTEMP"].Index == e.ColumnIndex && !CBPiezas.Checked) ||
                (gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGPIEZASTEMP"].Index == e.ColumnIndex))
                m_bDobleTab = true;
            else
                m_bDobleTab = false;
        }

        private void gET_INVFIS_LISTADETALLES_PDataGridView_Leave(object sender, EventArgs e)
        {
            m_bDobleTab = false;
        }

        private void gET_INVFIS_LISTADETALLES_PDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            /*if (m_bSelectingEditableCell)
                return;
            if (m_bIgnoreCellEnterEvent)
            {
                m_bIgnoreCellEnterEvent = false;
                return;
            }

            if (e.ColumnIndex == 0 && e.RowIndex == 0)
                return;
            //SelectNextEditableCell(gET_INVFIS_LISTADETALLES_PDataGridView);
            if (gET_INVFIS_LISTADETALLES_PDataGridView.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
            {
                SendKeys.Send("{tab}");
            }*/
        }


        private bool CambiarKITDESGLOSADO(FbTransaction st, bool bDesglosarKits, ref string message)
        {
            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.IKITDESGLOSADO = bDesglosarKits ? "S" : "N";
            if (!doctoD.CambiarKITDESGLOSADODOCTOD(m_Docto, st))
            {
                message = doctoD.IComentario;
                return false;
            }

            return true;

        }

        private bool CambiarACTIVO(FbTransaction st, bool bEsInventarioCiclico, ref string message)
        {
            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.IACTIVO = bEsInventarioCiclico ? "N" : "S";
            if (!doctoD.CambiarACTIVO(m_Docto, st))
            {
                message = doctoD.IComentario;
                return false;
            }

            return true;

        }


        private void KITDESGLOSADOCheckBox_Click(object sender, EventArgs e)
        {

            if (!PreguntarSiGuardarCambiosGrid())
            {
                KITDESGLOSADOCheckBox.Checked = !KITDESGLOSADOCheckBox.Checked;
                return;
            }

            if (m_Docto != null && m_Docto.IID > 0)
            {
                string strMensaje = "";

                if (KITDESGLOSADOCheckBox.Checked)
                {
                    if (MessageBox.Show("Esto eliminara las entradas de productos kit ( de este inventario ) que haya ingresado. Desea proseguir?  ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        KITDESGLOSADOCheckBox.Checked = !KITDESGLOSADOCheckBox.Checked;
                        return;
                    }
                }


                if (!CambiarKITDESGLOSADO(null, KITDESGLOSADOCheckBox.Checked, ref strMensaje))
                {
                    MessageBox.Show("Hubo un error al cambiar al cambiar el checkbox");
                    KITDESGLOSADOCheckBox.Checked = !KITDESGLOSADOCheckBox.Checked;
                }

            }
            
            LlenarGrid();
        }

        private void coloreaRow(DataGridViewRow row)
        {
            try
            {
                if (row.Cells["DGESTADO"].Value != DBNull.Value && (int)row.Cells["DGESTADO"].Value == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

                row.Cells["DGCANTIDADFISICATEMP"].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                row.Cells["DGCAJASTEMP"].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                row.Cells["DGPIEZASTEMP"].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            }
            catch(Exception ex)
            {

            }
        }

        private void gET_INVFIS_LISTADETALLES_PDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

                coloreaRow(gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex]);
           
        }

        private void btnGuardarCambiosGrid_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }


        private void GuardarDatos()
        {
            mensajeGuardadoMultiple = "";
            try
            {
                // var modifiedRows = this.dSInventarioFisico.GET_INVFIS_LISTADETAIL_XLOC.AsEnumerable().Where(r => ((int)r["ESTADO"]) == 1);



                var modifiedRows = this.dSInventarioFisico.GET_INVFIS_LISTADETAIL_XLOC.Select("ESTADO = 1");
                foreach (GET_INVFIS_LISTADETAIL_XLOCRow row in modifiedRows)
                {
                    try
                    {
                        decimal dViejaCantidadCajas = row.CAJAS;
                        decimal dNuevaCantidadCajas = row.CAJASTEMP;
                        decimal dEntradaCajas = dNuevaCantidadCajas - dViejaCantidadCajas;

                        if (dNuevaCantidadCajas < 0)
                        {
                            continue;
                        }



                        decimal dViejaCantidadPiezas = row.PIEZAS;
                        decimal dNuevaCantidadPiezas = row.PIEZASTEMP;
                        decimal dEntradaPiezas = dNuevaCantidadPiezas - dViejaCantidadPiezas;

                        if (dNuevaCantidadPiezas < 0)
                        {
                            continue;
                        }


                        if (dEntradaCajas == 0 && dEntradaPiezas == 0)
                            return;


                        TBCodigo.Text = row.PRODUCTOCLAVE;
                        LocalidadComboBox.Text = row.LOCALIDAD;

                        LlenarDatos();
                        TBPiezas.Text = dEntradaPiezas.ToString("N0");
                        TBCajas.Text = dEntradaCajas.ToString("N0");

                        if (Process(false))
                        {
                            row.ESTADO = 0;
                        }
                    }
                    catch (Exception ex)
                    {

                        mensajeGuardadoMultiple += ex.Message;
                    }
                }

                LlenarGrid();
            }
            catch (Exception ex)
            {
                mensajeGuardadoMultiple += ex.Message;
            }

            if (mensajeGuardadoMultiple.Trim().Length > 0)
            {
                MessageBox.Show(mensajeGuardadoMultiple);
            }

        }


        private bool PreguntarSiGuardarCambiosGrid()
        {
            if (!RBGuardadoGridXBoton.Checked)
                return true;
            var modifiedRows = this.dSInventarioFisico.GET_INVFIS_LISTADETAIL_XLOC.Select("ESTADO = 1");
            if (modifiedRows.Length == 0)
                return true;


            if (MessageBox.Show("Hay cambios no guardados en el grid. Desea guardarlos?  ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {

                if (MessageBox.Show("Seguro que no desea guardarlos?.   ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    return true;
                }
            }

            return false;

        }

        

      

        

        private void WFInventarioFisicoXLoc_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!PreguntarSiGuardarCambiosGrid())
                return;
        }
        

        private void ALMACENComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(m_terminoLoad)
                LlenarAnaquelComboBox();
        }
    }
}
