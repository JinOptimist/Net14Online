using Net14Web.Models.Movies;

namespace Net14Web.Services.Movies
{
    public class MovieBuilder
    {
        public MovieBuilder()
        {
        }

        public MovieViewModel BuildMovie(int id, AddMovieViewModel addMovie)
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
    }
}
