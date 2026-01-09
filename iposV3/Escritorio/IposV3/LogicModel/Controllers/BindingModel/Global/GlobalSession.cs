using BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IposV3.Model;

#if PROYECTO_WEB
using Microsoft.EntityFrameworkCore;
#endif


namespace IposV3.BindingModel
{
    public class GlobalSession
    {
          
        public  EmpresaBindingModel? CurrentEmpresa { get; set; }
        public  SucursalBindingModel? CurrentSucursal { get; set; }
        public  ParametroBindingModel? CurrentParametro { get; set; }
        public  UsuarioBindingModel? CurrentUsuario { get; set; }
        public Sucursal_infoBindingModel? CurrentSucursalInfo { get; set; }

        public  CajaBindingModel? CurrentCaja { get; set; }

        public Configuracion? CurrentConfiguracion { get; set; }

        public List<LookupBindingModel>? CurrentLookups { get; set; }

        //public Configuracionsync CurrentConfiguracionsync { get; set; }



        public List<ProductoAutocompleteBindingModel>? ListadoAutoCompleteProd { get; set; }

        public List<ClienteAutocompleteBindingModel>? ListadoAutoCompleteCliente { get; set; }

        public long? Empresaid { 
            get {
                    return (CurrentEmpresa != null && CurrentEmpresa?.Id != null) ? CurrentEmpresa.Id : null;
                } 
        }

        public long? Sucursalid
        {
            get
            {
                return (CurrentSucursal != null && CurrentSucursal?.Id != null) ? CurrentSucursal.Id : null;
            }
        }



        public long? Usuarioid
        {
            get
            {
                return (CurrentUsuario != null && CurrentUsuario?.Id != null) ? CurrentUsuario.Id : null;
            }
        }


        #if PROYECTO_WEB
        //public  List<V_producto_autocomplete_compact> ListadoAutoCompleteProd { get; set; }

