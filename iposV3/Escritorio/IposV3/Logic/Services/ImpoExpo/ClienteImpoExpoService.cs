
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
    public class ClienteImpoExpoService : BaseImpoExpoService
    {


        public void ImportarDeTablaFirebird(
                          long empresaId, long sucursalId, long? usuarioId, ref long? doctoId, long? tipoDoctoId,
                          string fbCadenaConexion,
                          string? nombreTabla, string? queryPersonalizada,
                           ApplicationDbContext localContext, ClienteController clienteController)
        {
            /**/
            FbDataReader? dr = null;
            FbConnection? pcn = null;

            var utf8 = new UTF8Encoding();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();

                String CmdTxt = @"SELECT
            PERSONA.CLAVE as CLAVE,
            PERSONA.NOMBRES as NOMBRES,
            PERSONA.APELLIDOS as APELLIDOS,
            PERSONA.RAZONSOCIAL as RAZONSOCIAL, 
            PERSONA.RFC as RFC, 
            PERSONA.TELEFONO1 as TELEFONO1, 
            PERSONA.TELEFONO2 as TELEFONO2, 
            PERSONA.TELEFONO3 as TELEFONO3, 
            PERSONA.CELULAR as CELULAR, 
            PERSONA.NEXTEL as NEXTEL, 
            PERSONA.EMAIL1 as EMAIL1, 
            PERSONA.EMAIL2 as EMAIL2, 
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
            PERSONA.ENTREGACALLE as DOMICILIOENTREGA_CALLE, 
            PERSONA.ENTREGANUMEROINTERIOR as DOMICILIOENTREGA_NUMEROEXTERIOR, 
            PERSONA.ENTREGANUMEROEXTERIOR as DOMICILIOENTREGA_NUMEROINTERIOR, 
            PERSONA.ENTREGACOLONIA as DOMICILIOENTREGA_COLONIA,
            PERSONA.ENTREGAMUNICIPIO as DOMICILIOENTREGA_MUNICIPIO, 
            PERSONA.ENTREGAESTADO as DOMICILIOENTREGA_ESTADO,
            PERSONA.ENTREGACODIGOPOSTAL as DOMICILIOENTREGA_CODIGOPOSTAL, 
            PERSONA.FIRMAIMAGEN as FIRMA,
            PERSONA.EMAIL3 as EMAIL3, 
            PERSONA.EMAIL4 as EMAIL4, 
            PERSONA.ENTREGAREFERENCIADOM as CLIENTE_FACT_ELECT_ENTREGAREFERENCIADOM,
            PERSONA.REVISION as CLIENTE_PAGO_PARAMETROS_REVISION, 
            PERSONA.PAGOS as CLIENTE_PAGO_PARAMETROS_PAGOS, 
            PERSONA.CREDITOREFERENCIAABONOS as CLIENTE_PAGO_PARAMETROS_CREDITOREFERENCIAABONOS, 
            PERSONA.BLOQUEONOT as CLIENTE_PAGO_PARAMETROS_BLOQUEONOT, 
            PERSONA.CUENTAIEPS as CLIENTE_POLIZA_CUENTAIEPS, 
            PERSONA.CUENTACONTPAQ as CLIENTE_POLIZA_CUENTACONTPAQ, 
            PERSONA.NOMBRES as NOMBRE, 
            PERSONA.SERVICIOADOMICILIO as CLIENTE_COMISION_SERVICIOADOMICILIO, 
            PERSONA.GENERARRECIBOELECTRONICO as CLIENTE_FACT_ELECT_GENERARRECIBOELECTRONICO,
            PERSONA.RETIENEISR as CLIENTE_FACT_ELECT_RETIENEISR, 
            PERSONA.RETIENEIVA as CLIENTE_FACT_ELECT_RETIENEIVA, 
            PERSONA.GENERACOMPROBTRASL as CLIENTE_FACT_ELECT_GENERACOMPROBTRASL, 
            PERSONA.GENERACARTAPORTE as CLIENTE_FACT_ELECT_GENERACARTAPORTE, 
            PERSONA.SOLICITAORDENCOMPRA as CLIENTE_ORDENCOMPRA_SOLICITAORDENCOMPRA, 
            PERSONA.HAB_PAGOTARJETA as CLIENTE_PAGO_PARAMETROS_HAB_PAGOTARJETA, 
            PERSONA.HAB_PAGOCREDITO as CLIENTE_PAGO_PARAMETROS_HAB_PAGOCREDITO, 
            PERSONA.HAB_PAGOCHEQUE as CLIENTE_PAGO_PARAMETROS_HAB_PAGOCHEQUE, 
            PERSONA.BLOQUEADO as CLIENTE_PAGO_PARAMETROS_BLOQUEADO, 
            PERSONA.HAB_PAGOTRANSFERENCIA as CLIENTE_PAGO_PARAMETROS_HAB_PAGOTRANSFERENCIA, 
            PERSONA.PAGOPARCIALIDADES as CLIENTE_PAGO_PARAMETROS_PAGOPARCIALIDADES, 
            PERSONA.EXENTOIVA as CLIENTE_PAGO_PARAMETROS_EXENTOIVA, 
            PERSONA.CARGOXVENTACONTARJETA as CLIENTE_PAGO_PARAMETROS_CARGOXVENTACONTARJETA, 
            PERSONA.PAGOTARJMENORPRECIOLISTA as CLIENTE_PAGO_PARAMETROS_PAGOTARJMENORPRECIOLISTA, 
            PERSONA.DESGLOSEIEPS as CLIENTE_POLIZA_DESGLOSEIEPS, 
            PERSONA.SEPARARPRODXPLAZO as CLIENTE_POLIZA_SEPARARPRODXPLAZO, 
            PERSONA.MAYOREOXPRODUCTO as CLIENTE_PRECIO_MAYOREOXPRODUCTO, 
            PERSONA.ACTIVO as ACTIVO, 
            PERSONA.HAB_PAGOEFECTIVO as CLIENTE_PAGO_PARAMETROS_HAB_PAGOEFECTIVO, 
            PERSONA.CREADO as CREADO, 
            PERSONA.MODIFICADO as MODIFICADO, 
            PERSONA.VIGENCIA as VIGENCIA,
            PERSONA.POR_COME as CLIENTE_COMISION_POR_COME, 
            PERSONA.DISTANCIA as CLIENTE_FACT_ELECT_DISTANCIA, 
            PERSONA.ENTREGA_DISTANCIA as CLIENTE_FACT_ELECT_ENTREGA_DISTANCIA, 
            PERSONA.SALDO as CLIENTE_PAGO_SALDO, 
            PERSONA.SALDOAPARTADONEGATIVO as CLIENTE_PAGO_SALDOAPARTADONEGATIVO, 
            PERSONA.SALDOAPARTADOPOSITIVO as CLIENTE_PAGO_SALDOAPARTADOPOSITIVO, 
            PERSONA.SALDOSPOSITIVOS as CLIENTE_PAGO_SALDOSPOSITIVOS, 
            PERSONA.SALDOSNEGATIVOS as CLIENTE_PAGO_SALDOSNEGATIVOS,
            PERSONA.LIMITECREDITO as CLIENTE_PAGO_PARAMETROS_LIMITECREDITO,
            PERSONA.DIAS_EXTR as CLIENTE_PAGO_PARAMETROS_DIAS_EXTR,
            PERSONA.subtipocliente SUBTIPOCLIENTECLAVE ,
            PROVEECLIENTE.clave  PROVEECLIENTECLAVE ,
            VENDEDORCOMISION.clave CLIENTE_COMISION_VENDEDORCLAVE ,
            CREDITOFORMAPAGOSAT.clave CLIENTE_FACT_ELECT_CREDITOFORMAPAGOSATABONOS_CLAVE ,
            SAT_USOCFDI.sat_clave CLIENTE_FACT_ELECT_SAT_USOCFDICLAVE  ,
            PERSONA.sat_clave_pais  CLIENTE_FACT_ELECT_SAT_PAISCLAVE,
            SAT_COLONIA.colonia CLIENTE_FACT_ELECT_SAT_COLONIACLAVE,
            SAT_LOCALIDAD.clave_localidad CLIENTE_FACT_ELECT_SAT_LOCALIDADCLAVE ,
            PERSONA.estado CLIENTE_FACT_ELECT_SAT_ESTADOCLAVE ,
            SAT_MUNICIPIO.clave_municipio CLIENTE_FACT_ELECT_SAT_MUNICIPIOCLAVE    ,
            SAT_COLONIA_ENTREGA.colonia CLIENTE_FACT_ELECT_ENTREGA_SAT_COLONIACLAVE ,
            SAT_LOCALIDAD_ENTREGA.clave_localidad CLIENTE_FACT_ELECT_ENTREGA_SAT_LOCALIDADCLAVE,
            SAT_MUNICIPIO_ENTREGA.clave_municipio CLIENTE_FACT_ELECT_ENTREGA_SAT_MUNICIPIOCLAVE ,
            SAT_MUNICIPIO_ENTREGA.clave_estado   CLIENTE_FACT_ELECT_ENTREGA_SAT_ESTADOCLAVE,
            SAT_REGIMENFISCAL.sat_clave CLIENTE_FACT_ELECT_SAT_REGIMENFISCALCLAVE ,
            CREDITOFORMAPAGO.clave CLIENTE_PAGO_PARAMETROS_CREDITOFORMAPAGOABONOS_CLAVE ,
            MONEDA.CLAVE CLIENTE_PAGO_PARAMETROS_MONEDACLAVE ,
            LISTAPRECIO.CLAVE CLIENTE_PRECIO_LISTAPRECIOCLAVE ,
            SUPERLISTAPRECIO.CLAVE CLIENTE_PRECIO_SUPERLISTAPRECIOCLAVE ,
            RUTAEMBARQUE.CLAVE CLIENTE_RUTAEMBARQUE_RUTAEMBARQUECLAVE
            FROM PERSONA
            LEFT JOIN PERSONA PROVEECLIENTE ON PROVEECLIENTE.ID =  PERSONA.PROVEECLIENTEID
            LEFT JOIN PERSONA VENDEDORCOMISION ON VENDEDORCOMISION.ID = PERSONA.vendedorid
            LEFT JOIN FORMAPAGOSAT CREDITOFORMAPAGOSAT ON CREDITOFORMAPAGOSAT.ID = PERSONA.creditoformapagosatabonos
            LEFT JOIN SAT_USOCFDI  ON SAT_USOCFDI.ID = PERSONA.SAT_USOCFDIID
            LEFT JOIN SAT_COLONIA ON SAT_COLONIA.ID = PERSONA.sat_coloniaid   
            LEFT JOIN SAT_LOCALIDAD ON SAT_LOCALIDAD.ID = PERSONA.sat_localidadid
            LEFT JOIN SAT_MUNICIPIO ON SAT_MUNICIPIO.ID = PERSONA.sat_municipioid
            LEFT JOIN SAT_COLONIA SAT_COLONIA_ENTREGA ON SAT_COLONIA_ENTREGA.ID = PERSONA.entrega_sat_coloniaid
            LEFT JOIN SAT_LOCALIDAD SAT_LOCALIDAD_ENTREGA ON SAT_LOCALIDAD_ENTREGA.ID = PERSONA.entrega_sat_localidadid
            LEFT JOIN SAT_MUNICIPIO SAT_MUNICIPIO_ENTREGA ON SAT_MUNICIPIO_ENTREGA.ID = PERSONA.entrega_sat_municipioid
            LEFT JOIN SAT_REGIMENFISCAL ON SAT_REGIMENFISCAL.ID = PERSONA.sat_regimenfiscalid
            LEFT JOIN FORMAPAGO CREDITOFORMAPAGO ON CREDITOFORMAPAGO.ID = PERSONA.creditoformapagoabonos
            LEFT JOIN MONEDA ON MONEDA.ID = PERSONA.MONEDAID
            LEFT JOIN listaprecio ON LISTAPRECIO.ID = PERSONA.listaprecioid
            LEFT JOIN listaprecio SUPERLISTAPRECIO ON SUPERLISTAPRECIO.ID = PERSONA.superlistaprecioid
            LEFT JOIN RUTAEMBARQUE ON RUTAEMBARQUE.ID = PERSONA.rutaembarqueid
          WHERE PERSONA.tipopersonaid IN (50) ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                dr = FbSqlHelper.ExecuteReader(fbCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {

                    ImportFromFirebirdReader(empresaId, sucursalId, usuarioId, ref doctoId, tipoDoctoId,
                                             dr, localContext, clienteController);
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
                                               FbDataReader dataReader, ApplicationDbContext localContext, ClienteController controller)
        {

            var clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";

            var codigoPostal = dataReader["DOMICILIO_CODIGOPOSTAL"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_CODIGOPOSTAL"]).Trim() : "";

            var estado = dataReader["DOMICILIO_ESTADO"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_ESTADO"]).Trim() : "";

            var codigoPostalEntrega = dataReader["DOMICILIOENTREGA_CODIGOPOSTAL"] != System.DBNull.Value ? ((string)dataReader["DOMICILIOENTREGA_CODIGOPOSTAL"]).Trim() : "";

            var estadoEntrega = dataReader["DOMICILIOENTREGA_ESTADO"] != System.DBNull.Value ? ((string)dataReader["DOMICILIOENTREGA_ESTADO"]).Trim() : "";


            var SubtipoclienteClave = dataReader["SUBTIPOCLIENTECLAVE"] != System.DBNull.Value ? ((string)dataReader["SUBTIPOCLIENTECLAVE"]).Trim() : "";

            var ProveeclienteClave = dataReader["PROVEECLIENTECLAVE"] != System.DBNull.Value ? ((string)dataReader["PROVEECLIENTECLAVE"]).Trim() : "";

            //var Cliente_bancomer_BancomerdoctopendClave = dataReader["CLIENTE_BANCOMER_BANCOMERDOCTOPENDCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_BANCOMER_BANCOMERDOCTOPENDCLAVE"]).Trim() : "";

            var Cliente_comision_VendedorClave = dataReader["CLIENTE_COMISION_VENDEDORCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_COMISION_VENDEDORCLAVE"]).Trim() : "";

            var Cliente_fact_elect_Creditoformapagosatabonos_Clave = dataReader["CLIENTE_FACT_ELECT_CREDITOFORMAPAGOSATABONOS_CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_CREDITOFORMAPAGOSATABONOS_CLAVE"]).Trim() : "";

            var Cliente_fact_elect_Sat_usocfdiClave = dataReader["CLIENTE_FACT_ELECT_SAT_USOCFDICLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_USOCFDICLAVE"]).Trim() : "";

            var Cliente_fact_elect_Sat_paisClave = dataReader["CLIENTE_FACT_ELECT_SAT_PAISCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_PAISCLAVE"]).Trim() : "";

            var Cliente_fact_elect_Sat_ColoniaClave = dataReader["CLIENTE_FACT_ELECT_SAT_COLONIACLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_COLONIACLAVE"]).Trim() : "";

            var Cliente_fact_elect_Sat_LocalidadClave = dataReader["CLIENTE_FACT_ELECT_SAT_LOCALIDADCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_LOCALIDADCLAVE"]).Trim() : "";

            var Cliente_fact_elect_Sat_MunicipioClave = dataReader["CLIENTE_FACT_ELECT_SAT_MUNICIPIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_MUNICIPIOCLAVE"]).Trim() : "";

            var Cliente_fact_elect_Entrega_Sat_ColoniaClave = dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_COLONIACLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_COLONIACLAVE"]).Trim() : "";

            var Cliente_fact_elect_Entrega_Sat_LocalidadClave = dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_LOCALIDADCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_LOCALIDADCLAVE"]).Trim() : "";

            var Cliente_fact_elect_Entrega_Sat_MunicipioClave = dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_MUNICIPIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_MUNICIPIOCLAVE"]).Trim() : "";

            var Cliente_fact_elect_Sat_RegimenfiscalClave = dataReader["CLIENTE_FACT_ELECT_SAT_REGIMENFISCALCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_REGIMENFISCALCLAVE"]).Trim() : "";

            var Cliente_pago_parametros_Creditoformapagoabonos_Clave = dataReader["CLIENTE_PAGO_PARAMETROS_CREDITOFORMAPAGOABONOS_CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PAGO_PARAMETROS_CREDITOFORMAPAGOABONOS_CLAVE"]).Trim() : "";

            var Cliente_pago_parametros_MonedaClave = dataReader["CLIENTE_PAGO_PARAMETROS_MONEDACLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PAGO_PARAMETROS_MONEDACLAVE"]).Trim() : "";

            var Cliente_precio_ListaprecioClave = dataReader["CLIENTE_PRECIO_LISTAPRECIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PRECIO_LISTAPRECIOCLAVE"]).Trim() : "";

            var Cliente_precio_SuperlistaprecioClave = dataReader["CLIENTE_PRECIO_SUPERLISTAPRECIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PRECIO_SUPERLISTAPRECIOCLAVE"]).Trim() : "";

            var Cliente_rutaembarque_RutaembarqueClave = dataReader["CLIENTE_RUTAEMBARQUE_RUTAEMBARQUECLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_RUTAEMBARQUE_RUTAEMBARQUECLAVE"]).Trim() : "";


            var itemSaved = localContext.Cliente.AsNoTracking()
                                        .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == clave);


            var SubtipoclienteClave_obj = localContext.Subtipocliente.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == SubtipoclienteClave);

            var ProveeclienteClave_obj = localContext.Proveedor.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == ProveeclienteClave);

            //var Cliente_bancomer_BancomerdoctopendClave_obj = localContext.Docto.AsNoTracking()
            //                                .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
            //                                                 i.Clave == Cliente_bancomer_BancomerdoctopendClave);

            var Cliente_comision_VendedorClave_obj = localContext.Usuario.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.UsuarioNombre == Cliente_comision_VendedorClave);

            var Cliente_fact_elect_Creditoformapagosatabonos_Clave_obj = localContext.Formapagosat.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Cliente_fact_elect_Creditoformapagosatabonos_Clave);

            var Cliente_fact_elect_Sat_usocfdiClave_obj = localContext.Sat_usocfdi.AsNoTracking()
                                            .FirstOrDefault(i => i.Sat_clave == Cliente_fact_elect_Sat_usocfdiClave);

            var Cliente_fact_elect_Sat_paisClave_obj = localContext.Sat_pais.AsNoTracking()
                                            .FirstOrDefault(i => i.Sat_clave == Cliente_fact_elect_Sat_paisClave);

            var Cliente_fact_elect_Sat_ColoniaClave_obj = localContext.Sat_colonia.AsNoTracking()
                                            .FirstOrDefault(i => i.Colonia == Cliente_fact_elect_Sat_ColoniaClave && i.Codigopostal == codigoPostal);

            var Cliente_fact_elect_Sat_LocalidadClave_obj = localContext.Sat_localidad.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave_localidad == Cliente_fact_elect_Sat_LocalidadClave && i.Clave_estado == estado);

            var Cliente_fact_elect_Sat_MunicipioClave_obj = localContext.Sat_municipio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave_municipio == Cliente_fact_elect_Sat_MunicipioClave && i.Clave_estado == estado);

            var Cliente_fact_elect_Entrega_Sat_ColoniaClave_obj = localContext.Sat_colonia.AsNoTracking()
                                            .FirstOrDefault(i =>  i.Colonia == Cliente_fact_elect_Entrega_Sat_ColoniaClave && i.Codigopostal == codigoPostalEntrega);

            var Cliente_fact_elect_Entrega_Sat_LocalidadClave_obj = localContext.Sat_localidad.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave_localidad == Cliente_fact_elect_Entrega_Sat_LocalidadClave && i.Clave_estado == estadoEntrega);

            var Cliente_fact_elect_Entrega_Sat_MunicipioClave_obj = localContext.Sat_municipio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave_municipio == Cliente_fact_elect_Entrega_Sat_MunicipioClave && i.Clave_estado == estadoEntrega);

            var Cliente_fact_elect_Sat_RegimenfiscalClave_obj = localContext.Sat_regimenfiscal.AsNoTracking()
                                            .FirstOrDefault(i => i.Sat_clave == Cliente_fact_elect_Sat_RegimenfiscalClave);

            var Cliente_pago_parametros_Creditoformapagoabonos_Clave_obj = localContext.Formapago.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Cliente_pago_parametros_Creditoformapagoabonos_Clave);

            var Cliente_pago_parametros_MonedaClave_obj = localContext.Moneda.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Cliente_pago_parametros_MonedaClave);

            var Cliente_precio_ListaprecioClave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Cliente_precio_ListaprecioClave);

            var Cliente_precio_SuperlistaprecioClave_obj = localContext.Tipoprecio.AsNoTracking()
                                            .FirstOrDefault(i => i.Clave == Cliente_precio_SuperlistaprecioClave);

            var Cliente_rutaembarque_RutaembarqueClave_obj = localContext.Rutaembarque.AsNoTracking()
                                            .FirstOrDefault(i => i.EmpresaId == empresaId && i.SucursalId == sucursalId &&
                                                             i.Clave == Cliente_rutaembarque_RutaembarqueClave);


            var item = itemSaved != null ? new ClienteBindingModel(itemSaved) : new ClienteBindingModel();
            var existItem = itemSaved != null;

            item.EmpresaId = empresaId;
            item.SucursalId = sucursalId;


            item.Clave = dataReader["CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLAVE"]).Trim() : "";
            item.Nombres = dataReader["NOMBRES"] != System.DBNull.Value ? ((string)dataReader["NOMBRES"]).Trim() : "";
            item.Apellidos = dataReader["APELLIDOS"] != System.DBNull.Value ? ((string)dataReader["APELLIDOS"]).Trim() : "";
            item.Razonsocial = dataReader["RAZONSOCIAL"] != System.DBNull.Value ? ((string)dataReader["RAZONSOCIAL"]).Trim() : "";
            item.Rfc = dataReader["RFC"] != System.DBNull.Value ? ((string)dataReader["RFC"]).Trim() : "";
            item.Telefono1 = dataReader["TELEFONO1"] != System.DBNull.Value ? ((string)dataReader["TELEFONO1"]).Trim() : "";
            item.Telefono2 = dataReader["TELEFONO2"] != System.DBNull.Value ? ((string)dataReader["TELEFONO2"]).Trim() : "";
            item.Telefono3 = dataReader["TELEFONO3"] != System.DBNull.Value ? ((string)dataReader["TELEFONO3"]).Trim() : "";
            item.Celular = dataReader["CELULAR"] != System.DBNull.Value ? ((string)dataReader["CELULAR"]).Trim() : "";
            item.Nextel = dataReader["NEXTEL"] != System.DBNull.Value ? ((string)dataReader["NEXTEL"]).Trim() : "";
            item.Email1 = dataReader["EMAIL1"] != System.DBNull.Value ? ((string)dataReader["EMAIL1"]).Trim() : "";
            item.Email2 = dataReader["EMAIL2"] != System.DBNull.Value ? ((string)dataReader["EMAIL2"]).Trim() : "";
            item.Domicilio_Calle = dataReader["DOMICILIO_CALLE"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_CALLE"]).Trim() : "";
            item.Domicilio_Numeroexterior = dataReader["DOMICILIO_NUMEROEXTERIOR"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_NUMEROEXTERIOR"]).Trim() : "";
            item.Domicilio_Numerointerior = dataReader["DOMICILIO_NUMEROINTERIOR"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_NUMEROINTERIOR"]).Trim() : "";
            item.Domicilio_Colonia = dataReader["DOMICILIO_COLONIA"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_COLONIA"]).Trim() : "";
            item.Domicilio_Ciudad = dataReader["DOMICILIO_CIUDAD"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_CIUDAD"]).Trim() : "";
            item.Domicilio_Municipio = dataReader["DOMICILIO_MUNICIPIO"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_MUNICIPIO"]).Trim() : "";
            item.Domicilio_Estado = dataReader["DOMICILIO_ESTADO"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_ESTADO"]).Trim() : "";
            item.Domicilio_Pais = dataReader["DOMICILIO_PAIS"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_PAIS"]).Trim() : "";
            item.Domicilio_Codigopostal = dataReader["DOMICILIO_CODIGOPOSTAL"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_CODIGOPOSTAL"]).Trim() : "";
            item.Domicilio_Referencia = dataReader["DOMICILIO_REFERENCIA"] != System.DBNull.Value ? ((string)dataReader["DOMICILIO_REFERENCIA"]).Trim() : "";
            item.Contacto1_Nombre = dataReader["CONTACTO1_NOMBRE"] != System.DBNull.Value ? ((string)dataReader["CONTACTO1_NOMBRE"]).Trim() : "";
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
            item.Contacto2_Nombre = dataReader["CONTACTO2_NOMBRE"] != System.DBNull.Value ? ((string)dataReader["CONTACTO2_NOMBRE"]).Trim() : "";
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
            item.Domicilioentrega_Calle = dataReader["DOMICILIOENTREGA_CALLE"] != System.DBNull.Value ? ((string)dataReader["DOMICILIOENTREGA_CALLE"]).Trim() : "";
            item.Domicilioentrega_Numeroexterior = dataReader["DOMICILIOENTREGA_NUMEROEXTERIOR"] != System.DBNull.Value ? ((string)dataReader["DOMICILIOENTREGA_NUMEROEXTERIOR"]).Trim() : "";
            item.Domicilioentrega_Numerointerior = dataReader["DOMICILIOENTREGA_NUMEROINTERIOR"] != System.DBNull.Value ? ((string)dataReader["DOMICILIOENTREGA_NUMEROINTERIOR"]).Trim() : "";
            item.Domicilioentrega_Colonia = dataReader["DOMICILIOENTREGA_COLONIA"] != System.DBNull.Value ? ((string)dataReader["DOMICILIOENTREGA_COLONIA"]).Trim() : "";
            //item.Domicilioentrega_Ciudad = dataReader["DOMICILIOENTREGA_CIUDAD"] != System.DBNull.Value ? ((string)dataReader["DOMICILIOENTREGA_CIUDAD"]).Trim() : "";
            item.Domicilioentrega_Municipio = dataReader["DOMICILIOENTREGA_MUNICIPIO"] != System.DBNull.Value ? ((string)dataReader["DOMICILIOENTREGA_MUNICIPIO"]).Trim() : "";
            item.Domicilioentrega_Estado = dataReader["DOMICILIOENTREGA_ESTADO"] != System.DBNull.Value ? ((string)dataReader["DOMICILIOENTREGA_ESTADO"]).Trim() : "";
            //item.Domicilioentrega_Pais = dataReader["DOMICILIOENTREGA_PAIS"] != System.DBNull.Value ? ((string)dataReader["DOMICILIOENTREGA_PAIS"]).Trim() : "";
            item.Domicilioentrega_Codigopostal = dataReader["DOMICILIOENTREGA_CODIGOPOSTAL"] != System.DBNull.Value ? ((string)dataReader["DOMICILIOENTREGA_CODIGOPOSTAL"]).Trim() : "";
            //item.Domicilioentrega_Referencia = dataReader["DOMICILIOENTREGA_REFERENCIA"] != System.DBNull.Value ? ((string)dataReader["DOMICILIOENTREGA_REFERENCIA"]).Trim() : "";
            //item.SubtipoclienteClave = dataReader["SUBTIPOCLIENTECLAVE"] != System.DBNull.Value ? ((string)dataReader["SUBTIPOCLIENTECLAVE"]).Trim() : null;
            //item.SubtipoclienteNombre = dataReader["SUBTIPOCLIENTENOMBRE"] != System.DBNull.Value ? ((string)dataReader["SUBTIPOCLIENTENOMBRE"]).Trim() : null;
            //item.ProveeclienteClave = dataReader["PROVEECLIENTECLAVE"] != System.DBNull.Value ? ((string)dataReader["PROVEECLIENTECLAVE"]).Trim() : null;
            //item.ProveeclienteNombre = dataReader["PROVEECLIENTENOMBRE"] != System.DBNull.Value ? ((string)dataReader["PROVEECLIENTENOMBRE"]).Trim() : null;
            item.Firma = dataReader["FIRMA"] != System.DBNull.Value ? ((string)dataReader["FIRMA"]).Trim() : "";
            item.Email3 = dataReader["EMAIL3"] != System.DBNull.Value ? ((string)dataReader["EMAIL3"]).Trim() : "";
            item.Email4 = dataReader["EMAIL4"] != System.DBNull.Value ? ((string)dataReader["EMAIL4"]).Trim() : "";
            //item.Cliente_bancomer_BancomerdoctopendClave = dataReader["CLIENTE_BANCOMER_BANCOMERDOCTOPENDCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_BANCOMER_BANCOMERDOCTOPENDCLAVE"]).Trim() : null;
            //item.Cliente_bancomer_BancomerdoctopendNombre = dataReader["CLIENTE_BANCOMER_BANCOMERDOCTOPENDNOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_BANCOMER_BANCOMERDOCTOPENDNOMBRE"]).Trim() : null;
            //item.Cliente_comision_VendedorClave = dataReader["CLIENTE_COMISION_VENDEDORCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_COMISION_VENDEDORCLAVE"]).Trim() : null;
            //item.Cliente_comision_VendedorNombre = dataReader["CLIENTE_COMISION_VENDEDORNOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_COMISION_VENDEDORNOMBRE"]).Trim() : null;
            //item.Cliente_fact_elect_Creditoformapagosatabonos_Clave = dataReader["CLIENTE_FACT_ELECT_CREDITOFORMAPAGOSATABONOS_CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_CREDITOFORMAPAGOSATABONOS_CLAVE"]).Trim() : null;
            //item.Cliente_fact_elect_Creditoformapagosatabonos_Nombre = dataReader["CLIENTE_FACT_ELECT_CREDITOFORMAPAGOSATABONOS_NOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_CREDITOFORMAPAGOSATABONOS_NOMBRE"]).Trim() : null;
            //item.Cliente_fact_elect_Sat_usocfdiClave = dataReader["CLIENTE_FACT_ELECT_SAT_USOCFDICLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_USOCFDICLAVE"]).Trim() : null;
            //item.Cliente_fact_elect_Sat_usocfdiNombre = dataReader["CLIENTE_FACT_ELECT_SAT_USOCFDINOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_USOCFDINOMBRE"]).Trim() : null;
            //item.Cliente_fact_elect_Sat_paisClave = dataReader["CLIENTE_FACT_ELECT_SAT_PAISCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_PAISCLAVE"]).Trim() : null;
            //item.Cliente_fact_elect_Sat_paisNombre = dataReader["CLIENTE_FACT_ELECT_SAT_PAISNOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_PAISNOMBRE"]).Trim() : null;
            //item.Cliente_fact_elect_Sat_ColoniaClave = dataReader["CLIENTE_FACT_ELECT_SAT_COLONIACLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_COLONIACLAVE"]).Trim() : null;
            //item.Cliente_fact_elect_Sat_ColoniaNombre = dataReader["CLIENTE_FACT_ELECT_SAT_COLONIANOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_COLONIANOMBRE"]).Trim() : null;
            //item.Cliente_fact_elect_Sat_LocalidadClave = dataReader["CLIENTE_FACT_ELECT_SAT_LOCALIDADCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_LOCALIDADCLAVE"]).Trim() : null;
            //item.Cliente_fact_elect_Sat_LocalidadNombre = dataReader["CLIENTE_FACT_ELECT_SAT_LOCALIDADNOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_LOCALIDADNOMBRE"]).Trim() : null;
            //item.Cliente_fact_elect_Sat_MunicipioClave = dataReader["CLIENTE_FACT_ELECT_SAT_MUNICIPIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_MUNICIPIOCLAVE"]).Trim() : null;
            //item.Cliente_fact_elect_Sat_MunicipioNombre = dataReader["CLIENTE_FACT_ELECT_SAT_MUNICIPIONOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_MUNICIPIONOMBRE"]).Trim() : null;
            //item.Cliente_fact_elect_Entrega_Sat_ColoniaClave = dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_COLONIACLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_COLONIACLAVE"]).Trim() : null;
            //item.Cliente_fact_elect_Entrega_Sat_ColoniaNombre = dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_COLONIANOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_COLONIANOMBRE"]).Trim() : null;
            //item.Cliente_fact_elect_Entrega_Sat_LocalidadClave = dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_LOCALIDADCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_LOCALIDADCLAVE"]).Trim() : null;
            //item.Cliente_fact_elect_Entrega_Sat_LocalidadNombre = dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_LOCALIDADNOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_LOCALIDADNOMBRE"]).Trim() : null;
            //item.Cliente_fact_elect_Entrega_Sat_MunicipioClave = dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_MUNICIPIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_MUNICIPIOCLAVE"]).Trim() : null;
            //item.Cliente_fact_elect_Entrega_Sat_MunicipioNombre = dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_MUNICIPIONOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_MUNICIPIONOMBRE"]).Trim() : null;
            item.Cliente_fact_elect_Entregareferenciadom = dataReader["CLIENTE_FACT_ELECT_ENTREGAREFERENCIADOM"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_ENTREGAREFERENCIADOM"]).Trim() : "";
            //item.Cliente_fact_elect_Sat_RegimenfiscalClave = dataReader["CLIENTE_FACT_ELECT_SAT_REGIMENFISCALCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_REGIMENFISCALCLAVE"]).Trim() : null;
            //item.Cliente_fact_elect_Sat_RegimenfiscalNombre = dataReader["CLIENTE_FACT_ELECT_SAT_REGIMENFISCALNOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_FACT_ELECT_SAT_REGIMENFISCALNOMBRE"]).Trim() : null;
            item.Cliente_pago_parametros_Revision = dataReader["CLIENTE_PAGO_PARAMETROS_REVISION"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PAGO_PARAMETROS_REVISION"]).Trim() : "";
            item.Cliente_pago_parametros_Pagos = dataReader["CLIENTE_PAGO_PARAMETROS_PAGOS"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PAGO_PARAMETROS_PAGOS"]).Trim() : "";
            item.Cliente_pago_parametros_Creditoreferenciaabonos = dataReader["CLIENTE_PAGO_PARAMETROS_CREDITOREFERENCIAABONOS"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PAGO_PARAMETROS_CREDITOREFERENCIAABONOS"]).Trim() : "";
            item.Cliente_pago_parametros_Bloqueonot = dataReader["CLIENTE_PAGO_PARAMETROS_BLOQUEONOT"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PAGO_PARAMETROS_BLOQUEONOT"]).Trim() : "";
            //item.Cliente_pago_parametros_Creditoformapagoabonos_Clave = dataReader["CLIENTE_PAGO_PARAMETROS_CREDITOFORMAPAGOABONOS_CLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PAGO_PARAMETROS_CREDITOFORMAPAGOABONOS_CLAVE"]).Trim() : null;
            //item.Cliente_pago_parametros_Creditoformapagoabonos_Nombre = dataReader["CLIENTE_PAGO_PARAMETROS_CREDITOFORMAPAGOABONOS_NOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PAGO_PARAMETROS_CREDITOFORMAPAGOABONOS_NOMBRE"]).Trim() : null;
            //item.Cliente_pago_parametros_MonedaClave = dataReader["CLIENTE_PAGO_PARAMETROS_MONEDACLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PAGO_PARAMETROS_MONEDACLAVE"]).Trim() : null;
            //item.Cliente_pago_parametros_MonedaNombre = dataReader["CLIENTE_PAGO_PARAMETROS_MONEDANOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PAGO_PARAMETROS_MONEDANOMBRE"]).Trim() : null;
            item.Cliente_poliza_Cuentaieps = dataReader["CLIENTE_POLIZA_CUENTAIEPS"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_POLIZA_CUENTAIEPS"]).Trim() : "";
            item.Cliente_poliza_Cuentacontpaq = dataReader["CLIENTE_POLIZA_CUENTACONTPAQ"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_POLIZA_CUENTACONTPAQ"]).Trim() : "";
            //item.Cliente_precio_ListaprecioClave = dataReader["CLIENTE_PRECIO_LISTAPRECIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PRECIO_LISTAPRECIOCLAVE"]).Trim() : null;
            //item.Cliente_precio_ListaprecioNombre = dataReader["CLIENTE_PRECIO_LISTAPRECIONOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PRECIO_LISTAPRECIONOMBRE"]).Trim() : null;
            //item.Cliente_precio_SuperlistaprecioClave = dataReader["CLIENTE_PRECIO_SUPERLISTAPRECIOCLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PRECIO_SUPERLISTAPRECIOCLAVE"]).Trim() : null;
            //item.Cliente_precio_SuperlistaprecioNombre = dataReader["CLIENTE_PRECIO_SUPERLISTAPRECIONOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_PRECIO_SUPERLISTAPRECIONOMBRE"]).Trim() : null;
            //item.Cliente_rutaembarque_RutaembarqueClave = dataReader["CLIENTE_RUTAEMBARQUE_RUTAEMBARQUECLAVE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_RUTAEMBARQUE_RUTAEMBARQUECLAVE"]).Trim() : null;
            //item.Cliente_rutaembarque_RutaembarqueNombre = dataReader["CLIENTE_RUTAEMBARQUE_RUTAEMBARQUENOMBRE"] != System.DBNull.Value ? ((string)dataReader["CLIENTE_RUTAEMBARQUE_RUTAEMBARQUENOMBRE"]).Trim() : null;
            item.Nombre = dataReader["NOMBRE"] != System.DBNull.Value ? ((string)dataReader["NOMBRE"]).Trim() : "";
            item.Cliente_comision_Servicioadomicilio = dataReader["CLIENTE_COMISION_SERVICIOADOMICILIO"] != System.DBNull.Value && ((string)dataReader["CLIENTE_COMISION_SERVICIOADOMICILIO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_fact_elect_Generarreciboelectronico = dataReader["CLIENTE_FACT_ELECT_GENERARRECIBOELECTRONICO"] != System.DBNull.Value && ((string)dataReader["CLIENTE_FACT_ELECT_GENERARRECIBOELECTRONICO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_fact_elect_Retieneisr = dataReader["CLIENTE_FACT_ELECT_RETIENEISR"] != System.DBNull.Value && ((string)dataReader["CLIENTE_FACT_ELECT_RETIENEISR"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_fact_elect_Retieneiva = dataReader["CLIENTE_FACT_ELECT_RETIENEIVA"] != System.DBNull.Value && ((string)dataReader["CLIENTE_FACT_ELECT_RETIENEIVA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            //item.Cliente_fact_elect_Desglosaieps = dataReader["CLIENTE_FACT_ELECT_DESGLOSAIEPS"] != System.DBNull.Value && ((string)dataReader["CLIENTE_FACT_ELECT_DESGLOSAIEPS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_fact_elect_Generacomprobtrasl = dataReader["CLIENTE_FACT_ELECT_GENERACOMPROBTRASL"] != System.DBNull.Value && ((string)dataReader["CLIENTE_FACT_ELECT_GENERACOMPROBTRASL"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_fact_elect_Generacartaporte = dataReader["CLIENTE_FACT_ELECT_GENERACARTAPORTE"] != System.DBNull.Value && ((string)dataReader["CLIENTE_FACT_ELECT_GENERACARTAPORTE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_ordencompra_Solicitaordencompra = dataReader["CLIENTE_ORDENCOMPRA_SOLICITAORDENCOMPRA"] != System.DBNull.Value && ((string)dataReader["CLIENTE_ORDENCOMPRA_SOLICITAORDENCOMPRA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_pago_parametros_Hab_pagotarjeta = dataReader["CLIENTE_PAGO_PARAMETROS_HAB_PAGOTARJETA"] != System.DBNull.Value && ((string)dataReader["CLIENTE_PAGO_PARAMETROS_HAB_PAGOTARJETA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_pago_parametros_Hab_pagocredito = dataReader["CLIENTE_PAGO_PARAMETROS_HAB_PAGOCREDITO"] != System.DBNull.Value && ((string)dataReader["CLIENTE_PAGO_PARAMETROS_HAB_PAGOCREDITO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_pago_parametros_Hab_pagocheque = dataReader["CLIENTE_PAGO_PARAMETROS_HAB_PAGOCHEQUE"] != System.DBNull.Value && ((string)dataReader["CLIENTE_PAGO_PARAMETROS_HAB_PAGOCHEQUE"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_pago_parametros_Bloqueado = dataReader["CLIENTE_PAGO_PARAMETROS_BLOQUEADO"] != System.DBNull.Value && ((string)dataReader["CLIENTE_PAGO_PARAMETROS_BLOQUEADO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_pago_parametros_Hab_pagotransferencia = dataReader["CLIENTE_PAGO_PARAMETROS_HAB_PAGOTRANSFERENCIA"] != System.DBNull.Value && ((string)dataReader["CLIENTE_PAGO_PARAMETROS_HAB_PAGOTRANSFERENCIA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_pago_parametros_Pagoparcialidades = dataReader["CLIENTE_PAGO_PARAMETROS_PAGOPARCIALIDADES"] != System.DBNull.Value && ((string)dataReader["CLIENTE_PAGO_PARAMETROS_PAGOPARCIALIDADES"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_pago_parametros_Exentoiva = dataReader["CLIENTE_PAGO_PARAMETROS_EXENTOIVA"] != System.DBNull.Value && ((string)dataReader["CLIENTE_PAGO_PARAMETROS_EXENTOIVA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_pago_parametros_Cargoxventacontarjeta = dataReader["CLIENTE_PAGO_PARAMETROS_CARGOXVENTACONTARJETA"] != System.DBNull.Value && ((string)dataReader["CLIENTE_PAGO_PARAMETROS_CARGOXVENTACONTARJETA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_pago_parametros_Pagotarjmenorpreciolista = dataReader["CLIENTE_PAGO_PARAMETROS_PAGOTARJMENORPRECIOLISTA"] != System.DBNull.Value && ((string)dataReader["CLIENTE_PAGO_PARAMETROS_PAGOTARJMENORPRECIOLISTA"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_poliza_Desgloseieps = dataReader["CLIENTE_POLIZA_DESGLOSEIEPS"] != System.DBNull.Value && ((string)dataReader["CLIENTE_POLIZA_DESGLOSEIEPS"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_poliza_Separarprodxplazo = dataReader["CLIENTE_POLIZA_SEPARARPRODXPLAZO"] != System.DBNull.Value && ((string)dataReader["CLIENTE_POLIZA_SEPARARPRODXPLAZO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Cliente_precio_Mayoreoxproducto = dataReader["CLIENTE_PRECIO_MAYOREOXPRODUCTO"] != System.DBNull.Value && ((string)dataReader["CLIENTE_PRECIO_MAYOREOXPRODUCTO"]).Trim() == "S" ? BoolCN.S : BoolCN.N;
            item.Activo = dataReader["ACTIVO"] != System.DBNull.Value && ((string)dataReader["ACTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            item.Cliente_pago_parametros_Hab_pagoefectivo = dataReader["CLIENTE_PAGO_PARAMETROS_HAB_PAGOEFECTIVO"] != System.DBNull.Value && ((string)dataReader["CLIENTE_PAGO_PARAMETROS_HAB_PAGOEFECTIVO"]).Trim() == "N" ? BoolCS.N : BoolCS.S;
            //item.Creado = dataReader["CREADO"] != System.DBNull.Value ? (DateTimeOffset)dataReader["CREADO"] : DateTime.UtcNow;
            //item.Modificado = dataReader["MODIFICADO"] != System.DBNull.Value ? (DateTimeOffset)dataReader["MODIFICADO"] : DateTime.UtcNow;
            item.Vigencia = dataReader["VIGENCIA"] != System.DBNull.Value ? new DateTimeOffset(((DateTime)dataReader["VIGENCIA"])) : null;
            item.Cliente_comision_Por_come = dataReader["CLIENTE_COMISION_POR_COME"] != System.DBNull.Value ? (decimal)dataReader["CLIENTE_COMISION_POR_COME"] : 0;
            item.Cliente_fact_elect_Distancia = dataReader["CLIENTE_FACT_ELECT_DISTANCIA"] != System.DBNull.Value ? (decimal)dataReader["CLIENTE_FACT_ELECT_DISTANCIA"] : 0;
            item.Cliente_fact_elect_Entrega_Distancia = dataReader["CLIENTE_FACT_ELECT_ENTREGA_DISTANCIA"] != System.DBNull.Value ? (decimal)dataReader["CLIENTE_FACT_ELECT_ENTREGA_DISTANCIA"] : 0;
            item.Cliente_pago_Saldo = dataReader["CLIENTE_PAGO_SALDO"] != System.DBNull.Value ? (decimal)dataReader["CLIENTE_PAGO_SALDO"] : 0;
            item.Cliente_pago_Saldoapartadonegativo = dataReader["CLIENTE_PAGO_SALDOAPARTADONEGATIVO"] != System.DBNull.Value ? (decimal)dataReader["CLIENTE_PAGO_SALDOAPARTADONEGATIVO"] : 0;
            item.Cliente_pago_Saldoapartadopositivo = dataReader["CLIENTE_PAGO_SALDOAPARTADOPOSITIVO"] != System.DBNull.Value ? (decimal)dataReader["CLIENTE_PAGO_SALDOAPARTADOPOSITIVO"] : 0;
            item.Cliente_pago_Saldospositivos = dataReader["CLIENTE_PAGO_SALDOSPOSITIVOS"] != System.DBNull.Value ? (decimal)dataReader["CLIENTE_PAGO_SALDOSPOSITIVOS"] : 0;
            item.Cliente_pago_Saldosnegativos = dataReader["CLIENTE_PAGO_SALDOSNEGATIVOS"] != System.DBNull.Value ? (decimal)dataReader["CLIENTE_PAGO_SALDOSNEGATIVOS"] : 0;
            //item.Cliente_pago_Ultimaventa = dataReader["CLIENTE_PAGO_ULTIMAVENTA"] != System.DBNull.Value ? (DateTimeOffset)dataReader["CLIENTE_PAGO_ULTIMAVENTA"] : null;
            item.Cliente_pago_parametros_Limitecredito = dataReader["CLIENTE_PAGO_PARAMETROS_LIMITECREDITO"] != System.DBNull.Value ? (decimal)dataReader["CLIENTE_PAGO_PARAMETROS_LIMITECREDITO"] : 0;
            //item.CreadoPorId = dataReader["CREADOPORID"] != System.DBNull.Value ? long.Parse((string)dataReader["CREADOPORID"]) : (long?)null;
            //item.ModificadoPorId = dataReader["MODIFICADOPORID"] != System.DBNull.Value ? long.Parse((string)dataReader["MODIFICADOPORID"]) : (long?)null;
            //item.Domicilioid = dataReader["DOMICILIOID"] != System.DBNull.Value ? long.Parse((string)dataReader["DOMICILIOID"]) : (long?)null;
            //item.Contacto1id = dataReader["CONTACTO1ID"] != System.DBNull.Value ? long.Parse((string)dataReader["CONTACTO1ID"]) : (long?)null;
            //item.Contacto1_Domicilioid = dataReader["CONTACTO1_DOMICILIOID"] != System.DBNull.Value ? long.Parse((string)dataReader["CONTACTO1_DOMICILIOID"]) : (long?)null;
            //item.Contacto2id = dataReader["CONTACTO2ID"] != System.DBNull.Value ? long.Parse((string)dataReader["CONTACTO2ID"]) : (long?)null;
            //item.Contacto2_Domicilioid = dataReader["CONTACTO2_DOMICILIOID"] != System.DBNull.Value ? long.Parse((string)dataReader["CONTACTO2_DOMICILIOID"]) : (long?)null;
            //item.Domicilioentregaid = dataReader["DOMICILIOENTREGAID"] != System.DBNull.Value ? long.Parse((string)dataReader["DOMICILIOENTREGAID"]) : (long?)null;
            //item.Subtipoclienteid = dataReader["SUBTIPOCLIENTEID"] != System.DBNull.Value ? long.Parse((string)dataReader["SUBTIPOCLIENTEID"]) : (long?)null;
            //item.Proveeclienteid = dataReader["PROVEECLIENTEID"] != System.DBNull.Value ? long.Parse((string)dataReader["PROVEECLIENTEID"]) : (long?)null;
            //item.Cliente_bancomer_Bancomerdoctopendid = dataReader["CLIENTE_BANCOMER_BANCOMERDOCTOPENDID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_BANCOMER_BANCOMERDOCTOPENDID"]) : (long?)null;
            //item.Cliente_comision_Vendedorid = dataReader["CLIENTE_COMISION_VENDEDORID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_COMISION_VENDEDORID"]) : (long?)null;
            //item.Cliente_fact_elect_Creditoformapagosatabonos = dataReader["CLIENTE_FACT_ELECT_CREDITOFORMAPAGOSATABONOS"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_FACT_ELECT_CREDITOFORMAPAGOSATABONOS"]) : (long?)null;
            //item.Cliente_fact_elect_Sat_usocfdiid = dataReader["CLIENTE_FACT_ELECT_SAT_USOCFDIID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_FACT_ELECT_SAT_USOCFDIID"]) : (long?)null;
            //item.Cliente_fact_elect_Sat_id_pais = dataReader["CLIENTE_FACT_ELECT_SAT_ID_PAIS"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_FACT_ELECT_SAT_ID_PAIS"]) : (long?)null;
            //item.Cliente_fact_elect_Sat_Coloniaid = dataReader["CLIENTE_FACT_ELECT_SAT_COLONIAID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_FACT_ELECT_SAT_COLONIAID"]) : (long?)null;
            //item.Cliente_fact_elect_Sat_Localidadid = dataReader["CLIENTE_FACT_ELECT_SAT_LOCALIDADID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_FACT_ELECT_SAT_LOCALIDADID"]) : (long?)null;
            //item.Cliente_fact_elect_Sat_Municipioid = dataReader["CLIENTE_FACT_ELECT_SAT_MUNICIPIOID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_FACT_ELECT_SAT_MUNICIPIOID"]) : (long?)null;
            //item.Cliente_fact_elect_Entrega_Sat_Coloniaid = dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_COLONIAID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_COLONIAID"]) : (long?)null;
            //item.Cliente_fact_elect_Entrega_Sat_Localidadid = dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_LOCALIDADID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_LOCALIDADID"]) : (long?)null;
            //item.Cliente_fact_elect_Entrega_Sat_Municipioid = dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_MUNICIPIOID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_FACT_ELECT_ENTREGA_SAT_MUNICIPIOID"]) : (long?)null;
            //item.Cliente_fact_elect_Sat_Regimenfiscalid = dataReader["CLIENTE_FACT_ELECT_SAT_REGIMENFISCALID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_FACT_ELECT_SAT_REGIMENFISCALID"]) : (long?)null;
            //item.Cliente_pago_parametros_Dias = dataReader["CLIENTE_PAGO_PARAMETROS_DIAS"] != System.DBNull.Value ? int.Parse((string)dataReader["CLIENTE_PAGO_PARAMETROS_DIAS"]) : (int?)null;
            //item.Cliente_pago_parametros_Creditoformapagoabonos = dataReader["CLIENTE_PAGO_PARAMETROS_CREDITOFORMAPAGOABONOS"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_PAGO_PARAMETROS_CREDITOFORMAPAGOABONOS"]) : (long?)null;
            //item.Cliente_pago_parametros_Monedaid = dataReader["CLIENTE_PAGO_PARAMETROS_MONEDAID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_PAGO_PARAMETROS_MONEDAID"]) : (long?)null;
            item.Cliente_pago_parametros_Dias_extr = dataReader["CLIENTE_PAGO_PARAMETROS_DIAS_EXTR"] != System.DBNull.Value ? (int)dataReader["CLIENTE_PAGO_PARAMETROS_DIAS_EXTR"] : (int?)null;
            //item.Cliente_precio_Listaprecioid = dataReader["CLIENTE_PRECIO_LISTAPRECIOID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_PRECIO_LISTAPRECIOID"]) : (long?)null;
            //item.Cliente_precio_Superlistaprecioid = dataReader["CLIENTE_PRECIO_SUPERLISTAPRECIOID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_PRECIO_SUPERLISTAPRECIOID"]) : (long?)null;
            //item.Cliente_rutaembarque_Rutaembarqueid = dataReader["CLIENTE_RUTAEMBARQUE_RUTAEMBARQUEID"] != System.DBNull.Value ? long.Parse((string)dataReader["CLIENTE_RUTAEMBARQUE_RUTAEMBARQUEID"]) : (long?)null;


            if (SubtipoclienteClave_obj != null)
                item.Subtipoclienteid = SubtipoclienteClave_obj.Id;
            else
                item.Subtipoclienteid = null;

            if (ProveeclienteClave_obj != null)
                item.Proveeclienteid = ProveeclienteClave_obj.Id;
            else
                item.Proveeclienteid = null;

            //if (Cliente_bancomer_BancomerdoctopendClave_obj != null)
            //    item.Cliente_bancomer_Bancomerdoctopendid = Cliente_bancomer_BancomerdoctopendClave_obj.Id;
            //else
            //    item.Cliente_bancomer_Bancomerdoctopendid = null;

            if (Cliente_comision_VendedorClave_obj != null)
                item.Cliente_comision_Vendedorid = Cliente_comision_VendedorClave_obj.Id;
            else
                item.Cliente_comision_Vendedorid = null;

            if (Cliente_fact_elect_Creditoformapagosatabonos_Clave_obj != null)
                item.Cliente_fact_elect_Creditoformapagosatabonos = Cliente_fact_elect_Creditoformapagosatabonos_Clave_obj.Id;
            else
                item.Cliente_fact_elect_Creditoformapagosatabonos = null;

            if (Cliente_fact_elect_Sat_usocfdiClave_obj != null)
                item.Cliente_fact_elect_Sat_usocfdiid = Cliente_fact_elect_Sat_usocfdiClave_obj.Id;
            else
                item.Cliente_fact_elect_Sat_usocfdiid = null;

            if (Cliente_fact_elect_Sat_paisClave_obj != null)
                item.Cliente_fact_elect_Sat_id_pais = Cliente_fact_elect_Sat_paisClave_obj.Id;
            else
                item.Cliente_fact_elect_Sat_id_pais = null;

            if (Cliente_fact_elect_Sat_ColoniaClave_obj != null)
                item.Cliente_fact_elect_Sat_Coloniaid = Cliente_fact_elect_Sat_ColoniaClave_obj.Id;
            else
                item.Cliente_fact_elect_Sat_Coloniaid = null;

            if (Cliente_fact_elect_Sat_LocalidadClave_obj != null)
                item.Cliente_fact_elect_Sat_Localidadid = Cliente_fact_elect_Sat_LocalidadClave_obj.Id;
            else
                item.Cliente_fact_elect_Sat_Localidadid = null;

            if (Cliente_fact_elect_Sat_MunicipioClave_obj != null)
                item.Cliente_fact_elect_Sat_Municipioid = Cliente_fact_elect_Sat_MunicipioClave_obj.Id;
            else
                item.Cliente_fact_elect_Sat_Municipioid = null;

            if (Cliente_fact_elect_Entrega_Sat_ColoniaClave_obj != null)
                item.Cliente_fact_elect_Entrega_Sat_Coloniaid = Cliente_fact_elect_Entrega_Sat_ColoniaClave_obj.Id;
            else
                item.Cliente_fact_elect_Entrega_Sat_Coloniaid = null;

            if (Cliente_fact_elect_Entrega_Sat_LocalidadClave_obj != null)
                item.Cliente_fact_elect_Entrega_Sat_Localidadid = Cliente_fact_elect_Entrega_Sat_LocalidadClave_obj.Id;
            else
                item.Cliente_fact_elect_Entrega_Sat_Localidadid = null;

            if (Cliente_fact_elect_Entrega_Sat_MunicipioClave_obj != null)
                item.Cliente_fact_elect_Entrega_Sat_Municipioid = Cliente_fact_elect_Entrega_Sat_MunicipioClave_obj.Id;
            else
                item.Cliente_fact_elect_Entrega_Sat_Municipioid = null;

            if (Cliente_fact_elect_Sat_RegimenfiscalClave_obj != null)
                item.Cliente_fact_elect_Sat_Regimenfiscalid = Cliente_fact_elect_Sat_RegimenfiscalClave_obj.Id;
            else
                item.Cliente_fact_elect_Sat_Regimenfiscalid = null;

            if (Cliente_pago_parametros_Creditoformapagoabonos_Clave_obj != null)
                item.Cliente_pago_parametros_Creditoformapagoabonos = Cliente_pago_parametros_Creditoformapagoabonos_Clave_obj.Id;
            else
                item.Cliente_pago_parametros_Creditoformapagoabonos = null;

            if (Cliente_pago_parametros_MonedaClave_obj != null)
                item.Cliente_pago_parametros_Monedaid = Cliente_pago_parametros_MonedaClave_obj.Id;
            else
                item.Cliente_pago_parametros_Monedaid = null;

            if (Cliente_precio_ListaprecioClave_obj != null)
                item.Cliente_precio_Listaprecioid = Cliente_precio_ListaprecioClave_obj.Id;
            else
                item.Cliente_precio_Listaprecioid = null;

            if (Cliente_precio_SuperlistaprecioClave_obj != null)
                item.Cliente_precio_Superlistaprecioid = Cliente_precio_SuperlistaprecioClave_obj.Id;
            else
                item.Cliente_precio_Superlistaprecioid = null;

            if (Cliente_rutaembarque_RutaembarqueClave_obj != null)
                item.Cliente_rutaembarque_Rutaembarqueid = Cliente_rutaembarque_RutaembarqueClave_obj.Id;
            else
                item.Cliente_rutaembarque_Rutaembarqueid = null;



            if (existItem)
                controller.Update(item);
            else
                controller.Insert(item);

            localContext.SaveChanges();

            return true;
        }
    }
}
