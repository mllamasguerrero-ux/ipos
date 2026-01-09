using BindingModels;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using Models.CatalogSelector;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Windows.Forms.DataFormats;

namespace IposV3.Controllers.Controller.Utils
{
    public class CatalogSelector
    {
        private IDbContextFactory<ApplicationDbContext> _operationsContextFactory;
        public CatalogSelector(IDbContextFactory<ApplicationDbContext> operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }


        public Tuple<string, List<DbParameter>> SelectListQuery<T>(string baseQuery, BaseParam? param, KendoParams? kendoParams)
        {

            List<BaseSelector> listToReturn = new List<BaseSelector>();



            try
            {
                List<DbParameter> parameterList = new List<DbParameter>();

                if (param != null)
                {
                    parameterList.Add(new NpgsqlParameter($"@1", param.P_empresaid));
                    parameterList.Add(new NpgsqlParameter($"@2", param.P_sucursalid));
                }

                string commandText = baseQuery;

                if (kendoParams != null)
                {
                    commandText = KendoParamDao.PrepareFilteringAndPagination<T>(kendoParams, parameterList, commandText);
                }
                return Tuple.Create(commandText, parameterList);
            }
            catch 
            {
                throw;
                //return null;
            }


        }




        public string obtainCatalogTitle(CatalogRelatedFields catalogRelated)
        {

            if (!string.IsNullOrEmpty(catalogRelated.ListTitle))
                return catalogRelated.ListTitle;

            switch (catalogRelated.CatalogName)
            {


                case "Empresa":
                    return "Empresas";

                case "Sucursal":
                    return "Sucursales";
                case "Marca":
                    return "Sucursales";

                case "Linea":
                    return "Lineas";


                case "Caja":
                    return "Cajas";

                case "Perfiles":
                    return "Perfiles";

                case "Sucursal_info":
                    return "Sucursales";

                case "Usuario":
                    return "Usuarios";

                case "Vendedor":
                    return "Vendedores";


                case "Encargadoguia":
                    return "Encargados de guia";


                case "Encargadocorte":
                    return "Encargados de corte";

                case "Gruposucursal":
                    return "Grupos sucursales";

                case "Grupousuario":
                    return "Grupos de usuario";

                case "Moneda":
                    return "Monedas";

                case "Tasaieps":
                    return "Tasas Ieps";

                case "Tasaiva":
                    return "Tasas Iva";

                case "Unidad":
                    return "Unidades";

                case "Estadopais":
                    return "Estados";

                case "Estadopaisacronimo":
                    return "Paises";

                case "Subtipocliente":
                    return "Subtipos de cliente";

                case "Tiporecarga":
                    return "Tipos de recarga";

                case "Formapagosat":
                    return "Formas de pago SAT";

                case "Sat_aduana":
                    return "Aduanas SAT";

                case "Sat_claveunidadpeso":
                    return "Unidades/Pesos SAT";

                case "Sat_colonia":
                    return "Colonias SAT";

                case "Sat_localidad":
                    return "Localidades SAT";

                case "Sat_matpeligroso":
                    return "Materiales peligrosos SAT";

                case "Sat_metodopago":
                    return "Metodos de pago SAT";

                case "Sat_municipio":
                    return "Municipios SAT";

                case "Sat_pais":
                    return "Paises SAT";

                case "Sat_productoservicio":
                    return "Productos/Servicios SAT";

                case "Sat_regimenfiscal":
                    return "Regimenes fiscales";

                case "Sat_tipoembalaje":
                    return "Tipos embalaje";

                case "Sat_unidadmedida":
                    return "Unidades de medida SAT";

                case "Sat_usocfdi":
                    return "Uso CFDI SAT";

                case "Estadocobranza":
                    return "Estaods de cobranza";

                case "Estadopagocontrarecibo":
                    return "Estados de pago de contra recibo";

                case "Cliente":
                    return "Clientes";

                case "Producto":
                    return "Productos";

                case "Proveedor":
                    return "Proveedores";

                case "Tipotransaccion":
                    return "Tipos de transaccion";

                case "Clerkpagoservicio":
                    return "Clerks de pago de servicio";

                case "Emidaproduct":
                    return "Productos Emida";

                case "Merchantpagoservicio":
                    return "Merchangs de pago de servicio";

                case "Terminalpagoservicio":
                    return "Terminales de pago de servicio";

                case "Gastoadicional":
                    return "Gastos adicionales";

                case "Estadoguia":
                    return "Estados de guia";

                case "Tipoentrega":
                    return "Tipos de entrega";


                case "Almacen":
                    return "Almacenes";

                case "Anaquel":
                    return "Anaqueles";

                case "AnaquelLibre":
                    return "Anaqueles";

                case "Grupodiferenciainventario":
                    return "Grupos de diferencia de inventario";

                case "Tipodiferenciainventario":
                    return "Tipos de diferencia de inventario";

                case "Mensajenivelurgencia":
                    return "Niveles de urgencia";

                case "Banco":
                    return "Bancos";

                case "Formapago":
                    return "Formas de pago";

                case "Motivo_camfec":
                    return "Motivo de cambio de fecha";

                case "Cuenta":
                    return "Cuentas";

                case "Cuentabanco":
                    return "Cuentas de banco";

                case "Plazo":
                    return "Plazos";

                case "Tipolineapoliza":
                    return "Tipos linea de poliza";

                case "Camporeferenciaprecio":
                    return "Campos referencia de precio";

                case "Tipodescuentoprod":
                    return "Tipos descuento";

                case "Tipoutilidad":
                    return "Tipos utilidad";

                case "Promocion":
                    return "Promociones";

                case "Rangopromocion":
                    return "Rangos de promocion";

                case "Tipopromocion":
                    return "Tipos de promocion";

                case "Clasifica":
                    return "Clasificaciones";

                case "Contenido":
                    return "Contenido";

                case "Reportes":
                    return "Reportes";

                case "Rutaembarque":
                    return "Rutas de embarque";

                case "Motivo_devolucion":
                    return "Motivos de devolucion";



                case "Origenfiscal":
                    return "Origenes fiscales";




                case "Tipoprecio":
                    return "Tipos de precio";

                case "Agrupacionventa":
                    return "Agrupaciones de venta";


                case "Saludo":
                    return "Saludos";


                case "LetraEnTicket":
                    return "Letras en ticket";

                case "FormatTicketCorto":
                    return "Formatos de ticket corto";

                case "OrdenImpresion":
                    return "Orden de impresion";

                case "FormatoFactura":
                    return "Formatos de factura";

                case "FiltroProductoSat":
                    return "Filtros de producto SAT";

                case "ModoAlertaPV":
                    return "Modos alerta PV";

                case "ConfigPantalla":
                    return "Configuraciones de pantalla";

                case "Tiposyncmovil":
                    return "Tipos sincronizacion movil";

                case "TipoConexionMovil":
                    return "Tipos conexion movil";


                case "Tipodocto_Proveeduria":
                    return "Tipos de documento de proveeduria";

                case "Estatusdocto_Proveeduria":
                    return "Estados de documentos de proveeduria";


                case "Tipodocto_Vendeduria":
                    return "Tipos de documento de proveeduria";

                case "Estatusdocto_Vendeduria":
                    return "Estados de documento de vendeduria";


                case "Tipodocto_Provdevo":
                    return "Tipos de documento de devolucion de proveeduria";

                case "Estatusdocto_Provdevo":
                    return "Estados de documento de devolucion de proveeduria";


                case "Tipodocto_Venddevo":
                    return "Tipos de documento de devolucion";

                case "Estatusdocto_Venddevo":
                    return "Estados de documento de devolucion";


                case "Tipodocto_Vend_to_devo":
                    return "Tipos de documento de venta a devolver";

                case "Estatusdocto_Vend_to_devo":
                    return "Estados de documento de venta a devolver";

                case "Tipodocto_Prov_to_devo":
                    return "Tipos de documento de compra a devolver";

                case "Estatusdocto_Prov_to_devo":
                    return "Estados de documento de compra a devolver";



                case "SatFormaPagoTarjeta":
                    return "Formas de pago tarjeta SAT";



                case "Sat_figuratransporte":
                    return "Figuras de transporte SAT";

                case "Sat_partetransporte":
                    return "Parte transporte SAT";

                case "DiasDeLaSemana":
                    return "Dias de la semana";



                case "Area":
                    return "Areas";

                case "Listaprecio":
                    return "Listas de precio";




                default:
                    return catalogRelated.CatalogName ?? "";

            }
        }

