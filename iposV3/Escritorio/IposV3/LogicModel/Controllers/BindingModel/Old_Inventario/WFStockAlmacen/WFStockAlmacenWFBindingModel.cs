
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
    public class WFStockAlmacenWFBindingModel : Validatable
    {

        public WFStockAlmacenWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Stockmax;
        [XmlAttribute]
        public decimal? Stockmax { get => _Stockmax; set { if (RaiseAcceptPendingChange(value, _Stockmax)) { _Stockmax = value; OnPropertyChanged(); } } }

        private long? _Almacencombobox;
        [XmlAttribute]
        public long? Almacencombobox { get => _Almacencombobox; set { if (RaiseAcceptPendingChange(value, _Almacencombobox)) { _Almacencombobox = value; OnPropertyChanged(); } } }

        private string? _Tbcodigo;
        [XmlAttribute]
        public string? Tbcodigo { get => _Tbcodigo; set { if (RaiseAcceptPendingChange(value, _Tbcodigo)) { _Tbcodigo = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private decimal? _Stock;
        [XmlAttribute]
        public decimal? Stock { get => _Stock; set { if (RaiseAcceptPendingChange(value, _Stock)) { _Stock = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private string? _AlmacencomboboxClave;
        [XmlAttribute]
        public string? AlmacencomboboxClave { get => _AlmacencomboboxClave; set { if (RaiseAcceptPendingChange(value, _AlmacencomboboxClave)) { _AlmacencomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AlmacencomboboxNombre;
        [XmlAttribute]
        public string? AlmacencomboboxNombre { get => _AlmacencomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AlmacencomboboxNombre)) { _AlmacencomboboxNombre = value; OnPropertyChanged(); } } }

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
    public class WFStockAlmacenWF_StockalmacenBindingModel : Validatable
    {

        public WFStockAlmacenWF_StockalmacenBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private string? _Clavealmacen;
        [XmlAttribute]
        public string? Clavealmacen { get => _Clavealmacen; set { if (RaiseAcceptPendingChange(value, _Clavealmacen)) { _Clavealmacen = value; OnPropertyChanged(); } } }

        private string? _Almacen;
        [XmlAttribute]
        public string? Almacen { get => _Almacen; set { if (RaiseAcceptPendingChange(value, _Almacen)) { _Almacen = value; OnPropertyChanged(); } } }

        private decimal? _Stockmin;
        [XmlAttribute]
        public decimal? Stockmin { get => _Stockmin; set { if (RaiseAcceptPendingChange(value, _Stockmin)) { _Stockmin = value; OnPropertyChanged(); } } }

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


     
}

