namespace Employment.WPF.Models
{
    public class Locality
    {
        public int LocalityId { get; set; }
        public string Name { get; set; } = null!;
        public string? ShortName { get; set; }
        public int LocalityTypeId { get; set; }

        public LocalityType LocalityType { get; set; } = null!;

    }
}
