using Employment.WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Employment.WPF.ViewModels.DTOs
{
    public class VacancyDto
    {
        public int VacancyId { get; set; }

        [DisplayName("Вакансия")]
        public string Name { get; set; }

        [DisplayName("Трудовая книжка")]
        public bool WorkBookRegistration { get; set; }

        [DisplayName("Соц. пакет")]
        public bool SocialPackage { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; } = null;

        [DisplayName("Пол")]
        public string? Gender { get; set; } = "Не указан";
        public int? LowerAge { get; set; } = null;
        public int? TopAge { get; set; } = null;

        [DisplayName("Возраст")]
        public string? AgeRange { get; set; }

        public double? LowerSalary { get; set; }
        public double? UpperSalary { get; set; }

        [DisplayName("Зарплата")]
        public string? SalaryRange { get; set; }

        [DisplayName("Уровень образования")]
        public string? Education { get; set; }
        public int? EducationId { get; set; }

        [DisplayName("Компания")]
        public string? Company { get; set; }
        public Guid CompanyId { get; set; }

        [DisplayName("Должность")]
        public string? Position { get; set; }
        public int? PositionId { get; set; }

        public ObservableCollection<Skill>? Skills { get; set; }
        public ObservableCollection<Responsibility>? Responsibilities { get; set; }


    }
}
