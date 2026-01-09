
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
    
    public class UnidadBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public UnidadBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public UnidadBindingModelGenerated(Unidad item)
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
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

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

        private string? _Clave;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Clave { get => _Clave?? ""; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value?? ""; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get => _Nombre?? ""; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value?? ""; OnPropertyChanged(); } } }

        private short? _CantidadDecimales;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public short? CantidadDecimales { get => _CantidadDecimales?? 0; set { if (RaiseAcceptPendingChange(value, _CantidadDecimales)) { _CantidadDecimales = value?? 0; OnPropertyChanged(); } } }

        private long? _Sat_unidadmedidaid;
        [XmlAttribute]
        public long? Sat_unidadmedidaid { get => _Sat_unidadmedidaid; set { if (RaiseAcceptPendingChange(value, _Sat_unidadmedidaid)) { _Sat_unidadmedidaid = value; OnPropertyChanged(); } } }

        private string? _Sat_unidadmedidaClave;
        [XmlAttribute]
        public string? Sat_unidadmedidaClave { get => _Sat_unidadmedidaClave; set { if (RaiseAcceptPendingChange(value, _Sat_unidadmedidaClave)) { _Sat_unidadmedidaClave = value; OnPropertyChanged(); } } }

        private string? _Sat_unidadmedidaNombre;
        [XmlAttribute]
        public string? Sat_unidadmedidaNombre { get => _Sat_unidadmedidaNombre; set { if (RaiseAcceptPendingChange(value, _Sat_unidadmedidaNombre)) { _Sat_unidadmedidaNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Unidad"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombre|Sat_unidadmedida.Clave|Sat_unidadmedida.Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Unidad item)
        {

             this._Sat_unidadmedidaClave = item.Sat_unidadmedida?.Clave;

             this._Sat_unidadmedidaNombre = item.Sat_unidadmedida?.Nombre;


        }


        public void FillEntityValues(ref Unidad item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";


            item.CantidadDecimales = CantidadDecimales ?? 0;


            item.Sat_unidadmedidaid = Sat_unidadmedidaid ;



        }

        public void FillFromEntity(Unidad item)
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

            CantidadDecimales = item.CantidadDecimales;

            Sat_unidadmedidaid = item.Sat_unidadmedidaid;


             FillCatalogRelatedFields(item);


        }
        #endif



    }
}

