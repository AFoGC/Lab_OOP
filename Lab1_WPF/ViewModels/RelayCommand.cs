using System;
using System.Windows.Input;

namespace Lab1_WPF.ViewModels
{
    //Реалізація паттерну команда
    //інтерфейс ICommand береться з простору імен System.Windows.Input
    public class RelayCommand : ICommand
    {
        private Action<object> execute;         
        private Func<object, bool> canExecute;  


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
