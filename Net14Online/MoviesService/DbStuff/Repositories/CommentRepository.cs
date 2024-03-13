using CommentMoviesMicroService.DbStuff.Model;

namespace CommentMoviesMicroService.DbStuff.Repositories
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(CommentWebDbContext context) : base(context) { }

        public List<Comment> GetMoviesComments(int movieId)
        {
            return _entyties
                .Where(e => e.MovieId == movieId)
                .ToList();
        }
    }
}
