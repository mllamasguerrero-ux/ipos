
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



    public class CDESCLINEAPERSD
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
        public CDESCLINEAPERSBE AgregarDESCLINEAPERSD(CDESCLINEAPERSBE oCDESCLINEAPERS, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCDESCLINEAPERS.isnull["IACTIVO"])
                {
                    auxPar.Value = oCDESCLINEAPERS.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCDESCLINEAPERS.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCDESCLINEAPERS.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LINEAID", FbDbType.BigInt);
                if (!(bool)oCDESCLINEAPERS.isnull["ILINEAID"])
                {
                    auxPar.Value = oCDESCLINEAPERS.ILINEAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCUENTO", FbDbType.Numeric);
                if (!(bool)oCDESCLINEAPERS.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCDESCLINEAPERS.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO DESCLINEAPERS
      (
    

ACTIVO,

PERSONAID,

LINEAID,

DESCUENTO
         )

Values (

@ACTIVO,

@PERSONAID,

@LINEAID,

@DESCUENTO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCDESCLINEAPERS;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarDESCLINEAPERSD(CDESCLINEAPERSBE oCDESCLINEAPERS, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDESCLINEAPERS.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from DESCLINEAPERS
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
        public bool CambiarDESCLINEAPERSD(CDESCLINEAPERSBE oCDESCLINEAPERSNuevo, CDESCLINEAPERSBE oCDESCLINEAPERSAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCDESCLINEAPERSNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCDESCLINEAPERSNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCDESCLINEAPERSNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCDESCLINEAPERSNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCDESCLINEAPERSNuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCDESCLINEAPERSNuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LINEAID", FbDbType.BigInt);
                if (!(bool)oCDESCLINEAPERSNuevo.isnull["ILINEAID"])
                {
                    auxPar.Value = oCDESCLINEAPERSNuevo.ILINEAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCUENTO", FbDbType.Numeric);
                if (!(bool)oCDESCLINEAPERSNuevo.isnull["IDESCUENTO"])
                {
                    auxPar.Value = oCDESCLINEAPERSNuevo.IDESCUENTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCDESCLINEAPERSAnterior.isnull["IID"])
                {
                    auxPar.Value = oCDESCLINEAPERSAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  DESCLINEAPERS
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

PERSONAID=@PERSONAID,

LINEAID=@LINEAID,

DESCUENTO=@DESCUENTO
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
        public CDESCLINEAPERSBE seleccionarDESCLINEAPERS(CDESCLINEAPERSBE oCDESCLINEAPERS, FbTransaction st)
        {




            CDESCLINEAPERSBE retorno = new CDESCLINEAPERSBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DESCLINEAPERS where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCDESCLINEAPERS.IID;
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

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["LINEAID"] != System.DBNull.Value)
                    {
                        retorno.ILINEAID = (long)(dr["LINEAID"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
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
        public DataSet enlistarDESCLINEAPERS()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DESCLINEAPERS_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoDESCLINEAPERS()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_DESCLINEAPERS_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteDESCLINEAPERS(CDESCLINEAPERSBE oCDESCLINEAPERS, FbTransaction st)
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
                auxPar.Value = oCDESCLINEAPERS.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from DESCLINEAPERS where

  ID=@ID  
  );";






                //FbDataReader dr;
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




        public CDESCLINEAPERSBE AgregarDESCLINEAPERS(CDESCLINEAPERSBE oCDESCLINEAPERS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDESCLINEAPERS(oCDESCLINEAPERS, st);
                if (iRes == 1)
                {
                    this.IComentario = "El DESCLINEAPERS ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarDESCLINEAPERSD(oCDESCLINEAPERS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarDESCLINEAPERS(CDESCLINEAPERSBE oCDESCLINEAPERS, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDESCLINEAPERS(oCDESCLINEAPERS, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DESCLINEAPERS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarDESCLINEAPERSD(oCDESCLINEAPERS, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarDESCLINEAPERS(CDESCLINEAPERSBE oCDESCLINEAPERSNuevo, CDESCLINEAPERSBE oCDESCLINEAPERSAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteDESCLINEAPERS(oCDESCLINEAPERSAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El DESCLINEAPERS no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarDESCLINEAPERSD(oCDESCLINEAPERSNuevo, oCDESCLINEAPERSAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }

        public CDESCLINEAPERSBE seleccionarDESCLINEAPERSXPersonaYLinea(CDESCLINEAPERSBE oCLINEAPERSONA, FbTransaction st)
        {




            CDESCLINEAPERSBE retorno = new CDESCLINEAPERSBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from DESCLINEAPERS where PERSONAID=@PERSONAID AND LINEAID = @LINEAID  ";


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = oCLINEAPERSONA.IPERSONAID;
                parts.Add(auxPar);



                auxPar = new FbParameter("@LINEAID", FbDbType.BigInt);
                auxPar.Value = oCLINEAPERSONA.ILINEAID;
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

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["LINEAID"] != System.DBNull.Value)
                    {
                        retorno.ILINEAID = (long)(dr["LINEAID"]);
                    }

                    if (dr["DESCUENTO"] != System.DBNull.Value)
                    {
                        retorno.IDESCUENTO = (decimal)(dr["DESCUENTO"]);
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



        public CDESCLINEAPERSD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
