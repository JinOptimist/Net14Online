using Net14Web.Models.Movies;

namespace Net14Web.Services.Movies
{
    public class CommentBuilder
    {
        public CommentsOnMovieViewModel BuildCommentToMovie(DateTime timeOfWriting, string description, UserViewModel user)
        {
            var comment = new CommentsOnMovieViewModel
            {
                Description = description,
                TimeOfWriting = timeOfWriting,
                User = user
            };
            return comment;
        }

        public UserCommentViewModel BuildCommentToUser(DateTime timeOfWriting, string description, MovieViewModel movie)
        {
            var comment = new UserCommentViewModel
            {
                Description = description,
                TimeOfWritng = timeOfWriting,
                Movie = movie
            };
            return comment;
        }
    }
}
