

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



    public class CHILOSISTEMAD
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


        public CHILOSISTEMABE AgregarHILOSISTEMAD(CHILOSISTEMABE oCHILOSISTEMA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCHILOSISTEMA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCHILOSISTEMA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCHILOSISTEMA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCHILOSISTEMA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCHILOSISTEMA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCHILOSISTEMA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCHILOSISTEMA.isnull["ICLAVE"])
                {
                    auxPar.Value = oCHILOSISTEMA.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RANDOM", FbDbType.VarChar);
                if (!(bool)oCHILOSISTEMA.isnull["IRANDOM"])
                {
                    auxPar.Value = oCHILOSISTEMA.IRANDOM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                


                string commandText = @"
        INSERT INTO HILOSISTEMA
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE,

RANDOM
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@RANDOM
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCHILOSISTEMA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarHILOSISTEMAD(CHILOSISTEMABE oCHILOSISTEMA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCHILOSISTEMA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from HILOSISTEMA
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


        public bool CambiarHILOSISTEMAD(CHILOSISTEMABE oCHILOSISTEMANuevo, CHILOSISTEMABE oCHILOSISTEMAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCHILOSISTEMANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCHILOSISTEMANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCHILOSISTEMANuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCHILOSISTEMANuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCHILOSISTEMANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCHILOSISTEMANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCHILOSISTEMANuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCHILOSISTEMANuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RANDOM", FbDbType.VarChar);
                if (!(bool)oCHILOSISTEMANuevo.isnull["IRANDOM"])
                {
                    auxPar.Value = oCHILOSISTEMANuevo.IRANDOM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCHILOSISTEMAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCHILOSISTEMAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  HILOSISTEMA
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

RANDOM=@RANDOM
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


        public CHILOSISTEMABE seleccionarHILOSISTEMA(CHILOSISTEMABE oCHILOSISTEMA, FbTransaction st)
        {




            CHILOSISTEMABE retorno = new CHILOSISTEMABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from HILOSISTEMA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCHILOSISTEMA.IID;
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
                        retorno.IMODIFICADO = (DateTime)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["RANDOM"] != System.DBNull.Value)
                    {
                        retorno.IRANDOM = (string)(dr["RANDOM"]);
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




        public CHILOSISTEMABE seleccionarHILOSISTEMA_X_CLAVE(CHILOSISTEMABE oCHILOSISTEMA, FbTransaction st)
        {




            CHILOSISTEMABE retorno = new CHILOSISTEMABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from HILOSISTEMA where CLAVE = @CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCHILOSISTEMA.ICLAVE;
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
                        retorno.IMODIFICADO = (DateTime)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["RANDOM"] != System.DBNull.Value)
                    {
                        retorno.IRANDOM = (string)(dr["RANDOM"]);
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








        public DataSet enlistarHILOSISTEMA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_HILOSISTEMA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoHILOSISTEMA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_HILOSISTEMA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteHILOSISTEMA(CHILOSISTEMABE oCHILOSISTEMA, FbTransaction st)
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
                auxPar.Value = oCHILOSISTEMA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from HILOSISTEMA where

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




        public CHILOSISTEMABE AgregarHILOSISTEMA(CHILOSISTEMABE oCHILOSISTEMA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteHILOSISTEMA(oCHILOSISTEMA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El HILOSISTEMA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarHILOSISTEMAD(oCHILOSISTEMA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarHILOSISTEMA(CHILOSISTEMABE oCHILOSISTEMA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteHILOSISTEMA(oCHILOSISTEMA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El HILOSISTEMA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarHILOSISTEMAD(oCHILOSISTEMA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarHILOSISTEMA(CHILOSISTEMABE oCHILOSISTEMANuevo, CHILOSISTEMABE oCHILOSISTEMAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteHILOSISTEMA(oCHILOSISTEMAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El HILOSISTEMA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarHILOSISTEMAD(oCHILOSISTEMANuevo, oCHILOSISTEMAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }

        public DateTime? selectCurrentTimeStamp(FbTransaction st)
        {
            
            FbDataReader dr = null;

            FbConnection pcn = null;

            DateTime? retorno = null; 

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select current_timestamp TIEMPO from rdb$database  ";

                




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {
                    

                    if (dr["TIEMPO"] != System.DBNull.Value)
                    {
                        retorno = (DateTime)(dr["TIEMPO"]);
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


        public bool ApartarHiloSistema(CHILOSISTEMABE hilo, FbTransaction st)
        {
            CHILOSISTEMABE saved = this.seleccionarHILOSISTEMA_X_CLAVE(hilo, st);

            DateTime? tiempoDB = this.selectCurrentTimeStamp(st);

            if (tiempoDB == null)
                return false;

            if(saved == null)
            {
                CHILOSISTEMABE inserted = this.AgregarHILOSISTEMAD(hilo, st);
                if (inserted != null)
                    return true;
            }

            if(saved != null)
            {
                if(  saved.IRANDOM == null || saved.IRANDOM.Trim().Length == 0 || saved.IRANDOM.Equals(hilo.IRANDOM) ||  tiempoDB.Value.AddMinutes(-10) > saved.IMODIFICADO )
                {
                    saved.IRANDOM = hilo.IRANDOM;
                    bool bRes = this.CambiarHILOSISTEMAD(saved, saved, st);
                    return bRes;
                }
                else
                {
                    return false;
                }
            }

            return false;

        }



        public bool DesApartarHiloSistema(CHILOSISTEMABE hilo, FbTransaction st)
        {
            CHILOSISTEMABE saved = this.seleccionarHILOSISTEMA_X_CLAVE(hilo, st);

            DateTime? tiempoDB = this.selectCurrentTimeStamp(st);

            if (tiempoDB == null)
                return false;
            

            if (saved != null)
            {
                if ((saved.IRANDOM != null && saved.IRANDOM.Equals(hilo.IRANDOM)) )
                {
                    saved.IRANDOM = "";
                    bool bRes = this.CambiarHILOSISTEMAD(saved, saved, st);
                    return bRes;
                }
                else
                {
                    return false;
                }
            }

            return false;

        }

        public CHILOSISTEMAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
