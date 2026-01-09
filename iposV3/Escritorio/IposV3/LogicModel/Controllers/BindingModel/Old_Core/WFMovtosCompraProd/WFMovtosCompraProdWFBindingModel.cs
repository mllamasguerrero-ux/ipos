
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
    public class WFMovtosCompraProdWFBindingModel : Validatable
    {

        public WFMovtosCompraProdWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datetimepickerfechaini;
        [XmlAttribute]
        public DateTimeOffset? Datetimepickerfechaini { get => _Datetimepickerfechaini; set { if (RaiseAcceptPendingChange(value, _Datetimepickerfechaini)) { _Datetimepickerfechaini = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datetimepickerfechafin;
        [XmlAttribute]
        public DateTimeOffset? Datetimepickerfechafin { get => _Datetimepickerfechafin; set { if (RaiseAcceptPendingChange(value, _Datetimepickerfechafin)) { _Datetimepickerfechafin = value; OnPropertyChanged(); } } }

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
    public class WFMovtosCompraProdWF_Get_producto_movtosBindingModel : Validatable
    {

        public WFMovtosCompraProdWF_Get_producto_movtosBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Numero;
        [XmlAttribute]
        public int? Numero { get => _Numero; set { if (RaiseAcceptPendingChange(value, _Numero)) { _Numero = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private string? _Almacenclave;
        [XmlAttribute]
        public string? Almacenclave { get => _Almacenclave; set { if (RaiseAcceptPendingChange(value, _Almacenclave)) { _Almacenclave = value; OnPropertyChanged(); } } }

        private int? _Doctofolio;
        [XmlAttribute]
        public int? Doctofolio { get => _Doctofolio; set { if (RaiseAcceptPendingChange(value, _Doctofolio)) { _Doctofolio = value; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadmov;
        [XmlAttribute]
        public decimal? Cantidadmov { get => _Cantidadmov; set { if (RaiseAcceptPendingChange(value, _Cantidadmov)) { _Cantidadmov = value; OnPropertyChanged(); } } }

        private string? _Nombrepersona;
        [XmlAttribute]
        public string? Nombrepersona { get => _Nombrepersona; set { if (RaiseAcceptPendingChange(value, _Nombrepersona)) { _Nombrepersona = value; OnPropertyChanged(); } } }

        private decimal? _Costoprecio;
        [XmlAttribute]
        public decimal? Costoprecio { get => _Costoprecio; set { if (RaiseAcceptPendingChange(value, _Costoprecio)) { _Costoprecio = value; OnPropertyChanged(); } } }

        private decimal? _Precio_mas_impuesto;
        [XmlAttribute]
        public decimal? Precio_mas_impuesto { get => _Precio_mas_impuesto; set { if (RaiseAcceptPendingChange(value, _Precio_mas_impuesto)) { _Precio_mas_impuesto = value; OnPropertyChanged(); } } }

        private decimal? _Preciocaj_mas_impuesto;
        [XmlAttribute]
        public decimal? Preciocaj_mas_impuesto { get => _Preciocaj_mas_impuesto; set { if (RaiseAcceptPendingChange(value, _Preciocaj_mas_impuesto)) { _Preciocaj_mas_impuesto = value; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute]
        public decimal? Descuento { get => _Descuento; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value; OnPropertyChanged(); } } }

        private decimal? _Iva;
        [XmlAttribute]
        public decimal? Iva { get => _Iva; set { if (RaiseAcceptPendingChange(value, _Iva)) { _Iva = value; OnPropertyChanged(); } } }

        private decimal? _Ieps;
        [XmlAttribute]
        public decimal? Ieps { get => _Ieps; set { if (RaiseAcceptPendingChange(value, _Ieps)) { _Ieps = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Impuesto;
        [XmlAttribute]
        public decimal? Impuesto { get => _Impuesto; set { if (RaiseAcceptPendingChange(value, _Impuesto)) { _Impuesto = value; OnPropertyChanged(); } } }

        private decimal? _Tasaiva;
        [XmlAttribute]
        public decimal? Tasaiva { get => _Tasaiva; set { if (RaiseAcceptPendingChange(value, _Tasaiva)) { _Tasaiva = value; OnPropertyChanged(); } } }

        private decimal? _Tasaieps;
        [XmlAttribute]
        public decimal? Tasaieps { get => _Tasaieps; set { if (RaiseAcceptPendingChange(value, _Tasaieps)) { _Tasaieps = value; OnPropertyChanged(); } } }

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

