using Employment.WPF.Models;
using Employment.WPF.ViewModels.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Employment.WPF.ViewModels
{
    public class VacancyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ResponsibilityViewModel> AvailableResponsibilities { get; set; }
        public ObservableCollection<ResponsibilityViewModel> SelectedResponsibilities { get; set; }

        public ObservableCollection<SkillViewModel> AvailablSkills { get; set; }
        public ObservableCollection<SkillViewModel> SelectedSkills { get; set; }

        public void OnLoad()
        {
            using (var db = new EmploymentContext())
            {
                AvailableResponsibilities = new ObservableCollection<ResponsibilityViewModel>(
                    db.Responsibilities.Select(r => new ResponsibilityViewModel(r)));
                SelectedResponsibilities = new ObservableCollection<ResponsibilityViewModel>();

                foreach (var rvm in AvailableResponsibilities)
                {
                    rvm.OnSelectedChanged += (sender, args) =>
                    {
                        var item = sender as ResponsibilityViewModel;
                        if (item != null)
                        {
                            if (item.IsSelected)
                            {
                                SelectedResponsibilities.Add(item);
                                AvailableResponsibilities.Remove(item);
                            }
                            else
                            {
                                AvailableResponsibilities.Add(item);
                                SelectedResponsibilities.Remove(item);
                            }
                        }
                    };
                }

                AvailablSkills = new ObservableCollection<SkillViewModel>(
                    db.Skills.Select(r => new SkillViewModel(r)));
                SelectedSkills = new ObservableCollection<SkillViewModel>();

                foreach (var svm in AvailablSkills)
                {
                    svm.OnSelectedChanged += (sender, args) =>
                    {
                        var item = sender as SkillViewModel;
                        if (item != null)
                        {
                            if (item.IsSelected)
                            {
                                SelectedSkills.Add(item);
                                AvailablSkills.Remove(item);
                            }
                            else
                            {
                                AvailablSkills.Add(item);
                                SelectedSkills.Remove(item);
                            }
                        }
                    };
                }

                CompanyCollection = new ObservableCollection<Company>(db.Companies.ToList());

                PositionCollection = new ObservableCollection<Position>(db.Positions.ToList());
                EducationCollection = new ObservableCollection<Education>(db.Educations.ToList());
                SkillCollection = new ObservableCollection<Skill>(db.Skills.ToList());
                ResponsibilityCollection = new ObservableCollection<Responsibility>(db.Responsibilities.ToList());

                LocalityTypeCollection = new ObservableCollection<LocalityType>(db.LocalityTypes.ToList());
                StreetCollection = new ObservableCollection<Street>(db.Streets.ToList());
                StreetTypeCollection = new ObservableCollection<StreetType>(db.StreetTypes.ToList());
                LocalityCollection = new ObservableCollection<Locality>(db.Localities.ToList());

                CurrentVacancy = new();
            }
        }

        public VacancyViewModel()
        {
            OnLoad();
            VacancyOpenDate = DateTime.Now;
        }
        public VacancyViewModel(Vacancy vacancy)
        {
            //VacancyName = vacancy.Name;
            //VacancyLowerAge = vacancy.LowerAge;
            //VacancyTopAge = vacancy.TopAge;
            //VacancyLowerSalary = vacancy.LowerSalary;
            //VacancyUpperSalary = vacancy.UpperSalary;
            //VacancySocialPackage = vacancy.SocialPackage;
            //VacancyWorkBookRegistration = vacancy.WorkBookRegistration;
            //VacancyOpenDate = vacancy.OpenDate;


            OnLoad();
            CurrentVacancy = vacancy;
            //using (var db = new EmploymentContext())
            //{
            //    foreach (var resp in vacancy.Responsibilities)
            //    {
            //        SelectedResponsibilities
            //            .Add(new ResponsibilityViewModel(db.Responsibilities
            //            .First(r => r.ResponsibilityId == resp.ResponsibilityId)));
            //        AvailableResponsibilities.Remove(new ResponsibilityViewModel(db.Responsibilities
            //            .First(r => r.ResponsibilityId == resp.ResponsibilityId)));
            //    }
            //    foreach (var skill in vacancy.Skills)
            //    {
            //        SelectedSkills
            //            .Add(new SkillViewModel(db.Skills
            //            .First(r => r.SkillId == skill.SkillId)));
            //        AvailablSkills.Remove(new SkillViewModel(db.Skills
            //            .First(r => r.SkillId == skill.SkillId)));
            //    }
            //}

            AvailableResponsibilities.Where(resp =>
                CurrentVacancy.Responsibilities.Any(vacResp =>
                vacResp.ResponsibilityId == resp.Responsibility.ResponsibilityId))
                .ToList()
                .ForEach(resp => resp.IsSelected = true);

            AvailablSkills.Where(skill =>
                CurrentVacancy.Skills.Any(vacSkill =>
                vacSkill.SkillId == skill.Skill.SkillId))
                .ToList()
                .ForEach(skill => skill.IsSelected = true);

            //using (var db = new EmploymentContext())
            //{
            //    var matchingResponsibilities = AvailableResponsibilities
            //        .Where(resp => CurrentVacancy.Responsibilities
            //        .Any(vacResp => vacResp.ResponsibilityId == resp.Responsibility.ResponsibilityId))
            //        .ToList();


            //    foreach (var responsibility in CurrentVacancy.Responsibilities)
            //    {
            //        if (AvailableResponsibilities
            //            .Any(resp => resp.Responsibility.ResponsibilityId == responsibility.ResponsibilityId))
            //        {

            //        }
            //    }
            //}
        }

        private void AddResponsibilitiesAndSkills(EmploymentContext db)
        {
            foreach (var resp in SelectedResponsibilities)
            {
                db.VacancyResponsibilities.Add(new VacancyResponsibility
                {
                    ResponsibilityId = resp.Responsibility.ResponsibilityId,
                    VacancyId = CurrentVacancy.VacancyId
                });
            }
            foreach (var skill in SelectedSkills)
            {
                db.VacancySkills.Add(new VacancySkill
                {
                    SkillId = skill.Skill.SkillId,
                    VacancyId = CurrentVacancy.VacancyId
                });
            }
        }

        private RelayCommand _AddCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _AddCommand ??
                  (_AddCommand = new RelayCommand(obj =>
                  {
                      using (var db = new EmploymentContext())
                      {
                          using (var transaction = db.Database.BeginTransaction())
                          {
                              try
                              {
                                  CurrentVacancy.OpenDate = CurrentVacancy.OpenDate.ToUniversalTime();
                                  CurrentVacancy.CloseDate = null;
                                  if (CurrentVacancy.VacancyId == null || CurrentVacancy.VacancyId < 1)
                                  {
                                      db.Vacancies.Add(CurrentVacancy);
                                      db.SaveChanges();
                                      AddResponsibilitiesAndSkills(db);
                                  }
                                  else
                                  {
                                      db.Vacancies.Update(CurrentVacancy);
                                      db.SaveChanges();

                                      var responsibilitiesToRemove = db.VacancyResponsibilities.Where(resp => resp.VacancyId == CurrentVacancy.VacancyId);
                                      db.VacancyResponsibilities.RemoveRange(responsibilitiesToRemove);

                                      var skillsToRemove = db.VacancySkills.Where(skill => skill.VacancyId == CurrentVacancy.VacancyId);
                                      db.VacancySkills.RemoveRange(skillsToRemove);

                                      db.SaveChanges();

                                      AddResponsibilitiesAndSkills(db);
                                  }

                                  db.SaveChanges();
                                  transaction.Commit();
                              }
                              catch
                              {
                                  transaction.Rollback();
                              }
                          }
                      }
                  }));
            }
        }

        private Vacancy _currentVacancy;
        public Vacancy CurrentVacancy
        {
            get { return _currentVacancy; }
            set
            {
                _currentVacancy = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<ResponsibilityViewModel> _responsibilityViewModelsCollection;
        public ObservableCollection<ResponsibilityViewModel> ResponsibilityViewModelsCollection
        {
            get => _responsibilityViewModelsCollection;
            set
            {
                _responsibilityViewModelsCollection = value;
                OnPropertyChanged(nameof(ResponsibilityViewModelsCollection));
            }
        }

        //private ObservableCollection<ResponsibilityViewModel> _responsibilityViewModelsCollection;
        //public ObservableCollection<ResponsibilityViewModel> ResponsibilityViewModelsCollection
        //{
        //    get => _responsibilityViewModelsCollection;
        //    set
        //    {
        //        _responsibilityViewModelsCollection = value;
        //        OnPropertyChanged(nameof(ResponsibilityViewModelsCollection));
        //    }
        //}

        public int SelectedEducationId
        {
            get { return CurrentVacancy.EducationId; }
            set
            {
                CurrentVacancy.EducationId = value;
                OnPropertyChanged();
            }
        }

        public Guid SelectedCompanyId
        {
            get { return CurrentVacancy.CompanyId; }
            set
            {
                CurrentVacancy.CompanyId = value;
                OnPropertyChanged();
            }
        }

        public int SelectedPositionId
        {
            get { return CurrentVacancy.PositionId; }
            set
            {
                CurrentVacancy.PositionId = value;
                OnPropertyChanged();
            }
        }
        public string VacancyName
        {
            get { return CurrentVacancy.Name; }
            set
            {
                CurrentVacancy.Name = value;
                OnPropertyChanged();
            }
        }
        public bool VacancyWorkBookRegistration
        {
            get { return CurrentVacancy.WorkBookRegistration; }
            set
            {
                CurrentVacancy.WorkBookRegistration = value;
                OnPropertyChanged();
            }
        }
        public bool VacancySocialPackage
        {
            get { return CurrentVacancy.SocialPackage; }
            set
            {
                CurrentVacancy.SocialPackage = value;
                OnPropertyChanged();
            }
        }
        public DateTime VacancyOpenDate
        {
            get { return CurrentVacancy.OpenDate; }
            set
            {
                CurrentVacancy.OpenDate = value;
                OnPropertyChanged();
            }
        }
        public string? VacancyGender
        {
            get { return CurrentVacancy.Gender; }
            set
            {
                CurrentVacancy.Gender = value;
                OnPropertyChanged();
            }
        }
        public int? VacancyLowerAge
        {
            get { return CurrentVacancy.LowerAge; }
            set
            {
                CurrentVacancy.LowerAge = value;
                OnPropertyChanged();
            }
        }

        public int? VacancyTopAge
        {
            get { return CurrentVacancy.TopAge; }
            set
            {
                CurrentVacancy.TopAge = value;
                OnPropertyChanged();
            }
        }

        public double? VacancyLowerSalary
        {
            get { return CurrentVacancy.LowerSalary; }
            set
            {
                CurrentVacancy.LowerSalary = value;
                OnPropertyChanged();
            }
        }

        public double? VacancyUpperSalary
        {
            get { return CurrentVacancy.UpperSalary; }
            set
            {
                CurrentVacancy.UpperSalary = value;
                OnPropertyChanged();
            }
        }

        public ICollection<VacancySkill>? VacancySkills
        {
            get { return CurrentVacancy.Skills; }
            set
            {
                CurrentVacancy.Skills = value;
                OnPropertyChanged();
            }
        }

        public ICollection<VacancyResponsibility>? VacancyResponsibilites
        {
            get { return CurrentVacancy.Responsibilities; }
            set
            {
                CurrentVacancy.Responsibilities = value;
                OnPropertyChanged();
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
