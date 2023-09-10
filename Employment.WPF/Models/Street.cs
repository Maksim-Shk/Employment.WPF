namespace Employment.WPF.Models
{
    public class Street
    {
        public int StreetId { get; set; }
        public string Name { get; set; } = null!;
        public string? ShortName { get; set; }
        public int StreeTypetId { get; set; }

        public StreetType StreetType { get; set; } = null!;
    }
}
