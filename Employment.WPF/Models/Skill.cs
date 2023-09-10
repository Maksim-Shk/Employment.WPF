using System.Collections.Generic;

namespace Employment.WPF.Models;

public class Skill
{
    public Skill()
    {
        Vacancies = new HashSet<VacancySkill>();
    }

    public int SkillId { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<VacancySkill>? Vacancies { get; set; }
}
