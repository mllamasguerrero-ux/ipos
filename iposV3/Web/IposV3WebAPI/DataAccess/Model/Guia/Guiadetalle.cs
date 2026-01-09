
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
    public class Guiadetalle : EntityBaseExt
    {


        public Guiadetalle() : base()
        {
        }

        public Guiadetalle(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Guiadetalle(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Guiaid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Guiaid")]
        public virtual Guia? Guia { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public long? Estadoguiaid { get; set; }

        [ForeignKey(" Estadoguiaid")]
        public virtual Estadoguia? Estadoguia { get; set; }

        public DateTimeOffset? Fecharecibido { get; set; }

    public string? Fechahorarecibido { get; set; }

    public long? Personaidrecibio { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Personaidrecibio")]
        public virtual Usuario? Personarecibio { get; set; }


        public long? Cartaporteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Cartaporteid")]
        public virtual Cartaporte? Cartaporte { get; set; }

        public static void ConfigureEntity(EntityTypeBuilder<Guiadetalle> modelBuilder)
        {

        }



    }
}

