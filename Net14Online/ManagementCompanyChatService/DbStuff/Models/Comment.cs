namespace ManagementCompanyChatService.DbStuff.Models
{
    public class Comment : BaseModel
    {
        public string UserName { get; set; }

        public string CommentMessage { get; set; }

        public Comment() : base() { }
    }
}
