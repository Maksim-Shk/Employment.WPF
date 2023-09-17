using System.Collections.Generic;
using System.ComponentModel;

namespace Employment.WPF.Models;

public class Position
{
    public Position()
    {
        Vacancies = new HashSet<Vacancy>();
    }
    public int PositionId { get; set; }

    [DisplayName("Должность")]
    public string? Title { get; set; }

    public ICollection<Vacancy>? Vacancies { get; set; }
}
