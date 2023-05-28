namespace ZucoBackend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; } = "Anoniman korisnik";
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int Upvotes { get; set; } = 0;
        public int Downvotes { get; set; } = 0;
        [JsonIgnore]
        public Report Report { get; set; }
        public int ReportId { get; set; }
    }
}
