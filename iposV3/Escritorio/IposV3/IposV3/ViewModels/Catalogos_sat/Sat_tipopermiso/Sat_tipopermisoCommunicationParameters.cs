
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_tipopermisoItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_tipopermisoItemVMInitialParameters() : base(0)
        {
        }

        public Sat_tipopermisoItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_tipopermisoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_tipopermisoListVMInitialParameters() : base(0)
        {
        }

        public Sat_tipopermisoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_tipopermisoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_tipopermisoListVMEventParameters() : base(false)
        { }

        public Sat_tipopermisoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_tipopermisoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
