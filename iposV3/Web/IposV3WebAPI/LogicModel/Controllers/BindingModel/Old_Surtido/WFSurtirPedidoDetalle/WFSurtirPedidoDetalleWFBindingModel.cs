
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
    public class WFSurtirPedidoDetalleWFBindingModel : Validatable
    {

        public WFSurtirPedidoDetalleWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbnotasurtido;
        [XmlAttribute]
        public string? Tbnotasurtido { get => _Tbnotasurtido; set { if (RaiseAcceptPendingChange(value, _Tbnotasurtido)) { _Tbnotasurtido = value; OnPropertyChanged(); } } }

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
    public class WFSurtirPedidoDetalleWF_Movto_por_lote_viewBindingModel : Validatable
    {

        public WFSurtirPedidoDetalleWF_Movto_por_lote_viewBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private decimal? _Precio;
        [XmlAttribute]
        public decimal? Precio { get => _Precio; set { if (RaiseAcceptPendingChange(value, _Precio)) { _Precio = value; OnPropertyChanged(); } } }

        private string? _Lotes;
        [XmlAttribute]
        public string? Lotes { get => _Lotes; set { if (RaiseAcceptPendingChange(value, _Lotes)) { _Lotes = value; OnPropertyChanged(); } } }

        private decimal? _Tasaiva;
        [XmlAttribute]
        public decimal? Tasaiva { get => _Tasaiva; set { if (RaiseAcceptPendingChange(value, _Tasaiva)) { _Tasaiva = value; OnPropertyChanged(); } } }

        private decimal? _Tasaieps;
        [XmlAttribute]
        public decimal? Tasaieps { get => _Tasaieps; set { if (RaiseAcceptPendingChange(value, _Tasaieps)) { _Tasaieps = value; OnPropertyChanged(); } } }

        private decimal? _Tasaimpuesto;
        [XmlAttribute]
        public decimal? Tasaimpuesto { get => _Tasaimpuesto; set { if (RaiseAcceptPendingChange(value, _Tasaimpuesto)) { _Tasaimpuesto = value; OnPropertyChanged(); } } }

        private decimal? _Descuentoporcentaje;
        [XmlAttribute]
        public decimal? Descuentoporcentaje { get => _Descuentoporcentaje; set { if (RaiseAcceptPendingChange(value, _Descuentoporcentaje)) { _Descuentoporcentaje = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion1;
        [XmlAttribute]
        public string? Productodescripcion1 { get => _Productodescripcion1; set { if (RaiseAcceptPendingChange(value, _Productodescripcion1)) { _Productodescripcion1 = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion2;
        [XmlAttribute]
        public string? Productodescripcion2 { get => _Productodescripcion2; set { if (RaiseAcceptPendingChange(value, _Productodescripcion2)) { _Productodescripcion2 = value; OnPropertyChanged(); } } }

        private long? _Firstmovtoid;
        [XmlAttribute]
        public long? Firstmovtoid { get => _Firstmovtoid; set { if (RaiseAcceptPendingChange(value, _Firstmovtoid)) { _Firstmovtoid = value; OnPropertyChanged(); } } }

        private string? _Dgeditarlotes;
        [XmlAttribute]
        public string? Dgeditarlotes { get => _Dgeditarlotes; set { if (RaiseAcceptPendingChange(value, _Dgeditarlotes)) { _Dgeditarlotes = value; OnPropertyChanged(); } } }

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

