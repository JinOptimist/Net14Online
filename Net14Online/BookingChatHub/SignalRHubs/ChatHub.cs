using BookingChatHub.DbStaff;
using Microsoft.AspNetCore.SignalR;

namespace BookingChatHub.SignalRHubs
{
    public class ChatHub : Hub
    {
        private FakeChatDb _fakeChatDb;

        public ChatHub(FakeChatDb fakeChatDb)
        {
            _fakeChatDb = fakeChatDb;
        }
        public void SendMessage(string userName, string message)
        {
            _fakeChatDb.AddMessages(userName, message);
            Clients.All.SendAsync("newMessage", userName, message).Wait();
        }

        public void NewUserEntered(string userName)
        {
            Clients.All.SendAsync("userEnteredChat", userName).Wait();
        }
        public void GetLastMessages()
        {
            var lastMessages = _fakeChatDb.Messages.OrderByDescending(x => x.CreationTime)
                .Take(10)
                .Reverse()
                .ToList();
            Clients.Caller.SendAsync("LastMessages", lastMessages).Wait();
        }
    }
}
