
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
    internal class CustomQuerySet
    {
    }

    [NotMapped]
    [Keyless]
    public class SimpleLong
    {
        public long Val { get; set; }
    }

}
