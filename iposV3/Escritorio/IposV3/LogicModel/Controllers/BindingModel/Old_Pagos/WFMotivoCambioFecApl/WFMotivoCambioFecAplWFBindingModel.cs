
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
    public class WFMotivoCambioFecAplWFBindingModel : Validatable
    {

        public WFMotivoCambioFecAplWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Motivocombobox;
        [XmlAttribute]
        public long? Motivocombobox { get => _Motivocombobox; set { if (RaiseAcceptPendingChange(value, _Motivocombobox)) { _Motivocombobox = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechaaplicado;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechaaplicado { get => _Dtpfechaaplicado; set { if (RaiseAcceptPendingChange(value, _Dtpfechaaplicado)) { _Dtpfechaaplicado = value; OnPropertyChanged(); } } }

        private string? _MotivocomboboxClave;
        [XmlAttribute]
        public string? MotivocomboboxClave { get => _MotivocomboboxClave; set { if (RaiseAcceptPendingChange(value, _MotivocomboboxClave)) { _MotivocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _MotivocomboboxNombre;
        [XmlAttribute]
        public string? MotivocomboboxNombre { get => _MotivocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _MotivocomboboxNombre)) { _MotivocomboboxNombre = value; OnPropertyChanged(); } } }

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

