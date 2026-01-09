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


    public class CDOCTOVISITAD
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

        public CDOCTOVISITABE AgregarDOCTOVISITAD(CDOCTOVISITABE oCDOCTOVISITA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCDOCTOVISITA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCDOCTOVISITA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOVISITA.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCDOCTOVISITA.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                if (!(bool)oCDOCTOVISITA.isnull["ICAJAID"])
                {
                    auxPar.Value = oCDOCTOVISITA.ICAJAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAHORA", FbDbType.TimeStamp);
                if (!(bool)oCDOCTOVISITA.isnull["IFECHAHORA"])
                {
                    auxPar.Value = oCDOCTOVISITA.IFECHAHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOVISITA.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCDOCTOVISITA.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO DOCTOVISITA
      (

ACTIVO,

DOCTOID,

CAJAID,

FECHAHORA,

USUARIOID
         )

Values (

@ACTIVO,

@DOCTOID,

@CAJAID,

@FECHAHORA,

@USUARIOID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return oCDOCTOVISITA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public bool BorrarDOCTOVISITAD(CDOCTOVISITABE oCDOCTOVISITA, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOCTOVISITA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from DOCTOVISITA
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

        public bool CambiarDOCTOVISITAD(CDOCTOVISITABE oCDOCTOVISITANuevo, CDOCTOVISITABE oCDOCTOVISITAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCDOCTOVISITANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCDOCTOVISITANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOVISITANuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCDOCTOVISITANuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                if (!(bool)oCDOCTOVISITANuevo.isnull["ICAJAID"])
                {
                    auxPar.Value = oCDOCTOVISITANuevo.ICAJAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAHORA", FbDbType.TimeStamp);
                if (!(bool)oCDOCTOVISITANuevo.isnull["IFECHAHORA"])
                {
                    auxPar.Value = oCDOCTOVISITANuevo.IFECHAHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@USUARIOID", FbDbType.BigInt);
                if (!(bool)oCDOCTOVISITANuevo.isnull["IUSUARIOID"])
                {
                    auxPar.Value = oCDOCTOVISITANuevo.IUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDOCTOVISITAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDOCTOVISITAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DOCTOVISITA
  set

ACTIVO=@ACTIVO,

DOCTOID=@DOCTOID,

CAJAID=@CAJAID,

FECHAHORA = @FECHAHORA,

USUARIOID=@USUARIOID

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



        public CDOCTOVISITABE seleccionarDOCTOVISITA(CDOCTOVISITABE oCDOCTOVISITA, FbTransaction st)
        {

            CDOCTOVISITABE retorno = new CDOCTOVISITABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DOCTOVISITA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDOCTOVISITA.IID;
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

                    if (dr["CAJAID"] != System.DBNull.Value)
                    {
                        retorno.ICAJAID = (long)(dr["CAJAID"]);
                    }

                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (DateTime)(dr["FECHAHORA"]);
                    }

                    if (dr["USUARIOID"] != System.DBNull.Value)
                    {
                        retorno.IUSUARIOID = (long)(dr["USUARIOID"]);
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

        public DataSet enlistarDOCTOVISITA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DOCTOVISITA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }

        public DataSet enlistarCortoDOCTOVISITA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DOCTOVISITA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }

        public int ExisteDOCTOVISITA(CDOCTOVISITABE oCDOCTOVISITA, FbTransaction st)
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
                auxPar.Value = oCDOCTOVISITA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from DOCTOVISITA where

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




        public CDOCTOVISITABE AgregarDOCTOVISITA(CDOCTOVISITABE oCDOCTOVISITA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTOVISITA(oCDOCTOVISITA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El DOCTOVISITA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarDOCTOVISITAD(oCDOCTOVISITA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarDOCTOVISITA(CDOCTOVISITABE oCDOCTOVISITA, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTOVISITA(oCDOCTOVISITA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DOCTOVISITA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarDOCTOVISITAD(oCDOCTOVISITA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarDOCTOVISITA(CDOCTOVISITABE oCDOCTOVISITANuevo, CDOCTOVISITABE oCDOCTOVISITAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDOCTOVISITA(oCDOCTOVISITAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DOCTOVISITA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarDOCTOVISITAD(oCDOCTOVISITANuevo, oCDOCTOVISITAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }

        public CDOCTOVISITABE SeleccionarXDoctoCaja_DespuesFechaHora(long doctoId, 
                                                           long cajaId, 
                                                           DateTime fechaHora, 
                                                           FbTransaction trans)
        {
            CDOCTOVISITABE retorno = new CDOCTOVISITABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"SELECT * FROM DOCTOVISITA WHERE DOCTOID=@DOCTOID AND CAJAID = @CAJAID AND FECHAHORA > @FECHAHORA";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = cajaId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAHORA", FbDbType.TimeStamp);
                auxPar.Value = fechaHora;
                parts.Add(auxPar);


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (trans == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(trans, CommandType.Text, CmdTxt, arParms);


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

                    if (dr["CAJAID"] != System.DBNull.Value)
                    {
                        retorno.ICAJAID = (long)(dr["CAJAID"]);
                    }

                    if (dr["FECHAHORA"] != System.DBNull.Value)
                    {
                        retorno.IFECHAHORA = (DateTime)(dr["FECHAHORA"]);
                    }

                    if (dr["USUARIOID"] != System.DBNull.Value)
                    {
                        retorno.IUSUARIOID = (long)(dr["USUARIOID"]);
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

        public int CuentaXDocto_NoCaja_DespuesFechaHora(long doctoId,
                                                        long cajaId,
                                                        DateTime fechaHora,
                                                        FbTransaction trans)
        {
            FbDataReader dr = null;

            FbConnection pcn = null;

            int retorno = 0;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"SELECT COUNT(*) AS CUENTA FROM DOCTOVISITA WHERE DOCTOID=@DOCTOID AND CAJAID <> @CAJAID AND FECHAHORA > @FECHAHORA";


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = cajaId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAHORA", FbDbType.TimeStamp);
                auxPar.Value = fechaHora;
                parts.Add(auxPar);


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (trans == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(trans, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["CUENTA"] != System.DBNull.Value)
                    {
                        retorno = (int)(dr["CUENTA"]);
                    }
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


        public bool BorrarXDoctoCaja(long doctoId, long cajaId, FbTransaction trans)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = cajaId;
                parts.Add(auxPar);

                string commandText = @"Delete from DOCTOVISITA where DOCTOID=@DOCTOID AND CAJAID = @CAJAID;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (trans == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, commandText, arParms);


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool BorrarXCaja_AntesFechaHora(long cajaId, DateTime fechaHora, FbTransaction trans)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = cajaId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAHORA", FbDbType.TimeStamp);
                auxPar.Value = fechaHora;
                parts.Add(auxPar);

                string commandText = @"Delete from DOCTOVISITA where CAJAID = @CAJAID AND FECHAHORA < @FECHAHORA;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (trans == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, commandText, arParms);


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool BorrarXDocto(long doctoId, FbTransaction trans)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = doctoId;
                parts.Add(auxPar);

                string commandText = @"Delete from DOCTOVISITA where DOCTOID = @DOCTOID;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (trans == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, commandText, arParms);


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public CDOCTOVISITAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
