
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
    public class Docto_traslado : EntityBaseExt
    {


        public Docto_traslado() : base()
        {
        }

        public Docto_traslado(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_traslado(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_shortLength)]
    public string? Foliosolicitudmercancia { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Foliotrasladooriginal { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN? Estraslado { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN? Esdevolucion { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Foliodevolucion { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Essurtimientomerca { get; set; }


    public long? Sucursaltid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Sucursaltid")]
        public virtual Sucursal_info? Sucursalt { get; set; }

        public long? Almacentid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Almacentid")]
        public virtual Almacen? Almacen { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public long? Doctoimportadoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoimportadoid")]
        public virtual Docto? Doctoimportado { get; set; }

        public long? Idsolicitudmercancia { get; set; }

    public long? Idtrasladooriginal { get; set; }

    public long? Iddevolucion { get; set; }


  }
}

