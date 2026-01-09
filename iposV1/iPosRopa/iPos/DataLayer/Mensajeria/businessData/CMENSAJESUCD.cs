

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

    


    public class CMENSAJESUCD
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


        
        public CMENSAJESUCBE AgregarMENSAJESUCD(CMENSAJESUCBE oCMENSAJESUC, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJESUC.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMENSAJESUC.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJESUC.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJESUC.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJESUC.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJESUC.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDMENSAJE", FbDbType.BigInt);
                if (!(bool)oCMENSAJESUC.isnull["IIDMENSAJE"])
                {
                    auxPar.Value = oCMENSAJESUC.IIDMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCMENSAJESUC.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCMENSAJESUC.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVESUC", FbDbType.VarChar);
                if (!(bool)oCMENSAJESUC.isnull["ICLAVESUC"])
                {
                    auxPar.Value = oCMENSAJESUC.ICLAVESUC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MENSAJESUC
      (
    

ACTIVO,


CREADOPOR_USERID,


MODIFICADOPOR_USERID,

IDMENSAJE,

SUCURSALID,

CLAVESUC
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@IDMENSAJE,

@SUCURSALID,

@CLAVESUC
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMENSAJESUC;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        
        public bool BorrarMENSAJESUCD(CMENSAJESUCBE oCMENSAJESUC, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMENSAJESUC.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MENSAJESUC
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


        
        public bool CambiarMENSAJESUCD(CMENSAJESUCBE oCMENSAJESUCNuevo, CMENSAJESUCBE oCMENSAJESUCAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJESUCNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMENSAJESUCNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJESUCNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJESUCNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJESUCNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJESUCNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDMENSAJE", FbDbType.BigInt);
                if (!(bool)oCMENSAJESUCNuevo.isnull["IIDMENSAJE"])
                {
                    auxPar.Value = oCMENSAJESUCNuevo.IIDMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCMENSAJESUCNuevo.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCMENSAJESUCNuevo.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVESUC", FbDbType.VarChar);
                if (!(bool)oCMENSAJESUCNuevo.isnull["ICLAVESUC"])
                {
                    auxPar.Value = oCMENSAJESUCNuevo.ICLAVESUC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMENSAJESUCAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMENSAJESUCAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MENSAJESUC
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

IDMENSAJE=@IDMENSAJE,

SUCURSALID=@SUCURSALID,

CLAVESUC=@CLAVESUC
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



        public List<CMENSAJESUCBE> getMensajeSuc(long mensajeID, FbTransaction st)
        {
            List<CMENSAJESUCBE> retorno = new List<CMENSAJESUCBE>();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@IDMENSAJE", FbDbType.BigInt);
                auxPar.Value = mensajeID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"SELECT * from  MENSAJESUC where IDMENSAJE =  @IDMENSAJE;";



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                while (dr.Read())
                {
                    CMENSAJESUCBE mensuc = new CMENSAJESUCBE();
                    if (dr["ID"] != System.DBNull.Value)
                    {
                        mensuc.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        mensuc.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        mensuc.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        mensuc.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        mensuc.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        mensuc.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["IDMENSAJE"] != System.DBNull.Value)
                    {
                        mensuc.IIDMENSAJE = (long)(dr["IDMENSAJE"]);
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        mensuc.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["CLAVESUC"] != System.DBNull.Value)
                    {
                        mensuc.ICLAVESUC = (string)(dr["CLAVESUC"]);
                    }

                    retorno.Add(mensuc);
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


        public CMENSAJESUCBE seleccionarMENSAJESUC(CMENSAJESUCBE oCMENSAJESUC, FbTransaction st)
        {




            CMENSAJESUCBE retorno = new CMENSAJESUCBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MENSAJESUC where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMENSAJESUC.IID;
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

                    if (dr["IDMENSAJE"] != System.DBNull.Value)
                    {
                        retorno.IIDMENSAJE = (long)(dr["IDMENSAJE"]);
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["CLAVESUC"] != System.DBNull.Value)
                    {
                        retorno.ICLAVESUC = (string)(dr["CLAVESUC"]);
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









        
        public DataSet enlistarMENSAJESUC()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENSAJESUC_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        
        public DataSet enlistarCortoMENSAJESUC()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENSAJESUC_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public int ExisteMENSAJESUC(CMENSAJESUCBE oCMENSAJESUC, FbTransaction st)
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
                auxPar.Value = oCMENSAJESUC.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MENSAJESUC where

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




        public CMENSAJESUCBE AgregarMENSAJESUC(CMENSAJESUCBE oCMENSAJESUC, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJESUC(oCMENSAJESUC, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MENSAJESUC ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMENSAJESUCD(oCMENSAJESUC, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMENSAJESUC(CMENSAJESUCBE oCMENSAJESUC, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJESUC(oCMENSAJESUC, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENSAJESUC no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMENSAJESUCD(oCMENSAJESUC, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMENSAJESUC(CMENSAJESUCBE oCMENSAJESUCNuevo, CMENSAJESUCBE oCMENSAJESUCAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJESUC(oCMENSAJESUCAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENSAJESUC no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMENSAJESUCD(oCMENSAJESUCNuevo, oCMENSAJESUCAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CMENSAJESUCD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
