

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

    [Transaction(TransactionOption.Supported)]


    public class CQUOTAD
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


        [AutoComplete]
        public CQUOTABE AgregarQUOTAD(CQUOTABE oCQUOTA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCQUOTA.isnull["IID"])
                {
                    auxPar.Value = oCQUOTA.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCQUOTA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCQUOTA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCQUOTA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCQUOTA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCQUOTA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCQUOTA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCQUOTA.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCQUOTA.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ANIO", FbDbType.Integer);
                if (!(bool)oCQUOTA.isnull["IANIO"])
                {
                    auxPar.Value = oCQUOTA.IANIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MES", FbDbType.Integer);
                if (!(bool)oCQUOTA.isnull["IMES"])
                {
                    auxPar.Value = oCQUOTA.IMES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@QUOTA", FbDbType.Numeric);
                if (!(bool)oCQUOTA.isnull["IQUOTA"])
                {
                    auxPar.Value = oCQUOTA.IQUOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOGRO", FbDbType.Numeric);
                if (!(bool)oCQUOTA.isnull["ILOGRO"])
                {
                    auxPar.Value = oCQUOTA.ILOGRO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@UTILIDAD", FbDbType.Numeric);
                if (!(bool)oCQUOTA.isnull["IUTILIDAD"])
                {
                    auxPar.Value = oCQUOTA.IUTILIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO QUOTA
      (
    
ID,

ACTIVO,

CREADO,

CREADOPOR_USERID,

MODIFICADO,

MODIFICADOPOR_USERID,

VENDEDORID,

ANIO,

MES,

QUOTA,

LOGRO,

UTILIDAD
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@VENDEDORID,

@ANIO,

@MES,

@QUOTA,

@LOGRO,

@UTILIDAD
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCQUOTA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarQUOTAD(CQUOTABE oCQUOTA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCQUOTA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from QUOTA
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
        public bool CambiarQUOTAD(CQUOTABE oCQUOTANuevo, CQUOTABE oCQUOTAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCQUOTANuevo.isnull["IID"])
                {
                    auxPar.Value = oCQUOTANuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCQUOTANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCQUOTANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCQUOTANuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCQUOTANuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCQUOTANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCQUOTANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCQUOTANuevo.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCQUOTANuevo.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ANIO", FbDbType.Integer);
                if (!(bool)oCQUOTANuevo.isnull["IANIO"])
                {
                    auxPar.Value = oCQUOTANuevo.IANIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MES", FbDbType.Integer);
                if (!(bool)oCQUOTANuevo.isnull["IMES"])
                {
                    auxPar.Value = oCQUOTANuevo.IMES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@QUOTA", FbDbType.Numeric);
                if (!(bool)oCQUOTANuevo.isnull["IQUOTA"])
                {
                    auxPar.Value = oCQUOTANuevo.IQUOTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LOGRO", FbDbType.Numeric);
                if (!(bool)oCQUOTANuevo.isnull["ILOGRO"])
                {
                    auxPar.Value = oCQUOTANuevo.ILOGRO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@UTILIDAD", FbDbType.Numeric);
                if (!(bool)oCQUOTANuevo.isnull["IUTILIDAD"])
                {
                    auxPar.Value = oCQUOTANuevo.IUTILIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCQUOTAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCQUOTAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  QUOTA
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

VENDEDORID=@VENDEDORID,

ANIO=@ANIO,

MES=@MES,

QUOTA=@QUOTA,

LOGRO=@LOGRO,

UTILIDAD=@UTILIDAD
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
        public CQUOTABE seleccionarQUOTA(CQUOTABE oCQUOTA, FbTransaction st)
        {




            CQUOTABE retorno = new CQUOTABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from QUOTA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCQUOTA.IID;
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

                    if (dr["VENDEDORID"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDORID = (long)(dr["VENDEDORID"]);
                    }

                    if (dr["QUOTA"] != System.DBNull.Value)
                    {
                        retorno.IQUOTA = (decimal)(dr["QUOTA"]);
                    }

                    if (dr["LOGRO"] != System.DBNull.Value)
                    {
                        retorno.ILOGRO = (decimal)(dr["LOGRO"]);
                    }

                    if (dr["UTILIDAD"] != System.DBNull.Value)
                    {
                        retorno.IUTILIDAD = (decimal)(dr["UTILIDAD"]);
                    }

                    if (dr["ANIO"] != System.DBNull.Value)
                    {
                        retorno.IANIO = int.Parse(dr["ANIO"].ToString());
                    }

                    if (dr["MES"] != System.DBNull.Value)
                    {
                        retorno.IMES = int.Parse(dr["MES"].ToString());
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
        public DataSet enlistarQUOTA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_QUOTA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoQUOTA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_QUOTA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteQUOTA(CQUOTABE oCQUOTA, FbTransaction st)
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
                auxPar.Value = oCQUOTA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from QUOTA where

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




        public CQUOTABE AgregarQUOTA(CQUOTABE oCQUOTA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteQUOTA(oCQUOTA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El QUOTA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarQUOTAD(oCQUOTA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarQUOTA(CQUOTABE oCQUOTA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteQUOTA(oCQUOTA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El QUOTA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarQUOTAD(oCQUOTA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarQUOTA(CQUOTABE oCQUOTANuevo, CQUOTABE oCQUOTAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteQUOTA(oCQUOTAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El QUOTA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarQUOTAD(oCQUOTANuevo, oCQUOTAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CQUOTABE[] seleccionarQUOTASVendedorAnio(long vendedorId, int anio, FbTransaction st)
        {


            System.Collections.ArrayList retornoArray = new ArrayList();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            //

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from QUOTA where VENDEDORID = @VENDEDORID AND ANIO = @ANIO  ";


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ANIO", FbDbType.Integer);
                auxPar.Value = anio;
                parts.Add(auxPar);


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    CQUOTABE retorno = new CQUOTABE();
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

                    if (dr["VENDEDORID"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDORID = (long)(dr["VENDEDORID"]);
                    }

                    if (dr["QUOTA"] != System.DBNull.Value)
                    {
                        retorno.IQUOTA = (decimal)(dr["QUOTA"]);
                    }

                    if (dr["LOGRO"] != System.DBNull.Value)
                    {
                        retorno.ILOGRO = (decimal)(dr["LOGRO"]);
                    }

                    if (dr["UTILIDAD"] != System.DBNull.Value)
                    {
                        retorno.IUTILIDAD = (decimal)(dr["UTILIDAD"]);
                    }

                    if (dr["ANIO"] != System.DBNull.Value)
                    {
                        retorno.IANIO = int.Parse(dr["ANIO"].ToString());
                    }

                    if (dr["MES"] != System.DBNull.Value)
                    {
                        retorno.IMES = int.Parse(dr["MES"].ToString());
                    }
                    retornoArray.Add(retorno);
                }



                CQUOTABE[] items = new CQUOTABE[retornoArray.Count];
                retornoArray.CopyTo(items, 0);


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return items;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        

    public bool CambiarQUOTAVendedorAnio(long vendedorId, int anio,
                                             decimal quotaEnero, decimal quotaFebrero, decimal quotaMarzo, decimal quotaAbril,
                                             decimal quotaMayo, decimal quotaJunio, decimal quotaJulio, decimal quotaAgosto,
                                             decimal quotaSeptiembre, decimal quotaOctubre, decimal quotaNoviembre, decimal quotaDiciembre,
            FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = vendedorId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ANIO", FbDbType.Integer);
                auxPar.Value = anio;
                parts.Add(auxPar);


                auxPar = new FbParameter("@QUOTA_ENERO", FbDbType.Decimal);
                auxPar.Value = quotaEnero;
                parts.Add(auxPar);

                auxPar = new FbParameter("@QUOTA_FEBRERO", FbDbType.Decimal);
                auxPar.Value = quotaFebrero;
                parts.Add(auxPar);

                auxPar = new FbParameter("@QUOTA_MARZO", FbDbType.Decimal);
                auxPar.Value = quotaMarzo;
                parts.Add(auxPar);

                auxPar = new FbParameter("@QUOTA_ABRIL", FbDbType.Decimal);
                auxPar.Value = quotaAbril;
                parts.Add(auxPar);

                auxPar = new FbParameter("@QUOTA_MAYO", FbDbType.Decimal);
                auxPar.Value = quotaMayo;
                parts.Add(auxPar);

                auxPar = new FbParameter("@QUOTA_JUNIO", FbDbType.Decimal);
                auxPar.Value = quotaJunio;
                parts.Add(auxPar);

                auxPar = new FbParameter("@QUOTA_JULIO", FbDbType.Decimal);
                auxPar.Value = quotaJulio;
                parts.Add(auxPar);

                auxPar = new FbParameter("@QUOTA_AGOSTO", FbDbType.Decimal);
                auxPar.Value = quotaAgosto;
                parts.Add(auxPar);

                auxPar = new FbParameter("@QUOTA_SEPTIEMBRE", FbDbType.Decimal);
                auxPar.Value = quotaSeptiembre;
                parts.Add(auxPar);

                auxPar = new FbParameter("@QUOTA_OCTUBRE", FbDbType.Decimal);
                auxPar.Value = quotaOctubre;
                parts.Add(auxPar);

                auxPar = new FbParameter("@QUOTA_NOVIEMBRE", FbDbType.Decimal);
                auxPar.Value = quotaNoviembre;
                parts.Add(auxPar);

                auxPar = new FbParameter("@QUOTA_DICIEMBRE", FbDbType.Decimal);
                auxPar.Value = quotaDiciembre;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"QUOTA_UPDATE_ANIO";

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

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "ERROR : " + strMensajeErr;
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




    public bool CambiarAsignacionDelClienteXFecha(long clienteId, long vendedorId, DateTime fechaInicio, DateTime fechafin, FbTransaction st)
    {


        try
        {
            System.Collections.ArrayList parts = new ArrayList();
            FbParameter auxPar;



            auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
            auxPar.Value = fechaInicio;
            parts.Add(auxPar);

            auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
            auxPar.Value = fechafin;
            parts.Add(auxPar);

            auxPar = new FbParameter("@CLIENTEID", FbDbType.BigInt);
            auxPar.Value = clienteId;
            parts.Add(auxPar);

            auxPar = new FbParameter("@VENDEDORUTILIDADIDNEW", FbDbType.BigInt);
            auxPar.Value = vendedorId;
            parts.Add(auxPar);

            auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
            auxPar.Direction = ParameterDirection.Output;
            parts.Add(auxPar);


            string commandText = @"REASIGNARUTILIDADES";

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



        public CQUOTAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
