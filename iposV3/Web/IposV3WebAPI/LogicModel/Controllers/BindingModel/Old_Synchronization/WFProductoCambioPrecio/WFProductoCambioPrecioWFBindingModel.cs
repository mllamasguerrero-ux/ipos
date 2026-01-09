
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
    public class WFProductoCambioPrecioWFBindingModel : Validatable
    {

        public WFProductoCambioPrecioWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Datetimepicker1;
        [XmlAttribute]
        public DateTimeOffset? Datetimepicker1 { get => _Datetimepicker1; set { if (RaiseAcceptPendingChange(value, _Datetimepicker1)) { _Datetimepicker1 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsolocambioprecio;
        [XmlAttribute]
        public BoolCN? Cbsolocambioprecio { get => _Cbsolocambioprecio; set { if (RaiseAcceptPendingChange(value, _Cbsolocambioprecio)) { _Cbsolocambioprecio = value; OnPropertyChanged(); } } }

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
    public class WFProductoCambioPrecioWF_ProductopreciologBindingModel : Validatable
    {

        public WFProductoCambioPrecioWF_ProductopreciologBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private decimal? _Precio1;
        [XmlAttribute]
        public decimal? Precio1 { get => _Precio1; set { if (RaiseAcceptPendingChange(value, _Precio1)) { _Precio1 = value; OnPropertyChanged(); } } }

        private decimal? _Precio2;
        [XmlAttribute]
        public decimal? Precio2 { get => _Precio2; set { if (RaiseAcceptPendingChange(value, _Precio2)) { _Precio2 = value; OnPropertyChanged(); } } }

        private decimal? _Precio3;
        [XmlAttribute]
        public decimal? Precio3 { get => _Precio3; set { if (RaiseAcceptPendingChange(value, _Precio3)) { _Precio3 = value; OnPropertyChanged(); } } }

        private decimal? _Precio4;
        [XmlAttribute]
        public decimal? Precio4 { get => _Precio4; set { if (RaiseAcceptPendingChange(value, _Precio4)) { _Precio4 = value; OnPropertyChanged(); } } }

        private decimal? _Precio5;
        [XmlAttribute]
        public decimal? Precio5 { get => _Precio5; set { if (RaiseAcceptPendingChange(value, _Precio5)) { _Precio5 = value; OnPropertyChanged(); } } }

        private decimal? _Costoreposicion;
        [XmlAttribute]
        public decimal? Costoreposicion { get => _Costoreposicion; set { if (RaiseAcceptPendingChange(value, _Costoreposicion)) { _Costoreposicion = value; OnPropertyChanged(); } } }

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

