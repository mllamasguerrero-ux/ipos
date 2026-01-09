using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input; 

namespace Controllers.BindingModel.Menu
{

    public class RelayCommand : ICommand
    {
        private readonly Action<object?>? execute;
        private readonly Predicate<object?>? canExecute;

        public RelayCommand(Action<object?>? execute, Predicate<object?>? canExecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public void Execute(object? parameter)
        {
            if(execute != null)
                execute(parameter);
        }

        public bool CanExecute(object? parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
