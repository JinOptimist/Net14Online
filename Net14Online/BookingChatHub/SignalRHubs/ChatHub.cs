using Microsoft.AspNetCore.SignalR;

namespace BookingChatHub.SignalRHubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(string userName, string message)
        {
            Clients.All.SendAsync("newMessage", userName, message).Wait();
        }

        public void NewUserEntered(string userName)
        {
            Clients.All.SendAsync("userEnteredChat", userName).Wait();
        }
    }
}
