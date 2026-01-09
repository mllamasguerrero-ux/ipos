
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
    public class WFLogDetailWFBindingModel : Validatable
    {

        public WFLogDetailWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Txtloguser;
        [XmlAttribute]
        public string? Txtloguser { get => _Txtloguser; set { if (RaiseAcceptPendingChange(value, _Txtloguser)) { _Txtloguser = value; OnPropertyChanged(); } } }

        private string? _Txtlogdate;
        [XmlAttribute]
        public string? Txtlogdate { get => _Txtlogdate; set { if (RaiseAcceptPendingChange(value, _Txtlogdate)) { _Txtlogdate = value; OnPropertyChanged(); } } }

        private string? _Txtlogtable;
        [XmlAttribute]
        public string? Txtlogtable { get => _Txtlogtable; set { if (RaiseAcceptPendingChange(value, _Txtlogtable)) { _Txtlogtable = value; OnPropertyChanged(); } } }

        private string? _Txtlogregistry;
        [XmlAttribute]
        public string? Txtlogregistry { get => _Txtlogregistry; set { if (RaiseAcceptPendingChange(value, _Txtlogregistry)) { _Txtlogregistry = value; OnPropertyChanged(); } } }

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
    public class WFLogDetailWF_DetallelogBindingModel : Validatable
    {

        public WFLogDetailWF_DetallelogBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Campo;
        [XmlAttribute]
        public string? Campo { get => _Campo; set { if (RaiseAcceptPendingChange(value, _Campo)) { _Campo = value; OnPropertyChanged(); } } }

        private string? _Antes;
        [XmlAttribute]
        public string? Antes { get => _Antes; set { if (RaiseAcceptPendingChange(value, _Antes)) { _Antes = value; OnPropertyChanged(); } } }

        private string? _Despues;
        [XmlAttribute]
        public string? Despues { get => _Despues; set { if (RaiseAcceptPendingChange(value, _Despues)) { _Despues = value; OnPropertyChanged(); } } }

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

