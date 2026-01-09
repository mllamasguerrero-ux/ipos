
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
    public class WFUsuariosWFBindingModel : Validatable
    {

        public WFUsuariosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




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

    
    [XmlRoot]
    public class WFUsuariosWF_TableBindingModel : Validatable
    {

        public WFUsuariosWF_TableBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Username;
        [XmlAttribute]
        public string? Username { get => _Username; set { if (RaiseAcceptPendingChange(value, _Username)) { _Username = value; OnPropertyChanged(); } } }

        private string? _Claveacceso;
        [XmlAttribute]
        public string? Claveacceso { get => _Claveacceso; set { if (RaiseAcceptPendingChange(value, _Claveacceso)) { _Claveacceso = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Vigencia;
        [XmlAttribute]
        public DateTimeOffset? Vigencia { get => _Vigencia; set { if (RaiseAcceptPendingChange(value, _Vigencia)) { _Vigencia = value; OnPropertyChanged(); } } }

        private short? _Reset_pass;
        [XmlAttribute]
        public short? Reset_pass { get => _Reset_pass; set { if (RaiseAcceptPendingChange(value, _Reset_pass)) { _Reset_pass = value; OnPropertyChanged(); } } }

        private string? _Colver;
        [XmlAttribute]
        public string? Colver { get => _Colver; set { if (RaiseAcceptPendingChange(value, _Colver)) { _Colver = value; OnPropertyChanged(); } } }

        private string? _Coleditar;
        [XmlAttribute]
        public string? Coleditar { get => _Coleditar; set { if (RaiseAcceptPendingChange(value, _Coleditar)) { _Coleditar = value; OnPropertyChanged(); } } }

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

