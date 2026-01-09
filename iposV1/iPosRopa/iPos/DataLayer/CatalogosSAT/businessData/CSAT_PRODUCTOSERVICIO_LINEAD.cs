

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
    public class CSAT_PRODUCTOSERVICIO_LINEAD
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


        public CSAT_PRODUCTOSERVICIO_LINEABE AgregarSAT_PRODUCTOSERVICIO_LINEAD(CSAT_PRODUCTOSERVICIO_LINEABE oCSAT_PRODUCTOSERVICIO_LINEA, FbTransaction st)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_LINEA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_LINEA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_LINEA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LINEAID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_LINEA.isnull["ILINEAID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEA.ILINEAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_PRODUCTOSERVICIOID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_LINEA.isnull["ISAT_PRODUCTOSERVICIOID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEA.ISAT_PRODUCTOSERVICIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_PRODUCTOSERVICIO_LINEA
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

LINEAID,

SAT_PRODUCTOSERVICIOID
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@LINEAID,

@SAT_PRODUCTOSERVICIOID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_PRODUCTOSERVICIO_LINEA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_PRODUCTOSERVICIO_LINEAD(CSAT_PRODUCTOSERVICIO_LINEABE oCSAT_PRODUCTOSERVICIO_LINEA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_PRODUCTOSERVICIO_LINEA
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

        public bool BorrarSAT_PRODUCTOSERVICIO_LINEAD_X_PRODUCTOSERVICIOID(CSAT_PRODUCTOSERVICIO_LINEABE oCSAT_PRODUCTOSERVICIO_LINEA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@SAT_PRODUCTOSERVICIOID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_PRODUCTOSERVICIO_LINEA
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


        public bool CambiarSAT_PRODUCTOSERVICIO_LINEAD(CSAT_PRODUCTOSERVICIO_LINEABE oCSAT_PRODUCTOSERVICIO_LINEANuevo, CSAT_PRODUCTOSERVICIO_LINEABE oCSAT_PRODUCTOSERVICIO_LINEAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_LINEANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_LINEANuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEANuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_LINEANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LINEAID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_LINEANuevo.isnull["ILINEAID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEANuevo.ILINEAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_PRODUCTOSERVICIOID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_LINEANuevo.isnull["ISAT_PRODUCTOSERVICIOID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEANuevo.ISAT_PRODUCTOSERVICIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO_LINEAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_PRODUCTOSERVICIO_LINEA
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

LINEAID=@LINEAID,

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


        public CSAT_PRODUCTOSERVICIO_LINEABE seleccionarSAT_PRODUCTOSERVICIO_LINEA(CSAT_PRODUCTOSERVICIO_LINEABE oCSAT_PRODUCTOSERVICIO_LINEA, FbTransaction st)
        {




            CSAT_PRODUCTOSERVICIO_LINEABE retorno = new CSAT_PRODUCTOSERVICIO_LINEABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_PRODUCTOSERVICIO_LINEA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEA.IID;
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

                    if (dr["LINEAID"] != System.DBNull.Value)
                    {
                        retorno.ILINEAID = (long)(dr["LINEAID"]);
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









        public DataSet enlistarSAT_PRODUCTOSERVICIO_LINEA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_PRODUCTOSERVICIO_LINEA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoSAT_PRODUCTOSERVICIO_LINEA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_PRODUCTOSERVICIO_LINEA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteSAT_PRODUCTOSERVICIO_LINEA(CSAT_PRODUCTOSERVICIO_LINEABE oCSAT_PRODUCTOSERVICIO_LINEA, FbTransaction st)
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
                auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_PRODUCTOSERVICIO_LINEA where

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

        public bool ExisteSAT_PRODUCTOSERVICIO_LINEA_X_PRODUCTOSERVICIOID(CSAT_PRODUCTOSERVICIO_LINEABE oCSAT_PRODUCTOSERVICIO_LINEA, FbTransaction st)
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
                auxPar.Value = oCSAT_PRODUCTOSERVICIO_LINEA.ISAT_PRODUCTOSERVICIOID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_PRODUCTOSERVICIO_LINEA where

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


        public CSAT_PRODUCTOSERVICIO_LINEABE AgregarSAT_PRODUCTOSERVICIO_LINEA(CSAT_PRODUCTOSERVICIO_LINEABE oCSAT_PRODUCTOSERVICIO_LINEA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PRODUCTOSERVICIO_LINEA(oCSAT_PRODUCTOSERVICIO_LINEA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_PRODUCTOSERVICIO_LINEA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_PRODUCTOSERVICIO_LINEAD(oCSAT_PRODUCTOSERVICIO_LINEA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_PRODUCTOSERVICIO_LINEA(CSAT_PRODUCTOSERVICIO_LINEABE oCSAT_PRODUCTOSERVICIO_LINEA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PRODUCTOSERVICIO_LINEA(oCSAT_PRODUCTOSERVICIO_LINEA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_PRODUCTOSERVICIO_LINEA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_PRODUCTOSERVICIO_LINEAD(oCSAT_PRODUCTOSERVICIO_LINEA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_PRODUCTOSERVICIO_LINEA(CSAT_PRODUCTOSERVICIO_LINEABE oCSAT_PRODUCTOSERVICIO_LINEANuevo, CSAT_PRODUCTOSERVICIO_LINEABE oCSAT_PRODUCTOSERVICIO_LINEAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PRODUCTOSERVICIO_LINEA(oCSAT_PRODUCTOSERVICIO_LINEAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_PRODUCTOSERVICIO_LINEA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_PRODUCTOSERVICIO_LINEAD(oCSAT_PRODUCTOSERVICIO_LINEANuevo, oCSAT_PRODUCTOSERVICIO_LINEAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CSAT_PRODUCTOSERVICIO_LINEAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
