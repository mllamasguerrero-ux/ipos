using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.DataAccess.PostgreSQL
{
    public class SpecialMigrationProcess
    {

        public static string UpdateCMX()
        {
            return $@"do $$ 
<<cmx_block>>
declare
begin

   update ""Sat_codigopostal""
   set ""Sat_estado"" = 'CMX'
   where ""Sat_estado"" = 'DIF';


   update ""Sat_localidad""
   set ""Clave_estado"" = 'CMX'
   where ""Clave_estado"" = 'DIF';


   update ""Sat_municipio""
   set ""Clave_estado"" = 'CMX'
   where ""Clave_estado"" = 'DIF';


end cmx_block $$;";
        }
    }
}
