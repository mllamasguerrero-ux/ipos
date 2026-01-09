
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
    public class FRptTimbresCanceladosWFBindingModel : Validatable
    {

        public FRptTimbresCanceladosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Timbradocanceladocombobox;
        [XmlAttribute]
        public long? Timbradocanceladocombobox { get => _Timbradocanceladocombobox; set { if (RaiseAcceptPendingChange(value, _Timbradocanceladocombobox)) { _Timbradocanceladocombobox = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

        private string? _TimbradocanceladocomboboxClave;
        [XmlAttribute]
        public string? TimbradocanceladocomboboxClave { get => _TimbradocanceladocomboboxClave; set { if (RaiseAcceptPendingChange(value, _TimbradocanceladocomboboxClave)) { _TimbradocanceladocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _TimbradocanceladocomboboxNombre;
        [XmlAttribute]
        public string? TimbradocanceladocomboboxNombre { get => _TimbradocanceladocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _TimbradocanceladocomboboxNombre)) { _TimbradocanceladocomboboxNombre = value; OnPropertyChanged(); } } }

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

