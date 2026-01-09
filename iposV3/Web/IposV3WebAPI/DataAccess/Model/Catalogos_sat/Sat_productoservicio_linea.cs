
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
    public class Sat_productoservicio_linea : EntityBaseGenericPseudoCatalog
    {


        public Sat_productoservicio_linea() : base()
        {
        }



        //public long? Lineaid { get; set; }

        //[ForeignKey("EmpresaId, SucursalId, Lineaid")]
        //public virtual Linea? Linea { get; set; }



        public long? Sat_productoservicioid { get; set; }


        [ForeignKey("Sat_productoservicioid")]
        public virtual Sat_productoservicio? Sat_productoservicio { get; set; }


    }
}
