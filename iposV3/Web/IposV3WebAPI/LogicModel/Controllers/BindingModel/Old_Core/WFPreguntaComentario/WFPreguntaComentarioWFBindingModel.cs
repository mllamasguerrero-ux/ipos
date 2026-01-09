
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
    public class WFPreguntaComentarioWFBindingModel : Validatable
    {

        public WFPreguntaComentarioWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Comentario;
        [XmlAttribute]
        public string? Comentario { get => _Comentario; set { if (RaiseAcceptPendingChange(value, _Comentario)) { _Comentario = value; OnPropertyChanged(); } } }

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

