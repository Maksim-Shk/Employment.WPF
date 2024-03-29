﻿using System;

namespace Employment.WPF.Models
{
    public class VacancyResponsibility
    {
        public int ResponsibilityId { get; set; }
        public int VacancyId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public Responsibility Responsibility { get; set; } = null!;
        public Vacancy Vacancy { get; set; } = null!;
    }
}
