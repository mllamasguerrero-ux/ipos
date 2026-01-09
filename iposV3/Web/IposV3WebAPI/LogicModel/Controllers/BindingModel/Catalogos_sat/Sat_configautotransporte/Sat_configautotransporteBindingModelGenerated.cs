
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
    
    public class Sat_configautotransporteBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public Sat_configautotransporteBindingModelGenerated()
        {
        }

        #if PROYECTO_WEB
        public Sat_configautotransporteBindingModelGenerated(Sat_configautotransporte item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }

        #endif


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

        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Descripcion { get => _Descripcion?? ""; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value?? ""; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechainicio;
        [XmlAttribute]
        public DateTimeOffset? Fechainicio { get => _Fechainicio; set { if (RaiseAcceptPendingChange(value, _Fechainicio)) { _Fechainicio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechafin;
        [XmlAttribute]
        public DateTimeOffset? Fechafin { get => _Fechafin; set { if (RaiseAcceptPendingChange(value, _Fechafin)) { _Fechafin = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        private string? _Numeroejes;
        [XmlAttribute]
        public string? Numeroejes { get => _Numeroejes; set { if (RaiseAcceptPendingChange(value, _Numeroejes)) { _Numeroejes = value; OnPropertyChanged(); } } }

        private string? _Numerollantas;
        [XmlAttribute]
        public string? Numerollantas { get => _Numerollantas; set { if (RaiseAcceptPendingChange(value, _Numerollantas)) { _Numerollantas = value; OnPropertyChanged(); } } }

        private string? _Remolque;
        [XmlAttribute]
        public string? Remolque { get => _Remolque; set { if (RaiseAcceptPendingChange(value, _Remolque)) { _Remolque = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Sat_configautotransporte"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Descripcion|Nombre|Numeroejes|Numerollantas|Remolque";
        }



        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Sat_configautotransporte item)
        {


        }


        public void FillEntityValues(ref Sat_configautotransporte item)
        {


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.Clave = Clave ?? "";


            item.Descripcion = Descripcion ?? "";


            item.Fechainicio = Fechainicio ;


            item.Fechafin = Fechafin ;


            item.Nombre = Nombre ?? "";


            item.Numeroejes = Numeroejes ;


            item.Numerollantas = Numerollantas ;


            item.Remolque = Remolque ;



        }

        public void FillFromEntity(Sat_configautotransporte item)
        {

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            Clave = item.Clave;

            Descripcion = item.Descripcion;

            Fechainicio = item.Fechainicio;

            Fechafin = item.Fechafin;

            Nombre = item.Nombre;

            Numeroejes = item.Numeroejes;

            Numerollantas = item.Numerollantas;

            Remolque = item.Remolque;


             FillCatalogRelatedFields(item);


        }
        #endif




    }
}

