
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
    
    public class ProductolocationsBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public ProductolocationsBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public ProductolocationsBindingModelGenerated(Productolocations item)
        {
            FillFromEntity(item);
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
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Id { get => _Id?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value?? 0; OnPropertyChanged(); } } }

        private BoolCS? _Activo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Creado { get => _Creado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Modificado { get => _Modificado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private string? _Localidad;
        [XmlAttribute]
        public string? Localidad { get => _Localidad; set { if (RaiseAcceptPendingChange(value, _Localidad)) { _Localidad = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _ProductoClave;
        [XmlAttribute]
        public string? ProductoClave { get => _ProductoClave; set { if (RaiseAcceptPendingChange(value, _ProductoClave)) { _ProductoClave = value; OnPropertyChanged(); } } }

        private string? _ProductoNombre;
        [XmlAttribute]
        public string? ProductoNombre { get => _ProductoNombre; set { if (RaiseAcceptPendingChange(value, _ProductoNombre)) { _ProductoNombre = value; OnPropertyChanged(); } } }

        private long? _Anaquelid;
        [XmlAttribute]
        public long? Anaquelid { get => _Anaquelid; set { if (RaiseAcceptPendingChange(value, _Anaquelid)) { _Anaquelid = value; OnPropertyChanged(); } } }

        private string? _AnaquelClave;
        [XmlAttribute]
        public string? AnaquelClave { get => _AnaquelClave; set { if (RaiseAcceptPendingChange(value, _AnaquelClave)) { _AnaquelClave = value; OnPropertyChanged(); } } }

        private string? _AnaquelNombre;
        [XmlAttribute]
        public string? AnaquelNombre { get => _AnaquelNombre; set { if (RaiseAcceptPendingChange(value, _AnaquelNombre)) { _AnaquelNombre = value; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private string? _AlmacenClave;
        [XmlAttribute]
        public string? AlmacenClave { get => _AlmacenClave; set { if (RaiseAcceptPendingChange(value, _AlmacenClave)) { _AlmacenClave = value; OnPropertyChanged(); } } }

        private string? _AlmacenNombre;
        [XmlAttribute]
        public string? AlmacenNombre { get => _AlmacenNombre; set { if (RaiseAcceptPendingChange(value, _AlmacenNombre)) { _AlmacenNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Productolocations"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Localidad|Producto.Clave|Producto.Nombre|Anaquel.Clave|Anaquel.Nombre|Almacen.Clave|Almacen.Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Productolocations item)
        {

             this._ProductoClave = item.Producto?.Clave;

             this._ProductoNombre = item.Producto?.Nombre;

             this._AnaquelClave = item.Anaquel?.Clave;

             this._AnaquelNombre = item.Anaquel?.Nombre;

             this._AlmacenClave = item.Almacen?.Clave;

             this._AlmacenNombre = item.Almacen?.Nombre;


        }


        public void FillEntityValues(ref Productolocations item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Localidad = Localidad ;


            item.Productoid = Productoid ;


            item.Anaquelid = Anaquelid ;


            item.Almacenid = Almacenid ;



        }

        public void FillFromEntity(Productolocations item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Localidad = item.Localidad;

            Productoid = item.Productoid;

            Anaquelid = item.Anaquelid;

            Almacenid = item.Almacenid;


             FillCatalogRelatedFields(item);


        }

        #endif
        


    }
}

