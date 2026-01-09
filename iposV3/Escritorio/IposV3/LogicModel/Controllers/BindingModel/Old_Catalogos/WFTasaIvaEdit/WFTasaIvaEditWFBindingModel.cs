
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
    public class WFTasaIvaEditWFBindingModel : Validatable
    {

        public WFTasaIvaEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private decimal? _Tasa;
        [XmlAttribute]
        public decimal? Tasa { get => _Tasa; set { if (RaiseAcceptPendingChange(value, _Tasa)) { _Tasa = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechainicia;
        [XmlAttribute]
        public DateTimeOffset? Fechainicia { get => _Fechainicia; set { if (RaiseAcceptPendingChange(value, _Fechainicia)) { _Fechainicia = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

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

