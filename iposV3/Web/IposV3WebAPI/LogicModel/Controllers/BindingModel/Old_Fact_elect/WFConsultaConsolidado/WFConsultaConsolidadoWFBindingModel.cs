
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
    public class WFConsultaConsolidadoWFBindingModel : Validatable
    {

        public WFConsultaConsolidadoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfechainicial;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicial { get => _Dtpfechainicial; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicial)) { _Dtpfechainicial = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechafinal;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafinal { get => _Dtpfechafinal; set { if (RaiseAcceptPendingChange(value, _Dtpfechafinal)) { _Dtpfechafinal = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpdevfechainicial;
        [XmlAttribute]
        public DateTimeOffset? Dtpdevfechainicial { get => _Dtpdevfechainicial; set { if (RaiseAcceptPendingChange(value, _Dtpdevfechainicial)) { _Dtpdevfechainicial = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpdevfechafinal;
        [XmlAttribute]
        public DateTimeOffset? Dtpdevfechafinal { get => _Dtpdevfechafinal; set { if (RaiseAcceptPendingChange(value, _Dtpdevfechafinal)) { _Dtpdevfechafinal = value; OnPropertyChanged(); } } }

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
    public class WFConsultaConsolidadoWF_FacturasdeconsolidacionBindingModel : Validatable
    {

        public WFConsultaConsolidadoWF_FacturasdeconsolidacionBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgimprimirfact;
        [XmlAttribute]
        public string? Dgimprimirfact { get => _Dgimprimirfact; set { if (RaiseAcceptPendingChange(value, _Dgimprimirfact)) { _Dgimprimirfact = value; OnPropertyChanged(); } } }

        private string? _Dgdetalle;
        [XmlAttribute]
        public string? Dgdetalle { get => _Dgdetalle; set { if (RaiseAcceptPendingChange(value, _Dgdetalle)) { _Dgdetalle = value; OnPropertyChanged(); } } }

        private string? _Dgtickets;
        [XmlAttribute]
        public string? Dgtickets { get => _Dgtickets; set { if (RaiseAcceptPendingChange(value, _Dgtickets)) { _Dgtickets = value; OnPropertyChanged(); } } }

        private string? _Dgabonos;
        [XmlAttribute]
        public string? Dgabonos { get => _Dgabonos; set { if (RaiseAcceptPendingChange(value, _Dgabonos)) { _Dgabonos = value; OnPropertyChanged(); } } }

        private string? _Dgcancelar;
        [XmlAttribute]
        public string? Dgcancelar { get => _Dgcancelar; set { if (RaiseAcceptPendingChange(value, _Dgcancelar)) { _Dgcancelar = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Serie;
        [XmlAttribute]
        public string? Serie { get => _Serie; set { if (RaiseAcceptPendingChange(value, _Serie)) { _Serie = value; OnPropertyChanged(); } } }

        private int? _Foliosat;
        [XmlAttribute]
        public int? Foliosat { get => _Foliosat; set { if (RaiseAcceptPendingChange(value, _Foliosat)) { _Foliosat = value; OnPropertyChanged(); } } }

        private string? _Seriesat;
        [XmlAttribute]
        public string? Seriesat { get => _Seriesat; set { if (RaiseAcceptPendingChange(value, _Seriesat)) { _Seriesat = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Abono;
        [XmlAttribute]
        public decimal? Abono { get => _Abono; set { if (RaiseAcceptPendingChange(value, _Abono)) { _Abono = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaini;
        [XmlAttribute]
        public DateTimeOffset? Fechaini { get => _Fechaini; set { if (RaiseAcceptPendingChange(value, _Fechaini)) { _Fechaini = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechafin;
        [XmlAttribute]
        public DateTimeOffset? Fechafin { get => _Fechafin; set { if (RaiseAcceptPendingChange(value, _Fechafin)) { _Fechafin = value; OnPropertyChanged(); } } }

        private string? _Vendedornombre;
        [XmlAttribute]
        public string? Vendedornombre { get => _Vendedornombre; set { if (RaiseAcceptPendingChange(value, _Vendedornombre)) { _Vendedornombre = value; OnPropertyChanged(); } } }

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
    public class WFConsultaConsolidadoWF_DevolucionesdeconsolidacionBindingModel : Validatable
    {

        public WFConsultaConsolidadoWF_DevolucionesdeconsolidacionBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgimprimirdev;
        [XmlAttribute]
        public string? Dgimprimirdev { get => _Dgimprimirdev; set { if (RaiseAcceptPendingChange(value, _Dgimprimirdev)) { _Dgimprimirdev = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Serie;
        [XmlAttribute]
        public string? Serie { get => _Serie; set { if (RaiseAcceptPendingChange(value, _Serie)) { _Serie = value; OnPropertyChanged(); } } }

        private int? _Foliosat;
        [XmlAttribute]
        public int? Foliosat { get => _Foliosat; set { if (RaiseAcceptPendingChange(value, _Foliosat)) { _Foliosat = value; OnPropertyChanged(); } } }

        private string? _Seriesat;
        [XmlAttribute]
        public string? Seriesat { get => _Seriesat; set { if (RaiseAcceptPendingChange(value, _Seriesat)) { _Seriesat = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _Vendedornombre;
        [XmlAttribute]
        public string? Vendedornombre { get => _Vendedornombre; set { if (RaiseAcceptPendingChange(value, _Vendedornombre)) { _Vendedornombre = value; OnPropertyChanged(); } } }

        private int? _Foliofactconsolidada;
        [XmlAttribute]
        public int? Foliofactconsolidada { get => _Foliofactconsolidada; set { if (RaiseAcceptPendingChange(value, _Foliofactconsolidada)) { _Foliofactconsolidada = value; OnPropertyChanged(); } } }

        private string? _Seriefactconsolidada;
        [XmlAttribute]
        public string? Seriefactconsolidada { get => _Seriefactconsolidada; set { if (RaiseAcceptPendingChange(value, _Seriefactconsolidada)) { _Seriefactconsolidada = value; OnPropertyChanged(); } } }

        private int? _Foliosatfactconsolidada;
        [XmlAttribute]
        public int? Foliosatfactconsolidada { get => _Foliosatfactconsolidada; set { if (RaiseAcceptPendingChange(value, _Foliosatfactconsolidada)) { _Foliosatfactconsolidada = value; OnPropertyChanged(); } } }

        private string? _Seriesatfactconsolidada;
        [XmlAttribute]
        public string? Seriesatfactconsolidada { get => _Seriesatfactconsolidada; set { if (RaiseAcceptPendingChange(value, _Seriesatfactconsolidada)) { _Seriesatfactconsolidada = value; OnPropertyChanged(); } } }

        private int? _Foliodevreal;
        [XmlAttribute]
        public int? Foliodevreal { get => _Foliodevreal; set { if (RaiseAcceptPendingChange(value, _Foliodevreal)) { _Foliodevreal = value; OnPropertyChanged(); } } }

        private string? _Seriedevreal;
        [XmlAttribute]
        public string? Seriedevreal { get => _Seriedevreal; set { if (RaiseAcceptPendingChange(value, _Seriedevreal)) { _Seriedevreal = value; OnPropertyChanged(); } } }

        private string? _Nombrecliente;
        [XmlAttribute]
        public string? Nombrecliente { get => _Nombrecliente; set { if (RaiseAcceptPendingChange(value, _Nombrecliente)) { _Nombrecliente = value; OnPropertyChanged(); } } }

        private int? _Folioventareal;
        [XmlAttribute]
        public int? Folioventareal { get => _Folioventareal; set { if (RaiseAcceptPendingChange(value, _Folioventareal)) { _Folioventareal = value; OnPropertyChanged(); } } }

        private string? _Serieventareal;
        [XmlAttribute]
        public string? Serieventareal { get => _Serieventareal; set { if (RaiseAcceptPendingChange(value, _Serieventareal)) { _Serieventareal = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

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

