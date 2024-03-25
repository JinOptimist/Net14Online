using ManagementCompany.DbStuff.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace ManagementCompany.SignalRHubs
{
    public class BlogHub : Hub
    {
        

        

        //public void AddDislike(string userName, string comment)
        //{
        //    var userComment = new Comment()
        //    {
        //        UserName = userName,
        //        CommentMessage = comment
        //    };

        //    _dbContext.Comments.Add(userComment);
        //    _dbContext.SaveChanges();

        //    Clients.All.SendAsync("newDislike", userName, comment).Wait();
        //}
    }
}
