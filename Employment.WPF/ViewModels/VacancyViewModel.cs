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
        public VacancyViewModel()
        {
            using (var db = new EmploymentContext())
            {
                CurrentVacancy = db.Vacancies.FirstOrDefault(); 

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
