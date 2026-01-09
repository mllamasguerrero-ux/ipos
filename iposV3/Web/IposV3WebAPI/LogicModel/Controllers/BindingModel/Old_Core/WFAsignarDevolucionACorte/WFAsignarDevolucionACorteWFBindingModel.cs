
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
    public class WFAsignarDevolucionACorteWFBindingModel : Validatable
    {

        public WFAsignarDevolucionACorteWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtfecha;
        [XmlAttribute]
        public DateTimeOffset? Dtfecha { get => _Dtfecha; set { if (RaiseAcceptPendingChange(value, _Dtfecha)) { _Dtfecha = value; OnPropertyChanged(); } } }

        private long? _Cbcajero;
        [XmlAttribute]
        public long? Cbcajero { get => _Cbcajero; set { if (RaiseAcceptPendingChange(value, _Cbcajero)) { _Cbcajero = value; OnPropertyChanged(); } } }

        private string? _CbcajeroClave;
        [XmlAttribute]
        public string? CbcajeroClave { get => _CbcajeroClave; set { if (RaiseAcceptPendingChange(value, _CbcajeroClave)) { _CbcajeroClave = value; OnPropertyChanged(); } } }

        private string? _CbcajeroNombre;
        [XmlAttribute]
        public string? CbcajeroNombre { get => _CbcajeroNombre; set { if (RaiseAcceptPendingChange(value, _CbcajeroNombre)) { _CbcajeroNombre = value; OnPropertyChanged(); } } }

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

