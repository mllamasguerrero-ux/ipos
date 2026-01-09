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

namespace iPos
{
    public partial class WFIntercambioLotes : Form
    {

        CPRODUCTOBE m_prod = null;
        bool m_manejaAlmacen = false;


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


        public WFIntercambioLotes()
        {
            InitializeComponent();
        }

        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {


            //int errorCode = 0;
            //string strMensajeErr = "";



            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod, TBCodigo.Text))
            {
                SeleccionarProducto(TBCodigo.Text.Trim(), ref TBCodigo);
                return;
            }

            m_prod = prod;


            short numeroDecimales = 2;
            if (prod != null)
            {
                numeroDecimales = CUNIDADD.numerDecimalesPorClaveUnidad(prod.IUNIDAD);
            }
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
                LlenarComboLotes( 0, prod.IID);
            }
            else
            {
                pnlLotes.Visible = false;
            }

            pRODUCTONOMBRETextBox.Text = prod.INOMBRE;
            pRODUCTODESCRIPCIONTextBox.Text = prod.IDESCRIPCION1;


            LlenarDatos((prod.IMANEJALOTE == "S"));

            /*DataRow dr = this.dSInventarioFisico.GET_INVENTARIOFISICO_INFO.Rows[0];
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

            positionDataGridViewByCode(prod.ICLAVE.Trim());*/


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

        

        private void LlenarComboLotes(long doctoId, long productoId)
        {
            LlenarComboLotesSalida(doctoId, productoId);
            LlenarComboLotesEntrada(doctoId, productoId);
        }

        private void LlenarComboLotesSalida(long doctoId, long productoId)
        {
            try
            {
                this.r_LISTALOTESINVENTARIOTableAdapter.Fill(this.dSInventarioFisico2.R_LISTALOTESINVENTARIO, doctoId, productoId,  "S");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void LlenarComboLotesEntrada(long doctoId, long productoId)
        {
            try
            {
                this.r_LISTALOTESINVENTARIOTableAdapter.Fill(this.dsInventarioFisico21.R_LISTALOTESINVENTARIO, doctoId, productoId, "N");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }



        private void LlenarDatos(bool manejaLote)
        {
            //long? doctoId = null;
            string producto = TBCodigo.Text.Trim();
            string lote = "";
            DateTime? fechaVence = null;


            long almacenid;
            if (m_manejaAlmacen)
            {
                almacenid = this.ALMACENComboBox.SelectedIndex >= 0 ? int.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT;
            }
            else
            {
                almacenid = (int)DBValues._DOCTO_ALMACEN_DEFAULT;
            }

            if (manejaLote)
            {
                if (RBSeleccionLote.Checked)
                {
                    if (comboLote.SelectedIndex >= 0)
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

            /*if (!(bool)this.m_Docto.isnull["IID"])
            {
                doctoId = m_Docto.IID;
            }*/

            try
            {
                this.gET_INVENTARIOFISICO_INFOTableAdapter.Fill(this.dSInventarioFisico.GET_INVENTARIOFISICO_INFO, producto, lote, fechaVence, 0, almacenid,"N","S");
                /**wpf only starts*
                 gET_INVENTARIOFISICO_INFOBindingSource.View.MoveCurrentToFirst();
                 /**wpf only ends**/
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnAgregarAMovimientos_Click(object sender, EventArgs e)
        {
            if (!validarCantidadFisicaYTeorica())
                return;


            if (m_manejaAlmacen)
            {
                if (this.ALMACENComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("por favor seleccione un almacen valido de la lista ");
                    return;
                }

                //if (this.ALMACENDestinoComboBox.SelectedIndex < 0)
                //{
                //    MessageBox.Show("por favor seleccione un almacen valido de la lista ");
                //    return;
                //}
            }


            string loteSource = null, loteDestino = null;
            DateTime fechaVenceSource = DateTime.Today, fechaVenceDestino = DateTime.Today;
            if (comboLote.SelectedIndex >= 0)
            {
                string[] aux = comboLote.Text.Split('|');
                if (aux.Count() == 2)
                {
                    loteSource = aux[0].Trim();
                    DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                    dtfi.ShortDatePattern = "dd/MM/yyyy";
                    dtfi.DateSeparator = "-";
                    fechaVenceSource = Convert.ToDateTime(aux[1], dtfi);
                }
                else
                {

                    MessageBox.Show("No se ha pudo identificar a que lote pertenece este producto");
                    return;
                }

            }


            if (RBSeleccionLote.Checked)
            {
                if (comboLoteDestino.SelectedIndex >= 0)
                {
                    string[] aux = comboLoteDestino.Text.Split('|');
                    if (aux.Count() == 2)
                    {
                        loteDestino = aux[0].Trim();
                        DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                        dtfi.ShortDatePattern = "dd/MM/yyyy";
                        dtfi.DateSeparator = "-";
                        fechaVenceDestino = Convert.ToDateTime(aux[1], dtfi);
                    }
                    else
                    {

                        MessageBox.Show("No se ha pudo identificar a que lote pertenece este producto");
                        return;
                    }

                }
            }
            else if (RBManualLote.Checked)
            {
                if (TBLote.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No se ha seleccionado un lote valido");
                    return;
                }

                loteDestino = TBLote.Text;
                fechaVenceDestino = DTPFechaVence.Value;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un lote valido");
                return;
            }


            if(loteSource.Equals(loteDestino) &&
                fechaVenceSource.Equals(fechaVenceDestino))
            {

                MessageBox.Show("El lote-fechavence origen y destino no pueden ser iguales");
                return;
            }

            foreach(iPos.Inventario.DSInventarioFisico3.TEMPINTERCAMBIORow item in this.dSInventarioFisico3.TEMPINTERCAMBIO.Rows)
            {
                if((item.LOTE.Equals(loteDestino) && item.FECHAVENCE.Equals(fechaVenceDestino)) ||
                    (item.LOTEDESTINO.Equals(loteSource) && item.FECHAVENCEDESTINO.Equals(fechaVenceSource))
                    )
                {
                    MessageBox.Show("Si ya uso un lote como origen ya solo lo puede usar como origen, e igualmente si ya uso un lote como destino solo lo puede usar como destino en una aplicacion");
                    return;
                }

            }


            iPos.Inventario.DSInventarioFisico3.TEMPINTERCAMBIORow newCustomersRow = this.dSInventarioFisico3.TEMPINTERCAMBIO.NewTEMPINTERCAMBIORow();

            newCustomersRow.PRODUCTOID = m_prod.IID;
            newCustomersRow.ALMACENID = m_manejaAlmacen ? int.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT ;
            newCustomersRow.ALMACENIDDESTINO = newCustomersRow.ALMACENID;// m_manejaAlmacen ? int.Parse(this.ALMACENDestinoComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT;
            newCustomersRow.LOTE = loteSource;
            newCustomersRow.FECHAVENCE = fechaVenceSource;
            newCustomersRow.LOTEDESTINO = loteDestino;
            newCustomersRow.FECHAVENCEDESTINO = fechaVenceDestino;
            newCustomersRow.CANTIDAD = Decimal.Parse(TBCantidad.Text);
            try
            {
                newCustomersRow.EXISTENCIA = Decimal.Parse(cANTIDADTEORICATextBox.Text);
            }
            catch
            {
                newCustomersRow.EXISTENCIA = 0;
            }
            newCustomersRow.EXISTINSUF = "N";

            this.dSInventarioFisico3.TEMPINTERCAMBIO.AddTEMPINTERCAMBIORow(newCustomersRow);
            TBCodigo.Text = "";
            pRODUCTONOMBRETextBox.Text = "";
            pRODUCTODESCRIPCIONTextBox.Text = "";
            comboLote.Text = "";
            TBCantidad.Text = "";
            ALMACENComboBox.Text = "";
            //ALMACENDestinoComboBox.Text = "";
            comboLoteDestino.Text = "";
            TBLote.Text = "";
            DTPFechaVence.ResetText();
            cANTIDADTEORICATextBox.Text = "";
        }

        private void WFIntercambioLotes_Load(object sender, EventArgs e)
        {

            m_manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));
            if (!m_manejaAlmacen)
            {
                this.ALMACENComboBox.Visible = false;
                this.lblAlmacen.Visible = false;
                //this.ALMACENDestinoComboBox.Visible = false;
                //this.lblAlmacenDestino.Visible = false;
            }
            else
            {
                this.ALMACENComboBox.Visible = true;
                this.lblAlmacen.Visible = true;
                //this.ALMACENDestinoComboBox.Visible = true;
                //this.lblAlmacenDestino.Visible = true;

                this.ALMACENComboBox.llenarDatos();
                try
                {
                    this.ALMACENComboBox.SelectedIndex = -1;
                }
                catch
                {
                }

                //this.ALMACENDestinoComboBox.llenarDatos();
                //try
                //{
                //    this.ALMACENDestinoComboBox.SelectedIndex = -1;
                //}
                //catch
                //{
                //}

            }
        }



        private bool refreshAvailability()
        {
            bool bHayExistenciaSuficiente = true;
            
            CPRODUCTOD prod = new CPRODUCTOD();
            foreach (iPos.Inventario.DSInventarioFisico3.TEMPINTERCAMBIORow row in this.dSInventarioFisico3.TEMPINTERCAMBIO)
            {
                decimal existencia = prod.GetExistenciaPorLote(row.PRODUCTOID, row.LOTE, row.FECHAVENCE, null);
                row.EXISTENCIA = existencia;
                row.EXISTINSUF = existencia < row.CANTIDAD ? "S" : "N";

                if (existencia < row.CANTIDAD)
                    bHayExistenciaSuficiente = false;
                
            }
            coloreaGrid();
            return bHayExistenciaSuficiente;
        }


        private void coloreaGrid()
        {
            foreach (DataGridViewRow row in tEMPINTERCAMBIODataGridView.Rows)
            {

                coloreaRow(row);
            }
        }

        private void coloreaRow(DataGridViewRow row)
        {

            
            string existenciainsuficiente = "N";

            try
            {
                if (row.Cells["DGEXISTINSUF"].Value != DBNull.Value)
                {
                    existenciainsuficiente = row.Cells["DGEXISTINSUF"].Value.ToString();
                }



                if (existenciainsuficiente == "S")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            catch
            {

                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

        }


        private void btnAplicarMovimiento_Click(object sender, EventArgs e)
        {
            if(!refreshAvailability())
            {
                MessageBox.Show("Hay movimientos sin existencias suficientes");
                return;
            }

            Process();

            TBCodigo.Text = "";
            pRODUCTONOMBRETextBox.Text = "";
            pRODUCTODESCRIPCIONTextBox.Text = "";
            comboLote.Text = "";
            TBCantidad.Text = "";
            ALMACENComboBox.Text = "";
            //ALMACENDestinoComboBox.Text = "";
            comboLoteDestino.Text = "";
            TBLote.Text = "";
            DTPFechaVence.ResetText();
            cANTIDADTEORICATextBox.Text = "";
        }

        private void Process()
        {
            long doctoEntradas = 0;
            long doctoSalidas = 0;

            if(this.dSInventarioFisico3.TEMPINTERCAMBIO != null && this.dSInventarioFisico3.TEMPINTERCAMBIO.Rows.Count > 0)
            {


                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;

                try
                {
                    fConn.Open();
                    fTrans = fConn.BeginTransaction();
                    foreach (iPos.Inventario.DSInventarioFisico3.TEMPINTERCAMBIORow row in this.dSInventarioFisico3.TEMPINTERCAMBIO)
                    {
                        if (!ProcessLine(row.PRODUCTOID, row.ALMACENID, row.LOTE, row.FECHAVENCE, row.CANTIDAD, DBValues._DOCTO_TIPO_CAMBIOLOTES_SALIDA, ref doctoSalidas, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show("Ocurrio un error " + this.iComentario);
                            return;
                        }

                        if (!ProcessLine(row.PRODUCTOID, row.ALMACENIDDESTINO, row.LOTEDESTINO, row.FECHAVENCEDESTINO, row.CANTIDAD, DBValues._DOCTO_TIPO_CAMBIOLOTES_ENTRADA, ref doctoEntradas, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show("Ocurrio un error " + this.iComentario);
                            return;
                        }
                    }

                    if (doctoEntradas != 0 && doctoSalidas != 0)
                    {
                        CDOCTOBE doctoBEEntrada = new CDOCTOBE();
                        doctoBEEntrada.IID = doctoEntradas;
                        if (!CerrarTransaccion(doctoBEEntrada, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show("Ocurrio un error al terminar el docto " + this.iComentario);
                            return;
                        }

                        CDOCTOBE doctoBESalida = new CDOCTOBE();
                        doctoBESalida.IID = doctoSalidas;
                        if (!CerrarTransaccion(doctoBESalida, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show("Ocurrio un error al terminar el docto " + this.iComentario);
                            return;
                        }
                    }

                    fTrans.Commit();
                    fConn.Close();

                    MessageBox.Show("Se aplicaron los movimientos");
                    this.dSInventarioFisico3.TEMPINTERCAMBIO.Clear();
                }
                catch (Exception ex)
                {
                    try
                    {
                        fTrans.Rollback();
                    }
                    catch
                    {

                    }

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    fConn.Close();
                }

                

            }

        }


        private bool ProcessLine(long productoId, long almacenId, string lote, DateTime fechavence, decimal cantidad, long tipoDoctoId, ref long idDocto, FbTransaction fTrans)
        {

            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            string P_VD_VENDEDOR = CurrentUserID.CurrentUser.INOMBRE;
            string P_LOTE = "";
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            int? US_SUPERVISORID = null;
            int? ALMACENID = (int)almacenId ;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            long? SUCURSALTID = 0;
            long? ALMACENTID = 0;
            long? P_TIPODIFERENCIAINVENTARIOID = 0;
            decimal? P_CANTIDAD_SURTIDA = null;
            long P_TIPODOCTOID = tipoDoctoId;


            if (productoId == 0)
            {
               this.iComentario = "El producto no puede estar vacio";
                return false;
            }

            P_IDPRODUCTO = productoId;
             P_CANTIDAD = cantidad;



            if (idDocto != 0)
            {
                P_IDDOCTO = idDocto;
            }

            P_LOTE = lote;
            P_FECHAVENCE = fechavence;


            try
            {
                if (EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_VD_VENDEDOR, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, P_TIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_CANTIDAD_SURTIDA, null, fTrans))
                {
                    idDocto = (long)P_IDDOCTO;

                    return true;
                }

                 return false;
            }
            catch (Exception ex)
            {

                this.iComentario = ex.Message;
                return false;

            }
            finally
            {
                
            }
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


        public bool CerrarTransaccion(CDOCTOBE docto, FbTransaction st)
        {
            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.CerrarDOCTOD(docto, st))
            {
                this.IComentario = doctoD.IComentario;
                return false;
            }
            else
            {
                return true;
            }
        }


        private void TBCodigo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.comboLote.Focus();
            }
        }

        public bool validarCantidadFisicaYTeorica()
        {
            try
            {
                decimal dCantidad = Decimal.Parse(TBCantidad.Text);
                decimal dCantidadTeorica = Decimal.Parse(cANTIDADTEORICATextBox.Text);

                if (dCantidad > dCantidadTeorica)
                {
                    MessageBox.Show("Esta intentando intercambiar mas cantidad de la que hay de ese lote");
                    return false;
                }

            }
            catch (Exception ex)
            {

            }

            return true;
        }

        private void TBCantidad_Validated(object sender, EventArgs e)
        {
            validarCantidadFisicaYTeorica();
        }



      


        private void tEMPINTERCAMBIODataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex != -1)
            {

                if (tEMPINTERCAMBIODataGridView.Columns[e.ColumnIndex].Name == "BTEliminar")
                {
                     int dgDoctoId = (int)tEMPINTERCAMBIODataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                     this.dSInventarioFisico3.TEMPINTERCAMBIO.Rows.Find(dgDoctoId).Delete();
                }
            }
        }

        private void comboLote_Validated(object sender, EventArgs e)
        {
            LlenarDatos(true);
        }

        private void comboLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LlenarDatos(true);
                this.TBCantidad.Focus();
            }
        }





    }
}
