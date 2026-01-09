using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BindingModels;
using Z.EntityFramework.Plus;
using System.Runtime.Intrinsics.Arm;
using IposV3.Services;
using IposV3.Services.Extensions;

namespace IposV3.Services
{
    public class CartaporteFacturaElectronicaService
    {


        private MaestroConsecutivoService _maestroConsecutivoService;
        public CartaporteFacturaElectronicaService(MaestroConsecutivoService maestroConsecutivoService)
        {
            _maestroConsecutivoService = maestroConsecutivoService;
        }

        public CartaporteBindingModel CartaPorteDeTransaccion(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    ApplicationDbContext localContext)
        {

            var cartaPorteGuardado = localContext.Cartaporte.AsNoTracking()
                                                 .Include(c => c.CartaporteAutotransps)
                                                 .Include(c => c.CartaporteCanttransps)
                                                 .Include(c => c.CartaporteMercancias)
                                                 .Include(c => c.CartaporteTotalmercancias)
                                                 .Include(c => c.CartaporteTransptipofiguras)
                                                 .Include(c => c.CartaporteUbicacions)
                                                 .Include(c => c.Docto)
                                                 .FirstOrDefault(c => c.EmpresaId == empresaId && c.SucursalId == sucursalId && c.Doctoid == doctoId);

            if(cartaPorteGuardado == null)
            {
                return LlenarCartaporteDeTransaccion(empresaId, sucursalId, doctoId, localContext);
            }

            CartaporteBindingModel cartaPorteBM = new CartaporteBindingModel();
            cartaPorteBM.FillFromEntity(cartaPorteGuardado);
            return cartaPorteBM;

        }



