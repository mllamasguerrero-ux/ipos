
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
    public class Docto_solicitud_mercanciaWFBindingModel : Validatable
    {

        public Docto_solicitud_mercanciaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




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

        private long? _Estatusdoctoid;
        [XmlAttribute]
        public long? Estatusdoctoid { get => _Estatusdoctoid; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoid)) { _Estatusdoctoid = value; OnPropertyChanged(); } } }

        private string? _Estatusdoctoclave;
        [XmlAttribute]
        public string? Estatusdoctoclave { get => _Estatusdoctoclave; set { if (RaiseAcceptPendingChange(value, _Estatusdoctoclave)) { _Estatusdoctoclave = value; OnPropertyChanged(); } } }

        private string? _Estatusdoctonombre;
        [XmlAttribute]
        public string? Estatusdoctonombre { get => _Estatusdoctonombre; set { if (RaiseAcceptPendingChange(value, _Estatusdoctonombre)) { _Estatusdoctonombre = value; OnPropertyChanged(); } } }

        private long? _Usuarioid;
        [XmlAttribute]
        public long? Usuarioid { get => _Usuarioid; set { if (RaiseAcceptPendingChange(value, _Usuarioid)) { _Usuarioid = value; OnPropertyChanged(); } } }

        private string? _Usuarionombre;
        [XmlAttribute]
        public string? Usuarionombre { get => _Usuarionombre; set { if (RaiseAcceptPendingChange(value, _Usuarionombre)) { _Usuarionombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Serie;
        [XmlAttribute]
        public string? Serie { get => _Serie; set { if (RaiseAcceptPendingChange(value, _Serie)) { _Serie = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Importe { get => _Importe?? 0; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuento { get => _Descuento?? 0; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Subtotal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Subtotal { get => _Subtotal?? 0; set { if (RaiseAcceptPendingChange(value, _Subtotal)) { _Subtotal = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Iva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Iva { get => _Iva?? 0; set { if (RaiseAcceptPendingChange(value, _Iva)) { _Iva = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Ieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Ieps { get => _Ieps?? 0; set { if (RaiseAcceptPendingChange(value, _Ieps)) { _Ieps = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Total { get => _Total?? 0; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value?? 0; OnPropertyChanged(); } } }

        private long? _Cajaid;
        [XmlAttribute]
        public long? Cajaid { get => _Cajaid; set { if (RaiseAcceptPendingChange(value, _Cajaid)) { _Cajaid = value; OnPropertyChanged(); } } }

        private string? _Cajaclave;
        [XmlAttribute]
        public string? Cajaclave { get => _Cajaclave; set { if (RaiseAcceptPendingChange(value, _Cajaclave)) { _Cajaclave = value; OnPropertyChanged(); } } }

        private string? _Cajanombre;
        [XmlAttribute]
        public string? Cajanombre { get => _Cajanombre; set { if (RaiseAcceptPendingChange(value, _Cajanombre)) { _Cajanombre = value; OnPropertyChanged(); } } }

        private long? _Proveedorid;
        [XmlAttribute]
        public long? Proveedorid { get => _Proveedorid; set { if (RaiseAcceptPendingChange(value, _Proveedorid)) { _Proveedorid = value; OnPropertyChanged(); } } }

        private string? _Proveedorclave;
        [XmlAttribute]
        public string? Proveedorclave { get => _Proveedorclave; set { if (RaiseAcceptPendingChange(value, _Proveedorclave)) { _Proveedorclave = value; OnPropertyChanged(); } } }

        private string? _Proveedornombre;
        [XmlAttribute]
        public string? Proveedornombre { get => _Proveedornombre; set { if (RaiseAcceptPendingChange(value, _Proveedornombre)) { _Proveedornombre = value; OnPropertyChanged(); } } }

        private long? _Tipodoctoid;
        [XmlAttribute]
        public long? Tipodoctoid { get => _Tipodoctoid; set { if (RaiseAcceptPendingChange(value, _Tipodoctoid)) { _Tipodoctoid = value; OnPropertyChanged(); } } }

        private string? _Tipodoctoclave;
        [XmlAttribute]
        public string? Tipodoctoclave { get => _Tipodoctoclave; set { if (RaiseAcceptPendingChange(value, _Tipodoctoclave)) { _Tipodoctoclave = value; OnPropertyChanged(); } } }

        private string? _Tipodoctonombre;
        [XmlAttribute]
        public string? Tipodoctonombre { get => _Tipodoctonombre; set { if (RaiseAcceptPendingChange(value, _Tipodoctonombre)) { _Tipodoctonombre = value; OnPropertyChanged(); } } }

        private string? _Referencia;
        [XmlAttribute]
        public string? Referencia { get => _Referencia; set { if (RaiseAcceptPendingChange(value, _Referencia)) { _Referencia = value; OnPropertyChanged(); } } }

        private long? _Subtipodoctoid;
        [XmlAttribute]
        public long? Subtipodoctoid { get => _Subtipodoctoid; set { if (RaiseAcceptPendingChange(value, _Subtipodoctoid)) { _Subtipodoctoid = value; OnPropertyChanged(); } } }

        private string? _Subtipodoctoclave;
        [XmlAttribute]
        public string? Subtipodoctoclave { get => _Subtipodoctoclave; set { if (RaiseAcceptPendingChange(value, _Subtipodoctoclave)) { _Subtipodoctoclave = value; OnPropertyChanged(); } } }

        private string? _Subtipodoctonombre;
        [XmlAttribute]
        public string? Subtipodoctonombre { get => _Subtipodoctonombre; set { if (RaiseAcceptPendingChange(value, _Subtipodoctonombre)) { _Subtipodoctonombre = value; OnPropertyChanged(); } } }

        private long? _Sucursaltid;
        [XmlAttribute]
        public long? Sucursaltid { get => _Sucursaltid; set { if (RaiseAcceptPendingChange(value, _Sucursaltid)) { _Sucursaltid = value; OnPropertyChanged(); } } }

        private string? _Sucursaltclave;
        [XmlAttribute]
        public string? Sucursaltclave { get => _Sucursaltclave; set { if (RaiseAcceptPendingChange(value, _Sucursaltclave)) { _Sucursaltclave = value; OnPropertyChanged(); } } }

        private string? _Sucursaltnombre;
        [XmlAttribute]
        public string? Sucursaltnombre { get => _Sucursaltnombre; set { if (RaiseAcceptPendingChange(value, _Sucursaltnombre)) { _Sucursaltnombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {
            return "";
        }


        public static string GetFieldsForGeneralSearch()
        {
            return "";
        }


        public void FillCatalogRelatedFields()
        {

        }


        public static Docto_solicitud_mercanciaWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_Docto_solicitud_mercanciaWFBindingModel = new Docto_solicitud_mercanciaWFBindingModel();

        	buffer_Docto_solicitud_mercanciaWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Id = obj.Id;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Activo = obj.Activo;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Estatusdoctoid = obj.Estatusdoctoid;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Estatusdoctoclave = obj.Estatusdoctoclave;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Estatusdoctonombre = obj.Estatusdoctonombre;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Usuarioid = obj.Usuarioid;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Usuarionombre = obj.Usuarionombre;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Fecha = obj.Fecha;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Serie = obj.Serie;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Folio = obj.Folio;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Importe = obj.Importe;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Descuento = obj.Descuento;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Subtotal = obj.Subtotal;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Iva = obj.Iva;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Ieps = obj.Ieps;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Total = obj.Total;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Cajaid = obj.Cajaid;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Cajaclave = obj.Cajaclave;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Cajanombre = obj.Cajanombre;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Proveedorid = obj.Proveedorid;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Proveedorclave = obj.Proveedorclave;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Proveedornombre = obj.Proveedornombre;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Tipodoctoid = obj.Tipodoctoid;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Tipodoctoclave = obj.Tipodoctoclave;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Tipodoctonombre = obj.Tipodoctonombre;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Referencia = obj.Referencia;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Subtipodoctoid = obj.Subtipodoctoid;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Subtipodoctoclave = obj.Subtipodoctoclave;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Subtipodoctonombre = obj.Subtipodoctonombre;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Sucursaltid = obj.Sucursaltid;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Sucursaltclave = obj.Sucursaltclave;

        	buffer_Docto_solicitud_mercanciaWFBindingModel._Sucursaltnombre = obj.Sucursaltnombre;

            return buffer_Docto_solicitud_mercanciaWFBindingModel;
        }


    }

    
     
}

