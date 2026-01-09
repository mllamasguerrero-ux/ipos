
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
    public class WFLogItemsWFBindingModel : Validatable
    {

        public WFLogItemsWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cmbtabletype;
        [XmlAttribute]
        public long? Cmbtabletype { get => _Cmbtabletype; set { if (RaiseAcceptPendingChange(value, _Cmbtabletype)) { _Cmbtabletype = value; OnPropertyChanged(); } } }

        private long? _Txtloguser;
        [XmlAttribute]
        public long? Txtloguser { get => _Txtloguser; set { if (RaiseAcceptPendingChange(value, _Txtloguser)) { _Txtloguser = value; OnPropertyChanged(); } } }

        private string? _TxtloguserClave;
        [XmlAttribute]
        public string? TxtloguserClave { get => _TxtloguserClave; set { if (RaiseAcceptPendingChange(value, _TxtloguserClave)) { _TxtloguserClave = value; OnPropertyChanged(); } } }

        private string? _TxtloguserNombre;
        [XmlAttribute]
        public string? TxtloguserNombre { get => _TxtloguserNombre; set { if (RaiseAcceptPendingChange(value, _TxtloguserNombre)) { _TxtloguserNombre = value; OnPropertyChanged(); } } }

        private long? _Txtlogcliente;
        [XmlAttribute]
        public long? Txtlogcliente { get => _Txtlogcliente; set { if (RaiseAcceptPendingChange(value, _Txtlogcliente)) { _Txtlogcliente = value; OnPropertyChanged(); } } }

        private string? _TxtlogclienteClave;
        [XmlAttribute]
        public string? TxtlogclienteClave { get => _TxtlogclienteClave; set { if (RaiseAcceptPendingChange(value, _TxtlogclienteClave)) { _TxtlogclienteClave = value; OnPropertyChanged(); } } }

        private string? _TxtlogclienteNombre;
        [XmlAttribute]
        public string? TxtlogclienteNombre { get => _TxtlogclienteNombre; set { if (RaiseAcceptPendingChange(value, _TxtlogclienteNombre)) { _TxtlogclienteNombre = value; OnPropertyChanged(); } } }

        private long? _Txtlogelement;
        [XmlAttribute]
        public long? Txtlogelement { get => _Txtlogelement; set { if (RaiseAcceptPendingChange(value, _Txtlogelement)) { _Txtlogelement = value; OnPropertyChanged(); } } }

        private string? _TxtlogelementClave;
        [XmlAttribute]
        public string? TxtlogelementClave { get => _TxtlogelementClave; set { if (RaiseAcceptPendingChange(value, _TxtlogelementClave)) { _TxtlogelementClave = value; OnPropertyChanged(); } } }

        private string? _TxtlogelementNombre;
        [XmlAttribute]
        public string? TxtlogelementNombre { get => _TxtlogelementNombre; set { if (RaiseAcceptPendingChange(value, _TxtlogelementNombre)) { _TxtlogelementNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datetimepickerend;
        [XmlAttribute]
        public DateTimeOffset? Datetimepickerend { get => _Datetimepickerend; set { if (RaiseAcceptPendingChange(value, _Datetimepickerend)) { _Datetimepickerend = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datetimepickerbegin;
        [XmlAttribute]
        public DateTimeOffset? Datetimepickerbegin { get => _Datetimepickerbegin; set { if (RaiseAcceptPendingChange(value, _Datetimepickerbegin)) { _Datetimepickerbegin = value; OnPropertyChanged(); } } }

        private string? _CmbtabletypeClave;
        [XmlAttribute]
        public string? CmbtabletypeClave { get => _CmbtabletypeClave; set { if (RaiseAcceptPendingChange(value, _CmbtabletypeClave)) { _CmbtabletypeClave = value; OnPropertyChanged(); } } }

        private string? _CmbtabletypeNombre;
        [XmlAttribute]
        public string? CmbtabletypeNombre { get => _CmbtabletypeNombre; set { if (RaiseAcceptPendingChange(value, _CmbtabletypeNombre)) { _CmbtabletypeNombre = value; OnPropertyChanged(); } } }

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
    public class WFLogItemsWF_LogBindingModel : Validatable
    {

        public WFLogItemsWF_LogBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Tablaid;
        [XmlAttribute]
        public long? Tablaid { get => _Tablaid; set { if (RaiseAcceptPendingChange(value, _Tablaid)) { _Tablaid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Nombreusuario;
        [XmlAttribute]
        public string? Nombreusuario { get => _Nombreusuario; set { if (RaiseAcceptPendingChange(value, _Nombreusuario)) { _Nombreusuario = value; OnPropertyChanged(); } } }

        private string? _Antes;
        [XmlAttribute]
        public string? Antes { get => _Antes; set { if (RaiseAcceptPendingChange(value, _Antes)) { _Antes = value; OnPropertyChanged(); } } }

        private string? _Despues;
        [XmlAttribute]
        public string? Despues { get => _Despues; set { if (RaiseAcceptPendingChange(value, _Despues)) { _Despues = value; OnPropertyChanged(); } } }

        private string? _Dgver;
        [XmlAttribute]
        public string? Dgver { get => _Dgver; set { if (RaiseAcceptPendingChange(value, _Dgver)) { _Dgver = value; OnPropertyChanged(); } } }

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

