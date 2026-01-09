
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
    public class WFBitacoraCobranzaListMovilWFBindingModel : Validatable
    {

        public WFBitacoraCobranzaListMovilWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfechafinal;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafinal { get => _Dtpfechafinal; set { if (RaiseAcceptPendingChange(value, _Dtpfechafinal)) { _Dtpfechafinal = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechainicial;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicial { get => _Dtpfechainicial; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicial)) { _Dtpfechainicial = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsolopendientes;
        [XmlAttribute]
        public BoolCN? Cbsolopendientes { get => _Cbsolopendientes; set { if (RaiseAcceptPendingChange(value, _Cbsolopendientes)) { _Cbsolopendientes = value; OnPropertyChanged(); } } }

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
    public class WFBitacoraCobranzaListMovilWF_BitacobranzaBindingModel : Validatable
    {

        public WFBitacoraCobranzaListMovilWF_BitacobranzaBindingModel()
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

        private long? _Cobradorid;
        [XmlAttribute]
        public long? Cobradorid { get => _Cobradorid; set { if (RaiseAcceptPendingChange(value, _Cobradorid)) { _Cobradorid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Cobradornombre;
        [XmlAttribute]
        public string? Cobradornombre { get => _Cobradornombre; set { if (RaiseAcceptPendingChange(value, _Cobradornombre)) { _Cobradornombre = value; OnPropertyChanged(); } } }

        private decimal? _Totalabonado;
        [XmlAttribute]
        public decimal? Totalabonado { get => _Totalabonado; set { if (RaiseAcceptPendingChange(value, _Totalabonado)) { _Totalabonado = value; OnPropertyChanged(); } } }

        private string? _Estadonombre;
        [XmlAttribute]
        public string? Estadonombre { get => _Estadonombre; set { if (RaiseAcceptPendingChange(value, _Estadonombre)) { _Estadonombre = value; OnPropertyChanged(); } } }

        private string? _Dgver;
        [XmlAttribute]
        public string? Dgver { get => _Dgver; set { if (RaiseAcceptPendingChange(value, _Dgver)) { _Dgver = value; OnPropertyChanged(); } } }

        private string? _Dgeditar;
        [XmlAttribute]
        public string? Dgeditar { get => _Dgeditar; set { if (RaiseAcceptPendingChange(value, _Dgeditar)) { _Dgeditar = value; OnPropertyChanged(); } } }

        private string? _Dgcancelar;
        [XmlAttribute]
        public string? Dgcancelar { get => _Dgcancelar; set { if (RaiseAcceptPendingChange(value, _Dgcancelar)) { _Dgcancelar = value; OnPropertyChanged(); } } }

        private string? _Dgregistrarpagos;
        [XmlAttribute]
        public string? Dgregistrarpagos { get => _Dgregistrarpagos; set { if (RaiseAcceptPendingChange(value, _Dgregistrarpagos)) { _Dgregistrarpagos = value; OnPropertyChanged(); } } }

        private string? _Dgimprimir;
        [XmlAttribute]
        public string? Dgimprimir { get => _Dgimprimir; set { if (RaiseAcceptPendingChange(value, _Dgimprimir)) { _Dgimprimir = value; OnPropertyChanged(); } } }

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

