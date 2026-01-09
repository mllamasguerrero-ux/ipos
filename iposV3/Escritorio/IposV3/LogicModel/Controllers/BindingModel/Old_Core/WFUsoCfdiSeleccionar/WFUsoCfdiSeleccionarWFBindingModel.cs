
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
    public class WFUsoCfdiSeleccionarWFBindingModel : Validatable
    {

        public WFUsoCfdiSeleccionarWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Usocfdi;
        [XmlAttribute]
        public long? Usocfdi { get => _Usocfdi; set { if (RaiseAcceptPendingChange(value, _Usocfdi)) { _Usocfdi = value; OnPropertyChanged(); } } }

        private string? _UsocfdiClave;
        [XmlAttribute]
        public string? UsocfdiClave { get => _UsocfdiClave; set { if (RaiseAcceptPendingChange(value, _UsocfdiClave)) { _UsocfdiClave = value; OnPropertyChanged(); } } }

        private string? _UsocfdiNombre;
        [XmlAttribute]
        public string? UsocfdiNombre { get => _UsocfdiNombre; set { if (RaiseAcceptPendingChange(value, _UsocfdiNombre)) { _UsocfdiNombre = value; OnPropertyChanged(); } } }

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

