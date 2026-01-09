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
using System.Globalization;

using System.Collections;
using iPos.Inventario;

namespace iPos
{
    public partial class WFInventarioFisico : IposForm
    {
        CDOCTOBE m_Docto;
        CPRODUCTOBE m_prod;

        bool m_bFocusCodigo = false;
        bool m_bArrowsPressed = false;
        bool m_bPositionCantidadCell = false;
        decimal dMaxCantidad = 1000;
        bool m_manejaAlmacen = false;
        bool m_mostrarLookUpProductoSiVacio = false;

        bool m_bEsInventarioCiclico = false;

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

        public WFInventarioFisico()
        {
            InitializeComponent();
            try
            {
                m_prod = new CPRODUCTOBE();

                m_Docto = new CDOCTOBE();
                m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_INVENTARIO_FISICO;
                LlenarGrid();

                if (!(bool)iPos.CurrentUserID.CurrentParameters.isnull["IMAX_INV_FIS_CANT"])
                {
                    dMaxCantidad = iPos.CurrentUserID.CurrentParameters.IMAX_INV_FIS_CANT;
                }
                ESINVENTARIOCICLICOLabel.Visible = m_bEsInventarioCiclico;
            }
            catch { }
            
        }

        public WFInventarioFisico(bool bEsInventarioFCiclico):this()
        {
            this.m_bEsInventarioCiclico = bEsInventarioFCiclico;
            ESINVENTARIOCICLICOLabel.Visible = m_bEsInventarioCiclico;
        }



       public WFInventarioFisico(long doctoId)
            :this()
        {
            ObtenerDoctoDeBD(doctoId);
            LlenarGrid();



        }

        private void positionDataGridViewByCode(string strCode)
        {
            if (strCode == null || strCode.Trim().Length == 0)
                return;

            strCode = strCode.Trim();

            foreach(DataGridViewRow row in gET_INVFIS_LISTADETALLES_PDataGridView.Rows)
            {
                if (row.Index == gET_INVFIS_LISTADETALLES_PDataGridView.NewRowIndex)
                    {
                        continue;
                    }

                String productoFila = row.Cells["DGPRODUCTOCLAVE"].Value.ToString();
                    if(productoFila != null && productoFila.Trim().Equals(strCode))
                    {
                        gET_INVFIS_LISTADETALLES_PDataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                        gET_INVFIS_LISTADETALLES_PDataGridView.Rows[row.Index].Selected = true;
                        gET_INVFIS_LISTADETALLES_PDataGridView.CurrentCell = gET_INVFIS_LISTADETALLES_PDataGridView.Rows[row.Index].Cells["DGCANTIDADFISICA"];
                        return;
                    }
            }

            
        }

        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {
            
            int errorCode = 0;
            string strMensajeErr = "";
            bool mostrarLookUpProductoSiVacio = m_mostrarLookUpProductoSiVacio;
            m_mostrarLookUpProductoSiVacio = false;



            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod, TBCodigo.Text))
            {
                if (TBCodigo.Text.Trim().Length == 0 && !mostrarLookUpProductoSiVacio)
                    return;

                SeleccionarProducto(TBCodigo.Text.Trim(), ref TBCodigo);
                return;
            }

            if (prod.IESKIT != null && prod.IESKIT.Equals("S") && KITDESGLOSADOCheckBox.Checked )
            {
                MessageBox.Show("No se puede seleccionar un kit cuando estamos en un inventario con kits desglosado");
                e.Cancel = true;
                return;
            }


            m_prod = prod;


            short numeroDecimales = 2;
            if (prod != null)
            {
                numeroDecimales = CUNIDADD.numerDecimalesPorClaveUnidad(prod.IUNIDAD);
            }
            TBCantidad.NumericPrecision = 17 - numeroDecimales;
            TBCantidad.NumericScaleOnFocus = numeroDecimales;
            TBCantidad.NumericScaleOnLostFocus = numeroDecimales;



                //if (prod.IUNIDAD != null && prod.IUNIDAD.Trim().Equals("KG"))
                //{
                //    TBCantidad.NumericPrecision = 14;
                //    TBCantidad.NumericScaleOnFocus = 3;
                //    TBCantidad.NumericScaleOnLostFocus = 3;
                //}
                //else
                //{

