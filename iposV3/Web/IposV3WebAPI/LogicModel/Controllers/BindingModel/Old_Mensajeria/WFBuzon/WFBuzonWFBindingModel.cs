
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
    public class WFBuzonWFBindingModel : Validatable
    {

        public WFBuzonWFBindingModel()
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
    public class WFBuzonWF_BuzonBindingModel : Validatable
    {

        public WFBuzonWF_BuzonBindingModel()
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

        private long? _Mensajeid;
        [XmlAttribute]
        public long? Mensajeid { get => _Mensajeid; set { if (RaiseAcceptPendingChange(value, _Mensajeid)) { _Mensajeid = value; OnPropertyChanged(); } } }

        private long? _Mensajetipoid;
        [XmlAttribute]
        public long? Mensajetipoid { get => _Mensajetipoid; set { if (RaiseAcceptPendingChange(value, _Mensajetipoid)) { _Mensajetipoid = value; OnPropertyChanged(); } } }

        private string? _Asunto;
        [XmlAttribute]
        public string? Asunto { get => _Asunto; set { if (RaiseAcceptPendingChange(value, _Asunto)) { _Asunto = value; OnPropertyChanged(); } } }

        private string? _Codigolectura;
        [XmlAttribute]
        public string? Codigolectura { get => _Codigolectura; set { if (RaiseAcceptPendingChange(value, _Codigolectura)) { _Codigolectura = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

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

        private long? _Mensajeraizid;
        [XmlAttribute]
        public long? Mensajeraizid { get => _Mensajeraizid; set { if (RaiseAcceptPendingChange(value, _Mensajeraizid)) { _Mensajeraizid = value; OnPropertyChanged(); } } }

        private long? _Mensajepadreid;
        [XmlAttribute]
        public long? Mensajepadreid { get => _Mensajepadreid; set { if (RaiseAcceptPendingChange(value, _Mensajepadreid)) { _Mensajepadreid = value; OnPropertyChanged(); } } }

        private long? _Mensajeestadoid;
        [XmlAttribute]
        public long? Mensajeestadoid { get => _Mensajeestadoid; set { if (RaiseAcceptPendingChange(value, _Mensajeestadoid)) { _Mensajeestadoid = value; OnPropertyChanged(); } } }

        private long? _Mensajeusuario;
        [XmlAttribute]
        public long? Mensajeusuario { get => _Mensajeusuario; set { if (RaiseAcceptPendingChange(value, _Mensajeusuario)) { _Mensajeusuario = value; OnPropertyChanged(); } } }

        private long? _Niveldeurgenciaid;
        [XmlAttribute]
        public long? Niveldeurgenciaid { get => _Niveldeurgenciaid; set { if (RaiseAcceptPendingChange(value, _Niveldeurgenciaid)) { _Niveldeurgenciaid = value; OnPropertyChanged(); } } }

        private string? _Sucursalfuenteclave;
        [XmlAttribute]
        public string? Sucursalfuenteclave { get => _Sucursalfuenteclave; set { if (RaiseAcceptPendingChange(value, _Sucursalfuenteclave)) { _Sucursalfuenteclave = value; OnPropertyChanged(); } } }

        private string? _Mensaje;
        [XmlAttribute]
        public string? Mensaje { get => _Mensaje; set { if (RaiseAcceptPendingChange(value, _Mensaje)) { _Mensaje = value; OnPropertyChanged(); } } }

        private string? _Btnver;
        [XmlAttribute]
        public string? Btnver { get => _Btnver; set { if (RaiseAcceptPendingChange(value, _Btnver)) { _Btnver = value; OnPropertyChanged(); } } }

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

