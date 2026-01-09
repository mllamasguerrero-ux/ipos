
using BindingModels;
using Controllers.Controller;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
//--using Syncfusion.Data.Extensions;
using System;
using IposV3.Extensions;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Npgsql.PostgresTypes.PostgresCompositeType;
using KendoNET.DynamicLinq;
using Castle.Core.Internal;

using IposV3.Services;

namespace Controllers.Controller
{
    public class FirebirdMigrationController
    {

        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;
        private UsuarioController _usuarioController;
        private ClienteController _clienteController;
        private ProveedorController _proveedorController;
        private ProductoController _productoController;
        private Sucursal_infoController _sucursal_infoController;
        private PromocionController _promocionController;
        private KitdefinicionController _kitdefinicionController;
        private ParametroController _parametroController;

        public FirebirdMigrationController(IDbContextFactory<ApplicationDbContext> operationsContextFactory, 
            UsuarioController usuarioController,
            ClienteController clienteController,
            ProveedorController proveedorController,
            ProductoController productoController,
            Sucursal_infoController sucursal_InfoController,
            PromocionController promocionController,
            KitdefinicionController kitdefinicionController,
            ParametroController parametroController)
        {
            this._operationsContextFactory = operationsContextFactory;
            this._usuarioController = usuarioController;
            this._clienteController = clienteController;
            this._proveedorController = proveedorController;
            this._productoController = productoController;
            this._sucursal_infoController= sucursal_InfoController;
            this._promocionController = promocionController;
            this._kitdefinicionController = kitdefinicionController;
            this._parametroController = parametroController;
        }

        public void ImportarDatosDeFirebird(bool importarCatalogos, bool importarTransacciones, 
                                            bool importartInformacionEmpresa,
                                            long empresaId, long sucursalId,
                                            string fbCadenaConexion_char850, string fbCadenaConexion_chardefault)
        {

            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();
            FirebirdMigrationHelper.ImportarDatosDeFirebird(importarCatalogos, importarTransacciones, importartInformacionEmpresa, empresaId, sucursalId, fbCadenaConexion_char850,  fbCadenaConexion_chardefault, applicationDbContext, this._usuarioController, this._clienteController, 
                                                            this._proveedorController, this._productoController, this._sucursal_infoController, this._promocionController, this._kitdefinicionController, this._parametroController);
        }
    }
}
