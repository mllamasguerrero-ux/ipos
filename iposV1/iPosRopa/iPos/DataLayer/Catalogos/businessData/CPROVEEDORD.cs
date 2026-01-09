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
    public class CPROVEEDORD: CPERSONAD
    {

        [AutoComplete]
        public bool CambiarPROVEEDORD(CPERSONABE oCPERSONANuevo, CPERSONABE oCPERSONAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPERSONANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPERSONANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCPERSONANuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPERSONANuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCPERSONANuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MEMO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IMEMO"])
                {
                    auxPar.Value = oCPERSONANuevo.IMEMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALUDOID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ISALUDOID"])
                {
                    auxPar.Value = oCPERSONANuevo.ISALUDOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRES", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["INOMBRES"])
                {
                    auxPar.Value = oCPERSONANuevo.INOMBRES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@APELLIDOS", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IAPELLIDOS"])
                {
                    auxPar.Value = oCPERSONANuevo.IAPELLIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RAZONSOCIAL", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IRAZONSOCIAL"])
                {
                    auxPar.Value = oCPERSONANuevo.IRAZONSOCIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RFC", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IRFC"])
                {
                    auxPar.Value = oCPERSONANuevo.IRFC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CONTACTO1", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICONTACTO1"])
                {
                    auxPar.Value = oCPERSONANuevo.ICONTACTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CONTACTO2", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCPERSONANuevo.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOMICILIO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IDOMICILIO"])
                {
                    auxPar.Value = oCPERSONANuevo.IDOMICILIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COLONIA", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCPERSONANuevo.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CIUDAD", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCPERSONANuevo.ICIUDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MUNICIPIO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IMUNICIPIO"])
                {
                    auxPar.Value = oCPERSONANuevo.IMUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IESTADO"])
                {
                    auxPar.Value = oCPERSONANuevo.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAIS", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IPAIS"])
                {
                    auxPar.Value = oCPERSONANuevo.IPAIS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGOPOSTAL", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICODIGOPOSTAL"])
                {
                    auxPar.Value = oCPERSONANuevo.ICODIGOPOSTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TELEFONO1", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ITELEFONO1"])
                {
                    auxPar.Value = oCPERSONANuevo.ITELEFONO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TELEFONO2", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ITELEFONO2"])
                {
                    auxPar.Value = oCPERSONANuevo.ITELEFONO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TELEFONO3", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ITELEFONO3"])
                {
                    auxPar.Value = oCPERSONANuevo.ITELEFONO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CELULAR", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICELULAR"])
                {
                    auxPar.Value = oCPERSONANuevo.ICELULAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NEXTEL", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["INEXTEL"])
                {
                    auxPar.Value = oCPERSONANuevo.INEXTEL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMAIL1", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IEMAIL1"])
                {
                    auxPar.Value = oCPERSONANuevo.IEMAIL1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMAIL2", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IEMAIL2"])
                {
                    auxPar.Value = oCPERSONANuevo.IEMAIL2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMPRESAID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IEMPRESAID"])
                {
                    auxPar.Value = oCPERSONANuevo.IEMPRESAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCPERSONANuevo.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ILISTAPRECIOID"])
                {
                    auxPar.Value = oCPERSONANuevo.ILISTAPRECIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VIGENCIA", FbDbType.Date);
                if (!(bool)oCPERSONANuevo.isnull["IVIGENCIA"])
                {
                    auxPar.Value = oCPERSONANuevo.IVIGENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DIAS", FbDbType.Integer);
                if (!(bool)oCPERSONANuevo.isnull["IDIAS"])
                {
                    auxPar.Value = oCPERSONANuevo.IDIAS;
                }
                else
                {
                    auxPar.Value = "0";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REVISION", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IREVISION"])
                {
                    auxPar.Value = oCPERSONANuevo.IREVISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGOS", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IPAGOS"])
                {
                    auxPar.Value = oCPERSONANuevo.IPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);







                auxPar = new FbParameter("@EMAIL3", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IEMAIL3"])
                {
                    auxPar.Value = oCPERSONANuevo.IEMAIL3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMAIL4", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IEMAIL4"])
                {
                    auxPar.Value = oCPERSONANuevo.IEMAIL4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESIMPORTADOR", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IESIMPORTADOR"])
                {
                    auxPar.Value = oCPERSONANuevo.IESIMPORTADOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVE_PAIS", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ISAT_CLAVE_PAIS"])
                {
                    auxPar.Value = oCPERSONANuevo.ISAT_CLAVE_PAIS;
                }
                else
                {
                    auxPar.Value = "MEX";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PROVEECLIENTEID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IPROVEECLIENTEID"])
                {
                    auxPar.Value = oCPERSONANuevo.IPROVEECLIENTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ADESCPES", FbDbType.Numeric);
                if (!(bool)oCPERSONANuevo.isnull["IADESCPES"])
                {
                    auxPar.Value = oCPERSONANuevo.IADESCPES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPERSONAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPERSONAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"  
update  PERSONA
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

DESCRIPCION=@DESCRIPCION,

MEMO=@MEMO,

SALUDOID=@SALUDOID,

NOMBRES=@NOMBRES,

APELLIDOS=@APELLIDOS,

RAZONSOCIAL=@RAZONSOCIAL,

RFC=@RFC,

CONTACTO1=@CONTACTO1,

CONTACTO2=@CONTACTO2,

DOMICILIO=@DOMICILIO,

COLONIA=@COLONIA,

CIUDAD=@CIUDAD,

MUNICIPIO=@MUNICIPIO,

ESTADO=@ESTADO,

PAIS=@PAIS,

CODIGOPOSTAL=@CODIGOPOSTAL,

TELEFONO1=@TELEFONO1,

TELEFONO2=@TELEFONO2,

TELEFONO3=@TELEFONO3,

CELULAR=@CELULAR,

NEXTEL=@NEXTEL,

EMAIL1=@EMAIL1,

EMAIL2=@EMAIL2,

EMPRESAID=@EMPRESAID,

VENDEDORID=@VENDEDORID,

LISTAPRECIOID=@LISTAPRECIOID,

VIGENCIA=@VIGENCIA,

DIAS = @DIAS,

REVISION = @REVISION,

PAGOS = @PAGOS,

EMAIL3=@EMAIL3,

EMAIL4=@EMAIL4,

ESIMPORTADOR = @ESIMPORTADOR,

SAT_CLAVE_PAIS = @SAT_CLAVE_PAIS,

PROVEECLIENTEID = @PROVEECLIENTEID,

ADESCPES = @ADESCPES

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



        public DataTable getProveedoresNombres()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text, "select nombre, clave from persona where tipopersonaid = 40 order by nombre");

                return retorno.Tables[0];
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }



    }
}
