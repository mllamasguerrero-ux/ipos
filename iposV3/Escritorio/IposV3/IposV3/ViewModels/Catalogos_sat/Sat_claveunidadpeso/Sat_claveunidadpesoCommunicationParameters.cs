
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_claveunidadpesoItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_claveunidadpesoItemVMInitialParameters() : base(0)
        {
        }

        public Sat_claveunidadpesoItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_claveunidadpesoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_claveunidadpesoListVMInitialParameters() : base(0)
        {
        }

        public Sat_claveunidadpesoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_claveunidadpesoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_claveunidadpesoListVMEventParameters() : base(false)
        { }

        public Sat_claveunidadpesoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_claveunidadpesoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
