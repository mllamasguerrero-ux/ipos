

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




    public class CSAT_COLONIAD
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



        public CSAT_COLONIABE AgregarSAT_COLONIAD(CSAT_COLONIABE oCSAT_COLONIA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_COLONIA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_COLONIA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_COLONIA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_COLONIA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_COLONIA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_COLONIA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COLONIA", FbDbType.VarChar);
                if (!(bool)oCSAT_COLONIA.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCSAT_COLONIA.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGOPOSTAL", FbDbType.VarChar);
                if (!(bool)oCSAT_COLONIA.isnull["ICODIGOPOSTAL"])
                {
                    auxPar.Value = oCSAT_COLONIA.ICODIGOPOSTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCSAT_COLONIA.isnull["INOMBRE"])
                {
                    auxPar.Value = oCSAT_COLONIA.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_COLONIA
      (
    

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

COLONIA,

CODIGOPOSTAL,

NOMBRE
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@COLONIA,

@CODIGOPOSTAL,

@NOMBRE
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_COLONIA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BorrarSAT_COLONIAD(CSAT_COLONIABE oCSAT_COLONIA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_COLONIA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_COLONIA
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



        public bool CambiarSAT_COLONIAD(CSAT_COLONIABE oCSAT_COLONIANuevo, CSAT_COLONIABE oCSAT_COLONIAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_COLONIANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_COLONIANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_COLONIANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_COLONIANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COLONIA", FbDbType.VarChar);
                if (!(bool)oCSAT_COLONIANuevo.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCSAT_COLONIANuevo.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGOPOSTAL", FbDbType.VarChar);
                if (!(bool)oCSAT_COLONIANuevo.isnull["ICODIGOPOSTAL"])
                {
                    auxPar.Value = oCSAT_COLONIANuevo.ICODIGOPOSTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCSAT_COLONIANuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCSAT_COLONIANuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_COLONIAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_COLONIAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_COLONIA
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

COLONIA=@COLONIA,

CODIGOPOSTAL=@CODIGOPOSTAL,

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



        public CSAT_COLONIABE seleccionarSAT_COLONIA(CSAT_COLONIABE oCSAT_COLONIA, FbTransaction st)
        {




            CSAT_COLONIABE retorno = new CSAT_COLONIABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_COLONIA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_COLONIA.IID;
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

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }

                    if (dr["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = (string)(dr["CODIGOPOSTAL"]);
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





        public CSAT_COLONIABE seleccionarSAT_COLONIA_X_CLAVE(CSAT_COLONIABE oCSAT_COLONIA, FbTransaction st)
        {




            CSAT_COLONIABE retorno = new CSAT_COLONIABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_COLONIA where
 CODIGOPOSTAL=@CODIGOPOSTAL AND COLONIA=@COLONIA  ";


                auxPar = new FbParameter("@CODIGOPOSTAL", FbDbType.VarChar);
                auxPar.Value = oCSAT_COLONIA.ICODIGOPOSTAL;
                parts.Add(auxPar);

                auxPar = new FbParameter("@COLONIA", FbDbType.VarChar);
                auxPar.Value = oCSAT_COLONIA.ICOLONIA;
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

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }

                    if (dr["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = (string)(dr["CODIGOPOSTAL"]);
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







        public DataSet enlistarSAT_COLONIA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_COLONIA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public DataSet enlistarCortoSAT_COLONIA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_COLONIA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public int ExisteSAT_COLONIA(CSAT_COLONIABE oCSAT_COLONIA, FbTransaction st)
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
                auxPar.Value = oCSAT_COLONIA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_COLONIA where

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




        public CSAT_COLONIABE AgregarSAT_COLONIA(CSAT_COLONIABE oCSAT_COLONIA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_COLONIA(oCSAT_COLONIA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_COLONIA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_COLONIAD(oCSAT_COLONIA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_COLONIA(CSAT_COLONIABE oCSAT_COLONIA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_COLONIA(oCSAT_COLONIA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_COLONIA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_COLONIAD(oCSAT_COLONIA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_COLONIA(CSAT_COLONIABE oCSAT_COLONIANuevo, CSAT_COLONIABE oCSAT_COLONIAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_COLONIA(oCSAT_COLONIAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_COLONIA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_COLONIAD(oCSAT_COLONIANuevo, oCSAT_COLONIAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public CSAT_COLONIAD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }


        public CSAT_COLONIAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
