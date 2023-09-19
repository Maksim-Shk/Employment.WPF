using Employment.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.WPF.ViewModels.DTOs
{
    internal static class Mappings
    {
        public static VacancyDto ToVacancyDto(this Vacancy vacancy) =>
            new()
            {
                VacancyId = vacancy.VacancyId,
                Name = vacancy.Name,
                WorkBookRegistration = vacancy.WorkBookRegistration,
                SocialPackage = vacancy.SocialPackage,
                OpenDate = vacancy.OpenDate,
                CloseDate = vacancy.CloseDate,
                Gender = vacancy.Gender,
                AgeRange = GetAgeRange(vacancy.LowerAge.ToString(), vacancy.TopAge.ToString()),
                LowerAge = vacancy.LowerAge,
                TopAge = vacancy.TopAge,
                SalaryRange = GetSalaryRange(vacancy.LowerSalary.ToString(), vacancy.UpperSalary.ToString()),
                LowerSalary = vacancy.LowerSalary,
                UpperSalary = vacancy.UpperSalary,
                CompanyId = vacancy.CompanyId,
                EducationId = vacancy.EducationId,
                PositionId = vacancy.PositionId
            };

        private static string GetAgeRange(string? lowerAge, string? topAge)
        {
            if (string.IsNullOrEmpty(lowerAge) && string.IsNullOrEmpty(topAge))
            {
                return "не важен";
            }
            else if (string.IsNullOrEmpty(lowerAge))
            {
                return $"до {topAge}";
            }
            else if (string.IsNullOrEmpty(topAge))
            {
                return $"от {lowerAge}";
            }
            else
            {
                return $"{lowerAge} - {topAge}";
            }
        }

        private static string GetSalaryRange(string? lowerSalary, string? topSalary)
        {
            if (string.IsNullOrEmpty(lowerSalary) && string.IsNullOrEmpty(topSalary))
            {
                return "не важен";
            }
            else if (string.IsNullOrEmpty(lowerSalary))
            {
                return $"до {topSalary}";
            }
            else if (string.IsNullOrEmpty(topSalary))
            {
                return $"от {lowerSalary}";
            }
            else
            {
                return $"{lowerSalary} - {topSalary}";
            }
        }
    }
}
