using System.ComponentModel.DataAnnotations.Schema;

namespace ZucoBackend.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string DocType { get; set; }
        public string DocUrl { get; set; }
        public Report? Report { get; set; }
        public int? ReportId { get; set; } = null;
    }
}
