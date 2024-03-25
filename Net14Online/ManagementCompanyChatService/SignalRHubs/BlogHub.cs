using ManagementCompanyChatService.DbStuff;
using ManagementCompanyChatService.DbStuff.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ManagementCompanyChatService.SignalRHubs
{
    public class BlogHub : Hub
    {
        private ChatDbContext _dbContext;

        public BlogHub(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SendComment(string userName, string comment)
        {
            var userComment = new Comment()
            {
                UserName = userName,
                CommentMessage = comment
            };

            _dbContext.Comments.Add(userComment);
            _dbContext.SaveChanges();

            Clients.All.SendAsync("newComment", userName, comment).Wait();
        }

        public void UserEnterToChat(string userName)
        {
            Clients.All.SendAsync("newUserEnterToChat", userName).Wait();
        }

        public void GetLastComments()
        {
            var comments = _dbContext.Comments
                .OrderByDescending(c => c.CreationDate)
                .Take(10)
                .Reverse()
                .ToList();

            Clients.Caller.SendAsync("LastComments", comments).Wait();
        }
    }
}
