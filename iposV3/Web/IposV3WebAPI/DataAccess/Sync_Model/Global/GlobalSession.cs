using BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IposV3.Model;

namespace IposV3Sync.BindingModel
{
    public class GlobalSession
    {
          
        public  Empresa? CurrentEmpresa { get; set; }
        public  Sucursal? CurrentSucursal { get; set; }
        public  Parametro? CurrentParametro { get; set; }
        public  Usuario? CurrentUsuario { get; set; }
        
        public  Caja? CurrentCaja { get; set; }

        public Configuracion? CurrentConfiguracion { get; set; }

        public IposV3.Model.Syncr.Configuracionsync? CurrentConfiguracionsync { get; set; }



        //public List<ProductoAutocompleteBindingModel>? ListadoAutoCompleteProd { get; set; }

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


        //public  List<V_producto_autocomplete_compact> ListadoAutoCompleteProd { get; set; }

        public void FillBasicConfiguration(ApplicationDbContext context, long? empresaId, long? sucursalId, long? usuarioId, long? cajaId)
        {
            if (empresaId != null)
            {
                CurrentEmpresa = context.Empresa.Where(y => y.Id == empresaId!.Value).FirstOrDefault();

                if (sucursalId != null)
                {
                    CurrentSucursal = context.Sucursal.Where(y => y.Id == sucursalId!.Value).FirstOrDefault();

                    CurrentParametro = context.Parametro.FirstOrDefault(p => p.EmpresaId == empresaId!.Value && p.SucursalId == sucursalId!.Value);

                    if (usuarioId != null)
                        CurrentUsuario= context.Usuario.Where(y => y.EmpresaId == empresaId!.Value && y.SucursalId == sucursalId!.Value && y.Id == usuarioId!.Value).FirstOrDefault();


                    if (cajaId != null)
                        CurrentCaja = context.Caja.Where(y => y.EmpresaId == empresaId!.Value && y.SucursalId == sucursalId!.Value && y.Id == cajaId!.Value).FirstOrDefault();

                }
            }

        }

        public void FillUsuarioConfiguration(ApplicationDbContext context, long? empresaId, long? sucursalId, long? usuarioId)
        {

            if (usuarioId != null)
                CurrentUsuario = context.Usuario.Where(y => y.EmpresaId == empresaId!.Value && y.SucursalId == sucursalId!.Value && y.Id == usuarioId!.Value).FirstOrDefault();
        }

            


    }
}
