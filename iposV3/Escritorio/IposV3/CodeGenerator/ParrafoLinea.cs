using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class ParrafoLinea
    {
        public ParrafoLinea(int consecutivo, string? texto, string? orden, string? orden2, string? grupo, string? tab, string? grid, string? ordenar)
        {
            if (ordenar == null)
                throw new Exception("Se requiere el campo de ordenar");

            Consecutivo = consecutivo;
            Texto = texto;
            Orden = orden;


            var ordenarBuffer = ordenar.Split('_');
            Agrupador = ordenarBuffer.Length < 2 ? "NO" : (ordenarBuffer[1].Contains("AGRUPADOR") ? "SI" : "NO");
            Agrupador_inicio = ordenarBuffer.Length < 3 ? "NO" : (ordenarBuffer[2].Contains("INICIO") ? "SI" : "NO");
            Agrupador_fin = ordenarBuffer.Length < 3 ? "NO" : (ordenarBuffer[2].Contains("FIN") ? "SI" : "NO");
            Agrupador_tab_inicio = ordenarBuffer.Length < 3 ? "NO" : (ordenarBuffer[2].Contains("TABIN") ? "SI" : "NO");
            Agrupador_tab_fin = ordenarBuffer.Length < 3 ? "NO" : (ordenarBuffer[2].Contains("TABFI") ? "SI" : "NO");
            Agrupador_tabc_inicio = ordenarBuffer.Length < 3 ? "NO" : (ordenarBuffer[2].Contains("TABCIN") ? "SI" : "NO");
            Agrupador_tabc_fin = ordenarBuffer.Length < 3 ? "NO" : (ordenarBuffer[2].Contains("TABCFI") ? "SI" : "NO");
            Grupo = grupo;
            Tab = tab;

            Grid = grid;
            Agrupador_grid_inicio = ordenarBuffer.Length < 3 ? "NO" : (ordenarBuffer[2].Contains("GRIDIN") ? "SI" : "NO");
            Agrupador_grid_fin = ordenarBuffer.Length < 3 ? "NO" : (ordenarBuffer[2].Contains("GRIDFI") ? "SI" : "NO");


            Agrupador_siempre = ordenarBuffer.Length < 4 ? "NO" : (ordenarBuffer[3].Contains("SIEMPRE") ? "SI" : "NO");


        }



        public ParrafoLinea(ParrafoLinea copy)
        {
            Consecutivo = copy.Consecutivo;
            Texto = copy.Texto;
            Orden = copy.Orden;
            Orden2 = copy.Orden2;
            Agrupador = copy.Agrupador;
            Agrupador_inicio = copy.Agrupador_inicio;
            Agrupador_fin = copy.Agrupador_fin;
            Agrupador_tab_inicio = copy.Agrupador_tab_inicio;
            Agrupador_tab_fin = copy.Agrupador_tab_fin;
            Agrupador_tabc_inicio = copy.Agrupador_tabc_inicio;
            Agrupador_tabc_fin = copy.Agrupador_tabc_fin;
            Grupo = copy.Grupo;

            Grid = copy.Grid;
            Agrupador_grid_inicio = copy.Agrupador_grid_inicio;
            Agrupador_grid_fin = copy.Agrupador_grid_fin;

            Agrupador_siempre = copy.Agrupador_siempre;


        }

        public int Consecutivo { get; set; }
        public string? Texto { get; set; }
        public string? Orden { get; set; }
        public string? Orden2 { get; set; }



        public string? Agrupador { get; set; }

        public string? Agrupador_inicio { get; set; }
        public string? Agrupador_fin { get; set; }

        public string? Agrupador_tab_inicio { get; set; }
        public string? Agrupador_tab_fin { get; set; }
        public string? Agrupador_tabc_inicio { get; set; }
        public string? Agrupador_tabc_fin { get; set; }

        public string? Grupo { get; set; }
        public string? Tab { get; set; }


        public string? Grid { get; set; }
        public string? Agrupador_grid_inicio { get; set; }
        public string? Agrupador_grid_fin { get; set; }


        public string? Agrupador_siempre { get; set; } 



    }
}
