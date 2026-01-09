
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
    public class FormKardex2WFBindingModel : Validatable
    {

        public FormKardex2WFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Tbproductoinicial;
        [XmlAttribute]
        public string? Tbproductoinicial { get => _Tbproductoinicial; set { if (RaiseAcceptPendingChange(value, _Tbproductoinicial)) { _Tbproductoinicial = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechainicial;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechainicial { get => _Dtpfechainicial; set { if (RaiseAcceptPendingChange(value, _Dtpfechainicial)) { _Dtpfechainicial = value; OnPropertyChanged(); } } }

        private string? _Tbproductofinal;
        [XmlAttribute]
        public string? Tbproductofinal { get => _Tbproductofinal; set { if (RaiseAcceptPendingChange(value, _Tbproductofinal)) { _Tbproductofinal = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfechafinal;
        [XmlAttribute]
        public DateTimeOffset? Dtpfechafinal { get => _Dtpfechafinal; set { if (RaiseAcceptPendingChange(value, _Dtpfechafinal)) { _Dtpfechafinal = value; OnPropertyChanged(); } } }

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
    public class FormKardex2WF_Get_kardex_reportBindingModel : Validatable
    {

        public FormKardex2WF_Get_kardex_reportBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Sucursalclave;
        [XmlAttribute]
        public string? Sucursalclave { get => _Sucursalclave; set { if (RaiseAcceptPendingChange(value, _Sucursalclave)) { _Sucursalclave = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private string? _Tipodoctoclave;
        [XmlAttribute]
        public string? Tipodoctoclave { get => _Tipodoctoclave; set { if (RaiseAcceptPendingChange(value, _Tipodoctoclave)) { _Tipodoctoclave = value; OnPropertyChanged(); } } }

        private int? _Doctofolio;
        [XmlAttribute]
        public int? Doctofolio { get => _Doctofolio; set { if (RaiseAcceptPendingChange(value, _Doctofolio)) { _Doctofolio = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadini;
        [XmlAttribute]
        public decimal? Cantidadini { get => _Cantidadini; set { if (RaiseAcceptPendingChange(value, _Cantidadini)) { _Cantidadini = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadmov;
        [XmlAttribute]
        public decimal? Cantidadmov { get => _Cantidadmov; set { if (RaiseAcceptPendingChange(value, _Cantidadmov)) { _Cantidadmov = value; OnPropertyChanged(); } } }

        private int? _Numero;
        [XmlAttribute]
        public int? Numero { get => _Numero; set { if (RaiseAcceptPendingChange(value, _Numero)) { _Numero = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadfin;
        [XmlAttribute]
        public decimal? Cantidadfin { get => _Cantidadfin; set { if (RaiseAcceptPendingChange(value, _Cantidadfin)) { _Cantidadfin = value; OnPropertyChanged(); } } }

        private long? _Kardexid;
        [XmlAttribute]
        public long? Kardexid { get => _Kardexid; set { if (RaiseAcceptPendingChange(value, _Kardexid)) { _Kardexid = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private long? _Movtoid;
        [XmlAttribute]
        public long? Movtoid { get => _Movtoid; set { if (RaiseAcceptPendingChange(value, _Movtoid)) { _Movtoid = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private long? _Sucursalid;
        [XmlAttribute]
        public long? Sucursalid { get => _Sucursalid; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value; OnPropertyChanged(); } } }

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

