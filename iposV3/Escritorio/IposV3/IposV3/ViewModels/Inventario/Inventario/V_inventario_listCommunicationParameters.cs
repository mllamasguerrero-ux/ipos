
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class V_inventario_listItemVMInitialParameters : BaseCommonInitialParameters
    {

        public V_inventario_listItemVMInitialParameters() : base(0)
        {
        }

        public V_inventario_listItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class V_inventario_listVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public V_inventario_listVMInitialParameters() : base(0)
        {
        }

        public V_inventario_listVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class V_inventario_listVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public V_inventario_listVMEventParameters() : base(false)
        { }

        public V_inventario_listVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public V_inventario_listVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }


    public class V_inventario_fisicoUICommParams
    {
        public string Action { get; set; }
        public List<string> Parameters { get; set; }

        public V_inventario_fisicoUICommParams(string action, List<string> parameters)
        {
            Action = action;

            Parameters = parameters;
        }
    }



}
