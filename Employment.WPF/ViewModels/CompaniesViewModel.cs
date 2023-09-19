using Employment.WPF.Models;
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
    public class CompaniesViewModel : INotifyPropertyChanged
    {
        private Company _selectedCompany;
        public Company SelectedCompany
        {
            get => _selectedCompany;
            set
            {
                if (_selectedCompany != value)
                {
                    _selectedCompany = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Company> _Companies;
        public ObservableCollection<Company> Companies
        {
            get
            {
                return _Companies;
            }
            set
            {
                _Companies = value;
                OnPropertyChanged("Companies");
            }
        }

        private RelayCommand _LoadCompaniesCommand;
        public RelayCommand LoadCompaniesCommand
        {
            get
            {
                return _LoadCompaniesCommand ??
                  (_LoadCompaniesCommand = new RelayCommand(obj =>
                  {
                      using (var db = new EmploymentContext())
                      {
                          Companies = new ObservableCollection<Company>(db.Companies.ToList());
                      }
                  }));
            }
        }

        public CompaniesViewModel()
        {
            using (var db = new EmploymentContext())
            {
                LoadCompaniesCommand.Execute(null);
                SelectedCompany = db.Companies.ToList()[0];
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
