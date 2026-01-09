
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
    public class WFGuiaPopUpWFBindingModel : Validatable
    {

        public WFGuiaPopUpWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Horaestimadrec;
        [XmlAttribute]
        public DateTimeOffset? Horaestimadrec { get => _Horaestimadrec; set { if (RaiseAcceptPendingChange(value, _Horaestimadrec)) { _Horaestimadrec = value; OnPropertyChanged(); } } }

        private long? _Encargadoid;
        [XmlAttribute]
        public long? Encargadoid { get => _Encargadoid; set { if (RaiseAcceptPendingChange(value, _Encargadoid)) { _Encargadoid = value; OnPropertyChanged(); } } }

        private string? _EncargadoidClave;
        [XmlAttribute]
        public string? EncargadoidClave { get => _EncargadoidClave; set { if (RaiseAcceptPendingChange(value, _EncargadoidClave)) { _EncargadoidClave = value; OnPropertyChanged(); } } }

        private string? _EncargadoidNombre;
        [XmlAttribute]
        public string? EncargadoidNombre { get => _EncargadoidNombre; set { if (RaiseAcceptPendingChange(value, _EncargadoidNombre)) { _EncargadoidNombre = value; OnPropertyChanged(); } } }

        private long? _Vehiculoid;
        [XmlAttribute]
        public long? Vehiculoid { get => _Vehiculoid; set { if (RaiseAcceptPendingChange(value, _Vehiculoid)) { _Vehiculoid = value; OnPropertyChanged(); } } }

        private string? _VehiculoidClave;
        [XmlAttribute]
        public string? VehiculoidClave { get => _VehiculoidClave; set { if (RaiseAcceptPendingChange(value, _VehiculoidClave)) { _VehiculoidClave = value; OnPropertyChanged(); } } }

        private string? _VehiculoidNombre;
        [XmlAttribute]
        public string? VehiculoidNombre { get => _VehiculoidNombre; set { if (RaiseAcceptPendingChange(value, _VehiculoidNombre)) { _VehiculoidNombre = value; OnPropertyChanged(); } } }

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

