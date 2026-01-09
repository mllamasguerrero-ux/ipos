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
using BindingModels;
using Controllers.Controller;
using System.Data;

namespace IposV3.Services
{

    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class UsuarioImpoExpoService : BaseImpoExpoService
    {

       


        public  void ImportarDeTablaFirebird(
                          long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                          string fbCadenaConexion,
                          string? nombreTabla, string? queryPersonalizada,
                           ApplicationDbContext localContext, UsuarioController usuarioController)
        {
            /**/
            FbDataReader? dr = null;
            FbConnection? pcn = null;

            var utf8 = new UTF8Encoding();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();

                String CmdTxt = @"SELECT
            PERSONA.NOMBRE as NOMBRE, 
            CASE WHEN COALESCE(PERSONA.USERNAME,'') = '' THEN '___' || CAST(PERSONA.ID AS VARCHAR(16)) ELSE PERSONA.USERNAME END  as USUARIONOMBRE, 
            PERSONA.CLAVEACCESO as CONTRASENA, 
            PERSONA.NOMBRES as NOMBRES, 
            PERSONA.APELLIDOS as APELLIDOS, 
            PERSONA.RAZONSOCIAL as RAZONSOCIAL, 
            PERSONA.RFC as RFC, 
            PERSONA.DOMICILIO as DOMICILIO_CALLE, 
            PERSONA.NUMEROINTERIOR as DOMICILIO_NUMEROEXTERIOR,
            PERSONA.NUMEROEXTERIOR as DOMICILIO_NUMEROINTERIOR, 
            PERSONA.COLONIA as DOMICILIO_COLONIA, 
            PERSONA.CIUDAD as DOMICILIO_CIUDAD, 
            PERSONA.MUNICIPIO as DOMICILIO_MUNICIPIO, 
            PERSONA.ESTADO as DOMICILIO_ESTADO, 
            PERSONA.PAIS as DOMICILIO_PAIS, 
            PERSONA.CODIGOPOSTAL as DOMICILIO_CODIGOPOSTAL, 
            PERSONA.REFERENCIADOM as DOMICILIO_REFERENCIA, 
            PERSONA.CONTACTO1 as CONTACTO1_NOMBRE, 
            PERSONA.CONTACTO2 as CONTACTO2_NOMBRE, 
            PERSONA.TELEFONO1 as TELEFONO1, 
            PERSONA.TELEFONO2 as TELEFONO2, 
            PERSONA.TELEFONO3 as TELEFONO3, 
            PERSONA.CELULAR as CELULAR, 
            PERSONA.NEXTEL as NEXTEL, 
            PERSONA.EMAIL1 as EMAIL1, 
            PERSONA.EMAIL2 as EMAIL2, 
            PERSONA.GAFFETE as GAFFETE, 
            PERSONA.CODIGOAUTORIZACION as CODIGOAUTORIZACION, 
            PERSONA.CLIEFORMASPAGODEF as CLIEFORMASPAGODEF, 
            PERSONA.CLAVE as CLAVE, 
            PERSONA.RESET_PASS as RESET_PASS,
            PERSONA.TICKETLARGO as TICKETLARGO, 
            PERSONA.TICKETLARGOCOTIZACION as TICKETLARGOCOTIZACION, 
            PERSONA.TICKETLARGOCREDITO as TICKETLARGOCREDITO, 
            PERSONA.PREGUNTARTICKETLARGO as PREGUNTARTICKETLARGO, 
            CASE WHEN PERSONA.TIPOPERSONAID = 22 THEN 'S' ELSE 'N' END  as ESVENDEDOR,
            CASE WHEN PERSONA.TIPOPERSONAID = 70 THEN 'S' ELSE 'N' END  as ESENCARGADOCORTE,
            CASE WHEN PERSONA.TIPOPERSONAID = 60 THEN 'S' ELSE 'N' END  as ESENCARGADOGUIA,
            PERSONA.ACTIVO as ACTIVO, 
            PERSONA.CAJASBOTELLAS as CAJASBOTELLAS, 
            PERSONA.CREADO as CREADO, 
            PERSONA.MODIFICADO as MODIFICADO, 
            PERSONA.VIGENCIA as VIGENCIA, 
            PERSONA.PENDMAXDIAS as PENDMAXDIAS ,

            SALUDO.CLAVE SALUDOCLAVE,
            GRUPOUSUARIO.CLAVE USUARIO_PREFERENCIAS_GRUPOUSUARIOCLAVE,
            ALMACEN.CLAVE USUARIO_PREFERENCIAS_ALMACENCLAVE ,
            LISTAPRECIO.clave USUARIO_PREFERENCIAS_LISTAPRECIOCLAVE,
            SAT_FIGURATRANSPORTE.CLAVE  USUARIO_PERSONAFIGURA_SAT_FIGURATRANSPORTECLAVE,

            SAT_PARTETRANSPORTE.clave USUARIO_PERSONAFIGURA_SAT_PARTETRANSPORTECLAVE,
            PERSONA.sat_clave_pais USUARIO_FACT_ELECT_SAT_PAISCLAVE,
            SAT_COLONIA.colonia USUARIO_FACT_ELECT_SAT_COLONIACLAVE  ,

            SAT_LOCALIDAD.clave_localidad  USUARIO_FACT_ELECT_SAT_LOCALIDADCLAVE,
            SAT_MUNICIPIO.clave_municipio USUARIO_FACT_ELECT_SAT_MUNICIPIOCLAVE,
            PERSONA.estado USUARIO_FACT_ELECT_ESTADOCLAVE  ,

            CPS.clerkid USUARIO_EMIDA_CLERKPAGOSERVICIOSCLAVE,
            CS.CLERKID USUARIO_EMIDA_CLERKSERVICIOS_CLAVE,

            PERSONA.TIPOPERSONAID

          FROM PERSONA
          LEFT JOIN SALUDO ON SALUDO.ID = PERSONA.saludoid
          LEFT JOIN GRUPOUSUARIO ON PERSONA.grupousuarioid = GRUPOUSUARIO.ID
          LEFT JOIN ALMACEN ON PERSONA.almacenid = ALMACEN.ID
          LEFT JOIN PERSONAFIGURA ON personafigura.PERSONAID = PERSONA.ID
          LEFT JOIN sat_figuratransporte ON SAT_FIGURATRANSPORTE.id = PERSONAFIGURA.sat_figuratransporteid
          LEFT JOIN sat_partetransporte ON sat_partetransporte.ID = PERSONAFIGURA.sat_partetransporteid
          LEFT JOIN CLERKPAGOSERVICIO CPS ON CPS.id = PERSONA.clerkpagoserviciosid       
          LEFT JOIN CLERKPAGOSERVICIO CS ON CS.id = PERSONA.clerkservicios
          LEFT JOIN SAT_COLONIA ON SAT_COLONIA.ID = PERSONA.sat_coloniaid   
          LEFT JOIN SAT_LOCALIDAD ON SAT_LOCALIDAD.ID = PERSONA.sat_localidadid
          LEFT JOIN SAT_MUNICIPIO ON SAT_MUNICIPIO.ID = PERSONA.sat_municipioid
          LEFT JOIN LISTAPRECIO ON LISTAPRECIO.ID = PERSONA.listaprecioid
          WHERE PERSONA.tipopersonaid IN (20,21,22,60,70)";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                dr = FbSqlHelper.ExecuteReader(fbCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {

                    ImportFromFirebirdReader(empresaId, sucursalId, usuarioId, ref doctoId, tipoDoctoId,
                                             dr, localContext, usuarioController);
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
                                               FbDataReader dataReader, ApplicationDbContext localContext, UsuarioController controller)
        {

            var clave = dataReader["USUARIONOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIONOMBRE"]).Trim() : "";
            var nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";
            var tipopersonaid = dataReader["TIPOPERSONAID"] != System.DBNull.Value ? (long)dataReader["TIPOPERSONAID"] : 20L;

            var codigoPostal = dataReader["DOMICILIO_CODIGOPOSTAL"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_CODIGOPOSTAL"]).Trim() : "";


            var estado = dataReader["DOMICILIO_ESTADO"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_ESTADO"]).Trim() : "";


            var SaludoClave = dataReader["SALUDOCLAVE"] != System.DBNull.Value ? ((string)dataReader["SALUDOCLAVE"]).Trim() : "";

            var Usuario_Preferencias_GrupousuarioClave = dataReader["USUARIO_PREFERENCIAS_GRUPOUSUARIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PREFERENCIAS_GRUPOUSUARIOCLAVE"]).Trim() : "";

            var Usuario_Preferencias_AlmacenClave = dataReader["USUARIO_PREFERENCIAS_ALMACENCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PREFERENCIAS_ALMACENCLAVE"]).Trim() : "";

            var Usuario_Preferencias_ListaprecioClave = dataReader["USUARIO_PREFERENCIAS_LISTAPRECIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PREFERENCIAS_LISTAPRECIOCLAVE"]).Trim() : "";

