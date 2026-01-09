
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace BindingModels
{
    [XmlRoot]
    public class ParametroBindingModel: ParametroBindingModelGenerated
    {

        public List<CampoEnLista>? CamposEnListaProductos { get; set; }
        public List<CampoEnLista>? CamposEnListaVerificador { get; set; }

        public ComisionporlistaBindingModel? Comisionporlista { get; set; }

        public ParametroBindingModel():base()
        {
        }
        
        #if PROYECTO_WEB
        public ParametroBindingModel(Parametro item):base(item)
        {
        }
        #endif

      

    }

    public enum TipoListado
    {
        Producto,
        Verificador,
        Otro
    }

    public class CampoEnLista
    {
        public int Index { get; set; }

        public bool Campo { get; set; } 
        public string? Lbl_campo { get; set; }
        public string? DescripcionSistema { get; set; }

        public static readonly List<string> _descripcionSistemaProductos =
                new List<string>(new[]
                {
                    "Clave",
"Descripcion1",
"Descripcion2",
"Texto 1",
"Texto 2",
"Texto 3",
"Texto 4",
"Texto 5",
"Texto 6",
"Numero 1",
"Numero 2",
"Numero 3",
"Numero 4",
"Precio 1",
"Precio 2",
"Precio 3",
"Precio 4",
"Precio 5",
"Precio 1 + IMP",
"Precio 2 + IMP",
"Precio 3 + IMP",
"Precio 4 + IMP",
"Precio 5 + IMP",
"Precio caja",
"Tasa Iva",
"Limite Precio 2",
"Codigo barras",
"Existencia",
"Apartados",
"En proceso",
"Tasa Ieps",
"Desglose almacenes",
"Precio medio mayoreo con impuesto y comision tarjeta",
"Precio mayoreo con impuesto y comision tarjeta",
"Unidad de empaque",
"Pieza / Caja",
"Modo alerta en punto de venta",
"% utilidad en listado"
                });


        private static readonly List<string> _descripcionSistemaVerificador =
                new List<string>(new[]
                {
"Precio 1",
"Precio 2",
"Precio 3",
"Precio 4",
"Precio 5",
"Precio 1 + IMP",
"Precio 2 + IMP",
"Precio 4 + IMP",
"Precio 5 + IMP",
"Precio caja",
"Tasa Sugerido"
                });


        public CampoEnLista()
        {

        }


        public CampoEnLista(int index, bool campo, string? lbl_campo, string descripcionSistema)
        {
            Index = index;
            Campo = campo;
            Lbl_campo = lbl_campo;
            DescripcionSistema = descripcionSistema;
        }

        public CampoEnLista(int index, bool campo, string? lbl_campo, TipoListado tipoListado = TipoListado.Producto)
        {
            Index = index;
            Campo = campo;
            Lbl_campo = lbl_campo;

            switch(tipoListado)
            {
                case TipoListado.Producto:
                    {
                        DescripcionSistema = _descripcionSistemaProductos.Count() >= index ? _descripcionSistemaProductos[index - 1] : "";
                        break;
                    }

                case TipoListado.Verificador:
                    {
                        DescripcionSistema = _descripcionSistemaVerificador.Count() >= index ? _descripcionSistemaVerificador[index - 1] : "";
                        break;
                    }

                default:
                    DescripcionSistema =  "";
                    break;
            }

        }

        public CampoEnLista(int index, TipoListado tipoListado = TipoListado.Producto) :this(index, false, null, tipoListado)
        {
        }

        public static List<CampoEnLista> CrearListadoVacio(TipoListado tipoListado = TipoListado.Producto)
        {
            var listado = new List<CampoEnLista>();

            if (tipoListado == TipoListado.Producto)
            {
                listado.Add(new CampoEnLista(1, true, "Clave", tipoListado));
                listado.Add(new CampoEnLista(2, true, "Descripcion", tipoListado));
            }
            else
            {
                listado.Add(new CampoEnLista(1, tipoListado));
                listado.Add(new CampoEnLista(2, tipoListado));
            }

            listado.Add(new CampoEnLista(3, tipoListado));
            listado.Add(new CampoEnLista(4, tipoListado));
            listado.Add(new CampoEnLista(5, tipoListado));
            listado.Add(new CampoEnLista(6, tipoListado));
            listado.Add(new CampoEnLista(7, tipoListado));
            listado.Add(new CampoEnLista(8, tipoListado));
            listado.Add(new CampoEnLista(9, tipoListado));
            listado.Add(new CampoEnLista(10, tipoListado));
            listado.Add(new CampoEnLista(11, tipoListado));
            listado.Add(new CampoEnLista(12, tipoListado));
            listado.Add(new CampoEnLista(13, tipoListado));
            listado.Add(new CampoEnLista(14, tipoListado));
            listado.Add(new CampoEnLista(15, tipoListado));
            listado.Add(new CampoEnLista(16, tipoListado));
            listado.Add(new CampoEnLista(17, tipoListado));
            listado.Add(new CampoEnLista(18, tipoListado));
            listado.Add(new CampoEnLista(19, tipoListado));
            listado.Add(new CampoEnLista(20, tipoListado));
            listado.Add(new CampoEnLista(21, tipoListado));
            listado.Add(new CampoEnLista(22, tipoListado));
            listado.Add(new CampoEnLista(23, tipoListado));
            listado.Add(new CampoEnLista(24, tipoListado));
            listado.Add(new CampoEnLista(25, tipoListado));
            listado.Add(new CampoEnLista(26, tipoListado));
            listado.Add(new CampoEnLista(27, tipoListado));
            listado.Add(new CampoEnLista(28, tipoListado));
            listado.Add(new CampoEnLista(29, tipoListado));
            listado.Add(new CampoEnLista(30, tipoListado));
            listado.Add(new CampoEnLista(31, tipoListado));
            listado.Add(new CampoEnLista(32, tipoListado));
            listado.Add(new CampoEnLista(33, tipoListado));
            listado.Add(new CampoEnLista(34, tipoListado));
            listado.Add(new CampoEnLista(35, tipoListado));
            listado.Add(new CampoEnLista(36, tipoListado));
            listado.Add(new CampoEnLista(37, tipoListado));
            listado.Add(new CampoEnLista(38, tipoListado));
            listado.Add(new CampoEnLista(39, tipoListado));
            listado.Add(new CampoEnLista(40, tipoListado));

            return listado;
        }



#if PROYECTO_WEB
        public static List<CampoEnLista> CrearListadoDesdeLookup(Lookup record)
        {
            var listado = new List<CampoEnLista>();

            listado.Add(new CampoEnLista(1, record.Campo1 == BoolCN.S, record.Lbl_campo1));
            listado.Add(new CampoEnLista(2, record.Campo2 == BoolCN.S, record.Lbl_campo2));
            listado.Add(new CampoEnLista(3, record.Campo3 == BoolCN.S, record.Lbl_campo3));
            listado.Add(new CampoEnLista(4, record.Campo4 == BoolCN.S, record.Lbl_campo4));
            listado.Add(new CampoEnLista(5, record.Campo5 == BoolCN.S, record.Lbl_campo5));
            listado.Add(new CampoEnLista(6, record.Campo6 == BoolCN.S, record.Lbl_campo6));
            listado.Add(new CampoEnLista(7, record.Campo7 == BoolCN.S, record.Lbl_campo7));
            listado.Add(new CampoEnLista(8, record.Campo8 == BoolCN.S, record.Lbl_campo8));
            listado.Add(new CampoEnLista(9, record.Campo9 == BoolCN.S, record.Lbl_campo9));
            listado.Add(new CampoEnLista(10, record.Campo10 == BoolCN.S, record.Lbl_campo10));
            listado.Add(new CampoEnLista(11, record.Campo11 == BoolCN.S, record.Lbl_campo11));
            listado.Add(new CampoEnLista(12, record.Campo12 == BoolCN.S, record.Lbl_campo12));
            listado.Add(new CampoEnLista(13, record.Campo13 == BoolCN.S, record.Lbl_campo13));
            listado.Add(new CampoEnLista(14, record.Campo14 == BoolCN.S, record.Lbl_campo14));
            listado.Add(new CampoEnLista(15, record.Campo15 == BoolCN.S, record.Lbl_campo15));
            listado.Add(new CampoEnLista(16, record.Campo16 == BoolCN.S, record.Lbl_campo16));
            listado.Add(new CampoEnLista(17, record.Campo17 == BoolCN.S, record.Lbl_campo17));
            listado.Add(new CampoEnLista(18, record.Campo18 == BoolCN.S, record.Lbl_campo18));
            listado.Add(new CampoEnLista(19, record.Campo19 == BoolCN.S, record.Lbl_campo19));
            listado.Add(new CampoEnLista(20, record.Campo20 == BoolCN.S, record.Lbl_campo20));
            listado.Add(new CampoEnLista(21, record.Campo21 == BoolCN.S, record.Lbl_campo21));
            listado.Add(new CampoEnLista(22, record.Campo22 == BoolCN.S, record.Lbl_campo22));
            listado.Add(new CampoEnLista(23, record.Campo23 == BoolCN.S, record.Lbl_campo23));
            listado.Add(new CampoEnLista(24, record.Campo24 == BoolCN.S, record.Lbl_campo24));
            listado.Add(new CampoEnLista(25, record.Campo25 == BoolCN.S, record.Lbl_campo25));
            listado.Add(new CampoEnLista(26, record.Campo26 == BoolCN.S, record.Lbl_campo26));
            listado.Add(new CampoEnLista(27, record.Campo27 == BoolCN.S, record.Lbl_campo27));
            listado.Add(new CampoEnLista(28, record.Campo28 == BoolCN.S, record.Lbl_campo28));
            listado.Add(new CampoEnLista(29, record.Campo29 == BoolCN.S, record.Lbl_campo29));
            listado.Add(new CampoEnLista(30, record.Campo30 == BoolCN.S, record.Lbl_campo30));
            listado.Add(new CampoEnLista(31, record.Campo31 == BoolCN.S, record.Lbl_campo31));
            listado.Add(new CampoEnLista(32, record.Campo32 == BoolCN.S, record.Lbl_campo32));
            listado.Add(new CampoEnLista(33, record.Campo33 == BoolCN.S, record.Lbl_campo33));
            listado.Add(new CampoEnLista(34, record.Campo34 == BoolCN.S, record.Lbl_campo34));
            listado.Add(new CampoEnLista(35, record.Campo35 == BoolCN.S, record.Lbl_campo35));
            listado.Add(new CampoEnLista(36, record.Campo36 == BoolCN.S, record.Lbl_campo36));
            listado.Add(new CampoEnLista(37, record.Campo37 == BoolCN.S, record.Lbl_campo37));
            listado.Add(new CampoEnLista(38, record.Campo38 == BoolCN.S, record.Lbl_campo38));
            listado.Add(new CampoEnLista(39, record.Campo39 == BoolCN.S, record.Lbl_campo39));
            listado.Add(new CampoEnLista(40, record.Campo40 == BoolCN.S, record.Lbl_campo40));

            return listado;

        }

        public static void LlenarLookupDesdeListado(List<CampoEnLista> listado, ref Lookup record)
        {
            var buffer = listado.FirstOrDefault(y => y.Index == 1);
            if (buffer != null) { record.Campo1 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo1 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 2);
            if (buffer != null) { record.Campo2 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo2 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 3);
            if (buffer != null) { record.Campo3 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo3 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 4);
            if (buffer != null) { record.Campo4 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo4 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 5);
            if (buffer != null) { record.Campo5 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo5 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 6);
            if (buffer != null) { record.Campo6 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo6 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 7);
            if (buffer != null) { record.Campo7 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo7 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 8);
            if (buffer != null) { record.Campo8 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo8 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 9);
            if (buffer != null) { record.Campo9 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo9 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 10);
            if (buffer != null) { record.Campo10 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo10 = buffer.Lbl_campo; }

            buffer = listado.FirstOrDefault(y => y.Index == 11);
            if (buffer != null) { record.Campo11 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo11 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 12);
            if (buffer != null) { record.Campo12 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo12 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 13);
            if (buffer != null) { record.Campo13 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo13 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 14);
            if (buffer != null) { record.Campo14 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo14 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 15);
            if (buffer != null) { record.Campo15 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo15 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 16);
            if (buffer != null) { record.Campo16 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo16 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 17);
            if (buffer != null) { record.Campo17 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo17 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 18);
            if (buffer != null) { record.Campo18 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo18 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 19);
            if (buffer != null) { record.Campo19 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo19 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 20);
            if (buffer != null) { record.Campo20 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo20 = buffer.Lbl_campo; }

            buffer = listado.FirstOrDefault(y => y.Index == 21);
            if (buffer != null) { record.Campo21 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo21 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 22);
            if (buffer != null) { record.Campo22 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo22 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 23);
            if (buffer != null) { record.Campo23 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo23 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 24);
            if (buffer != null) { record.Campo24 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo24 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 25);
            if (buffer != null) { record.Campo25 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo25 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 26);
            if (buffer != null) { record.Campo26 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo26 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 27);
            if (buffer != null) { record.Campo27 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo27 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 28);
            if (buffer != null) { record.Campo28 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo28 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 29);
            if (buffer != null) { record.Campo29 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo29 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 30);
            if (buffer != null) { record.Campo30 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo30 = buffer.Lbl_campo; }

            buffer = listado.FirstOrDefault(y => y.Index == 31);
            if (buffer != null) { record.Campo31 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo31 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 32);
            if (buffer != null) { record.Campo32 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo32 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 33);
            if (buffer != null) { record.Campo33 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo33 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 34);
            if (buffer != null) { record.Campo34 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo34 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 35);
            if (buffer != null) { record.Campo35 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo35 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 36);
            if (buffer != null) { record.Campo36 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo36 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 37);
            if (buffer != null) { record.Campo37 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo37 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 38);
            if (buffer != null) { record.Campo38 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo38 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 39);
            if (buffer != null) { record.Campo39 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo39 = buffer.Lbl_campo; }
            buffer = listado.FirstOrDefault(y => y.Index == 40);
            if (buffer != null) { record.Campo40 = buffer.Campo ? BoolCN.S : BoolCN.N; record.Lbl_campo40 = buffer.Lbl_campo; }


        }
#endif


    }
}

