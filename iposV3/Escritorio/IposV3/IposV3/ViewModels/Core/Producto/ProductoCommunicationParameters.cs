
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class ProductoItemVMInitialParameters : BaseCommonInitialParameters
    {

        public ProductoItemVMInitialParameters() : base(0)
        {
        }

        public ProductoItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class ProductoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public ProductoListVMInitialParameters() : base(0)
        {
        }

        public ProductoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class ProductoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public ProductoListVMEventParameters() : base(false)
        { }

        public ProductoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public ProductoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
