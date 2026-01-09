
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
    public class FRptProductoLocationsWFBindingModel : Validatable
    {

        public FRptProductoLocationsWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Anaqueliniciocombobox;
        [XmlAttribute]
        public long? Anaqueliniciocombobox { get => _Anaqueliniciocombobox; set { if (RaiseAcceptPendingChange(value, _Anaqueliniciocombobox)) { _Anaqueliniciocombobox = value; OnPropertyChanged(); } } }

        private long? _Anaquelfincombobox;
        [XmlAttribute]
        public long? Anaquelfincombobox { get => _Anaquelfincombobox; set { if (RaiseAcceptPendingChange(value, _Anaquelfincombobox)) { _Anaquelfincombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbticket;
        [XmlAttribute]
        public BoolCN? Cbticket { get => _Cbticket; set { if (RaiseAcceptPendingChange(value, _Cbticket)) { _Cbticket = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodos;
        [XmlAttribute]
        public BoolCN? Cbtodos { get => _Cbtodos; set { if (RaiseAcceptPendingChange(value, _Cbtodos)) { _Cbtodos = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbkitsdesensamblados;
        [XmlAttribute]
        public BoolCN? Cbkitsdesensamblados { get => _Cbkitsdesensamblados; set { if (RaiseAcceptPendingChange(value, _Cbkitsdesensamblados)) { _Cbkitsdesensamblados = value; OnPropertyChanged(); } } }

        private string? _AnaqueliniciocomboboxClave;
        [XmlAttribute]
        public string? AnaqueliniciocomboboxClave { get => _AnaqueliniciocomboboxClave; set { if (RaiseAcceptPendingChange(value, _AnaqueliniciocomboboxClave)) { _AnaqueliniciocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AnaqueliniciocomboboxNombre;
        [XmlAttribute]
        public string? AnaqueliniciocomboboxNombre { get => _AnaqueliniciocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AnaqueliniciocomboboxNombre)) { _AnaqueliniciocomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _AnaquelfincomboboxClave;
        [XmlAttribute]
        public string? AnaquelfincomboboxClave { get => _AnaquelfincomboboxClave; set { if (RaiseAcceptPendingChange(value, _AnaquelfincomboboxClave)) { _AnaquelfincomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AnaquelfincomboboxNombre;
        [XmlAttribute]
        public string? AnaquelfincomboboxNombre { get => _AnaquelfincomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AnaquelfincomboboxNombre)) { _AnaquelfincomboboxNombre = value; OnPropertyChanged(); } } }

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

