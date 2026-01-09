
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
    public class WFSeleccionarOrdenCompraWFBindingModel : Validatable
    {

        public WFSeleccionarOrdenCompraWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Txtordencompra;
        [XmlAttribute]
        public string? Txtordencompra { get => _Txtordencompra; set { if (RaiseAcceptPendingChange(value, _Txtordencompra)) { _Txtordencompra = value; OnPropertyChanged(); } } }

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

