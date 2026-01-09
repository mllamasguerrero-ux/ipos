
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Data.Odbc;
using DataLayer;

namespace iPosData
{
	
	[Transaction(TransactionOption.Supported)]    
	

	public class CTICKET_HEADERD
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
				this.iComentario= value;
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



  [AutoComplete]
  public CTICKET_HEADERBE seleccionarTICKET_HEADER(CTICKET_HEADERBE oCTICKET_HEADER,FbTransaction st)
  {




      CTICKET_HEADERBE retorno = new CTICKET_HEADERBE();
       FbDataReader dr = null;
       FbConnection pcn = null;

  try
  {

  System.Collections.ArrayList parts = new ArrayList();
  FbParameter auxPar;

  String CmdTxt = @"select * from TICKET_HEADER where
 DOCTOID=@DOCTOID  ";


				auxPar= new FbParameter("@DOCTOID", FbDbType.BigInt);
                                auxPar.Value=oCTICKET_HEADER.IDOCTOID;
                                  parts.Add(auxPar);
				




  FbParameter[] arParms= new FbParameter[parts.Count];
  parts.CopyTo(arParms,0);



  if(st==null)
  dr = SqlHelper.ExecuteReader(this.sCadenaConexion,CommandType.Text, CmdTxt, out pcn, arParms);
  else
  dr = SqlHelper.ExecuteReader(st,CommandType.Text, CmdTxt,arParms);


  if (dr.Read())
  {

                                      if( dr["DOCTOID"]!= System.DBNull.Value)
                                     {
                                     retorno.IDOCTOID=(long)(dr["DOCTOID"]);
                                    }

                                      if( dr["ESTATUSDOCTOID"]!= System.DBNull.Value)
                                     {
                                     retorno.IESTATUSDOCTOID=(long)(dr["ESTATUSDOCTOID"]);
                                    }

                                      if( dr["ALMACENID"]!= System.DBNull.Value)
                                     {
                                     retorno.IALMACENID=(long)(dr["ALMACENID"]);
                                    }

                                      if( dr["SUCURSALID"]!= System.DBNull.Value)
                                     {
                                     retorno.ISUCURSALID=(long)(dr["SUCURSALID"]);
                                    }

                                      if( dr["PERSONAID"]!= System.DBNull.Value)
                                     {
                                     retorno.IPERSONAID=(long)(dr["PERSONAID"]);
                                    }

                                      if( dr["TIPODOCTOID"]!= System.DBNull.Value)
                                     {
                                     retorno.ITIPODOCTOID=(long)(dr["TIPODOCTOID"]);
                                    }

                                      if( dr["TOTAL"]!= System.DBNull.Value)
                                     {
                                     retorno.ITOTAL=(decimal)(dr["TOTAL"]);
                                    }

                                      if( dr["NOMBRE"]!= System.DBNull.Value)
                                     {
                                     retorno.INOMBRE=(string)(dr["NOMBRE"]);
                                    }

                                      if( dr["DESCRIPCION"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESCRIPCION=(string)(dr["DESCRIPCION"]);
                                    }

                                      if( dr["RFC"]!= System.DBNull.Value)
                                     {
                                     retorno.IRFC=(string)(dr["RFC"]);
                                    }

                                      if( dr["COLONIA"]!= System.DBNull.Value)
                                     {
                                     retorno.ICOLONIA=(string)(dr["COLONIA"]);
                                    }

                                      if( dr["DOMICICIO"]!= System.DBNull.Value)
                                     {
                                     retorno.IDOMICICIO=(string)(dr["DOMICICIO"]);
                                    }

                                      if( dr["CODIGOPOSTAL"]!= System.DBNull.Value)
                                     {
                                     retorno.ICODIGOPOSTAL=(string)(dr["CODIGOPOSTAL"]);
                                    }

                                      if( dr["RAZON_SOCIAL"]!= System.DBNull.Value)
                                     {
                                     retorno.IRAZON_SOCIAL=(string)(dr["RAZON_SOCIAL"]);
                                    }

                                      if( dr["TELEFONO"]!= System.DBNull.Value)
                                     {
                                     retorno.ITELEFONO=(string)(dr["TELEFONO"]);
                                    }

                                      if( dr["CIUDAD"]!= System.DBNull.Value)
                                     {
                                     retorno.ICIUDAD=(string)(dr["CIUDAD"]);
                                    }

                                      if( dr["ESTADO"]!= System.DBNull.Value)
                                     {
                                     retorno.IESTADO=(string)(dr["ESTADO"]);
                                    }

                                      if( dr["MUNICIPIO"]!= System.DBNull.Value)
                                     {
                                     retorno.IMUNICIPIO=(string)(dr["MUNICIPIO"]);
                                    }


                                      if (dr["TICKET"] != System.DBNull.Value)
                                      {
                                          retorno.ITICKET = int.Parse(dr["TICKET"].ToString());
                                      }


                                      if (dr["SUCURSALTID"] != System.DBNull.Value)
                                      {
                                          retorno.ISUCURSALTID = (long)(dr["SUCURSALTID"]);
                                      }

                                      if (dr["VENDEDORID"] != System.DBNull.Value)
                                      {
                                          retorno.IVENDEDORID = (long)(dr["VENDEDORID"]);
                                      }
                                      if (dr["ORIGENFISCALID"] != System.DBNull.Value)
                                      {
                                          retorno.IORIGENFISCALID = (long)(dr["ORIGENFISCALID"]);
                                      }
                                      if (dr["FECHA"] != System.DBNull.Value)
                                      {
                                          retorno.IFECHA = (DateTime)(dr["FECHA"]);
                                      }

                                      if (dr["VENDEDOR"] != System.DBNull.Value)
                                      {
                                          retorno.IVENDEDOR = (string)(dr["VENDEDOR"]);
                                      }
                                      if (dr["PERSONAAPARTADOID"] != System.DBNull.Value)
                                      {
                                          retorno.IPERSONAAPARTADOID = (long)(dr["PERSONAAPARTADOID"]);
                                      }

                                      if (dr["NUMEROEXTERIOR"] != System.DBNull.Value)
                                      {
                                          retorno.INUMEROEXTERIOR = (string)(dr["NUMEROEXTERIOR"]);
                                      }

                                      if (dr["NUMEROINTERIOR"] != System.DBNull.Value)
                                      {
                                          retorno.INUMEROINTERIOR = (string)(dr["NUMEROINTERIOR"]);
                                      }

                                      if (dr["REFERENCIA"] != System.DBNull.Value)
                                      {
                                          retorno.IREFERENCIA = (string)(dr["REFERENCIA"]);
                                      }


                                      if (dr["DOCTOREF_FOLIO"] != System.DBNull.Value)
                                      {
                                          retorno.IDOCTOREF_FOLIO = int.Parse(dr["DOCTOREF_FOLIO"].ToString());
                                      }


                                      if (dr["DOCTOREF_REFERENCIA"] != System.DBNull.Value)
                                      {
                                          retorno.IDOCTOREF_REFERENCIA = (string)(dr["DOCTOREF_REFERENCIA"]);
                                      }

                                      if (dr["SUBTIPODOCTOID"] != System.DBNull.Value)
                                      {
                                          retorno.ISUBTIPODOCTOID = long.Parse(dr["SUBTIPODOCTOID"].ToString());
                                      }

                                      if (dr["ALMACENTID"] != System.DBNull.Value)
                                      {
                                          retorno.IALMACENTID = (long)(dr["ALMACENTID"]);
                                      }

                                      if (dr["OBSERVACION"] != System.DBNull.Value)
                                      {
                                          retorno.IOBSERVACION = (string)(dr["OBSERVACION"]);
                                      }

                                      if (dr["RUTAEMBARQUECLAVE"] != System.DBNull.Value)
                                      {
                                          retorno.IRUTAEMBARQUECLAVE = (string)(dr["RUTAEMBARQUECLAVE"]);
                                      }

                                      if (dr["RUTAEMBARQUENOMBRE"] != System.DBNull.Value)
                                      {
                                          retorno.IRUTAEMBARQUENOMBRE = (string)(dr["RUTAEMBARQUENOMBRE"]);
                                      }

                                      if (dr["ORDENCOMPRA"] != System.DBNull.Value)
                                      {
                                          retorno.IORDENCOMPRA = (string)(dr["ORDENCOMPRA"]);
                                      }

                                     if (dr["ALMACENCLAVE"] != System.DBNull.Value)
                                     {
                                        retorno.IALMACENCLAVE = (string)(dr["ALMACENCLAVE"]);
                                     }

                                    if (dr["ALMACENNOMBRE"] != System.DBNull.Value)
                                    {
                                        retorno.IALMACENNOMBRE = (string)(dr["ALMACENNOMBRE"]);
                                    }



                }
				else
				{
					retorno =null;
				}



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
				
				return retorno;
			}
			catch (Exception e)
			{

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
				this.iComentario=e.Message + e.StackTrace;
				return null;
			}


			
		}






        public bool seleccionarTICKET_CAJASPIEZAS(CTICKET_HEADERBE oCTICKET_HEADER, ref decimal kilogramos, ref decimal piezas, ref decimal cajas, FbTransaction st)
        {




            CTICKET_HEADERBE retorno = new CTICKET_HEADERBE();
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"SELECT

        sum(case
            when  producto.unidad = 'KG' then
                 (CASE WHEN (docto.tipodoctoid in  (41)) THEN cast(movto.cantidadsurtida as numeric(18,3)) ELSE cast(movto.cantidad as numeric(18,3)) END )
           
            else
                0.00

        end)  KILOGRAMOS,

        sum(case
            when  producto.unidad = 'KG' then
                 0.00
            when  ( coalesce(producto.pzacaja,0) = 0 or  coalesce(producto.pzacaja,0) = 1 ) then
                 0.00
            else
                trunc(coalesce(     (CASE WHEN (docto.tipodoctoid in  (41)) THEN movto.cantidadsurtida ELSE movto.cantidad END   )   ,0)/coalesce(producto.pzacaja,1))
        end )  CAJAS ,

        sum(case
            when  producto.unidad = 'KG' then
                 0.00
            when  ( coalesce(producto.pzacaja,0) = 0 or  coalesce(producto.pzacaja,0) = 1 ) then
                 (CASE WHEN (docto.tipodoctoid in  (41)) THEN movto.cantidadsurtida ELSE movto.cantidad END )
            else
                mod(coalesce(    (CASE WHEN (docto.tipodoctoid in  (41)) THEN movto.cantidadsurtida ELSE movto.cantidad END )   ,0),coalesce(producto.pzacaja,1))
        end ) PIEZAS





        FROM
        docto
        left join MOVTO on docto.id = movto.doctoid
        left JOIN PRODUCTO ON MOVTO.productoid = PRODUCTO.ID
        left join parametro on 1 = 1



where docto.id = @doctoid
       ";


                auxPar = new FbParameter("@doctoid", FbDbType.BigInt);
                auxPar.Value = oCTICKET_HEADER.IDOCTOID;
                parts.Add(auxPar);





                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["KILOGRAMOS"] != System.DBNull.Value)
                    {
                        kilogramos = (decimal)(dr["KILOGRAMOS"]);
                    }

                    if (dr["PIEZAS"] != System.DBNull.Value)
                    {
                        piezas = (decimal)(dr["PIEZAS"]);
                    }

                    if (dr["CAJAS"] != System.DBNull.Value)
                    {
                        cajas = (decimal)(dr["CAJAS"]);
                    }
                    


                }
                else
                {
                    retorno = null;
                }



                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return true;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }



        }

        public CTICKET_HEADERD()
  {
  this.sCadenaConexion=ConexionBD.ConexionString();
  //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


  //
  // TODO: Add constructor logic here
  //
  }
  }
  }
