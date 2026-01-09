
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
    public class WFPreguntaLoteWFBindingModel : Validatable
    {

        public WFPreguntaLoteWFBindingModel()
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
    public class WFPreguntaLoteWF_GridlotesBindingModel : Validatable
    {

        public WFPreguntaLoteWF_GridlotesBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Producto;
        [XmlAttribute]
        public string? Producto { get => _Producto; set { if (RaiseAcceptPendingChange(value, _Producto)) { _Producto = value; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private string? _Caducado;
        [XmlAttribute]
        public string? Caducado { get => _Caducado; set { if (RaiseAcceptPendingChange(value, _Caducado)) { _Caducado = value; OnPropertyChanged(); } } }

        private string? _Porcaducar;
        [XmlAttribute]
        public string? Porcaducar { get => _Porcaducar; set { if (RaiseAcceptPendingChange(value, _Porcaducar)) { _Porcaducar = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadendocto;
        [XmlAttribute]
        public decimal? Cantidadendocto { get => _Cantidadendocto; set { if (RaiseAcceptPendingChange(value, _Cantidadendocto)) { _Cantidadendocto = value; OnPropertyChanged(); } } }

        private string? _Asurtir;
        [XmlAttribute]
        public string? Asurtir { get => _Asurtir; set { if (RaiseAcceptPendingChange(value, _Asurtir)) { _Asurtir = value; OnPropertyChanged(); } } }

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

