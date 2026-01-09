
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
    public class WFDefineLoteImportadoWFBindingModel : Validatable
    {

        public WFDefineLoteImportadoWFBindingModel()
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

        private decimal? _Tbtipocambio;
        [XmlAttribute]
        public decimal? Tbtipocambio { get => _Tbtipocambio; set { if (RaiseAcceptPendingChange(value, _Tbtipocambio)) { _Tbtipocambio = value; OnPropertyChanged(); } } }

        private string? _Tblote;
        [XmlAttribute]
        public string? Tblote { get => _Tblote; set { if (RaiseAcceptPendingChange(value, _Tblote)) { _Tblote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtp;
        [XmlAttribute]
        public DateTimeOffset? Dtp { get => _Dtp; set { if (RaiseAcceptPendingChange(value, _Dtp)) { _Dtp = value; OnPropertyChanged(); } } }

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

