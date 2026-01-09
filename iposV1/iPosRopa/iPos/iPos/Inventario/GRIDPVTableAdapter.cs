using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPos.Inventario.DSInventarioFisico3TableAdapters
{
    public partial class GRIDPVTableAdapter
    {
        

        public int SelectCommandTimeout
        {
            get
            {
                return this.CommandCollection[0].CommandTimeout;
            }
            set
            {
                this.CommandCollection[0].CommandTimeout = value;
               
            }
        }
    }
}
