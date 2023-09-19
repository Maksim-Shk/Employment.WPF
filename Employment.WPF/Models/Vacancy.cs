using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Employment.WPF.Models;

public class Vacancy
{
    public Vacancy()
    {
        Responsibilities = new List<VacancyResponsibility>();
        Skills = new List<VacancySkill>();
    }

    public int VacancyId { get; set; }
    public string Name { get; set; } = null!;

    /// <summary>
    /// оформление трудовой книжки 
    /// </summary>
    public bool WorkBookRegistration { get; set; }

    /// <summary>
    /// наличие социального пакета
    /// </summary>
    public bool SocialPackage { get; set; }

    public DateTime OpenDate { get; set; }
    public DateTime? CloseDate { get; set; } = null;


    [DisplayName("Пол")]
    public string? Gender { get; set; } = "Не указан";
    public int? LowerAge { get; set; } = null;
    public int? TopAge { get; set; } = null;

    public double? LowerSalary { get; set; }
    public double? UpperSalary { get; set; }

    public int EducationId { get; set; }
    public Guid CompanyId { get; set; }
    public int PositionId { get; set; }
    //public int SalaryId { get; set; }

    //public PersonRequirement PersonRequirement { get; set; } = null!;
    public Company Company { get; set; } = null!;
    public Education Education { get; set; } = null!;
    public Position Position { get; set; } = null!;
    //public Salary? Salary { get; set; }
    public ICollection<VacancySkill>? Skills { get; set; }
    public ICollection<VacancyResponsibility>? Responsibilities { get; set; }

}
