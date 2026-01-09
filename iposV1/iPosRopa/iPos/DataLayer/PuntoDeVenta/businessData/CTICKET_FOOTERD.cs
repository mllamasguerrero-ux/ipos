

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
	

	public class CTICKET_FOOTERD
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



        public CTICKET_FOOTERBE seleccionarTICKET_FOOTER(CTICKET_FOOTERBE oCTICKET_FOOTER, bool bRecargas, FbTransaction st)
  {




      CTICKET_FOOTERBE retorno = new CTICKET_FOOTERBE();
       FbDataReader dr = null;
       FbConnection pcn = null;

  try
  {


   CDOCTOD doctoD = new CDOCTOD();
   CDOCTOBE doctoBE = new CDOCTOBE();
   doctoBE.IID = oCTICKET_FOOTER.IDOCTOID;

   doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

  System.Collections.ArrayList parts = new ArrayList();
  FbParameter auxPar;

  //String CmdTxt = @"select * from  " + ((bRecargas) ? "TICKET_FOOTER_RECARGAS" : "TICKET_FOOTER") + @"  where DOCTOID=@DOCTOID    ";
  String CmdTxt = @"select * from " + ((bRecargas) ? "TICKET_FOOTER_RECARGAS" : ((doctoBE.ITIPODOCTOID == 11 || doctoBE.ITIPODOCTOID == 41) && doctoBE.ISUBTIPODOCTOID == 6) ? "TICKET_FOOTER_TRASLADO" : "TICKET_FOOTER") + @" where DOCTOID=@DOCTOID ";


				auxPar= new FbParameter("@DOCTOID", FbDbType.BigInt);
                                auxPar.Value=oCTICKET_FOOTER.IDOCTOID;
                                  parts.Add(auxPar);
				

  FbParameter[] arParms= new FbParameter[parts.Count];
  parts.CopyTo(arParms,0);


  if(st==null)
      dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
  else
  dr = SqlHelper.ExecuteReader(st,CommandType.Text, CmdTxt,arParms);


  if (dr.Read())
  {

                                      if( dr["DOCTOID"]!= System.DBNull.Value)
                                     {
                                     retorno.IDOCTOID=(long)(dr["DOCTOID"]);
                                    }

                                      if( dr["SUBTOTAL"]!= System.DBNull.Value)
                                     {
                                     retorno.ISUBTOTAL=(decimal)(dr["SUBTOTAL"]);
                                    }

                                      if( dr["IVA"]!= System.DBNull.Value)
                                     {
                                     retorno.IIVA=(decimal)(dr["IVA"]);
                                    }

                                      if( dr["TOTAL"]!= System.DBNull.Value)
                                     {
                                     retorno.ITOTAL=(decimal)(dr["TOTAL"]);
                                    }

                                      if( dr["TOTAL_CON_LETRA"]!= System.DBNull.Value)
                                     {
                                     retorno.ITOTAL_CON_LETRA=(string)(dr["TOTAL_CON_LETRA"]);
                                    }



                                      if (dr["DESCUENTO_TOTAL"] != System.DBNull.Value)
                                      {
                                          retorno.IDESCUENTO_TOTAL = (decimal)(dr["DESCUENTO_TOTAL"]);
                                      }

                                      if (dr["CAMBIO"] != System.DBNull.Value)
                                      {
                                          retorno.ICAMBIO = (decimal)(dr["CAMBIO"]);
                                      }

                                      if (dr["CAJA"] != System.DBNull.Value)
                                      {
                                          retorno.ICAJA = (string)(dr["CAJA"]);
                                      }

                                      if (dr["TURNO"] != System.DBNull.Value)
                                      {
                                          retorno.ITURNO = (string)(dr["TURNO"]);
                                      }


                                      if (dr["PAGOEFECTIVO"] != System.DBNull.Value)
                                      {
                                          retorno.IPAGOEFECTIVO = (decimal)(dr["PAGOEFECTIVO"]);
                                      }

                                      if (dr["PAGOTARJETA"] != System.DBNull.Value)
                                      {
                                          retorno.IPAGOTARJETA = (decimal)(dr["PAGOTARJETA"]);
                                      }

                                      if (dr["PAGOCREDITO"] != System.DBNull.Value)
                                      {
                                          retorno.IPAGOCREDITO = (decimal)(dr["PAGOCREDITO"]);
                                      }

                                      if (dr["PAGOCHEQUE"] != System.DBNull.Value)
                                      {
                                          retorno.IPAGOCHEQUE = (decimal)(dr["PAGOCHEQUE"]);
                                      }


                                      if (dr["PAGOVALE"] != System.DBNull.Value)
                                      {
                                          retorno.IPAGOVALE = (decimal)(dr["PAGOVALE"]);
                                      }
                                      if (dr["ABONO"] != System.DBNull.Value)
                                      {
                                          retorno.IABONO = (decimal)(dr["ABONO"]);
                                      }
                                      if (dr["SALDO"] != System.DBNull.Value)
                                      {
                                          retorno.ISALDO = (decimal)(dr["SALDO"]);
                                      }



                                      if (dr["PAGOMONEDERO"] != System.DBNull.Value)
                                      {
                                          retorno.IPAGOMONEDERO = (decimal)(dr["PAGOMONEDERO"]);
                                      }
                                      if (dr["ABONOMONEDERO"] != System.DBNull.Value)
                                      {
                                          retorno.IABONOMONEDERO = (decimal)(dr["ABONOMONEDERO"]);
                                      }
                                      if (dr["SALDOMONEDERO"] != System.DBNull.Value)
                                      {
                                          retorno.ISALDOMONEDERO = (decimal)(dr["SALDOMONEDERO"]);
                                      }


                                      if (dr["VIGENCIAMONEDERO"] != System.DBNull.Value)
                                      {
                                          retorno.IVIGENCIAMONEDERO = (DateTime)(dr["VIGENCIAMONEDERO"]);
                                      }

                                      if (dr["MONEDERO"] != System.DBNull.Value)
                                      {
                                          retorno.IMONEDERO = (long)(dr["MONEDERO"]);
                                      }



                                      if (dr["PAGOTRANSFERENCIA"] != System.DBNull.Value)
                                      {
                                          retorno.IPAGOTRANSFERENCIA = (decimal)(dr["PAGOTRANSFERENCIA"]);
                                      }

                                      if (dr["PAGONOIDENTIFICADO"] != System.DBNull.Value)
                                      {
                                          retorno.IPAGONOIDENTIFICADO = (decimal)(dr["PAGONOIDENTIFICADO"]);
                                      }

                                      if (dr["FECHAFACTURA"] != System.DBNull.Value)
                                      {
                                          retorno.IFECHAFACTURA = (DateTime)(dr["FECHAFACTURA"]);
                                      }

                                      if (dr["NOTAPAGO"] != System.DBNull.Value)
                                      {
                                          retorno.INOTAPAGO = (string)(dr["NOTAPAGO"]);
                                      }

                                      if (dr["IMPORTEENDOLAR"] != System.DBNull.Value)
                                      {
                                          retorno.IIMPORTEENDOLAR = (decimal)(dr["IMPORTEENDOLAR"]);
                                      }

				}
				else
				{
					retorno =null;
				}


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                if(retorno != null)
                {
                    retorno = seleccionarTICKET_FOOTERSUMATORIAS(retorno, bRecargas, st);
                }
				
				return retorno;
			}
			catch (Exception e)
			{

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
				this.iComentario=e.Message + e.StackTrace;
				return null;
			}


			
		}





        public CTICKET_FOOTERBE seleccionarTICKET_FOOTERSUMATORIAS(CTICKET_FOOTERBE oCTICKET_FOOTER, bool bRecargas, FbTransaction st)
        {




            CTICKET_FOOTERBE retorno = oCTICKET_FOOTER;
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                //String CmdTxt = @"select * from  " + ((bRecargas) ? "TICKET_FOOTER_RECARGAS" : "TICKET_FOOTER") + @"  where DOCTOID=@DOCTOID    ";
                String CmdTxt = @"select * from TICKET_SUMATORIA where DOCTOID=@DOCTOID ";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCTICKET_FOOTER.IDOCTOID;
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
                        retorno.IKILOGRAMOS = (decimal)(dr["KILOGRAMOS"]);
                    }

                    if (dr["CAJAS"] != System.DBNull.Value)
                    {
                        retorno.ICAJAS = (decimal)(dr["CAJAS"]);
                    }

                    if (dr["PIEZAS"] != System.DBNull.Value)
                    {
                        retorno.IPIEZAS = (decimal)(dr["PIEZAS"]);
                    }

                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }










        public CTICKET_FOOTERD()
  {
  this.sCadenaConexion=ConexionBD.ConexionString();
  //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


  //
  // TODO: Add constructor logic here
  //
  }
  }
  }
