
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
    public class EMPRESASEdit_RegWFBindingModel : Validatable
    {

        public EMPRESASEdit_RegWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Em_usuario;
        [XmlAttribute]
        public string? Em_usuario { get => _Em_usuario; set { if (RaiseAcceptPendingChange(value, _Em_usuario)) { _Em_usuario = value; OnPropertyChanged(); } } }

        private string? _Em_password;
        [XmlAttribute]
        public string? Em_password { get => _Em_password; set { if (RaiseAcceptPendingChange(value, _Em_password)) { _Em_password = value; OnPropertyChanged(); } } }

        private string? _Em_server;
        [XmlAttribute]
        public string? Em_server { get => _Em_server; set { if (RaiseAcceptPendingChange(value, _Em_server)) { _Em_server = value; OnPropertyChanged(); } } }

        private long? _Em_cajacombobox;
        [XmlAttribute]
        public long? Em_cajacombobox { get => _Em_cajacombobox; set { if (RaiseAcceptPendingChange(value, _Em_cajacombobox)) { _Em_cajacombobox = value; OnPropertyChanged(); } } }

        private BoolCN? _Habilitar_impexp_aut;
        [XmlAttribute]
        public BoolCN? Habilitar_impexp_aut { get => _Habilitar_impexp_aut; set { if (RaiseAcceptPendingChange(value, _Habilitar_impexp_aut)) { _Habilitar_impexp_aut = value; OnPropertyChanged(); } } }

        private BoolCN? _Esmatriz;
        [XmlAttribute]
        public BoolCN? Esmatriz { get => _Esmatriz; set { if (RaiseAcceptPendingChange(value, _Esmatriz)) { _Esmatriz = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_pooling;
        [XmlAttribute]
        public BoolCN? Hab_pooling { get => _Hab_pooling; set { if (RaiseAcceptPendingChange(value, _Hab_pooling)) { _Hab_pooling = value; OnPropertyChanged(); } } }

        private BoolCN? _Replicador;
        [XmlAttribute]
        public BoolCN? Replicador { get => _Replicador; set { if (RaiseAcceptPendingChange(value, _Replicador)) { _Replicador = value; OnPropertyChanged(); } } }

        private string? _Em_nombre;
        [XmlAttribute]
        public string? Em_nombre { get => _Em_nombre; set { if (RaiseAcceptPendingChange(value, _Em_nombre)) { _Em_nombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcustomconn;
        [XmlAttribute]
        public BoolCN? Cbcustomconn { get => _Cbcustomconn; set { if (RaiseAcceptPendingChange(value, _Cbcustomconn)) { _Cbcustomconn = value; OnPropertyChanged(); } } }

        private string? _Em_database;
        [XmlAttribute]
        public string? Em_database { get => _Em_database; set { if (RaiseAcceptPendingChange(value, _Em_database)) { _Em_database = value; OnPropertyChanged(); } } }

        private string? _Em_cajacomboboxClave;
        [XmlAttribute]
        public string? Em_cajacomboboxClave { get => _Em_cajacomboboxClave; set { if (RaiseAcceptPendingChange(value, _Em_cajacomboboxClave)) { _Em_cajacomboboxClave = value; OnPropertyChanged(); } } }

        private string? _Em_cajacomboboxNombre;
        [XmlAttribute]
        public string? Em_cajacomboboxNombre { get => _Em_cajacomboboxNombre; set { if (RaiseAcceptPendingChange(value, _Em_cajacomboboxNombre)) { _Em_cajacomboboxNombre = value; OnPropertyChanged(); } } }

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

