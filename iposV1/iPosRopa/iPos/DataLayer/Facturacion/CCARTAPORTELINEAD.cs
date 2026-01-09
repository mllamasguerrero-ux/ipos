

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


    public class CCARTAPORTELINEAD
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


        public List<CCARTAPORTELINEABE> CARTAPORTE_XML(long lDoctoId, FbTransaction st)
        {



            List<CCARTAPORTELINEABE> retornoList = new List<CCARTAPORTELINEABE>();
            
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"CARTAPORTE_XML";

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = lDoctoId;
                parts.Add(auxPar);

                



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.StoredProcedure, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.StoredProcedure, CmdTxt, arParms);


                while (dr.Read())
                {
                    CCARTAPORTELINEABE retorno = new CCARTAPORTELINEABE();


                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }
                    

                    if (dr["TIPOLINEA"] != System.DBNull.Value)
                    {
                        retorno.ITIPOLINEA = (string)(dr["TIPOLINEA"]);
                    }

                    if (dr["TRANSPINTERNAC"] != System.DBNull.Value)
                    {
                        retorno.ITRANSPINTERNAC = (string)(dr["TRANSPINTERNAC"]);
                    }

                    if (dr["ENTRADASALIDAMERC"] != System.DBNull.Value)
                    {
                        retorno.IENTRADASALIDAMERC = (string)(dr["ENTRADASALIDAMERC"]);
                    }

                    if (dr["PAISORIGENDESTINO"] != System.DBNull.Value)
                    {
                        retorno.IPAISORIGENDESTINO = (string)(dr["PAISORIGENDESTINO"]);
                    }

                    if (dr["VIAENTRADASALIDA"] != System.DBNull.Value)
                    {
                        retorno.IVIAENTRADASALIDA = (string)(dr["VIAENTRADASALIDA"]);
                    }

                    if (dr["TOTALDISTREC"] != System.DBNull.Value)
                    {
                        retorno.ITOTALDISTREC = (string)(dr["TOTALDISTREC"]);
                    }

                    if (dr["TIPOUBICACION"] != System.DBNull.Value)
                    {
                        retorno.ITIPOUBICACION = (string)(dr["TIPOUBICACION"]);
                    }

                    if (dr["IDUBICACION"] != System.DBNull.Value)
                    {
                        retorno.IIDUBICACION = (string)(dr["IDUBICACION"]);
                    }

                    if (dr["RFCREMITENTEDESTINATARIO"] != System.DBNull.Value)
                    {
                        retorno.IRFCREMITENTEDESTINATARIO = (string)(dr["RFCREMITENTEDESTINATARIO"]);
                    }

                    if (dr["NOMBREREMITENTEDESTINATARIO"] != System.DBNull.Value)
                    {
                        retorno.INOMBREREMITENTEDESTINATARIO = (string)(dr["NOMBREREMITENTEDESTINATARIO"]);
                    }

                    if (dr["NUMREGIDTRIB"] != System.DBNull.Value)
                    {
                        retorno.INUMREGIDTRIB = (string)(dr["NUMREGIDTRIB"]);
                    }

                    if (dr["RESIDENCIAFISCAL"] != System.DBNull.Value)
                    {
                        retorno.IRESIDENCIAFISCAL = (string)(dr["RESIDENCIAFISCAL"]);
                    }

                    if (dr["NUMESTACION"] != System.DBNull.Value)
                    {
                        retorno.INUMESTACION = (string)(dr["NUMESTACION"]);
                    }

                    if (dr["NOMBREESTACION"] != System.DBNull.Value)
                    {
                        retorno.INOMBREESTACION = (string)(dr["NOMBREESTACION"]);
                    }

                    if (dr["NAVEGACIONTRAFICO"] != System.DBNull.Value)
                    {
                        retorno.INAVEGACIONTRAFICO = (string)(dr["NAVEGACIONTRAFICO"]);
                    }

                    if (dr["FECHAHORASALIDALLEGADA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORASALIDALLEGADA = (string)(dr["FECHAHORASALIDALLEGADA"]);
                    }

                    if (dr["TIPOESTACION"] != System.DBNull.Value)
                    {
                        retorno.ITIPOESTACION = (string)(dr["TIPOESTACION"]);
                    }

                    if (dr["DISTANCIARECORRIDA"] != System.DBNull.Value)
                    {
                        retorno.IDISTANCIARECORRIDA = (string)(dr["DISTANCIARECORRIDA"]);
                    }

                    if (dr["CALLE"] != System.DBNull.Value)
                    {
                        retorno.ICALLE = (string)(dr["CALLE"]);
                    }

                    if (dr["NUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROEXTERIOR = (string)(dr["NUMEROEXTERIOR"]);
                    }

                    if (dr["NUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROINTERIOR = (string)(dr["NUMEROINTERIOR"]);
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

                    if (dr["PESOBRUTOTOTAL"] != System.DBNull.Value)
                    {
                        retorno.IPESOBRUTOTOTAL = (string)(dr["PESOBRUTOTOTAL"]);
                    }

                    if (dr["UNIDADPESO"] != System.DBNull.Value)
                    {
                        retorno.IUNIDADPESO = (string)(dr["UNIDADPESO"]);
                    }

                    if (dr["PESONETOTOTAL"] != System.DBNull.Value)
                    {
                        retorno.IPESONETOTOTAL = (string)(dr["PESONETOTOTAL"]);
                    }

                    if (dr["NUMTOTALMERCANCIAS"] != System.DBNull.Value)
                    {
                        retorno.INUMTOTALMERCANCIAS = (string)(dr["NUMTOTALMERCANCIAS"]);
                    }

                    if (dr["CARGOPORTASACION"] != System.DBNull.Value)
                    {
                        retorno.ICARGOPORTASACION = (string)(dr["CARGOPORTASACION"]);
                    }

                    if (dr["BIENESTRANSP"] != System.DBNull.Value)
                    {
                        retorno.IBIENESTRANSP = (string)(dr["BIENESTRANSP"]);
                    }

                    if (dr["CLAVESTCC"] != System.DBNull.Value)
                    {
                        retorno.ICLAVESTCC = (string)(dr["CLAVESTCC"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (string)(dr["CANTIDAD"]);
                    }

                    if (dr["CLAVEUNIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEUNIDAD = (string)(dr["CLAVEUNIDAD"]);
                    }

                    if (dr["UNIDAD"] != System.DBNull.Value)
                    {
                        retorno.IUNIDAD = (string)(dr["UNIDAD"]);
                    }

                    if (dr["DIMENSIONES"] != System.DBNull.Value)
                    {
                        retorno.IDIMENSIONES = (string)(dr["DIMENSIONES"]);
                    }

                    if (dr["MATERIALPELIGROSO"] != System.DBNull.Value)
                    {
                        retorno.IMATERIALPELIGROSO = (string)(dr["MATERIALPELIGROSO"]);
                    }

                    if (dr["CVEMATERIALPELIGROSO"] != System.DBNull.Value)
                    {
                        retorno.ICVEMATERIALPELIGROSO = (string)(dr["CVEMATERIALPELIGROSO"]);
                    }

                    if (dr["EMBALAJE"] != System.DBNull.Value)
                    {
                        retorno.IEMBALAJE = (string)(dr["EMBALAJE"]);
                    }

                    if (dr["DESCRIPEMBALAJE"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPEMBALAJE = (string)(dr["DESCRIPEMBALAJE"]);
                    }

                    if (dr["PESOENKG"] != System.DBNull.Value)
                    {
                        retorno.IPESOENKG = (string)(dr["PESOENKG"]);
                    }

                    if (dr["VALORMERCANCIA"] != System.DBNull.Value)
                    {
                        retorno.IVALORMERCANCIA = (string)(dr["VALORMERCANCIA"]);
                    }

                    if (dr["MONEDA"] != System.DBNull.Value)
                    {
                        retorno.IMONEDA = (string)(dr["MONEDA"]);
                    }

                    if (dr["FRACCIONARANCELARIA"] != System.DBNull.Value)
                    {
                        retorno.IFRACCIONARANCELARIA = (string)(dr["FRACCIONARANCELARIA"]);
                    }

                    if (dr["UUIDCOMERCIOEXT"] != System.DBNull.Value)
                    {
                        retorno.IUUIDCOMERCIOEXT = (string)(dr["UUIDCOMERCIOEXT"]);
                    }

                    if (dr["UNIDADPESOMERC"] != System.DBNull.Value)
                    {
                        retorno.IUNIDADPESOMERC = (string)(dr["UNIDADPESOMERC"]);
                    }

                    if (dr["PESOBRUTO"] != System.DBNull.Value)
                    {
                        retorno.IPESOBRUTO = (string)(dr["PESOBRUTO"]);
                    }

                    if (dr["PESONETO"] != System.DBNull.Value)
                    {
                        retorno.IPESONETO = (string)(dr["PESONETO"]);
                    }

                    if (dr["PESOTARA"] != System.DBNull.Value)
                    {
                        retorno.IPESOTARA = (string)(dr["PESOTARA"]);
                    }

                    if (dr["NUMPIEZAS"] != System.DBNull.Value)
                    {
                        retorno.INUMPIEZAS = (string)(dr["NUMPIEZAS"]);
                    }

                    if (dr["IDORIGEN"] != System.DBNull.Value)
                    {
                        retorno.IIDORIGEN = (string)(dr["IDORIGEN"]);
                    }

                    if (dr["IDDESTINO"] != System.DBNull.Value)
                    {
                        retorno.IIDDESTINO = (string)(dr["IDDESTINO"]);
                    }

                    if (dr["CVESTRANSPORTE"] != System.DBNull.Value)
                    {
                        retorno.ICVESTRANSPORTE = (string)(dr["CVESTRANSPORTE"]);
                    }

                    if (dr["TIPOFIGURA"] != System.DBNull.Value)
                    {
                        retorno.ITIPOFIGURA = (string)(dr["TIPOFIGURA"]);
                    }

                    if (dr["RFCFIGURA"] != System.DBNull.Value)
                    {
                        retorno.IRFCFIGURA = (string)(dr["RFCFIGURA"]);
                    }

                    if (dr["NUMLICENCIA"] != System.DBNull.Value)
                    {
                        retorno.INUMLICENCIA = (string)(dr["NUMLICENCIA"]);
                    }

                    if (dr["NOMBREFIGURA"] != System.DBNull.Value)
                    {
                        retorno.INOMBREFIGURA = (string)(dr["NOMBREFIGURA"]);
                    }

                    if (dr["NUMREGIDTRIBFIGURA"] != System.DBNull.Value)
                    {
                        retorno.INUMREGIDTRIBFIGURA = (string)(dr["NUMREGIDTRIBFIGURA"]);
                    }

                    if (dr["RESIDENCIAFISCALFIGURA"] != System.DBNull.Value)
                    {
                        retorno.IRESIDENCIAFISCALFIGURA = (string)(dr["RESIDENCIAFISCALFIGURA"]);
                    }

                    if (dr["PARTETRANSPORTE"] != System.DBNull.Value)
                    {
                        retorno.IPARTETRANSPORTE = (string)(dr["PARTETRANSPORTE"]);
                    }

                    if (dr["PERMSCT"] != System.DBNull.Value)
                    {
                        retorno.IPERMSCT = (string)(dr["PERMSCT"]);
                    }

                    if (dr["NUMPERMISOSCT"] != System.DBNull.Value)
                    {
                        retorno.INUMPERMISOSCT = (string)(dr["NUMPERMISOSCT"]);
                    }

                    if (dr["CONFIGVEHICULAR"] != System.DBNull.Value)
                    {
                        retorno.ICONFIGVEHICULAR = (string)(dr["CONFIGVEHICULAR"]);
                    }

                    if (dr["PLACAVM"] != System.DBNull.Value)
                    {
                        retorno.IPLACAVM = (string)(dr["PLACAVM"]);
                    }

                    if (dr["ANIOMODELOVM"] != System.DBNull.Value)
                    {
                        retorno.IANIOMODELOVM = (string)(dr["ANIOMODELOVM"]);
                    }

                    if (dr["ASEGURARESPCIVIL"] != System.DBNull.Value)
                    {
                        retorno.IASEGURARESPCIVIL = (string)(dr["ASEGURARESPCIVIL"]);
                    }

                    if (dr["POLIZARESPCIVIL"] != System.DBNull.Value)
                    {
                        retorno.IPOLIZARESPCIVIL = (string)(dr["POLIZARESPCIVIL"]);
                    }

                    if (dr["ASEGURAMEDAMBIENTE"] != System.DBNull.Value)
                    {
                        retorno.IASEGURAMEDAMBIENTE = (string)(dr["ASEGURAMEDAMBIENTE"]);
                    }

                    if (dr["POLIZAMEDAMBIENTE"] != System.DBNull.Value)
                    {
                        retorno.IPOLIZAMEDAMBIENTE = (string)(dr["POLIZAMEDAMBIENTE"]);
                    }

                    if (dr["ASEGURACARGA"] != System.DBNull.Value)
                    {
                        retorno.IASEGURACARGA = (string)(dr["ASEGURACARGA"]);
                    }

                    if (dr["POLIZACARGA"] != System.DBNull.Value)
                    {
                        retorno.IPOLIZACARGA = (string)(dr["POLIZACARGA"]);
                    }

                    if (dr["PRIMASEGURO"] != System.DBNull.Value)
                    {
                        retorno.IPRIMASEGURO = (string)(dr["PRIMASEGURO"]);
                    }

                    if (dr["SUBTIPOREM1"] != System.DBNull.Value)
                    {
                        retorno.ISUBTIPOREM1 = (string)(dr["SUBTIPOREM1"]);
                    }

                    if (dr["PLACA1"] != System.DBNull.Value)
                    {
                        retorno.IPLACA1 = (string)(dr["PLACA1"]);
                    }

                    if (dr["SUBTIPOREM2"] != System.DBNull.Value)
                    {
                        retorno.ISUBTIPOREM2 = (string)(dr["SUBTIPOREM2"]);
                    }

                    if (dr["PLACA2"] != System.DBNull.Value)
                    {
                        retorno.IPLACA2 = (string)(dr["PLACA2"]);
                    }


                    if (dr["CLAVEPRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEPRODUCTO = (string)dr["CLAVEPRODUCTO"];
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

                    if (dr["PESOBRUTOVEHICULAR"] != System.DBNull.Value)
                    {
                        retorno.IPESOBRUTOVEHICULAR = long.Parse(dr["PESOBRUTOVEHICULAR"].ToString());
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
                return null;
            }



        }








        
        public CCARTAPORTELINEAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
