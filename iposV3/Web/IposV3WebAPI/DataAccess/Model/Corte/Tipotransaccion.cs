
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
    public class Tipotransaccion : EntityBaseCatalog
    {


        public Tipotransaccion() : base()
        {
        }





    public short? Sentidoinventario { get; set; }

    public short? Sentidopago { get; set; }


  }
}

