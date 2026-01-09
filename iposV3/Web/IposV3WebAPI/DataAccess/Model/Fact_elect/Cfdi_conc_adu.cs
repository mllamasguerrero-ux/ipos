
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
    public class Cfdi_conc_adu : EntityBaseExt
    {


        public Cfdi_conc_adu() : base()
        {
        }

        public Cfdi_conc_adu(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cfdi_conc_adu(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_64Length)]
    public string? Numero { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Aduana { get; set; }


    public DateTimeOffset? Fecha { get; set; }

    public long? Cfdi_conc_id { get; set; }
        [ForeignKey("EmpresaId, SucursalId,Cfdi_conc_id")]
        public virtual Cfdi_conc? Cfdi_conc { get; set; }


    }
}

