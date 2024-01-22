using Net14Web.DbStuff.Models.Movies;
using Net14Web.Models.Movies;

namespace Net14Web.Services.Movies
{
    public class MovieEditHelper
    {
        public void EditMovie(Movie oldMovie, MovieViewModel updateMovie)
        {
            oldMovie.Title = updateMovie.Title;
            oldMovie.PosterUrl = updateMovie.PosterUrl;
            oldMovie.Description = updateMovie.Description;
        }
    }
}
