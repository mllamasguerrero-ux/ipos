
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
    public class WFPerfilesWFBindingModel : Validatable
    {

        public WFPerfilesWFBindingModel()
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
    public class WFPerfilesWF_TableBindingModel : Validatable
    {

        public WFPerfilesWF_TableBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Pf_perfil;
        [XmlAttribute]
        public int? Pf_perfil { get => _Pf_perfil; set { if (RaiseAcceptPendingChange(value, _Pf_perfil)) { _Pf_perfil = value; OnPropertyChanged(); } } }

        private string? _Pf_descripcion;
        [XmlAttribute]
        public string? Pf_descripcion { get => _Pf_descripcion; set { if (RaiseAcceptPendingChange(value, _Pf_descripcion)) { _Pf_descripcion = value; OnPropertyChanged(); } } }

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

