
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
    public class WFMovilSolicitarArchivosRemotosWFBindingModel : Validatable
    {

        public WFMovilSolicitarArchivosRemotosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cbdias;
        [XmlAttribute]
        public long? Cbdias { get => _Cbdias; set { if (RaiseAcceptPendingChange(value, _Cbdias)) { _Cbdias = value; OnPropertyChanged(); } } }

        private string? _CbdiasClave;
        [XmlAttribute]
        public string? CbdiasClave { get => _CbdiasClave; set { if (RaiseAcceptPendingChange(value, _CbdiasClave)) { _CbdiasClave = value; OnPropertyChanged(); } } }

        private string? _CbdiasNombre;
        [XmlAttribute]
        public string? CbdiasNombre { get => _CbdiasNombre; set { if (RaiseAcceptPendingChange(value, _CbdiasNombre)) { _CbdiasNombre = value; OnPropertyChanged(); } } }

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

