
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
    public class WFVehiculosWFBindingModel : Validatable
    {

        public WFVehiculosWFBindingModel()
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
    public class WFVehiculosWF_TableBindingModel : Validatable
    {

        public WFVehiculosWF_TableBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Activo;
        [XmlAttribute]
        public string? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute]
        public DateTimeOffset? Creado { get => _Creado; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value; OnPropertyChanged(); } } }

        private long? _Creadopor_userid;
        [XmlAttribute]
        public long? Creadopor_userid { get => _Creadopor_userid; set { if (RaiseAcceptPendingChange(value, _Creadopor_userid)) { _Creadopor_userid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        public DateTimeOffset? Modificado { get => _Modificado; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value; OnPropertyChanged(); } } }

        private long? _Modificadopor_userid;
        [XmlAttribute]
        public long? Modificadopor_userid { get => _Modificadopor_userid; set { if (RaiseAcceptPendingChange(value, _Modificadopor_userid)) { _Modificadopor_userid = value; OnPropertyChanged(); } } }

        private string? _Colver;
        [XmlAttribute]
        public string? Colver { get => _Colver; set { if (RaiseAcceptPendingChange(value, _Colver)) { _Colver = value; OnPropertyChanged(); } } }

        private string? _Coleditar;
        [XmlAttribute]
        public string? Coleditar { get => _Coleditar; set { if (RaiseAcceptPendingChange(value, _Coleditar)) { _Coleditar = value; OnPropertyChanged(); } } }

        private string? _Placavm;
        [XmlAttribute]
        public string? Placavm { get => _Placavm; set { if (RaiseAcceptPendingChange(value, _Placavm)) { _Placavm = value; OnPropertyChanged(); } } }

        private string? _Sat_tipopermiso_clave;
        [XmlAttribute]
        public string? Sat_tipopermiso_clave { get => _Sat_tipopermiso_clave; set { if (RaiseAcceptPendingChange(value, _Sat_tipopermiso_clave)) { _Sat_tipopermiso_clave = value; OnPropertyChanged(); } } }

        private string? _Sat_tipopermiso_desc;
        [XmlAttribute]
        public string? Sat_tipopermiso_desc { get => _Sat_tipopermiso_desc; set { if (RaiseAcceptPendingChange(value, _Sat_tipopermiso_desc)) { _Sat_tipopermiso_desc = value; OnPropertyChanged(); } } }

        private string? _Numpermisosct;
        [XmlAttribute]
        public string? Numpermisosct { get => _Numpermisosct; set { if (RaiseAcceptPendingChange(value, _Numpermisosct)) { _Numpermisosct = value; OnPropertyChanged(); } } }

        private string? _Sat_configautotransporte_clave;
        [XmlAttribute]
        public string? Sat_configautotransporte_clave { get => _Sat_configautotransporte_clave; set { if (RaiseAcceptPendingChange(value, _Sat_configautotransporte_clave)) { _Sat_configautotransporte_clave = value; OnPropertyChanged(); } } }

        private string? _Sat_configautotransporte_desc;
        [XmlAttribute]
        public string? Sat_configautotransporte_desc { get => _Sat_configautotransporte_desc; set { if (RaiseAcceptPendingChange(value, _Sat_configautotransporte_desc)) { _Sat_configautotransporte_desc = value; OnPropertyChanged(); } } }

        private string? _Aniomodelovm;
        [XmlAttribute]
        public string? Aniomodelovm { get => _Aniomodelovm; set { if (RaiseAcceptPendingChange(value, _Aniomodelovm)) { _Aniomodelovm = value; OnPropertyChanged(); } } }

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

