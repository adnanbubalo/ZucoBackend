namespace ZucoBackend.Services
{
    public class CommentService
    {
        AppDbContext db;

        public CommentService(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<Comment> GetComment(int id)
        {
            var comment = await db.Comments.FindAsync(id);
            return comment;
        }
        public async Task<Comment> AddComment(CommentDto comment)
        {
            var newComment = new Comment()
            {
                Author = comment.Author,
                Content = comment.Content,
                CreatedAt = DateTime.Now,
                ReportId = comment.ReportId
            };
            db.Comments.Add(newComment);
            await db.SaveChangesAsync();
            return newComment;
        }
        public async Task<Comment> Upvote(Comment comment)
        {
            comment.Upvotes++;
            db.Update(comment);
            await db.SaveChangesAsync();
            return comment;
        }
        public async Task<Comment> Downvote(Comment comment)
        {
            comment.Downvotes++;
            db.Update(comment);
            await db.SaveChangesAsync();
            return comment;
        }
    }
}
