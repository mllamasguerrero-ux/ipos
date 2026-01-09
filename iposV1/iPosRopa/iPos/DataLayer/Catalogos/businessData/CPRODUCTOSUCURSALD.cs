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
    public class CPRODUCTOSUCURSALD
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

        public CPRODUCTOSUCURSALBE AgregarPRODUCTOSUCURSALD(CPRODUCTOSUCURSALBE oCPRODUCTOSUCURSAL, FbTransaction st)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOSUCURSAL.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCPRODUCTOSUCURSAL.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOSUCURSAL.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCPRODUCTOSUCURSAL.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PRODUCTOSUCURSAL
      (

PRODUCTOID,

SUCURSALID
         )

Values (

@PRODUCTOID,

@SUCURSALID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPRODUCTOSUCURSAL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public bool BorrarPRODUCTOSUCURSALD(CPRODUCTOSUCURSALBE oCPRODUCTOSUCURSAL, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTOSUCURSAL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PRODUCTOSUCURSAL
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

        public bool BorrarXProductoIdPRODUCTOSUCURSAL(long promId, FbTransaction st)
        {
            try
            {
                string commandText = @"DELETE FROM PRODUCTOSUCURSAL 
                                       WHERE PRODUCTOID = " + promId.ToString() + ";";

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

        public bool BorrarTodoPRODUCTOSUCURSAL(FbTransaction st)
        {
            try
            {
                string commandText = @"  Delete from PRODUCTOSUCURSAL;";

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

        public bool CambiarPRODUCTOSUCURSALD(CPRODUCTOSUCURSALBE oCPRODUCTOSUCURSALNuevo, CPRODUCTOSUCURSALBE oCPRODUCTOSUCURSALAnterior, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOSUCURSALNuevo.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCPRODUCTOSUCURSALNuevo.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOSUCURSALNuevo.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCPRODUCTOSUCURSALNuevo.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPRODUCTOSUCURSALAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPRODUCTOSUCURSALAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PRODUCTOSUCURSAL
  set

PRODUCTOID=@PRODUCTOID,

SUCURSALID=@SUCURSALID
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

        public CPRODUCTOSUCURSALBE seleccionarPRODUCTOSUCURSAL(CPRODUCTOSUCURSALBE oCPRODUCTOSUCURSAL, FbTransaction st)
        {

            CPRODUCTOSUCURSALBE retorno = new CPRODUCTOSUCURSALBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PRODUCTOSUCURSAL where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTOSUCURSAL.IID;
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

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
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


        public DataSet enlistarPRODUCTOSUCURSAL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRODUCTOSUCURSAL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        public DataSet enlistarCortoPRODUCTOSUCURSAL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRODUCTOSUCURSAL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }

        public int ExistePRODUCTOSUCURSAL(CPRODUCTOSUCURSALBE oCPRODUCTOSUCURSAL, FbTransaction st)
        {
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRODUCTOSUCURSAL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PRODUCTOSUCURSAL where

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




        public CPRODUCTOSUCURSALBE AgregarPRODUCTOSUCURSAL(CPRODUCTOSUCURSALBE oCPRODUCTOSUCURSAL, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRODUCTOSUCURSAL(oCPRODUCTOSUCURSAL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PRODUCTOSUCURSAL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPRODUCTOSUCURSALD(oCPRODUCTOSUCURSAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPRODUCTOSUCURSAL(CPRODUCTOSUCURSALBE oCPRODUCTOSUCURSAL, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRODUCTOSUCURSAL(oCPRODUCTOSUCURSAL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRODUCTOSUCURSAL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPRODUCTOSUCURSALD(oCPRODUCTOSUCURSAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPRODUCTOSUCURSAL(CPRODUCTOSUCURSALBE oCPRODUCTOSUCURSALNuevo, CPRODUCTOSUCURSALBE oCPRODUCTOSUCURSALAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRODUCTOSUCURSAL(oCPRODUCTOSUCURSALAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRODUCTOSUCURSAL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPRODUCTOSUCURSALD(oCPRODUCTOSUCURSALNuevo, oCPRODUCTOSUCURSALAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public CPRODUCTOSUCURSALD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
