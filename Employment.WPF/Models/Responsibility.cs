
using System.Collections.Generic;

namespace Employment.WPF.Models;

public class Responsibility
{
    public Responsibility()
    {
        Vacancies = new HashSet<VacancyResponsibility>();
    }

    public int ResponsibilityId { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<VacancyResponsibility>? Vacancies { get; set; }
}
