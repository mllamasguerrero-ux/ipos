using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.BindingModel
{
    public delegate void AcceptPendingChangeHandler(
    object sender,
    AcceptPendingChangeEventArgs e);

    public interface IAcceptPendingChange
    {
        event AcceptPendingChangeHandler PendingChange;
    }

    public class AcceptPendingChangeEventArgs : EventArgs
    {

        public AcceptPendingChangeEventArgs(string propertyName, object newValue, object oldValue)
        {
            PropertyName = propertyName;
            NewValue = newValue;
            OldValue = oldValue;
            CancelPendingChange = false;
        }
        public string PropertyName { get; private set; }
        public object NewValue { get; private set; }
        public object OldValue { get; private set; }
        public bool CancelPendingChange { get; set; }
        // flesh this puppy out
    }
}
