
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class CuentaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public CuentaItemVMInitialParameters() : base(0)
        {
        }

        public CuentaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class CuentaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public CuentaListVMInitialParameters() : base(0)
        {
        }

        public CuentaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class CuentaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public CuentaListVMEventParameters() : base(false)
        { }

        public CuentaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public CuentaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
