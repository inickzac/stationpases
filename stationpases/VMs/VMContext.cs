using stationpases.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace stationpases.VMs
{
    public class VMContext
    {
        DisplayRootRegistry displayRootRegistry = (Application.Current as App).displayRootRegistry;

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private RelayCommand openModalWindow;
        private RelayCommand saveInBD;

        public RelayCommand OpenModalWindow
        {
            get
            {
                return openModalWindow ??
                  (openModalWindow = new RelayCommand(async obj =>
                  {

                  }));
            }
        }
        public RelayCommand SaveInBD
        {
            get
            {
                return saveInBD ??
                  (saveInBD = new RelayCommand(obj =>
                  {

                  }));
            }
        }

    }
}
