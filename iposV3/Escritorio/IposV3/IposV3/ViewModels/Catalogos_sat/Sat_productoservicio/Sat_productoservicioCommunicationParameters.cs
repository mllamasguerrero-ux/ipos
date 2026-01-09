
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_productoservicioItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_productoservicioItemVMInitialParameters() : base(0)
        {
        }

        public Sat_productoservicioItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_productoservicioListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_productoservicioListVMInitialParameters() : base(0)
        {
        }

        public Sat_productoservicioListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_productoservicioListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_productoservicioListVMEventParameters() : base(false)
        { }

        public Sat_productoservicioListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_productoservicioListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
