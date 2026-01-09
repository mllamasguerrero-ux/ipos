
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Cfdi : EntityBaseExt
    {


        public Cfdi() : base()
        {
        }

        public Cfdi(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cfdi(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.Stdtext_64Length)]
    public string? Serie { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Folio { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Tipocomprobante { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Formapago { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Moneda { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Tipocambio { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Condicionespago { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Metodopago { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Motivodescuento { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Lugarexpedicion { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Ex_lugarexpedicion { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Ex_numeroctapago { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Ex_seriefoliofiscaloriginal { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Ex_foliofiscaloriginal { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Em_rfc { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Em_razonsocial { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Em_regimenfiscal { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Em_calle { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Em_noexterior { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Em_nointerior { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Em_colonia { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Em_localidad { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Em_referencia { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Em_municipio { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Em_estado { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Em_pais { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Em_codigopostal { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Ee_calle { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Ee_noexterior { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Ee_nointerior { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Ee_colonia { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Ee_localidad { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Ee_referencia { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Ee_municipio { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Ee_estado { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Ee_pais { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Ee_codigopostal { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Rc_rfc { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rc_razonsocial { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rc_residenciafiscal { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rc_nombre { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Rc_numregidtrib { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Rc_usocfdi { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rc_calle { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Rc_noexterior { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Rc_nointerior { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rc_colonia { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rc_localidad { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rc_referencia { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rc_municipio { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Rc_estado { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Rc_pais { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Rc_codigopostal { get; set; }


        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


        public DateTimeOffset? Fecha { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Subtotal { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Descuento { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Total { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Ex_montofoliofiscaloriginal { get; set; } = 0m;

        public DateTimeOffset? Ex_fechafoliofiscaloriginal { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Totaltraslados { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Totalretenciones { get; set; } = 0m;



        [StringLength(Domains.Stdtext_64Length)]
        public string? Rc_Regimenfiscal { get; set; }

        [StringLength(Domains.Stdtext_64Length)]
        public string? Rc_Domiciliofiscal { get; set; }

        [StringLength(Domains.Stdtext_64Length)]
        public string? Exportacion { get; set; }

        [StringLength(Domains.Stdtext_64Length)]
        public string? Periodicidad { get; set; }

        [StringLength(Domains.Stdtext_64Length)]
        public string? Meses { get; set; }

        [StringLength(Domains.Stdtext_64Length)]
        public string? Anio { get; set; }




        [NotMapped]
        public string? Clave { get { return ""; } }

        [NotMapped]
        public string? Nombre { get { return ""; } }


        public virtual ICollection<Cfdi_conc>? Cfdi_conceptos { get; set; }
        public virtual ICollection<Cfdi_imp>? Cfdi_impuestos { get; set; }
        public virtual ICollection<Cfdi_rel>? Cfdi_relacionados { get; set; }



    }
}

