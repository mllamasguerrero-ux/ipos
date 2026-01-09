
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
    public class WFSeleccionarAbonoWFBindingModel : Validatable
    {

        public WFSeleccionarAbonoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Numeroabono;
        [XmlAttribute]
        public int? Numeroabono { get => _Numeroabono; set { if (RaiseAcceptPendingChange(value, _Numeroabono)) { _Numeroabono = value; OnPropertyChanged(); } } }

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

