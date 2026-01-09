

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



    public class CCONTROLPRECIOSD
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


        public CCONTROLPRECIOSBE AgregarCONTROLPRECIOSD(CCONTROLPRECIOSBE oCCONTROLPRECIOS, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCONTROLPRECIOS.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCONTROLPRECIOS.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCONTROLPRECIOS.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCONTROLPRECIOS.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCONTROLPRECIOS.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCONTROLPRECIOS.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCCONTROLPRECIOS.isnull["IFECHA"])
                {
                    auxPar.Value = oCCONTROLPRECIOS.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCCONTROLPRECIOS.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCCONTROLPRECIOS.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPO", FbDbType.Integer);
                if (!(bool)oCCONTROLPRECIOS.isnull["ITIPO"])
                {
                    auxPar.Value = oCCONTROLPRECIOS.ITIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDACTUALIZACION", FbDbType.BigInt);
                if (!(bool)oCCONTROLPRECIOS.isnull["IIDACTUALIZACION"])
                {
                    auxPar.Value = oCCONTROLPRECIOS.IIDACTUALIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO CONTROLPRECIOS
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

FECHA,

USUARIOID,

TIPO,

IDACTUALIZACION
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@FECHA,

@USUARIOID,

@TIPO,

@IDACTUALIZACION
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCCONTROLPRECIOS;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCONTROLPRECIOSD(CCONTROLPRECIOSBE oCCONTROLPRECIOS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCONTROLPRECIOS.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from CONTROLPRECIOS
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


        public bool CambiarCONTROLPRECIOSD(CCONTROLPRECIOSBE oCCONTROLPRECIOSNuevo, CCONTROLPRECIOSBE oCCONTROLPRECIOSAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCONTROLPRECIOSNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCONTROLPRECIOSNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCONTROLPRECIOSNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCONTROLPRECIOSNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCCONTROLPRECIOSNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCCONTROLPRECIOSNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCCONTROLPRECIOSNuevo.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCCONTROLPRECIOSNuevo.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO", FbDbType.Integer);
                if (!(bool)oCCONTROLPRECIOSNuevo.isnull["ITIPO"])
                {
                    auxPar.Value = oCCONTROLPRECIOSNuevo.ITIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDACTUALIZACION", FbDbType.BigInt);
                if (!(bool)oCCONTROLPRECIOSNuevo.isnull["IIDACTUALIZACION"])
                {
                    auxPar.Value = oCCONTROLPRECIOSNuevo.IIDACTUALIZACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCONTROLPRECIOSAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCONTROLPRECIOSAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  CONTROLPRECIOS
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

FECHA=@FECHA,

USUARIOID=@USUARIOID,

TIPO=@TIPO,

IDACTUALIZACION=@IDACTUALIZACION
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


        public CCONTROLPRECIOSBE seleccionarCONTROLPRECIOS(CCONTROLPRECIOSBE oCCONTROLPRECIOS, FbTransaction st)
        {




            CCONTROLPRECIOSBE retorno = new CCONTROLPRECIOSBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CONTROLPRECIOS where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCONTROLPRECIOS.IID;
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

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["USUARIOID"] != System.DBNull.Value)
                    {
                        retorno.IUSUARIOID = (long)(dr["USUARIOID"]);
                    }

                    if (dr["IDACTUALIZACION"] != System.DBNull.Value)
                    {
                        retorno.IIDACTUALIZACION = (long)(dr["IDACTUALIZACION"]);
                    }

                    if (dr["TIPO"] != System.DBNull.Value)
                    {
                        retorno.ITIPO = int.Parse(dr["TIPO"].ToString());
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









        public DataSet enlistarCONTROLPRECIOS()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_CONTROLPRECIOS_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoCONTROLPRECIOS()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_CONTROLPRECIOS_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteCONTROLPRECIOS(CCONTROLPRECIOSBE oCCONTROLPRECIOS, FbTransaction st)
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
                auxPar.Value = oCCONTROLPRECIOS.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CONTROLPRECIOS where

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




        public CCONTROLPRECIOSBE AgregarCONTROLPRECIOS(CCONTROLPRECIOSBE oCCONTROLPRECIOS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCONTROLPRECIOS(oCCONTROLPRECIOS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El CONTROLPRECIOS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCONTROLPRECIOSD(oCCONTROLPRECIOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCONTROLPRECIOS(CCONTROLPRECIOSBE oCCONTROLPRECIOS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCONTROLPRECIOS(oCCONTROLPRECIOS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CONTROLPRECIOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCONTROLPRECIOSD(oCCONTROLPRECIOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCONTROLPRECIOS(CCONTROLPRECIOSBE oCCONTROLPRECIOSNuevo, CCONTROLPRECIOSBE oCCONTROLPRECIOSAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCONTROLPRECIOS(oCCONTROLPRECIOSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CONTROLPRECIOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCONTROLPRECIOSD(oCCONTROLPRECIOSNuevo, oCCONTROLPRECIOSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CCONTROLPRECIOSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
