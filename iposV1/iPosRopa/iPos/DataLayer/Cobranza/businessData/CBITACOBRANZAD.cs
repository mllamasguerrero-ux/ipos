
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



    public class CBITACOBRANZAD
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
        public CBITACOBRANZABE AgregarBITACOBRANZAD(CBITACOBRANZABE oCBITACOBRANZA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;






                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCBITACOBRANZA.isnull["IFECHA"])
                {
                    auxPar.Value = oCBITACOBRANZA.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COBRADORID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZA.isnull["ICOBRADORID"])
                {
                    auxPar.Value = oCBITACOBRANZA.ICOBRADORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TOTALABONADO", FbDbType.Numeric);
                if (!(bool)oCBITACOBRANZA.isnull["ITOTALABONADO"])
                {
                    auxPar.Value = oCBITACOBRANZA.ITOTALABONADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADO", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZA.isnull["IESTADO"])
                {
                    auxPar.Value = oCBITACOBRANZA.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOTARECEPCION", FbDbType.VarChar);
                if (!(bool)oCBITACOBRANZA.isnull["INOTARECEPCION"])
                {
                    auxPar.Value = oCBITACOBRANZA.INOTARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO BITACOBRANZA
      (
  
FECHA,

COBRADORID,

TOTALABONADO,

ESTADO,

NOTARECEPCION
         )

Values (

@FECHA,

@COBRADORID,

@TOTALABONADO,

@ESTADO,

@NOTARECEPCION
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCBITACOBRANZA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarBITACOBRANZAD(CBITACOBRANZABE oCBITACOBRANZA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCBITACOBRANZA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from BITACOBRANZA
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
        public bool CambiarBITACOBRANZAD(CBITACOBRANZABE oCBITACOBRANZANuevo, CBITACOBRANZABE oCBITACOBRANZAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCBITACOBRANZANuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCBITACOBRANZANuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COBRADORID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZANuevo.isnull["ICOBRADORID"])
                {
                    auxPar.Value = oCBITACOBRANZANuevo.ICOBRADORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TOTALABONADO", FbDbType.Numeric);
                if (!(bool)oCBITACOBRANZANuevo.isnull["ITOTALABONADO"])
                {
                    auxPar.Value = oCBITACOBRANZANuevo.ITOTALABONADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADO", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZANuevo.isnull["IESTADO"])
                {
                    auxPar.Value = oCBITACOBRANZANuevo.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOTARECEPCION", FbDbType.VarChar);
                if (!(bool)oCBITACOBRANZANuevo.isnull["INOTARECEPCION"])
                {
                    auxPar.Value = oCBITACOBRANZANuevo.INOTARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCBITACOBRANZAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  BITACOBRANZA
  set


FECHA=@FECHA,

COBRADORID=@COBRADORID,

TOTALABONADO=@TOTALABONADO,

ESTADO=@ESTADO,

NOTARECEPCION = @NOTARECEPCION
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




        public bool CambiarBITACOBRANZA_ESTADO(CBITACOBRANZABE oCBITACOBRANZANuevo, CBITACOBRANZABE oCBITACOBRANZAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ESTADO", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZANuevo.isnull["IESTADO"])
                {
                    auxPar.Value = oCBITACOBRANZANuevo.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCBITACOBRANZAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  BITACOBRANZA
  set


ESTADO=@ESTADO
  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                commandText = @"
  update  BITACOBRANZADET
  set


ESTADO=@ESTADO
  where 

BITCOBRANZAID=@IDAnt
  ;";


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




        public bool CambiarBITACOBRANZA_NOTARECEPCION(CBITACOBRANZABE oCBITACOBRANZANuevo, CBITACOBRANZABE oCBITACOBRANZAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@NOTARECEPCION", FbDbType.VarChar);
                if (!(bool)oCBITACOBRANZANuevo.isnull["INOTARECEPCION"])
                {
                    auxPar.Value = oCBITACOBRANZANuevo.INOTARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCBITACOBRANZAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  BITACOBRANZA
  set


NOTARECEPCION=@NOTARECEPCION
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
        public CBITACOBRANZABE seleccionarBITACOBRANZA(CBITACOBRANZABE oCBITACOBRANZA, FbTransaction st)
        {




            CBITACOBRANZABE retorno = new CBITACOBRANZABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from BITACOBRANZA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCBITACOBRANZA.IID;
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

                    if (dr["COBRADORID"] != System.DBNull.Value)
                    {
                        retorno.ICOBRADORID = (long)(dr["COBRADORID"]);
                    }

                    if (dr["TOTALABONADO"] != System.DBNull.Value)
                    {
                        retorno.ITOTALABONADO = (decimal)(dr["TOTALABONADO"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (long)(dr["ESTADO"]);
                    }

                    if (dr["NOTARECEPCION"] != System.DBNull.Value)
                    {
                        retorno.INOTARECEPCION  = (string)(dr["NOTARECEPCION"]);
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





        public List<CBITACOBRANZABE> seleccionarBITACOBRANZAXCOBRADORFECHA(CBITACOBRANZABE oCBITACOBRANZA, FbTransaction st)
        {




            List<CBITACOBRANZABE> retornoList = new List<CBITACOBRANZABE>();

            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from BITACOBRANZA where FECHA = @FECHA AND COBRADORID = @COBRADORID AND ESTADO = 1 ";


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = oCBITACOBRANZA.IFECHA;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COBRADORID", FbDbType.BigInt);
                auxPar.Value = oCBITACOBRANZA.ICOBRADORID;
                parts.Add(auxPar);



                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    CBITACOBRANZABE retorno = new CBITACOBRANZABE();
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

                    if (dr["COBRADORID"] != System.DBNull.Value)
                    {
                        retorno.ICOBRADORID = (long)(dr["COBRADORID"]);
                    }

                    if (dr["TOTALABONADO"] != System.DBNull.Value)
                    {
                        retorno.ITOTALABONADO = (decimal)(dr["TOTALABONADO"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (long)(dr["ESTADO"]);
                    }

                    if (dr["NOTARECEPCION"] != System.DBNull.Value)
                    {
                        retorno.INOTARECEPCION = (string)(dr["NOTARECEPCION"]);
                    }

                    retornoList.Add(retorno);

                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retornoList;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }





        [AutoComplete]
        public DataSet enlistarBITACOBRANZA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_BITACOBRANZA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoBITACOBRANZA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_BITACOBRANZA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteBITACOBRANZA(CBITACOBRANZABE oCBITACOBRANZA, FbTransaction st)
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
                auxPar.Value = oCBITACOBRANZA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from BITACOBRANZA where

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




        public CBITACOBRANZABE AgregarBITACOBRANZA(CBITACOBRANZABE oCBITACOBRANZA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteBITACOBRANZA(oCBITACOBRANZA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El BITACOBRANZA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarBITACOBRANZAD(oCBITACOBRANZA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarBITACOBRANZA(CBITACOBRANZABE oCBITACOBRANZA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteBITACOBRANZA(oCBITACOBRANZA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El BITACOBRANZA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarBITACOBRANZAD(oCBITACOBRANZA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarBITACOBRANZA(CBITACOBRANZABE oCBITACOBRANZANuevo, CBITACOBRANZABE oCBITACOBRANZAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteBITACOBRANZA(oCBITACOBRANZAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El BITACOBRANZA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarBITACOBRANZAD(oCBITACOBRANZANuevo, oCBITACOBRANZAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public long BITACOBRANZAGENERAR(CBITACOBRANZABE oCBITACOBRANZA, bool forzarCreacion, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@COBRADORID", FbDbType.BigInt);
                if (!(bool)oCBITACOBRANZA.isnull["ICOBRADORID"])
                {
                    auxPar.Value = oCBITACOBRANZA.ICOBRADORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCBITACOBRANZA.isnull["IFECHA"])
                {
                    auxPar.Value = oCBITACOBRANZA.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FORZARCREACION", FbDbType.VarChar);
                auxPar.Value = forzarCreacion ? "S" : "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOTARECEPCION", FbDbType.VarChar);
                if (!(bool)oCBITACOBRANZA.isnull["INOTARECEPCION"])
                {
                    auxPar.Value = oCBITACOBRANZA.INOTARECEPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@IDRETORNO", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);



                string commandText = @"BITACOBRANZAGENERAR";

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
                        int errorvalue = (int)arParms[arParms.Length - 1].Value;
                        this.iComentario = "Hubo un error " + errorvalue.ToString();
                        return errorvalue * -1;
                    }
                }


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    long retorno = (long)arParms[arParms.Length - 2].Value;
                    return retorno;
                }



                this.iComentario = " No se pudo completar la operacion";
                return -1;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }
        }






        public CBITACOBRANZAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }

        public bool BITACORACOBRANZADET_RECIBIR(long bitacobradetid, long bitacobraid, long estado, long cajeroId, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@BITACORACOBRANZADETID", FbDbType.BigInt);
                auxPar.Value = bitacobradetid;
                parts.Add(auxPar);



                auxPar = new FbParameter("@BITACORACOBRANZAID", FbDbType.BigInt);
                auxPar.Value = bitacobraid;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADO", FbDbType.BigInt);
                auxPar.Value = estado;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJEROID", FbDbType.BigInt);
                auxPar.Value = cajeroId;
                parts.Add(auxPar);
                    
                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"BITACORACOBRANZADET_RECIBIR";

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
                        this.iComentario = "Hubo un error" + ((int)arParms[arParms.Length - 1].Value).ToString();
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


    }
}
