using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services
{

    public class Movto_command_deciphered
    {
        public bool Preguntacantidad { get; set; } = false;

        public bool Esean { get; set; }

        public bool Esempaque { get; set; }

        public bool Escaja { get; set; }

        public bool Tieneprefijobascula { get; set; }

        public decimal Cantidadaux { get; set; } = 0m;

        public long? Productoid { get; set; }

        public decimal Cantidad { get; set; } = 0m;

        public string? Usermessage { get; set; }



    }


}
