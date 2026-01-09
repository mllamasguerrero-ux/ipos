
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
    public class WFSeleccionarFormaPagoFEWFBindingModel : Validatable
    {

        public WFSeleccionarFormaPagoFEWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Combobox1;
        [XmlAttribute]
        public long? Combobox1 { get => _Combobox1; set { if (RaiseAcceptPendingChange(value, _Combobox1)) { _Combobox1 = value; OnPropertyChanged(); } } }

        private string? _Combobox1Clave;
        [XmlAttribute]
        public string? Combobox1Clave { get => _Combobox1Clave; set { if (RaiseAcceptPendingChange(value, _Combobox1Clave)) { _Combobox1Clave = value; OnPropertyChanged(); } } }

        private string? _Combobox1Nombre;
        [XmlAttribute]
        public string? Combobox1Nombre { get => _Combobox1Nombre; set { if (RaiseAcceptPendingChange(value, _Combobox1Nombre)) { _Combobox1Nombre = value; OnPropertyChanged(); } } }

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

