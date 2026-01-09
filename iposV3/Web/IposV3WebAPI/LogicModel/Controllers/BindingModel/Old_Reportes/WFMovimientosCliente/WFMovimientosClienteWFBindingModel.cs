
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
    public class WFMovimientosClienteWFBindingModel : Validatable
    {

        public WFMovimientosClienteWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Personaid;
        [XmlAttribute]
        public long? Personaid { get => _Personaid; set { if (RaiseAcceptPendingChange(value, _Personaid)) { _Personaid = value; OnPropertyChanged(); } } }

        private string? _PersonaidClave;
        [XmlAttribute]
        public string? PersonaidClave { get => _PersonaidClave; set { if (RaiseAcceptPendingChange(value, _PersonaidClave)) { _PersonaidClave = value; OnPropertyChanged(); } } }

        private string? _PersonaidNombre;
        [XmlAttribute]
        public string? PersonaidNombre { get => _PersonaidNombre; set { if (RaiseAcceptPendingChange(value, _PersonaidNombre)) { _PersonaidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbconsaldo;
        [XmlAttribute]
        public BoolCN? Cbconsaldo { get => _Cbconsaldo; set { if (RaiseAcceptPendingChange(value, _Cbconsaldo)) { _Cbconsaldo = value; OnPropertyChanged(); } } }

        private string? _Tbnota;
        [XmlAttribute]
        public string? Tbnota { get => _Tbnota; set { if (RaiseAcceptPendingChange(value, _Tbnota)) { _Tbnota = value; OnPropertyChanged(); } } }

        private long? _Cbtipo;
        [XmlAttribute]
        public long? Cbtipo { get => _Cbtipo; set { if (RaiseAcceptPendingChange(value, _Cbtipo)) { _Cbtipo = value; OnPropertyChanged(); } } }

        private long? _Cborigenfiscal;
        [XmlAttribute]
        public long? Cborigenfiscal { get => _Cborigenfiscal; set { if (RaiseAcceptPendingChange(value, _Cborigenfiscal)) { _Cborigenfiscal = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

        private string? _CbtipoClave;
        [XmlAttribute]
        public string? CbtipoClave { get => _CbtipoClave; set { if (RaiseAcceptPendingChange(value, _CbtipoClave)) { _CbtipoClave = value; OnPropertyChanged(); } } }

        private string? _CbtipoNombre;
        [XmlAttribute]
        public string? CbtipoNombre { get => _CbtipoNombre; set { if (RaiseAcceptPendingChange(value, _CbtipoNombre)) { _CbtipoNombre = value; OnPropertyChanged(); } } }

        private string? _CborigenfiscalClave;
        [XmlAttribute]
        public string? CborigenfiscalClave { get => _CborigenfiscalClave; set { if (RaiseAcceptPendingChange(value, _CborigenfiscalClave)) { _CborigenfiscalClave = value; OnPropertyChanged(); } } }

        private string? _CborigenfiscalNombre;
        [XmlAttribute]
        public string? CborigenfiscalNombre { get => _CborigenfiscalNombre; set { if (RaiseAcceptPendingChange(value, _CborigenfiscalNombre)) { _CborigenfiscalNombre = value; OnPropertyChanged(); } } }

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
    public class WFMovimientosClienteWF_Get_lista_abonos_doctoBindingModel : Validatable
    {

        public WFMovimientosClienteWF_Get_lista_abonos_doctoBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fechaelaboracion;
        [XmlAttribute]
        public DateTimeOffset? Fechaelaboracion { get => _Fechaelaboracion; set { if (RaiseAcceptPendingChange(value, _Fechaelaboracion)) { _Fechaelaboracion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecharecepcion;
        [XmlAttribute]
        public DateTimeOffset? Fecharecepcion { get => _Fecharecepcion; set { if (RaiseAcceptPendingChange(value, _Fecharecepcion)) { _Fecharecepcion = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaaplicado;
        [XmlAttribute]
        public DateTimeOffset? Fechaaplicado { get => _Fechaaplicado; set { if (RaiseAcceptPendingChange(value, _Fechaaplicado)) { _Fechaaplicado = value; OnPropertyChanged(); } } }

        private string? _Notas;
        [XmlAttribute]
        public string? Notas { get => _Notas; set { if (RaiseAcceptPendingChange(value, _Notas)) { _Notas = value; OnPropertyChanged(); } } }

        private string? _Formadepago;
        [XmlAttribute]
        public string? Formadepago { get => _Formadepago; set { if (RaiseAcceptPendingChange(value, _Formadepago)) { _Formadepago = value; OnPropertyChanged(); } } }

        private decimal? _Monto;
        [XmlAttribute]
        public decimal? Monto { get => _Monto; set { if (RaiseAcceptPendingChange(value, _Monto)) { _Monto = value; OnPropertyChanged(); } } }

        private string? _Banco;
        [XmlAttribute]
        public string? Banco { get => _Banco; set { if (RaiseAcceptPendingChange(value, _Banco)) { _Banco = value; OnPropertyChanged(); } } }

        private string? _Referenciabancaria;
        [XmlAttribute]
        public string? Referenciabancaria { get => _Referenciabancaria; set { if (RaiseAcceptPendingChange(value, _Referenciabancaria)) { _Referenciabancaria = value; OnPropertyChanged(); } } }

        private string? _Refinterno;
        [XmlAttribute]
        public string? Refinterno { get => _Refinterno; set { if (RaiseAcceptPendingChange(value, _Refinterno)) { _Refinterno = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Formapagoid;
        [XmlAttribute]
        public long? Formapagoid { get => _Formapagoid; set { if (RaiseAcceptPendingChange(value, _Formapagoid)) { _Formapagoid = value; OnPropertyChanged(); } } }

        private string? _Tipoabonodescripcion;
        [XmlAttribute]
        public string? Tipoabonodescripcion { get => _Tipoabonodescripcion; set { if (RaiseAcceptPendingChange(value, _Tipoabonodescripcion)) { _Tipoabonodescripcion = value; OnPropertyChanged(); } } }

        private long? _Tipoabonoid;
        [XmlAttribute]
        public long? Tipoabonoid { get => _Tipoabonoid; set { if (RaiseAcceptPendingChange(value, _Tipoabonoid)) { _Tipoabonoid = value; OnPropertyChanged(); } } }

        private string? _Revertido;
        [XmlAttribute]
        public string? Revertido { get => _Revertido; set { if (RaiseAcceptPendingChange(value, _Revertido)) { _Revertido = value; OnPropertyChanged(); } } }

        private long? _Pagoid;
        [XmlAttribute]
        public long? Pagoid { get => _Pagoid; set { if (RaiseAcceptPendingChange(value, _Pagoid)) { _Pagoid = value; OnPropertyChanged(); } } }

        private decimal? _Montopagocompuesto;
        [XmlAttribute]
        public decimal? Montopagocompuesto { get => _Montopagocompuesto; set { if (RaiseAcceptPendingChange(value, _Montopagocompuesto)) { _Montopagocompuesto = value; OnPropertyChanged(); } } }

        private int? _Folioref;
        [XmlAttribute]
        public int? Folioref { get => _Folioref; set { if (RaiseAcceptPendingChange(value, _Folioref)) { _Folioref = value; OnPropertyChanged(); } } }

        private string? _Nombrevendedor;
        [XmlAttribute]
        public string? Nombrevendedor { get => _Nombrevendedor; set { if (RaiseAcceptPendingChange(value, _Nombrevendedor)) { _Nombrevendedor = value; OnPropertyChanged(); } } }

        private string? _Aplicado;
        [XmlAttribute]
        public string? Aplicado { get => _Aplicado; set { if (RaiseAcceptPendingChange(value, _Aplicado)) { _Aplicado = value; OnPropertyChanged(); } } }

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
    public class WFMovimientosClienteWF_MovimientosBindingModel : Validatable
    {

        public WFMovimientosClienteWF_MovimientosBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private string? _Tipodoc;
        [XmlAttribute]
        public string? Tipodoc { get => _Tipodoc; set { if (RaiseAcceptPendingChange(value, _Tipodoc)) { _Tipodoc = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private int? _Foliosat;
        [XmlAttribute]
        public int? Foliosat { get => _Foliosat; set { if (RaiseAcceptPendingChange(value, _Foliosat)) { _Foliosat = value; OnPropertyChanged(); } } }

        private string? _Seriesat;
        [XmlAttribute]
        public string? Seriesat { get => _Seriesat; set { if (RaiseAcceptPendingChange(value, _Seriesat)) { _Seriesat = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute]
        public decimal? Descuento { get => _Descuento; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value; OnPropertyChanged(); } } }

        private decimal? _Subtotal;
        [XmlAttribute]
        public decimal? Subtotal { get => _Subtotal; set { if (RaiseAcceptPendingChange(value, _Subtotal)) { _Subtotal = value; OnPropertyChanged(); } } }

        private decimal? _Iva;
        [XmlAttribute]
        public decimal? Iva { get => _Iva; set { if (RaiseAcceptPendingChange(value, _Iva)) { _Iva = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute]
        public decimal? Saldo { get => _Saldo; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value; OnPropertyChanged(); } } }

        private decimal? _Saldo_sdoc;
        [XmlAttribute]
        public decimal? Saldo_sdoc { get => _Saldo_sdoc; set { if (RaiseAcceptPendingChange(value, _Saldo_sdoc)) { _Saldo_sdoc = value; OnPropertyChanged(); } } }

        private decimal? _Porc_utilidad;
        [XmlAttribute]
        public decimal? Porc_utilidad { get => _Porc_utilidad; set { if (RaiseAcceptPendingChange(value, _Porc_utilidad)) { _Porc_utilidad = value; OnPropertyChanged(); } } }

        private string? _Sucursalt;
        [XmlAttribute]
        public string? Sucursalt { get => _Sucursalt; set { if (RaiseAcceptPendingChange(value, _Sucursalt)) { _Sucursalt = value; OnPropertyChanged(); } } }

        private string? _Persona;
        [XmlAttribute]
        public string? Persona { get => _Persona; set { if (RaiseAcceptPendingChange(value, _Persona)) { _Persona = value; OnPropertyChanged(); } } }

        private string? _Nombrevendedor;
        [XmlAttribute]
        public string? Nombrevendedor { get => _Nombrevendedor; set { if (RaiseAcceptPendingChange(value, _Nombrevendedor)) { _Nombrevendedor = value; OnPropertyChanged(); } } }

        private string? _Almacennombre;
        [XmlAttribute]
        public string? Almacennombre { get => _Almacennombre; set { if (RaiseAcceptPendingChange(value, _Almacennombre)) { _Almacennombre = value; OnPropertyChanged(); } } }

        private string? _Estadosurtidonombre;
        [XmlAttribute]
        public string? Estadosurtidonombre { get => _Estadosurtidonombre; set { if (RaiseAcceptPendingChange(value, _Estadosurtidonombre)) { _Estadosurtidonombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechasurtido;
        [XmlAttribute]
        public DateTimeOffset? Fechasurtido { get => _Fechasurtido; set { if (RaiseAcceptPendingChange(value, _Fechasurtido)) { _Fechasurtido = value; OnPropertyChanged(); } } }

        private string? _Personasurtido;
        [XmlAttribute]
        public string? Personasurtido { get => _Personasurtido; set { if (RaiseAcceptPendingChange(value, _Personasurtido)) { _Personasurtido = value; OnPropertyChanged(); } } }

        private string? _Estadoguianombre;
        [XmlAttribute]
        public string? Estadoguianombre { get => _Estadoguianombre; set { if (RaiseAcceptPendingChange(value, _Estadoguianombre)) { _Estadoguianombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaguiaenviado;
        [XmlAttribute]
        public DateTimeOffset? Fechaguiaenviado { get => _Fechaguiaenviado; set { if (RaiseAcceptPendingChange(value, _Fechaguiaenviado)) { _Fechaguiaenviado = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaguiarecibido;
        [XmlAttribute]
        public DateTimeOffset? Fechaguiarecibido { get => _Fechaguiarecibido; set { if (RaiseAcceptPendingChange(value, _Fechaguiarecibido)) { _Fechaguiarecibido = value; OnPropertyChanged(); } } }

        private string? _Encargadoguia;
        [XmlAttribute]
        public string? Encargadoguia { get => _Encargadoguia; set { if (RaiseAcceptPendingChange(value, _Encargadoguia)) { _Encargadoguia = value; OnPropertyChanged(); } } }

        private string? _Autorizoguia;
        [XmlAttribute]
        public string? Autorizoguia { get => _Autorizoguia; set { if (RaiseAcceptPendingChange(value, _Autorizoguia)) { _Autorizoguia = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Vence;
        [XmlAttribute]
        public DateTimeOffset? Vence { get => _Vence; set { if (RaiseAcceptPendingChange(value, _Vence)) { _Vence = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechaaprobacioncxc;
        [XmlAttribute]
        public DateTimeOffset? Fechaaprobacioncxc { get => _Fechaaprobacioncxc; set { if (RaiseAcceptPendingChange(value, _Fechaaprobacioncxc)) { _Fechaaprobacioncxc = value; OnPropertyChanged(); } } }

        private string? _Personaaprobacioncxc;
        [XmlAttribute]
        public string? Personaaprobacioncxc { get => _Personaaprobacioncxc; set { if (RaiseAcceptPendingChange(value, _Personaaprobacioncxc)) { _Personaaprobacioncxc = value; OnPropertyChanged(); } } }

        private string? _Personaguiarecibio;
        [XmlAttribute]
        public string? Personaguiarecibio { get => _Personaguiarecibio; set { if (RaiseAcceptPendingChange(value, _Personaguiarecibio)) { _Personaguiarecibio = value; OnPropertyChanged(); } } }

        private string? _Referencia;
        [XmlAttribute]
        public string? Referencia { get => _Referencia; set { if (RaiseAcceptPendingChange(value, _Referencia)) { _Referencia = value; OnPropertyChanged(); } } }

        private string? _Notapago;
        [XmlAttribute]
        public string? Notapago { get => _Notapago; set { if (RaiseAcceptPendingChange(value, _Notapago)) { _Notapago = value; OnPropertyChanged(); } } }

        private string? _Supervisornombre;
        [XmlAttribute]
        public string? Supervisornombre { get => _Supervisornombre; set { if (RaiseAcceptPendingChange(value, _Supervisornombre)) { _Supervisornombre = value; OnPropertyChanged(); } } }

        private string? _Notamovil1;
        [XmlAttribute]
        public string? Notamovil1 { get => _Notamovil1; set { if (RaiseAcceptPendingChange(value, _Notamovil1)) { _Notamovil1 = value; OnPropertyChanged(); } } }

        private string? _Notamovil2;
        [XmlAttribute]
        public string? Notamovil2 { get => _Notamovil2; set { if (RaiseAcceptPendingChange(value, _Notamovil2)) { _Notamovil2 = value; OnPropertyChanged(); } } }

        private string? _Notaautorizacioncredito;
        [XmlAttribute]
        public string? Notaautorizacioncredito { get => _Notaautorizacioncredito; set { if (RaiseAcceptPendingChange(value, _Notaautorizacioncredito)) { _Notaautorizacioncredito = value; OnPropertyChanged(); } } }

        private string? _Notacancelacion;
        [XmlAttribute]
        public string? Notacancelacion { get => _Notacancelacion; set { if (RaiseAcceptPendingChange(value, _Notacancelacion)) { _Notacancelacion = value; OnPropertyChanged(); } } }

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
    public class WFMovimientosClienteWF_MovimientosdetalleBindingModel : Validatable
    {

        public WFMovimientosClienteWF_MovimientosdetalleBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private int? _Folio;
        [XmlAttribute]
        public int? Folio { get => _Folio; set { if (RaiseAcceptPendingChange(value, _Folio)) { _Folio = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private string? _Descripcion11;
        [XmlAttribute]
        public string? Descripcion11 { get => _Descripcion11; set { if (RaiseAcceptPendingChange(value, _Descripcion11)) { _Descripcion11 = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private decimal? _Precio;
        [XmlAttribute]
        public decimal? Precio { get => _Precio; set { if (RaiseAcceptPendingChange(value, _Precio)) { _Precio = value; OnPropertyChanged(); } } }

        private decimal? _Precioconimpuesto;
        [XmlAttribute]
        public decimal? Precioconimpuesto { get => _Precioconimpuesto; set { if (RaiseAcceptPendingChange(value, _Precioconimpuesto)) { _Precioconimpuesto = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute]
        public decimal? Descuento { get => _Descuento; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value; OnPropertyChanged(); } } }

        private decimal? _Subtotal;
        [XmlAttribute]
        public decimal? Subtotal { get => _Subtotal; set { if (RaiseAcceptPendingChange(value, _Subtotal)) { _Subtotal = value; OnPropertyChanged(); } } }

        private decimal? _Iva;
        [XmlAttribute]
        public decimal? Iva { get => _Iva; set { if (RaiseAcceptPendingChange(value, _Iva)) { _Iva = value; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute]
        public decimal? Total { get => _Total; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value; OnPropertyChanged(); } } }

        private string? _Sucursalt;
        [XmlAttribute]
        public string? Sucursalt { get => _Sucursalt; set { if (RaiseAcceptPendingChange(value, _Sucursalt)) { _Sucursalt = value; OnPropertyChanged(); } } }

        private string? _Tipodoc;
        [XmlAttribute]
        public string? Tipodoc { get => _Tipodoc; set { if (RaiseAcceptPendingChange(value, _Tipodoc)) { _Tipodoc = value; OnPropertyChanged(); } } }

        private string? _Persona;
        [XmlAttribute]
        public string? Persona { get => _Persona; set { if (RaiseAcceptPendingChange(value, _Persona)) { _Persona = value; OnPropertyChanged(); } } }

        private string? _Preciomanualmasbajo;
        [XmlAttribute]
        public string? Preciomanualmasbajo { get => _Preciomanualmasbajo; set { if (RaiseAcceptPendingChange(value, _Preciomanualmasbajo)) { _Preciomanualmasbajo = value; OnPropertyChanged(); } } }

        private string? _Razondescuentocajero;
        [XmlAttribute]
        public string? Razondescuentocajero { get => _Razondescuentocajero; set { if (RaiseAcceptPendingChange(value, _Razondescuentocajero)) { _Razondescuentocajero = value; OnPropertyChanged(); } } }

        private string? _Nombrevendedor;
        [XmlAttribute]
        public string? Nombrevendedor { get => _Nombrevendedor; set { if (RaiseAcceptPendingChange(value, _Nombrevendedor)) { _Nombrevendedor = value; OnPropertyChanged(); } } }

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

