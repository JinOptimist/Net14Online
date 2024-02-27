using ChatMiniService.DbStuff.Models;

namespace ChatMiniService.DbStuff
{
    public class FakeDb
    {
        public List<Message> Messages { get; set; } = new();

        public void AddMessage(string userName, string messageText)
        {
            var message = new Message
            {
                UserName = userName,
                MessageText = messageText,
                DateCreation = DateTime.Now
            };

            Messages.Add(message);
        }
    }

}