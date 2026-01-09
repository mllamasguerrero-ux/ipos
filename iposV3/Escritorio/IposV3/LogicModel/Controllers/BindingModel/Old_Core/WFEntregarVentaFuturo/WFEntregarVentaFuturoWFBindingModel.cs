
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
    public class WFEntregarVentaFuturoWFBindingModel : Validatable
    {

        public WFEntregarVentaFuturoWFBindingModel()
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
    public class WFEntregarVentaFuturoWF_Imp_filesBindingModel : Validatable
    {

        public WFEntregarVentaFuturoWF_Imp_filesBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Referencias;
        [XmlAttribute]
        public string? Referencias { get => _Referencias; set { if (RaiseAcceptPendingChange(value, _Referencias)) { _Referencias = value; OnPropertyChanged(); } } }

        private string? _Referencia;
        [XmlAttribute]
        public string? Referencia { get => _Referencia; set { if (RaiseAcceptPendingChange(value, _Referencia)) { _Referencia = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Aplicado;
        [XmlAttribute]
        public decimal? Aplicado { get => _Aplicado; set { if (RaiseAcceptPendingChange(value, _Aplicado)) { _Aplicado = value; OnPropertyChanged(); } } }

        private decimal? _Poraplicar;
        [XmlAttribute]
        public decimal? Poraplicar { get => _Poraplicar; set { if (RaiseAcceptPendingChange(value, _Poraplicar)) { _Poraplicar = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Recibir;
        [XmlAttribute]
        public string? Recibir { get => _Recibir; set { if (RaiseAcceptPendingChange(value, _Recibir)) { _Recibir = value; OnPropertyChanged(); } } }

        private string? _Eliminar;
        [XmlAttribute]
        public string? Eliminar { get => _Eliminar; set { if (RaiseAcceptPendingChange(value, _Eliminar)) { _Eliminar = value; OnPropertyChanged(); } } }

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

