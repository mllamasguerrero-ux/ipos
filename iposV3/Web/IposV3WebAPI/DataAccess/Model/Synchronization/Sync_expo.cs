
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
    public class Sync_expo : EntityBaseExt
    {


        public Sync_expo() : base()
        {
        }

        public Sync_expo(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Sync_expo(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
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
    public string? Sucursaldestinoclave { get; set; }


    public long? Tipoexpoid { get; set; }
        [ForeignKey("Tipoexpoid")]
        public virtual Tipoexpo? Tipoexpo { get; set; }

        public long? Estatusexpoid { get; set; }

        [ForeignKey("Estatusexpoid")]
        public virtual Estatusexpo? Estatusexpo { get; set; }

        public DateTimeOffset? Fechahoracreacion { get; set; }

    public DateTimeOffset? Fechahoraenvio { get; set; }

    public long? Sucursaldestinoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Sucursaldestinoid")]
        public virtual Sucursal_info? Sucursaldestino { get; set; }

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

