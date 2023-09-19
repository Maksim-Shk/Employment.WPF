using Employment.WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows.Controls;
using System.Windows;
using System.Linq;

namespace Employment.WPF.ViewModels
{
    public class BaseEntitiesViewModel : INotifyPropertyChanged
    {
        public BaseEntitiesViewModel()
        {

        }

        #region CurrentEnities
        private Locality _currentLocality;
        public Locality CurrentLocality
        {
            get => _currentLocality;
            set
            {
                if (_currentLocality != value)
                {
                    _currentLocality = value;
                    OnPropertyChanged();
                }
            }
        }

        private Locality _currentStreet;
        public Locality CurrentStreet
        {
            get => _currentStreet;
            set
            {
                if (_currentStreet != value)
                {
                    _currentStreet = value;
                    OnPropertyChanged();
                }
            }
        }

        private Locality _currentLocalityType;
        public Locality CurrentLocalityType
        {
            get => _currentLocalityType;
            set
            {
                if (_currentLocalityType != value)
                {
                    _currentLocalityType = value;
                    OnPropertyChanged();
                }
            }
        }

        private Locality _currentStreetType;
        public Locality CurrentStreetType
        {
            get => _currentStreetType;
            set
            {
                if (_currentStreetType != value)
                {
                    _currentStreetType = value;
                    OnPropertyChanged();
                }
            }
        }
        private Locality _currentAddress;
        public Locality CurrentAddress
        {
            get => _currentAddress;
            set
            {
                if (_currentAddress != value)
                {
                    _currentAddress = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        private RelayCommand _LoadBaseEntitiesWindowCommand;
        public RelayCommand LoadBaseEntitiesCommand
        {
            get
            {
                return _LoadBaseEntitiesWindowCommand ??
                  (_LoadBaseEntitiesWindowCommand = new RelayCommand(obj =>
                  {
                      using (var db = new EmploymentContext())
                      {

                      }
                  }));
            }
        }


        private RelayCommand _addOrUpdateLocalityCommand;
        public RelayCommand AddOrUpdateLocalityCommand
        {
            get
            {
                return _addOrUpdateLocalityCommand ??
                  (_addOrUpdateLocalityCommand = new RelayCommand(obj =>
                  {
                      using (var db = new EmploymentContext())
                      {
                          if (CurrentLocality.LocalityId == 0)
                          {
                              db.Localities.Add(CurrentLocality);
                          }
                          else
                          {
                              var existingLocality = db.Localities.FirstOrDefault(l => l.LocalityId == CurrentLocality.LocalityId);

                              if (existingLocality == null)
                              {
                                  db.Localities.Add(CurrentLocality);
                              }
                              else
                              {
                                  db.Entry(existingLocality).CurrentValues.SetValues(CurrentLocality);
                              }
                          }

                          db.SaveChanges();

                          MessageBox.Show("Locality added or updated successfully!");
                      }
                  },
                  obj => CurrentLocality != null && !string.IsNullOrEmpty(CurrentLocality.Name))); // The command can execute if the CurrentLocality exists and its Name is not empty.
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
