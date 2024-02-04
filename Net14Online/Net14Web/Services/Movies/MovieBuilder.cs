using Net14Web.DbStuff.Models.Movies;
using Net14Web.Models.Movies;

namespace Net14Web.Services.Movies
{
    public class MovieBuilder
    {
        private readonly CommentBuilder _commentBuilder;

        public MovieBuilder(CommentBuilder commentBuilder)
        {
            _commentBuilder = commentBuilder;
        }

        public MovieViewModel RebuildMovieToMovieViewModel(Movie movie)
        {
            var movieView = new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title ?? "",
                Description = movie.Description ?? "",
                PosterUrl = movie.PosterUrl ?? "",
                Comments = movie.Comments?.Select(c => _commentBuilder.BuildCommentToMovie(c)).ToList() ?? new List<CommentOnMovieViewModel>()
            };
            return movieView;
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
