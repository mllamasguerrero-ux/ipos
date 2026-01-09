
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Bancomerparam : EntityBaseExt
    {


        public Bancomerparam() : base()
        {
        }

        public Bancomerparam(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Bancomerparam(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.NombreLength)]
    public string? Aid { get; set; }

    [Column(TypeName = "char(1)")]
    public BoolCN Bancomer { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
    public BoolCN Bitcampanas { get; set; } = BoolCN.N;

        [StringLength(Domains.NombreLength)]
    public string? Campanaautorizacion { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Campanareferencia { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Cardrequest { get; set; }

    public string? Cardtipo { get; set; }

    [Column(TypeName = "char(1)")]
    public BoolCN Promociones { get; set; } = BoolCN.N;

        [StringLength(Domains.NombreLength)]
    public string? Cliente_cmp_comercio { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Cliente_tdc_stock { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Codigo_beneficio1 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Codigo_beneficio2 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Codigo_beneficio3 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Codigo_beneficio4 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Codigo_beneficio5 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Codigo_beneficio6 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Codigo_beneficio7 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Comercio_cmp_comercio { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Comercio_tdc_stock { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Comision1 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Comision2 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Comision3 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Comision4 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Comision5 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Comision6 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Comision7 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Creditodebito { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Criptograma { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Ecoupnumber { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Factorexp { get; set; }

    [Column(TypeName = "char(1)")]
    public BoolCN Firmaautografa { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
    public BoolCN Firmaelectronica { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
    public BoolCN Firmaqps { get; set; } = BoolCN.N;

        [StringLength(Domains.NombreLength)]
    public string? Guia_cie { get; set; }

    [Column(TypeName = "char(1)")]
    public BoolCN Idtoken12 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
    public BoolCN Idtoken13 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
    public BoolCN Idtoken16 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
    public BoolCN Idtokenr7 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
    public BoolCN Idtokenr8 { get; set; } = BoolCN.N;

        [StringLength(Domains.NombreLength)]
    public string? Importe_beneficio { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Importe_udis { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Indicador_cambio_plazo { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Indicador_de_aviso { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Indicaodr_de_beneficio { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Isfolio { get; set; }

    [Column(TypeName = "char(1)")]
    public BoolCN Isoffline { get; set; } = BoolCN.N;

        [StringLength(Domains.NombreLength)]
    public string? Leyenda { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Macaddalternativa { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Mensaje_base_cheque { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Mensaje_base_continuos { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Mensaje_cliente { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Mensaje_cliente_emisro { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Mensaje_comercio { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Modoingreso { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_beneficio_multiple1 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_beneficio_simple1 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_cheque_actual { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_cheque_anterior { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_cheque_redimidos { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_continuos_actual { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_continuos_anterior { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_continuos_redimidos { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_multiple2 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_multiple3 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_multiple4 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_multiple5 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_multiple6 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_multiple7 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_simple2 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_simple3 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_simple4 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_simple5 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_simple6 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Monto_simple7 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Noautorizacion { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nombreaplicacion { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nombrecliente { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Numero_de_beneficios { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Numerotarjeta { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Numtarjetaii { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pesosredimidos { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pesossaldoanterior { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pesossaldodisponible { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pesossaldodisponinleexp { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pesossaldoredimidosexp { get; set; }

    [Column(TypeName = "char(1)")]
    public BoolCN Pinpad_uso { get; set; } = BoolCN.N;

        [StringLength(Domains.NombreLength)]
    public string? Pooladjusttype { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Poolid { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Poolnumber { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Poolunitlabel { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Puntosredimidos { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Puntossaldoanterior { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Puntossaldodisponible { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Puntossaldodisponibleexp { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Puntossaldoredimidosexp { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? R8_codigo_leyenda { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? R8_leyenda { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Razon_social { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Referencia_respuesta { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Referenciaafin { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Request { get; set; }

    public string? Respdll { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Response { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Segmentnumber { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tbines { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_beneficio1 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_beneficio2 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_beneficio3 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_beneficio4 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_beneficio5 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_beneficio6 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_beneficio7 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_respuesta1 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_respuesta2 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_respuesta3 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_respuesta4 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_respuesta5 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_respuesta6 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipo_respuesta7 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipopos { get; set; }

    [Column(TypeName = "char(1)")]
    public BoolCN Tnxconpuntos { get; set; } = BoolCN.N;

    [StringLength(Domains.NombreLength)]
    public string? Toperador { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Valtipocard { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Vigenciapromocionesexp { get; set; }

    [StringLength(Domains.Stdtext_lightLength)]
    public string? Tipotransaccion { get; set; }


    public short? Amex { get; set; }

    public long? Campanareferencianum { get; set; }

    public long? Clsrequestid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clsrequestid")]
        public virtual Requestbancomer? Clsrequest { get; set; }


        public long? Clsresponseid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clsresponseid")]
        public virtual Responsebancomer? Clsresponse { get; set; }


        public long? Pagosmultipagosid { get; set; }


        public long? Puntosid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Puntosid")]
        public virtual Strucptosbancomer? Puntos { get; set; }

        public long? Doctoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public long? Doctopagoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Doctopagoid")]
        public virtual Doctopago? Doctopago { get; set; }

        public long? Estadotransaccionid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Estadotransaccionid")]
        public virtual Estadotransbancomer? Estadotransaccion { get; set; }

        public long? Refid { get; set; }


        [NotMapped]
        public string? Clave { get { return ""; } set { } }

        [NotMapped]
        public string? Nombre { get { return ""; } set { } }


    }
}

