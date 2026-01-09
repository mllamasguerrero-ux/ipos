
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
    public class WFAduanasSatWFBindingModel : Validatable
    {

        public WFAduanasSatWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Aduana;
        [XmlAttribute]
        public long? Aduana { get => _Aduana; set { if (RaiseAcceptPendingChange(value, _Aduana)) { _Aduana = value; OnPropertyChanged(); } } }

        private string? _AduanaClave;
        [XmlAttribute]
        public string? AduanaClave { get => _AduanaClave; set { if (RaiseAcceptPendingChange(value, _AduanaClave)) { _AduanaClave = value; OnPropertyChanged(); } } }

        private string? _AduanaNombre;
        [XmlAttribute]
        public string? AduanaNombre { get => _AduanaNombre; set { if (RaiseAcceptPendingChange(value, _AduanaNombre)) { _AduanaNombre = value; OnPropertyChanged(); } } }

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
    public class WFAduanasSatWF_LotesimportadosBindingModel : Validatable
    {

        public WFAduanasSatWF_LotesimportadosBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Aduana;
        [XmlAttribute]
        public string? Aduana { get => _Aduana; set { if (RaiseAcceptPendingChange(value, _Aduana)) { _Aduana = value; OnPropertyChanged(); } } }

        private string? _Aduanaasignada;
        [XmlAttribute]
        public string? Aduanaasignada { get => _Aduanaasignada; set { if (RaiseAcceptPendingChange(value, _Aduanaasignada)) { _Aduanaasignada = value; OnPropertyChanged(); } } }

        private string? _Asignaraduana;
        [XmlAttribute]
        public string? Asignaraduana { get => _Asignaraduana; set { if (RaiseAcceptPendingChange(value, _Asignaraduana)) { _Asignaraduana = value; OnPropertyChanged(); } } }

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

