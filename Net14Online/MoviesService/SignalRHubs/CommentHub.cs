using CommentMoviesMicroService.DbStuff.Repositories;
using CommentMoviesMicroService.Services;
using Microsoft.AspNetCore.SignalR;

namespace CommentMoviesMicroService.SignalRHubs
{
    public class CommentHub : Hub
    {
        private readonly CommentRepository _commentRepository;
        private readonly CommentBuilder _commentBuilder;
        public const int COUNT_LAST_COMMENTS = 10;
        private string? _lastMovieConnectId;

        public CommentHub(CommentRepository commentRepository, CommentBuilder commentBuilder)
        {
            _commentRepository = commentRepository;
            _commentBuilder = commentBuilder;
        }

        public void AddNewComment(string movieId, string userId, string userName, string userAvatarUrl, string description)
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
            var comment = _commentBuilder.BuildComment(movieIdInt, userIdInt, userName, userAvatarUrl, description, timeOfWriting);
            _commentRepository.Add(comment);
            Clients.All.SendAsync("MovieGotNewComment", comment).Wait();
        }
        
        public void GetLastMovieComments(string movieId)
        {
            int movieIdInt = 0;
            if (int.TryParse (movieId, out movieIdInt) == false)
            {
                return;
            }
            var movieComments = _commentRepository
                .GetMoviesComments(movieIdInt)
                .TakeLast(COUNT_LAST_COMMENTS)
                .ToList();
            Clients.Caller.SendAsync("LastComments", movieComments);
        }

        public void OpenMovie(string movieId)
        {
            if (_lastMovieConnectId is not null)
            {
                Groups.RemoveFromGroupAsync(Context.ConnectionId, _lastMovieConnectId);
            }
            _lastMovieConnectId = movieId;
            Groups.AddToGroupAsync(Context.ConnectionId, _lastMovieConnectId);
        }
    }
    
}
