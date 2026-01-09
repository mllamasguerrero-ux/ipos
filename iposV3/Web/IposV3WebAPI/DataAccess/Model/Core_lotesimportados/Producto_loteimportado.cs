
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
    public class Producto_loteimportado : EntityBaseExt
    {


        public Producto_loteimportado() : base()
        {
        }

        public Producto_loteimportado(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_loteimportado(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        [Column(TypeName = "char(1)")]
        public BoolCN Loteimportadoaplicado { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Manejaloteimportado { get; set; } = BoolCN.N;


        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


    }
}

