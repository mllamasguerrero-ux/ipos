
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
    public class Requestbancomer : EntityBaseExt
    {


        public Requestbancomer() : base()
        {
        }

        public Requestbancomer(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Requestbancomer(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Issintjroperador { get; set; } = BoolCN.N;

    [StringLength(Domains.NombreLength)]
    public string? Nomautorizacion { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nombre { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pan { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Toperador { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Codtransaction { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Terminal { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Session { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Secuencia { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Importe { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Propina { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Folio { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Capemv { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipolector { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Capcvv2 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Mesesfin { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Parcializacion { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Promociones { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipomoneda { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Noautorizacion { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Modoingreso { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Cvv2 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Track2 { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nosecuencia { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Importecash { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Fechahoracomercio { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Referenciacomercio { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Otroimporte { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Claveoperador { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Afiliacion { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Numerocuarto { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Referenciafinanciera { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Codigocondchip { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Longemvfull { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Datosemvfull { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Longlealtad { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Datoslealtad { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Longmultipagos { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Datosmultipagos { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Longdatoscifrados { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Datoscifrados { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Longcampana { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Datoscampana { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Conveniocie { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Version { get; set; }



  }
}

