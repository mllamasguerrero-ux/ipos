
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
    public class Lookup : EntityBaseExt
    {


        public Lookup() : base()
        {
        }

        public Lookup(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Lookup(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.ClaveLength)]
    public string? Clave { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nombre { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Campo1 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo2 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo3 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo4 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo5 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo6 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo7 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo8 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo9 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo10 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo11 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo12 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo13 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo14 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo15 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo16 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo17 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo18 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo19 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo20 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo21 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo22 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo23 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo24 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo25 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo26 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo27 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo28 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo29 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo30 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo31 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo32 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo33 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo34 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo35 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo36 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo37 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo38 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo39 { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Campo40 { get; set; } = BoolCN.N;

        [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo1 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo2 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo3 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo4 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo5 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo6 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo7 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo8 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo9 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo10 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo11 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo12 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo13 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo14 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo15 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo16 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo17 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo18 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo19 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo20 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo21 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo22 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo23 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo24 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo25 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo26 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo27 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo28 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo29 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo30 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo31 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo32 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo33 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo34 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo35 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo36 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo37 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo38 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo39 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Lbl_campo40 { get; set; }



  }
}

