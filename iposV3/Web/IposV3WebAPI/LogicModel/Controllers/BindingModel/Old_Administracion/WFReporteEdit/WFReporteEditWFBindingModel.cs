
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
    public class WFReporteEditWFBindingModel : Validatable
    {

        public WFReporteEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Archivo;
        [XmlAttribute]
        public string? Archivo { get => _Archivo; set { if (RaiseAcceptPendingChange(value, _Archivo)) { _Archivo = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private string? _Id;
        [XmlAttribute]
        public string? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

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
    public class WFReporteEditWF_PerfilreporteBindingModel : Validatable
    {

        public WFReporteEditWF_PerfilreporteBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Pf_descripcion;
        [XmlAttribute]
        public string? Pf_descripcion { get => _Pf_descripcion; set { if (RaiseAcceptPendingChange(value, _Pf_descripcion)) { _Pf_descripcion = value; OnPropertyChanged(); } } }

        private int? _Permitido;
        [XmlAttribute]
        public int? Permitido { get => _Permitido; set { if (RaiseAcceptPendingChange(value, _Permitido)) { _Permitido = value; OnPropertyChanged(); } } }

        private int? _Pf_perfil;
        [XmlAttribute]
        public int? Pf_perfil { get => _Pf_perfil; set { if (RaiseAcceptPendingChange(value, _Pf_perfil)) { _Pf_perfil = value; OnPropertyChanged(); } } }

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

