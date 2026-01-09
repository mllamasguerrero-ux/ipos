using ConexionesBD;
using DataLayer.Movil.businessEntity.MOVILANDROID;
using FirebirdSql.Data.FirebirdClient;
using iPosBusinessEntity;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Movil.businessData.MOVILANDROID
{
    public class CMCLIPDROIDD
    {
        private string iComentario;
        private string sCadenaConexion;
        private List<CCLIPDROIDBE> clientes;
        private const string conexion = @"User = SYSDBA; 
                                Password = masterkey; 
                                Database = C:\IposProject\iPosRopa\iPos\iPos\bin\Debug\sampdata\VENMOVDROID.fdb; 
                                DataSource = localhost;";

        public CMCLIPDROIDD()
        {
            sCadenaConexion = ConexionBD.ConexionString();
            clientes = new List<CCLIPDROIDBE>();
        }

        public CMCLIPDROIDD(string conexion)
        {
            sCadenaConexion = conexion;
            clientes = new List<CCLIPDROIDBE>();
        }

        public string IComentario { get => iComentario; set => iComentario = value; }

        public void FijarRegistros(List<CPERSONABE> personas, long tipoVendedor)
        {
            foreach (CPERSONABE persona in personas)
            {
                CCLIPDROIDBE item = ConvertirAClienteDroid(persona, tipoVendedor);
                clientes.Add(item);
            }
        }

        private string ConvertirClaveClienteAClaveClienteDroid(string customerClave)
        {
            string clipClave = "";

            if (customerClave.Trim().Length <= 6)
                return customerClave.Trim().PadLeft(6);


            int iStartIndex = customerClave.IndexOfAny("0123456789".ToCharArray());
            if (iStartIndex > -1 && iStartIndex < 5)
            {
                string strSubString1 = customerClave.Substring(0, iStartIndex);
                string strSubString2 = customerClave.Substring(iStartIndex, customerClave.Length - iStartIndex);
                strSubString2 = strSubString2.TrimStart("0".ToCharArray()).PadLeft(6 - iStartIndex, '0');

                clipClave = strSubString1 + strSubString2;
            }
            else
            {
                clipClave = "LARGOO";
            }

            return clipClave;
        }

        private CCLIPDROIDBE ConvertirAClienteDroid(CPERSONABE c, long tipoVendedor)
        {
            CCLIPDROIDBE retorno = new CCLIPDROIDBE();

            if (!(bool)c.isnull["ICLAVE"])
            {
                if (tipoVendedor != 2 && tipoVendedor != 3)
                {
                    retorno.Clave = ConvertirClaveClienteAClaveClienteDroid(c.ICLAVE);
                }
                else
                {
                    retorno.Clave = c.ICLAVE;
                }
            }

            if (!(bool)c.isnull["INOMBRE"])
                retorno.Nombre = c.INOMBRE;

            if (!(bool)c.isnull["INOMBRES"])
                retorno.Nombres = c.INOMBRES;

            if (!(bool)c.isnull["IAPELLIDOS"])
                retorno.Apellidos = c.IAPELLIDOS;

            if (!(bool)c.isnull["IDOMICILIO"])
                retorno.Domicilio = c.IDOMICILIO;

            if (!(bool)c.isnull["ICOLONIA"])
                retorno.Colonia = c.ICOLONIA;

            if (!(bool)c.isnull["ICIUDAD"])
                retorno.Ciudad = c.ICIUDAD;

            if (!(bool)c.isnull["IESTADO"])
                retorno.Estado = c.IESTADO;

            if (!(bool)c.isnull["ICODIGOPOSTAL"])
                retorno.CodigoPostal = c.ICODIGOPOSTAL;

            if (!(bool)c.isnull["ITELEFONO1"])
                retorno.Telefono1 = c.ITELEFONO1;
            if (!(bool)c.isnull["ITELEFONO2"])
                retorno.Telefono2 = c.ITELEFONO2;

            if (!(bool)c.isnull["ICONTACTO1"])
                retorno.Contacto1 = c.ICONTACTO1;

            if (!(bool)c.isnull["ICONTACTO2"])
                retorno.Contacto2 = c.ICONTACTO2;

            if (!(bool)c.isnull["IRFC"])
                retorno.Rfc = c.IRFC;

            if (!(bool)c.isnull["ILISTAPRECIOID"])
                retorno.ListaPrecioId = c.ILISTAPRECIOID.ToString();

            if (!(bool)c.isnull["ILIMITECREDITO"])
                retorno.LimiteCredito = Double.Parse(c.ILIMITECREDITO.ToString());

            if (!(bool)c.isnull["IBLOQUEADO"])
                retorno.Bloqueado = c.IBLOQUEADO;

            if (!(bool)c.isnull["IDIAS"])
                retorno.Dias = Double.Parse(c.IDIAS.ToString());

            if (!(bool)c.isnull["IEMAIL1"])
                retorno.Email1 = c.IEMAIL1;

            if (!(bool)c.isnull["IPAGOS"])
                retorno.DiaPago = c.IPAGOS;

            if (!(bool)c.isnull["ISALDO"])
                retorno.Saldo = Double.Parse(c.ISALDO.ToString());

            if (!(bool)c.isnull["IBLOQUEONOT"])
                retorno.Bloqueado = c.IBLOQUEONOT;

            retorno.VendedorId = String.Empty;

            if (!(bool)c.isnull["IMEMO"])
                retorno.Calles = c.IMEMO;

            if (!(bool)c.isnull["IEMAIL2"])
                retorno.Email2 = c.IEMAIL2;


            if (!(bool)c.isnull["IDESGLOSEIEPS"])
                retorno.CuentaIeps = c.IDESGLOSEIEPS;

            if (!(bool)c.isnull["INUMEROEXTERIOR"])
                retorno.NumeroExterior = c.INUMEROEXTERIOR;

            if (!(bool)c.isnull["INUMEROINTERIOR"])
                retorno.NumeroInterior = c.INUMEROINTERIOR;

            return retorno;
        }

        public bool LimpiarTabla(FbTransaction st)
        {
            try
            {
                ArrayList parts = new ArrayList();

                string commandText = @"DELETE FROM MCLIPDROID;";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);

                return true;
            }
            catch (Exception e)
            {
                iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool InsertarCliente(CCLIPDROIDBE cliente, FbTransaction st)
        {
            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = cliente.Clave;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                auxPar.Value = cliente.Nombre;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRES", FbDbType.VarChar);
                auxPar.Value = cliente.Nombres;
                parts.Add(auxPar);

                auxPar = new FbParameter("@APELLIDOS", FbDbType.VarChar);
                auxPar.Value = cliente.Apellidos;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOMICILIO", FbDbType.VarChar);
                auxPar.Value = cliente.Domicilio;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TELEFONO1", FbDbType.VarChar);
                auxPar.Value = cliente.Telefono1;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TELEFONO2", FbDbType.VarChar);
                auxPar.Value = cliente.Telefono2;
                parts.Add(auxPar);

                auxPar = new FbParameter("@RFC", FbDbType.VarChar);
                auxPar.Value = cliente.Rfc;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDO", FbDbType.Decimal);
                auxPar.Value = cliente.Saldo;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CIUDAD", FbDbType.VarChar);
                auxPar.Value = cliente.Ciudad;
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDOR_ID", FbDbType.VarChar);
                auxPar.Value = cliente.VendedorId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGO_POSTAL", FbDbType.VarChar);
                auxPar.Value = cliente.CodigoPostal;
                parts.Add(auxPar);

                auxPar = new FbParameter("@LISTA_PRECIOID", FbDbType.VarChar);
                auxPar.Value = cliente.ListaPrecioId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@LIMITE_CREDITO", FbDbType.Decimal);
                auxPar.Value = cliente.LimiteCredito;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DIAS", FbDbType.BigInt);
                auxPar.Value = cliente.Dias;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CALLES", FbDbType.VarChar);
                auxPar.Value = cliente.Calles;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CONTACTO1", FbDbType.VarChar);
                auxPar.Value = cliente.Contacto1;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CONTACTO2", FbDbType.VarChar);
                auxPar.Value = cliente.Contacto2;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMAIL1", FbDbType.VarChar);
                auxPar.Value = cliente.Email1;
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMAIL2", FbDbType.VarChar);
                auxPar.Value = cliente.Email2;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SERIE", FbDbType.VarChar);
                auxPar.Value = cliente.Serie;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAIS", FbDbType.VarChar);
                auxPar.Value = cliente.Pais;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADO", FbDbType.VarChar);
                auxPar.Value = cliente.Estado;
                parts.Add(auxPar);

                auxPar = new FbParameter("@COLONIA", FbDbType.VarChar);
                auxPar.Value = cliente.Colonia;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO_INTERIOR", FbDbType.VarChar);
                auxPar.Value = cliente.NumeroInterior;
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMERO_EXTERIOR", FbDbType.VarChar);
                auxPar.Value = cliente.NumeroExterior;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CUENTA_IEPS", FbDbType.VarChar);
                auxPar.Value = cliente.CuentaIeps;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SERVICIO_DOMICILIO", FbDbType.VarChar);
                auxPar.Value = cliente.ServicioDomicilio;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PLAZO", FbDbType.VarChar);
                auxPar.Value = cliente.Plazo;
                parts.Add(auxPar);

                auxPar = new FbParameter("@PRECIO", FbDbType.VarChar);
                auxPar.Value = cliente.Precio;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DIAPAGO", FbDbType.VarChar);
                auxPar.Value = cliente.DiaPago;
                parts.Add(auxPar);

                auxPar = new FbParameter("@REVISION", FbDbType.VarChar);
                auxPar.Value = cliente.Revision;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TARJETA", FbDbType.VarChar);
                auxPar.Value = cliente.Tarjeta;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CREDITO", FbDbType.VarChar);
                auxPar.Value = cliente.Credito;
                parts.Add(auxPar);

                auxPar = new FbParameter("@CHEQUE", FbDbType.VarChar);
                auxPar.Value = cliente.Cheque;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TRANSFERENCIA", FbDbType.VarChar);
                auxPar.Value = cliente.Transferencia;
                parts.Add(auxPar);

                auxPar = new FbParameter("@BLOQUEADO", FbDbType.VarChar);
                auxPar.Value = cliente.Bloqueado;
                parts.Add(auxPar);

                string commandText = @"INSERT INTO MCLIPDROID(
                                            CLAVE,
                                            NOMBRE,
                                            NOMBRES,
                                            APELLIDOS,
                                            DOMICILIO,
                                            TELEFONO1,
                                            TELEFONO2,
                                            RFC,
                                            SALDO,
                                            CIUDAD,
                                            VENDEDOR_ID,
                                            CODIGO_POSTAL,
                                            LISTA_PRECIOID,
                                            LIMITE_CREDITO,
                                            DIAS,
                                            CALLES,
                                            CONTACTO1,
                                            CONTACTO2,
                                            EMAIL1,
                                            EMAIL2,
                                            SERIE,
                                            PAIS,
                                            ESTADO,
                                            COLONIA,
                                            NUMERO_INTERIOR,
                                            NUMERO_EXTERIOR,
                                            CUENTA_IEPS,
                                            SERVICIO_DOMICILIO,
                                            PLAZO,
                                            PRECIO,
                                            DIAPAGO,
                                            REVISION,
                                            TARJETA,
                                            CREDITO,
                                            CHEQUE,
                                            TRANSFERENCIA,
                                            BLOQUEADO
                                       )
                                       Values(
                                            @CLAVE,
                                            @NOMBRE,
                                            @NOMBRES,
                                            @APELLIDOS,
                                            @DOMICILIO,
                                            @TELEFONO1,
                                            @TELEFONO2,
                                            @RFC,
                                            @SALDO,
                                            @CIUDAD,
                                            @VENDEDOR_ID,
                                            @CODIGO_POSTAL,
                                            @LISTA_PRECIOID,
                                            @LIMITE_CREDITO,
                                            @DIAS,
                                            @CALLES,
                                            @CONTACTO1,
                                            @CONTACTO2,
                                            @EMAIL1,
                                            @EMAIL2,
                                            @SERIE,
                                            @PAIS,
                                            @ESTADO,
                                            @COLONIA,
                                            @NUMERO_INTERIOR,
                                            @NUMERO_EXTERIOR,
                                            @CUENTA_IEPS,
                                            @SERVICIO_DOMICILIO,
                                            @PLAZO,
                                            @PRECIO,
                                            @DIAPAGO,
                                            @REVISION,
                                            @TARJETA,
                                            @CREDITO,
                                            @CHEQUE,
                                            @TRANSFERENCIA,
                                            @BLOQUEADO
                                        ); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;

            }
            catch (Exception e)
            {
                iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

        public bool LlenarTabla(List<CPERSONABE> registros, long tipoVendedor)
        {
            FbConnection fbConnection = new FbConnection(conexion);
            FbTransaction fbTransaction = null;
            bool retorno;

            sCadenaConexion = conexion;
            try
            {
                fbConnection.Open();
                fbTransaction = fbConnection.BeginTransaction();

                if (!LimpiarTabla(null))
                    throw new Exception(iComentario);

                FijarRegistros(registros, tipoVendedor);

                foreach (CCLIPDROIDBE cliente in clientes)
                {
                    if (!InsertarCliente(cliente, fbTransaction))
                        throw new Exception(iComentario);
                }

                fbTransaction.Commit();

                retorno = true;
            }
            catch (Exception e)
            {
                fbTransaction.Rollback();
                iComentario = e.Message;
                retorno = false;
            }
            finally
            {
                fbConnection.Close();
            }

            return retorno;
        }
    }
}
