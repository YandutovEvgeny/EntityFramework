using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantEntity.Models
{
    class Commands : ICommand
    {
        public event EventHandler CanExecuteChanged //Делегат
        {
            //Мы в делегат можем либо добавить метод, либо удалить метод
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        Action _action;
        Func<bool> _canExecute;

        public Commands(Action action, Func<bool> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
