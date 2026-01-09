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

    public class CTIPOTRANSACCIOND
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


        public CTIPOTRANSACCIONBE AgregarTIPOTRANSACCIOND(CTIPOTRANSACCIONBE oCTIPOTRANSACCION, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCTIPOTRANSACCION.isnull["IID"])
                {
                    auxPar.Value = oCTIPOTRANSACCION.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCTIPOTRANSACCION.isnull["IACTIVO"])
                {
                    auxPar.Value = oCTIPOTRANSACCION.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCTIPOTRANSACCION.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCTIPOTRANSACCION.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCTIPOTRANSACCION.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCTIPOTRANSACCION.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCTIPOTRANSACCION.isnull["ICLAVE"])
                {
                    auxPar.Value = oCTIPOTRANSACCION.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCTIPOTRANSACCION.isnull["INOMBRE"])
                {
                    auxPar.Value = oCTIPOTRANSACCION.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SENTIDOINVENTARIO", FbDbType.SmallInt);
                if (!(bool)oCTIPOTRANSACCION.isnull["ISENTIDOINVENTARIO"])
                {
                    auxPar.Value = oCTIPOTRANSACCION.ISENTIDOINVENTARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SENTIDOPAGO", FbDbType.SmallInt);
                if (!(bool)oCTIPOTRANSACCION.isnull["ISENTIDOPAGO"])
                {
                    auxPar.Value = oCTIPOTRANSACCION.ISENTIDOPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO TIPOTRANSACCION
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

CLAVE,

NOMBRE,

SENTIDOINVENTARIO,

SENTIDOPAGO
         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@CLAVE,

@NOMBRE,

@SENTIDOINVENTARIO,

@SENTIDOPAGO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCTIPOTRANSACCION;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarTIPOTRANSACCIOND(CTIPOTRANSACCIONBE oCTIPOTRANSACCION, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCTIPOTRANSACCION.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from TIPOTRANSACCION
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


        public bool CambiarTIPOTRANSACCIOND(CTIPOTRANSACCIONBE oCTIPOTRANSACCIONNuevo, CTIPOTRANSACCIONBE oCTIPOTRANSACCIONAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCTIPOTRANSACCIONNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCTIPOTRANSACCIONNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCTIPOTRANSACCIONNuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCTIPOTRANSACCIONNuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCTIPOTRANSACCIONNuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCTIPOTRANSACCIONNuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCTIPOTRANSACCIONNuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCTIPOTRANSACCIONNuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SENTIDOINVENTARIO", FbDbType.SmallInt);
                if (!(bool)oCTIPOTRANSACCIONNuevo.isnull["ISENTIDOINVENTARIO"])
                {
                    auxPar.Value = oCTIPOTRANSACCIONNuevo.ISENTIDOINVENTARIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SENTIDOPAGO", FbDbType.SmallInt);
                if (!(bool)oCTIPOTRANSACCIONNuevo.isnull["ISENTIDOPAGO"])
                {
                    auxPar.Value = oCTIPOTRANSACCIONNuevo.ISENTIDOPAGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCTIPOTRANSACCIONAnterior.isnull["IID"])
                {
                    auxPar.Value = oCTIPOTRANSACCIONAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  TIPOTRANSACCION
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

SENTIDOINVENTARIO=@SENTIDOINVENTARIO,

SENTIDOPAGO=@SENTIDOPAGO
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


        public CTIPOTRANSACCIONBE seleccionarTIPOTRANSACCION(CTIPOTRANSACCIONBE oCTIPOTRANSACCION, FbTransaction st)
        {




            CTIPOTRANSACCIONBE retorno = new CTIPOTRANSACCIONBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from TIPOTRANSACCION where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCTIPOTRANSACCION.IID;
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

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["SENTIDOINVENTARIO"] != System.DBNull.Value)
                    {
                        retorno.ISENTIDOINVENTARIO = short.Parse(dr["SENTIDOINVENTARIO"].ToString());
                    }

                    if (dr["SENTIDOPAGO"] != System.DBNull.Value)
                    {
                        retorno.ISENTIDOPAGO = short.Parse(dr["SENTIDOPAGO"].ToString());
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







        public CTIPOTRANSACCIONBE seleccionarTIPOTRANSACCIONxCLAVE(CTIPOTRANSACCIONBE oCTIPOTRANSACCION, FbTransaction st)
        {




            CTIPOTRANSACCIONBE retorno = new CTIPOTRANSACCIONBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from TIPOTRANSACCION where CLAVE=@CLAVE  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.BigInt);
                auxPar.Value = oCTIPOTRANSACCION.ICLAVE;
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

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["SENTIDOINVENTARIO"] != System.DBNull.Value)
                    {
                        retorno.ISENTIDOINVENTARIO = short.Parse(dr["SENTIDOINVENTARIO"].ToString());
                    }

                    if (dr["SENTIDOPAGO"] != System.DBNull.Value)
                    {
                        retorno.ISENTIDOPAGO = short.Parse(dr["SENTIDOPAGO"].ToString());
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






        public DataSet enlistarTIPOTRANSACCION()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_TIPOTRANSACCION_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public DataSet enlistarCortoTIPOTRANSACCION()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_TIPOTRANSACCION_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public int ExisteTIPOTRANSACCION(CTIPOTRANSACCIONBE oCTIPOTRANSACCION, FbTransaction st)
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
                auxPar.Value = oCTIPOTRANSACCION.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from TIPOTRANSACCION where

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




        public CTIPOTRANSACCIONBE AgregarTIPOTRANSACCION(CTIPOTRANSACCIONBE oCTIPOTRANSACCION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteTIPOTRANSACCION(oCTIPOTRANSACCION, st);
                if (iRes == 1)
                {
                    this.IComentario = "El TIPOTRANSACCION ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarTIPOTRANSACCIOND(oCTIPOTRANSACCION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarTIPOTRANSACCION(CTIPOTRANSACCIONBE oCTIPOTRANSACCION, FbTransaction st)
        {
            try
            {
                int iRes = ExisteTIPOTRANSACCION(oCTIPOTRANSACCION, st);
                if (iRes == 0)
                {
                    this.IComentario = "El TIPOTRANSACCION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarTIPOTRANSACCIOND(oCTIPOTRANSACCION, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarTIPOTRANSACCION(CTIPOTRANSACCIONBE oCTIPOTRANSACCIONNuevo, CTIPOTRANSACCIONBE oCTIPOTRANSACCIONAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExisteTIPOTRANSACCION(oCTIPOTRANSACCIONAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El TIPOTRANSACCION no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarTIPOTRANSACCIOND(oCTIPOTRANSACCIONNuevo, oCTIPOTRANSACCIONAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CTIPOTRANSACCIOND()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
