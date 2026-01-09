
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
    public class Plazo : EntityBaseExt
    {


        public Plazo() : base()
        {
        }

        public Plazo(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Plazo(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Clave { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nombre { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Comisionista { get; set; } = BoolCN.N;

        [StringLength(Domains.Stdtext_largeLength)]
    public string? Leyenda { get; set; }


    public int? Dias { get; set; }


        public long? Almacenid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Almacenid")]
        public virtual Almacen? Almacen { get; set; }


    }
}

