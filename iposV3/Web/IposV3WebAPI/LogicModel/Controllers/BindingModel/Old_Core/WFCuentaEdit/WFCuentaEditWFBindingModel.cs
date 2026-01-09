
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
    public class WFCuentaEditWFBindingModel : Validatable
    {

        public WFCuentaEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Tipolineapolizaid;
        [XmlAttribute]
        public long? Tipolineapolizaid { get => _Tipolineapolizaid; set { if (RaiseAcceptPendingChange(value, _Tipolineapolizaid)) { _Tipolineapolizaid = value; OnPropertyChanged(); } } }

        private string? _TipolineapolizaidClave;
        [XmlAttribute]
        public string? TipolineapolizaidClave { get => _TipolineapolizaidClave; set { if (RaiseAcceptPendingChange(value, _TipolineapolizaidClave)) { _TipolineapolizaidClave = value; OnPropertyChanged(); } } }

        private string? _TipolineapolizaidNombre;
        [XmlAttribute]
        public string? TipolineapolizaidNombre { get => _TipolineapolizaidNombre; set { if (RaiseAcceptPendingChange(value, _TipolineapolizaidNombre)) { _TipolineapolizaidNombre = value; OnPropertyChanged(); } } }

        private long? _Formapagosatid;
        [XmlAttribute]
        public long? Formapagosatid { get => _Formapagosatid; set { if (RaiseAcceptPendingChange(value, _Formapagosatid)) { _Formapagosatid = value; OnPropertyChanged(); } } }

        private string? _FormapagosatidClave;
        [XmlAttribute]
        public string? FormapagosatidClave { get => _FormapagosatidClave; set { if (RaiseAcceptPendingChange(value, _FormapagosatidClave)) { _FormapagosatidClave = value; OnPropertyChanged(); } } }

        private string? _FormapagosatidNombre;
        [XmlAttribute]
        public string? FormapagosatidNombre { get => _FormapagosatidNombre; set { if (RaiseAcceptPendingChange(value, _FormapagosatidNombre)) { _FormapagosatidNombre = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private BoolCN? _Esfact;
        [XmlAttribute]
        public BoolCN? Esfact { get => _Esfact; set { if (RaiseAcceptPendingChange(value, _Esfact)) { _Esfact = value; OnPropertyChanged(); } } }

        private decimal? _Tasa;
        [XmlAttribute]
        public decimal? Tasa { get => _Tasa; set { if (RaiseAcceptPendingChange(value, _Tasa)) { _Tasa = value; OnPropertyChanged(); } } }

        private string? _Leyenda;
        [XmlAttribute]
        public string? Leyenda { get => _Leyenda; set { if (RaiseAcceptPendingChange(value, _Leyenda)) { _Leyenda = value; OnPropertyChanged(); } } }

        private int? _Orden;
        [XmlAttribute]
        public int? Orden { get => _Orden; set { if (RaiseAcceptPendingChange(value, _Orden)) { _Orden = value; OnPropertyChanged(); } } }

        private string? _Numucuenta;
        [XmlAttribute]
        public string? Numucuenta { get => _Numucuenta; set { if (RaiseAcceptPendingChange(value, _Numucuenta)) { _Numucuenta = value; OnPropertyChanged(); } } }

        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

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

