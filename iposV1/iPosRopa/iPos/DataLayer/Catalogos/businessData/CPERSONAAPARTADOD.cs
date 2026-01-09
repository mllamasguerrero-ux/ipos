

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


    public class CPERSONAAPARTADOD
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
        public CPERSONAAPARTADOBE AgregarPERSONAAPARTADOD(CPERSONAAPARTADOBE oCPERSONAAPARTADO, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@NOMBRES", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADO.isnull["INOMBRES"])
                {
                    auxPar.Value = oCPERSONAAPARTADO.INOMBRES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@DOMICILIO", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADO.isnull["IDOMICILIO"])
                {
                    auxPar.Value = oCPERSONAAPARTADO.IDOMICILIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CIUDAD", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADO.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCPERSONAAPARTADO.ICIUDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@TELEFONO1", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADO.isnull["ITELEFONO1"])
                {
                    auxPar.Value = oCPERSONAAPARTADO.ITELEFONO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CELULAR", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADO.isnull["ICELULAR"])
                {
                    auxPar.Value = oCPERSONAAPARTADO.ICELULAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMAIL1", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADO.isnull["IEMAIL1"])
                {
                    auxPar.Value = oCPERSONAAPARTADO.IEMAIL1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PERSONAAPARTADOID", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"PERSONAAPARTADO_INSERT";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);



                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    if ((long)arParms[arParms.Length - 2].Value != 0)
                    {
                        oCPERSONAAPARTADO.IID = (long)arParms[arParms.Length - 2].Value;
                    }
                }

                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        this.iComentario = "Hubo un error";
                        return null;
                    }
                }





                return oCPERSONAAPARTADO;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        [AutoComplete]
        public bool BorrarPERSONAAPARTADOD(CPERSONAAPARTADOBE oCPERSONAAPARTADO, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPERSONAAPARTADO.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PERSONAAPARTADO
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
        public bool CambiarPERSONAAPARTADOD(CPERSONAAPARTADOBE oCPERSONAAPARTADONuevo, CPERSONAAPARTADOBE oCPERSONAAPARTADOAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;





                auxPar = new FbParameter("@NOMBRES", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["INOMBRES"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.INOMBRES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@APELLIDOS", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["IAPELLIDOS"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.IAPELLIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOMICILIO", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["IDOMICILIO"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.IDOMICILIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COLONIA", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CIUDAD", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.ICIUDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MUNICIPIO", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["IMUNICIPIO"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.IMUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADO", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["IESTADO"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAIS", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["IPAIS"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.IPAIS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGOPOSTAL", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["ICODIGOPOSTAL"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.ICODIGOPOSTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TELEFONO1", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["ITELEFONO1"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.ITELEFONO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CELULAR", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["ICELULAR"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.ICELULAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMAIL1", FbDbType.VarChar);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["IEMAIL1"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.IEMAIL1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDOAPARTADO", FbDbType.Numeric);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["ISALDOAPARTADO"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.ISALDOAPARTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDOAPARTADOPOSITIVO", FbDbType.Numeric);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["ISALDOAPARTADOPOSITIVO"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.ISALDOAPARTADOPOSITIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDOAPARTADONEGATIVO", FbDbType.Numeric);
                if (!(bool)oCPERSONAAPARTADONuevo.isnull["ISALDOAPARTADONEGATIVO"])
                {
                    auxPar.Value = oCPERSONAAPARTADONuevo.ISALDOAPARTADONEGATIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPERSONAAPARTADOAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPERSONAAPARTADOAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"
  update  PERSONAAPARTADO
  set


NOMBRES=@NOMBRES,

APELLIDOS=@APELLIDOS,

DOMICILIO=@DOMICILIO,

COLONIA=@COLONIA,

CIUDAD=@CIUDAD,

MUNICIPIO=@MUNICIPIO,

ESTADO=@ESTADO,

PAIS=@PAIS,

CODIGOPOSTAL=@CODIGOPOSTAL,

TELEFONO1=@TELEFONO1,

CELULAR=@CELULAR,

EMAIL1=@EMAIL1,

SALDOAPARTADO=@SALDOAPARTADO,

SALDOAPARTADOPOSITIVO=@SALDOAPARTADOPOSITIVO,

SALDOAPARTADONEGATIVO=@SALDOAPARTADONEGATIVO
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
        public CPERSONAAPARTADOBE seleccionarPERSONAAPARTADO(CPERSONAAPARTADOBE oCPERSONAAPARTADO, FbTransaction st)
        {




            CPERSONAAPARTADOBE retorno = new CPERSONAAPARTADOBE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PERSONAAPARTADO where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPERSONAAPARTADO.IID;
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

                    if (dr["NOMBRES"] != System.DBNull.Value)
                    {
                        retorno.INOMBRES = (string)(dr["NOMBRES"]);
                    }

                    if (dr["APELLIDOS"] != System.DBNull.Value)
                    {
                        retorno.IAPELLIDOS = (string)(dr["APELLIDOS"]);
                    }

                    if (dr["DOMICILIO"] != System.DBNull.Value)
                    {
                        retorno.IDOMICILIO = (string)(dr["DOMICILIO"]);
                    }

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }

                    if (dr["CIUDAD"] != System.DBNull.Value)
                    {
                        retorno.ICIUDAD = (string)(dr["CIUDAD"]);
                    }

                    if (dr["MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IMUNICIPIO = (string)(dr["MUNICIPIO"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (string)(dr["ESTADO"]);
                    }

                    if (dr["PAIS"] != System.DBNull.Value)
                    {
                        retorno.IPAIS = (string)(dr["PAIS"]);
                    }

                    if (dr["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = (string)(dr["CODIGOPOSTAL"]);
                    }

                    if (dr["TELEFONO1"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO1 = (string)(dr["TELEFONO1"]);
                    }

                    if (dr["CELULAR"] != System.DBNull.Value)
                    {
                        retorno.ICELULAR = (string)(dr["CELULAR"]);
                    }

                    if (dr["EMAIL1"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL1 = (string)(dr["EMAIL1"]);
                    }

                    if (dr["SALDOAPARTADO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADO = (decimal)(dr["SALDOAPARTADO"]);
                    }

                    if (dr["SALDOAPARTADOPOSITIVO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADOPOSITIVO = (decimal)(dr["SALDOAPARTADOPOSITIVO"]);
                    }

                    if (dr["SALDOAPARTADONEGATIVO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADONEGATIVO = (decimal)(dr["SALDOAPARTADONEGATIVO"]);
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
        public DataSet enlistarPERSONAAPARTADO()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERSONAAPARTADO_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoPERSONAAPARTADO()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERSONAAPARTADO_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExistePERSONAAPARTADO(CPERSONAAPARTADOBE oCPERSONAAPARTADO, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;

            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPERSONAAPARTADO.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PERSONAAPARTADO where

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
                this.iComentario = e.Message + e.StackTrace;
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return -1;
            }
        }




        public CPERSONAAPARTADOBE AgregarPERSONAAPARTADO(CPERSONAAPARTADOBE oCPERSONAAPARTADO, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONAAPARTADO(oCPERSONAAPARTADO, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PERSONAAPARTADO ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPERSONAAPARTADOD(oCPERSONAAPARTADO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPERSONAAPARTADO(CPERSONAAPARTADOBE oCPERSONAAPARTADO, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONAAPARTADO(oCPERSONAAPARTADO, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERSONAAPARTADO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPERSONAAPARTADOD(oCPERSONAAPARTADO, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPERSONAAPARTADO(CPERSONAAPARTADOBE oCPERSONAAPARTADONuevo, CPERSONAAPARTADOBE oCPERSONAAPARTADOAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONAAPARTADO(oCPERSONAAPARTADOAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERSONAAPARTADO no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPERSONAAPARTADOD(oCPERSONAAPARTADONuevo, oCPERSONAAPARTADOAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }





        public CPERSONAAPARTADOD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }
    }
}
