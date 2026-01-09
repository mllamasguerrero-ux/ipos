
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
    public class WFMensajesEnviadosWFBindingModel : Validatable
    {

        public WFMensajesEnviadosWFBindingModel()
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
    public class WFMensajesEnviadosWF_MensajeenviadoBindingModel : Validatable
    {

        public WFMensajesEnviadosWF_MensajeenviadoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Btnver;
        [XmlAttribute]
        public string? Btnver { get => _Btnver; set { if (RaiseAcceptPendingChange(value, _Btnver)) { _Btnver = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Mensajeid;
        [XmlAttribute]
        public long? Mensajeid { get => _Mensajeid; set { if (RaiseAcceptPendingChange(value, _Mensajeid)) { _Mensajeid = value; OnPropertyChanged(); } } }

        private long? _Mensajetipoid;
        [XmlAttribute]
        public long? Mensajetipoid { get => _Mensajetipoid; set { if (RaiseAcceptPendingChange(value, _Mensajetipoid)) { _Mensajetipoid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private string? _Asunto;
        [XmlAttribute]
        public string? Asunto { get => _Asunto; set { if (RaiseAcceptPendingChange(value, _Asunto)) { _Asunto = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Paratodassuc;
        [XmlAttribute]
        public string? Paratodassuc { get => _Paratodassuc; set { if (RaiseAcceptPendingChange(value, _Paratodassuc)) { _Paratodassuc = value; OnPropertyChanged(); } } }

        private string? _Paratodasareas;
        [XmlAttribute]
        public string? Paratodasareas { get => _Paratodasareas; set { if (RaiseAcceptPendingChange(value, _Paratodasareas)) { _Paratodasareas = value; OnPropertyChanged(); } } }

        private string? _Soloadmin;
        [XmlAttribute]
        public string? Soloadmin { get => _Soloadmin; set { if (RaiseAcceptPendingChange(value, _Soloadmin)) { _Soloadmin = value; OnPropertyChanged(); } } }

        private string? _Restrictivo;
        [XmlAttribute]
        public string? Restrictivo { get => _Restrictivo; set { if (RaiseAcceptPendingChange(value, _Restrictivo)) { _Restrictivo = value; OnPropertyChanged(); } } }

        private long? _Mensajeestadoid;
        [XmlAttribute]
        public long? Mensajeestadoid { get => _Mensajeestadoid; set { if (RaiseAcceptPendingChange(value, _Mensajeestadoid)) { _Mensajeestadoid = value; OnPropertyChanged(); } } }

        private long? _Niveldeurgenciaid;
        [XmlAttribute]
        public long? Niveldeurgenciaid { get => _Niveldeurgenciaid; set { if (RaiseAcceptPendingChange(value, _Niveldeurgenciaid)) { _Niveldeurgenciaid = value; OnPropertyChanged(); } } }

        private string? _Sucursalfuenteclave;
        [XmlAttribute]
        public string? Sucursalfuenteclave { get => _Sucursalfuenteclave; set { if (RaiseAcceptPendingChange(value, _Sucursalfuenteclave)) { _Sucursalfuenteclave = value; OnPropertyChanged(); } } }

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

