
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
    
    public class Sat_usocfdiBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public Sat_usocfdiBindingModelGenerated()
        {
        }

        #if PROYECTO_WEB
        public Sat_usocfdiBindingModelGenerated(Sat_usocfdi item)
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

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }

        private string? _Sat_clave;
        [XmlAttribute]
        public string? Sat_clave { get => _Sat_clave; set { if (RaiseAcceptPendingChange(value, _Sat_clave)) { _Sat_clave = value; OnPropertyChanged(); } } }

        private string? _Sat_descripcion;
        [XmlAttribute]
        public string? Sat_descripcion { get => _Sat_descripcion; set { if (RaiseAcceptPendingChange(value, _Sat_descripcion)) { _Sat_descripcion = value; OnPropertyChanged(); } } }

        private string? _Sat_personafisica;
        [XmlAttribute]
        public string? Sat_personafisica { get => _Sat_personafisica; set { if (RaiseAcceptPendingChange(value, _Sat_personafisica)) { _Sat_personafisica = value; OnPropertyChanged(); } } }

        private string? _Sat_personamoral;
        [XmlAttribute]
        public string? Sat_personamoral { get => _Sat_personamoral; set { if (RaiseAcceptPendingChange(value, _Sat_personamoral)) { _Sat_personamoral = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Sat_fechainicio;
        [XmlAttribute]
        public DateTimeOffset? Sat_fechainicio { get => _Sat_fechainicio; set { if (RaiseAcceptPendingChange(value, _Sat_fechainicio)) { _Sat_fechainicio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Sat_fechafin;
        [XmlAttribute]
        public DateTimeOffset? Sat_fechafin { get => _Sat_fechafin; set { if (RaiseAcceptPendingChange(value, _Sat_fechafin)) { _Sat_fechafin = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Sat_usocfdi""  ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombre|Sat_clave|Sat_descripcion|Sat_personafisica|Sat_personamoral";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Sat_usocfdi item)
        {


        }


        public void FillEntityValues(ref Sat_usocfdi item)
        {


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.Sat_clave = Sat_clave ;


            item.Sat_descripcion = Sat_descripcion ;


            item.Sat_personafisica = Sat_personafisica ;


            item.Sat_personamoral = Sat_personamoral ;


            item.Sat_fechainicio = Sat_fechainicio ;


            item.Sat_fechafin = Sat_fechafin ;



        }

        public void FillFromEntity(Sat_usocfdi item)
        {

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Clave = item.Clave;

            Nombre = item.Nombre;

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            Sat_clave = item.Sat_clave;

            Sat_descripcion = item.Sat_descripcion;

            Sat_personafisica = item.Sat_personafisica;

            Sat_personamoral = item.Sat_personamoral;

            Sat_fechainicio = item.Sat_fechainicio;

            Sat_fechafin = item.Sat_fechafin;


             FillCatalogRelatedFields(item);


        }

        #endif




    }
}

