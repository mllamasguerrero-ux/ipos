
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
    public class WFDescuentoLineaPersonaWFBindingModel : Validatable
    {

        public WFDescuentoLineaPersonaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Txtdescuento;
        [XmlAttribute]
        public decimal? Txtdescuento { get => _Txtdescuento; set { if (RaiseAcceptPendingChange(value, _Txtdescuento)) { _Txtdescuento = value; OnPropertyChanged(); } } }

        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

        private long? _Txtlinea;
        [XmlAttribute]
        public long? Txtlinea { get => _Txtlinea; set { if (RaiseAcceptPendingChange(value, _Txtlinea)) { _Txtlinea = value; OnPropertyChanged(); } } }

        private string? _TxtlineaClave;
        [XmlAttribute]
        public string? TxtlineaClave { get => _TxtlineaClave; set { if (RaiseAcceptPendingChange(value, _TxtlineaClave)) { _TxtlineaClave = value; OnPropertyChanged(); } } }

        private string? _TxtlineaNombre;
        [XmlAttribute]
        public string? TxtlineaNombre { get => _TxtlineaNombre; set { if (RaiseAcceptPendingChange(value, _TxtlineaNombre)) { _TxtlineaNombre = value; OnPropertyChanged(); } } }

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
    public class WFDescuentoLineaPersonaWF_DescuentolineapersBindingModel : Validatable
    {

        public WFDescuentoLineaPersonaWF_DescuentolineapersBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Personaid;
        [XmlAttribute]
        public long? Personaid { get => _Personaid; set { if (RaiseAcceptPendingChange(value, _Personaid)) { _Personaid = value; OnPropertyChanged(); } } }

        private long? _Lineaid;
        [XmlAttribute]
        public long? Lineaid { get => _Lineaid; set { if (RaiseAcceptPendingChange(value, _Lineaid)) { _Lineaid = value; OnPropertyChanged(); } } }

        private string? _Lineaclave;
        [XmlAttribute]
        public string? Lineaclave { get => _Lineaclave; set { if (RaiseAcceptPendingChange(value, _Lineaclave)) { _Lineaclave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute]
        public decimal? Descuento { get => _Descuento; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value; OnPropertyChanged(); } } }

        private string? _Dgeditar;
        [XmlAttribute]
        public string? Dgeditar { get => _Dgeditar; set { if (RaiseAcceptPendingChange(value, _Dgeditar)) { _Dgeditar = value; OnPropertyChanged(); } } }

        private string? _Dgeliminar;
        [XmlAttribute]
        public string? Dgeliminar { get => _Dgeliminar; set { if (RaiseAcceptPendingChange(value, _Dgeliminar)) { _Dgeliminar = value; OnPropertyChanged(); } } }

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

