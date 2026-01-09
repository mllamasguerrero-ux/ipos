
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
    public class Responsebancomer : EntityBaseExt
    {


        public Responsebancomer() : base()
        {
        }

        public Responsebancomer(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Responsebancomer(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.NombreLength)]
    public string? Codtransaction { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Terminal { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Session { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Secuencia { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Codigorespuesta { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Noautorizacion { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Afiliacion { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Filler1 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Importe { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Filler2 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tarjeta { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Cveoperador { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Filler3 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Folio { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Longleyenda { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Leyenda { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Referenciafinan { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Longemv { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Datosemv { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Longlealtad { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Datoslealtad { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Registro1 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Registro2 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Registro3 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Registro4 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Registro5 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Longmultipagos { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Multipagos { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Longdatoscifrados { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Datoscifrados { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Longcampana { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Datoscampana { get; set; }



    public long? Idencabezado { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Idencabezado")]
        public virtual Encabezadoresponsebancomer? Encabezado { get; set; }


    }
}

