using ChatMiniService.DbStuff;
using ChatMiniService.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.SignalR;

namespace ChatMiniService.SignalRHubs
{
    public class ChatHub : Hub
    {
        private FakeDb _fakeDb;
        private IValidator<MessageViewModel> _validatorMessageViewModel;

        public ChatHub(FakeDb fakeDb, IValidator<MessageViewModel> validatorMessageViewModel)
        {
            _fakeDb = fakeDb;
            _validatorMessageViewModel = validatorMessageViewModel;
        }

        public void SendMessage(MessageViewModel message)
        {
            var validationResult = _validatorMessageViewModel.Validate(message);
            if (!validationResult.IsValid)
            {
                Console.WriteLine(validationResult.ToDictionary());
                return;
            }

            _fakeDb.AddMessage(message.UserName, message.Message);
            Clients.All.SendAsync("ServerGotOneNewMessage", message.UserName, message.Message).Wait();
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
