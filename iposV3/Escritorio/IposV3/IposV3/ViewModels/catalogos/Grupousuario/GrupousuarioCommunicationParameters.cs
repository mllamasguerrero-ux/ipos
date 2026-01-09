
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class GrupousuarioItemVMInitialParameters : BaseCommonInitialParameters
    {

        public GrupousuarioItemVMInitialParameters() : base(0)
        {
        }

        public GrupousuarioItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class GrupousuarioListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public GrupousuarioListVMInitialParameters() : base(0)
        {
        }

        public GrupousuarioListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class GrupousuarioListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public GrupousuarioListVMEventParameters() : base(false)
        { }

        public GrupousuarioListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public GrupousuarioListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