        public List<BaseSelector>? obtainCatalog(CatalogDef catalogDef, BaseParam defaultParam)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            List<BaseSelector>? lstBase = null;
            BaseParam? param = null;

            switch (catalogDef.CatalogName)
            {


                //case "Marca":
                //var auxQuery = SelectListQuery<Marca>($@"SELECT * FROM ""Marca"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ", ((BaseParam?)catalogDef.CatalogParam ?? defaultParam), catalogDef.ExtraCondition);

                //lstBase = applicationDbContext.Marca
                //    .FromSqlRaw(auxQuery.Item1, auxQuery.Item2.ToArray())
                //    .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                //    .ToList();

                //break;

                case "Empresa":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Empresa
                            .Select(x => new BaseSelector(x.Id, 0, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Sucursal":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sucursal
                            .Where(x => x.EmpresaId == param!.P_empresaid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.Id, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Marca":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Marca
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid )
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Linea":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Linea
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;


                case "Caja":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Caja
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Perfiles":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Perfiles
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Descripcion ?? "", x.Descripcion ?? ""))
                            .ToList();

                    break;

                case "Sucursal_info":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sucursal_info
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Usuario":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Usuario
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), x.Nombre))
                            .ToList();

                    break;

                case "Vendedor":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Usuario
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid && x.Esvendedor == BoolCN.S)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), x.Nombre))
                            .ToList();

                    break;


                case "Encargadoguia":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Usuario
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid && x.Esencargadoguia == BoolCN.S)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), x.Nombre))
                            .ToList();

                    break;


                case "Encargadocorte":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Usuario
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid && x.Esencargadocorte == BoolCN.S)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), x.Nombre))
                            .ToList();

                    break;

                case "Gruposucursal":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Gruposucursal
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Grupousuario":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Grupousuario
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Moneda":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Moneda
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Tasaieps":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tasaieps
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Tasaiva":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tasaiva
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Unidad":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Unidad
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Estadopais":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Estadopais
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre, x.Acronimo, null))
                            .ToList();

                    break;

                case "Estadopaisacronimo":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Estadopais
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Acronimo, x.Nombre))
                            .ToList();

                    break;

                case "Subtipocliente":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Subtipocliente
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Tiporecarga":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tiporecarga
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Formapagosat":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Formapagosat
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Sat_aduana":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_aduana
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Sat_claveunidadpeso":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_claveunidadpeso
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Sat_colonia":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_colonia
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Sat_localidad":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_localidad
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Sat_matpeligroso":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_matpeligroso
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Sat_metodopago":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_metodopago
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Sat_municipio":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_municipio
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Sat_pais":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_pais
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Sat_productoservicio":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_productoservicio
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Sat_regimenfiscal":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_regimenfiscal
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Sat_tipoembalaje":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_tipoembalaje
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Sat_unidadmedida":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_unidadmedida
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Sat_usocfdi":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_usocfdi
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Estadocobranza":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Estadocobranza
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Estadopagocontrarecibo":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Estadopagocontrarecibo
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Cliente":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Cliente
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Producto":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Producto
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Proveedor":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Proveedor
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Tipotransaccion":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipotransaccion
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Clerkpagoservicio":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Clerkpagoservicio
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clerkid ?? "", x.Clerkid ?? ""))
                            .ToList();

                    break;

                case "Emidaproduct":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Emidaproduct
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Merchantpagoservicio":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Merchantpagoservicio
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Merchantid ?? ""), (x.Merchantid ?? "")))
                            .ToList();

                    break;

                case "Terminalpagoservicio":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Terminalpagoservicio
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Gastoadicional":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Gastoadicional
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Estadoguia":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Estadoguia
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Tipoentrega":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipoentrega
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;




                case "Almacen":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Almacen
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Anaquel":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Anaquel
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "AnaquelLibre":
                    {
                        param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);

                        string? almacenStrId = catalogDef.ExtraCondition?.Filter?.Filters?.FirstOrDefault()?.Value;
                        long? almacenId = almacenStrId != null ? long.Parse(almacenStrId!) : null;


                        lstBase = applicationDbContext.Anaquel
                                .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid &&
                                            (almacenId == null || (x.Almacenid ?? 1) == almacenId))
                                .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                                .ToList();

                        if (lstBase == null)
                            lstBase = new List<BaseSelector>();

                        BaseSelector libre = new BaseSelector();
                        libre.Id = -2;
                        libre.Clave = "libre";
                        libre.Nombre = "libre";
                        lstBase.Insert(0, libre);


                        BaseSelector todosAnaquel = new BaseSelector();
                        todosAnaquel.Id = 0;
                        todosAnaquel.Clave = "";
                        todosAnaquel.Nombre = "";

                        lstBase.Insert(0, todosAnaquel);
                        break;
                    }

                case "Grupodiferenciainventario":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Grupodiferenciainventario
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Tipodiferenciainventario":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipodiferenciainventario
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Mensajenivelurgencia":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Mensajenivelurgencia
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Banco":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Banco
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Formapago":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Formapago
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Motivo_camfec":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Motivo_camfec
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Cuenta":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Cuenta
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Descripcion ?? "")))
                            .ToList();

                    break;

                case "Cuentabanco":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Cuentabanco
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Plazo":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Plazo
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Tipolineapoliza":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipolineapoliza
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Camporeferenciaprecio":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Camporeferenciaprecio
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Tipodescuentoprod":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipodescuentoprod
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Tipoutilidad":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipoutilidad
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Promocion":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Promocion
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Rangopromocion":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Rangopromocion
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Tipopromocion":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipopromocion
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Clasifica":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Clasifica
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Contenido":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Contenido
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Reportes":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Reportes
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Nombre ?? ""), (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Rutaembarque":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Rutaembarque
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Motivo_devolucion":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Motivo_devolucion
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;



                case "Origenfiscal":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Origenfiscal
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;




                case "Tipoprecio":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipoprecio
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();
                    break;


                case "Agrupacionventa":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Agrupacionventa
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();
                    break;


                case "Saludo":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Saludo
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();
                    break;


                case "LetraEnTicket":
                    lstBase = this.LetraEnTicket_Catalog();
                    break;

                case "FormatTicketCorto":

                    lstBase = FormatTicketCorto_Catalog();
                    break;

                case "OrdenImpresion":

                    lstBase = OrdenImpresion_Catalog();
                    break;

                case "FormatoFactura":
                    lstBase = FormatoFactura_Catalog();
                    break;

                case "FiltroProductoSat":
                    lstBase = FiltroProductoSat_Catalog();
                    break;

                case "ModoAlertaPV":
                    lstBase = ModoAlertaPV_Catalog();
                    break;

                case "ConfigPantalla":
                    lstBase = ConfigPantalla_Catalog();
                    break;

                case "Tiposyncmovil":
                    lstBase = TipoSyncMovil_Catalog();
                    break;

                case "TipoConexionMovil":
                    lstBase = TipoConexionMovil_Catalog();
                    break;



                case "Tipodocto_Proveeduria":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipodocto
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Estatusdocto_Proveeduria":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Estatusdocto
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;


                case "Tipodocto_Vendeduria":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipodocto
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Estatusdocto_Vendeduria":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Estatusdocto
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;


                case "Tipodocto_Provdevo":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipodocto
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Estatusdocto_Provdevo":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Estatusdocto
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;


                case "Tipodocto_Venddevo":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipodocto
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Estatusdocto_Venddevo":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Estatusdocto
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;


                case "Tipodocto_Vend_to_devo":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipodocto
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Estatusdocto_Vend_to_devo":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Estatusdocto
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Tipodocto_Prov_to_devo":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Tipodocto
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;

                case "Estatusdocto_Prov_to_devo":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Estatusdocto
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;



                case "SatFormaPagoTarjeta":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Formapagosat
                            .Where(x => x.Nombre.Contains("Tarjeta"))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .ToList();

                    break;



                case "Sat_figuratransporte":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_figuratransporte
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "Sat_partetransporte":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Sat_partetransporte
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, (x.Nombre ?? "")))
                            .ToList();

                    break;

                case "DiasDeLaSemana":
                    lstBase = DiasDeLaSemana();
                    break;


                case "Meses":
                    lstBase = Meses();
                    break;



                case "Area":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Area
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombrearea))
                            .ToList();

                    break;

                case "Listaprecio":
                    param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    lstBase = applicationDbContext.Listaprecio
                            .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .ToList();

                    break;


                case "ProductolocationsLibre":
                    {


                        param = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);

                        string? anaquelStrId = catalogDef.ExtraCondition?.Filter?.Filters?.FirstOrDefault()?.Value;
                        long? anaquelId = anaquelStrId != null ? long.Parse(anaquelStrId!) : null;


                        lstBase = applicationDbContext.Productolocations
                                .Where(x => x.EmpresaId == param!.P_empresaid && x.SucursalId == param!.P_sucursalid &&
                                            (anaquelId == null || x.Anaquelid == anaquelId))
                                .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Localidad ?? ""), (x.Localidad ?? "")))
                                .ToList();

                        if (lstBase == null)
                            lstBase = new List<BaseSelector>();

                        BaseSelector libreProductoLocations = new BaseSelector();
                        libreProductoLocations.Id = -2;
                        libreProductoLocations.Clave = "libre";
                        libreProductoLocations.Nombre = "libre";

                        lstBase.Insert(0, libreProductoLocations);
                        break;
                    }


                default:
                    break;

            }
            return lstBase;
        }
        public Dictionary<string, List<BaseSelector>?> obtainCatalogs(List<CatalogDef> catalogDefinitions, BaseParam defaultParam)
        {

            Dictionary<string, List<BaseSelector>> lst = new Dictionary<string, List<BaseSelector>>();
            foreach (var catalogDef in catalogDefinitions)
            {
                List<BaseSelector>? lstBase = obtainCatalog(catalogDef, defaultParam);



                if (lstBase != null)
                {
                    string? catalogKey = catalogDef.CatalogKey != null ? catalogDef.CatalogKey : catalogDef.CatalogName;
                    if (catalogKey != null)
                        lst.Add(catalogKey, lstBase);
                }

            }

            return lst!;
        }

        public BaseSelector? obtainItemByClave(CatalogDef catalogDef, string clave, BaseParam defaultParam)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();


            BaseSelector? ret = null;
            if (clave == null || clave.Trim().Length == 0)
                return ret;

            BaseParam? auxParam;

            var claveToLower = clave.ToLower();

            switch (catalogDef.CatalogName)
            {


                case "Empresa":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Empresa
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.Id, 0, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;

                case "Sucursal":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sucursal
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.Id, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;

                case "Marca":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Marca
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Linea":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Linea
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;




                case "Caja":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Caja
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Perfiles":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Perfiles
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Descripcion ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Descripcion ?? ""), (x.Descripcion ?? "")))
                            .FirstOrDefault();
                    break;


                case "Sucursal_info":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sucursal_info
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Usuario":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Usuario
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.UsuarioNombre ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Nombre ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;

                case "Vendedor":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Usuario
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.UsuarioNombre ?? "").ToLower() == claveToLower && x.Esvendedor == BoolCN.S))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Nombre ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;

                case "Encargadoguia":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Usuario
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.UsuarioNombre ?? "").ToLower() == claveToLower && x.Esencargadoguia == BoolCN.S))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Nombre ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;

                case "Encargadorcorte":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Usuario
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.UsuarioNombre ?? "").ToLower() == claveToLower && x.Esencargadocorte == BoolCN.S))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Nombre ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Gruposucursal":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Gruposucursal
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Grupousuario":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Grupousuario
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Moneda":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Moneda
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tasaieps":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Tasaieps
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tasaiva":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Tasaiva
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Unidad":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Unidad
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Estadopais":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Estadopais
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Subtipocliente":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Subtipocliente
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tiporecarga":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Tiporecarga
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Formapagosat":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Formapagosat
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_aduana":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sat_aduana
                            .Where(x =>  (x.Sat_claveaduana != null && x.Sat_claveaduana.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_claveunidadpeso":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sat_claveunidadpeso
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Sat_colonia":
                    {
                        auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);

                        var bufferClaveSplit = claveToLower.Split('-');
                        var colonia = bufferClaveSplit[0];
                        var codigoPostal = bufferClaveSplit.Length > 1 ? bufferClaveSplit[1] : "";

                        ret = applicationDbContext.Sat_colonia
                                .Where(x => (x.Colonia != null && x.Colonia.ToLower() == colonia &&
                                              x.Codigopostal != null && x.Codigopostal.ToLower() == codigoPostal))
                                .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, (x.Nombre ?? "")))
                                .FirstOrDefault();
                    }
                    break;


                case "Sat_localidad":
                    {
                        auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);

                        var bufferClaveSplit = claveToLower.Split('-');
                        var claveLocalidad = bufferClaveSplit[0];
                        var claveEstado = bufferClaveSplit.Length > 1 ? bufferClaveSplit[1] : "";


                        ret = applicationDbContext.Sat_localidad
                                .Where(x => (x.Clave_localidad != null && x.Clave_localidad.ToLower() == claveLocalidad &&
                                              x.Clave_estado != null && x.Clave_estado.ToLower() == claveEstado))
                                .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                                .FirstOrDefault();
                    }
                    break;


                case "Sat_matpeligroso":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sat_matpeligroso
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_metodopago":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sat_metodopago
                            .Where(x =>  (x.Sat_clave != null && x.Sat_clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_municipio":
                    {
                        auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);


                        var bufferClaveSplit = claveToLower.Split('-');
                        var claveMunicipio = bufferClaveSplit[0];
                        var claveEstado = bufferClaveSplit.Length > 1 ? bufferClaveSplit[1] : "";

                        ret = applicationDbContext.Sat_municipio
                                .Where(x => (x.Clave_municipio != null && x.Clave_municipio.ToLower() == claveMunicipio &&
                                              x.Clave_estado != null && x.Clave_estado.ToLower() == claveEstado))
                                .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                                .FirstOrDefault();
                    }
                    break;


                case "Sat_pais":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sat_pais
                            .Where(x =>  (x.Sat_clave != null && x.Sat_clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_productoservicio":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sat_productoservicio
                            .Where(x =>  (x.Sat_claveprodserv != null && x.Sat_claveprodserv!.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_regimenfiscal":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sat_regimenfiscal
                            .Where(x =>  (x.Sat_clave != null && x.Sat_clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_tipoembalaje":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sat_tipoembalaje
                            .Where(x =>  (x.Clave != null && x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_unidadmedida":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sat_unidadmedida
                            .Where(x =>  (x.Sat_clave != null && x.Sat_clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;



                case "Sat_configautotransporte":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sat_configautotransporte
                            .Where(x => (x.Clave != null && x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;



                case "Sat_subtiporem":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sat_subtiporem
                            .Where(x => (x.Clave != null && x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_tipopermiso":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sat_tipopermiso
                            .Where(x => (x.Clave != null && x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;

                case "Sat_usocfdi":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Sat_usocfdi
                            .Where(x =>  (x.Sat_clave != null && x.Sat_clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Estadocobranza":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Estadocobranza
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Estadopagocontrarecibo":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Estadopagocontrarecibo
                            .Where(x => (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Cliente":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Cliente
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Producto":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Producto
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Proveedor":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Proveedor
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tipotransaccion":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Tipotransaccion
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Clerkpagoservicio":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Clerkpagoservicio
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Clerkid ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clerkid ?? ""), (x.Clerkid ?? "")))
                            .FirstOrDefault();
                    break;


                case "Emidaproduct":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Emidaproduct
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Merchantpagoservicio":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Merchantpagoservicio
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Merchantid ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Merchantid ?? ""), (x.Merchantid ?? "")))
                            .FirstOrDefault();
                    break;


                case "Terminalpagoservicio":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Terminalpagoservicio
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Terminal ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Gastoadicional":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Gastoadicional
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Clave ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Estadoguia":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Estadoguia
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tipoentrega":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Tipoentrega
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Almacen":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Almacen
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Clave ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Anaquel":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Anaquel
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Clave ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Grupodiferenciainventario":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Grupodiferenciainventario
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tipodiferenciainventario":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Tipodiferenciainventario
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Mensajenivelurgencia":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Mensajenivelurgencia
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Banco":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Banco
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Clave ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Formapago":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Formapago
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Motivo_camfec":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Motivo_camfec
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Cuenta":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Cuenta
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Clave ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Descripcion ?? "")))
                            .FirstOrDefault();
                    break;


                case "Cuentabanco":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Cuentabanco
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Clave ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Plazo":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Plazo
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Clave ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Tipolineapoliza":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Tipolineapoliza
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Camporeferenciaprecio":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Camporeferenciaprecio
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tipodescuentoprod":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Tipodescuentoprod
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tipoutilidad":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Tipoutilidad
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Promocion":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Promocion
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Clave ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Rangopromocion":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Rangopromocion
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tipopromocion":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Tipopromocion
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Clasifica":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Clasifica
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Clave ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Contenido":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Contenido
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Clave ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Reportes":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Reportes
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Nombre ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Nombre ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Rutaembarque":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Rutaembarque
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && ((x.Clave ?? "").ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Motivo_devolucion":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Motivo_devolucion
                            .Where(x =>  (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;



                case "Origenfiscal":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Origenfiscal
                            .Where(x => (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tipoprecio":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Tipoprecio
                            .Where(x => (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Agrupacionventa":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Agrupacionventa
                            .Where(x => (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;

                case "Saludo":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Saludo
                            .Where(x => (x.Clave.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Vehiculo":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Vehiculo
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Numpermisosct!.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;



                case "LetraEnTicket":
                    ret = LetraEnTicket_Catalog().Where(h => (h.Clave ?? "").ToLower() == claveToLower).FirstOrDefault();
                    break;

                case "FormatTicketCorto":

                    ret = FormatTicketCorto_Catalog().Where(h => (h.Clave ?? "").ToLower() == claveToLower).FirstOrDefault();
                    break;

                case "OrdenImpresion":

                    ret = OrdenImpresion_Catalog().Where(h => (h.Clave ?? "").ToLower() == claveToLower).FirstOrDefault();
                    break;

                case "FormatoFactura":
                    ret = FormatoFactura_Catalog().Where(h => (h.Clave ?? "").ToLower() == claveToLower).FirstOrDefault();
                    break;

                case "FiltroProductoSat":
                    ret = FiltroProductoSat_Catalog().Where(h => (h.Clave ?? "").ToLower() == claveToLower).FirstOrDefault();
                    break;

                case "ModoAlertaPV":
                    ret = ModoAlertaPV_Catalog().Where(h => (h.Clave ?? "").ToLower() == claveToLower).FirstOrDefault();
                    break;

                case "ConfigPantalla":
                    ret = ConfigPantalla_Catalog().Where(h => (h.Clave ?? "").ToLower() == claveToLower).FirstOrDefault();
                    break;

                case "Tiposyncmovil":
                    ret = TipoSyncMovil_Catalog().Where(h => (h.Clave ?? "").ToLower() == claveToLower).FirstOrDefault();
                    break;

                case "TipoConexionMovil":
                    ret = TipoConexionMovil_Catalog().Where(h => (h.Clave ?? "").ToLower() == claveToLower).FirstOrDefault();
                    break;



                case "Area":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Area
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Clave!.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombrearea))
                            .FirstOrDefault();
                    break;


                case "Listaprecio":
                    auxParam = ((BaseParam?)catalogDef.CatalogParam ?? defaultParam);
                    ret = applicationDbContext.Listaprecio
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Clave!.ToLower() == claveToLower))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;




                default:
                    break;

            }

            return ret;
        }

        public BaseSelector? obtainItemById(CatalogDef catalogDef, long itemId, BaseParam defaultParam)
        {
            using var applicationDbContext = this._operationsContextFactory.CreateDbContext();

            BaseSelector? ret = null;
            BaseParam? auxParam;

            if (catalogDef.CatalogName == null)
                return null;


            List<string> listCatalogsWithZeroValidVal = new List<string>() { "Estatusdocto" };
            if (itemId == 0 && !listCatalogsWithZeroValidVal.Contains(catalogDef.CatalogName))
                return ret;


            switch (catalogDef.CatalogName)
            {

                case "Empresa":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Empresa
                            .Where(x => (x.Id == itemId))
                            .Select(x => new BaseSelector(x.Id, 0, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;

                case "Sucursal":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    auxParam = auxParam == null ? defaultParam : auxParam;
                    ret = applicationDbContext.Sucursal
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.Id, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;

                case "Marca":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Marca
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;

                case "Linea":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Linea
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;




                case "Caja":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    auxParam = auxParam == null ? defaultParam : auxParam;
                    ret = applicationDbContext.Caja
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Perfiles":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Perfiles
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Descripcion ?? ""), (x.Descripcion ?? "")))
                            .FirstOrDefault();
                    break;


                case "Sucursal_info":
                    auxParam = (BaseParam?)catalogDef.CatalogParam ?? defaultParam;
                    ret = applicationDbContext.Sucursal_info
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Usuario":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    auxParam = auxParam == null ? defaultParam : auxParam;
                    ret = applicationDbContext.Usuario
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), x.Nombre))
                            .FirstOrDefault();
                    break;



                case "Vendedor":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Usuario
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId) && x.Esvendedor == BoolCN.S)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Encargadoguia":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Usuario
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId) && x.Esencargadoguia == BoolCN.S)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Encargadocorte":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Usuario
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId) && x.Esencargadocorte == BoolCN.S)
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Gruposucursal":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Gruposucursal
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Grupousuario":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Grupousuario
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Moneda":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Moneda
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tasaieps":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Tasaieps
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tasaiva":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Tasaiva
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Unidad":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Unidad
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Estadopais":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Estadopais
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Subtipocliente":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Subtipocliente
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tiporecarga":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Tiporecarga
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Formapagosat":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Formapagosat
                            .Where(x => (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_aduana":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Sat_aduana
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_claveunidadpeso":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Sat_claveunidadpeso
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Sat_colonia":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Sat_colonia
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Sat_localidad":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Sat_localidad
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_matpeligroso":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Sat_matpeligroso
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_metodopago":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Sat_metodopago
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_municipio":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Sat_municipio
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_pais":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Sat_pais
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_productoservicio":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Sat_productoservicio
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_regimenfiscal":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Sat_regimenfiscal
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_tipoembalaje":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Sat_tipoembalaje
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_unidadmedida":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Sat_unidadmedida
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Sat_usocfdi":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Sat_usocfdi
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Estadocobranza":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Estadocobranza
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Estadopagocontrarecibo":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Estadopagocontrarecibo
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Cliente":
                    if (catalogDef.CatalogParam != null)
                        auxParam = (BaseParam?)catalogDef.CatalogParam;
                    else
                        auxParam = defaultParam;
                    ret = applicationDbContext.Cliente
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Producto":
                    if (catalogDef.CatalogParam != null)
                        auxParam = (BaseParam?)catalogDef.CatalogParam;
                    else
                        auxParam = defaultParam;

                    ret = applicationDbContext.Producto
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Proveedor":
                    if (catalogDef.CatalogParam != null)
                        auxParam = (BaseParam?)catalogDef.CatalogParam;
                    else
                        auxParam = defaultParam;

                    ret = applicationDbContext.Proveedor
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tipotransaccion":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Tipotransaccion
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Clerkpagoservicio":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Clerkpagoservicio
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clerkid ?? ""), (x.Clerkid ?? "")))
                            .FirstOrDefault();
                    break;


                case "Emidaproduct":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Emidaproduct
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Merchantpagoservicio":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Merchantpagoservicio
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Merchantid ?? ""), (x.Merchantid ?? "")))
                            .FirstOrDefault();
                    break;


                case "Terminalpagoservicio":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Terminalpagoservicio
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Gastoadicional":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Gastoadicional
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Estadoguia":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Estadoguia
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tipoentrega":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Tipoentrega
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Almacen":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Almacen
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Anaquel":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Anaquel
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Grupodiferenciainventario":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Grupodiferenciainventario
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tipodiferenciainventario":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Tipodiferenciainventario
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Mensajenivelurgencia":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Mensajenivelurgencia
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Banco":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Banco
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Formapago":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Formapago
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Motivo_camfec":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Motivo_camfec
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Cuenta":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Cuenta
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Descripcion ?? "")))
                            .FirstOrDefault();
                    break;


                case "Cuentabanco":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Cuentabanco
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Plazo":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Plazo
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Tipolineapoliza":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Tipolineapoliza
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Camporeferenciaprecio":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Camporeferenciaprecio
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tipodescuentoprod":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Tipodescuentoprod
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tipoutilidad":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Tipoutilidad
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Promocion":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Promocion
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Rangopromocion":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Rangopromocion
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Tipopromocion":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Tipopromocion
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Clasifica":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Clasifica
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Contenido":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Contenido
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Reportes":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Reportes
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Nombre ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Rutaembarque":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Rutaembarque
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, (x.Clave ?? ""), (x.Nombre ?? "")))
                            .FirstOrDefault();
                    break;


                case "Motivo_devolucion":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Motivo_devolucion
                            .Where(x =>  (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;


                case "Origenfiscal":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Origenfiscal
                            .Where(x => (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;

                case "Tipoprecio":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Tipoprecio
                            .Where(x => (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;

                case "Agrupacionventa":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Agrupacionventa
                            .Where(x => (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;

                case "Saludo":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Saludo
                            .Where(x => (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;



                case "LetraEnTicket":
                    ret = LetraEnTicket_Catalog().Where(h => h.Id == itemId).FirstOrDefault();
                    break;

                case "FormatTicketCorto":

                    ret = FormatTicketCorto_Catalog().Where(h => h.Id == itemId).FirstOrDefault();
                    break;

                case "OrdenImpresion":

                    ret = OrdenImpresion_Catalog().Where(h => h.Id == itemId).FirstOrDefault();
                    break;

                case "FormatoFactura":
                    ret = FormatoFactura_Catalog().Where(h => h.Id == itemId).FirstOrDefault();
                    break;

                case "FiltroProductoSat":
                    ret = FiltroProductoSat_Catalog().Where(h => h.Id == itemId).FirstOrDefault();
                    break;

                case "ModoAlertaPV":
                    ret = ModoAlertaPV_Catalog().Where(h => h.Id == itemId).FirstOrDefault();
                    break;

                case "ConfigPantalla":
                    ret = ConfigPantalla_Catalog().Where(h => h.Id == itemId).FirstOrDefault();
                    break;

                case "Tiposyncmovil":
                    ret = TipoSyncMovil_Catalog().Where(h => h.Id == itemId).FirstOrDefault();
                    break;

                case "TipoConexionMovil":
                    ret = TipoConexionMovil_Catalog().Where(h => h.Id == itemId).FirstOrDefault();
                    break;





                case "Area":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Area
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombrearea))
                            .FirstOrDefault();
                    break;


                case "Listaprecio":
                    auxParam = (BaseParam?)catalogDef.CatalogParam;
                    ret = applicationDbContext.Listaprecio
                            .Where(x => x.EmpresaId == auxParam!.P_empresaid && x.SucursalId == auxParam!.P_sucursalid && (x.Id == itemId))
                            .Select(x => new BaseSelector(x.EmpresaId, x.SucursalId, x.Id, x.Clave, x.Nombre))
                            .FirstOrDefault();
                    break;



                default:
                    break;

            }

            return ret;
        }

        private List<BaseSelector> LetraEnTicket_Catalog() {
            return GenerateBaseSelectorFromStringArray(new List<string> { "Normal", "Pequenia" }, 0);
        }
            

        private List<BaseSelector> FormatTicketCorto_Catalog()
        {
            return GenerateBaseSelectorFromStringArray(new List<string> { "Normal", "Por_linea" }, 0);
        }

        private List<BaseSelector> OrdenImpresion_Catalog()
        {
            return GenerateBaseSelectorFromStringArray(new List<string> { "Normal", "Descripcion", "Descripcion1", "Descripcion2" }, 0);
        }


        private List<BaseSelector> FormatoFactura_Catalog()
        {
            return GenerateBaseSelectorFromStringArray(new List<string> { "Normal", "FastReport" }, 0);
        }



        private List<BaseSelector> FiltroProductoSat_Catalog()
        {
            return GenerateBaseSelectorFromStringArray(new List<string> { "Todos", "Parcial", "Linea" }, 0);
        }


        private List<BaseSelector> ModoAlertaPV_Catalog()
        {
            return GenerateBaseSelectorFromStringArray(new List<string> { "Ninguno_Especial", "Precio_minimo_costo" }, 0);
        }


        private List<BaseSelector> ConfigPantalla_Catalog()
        {
            return GenerateBaseSelectorFromStringArray(new List<string> { "Normal", "Movil_mediano", "Movil_10" }, 0);
        }


        private List<BaseSelector> TipoSyncMovil_Catalog()
        {
            return GenerateBaseSelectorFromStringArray(new List<string> { "WS", "FTP" }, 0);
        }


        private List<BaseSelector> TipoConexionMovil_Catalog()
        {
            return GenerateBaseSelectorFromStringArray(new List<string> { "Ninguno", "Tipo1", "Tipo2", "Tipo3", "Tipo4" }, 0);
        }


        private List<BaseSelector> DiasDeLaSemana()
        {
            return GenerateBaseSelectorFromStringArray(new List<string> { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" }, 0);
        }


        private List<BaseSelector> Meses()
        {
            return GenerateBaseSelectorFromStringArray(new List<string> { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre" }, 0);
        }




        private List<BaseSelector> GenerateBaseSelectorFromStringArray(List<string> lstString, int baseIndex)
        {
            var ret = new List<BaseSelector>();
            for(int i = baseIndex; i < lstString.Count() + baseIndex; i++)
                ret.Add( new BaseSelector(0, 0, i, lstString[i], lstString[i]));
            return ret;
        }


    }
}
