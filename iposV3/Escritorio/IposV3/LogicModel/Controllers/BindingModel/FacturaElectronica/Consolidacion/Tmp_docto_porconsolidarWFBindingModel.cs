
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using IposV3.Services;

namespace BindingModels
{
    
    [XmlRoot]
    public class Tmp_docto_porconsolidarWFBindingModel : Validatable
    {

        public Tmp_docto_porconsolidarWFBindingModel()
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

        private long? _Tipodoctoid;
        [XmlAttribute]
        public long? Tipodoctoid { get => _Tipodoctoid; set { if (RaiseAcceptPendingChange(value, _Tipodoctoid)) { _Tipodoctoid = value; OnPropertyChanged(); } } }

        private decimal? _Ivaretenido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Ivaretenido { get => _Ivaretenido?? 0; set { if (RaiseAcceptPendingChange(value, _Ivaretenido)) { _Ivaretenido = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Isrretenido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Isrretenido { get => _Isrretenido?? 0; set { if (RaiseAcceptPendingChange(value, _Isrretenido)) { _Isrretenido = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Saldo { get => _Saldo?? 0; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Abonoconvale;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Abonoconvale { get => _Abonoconvale?? 0; set { if (RaiseAcceptPendingChange(value, _Abonoconvale)) { _Abonoconvale = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Abonocontarjeta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Abonocontarjeta { get => _Abonocontarjeta?? 0; set { if (RaiseAcceptPendingChange(value, _Abonocontarjeta)) { _Abonocontarjeta = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Montodevoluciones;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Montodevoluciones { get => _Montodevoluciones?? 0; set { if (RaiseAcceptPendingChange(value, _Montodevoluciones)) { _Montodevoluciones = value?? 0; OnPropertyChanged(); } } }

        private long? _Tipoaplicacionid;
        [XmlAttribute]
        public long? Tipoaplicacionid { get => _Tipoaplicacionid; set { if (RaiseAcceptPendingChange(value, _Tipoaplicacionid)) { _Tipoaplicacionid = value; OnPropertyChanged(); } } }

        private long? _Doctopagoid;
        [XmlAttribute]
        public long? Doctopagoid { get => _Doctopagoid; set { if (RaiseAcceptPendingChange(value, _Doctopagoid)) { _Doctopagoid = value; OnPropertyChanged(); } } }

        private BoolCS? _Aplicado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Aplicado { get => _Aplicado?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Aplicado)) { _Aplicado = value?? BoolCS.S; OnPropertyChanged(); } } }

        private long? _Doctorefid;
        [XmlAttribute]
        public long? Doctorefid { get => _Doctorefid; set { if (RaiseAcceptPendingChange(value, _Doctorefid)) { _Doctorefid = value; OnPropertyChanged(); } } }

        private BoolCN? _Montosajustados;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCN? Montosajustados { get => _Montosajustados?? BoolCN.N; set { if (RaiseAcceptPendingChange(value, _Montosajustados)) { _Montosajustados = value?? BoolCN.N; OnPropertyChanged(); } } }


        public string Tipodoctonombre { get { return this._Tipodoctoid == DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO ? "Devolucion" : "Venta"; } }

        public string Nombretipoaplicacion { get { return this._Tipoaplicacionid == 3 ? "EGRESOS DEVOLUCION" : "VENTA"; } }

        public decimal? Impuesto { get { return (_Iva ?? 0m) + (_Ieps ?? 0m); } }
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


        public static Tmp_docto_porconsolidarWFBindingModel CreateFromAnonymous(Tmp_docto_porconsolidar obj)
        {
            var buffer_Tmp_docto_porconsolidarWFBindingModel = new Tmp_docto_porconsolidarWFBindingModel();

        	buffer_Tmp_docto_porconsolidarWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Id = obj.Id;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Fecha = obj.Fecha;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Serie = obj.Serie;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Folio = obj.Folio;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Importe = obj.Importe;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Descuento = obj.Descuento;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Subtotal = obj.Subtotal;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Iva = obj.Iva;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Ieps = obj.Ieps;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Total = obj.Total;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Tipodoctoid = obj.Tipodoctoid;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Ivaretenido = obj.Ivaretenido;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Isrretenido = obj.Isrretenido;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Saldo = obj.Saldo;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Abonoconvale = obj.Abonoconvale;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Abonocontarjeta = obj.Abonocontarjeta;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Montodevoluciones = obj.Montodevoluciones;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Tipoaplicacionid = obj.Tipoaplicacionid;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Doctopagoid = obj.Doctopagoid;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Aplicado = obj.Aplicado;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Doctorefid = obj.Doctorefid;

        	buffer_Tmp_docto_porconsolidarWFBindingModel._Montosajustados = obj.Montosajustados;

            return buffer_Tmp_docto_porconsolidarWFBindingModel;
        }


    }

    
     
}

