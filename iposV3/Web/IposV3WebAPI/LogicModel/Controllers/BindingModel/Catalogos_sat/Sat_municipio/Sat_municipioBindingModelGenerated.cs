
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
    
    public class Sat_municipioBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public Sat_municipioBindingModelGenerated()
        {
        }

        #if PROYECTO_WEB
        public Sat_municipioBindingModelGenerated(Sat_municipio item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }

        #endif


        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id?? 0; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value?? 0; OnPropertyChanged(); } } }

        private BoolCS? _Activo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute]
        public DateTimeOffset? Creado { get => _Creado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        public DateTimeOffset? Modificado { get => _Modificado?? DateTime.UtcNow; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value?? DateTime.UtcNow; OnPropertyChanged(); } } }

        private long? _EmpresaId;
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        private string? _Clave_municipio;
        [XmlAttribute]
        public string? Clave_municipio { get => _Clave_municipio; set { if (RaiseAcceptPendingChange(value, _Clave_municipio)) { _Clave_municipio = value; OnPropertyChanged(); } } }

        private string? _Clave_estado;
        [XmlAttribute]
        public string? Clave_estado { get => _Clave_estado; set { if (RaiseAcceptPendingChange(value, _Clave_estado)) { _Clave_estado = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Sat_municipio""  ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Nombre|Clave|Clave_municipio|Clave_estado|Descripcion";
        }



        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Sat_municipio item)
        {


        }


        public void FillEntityValues(ref Sat_municipio item)
        {


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Nombre = Nombre ?? "";


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.Clave = Clave ?? "";


            item.Clave_municipio = Clave_municipio ;


            item.Clave_estado = Clave_estado ;


            item.Descripcion = Descripcion ;



        }

        public void FillFromEntity(Sat_municipio item)
        {

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Nombre = item.Nombre;

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            Clave = item.Clave;

            Clave_municipio = item.Clave_municipio;

            Clave_estado = item.Clave_estado;

            Descripcion = item.Descripcion;


             FillCatalogRelatedFields(item);


        }
        #endif




    }
}

