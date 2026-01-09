
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
    public class WFVentasDivididasXPlazoWFBindingModel : Validatable
    {

        public WFVentasDivididasXPlazoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




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
    public class WFVentasDivididasXPlazoWF_VentasconerroremidaBindingModel : Validatable
    {

        public WFVentasDivididasXPlazoWF_VentasconerroremidaBindingModel()
        {
            FillCatalogRelatedFields();
        }




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

        private string? _Nombrecliente;
        [XmlAttribute]
        public string? Nombrecliente { get => _Nombrecliente; set { if (RaiseAcceptPendingChange(value, _Nombrecliente)) { _Nombrecliente = value; OnPropertyChanged(); } } }

        private string? _Nombrevendedor;
        [XmlAttribute]
        public string? Nombrevendedor { get => _Nombrevendedor; set { if (RaiseAcceptPendingChange(value, _Nombrevendedor)) { _Nombrevendedor = value; OnPropertyChanged(); } } }

        private string? _Username;
        [XmlAttribute]
        public string? Username { get => _Username; set { if (RaiseAcceptPendingChange(value, _Username)) { _Username = value; OnPropertyChanged(); } } }

        private string? _Procesosurtido;
        [XmlAttribute]
        public string? Procesosurtido { get => _Procesosurtido; set { if (RaiseAcceptPendingChange(value, _Procesosurtido)) { _Procesosurtido = value; OnPropertyChanged(); } } }

        private string? _Observacionfacturacion;
        [XmlAttribute]
        public string? Observacionfacturacion { get => _Observacionfacturacion; set { if (RaiseAcceptPendingChange(value, _Observacionfacturacion)) { _Observacionfacturacion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private string? _Notasurtido;
        [XmlAttribute]
        public string? Notasurtido { get => _Notasurtido; set { if (RaiseAcceptPendingChange(value, _Notasurtido)) { _Notasurtido = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private short? _Plazo;
        [XmlAttribute]
        public short? Plazo { get => _Plazo; set { if (RaiseAcceptPendingChange(value, _Plazo)) { _Plazo = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private string? _Dgpagar;
        [XmlAttribute]
        public string? Dgpagar { get => _Dgpagar; set { if (RaiseAcceptPendingChange(value, _Dgpagar)) { _Dgpagar = value; OnPropertyChanged(); } } }

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

