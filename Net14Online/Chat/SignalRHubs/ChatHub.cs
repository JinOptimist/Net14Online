using Microsoft.AspNetCore.SignalR;

namespace Chat.SignalRHubs;

public class ChatHub : Hub
{
    public void SendMassage(string userName, string massageText)
    {
        Clients.All.SendAsync("ServerGotOneNewMessage", userName, massageText).Wait();
    }
    
}