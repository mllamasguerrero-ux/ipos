

using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using DataLayer.Catalogos.businessEntity;
namespace iPosData
{


    public class CLLAMADOEMIDAD
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


        public CLLAMADOEMIDABE AgregarLLAMADOEMIDAD(CLLAMADOEMIDABE oCLLAMADOEMIDA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCLLAMADOEMIDA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLLAMADOEMIDA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLLAMADOEMIDA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OPERACION", FbDbType.VarChar);
                if (!(bool)oCLLAMADOEMIDA.isnull["IOPERACION"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.IOPERACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMIDAREQUESTID", FbDbType.BigInt);
                if (!(bool)oCLLAMADOEMIDA.isnull["IEMIDAREQUESTID"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.IEMIDAREQUESTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCLLAMADOEMIDA.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCLLAMADOEMIDA.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCLLAMADOEMIDA.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TERMINALID", FbDbType.BigInt);
                if (!(bool)oCLLAMADOEMIDA.isnull["ITERMINALID"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.ITERMINALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@INICIO", FbDbType.TimeStamp);
                if (!(bool)oCLLAMADOEMIDA.isnull["IINICIO"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.IINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FIN", FbDbType.TimeStamp);
                if (!(bool)oCLLAMADOEMIDA.isnull["IFIN"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.IFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DURACION", FbDbType.Integer);
                if (!(bool)oCLLAMADOEMIDA.isnull["IDURACION"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.IDURACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RESPONSECODE", FbDbType.VarChar);
                if (!(bool)oCLLAMADOEMIDA.isnull["IRESPONSECODE"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.IRESPONSECODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PIN", FbDbType.VarChar);
                if (!(bool)oCLLAMADOEMIDA.isnull["IPIN"])
                {
                    auxPar.Value = oCLLAMADOEMIDA.IPIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
        INSERT INTO LLAMADOEMIDA
      (
    

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

OPERACION,

EMIDAREQUESTID,

REFERENCIA,

SUCURSALID,

USUARIOID,

TERMINALID,

INICIO,

FIN,

DURACION,

RESPONSECODE,

PIN
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@OPERACION,

@EMIDAREQUESTID,

@REFERENCIA,

@SUCURSALID,

@USUARIOID,

@TERMINALID, 

@INICIO,

@FIN,

@DURACION,

@RESPONSECODE,

@PIN

); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCLLAMADOEMIDA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarLLAMADOEMIDAD(CLLAMADOEMIDABE oCLLAMADOEMIDA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCLLAMADOEMIDA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from LLAMADOEMIDA
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


        public bool CambiarLLAMADOEMIDAD(CLLAMADOEMIDABE oCLLAMADOEMIDANuevo, CLLAMADOEMIDABE oCLLAMADOEMIDAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCLLAMADOEMIDANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCLLAMADOEMIDANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLLAMADOEMIDANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCLLAMADOEMIDANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@OPERACION", FbDbType.VarChar);
                if (!(bool)oCLLAMADOEMIDANuevo.isnull["IOPERACION"])
                {
                    auxPar.Value = oCLLAMADOEMIDANuevo.IOPERACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMIDAREQUESTID", FbDbType.BigInt);
                if (!(bool)oCLLAMADOEMIDANuevo.isnull["IEMIDAREQUESTID"])
                {
                    auxPar.Value = oCLLAMADOEMIDANuevo.IEMIDAREQUESTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                if (!(bool)oCLLAMADOEMIDANuevo.isnull["IREFERENCIA"])
                {
                    auxPar.Value = oCLLAMADOEMIDANuevo.IREFERENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCLLAMADOEMIDANuevo.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCLLAMADOEMIDANuevo.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCLLAMADOEMIDANuevo.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCLLAMADOEMIDANuevo.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TERMINALID", FbDbType.BigInt);
                if (!(bool)oCLLAMADOEMIDANuevo.isnull["ITERMINALID"])
                {
                    auxPar.Value = oCLLAMADOEMIDANuevo.ITERMINALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCLLAMADOEMIDAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCLLAMADOEMIDAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  LLAMADOEMIDA
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

OPERACION=@OPERACION,

EMIDAREQUESTID=@EMIDAREQUESTID,

REFERENCIA=@REFERENCIA,

SUCURSALID=@SUCURSALID,

USUARIOID=@USUARIOID,

TERMINALID=@TERMINALID
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


        public CLLAMADOEMIDABE seleccionarLLAMADOEMIDA(CLLAMADOEMIDABE oCLLAMADOEMIDA, FbTransaction st)
        {




            CLLAMADOEMIDABE retorno = new CLLAMADOEMIDABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from LLAMADOEMIDA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCLLAMADOEMIDA.IID;
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

                    if (dr["OPERACION"] != System.DBNull.Value)
                    {
                        retorno.IOPERACION = (string)(dr["OPERACION"]);
                    }

                    if (dr["EMIDAREQUESTID"] != System.DBNull.Value)
                    {
                        retorno.IEMIDAREQUESTID = (long)(dr["EMIDAREQUESTID"]);
                    }

                    if (dr["REFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIA = (string)(dr["REFERENCIA"]);
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["USUARIOID"] != System.DBNull.Value)
                    {
                        retorno.IUSUARIOID = (long)(dr["USUARIOID"]);
                    }

                    if (dr["TERMINALID"] != System.DBNull.Value)
                    {
                        retorno.ITERMINALID = (long)(dr["TERMINALID"]);
                    }

                    if (dr["INICIO"] != System.DBNull.Value)
                    {
                        retorno.IINICIO = (DateTime)(dr["INICIO"]);
                    }

                    if (dr["FIN"] != System.DBNull.Value)
                    {
                        retorno.IFIN = (DateTime)(dr["FIN"]);
                    }

                    if (dr["DURACION"] != System.DBNull.Value)
                    {
                        retorno.IDURACION = (int)(dr["DURACION"]);
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









        public DataSet enlistarLLAMADOEMIDA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_LLAMADOEMIDA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoLLAMADOEMIDA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_LLAMADOEMIDA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteLLAMADOEMIDA(CLLAMADOEMIDABE oCLLAMADOEMIDA, FbTransaction st)
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
                auxPar.Value = oCLLAMADOEMIDA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from LLAMADOEMIDA where

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




        public CLLAMADOEMIDABE AgregarLLAMADOEMIDA(CLLAMADOEMIDABE oCLLAMADOEMIDA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLLAMADOEMIDA(oCLLAMADOEMIDA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El LLAMADOEMIDA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarLLAMADOEMIDAD(oCLLAMADOEMIDA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarLLAMADOEMIDA(CLLAMADOEMIDABE oCLLAMADOEMIDA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLLAMADOEMIDA(oCLLAMADOEMIDA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El LLAMADOEMIDA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarLLAMADOEMIDAD(oCLLAMADOEMIDA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarLLAMADOEMIDA(CLLAMADOEMIDABE oCLLAMADOEMIDANuevo, CLLAMADOEMIDABE oCLLAMADOEMIDAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLLAMADOEMIDA(oCLLAMADOEMIDAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El LLAMADOEMIDA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarLLAMADOEMIDAD(oCLLAMADOEMIDANuevo, oCLLAMADOEMIDAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CLLAMADOEMIDAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