        public void FillBasicConfiguration(ApplicationDbContext context, long? empresaId, long? sucursalId, long? usuarioId, long? cajaId)
        {
            if (empresaId != null)
            {
                var dbEmpresa = context.Empresa.Where(y => y.Id == empresaId!.Value).FirstOrDefault();
                CurrentEmpresa = dbEmpresa != null ? new EmpresaBindingModel( dbEmpresa ) : null;

                if (sucursalId != null)
                {
                    var dbSucursal = context.Sucursal.AsNoTracking().Where(y => y.Id == sucursalId!.Value).FirstOrDefault();
                    CurrentSucursal = dbSucursal != null ? new SucursalBindingModel(dbSucursal) : null;

                    var dbParametro = context.Parametro.Include(c => c.Lista_precio_def)
                                              .Include(c => c.Listaprecioinimayo_)
                                              .Include(c => c.Tipodescuentoprod)
                                              .Include(c => c.Agrupacionventa)
                                              .Include(c => c.Precioajustedifinv)
                                              .Include(c => c.Encargado)
                                              .Include(c => c.Listaprecioxuempaque_)
                                              .Include(c => c.Listaprecioxpzacaja_)
                                              .Include(c => c.Tipoutilidad)
                                              .Include(c => c.Listapreciominimo_)
                                              .Include(c => c.Almacenrecepcion)
                                              .Include(c => c.Campoimpocostorepo)
                                              .Include(c => c.Clienteconsolidado)
                                              .Include(c => c.Sat_metodopago)
                                              .Include(c => c.Sat_regimenfiscal)
                                              .Include(c => c.Monederolistaprecio)
                                              .Include(c => c.Vendedormovil)
                                              .Include(c => c.Emidarecargalinea)
                                              .Include(c => c.Emidarecargamarca)
                                              .Include(c => c.Emidarecargaproveedor)
                                              .Include(c => c.Emidaserviciolinea)
                                              .Include(c => c.Emidaserviciomarca)
                                              .Include(c => c.Emidaservicioproveedor)
                                              .Include(c => c.Ultmensaje)
                                              .Include(c => c.Listapreciomaylinea_)
                                              .Include(c => c.Listapremedmaylinea_)
                                              .AsNoTracking()
                                              .FirstOrDefault(p => p.EmpresaId == empresaId!.Value && p.SucursalId == sucursalId!.Value);
                    CurrentParametro = dbParametro != null ? new ParametroBindingModel(dbParametro) : null;

                    var dbSucursalInfo = context.Sucursal_info
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Gruposucursal)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Cliente)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Proveedor)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Banco)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(d => d.Empprov)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entregaestado)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entrega_Sat_Colonia)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entrega_Sat_Localidad)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_fact_elect).ThenInclude(d => d.Entrega_Sat_Municipio)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_importacion).ThenInclude(d => d.Listaprecio)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_importacion).ThenInclude(d => d.Surtidor)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_respaldo)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_traslado).ThenInclude(d => d.Preciorecepciontraslado_)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_traslado).ThenInclude(d => d.Precioenviotraslado_)
                                              .Include(c => c.Sucursal_info_opciones).ThenInclude(s => s.Sucursal_traslado).ThenInclude(d => d.Lista_precio_traspaso_)
                                              .AsNoTracking()
                                              .Where(p => p.EmpresaId == empresaId!.Value && p.SucursalId == sucursalId!.Value &&
                                                                                                        p.Clave == CurrentSucursal!.Clave).FirstOrDefault();
                    CurrentSucursalInfo = dbSucursalInfo != null ? new Sucursal_infoBindingModel(dbSucursalInfo) : null;

                    if (usuarioId != null)
                    {
                        var dbUsuario = context.Usuario
                            .Include(c => c.Saludo)
                            .Include(c => c.Domicilio)
                            .Include(c => c.Contacto1)
                            .Include(c => c.Contacto1).ThenInclude(s => s.Domicilio)
                            .Include(c => c.Contacto2)
                            .Include(c => c.Contacto2).ThenInclude(s => s.Domicilio)
                            .Include(c => c.Usuario_Preferencias).ThenInclude(d => d.Grupousuario)
                            .Include(c => c.Usuario_Preferencias).ThenInclude(d => d.Almacen)
                            .Include(c => c.Usuario_Preferencias).ThenInclude(d => d.Listaprecio)
                            .Include(c => c.Usuario_Personafigura)
                            .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Estado)
                            .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Sat_pais)
                            .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Sat_Colonia)
                            .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Sat_Localidad)
                            .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Sat_Municipio)
                            .Include(c => c.Usuario_Personafigura).ThenInclude(f => f.Sat_Figuratransporte)
                            .Include(c => c.Usuario_Personafigura).ThenInclude(f => f.Sat_Partetransporte)
                            .Include(c => c.Usuario_emida)
                            .AsNoTracking()
                            .Where(y => y.EmpresaId == empresaId!.Value && y.SucursalId == sucursalId!.Value && y.Id == usuarioId!.Value).FirstOrDefault();
                                    CurrentUsuario = dbUsuario != null ? new UsuarioBindingModel(dbUsuario) : null;
                    }
                        


                    if (cajaId != null)
                    {
                        var dbCaja = context.Caja
                                              .Include(c => c.Caja_bancomer)
                                              .Include(c => c.Caja_emida).ThenInclude(d => d.Terminal)
                                              .Include(c => c.Caja_emida).ThenInclude(d => d.Terminalservicios)
                                              .AsNoTracking()
                                              .Where(y => y.EmpresaId == empresaId!.Value && y.SucursalId == sucursalId!.Value && y.Id == cajaId!.Value).FirstOrDefault();
                        CurrentCaja = dbCaja != null ? new CajaBindingModel(dbCaja) : null;

                    }

                    CurrentLookups = context.Lookup.AsNoTracking().Where(y => y.EmpresaId == empresaId!.Value && y.SucursalId == sucursalId!.Value).Select(m => new LookupBindingModel(m)).ToList();

                }
            }

        }

        public void FillUsuarioConfiguration(ApplicationDbContext context, long? empresaId, long? sucursalId, long? usuarioId)
        {

            if (usuarioId != null)
            {
                var dbUsuario = context.Usuario
                            .Include(c => c.Saludo)
                            .Include(c => c.Domicilio)
                            .Include(c => c.Contacto1)
                            .Include(c => c.Contacto1).ThenInclude(s => s.Domicilio)
                            .Include(c => c.Contacto2)
                            .Include(c => c.Contacto2).ThenInclude(s => s.Domicilio)
                            .Include(c => c.Usuario_Preferencias).ThenInclude(d => d.Grupousuario)
                            .Include(c => c.Usuario_Preferencias).ThenInclude(d => d.Almacen)
                            .Include(c => c.Usuario_Preferencias).ThenInclude(d => d.Listaprecio)
                            .Include(c => c.Usuario_Personafigura)
                            .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Estado)
                            .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Sat_pais)
                            .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Sat_Colonia)
                            .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Sat_Localidad)
                            .Include(c => c.Usuario_fact_elect).ThenInclude(f => f.Sat_Municipio)
                            .Include(c => c.Usuario_Personafigura).ThenInclude(f => f.Sat_Figuratransporte)
                            .Include(c => c.Usuario_Personafigura).ThenInclude(f => f.Sat_Partetransporte)
                            .Include(c => c.Usuario_emida)
                            .AsNoTracking().Where(y => y.EmpresaId == empresaId!.Value && y.SucursalId == sucursalId!.Value && y.Id == usuarioId!.Value).FirstOrDefault();
                CurrentUsuario = dbUsuario != null ? new UsuarioBindingModel(dbUsuario) : null;
            }

        }
        #endif

            


    }
}
