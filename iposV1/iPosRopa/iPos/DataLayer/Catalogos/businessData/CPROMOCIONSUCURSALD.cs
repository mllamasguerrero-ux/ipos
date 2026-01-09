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
    public class CPROMOCIONSUCURSALD
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

        public CPROMOCIONSUCURSALBE AgregarPROMOCIONSUCURSALD(CPROMOCIONSUCURSALBE oCPROMOCIONSUCURSAL, FbTransaction st)
        {


            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@PROMOCIONID", FbDbType.BigInt);
                if (!(bool)oCPROMOCIONSUCURSAL.isnull["IPROMOCIONID"])
                {
                    auxPar.Value = oCPROMOCIONSUCURSAL.IPROMOCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCPROMOCIONSUCURSAL.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCPROMOCIONSUCURSAL.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PROMOCIONSUCURSAL
      (

PROMOCIONID,

SUCURSALID
         )

Values (

@PROMOCIONID,

@SUCURSALID
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPROMOCIONSUCURSAL;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public bool BorrarPROMOCIONSUCURSALD(CPROMOCIONSUCURSALBE oCPROMOCIONSUCURSAL, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPROMOCIONSUCURSAL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PROMOCIONSUCURSAL
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

        public bool BorrarXPromocionIdPROMOCIONSUCURSAL(long promId, FbTransaction st)
        {
            try
            {
                string commandText = @"DELETE FROM PROMOCIONSUCURSAL 
                                       WHERE PROMOCIONID = " + promId.ToString() + ";";

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

        public bool BorrarTodoPROMOCIONSUCURSAL(FbTransaction st)
        {
            try
            {
                string commandText = @"  Delete from PROMOCIONSUCURSAL;";

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

        public bool CambiarPROMOCIONSUCURSALD(CPROMOCIONSUCURSALBE oCPROMOCIONSUCURSALNuevo, CPROMOCIONSUCURSALBE oCPROMOCIONSUCURSALAnterior, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@PROMOCIONID", FbDbType.BigInt);
                if (!(bool)oCPROMOCIONSUCURSALNuevo.isnull["IPROMOCIONID"])
                {
                    auxPar.Value = oCPROMOCIONSUCURSALNuevo.IPROMOCIONID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCPROMOCIONSUCURSALNuevo.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCPROMOCIONSUCURSALNuevo.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPROMOCIONSUCURSALAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPROMOCIONSUCURSALAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PROMOCIONSUCURSAL
  set

PROMOCIONID=@PROMOCIONID,

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

        public CPROMOCIONSUCURSALBE seleccionarPROMOCIONSUCURSAL(CPROMOCIONSUCURSALBE oCPROMOCIONSUCURSAL, FbTransaction st)
        {

            CPROMOCIONSUCURSALBE retorno = new CPROMOCIONSUCURSALBE();
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PROMOCIONSUCURSAL where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPROMOCIONSUCURSAL.IID;
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

                    if (dr["PROMOCIONID"] != System.DBNull.Value)
                    {
                        retorno.IPROMOCIONID = (long)(dr["PROMOCIONID"]);
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


        public DataSet enlistarPROMOCIONSUCURSAL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PROMOCIONSUCURSAL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        public DataSet enlistarCortoPROMOCIONSUCURSAL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PROMOCIONSUCURSAL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }

        public int ExistePROMOCIONSUCURSAL(CPROMOCIONSUCURSALBE oCPROMOCIONSUCURSAL, FbTransaction st)
        {
            int retorno;
            FbDataReader dr = null;

            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPROMOCIONSUCURSAL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PROMOCIONSUCURSAL where

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




        public CPROMOCIONSUCURSALBE AgregarPROMOCIONSUCURSAL(CPROMOCIONSUCURSALBE oCPROMOCIONSUCURSAL, FbTransaction st)
        {
            try
            {
                int iRes = ExistePROMOCIONSUCURSAL(oCPROMOCIONSUCURSAL, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PROMOCIONSUCURSAL ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPROMOCIONSUCURSALD(oCPROMOCIONSUCURSAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPROMOCIONSUCURSAL(CPROMOCIONSUCURSALBE oCPROMOCIONSUCURSAL, FbTransaction st)
        {
            try
            {
                int iRes = ExistePROMOCIONSUCURSAL(oCPROMOCIONSUCURSAL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PROMOCIONSUCURSAL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPROMOCIONSUCURSALD(oCPROMOCIONSUCURSAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPROMOCIONSUCURSAL(CPROMOCIONSUCURSALBE oCPROMOCIONSUCURSALNuevo, CPROMOCIONSUCURSALBE oCPROMOCIONSUCURSALAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePROMOCIONSUCURSAL(oCPROMOCIONSUCURSALAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PROMOCIONSUCURSAL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPROMOCIONSUCURSALD(oCPROMOCIONSUCURSALNuevo, oCPROMOCIONSUCURSALAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }

        public CPROMOCIONSUCURSALD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
