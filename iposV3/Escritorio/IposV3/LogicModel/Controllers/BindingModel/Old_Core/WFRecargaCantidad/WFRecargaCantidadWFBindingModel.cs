
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
    public class WFRecargaCantidadWFBindingModel : Validatable
    {

        public WFRecargaCantidadWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Tbcantidad;
        [XmlAttribute]
        public decimal? Tbcantidad { get => _Tbcantidad; set { if (RaiseAcceptPendingChange(value, _Tbcantidad)) { _Tbcantidad = value; OnPropertyChanged(); } } }

        private long? _Cbcompania;
        [XmlAttribute]
        public long? Cbcompania { get => _Cbcompania; set { if (RaiseAcceptPendingChange(value, _Cbcompania)) { _Cbcompania = value; OnPropertyChanged(); } } }

        private string? _CbcompaniaClave;
        [XmlAttribute]
        public string? CbcompaniaClave { get => _CbcompaniaClave; set { if (RaiseAcceptPendingChange(value, _CbcompaniaClave)) { _CbcompaniaClave = value; OnPropertyChanged(); } } }

        private string? _CbcompaniaNombre;
        [XmlAttribute]
        public string? CbcompaniaNombre { get => _CbcompaniaNombre; set { if (RaiseAcceptPendingChange(value, _CbcompaniaNombre)) { _CbcompaniaNombre = value; OnPropertyChanged(); } } }

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

