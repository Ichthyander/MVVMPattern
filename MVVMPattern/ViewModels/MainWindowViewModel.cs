using MVVMPattern.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMPattern.ViewModels
{
    //Реализация INotifyPropertyChanged позволяет связать свойства ViewModel со свойствами View (например, текстовые поля)
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //[CallerMemberName] - атрибут, с помощью которого компилятор может взять название аргумента из вызывающего свойства
        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            //? - проверка на null, this - ссылка на ViewModel
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                //[CallerMemberName] позволяет в этом месте оставлять скобки пустыми
                OnPropertyChanged();
            }
        }

        private double length;
        public double Length
        {
            get => length;
            set
            {
                length = value;
                //[CallerMemberName] позволяет в этом месте оставлять скобки пустыми
                OnPropertyChanged();
            }
        }

        //Блок определения команд
        //Команда
        public ICommand AddCommand { get; }
        //метод для подстановки на место Execute из RelayCommand
        private void OnAddCommandExecute(object p)
        {
            //определение длины окружности через ссылку на метод из Models (CircleLength)
            Length = CircleLength.GetCircleLength(Radius);
        }
        //метод для подстановки на место CanExecute из RelayCommand
        private bool CanAddCommandExecuted(object p)
        {
            //место для условий ограничения доступности выполнения команды
            return true;
        }

        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
        }
    }
}
