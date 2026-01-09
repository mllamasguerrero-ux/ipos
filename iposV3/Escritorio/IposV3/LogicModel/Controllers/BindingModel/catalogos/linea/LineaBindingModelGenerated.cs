
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
    public class LineaBindingModelGenerated : Validatable, IBaseBindingModel
    {

        public LineaBindingModelGenerated()
        {
        }
        
        
        #if PROYECTO_WEB
        public LineaBindingModelGenerated(Linea item)
        {
            FillFromEntity(item);
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
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }






        private BoolCN? _Acumulapromocion;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN? Acumulapromocion { get => _Acumulapromocion; set { if (RaiseAcceptPendingChange(value, _Acumulapromocion)) { _Acumulapromocion = value; OnPropertyChanged(); } } }


        private BoolCS? _Aplicamayoreoxlinea;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCS? Aplicamayoreoxlinea { get => _Aplicamayoreoxlinea; set { if (RaiseAcceptPendingChange(value, _Aplicamayoreoxlinea)) { _Aplicamayoreoxlinea = value; OnPropertyChanged(); } } }




        private string? _Tiporecarga;
        [XmlAttribute]
        public string? Tiporecarga { get => _Tiporecarga; set { if (RaiseAcceptPendingChange(value, _Tiporecarga)) { _Tiporecarga = value; OnPropertyChanged(); } } }




        private string? _Gpoimp;
        [XmlAttribute]
        public string? Gpoimp { get => _Gpoimp; set { if (RaiseAcceptPendingChange(value, _Gpoimp)) { _Tiporecarga = value; OnPropertyChanged(); } } }



        private decimal? _Descuentovale;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public decimal? Descuentovale { get => _Descuentovale; set { if (RaiseAcceptPendingChange(value, _Descuentovale)) { _Descuentovale = value; OnPropertyChanged(); } } }


        public static string GetBaseQuery()
        {
            return $@"SELECT * FROM ""Linea"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";
        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"""Clave""|""Nombre""|""Gpoimp""";
        }


        #if PROYECTO_WEB
        public void FillEntityValues(ref Linea item)
        {
            item.Activo = this.Activo ?? BoolCS.S;
            item.SucursalId = this.SucursalId ?? 0;
            item.EmpresaId = this.EmpresaId ?? 0;
            item.Creado = this.Creado ?? DateTimeOffset.Now;
            item.CreadoPorId = this.CreadoPorId;
            item.Modificado = this.Modificado ?? DateTimeOffset.Now;
            item.ModificadoPorId = this.ModificadoPorId;
            item.Clave = this.Clave ?? "";
            item.Nombre = this.Nombre ?? "";
            item.Id = this.Id ?? 0;
            item.Acumulapromocion = this.Acumulapromocion ?? BoolCN.N;
            item.Aplicamayoreoxlinea = this.Aplicamayoreoxlinea ?? BoolCS.S;
            item.Tiporecarga = this.Tiporecarga;
            item.Gpoimp = this.Gpoimp;
            item.Descuentovale = this.Descuentovale ?? 0;
        }

        public void FillFromEntity(Linea item)
        {

            Activo = item.Activo;
            SucursalId = item.SucursalId;
            EmpresaId = item.EmpresaId;
            Creado = item.Creado;
            CreadoPorId = item.CreadoPorId;
            Modificado = item.Modificado;
            ModificadoPorId = item.ModificadoPorId;
            Clave = item.Clave;
            Nombre = item.Nombre;
            Id = item.Id;
            Acumulapromocion = item.Acumulapromocion ;
            Aplicamayoreoxlinea = item.Aplicamayoreoxlinea;
            Tiporecarga = item.Tiporecarga;
            Gpoimp = item.Gpoimp;
            Descuentovale = item.Descuentovale;
        }
#endif

    }
}

