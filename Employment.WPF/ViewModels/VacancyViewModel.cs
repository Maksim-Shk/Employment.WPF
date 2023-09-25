﻿using Employment.WPF.Models;
using Employment.WPF.ViewModels.DTOs;
using Microsoft.EntityFrameworkCore;
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
            Vacancies = new();
            using (var db = new EmploymentContext())
            {
                LoadVacanciesCommand.Execute(db.Companies.First());
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
