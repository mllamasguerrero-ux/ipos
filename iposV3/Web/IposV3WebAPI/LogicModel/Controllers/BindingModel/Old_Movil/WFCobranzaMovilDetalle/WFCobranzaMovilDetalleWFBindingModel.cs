
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
    public class WFCobranzaMovilDetalleWFBindingModel : Validatable
    {

        public WFCobranzaMovilDetalleWFBindingModel()
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
    public class WFCobranzaMovilDetalleWF_PagoporcobranzaBindingModel : Validatable
    {

        public WFCobranzaMovilDetalleWF_PagoporcobranzaBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Pagomovilid;
        [XmlAttribute]
        public long? Pagomovilid { get => _Pagomovilid; set { if (RaiseAcceptPendingChange(value, _Pagomovilid)) { _Pagomovilid = value; OnPropertyChanged(); } } }

        private long? _Cobranzaid;
        [XmlAttribute]
        public long? Cobranzaid { get => _Cobranzaid; set { if (RaiseAcceptPendingChange(value, _Cobranzaid)) { _Cobranzaid = value; OnPropertyChanged(); } } }

        private string? _Tipo;
        [XmlAttribute]
        public string? Tipo { get => _Tipo; set { if (RaiseAcceptPendingChange(value, _Tipo)) { _Tipo = value; OnPropertyChanged(); } } }

        private long? _Estatus;
        [XmlAttribute]
        public long? Estatus { get => _Estatus; set { if (RaiseAcceptPendingChange(value, _Estatus)) { _Estatus = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private long? _Tipopagoid;
        [XmlAttribute]
        public long? Tipopagoid { get => _Tipopagoid; set { if (RaiseAcceptPendingChange(value, _Tipopagoid)) { _Tipopagoid = value; OnPropertyChanged(); } } }

        private string? _Ventacobranza;
        [XmlAttribute]
        public string? Ventacobranza { get => _Ventacobranza; set { if (RaiseAcceptPendingChange(value, _Ventacobranza)) { _Ventacobranza = value; OnPropertyChanged(); } } }

        private string? _Verpago;
        [XmlAttribute]
        public string? Verpago { get => _Verpago; set { if (RaiseAcceptPendingChange(value, _Verpago)) { _Verpago = value; OnPropertyChanged(); } } }

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

