

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
    


    public class CPERSONAFIGURAD
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

        
        public CPERSONAFIGURABE AgregarPERSONAFIGURAD(CPERSONAFIGURABE oCPERSONAFIGURA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPERSONAFIGURA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPERSONAFIGURA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPERSONAFIGURA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPERSONAFIGURA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPERSONAFIGURA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPERSONAFIGURA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPERSONAFIGURA.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCPERSONAFIGURA.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_FIGURATRANSPORTEID", FbDbType.BigInt);
                if (!(bool)oCPERSONAFIGURA.isnull["ISAT_FIGURATRANSPORTEID"])
                {
                    auxPar.Value = oCPERSONAFIGURA.ISAT_FIGURATRANSPORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMLICENCIA", FbDbType.VarChar);
                if (!(bool)oCPERSONAFIGURA.isnull["INUMLICENCIA"])
                {
                    auxPar.Value = oCPERSONAFIGURA.INUMLICENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMREGIDTRIB", FbDbType.VarChar);
                if (!(bool)oCPERSONAFIGURA.isnull["INUMREGIDTRIB"])
                {
                    auxPar.Value = oCPERSONAFIGURA.INUMREGIDTRIB;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESIDENCIAFISCAL", FbDbType.VarChar);
                if (!(bool)oCPERSONAFIGURA.isnull["IRESIDENCIAFISCAL"])
                {
                    auxPar.Value = oCPERSONAFIGURA.IRESIDENCIAFISCAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_PARTETRANSPORTEID", FbDbType.BigInt);
                if (!(bool)oCPERSONAFIGURA.isnull["ISAT_PARTETRANSPORTEID"])
                {
                    auxPar.Value = oCPERSONAFIGURA.ISAT_PARTETRANSPORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PERSONAFIGURA
      (

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

PERSONAID,

SAT_FIGURATRANSPORTEID,

NUMLICENCIA,

NUMREGIDTRIB,

RESIDENCIAFISCAL,

SAT_PARTETRANSPORTEID
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@PERSONAID,

@SAT_FIGURATRANSPORTEID,

@NUMLICENCIA,

@NUMREGIDTRIB,

@RESIDENCIAFISCAL,

@SAT_PARTETRANSPORTEID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPERSONAFIGURA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        
        public bool BorrarPERSONAFIGURAD(CPERSONAFIGURABE oCPERSONAFIGURA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPERSONAFIGURA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PERSONAFIGURA
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

        
        public bool CambiarPERSONAFIGURAD(CPERSONAFIGURABE oCPERSONAFIGURANuevo, CPERSONAFIGURABE oCPERSONAFIGURAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPERSONAFIGURANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPERSONAFIGURANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPERSONAFIGURANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPERSONAFIGURANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPERSONAFIGURANuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCPERSONAFIGURANuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_FIGURATRANSPORTEID", FbDbType.BigInt);
                if (!(bool)oCPERSONAFIGURANuevo.isnull["ISAT_FIGURATRANSPORTEID"])
                {
                    auxPar.Value = oCPERSONAFIGURANuevo.ISAT_FIGURATRANSPORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMLICENCIA", FbDbType.VarChar);
                if (!(bool)oCPERSONAFIGURANuevo.isnull["INUMLICENCIA"])
                {
                    auxPar.Value = oCPERSONAFIGURANuevo.INUMLICENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMREGIDTRIB", FbDbType.VarChar);
                if (!(bool)oCPERSONAFIGURANuevo.isnull["INUMREGIDTRIB"])
                {
                    auxPar.Value = oCPERSONAFIGURANuevo.INUMREGIDTRIB;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RESIDENCIAFISCAL", FbDbType.VarChar);
                if (!(bool)oCPERSONAFIGURANuevo.isnull["IRESIDENCIAFISCAL"])
                {
                    auxPar.Value = oCPERSONAFIGURANuevo.IRESIDENCIAFISCAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_PARTETRANSPORTEID", FbDbType.BigInt);
                if (!(bool)oCPERSONAFIGURANuevo.isnull["ISAT_PARTETRANSPORTEID"])
                {
                    auxPar.Value = oCPERSONAFIGURANuevo.ISAT_PARTETRANSPORTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPERSONAFIGURAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPERSONAFIGURAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PERSONAFIGURA
  set


ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

PERSONAID=@PERSONAID,

SAT_FIGURATRANSPORTEID=@SAT_FIGURATRANSPORTEID,

NUMLICENCIA=@NUMLICENCIA,

NUMREGIDTRIB=@NUMREGIDTRIB,

RESIDENCIAFISCAL=@RESIDENCIAFISCAL,

SAT_PARTETRANSPORTEID=@SAT_PARTETRANSPORTEID
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

        
        public CPERSONAFIGURABE seleccionarPERSONAFIGURA(CPERSONAFIGURABE oCPERSONAFIGURA, FbTransaction st)
        {




            CPERSONAFIGURABE retorno = new CPERSONAFIGURABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PERSONAFIGURA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPERSONAFIGURA.IID;
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

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["SAT_FIGURATRANSPORTEID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FIGURATRANSPORTEID = (long)(dr["SAT_FIGURATRANSPORTEID"]);
                    }

                    if (dr["NUMLICENCIA"] != System.DBNull.Value)
                    {
                        retorno.INUMLICENCIA = (string)(dr["NUMLICENCIA"]);
                    }

                    if (dr["NUMREGIDTRIB"] != System.DBNull.Value)
                    {
                        retorno.INUMREGIDTRIB = (string)(dr["NUMREGIDTRIB"]);
                    }

                    if (dr["RESIDENCIAFISCAL"] != System.DBNull.Value)
                    {
                        retorno.IRESIDENCIAFISCAL = (string)(dr["RESIDENCIAFISCAL"]);
                    }

                    if (dr["SAT_PARTETRANSPORTEID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PARTETRANSPORTEID = (long)(dr["SAT_PARTETRANSPORTEID"]);
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




        public CPERSONAFIGURABE seleccionarPERSONAFIGURAxPERSONA(CPERSONAFIGURABE personaFiguraBEAnt, FbTransaction st)
        {




            CPERSONAFIGURABE retorno = new CPERSONAFIGURABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select PERSONAFIGURA.* 
                                    from PERSONAFIGURA 
                                    where PERSONAfIGURA.PERSONAID = @PERSONAID ";


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = personaFiguraBEAnt.IPERSONAID;
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

                    if (dr["PERSONAID"] != System.DBNull.Value)
                    {
                        retorno.IPERSONAID = (long)(dr["PERSONAID"]);
                    }

                    if (dr["SAT_FIGURATRANSPORTEID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_FIGURATRANSPORTEID = (long)(dr["SAT_FIGURATRANSPORTEID"]);
                    }

                    if (dr["NUMLICENCIA"] != System.DBNull.Value)
                    {
                        retorno.INUMLICENCIA = (string)(dr["NUMLICENCIA"]);
                    }

                    if (dr["NUMREGIDTRIB"] != System.DBNull.Value)
                    {
                        retorno.INUMREGIDTRIB = (string)(dr["NUMREGIDTRIB"]);
                    }

                    if (dr["RESIDENCIAFISCAL"] != System.DBNull.Value)
                    {
                        retorno.IRESIDENCIAFISCAL = (string)(dr["RESIDENCIAFISCAL"]);
                    }

                    if (dr["SAT_PARTETRANSPORTEID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_PARTETRANSPORTEID = (long)(dr["SAT_PARTETRANSPORTEID"]);
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



        public DataSet enlistarPERSONAFIGURA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERSONAFIGURA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public DataSet enlistarCortoPERSONAFIGURA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERSONAFIGURA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        

        public int ExistePERSONAFIGURA(CPERSONAFIGURABE oCPERSONAFIGURA, FbTransaction st)
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
                auxPar.Value = oCPERSONAFIGURA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PERSONAFIGURA where

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




        public CPERSONAFIGURABE AgregarPERSONAFIGURA(CPERSONAFIGURABE oCPERSONAFIGURA, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONAFIGURA(oCPERSONAFIGURA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PERSONAFIGURA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPERSONAFIGURAD(oCPERSONAFIGURA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPERSONAFIGURA(CPERSONAFIGURABE oCPERSONAFIGURA, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONAFIGURA(oCPERSONAFIGURA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERSONAFIGURA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPERSONAFIGURAD(oCPERSONAFIGURA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPERSONAFIGURA(CPERSONAFIGURABE oCPERSONAFIGURANuevo, CPERSONAFIGURABE oCPERSONAFIGURAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONAFIGURA(oCPERSONAFIGURAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERSONAFIGURA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPERSONAFIGURAD(oCPERSONAFIGURANuevo, oCPERSONAFIGURAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPERSONAFIGURAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
