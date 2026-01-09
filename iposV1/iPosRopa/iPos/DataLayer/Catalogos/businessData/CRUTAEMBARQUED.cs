
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


    public class CRUTAEMBARQUED
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


        public CRUTAEMBARQUEBE AgregarRUTAEMBARQUED(CRUTAEMBARQUEBE oCRUTAEMBARQUE, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCRUTAEMBARQUE.isnull["IACTIVO"])
                {
                    auxPar.Value = oCRUTAEMBARQUE.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCRUTAEMBARQUE.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCRUTAEMBARQUE.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCRUTAEMBARQUE.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCRUTAEMBARQUE.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCRUTAEMBARQUE.isnull["ICLAVE"])
                {
                    auxPar.Value = oCRUTAEMBARQUE.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCRUTAEMBARQUE.isnull["INOMBRE"])
                {
                    auxPar.Value = oCRUTAEMBARQUE.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO RUTAEMBARQUE
      (

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE,

NOMBRE
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@NOMBRE
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCRUTAEMBARQUE;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarRUTAEMBARQUED(CRUTAEMBARQUEBE oCRUTAEMBARQUE, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCRUTAEMBARQUE.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from RUTAEMBARQUE
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
        public bool CambiarRUTAEMBARQUED(CRUTAEMBARQUEBE oCRUTAEMBARQUENuevo, CRUTAEMBARQUEBE oCRUTAEMBARQUEAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCRUTAEMBARQUENuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCRUTAEMBARQUENuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCRUTAEMBARQUENuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCRUTAEMBARQUENuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCRUTAEMBARQUENuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCRUTAEMBARQUENuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCRUTAEMBARQUENuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCRUTAEMBARQUENuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCRUTAEMBARQUEAnterior.isnull["IID"])
                {
                    auxPar.Value = oCRUTAEMBARQUEAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  RUTAEMBARQUE
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE
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


        public CRUTAEMBARQUEBE seleccionarRUTAEMBARQUE(CRUTAEMBARQUEBE oCRUTAEMBARQUE, FbTransaction st)
        {




            CRUTAEMBARQUEBE retorno = new CRUTAEMBARQUEBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from RUTAEMBARQUE where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCRUTAEMBARQUE.IID;
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

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
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
        public DataSet enlistarRUTAEMBARQUE()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_RUTAEMBARQUE_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoRUTAEMBARQUE()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_RUTAEMBARQUE_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteRUTAEMBARQUE(CRUTAEMBARQUEBE oCRUTAEMBARQUE, FbTransaction st)
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
                auxPar.Value = oCRUTAEMBARQUE.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from RUTAEMBARQUE where

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




        public CRUTAEMBARQUEBE AgregarRUTAEMBARQUE(CRUTAEMBARQUEBE oCRUTAEMBARQUE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteRUTAEMBARQUE(oCRUTAEMBARQUE, st);
                if (iRes == 1)
                {
                    this.IComentario = "El RUTAEMBARQUE ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarRUTAEMBARQUED(oCRUTAEMBARQUE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarRUTAEMBARQUE(CRUTAEMBARQUEBE oCRUTAEMBARQUE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteRUTAEMBARQUE(oCRUTAEMBARQUE, st);
                if (iRes == 0)
                {
                    this.IComentario = "El RUTAEMBARQUE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarRUTAEMBARQUED(oCRUTAEMBARQUE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarRUTAEMBARQUE(CRUTAEMBARQUEBE oCRUTAEMBARQUENuevo, CRUTAEMBARQUEBE oCRUTAEMBARQUEAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteRUTAEMBARQUE(oCRUTAEMBARQUEAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El RUTAEMBARQUE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarRUTAEMBARQUED(oCRUTAEMBARQUENuevo, oCRUTAEMBARQUEAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public CRUTAEMBARQUEBE seleccionarRUTAEMBARQUExCLAVE(CRUTAEMBARQUEBE oCRUTASEMBARQUE, FbTransaction st)
        {




            CRUTAEMBARQUEBE retorno = new CRUTAEMBARQUEBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from RUTAEMBARQUE where
 CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCRUTASEMBARQUE.ICLAVE;
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

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
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


        public CRUTAEMBARQUED()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }

        public List<CRUTAEMBARQUEBE> seleccionarRUTASDEEMBARQUE()
        {




            List<CRUTAEMBARQUEBE> retorno = new List<CRUTAEMBARQUEBE>();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from RUTAEMBARQUE";


                /*auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCRUTAEMBARQUE.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);*/



                dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt);

                while(dr.Read())
                {
                    CRUTAEMBARQUEBE crutasbe = new CRUTAEMBARQUEBE();

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        crutasbe.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        crutasbe.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        crutasbe.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        crutasbe.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        crutasbe.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        crutasbe.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        crutasbe.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        crutasbe.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    retorno.Add(crutasbe);

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
    }
}
