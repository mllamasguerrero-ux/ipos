
using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Text;
namespace iPosData
{

    


    public class CMENSAJED
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


        
        public CMENSAJEBE AgregarMENSAJED(CMENSAJEBE oCMENSAJE, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJE.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMENSAJE.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJE.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJE.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJE.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJE.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJEID", FbDbType.BigInt);
                if (!(bool)oCMENSAJE.isnull["IMENSAJEID"])
                {
                    auxPar.Value = oCMENSAJE.IMENSAJEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJETIPOID", FbDbType.BigInt);
                if (!(bool)oCMENSAJE.isnull["IMENSAJETIPOID"])
                {
                    auxPar.Value = oCMENSAJE.IMENSAJETIPOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ASUNTO", FbDbType.VarChar);
                if (!(bool)oCMENSAJE.isnull["IASUNTO"])
                {
                    auxPar.Value = oCMENSAJE.IASUNTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGOLECTURA", FbDbType.VarChar);
                if (!(bool)oCMENSAJE.isnull["ICODIGOLECTURA"])
                {
                    auxPar.Value = oCMENSAJE.ICODIGOLECTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCMENSAJE.isnull["IFECHA"])
                {
                    auxPar.Value = oCMENSAJE.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAHORA", FbDbType.TimeStamp);
                if (!(bool)oCMENSAJE.isnull["IFECHAHORA"])
                {
                    auxPar.Value = oCMENSAJE.IFECHAHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PARATODASSUC", FbDbType.Char);
                if (!(bool)oCMENSAJE.isnull["IPARATODASSUC"])
                {
                    auxPar.Value = oCMENSAJE.IPARATODASSUC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PARATODASAREAS", FbDbType.Char);
                if (!(bool)oCMENSAJE.isnull["IPARATODASAREAS"])
                {
                    auxPar.Value = oCMENSAJE.IPARATODASAREAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SOLOADMIN", FbDbType.Char);
                if (!(bool)oCMENSAJE.isnull["ISOLOADMIN"])
                {
                    auxPar.Value = oCMENSAJE.ISOLOADMIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESTRICTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJE.isnull["IRESTRICTIVO"])
                {
                    auxPar.Value = oCMENSAJE.IRESTRICTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJERAIZID", FbDbType.BigInt);
                if (!(bool)oCMENSAJE.isnull["IMENSAJERAIZID"])
                {
                    auxPar.Value = oCMENSAJE.IMENSAJERAIZID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJEPADREID", FbDbType.BigInt);
                if (!(bool)oCMENSAJE.isnull["IMENSAJEPADREID"])
                {
                    auxPar.Value = oCMENSAJE.IMENSAJEPADREID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJEESTADOID", FbDbType.BigInt);
                if (!(bool)oCMENSAJE.isnull["IMENSAJEESTADOID"])
                {
                    auxPar.Value = oCMENSAJE.IMENSAJEESTADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJEUSUARIO", FbDbType.BigInt);
                if (!(bool)oCMENSAJE.isnull["IMENSAJEUSUARIO"])
                {
                    auxPar.Value = oCMENSAJE.IMENSAJEUSUARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NIVELDEURGENCIAID", FbDbType.BigInt);
                if (!(bool)oCMENSAJE.isnull["INIVELDEURGENCIAID"])
                {
                    auxPar.Value = oCMENSAJE.INIVELDEURGENCIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALFUENTECLAVE", FbDbType.VarChar);
                if (!(bool)oCMENSAJE.isnull["ISUCURSALFUENTECLAVE"])
                {
                    auxPar.Value = oCMENSAJE.ISUCURSALFUENTECLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MENSAJE", FbDbType.Text);
                if (!(bool)oCMENSAJE.isnull["IMENSAJE"] && oCMENSAJE.IMENSAJE != null)
                {
                    auxPar.Value =  oCMENSAJE.IMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MENSAJE
      (
   

ACTIVO,


CREADOPOR_USERID,

MODIFICADOPOR_USERID,

MENSAJEID,

MENSAJETIPOID,

ASUNTO,

CODIGOLECTURA,

FECHA,

FECHAHORA,

PARATODASSUC,

PARATODASAREAS,

SOLOADMIN,

RESTRICTIVO,

MENSAJERAIZID,

MENSAJEPADREID,

MENSAJEESTADOID,

MENSAJEUSUARIO,

NIVELDEURGENCIAID,

SUCURSALFUENTECLAVE,

MENSAJE
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@MENSAJEID,

@MENSAJETIPOID,

@ASUNTO,

@CODIGOLECTURA,

@FECHA,

@FECHAHORA,

@PARATODASSUC,

@PARATODASAREAS,

@SOLOADMIN,

@RESTRICTIVO,

@MENSAJERAIZID,

@MENSAJEPADREID,

@MENSAJEESTADOID,

@MENSAJEUSUARIO,

@NIVELDEURGENCIAID,

@SUCURSALFUENTECLAVE,

@MENSAJE
) RETURNING ID; ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                Object result = null;

                if (st == null)
                    result = SqlHelper.ExecuteScalar(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    result = SqlHelper.ExecuteScalar(st, CommandType.Text, commandText, arParms);




                oCMENSAJE.IID = (long)result;


                return oCMENSAJE;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        
        public bool BorrarMENSAJED(CMENSAJEBE oCMENSAJE, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMENSAJE.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MENSAJE
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


        
        public bool CambiarMENSAJED(CMENSAJEBE oCMENSAJENuevo, CMENSAJEBE oCMENSAJEAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJENuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMENSAJENuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJENuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMENSAJENuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJEID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENuevo.isnull["IMENSAJEID"])
                {
                    auxPar.Value = oCMENSAJENuevo.IMENSAJEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJETIPOID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENuevo.isnull["IMENSAJETIPOID"])
                {
                    auxPar.Value = oCMENSAJENuevo.IMENSAJETIPOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ASUNTO", FbDbType.VarChar);
                if (!(bool)oCMENSAJENuevo.isnull["IASUNTO"])
                {
                    auxPar.Value = oCMENSAJENuevo.IASUNTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGOLECTURA", FbDbType.VarChar);
                if (!(bool)oCMENSAJENuevo.isnull["ICODIGOLECTURA"])
                {
                    auxPar.Value = oCMENSAJENuevo.ICODIGOLECTURA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCMENSAJENuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCMENSAJENuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PARATODASSUC", FbDbType.Char);
                if (!(bool)oCMENSAJENuevo.isnull["IPARATODASSUC"])
                {
                    auxPar.Value = oCMENSAJENuevo.IPARATODASSUC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PARATODASAREAS", FbDbType.Char);
                if (!(bool)oCMENSAJENuevo.isnull["IPARATODASAREAS"])
                {
                    auxPar.Value = oCMENSAJENuevo.IPARATODASAREAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SOLOADMIN", FbDbType.Char);
                if (!(bool)oCMENSAJENuevo.isnull["ISOLOADMIN"])
                {
                    auxPar.Value = oCMENSAJENuevo.ISOLOADMIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RESTRICTIVO", FbDbType.Char);
                if (!(bool)oCMENSAJENuevo.isnull["IRESTRICTIVO"])
                {
                    auxPar.Value = oCMENSAJENuevo.IRESTRICTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJERAIZID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENuevo.isnull["IMENSAJERAIZID"])
                {
                    auxPar.Value = oCMENSAJENuevo.IMENSAJERAIZID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJEPADREID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENuevo.isnull["IMENSAJEPADREID"])
                {
                    auxPar.Value = oCMENSAJENuevo.IMENSAJEPADREID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJEESTADOID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENuevo.isnull["IMENSAJEESTADOID"])
                {
                    auxPar.Value = oCMENSAJENuevo.IMENSAJEESTADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJEUSUARIO", FbDbType.BigInt);
                if (!(bool)oCMENSAJENuevo.isnull["IMENSAJEUSUARIO"])
                {
                    auxPar.Value = oCMENSAJENuevo.IMENSAJEUSUARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NIVELDEURGENCIAID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENuevo.isnull["INIVELDEURGENCIAID"])
                {
                    auxPar.Value = oCMENSAJENuevo.INIVELDEURGENCIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALFUENTECLAVE", FbDbType.VarChar);
                if (!(bool)oCMENSAJENuevo.isnull["ISUCURSALFUENTECLAVE"])
                {
                    auxPar.Value = oCMENSAJENuevo.ISUCURSALFUENTECLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MENSAJE", FbDbType.Text);
                if (!(bool)oCMENSAJENuevo.isnull["IMENSAJE"])
                {
                    auxPar.Value = oCMENSAJENuevo.IMENSAJE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMENSAJEAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMENSAJEAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MENSAJE
  set


ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

MENSAJEID=@MENSAJEID,

MENSAJETIPOID=@MENSAJETIPOID,

ASUNTO=@ASUNTO,

CODIGOLECTURA=@CODIGOLECTURA,

FECHA=@FECHA,

PARATODASSUC=@PARATODASSUC,

PARATODASAREAS=@PARATODASAREAS,

SOLOADMIN=@SOLOADMIN,

RESTRICTIVO=@RESTRICTIVO,

MENSAJERAIZID=@MENSAJERAIZID,

MENSAJEPADREID=@MENSAJEPADREID,

MENSAJEESTADOID=@MENSAJEESTADOID,

MENSAJEUSUARIO=@MENSAJEUSUARIO,

NIVELDEURGENCIAID=@NIVELDEURGENCIAID,

SUCURSALFUENTECLAVE=@SUCURSALFUENTECLAVE,

MENSAJE=@MENSAJE
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



        public bool CambiarESTADOD(CMENSAJEBE oCMENSAJENuevo, CMENSAJEBE oCMENSAJEAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@MENSAJEESTADOID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENuevo.isnull["IMENSAJEESTADOID"])
                {
                    auxPar.Value = oCMENSAJENuevo.IMENSAJEESTADOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

               

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMENSAJEAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMENSAJEAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MENSAJE
  set


MENSAJEESTADOID=@MENSAJEESTADOID
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





        public bool CambiarMENSAJEWSIDD(CMENSAJEBE oCMENSAJENuevo, CMENSAJEBE oCMENSAJEAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@MENSAJEID", FbDbType.BigInt);
                if (!(bool)oCMENSAJENuevo.isnull["IMENSAJEID"])
                {
                    auxPar.Value = oCMENSAJENuevo.IMENSAJEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMENSAJEAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMENSAJEAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MENSAJE
  set


MENSAJEID=@MENSAJEID
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
        
        public CMENSAJEBE seleccionarMENSAJE(CMENSAJEBE oCMENSAJE, FbTransaction st)
        {




            CMENSAJEBE retorno = new CMENSAJEBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MENSAJE where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMENSAJE.IID;
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

                    if (dr["MENSAJEID"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJEID = (long)(dr["MENSAJEID"]);
                    }

                    if (dr["MENSAJETIPOID"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJETIPOID = (long)(dr["MENSAJETIPOID"]);
                    }

                    if (dr["ASUNTO"] != System.DBNull.Value)
                    {
                        retorno.IASUNTO = (string)(dr["ASUNTO"]);
                    }

                    if (dr["CODIGOLECTURA"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOLECTURA = (string)(dr["CODIGOLECTURA"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (object)(dr["FECHAHORA"]);
                    }

                    if (dr["PARATODASSUC"] != System.DBNull.Value)
                    {
                        retorno.IPARATODASSUC = (string)(dr["PARATODASSUC"]);
                    }

                    if (dr["PARATODASAREAS"] != System.DBNull.Value)
                    {
                        retorno.IPARATODASAREAS = (string)(dr["PARATODASAREAS"]);
                    }

                    if (dr["SOLOADMIN"] != System.DBNull.Value)
                    {
                        retorno.ISOLOADMIN = (string)(dr["SOLOADMIN"]);
                    }

                    if (dr["RESTRICTIVO"] != System.DBNull.Value)
                    {
                        retorno.IRESTRICTIVO = (string)(dr["RESTRICTIVO"]);
                    }

                    if (dr["MENSAJERAIZID"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJERAIZID = (long)(dr["MENSAJERAIZID"]);
                    }

                    if (dr["MENSAJEPADREID"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJEPADREID = (long)(dr["MENSAJEPADREID"]);
                    }

                    if (dr["MENSAJEESTADOID"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJEESTADOID = (long)(dr["MENSAJEESTADOID"]);
                    }

                    if (dr["MENSAJEUSUARIO"] != System.DBNull.Value)
                    {
                        retorno.IMENSAJEUSUARIO = (long)(dr["MENSAJEUSUARIO"]);
                    }

                    if (dr["NIVELDEURGENCIAID"] != System.DBNull.Value)
                    {
                        retorno.INIVELDEURGENCIAID = (long)(dr["NIVELDEURGENCIAID"]);
                    }

                    if (dr["SUCURSALFUENTECLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALFUENTECLAVE = (string)(dr["SUCURSALFUENTECLAVE"]);
                    }

                    if (dr["MENSAJE"] != System.DBNull.Value)
                    {

                        retorno.IMENSAJE = (string)dr["MENSAJE"];
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





        public bool llamarMENSAJES_ALERTAUSUARIO(long usuarioId, string usuarioEsAdmin, ref int countMensjSinLeer, ref int countMensjSinLeerRest,
                                                 ref int countMensjSinLeerAdm, ref int countMensjSinLeerAdmRest, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                auxPar.Value = usuarioId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@USUARIOESADMIN", FbDbType.VarChar);
                auxPar.Value = usuarioEsAdmin;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CUENTAMENSAJESSINLEER", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CUENTAMENSAJESSINLEERRESTR", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CUENTAMENSAJESSINLEERADM", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CUENTAMENSAJESSINLEERADMRESTR", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MENSAJES_ALERTAUSUARIO";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        this.iComentario = "Hubo un error";
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    countMensjSinLeerAdmRest = (int)arParms[arParms.Length - 2].Value;

                }

                if (!(arParms[arParms.Length - 3].Value == System.DBNull.Value))
                {
                    countMensjSinLeerAdm = (int)arParms[arParms.Length - 3].Value;

                }

                if (!(arParms[arParms.Length - 4].Value == System.DBNull.Value))
                {
                    countMensjSinLeerRest = (int)arParms[arParms.Length - 4].Value;

                }

                if (!(arParms[arParms.Length - 5].Value == System.DBNull.Value))
                {
                    countMensjSinLeer = (int)arParms[arParms.Length - 5].Value;

                }

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        
        public DataSet enlistarMENSAJE()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENSAJE_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        
        public DataSet enlistarCortoMENSAJE()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MENSAJE_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public int ExisteMENSAJE(CMENSAJEBE oCMENSAJE, FbTransaction st)
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
                auxPar.Value = oCMENSAJE.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MENSAJE where

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




        public CMENSAJEBE AgregarMENSAJE(CMENSAJEBE oCMENSAJE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJE(oCMENSAJE, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MENSAJE ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMENSAJED(oCMENSAJE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMENSAJE(CMENSAJEBE oCMENSAJE, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJE(oCMENSAJE, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENSAJE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMENSAJED(oCMENSAJE, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMENSAJE(CMENSAJEBE oCMENSAJENuevo, CMENSAJEBE oCMENSAJEAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMENSAJE(oCMENSAJEAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MENSAJE no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMENSAJED(oCMENSAJENuevo, oCMENSAJEAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CMENSAJED()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
