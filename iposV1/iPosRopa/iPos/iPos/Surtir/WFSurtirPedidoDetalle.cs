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
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using Microsoft.ApplicationBlocks.Data;
using ConexionesBD;
using DataLayer.Importaciones;

namespace iPos
{
    public partial class WFSurtirPedidoDetalle : Form
    {

        long m_lDoctoId = 0;
        long m_almacenId = 0;
        int m_folio = 0;
        string m_nombrecliente = "";
        DateTime m_fecha = DateTime.MinValue;



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

        public WFSurtirPedidoDetalle()
        {
            InitializeComponent();
        }


        public WFSurtirPedidoDetalle(long doctoId, int folio, string nombreCliente, DateTime fecha, long almacenid)
            : this()
        {
            m_lDoctoId = doctoId;
            m_folio = folio;
            m_nombrecliente = nombreCliente;
            m_fecha = fecha;
            m_almacenId = almacenid;
        }

        private void LlenarGrid()
        {
            try
            {
                this.mOVTO_POR_LOTE_VIEWTableAdapter.Fill(this.dSInventarioFisico3.MOVTO_POR_LOTE_VIEW, (int)m_lDoctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFSurtirPedidoDetalle_Load(object sender, EventArgs e)
        {

            lblFolio.Text = m_folio.ToString();
            lblCliente.Text = m_nombrecliente;
            lblFecha.Text = m_fecha.ToString("dd/MM/yyyy");
            LlenarGrid();
        }


        private ArrayList filterHayCantidadASurtir(ArrayList reasignaciones)
        {
            ArrayList retorno = new ArrayList();

            if (reasignaciones == null)
                return null;

            foreach(CReAsignacionLote reasignacion in reasignaciones)
            {
                if(reasignacion.cantidad > 0)
                    retorno.Add(reasignacion);
            }
            return retorno;
        }

        private void mOVTO_POR_LOTE_VIEWDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex != -1)
            {

                if (mOVTO_POR_LOTE_VIEWDataGridView.Columns[e.ColumnIndex].Name == "DGEDITARLOTES")
                {
                    CPRODUCTOBE prodBE = new CPRODUCTOBE();
                    CPRODUCTOD prodD = new CPRODUCTOD();

                    prodBE.IID = (long)mOVTO_POR_LOTE_VIEWDataGridView.Rows[e.RowIndex].Cells["DGPRODUCTOID"].Value;
                    decimal cantidad =  (decimal)mOVTO_POR_LOTE_VIEWDataGridView.Rows[e.RowIndex].Cells["DGCANTIDAD"].Value;
                    long firstMovtoId = (long)mOVTO_POR_LOTE_VIEWDataGridView.Rows[e.RowIndex].Cells["DGFIRSTMOVTOID"].Value;
                    decimal precio =  (decimal)mOVTO_POR_LOTE_VIEWDataGridView.Rows[e.RowIndex].Cells["DGPRECIO"].Value;


                    prodBE = prodD.seleccionarPRODUCTO(prodBE, null);
                    if(prodBE == null)
                    {
                        MessageBox.Show("No se pudo encontrar el producto");
                        return;
                    }

                    if(prodBE.IMANEJALOTE == null || !prodBE.IMANEJALOTE.Equals("S"))
                    {

                        MessageBox.Show("El producto no maneja lote");
                        return;
                    }

                    WFReasignaLote pl = new WFReasignaLote(prodBE, cantidad, m_lDoctoId, precio, m_almacenId);
                    pl.ShowDialog();


                    ArrayList asignacionesConCantidadASurtir = filterHayCantidadASurtir(pl.asignaciones);

                    if (asignacionesConCantidadASurtir.Count > 0)
                    {

                        

                        CSURTIDOD surtidoD = new CSURTIDOD();
                        bool bRes = false;


                        FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                        FbTransaction fTrans = null;
                        try
                        {

                            fConn.Open();
                            fTrans = fConn.BeginTransaction();
                            CReAsignacionLote firstAssign = (CReAsignacionLote)asignacionesConCantidadASurtir[0];
                            bRes = surtidoD.SURTIDO_CAMBIAR_LOTE_PREPARE(firstMovtoId, firstAssign.cantidad, firstAssign.lote, firstAssign.fechaVence, firstAssign.surtible , firstAssign.maxSurtible, fTrans);

                            if(!bRes)
                            {

                                fTrans.Rollback();
                                MessageBox.Show("No se pudo hacer la preparacion de cambio de lote");
                                throw new Exception();
                            }

                            if (!pl.m_esReasignacion)
                            {
                                if (!ProcessInterCambioLotes(pl.asignaciones, prodBE.IID, fTrans))
                                {
                                    fTrans.Rollback();
                                    MessageBox.Show("No se pudo hacer la preparacion de cambio de lote");
                                    throw new Exception();

                                }
                            }


                            bRes = surtidoD.SURTIDO_CAMBIAR_LOTE_PREPOST(firstMovtoId, firstAssign.cantidad, firstAssign.lote, firstAssign.fechaVence, firstAssign.surtible, firstAssign.maxSurtible, fTrans);

                            if (!bRes)
                            {

                                fTrans.Rollback();
                                MessageBox.Show("No se pudo hacer la post preparacion de cambio de lote");
                                throw new Exception();
                            }


                            if (asignacionesConCantidadASurtir.Count > 1)
                            {
                                for (int i = 1; i < asignacionesConCantidadASurtir.Count; i++)
                                {
                                    CReAsignacionLote assign = (CReAsignacionLote)asignacionesConCantidadASurtir[i];
                                    bRes = surtidoD.SURTIDO_CAMBIAR_LOTE_ADD(firstMovtoId, assign.cantidad, assign.lote, assign.fechaVence, assign.surtible, assign.maxSurtible, fTrans);

                                    if (!bRes)
                                    {

                                        fTrans.Rollback();
                                        MessageBox.Show("No se pudo hacer la adicion de cambio de lote");
                                        throw new Exception();
                                    }
                                }
                            }


                            bRes = surtidoD.SURTIDO_CAMBIAR_LOTE_FINISH(firstMovtoId, fTrans);

                            if (!bRes)
                            {

                                fTrans.Rollback();
                                MessageBox.Show("No se pudo hacer la finalizacion de los cambios");
                                throw new Exception();
                            }

                            fTrans.Commit();
                            fConn.Close();
                            this.LlenarGrid();

                        }
                        catch(Exception ex)
                        {
                            try
                            {
                                fTrans.Rollback();
                            }
                            catch { }

                            fConn.Close();

                        }
                        finally
                        {
                            fConn.Close();
                        }


                    }

                }
            }
        }





        private ArrayList filterHayDiferenciaCantidadAnteriorYNueva(ArrayList reasignaciones)
        {
            ArrayList retorno = new ArrayList();

            if (reasignaciones == null)
                return null;

            foreach (CReAsignacionLote reasignacion in reasignaciones)
            {
                if (reasignacion.cantidad != reasignacion.cantidadAnterior)
                    retorno.Add(reasignacion);
            }
            return retorno;
        }


        private bool ProcessInterCambioLotes(ArrayList reasignaciones, long prodId, FbTransaction fTrans)
        {
            long doctoEntradas = 0;
            long doctoSalidas = 0;

            ArrayList reasignacionesConCambio = filterHayDiferenciaCantidadAnteriorYNueva(reasignaciones);

            if (reasignacionesConCambio != null && reasignacionesConCambio.Count > 0)
            {



                try
                {
                    for (int i = 0; i < 2; i++)
                    {

                        foreach (CReAsignacionLote row in reasignacionesConCambio)
                        {

                            if (row.cantidad < row.cantidadAnterior && i == 1)
                            {

                                if (!ProcessLine(prodId, m_almacenId, row.lote, row.fechaVence, row.cantidadAnterior - row.cantidad, DBValues._DOCTO_TIPO_CAMBIOLOTES_SALIDA, ref doctoSalidas, fTrans))
                                {
                                    return false;
                                }
                            }
                            else if (row.cantidad > row.cantidadAnterior && i == 0)
                            {

                                if (!ProcessLine(prodId, m_almacenId, row.lote, row.fechaVence, row.cantidad - row.cantidadAnterior, DBValues._DOCTO_TIPO_CAMBIOLOTES_ENTRADA, ref doctoEntradas, fTrans))
                                {
                                    return false;
                                }
                            }
                        }
                    }

                    if (doctoEntradas != 0 && doctoSalidas != 0)
                    {
                        CDOCTOBE doctoBEEntrada = new CDOCTOBE();
                        doctoBEEntrada.IID = doctoEntradas;
                        if (!CerrarTransaccion(doctoBEEntrada, fTrans))
                        {
                            return false;
                        }

                        CDOCTOBE doctoBESalida = new CDOCTOBE();
                        doctoBESalida.IID = doctoSalidas;
                        if (!CerrarTransaccion(doctoBESalida, fTrans))
                        {
                            return false;
                        }
                    }

                }
                catch (Exception ex)
                {
                    this.iComentario = ex.Message;
                }
                finally
                {
                }



            }

            return true;

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
            int? ALMACENID = (int)almacenId;
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

        private void btnMarcarComoSurtido_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Realmente desea marcar este registro como surtido? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            CSURTIDOD surtidoD = new CSURTIDOD();

            if (!surtidoD.SURTIDO_ASIGNARESTADO(m_lDoctoId, TBNotaSurtido.Text, DBValues._DOCTO_SURTIDOESTADO_SURTIDO, CurrentUserID.CurrentUser.IID, null))
            {
                MessageBox.Show(surtidoD.IComentario);
            }
            else
            {

                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IID = this.m_lDoctoId;
                doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                if(doctoBE != null && doctoBE.IESFACTURAELECTRONICA == "S")
                {
                    if (generarFacturaElectronica(doctoBE))
                    {

                        MessageBox.Show("Se facturo");
                        imprimirFacturaElectronica(doctoBE);
                    }
                    else
                    {
                        surtidoD.SURTIDO_ASIGNARESTADO(m_lDoctoId, TBNotaSurtido.Text, DBValues._DOCTO_SURTIDOESTADO_PENDIENTE, CurrentUserID.CurrentUser.IID, null);
                        MessageBox.Show("No se pudo facturar");
                        return;
                    }
                }

                if (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO ||
                    doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA ||
                    (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA_SALIDA) ||
                    (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA))
                    {
                            EnviarTraslado(doctoBE);
                    }

                this.Close();
            }

        }

        private void btnMarcarComoNoSurtido_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Realmente desea marcar este registro con error de surtido? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            CSURTIDOD surtidoD = new CSURTIDOD();

            if (!surtidoD.SURTIDO_ASIGNARESTADO(m_lDoctoId, TBNotaSurtido.Text, DBValues._DOCTO_SURTIDOESTADO_ERROR, CurrentUserID.CurrentUser.IID, null))
            {
                MessageBox.Show(surtidoD.IComentario);
            }
            else
            {
                this.Close();
            }
        }






