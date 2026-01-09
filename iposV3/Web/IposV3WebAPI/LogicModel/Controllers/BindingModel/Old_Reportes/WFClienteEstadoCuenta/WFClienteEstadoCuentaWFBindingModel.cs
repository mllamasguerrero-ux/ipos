
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
    public class WFClienteEstadoCuentaWFBindingModel : Validatable
    {

        public WFClienteEstadoCuentaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbesapartado;
        [XmlAttribute]
        public BoolCN? Cbesapartado { get => _Cbesapartado; set { if (RaiseAcceptPendingChange(value, _Cbesapartado)) { _Cbesapartado = value; OnPropertyChanged(); } } }

        private long? _Personaid;
        [XmlAttribute]
        public long? Personaid { get => _Personaid; set { if (RaiseAcceptPendingChange(value, _Personaid)) { _Personaid = value; OnPropertyChanged(); } } }

        private string? _PersonaidClave;
        [XmlAttribute]
        public string? PersonaidClave { get => _PersonaidClave; set { if (RaiseAcceptPendingChange(value, _PersonaidClave)) { _PersonaidClave = value; OnPropertyChanged(); } } }

        private string? _PersonaidNombre;
        [XmlAttribute]
        public string? PersonaidNombre { get => _PersonaidNombre; set { if (RaiseAcceptPendingChange(value, _PersonaidNombre)) { _PersonaidNombre = value; OnPropertyChanged(); } } }

        private long? _Personaapartadoid;
        [XmlAttribute]
        public long? Personaapartadoid { get => _Personaapartadoid; set { if (RaiseAcceptPendingChange(value, _Personaapartadoid)) { _Personaapartadoid = value; OnPropertyChanged(); } } }

        private string? _PersonaapartadoidClave;
        [XmlAttribute]
        public string? PersonaapartadoidClave { get => _PersonaapartadoidClave; set { if (RaiseAcceptPendingChange(value, _PersonaapartadoidClave)) { _PersonaapartadoidClave = value; OnPropertyChanged(); } } }

        private string? _PersonaapartadoidNombre;
        [XmlAttribute]
        public string? PersonaapartadoidNombre { get => _PersonaapartadoidNombre; set { if (RaiseAcceptPendingChange(value, _PersonaapartadoidNombre)) { _PersonaapartadoidNombre = value; OnPropertyChanged(); } } }

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

