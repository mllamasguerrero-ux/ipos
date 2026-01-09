
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
    public class WFSeleccionarCajaWFBindingModel : Validatable
    {

        public WFSeleccionarCajaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cajacombobox;
        [XmlAttribute]
        public long? Cajacombobox { get => _Cajacombobox; set { if (RaiseAcceptPendingChange(value, _Cajacombobox)) { _Cajacombobox = value; OnPropertyChanged(); } } }

        private string? _CajacomboboxClave;
        [XmlAttribute]
        public string? CajacomboboxClave { get => _CajacomboboxClave; set { if (RaiseAcceptPendingChange(value, _CajacomboboxClave)) { _CajacomboboxClave = value; OnPropertyChanged(); } } }

        private string? _CajacomboboxNombre;
        [XmlAttribute]
        public string? CajacomboboxNombre { get => _CajacomboboxNombre; set { if (RaiseAcceptPendingChange(value, _CajacomboboxNombre)) { _CajacomboboxNombre = value; OnPropertyChanged(); } } }

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

