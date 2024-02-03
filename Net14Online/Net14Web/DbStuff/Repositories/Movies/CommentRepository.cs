using Net14Web.DbStuff.Models.Movies;

namespace Net14Web.DbStuff.Repositories.Movies
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(WebDbContext context) : base(context) { }
    }
}
