using Employment.WPF.Models;
using Employment.WPF.ViewModels.DTOs;
using Employment.WPF.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Employment.WPF.ViewModels
{
    public class VacancyDtoViewModel : INotifyPropertyChanged
    {
        public VacancyDtoViewModel()
        {
            Vacancies = new();
            using (var db = new EmploymentContext())
            {
                LoadVacanciesCommand.Execute(db.Companies.First());

                CompanyCollection = new ObservableCollection<Company>(db.Companies.ToList());

                PositionCollection = new ObservableCollection<Position>(db.Positions.ToList());
                EducationCollection = new ObservableCollection<Education>(db.Educations.ToList());
                SkillCollection = new ObservableCollection<Skill>(db.Skills.ToList());
                ResponsibilityCollection = new ObservableCollection<Responsibility>(db.Responsibilities.ToList());

                LocalityTypeCollection = new ObservableCollection<LocalityType>(db.LocalityTypes.ToList());
                StreetCollection = new ObservableCollection<Street>(db.Streets.ToList());
                StreetTypeCollection = new ObservableCollection<StreetType>(db.StreetTypes.ToList());
                LocalityCollection = new ObservableCollection<Locality>(db.Localities.ToList());
            }
        }

        private ObservableCollection<VacancyDto> _Vacancies;
        public ObservableCollection<VacancyDto> Vacancies
        {
            get
            {
                return _Vacancies;
            }
            set
            {
                _Vacancies = value;
                OnPropertyChanged("Vacancies");
            }
        }

        private VacancyDto _selectedVacancy;
        public VacancyDto SelectedVacancy
        {
            get => _selectedVacancy;
            set
            {
                if (_selectedVacancy != value)
                {
                    _selectedVacancy = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddVacancyCommand => new RelayCommand(_ => AddVacancy());
        public ICommand UpdateVacancyCommand => new RelayCommand(_ => UpdateVacancy());

        private void AddVacancy()
        {
            var addOrUpdateWindow = new AddOrUpdateVacancy();
            var vacancyViewModel = new VacancyViewModel();
            addOrUpdateWindow.DataContext = vacancyViewModel;
            addOrUpdateWindow.ShowDialog();
        }
        private void UpdateVacancy()
        {
            if (SelectedVacancy == null) return;
            using (var db = new EmploymentContext())
            {
                var addOrUpdateWindow = new AddOrUpdateVacancy();
                var vacancy = db.Vacancies.FirstOrDefault(v => v.VacancyId == SelectedVacancy.VacancyId);

                vacancy.Skills = db.VacancySkills.Where(x => x.VacancyId == vacancy.VacancyId).ToList();
                vacancy.Responsibilities = db.VacancyResponsibilities.Where(x => x.VacancyId == vacancy.VacancyId).ToList();
                
                var vacancyViewModel = new VacancyViewModel(vacancy);
                addOrUpdateWindow.DataContext = vacancyViewModel;
                addOrUpdateWindow.ShowDialog();
            }
        }

        private RelayCommand _GetAllVacanciesCommand;
        public RelayCommand GetAllVacanciesCommand
        {
            get
            {
                return _GetAllVacanciesCommand ??
                  (_GetAllVacanciesCommand = new RelayCommand(obj =>
                  {
                      using (var db = new EmploymentContext())
                      {
                          var company = obj as Company;
                          var vacancies = db.Vacancies
                                            .Include(v => v.Skills).ThenInclude(vs => vs.Skill)
                                            .Include(v => v.Responsibilities).ThenInclude(vr => vr.Responsibility)
                                            .Include(v => v.Education)
                                            .Include(v => v.Position)
                                            .Select(v => v.ToVacancyDto())
                                            .ToList();

                          Vacancies = new ObservableCollection<VacancyDto>(vacancies);
                      }
                  }));
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
                          var company = obj as Company;
                          var vacancies = db.Vacancies
                                            .Include(v => v.Skills).ThenInclude(vs => vs.Skill)
                                            .Include(v => v.Responsibilities).ThenInclude(vr => vr.Responsibility)
                                            .Include(v => v.Education)
                                            .Include(v => v.Position)
                                            .Where(x => x.CompanyId == company.CompanyId)
                                            .Select(v => v.ToVacancyDto())
                                            .ToList();

                          Vacancies = new ObservableCollection<VacancyDto>(vacancies);
                      }
                  }));
            }
        }

        #region collections

        private ObservableCollection<Position> _PositionCollection;
        public ObservableCollection<Position> PositionCollection
        {
            get
            {
                return _PositionCollection;
            }
            set
            {
                _PositionCollection = value;
                OnPropertyChanged("PositionCollection");
            }
        }

        private ObservableCollection<Education> _EducationCollection;
        public ObservableCollection<Education> EducationCollection
        {
            get
            {
                return _EducationCollection;
            }
            set
            {
                _EducationCollection = value;
                OnPropertyChanged("EducationCollection");
            }
        }

        private ObservableCollection<Skill> _SkillCollection;
        public ObservableCollection<Skill> SkillCollection
        {
            get
            {
                return _SkillCollection;
            }
            set
            {
                _SkillCollection = value;
                OnPropertyChanged("SkillCollection");
            }
        }

        private ObservableCollection<Responsibility> _ResponsibilityCollection;
        public ObservableCollection<Responsibility> ResponsibilityCollection
        {
            get
            {
                return _ResponsibilityCollection;
            }
            set
            {
                _ResponsibilityCollection = value;
                OnPropertyChanged("ResponsibilityCollection");
            }
        }

        private ObservableCollection<LocalityType> _LocalityTypeCollection;
        public ObservableCollection<LocalityType> LocalityTypeCollection
        {
            get
            {
                return _LocalityTypeCollection;
            }
            set
            {
                _LocalityTypeCollection = value;
                OnPropertyChanged("LocalityTypeCollection");
            }
        }

        private ObservableCollection<Street> _StreetCollection;
        public ObservableCollection<Street> StreetCollection
        {
            get
            {
                return _StreetCollection;
            }
            set
            {
                _StreetCollection = value;
                OnPropertyChanged("StreetCollection");
            }
        }

        private ObservableCollection<StreetType> _StreetTypeCollection;
        public ObservableCollection<StreetType> StreetTypeCollection
        {
            get
            {
                return _StreetTypeCollection;
            }
            set
            {
                _StreetTypeCollection = value;
                OnPropertyChanged("StreetTypeCollection");
            }
        }

        private ObservableCollection<Locality> _LocalityCollection;
        public ObservableCollection<Locality> LocalityCollection
        {
            get
            {
                return _LocalityCollection;
            }
            set
            {
                _LocalityCollection = value;
                OnPropertyChanged("LocalityCollection");
            }
        }

        private ObservableCollection<Company> _CompanyCollection;
        public ObservableCollection<Company> CompanyCollection
        {
            get
            {
                return _CompanyCollection;
            }
            set
            {
                _CompanyCollection = value;
                OnPropertyChanged("CompanyCollection");
            }
        }

        #endregion



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
