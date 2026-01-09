
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
    public class Encabezadoresponsebancomer : EntityBaseExt
    {


        public Encabezadoresponsebancomer() : base()
        {
        }

        public Encabezadoresponsebancomer(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Encabezadoresponsebancomer(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.NombreLength)]
    public string? Encabezadoip { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Mensaje { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipomensaje { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Idsandf { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Idsecuencial { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Direccionip { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Encabezadoversion { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Macaddress { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Versiondll { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Conectadopinpad { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Usopinpad { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Longsebehpos { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Macaddalternativa { get; set; }
        
        [Column(TypeName = "char(1)")]
        public BoolCN Pinpaddetectado { get; set; } = BoolCN.N;

        [StringLength(Domains.NombreLength)]
    public string? Qpsenlongmacadd { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Telecargapinpad { get; set; }



  }
}

