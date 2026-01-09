
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
    public class Emidaproduct : EntityBaseExt
    {


        public Emidaproduct() : base()
        {
        }

        public Emidaproduct(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Emidaproduct(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.NombreLength)]
    public string? Productid { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Description { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Shortdescription { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Amount { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Carrierid { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Categoryid { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Transtipoid { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Currencycode { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Currencysymbol { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Discountrate { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? H2hresultcode { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Reference { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN? Esservicio { get; set; }





        [NotMapped]
        public string Clave
        {
            get { return Shortdescription ?? ""; }
            set { Shortdescription = value; }
        }
        [NotMapped]
        public string Nombre
        {
            get { return Description ?? "";  }
            set { Description = value; }
        }

    }
}

