
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_localidadItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_localidadItemVMInitialParameters() : base(0)
        {
        }

        public Sat_localidadItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_localidadListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_localidadListVMInitialParameters() : base(0)
        {
        }

        public Sat_localidadListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_localidadListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_localidadListVMEventParameters() : base(false)
        { }

        public Sat_localidadListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_localidadListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
