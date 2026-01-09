
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
    public class WFCajaEditWFBindingModel : Validatable
    {

        public WFCajaEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private string? _Nombreimpresora;
        [XmlAttribute]
        public string? Nombreimpresora { get => _Nombreimpresora; set { if (RaiseAcceptPendingChange(value, _Nombreimpresora)) { _Nombreimpresora = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private long? _Terminal;
        [XmlAttribute]
        public long? Terminal { get => _Terminal; set { if (RaiseAcceptPendingChange(value, _Terminal)) { _Terminal = value; OnPropertyChanged(); } } }

        private string? _TerminalClave;
        [XmlAttribute]
        public string? TerminalClave { get => _TerminalClave; set { if (RaiseAcceptPendingChange(value, _TerminalClave)) { _TerminalClave = value; OnPropertyChanged(); } } }

        private string? _TerminalNombre;
        [XmlAttribute]
        public string? TerminalNombre { get => _TerminalNombre; set { if (RaiseAcceptPendingChange(value, _TerminalNombre)) { _TerminalNombre = value; OnPropertyChanged(); } } }

        private long? _Terminalservicios;
        [XmlAttribute]
        public long? Terminalservicios { get => _Terminalservicios; set { if (RaiseAcceptPendingChange(value, _Terminalservicios)) { _Terminalservicios = value; OnPropertyChanged(); } } }

        private string? _TerminalserviciosClave;
        [XmlAttribute]
        public string? TerminalserviciosClave { get => _TerminalserviciosClave; set { if (RaiseAcceptPendingChange(value, _TerminalserviciosClave)) { _TerminalserviciosClave = value; OnPropertyChanged(); } } }

        private string? _TerminalserviciosNombre;
        [XmlAttribute]
        public string? TerminalserviciosNombre { get => _TerminalserviciosNombre; set { if (RaiseAcceptPendingChange(value, _TerminalserviciosNombre)) { _TerminalserviciosNombre = value; OnPropertyChanged(); } } }

        private string? _Txtbancomerterminal;
        [XmlAttribute]
        public string? Txtbancomerterminal { get => _Txtbancomerterminal; set { if (RaiseAcceptPendingChange(value, _Txtbancomerterminal)) { _Txtbancomerterminal = value; OnPropertyChanged(); } } }

        private string? _Afiliacion;
        [XmlAttribute]
        public string? Afiliacion { get => _Afiliacion; set { if (RaiseAcceptPendingChange(value, _Afiliacion)) { _Afiliacion = value; OnPropertyChanged(); } } }

        private string? _Txtbancomercert;
        [XmlAttribute]
        public string? Txtbancomercert { get => _Txtbancomercert; set { if (RaiseAcceptPendingChange(value, _Txtbancomercert)) { _Txtbancomercert = value; OnPropertyChanged(); } } }

        private string? _Impresoracomanda;
        [XmlAttribute]
        public string? Impresoracomanda { get => _Impresoracomanda; set { if (RaiseAcceptPendingChange(value, _Impresoracomanda)) { _Impresoracomanda = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

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

