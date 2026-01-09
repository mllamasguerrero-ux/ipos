
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
    public class WFCatalogosSatUsoCFDIOperativoWFBindingModel : Validatable
    {

        public WFCatalogosSatUsoCFDIOperativoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Filtro;
        [XmlAttribute]
        public string? Filtro { get => _Filtro; set { if (RaiseAcceptPendingChange(value, _Filtro)) { _Filtro = value; OnPropertyChanged(); } } }

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
    public class WFCatalogosSatUsoCFDIOperativoWF_Sat_usocfdiBindingModel : Validatable
    {

        public WFCatalogosSatUsoCFDIOperativoWF_Sat_usocfdiBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Sat_clave;
        [XmlAttribute]
        public string? Sat_clave { get => _Sat_clave; set { if (RaiseAcceptPendingChange(value, _Sat_clave)) { _Sat_clave = value; OnPropertyChanged(); } } }

        private string? _Sat_descripcion;
        [XmlAttribute]
        public string? Sat_descripcion { get => _Sat_descripcion; set { if (RaiseAcceptPendingChange(value, _Sat_descripcion)) { _Sat_descripcion = value; OnPropertyChanged(); } } }

        private string? _Esoperativa;
        [XmlAttribute]
        public string? Esoperativa { get => _Esoperativa; set { if (RaiseAcceptPendingChange(value, _Esoperativa)) { _Esoperativa = value; OnPropertyChanged(); } } }

        private string? _Hacambiado;
        [XmlAttribute]
        public string? Hacambiado { get => _Hacambiado; set { if (RaiseAcceptPendingChange(value, _Hacambiado)) { _Hacambiado = value; OnPropertyChanged(); } } }

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

