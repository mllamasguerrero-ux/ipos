using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Utilerias.Respuestas.CatalogoSat
{
    public class CatalogoSatResponse<T>
    {
        private string message;

        private T data;

        public string Message { get => message; set => message = value; }
        public T Data { get => data; set => data = value; }
    }
}
