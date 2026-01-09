
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
    public class Usuario_fact_elect : EntityBaseExt
    {


        public Usuario_fact_elect() : base()
        {
        }

        public Usuario_fact_elect(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Usuario_fact_elect(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public long? Usuarioid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Usuarioid")]
        public virtual Usuario? Usuario { get; set; }



        public long? Sat_id_pais { get; set; }
        [ForeignKey("Sat_id_pais")]
        public virtual Sat_pais? Sat_pais { get; set; }





        public long? Sat_Coloniaid { get; set; }

        [ForeignKey("Sat_Coloniaid")]
        public virtual Sat_colonia? Sat_Colonia { get; set; }

        public long? Sat_Localidadid { get; set; }

        [ForeignKey("Sat_Localidadid")]
        public virtual Sat_localidad? Sat_Localidad { get; set; }

        public long? Sat_Municipioid { get; set; }

        [ForeignKey("Sat_Municipioid")]
        public virtual Sat_municipio? Sat_Municipio { get; set; }

        public long? Estadoid { get; set; }
        [ForeignKey("Estadoid")]
        public virtual Estadopais? Estado { get; set; }

        public string? Referenciadom { get; set; }






    }
}

