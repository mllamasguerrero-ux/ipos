
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_tipoembalajeItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_tipoembalajeItemVMInitialParameters() : base(0)
        {
        }

        public Sat_tipoembalajeItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_tipoembalajeListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_tipoembalajeListVMInitialParameters() : base(0)
        {
        }

        public Sat_tipoembalajeListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_tipoembalajeListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_tipoembalajeListVMEventParameters() : base(false)
        { }

        public Sat_tipoembalajeListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_tipoembalajeListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
