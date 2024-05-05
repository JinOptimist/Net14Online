namespace BookingChatHub.DbStaff.Models
{
    public class Message 
    {
        public string UserName { get; set; }
        public string MessageText { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
