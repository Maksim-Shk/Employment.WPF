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
            Companies = new ObservableCollection<Company>();
        }

        private ObservableCollection<Company> _companies;
        public ObservableCollection<Company> Companies
        {
            get => _companies;
            set
            {
                _companies = value;
                OnPropertyChanged();
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
                      var positionId = 2; // Используйте int, а не строку для идентификаторов
                      DateTime currentDate = DateTime.Now;

                      string query = $@"
                             SELECT DISTINCT c.*
                             FROM ""Company"" c
                             JOIN ""Vacancy"" v ON c.""CompanyId"" = v.""CompanyId""
                             WHERE v.""PositionId"" = :PositionId AND v.""OpenDate"" <= :CurrentDate AND 
                             (v.""CloseDate"" IS NULL OR v.""CloseDate"" >= :CurrentDate)";

                      using (var db = new EmploymentContext())
                      {
                          Companies = new ObservableCollection<Company>(db.Companies.FromSqlRaw(query,
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
                      //var dateRange = obj as Tuple<DateTime, DateTime>;
                      var dateRange = new Tuple<DateTime, DateTime>(new DateTime(2023, 1, 1), new DateTime(2023, 12, 30));

                      if (dateRange == null) return; // обработка ошибки или добавьте логирование

                      string startDate = dateRange.Item1.ToString("yyyy-MM-dd");
                      string endDate = dateRange.Item2.ToString("yyyy-MM-dd");

                      string query = $@"
                             SELECT p.""PositionId"", p.""Title""
                             FROM ""Vacancy"" v
                             JOIN ""Position"" p ON v.""PositionId"" = p.""PositionId""
                             WHERE v.""OpenDate"" BETWEEN '2023-01-01' AND '2023-10-10'
                             GROUP BY p.""PositionId"", p.""Title""
                             ORDER BY COUNT(v.""VacancyId"") DESC
                             LIMIT 1";

                      using (var db = new EmploymentContext())
                      {
                          var topPositionTitle = db.Positions.FromSqlRaw(query).FirstOrDefault();
                          if (!string.IsNullOrEmpty(topPositionTitle.ToString()))
                          {
                              // Тут вы можете, например, сохранить название позиции в свойстве модели или выполнить другие действия
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
                      DateTime date = (DateTime)obj;
                      string query = @"SELECT DISTINCT c.*
                                      FROM Companies c
                                      JOIN Vacancies v ON c.CompanyId = v.CompanyId
                                      WHERE v.EducationId IS NULL AND v.OpenDate <= @Date AND (v.CloseDate IS NULL OR v.CloseDate >= @Date)";

                      using (var db = new EmploymentContext())
                      {
                          Companies = new ObservableCollection<Company>(db.Companies.FromSqlRaw(query));
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

