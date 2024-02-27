using Microsoft.AspNetCore.SignalR;
using MoviesMicroService.Model;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Services.Movies;

namespace MoviesMicroService.SignalRHubs
{
    public class CommentHub : Hub
    {
        private readonly UserRepository _userRepository;
        private readonly CommentRepository _commentRepository;
        private readonly MoviesRepository _moviesRepository;
        private readonly CommentBuilder _commentBuilder;

        public const int COUNT_LAST_COMMENTS = 10;

        public CommentHub(UserRepository userRepository, CommentRepository commentRepository, CommentBuilder commentBuilder, MoviesRepository moviesRepository)
        {
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _commentBuilder = commentBuilder;
            _moviesRepository = moviesRepository;
        }

        public void AddNewComment(string userId, string movieId, string description)
        {
            int userIdInt = 0;
            if (int.TryParse(userId, out userIdInt) == false)
            {
                return;
            }
            int movieIdInt = 0;
            if (int.TryParse(movieId, out movieIdInt) == false)
            {
                return;
            }
            var timeOfWriting = DateTime.Now;
            var user = _userRepository.GetById(userIdInt);
            var movie = _moviesRepository.GetById(movieIdInt);
            var comment = _commentBuilder.BuildComment(timeOfWriting, description, user, movie);
            _commentRepository.Add(comment);
            Clients.All.SendAsync("MovieGotNewComment", userId, user.Login, user.AvatarUrl, description, timeOfWriting).Wait();
        }
        
        public void GetLastMovieComments(string movieId)
        {
            int movieIdInt = 0;
            if (int.TryParse (movieId, out movieIdInt) == false)
            {
                return;
            }
            var movies = _moviesRepository
                .GetMovieWithComments(movieIdInt);
            var movieComments = movies.Comments
                .Take(COUNT_LAST_COMMENTS)
                .Reverse()
                .ToList();
            List<Comment> commentsWithUser = new List<Comment>();
            foreach (var movieComment in movieComments)
            {
                var comment = _commentRepository.GetByIdCommentWithUser(movieComment.Id);
                var commentHub = new Comment
                {
                    UserId = comment.User.Id,
                    UserAvatarUrl = comment.User.AvatarUrl,
                    UserName = comment.User.Login,
                    TimeOfWriting = comment.TimeOfWriting,
                    Description = comment.Description
                };
                commentsWithUser.Add(commentHub);
            }
            Clients.Caller.SendAsync("LastComments", commentsWithUser);
        }
    }
    
}
