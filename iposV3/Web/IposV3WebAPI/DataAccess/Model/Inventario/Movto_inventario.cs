
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
    public class Movto_inventario : EntityBaseExt
    {


        public Movto_inventario() : base()
        {
        }

        public Movto_inventario(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_inventario(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.LocalidadLength)]
    public string? Localidad { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Registroprocesosalida { get; set; } = BoolCN.N;


        public long? Tipodiferenciainventarioid { get; set; }
        [ForeignKey("Tipodiferenciainventarioid")]
        public virtual Tipodiferenciainventario? Tipodiferenciainventario { get; set; }

        public long? Anaquelid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Anaquelid")]
        public virtual Anaquel? Anaquel { get; set; }

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidad_real { get; set; } = 0m;


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidad_teorica { get; set; } = 0m;


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidad_diferencia { get; set; } = 0m;


  }
}

