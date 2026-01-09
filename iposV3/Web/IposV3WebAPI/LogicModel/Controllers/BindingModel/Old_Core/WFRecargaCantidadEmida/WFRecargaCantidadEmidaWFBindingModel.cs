
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
    public class WFRecargaCantidadEmidaWFBindingModel : Validatable
    {

        public WFRecargaCantidadEmidaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Tbmonto;
        [XmlAttribute]
        public decimal? Tbmonto { get => _Tbmonto; set { if (RaiseAcceptPendingChange(value, _Tbmonto)) { _Tbmonto = value; OnPropertyChanged(); } } }

        private long? _Cbcompaniaemida;
        [XmlAttribute]
        public long? Cbcompaniaemida { get => _Cbcompaniaemida; set { if (RaiseAcceptPendingChange(value, _Cbcompaniaemida)) { _Cbcompaniaemida = value; OnPropertyChanged(); } } }

        private string? _Txtnum1;
        [XmlAttribute]
        public string? Txtnum1 { get => _Txtnum1; set { if (RaiseAcceptPendingChange(value, _Txtnum1)) { _Txtnum1 = value; OnPropertyChanged(); } } }

        private string? _Txtnum2;
        [XmlAttribute]
        public string? Txtnum2 { get => _Txtnum2; set { if (RaiseAcceptPendingChange(value, _Txtnum2)) { _Txtnum2 = value; OnPropertyChanged(); } } }

        private long? _Cbcantidademida;
        [XmlAttribute]
        public long? Cbcantidademida { get => _Cbcantidademida; set { if (RaiseAcceptPendingChange(value, _Cbcantidademida)) { _Cbcantidademida = value; OnPropertyChanged(); } } }

        private string? _CbcompaniaemidaClave;
        [XmlAttribute]
        public string? CbcompaniaemidaClave { get => _CbcompaniaemidaClave; set { if (RaiseAcceptPendingChange(value, _CbcompaniaemidaClave)) { _CbcompaniaemidaClave = value; OnPropertyChanged(); } } }

        private string? _CbcompaniaemidaNombre;
        [XmlAttribute]
        public string? CbcompaniaemidaNombre { get => _CbcompaniaemidaNombre; set { if (RaiseAcceptPendingChange(value, _CbcompaniaemidaNombre)) { _CbcompaniaemidaNombre = value; OnPropertyChanged(); } } }

        private string? _CbcantidademidaClave;
        [XmlAttribute]
        public string? CbcantidademidaClave { get => _CbcantidademidaClave; set { if (RaiseAcceptPendingChange(value, _CbcantidademidaClave)) { _CbcantidademidaClave = value; OnPropertyChanged(); } } }

        private string? _CbcantidademidaNombre;
        [XmlAttribute]
        public string? CbcantidademidaNombre { get => _CbcantidademidaNombre; set { if (RaiseAcceptPendingChange(value, _CbcantidademidaNombre)) { _CbcantidademidaNombre = value; OnPropertyChanged(); } } }

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

