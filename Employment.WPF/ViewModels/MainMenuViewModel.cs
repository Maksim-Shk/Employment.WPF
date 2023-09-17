using Employment.WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows.Controls;
using System.Windows;

namespace Employment.WPF.ViewModels
{
    public class MainMenuViewModel : INotifyPropertyChanged
    {
        public MainMenuViewModel()
        {

        }


        private RelayCommand _LoadMainWindowCommand;
        public RelayCommand LoadMainWindowCommand
        {
            get
            {
                return _LoadMainWindowCommand ??
                  (_LoadMainWindowCommand = new RelayCommand(obj =>
                  {
                      using (var db = new EmploymentContext())
                      {
                          MessageBox.Show("Hello");
                      }
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
