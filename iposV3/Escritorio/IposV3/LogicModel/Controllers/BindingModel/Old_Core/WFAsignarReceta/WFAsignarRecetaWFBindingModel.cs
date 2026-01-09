
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
    public class WFAsignarRecetaWFBindingModel : Validatable
    {

        public WFAsignarRecetaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Cedula;
        [XmlAttribute]
        public string? Cedula { get => _Cedula; set { if (RaiseAcceptPendingChange(value, _Cedula)) { _Cedula = value; OnPropertyChanged(); } } }

        private BoolCN? _Medicopropio;
        [XmlAttribute]
        public BoolCN? Medicopropio { get => _Medicopropio; set { if (RaiseAcceptPendingChange(value, _Medicopropio)) { _Medicopropio = value; OnPropertyChanged(); } } }

        private BoolCN? _Recetaretenida;
        [XmlAttribute]
        public BoolCN? Recetaretenida { get => _Recetaretenida; set { if (RaiseAcceptPendingChange(value, _Recetaretenida)) { _Recetaretenida = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Recetanumero;
        [XmlAttribute]
        public string? Recetanumero { get => _Recetanumero; set { if (RaiseAcceptPendingChange(value, _Recetanumero)) { _Recetanumero = value; OnPropertyChanged(); } } }

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

