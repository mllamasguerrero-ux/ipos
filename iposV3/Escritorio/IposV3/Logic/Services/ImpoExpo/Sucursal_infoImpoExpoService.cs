
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Collections;
using System.Data.Common;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using FirebirdSql.Data.FirebirdClient;
using Controllers.Controller;
using BindingModels;
using System.Data;

namespace IposV3.Services
{



    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class Sucursal_infoImpoExpoService : BaseImpoExpoService
    {






        public override IQueryable<List<ImpoExpoValor>>? ObtainImpoExpoValores(long empresaId, long sucursalId, ApplicationDbContext localContext)
        {
            var exportValores = localContext.Sucursal_info.AsNoTracking()
                                                 .Include(x => x.Sucursal_info_opciones).ThenInclude(y => y!.Gruposucursal)
                                                 .Include(x => x.Sucursal_info_opciones).ThenInclude(y => y!.Cliente)
                                                 .Include(x => x.Sucursal_info_opciones).ThenInclude(y => y!.Proveedor)
                                                 .Include(x => x.Sucursal_info_opciones).ThenInclude(y => y!.Banco)
                                                 .Include(x => x.Sucursal_info_opciones).ThenInclude(y => y!.Empprov)
                                                 .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId)
                                                 .Select(x => new List<ImpoExpoValor>(){

                                                        new ImpoExpoValor("Activo", x.Activo, BoolCS.S),
                                                        new ImpoExpoValor("Esmatriz", x.Esmatriz, BoolCN.N),
                                                        new ImpoExpoValor("Esfranquicia", x.Esfranquicia, BoolCN.N),
                                                        new ImpoExpoValor("Cuentareferencia", x.Cuentareferencia, ""),
                                                        new ImpoExpoValor("Cuentapoliza", x.Cuentapoliza, ""),
                                                        new ImpoExpoValor("Clave", x.Clave, ""),
                                                        new ImpoExpoValor("Nombre", x.Nombre, ""),
                                                        new ImpoExpoValor("Descripcion", x.Descripcion, ""),
                                                        new ImpoExpoValor("Memo", x.Memo, ""),
                                                        new ImpoExpoValor("Maxdoctospendientes", x.Maxdoctospendientes, 0),
                                                        new ImpoExpoValor("Sucursal_info_opciones_GruposucursalClave", x.Sucursal_info_opciones!.Gruposucursal!.Clave, ""),
                                                        new ImpoExpoValor("Sucursal_info_opciones_GruposucursalNombre", x.Sucursal_info_opciones.Gruposucursal.Nombre, ""),
                                                        new ImpoExpoValor("Sucursal_info_opciones_ClienteClave", x.Sucursal_info_opciones.Cliente!.Clave, ""),
                                                        new ImpoExpoValor("Sucursal_info_opciones_ClienteNombre", x.Sucursal_info_opciones.Cliente.Nombre, ""),
                                                        new ImpoExpoValor("Sucursal_info_opciones_ProveedorClave", x.Sucursal_info_opciones.Proveedor!.Clave, ""),
                                                        new ImpoExpoValor("Sucursal_info_opciones_ProveedorNombre", x.Sucursal_info_opciones.Proveedor.Nombre, ""),
                                                        new ImpoExpoValor("Sucursal_info_opciones_BancoClave", x.Sucursal_info_opciones.Banco!.Clave, ""),
                                                        new ImpoExpoValor("Sucursal_info_opciones_BancoNombre", x.Sucursal_info_opciones.Banco.Nombre, ""),
                                                        new ImpoExpoValor("Sucursal_info_opciones_EmpprovClave", x.Sucursal_info_opciones.Empprov!.Clave, ""),
                                                        new ImpoExpoValor("Sucursal_info_opciones_EmpprovNombre", x.Sucursal_info_opciones.Empprov.Nombre, ""),

                                                 });




            return exportValores;
        }

