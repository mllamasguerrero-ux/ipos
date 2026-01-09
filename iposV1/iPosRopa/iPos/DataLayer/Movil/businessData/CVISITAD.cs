

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


    public class CVISITAD
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



        public CVISITABE AgregarVISITAD(CVISITABE oCVISITA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCVISITA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCVISITA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVISITA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCVISITA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVISITA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCVISITA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCVISITA.isnull["IFECHA"])
                {
                    auxPar.Value = oCVISITA.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HORAINICIO", FbDbType.TimeStamp);
                if (!(bool)oCVISITA.isnull["IHORAINICIO"])
                {
                    auxPar.Value = oCVISITA.IHORAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HORAFIN", FbDbType.TimeStamp);
                if (!(bool)oCVISITA.isnull["IHORAFIN"])
                {
                    auxPar.Value = oCVISITA.IHORAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCVISITA.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCVISITA.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONACLAVE", FbDbType.VarChar);
                if (!(bool)oCVISITA.isnull["IPERSONACLAVE"])
                {
                    auxPar.Value = oCVISITA.IPERSONACLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HIZOPEDIDO", FbDbType.Char);
                if (!(bool)oCVISITA.isnull["IHIZOPEDIDO"])
                {
                    auxPar.Value = oCVISITA.IHIZOPEDIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENVIADOWS", FbDbType.Char);
                if (!(bool)oCVISITA.isnull["IENVIADOWS"])
                {
                    auxPar.Value = oCVISITA.IENVIADOWS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO VISITA
      (
    

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

FECHA,

HORAINICIO,

HORAFIN,

PERSONAID,

PERSONACLAVE,

HIZOPEDIDO,

ENVIADOWS
         )

Values (


@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@FECHA,

@HORAINICIO,

@HORAFIN,

@PERSONAID,

@PERSONACLAVE,

@HIZOPEDIDO,

@ENVIADOWS
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);



                return oCVISITA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BorrarVISITAD(CVISITABE oCVISITA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCVISITA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from VISITA
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



        public bool CambiarVISITAD(CVISITABE oCVISITANuevo, CVISITABE oCVISITAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCVISITANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCVISITANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVISITANuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCVISITANuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCVISITANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCVISITANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCVISITANuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCVISITANuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HORAINICIO", FbDbType.TimeStamp);
                if (!(bool)oCVISITANuevo.isnull["IHORAINICIO"])
                {
                    auxPar.Value = oCVISITANuevo.IHORAINICIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HORAFIN", FbDbType.TimeStamp);
                if (!(bool)oCVISITANuevo.isnull["IHORAFIN"])
                {
                    auxPar.Value = oCVISITANuevo.IHORAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCVISITANuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCVISITANuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONACLAVE", FbDbType.VarChar);
                if (!(bool)oCVISITANuevo.isnull["IPERSONACLAVE"])
                {
                    auxPar.Value = oCVISITANuevo.IPERSONACLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@HIZOPEDIDO", FbDbType.Char);
                if (!(bool)oCVISITANuevo.isnull["IHIZOPEDIDO"])
                {
                    auxPar.Value = oCVISITANuevo.IHIZOPEDIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENVIADOWS", FbDbType.Char);
                if (!(bool)oCVISITANuevo.isnull["IENVIADOWS"])
                {
                    auxPar.Value = oCVISITANuevo.IENVIADOWS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCVISITAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCVISITAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  VISITA
  set


ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

FECHA=@FECHA,

HORAINICIO=@HORAINICIO,

HORAFIN=@HORAFIN,

PERSONAID=@PERSONAID,

PERSONACLAVE=@PERSONACLAVE,

HIZOPEDIDO=@HIZOPEDIDO,

ENVIADOWS=@ENVIADOWS
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







        public bool MOVILVISITA_ASIGNARHIZOPEDIDO(CVISITABE oCVISITANuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@VISITAID", FbDbType.BigInt);
                auxPar.Value = oCVISITANuevo.IID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"MOVILVISITA_ASIGNARHIZOPEDIDO";

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

                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool finalizarVISITAD(CVISITABE oCVISITANuevo, CVISITABE oCVISITAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;






                auxPar = new FbParameter("@HORAFIN", FbDbType.TimeStamp);
                if (!(bool)oCVISITANuevo.isnull["IHORAFIN"])
                {
                    auxPar.Value = oCVISITANuevo.IHORAFIN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@HIZOPEDIDO", FbDbType.Char);
                if (!(bool)oCVISITANuevo.isnull["IHIZOPEDIDO"])
                {
                    auxPar.Value = oCVISITANuevo.IHIZOPEDIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCVISITAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCVISITAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  VISITA
  set


HORAFIN=@HORAFIN,

HIZOPEDIDO=@HIZOPEDIDO

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




        public bool CancelarVISITAD(CVISITABE oCVISITANuevo,  FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCVISITANuevo.isnull["IID"])
                {
                    auxPar.Value = oCVISITANuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  VISITA
  set ACTIVO='N'
  where ID=@IDAnt
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



        public bool updateEnviadoWSVISITAD(CVISITABE oCVISITANuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ENVIADOWS", FbDbType.Char);
                if (!(bool)oCVISITANuevo.isnull["IENVIADOWS"])
                {
                    auxPar.Value = oCVISITANuevo.IENVIADOWS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCVISITANuevo.isnull["IID"])
                {
                    auxPar.Value = oCVISITANuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  VISITA
  set ENVIADOWS=@ENVIADOWS
  where ID=@IDAnt
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



        public bool setEnviadoWSPENDINGSVISITAD( FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;






                string commandText = @"
  update  VISITA
  set ENVIADOWS = 'S'
  WHERE ACTIVO = 'S' AND ENVIADOWS <> 'S' 
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





        public bool updateHizoPedidoVISITAD(CVISITABE oCVISITANuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@HIZOPEDIDO", FbDbType.Char);
                if (!(bool)oCVISITANuevo.isnull["IHIZOPEDIDO"])
                {
                    auxPar.Value = oCVISITANuevo.IHIZOPEDIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCVISITANuevo.isnull["IID"])
                {
                    auxPar.Value = oCVISITANuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  VISITA
  setHIZOPEDIDO=@HIZOPEDIDO
  where ID=@IDAnt
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




        public CVISITABE seleccionarVISITA(CVISITABE oCVISITA, FbTransaction st)
        {




            CVISITABE retorno = new CVISITABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from VISITA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCVISITA.IID;
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

                    if (dr["HORAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IHORAINICIO = (DateTime)(dr["HORAINICIO"]);
                    }

                    if (dr["HORAFIN"] != System.DBNull.Value)
                    {
                        retorno.IHORAFIN = (DateTime)(dr["HORAFIN"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["PERSONACLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPERSONACLAVE = (string)(dr["PERSONACLAVE"]);
                    }

                    if (dr["HIZOPEDIDO"] != System.DBNull.Value)
                    {
                        retorno.IHIZOPEDIDO = (string)(dr["HIZOPEDIDO"]);
                    }

                    if (dr["ENVIADOWS"] != System.DBNull.Value)
                    {
                        retorno.IENVIADOWS = (string)(dr["ENVIADOWS"]);
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





        public int cantidadDoctosEnVisita(CVISITABE oCVISITA, FbTransaction st)
        {

            int iCuenta = 0;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select count(*) CUENTA from VISITA inner join DOCTO  on visita.personaid = docto.personaid
and visita.horainicio <= docto.fechahora and coalesce(visita.horafin,'') >= docto.fechahora
where docto.estatusdoctoid in (0,1) and docto.tipodoctoid = 321 and visita.id = @ID";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCVISITA.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["CUENTA"] != System.DBNull.Value)
                    {
                        iCuenta = (int)(dr["CUENTA"]);
                    }


                }


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return iCuenta;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }



        }




        public CVISITABE[] seleccionarVISITASNOENVIADAS( FbTransaction st)
        {


            ArrayList retArray = new ArrayList();

            CVISITABE retorno = new CVISITABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                String CmdTxt = @"select * from VISITA WHERE ACTIVO = 'S' AND ENVIADOWS <> 'S'  ";






                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    retorno = new CVISITABE();

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

                    if (dr["HORAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IHORAINICIO = (DateTime)(dr["HORAINICIO"]);
                    }

                    if (dr["HORAFIN"] != System.DBNull.Value)
                    {
                        retorno.IHORAFIN = (DateTime)(dr["HORAFIN"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["PERSONACLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPERSONACLAVE = (string)(dr["PERSONACLAVE"]);
                    }

                    if (dr["HIZOPEDIDO"] != System.DBNull.Value)
                    {
                        retorno.IHIZOPEDIDO = (string)(dr["HIZOPEDIDO"]);
                    }

                    if (dr["ENVIADOWS"] != System.DBNull.Value)
                    {
                        retorno.IENVIADOWS = (string)(dr["ENVIADOWS"]);
                    }



                    retArray.Add(retorno);
                }



                CVISITABE[] ret = new CVISITABE[retArray.Count];
                retArray.CopyTo(ret, 0);


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return ret;

            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        


        public CVISITABE seleccionarULTIMAVISITA( FbTransaction st)
        {




            CVISITABE retorno = new CVISITABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                String CmdTxt = @"select first 1 * from VISITA  order by id desc";






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

                    if (dr["HORAINICIO"] != System.DBNull.Value)
                    {
                        retorno.IHORAINICIO = (DateTime)(dr["HORAINICIO"]);
                    }

                    if (dr["HORAFIN"] != System.DBNull.Value)
                    {
                        retorno.IHORAFIN = (DateTime)(dr["HORAFIN"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["PERSONACLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPERSONACLAVE = (string)(dr["PERSONACLAVE"]);
                    }

                    if (dr["HIZOPEDIDO"] != System.DBNull.Value)
                    {
                        retorno.IHIZOPEDIDO = (string)(dr["HIZOPEDIDO"]);
                    }

                    if (dr["ENVIADOWS"] != System.DBNull.Value)
                    {
                        retorno.IENVIADOWS = (string)(dr["ENVIADOWS"]);
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




        public DataSet enlistarVISITA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_VISITA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        public DataSet enlistarCortoVISITA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_VISITA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public int ExisteVISITA(CVISITABE oCVISITA, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCVISITA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from VISITA where

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




        public CVISITABE AgregarVISITA(CVISITABE oCVISITA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVISITA(oCVISITA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El VISITA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarVISITAD(oCVISITA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarVISITA(CVISITABE oCVISITA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVISITA(oCVISITA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VISITA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarVISITAD(oCVISITA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarVISITA(CVISITABE oCVISITANuevo, CVISITABE oCVISITAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteVISITA(oCVISITAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El VISITA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarVISITAD(oCVISITANuevo, oCVISITAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CVISITAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }
    }
}
