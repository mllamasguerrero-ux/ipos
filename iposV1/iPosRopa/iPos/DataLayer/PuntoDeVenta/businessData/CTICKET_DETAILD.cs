

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
	

	public class CTICKET_DETAILD
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



        public CTICKET_DETAILBE[] seleccionarTICKET_DETAIL(long doctoId, bool bRecargas,  FbTransaction st)
        {
            return seleccionarTICKET_DETAIL(doctoId, bRecargas, null,  st);
        }


  public CTICKET_DETAILBE[] seleccionarTICKET_DETAIL(long doctoId, bool bRecargas, long? creadoPorUserId, FbTransaction st)
  {

  CTICKET_DETAILBE retorno ;

      System.Collections.ArrayList buffDetails = new ArrayList();
      //CTICKET_DETAILBE bufferTicketDet;


       FbDataReader dr = null;
       FbConnection pcn = null;


  try
  {



      CDOCTOD doctoD = new CDOCTOD();
      CDOCTOBE doctoBE = new CDOCTOBE();
      doctoBE.IID = doctoId;

      doctoBE = doctoD.seleccionarDOCTO(doctoBE,null);


  System.Collections.ArrayList parts = new ArrayList();
  FbParameter auxPar;

  String CmdTxt = @"select * from " + ((bRecargas) ? "TICKET_DETAIL_RECARGAS_PROC(" : ((doctoBE.ITIPODOCTOID == 11 || doctoBE.ITIPODOCTOID == 41) && doctoBE.ISUBTIPODOCTOID == 6) ? "TICKET_DETAIL_TRASLADOS_PROC(" : "TICKET_DETAIL_PROC(") + @"@DOCTOID, @CREADOPOR_USERID) ";


				auxPar= new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);
				
                if(CmdTxt.Contains("@CREADOPOR_USERID"))
                {

                    auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                    auxPar.Value = creadoPorUserId != null && creadoPorUserId.HasValue ? creadoPorUserId.Value :  0;
                    parts.Add(auxPar);
                }



  FbParameter[] arParms= new FbParameter[parts.Count];
  parts.CopyTo(arParms,0);



  if(st==null)
      dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
  else
  dr = SqlHelper.ExecuteReader(st,CommandType.Text, CmdTxt,arParms);


  while (dr.Read())
  {
      retorno = new CTICKET_DETAILBE();

                                      if( dr["DOCTOID"]!= System.DBNull.Value)
                                     {
                                     retorno.IDOCTOID=(long)(dr["DOCTOID"]);
                                    }

                                      if( dr["CANTIDAD"]!= System.DBNull.Value)
                                     {
                                     retorno.ICANTIDAD=(decimal)(dr["CANTIDAD"]);
                                    }

                                      if( dr["DESCRIPCION1"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESCRIPCION1=(string)(dr["DESCRIPCION1"]);
                                    }

                                      if( dr["DESCRIPCION2"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESCRIPCION2=(string)(dr["DESCRIPCION2"]);
                                    }

                                      if( dr["PRECIO"]!= System.DBNull.Value)
                                     {
                                     retorno.IPRECIO=(decimal)(dr["PRECIO"]);
                                    }

                                      if( dr["DESCUENTO"]!= System.DBNull.Value)
                                     {
                                     retorno.IDESCUENTO=(decimal)(dr["DESCUENTO"]);
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

                                      if( dr["LOTE"]!= System.DBNull.Value)
                                     {
                                     retorno.ILOTE=(string)(dr["LOTE"]);
                                    }

                                      if( dr["FECHAVENCE"]!= System.DBNull.Value)
                                     {
                                     retorno.IFECHAVENCE=(DateTime)(dr["FECHAVENCE"]);
                                    }


                                      if (dr["FALTANTE"] != System.DBNull.Value)
                                      {
                                          retorno.IFALTANTE = (decimal)(dr["FALTANTE"]);
                                      }


                                      if (dr["CANTIDADSURTIDA"] != System.DBNull.Value)
                                      {
                                          retorno.ICANTIDADSURTIDA = (decimal)(dr["CANTIDADSURTIDA"]);
                                      }


                                      if (dr["CANTIDADNOMINAL"] != System.DBNull.Value)
                                      {
                                          retorno.ICANTIDADNOMINAL = (decimal)(dr["CANTIDADNOMINAL"]);
                                      }

                                      if (dr["IMPORTEDESCUENTO"] != System.DBNull.Value)
                                      {
                                          retorno.IIMPORTEDESCUENTO = (decimal)(dr["IMPORTEDESCUENTO"]);
                                      }

                                      if (dr["IMPORTEIVA"] != System.DBNull.Value)
                                      {
                                          retorno.IIMPORTEIVA = (decimal)(dr["IMPORTEIVA"]);
                                      }

                                      if (dr["DESCUENTOVALE"] != System.DBNull.Value)
                                      {
                                          retorno.IDESCUENTOVALE = (decimal)(dr["DESCUENTOVALE"]);
                                      }


                                      if (dr["TIPORECARGA"] != System.DBNull.Value)
                                      {
                                          retorno.ITIPORECARGA = (string)(dr["TIPORECARGA"]);
                                      }
                                      if (dr["PRECIOCONIVA"] != System.DBNull.Value)
                                      {
                                          retorno.IPRECIOCONIVA = (decimal)(dr["PRECIOCONIVA"]);
                                      }

                                      if (dr["DESCRIPCION3"] != System.DBNull.Value)
                                      {
                                          retorno.IDESCRIPCION3 = (string)(dr["DESCRIPCION3"]);
                                      }

                                      if (dr["ES_COMODIN"] != System.DBNull.Value)
                                      {
                                          retorno.IES_COMODIN = (string)(dr["ES_COMODIN"]);
                                      }


                                      if (dr["TASAIEPS"] != System.DBNull.Value)
                                      {
                                          retorno.ITASAIEPS = (decimal)(dr["TASAIEPS"]);
                                      }

                                      if (dr["ESKIT"] != System.DBNull.Value)
                                      {
                                          retorno.IESKIT = (string)(dr["ESKIT"]);
                                      }
                                      //if (dr["ESPARTEKIT"] != System.DBNull.Value)
                                      //{
                                      //    retorno.IESPARTEKIT = (string)(dr["ESPARTEKIT"]);
                                      //}

                                      if (dr["MOTIVODEVOLUCION"] != System.DBNull.Value)
                                      {
                                          retorno.IMOTIVODEVOLUCION = (string)(dr["MOTIVODEVOLUCION"]);
                                      }

                                      if (dr["MOVTOID"] != System.DBNull.Value)
                                      {
                                          retorno.IMOVTOID = (long)(dr["MOVTOID"]);
                                      }
                                      if (dr["EMIDAREQUESTID"] != System.DBNull.Value)
                                      {
                                          retorno.IEMIDAREQUESTID = (long)(dr["EMIDAREQUESTID"]);
                                      }


                                      if (dr["EMIDACOMISION"] != System.DBNull.Value)
                                      {
                                          retorno.IEMIDACOMISION = (decimal)(dr["EMIDACOMISION"]);
                                      }


                                      //if (dr["LOTEIMPORTADO"] != System.DBNull.Value)
                                      //{
                                      //    retorno.ILOTEIMPORTADO = (long)(dr["LOTEIMPORTADO"]);
                                      //}

                                      //if (dr["PEDIMENTO"] != System.DBNull.Value)
                                      //{
                                      //    retorno.IPEDIMENTO = (string)(dr["PEDIMENTO"]);
                                      //}

                                      //if (dr["FECHAIMPORTACION"] != System.DBNull.Value)
                                      //{
                                      //    retorno.IFECHAIMPORTACION = (DateTime)(dr["FECHAIMPORTACION"]);
                                      //}

                                      //if (dr["ADUANA"] != System.DBNull.Value)
                                      //{
                                      //    retorno.IADUANA = (string)(dr["ADUANA"]);
                                      //}

                                      //if (dr["TIPOCAMBIOIMPO"] != System.DBNull.Value)
                                      //{
                                      //    retorno.ITIPOCAMBIOIMPO = (decimal)(dr["TIPOCAMBIOIMPO"]);
                                      //}



                                      if (dr["STRPEDIMENTO"] != System.DBNull.Value)
                                      {
                                          retorno.ISTRPEDIMENTO = (string)(dr["STRPEDIMENTO"]);
                                      }



                                      if (dr["KITMOVTOID"] != System.DBNull.Value)
                                      {
                                          retorno.IKITMOVTOID = (long)(dr["KITMOVTOID"]);
                                      }


                                      if (dr["KITPRODUCTOID"] != System.DBNull.Value)
                                      {
                                          retorno.IKITPRODUCTOID = (long)(dr["KITPRODUCTOID"]);
                                      }

                                      if (dr["KITPRODCLAVE"] != System.DBNull.Value)
                                      {
                                          retorno.IKITPRODCLAVE = (string)(dr["KITPRODCLAVE"]);
                                      }


                                      if (dr["KITPRODNOMBRE"] != System.DBNull.Value)
                                      {
                                          retorno.IKITPRODNOMBRE = (string)(dr["KITPRODNOMBRE"]);
                                      }


                                      if (dr["KITPRODDESCRIPCION1"] != System.DBNull.Value)
                                      {
                                          retorno.IKITPRODDESCRIPCION1 = (string)(dr["KITPRODDESCRIPCION1"]);
                                      }

                                      if (dr["KITCANTIDAD"] != System.DBNull.Value)
                                      {
                                          retorno.IKITCANTIDAD = (decimal)(dr["KITCANTIDAD"]);
                                      }

                                      if (dr["COSTOENDOLAR"] != System.DBNull.Value)
                                      {
                                          retorno.ICOSTOENDOLAR = (decimal)(dr["COSTOENDOLAR"]);
                                      }

                                      if (dr["IMPORTEENDOLAR"] != System.DBNull.Value)
                                      {
                                          retorno.IIMPORTEENDOLAR = (decimal)(dr["IMPORTEENDOLAR"]);
                                      }

                                        if (dr["DESCPZACAJA"] != System.DBNull.Value)
                                        {
                                            retorno.IDESCPZACAJA = (string)(dr["DESCPZACAJA"]);
                                        }

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
                                      if (dr["PRODUCTOCLAVE"] != System.DBNull.Value)
                                      {
                                        retorno.IPRODUCTOCLAVE = (string)(dr["PRODUCTOCLAVE"]);
                                      }
                                      if (dr["PLAZOCLAVE"] != System.DBNull.Value)
                                      {
                                        retorno.IPLAZOCLAVE = (string)(dr["PLAZOCLAVE"]);
                                      }
                                      if (dr["EAN"] != System.DBNull.Value)
                                      {
                                        retorno.IEAN = (string)(dr["EAN"]);
                                      }


                    buffDetails.Add(retorno);

				}

             CTICKET_DETAILBE[] detailList = new CTICKET_DETAILBE[buffDetails.Count];
             buffDetails.CopyTo(detailList, 0);



             Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

             return detailList;
				
				
			}
			catch (Exception e)
			{

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                System.Windows.Forms.MessageBox.Show(this.iComentario);
				return null;
			}


			
		}








  public CTICKET_DETAILD()
  {
  this.sCadenaConexion=ConexionBD.ConexionString();
  //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


  //
  // TODO: Add constructor logic here
  //
  }
  }
  }
