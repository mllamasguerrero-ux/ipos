
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
    public class WFReporteConciliacionEmidaWFBindingModel : Validatable
    {

        public WFReporteConciliacionEmidaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpend;
        [XmlAttribute]
        public DateTimeOffset? Dtpend { get => _Dtpend; set { if (RaiseAcceptPendingChange(value, _Dtpend)) { _Dtpend = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpbegin;
        [XmlAttribute]
        public DateTimeOffset? Dtpbegin { get => _Dtpbegin; set { if (RaiseAcceptPendingChange(value, _Dtpbegin)) { _Dtpbegin = value; OnPropertyChanged(); } } }

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

