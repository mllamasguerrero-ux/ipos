
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
    public class Sync_impo : EntityBaseExt
    {


        public Sync_impo() : base()
        {
        }

        public Sync_impo(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Sync_impo(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_largeLength)]
    public string? Archivolocal { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Archivoremoto { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Nombre { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Reenviado { get; set; } = BoolCN.N;

        [StringLength(Domains.ClaveLength)]
    public string? Sucursalorigenclave { get; set; }


    public long? Tipoimpoid { get; set; }
        [ForeignKey("Tipoimpoid")]
        public virtual Tipoimpo? Tipoimpo { get; set; }

        public long? Estatusimpoid { get; set; }

        [ForeignKey("Estatusimpoid")]
        public virtual Estatusimpo? Estatusimpo { get; set; }

        public DateTimeOffset? Fechahorarecepcion { get; set; }

    public DateTimeOffset? Fechahoraproceso { get; set; }

    public long? Sucursalorigenid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Sucursalorigenid")]
        public virtual Sucursal_info? Sucursalorigen { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


        public long? Clienteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clienteid")]
        public virtual Cliente? Cliente { get; set; }


        public long? Proveedorid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Proveedorid")]
        public virtual Proveedor? Proveedor { get; set; }


    }
}

