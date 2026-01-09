using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services
{
    public class MathIpos
    {

        public static bool Prorratear(decimal montoAProrratear, int numeroDecimales, ref List<Prorrateo> listaAProrratear)
        {
            var sumaRef = listaAProrratear.Select(y => y.Cantidad).Sum();

            var bufferMonto = 0m;
            var bufferMonto2 = 0m;

            for (int i = 0; i < listaAProrratear.Count; i++)
            {
                var prorrateo = listaAProrratear[i];

                if (bufferMonto >= montoAProrratear)
                {
                    prorrateo.CantidadProrrateada = 0;
                    continue;
                }


                if (i >= listaAProrratear.Count - 1)
                {
                    bufferMonto2 = montoAProrratear - bufferMonto;
                    if (bufferMonto2 >= 0)
                        prorrateo.CantidadProrrateada = bufferMonto2;
                    else
                        prorrateo.CantidadProrrateada = 0;
                }

                else
                {
                    bufferMonto2 = decimal.Round(montoAProrratear * (prorrateo.Cantidad / sumaRef), numeroDecimales);
                    if (bufferMonto2 + bufferMonto > montoAProrratear)
                        bufferMonto2 = montoAProrratear - bufferMonto;

                    prorrateo.CantidadProrrateada = bufferMonto2;
                }


                bufferMonto = bufferMonto + prorrateo.CantidadProrrateada;
            }

            return true;
        }

    }

    public class Prorrateo
    {
        public long Id { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CantidadProrrateada { get; set; }
    }
}
