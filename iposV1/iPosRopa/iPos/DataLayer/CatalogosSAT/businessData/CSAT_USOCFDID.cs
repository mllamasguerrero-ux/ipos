

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



    public class CSAT_USOCFDID
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


        public CSAT_USOCFDIBE AgregarSAT_USOCFDID(CSAT_USOCFDIBE oCSAT_USOCFDI, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_USOCFDI.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_USOCFDI.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_USOCFDI.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_USOCFDI.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_USOCFDI.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_USOCFDI.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_USOCFDI.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_USOCFDI.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_USOCFDI.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_USOCFDI.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_PERSONAFISICA", FbDbType.VarChar);
                if (!(bool)oCSAT_USOCFDI.isnull["ISAT_PERSONAFISICA"])
                {
                    auxPar.Value = oCSAT_USOCFDI.ISAT_PERSONAFISICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_PERSONAMORAL", FbDbType.VarChar);
                if (!(bool)oCSAT_USOCFDI.isnull["ISAT_PERSONAMORAL"])
                {
                    auxPar.Value = oCSAT_USOCFDI.ISAT_PERSONAMORAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_USOCFDI.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_USOCFDI.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_USOCFDI.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_USOCFDI.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_USOCFDI
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SAT_CLAVE,

SAT_DESCRIPCION,

SAT_PERSONAFISICA,

SAT_PERSONAMORAL,

SAT_FECHAINICIO,

SAT_FECHAFIN
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SAT_CLAVE,

@SAT_DESCRIPCION,

@SAT_PERSONAFISICA,

@SAT_PERSONAMORAL,

@SAT_FECHAINICIO,

@SAT_FECHAFIN
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_USOCFDI;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_USOCFDID(CSAT_USOCFDIBE oCSAT_USOCFDI, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_USOCFDI.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_USOCFDI
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


        public bool CambiarSAT_USOCFDID(CSAT_USOCFDIBE oCSAT_USOCFDINuevo, CSAT_USOCFDIBE oCSAT_USOCFDIAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_USOCFDINuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_USOCFDINuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_USOCFDINuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_USOCFDINuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_USOCFDINuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_USOCFDINuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_USOCFDINuevo.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_USOCFDINuevo.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_USOCFDINuevo.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_USOCFDINuevo.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_PERSONAFISICA", FbDbType.VarChar);
                if (!(bool)oCSAT_USOCFDINuevo.isnull["ISAT_PERSONAFISICA"])
                {
                    auxPar.Value = oCSAT_USOCFDINuevo.ISAT_PERSONAFISICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_PERSONAMORAL", FbDbType.VarChar);
                if (!(bool)oCSAT_USOCFDINuevo.isnull["ISAT_PERSONAMORAL"])
                {
                    auxPar.Value = oCSAT_USOCFDINuevo.ISAT_PERSONAMORAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_USOCFDINuevo.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_USOCFDINuevo.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_USOCFDINuevo.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_USOCFDINuevo.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_USOCFDIAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_USOCFDIAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_USOCFDI
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SAT_CLAVE=@SAT_CLAVE,

SAT_DESCRIPCION=@SAT_DESCRIPCION,

SAT_PERSONAFISICA=@SAT_PERSONAFISICA,

SAT_PERSONAMORAL=@SAT_PERSONAMORAL,

SAT_FECHAINICIO=@SAT_FECHAINICIO,

SAT_FECHAFIN=@SAT_FECHAFIN
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


        public CSAT_USOCFDIBE seleccionarSAT_USOCFDI(CSAT_USOCFDIBE oCSAT_USOCFDI, FbTransaction st)
        {




            CSAT_USOCFDIBE retorno = new CSAT_USOCFDIBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_USOCFDI where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_USOCFDI.IID;
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

                    if (dr["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = (string)(dr["SAT_CLAVE"]);
                    }

                    if (dr["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = (string)(dr["SAT_DESCRIPCION"]);
                    }

                    if (dr["SAT_PERSONAFISICA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PERSONAFISICA = (string)(dr["SAT_PERSONAFISICA"]);
                    }

                    if (dr["SAT_PERSONAMORAL"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PERSONAMORAL = (string)(dr["SAT_PERSONAMORAL"]);
                    }

                    if (dr["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)(dr["SAT_FECHAINICIO"]);
                    }

                    if (dr["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)(dr["SAT_FECHAFIN"]);
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






        public CSAT_USOCFDIBE seleccionarSAT_USOCFDI_X_CLAVE(CSAT_USOCFDIBE oCSAT_USOCFDI, FbTransaction st)
        {




            CSAT_USOCFDIBE retorno = new CSAT_USOCFDIBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_USOCFDI where  SAT_CLAVE = @SAT_CLAVE  ";


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSAT_USOCFDI.ISAT_CLAVE;
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

                    if (dr["SAT_CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE = (string)(dr["SAT_CLAVE"]);
                    }

                    if (dr["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = (string)(dr["SAT_DESCRIPCION"]);
                    }

                    if (dr["SAT_PERSONAFISICA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PERSONAFISICA = (string)(dr["SAT_PERSONAFISICA"]);
                    }

                    if (dr["SAT_PERSONAMORAL"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PERSONAMORAL = (string)(dr["SAT_PERSONAMORAL"]);
                    }

                    if (dr["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)(dr["SAT_FECHAINICIO"]);
                    }

                    if (dr["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)(dr["SAT_FECHAFIN"]);
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




        public DataSet enlistarSAT_USOCFDI()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_USOCFDI_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoSAT_USOCFDI()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_USOCFDI_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteSAT_USOCFDI(CSAT_USOCFDIBE oCSAT_USOCFDI, FbTransaction st)
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
                auxPar.Value = oCSAT_USOCFDI.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_USOCFDI where

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




        public CSAT_USOCFDIBE AgregarSAT_USOCFDI(CSAT_USOCFDIBE oCSAT_USOCFDI, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_USOCFDI(oCSAT_USOCFDI, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_USOCFDI ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_USOCFDID(oCSAT_USOCFDI, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_USOCFDI(CSAT_USOCFDIBE oCSAT_USOCFDI, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_USOCFDI(oCSAT_USOCFDI, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_USOCFDI no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_USOCFDID(oCSAT_USOCFDI, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_USOCFDI(CSAT_USOCFDIBE oCSAT_USOCFDINuevo, CSAT_USOCFDIBE oCSAT_USOCFDIAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_USOCFDI(oCSAT_USOCFDIAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_USOCFDI no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_USOCFDID(oCSAT_USOCFDINuevo, oCSAT_USOCFDIAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public CSAT_USOCFDID(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }


        public CSAT_USOCFDID()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
