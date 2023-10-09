using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.WPF.ViewModels.DTOs
{
    public class ClusteredVacancy
    {
        public double? OriginalAverageSalary { get; set; }
        public double? NormalizedAverageSalary { get; set; }
        public double? OriginalDaysOpen { get; set; }
        public double? NormalizedDaysOpen { get; set; }
        public int? AssignedCluster { get; set; }
        public string? VacancyName { get; set; }
    }

}
