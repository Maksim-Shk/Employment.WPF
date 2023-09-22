using Employment.WPF.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Employment.WPF.ViewModels
{
    public class ResponsibilityViewModel : INotifyPropertyChanged
    {
        public ResponsibilityViewModel()
        {
            Responsibility = new();
            using (var db = new EmploymentContext())
            {
                LoadVacanciesCommand.Execute(null);
            }
        }

        private ObservableCollection<Responsibility> _responsibility;
        public ObservableCollection<Responsibility> Responsibility
        {
            get
            {
                return _responsibility;
            }
            set
            {
                _responsibility = value;
                OnPropertyChanged("Responsibility");
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
                          Responsibility = new ObservableCollection<Responsibility>(db.Responsibilities.ToList());
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
