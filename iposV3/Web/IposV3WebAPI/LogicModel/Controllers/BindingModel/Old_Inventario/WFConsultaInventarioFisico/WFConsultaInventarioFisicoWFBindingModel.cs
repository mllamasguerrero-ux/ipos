
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
    public class WFConsultaInventarioFisicoWFBindingModel : Validatable
    {

        public WFConsultaInventarioFisicoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cbimprimedif;
        [XmlAttribute]
        public BoolCN? Cbimprimedif { get => _Cbimprimedif; set { if (RaiseAcceptPendingChange(value, _Cbimprimedif)) { _Cbimprimedif = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbmostrarsolodif;
        [XmlAttribute]
        public BoolCN? Cbmostrarsolodif { get => _Cbmostrarsolodif; set { if (RaiseAcceptPendingChange(value, _Cbmostrarsolodif)) { _Cbmostrarsolodif = value; OnPropertyChanged(); } } }

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
    public class WFConsultaInventarioFisicoWF_ConsultainventarioBindingModel : Validatable
    {

        public WFConsultaInventarioFisicoWF_ConsultainventarioBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadteorica;
        [XmlAttribute]
        public decimal? Cantidadteorica { get => _Cantidadteorica; set { if (RaiseAcceptPendingChange(value, _Cantidadteorica)) { _Cantidadteorica = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadfisica;
        [XmlAttribute]
        public decimal? Cantidadfisica { get => _Cantidadfisica; set { if (RaiseAcceptPendingChange(value, _Cantidadfisica)) { _Cantidadfisica = value; OnPropertyChanged(); } } }

        private decimal? _Diferencia;
        [XmlAttribute]
        public decimal? Diferencia { get => _Diferencia; set { if (RaiseAcceptPendingChange(value, _Diferencia)) { _Diferencia = value; OnPropertyChanged(); } } }

        private string? _Productolote;
        [XmlAttribute]
        public string? Productolote { get => _Productolote; set { if (RaiseAcceptPendingChange(value, _Productolote)) { _Productolote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private int? _Movotid;
        [XmlAttribute]
        public int? Movotid { get => _Movotid; set { if (RaiseAcceptPendingChange(value, _Movotid)) { _Movotid = value; OnPropertyChanged(); } } }

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

