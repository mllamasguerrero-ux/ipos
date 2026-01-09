
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
    public class WFClienteEdicionWFBindingModel : Validatable
    {

        public WFClienteEdicionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Razonsocial;
        [XmlAttribute]
        public string? Razonsocial { get => _Razonsocial; set { if (RaiseAcceptPendingChange(value, _Razonsocial)) { _Razonsocial = value; OnPropertyChanged(); } } }

        private decimal? _Limitecredito;
        [XmlAttribute]
        public decimal? Limitecredito { get => _Limitecredito; set { if (RaiseAcceptPendingChange(value, _Limitecredito)) { _Limitecredito = value; OnPropertyChanged(); } } }

        private int? _Dias;
        [XmlAttribute]
        public int? Dias { get => _Dias; set { if (RaiseAcceptPendingChange(value, _Dias)) { _Dias = value; OnPropertyChanged(); } } }

        private int? _Dias_extr;
        [XmlAttribute]
        public int? Dias_extr { get => _Dias_extr; set { if (RaiseAcceptPendingChange(value, _Dias_extr)) { _Dias_extr = value; OnPropertyChanged(); } } }

        private long? _Paiscomboboxfb;
        [XmlAttribute]
        public long? Paiscomboboxfb { get => _Paiscomboboxfb; set { if (RaiseAcceptPendingChange(value, _Paiscomboboxfb)) { _Paiscomboboxfb = value; OnPropertyChanged(); } } }

        private long? _Estado;
        [XmlAttribute]
        public long? Estado { get => _Estado; set { if (RaiseAcceptPendingChange(value, _Estado)) { _Estado = value; OnPropertyChanged(); } } }

        private string? _Codigopostal;
        [XmlAttribute]
        public string? Codigopostal { get => _Codigopostal; set { if (RaiseAcceptPendingChange(value, _Codigopostal)) { _Codigopostal = value; OnPropertyChanged(); } } }

        private long? _Sat_localidadid;
        [XmlAttribute]
        public long? Sat_localidadid { get => _Sat_localidadid; set { if (RaiseAcceptPendingChange(value, _Sat_localidadid)) { _Sat_localidadid = value; OnPropertyChanged(); } } }

        private string? _Sat_localidadidClave;
        [XmlAttribute]
        public string? Sat_localidadidClave { get => _Sat_localidadidClave; set { if (RaiseAcceptPendingChange(value, _Sat_localidadidClave)) { _Sat_localidadidClave = value; OnPropertyChanged(); } } }

        private string? _Sat_localidadidNombre;
        [XmlAttribute]
        public string? Sat_localidadidNombre { get => _Sat_localidadidNombre; set { if (RaiseAcceptPendingChange(value, _Sat_localidadidNombre)) { _Sat_localidadidNombre = value; OnPropertyChanged(); } } }

        private long? _Revision;
        [XmlAttribute]
        public long? Revision { get => _Revision; set { if (RaiseAcceptPendingChange(value, _Revision)) { _Revision = value; OnPropertyChanged(); } } }

        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private decimal? _Por_come;
        [XmlAttribute]
        public decimal? Por_come { get => _Por_come; set { if (RaiseAcceptPendingChange(value, _Por_come)) { _Por_come = value; OnPropertyChanged(); } } }

        private long? _Pagos;
        [XmlAttribute]
        public long? Pagos { get => _Pagos; set { if (RaiseAcceptPendingChange(value, _Pagos)) { _Pagos = value; OnPropertyChanged(); } } }

        private long? _Sat_municipioid;
        [XmlAttribute]
        public long? Sat_municipioid { get => _Sat_municipioid; set { if (RaiseAcceptPendingChange(value, _Sat_municipioid)) { _Sat_municipioid = value; OnPropertyChanged(); } } }

        private string? _Sat_municipioidClave;
        [XmlAttribute]
        public string? Sat_municipioidClave { get => _Sat_municipioidClave; set { if (RaiseAcceptPendingChange(value, _Sat_municipioidClave)) { _Sat_municipioidClave = value; OnPropertyChanged(); } } }

        private string? _Sat_municipioidNombre;
        [XmlAttribute]
        public string? Sat_municipioidNombre { get => _Sat_municipioidNombre; set { if (RaiseAcceptPendingChange(value, _Sat_municipioidNombre)) { _Sat_municipioidNombre = value; OnPropertyChanged(); } } }

        private long? _Sat_coloniaid;
        [XmlAttribute]
        public long? Sat_coloniaid { get => _Sat_coloniaid; set { if (RaiseAcceptPendingChange(value, _Sat_coloniaid)) { _Sat_coloniaid = value; OnPropertyChanged(); } } }

        private string? _Sat_coloniaidClave;
        [XmlAttribute]
        public string? Sat_coloniaidClave { get => _Sat_coloniaidClave; set { if (RaiseAcceptPendingChange(value, _Sat_coloniaidClave)) { _Sat_coloniaidClave = value; OnPropertyChanged(); } } }

        private string? _Sat_coloniaidNombre;
        [XmlAttribute]
        public string? Sat_coloniaidNombre { get => _Sat_coloniaidNombre; set { if (RaiseAcceptPendingChange(value, _Sat_coloniaidNombre)) { _Sat_coloniaidNombre = value; OnPropertyChanged(); } } }

        private string? _Telefono1;
        [XmlAttribute]
        public string? Telefono1 { get => _Telefono1; set { if (RaiseAcceptPendingChange(value, _Telefono1)) { _Telefono1 = value; OnPropertyChanged(); } } }

        private string? _Telefono2;
        [XmlAttribute]
        public string? Telefono2 { get => _Telefono2; set { if (RaiseAcceptPendingChange(value, _Telefono2)) { _Telefono2 = value; OnPropertyChanged(); } } }

        private long? _Listaprecioid;
        [XmlAttribute]
        public long? Listaprecioid { get => _Listaprecioid; set { if (RaiseAcceptPendingChange(value, _Listaprecioid)) { _Listaprecioid = value; OnPropertyChanged(); } } }

        private long? _Superlistaprecioid;
        [XmlAttribute]
        public long? Superlistaprecioid { get => _Superlistaprecioid; set { if (RaiseAcceptPendingChange(value, _Superlistaprecioid)) { _Superlistaprecioid = value; OnPropertyChanged(); } } }

        private string? _Domicilio;
        [XmlAttribute]
        public string? Domicilio { get => _Domicilio; set { if (RaiseAcceptPendingChange(value, _Domicilio)) { _Domicilio = value; OnPropertyChanged(); } } }

        private string? _Numeroexterior;
        [XmlAttribute]
        public string? Numeroexterior { get => _Numeroexterior; set { if (RaiseAcceptPendingChange(value, _Numeroexterior)) { _Numeroexterior = value; OnPropertyChanged(); } } }

        private string? _Numerointerior;
        [XmlAttribute]
        public string? Numerointerior { get => _Numerointerior; set { if (RaiseAcceptPendingChange(value, _Numerointerior)) { _Numerointerior = value; OnPropertyChanged(); } } }

        private string? _Referenciadom;
        [XmlAttribute]
        public string? Referenciadom { get => _Referenciadom; set { if (RaiseAcceptPendingChange(value, _Referenciadom)) { _Referenciadom = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsepararprodxplazo;
        [XmlAttribute]
        public BoolCN? Cbsepararprodxplazo { get => _Cbsepararprodxplazo; set { if (RaiseAcceptPendingChange(value, _Cbsepararprodxplazo)) { _Cbsepararprodxplazo = value; OnPropertyChanged(); } } }

        private BoolCN? _Bloqueado;
        [XmlAttribute]
        public BoolCN? Bloqueado { get => _Bloqueado; set { if (RaiseAcceptPendingChange(value, _Bloqueado)) { _Bloqueado = value; OnPropertyChanged(); } } }

        private long? _Subtipocliente;
        [XmlAttribute]
        public long? Subtipocliente { get => _Subtipocliente; set { if (RaiseAcceptPendingChange(value, _Subtipocliente)) { _Subtipocliente = value; OnPropertyChanged(); } } }

        private string? _SubtipoclienteClave;
        [XmlAttribute]
        public string? SubtipoclienteClave { get => _SubtipoclienteClave; set { if (RaiseAcceptPendingChange(value, _SubtipoclienteClave)) { _SubtipoclienteClave = value; OnPropertyChanged(); } } }

        private string? _SubtipoclienteNombre;
        [XmlAttribute]
        public string? SubtipoclienteNombre { get => _SubtipoclienteNombre; set { if (RaiseAcceptPendingChange(value, _SubtipoclienteNombre)) { _SubtipoclienteNombre = value; OnPropertyChanged(); } } }

        private long? _Sat_usocfdiid;
        [XmlAttribute]
        public long? Sat_usocfdiid { get => _Sat_usocfdiid; set { if (RaiseAcceptPendingChange(value, _Sat_usocfdiid)) { _Sat_usocfdiid = value; OnPropertyChanged(); } } }

        private string? _Sat_usocfdiidClave;
        [XmlAttribute]
        public string? Sat_usocfdiidClave { get => _Sat_usocfdiidClave; set { if (RaiseAcceptPendingChange(value, _Sat_usocfdiidClave)) { _Sat_usocfdiidClave = value; OnPropertyChanged(); } } }

        private string? _Sat_usocfdiidNombre;
        [XmlAttribute]
        public string? Sat_usocfdiidNombre { get => _Sat_usocfdiidNombre; set { if (RaiseAcceptPendingChange(value, _Sat_usocfdiidNombre)) { _Sat_usocfdiidNombre = value; OnPropertyChanged(); } } }

        private long? _Sat_regimenfiscalid;
        [XmlAttribute]
        public long? Sat_regimenfiscalid { get => _Sat_regimenfiscalid; set { if (RaiseAcceptPendingChange(value, _Sat_regimenfiscalid)) { _Sat_regimenfiscalid = value; OnPropertyChanged(); } } }

        private string? _Sat_regimenfiscalidClave;
        [XmlAttribute]
        public string? Sat_regimenfiscalidClave { get => _Sat_regimenfiscalidClave; set { if (RaiseAcceptPendingChange(value, _Sat_regimenfiscalidClave)) { _Sat_regimenfiscalidClave = value; OnPropertyChanged(); } } }

        private string? _Sat_regimenfiscalidNombre;
        [XmlAttribute]
        public string? Sat_regimenfiscalidNombre { get => _Sat_regimenfiscalidNombre; set { if (RaiseAcceptPendingChange(value, _Sat_regimenfiscalidNombre)) { _Sat_regimenfiscalidNombre = value; OnPropertyChanged(); } } }

        private string? _Rfc;
        [XmlAttribute]
        public string? Rfc { get => _Rfc; set { if (RaiseAcceptPendingChange(value, _Rfc)) { _Rfc = value; OnPropertyChanged(); } } }

        private long? _Creditoformapagoabonos;
        [XmlAttribute]
        public long? Creditoformapagoabonos { get => _Creditoformapagoabonos; set { if (RaiseAcceptPendingChange(value, _Creditoformapagoabonos)) { _Creditoformapagoabonos = value; OnPropertyChanged(); } } }

        private string? _Creditoreferenciaabonos;
        [XmlAttribute]
        public string? Creditoreferenciaabonos { get => _Creditoreferenciaabonos; set { if (RaiseAcceptPendingChange(value, _Creditoreferenciaabonos)) { _Creditoreferenciaabonos = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Vigencia;
        [XmlAttribute]
        public DateTimeOffset? Vigencia { get => _Vigencia; set { if (RaiseAcceptPendingChange(value, _Vigencia)) { _Vigencia = value; OnPropertyChanged(); } } }

        private string? _Contacto1;
        [XmlAttribute]
        public string? Contacto1 { get => _Contacto1; set { if (RaiseAcceptPendingChange(value, _Contacto1)) { _Contacto1 = value; OnPropertyChanged(); } } }

        private string? _Contacto2;
        [XmlAttribute]
        public string? Contacto2 { get => _Contacto2; set { if (RaiseAcceptPendingChange(value, _Contacto2)) { _Contacto2 = value; OnPropertyChanged(); } } }

        private string? _Email1;
        [XmlAttribute]
        public string? Email1 { get => _Email1; set { if (RaiseAcceptPendingChange(value, _Email1)) { _Email1 = value; OnPropertyChanged(); } } }

        private string? _Email2;
        [XmlAttribute]
        public string? Email2 { get => _Email2; set { if (RaiseAcceptPendingChange(value, _Email2)) { _Email2 = value; OnPropertyChanged(); } } }

        private string? _Creadopor_userclave;
        [XmlAttribute]
        public string? Creadopor_userclave { get => _Creadopor_userclave; set { if (RaiseAcceptPendingChange(value, _Creadopor_userclave)) { _Creadopor_userclave = value; OnPropertyChanged(); } } }

        private string? _Modificadopor_userid;
        [XmlAttribute]
        public string? Modificadopor_userid { get => _Modificadopor_userid; set { if (RaiseAcceptPendingChange(value, _Modificadopor_userid)) { _Modificadopor_userid = value; OnPropertyChanged(); } } }

        private BoolCN? _Pagoparcialidades;
        [XmlAttribute]
        public BoolCN? Pagoparcialidades { get => _Pagoparcialidades; set { if (RaiseAcceptPendingChange(value, _Pagoparcialidades)) { _Pagoparcialidades = value; OnPropertyChanged(); } } }

        private BoolCN? _Cargoxventacontarjeta;
        [XmlAttribute]
        public BoolCN? Cargoxventacontarjeta { get => _Cargoxventacontarjeta; set { if (RaiseAcceptPendingChange(value, _Cargoxventacontarjeta)) { _Cargoxventacontarjeta = value; OnPropertyChanged(); } } }

        private BoolCN? _Pagotarjmenorpreciolista;
        [XmlAttribute]
        public BoolCN? Pagotarjmenorpreciolista { get => _Pagotarjmenorpreciolista; set { if (RaiseAcceptPendingChange(value, _Pagotarjmenorpreciolista)) { _Pagotarjmenorpreciolista = value; OnPropertyChanged(); } } }

        private long? _Monedaid;
        [XmlAttribute]
        public long? Monedaid { get => _Monedaid; set { if (RaiseAcceptPendingChange(value, _Monedaid)) { _Monedaid = value; OnPropertyChanged(); } } }

        private string? _MonedaidClave;
        [XmlAttribute]
        public string? MonedaidClave { get => _MonedaidClave; set { if (RaiseAcceptPendingChange(value, _MonedaidClave)) { _MonedaidClave = value; OnPropertyChanged(); } } }

        private string? _MonedaidNombre;
        [XmlAttribute]
        public string? MonedaidNombre { get => _MonedaidNombre; set { if (RaiseAcceptPendingChange(value, _MonedaidNombre)) { _MonedaidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Generarreciboelectronico;
        [XmlAttribute]
        public BoolCN? Generarreciboelectronico { get => _Generarreciboelectronico; set { if (RaiseAcceptPendingChange(value, _Generarreciboelectronico)) { _Generarreciboelectronico = value; OnPropertyChanged(); } } }

        private string? _Memo;
        [XmlAttribute]
        public string? Memo { get => _Memo; set { if (RaiseAcceptPendingChange(value, _Memo)) { _Memo = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Ultimaventa;
        [XmlAttribute]
        public DateTimeOffset? Ultimaventa { get => _Ultimaventa; set { if (RaiseAcceptPendingChange(value, _Ultimaventa)) { _Ultimaventa = value; OnPropertyChanged(); } } }

        private string? _Cuentaieps;
        [XmlAttribute]
        public string? Cuentaieps { get => _Cuentaieps; set { if (RaiseAcceptPendingChange(value, _Cuentaieps)) { _Cuentaieps = value; OnPropertyChanged(); } } }

        private BoolCN? _Servicioadomicilio;
        [XmlAttribute]
        public BoolCN? Servicioadomicilio { get => _Servicioadomicilio; set { if (RaiseAcceptPendingChange(value, _Servicioadomicilio)) { _Servicioadomicilio = value; OnPropertyChanged(); } } }

        private BoolCN? _Desgloseieps;
        [XmlAttribute]
        public BoolCN? Desgloseieps { get => _Desgloseieps; set { if (RaiseAcceptPendingChange(value, _Desgloseieps)) { _Desgloseieps = value; OnPropertyChanged(); } } }

        private decimal? _Distancia;
        [XmlAttribute]
        public decimal? Distancia { get => _Distancia; set { if (RaiseAcceptPendingChange(value, _Distancia)) { _Distancia = value; OnPropertyChanged(); } } }

        private string? _Txtcuentacontpaq;
        [XmlAttribute]
        public string? Txtcuentacontpaq { get => _Txtcuentacontpaq; set { if (RaiseAcceptPendingChange(value, _Txtcuentacontpaq)) { _Txtcuentacontpaq = value; OnPropertyChanged(); } } }

        private BoolCN? _Chkordencompra;
        [XmlAttribute]
        public BoolCN? Chkordencompra { get => _Chkordencompra; set { if (RaiseAcceptPendingChange(value, _Chkordencompra)) { _Chkordencompra = value; OnPropertyChanged(); } } }

        private long? _Vendedorid;
        [XmlAttribute]
        public long? Vendedorid { get => _Vendedorid; set { if (RaiseAcceptPendingChange(value, _Vendedorid)) { _Vendedorid = value; OnPropertyChanged(); } } }

        private string? _VendedoridClave;
        [XmlAttribute]
        public string? VendedoridClave { get => _VendedoridClave; set { if (RaiseAcceptPendingChange(value, _VendedoridClave)) { _VendedoridClave = value; OnPropertyChanged(); } } }

        private string? _VendedoridNombre;
        [XmlAttribute]
        public string? VendedoridNombre { get => _VendedoridNombre; set { if (RaiseAcceptPendingChange(value, _VendedoridNombre)) { _VendedoridNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_pagotarjeta;
        [XmlAttribute]
        public BoolCN? Hab_pagotarjeta { get => _Hab_pagotarjeta; set { if (RaiseAcceptPendingChange(value, _Hab_pagotarjeta)) { _Hab_pagotarjeta = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_pagocredito;
        [XmlAttribute]
        public BoolCN? Hab_pagocredito { get => _Hab_pagocredito; set { if (RaiseAcceptPendingChange(value, _Hab_pagocredito)) { _Hab_pagocredito = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_pagocheque;
        [XmlAttribute]
        public BoolCN? Hab_pagocheque { get => _Hab_pagocheque; set { if (RaiseAcceptPendingChange(value, _Hab_pagocheque)) { _Hab_pagocheque = value; OnPropertyChanged(); } } }

        private string? _Nombres;
        [XmlAttribute]
        public string? Nombres { get => _Nombres; set { if (RaiseAcceptPendingChange(value, _Nombres)) { _Nombres = value; OnPropertyChanged(); } } }

        private string? _Apellidos;
        [XmlAttribute]
        public string? Apellidos { get => _Apellidos; set { if (RaiseAcceptPendingChange(value, _Apellidos)) { _Apellidos = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_pagotransferencia;
        [XmlAttribute]
        public BoolCN? Hab_pagotransferencia { get => _Hab_pagotransferencia; set { if (RaiseAcceptPendingChange(value, _Hab_pagotransferencia)) { _Hab_pagotransferencia = value; OnPropertyChanged(); } } }

        private BoolCN? _Hab_pagoefectivo;
        [XmlAttribute]
        public BoolCN? Hab_pagoefectivo { get => _Hab_pagoefectivo; set { if (RaiseAcceptPendingChange(value, _Hab_pagoefectivo)) { _Hab_pagoefectivo = value; OnPropertyChanged(); } } }

        private long? _Entrega_sat_coloniaid;
        [XmlAttribute]
        public long? Entrega_sat_coloniaid { get => _Entrega_sat_coloniaid; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_coloniaid)) { _Entrega_sat_coloniaid = value; OnPropertyChanged(); } } }

        private string? _Entrega_sat_coloniaidClave;
        [XmlAttribute]
        public string? Entrega_sat_coloniaidClave { get => _Entrega_sat_coloniaidClave; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_coloniaidClave)) { _Entrega_sat_coloniaidClave = value; OnPropertyChanged(); } } }

        private string? _Entrega_sat_coloniaidNombre;
        [XmlAttribute]
        public string? Entrega_sat_coloniaidNombre { get => _Entrega_sat_coloniaidNombre; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_coloniaidNombre)) { _Entrega_sat_coloniaidNombre = value; OnPropertyChanged(); } } }

        private string? _Entregacalle;
        [XmlAttribute]
        public string? Entregacalle { get => _Entregacalle; set { if (RaiseAcceptPendingChange(value, _Entregacalle)) { _Entregacalle = value; OnPropertyChanged(); } } }

        private string? _Entreganumeroexterior;
        [XmlAttribute]
        public string? Entreganumeroexterior { get => _Entreganumeroexterior; set { if (RaiseAcceptPendingChange(value, _Entreganumeroexterior)) { _Entreganumeroexterior = value; OnPropertyChanged(); } } }

        private string? _Entreganumerointerior;
        [XmlAttribute]
        public string? Entreganumerointerior { get => _Entreganumerointerior; set { if (RaiseAcceptPendingChange(value, _Entreganumerointerior)) { _Entreganumerointerior = value; OnPropertyChanged(); } } }

        private decimal? _Entrega_distancia;
        [XmlAttribute]
        public decimal? Entrega_distancia { get => _Entrega_distancia; set { if (RaiseAcceptPendingChange(value, _Entrega_distancia)) { _Entrega_distancia = value; OnPropertyChanged(); } } }

        private string? _Entregareferenciadom;
        [XmlAttribute]
        public string? Entregareferenciadom { get => _Entregareferenciadom; set { if (RaiseAcceptPendingChange(value, _Entregareferenciadom)) { _Entregareferenciadom = value; OnPropertyChanged(); } } }

        private BoolCN? _Retieneiva;
        [XmlAttribute]
        public BoolCN? Retieneiva { get => _Retieneiva; set { if (RaiseAcceptPendingChange(value, _Retieneiva)) { _Retieneiva = value; OnPropertyChanged(); } } }

        private BoolCN? _Retieneisr;
        [XmlAttribute]
        public BoolCN? Retieneisr { get => _Retieneisr; set { if (RaiseAcceptPendingChange(value, _Retieneisr)) { _Retieneisr = value; OnPropertyChanged(); } } }

        private long? _Proveeclienteid;
        [XmlAttribute]
        public long? Proveeclienteid { get => _Proveeclienteid; set { if (RaiseAcceptPendingChange(value, _Proveeclienteid)) { _Proveeclienteid = value; OnPropertyChanged(); } } }

        private string? _ProveeclienteidClave;
        [XmlAttribute]
        public string? ProveeclienteidClave { get => _ProveeclienteidClave; set { if (RaiseAcceptPendingChange(value, _ProveeclienteidClave)) { _ProveeclienteidClave = value; OnPropertyChanged(); } } }

        private string? _ProveeclienteidNombre;
        [XmlAttribute]
        public string? ProveeclienteidNombre { get => _ProveeclienteidNombre; set { if (RaiseAcceptPendingChange(value, _ProveeclienteidNombre)) { _ProveeclienteidNombre = value; OnPropertyChanged(); } } }

        private string? _Email3;
        [XmlAttribute]
        public string? Email3 { get => _Email3; set { if (RaiseAcceptPendingChange(value, _Email3)) { _Email3 = value; OnPropertyChanged(); } } }

        private string? _Email4;
        [XmlAttribute]
        public string? Email4 { get => _Email4; set { if (RaiseAcceptPendingChange(value, _Email4)) { _Email4 = value; OnPropertyChanged(); } } }

        private BoolCN? _Exentoiva;
        [XmlAttribute]
        public BoolCN? Exentoiva { get => _Exentoiva; set { if (RaiseAcceptPendingChange(value, _Exentoiva)) { _Exentoiva = value; OnPropertyChanged(); } } }

        private long? _Rutaembarqueid;
        [XmlAttribute]
        public long? Rutaembarqueid { get => _Rutaembarqueid; set { if (RaiseAcceptPendingChange(value, _Rutaembarqueid)) { _Rutaembarqueid = value; OnPropertyChanged(); } } }

        private string? _RutaembarqueidClave;
        [XmlAttribute]
        public string? RutaembarqueidClave { get => _RutaembarqueidClave; set { if (RaiseAcceptPendingChange(value, _RutaembarqueidClave)) { _RutaembarqueidClave = value; OnPropertyChanged(); } } }

        private string? _RutaembarqueidNombre;
        [XmlAttribute]
        public string? RutaembarqueidNombre { get => _RutaembarqueidNombre; set { if (RaiseAcceptPendingChange(value, _RutaembarqueidNombre)) { _RutaembarqueidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Preguntarticketlargo;
        [XmlAttribute]
        public BoolCN? Preguntarticketlargo { get => _Preguntarticketlargo; set { if (RaiseAcceptPendingChange(value, _Preguntarticketlargo)) { _Preguntarticketlargo = value; OnPropertyChanged(); } } }

        private BoolCN? _Mayoreoxproducto;
        [XmlAttribute]
        public BoolCN? Mayoreoxproducto { get => _Mayoreoxproducto; set { if (RaiseAcceptPendingChange(value, _Mayoreoxproducto)) { _Mayoreoxproducto = value; OnPropertyChanged(); } } }

        private BoolCN? _Generacomprobtrasl;
        [XmlAttribute]
        public BoolCN? Generacomprobtrasl { get => _Generacomprobtrasl; set { if (RaiseAcceptPendingChange(value, _Generacomprobtrasl)) { _Generacomprobtrasl = value; OnPropertyChanged(); } } }

        private BoolCN? _Generacartaporte;
        [XmlAttribute]
        public BoolCN? Generacartaporte { get => _Generacartaporte; set { if (RaiseAcceptPendingChange(value, _Generacartaporte)) { _Generacartaporte = value; OnPropertyChanged(); } } }

        private long? _Entrega_sat_municipioid;
        [XmlAttribute]
        public long? Entrega_sat_municipioid { get => _Entrega_sat_municipioid; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_municipioid)) { _Entrega_sat_municipioid = value; OnPropertyChanged(); } } }

        private string? _Entrega_sat_municipioidClave;
        [XmlAttribute]
        public string? Entrega_sat_municipioidClave { get => _Entrega_sat_municipioidClave; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_municipioidClave)) { _Entrega_sat_municipioidClave = value; OnPropertyChanged(); } } }

        private string? _Entrega_sat_municipioidNombre;
        [XmlAttribute]
        public string? Entrega_sat_municipioidNombre { get => _Entrega_sat_municipioidNombre; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_municipioidNombre)) { _Entrega_sat_municipioidNombre = value; OnPropertyChanged(); } } }

        private long? _Entregaestado;
        [XmlAttribute]
        public long? Entregaestado { get => _Entregaestado; set { if (RaiseAcceptPendingChange(value, _Entregaestado)) { _Entregaestado = value; OnPropertyChanged(); } } }

        private string? _Entregacodigopostal;
        [XmlAttribute]
        public string? Entregacodigopostal { get => _Entregacodigopostal; set { if (RaiseAcceptPendingChange(value, _Entregacodigopostal)) { _Entregacodigopostal = value; OnPropertyChanged(); } } }

        private long? _Entrega_sat_localidadid;
        [XmlAttribute]
        public long? Entrega_sat_localidadid { get => _Entrega_sat_localidadid; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_localidadid)) { _Entrega_sat_localidadid = value; OnPropertyChanged(); } } }

        private string? _Entrega_sat_localidadidClave;
        [XmlAttribute]
        public string? Entrega_sat_localidadidClave { get => _Entrega_sat_localidadidClave; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_localidadidClave)) { _Entrega_sat_localidadidClave = value; OnPropertyChanged(); } } }

        private string? _Entrega_sat_localidadidNombre;
        [XmlAttribute]
        public string? Entrega_sat_localidadidNombre { get => _Entrega_sat_localidadidNombre; set { if (RaiseAcceptPendingChange(value, _Entrega_sat_localidadidNombre)) { _Entrega_sat_localidadidNombre = value; OnPropertyChanged(); } } }

        private string? _PaiscomboboxfbClave;
        [XmlAttribute]
        public string? PaiscomboboxfbClave { get => _PaiscomboboxfbClave; set { if (RaiseAcceptPendingChange(value, _PaiscomboboxfbClave)) { _PaiscomboboxfbClave = value; OnPropertyChanged(); } } }

        private string? _PaiscomboboxfbNombre;
        [XmlAttribute]
        public string? PaiscomboboxfbNombre { get => _PaiscomboboxfbNombre; set { if (RaiseAcceptPendingChange(value, _PaiscomboboxfbNombre)) { _PaiscomboboxfbNombre = value; OnPropertyChanged(); } } }

        private string? _EstadoClave;
        [XmlAttribute]
        public string? EstadoClave { get => _EstadoClave; set { if (RaiseAcceptPendingChange(value, _EstadoClave)) { _EstadoClave = value; OnPropertyChanged(); } } }

        private string? _EstadoNombre;
        [XmlAttribute]
        public string? EstadoNombre { get => _EstadoNombre; set { if (RaiseAcceptPendingChange(value, _EstadoNombre)) { _EstadoNombre = value; OnPropertyChanged(); } } }

        private string? _RevisionClave;
        [XmlAttribute]
        public string? RevisionClave { get => _RevisionClave; set { if (RaiseAcceptPendingChange(value, _RevisionClave)) { _RevisionClave = value; OnPropertyChanged(); } } }

        private string? _RevisionNombre;
        [XmlAttribute]
        public string? RevisionNombre { get => _RevisionNombre; set { if (RaiseAcceptPendingChange(value, _RevisionNombre)) { _RevisionNombre = value; OnPropertyChanged(); } } }

        private string? _PagosClave;
        [XmlAttribute]
        public string? PagosClave { get => _PagosClave; set { if (RaiseAcceptPendingChange(value, _PagosClave)) { _PagosClave = value; OnPropertyChanged(); } } }

        private string? _PagosNombre;
        [XmlAttribute]
        public string? PagosNombre { get => _PagosNombre; set { if (RaiseAcceptPendingChange(value, _PagosNombre)) { _PagosNombre = value; OnPropertyChanged(); } } }

        private string? _ListaprecioidClave;
        [XmlAttribute]
        public string? ListaprecioidClave { get => _ListaprecioidClave; set { if (RaiseAcceptPendingChange(value, _ListaprecioidClave)) { _ListaprecioidClave = value; OnPropertyChanged(); } } }

        private string? _ListaprecioidNombre;
        [XmlAttribute]
        public string? ListaprecioidNombre { get => _ListaprecioidNombre; set { if (RaiseAcceptPendingChange(value, _ListaprecioidNombre)) { _ListaprecioidNombre = value; OnPropertyChanged(); } } }

        private string? _SuperlistaprecioidClave;
        [XmlAttribute]
        public string? SuperlistaprecioidClave { get => _SuperlistaprecioidClave; set { if (RaiseAcceptPendingChange(value, _SuperlistaprecioidClave)) { _SuperlistaprecioidClave = value; OnPropertyChanged(); } } }

        private string? _SuperlistaprecioidNombre;
        [XmlAttribute]
        public string? SuperlistaprecioidNombre { get => _SuperlistaprecioidNombre; set { if (RaiseAcceptPendingChange(value, _SuperlistaprecioidNombre)) { _SuperlistaprecioidNombre = value; OnPropertyChanged(); } } }

        private string? _CreditoformapagoabonosClave;
        [XmlAttribute]
        public string? CreditoformapagoabonosClave { get => _CreditoformapagoabonosClave; set { if (RaiseAcceptPendingChange(value, _CreditoformapagoabonosClave)) { _CreditoformapagoabonosClave = value; OnPropertyChanged(); } } }

        private string? _CreditoformapagoabonosNombre;
        [XmlAttribute]
        public string? CreditoformapagoabonosNombre { get => _CreditoformapagoabonosNombre; set { if (RaiseAcceptPendingChange(value, _CreditoformapagoabonosNombre)) { _CreditoformapagoabonosNombre = value; OnPropertyChanged(); } } }

        private string? _EntregaestadoClave;
        [XmlAttribute]
        public string? EntregaestadoClave { get => _EntregaestadoClave; set { if (RaiseAcceptPendingChange(value, _EntregaestadoClave)) { _EntregaestadoClave = value; OnPropertyChanged(); } } }

        private string? _EntregaestadoNombre;
        [XmlAttribute]
        public string? EntregaestadoNombre { get => _EntregaestadoNombre; set { if (RaiseAcceptPendingChange(value, _EntregaestadoNombre)) { _EntregaestadoNombre = value; OnPropertyChanged(); } } }

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

