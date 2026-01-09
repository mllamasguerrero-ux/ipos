
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
    public class Tipodiferenciainventario : EntityBaseGenericCatalog
    {


        public Tipodiferenciainventario() : base()
        {
        }





    [StringLength(Domains.DescripcionLength)]
    public string? Descripcion { get; set; }


        //[StringLength(Domains.Stdtext_maxLength)]
        public string? Memo { get; set; }

    public long? Grupodiferenciainventarioid { get; set; }

        [ForeignKey("Grupodiferenciainventarioid")]
        public virtual Grupodiferenciainventario? Grupodiferenciainventario { get; set; }


    }
}

