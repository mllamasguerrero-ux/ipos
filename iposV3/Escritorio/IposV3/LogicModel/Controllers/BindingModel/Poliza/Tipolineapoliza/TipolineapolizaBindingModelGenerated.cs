
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
    
    public class TipolineapolizaBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public TipolineapolizaBindingModelGenerated()
        {
        }
        
        #if PROYECTO_WEB
        public TipolineapolizaBindingModelGenerated(Tipolineapoliza item)
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

        private long? _EmpresaId;
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private long? _CreadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => _CreadoPorId; set { if (RaiseAcceptPendingChange(value, _CreadoPorId)) { _CreadoPorId = value; OnPropertyChanged(); } } }

        private long? _ModificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => _ModificadoPorId; set { if (RaiseAcceptPendingChange(value, _ModificadoPorId)) { _ModificadoPorId = value; OnPropertyChanged(); } } }

        private BoolCN? _Sumarizado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Sumarizado { get => _Sumarizado?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Sumarizado)) { _Sumarizado = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Manejatasa;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejatasa { get => _Manejatasa?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejatasa)) { _Manejatasa = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Manejaformapago;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejaformapago { get => _Manejaformapago?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejaformapago)) { _Manejaformapago = value?? BoolCN.N; OnPropertyChanged(); } } }

        private BoolCN? _Manejaesfact;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Manejaesfact { get => _Manejaesfact?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Manejaesfact)) { _Manejaesfact = value?? BoolCN.N; OnPropertyChanged(); } } }

        private int? _Orden;
        [XmlAttribute]
        public int? Orden { get => _Orden; set { if (RaiseAcceptPendingChange(value, _Orden)) { _Orden = value; OnPropertyChanged(); } } }

        private long? _Tipoentrada;
        [XmlAttribute]
        public long? Tipoentrada { get => _Tipoentrada; set { if (RaiseAcceptPendingChange(value, _Tipoentrada)) { _Tipoentrada = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""Tipolineapoliza"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Clave|Nombre";
        }


        #if PROYECTO_WEB
        public void FillCatalogRelatedFields(Tipolineapoliza item)
        {


        }


        public void FillEntityValues(ref Tipolineapoliza item)
        {


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clave = Clave ?? "";


            item.Nombre = Nombre ?? "";


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.CreadoPorId = CreadoPorId ;


            item.ModificadoPorId = ModificadoPorId ;


            item.Sumarizado = Sumarizado ?? BoolCN.N;


            item.Manejatasa = Manejatasa ?? BoolCN.N;


            item.Manejaformapago = Manejaformapago ?? BoolCN.N;


            item.Manejaesfact = Manejaesfact ?? BoolCN.N;


            item.Orden = Orden ;


            item.Tipoentrada = Tipoentrada ;



        }

        public void FillFromEntity(Tipolineapoliza item)
        {

            Id = item.Id;

            Activo = item.Activo;

            Creado = item.Creado;

            Modificado = item.Modificado;

            Clave = item.Clave;

            Nombre = item.Nombre;

            EmpresaId = item.EmpresaId;

            SucursalId = item.SucursalId;

            CreadoPorId = item.CreadoPorId;

            ModificadoPorId = item.ModificadoPorId;

            Sumarizado = item.Sumarizado;

            Manejatasa = item.Manejatasa;

            Manejaformapago = item.Manejaformapago;

            Manejaesfact = item.Manejaesfact;

            Orden = item.Orden;

            Tipoentrada = item.Tipoentrada;


             FillCatalogRelatedFields(item);


        }
        #endif
        



    }
}

