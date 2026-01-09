
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
    public class WFCobranzaMovilWFBindingModel : Validatable
    {

        public WFCobranzaMovilWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Lstsearchcomplete;
        [XmlAttribute]
        public long? Lstsearchcomplete { get => _Lstsearchcomplete; set { if (RaiseAcceptPendingChange(value, _Lstsearchcomplete)) { _Lstsearchcomplete = value; OnPropertyChanged(); } } }

        private string? _Tbbusqueda;
        [XmlAttribute]
        public string? Tbbusqueda { get => _Tbbusqueda; set { if (RaiseAcceptPendingChange(value, _Tbbusqueda)) { _Tbbusqueda = value; OnPropertyChanged(); } } }

        private string? _LstsearchcompleteClave;
        [XmlAttribute]
        public string? LstsearchcompleteClave { get => _LstsearchcompleteClave; set { if (RaiseAcceptPendingChange(value, _LstsearchcompleteClave)) { _LstsearchcompleteClave = value; OnPropertyChanged(); } } }

        private string? _LstsearchcompleteNombre;
        [XmlAttribute]
        public string? LstsearchcompleteNombre { get => _LstsearchcompleteNombre; set { if (RaiseAcceptPendingChange(value, _LstsearchcompleteNombre)) { _LstsearchcompleteNombre = value; OnPropertyChanged(); } } }

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
    public class WFCobranzaMovilWF_CobranzamovilBindingModel : Validatable
    {

        public WFCobranzaMovilWF_CobranzamovilBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgpagar;
        [XmlAttribute]
        public string? Dgpagar { get => _Dgpagar; set { if (RaiseAcceptPendingChange(value, _Dgpagar)) { _Dgpagar = value; OnPropertyChanged(); } } }

        private string? _Verpagos;
        [XmlAttribute]
        public string? Verpagos { get => _Verpagos; set { if (RaiseAcceptPendingChange(value, _Verpagos)) { _Verpagos = value; OnPropertyChanged(); } } }

        private string? _Venta;
        [XmlAttribute]
        public string? Venta { get => _Venta; set { if (RaiseAcceptPendingChange(value, _Venta)) { _Venta = value; OnPropertyChanged(); } } }

        private string? _Estatus;
        [XmlAttribute]
        public string? Estatus { get => _Estatus; set { if (RaiseAcceptPendingChange(value, _Estatus)) { _Estatus = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Saldomovil;
        [XmlAttribute]
        public decimal? Saldomovil { get => _Saldomovil; set { if (RaiseAcceptPendingChange(value, _Saldomovil)) { _Saldomovil = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _F_pago;
        [XmlAttribute]
        public DateTimeOffset? F_pago { get => _F_pago; set { if (RaiseAcceptPendingChange(value, _F_pago)) { _F_pago = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _F_factura;
        [XmlAttribute]
        public DateTimeOffset? F_factura { get => _F_factura; set { if (RaiseAcceptPendingChange(value, _F_factura)) { _F_factura = value; OnPropertyChanged(); } } }

        private int? _Dias;
        [XmlAttribute]
        public int? Dias { get => _Dias; set { if (RaiseAcceptPendingChange(value, _Dias)) { _Dias = value; OnPropertyChanged(); } } }

        private decimal? _Abonosmovil;
        [XmlAttribute]
        public decimal? Abonosmovil { get => _Abonosmovil; set { if (RaiseAcceptPendingChange(value, _Abonosmovil)) { _Abonosmovil = value; OnPropertyChanged(); } } }

        private string? _Cobranza;
        [XmlAttribute]
        public string? Cobranza { get => _Cobranza; set { if (RaiseAcceptPendingChange(value, _Cobranza)) { _Cobranza = value; OnPropertyChanged(); } } }

        private string? _Cliente;
        [XmlAttribute]
        public string? Cliente { get => _Cliente; set { if (RaiseAcceptPendingChange(value, _Cliente)) { _Cliente = value; OnPropertyChanged(); } } }

        private string? _Vendedor;
        [XmlAttribute]
        public string? Vendedor { get => _Vendedor; set { if (RaiseAcceptPendingChange(value, _Vendedor)) { _Vendedor = value; OnPropertyChanged(); } } }

        private string? _Obs;
        [XmlAttribute]
        public string? Obs { get => _Obs; set { if (RaiseAcceptPendingChange(value, _Obs)) { _Obs = value; OnPropertyChanged(); } } }

        private decimal? _A_cuenta;
        [XmlAttribute]
        public decimal? A_cuenta { get => _A_cuenta; set { if (RaiseAcceptPendingChange(value, _A_cuenta)) { _A_cuenta = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private string? _Empresa;
        [XmlAttribute]
        public string? Empresa { get => _Empresa; set { if (RaiseAcceptPendingChange(value, _Empresa)) { _Empresa = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private string? _Factura;
        [XmlAttribute]
        public string? Factura { get => _Factura; set { if (RaiseAcceptPendingChange(value, _Factura)) { _Factura = value; OnPropertyChanged(); } } }

        private decimal? _Int_cob;
        [XmlAttribute]
        public decimal? Int_cob { get => _Int_cob; set { if (RaiseAcceptPendingChange(value, _Int_cob)) { _Int_cob = value; OnPropertyChanged(); } } }

        private decimal? _Intereses;
        [XmlAttribute]
        public decimal? Intereses { get => _Intereses; set { if (RaiseAcceptPendingChange(value, _Intereses)) { _Intereses = value; OnPropertyChanged(); } } }

        private decimal? _Impor_neto;
        [XmlAttribute]
        public decimal? Impor_neto { get => _Impor_neto; set { if (RaiseAcceptPendingChange(value, _Impor_neto)) { _Impor_neto = value; OnPropertyChanged(); } } }

        private decimal? _Pago;
        [XmlAttribute]
        public decimal? Pago { get => _Pago; set { if (RaiseAcceptPendingChange(value, _Pago)) { _Pago = value; OnPropertyChanged(); } } }

        private decimal? _Efectivo;
        [XmlAttribute]
        public decimal? Efectivo { get => _Efectivo; set { if (RaiseAcceptPendingChange(value, _Efectivo)) { _Efectivo = value; OnPropertyChanged(); } } }

        private decimal? _Diferencia;
        [XmlAttribute]
        public decimal? Diferencia { get => _Diferencia; set { if (RaiseAcceptPendingChange(value, _Diferencia)) { _Diferencia = value; OnPropertyChanged(); } } }

        private decimal? _Imp_cheque;
        [XmlAttribute]
        public decimal? Imp_cheque { get => _Imp_cheque; set { if (RaiseAcceptPendingChange(value, _Imp_cheque)) { _Imp_cheque = value; OnPropertyChanged(); } } }

        private string? _Banco;
        [XmlAttribute]
        public string? Banco { get => _Banco; set { if (RaiseAcceptPendingChange(value, _Banco)) { _Banco = value; OnPropertyChanged(); } } }

        private int? _Num_cheq;
        [XmlAttribute]
        public int? Num_cheq { get => _Num_cheq; set { if (RaiseAcceptPendingChange(value, _Num_cheq)) { _Num_cheq = value; OnPropertyChanged(); } } }

        private decimal? _Interes;
        [XmlAttribute]
        public decimal? Interes { get => _Interes; set { if (RaiseAcceptPendingChange(value, _Interes)) { _Interes = value; OnPropertyChanged(); } } }

        private decimal? _Capital;
        [XmlAttribute]
        public decimal? Capital { get => _Capital; set { if (RaiseAcceptPendingChange(value, _Capital)) { _Capital = value; OnPropertyChanged(); } } }

        private string? _Olla;
        [XmlAttribute]
        public string? Olla { get => _Olla; set { if (RaiseAcceptPendingChange(value, _Olla)) { _Olla = value; OnPropertyChanged(); } } }

        private string? _Bloqueado;
        [XmlAttribute]
        public string? Bloqueado { get => _Bloqueado; set { if (RaiseAcceptPendingChange(value, _Bloqueado)) { _Bloqueado = value; OnPropertyChanged(); } } }

        private string? _Llevar;
        [XmlAttribute]
        public string? Llevar { get => _Llevar; set { if (RaiseAcceptPendingChange(value, _Llevar)) { _Llevar = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Personaid;
        [XmlAttribute]
        public long? Personaid { get => _Personaid; set { if (RaiseAcceptPendingChange(value, _Personaid)) { _Personaid = value; OnPropertyChanged(); } } }

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

