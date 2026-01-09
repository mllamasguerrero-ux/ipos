
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
    public class WFAreaEditWFBindingModel : Validatable
    {

        public WFAreaEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

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
    public class WFAreaEditWF_AreaderechosBindingModel : Validatable
    {

        public WFAreaEditWF_AreaderechosBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Dr_derecho;
        [XmlAttribute]
        public int? Dr_derecho { get => _Dr_derecho; set { if (RaiseAcceptPendingChange(value, _Dr_derecho)) { _Dr_derecho = value; OnPropertyChanged(); } } }

        private string? _Dr_descripcion;
        [XmlAttribute]
        public string? Dr_descripcion { get => _Dr_descripcion; set { if (RaiseAcceptPendingChange(value, _Dr_descripcion)) { _Dr_descripcion = value; OnPropertyChanged(); } } }

        private int? _Permitido;
        [XmlAttribute]
        public int? Permitido { get => _Permitido; set { if (RaiseAcceptPendingChange(value, _Permitido)) { _Permitido = value; OnPropertyChanged(); } } }

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

