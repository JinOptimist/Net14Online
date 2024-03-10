using GameCommentsService.Database;
using Microsoft.AspNetCore.SignalR;

namespace GameCommentsService.Hubs
{
    public class CommentHub : Hub
    {
        private readonly FakeDb _database;

        public CommentHub(FakeDb database)
        {
            _database = database;
        }

        public void AddComment(string userName, string comment)
        {
            _database.AddComment(userName, comment);
            Clients.All.SendAsync("RetriveNewComment", userName, comment).Wait();
        }

        public void GetLastComments()
        {
            var lastComments = _database
                .Comments
                .OrderByDescending(x => x.TimeOfCreation)
                .Take(10)
                .Reverse()
                .ToList();
            Clients.Caller.SendAsync("LastComments", lastComments).Wait();
        }
    }
}
