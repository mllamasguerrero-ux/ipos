
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


    public class CMONEDEROMOVTOD
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
        public CMONEDEROMOVTOBE AgregarMONEDEROMOVTOD(CMONEDEROMOVTOBE oCMONEDEROMOVTO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCMONEDEROMOVTO.isnull["IID"])
                {
                    auxPar.Value = oCMONEDEROMOVTO.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMONEDEROMOVTO.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMONEDEROMOVTO.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONEDEROMOVTO.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMONEDEROMOVTO.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONEDEROMOVTO.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMONEDEROMOVTO.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONEDERO", FbDbType.BigInt);
                if (!(bool)oCMONEDEROMOVTO.isnull["IMONEDERO"])
                {
                    auxPar.Value = oCMONEDEROMOVTO.IMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPOMONEDEROMOVTOID", FbDbType.BigInt);
                if (!(bool)oCMONEDEROMOVTO.isnull["ITIPOMONEDEROMOVTOID"])
                {
                    auxPar.Value = oCMONEDEROMOVTO.ITIPOMONEDEROMOVTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCMONEDEROMOVTO.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCMONEDEROMOVTO.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTO", FbDbType.Numeric);
                if (!(bool)oCMONEDEROMOVTO.isnull["IMONTO"])
                {
                    auxPar.Value = oCMONEDEROMOVTO.IMONTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCMONEDEROMOVTO.isnull["IFECHA"])
                {
                    auxPar.Value = oCMONEDEROMOVTO.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CADUCIDAD", FbDbType.Integer);
                if (!(bool)oCMONEDEROMOVTO.isnull["ICADUCIDAD"])
                {
                    auxPar.Value = oCMONEDEROMOVTO.ICADUCIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONTOMONEDERO", FbDbType.Numeric);
                if (!(bool)oCMONEDEROMOVTO.isnull["IMONTOMONEDERO"])
                {
                    auxPar.Value = oCMONEDEROMOVTO.IMONTOMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIGENCIAMONEDERO", FbDbType.Date);
                if (!(bool)oCMONEDEROMOVTO.isnull["IVIGENCIAMONEDERO"])
                {
                    auxPar.Value = oCMONEDEROMOVTO.IVIGENCIAMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO MONEDEROMOVTO
      (
    
ID,

ACTIVO,

CREADO,

CREADOPOR_USERID,

MODIFICADO,

MODIFICADOPOR_USERID,

MONEDERO,

TIPOMONEDEROMOVTOID,

DOCTOID,

MONTO,

FECHA,

CADUCIDAD,

MONTOMONEDERO,

VIGENCIAMONEDERO
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@MONEDERO,

@TIPOMONEDEROMOVTOID,

@DOCTOID,

@MONTO,

@FECHA,

@CADUCIDAD,

@MONTOMONEDERO,

@VIGENCIAMONEDERO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCMONEDEROMOVTO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarMONEDEROMOVTOD(CMONEDEROMOVTOBE oCMONEDEROMOVTO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMONEDEROMOVTO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from MONEDEROMOVTO
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
        public bool CambiarMONEDEROMOVTOD(CMONEDEROMOVTOBE oCMONEDEROMOVTONuevo, CMONEDEROMOVTOBE oCMONEDEROMOVTOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCMONEDEROMOVTONuevo.isnull["IID"])
                {
                    auxPar.Value = oCMONEDEROMOVTONuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCMONEDEROMOVTONuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCMONEDEROMOVTONuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONEDEROMOVTONuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCMONEDEROMOVTONuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCMONEDEROMOVTONuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCMONEDEROMOVTONuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONEDERO", FbDbType.BigInt);
                if (!(bool)oCMONEDEROMOVTONuevo.isnull["IMONEDERO"])
                {
                    auxPar.Value = oCMONEDEROMOVTONuevo.IMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOMONEDEROMOVTOID", FbDbType.BigInt);
                if (!(bool)oCMONEDEROMOVTONuevo.isnull["ITIPOMONEDEROMOVTOID"])
                {
                    auxPar.Value = oCMONEDEROMOVTONuevo.ITIPOMONEDEROMOVTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCMONEDEROMOVTONuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCMONEDEROMOVTONuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTO", FbDbType.Numeric);
                if (!(bool)oCMONEDEROMOVTONuevo.isnull["IMONTO"])
                {
                    auxPar.Value = oCMONEDEROMOVTONuevo.IMONTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCMONEDEROMOVTONuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCMONEDEROMOVTONuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CADUCIDAD", FbDbType.Integer);
                if (!(bool)oCMONEDEROMOVTONuevo.isnull["ICADUCIDAD"])
                {
                    auxPar.Value = oCMONEDEROMOVTONuevo.ICADUCIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MONTOMONEDERO", FbDbType.Numeric);
                if (!(bool)oCMONEDEROMOVTONuevo.isnull["IMONTOMONEDERO"])
                {
                    auxPar.Value = oCMONEDEROMOVTONuevo.IMONTOMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VIGENCIAMONEDERO", FbDbType.Date);
                if (!(bool)oCMONEDEROMOVTONuevo.isnull["IVIGENCIAMONEDERO"])
                {
                    auxPar.Value = oCMONEDEROMOVTONuevo.IVIGENCIAMONEDERO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCMONEDEROMOVTOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCMONEDEROMOVTOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  MONEDEROMOVTO
  set

ID=@ID,

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

MONEDERO=@MONEDERO,

TIPOMONEDEROMOVTOID=@TIPOMONEDEROMOVTOID,

DOCTOID=@DOCTOID,

MONTO=@MONTO,

FECHA=@FECHA,

CADUCIDAD=@CADUCIDAD,

MONTOMONEDERO=@MONTOMONEDERO,

VIGENCIAMONEDERO=@VIGENCIAMONEDERO
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
        public CMONEDEROMOVTOBE seleccionarMONEDEROMOVTO(CMONEDEROMOVTOBE oCMONEDEROMOVTO, FbTransaction st)
        {




            CMONEDEROMOVTOBE retorno = new CMONEDEROMOVTOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from MONEDEROMOVTO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCMONEDEROMOVTO.IID;
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

                    if (dr["MONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IMONEDERO = (long)(dr["MONEDERO"]);
                    }

                    if (dr["TIPOMONEDEROMOVTOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOMONEDEROMOVTOID = (long)(dr["TIPOMONEDEROMOVTOID"]);
                    }

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["MONTO"] != System.DBNull.Value)
                    {
                        retorno.IMONTO = (decimal)(dr["MONTO"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["MONTOMONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IMONTOMONEDERO = (decimal)(dr["MONTOMONEDERO"]);
                    }

                    if (dr["VIGENCIAMONEDERO"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIAMONEDERO = (DateTime)(dr["VIGENCIAMONEDERO"]);
                    }

                    if (dr["CADUCIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICADUCIDAD = int.Parse(dr["CADUCIDAD"].ToString());
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
        public DataSet enlistarMONEDEROMOVTO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MONEDEROMOVTO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoMONEDEROMOVTO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_MONEDEROMOVTO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteMONEDEROMOVTO(CMONEDEROMOVTOBE oCMONEDEROMOVTO, FbTransaction st)
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
                auxPar.Value = oCMONEDEROMOVTO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from MONEDEROMOVTO where

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




        public CMONEDEROMOVTOBE AgregarMONEDEROMOVTO(CMONEDEROMOVTOBE oCMONEDEROMOVTO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMONEDEROMOVTO(oCMONEDEROMOVTO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El MONEDEROMOVTO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarMONEDEROMOVTOD(oCMONEDEROMOVTO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarMONEDEROMOVTO(CMONEDEROMOVTOBE oCMONEDEROMOVTO, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMONEDEROMOVTO(oCMONEDEROMOVTO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MONEDEROMOVTO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarMONEDEROMOVTOD(oCMONEDEROMOVTO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarMONEDEROMOVTO(CMONEDEROMOVTOBE oCMONEDEROMOVTONuevo, CMONEDEROMOVTOBE oCMONEDEROMOVTOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteMONEDEROMOVTO(oCMONEDEROMOVTOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El MONEDEROMOVTO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarMONEDEROMOVTOD(oCMONEDEROMOVTONuevo, oCMONEDEROMOVTOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }






        public CMONEDEROMOVTOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
