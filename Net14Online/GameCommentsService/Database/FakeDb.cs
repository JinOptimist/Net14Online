namespace GameCommentsService.Database
{
    public class FakeDb
    {
        public List<Comment> Comments { get; set; } = new();

        public void AddComment(string userName, string commentText)
        {
            var message = new Comment
            {
                UserName = userName,
                Text = commentText,
                TimeOfCreation = DateTime.Now
            };

            Comments.Add(message);
        }
    }
}
