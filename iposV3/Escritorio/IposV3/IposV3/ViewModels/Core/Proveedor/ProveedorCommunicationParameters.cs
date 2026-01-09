
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class ProveedorItemVMInitialParameters : BaseCommonInitialParameters
    {

        public ProveedorItemVMInitialParameters() : base(0)
        {
        }

        public ProveedorItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class ProveedorListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public ProveedorListVMInitialParameters() : base(0)
        {
        }

        public ProveedorListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class ProveedorListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public ProveedorListVMEventParameters() : base(false)
        { }

        public ProveedorListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public ProveedorListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
