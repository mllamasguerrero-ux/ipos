
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class CamporeferenciaprecioItemVMInitialParameters : BaseCommonInitialParameters
    {

        public CamporeferenciaprecioItemVMInitialParameters() : base(0)
        {
        }

        public CamporeferenciaprecioItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class CamporeferenciaprecioListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public CamporeferenciaprecioListVMInitialParameters() : base(0)
        {
        }

        public CamporeferenciaprecioListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class CamporeferenciaprecioListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public CamporeferenciaprecioListVMEventParameters() : base(false)
        { }

        public CamporeferenciaprecioListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public CamporeferenciaprecioListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
