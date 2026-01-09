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


    public class CEMIDACOMISIOND
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


        public CEMIDACOMISIONBE AgregarEMIDACOMISIOND(CEMIDACOMISIONBE oCEMIDACOMISION, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCEMIDACOMISION.isnull["IACTIVO"])
                {
                    auxPar.Value = oCEMIDACOMISION.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCEMIDACOMISION.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCEMIDACOMISION.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCEMIDACOMISION.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCEMIDACOMISION.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VERSIONEMIDA", FbDbType.VarChar);
                if (!(bool)oCEMIDACOMISION.isnull["IVERSIONEMIDA"])
                {
                    auxPar.Value = oCEMIDACOMISION.IVERSIONEMIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESPONSECODE", FbDbType.VarChar);
                if (!(bool)oCEMIDACOMISION.isnull["IRESPONSECODE"])
                {
                    auxPar.Value = oCEMIDACOMISION.IRESPONSECODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTID", FbDbType.VarChar);
                if (!(bool)oCEMIDACOMISION.isnull["IPRODUCTID"])
                {
                    auxPar.Value = oCEMIDACOMISION.IPRODUCTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTDESCRIPTION", FbDbType.VarChar);
                if (!(bool)oCEMIDACOMISION.isnull["IPRODUCTDESCRIPTION"])
                {
                    auxPar.Value = oCEMIDACOMISION.IPRODUCTDESCRIPTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTUFEE", FbDbType.VarChar);
                if (!(bool)oCEMIDACOMISION.isnull["IPRODUCTUFEE"])
                {
                    auxPar.Value = oCEMIDACOMISION.IPRODUCTUFEE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO EMIDACOMISION
      (
    

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

VERSIONEMIDA,

RESPONSECODE,

PRODUCTID,

PRODUCTDESCRIPTION,

PRODUCTUFEE
         )

Values (


@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@VERSIONEMIDA,

@RESPONSECODE,

@PRODUCTID,

@PRODUCTDESCRIPTION,

@PRODUCTUFEE
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCEMIDACOMISION;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarEMIDACOMISIOND(CEMIDACOMISIONBE oCEMIDACOMISION, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCEMIDACOMISION.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from EMIDACOMISION
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


        public bool CambiarEMIDACOMISIOND(CEMIDACOMISIONBE oCEMIDACOMISIONNuevo, CEMIDACOMISIONBE oCEMIDACOMISIONAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCEMIDACOMISIONNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCEMIDACOMISIONNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCEMIDACOMISIONNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCEMIDACOMISIONNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VERSIONEMIDA", FbDbType.VarChar);
                if (!(bool)oCEMIDACOMISIONNuevo.isnull["IVERSIONEMIDA"])
                {
                    auxPar.Value = oCEMIDACOMISIONNuevo.IVERSIONEMIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RESPONSECODE", FbDbType.VarChar);
                if (!(bool)oCEMIDACOMISIONNuevo.isnull["IRESPONSECODE"])
                {
                    auxPar.Value = oCEMIDACOMISIONNuevo.IRESPONSECODE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTID", FbDbType.VarChar);
                if (!(bool)oCEMIDACOMISIONNuevo.isnull["IPRODUCTID"])
                {
                    auxPar.Value = oCEMIDACOMISIONNuevo.IPRODUCTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTDESCRIPTION", FbDbType.VarChar);
                if (!(bool)oCEMIDACOMISIONNuevo.isnull["IPRODUCTDESCRIPTION"])
                {
                    auxPar.Value = oCEMIDACOMISIONNuevo.IPRODUCTDESCRIPTION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTUFEE", FbDbType.VarChar);
                if (!(bool)oCEMIDACOMISIONNuevo.isnull["IPRODUCTUFEE"])
                {
                    auxPar.Value = oCEMIDACOMISIONNuevo.IPRODUCTUFEE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCEMIDACOMISIONAnterior.isnull["IID"])
                {
                    auxPar.Value = oCEMIDACOMISIONAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  EMIDACOMISION
  set


ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

VERSIONEMIDA=@VERSIONEMIDA,

RESPONSECODE=@RESPONSECODE,

PRODUCTID=@PRODUCTID,

PRODUCTDESCRIPTION=@PRODUCTDESCRIPTION,

PRODUCTUFEE=@PRODUCTUFEE
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


        public CEMIDACOMISIONBE seleccionarEMIDACOMISION(CEMIDACOMISIONBE oCEMIDACOMISION, FbTransaction st)
        {




            CEMIDACOMISIONBE retorno = new CEMIDACOMISIONBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from EMIDACOMISION where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCEMIDACOMISION.IID;
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

                    if (dr["VERSIONEMIDA"] != System.DBNull.Value)
                    {
                        retorno.IVERSIONEMIDA = (string)(dr["VERSIONEMIDA"]);
                    }

                    if (dr["RESPONSECODE"] != System.DBNull.Value)
                    {
                        retorno.IRESPONSECODE = (string)(dr["RESPONSECODE"]);
                    }

                    if (dr["PRODUCTID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTID = (string)(dr["PRODUCTID"]);
                    }

                    if (dr["PRODUCTDESCRIPTION"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTDESCRIPTION = (string)(dr["PRODUCTDESCRIPTION"]);
                    }

                    if (dr["PRODUCTUFEE"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTUFEE = (string)(dr["PRODUCTUFEE"]);
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





        public CEMIDACOMISIONBE seleccionarEMIDACOMISIONxEMIDAPRODUCTID(CEMIDACOMISIONBE oCEMIDACOMISION, FbTransaction st)
        {




            CEMIDACOMISIONBE retorno = new CEMIDACOMISIONBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from EMIDACOMISION where PRODUCTID=@PRODUCTID";



                auxPar = new FbParameter("@PRODUCTID", FbDbType.VarChar);
                auxPar.Value = oCEMIDACOMISION.IPRODUCTID;
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

                    if (dr["VERSIONEMIDA"] != System.DBNull.Value)
                    {
                        retorno.IVERSIONEMIDA = (string)(dr["VERSIONEMIDA"]);
                    }

                    if (dr["RESPONSECODE"] != System.DBNull.Value)
                    {
                        retorno.IRESPONSECODE = (string)(dr["RESPONSECODE"]);
                    }

                    if (dr["PRODUCTID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTID = (string)(dr["PRODUCTID"]);
                    }

                    if (dr["PRODUCTDESCRIPTION"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTDESCRIPTION = (string)(dr["PRODUCTDESCRIPTION"]);
                    }

                    if (dr["PRODUCTUFEE"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTUFEE = (string)(dr["PRODUCTUFEE"]);
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







        public DataSet enlistarEMIDACOMISION()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EMIDACOMISION_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoEMIDACOMISION()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_EMIDACOMISION_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        public int ExisteEMIDACOMISION(CEMIDACOMISIONBE oCEMIDACOMISION, FbTransaction st)
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
                auxPar.Value = oCEMIDACOMISION.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from EMIDACOMISION where

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




        public CEMIDACOMISIONBE AgregarEMIDACOMISION(CEMIDACOMISIONBE oCEMIDACOMISION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMIDACOMISION(oCEMIDACOMISION, st);
                if (iRes == 1)
                {
                    this.IComentario = "El EMIDACOMISION ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarEMIDACOMISIOND(oCEMIDACOMISION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarEMIDACOMISION(CEMIDACOMISIONBE oCEMIDACOMISION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMIDACOMISION(oCEMIDACOMISION, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EMIDACOMISION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarEMIDACOMISIOND(oCEMIDACOMISION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarEMIDACOMISION(CEMIDACOMISIONBE oCEMIDACOMISIONNuevo, CEMIDACOMISIONBE oCEMIDACOMISIONAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteEMIDACOMISION(oCEMIDACOMISIONAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El EMIDACOMISION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarEMIDACOMISIOND(oCEMIDACOMISIONNuevo, oCEMIDACOMISIONAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }



        public bool DesactivarTodosEMIDACOMISIOND(FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;






                string commandText = @" update EMIDACOMISION SET ACTIVO = 'N';";

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



        public CEMIDACOMISIOND()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
