

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




    public class CLOTESIMPORTADOSD
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

        public CLOTESIMPORTADOSBE AgregarLOTESIMPORTADOSD(CLOTESIMPORTADOSBE oCLOTESIMPORTADOS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCLOTESIMPORTADOS.isnull["IACTIVO"])
                {
                    auxPar.Value = oCLOTESIMPORTADOS.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLOTESIMPORTADOS.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCLOTESIMPORTADOS.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLOTESIMPORTADOS.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCLOTESIMPORTADOS.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PEDIMENTO", FbDbType.VarChar);
                if (!(bool)oCLOTESIMPORTADOS.isnull["IPEDIMENTO"])
                {
                    auxPar.Value = oCLOTESIMPORTADOS.IPEDIMENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAIMPORTACION", FbDbType.Date);
                if (!(bool)oCLOTESIMPORTADOS.isnull["IFECHAIMPORTACION"])
                {
                    auxPar.Value = oCLOTESIMPORTADOS.IFECHAIMPORTACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ADUANA", FbDbType.VarChar);
                if (!(bool)oCLOTESIMPORTADOS.isnull["IADUANA"])
                {
                    auxPar.Value = oCLOTESIMPORTADOS.IADUANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOCAMBIO", FbDbType.Numeric);
                if (!(bool)oCLOTESIMPORTADOS.isnull["ITIPOCAMBIO"])
                {
                    auxPar.Value = oCLOTESIMPORTADOS.ITIPOCAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SATADUANAID", FbDbType.BigInt);
                if(!(bool)oCLOTESIMPORTADOS.isnull["ISATADUANAID"])
                {
                    auxPar.Value = oCLOTESIMPORTADOS.ISATADUANAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO LOTESIMPORTADOS
      (
   

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

PEDIMENTO,

FECHAIMPORTACION,

ADUANA,

TIPOCAMBIO,

SATADUANAID
         )

Values (


@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@PEDIMENTO,

@FECHAIMPORTACION,

@ADUANA,

@TIPOCAMBIO,

@SATADUANAID
)
RETURNING ID; ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                Object result = null;

                if (st == null)
                    result = SqlHelper.ExecuteScalar(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    result = SqlHelper.ExecuteScalar(st, CommandType.Text, commandText, arParms);

                oCLOTESIMPORTADOS.IID = (long)result;



                return oCLOTESIMPORTADOS;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarLOTESIMPORTADOSD(CLOTESIMPORTADOSBE oCLOTESIMPORTADOS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCLOTESIMPORTADOS.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from LOTESIMPORTADOS
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

        public bool CambiarLOTESIMPORTADOSD(CLOTESIMPORTADOSBE oCLOTESIMPORTADOSNuevo, CLOTESIMPORTADOSBE oCLOTESIMPORTADOSAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCLOTESIMPORTADOSNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCLOTESIMPORTADOSNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLOTESIMPORTADOSNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCLOTESIMPORTADOSNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PEDIMENTO", FbDbType.VarChar);
                if (!(bool)oCLOTESIMPORTADOSNuevo.isnull["IPEDIMENTO"])
                {
                    auxPar.Value = oCLOTESIMPORTADOSNuevo.IPEDIMENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAIMPORTACION", FbDbType.Date);
                if (!(bool)oCLOTESIMPORTADOSNuevo.isnull["IFECHAIMPORTACION"])
                {
                    auxPar.Value = oCLOTESIMPORTADOSNuevo.IFECHAIMPORTACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ADUANA", FbDbType.VarChar);
                if (!(bool)oCLOTESIMPORTADOSNuevo.isnull["IADUANA"])
                {
                    auxPar.Value = oCLOTESIMPORTADOSNuevo.IADUANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOCAMBIO", FbDbType.Numeric);
                if (!(bool)oCLOTESIMPORTADOSNuevo.isnull["ITIPOCAMBIO"])
                {
                    auxPar.Value = oCLOTESIMPORTADOSNuevo.ITIPOCAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SATADUANAID", FbDbType.BigInt);
                if (!(bool)oCLOTESIMPORTADOSNuevo.isnull["ISATADUANAID"])
                {
                    auxPar.Value = oCLOTESIMPORTADOSNuevo.ISATADUANAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCLOTESIMPORTADOSAnterior.isnull["IID"])
                {
                    auxPar.Value = oCLOTESIMPORTADOSAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  LOTESIMPORTADOS
  set


ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

PEDIMENTO=@PEDIMENTO,

FECHAIMPORTACION=@FECHAIMPORTACION,

ADUANA=@ADUANA,

TIPOCAMBIO=@TIPOCAMBIO,

SATADUANAID = @SATADUANAID
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


        public CLOTESIMPORTADOSBE seleccionarLOTESIMPORTADOS(CLOTESIMPORTADOSBE oCLOTESIMPORTADOS, FbTransaction st)
        {

            CLOTESIMPORTADOSBE retorno = new CLOTESIMPORTADOSBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from LOTESIMPORTADOS where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCLOTESIMPORTADOS.IID;
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

                    if (dr["PEDIMENTO"] != System.DBNull.Value)
                    {
                        retorno.IPEDIMENTO = (string)(dr["PEDIMENTO"]);
                    }

                    if (dr["FECHAIMPORTACION"] != System.DBNull.Value)
                    {
                        retorno.IFECHAIMPORTACION = (DateTime)(dr["FECHAIMPORTACION"]);
                    }

                    if (dr["ADUANA"] != System.DBNull.Value)
                    {
                        retorno.IADUANA = (string)(dr["ADUANA"]);
                    }

                    if (dr["TIPOCAMBIO"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCAMBIO = (decimal)(dr["TIPOCAMBIO"]);
                    }

                    if(dr["SATADUANAID"] != System.DBNull.Value)
                    {
                        retorno.ISATADUANAID = (long)(dr["SATADUANAID"]);
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





        public CLOTESIMPORTADOSBE seleccionarLOTESIMPORTADOSXDATOS(CLOTESIMPORTADOSBE oCLOTESIMPORTADOS, FbTransaction st)
        {

            CLOTESIMPORTADOSBE retorno = new CLOTESIMPORTADOSBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from LOTESIMPORTADOS 
                                  where PEDIMENTO = @PEDIMENTO AND FECHAIMPORTACION = @FECHAIMPORTACION AND 
                                  (COALESCE(SATADUANAID,-1) = COALESCE(@SATADUANAID,0) OR (COALESCE(SATADUANAID,-1) = -1 AND 
                                  COALESCE(ADUANA,'') = COALESCE(@ADUANA,''))) AND 
                                  TIPOCAMBIO = @TIPOCAMBIO";

                auxPar = new FbParameter("@PEDIMENTO", FbDbType.VarChar);
                if (!(bool)oCLOTESIMPORTADOS.isnull["IPEDIMENTO"])
                {
                    auxPar.Value = oCLOTESIMPORTADOS.IPEDIMENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAIMPORTACION", FbDbType.Date);
                if (!(bool)oCLOTESIMPORTADOS.isnull["IFECHAIMPORTACION"])
                {
                    auxPar.Value = oCLOTESIMPORTADOS.IFECHAIMPORTACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ADUANA", FbDbType.VarChar);
                if (!(bool)oCLOTESIMPORTADOS.isnull["IADUANA"])
                {
                    auxPar.Value = oCLOTESIMPORTADOS.IADUANA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOCAMBIO", FbDbType.Numeric);
                if (!(bool)oCLOTESIMPORTADOS.isnull["ITIPOCAMBIO"])
                {
                    auxPar.Value = oCLOTESIMPORTADOS.ITIPOCAMBIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SATADUANAID", FbDbType.BigInt);
                if(!(bool)oCLOTESIMPORTADOS.isnull["ISATADUANAID"])
                {
                    auxPar.Value = oCLOTESIMPORTADOS.ISATADUANAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }

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

                    if (dr["PEDIMENTO"] != System.DBNull.Value)
                    {
                        retorno.IPEDIMENTO = (string)(dr["PEDIMENTO"]);
                    }

                    if (dr["FECHAIMPORTACION"] != System.DBNull.Value)
                    {
                        retorno.IFECHAIMPORTACION = (DateTime)(dr["FECHAIMPORTACION"]);
                    }

                    if (dr["ADUANA"] != System.DBNull.Value)
                    {
                        retorno.IADUANA = (string)(dr["ADUANA"]);
                    }

                    if (dr["TIPOCAMBIO"] != System.DBNull.Value)
                    {
                        retorno.ITIPOCAMBIO = (decimal)(dr["TIPOCAMBIO"]);
                    }

                    if(dr["SATADUANAID"] != System.DBNull.Value)
                    {
                        retorno.ISATADUANAID = (long)(dr["SATADUANAID"]);
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




        public DataSet enlistarLOTESIMPORTADOS()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_LOTESIMPORTADOS_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public DataSet enlistarCortoLOTESIMPORTADOS()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_LOTESIMPORTADOS_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteLOTESIMPORTADOS(CLOTESIMPORTADOSBE oCLOTESIMPORTADOS, FbTransaction st)
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
                auxPar.Value = oCLOTESIMPORTADOS.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from LOTESIMPORTADOS where

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




        public CLOTESIMPORTADOSBE AgregarLOTESIMPORTADOS(CLOTESIMPORTADOSBE oCLOTESIMPORTADOS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLOTESIMPORTADOS(oCLOTESIMPORTADOS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El LOTESIMPORTADOS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarLOTESIMPORTADOSD(oCLOTESIMPORTADOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarLOTESIMPORTADOS(CLOTESIMPORTADOSBE oCLOTESIMPORTADOS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLOTESIMPORTADOS(oCLOTESIMPORTADOS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El LOTESIMPORTADOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarLOTESIMPORTADOSD(oCLOTESIMPORTADOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarLOTESIMPORTADOS(CLOTESIMPORTADOSBE oCLOTESIMPORTADOSNuevo, CLOTESIMPORTADOSBE oCLOTESIMPORTADOSAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLOTESIMPORTADOS(oCLOTESIMPORTADOSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El LOTESIMPORTADOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarLOTESIMPORTADOSD(oCLOTESIMPORTADOSNuevo, oCLOTESIMPORTADOSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }

        public bool CambiarSATADUANAID(long satAduanaId, string aduana, FbTransaction st)
        {
           try
           {
               System.Collections.ArrayList parts = new ArrayList();
               FbParameter auxPar;

               auxPar = new FbParameter("@ADUANA", FbDbType.Char);
               if (!String.IsNullOrEmpty(aduana))
               {
                   auxPar.Value = aduana;
               }
               else
               {
                   auxPar.Value = System.DBNull.Value;
               }
               parts.Add(auxPar);


               auxPar = new FbParameter("@SATADUANAID", FbDbType.BigInt);
               if (satAduanaId != null)
               {
                   auxPar.Value = satAduanaId;
               }
               else
               {
                   auxPar.Value = System.DBNull.Value;
               }
               parts.Add(auxPar);

               string commandText = @"UPDATE LOTESIMPORTADOS SET SATADUANAID = @SATADUANAID WHERE ADUANA=@ADUANA;";

               FbParameter[] arParms = new FbParameter[parts.Count];
               parts.CopyTo(arParms, 0);


               if (st == null)
                   SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
               else
                   SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);

               return true;
           }
           catch(Exception ex)
           {
               this.IComentario = ex.Message;

               return false;
           }
        }

        public CLOTESIMPORTADOSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
