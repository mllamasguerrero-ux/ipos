
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
    
    public class MaxfactBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public MaxfactBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public MaxfactBindingModelGenerated(Maxfact item)
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

        private string? _Sucursalclave;
        [XmlAttribute]
        public string? Sucursalclave { get => _Sucursalclave; set { if (RaiseAcceptPendingChange(value, _Sucursalclave)) { _Sucursalclave = value; OnPropertyChanged(); } } }

        private BoolCN? _Lun_hay;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Lun_hay { get => _Lun_hay?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Lun_hay)) { _Lun_hay = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Mar_hay;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Mar_hay { get => _Mar_hay?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Mar_hay)) { _Mar_hay = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Mie_hay;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Mie_hay { get => _Mie_hay?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Mie_hay)) { _Mie_hay = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Jue_hay;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Jue_hay { get => _Jue_hay?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Jue_hay)) { _Jue_hay = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Vie_hay;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Vie_hay { get => _Vie_hay?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Vie_hay)) { _Vie_hay = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Sab_hay;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Sab_hay { get => _Sab_hay?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Sab_hay)) { _Sab_hay = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Dom_hay;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Dom_hay { get => _Dom_hay?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Dom_hay)) { _Dom_hay = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _Anio;
        [XmlAttribute]
        public int? Anio { get => _Anio; set { if (RaiseAcceptPendingChange(value, _Anio)) { _Anio = value; OnPropertyChanged(); } } }

        private int? _Mes;
        [XmlAttribute]
        public int? Mes { get => _Mes; set { if (RaiseAcceptPendingChange(value, _Mes)) { _Mes = value; OnPropertyChanged(); } } }

        private decimal? _Lun_max;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Lun_max { get => _Lun_max?? 0; set { if (RaiseAcceptPendingChange(value, _Lun_max)) { _Lun_max = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Mar_max;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Mar_max { get => _Mar_max?? 0; set { if (RaiseAcceptPendingChange(value, _Mar_max)) { _Mar_max = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Mie_max;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Mie_max { get => _Mie_max?? 0; set { if (RaiseAcceptPendingChange(value, _Mie_max)) { _Mie_max = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Jue_max;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Jue_max { get => _Jue_max?? 0; set { if (RaiseAcceptPendingChange(value, _Jue_max)) { _Jue_max = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Vie_max;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Vie_max { get => _Vie_max?? 0; set { if (RaiseAcceptPendingChange(value, _Vie_max)) { _Vie_max = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Sab_max;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Sab_max { get => _Sab_max?? 0; set { if (RaiseAcceptPendingChange(value, _Sab_max)) { _Sab_max = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Dom_max;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Dom_max { get => _Dom_max?? 0; set { if (RaiseAcceptPendingChange(value, _Dom_max)) { _Dom_max = value?? 0; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Maxfact"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Sucursalclave";
        }


        #if PROYECTO_WEB
        
        public void FillCatalogRelatedFields(Maxfact item)
        {


        }


        public void FillEntityValues(ref Maxfact item)
        {


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Sucursalclave = Sucursalclave ;


            item.Lun_hay = Lun_hay ?? BoolCN.N;


            item.Mar_hay = Mar_hay ?? BoolCN.N;


            item.Mie_hay = Mie_hay ?? BoolCN.N;


            item.Jue_hay = Jue_hay ?? BoolCN.N;


            item.Vie_hay = Vie_hay ?? BoolCN.N;


            item.Sab_hay = Sab_hay ?? BoolCN.N;


            item.Dom_hay = Dom_hay ?? BoolCN.N;


            item.Anio = Anio ;


            item.Mes = Mes ;


            item.Lun_max = Lun_max ?? 0;


            item.Mar_max = Mar_max ?? 0;


            item.Mie_max = Mie_max ?? 0;


            item.Jue_max = Jue_max ?? 0;


            item.Vie_max = Vie_max ?? 0;


            item.Sab_max = Sab_max ?? 0;


            item.Dom_max = Dom_max ?? 0;



        }

        public void FillFromEntity(Maxfact item)
        {

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Sucursalclave = item.Sucursalclave;

            Lun_hay = item.Lun_hay;

            Mar_hay = item.Mar_hay;

            Mie_hay = item.Mie_hay;

            Jue_hay = item.Jue_hay;

            Vie_hay = item.Vie_hay;

            Sab_hay = item.Sab_hay;

            Dom_hay = item.Dom_hay;

            Anio = item.Anio;

            Mes = item.Mes;

            Lun_max = item.Lun_max;

            Mar_max = item.Mar_max;

            Mie_max = item.Mie_max;

            Jue_max = item.Jue_max;

            Vie_max = item.Vie_max;

            Sab_max = item.Sab_max;

            Dom_max = item.Dom_max;


             FillCatalogRelatedFields(item);


        }
        #endif



    }
}

