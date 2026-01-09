using Controllers.Controller;
using FirebirdSql.Data.FirebirdClient;
using IposV3.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services
{

    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class FirebirdMigrationHelper
    {

        public static void FirebirdPreparaciones()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        public static void ImportarDatosDeFirebird(bool importarCatalogos, bool importarTransacciones,
                                        bool importartInformacionEmpresa,
                                       long empresaId, long sucursalId,
                                       string fbCadenaConexion_char850, string fbCadenaConexion_chardefault,
                                       ApplicationDbContext dbContext,
                                       UsuarioController usuarioController, ClienteController clienteController,
                                       ProveedorController proveedorController, ProductoController productoController,
                                       Sucursal_infoController sucursal_infoController, PromocionController promocionController,
                                       KitdefinicionController kitdefinicionController, ParametroController parametroController)
        {
            long? doctoId = null;



            if (importartInformacionEmpresa)
            {


                //new GrupousuarioImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "grupousuario", null, dbContext);


                //new UsuarioImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     null,
                //                                                      dbContext, usuarioController);


                //new Sucursal_infoImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     null,
                //                                                      dbContext, sucursal_infoController);

            }

            if (importarCatalogos)
            {
                //new MarcaImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "marca", null, dbContext);

                //new ContenidoImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "contenido", null, dbContext);

                //new ClasificaImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_chardefault, "clasifica", null, dbContext);

                //new AlmacenImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "almacen", null, dbContext);

                //new RutaembarqueImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "rutaembarque", null, dbContext);

                //new GruposucursalImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "gruposucursal", null, dbContext);


                //new AnaquelImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     "select a.*, m.clave ALMACENCLAVE from anaquel a left join almacen m on a.almacenid = m.id"
                //                                                     , dbContext);


                new PlazoImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                                                                     null, fbCadenaConexion_chardefault, null,
                                                                     "select a.*, m.clave ALMACENCLAVE from plazo a left join almacen m on a.almacenid = m.id"
                                                                     , dbContext);


                //new UnidadImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     "select u.*, s.sat_clave SAT_UNIDADMEDIDACLAVE from unidad u left join sat_unidadmedida s on u.sat_unidadmedidaid = s.id"
                //                                                     , dbContext);


                //new LineaImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "linea", null, dbContext);

                //new CajaImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "caja", null, dbContext);

                //new CuentaImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     "select c.*, tl.clave TIPOLINEAPOLIZACLAVE, tle.clave  TIPOLINEAPOLIZAESPECIALCLAVE," +
                //                                                     " fps.clave FORMAPAGOSATCLAVE " +
                //                                                     " from cuenta c " +
                //                                                     " left join tipolineapoliza tl on c.TIPOLINEAPOLIZAID = tl.id " +
                //                                                     " left join tipolineapoliza tle on c.TIPOLINEAPOLIZAESPECIALID = tle.id " +
                //                                                     " left join formapagosat fps on c.FORMAPAGOSATID = fps.id ",
                //                                                      dbContext);

                //new ClerkpagoservicioImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "clerkpagoservicio", null, dbContext);

                //new GastoImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     "select g.*, c.clave CUENTACLAVE from gasto g left join cuenta c on g.cuentaid = c.id",
                //                                                      dbContext);

                //new MerchantpagoservicioImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "merchantpagoservicio", null, dbContext);

                //new SubtipoclienteImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "subtipocliente", null, dbContext);

                //new TasaivaImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "tasaiva", null, dbContext);

                //new TasaiepsImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     "select t.*, " +
                //                                                     " (coalesce(t.gpoimp,'') || cast(t.tasa as varchar(30))) as CLAVE, " +
                //                                                     " (coalesce(t.gpoimp,'') || cast(t.tasa as varchar(30))) as NOMBRE " +
                //                                                     " from tasasieps t", dbContext);

                //new TerminalpagoservicioImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "terminalpagoservicio", null, dbContext);

                //new TipodiferenciainventarioImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                      "select t.*, g.clave GRUPODIFERENCIAINVENTARIOCLAVE " +
                //                                                      " from tipodiferenciainventario t left join grupodiferenciainventario g on t.grupodiferenciainventarioid = g.id  ", dbContext);






                //new ClienteImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     null,
                //                                                      dbContext, clienteController);


                //new ProveedorImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     null,
                //                                                      dbContext, proveedorController);


                //new ProductoImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_chardefault, null,
                //                                                     null,
                //                                                      dbContext, productoController);

                //new Sucursal_infoImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     null,
                //                                                      dbContext, sucursal_infoController);


                //new PromocionImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     null,
                //                                                      dbContext, promocionController);


                //new KitdefinicionImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     null,
                //                                                      dbContext, kitdefinicionController);



                //new TipotransaccionImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "tipotransaccion", null, dbContext);

                //new CuentabancoImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                      "select c.*, c.nombre as CLAVE, b.clave BANCOCLAVE " +
                //                                                      " from cuentabanco c left join bancos b on c.bancoid = b.id  ",
                //                                                     dbContext);

                //new ListaprecioImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "listaprecio", null, dbContext);


                //new ListapreciodetalleImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     "select lpd.*, lp.clave LISTAPRECIOCLAVE, p.clave PRODUCTOCLAVE " +
                //                                                     "from listapreciodetalle lpd left join listaprecio lp on lpd.listaprecioid = lp.id " +
                //                                                     "left join producto p on lpd.productoid = p.id", dbContext);

                //new MaxfactImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "maxfact", null, dbContext);

                //new PerfilesImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     "select p.*, p.pf_descripcion CLAVE, 'S' ACTIVO, p.pf_descripcion NOMBRE, p.pf_descripcion DESCRIPCION   from perfiles  p",
                //                                                     dbContext);

                //new Perfil_derImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     "select pd.*, p.pf_descripcion PERFILCLAVE, d.dr_descripcion DERECHOCLAVE " +
                //                                                     "from perfil_der pd left join perfiles p on pd.pd_perfil = p.pf_perfil " +
                //                                                     "left join derechos d on pd.pd_derecho = d.dr_derecho", dbContext);

                //new ProductolocationsImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     "select pl.*, p.clave PRODUCTOCLAVE, al.clave ALMACENCLAVE, an.clave ANAQUELCLAVE " +
                //                                                     "from productolocations pl left join producto p on pl.productoid = p.id " +
                //                                                     "left join almacen al on pl.almacenid = al.id      " +
                //                                                     "left join anaquel an on pl.anaquelid = an.id",
                //                                                     dbContext);


                //new AreaImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, "area", null, dbContext);

                //new Motivo_camfecImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     "select m.*, m.clave as NOMBRE from motivo_camfec  m",
                //                                                     dbContext);

                //ImportarMarcas(fbCadenaConexion_char850, empresaId, sucursalId, dbContext);
            }

            if (importartInformacionEmpresa)
            {


                //new ParametroImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     null,
                //                                                      dbContext, parametroController);

                //new PersonafiguraImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     "select pf.*, sft.clave SAT_FIGURATRANSPORTECLAVE, spt.clave SAT_PARTETRANSPORTECLAVE," +
                //                                                     " CASE WHEN COALESCE(P.USERNAME,'') = '' THEN '___' || CAST(P.ID AS VARCHAR(16)) ELSE P.USERNAME END USUARIOCLAVE " +
                //                                                     " from personafigura pf " +
                //                                                     " left join sat_figuratransporte sft on pf.SAT_FIGURATRANSPORTEID = sft.id " +
                //                                                     " left join SAT_PARTETRANSPORTE spt on pf.SAT_PARTETRANSPORTEID = spt.id " +
                //                                                     " left join persona p on pf.PERSONAID = p.id ",
                //                                                      dbContext);



                //new VehiculoImpoExpoService().ImportarDeTablaFirebird(empresaId, sucursalId, null, ref doctoId,
                //                                                     null, fbCadenaConexion_char850, null,
                //                                                     "select v.*, stp.clave SAT_TIPOPERMISOCLAVE, " +
                //                                                     " sca.clave SAT_CONFIGAUTOTRANSPORTECLAVE, " +
                //                                                     " str1.clave SAT_SUBTIPOREM1CLAVE, " +
                //                                                     " str2.clave SAT_SUBTIPOREM2CLAVE, " +
                //                                                     " p.NOMBRE DUENIOCLAVE " +
                //                                                     " from vehiculo v " +
                //                                                     " left join SAT_TIPOPERMISO stp on v.SAT_TIPOPERMISOID = stp.id " +
                //                                                     " left join SAT_CONFIGAUTOTRANSPORTE sca on v.SAT_CONFIGAUTOTRANSPORTEID = sca.id " +
                //                                                     " left join SAT_SUBTIPOREM str1 on v.SAT_SUBTIPOREM1ID = str1.id " +
                //                                                     " left join SAT_SUBTIPOREM str2 on v.SAT_SUBTIPOREM2ID = str2.id " +
                //                                                     " left join persona p on V.DUENIOID = p.id ",
                //                                                      dbContext);


            }


        }

        //public static string Encode(string text)
        //{

        //    string strBuffer = "�";
        //    var encodingx = Encoding.GetEncoding(850);
        //    var encodingA = Encoding.ASCII;
        //    byte[] b1 = encodingA.GetBytes(strBuffer);
        //    byte[] b2 = Encoding.Convert(encodingA, encodingx, b1);
        //    var text1 =  encodingx.GetString(b1);


        //    // encode the string as an ASCII byte array
        //    byte[] myASCIIBytes = ASCIIEncoding.ASCII.GetBytes(text);

        //    // convert the ASCII byte array to a UTF-8 byte array
        //    byte[] myUTF8Bytes = ASCIIEncoding.Convert(ASCIIEncoding.ASCII, UTF8Encoding.UTF8, myASCIIBytes);

        //    // reconstitute a string from the UTF-8 byte array 
        //    return UTF8Encoding.UTF8.GetString(myUTF8Bytes);
        //    //return ASCIIEncoding.Latin1.GetString(myUTF8Bytes);
        //}

        //public static void ImportarMarcas(string fbCadenaConexion, long empresaId, long sucursalId, ApplicationDbContext dbContext)
        //{
        //    /**/
        //    FbDataReader? dr = null;
        //    FbConnection? pcn = null;

        //    var utf8 = new UTF8Encoding();

        //    try
        //    {

        //        System.Collections.ArrayList parts = new ArrayList();

        //        String CmdTxt = @"select * from MARCA where clave = '414'  ";

        //        FbParameter[] arParms = new FbParameter[parts.Count];
        //        parts.CopyTo(arParms, 0);


        //        dr = FbSqlHelper.ExecuteReader(fbCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);


        //        while (dr.Read())
        //        {

        //            var marca = new Marca();

        //            marca.EmpresaId= empresaId;
        //            marca.SucursalId = sucursalId;

        //            marca.Creado = DateTimeOffset.UtcNow;
        //            marca.Modificado= DateTimeOffset.UtcNow;


        //            if (dr["ACTIVO"] != System.DBNull.Value)
        //            {
        //                marca.Activo = ((string)(dr["ACTIVO"])) == "S" ? BoolCS.S : BoolCS.N;
        //            }

        //            if (dr["CLAVE"] != System.DBNull.Value)
        //            {
        //                marca.Clave = (string)(dr["CLAVE"]);
        //            }

        //            if (dr["NOMBRE"] != System.DBNull.Value)
        //            {
        //                marca.Nombre = (string)(dr["NOMBRE"]);
        //            }

        //            if (dr["DESCONTINUADO"] != System.DBNull.Value)
        //            {
        //                marca.Descontinuado = ((string)(dr["DESCONTINUADO"])) == "S" ? BoolCN.S : BoolCN.N; 
        //            }

        //            dbContext.Marca.Add(marca);

        //        }
        //        dbContext.SaveChanges();
        //        FbSqlHelper.CloseReader(dr, pcn);




        //    }
        //    catch (Exception e)
        //    {
        //        FbSqlHelper.CloseReader(dr, pcn);
        //        Console.WriteLine(e.Message);
        //    }



        //}

        //public static byte[] ObjectToByteArray(Object obj)
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    using (var ms = new MemoryStream())
        //    {
        //        bf.Serialize(ms, obj);
        //        return ms.ToArray();
        //    }
        //}

    }


    public class FbSqlHelper
    {

        private enum FbConnectionOwnership
        {

            Internal,

            External
        }

        public static FbDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, out FbConnection? connection, params FbParameter[] commandParameters)
        {
            connection = null;
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            try
            {
                connection = new FbConnection(connectionString);
                connection.Open();

                return ExecuteReader(connection, null, commandType, commandText, commandParameters, FbConnectionOwnership.Internal);
            }
            catch (Exception ex)
            {

                if (connection != null) connection.Close();
                throw;
            }
        }

        private static FbDataReader ExecuteReader(FbConnection connection, FbTransaction? transaction, CommandType commandType, string commandText, FbParameter[] commandParameters, FbConnectionOwnership connectionOwnership)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            bool mustCloseConnection = false;

            FbCommand cmd = new FbCommand();
            try
            {
                PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

                FbDataReader dataReader;

                if (connectionOwnership == FbConnectionOwnership.External)
                {
                    dataReader = cmd.ExecuteReader();
                }
                else
                {
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }





                bool canClear = true;
                foreach (FbParameter commandParameter in cmd.Parameters)
                {
                    if (commandParameter.Direction != ParameterDirection.Input)
                        canClear = false;
                }
                if (canClear)
                {
                    cmd.Parameters.Clear();
                }
                return dataReader;
            }
            catch
            {
                if (mustCloseConnection)
                    connection.Close();
                throw;
            }
        }


        private static void PrepareCommand(FbCommand command, FbConnection connection, FbTransaction? transaction, CommandType commandType, string commandText, FbParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            command.Connection = connection;

            command.CommandText = commandText;

            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            command.CommandType = commandType;

            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }


        private static void AttachParameters(FbCommand command, FbParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (FbParameter p in commandParameters)
                {
                    if (p != null)
                    {

                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        public static void CloseReader(FbDataReader dr, FbConnection pcn)
        {
            if (dr != null && !dr.IsClosed)
            {

                dr.Close();
            }

            if (pcn != null /*&& pcn.State != ConnectionState.Closed*/)
            {
                pcn.Close();
            }
        }

    }
}
