using ConexionesBD;
using DataLayer.Movil.businessEntity.MOVILANDROID;
using FirebirdSql.Data.FirebirdClient;
using iPosBusinessEntity;
using iPosData;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Movil.businessData.MOVILANDROID
{
    public class CMCREPDROIDD
    {
        private string iComentario;
        private string sCadenaConexion;
        private List<CCREPDROIDBE> cobranzas;
        private const string conexion = @"User = SYSDBA; 
                                Password = masterkey; 
                                Database = C:\GitHub\ipos\ipos\iposV1\iPosRopa\iPos\iPos\bin\Debug\sampdata\VENMOVDROID.fdb; 
                                DataSource = localhost;";

        public CMCREPDROIDD()
        {
            sCadenaConexion = ConexionBD.ConexionString();
            cobranzas = new List<CCREPDROIDBE>();
        }

        public CMCREPDROIDD(string conexion)
        {
            sCadenaConexion = conexion;
            cobranzas = new List<CCREPDROIDBE>();
        }

        public string IComentario { get => iComentario; set => iComentario = value; }

        public bool LimpiarTabla(FbTransaction st)
        {
            try
            {
                sCadenaConexion = conexion;
                ArrayList parts = new ArrayList();

                string commandText = @"DELETE FROM MCREPDROID;";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);

                return true;
            }
            catch (Exception e)
            {
                iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool InsertarCobranza(CCREPDROIDBE cobranza, FbTransaction st)
        {
            try
            {
                sCadenaConexion = conexion;
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@COBRANZA", FbDbType.VarChar);
                auxPar.Value = cobranza.Cobranza;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDOR", FbDbType.VarChar);
                auxPar.Value = cobranza.Vendedor;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENTA", FbDbType.VarChar);
                auxPar.Value = cobranza.Venta;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMPRESA", FbDbType.VarChar);
                auxPar.Value = cobranza.Empresa;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLIENTE", FbDbType.VarChar);
                auxPar.Value = cobranza.Cliente;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                auxPar.Value = cobranza.Nombre;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FACTURA", FbDbType.VarChar);
                auxPar.Value = cobranza.Factura;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUS", FbDbType.VarChar);
                auxPar.Value = cobranza.Estatus;
                parts.Add(auxPar);

                auxPar = new FbParameter("@OBS", FbDbType.Decimal);
                auxPar.Value = cobranza.Obs;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA_FACTURA", FbDbType.VarChar);
                auxPar.Value = cobranza.FechaFactura;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA_PAGO", FbDbType.VarChar);
                auxPar.Value = cobranza.FechaPago;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DIAS", FbDbType.VarChar);
                auxPar.Value = cobranza.Dias;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOTAL", FbDbType.VarChar);
                auxPar.Value = cobranza.Total;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACUENTA", FbDbType.Decimal);
                auxPar.Value = cobranza.ACuenta;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDO", FbDbType.BigInt);
                auxPar.Value = cobranza.Saldo;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INT_COB", FbDbType.VarChar);
                auxPar.Value = cobranza.IntCob;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INTERESES", FbDbType.VarChar);
                auxPar.Value = cobranza.Intereses;
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMPORTE_NETO", FbDbType.VarChar);
                auxPar.Value = cobranza.ImporteNeto;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGO", FbDbType.VarChar);
                auxPar.Value = cobranza.Pago;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EFECTIVO", FbDbType.VarChar);
                auxPar.Value = cobranza.Efectivo;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DIFERENCIA", FbDbType.VarChar);
                auxPar.Value = cobranza.Diferencia;
                parts.Add(auxPar);

                auxPar = new FbParameter("@IMP_CHEQUE", FbDbType.VarChar);
                auxPar.Value = cobranza.ImpCheque;
                parts.Add(auxPar);

                auxPar = new FbParameter("@BANCO", FbDbType.VarChar);
                auxPar.Value = cobranza.Banco;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUM_CHEQ", FbDbType.VarChar);
                auxPar.Value = cobranza.NumCheq;
                parts.Add(auxPar);

                auxPar = new FbParameter("@INTERES", FbDbType.VarChar);
                auxPar.Value = cobranza.Interes;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAPITAL", FbDbType.VarChar);
                auxPar.Value = cobranza.Capital;
                parts.Add(auxPar);

                auxPar = new FbParameter("@OLLA", FbDbType.VarChar);
                auxPar.Value = cobranza.Olla;
                parts.Add(auxPar);

                auxPar = new FbParameter("@BLOQUEADO", FbDbType.VarChar);
                auxPar.Value = cobranza.Bloqueado;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.VarChar);
                auxPar.Value = cobranza.Fecha;
                parts.Add(auxPar);

                auxPar = new FbParameter("@LLEVAR", FbDbType.VarChar);
                auxPar.Value = cobranza.Llevar;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ID", FbDbType.VarChar);
                auxPar.Value = cobranza.Id;
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDFECHA", FbDbType.VarChar);
                auxPar.Value = cobranza.IdFecha;
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDHORA", FbDbType.VarChar);
                auxPar.Value = cobranza.IdHora;
                parts.Add(auxPar);

                string commandText = @"INSERT INTO MCREPDROID(
                                            COBRANZA,
                                            VENDEDOR,
                                            VENTA,
                                            EMPRESA,
                                            CLIENTE,
                                            NOMBRE,
                                            FACTURA,
                                            ESTATUS,
                                            OBS,
                                            FECHA_FACTURA,
                                            FECHA_PAGO,
                                            DIAS,
                                            TOTAL,
                                            ACUENTA,
                                            SALDO,
                                            INT_COB,
                                            INTERESES,
                                            IMPORTE_NETO,
                                            PAGO,
                                            EFECTIVO,
                                            DIFERENCIA,
                                            IMP_CHEQUE,
                                            BANCO,
                                            NUM_CHEQ,
                                            INTERES,
                                            CAPITAL,
                                            OLLA,
                                            BLOQUEADO,
                                            FECHA,
                                            LLEVAR,
                                            ID,
                                            IDFECHA,
                                            IDHORA         
                                       )
                                       Values(
                                            @COBRANZA,
                                            @VENDEDOR,
                                            @VENTA,
                                            @EMPRESA,
                                            @CLIENTE,
                                            @NOMBRE,
                                            @FACTURA,
                                            @ESTATUS,
                                            @OBS,
                                            @FECHA_FACTURA,
                                            @FECHA_PAGO,
                                            @DIAS,
                                            @TOTAL,
                                            @ACUENTA,
                                            @SALDO,
                                            @INT_COB,
                                            @INTERESES,
                                            @IMPORTE_NETO,
                                            @PAGO,
                                            @EFECTIVO,
                                            @DIFERENCIA,
                                            @IMP_CHEQUE,
                                            @BANCO,
                                            @NUM_CHEQ,
                                            @INTERES,
                                            @CAPITAL,
                                            @OLLA,
                                            @BLOQUEADO,
                                            @FECHA,
                                            @LLEVAR,
                                            @ID,
                                            @IDFECHA,
                                            @IDHORA
                                        ); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);

                return true;

            }
            catch (Exception e)
            {
                iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool ObtenerRegistros(long crepId, string personaClave, FbTransaction st)
        {
            CM_CREPBE fbItem = new CM_CREPBE();

            CM_CREPD m_dbfD = new CM_CREPD();
            CCREPDROIDBE crep = new CCREPDROIDBE();

            ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                sCadenaConexion = ConexionBD.ConexionString();
                parts = new ArrayList();

                CmdTxt = @"
                            SELECT  BITACOBRANZADET.*, 
                                    DOCTO.FOLIO DOCTOFOLIO , 
                                    CLIENTE.CLAVE CLIENTECLAVE, 
                                    CLIENTE.NOMBRE CLIENTENOMBRE,
                                    DOCTO.ESFACTURAELECTRONICA, 
                                    DOCTO.FOLIOSAT,
                                    DOCTO.TOTAL DOCTOTOTAL, 
                                    DOCTO.FECHAFACTURA, 
                                    CLIENTE.BLOQUEADO, 
                                    DOCTO.ABONO DOCTOABONO, 
                                    DOCTO.SALDO DOCTOSALDO

                            FROM BITACOBRANZADET 
                            LEFT JOIN DOCTO ON DOCTO.ID = BITACOBRANZADET.DOCTOID 
                            LEFT JOIN PERSONA CLIENTE ON CLIENTE.ID = BITACOBRANZADET.PERSONAID 
                            WHERE BITCOBRANZAID = @BITCOBRANZAID";


                FbParameter auxPar;
                auxPar = new FbParameter("@BITCOBRANZAID", FbDbType.BigInt);
                auxPar.Value = crepId;
                parts.Add(auxPar);

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    crep = new CCREPDROIDBE();


                    if (dr["BITCOBRANZAID"] != System.DBNull.Value)
                    {
                        long bitCobranzaId = (long)(dr["BITCOBRANZAID"]);
                        crep.Cobranza = bitCobranzaId.ToString();
                    }

                    crep.Vendedor = personaClave;


                    if (dr["DOCTOFOLIO"] != System.DBNull.Value)
                    {
                        int folio = (int)(dr["DOCTOFOLIO"]);
                        crep.Venta = folio.ToString();
                    }



                    if (dr["BITCOBRANZAID"] != System.DBNull.Value)
                    {
                        long bitCobranzaId = (long)(dr["BITCOBRANZAID"]);
                        crep.Cobranza = bitCobranzaId.ToString();
                    }



                    if (dr["CLIENTECLAVE"] != System.DBNull.Value)
                    {

                        crep.Cliente = (string)dr["CLIENTECLAVE"];
                    }

                    if (dr["CLIENTENOMBRE"] != System.DBNull.Value)
                    {

                        crep.Nombre = (string)dr["CLIENTENOMBRE"];
                    }


                    if (dr["FOLIOSAT"] != System.DBNull.Value)
                    {

                        int folioSat = (int)(dr["FOLIOSAT"]);
                        crep.Factura = folioSat.ToString();
                    }


                    if (dr["ESFACTURAELECTRONICA"] != System.DBNull.Value)
                    {

                        string sEsFacturaElectronica = (string)dr["ESFACTURAELECTRONICA"];
                        if (sEsFacturaElectronica != null && sEsFacturaElectronica.Equals("S"))
                        {
                            crep.Estatus = "F";
                        }
                        else
                        {
                            crep.Estatus = "R";
                        }
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {

                        crep.Fecha = (DateTime)dr["FECHA"];
                    }

                    if (dr["FECHAFACTURA"] != System.DBNull.Value)
                    {

                        crep.FechaFactura = (DateTime)dr["FECHAFACTURA"];
                    }



                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {

                        crep.FechaPago = (DateTime)dr["FECHAVENCE"];
                    }



                    if (dr["DOCTOTOTAL"] != System.DBNull.Value)
                    {
                        crep.Total = (decimal)(dr["DOCTOTOTAL"]);
                    }

                    if (dr["DOCTOSALDO"] != System.DBNull.Value)
                    {
                        crep.Saldo = (decimal)(dr["DOCTOSALDO"]);

                        crep.ImporteNeto = (decimal)(dr["DOCTOSALDO"]);
                    }

                    if (dr["DOCTOABONO"] != System.DBNull.Value)
                    {
                        crep.ACuenta = (decimal)(dr["DOCTOABONO"]);
                    }



                    if (dr["BLOQUEADO"] != System.DBNull.Value)
                    {

                        crep.Bloqueado = (string)dr["BLOQUEADO"];
                    }

                    cobranzas.Add(crep);
                }

                SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool LlenarTabla(long crepId, string personaClave)
        {
            FbConnection fbConnection = new FbConnection(conexion);
            FbTransaction fbTransaction = null;
            bool retorno;

            try
            {
                fbConnection.Open();
                fbTransaction = fbConnection.BeginTransaction();

                if (!LimpiarTabla(null))
                    throw new Exception(iComentario);

                //llenar tabla de cobranza con los registros recuperados con el query que usan para el dbf y el header id de la cobranza
                ObtenerRegistros(crepId, personaClave, null);

                foreach(CCREPDROIDBE crep in cobranzas)
                {

                    InsertarCobranza(crep, fbTransaction);
                }

                fbTransaction.Commit();

                retorno = true;
            }
            catch (Exception e)
            {
                fbTransaction.Rollback();
                iComentario = e.Message;
                retorno = false;
            }
            finally
            {
                fbConnection.Close();
            }

            return retorno;
        }
    }
}
