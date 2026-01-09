
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
    public class CorteCerrarWFBindingModel : Validatable
    {

        public CorteCerrarWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Ntbsaldoreal;
        [XmlAttribute]
        public decimal? Ntbsaldoreal { get => _Ntbsaldoreal; set { if (RaiseAcceptPendingChange(value, _Ntbsaldoreal)) { _Ntbsaldoreal = value; OnPropertyChanged(); } } }

        private decimal? _Ntbsaldorealcredito;
        [XmlAttribute]
        public decimal? Ntbsaldorealcredito { get => _Ntbsaldorealcredito; set { if (RaiseAcceptPendingChange(value, _Ntbsaldorealcredito)) { _Ntbsaldorealcredito = value; OnPropertyChanged(); } } }

        private decimal? _Ntbfondofinal;
        [XmlAttribute]
        public decimal? Ntbfondofinal { get => _Ntbfondofinal; set { if (RaiseAcceptPendingChange(value, _Ntbfondofinal)) { _Ntbfondofinal = value; OnPropertyChanged(); } } }

        private string? _Lbingresocheque;
        [XmlAttribute]
        public string? Lbingresocheque { get => _Lbingresocheque; set { if (RaiseAcceptPendingChange(value, _Lbingresocheque)) { _Lbingresocheque = value; OnPropertyChanged(); } } }

        private string? _Lbegresocheque;
        [XmlAttribute]
        public string? Lbegresocheque { get => _Lbegresocheque; set { if (RaiseAcceptPendingChange(value, _Lbegresocheque)) { _Lbegresocheque = value; OnPropertyChanged(); } } }

        private string? _Lbtotalcheque;
        [XmlAttribute]
        public string? Lbtotalcheque { get => _Lbtotalcheque; set { if (RaiseAcceptPendingChange(value, _Lbtotalcheque)) { _Lbtotalcheque = value; OnPropertyChanged(); } } }

        private string? _Lbcambiocheque;
        [XmlAttribute]
        public string? Lbcambiocheque { get => _Lbcambiocheque; set { if (RaiseAcceptPendingChange(value, _Lbcambiocheque)) { _Lbcambiocheque = value; OnPropertyChanged(); } } }

        private string? _Lbcambiochequetotal;
        [XmlAttribute]
        public string? Lbcambiochequetotal { get => _Lbcambiochequetotal; set { if (RaiseAcceptPendingChange(value, _Lbcambiochequetotal)) { _Lbcambiochequetotal = value; OnPropertyChanged(); } } }

        private string? _Lbingresovale;
        [XmlAttribute]
        public string? Lbingresovale { get => _Lbingresovale; set { if (RaiseAcceptPendingChange(value, _Lbingresovale)) { _Lbingresovale = value; OnPropertyChanged(); } } }

        private string? _Lbegresovale;
        [XmlAttribute]
        public string? Lbegresovale { get => _Lbegresovale; set { if (RaiseAcceptPendingChange(value, _Lbegresovale)) { _Lbegresovale = value; OnPropertyChanged(); } } }

        private string? _Lbtotalvale;
        [XmlAttribute]
        public string? Lbtotalvale { get => _Lbtotalvale; set { if (RaiseAcceptPendingChange(value, _Lbtotalvale)) { _Lbtotalvale = value; OnPropertyChanged(); } } }

        private string? _Lbingresomonedero;
        [XmlAttribute]
        public string? Lbingresomonedero { get => _Lbingresomonedero; set { if (RaiseAcceptPendingChange(value, _Lbingresomonedero)) { _Lbingresomonedero = value; OnPropertyChanged(); } } }

        private string? _Lbegresomonedero;
        [XmlAttribute]
        public string? Lbegresomonedero { get => _Lbegresomonedero; set { if (RaiseAcceptPendingChange(value, _Lbegresomonedero)) { _Lbegresomonedero = value; OnPropertyChanged(); } } }

        private string? _Lbtotalmonedero;
        [XmlAttribute]
        public string? Lbtotalmonedero { get => _Lbtotalmonedero; set { if (RaiseAcceptPendingChange(value, _Lbtotalmonedero)) { _Lbtotalmonedero = value; OnPropertyChanged(); } } }

        private string? _Lbsaldoinicial;
        [XmlAttribute]
        public string? Lbsaldoinicial { get => _Lbsaldoinicial; set { if (RaiseAcceptPendingChange(value, _Lbsaldoinicial)) { _Lbsaldoinicial = value; OnPropertyChanged(); } } }

        private string? _Lbsaldoinicialtotal;
        [XmlAttribute]
        public string? Lbsaldoinicialtotal { get => _Lbsaldoinicialtotal; set { if (RaiseAcceptPendingChange(value, _Lbsaldoinicialtotal)) { _Lbsaldoinicialtotal = value; OnPropertyChanged(); } } }

        private string? _Lbtotaltransferencia;
        [XmlAttribute]
        public string? Lbtotaltransferencia { get => _Lbtotaltransferencia; set { if (RaiseAcceptPendingChange(value, _Lbtotaltransferencia)) { _Lbtotaltransferencia = value; OnPropertyChanged(); } } }

        private string? _Lbingresotransferencia;
        [XmlAttribute]
        public string? Lbingresotransferencia { get => _Lbingresotransferencia; set { if (RaiseAcceptPendingChange(value, _Lbingresotransferencia)) { _Lbingresotransferencia = value; OnPropertyChanged(); } } }

        private string? _Lbegresotransferencia;
        [XmlAttribute]
        public string? Lbegresotransferencia { get => _Lbegresotransferencia; set { if (RaiseAcceptPendingChange(value, _Lbegresotransferencia)) { _Lbegresotransferencia = value; OnPropertyChanged(); } } }

        private string? _Lbaportacion;
        [XmlAttribute]
        public string? Lbaportacion { get => _Lbaportacion; set { if (RaiseAcceptPendingChange(value, _Lbaportacion)) { _Lbaportacion = value; OnPropertyChanged(); } } }

        private string? _Lbaportaciontotal;
        [XmlAttribute]
        public string? Lbaportaciontotal { get => _Lbaportaciontotal; set { if (RaiseAcceptPendingChange(value, _Lbaportaciontotal)) { _Lbaportaciontotal = value; OnPropertyChanged(); } } }

        private string? _Lbretiro;
        [XmlAttribute]
        public string? Lbretiro { get => _Lbretiro; set { if (RaiseAcceptPendingChange(value, _Lbretiro)) { _Lbretiro = value; OnPropertyChanged(); } } }

        private string? _Lbretirototal;
        [XmlAttribute]
        public string? Lbretirototal { get => _Lbretirototal; set { if (RaiseAcceptPendingChange(value, _Lbretirototal)) { _Lbretirototal = value; OnPropertyChanged(); } } }

        private string? _Lbpagoproveedorestotales;
        [XmlAttribute]
        public string? Lbpagoproveedorestotales { get => _Lbpagoproveedorestotales; set { if (RaiseAcceptPendingChange(value, _Lbpagoproveedorestotales)) { _Lbpagoproveedorestotales = value; OnPropertyChanged(); } } }

        private string? _Lbpagoproveedores;
        [XmlAttribute]
        public string? Lbpagoproveedores { get => _Lbpagoproveedores; set { if (RaiseAcceptPendingChange(value, _Lbpagoproveedores)) { _Lbpagoproveedores = value; OnPropertyChanged(); } } }

        private string? _Lbfondeodecajatotal;
        [XmlAttribute]
        public string? Lbfondeodecajatotal { get => _Lbfondeodecajatotal; set { if (RaiseAcceptPendingChange(value, _Lbfondeodecajatotal)) { _Lbfondeodecajatotal = value; OnPropertyChanged(); } } }

        private string? _Lbfondeodecaja;
        [XmlAttribute]
        public string? Lbfondeodecaja { get => _Lbfondeodecaja; set { if (RaiseAcceptPendingChange(value, _Lbfondeodecaja)) { _Lbfondeodecaja = value; OnPropertyChanged(); } } }

        private string? _Lbingreso;
        [XmlAttribute]
        public string? Lbingreso { get => _Lbingreso; set { if (RaiseAcceptPendingChange(value, _Lbingreso)) { _Lbingreso = value; OnPropertyChanged(); } } }

        private string? _Lbegreso;
        [XmlAttribute]
        public string? Lbegreso { get => _Lbegreso; set { if (RaiseAcceptPendingChange(value, _Lbegreso)) { _Lbegreso = value; OnPropertyChanged(); } } }

        private string? _Lbsaldofinal;
        [XmlAttribute]
        public string? Lbsaldofinal { get => _Lbsaldofinal; set { if (RaiseAcceptPendingChange(value, _Lbsaldofinal)) { _Lbsaldofinal = value; OnPropertyChanged(); } } }

        private string? _Lbingresoefectivo;
        [XmlAttribute]
        public string? Lbingresoefectivo { get => _Lbingresoefectivo; set { if (RaiseAcceptPendingChange(value, _Lbingresoefectivo)) { _Lbingresoefectivo = value; OnPropertyChanged(); } } }

        private string? _Lbegresoefectivo;
        [XmlAttribute]
        public string? Lbegresoefectivo { get => _Lbegresoefectivo; set { if (RaiseAcceptPendingChange(value, _Lbegresoefectivo)) { _Lbegresoefectivo = value; OnPropertyChanged(); } } }

        private string? _Lbtotalefectivo;
        [XmlAttribute]
        public string? Lbtotalefectivo { get => _Lbtotalefectivo; set { if (RaiseAcceptPendingChange(value, _Lbtotalefectivo)) { _Lbtotalefectivo = value; OnPropertyChanged(); } } }

        private string? _Lbingresotarjeta;
        [XmlAttribute]
        public string? Lbingresotarjeta { get => _Lbingresotarjeta; set { if (RaiseAcceptPendingChange(value, _Lbingresotarjeta)) { _Lbingresotarjeta = value; OnPropertyChanged(); } } }

        private string? _Lbegresotarjeta;
        [XmlAttribute]
        public string? Lbegresotarjeta { get => _Lbegresotarjeta; set { if (RaiseAcceptPendingChange(value, _Lbegresotarjeta)) { _Lbegresotarjeta = value; OnPropertyChanged(); } } }

        private string? _Lbtotaltarjeta;
        [XmlAttribute]
        public string? Lbtotaltarjeta { get => _Lbtotaltarjeta; set { if (RaiseAcceptPendingChange(value, _Lbtotaltarjeta)) { _Lbtotaltarjeta = value; OnPropertyChanged(); } } }

        private string? _Lbtotalcredito;
        [XmlAttribute]
        public string? Lbtotalcredito { get => _Lbtotalcredito; set { if (RaiseAcceptPendingChange(value, _Lbtotalcredito)) { _Lbtotalcredito = value; OnPropertyChanged(); } } }

        private string? _Lbingresocredito;
        [XmlAttribute]
        public string? Lbingresocredito { get => _Lbingresocredito; set { if (RaiseAcceptPendingChange(value, _Lbingresocredito)) { _Lbingresocredito = value; OnPropertyChanged(); } } }

        private string? _Lbegresocredito;
        [XmlAttribute]
        public string? Lbegresocredito { get => _Lbegresocredito; set { if (RaiseAcceptPendingChange(value, _Lbegresocredito)) { _Lbegresocredito = value; OnPropertyChanged(); } } }

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

