
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class VehiculoItemVMInitialParameters : BaseCommonInitialParameters
    {

        public VehiculoItemVMInitialParameters() : base(0)
        {
        }

        public VehiculoItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class VehiculoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public VehiculoListVMInitialParameters() : base(0)
        {
        }

        public VehiculoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class VehiculoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public VehiculoListVMEventParameters() : base(false)
        { }

        public VehiculoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public VehiculoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
