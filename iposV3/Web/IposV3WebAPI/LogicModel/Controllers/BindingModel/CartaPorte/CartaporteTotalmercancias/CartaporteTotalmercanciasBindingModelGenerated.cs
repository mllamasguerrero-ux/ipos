
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
    
    public class CartaporteTotalmercanciasBindingModelGenerated : Validatable, IBaseBindingModel
    
    {
        
        public CartaporteTotalmercanciasBindingModelGenerated()
        {
        }



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

        private long? _Cartaporteid;
        [XmlAttribute]
        public long? Cartaporteid { get => _Cartaporteid; set { if (RaiseAcceptPendingChange(value, _Cartaporteid)) { _Cartaporteid = value; OnPropertyChanged(); } } }

        private string? _CartaporteClave;
        [XmlAttribute]
        public string? CartaporteClave { get => _CartaporteClave; set { if (RaiseAcceptPendingChange(value, _CartaporteClave)) { _CartaporteClave = value; OnPropertyChanged(); } } }

        private string? _CartaporteNombre;
        [XmlAttribute]
        public string? CartaporteNombre { get => _CartaporteNombre; set { if (RaiseAcceptPendingChange(value, _CartaporteNombre)) { _CartaporteNombre = value; OnPropertyChanged(); } } }

        private string? _Pesobrutototal;
        [XmlAttribute]
        public string? Pesobrutototal { get => _Pesobrutototal; set { if (RaiseAcceptPendingChange(value, _Pesobrutototal)) { _Pesobrutototal = value; OnPropertyChanged(); } } }

        private string? _Unidadpeso;
        [XmlAttribute]
        public string? Unidadpeso { get => _Unidadpeso; set { if (RaiseAcceptPendingChange(value, _Unidadpeso)) { _Unidadpeso = value; OnPropertyChanged(); } } }

        private string? _Pesonetototal;
        [XmlAttribute]
        public string? Pesonetototal { get => _Pesonetototal; set { if (RaiseAcceptPendingChange(value, _Pesonetototal)) { _Pesonetototal = value; OnPropertyChanged(); } } }

        private string? _Numtotalmercancias;
        [XmlAttribute]
        public string? Numtotalmercancias { get => _Numtotalmercancias; set { if (RaiseAcceptPendingChange(value, _Numtotalmercancias)) { _Numtotalmercancias = value; OnPropertyChanged(); } } }

        private string? _Cargoportasacion;
        [XmlAttribute]
        public string? Cargoportasacion { get => _Cargoportasacion; set { if (RaiseAcceptPendingChange(value, _Cargoportasacion)) { _Cargoportasacion = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {

            return $@"SELECT * FROM ""CartaporteTotalmercancias"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";

        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"Cartaporte.Clave|Cartaporte.Nombre|Pesobrutototal|Unidadpeso|Pesonetototal|Numtotalmercancias|Cargoportasacion";
        }




    }
}

