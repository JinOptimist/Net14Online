using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.Movies;

namespace Net14Web.DbStuff.Repositories.Movies
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(WebDbContext context) : base(context) { }

        public Comment GetByIdCommentWithMovie(int commentId)
        {
            return _entyties
                .Include(c => c.Movie)
                .First(c => c.Id == commentId);
        }

        public async Task<Comment> GetByIdCommentWithMovieAsync(int commentId)
        {
            return await _entyties
                .Include(c => c.Movie)
                .FirstAsync(c => c.Id == commentId);
        }

        public Comment GetByIdCommentWithMovieAndUser(int commentId)
        {
            return _entyties
                .Include(c => c.Movie)
                .Include(c => c.User)
                .First(c => c.Id == commentId);
        }

        public Comment GetByIdCommentWithUser(int commentId)
        {
            return _entyties
                .Include(c => c.User)
                .First(c => c.Id == commentId);
        }
    }
}
