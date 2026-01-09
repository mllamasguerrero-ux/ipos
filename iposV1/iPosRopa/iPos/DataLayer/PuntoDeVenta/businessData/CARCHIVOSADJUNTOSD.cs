using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Collections.Generic;
namespace iPosData
{


    public class CARCHIVOSADJUNTOSD
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


        public CARCHIVOSADJUNTOSBE AgregarARCHIVOSADJUNTOSD(CARCHIVOSADJUNTOSBE oCARCHIVOSADJUNTOS, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCARCHIVOSADJUNTOS.isnull["IACTIVO"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOS.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCARCHIVOSADJUNTOS.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOS.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCARCHIVOSADJUNTOS.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOS.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCARCHIVOSADJUNTOS.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOS.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HORASDETRABAJO", FbDbType.Integer);
                if (!(bool)oCARCHIVOSADJUNTOS.isnull["IHORASDETRABAJO"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOS.IHORASDETRABAJO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHADECREACION", FbDbType.Date);
                if (!(bool)oCARCHIVOSADJUNTOS.isnull["IFECHADECREACION"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOS.IFECHADECREACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCARCHIVOSADJUNTOS.isnull["IFECHA"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOS.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTAARCHIVO", FbDbType.VarChar);
                if (!(bool)oCARCHIVOSADJUNTOS.isnull["IRUTAARCHIVO"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOS.IRUTAARCHIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBREARCHIVO", FbDbType.VarChar);
                if (!(bool)oCARCHIVOSADJUNTOS.isnull["INOMBREARCHIVO"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOS.INOMBREARCHIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO ARCHIVOSADJUNTOS
      (

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

DOCTOID,

HORASDETRABAJO,

FECHADECREACION,

FECHA,

RUTAARCHIVO,

NOMBREARCHIVO
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@DOCTOID,

@HORASDETRABAJO,

@FECHADECREACION,

@FECHA,

@RUTAARCHIVO,

@NOMBREARCHIVO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCARCHIVOSADJUNTOS;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarARCHIVOSADJUNTOSD(CARCHIVOSADJUNTOSBE oCARCHIVOSADJUNTOS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCARCHIVOSADJUNTOS.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from ARCHIVOSADJUNTOS
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


        public bool CambiarARCHIVOSADJUNTOSD(CARCHIVOSADJUNTOSBE oCARCHIVOSADJUNTOSNuevo, CARCHIVOSADJUNTOSBE oCARCHIVOSADJUNTOSAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCARCHIVOSADJUNTOSNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOSNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCARCHIVOSADJUNTOSNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOSNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCARCHIVOSADJUNTOSNuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOSNuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@HORASDETRABAJO", FbDbType.Integer);
                if (!(bool)oCARCHIVOSADJUNTOSNuevo.isnull["IHORASDETRABAJO"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOSNuevo.IHORASDETRABAJO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHADECREACION", FbDbType.Date);
                if (!(bool)oCARCHIVOSADJUNTOSNuevo.isnull["IFECHADECREACION"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOSNuevo.IFECHADECREACION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCARCHIVOSADJUNTOSNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOSNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RUTAARCHIVO", FbDbType.VarChar);
                if (!(bool)oCARCHIVOSADJUNTOSNuevo.isnull["IRUTAARCHIVO"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOSNuevo.IRUTAARCHIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBREARCHIVO", FbDbType.VarChar);
                if (!(bool)oCARCHIVOSADJUNTOSNuevo.isnull["INOMBREARCHIVO"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOSNuevo.INOMBREARCHIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCARCHIVOSADJUNTOSAnterior.isnull["IID"])
                {
                    auxPar.Value = oCARCHIVOSADJUNTOSAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  ARCHIVOSADJUNTOS
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

DOCTOID=@DOCTOID,

HORASDETRABAJO=@HORASDETRABAJO,

FECHADECREACION=@FECHADECREACION,

FECHA=@FECHA,

RUTAARCHIVO=@RUTAARCHIVO,

NOMBREARCHIVO=@NOMBREARCHIVO
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
        public CARCHIVOSADJUNTOSBE seleccionarARCHIVOSADJUNTOS(CARCHIVOSADJUNTOSBE oCARCHIVOSADJUNTOS, FbTransaction st)
        {




            CARCHIVOSADJUNTOSBE retorno = new CARCHIVOSADJUNTOSBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from ARCHIVOSADJUNTOS where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCARCHIVOSADJUNTOS.IID;
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

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["HORASDETRABAJO"] != System.DBNull.Value)
                    {
                        retorno.IHORASDETRABAJO = (int)(dr["HORASDETRABAJO"]);
                    }

                    if (dr["FECHADECREACION"] != System.DBNull.Value)
                    {
                        retorno.IFECHADECREACION = (DateTime)(dr["FECHADECREACION"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["RUTAARCHIVO"] != System.DBNull.Value)
                    {
                        retorno.IRUTAARCHIVO = (string)(dr["RUTAARCHIVO"]);
                    }

                    if (dr["NOMBREARCHIVO"] != System.DBNull.Value)
                    {
                        retorno.INOMBREARCHIVO = (string)(dr["NOMBREARCHIVO"]);
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
        public DataSet enlistarARCHIVOSADJUNTOS()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_ARCHIVOSADJUNTOS_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoARCHIVOSADJUNTOS()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_ARCHIVOSADJUNTOS_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteARCHIVOSADJUNTOS(CARCHIVOSADJUNTOSBE oCARCHIVOSADJUNTOS, FbTransaction st)
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
                auxPar.Value = oCARCHIVOSADJUNTOS.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from ARCHIVOSADJUNTOS where

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




        public CARCHIVOSADJUNTOSBE AgregarARCHIVOSADJUNTOS(CARCHIVOSADJUNTOSBE oCARCHIVOSADJUNTOS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteARCHIVOSADJUNTOS(oCARCHIVOSADJUNTOS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El ARCHIVOSADJUNTOS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarARCHIVOSADJUNTOSD(oCARCHIVOSADJUNTOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarARCHIVOSADJUNTOS(CARCHIVOSADJUNTOSBE oCARCHIVOSADJUNTOS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteARCHIVOSADJUNTOS(oCARCHIVOSADJUNTOS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El ARCHIVOSADJUNTOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarARCHIVOSADJUNTOSD(oCARCHIVOSADJUNTOS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarARCHIVOSADJUNTOS(CARCHIVOSADJUNTOSBE oCARCHIVOSADJUNTOSNuevo, CARCHIVOSADJUNTOSBE oCARCHIVOSADJUNTOSAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteARCHIVOSADJUNTOS(oCARCHIVOSADJUNTOSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El ARCHIVOSADJUNTOS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarARCHIVOSADJUNTOSD(oCARCHIVOSADJUNTOSNuevo, oCARCHIVOSADJUNTOSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public CARCHIVOSADJUNTOSBE[] seleccionarARCHIVOSADJUNTOSPorDOCTOID(long doctoid)
        {

            List<CARCHIVOSADJUNTOSBE> retorno = new List<CARCHIVOSADJUNTOSBE>();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();

                String CmdTxt = @"select * from ARCHIVOSADJUNTOS where ACTIVO = 'S' and DOCTOID =  "+ doctoid;


                /*auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSUCURSAL.ICLAVE;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);*/



                dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt);


                while (dr.Read())
                {
                    CARCHIVOSADJUNTOSBE auxSuc = new CARCHIVOSADJUNTOSBE();

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        auxSuc.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        auxSuc.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        auxSuc.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        auxSuc.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        auxSuc.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        auxSuc.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        auxSuc.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["HORASDETRABAJO"] != System.DBNull.Value)
                    {
                        auxSuc.IHORASDETRABAJO = (int)(dr["HORASDETRABAJO"]);
                    }

                    if (dr["FECHADECREACION"] != System.DBNull.Value)
                    {
                        auxSuc.IFECHADECREACION = (DateTime)(dr["FECHADECREACION"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        auxSuc.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["RUTAARCHIVO"] != System.DBNull.Value)
                    {
                        auxSuc.IRUTAARCHIVO = (string)(dr["RUTAARCHIVO"]);
                    }

                    if (dr["NOMBREARCHIVO"] != System.DBNull.Value)
                    {
                        auxSuc.INOMBREARCHIVO = (string)(dr["NOMBREARCHIVO"]);
                    }

                    retorno.Add(auxSuc);

                }


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno.ToArray();
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        public bool BorrarARCHIVOSADJUNTOSDPorDOCTOID(CARCHIVOSADJUNTOSBE oCARCHIVOSADJUNTOS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = oCARCHIVOSADJUNTOS.IDOCTOID;
                parts.Add(auxPar);



                string commandText = @"  Delete from ARCHIVOSADJUNTOS
  where

  DOCTOID=@DOCTOID
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


        public CARCHIVOSADJUNTOSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
