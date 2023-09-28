using Employment.WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Employment.WPF.ViewModels
{
    public class ResponsibilityViewModel : INotifyPropertyChanged
    {
        private Responsibility _responsibility;

        private bool _isSelected;
        public Responsibility Responsibility => _responsibility;

        public string Name => _responsibility.Name;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));

                    OnSelectedChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public event EventHandler? OnSelectedChanged;
        public ResponsibilityViewModel(Responsibility responsibility)
        {
            _responsibility = responsibility ?? throw new ArgumentNullException(nameof(responsibility));
        }
        //public ResponsibilityViewModel()
        //{
        //    Responsibility = new();
        //    using (var db = new EmploymentContext())
        //    {
        //        LoadVacanciesCommand.Execute(null);
        //    }
        //}

        //private ObservableCollection<Responsibility> _responsibility;
        //public ObservableCollection<Responsibility> Responsibility
        //{
        //    get
        //    {
        //        return _responsibility;
        //    }
        //    set
        //    {
        //        _responsibility = value;
        //        OnPropertyChanged("Responsibility");
        //    }
        //}

        //private RelayCommand _LoadVacanciesCommand;
        //public RelayCommand LoadVacanciesCommand
        //{
        //    get
        //    {
        //        return _LoadVacanciesCommand ??
        //          (_LoadVacanciesCommand = new RelayCommand(obj =>
        //          {
        //              using (var db = new EmploymentContext())
        //              {
        //                  Responsibility = new ObservableCollection<Responsibility>(db.Responsibilities.ToList());
        //              }
        //          }));
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
