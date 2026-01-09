


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

    public class CINVENTARIOSUCURSALD
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
        public bool AgregarINVENTARIOSUCURSALD(CINVENTARIOSUCURSALBE oCINVENTARIOSUCURSAL, FbTransaction st)
        {

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@PRODUCTOCLAVE", FbDbType.VarChar);
                if (!(bool)oCINVENTARIOSUCURSAL.isnull["IPRODUCTOCLAVE"])
                {
                    auxPar.Value = oCINVENTARIOSUCURSAL.IPRODUCTOCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCINVENTARIOSUCURSAL.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCINVENTARIOSUCURSAL.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HORA", FbDbType.VarChar);
                if (!(bool)oCINVENTARIOSUCURSAL.isnull["IHORA"])
                {
                    auxPar.Value = oCINVENTARIOSUCURSAL.IHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCINVENTARIOSUCURSAL.isnull["IFECHA"])
                {
                    auxPar.Value = oCINVENTARIOSUCURSAL.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUCURSALCLAVE", FbDbType.VarChar);
                if (!(bool)oCINVENTARIOSUCURSAL.isnull["ISUCURSALCLAVE"])
                {
                    auxPar.Value = oCINVENTARIOSUCURSAL.ISUCURSALCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ALMACENCLAVE", FbDbType.VarChar);
                if (!(bool)oCINVENTARIOSUCURSAL.isnull["IALMACENCLAVE"])
                {
                    auxPar.Value = oCINVENTARIOSUCURSAL.IALMACENCLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@EXISTENCIAID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"IMPORTAR_EXISTENCIA";

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


        public bool BorrarINVENTARIOSUCURSALD(CINVENTARIOSUCURSALBE oCINVENTARIOSUCURSAL, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCINVENTARIOSUCURSAL.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from INVENTARIOSUCURSAL
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





        public bool BorrarTodosINVENTARIOSUCURSALD( FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                string commandText = @"  Delete from INVENTARIOSUCURSAL ;";

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
        public bool CambiarINVENTARIOSUCURSALD(CINVENTARIOSUCURSALBE oCINVENTARIOSUCURSALNuevo,  FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (!(bool)oCINVENTARIOSUCURSALNuevo.isnull["ISUCURSALID"])
                {
                    auxPar.Value = oCINVENTARIOSUCURSALNuevo.ISUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (!(bool)oCINVENTARIOSUCURSALNuevo.isnull["IALMACENID"])
                {
                    auxPar.Value = oCINVENTARIOSUCURSALNuevo.IALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCINVENTARIOSUCURSALNuevo.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCINVENTARIOSUCURSALNuevo.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HORA", FbDbType.Time);
                if (!(bool)oCINVENTARIOSUCURSALNuevo.isnull["IHORA"])
                {
                    auxPar.Value = oCINVENTARIOSUCURSALNuevo.IHORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                if (!(bool)oCINVENTARIOSUCURSALNuevo.isnull["IFECHA"])
                {
                    auxPar.Value = oCINVENTARIOSUCURSALNuevo.IFECHA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (!(bool)oCINVENTARIOSUCURSALNuevo.isnull["ICANTIDAD"])
                {
                    auxPar.Value = oCINVENTARIOSUCURSALNuevo.ICANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                string commandText = @"
  update  INVENTARIOSUCURSAL
  set

CANTIDAD=@CANTIDAD,
FECHA = @FECHA,
HORA = QHORA

  where 

PRODUCTOID=@PRODUCTOID and SUCURSALID=@SUCURSALID and ALMACENID = @ALMACENID
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
        public CINVENTARIOSUCURSALBE seleccionarINVENTARIOSUCURSAL(CINVENTARIOSUCURSALBE oCINVENTARIOSUCURSAL, FbTransaction st)
        {




            CINVENTARIOSUCURSALBE retorno = new CINVENTARIOSUCURSALBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from INVENTARIOSUCURSAL where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCINVENTARIOSUCURSAL.IID;
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

                    if (dr["SUCURSALID"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALID = (long)(dr["SUCURSALID"]);
                    }

                    if (dr["SUCURSALCLAVE"] != System.DBNull.Value)
                    {
                        retorno.ISUCURSALCLAVE = (string)(dr["SUCURSALCLAVE"]);
                    }

                    if (dr["ALMACENID"] != System.DBNull.Value)
                    {
                        retorno.IALMACENID = (long)(dr["ALMACENID"]);
                    }

                    if (dr["ALMACENCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IALMACENCLAVE = (string)(dr["ALMACENCLAVE"]);
                    }

                    if (dr["PRODUCTOID"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOID = (long)(dr["PRODUCTOID"]);
                    }

                    if (dr["PRODUCTOCLAVE"] != System.DBNull.Value)
                    {
                        retorno.IPRODUCTOCLAVE = (string)(dr["PRODUCTOCLAVE"]);
                    }

                    if (dr["HORA"] != System.DBNull.Value)
                    {
                        retorno.IHORA = (TimeSpan)(dr["HORA"]);
                    }

                    if (dr["FECHA"] != System.DBNull.Value)
                    {
                        retorno.IFECHA = (DateTime)(dr["FECHA"]);
                    }

                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        retorno.ICANTIDAD = (decimal)(dr["CANTIDAD"]);
                    }

                    if (dr["COSTO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTO = (decimal)(dr["COSTO"]);
                    }

                    if (dr["COSTOULTIMO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOULTIMO = (decimal)(dr["COSTOULTIMO"]);
                    }

                    if (dr["COSTOPROMEDIO"] != System.DBNull.Value)
                    {
                        retorno.ICOSTOPROMEDIO = (decimal)(dr["COSTOPROMEDIO"]);
                    }

                    if (dr["ULTIMAFECHACOMPRA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMAFECHACOMPRA = (DateTime)(dr["ULTIMAFECHACOMPRA"]);
                    }

                    if (dr["ULTIMAFECHAVENTA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMAFECHAVENTA = (DateTime)(dr["ULTIMAFECHAVENTA"]);
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
        public DataSet enlistarINVENTARIOSUCURSAL()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_INVENTARIOSUCURSAL_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoINVENTARIOSUCURSAL()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_INVENTARIOSUCURSAL_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExisteINVENTARIOSUCURSAL(CINVENTARIOSUCURSALBE oCINVENTARIOSUCURSAL, FbTransaction st)
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
                auxPar.Value = oCINVENTARIOSUCURSAL.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from INVENTARIOSUCURSAL where

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




        public bool AgregarINVENTARIOSUCURSAL(CINVENTARIOSUCURSALBE oCINVENTARIOSUCURSAL, FbTransaction st)
        {
            try
            {
                return AgregarINVENTARIOSUCURSALD(oCINVENTARIOSUCURSAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool BorrarINVENTARIOSUCURSAL(CINVENTARIOSUCURSALBE oCINVENTARIOSUCURSAL, FbTransaction st)
        {
            try
            {
                int iRes = ExisteINVENTARIOSUCURSAL(oCINVENTARIOSUCURSAL, st);
                if (iRes == 0)
                {
                    this.IComentario = "El INVENTARIOSUCURSAL no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarINVENTARIOSUCURSALD(oCINVENTARIOSUCURSAL, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        //public bool CambiarINVENTARIOSUCURSAL(CINVENTARIOSUCURSALBE oCINVENTARIOSUCURSALNuevo, CINVENTARIOSUCURSALBE oCINVENTARIOSUCURSALAnterior, FbTransaction st)
        //{
        //    try
        //    {
        //        int iRes = ExisteINVENTARIOSUCURSAL(oCINVENTARIOSUCURSALAnterior, st);
        //        if (iRes == 0)
        //        {
        //            this.IComentario = "El INVENTARIOSUCURSAL no existe";
        //            return false;
        //        }
        //        else if (iRes == -1)
        //        {
        //            return false;
        //        }
        //        return CambiarINVENTARIOSUCURSALD(oCINVENTARIOSUCURSALNuevo, oCINVENTARIOSUCURSALAnterior, st);
        //    }
        //    catch (Exception e)
        //    {
        //        this.iComentario = e.Message + e.StackTrace;
        //        return false;
        //    }

        //}





        public CINVENTARIOSUCURSALD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
        }
    }
}
