
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
    public class WFImportacionInicialMovil_2WFBindingModel : Validatable
    {

        public WFImportacionInicialMovil_2WFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cb7;
        [XmlAttribute]
        public BoolCN? Cb7 { get => _Cb7; set { if (RaiseAcceptPendingChange(value, _Cb7)) { _Cb7 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cb2;
        [XmlAttribute]
        public BoolCN? Cb2 { get => _Cb2; set { if (RaiseAcceptPendingChange(value, _Cb2)) { _Cb2 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cb3;
        [XmlAttribute]
        public BoolCN? Cb3 { get => _Cb3; set { if (RaiseAcceptPendingChange(value, _Cb3)) { _Cb3 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cb4;
        [XmlAttribute]
        public BoolCN? Cb4 { get => _Cb4; set { if (RaiseAcceptPendingChange(value, _Cb4)) { _Cb4 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cb5;
        [XmlAttribute]
        public BoolCN? Cb5 { get => _Cb5; set { if (RaiseAcceptPendingChange(value, _Cb5)) { _Cb5 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cb6;
        [XmlAttribute]
        public BoolCN? Cb6 { get => _Cb6; set { if (RaiseAcceptPendingChange(value, _Cb6)) { _Cb6 = value; OnPropertyChanged(); } } }

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

