
using BindingModels;
using Controllers.Controller;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
//--using Syncfusion.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Npgsql.PostgresTypes.PostgresCompositeType;
using KendoNET.DynamicLinq;
//--using Syncfusion.Windows.Shared;
using Castle.Core.Internal;
using IposV3.Services;

namespace Controllers.Controller
{

    public class LoteController : BaseGenericController
    {


        private OperationsContextFactory _operationsContextFactory;
        private InventarioService _inventarioService;

        public LoteController(
            InventarioService inventarioService,
            OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._inventarioService = inventarioService;
        }

        public List<V_movto_lote_seleccionWFBindingModel> MovtoLoteSeleccion(long empresaId, long sucursalId, long productoId, long almacenId, long? doctoId)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            return _inventarioService.MovtoLoteSeleccion(empresaId, sucursalId,
                                                       productoId, almacenId, doctoId, applicationDbContext)
               .Select(m => { return (V_movto_lote_seleccionWFBindingModel)V_movto_lote_seleccionWFBindingModel.CreateFromAnonymous(m); }).ToList();

        }

        public List<V_movto_loteimpo_selWFBindingModel> MovtoLoteImportadoSeleccion(long empresaId, long sucursalId, long productoId, long almacenId, long? doctoId)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            return _inventarioService.MovtoLoteImportadoSeleccion(empresaId, sucursalId,
                                                       productoId, almacenId, doctoId, applicationDbContext)
               .Select(m => { return (V_movto_loteimpo_selWFBindingModel)V_movto_loteimpo_selWFBindingModel.CreateFromAnonymous(m); }).ToList();

        }

    }
}
