
using BookingChatHub.DbStaff.Models;

namespace BookingChatHub.DbStaff
{
    public class FakeChatDb
    {
        public List<Message> Messages { get; set; }= new List<Message>();

        public void AddMessages(string userName, string messageText)
        {
            var message = new Message
            {
                UserName = userName,
                MessageText = messageText,
                CreationTime = DateTime.Now
            };

            Messages.Add(message);
        }
    }
}
