
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

    public class PlazoBindingModelGenerated : Validatable, IBaseBindingModel

    {

        public PlazoBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public PlazoBindingModelGenerated(Plazo item)
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
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId ?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value ?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
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
        [Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Creado { get => _Creado ?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value ?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public DateTimeOffset? Modificado { get => _Modificado ?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value ?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Comisionista;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Comisionista { get => _Comisionista ?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Comisionista)) { _Comisionista = value ?? BoolCN.N; OnPropertyChanged(); } } }

        private string? _Leyenda;
        [XmlAttribute]
        public string? Leyenda { get => _Leyenda; set { if (RaiseAcceptPendingChange(value, _Leyenda)) { _Leyenda = value; OnPropertyChanged(); } } }

        private int? _Dias;
        [XmlAttribute]
        public int? Dias { get => _Dias; set { if (RaiseAcceptPendingChange(value, _Dias)) { _Dias = value; OnPropertyChanged(); } } }

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

            return $@"SELECT * FROM ""Plazo"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombre|Leyenda|Almacen.Clave|Almacen.Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Plazo item)
        {

            this._AlmacenClave = item.Almacen?.Clave;

            this._AlmacenNombre = item.Almacen?.Nombre;


        }


        public void FillEntityValues(ref Plazo item)
        {


            item.CreadoPorId = CreadoPorId;


            item.ModificadoPorId = ModificadoPorId;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clave = Clave;


            item.Nombre = Nombre;


            item.Comisionista = Comisionista ?? BoolCN.N;


            item.Leyenda = Leyenda;


            item.Dias = Dias;


            item.Almacenid = Almacenid;



        }

        public void FillFromEntity(Plazo item)
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

            Comisionista = item.Comisionista;

            Leyenda = item.Leyenda;

            Dias = item.Dias;

            Almacenid = item.Almacenid;


            FillCatalogRelatedFields(item);


        }
        #endif



    }
}

