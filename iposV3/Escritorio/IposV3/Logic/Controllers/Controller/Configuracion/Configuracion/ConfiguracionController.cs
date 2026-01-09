
using BindingModels;
using System;
using IposV3.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using Npgsql;
using DataAccess;
using IposV3.Model;
using IposV3.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using IposV3.Migrations.Seed;
using DatabaseToolkit;

namespace Controllers.Controller
{

    public class ConfiguracionController : BaseController<ConfiguracionBindingModel>
    {
        protected ConfiguracionDao dao;

        private OperationsContextFactory _operationsContextFactory;
        public ConfiguracionController(ConfiguracionDao dao, OperationsContextFactory operationsContextFactory)
        {
            this.dao = dao;
            this._operationsContextFactory = operationsContextFactory;
        }



        public override ConfiguracionBindingModel? GetById(ConfiguracionBindingModel itemSelect)
        {

            if (itemSelect.Item == null)
                return null;

            ConfiguracionBindingModel item = new ConfiguracionBindingModel();
            item.Item = dao.Get_ById(itemSelect.Item, null);
            return item;
        }

        public override List<ConfiguracionBindingModel> GetAll()
        {
            return dao.GetAll_(null).Select(x => new ConfiguracionBindingModel(x)).ToList();

        }


        public override List<ConfiguracionBindingModel> SelectList(object? param, IposV3.Model.KendoParams? kendoParams)
        {
            return dao.SelectList(null, (ConfiguracionParam?)param, kendoParams).Select(x => new ConfiguracionBindingModel(x)).ToList();
        }



        public override bool Insert(ConfiguracionBindingModel item)
        {
            if (item.Item == null)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            return dao.Insert(item.Item, null);
        }
        public override List<ConfiguracionBindingModel> Select(string search)
        {

            return dao.Select(null, search).Select(x => new ConfiguracionBindingModel(x)).ToList();
        }
        public override List<ConfiguracionBindingModel> SelectById(ConfiguracionBindingModel itemSelect)
        {

            if (itemSelect.Item == null)
                throw new InvalidOperationException("No hay parametros correctos para hacer la seleccion");

            return dao.Select_ById(itemSelect.Item, null).Select(x => new ConfiguracionBindingModel(x)).ToList();
        }
        public override bool Update(ConfiguracionBindingModel item)
        {
            if (item.HasErrors || item.Item == null)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            return dao.Update(item.Item, null);

        }
        public override bool Delete(ConfiguracionBindingModel item)
        {
            if ( item.Item == null)
                throw new InvalidOperationException("Hay datos no validos en este registro");

            return dao.Delete(item.Item, null);
        }


        public Configuracion? GetDefaultConfiguracion()
        {
            return dao.Select(null, "").Where(y => y.Esdefault == "S").FirstOrDefault();
        }


        public EmpresaBindingModel CrearEmpresa(EmpresaBindingModel empresaInfo)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            if (empresaInfo.Clave == null || empresaInfo.Nombre == null)
            {
                throw new Exception("Se requiere clave y nombre de la empresa");
            }

            var empresa = new Empresa();
            empresa.Clave = empresaInfo.Clave ;
            empresa.Nombre= empresaInfo.Nombre ;
            empresa.Rfc = empresaInfo.Rfc;
            empresa.Telefono = empresaInfo.Telefono;
            empresa.Correoe = empresaInfo.Correoe;
            applicationDbContext.Empresa.Add(empresa);
            applicationDbContext.SaveChanges();
            empresaInfo.Id = empresa.Id;

            return empresaInfo;
        }


        public bool UpdateEmpresa(EmpresaBindingModel item)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();


            var basicQuery = applicationDbContext.Empresa
                           .Where(x => x.Id == item.Id);


            var entityItem = basicQuery.FirstOrDefault();

            if (entityItem != null)
            {
                item.FillEntityValues(ref entityItem);

                applicationDbContext.Empresa?.Update(entityItem!);
                applicationDbContext.SaveChanges();
            }

