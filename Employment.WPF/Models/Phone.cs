using System;

namespace Employment.WPF.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// OrganizationId / CompanyId
        /// </summary>
        public Guid ExternalId { get; set; }

        public EntityType EntityType { get; set; }
        public Company? Company { get; set; }
        //public Organization? Organization { get; set; }
    }
    public enum EntityType
    {
        Company,
        Organization
    }
}
