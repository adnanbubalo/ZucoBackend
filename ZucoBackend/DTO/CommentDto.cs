namespace ZucoBackend.DTO
{
    public class CommentDto
    {
        public string Author { get; set; } = "Anoniman korisnik";
        public string Content { get; set; } = string.Empty;
        public int ReportId { get; set; }
    }
}
