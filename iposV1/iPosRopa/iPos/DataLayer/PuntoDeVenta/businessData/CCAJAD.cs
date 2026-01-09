


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


    public class CCAJAD
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
        public CCAJABE AgregarCAJAD(CCAJABE oCCAJA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCAJA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCAJA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCAJA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCCAJA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCAJA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCAJA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCCAJA.isnull["ICLAVE"])
                {
                    auxPar.Value = oCCAJA.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCCAJA.isnull["INOMBRE"])
                {
                    auxPar.Value = oCCAJA.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCCAJA.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCCAJA.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@NOMBREIMPRESORA", FbDbType.VarChar);
                if (!(bool)oCCAJA.isnull["INOMBREIMPRESORA"])
                {
                    auxPar.Value = oCCAJA.INOMBREIMPRESORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TERMINAL", FbDbType.VarChar);
                if (!(bool)oCCAJA.isnull["ITERMINAL"])
                {
                    auxPar.Value = oCCAJA.ITERMINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TERMINALSERVICIOS", FbDbType.VarChar);
                if (!(bool)oCCAJA.isnull["ITERMINALSERVICIOS"])
                {
                    auxPar.Value = oCCAJA.ITERMINALSERVICIOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMEROTERMINALBANCOMER", FbDbType.VarChar
                    
                    
                    );
                if (!(bool)oCCAJA.isnull["INUMEROTERMINALBANCOMER"])
                {
                    auxPar.Value = oCCAJA.INUMEROTERMINALBANCOMER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@NOMBRECERTIFICADOBANCOMER", FbDbType.VarChar);
                if (!(bool)oCCAJA.isnull["INOMBRECERTIFICADOBANCOMER"])
                {
                    auxPar.Value = oCCAJA.INOMBRECERTIFICADOBANCOMER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@AFILIACIONBANCOMER", FbDbType.VarChar);
                if (!(bool)oCCAJA.isnull["IAFILIACIONBANCOMER"])
                {
                    auxPar.Value = oCCAJA.IAFILIACIONBANCOMER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPRESORACOMANDA", FbDbType.VarChar);
                if (!(bool)oCCAJA.isnull["IIMPRESORACOMANDA"])
                {
                    auxPar.Value = oCCAJA.IIMPRESORACOMANDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                string commandText = @"
        INSERT INTO CAJA
      (
ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE,

NOMBRE,

DESCRIPCION,

NOMBREIMPRESORA,

TERMINAL,

TERMINALSERVICIOS,

NUMEROTERMINALBANCOMER,

NOMBRECERTIFICADOBANCOMER,

AFILIACIONBANCOMER,

IMPRESORACOMANDA


         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@NOMBRE,

@DESCRIPCION,

@NOMBREIMPRESORA,

@TERMINAL,

@TERMINALSERVICIOS,

@NUMEROTERMINALBANCOMER,

@NOMBRECERTIFICADOBANCOMER,

@AFILIACIONBANCOMER,

@IMPRESORACOMANDA
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCCAJA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarCAJAD(CCAJABE oCCAJA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCAJA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from CAJA
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
        public bool CambiarCAJAD(CCAJABE oCCAJANuevo, CCAJABE oCCAJAAnterior, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                /*
                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCCAJANuevo.isnull["IID"])
                {
                    auxPar.Value = oCCAJANuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);*/

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCCAJANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCCAJANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCCAJANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCCAJANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCCAJANuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCCAJANuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCCAJANuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCCAJANuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCCAJANuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCCAJANuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@NOMBREIMPRESORA", FbDbType.VarChar);
                if (!(bool)oCCAJANuevo.isnull["INOMBREIMPRESORA"])
                {
                    auxPar.Value = oCCAJANuevo.INOMBREIMPRESORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TERMINAL", FbDbType.VarChar);
                if (!(bool)oCCAJANuevo.isnull["ITERMINAL"])
                {
                    auxPar.Value = oCCAJANuevo.ITERMINAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TERMINALSERVICIOS", FbDbType.VarChar);
                if (!(bool)oCCAJANuevo.isnull["ITERMINALSERVICIOS"])
                {
                    auxPar.Value = oCCAJANuevo.ITERMINALSERVICIOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMEROTERMINALBANCOMER", FbDbType.VarChar);
                if (!(bool)oCCAJANuevo.isnull["INUMEROTERMINALBANCOMER"])
                {
                    auxPar.Value = oCCAJANuevo.INUMEROTERMINALBANCOMER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@NOMBRECERTIFICADOBANCOMER", FbDbType.VarChar);
                if (!(bool)oCCAJANuevo.isnull["INOMBRECERTIFICADOBANCOMER"])
                {
                    auxPar.Value = oCCAJANuevo.INOMBRECERTIFICADOBANCOMER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@AFILIACIONBANCOMER", FbDbType.VarChar);
                if (!(bool)oCCAJANuevo.isnull["IAFILIACIONBANCOMER"])
                {
                    auxPar.Value = oCCAJANuevo.IAFILIACIONBANCOMER;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IMPRESORACOMANDA", FbDbType.VarChar);
                if (!(bool)oCCAJANuevo.isnull["IIMPRESORACOMANDA"])
                {
                    auxPar.Value = oCCAJANuevo.IIMPRESORACOMANDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCCAJAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCCAJAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  CAJA
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

DESCRIPCION=@DESCRIPCION,

NOMBREIMPRESORA = @NOMBREIMPRESORA,

TERMINAL = @TERMINAL,

TERMINALSERVICIOS = @TERMINALSERVICIOS,

NUMEROTERMINALBANCOMER = @NUMEROTERMINALBANCOMER,

NOMBRECERTIFICADOBANCOMER = @NOMBRECERTIFICADOBANCOMER,

AFILIACIONBANCOMER = @AFILIACIONBANCOMER,

IMPRESORACOMANDA = @IMPRESORACOMANDA

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


        
        public CCAJABE seleccionarCAJA(CCAJABE oCCAJA, FbTransaction st)
        {
            CCAJABE retorno = new CCAJABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CAJA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCCAJA.IID;
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

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["MEMO"] != System.DBNull.Value)
                    {
                        retorno.IMEMO = (string)(dr["MEMO"]);
                    }

                    if (dr["FECHACORTE"] != System.DBNull.Value)
                    {
                        retorno.IFECHACORTE = (DateTime)(dr["FECHACORTE"]);
                    }

                    if (dr["CORTEID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEID = (long)(dr["CORTEID"]);
                    }

                    if (dr["CAJEROID"] != System.DBNull.Value)
                    {
                        retorno.ICAJEROID = (long)(dr["CAJEROID"]);
                    }

                    if (dr["TURNOID"] != System.DBNull.Value)
                    {
                        retorno.ITURNOID = (long)(dr["TURNOID"]);
                    }

                    if (dr["NOMBREIMPRESORA"] != System.DBNull.Value)
                    {
                        retorno.INOMBREIMPRESORA = (string)(dr["NOMBREIMPRESORA"]);
                    }
                    if (dr["TERMINAL"] != System.DBNull.Value)
                    {
                        retorno.ITERMINAL = (string)(dr["TERMINAL"]);
                    }
                    if (dr["TERMINALSERVICIOS"] != System.DBNull.Value)
                    {
                        retorno.ITERMINALSERVICIOS = (string)(dr["TERMINALSERVICIOS"]);
                    }


                    if (dr["NUMEROTERMINALBANCOMER"] != System.DBNull.Value)
                    {
                        retorno.INUMEROTERMINALBANCOMER = (long)(dr["NUMEROTERMINALBANCOMER"]);
                    }

                    if (dr["NOMBRECERTIFICADOBANCOMER"] != System.DBNull.Value)
                    {
                        retorno.INOMBRECERTIFICADOBANCOMER = (string)(dr["NOMBRECERTIFICADOBANCOMER"]);
                    }

                    if(dr["AFILIACIONBANCOMER"] != System.DBNull.Value)
                    {
                        retorno.IAFILIACIONBANCOMER = (string)(dr["AFILIACIONBANCOMER"]);
                    }

                    if (dr["IMPRESORACOMANDA"] != System.DBNull.Value)
                    {
                        retorno.IIMPRESORACOMANDA = (string)(dr["IMPRESORACOMANDA"]);
                    }


                    //MLG TEST EMIDA retorno.ITERMINAL = "8658650";

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




        public CCAJABE seleccionarCAJAxCLAVE(CCAJABE oCCAJA, FbTransaction st)
        {
            CCAJABE retorno = new CCAJABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from CAJA where CLAVE = @CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCCAJA.ICLAVE;
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

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["MEMO"] != System.DBNull.Value)
                    {
                        retorno.IMEMO = (string)(dr["MEMO"]);
                    }

                    if (dr["FECHACORTE"] != System.DBNull.Value)
                    {
                        retorno.IFECHACORTE = (DateTime)(dr["FECHACORTE"]);
                    }

                    if (dr["CORTEID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEID = (long)(dr["CORTEID"]);
                    }

                    if (dr["CAJEROID"] != System.DBNull.Value)
                    {
                        retorno.ICAJEROID = (long)(dr["CAJEROID"]);
                    }

                    if (dr["TURNOID"] != System.DBNull.Value)
                    {
                        retorno.ITURNOID = (long)(dr["TURNOID"]);
                    }

                    if (dr["NOMBREIMPRESORA"] != System.DBNull.Value)
                    {
                        retorno.INOMBREIMPRESORA = (string)(dr["NOMBREIMPRESORA"]);
                    }

                    if (dr["TERMINAL"] != System.DBNull.Value)
                    {
                        retorno.ITERMINAL = (string)(dr["TERMINAL"]);
                    }
                    if (dr["TERMINALSERVICIOS"] != System.DBNull.Value)
                    {
                        retorno.ITERMINALSERVICIOS = (string)(dr["TERMINALSERVICIOS"]);
                    }


                    if (dr["NUMEROTERMINALBANCOMER"] != System.DBNull.Value)
                    {
                        retorno.INUMEROTERMINALBANCOMER = (long)(dr["NUMEROTERMINALBANCOMER"]);
                    }

                    if (dr["NOMBRECERTIFICADOBANCOMER"] != System.DBNull.Value)
                    {
                        retorno.INOMBRECERTIFICADOBANCOMER = (string)(dr["NOMBRECERTIFICADOBANCOMER"]);
                    }

                    if (dr["AFILIACIONBANCOMER"] != System.DBNull.Value)
                    {
                        retorno.IAFILIACIONBANCOMER = (string)(dr["AFILIACIONBANCOMER"]);
                    }


                    if (dr["IMPRESORACOMANDA"] != System.DBNull.Value)
                    {
                        retorno.IIMPRESORACOMANDA = (string)(dr["IMPRESORACOMANDA"]);
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








        public DataSet enlistarCAJA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CAJA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoCAJA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_CAJA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteCAJA(CCAJABE oCCAJA, FbTransaction st)
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
                auxPar.Value = oCCAJA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from CAJA where

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




        public CCAJABE AgregarCAJA(CCAJABE oCCAJA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCAJA(oCCAJA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El CAJA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarCAJAD(oCCAJA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarCAJA(CCAJABE oCCAJA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCAJA(oCCAJA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CAJA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarCAJAD(oCCAJA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarCAJA(CCAJABE oCCAJANuevo, CCAJABE oCCAJAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteCAJA(oCCAJAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El CAJA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarCAJAD(oCCAJANuevo, oCCAJAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public string ObtenerNombreTurnoDeCaja(long lCajaId, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            string retorno = "";
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = lCajaId;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select turno.nombre as NOMBRETURNO from caja left join turno on caja.turnoid = turno.id
                                        where caja.id = @CAJAID;";
                

                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {

                    if (dr["NOMBRETURNO"] != System.DBNull.Value)
                    {
                        retorno = (string)(dr["NOMBRETURNO"]);
                    }
                }
                else
                {
                    retorno = "--";
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return  "--";
            }
        }





        public CCAJAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
