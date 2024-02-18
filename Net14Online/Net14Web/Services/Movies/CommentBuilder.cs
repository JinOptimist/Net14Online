using Net14Web.DbStuff.Models.Movies;
using Net14Web.Models.Movies;
using Net14Web.Services.Movies.Permissions;

namespace Net14Web.Services.Movies
{
    public class CommentBuilder
    {
        private readonly CommentPermissions _commentPermissions;

        public CommentBuilder(CommentPermissions commentPermissions)
        {
            _commentPermissions = commentPermissions;
        }

        public Comment BuildComment(DateTime timeOfWriting, string description, User user, Movie movie)
        {
            var comment = new Comment
            {
                TimeOfWriting = timeOfWriting,
                Description = description,
                Movie = movie,
                User = user
            };
            return comment;
        }

        public CommentOnMovieViewModel BuildCommentToMovie(Comment comment)
        {
            var newComment = new CommentOnMovieViewModel
            {
                Id = comment.Id,
                Description = comment.Description,
                TimeOfWriting = comment.TimeOfWriting,
                User = BuildCommentUserOnMovie(comment.User),
                CanRemoveCommentFromMovie = _commentPermissions.CanDeleteCommentFromMovie(comment.User.Id)
            };
            return newComment;
        }

        public CommentUserOnMovie BuildCommentUserOnMovie(User user)
        {
            var comment = new CommentUserOnMovie
            {
                UserId = user.Id,
                Username = user.Login ?? "",
                AvatarUrl = user.AvatarUrl ?? ""
            };
            return comment;
        }

        public UserCommentViewModel BuildUserCommentView(Comment comment)
        {
            var newComment = new UserCommentViewModel
            {
                Description = comment.Description ?? "",
                TimeOfWritng = comment.TimeOfWriting,
                Movie = BuildMovieUserComment(comment.Movie)
            };
            return newComment;
        }

        public MovieUserComment BuildMovieUserComment(Movie movie)
        {
            var movieComment = new MovieUserComment
            {
                MovieId = movie.Id,
                PosterUrl = movie.PosterUrl ?? "",
                Title = movie.Title ?? "",
                Description = movie.Description ?? ""
            };
            return movieComment;
        }
    }
}
