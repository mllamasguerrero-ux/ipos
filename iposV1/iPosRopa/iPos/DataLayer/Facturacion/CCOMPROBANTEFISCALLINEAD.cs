

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Collections.Generic;

namespace iPosData
{



    public class CCOMPROBANTEFISCALLINEAD
    {
        private string sCadenaConexion;

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

        protected string iComentarioAdicional;
        public string IComentarioAdicional
        {
            get
            {
                return this.iComentarioAdicional;
            }
            set
            {
                this.iComentarioAdicional = value;
            }
        }


        public List<CCOMPROBANTEFISCALLINEABE> FACTURAELECTRONICA_XML(long lDoctoId, string tipoComprobante, FbTransaction st)
        {


            List<CCOMPROBANTEFISCALLINEABE> retornoList = new List<CCOMPROBANTEFISCALLINEABE>();

            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"FACTURAELECTRONICA_XML";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lDoctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@P_TIPOCOMPROBANTE", FbDbType.VarChar);
                auxPar.Value = tipoComprobante;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.StoredProcedure, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.StoredProcedure, CmdTxt, arParms);


                while (dr.Read())
                {
                    CCOMPROBANTEFISCALLINEABE retorno = new CCOMPROBANTEFISCALLINEABE();

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }


                    if (dr["TIPOLINEA"] != System.DBNull.Value)
                    {
                        retorno.ITIPOLINEA = (string)(dr["TIPOLINEA"]);
                    }

