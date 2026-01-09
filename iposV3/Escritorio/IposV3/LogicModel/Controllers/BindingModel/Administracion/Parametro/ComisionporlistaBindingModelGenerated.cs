
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
    
    public class ComisionporlistaBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public ComisionporlistaBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public ComisionporlistaBindingModelGenerated(Comisionporlista item)
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

        private decimal? _Precio1;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Precio1 { get => _Precio1?? 0; set { if (RaiseAcceptPendingChange(value, _Precio1)) { _Precio1 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Precio2;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Precio2 { get => _Precio2?? 0; set { if (RaiseAcceptPendingChange(value, _Precio2)) { _Precio2 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Precio3;
        [XmlAttribute]
        public decimal? Precio3 { get => _Precio3; set { if (RaiseAcceptPendingChange(value, _Precio3)) { _Precio3 = value; OnPropertyChanged(); } } }

        private decimal? _Precio4;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Precio4 { get => _Precio4?? 0; set { if (RaiseAcceptPendingChange(value, _Precio4)) { _Precio4 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Precio5;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Precio5 { get => _Precio5?? 0; set { if (RaiseAcceptPendingChange(value, _Precio5)) { _Precio5 = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Preciootro;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Preciootro { get => _Preciootro?? 0; set { if (RaiseAcceptPendingChange(value, _Preciootro)) { _Preciootro = value?? 0; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Comisionporlista"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Comisionporlista item)
        {


        }


        public void FillEntityValues(ref Comisionporlista item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Precio1 = Precio1 ?? 0;


            item.Precio2 = Precio2 ?? 0;


            item.Precio3 = Precio3 ;


            item.Precio4 = Precio4 ?? 0;


            item.Precio5 = Precio5 ?? 0;


            item.Preciootro = Preciootro ?? 0;



        }

        public void FillFromEntity(Comisionporlista item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Precio1 = item.Precio1;

            Precio2 = item.Precio2;

            Precio3 = item.Precio3;

            Precio4 = item.Precio4;

            Precio5 = item.Precio5;

            Preciootro = item.Preciootro;


             FillCatalogRelatedFields(item);


        }
        #endif




    }
}

