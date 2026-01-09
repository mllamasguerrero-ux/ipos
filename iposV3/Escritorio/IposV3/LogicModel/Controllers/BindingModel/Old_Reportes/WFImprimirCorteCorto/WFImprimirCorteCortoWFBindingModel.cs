
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
    public class WFImprimirCorteCortoWFBindingModel : Validatable
    {

        public WFImprimirCorteCortoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cbsumarizado;
        [XmlAttribute]
        public BoolCN? Cbsumarizado { get => _Cbsumarizado; set { if (RaiseAcceptPendingChange(value, _Cbsumarizado)) { _Cbsumarizado = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpcorte;
        [XmlAttribute]
        public DateTimeOffset? Dtpcorte { get => _Dtpcorte; set { if (RaiseAcceptPendingChange(value, _Dtpcorte)) { _Dtpcorte = value; OnPropertyChanged(); } } }

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

