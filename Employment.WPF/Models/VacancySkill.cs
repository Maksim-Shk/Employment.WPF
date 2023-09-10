namespace Employment.WPF.Models
{
    public class VacancySkill
    {
        public int VacancyId { get; set; }
        public int SkillId { get; set; }

        public Vacancy Vacancy { get; set; } = null!;
        public Skill Skill { get; set; } = null!;
    }
}
