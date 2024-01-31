using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.Movies;
using Net14Web.Models.Movies;
using Net14Web.Services.Movies;

namespace Net14Web.DbStuff.Repositories.Movies
{
    public class MoviesRepository : BaseRepository<Movie>
    {
        public readonly MovieEditHelper _movieEditHelper;

        public MoviesRepository(WebDbContext context, MovieEditHelper movieEditHelper) : base(context)
        {
            _movieEditHelper = movieEditHelper;
        }

        public Movie? GetMovieWithComments(int movieId)
        {
            return _entyties
                .Include(u => u.Comments)
                .FirstOrDefault(u => u.Id == movieId);
        }

        public void UpdateMovie(Movie oldMovie, MovieViewModel updateMovie)
        {
            _movieEditHelper.EditMovie(oldMovie, updateMovie);
            _context.SaveChanges();
        }
    }
}
