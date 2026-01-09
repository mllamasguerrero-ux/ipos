using BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.ViewModels.core.operaciones.puntocompra
{
    public class PuntoCompraUICommParams
    {
        public string Action { get; set; }
        public List<string> Parameters { get; set; }

        public PuntoCompraUICommParams(string action , List<string> parameters)
        {
            Action = action;

            Parameters = parameters;
        }
    }



    public class PuntoCompraListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public PuntoCompraListVMInitialParameters() : base(0)
        {
        }

        public PuntoCompraListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }



    public class PuntoCompraListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {


        public PuntoCompraListVMEventParameters() : base(false)
        { }

        public PuntoCompraListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public PuntoCompraListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent, hasMessage, msgSimple)
        { }
    }
}
