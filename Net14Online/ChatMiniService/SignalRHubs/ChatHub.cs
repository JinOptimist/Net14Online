using Microsoft.AspNetCore.SignalR;

namespace ChatMiniService.SignalRHubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(string userName, string message)
        {
            Clients.All.SendAsync("ServerGotOneNewMessage", userName, message).Wait();
        }

        public void NewUserEnterToChat(string userName)
        {
            Clients.All.SendAsync("OneMoreUserEnterToChat", userName).Wait();
        }
    }
}
