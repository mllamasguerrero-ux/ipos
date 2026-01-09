

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




    public class CSAT_CONFIGAUTOTRANSPORTED
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



        public CSAT_CONFIGAUTOTRANSPORTEBE AgregarSAT_CONFIGAUTOTRANSPORTED(CSAT_CONFIGAUTOTRANSPORTEBE oCSAT_CONFIGAUTOTRANSPORTE, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTE.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTE.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTE.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTE.isnull["ICLAVE"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTE.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMEROEJES", FbDbType.VarChar);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTE.isnull["INUMEROEJES"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.INUMEROEJES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMEROLLANTAS", FbDbType.VarChar);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTE.isnull["INUMEROLLANTAS"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.INUMEROLLANTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REMOLQUE", FbDbType.VarChar);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTE.isnull["IREMOLQUE"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.IREMOLQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTE.isnull["IFECHAINICIO"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.IFECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTE.isnull["IFECHAFIN"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.IFECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO SAT_CONFIGAUTOTRANSPORTE
      (

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE,

DESCRIPCION,

NUMEROEJES,

NUMEROLLANTAS,

REMOLQUE,

FECHAINICIO,

FECHAFIN
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@DESCRIPCION,

@NUMEROEJES,

@NUMEROLLANTAS,

@REMOLQUE,

@FECHAINICIO,

@FECHAFIN
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCSAT_CONFIGAUTOTRANSPORTE;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BorrarSAT_CONFIGAUTOTRANSPORTED(CSAT_CONFIGAUTOTRANSPORTEBE oCSAT_CONFIGAUTOTRANSPORTE, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from SAT_CONFIGAUTOTRANSPORTE
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



        public bool CambiarSAT_CONFIGAUTOTRANSPORTED(CSAT_CONFIGAUTOTRANSPORTEBE oCSAT_CONFIGAUTOTRANSPORTENuevo, CSAT_CONFIGAUTOTRANSPORTEBE oCSAT_CONFIGAUTOTRANSPORTEAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTENuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTENuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTENuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTENuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTENuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTENuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTENuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTENuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMEROEJES", FbDbType.VarChar);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTENuevo.isnull["INUMEROEJES"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTENuevo.INUMEROEJES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMEROLLANTAS", FbDbType.VarChar);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTENuevo.isnull["INUMEROLLANTAS"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTENuevo.INUMEROLLANTAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@REMOLQUE", FbDbType.VarChar);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTENuevo.isnull["IREMOLQUE"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTENuevo.IREMOLQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTENuevo.isnull["IFECHAINICIO"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTENuevo.IFECHAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTENuevo.isnull["IFECHAFIN"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTENuevo.IFECHAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCSAT_CONFIGAUTOTRANSPORTEAnterior.isnull["IID"])
                {
                    auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTEAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  SAT_CONFIGAUTOTRANSPORTE
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

DESCRIPCION=@DESCRIPCION,

NUMEROEJES=@NUMEROEJES,

NUMEROLLANTAS=@NUMEROLLANTAS,

REMOLQUE=@REMOLQUE,

FECHAINICIO=@FECHAINICIO,

FECHAFIN=@FECHAFIN
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



        public CSAT_CONFIGAUTOTRANSPORTEBE seleccionarSAT_CONFIGAUTOTRANSPORTE(CSAT_CONFIGAUTOTRANSPORTEBE oCSAT_CONFIGAUTOTRANSPORTE, FbTransaction st)
        {




            CSAT_CONFIGAUTOTRANSPORTEBE retorno = new CSAT_CONFIGAUTOTRANSPORTEBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_CONFIGAUTOTRANSPORTE where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.IID;
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

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["NUMEROEJES"] != System.DBNull.Value)
                    {
                        retorno.INUMEROEJES = (string)(dr["NUMEROEJES"]);
                    }

                    if (dr["NUMEROLLANTAS"] != System.DBNull.Value)
                    {
                        retorno.INUMEROLLANTAS = (string)(dr["NUMEROLLANTAS"]);
                    }

                    if (dr["REMOLQUE"] != System.DBNull.Value)
                    {
                        retorno.IREMOLQUE = (string)(dr["REMOLQUE"]);
                    }

                    if (dr["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = (DateTime)(dr["FECHAINICIO"]);
                    }

                    if (dr["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = (DateTime)(dr["FECHAFIN"]);
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




        public CSAT_CONFIGAUTOTRANSPORTEBE seleccionarSAT_CONFIGAUTOTRANSPORTE_X_CLAVE(CSAT_CONFIGAUTOTRANSPORTEBE oCSAT_CONFIGAUTOTRANSPORTE, FbTransaction st)
        {




            CSAT_CONFIGAUTOTRANSPORTEBE retorno = new CSAT_CONFIGAUTOTRANSPORTEBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from SAT_CONFIGAUTOTRANSPORTE where
 CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.ICLAVE;
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

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["NUMEROEJES"] != System.DBNull.Value)
                    {
                        retorno.INUMEROEJES = (string)(dr["NUMEROEJES"]);
                    }

                    if (dr["NUMEROLLANTAS"] != System.DBNull.Value)
                    {
                        retorno.INUMEROLLANTAS = (string)(dr["NUMEROLLANTAS"]);
                    }

                    if (dr["REMOLQUE"] != System.DBNull.Value)
                    {
                        retorno.IREMOLQUE = (string)(dr["REMOLQUE"]);
                    }

                    if (dr["FECHAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IFECHAINICIO = (DateTime)(dr["FECHAINICIO"]);
                    }

                    if (dr["FECHAFIN"] != System.DBNull.Value)
                    {
                        retorno.IFECHAFIN = (DateTime)(dr["FECHAFIN"]);
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









        public DataSet enlistarSAT_CONFIGAUTOTRANSPORTE()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_CONFIGAUTOTRANSPORTE_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public DataSet enlistarCortoSAT_CONFIGAUTOTRANSPORTE()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_SAT_CONFIGAUTOTRANSPORTE_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public int ExisteSAT_CONFIGAUTOTRANSPORTE(CSAT_CONFIGAUTOTRANSPORTEBE oCSAT_CONFIGAUTOTRANSPORTE, FbTransaction st)
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
                auxPar.Value = oCSAT_CONFIGAUTOTRANSPORTE.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from SAT_CONFIGAUTOTRANSPORTE where

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




        public CSAT_CONFIGAUTOTRANSPORTEBE AgregarSAT_CONFIGAUTOTRANSPORTE(CSAT_CONFIGAUTOTRANSPORTEBE oCSAT_CONFIGAUTOTRANSPORTE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_CONFIGAUTOTRANSPORTE(oCSAT_CONFIGAUTOTRANSPORTE, st);
                if (iRes == 1)
                {
                    this.IComentario = "El SAT_CONFIGAUTOTRANSPORTE ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarSAT_CONFIGAUTOTRANSPORTED(oCSAT_CONFIGAUTOTRANSPORTE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarSAT_CONFIGAUTOTRANSPORTE(CSAT_CONFIGAUTOTRANSPORTEBE oCSAT_CONFIGAUTOTRANSPORTE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_CONFIGAUTOTRANSPORTE(oCSAT_CONFIGAUTOTRANSPORTE, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_CONFIGAUTOTRANSPORTE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarSAT_CONFIGAUTOTRANSPORTED(oCSAT_CONFIGAUTOTRANSPORTE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarSAT_CONFIGAUTOTRANSPORTE(CSAT_CONFIGAUTOTRANSPORTEBE oCSAT_CONFIGAUTOTRANSPORTENuevo, CSAT_CONFIGAUTOTRANSPORTEBE oCSAT_CONFIGAUTOTRANSPORTEAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteSAT_CONFIGAUTOTRANSPORTE(oCSAT_CONFIGAUTOTRANSPORTEAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El SAT_CONFIGAUTOTRANSPORTE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarSAT_CONFIGAUTOTRANSPORTED(oCSAT_CONFIGAUTOTRANSPORTENuevo, oCSAT_CONFIGAUTOTRANSPORTEAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public CSAT_CONFIGAUTOTRANSPORTED(string cadenaConexion)
        {
            this.sCadenaConexion = cadenaConexion;
        }


        public CSAT_CONFIGAUTOTRANSPORTED()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
