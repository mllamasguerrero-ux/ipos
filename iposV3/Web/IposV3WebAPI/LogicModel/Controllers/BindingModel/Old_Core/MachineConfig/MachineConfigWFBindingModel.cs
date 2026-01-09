
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
    public class MachineConfigWFBindingModel : Validatable
    {

        public MachineConfigWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Txtservermachinename;
        [XmlAttribute]
        public string? Txtservermachinename { get => _Txtservermachinename; set { if (RaiseAcceptPendingChange(value, _Txtservermachinename)) { _Txtservermachinename = value; OnPropertyChanged(); } } }

        private string? _Txtpathiposserver;
        [XmlAttribute]
        public string? Txtpathiposserver { get => _Txtpathiposserver; set { if (RaiseAcceptPendingChange(value, _Txtpathiposserver)) { _Txtpathiposserver = value; OnPropertyChanged(); } } }

        private string? _Txtclientmachinename;
        [XmlAttribute]
        public string? Txtclientmachinename { get => _Txtclientmachinename; set { if (RaiseAcceptPendingChange(value, _Txtclientmachinename)) { _Txtclientmachinename = value; OnPropertyChanged(); } } }

        private string? _Txtcompanykey;
        [XmlAttribute]
        public string? Txtcompanykey { get => _Txtcompanykey; set { if (RaiseAcceptPendingChange(value, _Txtcompanykey)) { _Txtcompanykey = value; OnPropertyChanged(); } } }

        private string? _Txtpathlocalserver;
        [XmlAttribute]
        public string? Txtpathlocalserver { get => _Txtpathlocalserver; set { if (RaiseAcceptPendingChange(value, _Txtpathlocalserver)) { _Txtpathlocalserver = value; OnPropertyChanged(); } } }

        private string? _Txtpathipos;
        [XmlAttribute]
        public string? Txtpathipos { get => _Txtpathipos; set { if (RaiseAcceptPendingChange(value, _Txtpathipos)) { _Txtpathipos = value; OnPropertyChanged(); } } }

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

