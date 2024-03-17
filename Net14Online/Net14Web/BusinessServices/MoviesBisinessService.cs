using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Models.Movies;
using Net14Web.Services.Movies;

namespace Net14Web.BusinessServices
{
    public class MoviesBisinessService
    {
        private readonly MoviesRepository _moviesRepository;
        private readonly MovieBuilder _movieBuilder;

        private const int COUNT_MOVIES_ON_INDEX = 10;

        public MoviesBisinessService(MoviesRepository moviesRepository, MovieBuilder movieBuilder)
        {
            _moviesRepository = moviesRepository;
            _movieBuilder = movieBuilder;
        }
        
        public List<MovieViewModel> GetMoviesForIndexPage()
        {
            return _moviesRepository
                    .GetMovies(COUNT_MOVIES_ON_INDEX)
                    .Select(m => _movieBuilder.RebuildMovieToMovieViewModel(m))
                    .ToList();
        }
    }
}
