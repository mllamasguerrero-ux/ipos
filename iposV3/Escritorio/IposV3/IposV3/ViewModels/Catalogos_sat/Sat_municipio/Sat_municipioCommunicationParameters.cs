
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_municipioItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_municipioItemVMInitialParameters() : base(0)
        {
        }

        public Sat_municipioItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_municipioListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_municipioListVMInitialParameters() : base(0)
        {
        }

        public Sat_municipioListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_municipioListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_municipioListVMEventParameters() : base(false)
        { }

        public Sat_municipioListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_municipioListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
