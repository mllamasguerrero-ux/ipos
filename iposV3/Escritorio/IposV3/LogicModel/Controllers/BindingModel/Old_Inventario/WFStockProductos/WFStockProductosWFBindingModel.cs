
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
    public class WFStockProductosWFBindingModel : Validatable
    {

        public WFStockProductosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbcodigo;
        [XmlAttribute]
        public string? Tbcodigo { get => _Tbcodigo; set { if (RaiseAcceptPendingChange(value, _Tbcodigo)) { _Tbcodigo = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcapturapiezas;
        [XmlAttribute]
        public BoolCN? Cbcapturapiezas { get => _Cbcapturapiezas; set { if (RaiseAcceptPendingChange(value, _Cbcapturapiezas)) { _Cbcapturapiezas = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcapturacajas;
        [XmlAttribute]
        public BoolCN? Cbcapturacajas { get => _Cbcapturacajas; set { if (RaiseAcceptPendingChange(value, _Cbcapturacajas)) { _Cbcapturacajas = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private decimal? _Stockcajamin;
        [XmlAttribute]
        public decimal? Stockcajamin { get => _Stockcajamin; set { if (RaiseAcceptPendingChange(value, _Stockcajamin)) { _Stockcajamin = value; OnPropertyChanged(); } } }

        private decimal? _Stock;
        [XmlAttribute]
        public decimal? Stock { get => _Stock; set { if (RaiseAcceptPendingChange(value, _Stock)) { _Stock = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsurtirporcaja;
        [XmlAttribute]
        public BoolCN? Cbsurtirporcaja { get => _Cbsurtirporcaja; set { if (RaiseAcceptPendingChange(value, _Cbsurtirporcaja)) { _Cbsurtirporcaja = value; OnPropertyChanged(); } } }

        private BoolCN? _Manejastock;
        [XmlAttribute]
        public BoolCN? Manejastock { get => _Manejastock; set { if (RaiseAcceptPendingChange(value, _Manejastock)) { _Manejastock = value; OnPropertyChanged(); } } }

        private decimal? _Stockcajamax;
        [XmlAttribute]
        public decimal? Stockcajamax { get => _Stockcajamax; set { if (RaiseAcceptPendingChange(value, _Stockcajamax)) { _Stockcajamax = value; OnPropertyChanged(); } } }

        private decimal? _Stockmax;
        [XmlAttribute]
        public decimal? Stockmax { get => _Stockmax; set { if (RaiseAcceptPendingChange(value, _Stockmax)) { _Stockmax = value; OnPropertyChanged(); } } }

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
    public class WFStockProductosWF_ProductoconstockBindingModel : Validatable
    {

        public WFStockProductosWF_ProductoconstockBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private string? _Descripcion3;
        [XmlAttribute]
        public string? Descripcion3 { get => _Descripcion3; set { if (RaiseAcceptPendingChange(value, _Descripcion3)) { _Descripcion3 = value; OnPropertyChanged(); } } }

        private string? _Manejastock;
        [XmlAttribute]
        public string? Manejastock { get => _Manejastock; set { if (RaiseAcceptPendingChange(value, _Manejastock)) { _Manejastock = value; OnPropertyChanged(); } } }

        private decimal? _Stock;
        [XmlAttribute]
        public decimal? Stock { get => _Stock; set { if (RaiseAcceptPendingChange(value, _Stock)) { _Stock = value; OnPropertyChanged(); } } }

        private decimal? _Stockmax;
        [XmlAttribute]
        public decimal? Stockmax { get => _Stockmax; set { if (RaiseAcceptPendingChange(value, _Stockmax)) { _Stockmax = value; OnPropertyChanged(); } } }

        private string? _Surtirporcaja;
        [XmlAttribute]
        public string? Surtirporcaja { get => _Surtirporcaja; set { if (RaiseAcceptPendingChange(value, _Surtirporcaja)) { _Surtirporcaja = value; OnPropertyChanged(); } } }

        private decimal? _Stockmincaja;
        [XmlAttribute]
        public decimal? Stockmincaja { get => _Stockmincaja; set { if (RaiseAcceptPendingChange(value, _Stockmincaja)) { _Stockmincaja = value; OnPropertyChanged(); } } }

        private decimal? _Stockmaxcaja;
        [XmlAttribute]
        public decimal? Stockmaxcaja { get => _Stockmaxcaja; set { if (RaiseAcceptPendingChange(value, _Stockmaxcaja)) { _Stockmaxcaja = value; OnPropertyChanged(); } } }

        private decimal? _Stockminpieza;
        [XmlAttribute]
        public decimal? Stockminpieza { get => _Stockminpieza; set { if (RaiseAcceptPendingChange(value, _Stockminpieza)) { _Stockminpieza = value; OnPropertyChanged(); } } }

        private decimal? _Stockmaxpieza;
        [XmlAttribute]
        public decimal? Stockmaxpieza { get => _Stockmaxpieza; set { if (RaiseAcceptPendingChange(value, _Stockmaxpieza)) { _Stockmaxpieza = value; OnPropertyChanged(); } } }

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

