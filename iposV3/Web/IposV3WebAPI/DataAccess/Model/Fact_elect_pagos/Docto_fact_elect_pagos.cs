
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
    public class Docto_fact_elect_pagos : EntityBaseExt
    {


        public Docto_fact_elect_pagos() : base()
        {
        }

        public Docto_fact_elect_pagos(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_fact_elect_pagos(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_shortLength)]
    public string? Timbradoformapagosat { get; set; }


    public long? Doctopagosat { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctopagosat")]
        public virtual Pagodoctosat? Doctopagosat_ { get; set; }

        public long? Pagosat { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Pagosat")]
        public virtual Pagosat? Pagosat_ { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

