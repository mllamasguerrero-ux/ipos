
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class ListaprecioItemVMInitialParameters : BaseCommonInitialParameters
    {

        public ListaprecioItemVMInitialParameters() : base(0)
        {
        }

        public ListaprecioItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class ListaprecioListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public ListaprecioListVMInitialParameters() : base(0)
        {
        }

        public ListaprecioListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class ListaprecioListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public ListaprecioListVMEventParameters() : base(false)
        { }

        public ListaprecioListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public ListaprecioListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
