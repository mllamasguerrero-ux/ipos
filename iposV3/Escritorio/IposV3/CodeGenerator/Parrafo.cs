using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class Parrafo
    {
        //public Parrafo(string parrafoId, string ordenar, int quitarChrFin)
        //{
        //    ParrafoId = parrafoId;
        //    Ordenar = ordenar;
        //    QuitarChrFin = quitarChrFin;
        //    ParrafoLineas = new List<ParrafoLinea>();
        //}

        public Parrafo(string? parrafoId, string? ordenar, int quitarChrFin)
        {

            if (ordenar == null)
                throw new Exception("Se requiere el campo de ordenar");

            ParrafoId = parrafoId;

            var ordenarBuffer = ordenar.Split('_');
            Ordenar = ordenarBuffer[0];
            Agrupado = ordenarBuffer.Length < 2 ? "NO" : (ordenarBuffer[1].Contains("AGRUPADO") ? "SI" : "NO");
            
            QuitarChrFin = quitarChrFin;
            ParrafoLineas = new List<ParrafoLinea>();
        }
        public string? ParrafoId { get; set; }
        public string? Ordenar { get; set; }


        public string? Agrupado { get; set; }


        public int QuitarChrFin { get; set; }

        public List<ParrafoLinea> ParrafoLineas { get; set; }
    }
}