            return true;

        }

        public SucursalBindingModel CrearSucursal( SucursalBindingModel sucursalInfo)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            if (sucursalInfo.Clave == null || sucursalInfo.Nombre == null)
            {
                throw new Exception("Se requiere clave y nombre de la sucursal");
            }

            var sucursal = new Sucursal();
            sucursal.EmpresaId = sucursalInfo.EmpresaId;
            sucursal.Clave = sucursalInfo.Clave;
            sucursal.Nombre = sucursalInfo.Nombre;
            applicationDbContext.Sucursal.Add(sucursal);
            applicationDbContext.SaveChanges();
            sucursalInfo.Id = sucursal.Id;

            

            return sucursalInfo;
        }

        public void CrearUnidadesDefault(SucursalBindingModel sucursalInfo)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();
            Seed.SeedUnidad(applicationDbContext, sucursalInfo.EmpresaId, sucursalInfo.Id!.Value);
        }

        public void CrearAlmacenDefault(SucursalBindingModel sucursalInfo)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();
            var almacen = new Almacen();
            almacen.EmpresaId = sucursalInfo.EmpresaId;
            almacen.SucursalId = sucursalInfo.Id!.Value;
            almacen.Clave = "PRINCIPAL";
            almacen.Nombre = "PRINCIPAL";
            almacen.Esprincipal = BoolCS.S;

            applicationDbContext.Almacen.Add(almacen);
            applicationDbContext.SaveChanges();

        }



        public void CrearClientesDefault(SucursalBindingModel sucursalInfo)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();
            var clienteVentaMostrador = new Cliente();
            clienteVentaMostrador.EmpresaId = sucursalInfo.EmpresaId;
            clienteVentaMostrador.SucursalId = sucursalInfo.Id!.Value;
            clienteVentaMostrador.Clave = "VENTAMOSTRADOR";
            clienteVentaMostrador.Nombre = "VENTA MOSTRADOR";
            clienteVentaMostrador.Nombres = "VENTA MOSTRADOR";
            clienteVentaMostrador.Apellidos = "";
            clienteVentaMostrador.Razonsocial = "VENTA MOSTRADOR";
            clienteVentaMostrador.Rfc = "XAXX010101000";
            clienteVentaMostrador.Telefono1 = "";

            var sat_uso_cfdi = applicationDbContext.Sat_usocfdi.AsNoTracking().FirstOrDefault(s => s.Sat_clave == "G01");

            Cliente_fact_elect clienteVentaMostrador_fact_elect = new Cliente_fact_elect();
            clienteVentaMostrador_fact_elect.EmpresaId = sucursalInfo.EmpresaId;
            clienteVentaMostrador_fact_elect.SucursalId = sucursalInfo.Id!.Value;
            clienteVentaMostrador_fact_elect.Sat_usocfdiid = sat_uso_cfdi?.Id;

            clienteVentaMostrador.Cliente_fact_elect = clienteVentaMostrador_fact_elect;

            var tipo_precio = applicationDbContext.Tipoprecio.AsNoTracking().FirstOrDefault(t => t.Clave == "PRECIO 1");

            Cliente_precio clientePrecio = new Cliente_precio();
            clientePrecio.EmpresaId = sucursalInfo.EmpresaId;
            clientePrecio.SucursalId = sucursalInfo.Id!.Value;
            clientePrecio.Listaprecioid = tipo_precio?.Id;

            clienteVentaMostrador.Cliente_precio= clientePrecio;

            Cliente_pago_parametros pago_Parametros = new Cliente_pago_parametros();
            pago_Parametros.EmpresaId = sucursalInfo.EmpresaId;
            pago_Parametros.SucursalId = sucursalInfo.Id!.Value;
            pago_Parametros.Bloqueado = BoolCN.N;
            pago_Parametros.Hab_pagocheque = BoolCN.S;
            pago_Parametros.Hab_pagocredito = BoolCN.S;
            pago_Parametros.Hab_pagoefectivo = BoolCS.S;
            pago_Parametros.Hab_pagotarjeta = BoolCN.S;
            pago_Parametros.Hab_pagotransferencia = BoolCN.S;

            clienteVentaMostrador.Cliente_pago_parametros = pago_Parametros;


            //clienteVentaMostrador.Esprincipal = BoolCS.S;

            applicationDbContext.Cliente.Add(clienteVentaMostrador);
            applicationDbContext.SaveChanges();

        }

        public void CrearProveedorDefault(SucursalBindingModel sucursalInfo)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();
            Proveedor proveedor = new Proveedor();
            proveedor.EmpresaId = sucursalInfo.EmpresaId;
            proveedor.SucursalId = sucursalInfo.Id!.Value;
            proveedor.Clave = "DEFAULT";
            proveedor.Nombre = "PROVEEDOR GENERICO";
            proveedor.Nombres = "";
            proveedor.Apellidos = "";
            proveedor.Razonsocial = "VENTA MOSTRADOR";
            proveedor.Rfc = "XAXX010101000";
            proveedor.Telefono1 = "";

            applicationDbContext.Proveedor.Add(proveedor);
            applicationDbContext.SaveChanges();

        }

        public void CrearLineaDefault(SucursalBindingModel sucursalInfo)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();
            Linea linea = new Linea();
            linea.EmpresaId = sucursalInfo.EmpresaId;
            linea.SucursalId = sucursalInfo.Id!.Value;
            linea.Clave = "DEFAULT";
            linea.Nombre = "LINEA GENERICA";

            applicationDbContext.Linea.Add(linea);
            applicationDbContext.SaveChanges();

        }

        public void CrearParametroDefault(long empresaId, long sucursalId)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            var strCommand = $@"INSERT INTO public.""Parametro"" (
