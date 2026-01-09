
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class VendedorItemVMInitialParameters : BaseCommonInitialParameters
    {

        public VendedorItemVMInitialParameters() : base(0)
        {
        }

        public VendedorItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class VendedorListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public VendedorListVMInitialParameters() : base(0)
        {
        }

        public VendedorListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class VendedorListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public VendedorListVMEventParameters() : base(false)
        { }

        public VendedorListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public VendedorListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
