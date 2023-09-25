using Employment.WPF.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Employment.WPF.ViewModels
{
    public class EmploymentViewModel : INotifyPropertyChanged
    {
        public EmploymentViewModel()
        {
            CompaniesWithVacanciesForPosition = new ObservableCollection<Company>();
            using (var db = new EmploymentContext())
            {
                Positions = new ObservableCollection<Position>(db.Positions.ToList());
            }
            CurrentDate = DateTime.Now;
            TopPositionTitle = "Пока что тут пусто";
        }

        private ObservableCollection<Position> _Positions;
        public ObservableCollection<Position> Positions
        {
            get => _Positions;
            set
            {
                _Positions = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Company> _CompaniesWithVacanciesForPosition;
        public ObservableCollection<Company> CompaniesWithVacanciesForPosition
        {
            get => _CompaniesWithVacanciesForPosition;
            set
            {
                _CompaniesWithVacanciesForPosition = value;
                OnPropertyChanged();
            }
        }

        private DateTime _currentDate;
        public DateTime CurrentDate
        {
            get => _currentDate;
            set
            {
                _currentDate = value;
                OnPropertyChanged();
            }
        }
        private string _topPositionTitle;
        public string TopPositionTitle
        {
            get { return _topPositionTitle; }
            set
            {
                if (_topPositionTitle != value)
                {
                    _topPositionTitle = value;
                    OnPropertyChanged(nameof(TopPositionTitle));
                }
            }
        }

        private ObservableCollection<Company> _companiesWithNoEducationRequirement;
        public ObservableCollection<Company> CompaniesWithNoEducationRequirement
        {
            get { return _companiesWithNoEducationRequirement; }
            set
            {
                if (_companiesWithNoEducationRequirement != value)
                {
                    _companiesWithNoEducationRequirement = value;
                    OnPropertyChanged(nameof(CompaniesWithNoEducationRequirement));
                }
            }
        }

        private DateTime _startDate = new DateTime(2022, 10, 10);
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        private DateTime _endDate = new DateTime(2023, 9, 10);
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }


        private RelayCommand _loadCompaniesWithVacanciesForPositionCommand;
        public RelayCommand LoadCompaniesWithVacanciesForPositionCommand
        {
            get
            {
                return _loadCompaniesWithVacanciesForPositionCommand ??
                  (_loadCompaniesWithVacanciesForPositionCommand = new RelayCommand(obj =>
                  {
                      var positionId = (int)obj; // Конвертируем полученный объект в int
                      DateTime currentDate = DateTime.Now;

                      string query = $@"
                             SELECT DISTINCT c.*
                             FROM ""Company"" c
                             JOIN ""Vacancy"" v ON c.""CompanyId"" = v.""CompanyId""
                             WHERE v.""PositionId"" = :PositionId AND v.""OpenDate"" <= :CurrentDate AND 
                             (v.""CloseDate"" IS NULL OR v.""CloseDate"" >= :CurrentDate)";

                      CompaniesWithVacanciesForPosition.Clear();
                      using (var db = new EmploymentContext())
                      {
                          CompaniesWithVacanciesForPosition = new ObservableCollection<Company>(db.Companies.FromSqlRaw(query,
                              new NpgsqlParameter("PositionId", positionId),
                              new NpgsqlParameter("CurrentDate", currentDate)));
                      }
                  }));
            }
        }

        private RelayCommand _loadTopPositionByVacanciesForPeriodCommand;
        public RelayCommand LoadTopPositionByVacanciesForPeriodCommand
        {
            get
            {
                return _loadTopPositionByVacanciesForPeriodCommand ??
                  (_loadTopPositionByVacanciesForPeriodCommand = new RelayCommand(obj =>
                  {
                      var dateRange = obj as Tuple<DateTime, DateTime>;
                      
                      if (dateRange == null) return; 

                      string startDate = dateRange.Item1.ToString("yyyy-MM-dd");
                      string endDate = dateRange.Item2.ToString("yyyy-MM-dd");

                      string query = $@"
                             SELECT p.""PositionId"", p.""Title""
                             FROM ""Vacancy"" v
                             JOIN ""Position"" p ON v.""PositionId"" = p.""PositionId""
                             WHERE v.""OpenDate"" BETWEEN '{startDate}' AND '{endDate}'
                             GROUP BY p.""PositionId"", p.""Title""
                             ORDER BY COUNT(v.""VacancyId"") DESC
                             LIMIT 1";

                      using (var db = new EmploymentContext())
                      {
                          var topPosition = db.Positions.FromSqlRaw(query).FirstOrDefault();
                          if (topPosition != null)
                          {
                              TopPositionTitle = $"Популярная должность: {topPosition.Title}";
                          }
                          else
                          {
                              TopPositionTitle = "Нет данных о популярной должности";
                          }
                      }
                  }));
            }
        }

        private RelayCommand _loadCompaniesWithNoEducationRequirementCommand;
        public RelayCommand LoadCompaniesWithNoEducationRequirementCommand
        {
            get
            {
                return _loadCompaniesWithNoEducationRequirementCommand ??
                  (_loadCompaniesWithNoEducationRequirementCommand = new RelayCommand(obj =>
                  {
                      //DateTime date = (DateTime)obj;
                      var date = DateTime.Now;
                      string query = $@"
                             SELECT DISTINCT c.*
                             FROM ""Company"" c
                             JOIN ""Vacancy"" v ON c.""CompanyId"" = v.""CompanyId""
                             LEFT JOIN ""Education"" e ON v.""EducationId"" = e.""EducationId""
                             WHERE (v.""EducationId"" IS NULL OR e.""Level"" = 'Не имеет значения') 
                                   AND v.""OpenDate"" <= '{date:yyyy-MM-dd}' 
                                   AND (v.""CloseDate"" IS NULL OR v.""CloseDate"" >= '{date:yyyy-MM-dd}')";

                      using (var db = new EmploymentContext())
                      {
                          CompaniesWithNoEducationRequirement = new ObservableCollection<Company>(db.Companies.FromSqlRaw(query));
                      }
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

