
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
    public class WFAdjuntarArchivosWFBindingModel : Validatable
    {

        public WFAdjuntarArchivosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Txthorastrabajo;
        [XmlAttribute]
        public long? Txthorastrabajo { get => _Txthorastrabajo; set { if (RaiseAcceptPendingChange(value, _Txthorastrabajo)) { _Txthorastrabajo = value; OnPropertyChanged(); } } }

        private string? _TxthorastrabajoClave;
        [XmlAttribute]
        public string? TxthorastrabajoClave { get => _TxthorastrabajoClave; set { if (RaiseAcceptPendingChange(value, _TxthorastrabajoClave)) { _TxthorastrabajoClave = value; OnPropertyChanged(); } } }

        private string? _TxthorastrabajoNombre;
        [XmlAttribute]
        public string? TxthorastrabajoNombre { get => _TxthorastrabajoNombre; set { if (RaiseAcceptPendingChange(value, _TxthorastrabajoNombre)) { _TxthorastrabajoNombre = value; OnPropertyChanged(); } } }

        private long? _Lvarchivosadjuntos;
        [XmlAttribute]
        public long? Lvarchivosadjuntos { get => _Lvarchivosadjuntos; set { if (RaiseAcceptPendingChange(value, _Lvarchivosadjuntos)) { _Lvarchivosadjuntos = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Datetimepicker1;
        [XmlAttribute]
        public DateTimeOffset? Datetimepicker1 { get => _Datetimepicker1; set { if (RaiseAcceptPendingChange(value, _Datetimepicker1)) { _Datetimepicker1 = value; OnPropertyChanged(); } } }

        private string? _LvarchivosadjuntosClave;
        [XmlAttribute]
        public string? LvarchivosadjuntosClave { get => _LvarchivosadjuntosClave; set { if (RaiseAcceptPendingChange(value, _LvarchivosadjuntosClave)) { _LvarchivosadjuntosClave = value; OnPropertyChanged(); } } }

        private string? _LvarchivosadjuntosNombre;
        [XmlAttribute]
        public string? LvarchivosadjuntosNombre { get => _LvarchivosadjuntosNombre; set { if (RaiseAcceptPendingChange(value, _LvarchivosadjuntosNombre)) { _LvarchivosadjuntosNombre = value; OnPropertyChanged(); } } }

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

