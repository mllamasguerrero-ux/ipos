

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


    public class CEXP_FILESD
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
        public CEXP_FILESBE AgregarEXP_FILESD(CEXP_FILESBE oCEXP_FILES, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                /*
                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCEXP_FILES.isnull["IID"])
                {
                    auxPar.Value = oCEXP_FILES.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);*/


                auxPar = new FbParameter("@TIPO", FbDbType.VarChar);
                if (!(bool)oCEXP_FILES.isnull["ITIPO"])
                {
                    auxPar.Value = oCEXP_FILES.ITIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCEXP_FILES.isnull["INOMBRE"])
                {
                    auxPar.Value = oCEXP_FILES.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ARCHIVOFTP", FbDbType.VarChar);
                if (!(bool)oCEXP_FILES.isnull["IARCHIVOFTP"])
                {
                    auxPar.Value = oCEXP_FILES.IARCHIVOFTP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCEXP_FILES.isnull["IFECHA"])
                {
                    auxPar.Value = oCEXP_FILES.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TURNOID", FbDbType.BigInt);
                if (!(bool)oCEXP_FILES.isnull["ITURNOID"])
                {
                    auxPar.Value = oCEXP_FILES.ITURNOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCEXP_FILES.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCEXP_FILES.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUS", FbDbType.Char);
                if (!(bool)oCEXP_FILES.isnull["IESTATUS"])
                {
                    auxPar.Value = oCEXP_FILES.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHASUBIDA", FbDbType.Date);
                if (!(bool)oCEXP_FILES.isnull["IFECHASUBIDA"])
                {
                    auxPar.Value = oCEXP_FILES.IFECHASUBIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HORASUBIDA", FbDbType.Time);
                if (!(bool)oCEXP_FILES.isnull["IHORASUBIDA"])
                {
                    auxPar.Value = oCEXP_FILES.IHORASUBIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCEXP_FILES.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCEXP_FILES.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOFOLIO", FbDbType.Integer);
                if (!(bool)oCEXP_FILES.isnull["IDOCTOFOLIO"])
                {
                    auxPar.Value = oCEXP_FILES.IDOCTOFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHATO", FbDbType.Date);
                if (!(bool)oCEXP_FILES.isnull["IFECHATO"])
                {
                    auxPar.Value = oCEXP_FILES.IFECHATO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOSERIE", FbDbType.VarChar);
                if (!(bool)oCEXP_FILES.isnull["IDOCTOSERIE"])
                {
                    auxPar.Value = oCEXP_FILES.IDOCTOSERIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                if (!(bool)oCEXP_FILES.isnull["ITIPODOCTOID"])
                {
                    auxPar.Value = oCEXP_FILES.ITIPODOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@IDNEW", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = "EXP_FILES_INSERT";
                /*@"
        INSERT INTO EXP_FILES
      (
    
ID,

TIPO,

NOMBRE,

ARCHIVOFTP,

FECHA,

TURNOID,

PERSONAID,

ESTATUS,

FECHASUBIDA,

HORASUBIDA,

DOCTOID,

DOCTOFOLIO,

FECHATO,

DOCTOSERIE,

TIPODOCTOID
         )

Values (

@ID,

@TIPO,

@NOMBRE,

@ARCHIVOFTP,

@FECHA,

@TURNOID,

@PERSONAID,

@ESTATUS,

@FECHASUBIDA,

@HORASUBIDA,

@DOCTOID,

@DOCTOFOLIO,

@FECHATO,

@DOCTOSERIE,

@TIPODOCTOID
)
RETURNING ID INTO @IDNEW
; ";*/

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    oCEXP_FILES.IID = (long)arParms[arParms.Length - 2].Value;
                }



                return oCEXP_FILES;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarEXP_FILESD(CEXP_FILESBE oCEXP_FILES, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCEXP_FILES.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from EXP_FILES
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
        public bool CambiarEXP_FILESD(CEXP_FILESBE oCEXP_FILESNuevo, CEXP_FILESBE oCEXP_FILESAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCEXP_FILESNuevo.isnull["IID"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPO", FbDbType.VarChar);
                if (!(bool)oCEXP_FILESNuevo.isnull["ITIPO"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.ITIPO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCEXP_FILESNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ARCHIVOFTP", FbDbType.VarChar);
                if (!(bool)oCEXP_FILESNuevo.isnull["IARCHIVOFTP"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.IARCHIVOFTP;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCEXP_FILESNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TURNOID", FbDbType.BigInt);
                if (!(bool)oCEXP_FILESNuevo.isnull["ITURNOID"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.ITURNOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCEXP_FILESNuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTATUS", FbDbType.Char);
                if (!(bool)oCEXP_FILESNuevo.isnull["IESTATUS"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.IESTATUS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHASUBIDA", FbDbType.Date);
                if (!(bool)oCEXP_FILESNuevo.isnull["IFECHASUBIDA"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.IFECHASUBIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@HORASUBIDA", FbDbType.Time);
                if (!(bool)oCEXP_FILESNuevo.isnull["IHORASUBIDA"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.IHORASUBIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                if (!(bool)oCEXP_FILESNuevo.isnull["IDOCTOID"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.IDOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOFOLIO", FbDbType.Integer);
                if (!(bool)oCEXP_FILESNuevo.isnull["IDOCTOFOLIO"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.IDOCTOFOLIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHATO", FbDbType.Date);
                if (!(bool)oCEXP_FILESNuevo.isnull["IFECHATO"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.IFECHATO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOSERIE", FbDbType.VarChar);
                if (!(bool)oCEXP_FILESNuevo.isnull["IDOCTOSERIE"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.IDOCTOSERIE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                if (!(bool)oCEXP_FILESNuevo.isnull["ITIPODOCTOID"])
                {
                    auxPar.Value = oCEXP_FILESNuevo.ITIPODOCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCEXP_FILESAnterior.isnull["IID"])
                {
                    auxPar.Value = oCEXP_FILESAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  EXP_FILES
  set

ID=@ID,

TIPO=@TIPO,

NOMBRE=@NOMBRE,

ARCHIVOFTP=@ARCHIVOFTP,

FECHA=@FECHA,

TURNOID=@TURNOID,

PERSONAID=@PERSONAID,

ESTATUS=@ESTATUS,

FECHASUBIDA=@FECHASUBIDA,

HORASUBIDA=@HORASUBIDA,

DOCTOID=@DOCTOID,

DOCTOFOLIO=@DOCTOFOLIO,

FECHATO = @FECHATO,

DOCTOSERIE = @DOCTOSERIE,

TIPODOCTOID = @TIPODOCTOID
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
        public CEXP_FILESBE seleccionarEXP_FILES(CEXP_FILESBE oCEXP_FILES, FbTransaction st)
        {




            CEXP_FILESBE retorno = new CEXP_FILESBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from EXP_FILES where ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCEXP_FILES.IID;
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

                    if (dr["TIPO"] != System.DBNull.Value)
                    {
                        retorno.ITIPO = (string)(dr["TIPO"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["ARCHIVOFTP"] != System.DBNull.Value)
                    {
                        retorno.IARCHIVOFTP = (string)(dr["ARCHIVOFTP"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["TURNOID"] != System.DBNull.Value)
                    {
                        retorno.ITURNOID = (long)(dr["TURNOID"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["ESTATUS"] != System.DBNull.Value)
                    {
                        retorno.IESTATUS = (string)(dr["ESTATUS"]);
                    }

                    if (dr["FECHASUBIDA"] != System.DBNull.Value)
                    {
                        retorno.IFECHASUBIDA = (DateTime)(dr["FECHASUBIDA"]);
                    }

                    if (dr["HORASUBIDA"] != System.DBNull.Value)
                    {
                        retorno.IHORASUBIDA = (TimeSpan)(dr["HORASUBIDA"]);
                    }

                    if (dr["DOCTOID"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOID = (long)(dr["DOCTOID"]);
                    }

                    if (dr["DOCTOFOLIO"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOFOLIO = int.Parse(dr["DOCTOFOLIO"].ToString());
                    }

                    if (dr["FECHATO"] != System.DBNull.Value)
                    {
                        retorno.IFECHATO = (DateTime)(dr["FECHATO"]);
                    }
                    if (dr["DOCTOSERIE"] != System.DBNull.Value)
                    {
                        retorno.IDOCTOSERIE = dr["DOCTOSSERIE"].ToString();
                    }

                    if (dr["TIPODOCTOID"] != System.DBNull.Value)
                    {
                        retorno.ITIPODOCTOID = (long)(dr["TIPODOCTOID"]);
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
        public DataSet enlistarEXP_FILES()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EXP_FILES_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoEXP_FILES()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EXP_FILES_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteEXP_FILES(CEXP_FILESBE oCEXP_FILES, FbTransaction st)
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
                auxPar.Value = oCEXP_FILES.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from EXP_FILES where

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


        public int ExisteEXP_FILESXTipoNombre(CEXP_FILESBE oCEXP_FILES, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@TIPO", FbDbType.VarChar);
                auxPar.Value = oCEXP_FILES.ITIPO;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                auxPar.Value = oCEXP_FILES.INOMBRE;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"
                                        select * from EXP_FILES where
                                        TIPO=@TIPO AND NOMBRE =@NOMBRE  ;";



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





        public bool UPDATE_EXP_FILES( FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            try
            {
                System.Collections.ArrayList parts = new ArrayList();

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"UPDATE_EXP_FILES;";

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




        public bool UPD_EXP_FILES_PED(DateTime dateFrom, DateTime dateTo, ref long exp_filesId, long pedido, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@FECHAFROM", FbDbType.Date);
                auxPar.Value = dateFrom;
                parts.Add(auxPar);

                /*auxPar = new FbParameter("@TURNOID", FbDbType.BigInt);
                auxPar.Value = (long)turnoIdFrom;
                parts.Add(auxPar);*/

                auxPar = new FbParameter("@FECHATO", FbDbType.Date);
                auxPar.Value = dateTo;
                parts.Add(auxPar);


                auxPar = new FbParameter("@UNSOLOARCHIVO", FbDbType.VarChar);
                auxPar.Value = "S";
                parts.Add(auxPar);


                auxPar = new FbParameter("@PEDIDO", FbDbType.BigInt);
                auxPar.Value = pedido;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EXP_FILESID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"UPD_EXP_FILES_PED";

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


                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    exp_filesId = (long)arParms[arParms.Length - 2].Value;
                }

                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }





        public bool UPD_EXP_FILES_TRA(int folio, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                auxPar.Value = (int) folio;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"UPD_EXP_FILES_TRA";

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





        public bool UPD_EXP_FILES_TRADEVO(int folio, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                auxPar.Value = (int)folio;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"UPD_EXP_FILES_TRADEVO";

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





        public bool UPD_EXP_FILES_PEDIDODEVO(int folio, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                auxPar.Value = (int)folio;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"UPD_EXP_FILES_PEDIDODEVO";

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




        public bool UPD_EXP_FILES_MATRIZPEDIDOS(int folio, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@FOLIO", FbDbType.Integer);
                auxPar.Value = (int)folio;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"UPD_EXP_FILES_MATRIZPEDIDOS";

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

        public CEXP_FILESBE AgregarEXP_FILES(CEXP_FILESBE oCEXP_FILES, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEXP_FILES(oCEXP_FILES, st);
                if (iRes == 1)
                {
                    this.IComentario = "El EXP_FILES ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarEXP_FILESD(oCEXP_FILES, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarEXP_FILES(CEXP_FILESBE oCEXP_FILES, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEXP_FILES(oCEXP_FILES, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EXP_FILES no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarEXP_FILESD(oCEXP_FILES, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarEXP_FILES(CEXP_FILESBE oCEXP_FILESNuevo, CEXP_FILESBE oCEXP_FILESAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEXP_FILES(oCEXP_FILESAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EXP_FILES no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarEXP_FILESD(oCEXP_FILESNuevo, oCEXP_FILESAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public CEXP_FILESBE GET_EXP_FILE_FROM_DR(FbDataReader dr )
        {

            CEXP_FILESBE retorno = new CEXP_FILESBE();
            if (dr["ID"] != System.DBNull.Value)
            {
                retorno.IID = (long)(dr["ID"]);
            }

            if (dr["TIPO"] != System.DBNull.Value)
            {
                retorno.ITIPO = (string)(dr["TIPO"]);
            }

            if (dr["NOMBRE"] != System.DBNull.Value)
            {
                retorno.INOMBRE = (string)(dr["NOMBRE"]);
            }

            if (dr["ARCHIVOFTP"] != System.DBNull.Value)
            {
                retorno.IARCHIVOFTP = (string)(dr["ARCHIVOFTP"]);
            }

            if (dr["FECHA"] != System.DBNull.Value)
            {
                retorno.IFECHA = (DateTime)(dr["FECHA"]);
            }

            if (dr["TURNOID"] != System.DBNull.Value)
            {
                retorno.ITURNOID = (long)(dr["TURNOID"]);
            }

            if (dr["PERSONAID"] != System.DBNull.Value)
            {
                retorno.IPERSONAID = (long)(dr["PERSONAID"]);
            }

            if (dr["ESTATUS"] != System.DBNull.Value)
            {
                retorno.IESTATUS = (string)(dr["ESTATUS"]);
            }

            if (dr["FECHASUBIDA"] != System.DBNull.Value)
            {
                retorno.IFECHASUBIDA = (DateTime)(dr["FECHASUBIDA"]);
            }

            if (dr["HORASUBIDA"] != System.DBNull.Value)
            {
                retorno.IHORASUBIDA = (TimeSpan)(dr["HORASUBIDA"]);
            }

            if (dr["DOCTOID"] != System.DBNull.Value)
            {
                retorno.IDOCTOID = (long)(dr["DOCTOID"]);
            }

            if (dr["DOCTOFOLIO"] != System.DBNull.Value)
            {
                retorno.IDOCTOFOLIO = int.Parse(dr["DOCTOFOLIO"].ToString());
            }

            if (dr["FECHATO"] != System.DBNull.Value)
            {
                retorno.IFECHATO = (DateTime)(dr["FECHATO"]);
            }

            if (dr["DOCTOSERIE"] != System.DBNull.Value)
            {
                retorno.IDOCTOSERIE = dr["DOCTOSERIE"].ToString();
            }
            if (dr["TIPODOCTOID"] != System.DBNull.Value)
            {
                retorno.ITIPODOCTOID = (long)(dr["TIPODOCTOID"]);
            }

            return retorno;
        }


        public CEXP_FILESD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