        public override List<ImpoExpoField> ObtainImpoExpoFields()
        {
            return new List<ImpoExpoField>() {

                new ImpoExpoField("Activo","activo",1,0, NpgsqlDbType.Varchar, typeof(BoolCS)),
                new ImpoExpoField("Esmatriz","esmatriz",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Esfranquicia","esfranq",1,0, NpgsqlDbType.Varchar, typeof(BoolCN)),
                new ImpoExpoField("Cuentareferencia","ctaref",64,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Cuentapoliza","ctapol",32,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Clave","clave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Nombre","nombre",127,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Descripcion","descr",254,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Memo","memo",254,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Maxdoctospendientes","maxdocpen",8,0, NpgsqlDbType.Integer, typeof(int)),
                new ImpoExpoField("Sucursal_info_opciones_GruposucursalClave","gsclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Sucursal_info_opciones_GruposucursalNombre","gsnombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Sucursal_info_opciones_ClienteClave","cteclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Sucursal_info_opciones_ClienteNombre","ctenombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Sucursal_info_opciones_ProveedorClave","prvclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Sucursal_info_opciones_ProveedorNombre","prvnombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Sucursal_info_opciones_BancoClave","bcoclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Sucursal_info_opciones_BancoNombre","bconombre",128,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Sucursal_info_opciones_EmpprovClave","empclave",31,0, NpgsqlDbType.Char, typeof(string)),
                new ImpoExpoField("Sucursal_info_opciones_EmpprovNombre","empnombre",128,0, NpgsqlDbType.Char, typeof(string)),
            };
        }

        public override bool ImportFromReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               OleDbDataReader dataReader, List<ImpoExpoField> fields, ApplicationDbContext localContext)
        {

            var clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : "";

            var bufferStr = "";

            var itemSaved = localContext.Sucursal_info
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);

            var item = itemSaved != null ? itemSaved : new Sucursal_info();
            var existItem = itemSaved != null;

	
          	item.Cuentareferencia = dataReader["ctaref"] != System.DBNull.Value ? ((string)dataReader["ctaref"]).Trim() : ""; 
          	item.Cuentapoliza = dataReader["ctapol"] != System.DBNull.Value ? ((string)dataReader["ctapol"]).Trim() : ""; 
          	item.Clave = dataReader["clave"] != System.DBNull.Value ? ((string)dataReader["clave"]).Trim() : ""; 
          	item.Nombre = dataReader["nombre"] != System.DBNull.Value ? ((string)dataReader["nombre"]).Trim() : ""; 
          	item.Descripcion = dataReader["descr"] != System.DBNull.Value ? ((string)dataReader["descr"]).Trim() : ""; 
          	item.Memo = dataReader["memo"] != System.DBNull.Value ? ((string)dataReader["memo"]).Trim() : "";
            item.Esmatriz = dataReader["esmatriz"] != System.DBNull.Value && ((string)dataReader["esmatriz"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Esfranquicia = dataReader["esfranq"] != System.DBNull.Value && ((string)dataReader["esfranq"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Activo = dataReader["activo"] != System.DBNull.Value && ((string)dataReader["activo"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Maxdoctospendientes = dataReader["maxdocpen"] != System.DBNull.Value ? int.Parse(dataReader["maxdocpen"].ToString()!) : 0;


            if (item.Sucursal_info_opciones == null)
                item.Sucursal_info_opciones = new Sucursal_info_opciones() { EmpresaId = empresaId, SucursalId = sucursalId };

            bufferStr = dataReader["gsclave"] != System.DBNull.Value ? ((string)dataReader["gsclave"]).Trim() : "";
            var grupoSucursal = bufferStr == "" ? null : localContext.Gruposucursal.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Sucursal_info_opciones.Gruposucursalid = grupoSucursal?.Id;

            bufferStr = dataReader["cteclave"] != System.DBNull.Value ? ((string)dataReader["cteclave"]).Trim() : "";
            var cliente = bufferStr == "" ? null : localContext.Cliente.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Sucursal_info_opciones.Clienteid = cliente?.Id;

            bufferStr = dataReader["prvclave"] != System.DBNull.Value ? ((string)dataReader["prvclave"]).Trim() : "";
            var proveedor = bufferStr == "" ? null : localContext.Proveedor.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Sucursal_info_opciones.Proveedorid = proveedor?.Id;


            bufferStr = dataReader["bcoclave"] != System.DBNull.Value ? ((string)dataReader["bcoclave"]).Trim() : "";
            var banco = bufferStr == "" ? null : localContext.Banco.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Sucursal_info_opciones.Bancoid = banco?.Id;



            bufferStr = dataReader["empclave"] != System.DBNull.Value ? ((string)dataReader["empclave"]).Trim() : "";
            var empproveedor = bufferStr == "" ? null : localContext.Proveedor.AsNoTracking()
                                                                                  .FirstOrDefault(x => x.EmpresaId == empresaId &&
                                                                                                       x.SucursalId == sucursalId &&
                                                                                                       x.Clave == bufferStr);
            item.Sucursal_info_opciones.Empprovid = empproveedor?.Id;


            if (existItem)
                localContext.Sucursal_info.Update(item);
            else
                localContext.Sucursal_info.Add(item);

            localContext.SaveChanges();

            return true;
        }


        public void ImportarDeTablaFirebird(
                          long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                          string fbCadenaConexion,
                          string? nombreTabla, string? queryPersonalizada,
                           ApplicationDbContext localContext, Sucursal_infoController sucursal_infoController)
        {
            /**/
            FbDataReader? dr = null;
            FbConnection? pcn = null;

            var utf8 = new UTF8Encoding();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();

                String CmdTxt = @"    SELECT
        SUCURSAL.CUENTAREFERENCIA as CUENTAREFERENCIA, 
        SUCURSAL.CUENTAPOLIZA as CUENTAPOLIZA, 
        SUCURSAL.CLAVE as CLAVE, 
        SUCURSAL.NOMBRE as NOMBRE, 
        SUCURSAL.DESCRIPCION as DESCRIPCION, 
        SUCURSAL.MEMO as MEMO, 
        SUCURSAL.ENTREGACALLE as SUCURSAL_FACT_ELECT_ENTREGACALLE, 
        SUCURSAL.ENTREGANUMEROEXTERIOR as SUCURSAL_FACT_ELECT_ENTREGANUMEROEXTERIOR, 
        SUCURSAL.ENTREGANUMEROINTERIOR as SUCURSAL_FACT_ELECT_ENTREGANUMEROINTERIOR, 
        SUCURSAL.ENTREGACOLONIA as SUCURSAL_FACT_ELECT_ENTREGACOLONIA, 
        SUCURSAL.ENTREGAMUNICIPIO as SUCURSAL_FACT_ELECT_ENTREGAMUNICIPIO, 
        SUCURSAL.ENTREGACODIGOPOSTAL as SUCURSAL_FACT_ELECT_ENTREGACODIGOPOSTAL, 
        SUCURSAL.ENTREGAREFERENCIADOM as SUCURSAL_FACT_ELECT_ENTREGAREFERENCIADOM, 
        SUCURSAL.PREFIJOPRECIOXDESCUENTO as SUCURSAL_IMPORTACION_PREFIJOPRECIOXDESCUENTO, 
        SUCURSAL.RUTARESPALDOORIGEN as SUCURSAL_RESPALDO_RUTARESPALDOORIGEN, 
        SUCURSAL.RUTARESPALDODESTINO as SUCURSAL_RESPALDO_RUTARESPALDODESTINO, 
        SUCURSAL.RUTARESPALDORED as SUCURSAL_RESPALDO_RUTARESPALDORED, 
        SUCURSAL.NOMBRERESPALDOBD as SUCURSAL_RESPALDO_NOMBRERESPALDOBD, 
        SUCURSAL.ESMATRIZ as ESMATRIZ, 
        SUCURSAL.ESFRANQUICIA as ESFRANQUICIA, 
        SUCURSAL.POR_FACT_ELECT as SUCURSAL_FACT_ELECT_POR_FACT_ELECT, 
        SUCURSAL.MANEJAPRECIOXDESCUENTO as SUCURSAL_IMPORTACION_MANEJAPRECIOXDESCUENTO, 
        SUCURSAL.MOSTRARPRECIOREAL as SUCURSAL_TRASLADO_MOSTRARPRECIOREAL, 
        SUCURSAL.ACTIVO as ACTIVO, 
        SUCURSAL.CREADO as CREADO, 
        SUCURSAL.MODIFICADO as MODIFICADO, 
        SUCURSAL.ENTREGA_DISTANCIA as SUCURSAL_FACT_ELECT_ENTREGA_DISTANCIA, 
        SUCURSAL.PORC_AUMENTO_PRECIO as SUCURSAL_IMPORTACION_PORC_AUMENTO_PRECIO, 
        SUCURSAL.MAXDOCTOSPENDIENTES as MAXDOCTOSPENDIENTES, 
        SUCURSAL.PRECIORECEPCIONTRASLADO as SUCURSAL_TRASLADO_PRECIORECEPCIONTRASLADO, 
        SUCURSAL.PRECIOENVIOTRASLADO as SUCURSAL_TRASLADO_PRECIOENVIOTRASLADO, 
        SUCURSAL.LISTA_PRECIO_TRASPASO as SUCURSAL_TRASLADO_LISTA_PRECIO_TRASPASO,
        GRUPOSUCURSAL.CLAVE SUCURSAL_INFO_OPCIONES_GRUPOSUCURSALCLAVE,
        SUCURSAL.clienteclave SUCURSAL_INFO_OPCIONES_CLIENTECLAVE  ,
        SUCURSAL.proveedorclave SUCURSAL_INFO_OPCIONES_PROVEEDORCLAVE,
        SUCURSAL.bancoclave SUCURSAL_INFO_OPCIONES_BANCOCLAVE ,
        SUCURSAL.empprov SUCURSAL_INFO_OPCIONES_EMPPROVCLAVE ,
        SUCURSAL.entregaestado SUCURSAL_FACT_ELECT_ENTREGAESTADOCLAVE ,
        SAT_COLONIA.COLONIA SUCURSAL_FACT_ELECT_ENTREGA_SAT_COLONIACLAVE ,
        SAT_LOCALIDAD.clave_localidad SUCURSAL_FACT_ELECT_ENTREGA_SAT_LOCALIDADCLAVE  ,
        SAT_MUNICIPIO.clave_municipio SUCURSAL_FACT_ELECT_ENTREGA_SAT_MUNICIPIOCLAVE ,
        SUCURSAL.listaprecioclave SUCURSAL_IMPORTACION_LISTAPRECIOCLAVE ,
        SUCURSAL.surtidor SUCURSAL_IMPORTACION_SURTIDORCLAVE  ,
        TIPOPRECIORECEPCIONTRASLADO.CLAVE SUCURSAL_TRASLADO_PRECIORECEPCIONTRASLADO_CLAVE,
        TIPOPRECIOENVIOTRASLADO.CLAVE SUCURSAL_TRASLADO_PRECIOENVIOTRASLADO_CLAVE,
        SUCURSAL.lista_precio_traspaso SUCURSAL_TRASLADO_LISTA_PRECIO_TRASPASO_CLAVE
  FROM SUCURSAL
     LEFT JOIN GRUPOSUCURSAL ON GRUPOSUCURSAL.ID = SUCURSAL.GRUPOSUCURSALID
     LEFT JOIN SAT_COLONIA ON SAT_COLONIA.ID = SUCURSAL.entrega_sat_coloniaid
     LEFT JOIN SAT_LOCALIDAD ON SAT_LOCALIDAD.ID = SUCURSAL.ENTREGA_SAT_LOCALIDADID
     LEFT JOIN SAT_MUNICIPIO ON SAT_MUNICIPIO.ID = SUCURSAL.ENTREGA_SAT_MUNICIPIOID
     LEFT JOIN TIPOPRECIO TIPOPRECIORECEPCIONTRASLADO ON TIPOPRECIORECEPCIONTRASLADO.ID = SUCURSAL.preciorecepciontraslado
     LEFT JOIN TIPOPRECIO TIPOPRECIOENVIOTRASLADO ON TIPOPRECIOENVIOTRASLADO.ID = SUCURSAL.precioenviotraslado
";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                dr = FbSqlHelper.ExecuteReader(fbCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {

                    ImportFromFirebirdReader(empresaId, sucursalId, usuarioId, ref doctoId, tipoDoctoId,
                                             dr, localContext, sucursal_infoController);
                }
                localContext.SaveChanges();
                FbSqlHelper.CloseReader(dr, pcn!);


            }
            catch (Exception e)
            {
                if (dr != null && pcn != null)
                    FbSqlHelper.CloseReader(dr, pcn);

                Console.WriteLine(e.Message);
            }

        }

        public bool ImportFromFirebirdReader(long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                                               FbDataReader dataReader, ApplicationDbContext localContext, Sucursal_infoController controller)
        {

            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";


            var entrega_codigoPostal = dataReader["SUCURSAL_FACT_ELECT_ENTREGACODIGOPOSTAL"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_FACT_ELECT_ENTREGACODIGOPOSTAL"]).Trim() : "";


            var entrega_estado = dataReader["SUCURSAL_FACT_ELECT_ENTREGAESTADOCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_FACT_ELECT_ENTREGAESTADOCLAVE"]).Trim() : "";


            var Sucursal_info_opciones_GruposucursalClave = dataReader["SUCURSAL_INFO_OPCIONES_GRUPOSUCURSALCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_INFO_OPCIONES_GRUPOSUCURSALCLAVE"]).Trim() : "";

            var Sucursal_info_opciones_ClienteClave = dataReader["SUCURSAL_INFO_OPCIONES_CLIENTECLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_INFO_OPCIONES_CLIENTECLAVE"]).Trim() : "";

            var Sucursal_info_opciones_ProveedorClave = dataReader["SUCURSAL_INFO_OPCIONES_PROVEEDORCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_INFO_OPCIONES_PROVEEDORCLAVE"]).Trim() : "";

            var Sucursal_info_opciones_BancoClave = dataReader["SUCURSAL_INFO_OPCIONES_BANCOCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_INFO_OPCIONES_BANCOCLAVE"]).Trim() : "";

            var Sucursal_info_opciones_EmpprovClave = dataReader["SUCURSAL_INFO_OPCIONES_EMPPROVCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_INFO_OPCIONES_EMPPROVCLAVE"]).Trim() : "";

            var Sucursal_fact_elect_EntregaestadoClave = dataReader["SUCURSAL_FACT_ELECT_ENTREGAESTADOCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_FACT_ELECT_ENTREGAESTADOCLAVE"]).Trim() : "";

