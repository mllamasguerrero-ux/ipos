
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class CambiocontrasenaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public CambiocontrasenaItemVMInitialParameters() : base(0)
        {
        }

        public CambiocontrasenaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class CambiocontrasenaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public CambiocontrasenaListVMInitialParameters() : base(0)
        {
        }

        public CambiocontrasenaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class CambiocontrasenaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public CambiocontrasenaListVMEventParameters() : base(false)
        { }

        public CambiocontrasenaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public CambiocontrasenaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
