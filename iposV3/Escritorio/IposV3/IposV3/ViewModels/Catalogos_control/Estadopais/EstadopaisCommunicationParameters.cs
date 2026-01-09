
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class EstadopaisItemVMInitialParameters : BaseCommonInitialParameters
    {

        public EstadopaisItemVMInitialParameters() : base(0)
        {
        }

        public EstadopaisItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class EstadopaisListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public EstadopaisListVMInitialParameters() : base(0)
        {
        }

        public EstadopaisListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class EstadopaisListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public EstadopaisListVMEventParameters() : base(false)
        { }

        public EstadopaisListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public EstadopaisListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
