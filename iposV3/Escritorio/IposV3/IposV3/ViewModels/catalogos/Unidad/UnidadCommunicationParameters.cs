
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class UnidadItemVMInitialParameters : BaseCommonInitialParameters
    {

        public UnidadItemVMInitialParameters() : base(0)
        {
        }

        public UnidadItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class UnidadListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public UnidadListVMInitialParameters() : base(0)
        {
        }

        public UnidadListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class UnidadListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public UnidadListVMEventParameters() : base(false)
        { }

        public UnidadListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public UnidadListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
