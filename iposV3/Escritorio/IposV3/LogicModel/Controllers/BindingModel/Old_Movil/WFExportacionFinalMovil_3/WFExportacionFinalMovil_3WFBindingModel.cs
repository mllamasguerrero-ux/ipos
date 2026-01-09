
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
    public class WFExportacionFinalMovil_3WFBindingModel : Validatable
    {

        public WFExportacionFinalMovil_3WFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cb2;
        [XmlAttribute]
        public BoolCN? Cb2 { get => _Cb2; set { if (RaiseAcceptPendingChange(value, _Cb2)) { _Cb2 = value; OnPropertyChanged(); } } }

        private BoolCN? _CbA;
        [XmlAttribute]
        public BoolCN? CbA { get => _CbA; set { if (RaiseAcceptPendingChange(value, _CbA)) { _CbA = value; OnPropertyChanged(); } } }

        private BoolCN? _Cb0;
        [XmlAttribute]
        public BoolCN? Cb0 { get => _Cb0; set { if (RaiseAcceptPendingChange(value, _Cb0)) { _Cb0 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cb3;
        [XmlAttribute]
        public BoolCN? Cb3 { get => _Cb3; set { if (RaiseAcceptPendingChange(value, _Cb3)) { _Cb3 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfinalizarventa;
        [XmlAttribute]
        public BoolCN? Cbfinalizarventa { get => _Cbfinalizarventa; set { if (RaiseAcceptPendingChange(value, _Cbfinalizarventa)) { _Cbfinalizarventa = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbfinalizarcobranza;
        [XmlAttribute]
        public BoolCN? Cbfinalizarcobranza { get => _Cbfinalizarcobranza; set { if (RaiseAcceptPendingChange(value, _Cbfinalizarcobranza)) { _Cbfinalizarcobranza = value; OnPropertyChanged(); } } }

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

