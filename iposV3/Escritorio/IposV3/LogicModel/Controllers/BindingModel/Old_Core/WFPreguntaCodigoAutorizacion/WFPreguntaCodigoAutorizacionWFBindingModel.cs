
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
    public class WFPreguntaCodigoAutorizacionWFBindingModel : Validatable
    {

        public WFPreguntaCodigoAutorizacionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Codigoautorizacion;
        [XmlAttribute]
        public string? Codigoautorizacion { get => _Codigoautorizacion; set { if (RaiseAcceptPendingChange(value, _Codigoautorizacion)) { _Codigoautorizacion = value; OnPropertyChanged(); } } }

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

