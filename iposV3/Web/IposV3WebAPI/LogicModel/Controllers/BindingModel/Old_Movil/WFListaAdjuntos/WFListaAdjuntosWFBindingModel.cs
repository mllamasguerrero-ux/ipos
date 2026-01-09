
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
    public class WFListaAdjuntosWFBindingModel : Validatable
    {

        public WFListaAdjuntosWFBindingModel()
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
    public class WFListaAdjuntosWF_AdjuntospordoctoBindingModel : Validatable
    {

        public WFListaAdjuntosWF_AdjuntospordoctoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Movtoadjuntoaid;
        [XmlAttribute]
        public long? Movtoadjuntoaid { get => _Movtoadjuntoaid; set { if (RaiseAcceptPendingChange(value, _Movtoadjuntoaid)) { _Movtoadjuntoaid = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private string? _Claveproducto;
        [XmlAttribute]
        public string? Claveproducto { get => _Claveproducto; set { if (RaiseAcceptPendingChange(value, _Claveproducto)) { _Claveproducto = value; OnPropertyChanged(); } } }

        private string? _Nombreproducto;
        [XmlAttribute]
        public string? Nombreproducto { get => _Nombreproducto; set { if (RaiseAcceptPendingChange(value, _Nombreproducto)) { _Nombreproducto = value; OnPropertyChanged(); } } }

        private string? _Descripcion1producto;
        [XmlAttribute]
        public string? Descripcion1producto { get => _Descripcion1producto; set { if (RaiseAcceptPendingChange(value, _Descripcion1producto)) { _Descripcion1producto = value; OnPropertyChanged(); } } }

        private string? _Claveproductoreferencia;
        [XmlAttribute]
        public string? Claveproductoreferencia { get => _Claveproductoreferencia; set { if (RaiseAcceptPendingChange(value, _Claveproductoreferencia)) { _Claveproductoreferencia = value; OnPropertyChanged(); } } }

        private string? _Nombreproductoreferencia;
        [XmlAttribute]
        public string? Nombreproductoreferencia { get => _Nombreproductoreferencia; set { if (RaiseAcceptPendingChange(value, _Nombreproductoreferencia)) { _Nombreproductoreferencia = value; OnPropertyChanged(); } } }

        private string? _Descripcion1productoreferencia;
        [XmlAttribute]
        public string? Descripcion1productoreferencia { get => _Descripcion1productoreferencia; set { if (RaiseAcceptPendingChange(value, _Descripcion1productoreferencia)) { _Descripcion1productoreferencia = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Dgheight;
        [XmlAttribute]
        public string? Dgheight { get => _Dgheight; set { if (RaiseAcceptPendingChange(value, _Dgheight)) { _Dgheight = value; OnPropertyChanged(); } } }

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

