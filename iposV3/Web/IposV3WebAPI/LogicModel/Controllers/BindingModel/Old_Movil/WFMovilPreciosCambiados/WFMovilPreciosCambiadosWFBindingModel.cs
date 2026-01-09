
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
    public class WFMovilPreciosCambiadosWFBindingModel : Validatable
    {

        public WFMovilPreciosCambiadosWFBindingModel()
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
    public class WFMovilPreciosCambiadosWF_1BindingModel : Validatable
    {

        public WFMovilPreciosCambiadosWF_1BindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Iproducto;
        [XmlAttribute]
        public string? Iproducto { get => _Iproducto; set { if (RaiseAcceptPendingChange(value, _Iproducto)) { _Iproducto = value; OnPropertyChanged(); } } }

        private string? _Idesc1;
        [XmlAttribute]
        public string? Idesc1 { get => _Idesc1; set { if (RaiseAcceptPendingChange(value, _Idesc1)) { _Idesc1 = value; OnPropertyChanged(); } } }

        private string? _Iprecio1;
        [XmlAttribute]
        public string? Iprecio1 { get => _Iprecio1; set { if (RaiseAcceptPendingChange(value, _Iprecio1)) { _Iprecio1 = value; OnPropertyChanged(); } } }

        private string? _Iprecio2;
        [XmlAttribute]
        public string? Iprecio2 { get => _Iprecio2; set { if (RaiseAcceptPendingChange(value, _Iprecio2)) { _Iprecio2 = value; OnPropertyChanged(); } } }

        private string? _Iprecio3;
        [XmlAttribute]
        public string? Iprecio3 { get => _Iprecio3; set { if (RaiseAcceptPendingChange(value, _Iprecio3)) { _Iprecio3 = value; OnPropertyChanged(); } } }

        private string? _Iprecio4;
        [XmlAttribute]
        public string? Iprecio4 { get => _Iprecio4; set { if (RaiseAcceptPendingChange(value, _Iprecio4)) { _Iprecio4 = value; OnPropertyChanged(); } } }

        private string? _Iprecio5;
        [XmlAttribute]
        public string? Iprecio5 { get => _Iprecio5; set { if (RaiseAcceptPendingChange(value, _Iprecio5)) { _Iprecio5 = value; OnPropertyChanged(); } } }

        private string? _Iprecio6;
        [XmlAttribute]
        public string? Iprecio6 { get => _Iprecio6; set { if (RaiseAcceptPendingChange(value, _Iprecio6)) { _Iprecio6 = value; OnPropertyChanged(); } } }

        private string? _Iprecio7;
        [XmlAttribute]
        public string? Iprecio7 { get => _Iprecio7; set { if (RaiseAcceptPendingChange(value, _Iprecio7)) { _Iprecio7 = value; OnPropertyChanged(); } } }

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

