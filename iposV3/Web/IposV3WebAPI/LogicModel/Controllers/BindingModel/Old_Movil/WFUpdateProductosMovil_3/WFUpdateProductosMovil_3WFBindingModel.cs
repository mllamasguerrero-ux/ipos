
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
    public class WFUpdateProductosMovil_3WFBindingModel : Validatable
    {

        public WFUpdateProductosMovil_3WFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cb2;
        [XmlAttribute]
        public BoolCN? Cb2 { get => _Cb2; set { if (RaiseAcceptPendingChange(value, _Cb2)) { _Cb2 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cb0;
        [XmlAttribute]
        public BoolCN? Cb0 { get => _Cb0; set { if (RaiseAcceptPendingChange(value, _Cb0)) { _Cb0 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cb1;
        [XmlAttribute]
        public BoolCN? Cb1 { get => _Cb1; set { if (RaiseAcceptPendingChange(value, _Cb1)) { _Cb1 = value; OnPropertyChanged(); } } }

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

