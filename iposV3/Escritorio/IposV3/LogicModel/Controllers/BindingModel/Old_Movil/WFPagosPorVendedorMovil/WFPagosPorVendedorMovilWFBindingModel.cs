
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
    public class WFPagosPorVendedorMovilWFBindingModel : Validatable
    {

        public WFPagosPorVendedorMovilWFBindingModel()
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
    public class WFPagosPorVendedorMovilWF_Pagos_movil_por_vendedorBindingModel : Validatable
    {

        public WFPagosPorVendedorMovilWF_Pagos_movil_por_vendedorBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Vendedor;
        [XmlAttribute]
        public string? Vendedor { get => _Vendedor; set { if (RaiseAcceptPendingChange(value, _Vendedor)) { _Vendedor = value; OnPropertyChanged(); } } }

        private decimal? _Monto;
        [XmlAttribute]
        public decimal? Monto { get => _Monto; set { if (RaiseAcceptPendingChange(value, _Monto)) { _Monto = value; OnPropertyChanged(); } } }

        private string? _Btnver;
        [XmlAttribute]
        public string? Btnver { get => _Btnver; set { if (RaiseAcceptPendingChange(value, _Btnver)) { _Btnver = value; OnPropertyChanged(); } } }

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

