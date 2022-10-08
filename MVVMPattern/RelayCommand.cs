using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMPattern
{
    //Класс-шаблон для создания команд в архитектуре MVVM
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            //Метод подписывается на событие(связывается с делегатом)
            add => CommandManager.RequerySuggested += value;
            //Обратный случай
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> Execute, Func<object,bool> CanExecute = null)
        {
            //Проверка наличия определения действия на команду
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute)); //имя нулевого аргумента Execute
            canExecute = CanExecute;
        }

        //поля для записи делегатов
        private readonly Action<object> execute;
        private readonly Func<object,bool> canExecute;

        //Проверка canExecute на null с возвратом true (через оператор "??") 
        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => execute(parameter);
    }
}
