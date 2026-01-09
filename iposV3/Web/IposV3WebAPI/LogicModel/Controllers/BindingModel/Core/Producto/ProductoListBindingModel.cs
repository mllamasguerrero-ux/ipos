
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;

namespace BindingModels
{
    [XmlRoot]

    public class ProductoListBindingModel : Validatable, IBaseBindingModel

    {

        public ProductoListBindingModel()
        {
        }
        
        #if PROYECTO_WEB
        
        public ProductoListBindingModel(Producto item)
        {
            FillFromEntity(item);
        }

        public ProductoListBindingModel(Producto item, Parametro parametro, Cliente clienteMostrador, long? almacenId1, long? almacenId2, long? almacenId3, decimal? porcUtilidad): 
                          this(item)
        {
            _Existencia_Almacen1 = 0;
            _Existencia_Almacen2 = 0;
            _Existencia_Almacen3 = 0;

            if (item.Inventarios != null)
            {
                if (almacenId1 != null)
                    _Existencia_Almacen1 = item.Inventarios.Where(i => i.Almacenid == almacenId1 && i.Esapartado != BoolCN.S).Sum(i => i.Cantidad);

                if (almacenId2 != null)
                    _Existencia_Almacen2 = item.Inventarios.Where(i => i.Almacenid == almacenId2 && i.Esapartado != BoolCN.S).Sum(i => i.Cantidad);

                if (almacenId3 != null)
                    _Existencia_Almacen3 = item.Inventarios.Where(i => i.Almacenid == almacenId3 && i.Esapartado != BoolCN.S).Sum(i => i.Cantidad);

            }


            _Producto_precios_Precio1_conImp = Math.Round((Producto_precios_Precio1 ?? 0m) * ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) * (1m + ((Ivaimpuesto ?? 0m) / 100m)), 4);
            _Producto_precios_Precio2_conImp = Math.Round((Producto_precios_Precio2 ?? 0m) * ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) * (1m + ((Ivaimpuesto ?? 0m) / 100m)), 4);
            _Producto_precios_Precio3_conImp = Math.Round((Producto_precios_Precio3 ?? 0m) * ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) * (1m + ((Ivaimpuesto ?? 0m) / 100m)), 4);
            _Producto_precios_Precio4_conImp = Math.Round((Producto_precios_Precio4 ?? 0m) * ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) * (1m + ((Ivaimpuesto ?? 0m) / 100m)), 4);
            _Producto_precios_Precio5_conImp = Math.Round((Producto_precios_Precio5 ?? 0m) * ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) * (1m + ((Ivaimpuesto ?? 0m) / 100m)), 4);

            decimal? bufferPrecio;
            if ((item.Producto_inventario?.Pzacaja ?? 1m) > 1 && parametro.Cambiarprecioxpzacaja == BoolCN.S && parametro.Listaprecioxpzacaja > 0)
            {
                bufferPrecio = PrecioXListaPrecio(parametro.Listaprecioxpzacaja_);
            }
            else
            {
                bufferPrecio = Producto_precios_Precio1;
            }
            _Producto_precios_caja_conImp = Math.Round(
                                                        Math.Round(
                                                            (bufferPrecio ?? 0m) *
                                                            ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) *
                                                            (1m + ((Ivaimpuesto ?? 0m) / 100m))
                                                            , 4) *
                                                        (item.Producto_inventario?.Pzacaja ?? 1m)
                                                        , 4);

            _Producto_precios_Costorepoconutilimp = Math.Round(
                                               Math.Round((this.Producto_precios_Costorepo ?? 0m) * (1m + ((porcUtilidad ?? 0m) / 100m)), 4)
                                               * ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) * (1m + ((Ivaimpuesto ?? 0m) / 100m)),
                                               4);



            decimal? bufferPrecioMostrador = PrecioXListaPrecio(clienteMostrador.Cliente_precio?.Listaprecio);
            decimal? bufferPrecioConTarjeta;
            decimal? bufferPrecioConTarjetaConPrecioEspecial;

            //medio mayoreo
            bufferPrecioConTarjeta = PrecioXListaPrecio(parametro.Listapremedmaylinea_) * (1m + (parametro.Comisionportarjeta / 100m));
            bufferPrecio = (new List<decimal?>() { bufferPrecioMostrador, bufferPrecioConTarjeta }).Min();


            _Producto_precios_Preciomediomayoreocontarjeta =
                                                    Math.Round(
                                                        Math.Round(
                                                            (bufferPrecio ?? 0m) *
                                                            ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) *
                                                            (1m + ((Ivaimpuesto ?? 0m) / 100m))
                                                            , 4)
                                                        , 4);

            //mayoreo
            bufferPrecioConTarjeta = PrecioXListaPrecio(parametro.Listapreciomaylinea_) * (1m + (parametro.Comisionportarjeta / 100m));
            bufferPrecioConTarjetaConPrecioEspecial = Producto_precios_Precio6 * (1m + (parametro.Comisionportarjeta / 100m));
            bufferPrecio = (new List<decimal?>() { bufferPrecioMostrador, bufferPrecioConTarjeta, bufferPrecioConTarjetaConPrecioEspecial }).Min();


            _Producto_precios_Preciomayoreocontarjeta =
                                                    Math.Round(
                                                        Math.Round(
                                                            (bufferPrecio ?? 0m) *
                                                            ((parametro.Desgloseieps != BoolCN.S) ? 1m : (1m + ((Iepsimpuesto ?? 0m) / 100m))) *
                                                            (1m + ((Ivaimpuesto ?? 0m) / 100m))
                                                            , 4)
                                                        , 4);

            _Producto_inventario_Pzacaja = item.Producto_inventario?.Pzacaja ?? 1m;

            _Producto_precios_Limiteprecio2 = item.Producto_precios?.Limiteprecio2 ?? 1m;

            if ((item.Producto_inventario?.Pzacaja ?? 1m) <= 1m)
            {

                _Producto_inventario_ExistenciaCajas = 0m;
                _Producto_inventario_ExistenciaPiezas = this.Producto_existencia_Existencia ?? 0m;
            }
            else
            {
                _Producto_inventario_ExistenciaPiezas = (this.Producto_existencia_Existencia ?? 0m) % (item.Producto_inventario?.Pzacaja ?? 1m);
                _Producto_inventario_ExistenciaCajas = Math.Truncate((this.Producto_existencia_Existencia ?? 0m) / (item.Producto_inventario?.Pzacaja ?? 1m));

            }


            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Texto1 != null)
                Productocaracteristicas_Texto1 = item.Productocaracteristicas!.Texto1;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Texto2 != null)
                Productocaracteristicas_Texto2 = item.Productocaracteristicas!.Texto2;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Texto3 != null)
                Productocaracteristicas_Texto3 = item.Productocaracteristicas!.Texto3;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Texto4 != null)
                Productocaracteristicas_Texto4 = item.Productocaracteristicas!.Texto4;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Texto5 != null)
                Productocaracteristicas_Texto5 = item.Productocaracteristicas!.Texto5;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Texto6 != null)
                Productocaracteristicas_Texto6 = item.Productocaracteristicas!.Texto6;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Numero1 != null)
                Productocaracteristicas_Numero1 = item.Productocaracteristicas!.Numero1;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Numero2 != null)
                Productocaracteristicas_Numero2 = item.Productocaracteristicas!.Numero2;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Numero3 != null)
                Productocaracteristicas_Numero3 = item.Productocaracteristicas!.Numero3;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Numero4 != null)
                Productocaracteristicas_Numero4 = item.Productocaracteristicas!.Numero4;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Fecha1 != null)
                Productocaracteristicas_Fecha1 = item.Productocaracteristicas!.Fecha1;

            if (item.Productocaracteristicas != null && item.Productocaracteristicas?.Fecha2 != null)
                Productocaracteristicas_Fecha2 = item.Productocaracteristicas!.Fecha2;

        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }

        #endif
        

        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }

        private long? _EmpresaId;
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId ?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value ?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId ?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value ?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public long? Id { get => _Id ?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value ?? 0; OnPropertyChanged(); } } }

        private BoolCS? _Activo;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo ?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value ?? BoolCS.S; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute]
        public DateTimeOffset? Creado { get => _Creado ?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value ?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        public DateTimeOffset? Modificado { get => _Modificado ?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value ?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave ?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value ?? ""; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre ?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value ?? ""; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public string? Descripcion { get => _Descripcion ?? ""; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value ?? ""; OnPropertyChanged(); } } }

        private string? _Ean;
        [XmlAttribute]
        public string? Ean { get => _Ean; set { if (RaiseAcceptPendingChange(value, _Ean)) { _Ean = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private string? _Descripcion3;
        [XmlAttribute]
        public string? Descripcion3 { get => _Descripcion3; set { if (RaiseAcceptPendingChange(value, _Descripcion3)) { _Descripcion3 = value; OnPropertyChanged(); } } }

        private string? _Cbarras;
        [XmlAttribute]
        public string? Cbarras { get => _Cbarras; set { if (RaiseAcceptPendingChange(value, _Cbarras)) { _Cbarras = value; OnPropertyChanged(); } } }

        private string? _Cempaque;
        [XmlAttribute]
        public string? Cempaque { get => _Cempaque; set { if (RaiseAcceptPendingChange(value, _Cempaque)) { _Cempaque = value; OnPropertyChanged(); } } }

        private string? _Plug;
        [XmlAttribute]
        public string? Plug { get => _Plug; set { if (RaiseAcceptPendingChange(value, _Plug)) { _Plug = value; OnPropertyChanged(); } } }

        private long? _Proveedor1id;
        [XmlAttribute]
        public long? Proveedor1id { get => _Proveedor1id; set { if (RaiseAcceptPendingChange(value, _Proveedor1id)) { _Proveedor1id = value; OnPropertyChanged(); } } }

        private string? _Proveedor1Clave;
        [XmlAttribute]
        public string? Proveedor1Clave { get => _Proveedor1Clave; set { if (RaiseAcceptPendingChange(value, _Proveedor1Clave)) { _Proveedor1Clave = value; OnPropertyChanged(); } } }

        private string? _Proveedor1Nombre;
        [XmlAttribute]
        public string? Proveedor1Nombre { get => _Proveedor1Nombre; set { if (RaiseAcceptPendingChange(value, _Proveedor1Nombre)) { _Proveedor1Nombre = value; OnPropertyChanged(); } } }

        private long? _Proveedor2id;
        [XmlAttribute]
        public long? Proveedor2id { get => _Proveedor2id; set { if (RaiseAcceptPendingChange(value, _Proveedor2id)) { _Proveedor2id = value; OnPropertyChanged(); } } }

        private string? _Proveedor2Clave;
        [XmlAttribute]
        public string? Proveedor2Clave { get => _Proveedor2Clave; set { if (RaiseAcceptPendingChange(value, _Proveedor2Clave)) { _Proveedor2Clave = value; OnPropertyChanged(); } } }

        private string? _Proveedor2Nombre;
        [XmlAttribute]
        public string? Proveedor2Nombre { get => _Proveedor2Nombre; set { if (RaiseAcceptPendingChange(value, _Proveedor2Nombre)) { _Proveedor2Nombre = value; OnPropertyChanged(); } } }

        private long? _Lineaid;
        [XmlAttribute]
        public long? Lineaid { get => _Lineaid; set { if (RaiseAcceptPendingChange(value, _Lineaid)) { _Lineaid = value; OnPropertyChanged(); } } }

        private string? _LineaClave;
        [XmlAttribute]
        public string? LineaClave { get => _LineaClave; set { if (RaiseAcceptPendingChange(value, _LineaClave)) { _LineaClave = value; OnPropertyChanged(); } } }

        private string? _LineaNombre;
        [XmlAttribute]
        public string? LineaNombre { get => _LineaNombre; set { if (RaiseAcceptPendingChange(value, _LineaNombre)) { _LineaNombre = value; OnPropertyChanged(); } } }

        private long? _Marcaid;
        [XmlAttribute]
        public long? Marcaid { get => _Marcaid; set { if (RaiseAcceptPendingChange(value, _Marcaid)) { _Marcaid = value; OnPropertyChanged(); } } }

        private string? _MarcaClave;
        [XmlAttribute]
        public string? MarcaClave { get => _MarcaClave; set { if (RaiseAcceptPendingChange(value, _MarcaClave)) { _MarcaClave = value; OnPropertyChanged(); } } }

        private string? _MarcaNombre;
        [XmlAttribute]
        public string? MarcaNombre { get => _MarcaNombre; set { if (RaiseAcceptPendingChange(value, _MarcaNombre)) { _MarcaNombre = value; OnPropertyChanged(); } } }

        private long? _Unidadid;
        [XmlAttribute]
        public long? Unidadid { get => _Unidadid; set { if (RaiseAcceptPendingChange(value, _Unidadid)) { _Unidadid = value; OnPropertyChanged(); } } }

        private string? _UnidadClave;
        [XmlAttribute]
        public string? UnidadClave { get => _UnidadClave; set { if (RaiseAcceptPendingChange(value, _UnidadClave)) { _UnidadClave = value; OnPropertyChanged(); } } }

        private string? _UnidadNombre;
        [XmlAttribute]
        public string? UnidadNombre { get => _UnidadNombre; set { if (RaiseAcceptPendingChange(value, _UnidadNombre)) { _UnidadNombre = value; OnPropertyChanged(); } } }

        private decimal? _Ivaimpuesto;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Ivaimpuesto { get => _Ivaimpuesto ?? 0; set { if (RaiseAcceptPendingChange(value, _Ivaimpuesto)) { _Ivaimpuesto = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Iepsimpuesto;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Iepsimpuesto { get => _Iepsimpuesto ?? 0; set { if (RaiseAcceptPendingChange(value, _Iepsimpuesto)) { _Iepsimpuesto = value ?? 0; OnPropertyChanged(); } } }

       
        private decimal? _Producto_existencia_Existencia;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_existencia_Existencia { get => _Producto_existencia_Existencia ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_existencia_Existencia)) { _Producto_existencia_Existencia = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_existencia_Enprocesodesalida;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_existencia_Enprocesodesalida { get => _Producto_existencia_Enprocesodesalida ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_existencia_Enprocesodesalida)) { _Producto_existencia_Enprocesodesalida = value ?? 0; OnPropertyChanged(); } } }

       
        private BoolCS? _Producto_inventario_Inventariable;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCS? Producto_inventario_Inventariable { get => _Producto_inventario_Inventariable ?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Inventariable)) { _Producto_inventario_Inventariable = value ?? BoolCS.S; OnPropertyChanged(); } } }

        private BoolCN? _Producto_inventario_Negativos;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Producto_inventario_Negativos { get => _Producto_inventario_Negativos ?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Negativos)) { _Producto_inventario_Negativos = value ?? BoolCN.N; OnPropertyChanged(); } } }

       
        private decimal? _Producto_precios_Precio1;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Precio1 { get => _Producto_precios_Precio1 ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio1)) { _Producto_precios_Precio1 = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio2;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Precio2 { get => _Producto_precios_Precio2 ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio2)) { _Producto_precios_Precio2 = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio3;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Precio3 { get => _Producto_precios_Precio3 ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio3)) { _Producto_precios_Precio3 = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio4;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Precio4 { get => _Producto_precios_Precio4 ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio4)) { _Producto_precios_Precio4 = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio5;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Precio5 { get => _Producto_precios_Precio5 ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio5)) { _Producto_precios_Precio5 = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio6;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Precio6 { get => _Producto_precios_Precio6 ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio6)) { _Producto_precios_Precio6 = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Costoultimo;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Costoultimo { get => _Producto_precios_Costoultimo ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Costoultimo)) { _Producto_precios_Costoultimo = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Costopromedio;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Costopromedio { get => _Producto_precios_Costopromedio ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Costopromedio)) { _Producto_precios_Costopromedio = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Costorepo;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Producto_precios_Costorepo { get => _Producto_precios_Costorepo ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Costorepo)) { _Producto_precios_Costorepo = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Superprecio1;
        [XmlAttribute]
        public decimal? Producto_precios_Superprecio1 { get => _Producto_precios_Superprecio1; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Superprecio1)) { _Producto_precios_Superprecio1 = value; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Superprecio2;
        [XmlAttribute]
        public decimal? Producto_precios_Superprecio2 { get => _Producto_precios_Superprecio2; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Superprecio2)) { _Producto_precios_Superprecio2 = value; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Superprecio3;
        [XmlAttribute]
        public decimal? Producto_precios_Superprecio3 { get => _Producto_precios_Superprecio3; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Superprecio3)) { _Producto_precios_Superprecio3 = value; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Superprecio4;
        [XmlAttribute]
        public decimal? Producto_precios_Superprecio4 { get => _Producto_precios_Superprecio4; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Superprecio4)) { _Producto_precios_Superprecio4 = value; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Superprecio5;
        [XmlAttribute]
        public decimal? Producto_precios_Superprecio5 { get => _Producto_precios_Superprecio5; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Superprecio5)) { _Producto_precios_Superprecio5 = value; OnPropertyChanged(); } } }



        private decimal? _Existencia_Almacen1;
        public decimal? Existencia_Almacen1 { get => _Existencia_Almacen1; set { if (RaiseAcceptPendingChange(value, _Existencia_Almacen1)) { _Existencia_Almacen1 = value; OnPropertyChanged(); } } }


        private decimal? _Existencia_Almacen2;
        public decimal? Existencia_Almacen2 { get => _Existencia_Almacen2; set { if (RaiseAcceptPendingChange(value, _Existencia_Almacen2)) { _Existencia_Almacen2 = value; OnPropertyChanged(); } } }


        private decimal? _Existencia_Almacen3;
        public decimal? Existencia_Almacen3 { get => _Existencia_Almacen3; set { if (RaiseAcceptPendingChange(value, _Existencia_Almacen3)) { _Existencia_Almacen3 = value; OnPropertyChanged(); } } }


        private decimal? _Existencia_Apartados;
        public decimal? Existencia_Apartados { get => _Existencia_Apartados; set { if (RaiseAcceptPendingChange(value, _Existencia_Apartados)) { _Existencia_Apartados = value; OnPropertyChanged(); } } }



        [XmlAttribute]
        private decimal? _Producto_precios_Precio1_conImp;
        [XmlAttribute]
        public decimal? Producto_precios_Precio1_conImp { get => _Producto_precios_Precio1_conImp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio1_conImp)) { _Producto_precios_Precio1_conImp = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio2_conImp;
        [XmlAttribute]
        public decimal? Producto_precios_Precio2_conImp { get => _Producto_precios_Precio2_conImp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio2_conImp)) { _Producto_precios_Precio2_conImp = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio3_conImp;
        [XmlAttribute]
        public decimal? Producto_precios_Precio3_conImp { get => _Producto_precios_Precio3_conImp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio3_conImp)) { _Producto_precios_Precio3_conImp = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio4_conImp;
        [XmlAttribute]
        public decimal? Producto_precios_Precio4_conImp { get => _Producto_precios_Precio4_conImp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio4_conImp)) { _Producto_precios_Precio4_conImp = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Producto_precios_Precio5_conImp;
        [XmlAttribute]
        public decimal? Producto_precios_Precio5_conImp { get => _Producto_precios_Precio5_conImp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Precio5_conImp)) { _Producto_precios_Precio5_conImp = value ?? 0; OnPropertyChanged(); } } }


        private decimal? _Producto_precios_caja_conImp;
        [XmlAttribute]
        public decimal? Producto_precios_caja_conImp { get => _Producto_precios_caja_conImp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_caja_conImp)) { _Producto_precios_caja_conImp = value ?? 0; OnPropertyChanged(); } } }




        private decimal? _Producto_precios_Costorepoconutilimp;
        [XmlAttribute]
        public decimal? Producto_precios_Costorepoconutilimp { get => _Producto_precios_Costorepoconutilimp ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Costorepoconutilimp)) { _Producto_precios_Costorepoconutilimp = value ?? 0; OnPropertyChanged(); } } }


        private decimal? _Producto_precios_Preciomediomayoreocontarjeta;
        [XmlAttribute]
        public decimal? Producto_precios_Preciomediomayoreocontarjeta { get => _Producto_precios_Preciomediomayoreocontarjeta ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Preciomediomayoreocontarjeta)) { _Producto_precios_Preciomediomayoreocontarjeta = value ?? 0; OnPropertyChanged(); } } }



        private decimal? _Producto_precios_Preciomayoreocontarjeta;
        [XmlAttribute]
        public decimal? Producto_precios_Preciomayoreocontarjeta { get => _Producto_precios_Preciomayoreocontarjeta ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Preciomayoreocontarjeta)) { _Producto_precios_Preciomayoreocontarjeta = value ?? 0; OnPropertyChanged(); } } }



        private decimal? _Producto_inventario_ExistenciaCajas;
        [XmlAttribute]
        public decimal? Producto_inventario_ExistenciaCajas { get => _Producto_inventario_ExistenciaCajas ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_ExistenciaCajas)) { _Producto_inventario_ExistenciaCajas = value ?? 0; OnPropertyChanged(); } } }



        private decimal? _Producto_inventario_ExistenciaPiezas;
        [XmlAttribute]
        public decimal? Producto_inventario_ExistenciaPiezas { get => _Producto_inventario_ExistenciaPiezas ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_ExistenciaPiezas)) { _Producto_inventario_ExistenciaPiezas = value ?? 0; OnPropertyChanged(); } } }



        private decimal? _Producto_inventario_Pzacaja;
        [XmlAttribute]
        public decimal? Producto_inventario_Pzacaja { get => _Producto_inventario_Pzacaja ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_inventario_Pzacaja)) { _Producto_inventario_Pzacaja = value ?? 0; OnPropertyChanged(); } } }



        private decimal? _Producto_precios_Limiteprecio2;
        [XmlAttribute]
        public decimal? Producto_precios_Limiteprecio2 { get => _Producto_precios_Limiteprecio2 ?? 0; set { if (RaiseAcceptPendingChange(value, _Producto_precios_Limiteprecio2)) { _Producto_precios_Limiteprecio2 = value ?? 0; OnPropertyChanged(); } } }


        private string? _Productocaracteristicas_Texto1;
        [XmlAttribute]
        public string? Productocaracteristicas_Texto1 { get => _Productocaracteristicas_Texto1; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Texto1)) { _Productocaracteristicas_Texto1 = value; OnPropertyChanged(); } } }

        private string? _Productocaracteristicas_Texto2;
        [XmlAttribute]
        public string? Productocaracteristicas_Texto2 { get => _Productocaracteristicas_Texto2; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Texto2)) { _Productocaracteristicas_Texto2 = value; OnPropertyChanged(); } } }

        private string? _Productocaracteristicas_Texto3;
        [XmlAttribute]
        public string? Productocaracteristicas_Texto3 { get => _Productocaracteristicas_Texto3; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Texto3)) { _Productocaracteristicas_Texto3 = value; OnPropertyChanged(); } } }

        private string? _Productocaracteristicas_Texto4;
        [XmlAttribute]
        public string? Productocaracteristicas_Texto4 { get => _Productocaracteristicas_Texto4; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Texto4)) { _Productocaracteristicas_Texto4 = value; OnPropertyChanged(); } } }

        private string? _Productocaracteristicas_Texto5;
        [XmlAttribute]
        public string? Productocaracteristicas_Texto5 { get => _Productocaracteristicas_Texto5; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Texto5)) { _Productocaracteristicas_Texto5 = value; OnPropertyChanged(); } } }

        private string? _Productocaracteristicas_Texto6;
        [XmlAttribute]
        public string? Productocaracteristicas_Texto6 { get => _Productocaracteristicas_Texto6; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Texto6)) { _Productocaracteristicas_Texto6 = value; OnPropertyChanged(); } } }

        private decimal? _Productocaracteristicas_Numero1;
        [XmlAttribute]
        public decimal? Productocaracteristicas_Numero1 { get => _Productocaracteristicas_Numero1; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Numero1)) { _Productocaracteristicas_Numero1 = value; OnPropertyChanged(); } } }

        private decimal? _Productocaracteristicas_Numero2;
        [XmlAttribute]
        public decimal? Productocaracteristicas_Numero2 { get => _Productocaracteristicas_Numero2; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Numero2)) { _Productocaracteristicas_Numero2 = value; OnPropertyChanged(); } } }

        private decimal? _Productocaracteristicas_Numero3;
        [XmlAttribute]
        public decimal? Productocaracteristicas_Numero3 { get => _Productocaracteristicas_Numero3; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Numero3)) { _Productocaracteristicas_Numero3 = value; OnPropertyChanged(); } } }

        private decimal? _Productocaracteristicas_Numero4;
        [XmlAttribute]
        public decimal? Productocaracteristicas_Numero4 { get => _Productocaracteristicas_Numero4; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Numero4)) { _Productocaracteristicas_Numero4 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Productocaracteristicas_Fecha1;
        [XmlAttribute]
        public DateTimeOffset? Productocaracteristicas_Fecha1 { get => _Productocaracteristicas_Fecha1; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Fecha1)) { _Productocaracteristicas_Fecha1 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Productocaracteristicas_Fecha2;
        [XmlAttribute]
        public DateTimeOffset? Productocaracteristicas_Fecha2 { get => _Productocaracteristicas_Fecha2; set { if (RaiseAcceptPendingChange(value, _Productocaracteristicas_Fecha2)) { _Productocaracteristicas_Fecha2 = value; OnPropertyChanged(); } } }


        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Producto"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombre|Descripcion|Ean|Descripcion1|Descripcion2|Descripcion3|Cbarras|Cempaque|Plug|Proveedor1.Clave|Proveedor1.Nombre|Proveedor2.Clave|Proveedor2.Nombre|Linea.Clave|Linea.Nombre|Marca.Clave|Marca.Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Producto item)
        {

            this._Proveedor1Clave = item.Proveedor1?.Clave;

            this._Proveedor1Nombre = item.Proveedor1?.Nombre;

            this._Proveedor2Clave = item.Proveedor2?.Clave;

            this._Proveedor2Nombre = item.Proveedor2?.Nombre;

            this._LineaClave = item.Linea?.Clave;

            this._LineaNombre = item.Linea?.Nombre;

            this._MarcaClave = item.Marca?.Clave;

            this._MarcaNombre = item.Marca?.Nombre;

            this._UnidadClave = item.Unidad?.Clave;

            this._UnidadNombre = item.Unidad?.Nombre;


        }


        public void FillEntityValues(ref Producto item)
        {


            item.CreadoPorId = CreadoPorId;


            item.ModificadoPorId = ModificadoPorId;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";


            item.Descripcion = Descripcion ?? "";


            item.Ean = Ean;


            item.Descripcion1 = Descripcion1;


            item.Descripcion2 = Descripcion2;


            item.Descripcion3 = Descripcion3;


            item.Cbarras = Cbarras;


            item.Cempaque = Cempaque;


            item.Plug = Plug;


            item.Proveedor1id = Proveedor1id;


            item.Proveedor2id = Proveedor2id;


            item.Lineaid = Lineaid;


            item.Marcaid = Marcaid;


            item.Unidadid = Unidadid;


            item.Ivaimpuesto = Ivaimpuesto ?? 0;


            item.Iepsimpuesto = Iepsimpuesto ?? 0;



            if (item.Producto_existencia != null)
                item.Producto_existencia!.Existencia = Producto_existencia_Existencia ?? 0;
            else if (item.Producto_existencia == null && Producto_existencia_Existencia != null)
            {
                item.Producto_existencia = CreateSubEntity<Producto_existencia>();
                item.Producto_existencia!.Existencia = Producto_existencia_Existencia ?? 0;
            }

            if (item.Producto_existencia != null)
                item.Producto_existencia!.Enprocesodesalida = Producto_existencia_Enprocesodesalida ?? 0;
            else if (item.Producto_existencia == null && Producto_existencia_Enprocesodesalida != null)
            {
                item.Producto_existencia = CreateSubEntity<Producto_existencia>();
                item.Producto_existencia!.Enprocesodesalida = Producto_existencia_Enprocesodesalida ?? 0;
            }


            if (item.Producto_inventario != null)
                item.Producto_inventario!.Inventariable = Producto_inventario_Inventariable ?? BoolCS.S;
            else if (item.Producto_inventario == null && Producto_inventario_Inventariable != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Inventariable = Producto_inventario_Inventariable ?? BoolCS.S;
            }

            if (item.Producto_inventario != null)
                item.Producto_inventario!.Negativos = Producto_inventario_Negativos ?? BoolCN.N;
            else if (item.Producto_inventario == null && Producto_inventario_Negativos != null)
            {
                item.Producto_inventario = CreateSubEntity<Producto_inventario>();
                item.Producto_inventario!.Negativos = Producto_inventario_Negativos ?? BoolCN.N;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Precio1 = Producto_precios_Precio1 ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Precio1 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Precio1 = Producto_precios_Precio1 ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Precio2 = Producto_precios_Precio2 ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Precio2 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Precio2 = Producto_precios_Precio2 ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Precio3 = Producto_precios_Precio3 ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Precio3 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Precio3 = Producto_precios_Precio3 ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Precio4 = Producto_precios_Precio4 ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Precio4 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Precio4 = Producto_precios_Precio4 ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Precio5 = Producto_precios_Precio5 ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Precio5 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Precio5 = Producto_precios_Precio5 ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Precio6 = Producto_precios_Precio6 ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Precio6 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Precio6 = Producto_precios_Precio6 ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Costoultimo = Producto_precios_Costoultimo ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Costoultimo != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Costoultimo = Producto_precios_Costoultimo ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Costopromedio = Producto_precios_Costopromedio ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Costopromedio != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Costopromedio = Producto_precios_Costopromedio ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Costorepo = Producto_precios_Costorepo ?? 0;
            else if (item.Producto_precios == null && Producto_precios_Costorepo != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Costorepo = Producto_precios_Costorepo ?? 0;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Superprecio1 = Producto_precios_Superprecio1;
            else if (item.Producto_precios == null && Producto_precios_Superprecio1 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Superprecio1 = Producto_precios_Superprecio1;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Superprecio2 = Producto_precios_Superprecio2;
            else if (item.Producto_precios == null && Producto_precios_Superprecio2 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Superprecio2 = Producto_precios_Superprecio2;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Superprecio3 = Producto_precios_Superprecio3;
            else if (item.Producto_precios == null && Producto_precios_Superprecio3 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Superprecio3 = Producto_precios_Superprecio3;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Superprecio4 = Producto_precios_Superprecio4;
            else if (item.Producto_precios == null && Producto_precios_Superprecio4 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Superprecio4 = Producto_precios_Superprecio4;
            }

            if (item.Producto_precios != null)
                item.Producto_precios!.Superprecio5 = Producto_precios_Superprecio5;
            else if (item.Producto_precios == null && Producto_precios_Superprecio5 != null)
            {
                item.Producto_precios = CreateSubEntity<Producto_precios>();
                item.Producto_precios!.Superprecio5 = Producto_precios_Superprecio5;
            }

            

        }

        public void FillFromEntity(Producto item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Clave = item.Clave;

            Nombre = item.Nombre;

            Descripcion = item.Descripcion;

            Ean = item.Ean;

            Descripcion1 = item.Descripcion1;

            Descripcion2 = item.Descripcion2;

            Descripcion3 = item.Descripcion3;

            Cbarras = item.Cbarras;

            Cempaque = item.Cempaque;

            Plug = item.Plug;

            Proveedor1id = item.Proveedor1id;

            Proveedor2id = item.Proveedor2id;

            Lineaid = item.Lineaid;

            Marcaid = item.Marcaid;

            Unidadid = item.Unidadid;

            Ivaimpuesto = item.Ivaimpuesto;

            Iepsimpuesto = item.Iepsimpuesto;


            if (item.Producto_existencia != null && item.Producto_existencia?.Existencia != null)
                Producto_existencia_Existencia = item.Producto_existencia!.Existencia;

            if (item.Producto_existencia != null && item.Producto_existencia?.Enprocesodesalida != null)
                Producto_existencia_Enprocesodesalida = item.Producto_existencia!.Enprocesodesalida;

            if (item.Producto_inventario != null && item.Producto_inventario?.Inventariable != null)
                Producto_inventario_Inventariable = item.Producto_inventario!.Inventariable;

            if (item.Producto_inventario != null && item.Producto_inventario?.Negativos != null)
                Producto_inventario_Negativos = item.Producto_inventario!.Negativos;

            if (item.Producto_precios != null && item.Producto_precios?.Precio1 != null)
                Producto_precios_Precio1 = item.Producto_precios!.Precio1;

            if (item.Producto_precios != null && item.Producto_precios?.Precio2 != null)
                Producto_precios_Precio2 = item.Producto_precios!.Precio2;

            if (item.Producto_precios != null && item.Producto_precios?.Precio3 != null)
                Producto_precios_Precio3 = item.Producto_precios!.Precio3;

            if (item.Producto_precios != null && item.Producto_precios?.Precio4 != null)
                Producto_precios_Precio4 = item.Producto_precios!.Precio4;

            if (item.Producto_precios != null && item.Producto_precios?.Precio5 != null)
                Producto_precios_Precio5 = item.Producto_precios!.Precio5;

            if (item.Producto_precios != null && item.Producto_precios?.Precio6 != null)
                Producto_precios_Precio6 = item.Producto_precios!.Precio6;

            if (item.Producto_precios != null && item.Producto_precios?.Costoultimo != null)
                Producto_precios_Costoultimo = item.Producto_precios!.Costoultimo;

            if (item.Producto_precios != null && item.Producto_precios?.Costopromedio != null)
                Producto_precios_Costopromedio = item.Producto_precios!.Costopromedio;

            if (item.Producto_precios != null && item.Producto_precios?.Costorepo != null)
                Producto_precios_Costorepo = item.Producto_precios!.Costorepo;

            if (item.Producto_precios != null && item.Producto_precios?.Superprecio1 != null)
                Producto_precios_Superprecio1 = item.Producto_precios!.Superprecio1;

            if (item.Producto_precios != null && item.Producto_precios?.Superprecio2 != null)
                Producto_precios_Superprecio2 = item.Producto_precios!.Superprecio2;

            if (item.Producto_precios != null && item.Producto_precios?.Superprecio3 != null)
                Producto_precios_Superprecio3 = item.Producto_precios!.Superprecio3;

            if (item.Producto_precios != null && item.Producto_precios?.Superprecio4 != null)
                Producto_precios_Superprecio4 = item.Producto_precios!.Superprecio4;

            if (item.Producto_precios != null && item.Producto_precios?.Superprecio5 != null)
                Producto_precios_Superprecio5 = item.Producto_precios!.Superprecio5;



             FillCatalogRelatedFields(item);


        }

    private decimal? PrecioXListaPrecio(Tipoprecio? tipoPrecio)
    {
        decimal? bufferPrecio;

        switch (tipoPrecio?.Clave)
        {
            case "PRECIO 1": bufferPrecio = Producto_precios_Precio1; break;
            case "PRECIO 2": bufferPrecio = Producto_precios_Precio2; break;
            case "PRECIO 3": bufferPrecio = Producto_precios_Precio3; break;
            case "PRECIO 4": bufferPrecio = Producto_precios_Precio4; break;
            case "PRECIO 5": bufferPrecio = Producto_precios_Precio5; break;
            default: bufferPrecio = Producto_precios_Precio1; break;

        }

        return bufferPrecio;
    }
        #endif



    public ProductoBindingModel CastAsProductoBinding()
        {

            return new ProductoBindingModel()
            {

                CreadoPorId = this.CreadoPorId,

                ModificadoPorId = this.ModificadoPorId,

                EmpresaId = this.EmpresaId,

                SucursalId = this.SucursalId,

                Id = this.Id,

                Activo = this.Activo,

                Creado = this.Creado,

                Modificado = this.Modificado,

                Clave = this.Clave,

                Nombre = this.Nombre,

                Descripcion = this.Descripcion,

                Ean = this.Ean,

                Descripcion1 = this.Descripcion1,

                Descripcion2 = this.Descripcion2,

                Descripcion3 = this.Descripcion3
            };

        }


    }
}

