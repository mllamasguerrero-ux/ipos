
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
    public class Zebraconfig : EntityBaseExt
    {


        public Zebraconfig() : base()
        {
        }

        public Zebraconfig(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Zebraconfig(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ZebraConfigLength)]
    public string? A1_x_position { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? A2_y_position { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? A3_rotation { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? A4_font_selection { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? A5_x_multiplier { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? A6_y_multiplier { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? A7_reverseimage { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? B1_x_position { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? B2_y_position { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? B3_rotation { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? B4_barcode_selection { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? B5_narrowbarwidth { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? B6_widebarwidth { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? B7_barcodeheight { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? B8_printhumanreadable { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? Q_labelwidth { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? Q_formlength_1 { get; set; }

        [StringLength(Domains.ZebraConfigLength)]
        public string? Q_formlength_2 { get; set; }



  }
}

