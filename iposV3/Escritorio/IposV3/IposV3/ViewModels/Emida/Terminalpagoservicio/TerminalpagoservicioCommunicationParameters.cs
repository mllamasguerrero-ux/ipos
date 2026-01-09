
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class TerminalpagoservicioItemVMInitialParameters : BaseCommonInitialParameters
    {

        public TerminalpagoservicioItemVMInitialParameters() : base(0)
        {
        }

        public TerminalpagoservicioItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class TerminalpagoservicioListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public TerminalpagoservicioListVMInitialParameters() : base(0)
        {
        }

        public TerminalpagoservicioListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class TerminalpagoservicioListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public TerminalpagoservicioListVMEventParameters() : base(false)
        { }

        public TerminalpagoservicioListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public TerminalpagoservicioListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
