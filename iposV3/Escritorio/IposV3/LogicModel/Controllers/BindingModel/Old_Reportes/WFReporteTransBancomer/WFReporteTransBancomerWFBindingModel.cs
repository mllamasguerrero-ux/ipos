
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
    public class WFReporteTransBancomerWFBindingModel : Validatable
    {

        public WFReporteTransBancomerWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Terminalid;
        [XmlAttribute]
        public long? Terminalid { get => _Terminalid; set { if (RaiseAcceptPendingChange(value, _Terminalid)) { _Terminalid = value; OnPropertyChanged(); } } }

        private string? _TerminalidClave;
        [XmlAttribute]
        public string? TerminalidClave { get => _TerminalidClave; set { if (RaiseAcceptPendingChange(value, _TerminalidClave)) { _TerminalidClave = value; OnPropertyChanged(); } } }

        private string? _TerminalidNombre;
        [XmlAttribute]
        public string? TerminalidNombre { get => _TerminalidNombre; set { if (RaiseAcceptPendingChange(value, _TerminalidNombre)) { _TerminalidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Todasterm;
        [XmlAttribute]
        public BoolCN? Todasterm { get => _Todasterm; set { if (RaiseAcceptPendingChange(value, _Todasterm)) { _Todasterm = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Desdedatetimepicker;
        [XmlAttribute]
        public DateTimeOffset? Desdedatetimepicker { get => _Desdedatetimepicker; set { if (RaiseAcceptPendingChange(value, _Desdedatetimepicker)) { _Desdedatetimepicker = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Hastadatetimepicker;
        [XmlAttribute]
        public DateTimeOffset? Hastadatetimepicker { get => _Hastadatetimepicker; set { if (RaiseAcceptPendingChange(value, _Hastadatetimepicker)) { _Hastadatetimepicker = value; OnPropertyChanged(); } } }

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

