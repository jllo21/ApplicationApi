namespace ApplicationApi
{
    public class Application
    {
        // Model to load data into
        public int Id { get; set; }
        public DateTime DateTimeUpdated { get; set; }
        public string? Email {get; set; }
        public string? NameFirst { get; set; }
        public string? NameLast { get; set; }
        public string? BusinessName { get; set; }
        public string? BusinessCategory { get; set; }
    }
}
