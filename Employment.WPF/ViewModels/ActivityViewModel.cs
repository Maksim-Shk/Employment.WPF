using Employment.WPF.Models;
using Employment.WPF.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Employment.WPF.ViewModels
{
    public class ActivityViewModel : INotifyPropertyChanged
    {
        public ActivityViewModel()
        {
            Activity = new();
            using (var db = new EmploymentContext())
            {
                LoadVacanciesCommand.Execute(null);
            }
        }

        private ObservableCollection<Activity> _activity;
        public ObservableCollection<Activity> Activity
        {
            get
            {
                return _activity;
            }
            set
            {
                _activity = value;
                OnPropertyChanged("Activity");
            }
        }

        private RelayCommand _LoadVacanciesCommand;
        public RelayCommand LoadVacanciesCommand
        {
            get
            {
                return _LoadVacanciesCommand ??
                  (_LoadVacanciesCommand = new RelayCommand(obj =>
                  {
                      using (var db = new EmploymentContext())
                      {
                          Activity = new ObservableCollection<Activity>(db.Activities.ToList());
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