            //var Usuario_Personafigura_PersonaClave = dataReader["USUARIO_PERSONAFIGURA_PERSONACLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PERSONAFIGURA_PERSONACLAVE"]).Trim() : "";

            var Usuario_Personafigura_Sat_FiguratransporteClave = dataReader["USUARIO_PERSONAFIGURA_SAT_FIGURATRANSPORTECLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PERSONAFIGURA_SAT_FIGURATRANSPORTECLAVE"]).Trim() : "";

            var Usuario_Personafigura_Sat_PartetransporteClave = dataReader["USUARIO_PERSONAFIGURA_SAT_PARTETRANSPORTECLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PERSONAFIGURA_SAT_PARTETRANSPORTECLAVE"]).Trim() : "";

            var Usuario_fact_elect_Sat_paisClave = dataReader["USUARIO_FACT_ELECT_SAT_PAISCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_SAT_PAISCLAVE"]).Trim() : "";

            var Usuario_fact_elect_Sat_ColoniaClave = dataReader["USUARIO_FACT_ELECT_SAT_COLONIACLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_SAT_COLONIACLAVE"]).Trim() : "";

            var Usuario_fact_elect_Sat_LocalidadClave = dataReader["USUARIO_FACT_ELECT_SAT_LOCALIDADCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_SAT_LOCALIDADCLAVE"]).Trim() : "";

            var Usuario_fact_elect_Sat_MunicipioClave = dataReader["USUARIO_FACT_ELECT_SAT_MUNICIPIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_SAT_MUNICIPIOCLAVE"]).Trim() : "";

            var Usuario_fact_elect_EstadoClave = dataReader["USUARIO_FACT_ELECT_ESTADOCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_ESTADOCLAVE"]).Trim() : "";

            var Usuario_emida_ClerkpagoserviciosClave = dataReader["USUARIO_EMIDA_CLERKPAGOSERVICIOSCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_EMIDA_CLERKPAGOSERVICIOSCLAVE"]).Trim() : "";

            var Usuario_emida_Clerkservicios_Clave = dataReader["USUARIO_EMIDA_CLERKSERVICIOS_CLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_EMIDA_CLERKSERVICIOS_CLAVE"]).Trim() : "";


            var itemSaved = localContext.Usuario.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             ((i.UsuarioNombre == null && clave == "") || (i.UsuarioNombre == clave)) &&
                                                              (i.Nombre == null && nombre == "") || (i.Nombre == nombre));


            var SaludoClave_obj = localContext.Saludo.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == SaludoClave);

            var Usuario_Preferencias_GrupousuarioClave_obj = localContext.Grupousuario.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Usuario_Preferencias_GrupousuarioClave);

            var Usuario_Preferencias_AlmacenClave_obj = localContext.Almacen.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Usuario_Preferencias_AlmacenClave);

            var Usuario_Preferencias_ListaprecioClave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i =>i.Clave == Usuario_Preferencias_ListaprecioClave);

            //var Usuario_Personafigura_PersonaClave_obj = localContext.Usuario.AsNoTracking()
            //                                .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
            //                                                 i.Clave == Usuario_Personafigura_PersonaClave);

            var Usuario_Personafigura_Sat_FiguratransporteClave_obj = localContext.Sat_figuratransporte.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Usuario_Personafigura_Sat_FiguratransporteClave);

            var Usuario_Personafigura_Sat_PartetransporteClave_obj = localContext.Sat_partetransporte.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Usuario_Personafigura_Sat_PartetransporteClave);

            var Usuario_fact_elect_Sat_paisClave_obj = localContext.Sat_pais.AsNoTracking()
                                            .FirstOrDefault(i => i.Sat_clave == Usuario_fact_elect_Sat_paisClave);

            var Usuario_fact_elect_Sat_ColoniaClave_obj = localContext.Sat_colonia.AsNoTracking()
                                            .FirstOrDefault(i => i.Colonia == Usuario_fact_elect_Sat_ColoniaClave && i.Codigopostal == codigoPostal);

            var Usuario_fact_elect_Sat_LocalidadClave_obj = localContext.Sat_localidad.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave_localidad == Usuario_fact_elect_Sat_LocalidadClave && i.Clave_estado == estado);

            var Usuario_fact_elect_Sat_MunicipioClave_obj = localContext.Sat_municipio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave_municipio == Usuario_fact_elect_Sat_MunicipioClave && i.Clave_estado == estado);

            var Usuario_fact_elect_EstadoClave_obj = localContext.Estadopais.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Usuario_fact_elect_EstadoClave);

            var Usuario_emida_ClerkpagoserviciosClave_obj = localContext.Clerkpagoservicio.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clerkid == Usuario_emida_ClerkpagoserviciosClave);

            var Usuario_emida_Clerkservicios_Clave_obj = localContext.Clerkpagoservicio.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clerkid == Usuario_emida_Clerkservicios_Clave);


            var item = itemSaved != null ? new UsuarioBindingModel(itemSaved) : new UsuarioBindingModel();
            var existItem = itemSaved != null;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;


            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";
            item.UsuarioNombre = dataReader["USUARIONOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIONOMBRE"]).Trim() : "";
            //item.Contrasena = dataReader["CONTRASENA"] != System.DBNull.Value ? ((string)dataReader["CONTRASENA"]).Trim() : "";
            item.Nombres = dataReader["NOMBRES"] != System.DBNull.Value ? ((string)dataReader["NOMBRES"]).Trim() : "";
            item.Apellidos = dataReader["APELLIDOS"] != System.DBNull.Value ? ((string)dataReader["APELLIDOS"]).Trim() : "";
            item.Razonsocial = dataReader["RAZONSOCIAL"] != System.DBNull.Value ? ((string)dataReader["RAZONSOCIAL"]).Trim() : "";
            item.Rfc = dataReader["RFC"] != System.DBNull.Value ? ((string)dataReader["RFC"]).Trim() : "";
            item.Domicilio_Calle = dataReader["DOMICILIO_CALLE"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_CALLE"]).Trim() : "";
            item.Domicilio_Numeroexterior = dataReader["DOMICILIO_NUMEROEXTERIOR"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_NUMEROEXTERIOR"]).Trim() : "";
            item.Domicilio_Numerointerior = dataReader["DOMICILIO_NUMEROINTERIOR"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_NUMEROINTERIOR"]).Trim() : "";
            item.Domicilio_Colonia = dataReader["DOMICILIO_COLONIA"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_COLONIA"]).Trim() : "";
            item.Domicilio_Ciudad = dataReader["DOMICILIO_CIUDAD"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_CIUDAD"]).Trim() : "";
            item.Domicilio_Municipio = dataReader["DOMICILIO_MUNICIPIO"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_MUNICIPIO"]).Trim() : "";
            item.Domicilio_Estado = dataReader["DOMICILIO_ESTADO"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_ESTADO"]).Trim() : "";
            item.Domicilio_Pais = dataReader["DOMICILIO_PAIS"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_PAIS"]).Trim() : "";
            item.Domicilio_Codigopostal = dataReader["DOMICILIO_CODIGOPOSTAL"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_CODIGOPOSTAL"]).Trim() : "";
            //item.Domicilio_Referencia = dataReader["DOMICILIO_REFERENCIA"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_REFERENCIA"]).Trim() : "";
            item.Contacto1_Nombre = dataReader["CONTACTO1_NOMBRE"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_NOMBRE"]).Trim() : "-";
            //item.Contacto1_Email = dataReader["CONTACTO1_EMAIL"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_EMAIL"]).Trim() : "";
            //item.Contacto1_Telefono1 = dataReader["CONTACTO1_TELEFONO1"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_TELEFONO1"]).Trim() : "";
            //item.Contacto1_Domicilio_Calle = dataReader["CONTACTO1_DOMICILIO_CALLE"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_DOMICILIO_CALLE"]).Trim() : "";
            //item.Contacto1_Domicilio_Numeroexterior = dataReader["CONTACTO1_DOMICILIO_NUMEROEXTERIOR"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_DOMICILIO_NUMEROEXTERIOR"]).Trim() : "";
            //item.Contacto1_Domicilio_Numerointerior = dataReader["CONTACTO1_DOMICILIO_NUMEROINTERIOR"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_DOMICILIO_NUMEROINTERIOR"]).Trim() : "";
            //item.Contacto1_Domicilio_Colonia = dataReader["CONTACTO1_DOMICILIO_COLONIA"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_DOMICILIO_COLONIA"]).Trim() : "";
            //item.Contacto1_Domicilio_Ciudad = dataReader["CONTACTO1_DOMICILIO_CIUDAD"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_DOMICILIO_CIUDAD"]).Trim() : "";
            //item.Contacto1_Domicilio_Municipio = dataReader["CONTACTO1_DOMICILIO_MUNICIPIO"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_DOMICILIO_MUNICIPIO"]).Trim() : "";
            //item.Contacto1_Domicilio_Estado = dataReader["CONTACTO1_DOMICILIO_ESTADO"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_DOMICILIO_ESTADO"]).Trim() : "";
            //item.Contacto1_Domicilio_Pais = dataReader["CONTACTO1_DOMICILIO_PAIS"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_DOMICILIO_PAIS"]).Trim() : "";
            //item.Contacto1_Domicilio_Codigopostal = dataReader["CONTACTO1_DOMICILIO_CODIGOPOSTAL"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_DOMICILIO_CODIGOPOSTAL"]).Trim() : "";
            //item.Contacto1_Domicilio_Referencia = dataReader["CONTACTO1_DOMICILIO_REFERENCIA"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_DOMICILIO_REFERENCIA"]).Trim() : "";
            item.Contacto2_Nombre = dataReader["CONTACTO2_NOMBRE"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_NOMBRE"]).Trim() : "-";
            //item.Contacto2_Email = dataReader["CONTACTO2_EMAIL"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_EMAIL"]).Trim() : "";
            //item.Contacto2_Telefono1 = dataReader["CONTACTO2_TELEFONO1"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_TELEFONO1"]).Trim() : "";
            //item.Contacto2_Domicilio_Calle = dataReader["CONTACTO2_DOMICILIO_CALLE"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_DOMICILIO_CALLE"]).Trim() : "";
            //item.Contacto2_Domicilio_Numeroexterior = dataReader["CONTACTO2_DOMICILIO_NUMEROEXTERIOR"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_DOMICILIO_NUMEROEXTERIOR"]).Trim() : "";
            //item.Contacto2_Domicilio_Numerointerior = dataReader["CONTACTO2_DOMICILIO_NUMEROINTERIOR"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_DOMICILIO_NUMEROINTERIOR"]).Trim() : "";
            //item.Contacto2_Domicilio_Colonia = dataReader["CONTACTO2_DOMICILIO_COLONIA"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_DOMICILIO_COLONIA"]).Trim() : "";
            //item.Contacto2_Domicilio_Ciudad = dataReader["CONTACTO2_DOMICILIO_CIUDAD"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_DOMICILIO_CIUDAD"]).Trim() : "";
            //item.Contacto2_Domicilio_Municipio = dataReader["CONTACTO2_DOMICILIO_MUNICIPIO"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_DOMICILIO_MUNICIPIO"]).Trim() : "";
            //item.Contacto2_Domicilio_Estado = dataReader["CONTACTO2_DOMICILIO_ESTADO"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_DOMICILIO_ESTADO"]).Trim() : "";
            //item.Contacto2_Domicilio_Pais = dataReader["CONTACTO2_DOMICILIO_PAIS"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_DOMICILIO_PAIS"]).Trim() : "";
            //item.Contacto2_Domicilio_Codigopostal = dataReader["CONTACTO2_DOMICILIO_CODIGOPOSTAL"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_DOMICILIO_CODIGOPOSTAL"]).Trim() : "";
            //item.Contacto2_Domicilio_Referencia = dataReader["CONTACTO2_DOMICILIO_REFERENCIA"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_DOMICILIO_REFERENCIA"]).Trim() : "";
            item.Telefono1 = dataReader["TELEFONO1"] != System.DBNull.Value ? ((string)dataReader["TELEFONO1"]).Trim() : "";
            item.Telefono2 = dataReader["TELEFONO2"] != System.DBNull.Value ? ((string)dataReader["TELEFONO2"]).Trim() : "";
            item.Telefono3 = dataReader["TELEFONO3"] != System.DBNull.Value ? ((string)dataReader["TELEFONO3"]).Trim() : "";
            item.Celular = dataReader["CELULAR"] != System.DBNull.Value ? ((string)dataReader["CELULAR"]).Trim() : "";
            item.Nextel = dataReader["NEXTEL"] != System.DBNull.Value ? ((string)dataReader["NEXTEL"]).Trim() : "";
            item.Email1 = dataReader["EMAIL1"] != System.DBNull.Value ? ((string)dataReader["EMAIL1"]).Trim() : "";
            item.Email2 = dataReader["EMAIL2"] != System.DBNull.Value ? ((string)dataReader["EMAIL2"]).Trim() : "";
            item.Gaffete = dataReader["GAFFETE"] != System.DBNull.Value ? ((string)dataReader["GAFFETE"]).Trim() : "";
            item.Codigoautorizacion = dataReader["CODIGOAUTORIZACION"] != System.DBNull.Value ? ((string)dataReader["CODIGOAUTORIZACION"]).Trim() : "";
            item.Clieformaspagodef = dataReader["CLIEFORMASPAGODEF"] != System.DBNull.Value ? ((string)dataReader["CLIEFORMASPAGODEF"]).Trim() : "";
            //item.SaludoClave = dataReader["SALUDOCLAVE"] != System.DBNull.Value ? ((string)dataReader["SALUDOCLAVE"]).Trim() : null;
            //item.SaludoNombre = dataReader["SALUDONOMBRE"] != System.DBNull.Value ? ((string)dataReader["SALUDONOMBRE"]).Trim() : null;
            //item.Usuario_Preferencias_GrupousuarioClave = dataReader["USUARIO_PREFERENCIAS_GRUPOUSUARIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PREFERENCIAS_GRUPOUSUARIOCLAVE"]).Trim() : null;
            //item.Usuario_Preferencias_GrupousuarioNombre = dataReader["USUARIO_PREFERENCIAS_GRUPOUSUARIONOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PREFERENCIAS_GRUPOUSUARIONOMBRE"]).Trim() : null;
            //item.Usuario_Preferencias_AlmacenClave = dataReader["USUARIO_PREFERENCIAS_ALMACENCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PREFERENCIAS_ALMACENCLAVE"]).Trim() : null;
            //item.Usuario_Preferencias_AlmacenNombre = dataReader["USUARIO_PREFERENCIAS_ALMACENNOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PREFERENCIAS_ALMACENNOMBRE"]).Trim() : null;
            //item.Usuario_Preferencias_ListaprecioClave = dataReader["USUARIO_PREFERENCIAS_LISTAPRECIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PREFERENCIAS_LISTAPRECIOCLAVE"]).Trim() : null;
            //item.Usuario_Preferencias_ListaprecioNombre = dataReader["USUARIO_PREFERENCIAS_LISTAPRECIONOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PREFERENCIAS_LISTAPRECIONOMBRE"]).Trim() : null;
            //item.Usuario_Preferencias_Nombreimpresora = dataReader["USUARIO_PREFERENCIAS_NOMBREIMPRESORA"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PREFERENCIAS_NOMBREIMPRESORA"]).Trim() : "";
            //item.Usuario_Personafigura_PersonaClave = dataReader["USUARIO_PERSONAFIGURA_PERSONACLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PERSONAFIGURA_PERSONACLAVE"]).Trim() : null;
            //item.Usuario_Personafigura_PersonaNombre = dataReader["USUARIO_PERSONAFIGURA_PERSONANOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PERSONAFIGURA_PERSONANOMBRE"]).Trim() : null;
            //item.Usuario_Personafigura_Sat_FiguratransporteClave = dataReader["USUARIO_PERSONAFIGURA_SAT_FIGURATRANSPORTECLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PERSONAFIGURA_SAT_FIGURATRANSPORTECLAVE"]).Trim() : null;
            //item.Usuario_Personafigura_Sat_FiguratransporteNombre = dataReader["USUARIO_PERSONAFIGURA_SAT_FIGURATRANSPORTENOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PERSONAFIGURA_SAT_FIGURATRANSPORTENOMBRE"]).Trim() : null;
            //item.Usuario_Personafigura_Numlicencia = dataReader["USUARIO_PERSONAFIGURA_NUMLICENCIA"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PERSONAFIGURA_NUMLICENCIA"]).Trim() : "";
            //item.Usuario_Personafigura_Numregidtrib = dataReader["USUARIO_PERSONAFIGURA_NUMREGIDTRIB"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PERSONAFIGURA_NUMREGIDTRIB"]).Trim() : "";
            //item.Usuario_Personafigura_Residenciafiscal = dataReader["USUARIO_PERSONAFIGURA_RESIDENCIAFISCAL"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PERSONAFIGURA_RESIDENCIAFISCAL"]).Trim() : "";
            //item.Usuario_Personafigura_Sat_PartetransporteClave = dataReader["USUARIO_PERSONAFIGURA_SAT_PARTETRANSPORTECLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PERSONAFIGURA_SAT_PARTETRANSPORTECLAVE"]).Trim() : null;
            //item.Usuario_Personafigura_Sat_PartetransporteNombre = dataReader["USUARIO_PERSONAFIGURA_SAT_PARTETRANSPORTENOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_PERSONAFIGURA_SAT_PARTETRANSPORTENOMBRE"]).Trim() : null;
            //item.Usuario_fact_elect_Sat_paisClave = dataReader["USUARIO_FACT_ELECT_SAT_PAISCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_SAT_PAISCLAVE"]).Trim() : null;
            //item.Usuario_fact_elect_Sat_paisNombre = dataReader["USUARIO_FACT_ELECT_SAT_PAISNOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_SAT_PAISNOMBRE"]).Trim() : null;
            //item.Usuario_fact_elect_Sat_ColoniaClave = dataReader["USUARIO_FACT_ELECT_SAT_COLONIACLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_SAT_COLONIACLAVE"]).Trim() : null;
            //item.Usuario_fact_elect_Sat_ColoniaNombre = dataReader["USUARIO_FACT_ELECT_SAT_COLONIANOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_SAT_COLONIANOMBRE"]).Trim() : null;
            //item.Usuario_fact_elect_Sat_LocalidadClave = dataReader["USUARIO_FACT_ELECT_SAT_LOCALIDADCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_SAT_LOCALIDADCLAVE"]).Trim() : null;
            //item.Usuario_fact_elect_Sat_LocalidadNombre = dataReader["USUARIO_FACT_ELECT_SAT_LOCALIDADNOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_SAT_LOCALIDADNOMBRE"]).Trim() : null;
            //item.Usuario_fact_elect_Sat_MunicipioClave = dataReader["USUARIO_FACT_ELECT_SAT_MUNICIPIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_SAT_MUNICIPIOCLAVE"]).Trim() : null;
            //item.Usuario_fact_elect_Sat_MunicipioNombre = dataReader["USUARIO_FACT_ELECT_SAT_MUNICIPIONOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_SAT_MUNICIPIONOMBRE"]).Trim() : null;
            //item.Usuario_fact_elect_EstadoClave = dataReader["USUARIO_FACT_ELECT_ESTADOCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_ESTADOCLAVE"]).Trim() : null;
            //item.Usuario_fact_elect_EstadoNombre = dataReader["USUARIO_FACT_ELECT_ESTADONOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_ESTADONOMBRE"]).Trim() : null;
            //item.Usuario_fact_elect_Referenciadom = dataReader["USUARIO_FACT_ELECT_REFERENCIADOM"] != System.DBNull.Value ? ((string)dataReader["USUARIO_FACT_ELECT_REFERENCIADOM"]).Trim() : "";
            //item.Usuario_emida_ClerkpagoserviciosClave = dataReader["USUARIO_EMIDA_CLERKPAGOSERVICIOSCLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_EMIDA_CLERKPAGOSERVICIOSCLAVE"]).Trim() : null;
            //item.Usuario_emida_ClerkpagoserviciosNombre = dataReader["USUARIO_EMIDA_CLERKPAGOSERVICIOSNOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_EMIDA_CLERKPAGOSERVICIOSNOMBRE"]).Trim() : null;
            //item.Usuario_emida_Clerkservicios_Clave = dataReader["USUARIO_EMIDA_CLERKSERVICIOS_CLAVE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_EMIDA_CLERKSERVICIOS_CLAVE"]).Trim() : null;
            //item.Usuario_emida_Clerkservicios_Nombre = dataReader["USUARIO_EMIDA_CLERKSERVICIOS_NOMBRE"] != System.DBNull.Value ? ((string)dataReader["USUARIO_EMIDA_CLERKSERVICIOS_NOMBRE"]).Trim() : null;
            item.Clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";
            item.Reset_pass = dataReader["RESET_PASS"] != System.DBNull.Value && ((short)dataReader["RESET_PASS"]) == 1 ? BoolCN.S : BoolCN.N;
            item.Ticketlargo = dataReader["TICKETLARGO"] != System.DBNull.Value && ((string)dataReader["TICKETLARGO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Ticketlargocotizacion = dataReader["TICKETLARGOCOTIZACION"] != System.DBNull.Value && ((string)dataReader["TICKETLARGOCOTIZACION"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Ticketlargocredito = dataReader["TICKETLARGOCREDITO"] != System.DBNull.Value && ((string)dataReader["TICKETLARGOCREDITO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Preguntarticketlargo = dataReader["PREGUNTARTICKETLARGO"] != System.DBNull.Value && ((string)dataReader["PREGUNTARTICKETLARGO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Esvendedor = dataReader["ESVENDEDOR"] != System.DBNull.Value && ((string)dataReader["ESVENDEDOR"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Esencargadocorte = dataReader["ESENCARGADOCORTE"] != System.DBNull.Value && ((string)dataReader["ESENCARGADOCORTE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Esencargadoguia = dataReader["ESENCARGADOGUIA"] != System.DBNull.Value && ((string)dataReader["ESENCARGADOGUIA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Cajasbotellas = dataReader["CAJASBOTELLAS"] != System.DBNull.Value && ((string)dataReader["CAJASBOTELLAS"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            //item.Creado = dataReader["CREADO"] != System.DBNull.Value ? (DateTimeOffset)dataReader["CREADO"] : DateTimeOffset.UtcNow;
            //item.Modificado = dataReader["MODIFICADO"] != System.DBNull.Value ? (DateTimeOffset)dataReader["MODIFICADO"] : DateTimeOffset.UtcNow;
            item.Vigencia = dataReader["VIGENCIA"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["VIGENCIA"])) : null;
            //item.CreadoPorId = dataReader["CREADOPORID"] != System.DBNull.Value ? long.Parse((string)dataReader["CREADOPORID"]) : (long?)null;
            //item.ModificadoPorId = dataReader["MODIFICADOPORID"] != System.DBNull.Value ? long.Parse((string)dataReader["MODIFICADOPORID"]) : (long?)null;
            //item.Domicilioid = dataReader["DOMICILIOID"] != System.DBNull.Value ? long.Parse((string)dataReader["DOMICILIOID"]) : (long?)null;
            //item.Contacto1id = dataReader["CONTACTO1ID"] != System.DBNull.Value ? long.Parse((string)dataReader["CONTACTO1ID"]) : (long?)null;
            //item.Contacto1_Domicilioid = dataReader["CONTACTO1_DOMICILIOID"] != System.DBNull.Value ? long.Parse((string)dataReader["CONTACTO1_DOMICILIOID"]) : (long?)null;
            //item.Contacto2id = dataReader["CONTACTO2ID"] != System.DBNull.Value ? long.Parse((string)dataReader["CONTACTO2ID"]) : (long?)null;
            //item.Contacto2_Domicilioid = dataReader["CONTACTO2_DOMICILIOID"] != System.DBNull.Value ? long.Parse((string)dataReader["CONTACTO2_DOMICILIOID"]) : (long?)null;
            item.PendMaxDias = dataReader["PENDMAXDIAS"] != System.DBNull.Value ? (int)dataReader["PENDMAXDIAS"] : (int?)null;
            //item.Saludoid = dataReader["SALUDOID"] != System.DBNull.Value ? long.Parse((string)dataReader["SALUDOID"]) : (long?)null;
            //item.Usuario_Preferencias_Grupousuarioid = dataReader["USUARIO_PREFERENCIAS_GRUPOUSUARIOID"] != System.DBNull.Value ? long.Parse((string)dataReader["USUARIO_PREFERENCIAS_GRUPOUSUARIOID"]) : (long?)null;
            //item.Usuario_Preferencias_Almacenid = dataReader["USUARIO_PREFERENCIAS_ALMACENID"] != System.DBNull.Value ? long.Parse((string)dataReader["USUARIO_PREFERENCIAS_ALMACENID"]) : (long?)null;
            //item.Usuario_Preferencias_Listaprecioid = dataReader["USUARIO_PREFERENCIAS_LISTAPRECIOID"] != System.DBNull.Value ? long.Parse((string)dataReader["USUARIO_PREFERENCIAS_LISTAPRECIOID"]) : (long?)null;
            //item.Usuario_Personafigura_Personaid = dataReader["USUARIO_PERSONAFIGURA_PERSONAID"] != System.DBNull.Value ? long.Parse((string)dataReader["USUARIO_PERSONAFIGURA_PERSONAID"]) : (long?)null;
            //item.Usuario_Personafigura_Sat_Figuratransporteid = dataReader["USUARIO_PERSONAFIGURA_SAT_FIGURATRANSPORTEID"] != System.DBNull.Value ? long.Parse((string)dataReader["USUARIO_PERSONAFIGURA_SAT_FIGURATRANSPORTEID"]) : (long?)null;
            //item.Usuario_Personafigura_Sat_Partetransporteid = dataReader["USUARIO_PERSONAFIGURA_SAT_PARTETRANSPORTEID"] != System.DBNull.Value ? long.Parse((string)dataReader["USUARIO_PERSONAFIGURA_SAT_PARTETRANSPORTEID"]) : (long?)null;
            //item.Usuario_fact_elect_Sat_id_pais = dataReader["USUARIO_FACT_ELECT_SAT_ID_PAIS"] != System.DBNull.Value ? long.Parse((string)dataReader["USUARIO_FACT_ELECT_SAT_ID_PAIS"]) : (long?)null;
            //item.Usuario_fact_elect_Sat_Coloniaid = dataReader["USUARIO_FACT_ELECT_SAT_COLONIAID"] != System.DBNull.Value ? long.Parse((string)dataReader["USUARIO_FACT_ELECT_SAT_COLONIAID"]) : (long?)null;
            //item.Usuario_fact_elect_Sat_Localidadid = dataReader["USUARIO_FACT_ELECT_SAT_LOCALIDADID"] != System.DBNull.Value ? long.Parse((string)dataReader["USUARIO_FACT_ELECT_SAT_LOCALIDADID"]) : (long?)null;
            //item.Usuario_fact_elect_Sat_Municipioid = dataReader["USUARIO_FACT_ELECT_SAT_MUNICIPIOID"] != System.DBNull.Value ? long.Parse((string)dataReader["USUARIO_FACT_ELECT_SAT_MUNICIPIOID"]) : (long?)null;
            //item.Usuario_fact_elect_Estadoid = dataReader["USUARIO_FACT_ELECT_ESTADOID"] != System.DBNull.Value ? long.Parse((string)dataReader["USUARIO_FACT_ELECT_ESTADOID"]) : (long?)null;
            //item.Usuario_emida_Clerkpagoserviciosid = dataReader["USUARIO_EMIDA_CLERKPAGOSERVICIOSID"] != System.DBNull.Value ? long.Parse((string)dataReader["USUARIO_EMIDA_CLERKPAGOSERVICIOSID"]) : (long?)null;
            //item.Usuario_emida_Clerkservicios = dataReader["USUARIO_EMIDA_CLERKSERVICIOS"] != System.DBNull.Value ? long.Parse((string)dataReader["USUARIO_EMIDA_CLERKSERVICIOS"]) : (long?)null;


            if (SaludoClave_obj != null)
                item.Saludoid = SaludoClave_obj.Id;
            else
                item.Saludoid = null;

            if (Usuario_Preferencias_GrupousuarioClave_obj != null)
                item.Usuario_Preferencias_Grupousuarioid = Usuario_Preferencias_GrupousuarioClave_obj.Id;
            else
                item.Usuario_Preferencias_Grupousuarioid = null;

            if (Usuario_Preferencias_AlmacenClave_obj != null)
                item.Usuario_Preferencias_Almacenid = Usuario_Preferencias_AlmacenClave_obj.Id;
            else
                item.Usuario_Preferencias_Almacenid = null;

            if (Usuario_Preferencias_ListaprecioClave_obj != null)
                item.Usuario_Preferencias_Listaprecioid = Usuario_Preferencias_ListaprecioClave_obj.Id;
            else
                item.Usuario_Preferencias_Listaprecioid = null;

            //if (Usuario_Personafigura_PersonaClave_obj != null)
            //    item.Usuario_Personafigura_Personaid = Usuario_Personafigura_PersonaClave_obj.Id;
            //else
            //    item.Usuario_Personafigura_Personaid = null;

            if (Usuario_Personafigura_Sat_FiguratransporteClave_obj != null)
                item.Usuario_Personafigura_Sat_Figuratransporteid = Usuario_Personafigura_Sat_FiguratransporteClave_obj.Id;
            else
                item.Usuario_Personafigura_Sat_Figuratransporteid = null;

            if (Usuario_Personafigura_Sat_PartetransporteClave_obj != null)
                item.Usuario_Personafigura_Sat_Partetransporteid = Usuario_Personafigura_Sat_PartetransporteClave_obj.Id;
            else
                item.Usuario_Personafigura_Sat_Partetransporteid = null;

            if (Usuario_fact_elect_Sat_paisClave_obj != null)
                item.Usuario_fact_elect_Sat_id_pais = Usuario_fact_elect_Sat_paisClave_obj.Id;
            else
                item.Usuario_fact_elect_Sat_id_pais = null;

            if (Usuario_fact_elect_Sat_ColoniaClave_obj != null)
                item.Usuario_fact_elect_Sat_Coloniaid = Usuario_fact_elect_Sat_ColoniaClave_obj.Id;
            else
                item.Usuario_fact_elect_Sat_Coloniaid = null;

            if (Usuario_fact_elect_Sat_LocalidadClave_obj != null)
                item.Usuario_fact_elect_Sat_Localidadid = Usuario_fact_elect_Sat_LocalidadClave_obj.Id;
            else
                item.Usuario_fact_elect_Sat_Localidadid = null;

            if (Usuario_fact_elect_Sat_MunicipioClave_obj != null)
                item.Usuario_fact_elect_Sat_Municipioid = Usuario_fact_elect_Sat_MunicipioClave_obj.Id;
            else
                item.Usuario_fact_elect_Sat_Municipioid = null;

            if (Usuario_fact_elect_EstadoClave_obj != null)
                item.Usuario_fact_elect_Estadoid = Usuario_fact_elect_EstadoClave_obj.Id;
            else
                item.Usuario_fact_elect_Estadoid = null;

            if (Usuario_emida_ClerkpagoserviciosClave_obj != null)
                item.Usuario_emida_Clerkpagoserviciosid = Usuario_emida_ClerkpagoserviciosClave_obj.Id;
            else
                item.Usuario_emida_Clerkpagoserviciosid = null;

            if (Usuario_emida_Clerkservicios_Clave_obj != null)
                item.Usuario_emida_Clerkservicios = Usuario_emida_Clerkservicios_Clave_obj.Id;
            else
                item.Usuario_emida_Clerkservicios = null;



            if (existItem)
            {
                controller.Update(item);
            }
            else
            {
                controller.Insert(item);
            }

            //localContext.SaveChanges();

            return true;
        }
    }
}