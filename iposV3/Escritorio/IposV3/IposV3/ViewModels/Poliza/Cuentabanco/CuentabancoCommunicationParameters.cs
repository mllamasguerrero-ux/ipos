
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class CuentabancoItemVMInitialParameters : BaseCommonInitialParameters
    {

        public CuentabancoItemVMInitialParameters() : base(0)
        {
        }

        public CuentabancoItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class CuentabancoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public CuentabancoListVMInitialParameters() : base(0)
        {
        }

        public CuentabancoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class CuentabancoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public CuentabancoListVMEventParameters() : base(false)
        { }

        public CuentabancoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public CuentabancoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
