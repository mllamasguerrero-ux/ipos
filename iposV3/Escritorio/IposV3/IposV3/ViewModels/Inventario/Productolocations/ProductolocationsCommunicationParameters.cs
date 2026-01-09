
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class ProductolocationsItemVMInitialParameters : BaseCommonInitialParameters
    {

        public ProductolocationsItemVMInitialParameters() : base(0)
        {
        }

        public ProductolocationsItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class ProductolocationsListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public ProductolocationsListVMInitialParameters() : base(0)
        {
        }

        public ProductolocationsListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class ProductolocationsListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public ProductolocationsListVMEventParameters() : base(false)
        { }

        public ProductolocationsListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public ProductolocationsListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
