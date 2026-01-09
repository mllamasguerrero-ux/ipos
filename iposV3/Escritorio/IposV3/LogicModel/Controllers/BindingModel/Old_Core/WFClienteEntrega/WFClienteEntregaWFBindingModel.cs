
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
    public class WFClienteEntregaWFBindingModel : Validatable
    {

        public WFClienteEntregaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Ciudad;
        [XmlAttribute]
        public string? Ciudad { get => _Ciudad; set { if (RaiseAcceptPendingChange(value, _Ciudad)) { _Ciudad = value; OnPropertyChanged(); } } }

        private string? _Celular;
        [XmlAttribute]
        public string? Celular { get => _Celular; set { if (RaiseAcceptPendingChange(value, _Celular)) { _Celular = value; OnPropertyChanged(); } } }

        private string? _Telefono1;
        [XmlAttribute]
        public string? Telefono1 { get => _Telefono1; set { if (RaiseAcceptPendingChange(value, _Telefono1)) { _Telefono1 = value; OnPropertyChanged(); } } }

        private string? _Email1;
        [XmlAttribute]
        public string? Email1 { get => _Email1; set { if (RaiseAcceptPendingChange(value, _Email1)) { _Email1 = value; OnPropertyChanged(); } } }

        private string? _Nombres;
        [XmlAttribute]
        public string? Nombres { get => _Nombres; set { if (RaiseAcceptPendingChange(value, _Nombres)) { _Nombres = value; OnPropertyChanged(); } } }

        private string? _Domicilio;
        [XmlAttribute]
        public string? Domicilio { get => _Domicilio; set { if (RaiseAcceptPendingChange(value, _Domicilio)) { _Domicilio = value; OnPropertyChanged(); } } }

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