                //    TBCantidad.NumericPrecision = 12;
                //    TBCantidad.NumericScaleOnFocus = 0;
                //    TBCantidad.NumericScaleOnLostFocus = 0;
                //}

                if (prod.IMANEJALOTE == "S")
            {
                pnlLotes.Visible = true;
                LlenarComboLotes(m_Docto != null ? m_Docto.IID : 0, prod.IID);
               
            }
            else
            {
                pnlLotes.Visible = false;
            }


            LlenarDatos((prod.IMANEJALOTE == "S"), prod);

            DataRow dr = this.dSInventarioFisico.GET_INVENTARIOFISICO_INFO.Rows[0];
            if(dr["ERRORCODE"] != DBNull.Value)
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

            positionDataGridViewByCode(prod.ICLAVE.Trim());


        }

        private void LlenarDatos(bool manejaLote, CPRODUCTOBE prod)
        {
            long? doctoId = null;
            string producto = prod != null ? prod.ICLAVE : TBCodigo.Text.Trim();
            string lote = "";
            DateTime? fechaVence = null;
            string kitDesglosado = KITDESGLOSADOCheckBox.Checked ? "S" : "N";


            long almacenid ;
            if (m_manejaAlmacen)
            {
                almacenid = this.ALMACENComboBox.SelectedIndex >= 0 ? int.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT;
            }
            else
            {
                almacenid = (int)DBValues._DOCTO_ALMACEN_DEFAULT;
            }

            if(manejaLote)
            {
                if (RBSeleccionLote.Checked)
                {
                    if(comboLote.SelectedIndex >= 0)
                    {
                        string[] aux = comboLote.Text.Split('|');
                        if (aux.Count() == 2)
                        {
                            lote = aux[0].Trim();
                            fechaVence = Convert.ToDateTime(aux[1]); 
                        }
                    }
                }
                else if (RBManualLote.Checked)
                {
                    lote = TBLote.Text;
                    fechaVence = DTPFechaVence.Value;
                }
            }

            if (!(bool)this.m_Docto.isnull["IID"])
            {
                doctoId = m_Docto.IID;
            }

            try
            {
                this.gET_INVENTARIOFISICO_INFOTableAdapter.Fill(this.dSInventarioFisico.GET_INVENTARIOFISICO_INFO, producto, lote, fechaVence,doctoId, almacenid, kitDesglosado,"S");
                
                /**wpf only starts*
                 gET_INVENTARIOFISICO_INFOBindingSource.View.MoveCurrentToFirst();
                 /**wpf only ends**/
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            LlenarProductosCaracteristicas(prod);


        }


        private void LlenarProductosCaracteristicas(CPRODUCTOBE prod)
        {
            string productoclave = prod != null ? prod.ICLAVE : TBCodigo.Text.Trim();





                this.TEXTO1TextBox.Text = "";
                this.TEXTO2TextBox.Text = "";
                this.TEXTO3TextBox.Text = "";
                this.TEXTO4TextBox.Text = "";
                this.NUMERO1TextBox.Text = "";
                this.NUMERO2TextBox.Text = "";
                this.NUMERO3TextBox.Text = "";
                this.NUMERO4TextBox.Text = "";

            if(productoclave != null && productoclave.Trim().Length > 0 && CurrentUserID.CurrentParameters.IMOSTRARINVINFOADICPROD != null && CurrentUserID.CurrentParameters.IMOSTRARINVINFOADICPROD.Equals("S"))
            {
                CPRODUCTOD prodD = new CPRODUCTOD();
                CPRODUCTOBE productoBE = new CPRODUCTOBE();
                productoBE.ICLAVE = productoclave;
                productoBE = prodD.seleccionarPRODUCTOPorClave(productoBE, null);

                if (productoBE != null)
                {

                    if (!(bool)productoBE.isnull["ITEXTO1"])
                        this.TEXTO1TextBox.Text = productoBE.ITEXTO1.ToString();

                    if (!(bool)productoBE.isnull["ITEXTO2"])
                        this.TEXTO2TextBox.Text = productoBE.ITEXTO2.ToString();

                    if (!(bool)productoBE.isnull["ITEXTO3"])
                        this.TEXTO3TextBox.Text = productoBE.ITEXTO3.ToString();

                    if (!(bool)productoBE.isnull["ITEXTO4"])
                        this.TEXTO4TextBox.Text = productoBE.ITEXTO4.ToString();

                    if (!(bool)productoBE.isnull["INUMERO1"])
                        this.NUMERO1TextBox.Text = productoBE.INUMERO1.ToString();

                    if (!(bool)productoBE.isnull["INUMERO2"])
                        this.NUMERO2TextBox.Text = productoBE.INUMERO2.ToString();

                    if (!(bool)productoBE.isnull["INUMERO3"])
                        this.NUMERO3TextBox.Text = productoBE.INUMERO3.ToString();

                    if (!(bool)productoBE.isnull["INUMERO4"])
                        this.NUMERO4TextBox.Text = productoBE.INUMERO4.ToString();

                }

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

        private bool bProductoSoloManejaKG(CPRODUCTOBE prod)
        {
            return prod != null && prod.IPZACAJA == 0 && prod.IUNIDAD != null && prod.IUNIDAD.Trim().ToUpper().Equals("KG");
        }

        private void Process()
        {


            if (m_manejaAlmacen)
            {
                if (this.ALMACENComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("por favor seleccione un almacen valido de la lista ");
                    return;
                }
            }


            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            string P_VD_VENDEDOR = CurrentUserID.CurrentUser.INOMBRE;
            string P_LOTE = "";
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            int? US_SUPERVISORID = null;
            int? ALMACENID = m_manejaAlmacen ? int.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT;/*CurrentUserID.CurrentUser.IUS_ALMACENID*/ ;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            long? SUCURSALTID = 0;
            long? ALMACENTID = 0;
            decimal? P_CANTIDAD_SURTIDA = null;
            bool bEsPrimeraEntrada = m_Docto == null || m_Docto.IID == 0;

            long? P_TIPODIFERENCIAINVENTARIOID = 0;


            if (TBCodigo.Text.Trim() == "")
            {
                MessageBox.Show("El texto de este control no debe estar vacio");
                return;
            }

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod, TBCodigo.Text))
            {

                MessageBox.Show("El producto no existe");
                return;
            }

             if (this.dSInventarioFisico.GET_INVENTARIOFISICO_INFO.Rows.Count < 0)
             {
                 MessageBox.Show("No se ha seleccionado un producto valido");
                 return;
             }

             DataRow dr = this.dSInventarioFisico.GET_INVENTARIOFISICO_INFO.Rows[0];

             if (dr["PRODUCTOID"] != DBNull.Value)
             {
                 P_IDPRODUCTO = (long)dr["PRODUCTOID"];
             }
             else
             {
                 MessageBox.Show("No se ha seleccionado un producto valido");
                 return;
             }



            if (CBCajasBotellas.Checked && !bProductoSoloManejaKG(prod))
            {
                Decimal cajas = Decimal.Parse(this.TBCajas.Text.ToString());
                P_CANTIDAD_SURTIDA = (cajas * (prod.IPZACAJA == 0 ? 1 : prod.IPZACAJA));
            }



            try
            {
                if (!P_CANTIDAD_SURTIDA.HasValue)
                    P_CANTIDAD_SURTIDA = 0;

                P_CANTIDAD_SURTIDA += decimal.Parse(TBCantidad.Text.Trim());
            }
            catch
            {
                MessageBox.Show("La cantidad no tiene el formato adecuado");
                return;
            }


            //if (!(bool)iPos.CurrentUserID.CurrentParameters.isnull["IMAX_INV_FIS_CANT"])
            //{
                if (P_CANTIDAD_SURTIDA >= dMaxCantidad /*iPos.CurrentUserID.CurrentParameters.IMAX_INV_FIS_CANT*/)
                {

                    if (MessageBox.Show("La cantidad parece ser muy grande , seguro que desea continuar con esa cantidad ", "Cantidad muy grande", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                }
            //}



            if (!(bool)this.m_Docto.isnull["IID"])
            {
                P_IDDOCTO = m_Docto.IID;
            }


            try
            {
                if (prod.IMANEJALOTE == "S")
                {
                    if (RBSeleccionLote.Checked)
                    {
                        if (comboLote.SelectedIndex >= 0)
                        {
                            string[] aux = comboLote.Text.Split('|');
                            if (aux.Count() == 2)
                            {
                                P_LOTE = aux[0].Trim();
                                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                                dtfi.ShortDatePattern = "dd/MM/yyyy";
                                dtfi.DateSeparator = "-";
                                P_FECHAVENCE = Convert.ToDateTime(aux[1], dtfi);
                            }
                            else
                            {

                                MessageBox.Show("No se ha pudo identificar a que lote pertenece este producto");
                                return;
                            }

                        }
                        else
                        {

                            MessageBox.Show("No se ha seleccionado un lote valido");
                            return;
                        }
                    }
                    else if (RBManualLote.Checked)
                    {
                        if (TBLote.Text.Trim().Length == 0)
                        {
                            MessageBox.Show("No se ha seleccionado un lote valido");
                            return;
                        }

                        P_LOTE = TBLote.Text;
                        P_FECHAVENCE = DTPFechaVence.Value;
                    }
                    else
                    {
                        MessageBox.Show("No se ha seleccionado un lote valido");
                        return;
                    }
                }
            }
            catch(Exception ex)
            {

                MessageBox.Show("No se ha seleccionado un producto valido " + ex.Message);
                return;
            }


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_VD_VENDEDOR, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_Docto.ITIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID,P_CANTIDAD_SURTIDA, null, fTrans))
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

                        if(this.m_bEsInventarioCiclico)
                        {

                            if (!CambiarACTIVO(null, this.m_bEsInventarioCiclico, ref mensajeKit))
                            {
                                MessageBox.Show("no se pudo poner como inventario ciclico");
                            }
                        }

                    }

                    ObtenerDoctoDeBD((long)P_IDDOCTO);

                   

                    PrepararSiguienteEntrada();
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
                    fConn.Close();
                    this.TBCodigo.Focus();
                }
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
        }


        private void PrepararSiguienteEntrada()
        {
            this.TBCantidad.Text = "";
            this.TBCajas.Text = "";
            TBLote.Text = "";
            comboLote.SelectedIndex = -1;
            //pnlLotes.Visible = false;
            this.LlenarDatos(false, null);
            //this.TBCodigo.Focus();
            //TBCodigo.Select(0,TBCodigo.Text.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process();

            this.TBCodigo.Focus();
            this.TBCodigo.Text = "";
            pnlLotes.Visible = false;

            //TBCodigo.Select(0, TBCodigo.Text.Length);
        }

        private void BTVerDiferencias_Click(object sender, EventArgs e)
        {
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
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
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

                P_IDDOCTO = (long)arParms[arParms.Length - 3].Value;
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        private void TBCantidad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Process();
                m_bFocusCodigo = true;
            }
        }

        private void TBCantidad_Leave(object sender, EventArgs e)
        {
            if (m_bFocusCodigo)
            {
                this.TBCodigo.Focus();
                this.TBCodigo.Text = "";
                m_bFocusCodigo = false;
                pnlLotes.Visible = false;
            }
        }

        private void TBCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_mostrarLookUpProductoSiVacio = true;

                if (TBCajas.Visible)
                {

                    this.TBCajas.Focus();
                    TBCajas.Select(0, TBCajas.Text.Length);
                }
                else
                {
                    this.TBCantidad.Focus();
                    TBCantidad.Select(0, TBCantidad.Text.Length);

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

                //todo esto tiene que ser condicionado
                if(KITDESGLOSADOCheckBox.Checked)
                {
                    this.gET_INVFIS_LISTADETALLES_PDataGridView.DataSource = this.gET_INVFIS_LISTADETALLES_PKITBindingSource;
                    this.gET_INVFIS_LISTADETALLES_PKITTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_LISTADETALLES_PKIT, (P_IDDOCTO.HasValue) ? P_IDDOCTO : 0, P_TODOSLOSPRODUCTOS/*, P_TODOSLOSPRODUCTOS*/);


                }
                else
                {
                    this.gET_INVFIS_LISTADETALLES_PDataGridView.DataSource = this.gET_INVFIS_LISTADETALLES_PBindingSource;
                    this.gET_INVFIS_LISTADETALLES_PTableAdapter.Fill(this.dSInventarioFisico2.GET_INVFIS_LISTADETALLES_P, (P_IDDOCTO.HasValue) ? P_IDDOCTO : 0, P_TODOSLOSPRODUCTOS/*, P_TODOSLOSPRODUCTOS*/);
                    
                }





                if (P_SOLODIFERENCIAS == 1)
                    this.gET_INVFIS_LISTADETALLES_PBindingSource.Filter = "CANTIDADDIFERENCIA <> 0";
                else
                    this.gET_INVFIS_LISTADETALLES_PBindingSource.Filter = "";

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void gET_INVFIS_LISTADETALLES_PDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex == gET_INVFIS_LISTADETALLES_PDataGridView.NewRowIndex)
                return;

            if (gET_INVFIS_LISTADETALLES_PDataGridView.Columns["DGCANTIDADFISICA"].Index != e.ColumnIndex)
                return;


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
                


                CPRODUCTOBE prod = new CPRODUCTOBE();
                if (!BuscarProducto(ref prod, TBCodigo.Text))
                {
                    SeleccionarProducto(TBCodigo.Text.Trim(), ref TBCodigo);
                    return;
                }

                LlenarDatos(false, prod);


                short numeroDecimales = 2;
                if (prod != null)
                {
                    numeroDecimales = CUNIDADD.numerDecimalesPorClaveUnidad(prod.IUNIDAD);
                }
                TBCantidad.NumericPrecision = 17 - numeroDecimales;
                TBCantidad.NumericScaleOnFocus = numeroDecimales;
                TBCantidad.NumericScaleOnLostFocus = numeroDecimales;

                TBCantidad.Text = dEntrada.ToString("N" + numeroDecimales.ToString());

                //if (prod.IUNIDAD != null && prod.IUNIDAD.Trim().Equals("KG"))
                //{
                //    TBCantidad.NumericPrecision = 14;
                //    TBCantidad.NumericScaleOnFocus = 3;
                //    TBCantidad.NumericScaleOnLostFocus = 3;
                //    TBCantidad.Text = dEntrada.ToString("N3");
                //}
                //else
                //{

                //    TBCantidad.NumericPrecision = 12;
                //    TBCantidad.NumericScaleOnFocus = 0;
                //    TBCantidad.NumericScaleOnLostFocus = 0;
                //    TBCantidad.Text = dEntrada.ToString("N0");
                //}




                RBManualLote.Checked = true;
                RBSeleccionLote.Checked = false;

                try
                {
                    TBLote.Text = gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["LOTE"].Value.ToString();

                }
                catch
                {
                    TBLote.Text = "";
                }

                try
                {
                    DTPFechaVence.Value = (DateTime)gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["FECHAVENCE"].Value;
                }
                catch
                {
                    DTPFechaVence.Value = DateTime.Today;
                }



                Process();

                if (!this.m_bArrowsPressed)
                {
                    m_bFocusCodigo = true;
                }
                else
                {
                    m_bPositionCantidadCell = true;
                    this.m_bArrowsPressed = false;
                }
                return;
            }
            catch
            {
                MessageBox.Show("Cheque el formato de entrada del valor");
                e.Cancel = true;
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

            if (m_bFocusCodigo)
            {
                this.TBCodigo.Focus();
                this.TBCodigo.Text = "";
                m_bFocusCodigo = false;
                pnlLotes.Visible = false;
            }
        }

        private void ActualizaTablasDeControl()
        {
            WFActualizandoKITMultiNivel wf = new WFActualizandoKITMultiNivel();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void WFInventarioFisico_Load(object sender, EventArgs e)
        {
            ActualizaTablasDeControl();

            this.TBCantidadMaxima.Text = this.dMaxCantidad.ToString("N0");
            FormatearCamposPersonalizados();
            formatGridColumnProductoCaracteristicas();

            


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

            }


        }

        private void TBCantidadMaxima_Validated(object sender, EventArgs e)
        {
            if (this.TBCantidadMaxima.Text != "")
            {
                this.dMaxCantidad = decimal.Parse(this.TBCantidadMaxima.Text);
            }
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

        private void gET_INVFIS_LISTADETALLES_PDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LlenarComboLotes(long doctoId, long productoId)
        {
            try
            {
                this.r_LISTALOTESINVENTARIOTableAdapter.Fill(this.dSInventarioFisico2.R_LISTALOTESINVENTARIO,doctoId, productoId, CBLotesConExistenciaCombo.Checked ? "S" : "N");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void comboLote_Validated(object sender, EventArgs e)
        {
            LlenarDatos(true, m_prod);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.RBSeleccionLote.Checked = true;
            for (int i = 0; i < comboLote.Items.Count; i++)
            {
                comboLote.SelectedIndex = i;
                TBCantidad.Text = "0";
                TBCajas.Text = "0";
                Process();
            }

        }

        private void CBLotesConExistenciaCombo_CheckedChanged(object sender, EventArgs e)
        {
            try{

                LlenarComboLotes(m_Docto.IID, m_prod.IID);
            }
            catch{
            }
        }

        private void TBPosicionar_Validating(object sender, CancelEventArgs e)
        {



            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod, TBPosicionar.Text))
            {
                SeleccionarProducto(TBPosicionar.Text.Trim(), ref TBPosicionar);
                return;
            }


            positionDataGridViewByCode(prod.ICLAVE.Trim());
        }

        private void TBPosicionar_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.gET_INVFIS_LISTADETALLES_PDataGridView.Focus();
            }
        }

        private void gET_INVFIS_LISTADETALLES_PDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                this.m_bArrowsPressed = true;
            }
            else
            {
                this.m_bArrowsPressed = false;
                m_bPositionCantidadCell = false;
            }
        }

        private void gET_INVFIS_LISTADETALLES_PDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                DataGridViewTextBoxEditingControl tb = e.Control as DataGridViewTextBoxEditingControl;
                tb.PreviewKeyDown -= gET_INVFIS_LISTADETALLES_PDataGridView_PreviewKeyDown;
                tb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(gET_INVFIS_LISTADETALLES_PDataGridView_PreviewKeyDown);
            }
        }

        private void gET_INVFIS_LISTADETALLES_PDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (m_bPositionCantidadCell)
            {

                m_bPositionCantidadCell = false;

                    /**winforms only starts**/
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    /**winforms only ends**/

                    gET_INVFIS_LISTADETALLES_PDataGridView.CurrentCell = gET_INVFIS_LISTADETALLES_PDataGridView.Rows[e.RowIndex].Cells["DGCANTIDADFISICA"];

                    /**winforms only starts**/
                }));
                /**winforms only ends**/


            }
        }



        private void FormatearCamposPersonalizados()
        {
            this.pnlProdCaracteristicas.Visible = CurrentUserID.CurrentParameters.IMOSTRARINVINFOADICPROD != null && CurrentUserID.CurrentParameters.IMOSTRARINVINFOADICPROD.Equals("S");
            try
            {
                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] && CurrentUserID.CurrentParameters.ITEXTO1 != "")
                {

                    this.TEXTO1Label.Visible = true;
                    this.TEXTO1TextBox.Visible = true;
                    this.TEXTO1Label.Text = CurrentUserID.CurrentParameters.ITEXTO1;
                }
                else
                {
                    this.TEXTO1Label.Visible = false;
                    this.TEXTO1TextBox.Visible = false;
                }



                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO2"] && CurrentUserID.CurrentParameters.ITEXTO2 != "")
                {

                    this.TEXTO2Label.Visible = true;
                    this.TEXTO2TextBox.Visible = true;
                    this.TEXTO2Label.Text = CurrentUserID.CurrentParameters.ITEXTO2;
                }
                else
                {
                    this.TEXTO2Label.Visible = false;
                    this.TEXTO2TextBox.Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO3"] && CurrentUserID.CurrentParameters.ITEXTO3 != "")
                {

                    this.TEXTO3Label.Visible = true;
                    this.TEXTO3TextBox.Visible = true;
                    this.TEXTO3Label.Text = CurrentUserID.CurrentParameters.ITEXTO3;
                }
                else
                {
                    this.TEXTO3Label.Visible = false;
                    this.TEXTO3TextBox.Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO4"] && CurrentUserID.CurrentParameters.ITEXTO4 != "")
                {

                    this.TEXTO4Label.Visible = true;
                    this.TEXTO4TextBox.Visible = true;
                    this.TEXTO4Label.Text = CurrentUserID.CurrentParameters.ITEXTO4;
                }
                else
                {
                    this.TEXTO4Label.Visible = false;
                    this.TEXTO4TextBox.Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO1"] && CurrentUserID.CurrentParameters.INUMERO1 != "")
                {

                    this.NUMERO1Label.Visible = true;
                    this.NUMERO1TextBox.Visible = true;
                    this.NUMERO1Label.Text = CurrentUserID.CurrentParameters.INUMERO1;
                }
                else
                {
                    this.NUMERO1Label.Visible = false;
                    this.NUMERO1TextBox.Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO2"] && CurrentUserID.CurrentParameters.INUMERO2 != "")
                {

                    this.NUMERO2Label.Visible = true;
                    this.NUMERO2TextBox.Visible = true;
                    this.NUMERO2Label.Text = CurrentUserID.CurrentParameters.INUMERO2;
                }
                else
                {
                    this.NUMERO2Label.Visible = false;
                    this.NUMERO2TextBox.Visible = false;
                }



                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO3"] && CurrentUserID.CurrentParameters.INUMERO3 != "")
                {

                    this.NUMERO3Label.Visible = true;
                    this.NUMERO3TextBox.Visible = true;
                    this.NUMERO3Label.Text = CurrentUserID.CurrentParameters.INUMERO3;
                }
                else
                {
                    this.NUMERO3Label.Visible = false;
                    this.NUMERO3TextBox.Visible = false;
                }



                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO4"] && CurrentUserID.CurrentParameters.INUMERO4 != "")
                {

                    this.NUMERO4Label.Visible = true;
                    this.NUMERO4TextBox.Visible = true;
                    this.NUMERO4Label.Text = CurrentUserID.CurrentParameters.INUMERO4;
                }
                else
                {
                    this.NUMERO4Label.Visible = false;
                    this.NUMERO4TextBox.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }





        public void formatGridColumnProductoCaracteristicas()
        {
            if (CurrentUserID.CurrentParameters.IMOSTRARINVINFOADICPROD != null && CurrentUserID.CurrentParameters.IMOSTRARINVINFOADICPROD.Equals("S"))
            {
                try
                {
                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] && CurrentUserID.CurrentParameters.ITEXTO1 != "")
                    {

                        this.DGTEXTO1.Visible = true;
                        this.DGTEXTO1.HeaderText = CurrentUserID.CurrentParameters.ITEXTO1;
                    }
                    else
                    {

                        this.DGTEXTO1.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO2"] && CurrentUserID.CurrentParameters.ITEXTO2 != "")
                    {

                        this.DGTEXTO2.Visible = true;
                        this.DGTEXTO2.HeaderText = CurrentUserID.CurrentParameters.ITEXTO2;
                    }
                    else
                    {

                        this.DGTEXTO2.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO3"] && CurrentUserID.CurrentParameters.ITEXTO3 != "")
                    {

                        this.DGTEXTO3.Visible = true;
                        this.DGTEXTO3.HeaderText = CurrentUserID.CurrentParameters.ITEXTO3;
                    }
                    else
                    {

                        this.DGTEXTO3.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO4"] && CurrentUserID.CurrentParameters.ITEXTO4 != "")
                    {

                        this.DGTEXTO4.Visible = true;
                        this.DGTEXTO4.HeaderText = CurrentUserID.CurrentParameters.ITEXTO4;
                    }
                    else
                    {

                        this.DGTEXTO4.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO5"] && CurrentUserID.CurrentParameters.ITEXTO5 != "")
                    {

                        this.DGTEXTO5.Visible = true;
                        this.DGTEXTO5.HeaderText = CurrentUserID.CurrentParameters.ITEXTO5;
                    }
                    else
                    {

                        this.DGTEXTO5.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO6"] && CurrentUserID.CurrentParameters.ITEXTO6 != "")
                    {

                        this.DGTEXTO6.Visible = true;
                        this.DGTEXTO6.HeaderText = CurrentUserID.CurrentParameters.ITEXTO6;
                    }
                    else
                    {

                        this.DGTEXTO6.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO1"] && CurrentUserID.CurrentParameters.INUMERO1 != "")
                    {

                        this.DGNUMERO1.Visible = true;
                        this.DGNUMERO1.HeaderText = CurrentUserID.CurrentParameters.INUMERO1;
                    }
                    else
                    {

                        this.DGNUMERO1.Visible = false;
                    }




                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO2"] && CurrentUserID.CurrentParameters.INUMERO2 != "")
                    {

                        this.DGNUMERO2.Visible = true;
                        this.DGNUMERO2.HeaderText = CurrentUserID.CurrentParameters.INUMERO2;
                    }
                    else
                    {

                        this.DGNUMERO2.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO3"] && CurrentUserID.CurrentParameters.INUMERO3 != "")
                    {

                        this.DGNUMERO3.Visible = true;
                        this.DGNUMERO3.HeaderText = CurrentUserID.CurrentParameters.INUMERO3;
                    }
                    else
                    {

                        this.DGNUMERO3.Visible = false;
                    }

                    if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO4"] && CurrentUserID.CurrentParameters.INUMERO4 != "")
                    {

                        this.DGNUMERO4.Visible = true;
                        this.DGNUMERO4.HeaderText = CurrentUserID.CurrentParameters.INUMERO4;
                    }
                    else
                    {

                        this.DGNUMERO4.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA1"] && CurrentUserID.CurrentParameters.IFECHA1 != "")
                    {

                        this.DGFECHA1.Visible = true;
                        this.DGFECHA1.HeaderText = CurrentUserID.CurrentParameters.IFECHA1;
                    }
                    else
                    {

                        this.DGFECHA1.Visible = false;
                    }


                    if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA2"] && CurrentUserID.CurrentParameters.IFECHA2 != "")
                    {

                        this.DGFECHA2.Visible = true;
                        this.DGFECHA2.HeaderText = CurrentUserID.CurrentParameters.IFECHA2;
                    }
                    else
                    {

                        this.DGFECHA2.Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
                LOTE.Visible = false;
                FECHAVENCE.Visible = false;
            }
            else
            {

                DGTEXTO1.Visible = false;
                DGTEXTO2.Visible = false;
                DGTEXTO3.Visible = false;
                DGTEXTO4.Visible = false;
                DGTEXTO5.Visible = false;
                DGTEXTO6.Visible = false;
                DGNUMERO1.Visible = false;
                DGNUMERO2.Visible = false;
                DGNUMERO3.Visible = false;
                DGNUMERO4.Visible = false;
                DGFECHA1.Visible = false;
                DGFECHA2.Visible = false;
                LOTE.Visible = true;
                FECHAVENCE.Visible = true;
            }
        }



        private void CBCajasBotellas_CheckedChanged(object sender, EventArgs e)
        {
            formatCajasBotellasPiezas(CBCajasBotellas.Checked);
        }


        private void formatCajasBotellasPiezas(bool cajasYBotellas)
        {
            if (cajasYBotellas)
            {
                TBCajas.Visible = true;
                lblCajas.Visible = true;
                lblCantidad.Text = "Botellas";
                TBCajas.Text = "0";
                TBCantidad.Text = "0";



            }
            else
            {
                TBCajas.Visible = false;
                lblCajas.Visible = false;
                lblCantidad.Text = "Cantidad";
                TBCajas.Text = "0";
                TBCantidad.Text = "1";
            }

        }

        private void TBCajas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            //if (e.KeyCode == Keys.Enter)
            //{
            //    TBCantidad.Focus();
            //    TBCantidad.Select(0, TBCantidad.Text.Length);
            //}
        }

        private void TBCajas_Leave(object sender, EventArgs e)
        {

            if (m_bFocusCodigo)
            {
                this.TBCodigo.Focus();
                this.TBCodigo.Text = "";
                m_bFocusCodigo = false;
                pnlLotes.Visible = false;
            }
        }

       

        private bool CambiarKITDESGLOSADO(FbTransaction st, bool bDesglosarKits, ref string message)
        {
            CDOCTOD doctoD = new CDOCTOD();
            m_Docto.IKITDESGLOSADO = bDesglosarKits  ? "S" : "N";
            if(!doctoD.CambiarKITDESGLOSADODOCTOD(m_Docto, st))
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


        private void KITDESGLOSADOCheckBox_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void KITDESGLOSADOCheckBox_Validated(object sender, EventArgs e)
        {
        }

        private void KITDESGLOSADOCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void KITDESGLOSADOCheckBox_Click(object sender, EventArgs e)
        {

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
    }
}
