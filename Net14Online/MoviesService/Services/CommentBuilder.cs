using CommentMoviesMicroService.DbStuff.Model;

namespace CommentMoviesMicroService.Services
{
    public class CommentBuilder
    {
        public Comment BuildComment(int movieId, int userId, string userName, string userAvatarUrl, string description, DateTime TimeOfWriting)
        {
            var comment = new Comment
            {
                MovieId = movieId,
                UserId = userId,
                UserName = userName,
                UserAvatarUrl = userAvatarUrl,
                Description = description,
                TimeOfWriting = TimeOfWriting
            };
            return comment;
        } 
    }
}
