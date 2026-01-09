
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class CajaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public CajaItemVMInitialParameters() : base(0)
        {
        }

        public CajaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class CajaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public CajaListVMInitialParameters() : base(0)
        {
        }

        public CajaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class CajaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public CajaListVMEventParameters() : base(false)
        { }

        public CajaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public CajaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
