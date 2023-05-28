namespace ZucoBackend.Services
{
    public class ReportService
    {
        AppDbContext db;

        public ReportService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Report>> GetReports()
        {
            var reports = await db.Reports
                .Include(r => r.Comments)
                .Include(r => r.Category)
                .Include(r => r.ReportType)
                .ToListAsync();
            return reports;
        }
        public async Task<Report> GetReport(int id)
        {
            var report = await db.Reports.FindAsync(id);
            return report;
        }
        public async Task<Report> AddReport(ReportDto reportDto)
        {
            var category = await db.Categories.FindAsync(reportDto.CategoryId);
            var reportType = await db.ReportTypes.FindAsync(reportDto.ReportTypeId);

            var report = new Report()
            {
                Title = reportDto.Title,
                Description = reportDto.Description,
                CreatedAt = DateTime.Now,
                Author = String.IsNullOrEmpty(reportDto.Author) ? "Anoniman korisnik" : reportDto.Author,
                Category = category,
                CategoryId = reportDto.CategoryId,
                ReportType = reportType,
                ReportTypeId = reportDto.ReportTypeId,
                Image = reportDto.Images,
                Amplitude = reportDto.Amplitude,
                Longitude = reportDto.Longitude,
            };
            db.Reports.Add(report);
            await db.SaveChangesAsync();
            return report;
        }
        public async Task<Report> RemoveReport(Report report)
        {
            db.Reports.Remove(report);
            await db.SaveChangesAsync();
            return report;
        }
        public async Task<Report> Upvote(Report report)
        {
            report.Upvotes++;
            db.Update(report);
            await db.SaveChangesAsync();
            return report;
        }
        public async Task<Report> Downvote(Report report)
        {
            report.Downvotes++;
            db.Update(report);
            await db.SaveChangesAsync();
            return report;
        }
        public async Task<Report> Approve(Report report)
        {
            report.IsApproved = true;
            db.Update(report);
            await db.SaveChangesAsync();
            return report;
        }
        public async Task<List<Comment>> GetComments(int id)
        {
            var comments = await db.Comments.Where(c => c.ReportId == id).ToListAsync();
            return comments;
        }
    }
}
