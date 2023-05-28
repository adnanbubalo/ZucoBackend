namespace ZucoBackend.Services
{
    public class CategoryService
    {
        private AppDbContext db;

        public CategoryService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Category>> GetCategories()
        {
            var categories = await db.Categories.ToListAsync();
            return categories;
        }
        public async Task<Category> GetCategory(int id)
        {
            var category = await db.Categories.FindAsync(id);
            return category;
        }
    }
}
