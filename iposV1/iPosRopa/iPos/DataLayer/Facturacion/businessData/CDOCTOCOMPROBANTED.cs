

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


    public class CDOCTOCOMPROBANTED
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
        public CDOCTOCOMPROBANTEBE AgregarDOCTOCOMPROBANTED(CDOCTOCOMPROBANTEBE oCDOCTOCOMPROBANTE, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCDOCTOCOMPROBANTE.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTE.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCDOCTOCOMPROBANTE.isnull["IACTIVO"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTE.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOCTOCOMPROBANTE.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTE.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOCTOCOMPROBANTE.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTE.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOCOMPROBANTE.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTE.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOCOMPROBANTE", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTE.isnull["ITIPOCOMPROBANTE"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTE.ITIPOCOMPROBANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIMBRADOUUID", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTE.isnull["ITIMBRADOUUID"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTE.ITIMBRADOUUID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIMBRADOFECHA", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTE.isnull["ITIMBRADOFECHA"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTE.ITIMBRADOFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIMBRADOCERTSAT", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTE.isnull["ITIMBRADOCERTSAT"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTE.ITIMBRADOCERTSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIMBRADOSELLOSAT", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTE.isnull["ITIMBRADOSELLOSAT"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTE.ITIMBRADOSELLOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIMBRADOSELLOCFDI", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTE.isnull["ITIMBRADOSELLOCFDI"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTE.ITIMBRADOSELLOCFDI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FOLIOSAT", FbDbType.Integer);
                if (!(bool)oCDOCTOCOMPROBANTE.isnull["IFOLIOSAT"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTE.IFOLIOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SERIESAT", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTE.isnull["ISERIESAT"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTE.ISERIESAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO DOCTOCOMPROBANTE
      (

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

DOCTOID,

TIPOCOMPROBANTE,

TIMBRADOUUID,

TIMBRADOFECHA,

TIMBRADOCERTSAT,

TIMBRADOSELLOSAT,

TIMBRADOSELLOCFDI,

FOLIOSAT,

SERIESAT
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@DOCTOID,

@TIPOCOMPROBANTE,

@TIMBRADOUUID,

@TIMBRADOFECHA,

@TIMBRADOCERTSAT,

@TIMBRADOSELLOSAT,

@TIMBRADOSELLOCFDI,

@FOLIOSAT,

@SERIESAT
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCDOCTOCOMPROBANTE;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarDOCTOCOMPROBANTED(CDOCTOCOMPROBANTEBE oCDOCTOCOMPROBANTE, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOCTOCOMPROBANTE.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from DOCTOCOMPROBANTE
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
        public bool CambiarDOCTOCOMPROBANTED(CDOCTOCOMPROBANTEBE oCDOCTOCOMPROBANTENuevo, CDOCTOCOMPROBANTEBE oCDOCTOCOMPROBANTEAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOCOMPROBANTE", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["ITIPOCOMPROBANTE"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.ITIPOCOMPROBANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIMBRADOUUID", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["ITIMBRADOUUID"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.ITIMBRADOUUID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIMBRADOFECHA", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["ITIMBRADOFECHA"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.ITIMBRADOFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIMBRADOCERTSAT", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["ITIMBRADOCERTSAT"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.ITIMBRADOCERTSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIMBRADOSELLOSAT", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["ITIMBRADOSELLOSAT"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.ITIMBRADOSELLOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIMBRADOSELLOCFDI", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["ITIMBRADOSELLOCFDI"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.ITIMBRADOSELLOCFDI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FOLIOSAT", FbDbType.Integer);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["IFOLIOSAT"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.IFOLIOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SERIESAT", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["ISERIESAT"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.ISERIESAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOCOMPROBANTEAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTEAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTOCOMPROBANTE
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

DOCTOID=@DOCTOID,

TIPOCOMPROBANTE=@TIPOCOMPROBANTE,

TIMBRADOUUID=@TIMBRADOUUID,

TIMBRADOFECHA=@TIMBRADOFECHA,

TIMBRADOCERTSAT=@TIMBRADOCERTSAT,

TIMBRADOSELLOSAT=@TIMBRADOSELLOSAT,

TIMBRADOSELLOCFDI=@TIMBRADOSELLOCFDI,

FOLIOSAT = @FOLIOSAT,

SERIESAT = @SERIESAT

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




        public bool CambiarxDOCTOyTIPOCOMPR(CDOCTOCOMPROBANTEBE oCDOCTOCOMPROBANTENuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIMBRADOUUID", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["ITIMBRADOUUID"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.ITIMBRADOUUID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIMBRADOFECHA", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["ITIMBRADOFECHA"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.ITIMBRADOFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIMBRADOCERTSAT", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["ITIMBRADOCERTSAT"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.ITIMBRADOCERTSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIMBRADOSELLOSAT", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["ITIMBRADOSELLOSAT"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.ITIMBRADOSELLOSAT;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIMBRADOSELLOCFDI", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["ITIMBRADOSELLOCFDI"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.ITIMBRADOSELLOCFDI;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOCOMPROBANTE", FbDbType.VarChar);
                if (!(bool)oCDOCTOCOMPROBANTENuevo.isnull["ITIPOCOMPROBANTE"])
                {
                    auxPar.Value = oCDOCTOCOMPROBANTENuevo.ITIPOCOMPROBANTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTOCOMPROBANTE
  set


MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

TIMBRADOUUID=@TIMBRADOUUID,

TIMBRADOFECHA=@TIMBRADOFECHA,

TIMBRADOCERTSAT=@TIMBRADOCERTSAT,

TIMBRADOSELLOSAT=@TIMBRADOSELLOSAT,

TIMBRADOSELLOCFDI=@TIMBRADOSELLOCFDI
  where 

DOCTOID=@DOCTOID AND

TIPOCOMPROBANTE=@TIPOCOMPROBANTE
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
        public CDOCTOCOMPROBANTEBE seleccionarDOCTOCOMPROBANTE(CDOCTOCOMPROBANTEBE oCDOCTOCOMPROBANTE, FbTransaction st)
        {




            CDOCTOCOMPROBANTEBE retorno = new CDOCTOCOMPROBANTEBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DOCTOCOMPROBANTE where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOCTOCOMPROBANTE.IID;
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

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["TIPOCOMPROBANTE"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCOMPROBANTE = (string)(dr["TIPOCOMPROBANTE"]);
                    }

                    if (dr["TIMBRADOUUID"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOUUID = (string)(dr["TIMBRADOUUID"]);
                    }

                    if (dr["TIMBRADOFECHA"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOFECHA = (string)(dr["TIMBRADOFECHA"]);
                    }

                    if (dr["TIMBRADOCERTSAT"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOCERTSAT = (string)(dr["TIMBRADOCERTSAT"]);
                    }

                    if (dr["TIMBRADOSELLOSAT"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOSELLOSAT = (string)(dr["TIMBRADOSELLOSAT"]);
                    }

                    if (dr["TIMBRADOSELLOCFDI"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOSELLOCFDI = (string)(dr["TIMBRADOSELLOCFDI"]);
                    }

                    if (dr["FOLIOSAT"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOSAT = int.Parse((string)(dr["FOLIOSAT"]));
                    }

                    if (dr["TIMBRADOSELLOCFDI"] != System.DBNull.Value)
                    {
                        retorno.ISERIESAT= (string)(dr["SERIESAT"]);
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





        public CDOCTOCOMPROBANTEBE seleccionarDOCTOCOMPROBANTExTIPOYDOCTO(CDOCTOCOMPROBANTEBE oCDOCTOCOMPROBANTE, FbTransaction st)
        {




            CDOCTOCOMPROBANTEBE retorno = new CDOCTOCOMPROBANTEBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DOCTOCOMPROBANTE where DOCTOID = @DOCTOID AND TIPOCOMPROBANTE = @TIPOCOMPROBANTE  ";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCDOCTOCOMPROBANTE.IDOCTOID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOCOMPROBANTE", FbDbType.VarChar);
                auxPar.Value = oCDOCTOCOMPROBANTE.ITIPOCOMPROBANTE;
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

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["TIPOCOMPROBANTE"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCOMPROBANTE = (string)(dr["TIPOCOMPROBANTE"]);
                    }

                    if (dr["TIMBRADOUUID"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOUUID = (string)(dr["TIMBRADOUUID"]);
                    }

                    if (dr["TIMBRADOFECHA"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOFECHA = (string)(dr["TIMBRADOFECHA"]);
                    }

                    if (dr["TIMBRADOCERTSAT"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOCERTSAT = (string)(dr["TIMBRADOCERTSAT"]);
                    }

                    if (dr["TIMBRADOSELLOSAT"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOSELLOSAT = (string)(dr["TIMBRADOSELLOSAT"]);
                    }

                    if (dr["TIMBRADOSELLOCFDI"] != System.DBNull.Value)
                    {
                        retorno.ITIMBRADOSELLOCFDI = (string)(dr["TIMBRADOSELLOCFDI"]);
                    }

                    if (dr["SERIESAT"] != System.DBNull.Value)
                    {
                        retorno.ISERIESAT = (string)(dr["SERIESAT"]);
                    }

                    if (dr["FOLIOSAT"] != System.DBNull.Value)
                    {
                        retorno.IFOLIOSAT = (int)(dr["FOLIOSAT"]);
                    }

                    if (dr["TIMBRADOSELLOCFDI"] != System.DBNull.Value)
                    {
                        retorno.ISERIESAT = (string)(dr["SERIESAT"]);
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
        public DataSet enlistarDOCTOCOMPROBANTE()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DOCTOCOMPROBANTE_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoDOCTOCOMPROBANTE()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DOCTOCOMPROBANTE_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteDOCTOCOMPROBANTE(CDOCTOCOMPROBANTEBE oCDOCTOCOMPROBANTE, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOCTOCOMPROBANTE.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from DOCTOCOMPROBANTE where

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




        public CDOCTOCOMPROBANTEBE AgregarDOCTOCOMPROBANTE(CDOCTOCOMPROBANTEBE oCDOCTOCOMPROBANTE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTOCOMPROBANTE(oCDOCTOCOMPROBANTE, st);
                if (iRes == 1)
                {
                    this.IComentario = "El DOCTOCOMPROBANTE ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarDOCTOCOMPROBANTED(oCDOCTOCOMPROBANTE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarDOCTOCOMPROBANTE(CDOCTOCOMPROBANTEBE oCDOCTOCOMPROBANTE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTOCOMPROBANTE(oCDOCTOCOMPROBANTE, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DOCTOCOMPROBANTE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarDOCTOCOMPROBANTED(oCDOCTOCOMPROBANTE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarDOCTOCOMPROBANTE(CDOCTOCOMPROBANTEBE oCDOCTOCOMPROBANTENuevo, CDOCTOCOMPROBANTEBE oCDOCTOCOMPROBANTEAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTOCOMPROBANTE(oCDOCTOCOMPROBANTEAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DOCTOCOMPROBANTE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarDOCTOCOMPROBANTED(oCDOCTOCOMPROBANTENuevo, oCDOCTOCOMPROBANTEAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CDOCTOCOMPROBANTED()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
