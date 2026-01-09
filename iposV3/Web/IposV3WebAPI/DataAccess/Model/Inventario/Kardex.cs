
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
    public class Kardex : EntityBaseExt
    {


        public Kardex() : base()
        {
        }

        public Kardex(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Kardex(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.LoteLength)]
    public string? Lote { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Esapartado { get; set; } = BoolCN.N;


        public long? Tipodoctoid { get; set; }
        [ForeignKey("Tipodoctoid")]
        public virtual Tipodocto? Tipodocto { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }

        public DateTimeOffset? Fecha { get; set; }

    public DateTimeOffset? Fechahora { get; set; }

        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidad { get; set; } = 0m;

    public DateTimeOffset? Fechavence { get; set; }

    public long? Loteimportado { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Loteimportado")]
        public virtual Lotesimportados? Loteimportado_ { get; set; }

        public long? Almacenid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Almacenid")]
        public virtual Almacen? Almacen { get; set; }

        public long? Origenfiscalid { get; set; }
        [ForeignKey("Origenfiscalid")]
        public virtual Origenfiscal? Origenfiscal { get; set; }


    }
}

