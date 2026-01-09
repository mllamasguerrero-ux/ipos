
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
    public class WFAnticiposWFBindingModel : Validatable
    {

        public WFAnticiposWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbventafuturofolio;
        [XmlAttribute]
        public string? Tbventafuturofolio { get => _Tbventafuturofolio; set { if (RaiseAcceptPendingChange(value, _Tbventafuturofolio)) { _Tbventafuturofolio = value; OnPropertyChanged(); } } }

        private long? _Proveedor1id;
        [XmlAttribute]
        public long? Proveedor1id { get => _Proveedor1id; set { if (RaiseAcceptPendingChange(value, _Proveedor1id)) { _Proveedor1id = value; OnPropertyChanged(); } } }

        private string? _Proveedor1idClave;
        [XmlAttribute]
        public string? Proveedor1idClave { get => _Proveedor1idClave; set { if (RaiseAcceptPendingChange(value, _Proveedor1idClave)) { _Proveedor1idClave = value; OnPropertyChanged(); } } }

        private string? _Proveedor1idNombre;
        [XmlAttribute]
        public string? Proveedor1idNombre { get => _Proveedor1idNombre; set { if (RaiseAcceptPendingChange(value, _Proveedor1idNombre)) { _Proveedor1idNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechaelaboracion;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechaelaboracion { get => _Dtpfechaelaboracion; set { if (RaiseAcceptPendingChange(value, _Dtpfechaelaboracion)) { _Dtpfechaelaboracion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfecharecepcion;
        [XmlAttribute]
        public DateTimeOffset? Dtpfecharecepcion { get => _Dtpfecharecepcion; set { if (RaiseAcceptPendingChange(value, _Dtpfecharecepcion)) { _Dtpfecharecepcion = value; OnPropertyChanged(); } } }

        private decimal? _Pa_abono;
        [XmlAttribute]
        public decimal? Pa_abono { get => _Pa_abono; set { if (RaiseAcceptPendingChange(value, _Pa_abono)) { _Pa_abono = value; OnPropertyChanged(); } } }

        private long? _Combobanco;
        [XmlAttribute]
        public long? Combobanco { get => _Combobanco; set { if (RaiseAcceptPendingChange(value, _Combobanco)) { _Combobanco = value; OnPropertyChanged(); } } }

        private long? _Formapagocombobox;
        [XmlAttribute]
        public long? Formapagocombobox { get => _Formapagocombobox; set { if (RaiseAcceptPendingChange(value, _Formapagocombobox)) { _Formapagocombobox = value; OnPropertyChanged(); } } }

        private string? _Tbreferencia;
        [XmlAttribute]
        public string? Tbreferencia { get => _Tbreferencia; set { if (RaiseAcceptPendingChange(value, _Tbreferencia)) { _Tbreferencia = value; OnPropertyChanged(); } } }

        private string? _Tbnotas;
        [XmlAttribute]
        public string? Tbnotas { get => _Tbnotas; set { if (RaiseAcceptPendingChange(value, _Tbnotas)) { _Tbnotas = value; OnPropertyChanged(); } } }

        private long? _Clienteid;
        [XmlAttribute]
        public long? Clienteid { get => _Clienteid; set { if (RaiseAcceptPendingChange(value, _Clienteid)) { _Clienteid = value; OnPropertyChanged(); } } }

        private string? _ClienteidClave;
        [XmlAttribute]
        public string? ClienteidClave { get => _ClienteidClave; set { if (RaiseAcceptPendingChange(value, _ClienteidClave)) { _ClienteidClave = value; OnPropertyChanged(); } } }

        private string? _ClienteidNombre;
        [XmlAttribute]
        public string? ClienteidNombre { get => _ClienteidNombre; set { if (RaiseAcceptPendingChange(value, _ClienteidNombre)) { _ClienteidNombre = value; OnPropertyChanged(); } } }

        private string? _CombobancoClave;
        [XmlAttribute]
        public string? CombobancoClave { get => _CombobancoClave; set { if (RaiseAcceptPendingChange(value, _CombobancoClave)) { _CombobancoClave = value; OnPropertyChanged(); } } }

        private string? _CombobancoNombre;
        [XmlAttribute]
        public string? CombobancoNombre { get => _CombobancoNombre; set { if (RaiseAcceptPendingChange(value, _CombobancoNombre)) { _CombobancoNombre = value; OnPropertyChanged(); } } }

        private string? _FormapagocomboboxClave;
        [XmlAttribute]
        public string? FormapagocomboboxClave { get => _FormapagocomboboxClave; set { if (RaiseAcceptPendingChange(value, _FormapagocomboboxClave)) { _FormapagocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _FormapagocomboboxNombre;
        [XmlAttribute]
        public string? FormapagocomboboxNombre { get => _FormapagocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _FormapagocomboboxNombre)) { _FormapagocomboboxNombre = value; OnPropertyChanged(); } } }

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
    public class WFAnticiposWF_Get_lista_abonos_doctoBindingModel : Validatable
    {

        public WFAnticiposWF_Get_lista_abonos_doctoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaelaboracion;
        [XmlAttribute]
        public DateTimeOffset? Fechaelaboracion { get => _Fechaelaboracion; set { if (RaiseAcceptPendingChange(value, _Fechaelaboracion)) { _Fechaelaboracion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecharecepcion;
        [XmlAttribute]
        public DateTimeOffset? Fecharecepcion { get => _Fecharecepcion; set { if (RaiseAcceptPendingChange(value, _Fecharecepcion)) { _Fecharecepcion = value; OnPropertyChanged(); } } }

        private string? _Formadepago;
        [XmlAttribute]
        public string? Formadepago { get => _Formadepago; set { if (RaiseAcceptPendingChange(value, _Formadepago)) { _Formadepago = value; OnPropertyChanged(); } } }

        private decimal? _Monto;
        [XmlAttribute]
        public decimal? Monto { get => _Monto; set { if (RaiseAcceptPendingChange(value, _Monto)) { _Monto = value; OnPropertyChanged(); } } }

        private string? _Banco;
        [XmlAttribute]
        public string? Banco { get => _Banco; set { if (RaiseAcceptPendingChange(value, _Banco)) { _Banco = value; OnPropertyChanged(); } } }

        private string? _Referenciabancaria;
        [XmlAttribute]
        public string? Referenciabancaria { get => _Referenciabancaria; set { if (RaiseAcceptPendingChange(value, _Referenciabancaria)) { _Referenciabancaria = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Tipoabonodescripcion;
        [XmlAttribute]
        public string? Tipoabonodescripcion { get => _Tipoabonodescripcion; set { if (RaiseAcceptPendingChange(value, _Tipoabonodescripcion)) { _Tipoabonodescripcion = value; OnPropertyChanged(); } } }

        private long? _Formapagoid;
        [XmlAttribute]
        public long? Formapagoid { get => _Formapagoid; set { if (RaiseAcceptPendingChange(value, _Formapagoid)) { _Formapagoid = value; OnPropertyChanged(); } } }

        private int? _Folioref;
        [XmlAttribute]
        public int? Folioref { get => _Folioref; set { if (RaiseAcceptPendingChange(value, _Folioref)) { _Folioref = value; OnPropertyChanged(); } } }

        private string? _Dgeditar;
        [XmlAttribute]
        public string? Dgeditar { get => _Dgeditar; set { if (RaiseAcceptPendingChange(value, _Dgeditar)) { _Dgeditar = value; OnPropertyChanged(); } } }

        private long? _Tipoabonoid;
        [XmlAttribute]
        public long? Tipoabonoid { get => _Tipoabonoid; set { if (RaiseAcceptPendingChange(value, _Tipoabonoid)) { _Tipoabonoid = value; OnPropertyChanged(); } } }

        private string? _Revertido;
        [XmlAttribute]
        public string? Revertido { get => _Revertido; set { if (RaiseAcceptPendingChange(value, _Revertido)) { _Revertido = value; OnPropertyChanged(); } } }

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

