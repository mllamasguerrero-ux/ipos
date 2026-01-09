

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


    public class CPRECIOSTEMPD
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
        public CPRECIOSTEMPBE AgregarPRECIOSTEMPD(CPRECIOSTEMPBE oCPRECIOSTEMP, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;




                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPRECIOSTEMP.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPRECIOSTEMP.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCPRECIOSTEMP.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCPRECIOSTEMP.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMP.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRECIOSTEMP.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMP.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRECIOSTEMP.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMP.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRECIOSTEMP.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMP.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPRECIOSTEMP.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMP.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRECIOSTEMP.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUGERIDO", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMP.isnull["ISUGERIDO"])
                {
                    auxPar.Value = oCPRECIOSTEMP.ISUGERIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PRECIOSTEMP
      (
   

ACTIVO,

PRODUCTOID,

PRECIO1,

PRECIO2,

PRECIO3,

PRECIO4,

PRECIO5,

SUGERIDO
         )

Values (

@ACTIVO,

@PRODUCTOID,

@PRECIO1,

@PRECIO2,

@PRECIO3,

@PRECIO4,

@PRECIO5,

@SUGERIDO
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPRECIOSTEMP;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarPRECIOSTEMPD(CPRECIOSTEMPBE oCPRECIOSTEMP, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRECIOSTEMP.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PRECIOSTEMP
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
        public bool CambiarPRECIOSTEMPD(CPRECIOSTEMPBE oCPRECIOSTEMPNuevo, CPRECIOSTEMPBE oCPRECIOSTEMPAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPRECIOSTEMPNuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPRECIOSTEMPNuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (!(bool)oCPRECIOSTEMPNuevo.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCPRECIOSTEMPNuevo.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMPNuevo.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRECIOSTEMPNuevo.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMPNuevo.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRECIOSTEMPNuevo.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMPNuevo.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRECIOSTEMPNuevo.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMPNuevo.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPRECIOSTEMPNuevo.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMPNuevo.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRECIOSTEMPNuevo.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUGERIDO", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMPNuevo.isnull["ISUGERIDO"])
                {
                    auxPar.Value = oCPRECIOSTEMPNuevo.ISUGERIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPRECIOSTEMPAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPRECIOSTEMPAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PRECIOSTEMP
  set

ACTIVO=@ACTIVO,

PRODUCTOID=@PRODUCTOID,

PRECIO1=@PRECIO1,

PRECIO2=@PRECIO2,

PRECIO3=@PRECIO3,

PRECIO4=@PRECIO4,

PRECIO5=@PRECIO5,

SUGERIDO=@SUGERIDO
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
        public CPRECIOSTEMPBE seleccionarPRECIOSTEMP(CPRECIOSTEMPBE oCPRECIOSTEMP, FbTransaction st)
        {




            CPRECIOSTEMPBE retorno = new CPRECIOSTEMPBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PRECIOSTEMP where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPRECIOSTEMP.IID;
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

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (decimal)(dr["PRECIO1"]);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)(dr["PRECIO2"]);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)(dr["PRECIO3"]);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)(dr["PRECIO4"]);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)(dr["PRECIO5"]);
                    }

                    if (dr["SUGERIDO"] != System.DBNull.Value)
                    {
                        retorno.ISUGERIDO = (decimal)(dr["SUGERIDO"]);
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





        public CPRECIOSTEMPBE seleccionarPRECIOSTEMPXPROD(CPRECIOSTEMPBE oCPRECIOSTEMP, FbTransaction st)
        {




            CPRECIOSTEMPBE retorno = new CPRECIOSTEMPBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PRECIOSTEMP where PRODUCTOID = @PRODUCTOID  ";


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                auxPar.Value = oCPRECIOSTEMP.IPRODUCTOID;
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

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO1 = (decimal)(dr["PRECIO1"]);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO2 = (decimal)(dr["PRECIO2"]);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO3 = (decimal)(dr["PRECIO3"]);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO4 = (decimal)(dr["PRECIO4"]);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        retorno.IPRECIO5 = (decimal)(dr["PRECIO5"]);
                    }

                    if (dr["SUGERIDO"] != System.DBNull.Value)
                    {
                        retorno.ISUGERIDO = (decimal)(dr["SUGERIDO"]);
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
        public DataSet enlistarPRECIOSTEMP()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRECIOSTEMP_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoPRECIOSTEMP()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PRECIOSTEMP_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExistePRECIOSTEMP(CPRECIOSTEMPBE oCPRECIOSTEMP, FbTransaction st)
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
                auxPar.Value = oCPRECIOSTEMP.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PRECIOSTEMP where

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




        public int HAYPRECIOSTEMP( FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @" select count(*) CUENTA from PRECIOSTEMP ";






                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {

                    if (dr["CUENTA"] != System.DBNull.Value)
                    {
                        int iCuenta = (int)(dr["CUENTA"]);
                        if (iCuenta > 0)
                        {
                            Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                            return 1;
                        }  
                        else
                        {
                            Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                            return 0;
                        }
                           
                    }

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




        public CPRECIOSTEMPBE AgregarPRECIOSTEMP(CPRECIOSTEMPBE oCPRECIOSTEMP, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRECIOSTEMP(oCPRECIOSTEMP, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PRECIOSTEMP ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPRECIOSTEMPD(oCPRECIOSTEMP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPRECIOSTEMP(CPRECIOSTEMPBE oCPRECIOSTEMP, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRECIOSTEMP(oCPRECIOSTEMP, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRECIOSTEMP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPRECIOSTEMPD(oCPRECIOSTEMP, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPRECIOSTEMP(CPRECIOSTEMPBE oCPRECIOSTEMPNuevo, CPRECIOSTEMPBE oCPRECIOSTEMPAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePRECIOSTEMP(oCPRECIOSTEMPAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PRECIOSTEMP no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPRECIOSTEMPD(oCPRECIOSTEMPNuevo, oCPRECIOSTEMPAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }







        public bool PRECIOSTEMP_APLICAR(FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"PRECIOSTEMP_APLICAR";

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







        public bool PRECIOSTEMP_ELIMINAR( FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                string commandText = @"PRECIOSTEMP_ELIMINAR";

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





        public bool importarPrecioTempD(CPRECIOSTEMPBE oCPRECIOSTEMP, FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@PRODUCTOID", FbDbType.VarChar);
                if (!(bool)oCPRECIOSTEMP.isnull["IPRODUCTOID"])
                {
                    auxPar.Value = oCPRECIOSTEMP.IPRODUCTOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@PRECIO1", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMP.isnull["IPRECIO1"])
                {
                    auxPar.Value = oCPRECIOSTEMP.IPRECIO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO2", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMP.isnull["IPRECIO2"])
                {
                    auxPar.Value = oCPRECIOSTEMP.IPRECIO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO3", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMP.isnull["IPRECIO3"])
                {
                    auxPar.Value = oCPRECIOSTEMP.IPRECIO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO4", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMP.isnull["IPRECIO4"])
                {
                    auxPar.Value = oCPRECIOSTEMP.IPRECIO4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO5", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMP.isnull["IPRECIO5"])
                {
                    auxPar.Value = oCPRECIOSTEMP.IPRECIO5;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUGERIDO", FbDbType.Numeric);
                if (!(bool)oCPRECIOSTEMP.isnull["ISUGERIDO"])
                {
                    auxPar.Value = oCPRECIOSTEMP.ISUGERIDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"PRECIOSTEMP_IMPORTAR";

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




        public CPRECIOSTEMPD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
