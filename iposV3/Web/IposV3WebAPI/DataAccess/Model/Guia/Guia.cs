
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Guia : EntityBaseExt
    {


        public Guia() : base()
        {
        }

        public Guia(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Guia(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }




    [StringLength(Domains.DescripcionLength)]
    public string? Nota { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Guiapaqueteria { get; set; }


    public int? Folio { get; set; }

    public long? Encargadoguiaid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Encargadoguiaid")]
        public virtual Usuario? Encargadoguia { get; set; }

        public long? Estadoguiaid { get; set; }

        [ForeignKey(" Estadoguiaid")]
        public virtual Estadoguia? Estadoguia { get; set; }

        public long? Cajeroid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Cajeroid")]
        public virtual Usuario? Cajero { get; set; }

        public long? Corteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Corteid")]
        public virtual Corte? Corte { get; set; }

        public DateTimeOffset? Fecha { get; set; }

    public DateTimeOffset? Fechahora { get; set; }

        public long? Tipoentregaid { get; set; }
        [ForeignKey("Tipoentregaid")]
        public virtual Tipoentrega? Tipoentrega { get; set; }



        public long? Vehiculoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Vehiculoid")]
        public virtual Vehiculo? Vehiculo { get; set; }

        public DateTimeOffset? Fechaestimadarec { get; set; }

        public DateTimeOffset? Horaestimadrec { get; set; }




        [NotMapped]
        public string? Clave { get { return ""; } set { } }

        [NotMapped]
        public string? Nombre { get { return ""; } set { } }


        public static void ConfigureEntity(EntityTypeBuilder<Guia> modelBuilder)
        {

        }

    }
}