        private bool generarFacturaElectronica(CDOCTOBE docto)
        {


            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_REMISIONAFACTURA, null))
            {
                MessageBox.Show("No tiene derecho para cambiar una remision ya hecha a factura");
                return false;
            }

            if (docto.IFECHAHORA.Month != DateTime.Now.Month)
            {
                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_FACTURARFUERADEMES, null))
                {
                    MessageBox.Show("No tiene derecho para facturar una remision fuera de este mes");
                    return false;
                }
            }



            bool retorno = false;


            CDOCTOPAGOBE pagoTemporal = new CDOCTOPAGOBE();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();

            pagoTemporal = doctoPagoD.seleccionarPrimerDOCTOPAGO(docto, null);

            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, iPosReporting.WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.m_vendedorId = CurrentUserID.CurrentUser.IID;
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            /*if (retorno)
            {
                CDOCTOD doctoD = new CDOCTOD();
                m_Docto.IESFACTURAELECTRONICA = "S";
                doctoD.ACTUALIZARESFACTURAELECTRONICA(m_Docto, null);
            }*/

            return retorno;
        }



        private bool imprimirFacturaElectronica(CDOCTOBE docto)
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            docto = doctoD.seleccionarDOCTO(docto, null);

            if ((bool)docto.isnull["IFOLIOSAT"] || (bool)docto.isnull["IESTATUSDOCTOID"]
                || docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || docto.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }


            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, iPosReporting.WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }



        private void ExportarTraslados(int folio)
        {


            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            //string strResultado = "";

            ArrayList resultadosExportacion = new ArrayList();
            if (!iDBF.EnviarArchivosAFtpDeTraslados(ref resultadosExportacion, folio))
            {

                StringBuilder strBuffer = new StringBuilder("");
                strBuffer.Append(iDBF.IComentario + "\n");
                foreach (string str in resultadosExportacion)
                {
                    strBuffer.Append(str);
                }
                MessageBox.Show(strBuffer.ToString() + "\n");
            }
            else
                MessageBox.Show("La exportacion se ha realizado");


        }



        private void ExportarTrasladosPedidosMatriz(int folio, long doctoid)
        {


            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            //string strResultado = "";
            ExportarDBF eDBF = new ExportarDBF();

            if (!eDBF.ExportarEnvioPedido(doctoid, CurrentUserID.CurrentUser, null))
            {
                return;
            }


            ArrayList resultadosExportacion = new ArrayList();
            if (iDBF.EnviarArchivosAFtpDeMatrizPedidos(ref resultadosExportacion, folio, null))
            {

                StringBuilder strBuffer = new StringBuilder("");
                strBuffer.Append(iDBF.IComentario + "\n");
                foreach (string str in resultadosExportacion)
                {
                    strBuffer.Append(str);
                }
                MessageBox.Show(strBuffer.ToString() + "\n");
            }
            else
            {
                MessageBox.Show("Hubo problemas al realizar al exportacion");
                if (resultadosExportacion.Count > 0)
                {

                    StringBuilder strBuffer = new StringBuilder("");
                    strBuffer.Append(iDBF.IComentario + "\n");
                    foreach (string str in resultadosExportacion)
                    {
                        strBuffer.Append(str);
                    }
                    MessageBox.Show(strBuffer.ToString() + "\n");
                }
            }


        }





        private void EnviarTraslado(CDOCTOBE doctoBE)
        {


            if (MessageBox.Show("¿Desea reimprimir el ticket de traslado?", "Confirmacion de re impresion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PosPrinter.ImprimirTicket(doctoBE.IID);
            }



            if (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
            {
                CDOCTOD vData = new CDOCTOD();
                doctoBE = vData.seleccionarDOCTO(doctoBE, null);

                ExportarTraslados(doctoBE.IFOLIO);
            }

            if (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA)
            {
                CDOCTOD vData = new CDOCTOD();
                doctoBE = vData.seleccionarDOCTO(doctoBE, null);

                ExportarTrasladosPedidosMatriz(doctoBE.IFOLIO, doctoBE.IID);
            }


            if (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA_SALIDA)
            {

                CDOCTOD vData = new CDOCTOD();
                doctoBE = vData.seleccionarDOCTO(doctoBE, null);
                CDOCTOBE doctoBEAux = new CDOCTOBE();
                doctoBEAux.IID = doctoBE.IDOCTOREFID;
                doctoBEAux = vData.seleccionarDOCTO(doctoBEAux, null);

                ExportarTraslados(doctoBEAux.IFOLIO);
            }


            if (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA)
            {

                CDOCTOD vData = new CDOCTOD();
                doctoBE = vData.seleccionarDOCTO(doctoBE, null);
                CDOCTOBE doctoBEAux = new CDOCTOBE();
                doctoBEAux.IID = doctoBE.IDOCTOREFID;
                doctoBEAux = vData.seleccionarDOCTO(doctoBEAux, null);

                ExportarTrasladosPedidosMatriz(doctoBEAux.IFOLIO, doctoBEAux.IID);
            }




        }



    }
}
