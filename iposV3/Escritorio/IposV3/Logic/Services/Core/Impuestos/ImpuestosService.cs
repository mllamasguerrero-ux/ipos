using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services
{
    public class ImpuestosService
    {
        public ImpuestosService() { }

        public void CalcularImpuestos(decimal tasaiva, decimal tasaieps, decimal cantidad,
                                      ref decimal? precioconimp, ref decimal? preciosinimp, ref decimal? total,
                                        out decimal? iva , out decimal? ieps, out decimal? subtotal )
        {

            iva = 0m;
            ieps = 0m;
            subtotal = 0m;

            decimal subtotalconiepssiniva = 0;

            if(cantidad == 0)
            {
                return;
                //throw new Exception("Error debe poner una cantidad mayor a cero");
            }


            if((precioconimp ?? 0m) !=  0m  || (total ?? 0m) != 0m )
            {


                if(total  ==  0 )
                    total = precioconimp * cantidad;
                

                subtotalconiepssiniva = decimal.Round((total!.Value / (1 + (tasaiva / 100m))), 2);
                iva = total - subtotalconiepssiniva;
                subtotal = decimal.Round((subtotalconiepssiniva / (1 + (tasaieps / 100m))), 2);
                ieps = subtotalconiepssiniva - subtotal;
                preciosinimp = decimal.Round(subtotal!.Value / cantidad, 4);

            }
            else
            {

                subtotal = decimal.Round(preciosinimp!.Value * cantidad, 2);
                ieps = decimal.Round(subtotal.Value * (tasaieps / 100m), 2);
                subtotalconiepssiniva = subtotal.Value + ieps.Value;
                iva = decimal.Round(subtotalconiepssiniva * (tasaiva/ 100m), 2);
                total = subtotal + iva + ieps;
                precioconimp = decimal.Round(total.Value / cantidad, 4);
            }

        }


    }
}
