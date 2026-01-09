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
    public partial class WFDesTrasladoProdProm : IposForm
    {
        CDOCTOBE m_Docto;
        CPRODUCTOBE m_prod;
        bool m_bFocusCodigo = false;

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

        public WFDesTrasladoProdProm()
        {
            InitializeComponent();
            m_prod = new CPRODUCTOBE();
            m_Docto = new CDOCTOBE();
            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_DESTRASLADO_PRODUCTO_PROMOCION;
            LlenarGrid();
            
        }

        private void TBCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                validCodigo();

                this.TBCantidad.Focus();
                TBCantidad.Select(0, TBCantidad.Text.Length);
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

        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {

            if (TBCodigo.Text.Trim() == "")
            {
                return;
            }

            if (!validCodigo())
            {
                e.Cancel = true;
            }

        }


        private bool validCodigo()
        {

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                SeleccionarProducto(TBCodigo.Text.Trim());
                return true;
            }

            if (prod.IESPRODPROMO == null || prod.IESPRODPROMO.Equals("N") ||
                    prod.IVIGENCIAPRODPROMO == null || prod.IVIGENCIAPRODPROMO.CompareTo(DateTime.Today) < 0)
            {
                MessageBox.Show("El producto o no es promocional o no esta en vigencia");
                return false;

            }

            m_prod = prod;
            LlenarDatos();

            return true;
        }


        private void LlenarDatos()
        {
            if (m_prod != null)
            {
                this.pRODUCTODESCRIPCIONTextBox.Text = m_prod.IDESCRIPCION;
                this.pRODUCTONOMBRETextBox.Text = m_prod.INOMBRE;
                this.cANTIDADTEORICATextBox.Text = m_prod.IEXISTENCIA.ToString();
            }
            else
            {

                this.pRODUCTODESCRIPCIONTextBox.Text = "";
                this.pRODUCTONOMBRETextBox.Text = "";
                this.cANTIDADTEORICATextBox.Text = "";
            }
        }

        private void LlenarGrid()
        {
            try
            {
                int P_IDDOCTO = 0;
                if (!(bool)this.m_Docto.isnull["IID"])
                {
                    P_IDDOCTO = (int)m_Docto.IID;
                }
                if (P_IDDOCTO == 0)
                {
                    this.dSProductoPromocion.TRASLADOPROMODETALLE.Clear();
                    return;
                }

                 this.tRASLADOPROMODETALLETableAdapter.Fill(this.dSProductoPromocion.TRASLADOPROMODETALLE, P_IDDOCTO);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        private void ClearDocto()
        {

            m_prod = new CPRODUCTOBE();
            m_Docto = new CDOCTOBE();
            m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_DESTRASLADO_PRODUCTO_PROMOCION;
            m_Docto.IALMACENID = DBValues._DOCTO_ALMACEN_DEFAULT;
            m_Docto.IALMACENTID = DBValues._DOCTO_ALMACEN_DEFAULT;


            LlenarGrid();
            LlenarDatos();



            this.LBConsecutivo.Text = m_Docto.IID.ToString();
            this.LBFolio.Text = m_Docto.IFOLIO.ToString();
            this.LBDateValue.Text = m_Docto.IFECHA.ToShortDateString();
            this.ALMACENDestinoComboBox.Enabled = this.m_manejaAlmacen;
        }



        private void Process()
        {



            if (m_manejaAlmacen && (this.ALMACENDestinoComboBox.SelectedDataValue == null  && int.Parse(this.ALMACENDestinoComboBox.SelectedValue.ToString()) <= 0 ))
            {

                MessageBox.Show("Seleccione el almacen destino y fuente");
                return;
            }


            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            string P_VD_VENDEDOR = CurrentUserID.CurrentUser.INOMBRE;
            string P_LOTE = "";
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            int? US_SUPERVISORID = null;
            int? ALMACENID = m_manejaAlmacen ? int.Parse(this.ALMACENDestinoComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT; ;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            long? SUCURSALTID = 0;
            long? ALMACENTID = m_manejaAlmacen ? int.Parse(this.ALMACENDestinoComboBox.SelectedValue.ToString()) : (int)DBValues._DOCTO_ALMACEN_DEFAULT; 
            decimal? P_CANTIDAD_SURTIDA = null;

            long? P_TIPODIFERENCIAINVENTARIOID = 0;


            if (TBCodigo.Text.Trim() == "")
            {
                MessageBox.Show("El texto de este control no debe estar vacio");
                return;
            }

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {

                MessageBox.Show("El producto no existe");
                return;
            }

            m_prod = prod;

            if (m_prod != null)
            {
                P_IDPRODUCTO = m_prod.IID;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un producto valido");
                return;
            }


            if (m_prod.IESPRODPROMO == null || !m_prod.IESPRODPROMO.Equals("S"))
            {
                MessageBox.Show("No es un  prod promo valido");
                return;
            }


            try
            {
                P_CANTIDAD = decimal.Parse(TBCantidad.Text.Trim());
            }
            catch
            {
                MessageBox.Show("La cantidad no tiene el formato adecuado");
                return;
            }


            if(P_CANTIDAD > m_prod.IEXISTENCIA)
            {

                MessageBox.Show("No hay existencia suficiente para desensamblar");
                return;
            }


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

                if (EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_VD_VENDEDOR, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_Docto.ITIPODOCTOID, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_CANTIDAD_SURTIDA, null, fTrans))
                {
                    fTrans.Commit();
                    ObtenerDoctoDeBD((long)P_IDDOCTO);

                    this.ALMACENDestinoComboBox.Enabled = false;

                    PrepararSiguienteEntrada();
                    LlenarGrid();



                }
                else
                {
                    fTrans.Rollback();
                    MessageBox.Show(this.IComentario);
                    this.TBCodigo.Focus();
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
        }



        private void ObtenerDoctoDeBD(long lDoctoID)
        {
            CDOCTOD vDocto = new CDOCTOD();
            m_Docto = new CDOCTOBE();
            m_Docto.IID = lDoctoID;
            m_Docto = vDocto.seleccionarDOCTO(m_Docto, null);


            this.LBConsecutivo.Text = m_Docto.IID.ToString();
            this.LBFolio.Text = m_Docto.IFOLIO.ToString();
            this.LBDateValue.Text = m_Docto.IFECHA.ToShortDateString();


            if (!(bool)m_Docto.isnull["IALMACENID"])
                this.ALMACENDestinoComboBox.SelectedDataValue = m_Docto.IALMACENID;
            else
                this.ALMACENDestinoComboBox.SelectedIndex = -1;



        }


        private void PrepararSiguienteEntrada()
        {
            this.TBCantidad.Text = "";
            this.LlenarDatos();
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

        private void BtnEnviar_Click(object sender, EventArgs e)
        {

            Process();

            this.TBCodigo.Focus();
            this.TBCodigo.Text = "";

            m_prod = new CPRODUCTOBE();
            this.LlenarDatos();
        }

        private void kitDetalleDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (trasladoPromDetalleDataGridView.Columns["DGCANTIDADFISICA"].Index != e.ColumnIndex)
                return;


            try
            {
                decimal dNuevaCantidad = decimal.Parse(e.FormattedValue.ToString());
                decimal dViejaCantidad = decimal.Parse(trasladoPromDetalleDataGridView.Rows[e.RowIndex].Cells["DGCANTIDADFISICA"].Value.ToString());
                decimal dEntrada = dNuevaCantidad - dViejaCantidad;
                if (dEntrada == 0)
                    return;
                if (dNuevaCantidad < 0)
                {
                    MessageBox.Show("La cantidad fisica no puede ser menor que cero");
                    e.Cancel = true;
                }
                TBCodigo.Text = trasladoPromDetalleDataGridView.Rows[e.RowIndex].Cells["DGPRODUCTOCLAVE"].Value.ToString();
                LlenarDatos();
                TBCantidad.Text = dEntrada.ToString("N0");


                Process();

                m_bFocusCodigo = true;
                return;
            }
            catch
            {
                MessageBox.Show("Cheque el formato de entrada del valor");
                e.Cancel = true;
            }

            return;
        }

        private void kitDetalleDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            if (m_bFocusCodigo)
            {
                this.TBCodigo.Focus();
                this.TBCodigo.Text = "";
                m_bFocusCodigo = false;
            }
        }

        private void btnAbrirPendientes_Click(object sender, EventArgs e)
        {
            WFListaEnsamblados look = new WFListaEnsamblados((int)DBValues._DOCTO_TIPO_DESTRASLADO_PRODUCTO_PROMOCION);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);



            try
            {
                if (dr != null && (long)dr["ID"] > 1)
                {
                    ClearDocto();
                    ObtenerDoctoDeBD((long)dr["ID"]);

                    this.ALMACENDestinoComboBox.Enabled = false;

                    PrepararSiguienteEntrada();
                    LlenarGrid();
                }
            }
            catch
            {

            }


        }

        private void kitDetalleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 )
            {

                if (trasladoPromDetalleDataGridView.Columns[e.ColumnIndex].Name == "BTELIMINAR")
                {
                    CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                    CMOVTOBE movtoBE = new CMOVTOBE();

                    movtoBE.IID = (long)this.trasladoPromDetalleDataGridView.CurrentRow.Cells["MOVTOID"].Value;
                    if (!pvd.BorrarMOVTOVENTAS(movtoBE, null))
                    {
                        MessageBox.Show(pvd.IComentario);
                    }
                    LlenarGrid();
                    PrepararSiguienteEntrada();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {


            if(m_Docto == null || m_Docto.IID == 0)
            {
                MessageBox.Show("No hay documento a cancelar");
                return;
            }
            if(m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
            {

                MessageBox.Show("Solo se puede cancelar los documentos de tipo borrador");
                return;
            }

            if (MessageBox.Show("Realmente quiere cancelar este documento?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;



            bool iResult;
            CDOCTOD doctoD = new CDOCTOD();
            iResult = doctoD.BorrarDOCTOD(this.m_Docto, null);

            if (!iResult)
            {
                MessageBox.Show("No se pudo borrar " + doctoD.IComentario);
                return;
            }


            ClearDocto();
            PrepararSiguienteEntrada();
            LlenarGrid();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           

            ProcessAplicar();
        }





        private bool TRASLADOPROMOCION_APLICAR_DEST(long lDoctoID, FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@TRASLADOPROMOCIONID", FbDbType.BigInt);
                auxPar.Value = lDoctoID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"TRASLADOPROMOCION_APLICAR_DEST";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), null);
                        MessageBox.Show("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }

        }






        private bool ProcessAplicar()
        {
            if (m_Docto == null || m_Docto.IID == 0)
            {
                MessageBox.Show("No hay documento a guardar");
                return false;
            }
            if (m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_BORRADOR)
            {

                MessageBox.Show("Solo se pueden guardar o modificar los documentos de tipo borrador");
                return false;
            }

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            bool bRes = false;

            //long lMovtoId = 0;
            //decimal dCantidadSurtida = 0;

            try
            {


                fConn.Open();
                fTrans = fConn.BeginTransaction();



                if (TRASLADOPROMOCION_APLICAR_DEST(m_Docto.IID, fTrans) == false)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    //MessageBox.Show(objRecD.IComentario);
                    return false;
                }

                fTrans.Commit();
                fConn.Close();
                bRes = true;


                this.ClearDocto();

            }
            catch (Exception ex)
            {
                fTrans.Rollback();
                fConn.Close();
                MessageBox.Show("Ocurrio un error , llame a sistemas . \n Detalles del error :" + ex.Message + ex.StackTrace);

            }
            finally
            {
                fConn.Close();
            }

            MessageBox.Show("La finalizacion del desensamble se realizo correctamente");
            return bRes;
        }

        private void WFDesTrasladoProdProm_Load(object sender, EventArgs e)
        {

            m_manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));

            this.ALMACENDestinoComboBox.llenarDatos();

            this.ALMACENDestinoComboBox.Enabled = m_manejaAlmacen;
        }

       



    }
}
