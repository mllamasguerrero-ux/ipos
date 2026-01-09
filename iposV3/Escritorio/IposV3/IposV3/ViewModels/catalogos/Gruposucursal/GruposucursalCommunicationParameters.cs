
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class GruposucursalItemVMInitialParameters : BaseCommonInitialParameters
    {

        public GruposucursalItemVMInitialParameters() : base(0)
        {
        }

        public GruposucursalItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class GruposucursalListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public GruposucursalListVMInitialParameters() : base(0)
        {
        }

        public GruposucursalListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class GruposucursalListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public GruposucursalListVMEventParameters() : base(false)
        { }

        public GruposucursalListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public GruposucursalListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
