namespace ZucoBackend.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public string Author { get; set; } = "Anoniman korisnik";
        public int Upvotes { get; set; } = 0;
        public int Downvotes { get; set; } = 0;
        public bool IsApproved { get; set; } = false;
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public ReportType ReportType { get; set; }
        public int ReportTypeId { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Solution>? Solutions { get; set; }
        public int Longitude { get; set; }
        public int Amplitude { get; set; }
    }
}
