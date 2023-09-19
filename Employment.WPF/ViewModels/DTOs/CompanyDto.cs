using Employment.WPF.Models;
using System.Collections.ObjectModel;

namespace Employment.WPF.ViewModels.DTOs
{
    public class CompanyDto
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ShortName { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }

        public ObservableCollection<Phone>? Phones { get; set; }
        public ObservableCollection<Vacancy>? Vacancies { get; set; }
        public ObservableCollection<Address>? Address  { get; set; }
    }
}