            var Sucursal_fact_elect_Entrega_Sat_ColoniaClave = dataReader["SUCURSAL_FACT_ELECT_ENTREGA_SAT_COLONIACLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_FACT_ELECT_ENTREGA_SAT_COLONIACLAVE"]).Trim() : "";

            var Sucursal_fact_elect_Entrega_Sat_LocalidadClave = dataReader["SUCURSAL_FACT_ELECT_ENTREGA_SAT_LOCALIDADCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_FACT_ELECT_ENTREGA_SAT_LOCALIDADCLAVE"]).Trim() : "";

            var Sucursal_fact_elect_Entrega_Sat_MunicipioClave = dataReader["SUCURSAL_FACT_ELECT_ENTREGA_SAT_MUNICIPIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_FACT_ELECT_ENTREGA_SAT_MUNICIPIOCLAVE"]).Trim() : "";

            var Sucursal_importacion_ListaprecioClave = dataReader["SUCURSAL_IMPORTACION_LISTAPRECIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_IMPORTACION_LISTAPRECIOCLAVE"]).Trim() : "";

            var Sucursal_importacion_SurtidorClave = dataReader["SUCURSAL_IMPORTACION_SURTIDORCLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_IMPORTACION_SURTIDORCLAVE"]).Trim() : "";

            var Sucursal_traslado_Preciorecepciontraslado_Clave = dataReader["SUCURSAL_TRASLADO_PRECIORECEPCIONTRASLADO_CLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_TRASLADO_PRECIORECEPCIONTRASLADO_CLAVE"]).Trim() : "";

            var Sucursal_traslado_Precioenviotraslado_Clave = dataReader["SUCURSAL_TRASLADO_PRECIOENVIOTRASLADO_CLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_TRASLADO_PRECIOENVIOTRASLADO_CLAVE"]).Trim() : "";

            var Sucursal_traslado_Lista_precio_traspaso_Clave = dataReader["SUCURSAL_TRASLADO_LISTA_PRECIO_TRASPASO_CLAVE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_TRASLADO_LISTA_PRECIO_TRASPASO_CLAVE"]).Trim() : "";


            var itemSaved = localContext.Sucursal_info.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);


            var Sucursal_info_opciones_GruposucursalClave_obj = localContext.Gruposucursal.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Sucursal_info_opciones_GruposucursalClave);

            var Sucursal_info_opciones_ClienteClave_obj = localContext.Cliente.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Sucursal_info_opciones_ClienteClave);

            var Sucursal_info_opciones_ProveedorClave_obj = localContext.Proveedor.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Sucursal_info_opciones_ProveedorClave);

            var Sucursal_info_opciones_BancoClave_obj = localContext.Banco.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Sucursal_info_opciones_BancoClave);

            var Sucursal_info_opciones_EmpprovClave_obj = localContext.Proveedor.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Sucursal_info_opciones_EmpprovClave);

            var Sucursal_fact_elect_EntregaestadoClave_obj = localContext.Estadopais.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Sucursal_fact_elect_EntregaestadoClave);

            var Sucursal_fact_elect_Entrega_Sat_ColoniaClave_obj = localContext.Sat_colonia.AsNoTracking()
                                            .FirstOrDefault(i => i.Colonia == Sucursal_fact_elect_Entrega_Sat_ColoniaClave && i.Codigopostal == entrega_codigoPostal);

            var Sucursal_fact_elect_Entrega_Sat_LocalidadClave_obj = localContext.Sat_localidad.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave_localidad == Sucursal_fact_elect_Entrega_Sat_LocalidadClave && i.Clave_estado == entrega_estado);

            var Sucursal_fact_elect_Entrega_Sat_MunicipioClave_obj = localContext.Sat_municipio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave_municipio == Sucursal_fact_elect_Entrega_Sat_MunicipioClave && i.Clave_estado == entrega_estado);

            var Sucursal_importacion_ListaprecioClave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Sucursal_importacion_ListaprecioClave);

            var Sucursal_importacion_SurtidorClave_obj = localContext.Sucursal_info.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Sucursal_importacion_SurtidorClave);

            var Sucursal_traslado_Preciorecepciontraslado_Clave_obj = localContext.Tipo_precio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Sucursal_traslado_Preciorecepciontraslado_Clave);

            var Sucursal_traslado_Precioenviotraslado_Clave_obj = localContext.Tipo_precio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Sucursal_traslado_Precioenviotraslado_Clave);

            var Sucursal_traslado_Lista_precio_traspaso_Clave_obj = localContext.Tipo_precio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Sucursal_traslado_Lista_precio_traspaso_Clave);


            var item = itemSaved != null ? new Sucursal_infoBindingModel(itemSaved) : new Sucursal_infoBindingModel();
            var existItem = itemSaved != null;


            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;

            item.Cuentareferencia = dataReader["CUENTAREFERENCIA"] != System.DBNull.Value ? ((string)dataReader["CUENTAREFERENCIA"]).Trim() : "";
            item.Cuentapoliza = dataReader["CUENTAPOLIZA"] != System.DBNull.Value ? ((string)dataReader["CUENTAPOLIZA"]).Trim() : "";
            item.Clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";
            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";
            item.Descripcion = dataReader["DESCRIPCION"] != System.DBNull.Value ? ((string)dataReader["DESCRIPCION"]).Trim() : "";
            item.Memo = dataReader["MEMO"] != System.DBNull.Value ? ((string)dataReader["MEMO"]).Trim() : "";
            item.Sucursal_fact_elect_Entregacalle = dataReader["SUCURSAL_FACT_ELECT_ENTREGACALLE"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_FACT_ELECT_ENTREGACALLE"]).Trim() : "";
            item.Sucursal_fact_elect_Entreganumeroexterior = dataReader["SUCURSAL_FACT_ELECT_ENTREGANUMEROEXTERIOR"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_FACT_ELECT_ENTREGANUMEROEXTERIOR"]).Trim() : "";
            item.Sucursal_fact_elect_Entreganumerointerior = dataReader["SUCURSAL_FACT_ELECT_ENTREGANUMEROINTERIOR"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_FACT_ELECT_ENTREGANUMEROINTERIOR"]).Trim() : "";
            item.Sucursal_fact_elect_Entregacolonia = dataReader["SUCURSAL_FACT_ELECT_ENTREGACOLONIA"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_FACT_ELECT_ENTREGACOLONIA"]).Trim() : "";
            item.Sucursal_fact_elect_Entregamunicipio = dataReader["SUCURSAL_FACT_ELECT_ENTREGAMUNICIPIO"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_FACT_ELECT_ENTREGAMUNICIPIO"]).Trim() : "";
            item.Sucursal_fact_elect_Entregacodigopostal = dataReader["SUCURSAL_FACT_ELECT_ENTREGACODIGOPOSTAL"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_FACT_ELECT_ENTREGACODIGOPOSTAL"]).Trim() : "";
            item.Sucursal_fact_elect_Entregareferenciadom = dataReader["SUCURSAL_FACT_ELECT_ENTREGAREFERENCIADOM"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_FACT_ELECT_ENTREGAREFERENCIADOM"]).Trim() : "";
            item.Sucursal_importacion_Prefijoprecioxdescuento = dataReader["SUCURSAL_IMPORTACION_PREFIJOPRECIOXDESCUENTO"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_IMPORTACION_PREFIJOPRECIOXDESCUENTO"]).Trim() : "";
            item.Sucursal_respaldo_Rutarespaldoorigen = dataReader["SUCURSAL_RESPALDO_RUTARESPALDOORIGEN"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_RESPALDO_RUTARESPALDOORIGEN"]).Trim() : "";
            item.Sucursal_respaldo_Rutarespaldodestino = dataReader["SUCURSAL_RESPALDO_RUTARESPALDODESTINO"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_RESPALDO_RUTARESPALDODESTINO"]).Trim() : "";
            item.Sucursal_respaldo_Rutarespaldored = dataReader["SUCURSAL_RESPALDO_RUTARESPALDORED"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_RESPALDO_RUTARESPALDORED"]).Trim() : "";
            item.Sucursal_respaldo_Nombrerespaldobd = dataReader["SUCURSAL_RESPALDO_NOMBRERESPALDOBD"] != System.DBNull.Value ? ((string)dataReader["SUCURSAL_RESPALDO_NOMBRERESPALDOBD"]).Trim() : "";
            item.Esmatriz = dataReader["ESMATRIZ"] != System.DBNull.Value && ((string)dataReader["ESMATRIZ"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Esfranquicia = dataReader["ESFRANQUICIA"] != System.DBNull.Value && ((string)dataReader["ESFRANQUICIA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Sucursal_fact_elect_Por_fact_elect = dataReader["SUCURSAL_FACT_ELECT_POR_FACT_ELECT"] != System.DBNull.Value && ((string)dataReader["SUCURSAL_FACT_ELECT_POR_FACT_ELECT"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Sucursal_importacion_Manejaprecioxdescuento = dataReader["SUCURSAL_IMPORTACION_MANEJAPRECIOXDESCUENTO"] != System.DBNull.Value && ((string)dataReader["SUCURSAL_IMPORTACION_MANEJAPRECIOXDESCUENTO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Sucursal_traslado_Mostrarprecioreal = dataReader["SUCURSAL_TRASLADO_MOSTRARPRECIOREAL"] != System.DBNull.Value && ((string)dataReader["SUCURSAL_TRASLADO_MOSTRARPRECIOREAL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Creado = dataReader["CREADO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["CREADO"])) : DateTime.UtcNow;
            item.Modificado = dataReader["MODIFICADO"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["MODIFICADO"])) : DateTime.UtcNow;
            item.Sucursal_fact_elect_Entrega_Distancia = dataReader["SUCURSAL_FACT_ELECT_ENTREGA_DISTANCIA"] != System.DBNull.Value ? (decimal)dataReader["SUCURSAL_FACT_ELECT_ENTREGA_DISTANCIA"] : 0;
            item.Sucursal_importacion_Porc_aumento_precio = dataReader["SUCURSAL_IMPORTACION_PORC_AUMENTO_PRECIO"] != System.DBNull.Value ? (decimal)dataReader["SUCURSAL_IMPORTACION_PORC_AUMENTO_PRECIO"] : 0;
            item.Maxdoctospendientes = dataReader["MAXDOCTOSPENDIENTES"] != System.DBNull.Value ? (int)dataReader["MAXDOCTOSPENDIENTES"] : (int?)null;
            //item.Sucursal_traslado_Preciorecepciontraslado = dataReader["SUCURSAL_TRASLADO_PRECIORECEPCIONTRASLADO"] != System.DBNull.Value ? long.Parse((string)dataReader["SUCURSAL_TRASLADO_PRECIORECEPCIONTRASLADO"]) : (long?)null;
            //item.Sucursal_traslado_Precioenviotraslado = dataReader["SUCURSAL_TRASLADO_PRECIOENVIOTRASLADO"] != System.DBNull.Value ? long.Parse((string)dataReader["SUCURSAL_TRASLADO_PRECIOENVIOTRASLADO"]) : (long?)null;
            //item.Sucursal_traslado_Lista_precio_traspaso = dataReader["SUCURSAL_TRASLADO_LISTA_PRECIO_TRASPASO"] != System.DBNull.Value ? long.Parse((string)dataReader["SUCURSAL_TRASLADO_LISTA_PRECIO_TRASPASO"]) : (long?)null;


            if (Sucursal_info_opciones_GruposucursalClave_obj != null)
                item.Sucursal_info_opciones_Gruposucursalid = Sucursal_info_opciones_GruposucursalClave_obj.Id;
            else
                item.Sucursal_info_opciones_Gruposucursalid = null;

            if (Sucursal_info_opciones_ClienteClave_obj != null)
                item.Sucursal_info_opciones_Clienteid = Sucursal_info_opciones_ClienteClave_obj.Id;
            else
                item.Sucursal_info_opciones_Clienteid = null;

            if (Sucursal_info_opciones_ProveedorClave_obj != null)
                item.Sucursal_info_opciones_Proveedorid = Sucursal_info_opciones_ProveedorClave_obj.Id;
            else
                item.Sucursal_info_opciones_Proveedorid = null;

            if (Sucursal_info_opciones_BancoClave_obj != null)
                item.Sucursal_info_opciones_Bancoid = Sucursal_info_opciones_BancoClave_obj.Id;
            else
                item.Sucursal_info_opciones_Bancoid = null;

            if (Sucursal_info_opciones_EmpprovClave_obj != null)
                item.Sucursal_info_opciones_Empprovid = Sucursal_info_opciones_EmpprovClave_obj.Id;
            else
                item.Sucursal_info_opciones_Empprovid = null;

            if (Sucursal_fact_elect_EntregaestadoClave_obj != null)
                item.Sucursal_fact_elect_Entregaestadoid = Sucursal_fact_elect_EntregaestadoClave_obj.Id;
            else
                item.Sucursal_fact_elect_Entregaestadoid = null;

            if (Sucursal_fact_elect_Entrega_Sat_ColoniaClave_obj != null)
                item.Sucursal_fact_elect_Entrega_Sat_Coloniaid = Sucursal_fact_elect_Entrega_Sat_ColoniaClave_obj.Id;
            else
                item.Sucursal_fact_elect_Entrega_Sat_Coloniaid = null;

            if (Sucursal_fact_elect_Entrega_Sat_LocalidadClave_obj != null)
                item.Sucursal_fact_elect_Entrega_Sat_Localidadid = Sucursal_fact_elect_Entrega_Sat_LocalidadClave_obj.Id;
            else
                item.Sucursal_fact_elect_Entrega_Sat_Localidadid = null;

            if (Sucursal_fact_elect_Entrega_Sat_MunicipioClave_obj != null)
                item.Sucursal_fact_elect_Entrega_Sat_Municipioid = Sucursal_fact_elect_Entrega_Sat_MunicipioClave_obj.Id;
            else
                item.Sucursal_fact_elect_Entrega_Sat_Municipioid = null;

            if (Sucursal_importacion_ListaprecioClave_obj != null)
                item.Sucursal_importacion_Listaprecioid = Sucursal_importacion_ListaprecioClave_obj.Id;
            else
                item.Sucursal_importacion_Listaprecioid = null;

            if (Sucursal_importacion_SurtidorClave_obj != null)
                item.Sucursal_importacion_Surtidorid = Sucursal_importacion_SurtidorClave_obj.Id;
            else
                item.Sucursal_importacion_Surtidorid = null;

            if (Sucursal_traslado_Preciorecepciontraslado_Clave_obj != null)
                item.Sucursal_traslado_Preciorecepciontraslado = Sucursal_traslado_Preciorecepciontraslado_Clave_obj.Id;
            else
                item.Sucursal_traslado_Preciorecepciontraslado = null;

            if (Sucursal_traslado_Precioenviotraslado_Clave_obj != null)
                item.Sucursal_traslado_Precioenviotraslado = Sucursal_traslado_Precioenviotraslado_Clave_obj.Id;
            else
                item.Sucursal_traslado_Precioenviotraslado = null;

            if (Sucursal_traslado_Lista_precio_traspaso_Clave_obj != null)
                item.Sucursal_traslado_Lista_precio_traspaso = Sucursal_traslado_Lista_precio_traspaso_Clave_obj.Id;
            else
                item.Sucursal_traslado_Lista_precio_traspaso = null;



            if (existItem)
                controller.Update(item);
            else
                controller.Insert(item);

            localContext.SaveChanges();

            return true;
        }


    }
}


