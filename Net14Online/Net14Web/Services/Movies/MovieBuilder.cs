using Net14Web.DbStuff.Models.Movies;
using Net14Web.Models.Movies;

namespace Net14Web.Services.Movies
{
    public class MovieBuilder
    {
        public MovieViewModel BuildMovieView(int id, AddMovieViewModel addMovie)
        {
            var movie = new MovieViewModel
            {
                Id = id,
                Title = addMovie.Title,
                Description = addMovie.Description,
                PosterUrl = addMovie.PosterUrl,
                Comments = new()
            };
            return movie;
        }

        public List<MovieViewModel> RebuildMoviesToMoviesViewModel(List<Movie> movies)
        {
            var moviesView = movies.
                Select(mov => new MovieViewModel
                {
                    Id = mov.Id,
                    Title = mov.Title,
                    Description = mov.Description,
                    PosterUrl = mov.PosterUrl,
                    Comments = new()
                }).ToList();
            return moviesView;
        }

        public MovieViewModel RebuildMovieToMovieViewModel(Movie movie)
        {
            var movieView = new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                PosterUrl = movie.PosterUrl,
                Comments = new()
            };
            return movieView;
        }

        public Movie BuildMovie(MovieViewModel addMovie)
        {
            var movie = new Movie
            {
                Title = addMovie.Title,
                Description = addMovie.Description,
                PosterUrl = addMovie.PosterUrl
            };
            return movie;
        }

        public Movie BuildMovie(AddMovieViewModel addMovie)
        {
            var movie = new Movie
            {
                Title = addMovie.Title,
                Description = addMovie.Description,
                PosterUrl = addMovie.PosterUrl
            };
            return movie;
        }
    }
}
