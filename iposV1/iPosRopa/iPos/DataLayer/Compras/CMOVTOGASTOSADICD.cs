

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



    public class CMOVTOGASTOSADICD
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


        public CMOVTOGASTOSADICBE AgregarMOVTOGASTOSADICD(CMOVTOGASTOSADICBE oCMOVTOGASTOSADIC, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMOVTOGASTOSADIC.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMOVTOGASTOSADIC.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOVTOGASTOSADIC.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMOVTOGASTOSADIC.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOVTOGASTOSADIC.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMOVTOGASTOSADIC.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCMOVTOGASTOSADIC.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCMOVTOGASTOSADIC.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVTOGASTOSADICID", FbDbType.BigInt);
                if (!(bool)oCMOVTOGASTOSADIC.isnull["IMOVTOGASTOSADICID"])
                {
                    auxPar.Value = oCMOVTOGASTOSADIC.IMOVTOGASTOSADICID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO", FbDbType.Numeric);
                if (!(bool)oCMOVTOGASTOSADIC.isnull["IMONTO"])
                {
                    auxPar.Value = oCMOVTOGASTOSADIC.IMONTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PARTIDA", FbDbType.Integer);
                if (!(bool)oCMOVTOGASTOSADIC.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCMOVTOGASTOSADIC.IPARTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MOVTOGASTOSADIC
      (
    

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

DOCTOID,

MOVTOGASTOSADICID,

MONTO,

PARTIDA

         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@DOCTOID,

@MOVTOGASTOSADICID,

@MONTO,

@PARTIDA
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMOVTOGASTOSADIC;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarMOVTOGASTOSADICD(CMOVTOGASTOSADICBE oCMOVTOGASTOSADIC, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOVTOGASTOSADIC.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MOVTOGASTOSADIC
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
        public bool CambiarMOVTOGASTOSADICD(CMOVTOGASTOSADICBE oCMOVTOGASTOSADICNuevo, CMOVTOGASTOSADICBE oCMOVTOGASTOSADICAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMOVTOGASTOSADICNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMOVTOGASTOSADICNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMOVTOGASTOSADICNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMOVTOGASTOSADICNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCMOVTOGASTOSADICNuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCMOVTOGASTOSADICNuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MOVTOGASTOSADICID", FbDbType.BigInt);
                if (!(bool)oCMOVTOGASTOSADICNuevo.isnull["IMOVTOGASTOSADICID"])
                {
                    auxPar.Value = oCMOVTOGASTOSADICNuevo.IMOVTOGASTOSADICID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO", FbDbType.Numeric);
                if (!(bool)oCMOVTOGASTOSADICNuevo.isnull["IMONTO"])
                {
                    auxPar.Value = oCMOVTOGASTOSADICNuevo.IMONTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PARTIDA", FbDbType.Integer);
                if (!(bool)oCMOVTOGASTOSADICNuevo.isnull["IPARTIDA"])
                {
                    auxPar.Value = oCMOVTOGASTOSADICNuevo.IPARTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMOVTOGASTOSADICAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMOVTOGASTOSADICAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MOVTOGASTOSADIC
  set

ACTIVO=@ACTIVO,


MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

DOCTOID=@DOCTOID,

MOVTOGASTOSADICID=@MOVTOGASTOSADICID,

MONTO=@MONTO,

PARTIDA = @PARTIDA
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
        public CMOVTOGASTOSADICBE seleccionarMOVTOGASTOSADIC(CMOVTOGASTOSADICBE oCMOVTOGASTOSADIC, FbTransaction st)
        {




            CMOVTOGASTOSADICBE retorno = new CMOVTOGASTOSADICBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MOVTOGASTOSADIC where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMOVTOGASTOSADIC.IID;
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

                    if (dr["MOVTOGASTOSADICID"] != System.DBNull.Value)
                    {
                        retorno.IMOVTOGASTOSADICID = (long)(dr["MOVTOGASTOSADICID"]);
                    }

                    if (dr["MONTO"] != System.DBNull.Value)
                    {
                        retorno.IMONTO = (decimal)(dr["MONTO"]);
                    }

                    if (dr["PARTIDA"] != System.DBNull.Value)
                    {
                        retorno.IPARTIDA = (int)(dr["PARTIDA"]);
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





        public int cuentaGastosXDoctoID(long doctoId, FbTransaction st)
        {




            int retorno = 0;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select count(*) CUENTA from MOVTOGASTOSADIC where DOCTOID = @DOCTOID  ";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["CUENTA"] != System.DBNull.Value)
                    {
                        retorno = (int)(dr["CUENTA"]);
                    }
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






        [AutoComplete]
        public DataSet enlistarMOVTOGASTOSADIC()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MOVTOGASTOSADIC_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoMOVTOGASTOSADIC()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MOVTOGASTOSADIC_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteMOVTOGASTOSADIC(CMOVTOGASTOSADICBE oCMOVTOGASTOSADIC, FbTransaction st)
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
                auxPar.Value = oCMOVTOGASTOSADIC.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MOVTOGASTOSADIC where

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




        public CMOVTOGASTOSADICBE AgregarMOVTOGASTOSADIC(CMOVTOGASTOSADICBE oCMOVTOGASTOSADIC, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMOVTOGASTOSADIC(oCMOVTOGASTOSADIC, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MOVTOGASTOSADIC ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMOVTOGASTOSADICD(oCMOVTOGASTOSADIC, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMOVTOGASTOSADIC(CMOVTOGASTOSADICBE oCMOVTOGASTOSADIC, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMOVTOGASTOSADIC(oCMOVTOGASTOSADIC, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MOVTOGASTOSADIC no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMOVTOGASTOSADICD(oCMOVTOGASTOSADIC, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMOVTOGASTOSADIC(CMOVTOGASTOSADICBE oCMOVTOGASTOSADICNuevo, CMOVTOGASTOSADICBE oCMOVTOGASTOSADICAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMOVTOGASTOSADIC(oCMOVTOGASTOSADICAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MOVTOGASTOSADIC no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMOVTOGASTOSADICD(oCMOVTOGASTOSADICNuevo, oCMOVTOGASTOSADICAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public bool EjecutarAddMOVTO(long? DOCTOID,
                                     int? PARTIDAID,
                                     long? MOVTOGASTOSADICID,
                                     decimal? MONTO,
                                     ref long? MOVTOID,
                                      FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (DOCTOID.HasValue)
                {
                    auxPar.Value = (long)DOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@PARTIDAID", FbDbType.Integer);
                if (PARTIDAID.HasValue)
                {
                    auxPar.Value = (long)PARTIDAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MOVTOGASTOSADICID", FbDbType.BigInt);
                if (MOVTOGASTOSADICID.HasValue)
                {
                    auxPar.Value = (long)MOVTOGASTOSADICID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO", FbDbType.Numeric);
                if (MONTO.HasValue)
                {
                    auxPar.Value = (decimal)MONTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);





                string commandText = @"MOVTOGASTOADIC_INSERT";
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
                        string strMensajeErr = "";
                        long longMensajeErr = (long)((int)arParms[arParms.Length - 1].Value);
                        strMensajeErr = CERRORCODED.ObtenerMensajeError(longMensajeErr, this.sCadenaConexion, st);

                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                MOVTOID = (long)arParms[arParms.Length - 2].Value;
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool GASTOSADIC_CANCEL(long doctoCancelarId,  FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOCANCELARID", FbDbType.BigInt);
                auxPar.Value = doctoCancelarId;
                parts.Add(auxPar);




                //auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                //auxPar.Direction = ParameterDirection.Output;
                //parts.Add(auxPar);

                string commandText = @"DELETE FROM MOVTOGASTOSADIC WHERE DOCTOID = :DOCTOCANCELARID ";

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


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public CMOVTOGASTOSADICBE[] seleccionarMOVTOGASTOSADIC(long doctoId,  FbTransaction st)
        {

            CMOVTOGASTOSADICBE retorno;

            System.Collections.ArrayList buffDetails = new ArrayList();
            //CTICKET_DETAILBE bufferTicketDet;


            FbDataReader dr = null;
            FbConnection pcn = null;


            try
            {



                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IID = doctoId;

                doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);


                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select MOVTOGASTOSADIC.*, GASTOADICIONAL.NOMBRE NOMBREGASTO  from MOVTOGASTOSADIC LEFT JOIN GASTOADICIONAL ON GASTOADICIONAL.ID = MOVTOGASTOSADIC.movtogastosadicid  where DOCTOID=@DOCTOID ";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);





                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    retorno = new CMOVTOGASTOSADICBE();


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

                    if (dr["MOVTOGASTOSADICID"] != System.DBNull.Value)
                    {
                        retorno.IMOVTOGASTOSADICID = (long)(dr["MOVTOGASTOSADICID"]);
                    }

                    if (dr["MONTO"] != System.DBNull.Value)
                    {
                        retorno.IMONTO = (decimal)(dr["MONTO"]);
                    }

                    if (dr["PARTIDA"] != System.DBNull.Value)
                    {
                        retorno.IPARTIDA = (int)(dr["PARTIDA"]);
                    }

                    if (dr["NOMBREGASTO"] != System.DBNull.Value)
                    {
                        retorno.INOMBREGASTO = (string)(dr["NOMBREGASTO"]);
                    }

                    buffDetails.Add(retorno);

                }

                CMOVTOGASTOSADICBE[] detailList = new CMOVTOGASTOSADICBE[buffDetails.Count];
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





        public CMOVTOGASTOSADICD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
