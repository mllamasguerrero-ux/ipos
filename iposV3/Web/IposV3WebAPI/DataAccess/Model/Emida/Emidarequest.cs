
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
    public class Emidarequest : EntityBaseExt
    {


        public Emidarequest() : base()
        {
        }

        public Emidarequest(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Emidarequest(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.NombreLength)]
    public string? Version { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Siteid { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Clerkid { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Productid { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Accountid { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Amount { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Invoiceno { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Languageoption { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Responsecode { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pin { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Controlno { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Carriercontrolno { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Customerserviceno { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Transactiondatetime { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Resultcode { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Responsemessage { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Transactionid { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? H2hresultcode { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Esservicio { get; set; } = BoolCN.N;


        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }

        public DateTimeOffset? Transtimestamp { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Comision { get; set; } = 0m;


        [NotMapped]
        public string? Clave { get { return ""; } }

        [NotMapped]
        public string? Nombre { get { return ""; } }


    }
}

