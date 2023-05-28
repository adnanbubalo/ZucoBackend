namespace ZucoBackend.Services
{
    public class SolutionService
    {

        AppDbContext db;

        public SolutionService(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<Solution> GetSolution(int id)
        {
            var solution = await db.Solutions.FindAsync(id);
            return solution;
        }
        public async Task<List<Solution>> GetSolutions(int id)
        {
            var solutions = await db.Solutions.Where(x => x.ReportId == id).ToListAsync();
            return solutions;
        }

        public async Task<Solution> AddSolution(SolutionDto solutionDto)
        {
            var report = await db.Reports.FindAsync(solutionDto.ReportId);
            var newSolution = new Solution()
            {
                Report = report,
                ReportId = solutionDto.ReportId,
                Author = solutionDto.Author,
                Description = solutionDto.Descritption
            };
            db.Solutions.Add(newSolution);
            await db.SaveChangesAsync();
            return newSolution;
        }
        public async Task<Solution> ApproveSolution(int id)
        {
            var solution = await GetSolution(id);
            solution.Approved = true;
            db.Update(solution);
            await db.SaveChangesAsync();
            return solution;
        }
    }
}
