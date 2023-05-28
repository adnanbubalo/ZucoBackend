namespace ZucoBackend.Services
{
    public class ReportTypeService
    {
        private AppDbContext db;

        public ReportTypeService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<List<ReportType>> GetReportTypes()
        {
            var reportTypes = await db.ReportTypes.ToListAsync();
            return reportTypes;
        }
        public async Task<ReportType> GetReportType(int id)
        {
            var reportType = await db.ReportTypes.FindAsync(id);
            return reportType;
        }
    }
}
