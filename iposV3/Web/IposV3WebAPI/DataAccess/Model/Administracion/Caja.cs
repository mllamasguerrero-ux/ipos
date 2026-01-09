
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
    public class Caja : EntityBaseExt
    {


        public Caja() : base()
        {
        }

        public Caja(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Caja(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [StringLength(Domains.ClaveLength)]
        public string Clave { get; set; } = "";

        [StringLength(Domains.NombreLength)]
        public string Nombre { get; set; } = "";

        [StringLength(Domains.DescripcionLength)]
        public string Descripcion { get; set; } = "";

        [StringLength(Domains.Stdtext_mediumLength)]
    public string? Nombreimpresora { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Impresoracomanda { get; set; }



        public virtual Caja_bancomer? Caja_bancomer { get; set; }
        public virtual Caja_emida? Caja_emida { get; set; }



    }
}

