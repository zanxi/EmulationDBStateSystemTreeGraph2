using System;
using System.Windows.Input;

namespace WpfApp_10_ICommand
{
    // 2022.07.30 https://metanit.com/sharp/wpf/22.3.php
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value;  }
            remove { CommandManager.RequerySuggested -= value;  }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canexecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canexecute;                
        }

        public bool CanExecute(object parameter)
        {
            //return canExecute != null && canExecute(parameter);
            return canExecute == null ? true : canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