                    if (dr["SERIE"] != System.DBNull.Value)
                    {
                        retorno.ISERIE = (string)(dr["SERIE"]);
                    }

                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        retorno.IFOLIO = (string)(dr["FOLIO"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["TIPOCOMPROBANTE"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCOMPROBANTE = (string)(dr["TIPOCOMPROBANTE"]);
                    }

                    if (dr["FORMAPAGO"] != System.DBNull.Value)
                    {
                        retorno.IFORMAPAGO = (string)(dr["FORMAPAGO"]);
                    }

                    if (dr["SUBTOTAL"] != System.DBNull.Value)
                    {
                        retorno.ISUBTOTAL = (decimal)(dr["SUBTOTAL"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                    }

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        retorno.IMONEDA = (string)(dr["MONEDA"]);
                    }

                    if (dr["TIPOCAMBIO"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCAMBIO = (string)(dr["TIPOCAMBIO"]);
                    }

                    if (dr["CONDICIONESPAGO"] != System.DBNull.Value)
                    {
                        retorno.ICONDICIONESPAGO = (string)(dr["CONDICIONESPAGO"]);
                    }

                    if (dr["METODOPAGO"] != System.DBNull.Value)
                    {
                        retorno.IMETODOPAGO = (string)(dr["METODOPAGO"]);
                    }

                    if (dr["MOTIVODESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IMOTIVODESCUENTO = (string)(dr["MOTIVODESCUENTO"]);
                    }

                    if (dr["LUGAREXPEDICION"] != System.DBNull.Value)
                    {
                        retorno.ILUGAREXPEDICION = (string)(dr["LUGAREXPEDICION"]);
                    }

                    if (dr["NUMEROCTAPAGO"] != System.DBNull.Value)
                    {
                        retorno.INUMEROCTAPAGO = (string)(dr["NUMEROCTAPAGO"]);
                    }

                    if (dr["SERIEFOLIOFISCALORIGINAL"] != System.DBNull.Value)
                    {
                        retorno.ISERIEFOLIOFISCALORIGINAL = (string)(dr["SERIEFOLIOFISCALORIGINAL"]);
                    }

                    if (dr["FOLIOFISCALORIGINAL"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOFISCALORIGINAL = (string)(dr["FOLIOFISCALORIGINAL"]);
                    }

                    if (dr["MONTOFOLIOFISCALORIGINAL"] != System.DBNull.Value)
                    {
                        retorno.IMONTOFOLIOFISCALORIGINAL = (decimal)(dr["MONTOFOLIOFISCALORIGINAL"]);
                    }

                    if (dr["FECHAFOLIOFISCALORIGINAL"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFOLIOFISCALORIGINAL = (DateTime)(dr["FECHAFOLIOFISCALORIGINAL"]);
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = (string)(dr["RFC"]);
                    }

                    if (dr["RAZONSOCIAL"] != System.DBNull.Value)
                    {
                        retorno.IRAZONSOCIAL = (string)(dr["RAZONSOCIAL"]);
                    }

                    if (dr["REGIMENFISCAL"] != System.DBNull.Value)
                    {
                        retorno.IREGIMENFISCAL = (string)(dr["REGIMENFISCAL"]);
                    }

                    if (dr["CALLE"] != System.DBNull.Value)
                    {
                        retorno.ICALLE = (string)(dr["CALLE"]);
                    }

                    if (dr["NOINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INOINTERIOR = (string)(dr["NOINTERIOR"]);
                    }

                    if (dr["NOEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INOEXTERIOR = (string)(dr["NOEXTERIOR"]);
                    }

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }

                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
                    }

                    if (dr["REFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIA = (string)(dr["REFERENCIA"]);
                    }

                    if (dr["MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IMUNICIPIO = (string)(dr["MUNICIPIO"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (string)(dr["ESTADO"]);
                    }

                    if (dr["PAIS"] != System.DBNull.Value)
                    {
                        retorno.IPAIS = (string)(dr["PAIS"]);
                    }

                    if (dr["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = (string)(dr["CODIGOPOSTAL"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["RESIDENCIAFISCAL"] != System.DBNull.Value)
                    {
                        retorno.IRESIDENCIAFISCAL = (string)(dr["RESIDENCIAFISCAL"]);
                    }

                    if (dr["NUMREGIDTRIB"] != System.DBNull.Value)
                    {
                        retorno.INUMREGIDTRIB = (string)(dr["NUMREGIDTRIB"]);
                    }

                    if (dr["USOCFDI"] != System.DBNull.Value)
                    {
                        retorno.IUSOCFDI = (string)(dr["USOCFDI"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["UNIDAD"] != System.DBNull.Value)
                    {
                        retorno.IUNIDAD = (string)(dr["UNIDAD"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["VALORUNITARIO"] != System.DBNull.Value)
                    {
                        retorno.IVALORUNITARIO = (decimal)(dr["VALORUNITARIO"]);
                    }

                    if (dr["IMPORTE"] != System.DBNull.Value)
                    {
                        retorno.IIMPORTE = (decimal)(dr["IMPORTE"]);
                    }

                    if (dr["NOIDENTIFICACION"] != System.DBNull.Value)
                    {
                        retorno.INOIDENTIFICACION = (string)(dr["NOIDENTIFICACION"]);
                    }

                    if (dr["CUENTAPREDIAL"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAPREDIAL = (string)(dr["CUENTAPREDIAL"]);
                    }

                    if (dr["CLAVEPRODSERV"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEPRODSERV = (string)(dr["CLAVEPRODSERV"]);
                    }

                    if (dr["CLAVEUNIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEUNIDAD = (string)(dr["CLAVEUNIDAD"]);
                    }

                    if (dr["NUMERO"] != System.DBNull.Value)
                    {
                        retorno.INUMERO = (string)(dr["NUMERO"]);
                    }

                    if (dr["ADUANA"] != System.DBNull.Value)
                    {
                        retorno.IADUANA = (string)(dr["ADUANA"]);
                    }

                    if (dr["IMPUESTO"] != System.DBNull.Value)
                    {
                        retorno.IIMPUESTO = (string)(dr["IMPUESTO"]);
                    }

                    if (dr["TASA"] != System.DBNull.Value)
                    {
                        retorno.ITASA = (decimal)(dr["TASA"]);
                    }

                    if (dr["BASEIMP"] != System.DBNull.Value)
                    {
                        retorno.IBASEIMP = (decimal)(dr["BASEIMP"]);
                    }

                    if (dr["TIPOFACTOR"] != System.DBNull.Value)
                    {
                        retorno.ITIPOFACTOR = (string)(dr["TIPOFACTOR"]);
                    }

                    if (dr["TASACUOTA"] != System.DBNull.Value)
                    {
                        retorno.ITASACUOTA = (string)(dr["TASACUOTA"]);
                    }

                    if (dr["FECHAPAGO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAPAGO = (DateTime)(dr["FECHAPAGO"]);
                    }

                    if (dr["FORMADEPAGOP"] != System.DBNull.Value)
                    {
                        retorno.IFORMADEPAGOP = (string)(dr["FORMADEPAGOP"]);
                    }

                    if (dr["MONEDAP"] != System.DBNull.Value)
                    {
                        retorno.IMONEDAP = (string)(dr["MONEDAP"]);
                    }

                    if (dr["TIPOCAMBIOP"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCAMBIOP = (string)(dr["TIPOCAMBIOP"]);
                    }

                    if (dr["MONTO"] != System.DBNull.Value)
                    {
                        retorno.IMONTO = (decimal)(dr["MONTO"]);
                    }

                    if (dr["NUMOPERACION"] != System.DBNull.Value)
                    {
                        retorno.INUMOPERACION = (string)(dr["NUMOPERACION"]);
                    }

                    if (dr["RFCEMISORCTAORD"] != System.DBNull.Value)
                    {
                        retorno.IRFCEMISORCTAORD = (string)(dr["RFCEMISORCTAORD"]);
                    }

                    if (dr["NOMBANCOORDEXT"] != System.DBNull.Value)
                    {
                        retorno.INOMBANCOORDEXT = (string)(dr["NOMBANCOORDEXT"]);
                    }

                    if (dr["CTAORDENANTE"] != System.DBNull.Value)
                    {
                        retorno.ICTAORDENANTE = (string)(dr["CTAORDENANTE"]);
                    }

                    if (dr["RFCEMISORCTABEN"] != System.DBNull.Value)
                    {
                        retorno.IRFCEMISORCTABEN = (string)(dr["RFCEMISORCTABEN"]);
                    }

                    if (dr["CTABENEFICIARIO"] != System.DBNull.Value)
                    {
                        retorno.ICTABENEFICIARIO = (string)(dr["CTABENEFICIARIO"]);
                    }

                    if (dr["TIPOCADPAGO"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCADPAGO = (string)(dr["TIPOCADPAGO"]);
                    }

                    if (dr["CERTPAGO"] != System.DBNull.Value)
                    {
                        retorno.ICERTPAGO = (string)(dr["CERTPAGO"]);
                    }

                    if (dr["CADPAGO"] != System.DBNull.Value)
                    {
                        retorno.ICADPAGO = (string)(dr["CADPAGO"]);
                    }

                    if (dr["SELLOPAGO"] != System.DBNull.Value)
                    {
                        retorno.ISELLOPAGO = (string)(dr["SELLOPAGO"]);
                    }

                    if (dr["IDDOCUMENTO"] != System.DBNull.Value)
                    {
                        retorno.IIDDOCUMENTO = (string)(dr["IDDOCUMENTO"]);
                    }

                    if (dr["MONEDADR"] != System.DBNull.Value)
                    {
                        retorno.IMONEDADR = (string)(dr["MONEDADR"]);
                    }

                    if (dr["TIPOCAMBIODR"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCAMBIODR = (string)(dr["TIPOCAMBIODR"]);
                    }

                    if (dr["METODODEPAGODR"] != System.DBNull.Value)
                    {
                        retorno.IMETODODEPAGODR = (string)(dr["METODODEPAGODR"]);
                    }

                    if (dr["NUMPARCIALIDAD"] != System.DBNull.Value)
                    {
                        retorno.INUMPARCIALIDAD = (string)(dr["NUMPARCIALIDAD"]);
                    }

                    if (dr["IMPSALDOANT"] != System.DBNull.Value)
                    {
                        retorno.IIMPSALDOANT = (decimal)(dr["IMPSALDOANT"]);
                    }

                    if (dr["IMPPAGADO"] != System.DBNull.Value)
                    {
                        retorno.IIMPPAGADO = (decimal)(dr["IMPPAGADO"]);
                    }

                    if (dr["IMPSALDOINSOLUTO"] != System.DBNull.Value)
                    {
                        retorno.IIMPSALDOINSOLUTO = (decimal)(dr["IMPSALDOINSOLUTO"]);
                    }

                    if (dr["TOTALTRASLADOS"] != System.DBNull.Value)
                    {
                        retorno.ITOTALTRASLADOS = (decimal)(dr["TOTALTRASLADOS"]);
                    }

                    if (dr["TOTALRETENCIONES"] != System.DBNull.Value)
                    {
                        retorno.ITOTALRETENCIONES = (decimal)(dr["TOTALRETENCIONES"]);
                    }

                    if (dr["TIPORELACION"] != System.DBNull.Value)
                    {
                        retorno.ITIPORELACION = (string)(dr["TIPORELACION"]);
                    }

                    if (dr["UUID"] != System.DBNull.Value)
                    {
                        retorno.IUUID = (string)(dr["UUID"]);
                    }

                    if (dr["IMPRIMIRCOMPROBANTESPAGO"] != System.DBNull.Value)
                    {
                        retorno.IIMPRIMIRCOMPROBANTESPAGO = (string)(dr["IMPRIMIRCOMPROBANTESPAGO"]);
                    }

                    if (dr["PADRELINEA"] != System.DBNull.Value)
                    {
                        retorno.IPADRELINEA = int.Parse(dr["PADRELINEA"].ToString());
                    }

                    if (dr["ORDENLINEA"] != System.DBNull.Value)
                    {
                        retorno.IORDENLINEA = int.Parse(dr["ORDENLINEA"].ToString());
                    }

                    if (dr["SUBORDEN"] != System.DBNull.Value)
                    {
                        retorno.ISUBORDEN = int.Parse(dr["SUBORDEN"].ToString());
                    }



                    if (dr["EXPORTACION"] != System.DBNull.Value)
                    {
                        retorno.IEXPORTACION = (string)(dr["EXPORTACION"]);
                    }

                    if (dr["OBJETOIMP"] != System.DBNull.Value)
                    {
                        retorno.IOBJETOIMP = (string)(dr["OBJETOIMP"]);
                    }

                    if (dr["DOMICILIOFISCAL"] != System.DBNull.Value)
                    {
                        retorno.IDOMICILIOFISCAL = (string)(dr["DOMICILIOFISCAL"]);
                    }


                    if (dr["PERIODICIDAD"] != System.DBNull.Value)
                    {
                        retorno.IPERIODICIDAD = (string)(dr["PERIODICIDAD"]);
                    }


                    if (dr["MESES"] != System.DBNull.Value)
                    {
                        retorno.IMESES = (string)(dr["MESES"]);
                    }


                    if (dr["ANIO"] != System.DBNull.Value)
                    {
                        retorno.IANIO = (string)(dr["ANIO"]);
                    }

                    retornoList.Add(retorno);
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retornoList;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;

                System.Windows.Forms.MessageBox.Show("Erroor" +  iComentario);

                return null;
            }



        }




        public bool FACTURAELECTRONICA_GUARDAR(long doctoId, string tipoComprobante, bool generarCartaPorte, string cartaPortIdccp, ref long cfdiId, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOCOMPROBANTE", FbDbType.VarChar);
                auxPar.Value = tipoComprobante;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CARTAPORTEGUARDAR", FbDbType.VarChar);
                auxPar.Value = generarCartaPorte ? "S" : "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARTAPORTE_IDCCP", FbDbType.VarChar);
                if (cartaPortIdccp != null)
                    auxPar.Value = cartaPortIdccp;
                else
                    auxPar.Value = DBNull.Value;
                parts.Add(auxPar);




                auxPar = new FbParameter("@CFDIID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"FACTURAELECTRONICA_GUARDAR";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        this.iComentario = "Hubo un error " + ((int)arParms[arParms.Length - 1].Value).ToString();
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    cfdiId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public CCOMPROBANTEFISCALLINEAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
