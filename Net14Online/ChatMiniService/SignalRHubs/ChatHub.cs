using ChatMiniService.DbStuff;
using Microsoft.AspNetCore.SignalR;

namespace ChatMiniService.SignalRHubs
{
    public class ChatHub : Hub
    {
        private FakeDb _fakeDb;

        public ChatHub(FakeDb fakeDb)
        {
            _fakeDb = fakeDb;
        }

        public void SendMessage(string userName, string message)
        {
            _fakeDb.AddMessage(userName, message);
            Clients.All.SendAsync("ServerGotOneNewMessage", userName, message).Wait();
        }

        public void NewUserEnterToChat(string userName)
        {
            Clients.All.SendAsync("OneMoreUserEnterToChat", userName).Wait();
        }

        public void GetLastMessages()
        {
            var lastMessages = _fakeDb
                .Messages
                .OrderByDescending(x => x.DateCreation)
                .Take(10)
                .Reverse()
                .ToList();
            Clients.Caller.SendAsync("LastMessages", lastMessages);
        }
    }
}
