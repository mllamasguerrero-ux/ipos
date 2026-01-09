
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
    public class WFPagoMovilWFBindingModel : Validatable
    {

        public WFPagoMovilWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Formapagocombobox;
        [XmlAttribute]
        public long? Formapagocombobox { get => _Formapagocombobox; set { if (RaiseAcceptPendingChange(value, _Formapagocombobox)) { _Formapagocombobox = value; OnPropertyChanged(); } } }

        private string? _Tbreferencia;
        [XmlAttribute]
        public string? Tbreferencia { get => _Tbreferencia; set { if (RaiseAcceptPendingChange(value, _Tbreferencia)) { _Tbreferencia = value; OnPropertyChanged(); } } }

        private string? _Tbnotas;
        [XmlAttribute]
        public string? Tbnotas { get => _Tbnotas; set { if (RaiseAcceptPendingChange(value, _Tbnotas)) { _Tbnotas = value; OnPropertyChanged(); } } }

        private decimal? _Tbacuenta;
        [XmlAttribute]
        public decimal? Tbacuenta { get => _Tbacuenta; set { if (RaiseAcceptPendingChange(value, _Tbacuenta)) { _Tbacuenta = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfecharecepcion;
        [XmlAttribute]
        public DateTimeOffset? Dtpfecharecepcion { get => _Dtpfecharecepcion; set { if (RaiseAcceptPendingChange(value, _Dtpfecharecepcion)) { _Dtpfecharecepcion = value; OnPropertyChanged(); } } }

        private long? _Clienteclave;
        [XmlAttribute]
        public long? Clienteclave { get => _Clienteclave; set { if (RaiseAcceptPendingChange(value, _Clienteclave)) { _Clienteclave = value; OnPropertyChanged(); } } }

        private string? _ClienteclaveClave;
        [XmlAttribute]
        public string? ClienteclaveClave { get => _ClienteclaveClave; set { if (RaiseAcceptPendingChange(value, _ClienteclaveClave)) { _ClienteclaveClave = value; OnPropertyChanged(); } } }

        private string? _ClienteclaveNombre;
        [XmlAttribute]
        public string? ClienteclaveNombre { get => _ClienteclaveNombre; set { if (RaiseAcceptPendingChange(value, _ClienteclaveNombre)) { _ClienteclaveNombre = value; OnPropertyChanged(); } } }

        private long? _Combobanco;
        [XmlAttribute]
        public long? Combobanco { get => _Combobanco; set { if (RaiseAcceptPendingChange(value, _Combobanco)) { _Combobanco = value; OnPropertyChanged(); } } }

        private decimal? _Pa_abono;
        [XmlAttribute]
        public decimal? Pa_abono { get => _Pa_abono; set { if (RaiseAcceptPendingChange(value, _Pa_abono)) { _Pa_abono = value; OnPropertyChanged(); } } }

        private string? _FormapagocomboboxClave;
        [XmlAttribute]
        public string? FormapagocomboboxClave { get => _FormapagocomboboxClave; set { if (RaiseAcceptPendingChange(value, _FormapagocomboboxClave)) { _FormapagocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _FormapagocomboboxNombre;
        [XmlAttribute]
        public string? FormapagocomboboxNombre { get => _FormapagocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _FormapagocomboboxNombre)) { _FormapagocomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _CombobancoClave;
        [XmlAttribute]
        public string? CombobancoClave { get => _CombobancoClave; set { if (RaiseAcceptPendingChange(value, _CombobancoClave)) { _CombobancoClave = value; OnPropertyChanged(); } } }

        private string? _CombobancoNombre;
        [XmlAttribute]
        public string? CombobancoNombre { get => _CombobancoNombre; set { if (RaiseAcceptPendingChange(value, _CombobancoNombre)) { _CombobancoNombre = value; OnPropertyChanged(); } } }

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



    }

    
    [XmlRoot]
    public class WFPagoMovilWF_CobranzamovilbyidBindingModel : Validatable
    {

        public WFPagoMovilWF_CobranzamovilbyidBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Vendedor;
        [XmlAttribute]
        public string? Vendedor { get => _Vendedor; set { if (RaiseAcceptPendingChange(value, _Vendedor)) { _Vendedor = value; OnPropertyChanged(); } } }

        private string? _Empresa;
        [XmlAttribute]
        public string? Empresa { get => _Empresa; set { if (RaiseAcceptPendingChange(value, _Empresa)) { _Empresa = value; OnPropertyChanged(); } } }

        private string? _Factura;
        [XmlAttribute]
        public string? Factura { get => _Factura; set { if (RaiseAcceptPendingChange(value, _Factura)) { _Factura = value; OnPropertyChanged(); } } }

        private string? _Estatus;
        [XmlAttribute]
        public string? Estatus { get => _Estatus; set { if (RaiseAcceptPendingChange(value, _Estatus)) { _Estatus = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _F_factura;
        [XmlAttribute]
        public DateTimeOffset? F_factura { get => _F_factura; set { if (RaiseAcceptPendingChange(value, _F_factura)) { _F_factura = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Cobranza;
        [XmlAttribute]
        public string? Cobranza { get => _Cobranza; set { if (RaiseAcceptPendingChange(value, _Cobranza)) { _Cobranza = value; OnPropertyChanged(); } } }

        private string? _Venta;
        [XmlAttribute]
        public string? Venta { get => _Venta; set { if (RaiseAcceptPendingChange(value, _Venta)) { _Venta = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Saldomovil;
        [XmlAttribute]
        public decimal? Saldomovil { get => _Saldomovil; set { if (RaiseAcceptPendingChange(value, _Saldomovil)) { _Saldomovil = value; OnPropertyChanged(); } } }

        private decimal? _Pagoactual;
        [XmlAttribute]
        public decimal? Pagoactual { get => _Pagoactual; set { if (RaiseAcceptPendingChange(value, _Pagoactual)) { _Pagoactual = value; OnPropertyChanged(); } } }

        private decimal? _Actualanticipo;
        [XmlAttribute]
        public decimal? Actualanticipo { get => _Actualanticipo; set { if (RaiseAcceptPendingChange(value, _Actualanticipo)) { _Actualanticipo = value; OnPropertyChanged(); } } }

        private decimal? _Saldodespues;
        [XmlAttribute]
        public decimal? Saldodespues { get => _Saldodespues; set { if (RaiseAcceptPendingChange(value, _Saldodespues)) { _Saldodespues = value; OnPropertyChanged(); } } }

        private decimal? _Abonosmovil;
        [XmlAttribute]
        public decimal? Abonosmovil { get => _Abonosmovil; set { if (RaiseAcceptPendingChange(value, _Abonosmovil)) { _Abonosmovil = value; OnPropertyChanged(); } } }

        private int? _Dias;
        [XmlAttribute]
        public int? Dias { get => _Dias; set { if (RaiseAcceptPendingChange(value, _Dias)) { _Dias = value; OnPropertyChanged(); } } }

        private decimal? _A_cuenta;
        [XmlAttribute]
        public decimal? A_cuenta { get => _A_cuenta; set { if (RaiseAcceptPendingChange(value, _A_cuenta)) { _A_cuenta = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private string? _Dgheight;
        [XmlAttribute]
        public string? Dgheight { get => _Dgheight; set { if (RaiseAcceptPendingChange(value, _Dgheight)) { _Dgheight = value; OnPropertyChanged(); } } }

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



    }


     
}

