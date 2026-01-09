
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
    public class WFAutorizacioRebajaMovilWFBindingModel : Validatable
    {

        public WFAutorizacioRebajaMovilWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

        private long? _Vendedor;
        [XmlAttribute]
        public long? Vendedor { get => _Vendedor; set { if (RaiseAcceptPendingChange(value, _Vendedor)) { _Vendedor = value; OnPropertyChanged(); } } }

        private string? _VendedorClave;
        [XmlAttribute]
        public string? VendedorClave { get => _VendedorClave; set { if (RaiseAcceptPendingChange(value, _VendedorClave)) { _VendedorClave = value; OnPropertyChanged(); } } }

        private string? _VendedorNombre;
        [XmlAttribute]
        public string? VendedorNombre { get => _VendedorNombre; set { if (RaiseAcceptPendingChange(value, _VendedorNombre)) { _VendedorNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodosvendedores;
        [XmlAttribute]
        public BoolCN? Cbtodosvendedores { get => _Cbtodosvendedores; set { if (RaiseAcceptPendingChange(value, _Cbtodosvendedores)) { _Cbtodosvendedores = value; OnPropertyChanged(); } } }

        private string? _Tbnota1;
        [XmlAttribute]
        public string? Tbnota1 { get => _Tbnota1; set { if (RaiseAcceptPendingChange(value, _Tbnota1)) { _Tbnota1 = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbplazos;
        [XmlAttribute]
        public BoolCN? Cbplazos { get => _Cbplazos; set { if (RaiseAcceptPendingChange(value, _Cbplazos)) { _Cbplazos = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbcontrato;
        [XmlAttribute]
        public BoolCN? Cbcontrato { get => _Cbcontrato; set { if (RaiseAcceptPendingChange(value, _Cbcontrato)) { _Cbcontrato = value; OnPropertyChanged(); } } }

        private long? _Producto;
        [XmlAttribute]
        public long? Producto { get => _Producto; set { if (RaiseAcceptPendingChange(value, _Producto)) { _Producto = value; OnPropertyChanged(); } } }

        private string? _ProductoClave;
        [XmlAttribute]
        public string? ProductoClave { get => _ProductoClave; set { if (RaiseAcceptPendingChange(value, _ProductoClave)) { _ProductoClave = value; OnPropertyChanged(); } } }

        private string? _ProductoNombre;
        [XmlAttribute]
        public string? ProductoNombre { get => _ProductoNombre; set { if (RaiseAcceptPendingChange(value, _ProductoNombre)) { _ProductoNombre = value; OnPropertyChanged(); } } }

        private long? _Cliente;
        [XmlAttribute]
        public long? Cliente { get => _Cliente; set { if (RaiseAcceptPendingChange(value, _Cliente)) { _Cliente = value; OnPropertyChanged(); } } }

        private string? _ClienteClave;
        [XmlAttribute]
        public string? ClienteClave { get => _ClienteClave; set { if (RaiseAcceptPendingChange(value, _ClienteClave)) { _ClienteClave = value; OnPropertyChanged(); } } }

        private string? _ClienteNombre;
        [XmlAttribute]
        public string? ClienteNombre { get => _ClienteNombre; set { if (RaiseAcceptPendingChange(value, _ClienteNombre)) { _ClienteNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodosproductos;
        [XmlAttribute]
        public BoolCN? Cbtodosproductos { get => _Cbtodosproductos; set { if (RaiseAcceptPendingChange(value, _Cbtodosproductos)) { _Cbtodosproductos = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodosclientes;
        [XmlAttribute]
        public BoolCN? Cbtodosclientes { get => _Cbtodosclientes; set { if (RaiseAcceptPendingChange(value, _Cbtodosclientes)) { _Cbtodosclientes = value; OnPropertyChanged(); } } }

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
    public class WFAutorizacioRebajaMovilWF_Rebajas_promodocto_movilBindingModel : Validatable
    {

        public WFAutorizacioRebajaMovilWF_Rebajas_promodocto_movilBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private int? _Doctofolio;
        [XmlAttribute]
        public int? Doctofolio { get => _Doctofolio; set { if (RaiseAcceptPendingChange(value, _Doctofolio)) { _Doctofolio = value; OnPropertyChanged(); } } }

        private string? _Personaclave;
        [XmlAttribute]
        public string? Personaclave { get => _Personaclave; set { if (RaiseAcceptPendingChange(value, _Personaclave)) { _Personaclave = value; OnPropertyChanged(); } } }

        private string? _Personanombre;
        [XmlAttribute]
        public string? Personanombre { get => _Personanombre; set { if (RaiseAcceptPendingChange(value, _Personanombre)) { _Personanombre = value; OnPropertyChanged(); } } }

        private string? _Personanombres;
        [XmlAttribute]
        public string? Personanombres { get => _Personanombres; set { if (RaiseAcceptPendingChange(value, _Personanombres)) { _Personanombres = value; OnPropertyChanged(); } } }

        private string? _Cajeroclave;
        [XmlAttribute]
        public string? Cajeroclave { get => _Cajeroclave; set { if (RaiseAcceptPendingChange(value, _Cajeroclave)) { _Cajeroclave = value; OnPropertyChanged(); } } }

        private string? _Cajeronombre;
        [XmlAttribute]
        public string? Cajeronombre { get => _Cajeronombre; set { if (RaiseAcceptPendingChange(value, _Cajeronombre)) { _Cajeronombre = value; OnPropertyChanged(); } } }

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
    public class WFAutorizacioRebajaMovilWF_Rebajas_promovidasBindingModel : Validatable
    {

        public WFAutorizacioRebajaMovilWF_Rebajas_promovidasBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgaprobar;
        [XmlAttribute]
        public string? Dgaprobar { get => _Dgaprobar; set { if (RaiseAcceptPendingChange(value, _Dgaprobar)) { _Dgaprobar = value; OnPropertyChanged(); } } }

        private string? _Dgrechazada;
        [XmlAttribute]
        public string? Dgrechazada { get => _Dgrechazada; set { if (RaiseAcceptPendingChange(value, _Dgrechazada)) { _Dgrechazada = value; OnPropertyChanged(); } } }

        private int? _Numero;
        [XmlAttribute]
        public int? Numero { get => _Numero; set { if (RaiseAcceptPendingChange(value, _Numero)) { _Numero = value; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion1;
        [XmlAttribute]
        public string? Productodescripcion1 { get => _Productodescripcion1; set { if (RaiseAcceptPendingChange(value, _Productodescripcion1)) { _Productodescripcion1 = value; OnPropertyChanged(); } } }

        private decimal? _Cajas;
        [XmlAttribute]
        public decimal? Cajas { get => _Cajas; set { if (RaiseAcceptPendingChange(value, _Cajas)) { _Cajas = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private decimal? _Piezassueltas;
        [XmlAttribute]
        public decimal? Piezassueltas { get => _Piezassueltas; set { if (RaiseAcceptPendingChange(value, _Piezassueltas)) { _Piezassueltas = value; OnPropertyChanged(); } } }

        private decimal? _Precio;
        [XmlAttribute]
        public decimal? Precio { get => _Precio; set { if (RaiseAcceptPendingChange(value, _Precio)) { _Precio = value; OnPropertyChanged(); } } }

        private decimal? _Cdescr;
        [XmlAttribute]
        public decimal? Cdescr { get => _Cdescr; set { if (RaiseAcceptPendingChange(value, _Cdescr)) { _Cdescr = value; OnPropertyChanged(); } } }

        private decimal? _Nprec;
        [XmlAttribute]
        public decimal? Nprec { get => _Nprec; set { if (RaiseAcceptPendingChange(value, _Nprec)) { _Nprec = value; OnPropertyChanged(); } } }

        private string? _Alerta3;
        [XmlAttribute]
        public string? Alerta3 { get => _Alerta3; set { if (RaiseAcceptPendingChange(value, _Alerta3)) { _Alerta3 = value; OnPropertyChanged(); } } }

        private decimal? _Nutil;
        [XmlAttribute]
        public decimal? Nutil { get => _Nutil; set { if (RaiseAcceptPendingChange(value, _Nutil)) { _Nutil = value; OnPropertyChanged(); } } }

        private decimal? _Margen;
        [XmlAttribute]
        public decimal? Margen { get => _Margen; set { if (RaiseAcceptPendingChange(value, _Margen)) { _Margen = value; OnPropertyChanged(); } } }

        private decimal? _Descpes;
        [XmlAttribute]
        public decimal? Descpes { get => _Descpes; set { if (RaiseAcceptPendingChange(value, _Descpes)) { _Descpes = value; OnPropertyChanged(); } } }

        private decimal? _Comisionporc;
        [XmlAttribute]
        public decimal? Comisionporc { get => _Comisionporc; set { if (RaiseAcceptPendingChange(value, _Comisionporc)) { _Comisionporc = value; OnPropertyChanged(); } } }

        private decimal? _Descuentoporcentaje;
        [XmlAttribute]
        public decimal? Descuentoporcentaje { get => _Descuentoporcentaje; set { if (RaiseAcceptPendingChange(value, _Descuentoporcentaje)) { _Descuentoporcentaje = value; OnPropertyChanged(); } } }

        private decimal? _Precio4;
        [XmlAttribute]
        public decimal? Precio4 { get => _Precio4; set { if (RaiseAcceptPendingChange(value, _Precio4)) { _Precio4 = value; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute]
        public decimal? Descuento { get => _Descuento; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value; OnPropertyChanged(); } } }

        private decimal? _Precio_sinimp_sinrebaja;
        [XmlAttribute]
        public decimal? Precio_sinimp_sinrebaja { get => _Precio_sinimp_sinrebaja; set { if (RaiseAcceptPendingChange(value, _Precio_sinimp_sinrebaja)) { _Precio_sinimp_sinrebaja = value; OnPropertyChanged(); } } }

        private decimal? _Precio_conimp_sinrebaja;
        [XmlAttribute]
        public decimal? Precio_conimp_sinrebaja { get => _Precio_conimp_sinrebaja; set { if (RaiseAcceptPendingChange(value, _Precio_conimp_sinrebaja)) { _Precio_conimp_sinrebaja = value; OnPropertyChanged(); } } }

        private decimal? _Total_sinrebaja;
        [XmlAttribute]
        public decimal? Total_sinrebaja { get => _Total_sinrebaja; set { if (RaiseAcceptPendingChange(value, _Total_sinrebaja)) { _Total_sinrebaja = value; OnPropertyChanged(); } } }

        private decimal? _Precio_sinimp_conrebaja;
        [XmlAttribute]
        public decimal? Precio_sinimp_conrebaja { get => _Precio_sinimp_conrebaja; set { if (RaiseAcceptPendingChange(value, _Precio_sinimp_conrebaja)) { _Precio_sinimp_conrebaja = value; OnPropertyChanged(); } } }

        private decimal? _Precio_conimp_conrebaja;
        [XmlAttribute]
        public decimal? Precio_conimp_conrebaja { get => _Precio_conimp_conrebaja; set { if (RaiseAcceptPendingChange(value, _Precio_conimp_conrebaja)) { _Precio_conimp_conrebaja = value; OnPropertyChanged(); } } }

        private decimal? _Totalconrebaja;
        [XmlAttribute]
        public decimal? Totalconrebaja { get => _Totalconrebaja; set { if (RaiseAcceptPendingChange(value, _Totalconrebaja)) { _Totalconrebaja = value; OnPropertyChanged(); } } }

        private decimal? _Diferencia;
        [XmlAttribute]
        public decimal? Diferencia { get => _Diferencia; set { if (RaiseAcceptPendingChange(value, _Diferencia)) { _Diferencia = value; OnPropertyChanged(); } } }

        private decimal? _Cantautrebaja;
        [XmlAttribute]
        public decimal? Cantautrebaja { get => _Cantautrebaja; set { if (RaiseAcceptPendingChange(value, _Cantautrebaja)) { _Cantautrebaja = value; OnPropertyChanged(); } } }

        private long? _Estadorebaja;
        [XmlAttribute]
        public long? Estadorebaja { get => _Estadorebaja; set { if (RaiseAcceptPendingChange(value, _Estadorebaja)) { _Estadorebaja = value; OnPropertyChanged(); } } }

        private decimal? _Costocaja;
        [XmlAttribute]
        public decimal? Costocaja { get => _Costocaja; set { if (RaiseAcceptPendingChange(value, _Costocaja)) { _Costocaja = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private long? _Movtoid;
        [XmlAttribute]
        public long? Movtoid { get => _Movtoid; set { if (RaiseAcceptPendingChange(value, _Movtoid)) { _Movtoid = value; OnPropertyChanged(); } } }

        private decimal? _Preciocaja;
        [XmlAttribute]
        public decimal? Preciocaja { get => _Preciocaja; set { if (RaiseAcceptPendingChange(value, _Preciocaja)) { _Preciocaja = value; OnPropertyChanged(); } } }

        private decimal? _Utilidad;
        [XmlAttribute]
        public decimal? Utilidad { get => _Utilidad; set { if (RaiseAcceptPendingChange(value, _Utilidad)) { _Utilidad = value; OnPropertyChanged(); } } }

        private decimal? _Utilidadporc;
        [XmlAttribute]
        public decimal? Utilidadporc { get => _Utilidadporc; set { if (RaiseAcceptPendingChange(value, _Utilidadporc)) { _Utilidadporc = value; OnPropertyChanged(); } } }

        private string? _Proveedorclave;
        [XmlAttribute]
        public string? Proveedorclave { get => _Proveedorclave; set { if (RaiseAcceptPendingChange(value, _Proveedorclave)) { _Proveedorclave = value; OnPropertyChanged(); } } }

        private decimal? _Precio1;
        [XmlAttribute]
        public decimal? Precio1 { get => _Precio1; set { if (RaiseAcceptPendingChange(value, _Precio1)) { _Precio1 = value; OnPropertyChanged(); } } }

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

