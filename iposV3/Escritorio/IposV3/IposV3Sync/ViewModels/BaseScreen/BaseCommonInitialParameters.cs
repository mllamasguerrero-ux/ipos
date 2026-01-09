using BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3Sync.ViewModels
{
    public class BaseCommonInitialParameters
    {


        public BaseCommonInitialParameters()
        {
        }
        public BaseCommonInitialParameters(long? Id)
        {
            this.Id = Id;
        }
        public long? Id { get; set; }


    }



    public class BaseListVMEventParameters : BaseCommonInitialParameters
    {

        public bool IsReloadEvent { get; set; }
        public bool HasMessage { get; set; }
        public MessageToUserSimple? MsgSimple { get; set; }
        public BaseListVMEventParameters(bool isReloadEvent) : base(0)
        {
            IsReloadEvent = isReloadEvent;
            HasMessage = false;
        }

        public BaseListVMEventParameters() : base(0)
        {

        }

        public void fillFields(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple)
        {

            IsReloadEvent = isReloadEvent;
            HasMessage = hasMessage;
            MsgSimple = msgSimple;
        }

        public BaseListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : this(isReloadEvent)
        {
            HasMessage = hasMessage;
            MsgSimple = msgSimple;
        }
    }
}
