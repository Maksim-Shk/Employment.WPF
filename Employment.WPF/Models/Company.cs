using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Employment.WPF.Models;
public class Company
{
    public Company()
    {
        Phones = new HashSet<Phone>();
        Vacancies = new HashSet<Vacancy>();
    }

    public Guid CompanyId { get; set; }

    [DisplayName("Наименование")]
    public string Name { get; set; } = null!;

    [DisplayName("Краткое наименование")]
    public string ShortName { get; set; } = null!;

    [DisplayName("Электронная почта")]
    public string? Email { get; set; } = null!;

    public ICollection<Phone>? Phones { get; set; }
    public ICollection<Vacancy>? Vacancies { get; set; }
    public ICollection<Address>? Addresses { get; set; }
}
