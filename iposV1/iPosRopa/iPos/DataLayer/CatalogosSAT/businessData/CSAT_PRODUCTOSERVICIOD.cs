

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



    public class CSAT_PRODUCTOSERVICIOD
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


        public CSAT_PRODUCTOSERVICIOBE AgregarSAT_PRODUCTOSERVICIOD(CSAT_PRODUCTOSERVICIOBE oCSAT_PRODUCTOSERVICIO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_PRODUCTOSERVICIO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVEPRODSERV", FbDbType.VarChar);
                if (!(bool)oCSAT_PRODUCTOSERVICIO.isnull["ISAT_CLAVEPRODSERV"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO.ISAT_CLAVEPRODSERV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_PRODUCTOSERVICIO.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_PRODUCTOSERVICIO.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_PRODUCTOSERVICIO.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_IVATRASLADADO", FbDbType.VarChar);
                if (!(bool)oCSAT_PRODUCTOSERVICIO.isnull["ISAT_IVATRASLADADO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO.ISAT_IVATRASLADADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_IEPSTRASLADADO", FbDbType.VarChar);
                if (!(bool)oCSAT_PRODUCTOSERVICIO.isnull["ISAT_IEPSTRASLADADO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO.ISAT_IEPSTRASLADADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_COMPLEMENTO", FbDbType.VarChar);
                if (!(bool)oCSAT_PRODUCTOSERVICIO.isnull["ISAT_COMPLEMENTO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIO.ISAT_COMPLEMENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_PRODUCTOSERVICIO
      (
    
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

SAT_CLAVEPRODSERV,

SAT_DESCRIPCION,

SAT_FECHAINICIO,

SAT_FECHAFIN,

SAT_IVATRASLADADO,

SAT_IEPSTRASLADADO,

SAT_COMPLEMENTO
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@SAT_CLAVEPRODSERV,

@SAT_DESCRIPCION,

@SAT_FECHAINICIO,

@SAT_FECHAFIN,

@SAT_IVATRASLADADO,

@SAT_IEPSTRASLADADO,

@SAT_COMPLEMENTO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_PRODUCTOSERVICIO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_PRODUCTOSERVICIOD(CSAT_PRODUCTOSERVICIOBE oCSAT_PRODUCTOSERVICIO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PRODUCTOSERVICIO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_PRODUCTOSERVICIO
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


        public bool CambiarSAT_PRODUCTOSERVICIOD(CSAT_PRODUCTOSERVICIOBE oCSAT_PRODUCTOSERVICIONuevo, CSAT_PRODUCTOSERVICIOBE oCSAT_PRODUCTOSERVICIOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_PRODUCTOSERVICIONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CLAVEPRODSERV", FbDbType.VarChar);
                if (!(bool)oCSAT_PRODUCTOSERVICIONuevo.isnull["ISAT_CLAVEPRODSERV"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIONuevo.ISAT_CLAVEPRODSERV;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_PRODUCTOSERVICIONuevo.isnull["ISAT_DESCRIPCION"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIONuevo.ISAT_DESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_PRODUCTOSERVICIONuevo.isnull["ISAT_FECHAINICIO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIONuevo.ISAT_FECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_PRODUCTOSERVICIONuevo.isnull["ISAT_FECHAFIN"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIONuevo.ISAT_FECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_IVATRASLADADO", FbDbType.VarChar);
                if (!(bool)oCSAT_PRODUCTOSERVICIONuevo.isnull["ISAT_IVATRASLADADO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIONuevo.ISAT_IVATRASLADADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_IEPSTRASLADADO", FbDbType.VarChar);
                if (!(bool)oCSAT_PRODUCTOSERVICIONuevo.isnull["ISAT_IEPSTRASLADADO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIONuevo.ISAT_IEPSTRASLADADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_COMPLEMENTO", FbDbType.VarChar);
                if (!(bool)oCSAT_PRODUCTOSERVICIONuevo.isnull["ISAT_COMPLEMENTO"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIONuevo.ISAT_COMPLEMENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_PRODUCTOSERVICIOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_PRODUCTOSERVICIOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_PRODUCTOSERVICIO
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

SAT_CLAVEPRODSERV=@SAT_CLAVEPRODSERV,

SAT_DESCRIPCION=@SAT_DESCRIPCION,

SAT_FECHAINICIO=@SAT_FECHAINICIO,

SAT_FECHAFIN=@SAT_FECHAFIN,

SAT_IVATRASLADADO=@SAT_IVATRASLADADO,

SAT_IEPSTRASLADADO=@SAT_IEPSTRASLADADO,

SAT_COMPLEMENTO=@SAT_COMPLEMENTO
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


        public CSAT_PRODUCTOSERVICIOBE seleccionarSAT_PRODUCTOSERVICIO(CSAT_PRODUCTOSERVICIOBE oCSAT_PRODUCTOSERVICIO, FbTransaction st)
        {




            CSAT_PRODUCTOSERVICIOBE retorno = new CSAT_PRODUCTOSERVICIOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_PRODUCTOSERVICIO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_PRODUCTOSERVICIO.IID;
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

                    if (dr["SAT_CLAVEPRODSERV"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVEPRODSERV = (string)(dr["SAT_CLAVEPRODSERV"]);
                    }

                    if (dr["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = (string)(dr["SAT_DESCRIPCION"]);
                    }

                    if (dr["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)(dr["SAT_FECHAINICIO"]);
                    }

                    if (dr["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)(dr["SAT_FECHAFIN"]);
                    }

                    if (dr["SAT_IVATRASLADADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_IVATRASLADADO = (string)(dr["SAT_IVATRASLADADO"]);
                    }

                    if (dr["SAT_IEPSTRASLADADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_IEPSTRASLADADO = (string)(dr["SAT_IEPSTRASLADADO"]);
                    }

                    if (dr["SAT_COMPLEMENTO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_COMPLEMENTO = (string)(dr["SAT_COMPLEMENTO"]);
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




        public CSAT_PRODUCTOSERVICIOBE seleccionarSAT_PRODUCTOSERVICIO_X_CLAVE(CSAT_PRODUCTOSERVICIOBE oCSAT_PRODUCTOSERVICIO, FbTransaction st)
        {




            CSAT_PRODUCTOSERVICIOBE retorno = new CSAT_PRODUCTOSERVICIOBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_PRODUCTOSERVICIO where SAT_CLAVEPRODSERV = @SAT_CLAVEPRODSERV  ";


                auxPar = new FbParameter("@SAT_CLAVEPRODSERV", FbDbType.VarChar);
                auxPar.Value = oCSAT_PRODUCTOSERVICIO.ISAT_CLAVEPRODSERV;
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

                    if (dr["SAT_CLAVEPRODSERV"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVEPRODSERV = (string)(dr["SAT_CLAVEPRODSERV"]);
                    }

                    if (dr["SAT_DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.ISAT_DESCRIPCION = (string)(dr["SAT_DESCRIPCION"]);
                    }

                    if (dr["SAT_FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAINICIO = (DateTime)(dr["SAT_FECHAINICIO"]);
                    }

                    if (dr["SAT_FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FECHAFIN = (DateTime)(dr["SAT_FECHAFIN"]);
                    }

                    if (dr["SAT_IVATRASLADADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_IVATRASLADADO = (string)(dr["SAT_IVATRASLADADO"]);
                    }

                    if (dr["SAT_IEPSTRASLADADO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_IEPSTRASLADADO = (string)(dr["SAT_IEPSTRASLADADO"]);
                    }

                    if (dr["SAT_COMPLEMENTO"] != System.DBNull.Value)
                    {
                        retorno.ISAT_COMPLEMENTO = (string)(dr["SAT_COMPLEMENTO"]);
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





        public DataSet enlistarSAT_PRODUCTOSERVICIO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_PRODUCTOSERVICIO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoSAT_PRODUCTOSERVICIO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "iPos_SAT_PRODUCTOSERVICIO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteSAT_PRODUCTOSERVICIO(CSAT_PRODUCTOSERVICIOBE oCSAT_PRODUCTOSERVICIO, FbTransaction st)
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
                auxPar.Value = oCSAT_PRODUCTOSERVICIO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_PRODUCTOSERVICIO where

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




        public CSAT_PRODUCTOSERVICIOBE AgregarSAT_PRODUCTOSERVICIO(CSAT_PRODUCTOSERVICIOBE oCSAT_PRODUCTOSERVICIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PRODUCTOSERVICIO(oCSAT_PRODUCTOSERVICIO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_PRODUCTOSERVICIO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_PRODUCTOSERVICIOD(oCSAT_PRODUCTOSERVICIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_PRODUCTOSERVICIO(CSAT_PRODUCTOSERVICIOBE oCSAT_PRODUCTOSERVICIO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PRODUCTOSERVICIO(oCSAT_PRODUCTOSERVICIO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_PRODUCTOSERVICIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_PRODUCTOSERVICIOD(oCSAT_PRODUCTOSERVICIO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_PRODUCTOSERVICIO(CSAT_PRODUCTOSERVICIOBE oCSAT_PRODUCTOSERVICIONuevo, CSAT_PRODUCTOSERVICIOBE oCSAT_PRODUCTOSERVICIOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_PRODUCTOSERVICIO(oCSAT_PRODUCTOSERVICIOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_PRODUCTOSERVICIO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_PRODUCTOSERVICIOD(oCSAT_PRODUCTOSERVICIONuevo, oCSAT_PRODUCTOSERVICIOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public CSAT_PRODUCTOSERVICIOD(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }


        public CSAT_PRODUCTOSERVICIOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
