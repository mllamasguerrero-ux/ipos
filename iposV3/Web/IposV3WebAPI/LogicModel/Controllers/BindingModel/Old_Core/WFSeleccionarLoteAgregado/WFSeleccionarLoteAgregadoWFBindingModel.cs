
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
    public class WFSeleccionarLoteAgregadoWFBindingModel : Validatable
    {

        public WFSeleccionarLoteAgregadoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cblistlotes;
        [XmlAttribute]
        public long? Cblistlotes { get => _Cblistlotes; set { if (RaiseAcceptPendingChange(value, _Cblistlotes)) { _Cblistlotes = value; OnPropertyChanged(); } } }

        private string? _CblistlotesClave;
        [XmlAttribute]
        public string? CblistlotesClave { get => _CblistlotesClave; set { if (RaiseAcceptPendingChange(value, _CblistlotesClave)) { _CblistlotesClave = value; OnPropertyChanged(); } } }

        private string? _CblistlotesNombre;
        [XmlAttribute]
        public string? CblistlotesNombre { get => _CblistlotesNombre; set { if (RaiseAcceptPendingChange(value, _CblistlotesNombre)) { _CblistlotesNombre = value; OnPropertyChanged(); } } }

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

