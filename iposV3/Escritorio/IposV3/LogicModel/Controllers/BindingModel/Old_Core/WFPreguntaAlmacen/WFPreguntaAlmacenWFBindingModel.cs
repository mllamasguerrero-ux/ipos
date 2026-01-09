
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
    public class WFPreguntaAlmacenWFBindingModel : Validatable
    {

        public WFPreguntaAlmacenWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Almacenorigencombobox;
        [XmlAttribute]
        public long? Almacenorigencombobox { get => _Almacenorigencombobox; set { if (RaiseAcceptPendingChange(value, _Almacenorigencombobox)) { _Almacenorigencombobox = value; OnPropertyChanged(); } } }

        private long? _Almacendestinocombobox;
        [XmlAttribute]
        public long? Almacendestinocombobox { get => _Almacendestinocombobox; set { if (RaiseAcceptPendingChange(value, _Almacendestinocombobox)) { _Almacendestinocombobox = value; OnPropertyChanged(); } } }

        private string? _AlmacenorigencomboboxClave;
        [XmlAttribute]
        public string? AlmacenorigencomboboxClave { get => _AlmacenorigencomboboxClave; set { if (RaiseAcceptPendingChange(value, _AlmacenorigencomboboxClave)) { _AlmacenorigencomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AlmacenorigencomboboxNombre;
        [XmlAttribute]
        public string? AlmacenorigencomboboxNombre { get => _AlmacenorigencomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AlmacenorigencomboboxNombre)) { _AlmacenorigencomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _AlmacendestinocomboboxClave;
        [XmlAttribute]
        public string? AlmacendestinocomboboxClave { get => _AlmacendestinocomboboxClave; set { if (RaiseAcceptPendingChange(value, _AlmacendestinocomboboxClave)) { _AlmacendestinocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AlmacendestinocomboboxNombre;
        [XmlAttribute]
        public string? AlmacendestinocomboboxNombre { get => _AlmacendestinocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AlmacendestinocomboboxNombre)) { _AlmacendestinocomboboxNombre = value; OnPropertyChanged(); } } }

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

