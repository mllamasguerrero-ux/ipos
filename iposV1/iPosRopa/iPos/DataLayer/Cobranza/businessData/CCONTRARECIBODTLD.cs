

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;

namespace iPosData
{

    [Transaction(TransactionOption.Supported)]


    public class CCONTRARECIBODTLD
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


        [AutoComplete]
        public CCONTRARECIBODTLBE AgregarCONTRARECIBODTLD(CCONTRARECIBODTLBE oCCONTRARECIBODTL, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCONTRARECIBODTL.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CONTRARECIBOID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBODTL.isnull["ICONTRARECIBOID"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.ICONTRARECIBOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBODTL.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCCONTRARECIBODTL.isnull["IFECHA"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)oCCONTRARECIBODTL.isnull["IFECHAVENCE"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IFECHAVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                if (!(bool)oCCONTRARECIBODTL.isnull["IFOLIO"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SERIE", FbDbType.VarChar);
                if (!(bool)oCCONTRARECIBODTL.isnull["ISERIE"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.ISERIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOLIOSAT", FbDbType.Integer);
                if (!(bool)oCCONTRARECIBODTL.isnull["IFOLIOSAT"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IFOLIOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SERIESAT", FbDbType.VarChar);
                if (!(bool)oCCONTRARECIBODTL.isnull["ISERIESAT"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.ISERIESAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBODTL.isnull["IESTATUSID"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IESTATUSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOTALDOCTO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTL.isnull["ITOTALDOCTO"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.ITOTALDOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ABONODOCTO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTL.isnull["IABONODOCTO"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IABONODOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDODOCTO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTL.isnull["ISALDODOCTO"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.ISALDODOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTL.isnull["ITOTAL"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ABONO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTL.isnull["IABONO"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTL.isnull["ISALDO"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO CONTRARECIBODTL
      (

ACTIVO,

CONTRARECIBOID,

DOCTOID,

FECHA,

FECHAVENCE,

FOLIO,

SERIE,

FOLIOSAT,

SERIESAT,

ESTATUSID,

TOTALDOCTO,

ABONODOCTO,

SALDODOCTO,

TOTAL,

ABONO,

SALDO
         )

Values (

@ACTIVO,

@CONTRARECIBOID,

@DOCTOID,

@FECHA,

@FECHAVENCE,

@FOLIO,

@SERIE,

@FOLIOSAT,

@SERIESAT,

@ESTATUSID,

@TOTALDOCTO,

@ABONODOCTO,

@SALDODOCTO,

@TOTAL,

@ABONO,

@SALDO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCCONTRARECIBODTL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarCONTRARECIBODTLD(CCONTRARECIBODTLBE oCCONTRARECIBODTL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCONTRARECIBODTL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from CONTRARECIBODTL
  where

  ID=@ID
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;




            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public bool CambiarCONTRARECIBODTLD(CCONTRARECIBODTLBE oCCONTRARECIBODTLNuevo, CCONTRARECIBODTLBE oCCONTRARECIBODTLAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONTRARECIBOID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["ICONTRARECIBOID"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.ICONTRARECIBOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["IFECHAVENCE"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.IFECHAVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["IFOLIO"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SERIE", FbDbType.VarChar);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["ISERIE"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.ISERIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FOLIOSAT", FbDbType.Integer);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["IFOLIOSAT"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.IFOLIOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SERIESAT", FbDbType.VarChar);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["ISERIESAT"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.ISERIESAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUSID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["IESTATUSID"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.IESTATUSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOTALDOCTO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["ITOTALDOCTO"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.ITOTALDOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ABONODOCTO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["IABONODOCTO"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.IABONODOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDODOCTO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["ISALDODOCTO"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.ISALDODOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["ITOTAL"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ABONO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["IABONO"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.IABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTLNuevo.isnull["ISALDO"])
                {
                    auxPar.Value = oCCONTRARECIBODTLNuevo.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBODTLAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCONTRARECIBODTLAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  CONTRARECIBODTL
  set

ACTIVO=@ACTIVO,

CONTRARECIBOID=@CONTRARECIBOID,

DOCTOID=@DOCTOID,

FECHA=@FECHA,

FECHAVENCE=@FECHAVENCE,

FOLIO=@FOLIO,

SERIE=@SERIE,

FOLIOSAT=@FOLIOSAT,

SERIESAT=@SERIESAT,

ESTATUSID=@ESTATUSID,

TOTALDOCTO=@TOTALDOCTO,

ABONODOCTO=@ABONODOCTO,

SALDODOCTO=@SALDODOCTO,

TOTAL=@TOTAL,

ABONO=@ABONO,

SALDO=@SALDO
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        [AutoComplete]
        public CCONTRARECIBODTLBE seleccionarCONTRARECIBODTL(CCONTRARECIBODTLBE oCCONTRARECIBODTL, FbTransaction st)
        {




            CCONTRARECIBODTLBE retorno = new CCONTRARECIBODTLBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CONTRARECIBODTL where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCONTRARECIBODTL.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["CONTRARECIBOID"] != System.DBNull.Value)
                    {
                        retorno.ICONTRARECIBOID = (long)(dr["CONTRARECIBOID"]);
                    }

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["FECHAVENCE"] != System.DBNull.Value)
                    {
                        retorno.IFECHAVENCE = (DateTime)(dr["FECHAVENCE"]);
                    }

                    if (dr["SERIE"] != System.DBNull.Value)
                    {
                        retorno.ISERIE = (string)(dr["SERIE"]);
                    }

                    if (dr["SERIESAT"] != System.DBNull.Value)
                    {
                        retorno.ISERIESAT = (string)(dr["SERIESAT"]);
                    }

                    if (dr["ESTATUSID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSID = (long)(dr["ESTATUSID"]);
                    }

                    if (dr["TOTALDOCTO"] != System.DBNull.Value)
                    {
                        retorno.ITOTALDOCTO = (decimal)(dr["TOTALDOCTO"]);
                    }

                    if (dr["ABONODOCTO"] != System.DBNull.Value)
                    {
                        retorno.IABONODOCTO = (decimal)(dr["ABONODOCTO"]);
                    }

                    if (dr["SALDODOCTO"] != System.DBNull.Value)
                    {
                        retorno.ISALDODOCTO = (decimal)(dr["SALDODOCTO"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                    }

                    if (dr["ABONO"] != System.DBNull.Value)
                    {
                        retorno.IABONO = (decimal)(dr["ABONO"]);
                    }

                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["FOLIO"] != System.DBNull.Value)
                    {
                        retorno.IFOLIO = int.Parse(dr["FOLIO"].ToString());
                    }

                    if (dr["FOLIOSAT"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOSAT = int.Parse(dr["FOLIOSAT"].ToString());
                    }

                }
                else
                {
                    retorno = null;
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









        [AutoComplete]
        public DataSet enlistarCONTRARECIBODTL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CONTRARECIBODTL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoCONTRARECIBODTL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CONTRARECIBODTL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteCONTRARECIBODTL(CCONTRARECIBODTLBE oCCONTRARECIBODTL, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCONTRARECIBODTL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CONTRARECIBODTL where

  ID=@ID  
  );";






                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {
                    retorno = 1;
                }
                else
                {
                    retorno = 0;
                } 
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }
        }



        



        public CCONTRARECIBODTLBE AgregarCONTRARECIBODTL(CCONTRARECIBODTLBE oCCONTRARECIBODTL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCONTRARECIBODTL(oCCONTRARECIBODTL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El CONTRARECIBODTL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCONTRARECIBODTLD(oCCONTRARECIBODTL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCONTRARECIBODTL(CCONTRARECIBODTLBE oCCONTRARECIBODTL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCONTRARECIBODTL(oCCONTRARECIBODTL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CONTRARECIBODTL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCONTRARECIBODTLD(oCCONTRARECIBODTL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCONTRARECIBODTL(CCONTRARECIBODTLBE oCCONTRARECIBODTLNuevo, CCONTRARECIBODTLBE oCCONTRARECIBODTLAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCONTRARECIBODTL(oCCONTRARECIBODTLAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CONTRARECIBODTL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCONTRARECIBODTLD(oCCONTRARECIBODTLNuevo, oCCONTRARECIBODTLAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public bool CONTRARECIBODETAIL_INSERT(CCONTRARECIBODTLBE oCCONTRARECIBODTL,CCONTRARECIBOHDRBE oCCONTRARECIBOHDR, ref long CONTRARECIBOID, ref long CONTRARECIBODTLID, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IFECHA"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.VarChar);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CONTRARECIBOACTUALID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBODTL.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOFECHA", FbDbType.Date);
                if (!(bool)oCCONTRARECIBODTL.isnull["IFECHA"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOFECHAVENCE", FbDbType.Date);
                if (!(bool)oCCONTRARECIBODTL.isnull["IFECHAVENCE"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IFECHAVENCE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOFOLIO", FbDbType.Integer);
                if (!(bool)oCCONTRARECIBODTL.isnull["IFOLIO"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOSERIE", FbDbType.VarChar);
                if (!(bool)oCCONTRARECIBODTL.isnull["ISERIE"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.ISERIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOFOLIOSAT", FbDbType.Integer);
                if (!(bool)oCCONTRARECIBODTL.isnull["IFOLIOSAT"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IFOLIOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOSERIESAT", FbDbType.VarChar);
                if (!(bool)oCCONTRARECIBODTL.isnull["ISERIESAT"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.ISERIESAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DOCTOTOTAL", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTL.isnull["ITOTALDOCTO"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.ITOTALDOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOABONO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTL.isnull["IABONODOCTO"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IABONODOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOSALDO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTL.isnull["ISALDODOCTO"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.ISALDODOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DETALLETOTAL", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTL.isnull["ITOTAL"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DETALLEABONO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTL.isnull["IABONO"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.IABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DETALLESALDO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBODTL.isnull["ISALDO"])
                {
                    auxPar.Value = oCCONTRARECIBODTL.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ESTATUSPAGOID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IESTATUSPAGOID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IESTATUSPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CONTRARECIBOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CONTRARECIBODTLID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"CONTRARECIBODETAIL_INSERT";

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
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        CONTRARECIBODTLID = (long)arParms[arParms.Length - 2].Value;
                    }
                }


                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 3].Value != 0)
                    {
                        CONTRARECIBOID = (long)arParms[arParms.Length - 3].Value;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool CONTRARECIBODETAIL_DELETE(CCONTRARECIBODTLBE oCCONTRARECIBODTL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@CONTRARECIBODTLID", FbDbType.BigInt);
                auxPar.Value = oCCONTRARECIBODTL.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"CONTRARECIBODETAIL_DELETE";

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
                        this.iComentario = "Hubo un error";
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }









        public CCONTRARECIBODTLD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
