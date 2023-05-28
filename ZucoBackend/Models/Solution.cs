namespace ZucoBackend.Models
{
    public class Solution
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Report Report { get; set; }
        public int ReportId { get; set; }
        public string Author { get; set; } = "Anoniman korisnik";
        public string Description { get; set; } = string.Empty;
        public bool Approved { get; set; } = false;
        public Solution()
        {

        }
    }
}
