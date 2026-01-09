
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
    public class WFInvLocationSingleProdWFBindingModel : Validatable
    {

        public WFInvLocationSingleProdWFBindingModel()
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
    public class WFInvLocationSingleProdWF_Get_invfis_listadetail_xlocprodBindingModel : Validatable
    {

        public WFInvLocationSingleProdWF_Get_invfis_listadetail_xlocprodBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Anaquelres;
        [XmlAttribute]
        public string? Anaquelres { get => _Anaquelres; set { if (RaiseAcceptPendingChange(value, _Anaquelres)) { _Anaquelres = value; OnPropertyChanged(); } } }

        private string? _Localidad;
        [XmlAttribute]
        public string? Localidad { get => _Localidad; set { if (RaiseAcceptPendingChange(value, _Localidad)) { _Localidad = value; OnPropertyChanged(); } } }

        private string? _Productolote;
        [XmlAttribute]
        public string? Productolote { get => _Productolote; set { if (RaiseAcceptPendingChange(value, _Productolote)) { _Productolote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadteorica;
        [XmlAttribute]
        public decimal? Cantidadteorica { get => _Cantidadteorica; set { if (RaiseAcceptPendingChange(value, _Cantidadteorica)) { _Cantidadteorica = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadfisica;
        [XmlAttribute]
        public decimal? Cantidadfisica { get => _Cantidadfisica; set { if (RaiseAcceptPendingChange(value, _Cantidadfisica)) { _Cantidadfisica = value; OnPropertyChanged(); } } }

        private decimal? _Cajas;
        [XmlAttribute]
        public decimal? Cajas { get => _Cajas; set { if (RaiseAcceptPendingChange(value, _Cajas)) { _Cajas = value; OnPropertyChanged(); } } }

        private decimal? _Piezas;
        [XmlAttribute]
        public decimal? Piezas { get => _Piezas; set { if (RaiseAcceptPendingChange(value, _Piezas)) { _Piezas = value; OnPropertyChanged(); } } }

        private decimal? _Pzacaja;
        [XmlAttribute]
        public decimal? Pzacaja { get => _Pzacaja; set { if (RaiseAcceptPendingChange(value, _Pzacaja)) { _Pzacaja = value; OnPropertyChanged(); } } }

        private int? _Numero;
        [XmlAttribute]
        public int? Numero { get => _Numero; set { if (RaiseAcceptPendingChange(value, _Numero)) { _Numero = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private decimal? _Cantidaddiferencia;
        [XmlAttribute]
        public decimal? Cantidaddiferencia { get => _Cantidaddiferencia; set { if (RaiseAcceptPendingChange(value, _Cantidaddiferencia)) { _Cantidaddiferencia = value; OnPropertyChanged(); } } }

        private long? _Movtoid;
        [XmlAttribute]
        public long? Movtoid { get => _Movtoid; set { if (RaiseAcceptPendingChange(value, _Movtoid)) { _Movtoid = value; OnPropertyChanged(); } } }

        private decimal? _Acumuladocantidadfisica;
        [XmlAttribute]
        public decimal? Acumuladocantidadfisica { get => _Acumuladocantidadfisica; set { if (RaiseAcceptPendingChange(value, _Acumuladocantidadfisica)) { _Acumuladocantidadfisica = value; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private long? _Anaquelidres;
        [XmlAttribute]
        public long? Anaquelidres { get => _Anaquelidres; set { if (RaiseAcceptPendingChange(value, _Anaquelidres)) { _Anaquelidres = value; OnPropertyChanged(); } } }

        private int? _Errorcode;
        [XmlAttribute]
        public int? Errorcode { get => _Errorcode; set { if (RaiseAcceptPendingChange(value, _Errorcode)) { _Errorcode = value; OnPropertyChanged(); } } }

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