""EmpresaId"", ""SucursalId"", ""Imp_prod_def"", ""Estado_def"", ""Lista_precio_traspaso"", ""Promocion"", ""Cantidad"", ""Utilidad"", ""Fechaanterior"", ""Fechaactual"", ""Fechaultima"", ""Max_inv_fis_cant"", ""Inventory_email"", ""Id_dosletras"", ""Habilitar_impexp_aut"", ""Comisionmedico"", ""Comisiondependiente"", ""Ftphost"", ""Ftpusuario"", ""Ftppassword"", ""Smtphost"", ""Smtpusuario"", ""Smtppassword"", ""Smtpport"", ""Smtpmailfrom"", ""Smtpmailto"", ""Cambiarprecio"", ""Listapreciominimo"", ""Compraentienda"", ""Header"", ""Footer"", ""Hab_sel_cliente"", ""Hab_impr_cotizacion"", ""Mostrar_exis_suc"", ""Req_aprobacion_inv"", ""Reabrircortes"", ""Descuentovale"", ""Ult_fecha_imp_prod"", ""Imp_prod_total"", ""Numeroexterior"", ""Numerointerior"", ""Fiscalcalle"", ""Fiscalnumerointerior"", ""Fiscalnumeroexterior"", ""Fiscalcolonia"", ""Fiscalmunicipio"", ""Fiscalestado"", ""Fiscalcodigopostal"", ""Certificadocsd"", ""Timbradouser"", ""Timbradopassword"", ""Timbradoarchivocertificado"", ""Timbradoarchivokey"", ""Timbradokey"", ""Fiscalnombre"", ""Seriesat"", ""Usarfiscalesenexpedicion"", ""Hab_facturaelectronica"", ""Footerventaapartado"", ""Encargadoid"", ""Porc_comisionencargado"", ""Porc_comisionvendedor"", ""Ftpfolder"", ""Ftpfolderpass"", ""Seriesatdevolucion"", ""Cambiarprecioxuempaque"", ""Cambiarprecioxpzacaja"", ""Prefijobascula"", ""Longprodbascula"", ""Longpesobascula"", ""Listaprecioxuempaque"", ""Listaprecioxpzacaja"",  ""Listaprecioinimayo"", ""Hayvendedorpiso"", ""Envioautomaticoexistencias"", ""Monederomontominimo"", ""Monederoaplicar"",   ""Monederocaducidad"", ""Imprimirnumeropiezas"", ""Pacnombre"", ""Pacusuario"", ""Cortepormail"", ""Rutareportes"", ""Doblecopiacredito"",   ""Doblecopiatraslado"", ""Camposcustomalimportar"", ""Recibolargoconfactura"", ""Recibolargoprinter"", ""Recibolargopreview"", ""Preguntarrazonpreciomenor"", ""Preguntardatosentrega"", ""Fiscalregimen"", ""Cortacaducidad"", ""Retencioniva"", ""Retencionisr"", ""Arrendatario"", ""Rutaimagenesproducto"", ""Mostrarimagenenventa"", ""Mostrarmontoahorro"", ""Smtpssl"", ""Mostrardescuentofactura"", ""Exportcatalogoaux"", ""Uiventaconcantidad"", ""Fact_elect_folder"", ""Pedidos_folder"", ""Prefijocliente"", ""Fechainiciopedido"", ""Mostrarpzacajaenfactura"", ""Desgloseieps"", ""Cuentaieps"", ""Dividir_rem_fact"", ""Webservice"", ""Minutilidad"", ""Manejasuperlistaprecio"", ""Manejaalmacen"", ""Tipodescuentoprodid"", ""Manejareceta"", ""Autocompprod"", ""Lastchangeproddesc"", ""Tipoutilidadid"", ""Manejaquota"", ""Touch"", ""Esvendedormovil"", ""Cajasbotellas"", ""Precionetoenpv"", ""Mostrarflash"", ""Autocompcliente"", ""Lastchangeclientenombre"", ""Precioxcajaenpv"", ""Localftphost"", ""Localwebservice"", ""Usarconexionlocal"", ""Movillastpreciodate"", ""Lastchangeprecioprod"", ""Movilcierrecobranza"", ""Movilcierreventa"", ""Mailtoinventario"", ""Rutarespaldoszip"", ""Promoenticket"", ""Tamanoletraticket"", ""Manejakits"", ""Rebajaespecial"", ""Habilitarrepl"", ""Bdlocalrepl"", ""Pendmovilantesventa"", ""Preciosmovilantesventa"", ""Recalcularcambiocliente"", ""Bdserverws"", ""Bdmatrizmovil"", ""Prodcambioparamovil"", ""Movilprocesosurtido"", ""Movilverificarventa"", ""Pendmaxdias"", ""Reqautcancelarcoti"", ""Reqautelimdetallecoti"", ""Abrircajonalfincorte"", ""Habsurtidopostpuesto"", ""Clienteconsolidadoid"", ""Rutareportessistema"", ""Doblecopiaremision"", ""Reimpresionesconmarca"", ""Habtotalizados"", ""Multipletipovale"", ""Descuentotipo1texto"", ""Descuentotipo1porc"", ""Descuentotipo2texto"", ""Descuentotipo2porc"", ""Descuentotipo3texto"", ""Descuentotipo3porc"", ""Descuentotipo4texto"", ""Descuentotipo4porc"", ""Habilitarlog"", ""Rutarespaldo"", ""Fecharespaldo"", ""Manejarretirodecaja"", ""Montoretirocaja"", ""Aplicarmayoreoporlinea"", ""Comisionportarjeta"", ""Piezasigualesmediomayoreo"", ""Piezasdifmediomayoreo"", ""Piezasigualesmayoreo"", ""Piezasdifmayoreo"", ""Comisiontarjetaempresa"", ""Ivacomisiontarjetaempresa"", ""Preguntacancelacotizacion"", ""Habverificacioncxc"", ""Mailejecutivo"", ""Ventasxcorteemail"", ""Habventasafuturo"", ""Serviciosemida"", ""Fechaactualizacionemida"", ""Seriesatabono"", ""Habimpresioncortecajero"", ""Habtrasladoporautorizacion"", ""Habventasmostrador"", ""Timeoutpindistsale"", ""Timeoutlookup"", ""Rutaarchivosadjuntos"", ""Timeoutpindistsaleserv"", ""Habpagoservemida"", ""Fechaactualizacionemidaserv"", ""Habpromoxmontomin"", ""Montomaxsaldomenor"", ""Emidarecargalineaid"", ""Emidarecargamarcaid"", ""Emidarecargaproveedorid"", ""Emidaserviciolineaid"", ""Emidaserviciomarcaid"", ""Emidaservicioproveedorid"", ""Emidaporcutilidadrecargas"", ""Emidautilidadpagoservicios"", ""Preciosordenados"", ""Decimalesencantidad"", ""Eanpuederepetirse"", ""Bancomerhabpinpad"", ""Hab_precioscliente"", ""Cxcvalidartraslados"", ""Preguntarsiesacredito"", ""Habmensajeria"", ""Wsmensajeria"", ""Ultmensajeid"", ""Habdesclineapersona"", ""Manejarloteimportacion"", ""Manejagastosadic"", ""Caducidadminima"", ""Habbotonpagovale"", ""Unicavisitapordocto"", ""Plazoxproducto"", ""Autocompleteconexisenventa"", ""Ipwebserviceappinv"", ""Rutabdappinventaro"", ""Rutadbfexistenciasuc"", ""Almacenrecepcionid"", ""Aplicarcambiosprecauto"", ""Numcancelactauto"", ""Numcancelactautousuario"", ""Manejacupones"", ""Hab_devoluciontraslado"", ""Hab_devolucionsurtidosuc"", ""Versionwsexistencias"", ""Manejaproductospromocion"", ""Sat_metodopagoid"", ""Sat_regimenfiscalid"", ""Precionetoengrids"", ""Versioncfdi"", ""Pagoservconsolidado"", ""Mostrarinvinfoadicprod"", ""Wsespecialexistmatriz"", ""Hab_consolidadoautomatico"", ""Rutareplicadorexe"", ""Ult_consolidadoautomatico"", ""Ticketespecial"", ""Ticketdefaultprinter"", ""Recargasdefaultprinter"", ""Piezacajaenticket"", ""Numticketsabono"", ""Generarfe"", ""Intentosretirocaja"", ""Vendedormovilclave"", ""Movil_ultcam_sesion"", ""Movil_tienevendedores"", ""Rutacatalogosupd"", ""Imprimircopiaalmacen"", ""Movil3_preimportar"", ""Rutaimportadatos"", ""Busquedatipo2"", ""Agrupacionventaid"", ""Consfactomitirvales"", ""Destinobdvenmov"", ""Doblecopiacontado"", ""Desgloseiepsfactura"", ""Rutapolizapdf"", ""Imprimirbancoscorte"", ""Pago_tarjmenorpreciolista"", ""Impr_canc_venta"", ""Retirocajaalcerrarcorte"", ""Pagotarjmenorpreciolistaall"", ""Kitsdef_ultact"", ""Kitsdef_unniv_ultact"", ""Preguntarservdom"", ""Habppc"", ""Soloabonoaplicado"", ""Versiontopeid"", ""Versioncomisionid"", ""Maxcomisionxcliente"", ""Imprformaventatrasl"", ""Habrevisionfinal"", ""Recibolargocotiprinter"", ""Habfondodinamico"", ""Habventaclisuc"", ""Segundoscicloftp"", ""Diasmaxexpftp"", ""Diasmaximpftp"", ""Wsdbf"", ""Habwsdbf"", ""Comisiondebtarjetaempresa"", ""Comisiondebportarjeta"", ""Factconsmaxpor"", ""Doblecopiatarjeta"", ""Fiscalfechacancelacion2"", ""Cantticketretiro"", ""Cantticketabrircorte"", ""Cantticketcompras"", ""Cantticketfondocaja"", ""Cantticketgastos"", ""Cantticketdepositos"", ""Cantticketcierrecorte"", ""Cantticketcierrebilletes"", ""Manejautilidadprecios"", ""Habmultplazocompra"", ""Costorepoigualcostoult"", ""Ticket_desc_vale_al_final"", ""Monederolistaprecioid"", ""Monederocamporef"", ""Habsurtidoprevio"", ""Numticketscomanda"", ""Recibopreviewcomanda"", ""Impresoracomanda"", ""Ticket_impr_desc2"", ""Seriecomprtraslsat"", ""Habsurtidopostmovil"", ""Porcutilidadlistado"", ""Activo"", ""Creado"", ""Modificado"", ""Tiposyncmovil"", ""Tiposeleccioncatalogosat"", ""Pvcolorear"", ""Ordenimpresion"", ""Formatofactelect"", ""Campoimpocostorepoid"", ""Formatoticketcortoid"", ""Lista_precio_defid"", ""Precioajustedifinvid"", ""Screenconfig"", ""Tipovendedormovil"", ""Vendedormovilid"", ""Calle"", ""Codigopostal"", ""Colonia"", ""Estado"", ""Municipio"", ""Nombre"", ""Autpreciolistabajo"", ""Listapreciomaylinea"", ""Listaprecmedmaylinea"", ""Rutafirmaimagenes""
)
VALUES (
{empresaId.ToString()},{sucursalId.ToString()}, '12', E'Hidalgo', NULL, E'N', '0', '0', NULL, NULL, NULL, '0', NULL, NULL, E'S', '0', '0', NULL, NULL, NULL, NULL, NULL, NULL,0, NULL, NULL, E'N', NULL, E'N', E'TEST\r\nENTER 1', E'TEST PIE 2', E'N', E'N', E'N', E'N', E'N', '0', NULL, E'N', NULL, NULL, E'Calle 45', E'3', E'4', E'Medrano', E'Leon', E'Hidalgo', E'37161', E'20001000000100001695', E'CTE940531F58', E'12345678a', E'.\\\\assets\\\\CSD_JES900109Q90\\JES900109Q90.cer', E'.\\\\assets\\\\CSD_JES900109Q90\\JES900109Q90.key', E'HwAAAHarKwEghcVR/jxG3Dd7OGKpk8uUTRjyYWdG6EI2mwOjedrfryXCjJwz5PP7;sDqjPQ==;', E'JIMENEZ ESTRADA SALAS', E'A', E'S', E'N', NULL, NULL, '0', '0', NULL, NULL, E'D', E'N', E'N', NULL, NULL, NULL, NULL, NULL, NULL, E'N', E'N', '0', E'N',0, E'N', E'VirtualPAC', E'demo_cibertec', E'S', NULL,0,0, E'N', E'N', NULL, E'N', E'N', E'N', E'General de Ley Personas Morales',0, '0', '0', E'N', NULL, E'N', E'N', E'N', E'N', E'N', E'N', E'{{{{BaseDirectory}}}}\\sampdata', NULL, NULL, NULL, E'N', E'S', E'1234567890', E'N', NULL, '0', E'N', E'N', NULL, E'N', E'N', NULL, NULL, E'N', E'N', E'N', E'N', E'N', E'N', E'N', NULL, E'N', NULL, NULL, E'N', NULL, NULL, NULL, NULL, NULL, NULL, E'N',0, E'S', E'N', E'N', NULL, E'N', E'N', E'N', NULL, NULL, NULL, E'N', E'N',0, E'N', E'N', E'N', E'N',NULL, NULL, E'N', E'N', E'N', E'N', NULL, '0', NULL, '0', NULL, '0', NULL, '0', E'N', NULL, NULL, E'N', '0', E'N', '0', '0', '0', '0', '0', '0', '0', E'N', E'N', NULL, E'N', E'S', E'N', NULL, E'C', E'N', E'N', E'N',0,0, NULL,0, E'N', NULL, E'N', '0', NULL, NULL, NULL, NULL, NULL, NULL, '0', '0', E'N',0, E'N', E'N', E'N', E'N', E'N', E'N', NULL, NULL, E'N', E'N', E'N',0, E'N', E'N', E'N', E'N', NULL, NULL, NULL,NULL, E'N',0,0, E'N', E'N', E'N',0, E'N',1,1, E'N', E'4.0', E'N', E'N', NULL, E'N', NULL, NULL, NULL, NULL, NULL, E'N',0, E'N',0, NULL, NULL, E'N', NULL, E'N', E'N', NULL, E'N', NULL, E'N', NULL,0, E'S', NULL, E'N', E'N', E'N', E'N', E'N', NULL, NULL, E'N', E'N', E'N', NULL, NULL, '0', E'N', E'N', NULL, E'N', E'N',0,0,0, NULL, E'N', '0', '0', '0',0, NULL,0,0,0,0,0,0,0,0, E'N', E'N', E'N', E'N', NULL, NULL, E'N',0, E'N', NULL, E'N', E'F', E'N', '0', E'S', E'2023-04-01 01:56:35.789762-06', E'2023-04-01 01:56:35.789764-06', NULL, NULL,1, NULL,1, NULL, NULL,4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, E'S',8,6, E'firma'
);";
            try
            {
                applicationDbContext.Database.ExecuteSqlRaw(strCommand);
                applicationDbContext.SaveChanges();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public void CrearMarcaDefault(SucursalBindingModel sucursalInfo)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();
            Marca marca = new Marca();
            marca.EmpresaId = sucursalInfo.EmpresaId;
            marca.SucursalId = sucursalInfo.Id!.Value;
            marca.Clave = "DEFAULT";
            marca.Nombre = "MARCA GENERICA";

            applicationDbContext.Marca.Add(marca);
            applicationDbContext.SaveChanges();

        }


        public void CrearProductoDefault(SucursalBindingModel sucursalInfo)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();


            var linea = applicationDbContext.Linea.AsNoTracking().FirstOrDefault(t => t.EmpresaId == sucursalInfo.EmpresaId && t.SucursalId == sucursalInfo.Id && t.Clave == "DEFAULT");
            var marca = applicationDbContext.Marca.AsNoTracking().FirstOrDefault(t => t.EmpresaId == sucursalInfo.EmpresaId && t.SucursalId == sucursalInfo.Id && t.Clave == "DEFAULT");
            var proveedor = applicationDbContext.Proveedor.AsNoTracking().FirstOrDefault(t => t.EmpresaId == sucursalInfo.EmpresaId && t.SucursalId == sucursalInfo.Id && t.Clave == "DEFAULT");
            var unidad = applicationDbContext.Unidad.AsNoTracking().FirstOrDefault(t => t.EmpresaId == sucursalInfo.EmpresaId && t.SucursalId == sucursalInfo.Id && t.Clave == "PZA");
            var sat_Productoservicio = applicationDbContext.Sat_productoservicio.AsNoTracking().FirstOrDefault(t => t.Sat_claveprodserv == "50192109");

            Producto producto = new Producto();
            producto.EmpresaId = sucursalInfo.EmpresaId;
            producto.SucursalId = sucursalInfo.Id!.Value;
            producto.Clave = "DEFAULT";
            producto.Nombre = "PROVEEDOR GENERICO";
            producto.Descripcion = "PROVEEDOR GENERICO";
            producto.Ean = null;
            producto.Descripcion1 = "PROVEEDOR GENERICO";
            producto.Descripcion2 = "PROVEEDOR GENERICO";
            producto.Descripcion3 = "PROVEEDOR GENERICO";
            producto.Cbarras = null;
            producto.Cempaque = null;
            producto.Plug = null;
            producto.Proveedor1id = proveedor?.Id;
            producto.Proveedor2id = null;
            producto.Lineaid = linea?.Id;
            producto.Marcaid = marca?.Id;
            producto.Unidadid = unidad?.Id;
            producto.Ivaimpuesto = 16;
            producto.Iepsimpuesto = 0;
            producto.Impuesto = 16;


            var producto_precios = new Producto_precios();
            producto_precios.EmpresaId = sucursalInfo.EmpresaId;
            producto_precios.SucursalId = sucursalInfo.Id!.Value;
            producto_precios.Precio1 = 100;
            producto_precios.Precio2 = 96;
            producto_precios.Precio3 = 92;
            producto_precios.Precio4 = 88;
            producto_precios.Precio5 = 84;
            producto_precios.Precio6 = 80;
            producto.Producto_precios = producto_precios;




            var producto_inventario = new Producto_inventario();
            producto_inventario.EmpresaId = sucursalInfo.EmpresaId;
            producto_inventario.SucursalId = sucursalInfo.Id!.Value;
            producto_inventario.Inventariable = BoolCS.S;
            producto_inventario.Pzacaja = 1;
            producto.Producto_inventario = producto_inventario;



            var producto_kit = new Producto_kit();
            producto_kit.EmpresaId = sucursalInfo.EmpresaId;
            producto_kit.SucursalId = sucursalInfo.Id!.Value;
            producto_kit.Eskit = BoolCN.N;
            producto.Producto_kit = producto_kit;


            var producto_fact_elect = new Producto_fact_elect();
            producto_fact_elect.EmpresaId = sucursalInfo.EmpresaId;
            producto_fact_elect.SucursalId = sucursalInfo.Id!.Value;
            producto_fact_elect.Sat_productoservicioid = sat_Productoservicio?.Id;
            producto_fact_elect.Generacomprobtrasl = BoolCN.N;
            producto_fact_elect.Generacartaporte = BoolCN.N;
            producto.Producto_fact_elect = producto_fact_elect;


            applicationDbContext.Producto.Add(producto);
            applicationDbContext.SaveChanges();


        }

        public CajaBindingModel CrearCaja(CajaBindingModel cajaInfo)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            if (cajaInfo.Clave == null || cajaInfo.Nombre == null)
            {
                throw new Exception("Se requiere clave y nombre de la sucursal");
            }

            var caja = new Caja();
            caja.EmpresaId = cajaInfo.EmpresaId ?? 0;
            caja.SucursalId = cajaInfo.SucursalId ?? 0;
            caja.Clave = cajaInfo.Clave;
            caja.Nombre = cajaInfo.Nombre;
            caja.Nombreimpresora = cajaInfo.Nombreimpresora;
            applicationDbContext.Caja.Add(caja);
            applicationDbContext.SaveChanges();
            cajaInfo.Id = caja.Id;

            return cajaInfo;
        }


        public UsuarioBindingModel CrearUsuario(UsuarioBindingModel usuarioInfo)
        {

            using var applicationDbContext = this._operationsContextFactory.Create();

            if (usuarioInfo.UsuarioNombre == null || usuarioInfo.Contrasena == null)
            {
                throw new Exception("Se requiere nombre y password del usuario");
            }

            var usuario = new Usuario();
            usuario.EmpresaId = usuarioInfo.EmpresaId ?? 0;
            usuario.SucursalId = usuarioInfo.SucursalId ?? 0;
            usuario.UsuarioNombre = usuarioInfo.UsuarioNombre;
            usuario.Nombre = usuarioInfo.Nombre ?? usuarioInfo.UsuarioNombre;
            usuario.Nombres = usuarioInfo.Nombres;
            usuario.Apellidos = usuarioInfo.Apellidos;
            usuario.Contrasena = usuarioInfo.Contrasena;

            applicationDbContext.Usuario.Add(usuario);
            applicationDbContext.SaveChanges();
            usuarioInfo.Id = usuario.Id;

            var perfilAdministrador = new Perfiles();
            perfilAdministrador.EmpresaId = usuarioInfo.EmpresaId ?? 0;
            perfilAdministrador.SucursalId = usuarioInfo.SucursalId ?? 0;
            perfilAdministrador.Descripcion = "Administrador";
            applicationDbContext.Perfiles.Add(perfilAdministrador);
            applicationDbContext.SaveChanges();

            var usuarioPerfil = new Usuario_perfil();
            usuarioPerfil.EmpresaId = usuarioInfo.EmpresaId ?? 0;
            usuarioPerfil.SucursalId = usuarioInfo.SucursalId ?? 0;
            usuarioPerfil.Usuarioid = usuarioInfo.Id;
            usuarioPerfil.Perfilid = perfilAdministrador.Id;
            applicationDbContext.Usuario_perfil.Add(usuarioPerfil);
            applicationDbContext.SaveChanges();

            var derechos = applicationDbContext.Derechos.AsNoTracking()
                                                .ToList();
            foreach (var derecho in derechos)
            {
                var perfil_der = new Perfil_der();
                perfil_der.EmpresaId = usuarioInfo.EmpresaId ?? 0;
                perfil_der.SucursalId = usuarioInfo.SucursalId ?? 0;
                perfil_der.Perfilid = perfilAdministrador.Id;
                perfil_der.Derechoid = derecho.Id;
                applicationDbContext.Perfil_der.Add(perfil_der);

            }

            applicationDbContext.SaveChanges();





            return usuarioInfo;
        }

        public void MigrateDataBase(bool createIfNotExist, string rutaInstalacionPostgresql, ConfiguracionBindingModel configuracion)
        {


            using var applicationDbContext = this._operationsContextFactory.Create();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var databaseExists = (applicationDbContext.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)?.Exists();

            if (!(databaseExists ?? false) && !createIfNotExist)
                throw new Exception("La base de datos no existe");

            if (!(databaseExists ?? false))
            {

                DBToolkitApplicationOptions dBToolkitApplicationOptions = new DBToolkitApplicationOptions();
                dBToolkitApplicationOptions.PostgreSQLHost = configuracion.Servidor ?? "";
                dBToolkitApplicationOptions.PostgreSQLPort = configuracion.Puerto ?? "";
                dBToolkitApplicationOptions.PostgreSQLUser = configuracion.Usuario ?? "";
                dBToolkitApplicationOptions.PostgreSQLPass = configuracion.Password ?? "";


                try
                {

                    PostgreSQLToolkit.RestoreDatabase(configuracion.Database!, "./SeedData/MomusBackupInitial.tar", rutaInstalacionPostgresql, dBToolkitApplicationOptions);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
            databaseExists = (applicationDbContext.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)?.Exists();

            if (!(databaseExists ?? false) )
                throw new Exception("No se pudo crear la bd");

            var migrationsJustApplied = applicationDbContext.Database.GetPendingMigrations().ToList();
            if(migrationsJustApplied.Any())
                applicationDbContext.Database.Migrate();


            IposV3.Migrations.Seed.MigrationService.RunSpecialMigrationProcesses(applicationDbContext, migrationsJustApplied);



        }



        //views



        //commands


        //impo-expo


    }
}