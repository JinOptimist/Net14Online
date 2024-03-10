using Microsoft.AspNetCore.SignalR;

namespace ManagementCompanyChatService.SignalRHubs
{
    public class BlogHub : Hub
    {
        public void SendComment(string userName, string comment)
        {
            Clients.All.SendAsync("newComment", userName, comment).Wait();
        }

        public void UserEnterToChat(string userName)
        {
            Clients.All.SendAsync("newUserEnterToChat", userName).Wait();
        }
    }
}
