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

        public List<Movie> GetMovies(int count)
        {
            return _entyties
                .Take(count)
                .AsNoTracking()
                .ToList();
        }

        public Movie? GetMovieWithComments(int movieId)
        {
            return _entyties
                .Include(u => u.Comments)
                .AsNoTracking()
                .FirstOrDefault(u => u.Id == movieId);
        }

        public async Task<List<Movie>> GetMoviesAsync(int count)
        {
            return await _entyties
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Movie?> GetMovieWithCommentsAsync(int movieId)
        {
            return await _entyties
                .Include(u => u.Comments)
                .ThenInclude(c => c.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == movieId);
        }

        public void UpdateMovie(Movie oldMovie, MovieViewModel updateMovie)
        {
            _movieEditHelper.EditMovie(oldMovie, updateMovie);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateMovieAsync(Movie oldMovie, MovieViewModel updateMovie)
        {
            _movieEditHelper.EditMovie(oldMovie, updateMovie);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
