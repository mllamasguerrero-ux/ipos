

using System;
using Microsoft.ApplicationBlocks.Data;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using iPosBusinessEntity;

namespace iPosData
{



    public class CLOGEVENTOTABLAD
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


        public CLOGEVENTOTABLABE AgregarLOGEVENTOTABLAD(CLOGEVENTOTABLABE oCLOGEVENTOTABLA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCLOGEVENTOTABLA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCLOGEVENTOTABLA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLOGEVENTOTABLA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCLOGEVENTOTABLA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLOGEVENTOTABLA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCLOGEVENTOTABLA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAHORA", FbDbType.TimeStamp);
                if (!(bool)oCLOGEVENTOTABLA.isnull["IFECHAHORA"])
                {
                    auxPar.Value = oCLOGEVENTOTABLA.IFECHAHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TABLA", FbDbType.VarChar);
                if (!(bool)oCLOGEVENTOTABLA.isnull["ITABLA"])
                {
                    auxPar.Value = oCLOGEVENTOTABLA.ITABLA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCLOGEVENTOTABLA.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCLOGEVENTOTABLA.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOEVENTOTABLAID", FbDbType.BigInt);
                if (!(bool)oCLOGEVENTOTABLA.isnull["ITIPOEVENTOTABLAID"])
                {
                    auxPar.Value = oCLOGEVENTOTABLA.ITIPOEVENTOTABLAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOTA", FbDbType.VarChar);
                if (!(bool)oCLOGEVENTOTABLA.isnull["INOTA"])
                {
                    auxPar.Value = oCLOGEVENTOTABLA.INOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


		auxPar= new FbParameter("@RECORDID", FbDbType.BigInt);
                                    if(!(bool)oCLOGEVENTOTABLA.isnull["IRECORDID"])
                                    {
                                    auxPar.Value=oCLOGEVENTOTABLA.IRECORDID;
                                    }
                                    else
                                    {
                                    auxPar.Value=System.DBNull.Value;
                                    }
                                    parts.Add(auxPar);


                auxPar = new FbParameter("@ENCABEZADO", FbDbType.VarChar);
                if (!(bool)oCLOGEVENTOTABLA.isnull["IENCABEZADO"])
                {
                    auxPar.Value = oCLOGEVENTOTABLA.IENCABEZADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO LOGEVENTOTABLA
      (
    

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

FECHAHORA,

TABLA,

USUARIOID,

TIPOEVENTOTABLAID,

NOTA,

RECORDID,

ENCABEZADO
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@FECHAHORA,

@TABLA,

@USUARIOID,

@TIPOEVENTOTABLAID,

@NOTA,

@RECORDID,

@ENCABEZADO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCLOGEVENTOTABLA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarLOGEVENTOTABLAD(CLOGEVENTOTABLABE oCLOGEVENTOTABLA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCLOGEVENTOTABLA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from LOGEVENTOTABLA
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


        [AutoComplete]
        public bool CambiarLOGEVENTOTABLAD(CLOGEVENTOTABLABE oCLOGEVENTOTABLANuevo, CLOGEVENTOTABLABE oCLOGEVENTOTABLAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCLOGEVENTOTABLANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCLOGEVENTOTABLANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCLOGEVENTOTABLANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCLOGEVENTOTABLANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TABLA", FbDbType.VarChar);
                if (!(bool)oCLOGEVENTOTABLANuevo.isnull["ITABLA"])
                {
                    auxPar.Value = oCLOGEVENTOTABLANuevo.ITABLA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCLOGEVENTOTABLANuevo.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCLOGEVENTOTABLANuevo.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOEVENTOTABLAID", FbDbType.BigInt);
                if (!(bool)oCLOGEVENTOTABLANuevo.isnull["ITIPOEVENTOTABLAID"])
                {
                    auxPar.Value = oCLOGEVENTOTABLANuevo.ITIPOEVENTOTABLAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTA", FbDbType.VarChar);
                if (!(bool)oCLOGEVENTOTABLANuevo.isnull["INOTA"])
                {
                    auxPar.Value = oCLOGEVENTOTABLANuevo.INOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar= new FbParameter("@RECORDID", FbDbType.BigInt);
                if(!(bool)oCLOGEVENTOTABLANuevo.isnull["IRECORDID"])
                {
                	auxPar.Value=oCLOGEVENTOTABLANuevo.IRECORDID;
                }
                else
                {
                        auxPar.Value=System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENCABEZADO", FbDbType.VarChar);
                if (!(bool)oCLOGEVENTOTABLANuevo.isnull["IENCABEZADO"])
                {
                    auxPar.Value = oCLOGEVENTOTABLANuevo.IENCABEZADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCLOGEVENTOTABLAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCLOGEVENTOTABLAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  LOGEVENTOTABLA
  set


ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

TABLA=@TABLA,

USUARIOID=@USUARIOID,

TIPOEVENTOTABLAID=@TIPOEVENTOTABLAID,

NOTA=@NOTA,

RECORDID=@RECORDID,

ENCABEZADO = @ENCABEZADO
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


        [AutoComplete]
        public CLOGEVENTOTABLABE seleccionarLOGEVENTOTABLA(CLOGEVENTOTABLABE oCLOGEVENTOTABLA, FbTransaction st)
        {




            CLOGEVENTOTABLABE retorno = new CLOGEVENTOTABLABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from LOGEVENTOTABLA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCLOGEVENTOTABLA.IID;
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

                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (DateTime)(dr["FECHAHORA"]);
                    }

                    if (dr["TABLA"] != System.DBNull.Value)
                    {
                        retorno.ITABLA = (string)(dr["TABLA"]);
                    }

                    if (dr["USUARIOID"] != System.DBNull.Value)
                    {
                        retorno.IUSUARIOID = (long)(dr["USUARIOID"]);
                    }

                    if (dr["TIPOEVENTOTABLAID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOEVENTOTABLAID = (long)(dr["TIPOEVENTOTABLAID"]);
                    }

                    if (dr["NOTA"] != System.DBNull.Value)
                    {
                        retorno.INOTA = (string)(dr["NOTA"]);
                    }
                    
		            if( dr["RECORDID"]!= System.DBNull.Value)
                    {
                         retorno.IRECORDID=(long)(dr["RECORDID"]);
                     }


                    if (dr["ENCABEZADO"] != System.DBNull.Value)
                    {
                        retorno.IENCABEZADO = (string)(dr["ENCABEZADO"]);
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









        [AutoComplete]
        public DataSet enlistarLOGEVENTOTABLA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_LOGEVENTOTABLA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoLOGEVENTOTABLA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_LOGEVENTOTABLA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteLOGEVENTOTABLA(CLOGEVENTOTABLABE oCLOGEVENTOTABLA, FbTransaction st)
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
                auxPar.Value = oCLOGEVENTOTABLA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from LOGEVENTOTABLA where

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



        public int ExisteLOGEVENTOTABLAXRecordYTipo(long recordId, string tabla, long tipoEventoTablaId, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                

                auxPar = new FbParameter("@TABLA", FbDbType.VarChar);
                auxPar.Value = tabla;
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@TIPOEVENTOTABLAID", FbDbType.BigInt);
                auxPar.Value = tipoEventoTablaId;
                parts.Add(auxPar);
                



                auxPar = new FbParameter("@RECORDID", FbDbType.BigInt);
                auxPar.Value = recordId;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from LOGEVENTOTABLA where

 TABLA=@TABLA and

TIPOEVENTOTABLAID=@TIPOEVENTOTABLAID and

RECORDID=@RECORDID
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


        public CLOGEVENTOTABLABE AgregarLOGEVENTOTABLA(CLOGEVENTOTABLABE oCLOGEVENTOTABLA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLOGEVENTOTABLA(oCLOGEVENTOTABLA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El LOGEVENTOTABLA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarLOGEVENTOTABLAD(oCLOGEVENTOTABLA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarLOGEVENTOTABLA(CLOGEVENTOTABLABE oCLOGEVENTOTABLA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLOGEVENTOTABLA(oCLOGEVENTOTABLA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El LOGEVENTOTABLA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarLOGEVENTOTABLAD(oCLOGEVENTOTABLA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarLOGEVENTOTABLA(CLOGEVENTOTABLABE oCLOGEVENTOTABLANuevo, CLOGEVENTOTABLABE oCLOGEVENTOTABLAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteLOGEVENTOTABLA(oCLOGEVENTOTABLAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El LOGEVENTOTABLA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarLOGEVENTOTABLAD(oCLOGEVENTOTABLANuevo, oCLOGEVENTOTABLAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CLOGEVENTOTABLAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
