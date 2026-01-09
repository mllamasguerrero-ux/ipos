

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


    public class CPRODUCTOPROVEEDORD
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
        public CPRODUCTOPROVEEDORBE AgregarPRODUCTOPROVEEDORD(CPRODUCTOPROVEEDORBE oCPRODUCTOPROVEEDOR, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPRODUCTOPROVEEDOR.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPRODUCTOPROVEEDOR.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOPROVEEDOR.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPRODUCTOPROVEEDOR.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOPROVEEDOR.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPRODUCTOPROVEEDOR.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOPROVEEDOR.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCPRODUCTOPROVEEDOR.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PROVEEDORID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOPROVEEDOR.isnull["IPROVEEDORID"])
                {
                    auxPar.Value = oCPRODUCTOPROVEEDOR.IPROVEEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PRODUCTOPROVEEDOR
      (
    

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

PRODUCTOID,

PROVEEDORID
         )

Values (

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@PRODUCTOID,

@PROVEEDORID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPRODUCTOPROVEEDOR;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarPRODUCTOPROVEEDORD(CPRODUCTOPROVEEDORBE oCPRODUCTOPROVEEDOR, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTOPROVEEDOR.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PRODUCTOPROVEEDOR
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


        public bool DesactivarPorProducto(long productoId, FbTransaction st)
        {
            try
            {
                string commandText = @"UPDATE PRODUCTOPROVEEDOR
                                       SET ACTIVO = 'N'
                                       WHERE PRODUCTOID = " + productoId.ToString() + ";";

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText);


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool EliminarInactivosPorProducto(long productoId, FbTransaction st)
        {
            try
            {
                string commandText = @"DELETE FROM PRODUCTOPROVEEDOR
                                       WHERE ACTIVO = 'N' and PRODUCTOID = " + productoId.ToString() + ";";

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText);


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool PonerValorActivo(long productoId, long proveedorId, string activo, FbTransaction st)
        {
            try
            {
                string commandText = @"UPDATE PRODUCTOPROVEEDOR
                                       SET ACTIVO = '" + activo + @"'
                                       WHERE PRODUCTOID = " + productoId.ToString() + "and PROVEEDORID = " + proveedorId.ToString() + ";";

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText);


                return true;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        [AutoComplete]
        public bool CambiarPRODUCTOPROVEEDORD(CPRODUCTOPROVEEDORBE oCPRODUCTOPROVEEDORNuevo, CPRODUCTOPROVEEDORBE oCPRODUCTOPROVEEDORAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                

                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPRODUCTOPROVEEDORNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPRODUCTOPROVEEDORNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOPROVEEDORNuevo.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPRODUCTOPROVEEDORNuevo.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOPROVEEDORNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPRODUCTOPROVEEDORNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOPROVEEDORNuevo.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCPRODUCTOPROVEEDORNuevo.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROVEEDORID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOPROVEEDORNuevo.isnull["IPROVEEDORID"])
                {
                    auxPar.Value = oCPRODUCTOPROVEEDORNuevo.IPROVEEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOPROVEEDORAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPRODUCTOPROVEEDORAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PRODUCTOPROVEEDOR
  set

ACTIVO=@ACTIVO,

CREADOPOR_USERID=@CREADOPOR_USERID,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

PRODUCTOID=@PRODUCTOID,

PROVEEDORID=@PROVEEDORID
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
        public CPRODUCTOPROVEEDORBE seleccionarPRODUCTOPROVEEDOR(CPRODUCTOPROVEEDORBE oCPRODUCTOPROVEEDOR, FbTransaction st)
        {




            CPRODUCTOPROVEEDORBE retorno = new CPRODUCTOPROVEEDORBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PRODUCTOPROVEEDOR where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTOPROVEEDOR.IID;
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

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["PROVEEDORID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEEDORID = (long)(dr["PROVEEDORID"]);
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
        public DataSet enlistarPRODUCTOPROVEEDOR()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRODUCTOPROVEEDOR_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoPRODUCTOPROVEEDOR()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRODUCTOPROVEEDOR_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExistePRODUCTOPROVEEDOR(CPRODUCTOPROVEEDORBE oCPRODUCTOPROVEEDOR, FbTransaction st)
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
                auxPar.Value = oCPRODUCTOPROVEEDOR.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PRODUCTOPROVEEDOR where

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



        public int ExistePRODUCTOPROVEEDOR_x_VALORES(long productoId, long proveedorId, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = productoId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROVEEDORID", FbDbType.BigInt);
                auxPar.Value = proveedorId;
                parts.Add(auxPar);


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PRODUCTOPROVEEDOR where

  PRODUCTOID=@PRODUCTOID AND PROVEEDORID=@PROVEEDORID  
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

        public CPRODUCTOPROVEEDORBE AgregarPRODUCTOPROVEEDOR(CPRODUCTOPROVEEDORBE oCPRODUCTOPROVEEDOR, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRODUCTOPROVEEDOR(oCPRODUCTOPROVEEDOR, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PRODUCTOPROVEEDOR ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPRODUCTOPROVEEDORD(oCPRODUCTOPROVEEDOR, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPRODUCTOPROVEEDOR(CPRODUCTOPROVEEDORBE oCPRODUCTOPROVEEDOR, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRODUCTOPROVEEDOR(oCPRODUCTOPROVEEDOR, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRODUCTOPROVEEDOR no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPRODUCTOPROVEEDORD(oCPRODUCTOPROVEEDOR, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPRODUCTOPROVEEDOR(CPRODUCTOPROVEEDORBE oCPRODUCTOPROVEEDORNuevo, CPRODUCTOPROVEEDORBE oCPRODUCTOPROVEEDORAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRODUCTOPROVEEDOR(oCPRODUCTOPROVEEDORAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRODUCTOPROVEEDOR no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPRODUCTOPROVEEDORD(oCPRODUCTOPROVEEDORNuevo, oCPRODUCTOPROVEEDORAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPRODUCTOPROVEEDORD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
