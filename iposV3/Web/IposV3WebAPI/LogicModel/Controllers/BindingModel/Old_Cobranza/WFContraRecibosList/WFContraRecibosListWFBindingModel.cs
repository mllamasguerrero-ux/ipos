
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
    public class WFContraRecibosListWFBindingModel : Validatable
    {

        public WFContraRecibosListWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Clienteclave;
        [XmlAttribute]
        public long? Clienteclave { get => _Clienteclave; set { if (RaiseAcceptPendingChange(value, _Clienteclave)) { _Clienteclave = value; OnPropertyChanged(); } } }

        private string? _ClienteclaveClave;
        [XmlAttribute]
        public string? ClienteclaveClave { get => _ClienteclaveClave; set { if (RaiseAcceptPendingChange(value, _ClienteclaveClave)) { _ClienteclaveClave = value; OnPropertyChanged(); } } }

        private string? _ClienteclaveNombre;
        [XmlAttribute]
        public string? ClienteclaveNombre { get => _ClienteclaveNombre; set { if (RaiseAcceptPendingChange(value, _ClienteclaveNombre)) { _ClienteclaveNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcliente;
        [XmlAttribute]
        public BoolCN? Cbcliente { get => _Cbcliente; set { if (RaiseAcceptPendingChange(value, _Cbcliente)) { _Cbcliente = value; OnPropertyChanged(); } } }

        private long? _Cbestado;
        [XmlAttribute]
        public long? Cbestado { get => _Cbestado; set { if (RaiseAcceptPendingChange(value, _Cbestado)) { _Cbestado = value; OnPropertyChanged(); } } }

        private string? _Tbfoliocontrarecibo;
        [XmlAttribute]
        public string? Tbfoliocontrarecibo { get => _Tbfoliocontrarecibo; set { if (RaiseAcceptPendingChange(value, _Tbfoliocontrarecibo)) { _Tbfoliocontrarecibo = value; OnPropertyChanged(); } } }

        private string? _Tbfolioventa;
        [XmlAttribute]
        public string? Tbfolioventa { get => _Tbfolioventa; set { if (RaiseAcceptPendingChange(value, _Tbfolioventa)) { _Tbfolioventa = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfoliocontrarecibo;
        [XmlAttribute]
        public BoolCN? Cbfoliocontrarecibo { get => _Cbfoliocontrarecibo; set { if (RaiseAcceptPendingChange(value, _Cbfoliocontrarecibo)) { _Cbfoliocontrarecibo = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfolioventa;
        [XmlAttribute]
        public BoolCN? Cbfolioventa { get => _Cbfolioventa; set { if (RaiseAcceptPendingChange(value, _Cbfolioventa)) { _Cbfolioventa = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechainicio;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicio { get => _Dtpfechainicio; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicio)) { _Dtpfechainicio = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechafin;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafin { get => _Dtpfechafin; set { if (RaiseAcceptPendingChange(value, _Dtpfechafin)) { _Dtpfechafin = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfecha;
        [XmlAttribute]
        public BoolCN? Cbfecha { get => _Cbfecha; set { if (RaiseAcceptPendingChange(value, _Cbfecha)) { _Cbfecha = value; OnPropertyChanged(); } } }

        private string? _CbestadoClave;
        [XmlAttribute]
        public string? CbestadoClave { get => _CbestadoClave; set { if (RaiseAcceptPendingChange(value, _CbestadoClave)) { _CbestadoClave = value; OnPropertyChanged(); } } }

        private string? _CbestadoNombre;
        [XmlAttribute]
        public string? CbestadoNombre { get => _CbestadoNombre; set { if (RaiseAcceptPendingChange(value, _CbestadoNombre)) { _CbestadoNombre = value; OnPropertyChanged(); } } }

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
    public class WFContraRecibosListWF_ContrarecibolstBindingModel : Validatable
    {

        public WFContraRecibosListWF_ContrarecibolstBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Nombrecliente;
        [XmlAttribute]
        public string? Nombrecliente { get => _Nombrecliente; set { if (RaiseAcceptPendingChange(value, _Nombrecliente)) { _Nombrecliente = value; OnPropertyChanged(); } } }

        private string? _Nombreestatus;
        [XmlAttribute]
        public string? Nombreestatus { get => _Nombreestatus; set { if (RaiseAcceptPendingChange(value, _Nombreestatus)) { _Nombreestatus = value; OnPropertyChanged(); } } }

        private string? _Nombreestatuspago;
        [XmlAttribute]
        public string? Nombreestatuspago { get => _Nombreestatuspago; set { if (RaiseAcceptPendingChange(value, _Nombreestatuspago)) { _Nombreestatuspago = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private string? _Observaciones;
        [XmlAttribute]
        public string? Observaciones { get => _Observaciones; set { if (RaiseAcceptPendingChange(value, _Observaciones)) { _Observaciones = value; OnPropertyChanged(); } } }

        private string? _Dgeditar;
        [XmlAttribute]
        public string? Dgeditar { get => _Dgeditar; set { if (RaiseAcceptPendingChange(value, _Dgeditar)) { _Dgeditar = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Activo;
        [XmlAttribute]
        public string? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private long? _Personaid;
        [XmlAttribute]
        public long? Personaid { get => _Personaid; set { if (RaiseAcceptPendingChange(value, _Personaid)) { _Personaid = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private long? _Estatusid;
        [XmlAttribute]
        public long? Estatusid { get => _Estatusid; set { if (RaiseAcceptPendingChange(value, _Estatusid)) { _Estatusid = value; OnPropertyChanged(); } } }

        private decimal? _Abono;
        [XmlAttribute]
        public decimal? Abono { get => _Abono; set { if (RaiseAcceptPendingChange(value, _Abono)) { _Abono = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

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

