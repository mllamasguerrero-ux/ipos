

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


    public class CCONTRARECIBOHDRD
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
        public CCONTRARECIBOHDRBE AgregarCONTRARECIBOHDRD(CCONTRARECIBOHDRBE oCCONTRARECIBOHDR, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IFECHA"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IESTATUSID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IESTATUSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBOHDR.isnull["ITOTAL"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ABONO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IABONO"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBOHDR.isnull["ISALDO"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ESTATUSPAGOID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IESTATUSPAGOID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IESTATUSPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO CONTRARECIBOHDR
      (

ACTIVO,

FECHA,

PERSONAID,

VENDEDORID,

ESTATUSID,

TOTAL,

ABONO,

SALDO,

ESTATUSPAGOID
         )

Values (

@ACTIVO,

@FECHA,

@PERSONAID,

@VENDEDORID,

@ESTATUSID,

@TOTAL,

@ABONO,

@SALDO,

@ESTATUSPAGOID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCCONTRARECIBOHDR;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarCONTRARECIBOHDRD(CCONTRARECIBOHDRBE oCCONTRARECIBOHDR, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCONTRARECIBOHDR.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from CONTRARECIBOHDR
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
        public bool CambiarCONTRARECIBOHDRD(CCONTRARECIBOHDRBE oCCONTRARECIBOHDRNuevo, CCONTRARECIBOHDRBE oCCONTRARECIBOHDRAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCONTRARECIBOHDRNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCONTRARECIBOHDRNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCCONTRARECIBOHDRNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCCONTRARECIBOHDRNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDRNuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDRNuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDRNuevo.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDRNuevo.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUSID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDRNuevo.isnull["IESTATUSID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDRNuevo.IESTATUSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBOHDRNuevo.isnull["ITOTAL"])
                {
                    auxPar.Value = oCCONTRARECIBOHDRNuevo.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ABONO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBOHDRNuevo.isnull["IABONO"])
                {
                    auxPar.Value = oCCONTRARECIBOHDRNuevo.IABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBOHDRNuevo.isnull["ISALDO"])
                {
                    auxPar.Value = oCCONTRARECIBOHDRNuevo.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSPAGOID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDRNuevo.isnull["IESTATUSPAGOID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDRNuevo.IESTATUSPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDRAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDRAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  CONTRARECIBOHDR
  set


ACTIVO=@ACTIVO,

FECHA=@FECHA,

PERSONAID=@PERSONAID,

VENDEDORID=@VENDEDORID,

ESTATUSID=@ESTATUSID,

TOTAL=@TOTAL,

ABONO=@ABONO,

SALDO=@SALDO,

ESTATUSPAGOID = @ESTATUSPAGOID
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
        public CCONTRARECIBOHDRBE seleccionarCONTRARECIBOHDR(CCONTRARECIBOHDRBE oCCONTRARECIBOHDR, FbTransaction st)
        {




            CCONTRARECIBOHDRBE retorno = new CCONTRARECIBOHDRBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CONTRARECIBOHDR where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCONTRARECIBOHDR.IID;
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

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["VENDEDORID"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDORID = (long)(dr["VENDEDORID"]);
                    }

                    if (dr["ESTATUSID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSID = (long)(dr["ESTATUSID"]);
                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {
                        retorno.ITOTAL = (decimal)(dr["TOTAL"]);
                    }

                    if (dr["ABONO"] != System.DBNull.Value)
                    {
                        retorno.IABONO = (decimal)(dr["ABONO"]);
                    }

                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["OBSERVACIONES"] != System.DBNull.Value)
                    {
                        retorno.IOBSERVACIONES = (string)(dr["OBSERVACIONES"]);
                    }
                    if (dr["ESTATUSPAGOID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSPAGOID = (long)(dr["ESTATUSPAGOID"]);
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
        public DataSet enlistarCONTRARECIBOHDR()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CONTRARECIBOHDR_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoCONTRARECIBOHDR()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CONTRARECIBOHDR_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteCONTRARECIBOHDR(CCONTRARECIBOHDRBE oCCONTRARECIBOHDR, FbTransaction st)
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
                auxPar.Value = oCCONTRARECIBOHDR.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CONTRARECIBOHDR where

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




        public CCONTRARECIBOHDRBE AgregarCONTRARECIBOHDR(CCONTRARECIBOHDRBE oCCONTRARECIBOHDR, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCONTRARECIBOHDR(oCCONTRARECIBOHDR, st);
                if (iRes == 1)
                {
                    this.IComentario = "El CONTRARECIBOHDR ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCONTRARECIBOHDRD(oCCONTRARECIBOHDR, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCONTRARECIBOHDR(CCONTRARECIBOHDRBE oCCONTRARECIBOHDR, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCONTRARECIBOHDR(oCCONTRARECIBOHDR, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CONTRARECIBOHDR no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCONTRARECIBOHDRD(oCCONTRARECIBOHDR, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCONTRARECIBOHDR(CCONTRARECIBOHDRBE oCCONTRARECIBOHDRNuevo, CCONTRARECIBOHDRBE oCCONTRARECIBOHDRAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCONTRARECIBOHDR(oCCONTRARECIBOHDRAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CONTRARECIBOHDR no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCONTRARECIBOHDRD(oCCONTRARECIBOHDRNuevo, oCCONTRARECIBOHDRAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }






        public bool CONTRARECIBO_INSERT( CCONTRARECIBOHDRBE oCCONTRARECIBOHDR, ref long CONTRARECIBOID,  FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IFECHA"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IESTATUSID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IESTATUSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOTAL", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBOHDR.isnull["ITOTAL"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.ITOTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ABONO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IABONO"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IABONO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCCONTRARECIBOHDR.isnull["ISALDO"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.VarChar);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSPAGOID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IESTATUSPAGOID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IESTATUSPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CONTRARECIBOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"CONTRARECIBO_INSERT";

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
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }



                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        CONTRARECIBOID = (long)arParms[arParms.Length - 2].Value;
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




        public bool CambiarEstatusPagoCONTRARECIBOHDRD(CCONTRARECIBOHDRBE oCCONTRARECIBOHDRNuevo, CCONTRARECIBOHDRBE oCCONTRARECIBOHDRAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                

                auxPar = new FbParameter("@ESTATUSPAGOID", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDRNuevo.isnull["IESTATUSPAGOID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDRNuevo.IESTATUSPAGOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCONTRARECIBOHDRAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCONTRARECIBOHDRAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  CONTRARECIBOHDR
  set

ESTATUSPAGOID = @ESTATUSPAGOID
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




        public bool CONTRARECIBOHEADER_DELETE(CCONTRARECIBOHDRBE oCCONTRARECIBOHDR, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@CONTRARECIBOID", FbDbType.BigInt);
                auxPar.Value = oCCONTRARECIBOHDR.IID;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"CONTRARECIBOHEADER_DELETE";

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




        public bool CONTRARECIBOHEADER_SAVE(CCONTRARECIBOHDRBE oCCONTRARECIBOHDR, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@CONTRARECIBOID", FbDbType.BigInt);
                auxPar.Value = oCCONTRARECIBOHDR.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.VarChar);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUSPAGOID", FbDbType.BigInt);
                auxPar.Value = oCCONTRARECIBOHDR.IESTATUSPAGOID;
                parts.Add(auxPar);




                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"CONTRARECIBOHEADER_SAVE";

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





        public bool CONTRARECIBOHEADER_CANCEL(CCONTRARECIBOHDRBE oCCONTRARECIBOHDR, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@CONTRARECIBOID", FbDbType.BigInt);
                auxPar.Value = oCCONTRARECIBOHDR.IID;
                parts.Add(auxPar);


                auxPar = new FbParameter("@OBSERVACIONES", FbDbType.VarChar);
                if (!(bool)oCCONTRARECIBOHDR.isnull["IOBSERVACIONES"])
                {
                    auxPar.Value = oCCONTRARECIBOHDR.IOBSERVACIONES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"CONTRARECIBOHEADER_CANCEL";

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




        public CCONTRARECIBOHDRD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
