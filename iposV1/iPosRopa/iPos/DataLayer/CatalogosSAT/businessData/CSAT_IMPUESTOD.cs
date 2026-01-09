

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



    public class CSAT_IMPUESTOD
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


        public CSAT_IMPUESTOBE AgregarSAT_IMPUESTOD(CSAT_IMPUESTOBE oCSAT_IMPUESTO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_IMPUESTO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_IMPUESTO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_IMPUESTO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_IMPUESTO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_IMPUESTO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_IMPUESTO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_IMPUESTO.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_IMPUESTO.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_IMPUESTO.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_IMPUESTO.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_RETENCION", FbDbType.VarChar);
                if (!(bool)oCSAT_IMPUESTO.isnull["ISAT_RETENCION"])
                {
                    auxPar.Value = oCSAT_IMPUESTO.ISAT_RETENCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_TRASLADO", FbDbType.VarChar);
                if (!(bool)oCSAT_IMPUESTO.isnull["ISAT_TRASLADO"])
                {
                    auxPar.Value = oCSAT_IMPUESTO.ISAT_TRASLADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_LOCALFEDERAL", FbDbType.VarChar);
                if (!(bool)oCSAT_IMPUESTO.isnull["ISAT_LOCALFEDERAL"])
                {
                    auxPar.Value = oCSAT_IMPUESTO.ISAT_LOCALFEDERAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_ENTIDADAPLICA", FbDbType.VarChar);
                if (!(bool)oCSAT_IMPUESTO.isnull["ISAT_ENTIDADAPLICA"])
                {
                    auxPar.Value = oCSAT_IMPUESTO.ISAT_ENTIDADAPLICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_IMPUESTO
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SAT_CLAVE,

SAT_DESCRIPCION,

SAT_RETENCION,

SAT_TRASLADO,

SAT_LOCALFEDERAL,

SAT_ENTIDADAPLICA
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SAT_CLAVE,

@SAT_DESCRIPCION,

@SAT_RETENCION,

@SAT_TRASLADO,

@SAT_LOCALFEDERAL,

@SAT_ENTIDADAPLICA
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_IMPUESTO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_IMPUESTOD(CSAT_IMPUESTOBE oCSAT_IMPUESTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_IMPUESTO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_IMPUESTO
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


        public bool CambiarSAT_IMPUESTOD(CSAT_IMPUESTOBE oCSAT_IMPUESTONuevo, CSAT_IMPUESTOBE oCSAT_IMPUESTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_IMPUESTONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_IMPUESTONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_IMPUESTONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_IMPUESTONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_IMPUESTONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_IMPUESTONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_IMPUESTONuevo.isnull["ISAT_CLAVE"])
                {
                    auxPar.Value = oCSAT_IMPUESTONuevo.ISAT_CLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_IMPUESTONuevo.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_IMPUESTONuevo.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_RETENCION", FbDbType.VarChar);
                if (!(bool)oCSAT_IMPUESTONuevo.isnull["ISAT_RETENCION"])
                {
                    auxPar.Value = oCSAT_IMPUESTONuevo.ISAT_RETENCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_TRASLADO", FbDbType.VarChar);
                if (!(bool)oCSAT_IMPUESTONuevo.isnull["ISAT_TRASLADO"])
                {
                    auxPar.Value = oCSAT_IMPUESTONuevo.ISAT_TRASLADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_LOCALFEDERAL", FbDbType.VarChar);
                if (!(bool)oCSAT_IMPUESTONuevo.isnull["ISAT_LOCALFEDERAL"])
                {
                    auxPar.Value = oCSAT_IMPUESTONuevo.ISAT_LOCALFEDERAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_ENTIDADAPLICA", FbDbType.VarChar);
                if (!(bool)oCSAT_IMPUESTONuevo.isnull["ISAT_ENTIDADAPLICA"])
                {
                    auxPar.Value = oCSAT_IMPUESTONuevo.ISAT_ENTIDADAPLICA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_IMPUESTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_IMPUESTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_IMPUESTO
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SAT_CLAVE=@SAT_CLAVE,

SAT_DESCRIPCION=@SAT_DESCRIPCION,

SAT_RETENCION=@SAT_RETENCION,

SAT_TRASLADO=@SAT_TRASLADO,

SAT_LOCALFEDERAL=@SAT_LOCALFEDERAL,

SAT_ENTIDADAPLICA=@SAT_ENTIDADAPLICA
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


        public CSAT_IMPUESTOBE seleccionarSAT_IMPUESTO(CSAT_IMPUESTOBE oCSAT_IMPUESTO, FbTransaction st)
        {




            CSAT_IMPUESTOBE retorno = new CSAT_IMPUESTOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_IMPUESTO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_IMPUESTO.IID;
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

                    if (dr["SAT_RETENCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RETENCION = (string)(dr["SAT_RETENCION"]);
                    }

                    if (dr["SAT_TRASLADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_TRASLADO = (string)(dr["SAT_TRASLADO"]);
                    }

                    if (dr["SAT_LOCALFEDERAL"] != System.DBNull.Value)
                    {
                        retorno.ISAT_LOCALFEDERAL = (string)(dr["SAT_LOCALFEDERAL"]);
                    }

                    if (dr["SAT_ENTIDADAPLICA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_ENTIDADAPLICA = (string)(dr["SAT_ENTIDADAPLICA"]);
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




        public CSAT_IMPUESTOBE seleccionarSAT_IMPUESTO_X_CLAVE(CSAT_IMPUESTOBE oCSAT_IMPUESTO, FbTransaction st)
        {




            CSAT_IMPUESTOBE retorno = new CSAT_IMPUESTOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_IMPUESTO where SAT_CLAVE = @SAT_CLAVE  ";


                auxPar = new FbParameter("@SAT_CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSAT_IMPUESTO.ISAT_CLAVE;
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

                    if (dr["SAT_RETENCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_RETENCION = (string)(dr["SAT_RETENCION"]);
                    }

                    if (dr["SAT_TRASLADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_TRASLADO = (string)(dr["SAT_TRASLADO"]);
                    }

                    if (dr["SAT_LOCALFEDERAL"] != System.DBNull.Value)
                    {
                        retorno.ISAT_LOCALFEDERAL = (string)(dr["SAT_LOCALFEDERAL"]);
                    }

                    if (dr["SAT_ENTIDADAPLICA"] != System.DBNull.Value)
                    {
                        retorno.ISAT_ENTIDADAPLICA = (string)(dr["SAT_ENTIDADAPLICA"]);
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








        public DataSet enlistarSAT_IMPUESTO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_IMPUESTO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoSAT_IMPUESTO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_IMPUESTO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteSAT_IMPUESTO(CSAT_IMPUESTOBE oCSAT_IMPUESTO, FbTransaction st)
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
                auxPar.Value = oCSAT_IMPUESTO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_IMPUESTO where

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




        public CSAT_IMPUESTOBE AgregarSAT_IMPUESTO(CSAT_IMPUESTOBE oCSAT_IMPUESTO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_IMPUESTO(oCSAT_IMPUESTO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_IMPUESTO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_IMPUESTOD(oCSAT_IMPUESTO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_IMPUESTO(CSAT_IMPUESTOBE oCSAT_IMPUESTO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_IMPUESTO(oCSAT_IMPUESTO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_IMPUESTO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_IMPUESTOD(oCSAT_IMPUESTO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_IMPUESTO(CSAT_IMPUESTOBE oCSAT_IMPUESTONuevo, CSAT_IMPUESTOBE oCSAT_IMPUESTOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_IMPUESTO(oCSAT_IMPUESTOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_IMPUESTO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_IMPUESTOD(oCSAT_IMPUESTONuevo, oCSAT_IMPUESTOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public CSAT_IMPUESTOD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }


        public CSAT_IMPUESTOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
