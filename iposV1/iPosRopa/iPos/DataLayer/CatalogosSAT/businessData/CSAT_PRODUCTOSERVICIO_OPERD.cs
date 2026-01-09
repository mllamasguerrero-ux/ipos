

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



    public class CSAT_PRODUCTOSERVICIO_OPERD
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


        public CSAT_PRODUCTOSERVICIO_OPERBE AgregarSAT_PRODUCTOSERVICIO_OPERD(CSAT_PRODUCTOSERVICIO_OPERBE oCSAT_PRODUCTOSERVICIO_OPER, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_OPER.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPER.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_OPER.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPER.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_OPER.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPER.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_PRODUCTOSERVICIOID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_OPER.isnull["ISAT_PRODUCTOSERVICIOID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPER.ISAT_PRODUCTOSERVICIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_PRODUCTOSERVICIO_OPER
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SAT_PRODUCTOSERVICIOID
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SAT_PRODUCTOSERVICIOID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return oCSAT_PRODUCTOSERVICIO_OPER;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_PRODUCTOSERVICIO_OPERD(CSAT_PRODUCTOSERVICIO_OPERBE oCSAT_PRODUCTOSERVICIO_OPER, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPER.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_PRODUCTOSERVICIO_OPER
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

        public bool BorrarSAT_PRODUCTOSERVICIO_OPER_X_PRODUCTOSERVICIOID(CSAT_PRODUCTOSERVICIO_OPERBE oCSAT_PRODUCTOSERVICIO_OPER, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@SAT_PRODUCTOSERVICIOID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPER.ISAT_PRODUCTOSERVICIOID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_PRODUCTOSERVICIO_OPER
  where

  SAT_PRODUCTOSERVICIOID=@SAT_PRODUCTOSERVICIOID
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

        public bool CambiarSAT_PRODUCTOSERVICIO_OPERD(CSAT_PRODUCTOSERVICIO_OPERBE oCSAT_PRODUCTOSERVICIO_OPERNuevo, CSAT_PRODUCTOSERVICIO_OPERBE oCSAT_PRODUCTOSERVICIO_OPERAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_OPERNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPERNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_OPERNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPERNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_OPERNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPERNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_PRODUCTOSERVICIOID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_OPERNuevo.isnull["ISAT_PRODUCTOSERVICIOID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPERNuevo.ISAT_PRODUCTOSERVICIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_OPERAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPERAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_PRODUCTOSERVICIO_OPER
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SAT_PRODUCTOSERVICIOID=@SAT_PRODUCTOSERVICIOID
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


        public CSAT_PRODUCTOSERVICIO_OPERBE seleccionarSAT_PRODUCTOSERVICIO_OPER(CSAT_PRODUCTOSERVICIO_OPERBE oCSAT_PRODUCTOSERVICIO_OPER, FbTransaction st)
        {




            CSAT_PRODUCTOSERVICIO_OPERBE retorno = new CSAT_PRODUCTOSERVICIO_OPERBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_PRODUCTOSERVICIO_OPER where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPER.IID;
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

                    if (dr["SAT_PRODUCTOSERVICIOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PRODUCTOSERVICIOID = (long)(dr["SAT_PRODUCTOSERVICIOID"]);
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









        public DataSet enlistarSAT_PRODUCTOSERVICIO_OPER()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_PRODUCTOSERVICIO_OPER_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoSAT_PRODUCTOSERVICIO_OPER()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_PRODUCTOSERVICIO_OPER_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }

        public bool ExisteSAT_PRODUCTOSERVICIO_OPER_X_PRODUCTOSERVICIOID(CSAT_PRODUCTOSERVICIO_OPERBE oCSAT_PRODUCTOSERVICIO_OPER, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            bool retorno = false;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@SAT_PRODUCTOSERVICIOID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPER.ISAT_PRODUCTOSERVICIOID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_PRODUCTOSERVICIO_OPER where

  SAT_PRODUCTOSERVICIOID=@SAT_PRODUCTOSERVICIOID  
  );";






                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {
                    retorno = true;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public int ExisteSAT_PRODUCTOSERVICIO_OPER(CSAT_PRODUCTOSERVICIO_OPERBE oCSAT_PRODUCTOSERVICIO_OPER, FbTransaction st)
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
                auxPar.Value = oCSAT_PRODUCTOSERVICIO_OPER.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_PRODUCTOSERVICIO_OPER where

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




        public CSAT_PRODUCTOSERVICIO_OPERBE AgregarSAT_PRODUCTOSERVICIO_OPER(CSAT_PRODUCTOSERVICIO_OPERBE oCSAT_PRODUCTOSERVICIO_OPER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PRODUCTOSERVICIO_OPER(oCSAT_PRODUCTOSERVICIO_OPER, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_PRODUCTOSERVICIO_OPER ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_PRODUCTOSERVICIO_OPERD(oCSAT_PRODUCTOSERVICIO_OPER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_PRODUCTOSERVICIO_OPER(CSAT_PRODUCTOSERVICIO_OPERBE oCSAT_PRODUCTOSERVICIO_OPER, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PRODUCTOSERVICIO_OPER(oCSAT_PRODUCTOSERVICIO_OPER, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_PRODUCTOSERVICIO_OPER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_PRODUCTOSERVICIO_OPERD(oCSAT_PRODUCTOSERVICIO_OPER, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_PRODUCTOSERVICIO_OPER(CSAT_PRODUCTOSERVICIO_OPERBE oCSAT_PRODUCTOSERVICIO_OPERNuevo, CSAT_PRODUCTOSERVICIO_OPERBE oCSAT_PRODUCTOSERVICIO_OPERAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PRODUCTOSERVICIO_OPER(oCSAT_PRODUCTOSERVICIO_OPERAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_PRODUCTOSERVICIO_OPER no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_PRODUCTOSERVICIO_OPERD(oCSAT_PRODUCTOSERVICIO_OPERNuevo, oCSAT_PRODUCTOSERVICIO_OPERAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CSAT_PRODUCTOSERVICIO_OPERD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
