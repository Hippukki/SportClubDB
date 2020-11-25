using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportClubDB
{
    public class Command<T> : ICommand
    {
        Func<T> func;
        Func<T, int> func2;
        
        public Command( Func<T> func, Func<T, int> func2)
        {
            this.func = func;
            this.func2 = func2;
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            T p = (T)parameter;
            if (parameter == null)
                func();
            else
                func2(p);
        }
    }
}
