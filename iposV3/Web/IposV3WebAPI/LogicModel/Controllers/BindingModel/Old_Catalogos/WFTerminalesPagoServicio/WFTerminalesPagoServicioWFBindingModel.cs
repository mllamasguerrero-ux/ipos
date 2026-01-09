
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
    public class WFTerminalesPagoServicioWFBindingModel : Validatable
    {

        public WFTerminalesPagoServicioWFBindingModel()
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
    public class WFTerminalesPagoServicioWF_TableBindingModel : Validatable
    {

        public WFTerminalesPagoServicioWF_TableBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

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

        private string? _Activo;
        [XmlAttribute]
        public string? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private string? _Terminal;
        [XmlAttribute]
        public string? Terminal { get => _Terminal; set { if (RaiseAcceptPendingChange(value, _Terminal)) { _Terminal = value; OnPropertyChanged(); } } }

        private string? _Sucursalclave;
        [XmlAttribute]
        public string? Sucursalclave { get => _Sucursalclave; set { if (RaiseAcceptPendingChange(value, _Sucursalclave)) { _Sucursalclave = value; OnPropertyChanged(); } } }

        private long? _Consecutivo;
        [XmlAttribute]
        public long? Consecutivo { get => _Consecutivo; set { if (RaiseAcceptPendingChange(value, _Consecutivo)) { _Consecutivo = value; OnPropertyChanged(); } } }

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

