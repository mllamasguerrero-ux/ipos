using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class ImplConf
    {
        public ImplConf()
        {

        }

        public ImplConf(
            string? Projecto,
            string? RutaBuffer,
            string? RutaProyecto,
            string? RutaRelativa,
            bool DefaultInsertarSiNoExiste,
            bool DefaultSobreEscribirSiExiste,
            bool DefaultAparecerComoOpcion,
            string? Section)
        {

            this.Projecto = Projecto;
            this.RutaBuffer = RutaBuffer;
            this.RutaProyecto = RutaProyecto;
            this.RutaRelativa = RutaRelativa;
            this.DefaultInsertarSiNoExiste = DefaultInsertarSiNoExiste;
            this.DefaultSobreEscribirSiExiste = DefaultSobreEscribirSiExiste;
            this.DefaultAparecerComoOpcion = DefaultAparecerComoOpcion;
            this.Section = Section;
        }


        public string? Tabla { get; set; }
        public string? Projecto { get; set; }
        public string? RutaBuffer { get; set; }
        public string? RutaProyecto { get; set; }
        public string? RutaRelativa { get; set; }

        public bool DefaultInsertarSiNoExiste { get; set; }
        public bool DefaultSobreEscribirSiExiste { get; set; }
        public bool DefaultAparecerComoOpcion { get; set; }

        public string? Section { get; set; }


    }


    public class ImplConfMisc
    {
        public ImplConfMisc()
        {

        }

        public ImplConfMisc(string? ArchivoMiscelanea, string? ArchivoRelacionado, string? ArchivoDestino, string? TextoUbicacion)
        {

            this.ArchivoMiscelanea = ArchivoMiscelanea;
            this.ArchivoRelacionado = ArchivoRelacionado;
            this.ArchivoDestino = ArchivoDestino;
            this.TextoUbicacion = TextoUbicacion;
    }

        public string? ArchivoMiscelanea { get; set; }
        public string? ArchivoRelacionado { get; set; }
        public string? ArchivoDestino { get; set; }
        public string? TextoUbicacion { get; set; }
    }
}
