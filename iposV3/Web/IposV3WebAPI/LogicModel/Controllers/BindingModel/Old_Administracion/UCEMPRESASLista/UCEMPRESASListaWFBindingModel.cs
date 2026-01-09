
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
    public class UCEMPRESASListaWFBindingModel : Validatable
    {

        public UCEMPRESASListaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Ddoperador_empresas;
        [XmlAttribute]
        public long? Ddoperador_empresas { get => _Ddoperador_empresas; set { if (RaiseAcceptPendingChange(value, _Ddoperador_empresas)) { _Ddoperador_empresas = value; OnPropertyChanged(); } } }

        private long? _Ddbuscar_empresas;
        [XmlAttribute]
        public long? Ddbuscar_empresas { get => _Ddbuscar_empresas; set { if (RaiseAcceptPendingChange(value, _Ddbuscar_empresas)) { _Ddbuscar_empresas = value; OnPropertyChanged(); } } }

        private string? _Tbvalor_empresas;
        [XmlAttribute]
        public string? Tbvalor_empresas { get => _Tbvalor_empresas; set { if (RaiseAcceptPendingChange(value, _Tbvalor_empresas)) { _Tbvalor_empresas = value; OnPropertyChanged(); } } }

        private string? _Ddoperador_empresasClave;
        [XmlAttribute]
        public string? Ddoperador_empresasClave { get => _Ddoperador_empresasClave; set { if (RaiseAcceptPendingChange(value, _Ddoperador_empresasClave)) { _Ddoperador_empresasClave = value; OnPropertyChanged(); } } }

        private string? _Ddoperador_empresasNombre;
        [XmlAttribute]
        public string? Ddoperador_empresasNombre { get => _Ddoperador_empresasNombre; set { if (RaiseAcceptPendingChange(value, _Ddoperador_empresasNombre)) { _Ddoperador_empresasNombre = value; OnPropertyChanged(); } } }

        private string? _Ddbuscar_empresasClave;
        [XmlAttribute]
        public string? Ddbuscar_empresasClave { get => _Ddbuscar_empresasClave; set { if (RaiseAcceptPendingChange(value, _Ddbuscar_empresasClave)) { _Ddbuscar_empresasClave = value; OnPropertyChanged(); } } }

        private string? _Ddbuscar_empresasNombre;
        [XmlAttribute]
        public string? Ddbuscar_empresasNombre { get => _Ddbuscar_empresasNombre; set { if (RaiseAcceptPendingChange(value, _Ddbuscar_empresasNombre)) { _Ddbuscar_empresasNombre = value; OnPropertyChanged(); } } }

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
    public class UCEMPRESASListaWF_1_empresasBindingModel : Validatable
    {

        public UCEMPRESASListaWF_1_empresasBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Em_nombre;
        [XmlAttribute]
        public string? Em_nombre { get => _Em_nombre; set { if (RaiseAcceptPendingChange(value, _Em_nombre)) { _Em_nombre = value; OnPropertyChanged(); } } }

        private string? _Em_database;
        [XmlAttribute]
        public string? Em_database { get => _Em_database; set { if (RaiseAcceptPendingChange(value, _Em_database)) { _Em_database = value; OnPropertyChanged(); } } }

        private string? _Em_usuario;
        [XmlAttribute]
        public string? Em_usuario { get => _Em_usuario; set { if (RaiseAcceptPendingChange(value, _Em_usuario)) { _Em_usuario = value; OnPropertyChanged(); } } }

        private string? _Em_password;
        [XmlAttribute]
        public string? Em_password { get => _Em_password; set { if (RaiseAcceptPendingChange(value, _Em_password)) { _Em_password = value; OnPropertyChanged(); } } }

        private string? _Em_server;
        [XmlAttribute]
        public string? Em_server { get => _Em_server; set { if (RaiseAcceptPendingChange(value, _Em_server)) { _Em_server = value; OnPropertyChanged(); } } }

        private string? _Em_default;
        [XmlAttribute]
        public string? Em_default { get => _Em_default; set { if (RaiseAcceptPendingChange(value, _Em_default)) { _Em_default = value; OnPropertyChanged(); } } }

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

