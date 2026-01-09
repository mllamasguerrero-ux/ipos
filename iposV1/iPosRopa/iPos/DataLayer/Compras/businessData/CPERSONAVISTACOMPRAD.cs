

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
    


    public class CPERSONAVISTACOMPRAD
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

        
        public CPERSONAVISTACOMPRABE AgregarPERSONAVISTACOMPRAD(CPERSONAVISTACOMPRABE oCPERSONAVISTACOMPRA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                

                


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPERSONAVISTACOMPRA.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCPERSONAVISTACOMPRA.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ULTIMAVISTA", FbDbType.TimeStamp);
                if (!(bool)oCPERSONAVISTACOMPRA.isnull["IULTIMAVISTA"])
                {
                    auxPar.Value = oCPERSONAVISTACOMPRA.IULTIMAVISTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
        INSERT INTO PERSONAVISTACOMPRA
      (
    

PERSONAID,

ULTIMAVISTA
         )

Values (

@PERSONAID,

@ULTIMAVISTA
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPERSONAVISTACOMPRA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        
        public bool BorrarPERSONAVISTACOMPRAD(CPERSONAVISTACOMPRABE oCPERSONAVISTACOMPRA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPERSONAVISTACOMPRA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PERSONAVISTACOMPRA
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

        
        public bool CambiarPERSONAVISTACOMPRAD(CPERSONAVISTACOMPRABE oCPERSONAVISTACOMPRANuevo, CPERSONAVISTACOMPRABE oCPERSONAVISTACOMPRAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                

                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPERSONAVISTACOMPRANuevo.isnull["IPERSONAID"])
                {
                    auxPar.Value = oCPERSONAVISTACOMPRANuevo.IPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ULTIMAVISTA", FbDbType.TimeStamp);
                if (!(bool)oCPERSONAVISTACOMPRANuevo.isnull["IULTIMAVISTA"])
                {
                    auxPar.Value = oCPERSONAVISTACOMPRANuevo.IULTIMAVISTA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPERSONAVISTACOMPRAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPERSONAVISTACOMPRAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PERSONAVISTACOMPRA
  set

PERSONAID=@PERSONAID,
ULTIMAVISTA = @ULTIMAVISTA
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
        
        public CPERSONAVISTACOMPRABE seleccionarPERSONAVISTACOMPRA(CPERSONAVISTACOMPRABE oCPERSONAVISTACOMPRA, FbTransaction st)
        {




            CPERSONAVISTACOMPRABE retorno = new CPERSONAVISTACOMPRABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PERSONAVISTACOMPRA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPERSONAVISTACOMPRA.IID;
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

                    if (dr["ULTIMAVISTA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMAVISTA = (DateTime)(dr["ULTIMAVISTA"]);
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






        public CPERSONAVISTACOMPRABE seleccionarPERSONAVISTACOMPRAxPERSONAID(CPERSONAVISTACOMPRABE oCPERSONAVISTACOMPRA, FbTransaction st)
        {




            CPERSONAVISTACOMPRABE retorno = new CPERSONAVISTACOMPRABE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PERSONAVISTACOMPRA where PERSONAID=@PERSONAID  ";


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = oCPERSONAVISTACOMPRA.IPERSONAID;
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

                    if (dr["ULTIMAVISTA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMAVISTA = (DateTime)(dr["ULTIMAVISTA"]);
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



        public DataSet enlistarPERSONAVISTACOMPRA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERSONAVISTACOMPRA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        
        public DataSet enlistarCortoPERSONAVISTACOMPRA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERSONAVISTACOMPRA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        
        public int ExistePERSONAVISTACOMPRA(CPERSONAVISTACOMPRABE oCPERSONAVISTACOMPRA, FbTransaction st)
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
                auxPar.Value = oCPERSONAVISTACOMPRA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PERSONAVISTACOMPRA where

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




        public CPERSONAVISTACOMPRABE AgregarPERSONAVISTACOMPRA(CPERSONAVISTACOMPRABE oCPERSONAVISTACOMPRA, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONAVISTACOMPRA(oCPERSONAVISTACOMPRA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PERSONAVISTACOMPRA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPERSONAVISTACOMPRAD(oCPERSONAVISTACOMPRA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPERSONAVISTACOMPRA(CPERSONAVISTACOMPRABE oCPERSONAVISTACOMPRA, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONAVISTACOMPRA(oCPERSONAVISTACOMPRA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERSONAVISTACOMPRA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPERSONAVISTACOMPRAD(oCPERSONAVISTACOMPRA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPERSONAVISTACOMPRA(CPERSONAVISTACOMPRABE oCPERSONAVISTACOMPRANuevo, CPERSONAVISTACOMPRABE oCPERSONAVISTACOMPRAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONAVISTACOMPRA(oCPERSONAVISTACOMPRAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERSONAVISTACOMPRA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPERSONAVISTACOMPRAD(oCPERSONAVISTACOMPRANuevo, oCPERSONAVISTACOMPRAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public int CuentaComprasRecientes(DateTime fechaMinima , FbTransaction st)
        {
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@FECHAMINIMA", FbDbType.Date);
                auxPar.Value = fechaMinima;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"
select count(*) CUENTA
from
(

   select producto.id
   from
   docto
   inner join movto on movto.doctoid = docto.id
   inner join producto on producto.id = movto.productoid

   where
     docto.tipodoctoid in (11,41) and
     docto.fecha >= @FECHAMINIMA
     group by producto.id


   union

   select producto.id
   from
   producto
   where
    cast(producto.creado as date) >= @FECHAMINIMA

)
";






                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);


                retorno = 0;
                if (dr.Read())
                {

                    if (dr["CUENTA"] != System.DBNull.Value)
                    {
                       retorno  = (int)(dr["CUENTA"]);
                    }
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



        public int CuentaComprasDespuesUltimoAcceso(DateTime fechaMinima, FbTransaction st)
        {
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@FECHAMINIMA", FbDbType.TimeStamp);
                auxPar.Value = fechaMinima;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"
select count(*) CUENTA
from
(

   select producto.id
   from
   docto
   inner join movto on movto.doctoid = docto.id
   inner join producto on producto.id = movto.productoid

   where
     docto.tipodoctoid in (11,41) and
     (docto.fechahora >= @FECHAMINIMA )
     group by producto.id


   union

   select producto.id
   from
   producto
   where
    (producto.creado >= @FECHAMINIMA  )

)
";






                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);


                retorno = 0;
                if (dr.Read())
                {

                    if (dr["CUENTA"] != System.DBNull.Value)
                    {
                        retorno = (int)(dr["CUENTA"]);
                    }
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



        public CPERSONAVISTACOMPRAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
