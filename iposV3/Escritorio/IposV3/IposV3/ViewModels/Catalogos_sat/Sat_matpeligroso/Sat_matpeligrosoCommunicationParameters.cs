
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_matpeligrosoItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_matpeligrosoItemVMInitialParameters() : base(0)
        {
        }

        public Sat_matpeligrosoItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_matpeligrosoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_matpeligrosoListVMInitialParameters() : base(0)
        {
        }

        public Sat_matpeligrosoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_matpeligrosoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_matpeligrosoListVMEventParameters() : base(false)
        { }

        public Sat_matpeligrosoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_matpeligrosoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
