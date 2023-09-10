using System.Collections.Generic;
using System.ComponentModel;

namespace Employment.WPF.Models;

public class Education
{
    public Education()
    {
        Vacancies = new HashSet<Vacancy>();
    }
    public int EducationId { get; set; }

    [DisplayName("Уровень образования")]
    public string? Level { get; set; }

    public ICollection<Vacancy>? Vacancies { get; set; }
}