       public CartaporteBindingModel LlenarCartaporteDeTransaccion(
                    long empresaId,
                    long sucursalId,
                    long doctoId,
                    ApplicationDbContext localContext)
        {
            CartaporteBindingModel cartaporteBindingModel = new CartaporteBindingModel();

            long? clienteId;
            long? origenClienteId;
            int? doctoFolio;
            //long? encargadoGuiaId;
            //long? duenioId;
            BoolCN contieneMaterialPeligroso = BoolCN.N;
            long? subtipoDoctoId;
            string? entregaCalleSucursaldest;
            BoolCN? preguntarDatosEntrega;
            string? clienteEntregaCalle;
            string? entregaCalleSucursalOrigen;
            BoolCNI usarDatosEntrega = BoolCNI.N;

            var empresaInfo = localContext.Empresa.AsNoTracking()
                .FirstOrDefault(e => e.Id == empresaId);

            if(empresaInfo == null)
                throw new Exception("No existe la empresa");



            var doctoInfo = localContext.Docto.AsNoTracking()
                                        .Include(d => d.Docto_fact_elect)
                                        .Include(d => d.Cliente).ThenInclude(c => c!.Domicilio)
                                        .Include(d => d.Cliente).ThenInclude(c => c!.Domicilioentrega)
                                        .Include(d => d.Cliente).ThenInclude(o => o!.Cliente_fact_elect).ThenInclude(f => f!.Sat_Colonia)
                                        .Include(d => d.Cliente).ThenInclude(o => o!.Cliente_fact_elect).ThenInclude(f => f!.Sat_Localidad)
                                        .Include(d => d.Cliente).ThenInclude(o => o!.Cliente_fact_elect).ThenInclude(f => f!.Sat_Municipio)
                                        .Include(d => d.Cliente).ThenInclude(o => o!.Cliente_fact_elect).ThenInclude(f => f!.Entrega_Sat_Colonia)
                                        .Include(d => d.Cliente).ThenInclude(o => o!.Cliente_fact_elect).ThenInclude(f => f!.Entrega_Sat_Localidad)
                                        .Include(d => d.Cliente).ThenInclude(o => o!.Cliente_fact_elect).ThenInclude(f => f!.Entrega_Sat_Municipio)
                                        .Include(d=> d.Docto_guia)
                                        .Include(d => d.Sucursal_info).ThenInclude(s => s!.Sucursal_info_opciones).ThenInclude(o => o!.Sucursal_fact_elect)
                                        .Include(d => d.Docto_traslado).ThenInclude(t => t!.Sucursalt).ThenInclude(t => t!.Sucursal_info_opciones).ThenInclude(o => o!.Sucursal_fact_elect).ThenInclude(f => f!.Entrega_Sat_Colonia)
                                        .Include(d => d.Docto_traslado).ThenInclude(t => t!.Sucursalt).ThenInclude(t => t!.Sucursal_info_opciones).ThenInclude(o => o!.Sucursal_fact_elect).ThenInclude(f => f!.Entrega_Sat_Localidad)
                                        .Include(d => d.Docto_traslado).ThenInclude(t => t!.Sucursalt).ThenInclude(t => t!.Sucursal_info_opciones).ThenInclude(o => o!.Sucursal_fact_elect).ThenInclude(f => f!.Entrega_Sat_Municipio)
                                        .Include(d => d.Docto_traslado).ThenInclude(t => t!.Sucursalt).ThenInclude(t => t!.Sucursal_info_opciones).ThenInclude(o => o!.Sucursal_fact_elect).ThenInclude(f => f!.Entregaestado)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Vehiculo).ThenInclude(v => v!.Sat_Tipopermiso)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Vehiculo).ThenInclude(v => v!.Sat_Configautotransporte)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Vehiculo).ThenInclude(v => v!.Sat_Subtiporem1)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Vehiculo).ThenInclude(v => v!.Sat_Subtiporem2)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Encargadoguia).ThenInclude(e => e!.Domicilio)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Encargadoguia).ThenInclude(e => e!.Usuario_Personafigura).ThenInclude(f => f!.Sat_Figuratransporte)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Encargadoguia).ThenInclude(e => e!.Usuario_Personafigura).ThenInclude(f => f!.Sat_Partetransporte)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Encargadoguia).ThenInclude(e => e!.Usuario_fact_elect).ThenInclude(f => f!.Sat_Colonia)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Encargadoguia).ThenInclude(e => e!.Usuario_fact_elect).ThenInclude(f => f!.Sat_Localidad)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Encargadoguia).ThenInclude(e => e!.Usuario_fact_elect).ThenInclude(f => f!.Sat_Municipio)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Vehiculo).ThenInclude(v => v!.Duenio).ThenInclude(e => e!.Domicilio)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Vehiculo).ThenInclude(v => v!.Duenio).ThenInclude(e => e!.Usuario_Personafigura).ThenInclude(f => f!.Sat_Figuratransporte)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Vehiculo).ThenInclude(v => v!.Duenio).ThenInclude(e => e!.Usuario_Personafigura).ThenInclude(f => f!.Sat_Partetransporte)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Vehiculo).ThenInclude(v => v!.Duenio).ThenInclude(e => e!.Usuario_fact_elect).ThenInclude(f => f!.Sat_Colonia)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Vehiculo).ThenInclude(v => v!.Duenio).ThenInclude(e => e!.Usuario_fact_elect).ThenInclude(f => f!.Sat_Localidad)
                                        .Include(d => d.Docto_guia).ThenInclude(dg => dg!.Guia).ThenInclude(g => g!.Vehiculo).ThenInclude(v => v!.Duenio).ThenInclude(e => e!.Usuario_fact_elect).ThenInclude(f => f!.Sat_Municipio)

                                        .FirstOrDefault(d => d.EmpresaId == empresaId && d.SucursalId == sucursalId && d.Id == doctoId)
                                        ;

            if (doctoInfo == null)
                throw new Exception("No existe el docto");


            clienteId = doctoInfo.Clienteid;
            doctoFolio = doctoInfo.Folio;
            clienteEntregaCalle = doctoInfo.Cliente?.Domicilioentrega?.Calle;
            subtipoDoctoId = doctoInfo.Subtipodoctoid;
            entregaCalleSucursaldest = doctoInfo.Docto_traslado?.Sucursalt?.Sucursal_info_opciones?.Sucursal_fact_elect?.Entregacalle;
            usarDatosEntrega = doctoInfo.Docto_guia?.Usardatosentrega ?? BoolCNI.N;


            var parametroInfo = localContext.Parametro.AsNoTracking()
                                            .Include(p => p.Sucursal)
                        .FirstOrDefault(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId);


            var sucursal_info = localContext.Sucursal_info.AsNoTracking()
                                            .Include(y => y.Sucursal)
                                            .Include(s => s.Sucursal_info_opciones).ThenInclude(o => o!.Sucursal_fact_elect).ThenInclude(f => f!.Entrega_Sat_Colonia)
                                            .Include(s => s.Sucursal_info_opciones).ThenInclude(o => o!.Sucursal_fact_elect).ThenInclude(f => f!.Entrega_Sat_Localidad)
                                            .Include(s => s.Sucursal_info_opciones).ThenInclude(o => o!.Sucursal_fact_elect).ThenInclude(f => f!.Entrega_Sat_Municipio)
                                            .Include(s => s.Sucursal_info_opciones).ThenInclude(o => o!.Sucursal_fact_elect).ThenInclude(f => f!.Entregaestado)
                                            .FirstOrDefault(s => s.EmpresaId == empresaId && s.SucursalId == sucursalId && s.Clave == s.Sucursal.Clave);

            if (parametroInfo == null)
                throw new Exception("no existe la informacion de parametro");


            if (sucursal_info == null)
                throw new Exception("No hay informacion de sucursal");

            origenClienteId = sucursal_info.Sucursal_info_opciones?.Clienteid;
            preguntarDatosEntrega = parametroInfo.Preguntardatosentrega;
            entregaCalleSucursalOrigen = sucursal_info.Sucursal_info_opciones?.Sucursal_fact_elect?.Entregacalle;

            var folioSubstr6 = (doctoInfo.Folio ?? 0).ToString().PadLeft(6, '0');
            folioSubstr6 = folioSubstr6.Substring(folioSubstr6.Length - 6);

            CartaporteUbicacionBindingModel ubicacionOrigen = new CartaporteUbicacionBindingModel();

            if((entregaCalleSucursalOrigen ?? "" ) != "")
            {
                //origen
                ubicacionOrigen.Tipoubicacion = "Origen";
                ubicacionOrigen.Idubicacion = "OR" + folioSubstr6;
                ubicacionOrigen.Rfcremitentedestinatario = empresaInfo.Rfc;
                ubicacionOrigen.Nombreremitentedestinatario = parametroInfo.Fiscalnombre;
                ubicacionOrigen.Numregidtrib = "";
                ubicacionOrigen.Residenciafiscal = "";
                ubicacionOrigen.Numestacion = "";
                ubicacionOrigen.Nombreestacion = "";
                ubicacionOrigen.Navegaciontrafico = "";
                ubicacionOrigen.Fechahorasalidallegada = doctoInfo.Docto_guia?.Guia?.Fechahora?.ToString("yyyy-MM-ddTHH:mm:ss");
                ubicacionOrigen.Tipoestacion = "";
                ubicacionOrigen.Distanciarecorrida = "";
                ubicacionOrigen.Calle = sucursal_info.Sucursal_info_opciones?.Sucursal_fact_elect?.Entregacalle;
                ubicacionOrigen.Numeroexterior = sucursal_info.Sucursal_info_opciones?.Sucursal_fact_elect?.Entreganumeroexterior;
                ubicacionOrigen.Numerointerior = sucursal_info.Sucursal_info_opciones?.Sucursal_fact_elect?.Entreganumerointerior;

                ubicacionOrigen.Colonia = sucursal_info.Sucursal_info_opciones?.Sucursal_fact_elect?.Entrega_Sat_Colonia?.Colonia;
                ubicacionOrigen.Localidad = sucursal_info.Sucursal_info_opciones?.Sucursal_fact_elect?.Entrega_Sat_Localidad?.Clave_localidad;
                ubicacionOrigen.Municipio = sucursal_info.Sucursal_info_opciones?.Sucursal_fact_elect?.Entrega_Sat_Municipio?.Clave_municipio;
                ubicacionOrigen.Estado = ValorEstadoParaCartaPorte(sucursal_info.Sucursal_info_opciones?.Sucursal_fact_elect?.Entregaestado?.Acronimo);
                ubicacionOrigen.Pais = "MEX";
                ubicacionOrigen.Codigopostal = sucursal_info.Sucursal_info_opciones?.Sucursal_fact_elect?.Entregacodigopostal;

                ubicacionOrigen.Referencia = "";



            }
            else
            {
                //origen
                ubicacionOrigen.Tipoubicacion = "Origen";
                ubicacionOrigen.Idubicacion = "OR" + folioSubstr6;
                ubicacionOrigen.Rfcremitentedestinatario = empresaInfo.Rfc;
                ubicacionOrigen.Nombreremitentedestinatario = parametroInfo.Fiscalnombre;
                ubicacionOrigen.Numregidtrib = "";
                ubicacionOrigen.Residenciafiscal = "";
                ubicacionOrigen.Numestacion = "";
                ubicacionOrigen.Nombreestacion = "";
                ubicacionOrigen.Navegaciontrafico = "";
                ubicacionOrigen.Fechahorasalidallegada = doctoInfo.Docto_guia?.Guia?.Fechahora?.ToString("yyyy-MM-ddTHH:mm:ss");
                ubicacionOrigen.Tipoestacion = "";
                ubicacionOrigen.Distanciarecorrida = "";


                ubicacionOrigen.Calle = doctoInfo.Cliente?.Domicilio?.Calle;
                ubicacionOrigen.Numeroexterior = doctoInfo.Cliente?.Domicilio?.Numeroexterior;
                ubicacionOrigen.Numerointerior = doctoInfo.Cliente?.Domicilio?.Numerointerior;

                ubicacionOrigen.Colonia = doctoInfo.Cliente?.Cliente_fact_elect?.Sat_Colonia?.Colonia;
                ubicacionOrigen.Localidad = doctoInfo.Cliente?.Cliente_fact_elect?.Sat_Localidad?.Clave_localidad;
                ubicacionOrigen.Municipio = doctoInfo.Cliente?.Cliente_fact_elect?.Sat_Municipio?.Clave_municipio;
                ubicacionOrigen.Estado = ValorEstadoParaCartaPorte(doctoInfo.Cliente?.Cliente_fact_elect?.Sat_Municipio?.Clave_estado);
                ubicacionOrigen.Pais = "MEX";
                ubicacionOrigen.Codigopostal = doctoInfo.Cliente?.Domicilio?.Codigopostal;

                ubicacionOrigen.Referencia = "";

            }

            CartaporteUbicacionBindingModel ubicacionDestino = new CartaporteUbicacionBindingModel();


            if ((subtipoDoctoId ?? 0).In(7,8) && (entregaCalleSucursaldest ?? "") != "")
            {
                //destino

                ubicacionDestino.Tipoubicacion = "Destino";
                ubicacionDestino.Idubicacion = "DE" + folioSubstr6;
                ubicacionDestino.Rfcremitentedestinatario = ((doctoInfo!.Docto_fact_elect?.Esfacturaelectronica  ?? BoolCN.N) == BoolCN.N ||
                                                             (doctoInfo.Docto_fact_elect?.Timbradouuidcancelacion ?? "") == "")
                                                             ?
                                                                    "XAXX010101000" :
                                                                    (doctoInfo.Cliente?.Rfc ?? "XAXX010101000");

                ubicacionDestino.Nombreremitentedestinatario = doctoInfo.Cliente?.Nombre ?? doctoInfo.Docto_traslado?.Sucursalt?.Nombre;
                ubicacionDestino.Numregidtrib = "";
                ubicacionDestino.Residenciafiscal = "";
                ubicacionDestino.Numestacion = "";
                ubicacionDestino.Nombreestacion = "";
                ubicacionDestino.Navegaciontrafico = "";
                ubicacionDestino.Fechahorasalidallegada = doctoInfo.Docto_guia?.Guia?.Horaestimadrec?.ToString("yyyy-MM-ddTHH:mm:ss");
                ubicacionDestino.Tipoestacion = "";
                ubicacionDestino.Distanciarecorrida = doctoInfo.Docto_traslado?.Sucursalt?.Sucursal_info_opciones?.Sucursal_fact_elect?.Entrega_Distancia.ToString("N3");
                ubicacionDestino.Calle = doctoInfo.Docto_traslado?.Sucursalt?.Sucursal_info_opciones?.Sucursal_fact_elect?.Entregacalle;
                ubicacionDestino.Numeroexterior = doctoInfo.Docto_traslado?.Sucursalt?.Sucursal_info_opciones?.Sucursal_fact_elect?.Entreganumeroexterior;
                ubicacionDestino.Numerointerior = doctoInfo.Docto_traslado?.Sucursalt?.Sucursal_info_opciones?.Sucursal_fact_elect?.Entreganumerointerior;

                ubicacionDestino.Colonia = doctoInfo.Docto_traslado?.Sucursalt?.Sucursal_info_opciones?.Sucursal_fact_elect?.Entrega_Sat_Colonia?.Colonia;
                ubicacionDestino.Localidad = doctoInfo.Docto_traslado?.Sucursalt?.Sucursal_info_opciones?.Sucursal_fact_elect?.Entrega_Sat_Localidad?.Clave_localidad;
                ubicacionDestino.Municipio = doctoInfo.Docto_traslado?.Sucursalt?.Sucursal_info_opciones?.Sucursal_fact_elect?.Entrega_Sat_Municipio?.Clave_municipio;
                ubicacionDestino.Estado = ValorEstadoParaCartaPorte(doctoInfo.Docto_traslado?.Sucursalt?.Sucursal_info_opciones?.Sucursal_fact_elect?.Entregaestado?.Acronimo);
                ubicacionDestino.Pais = "MEX";
                ubicacionDestino.Codigopostal = doctoInfo.Docto_traslado?.Sucursalt?.Sucursal_info_opciones?.Sucursal_fact_elect?.Entregacodigopostal;

                ubicacionDestino.Referencia = "";

            }
            else if(usarDatosEntrega  != BoolCNI.N && (clienteEntregaCalle ?? "") != "")
            {
                //destino

                ubicacionDestino.Tipoubicacion = "Destino";
                ubicacionDestino.Idubicacion = "DE" + folioSubstr6;
                ubicacionDestino.Rfcremitentedestinatario = ((doctoInfo!.Docto_fact_elect?.Esfacturaelectronica ?? BoolCN.N) == BoolCN.N ||
                                                             (doctoInfo.Docto_fact_elect?.Timbradouuidcancelacion ?? "") == "")
                                                             ?
                                                                    "XAXX010101000" :
                                                                    (doctoInfo.Cliente?.Rfc ?? "XAXX010101000");

                ubicacionDestino.Nombreremitentedestinatario = doctoInfo.Cliente?.Nombre ;
                ubicacionDestino.Numregidtrib = "";
                ubicacionDestino.Residenciafiscal = "";
                ubicacionDestino.Numestacion = "";
                ubicacionDestino.Nombreestacion = "";
                ubicacionDestino.Navegaciontrafico = "";
                ubicacionDestino.Fechahorasalidallegada = doctoInfo.Docto_guia?.Guia?.Horaestimadrec?.ToString("yyyy-MM-ddTHH:mm:ss");
                ubicacionDestino.Tipoestacion = "";
                ubicacionDestino.Distanciarecorrida = doctoInfo.Cliente?.Cliente_fact_elect?.Entrega_Distancia.ToString("N3");
                ubicacionDestino.Calle = doctoInfo.Cliente?.Domicilioentrega?.Calle;
                ubicacionDestino.Numeroexterior = doctoInfo.Cliente?.Domicilioentrega?.Numeroexterior;
                ubicacionDestino.Numerointerior = doctoInfo.Cliente?.Domicilioentrega?.Numerointerior;

                ubicacionDestino.Colonia = doctoInfo.Cliente?.Cliente_fact_elect?.Entrega_Sat_Colonia?.Colonia;
                ubicacionDestino.Localidad = doctoInfo.Cliente?.Cliente_fact_elect?.Entrega_Sat_Localidad?.Clave_localidad;
                ubicacionDestino.Municipio = doctoInfo.Cliente?.Cliente_fact_elect?.Entrega_Sat_Municipio?.Clave_municipio;
                ubicacionDestino.Estado = ValorEstadoParaCartaPorte(doctoInfo.Cliente?.Cliente_fact_elect?.Entrega_Sat_Municipio?.Clave_estado);
                ubicacionDestino.Pais = "MEX";
                ubicacionDestino.Codigopostal =  doctoInfo.Cliente?.Domicilioentrega?.Codigopostal;

                ubicacionDestino.Referencia = "";
            }
            else
            {
                //destino

                ubicacionDestino.Tipoubicacion = "Destino";
                ubicacionDestino.Idubicacion = "DE" + folioSubstr6;
                ubicacionDestino.Rfcremitentedestinatario = ((doctoInfo!.Docto_fact_elect?.Esfacturaelectronica ?? BoolCN.N) == BoolCN.N ||
                                                             (doctoInfo.Docto_fact_elect?.Timbradouuidcancelacion ?? "") == "")
                                                             ?
                                                                    "XAXX010101000" :
                                                                    (doctoInfo.Cliente?.Rfc ?? "XAXX010101000");

                ubicacionDestino.Nombreremitentedestinatario = doctoInfo.Cliente?.Nombre;
                ubicacionDestino.Numregidtrib = "";
                ubicacionDestino.Residenciafiscal = "";
                ubicacionDestino.Numestacion = "";
                ubicacionDestino.Nombreestacion = "";
                ubicacionDestino.Navegaciontrafico = "";
                ubicacionDestino.Fechahorasalidallegada = doctoInfo.Docto_guia?.Guia?.Horaestimadrec?.ToString("yyyy-MM-ddTHH:mm:ss");
                ubicacionDestino.Tipoestacion = "";
                ubicacionDestino.Distanciarecorrida = doctoInfo.Cliente?.Cliente_fact_elect?.Distancia.ToString("N2");
                ubicacionDestino.Calle = doctoInfo.Cliente?.Domicilio?.Calle;
                ubicacionDestino.Numeroexterior = doctoInfo.Cliente?.Domicilio?.Numeroexterior;
                ubicacionDestino.Numerointerior = doctoInfo.Cliente?.Domicilio?.Numerointerior;

                ubicacionDestino.Colonia = doctoInfo.Cliente?.Cliente_fact_elect?.Sat_Colonia?.Colonia;
                ubicacionDestino.Localidad = doctoInfo.Cliente?.Cliente_fact_elect?.Sat_Localidad?.Clave_localidad;
                ubicacionDestino.Municipio = doctoInfo.Cliente?.Cliente_fact_elect?.Sat_Municipio?.Clave_municipio;
                ubicacionDestino.Estado = ValorEstadoParaCartaPorte(doctoInfo.Cliente?.Cliente_fact_elect?.Sat_Municipio?.Clave_estado);
                ubicacionDestino.Pais = "MEX";
                ubicacionDestino.Codigopostal = doctoInfo.Cliente?.Domicilio?.Codigopostal;

                ubicacionDestino.Referencia = "";
            }


            CartaporteTotalmercanciasBindingModel cartaporteTotalmercancias = new CartaporteTotalmercanciasBindingModel();
            cartaporteTotalmercancias.Cargoportasacion = "";
            cartaporteTotalmercancias.Unidadpeso = "KGM";

            var movtosInfo = localContext.Movto.AsNoTracking()
                                                    .Include(m => m.Producto).ThenInclude(p => p!.Producto_fact_elect)
                                                    .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId && p.Doctoid == doctoId)
                                                    .ToList();

            var bufferCartaPorteTotal = movtosInfo.GroupBy(m => m.Doctoid)
                                                    .Select(m => new
                                                    {
                                                        Pesobrutototal = m.Sum(p => (p.Producto != null && p.Producto.Producto_fact_elect != null ? p.Producto.Producto_fact_elect.Peso : 0m) * p.Cantidad),
                                                        Pesonetototal = m.Sum(p => (p.Producto != null && p.Producto.Producto_fact_elect != null ? p.Producto.Producto_fact_elect.Peso : 0m) * p.Cantidad),
                                                        Numtotalmercancias = m.Count(),
                                                        Cantidadtotal = m.Sum(p => (p.Cantidad))
                                                    })
                                                    .FirstOrDefault();

            cartaporteTotalmercancias.Pesobrutototal = bufferCartaPorteTotal?.Pesobrutototal.ToString("N3") ?? "0.000";
            cartaporteTotalmercancias.Pesonetototal = bufferCartaPorteTotal?.Pesonetototal.ToString("N3") ?? "0.000";
            cartaporteTotalmercancias.Numtotalmercancias = bufferCartaPorteTotal?.Numtotalmercancias.ToString("N0") ?? "0";





            //cartaporte mercancias
            var movtosMercancia = localContext.Movto.AsNoTracking()
                                              .Include(m => m.Producto).ThenInclude(p => p!.Unidad).ThenInclude(u => u!.Sat_unidadmedida)
                                              .Include(m => m.Producto).ThenInclude(p => p!.Producto_fact_elect).ThenInclude(f => f!.Sat_Claveunidadpeso)
                                              .Include(m => m.Producto).ThenInclude(p => p!.Producto_fact_elect).ThenInclude(f => f!.Sat_Matpeligroso)
                                              .Include(m => m.Producto).ThenInclude(p => p!.Producto_fact_elect).ThenInclude(f => f!.Sat_productoservicio)
                                              .Include(m => m.Producto).ThenInclude(p => p!.Producto_fact_elect).ThenInclude(f => f!.Sat_Tipoembalaje)
                                              .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Doctoid == doctoId)
                                              .Select(m => new
                                              {
                                                  Bienstransp = m.Producto != null && m.Producto.Producto_fact_elect != null && m.Producto.Producto_fact_elect.Sat_productoservicio != null ? 
                                                                m.Producto.Producto_fact_elect.Sat_productoservicio.Sat_claveprodserv : "",
                                                  Clavestcc = "" ,
                                                  Descripcion = m.Producto != null ? 
                                                                m.Producto.Descripcion1 : "",
                                                  Cantidad = m.Cantidad,
                                                  Claveunidad = m.Producto != null && m.Producto.Unidad  != null && m.Producto.Unidad.Sat_unidadmedida  != null ? 
                                                                m.Producto.Unidad.Sat_unidadmedida.Clave : "" ,
                                                  Unidad = "",
                                                  Dimensiones = "" ,
                                                  Materialpeligroso = m.Producto != null && m.Producto.Producto_fact_elect != null ?
                                                                        (m.Producto.Producto_fact_elect.Espeligroso == BoolCN.S ? "Si" : "No") : "",
                                                  Cvematerialpeligroso = m.Producto != null && m.Producto.Producto_fact_elect != null && m.Producto.Producto_fact_elect.Sat_Matpeligroso != null && m.Producto.Producto_fact_elect.Espeligroso == BoolCN.S ?
                                                                                                m.Producto.Producto_fact_elect.Sat_Matpeligroso.Clave : 
                                                                                                "",
                                                  Embalaje = m.Producto != null && m.Producto.Producto_fact_elect != null && m.Producto.Producto_fact_elect.Sat_Tipoembalaje != null && m.Producto.Producto_fact_elect.Espeligroso == BoolCN.S ?
                                                                                                m.Producto.Producto_fact_elect.Sat_Tipoembalaje.Clave :
                                                                                                "",
                                                  Descripembalaje = m.Producto != null && m.Producto.Producto_fact_elect != null && m.Producto.Producto_fact_elect.Sat_Tipoembalaje != null && m.Producto.Producto_fact_elect.Espeligroso == BoolCN.S ?
                                                                                                m.Producto.Producto_fact_elect.Sat_Tipoembalaje.Descripcion :
                                                                                                "",
                                                  Pesoenkg = m.Producto != null && m.Producto.Producto_fact_elect != null ?
                                                                    m.Producto.Producto_fact_elect.Peso * m.Cantidad : -1,
                                                  Valormercancia = m.Total,
                                                  Moneda = "MXN" ,
                                                  Fraccionarancelaria = "" ,
                                                  Uuidcomercioext = "" ,
                    
                                                  Unidadpesomerc = ""  ,
                                                  Pesobruto = ""  ,
                                                  Pesoneto = "" ,
                                                  Pesotara = "" ,
                                                  Numpiezas = "" ,
                                                  Productoclave = m.Producto != null ? m.Producto.Clave : ""

                                              }).ToList();

            if (movtosMercancia == null)
                throw new Exception("No se encontro la mercancia");

            List<CartaporteMercanciaBindingModel> cartaporteMercancias = new List<CartaporteMercanciaBindingModel>();
            foreach(var merc in movtosMercancia)
            {
                CartaporteMercanciaBindingModel cartaporteMercanciaBindingModel = new CartaporteMercanciaBindingModel();

                cartaporteMercanciaBindingModel.Bienestransp = merc.Bienstransp;
                cartaporteMercanciaBindingModel.Clavestcc = "";
                cartaporteMercanciaBindingModel.Descripcion = merc.Descripcion;
                cartaporteMercanciaBindingModel.Cantidad = merc.Cantidad.ToString();
                cartaporteMercanciaBindingModel.Claveunidad = merc.Claveunidad;
                cartaporteMercanciaBindingModel.Unidad = merc.Unidad;
                cartaporteMercanciaBindingModel.Dimensiones = merc.Dimensiones;
                cartaporteMercanciaBindingModel.Materialpeligroso = merc.Materialpeligroso;
                cartaporteMercanciaBindingModel.Cvematerialpeligroso = merc.Cvematerialpeligroso;
                cartaporteMercanciaBindingModel.Embalaje = merc.Embalaje;
                cartaporteMercanciaBindingModel.Descripembalaje = merc.Descripembalaje;
                cartaporteMercanciaBindingModel.Pesoenkg = merc.Pesoenkg < 0 ? "" : merc.Pesoenkg.ToString("#.###");
                cartaporteMercanciaBindingModel.Valormercancia = merc.Valormercancia.ToString("#.##");
                cartaporteMercanciaBindingModel.Moneda = merc.Moneda;
                cartaporteMercanciaBindingModel.Fraccionarancelaria = merc.Fraccionarancelaria;
                cartaporteMercanciaBindingModel.Uuidcomercioext = merc.Uuidcomercioext;
                cartaporteMercanciaBindingModel.Unidadpesomerc = merc.Unidadpesomerc;
                cartaporteMercanciaBindingModel.Pesobruto = merc.Pesobruto;
                cartaporteMercanciaBindingModel.Pesoneto = merc.Pesoneto;
                cartaporteMercanciaBindingModel.Pesotara = merc.Pesotara;
                cartaporteMercanciaBindingModel.Numpiezas = merc.Numpiezas; 

                cartaporteMercancias.Add(cartaporteMercanciaBindingModel);
            }

            CartaporteCanttranspBindingModel cartaporteCanttransp = new CartaporteCanttranspBindingModel();
            cartaporteCanttransp.Cantidad = (bufferCartaPorteTotal?.Cantidadtotal  ?? 0m).ToString();
            cartaporteCanttransp.Iddestino = "DE" + folioSubstr6;
            cartaporteCanttransp.Idorigen = "OR" + folioSubstr6;
            cartaporteCanttransp.Cvestransporte = "";

            CartaporteAutotranspBindingModel cartaporteAutotransp = new CartaporteAutotranspBindingModel();
            cartaporteAutotransp.Permsct = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Sat_Tipopermiso?.Clave;
            cartaporteAutotransp.Numpermisosct = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Numpermisosct;
            cartaporteAutotransp.Configvehicular = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Sat_Configautotransporte?.Clave;
            cartaporteAutotransp.Placavm = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Placavm;
            cartaporteAutotransp.Aniomodelovm = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Aniomodelovm;
            cartaporteAutotransp.Asegurarespcivil = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Asegurarespcivil;
            cartaporteAutotransp.Polizarespcivil = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Polizarespcivil;

            cartaporteAutotransp.Aseguramedambiente = contieneMaterialPeligroso == BoolCN.S ? (doctoInfo.Docto_guia?.Guia?.Vehiculo?.Aseguramedambiente ?? "") : "";
            cartaporteAutotransp.Polizamedambiente = contieneMaterialPeligroso == BoolCN.S ? (doctoInfo.Docto_guia?.Guia?.Vehiculo?.Polizamedambiente ?? "") : "";


            cartaporteAutotransp.Aseguracarga = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Aseguracarga ;
            cartaporteAutotransp.Polizacarga = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Polizacarga ;
            cartaporteAutotransp.Primaseguro = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Primaseguro ;
            cartaporteAutotransp.Subtiporem1 = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Sat_Subtiporem1?.Clave;
            cartaporteAutotransp.Placa1 = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Placa1;
            cartaporteAutotransp.Subtiporem2 = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Sat_Subtiporem2?.Clave;
            cartaporteAutotransp.Placa2 = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Placa2;

            CartaporteTransptipofiguraBindingModel cartaporteTransptipofiguraEncargado = new CartaporteTransptipofiguraBindingModel();
            cartaporteTransptipofiguraEncargado.Tipofigura = doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Usuario_Personafigura?.Sat_Figuratransporte?.Clave;
            cartaporteTransptipofiguraEncargado.Rfcfigura = doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Rfc;
            cartaporteTransptipofiguraEncargado.Numlicencia = doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Usuario_Personafigura?.Numlicencia;
            cartaporteTransptipofiguraEncargado.Nombrefigura = doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Nombre;
            cartaporteTransptipofiguraEncargado.Numregidtribfigura = cartaporteTransptipofiguraEncargado.Rfcfigura != null && cartaporteTransptipofiguraEncargado.Rfcfigura.Length > 0 ? "" :
                                                                            doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Usuario_Personafigura?.Numregidtrib;
            cartaporteTransptipofiguraEncargado.Residenciafiscalfigura = "";
            cartaporteTransptipofiguraEncargado.Partetransporte = (doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Usuario_Personafigura?.Sat_Figuratransporte?.Clave ?? "") != "01" ? (doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Usuario_Personafigura?.Sat_Partetransporte?.Clave ?? "") : "";
            cartaporteTransptipofiguraEncargado.Calle = doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Domicilio?.Calle;
            cartaporteTransptipofiguraEncargado.Numeroexterior = doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Domicilio?.Numeroexterior;
            cartaporteTransptipofiguraEncargado.Numerointerior = doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Domicilio?.Numerointerior;
            cartaporteTransptipofiguraEncargado.Colonia = doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Usuario_fact_elect?.Sat_Colonia?.Clave;
            cartaporteTransptipofiguraEncargado.Localidad = doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Usuario_fact_elect?.Sat_Localidad?.Clave;
            cartaporteTransptipofiguraEncargado.Referencia = doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Usuario_fact_elect?.Referenciadom;
            cartaporteTransptipofiguraEncargado.Municipio = doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Usuario_fact_elect?.Sat_Municipio?.Clave;
            cartaporteTransptipofiguraEncargado.Estado = ValorEstadoParaCartaPorte(doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Usuario_fact_elect?.Sat_Municipio?.Clave_estado);
            cartaporteTransptipofiguraEncargado.Pais = "MEX";
            cartaporteTransptipofiguraEncargado.Codigopostal = doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Domicilio?.Codigopostal;



            CartaporteTransptipofiguraBindingModel cartaporteTransptipofiguraDuenio = new CartaporteTransptipofiguraBindingModel();
            cartaporteTransptipofiguraDuenio.Tipofigura = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Usuario_Personafigura?.Sat_Figuratransporte?.Clave;
            cartaporteTransptipofiguraDuenio.Rfcfigura = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Rfc;
            cartaporteTransptipofiguraDuenio.Numlicencia = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Usuario_Personafigura?.Numlicencia;
            cartaporteTransptipofiguraDuenio.Nombrefigura = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Nombre;
            cartaporteTransptipofiguraDuenio.Numregidtribfigura =  cartaporteTransptipofiguraDuenio.Rfcfigura != null && cartaporteTransptipofiguraDuenio.Rfcfigura.Length > 0 ? "" :
                                                                            doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Usuario_Personafigura?.Numregidtrib;
            cartaporteTransptipofiguraDuenio.Residenciafiscalfigura = "";
            cartaporteTransptipofiguraDuenio.Partetransporte = (doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Usuario_Personafigura?.Sat_Figuratransporte?.Clave ?? "") != "01" ? (doctoInfo.Docto_guia?.Guia?.Encargadoguia?.Usuario_Personafigura?.Sat_Partetransporte?.Clave ?? "") : "";
            cartaporteTransptipofiguraDuenio.Calle = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Domicilio?.Calle;
            cartaporteTransptipofiguraDuenio.Numeroexterior = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Domicilio?.Numeroexterior;
            cartaporteTransptipofiguraDuenio.Numerointerior = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Domicilio?.Numerointerior;
            cartaporteTransptipofiguraDuenio.Colonia = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Usuario_fact_elect?.Sat_Colonia?.Clave;
            cartaporteTransptipofiguraDuenio.Localidad = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Usuario_fact_elect?.Sat_Localidad?.Clave;
            cartaporteTransptipofiguraDuenio.Referencia = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Usuario_fact_elect?.Referenciadom;
            cartaporteTransptipofiguraDuenio.Municipio = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Usuario_fact_elect?.Sat_Municipio?.Clave;
            cartaporteTransptipofiguraDuenio.Estado = ValorEstadoParaCartaPorte(doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Usuario_fact_elect?.Sat_Municipio?.Clave_estado);
            cartaporteTransptipofiguraDuenio.Pais = "MEX";
            cartaporteTransptipofiguraDuenio.Codigopostal = doctoInfo.Docto_guia?.Guia?.Vehiculo?.Duenio?.Domicilio?.Codigopostal;





            cartaporteBindingModel.TranspInternac = "No";
            cartaporteBindingModel.EntradaSalidaMerc = "";
            cartaporteBindingModel.PaisOrigenDestino = "";
            cartaporteBindingModel.ViaEntradaSalida = "";
            cartaporteBindingModel.TotalDistRec = ubicacionDestino.Distanciarecorrida;
            cartaporteBindingModel.Doctoid = doctoId;

            cartaporteBindingModel.CartaporteAutotransps = cartaporteAutotransp;
            cartaporteBindingModel.CartaporteCanttransps = cartaporteCanttransp;
            cartaporteBindingModel.CartaporteTotalmercancias = cartaporteTotalmercancias;

            cartaporteBindingModel.CartaporteMercancias = cartaporteMercancias;

            cartaporteBindingModel.CartaporteTransptipofiguras = new List<CartaporteTransptipofiguraBindingModel>();
            if (cartaporteTransptipofiguraEncargado != null)
                cartaporteBindingModel.CartaporteTransptipofiguras.Add(cartaporteTransptipofiguraEncargado);
            if (cartaporteTransptipofiguraDuenio != null)
                cartaporteBindingModel.CartaporteTransptipofiguras.Add(cartaporteTransptipofiguraDuenio);

            cartaporteBindingModel.CartaporteUbicacions = new List<CartaporteUbicacionBindingModel>() { 
                                                                    ubicacionOrigen, 
                                                                    ubicacionDestino
                                                        };


            return cartaporteBindingModel;
        }

        private string? ValorEstadoParaCartaPorte(string? valor)
        {
            if (valor != null && valor.ToUpper() == "DIF")
                return "CMX";

            return valor;
        }


    }
}
