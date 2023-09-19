using Employment.WPF.Models;
using Employment.WPF.ViewModels.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Employment.WPF.ViewModels
{
    public class PositionViewModel : INotifyPropertyChanged
    {
        public PositionViewModel()
        {
            Positions = new();
            using (var db = new EmploymentContext())
            {
                LoadVacanciesCommand.Execute(null);
            }
        }

        private ObservableCollection<Position> _positions;
        public ObservableCollection<Position> Positions
        {
            get
            {
                return _positions;
            }
            set
            {
                _positions = value;
                OnPropertyChanged("Positions");
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
                          Positions = new ObservableCollection<Position>(db.Positions.ToList());
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
