using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace IposV3.Model
{
    public class ApplicationDbContext : DbContext
    {
#pragma warning disable CS8618
        public DbSet<Caja> Caja { get; set; }
        public DbSet<Contacto> Contacto { get; set; }
        public DbSet<Derechos> Derechos { get; set; }
        public DbSet<Domicilio> Domicilio { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Menuitems> Menuitems { get; set; }

        public DbSet<Parametro> Parametro { get; set; }
        public DbSet<Perfiles> Perfiles { get; set; }
        public DbSet<Perfil_der> Perfil_der { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Sucursal_info> Sucursal_info { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Usuario_perfil> Usuario_perfil { get; set; }
        public DbSet<Docto_alerta> Docto_alerta { get; set; }
        public DbSet<Docto_apartado> Docto_apartado { get; set; }
        public DbSet<Personaapartado> Personaapartado { get; set; }
        public DbSet<Producto_apartado> Producto_apartado { get; set; }
        public DbSet<Bancomerconsecutivo> Bancomerconsecutivo { get; set; }
        public DbSet<Bancomerparam> Bancomerparam { get; set; }
        public DbSet<Caja_bancomer> Caja_bancomer { get; set; }
        public DbSet<Cliente_bancomer> Cliente_bancomer { get; set; }
        public DbSet<Docto_bancomer> Docto_bancomer { get; set; }
        public DbSet<Encabezadoresponsebancomer> Encabezadoresponsebancomer { get; set; }
        public DbSet<Estadotransbancomer> Estadotransbancomer { get; set; }
        public DbSet<Pago_bancomer> Pago_bancomer { get; set; }
        public DbSet<Requestbancomer> Requestbancomer { get; set; }
        public DbSet<Responsebancomer> Responsebancomer { get; set; }
        public DbSet<Strucptosbancomer> Strucptosbancomer { get; set; }
        public DbSet<Gruposucursal> Gruposucursal { get; set; }
        public DbSet<Grupousuario> Grupousuario { get; set; }
        public DbSet<Linea> Linea { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Moneda> Moneda { get; set; }
        public DbSet<Saludo> Saludo { get; set; }
        public DbSet<Tasaieps> Tasaieps { get; set; }
        public DbSet<Tasaiva> Tasaiva { get; set; }
        public DbSet<Unidad> Unidad { get; set; }
        public DbSet<Agrupacionventa> Agrupacionventa { get; set; }
        public DbSet<Clasedocto> Clasedocto { get; set; }
        public DbSet<Estadopais> Estadopais { get; set; }
        public DbSet<Estatusdocto> Estatusdocto { get; set; }
        public DbSet<Estatusdoctopedido> Estatusdoctopedido { get; set; }
        public DbSet<Estatusmovto> Estatusmovto { get; set; }
        public DbSet<Meses> Meses { get; set; }
        public DbSet<Origenfiscal> Origenfiscal { get; set; }
        public DbSet<Subtipocliente> Subtipocliente { get; set; }
        public DbSet<Subtipodocto> Subtipodocto { get; set; }
        public DbSet<Tipodocto> Tipodocto { get; set; }
        public DbSet<Tiporecarga> Tiporecarga { get; set; }
        public DbSet<Formapagosat> Formapagosat { get; set; }
        public DbSet<Sat_aduana> Sat_aduana { get; set; }
        public DbSet<Sat_codigopostal> Sat_codigopostal { get; set; }
        public DbSet<Sat_impuesto> Sat_impuesto { get; set; }
        public DbSet<Sat_metodopago> Sat_metodopago { get; set; }
        public DbSet<Sat_moneda> Sat_moneda { get; set; }
        public DbSet<Sat_pais> Sat_pais { get; set; }
        public DbSet<Sat_patenteaduanal> Sat_patenteaduanal { get; set; }
        public DbSet<Sat_pedimentos> Sat_pedimentos { get; set; }
        public DbSet<Sat_productoservicio> Sat_productoservicio { get; set; }
        public DbSet<Sat_productoservicio_linea> Sat_productoservicio_linea { get; set; }
        public DbSet<Sat_regimenfiscal> Sat_regimenfiscal { get; set; }
        public DbSet<Sat_tasacuota> Sat_tasacuota { get; set; }
        public DbSet<Sat_tipocomprobante> Sat_tipocomprobante { get; set; }
        public DbSet<Sat_tipofactor> Sat_tipofactor { get; set; }
        public DbSet<Sat_tiporelacion> Sat_tiporelacion { get; set; }
        public DbSet<Sat_unidadmedida> Sat_unidadmedida { get; set; }
        public DbSet<Sat_usocfdi> Sat_usocfdi { get; set; }
        public DbSet<Sat_versioncatalogo> Sat_versioncatalogo { get; set; }
        public DbSet<Bitacobranza> Bitacobranza { get; set; }
        public DbSet<Bitacobranzadet> Bitacobranzadet { get; set; }
        public DbSet<Docto_cobranza> Docto_cobranza { get; set; }
        public DbSet<Estadocobranza> Estadocobranza { get; set; }
        public DbSet<Cliente_comision> Cliente_comision { get; set; }
        public DbSet<Comisionporlista> Comisionporlista { get; set; }
        public DbSet<Comision_calc_v2> Comision_calc_v2 { get; set; }
        public DbSet<Comision_color_v2> Comision_color_v2 { get; set; }
        public DbSet<Docto_comision> Docto_comision { get; set; }
        public DbSet<Movto_comision> Movto_comision { get; set; }
        public DbSet<Producto_comision> Producto_comision { get; set; }
        public DbSet<Movto_comodin> Movto_comodin { get; set; }
        public DbSet<Producto_comodin> Producto_comodin { get; set; }
        public DbSet<Docto_compra> Docto_compra { get; set; }
        public DbSet<Facturaoriginalcompra> Facturaoriginalcompra { get; set; }
        public DbSet<Configuracionsync> Configuracionsync { get; set; }
        public DbSet<Contrarecibodtl> Contrarecibodtl { get; set; }
        public DbSet<Contrarecibohdr> Contrarecibohdr { get; set; }
        public DbSet<Docto_contrarecibo> Docto_contrarecibo { get; set; }
        public DbSet<Estadopagocontrarecibo> Estadopagocontrarecibo { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Docto> Docto { get; set; }
        public DbSet<Docto_cancelacion> Docto_cancelacion { get; set; }
        public DbSet<Docto_devolucion> Docto_devolucion { get; set; }
        public DbSet<Docto_impuestos> Docto_impuestos { get; set; }
        public DbSet<Movto> Movto { get; set; }
        public DbSet<Movto_cancelacion> Movto_cancelacion { get; set; }
        public DbSet<Movto_devolucion> Movto_devolucion { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Archivosadjuntos> Archivosadjuntos { get; set; }
        public DbSet<Docto_loteimportado> Docto_loteimportado { get; set; }
        public DbSet<Movto_loteimportado> Movto_loteimportado { get; set; }
        public DbSet<Producto_loteimportado> Producto_loteimportado { get; set; }
        public DbSet<Tipodistloteimportado> Tipodistloteimportado { get; set; }
        public DbSet<Corte> Corte { get; set; }
        public DbSet<Corteieps> Corteieps { get; set; }
        public DbSet<Corterecoleccion> Corterecoleccion { get; set; }
        public DbSet<Corte_calculos> Corte_calculos { get; set; }
        public DbSet<Corte_calculo_def> Corte_calculo_def { get; set; }
        public DbSet<Corte_calculo_formapago> Corte_calculo_formapago { get; set; }
        public DbSet<Docto_corte> Docto_corte { get; set; }
        public DbSet<Montobilletes> Montobilletes { get; set; }
        public DbSet<Montobilleteslog> Montobilleteslog { get; set; }
        public DbSet<Tipocorte> Tipocorte { get; set; }
        public DbSet<Tipomontobilletes> Tipomontobilletes { get; set; }
        public DbSet<Tipotransaccion> Tipotransaccion { get; set; }
        public DbSet<Turno> Turno { get; set; }
        public DbSet<Quota> Quota { get; set; }
        public DbSet<Cuponesaplicados> Cuponesaplicados { get; set; }
        public DbSet<Caja_emida> Caja_emida { get; set; }
        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<Clerkpagoservicio> Clerkpagoservicio { get; set; }
        public DbSet<Emidacomision> Emidacomision { get; set; }
        public DbSet<Emidaproduct> Emidaproduct { get; set; }
        public DbSet<Emidarequest> Emidarequest { get; set; }
        public DbSet<Emidarespcode> Emidarespcode { get; set; }
        public DbSet<Llamadoemida> Llamadoemida { get; set; }
        public DbSet<Merchantpagoservicio> Merchantpagoservicio { get; set; }
        public DbSet<Movto_emida> Movto_emida { get; set; }
        public DbSet<Producto_emida> Producto_emida { get; set; }
        public DbSet<Terminalpagoservicio> Terminalpagoservicio { get; set; }
        public DbSet<Usuario_emida> Usuario_emida { get; set; }
        public DbSet<Ttlcontrol> Ttlcontrol { get; set; }
        public DbSet<Ttl_docto_pers_mes> Ttl_docto_pers_mes { get; set; }
        public DbSet<Ttl_prod_tipo_mes> Ttl_prod_tipo_mes { get; set; }
        public DbSet<Ajustesiva> Ajustesiva { get; set; }
        public DbSet<Cfdi> Cfdi { get; set; }
        public DbSet<Cfdi_conc> Cfdi_conc { get; set; }
        public DbSet<Cfdi_conc_adu> Cfdi_conc_adu { get; set; }
        public DbSet<Cfdi_conc_imp> Cfdi_conc_imp { get; set; }
        public DbSet<Cfdi_conc_part> Cfdi_conc_part { get; set; }
        public DbSet<Cfdi_imp> Cfdi_imp { get; set; }
        public DbSet<Cfdi_rel> Cfdi_rel { get; set; }
        public DbSet<Cliente_fact_elect> Cliente_fact_elect { get; set; }
        public DbSet<Docto_fact_elect> Docto_fact_elect { get; set; }
        public DbSet<Producto_fact_elect> Producto_fact_elect { get; set; }
        public DbSet<Sucursal_fact_elect> Sucursal_fact_elect { get; set; }
        public DbSet<Docto_fact_elect_consolidacion> Docto_fact_elect_consolidacion { get; set; }
        public DbSet<Maxfact> Maxfact { get; set; }
        public DbSet<Movto_fact_elect_consolidacion> Movto_fact_elect_consolidacion { get; set; }
        public DbSet<Docto_fact_elect_pagos> Docto_fact_elect_pagos { get; set; }
        public DbSet<Pagodoctosat> Pagodoctosat { get; set; }
        public DbSet<Pagosat> Pagosat { get; set; }
        public DbSet<Docto_fact_elect_sustitucion> Docto_fact_elect_sustitucion { get; set; }
        public DbSet<Docto_farmacia> Docto_farmacia { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Producto_farmacia> Producto_farmacia { get; set; }
        public DbSet<Receta> Receta { get; set; }
        public DbSet<Gasto> Gasto { get; set; }
        public DbSet<Gastoadicional> Gastoadicional { get; set; }
        public DbSet<Movtogasto> Movtogasto { get; set; }
        public DbSet<Movtogastosadic> Movtogastosadic { get; set; }
        public DbSet<Maestro_consecutivo> Maestro_consecutivo { get; set; }
        public DbSet<Docto_guia> Docto_guia { get; set; }
        public DbSet<Estadoguia> Estadoguia { get; set; }
        public DbSet<Guia> Guia { get; set; }
        public DbSet<Guiadetalle> Guiadetalle { get; set; }
        public DbSet<Tipoentrega> Tipoentrega { get; set; }
        public DbSet<Sucursal_importacion> Sucursal_importacion { get; set; }
        public DbSet<Ticketstemplates> Ticketstemplates { get; set; }
        public DbSet<Zebraconfig> Zebraconfig { get; set; }
        public DbSet<Incidencia> Incidencia { get; set; }
        public DbSet<Logeventotabla> Logeventotabla { get; set; }
        public DbSet<Tipoeventotabla> Tipoeventotabla { get; set; }
        public DbSet<Tipoincidencia> Tipoincidencia { get; set; }
        public DbSet<Almacen> Almacen { get; set; }
        public DbSet<Anaquel> Anaquel { get; set; }
        public DbSet<Grupodiferenciainventario> Grupodiferenciainventario { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Inventariosucursal> Inventariosucursal { get; set; }
        public DbSet<Kardex> Kardex { get; set; }
        public DbSet<Lotesimportados> Lotesimportados { get; set; }
        public DbSet<Movto_inventario> Movto_inventario { get; set; }
        public DbSet<Productoalmacen> Productoalmacen { get; set; }
        public DbSet<Productolocations> Productolocations { get; set; }
        public DbSet<Producto_existencia> Producto_existencia { get; set; }
        public DbSet<Producto_inventario> Producto_inventario { get; set; }
        public DbSet<Stockalmacen> Stockalmacen { get; set; }
        public DbSet<Tipodiferenciainventario> Tipodiferenciainventario { get; set; }
        public DbSet<Docto_kit> Docto_kit { get; set; }
        public DbSet<Kitdefinicion> Kitdefinicion { get; set; }
        public DbSet<Kitdeftemp> Kitdeftemp { get; set; }
        public DbSet<Kitdoctotemp> Kitdoctotemp { get; set; }
        public DbSet<Kitsunnivel> Kitsunnivel { get; set; }
        public DbSet<Movto_kit> Movto_kit { get; set; }
        public DbSet<Movto_kit_def> Movto_kit_def { get; set; }
        public DbSet<Producto_kit> Producto_kit { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Logtabla> Logtabla { get; set; }
        public DbSet<Traza> Traza { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Areaderechos> Areaderechos { get; set; }
        public DbSet<Mensaje> Mensaje { get; set; }
        public DbSet<Mensajeadjuntos> Mensajeadjuntos { get; set; }
        public DbSet<Mensajearea> Mensajearea { get; set; }
        public DbSet<Mensajeestado> Mensajeestado { get; set; }
        public DbSet<Mensajenivelurgencia> Mensajenivelurgencia { get; set; }
        public DbSet<Mensajesuc> Mensajesuc { get; set; }
        public DbSet<Mensajetipo> Mensajetipo { get; set; }
        public DbSet<Mensajeusuario> Mensajeusuario { get; set; }
        public DbSet<Docto_monedero> Docto_monedero { get; set; }
        public DbSet<Monedero> Monedero { get; set; }
        public DbSet<Monederomovto> Monederomovto { get; set; }
        public DbSet<Movto_monedero> Movto_monedero { get; set; }
        public DbSet<Tipomonederomovto> Tipomonederomovto { get; set; }
        public DbSet<Cliente_ordencompra> Cliente_ordencompra { get; set; }
        public DbSet<Docto_ordencompra> Docto_ordencompra { get; set; }
        public DbSet<Movto_ordencompra> Movto_ordencompra { get; set; }
        public DbSet<Docto_origenfiscal> Docto_origenfiscal { get; set; }
        public DbSet<Movto_origenfiscal> Movto_origenfiscal { get; set; }
        public DbSet<Producto_origenfiscal> Producto_origenfiscal { get; set; }
        public DbSet<Cliente_pago> Cliente_pago { get; set; }
        public DbSet<Cliente_pago_parametros> Cliente_pago_parametros { get; set; }
        public DbSet<Doctopago> Doctopago { get; set; }
        public DbSet<Docto_info_pago> Docto_info_pago { get; set; }
        public DbSet<Kardexabono> Kardexabono { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Pago_pago> Pago_pago { get; set; }
        public DbSet<Proveedor_pago> Proveedor_pago { get; set; }
        public DbSet<Proveedor_pago_parametros> Proveedor_pago_parametros { get; set; }
        public DbSet<Banco> Banco { get; set; }
        public DbSet<Estatusdoctopago> Estatusdoctopago { get; set; }
        public DbSet<Estatuspago> Estatuspago { get; set; }
        public DbSet<Formapago> Formapago { get; set; }
        public DbSet<Motivo_camfec> Motivo_camfec { get; set; }
        public DbSet<Subtipopago> Subtipopago { get; set; }
        public DbSet<Tipoabono> Tipoabono { get; set; }
        public DbSet<Tipoaplicacioncredito> Tipoaplicacioncredito { get; set; }
        public DbSet<Tipomovimientokardexabono> Tipomovimientokardexabono { get; set; }
        public DbSet<Tipopago> Tipopago { get; set; }
        public DbSet<Tiporelacionpago> Tiporelacionpago { get; set; }
        public DbSet<Cliente_poliza> Cliente_poliza { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Cuentabanco> Cuentabanco { get; set; }
        public DbSet<Docto_poliza> Docto_poliza { get; set; }
        public DbSet<Ingresuc_tipolinea> Ingresuc_tipolinea { get; set; }
        public DbSet<Movto_poliza> Movto_poliza { get; set; }
        public DbSet<Personacuentabanco> Personacuentabanco { get; set; }
        public DbSet<Plazo> Plazo { get; set; }
        public DbSet<Producto_poliza> Producto_poliza { get; set; }
        public DbSet<Tipolineapoliza> Tipolineapoliza { get; set; }
        public DbSet<Cliente_precio> Cliente_precio { get; set; }
        public DbSet<Desclineapers> Desclineapers { get; set; }
        public DbSet<Docto_precio> Docto_precio { get; set; }
        public DbSet<Listaprecio> Listaprecio { get; set; }
        public DbSet<Listapreciodetalle> Listapreciodetalle { get; set; }
        public DbSet<Movto_precio> Movto_precio { get; set; }
        public DbSet<Preciopersona> Preciopersona { get; set; }
        public DbSet<Producto_precios> Producto_precios { get; set; }
        public DbSet<Tipomayoreo> Tipomayoreo { get; set; }
        public DbSet<Tipoprecio> Tipoprecio { get; set; }
        public DbSet<Camporeferenciaprecio> Camporeferenciaprecio { get; set; }
        public DbSet<Tipodescuentoprod> Tipodescuentoprod { get; set; }
        public DbSet<Tipodescuentovale> Tipodescuentovale { get; set; }
        public DbSet<Tipoutilidad> Tipoutilidad { get; set; }
        public DbSet<Tipo_impuesto> Tipo_impuesto { get; set; }
        public DbSet<Tipo_precio> Tipo_precio { get; set; }
        public DbSet<Rangopromocion> Rangopromocion { get; set; }
        public DbSet<Tipopromocion> Tipopromocion { get; set; }
        public DbSet<Clasifica> Clasifica { get; set; }
        public DbSet<Contenido> Contenido { get; set; }
        public DbSet<Lookup> Lookup { get; set; }
        public DbSet<Productocaracteristicas> Productocaracteristicas { get; set; }
        public DbSet<Producto_miscelanea> Producto_miscelanea { get; set; }
        public DbSet<Producto_padre> Producto_padre { get; set; }
        public DbSet<Prod_def_caracteristicas> Prod_def_caracteristicas { get; set; }
        public DbSet<Docto_rebajaespecial> Docto_rebajaespecial { get; set; }
        public DbSet<Estatusrebaja> Estatusrebaja { get; set; }
        public DbSet<Movto_rebajaespecial> Movto_rebajaespecial { get; set; }
        public DbSet<Replgroup> Replgroup { get; set; }
        public DbSet<Replgroupdef> Replgroupdef { get; set; }
        public DbSet<Replgroupdef_dep_on> Replgroupdef_dep_on { get; set; }
        public DbSet<Replmov> Replmov { get; set; }
        public DbSet<Repltabla> Repltabla { get; set; }
        public DbSet<Repltablagroupdef> Repltablagroupdef { get; set; }
        public DbSet<Repltipomov> Repltipomov { get; set; }
        public DbSet<Replversion> Replversion { get; set; }
        public DbSet<Perfil_repo> Perfil_repo { get; set; }
        public DbSet<Reportes> Reportes { get; set; }
        public DbSet<Sucursal_respaldo> Sucursal_respaldo { get; set; }
        public DbSet<Docto_revision> Docto_revision { get; set; }
        public DbSet<Estadorevisado> Estadorevisado { get; set; }
        public DbSet<Movto_revision> Movto_revision { get; set; }
        public DbSet<Cliente_rutaembarque> Cliente_rutaembarque { get; set; }
        public DbSet<Docto_rutaembarque> Docto_rutaembarque { get; set; }
        public DbSet<Rutaembarque> Rutaembarque { get; set; }
        public DbSet<Docto_serviciodomicilio> Docto_serviciodomicilio { get; set; }
        public DbSet<Docto_surtido> Docto_surtido { get; set; }
        public DbSet<Estadosurtido> Estadosurtido { get; set; }
        public DbSet<Movto_surtido> Movto_surtido { get; set; }
        public DbSet<Sync_expo> Sync_expo { get; set; }
        public DbSet<Sync_impo> Sync_impo { get; set; }
        public DbSet<Estatusexpo> Estatusexpo { get; set; }
        public DbSet<Estatusimpo> Estatusimpo { get; set; }
        public DbSet<Tipoexpo> Tipoexpo { get; set; }
        public DbSet<Tipoimpo> Tipoimpo { get; set; }
        public DbSet<Docto_traslado> Docto_traslado { get; set; }
        public DbSet<Motivo_devolucion> Motivo_devolucion { get; set; }
        public DbSet<Movto_traslado> Movto_traslado { get; set; }
        public DbSet<Sucursal_traslado> Sucursal_traslado { get; set; }
        public DbSet<Docto_utilidad> Docto_utilidad { get; set; }
        public DbSet<Movto_utilidad> Movto_utilidad { get; set; }
        public DbSet<Producto_utilidad> Producto_utilidad { get; set; }
        public DbSet<Docto_ventafuturo> Docto_ventafuturo { get; set; }
        public DbSet<Movto_ventafuturo> Movto_ventafuturo { get; set; }

        public DbSet<Doctonota> Doctonota { get; set; }
        public DbSet<Tipodoctonota> Tipodoctonota { get; set; }
        public DbSet<Doctocomprobante> Doctocomprobante { get; set; }
        public DbSet<Sat_clavetransporte> Sat_clavetransporte { get; set; }
        public DbSet<Sat_tipoestacion> Sat_tipoestacion { get; set; }
        public DbSet<Sat_claveunidadpeso> Sat_claveunidadpeso { get; set; }
        public DbSet<Sat_tipoembalaje> Sat_tipoembalaje { get; set; }
        public DbSet<Sat_tipopermiso> Sat_tipopermiso { get; set; }
        public DbSet<Sat_colonia> Sat_colonia { get; set; }
        public DbSet<Sat_localidad> Sat_localidad { get; set; }
        public DbSet<Sat_municipio> Sat_municipio { get; set; }
        public DbSet<Sat_partetransporte> Sat_partetransporte { get; set; }
        public DbSet<Sat_figuratransporte> Sat_figuratransporte { get; set; }
        public DbSet<Sat_configautotransporte> Sat_configautotransporte { get; set; }
        public DbSet<Sat_subtiporem> Sat_subtiporem { get; set; }
        public DbSet<Personafigura> Personafigura { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<Cartaporte> Cartaporte { get; set; }
        public DbSet<CartaporteAutotransp> CartaporteAutotransp { get; set; }
        public DbSet<CartaporteCanttransp> CartaporteCanttransp { get; set; }
        public DbSet<CartaporteMercancia> CartaporteMercancia { get; set; }
        public DbSet<CartaporteTotalmercancias> CartaporteTotalmercancias { get; set; }
        public DbSet<CartaporteTransptipofigura> CartaporteTransptipofigura { get; set; }
        public DbSet<CartaporteUbicacion> CartaporteUbicacion { get; set; }
        public DbSet<Sat_matpeligroso> Sat_matpeligroso { get; set; }
        public DbSet<Pagodoctosat_imp> Pagodoctosat_Imp { get; set; }

        public DbSet<Promocion> Promocion { get; set; }


        public DbSet<Movto_promocion> Movto_promocion { get; set; }

        public DbSet<SimpleLong> SimpleLong { get; set; }


        public DbSet<Usuario_fact_elect> Usuario_fact_elect { get; set; }



#pragma warning restore CS8618


        //protected override void OnConfiguring(
        //    DbContextOptionsBuilder optionsBuilder)
        //{

        //    if (IntPtr.Size == 8)
        //    {
        //        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ipos3_1;User Id=postgres;Password=Twincept.l;");
        //    }
        //    else
        //    {
        //        optionsBuilder.UseNpgsql(ConnectionString!);
        //    }

        //    //if (connectionString != null)
        //    //    optionsBuilder.UseNpgsql(ConnectionString!);//, b => b.MigrationsAssembly("DataAcess"));
        //    //optionsBuilder.UseLazyLoadingProxies();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Usuario>(entity =>
            //{
            //    entity.OwnsOne(e => e.Domicilio);
            //    entity.OwnsOne(e => e.Contacto1);
            //    entity.OwnsOne(e => e.Contacto2);
            //});


            //modelBuilder.Entity<Grupousuario>(entity =>
            //{
            //    entity.Ignore(y => y.CreadoPor)
            //});



            //modelBuilder.Entity<Grupousuario>()
            //    .HasOne(_ => _.CreadoPor);

            //modelBuilder.Entity<Grupousuario>()
            //    .HasOne(_ => _.ModificadoPor);



            IposV3.Model.Sucursal.ConfigureEntity(modelBuilder.Entity<Sucursal>());

            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Contacto>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Domicilio>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Parametro>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Usuario>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Usuario_Preferencias>());

            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Caja>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Perfil_der>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Perfiles>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Sucursal_info>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Sucursal_info_opciones>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Usuario_perfil>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_alerta>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_apartado>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Personaapartado>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_apartado>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Bancomerconsecutivo>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Bancomerparam>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Caja_bancomer>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cliente_bancomer>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_bancomer>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Encabezadoresponsebancomer>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Estadotransbancomer>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Pago_bancomer>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Requestbancomer>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Responsebancomer>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Strucptosbancomer>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Gruposucursal>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Grupousuario>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Linea>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Marca>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Unidad>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Bitacobranza>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Bitacobranzadet>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_cobranza>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cliente_comision>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Comision_calc_v2>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Comision_color_v2>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Comisionporlista>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_comision>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_comision>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_comision>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_comodin>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_comodin>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_compra>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Facturaoriginalcompra>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Configuracionsync>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Contrarecibodtl>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Contrarecibohdr>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_contrarecibo>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cliente>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_cancelacion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_devolucion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_impuestos>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_cancelacion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_devolucion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Proveedor>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Archivosadjuntos>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_loteimportado>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_loteimportado>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_loteimportado>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Corte>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Corte_calculo_formapago>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Corte_calculos>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Corteieps>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Corterecoleccion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_corte>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Montobilletes>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Montobilleteslog>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Quota>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cuponesaplicados>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Caja_emida>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Carrier>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Clerkpagoservicio>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Emidacomision>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Emidaproduct>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Emidarequest>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Emidarespcode>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Llamadoemida>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Merchantpagoservicio>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_emida>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_emida>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Terminalpagoservicio>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Usuario_emida>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Ttl_docto_pers_mes>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Ttl_prod_tipo_mes>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Ttlcontrol>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Ajustesiva>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cfdi>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cfdi_conc>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cfdi_conc_adu>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cfdi_conc_imp>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cfdi_conc_part>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cfdi_imp>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cfdi_rel>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cliente_fact_elect>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_fact_elect>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_fact_elect>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Sucursal_fact_elect>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_fact_elect_consolidacion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Maxfact>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_fact_elect_consolidacion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_fact_elect_pagos>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Pagodoctosat>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Pagosat>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_fact_elect_sustitucion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_farmacia>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Medico>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_farmacia>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Receta>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Gasto>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Gastoadicional>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movtogasto>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movtogastosadic>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Maestro_consecutivo>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_guia>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Guia>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Guiadetalle>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Sucursal_importacion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Ticketstemplates>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Zebraconfig>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Incidencia>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Logeventotabla>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Almacen>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Anaquel>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Inventario>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Inventariosucursal>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Kardex>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Lotesimportados>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_inventario>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_existencia>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_inventario>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Productoalmacen>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Productolocations>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Stockalmacen>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_kit>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Kitdefinicion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Kitdeftemp>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Kitdoctotemp>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Kitsunnivel>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_kit>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_kit_def>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_kit>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Log>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Traza>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Area>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Areaderechos>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Mensaje>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Mensajeadjuntos>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Mensajearea>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Mensajesuc>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Mensajeusuario>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_monedero>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Monedero>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Monederomovto>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_monedero>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cliente_ordencompra>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_ordencompra>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_ordencompra>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_origenfiscal>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_origenfiscal>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_origenfiscal>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cliente_pago>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cliente_pago_parametros>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_info_pago>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Doctopago>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Kardexabono>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Pago>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Pago_pago>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Proveedor_pago>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Proveedor_pago_parametros>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Banco>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cliente_poliza>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cuenta>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cuentabanco>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_poliza>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_poliza>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Personacuentabanco>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Plazo>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_poliza>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_promocion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_promocion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_promocion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Promocion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Promocionsucursal>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cliente_precio>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Desclineapers>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_precio>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Listaprecio>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Listapreciodetalle>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_precio>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Preciopersona>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_precios>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Clasifica>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Contenido>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Lookup>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Prod_def_caracteristicas>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_miscelanea>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_padre>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Productocaracteristicas>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_rebajaespecial>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_rebajaespecial>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Replgroup>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Replgroupdef_dep_on>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Replmov>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Repltabla>());
            //IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Repltablagroupdef>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Replversion>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Perfil_repo>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Reportes>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Sucursal_respaldo>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_revision>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_revision>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Cliente_rutaembarque>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_rutaembarque>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Rutaembarque>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_serviciodomicilio>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_surtido>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_surtido>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Sync_expo>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Sync_impo>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_traslado>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_traslado>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Sucursal_traslado>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_utilidad>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_utilidad>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Producto_utilidad>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Docto_ventafuturo>());
            IposV3.Model.EntityBase.ConfigureEntityBaseKey(modelBuilder.Entity<Movto_ventafuturo>());





            IposV3.Model.Producto.ConfigureEntity(modelBuilder.Entity<Producto>());
            IposV3.Model.Cliente.ConfigureEntity(modelBuilder.Entity<Cliente>());
            IposV3.Model.Proveedor.ConfigureEntity(modelBuilder.Entity<Proveedor>());
            IposV3.Model.Pago.ConfigureEntity(modelBuilder.Entity<Pago>());
            IposV3.Model.Docto.ConfigureEntity(modelBuilder.Entity<Docto>());
            IposV3.Model.Movto.ConfigureEntity(modelBuilder.Entity<Movto>());
            IposV3.Model.Pagodoctosat.ConfigureEntity(modelBuilder.Entity<Pagodoctosat>());


            IposV3.Model.Usuario.ConfigureEntity(modelBuilder.Entity<Usuario>());



            IposV3.Model.Doctonota.ConfigureEntityBaseKey(modelBuilder.Entity<Doctonota>());
            //IposV3.Model.Tipodoctonota.ConfigureEntityBaseKey(modelBuilder.Entity<Tipodoctonota>());
            IposV3.Model.Doctocomprobante.ConfigureEntityBaseKey(modelBuilder.Entity<Doctocomprobante>());
            //IposV3.Model.Sat_clavetransporte.ConfigureEntityBaseKey(modelBuilder.Entity<Sat_clavetransporte>());
            //IposV3.Model.Sat_tipoestacion.ConfigureEntityBaseKey(modelBuilder.Entity<Sat_tipoestacion>());
            //IposV3.Model.Sat_claveunidadpeso.ConfigureEntityBaseKey(modelBuilder.Entity<Sat_claveunidadpeso>());
            //IposV3.Model.Sat_tipoembalaje.ConfigureEntityBaseKey(modelBuilder.Entity<Sat_tipoembalaje>());
            //IposV3.Model.Sat_tipopermiso.ConfigureEntityBaseKey(modelBuilder.Entity<Sat_tipopermiso>());
            //IposV3.Model.Sat_colonia.ConfigureEntityBaseKey(modelBuilder.Entity<Sat_colonia>());
            //IposV3.Model.Sat_localidad.ConfigureEntityBaseKey(modelBuilder.Entity<Sat_localidad>());
            //IposV3.Model.Sat_municipio.ConfigureEntityBaseKey(modelBuilder.Entity<Sat_municipio>());
            //IposV3.Model.Sat_partetransporte.ConfigureEntityBaseKey(modelBuilder.Entity<Sat_partetransporte>());
            //IposV3.Model.Sat_figuratransporte.ConfigureEntitBaseKey(modelBuilder.Entity<Sat_figuratransporte>());
            //IposV3.Model.Sat_configautotransporte.ConfigureEntityBaseKey(modelBuilder.Entity<Sat_configautotransporte>());
            //IposV3.Model.Sat_subtiporem.ConfigureEntityBaseKey(modelBuilder.Entity<Sat_subtiporem>());
            IposV3.Model.Personafigura.ConfigureEntityBaseKey(modelBuilder.Entity<Personafigura>());
            IposV3.Model.Vehiculo.ConfigureEntityBaseKey(modelBuilder.Entity<Vehiculo>());
            IposV3.Model.Cartaporte.ConfigureEntity(modelBuilder.Entity<Cartaporte>());
            IposV3.Model.CartaporteAutotransp.ConfigureEntityBaseKey(modelBuilder.Entity<CartaporteAutotransp>());
            IposV3.Model.CartaporteCanttransp.ConfigureEntityBaseKey(modelBuilder.Entity<CartaporteCanttransp>());
            IposV3.Model.CartaporteMercancia.ConfigureEntityBaseKey(modelBuilder.Entity<CartaporteMercancia>());
            IposV3.Model.CartaporteTotalmercancias.ConfigureEntityBaseKey(modelBuilder.Entity<CartaporteTotalmercancias>());
            IposV3.Model.CartaporteTransptipofigura.ConfigureEntityBaseKey(modelBuilder.Entity<CartaporteTransptipofigura>());
            IposV3.Model.CartaporteUbicacion.ConfigureEntityBaseKey(modelBuilder.Entity<CartaporteUbicacion>());
            //IposV3.Model.Sat_matpeligroso.ConfigureEntityBaseKey(modelBuilder.Entity<Sat_matpeligroso>());
            IposV3.Model.Pagodoctosat_imp.ConfigureEntityBaseKey(modelBuilder.Entity<Pagodoctosat_imp>());


            modelBuilder.Entity<SimpleLong>().HasNoKey();



        }


        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties(typeof(BoolCS))
                .HaveConversion<string>()
                .HaveColumnType("char(1)");


            builder.Properties(typeof(BoolCN))
                .HaveConversion<string>()
                .HaveColumnType("char(1)");


            builder.Properties(typeof(BoolCNI))
                .HaveConversion<string>()
                .HaveColumnType("char(1)");


            builder.Properties(typeof(BoolManejoReceta))
                .HaveConversion<string>()
                .HaveColumnType("char(1)");

            builder.Properties(typeof(TipoPagoConTarjeta))
                .HaveConversion<string>()
                .HaveColumnType("char(1)");



            //builder
            //    .Properties<DateTime>()
            //    .HaveConversion(typeof(UtcValueConverter));

            //builder
            //    .Properties<Nullable<DateTime>>()
            //    .HaveConversion(typeof(UtcValueConverter));




        }


        private string? connectionString = null ;
        public string? ConnectionString {
            get
            {
                //if (connectionString == null)
                //{
                //    connectionString = "Server=localhost;Port=5432;Database=ipos3_1;User Id=postgres;Password=Twincept.l;Include Error Detail=true;";
                //}

                return connectionString;
            }
            set {
                connectionString = value;
            } 
        } //= "Server=localhost;Port=5432;Database=ipos3_1;User Id=postgres;Password=Twincept.l;";


        //protected Func<string> ConnectionMethod { get; set; }

        protected bool IsConnected { get; set; }


#pragma warning disable CS8618
        //public ApplicationDbContext():base()
        //{
        //}

        //public ApplicationDbContext(string? connectionString):this()
        //{
        //    this.ConnectionString = connectionString;

        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

       

#pragma warning restore CS8618


        //public ApplicationDbContext(Func<string> connectionMethod) {

        //    this.ConnectionString = connectionMethod();
        //    this.ConnectionMethod = connectionMethod;
        //    IsConnected = false;
        //}


    }




    class UtcValueConverter : ValueConverter<DateTime, DateTime>
    {

        public UtcValueConverter()
            : base(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
        {
        }
    }


    public class OperationsContextFactory : IDbContextFactory<ApplicationDbContext>
    {

        private string? connectionString = null;
        public string? ConnectionString
        {
            get
            {
                //if (connectionString == null)
                //{
                //    connectionString = "Server=localhost;Port=5432;Database=ipos3_1;User Id=postgres;Password=Twincept.l;Include Error Detail=true;";
                //}

                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }

        public ApplicationDbContext Create()
        {
            return null;
            //return new ApplicationDbContext(this.connectionString);
        }

        public ApplicationDbContext CreateDbContext()
        {
            return null;
            //return new ApplicationDbContext(this.connectionString);
        }
    }


}
