
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
    public class WFProductoListasPrecioWFBindingModel : Validatable
    {

        public WFProductoListasPrecioWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _ProductoidClave;
        [XmlAttribute]
        public string? ProductoidClave { get => _ProductoidClave; set { if (RaiseAcceptPendingChange(value, _ProductoidClave)) { _ProductoidClave = value; OnPropertyChanged(); } } }

        private string? _ProductoidNombre;
        [XmlAttribute]
        public string? ProductoidNombre { get => _ProductoidNombre; set { if (RaiseAcceptPendingChange(value, _ProductoidNombre)) { _ProductoidNombre = value; OnPropertyChanged(); } } }

        private decimal? _Precio3;
        [XmlAttribute]
        public decimal? Precio3 { get => _Precio3; set { if (RaiseAcceptPendingChange(value, _Precio3)) { _Precio3 = value; OnPropertyChanged(); } } }

        private decimal? _Precio2;
        [XmlAttribute]
        public decimal? Precio2 { get => _Precio2; set { if (RaiseAcceptPendingChange(value, _Precio2)) { _Precio2 = value; OnPropertyChanged(); } } }

        private long? _Listaprecioclave;
        [XmlAttribute]
        public long? Listaprecioclave { get => _Listaprecioclave; set { if (RaiseAcceptPendingChange(value, _Listaprecioclave)) { _Listaprecioclave = value; OnPropertyChanged(); } } }

        private decimal? _Precio1;
        [XmlAttribute]
        public decimal? Precio1 { get => _Precio1; set { if (RaiseAcceptPendingChange(value, _Precio1)) { _Precio1 = value; OnPropertyChanged(); } } }

        private decimal? _Precio4;
        [XmlAttribute]
        public decimal? Precio4 { get => _Precio4; set { if (RaiseAcceptPendingChange(value, _Precio4)) { _Precio4 = value; OnPropertyChanged(); } } }

        private decimal? _Precio5;
        [XmlAttribute]
        public decimal? Precio5 { get => _Precio5; set { if (RaiseAcceptPendingChange(value, _Precio5)) { _Precio5 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavigdatetimepicker;
        [XmlAttribute]
        public DateTimeOffset? Fechavigdatetimepicker { get => _Fechavigdatetimepicker; set { if (RaiseAcceptPendingChange(value, _Fechavigdatetimepicker)) { _Fechavigdatetimepicker = value; OnPropertyChanged(); } } }

        private string? _Costoreposicion;
        [XmlAttribute]
        public string? Costoreposicion { get => _Costoreposicion; set { if (RaiseAcceptPendingChange(value, _Costoreposicion)) { _Costoreposicion = value; OnPropertyChanged(); } } }

        private BoolCN? _Tienevig;
        [XmlAttribute]
        public BoolCN? Tienevig { get => _Tienevig; set { if (RaiseAcceptPendingChange(value, _Tienevig)) { _Tienevig = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbprecioconimpuesto;
        [XmlAttribute]
        public BoolCN? Cbprecioconimpuesto { get => _Cbprecioconimpuesto; set { if (RaiseAcceptPendingChange(value, _Cbprecioconimpuesto)) { _Cbprecioconimpuesto = value; OnPropertyChanged(); } } }

        private string? _ListaprecioclaveClave;
        [XmlAttribute]
        public string? ListaprecioclaveClave { get => _ListaprecioclaveClave; set { if (RaiseAcceptPendingChange(value, _ListaprecioclaveClave)) { _ListaprecioclaveClave = value; OnPropertyChanged(); } } }

        private string? _ListaprecioclaveNombre;
        [XmlAttribute]
        public string? ListaprecioclaveNombre { get => _ListaprecioclaveNombre; set { if (RaiseAcceptPendingChange(value, _ListaprecioclaveNombre)) { _ListaprecioclaveNombre = value; OnPropertyChanged(); } } }

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
    public class WFProductoListasPrecioWF_ProductolistapreciosBindingModel : Validatable
    {

        public WFProductoListasPrecioWF_ProductolistapreciosBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Dgeditar;
        [XmlAttribute]
        public string? Dgeditar { get => _Dgeditar; set { if (RaiseAcceptPendingChange(value, _Dgeditar)) { _Dgeditar = value; OnPropertyChanged(); } } }

        private string? _Dgborrar;
        [XmlAttribute]
        public string? Dgborrar { get => _Dgborrar; set { if (RaiseAcceptPendingChange(value, _Dgborrar)) { _Dgborrar = value; OnPropertyChanged(); } } }

        private long? _Listaprecioid;
        [XmlAttribute]
        public long? Listaprecioid { get => _Listaprecioid; set { if (RaiseAcceptPendingChange(value, _Listaprecioid)) { _Listaprecioid = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Listaprecioclave;
        [XmlAttribute]
        public string? Listaprecioclave { get => _Listaprecioclave; set { if (RaiseAcceptPendingChange(value, _Listaprecioclave)) { _Listaprecioclave = value; OnPropertyChanged(); } } }

        private decimal? _Precio1;
        [XmlAttribute]
        public decimal? Precio1 { get => _Precio1; set { if (RaiseAcceptPendingChange(value, _Precio1)) { _Precio1 = value; OnPropertyChanged(); } } }

        private decimal? _Precio1conimpuesto;
        [XmlAttribute]
        public decimal? Precio1conimpuesto { get => _Precio1conimpuesto; set { if (RaiseAcceptPendingChange(value, _Precio1conimpuesto)) { _Precio1conimpuesto = value; OnPropertyChanged(); } } }

        private decimal? _Precio2;
        [XmlAttribute]
        public decimal? Precio2 { get => _Precio2; set { if (RaiseAcceptPendingChange(value, _Precio2)) { _Precio2 = value; OnPropertyChanged(); } } }

        private decimal? _Precio2conimpuesto;
        [XmlAttribute]
        public decimal? Precio2conimpuesto { get => _Precio2conimpuesto; set { if (RaiseAcceptPendingChange(value, _Precio2conimpuesto)) { _Precio2conimpuesto = value; OnPropertyChanged(); } } }

        private decimal? _Precio3;
        [XmlAttribute]
        public decimal? Precio3 { get => _Precio3; set { if (RaiseAcceptPendingChange(value, _Precio3)) { _Precio3 = value; OnPropertyChanged(); } } }

        private decimal? _Precio3conimpuesto;
        [XmlAttribute]
        public decimal? Precio3conimpuesto { get => _Precio3conimpuesto; set { if (RaiseAcceptPendingChange(value, _Precio3conimpuesto)) { _Precio3conimpuesto = value; OnPropertyChanged(); } } }

        private decimal? _Precio4;
        [XmlAttribute]
        public decimal? Precio4 { get => _Precio4; set { if (RaiseAcceptPendingChange(value, _Precio4)) { _Precio4 = value; OnPropertyChanged(); } } }

        private decimal? _Precio4conimpuesto;
        [XmlAttribute]
        public decimal? Precio4conimpuesto { get => _Precio4conimpuesto; set { if (RaiseAcceptPendingChange(value, _Precio4conimpuesto)) { _Precio4conimpuesto = value; OnPropertyChanged(); } } }

        private decimal? _Precio5;
        [XmlAttribute]
        public decimal? Precio5 { get => _Precio5; set { if (RaiseAcceptPendingChange(value, _Precio5)) { _Precio5 = value; OnPropertyChanged(); } } }

        private decimal? _Precio5conimpuesto;
        [XmlAttribute]
        public decimal? Precio5conimpuesto { get => _Precio5conimpuesto; set { if (RaiseAcceptPendingChange(value, _Precio5conimpuesto)) { _Precio5conimpuesto = value; OnPropertyChanged(); } } }

        private decimal? _Costoreposicion;
        [XmlAttribute]
        public decimal? Costoreposicion { get => _Costoreposicion; set { if (RaiseAcceptPendingChange(value, _Costoreposicion)) { _Costoreposicion = value; OnPropertyChanged(); } } }

        private decimal? _Costoreposicionconimpuesto;
        [XmlAttribute]
        public decimal? Costoreposicionconimpuesto { get => _Costoreposicionconimpuesto; set { if (RaiseAcceptPendingChange(value, _Costoreposicionconimpuesto)) { _Costoreposicionconimpuesto = value; OnPropertyChanged(); } } }

        private string? _Tienevig;
        [XmlAttribute]
        public string? Tienevig { get => _Tienevig; set { if (RaiseAcceptPendingChange(value, _Tienevig)) { _Tienevig = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavig;
        [XmlAttribute]
        public DateTimeOffset? Fechavig { get => _Fechavig; set { if (RaiseAcceptPendingChange(value, _Fechavig)) { _Fechavig = value; OnPropertyChanged(); } } }

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

