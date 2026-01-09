using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosReporting
{
    public class ConnectionReload
    {
        public static void reloadConnections()
        {
            
            iPosReporting.Properties.Settings.Default.Reload();
        }
    }
}
