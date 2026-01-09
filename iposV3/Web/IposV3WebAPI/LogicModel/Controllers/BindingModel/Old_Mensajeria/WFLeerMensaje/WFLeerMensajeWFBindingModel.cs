
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
    public class WFLeerMensajeWFBindingModel : Validatable
    {

        public WFLeerMensajeWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




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
    public class WFLeerMensajeWF_DatosadjuntosBindingModel : Validatable
    {

        public WFLeerMensajeWF_DatosadjuntosBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Ruta;
        [XmlAttribute]
        public string? Ruta { get => _Ruta; set { if (RaiseAcceptPendingChange(value, _Ruta)) { _Ruta = value; OnPropertyChanged(); } } }

        private string? _Nombreftp;
        [XmlAttribute]
        public string? Nombreftp { get => _Nombreftp; set { if (RaiseAcceptPendingChange(value, _Nombreftp)) { _Nombreftp = value; OnPropertyChanged(); } } }

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

