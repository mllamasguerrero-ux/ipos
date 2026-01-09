
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
    public class WFDefineLoteYCantidadWFBindingModel : Validatable
    {

        public WFDefineLoteYCantidadWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tblote;
        [XmlAttribute]
        public string? Tblote { get => _Tblote; set { if (RaiseAcceptPendingChange(value, _Tblote)) { _Tblote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtp;
        [XmlAttribute]
        public DateTimeOffset? Dtp { get => _Dtp; set { if (RaiseAcceptPendingChange(value, _Dtp)) { _Dtp = value; OnPropertyChanged(); } } }

        private decimal? _Tbcantidad;
        [XmlAttribute]
        public decimal? Tbcantidad { get => _Tbcantidad; set { if (RaiseAcceptPendingChange(value, _Tbcantidad)) { _Tbcantidad = value; OnPropertyChanged(); } } }

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

