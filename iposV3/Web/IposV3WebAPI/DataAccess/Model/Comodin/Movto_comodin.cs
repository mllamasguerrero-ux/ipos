
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
    public class Movto_comodin : EntityBaseExt
    {


        public Movto_comodin() : base()
        {
        }

        public Movto_comodin(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_comodin(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.Stdtext_largeLength)]
    public string? Descripcion1 { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Descripcion2 { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Descripcion3 { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Claveprod { get; set; }


        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


    }
}

