namespace ZucoBackend.DTO
{
    public class ReportDto
    {
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Author { get; set; } = "Anoniman korisnik";
        public int CategoryId { get; set; }
        public int ReportTypeId { get; set; }
        public string Images { get; set; }
        public int Longitude { get; set; }
        public int Amplitude { get; set; }

        public ReportDto()
        {

        }
    }
}
