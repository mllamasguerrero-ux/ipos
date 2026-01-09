
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
    public class CIMP_FILESD
    {
        private string sCadenaConexion;

        private string iComentario;
        public const string Status_Ingresado = "I";
        public const string Status_Completo = "C";
        public const string Status_Bajado = "B";

        public const string Status_EnTablasTemporales = "T";


        public const short FileType_RecCompras      = 1;
        public const short FileType_Producto        = 2;
        public const short FileType_Traslados       = 3;
        public const short FileType_ExistenciasGen = 4;

        public const short FileType_MatrizPedidos = 5;

        public const short FileType_RecComprasAux = 6;
        public const short FileType_TrasladosAux = 7;


        public const short FileType_PreciosTemp = 21;

        public const short FileType_TrasladosDevo = 8;
        public const short FileType_PedidosDevo = 9;


        public const short FileType_SolicitudMercancia = 25;

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


        public CIMP_FILESBE AgregarIMP_FILESD(CIMP_FILESBE oCIMP_FILES, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@IF_FILE", FbDbType.VarChar);
                if (!(bool)oCIMP_FILES.isnull["IIF_FILE"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_FILE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_TIPO", FbDbType.SmallInt);
                if (!(bool)oCIMP_FILES.isnull["IIF_TIPO"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_TIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_STATUS", FbDbType.Char);
                if (!(bool)oCIMP_FILES.isnull["IIF_STATUS"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_STATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_FECHA", FbDbType.Date);
                if (!(bool)oCIMP_FILES.isnull["IIF_FECHA"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_TIME", FbDbType.Time);
                if (!(bool)oCIMP_FILES.isnull["IIF_TIME"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_TIME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IF_REMOTE_FILE", FbDbType.VarChar);
                if (!(bool)oCIMP_FILES.isnull["IIF_REMOTE_FILE"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_REMOTE_FILE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_SUCURSALCLAVE", FbDbType.VarChar);
                if (!(bool)oCIMP_FILES.isnull["IIF_SUCURSALCLAVE"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_SUCURSALCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCIMP_FILES.isnull["IIF_SUCURSALID"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_SUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO IMP_FILES
      (
    
IF_FILE,

IF_TIPO,

IF_STATUS,

IF_FECHA,

IF_TIME,

IF_REMOTE_FILE,

IF_SUCURSALCLAVE,

IF_SUCURSALID
         )

Values (

@IF_FILE,

@IF_TIPO,

@IF_STATUS,

@IF_FECHA,

@IF_TIME,

@IF_REMOTE_FILE,

@IF_SUCURSALCLAVE,

@IF_SUCURSALID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCIMP_FILES;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }







        public CIMP_FILESBE MATRIZ_PED_IMP_FILES_INSERT(CIMP_FILESBE oCIMP_FILES, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@IF_FILE", FbDbType.VarChar);
                if (!(bool)oCIMP_FILES.isnull["IIF_FILE"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_FILE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_TIPO", FbDbType.SmallInt);
                if (!(bool)oCIMP_FILES.isnull["IIF_TIPO"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_TIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_STATUS", FbDbType.Char);
                if (!(bool)oCIMP_FILES.isnull["IIF_STATUS"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_STATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_FECHA", FbDbType.Date);
                if (!(bool)oCIMP_FILES.isnull["IIF_FECHA"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_TIME", FbDbType.Time);
                if (!(bool)oCIMP_FILES.isnull["IIF_TIME"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_TIME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IF_REMOTE_FILE", FbDbType.VarChar);
                if (!(bool)oCIMP_FILES.isnull["IIF_REMOTE_FILE"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_REMOTE_FILE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_SUCURSALCLAVE", FbDbType.VarChar);
                if (!(bool)oCIMP_FILES.isnull["IIF_SUCURSALCLAVE"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_SUCURSALCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCIMP_FILES.isnull["IIF_SUCURSALID"])
                {
                    auxPar.Value = oCIMP_FILES.IIF_SUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"MATRIZ_PED_IMP_FILES_INSERT";

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
                        return null;
                    }
                }

                return oCIMP_FILES;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



        public bool BorrarIMP_FILESD(CIMP_FILESBE oCIMP_FILES, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@IF_FECHA", FbDbType.Date);
                auxPar.Value = oCIMP_FILES.IIF_FECHA;
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_TIME", FbDbType.Time);
                auxPar.Value = oCIMP_FILES.IIF_TIME;
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_REMOTE_FILE", FbDbType.VarChar);
                auxPar.Value = oCIMP_FILES.IIF_REMOTE_FILE;
                parts.Add(auxPar);



                string commandText = @"  Delete from IMP_FILES
  where

  IF_FECHA=@IF_FECHA and 

  IF_TIME=@IF_TIME and 

  IF_REMOTE_FILE=@IF_REMOTE_FILE
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

        public bool CambiarIMP_FILESD(CIMP_FILESBE oCIMP_FILESNuevo, CIMP_FILESBE oCIMP_FILESAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@IF_FILE", FbDbType.VarChar);
                if (!(bool)oCIMP_FILESNuevo.isnull["IIF_FILE"])
                {
                    auxPar.Value = oCIMP_FILESNuevo.IIF_FILE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IF_TIPO", FbDbType.SmallInt);
                if (!(bool)oCIMP_FILESNuevo.isnull["IIF_TIPO"])
                {
                    auxPar.Value = oCIMP_FILESNuevo.IIF_TIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IF_STATUS", FbDbType.Char);
                if (!(bool)oCIMP_FILESNuevo.isnull["IIF_STATUS"])
                {
                    auxPar.Value = oCIMP_FILESNuevo.IIF_STATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IF_FECHA", FbDbType.Date);
                if (!(bool)oCIMP_FILESNuevo.isnull["IIF_FECHA"])
                {
                    auxPar.Value = oCIMP_FILESNuevo.IIF_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IF_TIME", FbDbType.Time);
                if (!(bool)oCIMP_FILESNuevo.isnull["IIF_TIME"])
                {
                    auxPar.Value = oCIMP_FILESNuevo.IIF_TIME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IF_REMOTE_FILE", FbDbType.VarChar);
                if (!(bool)oCIMP_FILESNuevo.isnull["IIF_REMOTE_FILE"])
                {
                    auxPar.Value = oCIMP_FILESNuevo.IIF_REMOTE_FILE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IF_SUCURSALCLAVE", FbDbType.VarChar);
                if (!(bool)oCIMP_FILESNuevo.isnull["IIF_SUCURSALCLAVE"])
                {
                    auxPar.Value = oCIMP_FILESNuevo.IIF_SUCURSALCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IF_SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCIMP_FILESNuevo.isnull["IIF_SUCURSALID"])
                {
                    auxPar.Value = oCIMP_FILESNuevo.IIF_SUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IF_FECHAAnt", FbDbType.Date);
                if (!(bool)oCIMP_FILESAnterior.isnull["IIF_FECHA"])
                {
                    auxPar.Value = oCIMP_FILESAnterior.IIF_FECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IF_TIMEAnt", FbDbType.Time);
                if (!(bool)oCIMP_FILESAnterior.isnull["IIF_TIME"])
                {
                    auxPar.Value = oCIMP_FILESAnterior.IIF_TIME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IF_REMOTE_FILEAnt", FbDbType.VarChar);
                if (!(bool)oCIMP_FILESAnterior.isnull["IIF_REMOTE_FILE"])
                {
                    auxPar.Value = oCIMP_FILESAnterior.IIF_REMOTE_FILE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  IMP_FILES
  set

IF_FILE=@IF_FILE,

IF_TIPO=@IF_TIPO,

IF_STATUS=@IF_STATUS,

IF_FECHA=@IF_FECHA,

IF_TIME=@IF_TIME,

IF_REMOTE_FILE=@IF_REMOTE_FILE,

IF_SUCURSALCLAVE = @IF_SUCURSALCLAVE, 

IF_SUCURSALID = @IF_SUCURSALID 
  where 

IF_FECHA=@IF_FECHAAnt and

IF_TIME=@IF_TIMEAnt and

IF_REMOTE_FILE=@IF_REMOTE_FILEAnt
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




        public bool CambiarESTATUSIMP_FILESD_X_TIPOYNOMBRE(CIMP_FILESBE oCIMP_FILESNuevo, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@IF_STATUS", FbDbType.Char);
                if (!(bool)oCIMP_FILESNuevo.isnull["IIF_STATUS"])
                {
                    auxPar.Value = oCIMP_FILESNuevo.IIF_STATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IF_FILE", FbDbType.VarChar);
                if (!(bool)oCIMP_FILESNuevo.isnull["IIF_FILE"])
                {
                    auxPar.Value = oCIMP_FILESNuevo.IIF_FILE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IF_TIPO", FbDbType.SmallInt);
                if (!(bool)oCIMP_FILESNuevo.isnull["IIF_TIPO"])
                {
                    auxPar.Value = oCIMP_FILESNuevo.IIF_TIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);






                string commandText = @"
  update  IMP_FILES
  set

IF_STATUS=@IF_STATUS

  where 

IF_FILE=@IF_FILE AND

IF_TIPO=@IF_TIPO
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

        public CIMP_FILESBE seleccionarIMP_FILES(CIMP_FILESBE oCIMP_FILES, FbTransaction st)
        {




            CIMP_FILESBE retorno = new CIMP_FILESBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from IMP_FILES where
 IF_FECHA=@IF_FECHA    and
 IF_TIME=@IF_TIME    and
 IF_REMOTE_FILE=@IF_REMOTE_FILE  ";


                auxPar = new FbParameter("@IF_FECHA", FbDbType.Date);
                auxPar.Value = oCIMP_FILES.IIF_FECHA;
                parts.Add(auxPar);



                auxPar = new FbParameter("@IF_TIME", FbDbType.Time);
                auxPar.Value = oCIMP_FILES.IIF_TIME;
                parts.Add(auxPar);



                auxPar = new FbParameter("@IF_REMOTE_FILE", FbDbType.VarChar);
                auxPar.Value = oCIMP_FILES.IIF_REMOTE_FILE;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["IF_FILE"] != System.DBNull.Value)
                    {
                        retorno.IIF_FILE = (string)(dr["IF_FILE"]);
                    }

                    if (dr["IF_STATUS"] != System.DBNull.Value)
                    {
                        retorno.IIF_STATUS = (string)(dr["IF_STATUS"]);
                    }

                    if (dr["IF_FECHA"] != System.DBNull.Value)
                    {
                        retorno.IIF_FECHA = (DateTime)(dr["IF_FECHA"]);
                    }

                    if (dr["IF_TIME"] != System.DBNull.Value)
                    {
                        retorno.IIF_TIME = (TimeSpan)(dr["IF_TIME"]);
                    }

                    if (dr["IF_TIPO"] != System.DBNull.Value)
                    {
                        retorno.IIF_TIPO = short.Parse(dr["IF_TIPO"].ToString());
                    }

                    if (dr["IF_REMOTE_FILE"] != System.DBNull.Value)
                    {
                        retorno.IIF_REMOTE_FILE = (string)(dr["IF_REMOTE_FILE"]);
                    }

                    if (dr["IF_SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IIF_SUCURSALCLAVE = (string)(dr["IF_SUCURSALCLAVE"]);
                    }

                    if (dr["IF_SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.IIF_SUCURSALID = (long)(dr["IF_SUCURSALID"]);
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



        public DataSet enlistarIMP_FILES()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_IMP_FILES_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }

        }

        public DataSet enlistarCortoIMP_FILES()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_IMP_FILES_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }

        }



        public int ExisteIMP_FILES(CIMP_FILESBE oCIMP_FILES, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@IF_FECHA", FbDbType.Date);
                auxPar.Value = oCIMP_FILES.IIF_FECHA;
                parts.Add(auxPar);

                auxPar = new FbParameter("@IF_TIME", FbDbType.Time);
                auxPar.Value = oCIMP_FILES.IIF_TIME;
                parts.Add(auxPar);

                auxPar = new FbParameter("@IF_REMOTE_FILE", FbDbType.VarChar);
                auxPar.Value = oCIMP_FILES.IIF_REMOTE_FILE;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from IMP_FILES where

  (IF_FECHA=@IF_FECHA    and

  IF_TIME=@IF_TIME    and

  IF_REMOTE_FILE=@IF_REMOTE_FILE) or (IF_REMOTE_FILE=@IF_REMOTE_FILE and IF_TIPO = 4)  
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




        public int YaSeAgregoAImpFiles(CIMP_FILESBE oCIMP_FILES, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@IF_FECHA", FbDbType.Date);
                auxPar.Value = oCIMP_FILES.IIF_FECHA;
                parts.Add(auxPar);

                auxPar = new FbParameter("@IF_TIME", FbDbType.Time);
                auxPar.Value = oCIMP_FILES.IIF_TIME;
                parts.Add(auxPar);

                auxPar = new FbParameter("@IF_REMOTE_FILE", FbDbType.VarChar);
                auxPar.Value = oCIMP_FILES.IIF_REMOTE_FILE;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from IMP_FILES where

  (IF_FECHA=@IF_FECHA    and

  IF_TIME=@IF_TIME    and

  IF_REMOTE_FILE=@IF_REMOTE_FILE) or (IF_REMOTE_FILE=@IF_REMOTE_FILE and IF_TIPO = 4)  or (IF_REMOTE_FILE=@IF_REMOTE_FILE and IF_TIPO = 1 )
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



        public bool ActualizarEstatusIMP_FILESD(CIMP_FILESBE oCIMP_FILES, FbTransaction st)
        {


            System.Collections.ArrayList parts = new ArrayList();
            FbParameter auxPar;

            auxPar = new FbParameter("@IF_FECHA", FbDbType.Date);
            auxPar.Value = oCIMP_FILES.IIF_FECHA;
            parts.Add(auxPar);

            auxPar = new FbParameter("@IF_TIME", FbDbType.Time);
            auxPar.Value = oCIMP_FILES.IIF_TIME;
            parts.Add(auxPar);

            auxPar = new FbParameter("@IF_REMOTE_FILE", FbDbType.VarChar);
            auxPar.Value = oCIMP_FILES.IIF_REMOTE_FILE;
            parts.Add(auxPar);

            string commandText = @"  update IMP_FILES 
SET if_status =
(
select case when count(*) > 0 THEN 'I' ELSE 'C' END
from IMP_RECIBIDOS 
where   IR_REMOTE_FECHA=@IF_FECHA    and IR_REMOTE_TIME=@IF_TIME  and IR_REMOTE_FILE=@IF_REMOTE_FILE   and IR_ESTATUS='I'
)
where 
  IF_FECHA=@IF_FECHA    and IF_TIME=@IF_TIME    and IF_REMOTE_FILE=@IF_REMOTE_FILE  

  ;";

            FbParameter[] arParms = new FbParameter[parts.Count];
            parts.CopyTo(arParms, 0);
            if (st == null)
                SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
            else
                SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);
            return true;
        }


        public CIMP_FILESBE AgregarIMP_FILES(CIMP_FILESBE oCIMP_FILES, FbTransaction st)
        {
            try
            {
                int iRes = ExisteIMP_FILES(oCIMP_FILES, st);
                if (iRes == 1)
                {
                    this.IComentario = "El IMP_FILES ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarIMP_FILESD(oCIMP_FILES, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarIMP_FILES(CIMP_FILESBE oCIMP_FILES, FbTransaction st)
        {
            try
            {
                int iRes = ExisteIMP_FILES(oCIMP_FILES, st);
                if (iRes == 0)
                {
                    this.IComentario = "El IMP_FILES no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarIMP_FILESD(oCIMP_FILES, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool CambiarIMP_FILES(CIMP_FILESBE oCIMP_FILESNuevo, CIMP_FILESBE oCIMP_FILESAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteIMP_FILES(oCIMP_FILESAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El IMP_FILES no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarIMP_FILESD(oCIMP_FILESNuevo, oCIMP_FILESAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public ArrayList ObtenerUltimosArchivosDescargados(FbTransaction st)
        {
            LastDownloadedFiles itemLastFile;
            ArrayList retorno = new ArrayList();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                String CmdTxt = @"select if_tipo TIPO, if_fecha FECHA, max(if_time) HORA from imp_files inner JOIN
                (select if_tipo g_tipo ,max(if_fecha) g_fecha from imp_files group by if_tipo) max_fechas
                on if_tipo = g_tipo and if_fecha = g_fecha group by  if_tipo, if_fecha ";
 
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, null);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, null);
                while (dr.Read())
                {
                    itemLastFile = new LastDownloadedFiles();
                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        itemLastFile.FECHA = (DateTime)(dr["FECHA"]);
                    }
                    if (dr["TIPO"] != System.DBNull.Value)
                    {
                        itemLastFile.TIPO = short.Parse(dr["TIPO"].ToString());
                    }

                    if (dr["HORA"] != System.DBNull.Value)
                    {
                        itemLastFile.TIME = (TimeSpan)(dr["HORA"]);
                    }
                    retorno.Add(itemLastFile);
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



        public ArrayList ObtenerSucursalesABuscarArchivos(FbTransaction st, long matrizId)
        {

            CIMP_FILESBE item;
            string surtidor = "";
            ArrayList retorno = new ArrayList();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {

                CSUCURSALD sucursalD = new CSUCURSALD();
                CSUCURSALBE sucursalBE = new CSUCURSALBE();
                sucursalBE.IID = matrizId;
                sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

                bool bEsMatrizPrincipal = true;
                string matrizClave = ""; 
                if(sucursalBE != null )
                {
                    matrizClave  = sucursalBE.ICLAVE.Trim();
                    if ( !((bool)sucursalBE.isnull["ISURTIDOR"] || sucursalBE.ISURTIDOR == null || sucursalBE.ISURTIDOR.Trim().Length == 0))
                    {
                        bEsMatrizPrincipal = false;
                    }
                }  


                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;
                //, g2_time as TIME

                String CmdTxt = @"select sucursal.id as SUCURSALID, sucursal.clave as SUCURSALCLAVE, g_fecha FECHA , g2_time FECHATIME, sucursal.surtidor as SURTIDOR
                                from SUCURSAL LEFT JOIN
                               (select if_tipo g_tipo ,max(if_fecha) g_fecha, if_sucursalid g_sucursalid from imp_files where if_tipo = 5 group by if_tipo, if_sucursalid) max_fechas
                                on max_fechas.g_sucursalid = sucursal.id  LEFT JOIN
                               (select if_tipo g2_tipo ,if_fecha g2_fecha, if_sucursalid g2_sucursalid, max(if_time) g2_time from imp_files where if_tipo = 5 group by if_tipo, if_fecha, if_sucursalid) max_times
                                on max_times.g2_sucursalid = max_fechas.g_sucursalid and max_times.g2_tipo = max_fechas.g_tipo and max_times.g2_fecha = max_fechas.g_fecha 
                                    ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    item = new CIMP_FILESBE();



                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        item.IIF_FECHA = (DateTime)(dr["FECHA"]);
                    }
                    else
                    {
                        item.IIF_FECHA = DateTime.Parse("01/01/1900");
                    }

                    if (dr["FECHATIME"] != System.DBNull.Value)
                    {
                        item.IIF_TIME = (TimeSpan)(dr["FECHATIME"]);
                    }
                    else
                    {
                        item.IIF_TIME = TimeSpan.MinValue;
                    }

                    item.IIF_TIPO = FileType_MatrizPedidos;

                    if (dr["SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        item.IIF_SUCURSALCLAVE = (string)(dr["SUCURSALCLAVE"]);
                    }

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        item.IIF_SUCURSALID = (long)(dr["SUCURSALID"]);
                    }


                    surtidor = "";

                    if (dr["SURTIDOR"] != System.DBNull.Value)
                    {
                        surtidor = (string)(dr["SURTIDOR"]);
                    }

                   

                    if (item.IIF_SUCURSALID == matrizId)
                        continue;

                    if (bEsMatrizPrincipal)
                    {
                        if(surtidor.Trim().Length != 0 && !surtidor.Trim().Equals(matrizClave))
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if(!surtidor.Trim().Equals(matrizClave))
                        {
                            continue;
                        }
                    }


                   

                    retorno.Add(item);
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




        public ArrayList ObtenerArchivosListosAImportar(FbTransaction st)
        {
            CIMP_FILESBE item;
            ArrayList retorno = new ArrayList();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@IF_STATUS", FbDbType.Char);
                auxPar.Value = Status_Bajado;
                parts.Add(auxPar);

                String CmdTxt = @"select * from IMP_FILES where
                                    IF_STATUS = @IF_STATUS";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    item = new CIMP_FILESBE();
                    if (dr["IF_FILE"] != System.DBNull.Value)
                    {
                        item.IIF_FILE = (string)(dr["IF_FILE"]);
                    }

                    if (dr["IF_STATUS"] != System.DBNull.Value)
                    {
                        item.IIF_STATUS = (string)(dr["IF_STATUS"]);
                    }

                    if (dr["IF_FECHA"] != System.DBNull.Value)
                    {
                        item.IIF_FECHA = (DateTime)(dr["IF_FECHA"]);
                    }

                    if (dr["IF_TIME"] != System.DBNull.Value)
                    {
                        item.IIF_TIME = (TimeSpan)(dr["IF_TIME"]);
                    }

                    if (dr["IF_TIPO"] != System.DBNull.Value)
                    {
                        item.IIF_TIPO = short.Parse(dr["IF_TIPO"].ToString());
                    }

                    if (dr["IF_REMOTE_FILE"] != System.DBNull.Value)
                    {
                        item.IIF_REMOTE_FILE = (string)(dr["IF_REMOTE_FILE"]);
                    }

                    if (dr["IF_SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        item.IIF_SUCURSALCLAVE = (string)(dr["IF_SUCURSALCLAVE"]);
                    }

                    if (dr["IF_SUCURSALID"] != System.DBNull.Value)
                    {
                        item.IIF_SUCURSALID = (long)(dr["IF_SUCURSALID"]);
                    }
                    retorno.Add(item);
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




        public ArrayList ObtenerPedidosDeSucursalesListosAImportar(FbTransaction st)
        {
            CIMP_FILESBE item;
            ArrayList retorno = new ArrayList();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@IF_STATUS", FbDbType.Char);
                auxPar.Value = Status_Bajado;
                parts.Add(auxPar);

                

                String CmdTxt = @"select * from IMP_FILES where
                                    IF_STATUS = @IF_STATUS and (IF_TIPO = '" + FileType_MatrizPedidos.ToString().Trim() + "' or IF_TIPO = '" + FileType_SolicitudMercancia.ToString().Trim() + "' )";
                
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                while (dr.Read())
                {
                    item = new CIMP_FILESBE();
                    if (dr["IF_FILE"] != System.DBNull.Value)
                    {
                        item.IIF_FILE = (string)(dr["IF_FILE"]);
                    }

                    if (dr["IF_STATUS"] != System.DBNull.Value)
                    {
                        item.IIF_STATUS = (string)(dr["IF_STATUS"]);
                    }

                    if (dr["IF_FECHA"] != System.DBNull.Value)
                    {
                        item.IIF_FECHA = (DateTime)(dr["IF_FECHA"]);
                    }

                    if (dr["IF_TIME"] != System.DBNull.Value)
                    {
                        item.IIF_TIME = (TimeSpan)(dr["IF_TIME"]);
                    }

                    if (dr["IF_TIPO"] != System.DBNull.Value)
                    {
                        item.IIF_TIPO = short.Parse(dr["IF_TIPO"].ToString());
                    }

                    if (dr["IF_REMOTE_FILE"] != System.DBNull.Value)
                    {
                        item.IIF_REMOTE_FILE = (string)(dr["IF_REMOTE_FILE"]);
                    }

                    if (dr["IF_SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        item.IIF_SUCURSALCLAVE = (string)(dr["IF_SUCURSALCLAVE"]);
                    }

                    if (dr["IF_SUCURSALID"] != System.DBNull.Value)
                    {
                        item.IIF_SUCURSALID = (long)(dr["IF_SUCURSALID"]);
                    }
                    retorno.Add(item);
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



        public bool HayImportacionesPendientes(long lTipoArchivo)
        {
            bool retorno = false;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {


                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@IF_TIPO", FbDbType.BigInt);
                auxPar.Value = lTipoArchivo;
                parts.Add(auxPar);


                string commandText = @"select coalesce(count(*), 0)
                                        from imp_files
                                        where ((if_tipo = @IF_TIPO )  or (@IF_TIPO = 0 and if_tipo in (1,2,3, 8, 9))) and
                                               (if_status = 'B' or (if_tipo = 1 and (select count(*) from docto where docto.tipodoctoid =11 and docto.subtipodoctoid in (23,6) and estatusdoctoid = 0 ) > 0 )
                                                                or (if_tipo = 3 and (select count(*) from docto where docto.tipodoctoid =41 and estatusdoctoid = 0 ) > 0)  
                                                                or (if_tipo = 8 and (select count(*) from docto where docto.tipodoctoid =32 and estatusdoctoid = 0 ) > 0)  
                                                                or (if_tipo = 9 and (select count(*) from docto where docto.tipodoctoid =11 and estatusdoctoid = 0 ) > 0)  );";


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);

                if (dr.Read())
                {
                    if (dr[0] != System.DBNull.Value)
                        if (short.Parse(dr[0].ToString()) >= 1)
                            retorno = true;
                        else
                            retorno = false;
                }
                else
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
            //return false;

        }



        public bool HayActualizacionesDePreciosAImportar()
        {
            bool retorno = false;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {

                FbParameter[] arParms = new FbParameter[0];
                string commandText = @"select coalesce(count(*), 0)
                                        from imp_files
                                        where if_tipo = 2 and if_status = 'B';";

                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                
                if (dr.Read())
                {
                    if (dr[0] != System.DBNull.Value)
                        if(short.Parse(dr[0].ToString()) >= 1)
                            retorno = true;
                        else
                            retorno = false;
                }
                else
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
            //return false;

        }





        public CIMP_FILESBE seleccionar_auxiliarIMP_FILES(CIMP_FILESBE oCIMP_FILES, FbTransaction st)
        {

            Int16 tipoABuscar = 0;
            switch(oCIMP_FILES.IIF_TIPO)
            {
                case CIMP_FILESD.FileType_RecCompras: tipoABuscar = CIMP_FILESD.FileType_RecComprasAux; break;
                case CIMP_FILESD.FileType_Traslados: tipoABuscar = CIMP_FILESD.FileType_TrasladosAux; break;
            }

            string fileABuscar = oCIMP_FILES.IIF_FILE.Replace(".dbf", "");
            fileABuscar = fileABuscar.Replace("_", ".");
            fileABuscar += ".zip";


            CIMP_FILESBE retorno = new CIMP_FILESBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from IMP_FILES where
                                IF_FILE=@IF_FILE    and
                                IF_TIPO=@IF_TIPO     ";


                auxPar = new FbParameter("@IF_FILE", FbDbType.VarChar);
                auxPar.Value = fileABuscar;
                parts.Add(auxPar);



                auxPar = new FbParameter("@IF_TIPO", FbDbType.SmallInt);
                auxPar.Value = tipoABuscar;
                parts.Add(auxPar);





                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["IF_FILE"] != System.DBNull.Value)
                    {
                        retorno.IIF_FILE = (string)(dr["IF_FILE"]);
                    }

                    if (dr["IF_STATUS"] != System.DBNull.Value)
                    {
                        retorno.IIF_STATUS = (string)(dr["IF_STATUS"]);
                    }

                    if (dr["IF_FECHA"] != System.DBNull.Value)
                    {
                        retorno.IIF_FECHA = (DateTime)(dr["IF_FECHA"]);
                    }

                    if (dr["IF_TIME"] != System.DBNull.Value)
                    {
                        retorno.IIF_TIME = (TimeSpan)(dr["IF_TIME"]);
                    }

                    if (dr["IF_TIPO"] != System.DBNull.Value)
                    {
                        retorno.IIF_TIPO = short.Parse(dr["IF_TIPO"].ToString());
                    }

                    if (dr["IF_REMOTE_FILE"] != System.DBNull.Value)
                    {
                        retorno.IIF_REMOTE_FILE = (string)(dr["IF_REMOTE_FILE"]);
                    }

                    if (dr["IF_SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IIF_SUCURSALCLAVE = (string)(dr["IF_SUCURSALCLAVE"]);
                    }

                    if (dr["IF_SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.IIF_SUCURSALID = (long)(dr["IF_SUCURSALID"]);
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



        public CIMP_FILESD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }
    }
}
